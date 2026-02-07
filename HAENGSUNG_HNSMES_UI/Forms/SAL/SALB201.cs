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
using HAENGSUNG_HNSMES_UI.WebService.Access;
using GridAlias = DevExpress.XtraGrid.Views.Grid;

namespace HAENGSUNG_HNSMES_UI.Forms.SAL
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : SALB201<br/>
    ///      기능 : 제품 출하 이력 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    ///

    public partial class SALB201 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
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

        public SALB201()
        {
            InitializeComponent();
        }

        private void SALB201_Load(object sender, EventArgs e)
        {

        }

        private void SALB201_Shown(object sender, EventArgs e)
        {
            this.InitForm();
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
            // 저장 버튼 클릭 이벤트
        }

       
        public void PrintButton_Click()
        {
            // 출력 버튼 클릭 이벤트
        }

       
        public void RefreshButton_Click()
        {
            // 새로 고침 버튼 클릭 이벤트
        }

        public void DeleteButton_Click()
        {
            // 삭제 버튼 클릭 이벤트
        }

        #endregion
     
        #region [Private Method]

        private void InitForm()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleVendor
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
                                                       , "PRODDELIVERY" }
                                                       , "VALUE"
                                                       , "DISP"
                                                       , "VALUE, DISP"
                                                       );

            
        }
     
        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid_Int( gcList
                                           , "PKGPRD_SALES.GET_DELIVERY"
                                           , 1
                                           , new string[] {
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_SDATE"
                                           , "A_EDATE"
                                           , "A_VENDOR"
                                           , "A_BOXNO" }
                                           , new string[] {
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , dteDate.StartDate                                          
                                           , dteDate.EndDate
                                           , gleVendor.EditValue.ObjectNullString()
                                           , txtBoxNo.EditValue.ObjectNullString() }
                                           , false
                                           , "TXNTIMEKEY,TXNCODE,WHLOC,TOVENDOR"
                                           , false
                                           , "OUTQTY"
                                           );

            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();
        }

        private void GetGridViewList2(string p_sBoxNo)
        {
            BASE_DXGridHelper.Bind_Grid_Int(gcList2
                                           , "PKGPRD_SALES.GET_SERIAL"
                                           , 1
                                           , new string[] { 
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_BOXNO" }
                                           , new string[] { 
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , p_sBoxNo }
                                           , false
                                           , "BCDDATA"
                                           , false
                                           , ""
                                           );

            gvList2.OptionsView.ColumnAutoWidth = false;
            gvList2.BestFitColumns();
        }
        
        #endregion

        #region [Control Event]

        private void gvList_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "SEL")
            {
                string _sBoxNo = gvList.GetRowCellValue(e.RowHandle, "BOXNO").ObjectNullString();

                for (int nRow = 0; nRow < gvList.RowCount; nRow++)
                {
                    if (_sBoxNo == gvList.GetRowCellValue(nRow, "BOXNO").ObjectNullString() &&
                        e.RowHandle != nRow)
                    {
                        gvList.SetRowCellValue(nRow, "SEL", e.Value);
                    }
                }
            }
        }

        private void gvList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvList.RowCount == 0)
            {
                gcList2.DataSource = null;
                return;
            }
            
            if (e.FocusedRowHandle < 0) return;

            string _sBoxNo = gvList.GetRowCellValue(e.FocusedRowHandle, "BOXNO").ToString();

            if (_sBoxNo != "")
                this.GetGridViewList2(_sBoxNo);
        }

        #endregion

        
    }
}
