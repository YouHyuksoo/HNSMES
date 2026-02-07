using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

// user namespace
using System.Collections;
using HAENGSUNG_HNSMES_UI.Class;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;

using DevExpress.Utils;
using IDAT.WebService;
using DevExpress.XtraBars.Ribbon;
using Microsoft.VisualBasic;
using System.IO;
using System.IO.Ports;
using DevExpress.XtraPrinting;
using System.Drawing.Printing;
using System.Threading.Tasks;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraGrid;
using DevExpress.XtraPivotGrid;
using DevExpress.Utils.Menu;
using IDAT.Devexpress.ActionDemo;
using HAENGSUNG_HNSMES_UI.Base.Class.ActiveDemo;

namespace HAENGSUNG_HNSMES_UI.Forms.BASE
{
    public enum WebServiceType
    {
        HTTPWebService,
        WCFService
    }

    public partial class Form : IDAT.Devexpress.FORM.BaseForm
    {
        // 웹서비스 타입을 설정합니다.
        WebServiceType _WebServicetype = WebServiceType.WCFService;
        LogUtility _clsLog = new LogUtility();

        SerialPort mSerialPort1 = null;
        SerialPort mSerialPort2 = null;
        SerialPort mSerialPort3 = null;
        SerialPort mSerialPort4 = null;

        public SerialPort _SerialPort1
        {
            get { return mSerialPort1; }
            set { mSerialPort1 = value; }
        }

        public SerialPort _SerialPort2
        {
            get { return mSerialPort2; }
            set { mSerialPort2 = value; }
        }

        public SerialPort _SerialPort3
        {
            get { return mSerialPort3; }
            set { mSerialPort3 = value; }
        }

        public SerialPort _SerialPort4
        {
            get { return mSerialPort4; }
            set { mSerialPort4 = value; }
        }

        public string STX
        {
            get { return Convert.ToString((char)2); }
        }

        public string ETX
        {
            get { return Convert.ToString((char)3); }
        }

        public WebServiceType WebServicetype
        {
            get
            {
                return _WebServicetype;
            }
            set
            {
                _WebServicetype = value;

                if (value == WebServiceType.HTTPWebService)
                {
                    BASE_db = new HAENGSUNG_HNSMES_UI.WebService.Business.WSDatabaseProcess();
                }
                else
                {
                    BASE_db = new HAENGSUNG_HNSMES_UI.WebService.Business.WCFDatabaseProcess();
                }
            }
        }


        private delegate void SetDefaultControlEventHandler(Control OneControls);

        // Base Class 선언
        internal HAENGSUNG_HNSMES_UI.WebService.Business.IDatabaseProcess BASE_db = null;
        internal HAENGSUNG_HNSMES_UI.WebService.Business.WSDatabaseProcess WS_db = new WebService.Business.WSDatabaseProcess();
        internal IDAT.Devexpress.GRID.IDATDevExpress_GridControl BASE_clsDevexpressGridUtil = new IDAT.Devexpress.GRID.IDATDevExpress_GridControl();
        internal IDAT.Devexpress.FORM.iDATCommonControlManager BASE_FormconlUtil = new IDAT.Devexpress.FORM.iDATCommonControlManager();
        internal HAENGSUNG_HNSMES_UI.Class.DXGridHelper BASE_DXGridHelper = null;
        internal HAENGSUNG_HNSMES_UI.Class.DXGridLookUpHelper BASE_DXGridLookUpHelper = null;
        internal IDAT.Devexpress.LAYOUT.IDATDevExpress_Layoutcontrol BASE_IDATLayoutUtil = new IDAT.Devexpress.LAYOUT.IDATDevExpress_Layoutcontrol();
        internal HAENGSUNG_HNSMES_UI.Class.LanguageInformation BASE_Language = new HAENGSUNG_HNSMES_UI.Class.LanguageInformation();
        //internal HAENGSUNG_HNSMES_UI.MyClass.myRepository BASE_myRepository = null;

