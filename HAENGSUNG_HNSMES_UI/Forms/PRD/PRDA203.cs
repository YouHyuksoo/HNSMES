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

namespace HAENGSUNG_HNSMES_UI.Forms.PRD
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : PRDA203<br/>
    ///      기능 : 실적 라벨 발행 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    
    public partial class PRDA203 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
    {
        // ******************************************* Base From Class ************************************
        // BASE_clsDevexpressGridUtil          DevExpress Grid 관련 Util Class.
        // BASE_db;                            웹서비스 DB처리 관련 Util Class.
        // BASE_DXGridHelper;                  DevExpress GridControl 데이터 Bind관련 Class
        // BASE_DXGridLookUpHelper;            DevExpress GridLookUp 데이터 Bind관련 Class
        // BASE_IDATLayoutUtil;                DevExpress LayoutControl Util Class.
        // BASE_Language;                      Language Util. ex) BASE_Language.GetMessageString("Code") 
        // ************************************************************************************************
        public PRDA203()
        {
            InitializeComponent();
        }
        private void PRDA203_Load(object sender, EventArgs e)
        {
            
        }
        private void PRDA203_Shown(object sender, EventArgs e)
        {
            InitButton_Click();
            
        }

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
            if (rdgLabelGbn.SelectedIndex == 0)
                GetGridViewList1();
            else
                GetGridViewList2();
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

        #endregion

        #region Scan Event

        public void Data_Scan(string sType, string sData)
        {
            ProcessScanEvent();
        }

        public void Data_SubScan(string sType, string sData)
        {
            ProcessScanEvent();
        }

        private void ProcessScanEvent()
        {
        }

        #endregion

        #region 사용자 정의
        private void GetGridViewList1()
        {
            BASE_DXGridHelper.Bind_Grid_Int( gcList
                                           , "PKGPRD_PROD.GET_PRODLABELPRINT"
                                           , 1
                                           , new string[] { 
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_SDATE"
                                           , "A_EDATE" }
                                           , new string[] { 
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , dteFromTo.StartDate
                                           , dteFromTo.EndDate }
                                           , true
                                           , "ITEMCODE,ITEMTYPE,OPER,PRINTTYPE,USEFLAG,REMARKS"
                                           , false//true
                                           , "WRKORDSEQ,ORDQTY,LOTUNITQTY"
                                           );

            gvList.OptionsBehavior.Editable = false;
            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();

            gcList1.DataSource = null;

            if (gvList.RowCount > 0)
            {
                GetSubGridViewList();
            }

        }
        private void GetGridViewList2()
        {
            BASE_DXGridHelper.Bind_Grid_Int(gcList
                                           , "PKGPRD_PROD.GET_PRODLABELPRINT"
                                           , 2
                                           , new string[] { 
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_LABELGBN"
                                           , "A_SDATE"
                                           , "A_EDATE" }
                                           , new string[] { 
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , ""
                                           , dteFromTo.StartDate
                                           , dteFromTo.EndDate }
                                           , true
                                           , "ITEMCODE,ITEMTYPE,OPER,PRINTTYPE,USEFLAG,REMARKS"
                                           , false//true
                                           , "WRKORDSEQ,ORDQTY,LOTUNITQTY"
                                           );

            gvList.OptionsBehavior.Editable = true;
            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();

            gcList1.DataSource = null;

            if (gvList.RowCount > 0)
            {
                GetSubGridViewList();
            }

        }
        private void GetSubGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid_Int( gcList1
                                           , "PKGPRD_PROD.GET_PRODCREATELABELPRINT"
                                           , 1
                                           , new string[] { 
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_WORKORD"
                                           , "A_WORKORDSEQ" }
                                           , new string[] { 
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , gvList.GetFocusedRowCellValue("WRKORD").ObjectNullString()
                                           , gvList.GetFocusedRowCellValue("WRKORDSEQ").ObjectNullString() }
                                           , true
                                           , "ITEMTYPE,PRINTTYPE"
                                           , false//true
                                           , "SEQ,UNITQTY,GOODQTY"
                                           );

            gvList1.OptionsView.ColumnAutoWidth = false;
            gvList1.BestFitColumns();
 
        }

        private bool Print(DataTable dTable, int nCopies)
        {
            using (RPT.RPTA201 _rpt = new RPT.RPTA201(dTable, nCopies))
            {
                _rpt.RptPrint();
            }
            return true;
        }

        private bool Print1(DataTable dTable, int nCopies)
        {
            using (RPT.RPTA213 _rpt = new RPT.RPTA213(dTable, nCopies))
            {
                _rpt.RptPrint();
            }
            return true;
        }
        private bool Print2(DataTable dTable, int nCopies)
        {
            using (RPT.RPTA214 _rpt = new RPT.RPTA214(dTable, nCopies))
            {
                _rpt.RptPrint();
            }
            return true;
        }
        private bool Print3(DataTable dTable, int nCopies)
        {
            using (RPT.RPTA215 _rpt = new RPT.RPTA215(dTable, nCopies))
            {
                _rpt.RptPrint();
            }
            return true;
        }
        private bool Print4(DataTable dTable, int nCopies)
        {
            using (RPT.RPTA2131 _rpt = new RPT.RPTA2131(dTable, nCopies))
            {
                _rpt.RptPrint();
            }
            return true;
        }
        private bool Print5(DataTable dTable, int nCopies)
        {
            using (RPT.RPTA2162 _rpt = new RPT.RPTA2162(dTable, nCopies))
            {
                _rpt.RptPrint();
            }
            return true;
        }
        private bool Print6(DataTable dTable, int nCopies)
        {
            using (RPT.RPTA2132 _rpt = new RPT.RPTA2132(dTable, nCopies))
            {
                _rpt.RptPrint();
            }
            return true;
        }
        #endregion

        #region 컨트롤이벤트
        private void gvList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvList.FocusedRowHandle <= -1) return;
            if (rdgLabelGbn.SelectedIndex == 0)
            {
                spiOrdQty.EditValue = gvList.GetFocusedRowCellValue("ORDQTY").ObjectNullString();
                spiLotUnitQty.EditValue = gvList.GetFocusedRowCellValue("LOTUNITQTY").ObjectNullString();

                GetSubGridViewList();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (gvList1.RowCount > 0)
            {
                if (iDATMessageBox.QuestionMessage("MSG_ER_PRD_124", this.Text) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
            }
            if (gvList.GetFocusedRowCellValue("ITEMTYPE").ObjectNullString() == "1" && gvList.GetFocusedRowCellValue("PRINTTYPE").ObjectNullString() == "X")
            {
                iDATMessageBox.ErrorMessage("MSG_ER_PRD_130", this.Text, 5); //제품라벨 유형이 등록되지 않았습니다. 기준정보를 등록하세요.
                return;
            }

            // 프로시져 수행
            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = 
                BASE_db.Execute_Proc( "PKGPRD_PROD.SET_PRODCREATELABEL"
                                    , 1
                                    , new string[] { 
                                      "A_CLIENT"
                                    , "A_COMPANY"
                                    , "A_PLANT"
                                    , "A_WORKORD"
                                    , "A_ITEMCODE"
                                    , "A_ORDQTY"
                                    , "A_LOTUNITQTY"
                                    , "A_USER" }
                                    , new object[] { 
                                      Global.Global_Variable.CLIENT
                                    , Global.Global_Variable.COMPANY
                                    , Global.Global_Variable.PLANT 
                                    , gvList.GetFocusedRowCellValue("WRKORD").ObjectNullString()
                                    , gvList.GetFocusedRowCellValue("ITEMCODE").ObjectNullString()
                                    , spiOrdQty.EditValue.ObjectNullString()
                                    , spiLotUnitQty.EditValue.ObjectNullString()
                                    , Global.Global_Variable.EHRCODE }
                                    );

            if (_Result.ResultInt == 0)
            {
                if (gvList.GetFocusedRowCellValue("ITEMTYPE").ObjectNullString() == "1")
                {
                    if (gvList.GetFocusedRowCellValue("PRINTTYPE").ObjectNullString() == "G") //GEN3
                        Print1(_Result.ResultDataSet.Tables[0], 1); 
                    else if (gvList.GetFocusedRowCellValue("PRINTTYPE").ObjectNullString() == "C") //CMA
                        Print2(_Result.ResultDataSet.Tables[0], 1);
                    else if (gvList.GetFocusedRowCellValue("PRINTTYPE").ObjectNullString() == "S") //S-FRAME
                        Print4(_Result.ResultDataSet.Tables[0], 1);
                    else if (gvList.GetFocusedRowCellValue("PRINTTYPE").ObjectNullString() == "B") //BMW                       
                        Print5(_Result.ResultDataSet.Tables[0], 1);
                    else if (gvList.GetFocusedRowCellValue("PRINTTYPE").ObjectNullString() == "P") //BMW                       
                        Print6(_Result.ResultDataSet.Tables[0], 1);
                    else
                        Print3(_Result.ResultDataSet.Tables[0], 1);
                }
                else
                {
                    Print(_Result.ResultDataSet.Tables[0], 1);
                }

                iDATMessageBox.OKMessage("MSG_OK_CREATE_001", this.Text, 5);
                
                GetGridViewList1();

            }
            else
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
        }

        private void btnReprint_Click(object sender, EventArgs e)
        {
            // 프로시져 수행
            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = 
                BASE_db.Execute_Proc( "PKGPRD_PROD.GET_PRODREPRINTLABEL"
                                    , 1
                                    , new string[] { 
                                      "A_CLIENT"
                                    , "A_COMPANY"
                                    , "A_PLANT"
                                    , "A_SERIAL" }
                                    , new object[] { 
                                      Global.Global_Variable.CLIENT
                                    , Global.Global_Variable.COMPANY
                                    , Global.Global_Variable.PLANT 
                                    , gvList1.GetFocusedRowCellValue("SERIAL").ObjectNullString() }
                                    );

            if (_Result.ResultInt == 0)
            {
                if (gvList.GetFocusedRowCellValue("ITEMTYPE").ObjectNullString() == "1")
                {

                    if (gvList.GetFocusedRowCellValue("PRINTTYPE").ObjectNullString() == "G") //GEN3
                        Print1(_Result.ResultDataSet.Tables[0], 1);
                    else if (gvList.GetFocusedRowCellValue("PRINTTYPE").ObjectNullString() == "C") //CMA
                        Print2(_Result.ResultDataSet.Tables[0], 1);
                    else if (gvList.GetFocusedRowCellValue("PRINTTYPE").ObjectNullString() == "S") //S-FRAME
                        Print4(_Result.ResultDataSet.Tables[0], 1);
                    else if (gvList.GetFocusedRowCellValue("PRINTTYPE").ObjectNullString() == "B") //BMW                       
                        Print5(_Result.ResultDataSet.Tables[0], 1);
                    else if (gvList.GetFocusedRowCellValue("PRINTTYPE").ObjectNullString() == "P") //BMW                       
                        Print6(_Result.ResultDataSet.Tables[0], 1);
                    else
                        Print3(_Result.ResultDataSet.Tables[0], 1);
                    /*
                    if (gvList.GetFocusedRowCellValue("PRINTTYPE").ObjectNullString() == "G")
                        Print1(_Result.ResultDataSet.Tables[0], 1);
                    else
                        Print2(_Result.ResultDataSet.Tables[0], 1);
                    */ 
                }
                else
                {
                    Print(_Result.ResultDataSet.Tables[0], 1);
                }

                iDATMessageBox.OKMessage("MSG_OK_CREATE_001", this.Text, 5);

                GetGridViewList1();

            }
            else
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);

        }
        #endregion

        private void rdgLabelGbn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdgLabelGbn.SelectedIndex == 0)
            {
                chkAllCheck.Checked = false;
                chkAllCheck.Enabled = false;
                btnSelPrint.Enabled = false;
                btnPrint.Enabled = true;
                btnReprint.Enabled = true;

                GetGridViewList1();
            }
            else
            {
                chkAllCheck.Enabled = true;
                btnSelPrint.Enabled = true;
                btnPrint.Enabled = false;
                btnReprint.Enabled = false;

                GetGridViewList2();
            }
        }

        private void chkAllCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (rdgLabelGbn.SelectedIndex == 1)
            {
                string strChk;
                if (chkAllCheck.Checked)
                    strChk = "Y";
                else
                    strChk = "N";

                for (int i = 0; i < gvList.DataRowCount; i++)
                {
                    gvList.SetRowCellValue(i, "SEL", strChk);
                }
            }
        }

        private void btnSelPrint_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvList.RowCount; i++)
            {
                if (gvList.GetRowCellValue(i, "SEL").ObjectNullString() == "Y")
                {
                    // 프로시져 수행
                    HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result =
                        BASE_db.Execute_Proc("PKGPRD_PROD.SET_PRODCREATELABEL"
                                            , 1
                                            , new string[] { 
                                              "A_CLIENT"
                                            , "A_COMPANY"
                                            , "A_PLANT"
                                            , "A_WORKORD"
                                            , "A_ITEMCODE"
                                            , "A_ORDQTY"
                                            , "A_LOTUNITQTY"
                                            , "A_USER" }
                                            , new object[] { 
                                              Global.Global_Variable.CLIENT
                                            , Global.Global_Variable.COMPANY
                                            , Global.Global_Variable.PLANT 
                                            , gvList.GetFocusedRowCellValue("WRKORD").ObjectNullString()
                                            , gvList.GetFocusedRowCellValue("ITEMCODE").ObjectNullString()
                                            , gvList.GetFocusedRowCellValue("ORDQTY").ObjectNullString()
                                            , gvList.GetFocusedRowCellValue("LOTUNITQTY").ObjectNullString()
                                            , Global.Global_Variable.EHRCODE }
                                            );

                    if (_Result.ResultInt == 0)
                    {
                        if (gvList.GetFocusedRowCellValue("ITEMTYPE").ObjectNullString() == "1")
                        {
                            if (gvList.GetFocusedRowCellValue("PRINTTYPE").ObjectNullString() == "G")
                                Print1(_Result.ResultDataSet.Tables[0], 1);
                            else
                                Print2(_Result.ResultDataSet.Tables[0], 1);
                        }
                        else
                        {
                            Print(_Result.ResultDataSet.Tables[0], 1);
                        }
                    }
                }
            }

            iDATMessageBox.OKMessage("MSG_OK_PRINT_002", this.Text, 3); //발행이 완료 되었습니다.
        }

        
    }
}