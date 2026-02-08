# 시스템관리 (SYS) 모듈

## 개요

| 항목 | 내용 |
|:---|:---|
| **모듈코드** | SYS |
| **구현 화면** | 15개 (+ 팝업 3개) |
| **주요 역할** | 코드관리, 메뉴/권한, 조직관리, 시스템 운영 |
| **주요 패키지** | PKGSYS_COMM, PKGSYS_MENU, PKGSYS_USER, PKGSYS_DBA |

SYS 모듈은 MES 시스템의 기반 환경을 설정하고 관리하는 핵심 모듈입니다.

## 업무 흐름도

```mermaid
flowchart TB
    subgraph AUTH["권한 관리"]
        A[SYSA206<br/>권한그룹관리] --> B[SYSA207<br/>메뉴권한관리]
        C[SYSA211<br/>사원등록] --> A
    end

    subgraph MENU["메뉴 관리"]
        D[SYSA204<br/>화면관리] --> E[SYSA205<br/>메뉴관리]
        E --> B
    end

    subgraph ORG["조직 관리"]
        F[SYSA208<br/>회사등록] --> G[SYSA209<br/>부서등록]
        G --> H[SYSA210<br/>직급관리]
        H --> C
    end

    subgraph CODE["코드/기본정보"]
        I[SYSA203<br/>공통코드관리]
        J[SYSA201<br/>용어사전관리]
        K[SYSA202<br/>트랜잭션관리]
        L[SYSA212<br/>단위관리]
    end
```

## 구현 화면 목록

### 기본정보 관리

| 화면ID | 화면명 | 유형 | 설명 | 상태 |
|:---|:---|:---:|:---|:---:|
| SYSA201 | 용어사전관리 | 관리 | 다국어 용어 관리 | ✅ |
| SYSA202 | 트랜잭션관리 | 관리 | 트랜잭션 코드 관리 | ✅ |
| SYSA203 | 공통코드관리 | 관리 | 시스템 공통 코드 관리 | ✅ |
| SYSA212 | 단위관리 | 관리 | 단위코드 관리 | ✅ |

### 메뉴/권한 관리

| 화면ID | 화면명 | 유형 | 설명 | 상태 |
|:---|:---|:---:|:---|:---:|
| SYSA204 | 화면관리 | 관리 | 시스템 등록 화면(Form) 관리 | ✅ |
| SYSA205 | 메뉴관리 | 관리 | 트리메뉴 구성 및 관리 | ✅ |
| SYSA206 | 권한그룹관리 | 관리 | 역할(Role) 기반 권한그룹 | ✅ |
| SYSA207 | 메뉴권한관리 | 관리 | 권한그룹별 메뉴 접근권한 설정 | ✅ |

### 조직 관리

| 화면ID | 화면명 | 유형 | 설명 | 상태 |
|:---|:---|:---:|:---|:---:|
| SYSA208 | 회사등록 | 관리 | 회사(Client/Company) 관리 | ✅ |
| SYSA209 | 부서등록 | 관리 | 부서/조직 정보 관리 | ✅ |
| SYSA210 | 직급관리 | 관리 | 직급 코드 관리 | ✅ |
| SYSA211 | 사원등록 | 관리 | 사원정보/비밀번호 초기화/EHR연동 | ✅ |

### 시스템 운영

| 화면ID | 화면명 | 유형 | 설명 | 상태 |
|:---|:---|:---:|:---|:---:|
| SYSA213 | 공지사항관리 | 관리 | 공지사항 등록/조회 | ✅ |
| SYSA214 | 에러로그조회 | 조회 | 시스템 에러 로그 조회 | ✅ |
| SYSA215 | 테이블스페이스조회 | 조회 | DB 용량 모니터링 (DBA용) | ✅ |

### 팝업 화면

| 화면ID | 화면명 | 설명 |
|:---|:---|:---|
| POP_SYS01 | 공통코드그룹 | 공통코드 그룹 관리 팝업 |
| POP_SYSA202 | 공통코드그룹(팝업) | 트랜잭션용 코드그룹 팝업 |
| POP_SYSB002 | 공통코드그룹(관리) | 코드그룹 관리 팝업 |

## 주요 화면 상세

### SYSA211 - 사원등록

<iframe src="../assets/screen-visualizations/SYSA211.designer.html" width="100%" height="550" style="border:1px solid #ccc; border-radius:8px;"></iframe>

[전체 화면 보기](../assets/screen-visualizations/SYSA211.designer.html){ .md-button .md-button--primary }

사용자 계정을 등록하고 기본 정보 및 권한을 관리하는 핵심 화면입니다.

| 항목 | 내용 |
|:---|:---|
| **호출 프로시저** | PKGSYS_USER.PUT_DEFAULTPWD, PKGSYS_USER.PUT_EHR, PKGSYS_USER.GET_ROLE |

