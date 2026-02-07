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
    public partial class MNTB201_POPUP : BASE.Form
    {

        private MNTB201 mParent = null;

        public MNTB201 _ParentForm
        {
            get { return mParent; }
            set { mParent = value; }
        }

        public MNTB201_POPUP()
        {
            InitializeComponent();
        }

        private void MNTB201_POPUP_Load(object sender, EventArgs e)
        {

        }

        private void MNTB201_POPUP_Shown(object sender, EventArgs e)
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

            WSResults result = BASE_db.Execute_Proc("PKGHNS_REPORT.GET_MAT_CUSTPLAN",
                                                     1,
                                                     new string[] {
                                                                    "A_CLIENT"
                                                                  , "A_COMPANY"
                                                                  , "A_PLANT"
                                                                  , "A_PLANDATE"
                                                                  , "A_PARTNO"
                                                                  },
                                                     new string[] {
                                                                     Global.Global_Variable.CLIENT
                                                                   , Global.Global_Variable.COMPANY
                                                                   , Global.Global_Variable.PLANT
                                                                   , txtDate.EditValue.ObjectNullString()
                                                                   , txtPartNo.EditValue.ObjectNullString()
                                                                  }
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
                    if (gc.FieldName.Equals("QTY32"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][31].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY33"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][32].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY34"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][33].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY35"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][34].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY36"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][35].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY37"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][36].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY38"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][37].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY39"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][38].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY40"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][39].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY41"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][40].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY42"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][41].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY43"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][42].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY44"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][43].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY45"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][44].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.Equals("QTY46"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][45].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY47") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][46].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY48") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][47].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY49") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][48].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY50") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][49].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY51") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][50].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY52") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][51].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY53") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][52].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY54") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][53].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY55") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][54].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY56") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][55].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY57") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][56].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY58") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][57].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY59") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][58].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY60") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][59].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY61") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][60].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY62") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][61].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY63") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][62].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY64") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][63].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY65") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][64].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY66") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][65].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY67") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][66].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY68") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][67].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY69") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][68].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY70") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][69].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY71") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][70].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY72") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][71].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY73") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][72].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY74") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][73].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY75") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][74].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY76") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][75].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY77") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][76].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY78") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][77].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY79") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][78].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY80") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][79].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY81") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][80].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY82") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][81].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY83") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][82].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY84") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][83].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY85") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][84].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY86") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][85].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY87") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][86].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY88") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][87].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY89") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][88].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY90") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][89].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY91") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][90].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY92") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][91].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY93") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][92].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY94") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][93].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }
                    if (gc.FieldName.IndexOf("QTY95") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][94].ObjectNullString();

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
