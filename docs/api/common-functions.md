# 공통 함수

> HAENGSUNG HNSMES UI에서 사용하는 전역 유틸리티 함수 및 클래스

---

## Global_Variable 클래스

애플리케이션 전역에서 사용되는 상수, 설정값, 사용자 정보를 관리하는 클래스입니다.

```csharp
namespace HAENGSUNG_HNSMES_UI.Global
{
    partial class Global_Variable
    {
        // 전역 변수 및 상수 정의
    }
}
```

---

## 시스템 경로 설정

| 변수명 | 경로 | 설명 |
|--------|------|------|
| `PATH_FileLog` | `{AppPath}\LOG` | 로그 파일 저장 경로 |
| `strDataLocalDB_Path` | `{AppPath}\Xml_Files\LocalDB.xml` | 로컬 DB 설정 파일 |
| `PATH_DataLanguage` | `{AppPath}\Xml_Files\IDAT_Language.xml` | 다국어 리소스 파일 |

```csharp
// 경로 사용 예제
string logPath = Global_Variable.PATH_FileLog;
string logFile = Path.Combine(logPath, $"LOG_{DateTime.Now:yyyyMMdd}.txt");
```

---

## 로그인 정보

### 사용자 관련 변수

| 변수명 | 타입 | 설명 |
|--------|------|------|
| `USER_ID` | `string` | 사용자 ID |
| `USERNAMELOCAL` | `string` | 사용자 성명 |
| `USERROLE` | `string` | 사용자 등급 |
| `USERCLASSNAME` | `string` | 사용자 등급명 |
| `DEPTCODE` | `string` | 부서 코드 |
| `EHRCODE` | `string` | 인사 코드 |
| `POSITION` | `string` | 직위 |

```csharp
// 현재 로그인 사용자 정보 확인
string currentUser = Global_Variable.USER_ID;
string userName = Global_Variable.USERNAMELOCAL;
string userRole = Global_Variable.USERROLE;

// 권한 체크
if (Global_Variable.USERROLE == Global_Variable.SUPERADMIN)
{
    // 관리자 기능 활성화
}
```

---

## 시스템 코드 및 설정

### 시스템 상수

| 변수명 | 값 | 설명 |
|--------|-----|------|
| `SYSTEMCODE` | `"HSMES"` | 시스템 코드 |
| `P_VERSION` | `"1.0.0.1"` | 프로그램 버전 |
| `CLIENT` | `"1060"` | 클라이언트 코드 |
| `COMPANY` | `"40"` | 회사 코드 |
| `PLANT` | `"P200"` | 공장 코드 |

### 권한 등급 상수

```csharp
public static readonly string SUPERADMIN = "MANAGER";  // 최고 관리자
public static readonly string ADMIN = "ADMIN";         // 관리자
public static readonly string GUEST = "GUEST";         // 게스트
```

### 권한 체크 예제

```csharp
/// <summary>
/// 버튼 권한 설정
/// </summary>
public void SetButtonAuthority()
{
    switch (Global_Variable.USERROLE)
    {
        case "MANAGER":
            btnDelete.Enabled = true;
            btnSave.Enabled = true;
            btnAdmin.Visible = true;
            break;
        case "ADMIN":
            btnDelete.Enabled = true;
            btnSave.Enabled = true;
            btnAdmin.Visible = false;
            break;
        case "GUEST":
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnAdmin.Visible = false;
            break;
        default:
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            break;
    }
}
```

---

## 네트워크 정보

### IP 주소 가져오기

```csharp
private static string g_strIPADDRESS = "";

public static string IPADDRESS
{
    get
    {
        IPHostEntry senderIP = Dns.GetHostEntry(Dns.GetHostName());
        
        for (int i = 0; i < senderIP.AddressList.Length; i++)
        {
            if (senderIP.AddressList[i].AddressFamily == 
                System.Net.Sockets.AddressFamily.InterNetwork)
            {
                g_strIPADDRESS = senderIP.AddressList[i].ToString();
                break;
            }
        }
        
        return g_strIPADDRESS;
    }
}
```

**사용 예제:**

```csharp
// 현재 클라이언트 IP 주소
string clientIP = Global_Variable.IPADDRESS;
Console.WriteLine($"클라이언트 IP: {clientIP}");
```

---

## FTP 설정

| 변수명 | 값 | 설명 |
|--------|-----|------|
| `FTP_IP` | `"ftp://10.2.30.219"` | FTP 서버 주소 |
| `FTP_ID` | `"MESUSER"` | FTP 사용자 ID |
| `FTP_PW` | `"Admin!@#$%"` | FTP 비밀번호 |

