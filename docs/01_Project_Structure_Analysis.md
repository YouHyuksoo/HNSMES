# Phase 1: 프로젝트 정적 구조 분석

## 1.1 프로젝트 개요

| 항목 | 내용 |
|------|------|
| **프로젝트명** | HAENGSUNG HNSMES UI |
| **프레임워크** | .NET Framework 4.0 |
| **UI 기술** | WinForms + DevExpress 13.2 |
| **통신** | WCF (TCP) + Legacy WebService (HTTP) |
| **데이터베이스** | Oracle |
| **총 C# 파일 수** | 약 448개 |

---

## 1.2 폼(Forms) 모듈별 파일 통계

| 모듈 | 파일 수 | 주요 기능 |
|------|--------|-----------|
| **PRD** (생산관리) | 46 | 작업지시, 생산실적, 공정관리 |
| **MAT** (자재관리) | 26 | 입고, IQC, 재고관리, 유효기한 |
| **MST** (기준정보) | 23 | 마스터 데이터 관리 |
| **RPT** (리포트) | 22 | 보고서 생성/조회 |
| **COM** (공통) | 20 | 로그인, 설정, 시스템관리 |
| **SYS** (시스템) | 18 | 사용자/권한/코드관리 |
| **MNT** (보전관리) | 13 | SMT 라인 관리, 설비보전 |
| **SAL** (영업관리) | 9 | 수주/출하 관리 |
| **SAMPLE** | 5 | 샘플/데모 화면 |
| **OSC** | 5 | 모니터링/테스트 |
| **Base** | 2 | 기본 폼 프레임워크 |

**총 Forms 파일 수**: 187개 (Designer 파일 제외 약 376개)

---

## 1.3 공통 컴포넌트 (Base.Class)

### 1.3.1 핵심 헬퍼 클래스

| 파일 | 역할 |
|------|------|
| `DXGridHelper.cs` | DevExpress Grid 바인딩/설정 캡슐화 |
| `DXGridLookUpHelper.cs` | GridLookUpEdit 컨트롤 헬퍼 |
| `iDATControlBinding.cs` | 컨트롤 데이터바인딩 |
| `iDATMessageBox.cs` | 메시지박스 래퍼 (다국어) |
| `Data.cs` | 데이터 처리 유틸리티 |

### 1.3.2 WCF 관련 클래스

| 파일 | 역할 |
|------|------|
| `DatabaseServiceClientHelper.cs` | WCF 클라이언트 팩토리 |
| `DatabaseService.cs` | WCF 서비스 인터페이스 |
| `GZipMessageEncoderFactory.cs` | GZip 압축 인코더 |
| `SecurityTripleDES.cs` | Triple DES 암호화 |
| `WCFClient.cs` | WCF 클라이언트 래퍼 |

### 1.3.3 하드웨어 연동

| 파일 | 역할 |
|------|------|
| `SocketClient.cs` | TCP 소켓 통신 |
| `ScannerProcess.cs` | 바코드 스캐너 처리 |
| `clsPrintBarcode.cs` | 바코드 프린터 제어 |
| `clsLPT.cs` | LPT 포트 제어 |

### 1.3.4 유틸리티

| 파일 | 역할 |
|------|------|
| `DirectCon.cs` | Oracle 직접 연결 (고성능 바코드용) |
| `ExcelHelper.cs` | Excel COM Interop 헬퍼 |
| `FTPHepler.cs` | FTP 파일 전송 |
| `LanguageInformation.cs` | 다국어 지원 |
| `LogHelper.cs` / `LogUtility.cs` | 로깅 유틸리티 |
| `SharedAPI.cs` | 공통 API 함수 |

---

## 1.4 아키텍처 패턴 분석

### 1.4.1 폼 상속 구조

```
System.Windows.Forms.Form
    └── BASE.Form (Forms/Base/Form.cs)
            ├── PRDA201 ~ PRDA222 (생산관리)
            ├── MATA201 ~ MATA210 (자재관리)
            ├── MSTA201 ~ MSTA221 (기준정보)
            ├── RPTA201 ~ RPTA216 (리포트)
            ├── SALA201 ~ SALA204 (영업관리)
            ├── SYSA201 ~ SYSA215 (시스템)
            ├── MNTA201 ~ MNTB207 (보전관리)
            ├── COMLOGIN, COMREGISTER 등 (공통)
            └── ...
```

**BASE.Form 상속 폼 수**: 약 180개+

### 1.4.2 인터페이스 구현

#### itfButton 인터페이스
표준 버튼 이벤트를 정의하는 인터페이스입니다.

