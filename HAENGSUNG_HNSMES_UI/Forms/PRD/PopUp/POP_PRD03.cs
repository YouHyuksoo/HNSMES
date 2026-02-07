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
    // 생산계획 수량수정

    public partial class POP_PRD03 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form
    {
        public string mQty = "";
        DataTable mTable = null;

        #region [Form Event]

        public POP_PRD03(DataTable dTable)
        {
            InitializeComponent();

            mTable = dTable;
        }
        private void POP_PRD03_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void POP_PRD03_Shown(object sender, EventArgs e)
        {
        }

        #endregion

        #region [Control Event]

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (speQty.EditValue.ObjectNullString() == "" || speQty.EditValue.ObjectNullString() == "0" || int.Parse(speQty.EditValue.ObjectNullString()) < 0)
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_WO_013", this.Text, 3);
                speQty.Focus();
                return;
            }

            mQty = speQty.EditValue.ObjectNullString();
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
