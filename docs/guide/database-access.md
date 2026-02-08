# 데이터베이스 접근 가이드

## 개요

HAENGSUNG HNSMES는 데이터베이스 접근을 위해 **WCF 서비스**와 **WebService** 두 가지 방식을 지원합니다. 본 문서는 데이터베이스 접근 패턴과 모범 사례를 설명합니다.

---

## 아키텍처 개요

```
┌─────────────────────────────────────────────────────────────┐
│                    PRESENTATION LAYER                        │
│                      (Windows Forms)                         │
└───────────────────────────┬─────────────────────────────────┘
                            │
┌───────────────────────────▼─────────────────────────────────┐
│                    BUSINESS LOGIC LAYER                      │
│           (WCFDatabaseProcess / WSDatabaseProcess)           │
│                    IDatabaseProcess 인터페이스                │
└───────────────────────────┬─────────────────────────────────┘
                            │
┌───────────────────────────▼─────────────────────────────────┐
│                    SERVICE LAYER                             │
│              (WCF Service / SOAP WebService)                 │
└───────────────────────────┬─────────────────────────────────┘
                            │
┌───────────────────────────▼─────────────────────────────────┐
│                    DATA LAYER                                │
│                   (Oracle Database)                          │
└─────────────────────────────────────────────────────────────┘
```

---

## IDatabaseProcess 인터페이스

### 인터페이스 정의

```csharp
public interface IDatabaseProcess
{
    /// <summary>
    /// 저장 프로시저 실행 (결과 반환)
    /// </summary>
    WSResults Execute_Proc(string p_strProc, int p_iProcSeq, 
                          string[] p_arName, object[] p_arValue);
    
    /// <summary>
    /// 저장 프로시저 실행 (결과 없음)
    /// </summary>
    WSResults Execute_Proc_NoReturn(string p_strProc, int p_iProcSeq, 
                                     string[] p_arName, object[] p_arValue);
    
    /// <summary>
    /// 쿼리 실행
    /// </summary>
    DataSet Get_DataBase(string p_strProc, int p_iProcSeq, 
                         string[] p_arName, object[] p_arValue);
    
    /// <summary>
    /// 연결 상태 확인
    /// </summary>
    bool Check_DBConnection();
}
```

### 구현체

| 구현체 | 설명 | 사용 상황 |
|--------|------|-----------|
| `WCFDatabaseProcess` | WCF(NetTcp) 통신 | 기본 권장 방식 |
| `WSDatabaseProcess` | SOAP WebService | 레거시 지원 |

---

## WCF vs WebService 선택

### WCF 서비스 (권장)

```csharp
// Base.Form에서 자동 설정
public enum WebServiceType
{
    HTTPWebService,
    WCFService  // ✅ 권장
}

// 기본값은 WCF
WebServicetype = WebServiceType.WCFService;
```

!!! success "WCF 장점"
    | 특징 | 설명 |
    |------|------|
    | **성능** | Binary Encoding으로 더 빠른 전송 |
    | **압축** | GZip 압축 지원 |
    | **보안** | Transport 레벨 암호화 지원 |
    | **신뢰성** | 세션 관리 및 재연결 지원 |

### WebService (레거시)

```csharp
// WebService로 전환 필요 시
WebServicetype = WebServiceType.HTTPWebService;
```

!!! warning "WebService 주의사항"
    - HTTP 평문 통신 사용 (보안 취약)
    - XML SOAP 메시지로 인한 오버헤드
    - 레거시 시스템 호환성 유지용으로만 사용

---

## 저장 프로시저 호출

### 기본 호출 패턴

```csharp
// ✅ 표준 호출 패턴
public void SaveWorkOrder(string woNo, string itemCode, int qty)
{
    // 1. 파라미터 정의
    string[] paramNames = new string[]
    {
        "A_CLIENT",
        "A_COMPANY",
        "A_PLANT", 
        "A_WONO",
        "A_ITEMCODE",
        "A_QTY"
    };
    
    object[] paramValues = new object[]
    {
        Global_Variable.CLIENT,
        Global_Variable.COMPANY,
        Global_Variable.PLANT,
        woNo,
        itemCode,
        qty
    };
    
    // 2. 저장 프로시저 실행
    WSResults result = BASE_db.Execute_Proc(
        "PKGPRD_PROD.SET_WORKORDER",  // 프로시저명
        1,                            // 오버로드 번호
        paramNames,                   // 파라미터명 배열
        paramValues                   // 파라미터값 배열
    );
    
    // 3. 결과 처리
    if (result.ResultInt != 0)
    {
        // 오류 발생
        MessageBox.Show($"저장 실패: {result.ResultString}", 
            "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
    }
    
    // 4. 성공 처리
    MessageBox.Show("저장되었습니다.", "확인", 
        MessageBoxButtons.OK, MessageBoxIcon.Information);
}
```

