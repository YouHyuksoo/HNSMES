# 프로젝트 구조 가이드

## 개요

HAENGSUNG HNSMES 프로젝트는 제조실행시스템(MES)을 위한 Windows Forms 애플리케이션입니다. 본 문서는 프로젝트의 디렉토리 구조와 조직화 방식을 설명합니다.

---

## 전체 프로젝트 디렉토리 구조

```
HNSMES/
├── HAENGSUNG_HNSMES_UI/           # 메인 프로젝트 폴
│   ├── Base.Class/                # 기반 클래스 라이브러리
│   │   ├── 1.Controls/            # 컨트롤 관련 클래스
│   │   ├── 2.DB/                  # 데이터베이스 관련 클래스
│   │   ├── 3.Hardware/            # 하드웨어 연동 클래스
│   │   ├── 4.Extension/           # 확장 메서드
│   │   ├── 5.ActiveDemo/          # 데모 기능
│   │   └── WCF/                   # WCF 서비스 클라이언트
│   ├── Forms/                     # 화면(폼) 모듈
│   │   ├── Base/                  # 기본 폼 클래스
│   │   ├── COM/                   # 공통 모듈
│   │   ├── MAT/                   # 자재관리
│   │   ├── MNT/                   # 보전관리
│   │   ├── MST/                   # 기준정보
│   │   ├── OSC/                   # 외주관리
│   │   ├── PRD/                   # 생산관리
│   │   ├── RPT/                   # 리포트
│   │   ├── SAL/                   # 영업/출하
│   │   ├── SYS/                   # 시스템관리
│   │   └── SAMPLE/                # 샘플/예제
│   ├── Global/                    # 전역 변수 및 함수
│   ├── MyClass/                   # 사용자 정의 클래스
│   ├── Excel/                     # 엑셀 템플릿
│   ├── IMAGE/                     # 이미지 리소스
│   ├── bin/                       # 빌드 출력
│   └── obj/                       # 빌드 임시 파일
├── DLL/                           # 외부 라이브러리
└── docs/                          # 문서
```

---

## 모듈 조직

### 모듈 구성

| 모듈 | 설명 | 폼 수 (약) | 주요 업무 |
|------|------|-----------|-----------|
| **COM** | 공통 (Common) | 19 | 로그인, 설정, 공통 팝업 |
| **SYS** | 시스템관리 (System) | 18 | 사용자, 권한, 메뉴, 코드 관리 |
| **MST** | 기준정보관리 (Master) | 21 | 공장, 품목, BOM, 라우팅 관리 |
| **MAT** | 자재관리 (Material) | 26 | 입고, IQC, 재고, 이력 관리 |
| **PRD** | 생산관리 (Production) | 43 | 작업지시, 실적, 검사 관리 |
| **MNT** | 보전관리 (Maintenance) | 13 | 설비보전, SMT 라인 관리 |
| **OSC** | 외주관리 (Outsourcing) | 5 | 외주 작업지시, 관리 |
| **SAL** | 영업/출하 (Sales) | 9 | 출하, OQC, 이력 관리 |
| **RPT** | 리포트 (Report) | 20 | 각종 보고서 및 분석 |
| **SAMPLE** | 샘플/데모 | 5 | 개발 예제 |

### 폼 ID 명명 규칙

```
[MODULE][TYPE][NUMBER]
   │      │      │
   │      │      └── 201~299: 일련번호
   │      │
   │      └── A: 주요 업무 (등록/처리)
   │          B: 조회/이력/현황
   │          C: 고급/특수 기능
   │          H: 도움말/참조
   │
   └── COM: 공통     MAT: 자재     MNT: 보전
       MST: 기준정보  OSC: 외주     PRD: 생산
       RPT: 리포트    SAL: 영업     SYS: 시스템
```

!!! example "명명 예시"
    | 폼 ID | 모듈 | 타입 | 설명 |
    |-------|------|------|------|
    | `PRDA201` | PRD(생산) | A(등록) | 작업지시 생성 |
    | `MATB201` | MAT(자재) | B(조회) | 입출고 이력 |
    | `SYSA203` | SYS(시스템) | A(등록) | 공통코드 마스터 |

---

## 주요 디렉토리 설명

### 1. Base.Class - 기반 클래스

```
Base.Class/
├── 1.Controls/
│   ├── itfButton.cs              # 버튼 인터페이스
│   ├── itfScanner.cs             # 스캐너 인터페이스
│   ├── Data.cs                   # 데이터 처리
│   └── MainButton.cs             # 메인 버튼 클래스
├── 2.DB/                         # 데이터베이스 클래스
├── 3.Hardware/
│   ├── itfScanner.cs             # 바코드 스캐너
│   ├── clsPrintBarcode.cs        # 바코드 프린터
│   └── clsLPT.cs                 # LPT 프린터
├── 4.Extension/
│   └── ExtensionMethod.cs        # 확장 메서드
├── 5.ActiveDemo/
│   └── ActiveDemoBusiness.cs     # 데모 비즈니스
├── WCF/                          # WCF 클라이언트
│   ├── DatabaseServiceClientHelper.cs
│   ├── WCFClient.cs
│   ├── ServiceSettings.cs
│   └── SecurityTripleDES.cs      # 암호화
├── DXGridHelper.cs               # 그리드 헬퍼
├── DXGridLookUpHelper.cs         # 룩업 헬퍼
├── ExcelHelper.cs                # 엑셀 헬퍼
├── LanguageInformation.cs        # 다국어 지원
└── SharedAPI.cs                  # 공통 API
```

