# 부록 A: 테이블 상세 정의서

## A.1 마스터 테이블

### TM_USER (사용자마스터)

| 컬럼명 | 데이터타입 | NULL | 설명 | 비고 |
|--------|-----------|------|------|------|
| CLIENT | VARCHAR2(10) | N | 클라이언트코드 | PK |
| COMPANY | VARCHAR2(10) | N | 회사코드 | PK |
| USER_ID | VARCHAR2(50) | N | 사용자ID | PK |
| USERNAME | VARCHAR2(100) | Y | 사용자명 | |
| PASSWORD | VARCHAR2(100) | Y | 암호화된 비밀번호 | Triple DES |
| DEPTCODE | VARCHAR2(20) | Y | 부서코드 | FK: TM_DEPARTMENT |
| POSTCODE | VARCHAR2(20) | Y | 직급코드 | FK: TM_POSITION |
| EMAIL | VARCHAR2(100) | Y | 이메일 | |
| TELNO | VARCHAR2(50) | Y | 전화번호 | |
| USEFLAG | VARCHAR2(1) | Y | 사용여부 | Y/N |
| ADMINFLAG | VARCHAR2(1) | Y | 관리자여부 | Y/N |
| PWFAILCNT | NUMBER | Y | 비밀번호실패횟수 | |
| LASTLOGINDATE | VARCHAR2(14) | Y | 최종로그인일시 | YYYYMMDDHH24MISS |
| REGUSER | VARCHAR2(50) | Y | 등록자 | |
| REGDATE | VARCHAR2(14) | Y | 등록일시 | |

**인덱스**: PK_TM_USER (CLIENT, COMPANY, USER_ID)

---

### TM_ITEMS (품목마스터)

| 컬럼명 | 데이터타입 | NULL | 설명 | 비고 |
|--------|-----------|------|------|------|
| CLIENT | VARCHAR2(10) | N | 클라이언트코드 | PK |
| COMPANY | VARCHAR2(10) | N | 회사코드 | PK |
| ITEMCODE | VARCHAR2(50) | N | 품목코드 | PK |
| ITEMNAME | VARCHAR2(200) | Y | 품목명 | |
| SPEC | VARCHAR2(200) | Y | 규격 | |
| MODEL | VARCHAR2(100) | Y | 모델 | |
| UNITCODE | VARCHAR2(10) | Y | 단위코드 | FK: TM_UNITCODE |
| ITEMTYPE | VARCHAR2(10) | Y | 품목유형 | 원자재/반제품/완제품 |
| ABCCLASS | VARCHAR2(1) | Y | ABC분류 | A/B/C |
| REORDERQTY | NUMBER | Y | 재주문수량 | |
| SAFESTOCK | NUMBER | Y | 안전재고 | |
| STDPRICE | NUMBER | Y | 표준단가 | |
| COST | NUMBER | Y | 원가 | |
| WAREHOUSE | VARCHAR2(20) | Y | 기본창고 | FK: TM_WAREHOUSE |
| LOCATION | VARCHAR2(20) | Y | 기본로케이션 | FK: TM_LOCATION |
| PRINTTYPE | VARCHAR2(10) | Y | 라벨유형 | W:Washer, R:REF |
| PRINTUNIT | NUMBER | Y | 라벨발행단위 | |
| TERMINALFLAG | VARCHAR2(1) | Y | 단자여부 | Y/N |
| USEFLAG | VARCHAR2(1) | Y | 사용여부 | Y/N |
| REMARK | VARCHAR2(500) | Y | 비고 | |
| REGUSER | VARCHAR2(50) | Y | 등록자 | |
| REGDATE | VARCHAR2(14) | Y | 등록일시 | |

**인덱스**: 
- PK_TM_ITEMS (CLIENT, COMPANY, ITEMCODE)
- IDX_ITEMS_NAME (ITEMNAME)

---

### TM_SERIAL (시리얼마스터)

| 컬럼명 | 데이터타입 | NULL | 설명 | 비고 |
|--------|-----------|------|------|------|
| SERIALNO | VARCHAR2(50) | N | 시리얼번호 | PK |
| CLIENT | VARCHAR2(10) | N | 클라이언트코드 | |
| COMPANY | VARCHAR2(10) | N | 회사코드 | |
| ITEMCODE | VARCHAR2(50) | N | 품목코드 | FK: TM_ITEMS |
| PRODDATE | VARCHAR2(8) | Y | 생산일자 | YYYYMMDD |
| STATUS | VARCHAR2(10) | Y | 상태 | 0:정상, 1:불량, 2:폐기 |
| LOTNO | VARCHAR2(50) | Y | LOT번호 | |
| BOXNO | VARCHAR2(50) | Y | 박스번호 | |
| USEFLAG | VARCHAR2(1) | Y | 사용여부 | |
| REGUSER | VARCHAR2(50) | Y | 등록자 | |
| REGDATE | VARCHAR2(14) | Y | 등록일시 | |

