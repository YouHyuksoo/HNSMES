#pragma warning disable IDE1006 // Naming Styles
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Linq;
using DevExpress.XtraBars;

using HAENGSUNG_HNSMES_UI.Forms.COM;
using HAENGSUNG_HNSMES_UI.Class;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using DevExpress.Utils;

using System.Deployment.Application;
using System.Collections;
using System.Diagnostics;
using IDAT.WebService;
using DevExpress.XtraEditors;
using DevExpress.RealtorWorld.Win;
using System.Reflection;
using HAENGSUNG_HNSMES_UI.WebService.Access;
using DevExpress.XtraGrid.Columns;

using System.Text;
using DevExpress.XtraSplashScreen;


namespace HAENGSUNG_HNSMES_UI
{
    public partial class MainForm : RibbonForm
    {
        #region 전역변수
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++전역변수
        //클래스

        HAENGSUNG_HNSMES_UI.WebService.Business.IDatabaseProcess _DB = null;

        public HAENGSUNG_HNSMES_UI.WebService.Business.IDatabaseProcess DB
        {
            get { return _DB; }
            set { _DB = value; }
        }

        readonly LanguageInformation m_clsLan = new LanguageInformation();
        readonly LogUtility m_clsLog = new LogUtility();
        FormWindowState m_frmsts;
        //문자
        private string m_programMessage = "";
        private string m_subMessage = "";

        private string m_strData = "";
        private string m_strSubData = "";
        private string m_strThirdData = "";
        private string m_strfourdData = "";
        //숫자
        private int m_intMessageCount = 10;
        //이미지
        //이진
        private bool m_blnLoad = true;

        // SSO(VB6 Link) 를 통한 자동 로그인 ID
        private string m_AutoLoginID = "";

        private readonly AlertWindow mount = null;
        private NotifyWindow update = null;
        private readonly AlertWindow mountstock = null;
        private AlertWindow expiry = null;
        private AlertWindow CircuitJIG = null;

        private string mExpiryMaterial = "";
        private string mCircuitJIG = "";

        private COMHELP frm;

        #endregion
        
        #region 속성

        /// <summary>
        /// SSO(VB6 Link) 를 통한 자동 로그인
        /// </summary>
        public string AutoLogin_ID
        {
            get { return m_AutoLoginID; }
            set { this.m_AutoLoginID = value; }
        }

        /// <summary>
        /// 프로그램의 메시지를 설정하거나 가져옵니다.
        /// </summary>
        public string ProgramMessage
        {
            get { return m_programMessage; }
            set
            {
                try
                {
                    m_programMessage = value;

                    // 메시지는 한줄에 표시해야 되기 때문에 엔터값은 모두 없앤다.
                    lblMessage.Caption = string.Format("[{0}] {1}", DateTime.Now.ToShortTimeString(), value.Replace("\r", "").Replace("\n", ""));
                    m_intMessageCount = 20;
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// 프로그램의 보조 메시지를 설정하거나 가져옵니다.
        /// </summary>
        public string SubMessage
        {
            get { return m_subMessage; }
            set
            {
                m_subMessage = value;

                if ((value == "0") || (value == ""))
                    btnSubMsg.Caption = "";
                else
                    btnSubMsg.Caption = value;
            }
        }
        #endregion

        #region 생성

        public MainForm()
        {
            InitializeComponent();

            InitSkinGallery();
            // 프린트 타입을 설정
            Global.Global_Variable.gv_sPRCommType = Settings_IDAT.Default.Print_CommunicationType;

            this.SetStyle(ControlStyles.DoubleBuffer, true);
            //스킨을 설정합니다.
            LAF.LookAndFeel.SkinName = Settings_IDAT.Default.SKIN;

            //화면 최대화
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.WindowState = FormWindowState.Maximized;

            //// 홍성원      : 매뉴얼 작업용 - 추후 삭제 
            //// 작업 시작일 : 2014.11.05
            //this.Width = 1061;
            //this.Height = 825;
            //this.WindowState = FormWindowState.Normal;

            //XML 디렉터리를 만든다..
            Directory.CreateDirectory(Application.StartupPath + "\\XML_FILES\\");

            _DB = new HAENGSUNG_HNSMES_UI.WebService.Business.WSDatabaseProcess();

            // 윈도우 스타일 설정 2012-04-17
            string strType = Settings_IDAT.Default.WINSTYLE;

            switch (strType.ToUpper())
            {
                case "NORMAL":
                    pnlTopMenu.Visible = false;
                    panelControl1.Visible = true;
                    panelControl_Tile.Visible = false;
                    panelControl_TileBack.Visible = false;
                    break;
                case "RIBBON":
                    pnlTopMenu.Visible = true;
                    panelControl1.Visible = false;
                    panelControl_Tile.Visible = false;
                    panelControl_TileBack.Visible = false;
                    break;
                case "TILE":
                    pnlTopMenu.Visible = false;
                    panelControl1.Visible = false;
                    hideContainerLeft.Visible = false;
                    panelControl_Tile.Visible = true;
                    panelControl_TileBack.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SplashScreenManager.CloseForm();

            //idatNoticeInfo1.LatestNewsText = " ";
            //idatNoticeInfo1.NoticeText = " ";
            //using (HAENGSUNG_HNSMES_UI.Forms.COM.COMSCANNERSETTING _frmScanner = new HAENGSUNG_HNSMES_UI.Forms.COM.COMSCANNERSETTING())
            //{
            //    _frmScanner.FormClass = "W";
            //    _frmScanner.ShowDialog(this);
            //}

            if (Scanner1.IsOpen) Scanner1.Close();
            if (Scanner2.IsOpen) Scanner2.Close();
            if (Scanner3.IsOpen) Scanner3.Close();
            if (Scanner4.IsOpen) Scanner4.Close();

            ScannerProcess _clsScan = new ScannerProcess();
            
            _clsScan.Open_Serial(Scanner1, "SCANNER1");
            _clsScan.Open_Serial(Scanner2, "SCANNER2");
            _clsScan.Open_Serial(Scanner3, "SCANNER3");
            _clsScan.Open_Serial(Scanner4, "SCANNER4");


        }




        private void MainForm_Shown(object sender, EventArgs e)
        {
            m_blnLoad = false;
            this.rcPageTop_SizeChanged(null, null);

            iDATMessageBox.ShowWait(this, "Loading", "Program Initialization");

            try
            {
                iDATMessageBox.WaitChangeCommand(IDAT.UI.MessageBox.COMWAITFORM.WaitFormCommand.SetDescription, "WebService Service Check");
                Application.DoEvents();
                // 웹서비스를 체크합니다.
                // DB컬럼 정보를 데이터셋에 저장을 한다.
                bool _bnlReturn = _DB.GetWsConnectStatus();

                if (_bnlReturn)
                {
                    iDATMessageBox.WaitChangeCommand(IDAT.UI.MessageBox.COMWAITFORM.WaitFormCommand.SetDescription, "WebService Check - Success");
                }
                else
                {
                    iDATMessageBox.CloseWait();
                    iDATMessageBox.ErrorMessage("Web Service가 정상실행되지 않아 프로그램을 실행할 수 없습니다.", "오류", 5);

                    this.Close();
                    Application.Exit();
                    return;
                }
                // 프로그램 용어 정보 셋팅
                iDATMessageBox.WaitChangeCommand(IDAT.UI.MessageBox.COMWAITFORM.WaitFormCommand.SetDescription, "Language Check");
                Application.DoEvents();

                m_clsLan.SetLanguage();

                // 시스템 명 셋팅
                WSResults result = _DB.Execute_Proc( "PKGSYS_COMM.GET_SYSTEM"
                                                   , 1
                                                   , new string[] { 
                                                     "A_CLIENT"
                                                   , "A_COMPANY"
                                                   , "A_PLANT" }
                                                   , new string[] { 
                                                     Global.Global_Variable.CLIENT
                                                   , Global.Global_Variable.COMPANY
                                                   , Global.Global_Variable.PLANT }
                                                   );

                if (result.ResultInt == 0)
                    if (result.ResultDataSet.Tables[0].Rows.Count > 0)
                    {
                        this.Text = string.Format("{0}", result.ResultDataSet.Tables[0].Rows[0][1].ObjectNullString()) + "          ";
                        Global.Global_Variable.SYSTEMCODE = result.ResultDataSet.Tables[0].Rows[0][0].ObjectNullString();
                    }
                    else
                    {
                        Class.iDATMessageBox.WARNINGMessage("No SystemCode", "Warning", 5);
                        Global.Global_Variable.SYSTEMCODE = "";
                        this.Text = "";
                    }
                else
                {
                    Class.iDATMessageBox.WARNINGMessage("No SystemCode", "Warning", 5);
                    Global.Global_Variable.SYSTEMCODE = "";
                    this.Text = "";
                }


            }
            catch (Exception ex)
            {
                iDATMessageBox.ErrorMessage(ex, Global.Global_Variable.USER_ID, "", null);
            }
            finally
            {
                iDATMessageBox.CloseWait();
            }

            ////////////////////////////////////////////////////////////////////////////
            // SSO처리
            ////////////////////////////////////////////////////////////////////////////
            System.Collections.Hashtable AppParam = new System.Collections.Hashtable(); // 웹호출 파라메터 담을 변수
            System.Collections.Specialized.NameValueCollection WebQuery = GetQueryStringParameters();

            // 웹에서 호출할경우 userid=IDIF
            // 위와 같은 식으로 파라메터가 넘어온다. ?이후 파라메터를 잘라 해쉬테이블에 넣어 관리함
            // 커맨드라인 파라메터용(DEBUG)
            if (!ApplicationDeployment.IsNetworkDeployed)
            {
                //foreach (string s in Environment.GetCommandLineArgs())
                //{
                //    string[] inputArgument = null;

                //    inputArgument = s.Split('&');
                //    foreach (string param in inputArgument)
                //    {
                //        try
                //        {
                //            AppParam[param.Split('=').GetValue(0)] = param.Split('=').GetValue(1);
                //        }
                //        catch (Exception ex)
                //        {
                //        }
                //    }
                //}
            }
            else
            {
                if ((Environment.GetCommandLineArgs().Length > 0) && (WebQuery.Count > 0))
                {
                    //웹URL방식
                    if (!string.IsNullOrEmpty(WebQuery.Get("USERID")))
                        AppParam["USERID"] = WebQuery.Get("USERID");
                    //일단 암호화되지않은 ID도 지원한다
                }
            }

            if ((Environment.GetCommandLineArgs().Length > 0) && (WebQuery.Count > 0))
            {
                if (!string.IsNullOrEmpty(AppParam["USERID"] + ""))
                    this.AutoLogin_ID = (AppParam["USERID"] + "");
            }

            rpControl.Visible = true;
            //groupLogin.Visibility = BarItemVisibility.Always;

            // 로그인 화면을 보여준다.

            this.btnLogin_ItemClick(null, null);

            // 모든 버튼을 비활성화
            btnPrint.Enabled = false;
            btnPrint1.Enabled = false;

            btnDelete.Enabled = false;
            btnDelete1.Enabled = false;

            btnSave.Enabled = false;
            btnSave1.Enabled = false;

            btnEdit.Enabled = false;
            btnEdit1.Enabled = false;

            btnNew.Enabled = false;
            btnNew1.Enabled = false;

            btnRefresh.Enabled = false;
            btnRefresh1.Enabled = false;

            btnStop.Enabled = false;
            btnStop1.Enabled = false;

            btnSearch.Enabled = false;
            btnSearch1.Enabled = false;

            btnInit.Enabled = false;
            btnInit1.Enabled = false;
        }

        public System.Collections.Specialized.NameValueCollection GetQueryStringParameters()
        {
            System.Collections.Specialized.NameValueCollection NameValueTable = new System.Collections.Specialized.NameValueCollection();
            try
            {
                if ((System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed))
                {
                    string QueryString = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.ActivationUri.Query;
                    NameValueTable = System.Web.HttpUtility.ParseQueryString(QueryString);
                }
            }
            catch
            {
                //Class.iDATMessageBox.ErrorMessage(ex, Global.Global_Variable.USER_ID);
            }
            return NameValueTable;
        }

        #endregion

        #region 이벤트

        #region 페이지 공통 버튼 이벤트

        private void Save_BtnHistory(BarButtonItem p_control)
        {
            string _formname = "";
            if (this.ActiveMdiChild != null) _formname = this.ActiveMdiChild.Name;
            m_clsLog.SaveUseHistory(_formname, p_control.Name + "_Click", _formname + " : " + p_control.Name + "_Click", "");
        }

        // ######################################초기화##############################
        public void btnInit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ActiveMdiChild == null)
                return;


            try
            {
                if (Settings_IDAT.Default.WINSTYLE != "Tile")
                {
                    ((HAENGSUNG_HNSMES_UI.Class.itfButton)this.ActiveMdiChild).InitButton_Click();
                    
                    this.Save_BtnHistory(btnInit);
                }
                else
                {
                    ((HAENGSUNG_HNSMES_UI.Class.itfButton)this.module).InitButton_Click();
                    this.Save_BtnHistory(btnInit);
                }
            }
            catch
            {
            }
        }
        private void btnInit1_Click(object sender, EventArgs e)
        {
            btnInit_ItemClick(null, null);
        }

        // ######################################닫기################################
        public void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Settings_IDAT.Default.WINSTYLE != "Tile")
            {
                if (this.ActiveMdiChild == null) return;
                this.ActiveMdiChild.Close();
            }
            else
            {
                if (this.module == null) return;
                this.module.Close();
            }
        }
        private void btnClose1_Click(object sender, EventArgs e)
        {
            btnClose_ItemClick(null, null);
        }

