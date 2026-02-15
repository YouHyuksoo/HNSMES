# 데이터베이스 개요

!!! info "자동 생성 문서"
    이 문서는 HANES Oracle DB(MESUSER@CDBHNSMES)에서 자동 추출하여 생성되었습니다.
    최종 추출일: 2026-02-15

## 통계 요약

| 항목 | 수량 |
|------|------|
| 전체 테이블 | **128개** |
| 마스터 테이블 (TM_) | **75개** |
| 트랜잭션 테이블 (TW_) | **20개** |
| 이력 테이블 (TH_) | **13개** |
| 기타 테이블 | **20개** |

## 네이밍 컨벤션

| 접두어 | 의미 | 설명 |
|--------|------|------|
| `TM_` | Table Master | 기준정보 마스터 테이블 |
| `TW_` | Table Work | 트랜잭션(작업) 테이블 |
| `TH_` | Table History | 이력/아카이브 테이블 |
| `TIF_` | Table Interface | 외부 인터페이스 테이블 |
| `TL_` | Table Log | 로그 테이블 |
| `TMP_` | Temporary | 임시 테이블 |
| `T_` | Table | 기타 테이블 |

## 공통 컬럼 패턴

대부분의 테이블에 아래 공통 컬럼이 포함됩니다:

| 컬럼명 | 타입 | 설명 |
|--------|------|------|
| `CLIENT` | VARCHAR2(5) | 법인코드 (PK) |
| `COMPANY` | VARCHAR2(5) | 회사코드 (PK) |
| `PLANT` | VARCHAR2(10) | 공장코드 (PK) |
| `USEFLAG` | VARCHAR2(1) | 사용여부 (기본값 'Y') |
| `REMARKS` | VARCHAR2(4000) | 비고 |
| `CREATETIMEKEY` | VARCHAR2(20) | 등록일시 (YYYYMMDDHH24MISSFF) |
| `CREATEUSER` | VARCHAR2(10) | 등록자 |
| `UPDATETIMEKEY` | VARCHAR2(20) | 수정일시 |
| `UPDATEUSER` | VARCHAR2(10) | 수정자 |

## 테이블 목록

### 시스템/공통

> 시스템 설정, 공통코드, 사용자 관리

| 테이블명 | 설명 | 컬럼수 | 행수 | PK |
|----------|------|--------|------|-----|
| `TM_CLIENT` | 법인마스터 | 11 | 1 | CLIENT |
| `TM_COMPANY` | 부속회사마스터 | 12 | 1 | CLIENT, COMPANY |
| `TM_PLANT` | 공장마스터 | 14 | 1 | CLIENT, COMPANY, PLANT |
| `TM_SYSTEM` | 시스템마스터 | 14 | 1 | - |
| `TM_USER` | 사용자마스터 | 17 | 88 | CLIENT, COMPANY, PLANT, USERID |
| `TM_USERROLE` | 사용자권한마스터 | 17 | 14 | - |
| `TM_SYSUSERROLE` | 시스템사용자권한마스터 | 15 | 191 | - |
| `TM_EHR` | 인사마스터 | 21 | 191 | CLIENT, COMPANY, PLANT, EHRCODE |
| `TM_DEPARTMENT` | 부서마스터 | 14 | 17 | CLIENT, COMPANY, PLANT, DEPARTMENT |
| `TM_POSITION` | 직위마스터 | 14 | 17 | CLIENT, COMPANY, PLANT, POSITION |
| `TM_MENU` | 메뉴마스터 | 23 | 134 | - |
| `TM_MENUROLE` | 사용자권한별메뉴마스터 | 16 | 468 | - |
| `TM_FORMS` | 화면마스터 | 18 | 114 | CLIENT, COMPANY, PLANT, SYSCODE, FORM |
| `TM_NOTICE` | 공지마스터 | 17 | 0 | - |
| `TM_FAVORITE` | 사용자즐겨찾기 | 16 | 0 | - |
| `TM_COMMCODE` | 공통코드 마스터 | 17 | 171 | CLIENT, COMPANY, PLANT, COMMGRP, COMMCODE |
| `TM_COMMGRP` | 공통코드 그룹 | 16 | 15 | CLIENT, COMPANY, PLANT, SYSCODE, COMMGRP |
| `TM_GLOSSARY` | 용어마스터 | 11 | 2,256 | SYSCODE, GLSR |
| `TM_TRANSACTION` | 트랜잭션마스터 | 22 | 63 | CLIENT, COMPANY, PLANT, TXNCODE |
| `TH_USESYSTEM` | 시스템 사용이력 | 8 | 53,217 | - |
| `TH_USESYSTEMLOG` | 시스템 로그메시지 사용이력 | 10 | 386,581 | - |
| `TH_VERSIONHISTORY` | 버전 이력 | 19 | 0 | - |
| `TL_LOGINFO` | 로그 정보 | 10 | 0 | - |

### 기준정보

> 품목, BOM, 공정, 설비, 불량코드 등 기준 마스터

| 테이블명 | 설명 | 컬럼수 | 행수 | PK |
|----------|------|--------|------|-----|
| `TM_ITEMS` | 품목마스터 | 44 | 1,315 | CLIENT, COMPANY, PLANT, ITEMCODE |
| `TM_ITEMS_BAK` | 품목마스터 백업 | 41 | 12 | - |
| `TM_SERIAL` | 시리얼마스터 | 32 | 1,868,570 | CLIENT, COMPANY, PLANT, SERIAL |
| `TM_BOX` | BOX 정보 마스터 | 24 | 97,094 | CLIENT, COMPANY, PLANT, BOXNO |
| `TM_BOM` | BOM마스터 | 28 | 9,206 | CLIENT, COMPANY, PLANT, IDX, UPRIDX, BOMGRP, REV |
| `TM_BOMGRP` | BOM그룹마스터 | 18 | 118 | CLIENT, COMPANY, PLANT, BOMGRP, REV |
| `TM_BOM_FIND` | BOM 검색용 | 6 | 0 | - |
| `TM_BOM_FIND2` | BOM 검색용2 | 6 | 287 | - |
| `TM_BOM_RELEASE` | BOM 릴리스 | 7 | 3,841 | - |
| `TM_BOM_TEMP` | BOM 임시 | 9 | 0 | - |
| `TM_BOM_TEMP2` | BOM 임시2 | 4 | 0 | - |
| `TM_MODELBOM` | MODELBOM | 19 | 0 | CLIENT, COMPANY, PLANT, MODEL, SEQ, PARTNO, VENDOR |
| `TM_SUBITEMS` | 대체자재마스터 | 15 | 0 | CLIENT, COMPANY, PLANT, SEQ, IDX, SUBITEMCODE |
| `TM_SUBITEMS_DEREK` | 대체자재(DEREK용) | 15 | 0 | - |
| `TM_OPERATION` | 공정마스터 | 17 | 11 | CLIENT, COMPANY, PLANT, OPER |
| `TM_ROUTING` | 라우팅마스터 | 27 | 0 | CLIENT, COMPANY, PLANT, ROUTEGRP, ROUTE |
| `TM_ROUTINGGRP` | 라우팅그룹마스터 | 11 | 0 | CLIENT, COMPANY, PLANT, ROUTEGRP |
| `TM_PRODLINE` | 생산라인마스터 | 17 | 10 | CLIENT, COMPANY, PLANT, PRODLINE |
| `TM_PRODLINE_UNIT` | 생산라인설비호기마스터 | 16 | 38 | CLIENT, COMPANY, PLANT, UNITNO |
| `TM_UNITCODE` | 단위마스터 | 15 | 5 | CLIENT, COMPANY, PLANT, UNITCODE |
| `TM_VENDOR` | 거래처마스터 | 24 | 5 | CLIENT, COMPANY, PLANT, VENDOR |
| `TM_DEFECT` | 불량마스터 | 16 | 109 | CLIENT, COMPANY, PLANT, DEFECT |
| `TM_REASON` | 사유코드 마스터 | 16 | 0 | CLIENT, COMPANY, PLANT, REASONCODE |
| `TM_DOWNTIME` | 비가동마스터 | 17 | 5 | - |
| `TM_EQP` | 설비 마스터 | 16 | 0 | CLIENT, COMPANY, PLANT, EQP |
| `TM_CRIMPINSP` | 압착검사마스터 | 28 | 39 | - |
| `TM_WAREHOUSE` | 창고마스터 | 16 | 6 | CLIENT, COMPANY, PLANT, WAREHOUSE |
| `TM_LOCATION` | 창고별위치마스터 | 29 | 10 | CLIENT, COMPANY, PLANT, WHLOC |
| `TM_CALENDER` | 기준달력(임의의 주를 계산하기 위한 사용자 달력) | 12 | 0 | CAL_DATE |
| `TM_WORKTIME` | 근무인원 | 35 | 0 | CLIENT, COMPANY, PLANT, WORKDATE, PRODLINE |
| `TM_CLOSINGBASE` | 마감월기준 | 10 | 1,000 | CLIENT, COMPANY, PLANT, CLOSINGMONTH |
| `TM_GP12_ITEM` | GP12 품목 | 8 | 2 | CLIENT, COMPANY, PLANT, ITEMCODE |

### 생산관리

> 작업지시, 생산실적, 자재장착, 압착검사

| 테이블명 | 설명 | 컬럼수 | 행수 | PK |
|----------|------|--------|------|-----|
| `TW_WORKORD` | 작업지시마스터정보 | 30 | 34,862 | CLIENT, COMPANY, PLANT, WRKDATE, WRKORD, WRKORDSEQ, WRKORDTYPE, WRKORDSTATE, BOMGRP, ITEMCODE, ORDQTY |
| `TH_WORKORD` | 생산 작업 이력 | 19 | 34,053 | - |
| `TW_PRODHIST` | 생산실적정보 | 26 | 6,354,665 | CLIENT, COMPANY, PLANT, TXNTIMEKEY, PRODDATE, PRODTYPE, PRODPROGNO, ITEMCODE, TXNCODE, SERIAL |
| `TW_PRODHIST_USE` | 생산 차감(사용) 자재 정보 | 13 | 7,628,428 | CLIENT, COMPANY, PLANT, PRODPROGNO, OUTNO, UNITNO, SEQ, PRODSERIAL, USESERIAL, USEITEMCODE, SIDE |
| `TW_MOUNT` | 생산 자재 장착 정보 | 23 | 154,126 | CLIENT, COMPANY, PLANT, WRKORD, WRKORDSEQ, PRODPROGNO, SERIAL, ITEMCODE, UNITNO, SIDE, SEQ |
| `TW_CRIMPPING` | 압착 기준 정보 | 21 | 34 | CLIENT, COMPANY, PLANT, ITEMCODE |
| `TH_CRIMPING` | 압착 이력 | 17 | 943 | CLIENT, COMPANY, PLANT, TXNTIMEKEY, IFMODE |
| `TH_CRIMPINSP` | 압착검사 이력(결과)관리 | 36 | 21,724 | CLIENT, COMPANY, PLANT, TXNTIMEKEY, TXNDATE, UNITNO |
| `TH_CRIMPINSP_20211014` | 압착검사 이력 백업(2021-10-14) | 36 | 1,232 | - |
| `TH_CRIMP_IMAGE` | 압착검사 이미지 관리 | 13 | 0 | CLIENT, COMPANY, PLANT, TXNTIMEKEY, WIRE, TERMINAL |
| `TW_DAILYWORKPLAN` | 일별 생산 계획(통전기준) | 18 | 0 | CLIENT, COMPANY, PLANT, PLANDATE, WRKORD, OPER, ITEMCODE |

### 자재/재고관리

> 입출고, 재고현황, IQC, 자재요청

| 테이블명 | 설명 | 컬럼수 | 행수 | PK |
|----------|------|--------|------|-----|
| `TW_IN` | 입고 이력 | 38 | 1,750,960 | CLIENT, COMPANY, PLANT, INDATE, SERIAL, ITEMCODE, STOCKTYPE, INQTY, TXNTIMEKEY, TXNCODE, WHLOC |
| `TW_OUT` | 출고 이력 | 38 | 9,271,825 | CLIENT, COMPANY, PLANT, OUTDATE, SERIAL, ITEMCODE, STOCKTYPE, OUTQTY, TXNTIMEKEY, TXNCODE, WHLOC |
| `TW_OQC` | 출고 이력(OQC) | 25 | 59,396 | - |
| `TW_STOCKSERIAL` | 재고 현황 | 22 | 128,276 | CLIENT, COMPANY, PLANT, SERIAL, ITEMCODE, WHLOC |
| `TW_STOCKSERIAL_MONTH` | 월별 재고 현황 | 22 | 0 | STOCKMONTH, SERIAL, ITEMCODE, WHLOC, CNTNO, SIDE, LOT, PCBLOT |
| `TW_STOCKMONTH` | 월재고정보 | 8 | 0 | - |
| `TW_STOCK_DATE` | 일별 재고 현황 | 11 | 0 | - |
| `TW_STOCK_DATE_CAL1` | 일별 재고 현황 계산 | 11 | 0 | CLIENT, COMPANY, PLANT, STOCKDATE, UPRITEM, ITEMCODE |
| `TH_STOCKSERIAL` | 재고 시리얼 이력(아카이브) | 16 | 18,127,046 | - |
| `TIF_STOCK` | 재고 현황(인터페이스) | 7 | 0 | CLIENT, COMPANY, PLANT, ITEMCODE, WHLOC |
| `TW_IQC` | IQC정보 | 23 | 3,639 | CLIENT, COMPANY, PLANT, IQCNO |
| `TW_MATERIALREQUSET` | 자재 요청 정보 | 18 | 12,966 | CLIENT, COMPANY, PLANT, REQUESTDATE, REQUESTMATNO, SEQ |
| `TW_RESPONSENO` | 불출지시 테이블 | 13 | 17,378 | CLIENT, COMPANY, PLANT, RESPONSENO, REQUESTMATNO, SEQ, ITEMCODE |
| `TW_ACTUALSTOCK` | 재고 실사 정보 | 21 | 32,167 | - |
| `TMP_ACTUALMATERIAL` | 재고 실사 정보(자재소요계산임시테이블) | 18 | 3,356 | - |
| `TW_COMPARESTOCK` | 재고 비교 | 3 | 0 | - |
| `TH_SPLITMERGE` | SPLIT/MERGE 이력 | 13 | 2,242 | - |
| `TH_BOX` | 반제품 BOX 포장 상세 이력 | 15 | 3 | CLIENT, COMPANY, PLANT, BOXNO, SERIAL |
| `TH_OQC_REPORT` | OQC 리포트 | 11 | 52 | CLIENT, COMPANY, PLANT, OQCREPORTNO |
| `TM_MAT_BALANCE_TEMP` | 자재 잔량 임시 | 134 | 0 | CLIENT, COMPANY, PLANT, PLANDATE, UPRITEM, ITEMCODE |

### 생산계획

> 생산계획, 고객계획, 월별계획

| 테이블명 | 설명 | 컬럼수 | 행수 | PK |
|----------|------|--------|------|-----|
| `TM_PRODPLAN` | 생산 계획 | 103 | 101 | CLIENT, COMPANY, PLANT, PLANDATE, SEQ, ITEMCODE |
| `TM_PRODPLAN_TEMP` | 생산 계획 임시 | 110 | 0 | CLIENT, COMPANY, PLANT, PLANDATE, ITEMCODE |
| `TM_PRODPLAN_MONTH` | 월별 생산 계획 | 73 | 0 | CLIENT, COMPANY, PLANT, PLANDATE, SEQ, ITEMCODE |
| `TM_PRODPLAN_MONTH_BALANCE` | 월별 생산 계획 잔량 | 73 | 0 | CLIENT, COMPANY, PLANT, PLANDATE, SEQ, UPRITEM, ITEMCODE |
| `TM_PRODPLAN_MONTH_BEGIN` | 월별 생산 계획 기초 | 11 | 0 | CLIENT, COMPANY, PLANT, STOCKDATE, UPRITEM, ITEMCODE |
| `TM_PRODPLAN_MONTH_PLAN` | 월별 생산 계획 상세 | 73 | 0 | CLIENT, COMPANY, PLANT, PLANDATE, SEQ, UPRITEM, ITEMCODE |
| `TM_PRODPLAN_MONTH_PRODRESULT` | 월별 생산 실적 | 73 | 0 | - |
| `TM_PRODPLAN_MONTH_RESULT` | 월별 생산 결과 | 73 | 0 | CLIENT, COMPANY, PLANT, PLANDATE, SEQ, UPRITEM, ITEMCODE |
| `TM_PRODPLAN_MONTH_WIP` | 월별 생산 재공 | 73 | 0 | CLIENT, COMPANY, PLANT, PLANDATE, SEQ, UPRITEM, ITEMCODE |
| `TM_CUSTPLAN` | 고객 계획 | 201 | 0 | CLIENT, COMPANY, PLANT, VENDOR, PLANDATE, SEQ, ITEMCODE |
| `TM_CUSTPLAN_MONTH` | 고객 월별 계획 | 120 | 0 | CLIENT, COMPANY, PLANT, VENDOR, PLANMONTH, SEQ, ITEMCODE, PRODLINE, WO, MODEL, MODELSUFFIX |
| `TM_CUSTPLAN_ORDER` | 고객 주문 계획 | 44 | 0 | CLIENT, COMPANY, PLANT, PLANDATE, SEQ, WORKORDER, MODELSUFFIX, ITEMCODE |
| `TM_CUSTPLAN_TEMP` | 고객 계획 임시 | 200 | 0 | CLIENT, COMPANY, PLANT, PLANDATE, ITEMCODE |
| `TM_CUSTPLAN_TEMP_TEMP` | 고객 계획 임시2 | 200 | 0 | - |
| `T_CUSTOMPLAN` | 사용자 정의 계획 | 3 | 0 | - |

### 영업/주문

> 주문, 인보이스, 불량관리

| 테이블명 | 설명 | 컬럼수 | 행수 | PK |
|----------|------|--------|------|-----|
| `TM_ORDERMASTER` | 주문 마스터 | 23 | 0 | - |
| `TM_ORDERDETAIL` | 주문 상세 | 49 | 0 | - |
| `TM_INVOICEMASTER` | 인보이스 마스터 | 38 | 0 | - |
| `TM_INVOICEDETAIL` | 인보이스 상세 | 28 | 0 | - |
| `TW_BRD` | 불량/수리/폐기 이력 | 31 | 728 | CLIENT, COMPANY, PLANT, TXNTIMEKEY, BRDDATE, DEFECT, SERIAL |

### 인터페이스/기타

> ERP 인터페이스, PowerBuilder 카탈로그, 기타

| 테이블명 | 설명 | 컬럼수 | 행수 | PK |
|----------|------|--------|------|-----|
| `IMHIST_ETC_MIF` | 입출력이력-기타 | 42 | 0 | SNO |
| `SHPACT_MIF` | 작업실적 MES I/F 테이블 | 42 | 0 | SNO |
| `TH_MODBUS_IF` | Modbus 인터페이스 | 11 | 0 | - |
| `COPY_T` | 복사 임시 테이블 | 1 | 1,000 | - |
| `PBCATCOL` | PowerBuilder 카탈로그(컬럼) | 20 | 0 | - |
| `PBCATEDT` | PowerBuilder 카탈로그(편집) | 7 | 21 | - |
| `PBCATFMT` | PowerBuilder 카탈로그(포맷) | 4 | 20 | - |
| `PBCATTBL` | PowerBuilder 카탈로그(테이블) | 25 | 0 | - |
| `PBCATVLD` | PowerBuilder 카탈로그(검증) | 5 | 0 | - |
| `TOAD_PLAN_TABLE` | TOAD 실행계획 테이블 | 36 | 0 | - |
| `T_NORMALDISTRIBUTION` | 정규분포 데이터 | 1 | 0 | - |
| `T_PACKING` | 포장 정보 | 4 | 0 | - |
| `T_SEQ_MAPPING` | 시퀀스 매핑 | 3 | 31,423 | - |
| `T_TIMETABLE` | 시간표 | 3 | 0 | - |
| `TM_CONVEYOR_REPORT_02` | LQC리포트 | 11 | 0 | CLIENT, COMPANY, PLANT, SEQ, WORKDATE, REALDATE, DEFECT |
| `TM_LQC_REPORT_01` | LQC리포트01 | 9 | 0 | CLIENT, COMPANY, PLANT, WORKDATE, WORKTIME, UNITNO |
| `TM_LQC_REPORT_02` | LQC리포트02 | 11 | 0 | CLIENT, COMPANY, PLANT, SEQ, WORKDATE, WORKTIME, DEFECT |
| `TM_LQC_REPORT_02_01` | LQC리포트02_01 | 11 | 0 | CLIENT, COMPANY, PLANT, SEQ, WORKDATE, REALDATE, DEFECT |
| `TM_LQC_REPORT_03` | LQC리포트03 | 9 | 0 | CLIENT, COMPANY, PLANT, WORKDATE, WORKTIME |

### 기타 미분류

| 테이블명 | 설명 | 컬럼수 |
|----------|------|--------|
| `VM_ERP_ORDER` |  | 21 |
| `VW_CURRENT_STOCK` |  | 9 |
| `VW_WORKTIME` |  | 9 |

---

## 테이블 상세 정의

### COPY_T
**복사 임시 테이블**
  행수: 1,000

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `SEQ` | NUMBER | N |  |  |

---

### IMHIST_ETC_MIF
**입출력이력-기타**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `SNO` | VARCHAR2(15) | N | PK |  |
| 2 | `IOJPNO` | VARCHAR2(15) | Y |  |  |
| 3 | `IOGBN` | VARCHAR2(3) | Y |  |  |
| 4 | `SUDAT` | VARCHAR2(8) | Y |  |  |
| 5 | `ITNBR` | VARCHAR2(20) | Y |  |  |
| 6 | `DITNBR` | VARCHAR2(20) | Y |  |  |
| 7 | `DEPOT_NO` | VARCHAR2(13) | Y |  |  |
| 8 | `OPSEQ` | VARCHAR2(4) | Y |  |  |
| 9 | `CVCOD` | VARCHAR2(13) | Y |  |  |
| 10 | `IOREQTY` | NUMBER(14,3) | Y |  |  |
| 11 | `IOQTY` | NUMBER(14,3) | Y |  |  |
| 12 | `INSDAT` | VARCHAR2(8) | Y |  |  |
| 13 | `QCGUB` | VARCHAR2(1) | Y |  |  |
| 14 | `IO_CONFIRM` | VARCHAR2(1) | Y |  |  |
| 15 | `IO_DATE` | VARCHAR2(8) | Y |  |  |
| 16 | `IO_EMPNO` | VARCHAR2(30) | Y |  |  |
| 17 | `INPCNF` | VARCHAR2(1) | Y |  |  |
| 18 | `SAUPJ` | VARCHAR2(6) | Y |  |  |
| 19 | `FILSK` | VARCHAR2(1) | Y |  |  |
| 20 | `IP_JPNO` | VARCHAR2(15) | Y |  |  |
| 21 | `IOFAQTY` | NUMBER(14,3) | Y |  |  |
| 22 | `IOPEQTY` | NUMBER(14,3) | Y |  |  |
| 23 | `IOSUQTY` | NUMBER(14,3) | Y |  |  |
| 24 | `CRT_DATE` | VARCHAR2(8) | Y |  |  |
| 25 | `CRT_TIME` | VARCHAR2(6) | Y |  |  |
| 26 | `CRT_USER` | VARCHAR2(30) | Y |  |  |
| 27 | `ITGU` | VARCHAR2(1) | Y |  |  |
| 28 | `WKCTR` | VARCHAR2(6) | Y |  |  |
| 29 | `RETURN_GUBUN` | VARCHAR2(6) | Y |  |  |
| 30 | `SAGBN` | VARCHAR2(1) | Y |  |  |
| 31 | `WAIGBN` | VARCHAR2(1) | Y |  |  |
| 32 | `M_INS_DATE` | VARCHAR2(8) | Y |  |  |
| 33 | `M_INS_TIME` | VARCHAR2(6) | Y |  |  |
| 34 | `M_UPD_DATE` | VARCHAR2(8) | Y |  |  |
| 35 | `M_UPD_TIME` | VARCHAR2(6) | Y |  |  |
| 36 | `INS_TYPE` | VARCHAR2(1) | Y |  |  |
| 37 | `UPD_YN` | VARCHAR2(1) | Y |  |  |
| 38 | `MOVE_GBN` | VARCHAR2(1) | Y |  |  |
| 39 | `WORKORDER` | VARCHAR2(50) | Y |  |  |
| 40 | `REMARK` | VARCHAR2(100) | Y |  |  |
| 41 | `MODELCODE` | VARCHAR2(30) | Y |  |  |
| 42 | `TRANSNO` | VARCHAR2(20) | Y |  |  |

**인덱스:**

- `IDX_IMHIST_ETC_MIF_001`  (IOJPNO)
- `IDX_IMHIST_ETC_MIF_002`  (INSDAT, IOGBN)
- `IDX_IMHIST_ETC_MIF_003`  (INSDAT, CVCOD)
- `IDX_IMHIST_ETC_MIF_004`  (CVCOD, IOJPNO)
- `IDX_IMHIST_ETC_MIF_005`  (CVCOD, ITNBR)
- `IDX_IMHIST_ETC_MIF_006`  (IO_DATE)
- `PK_IMHIST_ETC_MIF` UNIQUE (SNO)

---

### PBCATCOL
**PowerBuilder 카탈로그(컬럼)**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `PBC_TNAM` | VARCHAR2(60) | N |  |  |
| 2 | `PBC_TID` | NUMBER | Y |  |  |
| 3 | `PBC_OWNR` | VARCHAR2(60) | N |  |  |
| 4 | `PBC_CNAM` | VARCHAR2(60) | N |  |  |
| 5 | `PBC_CID` | NUMBER | Y |  |  |
| 6 | `PBC_LABL` | VARCHAR2(254) | Y |  |  |
| 7 | `PBC_LPOS` | NUMBER | Y |  |  |
| 8 | `PBC_HDR` | VARCHAR2(254) | Y |  |  |
| 9 | `PBC_HPOS` | NUMBER | Y |  |  |
| 10 | `PBC_JTFY` | NUMBER | Y |  |  |
| 11 | `PBC_MASK` | VARCHAR2(61) | Y |  |  |
| 12 | `PBC_CASE` | NUMBER | Y |  |  |
| 13 | `PBC_HGHT` | NUMBER | Y |  |  |
| 14 | `PBC_WDTH` | NUMBER | Y |  |  |
| 15 | `PBC_PTRN` | VARCHAR2(61) | Y |  |  |
| 16 | `PBC_BMAP` | CHAR(1) | Y |  |  |
| 17 | `PBC_INIT` | VARCHAR2(254) | Y |  |  |
| 18 | `PBC_CMNT` | VARCHAR2(254) | Y |  |  |
| 19 | `PBC_EDIT` | VARCHAR2(61) | Y |  |  |
| 20 | `PBC_TAG` | VARCHAR2(254) | Y |  |  |

**인덱스:**

- `PBSYSCATCOLDICT_IDX` UNIQUE (PBC_TNAM, PBC_OWNR, PBC_CNAM)

---

### PBCATEDT
**PowerBuilder 카탈로그(편집)**
  행수: 21

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `PBE_NAME` | VARCHAR2(60) | Y |  |  |
| 2 | `PBE_EDIT` | VARCHAR2(254) | Y |  |  |
| 3 | `PBE_TYPE` | NUMBER | Y |  |  |
| 4 | `PBE_CNTR` | NUMBER | Y |  |  |
| 5 | `PBE_SEQN` | NUMBER | Y |  |  |
| 6 | `PBE_FLAG` | NUMBER | Y |  |  |
| 7 | `PBE_WORK` | VARCHAR2(32) | Y |  |  |

**인덱스:**

- `PBSYSPBE_IDX` UNIQUE (PBE_NAME, PBE_SEQN)

---

### PBCATFMT
**PowerBuilder 카탈로그(포맷)**
  행수: 20

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `PBF_NAME` | VARCHAR2(60) | Y |  |  |
| 2 | `PBF_FRMT` | VARCHAR2(254) | Y |  |  |
| 3 | `PBF_TYPE` | NUMBER | N |  |  |
| 4 | `PBF_CNTR` | NUMBER | Y |  |  |

**인덱스:**

- `PBSYSCATFRMTS_IDX` UNIQUE (PBF_NAME)

---

### PBCATTBL
**PowerBuilder 카탈로그(테이블)**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `PBT_TNAM` | VARCHAR2(60) | N |  |  |
| 2 | `PBT_TID` | NUMBER | Y |  |  |
| 3 | `PBT_OWNR` | VARCHAR2(60) | N |  |  |
| 4 | `PBD_FHGT` | NUMBER | Y |  |  |
| 5 | `PBD_FWGT` | NUMBER | Y |  |  |
| 6 | `PBD_FITL` | CHAR(1) | Y |  |  |
| 7 | `PBD_FUNL` | CHAR(1) | Y |  |  |
| 8 | `PBD_FCHR` | NUMBER | Y |  |  |
| 9 | `PBD_FPTC` | NUMBER | Y |  |  |
| 10 | `PBD_FFCE` | VARCHAR2(36) | Y |  |  |
| 11 | `PBH_FHGT` | NUMBER | Y |  |  |
| 12 | `PBH_FWGT` | NUMBER | Y |  |  |
| 13 | `PBH_FITL` | CHAR(1) | Y |  |  |
| 14 | `PBH_FUNL` | CHAR(1) | Y |  |  |
| 15 | `PBH_FCHR` | NUMBER | Y |  |  |
| 16 | `PBH_FPTC` | NUMBER | Y |  |  |
| 17 | `PBH_FFCE` | VARCHAR2(36) | Y |  |  |
| 18 | `PBL_FHGT` | NUMBER | Y |  |  |
| 19 | `PBL_FWGT` | NUMBER | Y |  |  |
| 20 | `PBL_FITL` | CHAR(1) | Y |  |  |
| 21 | `PBL_FUNL` | CHAR(1) | Y |  |  |
| 22 | `PBL_FCHR` | NUMBER | Y |  |  |
| 23 | `PBL_FPTC` | NUMBER | Y |  |  |
| 24 | `PBL_FFCE` | VARCHAR2(36) | Y |  |  |
| 25 | `PBT_CMNT` | VARCHAR2(254) | Y |  |  |

**인덱스:**

- `PBSYSCATPBT_IDX` UNIQUE (PBT_TNAM, PBT_OWNR)

---

### PBCATVLD
**PowerBuilder 카탈로그(검증)**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `PBV_NAME` | VARCHAR2(60) | Y |  |  |
| 2 | `PBV_VALD` | VARCHAR2(254) | Y |  |  |
| 3 | `PBV_TYPE` | NUMBER | Y |  |  |
| 4 | `PBV_CNTR` | NUMBER | Y |  |  |
| 5 | `PBV_MSG` | VARCHAR2(254) | Y |  |  |

**인덱스:**

- `PBSYSCATVLDS_IDX` UNIQUE (PBV_NAME)

---

