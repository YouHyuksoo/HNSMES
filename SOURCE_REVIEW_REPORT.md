# HAENGSUNG HNSMES UI 프로젝트 소스 리뷰 보고서

**작성일**: 2026-02-06
**대상 프로젝트**: HAENGSUNG_HNSMES_UI (HAENGSUNG CDB HNS MES)
**솔루션 파일**: HAENGSUNG_HNSMES_UI_DBESS.sln

---

## 1. 프로젝트 개요

| 항목 | 내용 |
|------|------|
| **프로젝트명** | HAENGSUNG CDB HNS MES (제조실행시스템) |
| **프레임워크** | .NET Framework 4.0, WinForms |
| **UI 라이브러리** | DevExpress 13.2 |
| **데이터베이스** | Oracle (WCF/WebService 경유) |
| **통신** | WCF (NetTcp:8101), GZip 압축, Triple DES 암호화 |
| **배포** | ClickOnce |
| **소스 파일** | 약 962개 .cs 파일 (Designer 제외) |
| **Visual Studio** | Visual Studio 2019 (v16) |

---

## 2. 아키텍처 구조

```
+-- PRESENTATION LAYER -------------------------------------------+
|  MainForm + 900개 Forms (MAT/MNT/MST/PRD/RPT/SAL/SYS/COM/OSC) |
|  + UserControl 11개 (COM/MNT/SAL)                               |
+-- BUSINESS LOGIC LAYER -----------------------------------------+
|  Base.Class (35개): Grid/Log/WCF/Excel/Hardware 헬퍼             |
|  Global (2개): 전역변수(Global_Variable01), 유틸함수(GlobalFunction)|
|  MyClass (3개): 추가 유틸리티                                     |
+-- DATA ACCESS LAYER --------------------------------------------+
|  WebService.Access (3개): WCF/WS 클라이언트 래퍼                  |
|  WebService.Business (3개): IDatabaseProcess Interface + 구현체   |
|  DirectCon.cs: 직접 Oracle 연결 (고성능 바코드 스캔 용도)          |
+-- EXTERNAL / INFRASTRUCTURE ------------------------------------+
|  Oracle Database / FTP Server / 바코드프린터(Serial/LPT)          |
|  네트워크 공유(SMB) / TCP Socket                                  |
+-----------------------------------------------------------------+
```

### 2.1 모듈 구성

| 모듈 | 설명 | 파일 수 (약) |
|------|------|-------------|
| **MAT** | 자재관리 (입고, IQC, 재고, 유효기한) | 148 |
| **MNT** | 보전관리 (SMT 라인 관리) | 40 |
| **MST** | 기준정보 (마스터 데이터 관리) | 212 |
| **PRD** | 생산관리 (작업지시, 실적, 공정) | 416 |
| **RPT** | 리포트 (보고서 생성/조회) | 162 |
| **SAL** | 영업관리 (수주/출하) | 80 |
| **SYS** | 시스템관리 (사용자/권한/설정) | 92 |
| **COM** | 공통 (로그인, 설정, 진행표시) | 38 |
| **OSC** | 모니터링/테스트 | 10 |
| **SAMPLE** | 샘플/데모 | 10 |
| **Base** | 기본 폼 프레임워크 | 4 |

### 2.2 핵심 기술 스택

- **UI 컨트롤**: DevExpress XtraEditors, XtraGrid, XtraLayout, XtraBars
- **데이터 통신**: WCF (NetTcp), Legacy SOAP WebService
- **하드웨어 연동**: SerialPort (바코드 스캐너), LPT (프린터), TCP Socket
- **파일 처리**: FTP 업/다운로드, Excel COM Interop, 네트워크 공유(SMB)
- **보안**: Triple DES 암호화, GZip 메시지 압축
- **배포**: ClickOnce (자동 업데이트, IP Failover)

---

## 3. 긍정적 평가 (잘된 점)

