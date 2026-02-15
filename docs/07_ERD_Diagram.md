# ERD (Entity Relationship Diagram) (폐기됨)

!!! danger "이 문서는 폐기되었습니다"
    이 문서의 내용은 실제 DB와 다릅니다. 정확한 정보는 [ERD 다이어그램](database/erd-complete.md)을 참조하세요.
    최종 업데이트: 2026-02-15

---

**아래 내용은 더 이상 유효하지 않습니다.**

## 1. 개체 관계도 개요

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                              ERD 전체 구조                                   │
├─────────────────────────────────────────────────────────────────────────────┤
│                                                                             │
│   ┌──────────────┐       ┌──────────────┐       ┌──────────────┐          │
│   │  TM_CLIENT   │──1:N──│ TM_COMPANY   │──1:N──│  TM_PLANT    │          │
│   │   (클이언트) │       │   (회사)      │       │   (공장)      │          │
│   └──────────────┘       └──────────────┘       └───────┬──────┘          │
│                                                         │                   │
│   ┌─────────────────────────────────────────────────────┘                   │
│   │                                                                         │
│   │   ┌──────────────┐       ┌──────────────┐       ┌──────────────┐      │
│   └───│ TM_WAREHOUSE │──1:N──│ TM_LOCATION  │       │ TM_PRODLINE  │      │
│       │   (창고)      │       │   (로케이션)  │       │   (생산라인)  │      │
│       └──────────────┘       └──────────────┘       └──────────────┘      │
│                                                                             │
│   ┌──────────────┐       ┌──────────────┐       ┌──────────────┐          │
│   │ TM_DEPARTMENT│       │   TM_USER    │──N:M──│ TM_USERROLE  │          │
│   │   (부서)      │       │   (사용자)    │       │   (권한)      │          │
│   └──────────────┘       └───────┬──────┘       └──────────────┘          │
│                                  │                                          │
│   ┌──────────────┐       ┌──────┴──────┐       ┌──────────────┐          │
│   │  TM_ITEMS    │──1:N──│   TM_BOM    │──N:1──│  TM_BOMGRP   │          │
│   │   (품목)      │       │   (BOM)     │       │   (BOM그룹)   │          │
│   └───────┬──────┘       └─────────────┘       └──────────────┘          │
│           │                                                                 │
│   ┌───────┴──────┐       ┌──────────────┐       ┌──────────────┐          │
│   │  TM_SERIAL   │──1:N──│ TW_PRODHIST  │──N:1──│ TW_WORKORD   │          │
│   │   (시리얼)    │       │   (생산이력)  │       │   (작업지시)  │          │
│   └───────┬──────┘       └──────────────┘       └──────────────┘          │
│           │                                                                 │
│   ┌───────┴──────────────────────────────────────────────┐                 │
│   │                                                      │                 │
│   ▼                                                      ▼                 │
│┌──────────────┐                                  ┌──────────────┐         │
││   TW_IN      │                                  │   TW_OUT     │         │
││   (입고이력)  │                                  │   (출고이력)  │         │
│└──────────────┘                                  └──────────────┘         │
│                                                                             │
│┌─────────────────────────────────────────────────────────────────────┐    │
││                         TH_STOCKSERIAL                              │    │
││                           (현재고)                                   │    │
│└─────────────────────────────────────────────────────────────────────┘    │
│                                                                             │
└─────────────────────────────────────────────────────────────────────────────┘
```

---

## 2. 핵심 엔티티 상세

### 2.1 TM_USER (사용자마스터)

```
┌─────────────────────────────────────────────────────────────────┐
│                           TM_USER                               │
├─────────────────────────────────────────────────────────────────┤
│ PK │ CLIENT          │ VARCHAR2(10)  │ 클라이언트코드            │
│ PK │ COMPANY         │ VARCHAR2(10)  │ 회사코드                  │
│ PK │ USER_ID         │ VARCHAR2(50)  │ 사용자ID                  │
│    │ USERNAME        │ VARCHAR2(100) │ 사용자명                  │
│    │ PASSWORD        │ VARCHAR2(100) │ 비밀번호(암호화)          │
│ FK │ DEPTCODE        │ VARCHAR2(20)  │ 부서코드                  │
│ FK │ POSTCODE        │ VARCHAR2(20)  │ 직급코드                  │
│    │ EMAIL           │ VARCHAR2(100) │ 이메일                    │
│    │ USEFLAG         │ VARCHAR2(1)   │ 사용여부                  │
│    │ ADMINFLAG       │ VARCHAR2(1)   │ 관리자여부                │
│    │ REGDATE         │ VARCHAR2(14)  │ 등록일시                  │
└─────────────────────────────────────────────────────────────────┘

