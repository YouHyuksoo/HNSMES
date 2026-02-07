# Phase 2: 데이터베이스 분석

## 2.1 Oracle DB 연결 정보

| 항목 | 값 |
|------|-----|
| **Site Name** | ESSDB |
| **Host** | 10.2.30.7 |
| **Port** | 1522 |
| **Service** | CDBHNSMES |
| **User** | MESUSER |

---

## 2.2 테이블 구조

### 2.2.1 테이블 통계

| 구분 | 수량 |
|------|------|
| **총 테이블 수** | 125개 |
| **마스터 테이블 (TM_*)** | 45개 |
| **트랜잭션 테이블 (TW_*, TH_*)** | 35개 |
| **임시/기타 테이블** | 45개 |

### 2.2.2 주요 마스터 테이블

| 테이블명 | 설명 | 레코드 수 |
|----------|------|-----------|
| `TM_USER` | 사용자 마스터 | 88 |
| `TM_ITEMS` | 품목 마스터 | 1,315 |
| `TM_BOM` | BOM 마스터 | 9,206 |
| `TM_BOX` | 박스/포장 마스터 | 94,083 |
| `TM_SERIAL` | 시리얼 마스터 | 1,868,570 |
| `TM_VENDOR` | 거래처 마스터 | 5 |
| `TM_WAREHOUSE` | 창고 마스터 | 6 |
| `TM_LOCATION` | 로케이션 마스터 | 10 |
| `TM_PRODLINE` | 생산라인 마스터 | 10 |
| `TM_MENU` | 메뉴 마스터 | 134 |

### 2.2.3 주요 트랜잭션 테이블

| 테이블명 | 설명 | 레코드 수 |
|----------|------|-----------|
| `TW_OUT` | 출고 이력 | 9,271,825 |
| `TW_PRODHIST_USE` | 생산 이력 (사용) | 7,628,428 |
| `TW_PRODHIST` | 생산 이력 | 6,354,665 |
| `TW_IN` | 입고 이력 | 1,750,960 |
| `TH_STOCKSERIAL` | 재고 시리얼 | 18,127,046 |
| `TW_MOUNT` | 장착 이력 | 154,126 |
| `TW_OQC` | OQC 검사 이력 | 59,396 |
| `TW_STOCKSERIAL` | 재고 시리얼 (월별) | 129,675 |
| `TW_WORKORD` | 작업지시 | 34,862 |

---

## 2.3 패키지 구조

### 2.3.1 패키지 목록

| 패키지명 | 설명 | 상태 |
|----------|------|------|
| **PKGBAS_BASE** | 기준정보 기본 | VALID |
| **PKGBAS_MAT** | 자재 기준정보 | VALID |
| **PKGBAS_BRD** | 불량/검사 기준 | VALID |
| **PKGMAT_INOUT** | 자재 입출고 | VALID |
| **PKGPRD_PROD** | 생산관리 | VALID |
| **PKGPRD_QC** | 품질관리 | VALID |
| **PKGPRD_MNT** | 보전관리 | VALID |
| **PKGPRD_HIST** | 생산이력 | VALID |
| **PKGPRD_CHECK** | 검사관리 | VALID |
| **PKGPRD_CURRENT** | 현황조회 | VALID |
| **PKGPRD_REPORT** | 생산리포트 | VALID |
| **PKGPRD_SALES** | 영업관련 | VALID |
| **PKGPRD_ECC** | ECC 연동 | VALID |
| **PKGSYS_USER** | 사용자관리 | VALID |
| **PKGSYS_MENU** | 메뉴관리 | VALID |
| **PKGSYS_COMM** | 공통코드 | VALID |
| **PKGSYS_DBA** | DBA 관리 | VALID |
| **PKGTXN_STOCK** | 재고관리 | VALID |
| **PKGTXN_MODBUS** | MODBUS 연동 | VALID |
| **PKGTXN_GATHERING** | 데이터수집 | INVALID |
| **PKGIF_ERP** | ERP 인터페이스 | INVALID |
| **PKGPDA_COMM** | PDA 공통 | VALID |
| **PKGPDA_MAT** | PDA 자재 | VALID |
| **PKGPDA_PROD** | PDA 생산 | VALID |
| **PKGPDA_SALES** | PDA 영업 | VALID |
| **PKGHNS_REPORT** | 행성 리포트 | VALID |
| **PKGDEV_KBS_TEMP** | 개발자 임시 | VALID |
| **GPKGBAS_BASE** | 글로벌 기준정보 | VALID |
| **GPKGPRD_PROD** | 글로벌 생산 | VALID |
| **PCK_GET_NORMDIST** | 통계함수 | VALID |

---

## 2.4 화면-프로시저 매핑

### 2.4.1 자재관리 (MAT) 화면 매핑