### 3.1 일관된 폼 계층구조
- `BASE.Form` -> 개별 폼 상속 패턴이 전체 프로젝트에 일관되게 적용
- `itfButton` 인터페이스로 Init/New/Save/Search/Delete/Print 버튼 이벤트 표준화
- `itfScanner` 인터페이스로 바코드 스캐너 입력 표준화

### 3.2 헬퍼 클래스 패턴
- `BASE_DXGridHelper`: DevExpress Grid 바인딩/컬럼설정/서머리/병합 캡슐화
- `BASE_DXGridLookUpHelper`: GridLookUp 컨트롤 바인딩 캡슐화
- 반복적인 DevExpress 설정 코드를 줄이고 일관성 확보

### 3.3 다국어 지원
- `LanguageInformation` 클래스로 한국어/영어 지원
- 메시지 코드 외부화 ("MSG005", "MSG_ER_MAT_072" 등)
- DB 기반 용어집 관리

### 3.4 Strategy 패턴 적용
- `IDatabaseProcess` 인터페이스 정의
- `WCFDatabaseProcess`: WCF 구현체
- `WSDatabaseProcess`: Legacy WebService 구현체
- 서비스 레이어 교체 가능한 구조

### 3.5 배포 인프라
- ClickOnce 자동 업데이트
- IP Failover 지원 (10.2.31.9 / 10.2.30.9)
- 단일 인스턴스 실행 (Mutex)
- 스플래시 스크린 및 버전 관리

---

## 4. 심각한 보안 취약점 (CRITICAL)

### 4.1 하드코딩된 자격증명

> **심각도: CRITICAL**
> 소스 코드에 비밀번호와 사용자명이 직접 기입되어 있어, 소스 접근 시 모든 자격증명이 노출됩니다.

| 파일 | 라인 | 노출 내용 |
|------|------|-----------|
| `Global\Global_Variable01.cs` | 78 | FTP 비밀번호: `Admin!@#$%` |
| `Global\Global_Variable01.cs` | 76 | FTP 사용자명: `MESUSER` |
| `Base.Class\SharedAPI.cs` | 54-63 | SMB 공유 비밀번호: `ethmes123!@#`, 사용자명: `crimping` |
| `Forms\COM\Password.cs` | - | 마스터 비밀번호: `hseth2019` |
| `Base.Class\WCF\SecurityTripleDES.cs` | 41-42 | 암호화 키: `Copyright NG Soft 2015..` |

**권고사항**:
- 모든 자격증명을 암호화된 설정 파일 또는 비밀 관리 시스템(Vault 등)으로 이동
- 소스 코드에서 즉시 제거
- 노출된 비밀번호 즉시 변경

### 4.2 SQL Injection 취약점

> **심각도: CRITICAL**

```csharp
// WebService.Access\WebServiceProcess.cs:179
// Raw SQL 문자열을 검증 없이 직접 전달
public WSResults ExecuteQry(string strQry)
{
    result = WebSvr.ExecuteQry(strQry);  // 파라미터 검증 없음!
}

// Global\GlobalFunction.cs:49
// Excel 시트명으로 SQL Injection 가능
comm.CommandText = "select * from [" + sSheetName + "$]";
```

**권고사항**:
- `ExecuteQry()` 메서드의 raw SQL 전달 방식 제거
- 모든 쿼리를 파라미터화된 저장 프로시저 호출로 통일
- 사용자 입력값 검증 레이어 추가

### 4.3 취약한 암호화

> **심각도: HIGH**

| 문제 | 설명 |
|------|------|
| Triple DES 사용 | 2017년 NIST 폐기 권고, AES-256으로 전환 필요 |
| Key/IV 동일값 | 암호학적 원칙 위반, 패턴 분석 가능 |
| 하드코딩된 키 | 바이너리 리버스 엔지니어링으로 키 추출 가능 |
| Salt/Random IV 미사용 | 결정론적 암호화 → 동일 입력 = 동일 출력 |
| 무결성 검증 없음 | 암호문 변조 감지 불가 |

