using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Control;

namespace HAENGSUNG_HNSMES_UI.UserControl.SAL
{
    public partial class xucPreview : DevExpress.XtraEditors.XtraUserControl
    {
        public PrintControl printControl
        {
            get
            {
                return printControl1;
            }
            set
            {
                printControl1 = value;
            }
        }

        public xucPreview()
        {
            InitializeComponent();
        }
    }
}
