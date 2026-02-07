using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

using System.Collections.Generic;
using HAENGSUNG_HNSMES_UI.Class;
using HAENGSUNG_HNSMES_UI.WebService.Access;
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



using NGS.WCFClient.DatabaseService;



namespace HAENGSUNG_HNSMES_UI.Forms.MNT
{
    // 조회
    // 자재수불

    public partial class MNTB201 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {
        #region [Form Event]

        private int mSecond = 300;
        private int mSecond2 = 20;
        private int mSecond3 = 300;

        public MNTB201()
        {
            InitializeComponent();           
        }

        private void MNTB201_Load(object sender, EventArgs e)
        {
            dteDate.EditValue = DateTime.Now;
        }

        private void MNTB201_Shown(object sender, EventArgs e)
        {
            this.Set_init();
            //this.GetGridViewList();
        }
        

        #endregion

        #region [Button Event]

        public void InitButton_Click()
        {
            this.Set_init();
            //base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);
           
        }

        
        public void NewButton_Click()
        {
            // 신규 버튼 클릭 이벤트
        }

        
        public void EditButton_Click()
        {
            // 수정 버튼 클릭 이벤트
        }

       
        public void StopButton_Click()
        {
            // 중지 버튼 클릭 이벤트
        }

       
        public void SearchButton_Click()
        {
            // 검색 버튼 클릭 이벤트
            Set_init();
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

        private void Set_InitMemberList()
        {

        }

        private void Set_init()
        {
            WSResults result = BASE_db.Execute_Proc("PKGHNS_REPORT.GET_CUSTPLAN_MAXDATE",
                                                     1,
                                                     new string[] {
                                                                   "A_CLIENT",
                                                                   "A_COMPANY",
                                                                   "A_PLANT"
                                                                  },
                                                     new string[] {
                                                                   Global.Global_Variable.CLIENT,
                                                                   Global.Global_Variable.COMPANY,
                                                                   Global.Global_Variable.PLANT
                                                                  }
                                                   );

            if (result.ResultInt == 0)
            {
                txtMaxDate1.EditValue = result.ResultDataSet.Tables[0].Rows[0]["MAXDATE"].ObjectNullString();
                txtMaxDate2.EditValue = result.ResultDataSet.Tables[0].Rows[1]["MAXDATE"].ObjectNullString();
                txtMaxDate3.EditValue = result.ResultDataSet.Tables[0].Rows[2]["MAXDATE"].ObjectNullString();
            }
        }

        private void GetGridViewList()
        {
            string Tag = this.Tag.ObjectNullString();
            
            /// ****************** GridControl과 Bind Grid ***************
            /// 입력컨트롤과 GridControl의 바인딩은 필수적으로 BASE_DXGridHelper.Bind_Grid(...) 사용하도록 함.
            /// **********************************************************
            /// 

            WSResults result3 = BASE_db.Execute_Proc("PKGHNS_REPORT.GET_CUSTPLAN",
                                                     1,
                                                     new string[] {
                                                                    "A_CLIENT"
                                                                  , "A_COMPANY"
                                                                  , "A_PLANT"
                                                                  , "A_PLANDATE"
                                                                  },
                                                     new string[] {
                                                                     Global.Global_Variable.CLIENT
                                                                   , Global.Global_Variable.COMPANY
                                                                   , Global.Global_Variable.PLANT
                                                                   , dteDate.DateTime.ToString("yyyyMM")
                                                                  }
                                                   );

            if (result3.ResultInt == 0)
            {
                DataTable dt = null;

                dt = result3.ResultDataSet.Tables[0].Copy();

                int vToday = int.Parse(dt.Rows[0][4].ToString()); 

                for (int i = 1; i < vToday; i++)
                {
                    dt.Columns.Remove("D" + i.ToString());
                }

                for (int j = 6; j < dt.Columns.Count; j++)
                {
                    dt.Columns[j].ColumnName = "F" + j;
                }



                gvTemp.BeginUpdate();
                gvTemp.OptionsView.ShowAutoFilterRow = false;
                gvTemp.OptionsView.RowAutoHeight = true;

                gcTemp.DataSource = dt;                
            }

            gvTemp.EndUpdate();

            gvTemp.OptionsView.ColumnAutoWidth = false;
            gvTemp.BestFitColumns();

            DataTable dTable = (gcTemp.DataSource as DataTable).Copy();

            string _strXml = base.GetDataTableToXml(dTable);

            WSResults result2 = BASE_db.Execute_Proc("PKGHNS_REPORT.PUT_MAT_MONITOR",
                                                     1,
                                                     new string[] {
                                                                    "A_CLIENT"
                                                                  , "A_COMPANY"
                                                                  , "A_PLANT"
                                                                  , "A_DATE"
                                                                  , "A_XML"
                                                                  },
                                                     new string[] {
                                                                     Global.Global_Variable.CLIENT
                                                                   , Global.Global_Variable.COMPANY
                                                                   , Global.Global_Variable.PLANT
                                                                   , dteDate.DateTime.ToString("yyyyMM")
                                                                   , _strXml
                                                                  }
                                                   );

            if (result2.ResultInt != 0)
            {
                iDATMessageBox.ErrorMessage(result2.ResultString, this.Text, 3);
            }

            LanguageInformation m_clsLan = new LanguageInformation();
            SplashScreenManager.ShowForm(null, typeof(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM), true, true, false);
            SplashScreenManager.Default.SendCommand(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM.WaitFormCommand.SetCaption, m_clsLan.GetMessageString("MSG_WAIT_001"));
            SplashScreenManager.Default.SendCommand(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM.WaitFormCommand.SetDescription, m_clsLan.GetMessageString("SEARCHING"));

            WSResults result = BASE_db.Execute_Proc("PKGHNS_REPORT.GET_MAT_MONITOR",
                                                     1,
                                                     new string[] {
                                                                    "A_CLIENT"
                                                                  , "A_COMPANY"
                                                                  , "A_PLANT"
                                                                  , "A_DATE"
                                                                  , "A_FLAG"
                                                                  },
                                                     new string[] {
                                                                     Global.Global_Variable.CLIENT
                                                                   , Global.Global_Variable.COMPANY
                                                                   , Global.Global_Variable.PLANT
                                                                   , dteDate.DateTime.ToString("yyyyMM")
                                                                   , "MINUS"
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

            SplashScreenManager.CloseForm(true);

            gvList.EndUpdate();

            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();


            SplashScreenManager.ShowForm(null, typeof(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM), true, true, false);
            SplashScreenManager.Default.SendCommand(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM.WaitFormCommand.SetCaption, m_clsLan.GetMessageString("MSG_WAIT_001"));
            SplashScreenManager.Default.SendCommand(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM.WaitFormCommand.SetDescription, m_clsLan.GetMessageString("SEARCHING"));

            WSResults resultOver = BASE_db.Execute_Proc("PKGHNS_REPORT.GET_MAT_MONITOR",
                                                     1,
                                                     new string[] {
                                                                    "A_CLIENT"
                                                                  , "A_COMPANY"
                                                                  , "A_PLANT"
                                                                  , "A_DATE"
                                                                  , "A_FLAG"
                                                                  },
                                                     new string[] {
                                                                     Global.Global_Variable.CLIENT
                                                                   , Global.Global_Variable.COMPANY
                                                                   , Global.Global_Variable.PLANT
                                                                   , dteDate.DateTime.ToString("yyyyMM")
                                                                   , "OVER"
                                                                  }
                                                   );

            gcListOver.DataSource = null;
            gvListOver.Columns.Clear();

            if (resultOver.ResultInt == 0)
            {
                gvListOver.BeginUpdate();
                gvListOver.OptionsView.ShowAutoFilterRow = false;
                gvListOver.OptionsView.RowAutoHeight = true;

                gcListOver.DataSource = resultOver.ResultDataSet.Tables[0];

                foreach (GridColumn gc in gvListOver.Columns)
                {
                    if (gc.FieldName.IndexOf("PARTNO") > -1 || gc.FieldName.IndexOf("SPEC") > -1)
                    {
                        gc.Fixed = FixedStyle.Left;
                    }

                    gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                    if (gc.FieldName.Equals("QTY1"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][0].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][1].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][2].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][3].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][4].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][5].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][6].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][7].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][8].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][9].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][10].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][11].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][12].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][13].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][14].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][15].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][16].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][17].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][18].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][19].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][20].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][21].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][22].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][23].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][24].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][25].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][26].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][27].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][28].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][29].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][30].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][31].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][32].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][33].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][34].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][35].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][36].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][37].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][38].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][39].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][40].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][41].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][42].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][43].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][44].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][45].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][46].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][47].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][48].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][49].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][50].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][51].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][52].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][53].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][54].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][55].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][56].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][57].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][58].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][59].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][60].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][61].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][62].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][63].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][64].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][65].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][66].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][67].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][68].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][69].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][70].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][71].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][72].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][73].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][74].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][75].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][76].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][77].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][78].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][79].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][80].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][81].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][82].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][83].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][84].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][85].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][86].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][87].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][88].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][89].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][90].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][91].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][92].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][93].ObjectNullString();

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
                        gc.Caption = resultOver.ResultDataSet.Tables[1].Rows[0][94].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }

                }
            }

            SplashScreenManager.CloseForm(true);

            gvListOver.EndUpdate();

            gvListOver.OptionsView.ColumnAutoWidth = false;
            gvListOver.BestFitColumns();


            SplashScreenManager.ShowForm(null, typeof(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM), true, true, false);
            SplashScreenManager.Default.SendCommand(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM.WaitFormCommand.SetCaption, m_clsLan.GetMessageString("MSG_WAIT_001"));
            SplashScreenManager.Default.SendCommand(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM.WaitFormCommand.SetDescription, m_clsLan.GetMessageString("SEARCHING"));

            WSResults result1 = BASE_db.Execute_Proc("PKGHNS_REPORT.GET_MAT_MONITOR",
                                                    1,
                                                    new string[] {
                                                                    "A_CLIENT"
                                                                  , "A_COMPANY"
                                                                  , "A_PLANT"
                                                                  , "A_DATE"
                                                                  , "A_FLAG"
                                                                  },
                                                    new string[] {
                                                                     Global.Global_Variable.CLIENT
                                                                   , Global.Global_Variable.COMPANY
                                                                   , Global.Global_Variable.PLANT
                                                                   , dteDate.DateTime.ToString("yyyyMM")
                                                                   , "ALL"
                                                                  }
                                                  );

            gcListAll.DataSource = null;
            gvListAll.Columns.Clear();

            if (result1.ResultInt == 0)
            {
                gvListAll.BeginUpdate();
                gvListAll.OptionsView.ShowAutoFilterRow = false;
                gvListAll.OptionsView.RowAutoHeight = true;

                gcListAll.DataSource = result1.ResultDataSet.Tables[0];

                foreach (GridColumn gc in gvListAll.Columns)
                {
                    if (gc.FieldName.IndexOf("PARTNO") > -1 || gc.FieldName.IndexOf("SPEC") > -1)
                    {
                        gc.Fixed = FixedStyle.Left;
                    }

                    gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                    if (gc.FieldName.Equals("QTY1"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][0].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][1].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][2].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][3].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][4].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][5].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][6].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][7].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][8].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][9].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][10].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][11].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][12].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][13].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][14].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][15].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][16].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][17].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][18].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][19].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][20].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][21].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][22].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][23].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][24].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][25].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][26].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][27].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][28].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][29].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][30].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][31].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][32].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][33].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][34].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][35].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][36].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][37].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][38].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][39].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][40].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][41].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][42].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][43].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][44].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][45].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][46].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][47].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][48].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][49].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][50].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][51].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][52].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][53].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][54].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][55].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][56].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][57].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][58].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][59].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][60].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][61].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][62].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][63].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][64].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][65].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][66].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][67].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][68].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][69].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][70].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][71].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][72].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][73].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][74].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][75].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][76].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][77].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][78].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][79].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][80].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][81].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][82].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][83].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][84].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][85].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][86].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][87].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][88].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][89].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][90].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][91].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][92].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][93].ObjectNullString();

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
                        gc.Caption = result1.ResultDataSet.Tables[1].Rows[0][94].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                    }

                }
            }

            SplashScreenManager.CloseForm(true);

            gvListAll.EndUpdate();

            gvListAll.OptionsView.ColumnAutoWidth = false;
            gvListAll.BestFitColumns();

            

            

        }

        

        private void GetGridViewListRefresh()
        {
            
        }

        #endregion

        private void gvList_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
           
        }


        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            mSecond--;
            mSecond2--;
            mSecond3--;

            
            if (mSecond2 == 0)
            {
                //dteDate.EditValue = DateTime.Now;
                mSecond2 = 20;

                if (gvList.TopRowIndex + mSecond2 > gvList.RowCount)
                {
                    gvList.TopRowIndex = 0;
                    gvList.FocusedRowHandle = 0;
                }

                gvList.TopRowIndex = gvList.TopRowIndex + mSecond2;// gvList.RowCount - 1;
                gvList.FocusedRowHandle = gvList.FocusedRowHandle + mSecond2;// -1;


                if (gvListAll.TopRowIndex + mSecond2 > gvListAll.RowCount)
                {
                    gvListAll.TopRowIndex = 0;
                    gvListAll.FocusedRowHandle = 0;
                }

                gvListAll.TopRowIndex = gvListAll.TopRowIndex + mSecond2;// gvList.RowCount - 1;
                gvListAll.FocusedRowHandle = gvListAll.FocusedRowHandle + mSecond2;// -1;

                //디자인에서 1초마다 이벤트 호출하고 소스에서 1 * 50초마다 스크롤을 이동함
            }
            

            if (mSecond == 0)
            {
                dteDate.EditValue = DateTime.Now; 
                GetGridViewList();
                mSecond = 300;
                //디자인에서 1초마다 이벤트 호출하고 소스에서 1 * 100초마다 조회하게 됨
            }

            if (mSecond3 == 0)
            {
                if (tcgMain.SelectedTabPageIndex == 0)
                    tcgMain.SelectedTabPageIndex = 1;
                else if (tcgMain.SelectedTabPageIndex == 1)
                    tcgMain.SelectedTabPageIndex = 2;
                else if (tcgMain.SelectedTabPageIndex == 2)
                    tcgMain.SelectedTabPageIndex = 0;
                
                mSecond3 = 300;
            }

        }

        private void gvList_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == null || e.Column.AppearanceHeader.BackColor != Color.Red)
                return;
            e.Cache.FillRectangle(Color.Red, e.Bounds);
            e.Appearance.DrawString(e.Cache, e.Info.Caption, e.Info.CaptionRect);
            foreach (DevExpress.Utils.Drawing.DrawElementInfo info in e.Info.InnerElements)
            {
                if (!info.Visible) continue;
                DevExpress.Utils.Drawing.ObjectPainter.DrawObject(e.Cache, info.ElementPainter, info.ElementInfo);
            }
            e.Handled = true;
        }

        private void gvList_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {             
            GridView View = sender as GridView;

            if (e.RowHandle >= 0)
            {
                decimal iPassRate = 0;
                decimal iOnBoard = 0;


                if (e.Column.FieldName.Equals("QTY1"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Equals("QTY2"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Equals("QTY3"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Equals("QTY4"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Equals("QTY5"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Equals("QTY6"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Equals("QTY7"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Equals("QTY8"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Equals("QTY9"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Equals("QTY10"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY11"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY12"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY13"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY14"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY15"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY16"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY17"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY18"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY19"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY20"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY21"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY22"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY23"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY24"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY25"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY26"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY27"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY28"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY29"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY30"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY31"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY32"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY33"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY34"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY35"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY36"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY37"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY38"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY39"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY40"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY41"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY42"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY43"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY44"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY45"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY46"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY47"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY48"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY49"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY50"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY51"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY52"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY53"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY54"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY55"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY56"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY57"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY58"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY59"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY60"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY61"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY62"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY63"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY64"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY65"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY66"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY67"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY68"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY69"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY70"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY71"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY72"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY73"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY74"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY75"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY76"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY77"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY78"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY79"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY80"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY81"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY82"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY83"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY84"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY85"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY86"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY87"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY88"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY89"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY90"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY91"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY92"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY93"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY94"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY95"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
            }
       
        }

        private void gvListAll_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == null || e.Column.AppearanceHeader.BackColor != Color.Red)
                return;
            e.Cache.FillRectangle(Color.Red, e.Bounds);
            e.Appearance.DrawString(e.Cache, e.Info.Caption, e.Info.CaptionRect);
            foreach (DevExpress.Utils.Drawing.DrawElementInfo info in e.Info.InnerElements)
            {
                if (!info.Visible) continue;
                DevExpress.Utils.Drawing.ObjectPainter.DrawObject(e.Cache, info.ElementPainter, info.ElementInfo);
            }
            e.Handled = true;
        }

        private void gvListAll_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;

            if (e.RowHandle >= 0)
            {
                decimal iPassRate = 0;
                decimal iOnBoard = 0;


                if (e.Column.FieldName.Equals("QTY1"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Equals("QTY2"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Equals("QTY3"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Equals("QTY4"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Equals("QTY5"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Equals("QTY6"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Equals("QTY7"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Equals("QTY8"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Equals("QTY9"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Equals("QTY10"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY11"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY12"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY13"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY14"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY15"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY16"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY17"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY18"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY19"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY20"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY21"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY22"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY23"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY24"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY25"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY26"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY27"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY28"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY29"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY30"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY31"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY32"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY33"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY34"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY35"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY36"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY37"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY38"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY39"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY40"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY41"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY42"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY43"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY44"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY45"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY46"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY47"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY48"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY49"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY50"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY51"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY52"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY53"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY54"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY55"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY56"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY57"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY58"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY59"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY60"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY61"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY62"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY63"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY64"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY65"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY66"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY67"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY68"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY69"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY70"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY71"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY72"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY73"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY74"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY75"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY76"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY77"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY78"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY79"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY80"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY81"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY82"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY83"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY84"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY85"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY86"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY87"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY88"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY89"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY90"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY91"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY92"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY93"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY94"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                if (e.Column.FieldName.Contains("QTY95"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["QTYONBOARD"]).ObjectNullString(), out iOnBoard);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                        if (iPassRate + iOnBoard >= 0)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                }
            }
        }

        private void gcList_DoubleClick(object sender, EventArgs e)
        {
            string vPartNo = gvList.GetFocusedRowCellValue("PARTNO").ObjectNullString();

            if (vPartNo != null)
            {
                using (PopUp.MNTB201_POPUP pop = new PopUp.MNTB201_POPUP())
                {
                    pop.txtDate.EditValue = dteDate.DateTime.ToString("yyyyMM");
                    pop.txtPartNo.EditValue = vPartNo;
                    pop.ShowDialog(this);
                }

            }            
        }

        private void gcListAll_DoubleClick(object sender, EventArgs e)
        {
            string vPartNo = gvListAll.GetFocusedRowCellValue("PARTNO").ObjectNullString();

            if (vPartNo != null)
            {
                using (PopUp.MNTB201_POPUP pop = new PopUp.MNTB201_POPUP())
                {
                    pop.txtDate.EditValue = dteDate.DateTime.ToString("yyyyMM");
                    pop.txtPartNo.EditValue = vPartNo;
                    pop.ShowDialog(this);
                }

            }
        }

        private void gcListOver_DoubleClick(object sender, EventArgs e)
        {
            string vPartNo = gvListOver.GetFocusedRowCellValue("PARTNO").ObjectNullString();

            if (vPartNo != null)
            {
                using (PopUp.MNTB201_POPUP pop = new PopUp.MNTB201_POPUP())
                {
                    pop.txtDate.EditValue = dteDate.DateTime.ToString("yyyyMM");
                    pop.txtPartNo.EditValue = vPartNo;
                    pop.ShowDialog(this);
                }

            }
        }

       
        

    }
}