### 저장 프로시저 명명 규칙

```
PKG<모듈>_<엔티티>.<동작>_<대상>

예시:
- PKGSYS_MENU.GET_MENU              (시스템 메뉴 조회)
- PKGPRD_PROD.SET_WORKORDER         (생산 작업지시 저장)
- PKGMAT_INOUT.GET_IQC_SERIAL       (자재 IQC 시리얼 조회)
- PKGSYS_USER.SET_USERMASTER        (시스템 사용자 저장)
```

| 접두사 | 동작 | 설명 |
|--------|------|------|
| `GET_` | 조회 | 데이터 조회 |
| `SET_` | 저장 | INSERT/UPDATE |
| `DEL_` | 삭제 | DELETE |
| `PUT_` | 처리 | 복합 처리 |

---

## 파라미터 전달 패턴

### 1. 기본 파라미터

```csharp
// ✅ 올바른 파라미터 전달
string[] paramNames = new string[]
{
    "A_CLIENT",     // 클라이언트 코드
    "A_COMPANY",    // 회사 코드
    "A_PLANT",      // 공장 코드
    "A_USERID"      // 사용자 ID
};

object[] paramValues = new object[]
{
    Global_Variable.CLIENT,      // "1060"
    Global_Variable.COMPANY,     // "40"
    Global_Variable.PLANT,       // "P200"
    Global_Variable.USER_ID      // 로그인 사용자
};
```

### 2. 공통 파라미터

!!! note "필수 공통 파라미터"
    모든 저장 프로시저 호출 시 다음 파라미터는 기본적으로 포함됩니다:
    
    | 파라미터 | 설명 | 값 예시 |
    |----------|------|---------|
    | `A_CLIENT` | 클라이언트 코드 | `"1060"` |
    | `A_COMPANY` | 회사 코드 | `"40"` |
    | `A_PLANT` | 공장 코드 | `"P200"` |
    | `A_USERID` | 사용자 ID | `"ADMIN"` |

### 3. 동적 파라미터 구성

```csharp
// ✅ Dictionary를 사용한 동적 파라미터 구성
public WSResults ExecuteDynamicProc(string procName, 
    Dictionary<string, object> parameters)
{
    string[] paramNames = parameters.Keys.ToArray();
    object[] paramValues = parameters.Values.ToArray();
    
    // 공통 파라미터 추가
    var commonParams = new Dictionary<string, object>
    {
        ["A_CLIENT"] = Global_Variable.CLIENT,
        [A_COMPANY"] = Global_Variable.COMPANY,
        ["A_PLANT"] = Global_Variable.PLANT
    };
    
    // 기존 파라미터와 병합
    var mergedParams = commonParams.Concat(parameters)
        .ToDictionary(x => x.Key, x => x.Value);
    
    return BASE_db.Execute_Proc(
        procName,
        1,
        mergedParams.Keys.ToArray(),
        mergedParams.Values.ToArray()
    );
}

// 사용 예시
var params = new Dictionary<string, object>
{
    ["A_WONO"] = txtWoNo.Text,
    ["A_ITEMCODE"] = txtItemCode.Text,
    ["A_QTY"] = numQty.Value
};

ExecuteDynamicProc("PKGPRD_PROD.SET_WORKORDER", params);
```

---

## 트랜잭션 처리

### 트랜잭션 처리 패턴

