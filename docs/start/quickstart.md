# 빠른 시작 가이드

이 가이드는 HNSMES UI 개발 환경을 설정하고 첫 번째 화면을 실행하는 방법을 설명합니다.

## 전제 조건

시작하기 전에 다음 소프트웨어가 설치되어 있는지 확인하세요:

<div class="grid cards" markdown>

-   :material-check-circle:{ .lg .middle .green } __필수__

    ---

    - Windows 7 SP1 이상
    - .NET Framework 4.0
    - Visual Studio 2012 이상
    - Oracle Client 11g

-   :material-alert-circle:{ .lg .middle .orange } __권장__

    ---

    - Windows 10/11
    - Visual Studio 2019/2022
    - DevExpress 13.2.5+
    - SQL Developer

</div>

## 1단계: 소스 코드 가져오기

### Git 저장소 클론

```bash
# 저장소 클론
git clone https://github.com/haengsung/hnsmes-ui.git

# 또는 압축 파일 다운로드 후 추출
```

### 프로젝트 구조 확인

```
HNSMES/
├── HAENGSUNG_HNSMES_UI/          # 메인 프로젝트
│   ├── bin/                       # 빌드 출력
│   ├── obj/                       # 임시 파일
│   ├── Base/                      # 베이스 클래스
│   ├── Popup/                     # 팝업 화면
│   ├── SYSTEM/                    # 시스템 관리
│   ├── BASE/                      # 기준정보
│   ├── PLAN/                      # 생산계획
│   ├── PROD/                      # 생산실적
│   ├── MAT/                       # 자재관리
│   ├── QCM/                       # 품질관리
│   ├── EQM/                       # 설비관리
│   ├── MST/                       # 모니터링
│   └── Global/                    # 전역 설정
│
├── DLL/                           # 외부 라이브러리
│   ├── DevExpress/                # DevExpress DLL
│   ├── IDAT/                      # IDAT 라이브러리
│   └── Newtonsoft.Json.dll        # JSON 처리
│
└── docs/                          # 개발 문서
```

## 2단계: 개발 환경 설정

### 2.1 Visual Studio 설정

#### 프로젝트 열기

1. Visual Studio 실행
2. `HAENGSUNG_HNSMES_UI_DBESS.sln` 파일 열기
3. 솔루션 탐색기에서 프로젝트 확인

#### 참조 설정 확인

```powershell
# 누락된 참조 확인
# 솔루션 탐색기 > 참조에서 노란색 경고 아이콘 확인
```

!!! warning "DevExpress 참조 문제"
    DevExpress DLL이 누락된 경우:
    1. `DLL/DevExpress/` 폴더 확인
    2. DevExpress 13.2 설치 필요
    3. 또는 기존 DLL 파일 복사

### 2.2 데이터베이스 연결 설정

#### Global_Variable.cs 설정

```csharp
public static class Global_Variable
{
    // 데이터베이스 서버 설정
    public static string strOracle_IP = "10.2.30.7";
    public static string strOracle_Port = "1522";
    public static string strOracle_SID = "CDBHNSMES";
    public static string strOracle_User = "MESUSER";
    public static string strOracle_Pass = "mesuser";  // 암호화 권장
    
    // WCF 서비스 설정
    public static string strWCF_Address = "net.tcp://10.2.30.7:8101/WCF_SERVICE";
    
    // WebService 설정 (레거시)
    public static string strWS_URL = "http://10.2.30.7:8807/WebService.asmx";
}
```

!!! danger "보안 주의"
    위 예시의 비밀번호는 설명 목적입니다. 운영 환경에서는 반드시 환경변수 또는 암호화된 설정 파일을 사용하세요.

#### 연결 테스트

```csharp
// Program.cs 또는 테스트 화면에서
private void TestConnection()
{
    try
    {
        WCFDatabaseProcess wcf = new WCFDatabaseProcess();
        WSResults result = wcf.Execute_Proc("PKGCOM_TEST.SELECT_TEST", null);
        
        if (result.pResultInt == 0)
        {
            MessageBox.Show("연결 성공!");
        }
        else
        {
            MessageBox.Show("연결 실패: " + result.pResultMsg);
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("오류: " + ex.Message);
    }
}
```

## 3단계: 빌드 및 실행

### 3.1 솔루션 빌드

```bash
# Visual Studio에서
# Build > Build Solution (Ctrl+Shift+B)

# 또는 MSBuild 사용
msbuild HAENGSUNG_HNSMES_UI_DBESS.sln /p:Configuration=Debug
```

### 3.2 애플리케이션 실행

#### 시작 프로젝트 설정

1. 솔루션 탐색기에서 `HAENGSUNG_HNSMES_UI` 선택
2. 우클릭 > `시작 프로젝트로 설정`

#### 실행

```bash
# Visual Studio에서 F5 또는 Ctrl+F5

# 또는 직접 실행
.\HAENGSUNG_HNSMES_UI\bin\Debug\HAENGSUNG_HNSMES_UI.exe
```

## 4단계: 첫 화면 개발

### 4.1 새 화면 추가

#### 1. 폼 클래스 생성

