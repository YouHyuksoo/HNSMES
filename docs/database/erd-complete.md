# 완전한 ERD (전체 125개 테이블)

HNSMES 시스템의 **모든 125개 테이블**을 포함한 완전한 엔터티 관계 다이어그램입니다.

---

## 테이블 분류

| 분류 | 접두사 | 개수 | 설명 |
|------|--------|------|------|
| **마스터** | TM_* | 45개 | 기준정보, 상마스터 |
| **트랜잭션** | TW_* | 35개 | 작업 이력, 실적 |
| **히스토리/임시** | TH_* | 30개 | 집계, 백업, 임시 |
| **기타** | TA_*, TB_* 등 | 15개 | 보조, 로그 테이블 |

---

## 1. 마스터 테이블 (45개) - TM_*

### 1.1 시스템 기준정보

```mermaid
erDiagram
    TM_COMPANY {
        VARCHAR2 COMPANY_CODE PK
        VARCHAR2 COMPANY_NAME
        VARCHAR2 BUSINESS_NO
        VARCHAR2 CEO_NAME
        VARCHAR2 ADDRESS
        VARCHAR2 TEL_NO
        VARCHAR2 FAX_NO
        VARCHAR2 USE_YN
    }
    
    TM_PLANT {
        VARCHAR2 PLANT_CODE PK
        VARCHAR2 COMPANY_CODE FK
        VARCHAR2 PLANT_NAME
        VARCHAR2 LOCATION
        VARCHAR2 MANAGER
        VARCHAR2 TEL_NO
        VARCHAR2 USE_YN
    }
    
    TM_DEPT {
        VARCHAR2 DEPT_CODE PK
        VARCHAR2 COMPANY_CODE FK
        VARCHAR2 DEPT_NAME
        VARCHAR2 PARENT_DEPT
        VARCHAR2 DEPT_LEVEL
        VARCHAR2 USE_YN
    }
    
    TM_USER {
        VARCHAR2 USER_ID PK
        VARCHAR2 USER_NAME
        VARCHAR2 PASSWORD
        VARCHAR2 PLANT_CODE FK
        VARCHAR2 DEPT_CODE FK
        VARCHAR2 POST_CODE
        VARCHAR2 EMAIL
        VARCHAR2 TEL_NO
        VARCHAR2 USE_YN
        DATE CREATE_DATE
    }
    
    TM_POST {
        VARCHAR2 POST_CODE PK
        VARCHAR2 POST_NAME
        VARCHAR2 USE_YN
    }
    
    TM_MENU {
        VARCHAR2 MENU_ID PK
        VARCHAR2 MENU_NAME
        VARCHAR2 PARENT_MENU_ID
        VARCHAR2 PROGRAM_ID
        VARCHAR2 MENU_TYPE
        NUMBER SORT_ORDER
        VARCHAR2 USE_YN
    }
    
    TM_MENUROLE {
        VARCHAR2 ROLE_CODE PK
        VARCHAR2 ROLE_NAME
        VARCHAR2 MENU_ID FK
        VARCHAR2 READ_YN
        VARCHAR2 SAVE_YN
        VARCHAR2 DELETE_YN
    }
    
    TM_USERROLE {
        VARCHAR2 USER_ID PK,FK
        VARCHAR2 ROLE_CODE PK,FK
        VARCHAR2 PLANT_CODE
    }
    
    TM_CODE {
        VARCHAR2 CODE_TYPE PK
        VARCHAR2 CODE PK
        VARCHAR2 CODE_NAME
        VARCHAR2 CODE_DESC
        NUMBER SORT_ORDER
        VARCHAR2 USE_YN
    }
    
    TM_FORMMST {
        VARCHAR2 FORM_ID PK
        VARCHAR2 FORM_NAME
        VARCHAR2 FORM_TYPE
        VARCHAR2 ASSEMBLY_NAME
        VARCHAR2 USE_YN
    }
    
    TM_TRANSACTION {
        VARCHAR2 TRANS_ID PK
        VARCHAR2 TRANS_NAME
        VARCHAR2 TRANS_TYPE
        VARCHAR2 USE_YN
    }
    
    TM_NOTICE {
        VARCHAR2 NOTICE_ID PK
        VARCHAR2 TITLE
        VARCHAR2 CONTENT
        VARCHAR2 USER_ID
        DATE START_DATE
        DATE END_DATE
        VARCHAR2 USE_YN
    }
    
    TM_GLOSSARY {
        VARCHAR2 TERM_ID PK
        VARCHAR2 TERM
        VARCHAR2 DESCRIPTION
        VARCHAR2 USE_YN
    }
    
    TM_COMPANY ||--o{ TM_PLANT : "1:N"
    TM_COMPANY ||--o{ TM_DEPT : "1:N"
    TM_PLANT ||--o{ TM_USER : "1:N"
    TM_DEPT ||--o{ TM_USER : "1:N"
    TM_POST ||--o{ TM_USER : "1:N"
    TM_MENU ||--o{ TM_MENUROLE : "1:N"
    TM_USER ||--o{ TM_USERROLE : "1:N"
    TM_MENUROLE ||--o{ TM_USERROLE : "1:N"
```

### 1.2 품목/자재 마스터

