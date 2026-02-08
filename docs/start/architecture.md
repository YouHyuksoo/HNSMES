# 시스템 아키텍처

이 문서는 HNSMES UI의 전체 아키텍처와 주요 컴포넌트를 설명합니다.

## 개요

```mermaid
flowchart TB
    subgraph Client["클이언트 (Windows Desktop)"]
        UI[WinForms UI]
        BC[Business Components]
        DC[Data Components]
    end
    
    subgraph Service["서비스 계층"]
        WCF[WCF Service<br/>net.tcp:8101]
        WS[WebService<br/>http:8807]
    end
    
    subgraph Database["데이터베이스"]
        ORA[Oracle 11g]
        PROC[Stored Procedures]
        TBL[Tables/Views]
    end
    
    UI --> BC
    BC --> DC
    DC --> WCF
    DC --> WS
    WCF --> ORA
    WS --> ORA
    ORA --> PROC
    ORA --> TBL
```

## 3계층 아키텍처

### 계층별 책임

```mermaid
flowchart LR
    subgraph PL["Presentation Layer"]
        P1[사용자 입력 처리]
        P2[화면 렌더링]
        P3[이벤트 핸들링]
    end
    
    subgraph BL["Business Layer"]
        B1[업무 규칙 검증]
        B2[데이터 변환]
        B3[트랜잭션 관리]
    end
    
    subgraph DL["Data Layer"]
        D1[DB 연결 관리]
        D2[쿼리 실행]
        D3[결과 매핑]
    end
    
    PL --> BL
    BL --> DL
```

## 주요 컴포넌트

### 1. Base.Form (베이스 폼)

```mermaid
classDiagram
    class Form {
        +OnLoad()
        +OnShown()
        +Close()
    }
    
    class Base~Form~ {
        -IDatabaseProcess m_db
        -LanguageInformation m_lang
        +CheckAuth()
        +ShowMessage()
        +ExecuteProc()
        #OnFind()
        #OnSave()
        #OnDelete()
    }
    
    class PRODT001 {
        +LoadData()
        +SaveData()
        -ValidateInput()
    }
    
    class MATM001 {
        +SearchMaterial()
        +UpdateStock()
    }
    
    Form <|-- Base~Form~
    Base~Form~ <|-- PRODT001
    Base~Form~ <|-- MATM001
```

#### 핵심 기능

| 기능 | 설명 |
|------|------|
| **권한 체크** | 화면 로드 시 사용자 권한 검증 |
| **다국어 지원** | LanguageInformation 클래스 활용 |
| **공통 버튼** | itfButton 인터페이스 연동 |
| **데이터 접근** | IDatabaseProcess 인스턴스 제공 |

### 2. IDatabaseProcess (전략 패턴)

```mermaid
classDiagram
    class IDatabaseProcess {
        <<interface>>
        +Execute_Proc(string, Dictionary) WSResults
        +InsertTransactionData(List) WSResults
    }
    
    class WCFDatabaseProcess {
        -WebServiceProcess m_ws
        +Execute_Proc() WSResults
    }
    
    class WSDatabaseProcess {
        -WebServiceProcess m_ws
        +Execute_Proc() WSResults
    }
    
    IDatabaseProcess <|.. WCFDatabaseProcess
    IDatabaseProcess <|.. WSDatabaseProcess
```

#### 사용 예시

```csharp
// 설정에 따라 구현체 선택
IDatabaseProcess dbProcess;

if (Global_Variable.UseWCF)
{
    dbProcess = new WCFDatabaseProcess();
}
else
{
    dbProcess = new WSDatabaseProcess();
}

// 동일한 인터페이스로 사용
var result = dbProcess.Execute_Proc("PKG_PROD.SELECT", param);
```

### 3. WebServiceProcess

```mermaid
flowchart TB
    A[Client Call] --> B{Communication Type}
    B -->|WCF| C[WCF Proxy]
    B -->|WebService| D[SOAP Client]
    C --> E[WCF Service]
    D --> F[ASMX Service]
    E --> G[Oracle DB]
    F --> G
```

#### 주요 메서드

| 메서드 | 설명 |
|--------|------|
| `ExecuteProcCls()` | 프로시저 실행 (Dictionary 파라미터) |
| `ExecuteQry()` | 직접 SQL 실행 (보안 주의) |
| `GetWsConnectStatus()` | 연결 상태 확인 |
| `WsDownload()` | 파일 다운로드 |

### 4. itfButton (버튼 인터페이스)

```mermaid
classDiagram
    class itfButton {
        <<interface>>
        +OnFInd()
        +OnSave()
        +OnDelete()
        +OnNew()
        +OnPrint()
        +OnExcel()
        +OnClose()
    }
    
    class Base~Form~ {
        +OnFInd()
        +OnSave()
        +OnDelete()
        +OnNew()
        +OnPrint()
        +OnExcel()
        +OnClose()
    }
    
    itfButton <|.. Base~Form~
```

## 데이터 흐름

### 조회 프로세스

