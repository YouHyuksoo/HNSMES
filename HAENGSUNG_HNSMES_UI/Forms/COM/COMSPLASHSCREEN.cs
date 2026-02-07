using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace HAENGSUNG_HNSMES_UI.Forms.COM
{
    public partial class COMSPLASHSCREEN : SplashScreen
    {
        public COMSPLASHSCREEN()
        {
            InitializeComponent();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            try
            {
                if ((SplashScreenCommand)cmd == SplashScreenCommand.Description)
                {
                    labelControl2.Text = arg.ObjectNullString();
                }
            }
            catch { }

            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
            Description = 0
        }
    }
}