```csharp
// ✅ 다중 작업 트랜잭션 처리
public bool SaveWithTransaction(List<WorkOrderItem> items)
{
    bool success = true;
    string lastWoNo = "";
    
    try
    {
        foreach (var item in items)
        {
            // 작업지시 저장
            WSResults result1 = BASE_db.Execute_Proc(
                "PKGPRD_PROD.SET_WORKORDER",
                1,
                new string[] { "A_CLIENT", "A_COMPANY", "A_PLANT", 
                              "A_WONO", "A_ITEMCODE", "A_QTY" },
                new object[] { Global_Variable.CLIENT, 
                              Global_Variable.COMPANY, 
                              Global_Variable.PLANT,
                              item.WoNo, item.ItemCode, item.Qty }
            );
            
            if (result1.ResultInt != 0)
            {
                success = false;
                throw new ApplicationException(
                    $"작업지시 저장 실패: {result1.ResultString}");
            }
            
            // 자재 예약
            WSResults result2 = BASE_db.Execute_Proc(
                "PKGMAT_RESV.SET_RESERVATION",
                1,
                new string[] { "A_CLIENT", "A_COMPANY", "A_PLANT",
                              "A_WONO", "A_ITEMCODE", "A_QTY" },
                new object[] { Global_Variable.CLIENT,
                              Global_Variable.COMPANY,
                              Global_Variable.PLANT,
                              item.WoNo, item.ItemCode, item.Qty }
            );
            
            if (result2.ResultInt != 0)
            {
                success = false;
                throw new ApplicationException(
                    $"자재예약 실패: {result2.ResultString}");
            }
            
            lastWoNo = item.WoNo;
        }
        
        return true;
    }
    catch (Exception ex)
    {
        LogHelper.SaveLog("트랜잭션 오류", ex.Message);
        
        // 롤백 로직 (필요 시 별도 프로시저 호출)
        RollbackWorkOrders(lastWoNo);
        
        return false;
    }
}
```

!!! warning "중요"
    MES 시스템에서는 데이터베이스 트랜잭션을 서버 측(Oracle)에서 처리하는 것을 권장합니다.
    클라이언트 측 트랜잭션은 네트워크 지연 시 문제가 발생할 수 있습니다.

---

## 결과 처리

### WSResults 구조

```csharp
public class WSResults
{
    public int ResultInt { get; set; }           // 결과 코드 (0: 성공)
    public string ResultString { get; set; }     // 결과 메시지
    public DataSet ResultDataSet { get; set; }   // 반환 데이터
}
```

### 결과 코드 해석

| 코드 | 의미 | 처리 |
|------|------|------|
| `0` | 성공 | 정상 처리 계속 |
| `-1` | 일반 오류 | 오류 메시지 표시 |
| `-2` | 연결 오류 | WCF/WebService 연결 확인 |
| `-9` | 인증 실패 | 로그인 정보 확인 |

### 데이터 조회 처리

```csharp
// ✅ 올바른 결과 처리
public void LoadMaterialList()
{
    WSResults result = BASE_db.Execute_Proc(
        "PKGMAT_STOCK.GET_STOCK_LIST",
        1,
        new string[] { "A_CLIENT", "A_COMPANY", "A_PLANT" },
        new object[] { Global_Variable.CLIENT, 
                      Global_Variable.COMPANY, 
                      Global_Variable.PLANT }
    );
    
    // 1. 실행 결과 확인
    if (result.ResultInt != 0)
    {
        MessageBox.Show($"조회 오류: {result.ResultString}");
        return;
    }
    
    // 2. 데이터 존재 확인
    if (result.ResultDataSet == null)
    {
        MessageBox.Show("데이터가 없습니다.");
        return;
    }
    
    // 3. 테이블 존재 확인
    if (result.ResultDataSet.Tables.Count == 0)
    {
        MessageBox.Show("조회 결과가 없습니다.");
        return;
    }
    
    // 4. 데이터 바인딩
    DataTable dt = result.ResultDataSet.Tables[0];
    gcList.DataSource = dt;
    
    // 5. 상태 표시
    lblStatus.Text = $"총 {dt.Rows.Count}건 조회됨";
}
```

---

## 오류 처리

### 표준 오류 처리 패턴

```csharp
// ✅ 표준 오류 처리
public void SaveWithErrorHandling()
{
    try
    {
        WSResults result = BASE_db.Execute_Proc(
            "PKGPRD_PROD.SET_WORKORDER",
            1,
            paramNames,
            paramValues
        );
        
        // 결과 코드에 따른 처리
        switch (result.ResultInt)
        {
            case 0:
                // 성공
                MessageBox.Show("저장되었습니다.", "확인");
                break;
                
            case -1:
                // 비즈니스 로직 오류
                MessageBox.Show($"저장 실패: {result.ResultString}", 
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                break;
                
            case -2:
                // 연결 오류
                MessageBox.Show("서버 연결에 실패했습니다.\n네트워크 상태를 확인하세요.", 
                    "연결 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                break;
                
            default:
                // 기타 오류
                MessageBox.Show($"알 수 없는 오류: {result.ResultString}", 
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                break;
        }
    }
    catch (Exception ex)
    {
        // 예상치 못한 예외
        LogHelper.SaveLog("SaveWorkOrder", ex.ToString());
        MessageBox.Show("작업 중 오류가 발생했습니다.\n관리자에게 문의하세요.", 
            "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
```

