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

using DevExpress.XtraGrid.Views.Card;

using HAENGSUNG_HNSMES_UI.Forms.COM;
using DevExpress.XtraSplashScreen;

namespace HAENGSUNG_HNSMES_UI.Class
{
    class DXGridHelper
    {
        private delegate void BindControlEventHandler(GridControl _Grid, BaseEdit BaseCon, string bindTag);
        private delegate void GridColumnAddEventHandler(GridControl _Grid, DataTable _DataTable, bool _Summary, bool _GroupSummary, string _DisplayColumns, string _ColumnName, string[] _Cols, bool _ColVisible, DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpiChkEdit);
        private delegate void CardColumnAddEventHandler(GridControl _Grid, DataTable _DataTable, string _DisplayColumns, int i, string[] _Cols, bool _ColVisible, DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpiChkEdit);
        HAENGSUNG_HNSMES_UI.WebService.Business.IDatabaseProcess _DB = null;

        public DXGridHelper(HAENGSUNG_HNSMES_UI.WebService.Business.IDatabaseProcess iDB)
        {
            _DB = iDB;
        }

        #region [Private Method]

        private void BindControlEvent(GridControl _Grid, BaseEdit BaseCon, string bindTag)
        {
            try
            {
                if (BaseCon is IDAT.Devexpress.DXControl.IIDATDxControl)
                {
                    if (((IDAT.Devexpress.DXControl.IIDATDxControl)BaseCon).BindGridControl == null)
                    {
                        BaseCon.DataBindings.Add("EditValue", _Grid.DataSource, bindTag, false, DataSourceUpdateMode.OnValidation);
                    }
                    else
                    {
                        BaseCon.DataBindings.Add("EditValue", ((IDAT.Devexpress.DXControl.IIDATDxControl)BaseCon).BindGridControl.DataSource, bindTag, false, DataSourceUpdateMode.OnValidation);
                    }
                }
            }
            catch (Exception ex)
            {
                BaseCon.Text = ex.Message;
            }
        }

        private void Bind_GridAndFormFunc(GridControl _Grid, Control controls)
        {
            if (controls is BaseEdit && controls is IDAT.Devexpress.DXControl.IIDATDxControl)
            {
                if (((IDAT.Devexpress.DXControl.IIDATDxControl)controls).BindGridControl != null && ((IDAT.Devexpress.DXControl.IIDATDxControl)controls).BindGridControl.Name == _Grid.Name)
                {
                    BaseEdit baseCon = controls as BaseEdit;
                    
                    baseCon.DataBindings.Clear();
                    baseCon.EditValue = null;

                    if (((IDAT.Devexpress.DXControl.IIDATDxControl)baseCon).BindColumnName != "")
                    {
                        string bindTag = ((IDAT.Devexpress.DXControl.IIDATDxControl)baseCon).BindColumnName;

                        if (baseCon.InvokeRequired)
                        {
                            baseCon.Invoke(new BindControlEventHandler(BindControlEvent), _Grid, baseCon, bindTag);
                        }
                        else
                        {
                            BindControlEvent(_Grid, baseCon, bindTag);
                        }
                    }
                }
            }
        }

        private Control[] GetAllControls(Control containerControl)
        {
            List<Control> allControls = new List<Control>();
            Queue<Control.ControlCollection> queue = new Queue<Control.ControlCollection>();
            queue.Enqueue(containerControl.Controls);

            Task task = new Task(() =>
                {
                    while (queue.Count > 0)
                    {
                        Control.ControlCollection controls = (Control.ControlCollection)queue.Dequeue();
                        if (controls == null || controls.Count == 0) continue;

                        foreach (Control control in controls)
                        {
                            allControls.Add(control);
                            queue.Enqueue(control.Controls);
                        }
                    }
                });
            
            task.Start();
            task.Wait();

            return allControls.ToArray();
        }

        private void Bind_GridAndForm(GridControl _Grid, Control controls)
        {
            Control[] AllControls = GetAllControls(_Grid.FindForm());

            foreach (Control c in AllControls)
            {
                Bind_GridAndFormFunc(_Grid, c);
            }
        }

