# 개발 환경 설정

이 문서는 HNSMES UI 개발을 위한 완전한 환경 설정 가이드입니다.

## 시스템 요구사항

### 최소 사양

| 항목 | 요구사항 |
|------|----------|
| **OS** | Windows 7 SP1 이상 |
| **CPU** | Intel Core i3 이상 |
| **RAM** | 4GB 이상 |
| **HDD** | 10GB 여유 공간 |
| **네트워크** | 내트워크 연결 (DB 서버 접근) |

### 권장 사양

| 항목 | 요구사항 |
|------|----------|
| **OS** | Windows 10/11 (64bit) |
| **CPU** | Intel Core i5/i7 이상 |
| **RAM** | 8GB 이상 |
| **SSD** | 20GB 여유 공간 |
| **디스플레이** | 1920x1080 이상 |

## 필수 소프트웨어 설치

### 1. Visual Studio

#### 설치 버전

- **권장**: Visual Studio 2022 Community/Professional/Enterprise
- **최소**: Visual Studio 2012 Professional

#### 설치 구성 요소

```
☑ .NET Framework 4.0 타겟팅 팩
☑ .NET Framework 4.5+ 타겟팅 팩
☑ Windows Forms 앱 개발
☑ Git for Windows
☑ SQL Server Data Tools (선택)
```

#### 설치 단계

