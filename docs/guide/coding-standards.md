# 코딩 표준 가이드

## 개요

본 문서는 HAENGSUNG HNSMES 프로젝트의 C# 코딩 표준을 정의합니다. 일관된 코드 스타일은 유지보수성과 가독성을 향상시킵니다.

---

## C# 명명 규칙

### 1. 클래스 및 인터페이스

| 유형 | 규칙 | 예시 |
|------|------|------|
| 클래스 | PascalCase | `DXGridHelper`, `WCFDatabaseProcess` |
| 인터페이스 | PascalCase + `I` 접두사 | `IDatabaseProcess`, `itfButton` |
| 구조체 | PascalCase | `ReturnDataStructure` |
| 열거형 | PascalCase | `WebServiceType`, `UPDATEITEMTYPE` |

```csharp
// ✅ 올바른 예
public class DatabaseServiceClientHelper { }
public interface IDatabaseProcess { }
public enum WebServiceType { HTTPWebService, WCFService }

// ❌ 잘못된 예
public class databaseServiceClientHelper { }  // camelCase 사용
public interface databaseProcess { }           // I 접두사 없음
```

### 2. 메서드 및 프로퍼티

| 유형 | 규칙 | 예시 |
|------|------|------|
| 메서드 | PascalCase | `ExecuteProc()`, `GetDataBase()` |
| 프로퍼티 | PascalCase | `UserID`, `ServiceUri` |
| 이벤트 | PascalCase | `ButtonClick`, `DataChanged` |

```csharp
// ✅ 올바른 예
public void ExecuteProc(string procName) { }
public string UserID { get; set; }
public event EventHandler DataChanged;

// ❌ 잘못된 예
public void executeProc(string procName) { }   // camelCase
public string userID { get; set; }             // 소문자 시작
```

### 3. 변수 및 상수

| 범위 | 규칙 | 접두사 | 예시 |
|------|------|--------|------|
| 전역 변수 | PascalCase | `g_` | `g_strIPADDRESS` |
| 파라미터 | camelCase | `p_` | `p_strProc`, `p_iProcSeq` |
| 지역 변수 | camelCase | `_` | `_result`, `_dicPara` |
| 멤버 변수 | camelCase | `m` | `mIP`, `mPort` |
| 상수 | UPPER_SNAKE_CASE | - | `SUPERADMIN`, `P_VERSION` |

```csharp
// ✅ 올바른 예
public class Example
{
    private string mConnectionString;           // 멤버 변수
    
    public void ProcessData(string p_input)     // 파라미터
    {
        string _localVar = p_input;             // 지역 변수
        const int MAX_COUNT = 100;              // 상수
    }
}

// ❌ 잘못된 예
public void ProcessData(string input) { }       // 접두사 없음
private string ConnectionString;                // m 접두사 없음
```

---

## 코드 포맷팅 규칙

### 1. 중괄호 배치

```csharp
// ✅ K&R 스타일 (권장)
public void MethodName()
{
    if (condition)
    {
        // 코드
    }
}

// ❌ Allman 스타일 (프로젝트에서 사용하지 않음)
public void MethodName()
{
    if (condition)
    {
        // 코드
    }
}
```

### 2. 들여쓰기 및 공백

```csharp
// ✅ 올바른 예
public void Example()
{
    int a = 10;
    int b = 20;
    
    if (a > b)
    {
        Console.WriteLine("a가 더 큼");
    }
    else
    {
        Console.WriteLine("b가 더 크거나 같음");
    }
    
    // 메서드 호출
    BASE_db.Execute_Proc(
        "PKG_TEST.GET_DATA",
        1,
        new string[] { "PARAM1", "PARAM2" },
        new object[] { value1, value2 }
    );
}

// ❌ 잘못된 예
public void Example(){
int a=10;
if(a>b){
Console.WriteLine("a가 더 큼");}
```

### 3. 줄 길이 제한

