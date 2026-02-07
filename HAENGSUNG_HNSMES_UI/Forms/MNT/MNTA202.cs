using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

// DevExpress namespace
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraCharts;

// User namespace
using HAENGSUNG_HNSMES_UI.Class;
using GridAlias = DevExpress.XtraGrid.Views.Grid;
//using Google.API.Translate;
using HAENGSUNG_HNSMES_UI.WebService.Access;
using HAENGSUNG_HNSMES_UI.WebService.Business;

using DevExpress.XtraSplashScreen;

namespace HAENGSUNG_HNSMES_UI.Forms.MNT
{
    public partial class MNTA202 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {
       
        // ******************************************* Base From Class ************************************
        // BASE_clsDevexpressGridUtil          DevExpress Grid 관련 Util Class.
        // BASE_db;                            웹서비스 DB처리 관련 Util Class.
        // BASE_DXGridHelper;                  DevExpress GridControl 데이터 Bind관련 Class
        // BASE_DXGridLookUpHelper;            DevExpress GridLookUp 데이터 Bind관련 Class
        // BASE_IDATLayoutUtil;                DevExpress LayoutControl Util Class.
        // BASE_Language;                      Language Util. ex) BASE_Language.GetMessageString("Code") 
        // ************************************************************************************************
        private const int mInitSecond = 30; //5분주기 업데이트
        private int mSecond = 30; //5분주기 업데이트

        private string sWire = string.Empty;
        private string sTerminal = string.Empty;

        #region [생성자]

        public MNTA202()
        {
            InitializeComponent();

            // 폼 상태에 따라 발생되는 이벤트 정의 부
            this.IDAT_UpdateItemsEditChangedEvent += new IDAT_UpdateItemsEditChanged(FORM_IDAT_UpdateItemsEditChangedEvent);

        }

        public MNTA202(string _sWire, string _sTerminal)
        {
            InitializeComponent();

            sWire = _sWire;
            sTerminal = _sTerminal;

            // 폼 상태에 따라 발생되는 이벤트 정의 부
            this.IDAT_UpdateItemsEditChangedEvent += new IDAT_UpdateItemsEditChanged(FORM_IDAT_UpdateItemsEditChangedEvent);

        }

        void FORM_IDAT_UpdateItemsEditChangedEvent(object sender, IDAT.Devexpress.FORM.UPDATEITEMTYPE type)
        {
            switch (type)
            {
                case IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit:
                    // 폼 상태가 수정 모드일 경우 발생 이벤트
                    break;
                case IDAT.Devexpress.FORM.UPDATEITEMTYPE.New:
                    // 폼 상태가 신규 등록 모드일 경우 발생 이벤트
                    break;
                case IDAT.Devexpress.FORM.UPDATEITEMTYPE.None:
                    // 폼 상태가 초기화 모드일 경우 발생 이벤트
                    break;
                default:
                    break;
            }
        }

       

        private void Form_Load(object sender, EventArgs e)
        {
            // Main 버튼 사용 유무 (폼 속성 변경 가능)

            // Main 버튼 사용 유무
            //this.ShowCloseButton = true;
            //this.ShowDeleteButton = true;
            //this.ShowEditButton = true;
            //this.ShowIcon = true;
            //this.ShowInitButton = true;
            //this.ShowInTaskbar = true;
            //this.ShowNewbutton = true;
            //this.ShowPrintButton = false;
            //this.ShowRefreshButton = true;
            //this.ShowSaveButton = true;
            //this.ShowSearchButton = true;
            //this.ShowStopButton = false;
           
        }

      
        private void Form_Shown(object sender, EventArgs e)
        {
            // ************************************************************************************
            // 컨트롤 초기화는 필수적으로 Load이벤트에 작성을 하도록 합니다.
            // ************************************************************************************

            // 모든 Edit컨트롤을 보기 상태로 변경을 합니다.
            //base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);

            // 리스트 호출
            //lblTitle.Text = "Line Monitoring - " + mWrkCtr;

            
            //lblTimer.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            SplashScreenManager.ShowForm(typeof(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM), true, false);
            SplashScreenManager.Default.SendCommand(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM.WaitFormCommand.SetDescription, "Loading...");
          
            RefreshData();

            SplashScreenManager.CloseForm(true);
            
            pbcMain.Properties.Maximum = mSecond;
            pbcMain.Position = mSecond;
            tmrRefresh.Start();
            //tmrWorkCenter.Start();
        }


