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

namespace HAENGSUNG_HNSMES_UI.Forms.MAT
{
    //자재불량취소
    public partial class MATA205 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
    {
        // ******************************************* Base From Class ************************************
        // BASE_clsDevexpressGridUtil          DevExpress Grid 관련 Util Class.
        // BASE_db;                            웹서비스 DB처리 관련 Util Class.
        // BASE_DXGridHelper;                  DevExpress GridControl 데이터 Bind관련 Class
        // BASE_DXGridLookUpHelper;            DevExpress GridLookUp 데이터 Bind관련 Class
        // BASE_IDATLayoutUtil;                DevExpress LayoutControl Util Class.
        // BASE_Language;                      Language Util. ex) BASE_Language.GetMessageString("Code") 
        // ************************************************************************************************

        #region [Form Event]

        public MATA205()
        {
            InitializeComponent();           
        }

        private void MATA205_Load(object sender, EventArgs e)
        {

        }
        private void MATA205_Shown(object sender, EventArgs e)
        {
            MainButton_INIT.PerformClick();
        }
       

        #endregion

        #region [Button Event]

        public void InitButton_Click()
        {
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);

            Set_Init();
            gcList.DataSource = null;
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
            string _strWHLoc = "";
            string _strPartNo = "";
            string _strSN = "";
            string _strWH = "";

            _strWH = gleSearchWH.EditValue.ObjectNullString();
            _strWHLoc = gleSearchWHLoc.EditValue.ObjectNullString();
            _strPartNo = txtSearchPartNo.Text;
            _strSN = txtSearchSN.Text;
            GetGridViewList(_strWH, _strWHLoc, _strPartNo, _strSN);
        }

       
        public void SaveButton_Click()
        {
            bool _bResult = BASE_db.Execute_Proc( "PKGBAS_BRD.SET_BADREG_JUDGE"
                                                , 1
                                                , new string[] { 
                                                  "A_CLIENT"
                                                , "A_COMPANY"
                                                , "A_PLANT"
                                                , "A_TAG"
                                                , "A_TXNTIMEKEY"
                                                , "A_BRDDATE"
                                                , "A_DEFECT"
                                                , "A_SERIAL"
                                                , "A_FROMWHLOC"
                                                , "A_TOWHLOC"
                                                , "A_QTY"
                                                , "A_REMARKS"
                                                , "A_USER"  }
                                                , new string[] {  
                                                  Global.Global_Variable.CLIENT
                                                , Global.Global_Variable.COMPANY
                                                , Global.Global_Variable.PLANT
                                                , "CANCEL"
                                                , gvList.GetFocusedRowCellValue("TXNTIMEKEY").ObjectNullString()
                                                , gvList.GetFocusedRowCellValue("BRDDATE").ObjectNullString()
                                                , gvList.GetFocusedRowCellValue("DEFECT").ObjectNullString()
                                                , txtSN.EditValue.ObjectNullString()
                                                , gvList.GetFocusedRowCellValue("FROMWHLOC").ObjectNullString()
                                                , gleSearchWHLoc.EditValue.ObjectNullString()
                                                , ""
                                                , ""
                                                , Global.Global_Variable.EHRCODE }
                                                , true
                                                );
            if (_bResult)
            {
                iDATMessageBox.OKMessage("MSG_OK_REG_001", this.Text, 3);
                MainButton_Search.PerformClick();
            }
        }

       
        public void PrintButton_Click()
        {
            // 출력 버튼 클릭 이벤트
        }

       
        public void RefreshButton_Click()
        {
        }

        public void DeleteButton_Click()
        {
            // 삭제 버튼 클릭 이벤트
        }

        #endregion

        #region Scanner

        public void Data_Scan(string p_strType, string p_strData)
        {
            ProcessScanEvent(p_strType, p_strData);
        }

        public void Data_SubScan(string p_strType, string p_strData)
        {
            ProcessScanEvent(p_strType, p_strData);
        }

