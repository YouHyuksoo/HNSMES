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
    // 자재수불

    public partial class MATB211 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {
        #region [Form Event]

        public MATB211()
        {
            InitializeComponent();           
        }

        private void MATB211_Load(object sender, EventArgs e)
        {

        }

        private void MATB211_Shown(object sender, EventArgs e)
        {
            this.Set_init();
            this.GetGridViewList();      
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
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWarehouse
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
            gleWhloc.Properties.DataSource = null;
          

            string p_strWH = gleWarehouse.EditValue.ObjectNullString();
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWhloc
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
                                                       , gleWarehouse.EditValue.ObjectNullString()
                                                       , "2" }
                                                       , "WHLOC"
                                                       , "WHLOCNAME"
                                                       , "WHLOC, WHLOCNAME, REMARKS"
                                                       );  
        }

        private void GetGridViewList()
        {           
            string Tag = this.Tag.ObjectNullString();
            /// ****************** GridControl과 Bind Grid ***************
            /// 입력컨트롤과 GridControl의 바인딩은 필수적으로 BASE_DXGridHelper.Bind_Grid(...) 사용하도록 함.
            /// **********************************************************
            BASE_DXGridHelper.Bind_Grid( gcList
                                       , "PKGHNS_REPORT.GET_ACTUALSTOCK"
                                       , 1
                                       , new string[] {
                                         "A_CLIENT"
                                       , "A_COMPANY"
                                       , "A_PLANT"
                                       ,  "A_DATE"
                                       , "A_WHLOC" }
                                       , new string[] {
                                         Global.Global_Variable.CLIENT
                                       , Global.Global_Variable.COMPANY
                                       , Global.Global_Variable.PLANT
                                       , dteDate.DateTime.ToString("yyyyMM")
                                       , gleWhloc.EditValue.ObjectNullString() }
                                       , false
                                       , ""
                                       , true
                                       , true
                                       , true
                                       , true
                                       );
           
            gvList.BeginUpdate();
            gvList.OptionsView.ShowGroupPanel = false;
            gvList.OptionsView.ColumnAutoWidth = true;
            
            gvList.Columns["INSPQTY"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvList.Columns["INSPQTY"].DisplayFormat.FormatString = "{0:n2}";

            gvList.Columns["STOCKQTY"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvList.Columns["STOCKQTY"].DisplayFormat.FormatString = "{0:n2}";

            gvList.Columns["GAPQTY"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvList.Columns["GAPQTY"].DisplayFormat.FormatString = "{0:n2}";
            
            gvList.BestFitColumns();
            gvList.EndUpdate();
        }

        private void GetGridViewListRefresh()
        {
            
        }

        #endregion

        private void gvList_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
           
        }
        private void Set_SearchLocation(string p_strWH)
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWhloc
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
                                                       , gleWarehouse.EditValue.ObjectNullString()
                                                       , "2" }
                                                       , "WHLOC"
                                                       , "WHLOCNAME"
                                                       , "WHLOC, WHLOCNAME, REMARKS"
                                                       );  
        }

        private void gleWarehouse_EditValueChanged(object sender, EventArgs e)
        {
            if (gleWarehouse.EditValue == null)
                gleWhloc.EditValue = null;
            else
                Set_SearchLocation(gleWarehouse.EditValue.ObjectNullString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WSResults _Result = BASE_db.Execute_Proc( "PKGHNS_REPORT.SET_SAVE_STOCK"
                                                    , 1
                                                    , new string[] {
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_DATE"
                                                    , "A_WHLOC" }
                                                    , new string[] {
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT
                                                    , dteDate.DateTime.ToString("yyyyMM")
                                                    , gleWhloc.EditValue.ObjectNullString() }
                                                    );

            if (_Result.ResultInt == 0)
            {
                iDATMessageBox.OKMessage("MSG_OK_REG_001", this.Text, 3);
            }
            else
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
        }
    }
}
