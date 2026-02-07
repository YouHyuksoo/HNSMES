using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;

// user namespace

using System.Collections;
using DevExpress.XtraGrid.Views.Grid;
using IDAT.WebService;

using GridAlias = DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using HAENGSUNG_HNSMES_UI.WebService.Access ;
using IDAT.Devexpress.FORM;
using System.Threading.Tasks;
using DevExpress.XtraGrid.Views.Card;

namespace HAENGSUNG_HNSMES_UI.Class
{
    class iDATControlBinding
    {
        #region 전역변수

        ArrayList aryBindingControl = new ArrayList();
        HAENGSUNG_HNSMES_UI.WebService.Business.IDatabaseProcess _DB = null;
        iDATCommonControlManager _iDatCommonConUtil = new iDATCommonControlManager();
        IDAT.Devexpress.GRID.IDATDevExpress_GridControl _DevGridUitl = new IDAT.Devexpress.GRID.IDATDevExpress_GridControl();

        #endregion

        public iDATControlBinding(HAENGSUNG_HNSMES_UI.WebService.Business.IDatabaseProcess iDB)
        {
            _DB = iDB;
        }

        #region XtraGridView Bind

        #region [CardView Bind]

        /// <summary>
        /// CardView 컨트롤을 바인딩 합니다.
        /// </summary>
        /// <param name="p_Form">현재 폼 컨트롤</param>
        /// <param name="p_gc">그리드 컨트롤</param>
        /// <param name="p_strProc">프로시저명</param>
        /// <param name="p_intProcSeq">프로시져 오버로딩 인덱스</param>
        /// <param name="p_arrParams">파라메터</param>
        /// <param name="p_arrValues">값</param>
        /// <param name="p_blnControlBinding">현재 폼 컨트롤들의 바인딩 연결 유무</param>
        /// <returns>프로시저 호출 된 결과 데이터 테이블</returns>
        public DataTable Bind_CardView(Control p_Form, DevExpress.XtraGrid.GridControl p_gc, string p_strProc, int p_intProcSeq, string[] p_arrParams, string[] p_arrValues, bool p_blnControlBinding)
        {
            LanguageInformation _clsLan = new LanguageInformation();

            Dictionary<string, object> param = new Dictionary<string, object>();

            Parallel.For(0, p_arrParams.Length, i =>
            {
                param.Add(p_arrParams[i], p_arrValues[i]);
            });

            WSResults result = _DB.Execute_Proc(p_strProc, p_intProcSeq, param);

            // result.ReturnInt == 0이면 올바르게 데이터를 받음
            if (result.ResultInt == 0)
            {
                string _strFormName = "";
                if (p_Form != null)
                {
                    _strFormName = p_Form.Name;
                    if (p_Form.Tag + "" != "") _strFormName += "_" + p_Form.Tag;
                }

                // XtraGridview와 바인딩
                p_gc.BeginUpdate();
                p_gc.DataSource = result.ResultDataSet.Tables[0];

                CardView view = p_gc.DefaultView as CardView;
                Parallel.For(0, view.Columns.Count, nCol =>
                {
                    lock (view.Columns[nCol])
                    {
                        if (view.Columns[nCol].Visible)
                        {
                            view.Columns[result.ResultDataSet.Tables[0].Columns[nCol].ColumnName].Caption = _clsLan.GetMessageString(result.ResultDataSet.Tables[0].Columns[nCol].ColumnName);
                        }
                    }
                });

                p_gc.EndUpdate();

                if (p_blnControlBinding)
                    this.Bind_GridAndForm(p_gc, p_Form);

                return result.ResultDataSet.Tables[0];
            }
            else
            {
                iDATMessageBox.ShowProcResultMessage(result, "Error", Global.Global_Variable.USER_ID, p_strProc, param);
                return null;
            }
        }