**권고사항**:
- AES-256-GCM으로 전환 (인증된 암호화)
- Key/IV 분리, Random IV 생성
- 키 관리 시스템 도입

### 4.4 무제한 리소스 설정 (DoS 취약)

> **심각도: HIGH**

```csharp
// Base.Class\WCF\DatabaseServiceClientHelper.cs:79-91
tcp.MaxReceivedMessageSize = int.MaxValue;       // ~2GB 메시지 허용
tcp.MaxBufferPoolSize = int.MaxValue;             // 무제한 버퍼 풀
tcp.ReaderQuotas.MaxStringContentLength = int.MaxValue;
tcp.ReaderQuotas.MaxArrayLength = int.MaxValue;
tcp.OpenTimeout = TimeSpan.MaxValue;              // 무한 대기
tcp.ReceiveTimeout = TimeSpan.MaxValue;
tcp.SendTimeout = TimeSpan.MaxValue;
```

**권고사항**:
- 적절한 메시지 크기 제한 설정 (예: 10MB)
- 타임아웃 값 설정 (예: 30초~2분)
- 버퍼 풀 크기 제한

### 4.5 안전하지 않은 파일 다운로드

> **심각도: HIGH**

```csharp
// WebService.Access\WebServiceProcess.cs:342-373
public bool WsDownload(string filePath, string serverPath)
{
    hr = HttpWebRequest.Create(serverPath) as HttpWebRequest;  // URL 검증 없음
    fs = new FileStream(filePath, FileMode.Create);            // 경로 검증 없음
}
```

- 경로 탐색(Path Traversal) 취약점
- SSL/TLS 미강제
- 파일 크기 제한 없음

### 4.6 HTTP 사용 (비암호화 통신)

> **심각도: HIGH**

```xml
<!-- app.config -->
<value>http://218.158.2.71:8807/IDISYS_2012/IDAT_WebSvr.asmx</value>
```

- WebService 통신이 HTTP(평문)으로 수행
- 중간자 공격(MITM) 가능
- HTTPS로 전환 필요

---

## 5. 코드 품질 이슈

### 5.1 빈 예외 처리 (Empty Catch) — 프로젝트 전반에 만연

> **심각도: HIGH**

```csharp
// 패턴 1: 완전히 빈 catch
catch { }

// 패턴 2: Exception 변수만 선언
catch (Exception) { }

// 패턴 3: 콘솔에만 출력
catch (Exception ex) { Console.WriteLine(ex.Message); }

// 패턴 4: 주석 처리된 catch 조건
catch//(InvalidOperationException opEx)
{
    result.ReturnString = "disconnected WCF Service Server";
}
```

**발견 위치**:
- `DatabaseServiceClientHelper.cs`: 라인 185, 223, 263, 304
- `SecurityTripleDES.cs`: 라인 56, 72
- `WCFServiceProcess.cs`: 라인 70, 107, 179
- `WebServiceProcess.cs`: 라인 81, 126, 191
- 다수의 Form 파일들

**영향**: 오류 원인 추적 불가, 디버깅 난이도 극대화, 사일런트 실패

**권고사항**:
- 최소한 로그 기록 추가
- 구체적인 예외 타입 포착
- 비즈니스 로직에 맞는 예외 처리 전략 수립

### 5.2 리소스 누수

> **심각도: HIGH**

| 파일 | 문제 | 영향 |
|------|------|------|
| `ExcelHelper.cs` | COM 객체(Range, Worksheet) `Marshal.ReleaseComObject()` 미호출 | Excel 프로세스 잔존(좀비 프로세스) |
| `ExcelHelper.cs` | `IDisposable` 미구현 | 반복 호출 시 메모리 누적 |
| `LogHelper.cs:78` | `StreamWriter` using 문 미사용 | 예외 시 파일 핸들 누수 |
| `LogHelper.cs:99` | `StreamReader` using 문 미사용 | 예외 시 파일 핸들 누수 |
| `DXGridHelper.cs:774` | 이벤트 핸들러 해제 없이 반복 등록 | 메모리 누수, 중복 실행 |
| `DatabaseServiceClientHelper.cs` | WCF 채널 일부 경로에서 미정리 | 연결 누수 |

