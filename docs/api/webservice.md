# 레거시 웹서비스

> **ASMX 기반 SOAP 웹서비스** - 레거시 지원용 (신규 개발 시 WCF 사용 권장)

---

## 서비스 엔드포인트

```http
http://10.2.30.7:8807/WebService.asmx
```

| 속성 | 값 |
|------|-----|
| **프로토콜** | HTTP |
| **IP 주소** | 10.2.30.7 |
| **포트** | 8807 |
| **서비스 경로** | /WebService.asmx |
| **네임스페이스** | `IDAT.WebService` |

---

## 웹 메서드

### ExecuteProcCls

저장 프로시저를 실행하고 결과를 반환합니다.

```csharp
[WebMethod]
public clsDataSetStruct ExecuteProcCls(
    string ProcName, 
    ArrayList aryName, 
    ArrayList aryValue
)
```

| 매개변수 | 타입 | 설명 |
|---------|------|------|
| `ProcName` | `string` | 실행할 저장 프로시저 이름 |
| `aryName` | `ArrayList` | 매개변수 이름 배열 |
| `aryValue` | `ArrayList` | 매개변수 값 배열 |

**반환값:** `clsDataSetStruct`

| 속성 | 타입 | 설명 |
|------|------|------|
| `pResultDs` | `DataSet` | 결과 데이터셋 |
| `pResultInt` | `int` | 결과 코드 |
| `pResultString` | `string` | 결과 메시지 |

---

### ExecuteQry

SQL 쿼리를 직접 실행합니다.

```csharp
[WebMethod]
public clsDataSetStruct ExecuteQry(string strQry)
```

---

### ExecuteFunc

데이터베이스 함수를 실행합니다.

```csharp
[WebMethod]
public string ExecuteFunc(
    string ProcName, 
    ArrayList aryName, 
    ArrayList aryValue
)
```

---

### ExecuteProcBatchDS

배치 DataSet을 처리합니다.

```csharp
[WebMethod]
public clsDataSetStruct ExecuteProcBatchDS(DataSet ds)
```

---

### Open_WebService

웹서비스 연결 상태를 확인합니다.

```csharp
[WebMethod]
public bool Open_WebService(string sAddress)
```

---

## SOAP 메시지 형식

### 요청 메시지 예제

```xml
<?xml version="1.0" encoding="utf-8"?>
<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
               xmlns:xsd="http://www.w3.org/2001/XMLSchema"
               xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <ExecuteProcCls xmlns="http://tempuri.org/">
      <ProcName>USP_GET_PRODUCTION_DATA</ProcName>
      <aryName>
        <string>P_FROM_DATE</string>
        <string>P_TO_DATE</string>
        <string>P_LINE_CODE</string>
      </aryName>
      <aryValue>
        <string>2024-01-01</string>
        <string>2024-01-31</string>
        <string>L001</string>
      </aryValue>
    </ExecuteProcCls>
  </soap:Body>
</soap:Envelope>
```

### 응답 메시지 예제

```xml
<?xml version="1.0" encoding="utf-8"?>
<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
               xmlns:xsd="http://www.w3.org/2001/XMLSchema"
               xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <ExecuteProcClsResponse xmlns="http://tempuri.org/">
      <ExecuteProcClsResult>
        <pResultInt>0</pResultInt>
        <pResultString>Success</pResultString>
        <pResultDs>
          <xs:schema xmlns="" xmlns:xs="http://www.w3.org/2001/XMLSchema">
            <!-- 스키마 정의 -->
          </xs:schema>
          <diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata"
                          xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
            <DocumentElement>
              <PRODUCTION_DATA diffgr:id="PRODUCTION_DATA1" msdata:rowOrder="0">
                <WORK_DATE>2024-01-15</WORK_DATE>
                <ITEM_CODE>ITEM001</ITEM_CODE>
                <QTY>100</QTY>
              </PRODUCTION_DATA>
            </DocumentElement>
          </diffgr:diffgram>
        </pResultDs>
      </ExecuteProcClsResult>
    </ExecuteProcClsResponse>
  </soap:Body>
</soap:Envelope>
```