```csharp
// ✅ 한 줄당 최대 120자 권장
// 줄바꿈 예시
BASE_db.Execute_Proc(
    "PKG_MATERIAL.SET_IQC_JUDGE",
    1,
    new string[] { "A_CLIENT", "A_COMPANY", "A_PLANT" },
    new object[] { Global_Variable.CLIENT, Global_Variable.COMPANY, Global_Variable.PLANT }
);

// ❌ 너무 긴 줄
BASE_db.Execute_Proc("PKG_MATERIAL.SET_IQC_JUDGE", 1, new string[] { "A_CLIENT", "A_COMPANY", "A_PLANT", "A_LOTNO" }, new object[] { Global_Variable.CLIENT, Global_Variable.COMPANY, Global_Variable.PLANT, txtLotNo.EditValue });
```

---

## 주석 표준

### 1. XML 문서화 주석

```csharp
/// <summary>
/// 데이터베이스 저장 프로시저를 실행합니다.
/// </summary>
/// <param name="p_strProc">저장 프로시저 이름</param>
/// <param name="p_iProcSeq">프로시저 오버로드 번호</param>
/// <param name="p_arName">파라미터 이름 배열</param>
/// <param name="p_arValue">파라미터 값 배열</param>
/// <returns>실행 결과 (WSResults)</returns>
public WSResults Execute_Proc(
    string p_strProc, 
    int p_iProcSeq, 
    string[] p_arName, 
    object[] p_arValue)
{
    // 구현
}
```

### 2. 인라인 주석

```csharp
// ✅ 올바른 예
// 유효성 검사 수행
if (!ValidateInput())
{
    return;
}

// 그리드에 데이터 바인딩
BASE_DXGridHelper.Bind_Grid(
    gcList,
    "PKG_TEST.GET_DATA",
    1,
    new string[] { },
    new object[] { }
);

// ❌ 잘못된 예
// i 값을 1 증가시킴 (불필요한 주석)
i++;
```

### 3. TODO/FIXME 주석

```csharp
// TODO: 트랜잭션 처리 로직 추가 필요
// FIXME: NullReferenceException 발생 가능성 확인
// HACK: 임시 해결책, 추후 리팩토링 필요
```

---

## 예외 처리 패턴

### 1. 기본 예외 처리

```csharp
// ✅ 올바른 예
try
{
    BASE_db.Execute_Proc(procName, seq, paramNames, paramValues);
}
catch (Exception ex)
{
    // 로그 기록
    LogHelper.SaveLog($"오류 발생: {ex.Message}", ex.StackTrace);
    
    // 사용자에게 알림
    MessageBox.Show($"작업 중 오류가 발생했습니다: {ex.Message}", "오류", 
        MessageBoxButtons.OK, MessageBoxIcon.Error);
}

// ❌ 잘못된 예 - 빈 catch 블록
try
{
    BASE_db.Execute_Proc(procName, seq, paramNames, paramValues);
}
catch { }  // 오류가 무시됨!

// ❌ 잘못된 예 - 일반 Exception만 포창
try
{
    // 코드
}
catch (Exception)  // 구체적인 예외 타입 지정 필요
{
    // 처리
}
```

### 2. 구체적인 예외 처리

```csharp
// ✅ 올바른 예
try
{
    File.ReadAllText(filePath);
}
catch (FileNotFoundException ex)
{
    LogHelper.SaveLog("파일을 찾을 수 없습니다.", ex.Message);
}
catch (UnauthorizedAccessException ex)
{
    LogHelper.SaveLog("파일 접근 권한이 없습니다.", ex.Message);
}
catch (IOException ex)
{
    LogHelper.SaveLog("IO 오류 발생.", ex.Message);
}
catch (Exception ex)
{
    LogHelper.SaveLog("예상치 못한 오류 발생.", ex.Message);
    throw;  // 상위로 전파
}
```

### 3. using 문 사용