**권고사항**:
```csharp
// Before (현재)
StreamWriter sw = new StreamWriter(strFullName, true, Encoding.UTF8, 4096);
sw.WriteLine(strLog);
sw.Close();

// After (권고)
using (StreamWriter sw = new StreamWriter(strFullName, true, Encoding.UTF8, 4096))
{
    sw.WriteLine(strLog);
}
```

### 5.3 로직 오류

> **심각도: MEDIUM~HIGH**

#### (1) LogHelper.cs — OR/AND 혼동

```csharp
// 현재 코드 (라인 69-72) — 항상 true가 됨
if (strPath.EndsWith(@"\") == false || strPath.EndsWith("/") == false)
{
    strPath = strPath + @"\";
}

// 수정 필요 — AND로 변경
if (strPath.EndsWith(@"\") == false && strPath.EndsWith("/") == false)
{
    strPath = strPath + @"\";
}
```

#### (2) DXGridHelper.cs — 마지막 요소 누락

```csharp
// 현재 코드 (라인 670) — 마지막 요소 처리 안 됨
for (int i = 0; i < _strIntegerArray.Length - 1; i++)

// 수정 필요
for (int i = 0; i < _strIntegerArray.Length; i++)
```

#### (3) WSDatabaseProcess.cs — 의미 없는 조건

```csharp
// 현재 코드 (라인 217) — Length는 음수가 될 수 없음 (Dead Code)
if ((sArName.Length < 0) || (sArName.Length < 0))
    return oDs;
```

### 5.4 전역 상태 의존

> **심각도: MEDIUM**

```csharp
// Global\Global_Variable01.cs — 모든 세션 정보가 public static
public static string USER_ID = "";
public static string USERROLE = "";
public static string DEPTCODE = "";
public static string CLIENT = "1060";
public static string COMPANY = "40";
public static string PLANT = "P200";
public static string FTP_IP = "ftp://10.2.30.219";
public static string FTP_ID = "MESUSER";
public static string FTP_PW = "Admin!@#$%";
```

**문제점**:
- 스레드 안전하지 않음
- 단위 테스트 불가능
- 의존성 추적 어려움
- 다중 사용자 시 간섭 가능

**권고사항**:
- 세션 컨텍스트 클래스로 캡슐화
- 의존성 주입(DI) 패턴 적용
- 불변(immutable) 설정 객체 사용

### 5.5 UI-비즈니스 레이어 결합

> **심각도: MEDIUM**

```csharp
// WebService.Business\WCFDatabaseProcess.cs:73
// 비즈니스 레이어에서 직접 MessageBox 호출
iDATMessageBox.ShowProcResultMessage(_result, "Error",
    Global.Global_Variable.USER_ID, p_strProc, _dicPara);

// WebService.Access\WCFServiceProcess.cs:150
// 데이터 접근 레이어에서 직접 UI 상태 변경
Program.frmM.btnWCFStatus.ImageIndex = 0;
```

**문제점**: 계층 분리 원칙(SoC) 위반, 테스트 불가능, 재사용 불가

### 5.6 스레딩 이슈

> **심각도: MEDIUM**

```csharp
// DXGridHelper.cs:97-113
Task task = new Task(() => {
    while (queue.Count > 0) {
        Control.ControlCollection controls = (Control.ControlCollection)queue.Dequeue();
        foreach (Control control in controls) {
            allControls.Add(control);  // List<T>는 스레드 안전하지 않음!
        }
    }
});
task.Start();
task.Wait();
```

### 5.7 매직 넘버/문자열

> **심각도: LOW~MEDIUM**

