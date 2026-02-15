# 프로시저/패키지 상세 명세서

!!! info "자동 생성 문서"
    이 문서는 HANES Oracle DB(MESUSER@CDBHNSMES)에서 자동 추출하여 생성되었습니다.
    최종 추출일: 2026-02-15

## 통계 요약

| 항목 | 수량 |
|------|------|
| 패키지 | **31개** |
| 독립 함수 | **31개** |
| 독립 프로시저 | **4개** |

## 패키지 분류

| 접두어 | 의미 | 패키지 목록 |
|--------|------|-------------|
| `PKGBAS_` | 기준정보 | `PKGBAS_BASE`, `PKGBAS_BRD`, `PKGBAS_MAT` |
| `PKGPRD_` | 생산관리 | `PKGPRD_CHECK`, `PKGPRD_CURRENT`, `PKGPRD_ECC`, `PKGPRD_HIST`, `PKGPRD_MAT`, `PKGPRD_MNT`, `PKGPRD_PROD`, `PKGPRD_QC`, `PKGPRD_REPORT`, `PKGPRD_SALES` |
| `PKGMAT_` | 자재관리 | `PKGMAT_INOUT` |
| `PKGSYS_` | 시스템관리 | `PKGSYS_COMM`, `PKGSYS_DBA`, `PKGSYS_MENU`, `PKGSYS_USER` |
| `PKGPDA_` | PDA(모바일) | `PKGPDA_COMM`, `PKGPDA_MAT`, `PKGPDA_PROD`, `PKGPDA_SALES` |
| `PKGTXN_` | 트랜잭션 | `PKGTXN_GATHERING`, `PKGTXN_MODBUS`, `PKGTXN_STOCK` |
| `PKGIF_` | 인터페이스 | `PKGIF_ERP` |
| `PKGHNS_` | 리포트 | `PKGHNS_REPORT` |
| `PKGDEV_` | 개발용 | `PKGDEV_KBS_TEMP` |
| `GPKG` | 글로벌 | `GPKGBAS_BASE`, `GPKGPRD_PROD` |
| `PCK_` | 기타 | `PCK_GET_NORMDIST` |

---

## 패키지 상세

### GPKGBAS_BASE

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `GET_ITEMTYPE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_ROOTITEM` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_TERMINALFLAG` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PRODLINE_UNIT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_DEF_TYPE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_LOC_TYPE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_WAREHOUSE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_WHLOC` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_UNITCODE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_VENDOR` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PRINTTYPE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_LABELTEXT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_UNITNO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_MODELBOM` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_MODELBOM` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_SEQ_MAPPING` | A_ITEMCODE IN TM_ITEMS.ITEMCODE%TYPE |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         GPKGBAS_BASE IS
    
       /* 품목 유형 조회 */
       PROCEDURE GET_ITEMTYPE( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                               A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                               A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                               N_RETURN        OUT      NUMBER,          /* RETURN VALUE */
                               V_RETURN        OUT      VARCHAR2,        /* RETURN MESSAGE */
                               C_RETURN        OUT      SYS_REFCURSOR    /* RETURN CURSOR */
                             );
    
    
       /* 품목 조회 : 품목마스터 상위 품번 조회 */
       PROCEDURE GET_ROOTITEM( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                               A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                               A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                               N_RETURN        OUT      NUMBER,           /* RETURN VALUE */
                               V_RETURN        OUT      VARCHAR2,       /* RETURN MESSAGE */
                               C_RETURN        OUT      SYS_REFCURSOR    /* RETURN CURSOR */
                             );
    
    
       /* 터미널 구분 조회 */
       PROCEDURE GET_TERMINALFLAG( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                   A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                   A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                   N_RETURN        OUT      NUMBER,             /* RETURN VALUE */
                                   V_RETURN        OUT      VARCHAR2,         /* RETURN MESSAGE */
                                   C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                 );
    
    
       /* 호기 정보 조회 */
       PROCEDURE GET_PRODLINE_UNIT( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                    A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                    A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                    N_RETURN        OUT      NUMBER,       /* RETURN VALUE */
                                    V_RETURN        OUT      VARCHAR2,     /* RETURN MESSAGE */
                                    C_RETURN        OUT      SYS_REFCURSOR /* RETURN CURSOR */
                                  );
    
    
      /* 불량 현상 정보 조회 */
      PROCEDURE GET_DEF_TYPE( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                              V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                              C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                            );
    
    
       /* 위치 유형 조회 */
       PROCEDURE GET_LOC_TYPE( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                               A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                               A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                               N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                               V_RETURN        OUT      VARCHAR2,        /* RETURN MESSAGE */
                               C_RETURN        OUT      SYS_REFCURSOR     /* RETURN CURSOR */
                             );
    
    
      /* 창고 정보 조회 */
      PROCEDURE GET_WAREHOUSE( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                               A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                               A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                               A_VIEW           IN      NUMBER,            /* 0 = USEYN, 1 = ALL, 2 = MAT, 3 = PROD */
                               N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                               V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                               C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                             );
    
    
      /* 위치 정보 조회 */
      PROCEDURE GET_WHLOC( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                           N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                           V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                           C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                         );
    
    
      /* 단위 정보 조회 */
      PROCEDURE GET_UNITCODE( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                              V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                              C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                            );
    
    
       /* 거래처 정보 조회 */
       PROCEDURE GET_VENDOR( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                             A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                             A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                             A_PURCHASE       IN      TM_VENDOR.PRCFLAG%TYPE,
                             A_SALES          IN      TM_VENDOR.SALFLAG%TYPE,
                             A_OUTSC          IN      TM_VENDOR.OSCFLAG%TYPE,
                             A_VIEW           IN      NUMBER,
                             N_RETURN        OUT      NUMBER,        /* RETURN VALUE */
                             V_RETURN        OUT      VARCHAR2,    /* RETURN MESSAGE */
                             C_RETURN        OUT      SYS_REFCURSOR /* RETURN CURSOR */
                           );
                           
                           
       /* 통전검사 라벨 유형 조회 */
       PROCEDURE GET_PRINTTYPE( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                N_RETURN        OUT      NUMBER,        /* RETURN VALUE */
                                V_RETURN        OUT      VARCHAR2,    /* RETURN MESSAGE */
                                C_RETURN        OUT      SYS_REFCURSOR /* RETURN CURSOR */
                              );
                              
                              
       /* 통전검사 법인명칭 라벨 텍스트 조회 */
       PROCEDURE GET_LABELTEXT( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                N_RETURN        OUT      NUMBER,        /* RETURN VALUE */
                                V_RETURN        OUT      VARCHAR2,    /* RETURN MESSAGE */
                                C_RETURN        OUT      SYS_REFCURSOR /* RETURN CURSOR */
                              );    
                              
                              
       /* 공정별 호기 조회 */
       PROCEDURE GET_UNITNO( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                             A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                             A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                             A_OPER           IN      TM_OPERATION.OPER%TYPE,
                             N_RETURN        OUT      NUMBER,        /* RETURN VALUE */
                             V_RETURN        OUT      VARCHAR2,    /* RETURN MESSAGE */
                             C_RETURN        OUT      SYS_REFCURSOR /* RETURN CURSOR */
                           );     
                           
                                            
       /*모델 BOM */
       PROCEDURE GET_MODELBOM ( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                A_VENDOR         IN      TM_MODELBOM.VENDOR%TYPE,
                                A_MODEL          IN      TM_MODELBOM.MODEL%TYPE,
                                N_RETURN        OUT      NUMBER,        /* RETURN VALUE */
                                V_RETURN        OUT      VARCHAR2,    /* RETURN MESSAGE */
                                C_RETURN        OUT      SYS_REFCURSOR /* RETURN CURSOR */
                               );                   
                                     
                              
       /*모델 BOM */
       PROCEDURE PUT_MODELBOM ( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                A_VENDOR         IN      TM_MODELBOM.VENDOR%TYPE,
                                A_WHLOC          IN      TM_MODELBOM.WHLOC%TYPE,
                                A_MODEL          IN      TM_MODELBOM.MODEL%TYPE,
                                A_PARTNO         IN      TM_MODELBOM.PARTNO%TYPE,
                                A_SEQ            IN      TM_MODELBOM.SEQ%TYPE,
                                A_QTY            IN      TM_MODELBOM.ASSYUSAGE%TYPE,
                                A_RATE           IN      TM_MODELBOM.ASSYRATE%TYPE,
                                A_USEFLAG        IN      TM_MODELBOM.USEFLAG%TYPE,
                                A_REMARKS        IN      TM_MODELBOM.REMARKS%TYPE,
                                A_USER           IN      TM_EHR.EHRCODE%TYPE,
                                N_RETURN        OUT      NUMBER,        /* RETURN VALUE */
                                V_RETURN        OUT      VARCHAR2,    /* RETURN MESSAGE */
                                C_RETURN        OUT      SYS_REFCURSOR /* RETURN CURSOR */
                               );
                               
                               
      /*ASSY SEQ 생성 */
      PROCEDURE SET_SEQ_MAPPING ( A_ITEMCODE         IN      TM_ITEMS.ITEMCODE%TYPE);
                               
                                                                          
    END GPKGBAS_BASE;
    ```

**참조 테이블:**

`TM_CLIENT`, `TM_COMMCODE`, `TM_COMPANY`, `TM_EHR`, `TM_ITEMS`, `TM_LOCATION`, `TM_MODELBOM`, `TM_OPERATION`, `TM_PLANT`, `TM_PRODLINE`, `TM_PRODLINE_UNIT`, `TM_UNITCODE`, `TM_VENDOR`, `TM_WAREHOUSE`

---

### GPKGPRD_PROD

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `GET_BOM` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_OPER` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_VENDOR` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_VENDOR` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_ORDTYPE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PARTNO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PARTNO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PARTNO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PARTNO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_DEFECT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_DEFECT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_DEFECT_PDA` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PRODLINE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PRODLINE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PRODLINE_UNIT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_TYPE_UNITNO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_INSP_EQP` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_WORKER` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_REPAIR_SERIAL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_REPAIR_SERIAL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_MAINASSY_WORKORD` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_MAINASSY_SERIAL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_GP12_PARTNO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         GPKGPRD_PROD IS
    
      /* BOM 정보 조회*/
      PROCEDURE GET_BOM( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                         A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                         A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                         N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                         V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                         C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                       );
                     
      
      /* 공정 정보 조회*/
      PROCEDURE GET_OPER( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                          A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                          A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                          N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                          V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                          C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                        );    
                    
      
      /* 업체 정보 조회*/
      PROCEDURE GET_VENDOR( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                            A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                            A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                            N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                            V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                            C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                          );  
                          
                          
      /* 외주업체 정보 조회*/
      PROCEDURE GET_VENDOR( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                            A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                            A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                            A_OSCFLAG      IN      TM_VENDOR.OSCFLAG%TYPE,
                            N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                            V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                            C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                          );                      
                          
                          
      /* 작업 지시 유형 조회*/
      PROCEDURE GET_ORDTYPE( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                             A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                             A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                             N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                             V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                             C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                           );   
                           
                           
      /* 제품 품번 조회*/
      PROCEDURE GET_PARTNO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                            A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                            A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                            N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                            V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                            C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                          ); 
                          
    
      /* 제품 품번 조회*/
      PROCEDURE GET_PARTNO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                            A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                            A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                            A_ITEMTYPE     IN      TM_ITEMS.ITEMTYPE%TYPE,
                            N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                            V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                            C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                          );
                          
                          
      /* 제품 품번 조회*/
      PROCEDURE GET_PARTNO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                            A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                            A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                            A_BOMGRP       IN      TM_BOM.BOMGRP%TYPE,
                            A_OPER         IN      TM_OPERATION.OPER%TYPE,
                            N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                            V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                            C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                          );      
                          
                          
      /* 제품 품번 조회*/
      PROCEDURE GET_PARTNO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                            A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                            A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                            A_BOMGRP       IN      TM_BOM.BOMGRP%TYPE,
                            A_OPER         IN      TM_OPERATION.OPER%TYPE,
                            A_UNITNO       IN      TM_ITEMS.UNITNO%TYPE,
                            N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                            V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                            C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                          );                
                                                
                          
      /* 불량 유형 조회 - 통전검사 불량 유형*/
      PROCEDURE GET_DEFECT( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                            A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                            A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                            N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                            V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                            C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                          );  
                          
                          
      /* 불량 유형 조회 -유형별*/
      PROCEDURE GET_DEFECT( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                            A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                            A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                            A_DEFECTTYPE   IN      TM_DEFECT.DEFECTTYPE%TYPE,
                            N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                            V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                            C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                          );
                          
                          
      /* 불량 유형 조회*/
      PROCEDURE GET_DEFECT_PDA ( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                 V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                 C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                );                        
                          
                          
      /* 생산 라인 조회*/
      PROCEDURE GET_PRODLINE( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                              V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                              C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                            ); 
                         
         
      /* 타입별 생산 라인 조회*/
      PROCEDURE GET_PRODLINE( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              A_TYPE         IN      TM_PRODLINE.TYPE%TYPE,
                              N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                              V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                              C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                             );  
                             
                             
      /* 라이별 생산 호기 조회*/
      PROCEDURE GET_PRODLINE_UNIT( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                   A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                   A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                   A_PRODLINE     IN      TM_PRODLINE.PRODLINE%TYPE,
                                   N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                   V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                   C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                 );                         
                                 
           
      /* 타입별 호기 조회*/
      PROCEDURE GET_TYPE_UNITNO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 A_TYPE         IN      TM_PRODLINE.TYPE%TYPE,
                                 A_PRODLINE     IN      TM_PRODLINE.PRODLINE%TYPE,
                                 N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                 V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                 C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                               );     
                               
    
      /* 통전검사호기 조회*/
      PROCEDURE GET_INSP_EQP( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                              V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                              C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                            );
                             
                             
      /* 작업자 조회*/
      PROCEDURE GET_WORKER( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                            A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                            A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                            N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                            V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                            C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                          );                                                                                                                                                                                 
    
    
      /* 재작업 가능 시리얼 정보*/
      PROCEDURE GET_REPAIR_SERIAL( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                   A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                   A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                   A_ITEMCODE     IN      TM_ITEMS.ITEMCODE%TYPE,
                                   A_UNITNO       IN      TM_PRODLINE_UNIT.UNITNO%TYPE,
                                   N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                   V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                   C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                 );  
                                 
                                 
      /* 재작업 가능 시리얼 정보*/
      PROCEDURE GET_REPAIR_SERIAL( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                   A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                   A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                   A_SERIAL       IN      TM_SERIAL.SERIAL%TYPE,
                                   A_UNITNO       IN      TM_PRODLINE_UNIT.UNITNO%TYPE,
                                   A_USER         IN      TM_EHR.EHRCODE%TYPE,
                                   N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                   V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                   C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                 );                             
                                 
                                 
      /* 통전검사 작업지시 조회*/
      PROCEDURE GET_MAINASSY_WORKORD( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                      A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                      A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                      A_WRKORD       IN      TW_WORKORD.WRKORD%TYPE,
                                      N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                      V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                      C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                    );   
                                    
                                    
      /* 통전검사 외주입고 조회*/
      PROCEDURE GET_MAINASSY_SERIAL( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                     A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                     A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                     A_SERIAL       IN      TM_SERIAL.SERIAL%TYPE,
                                     N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                     V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                     C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                    );          
      
         /* GP12 품목정보 조회 */
       PROCEDURE GET_GP12_PARTNO( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
    	                          A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
    	                          A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
    	                          N_RETURN        OUT      NUMBER,          /* RETURN VALUE */
    	                          V_RETURN        OUT      VARCHAR2,      /* RETURN MESSAGE */
    	                          C_RETURN        OUT      SYS_REFCURSOR   /* RETURN CURSOR */
    	                        );
         
    END GPKGPRD_PROD;
    ```

**참조 테이블:**

`TM_BOM`, `TM_BOMGRP`, `TM_CLIENT`, `TM_COMMCODE`, `TM_COMPANY`, `TM_DEFECT`, `TM_EHR`, `TM_GP12_ITEM`, `TM_ITEMS`, `TM_LOCATION`, `TM_OPERATION`, `TM_PLANT`, `TM_PRODLINE`, `TM_PRODLINE_UNIT`, `TM_SERIAL`, `TM_VENDOR`, `TW_BRD`, `TW_STOCKSERIAL`, `TW_WORKORD`

---

### PCK_GET_NORMDIST

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| FUNC | `ERF` | Z IN NUMBER → NUMBER |
| FUNC | `PHI` | Z IN NUMBER → NUMBER |
| FUNC | `PHI` | Z IN NUMBER, MU IN NUMBER, SIGMA IN NUMBER → NUMBER |
| FUNC | `NORMDIST` | X IN NUMBER, MEAN IN NUMBER, STD IN NUMBER, CUMULATIVE IN... → NUMBER |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         PCK_GET_NORMDIST AS
        
        FUNCTION ERF(Z IN NUMBER) RETURN  NUMBER;
        
        FUNCTION PHI(Z IN NUMBER) RETURN  NUMBER;
        
        FUNCTION PHI(Z IN NUMBER, MU IN NUMBER, SIGMA IN NUMBER) RETURN  NUMBER;
        
        FUNCTION  NORMDIST(X IN NUMBER, MEAN IN NUMBER, STD IN NUMBER, CUMULATIVE IN NUMBER) RETURN  NUMBER;
        
        
    END PCK_GET_NORMDIST;
    ```

**참조 테이블:**

---

### PKGBAS_BASE

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `GET_PLANT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_PLANT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_VENDOR` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_VENDOR` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_OPER` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_OPER` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_REASONCODE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_REASONCODE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_ITEM` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_ITEM` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_ITEM` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_ITEM` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_BOMGRP` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_BOMGRP` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_BOMGRP` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_BOM` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_BOM` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_BOM` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_BOM` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_SUBITEM` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_SUBITEM` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_ROUTINGGRP` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_ROUTINGGRP` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_ROUTING` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_ROUTING` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_ROUTING` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_DEFECT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_DEFECT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_LINE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_LINE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_WAREHOUSE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_WAREHOUSE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_LOCATION` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_LOCATION2` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_LOCATION` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PRODLINE_UNIT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_PRODLINE_UNIT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_EQP` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_EQP` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PARTNO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PRODUNIT_TYPE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_ITEMIMAGE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_ITEMIMAGE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_CLOSINGBASE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_CLOSINGBASE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_SAMPLEIMAGE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_SAMPLEIMAGE2` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_DEFECTIMAGE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_CRIMPINGBASE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_CRIMPINGBASE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_BOM_RELEASE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_BOM_FIND` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ -- A_COMPANY IN TM_COMPANY.COM... |
| PROC | `PUT_BOM_FIND2` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_BOM_SUBITEM` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_BOM_SUBITEM_ALL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_BOMGRP_LIST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_BOM_LIST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_WORKTIME` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_WORKTIME` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_APPLICATOR` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_APPLICATORDETAIL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_APPLICATOR` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_JIGPIN` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_JIGPINDETAIL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_JIGPIN` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_GP12_ITEM` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_GP12_ITEM` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         PKGBAS_BASE IS
    
      /* 사유코드 순번 */
      FUNCTION SET_REASONCODE
        RETURN TM_REASON.REASONCODE%TYPE ;
        
      /* 공장 정보 조회 */
       PROCEDURE GET_PLANT( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                            A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                            A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                            A_VIEW           IN      NUMBER,
                            N_RETURN        OUT      NUMBER,          /* RETURN VALUE */
                            V_RETURN        OUT      VARCHAR2,      /* RETURN MESSAGE */
                            C_RETURN        OUT      SYS_REFCURSOR   /* RETURN CURSOR */
                           );
    
    
       /* 공장 정보 등록 */
       PROCEDURE PUT_PLANT( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                            A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                            A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                            A_PLANTNAME      IN      TM_PLANT.PLANTNAME%TYPE,
                            A_USEFLAG        IN      TM_PLANT.USEFLAG%TYPE,
                            A_REMARKS        IN      TM_PLANT.REMARKS%TYPE,
                            A_USERID         IN      TM_PLANT.CREATEUSER%TYPE,
                            A_NEWFLAG        IN      VARCHAR2,        /* 'Y' or 'N' */
                            N_RETURN        OUT      NUMBER,        /* RETURN VALUE */
                            V_RETURN        OUT      VARCHAR2,    /* RETURN MESSAGE */
                            C_RETURN        OUT      SYS_REFCURSOR /* RETURN CURSOR */
                          );  
        
      
       /* 거래처 정보 조회*/
       PROCEDURE GET_VENDOR( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                             A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                             A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                             A_PURCHASE       IN      TM_VENDOR.PRCFLAG%TYPE,
                             A_SALES          IN      TM_VENDOR.SALFLAG%TYPE,
                             A_OUTSC          IN      TM_VENDOR.OSCFLAG%TYPE,
                             A_VIEW           IN      NUMBER,
                             N_RETURN        OUT      NUMBER,        /* RETURN VALUE */
                             V_RETURN        OUT      VARCHAR2,    /* RETURN MESSAGE */
                             C_RETURN        OUT      SYS_REFCURSOR /* RETURN CURSOR */
                           );
                    
                
       /* 거래처 정보 등록*/
       PROCEDURE PUT_VENDOR( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                             A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                             A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                             A_VENDOR         IN      TM_VENDOR.VENDOR%TYPE, /* UPDATE CASE */
                             A_VENDORNAME     IN      TM_VENDOR.VENDORNAME%TYPE,
                             A_MAKER          IN      TM_VENDOR.MAKER%TYPE,
                             A_ENTRYNO        IN      TM_VENDOR.ENTRYNO%TYPE,
                             A_CEONAME        IN      TM_VENDOR.CEONAME%TYPE,
                             A_PHONE          IN      TM_VENDOR.PHONE%TYPE,
                             A_FAXNO          IN      TM_VENDOR.FAXNO%TYPE,
                             A_ADDRESS        IN      TM_VENDOR.ADDRESS%TYPE,
                             A_PRCFLAG        IN      TM_VENDOR.PRCFLAG%TYPE,
                             A_SALFLAG        IN      TM_VENDOR.SALFLAG%TYPE,
                             A_OSCFLAG        IN      TM_VENDOR.OSCFLAG%TYPE,
                             A_USEFLAG        IN      TM_VENDOR.USEFLAG%TYPE,
                             A_REMARKS        IN      TM_VENDOR.REMARKS%TYPE,
                             A_USER           IN      TM_VENDOR.CREATEUSER%TYPE,
                             A_NEWFLAG        IN      VARCHAR2,
                             N_RETURN        OUT      NUMBER,      /* RETURN VALUE */
                             V_RETURN        OUT      VARCHAR2   /* RETURN MESSAGE */
                           );                        
                                   
                             
       /* 공정 정보 조회*/
       PROCEDURE GET_OPER( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                           A_VIEW           IN      NUMBER,
                           N_RETURN        OUT      NUMBER,           /* RETURN VALUE */
                           V_RETURN        OUT      VARCHAR2,         /* RETURN MESSAGE */
                           C_RETURN        OUT      SYS_REFCURSOR     /* RETURN CURSOR */
                         );   
                          
                          
       /* 공정 정보 등록 */
       PROCEDURE PUT_OPER( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                           A_OPER           IN      TM_OPERATION.OPER%TYPE,
                           A_OPERNAME       IN      TM_OPERATION.OPERNAME%TYPE,
                           A_OPERTYPE       IN      TM_OPERATION.OPERTYPE%TYPE,
                           A_PERMISSIONRATE IN      TM_OPERATION.PERMISSIONRATE%TYPE,
                           A_PRECEDE        IN      TM_OPERATION.PRECEDE%TYPE,
                           A_REMARKS        IN      TM_OPERATION.REMARKS%TYPE,
                           A_OPERATOR       IN      TM_OPERATION.CREATEUSER%TYPE,
                           A_USEFLAG        IN      TM_OPERATION.USEFLAG%TYPE,
                           A_NEWFLAG        IN      VARCHAR2,       /* 'Y' or 'N' */
                           N_RETURN        OUT      NUMBER,         /* RETURN VALUE */
                           V_RETURN        OUT      VARCHAR2,       /* RETURN MESSAGE */
                           C_RETURN        OUT      SYS_REFCURSOR   /* RETURN CURSOR */
                          );   
                           
                           
       /* 사유 정보 조회 */
       PROCEDURE GET_REASONCODE( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 A_REASONTYPE     IN      TM_REASON.REASONTYPE%TYPE,
                                 A_VIEW           IN      NUMBER,       /* 0 = USEYN, 1 = ALL */
                                 N_RETURN        OUT      NUMBER,       /* RETURN VALUE */
                                 V_RETURN        OUT      VARCHAR2,     /* RETURN MESSAGE */
                                 C_RETURN        OUT      SYS_REFCURSOR /* RETURN CURSOR */
                               ); 
                                 
                                 
       /* 사유코드 정보 등록 */
       PROCEDURE PUT_REASONCODE( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 A_REASONCODE     IN      TM_REASON.REASONCODE%TYPE,
                                 A_REASON         IN      TM_REASON.REASON%TYPE,
                                 A_DISPSEQ        IN      TM_REASON.DISPSEQ%TYPE,
                                 A_REASONTYPE     IN      TM_REASON.REASONTYPE%TYPE,
                                 A_USEFLAG        IN      TM_REASON.USEFLAG%TYPE,
                                 A_REMARKS        IN      TM_REASON.REMARKS%TYPE,
                                 A_USERID         IN      TM_REASON.CREATEUSER%TYPE,
                                 A_NEWFLAG        IN      VARCHAR2,/* 'Y' or 'N' */
                                 N_RETURN        OUT      NUMBER,  /* RETURN VALUE */
                                 V_RETURN        OUT      VARCHAR2 /* RETURN MESSAGE */
                                );  
                                 
                                 
       /* 품목 정보 조회 : 전체 */
       PROCEDURE GET_ITEM( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                           A_VIEW           IN      NUMBER,
                           N_RETURN        OUT      NUMBER,           /* RETURN VALUE */
                           V_RETURN        OUT      VARCHAR2,         /* RETURN MESSAGE */
                           C_RETURN        OUT      SYS_REFCURSOR     /* RETURN CURSOR */
                          );
                           
                           
       /* 품목 정보 조회 : 품목 유형별 */
       PROCEDURE GET_ITEM( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                           A_VIEW           IN      NUMBER,
                           A_ITEMTYPE       IN      TM_ITEMS.ITEMTYPE%TYPE,
                           N_RETURN        OUT      NUMBER,           /* RETURN VALUE */
                           V_RETURN        OUT      VARCHAR2,         /* RETURN MESSAGE */
                           C_RETURN        OUT      SYS_REFCURSOR     /* RETURN CURSOR */
                          );                       
                           
                           
       /* 품목 정보 등록 */
       PROCEDURE PUT_ITEM( A_CLIENT             IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY            IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT              IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                           A_ITEMCODE           IN      TM_ITEMS.ITEMCODE%TYPE,
                           A_ITEMNAME           IN      TM_ITEMS.ITEMNAME%TYPE,
                           A_PARTNO             IN      TM_ITEMS.PARTNO%TYPE,
                           A_CUSTPARTNO         IN      TM_ITEMS.CUSTPARTNO%TYPE,
                           A_SPEC               IN      TM_ITEMS.SPEC%TYPE,
                           A_TOOL               IN      TM_ITEMS.TOOL%TYPE,
                           A_SIZE               IN      TM_ITEMS.PARTNOSIZE%TYPE,
                           A_TYPE               IN      TM_ITEMS.PARTNOTYPE%TYPE,
                           A_ROOTITEM           IN      TM_ITEMS.ROOTITEM%TYPE,
                           A_REV                IN      TM_ITEMS.REV%TYPE,
                           A_ITEMTYPE           IN      TM_ITEMS.ITEMTYPE%TYPE,
                           A_UNITCODE           IN      TM_ITEMS.UNITCODE%TYPE,
                           A_LOTUNITQTY         IN      TM_ITEMS.LOTUNITQTY%TYPE,
                           A_BOXQTY             IN      TM_ITEMS.BOXQTY%TYPE,
                           A_SAFTYQTY           IN      TM_ITEMS.SAFTYQTY%TYPE,
                           A_VALIDFROMDATE      IN      TM_ITEMS.VALIDFROMDATE%TYPE,
                           A_TERMINALFLAG       IN      TM_ITEMS.TERMINALFLAG%TYPE,
                           A_CURRFLOWINSFLAG    IN      TM_ITEMS.CURRFLOWINSFLAG%TYPE,
                           A_UNITNO             IN      TM_ITEMS.UNITNO%TYPE,
                           A_PRINTUNIT          IN      TM_ITEMS.PRINTUNIT%TYPE,
                           A_QTYOUTFLAG         IN      TM_ITEMS.QTYOUTFLAG%TYPE,
                           A_QTYPACKFLAG        IN      TM_ITEMS.QTYPACKFLAG%TYPE,
                           A_PRINTTYPE          IN      TM_ITEMS.PRINTTYPE%TYPE,
                           A_TACTTIME           IN      TM_ITEMS.TACTTIME%TYPE,
                           A_VISUALTACTTIME     IN      TM_ITEMS.VISUALTACTTIME%TYPE,
                           A_EXPIRYDATE         IN      TM_ITEMS.EXPIRYDATE%TYPE,
                           A_LONGTERMDATE       IN      TM_ITEMS.LONGTERMDATE%TYPE,
                           A_LABELTEXT          IN      TM_ITEMS.LABELTEXT%TYPE,
                           A_USEFLAG            IN      TM_ITEMS.USEFLAG%TYPE,
                           A_REMARKS            IN      TM_ITEMS.REMARKS%TYPE,
                           A_USER               IN      TM_ITEMS.CREATEUSER%TYPE,    
                           N_RETURN            OUT      NUMBER,                     /* RETURN VALUE */
                           V_RETURN            OUT      VARCHAR2,                 /* RETURN MESSAGE */
                           C_RETURN            OUT      SYS_REFCURSOR              /* RETURN CURSOR */
                         );
                         
                         
      /* 아이템 정보 등록 */
      PROCEDURE PUT_ITEM( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                          A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                          A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                          A_XML            IN      CLOB,
                          A_USERID         IN      TM_ITEMS.CREATEUSER%TYPE,
                          N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                          V_RETURN        OUT      VARCHAR2           /* RETURN MESSAGE */
                        );                     
                           
                           
       /* BOM 그룹 정보 */
       PROCEDURE GET_BOMGRP( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                             A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                             A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                             N_RETURN        OUT      NUMBER,          /* RETURN VALUE */
                             V_RETURN        OUT      VARCHAR2,        /* RETURN MESSAGE */
                             C_RETURN        OUT      SYS_REFCURSOR    /* RETURN CURSOR */
                            );
                            
                            
      /* BOM 그룹 정보 등록 : 전체 */
       PROCEDURE PUT_BOMGRP( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                             A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                             A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                             A_BOMGRP         IN      TM_BOMGRP.BOMGRP%TYPE,
                             A_GRPREV         IN      TM_BOMGRP.REV%TYPE,
                             A_FPATH          IN      TM_BOMGRP.FPATH%TYPE,
                             A_USEFLAG        IN      TM_BOMGRP.USEFLAG%TYPE,
                             A_STARTDATE      IN      TM_BOMGRP.STARTDATE%TYPE,
                             A_ENDDATE        IN      TM_BOMGRP.ENDDATE%TYPE,
                             A_USER           IN      TM_BOMGRP.CREATEUSER%TYPE,
                             N_RETURN        OUT      NUMBER,       /* RETURN VALUE */
                             V_RETURN        OUT      VARCHAR2,   /* RETURN MESSAGE */
                             C_RETURN        OUT      SYS_REFCURSOR /* RETURN CURSOR */
                           ); 
                             
                             
    /* BOM 그룹 정보 등록 :  사용여부 변경 */
       PROCEDURE PUT_BOMGRP( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                             A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                             A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                             A_BOMGRP         IN      TM_BOMGRP.BOMGRP%TYPE,
                             A_GRPREV         IN      TM_BOMGRP.REV%TYPE,
                             A_USEFLAG        IN      TM_BOMGRP.USEFLAG%TYPE,
                             A_USER           IN      TM_BOMGRP.CREATEUSER%TYPE,
                             N_RETURN        OUT      NUMBER,      /* RETURN VALUE */
                             V_RETURN        OUT      VARCHAR2     /* RETURN MESSAGE */
                           );                                            
                            
                            
       /* BOM 전체 조회 */
       PROCEDURE GET_BOM( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                          A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                          A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                          A_VIEW           IN      NUMBER,            /* 0 = USEYN, 1 = ALL */
                          N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                          V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                          C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                        );
                         
                         
       /* BOM 정보 조회 [BOM 마스터] */
       PROCEDURE GET_BOM( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                          A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                          A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                          A_BOMGRP         IN      TM_BOM.BOMGRP%TYPE,
                          A_GRPREV         IN      TM_BOM.REV%TYPE,
                          N_RETURN        OUT      NUMBER,             /* RETURN VALUE */
                          V_RETURN        OUT      VARCHAR2,         /* RETURN MESSAGE */
                          C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                        );
                          
                          
      /* BOM 정보 등록 */
      PROCEDURE PUT_BOM( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                         A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                         A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                         A_BOMGRP         IN      TM_BOM.BOMGRP%TYPE,
                         A_GRPREV         IN      TM_BOM.REV%TYPE,
                         A_XML            IN      CLOB,
                         A_FPATH          IN      TM_BOMGRP.FPATH%TYPE,
                         A_USERID         IN      TM_BOM.CREATEUSER%TYPE,
                         N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                         V_RETURN        OUT      VARCHAR2,           /* RETURN MESSAGE */
                         C_RETURN1        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                       );
                       
                        
       /* BOM 등록 */
       PROCEDURE PUT_BOM( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                          A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                          A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                          A_BOMGRP         IN      TM_BOM.BOMGRP%TYPE,
                          A_GRPREV         IN      TM_BOM.REV%TYPE,
                          A_ITEM           IN      TM_BOM.ITEMCODE%TYPE,
                          A_UPRITEM        IN      TM_BOM.UPRITEM%TYPE,
                          A_UPRPARENTITEM  IN      TM_BOM.UPRITEM%TYPE,
                          A_SEQ            IN      TM_BOM.SEQ%TYPE,
                          A_USAGE          IN      TM_BOM.ASSYUSAGE%TYPE,
                          A_SIDE           IN      TM_BOM.SIDE%TYPE,
                          A_LOCATION       IN      TM_BOM.REMARKS%TYPE,
                          A_STARTDATE      IN      TM_BOM.STARTDATE%TYPE,
                          A_ENDDATE        IN      TM_BOM.ENDDATE%TYPE,
                          A_USEFLAG        IN      TM_BOM.USEFLAG%TYPE,
                          A_OPER           IN      TM_BOM.OPER%TYPE,
                          A_REPLACEFLAG    IN      TM_BOM.REPLACEFLAG%TYPE,
                          A_USERID         IN      TM_BOM.CREATEUSER%TYPE,
                          N_RETURN        OUT      NUMBER,      /* RETURN VALUE */
                          V_RETURN        OUT      VARCHAR2     /* RETURN MESSAGE */
                         );
                         
                         
       /* BOM 대체 자재 조회 */
       PROCEDURE GET_SUBITEM( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              A_IDX            IN      TM_BOM.IDX%TYPE,
                              N_RETURN        OUT      NUMBER,         /* RETURN VALUE */
                              V_RETURN        OUT      VARCHAR2,       /* RETURN MESSAGE */
                              C_RETURN        OUT      SYS_REFCURSOR   /* RETURN CURSOR */
                            );
                              
                              
       /* BOM 대체자재 등록 */
       PROCEDURE PUT_SUBITEM( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              A_IDX            IN      TM_BOM.IDX%TYPE,
                              A_PARTNO         IN      TM_ITEMS.PARTNO%TYPE,
                              A_SEQ            IN      TM_SUBITEMS.SEQ%TYPE,
                              A_USEFLAG        IN      TM_PLANT.USEFLAG%TYPE,
                              A_USERID         IN      TM_PLANT.CREATEUSER%TYPE,
                              N_RETURN        OUT      NUMBER,        /* RETURN VALUE */
                              V_RETURN        OUT      VARCHAR2       /* RETURN MESSAGE */
                            );  
                              
                              
       /* 라우팅 그룹 정보 조회 */
       PROCEDURE GET_ROUTINGGRP( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 A_VIEW           IN      NUMBER,         /* 0 = USEYN, 1 = ALL */
                                 N_RETURN        OUT      NUMBER,         /* RETURN VALUE */
                                 V_RETURN        OUT      VARCHAR2,       /* RETURN MESSAGE */
                                 C_RETURN        OUT      SYS_REFCURSOR   /* RETURN CURSOR */
                                );
                                
                                
       /* 라우팅 그룹 정보 등록*/
       PROCEDURE PUT_ROUTINGGRP( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 A_ROUTEGRP       IN      TM_ROUTINGGRP.ROUTEGRP%TYPE,
                                 A_ITEMCODE       IN      TM_ROUTINGGRP.ITEMCODE%TYPE,
                                 A_USEFLAG        IN      TM_REASON.USEFLAG%TYPE,
                                 A_REMARKS        IN      TM_REASON.REMARKS%TYPE,
                                 A_EHRCODE        IN      TM_REASON.CREATEUSER%TYPE,
                                 A_NEWFLAG        IN      VARCHAR2,       /* 'Y' or 'N' */
                                 C_RETURN        OUT      SYS_REFCURSOR,  /* RETURN CURSOR */
                                 N_RETURN        OUT      NUMBER,         /* RETURN VALUE */
                                 V_RETURN        OUT      VARCHAR2        /* RETURN MESSAGE */
                               );                               
                                
                                
       /* 라우팅 정보 조회 */
       PROCEDURE GET_ROUTING( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              A_ROUTEGRP       IN      TM_ROUTING.ROUTEGRP%TYPE,
                              A_VIEW           IN      NUMBER,         /* 0 = USEYN, 1 = ALL */
                              N_RETURN        OUT      NUMBER,         /* RETURN VALUE */
                              V_RETURN        OUT      VARCHAR2,       /* RETURN MESSAGE */
                              C_RETURN        OUT      SYS_REFCURSOR   /* RETURN CURSOR */
                            );
                              
                              
    /* 라우팅 정보 조회 : 품번 */
       PROCEDURE GET_ROUTING( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              A_ITEMCODE       IN      TM_ITEMS.ITEMCODE%TYPE,
                              N_RETURN        OUT      NUMBER,                /* RETURN VALUE */
                              V_RETURN        OUT      VARCHAR2,              /* RETURN MESSAGE */
                              C_RETURN        OUT      SYS_REFCURSOR          /* RETURN CURSOR */
                            );
                              
                              
       /* 라우팅 정보 등록*/
       PROCEDURE PUT_ROUTING( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              A_ROUTEGRP       IN      TM_ROUTING.ROUTEGRP%TYPE,
                              A_ROUTE          IN      TM_ROUTING.ROUTE%TYPE,
                              A_OPER           IN      TM_ROUTING.OPER%TYPE,
                              A_UPRROUTE       IN      TM_ROUTING.UPRROUTE%TYPE,
                              A_ITEMCODE       IN      TM_ROUTING.ITEMCODE%TYPE,
                              A_ROUTETYPE      IN      TM_ROUTING.ROUTETYPE%TYPE,
                              A_INSPFLAG       IN      TM_ROUTING.INSPFLAG%TYPE,
                              A_BOMITEMUSEFLAG IN      TM_ROUTING.BOMITEMUSEFLAG%TYPE,
                              A_USEFLAG        IN      TM_REASON.USEFLAG%TYPE,
                              A_REMARKS        IN      TM_REASON.REMARKS%TYPE,
                              A_EHRCODE        IN      TM_REASON.CREATEUSER%TYPE,
                              A_NEWFLAG        IN      VARCHAR2,                   /* 'Y' or 'N' */
                              C_RETURN        OUT      SYS_REFCURSOR,              /* RETURN CURSOR */
                              N_RETURN        OUT      NUMBER,                     /* RETURN VALUE */
                              V_RETURN        OUT      VARCHAR2                    /* RETURN MESSAGE */
                            );  
                              
                              
      /* 불량 정보 조회 */
      PROCEDURE GET_DEFECT( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                            A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                            A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                            A_VIEW           IN      NUMBER,            /* 0 = USEYN, 1 = ALL */
                            N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                            V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                            C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                          );     
                           
                           
      /* 불량 정보 등록 */
      PROCEDURE PUT_DEFECT( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                            A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                            A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                            A_DEFECT         IN      TM_DEFECT.DEFECT%TYPE,
                            A_DEFECTNAME     IN      TM_DEFECT.DEFECTNAME%TYPE,
                            A_DEFECTTYPE     IN      TM_DEFECT.DEFECTTYPE%TYPE,
                            A_USEFLAG        IN      TM_DEFECT.USEFLAG%TYPE,
                            A_REMARKS        IN      TM_DEFECT.REMARKS%TYPE,
                            A_USERID         IN      TM_DEFECT.CREATEUSER%TYPE,
                            A_NEWFLAG        IN      VARCHAR2,          /* 'Y' or 'N' */
                            N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                            V_RETURN        OUT      VARCHAR2           /* RETURN MESSAGE */
                          );           
                          
                          
       /* 라인 정보 조회 */
       PROCEDURE GET_LINE( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                           A_VIEW           IN      NUMBER,
                           N_RETURN        OUT      NUMBER,           /* RETURN VALUE */
                           V_RETURN        OUT      VARCHAR2,         /* RETURN MESSAGE */
                           C_RETURN        OUT      SYS_REFCURSOR     /* RETURN CURSOR */
                         );                                                                                                                                                         
                                
                          
      /* 라인 정보 등록 */
       PROCEDURE PUT_LINE( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                           A_PRODLINE       IN      TM_PRODLINE.PRODLINE%TYPE,
                           A_PRODLINENAME   IN      TM_PRODLINE.PRODLINENAME%TYPE,
                           A_OPER           IN      TM_PRODLINE.OPER%TYPE,
                           A_ERPCODE        IN      TM_PRODLINE.ERPCODE%TYPE,
                           A_USEFLAG        IN      TM_PRODLINE.USEFLAG%TYPE,
                           A_REMARKS        IN      TM_PRODLINE.REMARKS%TYPE,
                           A_USERID         IN      TM_PRODLINE.CREATEUSER%TYPE,
                           A_NEWFLAG        IN      VARCHAR2,  /* 'Y' or 'N' */
                           N_RETURN        OUT      NUMBER,    /* RETURN VALUE */
                           V_RETURN        OUT      VARCHAR2   /* RETURN MESSAGE */
                         );
    
    
      /* 창고 정보 조회 */
      PROCEDURE GET_WAREHOUSE( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                               A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                               A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                               A_VIEW           IN      NUMBER,            /* 0 = USEYN, 1 = ALL, 2 = MAT, 3 = PROD */
                               N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                               V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                               C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                             );                      
                          
      
      /* 창고 정보 등록 */
      PROCEDURE PUT_WAREHOUSE( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                               A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                               A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */ 
                               A_WAREHOUSE      IN      TM_WAREHOUSE.WAREHOUSE%TYPE,
                               A_WAREHOUSENAME  IN      TM_WAREHOUSE.WAREHOUSENAME%TYPE,
                               A_WAREHOUSETYPE  IN      TM_WAREHOUSE.WAREHOUSETYPE%TYPE,
                               A_VENDOR         IN      TM_WAREHOUSE.VENDOR%TYPE,
                               A_USEFLAG        IN      TM_WAREHOUSE.USEFLAG%TYPE,
                               A_REMARKS        IN      TM_WAREHOUSE.REMARKS%TYPE,
                               A_USERID         IN      TM_WAREHOUSE.CREATEUSER%TYPE,
                               A_NEWFLAG        IN      VARCHAR2,          /* 'Y' or 'N' */
                               N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                               V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                               C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                             );
                                                   
                          
       /* 위치 정보 조회 */
       PROCEDURE GET_LOCATION( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                               A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                               A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                               A_WAREHOUSE      IN      TM_WAREHOUSE.WAREHOUSE%TYPE,
                               A_VIEW           IN      NUMBER,
                               N_RETURN        OUT      NUMBER,                       /* RETURN VALUE */
                               V_RETURN        OUT      VARCHAR2,                     /* RETURN MESSAGE */
                               C_RETURN        OUT      SYS_REFCURSOR                 /* RETURN CURSOR */
                             );
                             
       PROCEDURE GET_LOCATION2 ( A_CLIENT          IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY         IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT           IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 A_VIEW            IN      NUMBER,
                                 N_RETURN          OUT     NUMBER,                       /* RETURN VALUE */
                                 V_RETURN          OUT     VARCHAR2,                     /* RETURN MESSAGE */
                                 C_RETURN          OUT     SYS_REFCURSOR                 /* RETURN CURSOR */
                               );                        
                               
      /* 위치 정보 등록 */
      PROCEDURE PUT_LOCATION( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              A_WHLOC          IN      TM_LOCATION.WHLOC%TYPE,
                              A_WHLOCNAME      IN      TM_LOCATION.WHLOCNAME%TYPE,
                              A_WAREHOUSE      IN      TM_LOCATION.WAREHOUSE%TYPE,
                              A_PRODLINE       IN      TM_LOCATION.PRODLINE%TYPE,
                              A_USEFLAG        IN      TM_LOCATION.USEFLAG%TYPE,
                              A_REMARKS        IN      TM_LOCATION.REMARKS%TYPE,
                              A_LOCTYPE        IN      TM_LOCATION.LOCTYPE%TYPE,
                              A_BADWHFLAG      IN      TM_LOCATION.BADWHFLAG%TYPE,
                              A_RETRIEVALFLAG  IN      TM_LOCATION.RETRIEVALFLAG%TYPE,
                              A_STOCKINSPFLAG  IN      TM_LOCATION.STOCKINSPFLAG%TYPE,
                              A_SERIALDESTFLAG IN      TM_LOCATION.SERIALDESTFLAG%TYPE,
                              A_VENDOR         IN      TM_LOCATION.VENDOR%TYPE,
                              A_ERPLOCCODE     IN      TM_LOCATION.ERPLOCCODE%TYPE,
                              A_USERID         IN      TM_LOCATION.CREATEUSER%TYPE,
                              A_PURCHASEFLAG   IN      TM_LOCATION.PURCHASEFLAG%TYPE,
                              A_REPAIRFLAG     IN      TM_LOCATION.REPAIRFLAG%TYPE,
                              A_OTHERINFLAG    IN      TM_LOCATION.OTHERINFLAG%TYPE,
                              A_PUBFLAG        IN      TM_LOCATION.PUBFLAG%TYPE,
                              A_FIFOFLAG       IN      TM_LOCATION.FIFOFLAG%TYPE,
                              A_NEWFLAG        IN      VARCHAR2,          /* 'Y' or 'N' */
                              N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                              V_RETURN        OUT      VARCHAR2           /* RETURN MESSAGE */
                            );    
                             
                             
       /* 호기 정보 조회 */
       PROCEDURE GET_PRODLINE_UNIT( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                    A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                    A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                    N_RETURN        OUT      NUMBER,         /* RETURN VALUE */
                                    V_RETURN        OUT      VARCHAR2,       /* RETURN MESSAGE */
                                    C_RETURN        OUT      SYS_REFCURSOR   /* RETURN CURSOR */
                                   );
                                   
                                   
       /* 호기 정보 저장 */
       PROCEDURE PUT_PRODLINE_UNIT( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                    A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                    A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                    A_UNITNO         IN      TM_PRODLINE_UNIT.UNITNO%TYPE,
                                    A_UNITNM         IN      TM_PRODLINE_UNIT.UNITNM%TYPE,
                                    A_UNITTYPE       IN      TM_PRODLINE_UNIT.UNITTYPE%TYPE,
                                    A_PRODLINE       IN      TM_PRODLINE_UNIT.PRODLINE%TYPE,
                                    A_USEFLAG        IN      TM_PRODLINE_UNIT.USEFLAG%TYPE,
                                    A_USER           IN      TM_PRODLINE_UNIT.CREATEUSER%TYPE,
                                    A_NEWFLAG        IN      VARCHAR2,
                                    N_RETURN        OUT      NUMBER,
                                    V_RETURN        OUT      VARCHAR2
                                  );           
                                    
                                    
      /* 설비 정보 조회 */
      PROCEDURE GET_EQP( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                         A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                         A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                         N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                         V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                         C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                       );  
                        
                        
      /* 설비 정보 등록 */
      PROCEDURE PUT_EQP( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                         A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                         A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                         A_EQP            IN      TM_EQP.EQP%TYPE,
                         A_EQPNAME        IN      TM_EQP.EQPNAME%TYPE,
                         A_WHLOC          IN      TM_EQP.WHLOC%TYPE,
                         A_MAKER          IN      TM_EQP.MAKER%TYPE,
                         A_USEFLAG        IN      TM_EQP.USEFLAG%TYPE,
                         A_REMARKS        IN      TM_EQP.REMARKS%TYPE,
                         A_USER           IN      TM_EQP.CREATEUSER%TYPE,
                         N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                         V_RETURN        OUT      VARCHAR2           /* RETURN MESSAGE */
                       );   
                       
      -- 품번 정보
      PROCEDURE GET_PARTNO( A_CLIENT       IN  TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                            A_COMPANY      IN  TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                            A_PLANT        IN  TM_PLANT.PLANT%TYPE, /* 공장코드 */
                            N_RETURN      OUT  NUMBER,            /* RETURN VALUE */
                            V_RETURN      OUT  VARCHAR2,          /* RETURN MESSAGE */
                            C_RETURN      OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                          );
                          
                          
      /* 설비 유형 조회*/
      PROCEDURE GET_PRODUNIT_TYPE( A_CLIENT       IN  TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                   A_COMPANY      IN  TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                   A_PLANT        IN  TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                   N_RETURN      OUT  NUMBER,            /* RETURN VALUE */
                                   V_RETURN      OUT  VARCHAR2,          /* RETURN MESSAGE */
                                   C_RETURN      OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                                 ); 
                                 
      /*이미지 관리*/
      PROCEDURE GET_ITEMIMAGE( A_CLIENT       IN  TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                               A_COMPANY      IN  TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                               A_PLANT        IN  TM_PLANT.PLANT%TYPE, /* 공장코드 */
                               N_RETURN      OUT  NUMBER,            /* RETURN VALUE */
                               V_RETURN      OUT  VARCHAR2,           /* RETURN MESSAGE */
                               C_RETURN      OUT  SYS_REFCURSOR         /* RETURN CURSOR */
                              );
    
                                
      /*이미지 관리(압착검사 SPEC)*/
      PROCEDURE SET_ITEMIMAGE( A_CLIENT       IN  TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                               A_COMPANY      IN  TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                               A_PLANT        IN  TM_PLANT.PLANT%TYPE, /* 공장코드 */
                               A_WIRE         IN  TM_CRIMPINSP.WIRE%TYPE,
                               A_TERMINAL     IN  TM_CRIMPINSP.TERMINAL%TYPE,
                               A_CCHLOW       IN  TM_CRIMPINSP.CCHLOW%TYPE,
                               A_CCHHIGH      IN  TM_CRIMPINSP.CCHHIGH%TYPE,
                               A_CCWLOW       IN  TM_CRIMPINSP.CCWLOW%TYPE,
                               A_CCWHIGH      IN  TM_CRIMPINSP.CCWHIGH%TYPE,
                               A_ICHLOW       IN  TM_CRIMPINSP.ICHLOW%TYPE,
                               A_ICHHIGH      IN  TM_CRIMPINSP.ICHHIGH%TYPE,
                               A_ICWLOW       IN  TM_CRIMPINSP.ICWLOW%TYPE,
                               A_ICWHIGH      IN  TM_CRIMPINSP.ICWHIGH%TYPE,
                               A_TENLOW       IN  TM_CRIMPINSP.TENLOW%TYPE,
                               A_TENHIGH      IN  TM_CRIMPINSP.TENHIGH%TYPE,
                               A_RESISLOW     IN  TM_CRIMPINSP.RESISLOW%TYPE,
                               A_RESISHIGH    IN  TM_CRIMPINSP.RESISHIGH%TYPE,
                               A_IMGWIRE      IN  TM_CRIMPINSP.IMGWIRE%TYPE,
                               A_IMGTERMINAL  IN  TM_CRIMPINSP.IMGTERMINAL%TYPE,
                               A_USEFLAG      IN  TM_CRIMPINSP.USEFLAG%TYPE,
                               A_REMARKS      IN  TM_CRIMPINSP.REMARKS%TYPE,
                               A_USERID       IN  TM_CRIMPINSP.CREATEUSER%TYPE, 
                               N_RETURN      OUT  NUMBER,            /* RETURN VALUE */
                               V_RETURN      OUT  VARCHAR2           /* RETURN MESSAGE */
                              );    
                              
      /* 마감기준월 */
       PROCEDURE GET_CLOSINGBASE(A_CLIENT          IN  TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY         IN  TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT           IN  TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 N_RETURN         OUT  NUMBER,            /* RETURN VALUE */
                                 V_RETURN         OUT  VARCHAR2,           /* RETURN MESSAGE */
                                 C_RETURN         OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                                );    
                                
                                 
                                
      /* 마감기준월 */                           
      PROCEDURE PUT_CLOSINGBASE (
                                 A_CLIENT                IN  TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY               IN  TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT                 IN  TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 A_CLOSINGMONTH          IN     TM_CLOSINGBASE.CLOSINGMONTH%TYPE,
                                 A_FROMDATE              IN     TM_CLOSINGBASE.FROMDATE%TYPE,
                                 A_TODATE                IN     TM_CLOSINGBASE.TODATE%TYPE,
                                 A_USERID                IN     TM_EHR.EHRCODE%TYPE,
                                 A_NEWFLAG               IN     VARCHAR2,
                                 N_RETURN               OUT     NUMBER,
                                 V_RETURN               OUT     VARCHAR2,
                                 C_RETURN               OUT     SYS_REFCURSOR      /* RETURN CURSOR */);       
                                 
                                                                     
      /*이미지 관리*/
      PROCEDURE SET_SAMPLEIMAGE( A_CLIENT       IN  TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY      IN  TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT        IN  TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 A_ITEMCODE     IN  TM_ITEMS.ITEMCODE%TYPE,
                                 A_IMAGE        IN  TM_ITEMS.IMAGE%TYPE,
                                 A_USERID       IN  TH_CRIMP_IMAGE.CREATEUSER%TYPE, 
                                 N_RETURN      OUT  NUMBER,            /* RETURN VALUE */
                                 V_RETURN      OUT  VARCHAR2           /* RETURN MESSAGE */
                               );
                               
                              
       /*이미지 관리*/
      PROCEDURE SET_SAMPLEIMAGE2( A_CLIENT       IN  TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN  TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN  TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_ITEMCODE     IN  TM_ITEMS.ITEMCODE%TYPE,
                                  A_IMAGE        IN  TM_ITEMS.IMAGE%TYPE,
                                  A_USERID       IN  TH_CRIMP_IMAGE.CREATEUSER%TYPE, 
                                  N_RETURN      OUT  NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT  VARCHAR2           /* RETURN MESSAGE */
                                );
                                
                                
      /*이미지 관리:불량*/
      PROCEDURE SET_DEFECTIMAGE( A_CLIENT       IN  TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY      IN  TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT        IN  TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 A_DEFECT       IN  TM_DEFECT.DEFECT%TYPE,
                                 A_IMAGE        IN  TM_ITEMS.IMAGE%TYPE,
                                 A_USERID       IN  TH_CRIMP_IMAGE.CREATEUSER%TYPE, 
                                 N_RETURN      OUT  NUMBER,            /* RETURN VALUE */
                                 V_RETURN      OUT  VARCHAR2           /* RETURN MESSAGE */
                               );
                               
                               
      /*압착 기준정보 관리*/
      PROCEDURE GET_CRIMPINGBASE( A_CLIENT       IN  TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN  TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN  TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  N_RETURN      OUT  NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT  VARCHAR2,           /* RETURN MESSAGE */
                                  C_RETURN      OUT  SYS_REFCURSOR         /* RETURN CURSOR */
                                ); 
                                
                                
      /* 압착 기준 정보 등록 */
      PROCEDURE PUT_CRIMPINGBASE( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_ITEMCODE       IN      TW_CRIMPPING.ITEMCODE%TYPE,
                                  A_WIRE           IN      TW_CRIMPPING.WIRE%TYPE,
                                  A_COLOR          IN      TW_CRIMPPING.COLOR%TYPE,
                                  A_SQ             IN      TW_CRIMPPING.SQ%TYPE,
                                  A_WIRELENGTH     IN      TW_CRIMPPING.WIRELENGTH%TYPE,
                                  A_FRONT          IN      TW_CRIMPPING.FRONT%TYPE,
                                  A_FRONTSTRIP     IN      TW_CRIMPPING.FRONTSTRIP%TYPE,
                                  A_REAR           IN      TW_CRIMPPING.REAR%TYPE,
                                  A_REARSTRIP      IN      TW_CRIMPPING.REARSTRIP%TYPE,
                                  A_REMARKS        IN      TW_CRIMPPING.REMARKS%TYPE,
                                  A_USER           IN      TW_CRIMPPING.CREATEUSER%TYPE,
                                  N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN        OUT      VARCHAR2           /* RETURN MESSAGE */
                                 );  
                                 
                                 
      PROCEDURE PUT_BOM_RELEASE ( A_CLIENT       IN       TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN       TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN       TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  N_RETURN      OUT       NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT       VARCHAR2          /* RETURN MESSAGE */
                                )   ;
                                
      
    --  PROCEDURE PUT_BOM_FIND (    A_CLIENT       IN       TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
    --                              A_COMPANY      IN       TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
    --                              A_PLANT        IN       TM_PLANT.PLANT%TYPE, /* 공장코드 */
    --                              A_BOMGRP       IN       TM_BOM.BOMGRP%TYPE,
    --                              A_UPRITEM      IN       TM_BOM.UPRITEM%TYPE,
    --                              N_RETURN      OUT       NUMBER,            /* RETURN VALUE */
    --                              V_RETURN      OUT       VARCHAR2          /* RETURN MESSAGE */
    --                         )   ;   
                             
                             
      PROCEDURE PUT_BOM_FIND2 (   A_CLIENT       IN       TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN       TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN       TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  N_RETURN      OUT       NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT       VARCHAR2          /* RETURN MESSAGE */
                              )   ;     
                              
                              
      PROCEDURE PUT_BOM_SUBITEM ( A_CLIENT       IN       TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN       TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN       TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_BOMGRP       IN       TM_BOM.BOMGRP%TYPE,
                                  A_USERID       IN       TM_BOM.CREATEUSER%TYPE,
                                  N_RETURN      OUT       NUMBER,            /* RETURN VALUE    */
                                  V_RETURN      OUT       VARCHAR2            /* RETURN MESSAGE  */
                             )   ;      
                              
                              
      PROCEDURE PUT_BOM_SUBITEM_ALL ( A_CLIENT       IN       TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                      A_COMPANY      IN       TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                      A_PLANT        IN       TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                      A_USERID       IN       TM_BOM.CREATEUSER%TYPE,
                                      N_RETURN      OUT       NUMBER,            /* RETURN VALUE    */
                                      V_RETURN      OUT       VARCHAR2            /* RETURN MESSAGE  */
                                    )   ;    
    
      
      -- BOM그룹현황
      PROCEDURE GET_BOMGRP_LIST( A_CLIENT       IN  TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY      IN  TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT        IN  TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 A_PARTNO       IN  TM_ITEMS.PARTNO%TYPE,
                                 N_RETURN      OUT  NUMBER,            /* RETURN VALUE */
                                 V_RETURN      OUT  VARCHAR2,          /* RETURN MESSAGE */
                                 C_RETURN      OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                               );
                               
                                                                               
      -- BOM 현황
      PROCEDURE GET_BOM_LIST( A_CLIENT       IN  TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY      IN  TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT        IN  TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              A_BOMGRP       IN  TM_ITEMS.PARTNO%TYPE,
                              A_REV          IN  TM_BOM.REV%TYPE,
                              N_RETURN      OUT  NUMBER,            /* RETURN VALUE */
                              V_RETURN      OUT  VARCHAR2,          /* RETURN MESSAGE */
                              C_RETURN      OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                            );            
                             
                                                                              
      -- 근무달력
      PROCEDURE GET_WORKTIME( A_CLIENT       IN  TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY      IN  TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT        IN  TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              A_SDATE        IN  TM_WORKTIME.WORKDATE%TYPE,
                              A_EDATE        IN  TM_WORKTIME.WORKDATE%TYPE,
                              N_RETURN      OUT  NUMBER,            /* RETURN VALUE */
                              V_RETURN      OUT  VARCHAR2,          /* RETURN MESSAGE */
                              C_RETURN      OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                            );  
                                                          
      -- 근무달력
      PROCEDURE SET_WORKTIME( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */        
                              A_XML          IN      CLOB,   
                              A_USER         IN      TM_WORKTIME.CREATEUSER%TYPE,                      
                              N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                              V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                              C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                            );                                                                                               
                                                               
                                                                                     
       /* 어플리케이터 정보 조회 */
       PROCEDURE GET_APPLICATOR( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 N_RETURN        OUT      NUMBER,          /* RETURN VALUE */
                                 V_RETURN        OUT      VARCHAR2,      /* RETURN MESSAGE */
                                 C_RETURN        OUT      SYS_REFCURSOR   /* RETURN CURSOR */
                               );    
                               
                               
       /* 어플리케이터 정보 상세 조회 */
       PROCEDURE GET_APPLICATORDETAIL( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                       A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                       A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                       A_ITEMCODE       IN      TM_ITEMS.ITEMCODE%TYPE,
                                       N_RETURN        OUT      NUMBER,          /* RETURN VALUE */
                                       V_RETURN        OUT      VARCHAR2,      /* RETURN MESSAGE */
                                       C_RETURN        OUT      SYS_REFCURSOR   /* RETURN CURSOR */
                                     );
                                     
                                     
       /* 신규 어플리케이터 정보 등록 */
       PROCEDURE SET_APPLICATOR( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 A_ITEMCODE       IN      TM_ITEMS.ITEMCODE%TYPE,
                                 A_QTY            IN      NUMBER,
                                 A_USER           IN      TM_ITEMS.CREATEUSER%TYPE,
                                 N_RETURN        OUT      NUMBER,          /* RETURN VALUE */
                                 V_RETURN        OUT      VARCHAR2,      /* RETURN MESSAGE */
                                 C_RETURN        OUT      SYS_REFCURSOR   /* RETURN CURSOR */
                               );
                               
                               
       /* JIG 정보 조회 */
       PROCEDURE GET_JIGPIN( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                             A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                             A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                             N_RETURN        OUT      NUMBER,          /* RETURN VALUE */
                             V_RETURN        OUT      VARCHAR2,      /* RETURN MESSAGE */
                             C_RETURN        OUT      SYS_REFCURSOR   /* RETURN CURSOR */
                           );
                           
                           
       /* JIG PIN 정보 상세 조회 */
       PROCEDURE GET_JIGPINDETAIL( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                   A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                   A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                   A_ITEMCODE       IN      TM_ITEMS.ITEMCODE%TYPE,
                                   N_RETURN        OUT      NUMBER,          /* RETURN VALUE */
                                   V_RETURN        OUT      VARCHAR2,      /* RETURN MESSAGE */
                                   C_RETURN        OUT      SYS_REFCURSOR   /* RETURN CURSOR */
                                 );
                                 
                                 
       /* 신규 JIG PIN 정보 등록 */
       PROCEDURE SET_JIGPIN( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                             A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                             A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                             A_ITEMCODE       IN      TM_ITEMS.ITEMCODE%TYPE,
                             A_QTY            IN      NUMBER,
                             A_USER           IN      TM_ITEMS.CREATEUSER%TYPE,
                             N_RETURN        OUT      NUMBER,          /* RETURN VALUE */
                             V_RETURN        OUT      VARCHAR2,      /* RETURN MESSAGE */
                             C_RETURN        OUT      SYS_REFCURSOR   /* RETURN CURSOR */
                           );    
       
       /* GP12 품목정보 조회 */
       PROCEDURE GET_GP12_ITEM( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
    	                        A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
    	                        A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
    	                        N_RETURN        OUT      NUMBER,          /* RETURN VALUE */
    	                        V_RETURN        OUT      VARCHAR2,      /* RETURN MESSAGE */
    	                        C_RETURN        OUT      SYS_REFCURSOR   /* RETURN CURSOR */
    	                      );
       
       /* 신규 GP12 품복 등록 */
       PROCEDURE SET_GP12_ITEM( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
    	                        A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
    	                        A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
    	                        A_ITEMCODE       IN      TM_ITEMS.ITEMCODE%TYPE,
    	                        A_REMARKS        IN      TM_GP12_ITEM.REMARKS%TYPE,
    	                        A_USER           IN      TM_ITEMS.CREATEUSER%TYPE,
    	                        N_RETURN        OUT      NUMBER,          /* RETURN VALUE */
    	                        V_RETURN        OUT      VARCHAR2,      /* RETURN MESSAGE */
    	                        C_RETURN        OUT      SYS_REFCURSOR   /* RETURN CURSOR */
    	                      );
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
    END PKGBAS_BASE;
    ```

**참조 테이블:**

`TH_CRIMP_IMAGE`, `TM_BOM`, `TM_BOMGRP`, `TM_BOM_FIND`, `TM_BOM_FIND2`, `TM_BOM_RELEASE`, `TM_CLIENT`, `TM_CLOSINGBASE`, `TM_COMMCODE`, `TM_COMMGRP`, `TM_COMPANY`, `TM_CRIMPINSP`, `TM_DEFECT`, `TM_EHR`, `TM_EQP`, `TM_GP12_ITEM`, `TM_ITEMS`, `TM_LOCATION`, `TM_OPERATION`, `TM_PLANT`, `TM_PRODLINE`, `TM_PRODLINE_UNIT`, `TM_REASON`, `TM_ROUTING`, `TM_ROUTINGGRP`, `TM_SERIAL`, `TM_SUBITEMS`, `TM_SYSUSERROLE`, `TM_VENDOR`, `TM_WAREHOUSE`, `TM_WORKTIME`, `TW_CRIMPPING`, `TW_IN`, `TW_STOCKSERIAL`

---

### PKGBAS_BRD

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `GET_BADREG_SNINFO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_BADREG_SNINFO_PDA` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_BADREG_SN` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_BADREG_SN` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_BADREG_SN` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_BADREG_HISTINFO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_BADREG_JUDGE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_DEFECT_HISTORY` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_DEFECT_HISTORY3` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         PKGBAS_BRD IS
    
      /*불량 등록 대상 시리얼 정보 조회*/
      PROCEDURE GET_BADREG_SNINFO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                   A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                   A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */ 
                                   A_WHLOC        IN      TM_LOCATION.WHLOC%TYPE,
                                   A_SERIAL       IN      TM_SERIAL.SERIAL%TYPE,
                                   N_RETURN      OUT      NUMBER,            /* RETURN VALUE    */
                                   V_RETURN      OUT      VARCHAR2,            /* RETURN MESSAGE  */
                                   C_RETURN1     OUT      SYS_REFCURSOR        /* RETURN CURSOR  */
                                 );
    
      /*불량 등록 대상 시리얼 정보 조회*/
      PROCEDURE GET_BADREG_SNINFO_PDA(A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                      A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                      A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */ 
                                      A_WHLOC        IN      TM_LOCATION.WHLOC%TYPE,
                                      A_SERIAL       IN      TM_SERIAL.SERIAL%TYPE,
                                      N_RETURN      OUT      NUMBER,            /* RETURN VALUE    */
                                      V_RETURN      OUT      VARCHAR2,            /* RETURN MESSAGE  */
                                      C_RETURN1     OUT      SYS_REFCURSOR        /* RETURN CURSOR  */
                                    );
    
      /*불량 등록*/
      PROCEDURE SET_BADREG_SN( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                               A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                               A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                               A_PARTNO       IN      TM_ITEMS.PARTNO%TYPE, 
                               A_SERIAL       IN      TM_SERIAL.SERIAL%TYPE,
                               A_FROMWHLOC    IN      TM_LOCATION.WHLOC%TYPE,
                               A_QTY          IN      TM_SERIAL.QTY%TYPE,
                               A_PRODLINE     IN      TM_PRODLINE.PRODLINE%TYPE,
                               A_UNITNO       IN      TM_PRODLINE_UNIT.UNITNO%TYPE,
                               A_OPER         IN      TM_OPERATION.OPER%TYPE,
                               A_DEFECT       IN      TM_DEFECT.DEFECT%TYPE,
                               A_REMARKS      IN      TW_BRD.REMARKS%TYPE,
                               A_USER         IN      TW_BRD.CREATEUSER%TYPE,          
                               N_RETURN       OUT     NUMBER,            /* RETURN VALUE    */
                               V_RETURN       OUT     VARCHAR2           /* RETURN MESSAGE  */
                             );
                             
                             
      /*불량 등록*/
      PROCEDURE SET_BADREG_SN( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                               A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                               A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                               A_PARTNO       IN      TM_ITEMS.PARTNO%TYPE,
                               A_SERIAL       IN      TM_SERIAL.SERIAL%TYPE,
                               A_FROMWHLOC    IN      TM_LOCATION.WHLOC%TYPE,
                               A_QTY          IN      TM_SERIAL.QTY%TYPE,
                               A_PRODLINE     IN      TM_PRODLINE.PRODLINE%TYPE,
                               A_UNITNO       IN      TM_PRODLINE_UNIT.UNITNO%TYPE,
                               A_OPER         IN      TM_OPERATION.OPER%TYPE,
                               A_DEFECT       IN      TM_DEFECT.DEFECT%TYPE,
                               A_DEFECT1      IN      TM_DEFECT.DEFECT%TYPE,
                               A_DEFECT2      IN      TM_DEFECT.DEFECT%TYPE,
                               A_REMARKS      IN      TW_BRD.REMARKS%TYPE,
                               A_USER         IN      TW_BRD.CREATEUSER%TYPE,          
                               N_RETURN       OUT     NUMBER,            /* RETURN VALUE    */
                               V_RETURN       OUT     VARCHAR2           /* RETURN MESSAGE  */
                             ); 
                             
                             
       /*불량 등록*/
      PROCEDURE SET_BADREG_SN( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                               A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                               A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                               A_PARTNO       IN      TM_ITEMS.PARTNO%TYPE,
                               A_SERIAL       IN      TM_SERIAL.SERIAL%TYPE,
                               A_FROMWHLOC    IN      TM_LOCATION.WHLOC%TYPE,
                               A_QTY          IN      TM_SERIAL.QTY%TYPE,
                               A_PRODLINE     IN      TM_PRODLINE.PRODLINE%TYPE,
                               A_UNITNO       IN      TM_PRODLINE_UNIT.UNITNO%TYPE,
                               A_OPER         IN      TM_OPERATION.OPER%TYPE,
                               A_DEFECT       IN      TM_DEFECT.DEFECT%TYPE,
                               A_DEFECT2      IN      TM_DEFECT.DEFECT%TYPE,
                               A_DEFECT3      IN      TM_DEFECT.DEFECT%TYPE,
                               A_DEFECT4      IN      TM_DEFECT.DEFECT%TYPE,
                               A_DEFECT5      IN      TM_DEFECT.DEFECT%TYPE,
                               A_REMARKS      IN      TW_BRD.REMARKS%TYPE,
                               A_USER         IN      TW_BRD.CREATEUSER%TYPE,          
                               N_RETURN       OUT     NUMBER,            /* RETURN VALUE    */
                               V_RETURN       OUT     VARCHAR2           /* RETURN MESSAGE  */
                             );                                                
                             
                             
      /*불량 등록 이력 조회*/
      PROCEDURE GET_BADREG_HISTINFO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                     A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                     A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */ 
                                     A_WHLOC        IN      TM_LOCATION.WHLOC%TYPE,
                                     A_SERIAL       IN      TM_SERIAL.SERIAL%TYPE,
                                     A_SDATE        IN      TW_BRD.BRDDATE%TYPE,
                                     A_EDATE        IN      TW_BRD.BRDDATE%TYPE,
                                     N_RETURN      OUT      NUMBER,            /* RETURN VALUE    */
                                     V_RETURN      OUT      VARCHAR2,            /* RETURN MESSAGE  */
                                     C_RETURN1     OUT      SYS_REFCURSOR       /* RETURN CURSOR  */
                                   );                        
    
    
      /*불량 등록 판정 : 수리 / 폐기 / 취소*/
      PROCEDURE SET_BADREG_JUDGE( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_TAG          IN      VARCHAR2, 
                                  A_TXNTIMEKEY   IN      TW_BRD.TXNTIMEKEY%TYPE,
                                  A_BRDDATE      IN      TW_BRD.BRDDATE%TYPE,
                                  A_DEFECT       IN      TW_BRD.DEFECT%TYPE,
                                  A_SERIAL       IN      TM_SERIAL.SERIAL%TYPE,
                                  A_FROMWHLOC    IN      TM_LOCATION.WHLOC%TYPE,
                                  A_TOWHLOC      IN      TM_LOCATION.WHLOC%TYPE,
                                  A_QTY          IN      TM_SERIAL.QTY%TYPE,
                                  A_REMARKS      IN      TW_BRD.REMARKS%TYPE,
                                  A_USER         IN      TW_BRD.CREATEUSER%TYPE,         
                                  N_RETURN       OUT  NUMBER,            /* RETURN VALUE    */
                                  V_RETURN       OUT  VARCHAR2           /* RETURN MESSAGE  */
                                );
                                
                                
      /*불량 이력*/
      PROCEDURE GET_DEFECT_HISTORY( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                    A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                    A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                    A_BRDTYPE      IN      VARCHAR2,
                                    A_SDATE        IN      TW_BRD.BRDDATE%TYPE,
                                    A_EDATE        IN      TW_BRD.BRDDATE%TYPE,
                                    N_RETURN      OUT      NUMBER,            /* RETURN VALUE    */
                                    V_RETURN      OUT      VARCHAR2,            /* RETURN MESSAGE  */
                                    C_RETURN1     OUT      SYS_REFCURSOR       /* RETURN CURSOR  */
                                   ); 
                                   
     
      -- 불량/수리/페기 히스토리
      PROCEDURE GET_DEFECT_HISTORY3(
                         A_CLIENT         IN  TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                         A_COMPANY        IN  TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                         A_PLANT          IN  TM_PLANT.PLANT%TYPE, /* 공장코드 */
                         A_FROMDATE       IN  VARCHAR2,
                         A_TODATE         IN  VARCHAR2,
                         A_WHLOC          IN  TM_LOCATION.WHLOC%TYPE,
                         N_RETURN        OUT  NUMBER,             /* RETURN VALUE */
                         V_RETURN        OUT  VARCHAR2,           /* RETURN MESSAGE */
                         C_RETURN        OUT  SYS_REFCURSOR       /* RETURN CURSOR */
                         );                                                         
    end PKGBAS_BRD;
    ```

**참조 테이블:**

`TM_BOX`, `TM_CLIENT`, `TM_COMPANY`, `TM_DEFECT`, `TM_EHR`, `TM_ITEMS`, `TM_LOCATION`, `TM_OPERATION`, `TM_PLANT`, `TM_PRODLINE`, `TM_PRODLINE_UNIT`, `TM_SERIAL`, `TM_WAREHOUSE`, `TW_BRD`, `TW_STOCKSERIAL`

---

### PKGBAS_MAT

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `GET_LABEL_LIST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_RECEIVE_LIST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_RELEASE_LIST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_SPLITMERGE_LIST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_RECEIVE_RELEASE_LIST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_MATERIAL_STOCK_INCOMPANY_A` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_MATERIAL_STOCK_INCOMPANY_B` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_MATERIAL_STATUS` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_WAREHOUSE_STOCK` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_WAREHOUSE_NONE_STOCK` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_BAD_STOCK` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_BAD_MAT_LIST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_MATERIAL_ACTUAL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `DEL_PROD_ACTUAL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_MATERIAL_PO_REG` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_MAT_OUT_LIST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         PKGBAS_MAT IS
    
      /*라벨리스트*/
      PROCEDURE GET_LABEL_LIST( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                A_FROMDATE     IN      TM_SERIAL.INDATE%TYPE,
                                A_TODATE       IN      TM_SERIAL.INDATE%TYPE,
                                A_SN           IN      TM_SERIAL.SERIAL%TYPE,
                                N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                              );
    
    
      /*입고정보 : 자재 / 생산 / 영업*/
      PROCEDURE GET_RECEIVE_LIST( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_TXNCODE      IN      TW_IN.TXNCODE%TYPE,
                                  A_FROMDATE     IN      TW_IN.INDATE%TYPE,
                                  A_TODATE       IN      TW_IN.INDATE%TYPE,
                                  A_PARTNO       IN      TM_ITEMS.PARTNO%TYPE,
                                  A_SERIAL       IN      TW_IN.SERIAL%TYPE,
                                  A_WAREHOUSE    IN      TM_WAREHOUSE.WAREHOUSE%TYPE,
                                  A_WHLOC        IN      TM_LOCATION.WHLOC%TYPE,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                );
                                
    
      /*출고정보 : 자재 / 생산 / 영업*/
      PROCEDURE GET_RELEASE_LIST( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_TXNCODE      IN      TW_OUT.TXNCODE%TYPE,
                                  A_FROMDATE     IN      TW_OUT.OUTDATE%TYPE,
                                  A_TODATE       IN      TW_OUT.OUTDATE%TYPE,
                                  A_PARTNO       IN      TM_ITEMS.PARTNO%TYPE,
                                  A_SERIAL       IN      TW_OUT.SERIAL%TYPE,
                                  A_WAREHOUSE    IN      TM_WAREHOUSE.WAREHOUSE%TYPE,
                                  A_WHLOC        IN      TM_LOCATION.WHLOC%TYPE,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                );
    
    
      /*분리/병합 정보*/
      PROCEDURE GET_SPLITMERGE_LIST( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                     A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                     A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                     A_TXNCODE      IN      TW_IN.TXNCODE%TYPE,
                                     A_FROMDATE     IN      TW_IN.INDATE%TYPE,
                                     A_TODATE       IN      TW_IN.INDATE%TYPE,
                                     A_PARTNO       IN      TM_ITEMS.PARTNO%TYPE,
                                     A_SERIAL       IN      TW_IN.SERIAL%TYPE,
                                     A_WAREHOUSE    IN      TM_WAREHOUSE.WAREHOUSE%TYPE,
                                     A_WHLOC        IN      TM_LOCATION.WHLOC%TYPE,
                                     N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                     V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                     C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                   );
    
    
      /*입출고정보 : 자재 / 생산 / 영업*/
      PROCEDURE GET_RECEIVE_RELEASE_LIST( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                          A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                          A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                          A_TYPE         IN      TW_IN.TXNCODE%TYPE,
                                          A_TXNCODE      IN      TW_OUT.TXNCODE%TYPE,
                                          A_FROMDATE     IN      TW_OUT.OUTDATE%TYPE,
                                          A_TODATE       IN      TW_OUT.OUTDATE%TYPE,
                                          A_PARTNO       IN      TM_ITEMS.PARTNO%TYPE,
                                          A_SERIAL       IN      TW_OUT.SERIAL%TYPE,
                                          A_WAREHOUSE    IN      TM_WAREHOUSE.WAREHOUSE%TYPE,
                                          A_WHLOC        IN      TM_LOCATION.WHLOC%TYPE,
                                          N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                          V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                          C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                        );
    
    
    /*재고 현황 조회 : 자재 / 제품 동일 사용*/
      PROCEDURE GET_MATERIAL_STOCK_INCOMPANY_A( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                                A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                                A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                                A_WH           IN      TM_WAREHOUSE.WAREHOUSE%TYPE,
                                                A_WHLOC        IN      TW_STOCKSERIAL.WHLOC%TYPE,
                                                A_PARTNO       IN      TM_ITEMS.PARTNO%TYPE,
                                                N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                                V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                                C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                              );
                                              
                                              
    
    /*재고 현황 조회(상세) : 자재 / 제품 동일 사용*/
      PROCEDURE GET_MATERIAL_STOCK_INCOMPANY_B( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                                A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                                A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                                A_WH           IN      TM_WAREHOUSE.WAREHOUSE%TYPE,
                                                A_WHLOC        IN      TW_STOCKSERIAL.WHLOC%TYPE,
                                                A_PARTNO       IN      TM_ITEMS.PARTNO%TYPE,
                                                N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                                V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                                C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                              );
    
    
      /*재고 정보 조회 : 위치별 자재재고조회*/
      PROCEDURE GET_MATERIAL_STATUS( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                     A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                     A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                     A_WAREHOUSE    IN      TM_WAREHOUSE.WAREHOUSE%TYPE,
                                     A_WHLOC        IN      TW_STOCKSERIAL.WHLOC%TYPE,
                                     A_PARTNO       IN      TM_ITEMS.PARTNO%TYPE,
                                     A_SERIAL       IN      TW_STOCKSERIAL.SERIAL%TYPE,
                                     N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                     V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                     C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                   );
    
    
      /*재고 정보 조회: 위치별 전체재고조회*/
      PROCEDURE GET_WAREHOUSE_STOCK( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                     A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                     A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                     A_WAREHOUSE    IN      TM_WAREHOUSE.WAREHOUSE%TYPE,
                                     A_WHLOC        IN      TW_STOCKSERIAL.WHLOC%TYPE,
                                     A_PARTNO       IN      TM_ITEMS.PARTNO%TYPE,
                                     A_SERIAL       IN      TW_STOCKSERIAL.SERIAL%TYPE,
                                     N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                     V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                     C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                   );
    
    
      /*재고 정보 조회: 위치별 전체재고조회*/
      PROCEDURE GET_WAREHOUSE_NONE_STOCK( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                          A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                          A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                          A_WAREHOUSE    IN      TM_WAREHOUSE.WAREHOUSE%TYPE,
                                          A_WHLOC        IN      TW_STOCKSERIAL.WHLOC%TYPE,
                                          A_PARTNO       IN      TM_ITEMS.PARTNO%TYPE,
                                          A_SERIAL       IN      TW_STOCKSERIAL.SERIAL%TYPE,
                                          N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                          V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                          C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                        );
    
    
    
      /*불량재고조회*/
      PROCEDURE GET_BAD_STOCK( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                               A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                               A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                               A_WHLOC        IN      TM_LOCATION.WHLOC%TYPE,
                               A_SN           IN      TM_SERIAL.SERIAL%TYPE,
                               N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                               V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                               C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                             );
                             
    
      /*불량재고 리스트*/
      PROCEDURE GET_BAD_MAT_LIST( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_WHLOC        IN      TM_LOCATION.WHLOC%TYPE,
                                  A_SN           IN      TM_SERIAL.SERIAL%TYPE,
                                  A_PARTNO       IN      TM_ITEMS.PARTNO%TYPE,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                );
    
    
      /*재고 실사(자재) 조회*/
      PROCEDURE GET_MATERIAL_ACTUAL( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                     A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                     A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                     A_MONTH        IN      TW_ACTUALSTOCK.ACTUALMON%TYPE,
                                     A_WHLOC        IN      TW_ACTUALSTOCK.WHLOC%TYPE,
                                     N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                     V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                     C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                   );
                                   
                                   
      /*재고실사삭제*/
      PROCEDURE DEL_PROD_ACTUAL( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 A_MONTH        IN      TW_ACTUALSTOCK.ACTUALMON%TYPE,
                                 A_WHLOC        IN      TW_ACTUALSTOCK.WHLOC%TYPE,
                                 A_ITEMCODE     IN      TW_ACTUALSTOCK.ITEMCODE%TYPE,
                                 A_STOCKTYPE    IN      TW_ACTUALSTOCK.SERIAL%TYPE,
                                 A_SIDE         IN      TW_ACTUALSTOCK.SIDE%TYPE,
                                 A_SERIAL       IN      TW_ACTUALSTOCK.SERIAL%TYPE,
                                 A_BOXNO        IN      TW_ACTUALSTOCK.BOXNO%TYPE,
                                 N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                 V_RETURN      OUT      VARCHAR2           /* RETURN MESSAGE */
                               );
                               
                               
       /*PO MES 등록*/
      PROCEDURE PUT_MATERIAL_PO_REG( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                     A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                     A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                     A_XML          IN      CLOB,
                                     A_USER         IN      TM_ORDERMASTER.BAL_EMPNO%TYPE,
                                     N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                     V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                     C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                   );  
                             
    
      /*불출현황*/
      PROCEDURE GET_MAT_OUT_LIST( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_FROMDATE     IN      TW_OUT.OUTDATE%TYPE,
                                  A_TODATE       IN      TW_OUT.OUTDATE%TYPE,
                                  A_WHLOC        IN      TW_OUT.WHLOC%TYPE,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                );              
                        
    END PKGBAS_MAT;
    ```

**참조 테이블:**

`TH_SPLITMERGE`, `TIF_STOCK`, `TM_BOX`, `TM_CLIENT`, `TM_COMMCODE`, `TM_COMPANY`, `TM_EHR`, `TM_ITEMS`, `TM_LOCATION`, `TM_OPERATION`, `TM_ORDERDETAIL`, `TM_ORDERMASTER`, `TM_PLANT`, `TM_PRODLINE`, `TM_SERIAL`, `TM_TRANSACTION`, `TM_VENDOR`, `TM_WAREHOUSE`, `TW_ACTUALSTOCK`, `TW_IN`, `TW_IQC`, `TW_IQC_SEQ`, `TW_MATERIALREQUSET`, `TW_MOUNT`, `TW_OUT`, `TW_RESPONSENO`, `TW_STOCKSERIAL`

---

### PKGDEV_KBS_TEMP

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `SET_GP12_INSPECTION` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         PKGDEV_KBS_TEMP
    AS
    -- Package header
    
    /*GP12 검사 이력 등록*/
      PROCEDURE SET_GP12_INSPECTION( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                       A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                       A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                       A_UNITNO       IN      TW_PRODHIST.UNITNO%TYPE,
                                       A_SERIAL       IN      TW_PRODHIST.SERIAL%TYPE,
                                       A_JUDGE        IN      TW_PRODHIST.JUDGE%TYPE,
                                       A_DEFECT       IN      TW_PRODHIST.DEFECT%TYPE,
                                       A_DEFECT2      IN      TW_PRODHIST.DEFECT%TYPE,
                                       A_DEFECT3      IN      TW_PRODHIST.DEFECT%TYPE,
                                       A_DEFECT4      IN      TW_PRODHIST.DEFECT%TYPE,
                                       A_DEFECT5      IN      TW_PRODHIST.DEFECT%TYPE,
                                       A_USER         IN      TM_USER.USERID%TYPE,
                                       A_USER2        IN      TM_USER.USERID%TYPE,
                                       N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                       V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                       C_RETURN      OUT      SYS_REFCURSOR,     /* RETURN CURSOR */
                                       C_RETURN1     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                     );
    END PKGDEV_KBS_TEMP;
    ```

**참조 테이블:**

`TH_OQC_REPORT`, `TH_OQC_REPORT_SEQ`, `TM_BOX`, `TM_CLIENT`, `TM_COMPANY`, `TM_ITEMS`, `TM_LOCATION`, `TM_PLANT`, `TM_PRODLINE`, `TM_PRODLINE_UNIT`, `TM_SERIAL`, `TM_USER`, `TW_BRD`, `TW_IQC`, `TW_PRODHIST`, `TW_STOCKSERIAL`

---

### PKGHNS_REPORT

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `SET_SAVE_STOCK_DATE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_SAVE_STOCK` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, A_COMPANY IN TM_COMPANY.COMPANY%TYPE, A_PL... |
| PROC | `GET_STOCKLIST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, A_COMPANY IN TM_COMPANY.COMPANY%TYPE, A_PL... |
| PROC | `GET_ACTUALSTOCK` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, A_COMPANY IN TM_COMPANY.COMPANY%TYPE, A_PL... |
| PROC | `GET_LONGSTOCK_LIST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, A_COMPANY IN TM_COMPANY.COMPANY%TYPE, A_PL... |
| PROC | `GET_SALE_MONITOR1` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, A_COMPANY IN TM_COMPANY.COMPANY%TYPE, A_PL... |
| PROC | `GET_MAT_MONITOR1` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, A_COMPANY IN TM_COMPANY.COMPANY%TYPE, A_PL... |
| PROC | `PUT_MAT_MONITOR` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, A_COMPANY IN TM_COMPANY.COMPANY%TYPE, A_PL... |
| PROC | `GET_MAT_MONITOR` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, A_COMPANY IN TM_COMPANY.COMPANY%TYPE, A_PL... |
| PROC | `GET_CUSTPLAN` | A_CLIENT IN TM_CUSTPLAN.CLIENT%TYPE, A_COMPANY IN TM_CUSTPLAN.COMPANY%TYPE, A... |
| PROC | `GET_MAT_CUSTPLAN` | A_CLIENT IN TM_CUSTPLAN.CLIENT%TYPE, A_COMPANY IN TM_CUSTPLAN.COMPANY%TYPE, A... |
| PROC | `GET_CUSTPLAN_MAXDATE` | A_CLIENT IN TM_CUSTPLAN.CLIENT%TYPE, A_COMPANY IN TM_CUSTPLAN.COMPANY%TYPE, A... |
| PROC | `GET_PRODPLAN_MAXDATE` | A_CLIENT IN TM_CUSTPLAN.CLIENT%TYPE, A_COMPANY IN TM_CUSTPLAN.COMPANY%TYPE, A... |
| PROC | `PUT_MAT_MONITOR_PRODPLAN` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, A_COMPANY IN TM_COMPANY.COMPANY%TYPE, A_PL... |
| PROC | `GET_MAT_MONITOR_PRODPLAN` | A_CLIENT IN TM_PRODPLAN.CLIENT%TYPE, A_COMPANY IN TM_PRODPLAN.COMPANY%TYPE, A... |
| PROC | `GET_PRODPLAN` | A_CLIENT IN TM_CUSTPLAN.CLIENT%TYPE, A_COMPANY IN TM_CUSTPLAN.COMPANY%TYPE, A... |
| PROC | `GET_MAT_PRODPLAN` | A_CLIENT IN TM_CUSTPLAN.CLIENT%TYPE, A_COMPANY IN TM_CUSTPLAN.COMPANY%TYPE, A... |
| PROC | `PUT_MAT_BALANCE_TEMP` | A_CLIENT IN TM_CUSTPLAN.CLIENT%TYPE, A_COMPANY IN TM_CUSTPLAN.COMPANY%TYPE, A... |
| PROC | `GET_MAT_BALANCE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_CONVEYOR_MONITOR3` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_LQC_MONITOR1` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_LQC_MONITOR2` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_LQC_MONITOR3` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_LQC_MONITOR4` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_LQC_MONITOR5` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_NG_SCRAP` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PRD_MONITOR_PRODPLAN` | A_CLIENT IN TM_PRODPLAN.CLIENT%TYPE, A_COMPANY IN TM_PRODPLAN.COMPANY%TYPE, A... |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         PKGHNS_REPORT is  
    
                          
      --일별 재고 저장
      PROCEDURE SET_SAVE_STOCK_DATE( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                     A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                     A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                     A_PLANDATE     IN      TM_CUSTPLAN.PLANDATE%TYPE,
                                     N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                     V_RETURN      OUT      VARCHAR2           /* RETURN MESSAGE */
                                   );                                                    
                            
      -- 재고 저장
      PROCEDURE SET_SAVE_STOCK(  A_CLIENT       IN       TM_CLIENT.CLIENT%TYPE,
                                 A_COMPANY      IN       TM_COMPANY.COMPANY%TYPE,
                                 A_PLANT        IN       TM_PLANT.PLANT%TYPE,
                                 A_DATE         IN       TW_STOCKSERIAL_MONTH.STOCKMONTH%TYPE,
                                 A_WHLOC        IN       TM_LOCATION.WHLOC%TYPE,
                                 N_RETURN      OUT       NUMBER,            /* RETURN VALUE */
                                 V_RETURN      OUT       VARCHAR2,          /* RETURN MESSAGE */
                                 C_RETURN      OUT       SYS_REFCURSOR      /* RETURN CURSOR */
                                );     
                                
       /* 재고 현황 */
      PROCEDURE GET_STOCKLIST( A_CLIENT          IN       TM_CLIENT.CLIENT%TYPE,
                               A_COMPANY         IN       TM_COMPANY.COMPANY%TYPE,
                               A_PLANT           IN       TM_PLANT.PLANT%TYPE,
                               A_FROMDATE        IN VARCHAR2,
                               A_TODATE          IN VARCHAR2,
                               A_WAREHOUSE       IN VARCHAR2,
                               A_WHLOC           IN VARCHAR2,
                               A_PARTNO          IN VARCHAR2,
                               N_RETURN         OUT NUMBER,
                               V_RETURN         OUT VARCHAR2,
                               C_RETURN         OUT SYS_REFCURSOR
                             );
                             
       -- 실사 현황
      PROCEDURE GET_ACTUALSTOCK( A_CLIENT       IN       TM_CLIENT.CLIENT%TYPE,
                                 A_COMPANY      IN       TM_COMPANY.COMPANY%TYPE,
                                 A_PLANT        IN       TM_PLANT.PLANT%TYPE,
                                 A_DATE         IN       TW_ACTUALSTOCK.ACTUALMON%TYPE,
                                 A_WHLOC        IN       TM_LOCATION.WHLOC%TYPE,
                                 N_RETURN      OUT       NUMBER,            /* RETURN VALUE */
                                 V_RETURN      OUT       VARCHAR2,          /* RETURN MESSAGE */
                                 C_RETURN      OUT       SYS_REFCURSOR      /* RETURN CURSOR */
                                );       
                                                                               
      -- 장기 재고
      PROCEDURE GET_LONGSTOCK_LIST( A_CLIENT       IN  TM_CLIENT.CLIENT%TYPE,
                                    A_COMPANY      IN  TM_COMPANY.COMPANY%TYPE,
                                    A_PLANT        IN  TM_PLANT.PLANT%TYPE,
                                    A_PERIOD       IN  NUMBER,
                                    A_WAREHOUSE    IN  TM_WAREHOUSE.WAREHOUSE%TYPE,
                                    A_WHLOC        IN  TM_LOCATION.WHLOC%TYPE,
                                    A_PARTNO       IN  TM_ITEMS.PARTNO%TYPE,
                                    N_RETURN      OUT  NUMBER,            /* RETURN VALUE */
                                    V_RETURN      OUT  VARCHAR2,          /* RETURN MESSAGE */
                                    C_RETURN      OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                                  );        
                                     
      --영업 모니터링1
      PROCEDURE GET_SALE_MONITOR1(  A_CLIENT       IN  TM_CLIENT.CLIENT%TYPE,
                                    A_COMPANY      IN  TM_COMPANY.COMPANY%TYPE,
                                    A_PLANT        IN  TM_PLANT.PLANT%TYPE,
                                    N_RETURN      OUT  NUMBER,            /* RETURN VALUE */
                                    V_RETURN      OUT  VARCHAR2,          /* RETURN MESSAGE */
                                    C_RETURN      OUT  SYS_REFCURSOR,     /* RETURN CURSOR */
                                    C_RETURN1     OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                                  ); 
                                  
                    
      -- 자재 모니터링(자재 재고)
      PROCEDURE GET_MAT_MONITOR1( A_CLIENT       IN  TM_CLIENT.CLIENT%TYPE,
                                  A_COMPANY      IN  TM_COMPANY.COMPANY%TYPE,
                                  A_PLANT        IN  TM_PLANT.PLANT%TYPE,
                                  N_RETURN      OUT  NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT  VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                               ); 
                                  
      -- 자재 모니터링(자재 밸런스)
      PROCEDURE PUT_MAT_MONITOR ( A_CLIENT       IN  TM_CLIENT.CLIENT%TYPE,
                                  A_COMPANY      IN  TM_COMPANY.COMPANY%TYPE,
                                  A_PLANT        IN  TM_PLANT.PLANT%TYPE,
                                  A_DATE         IN       TM_CUSTPLAN.PLANDATE%TYPE,
                                  A_XML          IN       CLOB,
                                  N_RETURN      OUT       NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT       VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT       SYS_REFCURSOR,      /* RETURN CURSOR */
                                  C_RETURN1     OUT       SYS_REFCURSOR      /* RETURN CURSOR */
                                );        
                                   
                                  
      -- 자재 모니터링(자재 밸런스)
      PROCEDURE GET_MAT_MONITOR ( A_CLIENT       IN  TM_CLIENT.CLIENT%TYPE,
                                  A_COMPANY      IN  TM_COMPANY.COMPANY%TYPE,
                                  A_PLANT        IN  TM_PLANT.PLANT%TYPE,
                                  A_DATE         IN       TM_CUSTPLAN.PLANDATE%TYPE,
                                  A_FLAG         IN       VARCHAR2,
                                  N_RETURN      OUT       NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT       VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT       SYS_REFCURSOR,      /* RETURN CURSOR */
                                  C_RETURN1     OUT       SYS_REFCURSOR      /* RETURN CURSOR */
                                );          
                                     
      --고객 계획 조회
      PROCEDURE GET_CUSTPLAN ( A_CLIENT       IN   TM_CUSTPLAN.CLIENT%TYPE,
                               A_COMPANY      IN   TM_CUSTPLAN.COMPANY%TYPE,
                               A_PLANT        IN   TM_CUSTPLAN.PLANT%TYPE,
                               A_PLANDATE     IN   TM_CUSTPLAN.PLANDATE%TYPE,
                               N_RETURN       OUT  NUMBER,            /* RETURN VALUE */
                               V_RETURN       OUT  VARCHAR2,          /* RETURN MESSAGE */
                               C_RETURN       OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                             );                       
                                     
      --원자재에 대한 고객 계획 조회
      PROCEDURE GET_MAT_CUSTPLAN ( A_CLIENT       IN   TM_CUSTPLAN.CLIENT%TYPE,
                                   A_COMPANY      IN   TM_CUSTPLAN.COMPANY%TYPE,
                                   A_PLANT        IN   TM_CUSTPLAN.PLANT%TYPE,
                                   A_PLANDATE     IN   TM_CUSTPLAN.PLANDATE%TYPE,
                                   A_PARTNO       IN   TM_ITEMS.PARTNO%TYPE,
                                   N_RETURN       OUT  NUMBER,            /* RETURN VALUE */
                                   V_RETURN       OUT  VARCHAR2,          /* RETURN MESSAGE */
                                   C_RETURN       OUT  SYS_REFCURSOR,      /* RETURN CURSOR */
                                   C_RETURN1      OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                                 );           
                                     
      --고객 계획 최종 등록일
      PROCEDURE GET_CUSTPLAN_MAXDATE ( A_CLIENT       IN   TM_CUSTPLAN.CLIENT%TYPE,
                                       A_COMPANY      IN   TM_CUSTPLAN.COMPANY%TYPE,
                                       A_PLANT        IN   TM_CUSTPLAN.PLANT%TYPE,
                                       N_RETURN       OUT  NUMBER,            /* RETURN VALUE */
                                       V_RETURN       OUT  VARCHAR2,          /* RETURN MESSAGE */
                                       C_RETURN       OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                                      );           
                                     
      --생산 계획 최종 등록일
      PROCEDURE GET_PRODPLAN_MAXDATE ( A_CLIENT       IN   TM_CUSTPLAN.CLIENT%TYPE,
                                       A_COMPANY      IN   TM_CUSTPLAN.COMPANY%TYPE,
                                       A_PLANT        IN   TM_CUSTPLAN.PLANT%TYPE,
                                       N_RETURN       OUT  NUMBER,            /* RETURN VALUE */
                                       V_RETURN       OUT  VARCHAR2,          /* RETURN MESSAGE */
                                       C_RETURN       OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                                      ); 
                                      
                                  
      -- 자재 모니터링(자재 밸런스)
      PROCEDURE PUT_MAT_MONITOR_PRODPLAN ( A_CLIENT       IN  TM_CLIENT.CLIENT%TYPE,
                                           A_COMPANY      IN  TM_COMPANY.COMPANY%TYPE,
                                           A_PLANT        IN  TM_PLANT.PLANT%TYPE,
                                           A_DATE         IN       TM_CUSTPLAN.PLANDATE%TYPE,
                                           A_XML          IN       CLOB,
                                           N_RETURN      OUT       NUMBER,            /* RETURN VALUE */
                                           V_RETURN      OUT       VARCHAR2,          /* RETURN MESSAGE */
                                           C_RETURN      OUT       SYS_REFCURSOR,      /* RETURN CURSOR */
                                           C_RETURN1     OUT       SYS_REFCURSOR      /* RETURN CURSOR */
                                         );        
                                       
                                  
      -- 자재 모니터링(자재 밸런스)
      PROCEDURE GET_MAT_MONITOR_PRODPLAN( A_CLIENT       IN       TM_PRODPLAN.CLIENT%TYPE,
                                          A_COMPANY      IN       TM_PRODPLAN.COMPANY%TYPE,
                                          A_PLANT        IN       TM_PRODPLAN.PLANT%TYPE,
                                          A_DATE         IN       TM_PRODPLAN.PLANDATE%TYPE,
                                          A_FLAG         IN       VARCHAR2,
                                          N_RETURN      OUT       NUMBER,            /* RETURN VALUE */
                                          V_RETURN      OUT       VARCHAR2,          /* RETURN MESSAGE */
                                          C_RETURN      OUT       SYS_REFCURSOR,      /* RETURN CURSOR */
                                          C_RETURN1     OUT       SYS_REFCURSOR      /* RETURN CURSOR */
                                        );         
                                     
      --생산 계획 조회
      PROCEDURE GET_PRODPLAN ( A_CLIENT       IN   TM_CUSTPLAN.CLIENT%TYPE,
                               A_COMPANY      IN   TM_CUSTPLAN.COMPANY%TYPE,
                               A_PLANT        IN   TM_CUSTPLAN.PLANT%TYPE,
                               A_PLANDATE     IN   TM_CUSTPLAN.PLANDATE%TYPE,
                               N_RETURN       OUT  NUMBER,            /* RETURN VALUE */
                               V_RETURN       OUT  VARCHAR2,          /* RETURN MESSAGE */
                               C_RETURN       OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                             );                       
                                     
      --원자재에 대한 생산 계획 조회
      PROCEDURE GET_MAT_PRODPLAN ( A_CLIENT       IN   TM_CUSTPLAN.CLIENT%TYPE,
                                   A_COMPANY      IN   TM_CUSTPLAN.COMPANY%TYPE,
                                   A_PLANT        IN   TM_CUSTPLAN.PLANT%TYPE,
                                   A_PLANDATE     IN   TM_CUSTPLAN.PLANDATE%TYPE,
                                   A_PARTNO       IN   TM_ITEMS.PARTNO%TYPE,
                                   N_RETURN       OUT  NUMBER,            /* RETURN VALUE */
                                   V_RETURN       OUT  VARCHAR2,          /* RETURN MESSAGE */
                                   C_RETURN       OUT  SYS_REFCURSOR,      /* RETURN CURSOR */
                                   C_RETURN1      OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                                 );                          
                                     
      -- 자재 밸런스TEMP 저장
      PROCEDURE PUT_MAT_BALANCE_TEMP ( A_CLIENT       IN   TM_CUSTPLAN.CLIENT%TYPE,
                                       A_COMPANY      IN   TM_CUSTPLAN.COMPANY%TYPE,
                                       A_PLANT        IN   TM_CUSTPLAN.PLANT%TYPE,
                                       A_PLANDATE     IN   TM_CUSTPLAN.PLANDATE%TYPE,
                                       N_RETURN       OUT  NUMBER,            /* RETURN VALUE */
                                       V_RETURN       OUT  VARCHAR2,          /* RETURN MESSAGE */
                                       C_RETURN       OUT  SYS_REFCURSOR       /* RETURN CURSOR */
                                      );                    
                                     
      --자재 밸런스
      PROCEDURE GET_MAT_BALANCE( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 A_PLANDATE     IN      TM_CUSTPLAN.PLANDATE%TYPE,
                                 N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                 V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                 C_RETURN      OUT      SYS_REFCURSOR,      /* RETURN CURSOR */
                                 C_RETURN1     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                ); 
                                
                                
      --CONVEYOR 모니터링 3
      PROCEDURE GET_CONVEYOR_MONITOR3( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                       A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                       A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                       A_DATE         IN      TW_PRODHIST.PRODDATE%TYPE,
                                       A_FLAG         IN      VARCHAR2,
                                       N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                       V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                       C_RETURN      OUT      SYS_REFCURSOR,      /* RETURN CURSOR */
                                       C_RETURN1     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                     );
                                                
                                     
      --LQC 모니터링 1
      PROCEDURE GET_LQC_MONITOR1( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_DATE         IN      TW_PRODHIST.PRODDATE%TYPE,
                                  A_FLAG         IN      VARCHAR2,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT      SYS_REFCURSOR,      /* RETURN CURSOR */
                                  C_RETURN1     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                 );
                                                
                                     
      --LQC 모니터링 2
      PROCEDURE GET_LQC_MONITOR2( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_DATE         IN      TW_PRODHIST.PRODDATE%TYPE,
                                  A_FLAG         IN      VARCHAR2,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT      SYS_REFCURSOR,      /* RETURN CURSOR */
                                  C_RETURN1     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                 );          
                                     
      --LQC 모니터링 3
      PROCEDURE GET_LQC_MONITOR3( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_DATE         IN      TW_PRODHIST.PRODDATE%TYPE,
                                  A_FLAG         IN      VARCHAR2,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT      SYS_REFCURSOR,      /* RETURN CURSOR */
                                  C_RETURN1     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                 );
                                        
                                     
      --LQC 모니터링 4
      PROCEDURE GET_LQC_MONITOR4( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_DATE         IN      TW_PRODHIST.PRODDATE%TYPE,
                                  A_FLAG         IN      VARCHAR2,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT      SYS_REFCURSOR,      /* RETURN CURSOR */
                                  C_RETURN1     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                 );
                                            
                                     
      --LQC 모니터링 5
      PROCEDURE GET_LQC_MONITOR5( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_DATE         IN      TW_PRODHIST.PRODDATE%TYPE,
                                  A_FLAG         IN      VARCHAR2,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT      SYS_REFCURSOR,      /* RETURN CURSOR */
                                  C_RETURN1     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                 );
                                                              
       
      --NG SCRAP
      PROCEDURE GET_NG_SCRAP( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              A_ACTUALMON    IN      TW_ACTUALSTOCK.ACTUALMON%TYPE,
                              N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                              V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                              C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                             );
                                                           
                                                           
      -- 제품 모니터링(제품 밸런스)
      PROCEDURE GET_PRD_MONITOR_PRODPLAN( A_CLIENT       IN       TM_PRODPLAN.CLIENT%TYPE,
                                          A_COMPANY      IN       TM_PRODPLAN.COMPANY%TYPE,
                                          A_PLANT        IN       TM_PRODPLAN.PLANT%TYPE,
                                          A_DATE         IN       TM_PRODPLAN.PLANDATE%TYPE,
                                          A_FLAG         IN       VARCHAR2,
                                          N_RETURN      OUT       NUMBER,            /* RETURN VALUE */
                                          V_RETURN      OUT       VARCHAR2,          /* RETURN MESSAGE */
                                          C_RETURN      OUT       SYS_REFCURSOR,      /* RETURN CURSOR */
                                          C_RETURN1     OUT       SYS_REFCURSOR      /* RETURN CURSOR */
                                        );                                  
                                                                                                
    end PKGHNS_REPORT;
    ```

**참조 테이블:**

`TIF_STOCK`, `TM_BOM`, `TM_CALENDER`, `TM_CLIENT`, `TM_CLOSINGBASE`, `TM_COMPANY`, `TM_CUSTPLAN`, `TM_CUSTPLAN_TEMP`, `TM_DEFECT`, `TM_INVOICEDETAIL`, `TM_INVOICEMASTER`, `TM_ITEMS`, `TM_LOCATION`, `TM_LQC_REPORT_01`, `TM_LQC_REPORT_02`, `TM_LQC_REPORT_02_01`, `TM_LQC_REPORT_03`, `TM_MAT_BALANCE_TEMP`, `TM_ORDERDETAIL`, `TM_PLANT`, `TM_PRODPLAN`, `TM_PRODPLAN_MONTH`, `TM_PRODPLAN_MONTH_BEGIN`, `TM_PRODPLAN_MONTH_PLAN`, `TM_PRODPLAN_MONTH_RESULT`, `TM_PRODPLAN_TEMP`, `TM_SERIAL`, `TM_VENDOR`, `TM_WAREHOUSE`, `TW_ACTUALSTOCK`, `TW_IN`, `TW_OUT`, `TW_PRODHIST`, `TW_STOCKSERIAL`, `TW_STOCKSERIAL_MONTH`, `TW_STOCK_DATE`, `TW_STOCK_DATE_CAL1`

---

### PKGIF_ERP

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `PUT_ORDER` | N_RETURN OUT NUMBER, /* RETURN VALUE */ V_RETURN OUT VARCHAR2 /* RETURN MESSA... |
| PROC | `PUT_INVOICE` | N_RETURN OUT NUMBER, /* RETURN VALUE */ V_RETURN OUT VARCHAR2 /* RETURN MESSA... |
| PROC | `PUT_IN` | N_RETURN OUT NUMBER, /* RETURN VALUE */ V_RETURN OUT VARCHAR2 /* RETURN MESSA... |
| PROC | `PUT_RETURN_IN` | N_RETURN OUT NUMBER, /* RETURN VALUE */ V_RETURN OUT VARCHAR2 /* RETURN MESSA... |
| PROC | `PUT_ITEMS` | N_RETURN OUT NUMBER, /* RETURN VALUE */ -- V_RETURN OUT VARCHAR2 /* RETURN ME... |
| PROC | `PUT_VENDOR` | N_RETURN OUT NUMBER, /* RETURN VALUE */ -- V_RETURN OUT VARCHAR2 /* RETURN ME... |
| PROC | `PUT_OUT` | N_RETURN OUT NUMBER, /* RETURN VALUE */ -- V_RETURN OUT VARCHAR2 /* RETURN ME... |
| PROC | `PUT_OUT1` | N_RETURN OUT NUMBER, /* RETURN VALUE */ V_RETURN OUT VARCHAR2 /* RETURN MESSA... |
| PROC | `PUT_OUT2` | N_RETURN OUT NUMBER, /* RETURN VALUE */ V_RETURN OUT VARCHAR2 /* RETURN MESSA... |
| PROC | `PUT_OUT3` | N_RETURN OUT NUMBER, /* RETURN VALUE */ V_RETURN OUT VARCHAR2 /* RETURN MESSA... |
| PROC | `PUT_OUT3_1` | N_RETURN OUT NUMBER, /* RETURN VALUE */ V_RETURN OUT VARCHAR2 /* RETURN MESSA... |
| PROC | `PUT_OUT4` | N_RETURN OUT NUMBER, /* RETURN VALUE */ V_RETURN OUT VARCHAR2 /* RETURN MESSA... |
| PROC | `PUT_OUT5` | N_RETURN OUT NUMBER, /* RETURN VALUE */ V_RETURN OUT VARCHAR2 /* RETURN MESSA... |
| PROC | `PUT_OUT6` | N_RETURN OUT NUMBER, /* RETURN VALUE */ V_RETURN OUT VARCHAR2 /* RETURN MESSA... |
| PROC | `PUT_OUT7` | N_RETURN OUT NUMBER, /* RETURN VALUE */ V_RETURN OUT VARCHAR2 /* RETURN MESSA... |
| PROC | `PUT_OUT8` | N_RETURN OUT NUMBER, /* RETURN VALUE */ V_RETURN OUT VARCHAR2 /* RETURN MESSA... |
| PROC | `PUT_OUT_MATERIAL` | N_RETURN OUT NUMBER, /* RETURN VALUE */ -- V_RETURN OUT VARCHAR2 /* RETURN ME... |
| PROC | `PUT_OUT_DATE` | A_DATE IN VARCHAR2, -- N_RETURN OUT NUMBER, /* RETURN VALUE */ -- V_RETURN OU... |
| PROC | `PUT_BOM` | N_RETURN OUT NUMBER, /* RETURN VALUE */ V_RETURN OUT VARCHAR2 /* RETURN MESSA... |
| PROC | `PUT_PRODRESULT` | N_RETURN OUT NUMBER, /* RETURN VALUE */ V_RETURN OUT VARCHAR2 /* RETURN MESSA... |
| PROC | `PUT_PRODRECEIVE` | N_RETURN OUT NUMBER, /* RETURN VALUE */ V_RETURN OUT VARCHAR2 /* RETURN MESSA... |
| PROC | `PUT_PRODRETURN` | N_RETURN OUT NUMBER, /* RETURN VALUE */ V_RETURN OUT VARCHAR2 /* RETURN MESSA... |
| PROC | `PUT_PRODREREASE` | N_RETURN OUT NUMBER, /* RETURN VALUE */ V_RETURN OUT VARCHAR2 /* RETURN MESSA... |
| PROC | `PUT_EXPORT_OUT` | N_RETURN OUT NUMBER, /* RETURN VALUE */ -- V_RETURN OUT VARCHAR2 /* RETURN ME... |
| PROC | `PUT_TIF_STOCK` | N_RETURN OUT NUMBER, /* RETURN VALUE */ V_RETURN OUT VARCHAR2 /* RETURN MESSA... |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         PKGIF_ERP IS
    
      /* PO I/F ERP -> MES */
      PROCEDURE PUT_ORDER (N_RETURN         OUT  NUMBER,            /* RETURN VALUE */
                           V_RETURN         OUT  VARCHAR2          /* RETURN MESSAGE */
                          );
    
    
      /* INVOICE I/F ERP -> MES */
      PROCEDURE PUT_INVOICE (N_RETURN         OUT  NUMBER,            /* RETURN VALUE */
                             V_RETURN         OUT  VARCHAR2          /* RETURN MESSAGE */
                            );
                            
       /* 입고(로컬, 수입) I/F ERP -> MES */
      PROCEDURE PUT_IN(N_RETURN         OUT  NUMBER,            /* RETURN VALUE */
                       V_RETURN         OUT  VARCHAR2          /* RETURN MESSAGE */
                      );
    
    
    /* 입고(제품반품) I/F MES -> ERP */
      PROCEDURE PUT_RETURN_IN(N_RETURN         OUT  NUMBER,            /* RETURN VALUE */
                              V_RETURN         OUT  VARCHAR2          /* RETURN MESSAGE */
                             );
    
    
      /*품목 정보 : ERP → MES*/
    --  PROCEDURE PUT_ITEMS( N_RETURN         OUT     NUMBER,            /* RETURN VALUE */
    --                       V_RETURN         OUT     VARCHAR2          /* RETURN MESSAGE */
    --                     );
    
    
    --  /* 업체정보 I/F ERP -> MES */
    --  PROCEDURE PUT_VENDOR( N_RETURN        OUT     NUMBER,            /* RETURN VALUE */
    --                        V_RETURN        OUT     VARCHAR2          /* RETURN MESSAGE */
    --                      );
    
    --  /* 출고(이동, 불출, 생산출고) I/F MES -> ERP */
    --  PROCEDURE PUT_OUT( N_RETURN        OUT        NUMBER,            /* RETURN VALUE */
    --                     V_RETURN        OUT        VARCHAR2          /* RETURN MESSAGE */
    --                   );
                       
      /*자재불출 */
      PROCEDURE PUT_OUT1(N_RETURN         OUT  NUMBER,            /* RETURN VALUE */
                       V_RETURN         OUT  VARCHAR2          /* RETURN MESSAGE */
                      );
                      
      /*이동 출고 */
      PROCEDURE PUT_OUT2(N_RETURN         OUT  NUMBER,            /* RETURN VALUE */
                       V_RETURN         OUT  VARCHAR2          /* RETURN MESSAGE */
                      );
                      
      /* 자재 -> 외주 */
      PROCEDURE PUT_OUT3(N_RETURN         OUT  NUMBER,            /* RETURN VALUE */
                       V_RETURN         OUT  VARCHAR2          /* RETURN MESSAGE */
                      );
                      
      /* 외주 -> 자재 */
      PROCEDURE PUT_OUT3_1(N_RETURN         OUT  NUMBER,            /* RETURN VALUE */
                           V_RETURN         OUT  VARCHAR2          /* RETURN MESSAGE */
                          );
                      
      /* 제품 -> 고객 */
      PROCEDURE PUT_OUT4(N_RETURN         OUT  NUMBER,            /* RETURN VALUE */
                       V_RETURN         OUT  VARCHAR2          /* RETURN MESSAGE */
                      );
                      
      /*폐기 */
      PROCEDURE PUT_OUT5(N_RETURN         OUT  NUMBER,            /* RETURN VALUE */
                       V_RETURN         OUT  VARCHAR2          /* RETURN MESSAGE */
                      );
                      
      /* 재고보정, 재고실사 */
      PROCEDURE PUT_OUT6(N_RETURN         OUT  NUMBER,            /* RETURN VALUE */
                       V_RETURN         OUT  VARCHAR2          /* RETURN MESSAGE */
                      );
                      
      /*자재반품 */
      PROCEDURE PUT_OUT7(N_RETURN         OUT  NUMBER,            /* RETURN VALUE */
                       V_RETURN         OUT  VARCHAR2          /* RETURN MESSAGE */
                      );
                      
      /*품목대체 */
      PROCEDURE PUT_OUT8(N_RETURN         OUT  NUMBER,            /* RETURN VALUE */
                       V_RETURN         OUT  VARCHAR2          /* RETURN MESSAGE */
                      );
                                        
    
    
    --  /* 출고(불출) I/F MES -> ERP */
    --  PROCEDURE PUT_OUT_MATERIAL( N_RETURN      OUT     NUMBER,            /* RETURN VALUE */
    --                              V_RETURN      OUT     VARCHAR2          /* RETURN MESSAGE */
    --                            );
                      
    
    --  /* 출고(이동, 불출, 생산출고) I/F MES -> ERP */
    --  PROCEDURE PUT_OUT_DATE( A_DATE        IN      VARCHAR2,
    --                          N_RETURN     OUT      NUMBER,            /* RETURN VALUE */
    --                          V_RETURN     OUT      VARCHAR2          /* RETURN MESSAGE */
    --                        );
    
    
      /* BOM I/F MES -> ERP */
      PROCEDURE PUT_BOM( N_RETURN       OUT     NUMBER,            /* RETURN VALUE */
                         V_RETURN       OUT     VARCHAR2          /* RETURN MESSAGE */
                       );
    
    
      /* 생산실적 I/F MES -> ERP */
      PROCEDURE PUT_PRODRESULT( N_RETURN        OUT     NUMBER,            /* RETURN VALUE */
                                V_RETURN        OUT     VARCHAR2          /* RETURN MESSAGE */
                              );
    
    
      /* 제품 창고 입고  I/F PCB -> MES */
      PROCEDURE PUT_PRODRECEIVE( N_RETURN        OUT     NUMBER,            /* RETURN VALUE */
                                 V_RETURN        OUT     VARCHAR2          /* RETURN MESSAGE */
                                );
                                
                                
      /* 생산 창고 반납  I/F PCB -> MES */
      PROCEDURE PUT_PRODRETURN( N_RETURN        OUT     NUMBER,            /* RETURN VALUE */
                                V_RETURN        OUT     VARCHAR2          /* RETURN MESSAGE */
                              );                            
          
                            
      /* 제품 창고 출고  I/F PCB -> MES */
      PROCEDURE PUT_PRODREREASE( N_RETURN        OUT     NUMBER,            /* RETURN VALUE */
                                 V_RETURN        OUT     VARCHAR2          /* RETURN MESSAGE */
                                );                            
    
    --  /* 수출출고 I/F MES -> ERP */
    --  PROCEDURE PUT_EXPORT_OUT( N_RETURN        OUT     NUMBER,            /* RETURN VALUE */
    --                            V_RETURN        OUT     VARCHAR2          /* RETURN MESSAGE */
    --                          );
    
      /* 제품 창고 재고  I/F PCB -> MES */
      PROCEDURE PUT_TIF_STOCK  ( N_RETURN        OUT     NUMBER,            /* RETURN VALUE */
                                 V_RETURN        OUT     VARCHAR2          /* RETURN MESSAGE */
                                );
    
    END PKGIF_ERP;
    ```

**참조 테이블:**

`TH_BOM_THSERP`, `TH_EXPORT`, `TH_INVOICE_IN_THSERP`, `TH_ORDER_IN_THSERP`, `TH_OUT`, `TH_OUT_THSERP`, `TH_PRODRST_THSERP`, `TIF_STOCK`, `TM_BOM`, `TM_BOMGRP`, `TM_BOX`, `TM_CLOSINGBASE`, `TM_INVOICEDETAIL`, `TM_INVOICEMASTER`, `TM_ITEMS`, `TM_LOCATION`, `TM_ORDERDETAIL`, `TM_ORDERMASTER`, `TM_PRODLINE`, `TM_PRODLINE_UNIT`, `TM_SERIAL`, `TM_TRANSACTION`, `TM_VENDOR`, `TW_IN`, `TW_OUT`, `TW_PRODHIST`, `TW_STOCKSERIAL`

---

### PKGMAT_INOUT

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `GET_REQUESTPRINT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PRODMATERIALLOCATION` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PRODMATERIALREQUEST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PRODMATERIALREQUEST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PRODMATERIALDETAIL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_ORDER` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_ORDER` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_REELQTYSPLIT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_IQC_LIST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_LABEL_ORDER` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_CREATESN` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_CREATESN` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_NEW_CREATESN` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_NEW_CREATESN_ORGI` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_IQC_SERIAL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_IQC_JUDGE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_IQC_CANCEL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_REPRINT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_INOUT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_SPLITMERGE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_MATREQUESTNO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| FUNC | `F_GET_ITEMCODE` | A_ITEMCODE IN TM_ITEMS.ITEMCODE%TYPE → TM_ITEMS |
| FUNC | `FUN_CREATESN` | A_UNITQTY IN TM_SERIAL.QTY%TYPE, A_INQTY IN TM_SERIAL.QTY... → TB_MATSERIAL |
| FUNC | `F_GET_IVLABELPRT_QTY` | A_INVOICENO IN TM_SERIAL.INVOICENO%TYPE, A_ITEMCODE IN TM... → NUMBER |
| FUNC | `F_GET_ODLABELPRT_QTY` | A_ORDERNO IN TM_SERIAL.ORDERNO%TYPE, A_ORDERSEQ IN TM_SER... → NUMBER |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         PKGMAT_INOUT is
    
    
      -- 파트넘버
      FUNCTION F_GET_ITEMCODE( A_ITEMCODE IN      TM_ITEMS.ITEMCODE%TYPE
                             )
        RETURN TM_ITEMS.PARTNO%TYPE;
    
      FUNCTION FUN_CREATESN(A_UNITQTY      IN      TM_SERIAL.QTY%TYPE,
                            A_INQTY        IN      TM_SERIAL.QTY%TYPE)
        RETURN TB_MATSERIAL;
    
      -- Innvoice
      FUNCTION F_GET_IVLABELPRT_QTY( A_INVOICENO IN      TM_SERIAL.INVOICENO%TYPE,
                                     A_ITEMCODE  IN      TM_SERIAL.ITEMCODE%TYPE)
        RETURN NUMBER;
    
      FUNCTION F_GET_ODLABELPRT_QTY( A_ORDERNO   IN      TM_SERIAL.ORDERNO%TYPE,
                                     A_ORDERSEQ  IN      TM_SERIAL.ORDERSEQ%TYPE)
        RETURN NUMBER;
    
      PROCEDURE GET_REQUESTPRINT( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_RESPONSENO   IN      TW_RESPONSENO.RESPONSENO%TYPE,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                );
                                
                                
     -- 외주 자재 요청 업체 조회
      PROCEDURE GET_PRODMATERIALLOCATION( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                          A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                          A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                          A_SDATE        IN      TW_WORKORD.WRKDATE%TYPE,
                                          A_EDATE        IN      TW_WORKORD.WRKDATE%TYPE,
                                          N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                          V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                          C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                        );                            
    
    
     -- 자재요청 / 생산 작업지시 정보 조회
      PROCEDURE GET_PRODMATERIALREQUEST( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                         A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                         A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                         A_SDATE        IN      TW_WORKORD.WRKDATE%TYPE,
                                         A_EDATE        IN      TW_WORKORD.WRKDATE%TYPE,
                                         N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                         V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                         C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                       );
                                       
                                       
     -- 자재요청 / 생산 작업지시 정보 조회
      PROCEDURE GET_PRODMATERIALREQUEST( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                         A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                         A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                         A_VENDOR       IN      TW_MATERIALREQUSET.VENDOR%TYPE,
                                         A_WRKORDTYPE   IN      TW_WORKORD.WRKORDTYPE%TYPE,
                                         A_SDATE        IN      TW_WORKORD.WRKDATE%TYPE,
                                         A_EDATE        IN      TW_WORKORD.WRKDATE%TYPE,
                                         N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                         V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                         C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                       );   
                                       
                                       
     -- 자재요청 / 생산 작업지시 정보 상세 조회
      PROCEDURE GET_PRODMATERIALDETAIL( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                        A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                        A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                        A_REQUESTMATNO IN      TW_MATERIALREQUSET.REQUESTMATNO%TYPE,
                                        A_SEQ          IN      TW_MATERIALREQUSET.SEQ%TYPE,
                                        N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                        V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                        C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                       );
                                                                                                          
    
      -- PO AND INVOICE
      PROCEDURE GET_ORDER( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                           A_VENDOR       IN      TM_VENDOR.VENDOR%TYPE,
                           A_ITEMCODE     IN      TM_ITEMS.ITEMCODE%TYPE,
                           A_INVOICE      IN      VARCHAR2,
                           A_ORDERNO      IN      VARCHAR2,
                           N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                           V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                           C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                         );
                         
                         
      PROCEDURE GET_ORDER( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                           A_SDATE        IN      TW_IQC.IQCDATE%TYPE,
                           A_EDATE        IN      TW_IQC.IQCDATE%TYPE,
                           N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                           V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                           C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                          );
                                               
    
      -- NONE 재고 조회
      PROCEDURE GET_REELQTYSPLIT( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_WHLOC        IN      TM_VENDOR.VENDOR%TYPE,
                                  A_ITEMCODE     IN      TM_ITEMS.ITEMCODE%TYPE,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                );
                                
    
       /*IQC 등록 현황 조회*/
       PROCEDURE GET_IQC_LIST( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                               A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                               A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                               A_SDATE        IN      TW_IQC.IQCDATE%TYPE,
                               A_EDATE        IN      TW_IQC.IQCDATE%TYPE,
                               N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                               V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                               C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                             );
    
    
      PROCEDURE GET_LABEL_ORDER( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 A_TAB          IN      VARCHAR2,
                                 A_VENDOR       IN      TM_VENDOR.VENDOR%TYPE,
                                 A_ITEMCODE     IN      TM_ITEMS.ITEMCODE%TYPE,
                                 A_INVOICE      IN      TW_IQC.INVOICENO%TYPE,
                                 A_SDATE        IN      VARCHAR2,
                                 A_EDATE        IN      VARCHAR2,
                                 A_SERIAL       IN      TM_SERIAL.SERIAL%TYPE,
                                 N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                 V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                 C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                );
    
    
          -- SN 생성
      PROCEDURE SET_CREATESN( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              A_TYPE         IN      VARCHAR2,
                              A_ORDERNO      IN      TM_SERIAL.ORDERNO%TYPE,
                              A_ORDERSEQ     IN      TM_SERIAL.ORDERSEQ%TYPE,
                              A_INVOICENO    IN      TM_SERIAL.INVOICENO%TYPE,
                              A_VENDOR       IN      TM_SERIAL.VENDOR%TYPE,
                              A_ITEMCODE     IN      TM_SERIAL.ITEMCODE%TYPE,
                              A_UNITQTY      IN      TM_SERIAL.QTY%TYPE,
                              A_INQTY        IN      TM_SERIAL.QTY%TYPE,
                              A_TXNCODE      IN      VARCHAR2,
                              A_MAKER        IN      TM_SERIAL.MAKER%TYPE,
                              A_SLIPNO       IN      TM_SERIAL.SLIPNO%TYPE,
                              A_USER         IN      VARCHAR2,
                              N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                              V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                              C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                            );
    
    
      /* SN 생성*/
      PROCEDURE SET_CREATESN( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              A_TYPE         IN      VARCHAR2,
                              A_ORDERNO      IN      TM_SERIAL.ORDERNO%TYPE,
                              A_ORDERSEQ     IN      TM_SERIAL.ORDERSEQ%TYPE,
                              A_INVOICENO    IN      TM_SERIAL.INVOICENO%TYPE,
                              A_VENDOR       IN      TM_SERIAL.VENDOR%TYPE,
                              A_ITEMCODE     IN      TM_SERIAL.ITEMCODE%TYPE,
                              A_UNITQTY      IN      TM_SERIAL.QTY%TYPE,
                              A_INQTY        IN      TM_SERIAL.QTY%TYPE,
                              A_TXNCODE      IN      VARCHAR2,
                              A_BCDDATA      IN      TM_SERIAL.BCDDATA%TYPE,
                              A_BCDLOT       IN      TM_SERIAL.BCDLOT%TYPE,
                              A_MAKER        IN      TM_SERIAL.MAKER%TYPE,
                              A_SLIPNO       IN      TM_SERIAL.SLIPNO%TYPE,
                              A_USER         IN      VARCHAR2,
                              V_MATSERIAL   OUT      TB_MATSERIAL,
                              N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                              V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                              C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                            );
    
    
      PROCEDURE SET_NEW_CREATESN( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_TYPE         IN      VARCHAR2,
                                  A_ORDERNO      IN      TM_SERIAL.ORDERNO%TYPE,
                                  A_ORDERSEQ     IN      TM_SERIAL.ORDERSEQ%TYPE,
                                  A_INVOICENO    IN      TM_SERIAL.INVOICENO%TYPE,
                                  A_VENDOR       IN      TM_SERIAL.VENDOR%TYPE,
                                  A_ITEMCODE     IN      TM_SERIAL.ITEMCODE%TYPE,
                                  A_UNITQTY      IN      TM_SERIAL.QTY%TYPE,
                                  A_INQTY        IN      TM_SERIAL.QTY%TYPE,
                                  A_TXNCODE      IN      VARCHAR2,
                                  A_BCDDATA      IN      TM_SERIAL.BCDDATA%TYPE,
                                  A_BEFSN        IN      TM_SERIAL.PRESERIAL%TYPE,
                                  A_BCDLOT       IN      TM_SERIAL.BCDLOT%TYPE,
                                  A_MAKER        IN      TM_SERIAL.MAKER%TYPE,
                                  A_SLIPNO       IN      TM_SERIAL.SLIPNO%TYPE,
                                  A_IQCNO        IN      TW_IQC.IQCNO%TYPE,
                                  A_USER         IN      VARCHAR2,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                );
    
    
      PROCEDURE SET_NEW_CREATESN_ORGI( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                       A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                       A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                       A_TYPE         IN      VARCHAR2,
                                       A_ORDERNO      IN      TM_SERIAL.ORDERNO%TYPE,
                                       A_ORDERSEQ     IN      TM_SERIAL.ORDERSEQ%TYPE,
                                       A_INVOICENO    IN      TM_SERIAL.INVOICENO%TYPE,
                                       A_VENDOR       IN      TM_SERIAL.VENDOR%TYPE,
                                       A_ITEMCODE     IN      TM_ITEMS.ITEMCODE%TYPE,
                                       A_UNITQTY      IN      TM_SERIAL.QTY%TYPE,
                                       A_INQTY        IN      TM_SERIAL.QTY%TYPE,
                                       A_TXNCODE      IN      VARCHAR2,
                                       A_BCDDATA      IN      TM_SERIAL.BCDDATA%TYPE,
                                       A_BEFSN        IN      TM_SERIAL.PRESERIAL%TYPE,
                                       A_BCDLOT       IN      TM_SERIAL.BCDLOT%TYPE,
                                       A_MAKER        IN      TM_SERIAL.MAKER%TYPE,
                                       A_SLIPNO       IN      TM_SERIAL.SLIPNO%TYPE,
                                       A_IQCNO        IN      TW_IQC.IQCNO%TYPE,
                                       A_INDATE       IN      TM_SERIAL.INDATE%TYPE,
                                       A_USER         IN      VARCHAR2,
                                       V_MATSERIAL   OUT      TB_MATSERIAL,
                                       N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                       V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                       C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                     );
     
     
       /*IQC 시리얼 정보 조회*/
      PROCEDURE GET_IQC_SERIAL( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                               A_COMPANY       IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                               A_PLANT         IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                               A_PRTDATE       IN      TM_SERIAL.INDATE%TYPE,
                               A_ITEMCODE      IN      TM_SERIAL.ITEMCODE%TYPE,
                               N_RETURN       OUT      NUMBER,            /* RETURN VALUE */
                               V_RETURN       OUT      VARCHAR2,          /* RETURN MESSAGE */
                               C_RETURN       OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                             );
                                                              
                                      
      /*IQC 결과*/
      PROCEDURE SET_IQC_JUDGE ( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                A_PRTDATE      IN      VARCHAR2,
                                A_ITEMCODE     IN      TW_IQC.ITEMCODE%TYPE,
                                A_IQCQTY       IN      TW_IQC.IQCQTY%TYPE,
                                A_FILE         IN      TW_IQC.FPATH%TYPE,
                                A_DOCDATE      IN      TW_IQC.DOCDATE%TYPE,
                                A_JUDGE        IN      TW_IQC.IQCJUDGE%TYPE,
                                A_USER         IN      TW_IQC.CREATEUSER%TYPE,
                                N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                              );
    
    
      -- IQC 취소
      PROCEDURE SET_IQC_CANCEL( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                A_XML          IN      CLOB,
                                A_REMARKS      IN      TW_IQC.REMARKS%TYPE,
                                A_USER         IN      TW_IQC.CREATEUSER%TYPE,
                                N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                              );
    
    
      --재발행
      PROCEDURE SET_REPRINT( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                             A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                             A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                             A_PRINTTYPE    IN      VARCHAR2,
                             A_SN           IN      TM_SERIAL.SERIAL%TYPE,
                             A_BCDLOT       IN      TM_SERIAL.BCDLOT%TYPE,
                             A_IQCNO        IN      TW_IQC.IQCNO%TYPE,
                             A_USER         IN      VARCHAR2,
                             N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                             V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                             C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                           );
    
    
      -- IN/OUT
      PROCEDURE SET_INOUT( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                           A_TYPE         IN      VARCHAR2,
                           A_ITEMCODE     IN      TM_SERIAL.ITEMCODE%TYPE,
                           A_STOCKTYPE    IN      TW_OUT.STOCKTYPE%TYPE,
                           A_SN1          IN      TM_SERIAL.SERIAL%TYPE,
                           A_SN2          IN      TM_SERIAL.SERIAL%TYPE,
                           A_SN1WHLOC     IN      TW_STOCKSERIAL.WHLOC%TYPE,
                           A_SN2WHLOC     IN      TW_STOCKSERIAL.WHLOC%TYPE,
                           A_SN1QTY       IN      TW_STOCKSERIAL.GOODQTY%TYPE,
                           A_SN2QTY       IN      TW_STOCKSERIAL.GOODQTY%TYPE,
                           A_NEWSN1       IN      TM_SERIAL.SERIAL%TYPE,
                           A_NEWSN2       IN      TM_SERIAL.SERIAL%TYPE,
                           A_NEWSN1QTY    IN      TM_SERIAL.QTY%TYPE,
                           A_NEWSN2QTY    IN      TM_SERIAL.QTY%TYPE,
                           A_IQCNO        IN      TW_IQC.IQCNO%TYPE,
                           A_USER         IN      VARCHAR2,
                           N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                           V_RETURN      OUT      VARCHAR2           /* RETURN MESSAGE */
                         );
    
    
      PROCEDURE SET_SPLITMERGE( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                A_TYPE         IN      VARCHAR2,
                                A_SN1          IN      TM_SERIAL.SERIAL%TYPE,
                                A_SN2          IN      TM_SERIAL.SERIAL%TYPE,
                                A_SPLITQTY     IN      TW_STOCKSERIAL.GOODQTY%TYPE,
                                A_IQCNO        IN      TW_IQC.IQCNO%TYPE,
                                A_USER         IN      VARCHAR2,
                                N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                C_RETURN1     OUT      SYS_REFCURSOR,     /* RETURN CURSOR */
                                C_RETURN2     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                              );
    
    
      PROCEDURE SET_MATREQUESTNO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_XML          IN      CLOB,
                                  A_USER         IN      TW_RESPONSENO.CREATEUSER%TYPE,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                 );
    
    end PKGMAT_INOUT;
    ```

**참조 테이블:**

`TH_SPLITMERGE`, `TM_BOM`, `TM_CLIENT`, `TM_COMPANY`, `TM_INVOICEDETAIL`, `TM_INVOICEMASTER`, `TM_ITEMS`, `TM_LOCATION`, `TM_ORDERDETAIL`, `TM_ORDERMASTER`, `TM_PLANT`, `TM_SERIAL`, `TM_TRANSACTION`, `TM_VENDOR`, `TW_IN`, `TW_IQC`, `TW_IQC_SEQ`, `TW_MATERIALREQUSET`, `TW_OUT`, `TW_RESPONSENO`, `TW_STOCKSERIAL`, `TW_WORKORD`

---

### PKGPDA_COMM

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `GET_BASICSET` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, A_COMPANY IN TM_COMPANY.COMPANY%TYPE, A_PL... |
| PROC | `GET_BARCODETYPE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, A_COMPANY IN TM_COMPANY.COMPANY%TYPE, A_PL... |
| PROC | `SCN_INFO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, A_COMPANY IN TM_COMPANY.COMPANY%TYPE, A_PL... |
| PROC | `GET_LOC` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, A_COMPANY IN TM_COMPANY.COMPANY%TYPE, A_PL... |
| PROC | `GET_WH` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, A_COMPANY IN TM_COMPANY.COMPANY%TYPE, A_PL... |
| PROC | `GET_MATTYPE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, A_COMPANY IN TM_COMPANY.COMPANY%TYPE, A_PL... |
| PROC | `GET_PRODLINE_UNIT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, A_COMPANY IN TM_COMPANY.COMPANY%TYPE, A_PL... |
| PROC | `CHK_USERROLE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| FUNC | `F_GET_TRANSACTION` | A_TYPE IN VARCHAR2 → TM_TRANSACTION |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         PKGPDA_COMM is
      /*TRANSACTION CODE 조회*/
      FUNCTION F_GET_TRANSACTION( A_TYPE IN VARCHAR2)
        RETURN TM_TRANSACTION.TXNCODE%TYPE;
    
    
      /* 기초정보조회*/
      PROCEDURE GET_BASICSET( A_CLIENT        IN        TM_CLIENT.CLIENT%TYPE,
                              A_COMPANY       IN        TM_COMPANY.COMPANY%TYPE,
                              A_PLANT         IN        TM_PLANT.PLANT%TYPE,
                              N_RETURN       OUT        NUMBER,            /* RETURN VALUE */
                              V_RETURN       OUT        VARCHAR2,          /* RETURN MESSAGE */
                              C_RETURN1      OUT        SYS_REFCURSOR,     /* RETURN CURSOR */
                              C_RETURN2      OUT        SYS_REFCURSOR,      /* RETURN CURSOR */
                              C_RETURN3      OUT        SYS_REFCURSOR      /* RETURN CURSOR */
                             );
    
    
      /* BARCODE 유형 조회*/
      PROCEDURE GET_BARCODETYPE( A_CLIENT        IN        TM_CLIENT.CLIENT%TYPE,
                                 A_COMPANY       IN        TM_COMPANY.COMPANY%TYPE,
                                 A_PLANT         IN        TM_PLANT.PLANT%TYPE,
                                 A_JOB           IN        VARCHAR2,
                                 A_BARCODE       IN        VARCHAR2,
                                 N_RETURN       OUT        NUMBER,            /* RETURN VALUE */
                                 V_RETURN       OUT        VARCHAR2           /* RETURN MESSAGE */
                                );
    
    
      /* 스캐너이벤트  공통 호출*/
      PROCEDURE SCN_INFO( A_CLIENT        IN        TM_CLIENT.CLIENT%TYPE,
                          A_COMPANY       IN        TM_COMPANY.COMPANY%TYPE,
                          A_PLANT         IN        TM_PLANT.PLANT%TYPE,
                          A_JOB           IN        VARCHAR2,
                          A_BARCODE       IN        VARCHAR2,
                          A_PARAM1        IN        VARCHAR2,
                          A_PARAM2        IN        VARCHAR2,
                          A_PARAM3        IN        VARCHAR2,
                          A_PARAM4        IN        VARCHAR2,
                          A_PARAM5        IN        VARCHAR2,
                          N_RETURN       OUT        NUMBER,            /* RETURN VALUE */
                          V_RETURN       OUT        VARCHAR2,          /* RETURN MESSAGE */
                          C_RETURN1      OUT        SYS_REFCURSOR,     /* RETURN CURSOR */
                          C_RETURN2      OUT        SYS_REFCURSOR,     /* RETURN CURSOR */
                          C_RETURN3      OUT        SYS_REFCURSOR      /* RETURN CURSOR */
                        );
    
    
    
      /* 위치정보조회*/
      PROCEDURE GET_LOC( A_CLIENT        IN        TM_CLIENT.CLIENT%TYPE,
                         A_COMPANY       IN        TM_COMPANY.COMPANY%TYPE,
                         A_PLANT         IN        TM_PLANT.PLANT%TYPE,
                         A_WH            IN        TM_WAREHOUSE.WAREHOUSE%TYPE,
                         N_RETURN       OUT        NUMBER,            /* RETURN VALUE */
                         V_RETURN       OUT        VARCHAR2,          /* RETURN MESSAGE */
                         C_RETURN       OUT        SYS_REFCURSOR      /* RETURN CURSOR */
                        );
    
    
      /*창고정보 조회*/
      PROCEDURE GET_WH( A_CLIENT        IN        TM_CLIENT.CLIENT%TYPE,
                        A_COMPANY       IN        TM_COMPANY.COMPANY%TYPE,
                        A_PLANT         IN        TM_PLANT.PLANT%TYPE,
                        A_TYPE          IN        VARCHAR2,
                        N_RETURN       OUT        NUMBER,            /* RETURN VALUE */
                        V_RETURN       OUT        VARCHAR2,          /* RETURN MESSAGE */
                        C_RETURN       OUT        SYS_REFCURSOR      /* RETURN CURSOR */
                       );
    
      /*자재 유형 조회*/
      PROCEDURE GET_MATTYPE( A_CLIENT      IN  TM_CLIENT.CLIENT%TYPE,
                             A_COMPANY     IN  TM_COMPANY.COMPANY%TYPE,
                             A_PLANT       IN  TM_PLANT.PLANT%TYPE,
                             N_RETURN     OUT  NUMBER,            /* RETURN VALUE */
                             V_RETURN     OUT  VARCHAR2,          /* RETURN MESSAGE */
                             C_RETURN     OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                           );
    
     /*호기 정보 조회*/
      PROCEDURE GET_PRODLINE_UNIT( A_CLIENT        IN        TM_CLIENT.CLIENT%TYPE,
                                   A_COMPANY       IN        TM_COMPANY.COMPANY%TYPE,
                                   A_PLANT         IN        TM_PLANT.PLANT%TYPE,
                                   A_UNITNO        IN        TM_PRODLINE_UNIT.UNITNO%TYPE,
                                   N_RETURN       OUT        NUMBER,            /* RETURN VALUE */
                                   V_RETURN       OUT        VARCHAR2,          /* RETURN MESSAGE */
                                   C_RETURN       OUT        SYS_REFCURSOR      /* RETURN CURSOR */
                                 );
                                 
    
      -- 권한 조회
      PROCEDURE CHK_USERROLE( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              A_SYSTEM       IN      TM_SYSUSERROLE.SYSCODE%TYPE,/* SYSTEM Code */
                              A_USER_ID      IN      TM_USER.USERID%TYPE,
                              A_MENU         IN      VARCHAR2,
                              N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                              V_RETURN      OUT      VARCHAR2           /* RETURN MESSAGE */                          
                            );                                
    
    END PKGPDA_COMM;
    ```

**참조 테이블:**

`TM_BOX`, `TM_CLIENT`, `TM_COMPANY`, `TM_DEFECT`, `TM_EHR`, `TM_GLOSSARY`, `TM_ITEMS`, `TM_LOCATION`, `TM_MENU`, `TM_MENUROLE`, `TM_PLANT`, `TM_PRODLINE_UNIT`, `TM_SERIAL`, `TM_SYSTEM`, `TM_SYSUSERROLE`, `TM_TRANSACTION`, `TM_USER`, `TM_WAREHOUSE`, `TW_RESPONSENO`, `TW_WORKORD`

---

### PKGPDA_MAT

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `GET_RECEIVE_SNINFO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_RELEASE_SNINFO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_ACTUAL_SNINFO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_ACTUAL_SEMIBOXINFO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_ACTUAL_BOXINFO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_STOCK` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_STOCK_SNINFO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_STOCK_SNINFO2` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_STOCK_SNINFO3` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_OUTITEMINFO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_ACTUAL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_ACTUAL` | A_PLANT IN TM_PLANT.PLANT%TYPE, A_ACTUALMONTH IN TW_ACTUALSTOCK.ACTUALMON%TYP... |
| PROC | `SET_ACTUAL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_ACTUAL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_RECEIVE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_RECEIVE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_IQCRECEIVE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_QTYRECEIVE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_RCQTY` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_RELEASE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_RELEASE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_STOCKCORRECT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_SNSEPARATEQTY` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `CHK_INNO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `CHK_OUTNO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `CHK_AVAILABLE_SN` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `CHK_AVAILABLE_BOX` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `CHK_TRANSLOC_PART` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `CHK_RELEASE_PART` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `CHK_RELEASE_SN` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `CHK_TRANSLOC_SN` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `CHK_RESPONSENO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `CHK_FIFO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `CHK_BOM` | A_UPITEMCODE IN TM_ITEMS.ITEMCODE%TYPE, A_SUBITEMCODE IN TM_ITEMS.ITEMCODE%TY... |
| PROC | `CHK_VENDORPARTNO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PARTSTOCK` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_REPLACEITEM` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         PKGPDA_MAT IS
    
      PROCEDURE GET_RECEIVE_SNINFO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                    A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                    A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                    A_SN           IN      TM_SERIAL.SERIAL%TYPE,
                                    N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                    V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                    C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                   );
    
    
      /*출고 정보 조회*/
      PROCEDURE GET_RELEASE_SNINFO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                    A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                    A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                    A_JOB          IN      VARCHAR2,
                                    A_SN           IN      TM_SERIAL.SERIAL%TYPE,
                                    A_RESPONSENO   IN       TW_RESPONSENO.RESPONSENO%TYPE,
                                    A_PARAM1       IN      VARCHAR2,
                                    A_PARAM2       IN      VARCHAR2,
                                    N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                    V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                    C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                  );
    
        --재고실사 조회
      PROCEDURE GET_ACTUAL_SNINFO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                   A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                   A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                   A_LOC          IN      TM_LOCATION.WHLOC%TYPE,
                                   A_SN           IN      TM_SERIAL.SERIAL%TYPE,
                                   N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                   V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                   C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                 );
                                 
                                 
      /*재고 실사 정보 조회*/
      PROCEDURE GET_ACTUAL_SEMIBOXINFO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                        A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                        A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                        A_LOC          IN      TM_LOCATION.WHLOC%TYPE,
                                        A_BOXNO        IN      TM_BOX.BOXNO%TYPE,
                                        N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                        V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                        C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                      );
                                                                   
    
        -- 박스실사 조회
      PROCEDURE GET_ACTUAL_BOXINFO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                    A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                    A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                    A_BOXNO        IN      TM_BOX.BOXNO%TYPE,
                                    A_LOC          IN      TM_LOCATION.WHLOC%TYPE,
                                    N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                    V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                    C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                  );
    
    
      PROCEDURE GET_STOCK( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                           A_SERIAL       IN      TM_SERIAL.SERIAL%TYPE,
                           N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                           V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                           C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                          );
    
    
      PROCEDURE GET_STOCK_SNINFO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_SN           IN      TM_SERIAL.SERIAL%TYPE,
                                  A_WHLOC        IN      TM_LOCATION.WHLOC%TYPE,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                );
    
      -- 재고 보정 용도로 사용
      PROCEDURE GET_STOCK_SNINFO2( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                   A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                   A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                   A_SN           IN      TM_SERIAL.SERIAL%TYPE,
                                   A_WHLOC        IN      TM_LOCATION.WHLOC%TYPE,
                                   N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                   V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                   C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                 );
    
    
      PROCEDURE GET_STOCK_SNINFO3( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                   A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                   A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                   A_SN           IN      TM_SERIAL.SERIAL%TYPE,
                                   A_WHLOC        IN      TM_LOCATION.WHLOC%TYPE,
                                   N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                   V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                   C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                 );
    
    
    
      PROCEDURE GET_OUTITEMINFO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 A_JOB          IN      VARCHAR2,
                                 A_PARAM1       IN      VARCHAR2,
                                 A_PARAM2       IN      VARCHAR2,
                                 V_TXNCODE     OUT      TM_TRANSACTION.TXNCODE%TYPE,
                                 V_TOWHLOC     OUT      TW_OUT.TOWHLOC%TYPE,
                                 V_TOVENDOR    OUT      TW_OUT.TOVENDOR%TYPE,
                                 V_WRKORD      OUT      TW_OUT.WRKORD%TYPE,
                                 V_ORDERNO     OUT      TW_OUT.ORDERNO%TYPE,
                                 V_PRODLINE    OUT      TW_OUT.PRODLINE%TYPE,
                                 V_OPER        OUT      TW_OUT.OPER%TYPE,
                                 V_SIDE        OUT      TW_OUT.SIDE%TYPE,
                                 N_ORDSEQ      OUT      TW_OUT.ORDERSEQ%TYPE,
                                 N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                 V_RETURN      OUT      VARCHAR2           /* RETURN MESSAGE */
                               );
    
    
    /*재고 실사 정보 조회 (PDA)*/
      PROCEDURE GET_ACTUAL( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                            A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                            A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                            A_ACTUALMONTH  IN      TW_ACTUALSTOCK.ACTUALMON%TYPE,
                            A_NO           IN      VARCHAR2,
                            N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                            V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                            C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                          );
    
    
      -- 실사 등록
      PROCEDURE SET_ACTUAL( A_PLANT                IN  TM_PLANT.PLANT%TYPE,
                            A_ACTUALMONTH          IN  TW_ACTUALSTOCK.ACTUALMON%TYPE,
                            A_XML                  IN  CLOB,
                            A_EHRCODE              IN  VARCHAR2,
                            N_RETURN              OUT  NUMBER,            /* RETURN VALUE */
                            V_RETURN              OUT  VARCHAR2           /* RETURN MESSAGE */
                           );
    
                          
                          
      /*재고 실사 정보 저장(PDA)*/
      PROCEDURE SET_ACTUAL( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                            A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                            A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                            A_ACTUALMONTH  IN      TW_ACTUALSTOCK.ACTUALMON%TYPE,
                            A_LOC          IN      TW_ACTUALSTOCK.WHLOC%TYPE,
                            A_SN           IN      TW_ACTUALSTOCK.SERIAL%TYPE,
                            A_ITEMCODE     IN      TW_ACTUALSTOCK.ITEMCODE%TYPE,
                            A_TYPE         IN      TW_ACTUALSTOCK.STOCKTYPE%TYPE,
                            A_ACTUALQTY    IN      TW_ACTUALSTOCK.ACTUALQTY%TYPE,
                            A_EHRCODE      IN      VARCHAR2,
                            N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                            V_RETURN      OUT      VARCHAR2           /* RETURN MESSAGE */
                          );
                          
      /*재고 실사 정보 저장(PDA)*/
      PROCEDURE PUT_ACTUAL( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                            A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                            A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                            A_ACTUALMONTH  IN      TW_ACTUALSTOCK.ACTUALMON%TYPE,
                            A_LOC          IN      TW_ACTUALSTOCK.WHLOC%TYPE,
                            A_XML          IN      CLOB,
                            A_EHRCODE      IN      VARCHAR2,
                            N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                            V_RETURN      OUT      VARCHAR2           /* RETURN MESSAGE */
                          );                                            
    
    
      PROCEDURE SET_RECEIVE( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                             A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                             A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                             A_LOC          IN      TM_LOCATION.WHLOC%TYPE,
                             A_XML          IN      CLOB,
                             A_REMARKS      IN      TW_IN.REMARKS%TYPE,
                             A_EHRCODE      IN      TM_EHR.EHRCODE%TYPE,
                             N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                             V_RETURN      OUT      VARCHAR2           /* RETURN MESSAGE */
                           );
    
    
      PROCEDURE SET_RECEIVE( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                             A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                             A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                             A_INDATE       IN      TW_IN.INDATE%TYPE,
                             A_TXNTIMEKEY   IN      TW_IN.TXNTIMEKEY%TYPE,
                             A_TXNCODE      IN      TW_IN.TXNCODE%TYPE,
                             A_WHLOC        IN      TW_IN.WHLOC%TYPE,
                             A_VENDOR       IN      TW_IN.VENDOR%TYPE,
                             A_FROMWHLOC    IN      TW_IN.FROMWHLOC%TYPE,
                             A_FROMVENDOR   IN      TW_IN.FROMVENDOR%TYPE,
                             A_WRKORD       IN      TW_IN.WRKORD%TYPE,
                             A_ORDERNO      IN      TW_IN.ORDERNO%TYPE,
                             A_INVOICENO    IN      TW_IN.INVOICENO%TYPE,
                             A_ITEMCODE     IN      TW_IN.ITEMCODE%TYPE,
                             A_INQTY        IN      TW_IN.INQTY%TYPE,
                             A_CREATEUSER   IN      TW_IN.CREATEUSER%TYPE,
                             A_PRODLINE     IN      TW_IN.PRODLINE%TYPE,
                             A_OPER         IN      TW_IN.OPER%TYPE,
                             A_STOCKTYPE    IN      TW_IN.STOCKTYPE%TYPE,
                             A_SIDE         IN      TW_IN.SIDE%TYPE,
                             A_BCDDATA      IN      TM_SERIAL.BCDDATA%TYPE,
                             A_BCDLOT       IN      TM_SERIAL.BCDLOT%TYPE,
                             A_SERIAL       IN      TW_IN.SERIAL%TYPE,
                             A_ORDERSEQ     IN      TW_IN.ORDERSEQ%TYPE,
                             A_IQCNO        IN      TW_IN.IQCNO%TYPE,
                             A_REMARKS      IN      TW_IN.REMARKS%TYPE,
                             A_INNO         IN      TW_IN.INNO%TYPE,
                             A_OUTNO        IN      TW_IN.OUTNO%TYPE,
                             V_TXNTIMEKEY  OUT      TW_IN.TXNTIMEKEY%TYPE
                           );
    
    
    
      PROCEDURE SET_IQCRECEIVE( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                A_SERIAL       IN      TM_SERIAL.SERIAL%TYPE,
                                A_LOC          IN      TM_LOCATION.WHLOC%TYPE,
                                A_ITEMCODE     IN      TW_IQC.ITEMCODE%TYPE,
                                A_IQCQTY       IN      TW_IQC.IQCQTY%TYPE,
                                A_ORDERNO      IN      TW_IQC.ORDERNO%TYPE,
                                A_ORDERSEQ     IN      TW_IQC.ORDERSEQ%TYPE,
                                A_INVOICENO    IN      TW_IQC.INVOICENO%TYPE,
                                A_VENDOR       IN      TM_VENDOR.VENDOR%TYPE,
                                A_IQCNO        IN      TW_IQC.IQCNO%TYPE,
                                A_REMARKS      IN      TW_IQC.REMARKS%TYPE,
                                A_EHRCODE      IN      TM_EHR.EHRCODE%TYPE,
                                N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                            );
    
      -- 수량입고
      PROCEDURE SET_QTYRECEIVE( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                A_LOC          IN      TM_LOCATION.WHLOC%TYPE,
                                A_TXNCODE      IN      VARCHAR2,
                                A_ITEMCODE     IN      TM_ITEMS.ITEMCODE%TYPE,
                                A_QTY          IN      TW_IN.INQTY%TYPE,
                                A_ORDERNO      IN      TW_IN.ORDERNO%TYPE,
                                A_ORDERSEQ     IN      TW_IN.ORDERSEQ%TYPE,
                                A_INVOICENO    IN      TW_IN.INVOICENO%TYPE,
                                A_VENDOR       IN      TM_VENDOR.VENDOR%TYPE,
                                A_REMARKS      IN      TW_IQC.REMARKS%TYPE,
                                A_EHRCODE      IN      TM_EHR.EHRCODE%TYPE,
                                N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                            );
                            
                            
      PROCEDURE SET_RCQTY( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                           A_ORDERNO      IN      TM_ORDERDETAIL.ORDER_NO%TYPE,
                           A_ORDERSEQ     IN      TM_ORDERDETAIL.OPSEQ%TYPE,
                           A_INVOICENO    IN      TM_INVOICEDETAIL.BALJPNO%TYPE,
                           A_ITEMCODE     IN      TM_ITEMS.ITEMCODE%TYPE,
                           A_QTY          IN      TM_ORDERDETAIL.RCQTY%TYPE,
                           N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                           V_RETURN      OUT      VARCHAR2           /* RETURN MESSAGE */
                         );
    
    
      /*출고처리*/
      PROCEDURE SET_RELEASE( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                             A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                             A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                             A_JOB          IN      VARCHAR2,
                             A_PARAM1       IN      VARCHAR2,
                             A_PARAM2       IN      VARCHAR2,
                             A_XML          IN      CLOB,
                             A_REMARKS      IN      TW_OUT.REMARKS%TYPE,
                             A_EHRCODE      IN      TM_EHR.EHRCODE%TYPE,
                             N_RETURN      OUT      NUMBER,
                             V_RETURN      OUT      VARCHAR2
                           );
    
    
      PROCEDURE SET_RELEASE( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                             A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                             A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                             A_OUTDATE      IN      TW_OUT.OUTDATE%TYPE,
                             A_TXNTIMEKEY   IN      TW_OUT.TXNTIMEKEY%TYPE,
                             A_TXNCODE      IN      TW_OUT.TXNCODE%TYPE,
                             A_WHLOC        IN      TW_OUT.WHLOC%TYPE,
                             A_VENDOR       IN      TW_OUT.VENDOR%TYPE,
                             A_TOWHLOC      IN      TW_OUT.TOWHLOC%TYPE,
                             A_TOVENDOR     IN      TW_OUT.TOVENDOR%TYPE,
                             A_WRKORD       IN      TW_OUT.WRKORD%TYPE,
                             A_ORDERNO      IN      TW_OUT.ORDERNO%TYPE,
                             A_ITEMCODE     IN      TW_OUT.ITEMCODE%TYPE,
                             A_OUTQTY       IN      TW_OUT.OUTQTY%TYPE,
                             A_CREATEUSER   IN      TW_OUT.CREATEUSER%TYPE,
                             A_PRODLINE     IN      TW_OUT.PRODLINE%TYPE,
                             A_OPER         IN      TW_OUT.OPER%TYPE,
                             A_STOCKTYPE    IN      TW_OUT.STOCKTYPE%TYPE,
                             A_SIDE         IN      TW_OUT.SIDE%TYPE,
                             A_SERIAL       IN      TW_OUT.SERIAL%TYPE,
                             A_REMARKS      IN      TW_OUT.REMARKS%TYPE,
                             A_ORDERSEQ     IN      TW_OUT.ORDERSEQ%TYPE,
                             A_RESPONSENO   IN      TW_OUT.RESPONSENO%TYPE,
                             A_INNO         IN      TW_OUT.INNO%TYPE,
                             A_OUTNO        IN      TW_OUT.OUTNO%TYPE,
                             V_TXNTIMEKEY  OUT      TW_OUT.TXNTIMEKEY%TYPE
                           );
    
    
    /*재고 보정*/
      PROCEDURE SET_STOCKCORRECT( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_LOC          IN      TM_LOCATION.WHLOC%TYPE,
                                  A_SN           IN      TM_SERIAL.SERIAL%TYPE,
                                  A_ITEMCODE     IN      TM_ITEMS.ITEMCODE%TYPE,
                                  A_TYPE         IN      VARCHAR2,
                                  A_STOCKQTY     IN      TW_STOCKSERIAL.GOODQTY%TYPE,
                                  A_CORRECTQTY   IN      TW_STOCKSERIAL.BADQTY%TYPE,
                                  A_CORRECTTYPE  IN      VARCHAR2,
                                  A_REMARKS      IN      VARCHAR2,
                                  A_EHRCODE      IN      VARCHAR2,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2           /* RETURN MESSAGE */
                                );
    
    
      PROCEDURE SET_SNSEPARATEQTY( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                   A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                   A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                   A_SN           IN      TM_SERIAL.SERIAL%TYPE,
                                   A_STOCKQTY     IN      TW_STOCKSERIAL.GOODQTY%TYPE,
                                   A_SEPARATEQTY  IN      TW_STOCKSERIAL.GOODQTY%TYPE,
                                   A_EHRCODE      IN      VARCHAR2,
                                   N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                   V_RETURN      OUT      VARCHAR2           /* RETURN MESSAGE */
                                 );
    
    
        --입고번호 체크
      PROCEDURE CHK_INNO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                          A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                          A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                          A_SN           IN      TW_IN.SERIAL%TYPE,
                          N_RETURN      OUT      NUMBER,
                          V_RETURN      OUT      VARCHAR2
                         );
                         
                         
        --출고번호 체크
      PROCEDURE CHK_OUTNO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                           A_SN           IN      TW_OUT.SERIAL%TYPE,
                           N_RETURN      OUT      NUMBER,
                           V_RETURN      OUT      VARCHAR2
                         );
    
    
      /* 시리얼 체크*/
      PROCEDURE CHK_AVAILABLE_SN( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_SN           IN      TM_SERIAL.SERIAL%TYPE,
                                  A_CHKSTOCK     IN      VARCHAR2,
                                  N_RETURN      OUT      NUMBER,
                                  V_RETURN      OUT      VARCHAR2
                                );
    
    
    /* 박스 넘버 체크 */
      PROCEDURE CHK_AVAILABLE_BOX(A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_BOXNO        IN      TM_BOX.BOXNO%TYPE,
                                  A_CHKSTOCK     IN      VARCHAR2,
                                  N_RETURN      OUT      NUMBER,
                                  V_RETURN      OUT      VARCHAR2
                                );
    
      PROCEDURE CHK_TRANSLOC_PART( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                   A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                   A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                   A_WHLOC        IN      TM_LOCATION.WHLOC%TYPE,
                                   A_ITEMCODE     IN      TM_ITEMS.ITEMCODE%TYPE,
                                   A_TYPE         IN      VARCHAR2,
                                   A_QTY          IN      TW_STOCKSERIAL.GOODQTY%TYPE,
                                   A_TOWHLOC      IN      TM_LOCATION.WHLOC%TYPE,
                                   N_RETURN      OUT      NUMBER,
                                   V_RETURN      OUT      VARCHAR2
                                 );
    
    
      PROCEDURE CHK_RELEASE_PART( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_JOB          IN      VARCHAR2,
                                  A_WHLOC        IN      TM_LOCATION.WHLOC%TYPE,
                                  A_ITEMCODE     IN      TM_ITEMS.ITEMCODE%TYPE,
                                  A_TYPE         IN      VARCHAR2,
                                  A_QTY          IN      TW_STOCKSERIAL.GOODQTY%TYPE,
                                  A_PARAM1       IN      VARCHAR2,
                                  A_PARAM2       IN      VARCHAR2,
                                  N_RETURN      OUT      NUMBER,
                                  V_RETURN      OUT      VARCHAR2
                                );
    
    
      PROCEDURE CHK_RELEASE_SN( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                A_JOB          IN      VARCHAR2,
                                A_SN           IN      TM_SERIAL.SERIAL%TYPE,
                                A_PARAM1       IN      VARCHAR2,
                                A_PARAM2       IN      VARCHAR2,
                                N_RETURN      OUT      NUMBER,
                                V_RETURN      OUT      VARCHAR2
                               );
    
    
      /* 이동체크 */
      PROCEDURE CHK_TRANSLOC_SN( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 A_SN           IN      TM_SERIAL.SERIAL%TYPE,
                                 A_WHLOC        IN      TM_LOCATION.WHLOC%TYPE,
                                 A_STOCKTYPE    IN      VARCHAR2,
                                 N_RETURN      OUT      NUMBER,
                                 V_RETURN      OUT      VARCHAR2
                               );
    
    
      /* 요청번호 체크 */
      PROCEDURE CHK_RESPONSENO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                A_RESPONSENO   IN      VARCHAR2,
                                A_SN           IN      TM_SERIAL.SERIAL%TYPE,
                                N_RETURN      OUT      NUMBER,
                                V_RETURN      OUT      VARCHAR2
                               );
    
    
      PROCEDURE CHK_FIFO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                          A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                          A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                          A_JOB          IN      VARCHAR2,
                          A_SERIAL       IN      TM_SERIAL.SERIAL%TYPE,
                          A_PARAM        IN      VARCHAR2,
                          N_RETURN      OUT      NUMBER,            /* RETURN VALUE    */
                          V_RETURN      OUT      VARCHAR2             /* RETURN MESSAGE  */
                        );
    
    
      PROCEDURE CHK_BOM( A_UPITEMCODE   IN      TM_ITEMS.ITEMCODE%TYPE,
                         A_SUBITEMCODE  IN      TM_ITEMS.ITEMCODE%TYPE,
                         N_RETURN      OUT      NUMBER,
                         V_RETURN      OUT      VARCHAR2
                        );
    
    
      /*업체 바코드 체크*/
      PROCEDURE CHK_VENDORPARTNO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_SN           IN      TM_SERIAL.SERIAL%TYPE,
                                  A_VENDORPARTNO IN      VARCHAR2,
                                  N_RETURN      OUT      NUMBER,
                                  V_RETURN      OUT      VARCHAR2
                                );
    
    
      /* 품번 재고조회*/
      PROCEDURE GET_PARTSTOCK( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                               A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                               A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                               A_LOC          IN      TM_LOCATION.WHLOC%TYPE,
                               A_PARTNO       IN      TM_ITEMS.PARTNO%TYPE,
                               N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                               V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                               C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                             );
                             
                             
      -- 품목 대체
      PROCEDURE SET_REPLACEITEM( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 A_LOC          IN      TM_LOCATION.WHLOC%TYPE,
                                 A_SN           IN      TM_SERIAL.SERIAL%TYPE,
                                 A_SN_NEW       IN      TM_SERIAL.SERIAL%TYPE,
                                 A_TYPE         IN      VARCHAR2,
                                 A_ITEMCODE1    IN      TM_ITEMS.ITEMCODE%TYPE,
                                 A_ITEMCODE2    IN      TM_ITEMS.ITEMCODE%TYPE,
                                 A_STOCKQTY     IN      TW_STOCKSERIAL.GOODQTY%TYPE,
                                 A_REMARKS      IN      VARCHAR2,
                                 A_EHRCODE      IN      VARCHAR2,
                                 N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                 V_RETURN      OUT      VARCHAR2           /* RETURN MESSAGE */
                                );
    
    end PKGPDA_MAT;
    ```

**참조 테이블:**

`TH_BOX`, `TM_BOM`, `TM_BOMGRP`, `TM_BOX`, `TM_CLIENT`, `TM_COMPANY`, `TM_EHR`, `TM_INVOICEDETAIL`, `TM_INVOICEMASTER`, `TM_ITEMS`, `TM_LOCATION`, `TM_OPERATION`, `TM_ORDERDETAIL`, `TM_ORDERMASTER`, `TM_PLANT`, `TM_PRODLINE`, `TM_SERIAL`, `TM_SUBITEMS`, `TM_TRANSACTION`, `TM_VENDOR`, `TM_WAREHOUSE`, `TW_ACTUALSTOCK`, `TW_IN`, `TW_IQC`, `TW_MOUNT`, `TW_OUT`, `TW_RESPONSENO`, `TW_STOCKSERIAL`, `TW_WORKORD`

---

### PKGPDA_PROD

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `GET_PROD_START_END_INFO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_PROD_START_END` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_WO_SNINFO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_MOUNT_SNINFO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_MOUNT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PROD_SNINFO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_PROD_REG` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_QTYPACKING` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_OSC_RELEASE_SNINFO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_OSC_RELEASE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_OSC_RECEIVE_SNINFO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_OSC_RECEIVE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_SEMIPACKING` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_OSC_TRANS_SNINFO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_OSC_TRANSLOC` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         PKGPDA_PROD IS
    
      /* 작업지시 시작/ 종료상태 조회 */
      PROCEDURE GET_PROD_START_END_INFO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                         A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                         A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                         A_WRKORD       IN      TW_WORKORD.WRKORD%TYPE,
                                         A_WRKORDSEQ    IN      TW_WORKORD.WRKORDSEQ%TYPE,
                                         A_JOB          IN      VARCHAR2,
                                         N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                         V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                         C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                       );
                                       
                                       
      /* 작업지시 시작/ 종료 */
      PROCEDURE SET_PROD_START_END( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                    A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                    A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                    A_WRKORD       IN      TW_WORKORD.WRKORD%TYPE,
                                    A_WRKORDSEQ    IN      TW_WORKORD.WRKORDSEQ%TYPE,
                                    A_JOB          IN      VARCHAR2,
                                    A_USER         IN      TM_USER.USERID%TYPE,
                                    N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                    V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                    C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                  );
                                  
                                  
      /* 작업 지시 정보 조회 */
      PROCEDURE GET_WO_SNINFO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                               A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                               A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                               A_WRKORD       IN      TW_WORKORD.WRKORD%TYPE,
                               A_WRKORDSEQ    IN      TW_WORKORD.WRKORDSEQ%TYPE,
                               N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                               V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                               C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                             );
                                                  
                             
      /* 장착  정보 조회 */
      PROCEDURE GET_MOUNT_SNINFO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_WRKORD       IN      TW_WORKORD.WRKORD%TYPE,
                                  A_UNITNO       IN      TW_MOUNT.UNITNO%TYPE,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                );                         
                           
        
      /* 자재장착 */
      PROCEDURE SET_MOUNT( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                           A_WRKORD       IN      TW_WORKORD.WRKORD%TYPE,
                           A_SERIAL       IN      TW_MOUNT.SERIAL%TYPE,
                           A_UNITNO       IN      TW_MOUNT.UNITNO%TYPE,
                           A_SIDE         IN      TW_MOUNT.SIDE%TYPE,
                           A_USER         IN      TM_USER.USERID%TYPE,
                           N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                           V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                           C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                         );                         
                             
                         
      /* 생산 실적 정보 조회 */
      PROCEDURE GET_PROD_SNINFO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 A_BARCODE      IN      TM_SERIAL.SERIAL%TYPE,
                                 N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                 V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                 C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                               );  
                               
                               
      /* 생산 실적 등록 */
      PROCEDURE SET_PROD_REG( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              A_WRKORD       IN      TW_WORKORD.WRKORD%TYPE,
                              A_UNITNO       IN      TW_MOUNT.UNITNO%TYPE,
                              A_SERIAL       IN      TM_SERIAL.SERIAL%TYPE,
                              A_PRODQTY      IN      TW_PRODHIST.PRODQTY%TYPE,
                              A_USER         IN      TM_USER.USERID%TYPE,
                              N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                              V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                              C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                            );
                            
    
      /* 수량 포장(PDA) */
      PROCEDURE PUT_QTYPACKING( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                A_XML          IN      CLOB,
                                A_USER         IN      TM_USER.USERID%TYPE,
                                N_RETURN      OUT      NUMBER,            /* RETURN VALUE    */
                                V_RETURN      OUT      VARCHAR2,            /* RETURN MESSAGE  */
                                C_RETURN      OUT      SYS_REFCURSOR        /* RETURN CURSOR  */
                               );        
                               
                               
      /*외주 출고 정보 조회*/
      PROCEDURE GET_OSC_RELEASE_SNINFO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                        A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                        A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                        A_SN           IN      TM_SERIAL.SERIAL%TYPE,
                                        N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                        V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                        C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                      );      
    
    
      /*외주 출고*/
      PROCEDURE SET_OSC_RELEASE( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 A_LOC          IN      TM_LOCATION.WHLOC%TYPE,
                                 A_XML          IN      CLOB,
                                 A_REMARKS      IN      TW_IN.REMARKS%TYPE,
                                 A_USER         IN      TM_EHR.EHRCODE%TYPE,
                                 N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                 V_RETURN      OUT      VARCHAR2           /* RETURN MESSAGE */
                               );
                               
                               
      /*외주 입고 정보 조회*/
      PROCEDURE GET_OSC_RECEIVE_SNINFO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                        A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                        A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                        A_SN           IN      TM_SERIAL.SERIAL%TYPE,
                                        N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                        V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                        C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                       );                                                             
                                      
      /*외주 입고*/
      PROCEDURE SET_OSC_RECEIVE( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 A_LOC          IN      TM_LOCATION.WHLOC%TYPE,
                                 A_XML          IN      CLOB,
                                 A_REMARKS      IN      TW_IN.REMARKS%TYPE,
                                 A_USER         IN      TM_EHR.EHRCODE%TYPE,
                                 N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                 V_RETURN      OUT      VARCHAR2           /* RETURN MESSAGE */
                               );
                               
                               
      /* 반제품 포장 */
      PROCEDURE PUT_SEMIPACKING( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 A_BOXNO        IN      TM_BOX.BOXNO%TYPE,
                                 A_XML          IN      CLOB,
                                 A_USER         IN      TM_USER.USERID%TYPE,
                                 N_RETURN      OUT      NUMBER,            /* RETURN VALUE    */
                                 V_RETURN      OUT      VARCHAR2,            /* RETURN MESSAGE  */
                                 C_RETURN      OUT      SYS_REFCURSOR        /* RETURN CURSOR  */
                                );   
                                
                                
      /*반제품 이동 조회*/
      PROCEDURE GET_OSC_TRANS_SNINFO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                      A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                      A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                      A_BOXNO        IN      TM_BOX.BOXNO%TYPE,
                                      N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                      V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                      C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                    );    
                
                          
      /*반제품이동*/
      PROCEDURE SET_OSC_TRANSLOC( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_LOC          IN      TM_LOCATION.WHLOC%TYPE,
                                  A_XML          IN      CLOB,
                                  A_REMARKS      IN      TW_IN.REMARKS%TYPE,
                                  A_USER         IN      TM_EHR.EHRCODE%TYPE,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2           /* RETURN MESSAGE */
                                );                                                                                                                                                                                                          
                                                                                                                                                                                   
    END PKGPDA_PROD;
    ```

**참조 테이블:**

`TH_BOX`, `TH_WORKORD`, `TM_BOM`, `TM_BOX`, `TM_CLIENT`, `TM_COMPANY`, `TM_EHR`, `TM_ITEMS`, `TM_LOCATION`, `TM_PLANT`, `TM_PRODLINE`, `TM_PRODLINE_UNIT`, `TM_SERIAL`, `TM_SUBITEMS`, `TM_USER`, `TM_VENDOR`, `TW_IN`, `TW_MOUNT`, `TW_OUT`, `TW_PRODHIST`, `TW_PRODHIST_USE`, `TW_STOCKSERIAL`, `TW_WORKORD`

---

### PKGPDA_SALES

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `SET_INOUT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_TRANSLOC` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_DELIVERY` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_RETURNRECEIVE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_TEMPTRANSLOC` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         PKGPDA_SALES is
    
      /* 제품 입고 / 출하 / 생산반납 */
      PROCEDURE SET_INOUT( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                           A_JOB          IN      VARCHAR2,
                           A_OUTDATE      IN      TW_OUT.OUTDATE%TYPE,
                           A_WHLOC        IN      TM_LOCATION.WHLOC%TYPE,
                           A_XML          IN      CLOB,
                           A_REMARKS      IN      TW_OUT.REMARKS%TYPE,
                           A_USER         IN      TM_EHR.EHRCODE%TYPE,
                           N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                           V_RETURN      OUT      VARCHAR2           /* RETURN MESSAGE */
                         );
                         
      /*제품 입고 / 생산 반납*/
      PROCEDURE SET_TRANSLOC( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              A_JOB          IN      VARCHAR2,
                              A_WHLOC        IN      TM_LOCATION.WHLOC%TYPE,
                              A_XML          IN      CLOB,
                              A_USER         IN      TM_EHR.EHRCODE%TYPE,
                              N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                              V_RETURN      OUT      VARCHAR2           /* RETURN MESSAGE */
                            );
                            
                            
      /*제품 출하*/
      PROCEDURE SET_DELIVERY( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              A_JOB          IN      VARCHAR2,
                              A_OUTDATE      IN      TW_OUT.OUTDATE%TYPE,
                              A_WHLOC        IN      TM_LOCATION.WHLOC%TYPE,
                              A_XML          IN      CLOB,
                              A_USER         IN      TM_EHR.EHRCODE%TYPE,
                              N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                              V_RETURN      OUT      VARCHAR2           /* RETURN MESSAGE */
                            );
                            
                            
      /*출하 반납*/
      PROCEDURE SET_RETURNRECEIVE( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                   A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                   A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                   A_JOB          IN      VARCHAR2,
                                   A_WHLOC        IN      TM_LOCATION.WHLOC%TYPE,
                                   A_XML          IN      CLOB,
                                   A_USER         IN      TM_EHR.EHRCODE%TYPE,
                                   N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                   V_RETURN      OUT      VARCHAR2           /* RETURN MESSAGE */
                                 );
                                 
    
      /*제품 입고 / 생산 반납*/
      PROCEDURE SET_TEMPTRANSLOC( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_JOB          IN      VARCHAR2,
                                  A_WHLOC        IN      TM_LOCATION.WHLOC%TYPE,
                                  A_USER         IN      TM_EHR.EHRCODE%TYPE,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2           /* RETURN MESSAGE */
                                );                                                                     
      
    end PKGPDA_SALES;
    ```

**참조 테이블:**

`TM_BOX`, `TM_CLIENT`, `TM_COMPANY`, `TM_EHR`, `TM_ITEMS`, `TM_LOCATION`, `TM_PLANT`, `TM_TRANSACTION`, `TW_IN`, `TW_OQC`, `TW_OUT`, `TW_STOCKSERIAL`

---

### PKGPRD_CHECK

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `CHK_BOXNO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `CHK_SERIAL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         PKGPRD_CHECK IS
    
      /* BOX 체크 */
      PROCEDURE CHK_BOXNO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                           A_TYPE         IN      VARCHAR2,
                           A_BOXNO        IN      TM_BOX.BOXNO%TYPE,
                           N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                           V_RETURN      OUT      VARCHAR2           /* RETURN MESSAGE */                       
                         );
                         
                         
     /* SERIAL 체크 */
      PROCEDURE CHK_SERIAL( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                            A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                            A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                            A_TYPE         IN      VARCHAR2,
                            A_SERIAL       IN      VARCHAR2,
                            A_BOXNO        IN      TM_BOX.BOXNO%TYPE,
                            N_RETURN      OUT      NUMBER,            /* RETURN VALUE    */
                            V_RETURN      OUT      VARCHAR2           /* RETURN MESSAGE  */
                          );                     
                         
    END PKGPRD_CHECK;
    ```

**참조 테이블:**

`TM_BOX`, `TM_CLIENT`, `TM_COMPANY`, `TM_ITEMS`, `TM_LOCATION`, `TM_OPERATION`, `TM_PLANT`, `TM_SERIAL`, `TM_TRANSACTION`, `TM_WAREHOUSE`, `TW_IN`, `TW_MOUNT`, `TW_OUT`, `TW_PRODHIST`, `TW_STOCKSERIAL`

---

### PKGPRD_CURRENT

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `GET_PROD_UNITITEM_HISTORY` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PROD_WRKORD_HISTORY` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PROD_WRKORD_HISTORY` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PROD_LABELTEXT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PROD_PRODQTY` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PROD_PRODQTY` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PROD_PRODQTY` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_PROD_CYCLECHECK` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_PROD_PRODUCTION` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_PROD_PRODUCTION` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_PROD_PRODUCTION` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_PROD_PRODUCTION` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_PROD_PRODUCTION` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_PROD_PRODUCTION` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_PROD_PRODUCTION_OS` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_PROD_REWORK` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_DAILY_WORKPLAN` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_DAILY_WORKPLAN` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_DAILY_WORKPLAN` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_DAILY_WORKPLAN` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_CIRCUIT_REPINT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_VISUAL_INSPECTION` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_VISUAL_INSPECTION` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_VISUAL_INSPECTION` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_VISUAL_INSPECTION` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PROD_MOUNT_SERIAL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `CHK_PARTNO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_GP12_INSPECTION` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `CHK_PARTNO_GP12` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         PKGPRD_CURRENT IS
                                         
      /*통전검사(일반) 호기/품목별 검사 이력 조회*/
      PROCEDURE GET_PROD_UNITITEM_HISTORY( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                           A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                           A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                           A_UNITNO       IN      TW_PRODHIST.UNITNO%TYPE,
                                           A_ITEMCODE     IN      TW_WORKORD.ITEMCODE%TYPE,
                                           N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                           V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                           C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                         ); 
                                         
                                         
      /*통전검사(일반) 작업지시별 검사 이력 조회*/
      PROCEDURE GET_PROD_WRKORD_HISTORY( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                         A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                         A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                         A_WRKORD       IN      TW_WORKORD.WRKORD%TYPE,
                                         N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                         V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                         C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                       );
                                       
                                       
        /*통전검사(일반) 작업지시별 검사 이력 조회*/
      PROCEDURE GET_PROD_WRKORD_HISTORY( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                         A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                         A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                         A_WRKORD       IN      TW_WORKORD.WRKORD%TYPE,
                                         A_UNITNO       IN      TW_PRODHIST.UNITNO%TYPE,
                                         N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                         V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                         C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                       );                                     
                                         
                                         
      /*통전검사(일반) 라벨 텍스트 조회*/
      PROCEDURE GET_PROD_LABELTEXT( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                    A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                    A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                    A_UNITNO       IN      TW_PRODHIST.UNITNO%TYPE,
                                    A_ITEMCODE     IN      TW_WORKORD.ITEMCODE%TYPE,
                                    A_SERIAL       IN      TM_SERIAL.SERIAL%TYPE,
                                    A_REWORK       IN      VARCHAR2,
                                    A_USER         IN      TM_USER.USERID%TYPE,
                                    N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                    V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                    C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                  );                                                          
                          
                          
      /*통전검사(일반) 생산 수량 정보  조회*/
      PROCEDURE GET_PROD_PRODQTY( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_PRODTYPE     IN      TW_PRODHIST.PRODTYPE%TYPE,
                                  A_UNITNO       IN      TW_PRODHIST.UNITNO%TYPE,
                                  A_ITEMCODE     IN      TW_WORKORD.ITEMCODE%TYPE,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                );    
                                   
                                
      /*통전검사(배판) 생산 수량 정보  조회*/
      PROCEDURE GET_PROD_PRODQTY( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_SERIAL       IN      TM_SERIAL.SERIAL%TYPE,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                ); 
                                
                                
      /*통전검사(배판) 생산 수량 정보  조회*/
      PROCEDURE GET_PROD_PRODQTY( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_WRKORD       IN      TW_WORKORD.WRKORD%TYPE,
                                  A_UNITNO       IN      TW_PRODHIST.UNITNO%TYPE,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                );                           
                                   
                                
      /*통전검사(일반) 주기검사 이력 등록*/
      PROCEDURE SET_PROD_CYCLECHECK( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                     A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                     A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                     A_UNITNO       IN      TW_PRODHIST.UNITNO%TYPE,
                                     A_ITEMCODE     IN      TW_WORKORD.ITEMCODE%TYPE,
                                     A_USER         IN      TM_USER.USERID%TYPE,
                                     N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                     V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                     C_RETURN      OUT      SYS_REFCURSOR,      /* RETURN CURSOR */
                                     C_RETURN1     OUT      SYS_REFCURSOR,      /* RETURN CURSOR */
                                     C_RETURN2     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                   );  
    
                                   
      /*통전검사(일반) 생산 이력 등록*/
      PROCEDURE SET_PROD_PRODUCTION( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                     A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                     A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                     A_WRKORD       IN      TW_PRODHIST.WRKORD%TYPE,
                                     A_WRKORDSEQ    IN      TW_PRODHIST.WRKORDSEQ%TYPE,
                                     A_PRODTYPE     IN      TW_PRODHIST.PRODTYPE%TYPE,
                                     A_PRODLINE     IN      TM_PRODLINE.PRODLINE%TYPE,
                                     A_UNITNO       IN      TW_PRODHIST.UNITNO%TYPE,
                                     A_ITEMCODE     IN      TW_WORKORD.ITEMCODE%TYPE,
                                     A_JUDGE        IN      TW_PRODHIST.JUDGE%TYPE,
                                     A_DEFECT       IN      TW_PRODHIST.DEFECT%TYPE,
                                     A_USER         IN      TM_USER.USERID%TYPE,
                                     N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                     V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                     C_RETURN      OUT      SYS_REFCURSOR,     /* RETURN CURSOR */
                                     C_RETURN1     OUT      SYS_REFCURSOR,     /* RETURN CURSOR */
                                     C_RETURN2     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                   );
                                   
    
      /*통전검사(배판) 생산 이력 등록*/
      PROCEDURE SET_PROD_PRODUCTION( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                     A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                     A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                     A_WRKORD       IN      TW_PRODHIST.WRKORD%TYPE,
                                     A_PRODLINE     IN      TM_PRODLINE.PRODLINE%TYPE,
                                     A_UNITNO       IN      TW_PRODHIST.UNITNO%TYPE,
                                     A_ITEMCODE     IN      TW_WORKORD.ITEMCODE%TYPE,
                                     A_JUDGE        IN      TW_PRODHIST.JUDGE%TYPE,
                                     A_DEFECT       IN      TW_PRODHIST.DEFECT%TYPE,
                                     A_USER         IN      TM_USER.USERID%TYPE,
                                     N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                     V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                     C_RETURN      OUT      SYS_REFCURSOR,     /* RETURN CURSOR */
                                     C_RETURN1     OUT      SYS_REFCURSOR,     /* RETURN CURSOR */
                                     C_RETURN2     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                   );  
                                   
                                   
      /*통전검사(배판) 생산 이력 등록*/
      PROCEDURE SET_PROD_PRODUCTION( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                     A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                     A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                     A_WRKORD       IN      TW_PRODHIST.WRKORD%TYPE,
                                     A_PRODLINE     IN      TM_PRODLINE.PRODLINE%TYPE,
                                     A_UNITNO       IN      TW_PRODHIST.UNITNO%TYPE,
                                     A_ITEMCODE     IN      TW_WORKORD.ITEMCODE%TYPE,
                                     A_JUDGE        IN      TW_PRODHIST.JUDGE%TYPE,
                                     A_DEFECT       IN      TW_PRODHIST.DEFECT%TYPE,
                                     A_DEFECT1      IN      TW_PRODHIST.DEFECT%TYPE,
                                     A_DEFECT2      IN      TW_PRODHIST.DEFECT%TYPE,
                                     A_USER         IN      TM_USER.USERID%TYPE,
                                     N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                     V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                     C_RETURN      OUT      SYS_REFCURSOR,     /* RETURN CURSOR */
                                     C_RETURN1     OUT      SYS_REFCURSOR,     /* RETURN CURSOR */
                                     C_RETURN2     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                   );
                                   
                                   
      /*통전검사(배판) 생산 이력 등록*/
      PROCEDURE SET_PROD_PRODUCTION( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                     A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                     A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                     A_WRKORD       IN      TW_PRODHIST.WRKORD%TYPE,
                                     A_PRODLINE     IN      TM_PRODLINE.PRODLINE%TYPE,
                                     A_UNITNO       IN      TW_PRODHIST.UNITNO%TYPE,
                                     A_ITEMCODE     IN      TW_WORKORD.ITEMCODE%TYPE,
                                     A_JUDGE        IN      TW_PRODHIST.JUDGE%TYPE,
                                     A_DEFECT       IN      TW_PRODHIST.DEFECT%TYPE,
                                     A_DEFECT1      IN      TW_PRODHIST.DEFECT%TYPE,
                                     A_DEFECT2      IN      TW_PRODHIST.DEFECT%TYPE,
                                     A_USER         IN      TM_USER.USERID%TYPE,
                                     A_USER2        IN      TM_USER.USERID%TYPE,
                                     N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                     V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                     C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                   ); 
                                   
                                   
        /*ESS 라벨 사전 발행 통전검사(배판) 생산 이력 등록*/
      PROCEDURE SET_PROD_PRODUCTION( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                     A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                     A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                     A_UNITNO       IN      TW_PRODHIST.UNITNO%TYPE,
                                     A_SERIAL       IN      TW_PRODHIST.SERIAL%TYPE,
                                     A_JUDGE        IN      TW_PRODHIST.JUDGE%TYPE,
                                     A_DEFECT       IN      TW_PRODHIST.DEFECT%TYPE,
                                     A_USER         IN      TM_USER.USERID%TYPE,
                                     A_USER2        IN      TM_USER.USERID%TYPE,
                                     N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                     V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                     C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                   );  
                                   
                                   
      /*ESS 라벨 사전 발행 통전검사(배판) 생산 이력 등록*/
      PROCEDURE SET_PROD_PRODUCTION( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                     A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                     A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                     A_UNITNO       IN      TW_PRODHIST.UNITNO%TYPE,
                                     A_JIGSERIAL    IN      TW_PRODHIST.SERIAL%TYPE,
                                     A_SERIAL       IN      TW_PRODHIST.SERIAL%TYPE,
                                     A_JUDGE        IN      TW_PRODHIST.JUDGE%TYPE,
                                     A_DEFECT       IN      TW_PRODHIST.DEFECT%TYPE,
                                     A_USER         IN      TM_USER.USERID%TYPE,
                                     A_USER2        IN      TM_USER.USERID%TYPE,
                                     N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                     V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                     C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                   );                                                              
                                   
                                   
      /*통전검사(배판) 외주 생산 이력 등록*/
      PROCEDURE SET_PROD_PRODUCTION_OS( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                        A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                        A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                        A_SERIAL       IN      TW_PRODHIST.SERIAL%TYPE,
                                        A_PRODLINE     IN      TM_PRODLINE.PRODLINE%TYPE,
                                        A_UNITNO       IN      TW_PRODHIST.UNITNO%TYPE,
                                        A_ITEMCODE     IN      TW_WORKORD.ITEMCODE%TYPE,
                                        A_JUDGE        IN      TW_PRODHIST.JUDGE%TYPE,
                                        A_DEFECT       IN      TW_PRODHIST.DEFECT%TYPE,
                                        A_DEFECT1      IN      TW_PRODHIST.DEFECT%TYPE,
                                        A_DEFECT2      IN      TW_PRODHIST.DEFECT%TYPE,
                                        A_USER         IN      TM_USER.USERID%TYPE,
                                        A_USER2        IN      TM_USER.USERID%TYPE,
                                        N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                        V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                        C_RETURN      OUT      SYS_REFCURSOR     /* RETURN CURSOR */
                                      );                                                                                           
                                   
                                   
      /*통전검사(일반) 재작업 등록*/
      PROCEDURE SET_PROD_REWORK( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 A_WRKORD       IN      TW_PRODHIST.WRKORD%TYPE,
                                 A_WRKORDSEQ    IN      TW_PRODHIST.WRKORDSEQ%TYPE,
                                 A_SERIAL       IN      TM_SERIAL.SERIAL%TYPE,
                                 A_PRODTYPE     IN      TW_PRODHIST.PRODTYPE%TYPE,
                                 A_PRODLINE     IN      TM_PRODLINE.PRODLINE%TYPE,
                                 A_UNITNO       IN      TW_PRODHIST.UNITNO%TYPE,
                                 A_ITEMCODE     IN      TW_WORKORD.ITEMCODE%TYPE,
                                 A_JUDGE        IN      TW_PRODHIST.JUDGE%TYPE,
                                 A_DEFECT       IN      TW_PRODHIST.DEFECT%TYPE,
                                 A_USER         IN      TM_USER.USERID%TYPE,
                                 N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                 V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                 C_RETURN      OUT      SYS_REFCURSOR,    /* RETURN CURSOR */
                                 C_RETURN1     OUT      SYS_REFCURSOR     /* RETURN CURSOR */
                                );   
                                
                                
      /*일별 생산계획(통전) 조회*/
      PROCEDURE GET_DAILY_WORKPLAN( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                    A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                    A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                    A_SDATE        IN      TW_DAILYWORKPLAN.PLANDATE%TYPE,
                                    A_EDATE        IN      TW_DAILYWORKPLAN.PLANDATE%TYPE,
                                    N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                    V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                    C_RETURN      OUT      SYS_REFCURSOR     /* RETURN CURSOR */
                                  );     
                                  
                                  
      /*일별 생산계획(통전) 등록*/
      PROCEDURE SET_DAILY_WORKPLAN( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                    A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                    A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                    A_PLANDATE     IN      TW_DAILYWORKPLAN.PLANDATE%TYPE,
                                    A_ITEMCODE     IN      TW_DAILYWORKPLAN.ITEMCODE%TYPE,
                                    A_PLANQTY      IN      TW_DAILYWORKPLAN.PLANQTY%TYPE,
                                    A_USEFLAG      IN      TW_DAILYWORKPLAN.USEFLAG%TYPE,
                                    A_REMARKS      IN      TW_DAILYWORKPLAN.REMARKS%TYPE,
                                    A_USER         IN      TW_DAILYWORKPLAN.CREATEUSER%TYPE,
                                    N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                    V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                    C_RETURN      OUT      SYS_REFCURSOR     /* RETURN CURSOR */
                                  );         
                                  
                                  
      /*일별 생산계획(통전) 등록*/
      PROCEDURE SET_DAILY_WORKPLAN( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                    A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                    A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                    A_PLANDATE     IN      TW_DAILYWORKPLAN.PLANDATE%TYPE,
                                    A_ITEMCODE     IN      TW_DAILYWORKPLAN.ITEMCODE%TYPE,
                                    A_PLANQTY      IN      TW_DAILYWORKPLAN.PLANQTY%TYPE,
                                    A_PLANHOUR     IN      TW_DAILYWORKPLAN.PLANHOUR%TYPE,
                                    A_USEFLAG      IN      TW_DAILYWORKPLAN.USEFLAG%TYPE,
                                    A_REMARKS      IN      TW_DAILYWORKPLAN.REMARKS%TYPE,
                                    A_USER         IN      TW_DAILYWORKPLAN.CREATEUSER%TYPE,
                                    N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                    V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                    C_RETURN      OUT      SYS_REFCURSOR     /* RETURN CURSOR */
                                  );  
                                  
      /*일별 생산계획(통전) 등록*/
      PROCEDURE SET_DAILY_WORKPLAN( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                    A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                    A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                    A_PLANDATE     IN      TW_DAILYWORKPLAN.PLANDATE%TYPE,
                                    A_OPER         IN      TW_DAILYWORKPLAN.OPER%TYPE,
                                    A_ITEMCODE     IN      TW_DAILYWORKPLAN.ITEMCODE%TYPE,
                                    A_PLANQTY      IN      TW_DAILYWORKPLAN.PLANQTY%TYPE,
                                    A_PLANHOUR     IN      TW_DAILYWORKPLAN.PLANHOUR%TYPE,
                                    A_USEFLAG      IN      TW_DAILYWORKPLAN.USEFLAG%TYPE,
                                    A_REMARKS      IN      TW_DAILYWORKPLAN.REMARKS%TYPE,
                                    A_USER         IN      TW_DAILYWORKPLAN.CREATEUSER%TYPE,
                                    N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                    V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                    C_RETURN      OUT      SYS_REFCURSOR     /* RETURN CURSOR */
                                  );  
                                  
    
      /*재발행*/
      PROCEDURE SET_CIRCUIT_REPINT( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                    A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                    A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                    A_SERIAL       IN      TM_SERIAL.SERIAL%TYPE,
                                    A_USER         IN      TW_DAILYWORKPLAN.CREATEUSER%TYPE,
                                    N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                    V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                    C_RETURN      OUT      SYS_REFCURSOR     /* RETURN CURSOR */
                                  );
                                  
    
      /*육안검사 이력 등록*/
      PROCEDURE SET_VISUAL_INSPECTION( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                       A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                       A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                       A_UNITNO       IN      TW_PRODHIST.UNITNO%TYPE,
                                       A_SERIAL       IN      TW_PRODHIST.SERIAL%TYPE,
                                       A_JUDGE        IN      TW_PRODHIST.JUDGE%TYPE,
                                       A_DEFECT       IN      TW_PRODHIST.DEFECT%TYPE,
                                       A_USER         IN      TM_USER.USERID%TYPE,
                                       N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                       V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                       C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                     ); 
                                     
                                     
      /*육안검사 이력 등록*/
      PROCEDURE SET_VISUAL_INSPECTION( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                       A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                       A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                       A_UNITNO       IN      TW_PRODHIST.UNITNO%TYPE,
                                       A_SERIAL       IN      TW_PRODHIST.SERIAL%TYPE,
                                       A_JUDGE        IN      TW_PRODHIST.JUDGE%TYPE,
                                       A_DEFECT       IN      TW_PRODHIST.DEFECT%TYPE,
                                       A_DEFECT2      IN      TW_PRODHIST.DEFECT%TYPE,
                                       A_DEFECT3      IN      TW_PRODHIST.DEFECT%TYPE,
                                       A_DEFECT4      IN      TW_PRODHIST.DEFECT%TYPE,
                                       A_DEFECT5      IN      TW_PRODHIST.DEFECT%TYPE,
                                       A_USER         IN      TM_USER.USERID%TYPE,
                                       N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                       V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                       C_RETURN      OUT      SYS_REFCURSOR,     /* RETURN CURSOR */
                                       C_RETURN1     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                     );    
                                     
                                     
      /*육안검사 이력 등록*/
      PROCEDURE SET_VISUAL_INSPECTION( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                       A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                       A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                       A_UNITNO       IN      TW_PRODHIST.UNITNO%TYPE,
                                       A_SERIAL       IN      TW_PRODHIST.SERIAL%TYPE,
                                       A_JUDGE        IN      TW_PRODHIST.JUDGE%TYPE,
                                       A_DEFECT       IN      TW_PRODHIST.DEFECT%TYPE,
                                       A_DEFECT2      IN      TW_PRODHIST.DEFECT%TYPE,
                                       A_DEFECT3      IN      TW_PRODHIST.DEFECT%TYPE,
                                       A_DEFECT4      IN      TW_PRODHIST.DEFECT%TYPE,
                                       A_DEFECT5      IN      TW_PRODHIST.DEFECT%TYPE,
                                       A_USER         IN      TM_USER.USERID%TYPE,
                                       A_USER2        IN      TM_USER.USERID%TYPE,
                                       N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                       V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                       C_RETURN      OUT      SYS_REFCURSOR,     /* RETURN CURSOR */
                                       C_RETURN1     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                     );
                                     
                                     
      /*육안검사 이력 등록*/
      PROCEDURE SET_VISUAL_INSPECTION( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                       A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                       A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                       A_UNITNO       IN      TW_PRODHIST.UNITNO%TYPE,
                                       A_SERIAL       IN      TW_PRODHIST.SERIAL%TYPE,
                                       A_JUDGE        IN      TW_PRODHIST.JUDGE%TYPE,
                                       A_DEFECT       IN      TW_PRODHIST.DEFECT%TYPE,
                                       A_DEFECT2      IN      TW_PRODHIST.DEFECT%TYPE,
                                       A_DEFECT3      IN      TW_PRODHIST.DEFECT%TYPE,
                                       A_DEFECT4      IN      TW_PRODHIST.DEFECT%TYPE,
                                       A_DEFECT5      IN      TW_PRODHIST.DEFECT%TYPE,
                                       A_ITEMCODE     IN      TW_PRODHIST.ITEMCODE%TYPE,
                                       A_USER         IN      TM_USER.USERID%TYPE,
                                       A_USER2        IN      TM_USER.USERID%TYPE,
                                       N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                       V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                       C_RETURN      OUT      SYS_REFCURSOR,     /* RETURN CURSOR */
                                       C_RETURN1     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                     );
                                     
                                     
      /*통전검사(일반) 장착 자재 정보*/
      PROCEDURE GET_PROD_MOUNT_SERIAL( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                       A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                       A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */    
                                       A_SERIAL       IN      TM_SERIAL.SERIAL%TYPE,
                                       N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                       V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                       C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                     );     
                                     
                                     
      /*품번 체크*/
      PROCEDURE CHK_PARTNO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                            A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                            A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */    
                            A_SERIAL       IN      TM_SERIAL.SERIAL%TYPE, 
                            A_ITEMCODE     IN      TM_SERIAL.ITEMCODE%TYPE,
                            N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                            V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                            C_RETURN      OUT      SYS_REFCURSOR     /* RETURN CURSOR */
                           );   
      
    /*GP12 검사 이력 등록*/
      PROCEDURE SET_GP12_INSPECTION( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                       A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                       A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                       A_UNITNO       IN      TW_PRODHIST.UNITNO%TYPE,
                                       A_SERIAL       IN      TW_PRODHIST.SERIAL%TYPE,
                                       A_JUDGE        IN      TW_PRODHIST.JUDGE%TYPE,
                                       A_DEFECT       IN      TW_PRODHIST.DEFECT%TYPE,
                                       A_DEFECT2      IN      TW_PRODHIST.DEFECT%TYPE,
                                       A_DEFECT3      IN      TW_PRODHIST.DEFECT%TYPE,
                                       A_DEFECT4      IN      TW_PRODHIST.DEFECT%TYPE,
                                       A_DEFECT5      IN      TW_PRODHIST.DEFECT%TYPE,
                                       A_USER         IN      TM_USER.USERID%TYPE,
                                       A_USER2        IN      TM_USER.USERID%TYPE,
                                       N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                       V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                       C_RETURN      OUT      SYS_REFCURSOR,     /* RETURN CURSOR */
                                       C_RETURN1     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                     );
    
    
        /*품번 체크*/
      PROCEDURE CHK_PARTNO_GP12( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
    	                         A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
    	                         A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */    
    	                         A_SERIAL       IN      TM_SERIAL.SERIAL%TYPE, 
    	                         A_ITEMCODE     IN      TM_SERIAL.ITEMCODE%TYPE,
    	                         N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
    	                         V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
    	                         C_RETURN      OUT      SYS_REFCURSOR     /* RETURN CURSOR */
    	                        );
         
    END PKGPRD_CURRENT;
    ```

**참조 테이블:**

`TH_WORKORD`, `TM_BOM`, `TM_BOX`, `TM_CLIENT`, `TM_COMMCODE`, `TM_COMPANY`, `TM_GP12_ITEM`, `TM_ITEMS`, `TM_LOCATION`, `TM_PLANT`, `TM_PRODLINE`, `TM_PRODLINE_UNIT`, `TM_SERIAL`, `TM_SUBITEMS`, `TM_USER`, `TW_BRD`, `TW_DAILYWORKPLAN`, `TW_IN`, `TW_MOUNT`, `TW_OUT`, `TW_PRODHIST`, `TW_PRODHIST_USE`, `TW_STOCKSERIAL`, `TW_WORKORD`

---

### PKGPRD_ECC

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `GET_SERIAL_INFO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_PROD_SPLITMERGE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_PROD_NEW_CREATESN` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_PROD_NEW_CREATESN_ORGI` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| FUNC | `FUN_PROD_CREATESN` | A_UNITQTY IN TM_SERIAL.QTY%TYPE, A_INQTY IN TM_SERIAL.QTY... → TB_MATSERIAL |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         PKGPRD_ECC AS 
    
      /* SERIAL 정보 조회 */
      PROCEDURE GET_SERIAL_INFO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 A_SERIAL       IN      TM_SERIAL.SERIAL%TYPE,
                                 N_RETURN      OUT      NUMBER,            /* RETURN VALUE    */
                                 V_RETURN      OUT      VARCHAR2,            /* RETURN MESSAGE  */
                                 C_RETURN      OUT      SYS_REFCURSOR       /* RETURN CURSOR  */
                                );
                                    
                                                                                              
      /* 생산 실적 분리&병합 */
      PROCEDURE SET_PROD_SPLITMERGE( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                     A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                     A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                     A_TYPE         IN      VARCHAR2,
                                     A_SN1          IN      TM_SERIAL.SERIAL%TYPE,
                                     A_SN2          IN      TM_SERIAL.SERIAL%TYPE,
                                     A_SPLITQTY     IN      TW_STOCKSERIAL.GOODQTY%TYPE,
                                     A_IQCNO        IN      TW_IQC.IQCNO%TYPE,
                                     A_USER         IN      VARCHAR2,
                                     N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                     V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                     C_RETURN1     OUT      SYS_REFCURSOR,     /* RETURN CURSOR */
                                     C_RETURN2     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                     );      
                                     
                                     
      /* 시리얼 생성 */
      PROCEDURE SET_PROD_NEW_CREATESN( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                       A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                       A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                       A_TYPE         IN      VARCHAR2,
                                       A_INDATE       IN      TM_SERIAL.INDATE%TYPE,
                                       A_ORDERNO      IN      TM_SERIAL.ORDERNO%TYPE,
                                       A_ORDERSEQ     IN      TM_SERIAL.ORDERSEQ%TYPE,
                                       A_INVOICENO    IN      TM_SERIAL.INVOICENO%TYPE,
                                       A_VENDOR       IN      TM_SERIAL.VENDOR%TYPE,
                                       A_ITEMCODE     IN      TM_ITEMS.ITEMCODE%TYPE,
                                       A_UNITQTY      IN      TM_SERIAL.QTY%TYPE,
                                       A_INQTY        IN      TM_SERIAL.QTY%TYPE,
                                       A_TXNCODE      IN      VARCHAR2,
                                       A_BCDDATA      IN      TM_SERIAL.BCDDATA%TYPE,
                                       A_BCDLOT       IN      TM_SERIAL.BCDLOT%TYPE,
                                       A_PRESERIAL    IN      TM_SERIAL.PRESERIAL%TYPE,
                                       A_MAKER        IN      TM_SERIAL.MAKER%TYPE,
                                       A_SLIPNO       IN      TM_SERIAL.SLIPNO%TYPE,   
                                       A_IQCNO        IN      TW_IQC.IQCNO%TYPE,                       
                                       A_USER         IN      VARCHAR2,
                                       N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                       V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                       C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                     ); 
                                     
                                     
      /* 시리얼 생성 */
      PROCEDURE SET_PROD_NEW_CREATESN_ORGI( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                            A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                            A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                            A_TYPE         IN      VARCHAR2,
                                            A_INDATE       IN      TM_SERIAL.INDATE%TYPE,
                                            A_ORDERNO      IN      TM_SERIAL.ORDERNO%TYPE,
                                            A_ORDERSEQ     IN      TM_SERIAL.ORDERSEQ%TYPE,
                                            A_INVOICENO    IN      TM_SERIAL.INVOICENO%TYPE,
                                            A_VENDOR       IN      TM_SERIAL.VENDOR%TYPE,
                                            A_ITEMCODE     IN      TM_ITEMS.ITEMCODE%TYPE,
                                            A_UNITQTY      IN      TM_SERIAL.QTY%TYPE,
                                            A_INQTY        IN      TM_SERIAL.QTY%TYPE,
                                            A_TXNCODE      IN      VARCHAR2,
                                            A_BCDDATA      IN      TM_SERIAL.BCDDATA%TYPE,
                                            A_BCDLOT       IN      TM_SERIAL.BCDLOT%TYPE,
                                            A_PRESERIAL    IN      TM_SERIAL.PRESERIAL%TYPE,
                                            A_MAKER        IN      TM_SERIAL.MAKER%TYPE,
                                            A_SLIPNO       IN      TM_SERIAL.SLIPNO%TYPE,   
                                            A_IQCNO        IN      TW_IQC.IQCNO%TYPE,                       
                                            A_USER         IN      VARCHAR2,
                                            V_MATSERIAL   OUT      TB_MATSERIAL,
                                            N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                            V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                            C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                          );     
                                          
                                          
      /*시리얼 테이블 생성*/
      FUNCTION FUN_PROD_CREATESN(A_UNITQTY      IN      TM_SERIAL.QTY%TYPE,
                                 A_INQTY        IN      TM_SERIAL.QTY%TYPE
                                )
      RETURN TB_MATSERIAL;    
       
      
      
      
                                                                                                                   
    END PKGPRD_ECC;
    ```

**참조 테이블:**

`TH_SPLITMERGE`, `TM_CLIENT`, `TM_COMPANY`, `TM_ITEMS`, `TM_PLANT`, `TM_SERIAL`, `TW_IQC`, `TW_MOUNT`, `TW_OUT`, `TW_PRODHIST`, `TW_STOCKSERIAL`, `TW_WORKORD`

---

### PKGPRD_HIST

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `GET_UNITNO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_CIRCUIT` | A_SDATE IN VARCHAR2, /* 시작 날짜 */ A_EDATE IN VARCHAR2, /* 종료 날짜 */ A_UNITNO IN... |
| PROC | `GET_VISUALINSP` | A_SDATE IN VARCHAR2, /* 시작 날짜 */ A_EDATE IN VARCHAR2, /* 종료 날짜 */ A_UNITNO IN... |
| PROC | `GET_PRODSN_DETAIL_HIST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_GP12_HIST` | A_SDATE IN VARCHAR2, /* 시작 날짜 */ A_EDATE IN VARCHAR2, /* 종료 날짜 */ A_UNITNO IN... |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         PKGPRD_HIST
    AS
    -- Package header
    
    
      PROCEDURE GET_UNITNO( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                            A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                            A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                            N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                            V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                            C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                           );
                       
                       
       PROCEDURE GET_CIRCUIT(A_SDATE          IN      VARCHAR2,  /* 시작 날짜 */
                             A_EDATE          IN      VARCHAR2,  /* 종료 날짜 */
                             A_UNITNO         IN      TM_PRODLINE_UNIT.UNITNO%TYPE, /* 호기 번호 */
                             A_WORKER         IN      TM_EHR.LOCUSERNAME%TYPE, /* 작업자 */
                             N_RETURN        OUT      NUMBER,            
                             V_RETURN        OUT      VARCHAR2,          
                             C_RETURN        OUT      SYS_REFCURSOR      
                             );
                         
       PROCEDURE GET_VISUALINSP(A_SDATE          IN      VARCHAR2,  /* 시작 날짜 */
                                A_EDATE          IN      VARCHAR2,  /* 종료 날짜 */
                                A_UNITNO         IN      TM_PRODLINE_UNIT.UNITNO%TYPE, /* 호기 번호 */
                                A_WORKER         IN      TM_EHR.LOCUSERNAME%TYPE, /* 작업자 */
                                N_RETURN        OUT      NUMBER,            
                                V_RETURN        OUT      VARCHAR2,          
                                C_RETURN        OUT      SYS_REFCURSOR      
                                );
                            
                            
      /* LOT 추적 */
      PROCEDURE GET_PRODSN_DETAIL_HIST( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                        A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                        A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                        A_FLAG         IN      VARCHAR2,
                                        A_BARCODE      IN      VARCHAR2,
                                        N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                        V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                        C_RETURN      OUT      SYS_REFCURSOR,      /* RETURN CURSOR */
                                        C_RETURN1     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                      );
      
         PROCEDURE GET_GP12_HIST(A_SDATE          IN      VARCHAR2,  /* 시작 날짜 */
                                A_EDATE          IN      VARCHAR2,  /* 종료 날짜 */
                                A_UNITNO         IN      TM_PRODLINE_UNIT.UNITNO%TYPE, /* 호기 번호 */
                                A_WORKER         IN      TM_EHR.LOCUSERNAME%TYPE, /* 작업자 */
                                N_RETURN        OUT      NUMBER,            
                                V_RETURN        OUT      VARCHAR2,          
                                C_RETURN        OUT      SYS_REFCURSOR      
                                );
                      
                      
    
    END PKGPRD_HIST;
    ```

**참조 테이블:**

`TM_CLIENT`, `TM_COMPANY`, `TM_DEFECT`, `TM_EHR`, `TM_ITEMS`, `TM_PLANT`, `TM_PRODLINE`, `TM_PRODLINE_UNIT`, `TM_SERIAL`, `TM_TRANSACTION`, `TM_VENDOR`, `TW_BRD`, `TW_PRODHIST`, `TW_PRODHIST_USE`

---

### PKGPRD_MAT

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `GET_STOCK_SNINFO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_REPLACE_NONE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_REPLACE_NONE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         PKGPRD_MAT is
    
       /*SERIAL별 재고 조회*/
       PROCEDURE GET_STOCK_SNINFO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                   A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                   A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                   A_SN           IN      TM_SERIAL.SERIAL%TYPE,
                                   A_WHLOC        IN      TM_LOCATION.WHLOC%TYPE,
                                   N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                   V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                   C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                 );
                                 
                                 
      /*NONE 변경 시리얼 조회*/
      PROCEDURE GET_REPLACE_NONE( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_WHLOC        IN      TM_LOCATION.WHLOC%TYPE,
                                  A_SDATE        IN      TM_SERIAL.INDATE%TYPE,
                                  A_EDATE        IN      TM_SERIAL.INDATE%TYPE,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                 );                             
                                 
                                 
      /*NONE 시리얼 대체*/
      PROCEDURE SET_REPLACE_NONE( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_ITEMCODE     IN      TM_SERIAL.ITEMCODE%TYPE,
                                  A_SN           IN      TM_SERIAL.SERIAL%TYPE,
                                  A_WHLOC        IN      TM_LOCATION.WHLOC%TYPE,
                                  A_QTY          IN      TW_STOCKSERIAL.GOODQTY%TYPE,
                                  A_USER         IN      TM_USER.USERID%TYPE,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                 );                                                                  
      
    end PKGPRD_MAT;
    ```

**참조 테이블:**

`TM_CLIENT`, `TM_COMPANY`, `TM_ITEMS`, `TM_LOCATION`, `TM_PLANT`, `TM_SERIAL`, `TM_USER`, `TM_WAREHOUSE`, `TW_IN`, `TW_OUT`, `TW_STOCKSERIAL`

---

### PKGPRD_MNT

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `GET_DAILY_PROD_MONITERING` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_DAILY_PLAN_MONITERING` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_CRIMP_MONITORING` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_ASSEMBLY_RESULT_1_1` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_ASSEMBLY_RESULT_1_2` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_ASSEMBLY_RESULT_3_1` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_ASSEMBLY_RESULT_3_2` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_ASSEMBLY_RESULT_4_1` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_ASSEMBLY_RESULT_4_2` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         PKGPRD_MNT IS
    
      /* 일별 생산 실적 현황 */
      PROCEDURE GET_DAILY_PROD_MONITERING( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                           A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                           A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                           N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                           V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                           C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                         );
                                         
                                         
      /* 일별 생산 계획 대 실적  현황 */
      PROCEDURE GET_DAILY_PLAN_MONITERING( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                           A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                           A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                           N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                           V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                           C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                         ); 
                                         
                                         
      /* CPK값 조회 */
      PROCEDURE GET_CRIMP_MONITORING( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                      A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                      A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                      A_WIRE         IN      TH_CRIMPINSP.WIRE%TYPE,
                                      A_TERMINAL     IN      TH_CRIMPINSP.TERMINAL%TYPE,
                                      N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                      V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                      C_RETURN      OUT      SYS_REFCURSOR,      /* RETURN CURSOR */
                                      C_RETURN1     OUT      SYS_REFCURSOR,      /* RETURN CURSOR */
                                      C_RETURN2     OUT      SYS_REFCURSOR,      /* RETURN CURSOR */
                                      C_RETURN3     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                    );
                                    
                                    
      /* Assembly Result - Conveyor(시간대별 수량 집계) */
      PROCEDURE GET_ASSEMBLY_RESULT_1_1( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                         A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                         A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                         N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                         V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                         C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                       );
                                       
                                       
      /* Assembly Result - Conveyor(LINE 별 생산 현황 집계) */
      PROCEDURE GET_ASSEMBLY_RESULT_1_2( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                         A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                         A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                         N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                         V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                         C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                       );
                                       
    
      /* Assembly Result - Conveyor(Current Production P/NO Daily Trend) */
      PROCEDURE GET_ASSEMBLY_RESULT_3_1( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                         A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                         A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                         N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                         V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                         C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                       );
                                       
                                       
      /* Assembly Result - Conveyor(Current Production P/NO Daily Trend) */
      PROCEDURE GET_ASSEMBLY_RESULT_3_2( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                         A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                         A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                         N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                         V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                         C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                       );
                                       
                                       
      /* Assembly Result - Conveyor(Monthly / Weekly / Daily Trend) */
      PROCEDURE GET_ASSEMBLY_RESULT_4_1( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                         A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                         A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                         N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                         V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                         C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                       );
                                       
                                       
      /* Assembly Result - Conveyor(Monthly / Weekly / Daily Trend) */
      PROCEDURE GET_ASSEMBLY_RESULT_4_2( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                         A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                         A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                         N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                         V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                         C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                       );                                                                                                                                                                                                                                                        
                                         
                                         
    END PKGPRD_MNT;
    ```

**참조 테이블:**

`TH_CRIMPINSP`, `TH_CRIMP_IMAGE`, `TH_WORKORD`, `TM_CLIENT`, `TM_COMPANY`, `TM_ITEMS`, `TM_PLANT`, `TM_PRODLINE_UNIT`, `TW_BRD`, `TW_DAILYWORKPLAN`, `TW_PRODHIST`, `TW_WORKORD`

---

### PKGPRD_PROD

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `GET_CREATEWRKORDINFO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_OSC_CREATEWRKORDINFO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_CREATEWRKORDDETAIL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_OSC_CREATEWRKORDDETAIL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_CREATEWRKORD` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_OSC_CREATEWRKORD` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_ALTERWRKORD` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_CREATEWRKORDPRINT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PRODMATERIALREQUEST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PRODMATERIALREQUEST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PRODMATERIALREQUEST2` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_OSC_PRODMATERIALREQUEST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_OSC_PRODMATERIALREQUEST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_PRODMATERIALREQUEST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_OSC_PRODMATERIALREQUEST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PRODMATERIALSTOCK` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_OSC_PRODMATERIALSTOCK` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PRODLABELPRINT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PRODLABELPRINT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PRODCREATELABELPRINT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_PRODCREATELABEL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PRODREPRINTLABEL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_BOXSNINFO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_BOXSNINFO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_BOXNO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_BOXNO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_SERIAL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_SERIALPACKING` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_SERIALPACKING` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_BOXPACKING` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_QTYPACK_WRKORD` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_QTYPACKING` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_QTYPACKING` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_UNPACKING` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_UNBOXPACKING` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PROD_RECEIVE_OUTSOURCING` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_PROD_RECEIVE_OUTSOURCING` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_INSP_CRIMP` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_WORKORDER` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_PROD_READY` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_PROD_START` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_PROD_END` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_PROD_END` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_PROD_END` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_PROD_END` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_MOUNT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_PROD_REG` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_PROD_REG` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PROD_REG_HIST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_PRODPLAN_UPLOAD` | A_CLIENT IN TM_PRODPLAN.CLIENT%TYPE, A_COMPANY IN TM_PRODPLAN.COMPANY%TYPE, A... |
| PROC | `GET_PRODPLAN` | A_CLIENT IN TM_PRODPLAN.CLIENT%TYPE, A_COMPANY IN TM_PRODPLAN.COMPANY%TYPE, A... |
| PROC | `PUT_PRODPLAN_MONTH_UPLOAD` | A_CLIENT IN TM_PRODPLAN.CLIENT%TYPE, A_COMPANY IN TM_PRODPLAN.COMPANY%TYPE, A... |
| PROC | `GET_PRODPLAN_MONTH` | A_CLIENT IN TM_PRODPLAN.CLIENT%TYPE, A_COMPANY IN TM_PRODPLAN.COMPANY%TYPE, A... |
| PROC | `SET_CRIMPINGERROR` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_CRIMPINGERROR` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_REPLACEITEM` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_REPLACEITEM` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_CHANGE_UNITNO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `CHK_WORKORDER` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         PKGPRD_PROD IS
    
    
      /* 작업 지시 생성 이력 조회 */
      PROCEDURE GET_CREATEWRKORDINFO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                      A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                      A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                      A_SDATE        IN      TW_WORKORD.WRKDATE%TYPE,
                                      A_EDATE        IN      TW_WORKORD.WRKDATE%TYPE,
                                      A_OPER         IN      TW_WORKORD.OPER%TYPE,
                                      A_UNITNO       IN      TW_WORKORD.UNITNO%TYPE,
                                      A_USEFLAG      IN      TW_WORKORD.USEFLAG%TYPE,
                                      N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                      V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                      C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                    );
                                    
                                    
      /* 외주 작업 지시 생성 이력 조회 */
      PROCEDURE GET_OSC_CREATEWRKORDINFO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                          A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                          A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                          A_SDATE        IN      TW_WORKORD.WRKDATE%TYPE,
                                          A_EDATE        IN      TW_WORKORD.WRKDATE%TYPE,
                                          A_OPER         IN      TW_WORKORD.OPER%TYPE,
                                          A_USEFLAG      IN      TW_WORKORD.USEFLAG%TYPE,
                                          N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                          V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                          C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                        );                                
                                
                                    
      /* 공정 / 호기별 작업지시 생산 현황 */
      PROCEDURE GET_CREATEWRKORDDETAIL( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                        A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                        A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                        A_WRKDATE      IN      TW_WORKORD.WRKDATE%TYPE,
                                        A_OPER         IN      TM_OPERATION.OPER%TYPE,
                                        A_UNITNO       IN      TM_PRODLINE_UNIT.UNITNO%TYPE,
                                        N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                        V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                        C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                      ); 
                                      
                                      
      /* 공정 / 호기별 작업지시 생산 현황 */
      PROCEDURE GET_OSC_CREATEWRKORDDETAIL( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                            A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                            A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                            A_WRKDATE      IN      TW_WORKORD.WRKDATE%TYPE,
                                            A_VENDOR       IN      TM_VENDOR.VENDOR%TYPE,
                                            N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                            V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                            C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                          );                                      
                            
                            
      /* 작업 지시 정보 생성 */
      PROCEDURE SET_CREATEWRKORD( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_WRKDATE      IN      TW_WORKORD.WRKDATE%TYPE,
                                  A_BOMGRP       IN      TM_BOM.BOMGRP%TYPE,
                                  A_OPER         IN      TM_OPERATION.OPER%TYPE,
                                  A_UNITNO       IN      TM_PRODLINE_UNIT.UNITNO%TYPE,
                                  A_ITEMCODE     IN      TM_ITEMS.ITEMCODE%TYPE,
                                  A_WRKORDTYPE   IN      TW_WORKORD.WRKORDTYPE%TYPE,
                                  A_ORDQTY       IN      TW_WORKORD.ORDQTY%TYPE,
                                  A_USER         IN      TM_USER.USERID%TYPE,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                );
                                
                                
     /* 외주 작업 지시 정보 생성 */
      PROCEDURE SET_OSC_CREATEWRKORD( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                      A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                      A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                      A_WRKDATE      IN      TW_WORKORD.WRKDATE%TYPE,
                                      A_BOMGRP       IN      TM_BOM.BOMGRP%TYPE,
                                      A_VENDOR       IN      TW_WORKORD.VENDOR%TYPE,
                                      A_OPER         IN      TM_OPERATION.OPER%TYPE,
                                      A_ITEMCODE     IN      TM_ITEMS.ITEMCODE%TYPE,
                                      A_WRKORDTYPE   IN      TW_WORKORD.WRKORDTYPE%TYPE,
                                      A_ORDQTY       IN      TW_WORKORD.ORDQTY%TYPE,
                                      A_USER         IN      TM_USER.USERID%TYPE,
                                      N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                      V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                      C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                    );                              
                                
                                
      /* 작업 지시 정보 수정 */
      PROCEDURE SET_ALTERWRKORD( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 A_JOB          IN      VARCHAR2, /*A_JOB파라메타설정 : U :UP, D : DOWN, M : MODIFY*/
                                 A_WRKDATE      IN      TW_WORKORD.WRKDATE%TYPE,
                                 A_OPER         IN      TW_WORKORD.OPER%TYPE,
                                 A_UNITNO       IN      TW_WORKORD.UNITNO%TYPE,
                                 A_WRKORDSEQ    IN      TW_WORKORD.WRKORDSEQ%TYPE,
                                 A_ORDQTY       IN      TW_WORKORD.ORDQTY%TYPE,
                                 A_USER         IN      TM_USER.USERID%TYPE,
                                 N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                 V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                 C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                               );       
                               
                               
      /* 생산 작업지시 출력 */
      PROCEDURE GET_CREATEWRKORDPRINT( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                       A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                       A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                       A_WRKORD       IN      TW_WORKORD.WRKORD%TYPE,
                                       N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                       V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                       C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                     );                                                                           
                    
                                
      /* 자재요청 / 생산 작업지시 정보 조회 */
      PROCEDURE GET_PRODMATERIALREQUEST( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                         A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                         A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                         A_WRKORDTYPE   IN      TW_WORKORD.WRKORDTYPE%TYPE,
                                         A_STDATE       IN      TW_WORKORD.WRKDATE%TYPE,
                                         A_ENDATE       IN      TW_WORKORD.WRKDATE%TYPE,
                                         N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                         V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                         C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                       );
                                       
      /* 재소요량 계산 / 선택 작업지시별 */  
      PROCEDURE GET_PRODMATERIALREQUEST( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                         A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                         A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                         A_XML          IN      CLOB,
                                         N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                         V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                         C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                       );   
      /* 재소요량 계산 / 선택 작업지시별 */  
      PROCEDURE GET_PRODMATERIALREQUEST2( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                         A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                         A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                         A_XML          IN      CLOB,
                                         N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                         V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                         C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                       );   
                                       
                                       
      /* 자재요청 / 생산 작업지시 정보 조회 */
      PROCEDURE GET_OSC_PRODMATERIALREQUEST( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                             A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                             A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                             A_VENDOR       IN      TM_VENDOR.VENDOR%TYPE,
                                             A_STDATE       IN      TW_WORKORD.WRKDATE%TYPE,
                                             A_ENDATE       IN      TW_WORKORD.WRKDATE%TYPE,
                                             N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                             V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                             C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                           );                                    
                                       
      
      /* 자재소요량 계산 / 선택 작업지시별 */
      PROCEDURE GET_OSC_PRODMATERIALREQUEST( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                             A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                             A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                             A_VENDOR       IN      TM_VENDOR.VENDOR%TYPE,
                                             A_XML          IN      CLOB,
                                             N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                             V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                             C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                           );                                   
    
                                       
                                       
      /* 자재 요청 데이터 생성*/
      PROCEDURE PUT_PRODMATERIALREQUEST( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                         A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                         A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                         A_XML1         IN      CLOB,
                                         A_XML2         IN      CLOB,
                                         A_USER         IN      TM_USER.USERID%TYPE,
                                         N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                         V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                         C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                       ); 
                                       
                                       
      /* 자재 요청 데이터 생성*/
      PROCEDURE PUT_OSC_PRODMATERIALREQUEST( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                             A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                             A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                             A_VENDOR       IN      TM_VENDOR.VENDOR%TYPE,
                                             A_XML1         IN      CLOB,
                                             A_XML2         IN      CLOB,
                                             A_USER         IN      TM_USER.USERID%TYPE,
                                             N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                             V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                             C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                           );                                   
                                       
                                       
      /* 현장 자재 재고 조회 */
      PROCEDURE GET_PRODMATERIALSTOCK( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                       A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                       A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                       N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                       V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                       C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                     );  
                                     
                                     
      /* 현장 자재 재고 조회 */
      PROCEDURE GET_OSC_PRODMATERIALSTOCK( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                           A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                           A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                           A_VENDOR       IN      TM_VENDOR.VENDOR%TYPE,
                                           N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                           V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                           C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                         );                                                                  
                                       
                                       
      /* 생산 라벨 출력 작업지시  리스트 조회 : 통전(완제품)라벨은 제외 */
      PROCEDURE GET_PRODLABELPRINT( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                    A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                    A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                    A_SDATE        IN      TW_WORKORD.WRKDATE%TYPE,
                                    A_EDATE        IN      TW_WORKORD.WRKDATE%TYPE,
                                    N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                    V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                    C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                  );
                                  
                                  
      /* 생산 라벨 출력 작업지시  리스트 조회 : 통전(완제품)라벨은 제외*/
      PROCEDURE GET_PRODLABELPRINT( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                    A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                    A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                    A_LABELGBN     IN      VARCHAR2,
                                    A_SDATE        IN      TW_WORKORD.WRKDATE%TYPE,
                                    A_EDATE        IN      TW_WORKORD.WRKDATE%TYPE,
                                    N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                    V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                    C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                  );                              
                                  
                                  
      /* 생산 라벨 출력 이력 정보 조회 : 통전(완제품)라벨은 제외 */
      PROCEDURE GET_PRODCREATELABELPRINT( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                          A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                          A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                          A_WORKORD      IN      TW_WORKORD.WRKORD%TYPE,
                                          A_WORKORDSEQ   IN      TW_WORKORD.WRKORDSEQ%TYPE,
                                          N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                          V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                          C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                        );  
                                        
                                        
      /* 생산 라벨 정보 생성 */
      PROCEDURE SET_PRODCREATELABEL( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                     A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                     A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                     A_WORKORD      IN      TW_WORKORD.WRKORD%TYPE,
                                     A_ITEMCODE     IN      TW_WORKORD.ITEMCODE%TYPE,
                                     A_ORDQTY       IN      TW_WORKORD.ORDQTY%TYPE,
                                     A_LOTUNITQTY   IN      TM_ITEMS.LOTUNITQTY%TYPE,
                                     A_USER         IN      TM_USER.USERID%TYPE,            
                                     N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                     V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                     C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                   ); 
                                   
                                   
      /* 생산 라벨 정보 재발행*/
      PROCEDURE GET_PRODREPRINTLABEL( A_CLIENT      IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                      A_COMPANY     IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                      A_PLANT       IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                      A_SERIAL      IN      TM_SERIAL.SERIAL%TYPE,
                                      N_RETURN     OUT      NUMBER,            /* RETURN VALUE */
                                      V_RETURN     OUT      VARCHAR2,          /* RETURN MESSAGE */
                                      C_RETURN     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                    );                               
                                   
                                   
      /* 포장 박스 라벨 출력 정보 */
      PROCEDURE GET_BOXSNINFO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                               A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                               A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                               A_BOXTYPE      IN      TM_BOX.BOXTYPE%TYPE,
                               A_SDATE        IN      TM_BOX.PACKINGDATE%TYPE,
                               A_EDATE        IN      TM_BOX.PACKINGDATE%TYPE,
                               N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                               V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                               C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                             );
                             
                             
      /* 포장 박스 라벨 생성 */
      PROCEDURE SET_BOXSNINFO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                               A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                               A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                               A_BOXTYPE      IN      TM_BOX.BOXTYPE%TYPE,
                               A_ITEMCODE     IN      TM_ITEMS.ITEMCODE%TYPE,
                               A_WHLOC        IN      TM_BOX.WHLOC%TYPE,
                               A_QTY          IN      NUMBER,
                               A_USER         IN      VARCHAR2,          /* 사원번호  */
                               N_RETURN      OUT      NUMBER,            /* RETURN VALUE    */
                               V_RETURN      OUT      VARCHAR2,           /* RETURN MESSAGE */
                               C_RETURN      OUT      SYS_REFCURSOR       /* RETURN CURSOR */
                             );    
                             
                             
      /* BOX 조회*/
      PROCEDURE GET_BOXNO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                           A_TYPE         IN      VARCHAR2,
                           A_BOXNO        IN      TM_BOX.BOXNO%TYPE,
                           N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                           V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                           C_RETURN1     OUT      SYS_REFCURSOR,     /* RETURN CURSOR */
                           C_RETURN2     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                         );
                         
                         
      /* BOX 조회*/
      PROCEDURE GET_BOXNO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                           A_PARTNO       IN      TM_ITEMS.PARTNO%TYPE,
                           A_WRKORD       IN      TW_PRODHIST.WRKORD%TYPE,
                           A_BOXNO        IN      TM_BOX.BOXNO%TYPE,
                           N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                           V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                           C_RETURN1     OUT      SYS_REFCURSOR,     /* RETURN CURSOR */
                           C_RETURN2     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                         );
                         
                         
      /* SERIAL 조회 */
      PROCEDURE GET_SERIAL( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                            A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                            A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                            A_TYPE         IN      VARCHAR2,
                            A_SERIAL       IN      TM_SERIAL.SERIAL%TYPE,
                            A_BOXNO        IN      TM_BOX.BOXNO%TYPE,
                            N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                            V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                            C_RETURN      OUT      SYS_REFCURSOR       /* RETURN CURSOR */
                          );
                          
                          
      /* 개별(시리얼) 포장 */
      PROCEDURE PUT_SERIALPACKING( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                   A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                   A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                   A_TYPE         IN      VARCHAR2,
                                   A_UNITNO       IN      TM_PRODLINE_UNIT.UNITNO%TYPE,
                                   A_BOXNO        IN      TM_BOX.BOXNO%TYPE,
                                   A_XML          IN      CLOB,
                                   A_USER         IN      TM_USER.USERID%TYPE,
                                   N_RETURN      OUT      NUMBER,            /* RETURN VALUE    */
                                   V_RETURN      OUT      VARCHAR2,            /* RETURN MESSAGE  */
                                   C_RETURN      OUT      SYS_REFCURSOR        /* RETURN CURSOR  */
                                 );  
                                 
                                 
      /* 개별(시리얼) 포장 */
      PROCEDURE PUT_SERIALPACKING( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                   A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                   A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                   A_TYPE         IN      VARCHAR2,
                                   A_UNITNO       IN      TM_PRODLINE_UNIT.UNITNO%TYPE,
                                   A_BOXNO        IN      TM_BOX.BOXNO%TYPE,
                                   A_EMPTYBOXNO   IN      VARCHAR2,
                                   A_ETCQTY       IN      TM_BOX.ETCQTY%TYPE,
                                   A_WEIGHT       IN      TM_BOX.WEIGHT%TYPE,
                                   A_XML          IN      CLOB,
                                   A_USER         IN      TM_USER.USERID%TYPE,
                                   N_RETURN      OUT      NUMBER,            /* RETURN VALUE    */
                                   V_RETURN      OUT      VARCHAR2,            /* RETURN MESSAGE  */
                                   C_RETURN      OUT      SYS_REFCURSOR        /* RETURN CURSOR  */
                                 );
                                 
    
     /* 박스 포장 */
      PROCEDURE PUT_BOXPACKING( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                A_BOXNO        IN      TM_BOX.BOXNO%TYPE,
                                A_XML          IN      CLOB,
                                A_USER         IN      TM_USER.USERID%TYPE,
                                N_RETURN      OUT      NUMBER,            /* RETURN VALUE    */
                                V_RETURN      OUT      VARCHAR2,            /* RETURN MESSAGE  */
                                C_RETURN      OUT      SYS_REFCURSOR        /* RETURN CURSOR  */
                              );
                              
    
      /* 수량 포장 작업지시 조회 */
      PROCEDURE GET_QTYPACK_WRKORD( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                    A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                    A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                    N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                    V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                    C_RETURN      OUT      SYS_REFCURSOR       /* RETURN CURSOR */
                                  );
    
    
      /* 수량 포장 */
      PROCEDURE SET_QTYPACKING( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                A_TYPE         IN      VARCHAR2,
                                A_UNITNO       IN      TM_PRODLINE_UNIT.UNITNO%TYPE,
                                A_BOXNO        IN      TM_BOX.BOXNO%TYPE,
                                A_QTY          IN      TM_BOX.QTY%TYPE,
                                A_USER         IN      TM_USER.USERID%TYPE,
                                N_RETURN      OUT      NUMBER,            /* RETURN VALUE    */
                                V_RETURN      OUT      VARCHAR2,            /* RETURN MESSAGE  */
                                C_RETURN      OUT      SYS_REFCURSOR        /* RETURN CURSOR  */
                               );  
                               
                               
      /* 수량 포장 */
      PROCEDURE SET_QTYPACKING( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                A_WRKORD       IN      TW_PRODHIST.WRKORD%TYPE,
                                A_PARTNO       IN      TM_ITEMS.PARTNO%TYPE,
                                A_UNITNO       IN      TM_PRODLINE_UNIT.UNITNO%TYPE,
                                A_BOXNO        IN      TM_BOX.BOXNO%TYPE,
                                A_QTY          IN      TM_BOX.QTY%TYPE,
                                A_USER         IN      TM_USER.USERID%TYPE,
                                N_RETURN      OUT      NUMBER,            /* RETURN VALUE    */
                                V_RETURN      OUT      VARCHAR2,            /* RETURN MESSAGE  */
                                C_RETURN      OUT      SYS_REFCURSOR        /* RETURN CURSOR  */
                               );
     
                              
      /*포장 해체 */
      PROCEDURE SET_UNPACKING( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                               A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                               A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                               A_TYPE         IN      VARCHAR2,
                               A_BOXNO        IN      TM_BOX.BOXNO%TYPE,
                               A_USER         IN      TM_USER.USERID%TYPE,
                               N_RETURN      OUT      NUMBER,            /* RETURN VALUE    */
                               V_RETURN      OUT      VARCHAR2,            /* RETURN MESSAGE  */
                               C_RETURN      OUT      SYS_REFCURSOR        /* RETURN CURSOR  */
                             );
                             
                             
      /*포장 해체 */
      PROCEDURE SET_UNBOXPACKING( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_TYPE         IN      VARCHAR2,
                                  A_BOXNO        IN      TM_BOX.BOXNO%TYPE,
                                  A_USER         IN      TM_USER.USERID%TYPE,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE    */
                                  V_RETURN      OUT      VARCHAR2,            /* RETURN MESSAGE  */
                                  C_RETURN      OUT      SYS_REFCURSOR        /* RETURN CURSOR  */
                                );                         
                             
    
      /* 외주 입고 라벨 출력 정보 */
      PROCEDURE GET_PROD_RECEIVE_OUTSOURCING( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                              A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                              A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                              A_SDATE        IN      TM_BOX.PACKINGDATE%TYPE,
                                              A_EDATE        IN      TM_BOX.PACKINGDATE%TYPE,
                                              N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                              V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                              C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                             );
    
    
      /* 외주 입고 라벨 정보 생성 */
      PROCEDURE SET_PROD_RECEIVE_OUTSOURCING( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                              A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                              A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                              A_ITEMCODE     IN      TM_ITEMS.ITEMCODE%TYPE,
                                              A_WHLOC        IN      TM_LOCATION.WHLOC%TYPE,
                                              A_QTY          IN      TM_SERIAL.QTY%TYPE,
                                              A_USER         IN      VARCHAR2,
                                              N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                              V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                              C_RETURN1     OUT      SYS_REFCURSOR,     /* RETURN CURSOR */
                                              C_RETURN2     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                            );  
                                            
                                            
      /* 압착 검사 결과 조회 */
      PROCEDURE GET_INSP_CRIMP( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                A_SDATE        IN      TH_CRIMPINSP.TXNDATE%TYPE,
                                A_EDATE        IN      TH_CRIMPINSP.TXNDATE%TYPE,
                                N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                C_RETURN      OUT      SYS_REFCURSOR       /* RETURN CURSOR */
                              );   
                              
                              
      /* 작업지시 조회 */
      PROCEDURE GET_WORKORDER( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                               A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                               A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                               A_WRKORD       IN      TW_WORKORD.WRKORD%TYPE,
                               N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                               V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                               C_RETURN      OUT      SYS_REFCURSOR,       /* RETURN CURSOR */
                               C_RETURN1     OUT      SYS_REFCURSOR       /* RETURN CURSOR */
                             ); 
                             
                             
      /*생산 작업 준비*/
      PROCEDURE SET_PROD_READY( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                A_WRKORD       IN      TW_WORKORD.WRKORD%TYPE,
                                A_UNITNO       IN      TW_WORKORD.UNITNO%TYPE,
                                A_USER         IN      TW_WORKORD.CREATEUSER%TYPE,
                                N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                C_RETURN      OUT      SYS_REFCURSOR,      /* RETURN CURSOR */
                                C_RETURN1     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                             );
                             
                             
      /*생산 작업 준비*/
      PROCEDURE SET_PROD_START( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                A_WRKORD       IN      TW_WORKORD.WRKORD%TYPE,
                                A_PRODPROGNO   IN      TH_WORKORD.PRODPROGNO%TYPE,
                                A_USER         IN      TW_WORKORD.CREATEUSER%TYPE,
                                N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                C_RETURN      OUT      SYS_REFCURSOR,      /* RETURN CURSOR */
                                C_RETURN1     OUT      SYS_REFCURSOR,      /* RETURN CURSOR */
                                C_RETURN2     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                             );
                             
                             
      /*생산 작업 종료*/
      PROCEDURE SET_PROD_END( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              A_WRKORD       IN      TW_WORKORD.WRKORD%TYPE,
                              A_PRODPROGNO   IN      TH_WORKORD.PRODPROGNO%TYPE,
                              A_USER         IN      TW_WORKORD.CREATEUSER%TYPE,
                              N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                              V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                              C_RETURN      OUT      SYS_REFCURSOR,      /* RETURN CURSOR */
                              C_RETURN1     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                             );     
                             
                             
      /*생산 작업 종료*/
      PROCEDURE SET_PROD_END( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              A_WRKORD       IN      TW_WORKORD.WRKORD%TYPE,
                              A_PRODPROGNO   IN      TH_WORKORD.PRODPROGNO%TYPE,
                              A_WRKORDSEQ    IN      TH_CRIMPING.WRKORDSEQ%TYPE,
                              A_IFMODE       IN      TH_CRIMPING.IFMODE%TYPE,
                              A_ORDQTY       IN      TH_CRIMPING.ORDQTY%TYPE,
                              A_PRODQTY      IN      TH_CRIMPING.PRODQTY%TYPE,
                              A_STTIME       IN      TH_CRIMPING.PRDSTTIME%TYPE,
                              A_ENTIME       IN      TH_CRIMPING.PRDENTIME%TYPE,
                              A_LOSSTIME     IN      TH_CRIMPING.LOSSTIME%TYPE,
                              A_USER         IN      TW_WORKORD.CREATEUSER%TYPE,
                              N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                              V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                              C_RETURN      OUT      SYS_REFCURSOR,      /* RETURN CURSOR */
                              C_RETURN1     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                             );
                             
                             
      /*생산 작업 종료*/
      PROCEDURE SET_PROD_END( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              A_WRKORD       IN      TW_WORKORD.WRKORD%TYPE,
                              A_PRODPROGNO   IN      TH_WORKORD.PRODPROGNO%TYPE,
                              A_WRKORDSEQ    IN      TH_CRIMPING.WRKORDSEQ%TYPE,
                              A_IFMODE       IN      TH_CRIMPING.IFMODE%TYPE,
                              A_ORDQTY       IN      TH_CRIMPING.ORDQTY%TYPE,
                              A_PRODQTY      IN      TH_CRIMPING.PRODQTY%TYPE,
                              A_STTIME       IN      TH_CRIMPING.PRDSTTIME%TYPE,
                              A_ENTIME       IN      TH_CRIMPING.PRDENTIME%TYPE,
                              A_LOSSTIME     IN      TH_CRIMPING.LOSSTIME%TYPE,
                              A_UPH          IN      TH_CRIMPING.UPH%TYPE,
                              A_USER         IN      TW_WORKORD.CREATEUSER%TYPE,
                              N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                              V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                              C_RETURN      OUT      SYS_REFCURSOR,      /* RETURN CURSOR */
                              C_RETURN1     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                             );
                             
                             
      /*생산 작업 종료*/
      PROCEDURE SET_PROD_END( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              A_WRKORD       IN      TW_WORKORD.WRKORD%TYPE,
                              A_PRODPROGNO   IN      TH_WORKORD.PRODPROGNO%TYPE,
                              A_WRKORDSEQ    IN      TH_CRIMPING.WRKORDSEQ%TYPE,
                              A_IFMODE       IN      TH_CRIMPING.IFMODE%TYPE,
                              A_ORDQTY       IN      TH_CRIMPING.ORDQTY%TYPE,
                              A_PRODQTY      IN      TH_CRIMPING.PRODQTY%TYPE,
                              A_STTIME       IN      TH_CRIMPING.PRDSTTIME%TYPE,
                              A_ENTIME       IN      TH_CRIMPING.PRDENTIME%TYPE,
                              A_LOSSTIME     IN      TH_CRIMPING.LOSSTIME%TYPE,
                              A_UPH          IN      TH_CRIMPING.UPH%TYPE,
                              A_LOG          IN      TH_CRIMPING.DATALOG%TYPE,
                              A_USER         IN      TW_WORKORD.CREATEUSER%TYPE,
                              N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                              V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                              C_RETURN      OUT      SYS_REFCURSOR,      /* RETURN CURSOR */
                              C_RETURN1     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                             );                                                                                             
                             
                             
      /* 자재장착 */
      PROCEDURE SET_MOUNT( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                           A_WRKORD       IN      TW_WORKORD.WRKORD%TYPE,
                           A_SERIAL       IN      TW_MOUNT.SERIAL%TYPE,
                           A_UNITNO       IN      TW_MOUNT.UNITNO%TYPE,
                           A_SIDE         IN      TW_MOUNT.SIDE%TYPE,
                           A_USER         IN      TM_USER.USERID%TYPE,
                           N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                           V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                           C_RETURN      OUT      SYS_REFCURSOR,      /* RETURN CURSOR */
                           C_RETURN1     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                         );
                         
                                                 
      /* 생산 실적 등록 */
      PROCEDURE SET_PROD_REG( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              A_WRKORD       IN      TW_WORKORD.WRKORD%TYPE,
                              A_UNITNO       IN      TW_MOUNT.UNITNO%TYPE,
                              A_PRODQTY      IN      TW_PRODHIST.PRODQTY%TYPE,
                              A_USER         IN      TM_USER.USERID%TYPE,
                              N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                              V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                              C_RETURN      OUT      SYS_REFCURSOR,      /* RETURN CURSOR */
                              C_RETURN1     OUT      SYS_REFCURSOR,     /* RETURN CURSOR */
                              C_RETURN2     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                            ); 
                            
                            
      /* 생산 실적 등록 */
      PROCEDURE SET_PROD_REG( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              A_WRKORD       IN      TW_WORKORD.WRKORD%TYPE,
                              A_UNITNO       IN      TW_MOUNT.UNITNO%TYPE,
                              A_PRODQTY      IN      TW_PRODHIST.PRODQTY%TYPE,
                              A_USER         IN      TM_USER.USERID%TYPE,
                              A_LOG          IN      TH_CRIMPING.DATALOG%TYPE,
                              N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                              V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                              C_RETURN      OUT      SYS_REFCURSOR,      /* RETURN CURSOR */
                              C_RETURN1     OUT      SYS_REFCURSOR,     /* RETURN CURSOR */
                              C_RETURN2     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                            );                        
                            
                            
      /*생산 실적  결과 조회 */
      PROCEDURE GET_PROD_REG_HIST( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                   A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                   A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                   A_WRKORD       IN      TH_CRIMPINSP.TXNDATE%TYPE,
                                   N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                   V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                   C_RETURN      OUT      SYS_REFCURSOR       /* RETURN CURSOR */
                                 ); 
                                   
                            
      -- 생산 계획 UPLOAD
      PROCEDURE PUT_PRODPLAN_UPLOAD( A_CLIENT       IN   TM_PRODPLAN.CLIENT%TYPE,
                                     A_COMPANY      IN   TM_PRODPLAN.COMPANY%TYPE,
                                     A_PLANT        IN   TM_PRODPLAN.PLANT%TYPE,
                                     A_XML          IN   CLOB,
                                     A_PLANDATE     IN   TM_PRODPLAN.PLANDATE%TYPE,
                                     A_USER         IN   VARCHAR2,          
                                     N_RETURN       OUT  NUMBER,            /* RETURN VALUE */
                                     V_RETURN       OUT  VARCHAR2,          /* RETURN MESSAGE */
                                     C_RETURN       OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                                    );  
      
       --생산 계획 조회
      PROCEDURE GET_PRODPLAN ( A_CLIENT       IN   TM_PRODPLAN.CLIENT%TYPE,
                               A_COMPANY      IN   TM_PRODPLAN.COMPANY%TYPE,
                               A_PLANT        IN   TM_PRODPLAN.PLANT%TYPE,
                               A_PLANDATE     IN   TM_PRODPLAN.PLANDATE%TYPE,
                               A_PARTNO       IN   TM_ITEMS.PARTNO%TYPE,
                               N_RETURN       OUT  NUMBER,            /* RETURN VALUE */
                               V_RETURN       OUT  VARCHAR2,          /* RETURN MESSAGE */
                               C_RETURN       OUT  SYS_REFCURSOR,      /* RETURN CURSOR */
                               C_RETURN1      OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                             );        
                             
                                   
                            
      -- 생산 계획 UPLOAD
      PROCEDURE PUT_PRODPLAN_MONTH_UPLOAD( A_CLIENT       IN   TM_PRODPLAN.CLIENT%TYPE,
                                           A_COMPANY      IN   TM_PRODPLAN.COMPANY%TYPE,
                                           A_PLANT        IN   TM_PRODPLAN.PLANT%TYPE,
                                           A_XML          IN   CLOB,
                                           A_PLANDATE     IN   TM_PRODPLAN.PLANDATE%TYPE,
                                           A_USER         IN   VARCHAR2,          
                                           N_RETURN       OUT  NUMBER,            /* RETURN VALUE */
                                           V_RETURN       OUT  VARCHAR2,          /* RETURN MESSAGE */
                                           C_RETURN       OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                                          );  
      
       --생산 계획 조회
      PROCEDURE GET_PRODPLAN_MONTH ( A_CLIENT       IN   TM_PRODPLAN.CLIENT%TYPE,
                                     A_COMPANY      IN   TM_PRODPLAN.COMPANY%TYPE,
                                     A_PLANT        IN   TM_PRODPLAN.PLANT%TYPE,
                                     A_PLANDATE     IN   TM_PRODPLAN.PLANDATE%TYPE,
                                     A_PARTNO       IN   TM_ITEMS.PARTNO%TYPE,
                                     N_RETURN       OUT  NUMBER,            /* RETURN VALUE */
                                     V_RETURN       OUT  VARCHAR2,          /* RETURN MESSAGE */
                                     C_RETURN       OUT  SYS_REFCURSOR,      /* RETURN CURSOR */
                                     C_RETURN1      OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                                   );        
                             
                             
      /*압착 설비 오류*/
      PROCEDURE SET_CRIMPINGERROR( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                   A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                   A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                   A_WRKORD       IN      TW_WORKORD.WRKORD%TYPE,
                                   A_WRKORDSEQ    IN      TH_CRIMPING.WRKORDSEQ%TYPE,
                                   A_ERRCODE      IN      TH_CRIMPING.ERRCODE%TYPE,
                                   A_STTIME       IN      TH_CRIMPING.PRDSTTIME%TYPE,
                                   A_ENTIME       IN      TH_CRIMPING.PRDENTIME%TYPE,
                                   N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                   V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                   C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                  );      
                                  
                                  
      /*압착 설비 오류*/
      PROCEDURE SET_CRIMPINGERROR( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                   A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                   A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                   A_WRKORD       IN      TW_WORKORD.WRKORD%TYPE,
                                   A_WRKORDSEQ    IN      TH_CRIMPING.WRKORDSEQ%TYPE,
                                   A_ERRCODE      IN      TH_CRIMPING.ERRCODE%TYPE,
                                   A_STTIME       IN      TH_CRIMPING.PRDSTTIME%TYPE,
                                   A_ENTIME       IN      TH_CRIMPING.PRDENTIME%TYPE,
                                   A_LOG          IN      TH_CRIMPING.DATALOG%TYPE,
                                   N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                   V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                   C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                  ); 
                                  
                                  
      /*품목대체조회 */
      PROCEDURE GET_REPLACEITEM( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 A_STDATE       IN      TW_IN.INDATE%TYPE,
                                 A_ENDATE       IN      TW_IN.INDATE%TYPE,
                                 N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                 V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                 C_RETURN      OUT      SYS_REFCURSOR       /* RETURN CURSOR */
                                );
                                                              
                                  
      /*반제품 품목 대체 */
      PROCEDURE PUT_REPLACEITEM( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 A_XML          IN      CLOB,
                                 A_USER         IN      TM_USER.USERID%TYPE,
                                 N_RETURN      OUT      NUMBER,            /* RETURN VALUE    */
                                 V_RETURN      OUT      VARCHAR2,            /* RETURN MESSAGE  */
                                 C_RETURN      OUT      SYS_REFCURSOR        /* RETURN CURSOR  */
                                ); 
                                
                                
      /*작업지시 호기 변경 */
      PROCEDURE SET_CHANGE_UNITNO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                   A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                   A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                   A_WRKORD       IN      TW_WORKORD.WRKORD%TYPE,
                                   A_UNITNO       IN      TW_WORKORD.UNITNO%TYPE,
                                   A_USER         IN      TM_USER.USERID%TYPE,
                                   N_RETURN      OUT      NUMBER,            /* RETURN VALUE    */
                                   V_RETURN      OUT      VARCHAR2,            /* RETURN MESSAGE  */
                                   C_RETURN      OUT      SYS_REFCURSOR        /* RETURN CURSOR  */
                                  );                                                                                                                                            
                                                 
                                 
      /*작업지시 확인*/
      PROCEDURE CHK_WORKORDER( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                   A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                   A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                   A_WRKORD       IN      TW_WORKORD.WRKORD%TYPE,
                                   A_OPER         IN      VARCHAR2,
                                   N_RETURN      OUT      NUMBER,            /* RETURN VALUE    */
                                   V_RETURN      OUT      VARCHAR2,            /* RETURN MESSAGE  */
                                   C_RETURN      OUT      SYS_REFCURSOR        /* RETURN CURSOR  */
                                  );                                                                                                                                            
                                 
                                 
                                                                                                                                                                                                                                                                                                                    
    END PKGPRD_PROD;
    ```

**참조 테이블:**

`TH_BOX`, `TH_CRIMPING`, `TH_CRIMPINSP`, `TH_OQC`, `TH_WORKORD`, `TM_BOM`, `TM_BOX`, `TM_CLIENT`, `TM_COMMCODE`, `TM_COMPANY`, `TM_DOWNTIME`, `TM_EHR`, `TM_GP12_ITEM`, `TM_ITEMS`, `TM_LOCATION`, `TM_OPERATION`, `TM_PLANT`, `TM_PRODLINE`, `TM_PRODLINE_UNIT`, `TM_PRODPLAN`, `TM_PRODPLAN_MONTH`, `TM_SERIAL`, `TM_SUBITEMS`, `TM_USER`, `TM_VENDOR`, `TW_BRD`, `TW_CRIMPPING`, `TW_DAILYWORKPLAN`, `TW_IN`, `TW_MATERIALREQUSET`, `TW_MOUNT`, `TW_OUT`, `TW_PRODHIST`, `TW_PRODHIST_USE`, `TW_STOCKSERIAL`, `TW_WORKORD`

---

### PKGPRD_QC

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `GET_INSP_OBJECT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_INSP_HISTORY` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_INSP_CRIMP` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_INSP_CRIMP` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_INSP_CRIMP` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_OQC_REPORT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_OQC_REPORT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         PKGPRD_QC IS
    
      /* 배판 호기 정보 조회 */
      PROCEDURE GET_INSP_OBJECT( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                 V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                 C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                               );
                               
                               
      /* 작업실적(압착검사) 이력 조회 */
      PROCEDURE GET_INSP_HISTORY( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_SDATE        IN      TH_CRIMPINSP.TXNDATE%TYPE,
                                  A_EDATE        IN      TH_CRIMPINSP.TXNDATE%TYPE,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                 );
    
                               
      /* 작업실적(압착검사) 정보 등록 */
      PROCEDURE SET_INSP_CRIMP( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                A_WIRE         IN      TH_CRIMPINSP.WIRE%TYPE,
                                A_TERMINAL     IN      TH_CRIMPINSP.TERMINAL%TYPE,
                                A_CCH          IN      TH_CRIMPINSP.CCH%TYPE,
                                A_CCW          IN      TH_CRIMPINSP.CCW%TYPE,
                                A_ICH          IN      TH_CRIMPINSP.ICH%TYPE,
                                A_ICW          IN      TH_CRIMPINSP.ICW%TYPE,
                                A_TEN          IN      TH_CRIMPINSP.TENSION%TYPE,
                                A_RESIS        IN      TH_CRIMPINSP.RESISTANCE%TYPE,
                                A_USER         IN      TH_CRIMPINSP.CREATEUSER%TYPE,
                                N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                              );    
                              
                              
      /* 작업실적(압착검사) 정보 등록 */
      PROCEDURE SET_INSP_CRIMP( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                A_WIRE         IN      TH_CRIMPINSP.WIRE%TYPE,
                                A_TERMINAL     IN      TH_CRIMPINSP.TERMINAL%TYPE,
                                A_CCH          IN      TH_CRIMPINSP.CCH%TYPE,
                                A_CCW          IN      TH_CRIMPINSP.CCW%TYPE,
                                A_ICH          IN      TH_CRIMPINSP.ICH%TYPE,
                                A_ICW          IN      TH_CRIMPINSP.ICW%TYPE,
                                A_TEN          IN      TH_CRIMPINSP.TENSION%TYPE,
                                A_RESIS        IN      TH_CRIMPINSP.RESISTANCE%TYPE,
                                A_FILENAME     IN      TH_CRIMPINSP.FPATH%TYPE,
                                A_USER         IN      TH_CRIMPINSP.CREATEUSER%TYPE,
                                N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                              );
                              
                              
      /* 작업실적(압착검사) 정보 등록 */
      PROCEDURE SET_INSP_CRIMP( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                A_WIRE         IN      TH_CRIMPINSP.WIRE%TYPE,
                                A_TERMINAL     IN      TH_CRIMPINSP.TERMINAL%TYPE,
                                A_CCH          IN      TH_CRIMPINSP.CCH%TYPE,
                                A_CCW          IN      TH_CRIMPINSP.CCW%TYPE,
                                A_ICH          IN      TH_CRIMPINSP.ICH%TYPE,
                                A_ICW          IN      TH_CRIMPINSP.ICW%TYPE,
                                A_TEN          IN      TH_CRIMPINSP.TENSION%TYPE,
                                A_RESIS        IN      TH_CRIMPINSP.RESISTANCE%TYPE,
                                A_FFILE        IN      TH_CRIMPINSP.FPATH%TYPE,
                                A_RFILE        IN      TH_CRIMPINSP.RPATH%TYPE,
                                A_USER         IN      TH_CRIMPINSP.CREATEUSER%TYPE,
                                N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                C_RETURN      OUT      SYS_REFCURSOR,      /* RETURN CURSOR */
                                C_RETURN1     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                              );     
      
        PROCEDURE SET_OQC_REPORT ( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                   A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                   A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */                                                        
                                   A_FILE         IN      TH_OQC_REPORT.FPATH%TYPE,     
                                   A_USER         IN      TH_OQC_REPORT.CREATEUSER%TYPE,
                                   N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                   V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                   C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                 );
        
      PROCEDURE GET_OQC_REPORT( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                A_SDATE        IN      TW_IQC.IQCDATE%TYPE,
                                A_EDATE        IN      TW_IQC.IQCDATE%TYPE,
                                N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                               );
      
       
    END PKGPRD_QC;
    ```

**참조 테이블:**

`TH_CRIMPINSP`, `TH_OQC_REPORT`, `TH_OQC_REPORT_SEQ`, `TM_CLIENT`, `TM_COMPANY`, `TM_CRIMPINSP`, `TM_PLANT`, `TW_IQC`

---

### PKGPRD_REPORT

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `GET_PRODSN_DETAIL_HIST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_BOX_DETAIL_HIST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_WO_DETAIL_HIST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PRODUCT_STOCK_A` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_PRODUCT_STOCK_B` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_DAILY_STOCK_A` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_DAILY_STOCK_B` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_DAILY_STOCK_MATERIAL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_BUNDLE_STOCK_A` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_BUNDLE_STOCK_B` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_OUTSOURCING_INOUT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_WRKMOUNT_HISTORY` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_ACTUALMATERIALSTOCK` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         PKGPRD_REPORT IS
    
    
      /* LOT 추적 */
      PROCEDURE GET_PRODSN_DETAIL_HIST( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                        A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                        A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                        A_FLAG         IN      VARCHAR2,
                                        A_BARCODE      IN      VARCHAR2,
                                        N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                        V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                        C_RETURN      OUT      SYS_REFCURSOR,      /* RETURN CURSOR */
                                        C_RETURN1     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                      );
                                      
                                      
      /* BOX 추적 */
      PROCEDURE GET_BOX_DETAIL_HIST( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                     A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                     A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                     A_BARCODE      IN      VARCHAR2,
                                     N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                     V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                     C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                   ); 
                                   
                                   
      /* WO 추적 */
      PROCEDURE GET_WO_DETAIL_HIST( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                    A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                    A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                    A_BARCODE      IN      VARCHAR2,
                                    N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                    V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                    C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                  );                                   
                                   
                                   
      /*박스 재고 현황 조회*/
      PROCEDURE GET_PRODUCT_STOCK_A( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                     A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                     A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                     A_WH           IN      TM_WAREHOUSE.WAREHOUSE%TYPE,
                                     A_WHLOC        IN      TW_STOCKSERIAL.WHLOC%TYPE,
                                     A_PARTNO       IN      TM_ITEMS.PARTNO%TYPE,
                                     N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                     V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                     C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                   );    
                                 
      /*박스 재고 현황 조회(상세)*/
      PROCEDURE GET_PRODUCT_STOCK_B( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                     A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                     A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                     A_WH           IN      TM_WAREHOUSE.WAREHOUSE%TYPE,
                                     A_WHLOC        IN      TW_STOCKSERIAL.WHLOC%TYPE,
                                     A_PARTNO       IN      TM_ITEMS.PARTNO%TYPE,
                                     N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                     V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                     C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                   );        
                                 
                                   
      /*일별 생산 현황 조회*/
      PROCEDURE GET_DAILY_STOCK_A( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                   A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                   A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                   A_SDATE        IN      TW_PRODHIST.PRODDATE%TYPE,
                                   A_EDATE        IN      TW_PRODHIST.PRODDATE%TYPE,
                                   A_WH           IN      TM_WAREHOUSE.WAREHOUSE%TYPE,
                                   A_WHLOC        IN      TW_STOCKSERIAL.WHLOC%TYPE,
                                   A_PARTNO       IN      TM_ITEMS.PARTNO%TYPE,
                                   N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                   V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                   C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                 );                                                                                                              
                                     
                                 
      /*일별 생산(상세) 현황 조회*/
      PROCEDURE GET_DAILY_STOCK_B( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                   A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                   A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                   A_SDATE        IN      TW_PRODHIST.PRODDATE%TYPE,
                                   A_EDATE        IN      TW_PRODHIST.PRODDATE%TYPE,
                                   A_WH           IN      TM_WAREHOUSE.WAREHOUSE%TYPE,
                                   A_WHLOC        IN      TW_STOCKSERIAL.WHLOC%TYPE,
                                   A_PARTNO       IN      TM_ITEMS.PARTNO%TYPE,
                                   N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                   V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                   C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                 ); 
                                 
                                 
      /*일별 생산 대비 자재차감현황  조회*/
      PROCEDURE GET_DAILY_STOCK_MATERIAL( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                          A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                          A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                          A_WRKORD       IN      TW_WORKORD.WRKORD%TYPE,
                                          A_OUTDATE      IN      TW_OUT.OUTDATE%TYPE,
                                          A_ITEMCODE     IN      TW_WORKORD.ITEMCODE%TYPE,
                                          N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                          V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                          C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                         );                             
                                 
                                 
      /*묶음 박스 재고 현황 조회*/
      PROCEDURE GET_BUNDLE_STOCK_A( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                    A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                    A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                    A_WHLOC        IN      TW_STOCKSERIAL.WHLOC%TYPE,
                                    A_BOXNO        IN      TM_BOX.BOXNO%TYPE,
                                    N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                    V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                    C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                   );  
                                   
                                   
      /*묶음 박스 재고 현황 조회(상세)*/
      PROCEDURE GET_BUNDLE_STOCK_B( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                    A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                    A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                    A_BOXNO        IN      TM_ITEMS.PARTNO%TYPE,
                                    N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                    V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                    C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                   );   
                                   
                                   
      /*외주 입출고 내역 조회*/
      PROCEDURE GET_OUTSOURCING_INOUT( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                       A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                       A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                       A_MONTH        IN      TW_ACTUALSTOCK.ACTUALMON%TYPE,
                                       A_WHLOC        IN      TW_ACTUALSTOCK.WHLOC%TYPE,
                                       N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                       V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                       C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                      );
                                      
                                      
      /*작업지시별 자재 장착 내역*/
      PROCEDURE GET_WRKMOUNT_HISTORY( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                      A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                      A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                      A_SDATE        IN      TW_WORKORD.WRKDATE%TYPE,
                                      A_EDATE        IN      TW_WORKORD.WRKDATE%TYPE,
                                      A_WRKORD       IN      TW_WORKORD.WRKORD%TYPE,
                                      N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                      V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                      C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                    );     
                                    
                                    
      /* 재고 실사 자재 소요 집계*/
      PROCEDURE GET_ACTUALMATERIALSTOCK( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                         A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                         A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                         A_ACTUALMON    IN      TW_ACTUALSTOCK.ACTUALMON%TYPE,
                                         A_WHLOC        IN      TW_ACTUALSTOCK.WHLOC%TYPE,
                                         N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                         V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                         C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                       );                                                                                                                                                                                                                                                                                                                                                                                                                                                              
    END PKGPRD_REPORT;
    ```

**참조 테이블:**

`TH_BOX`, `TMP_ACTUALMATERIAL`, `TM_BOM`, `TM_BOX`, `TM_CLIENT`, `TM_COMPANY`, `TM_DEFECT`, `TM_EHR`, `TM_ITEMS`, `TM_LOCATION`, `TM_PLANT`, `TM_PRODLINE`, `TM_PRODLINE_UNIT`, `TM_SERIAL`, `TM_TRANSACTION`, `TM_VENDOR`, `TM_WAREHOUSE`, `TW_ACTUALSTOCK`, `TW_BRD`, `TW_IN`, `TW_MOUNT`, `TW_OUT`, `TW_PRODHIST`, `TW_PRODHIST_USE`, `TW_STOCKSERIAL`, `TW_WORKORD`

---

### PKGPRD_SALES

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `GET_DELIVERY` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_SERIAL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_BOXINFO` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_BOXSPLIT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_CUSTPLAN_UPLOAD` | A_CLIENT IN TM_CUSTPLAN.CLIENT%TYPE, A_COMPANY IN TM_CUSTPLAN.COMPANY%TYPE, A... |
| PROC | `GET_CUSTPLAN` | A_CLIENT IN TM_CUSTPLAN.CLIENT%TYPE, A_COMPANY IN TM_CUSTPLAN.COMPANY%TYPE, A... |
| PROC | `GET_CUSTPLAN_ORDER` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_OQC` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_OQC_DETAIL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_OQC` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         PKGPRD_SALES is
    
      /* 제품 출하 이력 */
      PROCEDURE GET_DELIVERY( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              A_SDATE        IN      TW_OUT.OUTDATE%TYPE,
                              A_EDATE        IN      TW_OUT.OUTDATE%TYPE,
                              A_VENDOR       IN      TW_OUT.VENDOR%TYPE,
                              A_BOXNO        IN      TW_OUT.BOXNO%TYPE,
                              N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                              V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                              C_RETURN      OUT      SYS_REFCURSOR
                            );
                            
                            
      /* 포장 개별 시리얼 조회*/
      PROCEDURE GET_SERIAL( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                            A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                            A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                            A_BOXNO        IN      TW_OUT.BOXNO%TYPE,
                            N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                            V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                            C_RETURN      OUT      SYS_REFCURSOR
                          );  
                          
                          
      /* 포장 박스 정보 조회*/
      PROCEDURE GET_BOXINFO( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                             A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                             A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                             A_BOXNO        IN      TW_OUT.BOXNO%TYPE,
                             N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                             V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                             C_RETURN      OUT      SYS_REFCURSOR
                           );  
                           
                           
      /* 포장 박스 분리*/
      PROCEDURE SET_BOXSPLIT( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              A_BOXNO        IN      TM_BOX.BOXNO%TYPE,
                              A_SPLITQTY     IN      TM_BOX.QTY%TYPE,
                              A_USER         IN      VARCHAR2,
                              N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                              V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                              C_RETURN1     OUT      SYS_REFCURSOR,     /* RETURN CURSOR */
                              C_RETURN2     OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                            );     
                            
      -- 고객 계획 UPLOAD
      PROCEDURE PUT_CUSTPLAN_UPLOAD( A_CLIENT       IN   TM_CUSTPLAN.CLIENT%TYPE,
                                     A_COMPANY      IN   TM_CUSTPLAN.COMPANY%TYPE,
                                     A_PLANT        IN   TM_CUSTPLAN.PLANT%TYPE,
                                     A_XML          IN   CLOB,
                                     A_VENDOR       IN   TM_CUSTPLAN.VENDOR%TYPE,
                                     A_PLANDATE     IN   TM_CUSTPLAN.PLANDATE%TYPE,
                                     A_USER         IN   VARCHAR2,          
                                     N_RETURN       OUT  NUMBER,            /* RETURN VALUE */
                                     V_RETURN       OUT  VARCHAR2,          /* RETURN MESSAGE */
                                     C_RETURN       OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                                    );  
      
       --고객 계획 조회
      PROCEDURE GET_CUSTPLAN ( A_CLIENT       IN   TM_CUSTPLAN.CLIENT%TYPE,
                               A_COMPANY      IN   TM_CUSTPLAN.COMPANY%TYPE,
                               A_PLANT        IN   TM_CUSTPLAN.PLANT%TYPE,
                               A_VENDOR       IN   TM_CUSTPLAN.VENDOR%TYPE,
                               A_PLANDATE     IN   TM_CUSTPLAN.PLANDATE%TYPE,
                               A_PARTNO       IN   TM_ITEMS.PARTNO%TYPE,
                               N_RETURN       OUT  NUMBER,            /* RETURN VALUE */
                               V_RETURN       OUT  VARCHAR2,          /* RETURN MESSAGE */
                               C_RETURN       OUT  SYS_REFCURSOR,      /* RETURN CURSOR */
                               C_RETURN1      OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                             ); 
                             
                             
       --고객 주문 조회
      PROCEDURE GET_CUSTPLAN_ORDER( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                    A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                    A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                    A_PLANDATE     IN      TM_CUSTPLAN.PLANDATE%TYPE,
                                    N_RETURN       OUT     NUMBER,            /* RETURN VALUE */
                                    V_RETURN       OUT     VARCHAR2,          /* RETURN MESSAGE */
                                    C_RETURN       OUT     SYS_REFCURSOR,     /* RETURN CURSOR */
                                    C_RETURN1      OUT     SYS_REFCURSOR      /* RETURN CURSOR */
                                  ); 
                                  
                                  
      /* OQC 조회 */
      PROCEDURE GET_OQC( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                         A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                         A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                         A_SDATE        IN      TW_OUT.OUTDATE%TYPE,
                         A_EDATE        IN      TW_OUT.OUTDATE%TYPE,
                         N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                         V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                         C_RETURN      OUT      SYS_REFCURSOR
                        );  
                        
                        
       /* OQC 세부 박스 정보 조회 */
      PROCEDURE GET_OQC_DETAIL( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                A_OUTDATE      IN      TW_OQC.OUTDATE%TYPE,
                                A_ITEMCODE     IN      TW_OQC.ITEMCODE%TYPE,
                                A_TOWHLOC      IN      TW_OQC.TOWHLOC%TYPE,
                                N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                C_RETURN      OUT      SYS_REFCURSOR
                               );    
      
      
      /* OQC 등록 */
      PROCEDURE SET_OQC( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                         A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                         A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                         A_OUTDATE      IN      TW_OQC.OUTDATE%TYPE,
                         A_ITEMCODE     IN      TW_OQC.ITEMCODE%TYPE,
                         A_TOWHLOC      IN      TW_OQC.TOWHLOC%TYPE,
                         A_JUDGE        IN      TM_BOX.JUDGE%TYPE,
                         A_USER         IN      VARCHAR2,
                         N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                         V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                         C_RETURN      OUT      SYS_REFCURSOR
                       );                                                                                              
                             
    
    end PKGPRD_SALES;
    ```

**참조 테이블:**

`TM_BOX`, `TM_CLIENT`, `TM_COMPANY`, `TM_CUSTPLAN`, `TM_CUSTPLAN_ORDER`, `TM_EHR`, `TM_ITEMS`, `TM_LOCATION`, `TM_PLANT`, `TM_SERIAL`, `TM_VENDOR`, `TW_IN`, `TW_OQC`, `TW_OUT`

---

### PKGSYS_COMM

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `GET_SYSTEM` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_USESYSTEM` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_USESYSTEMLOG` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_GLOSSARY` | A_SYSTEM IN VARCHAR2, /* SYSTEM CODE */ N_RETURN OUT NUMBER, /* RETURN VALUE ... |
| PROC | `PUT_GLOSSARY` | A_SYSTEM IN VARCHAR2, /* SYSTEM CODE */ A_GLSR IN TM_GLOSSARY.GLSR%TYPE, A_KO... |
| PROC | `DEL_GLOSSARY` | A_SYSTEM IN VARCHAR2, /* SYSTEM CODE */ A_GLSR IN TM_GLOSSARY.GLSR%TYPE, N_RE... |
| PROC | `GET_CLIENT` | N_RETURN OUT NUMBER, /* RETURN VALUE */ V_RETURN OUT VARCHAR2, /* RETURN MESS... |
| PROC | `PUT_CLIENT` | N_RETURN OUT NUMBER, /* RETURN VALUE */ V_RETURN OUT VARCHAR2, /* RETURN MESS... |
| PROC | `GET_COMPANY` | N_RETURN OUT NUMBER, /* RETURN VALUE */ V_RETURN OUT VARCHAR2, /* RETURN MESS... |
| PROC | `PUT_COMPANY` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_UNITTYPE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_UNIT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_UNIT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_TRANSACTION` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_TRANSACTION` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_TRANSACTION` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_COMMGRP` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_COMMGRP` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_COMM` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_COMM` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_LOG` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_LOG` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_NOTICE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_NOTICE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_ERROR_LOG` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_VERSIONHISTORY` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_VERSIONHISTORY` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_EXPIRY_MATERIAL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_EXPIRY_JIG` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| FUNC | `FUN_DISPDTM` | A_DATETIME IN VARCHAR2, /* YYYYMMDD or YYYYMMDDHH24MISS o... → VARCHAR2 |
| FUNC | `F_GET_TRANSACTION_NAME` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY ... → TM_TRANSACTION |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         PKGSYS_COMM IS
      
      /* 날짜 표시 */
      FUNCTION FUN_DISPDTM( A_DATETIME     IN  VARCHAR2, /* YYYYMMDD or YYYYMMDDHH24MISS or YYYYMMDDHH24MISSFF */
                            A_TYPE         IN  NUMBER
                          )
      RETURN VARCHAR2 ;
      
      
      /* 트랜잭션 정보 이름 조회 */
      FUNCTION F_GET_TRANSACTION_NAME( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                       A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                       A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                       A_TXNCODE        IN      TM_TRANSACTION.TXNCODE%TYPE)
        RETURN TM_TRANSACTION.TXNNAME%TYPE;
    
    
      /* 시스템 정보 */
      PROCEDURE GET_SYSTEM( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                            A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                            A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                            N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                            V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                            C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                           );
    
      /* 시스템 사용 이력 */
      PROCEDURE PUT_USESYSTEM( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                               A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                               A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                               A_SYSTEM         IN      TH_USESYSTEM.SYSCODE%TYPE,
                               A_USER           IN      TH_USESYSTEM.USERID%TYPE,
                               A_IPADR          IN      TH_USESYSTEM.TERMIPADDR%TYPE,
                               A_CONTYPE        IN      TH_USESYSTEM.CONTYPE%TYPE,     /* 1 = LogIN, 2 = LogOut */
                               N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                               V_RETURN        OUT      VARCHAR2           /* RETURN MESSAGE */
                              );
    
    
      /* 시스템 메시지 이력 */
      PROCEDURE PUT_USESYSTEMLOG( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_SYSTEM         IN      TH_USESYSTEMLOG.SYSCODE%TYPE,
                                  A_USER           IN      TH_USESYSTEMLOG.USERID%TYPE,
                                  A_IPADR          IN      TH_USESYSTEMLOG.TERMIPADDR%TYPE,
                                  A_SUBJECT        IN      TH_USESYSTEMLOG.SUBJECT%TYPE,
                                  A_HEADER         IN      TH_USESYSTEMLOG.HEADER%TYPE,
                                  A_CONTENTS       IN      TH_USESYSTEMLOG.CONTENTS%TYPE,
                                  N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN        OUT      VARCHAR2           /* RETURN MESSAGE */
                                 );
    
                                 
      /*용어 마스터 정보 조회 */
      PROCEDURE GET_GLOSSARY( A_SYSTEM         IN      VARCHAR2,          /* SYSTEM CODE */
                              N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                              V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                              C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                             );
    
    
      /*용어 마스터 등록 */
      PROCEDURE PUT_GLOSSARY( A_SYSTEM                IN  VARCHAR2,          /* SYSTEM CODE */
                              A_GLSR                  IN  TM_GLOSSARY.GLSR%TYPE,
                              A_KORGLSR               IN  TM_GLOSSARY.KORGLSR%TYPE,
                              A_ENGGLSR               IN  TM_GLOSSARY.ENGGLSR%TYPE,
                              A_NATGLSR               IN  TM_GLOSSARY.NATGLSR%TYPE,
                              A_REMARKS               IN  TM_GLOSSARY.REMARKS%TYPE,
                              A_USER                  IN  TM_GLOSSARY.CREATEUSER%TYPE,
                              A_NEWFLAG               IN  VARCHAR2,
                              N_RETURN               OUT  NUMBER,            /* RETURN VALUE */
                              V_RETURN               OUT  VARCHAR2          /* RETURN MESSAGE */
                             ) ;
    
    
      /*용어 마스터 삭제 */
      PROCEDURE DEL_GLOSSARY( A_SYSTEM                IN  VARCHAR2,          /* SYSTEM CODE */
                              A_GLSR                  IN  TM_GLOSSARY.GLSR%TYPE,
                              N_RETURN               OUT  NUMBER,            /* RETURN VALUE */
                              V_RETURN               OUT  VARCHAR2          /* RETURN MESSAGE */
                             ) ;
    
    
      /* 법인 정보 조회 */
      PROCEDURE GET_CLIENT( N_RETURN               OUT  NUMBER,            /* RETURN VALUE */
                            V_RETURN               OUT  VARCHAR2,          /* RETURN MESSAGE */
                            C_RETURN               OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                           ) ;
                      
           
      /* 법인 정보 등록 */
      PROCEDURE PUT_CLIENT( N_RETURN               OUT  NUMBER,            /* RETURN VALUE */
                            V_RETURN               OUT  VARCHAR2,          /* RETURN MESSAGE */
                            C_RETURN               OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                           ) ;                       
    
    
      /* 사업부 정보 조회 */
      PROCEDURE GET_COMPANY( N_RETURN               OUT  NUMBER,            /* RETURN VALUE */
                             V_RETURN               OUT  VARCHAR2,          /* RETURN MESSAGE */
                             C_RETURN               OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                            ) ;
    
    
      /* 사업부 정보 등록 */
      PROCEDURE PUT_COMPANY ( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_COMPANYNAME    IN      TM_COMPANY.COMPANYNAME%TYPE,
                              A_USEFLAG        IN      TM_COMPANY.USEFLAG%TYPE,
                              A_REMARKS        IN      TM_COMPANY.REMARKS%TYPE,
                              A_USERID         IN      TM_COMPANY.CREATEUSER%TYPE,
                              N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                              V_RETURN        OUT      VARCHAR2           /* RETURN MESSAGE */
                            );
    
    
      /* 단위 구분 조회 */
      PROCEDURE GET_UNITTYPE ( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                               A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                               A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                               N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                               V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                               C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                              );
    
    
      /* 단위 정보 조회 */
      PROCEDURE GET_UNIT ( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                           A_TYPE           IN      TM_UNITCODE.UNITTYPE%TYPE,
                           A_VIEW           IN      NUMBER,
                           N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                           V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                           C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                          );
    
    
      /* 단위 정보 등록 */
      PROCEDURE PUT_UNIT( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                          A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                          A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                          A_UNIT           IN      TM_UNITCODE.UNITCODE%TYPE,
                          A_UNITNAME       IN      TM_UNITCODE.UNITNAME%TYPE,
                          A_UNITTYPE       IN      TM_UNITCODE.UNITTYPE%TYPE,
                          A_USEFLAG        IN      TM_UNITCODE.USEFLAG%TYPE,
                          A_REMARKS        IN      TM_UNITCODE.REMARKS%TYPE,
                          A_USERID         IN      TM_UNITCODE.CREATEUSER%TYPE,
                          A_NEWFLAG        IN      VARCHAR2,
                          N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                          V_RETURN        OUT      VARCHAR2           /* RETURN MESSAGE */
                        );
    
    
      /* 트랜잭션 정보 조회 */
      PROCEDURE GET_TRANSACTION ( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_VIEW           IN      NUMBER,
                                  N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                 );
    
    
      /* 트랜잭션 정보 조회 */
      PROCEDURE GET_TRANSACTION ( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_TYPE           IN      VARCHAR2,
                                  A_VIEW           IN      VARCHAR2,
                                  N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                 );
    
    
      /* 트랜잭션 정보 등록 */
      PROCEDURE PUT_TRANSACTION ( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_TXNCODE        IN      TM_TRANSACTION.TXNCODE%TYPE,
                                  A_TXNNAME        IN      TM_TRANSACTION.TXNNAME%TYPE,
                                  A_ERPTXNCODE     IN      TM_TRANSACTION.ERPTXNCODE%TYPE,
                                  A_MATINFLAG      IN      TM_TRANSACTION.MATINFLAG%TYPE,
                                  A_MATOUTFLAG     IN      TM_TRANSACTION.MATOUTFLAG%TYPE,
                                  A_PRDINFLAG      IN      TM_TRANSACTION.PRDINFLAG%TYPE,
                                  A_PRDOUTFLAG     IN      TM_TRANSACTION.PRDOUTFLAG%TYPE,
                                  A_CANCELFLAG     IN      TM_TRANSACTION.CANCELFLAG%TYPE,
                                  A_UNDOFLAG       IN      TM_TRANSACTION.UNDOFLAG%TYPE,
                                  A_USEMES         IN      TM_TRANSACTION.USEMES%TYPE,
                                  A_USEFLAG        IN      TM_TRANSACTION.USEFLAG%TYPE,
                                  A_REMARKS        IN      TM_TRANSACTION.REMARKS%TYPE,
                                  A_NEWFLAG        IN      VARCHAR2,
                                  N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN        OUT      VARCHAR2           /* RETURN MESSAGE */
                                );
    
    
      /* 공통코드그룹 정보 조회 */
      PROCEDURE GET_COMMGRP ( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              A_SYSCODE        IN      VARCHAR2,
                              A_DISPFLAG       IN      NUMBER,            /* O = 'Y', ALL */
                              A_VIEW           IN      NUMBER,
                              N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                              V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                              C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                             );
    
    
      /* 공통코드그룹 정보 등록 */
      PROCEDURE PUT_COMMGRP ( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              A_SYSCODE        IN      TM_COMMGRP.SYSCODE%TYPE,
                              A_COMMGRP        IN      TM_COMMGRP.COMMGRP%TYPE,
                              A_GRPNAME        IN      TM_COMMGRP.COMMGRPNAME%TYPE,
                              A_DISPFLAG       IN      TM_COMMGRP.DISPFLAG%TYPE,
                              A_USEFLAG        IN      TM_COMMGRP.USEFLAG%TYPE,
                              A_REMARKS        IN      TM_COMMGRP.REMARKS%TYPE,
                              N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                              V_RETURN        OUT      VARCHAR2           /* RETURN MESSAGE */
                            );
    
    
      /* 공통코드 정보 조회 */
      PROCEDURE GET_COMM ( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                           A_COMMGRP        IN      TM_COMMCODE.COMMGRP%TYPE,
                           A_VIEW           IN      NUMBER,
                           N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                           V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                           C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                          );
    
    
      /* 공통코드 정보 등록 */
      PROCEDURE PUT_COMM ( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                           A_COMMGRP        IN      TM_COMMCODE.COMMGRP%TYPE,
                           A_COMMCODE       IN      TM_COMMCODE.COMMCODE%TYPE,
                           A_COMMNAME       IN      TM_COMMCODE.COMMNAME%TYPE,
                           A_NVALUE         IN      TM_COMMCODE.NVALUE%TYPE,
                           A_CVALUE         IN      TM_COMMCODE.CVALUE%TYPE,
                           A_USEFLAG        IN      TM_COMMCODE.USEFLAG%TYPE,
                           A_REMARKS        IN      TM_COMMCODE.REMARKS%TYPE,
                           A_NEWFLAG        IN      VARCHAR2,
                           N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                           V_RETURN        OUT      VARCHAR2           /* RETURN MESSAGE */
                          );
    
    
       /* 시스템 로그 정보 조회 */
      PROCEDURE GET_LOG( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                         A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                         A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                         A_FROMDATE       IN      VARCHAR2,
                         A_TODATE         IN      VARCHAR2,
                         N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                         V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                         C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                        );
                        
                        
      /* 시스템 로그 정보 등록 */
      PROCEDURE SET_LOG( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                         A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                         A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                         A_PROC           IN      VARCHAR2,
                         A_ERROR          IN      VARCHAR2,
                         A_PARAMS         IN      VARCHAR2
                        );
    
      /* 공지 정보 조회 */
      PROCEDURE GET_NOTICE( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                            A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                            A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                            A_SYSTEM         IN      VARCHAR2,          /* SYSTEM CODE */
                            A_VIEW           IN      NUMBER,            /* 0 : ALL, 1 : USEFLAG = 'Y' */
                            N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                            V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                            C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                           );
    
    
    /* 공지 정보 등록 */
      PROCEDURE PUT_NOTICE( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                            A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                            A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                            A_SYSTEM         IN      VARCHAR2,
                            A_TYPE           IN      TM_NOTICE.TYPE%TYPE,          /* SYSTEM CODE */
                            A_NO             IN      TM_NOTICE.NO%TYPE,
                            A_TITLE          IN      TM_NOTICE.TITLE%TYPE,
                            A_REMARKS        IN      TM_NOTICE.REMARKS%TYPE,
                            A_USEFLAG        IN      TM_NOTICE.USEFLAG%TYPE,
                            A_USER           IN      TM_NOTICE.CREATEUSER%TYPE,
                            N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                            V_RETURN        OUT      VARCHAR2          /* RETURN MESSAGE */
                           );
    
    
      /*오류 로그 정보 조회 */
      PROCEDURE GET_ERROR_LOG( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                               A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                               A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                               N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                               V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                               C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                              );
          
      
      /* 버전 이력 정보 조회 */
      PROCEDURE GET_VERSIONHISTORY( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                    A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                    A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                    A_STARTDATE      IN      VARCHAR2,          
                                    A_ENDDATE        IN      VARCHAR2,          
                                    A_DATETYPE       IN      VARCHAR2,          
                                    A_REQUSTUSER     IN      VARCHAR2,          
                                    A_REQUSTCONTENTS IN      VARCHAR2, 
                                    A_APPLYFLAG      IN      VARCHAR2,
                                    N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                                    V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                                    C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                  );
                                  
                                  
     /* 버전 이력 정보 등록 */  
     PROCEDURE PUT_VERSIONHISTORY( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                   A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                   A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                   A_REQNO          IN      VARCHAR2,
                                   A_REQUSTDATE     IN      VARCHAR2,
                                   A_REQUSTTYPE     IN      VARCHAR2,
                                   A_REQUSTSCREEN   IN      VARCHAR2,
                                   A_REQUSTDEPT     IN      VARCHAR2,
                                   A_REQUSTUSER     IN      VARCHAR2,
                                   A_REQUSTCONTENTS IN      VARCHAR2,
                                   A_APPLYFLAG      IN      VARCHAR2,
                                   A_APPLYDATE      IN      VARCHAR2,
                                   A_APPLYVERSION   IN      VARCHAR2,
                                   A_APPLYUSER      IN      VARCHAR2,
                                   A_APPLYCONTENTS  IN      VARCHAR2,
                                   A_CREATEUSER     IN      VARCHAR2,
                                   A_UPDATEUSER     IN      VARCHAR2,
                                   N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                                   V_RETURN        OUT      VARCHAR2          /* RETURN MESSAGE */
                                  );
                                  
                                  
      /*문서(인증) 만료 일자 초과 원자재  조회 */
      PROCEDURE GET_EXPIRY_MATERIAL( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,   /* 법인 코드 */
                                     A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                     A_PLANT          IN      TM_PLANT.PLANT%TYPE,     /* 공장코드 */
                                     N_RETURN        OUT      NUMBER,                  /* RETURN VALUE */
                                     V_RETURN        OUT      VARCHAR2,                /* RETURN MESSAGE */
                                     C_RETURN        OUT      SYS_REFCURSOR            /* RETURN CURSOR */
                                    ); 
                                    
                                    
      /*JIG 만기 도래 조회 */
      PROCEDURE GET_EXPIRY_JIG( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,   /* 법인 코드 */
                                A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                A_PLANT          IN      TM_PLANT.PLANT%TYPE,     /* 공장코드 */
                                N_RETURN        OUT      NUMBER,                  /* RETURN VALUE */
                                V_RETURN        OUT      VARCHAR2,                /* RETURN MESSAGE */
                                C_RETURN        OUT      SYS_REFCURSOR            /* RETURN CURSOR */
                              );                                                             
    
    END PKGSYS_COMM;
    ```

**참조 테이블:**

`TH_USESYSTEM`, `TH_USESYSTEMLOG`, `TH_VERSIONHISTORY`, `TM_CLIENT`, `TM_COMMCODE`, `TM_COMMGRP`, `TM_COMPANY`, `TM_GLOSSARY`, `TM_ITEMS`, `TM_NOTICE`, `TM_PLANT`, `TM_SERIAL`, `TM_SYSTEM`, `TM_TRANSACTION`, `TM_UNITCODE`, `TW_IQC`, `TW_STOCKSERIAL`

---

### PKGSYS_DBA

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `GET_TABLESPACE_01` | N_RETURN OUT NUMBER, /* RETURN VALUE */ V_RETURN OUT VARCHAR2, /* RETURN MESS... |
| PROC | `GET_TABLESPACE_02` | N_RETURN OUT NUMBER, /* RETURN VALUE */ V_RETURN OUT VARCHAR2, /* RETURN MESS... |
| PROC | `GET_TABLESPACE_03` | N_RETURN OUT NUMBER, /* RETURN VALUE */ V_RETURN OUT VARCHAR2, /* RETURN MESS... |
| PROC | `GET_TABLESPACE_04` | A_SEGMENT IN VARCHAR2, /* 스캔바코드 */ N_RETURN OUT NUMBER, /* RETURN VALUE */ V_... |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         PKGSYS_DBA IS
    
    
        --데이블 스페이스 확인 01
      PROCEDURE GET_TABLESPACE_01(
                                   N_RETURN       OUT  NUMBER,            /* RETURN VALUE */
                                   V_RETURN       OUT  VARCHAR2,          /* RETURN MESSAGE */
                                   C_RETURN       OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                                 );
    
    
        --데이블 스페이스 확인 02
      PROCEDURE GET_TABLESPACE_02(
                                   N_RETURN       OUT  NUMBER,            /* RETURN VALUE */
                                   V_RETURN       OUT  VARCHAR2,          /* RETURN MESSAGE */
                                   C_RETURN       OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                                 );
    
    
        --데이블 스페이스 확인 03
      PROCEDURE GET_TABLESPACE_03(
                                   N_RETURN       OUT  NUMBER,            /* RETURN VALUE */
                                   V_RETURN       OUT  VARCHAR2,          /* RETURN MESSAGE */
                                   C_RETURN       OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                                 );
    
    
        --데이블 스페이스 확인 03
      PROCEDURE GET_TABLESPACE_04(
                                   A_SEGMENT      IN   VARCHAR2,          /* 스캔바코드 */
                                   N_RETURN       OUT  NUMBER,            /* RETURN VALUE */
                                   V_RETURN       OUT  VARCHAR2,          /* RETURN MESSAGE */
                                   C_RETURN       OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                                 );
    
    END PKGSYS_DBA;
    ```

**참조 테이블:**

---

### PKGSYS_MENU

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `GET_FORMMST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_FORMS` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_FORMMST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_MENU` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_MENU` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_MENU` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_MENU` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_MENU` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_MENUROLE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_MENUROLE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_TOUCHMENU` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         PKGSYS_MENU IS
    
    
      /* 폼 마스터 정보 리스트 조회 */
      PROCEDURE GET_FORMMST( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                             A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                             A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */ 
                             A_SYSTEM         IN      TM_FORMS.SYSCODE%TYPE,    /* SYSTEM Code */
                             N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                             V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                             C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                            );
    
    
      /* 폼 마스터 정보 리스트 조회 */
      PROCEDURE GET_FORMS( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                           A_SYSTEM         IN      TM_FORMS.SYSCODE%TYPE,    /* SYSTEM Code */
                           A_VIEW           IN      NUMBER,
                           N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                           V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                           C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                         );
    
      
      /* 폼 마스터 정보 등록 */
      PROCEDURE PUT_FORMMST( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                             A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                             A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                             A_SYSTEM         IN      TM_FORMS.SYSCODE%TYPE,
                             A_FORMCD         IN      TM_FORMS.FORM%TYPE,
                             A_FORMNM         IN      TM_FORMS.FORMNAME%TYPE,
                             A_USEFLAG        IN      TM_FORMS.USEFLAG%TYPE,
                             A_NEWFLAG        IN      VARCHAR2,
                             N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                             V_RETURN        OUT      VARCHAR2           /* RETURN MESSAGE */
                           );
    
    
      /* 메뉴 등록 */
      PROCEDURE PUT_MENU ( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                           A_SYSTEM         IN      TM_MENU.SYSCODE%TYPE,    /* SYSTEM Code */
                           A_PARENTSEQ      IN      TM_MENU.MENUSEQ%TYPE,  /* 부모 순번 */
                           A_MNUNAME        IN      TM_MENU.MENUNAME%TYPE,
                           A_FRMCODE        IN      TM_MENU.FORM%TYPE,
                           A_FRMPARAM       IN      TM_MENU.FORMPARAM%TYPE,
                           A_IMGIDX         IN      TM_MENU.IMGIDX%TYPE,
                           A_DISPIDX        IN      TM_MENU.DISPSEQ%TYPE,
                           A_DISPFLAG       IN      TM_MENU.DISPFLAG%TYPE,
                           A_REMARKS        IN      TM_MENU.REMARKS%TYPE,
                           A_USER           IN      TM_MENU.CREATEUSER%TYPE,
                           N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                           V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                           C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                          );
    
    
      /* 메뉴 수정 */
      PROCEDURE PUT_MENU ( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                           A_SYSTEM         IN      TM_MENU.SYSCODE%TYPE,    /* SYSTEM Code */
                           A_PARENTSEQ      IN      TM_MENU.MENUSEQ%TYPE,  /* 부모 순번 */
                           A_SEQ            IN      TM_MENU.MENUSEQ%TYPE,
                           A_MNUNAME        IN      TM_MENU.MENUNAME%TYPE,
                           A_FRMCODE        IN      TM_MENU.FORM%TYPE,
                           A_FRMPARAM       IN      TM_MENU.FORMPARAM%TYPE,
                           A_IMGIDX         IN      TM_MENU.IMGIDX%TYPE,
                           A_DISPIDX        IN      TM_MENU.DISPSEQ%TYPE,
                           A_DISPFLAG       IN      TM_MENU.DISPFLAG%TYPE,
                           A_REMARKS        IN      TM_MENU.REMARKS%TYPE,
                           A_USEFLAG        IN      TM_MENU.USEFLAG%TYPE,
                           A_USER           IN      TM_MENU.UPDATEUSER%TYPE,
                           N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                           V_RETURN        OUT      VARCHAR2--,          /* RETURN MESSAGE */
                          );
    
    
      /* 메뉴 리스트 전체 조회 */
      PROCEDURE GET_MENU( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                          A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                          A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                          A_SYSTEM         IN      TM_MENU.SYSCODE%TYPE,    /* SYSTEM Code */
                          N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                          V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                          C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                         );
    
    
      /* 사용자 등급별 메뉴 리스트 조회 */
      PROCEDURE GET_MENU( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                          A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                          A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                          A_SYSTEM         IN      TM_MENU.SYSCODE%TYPE,    /* SYSTEM Code */
                          A_USERROLE       IN      TM_USERROLE.USERROLE%TYPE,
                          A_PARENT_NO      IN      TM_MENU.MENUSEQ%TYPE,
                          A_LANG           IN      VARCHAR2,
                          N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                          V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                          C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                         );
                         
    
      /* 사용자 등급별 전체 메뉴 리스트 조회 */
      PROCEDURE GET_MENU( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                          A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                          A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                          A_SYSTEM         IN      TM_MENU.SYSCODE%TYPE,    /* SYSTEM Code */
                          A_USERROLE       IN      TM_USERROLE.USERROLE%TYPE,
                          N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                          V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                          C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                         );
    
                             
      /* 사용자 등급별 전체 메뉴 리스트 조회
         -. 권한별 메뉴마스터, 즐겨찾기*/
      PROCEDURE GET_MENUROLE( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              A_SYSTEM         IN      TM_USERROLE.SYSCODE%TYPE,    /* SYSTEM Code */
                              A_USERROLE       IN      TM_USERROLE.USERROLE%TYPE,
                              N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                              V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                              C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                             );
    
    
      /* 사용자 등급별 메뉴 리스트 등록 */
      PROCEDURE PUT_MENUROLE( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                              A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                              A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                              A_SYSTEM         IN      TM_USERROLE.SYSCODE%TYPE,    /* SYSTEM Code */
                              A_USERROLE       IN      TM_USERROLE.USERROLE%TYPE,
                              A_MENUSEQ        IN      VARCHAR2,          /* MENU SEQUENCE : 20,23,30,31... */
                              A_FORMROLE       IN      VARCHAR2,
                              A_OPERATOR       IN      VARCHAR2,
                              N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                              V_RETURN        OUT      VARCHAR2 --,          /* RETURN MESSAGE */
                             );
    
      /* 터치 메뉴 리스트 */
      PROCEDURE GET_TOUCHMENU( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                               A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                               A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                               A_SYSTEM         IN      TM_MENU.SYSCODE%TYPE,    /* SYSTEM Code */
                               N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                               V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                               C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                              );
    
    
    
    
    END PKGSYS_MENU;
    ```

**참조 테이블:**

`TM_CLIENT`, `TM_COMPANY`, `TM_FORMS`, `TM_GLOSSARY`, `TM_MENU`, `TM_MENUROLE`, `TM_PLANT`, `TM_USERROLE`

---

### PKGSYS_USER

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `CHK_USER` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, A_COMPANY IN TM_COMPANY.COMPANY%TYPE, A_PL... |
| PROC | `GET_DEPT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_DEPT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_DEPT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_POST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_POST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_EHR` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_EHR` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_DEFAULTPWD` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_REGUSER` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_REGUSER` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_ROLE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_ROLE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_FAVRT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_FAVRT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| FUNC | `FUN_ROLE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, A_COMPANY IN TM_COMPAN... → TM_USERROLE |
| FUNC | `FUN_USERNAME` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, A_COMPANY IN TM_COMPAN... → TM_EHR |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         PKGSYS_USER IS
    
      /* 사용자 등급 반환*/
      FUNCTION FUN_ROLE ( A_CLIENT      IN      TM_CLIENT.CLIENT%TYPE,
                          A_COMPANY     IN      TM_COMPANY.COMPANY%TYPE,
                          A_PLANT       IN      TM_PLANT.PLANT%TYPE,
                          A_SYSTEM      IN      TM_USERROLE.SYSCODE%TYPE,    /* SYSTEM Code */
                          A_USERID      IN      TM_USER.USERID%TYPE )
        RETURN TM_USERROLE.USERROLE%TYPE ;
    
    
      /* 사용자 정보 조회 */
      FUNCTION FUN_USERNAME( A_CLIENT      IN       TM_CLIENT.CLIENT%TYPE,
                             A_COMPANY     IN       TM_COMPANY.COMPANY%TYPE,
                             A_PLANT       IN       TM_PLANT.PLANT%TYPE,
                             A_USER_ID     IN       TM_USER.USERID%TYPE )
               RETURN TM_EHR.LOCUSERNAME%TYPE ;
    
               
      /* 시스템 로그인 */
      PROCEDURE CHK_USER( A_CLIENT          IN       TM_CLIENT.CLIENT%TYPE,
                          A_COMPANY         IN       TM_COMPANY.COMPANY%TYPE,
                          A_PLANT           IN       TM_PLANT.PLANT%TYPE,
                          A_SYSTEM          IN       TM_SYSUSERROLE.SYSCODE%TYPE,    /* SYSTEM Code */
                          A_USER_ID         IN       TM_USER.USERID%TYPE,
                          N_RETURN         OUT       NUMBER,            /* RETURN VALUE */
                          V_RETURN         OUT       VARCHAR2,          /* RETURN MESSAGE */
                          C_RETURN         OUT       SYS_REFCURSOR      /* RETURN CURSOR */
                         );
    
    
      /* 부서 리스트 */
      PROCEDURE GET_DEPT( A_CLIENT       IN     TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                          A_COMPANY      IN     TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                          A_PLANT        IN     TM_PLANT.PLANT%TYPE, /* 공장코드 */
                          N_RETURN      OUT  NUMBER,            /* RETURN VALUE */
                          V_RETURN      OUT  VARCHAR2,          /* RETURN MESSAGE */
                          C_RETURN      OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                          );
    
      /* 부서 리스트 */
      PROCEDURE GET_DEPT( A_CLIENT       IN     TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                          A_COMPANY      IN     TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                          A_PLANT        IN     TM_PLANT.PLANT%TYPE, /* 공장코드 */
                          A_VIEW         IN  NUMBER,
                          N_RETURN      OUT  NUMBER,            /* RETURN VALUE */
                          V_RETURN      OUT  VARCHAR2,          /* RETURN MESSAGE */
                          C_RETURN      OUT  SYS_REFCURSOR      /* RETURN CURSOR */
                          );
    
    
      /* 부서 마스터 */
      PROCEDURE PUT_DEPT ( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                           A_DEPT           IN      TM_DEPARTMENT.DEPARTMENT%TYPE,
                           A_DEPTNAME       IN      TM_DEPARTMENT.DEPARTMENTNAME%TYPE,
                           A_USEFLAG        IN      TM_DEPARTMENT.USEFLAG%TYPE,
                           A_EHRCODE        IN      TM_DEPARTMENT.CREATEUSER%TYPE,
                           A_NEWFLAG        IN      VARCHAR2,
                           N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                           V_RETURN        OUT      VARCHAR2           /* RETURN MESSAGE */
                         );
    
    
      /* 직위 리스트 */
      PROCEDURE GET_POST( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                          A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                          A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                          N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                          V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                          C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                          );
    
    
      /* 직위  마스터 */
      PROCEDURE PUT_POST ( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                           A_POST           IN      TM_POSITION.POSITION%TYPE,
                           A_POSTNAME       IN      TM_POSITION.POSITIONNAME%TYPE,
                           A_USEFLAG        IN      TM_POSITION.USEFLAG%TYPE,
                           A_NEWFLAG        IN      VARCHAR2,
                           N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                           V_RETURN        OUT      VARCHAR2           /* RETURN MESSAGE */
                         );
    
    
      /* 인사정보 */
      PROCEDURE GET_EHR( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                         A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                         A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                         A_SYSTEM         IN      TM_SYSTEM.SYSCODE%TYPE,
                         A_NAMELOC        IN      TM_EHR.LOCUSERNAME%TYPE,
                         A_VIEW           IN      NUMBER,            /* VIEW MODE : 0 = USEYN, 1 = All */
                         N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                         V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                         C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                        );
    
    
      /* 인사 정보 등록 */
      PROCEDURE PUT_EHR( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                         A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                         A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                         A_SYSTEM         IN      TM_SYSTEM.SYSCODE%TYPE,
                         A_EHR            IN      TM_EHR.EHRCODE%TYPE,
                         A_USERID         IN      TM_USER.USERID%TYPE,
                         A_ENG_NM         IN      TM_EHR.ENGUSERNAME%TYPE,
                         A_LOC_NM         IN      TM_EHR.LOCUSERNAME%TYPE,
                         A_CLASS          IN      TM_USERROLE.USERROLE%TYPE,
                         A_DEPT           IN      TM_EHR.DEPARTMENT%TYPE,
                         A_POS            IN      TM_EHR.POSITION%TYPE,
                         A_PHONE          IN      TM_EHR.PHONE%TYPE,
                         A_EMAIL          IN      TM_EHR.EMAIL%TYPE,
                         A_HIRE_DT        IN      TM_EHR.HIREDATE%TYPE,
                         A_QUIT_DT        IN      TM_EHR.QUITDATE%TYPE,
                         A_REMARKS        IN      TM_EHR.REMARKS%TYPE,
                         A_USEFLAG        IN      TM_EHR.USEFLAG%TYPE,
                         A_EDT_USER       IN      TM_EHR.CREATEUSER%TYPE,
                         A_NEWFLAG        IN      VARCHAR2,
                         N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                         V_RETURN        OUT      VARCHAR2           /* RETURN MESSAGE */
                        );
    
    
      /* 패스워드 초기화 */
      PROCEDURE PUT_DEFAULTPWD( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                A_USERID         IN      TM_USER.USERID%TYPE,
                                A_PWD            IN      TM_USER.PASSWORD%TYPE,
                                A_EDTUSER        IN      TM_USER.USERID%TYPE,
                                N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                                V_RETURN        OUT      VARCHAR2           /* RETURN MESSAGE */
                              );
    
    
      /* 시스템 사용자 정보 수정 */
      PROCEDURE GET_REGUSER( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                             A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                             A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                             A_SYSTEM         IN      TM_SYSUSERROLE.SYSCODE%TYPE,    /* SYSTEM Code */
                             A_EHR            IN      TM_USER.EHRCODE%TYPE,
                             N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                             V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                             C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                            );
    
    
      /* 시스템 사용자 정보 수정 */
      PROCEDURE PUT_REGUSER( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                             A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                             A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                             A_USERID         IN      TM_USER.USERID%TYPE,
                             A_PWD            IN      TM_USER.PASSWORD%TYPE,
                             A_EHRCODE        IN      TM_EHR.EHRCODE%TYPE,
                             A_PHONE          IN      TM_EHR.PHONE%TYPE,
                             A_EMAIL          IN      TM_EHR.EMAIL%TYPE,
                             A_DEPT           IN      TM_EHR.DEPARTMENT%TYPE,
                             A_POST           IN      TM_EHR.POSITION%TYPE,
                             A_REMARKS        IN      TM_EHR.REMARKS%TYPE,
                             N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                             V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                             C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                            );
    
    
      /* 사용자 등급 리스트 */
      PROCEDURE GET_ROLE( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                          A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                          A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                          A_SYSTEM         IN      TM_USERROLE.SYSCODE%TYPE,    /* SYSTEM Code */
                          A_VIEW           IN      NUMBER,            /* VIEW MODE : 0 = USEYN, 1 = All */
                          N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                          V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                          C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                        );
    
    
      /* 사용자 등급 등록 */
      PROCEDURE PUT_ROLE( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                          A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                          A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */ 
                          A_SYSCODE        IN      TM_USERROLE.SYSCODE%TYPE,    /* SYSTEM Code */
                          A_CLASSCD        IN      TM_USERROLE.USERROLE%TYPE,
                          A_CLASSNM        IN      TM_USERROLE.USERROLENAME%TYPE,
                          A_ALERTFLAG      IN      TM_USERROLE.ALERTFLAG%TYPE,
                          A_UPDATEFLAG     IN      TM_USERROLE.UPDATEFLAG%TYPE,
                          A_USEFLAG        IN      TM_USERROLE.USEFLAG%TYPE,
                          A_REMARKS        IN      TM_USERROLE.REMARKS%TYPE,
                          A_EHRCODE        IN      TM_USERROLE.CREATEUSER%TYPE,
                          A_NEWFLAG        IN      VARCHAR2,
                          N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                          V_RETURN        OUT      VARCHAR2           /* RETURN MESSAGE */
                         );
    
    
      /* View User Favorites */
      PROCEDURE GET_FAVRT( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */ 
                           A_SYSTEM         IN      TM_FAVORITE.SYSCODE%TYPE,    /* SYSTEM Code */
                           A_USERID         IN      TM_FAVORITE.USERID%TYPE,
                           N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                           V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                           C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                          );
                          
    
      /* Edit User Favorites */
      PROCEDURE PUT_FAVRT( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                           A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                           A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                           A_SYSTEM         IN      TM_FAVORITE.SYSCODE%TYPE,    /* SYSTEM Code */
                           A_USERID         IN      TM_FAVORITE.USERID%TYPE,
                           A_MENUSEQ        IN      TM_FAVORITE.MENUSEQ%TYPE,
                           A_DISPSEQ        IN      TM_FAVORITE.DISPSEQ%TYPE,
                           N_RETURN        OUT      NUMBER,            /* RETURN VALUE */
                           V_RETURN        OUT      VARCHAR2,          /* RETURN MESSAGE */
                           C_RETURN        OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                          );
    
    END PKGSYS_USER;
    ```

**참조 테이블:**

`TM_CLIENT`, `TM_COMPANY`, `TM_DEPARTMENT`, `TM_EHR`, `TM_FAVORITE`, `TM_MENU`, `TM_MENUROLE`, `TM_PLANT`, `TM_POSITION`, `TM_SYSTEM`, `TM_SYSUSERROLE`, `TM_USER`, `TM_USERROLE`

---

### PKGTXN_GATHERING

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `GET_LINE_BY_INSP` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_UNIT_BY_LINE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_PATHSETTING` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_CRIMP_INSP_DATA` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_CRIMP_INSP_HIST` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         PKGTXN_GATHERING IS
    
      /* 압착검사 호기 정보 조회 */
      PROCEDURE GET_LINE_BY_INSP( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_OPERTYPE     IN      TM_PRODLINE.TYPE%TYPE,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                );
                                
    
      /* 압착검사 호기 정보 조회 */
      PROCEDURE GET_UNIT_BY_LINE( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_PRODLINE     IN      TM_PRODLINE.PRODLINE%TYPE,
                                  A_OPERTYPE     IN      TM_PRODLINE.TYPE%TYPE,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                ); 
                                
    
      /* 압착검사 결과 경로 저장 */
      PROCEDURE PUT_PATHSETTING( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                 A_XML          IN      CLOB,
                                 N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                 V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                 C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                               );  
                               
                               
      /* 압착검사 결과 이력 저장 */
      PROCEDURE PUT_CRIMP_INSP_DATA( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                     A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                     A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                     A_EQP          IN      TM_PRODLINE_UNIT.UNITNO%TYPE,
                                     A_XML          IN      CLOB,
                                     N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                     V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                     C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                   );
                                   
                                   
      /* 압착검사 결과 이력 조회 */
      PROCEDURE GET_CRIMP_INSP_HIST( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                     A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                     A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                     A_SDATE        IN      TH_CRIMPINSP.TXNDATE%TYPE,
                                     A_EDATE        IN      TH_CRIMPINSP.TXNDATE%TYPE,
                                     N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                     V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                     C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                   ); 
                                   
    
    END PKGTXN_GATHERING;
    ```

**참조 테이블:**

`TH_CRIMPINSP`, `TM_CLIENT`, `TM_COMPANY`, `TM_PLANT`, `TM_PRODLINE`, `TM_PRODLINE_UNIT`

---

### PKGTXN_MODBUS

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `GET_LINE_BY_OPER` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_MODBUS_INTERFACE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         PKGTXN_MODBUS IS
    
      /* 배판 호기 정보 조회 */
      PROCEDURE GET_LINE_BY_OPER( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_OPER         IN      TM_OPERATION.OPER%TYPE,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                );
                                
                                
      /* MODBUS 프로토콜 인터페이스 */
      PROCEDURE SET_MODBUS_INTERFACE( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                      A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                      A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                      A_PROCESS      IN      VARCHAR2,
                                      A_UNITNO       IN      TM_PRODLINE_UNIT.UNITNO%TYPE,
                                      A_PRODQTY      IN      TW_PRODHIST.PRODQTY%TYPE,
                                      A_IP           IN      VARCHAR2,
                                      N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                      V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                      C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                    );                            
                                
    
    END PKGTXN_MODBUS;
    ```

**참조 테이블:**

`TH_MODBUS_IF`, `TH_WORKORD`, `TM_CLIENT`, `TM_COMPANY`, `TM_ITEMS`, `TM_OPERATION`, `TM_PLANT`, `TM_PRODLINE`, `TM_PRODLINE_UNIT`, `TW_PRODHIST`, `TW_WORKORD`

---

### PKGTXN_STOCK

| 유형 | 이름 | 파라미터 |
|------|------|----------|
| PROC | `PUT_IN` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_IN` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_IN_CANCEL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_IN_CANCEL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_OUT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_OUT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_OUT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_OUT_CANCEL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_OUT_CANCEL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_ACTUALSTOCK` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_ACTUALSTOCK_M_OUT` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_ACTUALSTOCK_M_IN` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `GET_ACTUAL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_ACTUAL_ALTER` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_ACTUAL_DELETE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_ACTUAL_DELETE_ALL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `PUT_ACTUAL_UPLOAD` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| PROC | `SET_ACTUAL_APPLY` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY IN TM_COMPANY.COMPAN... |
| FUNC | `FUN_SERIAL` | A_TYPE IN NUMBER /* 1 = Current Serial, 2 = Next Serial */ → NUMBER |
| FUNC | `FUN_TRANSLATE` | A_DATA IN VARCHAR2, A_SEP IN CHAR → NUMBER |

??? note "패키지 스펙 소스코드"
    ```sql
    PACKAGE         PKGTXN_STOCK IS
    
      -- Author  : SEOB2
      -- Created : 2011-07-26 ¿¿ 3:27:58
      -- Purpose : IDAT MES Transaction Stock Package
    
    
      /* SERIAL ¿¿
       */
      FUNCTION FUN_SERIAL ( A_TYPE        IN  NUMBER /* 1 = Current Serial, 2 = Next Serial */
                           )
          RETURN NUMBER ;
    
    
      FUNCTION FUN_TRANSLATE ( A_DATA        IN  VARCHAR2,
                               A_SEP         IN  CHAR
                              )
          RETURN NUMBER ;
    
    
      /* 입고 T10X, T201, T30X, T40X, T90X */
      PROCEDURE PUT_IN( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                        A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                        A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                        A_TXNTIMEKEY   IN      TW_IN.TXNTIMEKEY%TYPE,
                        A_TXNCODE      IN      TW_IN.TXNCODE%TYPE,
                        A_WHLOC        IN      TW_IN.WHLOC%TYPE,
                        A_ITEMCODE     IN      TW_IN.ITEMCODE%TYPE,
                        A_INQTY        IN      TW_IN.INQTY%TYPE,
                        A_STOCKTYPE    IN      TW_IN.STOCKTYPE%TYPE,
                        A_SERIAL       IN      TW_IN.SERIAL%TYPE,
                        A_ORDERNO      IN      TW_IN.ORDERNO%TYPE,
                        A_INVOICENO    IN      TW_IN.INVOICENO%TYPE,
                        A_VENDOR       IN      TW_IN.VENDOR%TYPE,
                        A_WRKORD       IN      TW_IN.WRKORD%TYPE,
                        A_PRODLINE     IN      TW_IN.PRODLINE%TYPE,
                        A_OPER         IN      TW_IN.OPER%TYPE,
                        A_SIDE         IN      TW_IN.SIDE%TYPE,
                        A_CREATEUSER   IN      TW_IN.CREATEUSER%TYPE
                      );
    
    
      /* BOX 입고 T10X, T201, T30X, T40X, T90X */
      PROCEDURE PUT_IN( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                        A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                        A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                        A_TXNTIMEKEY   IN      TW_IN.TXNTIMEKEY%TYPE,
                        A_TXNCODE      IN      TW_IN.TXNCODE%TYPE,
                        A_WHLOC        IN      TW_IN.WHLOC%TYPE,
                        A_ITEMCODE     IN      TW_IN.ITEMCODE%TYPE,
                        A_INQTY        IN      TW_IN.INQTY%TYPE,
                        A_STOCKTYPE    IN      TW_IN.STOCKTYPE%TYPE,
                        A_SERIAL       IN      TW_IN.SERIAL%TYPE,
                        A_ORDERNO      IN      TW_IN.ORDERNO%TYPE,
                        A_INVOICENO    IN      TW_IN.INVOICENO%TYPE,
                        A_VENDOR       IN      TW_IN.VENDOR%TYPE,
                        A_WRKORD       IN      TW_IN.WRKORD%TYPE,
                        A_PRODLINE     IN      TW_IN.PRODLINE%TYPE,
                        A_OPER         IN      TW_IN.OPER%TYPE,
                        A_SIDE         IN      TW_IN.SIDE%TYPE,
                        A_BOXNO        IN      TW_IN.BOXNO%TYPE,
                        A_CREATEUSER   IN      TW_IN.CREATEUSER%TYPE
                      );
                      
    
      /* 입고취소 U10X, U201, U30X, U40X, U90X */
      PROCEDURE PUT_IN_CANCEL( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                               A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                               A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */ 
                               A_TXNTIMEKEY   IN      TW_IN.TXNTIMEKEY%TYPE,
                               A_TXNCODE      IN      TW_IN.TXNCODE%TYPE,
                               A_WHLOC        IN      TW_IN.WHLOC%TYPE,
                               A_ITEMCODE     IN      TW_IN.ITEMCODE%TYPE,
                               A_INQTY        IN      TW_IN.INQTY%TYPE,
                               A_STOCKTYPE    IN      TW_IN.STOCKTYPE%TYPE,
                               A_SERIAL       IN      TW_IN.SERIAL%TYPE,
                               A_ORDERNO      IN      TW_IN.ORDERNO%TYPE,
                               A_INVOICENO    IN      TW_IN.INVOICENO%TYPE,
                               A_VENDOR       IN      TW_IN.VENDOR%TYPE,
                               A_WRKORD       IN      TW_IN.WRKORD%TYPE,
                               A_PRODLINE     IN      TW_IN.PRODLINE%TYPE,
                               A_OPER         IN      TW_IN.OPER%TYPE,
                               A_SIDE         IN      TW_IN.SIDE%TYPE,
                               A_CREATEUSER   IN      TW_IN.CREATEUSER%TYPE
                             );
                                                   
    
      /* BOX 입고취소 U10X, U201, U30X, U40X, U90X */
      PROCEDURE PUT_IN_CANCEL( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                               A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                               A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */ 
                               A_TXNTIMEKEY   IN      TW_IN.TXNTIMEKEY%TYPE,
                               A_TXNCODE      IN      TW_IN.TXNCODE%TYPE,
                               A_WHLOC        IN      TW_IN.WHLOC%TYPE,
                               A_ITEMCODE     IN      TW_IN.ITEMCODE%TYPE,
                               A_INQTY        IN      TW_IN.INQTY%TYPE,
                               A_STOCKTYPE    IN      TW_IN.STOCKTYPE%TYPE,
                               A_SERIAL       IN      TW_IN.SERIAL%TYPE,
                               A_ORDERNO      IN      TW_IN.ORDERNO%TYPE,
                               A_INVOICENO    IN      TW_IN.INVOICENO%TYPE,
                               A_VENDOR       IN      TW_IN.VENDOR%TYPE,
                               A_WRKORD       IN      TW_IN.WRKORD%TYPE,
                               A_PRODLINE     IN      TW_IN.PRODLINE%TYPE,
                               A_OPER         IN      TW_IN.OPER%TYPE,
                               A_SIDE         IN      TW_IN.SIDE%TYPE,
                               A_BOXNO        IN      TW_IN.BOXNO%TYPE,
                               A_CREATEUSER   IN      TW_IN.CREATEUSER%TYPE
                             );
                             
                             
      /* 출고 T10X, T201, T30X, T40X, T90X */
      PROCEDURE PUT_OUT( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                         A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                         A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */ 
                         A_TXNTIMEKEY   IN      TW_OUT.TXNTIMEKEY%TYPE,
                         A_TXNCODE      IN      TW_OUT.TXNCODE%TYPE,
                         A_WHLOC        IN      TW_OUT.WHLOC%TYPE,
                         A_ITEMCODE     IN      TW_OUT.ITEMCODE%TYPE,
                         A_OUTQTY       IN      TW_OUT.OUTQTY%TYPE,
                         A_STOCKTYPE    IN      TW_OUT.STOCKTYPE%TYPE,
                         A_SERIAL       IN      TW_OUT.SERIAL%TYPE,
                         A_ORDERNO      IN      TW_OUT.ORDERNO%TYPE,
                         A_INVOICENO    IN      TW_OUT.INVOICENO%TYPE,
                         A_VENDOR       IN      TW_OUT.VENDOR%TYPE,
                         A_WRKORD       IN      TW_OUT.WRKORD%TYPE,
                         A_CREATEUSER   IN      TW_OUT.CREATEUSER%TYPE
                       );
    
    
      /* 출고 T10X, T201, T30X, T40X, T90X */
      PROCEDURE PUT_OUT( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                         A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                         A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */ 
                         A_TXNTIMEKEY   IN      TW_OUT.TXNTIMEKEY%TYPE,
                         A_TXNCODE      IN      TW_OUT.TXNCODE%TYPE,
                         A_WHLOC        IN      TW_OUT.WHLOC%TYPE,
                         A_ITEMCODE     IN      TW_OUT.ITEMCODE%TYPE,
                         A_OUTQTY       IN      TW_OUT.OUTQTY%TYPE,
                         A_STOCKTYPE    IN      TW_OUT.STOCKTYPE%TYPE,
                         A_SERIAL       IN      TW_OUT.SERIAL%TYPE,
                         A_ORDERNO      IN      TW_OUT.ORDERNO%TYPE,
                         A_INVOICENO    IN      TW_OUT.INVOICENO%TYPE,
                         A_VENDOR       IN      TW_OUT.VENDOR%TYPE,
                         A_WRKORD       IN      TW_OUT.WRKORD%TYPE,
                         A_PRODLINE     IN      TW_OUT.PRODLINE%TYPE,
                         A_OPER         IN      TW_OUT.OPER%TYPE,
                         A_SIDE         IN      TW_OUT.SIDE%TYPE,
                         A_CREATEUSER   IN      TW_OUT.CREATEUSER%TYPE
                       );
                       
    
      /* BOX 출고 T10X, T201, T30X, T40X, T90X */
      PROCEDURE PUT_OUT( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                         A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                         A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */ 
                         A_TXNTIMEKEY   IN      TW_OUT.TXNTIMEKEY%TYPE,
                         A_TXNCODE      IN      TW_OUT.TXNCODE%TYPE,
                         A_WHLOC        IN      TW_OUT.WHLOC%TYPE,
                         A_ITEMCODE     IN      TW_OUT.ITEMCODE%TYPE,
                         A_OUTQTY       IN      TW_OUT.OUTQTY%TYPE,
                         A_STOCKTYPE    IN      TW_OUT.STOCKTYPE%TYPE,
                         A_SERIAL       IN      TW_OUT.SERIAL%TYPE,
                         A_ORDERNO      IN      TW_OUT.ORDERNO%TYPE,
                         A_INVOICENO    IN      TW_OUT.INVOICENO%TYPE,
                         A_VENDOR       IN      TW_OUT.VENDOR%TYPE,
                         A_WRKORD       IN      TW_OUT.WRKORD%TYPE,
                         A_PRODLINE     IN      TW_OUT.PRODLINE%TYPE,
                         A_OPER         IN      TW_OUT.OPER%TYPE,
                         A_SIDE         IN      TW_OUT.SIDE%TYPE,
                         A_BOXNO        IN      TW_OUT.BOXNO%TYPE,
                         A_CREATEUSER   IN      TW_OUT.CREATEUSER%TYPE
                       );
                       
    
      /* 출고취소 U10X, U201, U30X, U40X, U90X */
      PROCEDURE PUT_OUT_CANCEL( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */ 
                                A_TXNTIMEKEY   IN      TW_OUT.TXNTIMEKEY%TYPE,
                                A_TXNCODE      IN      TW_OUT.TXNCODE%TYPE,
                                A_WHLOC        IN      TW_OUT.WHLOC%TYPE,
                                A_ITEMCODE     IN      TW_OUT.ITEMCODE%TYPE,
                                A_OUTQTY       IN      TW_OUT.OUTQTY%TYPE,
                                A_STOCKTYPE    IN      TW_OUT.STOCKTYPE%TYPE,
                                A_SERIAL       IN      TW_OUT.SERIAL%TYPE,
                                A_ORDERNO      IN      TW_OUT.ORDERNO%TYPE,
                                A_INVOICENO    IN      TW_OUT.INVOICENO%TYPE,
                                A_VENDOR       IN      TW_OUT.VENDOR%TYPE,
                                A_WRKORD       IN      TW_OUT.WRKORD%TYPE,
                                A_PRODLINE     IN      TW_OUT.PRODLINE%TYPE,
                                A_OPER         IN      TW_OUT.OPER%TYPE,
                                A_SIDE         IN      TW_OUT.SIDE%TYPE,
                                A_CREATEUSER   IN      TW_OUT.CREATEUSER%TYPE
                              );
                              
    
      /* 출고취소 U10X, U201, U30X, U40X, U90X */
      PROCEDURE PUT_OUT_CANCEL( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */ 
                                A_TXNTIMEKEY   IN      TW_OUT.TXNTIMEKEY%TYPE,
                                A_TXNCODE      IN      TW_OUT.TXNCODE%TYPE,
                                A_WHLOC        IN      TW_OUT.WHLOC%TYPE,
                                A_ITEMCODE     IN      TW_OUT.ITEMCODE%TYPE,
                                A_OUTQTY       IN      TW_OUT.OUTQTY%TYPE,
                                A_STOCKTYPE    IN      TW_OUT.STOCKTYPE%TYPE,
                                A_SERIAL       IN      TW_OUT.SERIAL%TYPE,
                                A_ORDERNO      IN      TW_OUT.ORDERNO%TYPE,
                                A_INVOICENO    IN      TW_OUT.INVOICENO%TYPE,
                                A_VENDOR       IN      TW_OUT.VENDOR%TYPE,
                                A_WRKORD       IN      TW_OUT.WRKORD%TYPE,
                                A_PRODLINE     IN      TW_OUT.PRODLINE%TYPE,
                                A_OPER         IN      TW_OUT.OPER%TYPE,
                                A_SIDE         IN      TW_OUT.SIDE%TYPE,
                                A_BOXNO        IN      TW_OUT.BOXNO%TYPE,
                                A_CREATEUSER   IN      TW_OUT.CREATEUSER%TYPE
                              );
                              
    
      /*재고 실사 정보 등록*/
      PROCEDURE PUT_ACTUALSTOCK( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                 A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                 A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */ 
                                 A_ACTUALMON    IN      VARCHAR2,
                                 A_WHLOC        IN      VARCHAR2,
                                 A_ITEMTYPE     IN      VARCHAR2,
                                 A_USER         IN      VARCHAR2,
                                 N_RETURN      OUT      NUMBER,
                                 V_RETURN      OUT      VARCHAR2
                               );
    
    
      /*재고 실사 출고*/
      PROCEDURE PUT_ACTUALSTOCK_M_OUT( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                       A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                       A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */ 
                                       A_ACTUALMON    IN      VARCHAR2,
                                       A_WHLOC        IN      VARCHAR2,
                                       A_USER         IN      VARCHAR2
                                     );
    
    
      /*재고 실사 입고*/
      PROCEDURE PUT_ACTUALSTOCK_M_IN( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                      A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                      A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */ 
                                      A_ACTUALMON    IN      VARCHAR2,
                                      A_WHLOC        IN      VARCHAR2,
                                      A_USER         IN      VARCHAR2
                                    );
                                    
                                    
      /*실사 정보 조회*/
      PROCEDURE GET_ACTUAL( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                            A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                            A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                            A_ACTUALMON    IN      TW_ACTUALSTOCK.ACTUALMON%TYPE,
                            A_WHLOC        IN      TW_ACTUALSTOCK.WHLOC%TYPE,
                            A_ITEMCODE     IN      TM_ITEMS.ITEMCODE%TYPE,
                            N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                            V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                            C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                          );    
                          
                          
      /* 재고 실사 수정 */
      PROCEDURE SET_ACTUAL_ALTER( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_ACTUALMONTH  IN      TW_ACTUALSTOCK.ACTUALMON%TYPE,
                                  A_WHLOC        IN      TW_ACTUALSTOCK.WHLOC%TYPE,
                                  A_SERIAL       IN      TW_ACTUALSTOCK.SERIAL%TYPE,
                                  A_ITEMCODE     IN      TW_ACTUALSTOCK.ITEMCODE%TYPE,
                                  A_STOCKTYPE    IN      TW_ACTUALSTOCK.STOCKTYPE%TYPE,
                                  A_ACTUALQTY    IN      TW_ACTUALSTOCK.ACTUALQTY%TYPE,
                                  A_USER         IN      VARCHAR2,          
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                ); 
                                
                                
      /* 재고 실사 삭제(개별) */
      PROCEDURE SET_ACTUAL_DELETE( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                   A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                   A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                   A_ACTUALMONTH  IN      TW_ACTUALSTOCK.ACTUALMON%TYPE,
                                   A_WHLOC        IN      TW_ACTUALSTOCK.WHLOC%TYPE,
                                   A_SERIAL       IN      TW_ACTUALSTOCK.SERIAL%TYPE,
                                   A_ITEMCODE     IN      TW_ACTUALSTOCK.ITEMCODE%TYPE,
                                   A_STOCKTYPE    IN      TW_ACTUALSTOCK.STOCKTYPE%TYPE,
                                   A_ACTUALQTY    IN      TW_ACTUALSTOCK.ACTUALQTY%TYPE,
                                   A_USER         IN      VARCHAR2,          
                                   N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                   V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                   C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                 );                             
                                
      
      /* 재고 실사 삭제(전체) */
      PROCEDURE SET_ACTUAL_DELETE_ALL( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                       A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                       A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                       A_ACTUALMONTH  IN      TW_ACTUALSTOCK.ACTUALMON%TYPE,
                                       A_WHLOC        IN      TW_ACTUALSTOCK.WHLOC%TYPE,
                                       A_USER         IN      VARCHAR2,          
                                       N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                       V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                       C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                     );  
                                
      
      /* 재고 실사 EXCEL UPLOAD */
      PROCEDURE PUT_ACTUAL_UPLOAD( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                   A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                   A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                   A_ACTUALMON    IN      TW_ACTUALSTOCK.ACTUALMON%TYPE,
                                   A_WHLOC        IN      TW_ACTUALSTOCK.WHLOC%TYPE,
                                   A_XML          IN      CLOB,
                                   A_USER         IN      VARCHAR2,          
                                   N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                   V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                   C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                 ); 
                                 
                                 
      /*재고 실사 반영*/  
      PROCEDURE SET_ACTUAL_APPLY( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                  A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                  A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                  A_ACTUALMON    IN      TW_ACTUALSTOCK.ACTUALMON%TYPE,
                                  A_WHLOC        IN      TW_ACTUALSTOCK.WHLOC%TYPE,
                                  A_USER         IN      TW_ACTUALSTOCK.CREATEUSER%TYPE,
                                  N_RETURN      OUT      NUMBER,            /* RETURN VALUE */
                                  V_RETURN      OUT      VARCHAR2,          /* RETURN MESSAGE */
                                  C_RETURN      OUT      SYS_REFCURSOR      /* RETURN CURSOR */
                                );                                                                                                    
                                    
                          
    
    END PKGTXN_STOCK;
    ```

**참조 테이블:**

`TM_BOX`, `TM_CLIENT`, `TM_COMPANY`, `TM_ITEMS`, `TM_LOCATION`, `TM_PLANT`, `TM_SERIAL`, `TM_WAREHOUSE`, `TW_ACTUALSTOCK`, `TW_IN`, `TW_OUT`, `TW_STOCKSERIAL`

---

## 독립 함수

| 함수명 | 파라미터 | 반환타입 |
|--------|----------|----------|
| `FUN_CHECK_BOM_01` | arg_itemcode IN VARCHAR2, arg_ymd IN VARCHAR2, arg_gubun ... | VARCHAR2 |
| `FUN_COMMCODE` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY ... | VARCHAR2 |
| `FUN_CREATE_APPLICATOR` | - | - |
| `FUN_CREATE_ASSYSERIALNO` | ARG_ITEMCODE IN TM_ITEMS.ITEMCODE%TYPE | VARCHAR2 |
| `FUN_CREATE_BOXNO` | - | - |
| `FUN_CREATE_BUNDLENO` | - | - |
| `FUN_CREATE_JIG` | - | - |
| `FUN_CREATE_MFG` | - | - |
| `FUN_CREATE_PRODPROGNO` | - | - |
| `FUN_DATETOSN` | A_DATE VARCHAR2 | VARCHAR2 |
| `FUN_ERPNO` | - | - |
| `FUN_FROMTOLOSSTIME` | A_UNITNO IN TM_PRODLINE_UNIT.UNITNO%TYPE, A_STIME IN VARC... | NUMBER |
| `FUN_GET_BEGIN_STOCK_01` | ARG_CLIENT IN VARCHAR2, ARG_COMPANY IN VARCHAR2, ARG_PLAN... | NUMBER |
| `FUN_GET_CUSTPARTNO` | ARG_CLIENT IN VARCHAR2, ARG_COMPANY IN VARCHAR2, ARG_PLAN... | NUMBER |
| `FUN_GET_MATERIALREQUESTNO` | - | - |
| `FUN_GET_PLANENDTIME` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY ... | VARCHAR2 |
| `FUN_GET_PLANSTARTTIME` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY ... | VARCHAR2 |
| `FUN_GET_PRODLABEL_CNT` | ARG_CLIENT IN VARCHAR2, ARG_COMPANY IN VARCHAR2, ARG_PLAN... | NUMBER |
| `FUN_GET_STOCK_002` | ARG_CLIENT IN VARCHAR2, ARG_COMPANY IN VARCHAR2, ARG_PLAN... | NUMBER |
| `FUN_GET_STOCK_003` | ARG_CLIENT IN VARCHAR2, ARG_COMPANY IN VARCHAR2, ARG_PLAN... | NUMBER |
| `FUN_GET_STOCK_01` | ARG_CLIENT IN VARCHAR2, ARG_COMPANY IN VARCHAR2, ARG_PLAN... | NUMBER |
| `FUN_GET_STOCK_02` | ARG_CLIENT IN VARCHAR2, ARG_COMPANY IN VARCHAR2, ARG_PLAN... | NUMBER |
| `FUN_GET_STOCK_ONBOARD` | ARG_CLIENT IN VARCHAR2, ARG_COMPANY IN VARCHAR2, ARG_PLAN... | NUMBER |
| `FUN_GET_WORKORDNO` | ARG_WORKORDTYPE IN VARCHAR2 | VARCHAR2 |
| `FUN_HOURLOSS` | A_STDTIME IN VARCHAR2 | VARCHAR2 |
| `FUN_LOSSTIME` | A_STTIME IN VARCHAR2, A_ENTIME IN VARCHAR2 | VARCHAR2 |
| `FUN_MOUNT_SERIAL` | A_CLIENT IN TM_CLIENT.CLIENT%TYPE, /* 법인 코드 */ A_COMPANY ... | VARCHAR2 |
| `FUN_NORMDIST` | A_INPUTVAL IN NUMBER, A_MEAN IN NUMBER, A_STDV IN NUMBER | NUMBER |
| `FUN_REQUESTNO` | - | - |
| `FUN_TIMEGAPCAL` | A_ENTIME IN VARCHAR2, A_STTIME IN VARCHAR2 | VARCHAR2 |
| `FUN_TIMEKEY` | - | - |

### FUN_CHECK_BOM_01

??? note "소스코드"
    ```sql
    FUNCTION         FUN_CHECK_BOM_01
    (   arg_itemcode  IN VARCHAR2,
        arg_ymd       IN VARCHAR2,
        arg_gubun     IN VARCHAR2)
    RETURN VARCHAR2
    AS
      
      HOST_YN VARCHAR2(1) := 'Y';
      
    BEGIN
    
         BEGIN
         
            IF ARG_GUBUN = '1' THEN  --  파트넘버에 대한 BOM 유무 체크
               SELECT CASE WHEN COUNT(*) > 0 THEN 'Y' ELSE 'N' END
                 INTO HOST_YN
                 FROM TM_BOM A, ( SELECT MAX(REV) REV
                                    FROM TM_BOM A
                                   WHERE UPRITEM = ARG_ITEMCODE) B
                WHERE A.UPRITEM = ARG_ITEMCODE
                  AND A.STARTDATE <= ARG_YMD
                  AND A.ENDDATE >= ARG_YMD
                  AND A.REV = B.REV ;           
               
            ELSIF ARG_GUBUN = '2' THEN -- 계획  등록 시 압착은 CUSTPARTNO로 등록하기 때문에 CUSTPARTNO에 대한 실제 PARTNO의 BOM 유무 체크
            
               SELECT CASE WHEN COUNT(*) > 0 THEN 'Y' ELSE 'N' END
                 INTO HOST_YN
                 FROM ( SELECT Z.*
                          FROM TM_BOM Z
                         WHERE Z.UPRITEM = ARG_ITEMCODE
                           AND Z.USEFLAG = 'Y'
                           AND TO_CHAR(SYSDATE, 'YYYYMMDD') BETWEEN Z.STARTDATE AND Z.ENDDATE) A, 
                      ( SELECT UPRITEM, TO_CHAR(MAX(TO_NUMBER(REV))) REV
                          FROM TM_BOM A
                         WHERE A.USEFLAG = 'Y'
                           AND TO_CHAR(SYSDATE, 'YYYYMMDD') BETWEEN A.STARTDATE AND A.ENDDATE
                        GROUP BY UPRITEM) B
                WHERE A.STARTDATE <= ARG_YMD
                  AND A.ENDDATE >= ARG_YMD
                  AND A.UPRITEM = B.UPRITEM
                  AND A.REV = B.REV ;    
                  
    --           SELECT CASE WHEN COUNT(*) > 0 THEN 'Y' ELSE 'N' END
    --             INTO HOST_YN
    --             FROM ( SELECT Z.*
    --                      FROM TM_BOM Z
    --                     WHERE Z.UPRITEM = (SELECT NVL(A.ITEMCODE, B.ITEMCODE)
    --                                          FROM TM_ITEMS A, (SELECT CLIENT, COMPANY, PLANT, PARTNO, ITEMCODE
    --                                                              FROM TM_ITEMS 
    --                                                             WHERE ITEMCODE = ARG_ITEMCODE) B
    --                                         WHERE A.PARTNO <> NVL(A.CUSTPARTNO,'X')
    --                                           AND A.CLIENT = B.CLIENT
    --                                           AND A.COMPANY = B.COMPANY
    --                                           AND A.PLANT = B.PLANT
    --                                           AND NVL(A.CUSTPARTNO, A.PARTNO) = B.PARTNO )) A, 
    --                  ( SELECT UPRITEM, MAX(REV) REV
    --                      FROM TM_BOM A
    --                    GROUP BY UPRITEM) B
    --            WHERE A.STARTDATE <= ARG_YMD
    --              AND A.ENDDATE >= ARG_YMD
    --              AND A.UPRITEM = B.UPRITEM
    --              AND A.REV = B.REV ; 
         
             END IF;
                                     
               
         EXCEPTION
            WHEN NO_DATA_FOUND THEN
                 HOST_YN := 'N' ;
         END;                           
    
      
      
      return HOST_YN;
      
    exception
      when others then
         HOST_YN := 'N' ;
      return HOST_YN;
    END;
    ```

### FUN_COMMCODE

??? note "소스코드"
    ```sql
    FUNCTION         FUN_COMMCODE( A_CLIENT         IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                                     A_COMPANY        IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                                     A_PLANT          IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */ 
                                                     A_COMMGRP        IN      TM_COMMCODE.COMMGRP%TYPE,
                                                     A_COMMCODE       IN      TM_COMMCODE.COMMCODE%TYPE 
                                                    )
        RETURN VARCHAR2
    IS
    
      V_RETURN      TM_COMMCODE.COMMNAME%TYPE;
      
    
    BEGIN   
    
      --공통코드 COMMNAME 조회 FUNCTION
      SELECT COMMNAME
        INTO V_RETURN
        FROM TM_COMMCODE
       WHERE CLIENT = A_CLIENT
         AND COMPANY = A_COMPANY
         AND PLANT = A_PLANT
         AND COMMGRP = A_COMMGRP
         AND CVALUE = A_COMMCODE
         AND USEFLAG = 'Y'; 
    
      RETURN V_RETURN;
    
    EXCEPTION
    
        WHEN OTHERS THEN
            RETURN NULL;
    
    END FUN_COMMCODE;
    ```

### FUN_CREATE_APPLICATOR

??? note "소스코드"
    ```sql
    FUNCTION         FUN_CREATE_APPLICATOR
    RETURN VARCHAR2
    IS
    
    V_RTN      VARCHAR2(20);
    V_Y        VARCHAR2(1);
    V_M        VARCHAR2(1);
    V_D        VARCHAR2(1);
    V_SEQ      VARCHAR2(6);
    
    BEGIN
      
      SELECT CVALUE
        INTO  V_Y
        FROM TM_COMMCODE
       WHERE COMMGRP = 'CG005'
         AND COMMNAME = TO_CHAR(SYSDATE,'YYYY');
      
      SELECT CVALUE
        INTO  V_M
        FROM TM_COMMCODE
       WHERE COMMGRP = 'CG006'
         AND COMMNAME = TO_CHAR(SYSDATE,'MM');
      
      SELECT CVALUE 
        INTO  V_D
        FROM TM_COMMCODE
       WHERE COMMGRP = 'CG007'
         AND COMMNAME = TO_CHAR(SYSDATE,'DD');
    
      SELECT LPAD(SEQ_APPLICATOR.NEXTVAL, 6,'0') 
        INTO V_SEQ
        FROM DUAL;
       
      V_RTN := 'APP'||V_Y||V_M||V_D||V_SEQ;
    
      RETURN V_RTN;
    
    EXCEPTION
    
        WHEN OTHERS THEN
            RETURN NULL;
    
    END FUN_CREATE_APPLICATOR;
    ```

### FUN_CREATE_ASSYSERIALNO

??? note "소스코드"
    ```sql
    FUNCTION         FUN_CREATE_ASSYSERIALNO
    ( ARG_ITEMCODE         IN   TM_ITEMS.ITEMCODE%TYPE)
    RETURN VARCHAR2
    IS
      V_RTN         VARCHAR2(50);
      V_SEQ         VARCHAR2(5);
      V_PARTNO      TM_ITEMS.PARTNO%TYPE;
      V_PRINTTYPE   TM_ITEMS.PRINTTYPE%TYPE;
      V_BMWSERIAL   VARCHAR2(50);
      
    BEGIN
    
      SELECT T1.PARTNO, NVL(PRINTTYPE, 'X')
        INTO V_PARTNO, V_PRINTTYPE
        FROM TM_ITEMS T1
       WHERE T1.ITEMCODE = ARG_ITEMCODE  ;
       
      SELECT LPAD(T1.SEQ, 4,'0')   
        INTO V_SEQ
        FROM T_SEQ_MAPPING T1
       WHERE 1=1
         AND T1.ITEMCODE = ARG_ITEMCODE
         AND T1.YYYYMMDD = TO_CHAR(SYSDATE, 'YYYYMMDD')  ; 
      
      SELECT 'HA'||
             CASE WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),1,4) = '2022' THEN 'C'
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),1,4) = '2023' THEN 'D'
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),1,4) = '2024' THEN 'E'
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),1,4) = '2025' THEN 'F'
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),1,4) = '2026' THEN 'G'
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),1,4) = '2027' THEN 'H'
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),1,4) = '2028' THEN 'I'
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),1,4) = '2029' THEN 'J'
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),1,4) = '2030' THEN 'K'
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),1,4) = '2031' THEN 'L'
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),1,4) = '2032' THEN 'M'
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),1,4) = '2033' THEN 'N'
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),1,4) = '2034' THEN 'O'
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),1,4) = '2035' THEN 'P'
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),1,4) = '2036' THEN 'Q'
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),1,4) = '2037' THEN 'R'
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),1,4) = '2038' THEN 'S'
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),1,4) = '2039' THEN 'T'
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),1,4) = '2040' THEN 'U' END||
             CASE WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),5,2) = '10' THEN 'O' 
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),5,2) = '11' THEN 'N'
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),5,2) = '12' THEN 'D'
                  ELSE SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),6,1) END||   
             CASE WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),7,2) = '10' THEN 'A'     
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),7,2) = '11' THEN 'B'  
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),7,2) = '12' THEN 'C'  
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),7,2) = '13' THEN 'D'  
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),7,2) = '14' THEN 'E'  
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),7,2) = '15' THEN 'F'  
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),7,2) = '16' THEN 'G'  
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),7,2) = '17' THEN 'H'  
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),7,2) = '18' THEN 'I'  
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),7,2) = '19' THEN 'J'  
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),7,2) = '20' THEN 'K'  
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),7,2) = '21' THEN 'L'  
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),7,2) = '22' THEN 'M'  
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),7,2) = '23' THEN 'N'  
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),7,2) = '24' THEN 'O'  
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),7,2) = '25' THEN 'P'  
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),7,2) = '26' THEN 'Q'  
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),7,2) = '27' THEN 'R'  
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),7,2) = '28' THEN 'S'  
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),7,2) = '29' THEN 'T'  
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),7,2) = '30' THEN 'U'  
                  WHEN SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),7,2) = '31' THEN 'V'  
                  ELSE SUBSTR(TO_CHAR(SYSDATE, 'YYYYMMDD'),8,1) END||
             'A'||
             SUBSTR(V_PARTNO,4,8)  
        INTO V_BMWSERIAL          
        FROM DUAL ;     
         
      IF V_PRINTTYPE = 'B' THEN
         V_RTN := V_BMWSERIAL || V_SEQ;  
      ELSIF V_PRINTTYPE = 'S' THEN
         V_RTN := V_PARTNO || ';' || TO_CHAR(SYSDATE, 'YYMMDD') || V_SEQ;  
      ELSIF V_PRINTTYPE = 'P' THEN
         V_RTN := V_PARTNO || ';' || TO_CHAR(SYSDATE, 'YYMMDD') || V_SEQ;  
      ELSE
         V_RTN := V_PARTNO || ':' || TO_CHAR(SYSDATE, 'YYMMDD') || V_SEQ;
      END IF;
      
      
      RETURN V_RTN;
    
    EXCEPTION
    
        WHEN OTHERS THEN
            RETURN SQLERRM;
    
    END FUN_CREATE_ASSYSERIALNO;
    ```

### FUN_CREATE_BOXNO

??? note "소스코드"
    ```sql
    FUNCTION         FUN_CREATE_BOXNO
        RETURN VARCHAR2
    IS
      V_RTN      VARCHAR2(11);
      V_Y        VARCHAR2(1);
      V_M        VARCHAR2(1);
      V_D        VARCHAR2(1);
      V_SEQ      VARCHAR2(6);
    BEGIN
      
      SELECT CVALUE
      INTO  V_Y
      FROM TM_COMMCODE
      WHERE COMMGRP = 'CG005'
      AND COMMNAME = TO_CHAR(SYSDATE,'YYYY');
      
      SELECT CVALUE
      INTO  V_M
      FROM TM_COMMCODE
      WHERE COMMGRP = 'CG006'
      AND COMMNAME = TO_CHAR(SYSDATE,'MM');
      
      SELECT CVALUE 
      INTO  V_D
      FROM TM_COMMCODE
      WHERE COMMGRP = 'CG007'
      AND COMMNAME = TO_CHAR(SYSDATE,'DD');
      
      SELECT LPAD(SEQ_BOXNO.NEXTVAL,6,'0') 
      INTO V_SEQ
      FROM DUAL;
      
      V_RTN := 'BX'||V_Y||V_M||V_D||V_SEQ;
    
      RETURN V_RTN;
    
    EXCEPTION
    
        WHEN OTHERS THEN
            RETURN NULL;
    
    END FUN_CREATE_BOXNO;
    ```

### FUN_CREATE_BUNDLENO

??? note "소스코드"
    ```sql
    FUNCTION         FUN_CREATE_BUNDLENO
    RETURN VARCHAR2
    IS
    
    V_RTN      VARCHAR2(11);
    V_Y        VARCHAR2(1);
    V_M        VARCHAR2(1);
    V_D        VARCHAR2(1);
    V_SEQ      VARCHAR2(6);
    
    BEGIN
      
      SELECT CVALUE
        INTO  V_Y
        FROM TM_COMMCODE
       WHERE COMMGRP = 'CG005'
         AND COMMNAME = TO_CHAR(SYSDATE,'YYYY');
      
      SELECT CVALUE
        INTO  V_M
        FROM TM_COMMCODE
       WHERE COMMGRP = 'CG006'
         AND COMMNAME = TO_CHAR(SYSDATE,'MM');
      
      SELECT CVALUE 
        INTO  V_D
        FROM TM_COMMCODE
       WHERE COMMGRP = 'CG007'
         AND COMMNAME = TO_CHAR(SYSDATE,'DD');
    
      SELECT LPAD(SEQ_BUNDLENO.NEXTVAL, 6,'0') 
        INTO V_SEQ
        FROM DUAL;
       
      V_RTN := 'BU'||V_Y||V_M||V_D||V_SEQ;
    
      RETURN V_RTN;
    
    EXCEPTION
    
        WHEN OTHERS THEN
            RETURN NULL;
    
    END FUN_CREATE_BUNDLENO;
    ```

### FUN_CREATE_JIG

??? note "소스코드"
    ```sql
    FUNCTION         FUN_CREATE_JIG
    RETURN VARCHAR2
    IS
    
    V_RTN      VARCHAR2(20);
    V_Y        VARCHAR2(1);
    V_M        VARCHAR2(1);
    V_D        VARCHAR2(1);
    V_SEQ      VARCHAR2(6);
    
    BEGIN
      
      SELECT CVALUE
        INTO  V_Y
        FROM TM_COMMCODE
       WHERE COMMGRP = 'CG005'
         AND COMMNAME = TO_CHAR(SYSDATE,'YYYY');
      
      SELECT CVALUE
        INTO  V_M
        FROM TM_COMMCODE
       WHERE COMMGRP = 'CG006'
         AND COMMNAME = TO_CHAR(SYSDATE,'MM');
      
      SELECT CVALUE 
        INTO  V_D
        FROM TM_COMMCODE
       WHERE COMMGRP = 'CG007'
         AND COMMNAME = TO_CHAR(SYSDATE,'DD');
    
      SELECT LPAD(SEQ_JIG.NEXTVAL, 6,'0') 
        INTO V_SEQ
        FROM DUAL;
       
      V_RTN := 'TDJ'||V_Y||V_M||V_D||V_SEQ;
    
      RETURN V_RTN;
    
    EXCEPTION
    
        WHEN OTHERS THEN
            RETURN NULL;
    
    END FUN_CREATE_JIG;
    ```

### FUN_CREATE_MFG

??? note "소스코드"
    ```sql
    FUNCTION         FUN_CREATE_MFG
    RETURN VARCHAR2
    IS
    
    V_RTN      VARCHAR2(11);
    V_Y        VARCHAR2(1);
    V_M        VARCHAR2(1);
    V_D        VARCHAR2(1);
    
    
    BEGIN
      
      SELECT T1.COMMNAME
        INTO  V_Y
        FROM TM_COMMCODE T1
       WHERE COMMGRP = 'CG013'
         AND T1.CVALUE = TO_CHAR(SYSDATE,'YYYY');
      
      SELECT T1.COMMNAME
        INTO  V_M
        FROM TM_COMMCODE T1
       WHERE COMMGRP = 'CG014'
         AND T1.CVALUE = LPAD(TO_CHAR(SYSDATE,'MM'), 2, '0');
      
      SELECT T1.COMMNAME 
        INTO  V_D
        FROM TM_COMMCODE T1
       WHERE COMMGRP = 'CG015'
         AND T1.CVALUE = LPAD(TO_CHAR(SYSDATE,'DD'), 2, '0');
    
    
      V_RTN := V_Y||V_M||V_D;
    
      RETURN V_RTN;
    
    EXCEPTION
    
        WHEN OTHERS THEN
            RETURN NULL;
    
    END FUN_CREATE_MFG;
    ```

### FUN_CREATE_PRODPROGNO

??? note "소스코드"
    ```sql
    FUNCTION         FUN_CREATE_PRODPROGNO
        RETURN VARCHAR2
    IS
      
      V_RTN      VARCHAR2(12);
      V_Y        VARCHAR2(1);
      V_M        VARCHAR2(1);
      V_D        VARCHAR2(1);
      V_SEQ      VARCHAR2(6);
      
    BEGIN
      
      SELECT CVALUE
      INTO  V_Y
      FROM TM_COMMCODE
      WHERE COMMGRP = 'CG005'
      AND COMMNAME = TO_CHAR(SYSDATE,'YYYY');
      
      SELECT CVALUE
      INTO  V_M
      FROM TM_COMMCODE
      WHERE COMMGRP = 'CG006'
      AND COMMNAME = TO_CHAR(SYSDATE,'MM');
      
      SELECT CVALUE 
      INTO  V_D
      FROM TM_COMMCODE
      WHERE COMMGRP = 'CG007'
      AND COMMNAME = TO_CHAR(SYSDATE,'DD');
    
      SELECT LPAD(SEQ_PRODPROGNO.NEXTVAL, 6,'0') 
        INTO V_SEQ
        FROM DUAL;  
        
      V_RTN := 'PO'||V_Y||V_M||V_D||V_SEQ;
    
      RETURN V_RTN;
    
    EXCEPTION
    
        WHEN OTHERS THEN
            RETURN NULL;
    
    END FUN_CREATE_PRODPROGNO;
    ```

### FUN_DATETOSN

??? note "소스코드"
    ```sql
    FUNCTION         FUN_DATETOSN(A_DATE VARCHAR2
                                            )
     RETURN VARCHAR2
    IS
      V_DATE  VARCHAR2(8);
      V_SN    VARCHAR2(3);
      V_YEAR  VARCHAR2(1);
      V_MONTH VARCHAR2(1);
      V_DAY   VARCHAR2(1);
    BEGIN
    
      IF A_DATE IS NULL THEN
        V_DATE := TO_CHAR(SYSDATE,'YYYYMMDD');
      ELSE
        V_DATE := SUBSTR(A_DATE,1,8);
      END IF;
      -- 년 CHR로 확인
      SELECT CHR(T.LV) INTO V_YEAR
        FROM (
          SELECT LEVEL AS LV ,ROWNUM AS CNT
            FROM DUAL
           WHERE (LEVEL >=49 AND LEVEL <= 57) OR (LEVEL >=65 AND LEVEL <= 90)
         CONNECT BY LEVEL <= 90
             ) T
    
        WHERE T.CNT + 2010 =  TO_NUMBER(SUBSTR(V_DATE, 1,4))
      ;
    
      -- 월 CHR로 확인
      SELECT CHR(T.LV) INTO V_MONTH
        FROM (
          SELECT LEVEL AS LV ,ROWNUM AS CNT
            FROM DUAL
           WHERE (LEVEL >=49 AND LEVEL <= 57) OR (LEVEL >=65 AND LEVEL <= 90)
         CONNECT BY LEVEL <= 90
             ) T
        WHERE CNT = TO_NUMBER(SUBSTR(V_DATE, 5,2))
      ;
      -- 일 CHR로 확인
      SELECT CHR(T.LV) INTO V_DAY
        FROM (
          SELECT LEVEL AS LV ,ROWNUM AS CNT
            FROM DUAL
           WHERE (LEVEL >=49 AND LEVEL <= 57) OR (LEVEL >=65 AND LEVEL <= 90)
         CONNECT BY LEVEL <= 90
    
             ) T
        WHERE CNT = TO_NUMBER(SUBSTR(V_DATE, 7,2))
      ;
      V_SN := V_YEAR || V_MONTH || V_DAY;
    
      RETURN V_SN;
    EXCEPTION
    
        WHEN OTHERS THEN
            RETURN NULL;
    
    END FUN_DATETOSN;
    ```

### FUN_ERPNO

??? note "소스코드"
    ```sql
    FUNCTION         FUN_ERPNO
        RETURN VARCHAR2
    IS
    
      N_RETURN  VARCHAR(15);
    
    BEGIN
    
      SELECT 'H' || TO_CHAR(SYSDATE, 'YYYYMMDD') || LPAD(SEQ_ERPNO.NEXTVAL, 4, '0')
        INTO N_RETURN
        FROM DUAL;
    
    
      RETURN N_RETURN ;
    
    EXCEPTION
    
        WHEN OTHERS THEN
            RETURN 'NOTFOUND';
    
    END FUN_ERPNO ;
    ```

### FUN_FROMTOLOSSTIME

??? note "소스코드"
    ```sql
    FUNCTION         FUN_FROMTOLOSSTIME( A_UNITNO         IN      TM_PRODLINE_UNIT.UNITNO%TYPE,
                                                           A_STIME          IN      VARCHAR2,
                                                           A_ETIME          IN      VARCHAR2
                                                         )
        RETURN NUMBER
    IS
    
       V_RETURN NUMBER;
    
    BEGIN
    
        WITH T AS (
            SELECT WORKDATE, WORKTIME1, WORKTIME2, WORKTIME3, WORKTIME4, WORKTIME5, WORKTIME6, WORKTIME7, WORKTIME8, WORKTIME9, WORKTIME10, WORKTIME11, WORKTIME12, WORKTIME13, WORKTIME14, WORKTIME15, WORKTIME16, WORKTIME17, WORKTIME18, WORKTIME19, WORKTIME20, WORKTIME21, WORKTIME22, WORKTIME23, WORKTIME24
              FROM TM_WORKTIME
             WHERE PRODLINE = A_UNITNO
               AND WORKDATE BETWEEN TO_CHAR(TO_DATE(A_STIME, 'YYYYMMDDHH24MISS'), 'YYYYMMDD') AND TO_CHAR(TO_DATE(A_ETIME, 'YYYYMMDDHH24MISS'), 'YYYYMMDD')
        )
        SELECT ROUND(SUM(CASE WHEN TO_CHAR(TO_DATE(A_STIME, 'YYYYMMDDHH24MISS'), 'YYYYMMDDHH24') > WORKDATE || TIME OR TO_CHAR(TO_DATE(A_ETIME, 'YYYYMMDDHH24MISS'), 'YYYYMMDDHH24') < WORKDATE || TIME THEN 0 --시작시간 / 종료 시간 이전 이후 비가동 시간 누적 안함
                              WHEN TO_CHAR(TO_DATE(A_STIME, 'YYYYMMDDHH24MISS'), 'YYYYMMDDHH24') = WORKDATE || TIME THEN TO_NUMBER(MESUSER.FUN_TIMEGAPCAL(A_STIME, WORKDATE || TIME || '0000'))
                              WHEN PERSON = 0 THEN 3600
                              WHEN PERSON  > 0 THEN NVL(TO_NUMBER(MESUSER.FUN_HOURLOSS(TIME)), 0) END) /*/ 60 / 60*/, 1) AS LOSSTIME
          INTO V_RETURN
          FROM T
       UNPIVOT (PERSON FOR TIME IN (WORKTIME1 AS '00', WORKTIME2 AS '01', WORKTIME3 AS '02', WORKTIME4 AS '03', WORKTIME5 AS '04', 
                                    WORKTIME6 AS '05', WORKTIME7 AS '06', WORKTIME8 AS '07', WORKTIME9 AS '08', WORKTIME10 AS '09', 
                                    WORKTIME11 AS '10', WORKTIME12 AS '11', WORKTIME13 AS '12', WORKTIME14 AS '13', WORKTIME15 AS '14', 
                                    WORKTIME16 AS '15', WORKTIME17 AS '16', WORKTIME18 AS '17', WORKTIME19 AS '18', WORKTIME20 AS '19', 
                                    WORKTIME21 AS '20', WORKTIME22 AS '21', WORKTIME23 AS '22', WORKTIME24 AS '23'))
       ;
    
    
      RETURN V_RETURN;
    
    EXCEPTION
    
        WHEN OTHERS THEN
            RETURN NULL;
    
    END FUN_FROMTOLOSSTIME;
    ```

### FUN_GET_BEGIN_STOCK_01

??? note "소스코드"
    ```sql
    FUNCTION         FUN_GET_BEGIN_STOCK_01
    ( ARG_CLIENT         IN VARCHAR2,
      ARG_COMPANY        IN VARCHAR2,
      ARG_PLANT          IN VARCHAR2,
      ARG_DATE           IN VARCHAR2,
      ARG_UPRITEM        IN NUMBER,
      ARG_ITEMCODE       IN NUMBER,
      ARG_FLAG           IN VARCHAR2)
    RETURN NUMBER
    
    as
       
       GET_QTY NUMBER(14) ;
    
    begin 
      
       if arg_flag = '1' then
           begin
              SELECT NVL(SUM(A.QTY),0) STOCKQTY
                INTO GET_QTY
                FROM TM_PRODPLAN_MONTH_BEGIN A
               WHERE A.CLIENT = ARG_CLIENT
                 AND A.COMPANY = ARG_COMPANY
                 AND A.PLANT = ARG_PLANT
                 AND A.STOCKDATE = ARG_DATE
                 AND A.UPRITEM = ARG_UPRITEM
                 AND A.ITEMCODE = ARG_ITEMCODE;
           exception
              when NO_DATA_FOUND then
                 GET_QTY := 0;
                 return GET_QTY;
              when others then
                 GET_QTY := 0;
                 return GET_QTY;
           end;
       else
           begin   
              SELECT SUM(A.ACTUALQTY) ACTUALQTY
                INTO GET_QTY
                FROM TW_ACTUALSTOCK A, TM_ITEMS B
               WHERE A.CLIENT = ARG_CLIENT
                 AND A.COMPANY = ARG_COMPANY
                 AND A.PLANT = ARG_PLANT
                 AND A.ACTUALMON = TO_CHAR(TO_DATE(ARG_DATE||'01') -1,'YYYYMM')
                 AND A.ITEMCODE = ARG_ITEMCODE
                 AND A.CLIENT = B.CLIENT
                 AND A.COMPANY = B.COMPANY
                 AND A.PLANT = B.PLANT
                 AND A.ITEMCODE = B.ITEMCODE
                 AND B.ITEMTYPE = '3';
           exception
              when NO_DATA_FOUND then
                 GET_QTY := 0;
                 return GET_QTY;
              when others then
                 GET_QTY := 0;
                 return GET_QTY;
           end;
       end if;
       
       return GET_QTY;    
       
    EXCEPTION
       WHEN OTHERS THEN
          GET_QTY := 0;
          return GET_QTY;
    
    end;
    ```

### FUN_GET_CUSTPARTNO

??? note "소스코드"
    ```sql
    FUNCTION         FUN_GET_CUSTPARTNO
    ( ARG_CLIENT        IN VARCHAR2,
      ARG_COMPANY       IN VARCHAR2,
      ARG_PLANT         IN VARCHAR2,
      ARG_ITEMCODE      IN NUMBER)
    RETURN NUMBER
    
    as
       
       V_ITEMCODE NUMBER(14) ;
       V_CUSTPARTNO VARCHAR2(30) ;
    
    begin 
      
       
       begin
          SELECT MAX(CUSTPARTNO) CUSTPARTNO
            INTO V_CUSTPARTNO
            FROM TM_ITEMS A, (SELECT CLIENT, COMPANY, PLANT, PARTNO
                                FROM TM_ITEMS 
                               WHERE CLIENT = ARG_CLIENT
                                 AND COMPANY = ARG_COMPANY
                                 AND PLANT = ARG_PLANT
                                 AND ITEMCODE = ARG_ITEMCODE) B
           WHERE A.CLIENT = ARG_CLIENT
             AND A.COMPANY = ARG_COMPANY
             AND A.PLANT = ARG_PLANT
             AND A.PARTNO <> A.CUSTPARTNO
             AND A.CLIENT = B.CLIENT
             AND A.COMPANY = B.COMPANY
             AND A.PLANT = B.PLANT
             AND A.CUSTPARTNO = B.PARTNO ;
          EXCEPTION
             WHEN OTHERS THEN
                  V_CUSTPARTNO := 'X';   
       end;
       
       IF V_CUSTPARTNO <> 'X' THEN
          SELECT MAX(ITEMCODE)
            INTO V_ITEMCODE
            FROM TM_ITEMS
           WHERE CLIENT = ARG_CLIENT
             AND COMPANY = ARG_COMPANY
             AND PLANT = ARG_PLANT
             AND CUSTPARTNO = V_CUSTPARTNO;   
       ELSE
          V_ITEMCODE := ARG_ITEMCODE;
       END IF;
       
       return V_ITEMCODE;    
       
    EXCEPTION
       WHEN OTHERS THEN
          V_ITEMCODE := 0;
          return V_ITEMCODE;
    
    end;
    ```

### FUN_GET_MATERIALREQUESTNO

??? note "소스코드"
    ```sql
    FUNCTION         FUN_GET_MATERIALREQUESTNO 
        RETURN VARCHAR2
    IS
    
      N_RETURN  VARCHAR(15);
    
    BEGIN
    
      SELECT 'MR' || TO_CHAR(SYSDATE, 'YYYYMMDD') || LPAD(MESUSER.SEQ_MATREQUEST.NEXTVAL, 5, '0')
        INTO N_RETURN
        FROM DUAL;
        
    
      RETURN N_RETURN ;
    
    EXCEPTION
    
        WHEN OTHERS THEN
            RETURN 'NOTFOUND';
    
    END FUN_GET_MATERIALREQUESTNO ;
    ```

### FUN_GET_PLANENDTIME

??? note "소스코드"
    ```sql
    FUNCTION         FUN_GET_PLANENDTIME( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                                              A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                                              A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                                              A_WRKDATE      IN      TW_WORKORD.WRKDATE%TYPE,
                                                              A_OPER         IN      TM_OPERATION.OPER%TYPE,
                                                              A_UNITNO       IN      TM_PRODLINE_UNIT.UNITNO%TYPE,
                                                              A_ITEMCODE     IN      TM_ITEMS.ITEMCODE%TYPE,
                                                              A_ORDQTY       IN      TW_WORKORD.ORDQTY%TYPE)
      RETURN VARCHAR2
      
      IS
      
      N_EXISTS                NUMBER;
      N_RETURN                TW_WORKORD.PLANENDTIME%TYPE;
        
      V_ST                    TM_ITEMS.TACTTIME%TYPE;
      V_PLANSTARTTIME         TW_WORKORD.PLANSTARTTIME%TYPE;
      V_PLANENDTIME           TW_WORKORD.PLANENDTIME%TYPE;
    
      BEGIN
    
        /*작업지시 시작시간 조회*/
        SELECT NVL(MAX(T1.PLANENDTIME), A_WRKDATE ||'080000')
          INTO V_PLANSTARTTIME
          FROM TW_WORKORD T1
         WHERE T1.CLIENT = A_CLIENT
           AND T1.COMPANY = A_COMPANY
           AND T1.PLANT = A_PLANT
           AND T1.WRKDATE = A_WRKDATE
           AND T1.OPER = A_OPER
           AND T1.UNITNO = A_UNITNO
           AND T1.USEFLAG = 'Y'
           ;
               
        /*ST시간 조회*/
        SELECT NVL(TACTTIME, 1)
          INTO V_ST
          FROM TM_ITEMS
         WHERE CLIENT = A_CLIENT
           AND COMPANY = A_COMPANY
           AND PLANT = A_PLANT
           AND ITEMCODE = A_ITEMCODE
           ;
        
        /*작업 종료 시간 조회*/
        SELECT TO_CHAR(TO_DATE(V_PLANSTARTTIME, 'YYYYMMDDHH24MISS') + NUMTODSINTERVAL(V_ST * A_ORDQTY, 'second'), 'YYYYMMDDHH24MISS')
          INTO V_PLANENDTIME
          FROM DUAL
          ;
          
        /*작업 다운 시간 정보 조회*/
        SELECT COUNT(*)
          INTO N_EXISTS
          FROM TM_DOWNTIME T1
         WHERE CLIENT = A_CLIENT
           AND COMPANY = A_COMPANY
           AND PLANT = A_PLANT
           AND T1.DOWNDATE = A_WRKDATE
           ;
           
        IF N_EXISTS = 0 THEN
        
            FOR R_REC IN (SELECT T1.STARTTIME, T1.ENDTIME, T1.DOWNTIME
                            FROM TM_DOWNTIME T1
                           WHERE T1.CLIENT = A_CLIENT
                             AND T1.COMPANY = A_COMPANY
                             AND T1.PLANT = A_PLANT
                             AND T1.DOWNDATE = 'NONE'
                             AND T1.STARTTIME >= TO_CHAR(TO_DATE(V_PLANSTARTTIME, 'YYYYMMDDHH24MISS'), 'HH24MI')
                           ORDER BY STARTTIME )
            LOOP
                IF R_REC.STARTTIME <= TO_CHAR(TO_DATE(V_PLANENDTIME, 'YYYYMMDDHH24MISS'), 'HH24MI')  THEN
                    /*작업 종료 시간 조회*/
                    SELECT TO_CHAR(TO_DATE(V_PLANENDTIME, 'YYYYMMDDHH24MISS') + NUMTODSINTERVAL(R_REC.DOWNTIME, 'second'), 'YYYYMMDDHH24MISS')
                      INTO V_PLANENDTIME
                      FROM DUAL;
                ELSE
                    EXIT;
                END IF;
            END LOOP;
        
        ELSE
        
            FOR R_REC IN (SELECT T1.STARTTIME, T1.ENDTIME, T1.DOWNTIME
                            FROM TM_DOWNTIME T1
                           WHERE T1.CLIENT = A_CLIENT
                             AND T1.COMPANY = A_COMPANY
                             AND T1.PLANT = A_PLANT
                             AND T1.DOWNDATE = A_WRKDATE
                             AND T1.STARTTIME >= TO_CHAR(TO_DATE(V_PLANSTARTTIME, 'YYYYMMDDHH24MISS'), 'HH24MI')
                           ORDER BY T1.STARTTIME )
            LOOP
                IF R_REC.STARTTIME <= TO_CHAR(TO_DATE(V_PLANENDTIME, 'YYYYMMDDHH24MISS'), 'HH24MI') THEN
                    /*작업 종료 시간 조회*/
                    SELECT TO_CHAR(TO_DATE(V_PLANENDTIME, 'YYYYMMDDHH24MISS') + NUMTODSINTERVAL(R_REC.DOWNTIME, 'second'), 'YYYYMMDDHH24MISS')
                      INTO V_PLANENDTIME
                      FROM DUAL;
                ELSE
                    EXIT;
                END IF;
            END LOOP;
            
        END IF;
        
    
        RETURN V_PLANENDTIME ;
    
      EXCEPTION
    
            WHEN OTHERS THEN
                RETURN 'NOTFOUND';
    
      END FUN_GET_PLANENDTIME ;
    ```

### FUN_GET_PLANSTARTTIME

??? note "소스코드"
    ```sql
    FUNCTION         FUN_GET_PLANSTARTTIME( A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                                                A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                                                A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                                                A_WRKDATE      IN      TW_WORKORD.WRKDATE%TYPE,
                                                                A_OPER         IN      TM_OPERATION.OPER%TYPE,
                                                                A_UNITNO       IN      TM_PRODLINE_UNIT.UNITNO%TYPE,
                                                                A_ITEMCODE     IN      TM_ITEMS.ITEMCODE%TYPE,
                                                                A_ORDQTY       IN      TW_WORKORD.ORDQTY%TYPE)
      RETURN VARCHAR2
      
      IS
      
      N_EXISTS                NUMBER;
      N_RETURN                TW_WORKORD.PLANENDTIME%TYPE;
        
      V_ST                    TM_ITEMS.TACTTIME%TYPE;
      V_PLANSTARTTIME         TW_WORKORD.PLANSTARTTIME%TYPE;
      V_PLANENDTIME           TW_WORKORD.PLANENDTIME%TYPE;
    
      BEGIN
    
        /*작업지시 시작시간 조회*/
        SELECT NVL(MAX(T1.PLANENDTIME), A_WRKDATE ||'080000')
          INTO V_PLANSTARTTIME
          FROM TW_WORKORD T1
         WHERE T1.CLIENT = A_CLIENT
           AND T1.COMPANY = A_COMPANY
           AND T1.PLANT = A_PLANT
           AND T1.WRKDATE = A_WRKDATE
           AND T1.OPER = A_OPER
           AND T1.UNITNO = A_UNITNO
           AND T1.USEFLAG = 'Y'
           ;
        
        RETURN V_PLANSTARTTIME ;
    
      EXCEPTION
    
            WHEN OTHERS THEN
                RETURN 'NOTFOUND';
    
      END FUN_GET_PLANSTARTTIME ;
    ```

### FUN_GET_PRODLABEL_CNT

??? note "소스코드"
    ```sql
    FUNCTION         FUN_GET_PRODLABEL_CNT
    ( ARG_CLIENT        IN VARCHAR2,
      ARG_COMPANY       IN VARCHAR2,
      ARG_PLANT         IN VARCHAR2,
      ARG_PRINTTYPE     IN VARCHAR2)
    RETURN NUMBER
    
    as
       
       GET_CNT NUMBER(14) ;
    
    begin 
      
       
       begin
          SELECT COUNT(*) + 1
            INTO GET_CNT
            FROM TM_SERIAL A, TM_ITEMS B
           WHERE A.CLIENT = ARG_CLIENT
             AND A.COMPANY = ARG_COMPANY
             AND A.PLANT = ARG_PLANT
             AND SUBSTR(A.CREATETIMEKEY,1,8) = TO_CHAR(SYSDATE,'YYYYMMDD')
             AND A.ITEMCODE = B.ITEMCODE
             AND B.PRINTTYPE = ARG_PRINTTYPE ;
       exception
          when NO_DATA_FOUND then
             GET_CNT := 1;
             return GET_CNT;
          when others then
             GET_CNT := 1;
             return GET_CNT;
       end;
       
       return GET_CNT;    
       
    EXCEPTION
       WHEN OTHERS THEN
          GET_CNT := 1;
          return GET_CNT;
    
    end;
    ```

### FUN_GET_STOCK_002

??? note "소스코드"
    ```sql
    FUNCTION         FUN_GET_STOCK_002
    ( ARG_CLIENT        IN VARCHAR2,
      ARG_COMPANY       IN VARCHAR2,
      ARG_PLANT         IN VARCHAR2,
      ARG_PARTNO        IN VARCHAR2,
      ARG_WHLOC         IN VARCHAR2)
    RETURN NUMBER
    
    as
       
       GET_QTY NUMBER(14) ;
    
    begin 
      
       
       begin
          SELECT NVL(SUM(A.GOODQTY),0) STOCKQTY
            INTO GET_QTY
            FROM TW_STOCKSERIAL A, TM_ITEMS B
           WHERE A.CLIENT = ARG_CLIENT
             AND A.COMPANY = ARG_COMPANY
             AND A.PLANT = ARG_PLANT
             AND A.WHLOC = ARG_WHLOC
             AND A.ITEMCODE = B.ITEMCODE
             AND B.PARTNO = ARG_PARTNO;
       exception
          when NO_DATA_FOUND then
             GET_QTY := 0;
             return GET_QTY;
          when others then
             GET_QTY := 0;
             return GET_QTY;
       end;
       
       return GET_QTY;    
       
    EXCEPTION
       WHEN OTHERS THEN
          GET_QTY := 0;
          return GET_QTY;
    
    end;
    ```

### FUN_GET_STOCK_003

??? note "소스코드"
    ```sql
    FUNCTION         FUN_GET_STOCK_003
    ( ARG_CLIENT         IN VARCHAR2,
      ARG_COMPANY        IN VARCHAR2,
      ARG_PLANT          IN VARCHAR2,
      ARG_ITEMCODE       IN NUMBER)
    RETURN NUMBER
    
    as
       
       GET_QTY NUMBER(14) ;
    
    begin 
      
       
       begin
          SELECT NVL(SUM(A.STOCKQTY),0) STOCKQTY
            INTO GET_QTY
            FROM TIF_STOCK A
           WHERE CLIENT = ARG_CLIENT
             AND COMPANY = ARG_COMPANY
             AND PLANT = ARG_PLANT
             AND ITEMCODE = ARG_ITEMCODE;
       exception
          when NO_DATA_FOUND then
             GET_QTY := 0;
             return GET_QTY;
          when others then
             GET_QTY := 0;
             return GET_QTY;
       end;
       
       return GET_QTY;    
       
    EXCEPTION
       WHEN OTHERS THEN
          GET_QTY := 0;
          return GET_QTY;
    
    end;
    ```

### FUN_GET_STOCK_01

??? note "소스코드"
    ```sql
    FUNCTION         FUN_GET_STOCK_01
    ( 
      ARG_CLIENT            IN VARCHAR2,
      ARG_COMPANY           IN VARCHAR2,
      ARG_PLANT             IN VARCHAR2,
      ARG_WHLOC             IN VARCHAR2,
      ARG_SERIAL            IN VARCHAR2,
      ARG_ITEMCODE          IN  VARCHAR2,
      ARG_GUBUN             IN VARCHAR2
    
    )
        RETURN NUMBER
    IS
    
      N_QTY  NUMBER(14,3);
    
    BEGIN
    
      IF ARG_GUBUN = '1' THEN
         SELECT NVL(GOODQTY,0)
           INTO N_QTY
           FROM TW_STOCKSERIAL
          WHERE CLIENT  = ARG_CLIENT
            AND COMPANY = ARG_COMPANY
            AND PLANT   = ARG_PLANT
            AND WHLOC   = ARG_WHLOC
            AND ITEMCODE = ARG_ITEMCODE
            AND SERIAL  = ARG_SERIAL;
      ELSE
         SELECT NVL(SUM(QTY), 0)
           INTO N_QTY
           FROM TM_BOX
          WHERE CLIENT = ARG_CLIENT
            AND COMPANY = ARG_COMPANY
            AND PLANT = ARG_PLANT
            AND ITEMCODE = ARG_ITEMCODE
            AND WHLOC = ARG_WHLOC
          GROUP BY CLIENT, COMPANY, PLANT, WHLOC, ITEMCODE;
          
      END IF;
        
    
      RETURN N_QTY ;
    
    EXCEPTION
    
        WHEN OTHERS THEN
            RETURN 0;
    
    END FUN_GET_STOCK_01 ;
    ```

### FUN_GET_STOCK_02

??? note "소스코드"
    ```sql
    FUNCTION         FUN_GET_STOCK_02
    ( 
      ARG_CLIENT            IN VARCHAR2,
      ARG_COMPANY           IN VARCHAR2,
      ARG_PLANT             IN VARCHAR2,
      ARG_WHLOC             IN VARCHAR2,
      ARG_SERIAL            IN VARCHAR2,
      ARG_ITEMCODE          IN  VARCHAR2,
      ARG_GUBUN             IN VARCHAR2
    
    )
        RETURN NUMBER
    IS
    
      N_QTY  NUMBER(14,3);
    
    BEGIN
    
      IF ARG_GUBUN = '1' THEN
         SELECT SUM(NVL(GOODQTY,0))
           INTO N_QTY
           FROM TW_STOCKSERIAL
          WHERE CLIENT  = ARG_CLIENT
            AND COMPANY = ARG_COMPANY
            AND PLANT   = ARG_PLANT
            AND WHLOC   <> ARG_WHLOC
            AND ITEMCODE = ARG_ITEMCODE
            AND SERIAL  = ARG_SERIAL;
      ELSE
         SELECT NVL(SUM(QTY), 0)
           INTO N_QTY
           FROM TM_BOX
          WHERE CLIENT = ARG_CLIENT
            AND COMPANY = ARG_COMPANY
            AND PLANT = ARG_PLANT
            AND ITEMCODE = ARG_ITEMCODE
            AND WHLOC <> ARG_WHLOC
          GROUP BY CLIENT, COMPANY, PLANT, WHLOC, ITEMCODE;
          
      END IF;
        
    
      RETURN N_QTY ;
    
    EXCEPTION
    
        WHEN OTHERS THEN
            RETURN 0;
    
    END FUN_GET_STOCK_02 ;
    ```

### FUN_GET_STOCK_ONBOARD

??? note "소스코드"
    ```sql
    FUNCTION         FUN_GET_STOCK_ONBOARD
    ( ARG_CLIENT        IN VARCHAR2,
      ARG_COMPANY       IN VARCHAR2,
      ARG_PLANT         IN VARCHAR2,
      ARG_PARTNO        IN VARCHAR2)
    RETURN NUMBER
    
    as
       
       GET_QTY NUMBER(14) ;
    
    begin 
      
       
       begin
          SELECT SUM(B.LCQTY)
            INTO GET_QTY
            FROM TM_INVOICEMASTER A, TM_INVOICEDETAIL B, TM_ORDERDETAIL C
           WHERE A.CLIENT = B.CLIENT
             AND A.COMPANY = B.COMPANY
             AND A.PLANT = B.PLANT
             AND A.POLCNO = B.POLCNO
             AND B.CLIENT = ARG_CLIENT
             AND B.COMPANY = ARG_COMPANY
             AND B.PLANT = ARG_PLANT
             AND B.LCQTY IS NOT NULL
             AND B.CLIENT = C.CLIENT
             AND B.COMPANY = C.COMPANY
             AND B.PLANT = C.PLANT
             AND B.BALJPNO = C.BALJPNO
             AND B.BALSEQ = C.BALSEQ 
             AND C.ITNBR = ARG_PARTNO
             AND NOT EXISTS (SELECT D.INVOICENO
                               FROM TW_IN D 
                              WHERE A.CLIENT = D.CLIENT
                                AND A.COMPANY = D.COMPANY
                                AND A.PLANT = D.PLANT
                                AND A.POLCNO = D.INVOICENO)
          ;
       exception
          when NO_DATA_FOUND then
             GET_QTY := 0;
             return GET_QTY;
          when others then
             GET_QTY := 0;
             return GET_QTY;
       end;
       
       return GET_QTY;    
       
    EXCEPTION
       WHEN OTHERS THEN
          GET_QTY := 0;
          return GET_QTY;
    
    end;
    ```

### FUN_GET_WORKORDNO

??? note "소스코드"
    ```sql
    FUNCTION         FUN_GET_WORKORDNO ( ARG_WORKORDTYPE IN VARCHAR2)
        RETURN VARCHAR2
    IS
    
      N_RETURN  VARCHAR(15);
    
    BEGIN
    
      SELECT 'WO' || TO_CHAR(SYSDATE, 'YYYYMMDD') || ARG_WORKORDTYPE || LPAD(MESUSER.SEQ_WORKORD.NEXTVAL, 4, '0')
        INTO N_RETURN
        FROM DUAL;
        
    
      RETURN N_RETURN ;
    
    EXCEPTION
    
        WHEN OTHERS THEN
            RETURN 'NOTFOUND';
    
    END FUN_GET_WORKORDNO ;
    ```

### FUN_HOURLOSS

??? note "소스코드"
    ```sql
    FUNCTION         FUN_HOURLOSS( A_STDTIME     IN  VARCHAR2 )
        RETURN VARCHAR2
    IS
    
       V_RETURN VARCHAR2(10);
    
    BEGIN
    
        SELECT SUM(LOSSTIME)
          INTO V_RETURN
          FROM (SELECT CASE WHEN A_STDTIME = '10' THEN 600 ELSE 0 END AS LOSSTIME
                  FROM DUAL
                 UNION ALL
                SELECT CASE WHEN A_STDTIME = '12' THEN 3600 ELSE 0 END AS LOSSTIME
                  FROM DUAL
                 UNION ALL
                SELECT CASE WHEN A_STDTIME = '15' THEN 600 ELSE 0 END AS LOSSTIME
                  FROM DUAL
                 UNION ALL
                SELECT CASE WHEN A_STDTIME = '17' THEN 1200 ELSE 0 END AS LOSSTIME
                  FROM DUAL
                 UNION ALL
                SELECT CASE WHEN A_STDTIME = '18' THEN 600 ELSE 0 END AS LOSSTIME
                  FROM DUAL
                  )
          ;
    
      RETURN V_RETURN;
    
    EXCEPTION
    
        WHEN OTHERS THEN
            RETURN NULL;
    
    END FUN_HOURLOSS;
    ```

### FUN_LOSSTIME

??? note "소스코드"
    ```sql
    FUNCTION         FUN_LOSSTIME( A_STTIME     IN  VARCHAR2,
                                                     A_ENTIME     IN  VARCHAR2 
                                                   )
        RETURN VARCHAR2
    IS
    
       V_RETURN VARCHAR2(10);
    
    BEGIN
    
        SELECT SUM(LOSSTIME)
          INTO V_RETURN
          FROM (SELECT CASE WHEN TO_CHAR(TO_DATE(SUBSTR(A_STTIME,1,14),'YYYYMMDDHH24MISS'),'HH24MISS') < 100000 AND 
                                 TO_CHAR(TO_DATE(SUBSTR(A_ENTIME,1,14),'YYYYMMDDHH24MISS'),'HH24MISS') > 100959 THEN 600 --오전 휴식 시간
                       ELSE 0 END AS LOSSTIME
                  FROM DUAL
                 UNION ALL
                SELECT CASE WHEN TO_CHAR(TO_DATE(SUBSTR(A_STTIME,1,14),'YYYYMMDDHH24MISS'),'HH24MISS') < 113000 AND 
                                 TO_CHAR(TO_DATE(SUBSTR(A_ENTIME,1,14),'YYYYMMDDHH24MISS'),'HH24MISS') > 122959 THEN 3600 --점심 시간
                       ELSE 0 END
                  FROM DUAL
                 UNION ALL
                SELECT CASE WHEN TO_CHAR(TO_DATE(SUBSTR(A_STTIME,1,14),'YYYYMMDDHH24MISS'),'HH24MISS') < 150000 AND 
                                 TO_CHAR(TO_DATE(SUBSTR(A_ENTIME,1,14),'YYYYMMDDHH24MISS'),'HH24MISS') > 150959 THEN 600 -- 오후 휴식 시간
                       ELSE 0 END
                  FROM DUAL
                 UNION ALL
                SELECT CASE WHEN TO_CHAR(TO_DATE(SUBSTR(A_STTIME,1,14),'YYYYMMDDHH24MISS'),'HH24MISS') < 170000 AND 
                                 TO_CHAR(TO_DATE(SUBSTR(A_ENTIME,1,14),'YYYYMMDDHH24MISS'),'HH24MISS') > 172959 THEN 1800 --저녁 시간
                       ELSE 0 END
                  FROM DUAL
                 UNION ALL
                SELECT CASE WHEN TO_CHAR(TO_DATE(SUBSTR(A_STTIME,1,14),'YYYYMMDDHH24MISS'),'HH24MISS') < 193000 AND 
                                 TO_CHAR(TO_DATE(SUBSTR(A_ENTIME,1,14),'YYYYMMDDHH24MISS'),'HH24MISS') > 193959 THEN 600 --저녁 휴식 시간
                       ELSE 0 END
                  FROM DUAL
                  )
          ;
    
      RETURN V_RETURN;
    
    EXCEPTION
    
        WHEN OTHERS THEN
            RETURN NULL;
    
    END FUN_LOSSTIME;
    ```

### FUN_MOUNT_SERIAL

??? note "소스코드"
    ```sql
    FUNCTION         FUN_MOUNT_SERIAL(A_CLIENT       IN      TM_CLIENT.CLIENT%TYPE,  /* 법인 코드 */
                                                        A_COMPANY      IN      TM_COMPANY.COMPANY%TYPE, /* 사업장 코드 */
                                                        A_PLANT        IN      TM_PLANT.PLANT%TYPE, /* 공장코드 */
                                                        A_PRODPROGNO   IN      TH_WORKORD.PRODPROGNO%TYPE,
                                                        A_ITEMCODE     IN      TW_MOUNT.ITEMCODE%TYPE,
                                                        A_SIDE         IN      TW_MOUNT.SIDE%TYPE)
                                                        
    RETURN VARCHAR2
    IS
    
      N_RETURN  VARCHAR(15);
    
    BEGIN
    
      IF A_PRODPROGNO = 'NONE' THEN
        N_RETURN := '';
        RETURN N_RETURN;
      END IF;
    
      SELECT SERIAL
        INTO N_RETURN
        FROM TW_MOUNT T1
       WHERE T1.CLIENT = A_CLIENT
         AND T1.COMPANY = A_COMPANY
         AND T1.PLANT = A_PLANT
         AND T1.PRODPROGNO = A_PRODPROGNO
         AND T1.ITEMCODE = A_ITEMCODE
         AND T1.SEQ = (SELECT MIN(SEQ)
                         FROM TW_MOUNT
                        WHERE CLIENT = A_CLIENT
                          AND COMPANY = A_COMPANY
                          AND PLANT = A_PLANT
                          AND PRODPROGNO = A_PRODPROGNO
                          AND ITEMCODE = A_ITEMCODE
                          AND SIDE = A_SIDE
                          AND USEFLAG = 'Y')
         ;
    
    
      RETURN N_RETURN ;
    
    EXCEPTION
    
        WHEN OTHERS THEN
            RETURN '';
    
    END FUN_MOUNT_SERIAL ;
    ```

### FUN_NORMDIST

??? note "소스코드"
    ```sql
    FUNCTION         FUN_NORMDIST(A_INPUTVAL      IN      NUMBER,
                                                    A_MEAN          IN      NUMBER,
                                                    A_STDV          IN      NUMBER)
        RETURN NUMBER
    IS
    
      V_RTN      NUMBER;
    
    BEGIN
    
        SELECT   0.5 + SIGN(A_INPUTVAL - A_MEAN) /* 평균보다 크면 +, 작으면 - */
               * SUM( 1 / (SQRT( 2 * ACOS(-1) ) )
               * EXP( -POWER( X , 2) / 2 )/* 표준정규분포 확률밀도 함수의 SUM */
               / (5000 + 1)) 
          INTO V_RTN
          FROM( SELECT  ( ( LEVEL - 1) / 5000 ) AS X
                  FROM    DUAL
               CONNECT BY LEVEL <=   ABS(A_INPUTVAL - A_MEAN) / A_STDV  /* 표준정규분포 변환식 z = (x - μ) / σ */
                                 * 5000 + 1
               )
      ;
    
      RETURN V_RTN;
    
    EXCEPTION
    
        WHEN OTHERS THEN
            RETURN NULL;
    
    END FUN_NORMDIST;
    ```

### FUN_REQUESTNO

??? note "소스코드"
    ```sql
    FUNCTION         FUN_REQUESTNO
        RETURN VARCHAR2
    IS
    
      N_RETURN  VARCHAR(15);
    
    BEGIN
    
      SELECT 'RE' || TO_CHAR(SYSDATE, 'YYYYMMDD') || LPAD(MESUSER.SEQ_REQUEST.NEXTVAL, 5, '0')
        INTO N_RETURN
        FROM DUAL;
    
    
      RETURN N_RETURN ;
    
    EXCEPTION
    
        WHEN OTHERS THEN
            RETURN 'NOTFOUND';
    
    END FUN_REQUESTNO ;
    ```

### FUN_TIMEGAPCAL

??? note "소스코드"
    ```sql
    FUNCTION         FUN_TIMEGAPCAL( A_ENTIME     IN  VARCHAR2,
                                                       A_STTIME     IN  VARCHAR2 
                                                      )
        RETURN VARCHAR2
    IS
    
       V_RETURN VARCHAR2(10);
    
    BEGIN
    
        SELECT NVL(ROUND (
                   (    EXTRACT (
                           DAY FROM (  TO_TIMESTAMP (MAX (A_ENTIME),
                                                     'YYYYMMDDHH24MISSFF6')
                                     - TO_TIMESTAMP (MIN (A_STTIME),
                                                     'YYYYMMDDHH24MISSFF6')))
                      * 24
                      * 60
                      * 60
                    +   EXTRACT (
                           HOUR FROM (  TO_TIMESTAMP (MAX (A_ENTIME),
                                                      'YYYYMMDDHH24MISSFF6')
                                      - TO_TIMESTAMP (MIN (A_STTIME),
                                                      'YYYYMMDDHH24MISSFF6')))
                      * 60
                      * 60
                    +   EXTRACT (
                           MINUTE FROM (  TO_TIMESTAMP (MAX (A_ENTIME),
                                                        'YYYYMMDDHH24MISSFF6')
                                        - TO_TIMESTAMP (MIN (A_STTIME),
                                                        'YYYYMMDDHH24MISSFF6')))
                      * 60
                    + EXTRACT (
                         SECOND FROM (  TO_TIMESTAMP (MAX (A_ENTIME),
                                                      'YYYYMMDDHH24MISSFF6')
                                      - TO_TIMESTAMP (MIN (A_STTIME),
                                                      'YYYYMMDDHH24MISSFF6')))),
                   0), 0)
          INTO V_RETURN
          FROM DUAL
          ;
    
      RETURN V_RETURN;
    
    EXCEPTION
    
        WHEN OTHERS THEN
            RETURN NULL;
    
    END FUN_TIMEGAPCAL;
    ```

### FUN_TIMEKEY

??? note "소스코드"
    ```sql
    FUNCTION         FUN_TIMEKEY
        RETURN VARCHAR2
    IS
    
      V_RTN      VARCHAR2(20);
    
    BEGIN
    
      SELECT TO_CHAR(SYSTIMESTAMP,'YYYYMMDDHH24MISSFF')
             INTO V_RTN
        FROM DUAL
      ;
    
      RETURN V_RTN;
    
    EXCEPTION
    
        WHEN OTHERS THEN
            RETURN NULL;
    
    END FUN_TIMEKEY;
    ```

## 독립 프로시저

### PL_WRITEFILE

??? note "소스코드"
    ```sql
    PROCEDURE         PL_WriteFile(fname varchar2)
    IS
     
        v_output UTL_FILE.FILE_TYPE;
        v_result VARCHAR2(4000);
            
        CURSOR sql_cur IS
            SELECT CLIENT, COMPANY, PLANT
              FROM TW_PRODPROG;
        
         BEGIN
     
          v_output := UTL_FILE.FOPEN('LOG_DIR', fname, 'A');
    
          FOR v_cur IN sql_cur LOOP
            v_result := v_cur.CLIENT||' '||v_cur.COMPANY||' '||v_cur.PLANT;
            UTL_FILE.PUT_LINE(v_output, v_result);
          END LOOP; 
    
          UTL_FILE.FCLOSE(v_output);
    
         EXCEPTION
          WHEN UTL_FILE.INVALID_PATH THEN 
            DBMS_OUTPUT.PUT_LINE('INVALID PATH');
          WHEN UTL_FILE.INVALID_MODE THEN
            DBMS_OUTPUT.PUT_LINE('INVALID MODE');
          WHEN UTL_FILE.INVALID_OPERATION THEN
            DBMS_OUTPUT.PUT_LINE('INVALID OPERATION');
            
        END;
    ```

### RESET_SEQ

??? note "소스코드"
    ```sql
    PROCEDURE         RESET_SEQ
    AS
    
      V_DROP          VARCHAR2(32767);
      V_CREATE        VARCHAR2(32767);
      V_ALTER         VARCHAR2(32767);
    
    BEGIN
    
      SEQUENCE_RESET('SEQ_MATREQUEST');
      SEQUENCE_RESET('SEQ_MATSERIAL');
      SEQUENCE_RESET('SEQ_WORKORD');
      SEQUENCE_RESET('SEQ_SERIAL');
      SEQUENCE_RESET('SEQ_BOXNO');
      SEQUENCE_RESET('SEQ_BUNDLENO');
      SEQUENCE_RESET('SEQ_PRODPROGNO');
      SEQUENCE_RESET('SEQ_REQUEST');
      
      
      SEQUENCE_RESET_START('SEQ_INNO');
      SEQUENCE_RESET_START('SEQ_OUTNO');
      
    END RESET_SEQ;
    ```

### SEQUENCE_RESET

??? note "소스코드"
    ```sql
    PROCEDURE         SEQUENCE_RESET(S_NAME IN VARCHAR2)
    AS S_VALUE INTEGER;
    BEGIN
      EXECUTE IMMEDIATE 'ALTER SEQUENCE ' || S_NAME || ' MINVALUE 0' ;
      EXECUTE IMMEDIATE 'SELECT ' || S_NAME || '.NEXTVAL FROM DUAL' INTO S_VALUE ;
      EXECUTE IMMEDIATE 'ALTER SEQUENCE ' || S_NAME || ' INCREMENT BY -' || S_VALUE ;
      EXECUTE IMMEDIATE 'SELECT ' || S_NAME || '.NEXTVAL FROM DUAL' INTO S_VALUE ;
      EXECUTE IMMEDIATE 'ALTER SEQUENCE ' || S_NAME || ' INCREMENT BY 1' ;
    END;
    ```

### SEQUENCE_RESET_START

??? note "소스코드"
    ```sql
    PROCEDURE         SEQUENCE_RESET_START(S_NAME IN VARCHAR2)
    AS S_VALUE NUMBER;
      V_DATE  VARCHAR2(8);
      N_INIT  NUMBER;
    BEGIN
    
      V_DATE := TO_CHAR(SYSDATE,'YYYYMMDD');
    
      --EXECUTE IMMEDIATE 'ALTER SEQUENCE ' || S_NAME || ' MINVALUE 0' ;
      
      EXECUTE IMMEDIATE 'SELECT ' || S_NAME || '.NEXTVAL FROM DUAL' INTO S_VALUE ;
      
      N_INIT := TO_NUMBER(V_DATE || '0000000') - S_VALUE;
      
      EXECUTE IMMEDIATE 'ALTER SEQUENCE ' || S_NAME || ' INCREMENT BY ' || N_INIT ;
      EXECUTE IMMEDIATE 'SELECT ' || S_NAME || '.NEXTVAL FROM DUAL' INTO S_VALUE ;
      
      EXECUTE IMMEDIATE 'ALTER SEQUENCE ' || S_NAME || ' INCREMENT BY 1' ;
    
    END;
    ```
