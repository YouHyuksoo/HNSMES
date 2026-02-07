using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Threading.Tasks;

using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

using ECM.WCFClient;
using NGS.WCFClient.DatabaseService;
using HAENGSUNG_HNSMES_UI.WebService.Access;

namespace HAENGSUNG_HNSMES_UI.Class
{
    class DXGridLookUpHelper
    {
        private delegate void BindControlEventHandler(GridControl _Grid, BaseEdit BaseCon, string bindTag);
        private delegate void GridColumnAddEventHandler(GridControl _Grid, DataTable _DataTable, bool _Summary, bool _GroupSummary, string _DisplayColumns, int i, string[] _DPCols, DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpiChkEdit);
        HAENGSUNG_HNSMES_UI.WebService.Business.IDatabaseProcess _DB = null;

        public DXGridLookUpHelper(HAENGSUNG_HNSMES_UI.WebService.Business.IDatabaseProcess iDB)
        {
            _DB = iDB;
        }

        #region [Public Method]

        /// <summary>                                                                                                                                                                                                          
        /// lookupedit 설정
        /// </summary>                                                                                                                                                                                                         
        public void Bind_GridLookUpEdit(GridLookUpEdit p_gle, DataTable dTable, string p_strValueMemeber, string p_strDisplayMember, string p_strVisibleColumns)
        {
            DataRow dr = dTable.NewRow();
            dTable.Rows.InsertAt(dr, 0);
            dTable.AcceptChanges();

            p_gle.Properties.View.Columns.Clear();
            p_gle.Properties.DataSource = dTable;
            p_gle.Properties.DisplayMember = p_strDisplayMember;
            p_gle.Properties.ValueMember = p_strValueMemeber;

            if (p_strVisibleColumns != "")
            {
                string[] _Cols = p_strVisibleColumns.Trim().Split(',');

                for (int i = 0; i < dTable.Columns.Count; i++)
                {
                    DevExpress.XtraGrid.Columns.GridColumn gcCol = p_gle.Properties.View.Columns.AddField(dTable.Columns[i].ColumnName);

                    for (int j = 0; j < _Cols.Length; j++)
                    {
                        if (_Cols[j].Trim() == gcCol.FieldName)
                        {
                            p_gle.Properties.View.Columns[i].Visible = true;
                            break;
                        }
                        else
                        {
                            p_gle.Properties.View.Columns[i].Visible = false;
                        }
                    }
                    ////lock (p_gle)
                    //{

                    //    DevExpress.XtraGrid.Columns.GridColumn gcCol = p_gle.Properties.View.Columns.AddField(dTable.Columns[i].ColumnName);
                    //    if ((p_strVisibleColumns.IndexOf(dTable.Columns[i].ColumnName + ",") > -1) ||
                    //        (p_strVisibleColumns.IndexOf(dTable.Columns[i].ColumnName + " ") > -1))
                    //        p_gle.Properties.View.Columns[i].Visible = true;
                    //    else
                    //        p_gle.Properties.View.Columns[i].Visible = false;
                    //}
                }
            }

            p_gle.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            p_gle.Properties.View.OptionsView.ColumnAutoWidth = false;
            p_gle.Properties.View.BestFitColumns();
        }

        /// <summary> 
        /// 2016-04-20 데이터 테이블 신규 Row 추가 여부 확인 Flag 파라메타(p_bRowAddFlag) 추가 by.HS
        /// lookupedit 설정
        /// </summary>                                                                                                                                                                                                         
        public void Bind_GridLookUpEdit(GridLookUpEdit p_gle, DataTable dTable, string p_strValueMemeber, string p_strDisplayMember, string p_strVisibleColumns, bool p_bRowAddFlag)
        {
            if (p_bRowAddFlag)
            {
                DataRow dr = dTable.NewRow();
                dTable.Rows.InsertAt(dr, 0);
                dTable.AcceptChanges();
            }

            p_gle.Properties.View.Columns.Clear();
            p_gle.Properties.DataSource = dTable;
            p_gle.Properties.DisplayMember = p_strDisplayMember;
            p_gle.Properties.ValueMember = p_strValueMemeber;

            if (p_strVisibleColumns != "")
            {
                string[] _Cols = p_strVisibleColumns.Trim().Split(',');

                for (int i = 0; i < dTable.Columns.Count; i++)
                {
                    DevExpress.XtraGrid.Columns.GridColumn gcCol = p_gle.Properties.View.Columns.AddField(dTable.Columns[i].ColumnName);

                    for (int j = 0; j < _Cols.Length; j++)
                    {
                        if (_Cols[j].Trim() == gcCol.FieldName)
                        {
                            p_gle.Properties.View.Columns[i].Visible = true;
                            break;
                        }
                        else
                        {
                            p_gle.Properties.View.Columns[i].Visible = false;
                        }
                    }
                    ////lock (p_gle)
                    //{

                    //    DevExpress.XtraGrid.Columns.GridColumn gcCol = p_gle.Properties.View.Columns.AddField(dTable.Columns[i].ColumnName);
                    //    if ((p_strVisibleColumns.IndexOf(dTable.Columns[i].ColumnName + ",") > -1) ||
                    //        (p_strVisibleColumns.IndexOf(dTable.Columns[i].ColumnName + " ") > -1))
                    //        p_gle.Properties.View.Columns[i].Visible = true;
                    //    else
                    //        p_gle.Properties.View.Columns[i].Visible = false;
                    //}
                }
            }

            p_gle.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            p_gle.Properties.View.OptionsView.ColumnAutoWidth = false;
            p_gle.Properties.View.BestFitColumns();
        }

