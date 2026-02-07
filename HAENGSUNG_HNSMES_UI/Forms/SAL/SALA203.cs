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


namespace HAENGSUNG_HNSMES_UI.Forms.SAL
{

    public partial class SALA203 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {

        #region 생성

        private Boolean _bRefresh = false;

        public SALA203()
        {
            InitializeComponent();
        }

        private void SALA203_Load(object sender, EventArgs e)
        {
            
        }

        private void SALA203_Shown(object sender, EventArgs e)
        {
            MainButton_INIT.PerformClick();
        }

        #endregion

        #region 버튼이벤트

        public void InitButton_Click()
        {

            // 초기화 관련 구현은 여기에 구현 ***
            this.Set_Init();
        }

        public void NewButton_Click()
        {
            // 신규 관련 구현은 여기에 구현.
        }

        public void EditButton_Click()
        {
            // 수정 관련 구현은 여기에 구현.
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

        public ArrayList ExcelSheetNames(string excelFile)
        {
            ArrayList sheetNames = new ArrayList();
            string sConnectionString;


            string[] arrText = excelFile.ToString().Split(new char[] { '.' });

            if (arrText[arrText.Length - 1].ToString() == "xls")
            {
                sConnectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=No;\"", excelFile);
            }
            else
            {
                sConnectionString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=No;\"", excelFile);

            }