1. [Visual Studio 다운로드](https://visualstudio.microsoft.com/downloads/)
2. 설치 프로그램 실행
3. 위 구성 요소 선택
4. 설치 완료 후 재부팅

### 2. .NET Framework 4.0

Windows 8/10/11의 경우 기본 포함되어 있습니다.

```powershell
# 설치 확인
reg query "HKLM\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full" /v Version

# 또는 PowerShell
(Get-ItemProperty "HKLM:SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full").Version
```

### 3. Oracle Client

#### Oracle Instant Client 설치

1. [Oracle Instant Client 다운로드](https://www.oracle.com/database/technologies/instant-client/downloads.html)
2. **Basic** 또는 **Basic Light** 패키지 선택
3. 시스템 PATH에 추가:

```powershell
# 환경 변수 설정
[Environment]::SetEnvironmentVariable(
    "PATH", 
    $env:PATH + ";C:\oracle\instantclient_11_2",
    "Machine"
)
```

#### tnsnames.ora 설정

```
# C:\oracle\instantclient_11_2\network\admin\tnsnames.ora

CDBHNSMES =
  (DESCRIPTION =
    (ADDRESS = (PROTOCOL = TCP)(HOST = 10.2.30.7)(PORT = 1522))
    (CONNECT_DATA = (SERVICE_NAME = CDBHNSMES))
  )
```

### 4. DevExpress 13.2

#### 라이선스 확인

- **MPL (Multi-Platform License)** 확인
- 설치 미디어 또는 다운로드 링크 확보

#### 설치 단계

1. DevExpressUniversal-13.2.x.exe 실행
2. 컴포넌트 선택:
   - Windows Forms Controls
   - Reporting
   - Charting
3. GAC에 어셈블리 등록
4. Visual Studio 통합 설정

#### 라이선스 파일 설정

```
# 프로젝트 루트에 licenses.licx 파일 생성
DevExpress.XtraGrid.GridControl, DevExpress.XtraGrid.v13.2
DevExpress.XtraEditors.TextEdit, DevExpress.XtraEditors.v13.2
# ... 기타 사용 컴포넌트
```

### 5. Git (선택)

```powershell
# chocolatey로 설치
choco install git

# 또는 직접 다운로드
# https://git-scm.com/download/win
```

## 환경 변수 설정

### 시스템 환경 변수

```powershell
# Oracle
[Environment]::SetEnvironmentVariable("ORACLE_HOME", "C:\oracle\instantclient_11_2", "Machine")
[Environment]::SetEnvironmentVariable("TNS_ADMIN", "C:\oracle\instantclient_11_2\network\admin", "Machine")

# DevExpress (필요시)
[Environment]::SetEnvironmentVariable("DEVEXPRESS_PATH", "C:\Program Files (x86)\DevExpress 13.2\Components", "Machine")
```

### 사용자 환경 변수

```powershell
# 프로젝트 경로
[Environment]::SetEnvironmentVariable("HNSMES_HOME", "C:\Project\HNSMES", "User")
```

## 개발 도구 설정

### Visual Studio 설정

#### 1. 코드 스타일 설정

```
도구 > 옵션 > 텍스트 편집기 > C# > 코딩 규칙

- Using 지시문 정렬: 사용
- 개행 옵션: K&R 스타일
- 들여쓰기: 4칸 공백
```

#### 2. NuGet 패키지 관리자

```
도구 > 옵션 > NuGet 패키지 관리자 > 패키지 원본

- nuget.org: https://api.nuget.org/v3/index.json
- 나이트레스트 나이부트: (사낵 패키지 원본 추가)
```

#### 3. 디버깅 설정

```
디버그 > 옵션 및 설정 > 디버깅 > 일반

☑ 예외가 Throw될 때 중단: Common Language Runtime
☑ 소스 서버 지원 사용
☑ .NET Framework 소스 스텝핑 사용
```

### SQL Developer 설정 (선택)

1. [SQL Developer 다운로드](https://www.oracle.com/tools/downloads/sqldev-downloads.html)
2. Oracle Instant Client와 연동:

```
도구 > 환경 설정 > 데이터베이스 > 타사 JDBC 드라이버
- ojdbc6.jar 추가
```

3. 연결 설정:
   - 이름: HNSMES_DEV
   - 사용자 이름: MESUSER
   - 비밀번호: mesuser
   - 호스트: 10.2.30.7
   - 포트: 1522
   - SID: CDBHNSMES

## 프로젝트 환경 설정

### 1. 저장소 클론

```powershell
# Git 사용
git clone https://github.com/haengsung/hnsmes-ui.git
cd hnsmes-ui

# 또는 ZIP 다운로드
# 압축 해제 후 작업 디렉토리로 이동
```

### 2. 설정 파일 수정

#### Global_Variable.cs

```csharp
// 파일 위치: HAENGSUNG_HNSMES_UI/Global/Global_Variable.cs

public static class Global_Variable
{
    // 개발 환경 설정
    public static string strOracle_IP = "10.2.30.7";
    public static string strOracle_Port = "1522";
    public static string strOracle_SID = "CDBHNSMES";
    
    // 개발자별 로컬 설정 (필요시)
    #if DEBUG
    public static string strOracle_User = "MESUSER_DEV";
    public static string strWCF_Address = "net.tcp://localhost:8101/WCF_SERVICE";
    #else
    public static string strOracle_User = "MESUSER";
    public static string strWCF_Address = "net.tcp://10.2.30.7:8101/WCF_SERVICE";
    #endif
}
```

#### app.config

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings>
    <!-- 개발 환경 -->
    <add key="Environment" value="Development"/>
    <add key="DebugMode" value="true"/>
    <add key="LogLevel" value="Debug"/>
  </appSettings>
  
  <system.serviceModel>
    <bindings>
      <netTcpBinding>
        <binding name="wcfBinding" 
                 maxReceivedMessageSize="2147483647"
                 receiveTimeout="00:10:00">
          <security mode="None"/>
        </binding>
      </netTcpBinding>
    </bindings>
  </system.serviceModel>
</configuration>
```

### 3. 참조 설정 확인

```powershell
# PowerShell에서 누락된 참조 확인
dir "HAENGSUNG_HNSMES_UI\DLL\DevExpress\*.dll"
dir "HAENGSUNG_HNSMES_UI\DLL\IDAT\*.dll"
```

## 첫 실행

### 1. 솔루션 빌드

```bash
# Visual Studio에서
Ctrl+Shift+B

# 또는 MSBuild
msbuild HAENGSUNG_HNSMES_UI_DBESS.sln /p:Configuration=Debug /p:Platform="x86"
```

### 2. 연결 테스트

```csharp
// 테스트 코드 (Program.cs에 임시 추가)
static void Main()
{
    // 연결 테스트
    var db = new WCFDatabaseProcess();
    var result = db.Execute_Proc("PKGCOM_TEST.SELECT_TEST", null);
    
    if (result.pResultInt == 0)
    {
        MessageBox.Show("DB 연결 성공!");
    }
    
    Application.Run(new MainForm());
}
```

### 3. 로그인 테스트

- 사용자 ID: 개발자 계정
- 비밀번호: (DB에 등록된 비밀번호)
- 접속 성공 시 메인 화면 표시

## 문제 해결

### Oracle 연결 오류

| 오류 | 원인 | 해결책 |
|------|------|--------|
| ORA-12154 | TNS 이름 미발견 | tnsnames.ora 경로 확인 |
| ORA-12541 | 리스너 없음 | DB 서버 연결 확인 |
| ORA-01017 | 인증 실패 | 사용자/비밀번호 확인 |
| ORA-28000 | 계정 잠김 | DBA에 계정 잠금 해제 요청 |

### DevExpress 오류

| 오류 | 원인 | 해결책 |
|------|------|--------|
| 라이선스 오류 | 라이선스 없음 | licenses.licx 확인 |
| DLL 누락 | 참조 문제 | DLL 폴더 확인 및 복사 |
| 버전 불일치 | DevExpress 버전 | 13.2.x 버전 통일 |

### 빌드 오류

```powershell
# 빌드 캐시 정리
rmdir /s /q HAENGSUNG_HNSMES_UI\bin
rmdir /s /q HAENGSUNG_HNSMES_UI\obj

# NuGet 패키지 복원
nuget restore HAENGSUNG_HNSMES_UI_DBESS.sln
```

## 유용한 도구

### 필수 도구

| 도구 | 용도 | 다운로드 |
|------|------|----------|
| **Visual Studio** | IDE | [visualstudio.com](https://visualstudio.microsoft.com/) |
| **Oracle Client** | DB 연결 | [oracle.com](https://www.oracle.com/database/technologies/) |
| **SQL Developer** | DB 관리 | [oracle.com/sqldeveloper](https://www.oracle.com/tools/downloads/sqldev-downloads.html) |

### 권장 도구

| 도구 | 용도 | 다운로드 |
|------|------|----------|
| **Git Extensions** | Git GUI | [gitextensions.github.io](https://gitextensions.github.io/) |
| **Beyond Compare** | 파일 비교 | [scootersoftware.com](https://www.scootersoftware.com/) |
| **LinqPad** | 쿼리 테스트 | [linqpad.net](https://www.linqpad.net/) |
| **Postman** | API 테스트 | [postman.com](https://www.postman.com/) |
| **Process Monitor** | 디버깅 | [docs.microsoft.com](https://docs.microsoft.com/sysinternals/) |

---

## 다음 단계

환경 설정이 완료되었습니다! 다음 문서를 참고하세요:

- [→ 프로젝트 구조](../guide/project-structure.md)
- [→ 코딩 표준](../guide/coding-standards.md)
- [→ 첫 화면 개발](../guide/ui-components.md)