**인덱스**: 
- PK_TM_SERIAL (SERIALNO)
- IDX_SERIAL_ITEM (ITEMCODE, STATUS)

---

## A.2 트랜잭션 테이블

### TW_IN (입고이력)

| 컬럼명 | 데이터타입 | NULL | 설명 | 비고 |
|--------|-----------|------|------|------|
| CLIENT | VARCHAR2(10) | N | 클라이언트코드 | PK |
| COMPANY | VARCHAR2(10) | N | 회사코드 | PK |
| INDATE | VARCHAR2(8) | N | 입고일자 | PK |
| INNO | VARCHAR2(20) | N | 입고번호 | PK |
| SERIALNO | VARCHAR2(50) | N | 시리얼번호 | PK |
| ITEMCODE | VARCHAR2(50) | N | 품목코드 | FK: TM_ITEMS |
| QTY | NUMBER | Y | 수량 | |
| UNITCODE | VARCHAR2(10) | Y | 단위 | |
| VENDORCODE | VARCHAR2(20) | Y | 거래처코드 | FK: TM_VENDOR |
| LOTNO | VARCHAR2(50) | Y | LOT번호 | |
| INTYPE | VARCHAR2(10) | Y | 입고유형 | 1:일반, 2:반품 |
| WHCODE | VARCHAR2(20) | Y | 창고코드 | FK: TM_WAREHOUSE |
| LOCCODE | VARCHAR2(20) | Y | 로케이션코드 | FK: TM_LOCATION |
| IQCFLAG | VARCHAR2(1) | Y | IQC여부 | Y/N |
| IQCDATE | VARCHAR2(8) | Y | IQC일자 | |
| IQCJUDGE | VARCHAR2(1) | Y | IQC판정 | Y:합격, N:불합격 |
| REMARK | VARCHAR2(500) | Y | 비고 | |
| REGUSER | VARCHAR2(50) | Y | 등록자 | |
| REGDATE | VARCHAR2(14) | Y | 등록일시 | |

**인덱스**: PK_TW_IN (CLIENT, COMPANY, INDATE, INNO, SERIALNO)

---

### TW_OUT (출고이력)

| 컬럼명 | 데이터타입 | NULL | 설명 | 비고 |
|--------|-----------|------|------|------|
| CLIENT | VARCHAR2(10) | N | 클라이언트코드 | PK |
| COMPANY | VARCHAR2(10) | N | 회사코드 | PK |
| OUTDATE | VARCHAR2(8) | N | 출고일자 | PK |
| OUTNO | VARCHAR2(20) | N | 출고번호 | PK |
| SERIALNO | VARCHAR2(50) | N | 시리얼번호 | PK |
| ITEMCODE | VARCHAR2(50) | N | 품목코드 | FK: TM_ITEMS |
| QTY | NUMBER | Y | 수량 | |
| OUTTYPE | VARCHAR2(10) | Y | 출고유형 | 1:생산투입, 2:출하 |
| WORKORD | VARCHAR2(20) | Y | 작업지시번호 | FK: TW_WORKORD |
| WHCODE | VARCHAR2(20) | Y | 창고코드 | |
| LOCCODE | VARCHAR2(20) | Y | 로케이션코드 | |
| REGUSER | VARCHAR2(50) | Y | 등록자 | |
| REGDATE | VARCHAR2(14) | Y | 등록일시 | |

**인덱스**: PK_TW_OUT (CLIENT, COMPANY, OUTDATE, OUTNO, SERIALNO)

---

### TW_PRODHIST (생산이력)

