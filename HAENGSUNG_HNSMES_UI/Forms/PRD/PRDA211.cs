using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.AccessControl; 


// DevExpress namespace
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraSplashScreen;

// User namespace
using HAENGSUNG_HNSMES_UI.Class;
using GridAlias = DevExpress.XtraGrid.Views.Grid;
using HAENGSUNG_HNSMES_UI.WebService.Access;

using System.IO;
using System.Threading;

namespace HAENGSUNG_HNSMES_UI.Forms.PRD
{
    public partial class PRDA211 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
    {
        private Color CWrdEnableColor = Color.FromArgb(45, 166, 112);
        private Color CWrdDisableColor = Color.FromArgb(255, 255, 198);

        private Color CwrdEnableForeColor = Color.White;
        private Color CwrdDisableForeColor = Color.Black;

        private Color CPrdDisableColor = Color.FromArgb(245, 245, 247);

        private BackgroundWorker bgwPickup = null;
        string _strFileDir = string.Empty;
        string _strWorkInfo = string.Empty;

        bool closePending = false;

        private delegate void SetThreadCallback(string p_log);

        public PRDA211()
        {
            InitializeComponent();
        }

        #region [Form Event]

                
        private void Form_Load(object sender, EventArgs e)
        {
            
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            // ************************************************************************************
            // 컨트롤 초기화는 필수적으로 Shown이벤트에 작성을 하도록 합니다.
            // ************************************************************************************
            Frominit();
            FormBindingControl();
            FormInitEvent();

            bgwPickup = new BackgroundWorker();
            bgwPickup.WorkerSupportsCancellation = true;
            bgwPickup.DoWork += new DoWorkEventHandler(bgwPickup_DoWork);
            bgwPickup.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwPickup_RunWorkerCompleted);
            
        }
        private void bgwPickup_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (closePending) this.Close();
            closePending = false;
        }

        private void PRDA211_FormClosing(object sender, FormClosingEventArgs e)
        {
            closePending = true;
            if (bgwPickup.IsBusy)
            {
                bgwPickup.CancelAsync();
                e.Cancel = true;
                this.Hide();
                return;
            }

            
        }
        #endregion

        #region [Scan Event]
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
                case "WORKORDER":
                    formWorkordData(sData);
                    break;
                case "UNITNO":
                    gleUnitNo.EditValue = sData;
                    gleUnitNo.Properties.AppearanceReadOnly.BackColor = CWrdEnableColor;
                    gleUnitNo.Properties.AppearanceReadOnly.ForeColor = CwrdEnableForeColor;
                    break;
                case "WORKER":
                    gleWorker.EditValue = sData;
                    gleWorker.Properties.AppearanceReadOnly.BackColor = CWrdEnableColor;
                    gleWorker.Properties.AppearanceReadOnly.ForeColor = CwrdEnableForeColor;
                    break;
                case "MATSN":
                case "PRODSN":
                    SetMount(sData);
                    break;

                case "SIDE":
                    if (sData.Trim() == "FRONT")
                    {
                        btnFront.Appearance.BackColor = Color.LimeGreen;
                        btnRear.Appearance.BackColor = Color.White;
                    }
                    else
                    {
                        btnFront.Appearance.BackColor = Color.White;
                        btnRear.Appearance.BackColor = Color.LimeGreen;
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
            //base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);
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

        #region [private Event]

        private bool SetPerformance(string p_strwrkord, string p_Prodqty, string p_Log)
        {
            WSResults _result = BASE_db.Execute_Proc( "PKGPRD_PROD.SET_PROD_REG"
                                                    , 2
                                                    , new string[] {
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_WRKORD"
                                                    , "A_UNITNO"
                                                    , "A_PRODQTY"
                                                    , "A_LOG"
                                                    , "A_USER"}
                                                    , new string[] {
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT
                                                    , p_strwrkord
                                                    , gleUnitNo.EditValue.ObjectNullString()
                                                    , p_Prodqty
                                                    , p_Log
                                                    , gleWorker.EditValue.ObjectNullString() }
                                                    );

            if (_result.ResultInt == 0)
            {
                FormInitEvent();

                if (_result.ResultDataSet.Tables[0].Rows.Count > 0)
                {
                    ControlBinding(_result.ResultDataSet.Tables[0]);
                    GetProdHist(_result.ResultDataSet.Tables[1]);
                    Print(_result.ResultDataSet.Tables[2], 1);
                    ShowMessage("");
                }
                return true;
            }
            else
            {
                ShowMessage(base.BASE_Language.GetMessageString(_result.ResultString));
                return false;
            }
 
        }

        private bool SetError(string p_wrkord, string p_wrkordseq, string p_errcode, string p_sttime, string p_entime, string p_log)
        {
            WSResults _result = BASE_db.Execute_Proc( "PKGPRD_PROD.SET_CRIMPINGERROR"
                                                    , 2
                                                    , new string[] {
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_WRKORD"
                                                    , "A_WRKORDSEQ"
                                                    , "A_ERRCODE"
                                                    , "A_STTIME"
                                                    , "A_ENTIME"
                                                    , "A_LOG"}
                                                    , new string[] {
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT
                                                    , p_wrkord
                                                    , p_wrkordseq
                                                    , p_errcode
                                                    , p_sttime
                                                    , p_entime
                                                    , p_log }
                                                    );

            if (_result.ResultInt == 0)
            {
                return true;
            }
            else
            {
                ShowMessage(base.BASE_Language.GetMessageString(_result.ResultString));
                return false;
            }

        }
        private void GetProdHist(DataTable _dt)
        {
            gvList.BeginUpdate();

            gvList.OptionsView.ShowAutoFilterRow = false;

            gvList.RowHeight = 20;

            gvList.ColumnPanelRowHeight = 20;

            gvList.OptionsView.AllowCellMerge = false;

            gvList.OptionsView.RowAutoHeight = true;

            gcList.DataSource = _dt;

            gvList.EndUpdate();

        }
        private void FormBindingControl()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleUnitNo
                                                       , "GPKGBAS_BASE.GET_UNITNO"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_OPER"}
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , this.Tag.ObjectNullString()}
                                                       , "UNITNO"
                                                       , "UNITNM"
                                                       , "UNITNO,UNITNM"
                                                       );
        }

        private void SetMount(string _strSerial)
        {
            SplashScreenManager.ShowForm(typeof(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM), true, false);
            SplashScreenManager.Default.SendCommand(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM.WaitFormCommand.SetDescription, "Mounting...");
            try
            {
                string _strSide = string.Empty;

                if (btnFront.Appearance.BackColor == Color.LimeGreen)
                    _strSide = "F";
                else if (btnRear.Appearance.BackColor == Color.LimeGreen)
                    _strSide = "R";
                else
                    _strSide = "N";

                WSResults _result = BASE_db.Execute_Proc( "PKGPRD_PROD.SET_MOUNT"
                                                        , 1
                                                        , new string[] {
                                                          "A_CLIENT"
                                                        , "A_COMPANY"
                                                        , "A_PLANT"
                                                        , "A_WRKORD"
                                                        , "A_SERIAL"
                                                        , "A_UNITNO"
                                                        , "A_SIDE"
                                                        , "A_USER" }
                                                        , new string[] {
                                                          Global.Global_Variable.CLIENT
                                                        , Global.Global_Variable.COMPANY
                                                        , Global.Global_Variable.PLANT
                                                        , txtWorkorder.EditValue.ObjectNullString()
                                                        , _strSerial
                                                        , gleUnitNo.EditValue.ObjectNullString()
                                                        , _strSide
                                                        , gleWorker.EditValue.ObjectNullString() }
                                                        );

                

                if (_result.ResultInt == 0)
                {
                    FormInitEvent();

                    if (_result.ResultDataSet.Tables[0].Rows.Count > 0)
                    {
                        ControlBinding(_result.ResultDataSet.Tables[0]);
                    }
                }
                else
                {
                    iDATMessageBox.ErrorMessage(base.BASE_Language.GetMessageString(_result.ResultString), this.Text, 3); 
                }
            }
            finally
            {
                SplashScreenManager.CloseForm(true);
            }

        }
        private void formWorkordData(string _strWorkord)
        {
            SplashScreenManager.ShowForm(typeof(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM), true, false);
            SplashScreenManager.Default.SendCommand(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM.WaitFormCommand.SetDescription, "Searching...");
            try
            {
                WSResults _result = BASE_db.Execute_Proc( "PKGPRD_PROD.GET_WORKORDER"
                                                        , 1
                                                        , new string[] {
                                                          "A_CLIENT"
                                                        , "A_COMPANY"
                                                        , "A_PLANT"
                                                        , "A_WRKORD" }
                                                        , new string[] {
                                                          Global.Global_Variable.CLIENT
                                                        , Global.Global_Variable.COMPANY
                                                        , Global.Global_Variable.PLANT
                                                        , _strWorkord }
                                                        );

                FormInitEvent();

                if (_result.ResultInt == 0)
                {
                    if (_result.ResultDataSet.Tables[0].Rows.Count > 0)
                    {
                        ControlBinding(_result.ResultDataSet.Tables[0]);
                        GetProdHist(_result.ResultDataSet.Tables[1]);
                    }
                }
                else
                {
                    iDATMessageBox.ErrorMessage(base.BASE_Language.GetMessageString(_result.ResultString), this.Text, 3); 
                }
            }
            finally
            {
                SplashScreenManager.CloseForm(true);
            }

        }
        private void Frominit()
        {
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
        }

        private void ControlBinding(DataTable _dt)
        {
            txtWorkorder.EditValue = _dt.Rows[0]["WRKORD"].ObjectNullString();
            txtWorkorder.Tag = _dt.Rows[0]["PRODPROGNO"].ObjectNullString();
            txtUnitStatus.EditValue = _dt.Rows[0]["UNITSTATUS"].ObjectNullString();
            txtWorkorder.Properties.AppearanceReadOnly.BackColor = CWrdEnableColor;
            txtWorkorder.Properties.AppearanceReadOnly.ForeColor = CwrdEnableForeColor;
            _strFileDir = _dt.Rows[0]["FILEPATH"].ObjectNullString();

            if (_dt.Rows[0]["UNITNO"].ObjectNullString() == "")
            {
                gleUnitNo.Properties.AppearanceReadOnly.BackColor = CWrdDisableColor;
                gleUnitNo.Properties.AppearanceReadOnly.ForeColor = CwrdDisableForeColor;
            }
            else
            {
                gleUnitNo.Properties.AppearanceReadOnly.BackColor = CWrdEnableColor;
                gleUnitNo.Properties.AppearanceReadOnly.ForeColor = CwrdEnableForeColor;
            }

            gleUnitNo.EditValue = _dt.Rows[0]["UNITNO"].ObjectNullString();

            if (_dt.Rows[0]["WORKER"].ObjectNullString() == "")
            {
                gleWorker.Properties.AppearanceReadOnly.BackColor = CWrdDisableColor;
                gleWorker.Properties.AppearanceReadOnly.ForeColor = CwrdDisableForeColor;
            }
            else
            {
                gleWorker.Properties.AppearanceReadOnly.BackColor = CWrdEnableColor;
                gleWorker.Properties.AppearanceReadOnly.ForeColor = CwrdEnableForeColor;
            }
            gleWorker.EditValue = _dt.Rows[0]["WORKER"].ObjectNullString();

            txtWirePartNo.EditValue = _dt.Rows[0]["N_W_PARTNO"].ObjectNullString();
            txtWireSerial.EditValue = _dt.Rows[0]["N_W_SERIAL"].ObjectNullString();
            txtWireStock.EditValue = _dt.Rows[0]["N_W_STOCK"].ObjectNullString();

            if (txtWireSerial.EditValue.ObjectNullString() != "")
            {
                txtWirePartNo.Properties.AppearanceReadOnly.BackColor = CWrdEnableColor;
                txtWirePartNo.Properties.AppearanceReadOnly.ForeColor = CwrdEnableForeColor;

                txtWireSerial.Properties.AppearanceReadOnly.BackColor = CWrdEnableColor;
                txtWireSerial.Properties.AppearanceReadOnly.ForeColor = CwrdEnableForeColor;

                txtWireStock.Properties.AppearanceReadOnly.BackColor = CWrdEnableColor;
                txtWireStock.Properties.AppearanceReadOnly.ForeColor = CwrdEnableForeColor;
            }

            txtFTerPartNo.EditValue = _dt.Rows[0]["F_T_PARTNO"].ObjectNullString();
            txtFTerSerial.EditValue = _dt.Rows[0]["F_T_SERIAL"].ObjectNullString();
            txtFTerStock.EditValue = _dt.Rows[0]["F_T_STOCK"].ObjectNullString();

            if (txtFTerSerial.EditValue.ObjectNullString() != "")
            {
                txtFTerPartNo.Properties.AppearanceReadOnly.BackColor = CWrdEnableColor;
                txtFTerPartNo.Properties.AppearanceReadOnly.ForeColor = CwrdEnableForeColor;

                txtFTerSerial.Properties.AppearanceReadOnly.BackColor = CWrdEnableColor;
                txtFTerSerial.Properties.AppearanceReadOnly.ForeColor = CwrdEnableForeColor;

                txtFTerStock.Properties.AppearanceReadOnly.BackColor = CWrdEnableColor;
                txtFTerStock.Properties.AppearanceReadOnly.ForeColor = CwrdEnableForeColor;
            }

            txtRTerPartNo.EditValue = _dt.Rows[0]["R_T_PARTNO"].ObjectNullString();
            txtRTerSerial.EditValue = _dt.Rows[0]["R_T_SERIAL"].ObjectNullString();
            txtRTerStock.EditValue = _dt.Rows[0]["R_T_STOCK"].ObjectNullString();

            if (txtRTerSerial.EditValue.ObjectNullString() != "")
            {
                txtRTerPartNo.Properties.AppearanceReadOnly.BackColor = CWrdEnableColor;
                txtRTerPartNo.Properties.AppearanceReadOnly.ForeColor = CwrdEnableForeColor;

                txtRTerSerial.Properties.AppearanceReadOnly.BackColor = CWrdEnableColor;
                txtRTerSerial.Properties.AppearanceReadOnly.ForeColor = CwrdEnableForeColor;

                txtRTerStock.Properties.AppearanceReadOnly.BackColor = CWrdEnableColor;
                txtRTerStock.Properties.AppearanceReadOnly.ForeColor = CwrdEnableForeColor;
            }

            txtFAppPartNo.EditValue = _dt.Rows[0]["F_A_PARTNO"].ObjectNullString();
            txtFAppSerial.EditValue = _dt.Rows[0]["F_A_SERIAL"].ObjectNullString();
            
            if (txtFAppSerial.EditValue.ObjectNullString() != "")
            {
                txtFAppPartNo.Properties.AppearanceReadOnly.BackColor = CWrdEnableColor;
                txtFAppPartNo.Properties.AppearanceReadOnly.ForeColor = CwrdEnableForeColor;

                txtFAppSerial.Properties.AppearanceReadOnly.BackColor = CWrdEnableColor;
                txtFAppSerial.Properties.AppearanceReadOnly.ForeColor = CwrdEnableForeColor;
            }

            txtRAppPartNo.EditValue = _dt.Rows[0]["R_A_PARTNO"].ObjectNullString();
            txtRAppSerial.EditValue = _dt.Rows[0]["R_A_SERIAL"].ObjectNullString();

            if (txtRAppSerial.EditValue.ObjectNullString() != "")
            {
                txtRAppPartNo.Properties.AppearanceReadOnly.BackColor = CWrdEnableColor;
                txtRAppPartNo.Properties.AppearanceReadOnly.ForeColor = CwrdEnableForeColor;

                txtRAppSerial.Properties.AppearanceReadOnly.BackColor = CWrdEnableColor;
                txtRAppSerial.Properties.AppearanceReadOnly.ForeColor = CwrdEnableForeColor;
            }

            if (_dt.Rows[0]["WRKORDSTATE"].ObjectNullString() == "Ready")
            {
                btnReady.Enabled = true;
                btnStart.Enabled = false;
                btnEnd.Enabled = false;

                if (bgwPickup.IsBusy)
                {
                    idatDxSimpleButton2.Text = "0";
                    bgwPickup.CancelAsync();
                }
            }
            else if (_dt.Rows[0]["WRKORDSTATE"].ObjectNullString() == "Start")
            {
                btnReady.Enabled = false;
                btnStart.Enabled = true;
                btnEnd.Enabled = true;

                if (bgwPickup.IsBusy)
                {
                    idatDxSimpleButton2.Text = "0";
                    bgwPickup.CancelAsync();
                }

            }
            else //"WRKORDSTATE" = "Run"
            {
                btnReady.Enabled = false;
                btnStart.Enabled = false;
                btnEnd.Enabled = true;

                spiPerformance.Enabled = true;
                btnPerformance.Enabled = true;

                spiPerformance.EditValue = _dt.Rows[0]["LOTUNITQTY"].ObjectNullString();

                if (!bgwPickup.IsBusy)
                {
                    //sharedAPI.ConnectRemoteServer(_strFileDir);

                    //if (Global.Global_Variable.IPADDRESS.StartsWith("10.3.20."))
                    //    sharedAPI.ConnectRemoteServer(@"\\10.3.20.18\CRIMP");
                    //else
                    //    sharedAPI.ConnectRemoteServer(@"\\10.3.10.18\CRIMP");

                    idatDxSimpleButton2.Text = (int.Parse(idatDxSimpleButton2.Text) + 1).ToString();
                    bgwPickup.RunWorkerAsync();
                }

            }

            if (_dt.Rows[0]["TENSILE"].ObjectNullString() == "OK")
            {
                btnTensile.Appearance.BackColor = Color.Green;
                btnTensile.Appearance.Options.UseBackColor = true;
            }
            else
            {
                btnTensile.Appearance.BackColor = Color.White;
                btnTensile.Appearance.Options.UseBackColor = true;
            }

            btnFront.Appearance.BackColor = Color.White;
            btnRear.Appearance.BackColor = Color.White;

            
 
        }
        private bool SetAutoProductEnd( string p_wrkord, string p_wrkordseq, string p_prodprogno, string p_ordqty, string p_prodqty, 
                                        string p_sttime, string p_entime, string p_losstime, string p_uph, string p_log)
        {
            WSResults _result = BASE_db.Execute_Proc( "PKGPRD_PROD.SET_PROD_END"
                                                    , 4
                                                    , new string[] {
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "nn"
                                                    , "A_PRODPROGNO"
                                                    , "A_WRKORDSEQ"
                                                    , "A_IFMODE"
                                                    , "A_ORDQTY"
                                                    , "A_PRODQTY"
                                                    , "A_STTIME"
                                                    , "A_ENTIME"
                                                    , "A_LOSSTIME"
                                                    , "A_UPH"
                                                    , "A_LOG"
                                                    , "A_USER"}
                                                    , new string[] {
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT
                                                    , p_wrkord
                                                    , p_prodprogno
                                                    , p_wrkordseq
                                                    , "COMPLETE"
                                                    , p_ordqty
                                                    , p_prodqty
                                                    , p_sttime
                                                    , p_entime
                                                    , p_losstime
                                                    , p_uph
                                                    , p_log
                                                    , gleWorker.EditValue.ObjectNullString() }
                                                    );

            if (_result.ResultInt == 0)
            {
                FormInitEvent();

                if (_result.ResultDataSet.Tables[0].Rows.Count > 0)
                {
                    ControlBinding(_result.ResultDataSet.Tables[0]);
                    GetProdHist(_result.ResultDataSet.Tables[1]);
                    ShowMessage("");
                }

                return true;
            }
            else
            {
                ShowMessage(_result.ResultString);
                return true;
                
            }
        }
        private void ShowMessage(string p_log)
        {
            if (this.InvokeRequired)
            {
                var d = new SetThreadCallback(ShowMessage);
                this.Invoke(d, new object[] { p_log });
            }
            else
            {
                lblMessage.Text = p_log;
            }
        }
        private void FormInitEvent()
        {
            btnReady.Enabled = false;
            btnStart.Enabled = false;
            btnEnd.Enabled = false;

            btnPerformance.Enabled = false;

            btnTensile.LookAndFeel.UseDefaultLookAndFeel = false;
            btnTensile.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            btnFront.LookAndFeel.UseDefaultLookAndFeel = false;
            btnFront.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            btnRear.LookAndFeel.UseDefaultLookAndFeel = false;
            btnRear.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;

            btnTensile.Appearance.Options.UseBackColor = true;
            btnFront.Appearance.Options.UseBackColor = true;
            btnRear.Appearance.Options.UseBackColor = true;

            btnTensile.Appearance.BackColor = Color.White;
            btnFront.Appearance.BackColor = Color.White;
            btnRear.Appearance.BackColor = Color.White;
            
            gcList.DataSource = null;

            txtWorkorder.EditValue = null;
            txtWorkorder.Tag = null;
            txtWirePartNo.EditValue = null;
            txtWireSerial.EditValue = null;
            txtWireStock.EditValue = null;
            txtFTerPartNo.EditValue = null;
            txtFTerSerial.EditValue = null;
            txtFTerStock.EditValue = null;
            txtRTerPartNo.EditValue = null;
            txtRTerSerial.EditValue = null;
            txtRTerStock.EditValue = null;
            txtFAppPartNo.EditValue = null;
            txtFAppSerial.EditValue = null;
            txtRAppPartNo.EditValue = null;
            txtRAppSerial.EditValue = null;

            spiPerformance.EditValue = 0;
            spiPerformance.Enabled = false;

            gleWorker.EditValue = null;

            txtWorkorder.Properties.AppearanceReadOnly.BackColor = CWrdDisableColor;
            txtWorkorder.Properties.AppearanceReadOnly.ForeColor = CwrdDisableForeColor;
            txtWorkorder.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            txtWorkorder.Properties.AppearanceReadOnly.Options.UseForeColor = true;

            gleUnitNo.Properties.AppearanceReadOnly.BackColor = CWrdDisableColor;
            gleUnitNo.Properties.AppearanceReadOnly.ForeColor = CwrdDisableForeColor;
            gleUnitNo.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            gleUnitNo.Properties.AppearanceReadOnly.Options.UseForeColor = true;

            txtWirePartNo.Properties.AppearanceReadOnly.BackColor = CWrdDisableColor;
            txtWirePartNo.Properties.AppearanceReadOnly.ForeColor = CwrdDisableForeColor;
            txtWireSerial.Properties.AppearanceReadOnly.BackColor = CPrdDisableColor;
            txtWireStock.Properties.AppearanceReadOnly.BackColor = CPrdDisableColor;
            txtWirePartNo.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            txtWirePartNo.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            txtWireSerial.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            txtWireStock.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            
            txtFTerPartNo.Properties.AppearanceReadOnly.BackColor = CWrdDisableColor;
            txtFTerPartNo.Properties.AppearanceReadOnly.ForeColor = CwrdDisableForeColor;
            txtFTerSerial.Properties.AppearanceReadOnly.BackColor = CPrdDisableColor;
            txtFTerStock.Properties.AppearanceReadOnly.BackColor = CPrdDisableColor;
            txtFTerPartNo.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            txtFTerPartNo.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            txtFTerSerial.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            txtFTerStock.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            
            txtRTerPartNo.Properties.AppearanceReadOnly.BackColor = CWrdDisableColor;
            txtRTerPartNo.Properties.AppearanceReadOnly.ForeColor = CwrdDisableForeColor;
            txtRTerSerial.Properties.AppearanceReadOnly.BackColor = CPrdDisableColor;
            txtRTerStock.Properties.AppearanceReadOnly.BackColor = CPrdDisableColor;
            txtRTerPartNo.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            txtWirePartNo.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            txtRTerSerial.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            txtRTerStock.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            
            txtFAppPartNo.Properties.AppearanceReadOnly.BackColor = CWrdDisableColor;
            txtFAppPartNo.Properties.AppearanceReadOnly.ForeColor = CwrdDisableForeColor;
            txtFAppSerial.Properties.AppearanceReadOnly.BackColor = CPrdDisableColor;
            txtFAppPartNo.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            txtWirePartNo.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            txtFAppSerial.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            
            txtRAppPartNo.Properties.AppearanceReadOnly.BackColor = CWrdDisableColor;
            txtRAppPartNo.Properties.AppearanceReadOnly.ForeColor = CwrdDisableForeColor;
            txtRAppSerial.Properties.AppearanceReadOnly.BackColor = CPrdDisableColor;
            txtRAppPartNo.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            txtWirePartNo.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            txtRAppSerial.Properties.AppearanceReadOnly.Options.UseBackColor = true;



        }

        private bool Print(DataTable dTable, int nCopies)
        {
            using (RPT.RPTA201 _rpt = new RPT.RPTA201(dTable, nCopies))
            {
                _rpt.RptPrint();
            }
            return true;
        }

        private void SetCreateInterfaceFile(DataTable _dt)
        {
            if (_dt.Rows.Count > 0)
            {
                string _strFileName = _dt.Rows[0]["FILENAME"].ObjectNullString();
                _strFileDir = _dt.Rows[0]["FILEPATH"].ObjectNullString();
                _strWorkInfo = _dt.Rows[0]["WORKINFO"].ObjectNullString();

                txtFileSave(_strFileDir, _strFileName, _strWorkInfo);
                
            }
        }

        private void txtFileSave(string _strFileDir, string _strFileName,  string _data)
        {
            try
            {
                string sLogDirectory = _strFileDir;
                string sLogFile = sLogDirectory + @"\ORDER\" + _strFileName + ".txt";

                if (!Directory.Exists(sLogDirectory))
                    Directory.CreateDirectory(sLogDirectory);

                if (File.Exists(sLogFile))
                    File.Delete(sLogFile);

                FileStream fs = new FileStream(sLogFile, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);

                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(_data);

                sw.Flush();
                sw.Close();
                fs.Close();
            }
            catch (Exception)
            {
                //AddLogEvent(new AddLogEventArgs("Exception[LogFileSave] => " + ex.Message, LogType.Exclamation));
            }
        }
        #endregion

        #region [private Control Event]
        private void bgwPickup_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            List<FileInfo> _OrgFiles = null;
            List<FileInfo> _CopyFiles = null;

            string _moveFolder = Application.StartupPath + @"\PROD\";

            DirectoryInfo di = new DirectoryInfo(_moveFolder);

            if (di.Exists == false)
            {
                di.Create();
            }

            if (bgwPickup.CancellationPending) idatDxSimpleButton2.Text = "0";

            while (!bgwPickup.CancellationPending)
            {
                try
                {
                    // 전체 가져오기
                    DirectoryInfo directoryOrgInfo = new DirectoryInfo(_strFileDir + @"\PROD\");
                    _OrgFiles = directoryOrgInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly).OrderBy(t => t.LastWriteTime).ToList();

                    foreach (FileInfo fileFullName in _OrgFiles)
                    {
                        if (File.Exists(fileFullName.DirectoryName + @"\" + fileFullName.Name))
                        {
                            File.Move(fileFullName.DirectoryName + @"\" + fileFullName.Name, _moveFolder + fileFullName.Name);
                            Thread.Sleep(100);
                        }
                    }

                    DirectoryInfo directoryCopyInfo = new DirectoryInfo(_moveFolder);
                    _CopyFiles = directoryCopyInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly).OrderBy(t => t.LastWriteTime).ToList();

                    // Grid에 추가
                    foreach (FileInfo fileFullName in _CopyFiles)
                    {
                        bool _bResult = false;
                        if (File.Exists(fileFullName.DirectoryName+ @"\" + fileFullName.Name))
                        {
                            Thread.Sleep(300);

                            fileFullName.IsReadOnly = false;

                            string[] lines = File.ReadAllLines(fileFullName.DirectoryName + @"\" + fileFullName.Name, Encoding.Default);

                            foreach (string line in lines)
                            {
                                string[] words = line.Split(';');

                                if (words[0] == "")
                                {
                                    _bResult = true;
                                }
                                else
                                {
                                    if (fileFullName.Name.Contains("Complete"))
                                    {
                                        _bResult = SetAutoProductEnd(words[0], words[1], words[2], words[3], words[4], words[5], words[6], words[7], words[8], line);
                                    }
                                    else if (fileFullName.Name.Contains("Result"))
                                    {
                                        _bResult = SetPerformance(words[0], words[5], line);
                                    }
                                    else if (fileFullName.Name.Contains("Error"))
                                    {
                                        _bResult = SetError(words[0], words[1], words[2], words[3], words[4], line);
                                    }
                                    else
                                    {
                                        _bResult = true;
                                    }
                                }

                                if (_bResult == false && words[0] != txtWorkorder.EditValue.ObjectNullString())
                                {
                                    _bResult = true;
                                }
                            }

                            if (_bResult == false)
                                break;

                            if (_bResult)
                            {
                                for (int i = 0; i < 10; i++) //파일 복사 확인
                                {
                                    if (File.Exists(fileFullName.DirectoryName + @"\" + fileFullName.Name))
                                    {
                                        File.Delete(fileFullName.DirectoryName + @"\" + fileFullName.Name);
                                        
                                        Thread.Sleep(100);

                                        if (!File.Exists(fileFullName.DirectoryName + @"\" + fileFullName.Name))
                                        {
                                            ShowMessage("[" + i.ObjectNullString() + "]" + fileFullName.DirectoryName + @"\" + fileFullName.Name);
                                            break;
                                        }
                                    }
                                }
                                
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
                finally
                {
                    _OrgFiles = null;
                    _CopyFiles = null;
                }

                Thread.Sleep(2000);
            }
            
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            btnFront.Appearance.BackColor = Color.White;
            btnRear.Appearance.BackColor = Color.White;
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            if (gleUnitNo.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.ErrorMessage("MSG_ER_PRD_051", this.Text, 3); //호기를 선택하세요.
                return;
            }

            if (gleWorker.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.ErrorMessage("MSG_ER_PRD_098", this.Text, 3); //실작업자 선택하세요.
                return;
            }

            WSResults _result = BASE_db.Execute_Proc( "PKGPRD_PROD.SET_PROD_READY"
                                                    , 1
                                                    , new string[] {
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_WRKORD"
                                                    , "A_UNITNO"
                                                    , "A_USER"}
                                                    , new string[] {
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT
                                                    , txtWorkorder.EditValue.ObjectNullString()
                                                    , gleUnitNo.EditValue.ObjectNullString()
                                                    , gleWorker.EditValue.ObjectNullString() }
                                                    );

            if (_result.ResultInt == 0)
            {
                FormInitEvent();

                if (_result.ResultDataSet.Tables[0].Rows.Count > 0)
                {
                    ControlBinding(_result.ResultDataSet.Tables[0]);
                    GetProdHist(_result.ResultDataSet.Tables[1]);
                }
            }
            else
            {
                iDATMessageBox.ErrorMessage(_result.ResultString, this.Text, 3); 
            }

        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            WSResults _result = BASE_db.Execute_Proc( "PKGPRD_PROD.SET_PROD_START"
                                                    , 1
                                                    , new string[] {
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_WRKORD"
                                                    , "A_PRODPROGNO"
                                                    , "A_USER"}
                                                    , new string[] {
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT
                                                    , txtWorkorder.EditValue.ObjectNullString()
                                                    , txtWorkorder.Tag.ObjectNullString()
                                                    , gleWorker.EditValue.ObjectNullString() }
                                                    );

            if (_result.ResultInt == 0)
            {
                FormInitEvent();

                if (_result.ResultDataSet.Tables[0].Rows.Count > 0)
                {
                    ControlBinding(_result.ResultDataSet.Tables[0]);
                    GetProdHist(_result.ResultDataSet.Tables[1]);
                    SetCreateInterfaceFile(_result.ResultDataSet.Tables[2]);

                }
            }
            else
            {
                iDATMessageBox.ErrorMessage(_result.ResultString, this.Text, 3); 
            }

        }
        private void btnEnd_Click(object sender, EventArgs e)
        {
            WSResults _result = BASE_db.Execute_Proc( "PKGPRD_PROD.SET_PROD_END"
                                                    , 1
                                                    , new string[] {
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_WRKORD"
                                                    , "A_PRODPROGNO"
                                                    , "A_USER"}
                                                    , new string[] {
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT
                                                    , txtWorkorder.EditValue.ObjectNullString()
                                                    , txtWorkorder.Tag.ObjectNullString()
                                                    , gleWorker.EditValue.ObjectNullString() }
                                                    );

            if (_result.ResultInt == 0)
            {
                FormInitEvent();

                if (_result.ResultDataSet.Tables[0].Rows.Count > 0)
                {
                    ControlBinding(_result.ResultDataSet.Tables[0]);
                    GetProdHist(_result.ResultDataSet.Tables[1]);

                   if (bgwPickup.IsBusy)
                       bgwPickup.CancelAsync();

                }
            }
            else
            {
                iDATMessageBox.ErrorMessage(_result.ResultString, this.Text, 3);
            }

        }
        private void btnPerformance_Click(object sender, EventArgs e)
        {
            //SetPerformance(spiPerformance.EditValue.ObjectNullString());
        }
        
        #endregion

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                Get_BarcodeType(txtBarcode.EditValue.ObjectNullString());
        }

        private void idatDxSimpleButton2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + @"\PROD");
        }


    }
}