```mermaid
sequenceDiagram
    actor User
    participant UI as PRODT001
    participant Base as Base.Form
    participant DB as WCFDatabaseProcess
    participant Svc as WCF Service
    participant ORA as Oracle
    
    User->>UI: 조회 버튼 클릭
    UI->>Base: OnFind() 호출
    Base->>UI: 재정의 메서드 실행
    UI->>UI: 입력값 검증
    UI->>DB: Execute_Proc() 호출
    DB->>DB: 파라미터 구성
    DB->>Svc: WCF 호출
    Svc->>ORA: Stored Procedure 실행
    ORA-->>Svc: DataSet 반환
    Svc-->>DB: WSResults 반환
    DB-->>UI: 결과 반환
    UI->>UI: GridControl에 바인딩
    UI-->>User: 데이터 표시
```

### 저장 프로세스

```mermaid
sequenceDiagram
    actor User
    participant UI as PRODT001
    participant Base as Base.Form
    participant DB as WCFDatabaseProcess
    participant Svc as WCF Service
    participant ORA as Oracle
    
    User->>UI: 저장 버튼 클릭
    UI->>Base: OnSave() 호출
    Base->>UI: 재정의 메서드 실행
    UI->>UI: 입력값 검증
    UI->>UI: 수정된 행 수집
    loop 각 행별
        UI->>DB: Execute_Proc() 호출
        DB->>Svc: WCF 호출
        Svc->>ORA: INSERT/UPDATE/DELETE
        ORA-->>Svc: 결과 반환
        Svc-->>DB: WSResults 반환
    end
    DB-->>UI: 최종 결과 반환
    UI->>UI: 성공/실패 메시지 표시
    UI-->>User: 결과 알림
```

## 폼 상속 계층

```mermaid
flowchart TB
    A[System.Windows.Forms.Form]
    B[Base.Form]
    C[Base.GridForm]
    D[Base.SingleForm]
    E[Base.PopupForm]
    
    A --> B
    B --> C
    B --> D
    B --> E
    
    C --> F[PRODT001]
    C --> G[MATM001]
    D --> H[SYST001]
    E --> I[Popup.Search]
```

### 각 베이스 타입별 특징

| 타입 | 특징 | 사용 예시 |
|------|------|-----------|
| **Base.Form** | 기본 베이스, 공통 기능 | 단순 화면 |
| **Base.GridForm** | 그리드 기반, 다중 행 편집 | 생산실적, 자재입고 |
| **Base.SingleForm** | 단일 레코드 편집 | 기준정보 등록 |
| **Base.PopupForm** | 모달 팝업, 검색용 | 품목 검색, 공정 선택 |

## 모듈 구조

```mermaid
flowchart TB
    subgraph Modules["모듈별 화면 구성"]
        direction TB
        
        subgraph SYS["SYSTEM"]
            S1[사용자관리]
            S2[메뉴관리]
            S3[권한관리]
        end
        
        subgraph BASE["BASE"]
            B1[공장정보]
            B2[품목정보]
            B3[공정정보]
        end
        
        subgraph PROD["PROD"]
            P1[작업지시]
            P2[생산실적]
            P3[작업배정]
        end
        
        subgraph MAT["MAT"]
            M1[자재입고]
            M2[자재출고]
            M3[재고관리]
        end
        
        subgraph QCM["QCM"]
            Q1[검사기준]
            Q2[불량처리]
            Q3[품질이력]
        end
        
        subgraph EQM["EQM"]
            E1[설비정보]
            E2[점검계획]
            E3[고장이력]
        end
        
        subgraph MST["MST"]
            MT1[생산현황]
            MT2[설비가동]
            MT3[실적집계]
        end
    end
```

## 설정 및 구성

### Global_Variable

```mermaid
flowchart LR
    A[Global_Variable] --> B[DB 연결설정]
    A --> C[WCF 설정]
    A --> D[WebService 설정]
    A --> E[사용자 정보]
    A --> F[공통 코드]
    
    B --> B1[IP, Port, SID]
    C --> C1[Address, Binding]
    D --> D1[URL, Timeout]
    E --> E1[UserID, Dept, Plant]
    F --> F1[Code Dictionary]
```

### 주요 설정 항목

```csharp
public static class Global_Variable
{
    // 시스템 설정
    public static string CLIENT = "HNS";
    public static string COMPANY = "001";
    
    // DB 연결
    public static string strOracle_IP = "10.x.x.7";
    public static string strOracle_Port = "1522";
    public static string strOracle_SID = "CDBHNSMES";

    // WCF 설정
    public static string strWCF_Address = "net.tcp://10.x.x.7:8101/WCF_SERVICE";
    public static bool UseWCF = true;
    
    // 사용자 정보
    public static string strUserID;
    public static string strUserName;
    public static string strDeptCode;
    public static string strPlantCode;
}
```

## 보안 아키텍처

```mermaid
flowchart TB
    subgraph Auth["인증/인가"]
        A[로그인] --> B{인증 성공?}
        B -->|Yes| C[세션 생성]
        B -->|No| D[오류 반환]
        C --> E[권한 로드]
        E --> F[화면 접근 제어]
    end
    
    subgraph Enc["암호화"]
        G[Triple DES] --> H[암호화 저장]
        I[Base64] --> J[전송 인코딩]
    end
    
    subgraph Validation["입력 검증"]
        K[SQL Injection 방지]
        L[XSS 방지]
        M[파라미터 검증]
    end
```

---

## 참고 자료

- [→ 개발 가이드](../guide/project-structure.md)
- [→ 데이터베이스](../database/overview.md)
- [→ 화면 명세](../screens/overview.md)
