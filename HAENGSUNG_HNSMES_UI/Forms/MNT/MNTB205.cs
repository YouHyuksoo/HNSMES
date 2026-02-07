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
using DevExpress.XtraCharts;

using GridAlias = DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using NGS.WCFClient.DatabaseService;
using DevExpress.XtraGrid;
using DevExpress.XtraSplashScreen;

namespace HAENGSUNG_HNSMES_UI.Forms.MNT
{
    // 조회
    // 자재수불

    public partial class MNTB205 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {
        #region [Form Event]

        private readonly int mFontSize = 14;
        private int mSecond = 300;
        private int mSecond2 = 20;
        private int mSecond3 = 100;


        public MNTB205()
        {
            InitializeComponent();           
        }

        private void MNTB205_Load(object sender, EventArgs e)
        {

        }

        private void MNTB205_Shown(object sender, EventArgs e)
        {
            tcgMain.SelectedTabPageIndex = 0;
            this.Set_init();
            GetGridViewList();
        }
        

        #endregion

        #region [Button Event]

        public void InitButton_Click()
        {
            this.Set_init();           
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
            
        }
        
        private void GetGridViewList()
        {
            LanguageInformation m_clsLan = new LanguageInformation();
            SplashScreenManager.ShowForm(null, typeof(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM), true, true, false);
            SplashScreenManager.Default.SendCommand(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM.WaitFormCommand.SetCaption, m_clsLan.GetMessageString("MSG_WAIT_001"));
            SplashScreenManager.Default.SendCommand(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM.WaitFormCommand.SetDescription, m_clsLan.GetMessageString("SEARCHING"));

            if (tcgMain.SelectedTabPageIndex == 0)
            {

                WSResults result = BASE_db.Execute_Proc("PKGHNS_REPORT.GET_LQC_MONITOR1",
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
                                                                   , "1"
                                                                   , "1"
                                                                  }
                                                       );


                if (result.ResultInt == 0)
                {
                    SetChartData(result.ResultDataSet.Tables[0]);
                }

                WSResults result1 = BASE_db.Execute_Proc("PKGHNS_REPORT.GET_LQC_MONITOR1",
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
                                                                   , "1"
                                                                   , "2"
                                                                  }
                                                       );


                if (result1.ResultInt == 0)
                {
                    gcList.DataSource = result1.ResultDataSet.Tables[0];

                    gvList.Appearance.FooterPanel.Font = new Font(gvList.Appearance.FooterPanel.Font.Name, mFontSize - 4, FontStyle.Bold);
                    gvList.Appearance.Row.Font = new Font(gvList.Appearance.FooterPanel.Font.Name, mFontSize - 4, FontStyle.Bold);

                    foreach (GridColumn gc in gvList.Columns)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.AppearanceHeader.Font = new System.Drawing.Font(gc.AppearanceHeader.Font.Name, mFontSize - 4, FontStyle.Bold);
                    }