---

## SOAP 호출 코드 예제

### C# 클라이언트 (웹 참조 사용)

```csharp
using IDAT.WebService;

// 웹서비스 프록시 클래스 생성
var webService = new clsWebService();

// 매개변수 준비
var aryName = new ArrayList { "P_USER_ID", "P_DEPT_CODE" };
var aryValue = new ArrayList { "ADMIN", "P200" };

try
{
    // 저장 프로시저 실행
    clsDataSetStruct result = webService.ExecuteProcCls(
        "USP_USER_QUERY", 
        aryName, 
        aryValue
    );
    
    if (result.pResultInt == 0)
    {
        DataSet ds = result.pResultDs;
        // 데이터 처리
    }
    else
    {
        Console.WriteLine($"오류: {result.pResultString}");
    }
}
catch (InvalidOperationException ex)
{
    // 웹서비스 연결 실패
    Console.WriteLine($"웹서비스 연결 실패: {ex.Message}");
}
```

### C# 클라이언트 (HttpClient 사용)

```csharp
using System.Net.Http;
using System.Xml;

public async Task<string> CallWebServiceAsync()
{
    var soapEnvelope = @"<?xml version=""1.0"" encoding=""utf-8""?>
    <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
        <soap:Body>
            <ExecuteProcCls xmlns=""http://tempuri.org/"">
                <ProcName>USP_GET_DATA</ProcName>
                <aryName><string>P_PARAM1</string></aryName>
                <aryValue><string>Value1</string></aryValue>
            </ExecuteProcCls>
        </soap:Body>
    </soap:Envelope>";

    using (var client = new HttpClient())
    {
        var content = new StringContent(
            soapEnvelope, 
            Encoding.UTF8, 
            "text/xml"
        );
        
        content.Headers.Add("SOAPAction", "http://tempuri.org/ExecuteProcCls");
        
        var response = await client.PostAsync(
            "http://10.2.30.7:8807/WebService.asmx", 
            content
        );
        
        return await response.Content.ReadAsStringAsync();
    }
}
```

### PowerShell 호출 예제

```powershell
$uri = "http://10.2.30.7:8807/WebService.asmx"

$soapBody = @"
<?xml version="1.0" encoding="utf-8"?>
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
    <soap:Body>
        <Open_WebService xmlns="http://tempuri.org/">
            <sAddress>http://10.2.30.7:8807/WebService.asmx</sAddress>
        </Open_WebService>
    </soap:Body>
</soap:Envelope>
"@

$headers = @{
    "Content-Type" = "text/xml; charset=utf-8"
    "SOAPAction" = "http://tempuri.org/Open_WebService"
}

try {
    $response = Invoke-WebRequest -Uri $uri -Method Post -Body $soapBody -Headers $headers
    Write-Host "연결 성공: $($response.StatusCode)"
}
catch {
    Write-Host "연결 실패: $($_.Exception.Message)"
}
```

---

## WebServiceProcess 클래스 사용법

### 기본 사용 패턴

```csharp
using HAENGSUNG_HNSMES_UI.WebService.Access;

// 웹서비스 프로세서 생성
var wsProcess = new WebServiceProcess();

// 연결 상태 확인
if (wsProcess.GetWsConnectStatus())
{
    // 매개변수 설정
    var parameters = new Dictionary<string, object>
    {
        { "P_WORK_DATE", DateTime.Now.ToString("yyyy-MM-dd") },
        { "P_LINE_CODE", "LINE001" }
    };
    
    // 저장 프로시저 실행
    WSResults result = wsProcess.ExecuteProcCls("USP_DAILY_REPORT", parameters);
    
    if (result.ResultInt == 0)
    {
        DataTable data = result.ResultDataSet.Tables[0];
        // 결과 처리
    }
}
```

### 파일 다운로드

