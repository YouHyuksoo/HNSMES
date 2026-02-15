"""
@file tools/generate_db_docs.py
@description HANES Oracle DB 메타데이터에서 MkDocs 문서를 자동 생성하는 스크립트

초보자 가이드:
1. DB에서 추출된 JSON 파일들을 읽어 마크다운 문서 생성
2. 실행: python tools/generate_db_docs.py
3. 생성 파일: docs/database/overview.md, procedures-complete.md, erd-complete.md
"""

import json
import os
import re
from collections import defaultdict, OrderedDict

# === 파일 경로 설정 ===
BASE_DIR = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
TOOL_RESULTS_DIR = os.path.join(
    os.path.expanduser("~"), ".claude", "projects",
    "C--Project-HNSMES", "578154bd-1a08-4c38-9d1d-921f7c339893", "tool-results"
)
DOCS_DIR = os.path.join(BASE_DIR, "docs", "database")

# JSON 데이터 파일들
COLUMNS_FILE = os.path.join(TOOL_RESULTS_DIR, "toolu_01Y2LFnPQLf4cwXbwDCpTFMf.txt")
CONSTRAINTS_FILE = os.path.join(TOOL_RESULTS_DIR, "toolu_01Ee7o855kRhcDFadaGsgsfN.txt")
INDEXES_FILE = os.path.join(TOOL_RESULTS_DIR, "toolu_01VcpcRJrdyu1ZaHas5PiBWb.txt")
FUNPROC_FILE = os.path.join(TOOL_RESULTS_DIR, "toolu_01TNG2j4Fjr6C6VV4fUfSUJk.txt")
PKG_SOURCE_FILE = os.path.join(
    os.path.expanduser("~"), "AppData", "Local", "Temp",
    "claude", "C--Project-HNSMES", "tasks", "b44a2c7.output"
)

# 테이블 한글 설명 (DB comments 기반)
TABLE_COMMENTS = {
    "IMHIST_ETC_MIF": "입출력이력-기타",
    "SHPACT_MIF": "작업실적 MES I/F 테이블",
    "TH_BOX": "반제품 BOX 포장 상세 이력",
    "TH_CRIMPING": "압착 이력",
    "TH_CRIMPINSP": "압착검사 이력(결과)관리",
    "TH_CRIMPINSP_20211014": "압착검사 이력 백업(2021-10-14)",
    "TH_CRIMP_IMAGE": "압착검사 이미지 관리",
    "TH_MODBUS_IF": "Modbus 인터페이스",
    "TH_OQC_REPORT": "OQC 리포트",
    "TH_SPLITMERGE": "SPLIT/MERGE 이력",
    "TH_STOCKSERIAL": "재고 시리얼 이력(아카이브)",
    "TH_USESYSTEM": "시스템 사용이력",
    "TH_USESYSTEMLOG": "시스템 로그메시지 사용이력",
    "TH_VERSIONHISTORY": "버전 이력",
    "TH_WORKORD": "생산 작업 이력",
    "TIF_STOCK": "재고 현황(인터페이스)",
    "TL_LOGINFO": "로그 정보",
    "TMP_ACTUALMATERIAL": "재고 실사 정보(자재소요계산임시테이블)",
    "TM_BOM": "BOM마스터",
    "TM_BOMGRP": "BOM그룹마스터",
    "TM_BOM_FIND": "BOM 검색용",
    "TM_BOM_FIND2": "BOM 검색용2",
    "TM_BOM_RELEASE": "BOM 릴리스",
    "TM_BOM_TEMP": "BOM 임시",
    "TM_BOM_TEMP2": "BOM 임시2",
    "TM_BOX": "BOX 정보 마스터",
    "TM_CALENDER": "기준달력(임의의 주를 계산하기 위한 사용자 달력)",
    "TM_CLIENT": "법인마스터",
    "TM_CLOSINGBASE": "마감월기준",
    "TM_COMMCODE": "공통코드 마스터",
    "TM_COMMGRP": "공통코드 그룹",
    "TM_COMPANY": "부속회사마스터",
    "TM_CONVEYOR_REPORT_02": "LQC리포트",
    "TM_CRIMPINSP": "압착검사마스터",
    "TM_CUSTPLAN": "고객 계획",
    "TM_CUSTPLAN_MONTH": "고객 월별 계획",
    "TM_CUSTPLAN_ORDER": "고객 주문 계획",
    "TM_CUSTPLAN_TEMP": "고객 계획 임시",
    "TM_CUSTPLAN_TEMP_TEMP": "고객 계획 임시2",
    "TM_DEFECT": "불량마스터",
    "TM_DEPARTMENT": "부서마스터",
    "TM_DOWNTIME": "비가동마스터",
    "TM_EHR": "인사마스터",
    "TM_EQP": "설비 마스터",
    "TM_FAVORITE": "사용자즐겨찾기",
    "TM_FORMS": "화면마스터",
    "TM_GLOSSARY": "용어마스터",
    "TM_GP12_ITEM": "GP12 품목",
    "TM_INVOICEDETAIL": "인보이스 상세",
    "TM_INVOICEMASTER": "인보이스 마스터",
    "TM_ITEMS": "품목마스터",
    "TM_ITEMS_BAK": "품목마스터 백업",
    "TM_LOCATION": "창고별위치마스터",
    "TM_LQC_REPORT_01": "LQC리포트01",
    "TM_LQC_REPORT_02": "LQC리포트02",
    "TM_LQC_REPORT_02_01": "LQC리포트02_01",
    "TM_LQC_REPORT_03": "LQC리포트03",
    "TM_MAT_BALANCE_TEMP": "자재 잔량 임시",
    "TM_MENU": "메뉴마스터",
    "TM_MENUROLE": "사용자권한별메뉴마스터",
    "TM_MODELBOM": "MODELBOM",
    "TM_NOTICE": "공지마스터",
    "TM_OPERATION": "공정마스터",
    "TM_ORDERDETAIL": "주문 상세",
    "TM_ORDERMASTER": "주문 마스터",
    "TM_PLANT": "공장마스터",
    "TM_POSITION": "직위마스터",
    "TM_PRODLINE": "생산라인마스터",
    "TM_PRODLINE_UNIT": "생산라인설비호기마스터",
    "TM_PRODPLAN": "생산 계획",
    "TM_PRODPLAN_MONTH": "월별 생산 계획",
    "TM_PRODPLAN_MONTH_BALANCE": "월별 생산 계획 잔량",
    "TM_PRODPLAN_MONTH_BEGIN": "월별 생산 계획 기초",
    "TM_PRODPLAN_MONTH_PLAN": "월별 생산 계획 상세",
    "TM_PRODPLAN_MONTH_PRODRESULT": "월별 생산 실적",
    "TM_PRODPLAN_MONTH_RESULT": "월별 생산 결과",
    "TM_PRODPLAN_MONTH_WIP": "월별 생산 재공",
    "TM_PRODPLAN_TEMP": "생산 계획 임시",
    "TM_REASON": "사유코드 마스터",
    "TM_ROUTING": "라우팅마스터",
    "TM_ROUTINGGRP": "라우팅그룹마스터",
    "TM_SERIAL": "시리얼마스터",
    "TM_SUBITEMS": "대체자재마스터",
    "TM_SUBITEMS_DEREK": "대체자재(DEREK용)",
    "TM_SYSTEM": "시스템마스터",
    "TM_SYSUSERROLE": "시스템사용자권한마스터",
    "TM_TRANSACTION": "트랜잭션마스터",
    "TM_UNITCODE": "단위마스터",
    "TM_USER": "사용자마스터",
    "TM_USERROLE": "사용자권한마스터",
    "TM_VENDOR": "거래처마스터",
    "TM_WAREHOUSE": "창고마스터",
    "TM_WORKTIME": "근무인원",
    "TW_ACTUALSTOCK": "재고 실사 정보",
    "TW_BRD": "불량/수리/폐기 이력",
    "TW_COMPARESTOCK": "재고 비교",
    "TW_CRIMPPING": "압착 기준 정보",
    "TW_DAILYWORKPLAN": "일별 생산 계획(통전기준)",
    "TW_IN": "입고 이력",
    "TW_IQC": "IQC정보",
    "TW_MATERIALREQUSET": "자재 요청 정보",
    "TW_MOUNT": "생산 자재 장착 정보",
    "TW_OQC": "출고 이력(OQC)",
    "TW_OUT": "출고 이력",
    "TW_PRODHIST": "생산실적정보",
    "TW_PRODHIST_USE": "생산 차감(사용) 자재 정보",
    "TW_RESPONSENO": "불출지시 테이블",
    "TW_STOCKMONTH": "월재고정보",
    "TW_STOCKSERIAL": "재고 현황",
    "TW_STOCKSERIAL_MONTH": "월별 재고 현황",
    "TW_STOCK_DATE": "일별 재고 현황",
    "TW_STOCK_DATE_CAL1": "일별 재고 현황 계산",
    "TW_WORKORD": "작업지시마스터정보",
    "COPY_T": "복사 임시 테이블",
    "PBCATCOL": "PowerBuilder 카탈로그(컬럼)",
    "PBCATEDT": "PowerBuilder 카탈로그(편집)",
    "PBCATFMT": "PowerBuilder 카탈로그(포맷)",
    "PBCATTBL": "PowerBuilder 카탈로그(테이블)",
    "PBCATVLD": "PowerBuilder 카탈로그(검증)",
    "TOAD_PLAN_TABLE": "TOAD 실행계획 테이블",
    "T_CUSTOMPLAN": "사용자 정의 계획",
    "T_NORMALDISTRIBUTION": "정규분포 데이터",
    "T_PACKING": "포장 정보",
    "T_SEQ_MAPPING": "시퀀스 매핑",
    "T_TIMETABLE": "시간표",
}

