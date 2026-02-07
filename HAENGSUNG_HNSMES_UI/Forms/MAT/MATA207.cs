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
    public partial class MATA207 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
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

        public MATA207()
        {
            InitializeComponent();
        }

        private void MATA207_Load(object sender, EventArgs e)
        {
            GetWhLoc1();
        }

        private void MATA207_Shown(object sender, EventArgs e)
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
                                                    , this.Tag.ObjectNullString()
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
            LanguageInformation clsLan = new LanguageInformation();
            string sMsg = "";

            switch (sType)
            {
                case "PRODSN":
                    this.GetProdInfo(sData);
                    break;
                case "MATSN":
                    this.GetProdInfo(sData);
                    break;
                case "NODEFINE":
                    this.GetProdInfo("NONE");
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
            ProcessScanEvent("NODEFINE", "NONE");
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
            txtSN.EnterMoveNextControl = false;
        }

        private void InitControl()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWarehouse
                                                       , "PKGPDA_COMM.GET_WH"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_TYPE" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , "MAT" }
                                                       , "VALUE"
                                                       , "DISP"
                                                       , "VALUE, DISP"
                                                       );
            gcList.DataSource = null;
        }

        private void GetProdInfo(string p_sData)
        {
            this.InitControl();
            BASE_DXGridHelper.Bind_Grid_Int( gcList
                                           , "PKGPDA_MAT.GET_STOCK_SNINFO"
                                           , 1
                                           , new string[] {
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_SN"
                                           , "A_WHLOC" }
                                           , new string [] {
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , p_sData
                                           , gleWhLoc1.EditValue.ObjectNullString() }
                                           , true
                                           , ""
                                           , true
                                           , "ITEMCODE, QTY"
                                           );

            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();
            speCorrectQty.Focus();

            if (gvList.DataRowCount < 0)
            {
                iDATMessageBox.ErrorMessage("NO DATA FOUND", this.Text, 3);
            }
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

            if (gvList.GetRowCellValue(gvList.FocusedRowHandle, "WHLOC").ObjectNullString() == "")
            {
                _bState = false;
                sMsg += clsLan.GetMessageString("MSG_ER_COMM_005") + "\n";
            }

            if (speCorrectQty.EditValue + "" == "")
            {
                _bState = false;
                sMsg += clsLan.GetMessageString("MSG_ER_STOCK_014") + "\n";
            }

            if (gvList.GetRowCellValue(gvList.FocusedRowHandle, "OTHERQTY").ObjectNullString() != "" && gvList.GetRowCellValue(gvList.FocusedRowHandle, "OTHERQTY").ObjectNullString() != "0")
            {
                _bState = false;
                sMsg += clsLan.GetMessageString("MSG_ER_STOCK_043") + "\n";
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
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWhloc
                                                       , "PKGPDA_COMM.GET_LOC"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_WH" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , this.Tag.ObjectNullString() }
                                                       , "WHLOC"
                                                       , "LOCNAME"
                                                       , "WHLOC, LOCNAME, REMARKS"
                                                       );

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWhLoc1
                                                       , "PKGPDA_COMM.GET_LOC"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_WH" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , this.Tag.ObjectNullString() }
                                                       , "WHLOC"
                                                       , "LOCNAME"
                                                       , "WHLOC, LOCNAME, REMARKS"
                                                       );
        }

        private void SaveData()
        {
            if (gleWhloc.EditValue.ObjectNullString() == "LOC002")
            {
                bool _bResult = BASE_db.Execute_Proc( "PKGPDA_MAT.SET_STOCKCORRECT"
                                                    , 1
                                                    , new string[] { 
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_LOC"
                                                    , "A_SN"
                                                    , "A_ITEMCODE"
                                                    , "A_TYPE"
                                                    , "A_STOCKQTY"
                                                    , "A_CORRECTQTY"
                                                    , "A_CORRECTTYPE"
                                                    , "A_REMARKS"
                                                    , "A_EHRCODE" }
                                                    , new string[] {
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT
                                                    , gvList.GetRowCellValue(gvList.FocusedRowHandle, "WHLOC").ObjectNullString()
                                                    , txtSN1.EditValue.ObjectNullString()
                                                    , txtItemCode.EditValue.ObjectNullString()
                                                    , txtStockType.EditValue.ObjectNullString()
                                                    , speStockQty.Value.ObjectNullString()
                                                    , speCorrectQty.Value.ObjectNullString()
                                                    , txtStockType.EditValue.ObjectNullString()
                                                    , ""
                                                    , Global.Global_Variable.EHRCODE }
                                                    , true
                                                    );

                if (_bResult == true)
                {
                    iDATMessageBox.OKMessage("DBMSG_SUCCESS", this.Text, 3);
                    this.InitControl();

                    SearchButton_Click();
                }
            }
            else
                iDATMessageBox.WARNINGMessage("MSG_ER_STOCK_010", this.Text, 3);
            
        }

        #endregion

        #region 일반이벤트

        private void txtSN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSN.Text.Trim() == "")
                    return;

                this.Get_BarcodeType(txtSN.Text);

                txtSN.Text = "";
                txtSN.Focus();
            }
        }
        #endregion
    }
}