        private int GetIndex(string[] _Cols, string _FieldName)
        {
            int nIndex = -1;

            for (int i = 0; i < _Cols.Length; i++)
            {
                if (_Cols[i] == _FieldName)
                {
                    nIndex = i;
                    break;
                }
            }

            return nIndex;
        }


        private void CardColumnAddEvent(GridControl _Grid, DataTable _DataTable, string _DisplayColumns, int i, string[] _Cols, bool _ColVisible, DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpiChkEdit)
        {
            //lock (_Grid)
            {
                CardView view = _Grid.MainView as CardView;

                IDAT.Devexpress.GRID.IDATDevExpress_GridControl _clsDev = new IDAT.Devexpress.GRID.IDATDevExpress_GridControl();

                DataColumn dc = _DataTable.Columns[i];

                //gcs[i] = new GridColumn();
                
                GridColumn gc = view.Columns.AddField(dc.ColumnName);
                //gcs[i] = new GridColumn();
                gc.OptionsColumn.AllowEdit = false;
                gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                LanguageInformation clsLan = new LanguageInformation();
                gc.Caption = clsLan.GetMessageString(dc.ColumnName);
                gc.FieldName = dc.ColumnName;

                if (_DisplayColumns != "")
                {
                    int _Index = GetIndex(_Cols, gc.FieldName);

                    if (_Index > -1)
                    {
                        gc.VisibleIndex = _Index;
                        //gc.Visible = true;
                        gc.Visible = _ColVisible;
                    }
                    else
                        //gc.Visible = false;
                        gc.Visible = !_ColVisible;
                }
                else
                {
                    gc.VisibleIndex = i;
                    gc.Visible = true;
                }

                if (gc.FieldName.IndexOf("SEL") > -1)
                {
                    gc.OptionsColumn.AllowEdit = true;
                    gc.ColumnEdit = rpiChkEdit;
                }

                //if (gc.FieldName.IndexOf("USEFLAG") > -1)
                //{
                //    _clsDev.SetStyleFormatCondition(view, "USEFLAG", "N", null, true);
                //}
                //else
                //{
                //    //view.FormatConditions.Clear();
                //}
            }
        }


