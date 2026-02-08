# 배포 가이드

## 개요

본 문서는 HAENGSUNG HNSMES 애플리케이션의 배포 절차와 운영 환경 설정을 설명합니다.

---

## 사전 배포 체크리스트

### 1. 소스 코드 검증

- [ ] 모든 소스 파일이 최신 버전으로 커밋되었는가?
- [ ] 디버그 코드가 제거되었는가? (`Console.WriteLine`, 디버그 메시지 등)
- [ ] 테스트 코드가 정상 통과하는가?
- [ ] 코드 리뷰가 완료되었는가?
- [ ] bak 폴더가 정리되었는가?

### 2. 데이터베이스 검증

- [ ] 데이터베이스 변경 스크립트가 준비되었는가?
- [ ] 프로시저 변경 이력이 문서화되었는가?
- [ ] 롤백 스크립트가 준비되었는가?
- [ ] 데이터 마이그레이션 계획이 수립되었는가?

### 3. 환경 설정 검증

- [ ] app.config의 연결 문자열이 운영 환경으로 설정되었는가?
- [ ] 로그 경로가 올바르게 설정되었는가?
- [ ] 이미지 및 리소스 경로가 확인되었는가?

---

## 빌드 구성

### 1. Release 모드 빌드

```powershell
# Visual Studio Developer Command Prompt에서 실행
msbuild HAENGSUNG_HNSMES_UI_DBESS.sln /p:Configuration=Release /p:Platform="Any CPU"
```

### 2. ClickOnce 게시

```powershell
# ClickOnce 게시 설정
msbuild HAENGSUNG_HNSMES_UI.csproj /t:Publish /p:Configuration=Release
```

### 3. 빌드 출력 구조

```
bin/Release/
├── HAENGSUNG_CDBHNSMES.exe          # 실행 파일
├── HAENGSUNG_CDBHNSMES.exe.manifest # 매니페스트
├── HAENGSUNG_CDBHNSMES.application  # ClickOnce 애플리케이션 파일
├── *.dll                            # 종속 DLL
├── Excel/                           # 엑셀 템플릿
├── IMAGE/                           # 이미지 리소스
└── app.publish/                     # ClickOnce 게시 파일
    └── HAENGSUNG_CDBHNSMES.exe
```

---

## 환경별 설정

### 개발 환경 (Development)

```xml
<!-- app.config -->
<appSettings>
  <add key="WCFService" value="net.tcp://10.x.x.9:8101/NGS/WCFService" />
  <add key="WebService" value="http://10.x.x.9:8807/IDISYS_2012/IDAT_WebSvr.asmx" />
  <add key="LANGUAGE" value="KR" />
  <add key="LOG_LEVEL" value="DEBUG" />
</appSettings>
```

### 테스트 환경 (Testing)

```xml
<!-- app.config -->
<appSettings>
  <add key="WCFService" value="net.tcp://10.x.x.9:8101/NGS/WCFService" />
  <add key="WebService" value="http://10.x.x.9:8807/IDISYS_2012/IDAT_WebSvr.asmx" />
  <add key="LANGUAGE" value="KR" />
  <add key="LOG_LEVEL" value="INFO" />
</appSettings>
```

### 운영 환경 (Production)

```xml
<!-- app.config -->
<appSettings>
  <add key="WCFService" value="net.tcp://10.x.x.9:8101/NGS/WCFService" />
  <add key="WebService" value="http://10.x.x.9:8807/IDISYS_2012/IDAT_WebSvr.asmx" />
  <add key="LANGUAGE" value="KR" />
  <add key="LOG_LEVEL" value="ERROR" />
</appSettings>
```

---

## 설치 단계

### 1. 서버 환경 준비

```powershell
# 필수 구성 요소 설치 확인
# - .NET Framework 4.0 이상
# - Windows Installer 4.5 이상
# - Visual C++ 2010 재배포 가능 패키지
```

### 2. ClickOnce 설치

#### 방법 1: 웹 서버를 통한 설치

```
1. 게시 폴더를 웹 서버에 업로드
   - publish.htm (설치 페이지)
   - HAENGSUNG_CDBHNSMES.application
   - Application Files/ 폴더

2. 사용자에게 설치 URL 제공
   예: http://mes.haengsung.com/setup/publish.htm

3. 사용자가 URL에 접속하여 "설치" 클릭
```

#### 방법 2: 파일 공유를 통한 설치

```
1. 게시 폴더를 네트워크 공유에 복사
   예: \\MES-SERVER\Setup\

2. 사용자가 \\MES-SERVER\Setup\publish.htm 실행

3. 자동으로 설치 진행
```

### 3. 설치 후 확인

```powershell
# 설치 위치 확인
%LocalAppData%\Apps\2.0\

# 바로가기 위치
%AppData%\Microsoft\Windows\Start Menu\Programs\Haengsung\

# 레지스트리 확인
HKEY_CURRENT_USER\Software\Haengsung\HNSMES
```