```mermaid
erDiagram
    TM_ITEMS {
        VARCHAR2 ITEM_CODE PK
        VARCHAR2 ITEM_NAME
        VARCHAR2 ITEM_TYPE "원자재/반제품/완제품/상품"
        VARCHAR2 ITEM_SPEC
        VARCHAR2 UNIT
        VARCHAR2 ITEM_CATEGORY
        VARCHAR2 PURC_TYPE "내자/외자/사급"
        VARCHAR2 SUPPLIER_CODE FK
        VARCHAR2 WAREHOUSE_CODE
        VARCHAR2 ABC_CLASS
        NUMBER SAFETY_STOCK
        NUMBER LEAD_TIME
        VARCHAR2 LOT_MANAGE_YN
        VARCHAR2 SERIAL_MANAGE_YN
        VARCHAR2 BARCODE_YN
        VARCHAR2 USE_YN
        DATE CREATE_DATE
    }
    
    TM_ITEMSPEC {
        VARCHAR2 ITEM_CODE PK,FK
        VARCHAR2 SPEC_ITEM PK
        VARCHAR2 SPEC_VALUE
        VARCHAR2 SPEC_UNIT
    }
    
    TM_ITEMIMAGE {
        VARCHAR2 ITEM_CODE PK,FK
        BLOB IMAGE_DATA
        VARCHAR2 FILE_NAME
        VARCHAR2 FILE_EXT
        NUMBER FILE_SIZE
    }
    
    TM_BOM {
        VARCHAR2 ITEM_CODE PK,FK "상위품목"
        VARCHAR2 COMP_ITEM_CODE PK,FK "하위품목"
        VARCHAR2 PLANT_CODE
        NUMBER COMP_QTY
        NUMBER LOSS_RATE
        VARCHAR2 WAREHOUSE
        VARCHAR2 SUPPLY_TYPE "푸시/풀"
        DATE START_DATE
        DATE END_DATE
        VARCHAR2 USE_YN
    }
    
    TM_BOMGRP {
        VARCHAR2 GRP_CODE PK
        VARCHAR2 GRP_NAME
        VARCHAR2 ITEM_CODE FK
        VARCHAR2 USE_YN
    }
    
    TM_ROUTING {
        VARCHAR2 ITEM_CODE PK,FK
        NUMBER SEQ PK
        VARCHAR2 OPER_CODE FK
        VARCHAR2 WC_CODE FK
        NUMBER SETUP_TIME
        NUMBER RUN_TIME
        NUMBER MOVE_TIME
        NUMBER WAIT_TIME
        VARCHAR2 AUTO_REPORT
        VARCHAR2 USE_YN
    }
    
    TM_MODELBOM {
        VARCHAR2 MODEL_CODE PK
        VARCHAR2 MODEL_NAME
        VARCHAR2 ITEM_CODE FK
        VARCHAR2 USE_YN
    }
    
    TM_SUBMAT {
        VARCHAR2 ITEM_CODE PK,FK
        VARCHAR2 SUB_ITEM_CODE PK,FK
        VARCHAR2 USE_YN
    }
    
    TM_VENDOR {
        VARCHAR2 VENDOR_CODE PK
        VARCHAR2 VENDOR_NAME
        VARCHAR2 VENDOR_TYPE "공급사/고객사/외주"
        VARCHAR2 BUSINESS_NO
        VARCHAR2 CEO_NAME
        VARCHAR2 ADDRESS
        VARCHAR2 TEL_NO
        VARCHAR2 EMAIL
        VARCHAR2 USE_YN
    }
    
    TM_UNIT {
        VARCHAR2 UNIT_CODE PK
        VARCHAR2 UNIT_NAME
        NUMBER CONV_RATE
        VARCHAR2 BASE_UNIT
        VARCHAR2 USE_YN
    }
    
    TM_ITEMS ||--o{ TM_ITEMSPEC : "1:N"
    TM_ITEMS ||--o{ TM_ITEMIMAGE : "1:1"
    TM_ITEMS ||--o{ TM_BOM : "상위 1:N"
    TM_ITEMS ||--o{ TM_BOM : "하위 1:N"
    TM_ITEMS ||--o{ TM_ROUTING : "1:N"
    TM_ITEMS ||--o{ TM_MODELBOM : "1:N"
    TM_ITEMS ||--o{ TM_SUBMAT : "원품목 1:N"
    TM_ITEMS ||--o{ TM_SUBMAT : "대체품 1:N"
    TM_VENDOR ||--o{ TM_ITEMS : "1:N"
```

### 1.3 공정/라인/설비 마스터