```csharp
// FTP 업로드 예제
public bool UploadFileToFTP(string localFile, string remoteFile)
{
    try
    {
        string ftpUrl = $"{Global_Variable.FTP_IP}/{remoteFile}";
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUrl);
        
        request.Method = WebRequestMethods.Ftp.UploadFile;
        request.Credentials = new NetworkCredential(
            Global_Variable.FTP_ID, 
            Global_Variable.FTP_PW
        );
        
        byte[] fileContents = File.ReadAllBytes(localFile);
        request.ContentLength = fileContents.Length;
        
        using (Stream requestStream = request.GetRequestStream())
        {
            requestStream.Write(fileContents, 0, fileContents.Length);
        }
        
        return true;
    }
    catch (Exception ex)
    {
        LogHelper.WriteLog($"FTP 업로드 실패: {ex.Message}");
        return false;
    }
}
```

---

## GlobalFunction 클래스

### 엑셀 파일 읽기

```csharp
/// <summary>
/// 엑셀 파일을 DataTable로 변환
/// </summary>
/// <param name="sPath">엑셀 파일 경로</param>
/// <param name="sSheetName">시트명</param>
/// <returns>DataTable</returns>
public static DataTable ReadExcelFile(string sPath, string sSheetName)
```

**사용 예제:**

```csharp
// 엑셀 파일 읽기
DataTable excelData = GlobalFunction.ReadExcelFile(
    @"C:\Data\Production.xlsx", 
    "Sheet1"
);

if (excelData != null)
{
    foreach (DataRow row in excelData.Rows)
    {
        string itemCode = row["F1"].ToString();
        string qty = row["F2"].ToString();
        // 데이터 처리
    }
}
```

!!! note "엑셀 형식 지원"
    `.xls` (Excel 97-2003) 및 `.xlsx` (Excel 2007+) 형식을 모두 지원합니다.

---

## 날짜/시간 유틸리티

### 주차 계산

```csharp
/// <summary>
/// 날짜로부터 주차 정보 계산
/// </summary>
public static string GetWeekNumber(DateTime date)
{
    System.Globalization.CultureInfo ci = 
        System.Globalization.CultureInfo.CurrentCulture;
    int weekNum = ci.Calendar.GetWeekOfYear(
        date, 
        System.Globalization.CalendarWeekRule.FirstFourDayWeek, 
        DayOfWeek.Monday
    );
    return $"{date.Year}년 {weekNum}주";
}
```

### 공휴일 체크

```csharp
/// <summary>
/// 공휴일 여부 확인
/// </summary>
public static bool IsHoliday(DateTime date)
{
    // 주말 체크
    if (date.DayOfWeek == DayOfWeek.Saturday || 
        date.DayOfWeek == DayOfWeek.sunday)
    {
        return true;
    }
    
    // 공휴일 테이블 조회
    // ...
    
    return false;
}
```

### 근무일 계산

```csharp
/// <summary>
/// 두 날짜 사이의 근무일 수 계산
/// </summary>
public static int GetWorkingDays(DateTime startDate, DateTime endDate)
{
    int workingDays = 0;
    DateTime current = startDate;
    
    while (current <= endDate)
    {
        if (!IsHoliday(current))
        {
            workingDays++;
        }
        current = current.AddDays(1);
    }
    
    return workingDays;
}
```

---

## 문자열 유틸리티

### 문자열 포맷팅

```csharp
/// <summary>
/// 품번 코드 정규화
/// </summary>
public static string FormatItemCode(string rawCode)
{
    if (string.IsNullOrEmpty(rawCode))
        return string.Empty;
    
    // 공백 제거 및 대문자 변환
    return rawCode.Trim().ToUpper().Replace("-", "");
}

/// <summary>
/// 전화번호 포맷팅
/// </summary>
public static string FormatPhoneNumber(string phone)
{
    if (string.IsNullOrEmpty(phone) || phone.Length < 9)
        return phone;
    
    if (phone.Length == 10)
        return Regex.Replace(phone, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3");
    
    if (phone.Length == 11)
        return Regex.Replace(phone, @"(\d{3})(\d{4})(\d{4})", "$1-$2-$3");
    
    return phone;
}
```

### 널 체크 및 기본값

```csharp
/// <summary>
/// 객체를 문자열로 변환 (null 안전)
/// </summary>
public static string ToSafeString(object value, string defaultValue = "")
{
    if (value == null || value == DBNull.Value)
        return defaultValue;
    
    return value.ToString().Trim();
}

/// <summary>
/// 정수로 변환 (null 안전)
/// </summary>
public static int ToSafeInt(object value, int defaultValue = 0)
{
    if (value == null || value == DBNull.Value)
        return defaultValue;
    
    int result;
    if (int.TryParse(value.ToString(), out result))
        return result;
    
    return defaultValue;
}

/// <summary>
/// 날짜로 변환 (null 안전)
/// </summary>
public static DateTime? ToSafeDateTime(object value)
{
    if (value == null || value == DBNull.Value)
        return null;
    
    DateTime result;
    if (DateTime.TryParse(value.ToString(), out result))
        return result;
    
    return null;
}
```