### SHPACT_MIF
**작업실적 MES I/F 테이블**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `SNO` | VARCHAR2(15) | N | PK |  |
| 2 | `SHPJPNO` | VARCHAR2(16) | Y |  |  |
| 3 | `ITNBR` | VARCHAR2(20) | Y |  |  |
| 4 | `WKCTR` | VARCHAR2(6) | Y |  |  |
| 5 | `PDTGU` | VARCHAR2(6) | Y |  |  |
| 6 | `JOCOD` | VARCHAR2(6) | Y |  |  |
| 7 | `OPEMP` | VARCHAR2(20) | Y |  |  |
| 8 | `SIDAT` | VARCHAR2(8) | Y |  |  |
| 9 | `INWON` | NUMBER(3) | Y |  |  |
| 10 | `TOTIM` | NUMBER(10,2) | Y |  |  |
| 11 | `STIME` | VARCHAR2(4) | Y |  |  |
| 12 | `ETIME` | VARCHAR2(4) | Y |  |  |
| 13 | `NTIME` | NUMBER(10,2) | Y |  |  |
| 14 | `SIGBN` | VARCHAR2(1) | Y |  |  |
| 15 | `PURGC` | VARCHAR2(1) | Y |  |  |
| 16 | `ROQTY` | NUMBER(14,3) | Y |  |  |
| 17 | `FAQTY` | NUMBER(14,3) | Y |  |  |
| 18 | `SUQTY` | NUMBER(14,3) | Y |  |  |
| 19 | `PEQTY` | NUMBER(14,3) | Y |  |  |
| 20 | `COQTY` | NUMBER(14,3) | Y |  |  |
| 21 | `INSGU` | VARCHAR2(1) | Y |  |  |
| 22 | `IPGUB` | VARCHAR2(6) | Y |  |  |
| 23 | `OPSEQ` | VARCHAR2(4) | Y |  |  |
| 24 | `LASTC` | VARCHAR2(1) | Y |  |  |
| 25 | `CRT_USER` | VARCHAR2(30) | Y |  |  |
| 26 | `STDAT` | VARCHAR2(8) | Y |  |  |
| 27 | `RSSET` | NUMBER(10,2) | Y |  |  |
| 28 | `RSMAN` | NUMBER(10,2) | Y |  |  |
| 29 | `RSMCH` | NUMBER(10,2) | Y |  |  |
| 30 | `SILGBN` | VARCHAR2(1) | Y |  |  |
| 31 | `RQCGU` | VARCHAR2(1) | Y |  |  |
| 32 | `EDDAT` | VARCHAR2(8) | Y |  |  |
| 33 | `OCC_TYPE` | VARCHAR2(2) | Y |  | 1 |
| 34 | `WAIGBN` | VARCHAR2(1) | Y |  |  |
| 35 | `CVCOD` | VARCHAR2(13) | Y |  |  |
| 36 | `M_INS_DATE` | VARCHAR2(8) | Y |  |  |
| 37 | `M_INS_TIME` | VARCHAR2(6) | Y |  |  |
| 38 | `M_UPD_DATE` | VARCHAR2(8) | Y |  |  |
| 39 | `M_UPD_TIME` | VARCHAR2(6) | Y |  |  |
| 40 | `INS_TYPE` | VARCHAR2(1) | Y |  |  |
| 41 | `UPD_YN` | VARCHAR2(1) | Y |  |  |
| 42 | `UPD_USER` | VARCHAR2(30) | Y |  |  |

**인덱스:**

- `IDX_SHPACT_MIF_001`  (SHPJPNO, OPSEQ)
- `IDX_SHPACT_MIF_002`  (SIDAT, WKCTR)
- `IDX_SHPACT_MIF_003`  (SIDAT, WKCTR, RQCGU)
- `PK_SHPACT_MIF` UNIQUE (SNO)

---

### TH_BOX
**반제품 BOX 포장 상세 이력**
  행수: 3

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(5) | N | PK |  |
| 4 | `BOXNO` | VARCHAR2(50) | N | PK |  |
| 5 | `SERIAL` | VARCHAR2(50) | N | PK |  |
| 6 | `QTY` | NUMBER | Y |  |  |
| 7 | `UDF1` | NUMBER | Y |  |  |
| 8 | `UDF2` | NUMBER | Y |  |  |
| 9 | `UDF3` | NUMBER | Y |  |  |
| 10 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 11 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 12 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 13 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 14 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 15 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TH_BOX_PK` UNIQUE (CLIENT, COMPANY, PLANT, BOXNO, SERIAL)

---

### TH_CRIMPING
**압착 이력**
  행수: 943

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `TXNTIMEKEY` | VARCHAR2(20) | N | PK |  |
| 5 | `IFMODE` | VARCHAR2(8) | N | PK |  |
| 6 | `WRKORD` | VARCHAR2(15) | N |  |  |
| 7 | `WRKORDSEQ` | NUMBER | N |  |  |
| 8 | `PRODPROGNO` | VARCHAR2(30) | Y |  |  |
| 9 | `ORDQTY` | NUMBER | Y |  |  |
| 10 | `PRODQTY` | NUMBER | Y |  |  |
| 11 | `PRDSTTIME` | VARCHAR2(15) | Y |  |  |
| 12 | `PRDENTIME` | VARCHAR2(15) | Y |  |  |
| 13 | `LOSSTIME` | NUMBER | Y |  |  |
| 14 | `ERRCODE` | VARCHAR2(10) | Y |  |  |
| 15 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 16 | `UPH` | NUMBER | Y |  |  |
| 17 | `DATALOG` | VARCHAR2(500) | Y |  |  |

**인덱스:**

- `TH_CRIMPING_PK` UNIQUE (CLIENT, COMPANY, PLANT, TXNTIMEKEY, IFMODE)

---

### TH_CRIMPINSP
**압착검사 이력(결과)관리**
  행수: 21,724

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `TXNTIMEKEY` | VARCHAR2(20) | N | PK | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 5 | `TXNDATE` | VARCHAR2(8) | N | PK |  |
| 6 | `UNITNO` | VARCHAR2(10) | N | PK | 'NONE' |
| 7 | `SEQ` | VARCHAR2(5) | Y |  |  |
| 8 | `WIRE` | VARCHAR2(50) | Y |  |  |
| 9 | `TERMINAL` | VARCHAR2(50) | Y |  |  |
| 10 | `PARTNO` | VARCHAR2(50) | Y |  |  |
| 11 | `LOTNO` | VARCHAR2(50) | Y |  |  |
| 12 | `PRESSNO` | VARCHAR2(20) | Y |  |  |
| 13 | `SPEC` | NUMBER | Y |  |  |
| 14 | `TOLUP` | NUMBER | Y |  |  |
| 15 | `TOLDOWN` | NUMBER | Y |  |  |
| 16 | `PEAK` | NUMBER | Y |  |  |
| 17 | `UNIT` | VARCHAR2(5) | Y |  |  |
| 18 | `CREATEDATE` | VARCHAR2(30) | Y |  |  |
| 19 | `OPNAME` | VARCHAR2(20) | Y |  |  |
| 20 | `WIRECOLOR` | VARCHAR2(20) | Y |  |  |
| 21 | `CCH` | NUMBER | Y |  |  |
| 22 | `CCW` | NUMBER | Y |  |  |
| 23 | `ICH` | NUMBER | Y |  |  |
| 24 | `ICW` | NUMBER | Y |  |  |
| 25 | `TENSION` | NUMBER | Y |  |  |
| 26 | `RESISTANCE` | NUMBER | Y |  |  |
| 27 | `FPATH` | VARCHAR2(1000) | Y |  |  |
| 28 | `RPATH` | VARCHAR2(1000) | Y |  |  |
| 29 | `UDF1` | NUMBER | Y |  |  |
| 30 | `UDF2` | NUMBER | Y |  |  |
| 31 | `UDF3` | NUMBER | Y |  |  |
| 32 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 33 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 34 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 35 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 36 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TH_CRIMPINSP_IDX1`  (CLIENT, COMPANY, PLANT, TXNTIMEKEY, TERMINAL, WIRE)
- `TH_CRIMPINSP_PK` UNIQUE (CLIENT, COMPANY, PLANT, TXNTIMEKEY, TXNDATE, UNITNO)

---

### TH_CRIMPINSP_20211014
**압착검사 이력 백업(2021-10-14)**
  행수: 1,232

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | N |  |  |
| 3 | `PLANT` | VARCHAR2(10) | N |  |  |
| 4 | `TXNTIMEKEY` | VARCHAR2(20) | N |  |  |
| 5 | `TXNDATE` | VARCHAR2(8) | N |  |  |
| 6 | `UNITNO` | VARCHAR2(10) | N |  |  |
| 7 | `SEQ` | VARCHAR2(5) | Y |  |  |
| 8 | `WIRE` | VARCHAR2(50) | Y |  |  |
| 9 | `TERMINAL` | VARCHAR2(50) | Y |  |  |
| 10 | `PARTNO` | VARCHAR2(50) | Y |  |  |
| 11 | `LOTNO` | VARCHAR2(50) | Y |  |  |
| 12 | `PRESSNO` | VARCHAR2(20) | Y |  |  |
| 13 | `SPEC` | NUMBER | Y |  |  |
| 14 | `TOLUP` | NUMBER | Y |  |  |
| 15 | `TOLDOWN` | NUMBER | Y |  |  |
| 16 | `PEAK` | NUMBER | Y |  |  |
| 17 | `UNIT` | VARCHAR2(5) | Y |  |  |
| 18 | `CREATEDATE` | VARCHAR2(30) | Y |  |  |
| 19 | `OPNAME` | VARCHAR2(20) | Y |  |  |
| 20 | `WIRECOLOR` | VARCHAR2(20) | Y |  |  |
| 21 | `CCH` | NUMBER | Y |  |  |
| 22 | `CCW` | NUMBER | Y |  |  |
| 23 | `ICH` | NUMBER | Y |  |  |
| 24 | `ICW` | NUMBER | Y |  |  |
| 25 | `TENSION` | NUMBER | Y |  |  |
| 26 | `RESISTANCE` | NUMBER | Y |  |  |
| 27 | `FPATH` | VARCHAR2(1000) | Y |  |  |
| 28 | `RPATH` | VARCHAR2(1000) | Y |  |  |
| 29 | `UDF1` | NUMBER | Y |  |  |
| 30 | `UDF2` | NUMBER | Y |  |  |
| 31 | `UDF3` | NUMBER | Y |  |  |
| 32 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 33 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 34 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 35 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 36 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

---

### TH_CRIMP_IMAGE
**압착검사 이미지 관리**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `TXNTIMEKEY` | VARCHAR2(20) | N | PK | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 5 | `WIRE` | VARCHAR2(50) | N | PK |  |
| 6 | `TERMINAL` | VARCHAR2(50) | N | PK |  |
| 7 | `WIREIMAGE` | BLOB | Y |  |  |
| 8 | `TERMINALIMAGE` | BLOB | Y |  |  |
| 9 | `CREATETIMEKEY` | VARCHAR2(20) | N |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 10 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 11 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 12 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |
| 13 | `USEFLAG` | VARCHAR2(1) | Y |  |  |

**인덱스:**

- `TH_CRIMP_IMAGE_PK` UNIQUE (CLIENT, COMPANY, PLANT, TXNTIMEKEY, WIRE, TERMINAL)

---

### TH_MODBUS_IF
**Modbus 인터페이스**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | N |  |  |
| 3 | `PLANT` | VARCHAR2(10) | N |  |  |
| 4 | `IFDATE` | VARCHAR2(8) | N |  |  |
| 5 | `PROCESS` | VARCHAR2(10) | N |  |  |
| 6 | `UNITNO` | VARCHAR2(10) | N |  |  |
| 7 | `IP` | VARCHAR2(20) | N |  |  |
| 8 | `PRODQTY` | NUMBER | Y |  |  |
| 9 | `WRKORD` | VARCHAR2(15) | Y |  |  |
| 10 | `PROGRAMLOG` | VARCHAR2(4000) | Y |  |  |
| 11 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  |  |

---

### TH_OQC_REPORT
**OQC 리포트**
  행수: 52

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(5) | N | PK |  |
| 4 | `OQCREPORTNO` | VARCHAR2(30) | N | PK |  |
| 5 | `FPATH` | VARCHAR2(1000) | Y |  |  |
| 6 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 7 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 8 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 9 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 10 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 11 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TH_OQC_REPORT_PK` UNIQUE (CLIENT, COMPANY, PLANT, OQCREPORTNO)

---

### TH_SPLITMERGE
**SPLIT/MERGE 이력**
  행수: 2,242

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `SPTYPE` | VARCHAR2(1) | N |  |  |
| 2 | `TXNTIMEKEY` | VARCHAR2(20) | N |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 3 | `OLDSERIAL` | VARCHAR2(50) | N |  | 'NONE' |
| 4 | `NEWSERIAL` | VARCHAR2(50) | N |  | 'NONE' |
| 5 | `OLDQTY` | NUMBER | N |  | 0 |
| 6 | `NEWQTY` | NUMBER | N |  | 0 |
| 7 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 8 | `CREATETIMEKEY` | VARCHAR2(20) | N |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 9 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 10 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 11 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |
| 12 | `LOT` | VARCHAR2(30) | Y |  |  |
| 13 | `LOTSEQ` | VARCHAR2(3) | Y |  |  |

---

### TH_STOCKSERIAL
**재고 시리얼 이력(아카이브)**
  행수: 18,127,046

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `SERIAL` | VARCHAR2(50) | N |  |  |
| 2 | `TRANSACTIONTIMEKEY` | VARCHAR2(20) | N |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 3 | `LASTTRANSACTIONTIMEKEY` | VARCHAR2(20) | N |  |  |
| 4 | `LASTTRANSACTIONCODE` | VARCHAR2(10) | N |  |  |
| 5 | `ITEMCODE` | NUMBER | N |  |  |
| 6 | `WHLOC` | VARCHAR2(10) | N |  |  |
| 7 | `GOODQTY` | NUMBER | Y |  | 0 |
| 8 | `PRODLINE` | VARCHAR2(10) | Y |  |  |
| 9 | `OPER` | VARCHAR2(6) | Y |  |  |
| 10 | `PLANT` | VARCHAR2(10) | Y |  |  |
| 11 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 12 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 13 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 14 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |
| 15 | `STATUS` | VARCHAR2(10) | N |  |  |
| 16 | `BADQTY` | NUMBER | Y |  | 0 |

---

### TH_USESYSTEM
**시스템 사용이력**
  행수: 53,217

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | Y |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | Y |  |  |
| 3 | `PLANT` | VARCHAR2(10) | Y |  |  |
| 4 | `SYSCODE` | VARCHAR2(10) | N |  |  |
| 5 | `USERID` | VARCHAR2(10) | N |  |  |
| 6 | `CONTYPE` | NUMBER | N |  | 2 |
| 7 | `CONTIMEKEY` | VARCHAR2(20) | N |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 8 | `TERMIPADDR` | VARCHAR2(25) | Y |  |  |

---

### TH_USESYSTEMLOG
**시스템 로그메시지 사용이력**
  행수: 386,581

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | Y |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | Y |  |  |
| 3 | `PLANT` | VARCHAR2(10) | Y |  |  |
| 4 | `SYSCODE` | VARCHAR2(10) | N |  |  |
| 5 | `USERID` | VARCHAR2(10) | N |  |  |
| 6 | `TERMIPADDR` | VARCHAR2(25) | N |  |  |
| 7 | `LOGTIMEKEY` | VARCHAR2(20) | N |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 8 | `SUBJECT` | VARCHAR2(30) | Y |  |  |
| 9 | `HEADER` | VARCHAR2(100) | Y |  |  |
| 10 | `CONTENTS` | VARCHAR2(4000) | Y |  |  |

---

### TH_VERSIONHISTORY
**버전 이력**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | Y |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | Y |  |  |
| 3 | `PLANT` | VARCHAR2(10) | Y |  |  |
| 4 | `REQUSTNO` | VARCHAR2(12) | N |  |  |
| 5 | `REQUSTDATE` | VARCHAR2(8) | N |  |  |
| 6 | `REQUSTTYPE` | VARCHAR2(5) | N |  |  |
| 7 | `REQUSTSCREEN` | VARCHAR2(100) | Y |  |  |
| 8 | `REQUSTDEPT` | VARCHAR2(50) | Y |  |  |
| 9 | `REQUSTUSER` | VARCHAR2(50) | N |  | NULL |
| 10 | `REQUSTCONTENTS` | VARCHAR2(4000) | N |  | NULL |
| 11 | `APPLYFLAG` | VARCHAR2(1) | N |  | 'N' |
| 12 | `APPLYDATE` | VARCHAR2(8) | Y |  |  |
| 13 | `APPLYVERSION` | NUMBER | Y |  |  |
| 14 | `APPLYUSER` | VARCHAR2(50) | Y |  |  |
| 15 | `APPLYCONTENTS` | VARCHAR2(4000) | N |  | NULL |
| 16 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | to_char(systimestamp,'yyyymmddhh24mis... |
| 17 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 18 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  | to_char(systimestamp,'yyyymmddhh24mis... |
| 19 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

---

### TH_WORKORD
**생산 작업 이력**
  행수: 34,053

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | N |  |  |
| 3 | `PLANT` | VARCHAR2(5) | N |  |  |
| 4 | `PRODDATE` | VARCHAR2(8) | N |  |  |
| 5 | `WRKORD` | VARCHAR2(15) | N |  |  |
| 6 | `WRKORDSEQ` | NUMBER | N |  |  |
| 7 | `PRODPROGNO` | VARCHAR2(30) | N |  |  |
| 8 | `PRODSTTIME` | VARCHAR2(20) | Y |  |  |
| 9 | `PRODENTIME` | VARCHAR2(20) | Y |  |  |
| 10 | `STATUS` | VARCHAR2(5) | Y |  |  |
| 11 | `UDF1` | NUMBER | Y |  |  |
| 12 | `UDF2` | NUMBER | Y |  |  |
| 13 | `UDF3` | NUMBER | Y |  |  |
| 14 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 15 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 16 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 17 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 18 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 19 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

---

### TIF_STOCK
**재고 현황(인터페이스)**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(5) | N | PK |  |
| 4 | `ITEMCODE` | NUMBER | N | PK |  |
| 5 | `WHLOC` | VARCHAR2(10) | N | PK |  |
| 6 | `STOCKQTY` | NUMBER | Y |  | 0 |
| 7 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |

**인덱스:**

- `TIF_STOCK_PK` UNIQUE (CLIENT, COMPANY, PLANT, ITEMCODE, WHLOC)

---

### TL_LOGINFO
**로그 정보**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | Y |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | Y |  |  |
| 3 | `PLANT` | VARCHAR2(10) | Y |  |  |
| 4 | `PROCNAME` | VARCHAR2(100) | Y |  |  |
| 5 | `LOGTIMEKEY` | VARCHAR2(20) | Y |  |  |
| 6 | `LOGMESSAGE` | VARCHAR2(4000) | Y |  |  |
| 7 | `PARAMS` | VARCHAR2(2000) | Y |  |  |
| 8 | `OLDDATA` | CLOB | Y |  |  |
| 9 | `NEWDATA` | CLOB | Y |  |  |
| 10 | `LOGDATE` | VARCHAR2(8) | Y |  |  |

---

### TMP_ACTUALMATERIAL
**재고 실사 정보(자재소요계산임시테이블)**
  행수: 3,356

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | N |  |  |
| 3 | `PLANT` | VARCHAR2(5) | N |  |  |
| 4 | `SERIAL` | VARCHAR2(50) | N |  | 'NONE' |
| 5 | `UPRITEM` | NUMBER | Y |  |  |
| 6 | `UPRPARTNO` | VARCHAR2(30) | Y |  |  |
| 7 | `ITEMCODE` | NUMBER | Y |  |  |
| 8 | `PARTNO` | VARCHAR2(30) | Y |  |  |
| 9 | `ACTUALQTY` | NUMBER | Y |  |  |
| 10 | `ASSYUSAGE` | NUMBER | Y |  |  |
| 11 | `SUMASSYUSAGE` | NUMBER | Y |  |  |
| 12 | `UDF1` | NUMBER | Y |  |  |
| 13 | `UDF2` | NUMBER | Y |  |  |
| 14 | `UDF3` | NUMBER | Y |  |  |
| 15 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 16 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 17 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 18 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

---

### TM_BOM
**BOM마스터**
  행수: 9,206

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `IDX` | NUMBER | N | PK |  |
| 5 | `UPRIDX` | NUMBER | N | PK |  |
| 6 | `BOMGRP` | VARCHAR2(30) | N | PK |  |
| 7 | `REV` | NUMBER | N | PK |  |
| 8 | `UPRITEM` | NUMBER | N |  |  |
| 9 | `ITEMCODE` | NUMBER | N |  |  |
| 10 | `SEQ` | NUMBER | Y |  |  |
| 11 | `OPER` | VARCHAR2(6) | Y |  |  |
| 12 | `ASSYOPER` | VARCHAR2(6) | Y |  |  |
| 13 | `ASSYUSAGE` | NUMBER | N |  |  |
| 14 | `SIDE` | VARCHAR2(30) | N |  | 'NONE' |
| 15 | `STORAGEFLAG` | VARCHAR2(1) | N |  | 'Y' |
| 16 | `ASSYFLAG` | VARCHAR2(1) | N |  | 'N' |
| 17 | `VALIDFROMDATE` | VARCHAR2(20) | Y |  |  |
| 18 | `STARTDATE` | VARCHAR2(8) | Y |  |  |
| 19 | `ENDDATE` | VARCHAR2(8) | Y |  | '99991231' |
| 20 | `REPLACEFLAG` | VARCHAR2(1) | Y |  | 'N' |
| 21 | `UDF2` | NUMBER | Y |  |  |
| 22 | `UDF3` | NUMBER | Y |  |  |
| 23 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 24 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 25 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 26 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 27 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 28 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_BOM_PK` UNIQUE (CLIENT, COMPANY, PLANT, IDX, UPRIDX, BOMGRP, REV)

---

### TM_BOMGRP
**BOM그룹마스터**
  행수: 118

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `BOMGRP` | VARCHAR2(30) | N | PK |  |
| 5 | `REV` | NUMBER | N | PK |  |
| 6 | `ITEMCODE` | NUMBER | Y |  |  |
| 7 | `ERPFLAG` | VARCHAR2(1) | N |  | 'N' |
| 8 | `STARTDATE` | VARCHAR2(8) | Y |  |  |
| 9 | `ENDDATE` | VARCHAR2(8) | Y |  |  |
| 10 | `FPATH` | VARCHAR2(1000) | Y |  |  |
| 11 | `UDF2` | NUMBER | Y |  |  |
| 12 | `UDF3` | NUMBER | Y |  |  |
| 13 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 14 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 15 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 16 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 17 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 18 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_BOMGRP_PK` UNIQUE (CLIENT, COMPANY, PLANT, BOMGRP, REV)

---

### TM_BOM_FIND
**BOM 검색용**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | N |  |  |
| 3 | `PLANT` | VARCHAR2(10) | N |  |  |
| 4 | `BOMGRP` | VARCHAR2(30) | N |  |  |
| 5 | `UPRITEM` | NUMBER | N |  |  |
| 6 | `BOM_FIND` | VARCHAR2(2000) | N |  |  |

---

### TM_BOM_FIND2
**BOM 검색용2**
  행수: 287

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | N |  |  |
| 3 | `PLANT` | VARCHAR2(10) | N |  |  |
| 4 | `BOMGRP` | VARCHAR2(30) | N |  |  |
| 5 | `UPRITEM` | NUMBER | N |  |  |
| 6 | `BOM_FIND` | VARCHAR2(2000) | N |  |  |

---

### TM_BOM_RELEASE
**BOM 릴리스**
  행수: 3,841

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | N |  |  |
| 3 | `PLANT` | VARCHAR2(10) | N |  |  |
| 4 | `BOMGRP` | VARCHAR2(30) | N |  |  |
| 5 | `UPRITEM` | NUMBER | N |  |  |
| 6 | `ITEMCODE` | NUMBER | N |  |  |
| 7 | `ASSYUSAGE` | NUMBER | Y |  |  |

---

### TM_BOM_TEMP
**BOM 임시**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | N |  |  |
| 3 | `PLANT` | VARCHAR2(5) | N |  |  |
| 4 | `DEPTH` | NUMBER | N |  |  |
| 5 | `UPRITEM` | VARCHAR2(20) | N |  |  |
| 6 | `ITEMCODE` | VARCHAR2(20) | N |  |  |
| 7 | `USSEQ` | VARCHAR2(20) | N |  |  |
| 8 | `ASSYUSAGE` | NUMBER | N |  |  |
| 9 | `QTY` | NUMBER | N |  |  |

---

### TM_BOM_TEMP2
**BOM 임시2**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `PINBR` | VARCHAR2(20) | N |  |  |
| 2 | `CINBR` | VARCHAR2(20) | N |  |  |
| 3 | `ITEMTYPE` | VARCHAR2(20) | N |  |  |
| 4 | `USSEQ` | VARCHAR2(20) | N |  |  |

---

### TM_BOX
**BOX 정보 마스터**
  행수: 97,094

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(5) | N | PK |  |
| 4 | `BOXNO` | VARCHAR2(50) | N | PK |  |
| 5 | `BOXTYPE` | VARCHAR2(1) | N |  |  |
| 6 | `PACKINGDATE` | VARCHAR2(8) | Y |  |  |
| 7 | `WHINDATE` | VARCHAR2(8) | Y |  |  |
| 8 | `WHLOC` | VARCHAR2(10) | Y |  |  |
| 9 | `ITEMCODE` | NUMBER | N |  |  |
| 10 | `QTY` | NUMBER | N |  | 0 |
| 11 | `JUDGE` | VARCHAR2(1) | N |  | 'N' |
| 12 | `OLDBOXNO` | VARCHAR2(50) | Y |  |  |
| 13 | `ETCQTY` | NUMBER | Y |  |  |
| 14 | `SNO` | VARCHAR2(15) | Y |  |  |
| 15 | `WEIGHT` | VARCHAR2(20) | Y |  |  |
| 16 | `UDF1` | NUMBER | Y |  |  |
| 17 | `UDF2` | NUMBER | Y |  |  |
| 18 | `UDF3` | NUMBER | Y |  |  |
| 19 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 20 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 21 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 22 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 23 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 24 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_BOX_PK` UNIQUE (CLIENT, COMPANY, PLANT, BOXNO)

---

### TM_CALENDER
**기준달력(임의의 주를 계산하기 위한 사용자 달력)**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CAL_DATE` | VARCHAR2(8) | N | PK |  |
| 2 | `MS_MONTH` | VARCHAR2(6) | Y |  |  |
| 3 | `MS_YEAR_WEEK` | VARCHAR2(6) | Y |  |  |
| 4 | `MS_START_DATE` | VARCHAR2(8) | Y |  |  |
| 5 | `MS_END_DATE` | VARCHAR2(8) | Y |  |  |
| 6 | `WEEK_DAY` | VARCHAR2(20) | Y |  |  |
| 7 | `START7_WEEK` | VARCHAR2(2) | Y |  |  |
| 8 | `SM_WEEK_1JAN` | VARCHAR2(2) | Y |  |  |
| 9 | `MS_WEEK_1JAN` | VARCHAR2(2) | Y |  |  |
| 10 | `SUB_DAY` | VARCHAR2(2) | Y |  |  |
| 11 | `TOT_DAY` | VARCHAR2(2) | Y |  |  |
| 12 | `WEEK_NO` | VARCHAR2(2) | Y |  |  |

**인덱스:**

- `TM_CALENDER_PK` UNIQUE (CAL_DATE)

---

### TM_CLIENT
**법인마스터**
  행수: 1

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `CLIENTNAME` | VARCHAR2(50) | N |  |  |
| 3 | `UDF1` | NUMBER | Y |  |  |
| 4 | `UDF2` | NUMBER | Y |  |  |
| 5 | `UDF3` | NUMBER | Y |  |  |
| 6 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 7 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 8 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 9 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 10 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 11 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_CLIENT_PK` UNIQUE (CLIENT)

---

### TM_CLOSINGBASE
**마감월기준**
  행수: 1,000

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `CLOSINGMONTH` | VARCHAR2(6) | N | PK |  |
| 5 | `FROMDATE` | VARCHAR2(8) | N |  |  |
| 6 | `TODATE` | VARCHAR2(8) | N |  |  |
| 7 | `CREATETIMEKEY` | VARCHAR2(20) | N |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 8 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 9 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 10 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_CLOSINGBASE_PK` UNIQUE (CLIENT, COMPANY, PLANT, CLOSINGMONTH)

---

### TM_COMMCODE
**공통코드 마스터**
  행수: 171

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `COMMGRP` | VARCHAR2(5) | N | PK |  |
| 5 | `COMMCODE` | VARCHAR2(10) | N | PK |  |
| 6 | `COMMNAME` | VARCHAR2(50) | Y |  |  |
| 7 | `NVALUE` | NUMBER | Y |  |  |
| 8 | `CVALUE` | VARCHAR2(10) | Y |  |  |
| 9 | `UDF1` | NUMBER | Y |  |  |
| 10 | `UDF2` | NUMBER | Y |  |  |
| 11 | `UDF3` | NUMBER | Y |  |  |
| 12 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 13 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 14 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 15 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 16 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 17 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_COMMCODE_PK` UNIQUE (CLIENT, COMPANY, PLANT, COMMGRP, COMMCODE)

---

### TM_COMMGRP
**공통코드 그룹**
  행수: 15

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `SYSCODE` | VARCHAR2(10) | N | PK |  |
| 5 | `COMMGRP` | VARCHAR2(5) | N | PK |  |
| 6 | `COMMGRPNAME` | VARCHAR2(30) | Y |  |  |
| 7 | `DISPFLAG` | VARCHAR2(1) | Y |  | 'N' |
| 8 | `UDF1` | NUMBER | Y |  |  |
| 9 | `UDF2` | NUMBER | Y |  |  |
| 10 | `UDF3` | NUMBER | Y |  |  |
| 11 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 12 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 13 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 14 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 15 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 16 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_COMMGRP_PK` UNIQUE (CLIENT, COMPANY, PLANT, SYSCODE, COMMGRP)

---

### TM_COMPANY
**부속회사마스터**
  행수: 1

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `COMPANYNAME` | VARCHAR2(50) | N |  |  |
| 4 | `UDF1` | NUMBER | Y |  |  |
| 5 | `UDF2` | NUMBER | Y |  |  |
| 6 | `UDF3` | NUMBER | Y |  |  |
| 7 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 8 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 9 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 10 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 11 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 12 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_COMPANY_PK` UNIQUE (CLIENT, COMPANY)

---