| 화면ID | 화멪명 | 주요 프로시저 |
|--------|--------|--------------|
| MATA201 | IQC검사등록 | PKGMAT_INOUT.GET_IQC_SERIAL, PKGMAT_INOUT.SET_IQC_JUDGE |
| MATA202 | 라벨발행 | PKGMAT_INOUT.GET_LABEL_ORDER, PKGMAT_INOUT.SET_REELSPLIT |
| MATA203 | 자재입고 | PKGPDA_MAT.SET_RECEIVE, PKGPDA_MAT.SET_IQCRECEIVE |
| MATA204 | 자재불출요청 | PKGMAT_INOUT.GET_PRODMATERIALREQUEST |
| MATA205 | 불량판정 | PKGBAS_BRD.SET_BADREG_JUDGE |
| MATA206 | 창고이동 | PKGPDA_MAT.SET_RELEASE |
| MATA207 | 재고조정 | PKGPDA_MAT.SET_STOCKCORRECT |
| MATA208 | 실사등록 | PKGTXN_STOCK.PUT_ACTUAL_UPLOAD |
| MATA209 | 생산불출 | PKGPDA_MAT.SET_RELEASE |
| MATA210 | 대체품등록 | PKGPDA_MAT.SET_REPLACEITEM |
| MATB201 | 입고현황 | PKGBAS_MAT.GET_RECEIVE_LIST |
| MATB202 | 입출고현황 | PKGBAS_MAT.GET_RECEIVE_RELEASE_LIST |
| MATB203 | 재고현황 | PKGBAS_MAT.GET_RECEIVE_RELEASE_LIST |
| MATB204 | 입출고취소 | PKGBAS_MAT.SET_CANCEL_MATERIAL_IN_OUT_XML |
| MATB205 | 라벨재발행 | PKGBAS_MAT.GET_LABEL_LIST |
| MATB206 | 재고조회(회사별) | PKGBAS_MAT.GET_MATERIAL_STOCK_INCOMPANY_A |
| MATB207 | 자재수불부 | PKGTXN_STOCK.GET_SUBUL |
| MATB208 | 불량자재조회 | PKGBAS_MAT.GET_BAD_MAT_LIST |
| MATB209 | OQC검사 | PKGBAS_OQC.PUT_BADREG_SN |
| MATB210 | 자재실적현황 | PKGBAS_MAT.GET_MATERIAL_ACTUAL |
| MATB211 | 재고실사현황 | PKGHNS_REPORT.GET_ACTUALSTOCK |
| MATB212 | 반품이력조회 | PKGBAS_BRD.GET_DEFECT_HISTORY3 |
| MATB213 | 장기재고현황 | PKGHNS_REPORT.GET_LONGSTOCK_LIST |
| MATB214 | 요청서출력 | PKGMAT_INOUT.GET_REQUESTPRINT |

### 2.4.2 생산관리 (PRD) 화면 매핑

| 화면ID | 화멪명 | 주요 프로시저 |
|--------|--------|--------------|
| PRDA201 | 작업실적등록 | PKGPRD_PROD.* |
| PRDA202 | 작업지시관리 | PKGPRD_PROD.* |
| PRDA203 | 생산현황모니터링 | PKGPRD_CURRENT.* |
| PRDA204 ~ PRDA222 | 기타 생산관리 | PKGPRD_* 패키지 활용 |
| PRDB201 ~ PRDB208 | 생산현황/리포트 | PKGPRD_REPORT.* |

### 2.4.3 기준정보 (MST) 화면 매핑

| 화면ID | 화멪명 | 주요 프로시저 |
|--------|--------|--------------|
| MSTA201 | 공장등록 | PKGBAS_BASE.PUT_PLANT |
| MSTA202 | 거래처등록 | PKGBAS_BASE.PUT_VENDOR |
| MSTA203 | 공정등록 | PKGBAS_BASE.PUT_OPER |
| MSTA204 | 사유코드등록 | PKGBAS_BASE.PUT_REASONCODE |
| MSTA205 | 품목등록 | PKGBAS_BASE.PUT_ITEM |
| MSTA206 | BOM등록 | PKGBAS_BASE.PUT_BOM, PKGBAS_BASE.PUT_BOMGRP |
| MSTA207 | 라우팅등록 | PKGBAS_BASE.PUT_ROUTINGGRP |
| MSTA208 | 불량유형등록 | PKGBAS_BASE.PUT_DEFECT |
| MSTA209 | 라인등록 | PKGBAS_BASE.PUT_LINE |
| MSTA210 | 창고등록 | PKGBAS_BASE.PUT_LOCATION |
| MSTA211 | 라인별설비등록 | PKGBAS_BASE.PUT_PRODLINE_UNIT |
| MSTA212 | 설비등록 | PKGBAS_BASE.PUT_EQP |
| MSTA213 | 품목이미지등록 | PKGBAS_BASE.SET_ITEMIMAGE |
| MSTA216 | 마감기준등록 | PKGBAS_BASE.PUT_CLOSINGBASE |
| MSTA217 | 크림핑기준등록 | PKGBAS_BASE.PUT_CRIMPINGBASE |
| MSTA218 | 근무시간등록 | PKGBAS_BASE.PUT_WORKTIME |
| MSTA219 | 모델BOM등록 | GPKGBAS_BASE.PUT_MODELBOM |
| MSTA220 | 애플리케이터등록 | PKGBAS_BASE.PUT_APPLICATOR |
| MSTA221 | 지그/PIN등록 | PKGBAS_BASE.SET_JIGPIN |