# 테이블 분류
TABLE_CATEGORIES = OrderedDict([
    ("시스템/공통", {
        "desc": "시스템 설정, 공통코드, 사용자 관리",
        "prefix": ["TM_CLIENT", "TM_COMPANY", "TM_PLANT", "TM_SYSTEM",
                    "TM_USER", "TM_USERROLE", "TM_SYSUSERROLE", "TM_EHR",
                    "TM_DEPARTMENT", "TM_POSITION", "TM_MENU", "TM_MENUROLE",
                    "TM_FORMS", "TM_NOTICE", "TM_FAVORITE", "TM_COMMCODE",
                    "TM_COMMGRP", "TM_GLOSSARY", "TM_TRANSACTION",
                    "TH_USESYSTEM", "TH_USESYSTEMLOG", "TH_VERSIONHISTORY",
                    "TL_LOGINFO"]
    }),
    ("기준정보", {
        "desc": "품목, BOM, 공정, 설비, 불량코드 등 기준 마스터",
        "prefix": ["TM_ITEMS", "TM_ITEMS_BAK", "TM_SERIAL", "TM_BOX",
                    "TM_BOM", "TM_BOMGRP", "TM_BOM_FIND", "TM_BOM_FIND2",
                    "TM_BOM_RELEASE", "TM_BOM_TEMP", "TM_BOM_TEMP2", "TM_MODELBOM",
                    "TM_SUBITEMS", "TM_SUBITEMS_DEREK",
                    "TM_OPERATION", "TM_ROUTING", "TM_ROUTINGGRP",
                    "TM_PRODLINE", "TM_PRODLINE_UNIT",
                    "TM_UNITCODE", "TM_VENDOR",
                    "TM_DEFECT", "TM_REASON", "TM_DOWNTIME",
                    "TM_EQP", "TM_CRIMPINSP",
                    "TM_WAREHOUSE", "TM_LOCATION",
                    "TM_CALENDER", "TM_WORKTIME", "TM_CLOSINGBASE",
                    "TM_GP12_ITEM"]
    }),
    ("생산관리", {
        "desc": "작업지시, 생산실적, 자재장착, 압착검사",
        "prefix": ["TW_WORKORD", "TH_WORKORD",
                    "TW_PRODHIST", "TW_PRODHIST_USE",
                    "TW_MOUNT", "TW_CRIMPPING",
                    "TH_CRIMPING", "TH_CRIMPINSP", "TH_CRIMPINSP_20211014",
                    "TH_CRIMP_IMAGE",
                    "TW_DAILYWORKPLAN"]
    }),
    ("자재/재고관리", {
        "desc": "입출고, 재고현황, IQC, 자재요청",
        "prefix": ["TW_IN", "TW_OUT", "TW_OQC",
                    "TW_STOCKSERIAL", "TW_STOCKSERIAL_MONTH",
                    "TW_STOCKMONTH", "TW_STOCK_DATE", "TW_STOCK_DATE_CAL1",
                    "TH_STOCKSERIAL", "TIF_STOCK",
                    "TW_IQC", "TW_MATERIALREQUSET", "TW_RESPONSENO",
                    "TW_ACTUALSTOCK", "TMP_ACTUALMATERIAL", "TW_COMPARESTOCK",
                    "TH_SPLITMERGE", "TH_BOX", "TH_OQC_REPORT",
                    "TM_MAT_BALANCE_TEMP"]
    }),
    ("생산계획", {
        "desc": "생산계획, 고객계획, 월별계획",
        "prefix": ["TM_PRODPLAN", "TM_PRODPLAN_TEMP",
                    "TM_PRODPLAN_MONTH", "TM_PRODPLAN_MONTH_BALANCE",
                    "TM_PRODPLAN_MONTH_BEGIN", "TM_PRODPLAN_MONTH_PLAN",
                    "TM_PRODPLAN_MONTH_PRODRESULT", "TM_PRODPLAN_MONTH_RESULT",
                    "TM_PRODPLAN_MONTH_WIP",
                    "TM_CUSTPLAN", "TM_CUSTPLAN_MONTH", "TM_CUSTPLAN_ORDER",
                    "TM_CUSTPLAN_TEMP", "TM_CUSTPLAN_TEMP_TEMP",
                    "T_CUSTOMPLAN"]
    }),
    ("영업/주문", {
        "desc": "주문, 인보이스, 불량관리",
        "prefix": ["TM_ORDERMASTER", "TM_ORDERDETAIL",
                    "TM_INVOICEMASTER", "TM_INVOICEDETAIL",
                    "TW_BRD"]
    }),
    ("인터페이스/기타", {
        "desc": "ERP 인터페이스, PowerBuilder 카탈로그, 기타",
        "prefix": ["IMHIST_ETC_MIF", "SHPACT_MIF", "TH_MODBUS_IF",
                    "COPY_T", "PBCATCOL", "PBCATEDT", "PBCATFMT",
                    "PBCATTBL", "PBCATVLD", "TOAD_PLAN_TABLE",
                    "T_NORMALDISTRIBUTION", "T_PACKING", "T_SEQ_MAPPING",
                    "T_TIMETABLE",
                    "TM_CONVEYOR_REPORT_02",
                    "TM_LQC_REPORT_01", "TM_LQC_REPORT_02",
                    "TM_LQC_REPORT_02_01", "TM_LQC_REPORT_03"]
    }),
])

