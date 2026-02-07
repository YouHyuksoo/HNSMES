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
using DevExpress.XtraGrid.Views.Grid;
// User namespace
using HAENGSUNG_HNSMES_UI.Class;
using HAENGSUNG_HNSMES_UI.WebService.Access;
using GridAlias = DevExpress.XtraGrid.Views.Grid;

namespace HAENGSUNG_HNSMES_UI.Forms.MAT
{
    // 자재입고
    // 로컬/내수, 차용, 외주반납

    public partial class MATA203 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
    {
        #region [Form Event]

        IDAT.Devexpress.DXControl.IdatDxSimpleButton mNewSelBtn;
        string typegbn = string.Empty;

        public MATA203()
        {
            InitializeComponent();           
        }
        

        private void Form_Load(object sender, EventArgs e)
        {
            txtBarcode.EnterMoveNextControl = false;
            tabbedControlGroup1.SelectedTabPageIndex = 0;
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            MainButton_INIT.PerformClick();
        }

        #endregion

        #region [Button Event]

        public void InitButton_Click()
        {
            this.Set_Init();
            gleWHLoc.EditValue = null;
            gcList.DataSource = null;
            txtBarcode.Text = string.Empty;
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
        }
       
        public void SaveButton_Click()
        {
            // 바코드 입고
            if (tabbedControlGroup1.SelectedTabPageIndex == 0)
            {
                BcSave();
            }
            // IQC 입고
            else if (tabbedControlGroup1.SelectedTabPageIndex == 1)
            {
                IqcSave();
            }
            // 수량입고
            else if (tabbedControlGroup1.SelectedTabPageIndex == 2)
            {
                QtySave();
            }

            
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
            if (gvList.RowCount > 0)
            {
                string _strSN = gvList.GetRowCellValue(0, "SN").ObjectNullString();

                //업체 바코드 체크하지 않음(2016.05.30 이도화)
                //string _strVendorPartNo = gvList.GetRowCellValue(0, "VENDORPARTNO").ObjectNullString();

                //if (_strSN != "" && _strVendorPartNo != "" && p_strType != "MATSN")
                //{
                    //// 2014.10.14 홍성원 : 업체바코드와 업체LOT이 같으면 에러 (박영순B 요청)
                    
                    //if (gvList.GetRowCellValue(0, "VENDORPARTNO").ObjectNullString() == p_strData)
                    //{
                        //LanguageInformation clsLan = new LanguageInformation();
                        //string _strMsg = clsLan.GetMessageString("MSG_ER_MAT_039"); // 업체바코드와 업체LOT이 같습니다.
                        //iDATMessageBox.WARNINGMessage(_strMsg + "\r\n" + "Barcode : " + p_strData, this.Text, 3);

                        //return;
                    //}
                    
                    
                    gvList.SetRowCellValue(0, "BCDLOT", p_strData);
                    return;
                //}
            }

            switch (p_strType)
            {
                case "MATSN":
                    Scan_MatSN(p_strData);
                    break;

                case "PARTNO":
                    Scan_PartNo(p_strData);
                    break;

                //업체 바코드 체크하지 않음(2016.05.30 이도화)
                //case "VENDORPARTNO":
                    //Scan_VendorPartNo(p_strData);
                    ////Scan_VendorPartNo(p_strData.Replace("\n", ""));
                    //break;

                //default:
                    //LanguageInformation clsLan = new LanguageInformation();
                    //string _strMsg = clsLan.GetMessageString("MSG_ER_COMM_027"); //현재 화면에서 사용할 수 없는 바코드 입니다.
                    //iDATMessageBox.WARNINGMessage(_strMsg + "\r\n" + "Type : " + p_strType + "\r\n" + "Barcode : " + p_strData, this.Text, 3);
                    //break;
            }

            txtBarcode.SelectAll();
        }

        #endregion

        #region [Private Method]

        private void Set_Init()
        {

            GetLoc();
            //GetPartNo();
            //GetVendor();
        }