---

## 데이터베이스 업데이트

### 1. 업데이트 스크립트 실행

```sql
-- =============================================
-- 데이터베이스 업데이트 스크립트 예시
-- 버전: 1.2.0
-- 작성일: 2026-02-07
-- =============================================

-- 1. 신규 테이블 생성
CREATE TABLE MES_WORKORDER_EXT (
    WORKORDER_ID VARCHAR2(20) PRIMARY KEY,
    PRIORITY VARCHAR2(10),
    REMARK VARCHAR2(500),
    CREATE_DATE DATE DEFAULT SYSDATE,
    CREATE_USER VARCHAR2(50)
);

-- 2. 기존 테이블 변경
ALTER TABLE MES_WORKORDER ADD (
    PRIORITY VARCHAR2(10),
    EXT_ID VARCHAR2(20)
);

-- 3. 인덱스 생성
CREATE INDEX IDX_WORKORDER_PRIORITY ON MES_WORKORDER(PRIORITY);

-- 4. 저장 프로시저 업데이트
CREATE OR REPLACE PACKAGE PKGPRD_PROD AS
    -- 기존 프로시저
    PROCEDURE GET_WORKORDER_LIST(
        A_CLIENT IN VARCHAR2,
        A_COMPANY IN VARCHAR2,
        O_CUR OUT SYS_REFCURSOR
    );
    
    -- 신규 프로시저
    PROCEDURE SET_WORKORDER_PRIORITY(
        A_CLIENT IN VARCHAR2,
        A_COMPANY IN VARCHAR2,
        A_WONO IN VARCHAR2,
        A_PRIORITY IN VARCHAR2,
        A_USERID IN VARCHAR2,
        O_RESULT OUT NUMBER
    );
END PKGPRD_PROD;
/

-- 5. 데이터 마이그레이션
INSERT INTO MES_WORKORDER_EXT (WORKORDER_ID, PRIORITY, CREATE_DATE, CREATE_USER)
SELECT WONO, 'NORMAL', SYSDATE, 'SYSTEM' FROM MES_WORKORDER;

COMMIT;
```

### 2. 업데이트 순서

```
1. 백업 수행
   - 데이터베이스 전체 백업
   - 특정 테이블 백업 (선택)

2. DDL 실행
   - 테이블 생성/수정
   - 인덱스 생성
   - 제약조건 변경

3. DML 실행
   - 데이터 마이그레이션
   - 참조 데이터 업데이트

4. 저장 프로시저/함수 업데이트
   - 패키지 헤더
   - 패키지 본문
   - 독립 프로시저/함수

5. 권한 재부여
   - GRANT 문 실행

6. 검증
   - 테스트 쿼리 실행
   - 애플리케이션 연결 테스트
```

### 3. 업데이트 검증

```sql
-- 버전 확인
SELECT * FROM MES_SYSTEM_VERSION ORDER BY UPDATE_DATE DESC;

-- 프로시저 상태 확인
SELECT OBJECT_NAME, STATUS 
FROM USER_OBJECTS 
WHERE OBJECT_TYPE = 'PACKAGE BODY' 
AND STATUS = 'INVALID';

-- 데이터 정합성 확인
SELECT COUNT(*) FROM MES_WORKORDER WHERE WONO NOT IN (
    SELECT WORKORDER_ID FROM MES_WORKORDER_EXT
);
```

---

## 롤백 절차

### 1. 롤백 계획

```
롤백 시나리오:
1. 애플리케이션 오류 발생 시
2. 데이터베이스 오류 발생 시
3. 성능 저하 발생 시
```

### 2. 애플리케이션 롤백

#### ClickOnce 이전 버전 복원

```powershell
# 방법 1: 이전 버전 강제 실행
# publish.htm에서 이전 버전 선택

# 방법 2: 캐시 삭제 후 재설치
rundll32 %windir%\system32\dfshim.dll CleanOnlineAppCache
# 이전 버전 설치
```

#### 수동 롤백

```powershell
# 1. 현재 버전 제거
rundll32 dfshim.dll ShArpMaintain 
    HAENGSUNG_CDBHNSMES.application, 
    Culture=neutral, 
    PublicKeyToken=xxxxxxxxxxxxxxxx, 
    processorArchitecture=msil

# 2. 이전 버치 백업에서 복원
xcopy /E /I \\Backup\MES_v1.1.0\* C:\MES\

# 3. 이전 버전 실행
```

### 3. 데이터베이스 롤백

