#pragma warning disable IDE1006 // Naming Styles
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
// DevExpress namespace
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views;

// User namespace
using HAENGSUNG_HNSMES_UI.Class;
using GridAlias = DevExpress.XtraGrid.Views.Grid;
using HAENGSUNG_HNSMES_UI.WebService.Access;

using DevExpress.XtraSplashScreen;

namespace HAENGSUNG_HNSMES_UI.Forms.PRD
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : PRDA219<br/>
    ///      기능 : 통전검사 라벨 발행(외주) <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>

    public partial class PRDA219 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
    {
        // ******************************************* Base From Class ************************************
        // BASE_clsDevexpressGridUtil          DevExpress Grid 관련 Util Class.
        // BASE_db;                            웹서비스 DB처리 관련 Util Class.
        // BASE_DXGridHelper;                  DevExpress GridControl 데이터 Bind관련 Class
        // BASE_DXGridLookUpHelper;            DevExpress GridLookUp 데이터 Bind관련 Class
        // BASE_IDATLayoutUtil;                DevExpress LayoutControl Util Class.
        // BASE_Language;                      Language Util. ex) BASE_Language.GetMessageString("Code") 
        // ************************************************************************************************

        string strProdStatus = string.Empty; //작업모드
        
        int itrycheck = 3;

        Color ColorDefault;

        private Thread t = null;
        private delegate void SetThreadCallback();

        public PRDA219()
        {
            InitializeComponent();
        }

        private void PRDA219_Load(object sender, EventArgs e)
        {

        }

        private void PRDA219_Shown(object sender, EventArgs e)
        {
            // ************************************************************************************
            // 컨트롤 초기화는 필수적으로 Shown이벤트에 작성을 하도록 합니다.
            // ************************************************************************************
            SplashScreenManager.ShowForm(typeof(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM), true, false);
            SplashScreenManager.Default.SendCommand(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM.WaitFormCommand.SetDescription, "Loading...");
            PicTop.Image = Image.FromFile(Application.StartupPath + @"\IMAGE\TOP.gif");
            idatDxPictureEdit1.Image = Image.FromFile(Application.StartupPath + @"\IMAGE\New Project.gif");
            InitForm();
            SplashScreenManager.CloseForm(true);
        }

        private void PRDA215_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings_IDAT.Default.PassLabel = spiRemainPassLabel.EditValue.ObjectNullString();
            Settings_IDAT.Default.NGLabel = spiRemainNGLabel.EditValue.ObjectNullString();
            Settings_IDAT.Default.Save();
        }

        #region Scan Event

        private void Get_BarcodeType(string p_strBarcode)
        {
            string _strType = "NODEFINE";

            if (p_strBarcode.Trim() != "OK")
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

                _strType = _result.ResultString;
            }

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

            lblSerialPortMessage.ForeColor = Color.White;
            lblSerialPortMessage.Text = " [ " + DateTime.Now.ToString("HH:mm:ss") + " ] " + sData.Trim();

            switch (sType)
            {
                case "UNITNO":
                    if (btnProdReady.Appearance.BackColor == Color.LawnGreen)
                    {
                        gleEQP.EditValue = sData;
                    }
                    break;
                case "WORKER":
                    if (btnProdReady.Appearance.BackColor == Color.LawnGreen)
                    {
                        if (gleWorker.EditValue.ObjectNullString() == "")
                            gleWorker.EditValue = sData;
                        else
                            gleWorker2.EditValue = sData;
                    }
                    break;
                case "PARTNO":
                    //glePartNo.EditValue = sData;
                    break;
                case "WORKORDER":
                    if (btnProdReady.Appearance.BackColor == Color.LawnGreen)
                    {
                        iDATMessageBox.ErrorMessage("MSG_ER_COMM_027", this.Text, 3); //현재 화면에서 사용할 수 없는 바코드 입니다.
                    }
                    break;
                case "DEFECT":
                    if (btnProduction.Appearance.BackColor == Color.LawnGreen)
                    {
                        lblSerialPortMessage.ForeColor = Color.Red;
                        if (gleDefectProduction.EditValue.ObjectNullString() == "")
                            gleDefectProduction.EditValue = sData;
                        else if (gleDefectProduction1.EditValue.ObjectNullString() == "")
                            gleDefectProduction1.EditValue = sData;
                        else
                            gleDefectProduction2.EditValue = sData;
                    }
                    break;

                case "ENTER":
                    btnBRD_Click(null, null);
                    break;

                case "PRODSN":
                    if (btnProdReady.Appearance.BackColor == Color.LawnGreen)
                    {
                        GetSerial(sData);
                    }
                    if (btnRework.Appearance.BackColor == Color.LawnGreen)
                    {
                        GetRepairSerialInfo(sData);
                    }
                    break;
                case "NODEFINE":
                    if (sData.Trim() == "OK")
                    {
                        if (lblState.Text != "Ready") return;
                        lblSerialPortMessage.ForeColor = Color.LimeGreen;
                        fnInspResult();
                        timerRetryCheck.Enabled = true;

                    }
                    else 
                    {
                        sMsg = clsLan.GetMessageString("MSG_ER_COMM_027");
                        iDATMessageBox.WARNINGMessage(sMsg + "\r\n" +
                                                        "Type : " + sType + "\r\n" +
                                                        "Barcode : " + sData, this.Text, 3);
                    }
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
            InitForm();
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
        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid_Int( gcList
                                           , "PKGPRD_CURRENT.GET_PROD_SERIAL_HISTORY"
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
                                           , gleSerial.EditValue.ObjectNullString() }
                                           , true
                                           , ""
                                           , false//true
                                           , ""
                                           );

            gvList.OptionsView.ColumnAutoWidth = true;
            gvList.BestFitColumns();
        }

        private void GetGridViewList(DataTable dt)
        {
            BASE_DXGridHelper.Bind_Grid( gcList
                                       , dt );

            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();
        }
        private void GetRepairSerialInfo(string _strSerial)
        {
            /*재작업 가능 시리얼 정보*/
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleRepairSerial
                                                       , "GPKGPRD_PROD.GET_REPAIR_SERIAL"
                                                       , 2
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_SERIAL"
                                                       , "A_UNITNO"
                                                       , "A_USER"}
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , _strSerial
                                                       , gleEQP.EditValue.ObjectNullString()
                                                       , Global.Global_Variable.EHRCODE }
                                                       , "SERIAL"
                                                       , "SERIAL"
                                                       , "DEFECT, DEFECTNAME, SERIAL, REMARKS"
                                                       );

            gleRepairSerial.EditValue = _strSerial;
 
        }

        private void InitForm()
        {
            /*타이머 최기화*/
            timerRetryCheck.Enabled = false;
            timerRetryCheck.Interval = 1000;

            /*버튼 컨트롤 설정*/
            btnProdReady.LookAndFeel.UseDefaultLookAndFeel = false;
            btnProdReady.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;

            btnCycleCheck.LookAndFeel.UseDefaultLookAndFeel = false;
            btnCycleCheck.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;

            btnProduction.LookAndFeel.UseDefaultLookAndFeel = false;
            btnProduction.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;

            btnRework.LookAndFeel.UseDefaultLookAndFeel = false;
            btnRework.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;

            SetButton(btnProdReady, null);

            ColorDefault = spiRemainPassLabel.Properties.AppearanceReadOnly.BackColor;

            spiTotalPassLabel.EditValue = Settings_IDAT.Default.PassLabel;
            spiTotalNGLabel.EditValue = Settings_IDAT.Default.NGLabel;
            spiRemainPassLabel.EditValue = Settings_IDAT.Default.PassLabel;
            spiRemainNGLabel.EditValue = Settings_IDAT.Default.NGLabel;

            /*설비 호기 정보*/
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleEQP
                                                       , "GPKGPRD_PROD.GET_INSP_EQP"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT }
                                                       , "UNITNO"
                                                       , "UNITNM"
                                                       , "UNITNO, UNITNM, REMARKS"
                                                       );

            /*작업자 정보*/
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWorker
                                                       , "GPKGPRD_PROD.GET_WORKER"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT }
                                                       , "USERID"
                                                       , "USERNAME"
                                                       , "USERID, USERNAME"
                                                       );
            DataTable dtWorker = (gleWorker.Properties.DataSource as DataTable).Copy();
            dtWorker.Rows[0].Delete();
            dtWorker.AcceptChanges();

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWorker2
                                                       , dtWorker
                                                       , "USERID"
                                                       , "USERNAME"
                                                       , "USERID, USERNAME"
                                                       );

            /*품번 정보*/
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( glePartNo
                                                       , "GPKGPRD_PROD.GET_PARTNO"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT }
                                                       , "ITEMCODE"
                                                       , "PARTNO"
                                                       , "ITEMCODE, PARTNO, SPEC"
                                                       );

            /*불량 코드 정보*/
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleDefectProduction
                                                       , "GPKGPRD_PROD.GET_DEFECT"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT }
                                                       , "DEFECT"
                                                       , "DEFECTNAME"
                                                       , "DEFECT, DEFECTNAME"
                                                       );

            DataTable dt = (gleDefectProduction.Properties.DataSource as DataTable).Copy();
            dt.Rows[0].Delete();
            dt.AcceptChanges();

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleDefectProduction1
                                                       , dt.Copy()
                                                       , "DEFECT"
                                                       , "DEFECTNAME"
                                                       , "DEFECT, DEFECTNAME"
                                                       );

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleDefectProduction2
                                                       , dt.Copy()
                                                       , "DEFECT"
                                                       , "DEFECTNAME"
                                                       , "DEFECT, DEFECTNAME"
                                                       );

        }
        private void GetSerial(string _strSerial)
        {
            SplashScreenManager.ShowForm(typeof(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM), true, false);
            SplashScreenManager.Default.SendCommand(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM.WaitFormCommand.SetDescription, "Loading...");
            
            /*작업지시 정보*/
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleSerial
                                                       , "GPKGPRD_PROD.GET_MAINASSY_SERIAL"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_SERIAL"}
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , _strSerial}
                                                       , "SERIAL"
                                                       , "SERIAL"
                                                       , "SERIAL, PARTNO"
                                                       );

            gleSerial.EditValue = _strSerial;

            //DataRow[] _drWorkord = (gleWorkorder.Properties.DataSource as DataTable).Select("WRKORD='" + gleWorkorder.EditValue.ObjectNullString() + "'");
            //try
            //{
            //    if (_drWorkord[0]["IMAGE"].ObjectNullString().Length > 0)
            //    {
            //        var data = (Byte[])_drWorkord[0]["IMAGE"];

            //        if (data != null)
            //        {
            //            var stream = new MemoryStream(data);
            //            idatDxPictureEdit1.Image = Image.FromStream(stream);
            //        }
            //    }
            //}
            //catch { }

            SplashScreenManager.CloseForm(true);
        }
        private void SetButton(object sender,  EventArgs e)
        {
            IDAT.Devexpress.DXControl.IdatDxSimpleButton btn = sender as IDAT.Devexpress.DXControl.IdatDxSimpleButton;

            btn.Appearance.Options.UseBackColor = true;

            timerRetryCheck.Enabled = false;

            if (btn.Name != "btnProdReady")
            {
                if (gleSerial.EditValue.ObjectNullString() == "")
                {
                    iDATMessageBox.WARNINGMessage("MSG_ER_WO_011", this.Text, 3); //작업지시를 선택하세요.
                    return;
                }

                if (gleEQP.EditValue.ObjectNullString() == "")
                {
                    iDATMessageBox.WARNINGMessage("MSG_ER_EQP_001", this.Text, 3); //설비를 선택하세요.
                    return;
                }

                if (gleWorker.EditValue.ObjectNullString() == "")
                {
                    iDATMessageBox.WARNINGMessage("MSG_ER_PRD_098", this.Text, 3); //실작업자 선택하세요.
                    return;
                }

                if (glePartNo.EditValue.ObjectNullString() == "")
                {
                    iDATMessageBox.WARNINGMessage("MSG_ER_COMM_029", this.Text, 3); //품번을 스캔(입력)하세요.
                    return;
                }

                if (this.Tag.ObjectNullString() == "btnRework")
                {
                    iDATMessageBox.ErrorMessage("MSG_ER_COMM_027", this.Text, 3); //현재 화면에서 사용할 수 없는 바코드 입니다.
                    return;
                }

                DataRow[] _drSerial = (gleSerial.Properties.DataSource as DataTable).Select("SERIAL='" + gleSerial.EditValue.ObjectNullString() + "'");

                if (_drSerial[0]["PARTNO"].ObjectNullString() != glePartNo.Text)
                {
                    iDATMessageBox.WARNINGMessage("MSG_ER_PRD_126", this.Text, 3); //작업지시 품번과 선택한 품번이 다릅니다.
                    return;
                }
                gleEQP.Properties.ReadOnly = true;
                gleSerial.Properties.ReadOnly = true;
                gleWorker.Properties.ReadOnly = true;
                gleWorker2.Properties.ReadOnly = true;
                glePartNo.Properties.ReadOnly = true;

                spiTotalPassLabel.Properties.ReadOnly = true;
                spiTotalNGLabel.Properties.ReadOnly = true;

                GetGridViewList();
            }
            else
            {
                gleEQP.Properties.ReadOnly = false;
                gleSerial.Properties.ReadOnly = false;
                gleWorker.Properties.ReadOnly = false;
                gleWorker2.Properties.ReadOnly = false;
                glePartNo.Properties.ReadOnly = false;

                spiTotalPassLabel.Properties.ReadOnly = false;
                spiTotalNGLabel.Properties.ReadOnly = false;
            }

            lcgWorkManual.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lcgInspHistory.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            switch (btn.Name)
            {
                case "btnProdReady": //작업준비
                    btnProdReady.Appearance.BackColor = Color.LawnGreen;
                    btnCycleCheck.Appearance.BackColor = Color.Transparent;
                    btnProduction.Appearance.BackColor = Color.Transparent;
                    btnRework.Appearance.BackColor = Color.Transparent;

                    tpProdReady.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    tpCycleCheck.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    tpProduction.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    tpRework.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;


                    break;

                case "btnCycleCheck": //주기검사
                    spiGQtyCycleCheck.EditValue = 0;
                    spiBQtyCycleCheck.EditValue = 0;

                    btnProdReady.Appearance.BackColor = Color.Transparent;
                    btnCycleCheck.Appearance.BackColor = Color.LawnGreen;
                    btnProduction.Appearance.BackColor = Color.Transparent;
                    btnRework.Appearance.BackColor = Color.Transparent;

                    tpProdReady.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    tpCycleCheck.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    tpProduction.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    tpRework.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                    lcgWorkManual.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lcgInspHistory.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                    break;

                case "btnProduction": //양산모드
                    spiUnitPQty.EditValue = 0;
                    spiUnitNQty.EditValue = 0;
                   
                    timerRetryCheck.Enabled = true;

                    btnProdReady.Appearance.BackColor = Color.Transparent;
                    btnCycleCheck.Appearance.BackColor = Color.Transparent;
                    btnProduction.Appearance.BackColor = Color.LawnGreen;
                    btnRework.Appearance.BackColor = Color.Transparent;

                    spiRemainPassLabel.EditValue = spiTotalPassLabel.EditValue;
                    spiRemainNGLabel.EditValue = spiTotalNGLabel.EditValue;

                    tpProdReady.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    tpCycleCheck.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    tpProduction.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    tpRework.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    break;

                case "btnRework": //재작업
                    btnProdReady.Appearance.BackColor = Color.Transparent;
                    btnCycleCheck.Appearance.BackColor = Color.Transparent;
                    btnProduction.Appearance.BackColor = Color.Transparent;
                    btnRework.Appearance.BackColor = Color.LawnGreen;

                    spiRemainPassLabel.EditValue = spiTotalPassLabel.EditValue;
                    spiRemainNGLabel.EditValue = spiTotalNGLabel.EditValue;

                    tpProdReady.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    tpCycleCheck.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    tpProduction.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    tpRework.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                    //GetRepairSerialInfo();

                    break;

            }

            strProdStatus = btn.Name;
        }

        /*주기 검사 실적 저장*/
        private void SET_PROD_CYCLECHECK()
        {
            WSResults _Result = BASE_db.Execute_Proc( "PKGPRD_CURRENT.SET_PROD_CYCLECHECK"
                                                    , 1
                                                    , new string[] { 
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_UNITNO"
                                                    , "A_ITEMCODE"
                                                    , "A_USER" }
                                                    , new object[] { 
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT 
                                                    , gleEQP.EditValue.ObjectNullString()
                                                    , glePartNo.EditValue.ObjectNullString()
                                                    , gleWorker.EditValue.ObjectNullString() }
                                                    );

            if (_Result.ResultInt == 0)
            {
                lblMessageProduction.Text = "";

                if (_Result.ResultDataSet.Tables[0].Rows.Count > 0)
                {
                    //txtTotalStatus.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["TOTALSTATUS"].ObjectNullString();
                    //txtUnitStatus.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["UNITSTATUS"].ObjectNullString();
                    //spiGQtyProduction.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["GOODQTY"].ObjectNullString();
                    //spiBQtyProduction.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["NGQTY"].ObjectNullString();

                    //txtTotalNGStatus.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["TOTALNGSTATUS"].ObjectNullString();
                    //txtTotalDefectRate.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["TOTALDRATE"].ObjectNullString();
                    //txtUnitNGStatus.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["UNITNGSTATUS"].ObjectNullString();
                    //txtUnitDefectRate.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["UNITDRATE"].ObjectNullString();
                }

                if (_Result.ResultDataSet.Tables.Count > 1)
                    GetGridViewList(_Result.ResultDataSet.Tables[1]);

                if (_Result.ResultDataSet.Tables.Count > 2)
                {
                    DataRow[] _drPartNo = (glePartNo.Properties.DataSource as DataTable).Select("ITEMCODE='" + glePartNo.EditValue.ObjectNullString() + "'");

                    if (_drPartNo[0]["PRINTTYPE"].ObjectNullString() == "W")
                    {
                        Print1(_Result.ResultDataSet.Tables[2], 1); //Washer
                    }
                    else if (_drPartNo[0]["PRINTTYPE"].ObjectNullString() == "R")
                    {
                        Print2(_Result.ResultDataSet.Tables[2], 1); //REF
                    }
                    else if (_drPartNo[0]["PRINTTYPE"].ObjectNullString() == "D")
                    {
                        Print(_Result.ResultDataSet.Tables[2], 1); //Dryer
                    }
                    else
                    {
                        Print3(_Result.ResultDataSet.Tables[2], 1); //ETC
                    }

                    iDATMessageBox.OKMessage("MSG_OK_PRINT_002", this.Text); //발행이 완료 되었습니다.
                }
            }
            else
            {
                lblMessageCycleCheck.Text = BASE_Language.GetMessageString(_Result.ResultString);
            }
 
        }

        /*양산 검사 실적 저장*/
        private int SET_PROD_PRODUCTION(string p_strJudge, string p_strDefect, string p_strDefect1, string p_strDefect2)
        {
            DataRow[] _drProdLine = (gleEQP.Properties.DataSource as DataTable).Select("UNITNO='" + gleEQP.EditValue.ObjectNullString() + "'");

            WSResults _Result = BASE_db.Execute_Proc( "PKGPRD_CURRENT.SET_PROD_PRODUCTION_OS"
                                                    , 1
                                                    , new string[] { 
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_SERIAL"
                                                    , "A_PRODLINE"
                                                    , "A_UNITNO"
                                                    , "A_ITEMCODE"
                                                    , "A_JUDGE"
                                                    , "A_DEFECT"
                                                    , "A_DEFECT1"
                                                    , "A_DEFECT2"
                                                    , "A_USER" 
                                                    , "A_USER2"}
                                                    , new object[] { 
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT 
                                                    , gleSerial.EditValue.ObjectNullString()
                                                    , _drProdLine[0]["PRODLINE"].ObjectNullString()
                                                    , gleEQP.EditValue.ObjectNullString()
                                                    , glePartNo.EditValue.ObjectNullString()
                                                    , p_strJudge
                                                    , p_strDefect
                                                    , p_strDefect1
                                                    , p_strDefect2
                                                    , gleWorker.EditValue.ObjectNullString()
                                                    , gleWorker2.EditValue.ObjectNullString()}
                                                    );

            if (_Result.ResultInt == 0)
            {
                lblMessageProduction.Text = "";

                if (p_strJudge == "Y" && _Result.ResultDataSet.Tables.Count > 0)
                {
                    DataRow[] _drPartNo = (glePartNo.Properties.DataSource as DataTable).Select("ITEMCODE='" + glePartNo.EditValue.ObjectNullString() + "'");

                    int.TryParse(_drPartNo[0]["PRINTUNIT"].ObjectNullString(), out int nCopies);

                    if (nCopies > 0)
                    {
                        if (_drPartNo[0]["PRINTTYPE"].ObjectNullString() == "W")
                        {
                            Print1(_Result.ResultDataSet.Tables[0], nCopies); //Washer
                        }
                        else if (_drPartNo[0]["PRINTTYPE"].ObjectNullString() == "R")
                        {
                            Print2(_Result.ResultDataSet.Tables[0], nCopies); //REF
                        }
                        else if (_drPartNo[0]["PRINTTYPE"].ObjectNullString() == "D")
                        {
                            Print(_Result.ResultDataSet.Tables[0], 1); //Dryer
                        }
                        else
                        {
                            Print3(_Result.ResultDataSet.Tables[0], 1); //ETC
                        }
                    }
                    spiRemainPassLabel.EditValue = int.Parse(spiRemainPassLabel.EditValue.ObjectNullString()) - 1;
                }
                else
                {
                    DataRow[] _drDefect = (gleDefectProduction.Properties.DataSource as DataTable).Select("DEFECT ='" + p_strDefect + "'");
                    DataRow[] _drDefect1 = (gleDefectProduction1.Properties.DataSource as DataTable).Select("DEFECT ='" + p_strDefect1 + "'");
                    DataRow[] _drDefect2 = (gleDefectProduction2.Properties.DataSource as DataTable).Select("DEFECT ='" + p_strDefect2 + "'");

                    string _defect = string.Empty;
                    string _defect1 = string.Empty;
                    string _defect2 = string.Empty;

                    if (_drDefect.Length > 0) _defect = _drDefect[0]["DEFECTNAME"].ObjectNullString();

                    if (_drDefect1.Length > 0) _defect1 = _drDefect1[0]["DEFECTNAME"].ObjectNullString();

                    if (_drDefect2.Length > 0) _defect2 = _drDefect2[0]["DEFECTNAME"].ObjectNullString();

                    Print4(_Result.ResultDataSet.Tables[0]
                          , _defect
                          , _defect1
                          , _defect2
                          , 1); //NG

                    spiRemainNGLabel.EditValue = int.Parse(spiRemainNGLabel.EditValue.ObjectNullString()) - 1;
                }

            }
            else
            {
                lblMessageProduction.Text = BASE_Language.GetMessageString(_Result.ResultString);
            }

            timerThread.Enabled = true;

            return _Result.ResultInt;
        }
        
        private void GetBackgroundProcess()
        {
            if (this.InvokeRequired)
            {
                var d = new SetThreadCallback(GetBackgroundProcess);
                this.Invoke(d, new object[] { });
            }
            else
            {
                try
                {
                    WSResults _Result = BASE_db.Execute_Proc( "PKGPRD_CURRENT.GET_PROD_PRODQTY"
                                                            , 3
                                                            , new string[] { 
                                                              "A_CLIENT"
                                                            , "A_COMPANY"
                                                            , "A_PLANT"
                                                            , "A_WRKORD"
                                                            , "A_UNITNO" }
                                                            , new object[] { 
                                                              Global.Global_Variable.CLIENT
                                                            , Global.Global_Variable.COMPANY
                                                            , Global.Global_Variable.PLANT 
                                                            , gleSerial.EditValue.ObjectNullString()
                                                            , gleEQP.EditValue.ObjectNullString()}
                                                            );

                    //lblSerialPortMessage.Text += " [ " + DateTime.Now.ToString("HH:mm:ss") + " ]";

                    if (_Result.ResultInt == 0)
                    {
                        if (_Result.ResultDataSet.Tables[0].Rows.Count > 0)
                        {
                            txtUnitQty.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["UNITQTY"].ObjectNullString();
                            spiUnitPQty.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["UNITPASSQTY"].ObjectNullString();
                            spiUnitNQty.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["UNITNGQTY"].ObjectNullString();
                            spiUnitPPM.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["UNITPPM"].ObjectNullString();
                            spiUnitTarget.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["UNITTARGETUPH"].ObjectNullString();
                            spiUnitResult.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["UNITRESULTUPH"].ObjectNullString();

                            txtTotalQty.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["TOTALQTY"].ObjectNullString();
                            spiTotalPQty.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["TOTALPASSQTY"].ObjectNullString();
                            spiTotalNQty.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["TOTALNGQTY"].ObjectNullString();
                            spiTotalPPM.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["TOTALPPM"].ObjectNullString();
                            spiTotalTarget.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["TOTALTARGETUPH"].ObjectNullString();
                            spiTotalResult.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["TOTALRESULTUPH"].ObjectNullString();
                        }
                    }
                }
                catch (Exception)
                {
 
                }
                finally
                {
                    t.Abort();
                    t = null;
                }
            }
        }
        /*재작업 실적 저장*/
        private void SET_PROD_REWORK()
        {
            DataRow[] _drProdLine = (gleEQP.Properties.DataSource as DataTable).Select("UNITNO='" + gleEQP.EditValue.ObjectNullString() + "'");

            WSResults _Result = BASE_db.Execute_Proc( "PKGPRD_CURRENT.SET_PROD_REWORK"
                                                    , 1
                                                    , new string[] { 
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_WRKORD"
                                                    , "A_WRKORDSEQ"
                                                    , "A_SERIAL"
                                                    , "A_PRODTYPE"
                                                    , "A_PRODLINE"
                                                    , "A_UNITNO"
                                                    , "A_ITEMCODE"
                                                    , "A_JUDGE"
                                                    , "A_DEFECT"
                                                    , "A_USER" }
                                                    , new object[] { 
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT 
                                                    , "NONE"
                                                    , ""
                                                    , gleRepairSerial.EditValue.ObjectNullString()
                                                    , "P"
                                                    , _drProdLine[0]["PRODLINE"].ObjectNullString()
                                                    , gleEQP.EditValue.ObjectNullString()
                                                    , glePartNo.EditValue.ObjectNullString()
                                                    , "Y" //합격
                                                    , ""
                                                    , gleWorker.EditValue.ObjectNullString() }
                                                    );

            if (_Result.ResultInt == 0)
            {
                lblMessageRework.Text = "";

                //GetRepairSerialInfo();

                if (_Result.ResultDataSet.Tables.Count > 0)
                    GetGridViewList(_Result.ResultDataSet.Tables[0]);

                if (_Result.ResultDataSet.Tables.Count > 1)
                {
                    DataRow[] _drPartNo = (glePartNo.Properties.DataSource as DataTable).Select("ITEMCODE='" + glePartNo.EditValue.ObjectNullString() + "'");

                    if (_drPartNo[0]["PRINTTYPE"].ObjectNullString() == "W")
                    {
                        Print1(_Result.ResultDataSet.Tables[2], 1); //Washer
                    }
                    else if (_drPartNo[0]["PRINTTYPE"].ObjectNullString() == "R")
                    {
                        Print2(_Result.ResultDataSet.Tables[2], 1); //REF
                    }
                    else if (_drPartNo[0]["PRINTTYPE"].ObjectNullString() == "D")
                    {
                        Print(_Result.ResultDataSet.Tables[2], 1); //Dryer
                    }
                    else
                    {
                        Print3(_Result.ResultDataSet.Tables[2], 1); //ETC
                    }

                    spiRemainPassLabel.EditValue = int.Parse(spiRemainPassLabel.EditValue.ObjectNullString()) - 1;
                }
                    
            }
            else
            {
                lblMessageRework.Text = BASE_Language.GetMessageString(_Result.ResultString);
            }
        }

        /*재발행*/
        private int SET_CIRCUIT_REPIRNT(string p_strSerial)
        {
            WSResults _Result = BASE_db.Execute_Proc( "PKGPRD_CURRENT.SET_CIRCUIT_REPINT"
                                                    , 1
                                                    , new string[] { 
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_SERIAL" 
                                                    , "A_USER" }
                                                    , new object[] { 
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT 
                                                    , p_strSerial
                                                    , gleWorker.EditValue.ObjectNullString() }
                                                    );

            if (_Result.ResultInt == 0)
            {
                DataRow[] _drPartNo = (glePartNo.Properties.DataSource as DataTable).Select("ITEMCODE='" + glePartNo.EditValue.ObjectNullString() + "'");

                if (_drPartNo[0]["PRINTTYPE"].ObjectNullString() == "W")
                {
                    Print1(_Result.ResultDataSet.Tables[0], 1); //Washer
                }
                else if (_drPartNo[0]["PRINTTYPE"].ObjectNullString() == "R")
                {
                    Print2(_Result.ResultDataSet.Tables[0], 1); //REF
                }
                else if (_drPartNo[0]["PRINTTYPE"].ObjectNullString() == "D")
                {
                    Print(_Result.ResultDataSet.Tables[0], 1); //Dryer
                }
                else
                {
                    Print3(_Result.ResultDataSet.Tables[0], 1); //ETC
                }
            }
            else
            {
                lblMessageProduction.Text = BASE_Language.GetMessageString(_Result.ResultString);
            }

            //lblSerialPortMessage.Text += " [ " + DateTime.Now.ToString("HH:mm:ss") + " ]";

            return _Result.ResultInt;
        }

        private void fnInspResult()
        {
            if (strProdStatus == "btnProdReady")
            {
                return;
            }
            else if (strProdStatus == "btnCycleCheck") /*주기 검사 실적 저장*/
            {
                SET_PROD_CYCLECHECK();
            }
            else if (strProdStatus == "btnProduction") /*검사 실적 저장*/
            {
                SET_PROD_PRODUCTION("Y", "", "", "");
            }
            else if (strProdStatus == "btnRework") /*재작업*/
            {
                if (gleRepairSerial.EditValue.ObjectNullString() == "")
                {
                    iDATMessageBox.ErrorMessage("MSG_ER_COMM_025", this.Text, 3); //대상을 선택하세요.MSG_ER_BRD_016
                    return;
                }

                SET_PROD_REWORK();
            }
           
            //bgwProdInfo.RunWorkerAsync();

            if (int.Parse(spiRemainPassLabel.EditValue.ObjectNullString()) < 50)
                timerPassLamp.Enabled = true;
            else
                timerPassLamp.Enabled = false;

            if (int.Parse(spiRemainNGLabel.EditValue.ObjectNullString()) < 50)
                timerNGLamp.Enabled = true;
            else
                timerNGLamp.Enabled = false;

            


        }
        //Dryer or default
        private bool Print(DataTable dTable, int nCopies)
        {
            using (RPT.RPTA203 _rpt = new RPT.RPTA203(dTable, nCopies))
            {
                _rpt.RptPrint();
            }
            return true;
        }
        //Washer
        private bool Print1(DataTable dTable, int nCopies)
        {
            using (RPT.RPTA206 _rpt = new RPT.RPTA206(dTable, nCopies))
            {
                _rpt.RptPrint();
            }
            return true;
        }
        //REF
        private bool Print2(DataTable dTable, int nCopies)
        {
            using (RPT.RPTA207 _rpt = new RPT.RPTA207(dTable, nCopies))
            {
                _rpt.RptPrint();
            }
            return true;
        }
        //ETC
        private bool Print3(DataTable dTable, int nCopies)
        {
            using (RPT.RPTA209 _rpt = new RPT.RPTA209(dTable, nCopies))
            {
                _rpt.RptPrint();
            }
            return true;
        }
        //NG
        private bool Print4(DataTable dTable, string nDefectNm, string nDefectNm1, string nDefectNm2, int nCopies)
        {
            using (RPT.RPTA211 _rpt = new RPT.RPTA211(dTable, nDefectNm, nDefectNm1, nDefectNm2, nCopies))
            {
                _rpt.RptPrint("TTP-244");
            }
            return true;
        }
        #endregion

        #region [컨트롤 이벤트]

        /*불량 등록*/
        private void btnBRD_Click(object sender, EventArgs e)
        {
            if (gleDefectProduction.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.ErrorMessage("MSG_ER_BRD_012", this.Text, 3); //불량코드를 선택하여 주십시오.
                return;
            }
            DataRow[] _drDefect = (gleDefectProduction.Properties.DataSource as DataTable).Select("DEFECT ='" + gleDefectProduction.EditValue.ObjectNullString() + "'");
            LanguageInformation _clsLan = new LanguageInformation();
            string _strMsg = _clsLan.GetMessageString("MSG_ER_PRD_127") +
                "\r\n" + 
                "[NG CODE]" + gleDefectProduction.EditValue.ObjectNullString() + 
                "       " +
                "[NG NAME]" + _drDefect[0]["DEFECTNAME"].ObjectNullString();//불량을 등록하시겠습니까?

            if (iDATMessageBox.QuestionMessage(_strMsg, this.Text) == System.Windows.Forms.DialogResult.Yes)
            {
                if (SET_PROD_PRODUCTION( "N"
                                       , gleDefectProduction.EditValue.ObjectNullString()
                                       , gleDefectProduction1.EditValue.ObjectNullString()
                                       , gleDefectProduction2.EditValue.ObjectNullString()) <= 0)
                {
                    gleDefectProduction.EditValue = null;
                    gleDefectProduction1.EditValue = null;
                    gleDefectProduction2.EditValue = null;

                    iDATMessageBox.OKMessage("DBMSG_SUCCESS", this.Text, 3);
                }
            }
            
        }
        /*재발행*/
        private void btnReprint_Click(object sender, EventArgs e)
        {
            if(gvList.GetFocusedRowCellValue("JUDGE").ObjectNullString() == "Y")
                SET_CIRCUIT_REPIRNT(gvList.GetFocusedRowCellValue("SERIAL").ObjectNullString());
            else
                iDATMessageBox.ErrorMessage("MSG_ER_BRD_016", this.Text, 3); //불량 등록된 시리얼 입니다.

            
        }
        /*재작업 시리얼 선택 여부 체크*/
        private void gleRepairSerial_EditValueChanged(object sender, EventArgs e)
        {
            if (gleRepairSerial.EditValue.ObjectNullString() != "")
                lblMessageRework.Text = "";
        }

        #endregion

        private void lblMessageProduction_Click(object sender, EventArgs e)
        {
            if (Global.Global_Variable.USER_ID == "SYSOPER")
                Get_BarcodeType("OK");//ProcessScanEvent("NODEFINE", "OK");

        }

        private void timerRetryCheck_Tick(object sender, EventArgs e)
        {
            itrycheck--;

            lblState.Text = itrycheck.ObjectNullString();

            if (itrycheck == 0)
            {
                lblState.Text = "Ready";
                itrycheck = 3;
                timerRetryCheck.Enabled = false;
            }
        }

        private void lblMessageProdReady_Click(object sender, EventArgs e)
        {
            if (Global.Global_Variable.USER_ID == "SYSOPER")
                Get_BarcodeType("WO20190702P0002");//ProcessScanEvent("NODEFINE", "OK");
        }

        private void btnPassReset_Click(object sender, EventArgs e)
        {
            spiTotalPassLabel.EditValue = 1000;
            spiRemainPassLabel.EditValue = 1000;
            spiRemainPassLabel.Properties.AppearanceReadOnly.BackColor = ColorDefault;
            timerPassLamp.Enabled = false;
        }

        private void btnNGReset_Click(object sender, EventArgs e)
        {
            spiTotalNGLabel.EditValue = 1000;
            spiRemainNGLabel.EditValue = 1000;
            spiRemainPassLabel.Properties.AppearanceReadOnly.BackColor = ColorDefault;
            timerNGLamp.Enabled = false;
        }

        private void timerPassLamp_Tick(object sender, EventArgs e)
        {
            spiRemainPassLabel.LookAndFeel.UseDefaultLookAndFeel = false;
            //spiRemainPassLabel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;

            spiRemainPassLabel.Properties.AppearanceReadOnly.Options.UseBackColor = true;

            if (int.Parse(spiRemainPassLabel.EditValue.ObjectNullString()) < 50)
            {
                if (spiRemainPassLabel.Properties.AppearanceReadOnly.BackColor == Color.Red)
                    spiRemainPassLabel.Properties.AppearanceReadOnly.BackColor = Color.White;
                else
                    spiRemainPassLabel.Properties.AppearanceReadOnly.BackColor = Color.Red;
 
            }
            
        }

        private void timerNGLamp_Tick(object sender, EventArgs e)
        {
            spiRemainNGLabel.LookAndFeel.UseDefaultLookAndFeel = false;
            spiRemainNGLabel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;

            if (int.Parse(spiRemainNGLabel.EditValue.ObjectNullString()) < 50)
            {
                if (spiRemainNGLabel.Properties.AppearanceReadOnly.BackColor == Color.Red)
                    spiRemainNGLabel.Properties.AppearanceReadOnly.BackColor = Color.White;
                else
                    spiRemainNGLabel.Properties.AppearanceReadOnly.BackColor = Color.Red;

            }
        }

        private void timerThread_Tick(object sender, EventArgs e)
        {
            timerThread.Enabled = false;

            if (t == null)
            {
                t = new Thread(new ThreadStart(GetBackgroundProcess));
                t.Start();
            }
               
        }

    }
}