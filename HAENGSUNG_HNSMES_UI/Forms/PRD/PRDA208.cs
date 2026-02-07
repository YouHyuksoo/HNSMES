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
    ///    화면명 : PRDA208<br/>
    ///      기능 : 통전검사 라벨 발행 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>

    public partial class PRDA208 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
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

        public PRDA208()
        {
            InitializeComponent();
        }

        private void PRDA208_Load(object sender, EventArgs e)
        {

        }

        private void PRDA208_Shown(object sender, EventArgs e)
        {
            // ************************************************************************************
            // 컨트롤 초기화는 필수적으로 Shown이벤트에 작성을 하도록 합니다.
            // ************************************************************************************
            InitForm();
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

            lblSerialPortMessage.Text = " [ " + DateTime.Now.ToString("HH:mm:ss") + " ] " + sData.Trim();

            switch (sType)
            {
                case "UNITNO":
                    gleEQP.EditValue = sData;
                    break;
                case "WORKER":
                    gleWorker.EditValue = sData;
                    break;
                case "PARTNO":
                    glePartNo.EditValue = sData;
                    break;
                case "DEFECT":
                    if (btnProduction.Appearance.BackColor == Color.LawnGreen)
                    {
                        gleDefectProduction.EditValue = sData;

                        btnBRD_Click(null, null);
                    }
                    break;

                case "PRODSN":
                    if (btnRework.Appearance.BackColor == Color.LawnGreen)
                    {
                        GetRepairSerialInfo(sData);
                    }
                    break;
                case "NODEFINE":
                    if (sData.Trim() == "OK")
                    {
                        if (lblState.Text != "Ready") return;

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
                                           , "PKGPRD_CURRENT.GET_PROD_UNITITEM_HISTORY"
                                           , 1
                                           , new string[] { 
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_UNITNO"
                                           , "A_ITEMCODE" }
                                           , new string[] { 
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , gleEQP.EditValue.ObjectNullString()
                                           , glePartNo.EditValue.ObjectNullString() }
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

            gleWorker.EditValue = Global.Global_Variable.EHRCODE;

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
        }

        private void SetButton(object sender,  EventArgs e)
        {
            IDAT.Devexpress.DXControl.IdatDxSimpleButton btn = sender as IDAT.Devexpress.DXControl.IdatDxSimpleButton;

            btn.Appearance.Options.UseBackColor = true;

            timerRetryCheck.Enabled = false;

            if (btn.Name != "btnProdReady")
            {

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

                gleEQP.Properties.ReadOnly = true;
                gleWorker.Properties.ReadOnly = true;
                glePartNo.Properties.ReadOnly = true;

                GetGridViewList();
            }
            else
            {
                gleEQP.Properties.ReadOnly = false;
                gleWorker.Properties.ReadOnly = false;
                glePartNo.Properties.ReadOnly = false;
            }

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
                    break;

                case "btnProduction": //양산
                    spiGQtyProduction.EditValue = 0;
                    spiBQtyProduction.EditValue = 0;

                    timerRetryCheck.Enabled = true;

                    btnProdReady.Appearance.BackColor = Color.Transparent;
                    btnCycleCheck.Appearance.BackColor = Color.Transparent;
                    btnProduction.Appearance.BackColor = Color.LawnGreen;
                    btnRework.Appearance.BackColor = Color.Transparent;

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

                    tpProdReady.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    tpCycleCheck.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    tpProduction.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    tpRework.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

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
                    for (int i = 0; i < _Result.ResultDataSet.Tables[0].Rows.Count; i++)
                    {
                        if (_Result.ResultDataSet.Tables[0].Rows[i]["JUDGE"].ObjectNullString() == "Pass")
                        {
                            spiGQtyCycleCheck.EditValue = _Result.ResultDataSet.Tables[0].Rows[i]["QTY"].ObjectNullString();
                        }
                        else
                        {
                            spiBQtyCycleCheck.EditValue = _Result.ResultDataSet.Tables[0].Rows[i]["QTY"].ObjectNullString();
                        }
                    }
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
        private int SET_PROD_PRODUCTION(string p_strJudge, string p_strDefect)
        {
            DataRow[] _drProdLine = (gleEQP.Properties.DataSource as DataTable).Select("UNITNO='"+ gleEQP.EditValue.ObjectNullString() +"'");

            WSResults _Result = BASE_db.Execute_Proc( "PKGPRD_CURRENT.SET_PROD_PRODUCTION"
                                                    , 1
                                                    , new string[] { 
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_WRKORD"
                                                    , "A_WRKORDSEQ"
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
                                                    , "P"
                                                    , _drProdLine[0]["PRODLINE"].ObjectNullString()
                                                    , gleEQP.EditValue.ObjectNullString()
                                                    , glePartNo.EditValue.ObjectNullString()
                                                    , p_strJudge
                                                    , p_strDefect
                                                    , gleWorker.EditValue.ObjectNullString() }
                                                    );

            //lblSerialPortMessage.Text += " [ " + DateTime.Now.ToString("HH:mm:ss") + " ]";

            if (_Result.ResultInt == 0)
            {
                lblMessageProduction.Text = "";

                if (_Result.ResultDataSet.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < _Result.ResultDataSet.Tables[0].Rows.Count; i++)
                    {
                        if (_Result.ResultDataSet.Tables[0].Rows[i]["JUDGE"].ObjectNullString() == "Pass")
                        {
                            spiGQtyProduction.EditValue = _Result.ResultDataSet.Tables[0].Rows[i]["QTY"].ObjectNullString();
                        }
                        else
                        {
                            spiBQtyProduction.EditValue = _Result.ResultDataSet.Tables[0].Rows[i]["QTY"].ObjectNullString();
                        }
                    }

                    /*검사 수량 집계*/
                    spiTQtyProduction.EditValue = int.Parse(spiGQtyProduction.EditValue.ObjectNullString()) + int.Parse(spiBQtyProduction.EditValue.ObjectNullString());
                }

                if (_Result.ResultDataSet.Tables.Count > 1)
                    GetGridViewList(_Result.ResultDataSet.Tables[1]);

                if (p_strJudge == "Y" && _Result.ResultDataSet.Tables.Count > 2)
                {
                    DataRow[] _drPartNo = (glePartNo.Properties.DataSource as DataTable).Select("ITEMCODE='" + glePartNo.EditValue.ObjectNullString() + "'");

                    int nCopies;

                    int.TryParse(_drPartNo[0]["PRINTUNIT"].ObjectNullString(), out nCopies);

                    if (nCopies > 0)
                    {
                        if (_drPartNo[0]["PRINTTYPE"].ObjectNullString() == "W")
                        {
                            Print1(_Result.ResultDataSet.Tables[2], nCopies); //Washer
                        }
                        else if (_drPartNo[0]["PRINTTYPE"].ObjectNullString() == "R")
                        {
                            Print2(_Result.ResultDataSet.Tables[2], nCopies); //REF
                        }
                        else if (_drPartNo[0]["PRINTTYPE"].ObjectNullString() == "D")
                        {
                            Print(_Result.ResultDataSet.Tables[2], 1); //Dryer
                        }
                        else
                        {
                            Print3(_Result.ResultDataSet.Tables[2], 1); //ETC
                        }
                    }
                }
                else
                {
                    DataRow[] _drDefect = (gleDefectProduction.Properties.DataSource as DataTable).Select("DEFECT ='" + p_strDefect + "'");
                    Print4(_Result.ResultDataSet.Tables[2], _drDefect[0]["DEFECTNAME"].ObjectNullString(), 1); //NG
                }
            }
            else
            {
                lblMessageProduction.Text = BASE_Language.GetMessageString(_Result.ResultString);
            }

            //lblSerialPortMessage.Text += " [ " + DateTime.Now.ToString("HH:mm:ss") + " ]";

            return _Result.ResultInt;
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

                gleRepairSerial.EditValue = null;

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
                SET_PROD_PRODUCTION("Y", "");
            }
            else if (strProdStatus == "btnRework") /*재작업*/
            {
                if (gleRepairSerial.EditValue.ObjectNullString() == "")
                {
                    iDATMessageBox.ErrorMessage("MSG_ER_COMM_025", this.Text, 3); //대상을 선택하세요.
                    return;
                }

                SET_PROD_REWORK();


            }
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
        private bool Print4(DataTable dTable, string nDefectNm, int nCopies)
        {
            using (RPT.RPTA211 _rpt = new RPT.RPTA211(dTable, nDefectNm, "", "", nCopies))
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
            if (SET_PROD_PRODUCTION("N", gleDefectProduction.EditValue.ObjectNullString()) <= 0)
            {
                gleDefectProduction.EditValue = "";
                iDATMessageBox.OKMessage("DBMSG_SUCCESS", this.Text, 3);
            }
            
        }
        /*재발행*/
        private void btnReprint_Click(object sender, EventArgs e)
        {
            using (HAENGSUNG_HNSMES_UI.Forms.COM.Password _frmPassword = new Forms.COM.Password())
            {
                if (_frmPassword.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    SET_CIRCUIT_REPIRNT(gvList.GetFocusedRowCellValue("SERIAL").ObjectNullString());
                }
            }
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
                ProcessScanEvent("NODEFINE", "OK");//Get_BarcodeType("D001");

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
    }
}