# 부록 B: 프로시저 상세 명세서

## B.1 PKGBAS_BASE (기준정보 기본)

### GET_ITEM (품목조회)

**목적**: 품목마스터 조회

**파라미터**:

| 파라미터 | 방향 | 타입 | 설명 |
|----------|------|------|------|
| A_CLIENT | IN | VARCHAR2 | 클라이언트코드 |
| A_COMPANY | IN | VARCHAR2 | 회사코드 |
| A_ITEMCODE | IN | VARCHAR2 | 품목코드 (NULL시 전체) |
| A_ITEMNAME | IN | VARCHAR2 | 품목명 (LIKE 검색) |
| A_USEFLAG | IN | VARCHAR2 | 사용여부 |
| O_CUR | OUT | SYS_REFCURSOR | 결과 커서 |
| O_RESULT | OUT | NUMBER | 결과코드 (0:성공) |

**반환**: 품목목록 (CURSOR)

**사용예시**:
```sql
-- 전체 품목 조회
PKGBAS_BASE.GET_ITEM('1060', '40', NULL, NULL, 'Y', :cur, :result);

-- 특정 품목 조회
PKGBAS_BASE.GET_ITEM('1060', '40', 'ITEM001', NULL, NULL, :cur, :result);
```

---

### PUT_ITEM (품목등록/수정)

**목적**: 품목마스터 등록 또는 수정

**파라미터**:

| 파라미터 | 방향 | 타입 | 설명 |
|----------|------|------|------|
| A_CLIENT | IN | VARCHAR2 | 클라이언트코드 |
| A_COMPANY | IN | VARCHAR2 | 회사코드 |
| A_ITEMCODE | IN | VARCHAR2 | 품목코드 |
| A_ITEMNAME | IN | VARCHAR2 | 품목명 |
| A_SPEC | IN | VARCHAR2 | 규격 |
| A_UNITCODE | IN | VARCHAR2 | 단위코드 |
| A_ITEMTYPE | IN | VARCHAR2 | 품목유형 |
| A_SAFESTOCK | IN | NUMBER | 안전재고 |
| A_USEFLAG | IN | VARCHAR2 | 사용여부 |
| A_REGUSER | IN | VARCHAR2 | 등록자 |
| O_RESULT | OUT | NUMBER | 결과코드 |
| O_MSG | OUT | VARCHAR2 | 결과메시지 |

**처리로직**:
1. 품목코드 존재여부 체크
2. 존재시 UPDATE, 미존재시 INSERT
3. 이력저장 (TM_ITEMS_HISTORY)

---

### GET_VENDOR (거래처조회)

**목적**: 거래처마스터 조회

**파라미터**:
| 파라미터 | 방향 | 타입 | 설명 |
|----------|------|------|------|
| A_CLIENT | IN | VARCHAR2 | 클라이언트코드 |
| A_COMPANY | IN | VARCHAR2 | 회사코드 |
| A_VENDORCODE | IN | VARCHAR2 | 거래처코드 |
| A_VENDORNAME | IN | VARCHAR2 | 거래처명 |
| O_CUR | OUT | SYS_REFCURSOR | 결과 커서 |
| O_RESULT | OUT | NUMBER | 결과코드 |

---

## B.2 PKGMAT_INOUT (자재 입출고)

### GET_IQC_LIST (IQC검사목록조회)

**목적**: IQC 검사대상 목록 조회

**파라미터**:
| 파라미터 | 방향 | 타입 | 설명 |
|----------|------|------|------|
| A_CLIENT | IN | VARCHAR2 | 클라이언트코드 |
| A_COMPANY | IN | VARCHAR2 | 회사코드 |
| A_PLANT | IN | VARCHAR2 | 공장코드 |
| A_FROMDATE | IN | VARCHAR2 | 시작일자(YYYYMMDD) |
| A_TODATE | IN | VARCHAR2 | 종료일자(YYYYMMDD) |
| A_JUDGE | IN | VARCHAR2 | 판정상태 |
| O_CUR | OUT | SYS_REFCURSOR | 결과 커서 |
| O_RESULT | OUT | NUMBER | 결과코드 |

**반환데이터**:
- IQCDATE: IQC일자
- IQCNO: IQC번호
- LOTNO: LOT번호
- ITEMCODE: 품목코드
- ITEMNAME: 품목명
- QTY: 검사수량
- JUDGE: 판정

---

### SET_IQC_JUDGE (IQC판정저장)

**목적**: IQC 검사결과 저장