        // Button 선언
        internal Base.Class.Controls.IMainButtons MainButton_INIT;
        internal Base.Class.Controls.IMainButtons MainButton_Search;
        internal Base.Class.Controls.IMainButtons MainButton_Refresh;
        internal Base.Class.Controls.IMainButtons MainButton_Stop;
        internal Base.Class.Controls.IMainButtons MainButton_Save;
        internal Base.Class.Controls.IMainButtons MainButton_Edit;
        internal Base.Class.Controls.IMainButtons MainButton_New;
        internal Base.Class.Controls.IMainButtons MainButton_Delete;
        internal Base.Class.Controls.IMainButtons MainButton_Print;
        internal Base.Class.Controls.IMainButtons MainButton_Close;
        internal Base.Class.Controls.IMainButtons MainButton_AllClose;

        internal bool FirstShowing = true;

        public virtual string ModuleCaption { get { return string.Empty; } }
        public virtual string ModuleName { get { return ModuleCaption; } }
        internal virtual void ShowModule(object item)
        {
            FirstShowing = false;
        }
        internal virtual void HideModule() { }
        internal virtual void InitModule(IDXMenuManager manager, object data)
        {
            SetMenuManager(this.Controls, manager);
        }

        public Form()
            : base()
        {
            InitializeComponent();

            //if (SplashScreenManager.Default == null && AllowWaitDialog)
            //{
            //    SplashScreenManager.ShowForm(this.ParentForm, typeof(DevExpress.XtraWaitForm.DemoWaitForm), false, true);
            //    if (SplashScreenManager.Default != null)
            //        SplashScreenManager.Default.SetWaitFormDescription(string.Format("{0} loading...", ModuleName));
            //}

            if (!DesignMode)
            {
                if (Program.frmM != null)
                {
                    if (Settings_IDAT.Default.WINSTYLE.ToUpper() == "RIBBON")
                    {
                        MainButton_INIT = (Base.Class.Controls.IMainButtons)Program.frmM.btnInit;
                        MainButton_Search = (Base.Class.Controls.IMainButtons)Program.frmM.btnSearch;
                        MainButton_Refresh = (Base.Class.Controls.IMainButtons)Program.frmM.btnRefresh;
                        MainButton_Stop = (Base.Class.Controls.IMainButtons)Program.frmM.btnStop;
                        MainButton_Save = (Base.Class.Controls.IMainButtons)Program.frmM.btnSave;
                        MainButton_Edit = (Base.Class.Controls.IMainButtons)Program.frmM.btnEdit;
                        MainButton_New = (Base.Class.Controls.IMainButtons)Program.frmM.btnNew;
                        MainButton_Delete = (Base.Class.Controls.IMainButtons)Program.frmM.btnDelete;
                        MainButton_Print = (Base.Class.Controls.IMainButtons)Program.frmM.btnPrint;
                        MainButton_Close = (Base.Class.Controls.IMainButtons)Program.frmM.btnClose;
                        MainButton_AllClose = (Base.Class.Controls.IMainButtons)Program.frmM.btnCloseAll;
                    }
                    else if (Settings_IDAT.Default.WINSTYLE.ToUpper() == "NORMAL")
                    {
                        MainButton_INIT = (Base.Class.Controls.IMainButtons)Program.frmM.btnInit1;
                        MainButton_Search = (Base.Class.Controls.IMainButtons)Program.frmM.btnSearch1;
                        MainButton_Refresh = (Base.Class.Controls.IMainButtons)Program.frmM.btnRefresh1;
                        MainButton_Stop = (Base.Class.Controls.IMainButtons)Program.frmM.btnStop1;
                        MainButton_Save = (Base.Class.Controls.IMainButtons)Program.frmM.btnSave1;
                        MainButton_Edit = (Base.Class.Controls.IMainButtons)Program.frmM.btnEdit1;
                        MainButton_New = (Base.Class.Controls.IMainButtons)Program.frmM.btnNew1;
                        MainButton_Delete = (Base.Class.Controls.IMainButtons)Program.frmM.btnDelete1;
                        MainButton_Print = (Base.Class.Controls.IMainButtons)Program.frmM.btnPrint1;
                        MainButton_Close = (Base.Class.Controls.IMainButtons)Program.frmM.btnClose1;
                        MainButton_AllClose = (Base.Class.Controls.IMainButtons)Program.frmM.btnCloseAll1;
                    }
                }
            }

            WebServicetype = WebServiceType.WCFService;

            

            if (WebServicetype == WebServiceType.HTTPWebService)
                BASE_db = new HAENGSUNG_HNSMES_UI.WebService.Business.WSDatabaseProcess();
            else
                BASE_db = new HAENGSUNG_HNSMES_UI.WebService.Business.WCFDatabaseProcess();

            BASE_DXGridHelper = new DXGridHelper(BASE_db);
            BASE_DXGridLookUpHelper = new DXGridLookUpHelper(BASE_db);
            //BASE_myRepository = new MyClass.myRepository(BASE_db);

            BASE_FormconlUtil.IDAT_ChangedCaptionStringEvent += new IDAT.Devexpress.FORM.iDATCommonControlManager.IDAT_ChangedCaptionString(BASE_conlUtil_IDAT_ChangedCaptionStringEvent);
            BASE_FormconlUtil.IDAT_SelectionSummaryEvent += new IDAT.Devexpress.FORM.iDATCommonControlManager.IDAT_SelectionSummary(BASE_conlUtil_IDAT_SelectionSummaryEvent);
        }