        /// <summary>                                                                                                                                                                                                          
        /// lookupedit 설정
        /// </summary>                                                                                                                                                                                                         
        public void Bind_GridLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit p_gle, DataTable dTable, string p_strValueMemeber, string p_strDisplayMember, string p_strVisibleColumns)
        {
            DataRow dr = dTable.NewRow();
            dTable.Rows.InsertAt(dr, 0);
            dTable.AcceptChanges();

            p_gle.View.Columns.Clear();
            p_gle.DataSource = dTable;
            p_gle.DisplayMember = p_strDisplayMember;
            p_gle.ValueMember = p_strValueMemeber;

            if (p_strVisibleColumns != "")
            {
                for (int i = 0; i < dTable.Columns.Count; i++)
                {
                    {
                        p_gle.View.Columns.AddField(dTable.Columns[i].ColumnName);
                        if ((p_strVisibleColumns.IndexOf(dTable.Columns[i].ColumnName + ",") > -1) ||
                            (p_strVisibleColumns.IndexOf(dTable.Columns[i].ColumnName + " ") > -1))
                            p_gle.View.Columns[i].Visible = true;
                        else
                            p_gle.View.Columns[i].Visible = false;
                    }
                }
            }
            p_gle.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            p_gle.View.OptionsView.ColumnAutoWidth = false;
            p_gle.View.BestFitColumns();
        }

        /// <summary>                                                                                                                                                                                                          
        /// lookupedit 설정
        /// </summary>                                                                                                                                                                                                         
        public void Bind_GridLookUpEdit(GridLookUpEdit p_gle, string p_strProc, int p_intProcSeq, string[] p_arrParams, string[] p_arrValues, string p_strValueMemeber, string p_strDisplayMember, string p_strVisibleColumns)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();

            Parallel.For(0, p_arrParams.Length, i =>
            {
                lock (param)
                {
                    param.Add(p_arrParams[i], p_arrValues[i]);
                }
            });

            WSResults result = _DB.Execute_Proc(p_strProc, p_intProcSeq, param);

