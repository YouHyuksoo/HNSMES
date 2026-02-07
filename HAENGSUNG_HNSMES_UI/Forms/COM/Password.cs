using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HAENGSUNG_HNSMES_UI.Forms.COM
{
    public partial class Password : BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfScanner
    {
        public Password()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtPassword.EditValue + "" == "hseth2019")
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("try again Password!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        #region Scan Event
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
            if (sData == "hseth2019")
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("try again Password!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
            }

        }

        #endregion
    }
}