            using (OleDbConnection excelConnection = new OleDbConnection(sConnectionString))
            {
                System.Data.DataTable dtSheets = new System.Data.DataTable();

                try
                {
                    excelConnection.Open();
                    dtSheets = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    excelConnection.Close();
                    if (dtSheets == null)
                    {
                        return sheetNames;
                    }

                    foreach (DataRow dr in dtSheets.Rows)
                    {
                        string sheetName = dr["TABLE_NAME"].ToString().Trim('\'').Replace("$", "");

                        DataTable dt = Global.GlobalFunction.ReadExcelFile(excelFile, sheetName);

                        if (dt.Rows[0]["F1"] + "" == "Model(파트넘버)")
                        {
                            sheetNames.Add(sheetName);
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    iDATMessageBox.WARNINGMessage(ex.Message, this.Text, 3);
                    return null;
                }
                finally
                {
                    dtSheets.Dispose();
                }
            }
            return sheetNames;
        }

        private void Set_Init()
        {
            dteMonth.EditValue = DateTime.Now;
        }
            
       

        private void GetGridViewList()
        {
            if (dteMonth.EditValue == null)
            {
                LanguageInformation _clsLang = new LanguageInformation();
                string _strMsg = _clsLang.GetMessageString("MSG_ER_COMM_089");//날짜를 입력하세요
                iDATMessageBox.WARNINGMessage(_strMsg, this.Text, 3);
                return;
            }

            WSResults result = BASE_db.Execute_Proc( "PKGPRD_SALES.GET_CUSTPLAN_ORDER"
                                                   , 1
                                                   , new string[] {
                                                     "A_CLIENT"
                                                   , "A_COMPANY"
                                                   , "A_PLANT"
                                                   , "A_PLANDATE"}
                                                   , new string[] {
                                                     Global.Global_Variable.CLIENT
                                                   , Global.Global_Variable.COMPANY
                                                   , Global.Global_Variable.PLANT
                                                   , dteMonth.DateTime.ToString("yyyyMM") }
                                                   );


            gcList.DataSource = null;
            
            gvList.Columns.Clear();

            if (result.ResultInt == 0)
            {
                lblLastVersion.Text = result.ResultString;

                gvList.BeginUpdate();
                gvList.OptionsView.ShowAutoFilterRow = false;
                gvList.OptionsView.RowAutoHeight = true;

                gcList.DataSource = result.ResultDataSet.Tables[0];

                foreach (GridColumn gc in gvList.Columns)
                {
                    gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                    if (gc.FieldName.Equals("COLOR"))
                    {
                        gc.Visible = false;
                    }

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
            gvList.OptionsView.AllowCellMerge = true;
            gvList.Columns["ITEMCODE"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            gvList.Columns["PARTNO"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            gvList.Columns["LGORDQTY"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            gvList.Columns["HSETH"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            gvList.Columns["RATE"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            gvList.Columns["CIQTY"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY1"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY2"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY3"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY4"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY5"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY6"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY7"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY8"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY9"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY10"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY11"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY12"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY13"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY14"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY15"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY16"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY17"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY18"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY19"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY20"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY21"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY22"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY23"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY24"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY25"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY26"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY27"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY28"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY29"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY30"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            gvList.Columns["QTY31"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;

            gvList.EndUpdate();

            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();

            //DevExpress.XtraPrinting.XlsExportOptions _options = new DevExpress.XtraPrinting.XlsExportOptions();
            
            //_options.ExportMode = DevExpress.XtraPrinting.XlsExportMode.SingleFile;
            //_options.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Text;

            //SaveFileDialog savePanel = new SaveFileDialog();
            //savePanel.Filter = "Excel file|*.xls;";
            //DateTime time = DateTime.Now;
            //string timestr = String.Format("{0:yyyy.MM.dd HH.mm.ss}", time);
            //savePanel.FileName = "엑셀저장" + "(" + timestr + ")";
            //if (savePanel.ShowDialog() == DialogResult.OK) {
            //    gvList.ExportToXls(savePanel.FileName, _options);
            //    }
        }
        
        #endregion

        #region 일반이벤트

        private void gvList_Click(object sender, EventArgs e)
        {
            if (!(sender is GridAlias.GridView))
            {
                return;
            }

            //IDAT.Controls.IDATDevExpress _clsGrid = new IDAT.Controls.IDATDevExpress();

            GridAlias.GridView gridView = sender as GridAlias.GridView;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo gridHitINFO = BASE_clsDevexpressGridUtil.GetClickHitInfo(gvList, e);

            if (gridHitINFO.InRow && gridHitINFO.InColumn)
            {
                /// ============================================================
                /// 선택된 Row의 정보를 가져올려면 아래에 구현을 하면 된다.
                int RowIdx = gridHitINFO.RowHandle;
                int ColIdx = gridHitINFO.Column.AbsoluteIndex;
            }

            if (gridHitINFO.InRowCell)
            {
            }

            if (gridHitINFO.InColumn)
            {
            }

            if (gridHitINFO.InGroupColumn)
            {
            }

            if (gridHitINFO.InColumnPanel)
            {
            }

            if (gridHitINFO.InFilterPanel)
            {
            }

            if (gridHitINFO.InGroupColumn)
            {
            }
        }

        private void gvList_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
         
            if (_bRefresh == false)
            {
                // 신규 상태일때 다른 컬럼을 선택시에 기능을 상실하도록 한다.
                // 구현상 기능이 필요하지 않으면 주석처리 하세요.
                if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
                {
                    if (e.RowHandle == -2147483647)
                    {
                        e.Allow = false;
                    }
                }
            }
             
        }

        private void gvList_RowStyle(object sender, GridAlias.RowStyleEventArgs e)
        {
            DataTable changes = BASE_clsDevexpressGridUtil.GetChangedData(gcList, DataRowState.Modified);

            if (changes == null)
                return;

            if (e.RowHandle < 0)
                return;

            // 수정된 키값 필드를 입력한다.
            foreach (DataRow dr in changes.Rows)
            {
                if (dr["PARTNO"] != null)
                {
                    // 주키가 두개일 경우 AND 문으로 조건을 다중으로 준다.
                    if (dr["PARTNO"].ToString() == gvList.GetDataRow(e.RowHandle)["PARTNO"].ToString())
                    {
                        e.Appearance.ForeColor = Color.Red;                        
                    }
                }
            }
        }
        
        private void gleitemtype_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            
        }

        
        #endregion

       
        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.RestoreDirectory = true;
            ofd.Filter = "Excel Files(*.xls, *.xlsx, *.xlt)|*.xls;*.xlsx;*.xlt";
            //ofd.FilterIndex = 1;
            //

            if (dteMonth.EditValue == null)
            {
                LanguageInformation _clsLang = new LanguageInformation();
                string _strMsg = _clsLang.GetMessageString("MSG_ER_COMM_089");//날짜를 입력하세요
                iDATMessageBox.WARNINGMessage(_strMsg, this.Text, 3);
                return;
            }

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string _strFilePath = ofd.FileName;

                DataTable dTable = Global.GlobalFunction.ReadExcelFile(_strFilePath, "ORDER"); //EXCEL SHEET명
                //ExcelHelper excel = new ExcelHelper();
                //DataTable dTable = excel.GetSheetDataAsDataTable(_strFilePath, "ORDER");
                
                if (dTable == null)
                    return;

                dTable.Rows.RemoveAt(0);
                string _strModel = dTable.Rows[0]["F1"].ObjectNullString();

                LanguageInformation _clsLan = new LanguageInformation();
                string _strMsg = _clsLan.GetMessageString("MSG_QS_SAL_002"); //고객 계획을 업로드하시겠습니까?

                if (iDATMessageBox.QuestionMessage(_strMsg, this.Text) == System.Windows.Forms.DialogResult.Yes)
                {
                    string _strXml = this.GetDataTableToXml(dTable);
                    WSResults result = BASE_db.Execute_Proc( "PKGPRD_SALES.PUT_CUSTPLAN_ORDER_UPLOAD"
                                                           , 1
                                                           , new string[] {
                                                             "A_CLIENT"
                                                           , "A_COMPANY"
                                                           , "A_PLANT"
                                                           , "A_XML"
                                                           , "A_PLANDATE"
                                                           , "A_USER" }
                                                           , new string[] {
                                                             Global.Global_Variable.CLIENT
                                                           , Global.Global_Variable.COMPANY
                                                           , Global.Global_Variable.PLANT
                                                           , _strXml
                                                           , dteMonth.DateTime.ToString("yyyyMM")
                                                           , Global.Global_Variable.USER_ID }
                                                           );

                    if (result.ResultInt != 0)
                    {
                        iDATMessageBox.ErrorMessage(BASE_Language.GetMessageString(result.ResultString), this.Text, 5);
                    }
                    else
                    {
                        GetGridViewList();
                    }
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Process pc = new Process();
            pc.StartInfo.FileName = Application.StartupPath + @"\Excel\CUSTOMORDERUPLOAD.xlsx";
            pc.StartInfo.Verb = "Open";
            pc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            pc.Start();
        }

        private void btnUploadExcelFormXls_Click(object sender, EventArgs e)
        {
            Process pc = new Process();
            pc.StartInfo.FileName = Application.StartupPath + @"\Excel\CUSTOMORDERUPLOAD.xls";
            pc.StartInfo.Verb = "Open";
            pc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            pc.Start();
        }

        private void gvList_RowCellStyle(object sender, GridAlias.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;

            if (e.RowHandle >= 0)
            {
                if (e.Column.FieldName.StartsWith("QTY") || e.Column.FieldName.Equals("WO") || e.Column.FieldName.Equals("CIQTY"))
                {
                    if (View.GetRowCellValue(e.RowHandle, View.Columns["COLOR"]).ObjectNullString() == "TF")
                    {
                        e.Appearance.BackColor = Color.Yellow;
                    }
                }
                
            }
        }
    }
}
