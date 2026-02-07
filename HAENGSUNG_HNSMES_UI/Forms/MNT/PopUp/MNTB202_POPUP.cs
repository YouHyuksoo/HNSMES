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


using System.Data.OleDb;
using System.IO;
using System.Diagnostics;

using DevExpress.XtraGrid.Views;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

using GridAlias = DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraSplashScreen;


namespace HAENGSUNG_HNSMES_UI.Forms.MNT.PopUp
{
    public partial class MNTB202_POPUP : BASE.Form
    {
        RepositoryItemGridLookUpEdit gle = new RepositoryItemGridLookUpEdit();
        RepositoryItemComboBox cmb = new RepositoryItemComboBox();

        private MNTB202 mParent = null;

        public MNTB202 _ParentForm
        {
            get { return mParent; }
            set { mParent = value; }
        }

        public MNTB202_POPUP()
        {
            InitializeComponent();
        }

        private void MNTB202_POPUP_Load(object sender, EventArgs e)
        {

        }

        private void MNTB202_POPUP_Shown(object sender, EventArgs e)
        {
            GetGridViewList();
        }
        

        #region [Button Event]

        public void InitButton_Click()
        {
            this.Set_Init();
        }
        
        public void NewButton_Click()
        {
        }


        public void EditButton_Click()
        {
        }
       
        public void StopButton_Click()
        {
        }
       
        public void SearchButton_Click()
        {
            GetGridViewList();
        }
       
        public void SaveButton_Click()
        {            
        }

        public void PrintButton_Click()
        {
        }
       
        public void RefreshButton_Click()
        {
        }

        public void DeleteButton_Click()
        {
            
        }

        #endregion
     
        #region [Private Method]

        private void Set_Init()
        {            
        }


        private void GetGridViewList()
        {

            WSResults result = BASE_db.Execute_Proc("PKGHNS_REPORT.GET_MAT_PRODPLAN"
                                                   , 1
                                                   , new string[] {
                                                     "A_CLIENT"
                                                   , "A_COMPANY"
                                                   , "A_PLANT"
                                                   , "A_PLANDATE"
                                                   , "A_PARTNO" }
                                                   , new string[] {
                                                     Global.Global_Variable.CLIENT
                                                   , Global.Global_Variable.COMPANY
                                                   , Global.Global_Variable.PLANT
                                                   , txtDate.EditValue.ObjectNullString()
                                                   , txtPartNo.EditValue.ObjectNullString() }
                                                   );

            gcList.DataSource = null;
            gvList.Columns.Clear();

            if (result.ResultInt == 0)
            {
                gvList.BeginUpdate();
                gvList.OptionsView.ShowAutoFilterRow = false;
                gvList.OptionsView.RowAutoHeight = true;

                gcList.DataSource = result.ResultDataSet.Tables[0];

                foreach (GridColumn gc in gvList.Columns)
                {
                    if (gc.FieldName.IndexOf("PARTNO") > -1 || gc.FieldName.IndexOf("SPEC") > -1)
                    {
                        gc.Fixed = FixedStyle.Left;
                    }

                    gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                    if (gc.FieldName.Equals("QTY1"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][0].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY2"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][1].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY3"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][2].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY4"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][3].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY5"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][4].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY6"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][5].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY7"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][6].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY8"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][7].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY9"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][8].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY10"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][9].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY11"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][10].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY12"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][11].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY13"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][12].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY14"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][13].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY15"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][14].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }

                    if (gc.FieldName.Equals("QTY16"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][15].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY17"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][16].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY18"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][17].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY19"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][18].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY20"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][19].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY21"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][20].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY22"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][21].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY23"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][22].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY24"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][23].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY25"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][24].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY26"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][25].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY27"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][26].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY28"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][27].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY29"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][28].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY30"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][29].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY31"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][30].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                }
            }

            gvList.EndUpdate();

            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();
            
        }
        
        #endregion
      
    }
}
