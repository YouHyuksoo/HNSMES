using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views;
using HAENGSUNG_HNSMES_UI.Class;
using GridAlias = DevExpress.XtraGrid.Views.Grid;
using HAENGSUNG_HNSMES_UI.WebService.Access;

namespace HAENGSUNG_HNSMES_UI.Forms.PRD
{
    public partial class MATB209 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
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

        public MATB209()
        {
            InitializeComponent();
        }
                
        private void Form_Load(object sender, EventArgs e)
        {            
           
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            // ************************************************************************************
            // 컨트롤 초기화는 필수적으로 Shown이벤트에 작성을 하도록 합니다.
            // ************************************************************************************
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
            if (gleDefect.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_BRD_012", this.Text, 3);
                return;
            }

            LanguageInformation clsLan = new LanguageInformation();
            string sMsg = "";

            switch (sType)
            {
                case "PRODSN":
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

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleDefect
                                                       , "PKGBAS_OQC.GET_DEFECT"
                                                       , 1
                                                       , new string[] { "A_PLANT" }
                                                       , new string[] { Global.Global_Variable.PLANT }
                                                       , "DEFECT"
                                                       , "DEFECTNAME"
                                                       , "DEFECT,DEFECTNAME"
                                                       );

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleOper
                                                       , "PKGBAS_BASE.GET_OPER"
                                                       , 1
                                                       , new string[] { "A_PLANT" , "A_VIEW" }
                                                       , new string[] { Global.Global_Variable.PLANT, "0" }
                                                       , "OPER"
                                                       , "OPERNAME"
                                                       , "OPERNAME, REMARKS "
                                                       );

        }

        private void InitControl()
        {
            gleOper.EditValue = null;
            gleDefect.EditValue = null;
            txtRemarks.Text = "";

            gcList.DataSource = null;
        }

        private void GetProdInfo(string p_sData)
        {
            WSResults _result = BASE_db.Execute_Proc( "PKGBAS_OQC.GET_SNINFO"
                                                    , 1
                                                    , new string[] { "A_TYPE", "A_SERIAL" }
                                                    , new string[] { "BADREG", p_sData }
                                                    );

            if (_result.ResultInt == 0)
            {
                for (int i = 0; i < gvList.RowCount; i++)
                {
                    if (gvList.GetRowCellValue(i, "SERIAL").ToString() == _result.ResultDataSet.Tables[0].Rows[0]["SERIAL"].ToString())
                    {
                        LanguageInformation _clsLan = new LanguageInformation();
                        string _sMsg = "";
                        _sMsg += "S/N    : " + _result.ResultDataSet.Tables[0].Rows[0]["SERIAL"].ToString() + "\n";
                        _sMsg += "PartNo : " + _result.ResultDataSet.Tables[0].Rows[0]["PARTNO"].ToString() + "\n";
                        _sMsg += _clsLan.GetMessageString("MSG_QS_PRD_001");

                        if (iDATMessageBox.QuestionMessage(_sMsg, this.Text) == System.Windows.Forms.DialogResult.Yes)
                            gvList.DeleteRow(i);
                        
                        return;
                    }
                }

                this.AddProdSN(_result.ResultDataSet.Tables[0]);

            }
            else
                iDATMessageBox.ErrorMessage(_result.ResultString, this.Text, 3);

        }

        private void AddProdSN(DataTable p_dtProdSN)
        {
            if (gvList.RowCount == 0)
                gcList.DataSource = p_dtProdSN;
            else
            {


                DataTable _dt = gcList.DataSource as DataTable;

                DataRow dRow = _dt.NewRow();

                for (int nCol = 0; nCol < _dt.Columns.Count; nCol++)
                    dRow[nCol] = p_dtProdSN.Rows[0][nCol];

                _dt.Rows.InsertAt(dRow, 0);
                gcList.DataSource = _dt;

                gvList.FocusedRowHandle = 0;
            }

            gvList.BestFitColumns();
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

            if (gleOper.EditValue.ObjectNullString() == "")
            {
                _bState = false;
                sMsg += clsLan.GetMessageString("MSG_ER_PRD_082") + "\n";
            }

            if (gleDefect.EditValue.ObjectNullString() == "")
            {
                _bState = false;
                sMsg += clsLan.GetMessageString("MSG_ER_BRD_012") + "\n";
            }

            if (_bState == false)
            {
                iDATMessageBox.WARNINGMessage(sMsg, this.Text, 3);
                return false;
            }
            else
                return true;
        }

        private void SaveData()
        {
            DataTable _dt = gcList.DataSource as DataTable;
            string _strXML = "";
            _strXML = GetDataTableToXml(_dt);

            bool _bResult = BASE_db.Execute_Proc( "PKGBAS_OQC.PUT_BADREG_SN"
                                                , 1
                                                , new string[] { 
                                                  "A_XML"
                                                , "A_OPER"
                                                , "A_DEFECT"
                                                , "A_REMARKS"
                                                , "A_EHRCODE" }
                                                , new string[] {  
                                                  _strXML
                                                , gleOper.EditValue.ObjectNullString()
                                                , gleDefect.EditValue.ObjectNullString()
                                                , txtRemarks.EditValue.ObjectNullString()
                                                , Global.Global_Variable.EHRCODE }
                                                , true
                                                );

            if (_bResult == true)
            {
                iDATMessageBox.OKMessage("DBMSG_SUCCESS", this.Text, 3);

                this.InitControl();
            }
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
