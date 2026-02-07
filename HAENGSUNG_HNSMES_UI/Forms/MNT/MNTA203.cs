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




namespace HAENGSUNG_HNSMES_UI.Forms.MNT
{

    public partial class MNTA203 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {

        #region 생성
        private int mSecond = 100;

        public MNTA203()
        {
            InitializeComponent();
        }

        private void MNTA203_Load(object sender, EventArgs e)
        {
                     
        }

        private void MNTA203_Shown(object sender, EventArgs e)
        {
            
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


            WSResults result = BASE_db.Execute_Proc("PKGHNS_REPORT.GET_SALE_MONITOR1",
                                                                 1,
                                                                 new string[] {
                                                                                "A_CLIENT"
                                                                              , "A_COMPANY"
                                                                              , "A_PLANT"
                                                                              },
                                                                 new string[] {
                                                                                Global.Global_Variable.CLIENT
                                                                              , Global.Global_Variable.COMPANY
                                                                              , Global.Global_Variable.PLANT 
                                                                              }
                                                   );

            if (result.ResultInt == 0)
            {
                gvList.BeginUpdate();
                gvList.OptionsView.ShowAutoFilterRow = false;
                gvList.OptionsView.RowAutoHeight = true;

                gcList.DataSource = result.ResultDataSet.Tables[0];


                foreach (GridColumn gc in gvList.Columns)
                {
                    gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                    if (gc.FieldName.IndexOf("PARTNO") > -1 || 
                        gc.FieldName.IndexOf("MONTHPLANQTY") > -1 || gc.FieldName.IndexOf("D0PLANQTY") > -1 || 
                        gc.FieldName.IndexOf("PRODPLAN") > -1 || gc.FieldName.IndexOf("D0DELIQTY") > -1 ||
                        gc.FieldName.IndexOf("ACCUQTY") > -1 || gc.FieldName.IndexOf("D0RATE") > -1 ||
                        gc.FieldName.IndexOf("ACCRATE") > -1 || gc.FieldName.IndexOf("PRODSTOCKQTY") > -1 ||
                        gc.FieldName.IndexOf("SALESTOCKQTY") > -1)
                    {
                        gc.Fixed = FixedStyle.Left;

                    }



                    if (gc.FieldName.IndexOf("SHORTAGEQTY1") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][0].ObjectNullString();
                    }
                    if (gc.FieldName.IndexOf("SHORTAGEQTY2") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][1].ObjectNullString();
                    }
                    if (gc.FieldName.IndexOf("SHORTAGEQTY3") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][2].ObjectNullString();
                    }
                    if (gc.FieldName.IndexOf("SHORTAGEQTY4") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][3].ObjectNullString();
                    }
                    if (gc.FieldName.IndexOf("SHORTAGEQTY5") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][4].ObjectNullString();
                    }
                    if (gc.FieldName.IndexOf("SHORTAGEQTY6") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][5].ObjectNullString();
                    }
                    if (gc.FieldName.IndexOf("SHORTAGEQTY7") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][6].ObjectNullString();
                    }
                    if (gc.FieldName.IndexOf("SHORTAGEQTY8") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][7].ObjectNullString();
                    }
                    if (gc.FieldName.IndexOf("SHORTAGEQTY9") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][8].ObjectNullString();
                    }
                    if (gc.FieldName.IndexOf("SHORTAGEQTY10") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][9].ObjectNullString();
                    }
                    if (gc.FieldName.IndexOf("SHORTAGEQTY11") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][10].ObjectNullString();
                    }
                    if (gc.FieldName.IndexOf("SHORTAGEQTY12") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][11].ObjectNullString();
                    }
                    if (gc.FieldName.IndexOf("SHORTAGEQTY13") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][12].ObjectNullString();
                    }
                    if (gc.FieldName.IndexOf("SHORTAGEQTY14") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][13].ObjectNullString();
                    }
                    if (gc.FieldName.IndexOf("SHORTAGEQTY15") > -1)
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][14].ObjectNullString();
                    }

                    if (gc.FieldName.IndexOf("D0RATE") > -1)
                    {
                        gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                    }

                    if (gc.FieldName.IndexOf("ACCRATE") > -1)
                    {
                        gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                    }
                }
            }
            SplashScreenManager.CloseForm(true);

            gvList.EndUpdate();

            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();

            gvList.Columns["D0RATE"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            gvList.Columns["ACCRATE"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
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
                decimal iPassRate = 0;
                
                if (e.Column.FieldName.Contains("SHORTAGEQTY1"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                }               
                if (e.Column.FieldName.Contains("SHORTAGEQTY2"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                }                
                if (e.Column.FieldName.Contains("SHORTAGEQTY3"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                }
                if (e.Column.FieldName.Contains("SHORTAGEQTY4"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                }
                if (e.Column.FieldName.Contains("SHORTAGEQTY5"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                }
                if (e.Column.FieldName.Contains("SHORTAGEQTY6"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                }
                if (e.Column.FieldName.Contains("SHORTAGEQTY7"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                }
                if (e.Column.FieldName.Contains("SHORTAGEQTY8"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                }
                if (e.Column.FieldName.Contains("SHORTAGEQTY9"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                }
                if (e.Column.FieldName.Contains("SHORTAGEQTY10"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                }
                if (e.Column.FieldName.Contains("SHORTAGEQTY11"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                }
                if (e.Column.FieldName.Contains("SHORTAGEQTY12"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                }
                if (e.Column.FieldName.Contains("SHORTAGEQTY13"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                }
                if (e.Column.FieldName.Contains("SHORTAGEQTY14"))
                {
                    decimal.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString(), out iPassRate);

                    if (iPassRate < 0)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                }
                if (e.Column.FieldName.Contains("SHORTAGEQTY15"))
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

            if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("D0RATE") == 0)
            {
                decimal dDDeliQty, dDPlanQty;

                var vDDeliQty = View.Columns["D0DELIQTY"].SummaryItem.SummaryValue;
                var vDPlanQty = View.Columns["D0PLANQTY"].SummaryItem.SummaryValue;


                decimal.TryParse(vDDeliQty.ObjectNullString(), out dDDeliQty);
                decimal.TryParse(vDPlanQty.ObjectNullString(), out dDPlanQty);

                if (dDDeliQty > 0 && dDPlanQty > 0)
                {
                    decimal dResult = Math.Round(dDDeliQty / dDPlanQty * 100, 2);

                    e.TotalValue = Math.Round(dResult, 2) + "%";
                }
            }
            if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("ACCRATE") == 0)
            {
                decimal dMDeliQty, dMPlanQty;

                var vMDeliQty = View.Columns["ACCUQTY"].SummaryItem.SummaryValue;
                var vMPlanQty = View.Columns["MONTHPLANQTY"].SummaryItem.SummaryValue;


                decimal.TryParse(vMDeliQty.ObjectNullString(), out dMDeliQty);
                decimal.TryParse(vMPlanQty.ObjectNullString(), out dMPlanQty);

                if (dMDeliQty > 0 && dMPlanQty > 0)
                {
                    decimal dResult = Math.Round(dMDeliQty / dMPlanQty * 100, 2);

                    e.TotalValue = Math.Round(dResult, 2) + "%";
                }
            }
        }

        
       
        
    }
}