### TM_CONVEYOR_REPORT_02
**LQC리포트**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `SEQ` | VARCHAR2(3) | N | PK |  |
| 5 | `WORKDATE` | VARCHAR2(8) | N | PK |  |
| 6 | `REALDATE` | VARCHAR2(8) | N | PK |  |
| 7 | `DEFECT` | VARCHAR2(10) | N | PK |  |
| 8 | `DEFECTNAME` | VARCHAR2(100) | N |  |  |
| 9 | `PPM` | NUMBER | Y |  |  |
| 10 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 11 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_CONVEYOR_REPORT_02_PK` UNIQUE (CLIENT, COMPANY, PLANT, SEQ, WORKDATE, REALDATE, DEFECT)

---

### TM_CRIMPINSP
**압착검사마스터**
  행수: 39

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | N |  |  |
| 3 | `PLANT` | VARCHAR2(10) | N |  |  |
| 4 | `WIRE` | VARCHAR2(50) | N |  |  |
| 5 | `TERMINAL` | VARCHAR2(50) | N |  |  |
| 6 | `IMGWIRE` | BLOB | Y |  |  |
| 7 | `IMGTERMINAL` | BLOB | Y |  |  |
| 8 | `CCHLOW` | NUMBER | Y |  |  |
| 9 | `CCHHIGH` | NUMBER | Y |  |  |
| 10 | `CCWLOW` | NUMBER | Y |  |  |
| 11 | `CCWHIGH` | NUMBER | Y |  |  |
| 12 | `ICHLOW` | NUMBER | Y |  |  |
| 13 | `ICHHIGH` | NUMBER | Y |  |  |
| 14 | `ICWLOW` | NUMBER | Y |  |  |
| 15 | `ICWHIGH` | NUMBER | Y |  |  |
| 16 | `TENLOW` | NUMBER | Y |  |  |
| 17 | `TENHIGH` | NUMBER | Y |  |  |
| 18 | `RESISLOW` | NUMBER | Y |  |  |
| 19 | `RESISHIGH` | NUMBER | Y |  |  |
| 20 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 21 | `UDF1` | NUMBER | Y |  |  |
| 22 | `UDF2` | NUMBER | Y |  |  |
| 23 | `UDF3` | NUMBER | Y |  |  |
| 24 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 25 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 26 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 27 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 28 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

---

### TM_CUSTPLAN
**고객 계획**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `VENDOR` | VARCHAR2(10) | N | PK |  |
| 5 | `PLANDATE` | VARCHAR2(8) | N | PK |  |
| 6 | `SEQ` | VARCHAR2(3) | N | PK |  |
| 7 | `ITEMCODE` | NUMBER | N | PK |  |
| 8 | `QTY1` | NUMBER | Y |  |  |
| 9 | `QTY2` | NUMBER | Y |  |  |
| 10 | `QTY3` | NUMBER | Y |  |  |
| 11 | `QTY4` | NUMBER | Y |  |  |
| 12 | `QTY5` | NUMBER | Y |  |  |
| 13 | `QTY6` | NUMBER | Y |  |  |
| 14 | `QTY7` | NUMBER | Y |  |  |
| 15 | `QTY8` | NUMBER | Y |  |  |
| 16 | `QTY9` | NUMBER | Y |  |  |
| 17 | `QTY10` | NUMBER | Y |  |  |
| 18 | `QTY11` | NUMBER | Y |  |  |
| 19 | `QTY12` | NUMBER | Y |  |  |
| 20 | `QTY13` | NUMBER | Y |  |  |
| 21 | `QTY14` | NUMBER | Y |  |  |
| 22 | `QTY15` | NUMBER | Y |  |  |
| 23 | `QTY16` | NUMBER | Y |  |  |
| 24 | `QTY17` | NUMBER | Y |  |  |
| 25 | `QTY18` | NUMBER | Y |  |  |
| 26 | `QTY19` | NUMBER | Y |  |  |
| 27 | `QTY20` | NUMBER | Y |  |  |
| 28 | `QTY21` | NUMBER | Y |  |  |
| 29 | `QTY22` | NUMBER | Y |  |  |
| 30 | `QTY23` | NUMBER | Y |  |  |
| 31 | `QTY24` | NUMBER | Y |  |  |
| 32 | `QTY25` | NUMBER | Y |  |  |
| 33 | `QTY26` | NUMBER | Y |  |  |
| 34 | `QTY27` | NUMBER | Y |  |  |
| 35 | `QTY28` | NUMBER | Y |  |  |
| 36 | `QTY29` | NUMBER | Y |  |  |
| 37 | `QTY30` | NUMBER | Y |  |  |
| 38 | `QTY31` | NUMBER | Y |  |  |
| 39 | `QTY32` | NUMBER | Y |  |  |
| 40 | `QTY33` | NUMBER | Y |  |  |
| 41 | `QTY34` | NUMBER | Y |  |  |
| 42 | `QTY35` | NUMBER | Y |  |  |
| 43 | `QTY36` | NUMBER | Y |  |  |
| 44 | `QTY37` | NUMBER | Y |  |  |
| 45 | `QTY38` | NUMBER | Y |  |  |
| 46 | `QTY39` | NUMBER | Y |  |  |
| 47 | `QTY40` | NUMBER | Y |  |  |
| 48 | `QTY41` | NUMBER | Y |  |  |
| 49 | `QTY42` | NUMBER | Y |  |  |
| 50 | `QTY43` | NUMBER | Y |  |  |
| 51 | `QTY44` | NUMBER | Y |  |  |
| 52 | `QTY45` | NUMBER | Y |  |  |
| 53 | `QTY46` | NUMBER | Y |  |  |
| 54 | `QTY47` | NUMBER | Y |  |  |
| 55 | `QTY48` | NUMBER | Y |  |  |
| 56 | `QTY49` | NUMBER | Y |  |  |
| 57 | `QTY50` | NUMBER | Y |  |  |
| 58 | `QTY51` | NUMBER | Y |  |  |
| 59 | `QTY52` | NUMBER | Y |  |  |
| 60 | `QTY53` | NUMBER | Y |  |  |
| 61 | `QTY54` | NUMBER | Y |  |  |
| 62 | `QTY55` | NUMBER | Y |  |  |
| 63 | `QTY56` | NUMBER | Y |  |  |
| 64 | `QTY57` | NUMBER | Y |  |  |
| 65 | `QTY58` | NUMBER | Y |  |  |
| 66 | `QTY59` | NUMBER | Y |  |  |
| 67 | `QTY60` | NUMBER | Y |  |  |
| 68 | `QTY61` | NUMBER | Y |  |  |
| 69 | `QTY62` | NUMBER | Y |  |  |
| 70 | `QTY63` | NUMBER | Y |  |  |
| 71 | `QTY64` | NUMBER | Y |  |  |
| 72 | `QTY65` | NUMBER | Y |  |  |
| 73 | `QTY66` | NUMBER | Y |  |  |
| 74 | `QTY67` | NUMBER | Y |  |  |
| 75 | `QTY68` | NUMBER | Y |  |  |
| 76 | `QTY69` | NUMBER | Y |  |  |
| 77 | `QTY70` | NUMBER | Y |  |  |
| 78 | `QTY71` | NUMBER | Y |  |  |
| 79 | `QTY72` | NUMBER | Y |  |  |
| 80 | `QTY73` | NUMBER | Y |  |  |
| 81 | `QTY74` | NUMBER | Y |  |  |
| 82 | `QTY75` | NUMBER | Y |  |  |
| 83 | `QTY76` | NUMBER | Y |  |  |
| 84 | `QTY77` | NUMBER | Y |  |  |
| 85 | `QTY78` | NUMBER | Y |  |  |
| 86 | `QTY79` | NUMBER | Y |  |  |
| 87 | `QTY80` | NUMBER | Y |  |  |
| 88 | `QTY81` | NUMBER | Y |  |  |
| 89 | `QTY82` | NUMBER | Y |  |  |
| 90 | `QTY83` | NUMBER | Y |  |  |
| 91 | `QTY84` | NUMBER | Y |  |  |
| 92 | `QTY85` | NUMBER | Y |  |  |
| 93 | `QTY86` | NUMBER | Y |  |  |
| 94 | `QTY87` | NUMBER | Y |  |  |
| 95 | `QTY88` | NUMBER | Y |  |  |
| 96 | `QTY89` | NUMBER | Y |  |  |
| 97 | `QTY90` | NUMBER | Y |  |  |
| 98 | `QTY91` | NUMBER | Y |  |  |
| 99 | `QTY92` | NUMBER | Y |  |  |
| 100 | `QTY93` | NUMBER | Y |  |  |
| 101 | `QTY94` | NUMBER | Y |  |  |
| 102 | `QTY95` | NUMBER | Y |  |  |
| 103 | `ACCQTY1` | NUMBER | Y |  |  |
| 104 | `ACCQTY2` | NUMBER | Y |  |  |
| 105 | `ACCQTY3` | NUMBER | Y |  |  |
| 106 | `ACCQTY4` | NUMBER | Y |  |  |
| 107 | `ACCQTY5` | NUMBER | Y |  |  |
| 108 | `ACCQTY6` | NUMBER | Y |  |  |
| 109 | `ACCQTY7` | NUMBER | Y |  |  |
| 110 | `ACCQTY8` | NUMBER | Y |  |  |
| 111 | `ACCQTY9` | NUMBER | Y |  |  |
| 112 | `ACCQTY10` | NUMBER | Y |  |  |
| 113 | `ACCQTY11` | NUMBER | Y |  |  |
| 114 | `ACCQTY12` | NUMBER | Y |  |  |
| 115 | `ACCQTY13` | NUMBER | Y |  |  |
| 116 | `ACCQTY14` | NUMBER | Y |  |  |
| 117 | `ACCQTY15` | NUMBER | Y |  |  |
| 118 | `ACCQTY16` | NUMBER | Y |  |  |
| 119 | `ACCQTY17` | NUMBER | Y |  |  |
| 120 | `ACCQTY18` | NUMBER | Y |  |  |
| 121 | `ACCQTY19` | NUMBER | Y |  |  |
| 122 | `ACCQTY20` | NUMBER | Y |  |  |
| 123 | `ACCQTY21` | NUMBER | Y |  |  |
| 124 | `ACCQTY22` | NUMBER | Y |  |  |
| 125 | `ACCQTY23` | NUMBER | Y |  |  |
| 126 | `ACCQTY24` | NUMBER | Y |  |  |
| 127 | `ACCQTY25` | NUMBER | Y |  |  |
| 128 | `ACCQTY26` | NUMBER | Y |  |  |
| 129 | `ACCQTY27` | NUMBER | Y |  |  |
| 130 | `ACCQTY28` | NUMBER | Y |  |  |
| 131 | `ACCQTY29` | NUMBER | Y |  |  |
| 132 | `ACCQTY30` | NUMBER | Y |  |  |
| 133 | `ACCQTY31` | NUMBER | Y |  |  |
| 134 | `ACCQTY32` | NUMBER | Y |  |  |
| 135 | `ACCQTY33` | NUMBER | Y |  |  |
| 136 | `ACCQTY34` | NUMBER | Y |  |  |
| 137 | `ACCQTY35` | NUMBER | Y |  |  |
| 138 | `ACCQTY36` | NUMBER | Y |  |  |
| 139 | `ACCQTY37` | NUMBER | Y |  |  |
| 140 | `ACCQTY38` | NUMBER | Y |  |  |
| 141 | `ACCQTY39` | NUMBER | Y |  |  |
| 142 | `ACCQTY40` | NUMBER | Y |  |  |
| 143 | `ACCQTY41` | NUMBER | Y |  |  |
| 144 | `ACCQTY42` | NUMBER | Y |  |  |
| 145 | `ACCQTY43` | NUMBER | Y |  |  |
| 146 | `ACCQTY44` | NUMBER | Y |  |  |
| 147 | `ACCQTY45` | NUMBER | Y |  |  |
| 148 | `ACCQTY46` | NUMBER | Y |  |  |
| 149 | `ACCQTY47` | NUMBER | Y |  |  |
| 150 | `ACCQTY48` | NUMBER | Y |  |  |
| 151 | `ACCQTY49` | NUMBER | Y |  |  |
| 152 | `ACCQTY50` | NUMBER | Y |  |  |
| 153 | `ACCQTY51` | NUMBER | Y |  |  |
| 154 | `ACCQTY52` | NUMBER | Y |  |  |
| 155 | `ACCQTY53` | NUMBER | Y |  |  |
| 156 | `ACCQTY54` | NUMBER | Y |  |  |
| 157 | `ACCQTY55` | NUMBER | Y |  |  |
| 158 | `ACCQTY56` | NUMBER | Y |  |  |
| 159 | `ACCQTY57` | NUMBER | Y |  |  |
| 160 | `ACCQTY58` | NUMBER | Y |  |  |
| 161 | `ACCQTY59` | NUMBER | Y |  |  |
| 162 | `ACCQTY60` | NUMBER | Y |  |  |
| 163 | `ACCQTY61` | NUMBER | Y |  |  |
| 164 | `ACCQTY62` | NUMBER | Y |  |  |
| 165 | `ACCQTY63` | NUMBER | Y |  |  |
| 166 | `ACCQTY64` | NUMBER | Y |  |  |
| 167 | `ACCQTY65` | NUMBER | Y |  |  |
| 168 | `ACCQTY66` | NUMBER | Y |  |  |
| 169 | `ACCQTY67` | NUMBER | Y |  |  |
| 170 | `ACCQTY68` | NUMBER | Y |  |  |
| 171 | `ACCQTY69` | NUMBER | Y |  |  |
| 172 | `ACCQTY70` | NUMBER | Y |  |  |
| 173 | `ACCQTY71` | NUMBER | Y |  |  |
| 174 | `ACCQTY72` | NUMBER | Y |  |  |
| 175 | `ACCQTY73` | NUMBER | Y |  |  |
| 176 | `ACCQTY74` | NUMBER | Y |  |  |
| 177 | `ACCQTY75` | NUMBER | Y |  |  |
| 178 | `ACCQTY76` | NUMBER | Y |  |  |
| 179 | `ACCQTY77` | NUMBER | Y |  |  |
| 180 | `ACCQTY78` | NUMBER | Y |  |  |
| 181 | `ACCQTY79` | NUMBER | Y |  |  |
| 182 | `ACCQTY80` | NUMBER | Y |  |  |
| 183 | `ACCQTY81` | NUMBER | Y |  |  |
| 184 | `ACCQTY82` | NUMBER | Y |  |  |
| 185 | `ACCQTY83` | NUMBER | Y |  |  |
| 186 | `ACCQTY84` | NUMBER | Y |  |  |
| 187 | `ACCQTY85` | NUMBER | Y |  |  |
| 188 | `ACCQTY86` | NUMBER | Y |  |  |
| 189 | `ACCQTY87` | NUMBER | Y |  |  |
| 190 | `ACCQTY88` | NUMBER | Y |  |  |
| 191 | `ACCQTY89` | NUMBER | Y |  |  |
| 192 | `ACCQTY90` | NUMBER | Y |  |  |
| 193 | `ACCQTY91` | NUMBER | Y |  |  |
| 194 | `ACCQTY92` | NUMBER | Y |  |  |
| 195 | `ACCQTY93` | NUMBER | Y |  |  |
| 196 | `ACCQTY94` | NUMBER | Y |  |  |
| 197 | `ACCQTY95` | NUMBER | Y |  |  |
| 198 | `CREATETIMEKEY` | VARCHAR2(20) | N |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 199 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 200 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 201 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_CUSTPLAN_PK` UNIQUE (CLIENT, COMPANY, PLANT, VENDOR, PLANDATE, SEQ, ITEMCODE)

---

### TM_CUSTPLAN_MONTH
**고객 월별 계획**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `VENDOR` | VARCHAR2(10) | N | PK |  |
| 5 | `PLANMONTH` | VARCHAR2(8) | N | PK |  |
| 6 | `SEQ` | VARCHAR2(3) | N | PK |  |
| 7 | `ITEMCODE` | NUMBER | N | PK |  |
| 8 | `PRODLINE` | VARCHAR2(10) | N | PK |  |
| 9 | `WO` | VARCHAR2(20) | N | PK |  |
| 10 | `MODEL` | VARCHAR2(20) | N | PK |  |
| 11 | `MODELSUFFIX` | VARCHAR2(40) | N | PK |  |
| 12 | `TOOL` | VARCHAR2(20) | Y |  |  |
| 13 | `COLOR` | VARCHAR2(10) | Y |  |  |
| 14 | `ETD` | VARCHAR2(20) | Y |  |  |
| 15 | `BUCKET` | VARCHAR2(20) | Y |  |  |
| 16 | `SHIPTO` | VARCHAR2(20) | Y |  |  |
| 17 | `WOQTY` | NUMBER | Y |  |  |
| 18 | `REMAIN` | NUMBER | Y |  |  |
| 19 | `DUDATE` | VARCHAR2(20) | Y |  |  |
| 20 | `PST` | VARCHAR2(20) | Y |  |  |
| 21 | `STARTTIME` | VARCHAR2(20) | Y |  |  |
| 22 | `QTY1` | NUMBER | Y |  |  |
| 23 | `QTY2` | NUMBER | Y |  |  |
| 24 | `QTY3` | NUMBER | Y |  |  |
| 25 | `QTY4` | NUMBER | Y |  |  |
| 26 | `QTY5` | NUMBER | Y |  |  |
| 27 | `QTY6` | NUMBER | Y |  |  |
| 28 | `QTY7` | NUMBER | Y |  |  |
| 29 | `QTY8` | NUMBER | Y |  |  |
| 30 | `QTY9` | NUMBER | Y |  |  |
| 31 | `QTY10` | NUMBER | Y |  |  |
| 32 | `QTY11` | NUMBER | Y |  |  |
| 33 | `QTY12` | NUMBER | Y |  |  |
| 34 | `QTY13` | NUMBER | Y |  |  |
| 35 | `QTY14` | NUMBER | Y |  |  |
| 36 | `QTY15` | NUMBER | Y |  |  |
| 37 | `QTY16` | NUMBER | Y |  |  |
| 38 | `QTY17` | NUMBER | Y |  |  |
| 39 | `QTY18` | NUMBER | Y |  |  |
| 40 | `QTY19` | NUMBER | Y |  |  |
| 41 | `QTY20` | NUMBER | Y |  |  |
| 42 | `QTY21` | NUMBER | Y |  |  |
| 43 | `QTY22` | NUMBER | Y |  |  |
| 44 | `QTY23` | NUMBER | Y |  |  |
| 45 | `QTY24` | NUMBER | Y |  |  |
| 46 | `QTY25` | NUMBER | Y |  |  |
| 47 | `QTY26` | NUMBER | Y |  |  |
| 48 | `QTY27` | NUMBER | Y |  |  |
| 49 | `QTY28` | NUMBER | Y |  |  |
| 50 | `QTY29` | NUMBER | Y |  |  |
| 51 | `QTY30` | NUMBER | Y |  |  |
| 52 | `QTY31` | NUMBER | Y |  |  |
| 53 | `QTY32` | NUMBER | Y |  |  |
| 54 | `QTY33` | NUMBER | Y |  |  |
| 55 | `QTY34` | NUMBER | Y |  |  |
| 56 | `QTY35` | NUMBER | Y |  |  |
| 57 | `QTY36` | NUMBER | Y |  |  |
| 58 | `QTY37` | NUMBER | Y |  |  |
| 59 | `QTY38` | NUMBER | Y |  |  |
| 60 | `QTY39` | NUMBER | Y |  |  |
| 61 | `QTY40` | NUMBER | Y |  |  |
| 62 | `QTY41` | NUMBER | Y |  |  |
| 63 | `QTY42` | NUMBER | Y |  |  |
| 64 | `QTY43` | NUMBER | Y |  |  |
| 65 | `QTY44` | NUMBER | Y |  |  |
| 66 | `QTY45` | NUMBER | Y |  |  |
| 67 | `QTY46` | NUMBER | Y |  |  |
| 68 | `QTY47` | NUMBER | Y |  |  |
| 69 | `QTY48` | NUMBER | Y |  |  |
| 70 | `QTY49` | NUMBER | Y |  |  |
| 71 | `QTY50` | NUMBER | Y |  |  |
| 72 | `QTY51` | NUMBER | Y |  |  |
| 73 | `QTY52` | NUMBER | Y |  |  |
| 74 | `QTY53` | NUMBER | Y |  |  |
| 75 | `QTY54` | NUMBER | Y |  |  |
| 76 | `QTY55` | NUMBER | Y |  |  |
| 77 | `QTY56` | NUMBER | Y |  |  |
| 78 | `QTY57` | NUMBER | Y |  |  |
| 79 | `QTY58` | NUMBER | Y |  |  |
| 80 | `QTY59` | NUMBER | Y |  |  |
| 81 | `QTY60` | NUMBER | Y |  |  |
| 82 | `QTY61` | NUMBER | Y |  |  |
| 83 | `QTY62` | NUMBER | Y |  |  |
| 84 | `QTY63` | NUMBER | Y |  |  |
| 85 | `QTY64` | NUMBER | Y |  |  |
| 86 | `QTY65` | NUMBER | Y |  |  |
| 87 | `QTY66` | NUMBER | Y |  |  |
| 88 | `QTY67` | NUMBER | Y |  |  |
| 89 | `QTY68` | NUMBER | Y |  |  |
| 90 | `QTY69` | NUMBER | Y |  |  |
| 91 | `QTY70` | NUMBER | Y |  |  |
| 92 | `QTY71` | NUMBER | Y |  |  |
| 93 | `QTY72` | NUMBER | Y |  |  |
| 94 | `QTY73` | NUMBER | Y |  |  |
| 95 | `QTY74` | NUMBER | Y |  |  |
| 96 | `QTY75` | NUMBER | Y |  |  |
| 97 | `QTY76` | NUMBER | Y |  |  |
| 98 | `QTY77` | NUMBER | Y |  |  |
| 99 | `QTY78` | NUMBER | Y |  |  |
| 100 | `QTY79` | NUMBER | Y |  |  |
| 101 | `QTY80` | NUMBER | Y |  |  |
| 102 | `QTY81` | NUMBER | Y |  |  |
| 103 | `QTY82` | NUMBER | Y |  |  |
| 104 | `QTY83` | NUMBER | Y |  |  |
| 105 | `QTY84` | NUMBER | Y |  |  |
| 106 | `QTY85` | NUMBER | Y |  |  |
| 107 | `QTY86` | NUMBER | Y |  |  |
| 108 | `QTY87` | NUMBER | Y |  |  |
| 109 | `QTY88` | NUMBER | Y |  |  |
| 110 | `QTY89` | NUMBER | Y |  |  |
| 111 | `QTY90` | NUMBER | Y |  |  |
| 112 | `QTY91` | NUMBER | Y |  |  |
| 113 | `QTY92` | NUMBER | Y |  |  |
| 114 | `QTY93` | NUMBER | Y |  |  |
| 115 | `QTY94` | NUMBER | Y |  |  |
| 116 | `QTY95` | NUMBER | Y |  |  |
| 117 | `CREATETIMEKEY` | VARCHAR2(20) | N |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 118 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 119 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 120 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_CUSTPLAN_MONTH_PK` UNIQUE (CLIENT, COMPANY, PLANT, VENDOR, PLANMONTH, SEQ, ITEMCODE, PRODLINE, WO, MODEL, MODELSUFFIX)

---

### TM_CUSTPLAN_ORDER
**고객 주문 계획**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `PLANDATE` | VARCHAR2(8) | N | PK |  |
| 5 | `SEQ` | VARCHAR2(3) | N | PK |  |
| 6 | `WORKORDER` | VARCHAR2(20) | N | PK |  |
| 7 | `MODELSUFFIX` | VARCHAR2(30) | N | PK |  |
| 8 | `ITEMCODE` | NUMBER | N | PK |  |
| 9 | `ROWSEQ` | NUMBER | Y |  |  |
| 10 | `QTY1` | NUMBER | Y |  |  |
| 11 | `QTY2` | NUMBER | Y |  |  |
| 12 | `QTY3` | NUMBER | Y |  |  |
| 13 | `QTY4` | NUMBER | Y |  |  |
| 14 | `QTY5` | NUMBER | Y |  |  |
| 15 | `QTY6` | NUMBER | Y |  |  |
| 16 | `QTY7` | NUMBER | Y |  |  |
| 17 | `QTY8` | NUMBER | Y |  |  |
| 18 | `QTY9` | NUMBER | Y |  |  |
| 19 | `QTY10` | NUMBER | Y |  |  |
| 20 | `QTY11` | NUMBER | Y |  |  |
| 21 | `QTY12` | NUMBER | Y |  |  |
| 22 | `QTY13` | NUMBER | Y |  |  |
| 23 | `QTY14` | NUMBER | Y |  |  |
| 24 | `QTY15` | NUMBER | Y |  |  |
| 25 | `QTY16` | NUMBER | Y |  |  |
| 26 | `QTY17` | NUMBER | Y |  |  |
| 27 | `QTY18` | NUMBER | Y |  |  |
| 28 | `QTY19` | NUMBER | Y |  |  |
| 29 | `QTY20` | NUMBER | Y |  |  |
| 30 | `QTY21` | NUMBER | Y |  |  |
| 31 | `QTY22` | NUMBER | Y |  |  |
| 32 | `QTY23` | NUMBER | Y |  |  |
| 33 | `QTY24` | NUMBER | Y |  |  |
| 34 | `QTY25` | NUMBER | Y |  |  |
| 35 | `QTY26` | NUMBER | Y |  |  |
| 36 | `QTY27` | NUMBER | Y |  |  |
| 37 | `QTY28` | NUMBER | Y |  |  |
| 38 | `QTY29` | NUMBER | Y |  |  |
| 39 | `QTY30` | NUMBER | Y |  |  |
| 40 | `QTY31` | NUMBER | Y |  |  |
| 41 | `CREATETIMEKEY` | VARCHAR2(20) | N |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 42 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 43 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 44 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_CUSTPLAN_ORDER_PK` UNIQUE (CLIENT, COMPANY, PLANT, PLANDATE, SEQ, WORKORDER, MODELSUFFIX, ITEMCODE)

---