        /// <summary>
        /// CardView 컨트롤을 바인딩 합니다.
        /// </summary>
        /// <param name="p_Form">현재 폼 컨트롤</param>
        /// <param name="p_gc">그리드 컨트롤</param>
        /// <param name="dTable">데이터 테이블</param>
        /// <param name="p_blnControlBinding">현재 폼 컨트롤들의 바인딩 연결 유무</param>
        public void Bind_CardView(Control p_Form, DevExpress.XtraGrid.GridControl p_gc, DataTable dTable, bool p_blnControlBinding)
        {
            LanguageInformation _clsLan = new LanguageInformation();

            string _strFormName = "";
            if (p_Form != null)
            {
                _strFormName = p_Form.Name;
                if (p_Form.Tag + "" != "") _strFormName += "_" + p_Form.Tag;
            }
            // XtraGridview와 바인딩
            p_gc.BeginUpdate();
            p_gc.DataSource = dTable;

            CardView view = p_gc.DefaultView as CardView;

            Parallel.For(0, view.Columns.Count, nCol =>
            {
                lock (view)
                {
                    if (view.Columns[nCol].Visible)
                    {
                        view.Columns[dTable.Columns[nCol].ColumnName].Caption = _clsLan.GetMessageString(dTable.Columns[nCol].ColumnName);
                    }
                }
            });

            p_gc.EndUpdate();

            if (p_blnControlBinding)
                this.Bind_GridAndForm(p_gc, p_Form);
        }

        #endregion



        /// <summary>                                                                                                                                                                                                          
        /// 선택된 컬럼만 보이도록 나머지는 안보이도록 처리                                                                                                                                                                    
        /// </summary>                                                                                                                                                                                                         
        /// <param name="p_gv">그리드뷰 콘트롤</param>                                                                                                                                                                         
        /// <param name="p_strColumn">ex)"ACOLUMN,BCOLUMN,CCOLUMN" 컬럼 ,로 구분</param>                                                                                                                                       
        public void Set_GridColumn(DevExpress.XtraGrid.GridControl p_gc, string p_strColumn)
        {
            this.Set_GridColumn(p_gc, p_strColumn, true);
        }

        /// <summary>                                                                                                                                                                                                          
        /// 선택된 컬럼만 보이도록 나머지는 안보이도록 처리                                                                                                                                                                    
        /// </summary>                                                                                                                                                                                                         
        /// <param name="p_gv">그리드뷰 콘트롤</param>                                                                                                                                                                         
        /// <param name="p_strColumn">ex)"ACOLUMN,BCOLUMN,CCOLUMN" 컬럼 ,로 구분</param>                                                                                                                                       
        public void Set_GridColumn(DevExpress.XtraGrid.GridControl p_gc, string p_strColumn, bool p_blnVisible)
        {
            p_gc.BeginUpdate();
            foreach (DevExpress.XtraGrid.Views.Grid.GridView _gv in p_gc.Views)
            {
                this.Set_GridColumn(_gv, p_strColumn, p_blnVisible);
            }
            p_gc.EndUpdate();
        }

        /// <summary>                                                                                                                                                                                                          
        /// 선택된 컬럼만 보이도록 나머지는 안보이도록 처리                                                                                                                                                                    
        /// </summary>                                                                                                                                                                                                         
        /// <param name="p_gv">그리드뷰 콘트롤</param>                                                                                                                                                                         
        /// <param name="p_strColumn">ex)"ACOLUMN,BCOLUMN,CCOLUMN" 컬럼 ,로 구분</param>                                                                                                                                       
        public void Set_GridColumn(DevExpress.XtraGrid.Views.Grid.GridView p_gv, string p_strColumn)
        {
            this.Set_GridColumn(p_gv, p_strColumn, true);
        }