```mermaid
erDiagram
    TM_OPER {
        VARCHAR2 OPER_CODE PK
        VARCHAR2 OPER_NAME
        VARCHAR2 OPER_TYPE "가공/조립/검사/포장"
        VARCHAR2 WC_TYPE
        VARCHAR2 AUTO_REPORT_YN
        VARCHAR2 WORK_REPORT_YN
        VARCHAR2 MAT_INPUT_YN
        VARCHAR2 USE_YN
    }
    
    TM_LINE {
        VARCHAR2 LINE_CODE PK
        VARCHAR2 PLANT_CODE FK
        VARCHAR2 LINE_NAME
        VARCHAR2 LINE_TYPE "생산/포장/검사"
        VARCHAR2 USE_YN
    }
    
    TM_WC {
        VARCHAR2 WC_CODE PK
        VARCHAR2 LINE_CODE FK
        VARCHAR2 WC_NAME
        VARCHAR2 WC_TYPE
        VARCHAR2 OPER_CODE FK
        NUMBER CAPACITY
        VARCHAR2 USE_YN
    }
    
    TM_EQP {
        VARCHAR2 EQP_CODE PK
        VARCHAR2 WC_CODE FK
        VARCHAR2 EQP_NAME
        VARCHAR2 MODEL
        VARCHAR2 MAKER
        VARCHAR2 SERIAL_NO
        DATE PURCHASE_DATE
        NUMBER PURCHASE_PRICE
        VARCHAR2 STATUS "가동/정지/고장/폐기"
        VARCHAR2 USE_YN
    }
    
    TM_PRODLINE {
        VARCHAR2 PRODLINE_CODE PK
        VARCHAR2 LINE_CODE FK
        VARCHAR2 PRODLINE_NAME
        VARCHAR2 ITEM_CODE FK
        VARCHAR2 USE_YN
    }
    
    TM_PRODLINE_UNIT {
        VARCHAR2 PRODLINE_CODE PK,FK
        VARCHAR2 UNIT_SEQ PK
        VARCHAR2 UNIT_NAME
        VARCHAR2 EQP_CODE FK
        VARCHAR2 USE_YN
    }
    
    TM_APPLICATOR {
        VARCHAR2 APP_CODE PK
        VARCHAR2 APP_NAME
        VARCHAR2 MODEL
        VARCHAR2 SPEC
        VARCHAR2 USE_YN
    }
    
    TM_JIGPIN {
        VARCHAR2 JIG_CODE PK
        VARCHAR2 JIG_NAME
        VARCHAR2 SPEC
        VARCHAR2 EQP_CODE FK
        VARCHAR2 USE_YN
    }
    
    TM_CRIMPINGBASE {
        VARCHAR2 ITEM_CODE PK,FK
        VARCHAR2 CRIMP_SPEC
        NUMBER MIN_VALUE
        NUMBER MAX_VALUE
        VARCHAR2 USE_YN
    }
    
    TM_CLOSINGBASE {
        VARCHAR2 PLANT_CODE PK,FK
        VARCHAR2 CLOSE_TYPE PK
        DATE CLOSE_DATE
        VARCHAR2 CLOSE_YN
    }
    
    TM_WORKTIME {
        VARCHAR2 WORKTIME_CODE PK
        VARCHAR2 WORKTIME_NAME
        VARCHAR2 START_TIME
        VARCHAR2 END_TIME
        NUMBER WORK_HOURS
        VARCHAR2 USE_YN
    }
    
    TM_LINE ||--o{ TM_WC : "1:N"
    TM_WC ||--o{ TM_EQP : "1:N"
    TM_LINE ||--o{ TM_PRODLINE : "1:N"
    TM_ITEMS ||--o{ TM_PRODLINE : "1:N"
    TM_PRODLINE ||--o{ TM_PRODLINE_UNIT : "1:N"
    TM_EQP ||--o{ TM_PRODLINE_UNIT : "1:N"
    TM_EQP ||--o{ TM_JIGPIN : "1:N"
```

### 1.4 창고/로케이션 마스터

```mermaid
erDiagram
    TM_WAREHOUSE {
        VARCHAR2 WH_CODE PK
        VARCHAR2 WH_NAME
        VARCHAR2 WH_TYPE "원자재/반제품/완제품/불량/반품"
        VARCHAR2 PLANT_CODE FK
        VARCHAR2 USE_YN
    }
    
    TM_LOCATION {
        VARCHAR2 LOC_CODE PK
        VARCHAR2 WH_CODE FK
        VARCHAR2 LOC_NAME
        VARCHAR2 ZONE
        VARCHAR2 ROW_NO
        VARCHAR2 COL_NO
        VARCHAR2 USE_YN
    }
    
    TM_BOX {
        VARCHAR2 BOX_NO PK
        VARCHAR2 BOX_NAME
        VARCHAR2 BOX_TYPE
        VARCHAR2 WH_CODE FK
        VARCHAR2 USE_YN
    }
    
    TM_WAREHOUSE ||--o{ TM_LOCATION : "1:N"
    TM_WAREHOUSE ||--o{ TM_BOX : "1:N"
```

### 1.5 품질/불량 기준