Relationship:
  TM_USER ──N:1──▶ TM_DEPARTMENT (DEPTCODE)
  TM_USER ──N:1──▶ TM_POSITION (POSTCODE)
  TM_USER ──1:N──▶ TH_USESYSTEMLOG
```

### 2.2 TM_ITEMS (품목마스터)

```
┌─────────────────────────────────────────────────────────────────┐
│                          TM_ITEMS                               │
├─────────────────────────────────────────────────────────────────┤
│ PK │ CLIENT          │ VARCHAR2(10)  │ 클라이언트코드            │
│ PK │ COMPANY         │ VARCHAR2(10)  │ 회사코드                  │
│ PK │ ITEMCODE        │ VARCHAR2(50)  │ 품목코드                  │
│    │ ITEMNAME        │ VARCHAR2(200) │ 품목명                    │
│    │ SPEC            │ VARCHAR2(200) │ 규격                      │
│ FK │ UNITCODE        │ VARCHAR2(10)  │ 단위코드                  │
│    │ ITEMTYPE        │ VARCHAR2(10)  │ 품목유형                  │
│    │ ABCCLASS        │ VARCHAR2(1)   │ ABC분류                   │
│    │ SAFESTOCK       │ NUMBER        │ 안전재고                  │
│ FK │ WAREHOUSE       │ VARCHAR2(20)  │ 기본창고                  │
│ FK │ LOCATION        │ VARCHAR2(20)  │ 기본로케이션              │
│    │ PRINTTYPE       │ VARCHAR2(10)  │ 라벨유형                  │
│    │ PRINTUNIT       │ NUMBER        │ 발행단위                  │
│    │ USEFLAG         │ VARCHAR2(1)   │ 사용여부                  │
└─────────────────────────────────────────────────────────────────┘

Relationship:
  TM_ITEMS ──1:N──▶ TM_BOM (상위품목)
  TM_ITEMS ──N:1──▶ TM_BOM (하위품목)
  TM_ITEMS ──1:N──▶ TM_SERIAL
  TM_ITEMS ──N:1──│ TM_WAREHOUSE
  TM_ITEMS ──N:1──│ TM_LOCATION
```

### 2.3 TM_SERIAL (시리얼마스터)

```
┌─────────────────────────────────────────────────────────────────┐
│                         TM_SERIAL                               │
├─────────────────────────────────────────────────────────────────┤
│ PK │ SERIALNO        │ VARCHAR2(50)  │ 시리얼번호                │
│    │ CLIENT          │ VARCHAR2(10)  │ 클라이언트코드            │
│    │ COMPANY         │ VARCHAR2(10)  │ 회사코드                  │
│ FK │ ITEMCODE        │ VARCHAR2(50)  │ 품목코드                  │
│    │ PRODDATE        │ VARCHAR2(8)   │ 생산일자                  │
│    │ STATUS          │ VARCHAR2(10)  │ 상태(0:정상,1:불량)       │
│    │ LOTNO           │ VARCHAR2(50)  │ LOT번호                   │
│    │ BOXNO           │ VARCHAR2(50)  │ 박스번호                  │
│    │ USEFLAG         │ VARCHAR2(1)   │ 사용여부                  │
└─────────────────────────────────────────────────────────────────┘

Relationship:
  TM_SERIAL ──1:N──▶ TW_PRODHIST
  TM_SERIAL ──1:N──▶ TW_IN
  TM_SERIAL ──1:N──▶ TW_OUT
  TM_SERIAL ──1:1──▶ TH_STOCKSERIAL
```

### 2.4 TW_PRODHIST (생산이력)

```
┌─────────────────────────────────────────────────────────────────┐
│                        TW_PRODHIST                              │
├─────────────────────────────────────────────────────────────────┤
│ PK │ CLIENT          │ VARCHAR2(10)  │ 클라이언트코드            │
│ PK │ COMPANY         │ VARCHAR2(10)  │ 회사코드                  │
│ PK │ WORKDATE        │ VARCHAR2(8)   │ 작업일자                  │
│ PK │ WORKORD         │ VARCHAR2(20)  │ 작업지시번호              │
│ PK │ SERIALNO        │ VARCHAR2(50)  │ 시리얼번호                │
│ FK │ ITEMCODE        │ VARCHAR2(50)  │ 품목코드                  │
│ FK │ LINECODE        │ VARCHAR2(20)  │ 라인코드                  │
│ FK │ OPCODE          │ VARCHAR2(20)  │ 공정코드                  │
│    │ QTY_GOOD        │ NUMBER        │ 양품수량                  │
│    │ QTY_BAD         │ NUMBER        │ 불량수량                  │
│ FK │ BADCODE         │ VARCHAR2(20)  │ 불량코드                  │
│    │ WORKSTARTTIME   │ VARCHAR2(14)  │ 작업시작                  │
│    │ WORKENDTIME     │ VARCHAR2(14)  │ 작업종료                  │
│    │ WORKUSER        │ VARCHAR2(50)  │ 작업자                    │
└─────────────────────────────────────────────────────────────────┘