```sql
-- =============================================
-- 롤백 스크립트 예시
-- =============================================

-- 1. 백업 테이블에서 데이터 복원
INSERT INTO MES_WORKORDER (
    WONO, ITEMCODE, QTY, STATUS
)
SELECT WONO, ITEMCODE, QTY, STATUS 
FROM MES_WORKORDER_BAK_20260207;

-- 2. 신규 컬럼 제거
ALTER TABLE MES_WORKORDER DROP COLUMN PRIORITY;
ALTER TABLE MES_WORKORDER DROP COLUMN EXT_ID;

-- 3. 신규 테이블 제거
DROP TABLE MES_WORKORDER_EXT;

-- 4. 이전 버전 프로시저 복원
@rollback_pkg_prd_prod.sql

COMMIT;
```

---

## 문제 해결

### 1. 설치 문제

#### ClickOnce 설치 오류

```
오류: "Application cannot be started"

원인:
- 인증서 문제
- 서버 접근 불가
- .NET Framework 버전 불일치

해결:
1. 인증서 확인 및 재설치
2. 서버 연결 확인
3. .NET Framework 4.0 설치 확인
```

#### 권한 문제

```powershell
# 관리자 권한으로 실행
# 바로가기 속성 -> 고급 -> 관리자 권한으로 실행

# 폴더 권한 설정
icacls "C:\MES" /grant Users:F /T
```

### 2. 실행 문제

#### WCF 연결 오류

```
오류: "Could not connect to net.tcp://..."

원인:
- 방화벽 차단
- 서비스 미실행
- 잘못된 주소 설정

해결:
1. 방화벽 8101 포트 개방 확인
2. WCF 서비스 상태 확인
3. app.config 주소 확인
```

#### 데이터베이스 연결 오류

```
오류: "ORA-12154: TNS could not resolve the connect identifier"

원인:
- Oracle Client 미설치
- TNS 설정 오류
- 네트워크 연결 문제

해결:
1. Oracle Data Provider 설치
2. tnsnames.ora 설정 확인
3. 네트워크 연결 테스트
```

### 3. 성능 문제

#### 느린 시작

```
원인:
- 대용량 로그 파일
- 많은 설정 파일
- 네트워크 지연

해결:
1. 로그 파일 정리
2. 설정 파일 최적화
3. 로컬 캐시 사용
```

#### 메모리 누수

```
원인:
- COM 객체 미해제
- 이벤트 핸들러 미제거
- IDisposable 미구현

해결:
1. Marshal.ReleaseComObject() 호출
2. 이벤트 핸들러 제거
3. using 문 사용
```

---

## 유지보수

### 1. 로그 관리

```powershell
# 로그 파일 정리 스크립트
$logPath = "C:\MES\LOG"
$retentionDays = 30

Get-ChildItem $logPath -Filter "*.txt" | 
    Where-Object { $_.LastWriteTime -lt (Get-Date).AddDays(-$retentionDays) } |
    Remove-Item -Force

# Windows Task Scheduler에 등록
# 실행: 매일 자정
```

### 2. 백업 전략

```
일일 백업:
- 시간: 매일 02:00
- 대상: 실행 파일, 설정 파일
- 보관: 7일

주간 백업:
- 시간: 매주 일요일 03:00
- 대상: 전체 설치 폴더
- 보관: 4주

월간 백업:
- 시간: 매월 1일 04:00
- 대상: 전체 시스템
- 보관: 12개월
```

### 3. 모니터링

```powershell
# 시스템 상태 확인 스크립트
$computerName = $env:COMPUTERNAME
$mesPath = "C:\MES"

# 디스크 공간 확인
$disk = Get-WmiObject Win32_LogicalDisk -Filter "DeviceID='C:'"
$freeSpaceGB = [math]::Round($disk.FreeSpace / 1GB, 2)

if ($freeSpaceGB -lt 5) {
    Send-MailMessage -To "admin@haengsung.com" `
                     -From "mes@haengsung.com" `
                     -Subject "[$computerName] 디스크 공간 부족" `
                     -Body "남은 공간: $freeSpaceGB GB"
}

# 프로세스 확인
$process = Get-Process -Name "HAENGSUNG_CDBHNSMES" -ErrorAction SilentlyContinue
if (-not $process) {
    Send-MailMessage -To "admin@haengsung.com" `
                     -From "mes@haengsung.com" `
                     -Subject "[$computerName] MES 프로세스 중지" `
                     -Body "MES 프로세스가 실행 중이지 않습니다."
}
```

---

## 연락처 및 지원

| 구분 | 연락처 | 담당 |
|------|--------|------|
| 시스템 담당 | it@haengsung.com | IT팀 |
| 데이터베이스 | dba@haengsung.com | DB팀 |
| 업무 문의 | mes@haengsung.com | MES팀 |
| 긴급 지원 | 02-1234-5678 | 24/7 지원 |

---

## 버전 이력

| 버전 | 날짜 | 내용 | 담당자 |
|------|------|------|--------|
| 1.0.0 | 2024-01-15 | 초기 릴리스 | 김개발 |
| 1.1.0 | 2024-06-20 | 기능 개선 | 이개발 |
| 1.2.0 | 2026-02-07 | 성능 최적화 | 박개발 |
