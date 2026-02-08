# 문제점 분석 및 개선 제안서

## 1. 현재 시스템 문제점 분석

### 1.1 보안 취약점 (CRITICAL)

| 문제 | 심각도 | 위치 | 현상 | 위험도 |
|------|--------|------|------|--------|
| **하드코딩된 비밀번호** | CRITICAL | Global_Variable01.cs | FTP/SMB 비밀번호 소스코드 노출 | 높음 |
| **SQL Injection** | CRITICAL | WebServiceProcess.cs | ExecuteQry() 직접 SQL 실행 | 높음 |
| **취약한 암호화** | HIGH | SecurityTripleDES.cs | Triple DES 사용 (NIST 폐기권고) | 중간 |
| **HTTP 평문 통신** | HIGH | app.config | WebService HTTP 사용 | 중간 |
| **무제한 리소스** | HIGH | DatabaseServiceClientHelper.cs | 메시지크기 무제한 | 중간 |

#### 개선안

```csharp
// 1. 비밀번호 외부화
// BEFORE (취약)
public static string FTP_PW = "********";

// AFTER (권고)
public static string FTP_PW = ConfigurationManager
    .AppSettings["FTP_PW"]; // 암호화된 설정파일에서 로드

// 2. SQL Injection 방지
// BEFORE (취약)
public WSResults ExecuteQry(string strQry) {
    result = WebSvr.ExecuteQry(strQry); // 위험!
}

// AFTER (권고)
public WSResults ExecuteQry(string strQry) {
    throw new NotSupportedException("Raw SQL not allowed");
    // 모든 쿼리는 파라미터화된 프로시저만 사용
}

// 3. 암호화 강화
// BEFORE (취약)
TripleDES.Create(); // 폐기예정

// AFTER (권고)
Aes.Create(); // AES-256 권고
```

---

### 1.2 코드 품질 문제

| 문제 | 발생빈도 | 영향 | 개선우선순위 |
|------|----------|------|--------------|
| 빈 catch 블록 | 50+ | 디버깅 불가 | 높음 |
| 전역변수 의존 | 100+ | 테스트불가, 스레드위험 | 높음 |
| UI-비즈니스결합 | 30+ | 재사용불가 | 중간 |
| 복사붙여넣기코드 | 많음 | 유지보수어려움 | 중간 |
| 매직넘버 | 많음 | 가독성저하 | 낮음 |

#### 개선 예시

```csharp
// 1. 예외처리 개선
// BEFORE
}catch (Exception) { }

// AFTER
}catch (Exception ex) { 
    LogHelper.WriteLog("Error in MethodName", ex);
    throw new CustomException("사용자친화적메시지", ex);
}

// 2. 전역변수 제거
// BEFORE
Global_Variable.USER_ID = txtId.Text;

// AFTER
public class UserSession {
    public string UserId { get; private set; }
    // DI로 주입
}

// 3. UI-비즈니스분리
// BEFORE (폼에서 DB직접호출 + 메시지박스)
private void SaveButton_Click() {
    var result = db.ExecuteProc(...);
    if (result.ResultInt == 0) {
        MessageBox.Show("저장성공");
    }
}

// AFTER (서비스레이어 분리)
public class ProductionService {
    public Result SaveProduction(ProductionDto dto) {
        // 비즈니스로직
        return result;
    }
}
```

---

### 1.3 성능 문제

| 문제 | 위치 | 영향 | 개선방안 |
|------|------|------|----------|
| 매 호출시 서비스인스턴스생성 | WCFDatabaseProcess.cs | 메모리누수,느림 | 싱글톤/풀링 적용 |
| 셀단위 Excel COM 호출 | ExcelHelper.cs | 느림 | Range단위 처리 |
| 무제한 WCF 설정 | DatabaseServiceClientHelper.cs | DoS위험 | 적정값 설정 |
| 비압축 데이터전송 | WCF | 네트워크부하 | GZip 적용 (일부적용됨) |

#### 개선 예시

```csharp
// 1. 서비스 인스턴스 재사용
// BEFORE
public WSResults Execute_Proc(...) {
    WCFServiceProcess _db = new WCFServiceProcess(); // 매번생성
}

// AFTER
private static readonly WCFServiceProcess _db = new WCFServiceProcess();

// 2. Excel 최적화
// BEFORE (셀단위 - 느림)
for (int i = 1; i <= rows; i++) {
    for (int j = 1; j <= cols; j++) {
        sheet.Cells[i, j].Value = data[i, j]; // 10000번 COM 호출
    }
}

// AFTER (Range단위 - 빠름)
Range range = sheet.Range["A1:Z1000"];
range.Value = data; // 1번 COM 호출

// 3. WCF 제한설정
// BEFORE (무제한)
tcp.MaxReceivedMessageSize = int.MaxValue;

// AFTER (제한)
tcp.MaxReceivedMessageSize = 10 * 1024 * 1024; // 10MB
tcp.OpenTimeout = TimeSpan.FromSeconds(30);
```