        /// <summary>                                                                                                                                                                                                          
        /// 선택된 컬럼만 보이도록 나머지는 안보이도록 처리                                                                                                                                                                    
        /// </summary>                                                                                                                                                                                                         
        /// <param name="p_gv">그리드뷰 콘트롤</param>                                                                                                                                                                         
        /// <param name="p_strColumn">ex)"ACOLUMN,BCOLUMN,CCOLUMN" 컬럼 ,로 구분</param>                                                                                                                                       
        public void Set_GridColumn(DevExpress.XtraGrid.Views.Grid.GridView p_gv, string p_strColumn, bool p_blnView)
        {
            p_gv.BeginUpdate();

            p_strColumn = ("," + p_strColumn + ",").Replace(" ", "");

            int _iTmp = 0;

            if (p_gv.Columns.Count == 0 && p_blnView)
            {
                for (int i = 0; i < p_strColumn.Split(',').Length; i++)
                {
                    if (p_strColumn.Split(',')[i] + "" != "")
                    {
                        lock (p_gv)
                        {
                            DevExpress.XtraGrid.Columns.GridColumn _col = new DevExpress.XtraGrid.Columns.GridColumn();
                            _col.Name = p_strColumn.Split(',')[i] + "";
                            _col.Caption = p_strColumn.Split(',')[i] + "";
                            _col.FieldName = p_strColumn.Split(',')[i] + "";
                            _col.Visible = true;
                            _col.VisibleIndex = _iTmp;
                            _iTmp++;
                            p_gv.Columns.Add(_col);
                        }
                    }
                }
            }
            else
            {
                //Parallel.For(0, p_gv.Columns.Count, i =>
                for (int i = 0; i < p_gv.Columns.Count; i++)
                {
                    lock (p_gv)
                    {
                        if ((p_strColumn.IndexOf("," + p_gv.Columns[i].FieldName + ",") >= 0))
                        {
                            Console.WriteLine("True : " + p_gv.Columns[i].FieldName);
                            p_gv.Columns[i].Visible = p_blnView;
                        }
                        else
                        {
                            Console.WriteLine("False : " + p_gv.Columns[i].FieldName);
                            p_gv.Columns[i].Visible = !p_blnView;
                        }
                    }
                }//);
            }
            p_gv.EndUpdate();
        }

