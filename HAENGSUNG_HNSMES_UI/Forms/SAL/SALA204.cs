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
    ///    화면명 : SALA204<br/>
    ///      기능 : OQC등록 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    ///

    public partial class SALA204 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
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

        public SALA204()
        {
            InitializeComponent();
        }

        private void SALA204_Load(object sender, EventArgs e)
        {

        }

        private void SALA204_Shown(object sender, EventArgs e)
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
            Save();
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
                                           , "PKGPRD_SALES.GET_OQC"
                                           , 1
                                           , new string[] {
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_SDATE"
                                           , "A_EDATE" }
                                           , new string[] {
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , dteDate.StartDate                                          
                                           , dteDate.EndDate }
                                           , false
                                           , "OUTDATE,ITEMCODE,TOWHLOC"
                                           , false
                                           , "OUTQTY"
                                           );

            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();
        }

        private void GetGridViewList2(string p_sOutdate, string p_sItemcode, string p_sToWhloc)
        {
            BASE_DXGridHelper.Bind_Grid_Int( gcList2
                                           , "PKGPRD_SALES.GET_OQC_DETAIL"
                                           , 1
                                           , new string[] { 
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_OUTDATE" 
                                           , "A_ITEMCODE"
                                           , "A_TOWHLOC" }
                                           , new string[] { 
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , p_sOutdate
                                           , p_sItemcode
                                           , p_sToWhloc}
                                           , true
                                           , ""
                                           , false
                                           , "OUTQTY"
                                           ); 

            gvList2.OptionsView.ColumnAutoWidth = false;
            gvList2.BestFitColumns();
        }
        private void Save()
        {
            // 프로시져 수행
            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result =
                BASE_db.Execute_Proc("PKGPRD_SALES.SET_OQC"
                                    , 1
                                    , new string[] { 
                                      "A_CLIENT"
                                    , "A_COMPANY"
                                    , "A_PLANT"
                                    , "A_OUTDATE"
                                    , "A_ITEMCODE"
                                    , "A_TOWHLOC"
                                    , "A_JUDGE"
                                    , "A_USER" }
                                    , new string[] { 
                                      Global.Global_Variable.CLIENT
                                    , Global.Global_Variable.COMPANY
                                    , Global.Global_Variable.PLANT
                                    , gvList.GetFocusedRowCellValue("OUTDATE").ToString()
                                    , gvList.GetFocusedRowCellValue("ITEMCODE").ToString()
                                    , gvList.GetFocusedRowCellValue("TOWHLOC").ToString()
                                    , rdgJudge.EditValue.ObjectNullString()
                                    , Global.Global_Variable.EHRCODE }
                                    );

            if (_Result.ResultInt == 0)
            {
                iDATMessageBox.OKMessage("MSG_OK_PRINT_001", this.Text, 3);

                GetGridViewList();
            }
            else
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
 
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

            string _sOutdate = gvList.GetRowCellValue(e.FocusedRowHandle, "OUTDATE").ToString();
            string _sItemcode = gvList.GetRowCellValue(e.FocusedRowHandle, "ITEMCODE").ToString();
            string _sToWhloc = gvList.GetRowCellValue(e.FocusedRowHandle, "TOWHLOC").ToString();

            if (_sOutdate != "")
                this.GetGridViewList2(_sOutdate, _sItemcode, _sToWhloc);
        }

        #endregion

        
    }
}