### TM_CUSTPLAN_TEMP
**고객 계획 임시**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `PLANDATE` | VARCHAR2(8) | N | PK |  |
| 5 | `ITEMCODE` | NUMBER | N | PK |  |
| 6 | `STOCKQTY` | NUMBER | Y |  | 0 |
| 7 | `QTY1` | NUMBER | Y |  | 0 |
| 8 | `QTY2` | NUMBER | Y |  | 0 |
| 9 | `QTY3` | NUMBER | Y |  | 0 |
| 10 | `QTY4` | NUMBER | Y |  | 0 |
| 11 | `QTY5` | NUMBER | Y |  | 0 |
| 12 | `QTY6` | NUMBER | Y |  | 0 |
| 13 | `QTY7` | NUMBER | Y |  | 0 |
| 14 | `QTY8` | NUMBER | Y |  | 0 |
| 15 | `QTY9` | NUMBER | Y |  | 0 |
| 16 | `QTY10` | NUMBER | Y |  | 0 |
| 17 | `QTY11` | NUMBER | Y |  | 0 |
| 18 | `QTY12` | NUMBER | Y |  | 0 |
| 19 | `QTY13` | NUMBER | Y |  | 0 |
| 20 | `QTY14` | NUMBER | Y |  | 0 |
| 21 | `QTY15` | NUMBER | Y |  | 0 |
| 22 | `QTY16` | NUMBER | Y |  | 0 |
| 23 | `QTY17` | NUMBER | Y |  | 0 |
| 24 | `QTY18` | NUMBER | Y |  | 0 |
| 25 | `QTY19` | NUMBER | Y |  | 0 |
| 26 | `QTY20` | NUMBER | Y |  | 0 |
| 27 | `QTY21` | NUMBER | Y |  | 0 |
| 28 | `QTY22` | NUMBER | Y |  | 0 |
| 29 | `QTY23` | NUMBER | Y |  | 0 |
| 30 | `QTY24` | NUMBER | Y |  | 0 |
| 31 | `QTY25` | NUMBER | Y |  | 0 |
| 32 | `QTY26` | NUMBER | Y |  | 0 |
| 33 | `QTY27` | NUMBER | Y |  | 0 |
| 34 | `QTY28` | NUMBER | Y |  | 0 |
| 35 | `QTY29` | NUMBER | Y |  | 0 |
| 36 | `QTY30` | NUMBER | Y |  | 0 |
| 37 | `QTY31` | NUMBER | Y |  | 0 |
| 38 | `QTY32` | NUMBER | Y |  | 0 |
| 39 | `QTY33` | NUMBER | Y |  | 0 |
| 40 | `QTY34` | NUMBER | Y |  | 0 |
| 41 | `QTY35` | NUMBER | Y |  | 0 |
| 42 | `QTY36` | NUMBER | Y |  | 0 |
| 43 | `QTY37` | NUMBER | Y |  | 0 |
| 44 | `QTY38` | NUMBER | Y |  | 0 |
| 45 | `QTY39` | NUMBER | Y |  | 0 |
| 46 | `QTY40` | NUMBER | Y |  | 0 |
| 47 | `QTY41` | NUMBER | Y |  | 0 |
| 48 | `QTY42` | NUMBER | Y |  | 0 |
| 49 | `QTY43` | NUMBER | Y |  | 0 |
| 50 | `QTY44` | NUMBER | Y |  | 0 |
| 51 | `QTY45` | NUMBER | Y |  | 0 |
| 52 | `QTY46` | NUMBER | Y |  | 0 |
| 53 | `QTY47` | NUMBER | Y |  | 0 |
| 54 | `QTY48` | NUMBER | Y |  | 0 |
| 55 | `QTY49` | NUMBER | Y |  | 0 |
| 56 | `QTY50` | NUMBER | Y |  | 0 |
| 57 | `QTY51` | NUMBER | Y |  | 0 |
| 58 | `QTY52` | NUMBER | Y |  | 0 |
| 59 | `QTY53` | NUMBER | Y |  | 0 |
| 60 | `QTY54` | NUMBER | Y |  | 0 |
| 61 | `QTY55` | NUMBER | Y |  | 0 |
| 62 | `QTY56` | NUMBER | Y |  | 0 |
| 63 | `QTY57` | NUMBER | Y |  | 0 |
| 64 | `QTY58` | NUMBER | Y |  | 0 |
| 65 | `QTY59` | NUMBER | Y |  | 0 |
| 66 | `QTY60` | NUMBER | Y |  | 0 |
| 67 | `QTY61` | NUMBER | Y |  | 0 |
| 68 | `QTY62` | NUMBER | Y |  | 0 |
| 69 | `QTY63` | NUMBER | Y |  | 0 |
| 70 | `QTY64` | NUMBER | Y |  | 0 |
| 71 | `QTY65` | NUMBER | Y |  | 0 |
| 72 | `QTY66` | NUMBER | Y |  | 0 |
| 73 | `QTY67` | NUMBER | Y |  | 0 |
| 74 | `QTY68` | NUMBER | Y |  | 0 |
| 75 | `QTY69` | NUMBER | Y |  | 0 |
| 76 | `QTY70` | NUMBER | Y |  | 0 |
| 77 | `QTY71` | NUMBER | Y |  | 0 |
| 78 | `QTY72` | NUMBER | Y |  | 0 |
| 79 | `QTY73` | NUMBER | Y |  | 0 |
| 80 | `QTY74` | NUMBER | Y |  | 0 |
| 81 | `QTY75` | NUMBER | Y |  | 0 |
| 82 | `QTY76` | NUMBER | Y |  | 0 |
| 83 | `QTY77` | NUMBER | Y |  | 0 |
| 84 | `QTY78` | NUMBER | Y |  | 0 |
| 85 | `QTY79` | NUMBER | Y |  | 0 |
| 86 | `QTY80` | NUMBER | Y |  | 0 |
| 87 | `QTY81` | NUMBER | Y |  | 0 |
| 88 | `QTY82` | NUMBER | Y |  | 0 |
| 89 | `QTY83` | NUMBER | Y |  | 0 |
| 90 | `QTY84` | NUMBER | Y |  | 0 |
| 91 | `QTY85` | NUMBER | Y |  | 0 |
| 92 | `QTY86` | NUMBER | Y |  | 0 |
| 93 | `QTY87` | NUMBER | Y |  | 0 |
| 94 | `QTY88` | NUMBER | Y |  | 0 |
| 95 | `QTY89` | NUMBER | Y |  | 0 |
| 96 | `QTY90` | NUMBER | Y |  | 0 |
| 97 | `QTY91` | NUMBER | Y |  | 0 |
| 98 | `QTY92` | NUMBER | Y |  | 0 |
| 99 | `QTY93` | NUMBER | Y |  | 0 |
| 100 | `QTY94` | NUMBER | Y |  | 0 |
| 101 | `QTY95` | NUMBER | Y |  | 0 |
| 102 | `ACCQTY1` | NUMBER | Y |  | 0 |
| 103 | `ACCQTY2` | NUMBER | Y |  | 0 |
| 104 | `ACCQTY3` | NUMBER | Y |  | 0 |
| 105 | `ACCQTY4` | NUMBER | Y |  | 0 |
| 106 | `ACCQTY5` | NUMBER | Y |  | 0 |
| 107 | `ACCQTY6` | NUMBER | Y |  | 0 |
| 108 | `ACCQTY7` | NUMBER | Y |  | 0 |
| 109 | `ACCQTY8` | NUMBER | Y |  | 0 |
| 110 | `ACCQTY9` | NUMBER | Y |  | 0 |
| 111 | `ACCQTY10` | NUMBER | Y |  | 0 |
| 112 | `ACCQTY11` | NUMBER | Y |  | 0 |
| 113 | `ACCQTY12` | NUMBER | Y |  | 0 |
| 114 | `ACCQTY13` | NUMBER | Y |  | 0 |
| 115 | `ACCQTY14` | NUMBER | Y |  | 0 |
| 116 | `ACCQTY15` | NUMBER | Y |  | 0 |
| 117 | `ACCQTY16` | NUMBER | Y |  | 0 |
| 118 | `ACCQTY17` | NUMBER | Y |  | 0 |
| 119 | `ACCQTY18` | NUMBER | Y |  | 0 |
| 120 | `ACCQTY19` | NUMBER | Y |  | 0 |
| 121 | `ACCQTY20` | NUMBER | Y |  | 0 |
| 122 | `ACCQTY21` | NUMBER | Y |  | 0 |
| 123 | `ACCQTY22` | NUMBER | Y |  | 0 |
| 124 | `ACCQTY23` | NUMBER | Y |  | 0 |
| 125 | `ACCQTY24` | NUMBER | Y |  | 0 |
| 126 | `ACCQTY25` | NUMBER | Y |  | 0 |
| 127 | `ACCQTY26` | NUMBER | Y |  | 0 |
| 128 | `ACCQTY27` | NUMBER | Y |  | 0 |
| 129 | `ACCQTY28` | NUMBER | Y |  | 0 |
| 130 | `ACCQTY29` | NUMBER | Y |  | 0 |
| 131 | `ACCQTY30` | NUMBER | Y |  | 0 |
| 132 | `ACCQTY31` | NUMBER | Y |  | 0 |
| 133 | `ACCQTY32` | NUMBER | Y |  | 0 |
| 134 | `ACCQTY33` | NUMBER | Y |  | 0 |
| 135 | `ACCQTY34` | NUMBER | Y |  | 0 |
| 136 | `ACCQTY35` | NUMBER | Y |  | 0 |
| 137 | `ACCQTY36` | NUMBER | Y |  | 0 |
| 138 | `ACCQTY37` | NUMBER | Y |  | 0 |
| 139 | `ACCQTY38` | NUMBER | Y |  | 0 |
| 140 | `ACCQTY39` | NUMBER | Y |  | 0 |
| 141 | `ACCQTY40` | NUMBER | Y |  | 0 |
| 142 | `ACCQTY41` | NUMBER | Y |  | 0 |
| 143 | `ACCQTY42` | NUMBER | Y |  | 0 |
| 144 | `ACCQTY43` | NUMBER | Y |  | 0 |
| 145 | `ACCQTY44` | NUMBER | Y |  | 0 |
| 146 | `ACCQTY45` | NUMBER | Y |  | 0 |
| 147 | `ACCQTY46` | NUMBER | Y |  | 0 |
| 148 | `ACCQTY47` | NUMBER | Y |  | 0 |
| 149 | `ACCQTY48` | NUMBER | Y |  | 0 |
| 150 | `ACCQTY49` | NUMBER | Y |  | 0 |
| 151 | `ACCQTY50` | NUMBER | Y |  | 0 |
| 152 | `ACCQTY51` | NUMBER | Y |  | 0 |
| 153 | `ACCQTY52` | NUMBER | Y |  | 0 |
| 154 | `ACCQTY53` | NUMBER | Y |  | 0 |
| 155 | `ACCQTY54` | NUMBER | Y |  | 0 |
| 156 | `ACCQTY55` | NUMBER | Y |  | 0 |
| 157 | `ACCQTY56` | NUMBER | Y |  | 0 |
| 158 | `ACCQTY57` | NUMBER | Y |  | 0 |
| 159 | `ACCQTY58` | NUMBER | Y |  | 0 |
| 160 | `ACCQTY59` | NUMBER | Y |  | 0 |
| 161 | `ACCQTY60` | NUMBER | Y |  | 0 |
| 162 | `ACCQTY61` | NUMBER | Y |  | 0 |
| 163 | `ACCQTY62` | NUMBER | Y |  | 0 |
| 164 | `ACCQTY63` | NUMBER | Y |  | 0 |
| 165 | `ACCQTY64` | NUMBER | Y |  | 0 |
| 166 | `ACCQTY65` | NUMBER | Y |  | 0 |
| 167 | `ACCQTY66` | NUMBER | Y |  | 0 |
| 168 | `ACCQTY67` | NUMBER | Y |  | 0 |
| 169 | `ACCQTY68` | NUMBER | Y |  | 0 |
| 170 | `ACCQTY69` | NUMBER | Y |  | 0 |
| 171 | `ACCQTY70` | NUMBER | Y |  | 0 |
| 172 | `ACCQTY71` | NUMBER | Y |  | 0 |
| 173 | `ACCQTY72` | NUMBER | Y |  | 0 |
| 174 | `ACCQTY73` | NUMBER | Y |  | 0 |
| 175 | `ACCQTY74` | NUMBER | Y |  | 0 |
| 176 | `ACCQTY75` | NUMBER | Y |  | 0 |
| 177 | `ACCQTY76` | NUMBER | Y |  | 0 |
| 178 | `ACCQTY77` | NUMBER | Y |  | 0 |
| 179 | `ACCQTY78` | NUMBER | Y |  | 0 |
| 180 | `ACCQTY79` | NUMBER | Y |  | 0 |
| 181 | `ACCQTY80` | NUMBER | Y |  | 0 |
| 182 | `ACCQTY81` | NUMBER | Y |  | 0 |
| 183 | `ACCQTY82` | NUMBER | Y |  | 0 |
| 184 | `ACCQTY83` | NUMBER | Y |  | 0 |
| 185 | `ACCQTY84` | NUMBER | Y |  | 0 |
| 186 | `ACCQTY85` | NUMBER | Y |  | 0 |
| 187 | `ACCQTY86` | NUMBER | Y |  | 0 |
| 188 | `ACCQTY87` | NUMBER | Y |  | 0 |
| 189 | `ACCQTY88` | NUMBER | Y |  | 0 |
| 190 | `ACCQTY89` | NUMBER | Y |  | 0 |
| 191 | `ACCQTY90` | NUMBER | Y |  | 0 |
| 192 | `ACCQTY91` | NUMBER | Y |  | 0 |
| 193 | `ACCQTY92` | NUMBER | Y |  | 0 |
| 194 | `ACCQTY93` | NUMBER | Y |  | 0 |
| 195 | `ACCQTY94` | NUMBER | Y |  | 0 |
| 196 | `ACCQTY95` | NUMBER | Y |  | 0 |
| 197 | `CREATETIMEKEY` | VARCHAR2(20) | N |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 198 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 199 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 200 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_CUSTPLAN_TEMP_PK` UNIQUE (CLIENT, COMPANY, PLANT, PLANDATE, ITEMCODE)

---

### TM_CUSTPLAN_TEMP_TEMP
**고객 계획 임시2**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | N |  |  |
| 3 | `PLANT` | VARCHAR2(10) | N |  |  |
| 4 | `PLANDATE` | VARCHAR2(8) | N |  |  |
| 5 | `ITEMCODE` | NUMBER | N |  |  |
| 6 | `STOCKQTY` | NUMBER | Y |  |  |
| 7 | `QTY1` | NUMBER | Y |  |  |
| 8 | `QTY2` | NUMBER | Y |  |  |
| 9 | `QTY3` | NUMBER | Y |  |  |
| 10 | `QTY4` | NUMBER | Y |  |  |
| 11 | `QTY5` | NUMBER | Y |  |  |
| 12 | `QTY6` | NUMBER | Y |  |  |
| 13 | `QTY7` | NUMBER | Y |  |  |
| 14 | `QTY8` | NUMBER | Y |  |  |
| 15 | `QTY9` | NUMBER | Y |  |  |
| 16 | `QTY10` | NUMBER | Y |  |  |
| 17 | `QTY11` | NUMBER | Y |  |  |
| 18 | `QTY12` | NUMBER | Y |  |  |
| 19 | `QTY13` | NUMBER | Y |  |  |
| 20 | `QTY14` | NUMBER | Y |  |  |
| 21 | `QTY15` | NUMBER | Y |  |  |
| 22 | `QTY16` | NUMBER | Y |  |  |
| 23 | `QTY17` | NUMBER | Y |  |  |
| 24 | `QTY18` | NUMBER | Y |  |  |
| 25 | `QTY19` | NUMBER | Y |  |  |
| 26 | `QTY20` | NUMBER | Y |  |  |
| 27 | `QTY21` | NUMBER | Y |  |  |
| 28 | `QTY22` | NUMBER | Y |  |  |
| 29 | `QTY23` | NUMBER | Y |  |  |
| 30 | `QTY24` | NUMBER | Y |  |  |
| 31 | `QTY25` | NUMBER | Y |  |  |
| 32 | `QTY26` | NUMBER | Y |  |  |
| 33 | `QTY27` | NUMBER | Y |  |  |
| 34 | `QTY28` | NUMBER | Y |  |  |
| 35 | `QTY29` | NUMBER | Y |  |  |
| 36 | `QTY30` | NUMBER | Y |  |  |
| 37 | `QTY31` | NUMBER | Y |  |  |
| 38 | `QTY32` | NUMBER | Y |  |  |
| 39 | `QTY33` | NUMBER | Y |  |  |
| 40 | `QTY34` | NUMBER | Y |  |  |
| 41 | `QTY35` | NUMBER | Y |  |  |
| 42 | `QTY36` | NUMBER | Y |  |  |
| 43 | `QTY37` | NUMBER | Y |  |  |
| 44 | `QTY38` | NUMBER | Y |  |  |
| 45 | `QTY39` | NUMBER | Y |  |  |
| 46 | `QTY40` | NUMBER | Y |  |  |
| 47 | `QTY41` | NUMBER | Y |  |  |
| 48 | `QTY42` | NUMBER | Y |  |  |
| 49 | `QTY43` | NUMBER | Y |  |  |
| 50 | `QTY44` | NUMBER | Y |  |  |
| 51 | `QTY45` | NUMBER | Y |  |  |
| 52 | `QTY46` | NUMBER | Y |  |  |
| 53 | `QTY47` | NUMBER | Y |  |  |
| 54 | `QTY48` | NUMBER | Y |  |  |
| 55 | `QTY49` | NUMBER | Y |  |  |
| 56 | `QTY50` | NUMBER | Y |  |  |
| 57 | `QTY51` | NUMBER | Y |  |  |
| 58 | `QTY52` | NUMBER | Y |  |  |
| 59 | `QTY53` | NUMBER | Y |  |  |
| 60 | `QTY54` | NUMBER | Y |  |  |
| 61 | `QTY55` | NUMBER | Y |  |  |
| 62 | `QTY56` | NUMBER | Y |  |  |
| 63 | `QTY57` | NUMBER | Y |  |  |
| 64 | `QTY58` | NUMBER | Y |  |  |
| 65 | `QTY59` | NUMBER | Y |  |  |
| 66 | `QTY60` | NUMBER | Y |  |  |
| 67 | `QTY61` | NUMBER | Y |  |  |
| 68 | `QTY62` | NUMBER | Y |  |  |
| 69 | `QTY63` | NUMBER | Y |  |  |
| 70 | `QTY64` | NUMBER | Y |  |  |
| 71 | `QTY65` | NUMBER | Y |  |  |
| 72 | `QTY66` | NUMBER | Y |  |  |
| 73 | `QTY67` | NUMBER | Y |  |  |
| 74 | `QTY68` | NUMBER | Y |  |  |
| 75 | `QTY69` | NUMBER | Y |  |  |
| 76 | `QTY70` | NUMBER | Y |  |  |
| 77 | `QTY71` | NUMBER | Y |  |  |
| 78 | `QTY72` | NUMBER | Y |  |  |
| 79 | `QTY73` | NUMBER | Y |  |  |
| 80 | `QTY74` | NUMBER | Y |  |  |
| 81 | `QTY75` | NUMBER | Y |  |  |
| 82 | `QTY76` | NUMBER | Y |  |  |
| 83 | `QTY77` | NUMBER | Y |  |  |
| 84 | `QTY78` | NUMBER | Y |  |  |
| 85 | `QTY79` | NUMBER | Y |  |  |
| 86 | `QTY80` | NUMBER | Y |  |  |
| 87 | `QTY81` | NUMBER | Y |  |  |
| 88 | `QTY82` | NUMBER | Y |  |  |
| 89 | `QTY83` | NUMBER | Y |  |  |
| 90 | `QTY84` | NUMBER | Y |  |  |
| 91 | `QTY85` | NUMBER | Y |  |  |
| 92 | `QTY86` | NUMBER | Y |  |  |
| 93 | `QTY87` | NUMBER | Y |  |  |
| 94 | `QTY88` | NUMBER | Y |  |  |
| 95 | `QTY89` | NUMBER | Y |  |  |
| 96 | `QTY90` | NUMBER | Y |  |  |
| 97 | `QTY91` | NUMBER | Y |  |  |
| 98 | `QTY92` | NUMBER | Y |  |  |
| 99 | `QTY93` | NUMBER | Y |  |  |
| 100 | `QTY94` | NUMBER | Y |  |  |
| 101 | `QTY95` | NUMBER | Y |  |  |
| 102 | `ACCQTY1` | NUMBER | Y |  |  |
| 103 | `ACCQTY2` | NUMBER | Y |  |  |
| 104 | `ACCQTY3` | NUMBER | Y |  |  |
| 105 | `ACCQTY4` | NUMBER | Y |  |  |
| 106 | `ACCQTY5` | NUMBER | Y |  |  |
| 107 | `ACCQTY6` | NUMBER | Y |  |  |
| 108 | `ACCQTY7` | NUMBER | Y |  |  |
| 109 | `ACCQTY8` | NUMBER | Y |  |  |
| 110 | `ACCQTY9` | NUMBER | Y |  |  |
| 111 | `ACCQTY10` | NUMBER | Y |  |  |
| 112 | `ACCQTY11` | NUMBER | Y |  |  |
| 113 | `ACCQTY12` | NUMBER | Y |  |  |
| 114 | `ACCQTY13` | NUMBER | Y |  |  |
| 115 | `ACCQTY14` | NUMBER | Y |  |  |
| 116 | `ACCQTY15` | NUMBER | Y |  |  |
| 117 | `ACCQTY16` | NUMBER | Y |  |  |
| 118 | `ACCQTY17` | NUMBER | Y |  |  |
| 119 | `ACCQTY18` | NUMBER | Y |  |  |
| 120 | `ACCQTY19` | NUMBER | Y |  |  |
| 121 | `ACCQTY20` | NUMBER | Y |  |  |
| 122 | `ACCQTY21` | NUMBER | Y |  |  |
| 123 | `ACCQTY22` | NUMBER | Y |  |  |
| 124 | `ACCQTY23` | NUMBER | Y |  |  |
| 125 | `ACCQTY24` | NUMBER | Y |  |  |
| 126 | `ACCQTY25` | NUMBER | Y |  |  |
| 127 | `ACCQTY26` | NUMBER | Y |  |  |
| 128 | `ACCQTY27` | NUMBER | Y |  |  |
| 129 | `ACCQTY28` | NUMBER | Y |  |  |
| 130 | `ACCQTY29` | NUMBER | Y |  |  |
| 131 | `ACCQTY30` | NUMBER | Y |  |  |
| 132 | `ACCQTY31` | NUMBER | Y |  |  |
| 133 | `ACCQTY32` | NUMBER | Y |  |  |
| 134 | `ACCQTY33` | NUMBER | Y |  |  |
| 135 | `ACCQTY34` | NUMBER | Y |  |  |
| 136 | `ACCQTY35` | NUMBER | Y |  |  |
| 137 | `ACCQTY36` | NUMBER | Y |  |  |
| 138 | `ACCQTY37` | NUMBER | Y |  |  |
| 139 | `ACCQTY38` | NUMBER | Y |  |  |
| 140 | `ACCQTY39` | NUMBER | Y |  |  |
| 141 | `ACCQTY40` | NUMBER | Y |  |  |
| 142 | `ACCQTY41` | NUMBER | Y |  |  |
| 143 | `ACCQTY42` | NUMBER | Y |  |  |
| 144 | `ACCQTY43` | NUMBER | Y |  |  |
| 145 | `ACCQTY44` | NUMBER | Y |  |  |
| 146 | `ACCQTY45` | NUMBER | Y |  |  |
| 147 | `ACCQTY46` | NUMBER | Y |  |  |
| 148 | `ACCQTY47` | NUMBER | Y |  |  |
| 149 | `ACCQTY48` | NUMBER | Y |  |  |
| 150 | `ACCQTY49` | NUMBER | Y |  |  |
| 151 | `ACCQTY50` | NUMBER | Y |  |  |
| 152 | `ACCQTY51` | NUMBER | Y |  |  |
| 153 | `ACCQTY52` | NUMBER | Y |  |  |
| 154 | `ACCQTY53` | NUMBER | Y |  |  |
| 155 | `ACCQTY54` | NUMBER | Y |  |  |
| 156 | `ACCQTY55` | NUMBER | Y |  |  |
| 157 | `ACCQTY56` | NUMBER | Y |  |  |
| 158 | `ACCQTY57` | NUMBER | Y |  |  |
| 159 | `ACCQTY58` | NUMBER | Y |  |  |
| 160 | `ACCQTY59` | NUMBER | Y |  |  |
| 161 | `ACCQTY60` | NUMBER | Y |  |  |
| 162 | `ACCQTY61` | NUMBER | Y |  |  |
| 163 | `ACCQTY62` | NUMBER | Y |  |  |
| 164 | `ACCQTY63` | NUMBER | Y |  |  |
| 165 | `ACCQTY64` | NUMBER | Y |  |  |
| 166 | `ACCQTY65` | NUMBER | Y |  |  |
| 167 | `ACCQTY66` | NUMBER | Y |  |  |
| 168 | `ACCQTY67` | NUMBER | Y |  |  |
| 169 | `ACCQTY68` | NUMBER | Y |  |  |
| 170 | `ACCQTY69` | NUMBER | Y |  |  |
| 171 | `ACCQTY70` | NUMBER | Y |  |  |
| 172 | `ACCQTY71` | NUMBER | Y |  |  |
| 173 | `ACCQTY72` | NUMBER | Y |  |  |
| 174 | `ACCQTY73` | NUMBER | Y |  |  |
| 175 | `ACCQTY74` | NUMBER | Y |  |  |
| 176 | `ACCQTY75` | NUMBER | Y |  |  |
| 177 | `ACCQTY76` | NUMBER | Y |  |  |
| 178 | `ACCQTY77` | NUMBER | Y |  |  |
| 179 | `ACCQTY78` | NUMBER | Y |  |  |
| 180 | `ACCQTY79` | NUMBER | Y |  |  |
| 181 | `ACCQTY80` | NUMBER | Y |  |  |
| 182 | `ACCQTY81` | NUMBER | Y |  |  |
| 183 | `ACCQTY82` | NUMBER | Y |  |  |
| 184 | `ACCQTY83` | NUMBER | Y |  |  |
| 185 | `ACCQTY84` | NUMBER | Y |  |  |
| 186 | `ACCQTY85` | NUMBER | Y |  |  |
| 187 | `ACCQTY86` | NUMBER | Y |  |  |
| 188 | `ACCQTY87` | NUMBER | Y |  |  |
| 189 | `ACCQTY88` | NUMBER | Y |  |  |
| 190 | `ACCQTY89` | NUMBER | Y |  |  |
| 191 | `ACCQTY90` | NUMBER | Y |  |  |
| 192 | `ACCQTY91` | NUMBER | Y |  |  |
| 193 | `ACCQTY92` | NUMBER | Y |  |  |
| 194 | `ACCQTY93` | NUMBER | Y |  |  |
| 195 | `ACCQTY94` | NUMBER | Y |  |  |
| 196 | `ACCQTY95` | NUMBER | Y |  |  |
| 197 | `CREATETIMEKEY` | VARCHAR2(20) | N |  |  |
| 198 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 199 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 200 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

---

### TM_DEFECT
**불량마스터**
  행수: 109

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `DEFECT` | VARCHAR2(10) | N | PK |  |
| 5 | `DEFECTNAME` | VARCHAR2(200) | N |  |  |
| 6 | `DEFECTTYPE` | NUMBER | Y |  |  |
| 7 | `UDF1` | NUMBER | Y |  |  |
| 8 | `UDF2` | NUMBER | Y |  |  |
| 9 | `UDF3` | NUMBER | Y |  |  |
| 10 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 11 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 12 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 13 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 14 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 15 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |
| 16 | `IMAGE` | BLOB | Y |  |  |

**인덱스:**

- `TM_DEFECT_PK` UNIQUE (CLIENT, COMPANY, PLANT, DEFECT)

---

### TM_DEPARTMENT
**부서마스터**
  행수: 17

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `DEPARTMENT` | VARCHAR2(10) | N | PK |  |
| 5 | `DEPARTMENTNAME` | VARCHAR2(30) | N |  |  |
| 6 | `UDF1` | NUMBER | Y |  |  |
| 7 | `UDF2` | NUMBER | Y |  |  |
| 8 | `UDF3` | NUMBER | Y |  |  |
| 9 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 10 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 11 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 12 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 13 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 14 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_DEPARTMENT_PK` UNIQUE (CLIENT, COMPANY, PLANT, DEPARTMENT)

---

### TM_DOWNTIME
**비가동마스터**
  행수: 5

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | N |  |  |
| 3 | `PLANT` | VARCHAR2(10) | N |  |  |
| 4 | `DOWNDATE` | VARCHAR2(8) | N |  |  |
| 5 | `SHIFT` | VARCHAR2(5) | N |  |  |
| 6 | `STARTTIME` | VARCHAR2(8) | N |  |  |
| 7 | `ENDTIME` | VARCHAR2(8) | N |  |  |
| 8 | `DOWNTIME` | VARCHAR2(5) | Y |  |  |
| 9 | `UDF1` | NUMBER | Y |  |  |
| 10 | `UDF2` | NUMBER | Y |  |  |
| 11 | `UDF3` | NUMBER | Y |  |  |
| 12 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 13 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 14 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 15 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 16 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 17 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

---

### TM_EHR
**인사마스터**
  행수: 191

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `EHRCODE` | VARCHAR2(10) | N | PK |  |
| 5 | `LOCUSERNAME` | VARCHAR2(50) | N |  |  |
| 6 | `ENGUSERNAME` | VARCHAR2(50) | Y |  |  |
| 7 | `PHONE` | VARCHAR2(20) | Y |  |  |
| 8 | `EMAIL` | VARCHAR2(30) | Y |  |  |
| 9 | `DEPARTMENT` | VARCHAR2(10) | Y |  |  |
| 10 | `POSITION` | VARCHAR2(2) | Y |  |  |
| 11 | `HIREDATE` | VARCHAR2(8) | N |  | '19000101' |
| 12 | `QUITDATE` | VARCHAR2(8) | N |  | '99991231' |
| 13 | `UDF1` | NUMBER | Y |  |  |
| 14 | `UDF2` | NUMBER | Y |  |  |
| 15 | `UDF3` | NUMBER | Y |  |  |
| 16 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 17 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 18 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 19 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 20 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 21 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_EHR_PK` UNIQUE (CLIENT, COMPANY, PLANT, EHRCODE)

---

### TM_EQP
**설비 마스터**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `EQP` | VARCHAR2(10) | N | PK |  |
| 5 | `EQPNAME` | VARCHAR2(50) | N |  |  |
| 6 | `WHLOC` | VARCHAR2(10) | N |  |  |
| 7 | `MAKER` | VARCHAR2(50) | Y |  |  |
| 8 | `UDF1` | NUMBER | Y |  |  |
| 9 | `UDF2` | NUMBER | Y |  |  |
| 10 | `UDF3` | NUMBER | Y |  |  |
| 11 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 12 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 13 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 14 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 15 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 16 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_EQP_PK` UNIQUE (CLIENT, COMPANY, PLANT, EQP)

---

### TM_FAVORITE
**사용자즐겨찾기**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | N |  |  |
| 3 | `PLANT` | VARCHAR2(10) | N |  |  |
| 4 | `SYSCODE` | VARCHAR2(10) | N |  |  |
| 5 | `USERID` | VARCHAR2(10) | N |  |  |
| 6 | `DISPSEQ` | NUMBER | N |  |  |
| 7 | `MENUSEQ` | NUMBER(5) | N |  |  |
| 8 | `UDF1` | NUMBER | Y |  |  |
| 9 | `UDF2` | NUMBER | Y |  |  |
| 10 | `UDF3` | NUMBER | Y |  |  |
| 11 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 12 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 13 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 14 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 15 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 16 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

---

### TM_FORMS
**화면마스터**
  행수: 114

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `SYSCODE` | VARCHAR2(10) | N | PK |  |
| 5 | `FORM` | VARCHAR2(30) | N | PK |  |
| 6 | `FORMNAME` | VARCHAR2(50) | Y |  |  |
| 7 | `CAGEGORYHIGH` | VARCHAR2(5) | Y |  |  |
| 8 | `TYPE` | VARCHAR2(10) | Y |  |  |
| 9 | `FORMFUNCTION` | VARCHAR2(6) | Y |  |  |
| 10 | `UDF1` | NUMBER | Y |  |  |
| 11 | `UDF2` | NUMBER | Y |  |  |
| 12 | `UDF3` | NUMBER | Y |  |  |
| 13 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 14 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 15 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 16 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 17 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 18 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_FORMS_PK` UNIQUE (CLIENT, COMPANY, PLANT, SYSCODE, FORM)

---

### TM_GLOSSARY
**용어마스터**
  행수: 2,256

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `SYSCODE` | VARCHAR2(10) | N | PK |  |
| 2 | `GLSR` | VARCHAR2(4000) | N | PK |  |
| 3 | `KORGLSR` | VARCHAR2(4000) | Y |  |  |
| 4 | `ENGGLSR` | VARCHAR2(4000) | Y |  |  |
| 5 | `NATGLSR` | VARCHAR2(4000) | Y |  |  |
| 6 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 7 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 8 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 9 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 10 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 11 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_GLOSSARY_PK` UNIQUE (SYSCODE, GLSR)

---

### TM_GP12_ITEM
**GP12 품목**
  행수: 2

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `ITEMCODE` | NUMBER | N | PK |  |
| 5 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 6 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP, 'YYYYMMDDHH24MI... |
| 7 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 8 | `USEFLAG` | VARCHAR2(1) | N |  | 'Y' |

**인덱스:**

- `PK_TM_GP12_ITEM` UNIQUE (CLIENT, COMPANY, PLANT, ITEMCODE)

---

### TM_INVOICEDETAIL
**인보이스 상세**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | N |  |  |
| 3 | `PLANT` | VARCHAR2(5) | N |  |  |
| 4 | `POLCNO` | VARCHAR2(30) | N |  |  |
| 5 | `BALJPNO` | VARCHAR2(12) | N |  |  |
| 6 | `BALSEQ` | NUMBER(3) | N |  |  |
| 7 | `LCQTY` | NUMBER(14,3) | Y |  |  |
| 8 | `LCPRC` | NUMBER(19,6) | Y |  |  |
| 9 | `LCAMT` | NUMBER(13,2) | Y |  |  |
| 10 | `BLQTY` | NUMBER(14,3) | Y |  |  |
| 11 | `ENTQTY` | NUMBER(14,3) | Y |  |  |
| 12 | `LCBIPRC` | NUMBER(19,6) | Y |  |  |
| 13 | `LCBIAMT` | NUMBER(13,2) | Y |  |  |
| 14 | `LCGYAMT` | NUMBER(13,2) | Y |  |  |
| 15 | `SAUPJ` | VARCHAR2(6) | Y |  |  |
| 16 | `CRT_USER` | VARCHAR2(10) | Y |  |  |
| 17 | `CRT_DATE` | VARCHAR2(8) | Y |  |  |
| 18 | `CRT_TIME` | VARCHAR2(6) | Y |  |  |
| 19 | `UPD_USER` | VARCHAR2(10) | Y |  |  |
| 20 | `UPD_DATE` | VARCHAR2(8) | Y |  |  |
| 21 | `UPD_TIME` | VARCHAR2(6) | Y |  |  |
| 22 | `POCT_QTY` | NUMBER(14,3) | Y |  |  |
| 23 | `RMKS` | VARCHAR2(100) | Y |  |  |
| 24 | `POBLNO` | VARCHAR2(20) | Y |  |  |
| 25 | `POBSEQ` | NUMBER(3) | Y |  |  |
| 26 | `TRA_CVCOD` | VARCHAR2(13) | Y |  |  |
| 27 | `LABELPRINTFLAG` | VARCHAR2(1) | Y |  | 'N' |
| 28 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |

---

### TM_INVOICEMASTER
**인보이스 마스터**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | N |  |  |
| 3 | `PLANT` | VARCHAR2(5) | N |  |  |
| 4 | `POLCNO` | VARCHAR2(30) | N |  |  |
| 5 | `POLCNO2` | VARCHAR2(30) | Y |  |  |
| 6 | `POLCGU` | VARCHAR2(6) | Y |  |  |
| 7 | `OPEN_TYPE` | VARCHAR2(6) | Y |  |  |
| 8 | `POOPBK` | VARCHAR2(13) | Y |  |  |
| 9 | `POADBK` | VARCHAR2(30) | Y |  |  |
| 10 | `POSDAT` | VARCHAR2(8) | Y |  |  |
| 11 | `POEDAT` | VARCHAR2(8) | Y |  |  |
| 12 | `POBFCD` | VARCHAR2(40) | Y |  |  |
| 13 | `POLAMT` | NUMBER(13,2) | Y |  |  |
| 14 | `POCURR` | VARCHAR2(6) | Y |  |  |
| 15 | `POAPPO` | VARCHAR2(6) | Y |  |  |
| 16 | `POTERM` | VARCHAR2(6) | Y |  |  |
| 17 | `POMAGA` | VARCHAR2(1) | Y |  |  |
| 18 | `CVCOD` | VARCHAR2(13) | Y |  |  |
| 19 | `OPNDAT` | VARCHAR2(8) | Y |  |  |
| 20 | `LOCALYN` | VARCHAR2(1) | Y |  |  |
| 21 | `LRATE` | NUMBER(10,4) | Y |  |  |
| 22 | `USDRAT` | NUMBER(10,4) | Y |  |  |
| 23 | `BILAMT` | NUMBER(13,2) | Y |  |  |
| 24 | `JIGBN` | VARCHAR2(1) | Y |  |  |
| 25 | `BUBO_DATE` | VARCHAR2(8) | Y |  |  |
| 26 | `LCMADAT` | VARCHAR2(8) | Y |  |  |
| 27 | `REIPGO_YN` | VARCHAR2(1) | Y |  |  |
| 28 | `BOAMT` | NUMBER(13,2) | Y |  |  |
| 29 | `CRT_USER` | VARCHAR2(10) | Y |  |  |
| 30 | `CRT_DATE` | VARCHAR2(8) | Y |  |  |
| 31 | `CRT_TIME` | VARCHAR2(6) | Y |  |  |
| 32 | `UPD_USER` | VARCHAR2(10) | Y |  |  |
| 33 | `UPD_DATE` | VARCHAR2(8) | Y |  |  |
| 34 | `UPD_TIME` | VARCHAR2(6) | Y |  |  |
| 35 | `ITRADE_GBN` | VARCHAR2(3) | Y |  |  |
| 36 | `GBN` | VARCHAR2(1) | Y |  |  |
| 37 | `CONFIRM_DIV` | VARCHAR2(1) | Y |  | 'C' |
| 38 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |

---

### TM_ITEMS
**품목마스터**
  행수: 1,315

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `ITEMCODE` | NUMBER | N | PK |  |
| 5 | `ITEMNAME` | VARCHAR2(100) | N |  |  |
| 6 | `PARTNO` | VARCHAR2(30) | N |  |  |
| 7 | `CUSTPARTNO` | VARCHAR2(30) | Y |  |  |
| 8 | `SPEC` | VARCHAR2(4000) | Y |  |  |
| 9 | `REV` | VARCHAR2(5) | Y |  |  |
| 10 | `ROOTITEM` | NUMBER | Y |  |  |
| 11 | `ITEMTYPE` | VARCHAR2(30) | Y |  |  |
| 12 | `UNITCODE` | VARCHAR2(4) | Y |  |  |
| 13 | `VALIDFROMDATE` | VARCHAR2(8) | Y |  |  |
| 14 | `SAFTYQTY` | NUMBER | Y |  |  |
| 15 | `LOTUNITQTY` | NUMBER | Y |  |  |
| 16 | `BOXQTY` | NUMBER | Y |  | 0 |
| 17 | `UNITNO` | VARCHAR2(10) | Y |  |  |
| 18 | `IQCFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 19 | `CURRFLOWINSFLAG` | VARCHAR2(10) | Y |  |  |
| 20 | `TERMINALFLAG` | VARCHAR2(1) | Y |  | 'N' |
| 21 | `PRINTUNIT` | NUMBER | Y |  |  |
| 22 | `QTYOUTFLAG` | VARCHAR2(1) | Y |  | 'N' |
| 23 | `QTYPACKFLAG` | VARCHAR2(1) | Y |  | 'N' |
| 24 | `PRINTTYPE` | VARCHAR2(1) | Y |  |  |
| 25 | `TACTTIME` | NUMBER | Y |  |  |
| 26 | `LABELTEXT` | VARCHAR2(1) | Y |  |  |
| 27 | `PRODUCTTYPE` | VARCHAR2(8) | Y |  |  |
| 28 | `VISUALTACTTIME` | NUMBER | Y |  |  |
| 29 | `TOOL` | VARCHAR2(100) | Y |  |  |
| 30 | `PARTNOSIZE` | VARCHAR2(100) | Y |  |  |
| 31 | `PARTNOTYPE` | VARCHAR2(100) | Y |  |  |
| 32 | `IMAGE` | BLOB | Y |  |  |
| 33 | `IMAGE2` | BLOB | Y |  |  |
| 34 | `EXPIRYDATE` | NUMBER | Y |  |  |
| 35 | `ERPFLAG` | VARCHAR2(1) | Y |  |  |
| 36 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 37 | `LONGTERMDATE` | NUMBER | Y |  |  |
| 38 | `UDF2` | NUMBER | Y |  |  |
| 39 | `UDF3` | NUMBER | Y |  |  |
| 40 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 41 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 42 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 43 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 44 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_ITEMS_PK` UNIQUE (CLIENT, COMPANY, PLANT, ITEMCODE)

---

### TM_ITEMS_BAK
**품목마스터 백업**
  행수: 12

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | N |  |  |
| 3 | `PLANT` | VARCHAR2(10) | N |  |  |
| 4 | `ITEMCODE` | NUMBER | N |  |  |
| 5 | `ITEMNAME` | VARCHAR2(100) | N |  |  |
| 6 | `PARTNO` | VARCHAR2(30) | N |  |  |
| 7 | `CUSTPARTNO` | VARCHAR2(30) | Y |  |  |
| 8 | `SPEC` | VARCHAR2(4000) | Y |  |  |
| 9 | `REV` | VARCHAR2(5) | Y |  |  |
| 10 | `ROOTITEM` | NUMBER | Y |  |  |
| 11 | `ITEMTYPE` | VARCHAR2(30) | Y |  |  |
| 12 | `UNITCODE` | VARCHAR2(4) | Y |  |  |
| 13 | `VALIDFROMDATE` | VARCHAR2(8) | Y |  |  |
| 14 | `SAFTYQTY` | NUMBER | Y |  |  |
| 15 | `LOTUNITQTY` | NUMBER | Y |  |  |
| 16 | `BOXQTY` | NUMBER | Y |  |  |
| 17 | `UNITNO` | VARCHAR2(10) | Y |  |  |
| 18 | `IQCFLAG` | VARCHAR2(1) | Y |  |  |
| 19 | `CURRFLOWINSFLAG` | VARCHAR2(10) | Y |  |  |
| 20 | `TERMINALFLAG` | VARCHAR2(1) | Y |  |  |
| 21 | `PRINTUNIT` | NUMBER | Y |  |  |
| 22 | `QTYOUTFLAG` | VARCHAR2(1) | Y |  |  |
| 23 | `QTYPACKFLAG` | VARCHAR2(1) | Y |  |  |
| 24 | `PRINTTYPE` | VARCHAR2(1) | Y |  |  |
| 25 | `TACTTIME` | NUMBER | Y |  |  |
| 26 | `LABELTEXT` | VARCHAR2(1) | Y |  |  |
| 27 | `PRODUCTTYPE` | VARCHAR2(8) | Y |  |  |
| 28 | `VISUALTACTTIME` | NUMBER | Y |  |  |
| 29 | `UDF2` | NUMBER | Y |  |  |
| 30 | `ERPFLAG` | VARCHAR2(1) | Y |  |  |
| 31 | `USEFLAG` | VARCHAR2(1) | Y |  |  |
| 32 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 33 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 34 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 35 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 36 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |
| 37 | `IMAGE` | BLOB | Y |  |  |
| 38 | `IMAGE2` | BLOB | Y |  |  |
| 39 | `TOOL` | VARCHAR2(100) | Y |  |  |
| 40 | `PARTNOSIZE` | VARCHAR2(100) | Y |  |  |
| 41 | `PARTNOTYPE` | VARCHAR2(100) | Y |  |  |

---

### TM_LOCATION
**창고별위치마스터**
  행수: 10

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `WHLOC` | VARCHAR2(10) | N | PK |  |
| 5 | `WHLOCNAME` | VARCHAR2(100) | N |  |  |
| 6 | `WAREHOUSE` | VARCHAR2(10) | N |  |  |
| 7 | `PRODLINE` | VARCHAR2(10) | Y |  |  |
| 8 | `ERPLOCCODE` | VARCHAR2(50) | Y |  |  |
| 9 | `VENDOR` | VARCHAR2(10) | Y |  |  |
| 10 | `OQCWHLOC` | VARCHAR2(10) | Y |  |  |
| 11 | `LOCTYPE` | VARCHAR2(1) | Y |  | '1' |
| 12 | `PURCHASEFLAG` | VARCHAR2(1) | Y |  | 'N' |
| 13 | `BADWHFLAG` | VARCHAR2(1) | N |  | 'N' |
| 14 | `RETRIEVALFLAG` | VARCHAR2(1) | N |  | 'N' |
| 15 | `STOCKINSPFLAG` | VARCHAR2(1) | N |  | 'Y' |
| 16 | `SERIALDESTFLAG` | VARCHAR2(1) | N |  | 'N' |
| 17 | `REPAIRFLAG` | VARCHAR2(1) | N |  | 'N' |
| 18 | `OTHERINFLAG` | VARCHAR2(1) | N |  | 'N' |
| 19 | `PUBFLAG` | VARCHAR2(1) | N |  | 'N' |
| 20 | `FIFOFLAG` | VARCHAR2(1) | Y |  | 'N' |
| 21 | `UDF1` | NUMBER | Y |  | NULL |
| 22 | `UDF2` | NUMBER | Y |  |  |
| 23 | `UDF3` | NUMBER | Y |  |  |
| 24 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 25 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 26 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 27 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 28 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 29 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_LOCATION_PK` UNIQUE (CLIENT, COMPANY, PLANT, WHLOC)

---

### TM_LQC_REPORT_01
**LQC리포트01**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `WORKDATE` | VARCHAR2(8) | N | PK |  |
| 5 | `WORKTIME` | VARCHAR2(10) | N | PK |  |
| 6 | `UNITNO` | VARCHAR2(10) | N | PK |  |
| 7 | `BADRATE` | NUMBER | Y |  |  |
| 8 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 9 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_LQC_REPORT_01_PK` UNIQUE (CLIENT, COMPANY, PLANT, WORKDATE, WORKTIME, UNITNO)

---

### TM_LQC_REPORT_02
**LQC리포트02**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `SEQ` | VARCHAR2(3) | N | PK |  |
| 5 | `WORKDATE` | VARCHAR2(8) | N | PK |  |
| 6 | `WORKTIME` | VARCHAR2(3) | N | PK |  |
| 7 | `DEFECT` | VARCHAR2(10) | N | PK |  |
| 8 | `DEFECTNAME` | VARCHAR2(100) | N |  |  |
| 9 | `PPM` | NUMBER | Y |  |  |
| 10 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 11 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_LQC_REPORT_02_PK` UNIQUE (CLIENT, COMPANY, PLANT, SEQ, WORKDATE, WORKTIME, DEFECT)

---

### TM_LQC_REPORT_02_01
**LQC리포트02_01**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `SEQ` | VARCHAR2(3) | N | PK |  |
| 5 | `WORKDATE` | VARCHAR2(8) | N | PK |  |
| 6 | `REALDATE` | VARCHAR2(8) | N | PK |  |
| 7 | `DEFECT` | VARCHAR2(10) | N | PK |  |
| 8 | `DEFECTNAME` | VARCHAR2(100) | N |  |  |
| 9 | `PPM` | NUMBER | Y |  |  |
| 10 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 11 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_LQC_REPORT_02_01_PK` UNIQUE (CLIENT, COMPANY, PLANT, SEQ, WORKDATE, REALDATE, DEFECT)

---

### TM_LQC_REPORT_03
**LQC리포트03**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `SEQ` | VARCHAR2(3) | N |  |  |
| 5 | `WORKDATE` | VARCHAR2(8) | N | PK |  |
| 6 | `WORKTIME` | VARCHAR2(20) | N | PK |  |
| 7 | `PPM` | NUMBER | Y |  |  |
| 8 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 9 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_LQC_REPORT_03_PK` UNIQUE (CLIENT, COMPANY, PLANT, WORKDATE, WORKTIME)

---

### TM_MAT_BALANCE_TEMP
**자재 잔량 임시**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `PLANDATE` | VARCHAR2(8) | N | PK |  |
| 5 | `UPRITEM` | NUMBER | N | PK |  |
| 6 | `ITEMCODE` | NUMBER | N | PK |  |
| 7 | `WIP_QTY1` | NUMBER | Y |  |  |
| 8 | `WIP_QTY2` | NUMBER | Y |  |  |
| 9 | `WIP_QTY3` | NUMBER | Y |  |  |
| 10 | `WIP_QTY4` | NUMBER | Y |  |  |
| 11 | `WIP_QTY5` | NUMBER | Y |  |  |
| 12 | `WIP_QTY6` | NUMBER | Y |  |  |
| 13 | `WIP_QTY7` | NUMBER | Y |  |  |
| 14 | `WIP_QTY8` | NUMBER | Y |  |  |
| 15 | `WIP_QTY9` | NUMBER | Y |  |  |
| 16 | `WIP_QTY10` | NUMBER | Y |  |  |
| 17 | `WIP_QTY11` | NUMBER | Y |  |  |
| 18 | `WIP_QTY12` | NUMBER | Y |  |  |
| 19 | `WIP_QTY13` | NUMBER | Y |  |  |
| 20 | `WIP_QTY14` | NUMBER | Y |  |  |
| 21 | `WIP_QTY15` | NUMBER | Y |  |  |
| 22 | `WIP_QTY16` | NUMBER | Y |  |  |
| 23 | `WIP_QTY17` | NUMBER | Y |  |  |
| 24 | `WIP_QTY18` | NUMBER | Y |  |  |
| 25 | `WIP_QTY19` | NUMBER | Y |  |  |
| 26 | `WIP_QTY20` | NUMBER | Y |  |  |
| 27 | `WIP_QTY21` | NUMBER | Y |  |  |
| 28 | `WIP_QTY22` | NUMBER | Y |  |  |
| 29 | `WIP_QTY23` | NUMBER | Y |  |  |
| 30 | `WIP_QTY24` | NUMBER | Y |  |  |
| 31 | `WIP_QTY25` | NUMBER | Y |  |  |
| 32 | `WIP_QTY26` | NUMBER | Y |  |  |
| 33 | `WIP_QTY27` | NUMBER | Y |  |  |
| 34 | `WIP_QTY28` | NUMBER | Y |  |  |
| 35 | `WIP_QTY29` | NUMBER | Y |  |  |
| 36 | `WIP_QTY30` | NUMBER | Y |  |  |
| 37 | `WIP_QTY31` | NUMBER | Y |  |  |
| 38 | `WIP_QTY32` | NUMBER | Y |  |  |
| 39 | `WIP_QTY33` | NUMBER | Y |  |  |
| 40 | `WIP_QTY34` | NUMBER | Y |  |  |
| 41 | `WIP_QTY35` | NUMBER | Y |  |  |
| 42 | `WIP_QTY36` | NUMBER | Y |  |  |
| 43 | `WIP_QTY37` | NUMBER | Y |  |  |
| 44 | `WIP_QTY38` | NUMBER | Y |  |  |
| 45 | `WIP_QTY39` | NUMBER | Y |  |  |
| 46 | `WIP_QTY40` | NUMBER | Y |  |  |
| 47 | `WIP_QTY41` | NUMBER | Y |  |  |
| 48 | `WIP_QTY42` | NUMBER | Y |  |  |
| 49 | `WIP_QTY43` | NUMBER | Y |  |  |
| 50 | `WIP_QTY44` | NUMBER | Y |  |  |
| 51 | `WIP_QTY45` | NUMBER | Y |  |  |
| 52 | `WIP_QTY46` | NUMBER | Y |  |  |
| 53 | `WIP_QTY47` | NUMBER | Y |  |  |
| 54 | `WIP_QTY48` | NUMBER | Y |  |  |
| 55 | `WIP_QTY49` | NUMBER | Y |  |  |
| 56 | `WIP_QTY50` | NUMBER | Y |  |  |
| 57 | `WIP_QTY51` | NUMBER | Y |  |  |
| 58 | `WIP_QTY52` | NUMBER | Y |  |  |
| 59 | `WIP_QTY53` | NUMBER | Y |  |  |
| 60 | `WIP_QTY54` | NUMBER | Y |  |  |
| 61 | `WIP_QTY55` | NUMBER | Y |  |  |
| 62 | `WIP_QTY56` | NUMBER | Y |  |  |
| 63 | `WIP_QTY57` | NUMBER | Y |  |  |
| 64 | `WIP_QTY58` | NUMBER | Y |  |  |
| 65 | `WIP_QTY59` | NUMBER | Y |  |  |
| 66 | `WIP_QTY60` | NUMBER | Y |  |  |
| 67 | `WIP_QTY61` | NUMBER | Y |  |  |
| 68 | `WIP_QTY62` | NUMBER | Y |  |  |
| 69 | `BAL_QTY1` | NUMBER | Y |  |  |
| 70 | `BAL_QTY2` | NUMBER | Y |  |  |
| 71 | `BAL_QTY3` | NUMBER | Y |  |  |
| 72 | `BAL_QTY4` | NUMBER | Y |  |  |
| 73 | `BAL_QTY5` | NUMBER | Y |  |  |
| 74 | `BAL_QTY6` | NUMBER | Y |  |  |
| 75 | `BAL_QTY7` | NUMBER | Y |  |  |
| 76 | `BAL_QTY8` | NUMBER | Y |  |  |
| 77 | `BAL_QTY9` | NUMBER | Y |  |  |
| 78 | `BAL_QTY10` | NUMBER | Y |  |  |
| 79 | `BAL_QTY11` | NUMBER | Y |  |  |
| 80 | `BAL_QTY12` | NUMBER | Y |  |  |
| 81 | `BAL_QTY13` | NUMBER | Y |  |  |
| 82 | `BAL_QTY14` | NUMBER | Y |  |  |
| 83 | `BAL_QTY15` | NUMBER | Y |  |  |
| 84 | `BAL_QTY16` | NUMBER | Y |  |  |
| 85 | `BAL_QTY17` | NUMBER | Y |  |  |
| 86 | `BAL_QTY18` | NUMBER | Y |  |  |
| 87 | `BAL_QTY19` | NUMBER | Y |  |  |
| 88 | `BAL_QTY20` | NUMBER | Y |  |  |
| 89 | `BAL_QTY21` | NUMBER | Y |  |  |
| 90 | `BAL_QTY22` | NUMBER | Y |  |  |
| 91 | `BAL_QTY23` | NUMBER | Y |  |  |
| 92 | `BAL_QTY24` | NUMBER | Y |  |  |
| 93 | `BAL_QTY25` | NUMBER | Y |  |  |
| 94 | `BAL_QTY26` | NUMBER | Y |  |  |
| 95 | `BAL_QTY27` | NUMBER | Y |  |  |
| 96 | `BAL_QTY28` | NUMBER | Y |  |  |
| 97 | `BAL_QTY29` | NUMBER | Y |  |  |
| 98 | `BAL_QTY30` | NUMBER | Y |  |  |
| 99 | `BAL_QTY31` | NUMBER | Y |  |  |
| 100 | `BAL_QTY32` | NUMBER | Y |  |  |
| 101 | `BAL_QTY33` | NUMBER | Y |  |  |
| 102 | `BAL_QTY34` | NUMBER | Y |  |  |
| 103 | `BAL_QTY35` | NUMBER | Y |  |  |
| 104 | `BAL_QTY36` | NUMBER | Y |  |  |
| 105 | `BAL_QTY37` | NUMBER | Y |  |  |
| 106 | `BAL_QTY38` | NUMBER | Y |  |  |
| 107 | `BAL_QTY39` | NUMBER | Y |  |  |
| 108 | `BAL_QTY40` | NUMBER | Y |  |  |
| 109 | `BAL_QTY41` | NUMBER | Y |  |  |
| 110 | `BAL_QTY42` | NUMBER | Y |  |  |
| 111 | `BAL_QTY43` | NUMBER | Y |  |  |
| 112 | `BAL_QTY44` | NUMBER | Y |  |  |
| 113 | `BAL_QTY45` | NUMBER | Y |  |  |
| 114 | `BAL_QTY46` | NUMBER | Y |  |  |
| 115 | `BAL_QTY47` | NUMBER | Y |  |  |
| 116 | `BAL_QTY48` | NUMBER | Y |  |  |
| 117 | `BAL_QTY49` | NUMBER | Y |  |  |
| 118 | `BAL_QTY50` | NUMBER | Y |  |  |
| 119 | `BAL_QTY51` | NUMBER | Y |  |  |
| 120 | `BAL_QTY52` | NUMBER | Y |  |  |
| 121 | `BAL_QTY53` | NUMBER | Y |  |  |
| 122 | `BAL_QTY54` | NUMBER | Y |  |  |
| 123 | `BAL_QTY55` | NUMBER | Y |  |  |
| 124 | `BAL_QTY56` | NUMBER | Y |  |  |
| 125 | `BAL_QTY57` | NUMBER | Y |  |  |
| 126 | `BAL_QTY58` | NUMBER | Y |  |  |
| 127 | `BAL_QTY59` | NUMBER | Y |  |  |
| 128 | `BAL_QTY60` | NUMBER | Y |  |  |
| 129 | `BAL_QTY61` | NUMBER | Y |  |  |
| 130 | `BAL_QTY62` | NUMBER | Y |  |  |
| 131 | `CREATETIMEKEY` | VARCHAR2(20) | N |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 132 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 133 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 134 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_MAT_BALANCE_TEMP_PK` UNIQUE (CLIENT, COMPANY, PLANT, PLANDATE, UPRITEM, ITEMCODE)

---

### TM_MENU
**메뉴마스터**
  행수: 134

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | N |  |  |
| 3 | `PLANT` | VARCHAR2(10) | N |  |  |
| 4 | `SYSCODE` | VARCHAR2(10) | Y |  |  |
| 5 | `MENUSEQ` | NUMBER(5) | Y |  |  |
| 6 | `UPRSEQ` | NUMBER(5) | Y |  |  |
| 7 | `MENUNAME` | VARCHAR2(50) | Y |  |  |
| 8 | `FORM` | VARCHAR2(30) | Y |  |  |
| 9 | `FORMPARAM` | VARCHAR2(50) | Y |  |  |
| 10 | `IMGIDX` | NUMBER | Y |  |  |
| 11 | `DISPSEQ` | NUMBER | Y |  |  |
| 12 | `DISPFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 13 | `LOCKFLAG` | VARCHAR2(1) | Y |  | 'N' |
| 14 | `LASTUSER` | VARCHAR2(30) | Y |  |  |
| 15 | `UDF1` | NUMBER | Y |  |  |
| 16 | `UDF2` | NUMBER | Y |  |  |
| 17 | `UDF3` | NUMBER | Y |  |  |
| 18 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 19 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 20 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 21 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 22 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 23 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

---

### TM_MENUROLE
**사용자권한별메뉴마스터**
  행수: 468

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | N |  |  |
| 3 | `PLANT` | VARCHAR2(10) | N |  |  |
| 4 | `SYSCODE` | VARCHAR2(10) | Y |  |  |
| 5 | `USERROLE` | VARCHAR2(10) | Y |  |  |
| 6 | `MENUSEQ` | NUMBER(5) | Y |  |  |
| 7 | `FORMROLE` | VARCHAR2(3) | Y |  |  |
| 8 | `UDF1` | NUMBER | Y |  |  |
| 9 | `UDF2` | NUMBER | Y |  |  |
| 10 | `UDF3` | NUMBER | Y |  |  |
| 11 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 12 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 13 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 14 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 15 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 16 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

---

### TM_MODELBOM
**MODELBOM**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `MODEL` | VARCHAR2(30) | N | PK |  |
| 5 | `SEQ` | NUMBER | N | PK |  |
| 6 | `PARTNO` | VARCHAR2(30) | N | PK |  |
| 7 | `ASSYUSAGE` | NUMBER | N |  |  |
| 8 | `ASSYRATE` | NUMBER | Y |  | 0 |
| 9 | `VENDOR` | VARCHAR2(30) | N | PK |  |
| 10 | `WHLOC` | VARCHAR2(10) | N |  |  |
| 11 | `UDF1` | NUMBER | Y |  |  |
| 12 | `UDF2` | NUMBER | Y |  |  |
| 13 | `UDF3` | NUMBER | Y |  |  |
| 14 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 15 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 16 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 17 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 18 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 19 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_MODELBOM_PK` UNIQUE (CLIENT, COMPANY, PLANT, MODEL, SEQ, PARTNO, VENDOR)

---

### TM_NOTICE
**공지마스터**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | N |  |  |
| 3 | `PLANT` | VARCHAR2(10) | N |  |  |
| 4 | `SYSCODE` | VARCHAR2(10) | N |  |  |
| 5 | `TYPE` | VARCHAR2(1) | N |  |  |
| 6 | `NO` | NUMBER | N |  |  |
| 7 | `TITLE` | VARCHAR2(100) | N |  |  |
| 8 | `CONTENTS` | VARCHAR2(4000) | Y |  |  |
| 9 | `UDF1` | NUMBER | Y |  |  |
| 10 | `UDF2` | NUMBER | Y |  |  |
| 11 | `UDF3` | NUMBER | Y |  |  |
| 12 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 13 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 14 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 15 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 16 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 17 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

---

### TM_OPERATION
**공정마스터**
  행수: 11

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `OPER` | VARCHAR2(6) | N | PK |  |
| 5 | `OPERNAME` | VARCHAR2(50) | N |  |  |
| 6 | `OPERCODE` | VARCHAR2(30) | Y |  |  |
| 7 | `OPERTYPE` | NUMBER | Y |  |  |
| 8 | `PERMISSIONRATE` | NUMBER | Y |  |  |
| 9 | `PRECEDE` | NUMBER | Y |  |  |
| 10 | `UDF1` | NUMBER | Y |  |  |
| 11 | `UDF2` | NUMBER | Y |  |  |
| 12 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 13 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 14 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 15 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 16 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 17 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_OPERATION_PK` UNIQUE (CLIENT, COMPANY, PLANT, OPER)

---

### TM_ORDERDETAIL
**주문 상세**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | N |  |  |
| 3 | `PLANT` | VARCHAR2(5) | N |  |  |
| 4 | `BALJPNO` | VARCHAR2(12) | N |  |  |
| 5 | `BALSEQ` | NUMBER(3) | N |  |  |
| 6 | `ITNBR` | VARCHAR2(20) | Y |  |  |
| 7 | `PSPEC` | VARCHAR2(200) | Y |  |  |
| 8 | `OPSEQ` | VARCHAR2(4) | Y |  |  |
| 9 | `GUDAT` | VARCHAR2(8) | Y |  |  |
| 10 | `NADAT` | VARCHAR2(8) | Y |  |  |
| 11 | `BALQTY` | NUMBER(14,3) | Y |  |  |
| 12 | `RCQTY` | NUMBER(14,3) | Y |  |  |
| 13 | `BFAQTY` | NUMBER(14,3) | Y |  |  |
| 14 | `BPEQTY` | NUMBER(14,3) | Y |  |  |
| 15 | `BTEQTY` | NUMBER(14,3) | Y |  |  |
| 16 | `BJOQTY` | NUMBER(14,3) | Y |  |  |
| 17 | `BCUQTY` | NUMBER(14,3) | Y |  |  |
| 18 | `LCOQTY` | NUMBER(14,3) | Y |  |  |
| 19 | `BLQTY` | NUMBER(14,3) | Y |  |  |
| 20 | `ENTQTY` | NUMBER(14,3) | Y |  |  |
| 21 | `LCBIPRC` | NUMBER(13,2) | Y |  |  |
| 22 | `LCBIAMT` | NUMBER(15,2) | Y |  |  |
| 23 | `ORDER_NO` | VARCHAR2(20) | Y |  |  |
| 24 | `BALSTS` | VARCHAR2(1) | Y |  |  |
| 25 | `ESTNO` | VARCHAR2(16) | Y |  |  |
| 26 | `TUNCU` | VARCHAR2(6) | Y |  |  |
| 27 | `UNPRC` | NUMBER(17,6) | Y |  |  |
| 28 | `UNAMT` | NUMBER(17,6) | Y |  |  |
| 29 | `BQCQTYT` | NUMBER(14,3) | Y |  |  |
| 30 | `BIPWQTY` | NUMBER(14,3) | Y |  |  |
| 31 | `PORDNO` | VARCHAR2(16) | Y |  |  |
| 32 | `CRT_DATE` | VARCHAR2(8) | Y |  |  |
| 33 | `CRT_TIME` | VARCHAR2(6) | Y |  |  |
| 34 | `CRT_USER` | VARCHAR2(30) | Y |  |  |
| 35 | `UPD_DATE` | VARCHAR2(8) | Y |  |  |
| 36 | `UPD_TIME` | VARCHAR2(6) | Y |  |  |
| 37 | `UPD_USER` | VARCHAR2(30) | Y |  |  |
| 38 | `CNVBLQ` | NUMBER(13,2) | Y |  |  |
| 39 | `CNVENT` | NUMBER(14,3) | Y |  |  |
| 40 | `ACCOD` | VARCHAR2(7) | Y |  |  |
| 41 | `PROJECT_NO` | VARCHAR2(20) | Y |  |  |
| 42 | `SAUPJ` | VARCHAR2(6) | Y |  |  |
| 43 | `SEQNO` | NUMBER(1) | Y |  |  |
| 44 | `WBALQTY` | NUMBER(14,3) | Y |  |  |
| 45 | `IPDPT` | VARCHAR2(13) | Y |  |  |
| 46 | `BIGO` | VARCHAR2(100) | Y |  |  |
| 47 | `POCT_QTY` | NUMBER(14,3) | Y |  |  |
| 48 | `LABELPRINTFLAG` | VARCHAR2(1) | Y |  | 'N' |
| 49 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |

---

### TM_ORDERMASTER
**주문 마스터**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | N |  |  |
| 3 | `PLANT` | VARCHAR2(5) | N |  |  |
| 4 | `BALJPNO` | VARCHAR2(12) | N |  |  |
| 5 | `CVCOD` | VARCHAR2(13) | N |  |  |
| 6 | `BALGU` | VARCHAR2(6) | Y |  |  |
| 7 | `BALDATE` | VARCHAR2(8) | Y |  |  |
| 8 | `BAL_EMPNO` | VARCHAR2(30) | Y |  |  |
| 9 | `BAL_SUIP` | VARCHAR2(1) | Y |  |  |
| 10 | `SILGBN` | VARCHAR2(1) | Y |  |  |
| 11 | `PLNCRT` | VARCHAR2(1) | Y |  |  |
| 12 | `BGUBUN` | VARCHAR2(1) | Y |  |  |
| 13 | `PLNOPN` | VARCHAR2(8) | Y |  |  |
| 14 | `PLNAPP` | VARCHAR2(20) | Y |  |  |
| 15 | `PLNBNK` | VARCHAR2(13) | Y |  |  |
| 16 | `LOCALYN` | VARCHAR2(1) | Y |  |  |
| 17 | `PLNYMD` | VARCHAR2(8) | Y |  |  |
| 18 | `BIGO` | VARCHAR2(100) | Y |  |  |
| 19 | `WAIGBN` | VARCHAR2(3) | Y |  |  |
| 20 | `PRINTGU` | VARCHAR2(1) | Y |  |  |
| 21 | `SAGGUB` | VARCHAR2(3) | Y |  |  |
| 22 | `IQCFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 23 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |

---

### TM_PLANT
**공장마스터**
  행수: 1

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `PLANTNAME` | VARCHAR2(50) | N |  |  |
| 5 | `PLANTTYPE` | VARCHAR2(30) | Y |  |  |
| 6 | `UDF1` | NUMBER | Y |  |  |
| 7 | `UDF2` | NUMBER | Y |  |  |
| 8 | `UDF3` | NUMBER | Y |  |  |
| 9 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 10 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 11 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 12 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 13 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 14 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_PLANT_PK` UNIQUE (CLIENT, COMPANY, PLANT)

---

### TM_POSITION
**직위마스터**
  행수: 17

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `POSITION` | VARCHAR2(2) | N | PK |  |
| 5 | `POSITIONNAME` | VARCHAR2(30) | N |  |  |
| 6 | `UDF1` | NUMBER | Y |  |  |
| 7 | `UDF2` | NUMBER | Y |  |  |
| 8 | `UDF3` | NUMBER | Y |  |  |
| 9 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 10 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 11 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 12 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 13 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 14 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_POSITION_PK` UNIQUE (CLIENT, COMPANY, PLANT, POSITION)

---

### TM_PRODLINE
**생산라인마스터**
  행수: 10

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `PRODLINE` | VARCHAR2(10) | N | PK |  |
| 5 | `PRODLINENAME` | VARCHAR2(50) | N |  |  |
| 6 | `WHLOC` | VARCHAR2(10) | N |  |  |
| 7 | `ERPCODE` | VARCHAR2(10) | Y |  |  |
| 8 | `OPER` | VARCHAR2(6) | Y |  |  |
| 9 | `TYPE` | VARCHAR2(20) | Y |  |  |
| 10 | `UDF1` | NUMBER | Y |  |  |
| 11 | `UDF2` | NUMBER | Y |  |  |
| 12 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 13 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 14 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 15 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 16 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 17 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_PRODLINE_PK` UNIQUE (CLIENT, COMPANY, PLANT, PRODLINE)

---

### TM_PRODLINE_UNIT
**생산라인설비호기마스터**
  행수: 38

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `UNITNO` | VARCHAR2(10) | N | PK |  |
| 5 | `UNITNM` | VARCHAR2(20) | N |  |  |
| 6 | `UNITTYPE` | VARCHAR2(1) | N |  | 'N' |
| 7 | `PRODLINE` | VARCHAR2(10) | Y |  |  |
| 8 | `PATH` | VARCHAR2(200) | Y |  |  |
| 9 | `BACKPATH` | VARCHAR2(200) | Y |  |  |
| 10 | `UDF1` | NUMBER | Y |  |  |
| 11 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 12 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 13 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 14 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 15 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 16 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_PRODLINE_UNIT_PK` UNIQUE (CLIENT, COMPANY, PLANT, UNITNO)