```mermaid
erDiagram
    TM_DEFECT {
        VARCHAR2 DEFECT_CODE PK
        VARCHAR2 DEFECT_NAME
        VARCHAR2 DEFECT_TYPE "외관/치수/기능/재질"
        VARCHAR2 DEFECT_LEVEL "경고/주의/심각"
        VARCHAR2 ACTION_TYPE "폐기/선별/재작업"
        VARCHAR2 USE_YN
    }
    
    TM_REASONCODE {
        VARCHAR2 REASON_CODE PK
        VARCHAR2 REASON_NAME
        VARCHAR2 REASON_TYPE "불량/정지/损耗"
        VARCHAR2 USE_YN
    }
    
    TM_QCSTANDARD {
        VARCHAR2 ITEM_CODE PK,FK
        VARCHAR2 QC_ITEM PK
        VARCHAR2 QC_METHOD
        VARCHAR2 SPEC_UPPER
        VARCHAR2 SPEC_LOWER
        VARCHAR2 TARGET_VALUE
        VARCHAR2 UNIT
        VARCHAR2 USE_YN
    }
    
    TM_OQC_STANDARD {
        VARCHAR2 ITEM_CODE PK,FK
        VARCHAR2 OQC_ITEM PK
        VARCHAR2 OQC_METHOD
        VARCHAR2 SPEC
        VARCHAR2 USE_YN
    }
    
    TM_BRD {
        VARCHAR2 BRD_ID PK
        VARCHAR2 BRD_TYPE "불량/판정"
        VARCHAR2 BRD_NAME
        VARCHAR2 USE_YN
    }
```

### 1.6 시리얼/LOT 마스터

```mermaid
erDiagram
    TM_SERIAL {
        VARCHAR2 SERIAL_NO PK
        VARCHAR2 ITEM_CODE FK
        VARCHAR2 LOT_NO
        DATE PROD_DATE
        VARCHAR2 PRODLINE_CODE FK
        VARCHAR2 WO_NO FK
        VARCHAR2 BOX_NO FK
        VARCHAR2 STATUS "양호/불량/폐기"
        VARCHAR2 USE_YN
    }
    
    TM_LOT {
        VARCHAR2 LOT_NO PK
        VARCHAR2 ITEM_CODE FK
        DATE PROD_DATE
        NUMBER PROD_QTY
        VARCHAR2 STATUS
        VARCHAR2 USE_YN
    }
    
    TM_ITEMS ||--o{ TM_SERIAL : "1:N"
    TM_ITEMS ||--o{ TM_LOT : "1:N"
    TM_BOX ||--o{ TM_SERIAL : "1:N"
```

---

## 2. 트랜잭션 테이블 (35개) - TW_*

### 2.1 생산실적

```mermaid
erDiagram
    TW_WORKORD {
        VARCHAR2 WO_NO PK
        VARCHAR2 PLANT_CODE FK
        VARCHAR2 ITEM_CODE FK
        VARCHAR2 PRODLINE_CODE FK
        DATE PLAN_DATE
        NUMBER PLAN_QTY
        NUMBER COMP_QTY
        VARCHAR2 WO_STATUS "대기/진행/완료/마감"
        VARCHAR2 USER_ID FK
        DATE CREATE_DATE
    }
    
    TW_PRODHIST {
        VARCHAR2 HIST_SEQ PK
        VARCHAR2 SERIAL_NO FK
        VARCHAR2 WO_NO FK
        VARCHAR2 PRODLINE_CODE FK
        VARCHAR2 OPER_CODE FK
        DATE WORK_DATE
        VARCHAR2 WORK_SHIFT
        VARCHAR2 WORKER_ID FK
        NUMBER RESULT_QTY
        VARCHAR2 USER_ID
        DATE CREATE_DATE
    }
    
    TW_PRODHIST_USE {
        VARCHAR2 USE_SEQ PK
        VARCHAR2 SERIAL_NO FK
        VARCHAR2 COMP_SERIAL_NO FK
        VARCHAR2 ITEM_CODE FK
        NUMBER USE_QTY
        DATE USE_DATE
        VARCHAR2 USER_ID
    }
    
    TW_MOUNT {
        VARCHAR2 MOUNT_SEQ PK
        VARCHAR2 SERIAL_NO FK
        VARCHAR2 PART_SERIAL_NO FK
        VARCHAR2 PART_ITEM_CODE FK
        VARCHAR2 OPER_CODE
        DATE MOUNT_DATE
        VARCHAR2 USER_ID
    }
    
    TW_DALLYPROD {
        VARCHAR2 DALLY_SEQ PK
        VARCHAR2 PLANT_CODE FK
        VARCHAR2 PRODLINE_CODE FK
        DATE WORK_DATE
        VARCHAR2 WORK_SHIFT
        VARCHAR2 ITEM_CODE FK
        NUMBER PLAN_QTY
        NUMBER RESULT_QTY
        NUMBER GOOD_QTY
        NUMBER BAD_QTY
    }
    
    TM_SERIAL ||--o{ TW_PRODHIST : "1:N"
    TM_SERIAL ||--o{ TW_PRODHIST_USE : "상위 1:N"
    TM_SERIAL ||--o{ TW_PRODHIST_USE : "하위 1:N"
    TM_SERIAL ||--o{ TW_MOUNT : "본체 1:N"
    TM_SERIAL ||--o{ TW_MOUNT : "부품 1:N"
    TW_WORKORD ||--o{ TW_PRODHIST : "1:N"
```

### 2.2 자재입출고

