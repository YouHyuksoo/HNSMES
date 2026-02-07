using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraGrid;
using DevExpress.XtraPivotGrid;
using DevExpress.Utils.Menu;

namespace HAENGSUNG_HNSMES_UI.Forms.BASE
{
    public partial class UserControl : IDAT.Devexpress.FORM.BaseControl
    {
        
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

        public UserControl()
            : base()
        {
            InitializeComponent();

            if (SplashScreenManager.Default == null && AllowWaitDialog)
            {
                SplashScreenManager.ShowForm(this.FindForm(), typeof(DevExpress.XtraWaitForm.DemoWaitForm), false, true);
                if (SplashScreenManager.Default != null)
                    SplashScreenManager.Default.SetWaitFormDescription(string.Format("{0} loading...", ModuleName));
            }

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
    }
}
