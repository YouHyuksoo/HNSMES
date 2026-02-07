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

    public partial class MNTB203 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {
        #region [Form Event]


        public MNTB203()
        {
            InitializeComponent();           
        }

        private void MNTB203_Load(object sender, EventArgs e)
        {
            dteDate.EditValue = DateTime.Now;
        }

        private void MNTB203_Shown(object sender, EventArgs e)
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
            /// ****************** GridControl과 Bind Grid ***************
            /// 입력컨트롤과 GridControl의 바인딩은 필수적으로 BASE_DXGridHelper.Bind_Grid(...) 사용하도록 함.
            /// **********************************************************
            /// 

            WSResults result = BASE_db.Execute_Proc("PKGHNS_REPORT.GET_MAT_BALANCE",
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

            if (result.ResultInt == 0)
            {
                
                gcListAll.DataSource = result.ResultDataSet.Tables[0];

                gvListAll.OptionsView.AllowCellMerge = true;

                #region 날짜(일자) 변환
                foreach (GridColumn gc in gvListAll.Columns)
                {

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
                    if (gc.FieldName.Equals("QTY47"))
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
                    if (gc.FieldName.Equals("QTY48"))
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
                    if (gc.FieldName.Equals("QTY49"))
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
                    if (gc.FieldName.Equals("QTY50"))
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
                    if (gc.FieldName.Equals("QTY51"))
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
                    if (gc.FieldName.Equals("QTY52"))
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
                    if (gc.FieldName.Equals("QTY53"))
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
                    if (gc.FieldName.Equals("QTY54"))
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
                    if (gc.FieldName.Equals("QTY55"))
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
                    if (gc.FieldName.Equals("QTY56"))
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
                    if (gc.FieldName.Equals("QTY57"))
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
                    if (gc.FieldName.Equals("QTY58"))
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
                    if (gc.FieldName.Equals("QTY59"))
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
                    if (gc.FieldName.Equals("QTY60"))
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
                    if (gc.FieldName.Equals("QTY61"))
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
                    if (gc.FieldName.Equals("QTY62"))
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

                }
                #endregion

                gvListAll.OptionsView.ColumnAutoWidth = false;
                gvListAll.BestFitColumns();

            }
        }
        #endregion

        private void gvListAll_CellMerge(object sender, CellMergeEventArgs e)
        {
            if (e.Column.FieldName == "ITEMCODE" || e.Column.FieldName == "PARTNO" || e.Column.FieldName == "MAT_BEGIN" || e.Column.FieldName == "WIP_BEGIN")//Name 컬럼만 Merge
            {
                var dr1 = gvListAll.GetDataRow(e.RowHandle1); //위에 행 정보
                var dr2 = gvListAll.GetDataRow(e.RowHandle2); //아래 행 정보

                string _str1 = dr1["ITEMCODE"].ObjectNullString() + dr1["PARTNO"].ObjectNullString() + dr1["MAT_BEGIN"].ObjectNullString() + dr1["WIP_BEGIN"].ObjectNullString();
                string _Str2 = dr2["ITEMCODE"].ObjectNullString() + dr2["PARTNO"].ObjectNullString() + dr2["MAT_BEGIN"].ObjectNullString() + dr2["WIP_BEGIN"].ObjectNullString();

                //비교하는 이유 그래야 정상적으로 나옴.
                e.Merge = _str1.Equals(_Str2);
            }
            else
            {
                e.Merge = false;
            }
            e.Handled = true;

        }

        private void gvListAll_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;

            if (e.RowHandle >= 0)
            {
                decimal iPassRate = 0;
                if (e.Column.FieldName.Contains("QTY"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                }
            }
        }
        
    }
}