```csharp
// ✅ 올바른 예 - using 문 사용
public void WriteLog(string message)
{
    string filePath = Path.Combine(PATH_FileLog, $"log_{DateTime.Now:yyyyMMdd}.txt");
    
    using (StreamWriter sw = new StreamWriter(filePath, true, Encoding.UTF8))
    {
        sw.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}");
    }  // 자동으로 Dispose 호출
}

// ❌ 잘못된 예 - using 문 미사용
public void WriteLog(string message)
{
    StreamWriter sw = new StreamWriter(filePath, true, Encoding.UTF8);
    sw.WriteLine(message);
    sw.Close();  // 예외 발생 시 Close가 호출되지 않을 수 있음
}
```

---

## 데이터베이스 접근 패턴

### 1. 저장 프로시저 호출

```csharp
// ✅ 올바른 예 - 명명된 파라미터 사용
public void SaveData(string lotNo, string itemCode, int qty)
{
    string[] paramNames = new string[]
    {
        "A_CLIENT",
        "A_COMPANY", 
        "A_PLANT",
        "A_LOTNO",
        "A_ITEMCODE",
        "A_QTY"
    };
    
    object[] paramValues = new object[]
    {
        Global_Variable.CLIENT,
        Global_Variable.COMPANY,
        Global_Variable.PLANT,
        lotNo,
        itemCode,
        qty
    };
    
    WSResults result = BASE_db.Execute_Proc(
        "PKG_MATERIAL.SET_STOCK_IN",
        1,
        paramNames,
        paramValues
    );
    
    if (result.ResultInt != 0)
    {
        throw new ApplicationException($"저장 실패: {result.ResultString}");
    }
}

// ❌ 잘못된 예 - 인덱스 기반 접근
public void SaveData(string lotNo, string itemCode, int qty)
{
    // 파라미터 순서가 변경되면 오류 발생!
    WSResults result = BASE_db.Execute_Proc(
        "PKG_MATERIAL.SET_STOCK_IN",
        1,
        new string[] { "A_CLIENT", "A_COMPANY", "A_PLANT", "A_LOTNO", "A_ITEMCODE", "A_QTY" },
        new object[] { Global_Variable.CLIENT, Global_Variable.COMPANY, Global_Variable.PLANT, lotNo, itemCode, qty }
    );
}
```

### 2. 결과 처리

```csharp
// ✅ 올바른 예 - null 체크 및 결과 검증
public DataTable GetMaterialList()
{
    WSResults result = BASE_db.Execute_Proc(
        "PKG_MATERIAL.GET_LIST",
        1,
        new string[] { "A_CLIENT", "A_COMPANY" },
        new object[] { Global_Variable.CLIENT, Global_Variable.COMPANY }
    );
    
    if (result.ResultInt != 0)
    {
        LogHelper.SaveLog("조회 오류", result.ResultString);
        return null;
    }
    
    if (result.ResultDataSet == null || result.ResultDataSet.Tables.Count == 0)
    {
        return new DataTable();  // 빈 테이블 반환
    }
    
    return result.ResultDataSet.Tables[0];
}

// ❌ 잘못된 예 - null 체크 없음
public DataTable GetMaterialList()
{
    WSResults result = BASE_db.Execute_Proc(...);
    return result.ResultDataSet.Tables[0];  // NullReferenceException 가능
}
```

---

## UI 개발 패턴

### 1. 폼 상속

```csharp
// ✅ 올바른 예 - Base.Form 상속 및 itfButton 구현
public partial class PRDA201 : Forms.BASE.Form, itfButton
{
    public PRDA201()
    {
        InitializeComponent();
    }
    
    // itfButton 인터페이스 구현
    public void InitButton_Click() { }
    public void NewButton_Click() { }
    public void EditButton_Click() { }
    public void SaveButton_Click() { }
    public void DeleteButton_Click() { }
    public void SearchButton_Click() { }
    public void PrintButton_Click() { }
    public void RefreshButton_Click() { }
    public void StopButton_Click() { }
}

// ❌ 잘못된 예 - Form 직접 상속
public partial class PRDA201 : Form  // Base.Form을 상속하지 않음!
{
}
```

### 2. 유효성 검사

