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
using DevExpress.XtraGrid.Views.Grid;
// User namespace
using HAENGSUNG_HNSMES_UI.Class;
using GridAlias = DevExpress.XtraGrid.Views.Grid;

namespace HAENGSUNG_HNSMES_UI.Forms.OSC
{
    // 자재 재고실사 반영/조회

    public partial class OSCA205 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {

        #region [Form Event]

        public OSCA205()
        {
            InitializeComponent();           
        }
                
        private void Form_Load(object sender, EventArgs e)
        {

        }

        private void Form_Shown(object sender, EventArgs e)
        {
            Set_Init();
        }



        #endregion

        #region [Button Event]

        public void InitButton_Click()
        {
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);
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
            dteInsMonth.DateTime = DateTime.Now;
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
                                                       , this.Tag.ObjectNullString() }
                                                       , "WAREHOUSE"
                                                       , "WAREHOUSENAME"
                                                       , "WAREHOUSE, WAREHOUSENAME, REMARKS"
                                                       );

            gleWHLoc.EditValue = null;
            gleWHLoc.Enabled = false;
            gcList.DataSource = null;

           
        }

        private void Set_Location()
        {

            // 수정 - 해당 창고에 위치정보만 나오게 변경
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

        private void Set_RACK()
        {
            //BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleRACK, "PKGBAS_BASE.GET_RACK", 1, new string[] { "A_VIEW" }, new string[] { "0" }, "RACKADDR", "RACKLOC", "RACKADDR,RACKLOC,WHLOCNAME");        
        }
     


        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid( gcList
                                       , "PKGPRD_REPORT.GET_OUTSOURCING_INOUT"
                                       , 1
                                       , new string[] {
                                         "A_CLIENT"
                                       , "A_COMPANY"
                                       , "A_PLANT"
                                       , "A_MONTH"
                                       , "A_WHLOC" }
                                       , new string[] {
                                         Global.Global_Variable.CLIENT
                                       , Global.Global_Variable.COMPANY
                                       , Global.Global_Variable.PLANT
                                       , dteInsMonth.DateTime.ToString("yyyyMM")
                                       , gleWHLoc.EditValue.ObjectNullString() }
                                       , false
                                       , ""
                                       , false
                                       , true
                                       );

            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();
        }

        #endregion

        private void gleWH_EditValueChanged(object sender, EventArgs e)
        {
            if (gleWH.EditValue != null)
            {
                gleWHLoc.Enabled = true;
                this.Set_Location();
            }
            else
            {
                gleWHLoc.EditValue = null;
                gleWHLoc.Enabled = false;
            }
        }

    }
}
