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
    // LED 생산계획 등록

    public partial class POP_PRD04 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form
    {
        DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit rglLine = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
        //DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit rglTable = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
        DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit rglPartNo = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
        DevExpress.XtraEditors.Repository.RepositoryItemComboBox rcbRank = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
        DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rspQty = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
        bool mbSave = false;

        DataTable mdTable = new DataTable();

        #region [Form Event]

        public POP_PRD04()
        {
            InitializeComponent();
        }
        private void POP_PRD04_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void POP_PRD04_Shown(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }

        #endregion

        #region [Control Event]
       
        private void speModelChTime_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            for (int nRow = 0; nRow < gvLOT.RowCount; nRow++)
                gvLOT.SetRowCellValue(nRow, "PLANENDTIME", null);
        }

        private void speOrdQty_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            gcLOT.DataSource = null;
            gcTable.DataSource = null;
            mdTable.Clear();
        }                

        private void gvList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            InitItem();

            if (gvList.RowCount > 0 && gvList.FocusedRowHandle >= 0 && gvList.FocusedRowHandle < gvList.RowCount)
            {
                txtVendor.EditValue = gvList.GetRowCellValue(gvList.FocusedRowHandle, "VENDORNAME").ObjectNullString();
                txtVendor.Tag = gvList.GetRowCellValue(gvList.FocusedRowHandle, "VENDOR").ObjectNullString();
                txtModel.EditValue = gvList.GetRowCellValue(gvList.FocusedRowHandle, "MODEL").ObjectNullString();
                txtModel.Tag = gvList.GetRowCellValue(gvList.FocusedRowHandle, "ITEMCODE").ObjectNullString();

                txtRank1.EditValue = gvList.GetRowCellValue(gvList.FocusedRowHandle, "RANK1").ObjectNullString();
                txtRank2.EditValue = gvList.GetRowCellValue(gvList.FocusedRowHandle, "RANK2").ObjectNullString();
                txtRank3.EditValue = gvList.GetRowCellValue(gvList.FocusedRowHandle, "RANK3").ObjectNullString();
                txtRank4.EditValue = gvList.GetRowCellValue(gvList.FocusedRowHandle, "RANK4").ObjectNullString();
                txtCrtValue.EditValue = gvList.GetRowCellValue(gvList.FocusedRowHandle, "CRTVALUE").ObjectNullString();
                txtMarking.EditValue = gvList.GetRowCellValue(gvList.FocusedRowHandle, "MARKING").ObjectNullString();

                GetSide(gvList.GetRowCellValue(gvList.FocusedRowHandle, "PRODUCTIONTYPE").ObjectNullString());

                if (gvList.GetRowCellValue(gvList.FocusedRowHandle, "PRODUCTIONTYPE").ObjectNullString() == "1")
                {
                    gleSide.Properties.ReadOnly = false;
                    gleSide.EditValue = "";

                    lciTotTopOrdQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lciTotBotOrdQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lciOneSideOrdQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                    lciTopRemainQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lciBotRemainQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lciOneSideRemainQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                else if (gvList.GetRowCellValue(gvList.FocusedRowHandle, "PRODUCTIONTYPE").ObjectNullString() == "2")
                {
                    gleSide.Properties.ReadOnly = true;
                    gleSide.EditValue = "D";

                    lciTotTopOrdQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lciTotBotOrdQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lciOneSideOrdQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                    lciTopRemainQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lciBotRemainQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lciOneSideRemainQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                else
                {
                    gleSide.Properties.ReadOnly = true;
                    gleSide.EditValue = "N";

                    lciTotTopOrdQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciTotBotOrdQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciOneSideOrdQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                    lciTopRemainQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciBotRemainQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciOneSideRemainQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }

                txtTotPlanQty.EditValue = int.Parse(gvList.GetRowCellValue(gvList.FocusedRowHandle, "TOTPLANQTY").ObjectNullString());
                txtTotTopOrdQty.EditValue = int.Parse(gvList.GetRowCellValue(gvList.FocusedRowHandle, "TOTTOPORDQTY").ObjectNullString());
                txtTotBotOrdQty.EditValue = int.Parse(gvList.GetRowCellValue(gvList.FocusedRowHandle, "TOTBOTORDQTY").ObjectNullString());
                txtOneSideOrdQty.EditValue = int.Parse(gvList.GetRowCellValue(gvList.FocusedRowHandle, "TOTORDQTY").ObjectNullString());
                txtTopRemainQty.EditValue = int.Parse(gvList.GetRowCellValue(gvList.FocusedRowHandle, "TOPREMAINQTY").ObjectNullString());
                txtBotRemainQty.EditValue = int.Parse(gvList.GetRowCellValue(gvList.FocusedRowHandle, "BOTREMAINQTY").ObjectNullString());
                txtOneSideRemainQty.EditValue = int.Parse(gvList.GetRowCellValue(gvList.FocusedRowHandle, "REMAINQTY").ObjectNullString());
                speArray.EditValue = gvList.GetRowCellValue(gvList.FocusedRowHandle, "ARRAYQTY").ObjectNullString();

                rcbRank.Items.Clear();
                rcbRank.Items.Add("");
                rcbRank.Items.Add(txtRank1.EditValue.ObjectNullString());

                if (txtRank2.EditValue.ObjectNullString() != "NONE")
                    rcbRank.Items.Add(txtRank2.EditValue.ObjectNullString());

                if (txtRank3.EditValue.ObjectNullString() != "NONE")
                    rcbRank.Items.Add(txtRank3.EditValue.ObjectNullString());

                if (txtRank4.EditValue.ObjectNullString() != "NONE")
                    rcbRank.Items.Add(txtRank4.EditValue.ObjectNullString());

                if (gvList.GetRowCellValue(gvList.FocusedRowHandle, "RANK1").ObjectNullString() == "NONE")
                {
                    lciRank1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciRank2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                else
                {
                    lciRank1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lciRank2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
            }
        }
              
        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetCustPlan();
        }

        private void speOrdQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                GetTempLOT();
        }        

        private void btnTimeSearch_Click(object sender, EventArgs e)
        {
            if (!InputChk(false))
                return;


            for (int nRow = 0; nRow < gvLOT.RowCount; nRow++)
            {
                try
                {
                    DateTime.Parse(gvLOT.GetRowCellValue(nRow, "PLANSTARTTIME").ObjectNullString() + ":00");
                }
                catch (Exception ex)
                {
                    iDATMessageBox.WARNINGMessage(ex.Message, this.Text, 3);
                    return;
                }

                // 프로시져 수행
                HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = BASE_db.Execute_Proc("PKGPRD_SMT.GET_ESTIMATED_ENDTIME",
                                                                                    1,
                                                                                    new string[] { "A_PLANT",
                                                                                                   "A_VENDOR",
                                                                                                   "A_LINE",
                                                                                                   "A_MODEL",
                                                                                                   "A_SIDE",
                                                                                                   "A_MODELCHANGETIME",
                                                                                                   "A_ARRAY",
                                                                                                   "A_PLANQTY",
                                                                                                   "A_STARTDATETIME" },
                                                                                    new string[] { HAENGSUNG_HNSMES_UI.Global.Global_Variable.PLANT,
                                                                                                   txtVendor.Tag.ObjectNullString(),
                                                                                                   gvLOT.GetRowCellValue(nRow , "PRODLINE").ObjectNullString(),
                                                                                                   txtModel.Tag.ObjectNullString(),
                                                                                                   gleSide.EditValue.ObjectNullString(),
                                                                                                   gvLOT.GetRowCellValue(nRow , "MDLCHGTIME").ObjectNullString(),
                                                                                                   speArray.EditValue.ObjectNullString(),
                                                                                                   gvLOT.GetRowCellValue(nRow , "QTY").ObjectNullString(),
                                                                                                   gvLOT.GetRowCellValue(nRow , "PLANSTARTTIME").ObjectNullString().Replace("-","").Replace(":","").Replace(" ","") });

                if (_Result.ResultInt == 0)
                {
                    gvLOT.SetRowCellValue(nRow, "PLANENDTIME", _Result.ResultString);
                    gvList.OptionsView.ColumnAutoWidth = false;
                    gvList.BestFitColumns();
                }
                else
                {
                    iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
                    return;
                }
            }            
        }


        private void btnMarkingSearch_Click(object sender, EventArgs e)
        {
            if (!InputChk(false))
                return;


            for (int nRow = 0; nRow < gvLOT.RowCount; nRow++)
            {
                // 프로시져 수행
                HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = BASE_db.Execute_Proc("PKGPRD_SMT.GET_LEDMARKING",
                                                                                    1,
                                                                                    new string[] { "A_PLANT",
                                                                                                   "A_MODELITEM",
                                                                                                   "A_RANK",
                                                                                                   "A_LEDMAKER",
                                                                                                   "A_SMTDATE",
                                                                                                   "A_SMTMAKER",
                                                                                                   "A_PCBMAKER",
                                                                                                   "A_LOTQTY",
                                                                                                   "A_LOTSEQ" },
                                                                                    new string[] { HAENGSUNG_HNSMES_UI.Global.Global_Variable.PLANT,
                                                                                                   txtModel.Tag.ObjectNullString(),
                                                                                                   txtRank1.EditValue.ObjectNullString(),
                                                                                                   gleLedPkgMaker.EditValue.ObjectNullString(),
                                                                                                   gvLOT.GetRowCellValue(nRow , "PLANSTARTTIME").ObjectNullString().Replace("-","").Replace(":","").Replace(" ","").Substring(0,8),
                                                                                                   gleSmtMaker.EditValue.ObjectNullString(),
                                                                                                   glePcbMaker.EditValue.ObjectNullString(),
                                                                                                   gvLOT.GetRowCellValue(nRow , "QTY").ObjectNullString(),
                                                                                                   gvLOT.GetRowCellValue(nRow , "LOT").ObjectNullString() });

                if (_Result.ResultInt == 0)
                {
                    gvLOT.SetRowCellValue(nRow, "MARKING1", _Result.ResultDataSet.Tables[0].Rows[0]["MARKING1"]);
                    gvLOT.SetRowCellValue(nRow, "MARKING2", _Result.ResultDataSet.Tables[0].Rows[0]["MARKING2"]);
                    gvLOT.SetRowCellValue(nRow, "MARKING3", _Result.ResultDataSet.Tables[0].Rows[0]["MARKING3"]);
                }
                else             
                    iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
            }

            gvLOT.BestFitColumns();
        }


        private void gvLOT_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "PRODLINE")
            {
                if (e.Value.ObjectNullString() != "")
                    GetModelChangeTime(e.Value.ObjectNullString());
                
                GetTable(e.Value.ObjectNullString());
            }
            else if (e.Column.FieldName == "PLANSTARTTIME")
                gvLOT.SetRowCellValue(gvLOT.FocusedRowHandle, "PLANENDTIME", null);
        }
              

        private void gvLOT_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvLOT.RowCount > 0 && e.FocusedRowHandle >= 0 && e.FocusedRowHandle < gvLOT.RowCount)
            {
                GetTable(gvLOT.GetRowCellValue(e.FocusedRowHandle, "PRODLINE").ObjectNullString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!InputChk(true))
                return;

            SavePlan();
        }       

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (mbSave)
                DialogResult = System.Windows.Forms.DialogResult.OK;
            else
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void gvLOT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.V))
            {
                string _Clip = Clipboard.GetText();
                string[] _Rows = _Clip.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                int nRow = 0;

                foreach (string _Row in _Rows)
                {
                    int nCol = 1;
                    foreach (string _Col in _Row.Split((char)9))
                    {
                        gvLOT.SetRowCellValue(nRow, "MARKING" + nCol, _Col);
                        nCol++;
                    }

                    nRow++;
                }

                Clipboard.Clear();
            }
        }

        private void gvTable_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "PARTNO")
            {
                if (e.Value.ObjectNullString() == "")
                {
                    gvTable.SetRowCellValue(e.RowHandle, "RANK", "");
                    gvTable.SetRowCellValue(e.RowHandle, "REELCNT", 0);
                    gvTable.SetRowCellValue(e.RowHandle, "BM", "");
                }
                else
                {
                    if (txtRank2.EditValue.ObjectNullString() == "NONE")
                    {
                        gvTable.SetRowCellValue(e.RowHandle, "RANK", txtRank1.EditValue.ObjectNullString());
                        gvTable.SetRowCellValue(e.RowHandle, "BM", "B");
                    }
                    else
                    {
                        if (int.Parse(gvTable.GetRowCellValue(e.RowHandle, "EQPTABLENO").ObjectNullString().Split('-')[0]) % 2 == 1)
                        {
                            gvTable.SetRowCellValue(e.RowHandle, "RANK", txtRank1.EditValue.ObjectNullString());
                            gvTable.SetRowCellValue(e.RowHandle, "BM", "B");
                        }
                        else
                        {
                            gvTable.SetRowCellValue(e.RowHandle, "RANK", txtRank2.EditValue.ObjectNullString());
                            gvTable.SetRowCellValue(e.RowHandle, "BM", "M");
                        }
                    }
                }
            }

            if (e.Column.FieldName == "RANK")
            {
                if (e.Value.ObjectNullString() == "")
                {
                    gvTable.SetRowCellValue(e.RowHandle, "BM", "");
                }
                else
                {
                    if (e.Value.ObjectNullString() == txtRank1.EditValue.ObjectNullString())
                    {
                        gvTable.SetRowCellValue(e.RowHandle, "BM", "B");
                    }
                    else
                    {
                        gvTable.SetRowCellValue(e.RowHandle, "BM", "M");                      
                    }
                }
            }


            if (mdTable.Rows.Count > 0)
            {
                DataRow[] dRowList;
                dRowList = mdTable.Select(string.Format("LOT = '{0}' AND PRODLINE = '{1}'", gvTable.GetRowCellValue(e.RowHandle,"LOT"),
                                                                                            gvTable.GetRowCellValue(e.RowHandle, "PRODLINE")));

                if (dRowList.Length > 0)
                {
                    for (int nCol = 0; nCol < gvTable.Columns.Count; nCol++)
                        dRowList[e.RowHandle][nCol] = gvTable.GetRowCellValue(e.RowHandle, gvTable.Columns[nCol]);

                    dRowList[e.RowHandle][e.Column.FieldName] = e.Value;
                }
            }
        }

        #endregion

        #region [Private Method]

        private void InitForm()
        {
            rglLine.NullText = "";
            rglPartNo.NullText = "";
            rspQty.EditMask = "N00";
            rcbRank.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            gvLOT.OptionsView.ShowAutoFilterRow = false;
            gvTable.OptionsView.ShowAutoFilterRow = false;

            GetLine();
            GetMaker();
            //GetTable();
            gvLOT.OptionsFilter.AllowFilterEditor = false;
        }


        private void GetLine()
        {
            BASE_DXGridLookUpHelper.Bind_Repository_GridLookUpEdit(rglLine,
                                                                   "PKGPRD_SMT.GET_LINE2",
                                                                   1,
                                                                   new string[] { "A_PLANT",
                                                                                  "A_TYPE" },
                                                                   new string[] { Global.Global_Variable.PLANT,
                                                                                  "LED" },
                                                                   "PRODLINE",
                                                                   "PRODLINENAME",
                                                                   "PRODLINENAME",
                                                                   false);
        }


        private void GetSide(string sType)
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleSide,
                                                        "PKGPRD_SMT.GET_SIDE",
                                                        1,
                                                        new string[] { "A_TYPE" },
                                                        new string[] { sType },
                                                        "CODE",
                                                        "CODENAME",
                                                        "CODE,CODENAME,REMARKS");
        }


        private void GetMaker()
        {
            // 프로시져 수행
            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = BASE_db.Execute_Proc("PKGPRD_SMT.GET_MAKER",
                                                                                1,
                                                                                new string[] { "A_PLANT" },
                                                                                new string[] { Global.Global_Variable.PLANT });

            if (_Result.ResultInt == 0)
            {
                BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(glePcbMaker,
                                                            _Result.ResultDataSet.Tables[0],
                                                            "MAKER",
                                                            "MAKERNAME",
                                                            "MAKER,MAKERNAME");

                if (_Result.ResultDataSet.Tables[0].Rows.Count > 2)
                    glePcbMaker.EditValue = _Result.ResultDataSet.Tables[0].Rows[1]["MAKER"];


                BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleLedPkgMaker,
                                                            _Result.ResultDataSet.Tables[1],
                                                            "MAKER",
                                                            "MAKERNAME",
                                                            "MAKER,MAKERNAME");

                if (_Result.ResultDataSet.Tables[1].Rows.Count > 2)
                    gleLedPkgMaker.EditValue = _Result.ResultDataSet.Tables[1].Rows[1]["MAKER"];


                BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleSmtMaker,
                                                            _Result.ResultDataSet.Tables[2],
                                                            "MAKER",
                                                            "MAKERNAME",
                                                            "MAKER,MAKERNAME");

                if (_Result.ResultDataSet.Tables[2].Rows.Count > 2)
                    gleSmtMaker.EditValue = _Result.ResultDataSet.Tables[2].Rows[1]["MAKER"];

                
            }           
            else
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
        }


        //private void DelTable()
        //{
        //    if (mdTable.Rows.Count > 0)
        //    {               
        //        // delete
        //        for (int nRow = 0; nRow < mdTable.Rows.Count; nRow++)
        //        {
        //            if (mdTable.Rows[nRow]["LOT"].ObjectNullString() == gvLOT.GetRowCellValue(gvLOT.FocusedRowHandle, "LOT").ObjectNullString())
        //            {
        //                mdTable.Rows[nRow].Delete();
        //                nRow = 0;
        //            }
        //        }
        //    }
        //}


        private void GetTable(string sLine)
        {
            string sLot = gvLOT.GetRowCellValue(gvLOT.FocusedRowHandle, "LOT").ObjectNullString();

            if (mdTable.Rows.Count == 0)
            {
                BASE_DXGridHelper.Bind_Grid(gcTable,
                                            "PKGPRD_SMT.GET_TABLE",
                                            1,
                                            new string[] { "A_PLANT",
                                                            "A_LOT",
                                                            "A_LINE" },
                                            new string[] { Global.Global_Variable.PLANT,
                                                            gvLOT.GetRowCellValue(gvLOT.FocusedRowHandle, "LOT").ObjectNullString(),
                                                            sLine },
                                            false,
                                            "LOT,PRODLINE,TABLENO",
                                            false);
                
                 mdTable = (gcTable.DataSource as DataTable).Copy();                   

                //gvTable.Columns["PARTNO"].ColumnEdit = rglPartNo;
                //gvTable.Columns["RANK"].ColumnEdit = rcbRank;
                //gvTable.Columns["REELCNT"].ColumnEdit = rspQty;

                //gvTable.OptionsBehavior.Editable = true;
                //gvTable.Columns["PARTNO"].OptionsColumn.AllowEdit = true;
                //gvTable.Columns["RANK"].OptionsColumn.AllowEdit = true;
                //gvTable.Columns["REELCNT"].OptionsColumn.AllowEdit = true;

                //gvTable.OptionsView.ColumnAutoWidth = false;
                //gvTable.BestFitColumns();

                //gvTable.Columns["PARTNO"].Width = 130;
                //gvTable.Columns["RANK"].Width = 80;
            }
            else
            {
                DataRow[] dRowList;
                dRowList = mdTable.Select(string.Format("LOT = '{0}' AND PRODLINE = '{1}'", sLot, sLine));

                if (dRowList.Length == 0)
                {
                    // delete
                    for (int nRow = 0; nRow < mdTable.Rows.Count; nRow++)
                    {
                        if (mdTable.Rows[nRow]["LOT"].ObjectNullString() == sLot)
                        {
                            mdTable.Rows[nRow].Delete();
                            nRow = 0;
                        }
                    }

                    BASE_DXGridHelper.Bind_Grid(gcTable,
                                                "PKGPRD_SMT.GET_TABLE",
                                                1,
                                                new string[] { "A_PLANT",
                                                               "A_LOT",
                                                               "A_LINE" },
                                                new string[] { Global.Global_Variable.PLANT,
                                                               gvLOT.GetRowCellValue(gvLOT.FocusedRowHandle, "LOT").ObjectNullString(),
                                                               sLine },
                                                false,
                                                "LOT,PRODLINE,TABLENO",
                                                false);
                    
                    for (int nRow = 0; nRow < gvTable.RowCount; nRow++)
                    {
                        DataRow dRow = mdTable.NewRow();

                        for (int nCol = 0; nCol < gvTable.Columns.Count; nCol++)
                            dRow[nCol] = gvTable.GetRowCellValue(nRow, gvTable.Columns[nCol].FieldName);

                        mdTable.Rows.Add(dRow);
                    }
                }
                else
                {
                    DataTable dTable = mdTable.Copy();
                    dTable.Clear();

                    for (int nRow = 0; nRow < dRowList.Length; nRow++)
                    {
                        DataRow dRow = dTable.NewRow();

                        for (int nCol = 0; nCol < mdTable.Columns.Count; nCol++)
                            dRow[nCol] = dRowList[nRow][nCol];

                        dTable.Rows.Add(dRow);
                    }

                    BASE_DXGridHelper.Bind_Grid(gcTable,
                                                dTable,
                                                false,
                                                "LOT,PRODLINE,TABLENO",
                                                false);
                }                
            }

            gvTable.Columns["PARTNO"].ColumnEdit = rglPartNo;
            gvTable.Columns["RANK"].ColumnEdit = rcbRank;
            gvTable.Columns["REELCNT"].ColumnEdit = rspQty;

            gvTable.OptionsBehavior.Editable = true;
            gvTable.Columns["PARTNO"].OptionsColumn.AllowEdit = true;
            gvTable.Columns["RANK"].OptionsColumn.AllowEdit = true;
            gvTable.Columns["REELCNT"].OptionsColumn.AllowEdit = true;

            gvTable.OptionsView.ColumnAutoWidth = false;
            gvTable.BestFitColumns();

            gvTable.Columns["PARTNO"].Width = 130;
            gvTable.Columns["RANK"].Width = 80;
        }


        //private void SetTable(int nPrevFocusedRow)
        //{
        //    try
        //    {

        //        DataRow[] dRowList;
        //        dRowList = mdTable.Select(string.Format("LOT = '{0}'", gvLOT.GetRowCellValue(nPrevFocusedRow, "LOT").ObjectNullString()));

        //        //if (dRowList.Length > 0)
        //        //{
        //        //    for (int nRow = 0; nRow < gvTable.RowCount; nRow++)
        //        //    {
        //        //        for (int nCol = 0; nCol < gvTable.Columns.Count; nCol++)
        //        //            dRowList[nRow][nCol] = gvTable.GetRowCellValue(nRow, gvTable.Columns[nCol].FieldName);
        //        //    }
        //        //}
        //        //else
        //        //{
        //        //    for (int nRow = 0; nRow < gvTable.RowCount; nRow++)
        //        //    {
        //        //        DataRow dRow = mdTable.NewRow();

        //        //        for (int nCol = 0; nCol < gvTable.Columns.Count; nCol++)
        //        //            dRow[nCol] = gvTable.GetRowCellValue(nRow, gvTable.Columns[nCol].FieldName);

        //        //        mdTable.Rows.Add(dRow);
        //        //    }                    
        //        //}

        //        if (dRowList.Length > 0)
        //        {
        //            // delete
        //            for (int nRow = 0; nRow < mdTable.Rows.Count; nRow++)
        //            {
        //                if (mdTable.Rows[nRow]["LOT"].ObjectNullString() == gvLOT.GetRowCellValue(nPrevFocusedRow, "LOT").ObjectNullString())
        //                {
        //                    mdTable.Rows[nRow].Delete();
        //                    nRow = -1;
        //                }                        
        //            }
        //        }


        //        // insert
        //        for (int nRow = 0; nRow < gvTable.RowCount; nRow++)
        //        {
        //            DataRow dRow = mdTable.NewRow();

        //            for (int nCol = 0; nCol < gvTable.Columns.Count; nCol++)
        //                dRow[nCol] = gvTable.GetRowCellValue(nRow, gvTable.Columns[nCol].FieldName);

        //            mdTable.Rows.Add(dRow);
        //        }                    


        //        if (nPrevFocusedRow == gvLOT.FocusedRowHandle)
        //            return;

        //        DataTable _dt = (gcTable.DataSource as DataTable).Copy();
        //        _dt.Clear();
        //        gcTable.DataSource = null;

        //        //dRowList = mdTable.Select(string.Format("LOT = '{0}' AND PRODLINE = '{1}'", gvLOT.GetRowCellValue(gvLOT.FocusedRowHandle, "LOT").ObjectNullString(), gvLOT.GetRowCellValue(gvLOT.FocusedRowHandle, "PRODLINE").ObjectNullString()));
        //        dRowList = mdTable.Select(string.Format("LOT = '{0}'", gvLOT.GetRowCellValue(gvLOT.FocusedRowHandle, "LOT").ObjectNullString()));

        //        if (dRowList.Length > 0)
        //        {
        //            foreach (DataRow _dr in dRowList)
        //            {
        //                DataRow dRow = _dt.NewRow();

        //                for (int nCol = 0; nCol < _dt.Columns.Count; nCol++)
        //                    dRow[nCol] = _dr[nCol];

        //                _dt.Rows.Add(dRow);
        //            }

        //            BASE_DXGridHelper.Bind_Grid(gcTable,
        //                                        _dt,
        //                                        false,
        //                                        "LOT,PRODLINE,TABLENO",
        //                                        false);

        //            gvTable.Columns["PARTNO"].ColumnEdit = rglPartNo;
        //            gvTable.Columns["RANK"].ColumnEdit = rcbRank;
        //            gvTable.Columns["REELCNT"].ColumnEdit = rspQty;

        //            gvTable.OptionsBehavior.Editable = true;
        //            gvTable.Columns["PARTNO"].OptionsColumn.AllowEdit = true;
        //            gvTable.Columns["RANK"].OptionsColumn.AllowEdit = true;
        //            gvTable.Columns["REELCNT"].OptionsColumn.AllowEdit = true;

        //            gvTable.OptionsView.ColumnAutoWidth = false;
        //            gvTable.BestFitColumns();

        //            gvTable.Columns["PARTNO"].Width = 130;
        //            gvTable.Columns["RANK"].Width = 80;
        //        }
        //        else
        //            GetTable(gvLOT.GetRowCellValue(gvLOT.FocusedRowHandle, "PRODLINE").ObjectNullString());
        //    }
        //    catch (Exception ex)
        //    {
        //        iDATMessageBox.ErrorMessage(ex.Message, this.Text, 3);
        //    }
        //}


        private void GetModelChangeTime(string sLine)
        {
            gvLOT.SetRowCellValue(gvLOT.FocusedRowHandle, "PLANENDTIME", null);

            // 프로시져 수행
            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = BASE_db.Execute_Proc("PKGPRD_SMT.GET_MODELCHANGEST",
                                                                                1,
                                                                                new string[] { "A_PLANT",
                                                                                               "A_LINE",
                                                                                               "A_MODEL",
                                                                                               "A_SIDE" },
                                                                                new string[] { HAENGSUNG_HNSMES_UI.Global.Global_Variable.PLANT,
                                                                                               sLine,
                                                                                               txtModel.Tag.ObjectNullString(),
                                                                                               gleSide.EditValue.ObjectNullString() });

            if (_Result.ResultInt == 0)
                gvLOT.SetRowCellValue(gvLOT.FocusedRowHandle, "MDLCHGTIME", _Result.ResultDataSet.Tables[0].Rows[0]["MODELCHANGETIME"]);
            else
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
        }


        //private void GetPlanTime()
        //{
        //    // 프로시져 수행
        //    HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = BASE_db.Execute_Proc("PKGPRD_SMT.GET_ESTIMATED_STARTENDTIME",
        //                                                                        1,
        //                                                                        new string[] { "A_PLANT",
        //                                                                                       "A_LINE",
        //                                                                                       "A_MODEL",
        //                                                                                       "A_MODELCHANGETIME",
        //                                                                                       "A_ARRAY",
        //                                                                                       "A_PLANQTY"},
        //                                                                        new string[] { HAENGSUNG_HNSMES_UI.Global.Global_Variable.PLANT,
        //                                                                                       gvList.GetRowCellValue(gvLOT.FocusedRowHandle, "PRODLINE").ObjectNullString(),
        //                                                                                       txtModel.Tag.ObjectNullString(),
        //                                                                                       gvList.GetRowCellValue(gvLOT.FocusedRowHandle, "MDLCHGTIME").ObjectNullString(),
        //                                                                                       speArray.EditValue.ObjectNullString(),
        //                                                                                       gvList.GetRowCellValue(gvLOT.FocusedRowHandle, "QTY").ObjectNullString()
        //                                                                                       });

        //    if (_Result.ResultInt == 0)
        //    {
        //        gvLOT.Columns["PLANSTARTTIME"].OptionsColumn.AllowEdit = false;
        //        gvLOT.SetRowCellValue(gvLOT.FocusedRowHandle, "PLANSTARTTIME", DateTime.Parse(_Result.ResultDataSet.Tables[0].Rows[0]["PLANSTARTTIME"].ObjectNullString()));
        //        gvLOT.SetRowCellValue(gvLOT.FocusedRowHandle, "PLANENDTIME", DateTime.Parse(_Result.ResultDataSet.Tables[0].Rows[0]["PLANENDTIME"].ObjectNullString()));
        //    }
        //    else if (_Result.ResultInt == 1)
        //    {
        //        gvLOT.Columns["PLANSTARTTIME"].OptionsColumn.AllowEdit = true;
        //        gvLOT.SetRowCellValue(gvLOT.FocusedRowHandle, "PLANSTARTTIME", DateTime.Parse(_Result.ResultDataSet.Tables[0].Rows[0]["PLANSTARTTIME"].ObjectNullString()));
        //        gvLOT.SetRowCellValue(gvLOT.FocusedRowHandle, "PLANENDTIME", DateTime.Parse(_Result.ResultDataSet.Tables[0].Rows[0]["PLANENDTIME"].ObjectNullString()));
        //        //gvLOT.SetRowCellValue(gvLOT.FocusedRowHandle, "PLANENDTIME", null);
        //    }
        //    else
        //        iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
        //}

        private void InitItem()
        {
            txtVendor.EditValue = null;
            txtModel.EditValue = null;
            txtRank1.EditValue = null;
            txtRank2.EditValue = null;
            txtRank3.EditValue = null;
            txtRank4.EditValue = null;
            txtCrtValue.EditValue = null;
            txtMarking.EditValue = null;
            txtTotPlanQty.EditValue = null;         
            txtOneSideOrdQty.EditValue = null;         
            txtOneSideRemainQty.EditValue = null;
            gleSide.EditValue = null;
            speArray.EditValue = 1;
            speOrdQty.EditValue = 0;
            gcLOT.DataSource = null;
            gcTable.DataSource = null;
            mdTable.Clear();
        }

        private bool InputChk(bool bSave)
        {
            if (txtVendor.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_WO_011", this.Text, 3);
                return false;
            }

            if (gleSide.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_WO_014", this.Text, 3);
                gleSide.Focus();
                return false;
            }

            if (speArray.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_WO_024", this.Text, 3);
                speArray.Focus();
                return false;
            }

            if (int.Parse(speArray.EditValue.ObjectNullString()) < 1)
            {
                iDATMessageBox.ErrorMessage("MSG_ER_COMM_001", this.Text, 3);
                speArray.Focus();
                return false;
            }

            if (speOrdQty.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_WO_013", this.Text, 3);
                speOrdQty.Focus();
                return false;
            }

            if (int.Parse(speOrdQty.EditValue.ObjectNullString()) < 1)
            {
                iDATMessageBox.ErrorMessage("MSG_ER_COMM_001", this.Text, 3);
                speOrdQty.Focus();
                return false;
            }


            int nRemainQty;

            if (gleSide.EditValue.ObjectNullString() == "T")
                nRemainQty = int.Parse(txtTopRemainQty.EditValue.ObjectNullString());
            else if (gleSide.EditValue.ObjectNullString() == "B")
                nRemainQty = int.Parse(txtBotRemainQty.EditValue.ObjectNullString());
            else if (gleSide.EditValue.ObjectNullString() == "N")
                nRemainQty = int.Parse(txtOneSideRemainQty.EditValue.ObjectNullString());
            else
            {
                if (int.Parse(txtTopRemainQty.EditValue.ObjectNullString()) > int.Parse(txtBotRemainQty.EditValue.ObjectNullString()))
                    nRemainQty = int.Parse(txtBotRemainQty.EditValue.ObjectNullString());
                else
                    nRemainQty = int.Parse(txtTopRemainQty.EditValue.ObjectNullString());
            }

            if (nRemainQty < int.Parse(speOrdQty.EditValue.ObjectNullString()))
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_COMM_038", this.Text, 3);
                speOrdQty.Focus();
                return false;
            }


            for (int nRow = 0; nRow < gvLOT.RowCount; nRow++)
            {
                if (gvLOT.GetRowCellValue(nRow, "PRODLINE").ObjectNullString() == "")
                {
                    iDATMessageBox.WARNINGMessage("MSG_ER_LINE_004", this.Text, 3);
                    return false;
                }


                if (gvLOT.GetRowCellValue(nRow, "MDLCHGTIME").ObjectNullString() == "")
                {
                    iDATMessageBox.ErrorMessage("MSG_ER_WO_025", this.Text, 3);
                    return false;
                }                

                if (bSave)
                {
                    if (gvLOT.GetRowCellValue(nRow, "PLANENDTIME").ObjectNullString() == "")
                    {
                        iDATMessageBox.ErrorMessage("MSG_ER_WO_015", this.Text, 3);
                        btnTimeSearch.Focus();
                        return false;
                    }
                }
            }

            if (bSave)
            {
                if (glePcbMaker.EditValue.ObjectNullString() == "")
                {
                    iDATMessageBox.ErrorMessage("MSG_ER_WO_026", this.Text, 3);
                    glePcbMaker.Focus();
                    return false;
                }

                if (gleLedPkgMaker.EditValue.ObjectNullString() == "")
                {
                    iDATMessageBox.ErrorMessage("MSG_ER_WO_028", this.Text, 3);
                    gleLedPkgMaker.Focus();
                    return false;
                }

                if (gleSmtMaker.EditValue.ObjectNullString() == "")
                {
                    iDATMessageBox.ErrorMessage("MSG_ER_WO_029", this.Text, 3);
                    gleSmtMaker.Focus();
                    return false;
                }

                bool bChkRank1 = false;
                bool bChkRank2 = false;
                bool bChkRank3 = false;
                bool bChkRank4 = false;

                if (txtRank2.Text == "NONE" || txtRank2.Text == "")
                    bChkRank2 = true;

                if (txtRank3.Text == "NONE" || txtRank3.Text == "")
                    bChkRank3 = true;

                if (txtRank4.Text == "NONE" || txtRank4.Text == "")
                    bChkRank4 = true;

                for (int nRow = 0; nRow < gvTable.RowCount; nRow++)
                {
                    if (gvTable.GetRowCellValue(nRow, "RANK").ObjectNullString() == txtRank1.Text)
                        bChkRank1 = true;

                    if (gvTable.GetRowCellValue(nRow, "RANK").ObjectNullString() == txtRank2.Text)
                        bChkRank2 = true;

                    if (gvTable.GetRowCellValue(nRow, "RANK").ObjectNullString() == txtRank3.Text)
                        bChkRank3 = true;

                    if (gvTable.GetRowCellValue(nRow, "RANK").ObjectNullString() == txtRank4.Text)
                        bChkRank4 = true;
                }

                if (!bChkRank1 || !bChkRank2 || !bChkRank3 || !bChkRank4)
                {
                    iDATMessageBox.ErrorMessage("MSG_ER_WO_030", this.Text, 3);
                    return false;
                }           
            }
            
            return true;
        }

        private void GetCustPlan()
        {
            int nRow = gvList.FocusedRowHandle;

            BASE_DXGridHelper.Bind_Grid(gcList,
                                        "PKGPRD_SMT.GET_CUSTOMPLAN",
                                        1,
                                        new string[] { "A_TYPE"},
                                        new string[] { "LED"},
                                        false,
                                        "VENDOR,ITEMCODE,TOTORDQTY,REMAINQTY,ARRAYQTY,TOTTOPORDQTY,TOTBOTORDQTY,TOPREMAINQTY,BOTREMAINQTY,PRODUCTIONTYPE",
                                        false);

            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();

            if (nRow == 0)
                gvList_FocusedRowChanged(null, null);
        }


        private void GetTempLOT()
        {
            if (!InputChk(false))
                return;

            gcTable.DataSource = null;
            mdTable.Clear();

            // 프로시져 수행
            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = BASE_db.Execute_Proc("PKGPRD_SMT.GET_TEMPLOT",
                                                                               1,
                                                                                new string[] { "A_MODEL",
                                                                                               "A_QTY" },
                                                                                new string[] { txtModel.Tag.ObjectNullString(),
                                                                                               speOrdQty.EditValue.ObjectNullString() });

            if (_Result.ResultInt == 0)
            {
                BASE_DXGridHelper.Bind_Grid(gcLOT,
                                            _Result.ResultDataSet.Tables[0],
                                            false);
                //gvLOT.SetRowCellValue(nRow, "PLANENDTIME", _Result.ResultString);
                //for (int nRow = 0; nRow < gvLOT.RowCount; nRow++)
                //    gvLOT.SetRowCellValue(nRow, "PLANSTARTTIME", DateTime.Parse(gvLOT.GetRowCellValue(nRow, "PLANSTARTTIME").ObjectNullString()));

                gvLOT.Columns["PRODLINE"].ColumnEdit = rglLine;
                gvLOT.Columns["MDLCHGTIME"].ColumnEdit = rspQty;
                //gvLOT.Columns["PLANSTARTTIME"].ColumnEdit = rteTime;
                //gvLOT.Columns["PLANENDTIME"].ColumnEdit = rteTime;

                gvLOT.OptionsBehavior.Editable = true;
                gvLOT.Columns["PRODLINE"].OptionsColumn.AllowEdit = true;
                gvLOT.Columns["MDLCHGTIME"].OptionsColumn.AllowEdit = true;
                gvLOT.Columns["PLANSTARTTIME"].OptionsColumn.AllowEdit = true;
                gvLOT.Columns["MARKING1"].OptionsColumn.AllowEdit = false;
                gvLOT.Columns["MARKING2"].OptionsColumn.AllowEdit = false;
                gvLOT.Columns["MARKING3"].OptionsColumn.AllowEdit = false;

                gvLOT.OptionsView.ColumnAutoWidth = false;
                gvLOT.BestFitColumns();

                BASE_DXGridLookUpHelper.Bind_Repository_GridLookUpEdit(rglPartNo,
                                                                       _Result.ResultDataSet.Tables[1],
                                                                       "ITEMCODE",
                                                                       "PARTNO",
                                                                       "PARTNO",
                                                                       false);
            }
            else            
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
        }

        private void SavePlan()
        {
            //SetTable(gvLOT.FocusedRowHandle);

            //if (gvTable.RowCount > 0)
            //{
            //    for (int nRow = 0; nRow < (gvTable.DataSource as DataTable).Rows.Count; nRow++)
            //    {
            //        for (int nCol = 0; nCol < (gvTable.DataSource as DataTable).Columns.Count; nCol++)
            //        {
            //            if ((gvTable.DataSource as DataTable).Rows[nRow][nCol] == mdTable.Rows[nRow][nCol])
            //                mdTable.Rows[nRow][nCol] = (gvTable.DataSource as DataTable).Rows[nRow][nCol];
            //        }
            //    }
            //}

            string sLotXml = GetDataTableToXml(gcLOT.DataSource as DataTable);
            string sTableXml = GetDataTableToXml(mdTable);

            // 프로시져 수행
            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = BASE_db.Execute_Proc("PKGPRD_SMT.SET_WOLED",
                                                                                1,
                                                                                new string[] { "A_PLANT",
                                                                                               "A_VENDOR",
                                                                                               "A_MODELITEM",
                                                                                               "A_SIDE",
                                                                                               "A_RANK1",
                                                                                               "A_RANK2",
                                                                                               "A_RANK3",
                                                                                               "A_RANK4",
                                                                                               "A_PCBMAKER",
                                                                                               "A_LEDPKGMAKER",
                                                                                               "A_SMTMAKER",
                                                                                               "A_ARRAY",
                                                                                               "A_ORDQTY",
                                                                                               "A_CRTVALUE",
                                                                                               "A_MARKING",
                                                                                               "A_LOTXML",
                                                                                               "A_TABLEXML",
                                                                                               "A_USER" },
                                                                                new string[] { Global.Global_Variable.PLANT,
                                                                                               txtVendor.Tag.ObjectNullString(),
                                                                                               txtModel.Tag.ObjectNullString(),
                                                                                               gleSide.EditValue.ObjectNullString(),
                                                                                               txtRank1.EditValue.ObjectNullString(),
                                                                                               txtRank2.EditValue.ObjectNullString(),
                                                                                               txtRank3.EditValue.ObjectNullString(),
                                                                                               txtRank4.EditValue.ObjectNullString(),
                                                                                               glePcbMaker.EditValue.ObjectNullString(),
                                                                                               gleLedPkgMaker.EditValue.ObjectNullString(),
                                                                                               gleSmtMaker.EditValue.ObjectNullString(),
                                                                                               speArray.EditValue.ObjectNullString(),
                                                                                               speOrdQty.EditValue.ObjectNullString(),
                                                                                               txtCrtValue.EditValue.ObjectNullString(),
                                                                                               txtMarking.EditValue.ObjectNullString(),
                                                                                               sLotXml,
                                                                                               sTableXml,
                                                                                               Global.Global_Variable.EHRCODE });

            if (_Result.ResultInt == 0)
            {
                mbSave = true;
                iDATMessageBox.OKMessage("MSG_OK_REG_001", this.Text, 3);

                //Print(_Result.ResultDataSet.Tables[0]);

                btnSearch_Click(null, null);
            }
            else
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
        }


        private void Print(DataTable dTable)
        {
            for (int nRow = 0; nRow < dTable.Rows.Count; nRow++)
            {
                //using (RPT.RPTC001 _rpt = new RPT.RPTC001(dTable.Rows[nRow]["LOT"].ObjectNullString(), dTable.Rows[nRow]["PRODLINE"].ObjectNullString()))
                //{
                //    //_rpt.PrintingSystem.PageSettings.Landscape = true;
                //    _rpt.Landscape = true;
                //    _rpt.RptPrint();
                //}
            }
        }


        #endregion                
    }
}