        private void GetLoc()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWHLoc
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
                                                       ,"WHLOC"
                                                       ,"LOCNAME"
                                                       ,"WHLOC, LOCNAME, REMARKS"
                                                       );

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleIqcWHLoc
                                                       , gleWHLoc.Properties.DataSource as DataTable
                                                       , "WHLOC"
                                                       , "LOCNAME"
                                                       , "WHLOC, LOCNAME, REMARKS"
                                                       , false
                                                       );

           BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleQtyNWHLoc
                                                      , gleWHLoc.Properties.DataSource as DataTable
                                                      , "WHLOC"
                                                      , "LOCNAME"
                                                      , "WHLOC, LOCNAME, REMARKS"
                                                      , false
                                                      );
        }

        private void GetPartNo()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleQtyPartNo
                                                       , "PKGMAT_INOUT.GET_PARTNO"
                                                       , 1
                                                       , new string[] { }
                                                       , new string[] { }
                                                       , "ITEMCODE"
                                                       , "PARTNO"
                                                       , "PARTNO,ITEMCODE"
                                                       );

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleQtyNPartNo
                                                       , gleQtyPartNo.Properties.DataSource as DataTable
                                                       , "ITEMCODE"
                                                       , "PARTNO"
                                                       , "PARTNO,ITEMCODE"
                                                       , false
                                                       );

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleCPartNo
                                                       , gleQtyPartNo.Properties.DataSource as DataTable
                                                       , "ITEMCODE"
                                                       , "PARTNO"
                                                       , "PARTNO,ITEMCODE"
                                                       , false
                                                       );
        }

        private void GetVendor()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleQtyVendor
                                                       , "PKGBAS_BASE.GET_VENDOR"
                                                       , 1
                                                       , new string[] { 
                                                         "A_COMPANY"
                                                       , "A_PURCHASE"
                                                       , "A_SALES"
                                                       , "A_OUTSC"
                                                       , "A_VIEW" }
                                                       , new string[] { 
                                                         Global.Global_Variable.COMPANY
                                                       , "Y"
                                                       , "Y"
                                                       , "N"
                                                       , "0" }
                                                       , "VENDOR"
                                                       , "VENDORNAME"
                                                       , "VENDOR,VENDORNAME"
                                                       );

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleQtyNVendor
                                                       , gleQtyVendor.Properties.DataSource as DataTable
                                                       , "VENDOR"
                                                       , "VENDORNAME"
                                                       , "VENDOR,VENDORNAME"
                                                       , false
                                                       );

        }

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


            //if (_result.ResultInt != 0)
            //{
            //    LanguageInformation clsLan = new LanguageInformation();
            //    string _strMsg = clsLan.GetMessageString("MSG_ER_COMM_027"); // 현재 화면에서 사용할 수 없는 바코드 입니다.
            //    iDATMessageBox.WARNINGMessage(_strMsg + "\r\n" + "Barcode : " + p_strBarcode, this.Text, 3);
            //}
            //else
            //{
            //    string _strType = _result.ResultString;
            //    this.ProcessScanEvent(_strType, p_strBarcode);
            //}
        }

        private void Scan_MatSN(string p_strSN)
        {
            //업체 바코드 체크하지 않음(2016.05.30 이도화)
            if (gvList.RowCount > 0)
            {
                //if (gvList.GetRowCellValue(0, "VENDORPARTNO").ObjectNullString() == "")
                //{
                    //LanguageInformation clsLan = new LanguageInformation();
                    //string _strMsg = clsLan.GetMessageString("MSG_ER_COMM_029"); //품번을 스캔(입력)하세요.
                    //iDATMessageBox.WARNINGMessage(_strMsg + "\r\n" + "Barcode : " + p_strSN, this.Text, 3);

                    //return;
                //}
                //else
                //{
                    // 2014.10.14 홍성원 : 업체LOT이 없으면 에러 (박영순B 요청)
                    if (gvList.GetRowCellValue(0, "BCDLOT").ObjectNullString() == "")
                    {
                        LanguageInformation clsLan = new LanguageInformation();
                        string _strMsg = clsLan.GetMessageString("MSG_ER_MAT_038"); // 업체LOT를 스캔하세요.
                        iDATMessageBox.WARNINGMessage(_strMsg + "\r\n" + "Barcode : " + p_strSN, this.Text, 3);

                        return;
                    }
                    
               //}
            }

            WSResults _result = BASE_db.Execute_Proc( "PKGPDA_MAT.GET_RECEIVE_SNINFO"
                                                    , 1
                                                    , new string[] {
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_SN" }
                                                    , new string[] {
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT
                                                    , p_strSN }
                                                    );

            if (_result.ResultInt != 0)
            {
                LanguageInformation clsLan = new LanguageInformation();
                string _strMsg = clsLan.GetMessageString(_result.ResultString); //현재 화면에서 사용할 수 없는 바코드 입니다.
                iDATMessageBox.WARNINGMessage(_strMsg + "\r\n", this.Text, 3);
            }
            else
            {
                this.Add_SN(_result.ResultDataSet.Tables[0]);
            }
        }

        private void Scan_PartNo(string p_strPartNo)
        {
            if (gvList.RowCount == 0)
            {
                LanguageInformation clsLan = new LanguageInformation();
                string _strMsg = clsLan.GetMessageString("MSG_ER_COMM_008"); //S/N를 스캔(입력)하세요.
                iDATMessageBox.WARNINGMessage(_strMsg + "\r\n", this.Text, 3);

                return;
            }
            //업체 바코드 체크하지 않음(2016.05.30 이도화)
            //else if (gvList.RowCount > 0)
            //{
                //if (gvList.GetRowCellValue(0, "VENDORPARTNO").ObjectNullString() != "")
                //{
                    //LanguageInformation clsLan = new LanguageInformation();
                    //string _strMsg = clsLan.GetMessageString("MSG_ER_COMM_008"); //S/N를 스캔(입력)하세요.
                    //iDATMessageBox.WARNINGMessage(_strMsg + "\r\n", this.Text, 3);

                    //return;
                //}
            //}

            if (gvList.GetRowCellValue(0, "PARTNO").ObjectNullString() == p_strPartNo)
            {
                //업체 바코드 체크하지 않음(2016.05.30 이도화)
                //gvList.SetRowCellValue(0, "VENDORPARTNO", p_strPartNo);
                return;
            }
            else
            {
                return;
            }
        }

        private void Scan_VendorPartNo(string p_strVendorPartNo)
        {
            if (p_strVendorPartNo.IndexOf("\r\n") >= 0 || p_strVendorPartNo.IndexOf("\n") >= 0)
            {
                return;
            }

            if (gvList.RowCount == 0)
            {
                LanguageInformation clsLan = new LanguageInformation();
                string _strMsg = clsLan.GetMessageString("MSG_ER_COMM_008"); //S/N를 스캔(입력)하세요.
                iDATMessageBox.WARNINGMessage(_strMsg + "\r\n", this.Text, 3);

                return;
            }
            else if (gvList.RowCount > 0)
            {
                if (gvList.GetRowCellValue(0, "VENDORPARTNO").ObjectNullString() != "")
                {
                    LanguageInformation clsLan = new LanguageInformation();
                    string _strMsg = clsLan.GetMessageString("MSG_ER_COMM_008"); //S/N를 스캔(입력)하세요.
                    iDATMessageBox.WARNINGMessage(_strMsg + "\r\n", this.Text, 3);

                    return;
                }
            }

            WSResults _return = BASE_db.Execute_Proc( "PKGPDA_MAT.CHK_VENDORPARTNO"
                                                    , 1
                                                    , new string[] {
                                                      "A_SN"
                                                    , "A_VENDORPARTNO" }
                                                    , new string[] {
                                                      gvList.GetRowCellValue(0, "SN").ObjectNullString()
                                                    , p_strVendorPartNo }
                                                    );

            if (_return.ResultInt == 0)
            {
                if (gvList.RowCount > 0)
                {
                    if (gvList.GetRowCellValue(0, "VENDORPARTNO").ObjectNullString() != "")
                    {
                        LanguageInformation clsLan = new LanguageInformation();
                        string _strMsg = clsLan.GetMessageString("MSG_ER_COMM_008"); //S/N를 스캔(입력)하세요.
                        iDATMessageBox.WARNINGMessage(_strMsg + "\r\n", this.Text, 3);

                        return;
                    }
                }

                gvList.SetRowCellValue(0, "VENDORPARTNO", p_strVendorPartNo);

                // 2014.08.29 홍성원 : 업체바코드가 17자리 이상 -> 17자리부터 끝까지 업체LOT으로 자동
                if (p_strVendorPartNo.Length >= 30)
                    gvList.SetRowCellValue(0, "BCDLOT", p_strVendorPartNo.Substring(15));

                return;
            }
            else
            {
                iDATMessageBox.ErrorMessage(_return.ResultString, this.Text, 3);
                return;
            }

        }
     
        private void Add_SN(DataTable p_dt)
        {
            GridView view = gcList.DefaultView as GridView;

            if (view.RowCount == 0)
            {
                gcList.DataSource = p_dt;
            }
            else
            {
                DataTable gcTabel = gcList.DataSource as DataTable;

                foreach (DataRow _dr in gcTabel.Rows)
                {
                    if (_dr["SN"].ObjectNullString() == p_dt.Rows[0]["SN"].ObjectNullString())
                    {
                        LanguageInformation clsLan = new LanguageInformation();
                        string _strMsg = clsLan.GetMessageString("MSG_ER_MAT_005"); //이미 스캔한 S/N입니다.
                        iDATMessageBox.WARNINGMessage(_strMsg + "\r\n" + "S/N : " + p_dt.Rows[0]["SN"].ObjectNullString(), this.Text, 3);
                        return;
                    }
                }
                DataRow dRow = gcTabel.NewRow();

                for (int nCol = 0; nCol < gcTabel.Columns.Count; nCol++)
                    dRow[nCol] = p_dt.Rows[0][nCol];

                gcTabel.Rows.InsertAt(dRow, 0);
                gcTabel.AcceptChanges();
                gcList.DataSource = gcTabel;
            }
        }

        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            LanguageInformation _clsLan = new LanguageInformation();
            string _strMsg;

            if (gvList.FocusedRowHandle >= 0 && gvList.FocusedRowHandle < gvList.RowCount)
            {
                // 선택한 항목을 삭제하시겠습니까?
                _strMsg = gvList.GetRowCellValue(gvList.FocusedRowHandle, "SN") + "\r\n" + _clsLan.GetMessageString("MSG_QS_MAT_001"); 

                if (iDATMessageBox.QuestionMessage(_strMsg, this.Text) == DialogResult.Yes)
                    gvList.DeleteRow(gvList.FocusedRowHandle);
            }
            if (gvList.RowCount == 0)
            {
                txtBarcode.Text = "";
            }
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                Get_BarcodeType(txtBarcode.Text);
        }

        private void btnLSearch_Click(object sender, EventArgs e)
        {
            gcList1.DataSource = null;
            gvList1.Columns.Clear();

            BASE_DXGridHelper.Bind_Grid_Int( gcList1
                                           , "PKGMAT_INOUT.GET_IQC_LIST"
                                           , 1
                                           , new string[] {
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_TAB"
                                           , "A_SDATE"
                                           , "A_EDATE"
                                           , "A_INVOICENO"
                                           , "A_ORDERNO"
                                           , "A_ORDERSEQ"
                                           , "A_ITEMCODE"
                                           , "A_VENDOR" }
                                           , new string[] { 
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , "MATA203.btnSearch"
                                           , dteFromTo.StartDate
                                           , dteFromTo.EndDate
                                           , ""
                                           , ""
                                           , ""
                                           , gleCPartNo.EditValue.ObjectNullString()
                                           , "" }
                                           , true
                                           , "SEL, IQCDATE, IQCNO, VENDORNAME, PARTNO, ITEMNAME, QTY, SERIAL, VENDOR, ITEMCODE, ORDERNO, IQCJUDGE, PRINTFLAG, TERMINALFLAG"
                                           , true
                                           , "QTY,ITEMCODE"
                                           );

            gvList1.OptionsView.ColumnAutoWidth = false;
            gvList1.BestFitColumns();
            gcList2.DataSource = null;
        }

        private void BcSave()
        {
            GridView view = gcList.DefaultView as GridView;

            if (view.RowCount == 0)
                return;

            if (gleWHLoc.EditValue == null)
            {
                LanguageInformation clsLan = new LanguageInformation();
                string _strMsg = clsLan.GetMessageString("MSG_ER_COMM_005"); // 위치를 선택하세요.
                iDATMessageBox.WARNINGMessage(_strMsg + "\r\n", this.Text, 3);
                return;
            }

            //업체 바코드 체크하지 않음(2016.05.30 이도화)
            if (gvList.RowCount > 0)
            {
                if (gvList.GetRowCellValue(0, "BCDLOT").ObjectNullString() == "")
                {
                    LanguageInformation clsLan = new LanguageInformation();
                    string _strMsg = clsLan.GetMessageString("MSG_ER_MAT_038"); // 업체LOT를 스캔하세요.
                    iDATMessageBox.WARNINGMessage(_strMsg + "\r\n", this.Text, 3);
                    return;
                }
            }


            DataTable _dt = gcList.DataSource as DataTable;
            string _strXML = GetDataTableToXml(_dt);

            WSResults _result = BASE_db.Execute_Proc( "PKGPDA_MAT.SET_RECEIVE"
                                                    , 1
                                                    , new string[] {
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_LOC"
                                                    , "A_XML"
                                                    , "A_REMARKS"
                                                    , "A_EHRCODE" }
                                                    , new string[] {
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT
                                                    , gleWHLoc.EditValue.ObjectNullString()
                                                    , _strXML
                                                    , memRemarks.Text
                                                    , Global.Global_Variable.EHRCODE }
                                                    );

            if (_result.ResultInt != 0)
            {
                iDATMessageBox.OKMessage("Receive Complite", this.Text, 3);
                txtBarcode.Text = string.Empty;
                return;
            }
            else
            {
                iDATMessageBox.OKMessage("Receive Complite", this.Text, 3);
                txtBarcode.Text = string.Empty;
                gcList.DataSource = null;
                return;
            }
        }

        private void IqcSave()
        {
            GridView view = gcList1.DefaultView as GridView;

            if (view.RowCount == 0)
                return;

            if (gleIqcWHLoc.EditValue == null)
            {
                LanguageInformation clsLan = new LanguageInformation();
                string _strMsg = clsLan.GetMessageString("MSG_ER_COMM_005"); // 위치를 선택하세요.
                iDATMessageBox.WARNINGMessage(_strMsg + "\r\n", this.Text, 3);
                return;
            }

            WSResults _result = BASE_db.Execute_Proc( "PKGPDA_MAT.SET_IQCRECEIVE"
                                                    , 1
                                                    , new string[] {
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_SERIAL"
                                                    , "A_LOC"
                                                    , "A_ITEMCODE"
                                                    , "A_IQCQTY"
                                                    , "A_ORDERNO"
                                                    , "A_ORDERSEQ"
                                                    , "A_INVOICENO"
                                                    , "A_VENDOR"
                                                    , "A_IQCNO"
                                                    , "A_REMARKS"
                                                    , "A_EHRCODE" }
                                                    , new string[] {
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT
                                                    , gvList1.GetRowCellValue(gvList1.FocusedRowHandle, "SERIAL").ObjectNullString()
                                                    , gleIqcWHLoc.EditValue.ObjectNullString()
                                                    , gvList1.GetRowCellValue(gvList1.FocusedRowHandle, "ITEMCODE").ObjectNullString()
                                                    , gvList1.GetRowCellValue(gvList1.FocusedRowHandle, "QTY").ObjectNullString()
                                                    , gvList1.GetRowCellValue(gvList1.FocusedRowHandle, "ORDERNO").ObjectNullString()
                                                    , "" //OrderSEQ
                                                    , "" //InvoiceNo
                                                    , gvList1.GetRowCellValue(gvList1.FocusedRowHandle, "VENDOR").ObjectNullString()
                                                    , gvList1.GetRowCellValue(gvList1.FocusedRowHandle, "IQCNO").ObjectNullString()
                                                    , "" //Remarks
                                                    , Global.Global_Variable.EHRCODE }
                                                    );

            if (_result.ResultInt != 0)
            {
                iDATMessageBox.WARNINGMessage(_result.ResultString, this.Text, 3);
                txtBarcode.Text = string.Empty;
                return;
            }
            else
            {
                iDATMessageBox.OKMessage("Receive Complite", this.Text, 3);
                btnLSearch_Click(null, null);
                BASE_DXGridHelper.Bind_Grid(gcList2,
                                            _result.ResultDataSet.Tables[0]);

                gvList2.OptionsView.ColumnAutoWidth = false;
                gvList2.BestFitColumns();
            }
        }

        private void QtySave()
        {
            if (typegbn == "")
            {
                iDATMessageBox.ErrorMessage("MSG_ER_COMM_025", this.Text, 3);
                return;
            }

            if (btnNewRecv1.Image.ObjectNullString() != "" && gcList3.DataSource == null)
            {
                if (((DataTable)gcList3.DataSource).Rows.Count < 1)
                {
                    iDATMessageBox.ErrorMessage("MSG_ER_MAT_065", this.Text, 3);
                    return;
                }
            }

            //if (((DataTable)gcList.DataSource).Rows.Count < 1 && btnNewRecv1.Image.ObjectNullString() != "")
            //{
            //    iDATMessageBox.ErrorMessage("MSG_ER_MAT_065", this.Text, 3);
            //    return;
            //}

            if (gleQtyNVendor.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.ErrorMessage("MSG_ER_COMM_007", this.Text, 3);
                gleQtyNVendor.Focus();
                return;
            }

            if (gleQtyNPartNo.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.ErrorMessage("MSG_ER_COMM_002", this.Text, 3);
                gleQtyNPartNo.Focus();
                return;
            }

            if (gleQtyNWHLoc.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.ErrorMessage("MSG_ER_COMM_005", this.Text, 3);
                gleQtyNPartNo.Focus();
                return;
            }

            //if (speQtyNUnittQty.EditValue.ObjectNullString() == "" || int.Parse(speQtyNUnittQty.EditValue.ObjectNullString()) < 1)
            //{
            //    iDATMessageBox.ErrorMessage("MSG_ER_MAT_004", this.Text, 3);
            //    speQtyNUnittQty.Focus();
            //    return;
            //}

            if (speQtyNQty.EditValue.ObjectNullString() == "" || int.Parse(speQtyNQty.EditValue.ObjectNullString()) < 1)
            {
                iDATMessageBox.ErrorMessage("MSG_ER_STOCK_014", this.Text, 3);
                speQtyNQty.Focus();
                return;
            }

            string invoiceno = string.Empty;
            string orderno = string.Empty;
            string orderseq = string.Empty;

            if (btnNewRecv1.Image != null)
            {
                invoiceno = gvList3.GetRowCellValue(gvList3.FocusedRowHandle, "INVOICE").ToString();
                orderno = gvList3.GetRowCellValue(gvList3.FocusedRowHandle, "ORDERNO").ToString();
                orderseq = gvList3.GetRowCellValue(gvList3.FocusedRowHandle, "ORDERSEQ").ToString();
            }
            else
            {
                invoiceno = string.Empty;
                orderno = string.Empty;
                orderseq = string.Empty;
            }

            // 프로시져 수행
            WSResults _result = BASE_db.Execute_Proc( "PKGPDA_MAT.SET_QTYRECEIVE"
                                                    , 1
                                                    , new string[] {
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_LOC"
                                                    , "A_TXNCODE"
                                                    , "A_ITEMCODE"
                                                    , "A_QTY"
                                                    , "A_ORDERNO"
                                                    , "A_ORDERSEQ"
                                                    , "A_INVOICENO"
                                                    , "A_VENDOR"
                                                    , "A_REMARKS"
                                                    , "A_EHRCODE" }
                                                    , new string[] {
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT
                                                    , gleQtyNWHLoc.EditValue.ObjectNullString()
                                                    , typegbn
                                                    , gvList3.GetRowCellValue(gvList3.FocusedRowHandle, "ITEMCODE").ObjectNullString()
                                                    , speQtyNQty.EditValue.ObjectNullString()
                                                    , orderno
                                                    , orderseq
                                                    , invoiceno
                                                    , gleQtyNVendor.EditValue.ObjectNullString()
                                                    , ""
                                                    , Global.Global_Variable.EHRCODE }
                                                    );


            if (_result.ResultInt == 0)
            {
                if (tabbedControlGroup1.SelectedTabPageIndex == 2)
                {
                    BASE_DXGridHelper.Bind_Grid(gcList4,
                                                _result.ResultDataSet.Tables[0]);

                    gvList4.OptionsView.ColumnAutoWidth = false;
                    gvList4.BestFitColumns();
                    if (btnNewRecv1.Image != null)
                    {
                        iDATMessageBox.OKMessage("Receive Complite", this.Text, 3);
                        btnQtySearch_Click(null, null);
                    }
                }   
            }
            else
                iDATMessageBox.ErrorMessage(_result.ResultString, this.Text, 3);

        }

        private void SetReceiveType(object sender)
        {

            bool bReadOnly = false;

            gleQtyNPartNo.EditValue = null;
            gleQtyNVendor.EditValue = null;
            speQtyNQty.EditValue = null;
            //speQtyNUnittQty.EditValue = null;

            mNewSelBtn = sender as IDAT.Devexpress.DXControl.IdatDxSimpleButton;

            switch (mNewSelBtn.Name)
            {
                case "btnNewRecv1":
                    // 로컬/내수
                    btnNewRecv1.Image = HAENGSUNG_HNSMES_UI.Properties.Resources.button_ok;
                    btnNewRecv2.Image = null;
                    btnNewRecv3.Image = null;
                    btnNewRecv4.Image = null;
                    typegbn = "LOCAL";

                    //GetOrder();
                    bReadOnly = true;
                    if (gvList3.FocusedRowHandle >= 0)
                    {
                        gleQtyNVendor.EditValue = gvList3.GetRowCellValue(gvList3.FocusedRowHandle, "VENDOR").ToString();
                        gleQtyNPartNo.EditValue = gvList3.GetRowCellValue(gvList3.FocusedRowHandle, "ITEMCODE").ToString();
                        speQtyNQty.EditValue = gvList3.GetRowCellValue(gvList3.FocusedRowHandle, "QTY").ToString();
                    }

                    break;

                case "btnNewRecv2":
                    // 차입
                    btnNewRecv1.Image = null;
                    btnNewRecv2.Image = HAENGSUNG_HNSMES_UI.Properties.Resources.button_ok;
                    btnNewRecv3.Image = null;
                    btnNewRecv4.Image = null;
                    typegbn = "BORROW";
                    break;

                case "btnNewRecv3":
                    // 차출반납
                    btnNewRecv1.Image = null;
                    btnNewRecv2.Image = null;
                    btnNewRecv3.Image = HAENGSUNG_HNSMES_UI.Properties.Resources.button_ok;
                    btnNewRecv4.Image = null;
                    typegbn = "RETURNRENTAL";
                    break;

                case "btnNewRecv4":
                    // 업체반납
                    btnNewRecv1.Image = null;
                    btnNewRecv2.Image = null;
                    btnNewRecv3.Image = null;
                    btnNewRecv4.Image = HAENGSUNG_HNSMES_UI.Properties.Resources.button_ok;
                    typegbn = "RETURNOUTSOURCING";
                    break;
            }

            gleQtyNPartNo.Properties.ReadOnly = bReadOnly;
            gleQtyNVendor.Properties.ReadOnly = bReadOnly;

            if (bReadOnly == true)
            {
                speQtyNQty.Properties.ReadOnly = true;
            }
            else
            {
                speQtyNQty.Properties.ReadOnly = false;
            }
        }

        private void btnQtySearch_Click(object sender, EventArgs e)
        {
            BASE_DXGridHelper.Bind_Grid( gcList3
                                       , "PKGMAT_INOUT.GET_LABEL_ORDER"
                                       , 1
                                       , new string[] { 
                                         "A_CLIENT"
                                       , "A_COMPANY"
                                       , "A_PLANT"
                                       , "A_TAB"
                                       , "A_VENDOR"
                                       , "A_ITEMCODE"
                                       , "A_INVOICE"
                                       , "A_SDATE"
                                       , "A_EDATE"
                                       , "A_SERIAL" }
                                       , new string[] { 
                                         Global.Global_Variable.CLIENT
                                       , Global.Global_Variable.COMPANY
                                       , Global.Global_Variable.PLANT
                                       , "QTYRECIVE"
                                       , ""
                                       , gleQtyVendor.EditValue.ObjectNullString()
                                       , gleQtyPartNo.EditValue.ObjectNullString()
                                       , txtQtyInvoice.EditValue.ObjectNullString()
                                       , ""
                                       , ""
                                       , "" }
                                       , true
                                       , ""
                                       , false
                                       );

            gvList3.OptionsView.ColumnAutoWidth = false;
            gvList3.BestFitColumns();

            SetReceiveType(btnNewRecv1);
        }

        private void btnNewRecv1_Click(object sender, EventArgs e)
        {
            SetReceiveType(sender);
        }

        private void btnNewRecv2_Click(object sender, EventArgs e)
        {
            SetReceiveType(sender);
        }

        private void btnNewRecv3_Click(object sender, EventArgs e)
        {
            SetReceiveType(sender);
        }

        private void btnNewRecv4_Click(object sender, EventArgs e)
        {
            SetReceiveType(sender);
        }

        private void gvList3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                gleQtyNVendor.EditValue = gvList3.GetRowCellValue(e.FocusedRowHandle, "VENDOR").ToString();
                gleQtyNPartNo.EditValue = gvList3.GetRowCellValue(e.FocusedRowHandle, "ITEMCODE").ToString();
                speQtyNQty.EditValue = gvList3.GetRowCellValue(e.FocusedRowHandle, "QTY").ToString();
            }
        }
    }
}
