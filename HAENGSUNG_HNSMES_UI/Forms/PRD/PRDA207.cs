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
    ///    화면명 : PRDA207<br/>
    ///      기능 : 수리 / 폐기 등록 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>

    public partial class PRDA207 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
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

        public PRDA207()
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
            LanguageInformation clsLan = new LanguageInformation();
            string sMsg;

            switch (sType)
            {
                case "PRODSN":
                case "MATSN":
                    txtSerial.EditValue = sData;

                    GetGridViewList();
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
            this.InitForm();
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

        private void btnRepair_Click(object sender, EventArgs e)
        {
            this.SetButton("REPAIR");
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            this.SetButton("DISCARD");
        }

        

        #endregion
     
        #region [Private Method]

        private void InitForm()
        {
            string _strWarehouse;

            /*수리 / 폐기 버튼 컨트롤 설정*/
            btnRepair.LookAndFeel.UseDefaultLookAndFeel = false;
            btnRepair.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;

            btnDiscard.LookAndFeel.UseDefaultLookAndFeel = false;
            btnDiscard.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;

            /*컨트롤 읽기 전용 처리*/
            txtSN.Properties.ReadOnly = true;
            txtWhloc.Properties.ReadOnly = true;
            txtWhlocName.Properties.ReadOnly = true;
            txtItemcode.Properties.ReadOnly = true;
            txtPartNo.Properties.ReadOnly = true;
            txtItemName.Properties.ReadOnly = true;
            txtSpec.Properties.ReadOnly = true;
            txtProdline.Properties.ReadOnly = true;
            txtProdlineName.Properties.ReadOnly = true;
            txtOper.Properties.ReadOnly = true;
            txtOperName.Properties.ReadOnly = true;
            txtDefect.Properties.ReadOnly = true;
            txtDefectName.Properties.ReadOnly = true;
            txtDefect2.Properties.ReadOnly = true;
            txtDefectName2.Properties.ReadOnly = true;
            txtDefect3.Properties.ReadOnly = true;
            txtDefectName3.Properties.ReadOnly = true;
            txtDefect4.Properties.ReadOnly = true;
            txtDefectName4.Properties.ReadOnly = true;
            txtDefect5.Properties.ReadOnly = true;
            txtDefectName5.Properties.ReadOnly = true;

            spiBrdqty.Properties.ReadOnly = true;

            //생산관리 - 생산 불량
            if (this.Tag.ObjectNullString() == "PRODBAD")
            {
                lcRepair.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lcDiscard.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                _strWarehouse = "6";
            }
            else //자재관리 - 자재 불량
            {
                lcRepair.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lcDiscard.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                _strWarehouse = "4";
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

        private void GetGridViewList()
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
                                           , gleWHLoc.EditValue.ObjectNullString()
                                           , txtSerial.EditValue.ObjectNullString() 
                                           , dteFromTo.StartDate
                                           , dteFromTo.EndDate }
                                           , true
                                           , "TXNTIMEKEY, BRDDATE, ITEMCODE, FROMWHLOC, DEFECT, DEFECT2, DEFECT3, DEFECT4, DEFECT5, OPER, PRODLINE, DEFECTIMG,DEFECTIMG2, DEFECTIMG3, DEFECTIMG4, DEFECTIMG5"
                                           , false//true
                                           , "BRDQTY,REPAIRQTY,DISQTY"
                                           );
            
            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();

        }

        private void SaveData()
        {
            string _sJudge;

            if (this.Tag.ObjectNullString() == "PRODBAD")
            {
                if (btnRepair.Appearance.BackColor == Color.LawnGreen)
                {
                    _sJudge = "REPAIR";
                }
                else if (btnDiscard.Appearance.BackColor == Color.LawnGreen)
                {
                    _sJudge = "DISPOSE";
                }
                else
                {
                    iDATMessageBox.ErrorMessage("MSG_ER_PRD_080", this.Text, 3); //판정(수리/폐기)를 선택하세요.
                    return;
                }
            }
            else
            {
                _sJudge = "DISPOSE";
            }

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
                                                , _sJudge
                                                , gvList.GetFocusedRowCellValue("TXNTIMEKEY").ObjectNullString()
                                                , gvList.GetFocusedRowCellValue("BRDDATE").ObjectNullString()
                                                , txtDefect.EditValue.ObjectNullString()
                                                , txtSN.EditValue.ObjectNullString()
                                                , gvList.GetFocusedRowCellValue("FROMWHLOC").ObjectNullString()
                                                , txtWhloc.EditValue.ObjectNullString()
                                                , spiBrdqty.EditValue.ObjectNullString()
                                                , txtRemarks.EditValue.ObjectNullString()
                                                , Global.Global_Variable.EHRCODE }
                                                , true
                                                );

            if (_bResult == true)
            {
                iDATMessageBox.OKMessage("DBMSG_SUCCESS", this.Text, 3);
                GetGridViewList();
            }
        }

        private void SetButton(string p_sType)
        {
            btnRepair.Appearance.Options.UseBackColor = true;
            btnDiscard.Appearance.Options.UseBackColor = true;

            switch (p_sType)
            {
                case "REPAIR":
                    btnRepair.Appearance.BackColor = Color.LawnGreen;
                    btnDiscard.Appearance.BackColor = Color.Transparent;
                    break;

                case "DISCARD":
                    btnRepair.Appearance.BackColor = Color.Transparent;
                    btnDiscard.Appearance.BackColor = Color.LawnGreen;
                    break;
            }
        }

        #endregion

        #region 일반이벤트

        private void txtSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSerial.Text.Trim() == "")
                    return;

                this.Get_BarcodeType(txtSerial.Text);

                txtSerial.Text = "";
                txtSerial.Focus();
            }
        }

        private void gleWH_EditValueChanged(object sender, EventArgs e)
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
                                                       , "1" }
                                                       , "WHLOC"
                                                       , "WHLOCNAME"
                                                       , "WHLOC, WHLOCNAME, REMARKS"
                                                       );
        }
        #endregion

    }
}