        // ######################################모두닫기############################
        public void btnCloseAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ActiveMdiChild == null) return;
            foreach (Form _frm in this.MdiChildren)
            {
                _frm.Close();
            }
        }
        private void btnCloseAll1_Click(object sender, EventArgs e)
        {
            btnCloseAll_ItemClick(null, null);
        }

        // ######################################신규################################
        public void btnNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ActiveMdiChild == null)
                return;
            try
            {
                if (Settings_IDAT.Default.WINSTYLE != "Tile")
                {
                    ((HAENGSUNG_HNSMES_UI.Class.itfButton)this.ActiveMdiChild).NewButton_Click();
                }
                else
                {
                    ((HAENGSUNG_HNSMES_UI.Class.itfButton)this.module).NewButton_Click();
                }
            }
            catch
            {
            }
        }
        private void btnNew1_Click(object sender, EventArgs e)
        {
            btnNew_ItemClick(null, null);
        }

        // ######################################수정################################
        public void btnEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ActiveMdiChild == null)
                return;

            try
            {
                if (Settings_IDAT.Default.WINSTYLE != "Tile")
                {
                    ((HAENGSUNG_HNSMES_UI.Class.itfButton)this.ActiveMdiChild).EditButton_Click();
                }
                else
                {
                    ((HAENGSUNG_HNSMES_UI.Class.itfButton)this.module).EditButton_Click();
                    
                }
                this.Save_BtnHistory(btnEdit);
            }
            catch
            {
            }
        }
        private void btnMainEdit_Click(object sender, EventArgs e)
        {
            btnEdit_ItemClick(null, null);
        }

        // ######################################저장################################
        public void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ActiveMdiChild == null)
                return;

            try
            {
                if (Settings_IDAT.Default.WINSTYLE != "Tile")
                {
                    ((HAENGSUNG_HNSMES_UI.Class.itfButton)this.ActiveMdiChild).SaveButton_Click();
                }
                else
                {
                    ((HAENGSUNG_HNSMES_UI.Class.itfButton)this.module).SaveButton_Click();
                }
                this.Save_BtnHistory(btnSave);
            }
            catch
            {
            }
        }
        private void btnSave1_Click(object sender, EventArgs e)
        {
            btnSave_ItemClick(null, null);
        }

        // ######################################조회################################
        public void btnSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ActiveMdiChild == null)
                return;

            try
            {
                if (Settings_IDAT.Default.WINSTYLE != "Tile")
                {
                    ((HAENGSUNG_HNSMES_UI.Class.itfButton)this.ActiveMdiChild).SearchButton_Click();
                }
                else
                {
                    ((HAENGSUNG_HNSMES_UI.Class.itfButton)this.module).SearchButton_Click();
                }
                this.Save_BtnHistory(btnSearch);
            }
            catch
            {
            }
        }
        private void btnSearch1_Click(object sender, EventArgs e)
        {
            btnSearch_ItemClick(null, null);
        }

        // ######################################삭제################################
        public void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ActiveMdiChild == null)
                return;

            //if (Class.iDATMessageBox.QuestionMessage("정말 삭제 하시겠습니까?", "Delete") != System.Windows.Forms.DialogResult.Yes)
            //    return;

            try
            {
                if (Settings_IDAT.Default.WINSTYLE != "Tile")
                {
                    ((HAENGSUNG_HNSMES_UI.Class.itfButton)this.ActiveMdiChild).DeleteButton_Click();
                }
                else
                {
                    ((HAENGSUNG_HNSMES_UI.Class.itfButton)this.module).DeleteButton_Click();
                }
                this.Save_BtnHistory(btnSearch);
            }
            catch
            {
            }
        }
        private void btnDelete1_Click(object sender, EventArgs e)
        {
            btnDelete_ItemClick(null, null);
        }

        // ######################################출력################################
        public void btnPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ActiveMdiChild == null)
                return;

            try
            {
                if (Settings_IDAT.Default.WINSTYLE != "Tile")
                {
                    ((HAENGSUNG_HNSMES_UI.Class.itfButton)this.ActiveMdiChild).PrintButton_Click();
                }
                else
                {
                    ((HAENGSUNG_HNSMES_UI.Class.itfButton)this.module).PrintButton_Click();
                }
                this.Save_BtnHistory(btnPrint);
            }
            catch
            {
            }
        }
        private void btnPrint1_Click(object sender, EventArgs e)
        {
            btnPrint_ItemClick(null, null);
        }

        // ######################################정지################################
        public void btnStop_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ActiveMdiChild == null)
                return;

            try
            {
                if (Settings_IDAT.Default.WINSTYLE != "Tile")
                {
                    ((HAENGSUNG_HNSMES_UI.Class.itfButton)this.ActiveMdiChild).StopButton_Click();
                }
                else
                {
                    ((HAENGSUNG_HNSMES_UI.Class.itfButton)this.module).StopButton_Click();
                }
                this.Save_BtnHistory(btnPrint);
            }
            catch
            {
            }
        }
        private void btnStop1_Click(object sender, EventArgs e)
        {
            btnStop_ItemClick(null, null);
        }

        // ######################################새로고침############################
        public void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ActiveMdiChild == null)
                return;

            try
            {
                if (Settings_IDAT.Default.WINSTYLE != "Tile")
                {
                    ((HAENGSUNG_HNSMES_UI.Class.itfButton)this.ActiveMdiChild).RefreshButton_Click();
                }
                else
                {
                    ((HAENGSUNG_HNSMES_UI.Class.itfButton)this.module).RefreshButton_Click();
                }
                this.Save_BtnHistory(btnPrint);
            }
            catch
            {
            }
        }
        private void btnRefresh1_Click(object sender, EventArgs e)
        {
            btnRefresh_ItemClick(null, null);
        }

        #endregion

        #region 상단버튼 이벤트

        /// <summary>
        /// 로그인 버튼 클릭 이벤트
        /// </summary>
        /// <remarks>
        /// 로그인을 수행합니다. 로그인 권한에 따라 메뉴를 설정합니다.
        /// </remarks>
        private void btnLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
            /// 캡션에 따라 로그인, 로그아웃 수행
            if (btnLogin.Caption.ToUpper() == "LOG IN")  //로그인 수행
            {
                DialogResult _dlgRes = System.Windows.Forms.DialogResult.Cancel;

                using (HAENGSUNG_HNSMES_UI.Forms.COM.COMLOGIN _frmLogin = new Forms.COM.COMLOGIN())
                {
                    _frmLogin.FormClass = "W";

                    // SSO 처리 경우는 자동 로그인한다.
                    if (this.m_AutoLoginID != "")
                        _dlgRes = _frmLogin.AutoLogin(this.m_AutoLoginID);
                    else
                        _dlgRes = _frmLogin.ShowDialog(this);

                    // SSO 처리 경우는 자동 로그인 기록을 삭제한다.
                    this.m_AutoLoginID = "";
                }

                if (_dlgRes == DialogResult.Yes)
                {
                    SplashScreenManager.ShowForm(this, typeof(COMWAITFORM), true, true, false);
                    SplashScreenManager.Default.SendCommand(COMWAITFORM.WaitFormCommand.SetCaption, m_clsLan.GetMessageString("MENULOADING"));
                    SplashScreenManager.Default.SendCommand(COMWAITFORM.WaitFormCommand.SetDescription, m_clsLan.GetMessageString("LOADING"));

                    /// 로그인이 성공을 하게되면
                    /// 로그인 버튼을 -> 로그아웃을 변경을 하고 사용자 권한에 맞는 메뉴를 구성한다.
                    btnLogin.Caption = "Log out";
                    btnRegister.Caption = "My Settings";
                    lblLogin.Caption = GetLoginInfoString();

                    // 사용자 등록은 관리자가 이전 MES 정보를 참고하여 관리자가 직접 한다.
                    this.btnRegister.Visibility = BarItemVisibility.Always;


                    m_clsLog.SaveLogInOut(LogInOut.Login);

                    navMenu.Groups.Clear();

                    this.Set_MenuList();

                    // 윈도우 스타일 설정 2012-04-17
                    string strType = Settings_IDAT.Default.WINSTYLE;

                    switch (strType.ToUpper())
                    {
                        case "NORMAL":
                            pnlTopMenu.Visible = false;
                            panelControl1.Visible = true;
                            panelControl_Tile.Visible = false;
                            panelControl_TileBack.Visible = false;
                            break;
                        case "RIBBON":
                            pnlTopMenu.Visible = true;
                            panelControl1.Visible = false;
                            panelControl_Tile.Visible = false;
                            panelControl_TileBack.Visible = false;
                            break;
                        case "TILE":
                            panelControl_Tile.Visible = true;
                            panelControl_TileBack.Visible = true;
                            pnlTopMenu.Visible = false;
                            panelControl1.Visible = false;
                            hideContainerLeft.Visible = false;

                            panelControl_TileBack.Top = 0;
                            pnlMain.ItemSize = AppConst.TileSize;

                            changer = new ModuleChanger(this, pnlMain, pnlDetail, 0);


                            changer.ShowPanel(true, false);
                            break;

                        default:
                            break;
                    }

                    SplashScreenManager.CloseForm(false);

                    //패널 레이아웃을 불러옵니다.
                    if (Settings_IDAT.Default.Use_Auto_Login)
                    {
                        this.Set_ScreenMode("N");
                    }
                    else
                    {
                        dock.BeginUpdate();

                        if (Settings_IDAT.Default.WINSTYLE == "Tile")
                            pnlMenu.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                        else
                            pnlMenu.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;

                        dock.EndUpdate();
                    }

                    //공지사항
                    if (!bgwNotice.IsBusy) bgwNotice.RunWorkerAsync();

                    //알림표시
                    if (!bgwAlert.IsBusy) bgwAlert.RunWorkerAsync();
                    if (Global.Global_Variable.ALERTFLAG == "Y")
                    {
                        //if (Global.Global_Variable.USER_ID != "SYSOPER") 
                        tmrAlert.Start();
                    }

                    // P/G Update Check
                    //if (Global.Global_Variable.UPDATEFLAG == "Y") tmrUpdate.Start();
                    //if (!bgwUpdate.IsBusy) bgwUpdate.RunWorkerAsync();
                }
                else //DialogResult는 No
                {
                    // 트리형식의 메뉴바를 초기화 한다.
                    navMenu.Groups.Clear();
                }
            }
            else//로그아웃 수행
            {
                //idatNoticeInfo1.NoticeText = " ";
                //idatNoticeInfo1.LatestNewsText = " ";

                bgwNotice.CancelAsync();

                tmrAlert.Stop();
                tmrUpdate.Stop();
                // Log Out을 수행한다.
                // 사용자 권한에 관련된 모든것을 초기화 시킴.
                this.Clear_Menu();
                //imageListBoxControl_Fav.Items.Clear();

                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form childForm in MdiChildren)
                    {
                        childForm.Close();
                    }
                }

                btnLogin.Caption = "Log in";
                btnRegister.Caption = "Register";
                lblLogin.Caption = "Please Log in.";
                dock.BeginUpdate();
                pnlMenu.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                dock.EndUpdate();

                // 사용자 등록은 관리자가 이전 MES 정보를 참고하여 관리자가 직접 한다.
                //this.btnRegister.Visibility = BarItemVisibility.Never;


                pnlMain.Groups.Clear();
            }
        }

        

        /// <summary>
        /// 회원가입 & 수정 버튼 클릭 이벤트
        /// </summary>
        private void btnRegister_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (btnLogin.Caption.ToUpper() == "LOG IN")
            {
                using (HAENGSUNG_HNSMES_UI.Forms.COM.COMREGISTER_NEW _frm = new Forms.COM.COMREGISTER_NEW())
                {
                    _frm.FormClass = "W";
                    _frm.ShowDialog(this);
                }
            }
            else
            {
                using (HAENGSUNG_HNSMES_UI.Forms.COM.COMREGISTER_NEW _frm = new Forms.COM.COMREGISTER_NEW(Global.Global_Variable.USER_ID))
                {
                    if (_frm.DialogResult == System.Windows.Forms.DialogResult.No)
                        return;
                    _frm.FormClass = "W";
                    _frm.ShowDialog(this);
                }
            }
        }

        #endregion

        #region 셋팅 버튼 이벤트
        
        /// 스킨 클릭시 기본 스킨 변경
        private void rgbSkins_GalleryItemClick(object sender, GalleryItemClickEventArgs e)
        {
            Settings_IDAT.Default.SKIN = e.Item.Caption;
            Settings_IDAT.Default.Save();
        }
        private void galleryControlGallery1_ItemClick(object sender, GalleryItemClickEventArgs e)
        {
            Settings_IDAT.Default.SKIN = e.Item.Caption;
            Settings_IDAT.Default.Save();
        }

        /// 즐겨찾기 셋팅
        private void btnFavorites_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (HAENGSUNG_HNSMES_UI.Forms.COM.COMFAVORITES _frmFavorites = new HAENGSUNG_HNSMES_UI.Forms.COM.COMFAVORITES())
            {
                _frmFavorites.FormClass = "W";
                _frmFavorites.ShowDialog(this);
            }
        }
        private void btnFavorites1_Click(object sender, EventArgs e)
        {
            btnFavorites_ItemClick(null, null);
        }

        /// 스캐너 셋팅
        private void btnSetScanner_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (HAENGSUNG_HNSMES_UI.Forms.COM.COMSCANNERSETTING _frmScanner = new HAENGSUNG_HNSMES_UI.Forms.COM.COMSCANNERSETTING())
            {
                _frmScanner.FormClass = "W";
                _frmScanner.ShowDialog(this);

                if (Scanner1.IsOpen) Scanner1.Close();
                if (Scanner2.IsOpen) Scanner2.Close();
                if (Scanner3.IsOpen) Scanner3.Close();
                if (Scanner4.IsOpen) Scanner4.Close();

                ScannerProcess _clsScan = new ScannerProcess();

                _clsScan.Open_Serial(Scanner1, "SCANNER1");
                _clsScan.Open_Serial(Scanner2, "SCANNER2");
                _clsScan.Open_Serial(Scanner3, "SCANNER3");
                _clsScan.Open_Serial(Scanner4, "SCANNER4");
            }
        }
        private void btnSetScanner1_Click(object sender, EventArgs e)
        {
            btnSetScanner_ItemClick(null, null);
        }

        /// 바코드 프린터 셋팅
        private void btnSetBarPrinter_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (HAENGSUNG_HNSMES_UI.Forms.COM.COMBARPRINTSETTING _frmBarPrint = new Forms.COM.COMBARPRINTSETTING())
            {
                _frmBarPrint.FormClass = "W";
                _frmBarPrint.ShowDialog(this);
            }
        }
        private void btnSetBarPrinter1_Click(object sender, EventArgs e)
        {
            btnSetBarPrinter_ItemClick(null, null);
        }

        /// 프로그램 셋팅
        private void btnSetting_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool _blnFavorites = Settings_IDAT.Default.Use_Favorites;
            using (HAENGSUNG_HNSMES_UI.Forms.COM.COMSYSTEMSETTING _frmSet = new Forms.COM.COMSYSTEMSETTING())
            {
                _frmSet.FormClass = "W";
                _frmSet.ShowDialog(this);
            }

            if (btnLogin.Caption.ToUpper() != "LOG IN" && Settings_IDAT.Default.Use_Favorites != _blnFavorites)
            {
                //using (DevExpress.Utils.WaitDialogForm _msg = new WaitDialogForm("Update Setting", "Update"))
                using (DevExpress.Utils.WaitDialogForm _msg = new WaitDialogForm("업데이트 설정 중.", "업데이트"))
                {
                    if (Settings_IDAT.Default.Use_Favorites != _blnFavorites) this.Set_MenuList();
                }
            }
        }
        private void btnSetting1_Click(object sender, EventArgs e)
        {
            btnSetting_ItemClick(null, null);
        }

        #endregion

        #region mdi폼 활성화 이벤트

        /// <summary>
        /// midchild 가 활성화될때 버튼 설정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_MdiChildActivate(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveMdiChild == null)
                {
                    lblTitle.EditValue = "";
                    picTitle.EditValue = null;

                    labelControl_Title.Text = "";
                    pictureEdit_MainIcon.Image = null;
                    panelControl_Notice.Visible = true;
                }
                else
                {
                    panelControl_Notice.Visible = false;
                    rcPageTop.SelectedPage = rpControl;
                    lblTitle.EditValue = this.ActiveMdiChild.Text;
                    picTitle.EditValue = ((HAENGSUNG_HNSMES_UI.Forms.BASE.Form)this.ActiveMdiChild).FormIcon;

                    labelControl_Title.Text = this.ActiveMdiChild.Text;
                    pictureEdit_MainIcon.Image = ((HAENGSUNG_HNSMES_UI.Forms.BASE.Form)this.ActiveMdiChild).FormIcon;

                    IDAT.Devexpress.FORM.IBaseForm baseForm = (IDAT.Devexpress.FORM.IBaseForm)this.ActiveMdiChild;

                    if (((HAENGSUNG_HNSMES_UI.Forms.BASE.Form)this.ActiveMdiChild).FormClass != "W")
                    {
                        baseForm.ShowNewbutton = false;
                        baseForm.ShowEditButton = false;
                        baseForm.ShowSaveButton = false;
                        baseForm.ShowDeleteButton = false;
                    }

                    if (baseForm.ShowCloseButton == true)
                    {
                        btnClose.Enabled = true;
                        btnClose1.Enabled = true;
                    }
                    else
                    {
                        btnClose.Enabled = false;
                        btnClose1.Enabled = false;

                    }


                    if (baseForm.ShowPrintButton == true)
                    {
                        btnPrint.Enabled = true;
                        btnPrint1.Enabled = true;
                    }
                    else
                    {
                        btnPrint.Enabled = false;
                        btnPrint1.Enabled = false;
                    }


                    if (baseForm.ShowDeleteButton == true)
                    {
                        btnDelete.Enabled = true;
                        btnDelete1.Enabled = true;
                    }
                    else
                    {
                        btnDelete.Enabled = false;
                        btnDelete1.Enabled = false;
                    }

                    if (baseForm.ShowSaveButton == true)
                    {
                        btnSave.Enabled = true;
                        btnSave1.Enabled = true;
                    }
                    else
                    {
                        btnSave.Enabled = false;
                        btnSave1.Enabled = false;
                    }

                    if (baseForm.ShowEditButton == true)
                    {
                        btnEdit.Enabled = true;
                        btnEdit1.Enabled = true;
                    }
                    else
                    {
                        btnEdit.Enabled = false;
                        btnEdit1.Enabled = false;
                    }

                    if (baseForm.ShowNewbutton == true)
                    {
                        btnNew.Enabled = true;
                        btnNew1.Enabled = true;
                    }
                    else
                    {
                        btnNew.Enabled = false;
                        btnNew1.Enabled = false;
                    }

                    if (baseForm.ShowRefreshButton == true)
                    {
                        btnRefresh.Enabled = true;
                        btnRefresh1.Enabled = true;
                    }
                    else
                    {
                        btnRefresh.Enabled = false;
                        btnRefresh1.Enabled = false;
                    }

                    if (baseForm.ShowStopButton == true)
                    {
                        btnStop.Enabled = true;
                        btnStop1.Enabled = true;
                    }
                    else
                    {
                        btnStop.Enabled = false;
                        btnStop1.Enabled = false;
                    }

                    if (baseForm.ShowSearchButton == true)
                    {
                        btnSearch.Enabled = true;
                        btnSearch1.Enabled = true;
                    }
                    else
                    {
                        btnSearch.Enabled = false;
                        btnSearch1.Enabled = false;
                    }

                    if (baseForm.ShowInitButton == true)
                    {
                        btnInit.Enabled = true;
                        btnInit1.Enabled = true;
                    }
                    else
                    {
                        btnInit.Enabled = false;
                        btnInit1.Enabled = false;
                    }

                    if (((HAENGSUNG_HNSMES_UI.Forms.BASE.Form)this.ActiveMdiChild).CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit)
                    {
                        btnNew.Enabled = false;
                        btnNew1.Enabled = false;

                        btnEdit.Enabled = false;
                        btnEdit1.Enabled = false;

                        btnDelete.Enabled = false;
                        btnDelete1.Enabled = false;
                    }
                    if (((HAENGSUNG_HNSMES_UI.Forms.BASE.Form)this.ActiveMdiChild).CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
                    {
                        btnNew.Enabled = false;
                        btnNew1.Enabled = false;

                        btnEdit.Enabled = false;
                        btnEdit1.Enabled = false;

                        btnDelete.Enabled = false;
                        btnDelete1.Enabled = false;
                    }
                }
            }
            catch
            {
            }
        }

        #endregion

        #region 화면 Simple 화

        /// <summary>
        /// F11키 눌렸을때..
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                this.Set_ScreenMode(btnTouch.Tag + "");
            }

            if (e.KeyCode == Keys.F1)
                this.btnInit.PerformClick();

            if (e.KeyCode == Keys.F2)
                this.btnSearch.PerformClick();

            if (e.KeyCode == Keys.F3)
                this.btnStop.PerformClick();

            if (e.KeyCode == Keys.F4)
                this.btnRefresh.PerformClick();

            if (e.KeyCode == Keys.F5)
                this.btnNew.PerformClick();

            if (e.KeyCode == Keys.F6)
                this.btnEdit.PerformClick();

            if (e.KeyCode == Keys.F7)
                this.btnSave.PerformClick();

            if (e.KeyCode == Keys.F8)
                this.btnDelete.PerformClick();

            if (e.KeyCode == Keys.F9)
                this.btnPrint.PerformClick();

        }

        /// <summary>
        /// 페이지 공통 버튼사이즈 조절될때 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rcPageTop_SizeChanged(object sender, EventArgs e)
        {
            if (m_blnLoad) return;
            if (!rpgTitle.Visible) rpgTitle.Visible = true;
            pnlTopMenu.Height = rcPageTop.Height + 4;
            lblTitle.Width = rcPageTop.Width - 550 - 150;
        }

        #endregion

        #region 좌측 메뉴 이벤트

        private void navMenu_GroupExpanded(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            foreach (DevExpress.XtraNavBar.NavBarGroup group in navMenu.Groups)
            {
                if (e.Group.Caption != group.Caption && group.Caption != "Favorites")
                {
                    group.Expanded = false;
                }
            }
        }

        private void navMenu_Click(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraNavBar.NavBarControl con = sender as DevExpress.XtraNavBar.NavBarControl;

                System.Windows.Forms.MouseEventArgs e1 = e as System.Windows.Forms.MouseEventArgs;
                Point p = new Point(e1.X, e1.Y);
                DevExpress.XtraNavBar.NavBarHitInfo hi = con.CalcHitInfo(p);

                //Group Caption을 Click 했을때 Expanded or Collapsed 되게....
                if (hi.InGroupCaption == true && hi.InGroupButton == false)
                {
                    con.PressedGroup.Expanded = !con.PressedGroup.Expanded;
                }
            }
            catch
            {
                /// 예상치 못한 오류는 그냥 무시하고 지나가도록 한다.
                /// 내부적으로 알수 없는 오류가 가끔씩 발생함. 프로그램 프로세스상 큰 문제가 없으므로 
                /// 무시하도록 처리 하였음.
            }
        }

        #endregion

        #region 타이머 이벤트

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Caption = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            m_intMessageCount--;
            if (m_intMessageCount == 0)
            {
                lblMessage.Caption = "";
            }
        }

        #endregion

        #region 사용자 메뉴 이벤트
        
        void m_menuManager_Menu_SelectEvent(object sender, MouseEventArgs e)
        {
            if (e.Clicks != 1)
            {
                return;
            }

            if (e.Button.ToString() != "Left")
            {
                return;
            }

            DevExpress.XtraTreeList.TreeList ObjTL = sender as DevExpress.XtraTreeList.TreeList;
            DevExpress.XtraTreeList.TreeListHitInfo hi = ObjTL.CalcHitInfo(new Point(e.X, e.Y));
            DevExpress.XtraTreeList.Nodes.TreeListNode node = hi.Node;

            if (node != null)
            {
                this.UseWaitCursor = true;

                if (node.GetDisplayText("FORM").ObjectNullString() != "")
                {
                    string formname = node.GetDisplayText("MENUNAME").Trim();
                    string formparam = node.GetDisplayText("FORMPARAM").Trim();
                    string formclass = node.GetValue("FORMROLE").ToString();
                    int _intImageIndex = 0;

                    if (node.GetDisplayText("IMAGEINDEX") + "" != "") _intImageIndex = Convert.ToInt16(node.GetDisplayText("IMAGEINDEX") + "");

                    

                    /*모니터링 Call Sample Source*/
                    if (node.GetDisplayText("FORM") == "MNTA201")
                    {
                        Forms.MNT.MNTA201 mnt = new Forms.MNT.MNTA201() { Tag = formparam };
                        mnt.Show(this);
                    }
                    else if (node.GetDisplayText("FORM") == "MNTA202")
                    {
                        Forms.MNT.MNTA202 mnt = new Forms.MNT.MNTA202() { Tag = formparam };
                        mnt.Show(this);
                    }
                    else if (node.GetDisplayText("FORM") == "MNTB205")
                    {
                        Forms.MNT.MNTB205 mnt = new Forms.MNT.MNTB205() { Tag = formparam };
                        mnt.Show(this);
                    }
                    else if (node.GetDisplayText("FORM") == "PRDA211")
                    {
                        Forms.PRD.PRDA211 prd = new Forms.PRD.PRDA211() { Tag = formparam };
                        prd.Show(this);
                    }
                    else if (node.GetDisplayText("FORM") == "PRDA215")
                    {
                        Forms.PRD.PRDA215 prd = new Forms.PRD.PRDA215() { Tag = formparam };
                        prd.Show(this);
                    }
                    else if (node.GetDisplayText("FORM") == "PRDA216")
                    {
                        Forms.PRD.PRDA216 prd = new Forms.PRD.PRDA216() { Tag = formparam };
                        prd.Show(this);
                    }
                    else if (node.GetDisplayText("FORM") == "PRDA221")
                    {
                        Forms.PRD.PRDA221 prd = new Forms.PRD.PRDA221() { Tag = formparam };
                        prd.Show(this);
                    }
                    else if (node.GetDisplayText("FORM") == "PRDA221N")
                    {
                        Forms.PRD.PRDA221N prd = new Forms.PRD.PRDA221N() { Tag = formparam };
                        prd.Show(this);
                    }

                    else if (node.GetDisplayText("FORM") == "MNTA204")
                    {
                        Forms.MNT.MNTA204 mnt = new Forms.MNT.MNTA204() { Tag = formparam };
                        mnt.Show(this);
                    }
                    else
                    {
                        Load_Form(node.GetDisplayText("FORM").Trim(), formname, _intImageIndex, formparam, formclass);
                    }
                }

                this.UseWaitCursor = false;

                //hideContainerLeft.hi
                pnlMenu.HideSliding();
            }
        }

        void m_menuManager_FAVORITES_SelectEvent(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView _gv = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            if (e.RowHandle < 0) return;

            
            //DocFavorites.TryGetValue(imageFavCon.SelectedIndex, out formCode);

            DataRow _dr = _gv.GetDataRow(e.RowHandle);
            string formCode = _dr["FORM"] + "";
            string formName = _dr["MENUNAME"] + "";
            string formParam = _dr["FORMPARAM"] + "";
            string formclass = _dr["FORMROLE"] + "";

            this.Load_Form(formCode, formName, Convert.ToInt16(_dr["IMGIDX"]), formParam, formclass);

        }

        #endregion

        #region 타일 버튼 메뉴 이벤트

        void m_m_FAVORITES_SelectEvent(object sender, TileItemEventArgs e)
        {
            if (sender is TileItem item)
                ShowModule(item, item.CurrentFrame?.Tag, false);
        }

        void m_m_Menu_SelectEvent(object sender, TileItemEventArgs e)
        {
            if (sender is TileItem item)
                ShowModule(item, item.CurrentFrame?.Tag, false);
        }

        private void pictureEdit1_Properties_Click(object sender, EventArgs e)
        {


            if (pnlDetailContainer.Controls.Count > 0)
            {
                changer.ShowPanel(true, true);
                ((Forms.BASE.Form)pnlDetailContainer.Controls[0]).HideModule();
            }
        }

        private void pictureEdit_Setting_Click(object sender, EventArgs e)
        {
            btnSetting_ItemClick(null, null);
        }

        #endregion


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bgwAlert.IsBusy) bgwAlert.CancelAsync();
            if (bgwNotice.IsBusy) bgwNotice.CancelAsync();

            tmrUpdate.Stop();
            tmrAlert.Stop();
            
            if (Scanner1.IsOpen) Scanner1.Close();
            if (Scanner2.IsOpen) Scanner2.Close();
            if (Scanner3.IsOpen) Scanner3.Close();
            if (Scanner4.IsOpen) Scanner4.Close();

            if (btnLogin.Caption.ToUpper() == "LOG OUT")  //로그인 수행
            {
                m_clsLog.SaveLogInOut(LogInOut.Logout);
            }
        }

        #endregion

        #region 함수

        private void Clear_Menu()
        {
            navMenu.Groups.Clear();
        }

        private void Set_Init()
        {

        }

        /// <summary>
        /// 유저의 메뉴정보를 가져옵니다.
        /// </summary>
        public void Set_MenuList()
        {
            if (Settings_IDAT.Default.WINSTYLE == "Tile")
            {
                iDATMainMenuTile m_m = new iDATMainMenuTile(_DB);
                m_m.Add_MenuGroup(pnlMain);

                m_m.Menu_SelectEvent += new iDATMainMenuTile.Menu_MouseDown(m_m_Menu_SelectEvent);
                m_m.FAVORITES_SelectEvent += new iDATMainMenuTile.FAVMenu_MouseDown(m_m_FAVORITES_SelectEvent);
            }

            iDATMainMenu m_menuManager = new iDATMainMenu(_DB);
            // 사용자 메뉴를 설정합니다.
            m_menuManager.Add_MenuGroup(navMenu);


            //이벤트 설정
            m_menuManager.Menu_SelectEvent += new iDATMainMenu.Menu_MouseDown(m_menuManager_Menu_SelectEvent);
            m_menuManager.FAVORITES_SelectEvent += new iDATMainMenu.FAVMenu_MouseDown(m_menuManager_FAVORITES_SelectEvent);
        }


      
        /// <summary>
        /// 로그인 정보를 문자열로 리턴합니다.
        /// </summary>
        /// <returns>로그인정보</returns>
        private string GetLoginInfoString()
        {
            return string.Format("Welcome {0}({1}) {2} [{3}] ", Global.Global_Variable.USERNAMELOCAL, Global.Global_Variable.USER_ID, Global.Global_Variable.USERCLASSNAME, Global.Global_Variable.IPADDRESS);
        }

        /// <summary>
        /// 스킨 초기화
        /// </summary>
        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbSkins, true);
            SkinHelper.InitSkinGallery(galleryControl_skin, true);
        }
        
        /// <summary>
        /// 화면 호출
        /// </summary>
        /// <param name="As_FrmName"></param>
        /// <param name="As_FrmText"></param>
        /// <param name="imageindex"></param>
        /// <param name="formparam"></param>
        /// <param name="formclass"></param>
        public void Load_Form(string As_FrmName, string As_FrmText, int imageindex, string formparam, string formclass)
        {
            try
            {
                foreach (Form Ao_Form in this.MdiChildren)
                {
                    if (Ao_Form.Name == As_FrmName && Ao_Form.Tag.ObjectNullString() == formparam)
                    {
                        Ao_Form.Focus();
                        return;
                    }
                }

                // Child Form Load
                //Application.DoEvents();
                System.Reflection.Assembly Ao_Ass = System.Reflection.Assembly.GetExecutingAssembly();

                string strNameSpace = "";

                strNameSpace = string.Format("Forms.{0}.", As_FrmName.Substring(0, 3));

                _DB.GetWsConnectStatus();

                ProgramMessage = "Open " + As_FrmText;

                //waitDlg = new WaitDialogForm(As_FrmText + " Loading...", "Loading");
                SplashScreenManager.ShowForm(this, typeof(COMWAITFORM), true, true, false);
                SplashScreenManager.Default.SendCommand(COMWAITFORM.WaitFormCommand.SetCaption, m_clsLan.GetMessageString(As_FrmText) + " " + m_clsLan.GetMessageString("LOADING"));
                SplashScreenManager.Default.SendCommand(COMWAITFORM.WaitFormCommand.SetDescription, m_clsLan.GetMessageString("LOADING"));

                //waitDlg = new WaitDialogForm(As_FrmText + " 로딩중...", "화면 불러오는 중");
                //waitDlg.TopMost = false;
                //waitDlg.BringToFront();

                HAENGSUNG_HNSMES_UI.Forms.BASE.Form New_Form = Ao_Ass.CreateInstance(Ao_Ass.EntryPoint.DeclaringType.Namespace + "." + strNameSpace + As_FrmName, true) as HAENGSUNG_HNSMES_UI.Forms.BASE.Form;

                New_Form.MdiParent = this;
                New_Form.Location = new System.Drawing.Point(0, 0);
                New_Form.StartPosition = FormStartPosition.Manual;
                New_Form.WindowState = FormWindowState.Normal;
                //New_Form.WindowState = FormWindowState.Maximized;
                New_Form.Text = string.Format("{0} [{1}]", As_FrmText.Replace("&", "&&"), As_FrmName);
                New_Form.FormClass = formclass;

                /// 타이틀 명을 지정합니다.
                New_Form.FormIcon = imagesPage32.Images[imageindex];
                New_Form.Name = As_FrmName;
                New_Form.Tag = formparam;

                New_Form._SerialPort1 = Scanner1;
                New_Form._SerialPort2 = Scanner2;
                New_Form._SerialPort3 = Scanner3;
                New_Form._SerialPort4 = Scanner4;

                New_Form.CurrentDataTYPE = IDAT.Devexpress.FORM.UPDATEITEMTYPE.None;

                New_Form.Show();
                New_Form.BringToFront();

                SplashScreenManager.CloseForm(false);
            }
            catch (System.NullReferenceException exNull)
            {
                Class.iDATMessageBox.WARNINGMessage("Please note that Form names " + "are case sensitive. Form not found" + exNull.Message.ToString(), "Invalid Form name", 5);

            }
            catch (Exception ex)
            {
                Class.iDATMessageBox.WARNINGMessage(ex.Message.ToString(), "Form Load Error", 5);
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        /// <summary>
        /// 스크린 모드 변경
        /// </summary>
        /// <param name="p_blnTouch">터치패드인지여부</param>
        private void Set_ScreenMode(string p_strTouch)
        {
            if (p_strTouch != "Y")
            {
                m_frmsts = this.WindowState;
                this.WindowState = FormWindowState.Maximized;
                rcPageTop.Minimized = true;
                //rcMainTop.Hide();
                btnTouch.Tag = "Y";
                //pnlMenu.
                pnlMenu.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            }
            else
            {
                this.WindowState = m_frmsts;
                rcPageTop.Minimized = false;
                btnTouch.Tag = "N";
                pnlMenu.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
            }
        }

        #endregion

        private void Scanner1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
               
                System.Threading.Thread.Sleep(100);

                while (true)
                {
                    m_strData += Scanner1.ReadExisting();
                    if (m_strData.IndexOf("\r\n") >= 0) break;
                    else if (m_strData.IndexOf("\r") >= 0) break;
                    else if (m_strData.IndexOf("01A") >= 0 && m_strSubData.IndexOf("\r") >= 0) break;
                    else if (m_strData.IndexOf((char)2) >= 0 && m_strSubData.IndexOf((char)3) >= 0) break;
                }
                
                if (m_strData.IndexOf("\r\n") >= 0)
                {
                    if (m_strData.Substring(m_strData.Length - 2) == "\r\n")
                    {
                        this.Invoke(new EventHandler(ScanEvent1), sender);

                        //((HAENGSUNG_HNSMES_UI.Forms.BASE.Form)this.ActiveMdiChild)._SerialPort1 = sender as SerialPort;
                    }
                }
                else if (m_strData.IndexOf("01A") >= 0 && m_strData.IndexOf("\r") >= 0)
                {
                    // Tension 장비 
                    // 시작 문자열 "01A"
                    // 종료 문자열 "\r"
                    if (m_strData.Substring(m_strData.Length - 1) == "\r")
                    {
                        this.Invoke(new EventHandler(ScanEvent1), sender);

                        //((HAENGSUNG_HNSMES_UI.Forms.BASE.Form)this.ActiveMdiChild)._SerialPort1 = sender as SerialPort;
                    }
                }
                else if (m_strData.IndexOf((char)2) >= 0 && m_strData.IndexOf((char)3) >= 0)
                {
                    this.Invoke(new EventHandler(ScanEvent1), sender);

                    //((HAENGSUNG_HNSMES_UI.Forms.BASE.Form)this.ActiveMdiChild)._SerialPort1 = sender as SerialPort;
                }
                else if (m_strData.IndexOf("OK") > 0)
                {
                    this.Invoke(new EventHandler(ScanEvent1), sender);

                    //((HAENGSUNG_HNSMES_UI.Forms.BASE.Form)this.ActiveMdiChild)._SerialPort1 = sender as SerialPort;
                }
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
                m_strData = "";
            }
        }

        private void Scanner2_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(100);

                while (true)
                {
                    m_strSubData += Scanner2.ReadExisting();
                    if (m_strSubData.IndexOf("\r\n") >= 0) break;
                    else if (m_strSubData.IndexOf("\r") >= 0) break;
                    else if (m_strSubData.IndexOf("01A") >= 0 && m_strSubData.IndexOf("\r") >= 0) break;
                    else if (m_strSubData.IndexOf((char)2) >= 0 && m_strSubData.IndexOf((char)3) >= 0) break;
                }
                //if (m_strData == "") m_strData = Scanner2.ReadTo(Convert.ToString((char)3));

                if (m_strSubData.IndexOf("\r\n") >= 0 || m_strSubData.IndexOf("\r") >= 0)
                {
                    if (m_strSubData.Substring(m_strSubData.Length - 2) == "\r\n" || m_strSubData.Substring(m_strSubData.Length - 1) == "\r")
                    {
                        this.Invoke(new EventHandler(ScanEvent2), sender);

                        //((HAENGSUNG_HNSMES_UI.Forms.BASE.Form)this.ActiveMdiChild)._SerialPort2 = sender as SerialPort;
                    }
                }
                else if (m_strSubData.IndexOf("01A") >= 0 && m_strSubData.IndexOf("\r") >= 0) 
                {
                    // Tension 장비 
                    // 시작 문자열 "01A"
                    // 종료 문자열 "\r"
                    if (m_strSubData.Substring(m_strSubData.Length - 1) == "\r")
                    {
                        this.Invoke(new EventHandler(ScanEvent2), sender);

                        //((HAENGSUNG_HNSMES_UI.Forms.BASE.Form)this.ActiveMdiChild)._SerialPort2 = sender as SerialPort;
                    }
                }
                else if (m_strSubData.IndexOf((char)2) >= 0 && m_strSubData.IndexOf((char)3) >= 0)
                {
                    this.Invoke(new EventHandler(ScanEvent2), sender);

                    //((HAENGSUNG_HNSMES_UI.Forms.BASE.Form)this.ActiveMdiChild)._SerialPort2 = sender as SerialPort;
                }
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
                m_strSubData = "";
            }
        }

        private void Scanner3_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(100);

                m_strThirdData += Scanner3.ReadExisting();

                if (m_strThirdData.IndexOf("\r\n") >= 0 || m_strThirdData.IndexOf("\r") >= 0)
                {
                    if (m_strThirdData.Substring(m_strThirdData.Length - 2) == "\r\n" || m_strThirdData.Substring(m_strThirdData.Length - 1) == "\r")
                    {
                        this.Invoke(new EventHandler(ScanEvent3), sender);

                    }
                }
                else if (m_strThirdData.IndexOf("01A") >= 0 && m_strThirdData.IndexOf("\r") >= 0)
                {
                    // Tension 장비 
                    // 시작 문자열 "01A"
                    // 종료 문자열 "\r"
                    if (m_strThirdData.Substring(m_strThirdData.Length - 1) == "\r")
                    {
                        this.Invoke(new EventHandler(ScanEvent3), sender);

                        //((HAENGSUNG_HNSMES_UI.Forms.BASE.Form)this.ActiveMdiChild)._SerialPort2 = sender as SerialPort;
                    }
                }
                else if (m_strThirdData.IndexOf((char)2) >= 0 && m_strThirdData.IndexOf((char)3) >= 0)
                {
                    this.Invoke(new EventHandler(ScanEvent3), sender);

                    //((HAENGSUNG_HNSMES_UI.Forms.BASE.Form)this.ActiveMdiChild)._SerialPort2 = sender as SerialPort;
                }
                else if (m_strThirdData.LastIndexOf("PASS") > 0 || m_strThirdData.LastIndexOf("FAIL") > 0 )
                {
                    this.Invoke(new EventHandler(ScanEvent3), sender);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
                m_strThirdData = "";
            }

        }
        private void Scanner4_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(100);

                m_strfourdData = Scanner4.ReadExisting();

                if (m_strfourdData.IndexOf("\r\n") >= 0 || m_strfourdData.IndexOf("\r") >= 0)
                {
                    this.Invoke(new EventHandler(ScanEvent4), sender);
                }
                else if (m_strfourdData.IndexOf((char)2) >= 0 && m_strfourdData.IndexOf((char)3) >= 0)
                {
                    this.Invoke(new EventHandler(ScanEvent4), sender);
                }
               
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
                m_strfourdData = "";
            }

        }
        private void ScanEvent1(Object sender, EventArgs e)
        {
            try
            {
                string strRet = GetBarcodeType(m_strData.Replace("\r\n", "").Replace("\r", "").Replace(Convert.ToString((char)2), "").Replace(Convert.ToString((char)3), ""));

                if (strRet == null)
                {
                    m_strData = "";
                    return;
                }

                if (this.OwnedForms.Length == 0)
                {
                    ((HAENGSUNG_HNSMES_UI.Class.itfScanner)this.ActiveMdiChild).Data_Scan(strRet, m_strData.Replace("\r\n", "").Replace("\r", "").Replace(Convert.ToString((char)2), "").Replace(Convert.ToString((char)3), ""));
                    ((HAENGSUNG_HNSMES_UI.Forms.BASE.Form)this.ActiveMdiChild)._SerialPort1 = sender as SerialPort;
                }
                else
                {
                    ((HAENGSUNG_HNSMES_UI.Class.itfScanner)this.OwnedForms[0]).Data_Scan(strRet, m_strData.Replace("\r\n", "").Replace("\r", "").Replace(Convert.ToString((char)2), "").Replace(Convert.ToString((char)3), ""));
                    ((HAENGSUNG_HNSMES_UI.Forms.BASE.Form)this.OwnedForms[0])._SerialPort1 = sender as SerialPort;
                }
                m_strData = "";
            }
            catch (Exception)
            {
                //Class.iDATMessageBox.WARNINGMessage(ex.Message, "Scan2 Error", 5);
                m_strData = "";
            }
            
        }

        private void ScanEvent2(Object sender, EventArgs e)
        {
            try
            {
               
                string strRet = GetBarcodeType(m_strSubData.Replace("\r\n", "").Replace("\r", "").Replace(Convert.ToString((char)2), "").Replace(Convert.ToString((char)3), ""));

                if (strRet == null)
                {
                    m_strSubData = "";
                    return;
                }

                if (this.OwnedForms.Length == 0)
                {
                    ((HAENGSUNG_HNSMES_UI.Class.itfScanner)this.ActiveMdiChild).Data_Scan(strRet, m_strSubData.Replace("\r\n", "").Replace("\r", "").Replace(Convert.ToString((char)2), "").Replace(Convert.ToString((char)3), ""));
                    ((HAENGSUNG_HNSMES_UI.Forms.BASE.Form)this.ActiveMdiChild)._SerialPort2 = sender as SerialPort;
                }
                else
                {
                    ((HAENGSUNG_HNSMES_UI.Class.itfScanner)this.OwnedForms[0]).Data_Scan(strRet, m_strSubData.Replace("\r\n", "").Replace("\r", "").Replace(Convert.ToString((char)2), "").Replace(Convert.ToString((char)3), ""));
                    ((HAENGSUNG_HNSMES_UI.Forms.BASE.Form)this.OwnedForms[0])._SerialPort2 = sender as SerialPort;
                }
                m_strSubData = "";
            }
            catch (Exception)
            {
                //Class.iDATMessageBox.WARNINGMessage(ex.Message, "Scan2 Error", 5);
                m_strSubData = "";
            }
        }

        private void ScanEvent3(Object sender, EventArgs e)
        {
            try
            {
                /*통전검사기 전용*/
                string strRet = "";

                if (m_strThirdData.LastIndexOf("PASS") > 0 )
                {
                    strRet = "OK";
                    m_strThirdData = "PASS";
                }
                else if (m_strThirdData.LastIndexOf("FAIL") > 0)
                {
                    strRet = "NG";
                    m_strThirdData = "FAIL";
                }
                else
                {
                    strRet = GetBarcodeType(m_strThirdData.Replace("\r\n", "").Replace("\r", "").Replace(Convert.ToString((char)2), "").Replace(Convert.ToString((char)3), ""));
                }

                if (strRet == null)
                {
                    m_strThirdData = "";
                    return;
                }

                if (this.OwnedForms.Length == 0)
                {
                    ((HAENGSUNG_HNSMES_UI.Class.itfScanner)this.ActiveMdiChild).Data_Scan(strRet, m_strThirdData.Replace("\r\n", "").Replace("\r", "").Replace(Convert.ToString((char)2), "").Replace(Convert.ToString((char)3), ""));
                    ((HAENGSUNG_HNSMES_UI.Forms.BASE.Form)this.ActiveMdiChild)._SerialPort3 = sender as SerialPort;
                }
                else
                {
                    ((HAENGSUNG_HNSMES_UI.Class.itfScanner)this.OwnedForms[0]).Data_Scan(strRet, m_strThirdData.Replace("\r\n", "").Replace("\r", "").Replace(Convert.ToString((char)2), "").Replace(Convert.ToString((char)3), ""));
                    ((HAENGSUNG_HNSMES_UI.Forms.BASE.Form)this.OwnedForms[0])._SerialPort3 = sender as SerialPort;
                }
                m_strThirdData = "";
            }
            catch (Exception)
            {
                //Class.iDATMessageBox.WARNINGMessage(ex.Message, "Scan2 Error", 5);
                m_strThirdData = "";
            }
        }

        private void ScanEvent4(Object sender, EventArgs e)
        {
            try
            { if (this.OwnedForms.Length == 0)
                {
                    ((HAENGSUNG_HNSMES_UI.Class.itfScanner)this.ActiveMdiChild).Data_Scan("NONE", m_strfourdData.Replace("\r\n", "").Replace("\r", "").Replace(Convert.ToString((char)2), "").Replace(Convert.ToString((char)3), ""));
                    ((HAENGSUNG_HNSMES_UI.Forms.BASE.Form)this.ActiveMdiChild)._SerialPort4 = sender as SerialPort;
                }
                else
                {
                    ((HAENGSUNG_HNSMES_UI.Class.itfScanner)this.OwnedForms[0]).Data_Scan("NONE", m_strfourdData.Replace("\r\n", "").Replace("\r", "").Replace(Convert.ToString((char)2), "").Replace(Convert.ToString((char)3), ""));
                    ((HAENGSUNG_HNSMES_UI.Forms.BASE.Form)this.OwnedForms[0])._SerialPort4 = sender as SerialPort;
                }
                m_strThirdData = "";
            }
            catch (Exception)
            {
                //Class.iDATMessageBox.WARNINGMessage(ex.Message, "Scan2 Error", 5);
                m_strfourdData = "";
            }
        }
        private string GetBarcodeType(string sBarcode)
        {
            // 박영순 변경 2016.2.17 자재만 별도로 다른 프로시져 타기 위해 변경함 아래것 막고
            WSResults result;
            //if (this.OwnedForms.Length > 0 && this.OwnedForms[0].Name == "COMLOGIN")
            //{
            //    return this.OwnedForms[0].Name;
            //}

            // 바코드종류 확인
            result = _DB.Execute_Proc( "PKGPDA_COMM.GET_BARCODETYPE"
                                     , 1
                                     , new string[] {  
                                       "A_CLIENT"
                                     ,"A_COMPANY"
                                     ,"A_PLANT"
                                     ,"A_JOB"
                                     ,"A_BARCODE" }
                                     , new string[] { 
                                       Global.Global_Variable.CLIENT
                                     , Global.Global_Variable.COMPANY
                                     , Global.Global_Variable.PLANT
                                     , ""
                                     , sBarcode }
                                     );

            if (result.ResultInt == 0)
            {
                Program.frmM.ProgramMessage = "Scan : [Type : " + result.ResultString + "]" + sBarcode;
                return result.ResultString;
            }
            else
            {
                iDATMessageBox.ErrorMessage(result.ResultString, this.Text, 5);
                return null;
            }
        }


        // 스킨 관련
        private void tabbedControlGroup1_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            if (e.Page.Text == "PageControl")
                layoutControlItem_SKIN.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            else
                layoutControlItem_SKIN.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

        }

        #region 타일 관련 함수

        readonly string MainCaption = "Realtor World";
        ModuleChanger changer;
        public Forms.BASE.Form module;

        private Forms.BASE.Form InitModule(object tag, object current, bool directSwitching)
        {
            if (tag == null) return null;
            Forms.BASE.Form module = null;
            Cursor.Current = Cursors.WaitCursor;
            bool animation = true;
            try
            {
                if (tag is Type)
                {
                    animation = false;
                    Type type = tag as Type;
                    ConstructorInfo constructorInfoObj = type.GetConstructor(Type.EmptyTypes);
                    if (constructorInfoObj == null) return null;
                    tag = constructorInfoObj.Invoke(null);
                    //((Forms.BASE.Form)tag).InitModule(barManager1, null);
                }
                module = tag as Forms.BASE.Form;
                if (module != null)
                {
                    if (directSwitching && pnlDetailContainer.Controls.Count > 0)
                    {
                        if (pnlDetailContainer.Controls[0] is Forms.BASE.Form currentModule)
                            currentModule.HideModule();
                    }
                    if (animation && directSwitching)
                        changer.SetDraftImage();
                    pnlDetailContainer.Controls.Clear();
                    module.TopLevel = false;
                    pnlDetailContainer.Controls.Add(module);

                    module.SuspendLayout();
                    module.Dock = DockStyle.Fill;
                    module.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    module.MinimizeBox = false;
                    module.CloseBox = false;
                    module.MaximizeBox = false;
                    
                    module.ShowModule(current);
                    module.Show();
                    module.ResumeLayout();

                    if (animation && directSwitching)
                        changer.ShowDraftPanel();
                    else
                        changer.ShowPanel(false, animation);
                    HtmlText = string.Format("<size=+2><color={2}>{0}</color><size=+1> {1}", MainCaption, module.ModuleCaption, AppConst.HtmlInformationColor);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            return module;
        }

        void ShowModule(TileItem item, object current, bool directSwitching)
        {
            module = InitModule(item.Tag, current, directSwitching);
            if (module != null && !object.ReferenceEquals(item.Tag, module))
                item.Tag = module;

            if (module == null) return;
            lblTitle.EditValue = module.Text;
            picTitle.EditValue = ((HAENGSUNG_HNSMES_UI.Forms.BASE.Form)module).FormIcon;

            labelControl_Title.Text = module.Text;
            pictureEdit_MainIcon.Image = ((HAENGSUNG_HNSMES_UI.Forms.BASE.Form)module).FormIcon;

            IDAT.Devexpress.FORM.IBaseForm baseForm = (IDAT.Devexpress.FORM.IBaseForm)module;

            if (item.Name.Split(',')[2].ObjectNullString() != "W")
            {
                baseForm.ShowNewbutton = false;
                baseForm.ShowEditButton = false;
                baseForm.ShowSaveButton = false;
                baseForm.ShowDeleteButton = false;
            }

            if (baseForm.ShowCloseButton == true)
            {
                btnClose.Enabled = true;
                btnClose1.Enabled = true;
            }
            else
            {
                btnClose.Enabled = false;
                btnClose1.Enabled = false;
            }


            if (baseForm.ShowPrintButton == true)
            {
                btnPrint.Enabled = true;
                btnPrint1.Enabled = true;
            }
            else
            {
                btnPrint.Enabled = false;
                btnPrint1.Enabled = false;
            }

            if (baseForm.ShowDeleteButton == true)
            {
                btnDelete.Enabled = true;
                btnDelete1.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
                btnDelete1.Enabled = false;
            }

            if (baseForm.ShowSaveButton == true)
            {
                btnSave.Enabled = true;
                btnSave1.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
                btnSave1.Enabled = false;
            }

            if (baseForm.ShowEditButton == true)
            {
                btnEdit.Enabled = true;
                btnEdit1.Enabled = true;
            }
            else
            {
                btnEdit.Enabled = false;
                btnEdit1.Enabled = false;
            }

            if (baseForm.ShowNewbutton == true)
            {
                btnNew.Enabled = true;
                btnNew1.Enabled = true;
            }
            else
            {
                btnNew.Enabled = false;
                btnNew1.Enabled = false;
            }

            if (baseForm.ShowRefreshButton == true)
            {
                btnRefresh.Enabled = true;
                btnRefresh1.Enabled = true;
            }
            else
            {
                btnRefresh.Enabled = false;
                btnRefresh1.Enabled = false;
            }

            if (baseForm.ShowStopButton == true)
            {
                btnStop.Enabled = true;
                btnStop1.Enabled = true;
            }
            else
            {
                btnStop.Enabled = false;
                btnStop1.Enabled = false;
            }

            if (baseForm.ShowSearchButton == true)
            {
                btnSearch.Enabled = true;
                btnSearch1.Enabled = true;
            }
            else
            {
                btnSearch.Enabled = false;
                btnSearch1.Enabled = false;
            }

            if (baseForm.ShowInitButton == true)
            {
                btnInit.Enabled = true;
                btnInit1.Enabled = true;
            }
            else
            {
                btnInit.Enabled = false;
                btnInit1.Enabled = false;
            }

            if (((HAENGSUNG_HNSMES_UI.Forms.BASE.Form)module).CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit)
            {
                btnNew.Enabled = false;
                btnNew1.Enabled = false;

                btnEdit.Enabled = false;
                btnEdit1.Enabled = false;

                btnDelete.Enabled = false;
                btnDelete1.Enabled = false;
            }
            if (((HAENGSUNG_HNSMES_UI.Forms.BASE.Form)module).CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
            {
                btnNew.Enabled = false;
                btnNew1.Enabled = false;

                btnEdit.Enabled = false;
                btnEdit1.Enabled = false;

                btnDelete.Enabled = false;
                btnDelete1.Enabled = false;
            }


        }

        #endregion

        // 공지사항 정보를 셋팅합니다.
        private void SetNotice()
        {
            this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate()
            {
                idatNoticeInfo1.IsViewIdatUpdateHistory = false;

                WSResults result_notice = _DB.Execute_Proc( "PKGSYS_COMM.GET_NOTICE"
                                                          , 1
                                                          , new string[] { 
                                                            "A_CLIENT"
                                                          , "A_COMPANY"
                                                          , "A_PLANT"
                                                          , "A_SYSTEM"
                                                          , "A_VIEW"  }
                                                          , new string[] { 
                                                            Global.Global_Variable.CLIENT
                                                          , Global.Global_Variable.COMPANY
                                                          , Global.Global_Variable.PLANT
                                                          , Global.Global_Variable.SYSTEMCODE
                                                          , "1" }
                                                          );

                if (result_notice.ResultInt == 0) idatNoticeInfo1.NoticeDatatable = result_notice.ResultDataSet.Tables[0];
                //idatNoticeInfo1.InitSubNoticeControl();
                idatNoticeInfo1.NoticeGridView.OptionsView.EnableAppearanceEvenRow = true;
                idatNoticeInfo1.NoticeGridView.OptionsView.EnableAppearanceOddRow = true;
                idatNoticeInfo1.NoticeGridView.OptionsMenu.EnableColumnMenu = false;
                idatNoticeInfo1.NoticeGridView.OptionsMenu.EnableFooterMenu = false;
                idatNoticeInfo1.NoticeGridView.OptionsMenu.EnableGroupPanelMenu = false;
                idatNoticeInfo1.NoticeGridView.OptionsFilter.AllowFilterEditor = false;
                idatNoticeInfo1.NoticeGridView.OptionsFilter.AllowFilterIncrementalSearch = false;
                idatNoticeInfo1.NoticeGridView.OptionsFilter.AllowMRUFilterList = false;

                idatNoticeInfo1.NoticeGridView.OptionsCustomization.AllowSort = false;
                idatNoticeInfo1.NoticeGridView.OptionsCustomization.AllowFilter = false;
                idatNoticeInfo1.NoticeGridView.OptionsCustomization.AllowGroup = false;

                idatNoticeInfo1.SubNoticeTitleMaxLength = 100;

                foreach (GridColumn col in idatNoticeInfo1.NoticeGridView.Columns)
                    col.Caption = m_clsLan.GetMessageString(col.FieldName);

                idatNoticeInfo1.NoticeGridView.BestFitColumns();
            })));
        }

        private void bgwNotice_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (!bgwNotice.CancellationPending)
            {
                try
                {
                    //SetNotice();
                }
                catch { }
                System.Threading.Thread.Sleep(60000);
            }
        }

        private void ProgramUpdateNotify()
        {
            if (update == null)
            {
                try
                {
                    bool bRet = Program.CheckUpdateProgram(out string _currver, out string _newver);

                    if (bRet)
                    {
                        StringBuilder title = new StringBuilder();
                        StringBuilder content = new StringBuilder();

                        title.AppendLine("HAENGSUNG Digital MES Update Alert");

                        if (Application.CurrentCulture.Name.ToUpper() == "KO-KR")
                        {
                            content.AppendLine("새로운 버전이 있습니다.");
                            content.AppendLine("새로운 버전으로 업데이트 하실려면 본문이나 제목을 클릭하십시요.");
                            content.AppendLine("");
                            content.AppendLine("현재 버전 : " + _currver);
                            content.AppendLine("신규 버전 : " + _newver);
                        }
                        else if (Application.CurrentCulture.Name.ToUpper() == "ZH-CN")
                        {
                            content.AppendLine("有一个新版本.");
                            content.AppendLine("要与新版本更新，请按一下身体或标题.");
                            content.AppendLine("");
                            content.AppendLine("当前版本 : " + _currver);
                            content.AppendLine("新版本 : " + _newver);
                        }
                        else
                        {
                            content.AppendLine("The new version is available.");
                            content.AppendLine("To be updated with the new version please click.");
                            content.AppendLine("");
                            content.AppendLine("Current Version : " + _currver);
                            content.AppendLine("New Version : " + _newver);
                        }

                        NotifyWindow nwUpdate = new NotifyWindow(title.ToString(), content.ToString());
                        //nwUpdate.Click += new EventHandler(nwUpdate_Click);
                        //nw.TitleClicked += new System.EventHandler(titleClick);
                        //nw.FormClosed += new FormClosedEventHandler(update_FormClosed);
                        //nw.TextClicked += new System.EventHandler(textClick);
                        //nw.SetDimensions(200, 200);
                        update = nwUpdate;
                        nwUpdate.Show(this);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.ToString());
                }
            }
        }

        protected void expiry_FormClosed(object sender, FormClosedEventArgs e)
        {
            expiry = null;
            mExpiryMaterial = "";
        }

        private void bgwUpdate_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            ProgramUpdateNotify();
        }

        private void bgwAlert_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //CheckMountingInspection();
            //CheckMountStockShortage();
            //CheckNoMountMaster();
            //CheckMountingCycleInspection();
            //CheckPickupLossRate();
            CheckExpiryMaterial();
            CheckExpiryJIG();
        }

        private void tmrAlert_Tick(object sender, EventArgs e)
        {
            tmrAlert.Stop();

            if (!bgwAlert.IsBusy) bgwAlert.RunWorkerAsync();

            tmrAlert.Start();
        }

        private void bgwAlert_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (Global.Global_Variable.EHRCODE != "SYSOPER")
            {
                if (Global.Global_Variable.ALERTFLAG == "Y")
                {
                    /*알림 메시지가 필요한 경우 프로세스 로직 추가*/
                    ExpiryMaterialShowAlram();
                    ExpiryJIGShowAlram();
                }
            }

        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            tmrUpdate.Stop();

            if (update == null)
            {
                try
                {
                    bool bRet = Program.CheckUpdateProgram(out string _currver, out string _newver);

                    if (bRet)
                    {
                        StringBuilder title = new StringBuilder();
                        StringBuilder content = new StringBuilder();

                        title.AppendLine("HAENGSUNG HNS MES Update Alert");

                        if (Application.CurrentCulture.Name.ToUpper() == "KO-KR")
                        {
                            content.AppendLine("새로운 버전이 있습니다.");
                            content.AppendLine("새로운 버전으로 업데이트 하실려면 본문이나 제목을 클릭하십시요.");
                            content.AppendLine("");
                            content.AppendLine("현재 버전 : " + _currver);
                            content.AppendLine("신규 버전 : " + _newver);
                        }
                        else if (Application.CurrentCulture.Name.ToUpper() == "ZH-CN")
                        {
                            content.AppendLine("有一个新版本.");
                            content.AppendLine("要与新版本更新，请点击标题或身体.");
                            content.AppendLine("");
                            content.AppendLine("当前版本 : " + _currver);
                            content.AppendLine("新版本    : " + _newver);
                        }
                        else
                        {
                            content.AppendLine("There is a new version.");
                            content.AppendLine("To be updated with the new version please click the title of the body.");
                            content.AppendLine("");
                            content.AppendLine("Current version : " + _currver);
                            content.AppendLine("New version : " + _newver);
                        }

                        NotifyWindow nw;

                        nw = new NotifyWindow(title.ToString(), content.ToString());
                        nw.TitleClicked += new EventHandler(nw_TitleClicked);
                        nw.FormClosed += new FormClosedEventHandler(nw_FormClosed);
                        nw.TextClicked += new EventHandler(nw_TextClicked);
                        if (mount != null || mountstock != null) nw.Location = new Point(0, Screen.PrimaryScreen.WorkingArea.Height - (Screen.PrimaryScreen.WorkingArea.Height / 3));
                        nw.SetDimensions(Screen.PrimaryScreen.WorkingArea.Width / 3, Screen.PrimaryScreen.WorkingArea.Height / 3);
                        update = nw;
                        nw.Notify();
                    }
                }
                catch { }
            }

            tmrUpdate.Start();
        }

        void pickuploss_TextClicked(object sender, EventArgs e)
        {
            this.Load_Form("PRDZ012", "픽업미스 조치내역 등록", 0, "", "W");
            //pickuploss.Close();
        }

        void nw_TextClicked(object sender, EventArgs e)
        {
            if (iDATMessageBox.QuestionMessage(m_clsLan.GetMessageString("APPRESTARTQUESTION"), "Main") == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        void nw_FormClosed(object sender, FormClosedEventArgs e)
        {
            update = null;
        }

        void pickuploss_TitleClicked(object sender, EventArgs e)
        {
            this.Load_Form("PRDZ012", "픽업미스 조치내역 등록", 0, "", "W");
            //pickuploss.Close();
        }

        void nw_TitleClicked(object sender, EventArgs e)
        {
            if (iDATMessageBox.QuestionMessage(m_clsLan.GetMessageString("APPRESTARTQUESTION"), "Main") == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void barBtnHelp_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ActiveMdiChild == null) return;
            

            switch (this.ActiveMdiChild.Name)
            {
                case "PRDA204"://작업실적(압착)
                    frm = new COMHELP(Properties.Resources.R1000.Width, Properties.Resources.R1000.Height, Properties.Resources.R1000);
                    break;
                case "PRDA220"://작업실적(압착검사)
                    frm = new COMHELP(Properties.Resources.R2000.Width, Properties.Resources.R2000.Height, Properties.Resources.R2000);
                    break;
                case "PRDA205"://작업실적(조립)
                    frm = new COMHELP(Properties.Resources.R3000.Width, Properties.Resources.R3000.Height, Properties.Resources.R3000);
                    break;
                case "PRDA206"://작업실적(육안검사) OR 작업실적(수축)
                    if (this.ActiveMdiChild.Tag.ObjectNullString() == "#0201") //육안검사
                    {
                        frm = new COMHELP(Properties.Resources.R4000.Width, Properties.Resources.R4000.Height, Properties.Resources.R4000);
                    }
                    else if(this.ActiveMdiChild.Tag.ObjectNullString() == "#0301") // 수축
                    {
                        frm = new COMHELP(Properties.Resources.R5000.Width, Properties.Resources.R5000.Height, Properties.Resources.R5000);
                    }
                    break; 
                case "PRDA209"://통전검사(일반)
                    frm = new COMHELP(Properties.Resources.R6000.Width, Properties.Resources.R6000.Height, Properties.Resources.R6000);
                    break;
                case "PRDA210"://통전검사(자동)
                    frm = new COMHELP(Properties.Resources.R6000.Width, Properties.Resources.R6000.Height, Properties.Resources.R6000);
                    break;
            }

            frm?.ShowDialog();
            
        }

        #region [IQC 만기일자 정보 알림]
        private void CheckExpiryMaterial()
        {
            HAENGSUNG_HNSMES_UI.WebService.Business.IDatabaseProcess dbHelper = this._DB;
            
            WSResults retData = dbHelper.Execute_Proc( "PKGSYS_COMM.GET_EXPIRY_MATERIAL"
                                                     , 1
                                                     , new string[] { 
                                                       "A_CLIENT"
                                                     , "A_COMPANY"
                                                     , "A_PLANT" }
                                                     , new string[] { 
                                                       Global.Global_Variable.CLIENT
                                                     , Global.Global_Variable.COMPANY
                                                     , Global.Global_Variable.PLANT }
                                                     );

            if (retData.ResultInt == 0)
            {
                if (retData.ResultDataSet.Tables[0].Rows.Count > 0)
                {
                    StringBuilder content = new StringBuilder();

                    foreach (DataRow dr in retData.ResultDataSet.Tables[0].Rows)
                    {
                        content.AppendLine(dr["PARTNO"] + ", " + dr["SPEC"] + ", " + dr["ITEMNAME"] + ", " + dr["LASTDATE"]);
                    }

                    mExpiryMaterial = content.ToString();
                }
                else
                {
                    mExpiryMaterial = "";
                }
            }
            else
            {
                mExpiryMaterial = "";
            }
        }
        private void ExpiryMaterialShowAlram()
        {
            if (mExpiryMaterial != "")
            {
                if (expiry == null)
                {
                    try
                    {
                        StringBuilder title = new StringBuilder();
                        StringBuilder content = new StringBuilder();

                        title.AppendLine("HAENGSUNG HNS MES Expiry Material Alert");

                        if (Application.CurrentCulture.Name.ToUpper() == "KO-KR")
                        {
                            content.AppendLine("인증 문서 만기일자가 도래되었습니다.!!!!!");
                            content.AppendLine("- 만기 내역 -");
                        }
                        else if (Application.CurrentCulture.Name.ToUpper() == "ZH-CN")
                        {
                            content.AppendLine("认证文件的到期日期已经到来。!!!!!");
                            content.AppendLine("- 过期历史 -");
                        }
                        else
                        {
                            content.AppendLine("The expiration date of the certification document has arrived.!!!!!");
                            content.AppendLine("- Expiration history -");
                        }

                        content.AppendLine(mExpiryMaterial);

                        AlertWindow nw = new AlertWindow(title.ToString(), content.ToString()) { WaitTime = 60000 };

                        nw.FormClosed += new FormClosedEventHandler(expiry_FormClosed);
                        nw.SetDimensions(Screen.PrimaryScreen.WorkingArea.Width / 3, Screen.PrimaryScreen.WorkingArea.Height / 3);
                        expiry = nw;
                        nw.Alert();

                        mExpiryMaterial = "";
                    }
                    catch { }
                }
            }
        }
        #endregion

        #region [JIG 사용 정보 알림]
        private void CheckExpiryJIG()
        {
            HAENGSUNG_HNSMES_UI.WebService.Business.IDatabaseProcess dbHelper = this._DB;

            WSResults retData = dbHelper.Execute_Proc("PKGSYS_COMM.GET_EXPIRY_JIG"
                                                     , 1
                                                     , new string[] { 
                                                       "A_CLIENT"
                                                     , "A_COMPANY"
                                                     , "A_PLANT" }
                                                     , new string[] { 
                                                       Global.Global_Variable.CLIENT
                                                     , Global.Global_Variable.COMPANY
                                                     , Global.Global_Variable.PLANT }
                                                     );

            if (retData.ResultInt == 0)
            {
                if (retData.ResultDataSet.Tables[0].Rows.Count > 0)
                {
                    StringBuilder content = new StringBuilder();

                    foreach (DataRow dr in retData.ResultDataSet.Tables[0].Rows)
                    {
                        content.AppendLine(dr["SERIAL"] + ", " + dr["GOODQTY"]);
                    }

                    mCircuitJIG = content.ToString();
                }
                else
                {
                    mCircuitJIG = "";
                }
            }
            else
            {
                mCircuitJIG = "";
            }
        }
        private void ExpiryJIGShowAlram()
        {
            if (mCircuitJIG != "")
            {
                if (CircuitJIG == null)
                {
                    try
                    {
                        StringBuilder title = new StringBuilder();
                        StringBuilder content = new StringBuilder();

                        title.AppendLine("HAENGSUNG HNS MES JIG status Alert");

                        if (Application.CurrentCulture.Name.ToUpper() == "KO-KR")
                        {
                            content.AppendLine("회로검사 JIG 사용 알림입니다.!!!!!");
                            content.AppendLine("- 잔여 내역 -");
                        }
                        else if (Application.CurrentCulture.Name.ToUpper() == "ZH-CN")
                        {
                            content.AppendLine("这是关于使用电路检查JIG的通知。!!!!!");
                            content.AppendLine("- 其余细节 -");
                        }
                        else
                        {
                            content.AppendLine("This is a notification of the use of circuit check JIG.!!!!!");
                            content.AppendLine("- Remaining details -");
                        }

                        content.AppendLine(mCircuitJIG);

                        AlertWindow nw = new AlertWindow(title.ToString(), content.ToString()) { WaitTime = 60000 };

                        nw.FormClosed += new FormClosedEventHandler(expiry_FormClosed);
                        nw.SetDimensions(Screen.PrimaryScreen.WorkingArea.Width / 3, Screen.PrimaryScreen.WorkingArea.Height / 3);
                        CircuitJIG = nw;
                        nw.Alert();

                        mCircuitJIG = "";
                    }
                    catch { }
                }
            }
        }
        #endregion
    }
}