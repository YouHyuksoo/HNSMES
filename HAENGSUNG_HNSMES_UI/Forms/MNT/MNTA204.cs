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
using DevExpress.XtraGrid;
using DevExpress.XtraSplashScreen;




namespace HAENGSUNG_HNSMES_UI.Forms.MNT
{

    public partial class MNTA204 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {

        #region 생성
        private int mSecond = 100;

        public MNTA204()
        {
            InitializeComponent();
        }

        private void MNTA204_Load(object sender, EventArgs e)
        {
                     
        }

        private void MNTA204_Shown(object sender, EventArgs e)
        {
            tabControl.SelectedTabPageIndex = 0;
            GetGridViewList();
        }

        #endregion

        #region 버튼이벤트

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

        public void SearchButton_Click()
        {
            GetGridViewList();
        }

        #endregion

        #region 함수

        
        private void Set_Init()
        {

        }
            
       

        private void GetGridViewList()
        {
            LanguageInformation m_clsLan = new LanguageInformation();
            SplashScreenManager.ShowForm(null, typeof(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM), true, true, false);
            SplashScreenManager.Default.SendCommand(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM.WaitFormCommand.SetCaption, m_clsLan.GetMessageString("MSG_WAIT_001"));
            SplashScreenManager.Default.SendCommand(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM.WaitFormCommand.SetDescription, m_clsLan.GetMessageString("SEARCHING"));
            if (tabControl.SelectedTabPageIndex == 0)
            {
                WSResults result = BASE_db.Execute_Proc("PKGPRD_MNT.GET_ASSEMBLY_RESULT_1_1"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT }
                                                       );


                if (result.ResultInt == 0)
                {
                    SetChartData_P1(result.ResultDataSet.Tables[0]);
                    GetGridViewList_P1();
                }
            }
            else if (tabControl.SelectedTabPageIndex == 1)
            {
                
            }
            else if (tabControl.SelectedTabPageIndex == 2)
            {
                WSResults result1 = BASE_db.Execute_Proc("PKGPRD_MNT.GET_ASSEMBLY_RESULT_3_1"
                                       , 1
                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT" }
                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT }
                                       );


                if (result1.ResultInt == 0)
                {
                    if(result1.ResultDataSet.Tables[0].Rows.Count > 0)
                        GetGridViewList_P3(result1.ResultDataSet.Tables[0]);
                }

                WSResults result2 = BASE_db.Execute_Proc("PKGPRD_MNT.GET_ASSEMBLY_RESULT_3_2"
                                                        , 1
                                                        , new string[] {
                                                          "A_CLIENT"
                                                        , "A_COMPANY"
                                                        , "A_PLANT" }
                                                        , new string[] {
                                                          Global.Global_Variable.CLIENT
                                                        , Global.Global_Variable.COMPANY
                                                        , Global.Global_Variable.PLANT }
                                                        );


                if (result2.ResultInt == 0)
                {
                    SetChartData_P3(result2.ResultDataSet.Tables[0]);
                }
            }
            else if (tabControl.SelectedTabPageIndex == 3)
            { }
            else if (tabControl.SelectedTabPageIndex == 4)
            { }

