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

namespace HAENGSUNG_HNSMES_UI.Forms.SAL
{
   

    public partial class SALB203 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {
        
        #region [Form Event]

        public SALB203()
        {
            InitializeComponent();           
        }

        private void SALB203_Load(object sender, EventArgs e)
        {
            Set_Init();
            toolTipController1.Active = true;
        }

        private void SALB203_Shown(object sender, EventArgs e)
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

        private void Set_Init()
        {
            string _strWarehouse = string.Empty;

            if (this.Tag.ObjectNullString() == "SALESSTOCK")
                _strWarehouse = "5";
            else if (this.Tag.ObjectNullString() == "PRODSTOCK")
                _strWarehouse = "6";
            
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

            gleWHLoc.EditValue = null;
            
            gcList1.DataSource = null;
            
            txtPartNo1.Text = "";
            
        }

        private void GetGridViewList()
        {
            if (tabbedControlGroup2.SelectedTabPageIndex == 0)
            {
                BASE_DXGridHelper.Bind_Grid( gcList1
                                           , "PKGPRD_REPORT.GET_PRODUCT_SILSA"
                                           , 1
                                           , new string[] {
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_DATE"
                                           , "A_WH"
                                           , "A_WHLOC"
                                           , "A_PARTNO" }
                                           , new string[] {
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , dteMonth.DateTime.ToString("yyyyMM")
                                           , gleWH.EditValue.ObjectNullString()
                                           , gleWHLoc.EditValue.ObjectNullString()
                                           , txtPartNo1.EditValue.ObjectNullString() }
                                           , false
                                           , ""
                                           , false
                                           , false
                                           );

                gvList1.OptionsView.ColumnAutoWidth = true;
                gvList1.OptionsView.ShowFooter = true;
                gvList1.BestFitColumns();
            }
            
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
                                                       , "3" }
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

    }
}
