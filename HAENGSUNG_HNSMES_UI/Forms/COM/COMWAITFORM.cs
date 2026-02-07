using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraWaitForm;

namespace HAENGSUNG_HNSMES_UI.Forms.COM
{
    public partial class COMWAITFORM : WaitForm
    {
        public COMWAITFORM()
        {
            InitializeComponent();
            this.progressPanel1.AutoHeight = true;
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            switch ((WaitFormCommand)cmd)
            {
                case WaitFormCommand.SetCaption:
                    this.progressPanel1.Caption = arg.ObjectNullString();
                    break;
                case WaitFormCommand.SetDescription:
                    this.progressPanel1.Description = arg.ObjectNullString();
                    break;
            }

            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum WaitFormCommand
        {
            SetCaption = 0,
            SetDescription = 1
        }
    }
}