```csharp
// ✅ 올바른 예 - DXErrorProvider 사용
public void SaveButton_Click()
{
    // 기존 오류 초기화
    baseDxErrorProvider.ClearErrors();
    
    // 유효성 검사
    if (string.IsNullOrEmpty(txtLotNo.Text))
    {
        baseDxErrorProvider.SetError(txtLotNo, "LOT 번호는 필수입니다.");
    }
    
    if (dtWorkDate.EditValue == null)
    {
        baseDxErrorProvider.SetError(dtWorkDate, "작업일자는 필수입니다.");
    }
    
    // 검사 결과 확인
    if (baseDxErrorProvider.HasErrors)
    {
        return;
    }
    
    // 저장 로직
}
```

---

## 리소스 관리

### 1. COM 객체 해제

```csharp
// ✅ 올바른 예 - COM 객체 명시적 해제
public void ProcessExcel(string filePath)
{
    Excel.Application app = null;
    Excel.Workbook workbook = null;
    Excel.Worksheet worksheet = null;
    
    try
    {
        app = new Excel.Application();
        workbook = app.Workbooks.Open(filePath);
        worksheet = workbook.Sheets[1];
        
        // 작업 수행
    }
    finally
    {
        // COM 객체 해제
        if (worksheet != null)
        {
            Marshal.ReleaseComObject(worksheet);
            worksheet = null;
        }
        if (workbook != null)
        {
            Marshal.ReleaseComObject(workbook);
            workbook = null;
        }
        if (app != null)
        {
            Marshal.ReleaseComObject(app);
            app = null;
        }
    }
}
```

### 2. IDisposable 구현

```csharp
// ✅ 올바른 예 - IDisposable 패턴
public class CustomResource : IDisposable
{
    private bool _disposed = false;
    private StreamWriter _writer;
    
    public CustomResource(string filePath)
    {
        _writer = new StreamWriter(filePath);
    }
    
    public void Write(string message)
    {
        if (_disposed)
            throw new ObjectDisposedException(nameof(CustomResource));
            
        _writer.WriteLine(message);
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _writer?.Dispose();
            }
            _disposed = true;
        }
    }
}
```

---

## 안티패턴 및 주의사항

### ❌ 금지 패턴

```csharp
// 1. 매직 넘버 사용
// ❌ 잘못된 예
if (status == 1) { }

// ✅ 올바른 예
const int STATUS_ACTIVE = 1;
if (status == STATUS_ACTIVE) { }

// 2. 문자열 연결 반복
// ❌ 잘못된 예
string result = "";
foreach (var item in items)
{
    result += item.Name;  // 성능 저하
}

// ✅ 올바른 예
StringBuilder sb = new StringBuilder();
foreach (var item in items)
{
    sb.Append(item.Name);
}
string result = sb.ToString();

// 3. 하드코딩된 경로
// ❌ 잘못된 예
string path = "C:\\Logs\\log.txt";

// ✅ 올바른 예
string path = Path.Combine(Application.StartupPath, "Logs", "log.txt");

// 4. 예외 정보 노출
// ❌ 잘못된 예
catch (Exception ex)
{
    MessageBox.Show(ex.ToString());  // 민감한 정보 노출
}

// ✅ 올바른 예
catch (Exception ex)
{
    LogHelper.SaveLog(ex.ToString());  // 내부 로그에 기록
    MessageBox.Show("작업 중 오류가 발생했습니다.");  // 사용자에게는 일반 메시지
}
```

---

## 정적 분석 도구

프로젝트에서 다음 정적 분석 규칙을 준수하세요:

| 규칙 ID | 설명 | 심각도 |
|---------|------|--------|
| CA1806 | 메서드 반환값 무시 금지 | Warning |
| CA2000 | IDisposable 객체 Dispose 필요 | Warning |
| CA2202 | 객체를 여러 번 Dispose 금지 | Warning |
| CA1031 | 일반 Exception 포창 금지 | Warning |
| CA1822 | 정적 멤버로 변경 가능 여부 검사 | Suggestion |