            // result.ReturnInt == 0이면 올바르게 데이터를 받음                                                                                                                                                                
            if (result.ResultInt == 0)
            {
                DataRow dr = result.ResultDataSet.Tables[0].NewRow();
                result.ResultDataSet.Tables[0].Rows.InsertAt(dr, 0);
                result.ResultDataSet.Tables[0].AcceptChanges();

                p_gle.Properties.View.Columns.Clear();
                p_gle.Properties.DataSource = null;
                p_gle.Properties.DataSource = result.ResultDataSet.Tables[0];
                p_gle.Properties.DisplayMember = p_strDisplayMember;
                p_gle.Properties.ValueMember = p_strValueMemeber;



                if (p_strVisibleColumns != "")
                {
                    string[] _Cols = p_strVisibleColumns.Trim().Split(',');

                    for (int i = 0; i < result.ResultDataSet.Tables[0].Columns.Count; i++)
                    {
                        DevExpress.XtraGrid.Columns.GridColumn gcCol = p_gle.Properties.View.Columns.AddField(result.ResultDataSet.Tables[0].Columns[i].ColumnName);

                        for (int j = 0; j < _Cols.Length; j++)
                        {
                            if (_Cols[j].Trim() == gcCol.FieldName)
                            {
                                p_gle.Properties.View.Columns[i].Visible = true;
                                break;
                            }
                            else
                            {
                                p_gle.Properties.View.Columns[i].Visible = false;
                            }
                        }
                    }
                    //lock (result)
                    //{

                    //    for (int i = 0; i < result.ResultDataSet.Tables[0].Columns.Count; i++)
                    //    {
                    //        DevExpress.XtraGrid.Columns.GridColumn gcCol = p_gle.Properties.View.Columns.AddField(result.ResultDataSet.Tables[0].Columns[i].ColumnName);
                    //        if ((p_strVisibleColumns.IndexOf(result.ResultDataSet.Tables[0].Columns[i].ColumnName + ",") > -1) ||
                    //                        (p_strVisibleColumns.IndexOf(result.ResultDataSet.Tables[0].Columns[i].ColumnName) > -1))
                    //        {
                    //            {
                    //                p_gle.Properties.View.Columns[i].Visible = true;
                    //            }
                    //        }
                    //        else
                    //        {
                    //            //lock (p_gle.Properties.View)
                    //            {
                    //                p_gle.Properties.View.Columns[i].Visible = false;
                    //            }
                    //        }
                    //    }
                    //}
                }
                p_gle.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                p_gle.Properties.View.OptionsView.ColumnAutoWidth = false;
                p_gle.Properties.View.BestFitColumns();
            }
            else
            {
                iDATMessageBox.ShowProcResultMessage(result, "Error", Global.Global_Variable.USER_ID, p_strProc, param);
            }
        }

        /// <summary>                                                                                                                                                                                                          
        /// lookupedit 설정
        /// </summary>                                                                                                                                                                                                         
        public string Bind_GridLookUpEdit_RtnStr(GridLookUpEdit p_gle, string p_strProc, int p_intProcSeq, string[] p_arrParams, string[] p_arrValues, string p_strValueMemeber, string p_strDisplayMember, string p_strVisibleColumns)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();

            Parallel.For(0, p_arrParams.Length, i =>
            {
                lock (param)
                {
                    param.Add(p_arrParams[i], p_arrValues[i]);
                }
            });

            WSResults result = _DB.Execute_Proc(p_strProc, p_intProcSeq, param);

            // result.ReturnInt == 0이면 올바르게 데이터를 받음                                                                                                                                                                
            if (result.ResultInt == 0)
            {
                DataRow dr = result.ResultDataSet.Tables[0].NewRow();
                result.ResultDataSet.Tables[0].Rows.InsertAt(dr, 0);
                result.ResultDataSet.Tables[0].AcceptChanges();

                p_gle.Properties.View.Columns.Clear();
                p_gle.Properties.DataSource = null;
                p_gle.Properties.DataSource = result.ResultDataSet.Tables[0];
                p_gle.Properties.DisplayMember = p_strDisplayMember;
                p_gle.Properties.ValueMember = p_strValueMemeber;



                if (p_strVisibleColumns != "")
                {
                    string[] _Cols = p_strVisibleColumns.Trim().Split(',');

                    for (int i = 0; i < result.ResultDataSet.Tables[0].Columns.Count; i++)
                    {
                        DevExpress.XtraGrid.Columns.GridColumn gcCol = p_gle.Properties.View.Columns.AddField(result.ResultDataSet.Tables[0].Columns[i].ColumnName);

                        for (int j = 0; j < _Cols.Length; j++)
                        {
                            if (_Cols[j].Trim() == gcCol.FieldName)
                            {
                                p_gle.Properties.View.Columns[i].Visible = true;
                                break;
                            }
                            else
                            {
                                p_gle.Properties.View.Columns[i].Visible = false;
                            }
                        }
                    }
                    //lock (result)
                    //{

                    //    for (int i = 0; i < result.ResultDataSet.Tables[0].Columns.Count; i++)
                    //    {
                    //        DevExpress.XtraGrid.Columns.GridColumn gcCol = p_gle.Properties.View.Columns.AddField(result.ResultDataSet.Tables[0].Columns[i].ColumnName);
                    //        if ((p_strVisibleColumns.IndexOf(result.ResultDataSet.Tables[0].Columns[i].ColumnName + ",") > -1) ||
                    //                        (p_strVisibleColumns.IndexOf(result.ResultDataSet.Tables[0].Columns[i].ColumnName) > -1))
                    //        {
                    //            {
                    //                p_gle.Properties.View.Columns[i].Visible = true;
                    //            }
                    //        }
                    //        else
                    //        {
                    //            //lock (p_gle.Properties.View)
                    //            {
                    //                p_gle.Properties.View.Columns[i].Visible = false;
                    //            }
                    //        }
                    //    }
                    //}
                }
                p_gle.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                p_gle.Properties.View.OptionsView.ColumnAutoWidth = false;
                p_gle.Properties.View.BestFitColumns();
                return result.ResultString;
            }
            else
            {
                iDATMessageBox.ShowProcResultMessage(result, "Error", Global.Global_Variable.USER_ID, p_strProc, param);
                return null;
            }
        }


        public void Bind_Repository_GridLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit p_gle, string p_strProc, int p_intProcSeq, string[] p_arrParams, string[] p_arrValues, string p_strValueMemeber, string p_strDisplayMember, string p_strVisibleColumns, bool p_blnFilterRow)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();

            Parallel.For(0, p_arrParams.Length, i =>
            //for (int i = 0; i < p_arrParams.Length; i++)
            {
                lock (param)
                {
                    param.Add(p_arrParams[i], p_arrValues[i]);
                }
            });

            WSResults result = _DB.Execute_Proc(p_strProc, p_intProcSeq, param);

            // result.ReturnInt == 0이면 올바르게 데이터를 받음                                                                                                                                                                
            if (result.ResultInt == 0)
            {
                DataRow dr = result.ResultDataSet.Tables[0].NewRow();
                result.ResultDataSet.Tables[0].Rows.InsertAt(dr, 0);
                result.ResultDataSet.Tables[0].AcceptChanges();

                //p_gle.BeginUpdate();
                p_gle.View.Columns.Clear();
                p_gle.DataSource = result.ResultDataSet.Tables[0];
                p_gle.DisplayMember = p_strDisplayMember;
                p_gle.ValueMember = p_strValueMemeber;
                p_gle.View.OptionsView.ShowAutoFilterRow = p_blnFilterRow;

                if (p_strVisibleColumns != "")
                {
                    string[] _Cols = p_strVisibleColumns.Trim().Split(',');

                    for (int i = 0; i < result.ResultDataSet.Tables[0].Columns.Count; i++)
                    {
                        DevExpress.XtraGrid.Columns.GridColumn gcCol = p_gle.View.Columns.AddField(result.ResultDataSet.Tables[0].Columns[i].ColumnName);

                        for (int j = 0; j < _Cols.Length; j++)
                        {
                            if (_Cols[j].Trim() == gcCol.FieldName)
                            {
                                p_gle.View.Columns[i].Visible = true;

                                LanguageInformation clsLan = new LanguageInformation();
                                string sLanMsg = clsLan.GetMessageString(gcCol.FieldName);
                                p_gle.View.Columns[i].Caption = sLanMsg;
                                break;
                            }
                            else
                            {
                                p_gle.View.Columns[i].Visible = false;
                            }
                        }
                    }
                }
                //if (p_strVisibleColumns != "")
                //{
                //    //Parallel.For(0, result.ReturnDataSet.Tables[0].Columns.Count, i =>
                //    for (int i = 0; i < result.ResultDataSet.Tables[0].Columns.Count; i++)
                //    {
                //        //lock (p_gle)
                //        {
                //            DevExpress.XtraGrid.Columns.GridColumn gcCol = p_gle.View.Columns.AddField(result.ResultDataSet.Tables[0].Columns[i].ColumnName);
                //            if ((p_strVisibleColumns.IndexOf(result.ResultDataSet.Tables[0].Columns[i].ColumnName + ",") > -1) ||
                //                (p_strVisibleColumns.IndexOf(result.ResultDataSet.Tables[0].Columns[i].ColumnName + " ") > -1))
                //                p_gle.View.Columns[i].Visible = true;
                //            else
                //                p_gle.View.Columns[i].Visible = false;
                //        }
                //    }
                //}
                p_gle.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                p_gle.View.OptionsView.ColumnAutoWidth = false;
                p_gle.View.BestFitColumns();
                //p_gle.EndUpdate();
            }
            else
            {
                iDATMessageBox.ShowProcResultMessage(result, "Error", Global.Global_Variable.USER_ID, p_strProc, param);
            }
        }

        public void Bind_Repository_GridLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit p_gle, DataTable dt, string p_strValueMemeber, string p_strDisplayMember, string p_strVisibleColumns, bool p_blnFilterRow)
        {
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            dt.AcceptChanges();

            //p_gle.BeginUpdate();
            p_gle.View.Columns.Clear();
            p_gle.DataSource = dt;
            p_gle.DisplayMember = p_strDisplayMember;
            p_gle.ValueMember = p_strValueMemeber;
            p_gle.View.OptionsView.ShowAutoFilterRow = p_blnFilterRow;

            if (p_strVisibleColumns != "")
            {
                string[] _Cols = p_strVisibleColumns.Trim().Split(',');

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    DevExpress.XtraGrid.Columns.GridColumn gcCol = p_gle.View.Columns.AddField(dt.Columns[i].ColumnName);

                    for (int j = 0; j < _Cols.Length; j++)
                    {
                        if (_Cols[j].Trim() == gcCol.FieldName)
                        {
                            p_gle.View.Columns[i].Visible = true;

                            LanguageInformation clsLan = new LanguageInformation();
                            string sLanMsg = clsLan.GetMessageString(gcCol.FieldName);
                            p_gle.View.Columns[i].Caption = sLanMsg;
                            break;
                        }
                        else
                        {
                            p_gle.View.Columns[i].Visible = false;
                        }
                    }
                }
            }

            //if (p_strVisibleColumns != "")
            //{
            //    //Parallel.For(0, dt.Columns.Count, i =>
            //    for (int i = 0; i < dt.Columns.Count; i++)
            //    {
            //        //lock (p_gle)
            //        {
            //            DevExpress.XtraGrid.Columns.GridColumn gcCol = p_gle.View.Columns.AddField(dt.Columns[i].ColumnName);
            //            if ((p_strVisibleColumns.IndexOf(dt.Columns[i].ColumnName + ",") > -1) ||
            //                (p_strVisibleColumns.IndexOf(dt.Columns[i].ColumnName + "") > -1))
            //                p_gle.View.Columns[i].Visible = true;
            //            else
            //                p_gle.View.Columns[i].Visible = false;
            //        }
            //    }
            //}
            p_gle.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            p_gle.View.OptionsView.ColumnAutoWidth = false;
            p_gle.View.BestFitColumns();
            //p_gle.EndUpdate();
        }


        /// <summary>                                                                                                                                                                                                          
        /// lookupedit 설정
        /// </summary>                                                                                                                                                                                                         
        public void Bind_GridLookUpEdit(GridLookUpEdit gridLookUpCon, string proc, int procSeq, string[] sParams, string[] Values, string ValueMemeber, string DisplayMember)
        {
            this.Bind_GridLookUpEdit(gridLookUpCon, proc, procSeq, sParams, Values, ValueMemeber, DisplayMember, "");
        }

        /// <summary>                                                                                                                                                                                                          
        /// RepositoryItemGridLookUpEdit 설정
        /// </summary>
        public void Bind_GridLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit gridLookUpCon, string proc, int procSeq, string[] sParams, string[] Values, string ValueMemeber, string DisplayMember, string strVisibleColumns)//string[] visibleColumn)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();

            Parallel.For(0, sParams.Length, i =>
            //for (int i = 0; i < sParams.Length; i++)
            {
                lock (param)
                {
                    param.Add(sParams[i], Values[i]);
                }
            });

            WSResults result = _DB.Execute_Proc(proc, procSeq, param);

            // result.ReturnInt == 0이면 올바르게 데이터를 받음
            if (result.ResultInt == 0)
            {
                DataRow dr = result.ResultDataSet.Tables[0].NewRow();
                result.ResultDataSet.Tables[0].Rows.InsertAt(dr, 0);
                result.ResultDataSet.Tables[0].AcceptChanges();
                // GridLookUp 바인딩
                gridLookUpCon.View.Columns.Clear();
                gridLookUpCon.DataSource = result.ResultDataSet.Tables[0];
                gridLookUpCon.DisplayMember = DisplayMember;
                gridLookUpCon.ValueMember = ValueMemeber;
                gridLookUpCon.View.FocusedRowHandle = 0;
                //Parallel.For(0, gridLookUpCon.View.Columns.Count, i =>
                for (int i = 0; i < gridLookUpCon.View.Columns.Count; i++)
                {
                    //lock (gridLookUpCon)
                    {
                        if ((strVisibleColumns.IndexOf(gridLookUpCon.View.Columns[i].Caption + ",") > -1) ||
                            (strVisibleColumns.IndexOf(gridLookUpCon.View.Columns[i].Caption + " ") > -1))
                            gridLookUpCon.View.Columns[i].Visible = true;
                        else
                            gridLookUpCon.View.Columns[i].Visible = false;
                    }
                }
                gridLookUpCon.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                gridLookUpCon.View.OptionsView.ColumnAutoWidth = false;
                gridLookUpCon.View.BestFitColumns();
            }
            else
            {
                iDATMessageBox.ShowProcResultMessage(result, "Error", Global.Global_Variable.USER_ID, proc, param);
            }
        }

        #endregion
    }
}
