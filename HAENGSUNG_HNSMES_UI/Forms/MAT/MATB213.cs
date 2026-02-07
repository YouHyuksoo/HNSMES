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
using HAENGSUNG_HNSMES_UI.WebService.Access;

namespace HAENGSUNG_HNSMES_UI.Forms.MAT
{
    // 조회
    // 자재입고, 자재출고, 자재입/출고, Split/Merge이력

    public partial class MATB213 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {
        #region [Form Event]

        public MATB213()
        {
            InitializeComponent();           
        }

        private void MATB213_Load(object sender, EventArgs e)
        {

        }

        private void MATB213_Shown(object sender, EventArgs e)
        {
            this.Set_Init();
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
            txtPartNo.Text = "";

            gcList1.DataSource = null;

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
                                                       , "0"  }
                                                       , "WAREHOUSE"
                                                       , "WAREHOUSENAME"
                                                       , "WAREHOUSE, WAREHOUSENAME, REMARKS"
                                                       );
            gleWHLoc.Properties.DataSource = null;

            string p_strWH = gleWH.EditValue.ObjectNullString();

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
                                                       , "2" }
                                                       , "WHLOC"
                                                       , "WHLOCNAME"
                                                       , "WHLOC, WHLOCNAME, REMARKS"
                                                       );  
        }
        
        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid( gcList1
                                       , "PKGHNS_REPORT.GET_LONGSTOCK_LIST"
                                       , 1
                                       , new string[] {
                                         "A_CLIENT"
                                       , "A_COMPANY"
                                       , "A_PLANT"
                                       , "A_PERIOD"
                                       , "A_WAREHOUSE"
                                       , "A_WHLOC"
                                       , "A_PARTNO" }
                                       , new string[] {
                                         Global.Global_Variable.CLIENT
                                       , Global.Global_Variable.COMPANY
                                       , Global.Global_Variable.PLANT
                                       , txtPeriod.Text.Trim()
                                       , gleWH.EditValue.ObjectNullString()
                                       , gleWHLoc.EditValue.ObjectNullString()
                                       , txtPartNo.Text.Trim() }
                                       , true
                                       );

            gvList1.Columns["PERIOD"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvList1.Columns["PERIOD"].DisplayFormat.FormatString = "{0:n2}";

            gvList1.OptionsBehavior.Editable = true;
            
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
                                                       , "2" }
                                                       , "WHLOC"
                                                       , "WHLOCNAME"
                                                       , "WHLOC, WHLOCNAME, REMARKS"
                                                       );  
        }
        
        #endregion

        private void txtPartNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                MainButton_Search.PerformClick();
        }

        private void gleWH_EditValueChanged(object sender, EventArgs e)
        {
            if (gleWH.EditValue == null)
                gleWHLoc.EditValue = null;
            else
                Set_SearchLocation(gleWH.EditValue.ObjectNullString());
        }
    }
}