---

## 메시지 표시 함수

### 표준 메시지 박스

```csharp
/// <summary>
/// 정보 메시지 표시
/// </summary>
public static void ShowInfo(string message)
{
    XtraMessageBox.Show(
        message, 
        "정보", 
        MessageBoxButtons.OK, 
        MessageBoxIcon.Information
    );
}

/// <summary>
/// 경고 메시지 표시
/// </summary>
public static void ShowWarning(string message)
{
    XtraMessageBox.Show(
        message, 
        "경고", 
        MessageBoxButtons.OK, 
        MessageBoxIcon.Warning
    );
}

/// <summary>
/// 오류 메시지 표시
/// </summary>
public static void ShowError(string message)
{
    XtraMessageBox.Show(
        message, 
        "오류", 
        MessageBoxButtons.OK, 
        MessageBoxIcon.Error
    );
}

/// <summary>
/// 확인 메시지 표시
/// </summary>
public static bool ShowConfirm(string message)
{
    DialogResult result = XtraMessageBox.Show(
        message, 
        "확인", 
        MessageBoxButtons.YesNo, 
        MessageBoxIcon.Question
    );
    
    return result == DialogResult.Yes;
}
```

### 다국어 메시지

```csharp
/// <summary>
/// 다국어 메시지 표시
/// </summary>
public static void ShowMessage(string messageCode, params object[] args)
{
    string message = GetMessage(messageCode);
    string formattedMessage = string.Format(message, args);
    
    ShowInfo(formattedMessage);
}

/// <summary>
/// 메시지 코드로부터 텍스트 가져오기
/// </summary>
private static string GetMessage(string code)
{
    // Global_Variable.LANGUAGE 사용
    DataSet langDs = Global_Variable.LANGUAGE;
    // ... 메시지 조회 로직
    return code; // 기본값
}
```

---

## 로깅 유틸리티

### LogHelper 클래스

```csharp
/// <summary>
/// 로그 기록
/// </summary>
public static class LogHelper
{
    private static readonly object lockObj = new object();
    
    /// <summary>
    /// 정보 로그 기록
    /// </summary>
    public static void WriteLog(string message)
    {
        lock (lockObj)
        {
            string logPath = Global_Variable.PATH_FileLog;
            string logFile = Path.Combine(logPath, 
                $"LOG_{DateTime.Now:yyyyMMdd}.txt");
            
            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
            
            File.AppendAllText(logFile, logEntry + Environment.NewLine);
        }
    }
    
    /// <summary>
    /// 예외 로그 기록
    /// </summary>
    public static void WriteException(Exception ex, string context = "")
    {
        string message = $"[EXCEPTION] {context}\n" +
                        $"Message: {ex.Message}\n" +
                        $"StackTrace: {ex.StackTrace}";
        WriteLog(message);
    }
}
```

**사용 예제:**

```csharp
try
{
    // 작업 수행
    LogHelper.WriteLog("데이터 저장 시작");
    SaveData();
    LogHelper.WriteLog("데이터 저장 완료");
}
catch (Exception ex)
{
    LogHelper.WriteException(ex, "데이터 저장 중 오류");
    ShowError("저장 중 오류가 발생했습니다.");
}
```

---

## 데이터 검증 함수

### 입력값 검증

```csharp
/// <summary>
/// 필수 입력값 검증
/// </summary>
public static bool ValidateRequired(BaseEdit control, string fieldName)
{
    if (control.EditValue == null || 
        string.IsNullOrWhiteSpace(control.EditValue.ToString()))
    {
        ShowError($"{fieldName}은(는) 필수 입력 항목입니다.");
        control.Focus();
        return false;
    }
    return true;
}

/// <summary>
/// 날짜 범위 검증
/// </summary>
public static bool ValidateDateRange(
    DateEdit fromDate, 
    DateEdit toDate, 
    int maxDays = 31)
{
    if (fromDate.DateTime > toDate.DateTime)
    {
        ShowError("시작일은 종료일보다 클 수 없습니다.");
        fromDate.Focus();
        return false;
    }
    
    TimeSpan diff = toDate.DateTime - fromDate.DateTime;
    if (diff.Days > maxDays)
    {
        ShowError($"조회 기간은 {maxDays}일을 초과할 수 없습니다.");
        return false;
    }
    
    return true;
}

/// <summary>
/// 숫자 범위 검증
/// </summary>
public static bool ValidateNumberRange(
    SpinEdit control, 
    decimal min, 
    decimal max, 
    string fieldName)
{
    decimal value = control.Value;
    
    if (value < min || value > max)
    {
        ShowError($"{fieldName}은(는) {min}에서 {max} 사이의 값을 입력하세요.");
        control.Focus();
        return false;
    }
    
    return true;
}
```