        private void GridColumnAddEvent(GridControl _Grid, DataTable _DataTable, bool _Summary, bool _GroupSummary, string _DisplayColumns, string _ColumnName, string[] _Cols, bool _ColVisible, DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpiChkEdit)
        {
            //lock (_Grid)
            {
                GridView view = _Grid.MainView as GridView;

                IDAT.Devexpress.GRID.IDATDevExpress_GridControl _clsDev = new IDAT.Devexpress.GRID.IDATDevExpress_GridControl();

                DataColumn dc = _DataTable.Columns[_ColumnName];

                if (dc == null) return;

                //gcs[i] = new GridColumn();
                GridColumn gc = view.Columns.AddField(dc.ColumnName);
                //gcs[i] = new GridColumn();
                gc.OptionsColumn.AllowEdit = false;
                gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                LanguageInformation clsLan = new LanguageInformation();
                gc.Caption = clsLan.GetMessageString(dc.ColumnName);
                gc.FieldName = dc.ColumnName;

                gc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

                if (_DisplayColumns != "")
                {
                    int _Index = GetIndex(_Cols, gc.FieldName);

                    if (_Index > -1)
                    {
                        gc.VisibleIndex = _Index;
                        //gc.Visible = true;
                        gc.Visible = _ColVisible;
                    }
                    else
                        //gc.Visible = false;
                        gc.Visible = !_ColVisible;
                }
                else
                {
                    //gc.VisibleIndex = i;
                    gc.Visible = true;
                }

                if (gc.FieldName.IndexOf("SEL") > -1)
                {
                    gc.OptionsColumn.AllowEdit = true;
                    gc.ColumnEdit = rpiChkEdit;
                }

                if (gc.FieldName.IndexOf("USEFLAG") > -1)
                {
                    _clsDev.SetStyleFormatCondition(view, "USEFLAG", "N", null, true);
                }
                else
                {
                    //view.FormatConditions.Clear();
                }
                switch (dc.DataType.ToString())
                {
                    case "System.Int32":
                        gc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        gc.DisplayFormat.FormatString = "{0:n0}";
                        break;
                    case "System.Decimal":
                        gc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        gc.DisplayFormat.FormatString = "{0:n2}";
                        break;
                    case "System.Double":
                        gc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        gc.DisplayFormat.FormatString = "{0:n0}";
                        break;
                }

                gc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                if (_Summary)
                {
                    switch (dc.DataType.ToString())
                    {
                        case "System.Int32":
                            gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                            gc.SummaryItem.DisplayFormat = "{0:n0}";
                            break;
                        case "System.Decimal":
                            gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                            gc.SummaryItem.DisplayFormat = "{0:n0}";
                            break;
                        case "System.Double":
                            gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                            gc.SummaryItem.DisplayFormat = "{0:n0}";
                            break;
                    }
                }

                if (_GroupSummary)
                {
                    if (dc.DataType.ToString() == "System.Int32")
                    {
                        view.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, gc.FieldName, gc, "{0:n0}");
                    }

                    if (dc.DataType.ToString() == "System.Decimal" || dc.DataType.ToString() == "System.Double")
                    {
                        view.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, gc.FieldName, gc, "{0:n0}");
                    }
                }
            }
        }

        private void AddCardColumns(GridControl _Grid, DataTable _DataTable, string _Columns, bool _ColVisible)
        {
            CardView view = _Grid.MainView as CardView;

            string[] _Cols = _Columns.Trim().Split(',');

            IDAT.Devexpress.GRID.IDATDevExpress_GridControl _clsDev = new IDAT.Devexpress.GRID.IDATDevExpress_GridControl();
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpiChkEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            rpiChkEdit.ValueChecked = "Y";
            rpiChkEdit.ValueUnchecked = "N";

            Parallel.For(0, _Cols.Length, i =>
            //for (int i = 0; i < _DPCols.Length; i++)
            {
                _Cols[i] = _Cols[i].Trim();
            });

            view.GroupCount = 0;
            view.Columns.Clear();
            view.FormatConditions.Clear();

            for (int i = 0; i < _DataTable.Columns.Count; i++)
            {
                if (_Grid.InvokeRequired) _Grid.Invoke(new CardColumnAddEventHandler(CardColumnAddEvent), _Grid, _DataTable, _Columns, i, _Cols, _ColVisible, rpiChkEdit);
                else CardColumnAddEvent(_Grid, _DataTable, _Columns, i, _Cols, _ColVisible, rpiChkEdit);
            }
        }


        private void AddGridColumns(GridControl _Grid, DataTable _DataTable, bool _Summary, bool _GroupSummary, string _Columns, bool _ColVisible)
        {
            GridView view = _Grid.MainView as GridView;
            
            string[] _Cols = _Columns.Trim().Split(',');

            IDAT.Devexpress.GRID.IDATDevExpress_GridControl _clsDev = new IDAT.Devexpress.GRID.IDATDevExpress_GridControl();
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpiChkEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            rpiChkEdit.ValueChecked = "Y";
            rpiChkEdit.ValueUnchecked = "N";

            Parallel.For(0, _Cols.Length, i =>
            //for (int i = 0; i < _DPCols.Length; i++)
            {
                _Cols[i] = _Cols[i].Trim();
            });

            view.GroupCount = 0;
            view.Columns.Clear();
            view.FormatConditions.Clear();
            
            if (_GroupSummary)
            {
                view.OptionsView.ShowGroupPanel = true;
                view.OptionsView.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
                view.GroupSummary.Clear();
            }

            if (_Columns == "")
            {
                for (int i = 0; i < _DataTable.Columns.Count; i++)
                {
                    if (_Grid.InvokeRequired) _Grid.Invoke(new GridColumnAddEventHandler(GridColumnAddEvent), _Grid, _DataTable, _Summary, _GroupSummary, _Columns, _DataTable.Columns[i].ColumnName, _Cols, _ColVisible, rpiChkEdit);
                    else GridColumnAddEvent(_Grid, _DataTable, _Summary, _GroupSummary, _Columns, _DataTable.Columns[i].ColumnName, _Cols, _ColVisible, rpiChkEdit);
                }
            }
            else
            {
                if (_ColVisible)
                {
                    for (int i = 0; i < _Cols.Length; i++)
                    {
                        if (_Grid.InvokeRequired) _Grid.Invoke(new GridColumnAddEventHandler(GridColumnAddEvent), _Grid, _DataTable, _Summary, _GroupSummary, _Columns, _Cols[i], _Cols, _ColVisible, rpiChkEdit);
                        else GridColumnAddEvent(_Grid, _DataTable, _Summary, _GroupSummary, _Columns, _Cols[i], _Cols, _ColVisible, rpiChkEdit);
                    }
                }
                else
                {
                    for (int i = 0; i < _DataTable.Columns.Count; i++)
                    {
                        if (_Grid.InvokeRequired) _Grid.Invoke(new GridColumnAddEventHandler(GridColumnAddEvent), _Grid, _DataTable, _Summary, _GroupSummary, _Columns, _DataTable.Columns[i].ColumnName, _Cols, _ColVisible, rpiChkEdit);
                        else GridColumnAddEvent(_Grid, _DataTable, _Summary, _GroupSummary, _Columns, _DataTable.Columns[i].ColumnName, _Cols, _ColVisible, rpiChkEdit);
                    }
                }
            }
        }

        private DataTable GetExecuteProcedureData(string _ProcName, int _Overload, string[] _Params, string[] _Values, bool _ErrorMessage = false)
        {
            Dictionary<string, object> dicParams = new Dictionary<string, object>();
            for (int i = 0; i < _Params.Count(); i++)
            {
                dicParams.Add(_Params[i], _Values[i]);
            }

            WSResults retData = _DB.Execute_Proc(_ProcName, _Overload, _Params, _Values);

            if (retData.ResultInt == 0)
            {
                return retData.ResultDataSet.Tables[0];
            }
            else
            {
                LanguageInformation clsLan = new LanguageInformation();

                HAENGSUNG_HNSMES_UI.Class.iDATMessageBox.ErrorMessage(string.Format("[{0}] {1}", retData.ResultInt, clsLan.GetMessageString(retData.ResultString)), "Error", 5, Global.Global_Variable.USERNAMELOCAL, _ProcName, dicParams);
                if (retData.ResultDataSet != null && retData.ResultDataSet.Tables.Count > 0) return retData.ResultDataSet.Tables[0];
                else return null;
            }
        }

        #endregion

        #region [Public Method]

        public void Bind_RepositoryItemComboBox(DevExpress.XtraEditors.Repository.RepositoryItemComboBox _Combo, string _ProcName, int _Overload, string[] _Params, string[] _Values, bool _ErrorMessage = false)
        {
            _Combo.NullText = "";
            _Combo.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            DataTable dt = GetExecuteProcedureData(_ProcName, _Overload, _Params, _Values, _ErrorMessage);            

            for (int nRow = 0; nRow < dt.Rows.Count; nRow++)
                _Combo.Items.Add(dt.Rows[nRow][0]);
        }


        public DataTable Bind_Grid_RT(GridControl _Grid, string _ProcName, int _Overload, string[] _Params, string[] _Values, bool _ControlBinding = false, string _Columns = "", bool _ColVisible = true, bool _Summary = true, bool _GroupSummary = false, bool _Merge = false, bool _ErrorMessage = false)
        {
            DataTable dt = GetExecuteProcedureData(_ProcName, _Overload, _Params, _Values, _ErrorMessage);
            
            _Grid.MainView.BeginUpdate();
            _Grid.MainView.BeginDataUpdate();

            if (dt == null || dt.Rows.Count == 0)
                _Grid.DataSource = dt;
            else
            {
                LanguageInformation clsLan = new LanguageInformation();
                DataTable dTemp = new DataTable();
                dTemp.Columns.Add("A");
                dTemp.Columns.Add("B");
                for (int nCol = 0; nCol < dt.Columns.Count; nCol++)
                {
                    DataRow dRow = dTemp.NewRow();
                    dRow["A"] = clsLan.GetMessageString(dt.Columns[nCol].ColumnName);
                    dRow["B"] = dt.Rows[0][nCol];
                    dTemp.Rows.Add(dRow);
                }
            
                _Grid.DataSource = dTemp;

                DevExpress.XtraGrid.Views.Grid.GridView view = _Grid.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
                view.OptionsView.ColumnAutoWidth = true;
                view.BestFitColumns();
                view.OptionsView.ShowAutoFilterRow = false;
                view.OptionsView.ShowColumnHeaders = false;
             }

            _Grid.MainView.EndDataUpdate();
            _Grid.MainView.EndUpdate();

            if (_ControlBinding) Bind_GridAndForm(_Grid, _Grid.FindForm());

            return dt;
        }


        public void Bind_Grid_RT(GridControl _Grid, DataTable _DataTable, bool _ControlBinding = false, string _Columns = "", bool _ColVisible = true, bool _Summary = true, bool _GroupSummary = false, bool _Merge = false, bool _ErrorMessage = false)
        {
            _Grid.MainView.BeginUpdate();
            _Grid.MainView.BeginDataUpdate();

            if (_DataTable == null || _DataTable.Rows.Count == 0)
                _Grid.DataSource = _DataTable;
            else
            {
                LanguageInformation clsLan = new LanguageInformation();
                DataTable dTemp = new DataTable();
                dTemp.Columns.Add("A");
                dTemp.Columns.Add("B");
                for (int nCol = 0; nCol < _DataTable.Columns.Count; nCol++)
                {
                    DataRow dRow = dTemp.NewRow();
                    dRow["A"] = clsLan.GetMessageString(_DataTable.Columns[nCol].ColumnName);
                    dRow["B"] = _DataTable.Rows[0][nCol];
                    dTemp.Rows.Add(dRow);
                }

                DevExpress.XtraGrid.Views.Grid.GridView view = _Grid.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
                view.OptionsView.ColumnAutoWidth = true;
                view.BestFitColumns();
                view.OptionsView.ShowAutoFilterRow = false;
                view.OptionsView.ShowColumnHeaders = false;

                _Grid.DataSource = dTemp;
            }

            _Grid.MainView.EndDataUpdate();
            _Grid.MainView.EndUpdate();

            if (_ControlBinding) Bind_GridAndForm(_Grid, _Grid.FindForm());
        }


        public DataTable Bind_Grid(GridControl _Grid, string _ProcName, int _Overload, string[] _Params, string[] _Values, bool _ControlBinding = false, string _Columns = "", bool _ColVisible = true, bool _Summary = true, bool _GroupSummary = false, bool _Merge = false, bool _ErrorMessage = false)
        {
            DataTable dt = null;

            try
            {
                LanguageInformation m_clsLan = new LanguageInformation();
                SplashScreenManager.ShowForm(null, typeof(COMWAITFORM), true, true, false);
                SplashScreenManager.Default.SendCommand(COMWAITFORM.WaitFormCommand.SetCaption, m_clsLan.GetMessageString("MSG_WAIT_001"));
                SplashScreenManager.Default.SendCommand(COMWAITFORM.WaitFormCommand.SetDescription, m_clsLan.GetMessageString("SEARCHING"));

                dt = GetExecuteProcedureData(_ProcName, _Overload, _Params, _Values, _ErrorMessage);

                if (dt == null)
                {
                    _Grid.DataSource = dt;
                    return dt;
                }

                _Grid.MainView.BeginUpdate();
                _Grid.MainView.BeginDataUpdate();

                SetGridMerge(_Grid, _Merge);

                AddGridColumns(_Grid, dt, _Summary, _GroupSummary, _Columns, _ColVisible);
                _Grid.DataSource = dt;

                GridView view = _Grid.MainView as GridView;
                if (view.VisibleColumns.Count > 0) view.EX_SetTotalSummaryItems(view.VisibleColumns[0].AbsoluteIndex, DevExpress.Data.SummaryItemType.Count, "Total:{0}");

                _Grid.MainView.EndDataUpdate();
                _Grid.MainView.EndUpdate();

                if (_ControlBinding) Bind_GridAndForm(_Grid, _Grid.FindForm());

                SplashScreenManager.CloseForm(false);

                return dt;
            }
            catch (Exception ex)
            {
                HAENGSUNG_HNSMES_UI.Class.iDATMessageBox.ErrorMessage(ex, Global.Global_Variable.USERNAMELOCAL);
                SplashScreenManager.CloseForm(false);
                return dt;
            }
        }
        public DataTable Bind_Grid_Int(GridControl _Grid, string _ProcName, int _Overload, string[] _Params, string[] _Values, bool _ControlBinding = false, string _Columns = "", bool _ColVisible = true, string _ColInteger = "", bool _Summary = true, bool _GroupSummary = false, bool _Merge = false, bool _ErrorMessage = false)
        {
            DataTable dt = null;

            try
            {
                LanguageInformation m_clsLan = new LanguageInformation();
                SplashScreenManager.ShowForm(null, typeof(COMWAITFORM), true, true, false);
                SplashScreenManager.Default.SendCommand(COMWAITFORM.WaitFormCommand.SetCaption, m_clsLan.GetMessageString("MSG_WAIT_001"));
                SplashScreenManager.Default.SendCommand(COMWAITFORM.WaitFormCommand.SetDescription, m_clsLan.GetMessageString("SEARCHING"));

                dt = GetExecuteProcedureData(_ProcName, _Overload, _Params, _Values, _ErrorMessage);

                if (dt == null)
                {
                    _Grid.DataSource = dt;
                    return dt;
                }

                string[] _strIntegerArray = _ColInteger.Split(',');

                /*정수 표현 컬럼 유무 체크*/
                if (_strIntegerArray.Length > 0)
                {
                    DataTable dtTemp = dt.Clone();

                    for (int i = 0; i < _strIntegerArray.Length; i++)
                    {
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            /*데이터 테이블 형 변경*/
                            if (_strIntegerArray[i] == dt.Columns[j].ColumnName)
                            {
                                dtTemp.Columns[j].DataType = typeof(Int32);
                                dtTemp.AcceptChanges();
                            }
                        }
                    }
                    /*데이터 내용 복사*/
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dtTemp.ImportRow(dt.Rows[i]);
                    }

                    /*기존 데이터 테이블 초기화*/
                    dt = null;
                    /*변경된 테이블 정보로 복사*/
                    dt = dtTemp.Copy();
                    
                }

                _Grid.MainView.BeginUpdate();
                _Grid.MainView.BeginDataUpdate();

                SetGridMerge(_Grid, _Merge);

                AddGridColumns(_Grid, dt, _Summary, _GroupSummary, _Columns, _ColVisible);
                _Grid.DataSource = dt;

                GridView view = _Grid.MainView as GridView;
                if (view.VisibleColumns.Count > 0) view.EX_SetTotalSummaryItems(view.VisibleColumns[0].AbsoluteIndex, DevExpress.Data.SummaryItemType.Count, "Total:{0}");

                _Grid.MainView.EndDataUpdate();
                _Grid.MainView.EndUpdate();

                if (_ControlBinding) Bind_GridAndForm(_Grid, _Grid.FindForm());

                SplashScreenManager.CloseForm(false);

                return dt;
            }
            catch (Exception ex)
            {
                HAENGSUNG_HNSMES_UI.Class.iDATMessageBox.ErrorMessage(ex, Global.Global_Variable.USERNAMELOCAL);
                SplashScreenManager.CloseForm(false);
                return dt;
            }
        }
        public void Bind_Grid(GridControl _Grid, DataTable _DataTable, bool _ControlBinding = false, string _Columns = "", bool _ColVisible = true, bool _Summary = true, bool _GroupSummary = false, bool _Merge = false, bool _ErrorMessage = false)
        {
            _Grid.MainView.BeginUpdate();
            _Grid.MainView.BeginDataUpdate();

            SetGridMerge(_Grid, _Merge);

            AddGridColumns(_Grid, _DataTable, _Summary, _GroupSummary, _Columns, _ColVisible);
            _Grid.DataSource = _DataTable;

            //IDAT.Devexpress.GRID.IDATDevExpress_GridControl _clsDev = new IDAT.Devexpress.GRID.IDATDevExpress_GridControl();
            //GridView view = _Grid.MainView as GridView;
            //if (view.VisibleColumns.Count > 0) _clsDev.SetTotalSummaryItems(view, view.VisibleColumns[0].AbsoluteIndex, DevExpress.Data.SummaryItemType.Count, "Total:{0}");

            GridView view = _Grid.MainView as GridView;
            if (view.VisibleColumns.Count > 0) view.EX_SetTotalSummaryItems(view.VisibleColumns[0].AbsoluteIndex, DevExpress.Data.SummaryItemType.Count, "Total:{0}");

            _Grid.MainView.EndDataUpdate();
            _Grid.MainView.EndUpdate();

            if (_ControlBinding) Bind_GridAndForm(_Grid, _Grid.FindForm());
        }
        /*2016-06-24*/
        /*정수형 데이터 타입 형태 변환 추가*/
        public void Bind_Grid_Int(GridControl _Grid, DataTable _DataTable, bool _ControlBinding = false, string _Columns = "", bool _ColVisible = true, string _ColInteger = "", bool _Summary = true, bool _GroupSummary = false, bool _Merge = false, bool _ErrorMessage = false)
        {
            string[] _strIntegerArray = _ColInteger.Split(',');
            
            if (_strIntegerArray.Length > 0)
            {
                DataTable dtTemp = _DataTable.Clone();
                for (int i = 0; i < _strIntegerArray.Length - 1; i++)
                {
                    for (int j = 0; j < dtTemp.Columns.Count; j++)
                    {
                        if (_strIntegerArray[i] == dtTemp.Columns[j].ColumnName)
                        {
                            dtTemp.Columns[j].DataType = typeof(Int32);
                            dtTemp.AcceptChanges();
                        }
                    }
                }

                /*데이터 내용 복사*/
                for (int i = 0; i < _DataTable.Rows.Count; i++)
                {
                    dtTemp.ImportRow(_DataTable.Rows[i]);
                }

                /*기존 데이터 테이블 초기화*/
                _DataTable = null;
                /*변경된 테이블 정보로 복사*/
                _DataTable = dtTemp.Copy();
                _DataTable.AcceptChanges();
            }

            _Grid.MainView.BeginUpdate();
            _Grid.MainView.BeginDataUpdate();

            SetGridMerge(_Grid, _Merge);

            AddGridColumns(_Grid, _DataTable, _Summary, _GroupSummary, _Columns, _ColVisible);
            _Grid.DataSource = _DataTable;

            //IDAT.Devexpress.GRID.IDATDevExpress_GridControl _clsDev = new IDAT.Devexpress.GRID.IDATDevExpress_GridControl();
            //GridView view = _Grid.MainView as GridView;
            //if (view.VisibleColumns.Count > 0) _clsDev.SetTotalSummaryItems(view, view.VisibleColumns[0].AbsoluteIndex, DevExpress.Data.SummaryItemType.Count, "Total:{0}");

            GridView view = _Grid.MainView as GridView;
            if (view.VisibleColumns.Count > 0) view.EX_SetTotalSummaryItems(view.VisibleColumns[0].AbsoluteIndex, DevExpress.Data.SummaryItemType.Count, "Total:{0}");

            _Grid.MainView.EndDataUpdate();
            _Grid.MainView.EndUpdate();

            if (_ControlBinding) Bind_GridAndForm(_Grid, _Grid.FindForm());
        }

        public DataTable Refresh_Grid(GridControl _Grid, string _ProcName, int _Overload, string[] _Params, string[] _Values, bool _ControlBinding = false)
        {
            DataTable dt = GetExecuteProcedureData(_ProcName, _Overload, _Params, _Values);

            _Grid.MainView.BeginUpdate();
            _Grid.MainView.BeginDataUpdate();

            _Grid.DataSource = dt;

            _Grid.MainView.EndDataUpdate();
            _Grid.MainView.EndUpdate();

            if(_Grid.Views[0] is GridView)
                (_Grid.Views[0] as GridView).OptionsNavigation.AutoFocusNewRow = true;

            
            if (_ControlBinding) Bind_GridAndForm(_Grid, _Grid.FindForm());

            return dt;
        }

        public DataTable Refresh_Grid(GridControl _Grid, string _ProcName, int _Overload, string[] _Params, string[] _Values, bool _ControlBinding = false, string _DisplayColumns = "")
        {
            DataTable dt = GetExecuteProcedureData(_ProcName, _Overload, _Params, _Values);

            _Grid.MainView.BeginUpdate();
            _Grid.MainView.BeginDataUpdate();

            _Grid.DataSource = dt;

            _Grid.MainView.EndDataUpdate();
            _Grid.MainView.EndUpdate();

            if (_Grid.Views[0] is GridView)
                (_Grid.Views[0] as GridView).OptionsNavigation.AutoFocusNewRow = true;

            IDAT.Devexpress.GRID.IDATDevExpress_GridControl _clsDev = new IDAT.Devexpress.GRID.IDATDevExpress_GridControl();
            GridView view = _Grid.MainView as GridView;
            if (view.VisibleColumns.Count > 0) _clsDev.SetTotalSummaryItems(view, view.VisibleColumns[0].AbsoluteIndex, DevExpress.Data.SummaryItemType.Count, "Total:{0}");


            if (_ControlBinding) Bind_GridAndForm(_Grid, _Grid.FindForm());

            return dt;

        }

        public void SetGridMerge(DevExpress.XtraGrid.GridControl p_gc, bool _Merge)
        {
            GridView view = p_gc.DefaultView as GridView;
            view.OptionsView.AllowCellMerge = _Merge;

            try
            {
                view.CellMerge -= view_CellMerge;
            }
            catch { }

            if (_Merge) view.CellMerge += new CellMergeEventHandler(view_CellMerge);
        }

        private void view_CellMerge(object sender, CellMergeEventArgs e)
        {
            bool bMerge = true;
            GridView gv = sender as GridView;
            string[] strColumnValue1 = new string[gv.Columns.Count];
            string[] strColumnValue2 = new string[gv.Columns.Count];

            if (e.Column.VisibleIndex < gv.Columns.Count)
            {
                for (int i = 0; i < e.Column.VisibleIndex + 1; i++)
                {
                    for (int j = 0; j < gv.Columns.Count; j++)
                    {
                        lock (gv.Columns[j])
                        {
                            if (gv.Columns[j].VisibleIndex == i)
                            {
                                strColumnValue1[i] = gv.GetRowCellValue(e.RowHandle1, gv.Columns[j]) + "";
                                strColumnValue2[i] = gv.GetRowCellValue(e.RowHandle2, gv.Columns[j]) + "";
                                break;
                            }
                        }
                    }
                }

                for (int i = 0; i < e.Column.VisibleIndex + 1; i++)
                {
                    if (strColumnValue1[i] != strColumnValue2[i])
                    {
                        bMerge = false;
                        break;
                    }
                }

                e.Merge = bMerge;
                e.Handled = true;
            }
        }


        /*2016.04.29 신규 추가*/
        /*고정된 컬럼 Grid 초기화 Func*/
        public void Fix_Grid_Initialize(GridControl _Grid, DataTable dt)
        {
            GridView view = _Grid.MainView as GridView;

            _Grid.MainView.BeginUpdate();
            _Grid.MainView.BeginDataUpdate();

            _Grid.DataSource = dt;

            _Grid.MainView.EndDataUpdate();
            _Grid.MainView.EndUpdate();

            LanguageInformation clsLan = new LanguageInformation();

            for (int i = 0; i < view.Columns.Count; i++)
            {
                GridColumn dc = view.Columns[i];

                dc.Caption = clsLan.GetMessageString(dc.Caption);
                dc.FieldName = dc.Caption;
                dc.OptionsColumn.AllowEdit = true;
            }
            

        }

        #endregion
    }
}
