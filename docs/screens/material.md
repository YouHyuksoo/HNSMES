# 자재 관리 (MAT) 화면

MAT 모듈은 자재의 입출고, 재고관리, 창고 운영을 위한 **31개**의 화면으로 구성되어 있습니다.

## 개요

```mermaid
flowchart LR
    subgraph IN["📥 입고 프로세스"]
        A[발주접수] --> B[입고등록]
        B --> C[입하검사]
        C --> D[적재창고배정]
    end
    
    subgraph STOCK["📦 재고 관리"]
        D --> E[재고조회]
        E --> F[재고조정]
        E --> G[재고이동]
    end
    
    subgraph OUT["📤 출고 프로세스"]
        H[생산투입요청] --> I[출고등록]
        I --> J[출하처리]
    end
    
    STOCK --> OUT
```

## 주요 화면

### MATM001 - 자재입고등록

<iframe src="/assets/screen-visualizations/MATA201.Designer.html" width="100%" height="550" style="border:1px solid #ccc; border-radius:8px;"></iframe>

[전체 화면 보기](/assets/screen-visualizations/MATA201.Designer.html){ .md-button .md-button--primary }

!!! note "화면 설명"
    자재 입고 시 입고 정보를 등록하고 검수 결과를 기록하는 핵심 화면입니다.

| 항목 | 내용 |
|:---|:---|
| **화면 ID** | MATM001 |
| **화면 유형** | 등록/처리 |
| **주요 기능** | 입고등록, LOT 생성, 검수결과 입력 |
| **입력 항목** | 발주번호, 입고일, 품목, 수량, 창고, 위치 |

```mermaid
sequenceDiagram
    participant U as 사용자
    participant M as MATM001
    participant DB as 데이터베이스
    participant Q as QCMT
    participant P as PROD
    
    U->>M: 발주번호 입력
    M->>DB: 발주정보 조회
    DB-->>M: 발주데이터 반환
    U->>M: 입고수량/일자 입력
    alt 검수필요품목
        M->>Q: 입하검사요청
        Q-->>M: 검사완료 확인
    end
    M->>DB: 입고데이터 저장
    M->>DB: 재고증가 반영
    DB-->>M: 저장완료
    M-->>U: 입고증 출력
```

### MATM010 - 재고조회

!!! tip "조회 기능"
    실시간 재고 현황을 다양한 조건으로 조회할 수 있습니다.

| 조회 조건 | 설명 |
|:---|:---|
| 창고별 | 특정 창고의 재고 조회 |
| 위치별 | 창고 내 특정 위치 조회 |
| 품목별 | 특정 품목의 전 창고 재고 |
| LOT별 | LOT 단위 재고 추적 |
| 기간별 | 기간별 재고 변동 이력 |

### MATM020 - 자재출고

```mermaid
flowchart TB
    A[출고요청] --> B{요청유형}
    B -->|생산투입| C[PROD 연계]
    B -->|판매출하| D[출하처리]
    B -->|외주전달| E[외주출고]
    B -->|기타| F[기타출고]
    
    C --> G[재고차감]
    D --> G
    E --> G
    F --> G
    
    G --> H[출고증발행]
```

## 전체 화면 목록

| 화면 ID | 화면명 | 유형 | 설명 |
|:---:|:---|:---:|:---|
| **MATM001** | **자재입고등록** | 처리 | 자재 입고 데이터 등록 |
| MATM002 | 자재입고조회 | 조회 | 입고 이력 조회 |
| MATM003 | 자재입고취소 | 처리 | 입고 취소 처리 |
| MATM004 | 입하검사요청 | 처리 | 입하 검사 요청 |
| MATM005 | 입하검사결과 | 조회 | 입하 검사 결과 확인 |
| MATM006 | 반품등록 | 처리 | 불량 자재 반품 등록 |
| MATM007 | 반품조회 | 조회 | 반품 이력 조회 |
| MATM008 | 창고이동등록 | 처리 | 창고 간 재고 이동 |
| MATM009 | 창고이동조회 | 조회 | 창고 이동 이력 |
| **MATM010** | **재고조회** | 조회 | 현재고 현황 조회 |
| MATM011 | 재고상세조회 | 조회 | LOT별 재고 상세 |
| MATM012 | 재고조정등록 | 처리 | 재고 조정 처리 |
| MATM013 | 재고조정조회 | 조회 | 재고 조정 이력 |
| MATM014 | 재고실사등록 | 처리 | 재고 실사 데이터 등록 |
| MATM015 | 재고실사조회 | 조회 | 재고 실사 이력 |
| MATM016 | 재고실사차이조회 | 조회 | 실사 차이 내역 |
| MATM017 | 안전재고조회 | 조회 | 안전재고 기준 대비 현황 |
| MATM018 | 재고경고현황 | 조회 | 재고 부족/과다 경고 |
| MATM019 | 재고수불부 | 조회 | 기간별 수불 현황 |
| **MATM020** | **자재출고** | 처리 | 자재 출고 등록 |
| MATM021 | 자재출고조회 | 조회 | 출고 이력 조회 |
| MATM022 | 자재출고취소 | 처리 | 출고 취소 |
| MATM023 | 출하등록 | 처리 | 제품 출하 등록 |
| MATM024 | 출하조회 | 조회 | 출하 이력 조회 |
| MATM025 | 출하반품등록 | 처리 | 출하 반품 처리 |
| MATM026 | 출하반품조회 | 조회 | 출하 반품 이력 |
| MATM027 | 창고관리 | 관리 | 창고/위치 정보 관리 |
| MATM028 | 재고이력조회 | 조회 | 재고 변동 이력 추적 |
| MATM029 | LOT추적조회 | 조회 | LOT별 유통 이력 |
| MATM030 | 자재현황리포트 | 리포트 | 자재 현황 보고서 |
| MATM031 | 재고분석리포트 | 리포트 | 재고 분석 보고서 |