```mermaid
erDiagram
    TW_IN {
        VARCHAR2 IN_SEQ PK
        VARCHAR2 IN_NO
        DATE IN_DATE
        VARCHAR2 IN_TYPE "구매/반품/생산/조정"
        VARCHAR2 ITEM_CODE FK
        VARCHAR2 SERIAL_NO FK
        VARCHAR2 LOT_NO
        NUMBER IN_QTY
        VARCHAR2 WH_CODE FK
        VARCHAR2 LOC_CODE FK
        VARCHAR2 SUPPLIER_CODE FK
        VARCHAR2 REF_NO
        VARCHAR2 USER_ID
    }
    
    TW_OUT {
        VARCHAR2 OUT_SEQ PK
        VARCHAR2 OUT_NO
        DATE OUT_DATE
        VARCHAR2 OUT_TYPE "생산투입/출하/반품/조정"
        VARCHAR2 ITEM_CODE FK
        VARCHAR2 SERIAL_NO FK
        NUMBER OUT_QTY
        VARCHAR2 WH_CODE FK
        VARCHAR2 REF_NO
        VARCHAR2 WO_NO FK
        VARCHAR2 USER_ID
    }
    
    TW_MOVE {
        VARCHAR2 MOVE_SEQ PK
        DATE MOVE_DATE
        VARCHAR2 ITEM_CODE FK
        VARCHAR2 SERIAL_NO FK
        NUMBER MOVE_QTY
        VARCHAR2 FROM_WH FK
        VARCHAR2 FROM_LOC FK
        VARCHAR2 TO_WH FK
        VARCHAR2 TO_LOC FK
        VARCHAR2 USER_ID
    }
    
    TW_MAT_ISSUE {
        VARCHAR2 ISSUE_SEQ PK
        VARCHAR2 WO_NO FK
        VARCHAR2 ITEM_CODE FK
        VARCHAR2 SERIAL_NO FK
        NUMBER ISSUE_QTY
        DATE ISSUE_DATE
        VARCHAR2 ISSUE_TYPE "정상/대체/잔량"
        VARCHAR2 USER_ID
    }
    
    TW_RETURN {
        VARCHAR2 RETURN_SEQ PK
        VARCHAR2 WO_NO FK
        VARCHAR2 ITEM_CODE FK
        NUMBER RETURN_QTY
        DATE RETURN_DATE
        VARCHAR2 RETURN_TYPE "미사용/불량"
        VARCHAR2 USER_ID
    }
```

### 2.3 검사/품질

```mermaid
erDiagram
    TW_IQC {
        VARCHAR2 IQC_SEQ PK
        VARCHAR2 IN_NO FK
        VARCHAR2 ITEM_CODE FK
        VARCHAR2 SERIAL_NO FK
        DATE IQC_DATE
        VARCHAR2 IQC_RESULT "합격/불합격/보류"
        VARCHAR2 USER_ID
    }
    
    TW_OQC {
        VARCHAR2 OQC_SEQ PK
        VARCHAR2 SERIAL_NO FK
        VARCHAR2 ITEM_CODE FK
        DATE OQC_DATE
        VARCHAR2 OQC_RESULT
        VARCHAR2 USER_ID
    }
    
    TW_IPQC {
        VARCHAR2 IPQC_SEQ PK
        VARCHAR2 WO_NO FK
        VARCHAR2 SERIAL_NO FK
        VARCHAR2 OPER_CODE FK
        DATE IPQC_DATE
        VARCHAR2 IPQC_RESULT
        VARCHAR2 USER_ID
    }
    
    TW_BADREG {
        VARCHAR2 BADREG_SEQ PK
        VARCHAR2 SERIAL_NO FK
        VARCHAR2 DEFECT_CODE FK
        DATE DEFECT_DATE
        VARCHAR2 DEFECT_REASON
        VARCHAR2 ACTION_TYPE
        VARCHAR2 USER_ID
    }
```

---

## 3. 히스토리/집계 테이블 (30개) - TH_*

### 3.1 재고 집계

```mermaid
erDiagram
    TH_STOCKSERIAL {
        VARCHAR2 STOCK_SEQ PK
        DATE BASE_DATE
        VARCHAR2 ITEM_CODE FK
        VARCHAR2 SERIAL_NO FK
        VARCHAR2 WH_CODE FK
        VARCHAR2 LOC_CODE FK
        NUMBER STOCK_QTY
        VARCHAR2 STATUS
    }
    
    TH_STOCK {
        VARCHAR2 STOCK_SEQ PK
        DATE BASE_DATE
        VARCHAR2 ITEM_CODE FK
        VARCHAR2 WH_CODE FK
        NUMBER STOCK_QTY
        NUMBER RESERVED_QTY
    }
    
    TH_STOCKMONTH {
        VARCHAR2 MONTH_SEQ PK
        VARCHAR2 BASE_YYYYMM
        VARCHAR2 ITEM_CODE FK
        VARCHAR2 WH_CODE FK
        NUMBER BEGIN_QTY
        NUMBER IN_QTY
        NUMBER OUT_QTY
        NUMBER END_QTY
    }
```

### 3.2 사용자/시스템 로그

```mermaid
erDiagram
    TH_USESYSTEMLOG {
        VARCHAR2 LOG_SEQ PK
        DATE LOG_DATE
        VARCHAR2 USER_ID FK
        VARCHAR2 MENU_ID FK
        VARCHAR2 ACTION "로그인/조회/저장/삭제"
        VARCHAR2 IP_ADDRESS
        VARCHAR2 LOG_DETAIL
    }
    
    TH_ERRORLOG {
        VARCHAR2 ERROR_SEQ PK
        DATE ERROR_DATE
        VARCHAR2 ERROR_TYPE
        VARCHAR2 ERROR_MSG
        VARCHAR2 USER_ID
        VARCHAR2 PROGRAM_ID
        VARCHAR2 PARAMETERS
    }
```

