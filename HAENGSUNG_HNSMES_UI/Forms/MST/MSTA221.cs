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

namespace HAENGSUNG_HNSMES_UI.Forms.MST
{
    public partial class MSTA221 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {

        #region 생성

        private Boolean _bRefresh = false;

        public MSTA221()
        {
            InitializeComponent();
        }

        
        private void MSTA221_Load(object sender, EventArgs e)
        {
           
        }
        private void MSTA221_Shown(object sender, EventArgs e)
        {
            MainButton_INIT.PerformClick();
        }
        

        #endregion

        #region 버튼이벤트

        public void InitButton_Click()
        {

            // 초기화 관련 구현은 여기에 구현 ***
            // 상세 항목들을 모두 클리어 한다.
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);
            this.GetGridViewList();
        }

        public void NewButton_Click()
        {
            // 신규 관련 구현은 여기에 구현.
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New);

            spiQty.Focus();
        }

        public void EditButton_Click()
        {
            // 수정 관련 구현은 여기에 구현.
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit);
        }

        public void StopButton_Click()
        {
        }


        public void SaveButton_Click()
        {

            // 저장전에 필수 항목에 대한 Null 값을 초기화 합니다.
            // 유효성검사 다시 수행
            base.baseDxErrorProvider.ClearErrors();
            ValidateChildren(ValidationConstraints.Visible);

            // 유효성 검사를 한다.
            if (base.baseDxErrorProvider.HasErrors)
                return;

            string _strItemcode = "";
            string _strPartno = "";
            string _strQty = "";

            if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
            {
                _strItemcode = txtItemcode.EditValue.ObjectNullString();
                _strPartno = txtPartNo.EditValue.ObjectNullString();
                _strQty = spiQty.EditValue.ObjectNullString();


                if (!this.SaveData(_strItemcode, _strQty))
                    return;

                //마지막 처리 된 값쪽에 포커스를 이동 시킵니다. 사용시에 주석을 해제하고 수정하세요.
                gvList.EX_GetFocuseRowCell("PARTNO", _strPartno);

                GetGridViewList2();

                MainButton_INIT.PerformClick();
            }
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

        private bool SaveData(string p_strItemcode, string p_strqty)
        
        {
            bool _Rtn = BASE_db.Execute_Proc( "PKGBAS_BASE.SET_JIGPIN"
                                            , 1
                                            , new string[] { 
                                              "A_CLIENT"
                                            , "A_COMPANY"
                                            , "A_PLANT"
                                            , "A_ITEMCODE"
                                            , "A_QTY"
                                            , "A_USER" }
                                            , new string[] {  
                                              Global.Global_Variable.CLIENT
                                            , Global.Global_Variable.COMPANY
                                            , Global.Global_Variable.PLANT
                                            , p_strItemcode
                                            , p_strqty
                                            , Global.Global_Variable.USER_ID }
                                            , true);
             
            return _Rtn;

        }

        private void Set_Init()
        {

        }

        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid(
                                    gcList
                                   , "PKGBAS_BASE.GET_JIGPIN"
                                   , 1
                                   , new string[] {                                                      
                                     "A_CLIENT"
                                   , "A_COMPANY"
                                   , "A_PLANT" }
                                   , new string[] {    
                                     Global.Global_Variable.CLIENT
                                   , Global.Global_Variable.COMPANY
                                   , Global.Global_Variable.PLANT }
                                   , true );

            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();
            
        }
        private void GetGridViewList2()
        {
            BASE_DXGridHelper.Bind_Grid(gcList1
                                       , "PKGBAS_BASE.GET_JIGPINDETAIL"
                                       , 1
                                       , new string[] {                                                      
                                         "A_CLIENT"
                                       , "A_COMPANY"
                                       , "A_PLANT" 
                                       , "A_ITEMCODE" }
                                       , new string[] {    
                                         Global.Global_Variable.CLIENT
                                       , Global.Global_Variable.COMPANY
                                       , Global.Global_Variable.PLANT 
                                       , gvList.GetFocusedRowCellValue("ITEMCODE").ObjectNullString() }
                                       , true
                                       );

            gvList1.OptionsView.ColumnAutoWidth = false;
            gvList1.BestFitColumns();
        }

        #endregion

        #region 일반이벤트

        private void gvList_Click(object sender, EventArgs e)
        {
            
        }

        private void gvList_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (_bRefresh == false)
            {
                // 신규 상태일때 다른 컬럼을 선택시에 기능을 상실하도록 한다.
                // 구현상 기능이 필요하지 않으면 주석처리 하세요.
                if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
                {
                    if (e.RowHandle == -2147483647)
                    {
                        e.Allow = false;
                    }
                }
            }
        }

        private void gvList_RowStyle(object sender, GridAlias.RowStyleEventArgs e)
        {
           
        }


        #endregion

        private void gvList_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            
        }

        private void gvList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
                GetGridViewList2();

        }
           
               
    }
}