```csharp
/// <summary>
/// 웹 서비스를 통해 파일을 다운로드
/// </summary>
public bool WsDownload(string filePath, string serverPath)
{
    try
    {
        HttpWebRequest hr = HttpWebRequest.Create(serverPath) as HttpWebRequest;
        FileStream fs = new FileStream(filePath, FileMode.Create);
        Stream s = hr.GetResponse().GetResponseStream();

        byte[] buffer = new byte[4096];
        int bytesRead = s.Read(buffer, 0, buffer.Length);

        while (bytesRead > 0)
        {
            fs.Write(buffer, 0, bytesRead);
            bytesRead = s.Read(buffer, 0, buffer.Length);
        }
        
        fs.Close();
        return true;
    }
    catch
    {
        throw;
    }
}
```

---

## WCF 마이그레이션 가이드

### 주요 차이점 비교

| 기능 | 레거시 WebService | WCF 서비스 |
|------|------------------|------------|
| **프로토콜** | HTTP (SOAP) | NetTCP (바이너리) |
| **성능** | 느림 (텍스트 기반) | 빠름 (바이너리) |
| **보안** | 기본 | Transport/메시지 수준 |
| **압축** | 미지원 | GZip 지원 |
| **타임아웃** | 제한적 | 상세 설정 가능 |
| **매개변수** | ArrayList | Dictionary<string, object> |

### 마이그레이션 단계

#### 1단계: 클라이언트 코드 변경

```csharp
// 변경 전: 레거시 WebService
var wsProcess = new WebServiceProcess();
var aryName = new ArrayList { "P_PARAM1", "P_PARAM2" };
var aryValue = new ArrayList { "Value1", "Value2" };
clsDataSetStruct result = webService.ExecuteProcCls("USP_TEST", aryName, aryValue);
```

```csharp
// 변경 후: WCF
var wcfProcess = new WCFServiceProcess();
var parameters = new Dictionary<string, object>
{
    { "P_PARAM1", "Value1" },
    { "P_PARAM2", "Value2" }
};
WSResults result = wcfProcess.ExecuteProcCls("USP_TEST", 1, parameters);
```

#### 2단계: 결과 처리 코드 변경

```csharp
// 변경 전
if (result.pResultInt == 0)
{
    DataSet ds = result.pResultDs;
}
```

```csharp
// 변경 후
if (result.ResultInt == 0)
{
    DataSet ds = result.ResultDataSet;
}
```

#### 3단계: 연결 확인 변경

```csharp
// 변경 전
bool isConnected = wsProcess.GetWsConnectStatus();
```

```csharp
// 변경 후
bool isConnected = wcfProcess.GetWsConnectStatus();
```

### 마이그레이션 체크리스트

- [ ] `WebServiceProcess` 참조를 `WCFServiceProcess`로 변경
- [ ] `ArrayList` 매개변수를 `Dictionary<string, object>`로 변환
- [ ] 결과 객체 속성명 변경 (`pResultDs` → `ResultDataSet`)
- [ ] 오버로드 매개변수 추가 (기본값: 1)
- [ ] 연결 상태 확인 로직 업데이트
- [ ] 예외 처리 로직 검토

!!! danger "레거시 웹서비스 지원 종료 예정"
    레거시 웹서비스는 향후 지원이 종료될 예정입니다. 신규 개발은 반드시 WCF를 사용하세요.

---

## 오류 코드 및 처리

| 결과 코드 | 의미 | 처리 방법 |
|-----------|------|-----------|
| `0` | 성공 | 정상 처리 |
| `-9` | 연결 실패 | 네트워크 상태 확인, 서버 가동 여부 확인 |
| `-1` | 실행 오류 | 로그 확인, 매개변수 검증 |

```csharp
// 연결 실패 처리
if (result.ResultInt == -9)
{
    MessageBox.Show(
        "웹서비스 서버에 연결할 수 없습니다.\n관리자에게 문의하세요.",
        "연결 오류",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error
    );
}
```
