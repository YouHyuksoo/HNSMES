using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HAENGSUNG_HNSMES_UI.UserControl.COM
{
    public partial class XucFromToDate : IDAT.Devexpress.FORM.BaseControl
    {
        public XucFromToDate()
        {
            InitializeComponent();
            this.Size = new Size(232, 20);
        }

        public string StartDate
        {
            get
            {
                return dteStart.DateTime.ToString("yyyyMMdd");
            }
        }

        public string EndDate
        {
            get
            {
                return dteEnd.DateTime.ToString("yyyyMMdd");
            }
        }

        private void dteStart_EditValueChanged(object sender, EventArgs e)
        {
            if (int.Parse(dteStart.DateTime.ToString("yyyyMMdd")) > int.Parse(dteEnd.DateTime.ToString("yyyyMMdd")))
                dteEnd.DateTime = dteStart.DateTime;
        }

        private void dteEnd_EditValueChanged(object sender, EventArgs e)
        {
            if (int.Parse(dteStart.DateTime.ToString("yyyyMMdd")) > int.Parse(dteEnd.DateTime.ToString("yyyyMMdd")))
                dteStart.DateTime = dteEnd.DateTime;
        }

     
    }
}