---

## 2. 아키텍처 개선 로드맵

### 2.1 단기 (1~3개월)

| 항목 | 작업내용 | 예상효과 |
|------|----------|----------|
| 보안패치 | 비밀번호 외부화, SQL Injection 차단 | 보안강화 |
| 로깅개선 | 빈 catch블록 제거 | 디버깅향상 |
| 성능튜닝 | 인덱스 추가, 쿼리최적화 | 속도개선 30% |
| 문서정리 | 불용코드 제거 | 유지보수성 |

### 2.2 중기 (3~6개월)

| 항목 | 작업내용 | 예상효과 |
|------|----------|----------|
| DI도입 | 의존성주입 컨테이너 적용 | 테스트용이 |
| 레이어분리 | UI-Business-Data 분리 | 재사용성 |
| 암호화전환 | Triple DES → AES-256 | 보안강화 |
| API표준화 | RESTful API 도입 | 확장성 |

### 2.3 장기 (6~12개월)

| 항목 | 작업내용 | 예상효과 |
|------|----------|----------|
| 클라우드이전 | AWS/Azure 마이그레이션 | 확장성/비용 |
| 모바일앱 | Xamarin/MAUI 도입 | 사용성 |
| 리얼타임 | SignalR 도입 | 실시간알림 |
| AI도입 | 예측분석, 이상탐지 | 스마트화 |

---

## 3. 리팩토링 가이드

### 3.1 단계별 리팩토링

```
Phase 1: 안전한 리팩토링
├── 변수명/메서드명 개선
├── 매직넘버 상수화
├── 중복코드 메서드추출
└── 주석보강

Phase 2: 구조개선
├── 전역변수 → DI
├── 정적메서드 → 인스턴스메서드
├── 프로시저파라미터 → 객체전달
└── 예외처리 표준화

Phase 3: 아키텍처개선
├── 레이어 분리
├── 인터페이스 도입
├── Repository 패턴
└── Unit of Work 패턴
```

### 3.2 코드품질 체크리스트

```markdown
[ ] 모든 public 메서드에 XML 주석 작성
[ ] 20줄 이상 메서드는 분리
[ ] 3개이상 파라미터는 DTO 사용
[ ] 예외는 구체적인 타입으로 catch
[ ] null 체크는 ?. 연산자 사용
[ ] 문자열연결은 $"" 보간 사용
[ ] using문으로 IDisposable 관리
[ ] async/await 사용으로 UI응답개선
```

---

## 4. 테스트 전략

### 4.1 테스트 도입

```csharp
// 단위테스트 예시
[TestClass]
public class ProductionServiceTests {
    [TestMethod]
    public void SaveProduction_ValidData_ReturnsSuccess() {
        // Arrange
        var service = new ProductionService(mockRepo.Object);
        var dto = new ProductionDto { ... };
        
        // Act
        var result = service.SaveProduction(dto);
        
        // Assert
        Assert.AreEqual(0, result.Code);
    }
}
```

### 4.2 테스트 커버리지 목표

| 레이어 | 목표커버리지 | 우선순위 |
|--------|-------------|----------|
| Business | 80% | 높음 |
| DataAccess | 60% | 중간 |
| UI | 30% | 낮음 |

---

## 5. 모니터링/로깅 개선

### 5.1 중앙집중식 로깅

```csharp
// Serilog 도입 권고
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.Seq("http://localhost:5341") // 중앙로그서버
    .CreateLogger();

// 사용
Log.Information("Production saved: {WorkOrder}", workOrder);
Log.Error(ex, "Production save failed");
```

### 5.2 성능모니터링

```csharp
// Metrics 도입
using (Operation.Time("Production.Save")) {
    // 작업
}

// 결과: Production.Save 평균 150ms, 95th 300ms
```

---

## 6. 개선 우선순위 매트릭스

| 개선항목 | 긴급도 | 중요도 | 난이도 | 우선순위 |
|----------|--------|--------|--------|----------|
| 하드코딩비밀번호제거 | 높음 | 높음 | 낮음 | **1** |
| SQLInjection차단 | 높음 | 높음 | 낮음 | **2** |
| 빈catch블록제거 | 높음 | 중간 | 낮음 | **3** |
| 로깅개선 | 중간 | 높음 | 낮음 | **4** |
| 성능최적화 | 중간 | 중간 | 중간 | **5** |
| DI도입 | 낮음 | 높음 | 높음 | **6** |
| 클라우드이전 | 낮음 | 중간 | 높음 | **7** |

---

## 7. 예상 비용/효과

| 개선영역 | 예상공수 | 예상효과 |
|----------|----------|----------|
| 보안강화 | 2주 | 보안이슈 90% 감소 |
| 성능개선 | 4주 | 응답속도 50% 개선 |
| 코드품질 | 8주 | 버그 40% 감소 |
| 아키텍처 | 12주 | 유지보수비용 30% 감소 |

---

**문서 작성 완료**