```mermaid
erDiagram
    USER ||--o{ USER_ROLE : has
    USER ||--o{ LOGIN_LOG : creates
    USER {
        string user_id PK "사용자ID"
        string user_name "성명"
        string password "비밀번호(암호화)"
        string dept_code "부서코드"
        string position "직급"
        string status "상태(ACTIVE/LOCKED)"
    }
    USER_ROLE {
        string user_id FK "사용자ID"
        string role_id FK "권한그룹ID"
        datetime grant_date "부여일"
    }
```

### RBAC 권한 모델

```mermaid
flowchart TB
    subgraph 권한모델["RBAC 권한 모델"]
        R1[생산관리자] --> U1[사용자A]
        R1 --> U2[사용자B]
        R2[생산사용자] --> U3[사용자C]

        R1 --> P1[PRD 조회]
        R1 --> P2[PRD 등록]
        R1 --> P3[PRD 삭제]
        R2 --> P1
        R2 --> P2
    end
```

### 권한 부여 절차

```mermaid
flowchart LR
    A[SYSA206<br/>권한그룹생성] --> B[SYSA207<br/>메뉴권한설정]
    B --> C[SYSA211<br/>사원에 권한부여]
    C --> D[권한적용확인]
    D --> E[로그인테스트]
```

### 권한 그룹 설계 예시

| 권한그룹 ID | 권한그룹명 | 접근 모듈 | 권한 수준 |
|:---:|:---|:---|:---|
| ADMIN | 시스템관리자 | 전체 | 모든 권한 |
| PROD_MGR | 생산관리자 | PRD, MAT | 조회/등록/수정/삭제 |
| PROD_OP | 생산운영자 | PRD, MAT | 조회/등록/수정 |
| QC_MGR | 품질관리자 | MAT, PRD | 조회/등록/수정/삭제 |
| VIEWER | 조회사용자 | 전체 | 조회만 |

## 시스템 아키텍처

```mermaid
flowchart TB
    subgraph Client["클라이언트"]
        C1[사용자]
    end

    subgraph AuthLayer["인증/인가 계층"]
        A1[COMLOGIN<br/>로그인] --> A2[권한체크]
        A2 --> A3[메뉴필터링]
    end

    subgraph SysModule["SYS 모듈"]
        S1[SYSA211<br/>사원등록]
        S2[SYSA205<br/>메뉴관리]
        S3[SYSA206<br/>권한그룹]
        S4[SYSA203<br/>공통코드]
    end

    subgraph LogLayer["로그 관리"]
        L1[SYSA214<br/>에러로그]
        L2[COMSYSTEMHISTORY<br/>사용이력]
    end

    subgraph BusinessModules["업무 모듈"]
        B1[PRD]
        B2[MAT]
        B3[SAL]
        B4[RPT]
        B5[MNT/OSC]
    end

    C1 --> A1
    A3 --> S1
    A3 --> S2
    A3 --> S3
    A3 --> B1 & B2 & B3 & B4 & B5
    S1 --> L2
    B1 & B2 --> L1
```

## 공통코드 관리 (SYSA203)

시스템 전반에서 사용되는 공통 코드를 관리합니다.

| 코드그룹 | 설명 | 예시 코드값 |
|:---:|:---|:---|
| DEPT | 부서코드 | 1000:생산부, 2000:품질부 |
| POSITION | 직급코드 | 01:사원, 02:대리, 03:과장 |
| YESNO | 예/아니오 | Y:예, N:아니오 |
| STATUS | 상태코드 | ACTIVE:사용, INACTIVE:미사용 |
| UNIT | 단위코드 | EA:개, KG:킬로그램, M:미터 |

```mermaid
erDiagram
    COMCODE {
        string group_code PK "그룹코드"
        string code PK "코드값"
        string code_name "코드명"
        int sort_order "정렬순서"
        string use_yn "사용여부"
    }
```

## 로그 관리 체계

```mermaid
flowchart LR
    subgraph 로그생성["로그 생성"]
        L1[로그인/로그아웃] --> S1[(로그인이력)]
        L2[화면접근] --> S2[(접근이력)]
        L3[에러발생] --> S3[(에러로그)]
    end

    subgraph 로그조회["로그 조회"]
        S1 --> Q1[COMSYSTEMHISTORY]
        S3 --> Q3[SYSA214 에러로그]
    end
```

## 연계 모듈

SYS 모듈의 설정값은 모든 업무 모듈에 영향을 미칩니다:

- **COM**: 로그인 시 SYS 모듈의 사용자/권한 정보 활용
- **MST**: 공통코드, 단위코드 참조
- **PRD/MAT/SAL**: 메뉴 권한에 따른 화면 접근 제어
- **RPT**: 조직 정보(회사/부서) 기반 리포트 필터링
