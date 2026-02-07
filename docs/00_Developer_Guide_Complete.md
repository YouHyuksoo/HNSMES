# HAENGSUNG HNSMES UI 개발자 가이드

**버전**: 1.0  
**작성일**: 2026-02-07  
**대상**: 개발자/유지보수 엔지니어

---

## 목차

1. [시스템 개요](#1-시스템-개요)
2. [아키텍처](#2-아키텍처)
3. [개발 환경](#3-개발-환경)
4. [프로젝트 구조](#4-프로젝트-구조)
5. [데이터베이스](#5-데이터베이스)
6. [모듈별 상세 설명](#6-모듈별-상세-설명)
7. [공통 컴포넌트](#7-공통-컴포넌트)
8. [인터페이스](#8-인터페이스)
9. [에러 처리](#9-에러-처리)
10. [배포 가이드](#10-배포-가이드)

---

## 1. 시스템 개요

### 1.1 시스템 정의

| 항목 | 내용 |
|------|------|
| **시스템명** | HAENGSUNG HNSMES (제조실행시스템) |
| **버전** | 4.0 |
| **사용자** | 행성 CDB 공장 생산/품질/자재 담당자 |
| **목적** | 전자부품 제조 공정의 생산실적, 자재관리, 품질관리 통합관리 |

### 1.2 주요 기능

```
┌─────────────────────────────────────────────────────────────────┐
│                        HNSMES 시스템                            │
├─────────────┬─────────────┬─────────────┬─────────────┬─────────┤
│   자재관리   │   생산관리   │   품질관리   │   보전관리   │  리포트 │
│   (MAT)     │   (PRD)     │   (QC)      │   (MNT)     │  (RPT)  │
├─────────────┼─────────────┼─────────────┼─────────────┼─────────┤
│ • 입고관리   │ • 작업지시   │ • IQC검사   │ • 라인관리   │ • 생산일보│
│ • IQC검사   │ • 작업실적   │ • OQC검사   │ • 모니터링   │ • 재고현황│
│ • 재고관리   │ • 공정관리   │ • 불량관리   │ • 리포트     │ • 품질현황│
│ • 출고관리   │ • 현황조회   │ • A/S관리   │             │         │
└─────────────┴─────────────┴─────────────┴─────────────┴─────────┘
```

### 1.3 기술 스택

| 계층 | 기술 | 버전 |
|------|------|------|
| **OS** | Windows | 10/11, Server 2016+ |
| **Framework** | .NET Framework | 4.0 |
| **Language** | C# | 7.0 |
| **UI** | DevExpress WinForms | 13.2 |
| **DB** | Oracle | 11g/12c |
| **통신** | WCF (NetTcp) | - |
| **Report** | DevExpress XtraReport | 13.2 |

---

## 2. 아키텍처

### 2.1 전체 아키텍처

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                              CLIENT LAYER                                    │
│  ┌─────────────────────────────────────────────────────────────────────┐   │
│  │  WinForms Application (.NET 4.0)                                    │   │
│  │  • HAENGSUNG_HNSMES_UI.exe (ClickOnce 배포)                        │   │
│  │  • DevExpress 13.2 Controls                                         │   │
│  │  • WCF Client / WebService Client                                   │   │
│  └─────────────────────────────────────────────────────────────────────┘   │
└─────────────────────────────────────────────────────────────────────────────┘
                                      │
                                      │ HTTP / TCP
                                      ▼
┌─────────────────────────────────────────────────────────────────────────────┐
│                           MIDDLEWARE LAYER                                   │
│                                                                              │
│  ┌─────────────────────┐        ┌─────────────────────┐                     │
│  │   WCF Server        │        │   WebService        │                     │
│  │   (NetTcp:8101)     │        │   (HTTP:8807)       │                     │
│  │   • GZip Compression│        │   • SOAP            │                     │
│  │   • Triple DES Enc  │        │   • XML             │                     │
│  └──────────┬──────────┘        └──────────┬──────────┘                     │
│             │                              │                                 │
│             └──────────────┬───────────────┘                                 │
│                            │                                                │
│                            ▼                                                │
│              ┌─────────────────────────┐                                    │
│              │    Business Logic       │                                    │
│              │    • Transaction Mgmt   │                                    │
│              │    • Data Validation    │                                    │
│              └───────────┬─────────────┘                                    │
└──────────────────────────┼──────────────────────────────────────────────────┘
                           │
                           │ Oracle ODP.NET
                           ▼
┌─────────────────────────────────────────────────────────────────────────────┐
│                            DATABASE LAYER                                    │
│                                                                              │
│  ┌─────────────────────────────────────────────────────────────────────┐   │
│  │  Oracle Database (10.2.30.7:1522)                                   │   │
│  │  • Service: CDBHNSMES                                              │   │
│  │  • Schema: MESUSER                                                 │   │
│  │  • Packages: 31개                                                  │   │
│  │  • Tables: 125개                                                   │   │
│  └─────────────────────────────────────────────────────────────────────┘   │
└─────────────────────────────────────────────────────────────────────────────┘
```

### 2.2 어플리케이션 아키텍처

```
┌─────────────────────────────────────────────────────────────────┐
│                     Presentation Layer                          │
│  ┌─────────────┐  ┌─────────────┐  ┌─────────────────────────┐ │
│  │   Forms     │  │  UserCtrl   │  │      Reports           │ │
│  │  (*.cs)     │  │  (*.cs)     │  │     (*.repx)           │ │
│  │             │  │             │  │                        │ │
│  │ PRDA201     │  │ XUCTileMenu │  │ RPTA201 (라벨)         │ │
│  │ MATA201     │  │ XucFromTo   │  │ RPTA202 (리포트)       │ │
│  │ ...         │  │ ...         │  │ ...                    │ │
│  └──────┬──────┘  └──────┬──────┘  └───────────┬─────────────┘ │
│         │                │                      │               │
│         └────────────────┴──────────────────────┘               │
│                          │                                      │
│              ┌───────────▼───────────┐                         │
│              │   Base.Form (상속)     │                         │
│              │   itfButton (인터페이스)│                         │
│              └───────────────────────┘                         │
└─────────────────────────────────────────────────────────────────┘
                              │
┌─────────────────────────────▼───────────────────────────────────┐
│                      Business Layer                             │
│  ┌─────────────────────────────────────────────────────────────┐│
│  │              IDatabaseProcess (Interface)                    ││
│  │  ┌────────────────┐  ┌────────────────┐  ┌──────────────┐  ││
│  │  │WCFDatabaseProc │  │WSDatabaseProc  │  │DirectCon     │  ││
│  │  │(TCP)           │  │(HTTP)          │  │(Oracle Direct)│  ││
│  │  └───────┬────────┘  └───────┬────────┘  └──────┬───────┘  ││
│  │          │                   │                  │          ││
│  │          └───────────────────┴──────────────────┘          ││
│  │                              │                             ││
│  │          ┌───────────────────▼───────────────────┐         ││
│  │          │        WebService.Access              │         ││
│  │          │  WCFServiceProcess | WebServiceProcess│         ││
│  │          └───────────────────────────────────────┘         ││
│  └─────────────────────────────────────────────────────────────┘│
└─────────────────────────────────────────────────────────────────┘
```

---

## 3. 개발 환경

### 3.1 개발 도구

| 도구 | 버전 | 용도 |
|------|------|------|
| Visual Studio | 2019 (v16) | IDE |
| .NET Framework | 4.0 | Runtime |
| DevExpress | 13.2.5 | UI 컴포넌트 |
| Oracle Client | 11g | DB 연결 |
| Git | Latest | 버전관리 |

### 3.2 프로젝트 설정

```xml
<!-- 핵심 프로젝트 속성 -->
<PropertyGroup>
  <TargetFrameworkVersion>v4.0</TargetFrameworkVersion>
  <PlatformTarget>x86</PlatformTarget>
  <OutputType>WinExe</OutputType>
  <AssemblyName>HAENGSUNG_HNSMES_UI</AssemblyName>
</PropertyGroup>

<!-- 주요 참조 -->
<Reference Include="DevExpress.XtraEditors.v13.2" />
<Reference Include="DevExpress.XtraGrid.v13.2" />
<Reference Include="DevExpress.XtraReports.v13.2" />
<Reference Include="Oracle.DataAccess" />
```

### 3.3 필수 패키지

```
DLL/
├── DevExpress/
│   ├── DevExpress.Utils.v13.2.dll
│   ├── DevExpress.XtraEditors.v13.2.dll
│   ├── DevExpress.XtraGrid.v13.2.dll
│   ├── DevExpress.XtraLayout.v13.2.dll
│   └── DevExpress.XtraReports.v13.2.dll
├── Oracle/
│   └── Oracle.DataAccess.dll
└── IDAT/
    └── IDAT.Framework.dll
```

---

## 4. 프로젝트 구조

### 4.1 디렉토리 구조

```
HAENGSUNG_HNSMES_UI/
│
├── Base.Class/                    # 공통 클래스
│   ├── 1.Controls/               # 커스텀 컨트롤
│   │   ├── Controls.cs
│   │   ├── Data.cs
│   │   ├── iDATControlBinding.cs
│   │   ├── iDATMainMenu.cs
│   │   ├── iDATMessageBox.cs
│   │   └── itfButton.cs
│   ├── 3.Hardware/               # 하드웨어 연동
│   │   ├── clsLPT.cs
│   │   ├── clsPrintBarcode.cs
│   │   ├── itfScanner.cs
│   │   ├── ScannerProcess.cs
│   │   └── SocketClient.cs
│   ├── 4.Extension/              # 확장 메서드
│   │   └── ExtensionMethod.cs
│   ├── 5.ActiveDemo/
│   │   └── ActiveDemoBusiness.cs
│   ├── WCF/                      # WCF 관련
│   │   ├── DatabaseService.cs
│   │   ├── DatabaseServiceClientHelper.cs
│   │   ├── GZipMessageEncoderFactory.cs
│   │   ├── SecurityTripleDES.cs
│   │   ├── ServiceSettings.cs
│   │   └── WCFClient.cs
│   ├── CustPlan.cs
│   ├── DirectCon.cs              # Oracle 직접연결
│   ├── DXGridHelper.cs           # 그리드 헬퍼
│   ├── DXGridLookUpHelper.cs
│   ├── ExcelHelper.cs
│   ├── FTPHepler.cs
│   ├── LanguageInformation.cs    # 다국어
│   ├── LogHelper.cs
│   ├── LogUtility.cs
│   ├── SharedAPI.cs
│   └── WorkPlan.cs
│
├── Forms/                         # 화면 폴더
│   ├── Base/                     # 기본 폼
│   │   ├── Form.cs
│   │   └── UserControl.cs
│   ├── COM/                      # 공통
│   │   ├── COMLOGIN.cs
│   │   ├── COMREGISTER.cs
│   │   ├── COMSYSTEMSETTING.cs
│   │   └── ...
│   ├── MAT/                      # 자재관리
│   │   ├── MATA201.cs (IQC검사)
│   │   ├── MATA202.cs (라벨발행)
│   │   ├── MATA203.cs (입고)
│   │   └── ...
│   ├── MST/                      # 기준정보
│   │   ├── MSTA201.cs (공장)
│   │   ├── MSTA205.cs (품목)
│   │   └── ...
│   ├── MNT/                      # 보전관리
│   ├── PRD/                      # 생산관리
│   ├── RPT/                      # 리포트
│   ├── SAL/                      # 영업관리
│   ├── SYS/                      # 시스템
│   └── OSC/                      # 모니터링
│
├── Global/                        # 전역 설정
│   ├── Global_Variable01.cs      # 전역변수
│   └── GlobalFunction.cs         # 전역함수
│
├── UserControl/                   # 사용자 정의 컨트롤
│   └── ...
│
├── WebService.Access/            # 서비스 접근 계층
│   ├── WCFServiceProcess.cs
│   ├── WebServiceProcess.cs
│   └── WSResults.cs
│
├── WebService.Business/          # 서비스 비즈니스 계층
│   ├── IDatabaseProcess.cs
│   ├── WCFDatabaseProcess.cs
│   └── WSDatabaseProcess.cs
│
└── MainForm.cs                   # 메인 폼
```

### 4.2 파일 네이밍 규칙

```
폼:         [모듈][타입][번호].cs
           예: PRDA201.cs, MATA201.cs

컨트롤:     [접두사][기능].cs
           예: XucFromToDate.cs, XUCTileMenu.cs

리포트:     RPT[타입][번호].cs
           예: RPTA201.cs

팝업:       POP_[모듈][번호].cs
           예: POP_PRD01.cs, POP_MAT01.cs
```

---

## 5. 데이터베이스

### 5.1 연결 정보

```yaml
Primary DB (ESSDB):
  Host: 10.2.30.7
  Port: 1522
  Service: CDBHNSMES
  User: MESUSER
  
WCF Server:
  Address: net.tcp://10.2.31.9:8101/NGS.DatabaseService
  
WebService:
  URL: http://218.158.2.71:8807/IDISYS_2012/IDAT_WebSvr.asmx
```

### 5.2 테이블 정의

#### 5.2.1 마스터 테이블 (TM_*)

| 테이블명 | 설명 | 주요 컬럼 | 레코드수 |
|----------|------|-----------|----------|
| TM_USER | 사용자마스터 | USER_ID, USERNAME, PASSWORD, DEPTCODE, USEFLAG | 88 |
| TM_ITEMS | 품목마스터 | ITEMCODE, ITEMNAME, SPEC, UNITCODE, ITEMTYPE | 1,315 |
| TM_BOM | BOM | ITEMCODE, COMP_ITEMCODE, QTY, LEVEL | 9,206 |
| TM_SERIAL | 시리얼마스터 | SERIALNO, ITEMCODE, PRODDATE, STATUS | 1,868,570 |
| TM_VENDOR | 거래처 | VENDORCODE, VENDORNAME, INCOMETYPE | 5 |
| TM_WAREHOUSE | 창고 | WHCODE, WHNAME, WH_TYPE | 6 |
| TM_LOCATION | 로케이션 | LOCCODE, LOCNAME, WHCODE | 10 |
| TM_PRODLINE | 생산라인 | LINECODE, LINENAME, PLANT | 10 |
| TM_MENU | 메뉴 | MENUID, MENUNAME, PARENTID, FORMID, SORTSEQ | 134 |

#### 5.2.2 트랜잭션 테이블 (TW_*, TH_*)

| 테이블명 | 설명 | 주요 컬럼 | 레코드수 |
|----------|------|-----------|----------|
| TW_IN | 입고이력 | INDATE, INNO, SERIALNO, ITEMCODE, QTY, VENDOR | 1,750,960 |
| TW_OUT | 출고이력 | OUTDATE, OUTNO, SERIALNO, ITEMCODE, QTY, OUTTYPE | 9,271,825 |
| TW_PRODHIST | 생산이력 | WORKDATE, WORKORD, SERIALNO, ITEMCODE, QTY_GOOD | 6,354,665 |
| TH_STOCKSERIAL | 현재고 | SERIALNO, ITEMCODE, QTY, WHCODE, LOCCODE | 18,127,046 |
| TW_IQC | IQC검사이력 | IQCDATE, IQCNO, LOTNO, ITEMCODE, JUDGE | 3,639 |
| TW_OQC | OQC검사이력 | OQCDATE, OQCNO, SERIALNO, ITEMCODE | 59,396 |

### 5.3 패키지 목록

| 패키지명 | 설명 | 주요 기능 |
|----------|------|-----------|
| PKGBAS_BASE | 기준정보 기본 | 품목, 거래처, 창고, 로케이션 CRUD |
| PKGBAS_MAT | 자재 기준 | 자재마스터, 재고관리 |
| PKGBAS_BRD | 불량 기준 | 불량유형, 검사기준 |
| PKGMAT_INOUT | 자재 입출고 | 입고, 출고, IQC, 재고조정 |
| PKGPRD_PROD | 생산관리 | 작업실적, 공정이동, 현황 |
| PKGPRD_QC | 품질관리 | IQC, OQC, 불량관리 |
| PKGPRD_HIST | 생산이력 | 이력조회, 추적 |
| PKGPRD_MNT | 보전관리 | SMT 라인, 모니터링 |
| PKGSYS_USER | 사용자관리 | 사용자, 권한, 부서 |
| PKGSYS_MENU | 메뉴관리 | 메뉴, 권한매핑 |
| PKGSYS_COMM | 공통코드 | 코드관리, 공지사항 |
| PKGTXN_STOCK | 재고관리 | 재고계산, 실사 |
| PKGHNS_REPORT | 행성리포트 | 커스텀 리포트 |
| PKGPDA_* | PDA 연동 | 모바일 입출고 |

### 5.4 프로시저 명명 규칙

```sql
-- 패턴: PKG<모듈>_<엔티티>.<동작>[_<대상>]

-- 조회
PKG<모듈>_<엔티티>.GET_<대상>
예: PKGBAS_BASE.GET_ITEM, PKGMAT_INOUT.GET_IQC_LIST

-- 저장
PKG<모듈>_<엔티티>.SET_<대상>
예: PKGMAT_INOUT.SET_IQC_JUDGE

-- 등록/수정
PKG<모듈>_<엔티티>.PUT_<대상>
예: PKGBAS_BASE.PUT_ITEM

-- 삭제
PKG<모듈>_<엔티티>.DEL_<대상>
예: PKGSYS_MENU.DEL_MENU

-- 체크
PKG<모듈>_<엔티티>.CHK_<대상>
예: PKGPDA_MAT.CHK_VENDORPARTNO
```

---

## 6. 모듈별 상세 설명

### 6.1 자재관리 (MAT)

#### 6.1.1 화면 목록

| 화면ID | 화멪명 | 주요 기능 | 호출 프로시저 |
|--------|--------|-----------|---------------|
| MATA201 | IQC검사등록 | 수입검사 및 판정 | PKGMAT_INOUT.GET_IQC_SERIAL, SET_IQC_JUDGE |
| MATA202 | 라벨발행 | 시리얼 생성 및 라벨발행 | PKGMAT_INOUT.GET_LABEL_ORDER, SET_NEW_CREATESN |
| MATA203 | 자재입고 | PDA 연동 입고처리 | PKGPDA_MAT.SET_RECEIVE, SET_IQCRECEIVE |
| MATA204 | 자재불출요청 | 생산투입 요청 | PKGMAT_INOUT.GET_PRODMATERIALREQUEST |
| MATA205 | 불량판정 | 불량 자재 처리 | PKGBAS_BRD.SET_BADREG_JUDGE |
| MATA206 | 창고이동 | 로케이션 이동 | PKGPDA_MAT.SET_RELEASE |
| MATA207 | 재고조정 | 재고 수량 조정 | PKGPDA_MAT.SET_STOCKCORRECT |
| MATA208 | 실사등록 | 재고실사 | PKGTXN_STOCK.PUT_ACTUAL_UPLOAD |
| MATA209 | 생산불출 | 생산투입 처리 | PKGPDA_MAT.SET_RELEASE |
| MATA210 | 대체품등록 | 대체품 처리 | PKGPDA_MAT.SET_REPLACEITEM |
| MATB201~214 | 현황/리포트 | 각종 조회 | PKGBAS_MAT.*, PKGHNS_REPORT.* |

#### 6.1.2 데이터 흐름

```
[입고 프로세스]
수주/발주 ──▶ 입고접수(MATA203) ──▶ IQC검사(MATA201) ──▶ 라벨발행(MATA202) ──▶ 입고완료
                                              │
                                              ▼
                                        [불합격시]
                                              │
                                              ▼
                                        반품/선별처리

[출고 프로세스]
작업지시 ──▶ 자재불출요청(MATA204) ──▶ 출고처리(MATA209) ──▶ 생산투입
```

### 6.2 생산관리 (PRD)

#### 6.2.1 화면 목록

| 화면ID | 화멪명 | 주요 기능 | 호출 프로시저 |
|--------|--------|-----------|---------------|
| PRDA201 | 작업실적등록 | 공정별 실적 등록 | PKGPRD_PROD.SET_WORK_RESULT |
| PRDA202 | 작업지시관리 | 작업지시 생성/조회 | PKGPRD_PROD.GET_WORKORDER |
| PRDA203~222 | 생산현황 | 각종 현황 조회 | PKGPRD_CURRENT.* |
| PRDB201~208 | 리포트 | 생산리포트 | PKGPRD_REPORT.* |

#### 6.2.2 데이터 흐름

```
[생산실적 프로세스]
작업지시 생성 ──▶ PRDA202 ──▶ 작업지시 승인 ──▶ 생산투입(MATA209)
                                              │
                                              ▼
작업실적 등록 ◀── PRDA201 ◀── 바코드스캔 ◀── 공정작업
    │
    ├──▶ 양품실적 ──▶ TW_PRODHIST INSERT
    │
    ├──▶ 불량실적 ──▶ TW_BRD INSERT
    │
    └──▶ 자재차감 ──▶ TW_OUT INSERT
```

### 6.3 기준정보 (MST)

#### 6.3.1 화면 목록

| 화면ID | 화멪명 | 주요 기능 | 호출 프로시저 |
|--------|--------|-----------|---------------|
| MSTA201 | 공장등록 | 공장 기준정보 | PKGBAS_BASE.PUT_PLANT |
| MSTA202 | 거래처등록 | 거래처 관리 | PKGBAS_BASE.PUT_VENDOR |
| MSTA203 | 공정등록 | 공정 기준정보 | PKGBAS_BASE.PUT_OPER |
| MSTA205 | 품목등록 | 품목 마스터 | PKGBAS_BASE.PUT_ITEM |
| MSTA206 | BOM등록 | BOM 관리 | PKGBAS_BASE.PUT_BOM |
| MSTA209 | 라인등록 | 생산라인 관리 | PKGBAS_BASE.PUT_LINE |
| MSTA210 | 창고등록 | 창고/로케이션 | PKGBAS_BASE.PUT_LOCATION |

### 6.4 시스템관리 (SYS)

#### 6.4.1 화면 목록

| 화면ID | 화멪명 | 주요 기능 | 호출 프로시저 |
|--------|--------|-----------|---------------|
| SYSA201 | 용어사전 | 다국어 관리 | PKGSYS_COMM.PUT_GLOSSARY |
| SYSA203 | 공통코드 | 코드 관리 | PKGSYS_COMM.PUT_COMM |
| SYSA204 | 화면관리 | 폼 관리 | PKGSYS_MENU.PUT_FORMMST |
| SYSA205 | 메뉴관리 | 메뉴 구성 | PKGSYS_MENU.PUT_MENU |
| SYSA206 | 권한그룹 | 역할 관리 | PKGSYS_USER.PUT_ROLE |
| SYSA207 | 메뉴권한 | 권한 매핑 | PKGSYS_MENU.PUT_MENUROLE |
| SYSA211 | 사원등록 | 사용자 관리 | PKGSYS_USER.PUT_EHR |
| COMLOGIN | 로그인 | 인증 | PKGSYS_USER.CHK_USER |

---

## 7. 공통 컴포넌트

### 7.1 Base.Form

```csharp
public partial class Form : XtraForm
{
    // 폼 상태 관리
    protected FORM_TYPE FormType { get; set; }
    protected UPDATEITEMTYPE CurrentDataTYPE { get; set; }
    
    // 버튼 상태 제어
    public bool ShowNewbutton { get; set; }
    public bool ShowSaveButton { get; set; }
    public bool ShowDeleteButton { get; set; }
    public bool ShowSearchButton { get; set; }
    
    // 공통 이벤트
    public event IDAT_UpdateItemsEditChanged IDAT_UpdateItemsEditChangedEvent;
}
```

### 7.2 DXGridHelper

```csharp
public class BASE_DXGridHelper
{
    // 그리드 바인딩
    public static void Bind_Grid(...)
    
    // 그리드 설정
    public static void SetGridViewOption(...)
    
    // 컬럼 설정
    public static void SetColumn(...)
    
    // 서머리 설정
    public static void SetSummary(...)
}
```

### 7.3 데이터 접근

```csharp
// WCF 사용 예시
IDatabaseProcess db = new WCFDatabaseProcess();
WSResults result = db.Execute_Proc(
    "PKGPRD_PROD.GET_WORKORDER",
    1,
    new string[] { "A_CLIENT", "A_PLANT", "A_WORKDATE" },
    new object[] { CLIENT, PLANT, DateTime.Now.ToString("yyyyMMdd") }
);

if (result.ResultInt == 0)
{
    DataTable dt = result.ResultDataSet.Tables[0];
}
```

---

## 8. 인터페이스

### 8.1 WCF 인터페이스

```csharp
[ServiceContract]
public interface IDatabaseService
{
    [OperationContract]
    clsDataSetStruct ExecuteProcCls(string ProcName, ArrayList aryName, ArrayList aryValue);
    
    [OperationContract]
    clsDataSetStruct ExecuteQry(string strQry);
    
    [OperationContract]
    string ExecuteFunc(string ProcName, ArrayList aryName, ArrayList aryValue);
    
    [OperationContract]
    clsDataSetStruct ExecuteProcBatchDS(DataSet ds);
}
```

### 8.2 ERP 연계

```
방식: DB Link
패키지: PKGIF_ERP
주기: 실시간/배치
데이터: 수주, 발주, 입고, 출고, 품목마스터
```

### 8.3 PDA 연계

```
방식: WCF
패키지: PKGPDA_*
통신: WiFi (TCP)
기능: 입고, 출고, 재고조회, 생산실적
```

---

## 9. 에러 처리

### 9.1 예외 처리 패턴

```csharp
try
{
    WSResults result = BASE_db.Execute_Proc(...);
    if (result.ResultInt == 0)
    {
        // 성공 처리
    }
    else
    {
        // DB 오류 처리
        iDATMessageBox.ERRORMessage(result.ResultString);
    }
}
catch (InvalidOperationException ex)
{
    // WCF 연결 오류
    LogHelper.WriteLog(ex.Message);
}
catch (Exception ex)
{
    // 기타 오류
    LogHelper.WriteLog(ex.Message);
}
```

### 9.2 로깅

```csharp
// 로그 파일 위치
// C:\Logs\MES\YYYYMMDD.txt

// 사용법
LogHelper.WriteLog("메시지");
LogHelper.WriteLog("에러", ex);
```

---

## 10. 배포 가이드

### 10.1 ClickOnce 배포

```
1. 빌드
   - Release 모드로 빌드
   - 버전 업데이트 (AssemblyInfo.cs)

2. Publish
   - Visual Studio: Publish 탭
   - Publish Location: \\server\MES_Publish\
   - Installation Folder URL: http://.../

3. 업데이트
   - 클라이언트 자동 업데이트
   - 또는 setup.exe 재실행
```

### 10.2 환경 설정

```xml
<!-- app.config -->
<appSettings>
  <add key="WS_Address" value="net.tcp://10.2.31.9:8101/NGS.DatabaseService" />
  <add key="DB_IP" value="10.2.30.7" />
  <add key="DB_Port" value="1522" />
</appSettings>
```

---

## 부록

### A. 화면-DB 매핑표
[별첨: Excel 파일 참조]

### B. 프로시저 상세 명세
[별첨: 별도 문서 참조]

### C. 테이블 정의서
[별첨: 별도 문서 참조]

---

**문서 작성 완료**
