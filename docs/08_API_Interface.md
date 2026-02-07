# API 인터페이스 정의서

## 1. WCF 서비스 인터페이스

### 1.1 IDatabaseService

```csharp
[ServiceContract]
public interface IDatabaseService
{
    // 저장 프로시저 실행 (결과셋 반환)
    [OperationContract]
    clsDataSetStruct ExecuteProcCls(
        string ProcName, 
        ArrayList aryName, 
        ArrayList aryValue
    );
    
    // 쿼리 직접 실행 (보안취약 - 사용금지 권장)
    [OperationContract]
    clsDataSetStruct ExecuteQry(string strQry);
    
    // 함수 실행 (단일값 반환)
    [OperationContract]
    string ExecuteFunc(
        string ProcName, 
        ArrayList aryName, 
        ArrayList aryValue
    );
    
    // 배치 데이터셋 실행
    [OperationContract]
    clsDataSetStruct ExecuteProcBatchDS(DataSet ds);
    
    // 파일 다운로드
    [OperationContract]
    byte[] DownloadFile(string serverPath);
}
```

### 1.2 데이터 구조

```csharp
[DataContract]
public class clsDataSetStruct
{
    [DataMember]
    public int pResultInt { get; set; }        // 결과코드 (0:성공)
    
    [DataMember]
    public string pResultString { get; set; }   // 결과메시지
    
    [DataMember]
    public DataSet pResultDs { get; set; }      // 결과데이터셋
}

[DataContract]
public class WSResults
{
    [DataMember]
    public int ResultInt { get; set; }
    
    [DataMember]
    public string ResultString { get; set; }
    
    [DataMember]
    public DataSet ResultDataSet { get; set; }
}
```

---

## 2. 호출 패턴

### 2.1 클라이언트 호출 패턴

```csharp
// 1. WCF 클라이언트 생성
WCFServiceProcess ws = new WCFServiceProcess();

// 2. 파라미터 준비
Dictionary<string, object> param = new Dictionary<string, object>
{
    { "A_CLIENT", Global_Variable.CLIENT },
    { "A_COMPANY", Global_Variable.COMPANY },
    { "A_PLANT", Global_Variable.PLANT },
    { "A_WORKDATE", DateTime.Now.ToString("yyyyMMdd") }
};

// 3. 서비스 호출
WSResults result = ws.ExecuteProcCls("PKGPRD_PROD.GET_WORKORDER", param);

// 4. 결과처리
if (result.ResultInt == 0)
{
    DataTable dt = result.ResultDataSet.Tables[0];
    // ...
}
```

### 2.2 파라미터 매핑 규칙

```
[Oracle 프로시저 파라미터] → [C# Dictionary]

IN 파라미터:
  A_CLIENT    →  string (필수)
  A_COMPANY   →  string (필수)
  A_PLANT     →  string (필수)
  A_DATE      →  string (YYYYMMDD)
  A_QTY       →  int/decimal
  
OUT 파라미터:
  O_RESULT    →  int (반환코드)
  O_MSG       →  string (반환메시지)
  O_CUR       →  DataTable (결과셋)
```

---

## 3. 에러 코드 정의

### 3.1 시스템 에러코드

| 코드 | 의미 | 처리방법 |
|------|------|----------|
| 0 | 성공 | 정상처리 |
| -1 | 일반오류 | 오류메시지 표시 |
| -2 | 데이터없음 | "조회결과 없음" 메시지 |
| -3 | 중복오류 | "이미 등록된 데이터" 메시지 |
| -4 | 제약조건위반 | FK 위반이면 참조데이터 확인 |
| -9 | 시스템오류 | 관리자 문의 |
| -99 | DB연결실패 | 네트워크/DB상태 확인 |

### 3.2 비즈니스 에러코드

| 코드 | 의미 | 발생상황 |
|------|------|----------|
| 1001 | 로그인실패 | 사용자ID/비밀번호 불일치 |
| 1002 | 권한없음 | 메뉴접근권한 없음 |
| 2001 | 재고부족 | 출고시 재고부족 |
| 2002 | 중복시리얼 | 시리얼 중복등록 |
| 3001 | 작업지시없음 | 존재하지 않는 작업지시 |
| 3002 | 공정오류 | 잘못된 공정순서 |

