using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

// DevExpress namespace
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraGrid.Views.Grid;

// User namespace
using HAENGSUNG_HNSMES_UI.Class;
using GridAlias = DevExpress.XtraGrid.Views.Grid;
//using Google.API.Translate;
using HAENGSUNG_HNSMES_UI.WebService.Access;
using HAENGSUNG_HNSMES_UI.WebService.Business;

namespace HAENGSUNG_HNSMES_UI.Forms.MAT
{
    public partial class MATB212 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {
        #region [Form Event]

        public MATB212()
        {
            InitializeComponent();           
        }

        private void MATB212_Load(object sender, EventArgs e)
        {
            this.Set_Init();            
        }

        private void MATB212_Shown(object sender, EventArgs e)
        {

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

            //base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);

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
            // 저장 버튼 클릭 이벤트         
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
            tabList.SelectedTabPageIndex = 0;
            gcList.DataSource = null;
            gcListD.DataSource = null;
            gcListR.DataSource = null;
            gcList4.DataSource = null;

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWHLOC
                                                       , "PKGBAS_BASE.GET_LOCATION2"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_VIEW" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , "0" }
                                                       , "WHLOC"
                                                       , "WHLOCNAME"
                                                       , "WHLOC, WHLOCNAME, REMARKS"
                                                       );
        }       

        #endregion

        #region 함수
        private void GetGridViewList()
        {
            string _strBrdType = "";
            switch (tabList.SelectedTabPageIndex)
            {
                case (0):
                    _strBrdType = "B";
                    get_Defect_History(gcList, gvList, _strBrdType);
                    break;
                case (1):
                    _strBrdType = "R";
                    get_Defect_History(gcListR, gvListR, _strBrdType);
                    break;
                case (2):
                    _strBrdType = "D";
                    get_Defect_History(gcListD, gvListD, _strBrdType);
                    break;
                case (3):
                    _strBrdType = "G";
                    get_Defect_History(gridControl1, gridView1, _strBrdType);
                    break;
                //case (4):
                //    _strBrdType = "C";
                //    get_Defect_History(gcList4, gvList4, _strBrdType);
                //    break;
                case (4):
                    _strBrdType = "T";
                    get_Defect_History(gcList5, gvList5, _strBrdType);
                    break;
                default :
                    _strBrdType = "B";
                    get_Defect_History(gcList, gvList, _strBrdType);
                    break;
            }
          

        }
        private void get_Defect_History(DevExpress.XtraGrid.GridControl gc, DevExpress.XtraGrid.Views.Grid.GridView gv, string p_strBrdType)
        {
            //****************** GridControl과 Bind Grid ***************
            //입력컨트롤과 GridControl의 바인딩은 필수적으로 BASE_DXGridHelper.Bind_Grid(...) 사용하도록 함.
            //**********************************************************

            if (p_strBrdType == "R")
            {
                BASE_DXGridHelper.Bind_Grid( gc
                                           , "PKGBAS_BRD.GET_DEFECT_HISTORY3"
                                           , 1
                                           , new string[] {
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_FROMDATE"
                                           , "A_TODATE"
                                           , "A_WHLOC" }
                                           , new string[] {
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , dteFromTo.StartDate                                          
                                           , dteFromTo.EndDate
                                           , gleWHLOC.EditValue.ObjectNullString() }
                                           , false
                                           , ""
                                           , true                                            
                                           , true
                                           , false
                                           , true
                                           , false
                                           );

                // 2014.11.13 홍성원
                // 박영순B 요청으로 아래 컬럼들 Merge
                /*
                gv.Columns["SERIAL"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                gv.Columns["PARTNO"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                gv.Columns["SIDE"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                gv.Columns["QTY"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                gv.Columns["OPERNAME"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                gv.Columns["DEFECTNAME"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                gv.Columns["REASON"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                gv.Columns["REMARKS"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                gv.Columns["REGUSERNAME"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                */
            }
            else
            {
                HAENGSUNG_HNSMES_UI.WebService.Access.WSResults result = 
                    BASE_db.Execute_Proc( "PKGBAS_BRD.GET_DEFECT_HISTORY3"
                                        , 1
                                        , new string[] { 
                                          "A_CLIENT"
                                        , "A_COMPANY"
                                        , "A_PLANT"
                                        , "A_FROMDATE"
                                        , "A_TODATE"
                                        , "A_WHLOC" }
                                        , new string[] {
                                          Global.Global_Variable.CLIENT
                                        , Global.Global_Variable.COMPANY
                                        , Global.Global_Variable.PLANT
                                        , dteFromTo.StartDate                                          
                                        , dteFromTo.EndDate
                                        , gleWHLOC.EditValue.ObjectNullString() }
                                        );

                 if (result.ResultInt == 0)
                 {
                     gc.DataSource = result.ResultDataSet.Tables[0];

                     /*
                     if (result.ResultDataSet.Tables[1].Rows.Count > 0)
                     {
                         txtBQty.Text = result.ResultDataSet.Tables[1].Rows[0]["BQTY"].ToString();
                         txtRQty.Text = result.ResultDataSet.Tables[1].Rows[0]["RQTY"].ToString();
                         txtSrQty.Text = result.ResultDataSet.Tables[1].Rows[0]["SRQTY"].ToString();
                         txtFQty.Text = result.ResultDataSet.Tables[1].Rows[0]["FQYT"].ToString();
                         txtSfQty.Text = result.ResultDataSet.Tables[1].Rows[0]["SFQTY"].ToString();
                     }
                     else
                     {
                         txtBQty.Text = "0";
                         txtRQty.Text = "0";
                         txtSrQty.Text = "0";
                         txtFQty.Text = "0";
                         txtSfQty.Text = "0";
                     }
                     */
                     
                 }

            }
            gv.OptionsView.ShowGroupPanel = false;
            gv.OptionsView.ColumnAutoWidth = false;
            gv.BestFitColumns();

        }

        #endregion

        private void tabList_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            if (tabList.SelectedTabPageIndex == 5)
            {               
                layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }

            
        }

        
        private void txtBQty_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;

        }

        #region [일반 이벤트]

        #endregion

    }
}
