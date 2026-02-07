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

namespace HAENGSUNG_HNSMES_UI.Forms.MAT.PopUp
{
    // 자재진도 모니터링에서 출고 등록

    public partial class POP_MAT01 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form
    {
        public string mSN = "";
        DataTable mTable;

        #region [Form Event]

        public POP_MAT01(DataTable dTable)
        {
            InitializeComponent();

            mTable = dTable;
        }
        private void POP_MAT01_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void POP_MAT01_Shown(object sender, EventArgs e)
        {
        }

        #endregion
        

        #region [Control Event]

        private void txtSN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSave_Click(null, null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSN.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_COMM_008", this.Text, 3);
                txtSN.Focus();
                return;
            }

            mSN = txtSN.EditValue.ObjectNullString();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
       

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        #endregion

        #region [Private Method]

        public string SN
        {
            set
            { 
                txtSN.Text = value;
                btnSave_Click(null, null);
            }
        }

        private void InitForm()
        {
            BASE_DXGridHelper.Bind_Grid_RT(gcList,
                                            mTable.Copy());
        }
        
        #endregion
    }
}