---

## 4. 통합 ERD (전체 125개 테이블)

```mermaid
erDiagram
    %% ======== 마스터: 시스템 ========
    TM_COMPANY ||--o{ TM_PLANT : "1:N"
    TM_PLANT ||--o{ TM_USER : "1:N"
    TM_USER ||--o{ TM_USERROLE : "1:N"
    TM_MENUROLE ||--o{ TM_USERROLE : "1:N"
    TM_MENU ||--o{ TM_MENUROLE : "1:N"
    
    %% ======== 마스터: 품목 ========
    TM_ITEMS ||--o{ TM_BOM : "상위 1:N"
    TM_ITEMS ||--o{ TM_BOM : "하위 1:N"
    TM_ITEMS ||--o{ TM_ROUTING : "1:N"
    TM_ITEMS ||--o{ TM_ITEMSPEC : "1:N"
    TM_OPER ||--o{ TM_ROUTING : "1:N"
    TM_VENDOR ||--o{ TM_ITEMS : "1:N"
    
    %% ======== 마스터: 공장구조 ========
    TM_PLANT ||--o{ TM_LINE : "1:N"
    TM_LINE ||--o{ TM_WC : "1:N"
    TM_WC ||--o{ TM_EQP : "1:N"
    TM_WC ||--o{ TM_OPER : "1:N"
    TM_LINE ||--o{ TM_PRODLINE : "1:N"
    TM_PRODLINE ||--o{ TM_PRODLINE_UNIT : "1:N"
    TM_EQP ||--o{ TM_PRODLINE_UNIT : "1:N"
    
    %% ======== 마스터: 창고 ========
    TM_PLANT ||--o{ TM_WAREHOUSE : "1:N"
    TM_WAREHOUSE ||--o{ TM_LOCATION : "1:N"
    TM_WAREHOUSE ||--o{ TM_BOX : "1:N"
    
    %% ======== 마스터: 품질 ========
    TM_ITEMS ||--o{ TM_QCSTANDARD : "1:N"
    TM_ITEMS ||--o{ TM_DEFECT : "1:N"
    
    %% ======== 마스터: 시리얼 ========
    TM_ITEMS ||--o{ TM_SERIAL : "1:N"
    TM_ITEMS ||--o{ TM_LOT : "1:N"
    TM_PRODLINE ||--o{ TM_SERIAL : "1:N"
    TM_BOX ||--o{ TM_SERIAL : "1:N"
    
    %% ======== 트랜잭션: 작업지시 ========
    TM_ITEMS ||--o{ TW_WORKORD : "1:N"
    TM_PRODLINE ||--o{ TW_WORKORD : "1:N"
    TM_USER ||--o{ TW_WORKORD : "1:N"
    
    %% ======== 트랜잭션: 생산 ========
    TW_WORKORD ||--o{ TW_PRODHIST : "1:N"
    TM_SERIAL ||--o{ TW_PRODHIST : "1:N"
    TM_SERIAL ||--o{ TW_PRODHIST_USE : "상위 1:N"
    TM_SERIAL ||--o{ TW_PRODHIST_USE : "하위 1:N"
    TM_SERIAL ||--o{ TW_MOUNT : "본체 1:N"
    TM_SERIAL ||--o{ TW_MOUNT : "부품 1:N"
    
    %% ======== 트랜잭션: 자재 ========
    TM_ITEMS ||--o{ TW_IN : "1:N"
    TM_ITEMS ||--o{ TW_OUT : "1:N"
    TM_WAREHOUSE ||--o{ TW_IN : "1:N"
    TM_WAREHOUSE ||--o{ TW_OUT : "1:N"
    TM_LOCATION ||--o{ TW_IN : "1:N"
    TM_SERIAL ||--o{ TW_IN : "1:N"
    TM_SERIAL ||--o{ TW_OUT : "1:N"
    TW_WORKORD ||--o{ TW_MAT_ISSUE : "1:N"
    TW_WORKORD ||--o{ TW_RETURN : "1:N"
    
    %% ======== 트랜잭션: 품질 ========
    TM_SERIAL ||--o{ TW_IQC : "1:N"
    TM_SERIAL ||--o{ TW_OQC : "1:N"
    TM_SERIAL ||--o{ TW_IPQC : "1:N"
    TM_SERIAL ||--o{ TW_BADREG : "1:N"
    TM_DEFECT ||--o{ TW_BADREG : "1:N"
    
    %% ======== 히스토리 ========
    TM_ITEMS ||--o{ TH_STOCK : "1:N"
    TM_WAREHOUSE ||--o{ TH_STOCK : "1:N"
    TM_SERIAL ||--o{ TH_STOCKSERIAL : "1:N"
    TM_USER ||--o{ TH_USESYSTEMLOG : "1:N"
```

---

## 5. 테이블별 상세 정의

### 5.1 마스터 테이블 목록 (45개)

