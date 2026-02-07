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
    public partial class MATB202 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
    {
        #region [Form Event]
        string _strWarehouse = string.Empty;

        public MATB202()
        {
            InitializeComponent();           
        }

        private void MATB202_Load(object sender, EventArgs e)
        {
            //switch (this.Tag + "")
            //{
            //    case "RECEIVE":
            //        layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //        emptySpaceItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //        break;

            //    case "RELEASE":
            //        layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //        emptySpaceItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //        break;

            //    case "RECEIVERELEASE":
            //        layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //        emptySpaceItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //        break;

            //    case "SPLITMERGE":
            //        layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //        layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //        layoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //        layoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //        emptySpaceItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //        layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //        break;
            //}
        }

        private void MATB202_Shown(object sender, EventArgs e)
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
            switch (this.Tag + "")
            {
                case "RECEIVE":
                    this.RECEIVE_GetGridViewList();
                    break;

                case "RELEASE":
                    this.RELEASE_GetGridViewList();
                    break;

                case "RECEIVERELEASE":
                    this.RECEIVERELEASE_GetGridViewList();
                    break;

                case "SPLITMERGE":
                    this.SPLITMERGE_GetGridViewList();
                    break;
            }
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

            gleType.EditValue = null;
            gcList1.DataSource = null;

            switch (this.Tag + "")
            {
                case "RECEIVE":
                    this.Set_gleType("IN");
                    break;

                case "RELEASE":
                    this.Set_gleType("OUT");
                    break;
                case "RECEIVERELEASE":
                    this.Set_gleType("ALL");
                    break;
            }

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWH
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
                                                       , _strWarehouse }
                                                       , "WAREHOUSE"
                                                       , "WAREHOUSENAME"
                                                       , "WAREHOUSE, WAREHOUSENAME, REMARKS"
                                                       );

        }

        private void Set_gleType(string p_strType)
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleType
                                                       , "PKGSYS_COMM.GET_TRANSACTION"
                                                       , 2
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_TYPE"
                                                       , "A_VIEW" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , p_strType
                                                       , "0" }
                                                       , "TXNCODE"
                                                       , "TXNNAME"
                                                       , "TXNCODE, TXNNAME, REMARKS"
                                                       );
        }

        private void RECEIVE_GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid( gcList1
                                       , "PKGBAS_MAT.GET_RECEIVE_LIST"
                                       , 1
                                       , new string[] {
                                         "A_CLIENT"
                                       , "A_COMPANY"
                                       , "A_PLANT"
                                       , "A_TXNCODE"
                                       , "A_FROMDATE"
                                       , "A_TODATE"
                                       , "A_PARTNO"
                                       , "A_SERIAL"
                                       , "A_WAREHOUSE"
                                       , "A_WHLOC" }
                                       , new string[] {
                                         Global.Global_Variable.CLIENT
                                       , Global.Global_Variable.COMPANY
                                       , Global.Global_Variable.PLANT
                                       , gleType.EditValue.ObjectNullString()
                                       , dteFromTo.StartDate
                                       , dteFromTo.EndDate
                                       , txtPartNo.Text.Trim()
                                       , txtSN.Text.Trim()
                                       , gleWHLoc.EditValue.ObjectNullString()
                                       , gleWH.EditValue.ObjectNullString() }
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

        private void RELEASE_GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid( gcList1
                                       , "PKGBAS_MAT.GET_RELEASE_LIST"
                                       , 1
                                       , new string[] {
                                         "A_CLIENT"
                                       , "A_COMPANY"
                                       , "A_PLANT"
                                       , "A_TXNCODE"
                                       , "A_FROMDATE"
                                       , "A_TODATE"
                                       , "A_PARTNO"
                                       , "A_SERIAL"
                                       , "A_WAREHOUSE"
                                       , "A_WHLOC" }
                                       , new string[] {
                                         Global.Global_Variable.CLIENT
                                       , Global.Global_Variable.COMPANY
                                       , Global.Global_Variable.PLANT
                                       , gleType.EditValue.ObjectNullString()
                                       , dteFromTo.StartDate
                                       , dteFromTo.EndDate
                                       , txtPartNo.Text.Trim()
                                       , txtSN.Text.Trim()
                                       , gleWH.EditValue.ObjectNullString()
                                       , gleWHLoc.EditValue.ObjectNullString() }
                                       , true
                                       , "TXNTIMEKEY"
                                       , false
                                       );

            gvList1.BeginUpdate();
            gvList1.OptionsView.ColumnAutoWidth = false;
            gvList1.BestFitColumns();
            gvList1.OptionsBehavior.Editable = true;
            gvList1.EndUpdate();
        }

        private void RECEIVERELEASE_GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid( gcList1
                                       , "PKGBAS_MAT.GET_RECEIVE_RELEASE_LIST"
                                       , 1
                                       , new string[] {
                                         "A_CLIENT"
                                       , "A_COMPANY"
                                       , "A_PLANT"
                                       , "A_TYPE"
                                       , "A_TXNCODE"
                                       , "A_FROMDATE"
                                       , "A_TODATE"
                                       , "A_PARTNO"
                                       , "A_SERIAL"
                                       , "A_WAREHOUSE"
                                       , "A_WHLOC" }
                                       , new string[] {
                                         Global.Global_Variable.CLIENT
                                       , Global.Global_Variable.COMPANY
                                       , Global.Global_Variable.PLANT
                                       , rdgInOut.EditValue.ObjectNullString()
                                       , gleType.EditValue.ObjectNullString()
                                       , dteFromTo.StartDate
                                       , dteFromTo.EndDate
                                       , txtPartNo.Text.Trim()
                                       , txtSN.Text.Trim()
                                       , gleWHLoc.EditValue.ObjectNullString()
                                       , gleWH.EditValue.ObjectNullString() }
                                       , true
                                       , "MODEL, TOVENDOR, FROMVENDOR, TXNTIMEKEY, TXNCODE"
                                       , false
                                       );

            gvList1.BeginUpdate();
            gvList1.OptionsView.ColumnAutoWidth = false;
            gvList1.BestFitColumns();
            gvList1.EndUpdate();
        }

        private void SPLITMERGE_GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid( gcList1
                                       , "PKGBAS_MAT.GET_SPLITMERGE_LIST"
                                       , 1
                                       , new string[] {
                                         "A_CLIENT"
                                       , "A_COMPANY"
                                       , "A_PLANT"
                                       , "A_TXNCODE"
                                       , "A_FROMDATE"
                                       , "A_TODATE"
                                       , "A_PARTNO"
                                       , "A_SERIAL"
                                       , "A_WAREHOUSE"
                                       , "A_WHLOC" }
                                       , new string[] {
                                         Global.Global_Variable.CLIENT
                                       , Global.Global_Variable.COMPANY
                                       , Global.Global_Variable.PLANT
                                       , "T902"
                                       , dteFromTo.StartDate
                                       , dteFromTo.EndDate
                                       , txtPartNo.Text.Trim()
                                       , txtSN.Text.Trim()
                                       , gleWHLoc.EditValue.ObjectNullString()
                                       , gleWH.EditValue.ObjectNullString() }
                                       , true
                                       );

            gvList1.BeginUpdate();
            gvList1.OptionsView.ColumnAutoWidth = false;
            gvList1.BestFitColumns();
            gvList1.EndUpdate();
        }



        private void Cancel()
        {
            LanguageInformation _clsLan = new LanguageInformation();

            gvList1.FocusedRowHandle = -1;

            DataRow[] dRow;

            dRow = (gcList1.DataSource as DataTable).Select(string.Format("SEL = 'Y'"));

            if (dRow.Length < 1)
            {                
                string _strLanMsg = _clsLan.GetMessageString("MSG_ER_MAT_006"); //취소할 입고 데이터를 선탁하세요.
                iDATMessageBox.WARNINGMessage(_strLanMsg, "Cancel", 3);
                return;
            }
           
            string _strType = "";

            if (this.Tag.ObjectNullString() == "RECEIVE")
                _strType = "IN";
            else
                _strType = "OUT";

            if (iDATMessageBox.QuestionMessage(_clsLan.GetMessageString("MSG_QS_MAT_001"), "Cancel") == System.Windows.Forms.DialogResult.Yes)
            {
                DataTable dtable = new DataTable();
                dtable.Columns.Add("IODATE");
                dtable.Columns.Add("TXNTIMEKEY");
                dtable.Columns.Add("TXNCODE");
                dtable.Columns.Add("SERIAL");

                
                for (int nRow = 0; nRow < dRow.Length; nRow++)
                {
                    DataRow row = dtable.NewRow();

                    if (this.Tag.ObjectNullString() == "RECEIVE")
                        row["IODATE"] = (dRow[nRow]["INDATE"] + "").Replace("-","");
                    else
                        row["IODATE"] = (dRow[nRow]["OUTDATE"] + "").Replace("-", "");

                    row["TXNTIMEKEY"] = dRow[nRow]["TXNTIMEKEY"];
                    row["TXNCODE"] = dRow[nRow]["TXNCODE"];
                    row["SERIAL"] = dRow[nRow]["SN"];

                    dtable.Rows.Add(row);
                }               

                string _strXml = this.GetDataTableToXml(dtable);

                bool bRet = BASE_db.Execute_Proc( "PKGBAS_MAT.SET_CANCEL_MATERIAL_IN_OUT_XML"
                                                , 1
                                                , new string[] {  
                                                  "A_TYPE"
                                                , "A_XML"
                                                , "A_EHRCODE" }
                                                , new string[] {
                                                  _strType
                                                , _strXml
                                                , Global.Global_Variable.EHRCODE }
                                                , true
                                                );

                if (bRet)
                    iDATMessageBox.OKMessage("MSG_OK_REG_001", this.Text, 3);

                MainButton_Search.PerformClick();
            }
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
                                                       , gleWH.EditValue.ObjectNullString()
                                                       , "0" }
                                                       , "WHLOC"
                                                       , "WHLOCNAME"
                                                       , "WHLOC, WHLOCNAME, REMARKS"
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
            if (this.Tag.ObjectNullString() == "PRODOUT")
                _strWarehouse = "3";
            else
                _strWarehouse = "4";

            if (rdgInOut.EditValue.ObjectNullString() == "IN")
            {
                this.Set_gleType("IN");
                this.Tag = "RECEIVE";
            }

            else if (rdgInOut.EditValue.ObjectNullString() == "OUT")
            {
                this.Set_gleType("OUT");
                this.Tag = "RELEASE";
            }
            else
            {
                this.Set_gleType("ALL");
                this.Tag = "RECEIVERELEASE";
            }
        }
    }
}
