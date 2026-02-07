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
    public partial class PRDA210 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
    {
        // ******************************************* Base From Class ************************************
        // BASE_clsDevexpressGridUtil          DevExpress Grid 관련 Util Class.
        // BASE_db;                            웹서비스 DB처리 관련 Util Class.
        // BASE_DXGridHelper;                  DevExpress GridControl 데이터 Bind관련 Class
        // BASE_DXGridLookUpHelper;            DevExpress GridLookUp 데이터 Bind관련 Class
        // BASE_IDATLayoutUtil;                DevExpress LayoutControl Util Class.
        // BASE_Language;                      Language Util. ex) BASE_Language.GetMessageString("Code") 
        // ************************************************************************************************

        bool m_blCheck = true;

        #region [Form Event]

        public PRDA210()
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
            InitForm();
            MainButton_INIT.PerformClick();
            
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
            if (m_blCheck == false)
                return;

            LanguageInformation clsLan = new LanguageInformation();
            string sMsg;

            switch (sType)
            {
                case "PRODSN":
                    this.getSerialInfo(sData);
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
            //base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);
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
            txtBarCode.EditValue = null;
            txtSerial_1.EditValue = null;
            txtPartNo_1.EditValue = null;
            txtAssyPartNo_1.EditValue = null;
            spinRemainQty_1.EditValue = 0;

            txtSerial_2.EditValue = null;
            txtPartNo_2.EditValue = null;
            txtAssyPartNo_2.EditValue = null;
            spinRemainQty_2.EditValue = 0;
        }

        private void InitControl()
        {
            gcList.DataSource = null;
            InitForm();
        }

        private void getSerialInfo(string p_sData)
        {

            WSResults _result = BASE_db.Execute_Proc( "PKGPRD_ECC.GET_SERIAL_INFO"
                                                    , 1
                                                    , new string[] { 
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_SERIAL" }
                                                    , new string[] { 
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT
                                                    , p_sData }
                                                    );

            if (_result.ResultInt == 0)
            {
                if (txtSerial_1.EditValue == null)
                {
                    if (_result.ResultDataSet != null && _result.ResultDataSet.Tables[0] != null && _result.ResultDataSet.Tables[0].Rows.Count > 0)
                    {
                        txtSerial_1.EditValue = _result.ResultDataSet.Tables[0].Rows[0]["SERIAL"].ToString();
                        txtPartNo_1.EditValue = _result.ResultDataSet.Tables[0].Rows[0]["PARTNO"].ToString();
                        txtAssyPartNo_1.EditValue = _result.ResultDataSet.Tables[0].Rows[0]["ROOTPARTNO"].ToString();
                        spinRemainQty_1.EditValue = _result.ResultDataSet.Tables[0].Rows[0]["GOODQTY"].ToString();
                    }
                    else
                    {
                        iDATMessageBox.ErrorMessage("MSG_ER_COMM_032", this.Text, 3);
                    }
                }
                else
                {
                    if (_result.ResultDataSet != null && _result.ResultDataSet.Tables[0] != null && _result.ResultDataSet.Tables[0].Rows.Count > 0)
                    {
                        txtSerial_2.EditValue = _result.ResultDataSet.Tables[0].Rows[0]["SERIAL"].ToString();
                        txtPartNo_2.EditValue = _result.ResultDataSet.Tables[0].Rows[0]["PARTNO"].ToString();
                        txtAssyPartNo_2.EditValue = _result.ResultDataSet.Tables[0].Rows[0]["ROOTPARTNO"].ToString();
                        spinRemainQty_2.EditValue = _result.ResultDataSet.Tables[0].Rows[0]["GOODQTY"].ToString();
                    }
                    else
                    {
                        iDATMessageBox.ErrorMessage("MSG_ER_COMM_032", this.Text, 3);
                    }
                }
            }
        }

        private bool SaveData(string p_strSerial1, string p_strSerial2)
        {
            bool _blReturn = false;

            // 프로시져 수행
            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = 
                BASE_db.Execute_Proc( "PKGPRD_ECC.SET_PROD_SPLITMERGE"
                                    , 1
                                    , new string[] { 
                                      "A_CLIENT"
                                    , "A_COMPANY"
                                    , "A_PLANT"
                                    , "A_TYPE"
                                    , "A_SN1"
                                    , "A_SN2"
                                    , "A_SPLITQTY"
                                    , "A_IQCNO"
                                    , "A_USER" }
                                    , new string[] { 
                                     Global.Global_Variable.CLIENT
                                    , Global.Global_Variable.COMPANY
                                    , Global.Global_Variable.PLANT
                                    , "MERGE"
                                    , p_strSerial1
                                    , p_strSerial2
                                    , ""
                                    , ""
                                    , Global.Global_Variable.EHRCODE }
                                    );

            if (_Result.ResultInt == 0)
            {
                gcList.DataSource = _Result.ResultDataSet.Tables[0];

                if (Print(_Result.ResultDataSet.Tables[0], 1))
                    iDATMessageBox.OKMessage("MSG_OK_PRINT_001", this.Text, 3);

                _blReturn = true;
            }
            return _blReturn;
        }
        #endregion
        
        #region 일반이벤트
        private bool Print(DataTable dTable, int nCopies)
        {
            using (RPT.RPTA201 _rpt = new RPT.RPTA201(dTable, nCopies))
            {
                _rpt.RptPrint();
            }
            return true;
        }
        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBarCode.Text.Trim() == "")
                    return;

                this.Get_BarcodeType(txtBarCode.Text);

                txtBarCode.Text = "";
                txtBarCode.Focus();
            }
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            string p_strSerial1 = txtSerial_1.EditValue.ObjectNullString();

            string p_strSerial2 = txtSerial_2.EditValue.ObjectNullString();

            if (SaveData(p_strSerial1, p_strSerial2))
            {
                //getSerialInfo(p_strSerial);
            }
        }
        private void btnMergeInit1_Click(object sender, EventArgs e)
        {
            txtSerial_1.EditValue = null;
            txtPartNo_1.EditValue = null;
            txtAssyPartNo_1.EditValue = null;
            spinRemainQty_1.EditValue = 0;
        }

        private void btnMergeInit2_Click(object sender, EventArgs e)
        {
            txtSerial_2.EditValue = null;
            txtPartNo_2.EditValue = null;
            txtAssyPartNo_2.EditValue = null;
            spinRemainQty_2.EditValue = 0;
        }
        #endregion
   
    }
}