# 테이블 행수 (직접 매핑)
TABLE_ROWS = {}


def load_json(filepath):
    """JSON 파일 로드"""
    with open(filepath, 'r', encoding='utf-8') as f:
        data = json.load(f)
    return data.get('data', [])


def format_datatype(col):
    """데이터타입 포맷팅"""
    dtype = col['DATA_TYPE']
    length = col['DATA_LENGTH']
    precision = col.get('DATA_PRECISION')
    scale = col.get('DATA_SCALE')

    if dtype == 'NUMBER':
        if precision and scale and scale > 0:
            return f"NUMBER({precision},{scale})"
        elif precision:
            return f"NUMBER({precision})"
        else:
            return "NUMBER"
    elif dtype in ('VARCHAR2', 'CHAR', 'NVARCHAR2'):
        return f"{dtype}({length})"
    elif dtype == 'DATE':
        return "DATE"
    elif dtype == 'BLOB':
        return "BLOB"
    elif dtype == 'CLOB':
        return "CLOB"
    else:
        return dtype


def generate_overview(columns_data, constraints_data, indexes_data, table_rows):
    """데이터베이스 개요 문서 생성"""
    # 테이블별 컬럼 그룹핑
    tables = defaultdict(list)
    for col in columns_data:
        tables[col['TABLE_NAME']].append(col)

    # PK 정보 수집
    pk_info = defaultdict(list)
    for c in constraints_data:
        if c.get('CONSTRAINT_TYPE') == 'P' and not c['TABLE_NAME'].startswith('BIN$'):
            pk_info[c['TABLE_NAME']].append(c['COLUMN_NAME'])

    # 인덱스 정보 수집
    idx_info = defaultdict(lambda: defaultdict(list))
    for i in indexes_data:
        idx_info[i['TABLE_NAME']][i['INDEX_NAME']].append(
            (i['COLUMN_POSITION'], i['COLUMN_NAME'], i['UNIQUENESS'])
        )

    lines = []
    lines.append("# 데이터베이스 개요")
    lines.append("")
    lines.append("!!! info \"자동 생성 문서\"")
    lines.append("    이 문서는 HANES Oracle DB(MESUSER@CDBHNSMES)에서 자동 추출하여 생성되었습니다.")
    lines.append("    최종 추출일: 2026-02-15")
    lines.append("")
    lines.append(f"## 통계 요약")
    lines.append("")
    lines.append(f"| 항목 | 수량 |")
    lines.append(f"|------|------|")
    lines.append(f"| 전체 테이블 | **{len(tables)}개** |")
    lines.append(f"| 마스터 테이블 (TM_) | **{sum(1 for t in tables if t.startswith('TM_'))}개** |")
    lines.append(f"| 트랜잭션 테이블 (TW_) | **{sum(1 for t in tables if t.startswith('TW_'))}개** |")
    lines.append(f"| 이력 테이블 (TH_) | **{sum(1 for t in tables if t.startswith('TH_'))}개** |")
    lines.append(f"| 기타 테이블 | **{sum(1 for t in tables if not t.startswith(('TM_','TW_','TH_')))}개** |")
    lines.append("")

    # 네이밍 컨벤션
    lines.append("## 네이밍 컨벤션")
    lines.append("")
    lines.append("| 접두어 | 의미 | 설명 |")
    lines.append("|--------|------|------|")
    lines.append("| `TM_` | Table Master | 기준정보 마스터 테이블 |")
    lines.append("| `TW_` | Table Work | 트랜잭션(작업) 테이블 |")
    lines.append("| `TH_` | Table History | 이력/아카이브 테이블 |")
    lines.append("| `TIF_` | Table Interface | 외부 인터페이스 테이블 |")
    lines.append("| `TL_` | Table Log | 로그 테이블 |")
    lines.append("| `TMP_` | Temporary | 임시 테이블 |")
    lines.append("| `T_` | Table | 기타 테이블 |")
    lines.append("")

    # 공통 컬럼 패턴
    lines.append("## 공통 컬럼 패턴")
    lines.append("")
    lines.append("대부분의 테이블에 아래 공통 컬럼이 포함됩니다:")
    lines.append("")
    lines.append("| 컬럼명 | 타입 | 설명 |")
    lines.append("|--------|------|------|")
    lines.append("| `CLIENT` | VARCHAR2(5) | 법인코드 (PK) |")
    lines.append("| `COMPANY` | VARCHAR2(5) | 회사코드 (PK) |")
    lines.append("| `PLANT` | VARCHAR2(10) | 공장코드 (PK) |")
    lines.append("| `USEFLAG` | VARCHAR2(1) | 사용여부 (기본값 'Y') |")
    lines.append("| `REMARKS` | VARCHAR2(4000) | 비고 |")
    lines.append("| `CREATETIMEKEY` | VARCHAR2(20) | 등록일시 (YYYYMMDDHH24MISSFF) |")
    lines.append("| `CREATEUSER` | VARCHAR2(10) | 등록자 |")
    lines.append("| `UPDATETIMEKEY` | VARCHAR2(20) | 수정일시 |")
    lines.append("| `UPDATEUSER` | VARCHAR2(10) | 수정자 |")
    lines.append("")

    # 카테고리별 테이블 목록
    lines.append("## 테이블 목록")
    lines.append("")

    categorized = set()
    for cat_name, cat_info in TABLE_CATEGORIES.items():
        cat_tables = [t for t in cat_info['prefix'] if t in tables]
        if not cat_tables:
            continue

        lines.append(f"### {cat_name}")
        lines.append(f"")
        lines.append(f"> {cat_info['desc']}")
        lines.append(f"")
        lines.append(f"| 테이블명 | 설명 | 컬럼수 | 행수 | PK |")
        lines.append(f"|----------|------|--------|------|-----|")
        for tname in cat_tables:
            comment = TABLE_COMMENTS.get(tname, "")
            col_count = len(tables[tname])
            rows = table_rows.get(tname, 0) or 0
            pk_cols = pk_info.get(tname, [])
            pk_str = ", ".join(pk_cols) if pk_cols else "-"
            rows_str = f"{rows:,}" if rows else "0"
            lines.append(f"| `{tname}` | {comment} | {col_count} | {rows_str} | {pk_str} |")
            categorized.add(tname)
        lines.append("")

    # 미분류 테이블
    uncategorized = [t for t in sorted(tables.keys()) if t not in categorized]
    if uncategorized:
        lines.append("### 기타 미분류")
        lines.append("")
        lines.append("| 테이블명 | 설명 | 컬럼수 |")
        lines.append("|----------|------|--------|")
        for tname in uncategorized:
            comment = TABLE_COMMENTS.get(tname, "")
            col_count = len(tables[tname])
            lines.append(f"| `{tname}` | {comment} | {col_count} |")
        lines.append("")

    # === 각 테이블 상세 ===
    lines.append("---")
    lines.append("")
    lines.append("## 테이블 상세 정의")
    lines.append("")

    for tname in sorted(tables.keys()):
        cols = sorted(tables[tname], key=lambda x: x.get('COLUMN_ID', 0) or 0)
        comment = TABLE_COMMENTS.get(tname, "")
        pk_cols = pk_info.get(tname, [])
        rows = table_rows.get(tname, 0) or 0

        lines.append(f"### {tname}")
        if comment:
            lines.append(f"**{comment}**")
        if rows:
            lines.append(f"  행수: {rows:,}")
        lines.append("")

        lines.append("| # | 컬럼명 | 타입 | NULL | PK | 기본값 |")
        lines.append("|---|--------|------|------|----|--------|")

        for i, col in enumerate(cols, 1):
            dtype = format_datatype(col)
            nullable = "N" if col['NULLABLE'] == 'N' else "Y"
            is_pk = "PK" if col['COLUMN_NAME'] in pk_cols else ""
            default = str(col.get('DATA_DEFAULT', '') or '').strip()
            if len(default) > 40:
                default = default[:37] + "..."
            lines.append(f"| {i} | `{col['COLUMN_NAME']}` | {dtype} | {nullable} | {is_pk} | {default} |")

        # 인덱스 정보
        if tname in idx_info:
            lines.append("")
            lines.append("**인덱스:**")
            lines.append("")
            for idx_name, idx_cols in idx_info[tname].items():
                if idx_name.startswith('BIN$'):
                    continue
                sorted_cols = sorted(idx_cols, key=lambda x: x[0])
                col_names = ", ".join(c[1] for c in sorted_cols)
                uniqueness = sorted_cols[0][2]
                uq_str = "UNIQUE" if uniqueness == "UNIQUE" else ""
                lines.append(f"- `{idx_name}` {uq_str} ({col_names})")

        lines.append("")
        lines.append("---")
        lines.append("")

    return "\n".join(lines)