---

## 그리드 데이터 바인딩

### DXGridHelper 사용

```csharp
// ✅ 그리드 데이터 바인딩
public void BindGrid()
{
    // 방법 1: 간단한 바인딩
    BASE_DXGridHelper.Bind_Grid(
        gcList,                                    // GridControl
        "PKGPRD_PROD.GET_WORKORDER_LIST",         // 프로시저명
        1,                                         // 오버로드
        new string[] { "A_CLIENT", "A_COMPANY" }, // 파라미터명
        new object[] { Global_Variable.CLIENT, 
                      Global_Variable.COMPANY }   // 파라미터값
    );
    
    // 방법 2: 고급 바인딩 (옵션 지정)
    BASE_DXGridHelper.Bind_Grid_Int(
        gcList,
        "PKGPRD_PROD.GET_WORKORDER_LIST",
        1,
        new string[] { "A_CLIENT", "A_COMPANY", "A_PLANT" },
        new object[] { Global_Variable.CLIENT,
                      Global_Variable.COMPANY,
                      Global_Variable.PLANT },
        true,                                      // Summary 표시
        "QTY,AMOUNT",                             // Summary 컬럼
        true,                                      // 컬럼 자동 조정
        "WONO,ITEMCODE"                           // 정수형 컬럼
    );
}
```

---

## 성능 최적화

### 데이터 조회 최적화

```csharp
// ✅ 페이지네이션 적용
public void LoadDataWithPaging(int pageNo, int pageSize)
{
    WSResults result = BASE_db.Execute_Proc(
        "PKGPRD_PROD.GET_WORKORDER_LIST_PAGING",
        1,
        new string[] { "A_CLIENT", "A_COMPANY", 
                      "A_PAGE_NO", "A_PAGE_SIZE" },
        new object[] { Global_Variable.CLIENT, 
                      Global_Variable.COMPANY,
                      pageNo, pageSize }
    );
    
    gcList.DataSource = result.ResultDataSet.Tables[0];
}

// ✅ 조건부 조회
public void LoadDataWithCondition(DateTime fromDate, DateTime toDate, 
    string itemCode)
{
    // NULL 조건 처리
    string itemFilter = string.IsNullOrEmpty(itemCode) 
        ? null 
        : itemCode;
    
    WSResults result = BASE_db.Execute_Proc(
        "PKGPRD_PROD.GET_WORKORDER_BY_CONDITION",
        1,
        new string[] { "A_CLIENT", "A_COMPANY",
                      "A_FROM_DATE", "A_TO_DATE", "A_ITEMCODE" },
        new object[] { Global_Variable.CLIENT,
                      Global_Variable.COMPANY,
                      fromDate, toDate, itemFilter }
    );
    
    gcList.DataSource = result.ResultDataSet.Tables[0];
}
```

---

## 보안 고려사항

### SQL Injection 방지

```csharp
// ✅ 안전한 호출 (저장 프로시저 사용)
WSResults result = BASE_db.Execute_Proc(
    "PKGPRD_PROD.GET_WORKORDER",
    1,
    new string[] { "A_WONO" },
    new object[] { woNo }  // 파라미터화된 쿼리
);

// ❌ 절대 사용 금지 (Raw SQL)
WSResults result = BASE_db.ExecuteQry(
    $"SELECT * FROM WORKORDER WHERE WONO = '{woNo}'"  // SQL Injection 위험!
);
```

### 민감한 데이터 처리

```csharp
// ✅ 로그에 민감한 정보 제외
public void SaveUserData(string userId, string password)
{
    // 로그에는 파라미터명만 기록
    LogHelper.SaveLog("SaveUserData", 
        $"Proc: PKG_USER.SET_USER, Params: A_USERID, A_PASSWORD");
    
    // 실제 값은 로그에 남기지 않음
    WSResults result = BASE_db.Execute_Proc(...);
}
```

---

## 체크리스트

데이터베이스 접근 코드 작성 시 다음 사항을 확인하세요:

- [ ] 저장 프로시저명이 명명 규칙을 따르는가?
- [ ] 공통 파라미터(A_CLIENT, A_COMPANY, A_PLANT)가 포함되었는가?
- [ ] 결과 코드(ResultInt)를 확인하는가?
- [ ] null 체크를 수행하는가?
- [ ] 오류 처리가 적절한가?
- [ ] 로그를 기록하는가?
- [ ] Raw SQL 대신 저장 프로시저를 사용하는가?
