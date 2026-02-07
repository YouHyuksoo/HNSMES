using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

using HAENGSUNG_HNSMES_UI.Class;
using HAENGSUNG_HNSMES_UI.WebService.Access;

using IDAT.Controls;
using ECM.WCFClient;
using NGS.WCFClient.DatabaseService;

namespace HAENGSUNG_HNSMES_UI.Forms.MST.PopUp
{
    public partial class MSTA206_PopUp2 : BASE.Form
    {
        RepositoryItemGridLookUpEdit gle = new RepositoryItemGridLookUpEdit();
        RepositoryItemComboBox cmb = new RepositoryItemComboBox();

        private MSTA206 mParent = null;

        public MSTA206 _ParentForm
        {
            get { return mParent; }
            set { mParent = value; }
        }

        public MSTA206_PopUp2()
        {
            InitializeComponent();
        }

        private void MSTA206_PopUp_Load(object sender, EventArgs e)
        {
            layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 58, 2);

            Set_Init();
            GetGridView();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            gvList.OptionsBehavior.Editable = true;
            gvList.EX_AddNewRow(new string[] { "USEFLAG" }, new object[] { "Y" });
            gvList.Columns["PARTNO"].ColumnEdit = gle;
            gvList.Columns["USEFLAG"].ColumnEdit = cmb;

            gvList.Columns["PARTNO"].OptionsColumn.AllowEdit = true;
            gvList.Columns["USEFLAG"].OptionsColumn.AllowEdit = true;
        }

        private void Set_Init()
        {
            cmb.Items.Clear();
            cmb.Items.Add("Y");
            cmb.Items.Add("N");
            cmb.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.True;

            BASE_DXGridLookUpHelper.Bind_Repository_GridLookUpEdit(
                                                           gle
                                                         , "PKGBAS_BASE.GET_ITEM"
                                                         , 2
                                                         , new string[] {
                                                                           "A_CLIENT"
                                                                         , "A_COMPANY"
                                                                         , "A_PLANT"
                                                                         , "A_VIEW"
                                                                         , "A_ITEMTYPE"
                                                                        }
                                                         , new string[] {
                                                                          Global.Global_Variable.CLIENT
                                                                        , Global.Global_Variable.COMPANY
                                                                        , Global.Global_Variable.PLANT
                                                                        , "0"
                                                                        , "3"
                                                                        }
                                                         , "PARTNO"
                                                         , "PARTNO"
                                                         , "PARTNO, ITEMNAME, SPEC "
                                                         , true
                                                       );
            gle.EditValueChanged += new EventHandler(gle_EditValueChanged);
            gle.View.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(View_FocusedRowChanged);
        }

        void gle_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        void View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //try
            //{
            //    gvList.SetRowCellValue(gvList.FocusedRowHandle, "SUBITEMCODE", gle.View.GetRowCellValue(e.FocusedRowHandle, "ITEMCODE"));
            //    gvList.SetRowCellValue(gvList.FocusedRowHandle, "SPEC", gle.View.GetRowCellValue(e.FocusedRowHandle, "SPEC"));
            //}
            //catch { }
        }

        private void GetGridView()
        {
            BASE_DXGridHelper.Bind_Grid(
                                         gcList
                                       , "PKGBAS_BASE.GET_SUBITEM"
                                       , 1
                                       , new string[] {
                                                        "A_CLIENT"
                                                      , "A_COMPANY"
                                                      , "A_PLANT"
                                                      , "A_IDX"
                                                      }
                                       , new string[] {
                                                        Global.Global_Variable.CLIENT
                                                      , Global.Global_Variable.COMPANY
                                                      , Global.Global_Variable.PLANT
                                                      , txtIdx.EditValue + ""
                                                      }
                                       , true
                                       , "PARTNO, SPEC, USEFLAG "
                                   );

            gvList.BestFitColumns();

            gvList.OptionsBehavior.Editable = true;
            gvList.Columns["USEFLAG"].OptionsColumn.AllowEdit = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            gvList.UpdateCurrentRow();

            DataTable dt = gvList.EX_GetChangedData();

            foreach (DataRow dr in dt.Rows)
            {
                BASE_db.Execute_Proc("PKGBAS_BASE.PUT_SUBITEM", 1,
                                            new string[] {
                                                           "A_CLIENT"
                                                         , "A_COMPANY"
                                                         , "A_PLANT"
                                                         , "A_IDX"
                                                         , "A_PARTNO"
                                                         , "A_SEQ"
                                                         , "A_USEFLAG"
                                                         , "A_USERID"
                                                         },
                                            new string[] {
                                                           Global.Global_Variable.CLIENT
                                                         , Global.Global_Variable.COMPANY
                                                         , Global.Global_Variable.PLANT
                                                         , txtIdx.EditValue.ObjectNullString()
                                                         , dr["PARTNO"].ObjectNullString()
                                                         , txtSeq.EditValue.ObjectNullString()
                                                         , dr["USEFLAG"].ObjectNullString()
                                                         , Global.Global_Variable.EHRCODE
                                            }, false);
            }

            GetGridView();
        }

        private void gvList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
        }
    }
}