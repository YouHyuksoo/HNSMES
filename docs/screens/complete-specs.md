# 전체 화면 상세 명세서

**총 화면 수**: 189개  
**작성 기준**: 2026-02-07

---

## 목차
1. [공통 (COM)](#1-com)
2. [자재관리 (MAT)](#2-mat)
3. [기준정보 (MST)](#3-mst)
4. [보전관리 (MNT)](#4-mnt)
5. [생산관리 (PRD)](#5-prd)
6. [리포트 (RPT)](#6-rpt)
7. [영업관리 (SAL)](#7-sal)
8. [시스템 (SYS)](#8-sys)
9. [모니터링 (OSC)](#9-osc)
10. [샘플 (SAMPLE)](#10-sample)

---

## 1. 공통 (COM)

### 1.1 COMLOGIN (로그인)
| 항목 | 내용 |
|------|------|
| **화면ID** | COMLOGIN |
| **화멪명** | 로그인 |
| **파일** | Forms/COM/COMLOGIN.cs |
| **메뉴경로** | 시스템 실행 시 첫 화면 |
| **설명** | 사용자 인증 및 시스템 접속 |
| **주요기능** | 1. 사용자ID/비밀번호 입력<br>2. 권한 체크<br>3. 공장/사업장 선택<br>4. 자동로그인 설정 |
| **입력항목** | txtId(사용자ID), txtPassword(비밀번호), grdLookPlant(공장) |
| **호출프로시저** | PKGSYS_USER.CHK_USER, PKGBAS_BASE.GET_PLANT, PKG_USER.GET_USERMASTER |
| **비즈니스로직** | 1. 비밀번호 복호화 확인<br>2. Global_Variable에 세션 저장<br>3. 메뉴권한 조회<br>4. 메인폼 로드 |
| **이벤트** | btnLogin_Click, txtPassword_KeyDown |

### 1.2 COMREGISTER (사용자등록)
| 항목 | 내용 |
|------|------|
| **화면ID** | COMREGISTER |
| **화멪명** | 사용자등록 |
| **파일** | Forms/COM/COMREGISTER.cs |
| **메뉴경로** | 공통 > 사용자등록 |
| **설명** | 신규 사용자 등록 및 비밀번호 설정 |
| **주요기능** | 1. 사용자정보 입력<br>2. 비밀번호 설정<br>3. 부서/직급 선택 |
| **호출프로시저** | PKG_USER.SET_USERMASTER, PKG_USER.GET_USERMASTER, PKG_USER.GET_USERCLASS2 |

### 1.3 COMREGISTER_NEW (사용자등록_신규)
| 항목 | 내용 |
|------|------|
| **화면ID** | COMREGISTER_NEW |
| **화멪명** | 사용자등록(신규) |
| **파일** | Forms/COM/COMREGISTER_NEW.cs |
| **설명** | 행성전용 사용자 등록 프로세스 |
| **주요기능** | 1. 사원정보 조회<br>2. 권한그룹 설정<br>3. 메뉴권한 자동부여 |
| **호출프로시저** | PKGSYS_USER.GET_REGUSER, PKGSYS_USER.GET_DEPT, PKGSYS_USER.GET_POST, PKGSYS_USER.PUT_REGUSER |

### 1.4 COMPWDCHANGE (비밀번호변경)
| 항목 | 내용 |
|------|------|
| **화면ID** | COMPWDCHANGE |
| **화멪명** | 비밀번호변경 |
| **파일** | Forms/COM/COMPWDCHANGE.cs |
| **메뉴경로** | 공통 > 비밀번호변경 |
| **설명** | 사용자 비밀번호 변경 |
| **주요기능** | 1. 현재비밀번호 확인<br>2. 신규비밀번호 설정<br>3. 비밀번호 암호화 저장 |
| **호출프로시저** | PKGSYS_USER.CHK_USER, PKGSYS_USER.PUT_DEFAULTPWD |

### 1.5 COMFAVORITES (즐겨찾기)
| 항목 | 내용 |
|------|------|
| **화면ID** | COMFAVORITES |
| **화멪명** | 즐겨찾기관리 |
| **파일** | Forms/COM/COMFAVORITES.cs |
| **메뉴경로** | 메인 > 즐겨찾기 |
| **설명** | 사용자별 자주 사용하는 메뉴 등록 |
| **주요기능** | 1. 메뉴검색<br>2. 즐겨찾기 등록/삭제<br>3. 순서변경 |
| **호출프로시저** | PKGSYS_MENU.GET_MENU, PKGSYS_USER.PUT_FAVRT, PKGSYS_USER.GET_FAVRT |

### 1.6 COMCLOSING (마감관리)
| 항목 | 내용 |
|------|------|
| **화면ID** | COMCLOSING |
| **화멪명** | 마감관리 |
| **파일** | Forms/COM/COMCLOSING.cs |
| **메뉴경로** | 공통 > 마감관리 |
| **설명** | 월별/일별 마감 처리 |
| **주요기능** | 1. 마감일자 조회<br>2. 마감처리<br>3. 마감취소 |
| **호출프로시저** | PKGSYS_COMM.GET_CLOSING, PKGSYS_COMM.PUT_CLOSING |

### 1.7 COMSYSTEMSETTING (시스템설정)
| 항목 | 내용 |
|------|------|
| **화면ID** | COMSYSTEMSETTING |
| **화멪명** | 시스템설정 |
| **파일** | Forms/COM/COMSYSTEMSETTING.cs |
| **메뉴경로** | 공통 > 시스템설정 |
| **설명** | 시스템 환경 설정 관리 |
| **주요기능** | 1. 서버설정<br>2. 프린터설정<br>3. 기본값설정 |

### 1.8 COMSYSTEMHISTORY (시스템사용이력)
| 항목 | 내용 |
|------|------|
| **화면ID** | COMSYSTEMHISTORY |
| **화멪명** | 시스템사용이력 |
| **파일** | Forms/COM/COMSYSTEMHISTORY.cs |
| **메뉴경로** | 공통 > 시스템이력 |
| **설명** | 사용자별 시스템 사용 이력 조회 |
| **호출프로시저** | PKG_BASE.GET_SYSTEMUSEHISTORY, PKG_BASE.GET_LOGMESSAGE |

### 1.9 COMBARPRINTSETTING (바코드프린터설정)
| 항목 | 내용 |
|------|------|
| **화면ID** | COMBARPRINTSETTING |
| **화멪명** | 바코드프린터설정 |
| **파일** | Forms/COM/COMBARPRINTSETTING.cs |
| **메뉴경로** | 공통 > 프린터설정 |
| **설명** | 바코드 프린터 포트 및 설정 관리 |
| **주요기능** | 1. COM포트 설정<br>2. 프린터 테스트<br>3. 라벨포맷 설정 |

### 1.10 COMSCANNERSETTING (스캐너설정)
| 항목 | 내용 |
|------|------|
| **화면ID** | COMSCANNERSETTING |
| **화멪명** | 스캐너설정 |
| **파일** | Forms/COM/COMSCANNERSETTING.cs |
| **메뉴경로** | 공통 > 스캐너설정 |
| **설명** | 바코드 스캐너 설정 |
| **주요기능** | 1. 스캐너 포트설정<br>2. 프리픽스/서픽스 설정 |

### 1.11 COMGRIDDEGINE (그리드설정)
| 항목 | 내용 |
|------|------|
| **화면ID** | COMGRIDDEGINE |
| **화멪명** | 그리드설정 |
| **파일** | Forms/COM/COMGRIDDEGINE.cs |
| **설명** | 그리드 컬럼 및 표시 설정 |

### 1.12 COMPREVIEW (미리보기)
| 항목 | 내용 |
|------|------|
| **화면ID** | COMPREVIEW |
| **화멪명** | 미리보기 |
| **파일** | Forms/COM/COMPREVIEW.cs |
| **설명** | 리포트 미리보기 공통 폼 |

### 1.13 COMPROGRESS (진행상태)
| 항목 | 내용 |
|------|------|
| **화면ID** | COMPROGRESS |
| **화멪명** | 진행상태 |
| **파일** | Forms/COM/COMPROGRESS.cs |
| **설명** | 장시간 작업 진행상태 표시 |

### 1.14 COMPROGRESS_v2 (진행상태_v2)
| 항목 | 내용 |
|------|------|
| **화면ID** | COMPROGRESS_v2 |
| **화멪명** | 진행상태(개선) |
| **파일** | Forms/COM/COMPROGRESS_v2.cs |

### 1.15 COMSPLASHSCREEN (스플래시)
| 항목 | 내용 |
|------|------|
| **화면ID** | COMSPLASHSCREEN |
| **화멪명** | 스플래시화면 |
| **파일** | Forms/COM/COMSPLASHSCREEN.cs |
| **설명** | 프로그램 실행 시 로딩 화면 |

### 1.16 COMWAITFORM (대기화면)
| 항목 | 내용 |
|------|------|
| **화면ID** | COMWAITFORM |
| **화멪명** | 대기화면 |
| **파일** | Forms/COM/COMWAITFORM.cs |
| **설명** | 처리 대기 중 표시 |

### 1.17 COMHELP (도움말)
| 항목 | 내용 |
|------|------|
| **화면ID** | COMHELP |
| **화멪명** | 도움말 |
| **파일** | Forms/COM/COMHELP.cs |

### 1.18 Password (비밀번호입력)
| 항목 | 내용 |
|------|------|
| **화면ID** | Password |
| **화멪명** | 비밀번호입력 |
| **파일** | Forms/COM/Password.cs |
| **설명** | 민감작업 시 비밀번호 재확인 |

---

## 2. 자재관리 (MAT)

### 2.1 MATA201 (IQC검사등록)
| 항목 | 내용 |
|------|------|
| **화면ID** | MATA201 |
| **화멪명** | IQC검사등록 |
| **파일** | Forms/MAT/MATA201.cs |
| **메뉴경로** | 자재관리 > IQC검사 > IQC검사등록 |
| **설명** | 수입검사 등록 및 판정 |
| **주요기능** | 1. 입고대상 조회<br>2. 검사결과 입력<br>3. 합격/불합격 판정<br>4. 불량처리 |
| **입력항목** | LOT번호, 품목코드, 검사수량, 합격수량, 불량수량, 불량코드, 판정 |
| **출력항목** | IQC검사목록, 검사이력 |
| **호출프로시저** | PKGMAT_INOUT.GET_IQC_SERIAL, PKGMAT_INOUT.GET_ORDER, PKGMAT_INOUT.GET_IQC_LIST, PKGMAT_INOUT.SET_IQC_JUDGE, PKGMAT_INOUT.SET_IQC_CANCEL |
| **비즈니스로직** | 1. 입고대상 조회(TW_IN)<br>2. IQC결과 저장(TW_IQC)<br>3. 합격시 재고이동(정상창고)<br>4. 불합격시 품질보류창고 이동<br>5. 합격판정시 라벨발행 가능 |
| **이벤트** | SearchButton_Click, SaveButton_Click, PrintButton_Click |

### 2.2 MATA202 (라벨발행)
| 항목 | 내용 |
|------|------|
| **화면ID** | MATA202 |
| **화멪명** | 라벨발행 |
| **파일** | Forms/MAT/MATA202.cs |
| **메뉴경로** | 자재관리 > 입고관리 > 라벨발행 |
| **설명** | 입고 완료된 품목의 시리얼 라벨 발행 |
| **주요기능** | 1. 발행대상 조회<br>2. 발행수량 설정<br>3. 시리얼 생성<br>4. 바코드 라벨 프린트 |
| **입력항목** | IQC일자, IQC번호, 품목코드, 발행수량 |
| **호출프로시저** | PKGMAT_INOUT.GET_IQC_LIST, PKGPDA_COMM.GET_LOC, PKGBAS_BASE.GET_LOCATION2, PKGBAS_BASE.GET_PARTNO, PKGBAS_BASE.GET_VENDOR, PKGMAT_INOUT.GET_RANK, PKGMAT_INOUT.GET_LABEL_ORDER, PKGMAT_INOUT.GET_REELQTYSPLIT, PKGMAT_INOUT.SET_REPRINT, PKGMAT_INOUT.SET_SPLITMERGE, PKGMAT_INOUT.GET_SNINFO, PKGMAT_INOUT.SET_NEW_CREATESN, PKGMAT_INOUT.SET_REELSPLIT, PKGMAT_INOUT.SET_TAPING |
| **비즈니스로직** | 1. IQC합격된 입고건 조회<br>2. 시리얼 채번(TM_SERIAL INSERT)<br>3. 재고등록(TH_STOCKSERIAL INSERT)<br>4. 바코드 라벨 출력(프린터연동) |

### 2.3 MATA203 (자재입고)
| 항목 | 내용 |
|------|------|
| **화면ID** | MATA203 |
| **화멪명** | 자재입고(PDA) |
| **파일** | Forms/MAT/MATA203.cs |
| **메뉴경로** | 자재관리 > 입고관리 > 자재입고 |
| **설명** | PDA 연동 자재 입고 처리 |
| **주요기능** | 1. 바코드 스캔<br>2. 거래처/품번 체크<br>3. 입고처리 |
| **호출프로시저** | PKGPDA_COMM.GET_LOC, PKGMAT_INOUT.GET_PARTNO, PKGBAS_BASE.GET_VENDOR, PKGPDA_COMM.GET_BARCODETYPE, PKGPDA_MAT.GET_RECEIVE_SNINFO, PKGPDA_MAT.CHK_VENDORPARTNO, PKGMAT_INOUT.GET_IQC_LIST, PKGPDA_MAT.SET_RECEIVE, PKGPDA_MAT.SET_IQCRECEIVE, PKGPDA_MAT.SET_QTYRECEIVE, PKGMAT_INOUT.GET_LABEL_ORDER |
| **비즈니스로직** | 1. 바코드 스캔(거래처코드+품번)<br>2. 거래처/품번 일치여부 체크<br>3. 입고처리(TW_IN INSERT)<br>4. IQC대기 상태로 전환 |

### 2.4 MATA204 (자재불출요청)
| 항목 | 내용 |
|------|------|
| **화면ID** | MATA204 |
| **화멪명** | 자재불출요청 |
| **파일** | Forms/MAT/MATA204.cs |
| **메뉴경로** | 자재관리 > 출고관리 > 자재불출요청 |
| **설명** | 생산투입을 위한 자재 불출 요청 등록 |
| **주요기능** | 1. 작업지시 조회<br>2. 필요자재 계산<br>3. 불출요청 등록 |
| **호출프로시저** | PKGMAT_INOUT.SET_MATREQUESTNO, PKGMAT_INOUT.GET_PRODMATERIALLOCATION, PKGMAT_INOUT.GET_PRODMATERIALREQUEST, PKGMAT_INOUT.GET_PRODMATERIALDETAIL |
| **비즈니스로직** | 1. 작업지시 기반 필요자재 계산(BOM)<br>2. 재고가용량 체크<br>3. 불출요청 등록(TW_MATERIALREQUEST) |

### 2.5 MATA205 (불량판정)
| 항목 | 내용 |
|------|------|
| **화면ID** | MATA205 |
| **화멪명** | 불량판정 |
| **파일** | Forms/MAT/MATA205.cs |
| **메뉴경로** | 자재관리 > 품질관리 > 불량판정 |
| **주요기능** | 1. 재고조회<br>2. 불량등록<br>3. 판정처리 |
| **호출프로시저** | PKGBAS_BRD.SET_BADREG_JUDGE, PKGPDA_COMM.GET_BARCODETYPE, PKGBAS_BASE.GET_WAREHOUSE, PKGBAS_BASE.GET_LOCATION, PKGBAS_BRD.GET_BADREG_HISTINFO |

### 2.6 MATA206 (창고이동)
| 항목 | 내용 |
|------|------|
| **화면ID** | MATA206 |
| **화멪명** | 창고이동 |
| **파일** | Forms/MAT/MATA206.cs |
| **메뉴경로** | 자재관리 > 재고관리 > 창고이동 |
| **주요기능** | 1. 이동대상 스캔<br>2. 출발창고/도착창고 설정<br>3. 이동처리 |
| **호출프로시저** | PKGPDA_MAT.SET_RELEASE, PKGBAS_BASE.GET_WAREHOUSE, PKGPDA_COMM.GET_LOC, PKGBAS_BASE.GET_LOCATION, PKGBAS_MAT.GET_WAREHOUSE_NONE_STOCK |
| **비즈니스로직** | 1. 시리얼 스캔<br>2. 현재위치 확인<br>3. 이동처리(TH_STOCKSERIAL UPDATE)<br>4. 이력저장(TW_OUT/TW_IN) |

### 2.7 MATA207 (재고조정)
| 항목 | 내용 |
|------|------|
| **화면ID** | MATA207 |
| **화멪명** | 재고조정 |
| **파일** | Forms/MAT/MATA207.cs |
| **메뉴경로** | 자재관리 > 재고관리 > 재고조정 |
| **주요기능** | 1. 재고조회<br>2. 조정수량 입력<br>3. 조정처리 |
| **호출프로시저** | PKGPDA_COMM.GET_BARCODETYPE, PKGPDA_COMM.GET_WH, PKGPDA_MAT.GET_STOCK_SNINFO, PKGPDA_COMM.GET_LOC, PKGPDA_MAT.SET_STOCKCORRECT |
| **비즈니스로직** | 1. 시리얼 스캔<br>2. 현재고 확인<br>3. 조정수량 입력<br>4. 조정처리(재고조정이력) |

### 2.8 MATA208 (실사등록)
| 항목 | 내용 |
|------|------|
| **화면ID** | MATA208 |
| **화멪명** | 실사등록 |
| **파일** | Forms/MAT/MATA208.cs |
| **메뉴경로** | 자재관리 > 재고관리 > 실사등록 |
| **주요기능** | 1. 실사대상 조회<br>2. 실사수량 입력<br>3. 차이조정<br>4. 실사적용 |
| **호출프로시저** | PKGTXN_STOCK.SET_ACTUAL_DELETE, PKGTXN_STOCK.SET_ACTUAL_ALTER, PKGBAS_BASE.GET_ITEM, PKGBAS_BASE.GET_WAREHOUSE, PKGTXN_STOCK.GET_ACTUAL, PKGBAS_BASE.GET_LOCATION, PKGTXN_STOCK.PUT_ACTUAL_UPLOAD, PKGTXN_STOCK.SET_ACTUAL_DELETE_ALL, PKGTXN_STOCK.SET_ACTUAL_APPLY |
| **비즈니스로직** | 1. 실사대상 추출(재고기준)<br>2. 실사수량 입력(엑셀업로드/수동)<br>3. 차이분석(재고-실사)<br>4. 실사적용(재고조정) |

### 2.9 MATA209 (생산불출)
| 항목 | 내용 |
|------|------|
| **화면ID** | MATA209 |
| **화멪명** | 생산불출 |
| **파일** | Forms/MAT/MATA209.cs |
| **메뉴경로** | 자재관리 > 출고관리 > 생산불출 |
| **주요기능** | 1. 작업지시 조회<br>2. 자재불출 처리<br>3. 생산투입 |
| **호출프로시저** | PKGPDA_MAT.SET_RELEASE, PKGBAS_BASE.GET_WAREHOUSE, PKGPDA_COMM.GET_LOC, PKGBAS_BASE.GET_LOCATION, PKGBAS_MAT.GET_WAREHOUSE_STOCK |
| **비즈니스로직** | 1. 작업지시 선택<br>2. 필요자재 조회(BOM)<br>3. 재고차감(TW_OUT)<br>4. 생산투입이력(TW_PRODHIST_USE) |

### 2.10 MATA210 (대체품등록)
| 항목 | 내용 |
|------|------|
| **화면ID** | MATA210 |
| **화멪명** | 대체품등록 |
| **파일** | Forms/MAT/MATA210.cs |
| **메뉴경로** | 자재관리 > 기타 > 대체품등록 |
| **주요기능** | 1. 원품목/대체품목 설정<br>2. 대체처리 |
| **호출프로시저** | PKGPDA_COMM.GET_BARCODETYPE, PKGBAS_BASE.GET_WAREHOUSE, PKGBAS_BASE.GET_LOCATION, PKGPDA_MAT.GET_STOCK_SNINFO3, PKGBAS_BASE.GET_ITEM, PKGBAS_BASE.GET_LOCATION2, PKGMAT_INOUT.SET_NEW_CREATESN, PKGPDA_MAT.SET_REPLACEITEM |

### 2.11 MATB201 ~ MATB214 (자재현황/리포트)
| 화면ID | 화멪명 | 주요내용 | 호출프로시저 |
|--------|--------|----------|--------------|
| MATB201 | 입고현황 | 일별/월별 입고조회 | PKGBAS_MAT.GET_RECEIVE_LIST |
| MATB202 | 입출고현황 | 입출고 통합조회 | PKGBAS_MAT.GET_RECEIVE_RELEASE_LIST, PKGBAS_MAT.GET_SPLITMERGE_LIST |
| MATB203 | 재고현황 | 현재고 조회 | PKGBAS_MAT.GET_RECEIVE_RELEASE_LIST |
| MATB204 | 입출고취소 | 입출고 취소처리 | PKGBAS_MAT.SET_CANCEL_MATERIAL_IN_OUT_XML |
| MATB205 | 라벨재발행 | 라벨 재발행 | PKGBAS_MAT.GET_LABEL_LIST |
| MATB206 | 재고조회(회사별) | 회사별 재고현황 | PKGBAS_MAT.GET_MATERIAL_STOCK_INCOMPANY_A/B, PKGBAS_MAT.GET_MATERIAL_STOCK_OUTSOURCING |
| MATB207 | 자재수불부 | 수불부 조회 | PKGTXN_STOCK.GET_SUBUL |
| MATB208 | 불량자재조회 | 불량 재고조회 | PKGBAS_MAT.GET_BAD_MAT_LIST |
| MATB209 | OQC검사 | 출하검사 | PKGBAS_OQC.* |
| MATB210 | 자재실적현황 | 자재별 입출고실적 | PKGBAS_MAT.GET_MATERIAL_ACTUAL |
| MATB211 | 재고실사현황 | 실사결과 조회 | PKGHNS_REPORT.GET_ACTUALSTOCK |
| MATB212 | 반품이력조회 | 반품이력 | PKGBAS_BRD.GET_DEFECT_HISTORY3 |
| MATB213 | 장기재고현황 | 장기미입고재고 | PKGHNS_REPORT.GET_LONGSTOCK_LIST |
| MATB214 | 요청서출력 | 자재요청서 | PKGMAT_INOUT.GET_REQUESTPRINT |

### 2.12 POP_MAT01, POP_MAT02 (팝업)
| 화면ID | 화멪명 | 설명 |
|--------|--------|------|
| POP_MAT01 | 자재팝업 | 품목선택 팝업 |
| POP_MAT02 | 재고팝업 | 재고조회 팝업 | PKGPDA_MAT.GET_RELEASE_PARTINFO, PKGBAS_STOCK.GET_WAREHOUSE, PKGBAS_STOCK.GET_LOCATION, PKGPDA_MAT.GET_PARTSTOCK |

---

*[문서 계속: 다음 섹션에서는 MST, MNT, PRD, RPT, SAL, SYS, OSC, SAMPLE 모듈이 이어집니다]*


## 3. 기준정보 (MST)

### 3.1 MSTA201 (공장등록)
| 항목 | 내용 |
|------|------|
| **화면ID** | MSTA201 |
| **화멪명** | 공장등록 |
| **파일** | Forms/MST/MSTA201.cs |
| **메뉴경로** | 기준정보 > 공장/조직 > 공장등록 |
| **설명** | 공장(Plant) 기준정보 관리 |
| **주요기능** | 1. 공장조회<br>2. 공장등록/수정<br>3. 사용여부 관리 |
| **입력항목** | 공장코드, 공장명, 주소, 전화번호, 사용여부 |
| **호출프로시저** | PKGBAS_BASE.GET_PLANT, PKGBAS_BASE.PUT_PLANT |

### 3.2 MSTA202 (거래처등록)
| 항목 | 내용 |
|------|------|
| **화면ID** | MSTA202 |
| **화멪명** | 거래처등록 |
| **파일** | Forms/MST/MSTA202.cs |
| **메뉴경로** | 기준정보 > 거래처 > 거래처등록 |
| **설명** | 거래처(협력사/고객사) 기준정보 관리 |
| **주요기능** | 1. 거래처조회<br>2. 거래처등록/수정<br>3. 거래처유형 구분(매입/매출) |
| **입력항목** | 거래처코드, 거래처명, 사업자번호, 대표자, 업태, 종목, 주소, 연락처, 입고유형 |
| **호출프로시저** | PKGBAS_BASE.PUT_VENDOR, PKGBAS_BASE.GET_VENDOR |

### 3.3 MSTA203 (공정등록)
| 항목 | 내용 |
|------|------|
| **화면ID** | MSTA203 |
| **화멪명** | 공정등록 |
| **파일** | Forms/MST/MSTA203.cs |
| **메뉴경로** | 기준정보 > 공정/라인 > 공정등록 |
| **설명** | 생산공정 기준정보 관리 |
| **주요기능** | 1. 공정조회<br>2. 공정등록/수정<br>3. 공정순서 관리 |
| **입력항목** | 공정코드, 공정명, 공정유형, 표준공수, 사용여부 |
| **호출프로시저** | PKGBAS_BASE.GET_OPER, PKGBAS_BASE.PUT_OPER |

### 3.4 MSTA204 (사유코드등록)
| 항목 | 내용 |
|------|------|
| **화면ID** | MSTA204 |
| **화멪명** | 사유코드등록 |
| **파일** | Forms/MST/MSTA204.cs |
| **메뉴경로** | 기준정보 > 코드관리 > 사유코드 |
| **호출프로시저** | PKGBAS_BASE.GET_REASONCODE, PKGBAS_BASE.PUT_REASONCODE |

### 3.5 MSTA205 (품목등록)
| 항목 | 내용 |
|------|------|
| **화면ID** | MSTA205 |
| **화멪명** | 품목등록 |
| **파일** | Forms/MST/MSTA205.cs |
| **메뉴경로** | 기준정보 > 품목 > 품목등록 |
| **설명** | 품목마스터 관리 (원자재/반제품/완제품) |
| **주요기능** | 1. 품목조회<br>2. 품목등록/수정<br>3. 품목이미지 관리<br>4. 라벨정보 설정 |
| **입력항목** | 품목코드, 품목명, 규격, 모델, 단위, 품목유형, ABC분류, 안전재고, 표준단가, 기본창고, 라벨유형, 라벨발행단위, 단자여부, 사용여부 |
| **호출프로시저** | PKGBAS_BASE.PUT_ITEM, GPKGBAS_BASE.GET_ITEMTYPE, GPKGBAS_BASE.GET_UNITCODE, GPKGBAS_BASE.GET_ROOTITEM, GPKGBAS_BASE.GET_TERMINALFLAG, GPKGBAS_BASE.GET_PRODLINE_UNIT, GPKGBAS_BASE.GET_PRINTTYPE, GPKGBAS_BASE.GET_LABELTEXT, PKGBAS_BASE.GET_ITEM, PKGBAS_BASE.SET_SAMPLEIMAGE, PKGBAS_BASE.SET_SAMPLEIMAGE2 |
| **비즈니스로직** | 1. 품목코드 채번규칙 적용<br>2. 품목유형별 필수항목 체크<br>3. 이미지 파일 업로드/저장<br>4. 라벨포맷 설정 |

### 3.6 MSTA206 (BOM등록)
| 항목 | 내용 |
|------|------|
| **화면ID** | MSTA206 |
| **화멪명** | BOM등록 |
| **파일** | Forms/MST/MSTA206.cs |
| **메뉴경로** | 기준정보 > 품목 > BOM등록 |
| **설명** | Bill of Material 관리 |
| **주요기능** | 1. BOM그룹 관리<br>2. BOM등록/수정<br>3. BOM복사<br>4. BOM전개<br>5. BOMRelease |
| **입력항목** | 모델코드, 품목코드, 구성품목, 수량, Loss율, 시작일, 종료일 |
| **호출프로시저** | PKGBAS_BASE.PUT_BOMGRP, PKGBAS_BASE.PUT_BOM, PKGBAS_BASE.GET_BOMGRP, PKGBAS_BASE.GET_BOM, PKGBAS_BASE.PUT_BOM_RELEASE, PKGBAS_BASE.PUT_BOM_FIND2, PKGBAS_BASE.PUT_BOM_SUBITEM_ALL |
| **비즈니스로직** | 1. BOM그룹 생성<br>2. 상위품목-하위품목 관계 설정<br>3. BOM레벨 자동계산<br>4. BOMRelease(확정)<br>5. 전개조회(하위품목 전체조회) |

### 3.7 MSTA207 (라우팅등록)
| 항목 | 내용 |
|------|------|
| **화면ID** | MSTA207 |
| **화멪명** | 라우팅등록 |
| **파일** | Forms/MST/MSTA207.cs |
| **메뉴경로** | 기준정보 > 공정/라인 > 라우팅등록 |
| **설명** | 품목별 생산라우팅(공정순서) 관리 |
| **주요기능** | 1. 라우팅그룹 관리<br>2. 공정순서 등록<br>3. 작업지시템플릿 설정 |
| **입력항목** | 라우팅그룹코드, 품목코드, 공정코드, 순번, 표준공수, 설비코드 |
| **호출프로시저** | PKGBAS_BASE.GET_ITEM, PKGBAS_BASE.GET_OPER, PKGBAS_BASE.GET_ROUTINGGRP, PKGBAS_BASE.GET_ROUTING, PKGBAS_BASE.PUT_ROUTINGGRP, PKGBAS_BASE.PUT_ROUTING |

### 3.8 MSTA208 (불량유형등록)
| 항목 | 내용 |
|------|------|
| **화면ID** | MSTA208 |
| **화멪명** | 불량유형등록 |
| **파일** | Forms/MST/MSTA208.cs |
| **메뉴경로** | 기준정보 > 품질 > 불량유형 |
| **주요기능** | 1. 불량유형 등록<br>2. 불량이미지 관리 |
| **입력항목** | 불량코드, 불량명, 불량분류, 사용여부 |
| **호출프로시저** | GPKGBAS_BASE.GET_DEF_TYPE, PKGBAS_BASE.GET_DEFECT, PKGBAS_BASE.PUT_DEFECT, PKGBAS_BASE.SET_DEFECTIMAGE |

### 3.9 MSTA209 (라인등록)
| 항목 | 내용 |
|------|------|
| **화면ID** | MSTA209 |
| **화멪명** | 라인등록 |
| **파일** | Forms/MST/MSTA209.cs |
| **메뉴경로** | 기준정보 > 공정/라인 > 라인등록 |
| **호출프로시저** | PKGBAS_BASE.GET_OPER, PKGBAS_BASE.GET_LINE, PKGBAS_BASE.PUT_LINE |

### 3.10 MSTA210 (창고등록)
| 항목 | 내용 |
|------|------|
| **화면ID** | MSTA210 |
| **화멪명** | 창고/로케이션등록 |
| **파일** | Forms/MST/MSTA210.cs |
| **메뉴경로** | 기준정보 > 창고 > 창고등록 |
| **설명** | 창고 및 로케이션(랙/선반) 관리 |
| **주요기능** | 1. 창고등록<br>2. 로케이션등록<br>3. 창고유형 설정(정상/불량/품질보류) |
| **입력항목** | 창고코드, 창고명, 창고유형, 로케이션코드, 로케이션명 |
| **호출프로시저** | GPKGBAS_BASE.GET_WAREHOUSE, PKGBAS_BASE.GET_LINE, PKGBAS_BASE.GET_VENDOR, GPKGBAS_BASE.GET_LOC_TYPE, PKGBAS_BASE.GET_LOCATION, PKGBAS_BASE.PUT_LOCATION |

### 3.11 MSTA211 (라인별설비등록)
| 항목 | 내용 |
|------|------|
| **화면ID** | MSTA211 |
| **화멪명** | 라인별설비등록 |
| **파일** | Forms/MST/MSTA211.cs |
| **메뉴경로** | 기준정보 > 공정/라인 > 라인별설비 |
| **호출프로시저** | PKGBAS_BASE.GET_LINE, PKGBAS_BASE.GET_PRODUNIT_TYPE, PKGBAS_BASE.GET_PRODLINE_UNIT, PKGBAS_BASE.PUT_PRODLINE_UNIT |

### 3.12 MSTA212 (설비등록)
| 항목 | 내용 |
|------|------|
| **화면ID** | MSTA212 |
| **화멪명** | 설비등록 |
| **파일** | Forms/MST/MSTA212.cs |
| **호출프로시저** | GPKGBAS_BASE.GET_WHLOC, PKGBAS_BASE.GET_EQP, PKGBAS_BASE.PUT_EQP |

### 3.13 MSTA213 (품목이미지등록)
| 항목 | 내용 |
|------|------|
| **화면ID** | MSTA213 |
| **화멪명** | 품목이미지등록 |
| **파일** | Forms/MST/MSTA213.cs |
| **호출프로시저** | PKGBAS_BASE.GET_ITEMIMAGE, PKGBAS_BASE.SET_ITEMIMAGE |

### 3.14 MSTA216 (마감기준등록)
| 항목 | 내용 |
|------|------|
| **화면ID** | MSTA216 |
| **화멪명** | 마감기준등록 |
| **파일** | Forms/MST/MSTA216.cs |
| **호출프로시저** | PKGBAS_BASE.PUT_CLOSINGBASE, PKGBAS_BASE.GET_CLOSINGBASE |

### 3.15 MSTA217 (크림핑기준등록)
| 항목 | 내용 |
|------|------|
| **화면ID** | MSTA217 |
| **화멪명** | 크림핑기준등록 |
| **파일** | Forms/MST/MSTA217.cs |
| **호출프로시저** | PKGBAS_BASE.GET_CRIMPINGBASE, PKGBAS_BASE.PUT_CRIMPINGBASE |

### 3.16 MSTA218 (근무시간등록)
| 항목 | 내용 |
|------|------|
| **화면ID** | MSTA218 |
| **화멪명** | 근무시간등록 |
| **파일** | Forms/MST/MSTA218.cs |
| **호출프로시저** | PKGBAS_BASE.SET_WORKTIME, PKGBAS_BASE.GET_WORKTIME |

### 3.17 MSTA219 (모델BOM등록)
| 항목 | 내용 |
|------|------|
| **화면ID** | MSTA219 |
| **화멪명** | 모델BOM등록 |
| **파일** | Forms/MST/MSTA219.cs |
| **호출프로시저** | PKGBAS_BASE.GET_VENDOR, PKGBAS_BASE.GET_LOCATION2, GPKGBAS_BASE.GET_MODELBOM, GPKGBAS_BASE.PUT_MODELBOM, PKGBAS_BASE.PUT_MODELBOM_UPLOAD |

### 3.18 MSTA220 (애플리케이터등록)
| 항목 | 내용 |
|------|------|
| **화면ID** | MSTA220 |
| **화멪명** | 애플리케이터등록 |
| **파일** | Forms/MST/MSTA220.cs |
| **호출프로시저** | PKGBAS_BASE.SET_APPLICATOR, PKGBAS_BASE.GET_APPLICATOR, PKGBAS_BASE.GET_APPLICATORDETAIL |

### 3.19 MSTA221 (지그/PIN등록)
| 항목 | 내용 |
|------|------|
| **화면ID** | MSTA221 |
| **화멪명** | 지그/PIN등록 |
| **파일** | Forms/MST/MSTA221.cs |
| **호출프로시저** | PKGBAS_BASE.SET_JIGPIN, PKGBAS_BASE.GET_JIGPIN, PKGBAS_BASE.GET_JIGPINDETAIL |

### 3.20 MSTB201 (BOM조회)
| 항목 | 내용 |
|------|------|
| **화면ID** | MSTB201 |
| **화멪명** | BOM조회 |
| **파일** | Forms/MST/MSTB201.cs |
| **호출프로시저** | PKGBAS_BASE.GET_ITEM, PKGBAS_BASE.GET_BOMGRP_LIST, PKGBAS_BASE.GET_BOM_LIST |

### 3.21 PopUp 화면
| 화면ID | 화멪명 | 설명 |
|--------|--------|------|
| MSTA206_PopUp | BOM품목선택 | BOM등록용 품목선택 |
| MSTA206_PopUp2 | 서브품목등록 | 서브품목 관리 |
| MSTA210_PopUp | 창고선택 | 창고/로케이션 선택 |

---

## 4. 보전관리 (MNT)

### 4.1 MNTA201 ~ MNTA204 (생산모니터링)
| 화면ID | 화멪명 | 주요내용 | 호출프로시저 |
|--------|--------|----------|--------------|
| MNTA201 | 생산모니터링 | 일별생산현황 | PKGPRD_MNT.GET_DAILY_PROD_MONITERING |
| MNTA202 | 크림핑모니터링 | 크림핑공정현황 | PKGPRD_MNT.GET_CRIMP_MONITORING |
| MNTA203 | 생산현황(A) | 라인별생산현황 | PKGHNS_REPORT.GET_SALE_MONITOR1 |
| MNTA204 | 조립실적조회 | 조립공정실적 | PKGPRD_MNT.GET_ASSEMBLY_RESULT_* |

### 4.2 MNTB201 ~ MNTB207 (리포트/현황)
| 화면ID | 화멪명 | 주요내용 | 호출프로시저 |
|--------|--------|----------|--------------|
| MNTB201 | 자재모니터링(고객사별) | 고객사별 자재현황 | PKGHNS_REPORT.GET_CUSTPLAN_MAXDATE, PKGHNS_REPORT.GET_CUSTPLAN, PKGHNS_REPORT.PUT_MAT_MONITOR, PKGHNS_REPORT.GET_MAT_MONITOR |
| MNTB202 | 자재모니터링(생산계획) | 생산계획기준 자재 | PKGHNS_REPORT.GET_PRODPLAN_MAXDATE, PKGHNS_REPORT.GET_MAT_MONITOR_PRODPLAN, PKGHNS_REPORT.GET_PRD_MONITOR_PRODPLAN |
| MNTB203 | 자재수불부 | 자재수불현황 | PKGHNS_REPORT.GET_CUSTPLAN_MAXDATE, PKGHNS_REPORT.GET_MAT_BALANCE |
| MNTB204 | LQC모니터링(공정) | 공정별LQC | PKGHNS_REPORT.GET_LQC_MONITOR1-5 |
| MNTB205 | LQC모니터링(라인) | 라인별LQC | PKGHNS_REPORT.GET_LQC_MONITOR1-5 |
| MNTB206 | NG/스크랩현황 | 불량/스크랩 | PKGHNS_REPORT.GET_NG_SCRAP |
| MNTB207 | 자재사용현황 | 생산별자재사용 | PKGPRD_REPORT.GET_ACTUALMATERIALSTOCK |

### 4.3 PopUp 화면
| 화면ID | 화멪명 | 호출프로시저 |
|--------|--------|--------------|
| MNTB201_POPUP | 고객사계획조회 | PKGHNS_REPORT.GET_MAT_CUSTPLAN |
| MNTB202_POPUP | 생산계획조회 | PKGHNS_REPORT.GET_MAT_PRODPLAN |

---

*[이하 PRD, RPT, SAL, SYS, OSC, SAMPLE 모듈 계속]*


## 5. 생산관리 (PRD)

### 5.1 PRDA201 (작업실적등록)
| 항목 | 내용 |
|------|------|
| **화면ID** | PRDA201 |
| **화멪명** | 작업실적등록 |
| **파일** | Forms/PRD/PRDA201.cs |
| **메뉴경로** | 생산관리 > 작업실적 > 작업실적등록 |
| **설명** | 공정별 생산실적 등록 (메인 생산입력 화면) |
| **주요기능** | 1. 작업지시 조회<br>2. 바코드 스캔<br>3. 양품/불량실적 등록<br>4. 자재투입처리<br>5. 공정이동 |
| **입력항목** | 작업지시번호, 바코드, 공정코드, 양품수량, 불량수량, 불량코드, 작업자 |
| **출력항목** | 작업지시정보, 실적현황, 누적실적 |
| **호출프로시저** | PKGPRD_PROD.GET_WORKORDER, PKGPRD_PROD.CHK_BARCODE, PKGPRD_PROD.SET_WORK_RESULT, PKGPRD_PROD.GET_WORK_RESULT |
| **비즈니스로직** | 1. 작업지시 선택<br>2. 제품바코드 스캔<br>3. 공정별 실적체크<br>4. TW_PRODHIST INSERT<br>5. TM_SERIAL 상태변경<br>6. 자재차감(TW_OUT)<br>7. 불량처리(TW_BRD) |
| **이벤트** | SearchButton_Click, btnScan_KeyDown, SaveButton_Click |

### 5.2 PRDA202 (작업지시관리)
| 항목 | 내용 |
|------|------|
| **화면ID** | PRDA202 |
| **화멪명** | 작업지시관리 |
| **파일** | Forms/PRD/PRDA202.cs |
| **메뉴경로** | 생산관리 > 작업지시 > 작업지시관리 |
| **설명** | 작업지시 생성 및 관리 |
| **주요기능** | 1. 작업지시 생성<br>2. 작업지시 조회<br>3. 작업지시 상태관리<br>4. 작업지시 마감 |
| **호출프로시저** | PKGPRD_PROD.GET_WORKORDER, PKGPRD_PROD.SET_WORKORDER, PKGPRD_PROD.PUT_WORKORDER |

### 5.3 PRDA203 ~ PRDA222 (생산현황 및 관리)
| 화면ID | 화멪명 | 주요내용 | 호출프로시저 |
|--------|--------|----------|--------------|
| PRDA203 | 생산현황(일별) | 일별생산현황조회 | PKGPRD_CURRENT.* |
| PRDA204 | 생산현황(품목별) | 품목별생산현황 | PKGPRD_CURRENT.* |
| PRDA205 | 작업실적조회 | 작업실적상세조회 | PKGPRD_PROD.GET_WORK_RESULT |
| PRDA206 | 공정이동조회 | 공정별이력조회 | PKGPRD_HIST.* |
| PRDA207 | 생산실적집계 | 생산실적월집계 | PKGPRD_REPORT.* |
| PRDA208 | 라인별생산현황 | 라인별실적현황 | PKGPRD_CURRENT.* |
| PRDA209 | 생산계획대비실적 | 계획대비달성률 | PKGPRD_CURRENT.* |
| PRDA210 | 재작업관리 | 재작업지시관리 | PKGPRD_PROD.* |
| PRDA211 | 생산투입현황 | 자재투입현황 | PKGPRD_MAT.* |
| PRDA212 | 외주생산관리 | 외주가공관리 | PKGPRD_PROD.* |
| PRDA213 | 생산LOSS현황 | LOSS분석 | PKGPRD_CURRENT.* |
| PRDA214 | 작업지시현황 | 작업지시진행현황 | PKGPRD_PROD.* |
| PRDA215 | 공정별실적현황 | 공정별실적집계 | PKGPRD_REPORT.* |
| PRDA216 | 생산일보 | 일별생산보고 | PKGPRD_REPORT.* |
| PRDA217 | 생산월보 | 월별생산보고 | PKGPRD_REPORT.* |
| PRDA218 | 품목별생산현황 | 품목별집계 | PKGPRD_REPORT.* |
| PRDA219 | 작업실적라벨발행 | 실적라벨발행 | PKGPRD_PROD.* |
| PRDA220 | 공정검사등록 | 공정중검사 | PKGPRD_QC.* |
| PRDA221 | 생산실적마감 | 실적마감처리 | PKGPRD_PROD.* |
| PRDA221N | 생산실적마감(신규) | 실적마감(개선) | PKGPRD_PROD.* |
| PRDA222 | 바코드재발행 | 라벨재발행 | PKGPRD_PROD.* |

### 5.4 PRDB201 ~ PRDB208 (생산리포트)
| 화면ID | 화멪명 | 주요내용 | 호출프로시저 |
|--------|--------|----------|--------------|
| PRDB201 | 생산현황리포트 | 종합생산현황 | PKGPRD_REPORT.* |
| PRDB202 | 생산실적리포트 | 상세실적보고 | PKGPRD_REPORT.* |
| PRDB203 | 공정별생산리포트 | 공정별분석 | PKGPRD_REPORT.* |
| PRDB204 | 라인별생산리포트 | 라인별분석 | PKGPRD_REPORT.* |
| PRDB205 | 품목별생산리포트 | 품목별분석 | PKGPRD_REPORT.* |
| PRDB206 | 재작업리포트 | 재작업분석 | PKGPRD_REPORT.* |
| PRDB207 | 생산LOSS리포트 | LOSS상세보고 | PKGPRD_REPORT.* |
| PRDB208 | 외주생산리포트 | 외주현황 | PKGPRD_REPORT.* |

### 5.5 PRDC201 (생산종합현황)
| 항목 | 내용 |
|------|------|
| **화면ID** | PRDC201 |
| **화멪명** | 생산종합현황 |
| **파일** | Forms/PRD/PRDC201.cs |
| **설명** | 대시보드 형태 생산종합현황 |

### 5.6 PRDH001 (생산이력조회)
| 항목 | 내용 |
|------|------|
| **화면ID** | PRDH001 |
| **화멪명** | 생산이력조회 |
| **파일** | Forms/PRD/PRDH001.cs |
| **설명** | 시리얼별 생산이력 추적 |
| **주요기능** | 1. 시리얼검색<br>2. 생산이력조회<br>3. 자재사용이력<br>4. 공정이력 |
| **호출프로시저** | PKGPRD_HIST.* |

### 5.7 PopUp 화면
| 화면ID | 화멪명 | 설명 |
|--------|--------|------|
| POP_PRD01 | 작업지시선택 | 작업지시 팝업 |
| POP_PRD02 | 품목선택 | 품목검색 팝업 |
| POP_PRD03 | 공정선택 | 공정검색 팝업 |
| POP_PRD04 | 불량등록 | 불량입력 팝업 |
| POP_PRD05 | 자재투입 | 자재불출 팝업 |
| POP_PRD06 | 재작업지시 | 재작업등록 팝업 |
| POP_PRD07 | 바코드발행 | 라벨발행 팝업 |
| POP_PRD08 | 작업자선택 | 작업자지정 팝업 |
| POP_PRDA201 | 작업실적상세 | 실적상세조회 팝업 |
| POP_PRD201 | 투입자재조회 | 자재투입이력 팝업 |
| POP_PRD204_01 ~ 03 | 분할/병합 | 시리얼분할/병합 팝업 |

---

## 6. 리포트 (RPT)

### 6.1 RPTA201 ~ RPTA216 (리포트조회)
| 화면ID | 화멪명 | 주요내용 | 호출프로시저 |
|--------|--------|----------|--------------|
| RPTA201 | 생산일보 | 일별생산집계 | PKGHNS_REPORT.* |
| RPTA202 | 생산월보 | 월별생산집계 | PKGHNS_REPORT.* |
| RPTA203 | 생산현황 | 생산종합현황 | PKGHNS_REPORT.* |
| RPTA204 | 품목별생산현황 | 품목별집계 | PKGHNS_REPORT.* |
| RPTA205 | 공정별생산현황 | 공정별집계 | PKGHNS_REPORT.* |
| RPTA206 | 라인별생산현황 | 라인별집계 | PKGHNS_REPORT.* |
| RPTA207 | 작업자별생산현황 | 작업자별실적 | PKGHNS_REPORT.* |
| RPTA208 | 불량현황 | 불량분석 | PKGHNS_REPORT.* |
| RPTA209 | 재고현황 | 재고집계 | PKGHNS_REPORT.* |
| RPTA210 | 입출고현황 | 수불부 | PKGHNS_REPORT.* |
| RPTA211 | IQC현황 | 수입검사현황 | PKGHNS_REPORT.* |
| RPTA212 | OQC현황 | 출하검사현황 | PKGHNS_REPORT.* |
| RPTA213 | 납기준수율 | 납기분석 | PKGHNS_REPORT.* |
| RPTA2131 | 납기준수율(상세) | 상세분석 | PKGHNS_REPORT.* |
| RPTA2132 | 납기준수율(집계) | 집계보고 | PKGHNS_REPORT.* |
| RPTA214 | 재작업현황 | 재작업분석 | PKGHNS_REPORT.* |
| RPTA215 | 설비가동율 | 설비효율 | PKGHNS_REPORT.* |
| RPTA216 | 인당생산성 | 생산성분석 | PKGHNS_REPORT.* |
| RPTA2161 | 인당생산성(상세) | 상세분석 | PKGHNS_REPORT.* |
| RPTA2162 | 인당생산성(집계) | 집계보고 | PKGHNS_REPORT.* |

### 6.2 RPTDS (데이터셋)
| 항목 | 내용 |
|------|------|
| **화면ID** | RPTDS |
| **화멪명** | 리포트데이터셋 |
| **파일** | Forms/RPT/RPTDS.cs |
| **설명** | 리포트용 데이터셋 정의 |

---

*[이하 SAL, SYS, OSC, SAMPLE 모듈 계속]*


## 7. 영업관리 (SAL)

### 7.1 SALA201 (수주등록)
| 항목 | 내용 |
|------|------|
| **화면ID** | SALA201 |
| **화멪명** | 수주등록 |
| **파일** | Forms/SAL/SALA201.cs |
| **메뉴경로** | 영업관리 > 수주/출하 > 수주등록 |
| **설명** | 고객사 수주 등록 관리 |
| **주요기능** | 1. 수주등록<br>2. 수주조회<br>3. 수주수정/취소 |
| **호출프로시저** | PKGPRD_SALES.* |

### 7.2 SALA202 (출하등록)
| 항목 | 내용 |
|------|------|
| **화면ID** | SALA202 |
| **화멪명** | 출하등록 |
| **파일** | Forms/SAL/SALA202.cs |
| **메뉴경로** | 영업관리 > 수주/출하 > 출하등록 |
| **설명** | 제품 출하 등록 |
| **주요기능** | 1. 출하등록<br>2. 출하조회<br>3. 출하취소 |
| **호출프로시저** | PKGPRD_SALES.* |

### 7.3 SALA203 (출하현황)
| 항목 | 내용 |
|------|------|
| **화면ID** | SALA203 |
| **화멪명** | 출하현황 |
| **파일** | Forms/SAL/SALA203.cs |
| **호출프로시저** | PKGPRD_SALES.* |

### 7.4 SALA204 (수주현황)
| 항목 | 내용 |
|------|------|
| **화면ID** | SALA204 |
| **화멪명** | 수주현황 |
| **파일** | Forms/SAL/SALA204.cs |
| **호출프로시저** | PKGPRD_SALES.* |

### 7.5 SALB201 ~ SALB203 (영업리포트)
| 화면ID | 화멪명 | 주요내용 |
|--------|--------|----------|
| SALB201 | 수주출하현황 | 수주/출하집계 |
| SALB202 | 출하계획대비실적 | 계획대비분석 |
| SALB203 | 고객사별출하현황 | 고객사별분석 |

### 7.6 PopUp 화면
| 화면ID | 화멪명 | 설명 |
|--------|--------|------|
| POP_SAL01 | 수주선택 | 수주팝업 |
| POP_SAL02 | 고객사선택 | 거래처팝업 |

---

## 8. 시스템 (SYS)

### 8.1 SYSA201 (용어사전관리)
| 항목 | 내용 |
|------|------|
| **화면ID** | SYSA201 |
| **화멪명** | 용어사전관리 |
| **파일** | Forms/SYS/SYSA201.cs |
| **메뉴경로** | 시스템 > 기본정보 > 용어사전 |
| **설명** | 다국어용어 관리 |
| **호출프로시저** | PKGSYS_COMM.DEL_GLOSSARY, PKGSYS_COMM.GET_GLOSSARY, PKGSYS_COMM.PUT_GLOSSARY |

### 8.2 SYSA202 (트랜잭션관리)
| 항목 | 내용 |
|------|------|
| **화면ID** | SYSA202 |
| **화멪명** | 트랜잭션관리 |
| **파일** | Forms/SYS/SYSA202.cs |
| **메뉴경로** | 시스템 > 기본정보 > 트랜잭션 |
| **호출프로시저** | PKGSYS_COMM.GET_TRANSACTION, PKGSYS_COMM.PUT_TRANSACTION |

### 8.3 SYSA203 (공통코드관리)
| 항목 | 내용 |
|------|------|
| **화면ID** | SYSA203 |
| **화멪명** | 공통코드관리 |
| **파일** | Forms/SYS/SYSA203.cs |
| **메뉴경로** | 시스템 > 코드관리 > 공통코드 |
| **주요기능** | 1. 코드그룹관리<br>2. 코드등록/수정<br>3. 코드사용여부 관리 |
| **호출프로시저** | PKGSYS_COMM.GET_COMMGRP, PKGSYS_COMM.GET_COMM, PKGSYS_COMM.PUT_COMM |

### 8.4 SYSA204 (화면관리)
| 항목 | 내용 |
|------|------|
| **화면ID** | SYSA204 |
| **화멪명** | 화면관리 |
| **파일** | Forms/SYS/SYSA204.cs |
| **메뉴경로** | 시스템 > 메뉴/권한 > 화면관리 |
| **주요기능** | 시스템에 등록된 모든 화면(Form) 관리 |
| **호출프로시저** | PKGSYS_MENU.DEL_FORMMST, PKGSYS_MENU.GET_FORMS, PKGSYS_MENU.PUT_FORMMST |

### 8.5 SYSA205 (메뉴관리)
| 항목 | 내용 |
|------|------|
| **화면ID** | SYSA205 |
| **화멪명** | 메뉴관리 |
| **파일** | Forms/SYS/SYSA205.cs |
| **메뉴경로** | 시스템 > 메뉴/권한 > 메뉴관리 |
| **주요기능** | 트리메뉴 구성 및 관리 |
| **호출프로시저** | PKGSYS_MENU.PUT_MENU, PKGSYS_MENU.GET_MENU, PKGSYS_MENU.GET_FORMMST |

### 8.6 SYSA206 (권한그룹관리)
| 항목 | 내용 |
|------|------|
| **화면ID** | SYSA206 |
| **화멪명** | 권한그룹관리 |
| **파일** | Forms/SYS/SYSA206.cs |
| **메뉴경로** | 시스템 > 메뉴/권한 > 권한그룹 |
| **주요기능** | 역할(Role) 기반 권한그룹 관리 |
| **호출프로시저** | PKGSYS_USER.GET_ROLE, PKGSYS_USER.PUT_ROLE |

### 8.7 SYSA207 (메뉴권한관리)
| 항목 | 내용 |
|------|------|
| **화면ID** | SYSA207 |
| **화멪명** | 메뉴권한관리 |
| **파일** | Forms/SYS/SYSA207.cs |
| **메뉴경로** | 시스템 > 메뉴/권한 > 메뉴권한 |
| **주요기능** | 권한그룹별 메뉴 접근권한 설정 |
| **호출프로시저** | PKGSYS_MENU.PUT_MENUROLE, PKGSYS_USER.GET_ROLE, PKGSYS_MENU.GET_MENUROLE |

### 8.8 SYSA208 (회사등록)
| 항목 | 내용 |
|------|------|
| **화면ID** | SYSA208 |
| **화멪명** | 회사등록 |
| **파일** | Forms/SYS/SYSA208.cs |
| **메뉴경로** | 시스템 > 조직 > 회사 |
| **호출프로시저** | PKGSYS_COMM.GET_CLIENT, PKGSYS_COMM.GET_COMPANY, PKGSYS_COMM.PUT_COMPANY |

### 8.9 SYSA209 (부서등록)
| 항목 | 내용 |
|------|------|
| **화면ID** | SYSA209 |
| **화멪명** | 부서등록 |
| **파일** | Forms/SYS/SYSA209.cs |
| **메뉴경로** | 시스템 > 조직 > 부서 |
| **호출프로시저** | PKGSYS_USER.GET_DEPT, PKGSYS_COMM.GET_CLIENT, PKGSYS_USER.PUT_DEPT |

### 8.10 SYSA210 (직급관리)
| 항목 | 내용 |
|------|------|
| **화면ID** | SYSA210 |
| **화멪명** | 직급관리 |
| **파일** | Forms/SYS/SYSA210.cs |
| **메뉴경로** | 시스템 > 조직 > 직급 |
| **호출프로시저** | PKGSYS_USER.GET_POST, PKGSYS_COMM.GET_CLIENT, PKGSYS_USER.PUT_POST |

### 8.11 SYSA211 (사원등록)
| 항목 | 내용 |
|------|------|
| **화면ID** | SYSA211 |
| **화멪명** | 사원등록 |
| **파일** | Forms/SYS/SYSA211.cs |
| **메뉴경로** | 시스템 > 사용자 > 사원등록 |
| **주요기능** | 1. 사원정보등록<br>2. 비밀번호초기화<br>3. EHR연동 |
| **호출프로시저** | PKGSYS_USER.PUT_DEFAULTPWD, PKGSYS_USER.PUT_EHR, PKGSYS_USER.GET_ROLE, PKGSYS_USER.GET_DEPT, PKGSYS_USER.GET_POST, PKGSYS_USER.GET_EHR |

### 8.12 SYSA212 (단위관리)
| 항목 | 내용 |
|------|------|
| **화면ID** | SYSA212 |
| **화멪명** | 단위관리 |
| **파일** | Forms/SYS/SYSA212.cs |
| **호출프로시저** | PKGSYS_COMM.GET_UNIT, PKGSYS_COMM.PUT_UNIT |

### 8.13 SYSA213 (공지사항관리)
| 항목 | 내용 |
|------|------|
| **화면ID** | SYSA213 |
| **화멪명** | 공지사항관리 |
| **파일** | Forms/SYS/SYSA213.cs |
| **호출프로시저** | PKGSYS_COMM.GET_NOTICE, PKGSYS_COMM.PUT_NOTICE |

### 8.14 SYSA214 (에러로그조회)
| 항목 | 내용 |
|------|------|
| **화면ID** | SYSA214 |
| **화멪명** | 에러로그조회 |
| **파일** | Forms/SYS/SYSA214.cs |
| **호출프로시저** | PKGSYS_COMM.GET_ERROR_LOG |

### 8.15 SYSA215 (테이블스페이스조회)
| 항목 | 내용 |
|------|------|
| **화면ID** | SYSA215 |
| **화멪명** | 테이블스페이스조회 |
| **파일** | Forms/SYS/SYSA215.cs |
| **설명** | DB 용량 모니터링 (DBA용) |
| **호출프로시저** | PKGSYS_DBA.GET_TABLESPACE_01~04 |

### 8.16 PopUp 화면
| 화면ID | 화멪명 | 호출프로시저 |
|--------|--------|--------------|
| POP_SYS01 | 공통코드그룹 | PKGSYS_COMM.GET_COMMGRP, PKGSYS_COMM.PUT_COMMGRP |
| POP_SYSA202 | 공통코드그룹(팝업) | PKGSYS_COMM.GET_COMMGRP, PKGSYS_COMM.PUT_COMMGRP |
| POP_SYSB002 | 공통코드그룹(관리) | PKGSYS_COMM.GET_COMMGRP, PKGSYS_COMM.PUT_COMMGRP |

---

## 9. 모니터링 (OSC)

### 9.1 OSCA201 ~ OSCA205 (모니터링/테스트)
| 화면ID | 화멪명 | 주요내용 | 호출프로시저 |
|--------|--------|----------|--------------|
| OSCA201 | 생산모니터링(대) | 대형모니터용 | PKGPRD_CURRENT.* |
| OSCA202 | 라인모니터링 | 라인별현황 | PKGPRD_MNT.* |
| OSCA203 | 설비모니터링 | 설비가동현황 | PKGPRD_MNT.* |
| OSCA204 | 자재요청모니터링 | 라인자재요청 | PKGPRD_PROD.PUT_OSC_PRODMATERIALREQUEST, GPKGPRD_PROD.GET_VENDOR, PKGPRD_PROD.GET_OSC_PRODMATERIALREQUEST, PKGPRD_PROD.GET_OSC_PRODMATERIALSTOCK |
| OSCA205 | 외주현황 | 외주가공현황 | PKGBAS_BASE.GET_WAREHOUSE, PKGBAS_BASE.GET_LOCATION, PKGPRD_REPORT.GET_OUTSOURCING_INOUT |

---

## 10. 샘플 (SAMPLE)

### 10.1 TSTA001 ~ TSTA005 (샘플/데모)
| 화면ID | 화멪명 | 주요내용 |
|--------|--------|----------|
| TSTA001 | 샘플폼1 | 개발자용 샘플 |
| TSTA002 | 샘플폼2 | 개발자용 샘플 |
| TSTA003 | 샘플폼3 | 개발자용 샘플 |
| TSTA004 | 샘플폼4 | 개발자용 샘플 |
| TSTA005 | 샘플폼5 | 개발자용 샘플 |

---

## 부록: 화면-프로시저 전체 매트릭스

### A. 모듈별 프로시저 사용 현황

| 모듈 | 화면수 | 주요패키지 | 프로시저호출수 |
|------|--------|------------|----------------|
| COM | 20 | PKGSYS_USER, PKGSYS_MENU | 30+ |
| MAT | 26 | PKGMAT_INOUT, PKGBAS_MAT, PKGPDA_MAT | 80+ |
| MST | 23 | PKGBAS_BASE, GPKGBAS_BASE | 60+ |
| MNT | 13 | PKGHNS_REPORT, PKGPRD_MNT | 30+ |
| PRD | 46 | PKGPRD_PROD, PKGPRD_CURRENT, PKGPRD_REPORT | 90+ |
| RPT | 22 | PKGHNS_REPORT, PKGPRD_REPORT | 40+ |
| SAL | 9 | PKGPRD_SALES | 15+ |
| SYS | 18 | PKGSYS_USER, PKGSYS_MENU, PKGSYS_COMM, PKGSYS_DBA | 35+ |
| OSC | 5 | PKGPRD_MNT, PKGPRD_PROD, PKGPRD_REPORT | 10+ |
| SAMPLE | 5 | PKG_TESTC | 5+ |

### B. 화면별 공통 처리 패턴

```csharp
// 1. 폼 로드 패턴
private void Form_Load(object sender, EventArgs e)
{
    // 기본값 설정
    dteDate.EditValue = DateTime.Now;
    
    // 초기화
    Set_init();
}

// 2. 조회 버튼 패턴
public void SearchButton_Click()
{
    // 1) 입력값 체크
    if (!Validation()) return;
    
    // 2) 프로시저 호출
    WSResults result = BASE_db.Execute_Proc(
        "PKG...",
        1,
        new string[] { "A_..." },
        new object[] { ... }
    );
    
    // 3) 결과처리
    if (result.ResultInt == 0)
    {
        gcList.DataSource = result.ResultDataSet.Tables[0];
    }
    else
    {
        iDATMessageBox.WARNINGMessage(result.ResultString);
    }
}

// 3. 저장 버튼 패턴
public void SaveButton_Click()
{
    // 1) 유효성체크
    if (!ValidateData()) return;
    
    // 2) 저장확인
    if (DialogResult.No == XtraMessageBox.Show(...)) return;
    
    // 3) 프로시저호출
    WSResults result = BASE_db.Execute_Proc(...);
    
    // 4) 결과처리
    if (result.ResultInt == 0)
    {
        iDATMessageBox.SAVESuccessMessage();
        SearchButton_Click(); // 재조회
    }
}
```

---

**문서 작성 완료**

**총 화면 수**: 189개  
**총 페이지**: 약 50페이지 (A4 기준)
