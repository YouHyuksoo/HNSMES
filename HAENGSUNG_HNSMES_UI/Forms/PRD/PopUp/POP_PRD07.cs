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
    public partial class POP_PRD07 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form
    {
        #region [Form Event]

        public POP_PRD07()
        {
            InitializeComponent();
        }

        public POP_PRD07(string p_sItemCode, string p_sBCDLOT, string p_sStrmin, string p_sEndmin) : this()
        {
            this.GetGridViewList(p_sItemCode, p_sBCDLOT, p_sStrmin, p_sEndmin);
        }

        #endregion

        #region [Button Event]

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region [Control Event]

        private void GetGridViewList(string p_sItemCode, string p_sBCDLOT, string p_sStrmin, string p_sEndmin)
        {
            BASE_DXGridHelper.Bind_Grid(gcList,
                                         "PKGPRD_REPORT.GET_LOTREVERSE"
                                         , 1
                                         , new string[] { "A_ITEMCODE", "A_BCDLOT", "A_STRMIN", "A_ENDMIN" }
                                         , new string[] { p_sItemCode, p_sBCDLOT, p_sStrmin, p_sEndmin }
                                         , false);

            gvList.BeginUpdate();
            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitMaxRowCount = 10;
            gvList.BestFitColumns();
            gvList.EndUpdate();
            //DateTime _date = DateTime.Now;
            //WSResults _result = BASE_db.Execute_Proc("PKGPRD_REPORT.GET_LOTREVERSE"
            //                                         , 1
            //                                         , new string[] { "A_ITEMCODE", "A_BCDLOT" }
            //                                         , new string[] { p_sItemCode, p_sBCDLOT }
            //                                        );

            //DateTime _datetemp = DateTime.Now;
            //if (_result.ResultInt == 0)
            //{
            //    treList.Columns.Clear();

            //    DataTable dTable = _result.ResultDataSet.Tables[0];

            //    for (int nCol = 0; nCol < dTable.Columns.Count; nCol++)
            //    {
            //        treList.Columns.Add();
            //        treList.Columns[nCol].FieldName = dTable.Columns[nCol].ColumnName;
            //        treList.Columns[nCol].Caption = base.BASE_Language.GetMessageString(dTable.Columns[nCol].ColumnName);

            //        if (treList.Columns[nCol].FieldName == "PARENT_RN" || treList.Columns[nCol].FieldName == "RN")
            //            treList.Columns[nCol].Visible = false;
            //        else
            //            treList.Columns[nCol].Visible = true;

            //        if (treList.Columns[nCol].FieldName.IndexOf("QTY") >= 0)
            //        {
            //            treList.Columns[nCol].Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            //            treList.Columns[nCol].Format.FormatString = "n0";
            //        }
            //    }

            //    treList.DataSource = dTable;
                
            //    treList.OptionsPrint.PrintTree = true;
            //    treList.OptionsBehavior.Editable = false;
            //    treList.OptionsView.AutoWidth = true;
                
            //    treList.BeginUpdate();
            //    //treList.BestFitColumns();
            //    treList.ExpandAll();
            //    treList.EndUpdate();
            //}
        }

        #endregion

        
    }
}