            SplashScreenManager.CloseForm(true);

            
        }
        private void SetChartData_P1(DataTable _dt)
        {

            chtPage1_1.Series["Line1"].Points.Clear();
            chtPage1_1.Series["Line2"].Points.Clear();
            chtPage1_1.Series["LineValue1"].Points.Clear();
            chtPage1_1.Series["LineValue2"].Points.Clear();

            chtPage1_1.Series["Line1"].ArgumentScaleType = ScaleType.Qualitative;
            chtPage1_1.Series["Line1"].ValueScaleType = ScaleType.Numerical;
            chtPage1_1.Series["Line2"].ArgumentScaleType = ScaleType.Qualitative;
            chtPage1_1.Series["Line2"].ValueScaleType = ScaleType.Numerical;
            chtPage1_1.Series["LineValue1"].ArgumentScaleType = ScaleType.Qualitative;
            chtPage1_1.Series["LineValue1"].ValueScaleType = ScaleType.Numerical;
            chtPage1_1.Series["LineValue2"].ArgumentScaleType = ScaleType.Qualitative;
            chtPage1_1.Series["LineValue2"].ValueScaleType = ScaleType.Numerical;

            foreach (DataRow dr in _dt.Select("UNITNO='A01'", "ORDERBY ASC"))
            {
                DevExpress.XtraCharts.SeriesPoint sp1 = new DevExpress.XtraCharts.SeriesPoint();
                DevExpress.XtraCharts.SeriesPoint sp2 = new DevExpress.XtraCharts.SeriesPoint();

                sp1.Argument = dr["REMARKS"] + "";
                sp2.Argument = dr["REMARKS"] + "";

                double _value1 = 0;
                if (dr["TARGETUPH"].ObjectNullString() != "") _value1 = Convert.ToDouble(dr["TARGETUPH"]);

                double _value2 = 0;
                if (dr["RESULTUPH"].ObjectNullString() != "") _value2 = Convert.ToDouble(dr["RESULTUPH"]);


                if (_value1 > 0) sp1.Values = new double[] { _value1 }; 
                if (_value2 > 0) sp2.Values = new double[] { _value2 }; 

                chtPage1_1.Series["Line1"].Points.Add(sp1);
                chtPage1_1.Series["LineValue1"].Points.Add(sp2);
            }

            foreach (DataRow dr in _dt.Select("UNITNO='A02'", "ORDERBY ASC"))
            {
                DevExpress.XtraCharts.SeriesPoint sp1 = new DevExpress.XtraCharts.SeriesPoint();
                DevExpress.XtraCharts.SeriesPoint sp2 = new DevExpress.XtraCharts.SeriesPoint();

                sp1.Argument = dr["REMARKS"] + "";
                sp2.Argument = dr["REMARKS"] + "";

                double _value1 = 0;
                if (dr["TARGETUPH"].ObjectNullString() != "") _value1 = Convert.ToDouble(dr["TARGETUPH"]);

                double _value2 = 0;
                if (dr["RESULTUPH"].ObjectNullString() != "") _value2 = Convert.ToDouble(dr["RESULTUPH"]);

                if (_value1 > 0) sp1.Values = new double[] { _value1 };
                if (_value2 > 0) sp2.Values = new double[] { _value2 }; 

                chtPage1_1.Series["Line2"].Points.Add(sp1);
                chtPage1_1.Series["LineValue2"].Points.Add(sp2);
            }
        }
        private void SetChartData_P2(DataTable _dt)
        {

            
        }

        private void SetChartData_P3(DataTable _dt)
        {

            chtPage3_1.Series["TARGET"].Points.Clear();
            chtPage3_1.Series["RESULT"].Points.Clear();
            chtPage3_2.Series["TARGET"].Points.Clear();
            chtPage3_2.Series["RESULT"].Points.Clear();

            chtPage3_1.Series["TARGET"].ArgumentScaleType = ScaleType.Qualitative;
            chtPage3_1.Series["TARGET"].ValueScaleType = ScaleType.Numerical;
            chtPage3_1.Series["RESULT"].ArgumentScaleType = ScaleType.Qualitative;
            chtPage3_1.Series["RESULT"].ValueScaleType = ScaleType.Numerical;
            chtPage3_2.Series["TARGET"].ArgumentScaleType = ScaleType.Qualitative;
            chtPage3_2.Series["TARGET"].ValueScaleType = ScaleType.Numerical;
            chtPage3_2.Series["RESULT"].ArgumentScaleType = ScaleType.Qualitative;
            chtPage3_2.Series["RESULT"].ValueScaleType = ScaleType.Numerical;

            foreach (DataRow dr in _dt.Select("UNITNO='A01'", "SEQ DESC"))
            {
                DevExpress.XtraCharts.SeriesPoint sp1 = new DevExpress.XtraCharts.SeriesPoint();
                DevExpress.XtraCharts.SeriesPoint sp2 = new DevExpress.XtraCharts.SeriesPoint();

                sp1.Argument = dr["PRODDATE"] + "";
                sp2.Argument = dr["PRODDATE"] + "";

                double _value1 = 0;
                if (dr["TARGET"].ObjectNullString() != "") _value1 = Convert.ToDouble(dr["TARGET"]);

                double _value2 = 0;
                if (dr["RESULT"].ObjectNullString() != "") _value2 = Convert.ToDouble(dr["RESULT"]);


                if (_value1 > 0) sp1.Values = new double[] { _value1 };
                if (_value2 > 0) sp2.Values = new double[] { _value2 };

                chtPage3_1.Series["TARGET"].Points.Add(sp1);
                chtPage3_1.Series["RESULT"].Points.Add(sp2);
            }

            foreach (DataRow dr in _dt.Select("UNITNO='A02'", "SEQ DESC"))
            {
                DevExpress.XtraCharts.SeriesPoint sp1 = new DevExpress.XtraCharts.SeriesPoint();
                DevExpress.XtraCharts.SeriesPoint sp2 = new DevExpress.XtraCharts.SeriesPoint();

                sp1.Argument = dr["PRODDATE"] + "";
                sp2.Argument = dr["PRODDATE"] + "";

                double _value1 = 0;
                if (dr["TARGET"].ObjectNullString() != "") _value1 = Convert.ToDouble(dr["TARGET"]);

                double _value2 = 0;
                if (dr["RESULT"].ObjectNullString() != "") _value2 = Convert.ToDouble(dr["RESULT"]);

                if (_value1 > 0) sp1.Values = new double[] { _value1 };
                if (_value2 > 0) sp2.Values = new double[] { _value2 };

                chtPage3_2.Series["TARGET"].Points.Add(sp1);
                chtPage3_2.Series["RESULT"].Points.Add(sp2);
            }
        }

        private void GetGridViewList_P1()
        {
            WSResults result = BASE_db.Execute_Proc("PKGPRD_MNT.GET_ASSEMBLY_RESULT_1_2"
                                                   , 1
                                                   , new string[] {
                                                     "A_CLIENT"
                                                   , "A_COMPANY"
                                                   , "A_PLANT" }
                                                   , new string[] {
                                                     Global.Global_Variable.CLIENT
                                                   , Global.Global_Variable.COMPANY
                                                   , Global.Global_Variable.PLANT }
                                                   );


            if (result.ResultInt == 0)
            {
                gcList1_1.DataSource = result.ResultDataSet.Tables[0];

                //gvList1.Appearance.FooterPanel.Font = new Font(gvList1.Appearance.FooterPanel.Font.Name, 24, FontStyle.Bold);
                //gvList1.Appearance.Row.Font = new Font(gvList1.Appearance.FooterPanel.Font.Name, 24, FontStyle.Bold);

                foreach (GridColumn gc in gvList1_1.Columns)
                {
                    //gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    //gc.AppearanceHeader.Font = new System.Drawing.Font(gc.AppearanceHeader.Font.Name, 24, FontStyle.Bold);

                    //gvList1.Columns["WORKTIME"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    //gvList1.Columns["WORKTIME"].DisplayFormat.FormatString = "{0:n2}";

                    //gvList1.Columns["UPH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    //gvList1.Columns["UPH"].DisplayFormat.FormatString = "{0:n2}";
                }

                gvList1_1.OptionsView.ShowFooter = false;
                gvList1_1.OptionsView.ColumnAutoWidth = true;
                gvList1_1.BestFitColumns();
            }

        }
        private void GetGridViewList_P2()
        {
            

        }
        private void GetGridViewList_P3(DataTable dt)
        {
            DataRow[] drTempA01 = dt.Select("UNITNO ='A01'");

            if (drTempA01.Length > 0)
            {
                gvList3_1.Appearance.HeaderPanel.Font = new Font(gvList3_1.Appearance.FooterPanel.Font.Name, 32, FontStyle.Bold);
                gvList3_1.Appearance.Row.Font = new Font(gvList3_1.Appearance.FooterPanel.Font.Name, 32, FontStyle.Bold);
                gcList3_1.DataSource = drTempA01.CopyToDataTable();
                gvList3_1.OptionsView.ShowFooter = false;
                gvList3_1.OptionsView.ShowAutoFilterRow = false;
                gvList3_1.OptionsView.ColumnAutoWidth = true;
                gvList3_1.BestFitColumns();
            }

            DataRow[] drTempA02 = dt.Select("UNITNO ='A02'");

            if (drTempA02.Length > 0)
            {
                gvList3_2.Appearance.HeaderPanel.Font = new Font(gvList3_2.Appearance.FooterPanel.Font.Name, 32, FontStyle.Bold);
                gvList3_2.Appearance.Row.Font = new Font(gvList3_2.Appearance.FooterPanel.Font.Name, 32, FontStyle.Bold);
                gcList3_2.DataSource = drTempA02.CopyToDataTable();
                gvList3_2.OptionsView.ShowFooter = false;
                gvList3_2.OptionsView.ShowAutoFilterRow = false;
                gvList3_2.OptionsView.ColumnAutoWidth = true;
                gvList3_2.BestFitColumns();
            }
        }
        #endregion

        #region 일반이벤트

        private void gvList_Click(object sender, EventArgs e)
        {
        }

        private void gvList_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
                      
        }

        private void gvList_RowStyle(object sender, GridAlias.RowStyleEventArgs e)
        {

        }
        

        private void gleitemtype_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            
        }


        private void gvList_RowCellStyle(object sender, GridAlias.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            
            if (e.RowHandle >= 0)
            {
            }
           
        }

        #endregion

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            mSecond--;

            if (mSecond == 0)
            {
                GetGridViewList();
                mSecond = 100;
                //디자인에서 1초마다 이벤트 호출하고 소스에서 1 * 100초마다 조회하게 됨
            }
        }

        private void gvList_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            GridView View = sender as GridView;

            
        }



        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControl_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            GetGridViewList();
        }

        
       
        
    }
}