        void SetMenuManager(System.Windows.Forms.Control.ControlCollection controlCollection, IDXMenuManager manager)
        {
            foreach (Control ctrl in controlCollection)
            {
                GridControl grid = ctrl as GridControl;
                if (grid != null)
                {
                    grid.MenuManager = manager;
                    break;
                }
                PivotGridControl pivot = ctrl as PivotGridControl;
                if (pivot != null)
                {
                    pivot.MenuManager = manager;
                    break;
                }
                BaseEdit edit = ctrl as BaseEdit;
                if (edit != null)
                {
                    edit.MenuManager = manager;
                    break;
                }
                SetMenuManager(ctrl.Controls, manager);
            }
        }
        public virtual bool AllowWaitDialog { get { return true; } }

        // Grid 선택 합계, 평균 구하기.
        void BASE_conlUtil_IDAT_SelectionSummaryEvent(decimal count, decimal result)
        {
            //Program.frmM.SubMessage = string.Format("COUNT={0}  SUM={1}  AVG={2}", count.ToString("n0"), result.ToString("n0"), (result / count).ToString("n2"));
        }

        // Language 이벤트 용어
        void BASE_conlUtil_IDAT_ChangedCaptionStringEvent(ref string strCaptionText)
        {
            strCaptionText = BASE_Language.GetMessageString(strCaptionText.Trim());
        }

        #region [Form Load && Shown]

        private void Form_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                Program.frmM.btnInit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnInit_ItemClick);
                Program.frmM.btnInit1.Click += new EventHandler(btnInit1_Click);