def generate_procedures(pkg_source_data, funproc_data):
    """프로시저/패키지 명세서 생성"""
    # 패키지 소스를 이름+타입별로 재구성
    pkg_sources = defaultdict(lambda: defaultdict(list))
    for row in pkg_source_data:
        name = row['NAME']
        typ = row['TYPE']
        pkg_sources[name][typ].append((row['LINE'], row['TEXT']))

    # 함수/프로시저 소스 재구성
    funproc_sources = defaultdict(lambda: defaultdict(list))
    for row in funproc_data:
        name = row['NAME']
        typ = row['TYPE']
        funproc_sources[name][typ].append((row['LINE'], row['TEXT']))

    lines = []
    lines.append("# 프로시저/패키지 상세 명세서")
    lines.append("")
    lines.append("!!! info \"자동 생성 문서\"")
    lines.append("    이 문서는 HANES Oracle DB(MESUSER@CDBHNSMES)에서 자동 추출하여 생성되었습니다.")
    lines.append("    최종 추출일: 2026-02-15")
    lines.append("")

    # 통계
    pkg_names = sorted(set(n for n in pkg_sources.keys()))
    fun_names = sorted(set(n for n in funproc_sources.keys()
                           if 'FUNCTION' in funproc_sources[n]))
    proc_names = sorted(set(n for n in funproc_sources.keys()
                            if 'PROCEDURE' in funproc_sources[n]))

    lines.append("## 통계 요약")
    lines.append("")
    lines.append("| 항목 | 수량 |")
    lines.append("|------|------|")
    lines.append(f"| 패키지 | **{len(pkg_names)}개** |")
    lines.append(f"| 독립 함수 | **{len(fun_names)}개** |")
    lines.append(f"| 독립 프로시저 | **{len(proc_names)}개** |")
    lines.append("")

    # 패키지 분류
    lines.append("## 패키지 분류")
    lines.append("")
    lines.append("| 접두어 | 의미 | 패키지 목록 |")
    lines.append("|--------|------|-------------|")

    pkg_categories = {
        "PKGBAS_": "기준정보",
        "PKGPRD_": "생산관리",
        "PKGMAT_": "자재관리",
        "PKGSYS_": "시스템관리",
        "PKGPDA_": "PDA(모바일)",
        "PKGTXN_": "트랜잭션",
        "PKGIF_": "인터페이스",
        "PKGHNS_": "리포트",
        "PKGDEV_": "개발용",
        "GPKG": "글로벌",
        "PCK_": "기타",
    }
    for prefix, desc in pkg_categories.items():
        pkgs = [p for p in pkg_names if p.startswith(prefix)]
        if pkgs:
            lines.append(f"| `{prefix}` | {desc} | {', '.join(f'`{p}`' for p in pkgs)} |")
    lines.append("")

    # === 패키지 상세 ===
    lines.append("---")
    lines.append("")
    lines.append("## 패키지 상세")
    lines.append("")

    for pkg_name in pkg_names:
        lines.append(f"### {pkg_name}")
        lines.append("")

        # PACKAGE (spec) 소스에서 프로시저/함수 시그니처 추출
        if 'PACKAGE' in pkg_sources[pkg_name]:
            spec_lines = sorted(pkg_sources[pkg_name]['PACKAGE'], key=lambda x: x[0])
            spec_text = "".join(line[1] for line in spec_lines)

            # 프로시저/함수 시그니처 추출
            procedures = re.findall(
                r'PROCEDURE\s+(\w+)\s*\((.*?)\)\s*;',
                spec_text, re.DOTALL | re.IGNORECASE
            )
            functions = re.findall(
                r'FUNCTION\s+(\w+)\s*\((.*?)\)\s*RETURN\s+(\w+)',
                spec_text, re.DOTALL | re.IGNORECASE
            )

            if procedures or functions:
                lines.append("| 유형 | 이름 | 파라미터 |")
                lines.append("|------|------|----------|")

                for pname, params in procedures:
                    # 파라미터 정리
                    params_clean = re.sub(r'\s+', ' ', params.strip())
                    param_list = []
                    for p in params_clean.split(','):
                        p = p.strip()
                        if p:
                            param_list.append(p)
                    param_summary = ", ".join(param_list)
                    if len(param_summary) > 80:
                        param_summary = param_summary[:77] + "..."
                    lines.append(f"| PROC | `{pname}` | {param_summary} |")

                for fname, params, ret_type in functions:
                    params_clean = re.sub(r'\s+', ' ', params.strip())
                    param_list = []
                    for p in params_clean.split(','):
                        p = p.strip()
                        if p:
                            param_list.append(p)
                    param_summary = ", ".join(param_list)
                    if len(param_summary) > 60:
                        param_summary = param_summary[:57] + "..."
                    lines.append(f"| FUNC | `{fname}` | {param_summary} → {ret_type} |")

                lines.append("")

            # 전체 PACKAGE spec 소스코드
            lines.append("??? note \"패키지 스펙 소스코드\"")
            lines.append("    ```sql")
            for _, text in spec_lines:
                for t in text.rstrip('\n').split('\n'):
                    lines.append(f"    {t}")
            lines.append("    ```")
            lines.append("")

        # PACKAGE BODY 소스에서 프로시저별 상세 추출
        if 'PACKAGE BODY' in pkg_sources[pkg_name]:
            body_lines = sorted(pkg_sources[pkg_name]['PACKAGE BODY'], key=lambda x: x[0])
            body_text = "".join(line[1] for line in body_lines)

            # 각 프로시저/함수의 시작 위치 찾기
            proc_starts = [(m.start(), m.group(1), 'PROCEDURE')
                           for m in re.finditer(r'PROCEDURE\s+(\w+)', body_text, re.IGNORECASE)]
            func_starts = [(m.start(), m.group(1), 'FUNCTION')
                           for m in re.finditer(r'FUNCTION\s+(\w+)', body_text, re.IGNORECASE)]

            all_starts = sorted(proc_starts + func_starts, key=lambda x: x[0])

            if all_starts:
                # 각 프로시저/함수에서 사용하는 테이블 추출
                lines.append("**참조 테이블:**")
                lines.append("")

                # body 전체에서 테이블 참조 추출
                table_refs = set()
                for m in re.finditer(r'\b(TM_\w+|TW_\w+|TH_\w+|TIF_\w+|TMP_\w+)\b', body_text, re.IGNORECASE):
                    table_refs.add(m.group(1).upper())

                if table_refs:
                    lines.append(", ".join(f"`{t}`" for t in sorted(table_refs)))
                    lines.append("")

        lines.append("---")
        lines.append("")

    # === 독립 함수 ===
    lines.append("## 독립 함수")
    lines.append("")
    lines.append("| 함수명 | 파라미터 | 반환타입 |")
    lines.append("|--------|----------|----------|")

    for fname in fun_names:
        if 'FUNCTION' in funproc_sources[fname]:
            src_lines = sorted(funproc_sources[fname]['FUNCTION'], key=lambda x: x[0])
            src_text = "".join(line[1] for line in src_lines)

            # 파라미터/반환 추출
            match = re.search(r'FUNCTION\s+\w+\s*\((.*?)\)\s*RETURN\s+(\w+)',
                             src_text, re.DOTALL | re.IGNORECASE)
            if match:
                params = re.sub(r'\s+', ' ', match.group(1).strip())
                ret = match.group(2)
                if len(params) > 60:
                    params = params[:57] + "..."
                lines.append(f"| `{fname}` | {params} | {ret} |")
            else:
                lines.append(f"| `{fname}` | - | - |")

    lines.append("")

    # 각 함수 상세
    for fname in fun_names:
        if 'FUNCTION' in funproc_sources[fname]:
            src_lines = sorted(funproc_sources[fname]['FUNCTION'], key=lambda x: x[0])
            lines.append(f"### {fname}")
            lines.append("")
            lines.append("??? note \"소스코드\"")
            lines.append("    ```sql")
            for _, text in src_lines:
                for t in text.rstrip('\n').split('\n'):
                    lines.append(f"    {t}")
            lines.append("    ```")
            lines.append("")

    # === 독립 프로시저 ===
    if proc_names:
        lines.append("## 독립 프로시저")
        lines.append("")
        for pname in proc_names:
            if 'PROCEDURE' in funproc_sources[pname]:
                src_lines = sorted(funproc_sources[pname]['PROCEDURE'], key=lambda x: x[0])
                lines.append(f"### {pname}")
                lines.append("")
                lines.append("??? note \"소스코드\"")
                lines.append("    ```sql")
                for _, text in src_lines:
                    for t in text.rstrip('\n').split('\n'):
                        lines.append(f"    {t}")
                lines.append("    ```")
                lines.append("")

    return "\n".join(lines)