---

## 파일 유틸리티

### 파일 작업

```csharp
/// <summary>
/// 디렉토리 생성 (없는 경우)
/// </summary>
public static void EnsureDirectory(string path)
{
    if (!Directory.Exists(path))
    {
        Directory.CreateDirectory(path);
    }
}

/// <summary>
/// 안전한 파일명 생성
/// </summary>
public static string GetSafeFileName(string fileName)
{
    foreach (char c in Path.GetInvalidFileNameChars())
    {
        fileName = fileName.Replace(c, '_');
    }
    return fileName;
}

/// <summary>
/// 백업 파일 생성
/// </summary>
public static string CreateBackup(string filePath)
{
    if (!File.Exists(filePath))
        return null;
    
    string backupPath = $"{filePath}.{DateTime.Now:yyyyMMddHHmmss}.bak";
    File.Copy(filePath, backupPath);
    return backupPath;
}
```

---

## 컬렉션 유틸리티

### DataTable 확장

```csharp
/// <summary>
/// DataTable을 CSV로 변환
/// </summary>
public static string ToCsv(this DataTable table)
{
    StringBuilder sb = new StringBuilder();
    
    // 헤더
    string[] columnNames = table.Columns
        .Cast<DataColumn>()
        .Select(x => x.ColumnName)
        .ToArray();
    sb.AppendLine(string.Join(",", columnNames));
    
    // 데이터
    foreach (DataRow row in table.Rows)
    {
        string[] fields = row.ItemArray
            .Select(field => $"\"{field.ToString().Replace("\"", "\"\"")}\"")
            .ToArray();
        sb.AppendLine(string.Join(",", fields));
    }
    
    return sb.ToString();
}

/// <summary>
/// DataTable 복제 (데이터 포함)
/// </summary>
public static DataTable CloneWithData(this DataTable source)
{
    DataTable clone = source.Clone();
    foreach (DataRow row in source.Rows)
    {
        clone.ImportRow(row);
    }
    return clone;
}
```

---

## 사용 예제 모음

### 완전한 예제: 데이터 저장 프로시저 호출

```csharp
public bool SaveProductionData(ProductionData data)
{
    // 1. 입력값 검증
    if (!ValidateRequired(txtItemCode, "품번")) return false;
    if (!ValidateRequired(txtQty, "수량")) return false;
    if (!ValidateDateRange(dtFromDate, dtToDate)) return false;
    
    // 2. 매개변수 설정
    var parameters = new Dictionary<string, object>
    {
        { "P_WORK_DATE", data.WorkDate.ToString("yyyy-MM-dd") },
        { "P_LINE_CODE", Global_Variable.gv_sLogInWorkLine },
        { "P_ITEM_CODE", FormatItemCode(data.ItemCode) },
        { "P_QTY", data.Quantity },
        { "P_USER_ID", Global_Variable.USER_ID },
        { "P_IP_ADDRESS", Global_Variable.IPADDRESS }
    };
    
    try
    {
        // 3. 저장 프로시저 실행
        LogHelper.WriteLog("생산 데이터 저장 시작");
        
        var wcfProcess = new WCFServiceProcess();
        WSResults result = wcfProcess.ExecuteProcCls(
            "USP_SAVE_PRODUCTION", 
            1, 
            parameters
        );
        
        // 4. 결과 처리
        if (result.ResultInt == 0)
        {
            ShowInfo("저장되었습니다.");
            LogHelper.WriteLog("생산 데이터 저장 완료");
            return true;
        }
        else
        {
            ShowError($"저장 실패: {result.ResultString}");
            LogHelper.WriteLog($"생산 데이터 저장 실패: {result.ResultString}");
            return false;
        }
    }
    catch (Exception ex)
    {
        LogHelper.WriteException(ex, "생산 데이터 저장 중 예외");
        ShowError("저장 중 오류가 발생했습니다.");
        return false;
    }
}
```

!!! tip "코딩 표준"
    - 모든 사용자 입력은 검증 후 사용하세요.
    - 중요한 작업은 로그를 남기세요.
    - 예외는 반드시 처리하고 사용자에게 적절한 메시지를 표시하세요.