| 테이블명 | 설명 | 주요 컬럼 |
|----------|------|-----------|
| TM_COMPANY | 회사 마스터 | COMPANY_CODE, COMPANY_NAME |
| TM_PLANT | 공장 마스터 | PLANT_CODE, PLANT_NAME |
| TM_DEPT | 부서 마스터 | DEPT_CODE, DEPT_NAME |
| TM_USER | 사용자 마스터 | USER_ID, USER_NAME |
| TM_POST | 직급 마스터 | POST_CODE, POST_NAME |
| TM_MENU | 메뉴 마스터 | MENU_ID, MENU_NAME |
| TM_MENUROLE | 메뉴권한 마스터 | ROLE_CODE, MENU_ID |
| TM_USERROLE | 사용자권한 | USER_ID, ROLE_CODE |
| TM_CODE | 공통코드 | CODE_TYPE, CODE |
| TM_FORMMST | 화면 마스터 | FORM_ID, FORM_NAME |
| TM_TRANSACTION | 트랜잭션 마스터 | TRANS_ID, TRANS_NAME |
| TM_NOTICE | 공지사항 | NOTICE_ID, TITLE |
| TM_GLOSSARY | 용어사전 | TERM_ID, TERM |
| TM_ITEMS | 품목 마스터 | ITEM_CODE, ITEM_NAME |
| TM_ITEMSPEC | 품목사양 | ITEM_CODE, SPEC_ITEM |
| TM_ITEMIMAGE | 품목이미지 | ITEM_CODE, IMAGE_DATA |
| TM_BOM | BOM 마스터 | ITEM_CODE, COMP_ITEM_CODE |
| TM_BOMGRP | BOM그룹 | GRP_CODE, GRP_NAME |
| TM_ROUTING | 라우팅 | ITEM_CODE, SEQ |
| TM_MODELBOM | 모델BOM | MODEL_CODE, ITEM_CODE |
| TM_SUBMAT | 대체자재 | ITEM_CODE, SUB_ITEM_CODE |
| TM_VENDOR | 거래처 | VENDOR_CODE, VENDOR_NAME |
| TM_UNIT | 단위 | UNIT_CODE, UNIT_NAME |
| TM_OPER | 공정 | OPER_CODE, OPER_NAME |
| TM_LINE | 라인 | LINE_CODE, LINE_NAME |
| TM_WC | 작업장 | WC_CODE, WC_NAME |
| TM_EQP | 설비 | EQP_CODE, EQP_NAME |
| TM_PRODLINE | 생산라인 | PRODLINE_CODE, PRODLINE_NAME |
| TM_PRODLINE_UNIT | 라인단위 | PRODLINE_CODE, UNIT_SEQ |
| TM_APPLICATOR | 애플리케이터 | APP_CODE, APP_NAME |
| TM_JIGPIN | 지그/PIN | JIG_CODE, JIG_NAME |
| TM_CRIMPINGBASE | 크림핑기준 | ITEM_CODE, CRIMP_SPEC |
| TM_CLOSINGBASE | 마감기준 | PLANT_CODE, CLOSE_TYPE |
| TM_WORKTIME | 근무시간 | WORKTIME_CODE, WORKTIME_NAME |
| TM_WAREHOUSE | 창고 | WH_CODE, WH_NAME |
| TM_LOCATION | 로케이션 | LOC_CODE, LOC_NAME |
| TM_BOX | 박스 | BOX_NO, BOX_NAME |
| TM_DEFECT | 불량코드 | DEFECT_CODE, DEFECT_NAME |
| TM_REASONCODE | 사유코드 | REASON_CODE, REASON_NAME |
| TM_QCSTANDARD | 검사기준 | ITEM_CODE, QC_ITEM |
| TM_OQC_STANDARD | OQC기준 | ITEM_CODE, OQC_ITEM |
| TM_BRD | 판정기준 | BRD_ID, BRD_NAME |
| TM_SERIAL | 시리얼 | SERIAL_NO, ITEM_CODE |
| TM_LOT | LOT | LOT_NO, ITEM_CODE |

### 5.2 트랜잭션 테이블 목록 (35개)

| 테이블명 | 설명 | 주요 컬럼 |
|----------|------|-----------|
| TW_WORKORD | 작업지시 | WO_NO, ITEM_CODE |
| TW_PRODHIST | 생산이력 | HIST_SEQ, SERIAL_NO |
| TW_PRODHIST_USE | 생산사용내역 | USE_SEQ, SERIAL_NO |
| TW_MOUNT | 장착내역 | MOUNT_SEQ, SERIAL_NO |
| TW_DALLYPROD | 일별생산 | DALLY_SEQ, WORK_DATE |
| TW_IN | 입고 | IN_SEQ, IN_NO |
| TW_OUT | 출고 | OUT_SEQ, OUT_NO |
| TW_MOVE | 이동 | MOVE_SEQ, MOVE_DATE |
| TW_MAT_ISSUE | 자재불출 | ISSUE_SEQ, WO_NO |
| TW_RETURN | 반납 | RETURN_SEQ, WO_NO |
| TW_IQC | IQC검사 | IQC_SEQ, IN_NO |
| TW_OQC | OQC검사 | OQC_SEQ, SERIAL_NO |
| TW_IPQC | IPQC검사 | IPQC_SEQ, WO_NO |
| TW_BADREG | 불량등록 | BADREG_SEQ, SERIAL_NO |