def generate_erd(columns_data, constraints_data, table_rows):
    """ERD 문서 생성"""
    tables = defaultdict(list)
    for col in columns_data:
        tables[col['TABLE_NAME']].append(col)

    pk_info = defaultdict(list)
    for c in constraints_data:
        if c.get('CONSTRAINT_TYPE') == 'P' and not c['TABLE_NAME'].startswith('BIN$'):
            pk_info[c['TABLE_NAME']].append(c['COLUMN_NAME'])

    lines = []
    lines.append("# ERD (Entity Relationship Diagram)")
    lines.append("")
    lines.append("!!! info \"자동 생성 문서\"")
    lines.append("    이 문서는 HANES Oracle DB(MESUSER@CDBHNSMES)에서 자동 추출하여 생성되었습니다.")
    lines.append("    FK 제약은 DB에 미설정 - 컬럼명 기반 논리적 관계를 표시합니다.")
    lines.append("    최종 추출일: 2026-02-15")
    lines.append("")

    # 논리적 관계 추론 (컬럼명 기반)
    # 공통 조인 키: CLIENT, COMPANY, PLANT, ITEMCODE, SERIAL, WHLOC, BOXNO, etc.
    lines.append("## 1. 전체 구조 개요")
    lines.append("")
    lines.append("```mermaid")
    lines.append("erDiagram")
    lines.append("    TM_CLIENT ||--o{ TM_COMPANY : \"법인-회사\"")
    lines.append("    TM_COMPANY ||--o{ TM_PLANT : \"회사-공장\"")
    lines.append("    TM_PLANT ||--o{ TM_WAREHOUSE : \"공장-창고\"")
    lines.append("    TM_WAREHOUSE ||--o{ TM_LOCATION : \"창고-위치\"")
    lines.append("    TM_PLANT ||--o{ TM_PRODLINE : \"공장-생산라인\"")
    lines.append("    TM_PRODLINE ||--o{ TM_PRODLINE_UNIT : \"라인-설비호기\"")
    lines.append("    TM_PLANT ||--o{ TM_USER : \"공장-사용자\"")
    lines.append("    TM_USER ||--o{ TM_SYSUSERROLE : \"사용자-권한\"")
    lines.append("    TM_USERROLE ||--o{ TM_MENUROLE : \"권한-메뉴접근\"")
    lines.append("    TM_MENU ||--o{ TM_MENUROLE : \"메뉴-메뉴접근\"")
    lines.append("    TM_DEPARTMENT ||--o{ TM_EHR : \"부서-인사\"")
    lines.append("    TM_ITEMS ||--o{ TM_BOM : \"품목-BOM\"")
    lines.append("    TM_BOMGRP ||--o{ TM_BOM : \"BOM그룹-BOM\"")
    lines.append("    TM_ITEMS ||--o{ TM_SERIAL : \"품목-시리얼\"")
    lines.append("    TM_ITEMS ||--o{ TM_BOX : \"품목-BOX\"")
    lines.append("    TM_SERIAL ||--o{ TW_IN : \"시리얼-입고\"")
    lines.append("    TM_SERIAL ||--o{ TW_OUT : \"시리얼-출고\"")
    lines.append("    TM_ITEMS ||--o{ TW_STOCKSERIAL : \"품목-재고\"")
    lines.append("    TM_ITEMS ||--o{ TW_WORKORD : \"품목-작업지시\"")
    lines.append("    TW_WORKORD ||--o{ TW_PRODHIST : \"작업지시-생산실적\"")
    lines.append("    TW_PRODHIST ||--o{ TW_PRODHIST_USE : \"생산실적-자재사용\"")
    lines.append("    TW_WORKORD ||--o{ TW_MOUNT : \"작업지시-자재장착\"")
    lines.append("    TM_ITEMS ||--o{ TW_IQC : \"품목-IQC\"")
    lines.append("    TM_ITEMS ||--o{ TW_OQC : \"품목-OQC\"")
    lines.append("    TW_WORKORD ||--o{ TW_MATERIALREQUSET : \"작업지시-자재요청\"")
    lines.append("    TM_DEFECT ||--o{ TW_BRD : \"불량코드-BRD\"")
    lines.append("    TM_VENDOR ||--o{ TW_IN : \"거래처-입고\"")
    lines.append("    TM_OPERATION ||--o{ TW_PRODHIST : \"공정-생산실적\"")
    lines.append("    TM_ITEMS ||--o{ TM_CRIMPINSP : \"품목-압착검사기준\"")
    lines.append("    TM_CRIMPINSP ||--o{ TH_CRIMPINSP : \"압착기준-검사이력\"")
    lines.append("```")
    lines.append("")

    # 핵심 엔티티 상세
    lines.append("## 2. 핵심 엔티티 상세")
    lines.append("")

    core_tables = [
        "TM_CLIENT", "TM_COMPANY", "TM_PLANT", "TM_USER", "TM_ITEMS",
        "TM_SERIAL", "TM_BOM", "TM_WAREHOUSE", "TM_LOCATION",
        "TM_VENDOR", "TM_OPERATION", "TM_PRODLINE",
        "TW_IN", "TW_OUT", "TW_WORKORD", "TW_PRODHIST",
        "TW_STOCKSERIAL", "TW_MOUNT", "TW_IQC", "TW_OQC",
        "TW_BRD", "TW_MATERIALREQUSET"
    ]

    for tname in core_tables:
        if tname not in tables:
            continue
        cols = sorted(tables[tname], key=lambda x: x.get('COLUMN_ID', 0) or 0)
        pk_cols = pk_info.get(tname, [])
        comment = TABLE_COMMENTS.get(tname, "")
        rows = table_rows.get(tname, 0) or 0

        lines.append(f"### {tname} ({comment})")
        lines.append("")
        if rows:
            lines.append(f"행수: **{rows:,}**")
            lines.append("")
        lines.append("```")
        lines.append(f"┌{'─'*65}┐")
        lines.append(f"│{tname:^65}│")
        lines.append(f"├{'─'*65}┤")

        for col in cols:
            dtype = format_datatype(col)
            pk_mark = "PK" if col['COLUMN_NAME'] in pk_cols else "  "
            null_mark = "NN" if col['NULLABLE'] == 'N' else "  "
            col_line = f"│ {pk_mark} │ {col['COLUMN_NAME']:<25} │ {dtype:<15} │ {null_mark} │"
            # 패딩 조정
            padding = 65 - len(col_line) + 1
            if padding < 0:
                col_line = col_line[:65] + "│"
            else:
                col_line = col_line + " " * padding + "│"
            lines.append(col_line[:67])

        lines.append(f"└{'─'*65}┘")
        lines.append("```")
        lines.append("")

    # 데이터 흐름
    lines.append("## 3. 핵심 데이터 흐름")
    lines.append("")
    lines.append("```mermaid")
    lines.append("flowchart LR")
    lines.append("    subgraph 자재입고")
    lines.append("        A[TM_VENDOR<br/>거래처] --> B[TW_IN<br/>입고이력]")
    lines.append("        B --> C[TM_SERIAL<br/>시리얼생성]")
    lines.append("        B --> D[TW_IQC<br/>수입검사]")
    lines.append("    end")
    lines.append("    subgraph 재고관리")
    lines.append("        C --> E[TW_STOCKSERIAL<br/>재고현황]")
    lines.append("        E --> F[TW_MATERIALREQUSET<br/>자재요청]")
    lines.append("    end")
    lines.append("    subgraph 생산")
    lines.append("        F --> G[TW_WORKORD<br/>작업지시]")
    lines.append("        G --> H[TW_MOUNT<br/>자재장착]")
    lines.append("        G --> I[TW_PRODHIST<br/>생산실적]")
    lines.append("        I --> J[TW_PRODHIST_USE<br/>자재차감]")
    lines.append("    end")
    lines.append("    subgraph 출고")
    lines.append("        I --> K[TW_OQC<br/>출하검사]")
    lines.append("        K --> L[TW_OUT<br/>출고이력]")
    lines.append("    end")
    lines.append("    subgraph 품질")
    lines.append("        I --> M[TH_CRIMPINSP<br/>압착검사]")
    lines.append("        I --> N[TW_BRD<br/>불량/수리/폐기]")
    lines.append("    end")
    lines.append("```")
    lines.append("")

    # 조인 관계 정리
    lines.append("## 4. 주요 조인 키")
    lines.append("")
    lines.append("| 조인 키 | 관련 테이블 | 설명 |")
    lines.append("|---------|------------|------|")
    lines.append("| `CLIENT, COMPANY, PLANT` | 거의 모든 테이블 | 멀티테넌트 기본키 |")
    lines.append("| `ITEMCODE` (NUMBER) | TM_ITEMS, TM_SERIAL, TW_IN, TW_OUT, TW_STOCKSERIAL 등 | 품목 조인 |")
    lines.append("| `SERIAL` (VARCHAR2) | TM_SERIAL, TW_IN, TW_OUT, TW_STOCKSERIAL, TW_PRODHIST 등 | 시리얼 추적 |")
    lines.append("| `WHLOC` (VARCHAR2) | TM_LOCATION, TW_IN, TW_OUT, TW_STOCKSERIAL | 창고+위치 코드 |")
    lines.append("| `BOXNO` (VARCHAR2) | TM_BOX, TM_SERIAL, TW_IN, TW_OUT | 박스 추적 |")
    lines.append("| `WRKORD` (VARCHAR2) | TW_WORKORD, TW_PRODHIST, TW_MOUNT, TM_SERIAL | 작업지시번호 |")
    lines.append("| `OPER` (VARCHAR2) | TM_OPERATION, TW_PRODHIST, TW_IN | 공정코드 |")
    lines.append("| `VENDOR` (VARCHAR2) | TM_VENDOR, TW_IN, TM_SERIAL | 거래처코드 |")
    lines.append("| `USERID` (VARCHAR2) | TM_USER, CREATEUSER/UPDATEUSER | 사용자 참조 |")
    lines.append("| `PRODLINE` (VARCHAR2) | TM_PRODLINE, TW_WORKORD, TW_PRODHIST | 생산라인 |")
    lines.append("")

    # ITEMCODE가 NUMBER임을 강조
    lines.append("!!! warning \"ITEMCODE 타입 주의\"")
    lines.append("    `ITEMCODE`는 **NUMBER** 타입입니다 (VARCHAR2가 아님).")
    lines.append("    TM_ITEMS.ITEMCODE를 조인할 때 타입 변환에 주의하세요.")
    lines.append("")

    return "\n".join(lines)