### 2.4.4 시스템관리 (SYS) 화면 매핑

| 화면ID | 화멪명 | 주요 프로시저 |
|--------|--------|--------------|
| SYSA201 | 용어사전관리 | PKGSYS_COMM.PUT_GLOSSARY |
| SYSA202 | 트랜잭션관리 | PKGSYS_COMM.PUT_TRANSACTION |
| SYSA203 | 공통코드관리 | PKGSYS_COMM.PUT_COMM |
| SYSA204 | 화면관리 | PKGSYS_MENU.PUT_FORMMST |
| SYSA205 | 메뉴관리 | PKGSYS_MENU.PUT_MENU |
| SYSA206 | 권한그룹관리 | PKGSYS_USER.PUT_ROLE |
| SYSA207 | 메뉴권한관리 | PKGSYS_MENU.PUT_MENUROLE |
| SYSA208 | 회사등록 | PKGSYS_COMM.PUT_COMPANY |
| SYSA209 | 부서등록 | PKGSYS_USER.PUT_DEPT |
| SYSA210 | 직급관리 | PKGSYS_USER.PUT_POST |
| SYSA211 | 사원등록 | PKGSYS_USER.PUT_EHR |
| SYSA212 | 단위관리 | PKGSYS_COMM.PUT_UNIT |
| SYSA213 | 공지사항관리 | PKGSYS_COMM.PUT_NOTICE |
| SYSA214 | 에러로그조회 | PKGSYS_COMM.GET_ERROR_LOG |
| SYSA215 | 테이블스페이스조회 | PKGSYS_DBA.GET_TABLESPACE_* |

### 2.4.5 보전관리 (MNT) 화면 매핑

| 화면ID | 화멪명 | 주요 프로시저 |
|--------|--------|--------------|
| MNTA201 | 생산모니터링 | PKGPRD_MNT.GET_DAILY_PROD_MONITERING |
| MNTA202 | 크림핑모니터링 | PKGPRD_MNT.GET_CRIMP_MONITORING |
| MNTA203 ~ MNTA204 | 생산현황 | PKGPRD_MNT.* |
| MNTB201 ~ MNTB207 | 리포트/현황 | PKGHNS_REPORT.* |

---

## 2.5 프로시저 호출 패턴 분석

### 2.5.1 명명 규칙

```
PKG<모듈>_<엔티티>.<동작>[_<대상>]

동작:
- GET_ : 조회
- SET_ : 저장/수정
- PUT_ : 등록/추가
- DEL_ : 삭제
- CHK_ : 체크/검증
- INS_ : 삽입
- UPD_ : 수정
```

### 2.5.2 호출 빈도 TOP 20

| 프로시저 패턴 | 호출 건수 |
|--------------|----------|
| PKGBAS_BASE.GET_* | 50+ |
| PKGBAS_BASE.PUT_* | 30+ |
| PKGMAT_INOUT.GET_* | 25+ |
| PKGMAT_INOUT.SET_* | 20+ |
| PKGSYS_USER.* | 15+ |
| PKGSYS_COMM.* | 15+ |
| PKGPRD_PROD.* | 20+ |
| PKGHNS_REPORT.GET_* | 25+ |
| PKGPDA_MAT.* | 15+ |
| PKGPDA_COMM.* | 10+ |

---

## 2.6 ERD 개요

### 2.6.1 핵심 엔티티 관계

```
[TM_CLIENT] 1:N [TM_COMPANY] 1:N [TM_PLANT]
                              |
                              v
[TM_ITEMS] 1:N [TM_BOM] N:1 [TM_BOMGRP]
     |
     v
[TM_SERIAL] 1:N [TW_PRODHIST] N:1 [TM_PRODLINE]
     |                          |
     v                          v
[TH_STOCKSERIAL]          [TW_OUT/TW_IN]
     |
     v
[TM_BOX]

[TM_USER] N:M [TM_USERROLE] M:1 [TM_MENUROLE]
     |                           |
     v                           v
[TH_USESYSTEMLOG]          [TM_MENU]
```

---

## 다음 단계

Phase 3에서는 다음을 진행합니다:
1. 주요 패키지 소스코드 상세 분석
2. 화면별 상세 워크플로우 작성
3. 전체 시스템 데이터 흐름도 작성