        #endregion

        #region [Button Event]

        public void InitButton_Click()
        {
            // 초기화 관련 구현은 여기에 구현 ***

            ////  현재 프로그램 모드정보를 변경한다.
            ////  IDAT.Devexpress.FORM.UPDATEITEMTYPE.None = 초기화 모드
            ////  IDAT.Devexpress.FORM.UPDATEITEMTYPE.New  = 신규 모드
            ////  IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit = 수정 모드

            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);

        }

        public void NewButton_Click()
        {
            // 신규 관련 구현은 아래에 구현 ***

            // ************************************************************************************
            // 신규 항목을 추가하기전에 기존에 수정된 데이터를 저장하고 신규 추가를 한다.
            // 메인화면 버튼접근시에는 아래와 같이 접근을 합니다.

            // MainButton_Save;
            // MainButton_Refresh;
            // MainButton_New;
            // .....
            // MainButton_Refresh;
            // MainButton_Stop;
            // ************************************************************************************

            // 추가하기 전에 기존에 수정된 데이터를 저장 함.
            MainButton_Save.PerformClick();

            // 각 컨트롤마다 신규 상태를 별도로 설정할 수 있습니다.
            
        }

        public void EditButton_Click()
        {
            // 수정 관련 구현은 여기에 구현 ***
            
        }

        public void StopButton_Click()
        {
           // 중지 이벤트
        }

        public void SearchButton_Click()
        {
            // 검색 이벤트
        }

        public void SaveButton_Click()
        {
            // 저장 관련 구현은 아래에 구현 ***
        }

        public void PrintButton_Click()
        {
           // 출력 이벤트
        }

        public void RefreshButton_Click()
        {
            // 새로고침 이벤트
        }

        public void DeleteButton_Click()
        {
            // 삭제 이벤트
        }

        #endregion
      
        #region [Private Method]