def main():
    print("=== HNSMES DB 문서 생성 시작 ===")
    print()

    # 데이터 로드
    print("1. 컬럼 데이터 로드...")
    columns_data = load_json(COLUMNS_FILE)
    print(f"   → {len(columns_data)}개 컬럼 로드")

    print("2. 제약조건 데이터 로드...")
    constraints_data = load_json(CONSTRAINTS_FILE)
    print(f"   → {len(constraints_data)}개 제약조건 로드")

    print("3. 인덱스 데이터 로드...")
    indexes_data = load_json(INDEXES_FILE)
    print(f"   → {len(indexes_data)}개 인덱스 로드")

    print("4. 패키지 소스 로드...")
    pkg_source_data = load_json(PKG_SOURCE_FILE)
    print(f"   → {len(pkg_source_data)}줄 패키지 소스 로드")

    print("5. 함수/프로시저 소스 로드...")
    funproc_data = load_json(FUNPROC_FILE)
    print(f"   → {len(funproc_data)}줄 함수/프로시저 소스 로드")

    # 행수 데이터 (하드코딩 - 추출 시점 데이터)
    table_rows = {
        "COPY_T": 1000, "TH_BOX": 3, "TH_CRIMPING": 943,
        "TH_CRIMPINSP": 21724, "TH_CRIMPINSP_20211014": 1232,
        "TH_OQC_REPORT": 52, "TH_SPLITMERGE": 2242,
        "TH_STOCKSERIAL": 18127046, "TH_USESYSTEM": 53217,
        "TH_USESYSTEMLOG": 386581, "TH_WORKORD": 34053,
        "TM_BOM": 9206, "TM_BOMGRP": 118, "TM_BOM_FIND2": 287,
        "TM_BOM_RELEASE": 3841, "TM_BOX": 97094,
        "TM_CLIENT": 1, "TM_CLOSINGBASE": 1000,
        "TM_COMMCODE": 171, "TM_COMMGRP": 15, "TM_COMPANY": 1,
        "TM_CRIMPINSP": 39, "TM_DEFECT": 109, "TM_DEPARTMENT": 17,
        "TM_DOWNTIME": 5, "TM_EHR": 191, "TM_FORMS": 114,
        "TM_GLOSSARY": 2256, "TM_GP12_ITEM": 2,
        "TM_ITEMS": 1315, "TM_ITEMS_BAK": 12, "TM_LOCATION": 10,
        "TM_MENU": 134, "TM_MENUROLE": 468, "TM_OPERATION": 11,
        "TM_PLANT": 1, "TM_POSITION": 17, "TM_PRODLINE": 10,
        "TM_PRODLINE_UNIT": 38, "TM_PRODPLAN": 101,
        "TM_SERIAL": 1868570, "TM_SYSTEM": 1,
        "TM_SYSUSERROLE": 191, "TM_TRANSACTION": 63,
        "TM_UNITCODE": 5, "TM_USER": 88, "TM_USERROLE": 14,
        "TM_VENDOR": 5, "TM_WAREHOUSE": 6,
        "TMP_ACTUALMATERIAL": 3356,
        "TW_ACTUALSTOCK": 32167, "TW_BRD": 728,
        "TW_CRIMPPING": 34, "TW_IN": 1750960,
        "TW_IQC": 3639, "TW_MATERIALREQUSET": 12966,
        "TW_MOUNT": 154126, "TW_OQC": 59396,
        "TW_OUT": 9271825, "TW_PRODHIST": 6354665,
        "TW_PRODHIST_USE": 7628428, "TW_RESPONSENO": 17378,
        "TW_STOCKSERIAL": 128276, "TW_WORKORD": 34862,
        "T_SEQ_MAPPING": 31423, "PBCATEDT": 21, "PBCATFMT": 20,
    }

    # 문서 생성
    os.makedirs(DOCS_DIR, exist_ok=True)

    print()
    print("6. 데이터베이스 개요 문서 생성...")
    overview_md = generate_overview(columns_data, constraints_data, indexes_data, table_rows)
    with open(os.path.join(DOCS_DIR, "overview.md"), 'w', encoding='utf-8') as f:
        f.write(overview_md)
    print(f"   → docs/database/overview.md ({len(overview_md):,} bytes)")

    print("7. 프로시저 명세서 생성...")
    procedures_md = generate_procedures(pkg_source_data, funproc_data)
    with open(os.path.join(DOCS_DIR, "procedures-complete.md"), 'w', encoding='utf-8') as f:
        f.write(procedures_md)
    print(f"   → docs/database/procedures-complete.md ({len(procedures_md):,} bytes)")

    print("8. ERD 문서 생성...")
    erd_md = generate_erd(columns_data, constraints_data, table_rows)
    with open(os.path.join(DOCS_DIR, "erd-complete.md"), 'w', encoding='utf-8') as f:
        f.write(erd_md)
    print(f"   → docs/database/erd-complete.md ({len(erd_md):,} bytes)")

    print()
    print("=== 문서 생성 완료! ===")


if __name__ == '__main__':
    main()
