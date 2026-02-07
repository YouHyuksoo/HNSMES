using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HAENGSUNG_HNSMES_UI.Forms.COM
{
    public partial class COMPREVIEW : DevExpress.XtraEditors.XtraForm
    {
        DataSet m_ds;
        public COMPREVIEW()
        {
            InitializeComponent();
        }

        public COMPREVIEW(DataSet p_ds)
        {
            InitializeComponent();
            m_ds = p_ds;
        }

        private void COMPREVIEW_Load(object sender, EventArgs e) 
        {
            // 사용 방법을 모른다.
            //iDAT_HSDMES.Forms.RPT.RPTB001 _rpt = new iDAT_HSDMES.Forms.RPT.RPTB001(m_ds);

            //prtPreview.AutoSize = true;
            //prtPreview.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;

            //_rpt.CreateDocument(true);
            //prtPreview.PrintingSystem = _rpt.PrintingSystem;
            //prtPreview.PrintingSystem.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.ZoomToWholePage, new object[] { true }); // setting the Zoom to the whole page
        }

    }
}