        private void GetExcelChartImage(string _strUsl, string _strLsl, string _strMean, string _strSDA, string _strSDW)
        {
            string dtPath = Application.StartupPath + @"\Excel\NormalDistribution.xlsx";
            string dtSheet = "data";
            
            Microsoft.Office.Interop.Excel.Application objExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = objExcel.Workbooks.Open(dtPath);
            Microsoft.Office.Interop.Excel.Worksheet Sheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[dtSheet];

            objExcel.Visible = false;

            //add data 
            Sheet.Cells[2, 3] = _strUsl;
            Sheet.Cells[3, 3] = _strLsl;
            Sheet.Cells[4, 3] = _strMean;
            Sheet.Cells[5, 3] = _strSDA;
            Sheet.Cells[7, 3] = _strSDW;

            workbook.Save();

            Microsoft.Office.Interop.Excel.ChartObjects chartObjects = (Microsoft.Office.Interop.Excel.ChartObjects)Sheet.ChartObjects(Type.Missing);
            int chartCount = chartObjects.Count;
            for (int j = 1; j <= chartCount; j++)
            {
                Microsoft.Office.Interop.Excel.ChartObject chart = (Microsoft.Office.Interop.Excel.ChartObject)chartObjects.Item(j);
                string path = System.IO.Path.Combine(Application.StartupPath, @"Normaldistribution.bmp");
                chart.Activate(); //New line
                chart.Chart.Export(path, "BMP", true);
            }

            workbook.Close(true, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
            objExcel.Workbooks.Close();
            objExcel.Quit();

            releaseObject(Sheet);
            releaseObject(workbook);
            releaseObject(objExcel);
           
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception)
            {
                obj = null;
                //MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        private void RefreshData()
        {
            WSResults result = BASE_db.Execute_Proc("PKGPRD_MNT.GET_CRIMP_MONITORING"
                                                   , 1
                                                   , new string[] {
                                                     "A_CLIENT"
                                                   , "A_COMPANY"
                                                   , "A_PLANT" 
                                                   , "A_WIRE"
                                                   , "A_TERMINAL" }
                                                   , new string[] {
                                                     Global.Global_Variable.CLIENT
                                                   , Global.Global_Variable.COMPANY
                                                   , Global.Global_Variable.PLANT
                                                   , sWire
                                                   , sTerminal}
                                                   );
            if (result.ResultInt == 0)
            {
                if (result.ResultDataSet.Tables[0].Rows.Count > 0)
                {
                    SwiftPlotDiagram diagram = (SwiftPlotDiagram)chtXControl.Diagram;
                    
                    diagram.AxisY.WholeRange.SideMarginsValue = 0;
                    double min = Convert.ToDouble(result.ResultDataSet.Tables[0].Rows[0]["YMIN"].ObjectNullString()) - 0.5;
                    double max = Convert.ToDouble(result.ResultDataSet.Tables[0].Rows[0]["YMAX"].ObjectNullString()) + 0.5;

                    diagram.AxisY.WholeRange.SetMinMaxValues(min, max);

                    SetXControlChartData(result.ResultDataSet.Tables[1]);
                    SetRMControlChartData(result.ResultDataSet.Tables[2]);
                    //SetNormalDistributionControlChartData(result.ResultDataSet.Tables[3]);

                    BASE_DXGridHelper.Bind_Grid(gcList, result.ResultDataSet.Tables[0], true, "", false, true, false);

                    lblInspTime.Text = "I/D Time : " + result.ResultDataSet.Tables[0].Rows[0]["INSPTIME"].ObjectNullString();
                    lblWire.Text = result.ResultDataSet.Tables[0].Rows[0]["WIRE"].ObjectNullString();
                    lblTerminal.Text = result.ResultDataSet.Tables[0].Rows[0]["TERMINAL"].ObjectNullString();
                    lblCP.Text = result.ResultDataSet.Tables[0].Rows[0]["CP"].ObjectNullString();
                    lblCPK.Text = result.ResultDataSet.Tables[0].Rows[0]["CPK"].ObjectNullString();

                    double dCP = Convert.ToDouble(lblCP.Text);
                    double dCPK = Convert.ToDouble(lblCPK.Text);

                    lblCP.ForeColor = Color.White;
                    lblCPK.ForeColor = Color.White;

                    if (dCPK >= 1.33) lblCPK.BackColor = Color.DarkGreen;
                    else if (dCPK >= 1 && dCPK < 1.33) lblCPK.BackColor = Color.Blue;
                    else lblCPK.BackColor = Color.Red;

                    if (dCP >= 1.33) lblCP.BackColor = Color.DarkGreen;
                    else if (dCP >= 1 && dCP < 1.33) lblCP.BackColor = Color.Blue;
                    else lblCP.BackColor = Color.Red;

                    if (Convert.ToDouble(result.ResultDataSet.Tables[0].Rows[0]["EDUSL"].ObjectNullString()) == 0) lblEDUSL.Text = "0 PPM";
                    else lblEDUSL.Text = Convert.ToDouble(result.ResultDataSet.Tables[0].Rows[0]["EDUSL"].ObjectNullString()).ToString("#,#.##") + " PPM";

                    if (Convert.ToDouble(result.ResultDataSet.Tables[0].Rows[0]["EDLSL"].ObjectNullString()) == 0) lblEDLSL.Text = "0 PPM";
                    else lblEDLSL.Text = Convert.ToDouble(result.ResultDataSet.Tables[0].Rows[0]["EDLSL"].ObjectNullString()).ToString("#,#.##") + " PPM";

                    lblUSL.Text = result.ResultDataSet.Tables[0].Rows[0]["USL"].ObjectNullString();
                    lblX.Text = result.ResultDataSet.Tables[0].Rows[0]["X"].ObjectNullString();
                    lblLSL.Text = result.ResultDataSet.Tables[0].Rows[0]["LSL"].ObjectNullString();
                    lblMEAN.Text = result.ResultDataSet.Tables[0].Rows[0]["MEAN"].ObjectNullString();
                    lblJUDGE.Text = result.ResultDataSet.Tables[0].Rows[0]["JUDGE"].ObjectNullString();

                    if (lblJUDGE.Text == "OK")
                    {
                        lblJUDGE.BackColor = Color.ForestGreen;
                    }
                    else
                    {
                        lblJUDGE.BackColor = Color.Red;
                        SoundPlayer _player = new SoundPlayer(HAENGSUNG_HNSMES_UI.Properties.Resources.NG_Sound);
                        _player.Play();
                    }

                    System.IO.FileStream fs = null;
                    try
                    {
                        GetExcelChartImage(result.ResultDataSet.Tables[0].Rows[0]["USL"].ObjectNullString()
                                          , result.ResultDataSet.Tables[0].Rows[0]["LSL"].ObjectNullString()
                                          , result.ResultDataSet.Tables[0].Rows[0]["OMEAN"].ObjectNullString()
                                          , result.ResultDataSet.Tables[0].Rows[0]["SDA"].ObjectNullString()
                                          , result.ResultDataSet.Tables[0].Rows[0]["SDW"].ObjectNullString()
                                          );

                        fs = new System.IO.FileStream(System.IO.Path.Combine(Application.StartupPath, @"Normaldistribution.bmp"), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        byte[] b = new byte[fs.Length - 1];
                        fs.Read(b, 0, b.Length);
                        Image imgFromBlob = Image.FromStream(fs);
                        picNormalDistribution.Image = imgFromBlob;
                        fs.Close();
                    }
                    catch
                    {
                        if (fs != null) fs.Close();
                    }
                }
            }

            this.Activate();
        }

        /*데이터 테이블 정보를 활용한 차트 표현*/
        private void SetXControlChartData(DataTable _dt)
        {
            chtXControl.Series["Series 1"].Points.Clear();
            chtXControl.Series["Series 2"].Points.Clear();
            chtXControl.Series["Series 3"].Points.Clear();
            chtXControl.Series["Series 4"].Points.Clear();
            chtXControl.Series["Series 5"].Points.Clear();
            chtXControl.Series["Series 6"].Points.Clear();

            chtXControl.Series["Series 1"].ArgumentScaleType = ScaleType.Qualitative;
            chtXControl.Series["Series 1"].ValueScaleType = ScaleType.Numerical;
            chtXControl.Series["Series 2"].ArgumentScaleType = ScaleType.Qualitative;
            chtXControl.Series["Series 2"].ValueScaleType = ScaleType.Numerical;
            chtXControl.Series["Series 3"].ArgumentScaleType = ScaleType.Qualitative;
            chtXControl.Series["Series 3"].ValueScaleType = ScaleType.Numerical;
            chtXControl.Series["Series 4"].ArgumentScaleType = ScaleType.Qualitative;
            chtXControl.Series["Series 4"].ValueScaleType = ScaleType.Numerical;
            chtXControl.Series["Series 5"].ArgumentScaleType = ScaleType.Qualitative;
            chtXControl.Series["Series 5"].ValueScaleType = ScaleType.Numerical;
            chtXControl.Series["Series 6"].ArgumentScaleType = ScaleType.Qualitative;
            chtXControl.Series["Series 6"].ValueScaleType = ScaleType.Numerical;


            foreach (DataRow dr in _dt.Rows)
            {
                DevExpress.XtraCharts.SeriesPoint sp1 = new DevExpress.XtraCharts.SeriesPoint();
                DevExpress.XtraCharts.SeriesPoint sp2 = new DevExpress.XtraCharts.SeriesPoint();
                DevExpress.XtraCharts.SeriesPoint sp3 = new DevExpress.XtraCharts.SeriesPoint();
                DevExpress.XtraCharts.SeriesPoint sp4 = new DevExpress.XtraCharts.SeriesPoint();
                DevExpress.XtraCharts.SeriesPoint sp5 = new DevExpress.XtraCharts.SeriesPoint();
                DevExpress.XtraCharts.SeriesPoint sp6 = new DevExpress.XtraCharts.SeriesPoint();
                
                sp1.Argument = dr["NUM"] + "";
                sp2.Argument = dr["NUM"] + "";
                sp3.Argument = dr["NUM"] + "";
                sp4.Argument = dr["NUM"] + "";
                sp5.Argument = dr["NUM"] + "";
                sp6.Argument = dr["NUM"] + ""; 

                double _value1 = 0;
                double _value2 = 0;
                double _value3 = 0;
                double _value4 = 0;
                double _value5 = 0;
                double _value6 = 0;

                if (dr["USL"].ObjectNullString() != "") _value1 = Convert.ToDouble(dr["USL"]);

                sp1.Values = new double[] { _value1 };

                if (dr["UCL"].ObjectNullString() != "") _value2 = Convert.ToDouble(dr["UCL"]);

                sp2.Values = new double[] { _value2 };

                if (dr["LSL"].ObjectNullString() != "") _value3 = Convert.ToDouble(dr["LSL"]);

                sp3.Values = new double[] { _value3 };

                if (dr["LCL"].ObjectNullString() != "") _value4 = Convert.ToDouble(dr["LCL"]);

                sp4.Values = new double[] { _value4 };

                if (dr["CL"].ObjectNullString() != "") _value5 = Convert.ToDouble(dr["CL"]);

                sp5.Values = new double[] { _value5 };

                if (dr["PEAK"].ObjectNullString() != "") _value6 = Convert.ToDouble(dr["PEAK"]);

                sp6.Values = new double[] { _value6 };

                chtXControl.Series["Series 1"].Points.Add(sp1);
                chtXControl.Series["Series 2"].Points.Add(sp2);
                chtXControl.Series["Series 3"].Points.Add(sp3);
                chtXControl.Series["Series 4"].Points.Add(sp4);
                chtXControl.Series["Series 5"].Points.Add(sp5);
                chtXControl.Series["Series 6"].Points.Add(sp6);
            }
            //chtXControl.BeginInit();
            //SwiftPlotDiagram diagram = (SwiftPlotDiagram)chtXControl.Diagram;
            //diagram.AxisY.VisualRange.MinValue = 5;
            //chtXControl.EndInit();
        }

        /*데이터 테이블 정보를 활용한 차트 표현*/
        private void SetRMControlChartData(DataTable _dt)
        {
            chtRMControl.Series["Series 1"].Points.Clear();
            chtRMControl.Series["Series 2"].Points.Clear();
            chtRMControl.Series["Series 3"].Points.Clear();
            chtRMControl.Series["Series 4"].Points.Clear();


            chtRMControl.Series["Series 1"].ArgumentScaleType = ScaleType.Qualitative;
            chtRMControl.Series["Series 1"].ValueScaleType = ScaleType.Numerical;
            chtRMControl.Series["Series 2"].ArgumentScaleType = ScaleType.Qualitative;
            chtRMControl.Series["Series 2"].ValueScaleType = ScaleType.Numerical;
            chtRMControl.Series["Series 3"].ArgumentScaleType = ScaleType.Qualitative;
            chtRMControl.Series["Series 3"].ValueScaleType = ScaleType.Numerical;
            chtRMControl.Series["Series 4"].ArgumentScaleType = ScaleType.Qualitative;
            chtRMControl.Series["Series 4"].ValueScaleType = ScaleType.Numerical;

            /*차트 표기(IQC 소형 성능 검사 현황)*/
            foreach (DataRow dr in _dt.Rows)
            {
                DevExpress.XtraCharts.SeriesPoint sp1 = new DevExpress.XtraCharts.SeriesPoint();
                DevExpress.XtraCharts.SeriesPoint sp2 = new DevExpress.XtraCharts.SeriesPoint();
                DevExpress.XtraCharts.SeriesPoint sp3 = new DevExpress.XtraCharts.SeriesPoint();
                DevExpress.XtraCharts.SeriesPoint sp4 = new DevExpress.XtraCharts.SeriesPoint();

                sp1.Argument = dr["NUM"] + "";
                sp2.Argument = dr["NUM"] + "";
                sp3.Argument = dr["NUM"] + "";
                sp4.Argument = dr["NUM"] + "";


                double _value1 = 0;
                double _value2 = 0;
                double _value3 = 0;
                double _value4 = 0;


                if (dr["UCL"].ObjectNullString() != "") _value1 = Convert.ToDouble(dr["UCL"]);

                sp1.Values = new double[] { _value1 };

                if (dr["LCL"].ObjectNullString() != "") _value2 = Convert.ToDouble(dr["LCL"]);

                sp2.Values = new double[] { _value2 };

                if (dr["RM"].ObjectNullString() != "") _value3 = Convert.ToDouble(dr["RM"]);

                sp3.Values = new double[] { _value3 };

                if (dr["CL"].ObjectNullString() != "") _value4 = Convert.ToDouble(dr["CL"]);

                sp4.Values = new double[] { _value4 };



                chtRMControl.Series["Series 1"].Points.Add(sp1);
                chtRMControl.Series["Series 2"].Points.Add(sp2);
                chtRMControl.Series["Series 3"].Points.Add(sp3);
                chtRMControl.Series["Series 4"].Points.Add(sp4);
            }

            //SwiftPlotDiagram diagram = (SwiftPlotDiagram)chtXControl.Diagram;

            //diagram.AxisY.VisualRange.MinValue = 5;
        }


        /*데이터 테이블 정보를 활용한 차트 표현*/
        private void SetNormalDistributionControlChartData(DataTable _dt)
        {
            double dMAXvalue = 0;

            chtNorDistribution.Series["Series 1"].Points.Clear();
            chtNorDistribution.Series["Series 2"].Points.Clear();
            chtNorDistribution.Series["Series 3"].Points.Clear();
            chtNorDistribution.Series["Series 4"].Points.Clear();
            chtNorDistribution.Series["Series 5"].Points.Clear();
            chtNorDistribution.Series["Series 6"].Points.Clear();
            chtNorDistribution.Series["Series 7"].Points.Clear();

            chtNorDistribution.Series["Series 1"].ArgumentScaleType = ScaleType.Qualitative;
            chtNorDistribution.Series["Series 1"].ValueScaleType = ScaleType.Numerical;
            chtNorDistribution.Series["Series 2"].ArgumentScaleType = ScaleType.Qualitative;
            chtNorDistribution.Series["Series 2"].ValueScaleType = ScaleType.Numerical;
            chtNorDistribution.Series["Series 3"].ArgumentScaleType = ScaleType.Qualitative;
            chtNorDistribution.Series["Series 3"].ValueScaleType = ScaleType.Numerical;
            chtNorDistribution.Series["Series 4"].ArgumentScaleType = ScaleType.Qualitative;
            chtNorDistribution.Series["Series 4"].ValueScaleType = ScaleType.Numerical;
            chtNorDistribution.Series["Series 5"].ArgumentScaleType = ScaleType.Qualitative;
            chtNorDistribution.Series["Series 5"].ValueScaleType = ScaleType.Numerical;
            chtNorDistribution.Series["Series 6"].ArgumentScaleType = ScaleType.Qualitative;
            chtNorDistribution.Series["Series 6"].ValueScaleType = ScaleType.Numerical;
            chtNorDistribution.Series["Series 7"].ArgumentScaleType = ScaleType.Qualitative;
            chtNorDistribution.Series["Series 7"].ValueScaleType = ScaleType.Numerical;

            for(int j = 0; j< _dt.Rows.Count; j++)
            {
                double dvalue = 0;
                if (double.Parse(_dt.Rows[j]["Y"].ObjectNullString()) > double.Parse(_dt.Rows[j]["B"].ObjectNullString()))
                {
                    dvalue = Convert.ToDouble(_dt.Rows[j]["Y"].ObjectNullString());
                }
                else
                {
                    dvalue = Convert.ToDouble(_dt.Rows[j]["B"].ObjectNullString());
                }

                if (dvalue > dMAXvalue) dMAXvalue = dvalue;

            }

            double dMaxY = 0;
            double dMaxB = 0;
            
            /*차트 표기(IQC 소형 성능 검사 현황)*/
            foreach (DataRow dr in _dt.Rows)
            {
                DevExpress.XtraCharts.SeriesPoint sp1 = new DevExpress.XtraCharts.SeriesPoint();
                DevExpress.XtraCharts.SeriesPoint sp2 = new DevExpress.XtraCharts.SeriesPoint();
                //DevExpress.XtraCharts.SeriesPoint sp3 = new DevExpress.XtraCharts.SeriesPoint();
                //DevExpress.XtraCharts.SeriesPoint sp4 = new DevExpress.XtraCharts.SeriesPoint();
                DevExpress.XtraCharts.SeriesPoint sp5 = new DevExpress.XtraCharts.SeriesPoint();
                DevExpress.XtraCharts.SeriesPoint sp6 = new DevExpress.XtraCharts.SeriesPoint();
                DevExpress.XtraCharts.SeriesPoint sp7 = new DevExpress.XtraCharts.SeriesPoint();

                sp1.Argument = dr["X"] + "";
                sp2.Argument = dr["X"] + "";
                //sp3.Argument = dr["X"] + "";
                //sp4.Argument = dr["X"] + "";
                sp5.Argument = dr["X"] + "";
                sp6.Argument = dr["X"] + "";
                sp7.Argument = dr["X"] + "";

                double _value1 = 0;
                double _value2 = 0;
                //double _value3 = 0;
                //double _value4 = 0;
                double _value5 = 0;
                double _value6 = 0;
                double _value7 = 0;

                if (dr["USL"].ObjectNullString() != "" ) _value1 = Convert.ToDouble(dr["USL"]);

                if (_value1 == 1) _value1 = dMAXvalue;

                sp1.Values = new double[] { _value1 };

                if (dr["LSL"].ObjectNullString() != "") _value2 = Convert.ToDouble(dr["LSL"]);

                if (_value2 == 1) _value2 = dMAXvalue;

                sp2.Values = new double[] { _value2 };

                //if (dr["UCL"].ObjectNullString() != "") _value3 = Convert.ToDouble(dr["UCL"]);

                //if (_value3 == 1) _value3 = dMAXvalue;

                //sp3.Values = new double[] { _value3 };

                //if (dr["LCL"].ObjectNullString() != "") _value4 = Convert.ToDouble(dr["LCL"]);

                //if (_value4 == 1) _value4 = dMAXvalue;

                //sp4.Values = new double[] { _value4 };

                if (dr["Y"].ObjectNullString() != "") _value5 = Convert.ToDouble(dr["Y"]);

                if (_value5 > 0) dMaxY = _value5;
                else if (_value5 == 0) _value5 = dMaxY;

                sp5.Values = new double[] { _value5 };

                if (dr["B"].ObjectNullString() != "") _value6 = Convert.ToDouble(dr["B"]);

                if (_value6 > 0) dMaxB = _value6;
                else if (_value6 == 0) _value6 = dMaxY;

                sp6.Values = new double[] { _value6 };

                if (dr["SL"].ObjectNullString() != "") _value7 = Convert.ToDouble(dr["SL"]);

                if (_value7 == 1) _value7 = dMAXvalue;

                sp7.Values = new double[] { _value7 };


                chtNorDistribution.Series["Series 1"].Points.Add(sp1);
                chtNorDistribution.Series["Series 2"].Points.Add(sp2);
                //chtNorDistribution.Series["Series 3"].Points.Add(sp3);
                //chtNorDistribution.Series["Series 4"].Points.Add(sp4);
                chtNorDistribution.Series["Series 5"].Points.Add(sp5);
                chtNorDistribution.Series["Series 6"].Points.Add(sp6);
                chtNorDistribution.Series["Series 7"].Points.Add(sp7);
            }

            //chtNorDistribution.BeginInit();
            //SwiftPlotDiagram diagram = (SwiftPlotDiagram)chtXControl.Diagram;

            //diagram.AxisY.VisualRange.MinValue = 0;
            //diagram.AxisY.VisualRange.MaxValue = 1;
            //chtNorDistribution.EndInit();

        }

        private void SaveData(string p_strA, string p_strB, string p_strC)
        {
            // 프로시져 수행 (저장)
            // BASE_db.Execute_Proc("ProcName", 1, new string[] { "param1", "param2", "param3" }, new string[] { p_strA, p_strB, p_strC });
            //gvList.OptionsBehavior.Editable = false;
        }
      

        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            mSecond--;

            
            if (mSecond == 0)
            {
                RefreshData();

                mSecond = mInitSecond;

            }

            pbcMain.Position = mSecond;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void tmrWorkCenter_Tick(object sender, EventArgs e)
        {
            tmrWorkCenter.Stop();

            tmrWorkCenter.Start();
        }

        private void lblSecond_DoubleClick(object sender, EventArgs e)
        {
            btnExit_Click(null, null);
        }

      

        private void lblTimer_Click(object sender, EventArgs e)
        {
            btnExit_Click(null, null);

        }

        private void pnlLanguage_Click(object sender, EventArgs e)
        {
           
        }

        private void lblInspTime_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
     

    }
}
