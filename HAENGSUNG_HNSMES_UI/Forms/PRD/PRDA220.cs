using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// DevExpress namespace
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views;

// User namespace
using HAENGSUNG_HNSMES_UI.Class;
using GridAlias = DevExpress.XtraGrid.Views.Grid;
using HAENGSUNG_HNSMES_UI.WebService.Access;

namespace HAENGSUNG_HNSMES_UI.Forms.PRD
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : PRDA220<br/>
    ///      기능 : NONE 대체 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    public partial class PRDA220 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
    {

        #region [Form Event]

        public PRDA220()
        {
            InitializeComponent();
        }

        private void PRDA220_Load(object sender, EventArgs e)
        {
            
        }

        private void PRDA220_Shown(object sender, EventArgs e)
        {
            this.InitForm();
        }
       

        #endregion

        #region Scan Event

        private void Get_BarcodeType(string p_strBarcode)
        {
            WSResults _result = BASE_db.Execute_Proc( "PKGPDA_COMM.GET_BARCODETYPE"
                                                    , 1
                                                    , new string[] {
                                                      "A_CLIENT"
                                                    , "A_COMPANY"                                                                       
                                                    , "A_PLANT"
                                                    , "A_JOB"
                                                    , "A_BARCODE" }
                                                    , new string[] {
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT
                                                    , "REPLACE ITEM"
                                                    , p_strBarcode }
                                                    );

            string _strType = _result.ResultString;
            this.ProcessScanEvent(_strType, p_strBarcode);
        }

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
            if (speStockQty.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_STOCK_003", this.Text, 3);
                return;
            }

            LanguageInformation clsLan = new LanguageInformation();
            string sMsg;

            switch (sType)
            {
                case "PRODSN":
                   
                    break;
                case "MATSN":
                   
                    break;

                default:
                    sMsg = clsLan.GetMessageString("MSG_ER_COMM_027");
                    iDATMessageBox.WARNINGMessage(sMsg + "\r\n" +
                                                    "Type : " + sType + "\r\n" +
                                                    "Barcode : " + sData, this.Text, 3);
                    break;
            }

        }

        #endregion

        #region [Button Event]

        public void InitButton_Click()
        {
            // 초기화 관련 구현은 여기에 구현 ***
            this.InitControl();
        }

        
        public void NewButton_Click()
        {
            // 신규 버튼 클릭 이벤트
        }

        
        public void EditButton_Click()
        {
            // 수정 버튼 클릭 이벤트
        }

       
        public void StopButton_Click()
        {
            // 중지 버튼 클릭 이벤트
        }

       
        public void SearchButton_Click()
        {
            // 검색 버튼 클릭 이벤트
            GetGridViewList();
        }

       
        public void SaveButton_Click()
        {
            // 저장 버튼 클릭 이벤트
            if (this.Check_Data() == false)
                return;

            this.SaveData();
        }

       
        public void PrintButton_Click()
        {
            // 출력 버튼 클릭 이벤트
        }

       
        public void RefreshButton_Click()
        {
            // 새로 고침 버튼 클릭 이벤트
        }

        public void DeleteButton_Click()
        {
            // 삭제 버튼 클릭 이벤트
        }

        #endregion
     
        #region [Private Method]

        private void InitForm()
        {
            GetWhLoc1();
            InitControl();
        }

        private void InitControl()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWarehouse
                                                       , "PKGBAS_BASE.GET_WAREHOUSE"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_VIEW" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , "0" }
                                                       , "WAREHOUSE"
                                                       , "WAREHOUSENAME"
                                                       , "WAREHOUSE, WAREHOUSENAME, REMARKS"
                                                       );

            string p_strWH = gleWarehouse.EditValue.ObjectNullString();

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWhloc
                                                       , "PKGBAS_BASE.GET_LOCATION"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_WAREHOUSE"
                                                       , "A_VIEW" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , p_strWH
                                                       , "0" }
                                                       , "WHLOC"
                                                       , "WHLOCNAME"
                                                       , "WHLOC, WHLOCNAME, REMARKS"
                                                       );

            txtRemarks.Text = "";

            gcList.DataSource = null;
        }

        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid_Int( gcList
                                           , "PKGPRD_MAT.GET_STOCK_SNINFO"
                                           , 1
                                           , new string[] { 
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_SN"
                                           , "A_WHLOC" }
                                           , new string[] { 
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , "NONE"
                                           , gleWhLoc1.EditValue.ObjectNullString() }
                                           , true
                                           , ""
                                           , true
                                           , "ITEMCODE"
                                           );

            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();

            BASE_DXGridHelper.Bind_Grid_Int( gcList2
                                           , "PKGPRD_MAT.GET_REPLACE_NONE"
                                           , 1
                                           , new string[] { 
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_WHLOC"
                                           , "A_SDATE"
                                           , "A_EDATE" }
                                           , new string[] { 
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , gleWhLoc1.EditValue.ObjectNullString()
                                           , dteFromTo.StartDate
                                           , dteFromTo.EndDate }
                                           , true
                                           , ""
                                           , true
                                           , "ITEMCODE"
                                           );

            gvList2.OptionsView.ColumnAutoWidth = false;
            gvList2.BestFitColumns();

        }

        
        private bool Check_Data()
        {
            LanguageInformation clsLan = new LanguageInformation();
            string sMsg = "";

            bool _bState = true;

            if (gvList.RowCount == 0)
            {
                _bState = false;
                sMsg += clsLan.GetMessageString("MSG_ER_COMM_008") + "\n";
            }

            if (txtPartNo.EditValue + "" == "")
            {
                _bState = false;
                sMsg += clsLan.GetMessageString("MSG_ER_COMM_055") + "\n";
            }

            if (gleWhloc.EditValue + "" == "")
            {
                _bState = false;
                sMsg += clsLan.GetMessageString("MSG_ER_COMM_005") + "\n";
            }

            if (int.Parse(speStockQty.EditValue.ObjectNullString()) < int.Parse(spiQty.EditValue.ObjectNullString()))
            {
                _bState = false;
                sMsg += clsLan.GetMessageString("MSG_ER_COMM_038") + "\n"; 
            }

            if (int.Parse(spiQty.EditValue.ObjectNullString()) <= 0)
            {
                _bState = false;
                sMsg += clsLan.GetMessageString("MSG_ER_BRD_021") + "\n";
            }

            if (_bState == false)
            {
                iDATMessageBox.WARNINGMessage(sMsg, this.Text, 3);
                return false;
            }
            else
                return true;
        }

        
        private void GetWhLoc1()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWhLoc1
                                                       , "PKGBAS_BASE.GET_LOCATION2"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_VIEW" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , "0" }
                                                       , "WHLOC"
                                                       , "WHLOCNAME"
                                                       , "WHLOC,WHLOCNAME");
        }

        private void SaveData()
        {
            WSResults _result = BASE_db.Execute_Proc( "PKGPRD_MAT.SET_REPLACE_NONE"
                                                    , 1
                                                    , new string[] {
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_ITEMCODE"
                                                    , "A_SN"
                                                    , "A_WHLOC"
                                                    , "A_QTY"
                                                    , "A_USER"}
                                                    , new string[] {
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT
                                                    , txtItemCode.EditValue.ObjectNullString()
                                                    , txtSN1.EditValue.ObjectNullString()
                                                    , gleWhloc.EditValue.ObjectNullString()
                                                    , spiQty.EditValue.ObjectNullString()
                                                    , Global.Global_Variable.USER_ID }
                                                    );


            if (_result.ResultInt == 0)
            {
                iDATMessageBox.OKMessage(_result.ResultString, this.Text, 3);
                GetGridViewList();
            }
            else
            {

                iDATMessageBox.ErrorMessage(_result.ResultString, this.Text, 3);
            }
            
        }

        private bool Print(DataTable dTable, int nCopies)
        {
            using (RPT.RPTA202 _rpt = new RPT.RPTA202(dTable, nCopies))
            {
                _rpt.RptPrint();
            }
            return true;
        }

        #endregion

        #region 일반이벤트

        
        #endregion

        private void gvList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var dr = from row in (gcList2.DataSource as DataTable).AsEnumerable()
                     where row.Field<string>("SERIAL") == gvList2.GetFocusedRowCellValue("SERIAL").ObjectNullString()
                     select row;

            DataTable dtSelected = dr.CopyToDataTable();

            if (Print(dtSelected, 1))
            {
                iDATMessageBox.OKMessage("MSG_OK_PRINT_002", this.Text, 3);
            }
        }
    }
}