        private void ProcessScanEvent(string p_strType, string p_strData)
        {
            switch (p_strType)
            {
                case "MATSN":
                    txtSearchSN.Text = p_strData;
                    this.GetGridViewList(gleSearchWH.EditValue.ObjectNullString(),
                                         gleSearchWHLoc.EditValue.ObjectNullString(),
                                         txtSearchPartNo.Text,
                                         txtSearchSN.Text);
                    break;

                case "PARTNO":
                    txtPartNo.Text = p_strData;
                    break;

                default:
                    LanguageInformation clsLan = new LanguageInformation();
                    string _strMsg = clsLan.GetMessageString("MSG_ER_COMM_027"); //현재 화면에서 사용할 수 없는 바코드 입니다.
                    iDATMessageBox.WARNINGMessage(_strMsg + "\r\n" + "Type : " + p_strType + "\r\n" + "Barcode : " + p_strData, this.Text, 3);
                    break;
            }
        }

        private void Get_BarcodeType(string p_strBarcode)
        {
            WSResults _result = BASE_db.Execute_Proc( "PKGPDA_COMM.GET_BARCODETYPE"
                                                    , 1
                                                    , new string[] {
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_BARCODE" }
                                                    , new string[] {
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT
                                                    , p_strBarcode }
                                                    );

            string _strType = _result.ResultString;
            this.ProcessScanEvent(_strType, p_strBarcode);
        }

        #endregion
     
        #region [Private Method]

        private void Set_Init()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleSearchWH
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
                                                       , "4"  }
                                                       , "WAREHOUSE"
                                                       , "WAREHOUSENAME"
                                                       , "WAREHOUSE, WAREHOUSENAME, REMARKS"
                                                       );

            if ((gleSearchWH.Properties.DataSource as DataTable).Rows.Count > 1)
            {
                gleSearchWH.EditValue = gleSearchWH.Properties.GetKeyValue(1);
                gleSearchWH.Enabled = false;
            }
        }
     
        private void Set_SearchLocation(string p_strWH)
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleSearchWHLoc
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
                                                       , gleSearchWH.EditValue.ObjectNullString()
                                                       , "1" }
                                                       , "WHLOC"
                                                       , "WHLOCNAME"
                                                       , "WHLOC, WHLOCNAME, REMARKS"
                                                       );  
        }

        private void GetGridViewList(string p_strWH, string p_strWHLoc, string p_strPartNo, string p_strSN)
        {
            BASE_DXGridHelper.Bind_Grid_Int( gcList
                                           , "PKGBAS_BRD.GET_BADREG_HISTINFO"
                                           , 1
                                           , new string[] { 
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_WHLOC"
                                           , "A_SERIAL"
                                           , "A_SDATE"
                                           , "A_EDATE" }
                                           , new string[] { 
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , gleSearchWHLoc.EditValue.ObjectNullString()
                                           , txtSearchSN.EditValue.ObjectNullString()
                                           , dteFromTo.StartDate
                                           , dteFromTo.EndDate }
                                           , true
                                           , "REGDATE, DEFECT, DEFECTNAME, PARTNO, ITEMNAME, SPEC, BRDQTY, REPAIRQTY, DISQTY, SERIAL, ITEMCODE, FROMWHLOC"
                                           , true
                                           , "ITEMCODE"
                                           );

            gvList.OptionsView.ColumnAutoWidth = true;
            gvList.BestFitColumns();
        }

        #endregion

        private void gleSearchWH_EditValueChanged(object sender, EventArgs e)
        {
            gcList.DataSource = null;
            Set_SearchLocation(gleSearchWH.EditValue.ObjectNullString());
        }

        private void txtSN_EditValueChanged(object sender, EventArgs e)
        {
            spinAlterStockQty.EditValue = spinStockQty.EditValue;

            if (txtSN.Text == "NONE"  || txtSN.Text == "")
                spinAlterStockQty.Enabled = true;
            else
                spinAlterStockQty.Enabled = false;
        }

        private void gleSearchWHLoc_EditValueChanged(object sender, EventArgs e)
        {
            gcList.DataSource = null;
        }

        private void txtSearchSN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSearchSN.Text.Trim() == "")
                    return;

                this.Get_BarcodeType(txtSearchSN.Text);

                txtSearchSN.Text = "";
                txtSearchSN.Focus();
            }
        }
    }
}