        public void Set_GridColumn(DevExpress.XtraGrid.Views.Grid.GridView p_gv, DataTable dt)
        {
            if (p_gv is DevExpress.XtraGrid.Views.BandedGrid.BandedGridView) return;

            p_gv.BeginUpdate();

            int _iTmp = 0;

            if (p_gv.Columns.Count == 0)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    lock (p_gv)
                    {
                        DevExpress.XtraGrid.Columns.GridColumn _col = new DevExpress.XtraGrid.Columns.GridColumn();
                        _col.Name = dt.Columns[i].ColumnName + "";
                        _col.Caption = dt.Columns[i].ColumnName + "";
                        _col.FieldName = dt.Columns[i].ColumnName + "";
                        _col.Visible = true;
                        _col.VisibleIndex = _iTmp;
                        _iTmp++;
                        p_gv.Columns.Add(_col);
                    }
                }//);
            }
            p_gv.EndUpdate();
        }
        #endregion

        #region GridLookUpEditor Bind



        #endregion

        #region SearchLookUpEditor Bind

        /// <summary>                                                                                                                                                                                                          
        /// search lookupedit 설정
        /// </summary>                                                                                                                                                                                                         
        public void Bind_SearchGridLookUpEdit(DevExpress.XtraEditors.SearchLookUpEdit p_gle, DataTable dTable, string p_strValueMemeber, string p_strDisplayMember, string p_strVisibleColumns)
        {
            //p_gle.Properties.BeginUpdate();
            p_gle.Properties.View.Columns.Clear();
            p_gle.Properties.DataSource = dTable;
            p_gle.Properties.DisplayMember = p_strDisplayMember;
            p_gle.Properties.ValueMember = p_strValueMemeber;

            if (p_strVisibleColumns != "")
            {
                //Parallel.For(0, dTable.Columns.Count, i =>
                for (int i = 0; i < dTable.Columns.Count; i++)
                {
                    //lock (p_gle)
                    {
                        p_gle.Properties.View.Columns.AddField(dTable.Columns[i].ColumnName);
                        if ((p_strVisibleColumns.IndexOf(dTable.Columns[i].ColumnName + ",") > -1) ||
                            (p_strVisibleColumns.IndexOf(dTable.Columns[i].ColumnName + " ") > -1))
                            p_gle.Properties.View.Columns[i].Visible = true;
                        else
                            p_gle.Properties.View.Columns[i].Visible = false;
                    }
                }
            }
            p_gle.Properties.View.OptionsView.ColumnAutoWidth = false;
            p_gle.Properties.View.BestFitColumns();
            //p_gle.Properties.EndUpdate();
        }

        /// <summary>
        /// search lookupedit 설정
        /// </summary>
        public void Bind_SearchGridLookUpEdit(DevExpress.XtraEditors.SearchLookUpEdit p_gle, string p_strProc, int p_intProcSeq, string[] p_arrParams, string[] p_arrValues, string p_strValueMemeber, string p_strDisplayMember, string p_strVisibleColumns)
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
                //p_gle.Properties.BeginUpdate();
                p_gle.Properties.View.Columns.Clear();
                p_gle.Properties.DataSource = result.ResultDataSet.Tables[0];
                p_gle.Properties.DisplayMember = p_strDisplayMember;
                p_gle.Properties.ValueMember = p_strValueMemeber;

                if (p_strVisibleColumns != "")
                {
                    //Parallel.For(0, result.ReturnDataSet.Tables[0].Columns.Count, i =>
                    for (int i = 0; i < result.ResultDataSet.Tables[0].Columns.Count; i++)
                    {
                        p_gle.Properties.View.Columns.AddField(result.ResultDataSet.Tables[0].Columns[i].ColumnName);
                        if ((p_strVisibleColumns.IndexOf(result.ResultDataSet.Tables[0].Columns[i].ColumnName + ",") > -1) ||
                            (p_strVisibleColumns.IndexOf(result.ResultDataSet.Tables[0].Columns[i].ColumnName + " ") > -1))

                            p_gle.Properties.View.Columns[i].Visible = true;
                        else
                            p_gle.Properties.View.Columns[i].Visible = false;
                    }
                }
                p_gle.Properties.View.OptionsView.ColumnAutoWidth = false;
                p_gle.Popup += new EventHandler(p_gle_Popup);
                //p_gle.Properties.View.BestFitColumns();
                p_gle.Properties.EndUpdate();
            }
            else
            {
                iDATMessageBox.ShowProcResultMessage(result, "Error", Global.Global_Variable.USER_ID, p_strProc, param);
            }
        }

        void p_gle_Popup(object sender, EventArgs e)
        {
            SearchLookUpEdit sle = sender as SearchLookUpEdit;
            sle.Properties.View.BestFitColumns();

        }

        public void Bind_Repository_SearchGridLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit p_gle, string p_strProc, int p_intProcSeq, string[] p_arrParams, string[] p_arrValues, string p_strValueMemeber, string p_strDisplayMember, string p_strVisibleColumns, bool p_blnFilterRow)
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
                //p_gle.BeginUpdate();
                p_gle.View.Columns.Clear();
                p_gle.DataSource = result.ResultDataSet.Tables[0];
                p_gle.DisplayMember = p_strDisplayMember;
                p_gle.ValueMember = p_strValueMemeber;
                p_gle.View.OptionsView.ShowAutoFilterRow = p_blnFilterRow;

                if (p_strVisibleColumns != "")
                {
                    for (int i = 0; i < result.ResultDataSet.Tables[0].Columns.Count; i++)
                    {
                        //lock (p_gle)
                        {
                            p_gle.View.Columns.AddField(result.ResultDataSet.Tables[0].Columns[i].ColumnName);
                            if ((p_strVisibleColumns.IndexOf(result.ResultDataSet.Tables[0].Columns[i].ColumnName + ",") > -1) ||
                                (p_strVisibleColumns.IndexOf(result.ResultDataSet.Tables[0].Columns[i].ColumnName + " ") > -1))
                                p_gle.View.Columns[i].Visible = true;
                            else
                                p_gle.View.Columns[i].Visible = false;
                        }
                    }
                }
                p_gle.View.OptionsView.ColumnAutoWidth = false;
                p_gle.View.BestFitColumns();
            }
            else
            {
                iDATMessageBox.ShowProcResultMessage(result, "Error", Global.Global_Variable.USER_ID, p_strProc, param);
            }
        }


        /// <summary>                                                                                                                                                                                                          
        /// lookupedit 설정
        /// </summary>                                                                                                                                                                                                         
        public void Bind_SearchGridLookUpEdit(DevExpress.XtraEditors.SearchLookUpEdit gridLookUpCon, string proc, int procSeq, string[] sParams, string[] Values, string ValueMemeber, string DisplayMember)
        {
            this.Bind_SearchGridLookUpEdit(gridLookUpCon, proc, procSeq, sParams, Values, ValueMemeber, DisplayMember, "");
        }

        /// <summary>                                                                                                                                                                                                          
        /// RepositoryItemGridLookUpEdit 설정
        /// </summary>
        public void Bind_SearchGridLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit gridLookUpCon, string proc, int procSeq, string[] sParams, string[] Values, string ValueMemeber, string DisplayMember, string strVisibleColumns)//string[] visibleColumn)
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
                // GridLookUp 바인딩
                gridLookUpCon.View.Columns.Clear();
                gridLookUpCon.DataSource = result.ResultDataSet.Tables[0];
                gridLookUpCon.DisplayMember = DisplayMember;
                gridLookUpCon.ValueMember = ValueMemeber;

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
            }
            else
            {
                iDATMessageBox.ShowProcResultMessage(result, "Error", Global.Global_Variable.USER_ID, proc, param);
            }
        }




        #endregion

        #region Data Binding
        /// <summary>
        /// 바인딩 작업을 지원합니다.
        /// </summary>
        /// <param name="p_gc">그리드 컨트롤</param>
        /// <param name="controls">컨트롤</param>
        public void Bind_GridAndForm(DevExpress.XtraGrid.GridControl gridCon, Control controls)
        {
            try
            {
                aryBindingControl.Clear();

                Find_FormControl(controls);
                //Parallel.For(0, aryBindingControl.Count, i =>
                foreach (Control cons in aryBindingControl)
                {
                    lock (cons)
                    {
                        Bind_GridAndFormFunc(gridCon, cons);
                    }
                }

                aryBindingControl.Clear();
                // 바인딩 된 그리드 컨트롤을 전역변수에 저장
                //aryBindingGridCon.Add(gridCon);
            }
            catch
            {
                throw;
            }
        }

        private void Find_FormControl(Control controls)
        {
            Parallel.For(0, controls.Controls.Count, i =>
            {
                if (controls.Controls[i].Controls.Count > 0)
                {
                    Find_FormControl(controls.Controls[i]);
                }

                if (controls.Controls[i].Tag + "" != "")
                {
                    lock (aryBindingControl)
                    {
                        aryBindingControl.Add(controls.Controls[i]);
                    }
                }
            });
        }

        private void Bind_GridAndFormFunc(DevExpress.XtraGrid.GridControl gridCon, Control controls)
        {
            if (controls.Tag != null)
            {
                if (controls is BaseEdit)
                {
                    BaseEdit BaseCon = controls as BaseEdit;
                    BaseCon.DataBindings.Clear();

                    if (_iDatCommonConUtil.GetTagINFO(controls, "bind") != "")
                    {
                        string bindTag = _iDatCommonConUtil.GetTagINFO(controls, "bind");

                        try
                        {
                            // lock (BaseCon)
                            {
                                if (controls.InvokeRequired)
                                {
                                    controls.Invoke(new MethodInvoker(delegate()
                                    {
                                        BaseCon.DataBindings.Add("EditValue", gridCon.DataSource, bindTag, false, DataSourceUpdateMode.OnValidation);
                                    }));
                                }
                                else
                                {
                                    BaseCon.DataBindings.Add("EditValue", gridCon.DataSource, bindTag, false, DataSourceUpdateMode.OnValidation);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (controls.InvokeRequired)
                            {
                                controls.Invoke(new MethodInvoker(delegate()
                                {
                                    //lock (BaseCon)
                                    {
                                        BaseCon.Text = ex.Message;
                                    }
                                }));
                            }
                            else
                            {
                                BaseCon.Text = ex.Message;
                            }
                        }
                    }
                }
            }
        }

        public void Bind_GridAndControl(DevExpress.XtraGrid.GridControl gridCon, Control cons)
        {
            try
            {
                if (cons.Tag != null)
                {
                    if (cons is BaseEdit)
                    {
                        BaseEdit BaseCon = cons as BaseEdit;
                        BaseCon.DataBindings.Clear();

                        if (_iDatCommonConUtil.GetTagINFO(cons, "bind") != "")
                        {
                            string bindTag = _iDatCommonConUtil.GetTagINFO(cons, "bind");

                            try
                            {
                                BaseCon.DataBindings.Add("EditValue", gridCon.DataSource, bindTag, false, DataSourceUpdateMode.OnValidation);
                            }
                            catch (Exception ex)
                            {
                                BaseCon.Text = ex.Message;
                            }
                        }
                    }
                }

                // 바인딩 된 그리드 컨트롤을 전역변수에 저장
                //aryBindingGridCon.Add(gridCon);
            }
            catch
            {
                throw;
            }
        }

        public void Bind_DataTableAndForm(DataTable data, Control controls)
        {
            try
            {
                Parallel.For(0, controls.Controls.Count, i =>
                //foreach (Control cons in controls.Controls)
                {
                    if (controls.Controls[i].Controls.Count > 0)
                    {
                        foreach (Control cons in controls.Controls[i].Controls)
                        {
                            Bind_DataTableAndFormFunc(data, cons);
                        }
                    }

                    Bind_DataTableAndFormFunc(data, controls.Controls[i]);
                });

                // 바인딩 된 그리드 컨트롤을 전역변수에 저장
                //aryBindingGridCon.Add(data);
            }
            catch
            {
                throw;
            }
        }

        private void Bind_DataTableAndFormFunc(DataTable data, Control controls)
        {
            if (controls.Tag != null)
            {
                if (controls is BaseEdit)
                {
                    BaseEdit BaseCon = controls as BaseEdit;
                    BaseCon.DataBindings.Clear();

                    if (_iDatCommonConUtil.GetTagINFO(controls, "bind") != "")
                    {
                        string bindTag = _iDatCommonConUtil.GetTagINFO(controls, "bind");

                        try
                        {
                            BaseCon.DataBindings.Add("EditValue", data, bindTag, false, DataSourceUpdateMode.OnValidation);
                        }
                        catch (Exception ex)
                        {
                            BaseCon.Text = ex.Message;
                        }
                    }
                }
            }
        }

        public void Bind_DataTableAndControl(DataTable data, Control cons)
        {
            try
            {
                if (cons.Tag != null)
                {
                    if (cons is BaseEdit)
                    {
                        BaseEdit BaseCon = cons as BaseEdit;
                        BaseCon.DataBindings.Clear();

                        if (_iDatCommonConUtil.GetTagINFO(cons, "bind") != "")
                        {
                            string bindTag = _iDatCommonConUtil.GetTagINFO(cons, "bind");

                            try
                            {
                                BaseCon.DataBindings.Add("EditValue", data, bindTag, false, DataSourceUpdateMode.OnValidation);
                            }
                            catch (Exception ex)
                            {
                                BaseCon.Text = ex.Message;
                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region TreeEdit Bind

        public void Bind_TreeEdit(HAENGSUNG_HNSMES_UI.UserControl.COM.TreeEdit p_TreeEdit, string proc, int procSeq, string[] sParams, string[] Values, string ValueMemeber, string DisplayMember, string p_strParentField, string p_strKeyField, string p_strImageField)
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
                p_TreeEdit.Properties.BeginUpdate();
                p_TreeEdit.DataSource = result.ResultDataSet.Tables[0];
                p_TreeEdit.Properties.DisplayMember = DisplayMember;
                p_TreeEdit.Properties.ValueMember = ValueMemeber;
                p_TreeEdit.ParentFieldName = p_strParentField;
                p_TreeEdit.KeyFieldName = p_strKeyField;
                p_TreeEdit.ImageIndexFieldName = p_strImageField;
                p_TreeEdit.Properties.EndUpdate();

            }
            else
            {
                iDATMessageBox.ShowProcResultMessage(result, "Error", Global.Global_Variable.USER_ID, proc, param);
            }
        }

        #endregion

        #region TreeList Bind

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_Form"></param>
        /// <param name="p_TreeList"></param>
        /// <param name="p_strProc"></param>
        /// <param name="p_intProcSeq"></param>
        /// <param name="p_arrParams"></param>
        /// <param name="p_arrValues"></param>
        /// <param name="p_blnAutoWidth"></param>
        /// <param name="ParentFieldName"></param>
        /// <param name="KeyFieldName"></param>
        /// <returns></returns>
        public DataTable Bind_TreeList(
            Control p_Form, 
            DevExpress.XtraTreeList.TreeList p_TreeList, 
            string p_strProc, 
            int p_intProcSeq, 
            string[] p_arrParams, 
            string[] p_arrValues, 
            bool p_blnAutoWidth,
            string ParentFieldName = "UPRIDX",
            string KeyFieldName = "IDX")
        {
            LanguageInformation _clsLan = new LanguageInformation();

            Dictionary<string, object> param = new Dictionary<string, object>();

            Parallel.For(0, p_arrParams.Length, i =>
            {
                lock (param)
                {
                    param.Add(p_arrParams[i], p_arrValues[i]);
                }
            });

            WSResults result = _DB.Execute_Proc(p_strProc, p_intProcSeq, param);

            if (result.ResultInt == 0)
            {
                p_TreeList.Update();


                p_TreeList.DataSource = result.ResultDataSet.Tables[0];

                Parallel.For(0, p_TreeList.Columns.Count, nCol =>
                {
                    lock (p_TreeList.Columns[nCol])
                    {
                        if (p_TreeList.Columns[nCol].Visible)
                        {
                            p_TreeList.Columns[result.ResultDataSet.Tables[0].Columns[nCol].ColumnName].Caption = 
                                _clsLan.GetMessageString(result.ResultDataSet.Tables[0].Columns[nCol].ColumnName) == null ? 
                                result.ResultDataSet.Tables[0].Columns[nCol].ColumnName :
                                _clsLan.GetMessageString(result.ResultDataSet.Tables[0].Columns[nCol].ColumnName);
                        }
                    }
                });

                p_TreeList.ParentFieldName = ParentFieldName;
                p_TreeList.KeyFieldName = KeyFieldName;

                p_TreeList.OptionsView.AutoWidth = p_blnAutoWidth;
                p_TreeList.BestFitColumns();

                p_TreeList.ExpandAll();

                p_TreeList.EndUpdate();

                return result.ResultDataSet.Tables[0];
            }
            else
            {
                iDATMessageBox.ShowProcResultMessage(result, "Error", Global.Global_Variable.USER_ID, p_strProc, param);
                return null;
            }
        }

        #endregion

        #region RadioGroup Bind

        /// <summary>                                                                                                                                                                                                          
        /// RadioGroup 설정
        /// </summary>                                                                                                                                                                                                         
        public void Bind_RadioGroup(RadioGroup p_rdo, string p_strProc, int p_intProcSeq, string[] p_arrParams, string[] p_arrValues, string strValueMember, string strTextMember)
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
                p_rdo.Properties.BeginUpdate();
                p_rdo.Properties.Items.Clear();

                Parallel.For(0, result.ResultDataSet.Tables[0].Rows.Count, nRow =>
                {
                    lock (p_rdo)
                    {
                        p_rdo.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(result.ResultDataSet.Tables[0].Rows[nRow][strValueMember] + "", result.ResultDataSet.Tables[0].Rows[nRow][strTextMember] + ""));
                    }
                });

                p_rdo.Properties.EndUpdate();
            }
            else
            {
                iDATMessageBox.ShowProcResultMessage(result, "Error", Global.Global_Variable.USER_ID, p_strProc, param);
            }
        }

        #endregion
    }
}