Relationship:
  TW_PRODHIST ──N:1──▶ TM_SERIAL
  TW_PRODHIST ──N:1──▶ TM_PRODLINE
  TW_PRODHIST ──N:1──▶ TM_OPERATION
  TW_PRODHIST ──N:1──▶ TM_DEFECT
```

### 2.5 TH_STOCKSERIAL (현재고)

```
┌─────────────────────────────────────────────────────────────────┐
│                       TH_STOCKSERIAL                            │
├─────────────────────────────────────────────────────────────────┤
│ PK │ SERIALNO        │ VARCHAR2(50)  │ 시리얼번호                │
│    │ CLIENT          │ VARCHAR2(10)  │ 클라이언트코드            │
│    │ COMPANY         │ VARCHAR2(10)  │ 회사코드                  │
│ FK │ ITEMCODE        │ VARCHAR2(50)  │ 품목코드                  │
│    │ QTY             │ NUMBER        │ 현재고수량                │
│ FK │ WHCODE          │ VARCHAR2(20)  │ 창고코드                  │
│ FK │ LOCCODE         │ VARCHAR2(20)  │ 로케이션코드              │
│    │ STATUS          │ VARCHAR2(10)  │ 재고상태                  │
│    │ INDATE          │ VARCHAR2(8)   │ 최초입고일                │
│    │ UPDDATE         │ VARCHAR2(14)  │ 수정일시                  │
└─────────────────────────────────────────────────────────────────┘

Relationship:
  TH_STOCKSERIAL ──1:1──▶ TM_SERIAL
  TH_STOCKSERIAL ──N:1──▶ TM_WAREHOUSE
  TH_STOCKSERIAL ──N:1──▶ TM_LOCATION
```

---

## 3. 트랜잭션 엔티티 관계

### 3.1 입고 프로세스 ERD

```
┌──────────────┐     ┌──────────────┐     ┌──────────────┐
│   TM_ITEMS   │◀────│    TW_IN     │────▶│  TM_VENDOR   │
│   (품목)      │     │   (입고이력)  │     │   (거래처)   │
└──────┬───────┘     └──────┬───────┘     └──────────────┘
       │                    │
       │                    │
       ▼                    ▼
┌──────────────┐     ┌──────────────┐
│  TM_SERIAL   │◀────│  TW_IQC      │
│   (시리얼)    │     │   (IQC검사)  │
└──────┬───────┘     └──────────────┘
       │
       ▼
┌──────────────┐
│TH_STOCKSERIAL│
│   (현재고)    │
└──────────────┘
```

### 3.2 출고/생산 프로세스 ERD

```
┌──────────────┐     ┌──────────────┐     ┌──────────────┐
│TH_STOCKSERIAL│◀────│   TW_OUT     │────▶│  TM_SERIAL   │
│   (현재고)    │     │   (출고이력)  │     │   (시리얼)   │
└──────────────┘     └──────┬───────┘     └──────┬───────┘
                            │                    │
                            ▼                    ▼
                     ┌──────────────┐     ┌──────────────┐
                     │ TW_WORKORD   │     │ TW_PRODHIST  │
                     │   (작업지시)  │     │   (생산이력)  │
                     └──────────────┘     └──────────────┘
```

### 3.3 품질관리 ERD

```
┌──────────────┐     ┌──────────────┐     ┌──────────────┐
│   TM_ITEMS   │◀────│   TW_IQC     │     │  TM_DEFECT   │
│              │     │   (수입검사)  │────▶│   (불량유형) │
└──────────────┘     └──────────────┘     └──────────────┘