---

### TM_PRODPLAN
**생산 계획**
  행수: 101

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `PLANDATE` | VARCHAR2(8) | N | PK |  |
| 5 | `SEQ` | VARCHAR2(3) | N | PK |  |
| 6 | `ITEMCODE` | NUMBER | N | PK |  |
| 7 | `QTYSUM` | NUMBER | Y |  |  |
| 8 | `QTY1` | NUMBER | Y |  |  |
| 9 | `QTY2` | NUMBER | Y |  |  |
| 10 | `QTY3` | NUMBER | Y |  |  |
| 11 | `QTY4` | NUMBER | Y |  |  |
| 12 | `QTY5` | NUMBER | Y |  |  |
| 13 | `QTY6` | NUMBER | Y |  |  |
| 14 | `QTY7` | NUMBER | Y |  |  |
| 15 | `QTY8` | NUMBER | Y |  |  |
| 16 | `QTY9` | NUMBER | Y |  |  |
| 17 | `QTY10` | NUMBER | Y |  |  |
| 18 | `QTY11` | NUMBER | Y |  |  |
| 19 | `QTY12` | NUMBER | Y |  |  |
| 20 | `QTY13` | NUMBER | Y |  |  |
| 21 | `QTY14` | NUMBER | Y |  |  |
| 22 | `QTY15` | NUMBER | Y |  |  |
| 23 | `QTY16` | NUMBER | Y |  |  |
| 24 | `QTY17` | NUMBER | Y |  |  |
| 25 | `QTY18` | NUMBER | Y |  |  |
| 26 | `QTY19` | NUMBER | Y |  |  |
| 27 | `QTY20` | NUMBER | Y |  |  |
| 28 | `QTY21` | NUMBER | Y |  |  |
| 29 | `QTY22` | NUMBER | Y |  |  |
| 30 | `QTY23` | NUMBER | Y |  |  |
| 31 | `QTY24` | NUMBER | Y |  |  |
| 32 | `QTY25` | NUMBER | Y |  |  |
| 33 | `QTY26` | NUMBER | Y |  |  |
| 34 | `QTY27` | NUMBER | Y |  |  |
| 35 | `QTY28` | NUMBER | Y |  |  |
| 36 | `QTY29` | NUMBER | Y |  |  |
| 37 | `QTY30` | NUMBER | Y |  |  |
| 38 | `QTY31` | NUMBER | Y |  |  |
| 39 | `QTY32` | NUMBER | Y |  |  |
| 40 | `QTY33` | NUMBER | Y |  |  |
| 41 | `QTY34` | NUMBER | Y |  |  |
| 42 | `QTY35` | NUMBER | Y |  |  |
| 43 | `QTY36` | NUMBER | Y |  |  |
| 44 | `QTY37` | NUMBER | Y |  |  |
| 45 | `QTY38` | NUMBER | Y |  |  |
| 46 | `QTY39` | NUMBER | Y |  |  |
| 47 | `QTY40` | NUMBER | Y |  |  |
| 48 | `QTY41` | NUMBER | Y |  |  |
| 49 | `QTY42` | NUMBER | Y |  |  |
| 50 | `QTY43` | NUMBER | Y |  |  |
| 51 | `QTY44` | NUMBER | Y |  |  |
| 52 | `QTY45` | NUMBER | Y |  |  |
| 53 | `QTY46` | NUMBER | Y |  |  |
| 54 | `QTY47` | NUMBER | Y |  |  |
| 55 | `QTY48` | NUMBER | Y |  |  |
| 56 | `QTY49` | NUMBER | Y |  |  |
| 57 | `QTY50` | NUMBER | Y |  |  |
| 58 | `QTY51` | NUMBER | Y |  |  |
| 59 | `QTY52` | NUMBER | Y |  |  |
| 60 | `QTY53` | NUMBER | Y |  |  |
| 61 | `QTY54` | NUMBER | Y |  |  |
| 62 | `QTY55` | NUMBER | Y |  |  |
| 63 | `QTY56` | NUMBER | Y |  |  |
| 64 | `QTY57` | NUMBER | Y |  |  |
| 65 | `QTY58` | NUMBER | Y |  |  |
| 66 | `QTY59` | NUMBER | Y |  |  |
| 67 | `QTY60` | NUMBER | Y |  |  |
| 68 | `QTY61` | NUMBER | Y |  |  |
| 69 | `QTY62` | NUMBER | Y |  |  |
| 70 | `QTY63` | NUMBER | Y |  |  |
| 71 | `QTY64` | NUMBER | Y |  |  |
| 72 | `QTY65` | NUMBER | Y |  |  |
| 73 | `QTY66` | NUMBER | Y |  |  |
| 74 | `QTY67` | NUMBER | Y |  |  |
| 75 | `QTY68` | NUMBER | Y |  |  |
| 76 | `QTY69` | NUMBER | Y |  |  |
| 77 | `QTY70` | NUMBER | Y |  |  |
| 78 | `QTY71` | NUMBER | Y |  |  |
| 79 | `QTY72` | NUMBER | Y |  |  |
| 80 | `QTY73` | NUMBER | Y |  |  |
| 81 | `QTY74` | NUMBER | Y |  |  |
| 82 | `QTY75` | NUMBER | Y |  |  |
| 83 | `QTY76` | NUMBER | Y |  |  |
| 84 | `QTY77` | NUMBER | Y |  |  |
| 85 | `QTY78` | NUMBER | Y |  |  |
| 86 | `QTY79` | NUMBER | Y |  |  |
| 87 | `QTY80` | NUMBER | Y |  |  |
| 88 | `QTY81` | NUMBER | Y |  |  |
| 89 | `QTY82` | NUMBER | Y |  |  |
| 90 | `QTY83` | NUMBER | Y |  |  |
| 91 | `QTY84` | NUMBER | Y |  |  |
| 92 | `QTY85` | NUMBER | Y |  |  |
| 93 | `QTY86` | NUMBER | Y |  |  |
| 94 | `QTY87` | NUMBER | Y |  |  |
| 95 | `QTY88` | NUMBER | Y |  |  |
| 96 | `QTY89` | NUMBER | Y |  |  |
| 97 | `QTY90` | NUMBER | Y |  |  |
| 98 | `QTY91` | NUMBER | Y |  |  |
| 99 | `QTY92` | NUMBER | Y |  |  |
| 100 | `CREATETIMEKEY` | VARCHAR2(20) | N |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 101 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 102 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 103 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_PRODPLAN_PK` UNIQUE (CLIENT, COMPANY, PLANT, PLANDATE, SEQ, ITEMCODE)

---

### TM_PRODPLAN_MONTH
**월별 생산 계획**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `PLANDATE` | VARCHAR2(8) | N | PK |  |
| 5 | `SEQ` | VARCHAR2(3) | N | PK |  |
| 6 | `ITEMCODE` | NUMBER | N | PK |  |
| 7 | `QTYSUM` | NUMBER | Y |  |  |
| 8 | `QTY1` | NUMBER | Y |  |  |
| 9 | `QTY2` | NUMBER | Y |  |  |
| 10 | `QTY3` | NUMBER | Y |  |  |
| 11 | `QTY4` | NUMBER | Y |  |  |
| 12 | `QTY5` | NUMBER | Y |  |  |
| 13 | `QTY6` | NUMBER | Y |  |  |
| 14 | `QTY7` | NUMBER | Y |  |  |
| 15 | `QTY8` | NUMBER | Y |  |  |
| 16 | `QTY9` | NUMBER | Y |  |  |
| 17 | `QTY10` | NUMBER | Y |  |  |
| 18 | `QTY11` | NUMBER | Y |  |  |
| 19 | `QTY12` | NUMBER | Y |  |  |
| 20 | `QTY13` | NUMBER | Y |  |  |
| 21 | `QTY14` | NUMBER | Y |  |  |
| 22 | `QTY15` | NUMBER | Y |  |  |
| 23 | `QTY16` | NUMBER | Y |  |  |
| 24 | `QTY17` | NUMBER | Y |  |  |
| 25 | `QTY18` | NUMBER | Y |  |  |
| 26 | `QTY19` | NUMBER | Y |  |  |
| 27 | `QTY20` | NUMBER | Y |  |  |
| 28 | `QTY21` | NUMBER | Y |  |  |
| 29 | `QTY22` | NUMBER | Y |  |  |
| 30 | `QTY23` | NUMBER | Y |  |  |
| 31 | `QTY24` | NUMBER | Y |  |  |
| 32 | `QTY25` | NUMBER | Y |  |  |
| 33 | `QTY26` | NUMBER | Y |  |  |
| 34 | `QTY27` | NUMBER | Y |  |  |
| 35 | `QTY28` | NUMBER | Y |  |  |
| 36 | `QTY29` | NUMBER | Y |  |  |
| 37 | `QTY30` | NUMBER | Y |  |  |
| 38 | `QTY31` | NUMBER | Y |  |  |
| 39 | `QTY32` | NUMBER | Y |  |  |
| 40 | `QTY33` | NUMBER | Y |  |  |
| 41 | `QTY34` | NUMBER | Y |  |  |
| 42 | `QTY35` | NUMBER | Y |  |  |
| 43 | `QTY36` | NUMBER | Y |  |  |
| 44 | `QTY37` | NUMBER | Y |  |  |
| 45 | `QTY38` | NUMBER | Y |  |  |
| 46 | `QTY39` | NUMBER | Y |  |  |
| 47 | `QTY40` | NUMBER | Y |  |  |
| 48 | `QTY41` | NUMBER | Y |  |  |
| 49 | `QTY42` | NUMBER | Y |  |  |
| 50 | `QTY43` | NUMBER | Y |  |  |
| 51 | `QTY44` | NUMBER | Y |  |  |
| 52 | `QTY45` | NUMBER | Y |  |  |
| 53 | `QTY46` | NUMBER | Y |  |  |
| 54 | `QTY47` | NUMBER | Y |  |  |
| 55 | `QTY48` | NUMBER | Y |  |  |
| 56 | `QTY49` | NUMBER | Y |  |  |
| 57 | `QTY50` | NUMBER | Y |  |  |
| 58 | `QTY51` | NUMBER | Y |  |  |
| 59 | `QTY52` | NUMBER | Y |  |  |
| 60 | `QTY53` | NUMBER | Y |  |  |
| 61 | `QTY54` | NUMBER | Y |  |  |
| 62 | `QTY55` | NUMBER | Y |  |  |
| 63 | `QTY56` | NUMBER | Y |  |  |
| 64 | `QTY57` | NUMBER | Y |  |  |
| 65 | `QTY58` | NUMBER | Y |  |  |
| 66 | `QTY59` | NUMBER | Y |  |  |
| 67 | `QTY60` | NUMBER | Y |  |  |
| 68 | `QTY61` | NUMBER | Y |  |  |
| 69 | `QTY62` | NUMBER | Y |  |  |
| 70 | `CREATETIMEKEY` | VARCHAR2(20) | N |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 71 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 72 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 73 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_PRODPLAN_MONTH_PK` UNIQUE (CLIENT, COMPANY, PLANT, PLANDATE, SEQ, ITEMCODE)

---

### TM_PRODPLAN_MONTH_BALANCE
**월별 생산 계획 잔량**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `PLANDATE` | VARCHAR2(8) | N | PK |  |
| 5 | `SEQ` | VARCHAR2(3) | N | PK |  |
| 6 | `UPRITEM` | NUMBER | N | PK |  |
| 7 | `ITEMCODE` | NUMBER | N | PK |  |
| 8 | `QTY1` | NUMBER | Y |  |  |
| 9 | `QTY2` | NUMBER | Y |  |  |
| 10 | `QTY3` | NUMBER | Y |  |  |
| 11 | `QTY4` | NUMBER | Y |  |  |
| 12 | `QTY5` | NUMBER | Y |  |  |
| 13 | `QTY6` | NUMBER | Y |  |  |
| 14 | `QTY7` | NUMBER | Y |  |  |
| 15 | `QTY8` | NUMBER | Y |  |  |
| 16 | `QTY9` | NUMBER | Y |  |  |
| 17 | `QTY10` | NUMBER | Y |  |  |
| 18 | `QTY11` | NUMBER | Y |  |  |
| 19 | `QTY12` | NUMBER | Y |  |  |
| 20 | `QTY13` | NUMBER | Y |  |  |
| 21 | `QTY14` | NUMBER | Y |  |  |
| 22 | `QTY15` | NUMBER | Y |  |  |
| 23 | `QTY16` | NUMBER | Y |  |  |
| 24 | `QTY17` | NUMBER | Y |  |  |
| 25 | `QTY18` | NUMBER | Y |  |  |
| 26 | `QTY19` | NUMBER | Y |  |  |
| 27 | `QTY20` | NUMBER | Y |  |  |
| 28 | `QTY21` | NUMBER | Y |  |  |
| 29 | `QTY22` | NUMBER | Y |  |  |
| 30 | `QTY23` | NUMBER | Y |  |  |
| 31 | `QTY24` | NUMBER | Y |  |  |
| 32 | `QTY25` | NUMBER | Y |  |  |
| 33 | `QTY26` | NUMBER | Y |  |  |
| 34 | `QTY27` | NUMBER | Y |  |  |
| 35 | `QTY28` | NUMBER | Y |  |  |
| 36 | `QTY29` | NUMBER | Y |  |  |
| 37 | `QTY30` | NUMBER | Y |  |  |
| 38 | `QTY31` | NUMBER | Y |  |  |
| 39 | `QTY32` | NUMBER | Y |  |  |
| 40 | `QTY33` | NUMBER | Y |  |  |
| 41 | `QTY34` | NUMBER | Y |  |  |
| 42 | `QTY35` | NUMBER | Y |  |  |
| 43 | `QTY36` | NUMBER | Y |  |  |
| 44 | `QTY37` | NUMBER | Y |  |  |
| 45 | `QTY38` | NUMBER | Y |  |  |
| 46 | `QTY39` | NUMBER | Y |  |  |
| 47 | `QTY40` | NUMBER | Y |  |  |
| 48 | `QTY41` | NUMBER | Y |  |  |
| 49 | `QTY42` | NUMBER | Y |  |  |
| 50 | `QTY43` | NUMBER | Y |  |  |
| 51 | `QTY44` | NUMBER | Y |  |  |
| 52 | `QTY45` | NUMBER | Y |  |  |
| 53 | `QTY46` | NUMBER | Y |  |  |
| 54 | `QTY47` | NUMBER | Y |  |  |
| 55 | `QTY48` | NUMBER | Y |  |  |
| 56 | `QTY49` | NUMBER | Y |  |  |
| 57 | `QTY50` | NUMBER | Y |  |  |
| 58 | `QTY51` | NUMBER | Y |  |  |
| 59 | `QTY52` | NUMBER | Y |  |  |
| 60 | `QTY53` | NUMBER | Y |  |  |
| 61 | `QTY54` | NUMBER | Y |  |  |
| 62 | `QTY55` | NUMBER | Y |  |  |
| 63 | `QTY56` | NUMBER | Y |  |  |
| 64 | `QTY57` | NUMBER | Y |  |  |
| 65 | `QTY58` | NUMBER | Y |  |  |
| 66 | `QTY59` | NUMBER | Y |  |  |
| 67 | `QTY60` | NUMBER | Y |  |  |
| 68 | `QTY61` | NUMBER | Y |  |  |
| 69 | `QTY62` | NUMBER | Y |  |  |
| 70 | `CREATETIMEKEY` | VARCHAR2(20) | N |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 71 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 72 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 73 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_PRODPLAN_MONTH_BALANCE_PK` UNIQUE (CLIENT, COMPANY, PLANT, PLANDATE, SEQ, UPRITEM, ITEMCODE)

---

### TM_PRODPLAN_MONTH_BEGIN
**월별 생산 계획 기초**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `STOCKDATE` | VARCHAR2(8) | N | PK |  |
| 5 | `UPRITEM` | NUMBER | N | PK |  |
| 6 | `ITEMCODE` | NUMBER | N | PK |  |
| 7 | `QTY` | NUMBER | Y |  |  |
| 8 | `CREATETIMEKEY` | VARCHAR2(20) | N |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 9 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 10 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 11 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_PRODPLAN_MONTH_BEGIN_PK` UNIQUE (CLIENT, COMPANY, PLANT, STOCKDATE, UPRITEM, ITEMCODE)

---

### TM_PRODPLAN_MONTH_PLAN
**월별 생산 계획 상세**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `PLANDATE` | VARCHAR2(8) | N | PK |  |
| 5 | `SEQ` | VARCHAR2(3) | N | PK |  |
| 6 | `UPRITEM` | NUMBER | N | PK |  |
| 7 | `ITEMCODE` | NUMBER | N | PK |  |
| 8 | `QTY1` | NUMBER | Y |  |  |
| 9 | `QTY2` | NUMBER | Y |  |  |
| 10 | `QTY3` | NUMBER | Y |  |  |
| 11 | `QTY4` | NUMBER | Y |  |  |
| 12 | `QTY5` | NUMBER | Y |  |  |
| 13 | `QTY6` | NUMBER | Y |  |  |
| 14 | `QTY7` | NUMBER | Y |  |  |
| 15 | `QTY8` | NUMBER | Y |  |  |
| 16 | `QTY9` | NUMBER | Y |  |  |
| 17 | `QTY10` | NUMBER | Y |  |  |
| 18 | `QTY11` | NUMBER | Y |  |  |
| 19 | `QTY12` | NUMBER | Y |  |  |
| 20 | `QTY13` | NUMBER | Y |  |  |
| 21 | `QTY14` | NUMBER | Y |  |  |
| 22 | `QTY15` | NUMBER | Y |  |  |
| 23 | `QTY16` | NUMBER | Y |  |  |
| 24 | `QTY17` | NUMBER | Y |  |  |
| 25 | `QTY18` | NUMBER | Y |  |  |
| 26 | `QTY19` | NUMBER | Y |  |  |
| 27 | `QTY20` | NUMBER | Y |  |  |
| 28 | `QTY21` | NUMBER | Y |  |  |
| 29 | `QTY22` | NUMBER | Y |  |  |
| 30 | `QTY23` | NUMBER | Y |  |  |
| 31 | `QTY24` | NUMBER | Y |  |  |
| 32 | `QTY25` | NUMBER | Y |  |  |
| 33 | `QTY26` | NUMBER | Y |  |  |
| 34 | `QTY27` | NUMBER | Y |  |  |
| 35 | `QTY28` | NUMBER | Y |  |  |
| 36 | `QTY29` | NUMBER | Y |  |  |
| 37 | `QTY30` | NUMBER | Y |  |  |
| 38 | `QTY31` | NUMBER | Y |  |  |
| 39 | `QTY32` | NUMBER | Y |  |  |
| 40 | `QTY33` | NUMBER | Y |  |  |
| 41 | `QTY34` | NUMBER | Y |  |  |
| 42 | `QTY35` | NUMBER | Y |  |  |
| 43 | `QTY36` | NUMBER | Y |  |  |
| 44 | `QTY37` | NUMBER | Y |  |  |
| 45 | `QTY38` | NUMBER | Y |  |  |
| 46 | `QTY39` | NUMBER | Y |  |  |
| 47 | `QTY40` | NUMBER | Y |  |  |
| 48 | `QTY41` | NUMBER | Y |  |  |
| 49 | `QTY42` | NUMBER | Y |  |  |
| 50 | `QTY43` | NUMBER | Y |  |  |
| 51 | `QTY44` | NUMBER | Y |  |  |
| 52 | `QTY45` | NUMBER | Y |  |  |
| 53 | `QTY46` | NUMBER | Y |  |  |
| 54 | `QTY47` | NUMBER | Y |  |  |
| 55 | `QTY48` | NUMBER | Y |  |  |
| 56 | `QTY49` | NUMBER | Y |  |  |
| 57 | `QTY50` | NUMBER | Y |  |  |
| 58 | `QTY51` | NUMBER | Y |  |  |
| 59 | `QTY52` | NUMBER | Y |  |  |
| 60 | `QTY53` | NUMBER | Y |  |  |
| 61 | `QTY54` | NUMBER | Y |  |  |
| 62 | `QTY55` | NUMBER | Y |  |  |
| 63 | `QTY56` | NUMBER | Y |  |  |
| 64 | `QTY57` | NUMBER | Y |  |  |
| 65 | `QTY58` | NUMBER | Y |  |  |
| 66 | `QTY59` | NUMBER | Y |  |  |
| 67 | `QTY60` | NUMBER | Y |  |  |
| 68 | `QTY61` | NUMBER | Y |  |  |
| 69 | `QTY62` | NUMBER | Y |  |  |
| 70 | `CREATETIMEKEY` | VARCHAR2(20) | N |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 71 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 72 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 73 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_PRODPLAN_MONTH_PLAN_PK` UNIQUE (CLIENT, COMPANY, PLANT, PLANDATE, SEQ, UPRITEM, ITEMCODE)

---

### TM_PRODPLAN_MONTH_PRODRESULT
**월별 생산 실적**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | N |  |  |
| 3 | `PLANT` | VARCHAR2(10) | N |  |  |
| 4 | `PLANDATE` | VARCHAR2(8) | N |  |  |
| 5 | `SEQ` | VARCHAR2(3) | N |  |  |
| 6 | `UPRITEM` | NUMBER | N |  |  |
| 7 | `ITEMCODE` | NUMBER | N |  |  |
| 8 | `QTY1` | NUMBER | Y |  |  |
| 9 | `QTY2` | NUMBER | Y |  |  |
| 10 | `QTY3` | NUMBER | Y |  |  |
| 11 | `QTY4` | NUMBER | Y |  |  |
| 12 | `QTY5` | NUMBER | Y |  |  |
| 13 | `QTY6` | NUMBER | Y |  |  |
| 14 | `QTY7` | NUMBER | Y |  |  |
| 15 | `QTY8` | NUMBER | Y |  |  |
| 16 | `QTY9` | NUMBER | Y |  |  |
| 17 | `QTY10` | NUMBER | Y |  |  |
| 18 | `QTY11` | NUMBER | Y |  |  |
| 19 | `QTY12` | NUMBER | Y |  |  |
| 20 | `QTY13` | NUMBER | Y |  |  |
| 21 | `QTY14` | NUMBER | Y |  |  |
| 22 | `QTY15` | NUMBER | Y |  |  |
| 23 | `QTY16` | NUMBER | Y |  |  |
| 24 | `QTY17` | NUMBER | Y |  |  |
| 25 | `QTY18` | NUMBER | Y |  |  |
| 26 | `QTY19` | NUMBER | Y |  |  |
| 27 | `QTY20` | NUMBER | Y |  |  |
| 28 | `QTY21` | NUMBER | Y |  |  |
| 29 | `QTY22` | NUMBER | Y |  |  |
| 30 | `QTY23` | NUMBER | Y |  |  |
| 31 | `QTY24` | NUMBER | Y |  |  |
| 32 | `QTY25` | NUMBER | Y |  |  |
| 33 | `QTY26` | NUMBER | Y |  |  |
| 34 | `QTY27` | NUMBER | Y |  |  |
| 35 | `QTY28` | NUMBER | Y |  |  |
| 36 | `QTY29` | NUMBER | Y |  |  |
| 37 | `QTY30` | NUMBER | Y |  |  |
| 38 | `QTY31` | NUMBER | Y |  |  |
| 39 | `QTY32` | NUMBER | Y |  |  |
| 40 | `QTY33` | NUMBER | Y |  |  |
| 41 | `QTY34` | NUMBER | Y |  |  |
| 42 | `QTY35` | NUMBER | Y |  |  |
| 43 | `QTY36` | NUMBER | Y |  |  |
| 44 | `QTY37` | NUMBER | Y |  |  |
| 45 | `QTY38` | NUMBER | Y |  |  |
| 46 | `QTY39` | NUMBER | Y |  |  |
| 47 | `QTY40` | NUMBER | Y |  |  |
| 48 | `QTY41` | NUMBER | Y |  |  |
| 49 | `QTY42` | NUMBER | Y |  |  |
| 50 | `QTY43` | NUMBER | Y |  |  |
| 51 | `QTY44` | NUMBER | Y |  |  |
| 52 | `QTY45` | NUMBER | Y |  |  |
| 53 | `QTY46` | NUMBER | Y |  |  |
| 54 | `QTY47` | NUMBER | Y |  |  |
| 55 | `QTY48` | NUMBER | Y |  |  |
| 56 | `QTY49` | NUMBER | Y |  |  |
| 57 | `QTY50` | NUMBER | Y |  |  |
| 58 | `QTY51` | NUMBER | Y |  |  |
| 59 | `QTY52` | NUMBER | Y |  |  |
| 60 | `QTY53` | NUMBER | Y |  |  |
| 61 | `QTY54` | NUMBER | Y |  |  |
| 62 | `QTY55` | NUMBER | Y |  |  |
| 63 | `QTY56` | NUMBER | Y |  |  |
| 64 | `QTY57` | NUMBER | Y |  |  |
| 65 | `QTY58` | NUMBER | Y |  |  |
| 66 | `QTY59` | NUMBER | Y |  |  |
| 67 | `QTY60` | NUMBER | Y |  |  |
| 68 | `QTY61` | NUMBER | Y |  |  |
| 69 | `QTY62` | NUMBER | Y |  |  |
| 70 | `CREATETIMEKEY` | VARCHAR2(20) | N |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 71 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 72 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 73 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

---

### TM_PRODPLAN_MONTH_RESULT
**월별 생산 결과**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `PLANDATE` | VARCHAR2(8) | N | PK |  |
| 5 | `SEQ` | VARCHAR2(3) | N | PK |  |
| 6 | `UPRITEM` | NUMBER | N | PK |  |
| 7 | `ITEMCODE` | NUMBER | N | PK |  |
| 8 | `QTY1` | NUMBER | Y |  |  |
| 9 | `QTY2` | NUMBER | Y |  |  |
| 10 | `QTY3` | NUMBER | Y |  |  |
| 11 | `QTY4` | NUMBER | Y |  |  |
| 12 | `QTY5` | NUMBER | Y |  |  |
| 13 | `QTY6` | NUMBER | Y |  |  |
| 14 | `QTY7` | NUMBER | Y |  |  |
| 15 | `QTY8` | NUMBER | Y |  |  |
| 16 | `QTY9` | NUMBER | Y |  |  |
| 17 | `QTY10` | NUMBER | Y |  |  |
| 18 | `QTY11` | NUMBER | Y |  |  |
| 19 | `QTY12` | NUMBER | Y |  |  |
| 20 | `QTY13` | NUMBER | Y |  |  |
| 21 | `QTY14` | NUMBER | Y |  |  |
| 22 | `QTY15` | NUMBER | Y |  |  |
| 23 | `QTY16` | NUMBER | Y |  |  |
| 24 | `QTY17` | NUMBER | Y |  |  |
| 25 | `QTY18` | NUMBER | Y |  |  |
| 26 | `QTY19` | NUMBER | Y |  |  |
| 27 | `QTY20` | NUMBER | Y |  |  |
| 28 | `QTY21` | NUMBER | Y |  |  |
| 29 | `QTY22` | NUMBER | Y |  |  |
| 30 | `QTY23` | NUMBER | Y |  |  |
| 31 | `QTY24` | NUMBER | Y |  |  |
| 32 | `QTY25` | NUMBER | Y |  |  |
| 33 | `QTY26` | NUMBER | Y |  |  |
| 34 | `QTY27` | NUMBER | Y |  |  |
| 35 | `QTY28` | NUMBER | Y |  |  |
| 36 | `QTY29` | NUMBER | Y |  |  |
| 37 | `QTY30` | NUMBER | Y |  |  |
| 38 | `QTY31` | NUMBER | Y |  |  |
| 39 | `QTY32` | NUMBER | Y |  |  |
| 40 | `QTY33` | NUMBER | Y |  |  |
| 41 | `QTY34` | NUMBER | Y |  |  |
| 42 | `QTY35` | NUMBER | Y |  |  |
| 43 | `QTY36` | NUMBER | Y |  |  |
| 44 | `QTY37` | NUMBER | Y |  |  |
| 45 | `QTY38` | NUMBER | Y |  |  |
| 46 | `QTY39` | NUMBER | Y |  |  |
| 47 | `QTY40` | NUMBER | Y |  |  |
| 48 | `QTY41` | NUMBER | Y |  |  |
| 49 | `QTY42` | NUMBER | Y |  |  |
| 50 | `QTY43` | NUMBER | Y |  |  |
| 51 | `QTY44` | NUMBER | Y |  |  |
| 52 | `QTY45` | NUMBER | Y |  |  |
| 53 | `QTY46` | NUMBER | Y |  |  |
| 54 | `QTY47` | NUMBER | Y |  |  |
| 55 | `QTY48` | NUMBER | Y |  |  |
| 56 | `QTY49` | NUMBER | Y |  |  |
| 57 | `QTY50` | NUMBER | Y |  |  |
| 58 | `QTY51` | NUMBER | Y |  |  |
| 59 | `QTY52` | NUMBER | Y |  |  |
| 60 | `QTY53` | NUMBER | Y |  |  |
| 61 | `QTY54` | NUMBER | Y |  |  |
| 62 | `QTY55` | NUMBER | Y |  |  |
| 63 | `QTY56` | NUMBER | Y |  |  |
| 64 | `QTY57` | NUMBER | Y |  |  |
| 65 | `QTY58` | NUMBER | Y |  |  |
| 66 | `QTY59` | NUMBER | Y |  |  |
| 67 | `QTY60` | NUMBER | Y |  |  |
| 68 | `QTY61` | NUMBER | Y |  |  |
| 69 | `QTY62` | NUMBER | Y |  |  |
| 70 | `CREATETIMEKEY` | VARCHAR2(20) | N |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 71 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 72 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 73 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_PRODPLAN_MONTH_RESULT_PK` UNIQUE (CLIENT, COMPANY, PLANT, PLANDATE, SEQ, UPRITEM, ITEMCODE)

---