### 2. Forms - 화면 모듈

```
Forms/
├── Base/
│   ├── Form.cs                   # 기본 폼 클래스
│   └── UserControl.cs            # 기본 사용자 컨트롤
├── COM/                          # 공통 폼
│   ├── COMLOGIN.cs               # 로그인
│   ├── COMREGISTER.cs            # 사용자 등록
│   └── ...
├── [MODULE]/                     # 각 업무 모듈
│   ├── [FORM_ID].cs              # 폼 코드
│   ├── [FORM_ID].Designer.cs     # 디자이너 코드
│   ├── [FORM_ID].resx            # 리소스
│   └── PopUp/                    # 팝업 폼
│       └── POP_[NAME].cs
```

### 3. Global - 전역 설정

```
Global/
├── Global_Variable01.cs          # 전역 변수
└── GlobalFunction.cs             # 전역 함수
```

!!! warning "주의사항"
    `Global_Variable01.cs`에 하드코딩된 자격증명(FTP 비밀번호 등)이 포함되어 있습니다. 보안 강화가 필요합니다.

---

## 파일 명명 규칙

### 1. 폼 파일

| 파일 유형 | 명명 규칙 | 예시 |
|-----------|-----------|------|
| 메인 폼 | `[MODULE][TYPE][NUMBER].cs` | `PRDA201.cs` |
| 디자이너 | `[FORM_ID].Designer.cs` | `PRDA201.Designer.cs` |
| 리소스 | `[FORM_ID].resx` | `PRDA201.resx` |
| 팝업 | `POP_[MODULE][NUMBER].cs` | `POP_PRD01.cs` |

### 2. 클래스 파일

```
[접두사]_[클스명].cs

예시:
- BASE_Form.cs          # 기본 폼
- DXGridHelper.cs       # 그리드 헬퍼
- WSResults.cs          # 웹서비스 결과
```

### 3. 변수 명명 규칙

| 범위 | 접두사 | 예시 | 설명 |
|------|--------|------|------|
| 전역 변수 | `g_` | `g_strIPADDRESS` | 글로벌 변수 |
| 파라미터 | `p_` | `p_strProc`, `p_iProcSeq` | 메서드 파라미터 |
| 지역 변수 | `_` | `_result`, `_dicPara` | 메서드 내부 변수 |
| 멤버 변수 | `m` | `mIP`, `mPort` | 클래스 멤버 변수 |

---

## 빌드 출력 구조

### Debug/Release 폴더

```
bin/
├── Debug/                        # 디버그 빌드
│   ├── HAENGSUNG_CDBHNSMES.exe   # 실행 파일
│   ├── HAENGSUNG_CDBHNSMES.pdb   # 디버그 심볼
│   ├── *.dll                     # 외부 라이브러리
│   ├── Excel/                    # 엑셀 템플릿
│   ├── IMAGE/                    # 이미지 리소스
│   └── XML_FILES/                # 설정 XML
└── Release/                      # 릴리즈 빌드
    └── ...
```

### 필수 DLL 목록

| DLL | 설명 |
|-----|------|
| `DevExpress.*.v13.2.dll` | DevExpress UI 컴포넌트 |
| `Oracle.ManagedDataAccess.dll` | Oracle 데이터 접근 |
| `IDAT.*.dll` | IDAT 프레임워크 |
| `System.ServiceModel.dll` | WCF 통신 |

---

## 프로젝트 설정

### 주요 설정 파일

```
HAENGSUNG_HNSMES_UI/
├── app.config                    # 애플리케이션 설정
├── HAENGSUNG_HNSMES_UI.csproj    # 프로젝트 파일
└── .editorconfig                 # 에디터 설정
```

### app.config 주요 설정

```xml
<configuration>
  <appSettings>
    <!-- WCF 서비스 주소 -->
    <add key="WCFService" value="net.tcp://10.2.31.9:8101/NGS/WCFService" />
    <!-- 웹서비스 주소 -->
    <add key="WebService" value="http://10.2.31.9:8807/IDISYS_2012/IDAT_WebSvr.asmx" />
    <!-- 언어 설정 -->
    <add key="LANGUAGE" value="KR" />
  </appSettings>
</configuration>
```

---

## 메뉴 구조

```
HAENGSUNG HNS MES
├── COM 공통
│   ├── COMLOGIN (로그인)
│   ├── COMREGISTER (사용자 등록)
│   └── ...
├── SYS 시스템관리
├── MST 기준정보관리
├── MAT 자재관리
├── PRD 생산관리
├── MNT 보전관리
├── OSC 외주관리
├── SAL 영업/출하관리
└── RPT 리포트
```

!!! tip "메뉴 로딩"
    메뉴는 데이터베이스의 `PKGSYS_MENU.GET_MENU` 프로시저를 통해 동적으로 로드됩니다.

---

## 참고사항

### 개발 시 주의사항

1. **신규 폼 생성 시**: 반드시 `Forms.BASE.Form`을 상속받아 작성
2. **데이터베이스 접근**: `BASE_db` 객체를 통해 저장 프로시저 호출
3. **버튼 이벤트**: `itfButton` 인터페이스 구현 필요
4. **그리드 바인딩**: `BASE_DXGridHelper` 클래스 사용 권장

### 파일 배치 규칙

- 새로운 업무 폼은 해당 모듈 폴더에 생성
- 공통으로 사용되는 클래스는 `Base.Class`에 생성
- 사용자 정의 클래스는 `MyClass` 폴더에 생성