```csharp
public interface itfButton
{
    void InitButton_Click();    // 초기화
    void NewButton_Click();     // 신규
    void EditButton_Click();    // 수정
    void SaveButton_Click();    // 저장
    void DeleteButton_Click();  // 삭제
    void SearchButton_Click();  // 조회
    void PrintButton_Click();   // 인쇄
    void StopButton_Click();    // 중지
    void RefreshButton_Click(); // 새로고침
}
```

**구현 폼 수**: 약 160개+

#### itfScanner 인터페이스
바코드 스캐너 입력 처리 인터페이스입니다.

```csharp
public interface itfScanner
{
    void ScannerProcess(string sBarCode);
}
```

---

## 1.5 데이터 접근 패턴

### 1.5.1 레이어 구조

```
[Presentation Layer]
    Form (PRDA201 등)
    ↓
[Business Layer]
    WCFDatabaseProcess / WSDatabaseProcess
    IDatabaseProcess 인터페이스 (Strategy 패턴)
    ↓
[Access Layer]
    WCFServiceProcess (TCP:8101) 
    WebServiceProcess (HTTP:8807)
    ↓
[Database Layer]
    Oracle Database
```

### 1.5.2 주요 데이터 메서드 호출 통계

| 메서드 | 호출 횟수 | 설명 |
|--------|----------|------|
| `Execute_Proc` | 200+ | 저장 프로시저 실행 (WCF) |
| `ExecuteProcCls` | 200+ | 저장 프로시저 실행 (WebService) |

### 1.5.3 데이터 바인딩 패턴

```csharp
// 조회 패턴
WSResults result = BASE_db.Execute_Proc(
    "PKGPRD_PROD.GET_WORK_RESULT",  // 프로시저명
    1,                              // 순번
    new string[] { "A_CLIENT", "A_COMPANY", ... },  // 파라미터명
    new object[] { CLIENT, COMPANY, ... }           // 파라미터값
);

if (result.ResultInt == 0)
{
    gcList.DataSource = result.ResultDataSet.Tables[0];
}
```

---

## 1.6 네이밍 컨벤션

### 1.6.1 폼 ID 체계

| 모듈 | ID 패턴 | 예시 |
|------|---------|------|
| 생산관리 | PRD[A-Z][0-9]{3} | PRDA201 (작업실적등록) |
| 자재관리 | MAT[A-Z][0-9]{3} | MATA201 (자재입고등록) |
| 기준정보 | MST[A-Z][0-9]{3} | MSTA201 (품목정보관리) |
| 리포트 | RPT[A-Z][0-9]{3} | RPTA201 (생산일보) |
| 영업관리 | SAL[A-Z][0-9]{3} | SALA201 (수주등록) |
| 시스템 | SYS[A-Z][0-9]{3} | SYSA201 (사용자관리) |
| 보전관리 | MNT[A-Z][0-9]{3} | MNTA201 (라인정보) |
| 공통 | COM[A-Z]{3,} | COMLOGIN, COMREGISTER |

### 1.6.2 저장 프로시저 명명 규칙

```
PKG<모듈>_<엔티티>.<동작>_<대상>

예시:
- PKGMAT_INOUT.GET_IQC_SERIAL
- PKGMAT_INOUT.SET_IQC_JUDGE
- PKGPRD_PROD.GET_CREATEWRKORDINFO
- PKG_USER.SET_USERMASTER
- PKGSYS_COMM.PUT_USESYSTEM
```

---

## 1.7 파일 크기 분포

| 디렉토리 | 파일 수 | 크기(KB) | 비고 |
|----------|--------|----------|------|
| Forms | 376 | 12,123 | 핵심 비즈니스 로직 |
| Base.Class | 35 | 364 | 공통 컴포넌트 |
| UserControl | 17 | 298 | 사용자 정의 컨트롤 |
| WebService.Business | 3 | 20 | 데이터 접근 비즈니스 |
| WebService.Access | 3 | 20 | 서비스 클라이언트 |
| Global | 2 | 12 | 전역 변수/함수 |
| Resources | - | 5,409 | 리소스 파일 |
| IMAGE | - | 101,505 | 이미지 리소스 |

---

## 1.8 주요 특이사항

1. **bak 폴더 다수 존재**: 각 모듈별로 백업 파일이 있어 버전 관리가 필요
2. **이중화 통신**: WCF(TCP)와 WebService(HTTP) 병행 사용
3. **전역 상태 의존**: `Global.Global_Variable` 클래스에 세션 정보 집중
4. **하드코딩된 설정**: DB 연결정보, FTP 정보 등이 코드에 직접 기입됨
5. **DevExpress 의존성**: UI 컨트롤 100% DevExpress 기반

---

## 다음 단계

Phase 2에서는 다음을 진행합니다:
1. Oracle DB 연결 및 스키마 탐색
2. 저장 프로시저 목록 추출 및 분류
3. 화면-DB 매핑 분석