```csharp
// 의미 불명확한 숫자 파라미터
BASE_DXGridHelper.Bind_Grid_Int(gcList, "PKGPRD_PROD.GET_CREATEWRKORDINFO", 1,
    new string[] { "A_CLIENT", ... },
    new string[] { Global.Global_Variable.CLIENT, ... },
    true, "", false, "QTY,ITEMCODE"
);

// 하드코딩된 컬럼명 검색
if (gc.FieldName.IndexOf("SEL") > -1) { ... }
if (gc.FieldName.IndexOf("USEFLAG") > -1) { ... }
```

### 5.8 네이밍 불일치

| 패턴 | 예시 |
|------|------|
| 파라미터 접두사 | `p_strProc`, `p_iProcSeq`, `p_dicPara` |
| 로컬 변수 접두사 | `_strReturn`, `_dicPara`, `_result` |
| 멤버 변수 접두사 | `mIP`, `mPort`, `mUserID` |
| 메서드명 불일치 | `ExecuteProcCls` vs `Execute_Proc` / `GetWsConnectStatus` vs `get_DataBase` |
| 오타 | `SharedAPI.CencelRemoteServer()` (Cancel 오타), `FTPHepler.cs` (Helper 오타) |

---

## 6. 코드 관리 이슈

### 6.1 bak 폴더 문제

> **심각도: MEDIUM**

약 **836개 백업 파일**이 다수의 `bak/` 폴더에 존재:

```
Forms/MAT/bak/      Forms/MNT/bak/      Forms/MST/bak/
Forms/MST/PopUp/bak/  Forms/PRD/bak/    Forms/RPT/bak/
Forms/SAL/bak/       Forms/SYS/bak/
```

**문제점**:
- 수동 백업 방식 → 버전 관리 시스템(VCS) 미사용 또는 불완전 적용
- 코드 분기 위험 (어떤 버전이 최신인지 불명확)
- 프로젝트 크기 불필요하게 증가

**권고사항**:
- Git 저장소 초기화 및 모든 bak 폴더 제거
- `.gitignore` 설정으로 빌드 산출물 제외
- Git 브랜치로 버전 관리

### 6.2 미사용/Dead Code

| 파일 | 상태 |
|------|------|
| `Base.Class\WCF\ReturnDataStructure.cs` | 전체 주석 처리 (Dead Code) |
| `MyClass\myClass1.cs` | 빈 클래스 |
| `MyClass\myClass2.cs` | 빈 클래스 |

### 6.3 날짜 형식 문화권 의존

```csharp
// LogHelper.cs:74 — 로그 파일명에 문화권 의존 날짜 사용
strFullName = strPath + strFileName + "_" + DateTime.Now.ToShortDateString() + ".txt";
```

- `ToShortDateString()`은 시스템 문화권에 따라 형식이 달라짐
- 특수문자(`/`)가 포함될 수 있어 파일명 오류 가능
- `DateTime.Now.ToString("yyyyMMdd")` 등 고정 형식 사용 권고

### 6.4 경로 처리

```csharp
// 현재: 문자열 연결
strFullName = strPath + strFileName + "_" + DateTime.Now.ToShortDateString() + ".txt";

// 권고: Path.Combine 사용
strFullName = Path.Combine(strPath, strFileName + "_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
```

---

## 7. 성능 이슈

### 7.1 Excel COM Interop 셀 단위 접근

```csharp
// ExcelHelper.cs — 셀 단위 COM 호출 (매우 느림)
for (int i = 1; i <= xlRange.Rows.Count; i++) {
    for (int j = 1; j <= xlRange.Columns.Count; j++) {
        row[j - 1] = xlRange.Cells[i, j].value;  // 1000x100 = 100,000 COM 호출
    }
}
```

**권고**: Range 일괄 읽기 또는 OleDb/EPPlus 라이브러리 사용

### 7.2 매 호출마다 서비스 인스턴스 생성

```csharp
// WCFDatabaseProcess.cs — 매 메서드 호출마다 new
public WSResults Execute_Proc(string p_strProc, int p_iProcSeq, ...)
{
    WCFServiceProcess _db = new WCFServiceProcess();  // 매번 새 인스턴스
    WSResults _result = _db.ExecuteProcCls(...);
    return _result;
}
```

