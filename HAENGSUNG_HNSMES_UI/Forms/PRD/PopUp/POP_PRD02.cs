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

namespace HAENGSUNG_HNSMES_UI.Forms.PRD.PopUp
{
    // 주기검사, 장착 조치내역 등록

    public partial class POP_PRD02 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form
    {
        public string mAction = "";
        DataTable mTable = null;

        #region [Form Event]

        public POP_PRD02(DataTable dTable)
        {
            InitializeComponent();

            mTable = dTable;
        }
        private void POP_PRD02_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void POP_PRD02_Shown(object sender, EventArgs e)
        {
        }

        #endregion

        #region [Control Event]

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (memAction.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_COMM_028", this.Text, 3);
                memAction.Focus();
                return;
            }

            mAction = memAction.EditValue.ObjectNullString();
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

        private void InitForm()
        {
            BASE_DXGridHelper.Bind_Grid_RT(gcList,
                                            mTable.Copy());

            //gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();
        }
        
        #endregion
                
    }
}