```csharp
using System;
using System.Windows.Forms;
using Global;

namespace HAENGSUNG_HNSMES_UI.PROD
{
    public partial class PRODT001 : Base.Form
    {
        public PRODT001()
        {
            InitializeComponent();
        }
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            // 화면 초기화
            this.Text = "생산실적등록";
            
            // 권한 체크
            if (!CheckAuth("PRODT001", "READ"))
            {
                MessageBox.Show("접근 권한이 없습니다.");
                this.Close();
                return;
            }
            
            // 데이터 로드
            LoadData();
        }
        
        private void LoadData()
        {
            // DB 조회 로직
            Dictionary<string, object> param = new Dictionary<string, object>
            {
                { "A_CLIENT", Global_Variable.CLIENT },
                { "A_COMPANY", Global_Variable.COMPANY },
                { "A_WORK_DATE", DateTime.Today.ToString("yyyyMMdd") }
            };
            
            WSResults result = m_db.Execute_Proc("PKGPRD_PROD.SELECT_PROD_LIST", param);
            
            if (result.pResultInt == 0)
            {
                gridControl1.DataSource = result.pResultData.Tables[0];
            }
        }
    }
}
```

#### 2. 디자이너 파일

```csharp
namespace HAENGSUNG_HNSMES_UI.PROD
{
    partial class PRODT001
    {
        private System.ComponentModel.IContainer components = null;
        
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        
        private void InitializeComponent()
        {
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            
            // ... 디자인 코드
        }
    }
}
```

### 4.2 메뉴 등록

#### 메뉴 테이블에 등록

```sql
INSERT INTO TM_MENU (
    CLIENT, COMPANY, MENU_ID, MENU_NAME, 
    MENU_TYPE, PROGRAM_ID, PARENT_MENU_ID, 
    SORT_ORDER, USE_YN
) VALUES (
    'HNS', '001', 'PRODT001', '생산실적등록',
    'P', 'PROD.PRODT001', 'PROD',
    10, 'Y'
);
```

## 5단계: 디버깅

### 5.1 디버깅 설정

#### Visual Studio 디버그 설정

1. `프로젝트 > 속성 > 디버그` 탭
2. 시작 작업: `시작 프로젝트`
3. 명령줄 인수: (필요시 설정)

### 5.2 주요 디버깅 포인트

| 위치 | 설명 |
|------|------|
| `Base.Form.OnLoad()` | 화면 로드 시점 |
| `IDatabaseProcess.Execute_Proc()` | DB 호출 시점 |
| `WebServiceProcess.ExecuteProcCls()` | WCF/WebService 호출 시점 |
| `itfButton.OnFInd()` | 조회 버튼 클릭 시 |
| `itfButton.OnSave()` | 저장 버튼 클릭 시 |

### 5.3 로그 확인

```csharp
// 로그 기록
System.Diagnostics.Debug.WriteLine("Debug message");
System.Diagnostics.Trace.WriteLine("Trace message");

// 파일 로그
File.AppendAllText("log.txt", $"[{DateTime.Now}] {message}\n");
```

## 6단계: 테스트

### 6.1 단위 테스트

#### NUnit 또는 MSTest 사용 (권장)

```bash
# 테스트 프로젝트 추가
# 프로젝트 > 추가 > 새 프로젝트 > 단위 테스트 프로젝트
```

### 6.2 통합 테스트

```csharp
[TestMethod]
public void TestDatabaseConnection()
{
    // Arrange
    var db = new WCFDatabaseProcess();
    var param = new Dictionary<string, object>();
    
    // Act
    var result = db.Execute_Proc("PKGCOM_TEST.SELECT_TEST", param);
    
    // Assert
    Assert.AreEqual(0, result.pResultInt);
    Assert.IsNotNull(result.pResultData);
}
```

## 일반적인 문제 해결

### 문제 1: "DevExpress DLL을 찾을 수 없습니다"

**해결책:**

```powershell
# 1. DLL 폴더 확인
ls DLL/DevExpress/

# 2. 참조 경로 확인
# 솔루션 탐색기 > 참조 > 속성 > 경로

# 3. DevExpress 재설치 또는 파일 복사
```

### 문제 2: "Oracle 연결 실패"

**해결책:**

1. Oracle Client 설치 확인
2. tnsnames.ora 설정 확인
3. 방화벽 설정 확인
4. Global_Variable.cs 연결 정보 확인

### 문제 3: "권한 없음" 오류

**해결책:**

```sql
-- 사용자 권한 확인
SELECT * FROM TM_USER_MENU 
WHERE USER_ID = 'your_user_id' 
AND MENU_ID = 'your_menu_id';

-- 권한 부여
INSERT INTO TM_USER_MENU (USER_ID, MENU_ID, READ_YN, SAVE_YN, DELETE_YN)
VALUES ('your_user_id', 'your_menu_id', 'Y', 'Y', 'Y');
```

---

## 다음 단계

- [→ 아키텍처 가이드](architecture.md)에서 시스템 구조를 자세히 알아보세요.
- [→ 개발 가이드](../guide/project-structure.md)에서 코딩 표준을 확인하세요.
- [→ 데이터베이스](../database/overview.md)에서 테이블/프로시저를 확인하세요.
