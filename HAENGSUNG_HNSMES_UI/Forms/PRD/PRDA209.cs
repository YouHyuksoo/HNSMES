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
    public partial class PRDA209 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
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

        public PRDA209()
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
            txtBarCode.EditValue = string.Empty;
            txtSerial.EditValue = string.Empty;
            txtPartNo.EditValue = string.Empty;
            txtAssyPartNo.EditValue = string.Empty;
            spinRemainQty.EditValue = 0;
        }

        private void InitControl()
        {
            gcList.DataSource = null;
            InitForm();
        }

        private void getSerialInfo(string p_sData)
        {
            InitControl();
        
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
                txtSerial.EditValue = _result.ResultDataSet.Tables[0].Rows[0]["SERIAL"].ToString();
                txtPartNo.EditValue = _result.ResultDataSet.Tables[0].Rows[0]["PARTNO"].ToString();
                txtAssyPartNo.EditValue = _result.ResultDataSet.Tables[0].Rows[0]["ROOTPARTNO"].ToString();
                spinRemainQty.EditValue = _result.ResultDataSet.Tables[0].Rows[0]["GOODQTY"].ToString();
            }
        }

        private bool SaveData(string p_strSerial, string p_strQty)
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
                                    , "SPLIT"
                                    , p_strSerial
                                    , ""
                                    , p_strQty
                                    , ""
                                    , Global.Global_Variable.EHRCODE }
                                    );

            if (_Result.ResultInt == 0)
            {
                DataTable dt = _Result.ResultDataSet.Tables[0].Clone();
                dt.Merge(_Result.ResultDataSet.Tables[0]);
                dt.Merge(_Result.ResultDataSet.Tables[1]);

                gcList.DataSource = dt;

                if (Print(_Result.ResultDataSet.Tables[0], 1))
                    if (Print(_Result.ResultDataSet.Tables[1], 1))
                    {
                        iDATMessageBox.OKMessage("MSG_OK_PRINT_001", this.Text, 3);
                    }


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

        private void btnSplit_Click(object sender, EventArgs e)
        {
            string sMsg;
            LanguageInformation clsLan = new LanguageInformation();
            if (spinSplitQty.EditValue.ObjectNullString() == "0")
            {
                sMsg = clsLan.GetMessageString("MSG_ER_STOCK_009");
                iDATMessageBox.WARNINGMessage(sMsg, this.Text, 3);
                return;
            }

            if (spinRemainQty.Value < spinSplitQty.Value)
            {
                sMsg = clsLan.GetMessageString("MSG_ER_STOCK_008");
                iDATMessageBox.WARNINGMessage(sMsg, this.Text, 3);
                return;
            }

            string p_strSerial = txtSerial.EditValue.ObjectNullString();
            string p_strQty = spinSplitQty.EditValue.ObjectNullString();
            if (SaveData(p_strSerial, p_strQty))
            {
                //getSerialInfo(p_strSerial);
            }
        }
        #endregion
    }
}
