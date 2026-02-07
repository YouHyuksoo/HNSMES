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
using NGS.WCFClient.DatabaseService;
using DevExpress.XtraGrid;
using DevExpress.XtraSplashScreen;

namespace HAENGSUNG_HNSMES_UI.Forms.MST
{
   
    public partial class MSTA218 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {
       
        #region [Form Event]

        public MSTA218()
        {
            InitializeComponent();           
        }

        private void MSTA218_Load(object sender, EventArgs e)
        {
            this.Set_Init();            
        }

        private void MSTA218_Shown(object sender, EventArgs e)
        {

        }

        

        #endregion

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
            // 수정 버튼 클릭 이벤트
        }


        public void StopButton_Click()
        {
            // 중지 버튼 클릭 이벤트
        }


        public void SearchButton_Click()
        {
            // 검색 버튼 클릭 이벤트
            this.GetGridViewList();
        }


        public void SaveButton_Click()
        {
            LanguageInformation _clsLan = new LanguageInformation();
            string _strMsg = _clsLan.GetMessageString("MSG_QS_MST_002"); //저장하시겠습니까?

            if (iDATMessageBox.QuestionMessage(_strMsg, this.Text) == System.Windows.Forms.DialogResult.Yes)
            {
                DataTable dt = (gcList.DataSource as DataTable).Select("SEL='Y'").CopyToDataTable();

                string sXml = GetDataTableToXml(dt);

                bool bRtn = BASE_db.Execute_Proc(  "PKGBAS_BASE.SET_WORKTIME"
                                                , 1
                                                , new string[] {
                                                  "A_CLIENT"
                                                , "A_COMPANY"
                                                , "A_PLANT"
                                                , "A_XML"
                                                , "A_USER" }
                                                , new string[] {
                                                  Global.Global_Variable.CLIENT
                                                , Global.Global_Variable.COMPANY
                                                , Global.Global_Variable.PLANT
                                                , sXml
                                                , Global.Global_Variable.USER_ID }
                                                , true );

                if (bRtn)
                {
                    iDATMessageBox.OKMessage("MSG_OK_REG_001", this.Text, 3);
                }
            }

            GetGridViewList();
        }


        public void PrintButton_Click()
        {
            // 출력 버튼 클릭 이벤트
        }


        public void RefreshButton_Click()
        {
            // 새로 고침 버튼 클릭 이벤트
            //GetGridViewListRefresh();
        }

        public void DeleteButton_Click()
        {
            // 삭제 버튼 클릭 이벤트
        }

        #endregion

        #region [Private Method]

        private void Set_Init()
        {
            gcList.DataSource = null;
            
        }       

        #endregion

        #region 함수
        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid(gcList
                                       , "PKGBAS_BASE.GET_WORKTIME"
                                       , 1
                                       , new string[] {
                                         "A_CLIENT"
                                       , "A_COMPANY"
                                       , "A_PLANT"
                                       , "A_SDATE"
                                       , "A_EDATE" }
                                       , new string[] {
                                         Global.Global_Variable.CLIENT
                                       , Global.Global_Variable.COMPANY
                                       , Global.Global_Variable.PLANT
                                       , dteFromTo.StartDate                                          
                                       , dteFromTo.EndDate }
                                       , false
                                       , ""
                                       , true
                                       , true
                                       , false
                                       , true
                                       , false
                                       );

            gvList.OptionsView.ShowGroupPanel = false;
            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();

            gvList.OptionsBehavior.Editable = true;
            gvList.Columns["SEL"].OptionsColumn.AllowEdit = false;
            gvList.Columns["WORKTIME1"].OptionsColumn.AllowEdit = true;
            gvList.Columns["WORKTIME2"].OptionsColumn.AllowEdit = true;
            gvList.Columns["WORKTIME3"].OptionsColumn.AllowEdit = true;
            gvList.Columns["WORKTIME4"].OptionsColumn.AllowEdit = true;
            gvList.Columns["WORKTIME5"].OptionsColumn.AllowEdit = true;
            gvList.Columns["WORKTIME6"].OptionsColumn.AllowEdit = true;
            gvList.Columns["WORKTIME7"].OptionsColumn.AllowEdit = true;
            gvList.Columns["WORKTIME8"].OptionsColumn.AllowEdit = true;
            gvList.Columns["WORKTIME9"].OptionsColumn.AllowEdit = true;
            gvList.Columns["WORKTIME10"].OptionsColumn.AllowEdit = true;
            gvList.Columns["WORKTIME11"].OptionsColumn.AllowEdit = true;
            gvList.Columns["WORKTIME12"].OptionsColumn.AllowEdit = true;
            gvList.Columns["WORKTIME13"].OptionsColumn.AllowEdit = true;
            gvList.Columns["WORKTIME14"].OptionsColumn.AllowEdit = true;
            gvList.Columns["WORKTIME15"].OptionsColumn.AllowEdit = true;
            gvList.Columns["WORKTIME16"].OptionsColumn.AllowEdit = true;
            gvList.Columns["WORKTIME17"].OptionsColumn.AllowEdit = true;
            gvList.Columns["WORKTIME18"].OptionsColumn.AllowEdit = true;
            gvList.Columns["WORKTIME19"].OptionsColumn.AllowEdit = true;
            gvList.Columns["WORKTIME20"].OptionsColumn.AllowEdit = true;
            gvList.Columns["WORKTIME21"].OptionsColumn.AllowEdit = true;
            gvList.Columns["WORKTIME22"].OptionsColumn.AllowEdit = true;
            gvList.Columns["WORKTIME23"].OptionsColumn.AllowEdit = true;
            gvList.Columns["WORKTIME24"].OptionsColumn.AllowEdit = true;