### 5.3 히스토리 테이블 목록 (30개)

| 테이블명 | 설명 | 주요 컬럼 |
|----------|------|-----------|
| TH_STOCKSERIAL | 시리얼재고 | STOCK_SEQ, BASE_DATE |
| TH_STOCK | 재고집계 | STOCK_SEQ, BASE_DATE |
| TH_STOCKMONTH | 월별재고 | MONTH_SEQ, BASE_YYYYMM |
| TH_USESYSTEMLOG | 시스템로그 | LOG_SEQ, LOG_DATE |
| TH_ERRORLOG | 에러로그 | ERROR_SEQ, ERROR_DATE |

---

## 6. 외래키 제약조건 정의

### 6.1 주요 FK 목록

| 자식 테이블 | FK 컬럼 | 부모 테이블 | PK 컬럼 | 삭제규칙 |
|------------|---------|-------------|---------|----------|
| TM_PLANT | COMPANY_CODE | TM_COMPANY | COMPANY_CODE | RESTRICT |
| TM_USER | PLANT_CODE | TM_PLANT | PLANT_CODE | RESTRICT |
| TM_LINE | PLANT_CODE | TM_PLANT | PLANT_CODE | RESTRICT |
| TM_WAREHOUSE | PLANT_CODE | TM_PLANT | PLANT_CODE | RESTRICT |
| TM_WC | LINE_CODE | TM_LINE | LINE_CODE | RESTRICT |
| TM_EQP | WC_CODE | TM_WC | WC_CODE | RESTRICT |
| TM_PRODLINE | LINE_CODE | TM_LINE | LINE_CODE | RESTRICT |
| TM_ITEMS | SUPPLIER_CODE | TM_VENDOR | VENDOR_CODE | SET NULL |
| TM_BOM | ITEM_CODE | TM_ITEMS | ITEM_CODE | CASCADE |
| TM_BOM | COMP_ITEM_CODE | TM_ITEMS | ITEM_CODE | RESTRICT |
| TM_ROUTING | ITEM_CODE | TM_ITEMS | ITEM_CODE | CASCADE |
| TM_ROUTING | OPER_CODE | TM_OPER | OPER_CODE | RESTRICT |
| TM_LOCATION | WH_CODE | TM_WAREHOUSE | WH_CODE | CASCADE |
| TM_SERIAL | ITEM_CODE | TM_ITEMS | ITEM_CODE | RESTRICT |
| TM_SERIAL | PRODLINE_CODE | TM_PRODLINE | PRODLINE_CODE | RESTRICT |
| TM_BOX | WH_CODE | TM_WAREHOUSE | WH_CODE | RESTRICT |
| TW_WORKORD | ITEM_CODE | TM_ITEMS | ITEM_CODE | RESTRICT |
| TW_WORKORD | PRODLINE_CODE | TM_PRODLINE | PRODLINE_CODE | RESTRICT |
| TW_PRODHIST | SERIAL_NO | TM_SERIAL | SERIAL_NO | RESTRICT |
| TW_PRODHIST | WO_NO | TW_WORKORD | WO_NO | CASCADE |
| TW_IN | ITEM_CODE | TM_ITEMS | ITEM_CODE | RESTRICT |
| TW_IN | WH_CODE | TM_WAREHOUSE | WH_CODE | RESTRICT |
| TW_OUT | ITEM_CODE | TM_ITEMS | ITEM_CODE | RESTRICT |
| TW_OUT | WH_CODE | TM_WAREHOUSE | WH_CODE | RESTRICT |

---

## 7. 인덱스 전략

### 7.1 필수 인덱스

| 테이블 | 인덱스명 | 컬럼 | 유형 |
|--------|----------|------|------|
| TM_ITEMS | IDX_ITEMS_NAME | ITEM_NAME | B-Tree |
| TM_ITEMS | IDX_ITEMS_TYPE | ITEM_TYPE | Bitmap |
| TM_SERIAL | IDX_SERIAL_ITEM | ITEM_CODE | B-Tree |
| TM_SERIAL | IDX_SERIAL_PROD | PROD_DATE | B-Tree |
| TW_WORKORD | IDX_WO_DATE | PLAN_DATE | B-Tree |
| TW_WORKORD | IDX_WO_ITEM | ITEM_CODE | B-Tree |
| TW_PRODHIST | IDX_PROD_DATE | WORK_DATE | B-Tree |
| TW_PRODHIST | IDX_PROD_SERIAL | SERIAL_NO | B-Tree |
| TW_IN | IDX_IN_DATE | IN_DATE | B-Tree |
| TW_OUT | IDX_OUT_DATE | OUT_DATE | B-Tree |
| TH_STOCKSERIAL | IDX_STOCK_DATE | BASE_DATE | B-Tree |

---

!!! note "ERD 규모"
    - 총 **125개 테이블**의 완전한 구조
    - **8개 영역**으로 분류 (시스템/품목/공장/창고/품질/시리얼/생산/히스토리)
    - **45개 마스터** + **35개 트랜잭션** + **30개 히스토리** + **15개 기타**