                Program.frmM.btnSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnSearch_ItemClick);
                Program.frmM.btnSearch1.Click += new EventHandler(btnSearch1_Click);

                Program.frmM.btnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnNew_ItemClick);
                Program.frmM.btnNew1.Click += new EventHandler(btnNew1_Click);

                Program.frmM.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnEdit_ItemClick);
                Program.frmM.btnEdit1.Click += new EventHandler(btnMainEdit_Click);

                Program.frmM.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnRefresh_ItemClick);
                Program.frmM.btnRefresh1.Click += new EventHandler(btnRefresh1_Click);

                string strFormName = this.Name;
                if (this.Tag + "" != "") strFormName += "_" + this.Tag;

                _clsLog.SaveUseHistory(strFormName, strFormName + "_FormLoad", "", "");

                if (!DesignMode)
                {
                    BASE_FormconlUtil.SetLayControlsInit(this);
                    BASE_FormconlUtil.SetDefaultControls(this);

                    SetDefaultControls(this);
                }

                if (ShowSaveButton)
                    this.IsButtonSaveEnable = ShowSaveButton;

                if (ShowInitButton)
                    this.IsButtonInitEnable = ShowInitButton;

                if (ShowSearchButton)
                    this.IsButtonSearchEnable = ShowSearchButton;

                if (ShowStopButton)
                    this.IsButtonStopEnable = ShowStopButton;

                if (ShowRefreshButton)
                    this.IsButtonRefreshEnable = ShowRefreshButton;

                if (ShowPrintButton)
                    this.IsButtonPrintEnable = ShowPrintButton;

                // 버튼의 기본설정이 들어간다.
                if (this.FormClass == "W")
                {
                    if (ShowNewbutton)
                    {
                        Program.frmM.btnNew.Enabled = true;
                        Program.frmM.btnNew1.Enabled = true;
                        this.IsButtonNewEnable = true;
                    }

                    if (ShowEditButton)
                    {
                        Program.frmM.btnEdit.Enabled = true;
                        Program.frmM.btnEdit1.Enabled = true;
                        this.IsButtonEditEnable = true;
                    }

                    if (ShowDeleteButton)
                    {
                        Program.frmM.btnDelete.Enabled = true;
                        Program.frmM.btnDelete1.Enabled = true;
                        this.IsButtonDeleteEnable = true;
                    }
                }
                else
                {
                    if (ShowNewbutton)
                    {
                        Program.frmM.btnNew.Enabled = false;
                        Program.frmM.btnNew1.Enabled = false;
                        this.IsButtonNewEnable = false;
                    }

                    if (ShowEditButton)
                    {
                        Program.frmM.btnEdit.Enabled = false;
                        Program.frmM.btnEdit1.Enabled = false;
                        this.IsButtonEditEnable = false;
                    }

                    if (ShowDeleteButton)
                    {
                        Program.frmM.btnDelete.Enabled = false;
                        Program.frmM.btnDelete1.Enabled = false;
                        this.IsButtonDeleteEnable = false;
                    }
                }

                if (!this.ShowSaveButton)
                {
                    if (this.ShowEditButton) this.ShowSaveButton = true;
                    if (this.ShowNewbutton) this.ShowSaveButton = true;
                    if (this.ShowDeleteButton) this.ShowSaveButton = true;
                }
            }
        }

        private void Form_Shown(object sender, EventArgs e)
        {
        }

        // 컨트롤의 기본속성을 부여합니다. [공통 컨트롤 적용] ***************************************
        public void SetUserDefaultControl(Control cons)
        {
            try
            {
                if (cons is DevExpress.XtraGrid.GridControl)
                {
                    DevExpress.XtraGrid.GridControl gridCon = cons as DevExpress.XtraGrid.GridControl;
                    DevExpress.XtraGrid.Views.Grid.GridView gridV = gridCon.DefaultView as DevExpress.XtraGrid.Views.Grid.GridView;

                    gridV.OptionsBehavior.EditorShowMode = EditorShowMode.MouseDown;
                    gridV.EX_SetIDIFExtendGridView(this.Name);
                }

                if (cons is DevExpress.XtraLayout.LayoutControl)
                {
                    DevExpress.XtraLayout.LayoutControl layout = cons as DevExpress.XtraLayout.LayoutControl;
                    layout.OptionsFocus.MoveFocusDirection = MoveFocusDirection.AcrossThenDown;
                }

                if (cons is DevExpress.XtraEditors.GridLookUpEdit)
                {
                    DevExpress.XtraEditors.GridLookUpEdit gridlookup = cons as DevExpress.XtraEditors.GridLookUpEdit;
                    gridlookup.Properties.AllowNullInput = DefaultBoolean.True;
                    if (gridlookup.Properties.NullText == "[EditValue is null]") gridlookup.Properties.NullText = "[선택]";
                }
            }
            catch (Exception)
            {
            }
        }

        private void SetDefaultControls(Control controls)
        {
            Control[] AllControls = GetAllControls(controls);

            for (int i = 0; i < AllControls.Length; i++)
            {
                if (AllControls[i].InvokeRequired)
                {
                    AllControls[i].Invoke(new SetDefaultControlEventHandler(SetUserDefaultControl), (Control)AllControls[i]);
                }
                else
                {
                    SetUserDefaultControl((Control)AllControls[i]);
                }
            }
        }

        private Control[] GetAllControls(Control containerControl)
        {
            List<Control> allControls = new List<Control>();
            Queue<Control.ControlCollection> queue = new Queue<Control.ControlCollection>();
            queue.Enqueue(containerControl.Controls);

            Task task = new Task(() =>
            {
                while (queue.Count > 0)
                {
                    Control.ControlCollection controls = (Control.ControlCollection)queue.Dequeue();
                    if (controls == null || controls.Count == 0) continue;

                    foreach (Control control in controls)
                    {
                        allControls.Add(control);
                        queue.Enqueue(control.Controls);
                    }
                }
            });

            task.Start();
            task.Wait();

            return allControls.ToArray();
        }

        /// <summary>
        /// DataTable 의 데이터를 xml 형식의 텍스트로 변환하여 반환한다.
        /// </summary>
        public string GetDataTableToXml(DataTable dt)
        {
            string _Ret = "";
            string _Name = "";

            _Name = dt.TableName;
            dt.TableName = "Table";
            using (MemoryStream ms = new MemoryStream())
            {
                dt.WriteXml(ms, XmlWriteMode.IgnoreSchema);
                ms.Flush();
                ms.Position = 0;
                using (StreamReader sr = new StreamReader(ms, Encoding.Default))
                {
                    _Ret = sr.ReadToEnd();
                    _Ret = @"<?xml version=""1.0"" encoding=""UTF-8""?>" + "\r\n" + _Ret;

                    sr.Close();
                }
                ms.Close();
            }

            dt.TableName = _Name;

            return _Ret.Replace("&amp;", "&");
        }

        #endregion

        #region [Form Button 이벤트]

        // ################################################################################Search
        internal void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }
        internal void btnSearch1_Click(object sender, EventArgs e)
        {
            btnSearch_ItemClick(null, null);
        }

        // ################################################################################Init
        internal void btnInit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.Name != Program.frmM.ActiveMdiChild.Name)
                return;

            if (!(this is HAENGSUNG_HNSMES_UI.Class.itfButton))
            {
                return;
            }

            if (Program.frmM.ActiveMdiChild == null)
                return;

            if (this.Name != Program.frmM.ActiveMdiChild.Name)
                return;


            // NEW
            if (ShowNewbutton)
            {
                if (this.IsButtonAuto)
                {
                    // 버튼의 기본설정이 들어간다.
                    if (this.FormClass == "W")
                    {
                        Program.frmM.btnNew.Enabled = true;
                        Program.frmM.btnNew1.Enabled = true;
                        this.IsButtonNewEnable = true;
                    }
                }
            }
            else
            {
                if (this.IsButtonAuto)
                {
                    Program.frmM.btnNew.Enabled = false;
                    Program.frmM.btnNew1.Enabled = false;
                    this.IsButtonNewEnable = false;
                }
            }

            // EDIT
            if (ShowEditButton)
            {
                if (this.IsButtonAuto)
                {
                    // 버튼의 기본설정이 들어간다.
                    if (this.FormClass == "W")
                    {
                        Program.frmM.btnEdit.Enabled = true;
                        Program.frmM.btnEdit1.Enabled = true;
                        this.IsButtonEditEnable = true;
                    }
                }
            }
            else
            {
                if (this.IsButtonAuto)
                {
                    Program.frmM.btnEdit.Enabled = false;
                    Program.frmM.btnEdit1.Enabled = false;
                    this.IsButtonEditEnable = false;
                }
            }

            // DELETE
            if (ShowDeleteButton)
            {
                if (this.IsButtonAuto)
                {
                    // 버튼의 기본설정이 들어간다.
                    if (this.FormClass == "W")
                    {
                        Program.frmM.btnDelete.Enabled = true;
                        Program.frmM.btnDelete1.Enabled = true;
                        this.IsButtonDeleteEnable = true;
                    }
                }
            }
            else
            {
                if (this.IsButtonAuto)
                {
                    Program.frmM.btnDelete.Enabled = false;
                    Program.frmM.btnDelete1.Enabled = false;
                    this.IsButtonDeleteEnable = false;
                }
            }
        }
        internal void btnInit1_Click(object sender, EventArgs e)
        {
            btnInit_ItemClick(null, null);
        }

        // ################################################################################Edit
        internal void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.Name != Program.frmM.ActiveMdiChild.Name)
                return;

            if (IsButtonAuto)
            {
                Program.frmM.btnNew.Enabled = false;
                Program.frmM.btnNew1.Enabled = false;
                this.IsButtonNewEnable = false;

                Program.frmM.btnEdit.Enabled = false;
                Program.frmM.btnEdit1.Enabled = false;
                this.IsButtonEditEnable = false;

                // 버튼의 기본설정이 들어간다.
                if (this.FormClass == "W")
                {
                    Program.frmM.btnSave.Enabled = true;
                    Program.frmM.btnSave1.Enabled = true;
                    this.IsButtonSaveEnable = true;
                }

                Program.frmM.btnDelete.Enabled = false;
                Program.frmM.btnDelete1.Enabled = false;
                this.IsButtonDeleteEnable = false;
            }
        }
        internal void btnMainEdit_Click(object sender, EventArgs e)
        {
            btnEdit_ItemClick(null, null);
        }

        // ################################################################################New
        internal void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.frmM.ActiveMdiChild == null) return;
            if (this.Name != Program.frmM.ActiveMdiChild.Name)
                return;

            if (IsButtonAuto)
            {
                Program.frmM.btnNew.Enabled = false;
                Program.frmM.btnNew1.Enabled = false;
                this.IsButtonNewEnable = false;

                Program.frmM.btnEdit.Enabled = false;
                Program.frmM.btnEdit1.Enabled = false;
                this.IsButtonEditEnable = false;

                // 버튼의 기본설정이 들어간다.
                if (this.FormClass == "W")
                {
                    Program.frmM.btnSave.Enabled = true;
                    Program.frmM.btnSave1.Enabled = true;
                    this.IsButtonSaveEnable = true;
                }

                Program.frmM.btnDelete.Enabled = false;
                Program.frmM.btnDelete1.Enabled = false;
                this.IsButtonDeleteEnable = false;
            }
        }
        void btnNew1_Click(object sender, EventArgs e)
        {
            btnNew_ItemClick(null, null);
        }

        // ################################################################################Refresh
        void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.Name != Program.frmM.ActiveMdiChild.Name)
                return;

            if (this.IsButtonAuto)
            {
                // NEW
                if (ShowNewbutton)
                {
                    // 버튼의 기본설정이 들어간다.
                    if (this.FormClass == "W")
                    {
                        Program.frmM.btnNew.Enabled = true;
                        Program.frmM.btnNew1.Enabled = true;
                        this.IsButtonNewEnable = true;
                    }
                }
                else
                {
                    Program.frmM.btnNew.Enabled = false;
                    Program.frmM.btnNew1.Enabled = false;
                    this.IsButtonNewEnable = false;
                }

                // EDIT
                if (ShowEditButton)
                {
                    // 버튼의 기본설정이 들어간다.
                    if (this.FormClass == "W")
                    {
                        Program.frmM.btnEdit.Enabled = true;
                        Program.frmM.btnEdit1.Enabled = true;
                        this.IsButtonEditEnable = true;
                    }
                }
                else
                {
                    Program.frmM.btnEdit.Enabled = false;
                    Program.frmM.btnEdit1.Enabled = false;
                    this.IsButtonEditEnable = false;
                }

                // DELETE
                if (ShowDeleteButton)
                {
                    // 버튼의 기본설정이 들어간다.
                    if (this.FormClass == "W")
                    {
                        Program.frmM.btnDelete.Enabled = true;
                        Program.frmM.btnDelete1.Enabled = true;
                        this.IsButtonDeleteEnable = true;
                    }
                }
                else
                {
                    Program.frmM.btnDelete.Enabled = false;
                    Program.frmM.btnDelete1.Enabled = false;
                    this.IsButtonDeleteEnable = false;
                }
            }
        }
        void btnRefresh1_Click(object sender, EventArgs e)
        {
            btnRefresh_ItemClick(this, null);
        }

        #endregion

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.DesignMode)
            {
                Program.frmM.btnInit.ItemClick -= new DevExpress.XtraBars.ItemClickEventHandler(btnInit_ItemClick);
                Program.frmM.btnInit1.Click -= new EventHandler(btnInit1_Click);

                Program.frmM.btnSearch.ItemClick -= new DevExpress.XtraBars.ItemClickEventHandler(btnSearch_ItemClick);
                Program.frmM.btnSearch1.Click -= new EventHandler(btnSearch1_Click);

                Program.frmM.btnNew.ItemClick -= new DevExpress.XtraBars.ItemClickEventHandler(btnNew_ItemClick);
                Program.frmM.btnNew1.Click -= new EventHandler(btnNew1_Click);

                Program.frmM.btnEdit.ItemClick -= new DevExpress.XtraBars.ItemClickEventHandler(btnEdit_ItemClick);
                Program.frmM.btnEdit1.Click -= new EventHandler(btnMainEdit_Click);

                Program.frmM.btnRefresh.ItemClick -= new DevExpress.XtraBars.ItemClickEventHandler(btnRefresh_ItemClick);
                Program.frmM.btnRefresh1.Click -= new EventHandler(btnRefresh1_Click);
            }

            string _strFormName = this.Name;
            if (this.Tag + "" != "") _strFormName += "_" + this.Tag;

            _clsLog.SaveUseHistory(_strFormName, _strFormName + "_FormClosing", "", "");
        }

        #region [Demo Action]

        //ActiveDemoResults fActiveDemoResults = null;
        private ActiveGridDemo fActiveDemo = null;
        public new bool IsActiveDemo { get { return fActiveDemo != null; } }

        public void RunActiveDemo(GridControl gc, string helpType)
        {
            if (IsActiveDemo)
            {
                fActiveDemo = null;
                return;
            }
            fActiveDemo = CreateActiveGridDemo(gc);

            if (fActiveDemo == null) return;
            //b.RunDemo(fActiveDemo, this, helpType);

            if (fActiveDemo == null) return;
            ActiveActionsCancelMode cancelMode = fActiveDemo.Actions.CancelMode;
            fActiveDemo.Dispose();
            fActiveDemo = null;
            if (cancelMode == ActiveActionsCancelMode.UnknownTopWindow)
                System.Windows.Forms.MessageBox.Show("There is unknown window above the demo. Please hide or close all tops windows to run active demo"); //TODO
            if (cancelMode == ActiveActionsCancelMode.UserCancel)
                System.Windows.Forms.MessageBox.Show("도움말을 종료 합니다.");
        }
        protected virtual ActiveGridDemo CreateActiveGridDemo(GridControl gc)
        {
            return new ActiveGridDemo(gc);
        }

        protected virtual new void RunGridActiveDemo(ActiveGridDemo fActiveDemo) { }

        #endregion
    }
}