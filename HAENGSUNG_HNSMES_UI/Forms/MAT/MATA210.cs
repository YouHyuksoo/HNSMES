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
    public partial class MATA210 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
    {

        #region [Form Event]

        public MATA210()
        {
            InitializeComponent();
        }

        private void MATA210_Load(object sender, EventArgs e)
        {
            GetPartNo(); 
            GetWhLoc1();
        }

        private void MATA210_Shown(object sender, EventArgs e)
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
            string sMsg = "";

            switch (sType)
            {
                case "PRODSN":
                    this.GetProdInfo(sData);
                    break;
                case "MATSN":
                    this.GetProdInfo(sData);
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
            GetProdInfo("");
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

        private void GetProdInfo(string p_sData)
        {
            this.InitControl();

            WSResults _result = BASE_db.Execute_Proc( "PKGPDA_MAT.GET_STOCK_SNINFO3"
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
                                                    , p_sData
                                                    , gleWhLoc1.EditValue.ObjectNullString() }
                                                    );

            if (_result.ResultInt == 0)
            {
                BASE_DXGridHelper.Bind_Grid( gcList
                                           , _result.ResultDataSet.Tables[0]
                                           , true
                                           , ""
                                           , true
                                           );

                gvList.OptionsView.ColumnAutoWidth = false;
                gvList.BestFitColumns();
                gleItemCode.Focus();
            }
            else
                iDATMessageBox.ErrorMessage(_result.ResultString, this.Text, 3);

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


            if (gleItemCode.EditValue + "" == "")
            {
                _bState = false;
                sMsg += clsLan.GetMessageString("MSG_ER_COMM_002") + "\n";
            }

            if (_bState == false)
            {
                iDATMessageBox.WARNINGMessage(sMsg, this.Text, 3);
                return false;
            }
            else
                return true;
        }

        /*PARTNO 조회 함수*/
        private void GetPartNo()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleItemCode
                                                       , "PKGBAS_BASE.GET_ITEM"
                                                       , 2
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_VIEW"
                                                       , "A_ITEMTYPE" }
                                                       , new string[] { 
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , "0"
                                                       , gvList.GetRowCellValue(gvList.FocusedRowHandle, "ITEMTYPE").ObjectNullString() }
                                                       , "ITEMCODE"
                                                       , "PARTNO"
                                                       , "PARTNO,ITEMNAME,SPEC"
                                                       );
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
                                                       , "WHLOC,WHLOCNAME"
                                                       );
        }

        private void SaveData()
        {
            string invoiceno = gvList.GetRowCellValue(gvList.FocusedRowHandle, "INVOICE").ObjectNullString();
            string orderno = gvList.GetRowCellValue(gvList.FocusedRowHandle, "ORDERNO").ObjectNullString();
            string orderseq = gvList.GetRowCellValue(gvList.FocusedRowHandle, "ORDERSEQ").ObjectNullString();
            string vendor = gvList.GetRowCellValue(gvList.FocusedRowHandle, "VENDOR").ObjectNullString();
            string partno_old = gvList.GetRowCellValue(gvList.FocusedRowHandle, "ITEMCODE").ObjectNullString();
            string partno = gleItemCode.EditValue.ObjectNullString();
            string qty = gvList.GetRowCellValue(gvList.FocusedRowHandle, "QTY").ObjectNullString();


            if (partno_old == partno)
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_COMM_088", this.Text, 3);
                return;
            }

            CreateSN( invoiceno
                    , orderno
                    , orderseq
                    , vendor
                    , partno
                    , qty
                    , qty
                    , "LOCAL"
                    , "");
            
        }

        private void CreateSN(string invoiceno, string orderno, string orderseq, string vendor, string itemcode, string unitqty, string qty, string txncode, string iqcno)
        {
            // 프로시져 수행
            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = 
                BASE_db.Execute_Proc( "PKGMAT_INOUT.SET_NEW_CREATESN"
                                    , 1
                                    , new string[] { 
                                      "A_CLIENT"
                                    , "A_COMPANY"
                                    , "A_PLANT"
                                    , "A_TYPE"
                                    , "A_ORDERNO"
                                    , "A_ORDERSEQ"
                                    , "A_INVOICENO"
                                    , "A_VENDOR"
                                    , "A_ITEMCODE"
                                    , "A_UNITQTY"
                                    , "A_INQTY"
                                    , "A_TXNCODE"
                                    , "A_BCDDATA"
                                    , "A_BEFSN"
                                    , "A_BCDLOT"
                                    , "A_MAKER"
                                    , "A_SLIPNO"
                                    , "A_IQCNO"
                                    , "A_USER" }
                                    , new object[] {
                                      Global.Global_Variable.CLIENT
                                    , Global.Global_Variable.COMPANY
                                    , Global.Global_Variable.PLANT
                                    , "REPLACE"
                                    , orderno
                                    , orderseq
                                    , invoiceno
                                    , vendor
                                    , itemcode
                                    , unitqty
                                    , qty
                                    , txncode
                                    , null
                                    , null //BEFSN
                                    , null
                                    , null //MAKER
                                    , null //SLIPNO
                                    , iqcno
                                    , Global.Global_Variable.EHRCODE }
                                    );



            if (_Result.ResultInt == 0)
            {
                BASE_DXGridHelper.Bind_Grid( gcList2
                                           , _Result.ResultDataSet.Tables[0]);

                gvList2.OptionsView.ColumnAutoWidth = false;
                gvList2.BestFitColumns();

                int nCopies = 1;

                DataTable dtPrint = _Result.ResultDataSet.Tables[0].Clone();

                for (int nRow = 0; nRow < _Result.ResultDataSet.Tables[0].Rows.Count; nRow++)
                {
                    dtPrint.Clear();
                    dtPrint.ImportRow(_Result.ResultDataSet.Tables[0].Rows[nRow]);

                    Print(dtPrint, nCopies);
                }
            }
            else
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);

            bool _bResult = BASE_db.Execute_Proc( "PKGPDA_MAT.SET_REPLACEITEM"
                                                , 1
                                                , new string[] { 
                                                  "A_CLIENT"
                                                , "A_COMPANY"
                                                , "A_PLANT"
                                                , "A_LOC"
                                                , "A_SN"
                                                , "A_SN_NEW"
                                                , "A_TYPE"
                                                , "A_ITEMCODE1"
                                                , "A_ITEMCODE2"
                                                , "A_STOCKQTY"
                                                , "A_REMARKS"
                                                , "A_EHRCODE" }
                                                , new string[] {
                                                  Global.Global_Variable.CLIENT
                                                , Global.Global_Variable.COMPANY
                                                , Global.Global_Variable.PLANT
                                                , gleWhloc.EditValue.ObjectNullString()
                                                , txtSN1.EditValue.ObjectNullString()
                                                , gvList2.GetRowCellValue(gvList.FocusedRowHandle, "SERIAL").ObjectNullString()
                                                , txtStockType.EditValue.ObjectNullString()
                                                , txtItemCode.EditValue.ObjectNullString()
                                                , gleItemCode.EditValue.ObjectNullString()
                                                , speStockQty.Value.ObjectNullString()
                                                , ""
                                                , Global.Global_Variable.EHRCODE }
                                                , true
                                                );

            if (_bResult == true)
            {
                iDATMessageBox.OKMessage("DBMSG_SUCCESS", this.Text, 3);
                this.InitControl();
            }

            gcList.DataSource = null;
            gcList2.DataSource = null;

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

        private void gvList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleItemCode
                                                       , "PKGBAS_BASE.GET_ITEM"
                                                       , 2
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_VIEW"
                                                       , "A_ITEMTYPE" }
                                                       , new string[] { 
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , "0"
                                                       , gvList.GetRowCellValue(gvList.FocusedRowHandle, "ITEMTYPE").ObjectNullString() }
                                                       , "ITEMCODE"
                                                       , "PARTNO"
                                                       , "PARTNO,ITEMNAME,SPEC"
                                                       );
        }
    }
}