---

## 4. 보안

### 4.1 인증

```csharp
// 로그인 토큰 기반 인증
public class Authentication
{
    // 로그인시 세션 생성
    public string CreateSession(string userId)
    {
        string token = GenerateToken(userId);
        // DB에 세션저장
        return token;
    }
    
    // 각 요청시 세션 검증
    public bool ValidateSession(string token)
    {
        // 토큰유효성 + 만료시간 체크
        return true/false;
    }
}
```

### 4.2 암호화

```csharp
// Triple DES 암호화 (레거시)
public class SecurityTripleDES
{
    private static readonly byte[] Key = ...;
    private static readonly byte[] IV = ...;
    
    public string Encrypt(string plainText)
    {
        // Triple DES 암호화
    }
    
    public string Decrypt(string cipherText)
    {
        // Triple DES 복호화
    }
}
```

### 4.3 권한 체크

```csharp
// 메뉴 권한 체크
public bool CheckMenuAuthority(string userId, string menuId)
{
    // TM_MENUROLE 조회
    // 사용자의 권한그룹이 해당 메뉴에 접근가능한지 체크
    return hasAuthority;
}
```

---

## 5. 인터페이스 연계

### 5.1 ERP 연계

```
[ERP] ◀──▶ [PKGIF_ERP] ◀──▶ [MES DB]

연계데이터:
- 수주정보 (ERP ▶ MES)
- 발주정보 (ERP ▶ MES)
- 입고정보 (ERP ▶ MES)
- 출하정보 (MES ▶ ERP)
- 품목마스터 (양방향)

연계방식:
- 방식1: DB Link (Oracle)
- 방식2: WebService (SOAP)
- 주기: 실시간/배치(1시간)
```

### 5.2 PDA 연계

```
[PDA] ◀──▶ [WCF:8101] ◀──▶ [MES DB]

연계데이터:
- 자재입고
- 자재출고
- 재고조회
- 생산실적

특징:
- WiFi 연결
- 바코드스캔
- 소량데이터 전송
```

### 5.3 바코드프린터 연계

```
[MES] ──▶ [Serial Port] ──▶ [Barcode Printer]

제어포맷:
- ZPL (Zebra Printer)
- EPL (Eltron Printer)
- CPCL (Citizen Printer)

라벨템플릿:
- TM_LABEL_MST 테이블 관리
- 품목별 라벨포맷 지정
```

---

## 6. 성능 가이드라인

### 6.1 쿼리 최적화

```sql
-- 권장: 인덱스 활용
SELECT * FROM TW_PRODHIST 
WHERE WORKDATE BETWEEN '20240101' AND '20240131'
  AND CLIENT = '1060'
  AND COMPANY = '40';

-- 비권장: 함수사용으로 인덱스 무효화
SELECT * FROM TW_PRODHIST 
WHERE TO_CHAR(WORKDATE, 'YYYY') = '2024';
```

### 6.2 페이징 처리

```csharp
// 대용량 데이터 페이징
public DataTable GetPagedData(int pageNo, int pageSize)
{
    string sql = $@"
        SELECT * FROM (
            SELECT ROW_NUMBER() OVER (ORDER BY REGDATE DESC) AS RNUM,
                   A.*
            FROM TM_SERIAL A
            WHERE CLIENT = '{client}'
        )
        WHERE RNUM BETWEEN {startRow} AND {endRow}
    ";
    // ...
}
```

### 6.3 타임아웃 설정

```csharp
// WCF 바인딩 설정
var binding = new NetTcpBinding();
binding.OpenTimeout = TimeSpan.FromSeconds(30);
binding.ReceiveTimeout = TimeSpan.FromMinutes(5);
binding.SendTimeout = TimeSpan.FromMinutes(5);
binding.MaxReceivedMessageSize = 10 * 1024 * 1024; // 10MB
```

---

**API 인터페이스 문서 작성 완료**