            WSResults result1 = BASE_db.Execute_Proc("PKGBAS_BASE.GET_WORKTIME",
                                                     1,
                                                     new string[] {
                                                                   "A_CLIENT",
                                                                   "A_COMPANY",
                                                                   "A_PLANT",
                                                                   "A_SDATE",
                                                                   "A_EDATE"
                                                                  },
                                                     new string[] {
                                                                   Global.Global_Variable.CLIENT,
                                                                   Global.Global_Variable.COMPANY,
                                                                   Global.Global_Variable.PLANT,
                                                                   dteFromTo.StartDate,                                          
                                                                   dteFromTo.EndDate
                                                                  }
                                                   );
            if (result1.ResultInt == 0)
            {
                gvList.BeginUpdate();
                gvList.OptionsView.RowAutoHeight = true;

                foreach (GridColumn gc in gvList.Columns)
                {
                    gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                    if (gc.FieldName.IndexOf("SEL") > -1 || gc.FieldName.IndexOf("WORKDATE") > -1 ||
                        gc.FieldName.IndexOf("PRODLINE") > -1 || gc.FieldName.IndexOf("UNITNM") > -1 )
                    {
                        gc.Fixed = FixedStyle.Left;
                    }


                    if (gc.FieldName.Equals("WORKTIME1"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = "00~01";

                    }
                    if (gc.FieldName.Equals("WORKTIME2"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = "01~02";

                    }
                    if (gc.FieldName.Equals("WORKTIME3"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = "02~03";

                    }
                    if (gc.FieldName.Equals("WORKTIME4"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = "03~04";

                    }
                    if (gc.FieldName.Equals("WORKTIME5"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = "04~05";

                    }
                    if (gc.FieldName.Equals("WORKTIME6"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = "05~06";

                    }
                    if (gc.FieldName.Equals("WORKTIME7"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = "06~07";

                    }
                    if (gc.FieldName.Equals("WORKTIME8"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = "07~08";

                    }
                    if (gc.FieldName.Equals("WORKTIME9"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = "08~09";

                    }
                    if (gc.FieldName.Equals("WORKTIME10"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = "09~10";

                    }
                    if (gc.FieldName.Equals("WORKTIME11"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = "10~11";

                    }
                    if (gc.FieldName.Equals("WORKTIME12"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = "11~12";

                    }
                    if (gc.FieldName.Equals("WORKTIME13"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = "12~13";

                    }
                    if (gc.FieldName.Equals("WORKTIME14"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = "13~14";

                    }
                    if (gc.FieldName.Equals("WORKTIME15"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = "14~15";

                    }
                    if (gc.FieldName.Equals("WORKTIME16"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = "15~16";

                    }
                    if (gc.FieldName.Equals("WORKTIME17"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = "16~17";

                    }
                    if (gc.FieldName.Equals("WORKTIME18"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = "17~18";

                    }
                    if (gc.FieldName.Equals("WORKTIME19"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = "18~19";

                    }
                    if (gc.FieldName.Equals("WORKTIME20"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = "19~20";

                    }
                    if (gc.FieldName.Equals("WORKTIME21"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = "20~21";

                    }
                    if (gc.FieldName.Equals("WORKTIME22"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = "21~22";

                    }
                    if (gc.FieldName.Equals("WORKTIME23"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = "22~23";

                    }
                    if (gc.FieldName.Equals("WORKTIME24"))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = "23~24";

                    }
                    
                }

            }

            gvList.EndUpdate();

        }

      

        #endregion


        #region [일반 이벤트]
        private void gvList_DoubleClick(object sender, EventArgs e)
        {
            
        }
        #endregion

        private void gvList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            if (gvList.GetRowCellValue(e.RowHandle, "SEL").ObjectNullString() != "Y")
            {
                if (e.Column.ObjectNullString() != "SEL")
                {
                    gvList.SetRowCellValue(e.RowHandle, "SEL", "Y");
                }
            }
        }

        
    }
}
