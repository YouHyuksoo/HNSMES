using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// DevExpress namespace
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views;

// User namespace
using HAENGSUNG_HNSMES_UI.Class;
using GridAlias = DevExpress.XtraGrid.Views.Grid;
using HAENGSUNG_HNSMES_UI.WebService.Access;

namespace HAENGSUNG_HNSMES_UI.Forms.PRD.PopUp
{
    public partial class POP_PRD08 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfScanner
    {
        public POP_PRD08()
        {
            InitializeComponent();
        }

        public POP_PRD08(string p_sMsg) : this()
        {
            lblMsg.Text = p_sMsg;
        }

        #region Scan Event

        public void Data_Scan(string sType, string sData)
        {
            ProcessScanEvent(sData);
        }

        public void Data_SubScan(string sType, string sData)
        {
            ProcessScanEvent(sData);
        }

        private void ProcessScanEvent(string sData)
        {
            if (sData == "ENTER")
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        #endregion

        
    }
}
