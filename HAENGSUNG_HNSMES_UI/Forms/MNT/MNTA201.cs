using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

namespace HAENGSUNG_HNSMES_UI.Forms.MNT
{
    public partial class MNTA201 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
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


        private int mFontSize = 36;
        private int mRowHeight = 100;

        #region [생성자]

        public MNTA201()
        {
            InitializeComponent();

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
            tcgMain.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;

            lblTimer.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            //화면 종류에 따라 프로그램 바인딩
            tcgMain.SelectedTabPageIndex = 0;

            RefreshData();
            
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
        private void RefreshData()
        {
            WSResults result = BASE_db.Execute_Proc( "PKGPRD_MNT.GET_DAILY_PROD_MONITERING"
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
                gvMonTab1.BeginUpdate(); //사내

                gvMonTab1.OptionsView.ShowAutoFilterRow = false;
                
                gvMonTab1.RowHeight = mRowHeight;
                
                gvMonTab1.ColumnPanelRowHeight = mRowHeight - 20;
                
                gvMonTab1.OptionsView.AllowCellMerge = false;
                
                gvMonTab1.OptionsView.RowAutoHeight = true;
                
                gcMonTab1.DataSource = result.ResultDataSet.Tables[0];
                
                gvMonTab1.Appearance.FooterPanel.Font = new Font(gvMonTab1.Appearance.FooterPanel.Font.Name, mFontSize, FontStyle.Bold);
                
                gcMonTab1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                gcMonTab1.LookAndFeel.UseDefaultLookAndFeel = false; // <<<<<<<<

                gvMonTab1.Appearance.HeaderPanel.Options.UseBackColor = true;
                gvMonTab1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Black;

                gvMonTab1.Appearance.FooterPanel.Options.UseBackColor = true;
                gvMonTab1.Appearance.FooterPanel.BackColor = Color.Black;
                gvMonTab1.Appearance.FooterPanel.Options.UseForeColor = true;
                gvMonTab1.Appearance.FooterPanel.ForeColor = Color.White;
                gvMonTab1.Appearance.FooterPanel.Options.UseBorderColor = true;
                gvMonTab1.Appearance.FooterPanel.BorderColor = Color.Black;



                foreach (GridColumn gc in gvMonTab1.Columns)
                {
                    if (gc.FieldName.IndexOf("PARTNO") > -1)
                    {
                        gc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                        gc.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                        gc.Width = 150;
                        gc.Caption = "P/NO";
                    }

                    if (gc.FieldName.IndexOf("PLANQTY") > -1)
                    {
                        //gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                        gc.Caption = "Plan";
                    }

                    if (gc.FieldName.IndexOf("PLANACHIVE") > -1)
                    {
                        gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                        gc.Caption = "P/Achi";
                    }
                    
                    if (gc.FieldName.IndexOf("TARGETQTY") > -1)
                    {
                        //gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                        gc.Caption = "Target";
                    }

                    if (gc.FieldName.IndexOf("TOTALQTY") > -1)
                    {
                        //gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                        gc.Caption = "Total";
                    }

                    if (gc.FieldName.IndexOf("GOODQTY") > -1)
                    {
                        //gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                        gc.Caption = "Good";
                    }

                    if (gc.FieldName.IndexOf("BADQTY") > -1)
                    {
                        //gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                        gc.Caption = "Bad";
                    }

                    if (gc.FieldName.IndexOf("ACHIEVEMENTRATIO") > -1)
                    {
                        gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                        gc.Caption = "T/Achi";
                    }

                    gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gc.AppearanceHeader.Font = new System.Drawing.Font(gc.AppearanceHeader.Font.Name, mFontSize - 6, FontStyle.Bold);

                    gc.AppearanceHeader.Options.UseBackColor = true;
                    gc.AppearanceHeader.BackColor = Color.Black;
                    gc.AppearanceHeader.Options.UseForeColor = true;
                    gc.AppearanceHeader.ForeColor = Color.Yellow;

                    if (gc.FieldName.IndexOf("TARGETQTY") > -1 || gc.FieldName.IndexOf("TOTALQTY") > -1 || gc.FieldName.IndexOf("GOODQTY") > -1 || gc.FieldName.IndexOf("BADQTY") > -1)
                    {
                        gc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        gc.DisplayFormat.FormatString = "#,##0";

                        gc.SummaryItem.DisplayFormat = "{0:#,##0}";
                    }

                }
                
                gvMonTab1.EndUpdate();
                
            }

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

            lblTimer.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            lblSecond.Text = mSecond.ToString() + " sec";
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

        private void gv_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView View = sender as GridView;

            View.Appearance.FocusedRow.BackColor = Color.White;
            View.Appearance.FocusedCell.BackColor = Color.White;
            View.Appearance.SelectedRow.BackColor = Color.Gold;
            View.Appearance.HideSelectionRow.BackColor = Color.Gold;
        }

        private void gv_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;

            if (e.RowHandle >= 0)
            {
                int iPassRate = 0;
                e.Appearance.BackColor = Color.Black;
                e.Appearance.ForeColor = Color.White;
                if (e.Column.FieldName == "PLANACHIVE")
                {
                    int.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["PLANACHIVE"]).ObjectNullString(), out iPassRate);

                    if (e.Column.FieldName == "PLANACHIVE")
                    {
                        if (iPassRate < 100)
                        {
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.ForeColor = Color.White;
                        }
                        else
                        {
                            e.Appearance.BackColor = Color.Green;
                            e.Appearance.ForeColor = Color.White;
                        }
                    }
                }

