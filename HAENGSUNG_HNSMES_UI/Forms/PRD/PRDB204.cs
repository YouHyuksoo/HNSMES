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
using DevExpress.XtraGrid.Views;

// User namespace
using HAENGSUNG_HNSMES_UI.Class;
using GridAlias = DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo; 

namespace HAENGSUNG_HNSMES_UI.Forms.PRD
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : PRDB204<br/>
    ///      기능 : 일별 생산 현황 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>

    public partial class PRDB204 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {
        // ******************************************* Base From Class ************************************
        // BASE_clsDevexpressGridUtil          DevExpress Grid 관련 Util Class.
        // BASE_db;                            웹서비스 DB처리 관련 Util Class.
        // BASE_DXGridHelper;                  DevExpress GridControl 데이터 Bind관련 Class
        // BASE_DXGridLookUpHelper;            DevExpress GridLookUp 데이터 Bind관련 Class
        // BASE_IDATLayoutUtil;                DevExpress LayoutControl Util Class.
        // BASE_Language;                      Language Util. ex) BASE_Language.GetMessageString("Code") 
        // ************************************************************************************************

        #region [Form Event]

        public PRDB204()
        {
            InitializeComponent();           
        }

        private void PRDB204_Load(object sender, EventArgs e)
        {
            Set_Init();
            toolTipController1.Active = true;
        }

        private void PRDB204_Shown(object sender, EventArgs e)
        {

        }

        #endregion

        #region [Button Event]

        public void InitButton_Click()
        {
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

       
        public void SearchButton_Click()
        {
            if (tabbedControlGroup1.SelectedTabPageIndex == 0)
                this.InCompany_GetGridViewList();
            else
                this.OutSourcing_GetGridViewList();
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

        private void Set_Init()
        {
            string _strWarehouse = string.Empty;

            if (this.Tag.ObjectNullString() == "PRODSTOCK")
                _strWarehouse = "3";
            else if (this.Tag.ObjectNullString() == "MATSTOCK")
                _strWarehouse = "4";
            else if (this.Tag.ObjectNullString() == "SALESSTOCK")
                _strWarehouse = "5";


            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWH
                                                       , "PKGBAS_BASE.GET_WAREHOUSE"
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
                                                       , _strWarehouse }
                                                       , "WAREHOUSE"
                                                       , "WAREHOUSENAME"
                                                       , "WAREHOUSE, WAREHOUSENAME, REMARKS"
                                                       );

            //if ((gleWH.Properties.DataSource as DataTable).Rows.Count > 2)
            //{
            //    gleWH.EditValue = gleWH.Properties.GetKeyValue(1);
            //    gleWH.Enabled = false;
            //}

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleVendor
                                                       , "GPKGBAS_BASE.GET_VENDOR"
                                                       , 1
                                                       , new string[] { 
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_PURCHASE"
                                                       , "A_SALES"
                                                       , "A_OUTSC"
                                                       , "A_VIEW" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , "Y"
                                                       , "Y"
                                                       , "Y"
                                                       , "0" }
                                                       , "VENDOR"
                                                       , "VENDORNAME"
                                                       , "VENDOR, VENDORNAME"
                                                       );
            
            gleWHLoc.EditValue = null;
            gleVendor.EditValue = null;
            gcList1.DataSource = null;
            gcList2.DataSource = null;
            txtPartNo1.Text = "";
            txtPartNo2.Text = "";

            tmrRefresh.Start();
        }

        private void InCompany_GetGridViewList()
        {
            if (tabbedControlGroup2.SelectedTabPageIndex == 0)
            {
                BASE_DXGridHelper.Bind_Grid( gcList1
                                           , "PKGPRD_REPORT.GET_DAILY_STOCK_A"
                                           , 1
                                           , new string[] {
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_SDATE"
                                           , "A_EDATE"
                                           , "A_WH"
                                           , "A_WHLOC"
                                           , "A_PARTNO" }
                                           , new string[] {
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , dteFromTo.StartDate
                                           , dteFromTo.EndDate
                                           , gleWH.EditValue.ObjectNullString()
                                           , gleWHLoc.EditValue.ObjectNullString()
                                           , txtPartNo1.EditValue.ObjectNullString() }
                                           , false
                                           , ""
                                           , false
                                           , false
                                           );

                gvList1.OptionsView.ColumnAutoWidth = false;
                gvList1.OptionsView.ShowFooter = true;
                gvList1.BestFitColumns();
            }
            else
            {
                BASE_DXGridHelper.Bind_Grid( gcList3
                                           , "PKGPRD_REPORT.GET_DAILY_STOCK_B"
                                           , 1
                                           , new string[] {
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_SDATE"
                                           , "A_EDATE"
                                           , "A_WH"
                                           , "A_WHLOC"
                                           , "A_PARTNO" }
                                           , new string[] {
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , dteFromTo.StartDate
                                           , dteFromTo.EndDate
                                           , gleWH.EditValue.ObjectNullString()
                                           , gleWHLoc.EditValue.ObjectNullString()
                                           , txtPartNo1.EditValue.ObjectNullString() }
                                           , false
                                           , "LONGDATEGBN, LONGSTOCKDATE"
                                           , false
                                           , false
                                           );

                gvList3.OptionsView.ColumnAutoWidth = false;
                gvList3.OptionsView.ShowFooter = true;
                gvList3.BestFitColumns();
            }
        }

        private void OutSourcing_GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid( gcList2
                                       , "PKGBAS_MAT.GET_MATERIAL_STOCK_OUTSOURCING"
                                       , 1
                                       , new string[] {
                                         "A_PLANT"
                                       , "A_VENDOR"
                                       , "A_PARTNO" }
                                       , new string[] {
                                         Global.Global_Variable.PLANT
                                       , gleVendor.EditValue.ObjectNullString()
                                       , txtPartNo2.EditValue.ObjectNullString() }
                                       , true
                                       );

            gvList2.BestFitColumns();
        }

        private void Set_SearchLocation(string p_strWH)
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWHLoc
                                                       , "PKGBAS_BASE.GET_LOCATION"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_WAREHOUSE"
                                                       , "A_VIEW" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , gleWH.EditValue.ObjectNullString()
                                                       , "0" }
                                                       , "WHLOC"
                                                       , "WHLOCNAME"
                                                       , "WHLOC, WHLOCNAME, REMARKS"
                                                       );  
        }

        #endregion

        private void gleWH_EditValueChanged(object sender, EventArgs e)
        {
            Set_SearchLocation(gleWH.EditValue.ObjectNullString());
        }

        private void gvList3_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (gvList3.RowCount > 0 && e.RowHandle >= 0 && e.RowHandle < gvList3.RowCount)
            {
                if (gvList3.GetRowCellValue(e.RowHandle, "LONGDATEGBN").ObjectNullString() == "Y")
                {
                    e.Appearance.BackColor = Color.Red;
                }
            }
        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            if (tabbedControlGroup2.SelectedTabPageIndex == 0)
                SearchButton_Click();
        }

        private void PRDB204_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrRefresh.Stop();
        }

        private void gvList1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            BASE_DXGridHelper.Bind_Grid( gcList4
                                       , "PKGPRD_REPORT.GET_DAILY_STOCK_MATERIAL"
                                       , 1
                                       , new string[] {
                                         "A_CLIENT"
                                       , "A_COMPANY"
                                       , "A_PLANT"
                                       , "A_WRKORD"
                                       , "A_OUTDATE"
                                       , "A_ITEMCODE" }
                                       , new string[] {
                                         Global.Global_Variable.CLIENT
                                       , Global.Global_Variable.COMPANY
                                       , Global.Global_Variable.PLANT
                                       , gvList1.GetFocusedRowCellValue("WRKORD").ObjectNullString()
                                       , gvList1.GetFocusedRowCellValue("PRODDATE").ObjectNullString()
                                       , gvList1.GetFocusedRowCellValue("ITEMCODE").ObjectNullString() }
                                       , false
                                       , ""
                                       , false
                                       , false
                                       );

            gvList4.OptionsView.ColumnAutoWidth = false;
            gvList4.OptionsView.ShowFooter = true;
            gvList4.BestFitColumns();
        }
    }
}
