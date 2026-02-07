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
    // 조회
    // 자재입고, 자재출고, 자재입/출고, Split/Merge이력

    public partial class MATB205 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
    {
        #region [Form Event]

        public MATB205()
        {
            InitializeComponent();           
        }

        private void MATB205_Load(object sender, EventArgs e)
        {

        }

        private void MATB205_Shown(object sender, EventArgs e)
        {
            this.Set_Init();
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
                    txtSN.Text = p_strData;
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

        #endregion

        #region [Button Event]

        public void InitButton_Click()
        {
            this.Set_Init();
        }

        
        public void NewButton_Click()
        {
        }


        public void EditButton_Click()
        {
        }
       
        public void StopButton_Click()
        {
        }
       
        public void SearchButton_Click()
        {
            GetGridViewList();
        }
       
        public void SaveButton_Click()
        {
            if (this.Tag.ObjectNullString() == "RECEIVE" || this.Tag.ObjectNullString() == "RELEASE")
                Cancel();
        }

        public void PrintButton_Click()
        {
        }
       
        public void RefreshButton_Click()
        {
        }

        public void DeleteButton_Click()
        {
            
        }

        #endregion
     
        #region [Private Method]

        private void Set_Init()
        {

            rdgInOut.SelectedIndex = 0;
            txtPartNo.Text = "";
            txtSN.Text = "";
            gcList1.DataSource = null;

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWH
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
                                                       , "MATRECEIVE" }
                                                       , "WHLOC"
                                                       , "LOCNAME"
                                                       , "WHLOC, LOCNAME, REMARKS"
                                                       );
        }

        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid( gcList1
                                       , "PKGBAS_MAT.GET_LABEL_LIST"
                                       , 1
                                       , new string[] {
                                         "A_CLIENT"
                                       , "A_COMPANY"
                                       , "A_PLANT"
                                       , "A_FROMDATE"
                                       , "A_TODATE"
                                       , "A_SN" }
                                       , new string[] {
                                         Global.Global_Variable.CLIENT
                                       , Global.Global_Variable.COMPANY
                                       , Global.Global_Variable.PLANT
                                       , dteFromTo.StartDate
                                       , dteFromTo.EndDate
                                       , txtSN.Text.ToString() }
                                       , true
                                       , "TOVENDOR, FROMWHLOC, FROMWH, UNDOFLAG, TXNTIMEKEY, TXNCODE"
                                       , false
                                       );

            gvList1.BeginUpdate();
            gvList1.OptionsView.ColumnAutoWidth = false;
            gvList1.BestFitColumns();

            gvList1.OptionsBehavior.Editable = true;
            gvList1.Columns["SEL"].OptionsColumn.AllowEdit = true;

            gvList1.EndUpdate();
            
        }

        private void Cancel()
        {

        }

        private void Cancel_Release()
        {
            gvList1.FocusedRowHandle = -1;

            bool bSel = false;

            for (int i = 0; i < gvList1.RowCount; i++)
            {
                if (gvList1.GetRowCellValue(i, "SEL") + "" == "Y")
                {
                    bSel = true;
                    break;
                }
            }

            if (!bSel)
            {
                LanguageInformation _clsLan = new LanguageInformation();
                string _strLanMsg = _clsLan.GetMessageString("MSG_ER_MAT_007"); //취소할 출고 데이터를 선탁하세요.
                iDATMessageBox.WARNINGMessage(_strLanMsg, "Cancel Receive", 3);
                return;
            }
            else
            {
                LanguageInformation _clsLan = new LanguageInformation();
                string _strLanMsg = _clsLan.GetMessageString("MSG_QS_MAT_001"); //

                MainButton_Search.PerformClick();
                
            }
        }

        

        private void Set_SearchLocation(string p_strWH)
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWHLoc
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
                                                       , "DISP"
                                                       , "VALUE"
                                                       , "DISP, VALUE"
                                                       );
        }

        #endregion

        private void gvList1_ShowingEditor(object sender, CancelEventArgs e)
        {
            string _strUndoFlag = gvList1.GetRowCellValue(gvList1.FocusedRowHandle, "UNDOFLAG").ObjectNullString();
            string _strTxnCode = gvList1.GetRowCellValue(gvList1.FocusedRowHandle, "TXNCODE").ObjectNullString();
            string _strLastTxnCode = gvList1.GetRowCellValue(gvList1.FocusedRowHandle, "LASTTXNCODE").ObjectNullString();
            string _strClosingFlag = gvList1.GetRowCellValue(gvList1.FocusedRowHandle, "CLOSINGFLAG").ObjectNullString();

            if (_strUndoFlag == "N" || _strTxnCode != _strLastTxnCode || _strClosingFlag == "Y")
            {
                e.Cancel = true;
            }
        }

        private void txtPartNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                MainButton_Search.PerformClick();
        }

        private void txtSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
                MainButton_Search.PerformClick();
        }

        private void gleWH_EditValueChanged(object sender, EventArgs e)
        {
            if (gleWH.EditValue == null)
                gleWHLoc.EditValue = null;
            else
                Set_SearchLocation(gleWH.EditValue.ObjectNullString());
        }

        private void rdgInOut_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