                if (e.Column.FieldName == "ACHIEVEMENTRATIO")
                {
                    int.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["ACHIEVEMENTRATIO"]).ObjectNullString(), out iPassRate);

                    if (e.Column.FieldName == "ACHIEVEMENTRATIO")
                    {
                        if (iPassRate < 100)
                        {
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.ForeColor = Color.White;
                        }
                        else
                        {
                            e.Appearance.BackColor = Color.Green;
                            e.Appearance.ForeColor = Color.White;
                        }
                    }
                }
            }
        }
        private void gv_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "PLANACHIVE")
            {
                object v = e.Info.Value;
                if (!(v is decimal))
                {
                    return;
                }

                decimal d = Convert.ToDecimal(v);
                if (d < 100)
                    e.Appearance.BackColor = Color.Red;
                else
                    e.Appearance.BackColor = Color.Green;
            }
            if (e.Column.FieldName == "ACHIEVEMENTRATIO")
            {
                object v = e.Info.Value;
                if (!(v is decimal))
                {
                    return;
                }

                decimal d = Convert.ToDecimal(v);
                if (d < 100)
                    e.Appearance.BackColor = Color.Red;
                else
                    e.Appearance.BackColor = Color.Green;
            }

        }
        private void gv_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            //GridView View = sender as GridView;

            //if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("ACHIEVEMENTRATIO") == 0)
            //{
            //    decimal dExprodQty, dResultQty;
            //    var vExprodQty = View.Columns["TARGET"].SummaryItem.SummaryValue;
            //    var vResultQty = View.Columns["RESULT"].SummaryItem.SummaryValue;


            //    decimal.TryParse(vExprodQty.ObjectNullString(), out dExprodQty);
            //    decimal.TryParse(vResultQty.ObjectNullString(), out dResultQty);

            //    if (dResultQty > 0 && dExprodQty > 0)
            //    {
            //        decimal dResult = Math.Round(dResultQty / dExprodQty * 100, 0);

            //        e.TotalValue = Math.Round(dResult, 0);
            //    }

            //}
            //if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("STRAIGHTRATIO") == 0)
            //{
            //    decimal dExprodQty, dResultQty;
            //    var vExprodQty = View.Columns["TOTALQTY"].SummaryItem.SummaryValue;
            //    var vResultQty = View.Columns["RESULT"].SummaryItem.SummaryValue;


            //    decimal.TryParse(vExprodQty.ObjectNullString(), out dExprodQty);
            //    decimal.TryParse(vResultQty.ObjectNullString(), out dResultQty);

            //    if (dResultQty > 0 && dExprodQty > 0)
            //    {
            //        decimal dResult = Math.Round(dResultQty / dExprodQty * 100, 0);

            //        e.TotalValue = Math.Round(dResult, 0);
            //    }

            //}
            //if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("PROGRESS") == 0)
            //{
            //    //decimal dExprodQty, dResultQty;
            //    //var vExprodQty = View.Columns["PLAN"].SummaryItem.SummaryValue;
            //    //var vResultQty = View.Columns["RESULT"].SummaryItem.SummaryValue;


            //    //decimal.TryParse(vExprodQty.ObjectNullString(), out dExprodQty);
            //    //decimal.TryParse(vResultQty.ObjectNullString(), out dResultQty);

            //    //if (dResultQty > 0 && dExprodQty > 0)
            //    //{
            //    //    decimal dResult = Math.Round(dExprodQty / dResultQty, 0);

            //    //    e.TotalValue = Math.Round(dResult, 0);
            //    //}
            //    //else
            //    //{
            //    //    e.TotalValue = 0;
            //    //}

            //    decimal dProgress = 0;

            //    for (int i = 0; i < View.RowCount; i++)
            //    {
            //        decimal dCal = 0;
            //        decimal.TryParse(View.GetRowCellValue(i, "PROGRESS").ObjectNullString(), out dCal);
            //        dProgress += dCal;
            //    }


            //    if (dProgress > 0 && View.RowCount > 0)
            //    {
            //        e.TotalValue = Math.Round(dProgress / View.RowCount, 0);
            //    }
            //    else
            //    {
            //        e.TotalValue = 0;
            //    }



            //}
        }


        private void gv_RowCellDefaultAlignment(object sender, DevExpress.XtraGrid.Views.Base.RowCellAlignmentEventArgs e)
        {
            if (e.Column.FieldName == "LINE" || e.Column.FieldName == "PARTNO" || e.Column.FieldName == "STARTTIME" || e.Column.FieldName == "ENDTIME")
                e.HorzAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void lblTimer_Click(object sender, EventArgs e)
        {
            btnExit_Click(null, null);

        }

        private void pnlLanguage_Click(object sender, EventArgs e)
        {
           
        }

       
        //private void gvMonTab2_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        //{
        //    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("STRAIGHTRATIO") == 0)
        //    {
        //        decimal dResultQty, dGoodQty;
        //        var vResultQty = gvMonTab2.Columns["ACC_RESULTQTY"].SummaryItem.SummaryValue;
        //        var vGoodQty = gvMonTab2.Columns["GOODQTY"].SummaryItem.SummaryValue;


        //        decimal.TryParse(vResultQty.ObjectNullString(), out dResultQty);
        //        decimal.TryParse(vGoodQty.ObjectNullString(), out dGoodQty);

        //        if (dGoodQty > 0 && dResultQty > 0)
        //        {
        //            decimal dResult = Math.Round(dGoodQty / dResultQty * 100, 0);

        //            e.TotalValue = Math.Round(dResult, 0);
        //        }

        //    }   
        //}
        //private void gvMonTab3_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        //{

        //}

    }
}