| 컬럼명 | 데이터타입 | NULL | 설명 | 비고 |
|--------|-----------|------|------|------|
| CLIENT | VARCHAR2(10) | N | 클라이언트코드 | PK |
| COMPANY | VARCHAR2(10) | N | 회사코드 | PK |
| WORKDATE | VARCHAR2(8) | N | 작업일자 | PK |
| WORKORD | VARCHAR2(20) | N | 작업지시번호 | PK |
| SERIALNO | VARCHAR2(50) | N | 시리얼번호 | PK |
| ITEMCODE | VARCHAR2(50) | N | 품목코드 | |
| LINECODE | VARCHAR2(20) | Y | 라인코드 | FK: TM_PRODLINE |
| OPCODE | VARCHAR2(20) | Y | 공정코드 | FK: TM_OPERATION |
| QTY_GOOD | NUMBER | Y | 양품수량 | |
| QTY_BAD | NUMBER | Y | 불량수량 | |
| BADCODE | VARCHAR2(20) | Y | 불량코드 | FK: TM_DEFECT |
| WORKSTARTTIME | VARCHAR2(14) | Y | 작업시작시간 | |
| WORKENDTIME | VARCHAR2(14) | Y | 작업종료시간 | |
| WORKUSER | VARCHAR2(50) | Y | 작업자 | |
| REMARK | VARCHAR2(500) | Y | 비고 | |
| REGUSER | VARCHAR2(50) | Y | 등록자 | |
| REGDATE | VARCHAR2(14) | Y | 등록일시 | |

**인덱스**: PK_TW_PRODHIST (CLIENT, COMPANY, WORKDATE, WORKORD, SERIALNO)

---

### TH_STOCKSERIAL (현재고)

| 컬럼명 | 데이터타입 | NULL | 설명 | 비고 |
|--------|-----------|------|------|------|
| SERIALNO | VARCHAR2(50) | N | 시리얼번호 | PK |
| CLIENT | VARCHAR2(10) | N | 클라이언트코드 | |
| COMPANY | VARCHAR2(10) | N | 회사코드 | |
| ITEMCODE | VARCHAR2(50) | N | 품목코드 | |
| QTY | NUMBER | Y | 현재고수량 | |
| WHCODE | VARCHAR2(20) | Y | 창고코드 | |
| LOCCODE | VARCHAR2(20) | Y | 로케이션코드 | |
| STATUS | VARCHAR2(10) | Y | 재고상태 | 0:정상, 1:품질보류 |
| INDate | VARCHAR2(8) | Y | 최초입고일 | |
| REGUSER | VARCHAR2(50) | Y | 등록자 | |
| REGDATE | VARCHAR2(14) | Y | 등록일시 | |
| UPDUSER | VARCHAR2(50) | Y | 수정자 | |
| UPDDATE | VARCHAR2(14) | Y | 수정일시 | |

**인덱스**: PK_TH_STOCKSERIAL (SERIALNO)

---

## A.3 코드 테이블

### TM_COMMCODE (공통코드)

| 컬럼명 | 데이터타입 | NULL | 설명 | 비고 |
|--------|-----------|------|------|------|
| CLIENT | VARCHAR2(10) | N | 클라이언트코드 | PK |
| COMMGRP | VARCHAR2(20) | N | 코드그룹 | PK |
| COMMCODE | VARCHAR2(20) | N | 코드 | PK |
| COMMNAME | VARCHAR2(100) | Y | 코드명 | |
| COMMTYPE | VARCHAR2(10) | Y | 코드유형 | |
| SORTSEQ | NUMBER | Y | 정렬순서 | |
| USEFLAG | VARCHAR2(1) | Y | 사용여부 | Y/N |
| REMARK | VARCHAR2(500) | Y | 비고 | |
| REGDATE | VARCHAR2(14) | Y | 등록일시 | |

---

## A.4 테이블 관계도

```
[TM_CLIENT]
    │
    ├── [TM_COMPANY]
    │       │
    │       ├── [TM_PLANT] ◀── [TM_WAREHOUSE] ◀── [TM_LOCATION]
    │       │
    │       ├── [TM_DEPARTMENT]
    │       │
    │       ├── [TM_USER] ──▶ [TM_USERROLE]
    │       │
    │       └── [TM_ITEMS] ──▶ [TM_BOM] ──▶ [TM_BOMGRP]
    │               │
    │               ├──▶ [TM_SERIAL] ──▶ [TH_STOCKSERIAL]
    │               │        │
    │               │        ├──▶ [TW_IN]
    │               │        ├──▶ [TW_OUT]
    │               │        └──▶ [TW_PRODHIST]
    │               │
    │               └──▶ [TW_WORKORD]
    │
    └── [TM_MENU] ──▶ [TM_MENUROLE]
```

---

**문서 끝**