**파라미터**:
| 파라미터 | 방향 | 타입 | 설명 |
|----------|------|------|------|
| A_CLIENT | IN | VARCHAR2 | 클라이언트코드 |
| A_COMPANY | IN | VARCHAR2 | 회사코드 |
| A_PLANT | IN | VARCHAR2 | 공장코드 |
| A_IQCDATE | IN | VARCHAR2 | IQC일자 |
| A_IQCNO | IN | VARCHAR2 | IQC번호 |
| A_JUDGE | IN | VARCHAR2 | 판정(Y/N) |
| A_USER | IN | VARCHAR2 | 검사자 |
| O_RESULT | OUT | NUMBER | 결과코드 |
| O_MSG | OUT | VARCHAR2 | 결과메시지 |

**처리로직**:
1. IQC 마스터 상태 체크
2. 판정결과 UPDATE (TW_IQC)
3. 합격시: TW_IN.IQCJUDGE = 'Y' UPDATE
4. 불합격시: TW_IN.IQCJUDGE = 'N' UPDATE + 품질보류 처리

---

### GET_LABEL_ORDER (라벨발행대상조회)

**목적**: 라벨 발행 대상 목록 조회

**파라미터**:
| 파라미터 | 방향 | 타입 | 설명 |
|----------|------|------|------|
| A_CLIENT | IN | VARCHAR2 | 클라이언트코드 |
| A_COMPANY | IN | VARCHAR2 | 회사코드 |
| A_PLANT | IN | VARCHAR2 | 공장코드 |
| A_IQCDATE | IN | VARCHAR2 | IQC일자 |
| A_IQCNO | IN | VARCHAR2 | IQC번호 |
| O_CUR | OUT | SYS_REFCURSOR | 결과 커서 |
| O_RESULT | OUT | NUMBER | 결과코드 |

---

### SET_NEW_CREATESN (시리얼생성)

**목적**: 신규 시리얼 번호 생성

**파라미터**:
| 파라미터 | 방향 | 타입 | 설명 |
|----------|------|------|------|
| A_CLIENT | IN | VARCHAR2 | 클라이언트코드 |
| A_COMPANY | IN | VARCHAR2 | 회사코드 |
| A_PLANT | IN | VARCHAR2 | 공장코드 |
| A_ITEMCODE | IN | VARCHAR2 | 품목코드 |
| A_QTY | IN | NUMBER | 생성수량 |
| A_PRODDATE | IN | VARCHAR2 | 생산일자 |
| A_REGUSER | IN | VARCHAR2 | 등록자 |
| O_CUR | OUT | SYS_REFCURSOR | 생성된 시리얼 목록 |
| O_RESULT | OUT | NUMBER | 결과코드 |
| O_MSG | OUT | VARCHAR2 | 결과메시지 |

**처리로직**:
1. 품목정보 조회 (라벨유형, 발행단위)
2. 시리얼 채번 (시퀀스 또는 규칙)
3. TM_SERIAL INSERT
4. TH_STOCKSERIAL INSERT (초기재고)
5. TW_IN INSERT (입고이력)

**시리얼채번규칙**:
```
[품목코드][YYMMDD][일련번호4자리]
예: ITEM0012306150001
```

---

## B.3 PKGPRD_PROD (생산관리)

### GET_WORKORDER (작업지시조회)

**목적**: 작업지시 목록 조회

**파라미터**:
| 파라미터 | 방향 | 타입 | 설명 |
|----------|------|------|------|
| A_CLIENT | IN | VARCHAR2 | 클라이언트코드 |
| A_COMPANY | IN | VARCHAR2 | 회사코드 |
| A_PLANT | IN | VARCHAR2 | 공장코드 |
| A_WORKDATE | IN | VARCHAR2 | 작업일자 |
| A_LINECODE | IN | VARCHAR2 | 라인코드 |
| O_CUR | OUT | SYS_REFCURSOR | 결과 커서 |
| O_RESULT | OUT | NUMBER | 결과코드 |

---

### SET_WORK_RESULT (작업실적저장)

**목적**: 생산실적 등록

**파라미터**:
| 파라미터 | 방향 | 타입 | 설명 |
|----------|------|------|------|
| A_CLIENT | IN | VARCHAR2 | 클라이언트코드 |
| A_COMPANY | IN | VARCHAR2 | 회사코드 |
| A_PLANT | IN | VARCHAR2 | 공장코드 |
| A_WORKDATE | IN | VARCHAR2 | 작업일자 |
| A_WORKORD | IN | VARCHAR2 | 작업지시번호 |
| A_SERIALNO | IN | VARCHAR2 | 시리얼번호 |
| A_ITEMCODE | IN | VARCHAR2 | 품목코드 |
| A_LINECODE | IN | VARCHAR2 | 라인코드 |
| A_OPCODE | IN | VARCHAR2 | 공정코드 |
| A_QTY_GOOD | IN | NUMBER | 양품수량 |
| A_QTY_BAD | IN | NUMBER | 불량수량 |
| A_BADCODE | IN | VARCHAR2 | 불량코드 |
| A_WORKUSER | IN | VARCHAR2 | 작업자 |
| A_REGUSER | IN | VARCHAR2 | 등록자 |
| O_RESULT | OUT | NUMBER | 결과코드 |
| O_MSG | OUT | VARCHAR2 | 결과메시지 |