**권고**: 인스턴스 재사용 또는 풀링 고려

---

## 8. 데이터 접근 패턴

### 8.1 저장 프로시저 명명 규칙

```
PKG_<모듈>_<엔티티>.GET_<조회동작>
PKG_<모듈>_<엔티티>.SET_<저장동작>

예시:
- PKGMAT_INOUT.GET_IQC_SERIAL
- PKGMAT_INOUT.SET_IQC_JUDGE
- PKGPRD_PROD.GET_CREATEWRKORDINFO
- PKG_USER.SET_USERMASTER
- PKGSYS_COMM.PUT_USESYSTEM
```

### 8.2 파라미터 전달 방식

```csharp
// 병렬 배열 방식 (현재)
BASE_db.Execute_Proc("PKGMAT_INOUT.SET_IQC_JUDGE", 1,
    new string[] { "A_CLIENT", "A_COMPANY", "A_PLANT", "A_LOTNO" },
    new object[] { Global.Global_Variable.CLIENT, Global.Global_Variable.COMPANY,
                   Global.Global_Variable.PLANT, txtLotNo.EditValue }
);
```

**문제점**: 파라미터명과 값의 인덱스 불일치 위험, 타입 안전성 없음

### 8.3 결과 처리 방식

```csharp
// DataTable 직접 접근 (ORM 미사용)
DataSet ds = BASE_db.Get_DataBase(...);
string value = ds.Tables[0].Rows[0]["COLUMN_NAME"].ToString();
int qty = int.Parse(ds.Tables[0].Rows[0]["QTY"].ToString());
```

**문제점**: 컬럼명 오타 시 런타임 오류, 타입 변환 실패 위험

---

## 9. 개선 권고사항 (우선순위별)

### 즉시 조치 (CRITICAL — 보안)

| # | 항목 | 관련 파일 |
|---|------|-----------|
| 1 | 하드코딩된 모든 자격증명 제거 및 비밀번호 변경 | Global_Variable01.cs, SharedAPI.cs, Password.cs, SecurityTripleDES.cs |
| 2 | `ExecuteQry()` raw SQL 전달 방식 제거, 파라미터화 적용 | WebServiceProcess.cs, WSDatabaseProcess.cs |
| 3 | Triple DES -> AES-256 전환, Key/IV 분리, Random IV | SecurityTripleDES.cs |
| 4 | HTTP -> HTTPS 전환 (모든 웹서비스 통신) | app.config |
| 5 | WCF 메시지크기/타임아웃 적절한 값으로 제한 | DatabaseServiceClientHelper.cs |
| 6 | 파일 다운로드 경로/URL 검증 추가 | WebServiceProcess.cs |

### 단기 조치 (HIGH — 안정성)

