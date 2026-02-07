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

namespace HAENGSUNG_HNSMES_UI.Forms.MAT
{
    // 조회
    // 자재수불

    public partial class MATB207 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {
        #region [Form Event]

        public MATB207()
        {
            InitializeComponent();           
        }

        
        private void MATB207_Load(object sender, EventArgs e)
        {

        }

        private void MATB207_Shown(object sender, EventArgs e)
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
                                                       , "PKGPDA_COMM.GET_WH"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_TYPE" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , "MAT" }
                                                       , "VALUE"
                                                       , "DISP"
                                                       , "VALUE, DISP, REMARKS"
                                                       );

            gleWhloc.Properties.DataSource = null;
            string p_strWH = gleWarehouse.EditValue.ObjectNullString();

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWhloc
                                                       , "PKGPDA_COMM.GET_LOC"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_WH" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , "MATRECEIVE" }
                                                       , "WHLOC"
                                                       , "LOCNAME"
                                                       , "WHLOC, LOCNAME, REMARKS"
                                                       );
        }

        private void GetGridViewList()
        {
            /*
            if (gleWarehouse.EditValue + "" == "")
            {
                iDATMessageBox.WARNINGMessage(BASE_Language.GetMessageString("MSG_ER_COMM_004"), this.Text, 3);
                gleWarehouse.Focus();
                return;
            }
            */

            /// ****************** GridControl과 Bind Grid ***************
            /// 입력컨트롤과 GridControl의 바인딩은 필수적으로 BASE_DXGridHelper.Bind_Grid(...) 사용하도록 함.
            /// **********************************************************
            BASE_DXGridHelper.Bind_Grid( gcList
                                       , "PKGTXN_STOCK.GET_SUBUL"
                                       , 1
                                       , new string[] {
                                         "A_FROMDATE"
                                       , "A_TODATE"
                                       , "A_WAREHOUSE"
                                       , "A_WHLOC"
                                       , "A_PARTNO"
                                       , "A_ITEMTYPE" }
                                       , new string[] {
                                         dteDate.DateTime.ToString("yyyyMM")
                                       , dteDate.DateTime.ToString("yyyyMM")
                                       , gleWarehouse.EditValue.ObjectNullString()
                                       , gleWhloc.EditValue.ObjectNullString()
                                       , txtPartNo.EditValue.ObjectNullString()
                                       , this.Tag.ObjectNullString() }
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

            gvList.Columns["PARTNO"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            gvList.Columns["ITEMNAME"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            gvList.Columns["WAREHOUSENAME"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            gvList.Columns["STOCKTYPE"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;


            gvList.Columns["PARTNO"].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            gvList.Columns["ITEMNAME"].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            gvList.Columns["WAREHOUSENAME"].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            gvList.Columns["STOCKTYPE"].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            
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
                                                       , "PKGPDA_COMM.GET_LOC"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_WH" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , "MATRECEIVE" }
                                                       , "WHLOC"
                                                       , "LOCNAME"
                                                       , "WHLOC, LOCNAME, REMARKS"
                                                       );
        }

        private void gleWarehouse_EditValueChanged(object sender, EventArgs e)
        {
            if (gleWarehouse.EditValue == null)
                gleWhloc.EditValue = null;
            else
                Set_SearchLocation(gleWarehouse.EditValue.ObjectNullString());
        }

    }
}