### TM_PRODPLAN_MONTH_WIP
**월별 생산 재공**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `PLANDATE` | VARCHAR2(8) | N | PK |  |
| 5 | `SEQ` | VARCHAR2(3) | N | PK |  |
| 6 | `UPRITEM` | NUMBER | N | PK |  |
| 7 | `ITEMCODE` | NUMBER | N | PK |  |
| 8 | `QTY1` | NUMBER | Y |  |  |
| 9 | `QTY2` | NUMBER | Y |  |  |
| 10 | `QTY3` | NUMBER | Y |  |  |
| 11 | `QTY4` | NUMBER | Y |  |  |
| 12 | `QTY5` | NUMBER | Y |  |  |
| 13 | `QTY6` | NUMBER | Y |  |  |
| 14 | `QTY7` | NUMBER | Y |  |  |
| 15 | `QTY8` | NUMBER | Y |  |  |
| 16 | `QTY9` | NUMBER | Y |  |  |
| 17 | `QTY10` | NUMBER | Y |  |  |
| 18 | `QTY11` | NUMBER | Y |  |  |
| 19 | `QTY12` | NUMBER | Y |  |  |
| 20 | `QTY13` | NUMBER | Y |  |  |
| 21 | `QTY14` | NUMBER | Y |  |  |
| 22 | `QTY15` | NUMBER | Y |  |  |
| 23 | `QTY16` | NUMBER | Y |  |  |
| 24 | `QTY17` | NUMBER | Y |  |  |
| 25 | `QTY18` | NUMBER | Y |  |  |
| 26 | `QTY19` | NUMBER | Y |  |  |
| 27 | `QTY20` | NUMBER | Y |  |  |
| 28 | `QTY21` | NUMBER | Y |  |  |
| 29 | `QTY22` | NUMBER | Y |  |  |
| 30 | `QTY23` | NUMBER | Y |  |  |
| 31 | `QTY24` | NUMBER | Y |  |  |
| 32 | `QTY25` | NUMBER | Y |  |  |
| 33 | `QTY26` | NUMBER | Y |  |  |
| 34 | `QTY27` | NUMBER | Y |  |  |
| 35 | `QTY28` | NUMBER | Y |  |  |
| 36 | `QTY29` | NUMBER | Y |  |  |
| 37 | `QTY30` | NUMBER | Y |  |  |
| 38 | `QTY31` | NUMBER | Y |  |  |
| 39 | `QTY32` | NUMBER | Y |  |  |
| 40 | `QTY33` | NUMBER | Y |  |  |
| 41 | `QTY34` | NUMBER | Y |  |  |
| 42 | `QTY35` | NUMBER | Y |  |  |
| 43 | `QTY36` | NUMBER | Y |  |  |
| 44 | `QTY37` | NUMBER | Y |  |  |
| 45 | `QTY38` | NUMBER | Y |  |  |
| 46 | `QTY39` | NUMBER | Y |  |  |
| 47 | `QTY40` | NUMBER | Y |  |  |
| 48 | `QTY41` | NUMBER | Y |  |  |
| 49 | `QTY42` | NUMBER | Y |  |  |
| 50 | `QTY43` | NUMBER | Y |  |  |
| 51 | `QTY44` | NUMBER | Y |  |  |
| 52 | `QTY45` | NUMBER | Y |  |  |
| 53 | `QTY46` | NUMBER | Y |  |  |
| 54 | `QTY47` | NUMBER | Y |  |  |
| 55 | `QTY48` | NUMBER | Y |  |  |
| 56 | `QTY49` | NUMBER | Y |  |  |
| 57 | `QTY50` | NUMBER | Y |  |  |
| 58 | `QTY51` | NUMBER | Y |  |  |
| 59 | `QTY52` | NUMBER | Y |  |  |
| 60 | `QTY53` | NUMBER | Y |  |  |
| 61 | `QTY54` | NUMBER | Y |  |  |
| 62 | `QTY55` | NUMBER | Y |  |  |
| 63 | `QTY56` | NUMBER | Y |  |  |
| 64 | `QTY57` | NUMBER | Y |  |  |
| 65 | `QTY58` | NUMBER | Y |  |  |
| 66 | `QTY59` | NUMBER | Y |  |  |
| 67 | `QTY60` | NUMBER | Y |  |  |
| 68 | `QTY61` | NUMBER | Y |  |  |
| 69 | `QTY62` | NUMBER | Y |  |  |
| 70 | `CREATETIMEKEY` | VARCHAR2(20) | N |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 71 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 72 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 73 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_PRODPLAN_MONTH_WIP_PK` UNIQUE (CLIENT, COMPANY, PLANT, PLANDATE, SEQ, UPRITEM, ITEMCODE)

---

### TM_PRODPLAN_TEMP
**생산 계획 임시**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `PLANDATE` | VARCHAR2(8) | N | PK |  |
| 5 | `ITEMCODE` | NUMBER | N | PK |  |
| 6 | `STOCKQTY` | NUMBER | Y |  |  |
| 7 | `QTY1` | NUMBER | Y |  |  |
| 8 | `QTY2` | NUMBER | Y |  |  |
| 9 | `QTY3` | NUMBER | Y |  |  |
| 10 | `QTY4` | NUMBER | Y |  |  |
| 11 | `QTY5` | NUMBER | Y |  |  |
| 12 | `QTY6` | NUMBER | Y |  |  |
| 13 | `QTY7` | NUMBER | Y |  |  |
| 14 | `QTY8` | NUMBER | Y |  |  |
| 15 | `QTY9` | NUMBER | Y |  |  |
| 16 | `QTY10` | NUMBER | Y |  |  |
| 17 | `QTY11` | NUMBER | Y |  |  |
| 18 | `QTY12` | NUMBER | Y |  |  |
| 19 | `QTY13` | NUMBER | Y |  |  |
| 20 | `QTY14` | NUMBER | Y |  |  |
| 21 | `QTY15` | NUMBER | Y |  |  |
| 22 | `QTY16` | NUMBER | Y |  |  |
| 23 | `QTY17` | NUMBER | Y |  |  |
| 24 | `QTY18` | NUMBER | Y |  |  |
| 25 | `QTY19` | NUMBER | Y |  |  |
| 26 | `QTY20` | NUMBER | Y |  |  |
| 27 | `QTY21` | NUMBER | Y |  |  |
| 28 | `QTY22` | NUMBER | Y |  |  |
| 29 | `QTY23` | NUMBER | Y |  |  |
| 30 | `QTY24` | NUMBER | Y |  |  |
| 31 | `QTY25` | NUMBER | Y |  |  |
| 32 | `QTY26` | NUMBER | Y |  |  |
| 33 | `QTY27` | NUMBER | Y |  |  |
| 34 | `QTY28` | NUMBER | Y |  |  |
| 35 | `QTY29` | NUMBER | Y |  |  |
| 36 | `QTY30` | NUMBER | Y |  |  |
| 37 | `QTY31` | NUMBER | Y |  |  |
| 38 | `QTY32` | NUMBER | Y |  |  |
| 39 | `QTY33` | NUMBER | Y |  |  |
| 40 | `QTY34` | NUMBER | Y |  |  |
| 41 | `QTY35` | NUMBER | Y |  |  |
| 42 | `QTY36` | NUMBER | Y |  |  |
| 43 | `QTY37` | NUMBER | Y |  |  |
| 44 | `QTY38` | NUMBER | Y |  |  |
| 45 | `QTY39` | NUMBER | Y |  |  |
| 46 | `QTY40` | NUMBER | Y |  |  |
| 47 | `QTY41` | NUMBER | Y |  |  |
| 48 | `QTY42` | NUMBER | Y |  |  |
| 49 | `QTY43` | NUMBER | Y |  |  |
| 50 | `QTY44` | NUMBER | Y |  |  |
| 51 | `QTY45` | NUMBER | Y |  |  |
| 52 | `QTY46` | NUMBER | Y |  |  |
| 53 | `QTY47` | NUMBER | Y |  |  |
| 54 | `QTY48` | NUMBER | Y |  |  |
| 55 | `QTY49` | NUMBER | Y |  |  |
| 56 | `QTY50` | NUMBER | Y |  |  |
| 57 | `PLANQTY1` | NUMBER | Y |  |  |
| 58 | `PLANQTY2` | NUMBER | Y |  |  |
| 59 | `PLANQTY3` | NUMBER | Y |  |  |
| 60 | `PLANQTY4` | NUMBER | Y |  |  |
| 61 | `PLANQTY5` | NUMBER | Y |  |  |
| 62 | `PLANQTY6` | NUMBER | Y |  |  |
| 63 | `PLANQTY7` | NUMBER | Y |  |  |
| 64 | `PLANQTY8` | NUMBER | Y |  |  |
| 65 | `PLANQTY9` | NUMBER | Y |  |  |
| 66 | `PLANQTY10` | NUMBER | Y |  |  |
| 67 | `PLANQTY11` | NUMBER | Y |  |  |
| 68 | `PLANQTY12` | NUMBER | Y |  |  |
| 69 | `PLANQTY13` | NUMBER | Y |  |  |
| 70 | `PLANQTY14` | NUMBER | Y |  |  |
| 71 | `PLANQTY15` | NUMBER | Y |  |  |
| 72 | `PLANQTY16` | NUMBER | Y |  |  |
| 73 | `PLANQTY17` | NUMBER | Y |  |  |
| 74 | `PLANQTY18` | NUMBER | Y |  |  |
| 75 | `PLANQTY19` | NUMBER | Y |  |  |
| 76 | `PLANQTY20` | NUMBER | Y |  |  |
| 77 | `PLANQTY21` | NUMBER | Y |  |  |
| 78 | `PLANQTY22` | NUMBER | Y |  |  |
| 79 | `PLANQTY23` | NUMBER | Y |  |  |
| 80 | `PLANQTY24` | NUMBER | Y |  |  |
| 81 | `PLANQTY25` | NUMBER | Y |  |  |
| 82 | `PLANQTY26` | NUMBER | Y |  |  |
| 83 | `PLANQTY27` | NUMBER | Y |  |  |
| 84 | `PLANQTY28` | NUMBER | Y |  |  |
| 85 | `PLANQTY29` | NUMBER | Y |  |  |
| 86 | `PLANQTY30` | NUMBER | Y |  |  |
| 87 | `PLANQTY31` | NUMBER | Y |  |  |
| 88 | `PLANQTY32` | NUMBER | Y |  |  |
| 89 | `PLANQTY33` | NUMBER | Y |  |  |
| 90 | `PLANQTY34` | NUMBER | Y |  |  |
| 91 | `PLANQTY35` | NUMBER | Y |  |  |
| 92 | `PLANQTY36` | NUMBER | Y |  |  |
| 93 | `PLANQTY37` | NUMBER | Y |  |  |
| 94 | `PLANQTY38` | NUMBER | Y |  |  |
| 95 | `PLANQTY39` | NUMBER | Y |  |  |
| 96 | `PLANQTY40` | NUMBER | Y |  |  |
| 97 | `PLANQTY41` | NUMBER | Y |  |  |
| 98 | `PLANQTY42` | NUMBER | Y |  |  |
| 99 | `PLANQTY43` | NUMBER | Y |  |  |
| 100 | `PLANQTY44` | NUMBER | Y |  |  |
| 101 | `PLANQTY45` | NUMBER | Y |  |  |
| 102 | `PLANQTY46` | NUMBER | Y |  |  |
| 103 | `PLANQTY47` | NUMBER | Y |  |  |
| 104 | `PLANQTY48` | NUMBER | Y |  |  |
| 105 | `PLANQTY49` | NUMBER | Y |  |  |
| 106 | `PLANQTY50` | NUMBER | Y |  |  |
| 107 | `CREATETIMEKEY` | VARCHAR2(20) | N |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 108 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 109 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 110 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_PRODPLAN_TEMP_PK` UNIQUE (CLIENT, COMPANY, PLANT, PLANDATE, ITEMCODE)

---

### TM_REASON
**사유코드 마스터**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `REASONCODE` | VARCHAR2(5) | N | PK |  |
| 5 | `REASON` | VARCHAR2(300) | N |  |  |
| 6 | `DISPSEQ` | NUMBER | Y |  |  |
| 7 | `REASONTYPE` | NUMBER | N |  |  |
| 8 | `UDF1` | NUMBER | Y |  |  |
| 9 | `UDF2` | NUMBER | Y |  |  |
| 10 | `UDF3` | NUMBER | Y |  |  |
| 11 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 12 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 13 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 14 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 15 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 16 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_REASON_PK` UNIQUE (CLIENT, COMPANY, PLANT, REASONCODE)

---

### TM_ROUTING
**라우팅마스터**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `ROUTEGRP` | VARCHAR2(50) | N | PK |  |
| 5 | `ROUTE` | VARCHAR2(8) | N | PK |  |
| 6 | `OPER` | VARCHAR2(6) | N |  |  |
| 7 | `UPRROUTE` | VARCHAR2(8) | Y |  |  |
| 8 | `ITEMCODE` | NUMBER | Y |  |  |
| 9 | `ROUTETYPE` | NUMBER | Y |  |  |
| 10 | `VENDOR` | VARCHAR2(10) | Y |  |  |
| 11 | `BOMITEMUSEFLAG` | VARCHAR2(1) | N |  | 'N' |
| 12 | `INSPFLAG` | VARCHAR2(1) | N |  | 'N' |
| 13 | `PRODUCTIONTERM` | NUMBER | Y |  |  |
| 14 | `OUTSOURFLAG` | VARCHAR2(1) | N |  | 'N' |
| 15 | `LINETYPE` | NUMBER | Y |  |  |
| 16 | `LINECOLOR` | NUMBER | Y |  |  |
| 17 | `XPOS` | NUMBER | Y |  |  |
| 18 | `YPOS` | NUMBER | Y |  |  |
| 19 | `UDF1` | NUMBER | Y |  |  |
| 20 | `UDF2` | NUMBER | Y |  |  |
| 21 | `UDF3` | NUMBER | Y |  |  |
| 22 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 23 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 24 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 25 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 26 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 27 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_ROUTING_PK` UNIQUE (CLIENT, COMPANY, PLANT, ROUTEGRP, ROUTE)

---

### TM_ROUTINGGRP
**라우팅그룹마스터**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `ROUTEGRP` | VARCHAR2(50) | N | PK |  |
| 5 | `ITEMCODE` | NUMBER | Y |  |  |
| 6 | `USEFLAG` | VARCHAR2(1) | N |  | 'Y' |
| 7 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 8 | `CREATETIMEKEY` | VARCHAR2(20) | N |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 9 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 10 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 11 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_ROUTINGGRP_PK` UNIQUE (CLIENT, COMPANY, PLANT, ROUTEGRP)

---

### TM_SERIAL
**시리얼마스터**
  행수: 1,868,570

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `SERIAL` | VARCHAR2(100) | N | PK |  |
| 5 | `SERIALTYPE` | VARCHAR2(1) | N |  |  |
| 6 | `PRESERIAL` | VARCHAR2(50) | Y |  |  |
| 7 | `INDATE` | VARCHAR2(8) | Y |  | NULL |
| 8 | `TXNCODE` | VARCHAR2(5) | Y |  |  |
| 9 | `ITEMCODE` | NUMBER | Y |  |  |
| 10 | `QTY` | NUMBER | N |  | 1 |
| 11 | `WRKORD` | VARCHAR2(30) | Y |  |  |
| 12 | `WRKORDSEQ` | NUMBER | Y |  |  |
| 13 | `ORDERNO` | VARCHAR2(12) | Y |  |  |
| 14 | `ORDERSEQ` | NUMBER | Y |  |  |
| 15 | `INVOICENO` | VARCHAR2(30) | Y |  |  |
| 16 | `VENDOR` | VARCHAR2(10) | Y |  |  |
| 17 | `MAKER` | VARCHAR2(10) | Y |  |  |
| 18 | `BCDDATA` | VARCHAR2(100) | Y |  |  |
| 19 | `BCDLOT` | VARCHAR2(100) | Y |  |  |
| 20 | `PRINTFLAG` | VARCHAR2(1) | Y |  | 'N' |
| 21 | `SLIPNO` | VARCHAR2(100) | Y |  | 'NONE' |
| 22 | `IQCNO` | NUMBER | Y |  |  |
| 23 | `BOXNO` | VARCHAR2(50) | Y |  | 'NONE' |
| 24 | `REPRINTCNT` | NUMBER | Y |  |  |
| 25 | `PRINTCNT` | NUMBER | Y |  |  |
| 26 | `UDF3` | NUMBER | Y |  |  |
| 27 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 28 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 29 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 30 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 31 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 32 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_SERIAL_IDX1`  (CLIENT, COMPANY, PLANT, WRKORD)
- `TM_SERIAL_IDX2`  (CLIENT, COMPANY, PLANT, BOXNO)
- `TM_SERIAL_IDX3`  (CLIENT, COMPANY, PLANT, INDATE, TXNCODE)
- `TM_SERIAL_IDX4`  (CLIENT, COMPANY, PLANT, SERIAL, BOXNO)
- `TM_SERIAL_IDX5`  (CLIENT, COMPANY, PLANT, ORDERNO, ORDERSEQ)
- `TM_SERIAL_PK` UNIQUE (CLIENT, COMPANY, PLANT, SERIAL)
- `TM_SERIAL_SERIAL_IDX` UNIQUE (SERIAL)

---

### TM_SUBITEMS
**대체자재마스터**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `SEQ` | NUMBER | N | PK |  |
| 5 | `IDX` | NUMBER | N | PK |  |
| 6 | `SUBITEMCODE` | NUMBER | N | PK |  |
| 7 | `UDF1` | NUMBER | Y |  |  |
| 8 | `UDF2` | NUMBER | Y |  |  |
| 9 | `UDF3` | NUMBER | Y |  |  |
| 10 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 11 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 12 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 13 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 14 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 15 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_SUBITEMS_PK` UNIQUE (CLIENT, COMPANY, PLANT, SEQ, IDX, SUBITEMCODE)

---

### TM_SUBITEMS_DEREK
**대체자재(DEREK용)**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | N |  |  |
| 3 | `PLANT` | VARCHAR2(10) | N |  |  |
| 4 | `SEQ` | NUMBER | Y |  |  |
| 5 | `IDX` | NUMBER | N |  |  |
| 6 | `SUBITEMCODE` | NUMBER | N |  |  |
| 7 | `UDF1` | NUMBER | Y |  |  |
| 8 | `UDF2` | NUMBER | Y |  |  |
| 9 | `UDF3` | NUMBER | Y |  |  |
| 10 | `USEFLAG` | VARCHAR2(1) | Y |  |  |
| 11 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 12 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 13 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 14 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 15 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

---

### TM_SYSTEM
**시스템마스터**
  행수: 1

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | N |  |  |
| 3 | `PLANT` | VARCHAR2(10) | N |  |  |
| 4 | `SYSCODE` | VARCHAR2(10) | Y |  |  |
| 5 | `SYSNAME` | VARCHAR2(30) | Y |  |  |
| 6 | `UDF1` | NUMBER | Y |  |  |
| 7 | `UDF2` | NUMBER | Y |  |  |
| 8 | `UDF3` | NUMBER | Y |  |  |
| 9 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 10 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 11 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 12 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 13 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 14 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

---

### TM_SYSUSERROLE
**시스템사용자권한마스터**
  행수: 191

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | N |  |  |
| 3 | `PLANT` | VARCHAR2(10) | N |  |  |
| 4 | `SYSCODE` | VARCHAR2(10) | N |  |  |
| 5 | `EHRCODE` | VARCHAR2(10) | N |  |  |
| 6 | `USERROLE` | VARCHAR2(10) | N |  |  |
| 7 | `UDF1` | NUMBER | Y |  |  |
| 8 | `UDF2` | NUMBER | Y |  |  |
| 9 | `UDF3` | NUMBER | Y |  |  |
| 10 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 11 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 12 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 13 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 14 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 15 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

---

### TM_TRANSACTION
**트랜잭션마스터**
  행수: 63

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `TXNCODE` | VARCHAR2(5) | N | PK |  |
| 5 | `TXNNAME` | VARCHAR2(50) | Y |  |  |
| 6 | `ERPTXNCODE` | VARCHAR2(10) | Y |  |  |
| 7 | `MATINFLAG` | VARCHAR2(1) | Y |  | 'N' |
| 8 | `MATOUTFLAG` | VARCHAR2(1) | Y |  | 'N' |
| 9 | `PRDINFLAG` | VARCHAR2(1) | Y |  | 'N' |
| 10 | `PRDOUTFLAG` | VARCHAR2(1) | Y |  | 'N' |
| 11 | `CANCELFLAG` | VARCHAR2(1) | Y |  | 'N' |
| 12 | `UNDOFLAG` | VARCHAR2(1) | Y |  | 'N' |
| 13 | `USEMES` | VARCHAR2(1) | Y |  | 'N' |
| 14 | `UDF1` | NUMBER | Y |  |  |
| 15 | `UDF2` | NUMBER | Y |  |  |
| 16 | `UDF3` | NUMBER | Y |  |  |
| 17 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 18 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 19 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 20 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 21 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 22 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_TRANSACTION_PK` UNIQUE (CLIENT, COMPANY, PLANT, TXNCODE)

---

### TM_UNITCODE
**단위마스터**
  행수: 5

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `UNITCODE` | VARCHAR2(4) | N | PK |  |
| 5 | `UNITNAME` | VARCHAR2(30) | N |  |  |
| 6 | `UNITTYPE` | VARCHAR2(30) | Y |  |  |
| 7 | `UDF1` | NUMBER | Y |  |  |
| 8 | `UDF2` | NUMBER | Y |  |  |
| 9 | `UDF3` | NUMBER | Y |  |  |
| 10 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 11 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 12 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 13 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 14 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 15 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_UNITCODE_PK` UNIQUE (CLIENT, COMPANY, PLANT, UNITCODE)

---

### TM_USER
**사용자마스터**
  행수: 88

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `USERID` | VARCHAR2(10) | N | PK |  |
| 5 | `PASSWORD` | VARCHAR2(100) | Y |  |  |
| 6 | `EHRCODE` | VARCHAR2(10) | Y |  |  |
| 7 | `LOCUSERNAME` | VARCHAR2(50) | Y |  |  |
| 8 | `VALIDTODATE` | VARCHAR2(8) | Y |  | '99991231' |
| 9 | `UDF1` | NUMBER | Y |  |  |
| 10 | `UDF2` | NUMBER | Y |  |  |
| 11 | `UDF3` | NUMBER | Y |  |  |
| 12 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 13 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 14 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 15 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 16 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 17 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_USER_PK` UNIQUE (CLIENT, COMPANY, PLANT, USERID)

---

### TM_USERROLE
**사용자권한마스터**
  행수: 14

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | N |  |  |
| 3 | `PLANT` | VARCHAR2(10) | N |  |  |
| 4 | `SYSCODE` | VARCHAR2(10) | Y |  |  |
| 5 | `USERROLE` | VARCHAR2(10) | Y |  |  |
| 6 | `USERROLENAME` | VARCHAR2(30) | Y |  |  |
| 7 | `ALERTFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 8 | `UPDATEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 9 | `UDF1` | NUMBER | Y |  |  |
| 10 | `UDF2` | NUMBER | Y |  |  |
| 11 | `UDF3` | NUMBER | Y |  |  |
| 12 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 13 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 14 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 15 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 16 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 17 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

---

### TM_VENDOR
**거래처마스터**
  행수: 5

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `VENDOR` | VARCHAR2(10) | N | PK |  |
| 5 | `VENDORNAME` | VARCHAR2(100) | N |  |  |
| 6 | `MAKER` | VARCHAR2(30) | Y |  |  |
| 7 | `ENTRYNO` | VARCHAR2(15) | Y |  |  |
| 8 | `CONTRYNO` | VARCHAR2(30) | Y |  |  |
| 9 | `CEONAME` | VARCHAR2(30) | Y |  |  |
| 10 | `PHONE` | VARCHAR2(20) | Y |  |  |
| 11 | `FAXNO` | VARCHAR2(20) | Y |  |  |
| 12 | `ADDRESS` | VARCHAR2(300) | Y |  |  |
| 13 | `PRCFLAG` | VARCHAR2(1) | N |  | 'Y' |
| 14 | `SALFLAG` | VARCHAR2(1) | N |  | 'Y' |
| 15 | `OSCFLAG` | VARCHAR2(1) | N |  | 'Y' |
| 16 | `UDF1` | NUMBER | Y |  |  |
| 17 | `UDF2` | NUMBER | Y |  |  |
| 18 | `UDF3` | NUMBER | Y |  |  |
| 19 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 20 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 21 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 22 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 23 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 24 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_VENDOR_PK` UNIQUE (CLIENT, COMPANY, PLANT, VENDOR)

---

### TM_WAREHOUSE
**창고마스터**
  행수: 6

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `WAREHOUSE` | VARCHAR2(10) | N | PK |  |
| 5 | `WAREHOUSENAME` | VARCHAR2(100) | N |  |  |
| 6 | `WAREHOUSETYPE` | VARCHAR2(4) | Y |  |  |
| 7 | `VENDOR` | VARCHAR2(10) | Y |  |  |
| 8 | `UDF1` | NUMBER | Y |  |  |
| 9 | `UDF2` | NUMBER | Y |  |  |
| 10 | `UDF3` | NUMBER | Y |  |  |
| 11 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 12 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 13 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 14 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 15 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 16 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_WAREHOUSE_PK` UNIQUE (CLIENT, COMPANY, PLANT, WAREHOUSE)

---

### TM_WORKTIME
**근무인원**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `WORKDATE` | VARCHAR2(8) | N | PK |  |
| 5 | `PRODLINE` | VARCHAR2(10) | N | PK |  |
| 6 | `WORKTIME1` | NUMBER | Y |  |  |
| 7 | `WORKTIME2` | NUMBER | Y |  |  |
| 8 | `WORKTIME3` | NUMBER | Y |  |  |
| 9 | `WORKTIME4` | NUMBER | Y |  |  |
| 10 | `WORKTIME5` | NUMBER | Y |  |  |
| 11 | `WORKTIME6` | NUMBER | Y |  |  |
| 12 | `WORKTIME7` | NUMBER | Y |  |  |
| 13 | `WORKTIME8` | NUMBER | Y |  |  |
| 14 | `WORKTIME9` | NUMBER | Y |  |  |
| 15 | `WORKTIME10` | NUMBER | Y |  |  |
| 16 | `WORKTIME11` | NUMBER | Y |  |  |
| 17 | `WORKTIME12` | NUMBER | Y |  |  |
| 18 | `WORKTIME13` | NUMBER | Y |  |  |
| 19 | `WORKTIME14` | NUMBER | Y |  |  |
| 20 | `WORKTIME15` | NUMBER | Y |  |  |
| 21 | `WORKTIME16` | NUMBER | Y |  |  |
| 22 | `WORKTIME17` | NUMBER | Y |  |  |
| 23 | `WORKTIME18` | NUMBER | Y |  |  |
| 24 | `WORKTIME19` | NUMBER | Y |  |  |
| 25 | `WORKTIME20` | NUMBER | Y |  |  |
| 26 | `WORKTIME21` | NUMBER | Y |  |  |
| 27 | `WORKTIME22` | NUMBER | Y |  |  |
| 28 | `WORKTIME23` | NUMBER | Y |  |  |
| 29 | `WORKTIME24` | NUMBER | Y |  |  |
| 30 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 31 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 32 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 33 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 34 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 35 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TM_WORKTIME_PK` UNIQUE (CLIENT, COMPANY, PLANT, WORKDATE, PRODLINE)

---

### TOAD_PLAN_TABLE
**TOAD 실행계획 테이블**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `STATEMENT_ID` | VARCHAR2(30) | Y |  |  |
| 2 | `PLAN_ID` | NUMBER | Y |  |  |
| 3 | `TIMESTAMP` | DATE | Y |  |  |
| 4 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 5 | `OPERATION` | VARCHAR2(30) | Y |  |  |
| 6 | `OPTIONS` | VARCHAR2(255) | Y |  |  |
| 7 | `OBJECT_NODE` | VARCHAR2(128) | Y |  |  |
| 8 | `OBJECT_OWNER` | VARCHAR2(30) | Y |  |  |
| 9 | `OBJECT_NAME` | VARCHAR2(30) | Y |  |  |
| 10 | `OBJECT_ALIAS` | VARCHAR2(65) | Y |  |  |
| 11 | `OBJECT_INSTANCE` | NUMBER | Y |  |  |
| 12 | `OBJECT_TYPE` | VARCHAR2(30) | Y |  |  |
| 13 | `OPTIMIZER` | VARCHAR2(255) | Y |  |  |
| 14 | `SEARCH_COLUMNS` | NUMBER | Y |  |  |
| 15 | `ID` | NUMBER | Y |  |  |
| 16 | `PARENT_ID` | NUMBER | Y |  |  |
| 17 | `DEPTH` | NUMBER | Y |  |  |
| 18 | `POSITION` | NUMBER | Y |  |  |
| 19 | `COST` | NUMBER | Y |  |  |
| 20 | `CARDINALITY` | NUMBER | Y |  |  |
| 21 | `BYTES` | NUMBER | Y |  |  |
| 22 | `OTHER_TAG` | VARCHAR2(255) | Y |  |  |
| 23 | `PARTITION_START` | VARCHAR2(255) | Y |  |  |
| 24 | `PARTITION_STOP` | VARCHAR2(255) | Y |  |  |
| 25 | `PARTITION_ID` | NUMBER | Y |  |  |
| 26 | `OTHER` | LONG | Y |  |  |
| 27 | `DISTRIBUTION` | VARCHAR2(30) | Y |  |  |
| 28 | `CPU_COST` | NUMBER | Y |  |  |
| 29 | `IO_COST` | NUMBER | Y |  |  |
| 30 | `TEMP_SPACE` | NUMBER | Y |  |  |
| 31 | `ACCESS_PREDICATES` | VARCHAR2(4000) | Y |  |  |
| 32 | `FILTER_PREDICATES` | VARCHAR2(4000) | Y |  |  |
| 33 | `PROJECTION` | VARCHAR2(4000) | Y |  |  |
| 34 | `TIME` | NUMBER | Y |  |  |
| 35 | `QBLOCK_NAME` | VARCHAR2(30) | Y |  |  |
| 36 | `OTHER_XML` | CLOB | Y |  |  |

---

### TW_ACTUALSTOCK
**재고 실사 정보**
  행수: 32,167

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | N |  |  |
| 3 | `PLANT` | VARCHAR2(5) | N |  |  |
| 4 | `ACTUALMON` | VARCHAR2(8) | N |  |  |
| 5 | `SERIAL` | VARCHAR2(50) | N |  | 'NONE' |
| 6 | `ITEMCODE` | NUMBER | N |  |  |
| 7 | `WHLOC` | VARCHAR2(20) | N |  | 'NONE' |
| 8 | `BOXNO` | VARCHAR2(50) | N |  | 'NONE' |
| 9 | `SIDE` | VARCHAR2(1) | N |  | 'N' |
| 10 | `STOCKTYPE` | VARCHAR2(1) | N |  | 'G' |
| 11 | `ACTUALQTY` | NUMBER | Y |  |  |
| 12 | `APPLYFLAG` | VARCHAR2(1) | N |  | 'N' |
| 13 | `UDF1` | NUMBER | Y |  |  |
| 14 | `UDF2` | NUMBER | Y |  |  |
| 15 | `UDF3` | NUMBER | Y |  |  |
| 16 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 17 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 18 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 19 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 20 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 21 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TW_ACTUALSTOCK_IDX1`  (CLIENT, COMPANY, PLANT, ACTUALMON, WHLOC)

---

