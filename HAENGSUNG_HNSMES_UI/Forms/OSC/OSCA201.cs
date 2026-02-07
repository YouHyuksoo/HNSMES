using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

// DevExpress namespace
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

// User namespace
using HAENGSUNG_HNSMES_UI.Class;

using GridAlias = DevExpress.XtraGrid.Views.Grid;
using HAENGSUNG_HNSMES_UI.WebService.Access;

using DevExpress.XtraGrid;
using DevExpress.XtraSplashScreen;

namespace HAENGSUNG_HNSMES_UI.Forms.OSC
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : OSCA201<br/>
    ///      기능 : 외주 작업지시 생성 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>

    public partial class OSCA201 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
    {
        // ******************************************* Base From Class ************************************
        // BASE_clsDevexpressGridUtil          DevExpress Grid 관련 Util Class.
        // BASE_db;                            웹서비스 DB처리 관련 Util Class.
        // BASE_DXGridHelper;                  DevExpress GridControl 데이터 Bind관련 Class
        // BASE_DXGridLookUpHelper;            DevExpress GridLookUp 데이터 Bind관련 Class
        // BASE_IDATLayoutUtil;                DevExpress LayoutControl Util Class.
        // BASE_Language;                      Language Util. ex) BASE_Language.GetMessageString("Code") 
        // ************************************************************************************************
        public OSCA201()
        {
            InitializeComponent();
        }

        private void OSCA201_Load(object sender, EventArgs e)
        {

        }

        private void OSCA201_Shown(object sender, EventArgs e)
        {
            tabGr.SelectedTabPageIndex = 0;
            Set_Init_Tabpage1();
            GetGridViewList_Tabpage1();
        }

        #region 사용자정의

        private void Set_Init_Tabpage1()
        {
            /*작업지시 생성 대상 품목 조회 : BOM 기준*/
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleBom
                                                       , "GPKGPRD_PROD.GET_BOM"
                                                       , 1
                                                       , new string[] { 
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT" }
                                                       , new string[] { 
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT }
                                                       , "BOMGRP"
                                                       , "BOMGRP"
                                                       , "BOMGRP, SPEC, ITEMNAME"
                                                       );

            /*작업지시 생성 공정 조회 */
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleOper
                                                       , "GPKGPRD_PROD.GET_OPER"
                                                       , 1
                                                       , new string[] { 
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT" }
                                                       , new string[] { 
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT }
                                                       , "OPER"
                                                       , "OPERNAME"
                                                       , "OPER, OPERNAME"
                                                       );

            /*작업지시 생성 공정 조회 */
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleOper1
                                                       , "GPKGPRD_PROD.GET_OPER"
                                                       , 1
                                                       , new string[] { 
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT" }
                                                       , new string[] { 
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT }
                                                       , "OPER"
                                                       , "OPERNAME"
                                                       , "OPER, OPERNAME"
                                                       );

            /*작업지시 생성 업체 정보 조회 */
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleVendor
                                                       , "GPKGPRD_PROD.GET_VENDOR"
                                                       , 2
                                                       , new string[] { 
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_OSCFLAG"}
                                                       , new string[] { 
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , "Y"}
                                                       , "VENDOR"
                                                       , "VENDORNAME"
                                                       , "VENDOR, VENDORNAME"
                                                       );

        }

        private void GetGridViewList_Tabpage1()
        {
            BASE_DXGridHelper.Bind_Grid_Int( gcList
                                           , "PKGPRD_PROD.GET_OSC_CREATEWRKORDINFO"
                                           , 1
                                           , new string[] { 
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_SDATE"
                                           , "A_EDATE"
                                           , "A_OPER"
                                           , "A_USEFLAG"}
                                           , new string[] { 
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , dteFromTo_P0.StartDate
                                           , dteFromTo_P0.EndDate
                                           , gleOper.EditValue.ObjectNullString()
                                           , "Y"}
                                           , true
                                           , "SEL,ITEMCODE,WRKORDTYPE,WRKORDSTATE,USEFLAG, REMARKS"
                                           , false//true
                                           , "WRKORDSEQ,ITEMCODE,ORDQTY"
                                           );

            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();

        }

        private void GetGridViewList_Tabpage2()
        {
            BASE_DXGridHelper.Bind_Grid_Int(gcList1
                                           , "PKGPRD_PROD.GET_OSC_CREATEWRKORDINFO"
                                           , 1
                                           , new string[] { 
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_SDATE"
                                           , "A_EDATE"
                                           , "A_OPER"
                                           , "A_UNITNO"
                                           , "A_USEFLAG"}
                                           , new string[] { 
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , dteFromTo_P1.StartDate 
                                           , dteFromTo_P1.EndDate
                                           , ""
                                           , ""
                                           , "N"}
                                           , true
                                           , "SEL,ITEMCODE,WRKORDTYPE,WRKORDSTATE,USEFLAG, REMARKS"
                                           , false//true
                                           , "WRKORDSEQ,ITEMCODE,ORDQTY"
                                           );

            gvList1.OptionsView.ColumnAutoWidth = false;
            gvList1.BestFitColumns();

        }
        #endregion

        #region 버튼이벤트

        public void InitButton_Click()
        {
            // 초기화 관련 구현은 여기에 구현 ***
            // 상세 항목들을 모두 클리어 한다.
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);
            

        }

        public void NewButton_Click()
        {
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New);

        }

        public void EditButton_Click()
        {
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit);

        }

        public void StopButton_Click()
        {
        }

        public void SearchButton_Click()
        {
            if (tabGr.SelectedTabPageIndex == 0)
                GetGridViewList_Tabpage1();
            else if (tabGr.SelectedTabPageIndex == 1)
                GetGridViewList_Tabpage2();
        }

        public void SaveButton_Click()
        {
            // 저장전에 필수 항목에 대한 Null 값을 초기화 합니다.
            // 유효성검사 다시 수행
            base.baseDxErrorProvider.ClearErrors();
            ValidateChildren(ValidationConstraints.Visible);

            // 유효성 검사를 한다.
            if (base.baseDxErrorProvider.HasErrors)
            {
                return;
            }

        }
        public void RefreshButton_Click()
        {

        }

        public void PrintButton_Click()
        {

        }
        public void DeleteButton_Click()
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (gleBom.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.ErrorMessage("MSG_ER_MAT_012", this.Text, 3); //아이템을 선택하세요.
                return;
            }
            if (gleVendor.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.ErrorMessage("MSG_ER_COMM_007", this.Text, 3); //업체를 선택하세요.
                return;
            }
            if (gleOper1.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.ErrorMessage("MSG_ER_PRD_082", this.Text, 3); //공정을 선택하세요.
                return;
            }
            if (int.Parse(spiOrdqty.EditValue.ObjectNullString()) <= 0)
            {
                iDATMessageBox.ErrorMessage("MSG_ER_RESULT_032", this.Text, 3); //양품수량은 0보다 커야합니다.
                return;
            }


            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = BASE_db.Execute_Proc("PKGPRD_PROD.SET_OSC_CREATEWRKORD"
                                                                                            , 1
                                                                                            , new string[] {
                                                                                              "A_CLIENT"
                                                                                            , "A_COMPANY"
                                                                                            , "A_PLANT"
                                                                                            , "A_WRKDATE"
                                                                                            , "A_BOMGRP"
                                                                                            , "A_VENDOR"
                                                                                            , "A_OPER"
                                                                                            , "A_ITEMCODE"
                                                                                            , "A_WRKORDTYPE"
                                                                                            , "A_ORDQTY"
                                                                                            , "A_USER" }
                                                                                            , new string[] {
                                                                                              Global.Global_Variable.CLIENT
                                                                                            , Global.Global_Variable.COMPANY
                                                                                            , Global.Global_Variable.PLANT  
                                                                                            , ideProdDate.DateTime.ToString("yyyyMMdd")
                                                                                            , gleBom.EditValue.ObjectNullString()
                                                                                            , gleVendor.EditValue.ObjectNullString()
                                                                                            , gleOper1.EditValue.ObjectNullString()
                                                                                            , glePartNo.EditValue.ObjectNullString()
                                                                                            , "O"
                                                                                            , spiOrdqty.EditValue.ObjectNullString()
                                                                                            , Global.Global_Variable.EHRCODE }
                                                                                            );

            if (_Result.ResultInt == 0)
            {
                iDATMessageBox.OKMessage("MSG_OK_CREATE_001", this.Text, 3); //생성이 완료되었습니다.
                GetGridViewList_Tabpage1();
            }
            else
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);

        }
        #endregion

        #region Scan Event

        public void Data_Scan(string sType, string sData)
        {
            ProcessScanEvent(sType, sData);
        }

        public void Data_SubScan(string sType, string sData)
        {
            ProcessScanEvent(sType, sData);
        }

        private void ProcessScanEvent(string sType, string sData)
        {
        }

        #endregion

 


        private void gleOper_EditValueChanged(object sender, EventArgs e)
        {
            

        }

        private void gleOper1_EditValueChanged(object sender, EventArgs e)
        {
            /*공정별 생산 품목 정보 조회 */
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(glePartNo
                                                       , "GPKGPRD_PROD.GET_PARTNO"
                                                       , 3
                                                       , new string[] { 
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_BOMGRP"
                                                       , "A_OPER"}
                                                       , new string[] { 
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , gleBom.EditValue.ObjectNullString()
                                                       , gleOper1.EditValue.ObjectNullString()}
                                                       , "ITEMCODE"
                                                       , "PARTNO"
                                                       , "ITEMCODE, PARTNO"
                                                       );
        }

        private void gvList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                GetGridViewList_gcList2();
            }
        }

        private void GetGridViewList_gcList2()
        {
            BASE_DXGridHelper.Bind_Grid_Int(gcList2
                                               , "PKGPRD_PROD.GET_OSC_CREATEWRKORDDETAIL"
                                               , 1
                                               , new string[] { 
                                                 "A_CLIENT"
                                               , "A_COMPANY"
                                               , "A_PLANT"
                                               , "A_WRKDATE"
                                               , "A_VENDOR" }
                                               , new string[] { 
                                                 Global.Global_Variable.CLIENT
                                               , Global.Global_Variable.COMPANY
                                               , Global.Global_Variable.PLANT
                                               , gvList.GetFocusedRowCellValue("REGDATE").ObjectNullString()
                                               , gvList.GetFocusedRowCellValue("VENDOR").ObjectNullString() }
                                               , true
                                               , "WRKDATE,OPER,UNITNO,UNITNM"
                                               , false//true
                                               , "WRKORDSEQ,ITEMCODE,ORDQTY"
                                               );
            
            gvList2.OptionsView.ShowAutoFilterRow = false;
            gvList2.OptionsBehavior.Editable = true;
            gvList2.OptionsView.ColumnAutoWidth = false;
            gvList2.Columns["ORDQTY"].OptionsColumn.AllowEdit = true;
            
            gvList2.BestFitColumns();
            gvList2.OptionsCustomization.AllowSort = false;
            
        }
        
        #region ###작업지시 순서/수량/취소###
        /*A_JOB파라메타설정 : U :UP, D : DOWN, M : MODIFY, C: CANCEL*/
        private void btnUp_Click(object sender, EventArgs e)
        {
            bool _breturn = fnAlterWorkord("U"
                                          , gvList2.GetFocusedRowCellValue("WRKDATE").ObjectNullString()
                                          , gvList2.GetFocusedRowCellValue("OPER").ObjectNullString()
                                          , gvList2.GetFocusedRowCellValue("UNITNO").ObjectNullString()
                                          , gvList2.GetFocusedRowCellValue("WRKORDSEQ").ObjectNullString()
                                          , gvList2.GetFocusedRowCellValue("ORDQTY").ObjectNullString()
                                          );

            if (_breturn)
            {
                iDATMessageBox.OKMessage("MSG_OK_CREATE_002", this.Text, 3); //변경되었습니다.
                GetGridViewList_gcList2();
            }
        }
        private void btnDown_Click(object sender, EventArgs e)
        {
            bool _breturn = fnAlterWorkord("D"
                                          , gvList2.GetFocusedRowCellValue("WRKDATE").ObjectNullString()
                                          , gvList2.GetFocusedRowCellValue("OPER").ObjectNullString()
                                          , gvList2.GetFocusedRowCellValue("UNITNO").ObjectNullString()
                                          , gvList2.GetFocusedRowCellValue("WRKORDSEQ").ObjectNullString()
                                          , gvList2.GetFocusedRowCellValue("ORDQTY").ObjectNullString()
                                          );

            if (_breturn)
            {
                iDATMessageBox.OKMessage("MSG_OK_CREATE_002", this.Text, 3); //변경되었습니다.
                GetGridViewList_gcList2();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            bool _breturn = false;

            DataTable dt = gvList2.EX_GetChangedData();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                _breturn = fnAlterWorkord("M"
                                         , dt.Rows[i]["WRKDATE"].ObjectNullString()
                                         , dt.Rows[i]["OPER"].ObjectNullString()
                                         , dt.Rows[i]["UNITNO"].ObjectNullString()
                                         , dt.Rows[i]["WRKORDSEQ"].ObjectNullString()
                                         , dt.Rows[i]["ORDQTY"].ObjectNullString()
                                         );

                if (!_breturn)
                    return;
            }

            if (_breturn)
            {
                iDATMessageBox.OKMessage("MSG_OK_CREATE_002", this.Text, 3); //변경되었습니다.
                GetGridViewList_gcList2();
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bool _breturn = fnAlterWorkord("C"
                                          , gvList2.GetFocusedRowCellValue("WRKDATE").ObjectNullString()
                                          , gvList2.GetFocusedRowCellValue("OPER").ObjectNullString()
                                          , gvList2.GetFocusedRowCellValue("UNITNO").ObjectNullString()
                                          , gvList2.GetFocusedRowCellValue("WRKORDSEQ").ObjectNullString()
                                          , gvList2.GetFocusedRowCellValue("ORDQTY").ObjectNullString()
                                          );

            if (_breturn)
            {
                iDATMessageBox.OKMessage("MSG_OK_CREATE_002", this.Text, 3); //변경되었습니다.
                GetGridViewList_gcList2();
            }
        }

        private bool fnAlterWorkord(string _strJob, string _strWrkdate, string _strOper, string _strUnitno, string _strWrkordseq, string _strOrdqty)
        {
            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = BASE_db.Execute_Proc("PKGPRD_PROD.SET_ALTERWRKORD"
                                                                                            , 1
                                                                                            , new string[] {
                                                                                              "A_CLIENT"
                                                                                            , "A_COMPANY"
                                                                                            , "A_PLANT"
                                                                                            , "A_JOB"
                                                                                            , "A_WRKDATE"
                                                                                            , "A_OPER"
                                                                                            , "A_UNITNO"
                                                                                            , "A_WRKORDSEQ"
                                                                                            , "A_ORDQTY"
                                                                                            , "A_USER"}
                                                                                            , new string[] {
                                                                                              Global.Global_Variable.CLIENT
                                                                                            , Global.Global_Variable.COMPANY
                                                                                            , Global.Global_Variable.PLANT  
                                                                                            , _strJob
                                                                                            , _strWrkdate
                                                                                            , _strOper
                                                                                            , _strUnitno
                                                                                            , _strWrkordseq
                                                                                            , _strOrdqty
                                                                                            , Global.Global_Variable.EHRCODE }
                                                                                            );

            if (_Result.ResultInt == 0)
            {
                return true;
            }
            else
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);

            return false;
 
        }
        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvList2.RowCount; i++)
            {
                if (gvList2.GetRowCellValue(i, "SEL").ObjectNullString() == "Y")
                {
                    HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = BASE_db.Execute_Proc("PKGPRD_PROD.GET_CREATEWRKORDPRINT"
                                                                                            , 1
                                                                                            , new string[] {
                                                                                              "A_CLIENT"
                                                                                            , "A_COMPANY"
                                                                                            , "A_PLANT"
                                                                                            , "A_WRKORD"}
                                                                                            , new string[] {
                                                                                              Global.Global_Variable.CLIENT
                                                                                            , Global.Global_Variable.COMPANY
                                                                                            , Global.Global_Variable.PLANT  
                                                                                            , gvList2.GetRowCellValue(i, "WRKORD").ObjectNullString() }
                                                                                            );

                    if (_Result.ResultInt == 0)
                    {
                        if (_Result.ResultDataSet.Tables[0].Rows.Count > 0)
                        {
                            int iPrintCnt = int.Parse(_Result.ResultDataSet.Tables[0].Rows[0]["PRINTCNT"].ObjectNullString());
                            Print(_Result.ResultDataSet.Tables[0], iPrintCnt);
                        }
                    }
                }
            }

            iDATMessageBox.OKMessage("MSG_OK_PRINT_002", this.Text, 3); //발행이 완료 되었습니다.
        }

        private bool Print(DataTable dTable, int nCopies)
        {
            using (RPT.RPTA210 _rpt = new RPT.RPTA210(dTable, nCopies))
            {
                _rpt.RptPrint();
            }
            return true;
        }

        private void gcList2_DoubleClick(object sender, EventArgs e)
        {
            string vPartNo = gvList2.GetFocusedRowCellValue("PARTNO").ObjectNullString();
            string vWrkord = gvList2.GetFocusedRowCellValue("WRKORD").ObjectNullString();
            string vOper = gvList2.GetFocusedRowCellValue("OPER").ObjectNullString();
            string vUnitNo = gvList2.GetFocusedRowCellValue("UNITNO").ObjectNullString();
            string vUnitNm = gvList2.GetFocusedRowCellValue("UNITNM").ObjectNullString();

            if (vPartNo != null)
            {
                //using (PopUp.POP_PRDA201 pop = new PopUp.POP_PRDA201(vWrkord,vPartNo,vOper,vUnitNo, vUnitNm))
                //{
                //    if (DialogResult.OK == pop.ShowDialog(this))
                //    {
                //        GetGridViewList_Tabpage1();
                //    }
                //}

            }
        }
    }
}