┌──────────────┐     ┌──────────────┐
│  TM_SERIAL   │◀────│   TW_BRD     │
│              │     │   (불량등록)  │
└──────────────┘     └──────────────┘
```

---

## 4. 테이블 간 관계 정의

### 4.1 1:N 관계 (One-to-Many)

| 부모 테이블 | 자식 테이블 | 관계 설명 |
|------------|------------|-----------|
| TM_CLIENT | TM_COMPANY | 클라이언트:회사 = 1:N |
| TM_COMPANY | TM_PLANT | 회사:공장 = 1:N |
| TM_PLANT | TM_WAREHOUSE | 공장:창고 = 1:N |
| TM_WAREHOUSE | TM_LOCATION | 창고:로케이션 = 1:N |
| TM_ITEMS | TM_BOM | 품목:BOM = 1:N |
| TM_ITEMS | TM_SERIAL | 품목:시리얼 = 1:N |
| TM_SERIAL | TW_PRODHIST | 시리얼:생산이력 = 1:N |
| TM_SERIAL | TW_IN | 시리얼:입고 = 1:N |
| TM_SERIAL | TW_OUT | 시리얼:출고 = 1:N |
| TM_USER | TH_USESYSTEMLOG | 사용자:사용로그 = 1:N |

### 4.2 N:M 관계 (Many-to-Many)

| 테이블1 | 테이블2 | 중간테이블 | 관계 설명 |
|---------|---------|-----------|-----------|
| TM_USER | TM_USERROLE | TM_SYSUSERROLE | 사용자:권한 |
| TM_MENU | TM_USERROLE | TM_MENUROLE | 메뉴:권한 |
| TM_ITEMS | TM_ITEMS | TM_BOM | 상위품목:하위품목 |

---

## 5. 물리 ERD (주요 테이블)

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                           물리 ERD - 주요 테이블                            │
├─────────────────────────────────────────────────────────────────────────────┤
│                                                                             │
│  ┌─────────────────┐        ┌─────────────────┐        ┌─────────────────┐ │
│  │    TM_USER      │        │    TM_ITEMS     │        │   TM_SERIAL     │ │
│  ├─────────────────┤        ├─────────────────┤        ├─────────────────┤ │
│  │ PK CLIENT       │        │ PK CLIENT       │        │ PK SERIALNO     │ │
│  │ PK COMPANY      │        │ PK COMPANY      │        │    CLIENT       │ │
│  │ PK USER_ID      │        │ PK ITEMCODE     │        │    COMPANY      │ │
│  │    USERNAME     │        │    ITEMNAME     │        │ FK ITEMCODE     │ │
│  │    PASSWORD     │        │    SPEC         │        │    PRODDATE     │ │
│  │ FK DEPTCODE     │        │ FK UNITCODE     │        │    STATUS       │ │
│  │    USEFLAG      │        │    ITEMTYPE     │        └────────┬────────┘ │
│  └────────┬────────┘        │    USEFLAG      │                 │          │
│           │                 └────────┬────────┘                 │          │
│           │                          │                          │          │
│           │                          │                          │          │
│           ▼                          ▼                          ▼          │
│  ┌─────────────────┐        ┌─────────────────┐        ┌─────────────────┐ │
│  │  TM_DEPARTMENT  │        │   TW_PRODHIST   │        │   TH_STOCKSERIAL│ │
│  ├─────────────────┤        ├─────────────────┤        ├─────────────────┤ │
│  │ PK DEPTCODE     │        │ PK CLIENT       │        │ PK SERIALNO     │ │
│  │    DEPTNAME     │        │ PK COMPANY      │        │    QTY          │ │
│  └─────────────────┘        │ PK WORKDATE     │        │ FK WHCODE       │ │
│                             │ PK WORKORD      │        │ FK LOCCODE      │ │
│                             │ PK SERIALNO     │        │    STATUS       │ │
│                             │ FK ITEMCODE     │        └────────┬────────┘ │
│                             │ FK LINECODE     │                 │          │
│                             │ FK OPCODE       │                 │          │
│                             │    QTY_GOOD     │                 │          │
│                             │    QTY_BAD      │                 ▼          │
│                             └─────────────────┘        ┌─────────────────┐ │
│                                                        │  TM_WAREHOUSE   │ │
│                             ┌─────────────────┐        ├─────────────────┤ │
│                             │     TW_IN       │        │ PK WHCODE       │ │
│                             ├─────────────────┤        │    WHNAME       │ │
│                             │ PK CLIENT       │        └────────┬────────┘ │
│                             │ PK COMPANY      │                 │          │
│                             │ PK INDATE       │                 ▼          │
│                             │ PK INNO         │        ┌─────────────────┐ │
│                             │ PK SERIALNO     │        │  TM_LOCATION    │ │
│                             │ FK ITEMCODE     │        ├─────────────────┤ │
│                             │ FK VENDORCODE   │        │ PK LOCCODE      │ │
│                             │    QTY          │        │ FK WHCODE       │ │
│                             │    IQCFLAG      │        │    LOCNAME      │ │
│                             └─────────────────┘        └─────────────────┘ │
│                                                                             │
└─────────────────────────────────────────────────────────────────────────────┘
```

---

**ERD 문서 작성 완료**