### TW_BRD
**불량/수리/폐기 이력**
  행수: 728

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `TXNTIMEKEY` | VARCHAR2(20) | N | PK |  |
| 5 | `BRDDATE` | VARCHAR2(8) | N | PK |  |
| 6 | `DEFECT` | VARCHAR2(10) | N | PK |  |
| 7 | `DEFECT2` | VARCHAR2(10) | Y |  |  |
| 8 | `DEFECT3` | VARCHAR2(10) | Y |  |  |
| 9 | `DEFECT4` | VARCHAR2(10) | Y |  |  |
| 10 | `DEFECT5` | VARCHAR2(10) | Y |  |  |
| 11 | `SERIAL` | VARCHAR2(50) | N | PK | 'NONE' |
| 12 | `FROMWHLOC` | VARCHAR2(10) | Y |  |  |
| 13 | `TOWHLOC` | VARCHAR2(10) | Y |  |  |
| 14 | `OPER` | VARCHAR2(6) | Y |  |  |
| 15 | `PRODLINE` | VARCHAR2(10) | Y |  |  |
| 16 | `UNITNO` | VARCHAR2(10) | Y |  |  |
| 17 | `ITEMCODE` | NUMBER | Y |  |  |
| 18 | `BRDQTY` | NUMBER | Y |  |  |
| 19 | `REPAIRQTY` | NUMBER | Y |  | 0 |
| 20 | `DISPOSEQTY` | NUMBER | Y |  | 0 |
| 21 | `WRKORD` | VARCHAR2(15) | Y |  | 'NONE' |
| 22 | `WRKORDSEQ` | NUMBER | Y |  |  |
| 23 | `UDF1` | NUMBER | Y |  |  |
| 24 | `UDF2` | NUMBER | Y |  |  |
| 25 | `UDF3` | NUMBER | Y |  |  |
| 26 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 27 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 28 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 29 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 30 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 31 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TW_BRD_IDX1`  (CLIENT, COMPANY, PLANT, SERIAL)
- `TW_BRD_PK` UNIQUE (CLIENT, COMPANY, PLANT, TXNTIMEKEY, BRDDATE, DEFECT, SERIAL)

---

### TW_COMPARESTOCK
**재고 비교**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `PARTNO` | VARCHAR2(30) | N |  |  |
| 2 | `WHLOC` | VARCHAR2(20) | Y |  |  |
| 3 | `QTY` | NUMBER | Y |  |  |

---

### TW_CRIMPPING
**압착 기준 정보**
  행수: 34

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `ITEMCODE` | NUMBER | N | PK |  |
| 5 | `WIRE` | VARCHAR2(30) | N |  |  |
| 6 | `COLOR` | VARCHAR2(10) | Y |  |  |
| 7 | `SQ` | VARCHAR2(10) | Y |  |  |
| 8 | `WIRELENGTH` | NUMBER | Y |  |  |
| 9 | `FRONT` | VARCHAR2(30) | Y |  |  |
| 10 | `FRONTSTRIP` | NUMBER | Y |  |  |
| 11 | `REAR` | VARCHAR2(30) | Y |  |  |
| 12 | `REARSTRIP` | NUMBER | Y |  |  |
| 13 | `UDF1` | NUMBER | Y |  |  |
| 14 | `UDF2` | NUMBER | Y |  |  |
| 15 | `UDF3` | NUMBER | Y |  |  |
| 16 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 17 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 18 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 19 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 20 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 21 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TW_CRIMPPING_PK` UNIQUE (CLIENT, COMPANY, PLANT, ITEMCODE)

---

### TW_DAILYWORKPLAN
**일별 생산 계획(통전기준)**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(5) | N | PK |  |
| 4 | `PLANDATE` | VARCHAR2(8) | N | PK |  |
| 5 | `WRKORD` | VARCHAR2(30) | N | PK |  |
| 6 | `OPER` | VARCHAR2(8) | N | PK |  |
| 7 | `ITEMCODE` | NUMBER | N | PK |  |
| 8 | `PLANQTY` | NUMBER | N |  |  |
| 9 | `PLANHOUR` | NUMBER | Y |  |  |
| 10 | `UDF1` | NUMBER | Y |  |  |
| 11 | `UDF2` | NUMBER | Y |  |  |
| 12 | `UDF3` | NUMBER | Y |  |  |
| 13 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 14 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 15 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 16 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 17 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 18 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TW_DAILYWORKPLAN_PK` UNIQUE (CLIENT, COMPANY, PLANT, PLANDATE, WRKORD, OPER, ITEMCODE)

---

### TW_IN
**입고 이력**
  행수: 1,750,960

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(5) | N | PK |  |
| 4 | `INDATE` | VARCHAR2(8) | N | PK |  |
| 5 | `SERIAL` | VARCHAR2(50) | N | PK | 'NONE' |
| 6 | `ITEMCODE` | NUMBER | N | PK |  |
| 7 | `STOCKTYPE` | VARCHAR2(1) | N | PK | 'G' |
| 8 | `INQTY` | NUMBER | N | PK | 0 |
| 9 | `TXNTIMEKEY` | VARCHAR2(20) | N | PK | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 10 | `TXNCODE` | VARCHAR2(5) | N | PK |  |
| 11 | `WHLOC` | VARCHAR2(10) | N | PK |  |
| 12 | `VENDOR` | VARCHAR2(10) | Y |  |  |
| 13 | `FROMWHLOC` | VARCHAR2(10) | Y |  |  |
| 14 | `FROMVENDOR` | VARCHAR2(10) | Y |  |  |
| 15 | `WRKORD` | VARCHAR2(15) | Y |  | 'NONE' |
| 16 | `WRKORDSEQ` | NUMBER | Y |  |  |
| 17 | `INNO` | VARCHAR2(20) | Y |  |  |
| 18 | `OUTNO` | VARCHAR2(20) | Y |  |  |
| 19 | `ORDERNO` | VARCHAR2(30) | Y |  |  |
| 20 | `ORDERSEQ` | NUMBER | Y |  |  |
| 21 | `INVOICENO` | VARCHAR2(30) | Y |  |  |
| 22 | `IQCNO` | NUMBER | Y |  |  |
| 23 | `BOXNO` | VARCHAR2(50) | Y |  | 'NONE' |
| 24 | `OPER` | VARCHAR2(6) | Y |  |  |
| 25 | `PRODLINE` | VARCHAR2(10) | Y |  |  |
| 26 | `SIDE` | VARCHAR2(1) | N |  | 'N' |
| 27 | `OUTSOURCINGFLAG` | VARCHAR2(1) | N |  | 'N' |
| 28 | `ERPFLAG` | VARCHAR2(1) | N |  | 'N' |
| 29 | `CLOSINGFLAG` | VARCHAR2(1) | N |  | 'N' |
| 30 | `UDF1` | NUMBER | Y |  |  |
| 31 | `UDF2` | NUMBER | Y |  |  |
| 32 | `UDF3` | NUMBER | Y |  |  |
| 33 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 34 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 35 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 36 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 37 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 38 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TW_IN_IDX1`  (CLIENT, COMPANY, PLANT, SERIAL)
- `TW_IN_IDX2`  (CLIENT, COMPANY, PLANT, BOXNO)
- `TW_IN_IDX3`  (CLIENT, COMPANY, PLANT, INDATE, TXNCODE)
- `TW_IN_PK` UNIQUE (CLIENT, COMPANY, PLANT, INDATE, SERIAL, ITEMCODE, STOCKTYPE, INQTY, TXNTIMEKEY, TXNCODE, WHLOC)

---

### TW_IQC
**IQC정보**
  행수: 3,639

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(5) | N | PK |  |
| 4 | `IQCNO` | VARCHAR2(30) | N | PK |  |
| 5 | `ORDERNO` | VARCHAR2(12) | Y |  |  |
| 6 | `ORDERSEQ` | NUMBER | Y |  |  |
| 7 | `INVOICENO` | VARCHAR2(30) | Y |  |  |
| 8 | `ITEMCODE` | NUMBER | Y |  |  |
| 9 | `IQCDATE` | VARCHAR2(8) | Y |  |  |
| 10 | `IQCQTY` | NUMBER | Y |  |  |
| 11 | `IQCJUDGE` | VARCHAR2(8) | Y |  |  |
| 12 | `LABISSNUM` | NUMBER | Y |  |  |
| 13 | `LABISSFLAG` | VARCHAR2(1) | N |  | 'N' |
| 14 | `FPATH` | VARCHAR2(1000) | Y |  |  |
| 15 | `DOCDATE` | VARCHAR2(8) | Y |  |  |
| 16 | `UDF2` | NUMBER | Y |  |  |
| 17 | `UDF3` | NUMBER | Y |  |  |
| 18 | `USEFLAG` | VARCHAR2(1) | N |  | 'Y' |
| 19 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 20 | `CREATETIMEKEY` | VARCHAR2(20) | N |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 21 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 22 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 23 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TW_IQC_PK` UNIQUE (CLIENT, COMPANY, PLANT, IQCNO)

---

### TW_MATERIALREQUSET
**자재 요청 정보**
  행수: 12,966

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `REQUESTDATE` | VARCHAR2(8) | N | PK |  |
| 5 | `REQUESTMATNO` | VARCHAR2(15) | N | PK |  |
| 6 | `SEQ` | NUMBER | N | PK |  |
| 7 | `ITEMCODE` | NUMBER | N |  |  |
| 8 | `ASSYUSAGE` | NUMBER | N |  |  |
| 9 | `REQUESTQTY` | NUMBER | N |  |  |
| 10 | `VENDOR` | VARCHAR2(10) | Y |  |  |
| 11 | `UDF2` | NUMBER | Y |  |  |
| 12 | `UDF3` | NUMBER | Y |  |  |
| 13 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 14 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 15 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 16 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 17 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 18 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TW_MATERIALREQUSET_PK` UNIQUE (CLIENT, COMPANY, PLANT, REQUESTDATE, REQUESTMATNO, SEQ)

---

### TW_MOUNT
**생산 자재 장착 정보**
  행수: 154,126

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `WRKORD` | VARCHAR2(30) | N | PK |  |
| 5 | `WRKORDSEQ` | NUMBER | N | PK |  |
| 6 | `PRODPROGNO` | VARCHAR2(30) | N | PK |  |
| 7 | `SERIAL` | VARCHAR2(30) | N | PK |  |
| 8 | `ITEMCODE` | NUMBER | N | PK |  |
| 9 | `SUBITEMCODE` | NUMBER | Y |  |  |
| 10 | `UNITNO` | VARCHAR2(10) | N | PK |  |
| 11 | `SIDE` | VARCHAR2(1) | N | PK | 'Y' |
| 12 | `SEQ` | NUMBER | N | PK |  |
| 13 | `STOCKQTY` | NUMBER | Y |  |  |
| 14 | `USAGE` | NUMBER | Y |  |  |
| 15 | `UDF1` | NUMBER | Y |  |  |
| 16 | `UDF2` | NUMBER | Y |  |  |
| 17 | `UDF3` | NUMBER | Y |  |  |
| 18 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 19 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 20 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 21 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 22 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 23 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TW_MOUNT_PK` UNIQUE (CLIENT, COMPANY, PLANT, WRKORD, WRKORDSEQ, PRODPROGNO, SERIAL, ITEMCODE, UNITNO, SIDE, SEQ)

---

### TW_OQC
**출고 이력(OQC)**
  행수: 59,396

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | N |  |  |
| 3 | `PLANT` | VARCHAR2(5) | N |  |  |
| 4 | `OUTDATE` | VARCHAR2(8) | N |  |  |
| 5 | `ITEMCODE` | NUMBER | N |  |  |
| 6 | `STOCKTYPE` | VARCHAR2(1) | N |  | 'G' |
| 7 | `OUTQTY` | NUMBER | N |  | 0 |
| 8 | `TXNTIMEKEY` | VARCHAR2(20) | N |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 9 | `TXNCODE` | VARCHAR2(5) | N |  |  |
| 10 | `WHLOC` | VARCHAR2(10) | N |  |  |
| 11 | `TOWHLOC` | VARCHAR2(10) | N |  |  |
| 12 | `OQCDATE` | VARCHAR2(8) | Y |  |  |
| 13 | `INNO` | VARCHAR2(20) | Y |  |  |
| 14 | `OUTNO` | VARCHAR2(20) | Y |  |  |
| 15 | `BOXNO` | VARCHAR2(50) | Y |  | 'NONE' |
| 16 | `ERPFLAG` | VARCHAR2(1) | N |  | 'N' |
| 17 | `UDF1` | NUMBER | Y |  |  |
| 18 | `UDF2` | NUMBER | Y |  |  |
| 19 | `UDF3` | NUMBER | Y |  |  |
| 20 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 21 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 22 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 23 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 24 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 25 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TW_OQC_IDX1`  (CLIENT, COMPANY, PLANT, BOXNO)
- `TW_OQC_PK` UNIQUE (CLIENT, COMPANY, PLANT, OUTDATE, BOXNO, TXNTIMEKEY)

---

### TW_OUT
**출고 이력**
  행수: 9,271,825

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(5) | N | PK |  |
| 4 | `OUTDATE` | VARCHAR2(8) | N | PK |  |
| 5 | `SERIAL` | VARCHAR2(50) | N | PK | 'NONE' |
| 6 | `ITEMCODE` | NUMBER | N | PK |  |
| 7 | `STOCKTYPE` | VARCHAR2(1) | N | PK | 'G' |
| 8 | `OUTQTY` | NUMBER | N | PK | 0 |
| 9 | `TXNTIMEKEY` | VARCHAR2(20) | N | PK | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 10 | `TXNCODE` | VARCHAR2(5) | N | PK |  |
| 11 | `WHLOC` | VARCHAR2(10) | N | PK |  |
| 12 | `VENDOR` | VARCHAR2(10) | Y |  |  |
| 13 | `TOWHLOC` | VARCHAR2(10) | Y |  |  |
| 14 | `TOVENDOR` | VARCHAR2(10) | Y |  |  |
| 15 | `WRKORD` | VARCHAR2(15) | Y |  |  |
| 16 | `WRKORDSEQ` | NUMBER | Y |  |  |
| 17 | `INNO` | VARCHAR2(20) | Y |  |  |
| 18 | `OUTNO` | VARCHAR2(20) | Y |  |  |
| 19 | `ORDERNO` | VARCHAR2(30) | Y |  |  |
| 20 | `ORDERSEQ` | NUMBER | Y |  |  |
| 21 | `INVOICENO` | VARCHAR2(30) | Y |  |  |
| 22 | `IQCNO` | NUMBER | Y |  |  |
| 23 | `BOXNO` | VARCHAR2(50) | Y |  | 'NONE' |
| 24 | `OPER` | VARCHAR2(6) | Y |  |  |
| 25 | `PRODLINE` | VARCHAR2(10) | Y |  |  |
| 26 | `SIDE` | VARCHAR2(1) | N |  | 'N' |
| 27 | `OUTSOURCINGFLAG` | VARCHAR2(1) | N |  | 'N' |
| 28 | `ERPFLAG` | VARCHAR2(1) | N |  | 'N' |
| 29 | `CLOSINGFLAG` | VARCHAR2(1) | N |  | 'N' |
| 30 | `RESPONSENO` | VARCHAR2(50) | Y |  |  |
| 31 | `UDF2` | NUMBER | Y |  |  |
| 32 | `UDF3` | NUMBER | Y |  |  |
| 33 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 34 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 35 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 36 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 37 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 38 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TW_OUT_IDX1`  (CLIENT, COMPANY, PLANT, SERIAL)
- `TW_OUT_IDX2`  (CLIENT, COMPANY, PLANT, BOXNO)
- `TW_OUT_IDX3`  (CLIENT, COMPANY, PLANT, WRKORD)
- `TW_OUT_IDX4`  (CLIENT, COMPANY, PLANT, RESPONSENO)
- `TW_OUT_PK` UNIQUE (CLIENT, COMPANY, PLANT, OUTDATE, SERIAL, ITEMCODE, STOCKTYPE, OUTQTY, TXNTIMEKEY, TXNCODE, WHLOC)

---

### TW_PRODHIST
**생산실적정보**
  행수: 6,354,665

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `TXNTIMEKEY` | VARCHAR2(20) | N | PK |  |
| 5 | `PRODDATE` | VARCHAR2(8) | N | PK |  |
| 6 | `PRODTYPE` | VARCHAR2(1) | N | PK | 'P' |
| 7 | `PRODPROGNO` | VARCHAR2(30) | N | PK |  |
| 8 | `ITEMCODE` | NUMBER | N | PK |  |
| 9 | `TXNCODE` | VARCHAR2(5) | N | PK |  |
| 10 | `SERIAL` | VARCHAR2(30) | N | PK |  |
| 11 | `PRODQTY` | NUMBER | Y |  |  |
| 12 | `WRKORD` | VARCHAR2(15) | Y |  | 'NONE' |
| 13 | `WRKORDSEQ` | NUMBER | Y |  |  |
| 14 | `UNITNO` | VARCHAR2(10) | Y |  |  |
| 15 | `BOXNO` | VARCHAR2(50) | Y |  |  |
| 16 | `JUDGE` | VARCHAR2(1) | Y |  | 'N' |
| 17 | `DEFECT` | VARCHAR2(10) | Y |  |  |
| 18 | `WHLOC` | VARCHAR2(10) | Y |  |  |
| 19 | `REWORK` | VARCHAR2(1) | Y |  |  |
| 20 | `UDF2` | NUMBER | Y |  |  |
| 21 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 22 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 23 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 24 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 25 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 26 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TW_PRODHIST_CLIENT_IDX`  (CLIENT, COMPANY, PLANT)
- `TW_PRODHIST_CLIENT_IDX2`  (CLIENT, COMPANY, PLANT, UNITNO)
- `TW_PRODHIST_IDX1`  (CLIENT, COMPANY, PLANT, WRKORD, UNITNO)
- `TW_PRODHIST_IDX2`  (CLIENT, COMPANY, PLANT, PRODDATE, ITEMCODE, UNITNO)
- `TW_PRODHIST_IDX3`  (CLIENT, COMPANY, PLANT, SERIAL)
- `TW_PRODHIST_PK` UNIQUE (CLIENT, COMPANY, PLANT, TXNTIMEKEY, PRODDATE, PRODTYPE, PRODPROGNO, ITEMCODE, TXNCODE, SERIAL)
- `TW_PRODHIST_SERIAL_IDX`  (SERIAL)

---

### TW_PRODHIST_USE
**생산 차감(사용) 자재 정보**
  행수: 7,628,428

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `PRODPROGNO` | VARCHAR2(30) | N | PK |  |
| 5 | `OUTNO` | VARCHAR2(20) | N | PK |  |
| 6 | `UNITNO` | VARCHAR2(10) | N | PK |  |
| 7 | `SEQ` | NUMBER | N | PK |  |
| 8 | `PRODSERIAL` | VARCHAR2(50) | N | PK |  |
| 9 | `USESERIAL` | VARCHAR2(50) | N | PK |  |
| 10 | `USEITEMCODE` | NUMBER | N | PK |  |
| 11 | `SIDE` | VARCHAR2(1) | N | PK |  |
| 12 | `USEQTY` | NUMBER | Y |  |  |
| 13 | `CREATETIMEKEY` | VARCHAR2(20) | N |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |

**인덱스:**

- `TW_PRODHIST_USE_CLIENT_IDX`  (CLIENT, COMPANY, PLANT, PRODSERIAL)
- `TW_PRODHIST_USE_IDX1`  (CLIENT, COMPANY, PLANT, PRODSERIAL, USESERIAL)
- `TW_PRODHIST_USE_PK` UNIQUE (CLIENT, COMPANY, PLANT, PRODPROGNO, OUTNO, UNITNO, SEQ, PRODSERIAL, USESERIAL, USEITEMCODE, SIDE)
- `TW_PRODHIST_USE_PRODSERIAL_IDX`  (PRODSERIAL)

---

### TW_RESPONSENO
**불출지시 테이블**
  행수: 17,378

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(10) | N | PK |  |
| 4 | `RESPONSENO` | VARCHAR2(50) | N | PK |  |
| 5 | `REQUESTMATNO` | VARCHAR2(50) | N | PK |  |
| 6 | `SEQ` | NUMBER | N | PK |  |
| 7 | `ITEMCODE` | NUMBER | N | PK |  |
| 8 | `PRINTFLAG` | VARCHAR2(1) | Y |  | 'N' |
| 9 | `REALOUTFLAG` | VARCHAR2(1) | Y |  | 'N' |
| 10 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 11 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 12 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 13 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TW_RESPONSENO_PK` UNIQUE (CLIENT, COMPANY, PLANT, RESPONSENO, REQUESTMATNO, SEQ, ITEMCODE)

---

### TW_STOCKMONTH
**월재고정보**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `YYMM` | VARCHAR2(6) | N |  |  |
| 2 | `WHLOC` | VARCHAR2(10) | N |  |  |
| 3 | `ITEMCODE` | NUMBER | N |  |  |
| 4 | `BOH` | NUMBER | Y |  | 0 |
| 5 | `MONTHINQTY` | NUMBER | Y |  | 0 |
| 6 | `STOCKTYPE` | VARCHAR2(1) | N |  | 'G' |
| 7 | `MONTHOUTQTY` | NUMBER | Y |  | 0 |
| 8 | `EOH` | NUMBER | Y |  | 0 |

---

### TW_STOCKSERIAL
**재고 현황**
  행수: 128,276

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(5) | N | PK |  |
| 4 | `SERIAL` | VARCHAR2(50) | N | PK | 'NONE' |
| 5 | `ITEMCODE` | NUMBER | N | PK |  |
| 6 | `WHLOC` | VARCHAR2(10) | N | PK |  |
| 7 | `GOODQTY` | NUMBER | Y |  | 0 |
| 8 | `BADQTY` | NUMBER | Y |  | 0 |
| 9 | `WRKORD` | VARCHAR2(15) | Y |  | NULL |
| 10 | `OPER` | VARCHAR2(6) | Y |  |  |
| 11 | `PRODLINE` | VARCHAR2(10) | Y |  |  |
| 12 | `LASTTXNTIMEKEY` | VARCHAR2(20) | Y |  |  |
| 13 | `LASTTXNCODE` | VARCHAR2(10) | Y |  |  |
| 14 | `UDF1` | NUMBER | Y |  |  |
| 15 | `UDF2` | NUMBER | Y |  |  |
| 16 | `UDF3` | NUMBER | Y |  |  |
| 17 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 18 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 19 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 20 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 21 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 22 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TW_STOCKSERIAL_IDX1`  (CLIENT, COMPANY, PLANT, WHLOC, ITEMCODE)
- `TW_STOCKSERIAL_IDX2`  (CLIENT, COMPANY, PLANT, WRKORD)
- `TW_STOCKSERIAL_IDX3`  (CLIENT, COMPANY, PLANT, SERIAL)
- `TW_STOCKSERIAL_IDX4`  (CLIENT, COMPANY, PLANT, WHLOC)
- `TW_STOCKSERIAL_PK` UNIQUE (CLIENT, COMPANY, PLANT, SERIAL, ITEMCODE, WHLOC)

---

### TW_STOCKSERIAL_MONTH
**월별 재고 현황**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `STOCKMONTH` | VARCHAR2(8) | N | PK |  |
| 2 | `SERIAL` | VARCHAR2(50) | N | PK | 'NONE' |
| 3 | `ITEMCODE` | NUMBER | N | PK |  |
| 4 | `WHLOC` | VARCHAR2(10) | N | PK |  |
| 5 | `LASTTXNTIMEKEY` | VARCHAR2(20) | Y |  |  |
| 6 | `LASTTXNCODE` | VARCHAR2(10) | Y |  |  |
| 7 | `GOODQTY` | NUMBER | Y |  | 0 |
| 8 | `BADQTY` | NUMBER | Y |  | 0 |
| 9 | `PRODLINE` | VARCHAR2(10) | Y |  |  |
| 10 | `OPER` | VARCHAR2(6) | Y |  |  |
| 11 | `CLIENT` | VARCHAR2(5) | Y |  |  |
| 12 | `COMPANY` | VARCHAR2(5) | Y |  |  |
| 13 | `PLANT` | VARCHAR2(10) | Y |  |  |
| 14 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 15 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 16 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 17 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |
| 18 | `CNTNO` | VARCHAR2(20) | N | PK | 'NONE' |
| 19 | `SIDE` | VARCHAR2(1) | N | PK | 'N' |
| 20 | `LOT` | VARCHAR2(30) | N | PK | 'NONE' |
| 21 | `WRKORD` | VARCHAR2(15) | N |  | 'NONE' |
| 22 | `PCBLOT` | VARCHAR2(10) | N | PK | 'NONE' |

**인덱스:**

- `TW_STOCKSERIAL_MONTH_PK` UNIQUE (STOCKMONTH, SERIAL, ITEMCODE, WHLOC, CNTNO, SIDE, LOT, PCBLOT)

---

### TW_STOCK_DATE
**일별 재고 현황**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | N |  |  |
| 3 | `PLANT` | VARCHAR2(5) | N |  |  |
| 4 | `STOCKDATE` | VARCHAR2(8) | N |  |  |
| 5 | `ITEMCODE` | NUMBER | N |  |  |
| 6 | `WHLOC` | VARCHAR2(10) | N |  |  |
| 7 | `STOCKQTY` | NUMBER | Y |  | 0 |
| 8 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 9 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 10 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 11 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

---

### TW_STOCK_DATE_CAL1
**일별 재고 현황 계산**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(5) | N | PK |  |
| 4 | `STOCKDATE` | VARCHAR2(8) | N | PK |  |
| 5 | `UPRITEM` | NUMBER | N | PK |  |
| 6 | `ITEMCODE` | NUMBER | N | PK |  |
| 7 | `STOCKQTY` | NUMBER | Y |  | 0 |
| 8 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 9 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 10 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 11 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TW_STOCK_DATE_CAL1_PK` UNIQUE (CLIENT, COMPANY, PLANT, STOCKDATE, UPRITEM, ITEMCODE)

---

### TW_WORKORD
**작업지시마스터정보**
  행수: 34,862

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | N | PK |  |
| 2 | `COMPANY` | VARCHAR2(5) | N | PK |  |
| 3 | `PLANT` | VARCHAR2(5) | N | PK |  |
| 4 | `WRKDATE` | VARCHAR2(8) | N | PK |  |
| 5 | `WRKORD` | VARCHAR2(15) | N | PK |  |
| 6 | `WRKORDSEQ` | NUMBER | N | PK | 1 |
| 7 | `WRKORDTYPE` | VARCHAR2(1) | N | PK |  |
| 8 | `WRKORDSTATE` | VARCHAR2(30) | N | PK |  |
| 9 | `BOMGRP` | VARCHAR2(30) | N | PK |  |
| 10 | `ITEMCODE` | NUMBER | N | PK |  |
| 11 | `ORDQTY` | NUMBER | N | PK |  |
| 12 | `UPRWRKORD` | VARCHAR2(15) | Y |  |  |
| 13 | `UPRWRKORDSEQ` | NUMBER | Y |  |  |
| 14 | `MATREQUESTNO` | VARCHAR2(15) | Y |  |  |
| 15 | `OPER` | VARCHAR2(6) | Y |  |  |
| 16 | `UNITNO` | VARCHAR2(10) | Y |  |  |
| 17 | `VENDOR` | VARCHAR2(10) | Y |  |  |
| 18 | `PLANSTARTTIME` | VARCHAR2(20) | Y |  |  |
| 19 | `PLANENDTIME` | VARCHAR2(20) | Y |  |  |
| 20 | `WRKSTARTTIME` | VARCHAR2(20) | Y |  |  |
| 21 | `WRKENDTIME` | VARCHAR2(20) | Y |  |  |
| 22 | `UDF1` | NUMBER | Y |  |  |
| 23 | `UDF2` | NUMBER | Y |  |  |
| 24 | `UDF3` | NUMBER | Y |  |  |
| 25 | `USEFLAG` | VARCHAR2(1) | Y |  | 'Y' |
| 26 | `REMARKS` | VARCHAR2(4000) | Y |  |  |
| 27 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  | TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MIS... |
| 28 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |
| 29 | `UPDATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 30 | `UPDATEUSER` | VARCHAR2(10) | Y |  |  |

**인덱스:**

- `TW_WORKORD_IDX1`  (CLIENT, COMPANY, PLANT, WRKORD, USEFLAG)
- `TW_WORKORD_PK` UNIQUE (CLIENT, COMPANY, PLANT, WRKDATE, WRKORD, WRKORDSEQ, WRKORDTYPE, WRKORDSTATE, BOMGRP, ITEMCODE, ORDQTY)

---

### T_CUSTOMPLAN
**사용자 정의 계획**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `ITEMCODE` | NUMBER | Y |  |  |
| 2 | `IDATE` | VARCHAR2(10) | Y |  |  |
| 3 | `QTY` | NUMBER | Y |  |  |

---

### T_NORMALDISTRIBUTION
**정규분포 데이터**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `ZVALUE` | NUMBER | Y |  |  |

---

### T_PACKING
**포장 정보**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | Y |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | Y |  |  |
| 3 | `PLANT` | VARCHAR2(10) | Y |  |  |
| 4 | `SERIAL` | VARCHAR2(50) | Y |  |  |

---

### T_SEQ_MAPPING
**시퀀스 매핑**
  행수: 31,423

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `ITEMCODE` | NUMBER | Y |  |  |
| 2 | `YYYYMMDD` | VARCHAR2(8) | Y |  |  |
| 3 | `SEQ` | NUMBER | Y |  |  |

---

### T_TIMETABLE
**시간표**

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `ORIGINALTIME` | VARCHAR2(5) | Y |  |  |
| 2 | `REMARKS` | VARCHAR2(20) | Y |  |  |
| 3 | `ORDERBY` | NUMBER | Y |  |  |

---

### VM_ERP_ORDER

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | Y |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | Y |  |  |
| 3 | `PLANT` | VARCHAR2(5) | Y |  |  |
| 4 | `ORDERDATE` | DATE | Y |  |  |
| 5 | `VENDOR` | VARCHAR2(13) | Y |  |  |
| 6 | `VENDORNAME` | VARCHAR2(100) | Y |  |  |
| 7 | `PARTNO` | VARCHAR2(20) | Y |  |  |
| 8 | `UNITQTY` | NUMBER | Y |  |  |
| 9 | `ORIGQTY` | NUMBER | Y |  |  |
| 10 | `PRTQTY` | NUMBER | Y |  |  |
| 11 | `SUMPRTQTY` | NUMBER | Y |  |  |
| 12 | `IQCQTY` | NUMBER | Y |  |  |
| 13 | `SUMIQCQTY` | NUMBER | Y |  |  |
| 14 | `RCQTY` | NUMBER | Y |  |  |
| 15 | `SUMRCQTY` | NUMBER | Y |  |  |
| 16 | `INVOICE` | VARCHAR2(30) | Y |  |  |
| 17 | `ORDERNO` | VARCHAR2(12) | Y |  |  |
| 18 | `ORDERSEQ` | NUMBER(3) | Y |  |  |
| 19 | `ITEMCODE` | NUMBER | Y |  |  |
| 20 | `LABELPRINTFLAG` | VARCHAR2(1) | Y |  |  |
| 21 | `IQCFLAG` | VARCHAR2(1) | Y |  |  |

---

### VW_CURRENT_STOCK

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | Y |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | Y |  |  |
| 3 | `PLANT` | VARCHAR2(5) | Y |  |  |
| 4 | `ITEMTYPE` | CHAR(1) | Y |  |  |
| 5 | `WHLOC` | VARCHAR2(10) | Y |  |  |
| 6 | `SERIAL` | VARCHAR2(50) | Y |  |  |
| 7 | `ITEMCODE` | NUMBER | Y |  |  |
| 8 | `STOCKTYPE` | CHAR(1) | Y |  |  |
| 9 | `QTY` | NUMBER | Y |  |  |

---

### VW_WORKTIME

| # | 컬럼명 | 타입 | NULL | PK | 기본값 |
|---|--------|------|------|----|--------|
| 1 | `CLIENT` | VARCHAR2(5) | Y |  |  |
| 2 | `COMPANY` | VARCHAR2(5) | Y |  |  |
| 3 | `PLANT` | VARCHAR2(10) | Y |  |  |
| 4 | `WORKDATE` | VARCHAR2(8) | Y |  |  |
| 5 | `UNITNO` | VARCHAR2(10) | Y |  |  |
| 6 | `WORKTIME` | VARCHAR2(8) | Y |  |  |
| 7 | `WORKER` | NUMBER | Y |  |  |
| 8 | `CREATETIMEKEY` | VARCHAR2(20) | Y |  |  |
| 9 | `CREATEUSER` | VARCHAR2(10) | Y |  |  |

---