                    gvList.OptionsView.ShowFooter = false;
                    gvList.OptionsView.ColumnAutoWidth = true;
                    gvList.BestFitColumns();
                }
            }

            if (tcgMain.SelectedTabPageIndex == 1)
            {

                WSResults result2 = BASE_db.Execute_Proc("PKGHNS_REPORT.GET_LQC_MONITOR2",
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
                                                                   , "1"
                                                                   , "1"
                                                                  }
                                                       );


                if (result2.ResultInt == 0)
                {
                    gcList1.DataSource = result2.ResultDataSet.Tables[0];

                    gvList1.Appearance.FooterPanel.Font = new Font(gvList1.Appearance.FooterPanel.Font.Name, mFontSize - 2, FontStyle.Bold);
                    gvList1.Appearance.Row.Font = new Font(gvList1.Appearance.FooterPanel.Font.Name, mFontSize - 4, FontStyle.Bold);


                    foreach (GridColumn gc in gvList1.Columns)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.AppearanceHeader.Font = new System.Drawing.Font(gc.AppearanceHeader.Font.Name, mFontSize - 2, FontStyle.Bold);

                        if (gc.FieldName.IndexOf("PRODQTY") > -1)
                        {
                            gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                        }

                        if (gc.FieldName.IndexOf("PPM") > -1)
                        {
                            gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                        }

                        if (gc.FieldName.IndexOf("ACCRATIO") > -1)
                        {
                            gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                        }

                        if (gc.FieldName.IndexOf("QTYTEMP") > -1)
                        {
                            gc.Visible = false;
                        }

                        if (gc.FieldName.IndexOf("BRD") > -1)
                        {
                            gc.Visible = false;
                        }

                    }


                    gvList1.Columns["PRODQTY"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                    gvList1.Columns["PRODQTY"].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gvList1.Columns["PRODQTY"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

                    gvList1.OptionsView.ShowFooter = true;
                    gvList1.OptionsView.ColumnAutoWidth = true;
                    gvList1.BestFitColumns();

                    try
                    {
                        if (result2.ResultDataSet.Tables[1].Rows[0]["DEFECT"].ObjectNullString().Length > 0)
                        {
                            idt1.Text = result2.ResultDataSet.Tables[1].Rows[0]["DEFECTNAME"].ObjectNullString();
                            idt2.Text = result2.ResultDataSet.Tables[1].Rows[0]["RATIO"].ObjectNullString();
                        }

                        if (result2.ResultDataSet.Tables[1].Rows[0]["IMAGE"].ObjectNullString().Length > 0)
                        {
                            var data = (Byte[])result2.ResultDataSet.Tables[1].Rows[0]["IMAGE"];

                            if (data != null)
                            {
                                var stream = new MemoryStream(data);
                                idatDxPictureEdit1.Image = Image.FromStream(stream);
                            }
                        }

                        if (result2.ResultDataSet.Tables[1].Rows[1]["DEFECT"].ObjectNullString().Length > 0)
                        {
                            idt3.Text = result2.ResultDataSet.Tables[1].Rows[1]["DEFECTNAME"].ObjectNullString();
                            idt4.Text = result2.ResultDataSet.Tables[1].Rows[1]["RATIO"].ObjectNullString();
                        }

                        if (result2.ResultDataSet.Tables[1].Rows[1]["IMAGE"].ObjectNullString().Length > 0)
                        {
                            var data = (Byte[])result2.ResultDataSet.Tables[1].Rows[1]["IMAGE"];

                            if (data != null)
                            {
                                var stream = new MemoryStream(data);
                                idatDxPictureEdit2.Image = Image.FromStream(stream);
                            }

                            idt3.Text = result2.ResultDataSet.Tables[1].Rows[1]["DEFECTNAME"].ObjectNullString();
                            idt4.Text = result2.ResultDataSet.Tables[1].Rows[1]["RATIO"].ObjectNullString();
                        }


                        if (result2.ResultDataSet.Tables[1].Rows[2]["DEFECT"].ObjectNullString().Length > 0)
                        {
                            idt5.Text = result2.ResultDataSet.Tables[1].Rows[2]["DEFECTNAME"].ObjectNullString();
                            idt6.Text = result2.ResultDataSet.Tables[1].Rows[2]["RATIO"].ObjectNullString();
                        }

                        if (result2.ResultDataSet.Tables[1].Rows[2]["IMAGE"].ObjectNullString().Length > 0)
                        {
                            var data = (Byte[])result2.ResultDataSet.Tables[1].Rows[2]["IMAGE"];

                            if (data != null)
                            {
                                var stream = new MemoryStream(data);
                                idatDxPictureEdit3.Image = Image.FromStream(stream);
                            }

                            idt5.Text = result2.ResultDataSet.Tables[1].Rows[2]["DEFECTNAME"].ObjectNullString();
                            idt6.Text = result2.ResultDataSet.Tables[1].Rows[2]["RATIO"].ObjectNullString();
                        }
                    }
                    catch(Exception)
                    {

                    }


                    SetChartData2(result2.ResultDataSet.Tables[0]);
                }

            }


            if (tcgMain.SelectedTabPageIndex == 2)
            {
                WSResults result3 = BASE_db.Execute_Proc("PKGHNS_REPORT.GET_LQC_MONITOR3",
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
                                                                   , "1"
                                                                   , "1"
                                                                  }
                                                       );


                if (result3.ResultInt == 0)
                {
                    gcList2.DataSource = result3.ResultDataSet.Tables[0];

                    gvList2.Appearance.FooterPanel.Font = new Font(gvList2.Appearance.FooterPanel.Font.Name, mFontSize - 2, FontStyle.Bold);
                    gvList2.Appearance.Row.Font = new Font(gvList2.Appearance.FooterPanel.Font.Name, mFontSize - 4, FontStyle.Bold);


                    foreach (GridColumn gc in gvList2.Columns)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.AppearanceHeader.Font = new System.Drawing.Font(gc.AppearanceHeader.Font.Name, mFontSize - 2, FontStyle.Bold);
                    }

                    gvList2.OptionsView.ShowFooter = false;
                    gvList2.OptionsView.ColumnAutoWidth = true;
                    gvList2.BestFitColumns();

                    WSResults result4 = BASE_db.Execute_Proc("PKGHNS_REPORT.GET_LQC_MONITOR3",
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
                                                                   , "1"
                                                                   , "2"
                                                                  }
                                                           );


                    if (result4.ResultInt == 0)
                    {
                        SetChartData3(result4.ResultDataSet.Tables[0], result4.ResultDataSet.Tables[1]);
                    }
                }
            }

            if (tcgMain.SelectedTabPageIndex == 3)
            {

                WSResults result5 = BASE_db.Execute_Proc("PKGHNS_REPORT.GET_LQC_MONITOR4",
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
                                                                   , "1"
                                                                   , "1"
                                                                  }
                                                       );


                if (result5.ResultInt == 0)
                {
                    gcList3.DataSource = result5.ResultDataSet.Tables[0];

                    //gvList3.Appearance.FooterPanel.Font = new Font(gvList3.Appearance.FooterPanel.Font.Name, mFontSize - 2, FontStyle.Bold);
                    gvList3.Appearance.Row.Font = new Font(gvList3.Appearance.FooterPanel.Font.Name, mFontSize - 4, FontStyle.Bold);


                    foreach (GridColumn gc in gvList3.Columns)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.AppearanceHeader.Font = new System.Drawing.Font(gc.AppearanceHeader.Font.Name, mFontSize - 4, FontStyle.Bold);

                        if (gc.FieldName.Equals("MQTY1"))
                        {
                            gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gc.Caption = result5.ResultDataSet.Tables[1].Rows[0][0].ObjectNullString();
                        }
                        if (gc.FieldName.Equals("MQTY2"))
                        {
                            gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gc.Caption = result5.ResultDataSet.Tables[1].Rows[0][1].ObjectNullString();
                        }
                        if (gc.FieldName.Equals("MQTY3"))
                        {
                            gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gc.Caption = result5.ResultDataSet.Tables[1].Rows[0][2].ObjectNullString();
                        }
                        if (gc.FieldName.Equals("WQTY1"))
                        {
                            gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gc.Caption = result5.ResultDataSet.Tables[1].Rows[0][3].ObjectNullString();
                        }
                        if (gc.FieldName.Equals("WQTY2"))
                        {
                            gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gc.Caption = result5.ResultDataSet.Tables[1].Rows[0][4].ObjectNullString();
                        }
                        if (gc.FieldName.Equals("WQTY3"))
                        {
                            gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gc.Caption = result5.ResultDataSet.Tables[1].Rows[0][5].ObjectNullString();
                        }
                        if (gc.FieldName.Equals("WQTY4"))
                        {
                            gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gc.Caption = result5.ResultDataSet.Tables[1].Rows[0][6].ObjectNullString();
                        }
                        if (gc.FieldName.Equals("WQTY5"))
                        {
                            gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gc.Caption = result5.ResultDataSet.Tables[1].Rows[0][7].ObjectNullString();
                        }
                        if (gc.FieldName.Equals("DQTY1"))
                        {
                            gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gc.Caption = result5.ResultDataSet.Tables[1].Rows[0][8].ObjectNullString();
                        }
                        if (gc.FieldName.Equals("DQTY2"))
                        {
                            gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gc.Caption = result5.ResultDataSet.Tables[1].Rows[0][9].ObjectNullString();
                        }
                        if (gc.FieldName.Equals("DQTY3"))
                        {
                            gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gc.Caption = result5.ResultDataSet.Tables[1].Rows[0][10].ObjectNullString();
                        }
                        if (gc.FieldName.Equals("DQTY4"))
                        {
                            gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gc.Caption = result5.ResultDataSet.Tables[1].Rows[0][11].ObjectNullString();
                        }
                        if (gc.FieldName.Equals("DQTY5"))
                        {
                            gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gc.Caption = result5.ResultDataSet.Tables[1].Rows[0][12].ObjectNullString();
                        }
                        if (gc.FieldName.Equals("DQTY6"))
                        {
                            gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gc.Caption = result5.ResultDataSet.Tables[1].Rows[0][13].ObjectNullString();
                        }
                    }

                    gvList3.OptionsView.ShowFooter = false;
                    gvList3.OptionsView.ColumnAutoWidth = true;
                    gvList3.BestFitColumns();

                }


                WSResults result6 = BASE_db.Execute_Proc("PKGHNS_REPORT.GET_LQC_MONITOR4",
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
                                                                   , "1"
                                                                   , "2"
                                                                  }
                                                       );


                if (result6.ResultInt == 0)
                {
                    gcList4.DataSource = result6.ResultDataSet.Tables[0];

                    gvList4.Appearance.FooterPanel.Font = new Font(gvList4.Appearance.FooterPanel.Font.Name, mFontSize - 4, FontStyle.Bold);
                    gvList4.Appearance.Row.Font = new Font(gvList4.Appearance.FooterPanel.Font.Name, mFontSize - 4, FontStyle.Bold);


                    foreach (GridColumn gc in gvList4.Columns)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.AppearanceHeader.Font = new System.Drawing.Font(gc.AppearanceHeader.Font.Name, mFontSize - 4, FontStyle.Bold);

                        if (gc.FieldName.Equals("MQTY1"))
                        {
                            gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gc.Caption = result6.ResultDataSet.Tables[1].Rows[0][0].ObjectNullString();
                        }
                        if (gc.FieldName.Equals("MQTY2"))
                        {
                            gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gc.Caption = result6.ResultDataSet.Tables[1].Rows[0][1].ObjectNullString();
                        }
                        if (gc.FieldName.Equals("MQTY3"))
                        {
                            gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gc.Caption = result6.ResultDataSet.Tables[1].Rows[0][2].ObjectNullString();
                        }
                        if (gc.FieldName.Equals("WQTY1"))
                        {
                            gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gc.Caption = result6.ResultDataSet.Tables[1].Rows[0][3].ObjectNullString();
                        }
                        if (gc.FieldName.Equals("WQTY2"))
                        {
                            gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gc.Caption = result6.ResultDataSet.Tables[1].Rows[0][4].ObjectNullString();
                        }
                        if (gc.FieldName.Equals("WQTY3"))
                        {
                            gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gc.Caption = result6.ResultDataSet.Tables[1].Rows[0][5].ObjectNullString();
                        }
                        if (gc.FieldName.Equals("WQTY4"))
                        {
                            gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gc.Caption = result6.ResultDataSet.Tables[1].Rows[0][6].ObjectNullString();
                        }
                        if (gc.FieldName.Equals("WQTY5"))
                        {
                            gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gc.Caption = result6.ResultDataSet.Tables[1].Rows[0][7].ObjectNullString();
                        }
                        if (gc.FieldName.Equals("DQTY1"))
                        {
                            gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gc.Caption = result6.ResultDataSet.Tables[1].Rows[0][8].ObjectNullString();
                        }
                        if (gc.FieldName.Equals("DQTY2"))
                        {
                            gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gc.Caption = result6.ResultDataSet.Tables[1].Rows[0][9].ObjectNullString();
                        }
                        if (gc.FieldName.Equals("DQTY3"))
                        {
                            gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gc.Caption = result6.ResultDataSet.Tables[1].Rows[0][10].ObjectNullString();
                        }
                        if (gc.FieldName.Equals("DQTY4"))
                        {
                            gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gc.Caption = result6.ResultDataSet.Tables[1].Rows[0][11].ObjectNullString();
                        }
                        if (gc.FieldName.Equals("DQTY5"))
                        {
                            gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gc.Caption = result6.ResultDataSet.Tables[1].Rows[0][12].ObjectNullString();
                        }
                        if (gc.FieldName.Equals("DQTY6"))
                        {
                            gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            gc.Caption = result6.ResultDataSet.Tables[1].Rows[0][13].ObjectNullString();
                        }
                    }
                    gvList4.OptionsView.ShowFooter = true;
                    gvList4.OptionsView.ColumnAutoWidth = true;
                    gvList4.BestFitColumns();

                }

                WSResults result7 = BASE_db.Execute_Proc("PKGHNS_REPORT.GET_LQC_MONITOR4",
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
                                                                   , "1"
                                                                   , "3"
                                                                  }
                                                       );


                if (result7.ResultInt == 0)
                {
                    SetChartData4(result7.ResultDataSet.Tables[0]);
                }
            }

            if (tcgMain.SelectedTabPageIndex == 4)
            {
                WSResults result8 = BASE_db.Execute_Proc("PKGHNS_REPORT.GET_LQC_MONITOR5",
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
                                                                   , "1"
                                                                   , "1"
                                                                  }
                                                       );


                if (result8.ResultInt == 0)
                {
                    gcList5.DataSource = result8.ResultDataSet.Tables[0];

                    gvList5.Appearance.FooterPanel.Font = new Font(gvList5.Appearance.FooterPanel.Font.Name, mFontSize - 4, FontStyle.Bold);
                    gvList5.Appearance.Row.Font = new Font(gvList5.Appearance.FooterPanel.Font.Name, mFontSize - 4, FontStyle.Bold);

                    foreach (GridColumn gc in gvList5.Columns)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.AppearanceHeader.Font = new System.Drawing.Font(gc.AppearanceHeader.Font.Name, mFontSize - 4, FontStyle.Bold);

                        gvList5.Columns["WORKTIME"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        gvList5.Columns["WORKTIME"].DisplayFormat.FormatString = "{0:n2}";

                        gvList5.Columns["UPH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        gvList5.Columns["UPH"].DisplayFormat.FormatString = "{0:n2}";
                    }

                    gvList5.OptionsView.ShowFooter = false;
                    gvList5.OptionsView.ColumnAutoWidth = true;
                    gvList5.BestFitColumns();
                }
            }

            SplashScreenManager.CloseForm(true);
        }



        private void SetChartData(DataTable _dt)
        {
            chtMainItem1.Series["TOTAL"].Points.Clear();
            chtMainItem1.Series["1"].Points.Clear();
            chtMainItem1.Series["2"].Points.Clear();
            chtMainItem1.Series["3"].Points.Clear();
            chtMainItem1.Series["4"].Points.Clear();
            chtMainItem1.Series["5"].Points.Clear();
            chtMainItem1.Series["6"].Points.Clear();

            chtMainItem1.Series["TARGET"].ArgumentScaleType = ScaleType.Qualitative;
            chtMainItem1.Series["TARGET"].ValueScaleType = ScaleType.Numerical;

            chtMainItem1.Series["TOTAL"].ArgumentScaleType = ScaleType.Qualitative;
            chtMainItem1.Series["TOTAL"].ValueScaleType = ScaleType.Numerical;

            chtMainItem1.Series["1"].ArgumentScaleType = ScaleType.Qualitative;
            chtMainItem1.Series["1"].ValueScaleType = ScaleType.Numerical;

            chtMainItem1.Series["2"].ArgumentScaleType = ScaleType.Qualitative;
            chtMainItem1.Series["2"].ValueScaleType = ScaleType.Numerical;

            chtMainItem1.Series["3"].ArgumentScaleType = ScaleType.Qualitative;
            chtMainItem1.Series["3"].ValueScaleType = ScaleType.Numerical;

            chtMainItem1.Series["4"].ArgumentScaleType = ScaleType.Qualitative;
            chtMainItem1.Series["4"].ValueScaleType = ScaleType.Numerical;

            chtMainItem1.Series["5"].ArgumentScaleType = ScaleType.Qualitative;
            chtMainItem1.Series["5"].ValueScaleType = ScaleType.Numerical;

            chtMainItem1.Series["6"].ArgumentScaleType = ScaleType.Qualitative;
            chtMainItem1.Series["6"].ValueScaleType = ScaleType.Numerical;


            foreach (DataRow dr in _dt.Select("UNITNO = 'TARGET'"))
            {
                double _value1 = 0;
                if (dr["BADRATE"].ObjectNullString() != "") _value1 = Convert.ToDouble(dr["BADRATE"]);

                DevExpress.XtraCharts.SeriesPoint sp1 = new DevExpress.XtraCharts.SeriesPoint
                {
                    Argument = dr["WORKTIME"] + "",
                    Values = new double[] { _value1 }
                };

                chtMainItem1.Series["TARGET"].Points.Add(sp1);

            }

            foreach (DataRow dr in _dt.Select("UNITNO = 'TOTAL'"))
            {
                double _value1 = 0;
                if (dr["BADRATE"].ObjectNullString() != "") _value1 = Convert.ToDouble(dr["BADRATE"]);

                DevExpress.XtraCharts.SeriesPoint sp1 = new DevExpress.XtraCharts.SeriesPoint
                {
                    Argument = dr["WORKTIME"] + "",
                    Values = new double[] { _value1 }
                };

                chtMainItem1.Series["TOTAL"].Points.Add(sp1);

            }

            foreach (DataRow dr in _dt.Select("UNITNO = '1'"))
            {
                double _value1 = 0;
                if (dr["BADRATE"].ObjectNullString() != "") _value1 = Convert.ToDouble(dr["BADRATE"]);

                DevExpress.XtraCharts.SeriesPoint sp1 = new DevExpress.XtraCharts.SeriesPoint
                {
                    Argument = dr["WORKTIME"] + "",
                    Values = new double[] { _value1 }
                };

                chtMainItem1.Series["1"].Points.Add(sp1);

            }

            foreach (DataRow dr in _dt.Select("UNITNO = '2'"))
            {
                double _value1 = 0;
                if (dr["BADRATE"].ObjectNullString() != "") _value1 = Convert.ToDouble(dr["BADRATE"]);

                DevExpress.XtraCharts.SeriesPoint sp1 = new DevExpress.XtraCharts.SeriesPoint
                {
                    Argument = dr["WORKTIME"] + "",
                    Values = new double[] { _value1 }
                };

                chtMainItem1.Series["2"].Points.Add(sp1);

            }

            foreach (DataRow dr in _dt.Select("UNITNO = '3'"))
            {
                double _value1 = 0;
                if (dr["BADRATE"].ObjectNullString() != "") _value1 = Convert.ToDouble(dr["BADRATE"]);

                DevExpress.XtraCharts.SeriesPoint sp1 = new DevExpress.XtraCharts.SeriesPoint
                {
                    Argument = dr["WORKTIME"] + "",
                    Values = new double[] { _value1 }
                };

                chtMainItem1.Series["3"].Points.Add(sp1);

            }

            foreach (DataRow dr in _dt.Select("UNITNO = '4'"))
            {
                double _value1 = 0;
                if (dr["BADRATE"].ObjectNullString() != "") _value1 = Convert.ToDouble(dr["BADRATE"]);

                DevExpress.XtraCharts.SeriesPoint sp1 = new DevExpress.XtraCharts.SeriesPoint
                {
                    Argument = dr["WORKTIME"] + "",
                    Values = new double[] { _value1 }
                };

                chtMainItem1.Series["4"].Points.Add(sp1);

            }

            foreach (DataRow dr in _dt.Select("UNITNO = '5'"))
            {
                double _value1 = 0;
                if (dr["BADRATE"].ObjectNullString() != "") _value1 = Convert.ToDouble(dr["BADRATE"]);

                DevExpress.XtraCharts.SeriesPoint sp1 = new DevExpress.XtraCharts.SeriesPoint
                {
                    Argument = dr["WORKTIME"] + "",
                    Values = new double[] { _value1 }
                };

                chtMainItem1.Series["5"].Points.Add(sp1);

            }

            foreach (DataRow dr in _dt.Select("UNITNO = '6'"))
            {
                double _value1 = 0;
                if (dr["BADRATE"].ObjectNullString() != "") _value1 = Convert.ToDouble(dr["BADRATE"]);

                DevExpress.XtraCharts.SeriesPoint sp1 = new DevExpress.XtraCharts.SeriesPoint
                {
                    Argument = dr["WORKTIME"] + "",
                    Values = new double[] { _value1 }
                };

                chtMainItem1.Series["6"].Points.Add(sp1);

            }

        }


        private void SetChartData2(DataTable _dt)
        {




            chtMainItem2.Series["PPM"].Points.Clear();
            chtMainItem2.Series["RATIO"].Points.Clear();

            chtMainItem2.Series["PPM"].ArgumentScaleType = ScaleType.Qualitative;
            chtMainItem2.Series["RATIO"].ValueScaleType = ScaleType.Numerical;

            chtMainItem2.Series["PPM"].ArgumentScaleType = ScaleType.Qualitative;
            chtMainItem2.Series["RATIO"].ValueScaleType = ScaleType.Numerical;

            foreach (DataRow dr in _dt.Rows)
            {
                double _value1 = 0;
                if (dr["PPM"].ObjectNullString() != "") _value1 = Convert.ToDouble(dr["PPM"]);

                DevExpress.XtraCharts.SeriesPoint sp1 = new DevExpress.XtraCharts.SeriesPoint
                {
                    Argument = dr["DEFECTNAME"] + "",
                    Values = new double[] { _value1 }
                };

                chtMainItem2.Series["PPM"].Points.Add(sp1);
            }

            chtMainItem2.Series["RATIO"].Points.Clear();

            if (((XYDiagram)chtMainItem2.Diagram).SecondaryAxesY.Count > 0)
            {
                ((XYDiagram)chtMainItem2.Diagram).SecondaryAxesY.RemoveAt(0);
            }

            SecondaryAxisY myAxisY = new SecondaryAxisY("ACCRATIO");
            ((XYDiagram)chtMainItem2.Diagram).SecondaryAxesY.Add(myAxisY);
            ((LineSeriesView)chtMainItem2.Series["RATIO"].View).AxisY = myAxisY;
            //myAxisY.Title.Visible = true;
            myAxisY.Color = Color.Black;

            foreach (DataRow dr in _dt.Rows)
            {
                double _value1 = 0;
                if (dr["ACCRATIO"].ObjectNullString() != "") _value1 = Convert.ToDouble(dr["ACCRATIO"]);

                DevExpress.XtraCharts.SeriesPoint sp1 = new DevExpress.XtraCharts.SeriesPoint
                {
                    Argument = dr["DEFECTNAME"] + "",
                    Values = new double[] { _value1 }
                };

                chtMainItem2.Series["RATIO"].Points.Add(sp1);
            }

        }


        private void SetChartData3(DataTable _dt, DataTable _dt1)
        {




            chtMainItem3.Series["Series 1"].Points.Clear();
            chtMainItem3.Series["Series 2"].Points.Clear();
            chtMainItem3.Series["Series 3"].Points.Clear();

            chtMainItem3.Series["Series 1"].ArgumentScaleType = ScaleType.Qualitative;
            chtMainItem3.Series["Series 1"].ValueScaleType = ScaleType.Numerical;

            chtMainItem3.Series["Series 2"].ArgumentScaleType = ScaleType.Qualitative;
            chtMainItem3.Series["Series 2"].ValueScaleType = ScaleType.Numerical;

            chtMainItem3.Series["Series 3"].ArgumentScaleType = ScaleType.Qualitative;
            chtMainItem3.Series["Series 3"].ValueScaleType = ScaleType.Numerical;
            
            //chtMainItem3.Series.Add(new Series("DEFECTNAME", ViewType.Line));

            var vDefectName1 = _dt1.Rows[0]["DEFECTNAME"].ObjectNullString();
            var vDefectName2 = _dt1.Rows[1]["DEFECTNAME"].ObjectNullString();
            var vDefectName3 = _dt1.Rows[2]["DEFECTNAME"].ObjectNullString();

            
            foreach (DataRow dr in _dt.Select("DEFECTNAME = '"+vDefectName1+"'"))
            {
                double _value1 = 0;
                if (dr["PPM"].ObjectNullString() != "") _value1 = Convert.ToDouble(dr["PPM"]);

                DevExpress.XtraCharts.SeriesPoint sp1 = new DevExpress.XtraCharts.SeriesPoint
                {
                    Argument = dr["REALDATE"] + "",
                    Values = new double[] { _value1 }
                };

                chtMainItem3.Series["Series 1"].Points.Add(sp1);

                chtMainItem3.Series["Series 1"].LegendText = dr["DEFECTNAME"].ObjectNullString();
            }

            foreach (DataRow dr in _dt.Select("DEFECTNAME = '" + vDefectName2 + "'"))
            {
                double _value1 = 0;
                if (dr["PPM"].ObjectNullString() != "") _value1 = Convert.ToDouble(dr["PPM"]);

                DevExpress.XtraCharts.SeriesPoint sp1 = new DevExpress.XtraCharts.SeriesPoint
                {
                    Argument = dr["REALDATE"] + "",
                    Values = new double[] { _value1 }
                };

                chtMainItem3.Series["Series 2"].Points.Add(sp1);

                chtMainItem3.Series["Series 2"].LegendText = dr["DEFECTNAME"].ObjectNullString();
            }

            foreach (DataRow dr in _dt.Select("DEFECTNAME = '" + vDefectName3 + "'"))
            {
                double _value1 = 0;
                if (dr["PPM"].ObjectNullString() != "") _value1 = Convert.ToDouble(dr["PPM"]);

                DevExpress.XtraCharts.SeriesPoint sp1 = new DevExpress.XtraCharts.SeriesPoint
                {
                    Argument = dr["REALDATE"] + "",
                    Values = new double[] { _value1 }
                };

                chtMainItem3.Series["Series 3"].Points.Add(sp1);

                chtMainItem3.Series["Series 3"].LegendText = dr["DEFECTNAME"].ObjectNullString();

            }

        }


        private void SetChartData4(DataTable _dt)
        {




            chtMainItem4.Series["PPM"].Points.Clear();

            chtMainItem4.Series["PPM"].ArgumentScaleType = ScaleType.Qualitative;
            chtMainItem4.Series["PPM"].ValueScaleType = ScaleType.Numerical;

            foreach (DataRow dr in _dt.Select())
            {
                double _value1 = 0;
                if (dr["PPM"].ObjectNullString() != "") _value1 = Convert.ToDouble(dr["PPM"]);

                DevExpress.XtraCharts.SeriesPoint sp1 = new DevExpress.XtraCharts.SeriesPoint
                {
                    Argument = dr["WORKTIME"] + "",
                    Values = new double[] { _value1 }
                };

                chtMainItem4.Series["PPM"].Points.Add(sp1);

            }
        }


        private void GetGridViewListRefresh()
        {
            
        }

        #endregion

        private void gvList_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
           
        }

        private void gvList1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            GridView View = sender as GridView;

            if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("PRODQTY") == 0)
            {
                var vExprodQty = gvList1.RowCount;
                var vResultQty = View.Columns["QTYTEMP"].SummaryItem.SummaryValue;

                decimal.TryParse(vExprodQty.ObjectNullString(), out decimal dExprodQty);
                decimal.TryParse(vResultQty.ObjectNullString(), out decimal dResultQty);

                if (vExprodQty > 1)
                {
                    e.TotalValue = Math.Round(Math.Round(dResultQty / dExprodQty, 2), 2);
                }
            }

            if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("PPM") == 0)
            {
                var vExprodQty = View.Columns["NGQTY"].SummaryItem.SummaryValue;
                var vResultQty = View.Columns["QTYTEMP"].SummaryItem.SummaryValue;

                var vRow = gvList1.RowCount;

                decimal.TryParse(vExprodQty.ObjectNullString(), out decimal dExprodQty);
                decimal.TryParse(vResultQty.ObjectNullString(), out decimal dResultQty);
                decimal.TryParse(vRow.ObjectNullString(), out decimal dRow);

                if (dExprodQty > 1)
                {
                    e.TotalValue = Math.Round(Math.Round(dExprodQty / (dResultQty/dRow)  * 1000000, 2), 2);
                }
            }

            if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("ACCRATIO") == 0)
            {
                var vResultQty = View.Columns["RATIO"].SummaryItem.SummaryValue;

                decimal.TryParse(vResultQty.ObjectNullString(), out decimal dResultQty);

                e.TotalValue = Math.Round(Math.Round(dResultQty, 2), 2);

            }
        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            mSecond--;
            mSecond2--;
            mSecond3--;
            
            if (mSecond3 == 0)
            {
                if (tcgMain.SelectedTabPageIndex == 0)
                    tcgMain.SelectedTabPageIndex = 1;
                else if (tcgMain.SelectedTabPageIndex == 1)
                    tcgMain.SelectedTabPageIndex = 2;
                else if (tcgMain.SelectedTabPageIndex == 2)
                    tcgMain.SelectedTabPageIndex = 3;
                else if (tcgMain.SelectedTabPageIndex == 3)
                    tcgMain.SelectedTabPageIndex = 4;
                else if (tcgMain.SelectedTabPageIndex == 4)
                    tcgMain.SelectedTabPageIndex = 0;
               
                GetGridViewList();
                mSecond3 = 100;
            }
        }


        private void layoutControlGroup3_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void layoutControlGroup4_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void layoutControlGroup5_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void layoutControlGroup6_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void layoutControlGroup7_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}