| # | 항목 | 관련 파일 |
|---|------|-----------|
| 7 | 빈 catch 블록에 로깅 추가 | 프로젝트 전반 |
| 8 | using 문 적용으로 리소스 누수 해결 | ExcelHelper.cs, LogHelper.cs |
| 9 | LogHelper.cs OR->AND 로직 오류 수정 | LogHelper.cs:69 |
| 10 | DXGridHelper.cs 루프 범위 오류 수정 | DXGridHelper.cs:670 |
| 11 | COM 객체 Marshal.ReleaseComObject() 적용 | ExcelHelper.cs |
| 12 | bak 폴더 정리 및 Git 버전 관리 도입 | Forms/*/bak/ |

### 중장기 조치 (MEDIUM — 아키텍처)

| # | 항목 | 설명 |
|---|------|------|
| 13 | 전역 변수 -> 의존성 주입(DI) 패턴 전환 | 세션 컨텍스트 클래스 도입 |
| 14 | 비즈니스 레이어에서 UI 코드 분리 | MessageBox, UI 상태 변경 제거 |
| 15 | async/await 도입 | UI 응답성 개선 |
| 16 | 단위 테스트 인프라 구축 | 테스트 프로젝트 추가 |
| 17 | Dead Code 정리 | ReturnDataStructure.cs, myClass1/2.cs |
| 18 | .NET Framework 업그레이드 검토 | 4.0 -> 4.8 또는 .NET 6+ |
| 19 | DevExpress 버전 업그레이드 | 13.2 -> 최신 LTS |
| 20 | 네이밍 컨벤션 통일 | 코딩 표준 문서 작성 및 적용 |

---

## 10. 보안 취약점 요약 테이블

| 취약점 | 위치 | 심각도 | 유형 |
|--------|------|--------|------|
| 하드코딩 FTP 비밀번호 | Global_Variable01.cs:78 | CRITICAL | 자격증명 노출 |
| 하드코딩 FTP 사용자명 | Global_Variable01.cs:76 | CRITICAL | 자격증명 노출 |
| 하드코딩 SMB 비밀번호 | SharedAPI.cs:54-63 | CRITICAL | 자격증명 노출 |
| 하드코딩 마스터 비밀번호 | Password.cs | CRITICAL | 자격증명 노출 |
| 하드코딩 암호화 키 | SecurityTripleDES.cs:41-42 | CRITICAL | 키 노출 |
| SQL Injection (ExecuteQry) | WebServiceProcess.cs:179 | CRITICAL | 입력 검증 |
| SQL Injection (시트명) | GlobalFunction.cs:49 | HIGH | 입력 검증 |
| 경로 탐색 (다운로드) | WebServiceProcess.cs:342 | HIGH | 경로 검증 |
| 경로 탐색 (Excel 임포트) | GlobalFunction.cs:36 | HIGH | 경로 검증 |
| 무제한 메시지 크기 | DatabaseServiceClientHelper.cs:79-91 | HIGH | DoS |
| 무제한 타임아웃 | DatabaseServiceClientHelper.cs:82-86 | HIGH | DoS |
| HTTP 평문 통신 | app.config:72 | HIGH | 암호화 |
| FTP 평문 통신 | Global_Variable01.cs:74 | HIGH | 암호화 |
| Triple DES 사용 | SecurityTripleDES.cs | HIGH | 취약 암호화 |
| 빈 catch 블록 | 프로젝트 전반 | HIGH | 오류 처리 |
| 예외 정보 누출 | WCFServiceProcess.cs:75 | MEDIUM | 정보 노출 |
| Static 세션 변수 | Global_Variable01.cs:38-48 | MEDIUM | 상태 관리 |

---

## 11. 종합 평가

| 영역 | 점수 (10점) | 평가 |
|------|------------|------|
| **아키텍처** | 7 | 계층 구조 양호, 인터페이스 패턴 적용, Strategy 패턴 사용 |
| **기능 완성도** | 8 | MES 핵심 기능 충실히 구현, 다국어/하드웨어 연동, 11개 모듈 |
| **코드 일관성** | 6 | 폼 패턴은 일관적이나 네이밍/예외처리 불일치 |
| **코드 품질** | 5 | 예외 처리 미흡, 로직 오류, 리소스 누수, Dead Code |
| **보안** | 3 | 하드코딩 자격증명, SQL Injection, 취약한 암호화, HTTP |
| **유지보수성** | 4 | 전역 상태 의존, bak 폴더, UI-비즈니스 결합, 테스트 부재 |
| **성능** | 5 | Excel COM 비효율, 매번 서비스 인스턴스 생성, 무제한 리소스 |

### 종합 점수: 5.4 / 10

기능적으로는 완성도 높은 MES 시스템이나, **보안 취약점**과 **코드 품질 이슈**가 즉각적인 개선을 필요로 합니다.
특히 하드코딩된 비밀번호와 SQL Injection 취약점은 **즉시 수정**이 필요합니다.

---

*본 리뷰는 소스 코드 정적 분석 기반으로 작성되었으며, 런타임 테스트는 포함되지 않았습니다.*