**처리로직**:
1. 입력값 Validation 체크
2. 중복실적 체크
3. TW_PRODHIST INSERT
4. TM_SERIAL UPDATE (상태변경)
5. 불량있을시: TW_BRD INSERT
6. 자재차감: PKGTXN_STOCK.SET_STOCK_DEDUCT 호출

**트랜잭션**: ALL or NOTHING

---

## B.4 PKGSYS_USER (사용자관리)

### CHK_USER (사용자인증)

**목적**: 로그인 사용자 인증

**파라미터**:
| 파라미터 | 방향 | 타입 | 설명 |
|----------|------|------|------|
| A_CLIENT | IN | VARCHAR2 | 클라이언트코드 |
| A_COMPANY | IN | VARCHAR2 | 회사코드 |
| A_SYSTEM | IN | VARCHAR2 | 시스템코드 |
| A_USER_ID | IN | VARCHAR2 | 사용자ID |
| O_CUR | OUT | SYS_REFCURSOR | 사용자정보 |
| O_RESULT | OUT | NUMBER | 결과코드 |
| O_MSG | OUT | VARCHAR2 | 결과메시지 |

**반환**:
- O_RESULT = 0: 인증성공
- O_RESULT = -1: 사용자없음
- O_RESULT = -2: 비밀번호불일치
- O_RESULT = -3: 사용중지
- O_RESULT = -4: 권한없음

---

### PUT_EHR (사원등록)

**목적**: 사원정보 등록/수정

**파라미터**:
| 파라미터 | 방향 | 타입 | 설명 |
|----------|------|------|------|
| A_CLIENT | IN | VARCHAR2 | 클라이언트코드 |
| A_COMPANY | IN | VARCHAR2 | 회사코드 |
| A_USER_ID | IN | VARCHAR2 | 사용자ID |
| A_USERNAME | IN | VARCHAR2 | 사용자명 |
| A_PASSWORD | IN | VARCHAR2 | 비밀번호 (평문) |
| A_DEPTCODE | IN | VARCHAR2 | 부서코드 |
| A_POSTCODE | IN | VARCHAR2 | 직급코드 |
| A_EMAIL | IN | VARCHAR2 | 이메일 |
| A_USEFLAG | IN | VARCHAR2 | 사용여부 |
| A_REGUSER | IN | VARCHAR2 | 등록자 |
| O_RESULT | OUT | NUMBER | 결과코드 |
| O_MSG | OUT | VARCHAR2 | 결과메시지 |

**처리로직**:
1. 비밀번호 암호화 (Triple DES)
2. INSERT 또는 UPDATE
3. 기존 비밀번호 유지 로직 (NULL 입력시)

---

## B.5 PKGHNS_REPORT (행성 리포트)

### GET_MAT_BALANCE (자재수불조회)

**목적**: 자재 수불 현황 조회

**파라미터**:
| 파라미터 | 방향 | 타입 | 설명 |
|----------|------|------|------|
| A_CLIENT | IN | VARCHAR2 | 클라이언트코드 |
| A_COMPANY | IN | VARCHAR2 | 회사코드 |
| A_PLANT | IN | VARCHAR2 | 공장코드 |
| A_PLANDATE | IN | VARCHAR2 | 계획월(YYYYMM) |
| O_CUR | OUT | SYS_REFCURSOR | 결과 커서 |
| O_RESULT | OUT | NUMBER | 결과코드 |

**반환데이터**:
- 품목별 기초/입고/출고/현재고
- 일자별 수불 현황 (1일~31일)

---

## B.6 공통 반환코드

| 코드 | 의미 | 설명 |
|------|------|------|
| 0 | 성공 | 정상처리 |
| -1 | 오류 | 일반오류 |
| -2 | 데이터없음 | 조회결과 없음 |
| -3 | 중복 | 중복데이터 존재 |
| -4 | 제약조건위반 | FK, CK 위반 |
| -9 | 시스템오류 | DB 연결/권한 오류 |

---

**문서 끝**