## 재고 흐름도

```mermaid
flowchart TB
    subgraph 입고["입고 프로세스"]
        I1[자재입고등록<br/>MATM001]
        I2[입하검사<br/>MATM004-005]
        I3[반품관리<br/>MATM006-007]
    end
    
    subgraph 재고["재고 관리"]
        S1[재고조회<br/>MATM010-011]
        S2[재고조정<br/>MATM012-013]
        S3[재고실사<br/>MATM014-016]
        S4[안전재고관리<br/>MATM017-018]
    end
    
    subgraph 출고["출고 프로세스"]
        O1[자재출고<br/>MATM020]
        O2[출하관리<br/>MATM023-026]
    end
    
    subgraph 이동["창고 이동"]
        T1[창고이동<br/>MATM008-009]
    end
    
    I1 --> S1
    I2 --> S1
    S1 --> S2
    S1 --> S3
    S1 --> S4
    S1 --> O1
    S1 --> O2
    S1 --> T1
    T1 --> S1
```

## 화면 유형별 분포

```mermaid
pie title MAT 모듈 화면 유형
    "조회 화면" : 18
    "등록/처리 화면" : 11
    "관리 화면" : 1
    "리포트 화면" : 1
```

## 주요 기능 상세

### 입고 처리 프로세스

```mermaid
sequenceDiagram
    autonumber
    participant P as 구매담당
    participant M1 as MATM001
    participant Q as QCMT
    participant M2 as MATM004
    participant DB as DB
    
    P->>M1: 입고등록 화면 오픈
    P->>M1: 발주번호 스캔/입력
    M1->>DB: 발주정보 조회
    DB-->>M1: 발주정보 반환
    P->>M1: 입고수량 입력
    
    alt 검수필요품목
        M1->>Q: 자동 검사요청
        Q-->>M1: 검사요청번호 반환
        Note over Q,M2: 검수 완료 후
        Q->>M2: 검사결과 전송
    end
    
    M1->>DB: 입고데이터 저장
    DB->>DB: 재고증가
    DB-->>M1: 저장완료
    M1-->>P: 입고증 출력
```

### 재고 실사 프로세스

| 단계 | 화면 | 작업 내용 |
|:---:|:---|:---|
| 1 | MATM014 | 실사계획 등록 및 전표 생성 |
| 2 | MATM014 | 실사데이터 입력 (스캔/수기) |
| 3 | MATM016 | 실사결과 vs 시스템재고 비교 |
| 4 | MATM012 | 차이분 재고조정 |
| 5 | MATM015 | 실사 마감 처리 |

!!! warning "재고조정 주의사항"
    재고조정은 반드시 사유를 입력해야 하며, 승인 절차를 거쳐야만 최종 반영됩니다.

## 권한 설정

| 권한 코드 | 권한명 | 접근 가능 화면 |
|:---:|:---|:---|
| MAT_ADMIN | 자재관리자 | 모든 화면 |
| MAT_IN | 입고담당자 | 입고 + 조회 화면 |
| MAT_OUT | 출고담당자 | 출고 + 조회 화면 |
| MAT_STOCK | 재고관리자 | 재고 + 실사 관련 화면 |
| MAT_VIEWER | 자재조회자 | 조회 화면만 |

## 연계 모듈

```mermaid
flowchart TB
    subgraph MAT["MAT 모듈"]
        M1[자재입고]
        M2[재고관리]
        M3[자재출고]
    end
    
    subgraph PROD["PROD 모듈"]
        P1[생산투입]
        P2[완제품입고]
    end
    
    subgraph QCM["QCM 모듈"]
        Q1[입하검사]
        Q2[출하검사]
    end
    
    subgraph MST["MST 모듈"]
        MS1[품목정보]
        MS2[BOM]
    end
    
    MS1 -.-> M1
    MS2 -.-> P1
    M1 -.-> Q1
    M2 -.-> P1
    P1 -.-> M3
    P2 -.-> M1
    M3 -.-> Q2
```

## LOT 추적

```mermaid
timeline
    title LOT 생명주기
    section 입고
        LOT생성 : 입고등록 시
                : 고유 LOT번호 부여
    section 재고
        보관 : 창고/위치 관리
        이동 : 창고간 이동 추적
        조정 : 재고조정 이력
    section 출고
        생산투입 : 공정별 사용 추적
        출하 : 고객/납품처 기록
    section 이력
        추적조회 : MATM029
                 : 유통전과정 추적
```
