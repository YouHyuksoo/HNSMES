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


namespace HAENGSUNG_HNSMES_UI.Forms.TST
{
    public partial class TSTA005 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {
        // ******************************************* Base From Class ************************************
        // BASE_clsDevexpressGridUtil          DevExpress Grid 관련 Util Class.
        // BASE_db;                            웹서비스 DB처리 관련 Util Class.
        // BASE_DXGridHelper;                  DevExpress GridControl 데이터 Bind관련 Class
        // BASE_DXGridLookUpHelper;            DevExpress GridLookUp 데이터 Bind관련 Class
        // BASE_IDATLayoutUtil;                DevExpress LayoutControl Util Class.
        // BASE_Language;                      Language Util. ex) BASE_Language.GetMessageString("Code") 
        // ************************************************************************************************

        #region [생성자]

        public TSTA005()
        {
            InitializeComponent();

            // 폼 상태에 따라 발생 이벤트 정의 부
            this.IDAT_UpdateItemsEditChangedEvent += new IDAT_UpdateItemsEditChanged(FORM_IDAT_UpdateItemsEditChangedEvent);
        }

        // 폼 상태에 따라 발생 이벤트 정의 부
        void FORM_IDAT_UpdateItemsEditChangedEvent(object sender, IDAT.Devexpress.FORM.UPDATEITEMTYPE type)
        {
            switch (type)
            {
                case IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit:
                    // 폼 상태가 수정 모드일 경우 발생
                    break;
                case IDAT.Devexpress.FORM.UPDATEITEMTYPE.New:
                    // 폼 상태가 신규 등록 모드일 경우 발생
                    break;
                case IDAT.Devexpress.FORM.UPDATEITEMTYPE.None:
                    // 폼 상태가 초기화 모드일 경우 발생
                    break;
                default:
                    break;
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            // 최초 폼 로드 시 발생 이벤트

            // Main 버튼 사용 유무 (폼 속성 변경 가능)
            //this.ShowCloseButton = true;
            //this.ShowDeleteButton = false;
            //this.ShowEditButton = false;
            //this.ShowIcon = true;
            //this.ShowInitButton = true;
            //this.ShowInTaskbar = true;
            //this.ShowNewbutton = true;
            //this.ShowPrintButton = false;
            //this.ShowRefreshButton = false;
            //this.ShowSaveButton = false;
            //this.ShowSearchButton = true;
            //this.ShowStopButton = false;
        }


        private void Form_Shown(object sender, EventArgs e)
        {
            // ************************************************************************************
            // 컨트롤 초기화는 필수적으로 Load이벤트에 작성을 하도록 합니다.
            // ************************************************************************************

            // 모든 Edit컨트롤을 보기 상태로 변경을 합니다.
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);

            // 리스트 호출
            GetGridViewList();
        }

        #endregion

        #region [Button Event]

        public void InitButton_Click()
        {
            // 초기화 관련 구현은 아래에 구현 ***

            ////  현재 프로그램 모드정보를 변경한다.
            ////  IDAT.Devexpress.FORM.UPDATEITEMTYPE.None = 초기화 모드
            ////  IDAT.Devexpress.FORM.UPDATEITEMTYPE.New  = 신규 모드
            ////  IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit = 수정 모드
            ////  [컨트롤].ValidationCheck == True 일때 컨트롤이 상태변경이 됨.
           
           GetGridViewList();
           gcList2.DataSource = null;
        }

        public void NewButton_Click()
        {
           // 신규 등록 이벤트
        }

        public void EditButton_Click()
        {
            // 수정 버튼 이벤트
        }

        public void StopButton_Click()
        {
           // 중지 버튼 이벤트
        }

        public void SearchButton_Click()
        {
            // 검색 버튼 이벤트
            GetGridViewList();
        }

        public void SaveButton_Click()
        {
           // 저장 버튼 이벤트
        }

        public void PrintButton_Click()
        {
           // 출력 버튼 이벤트
        }

        public void RefreshButton_Click()
        {
            // 활성화 버튼 이벤트
        }

        public void DeleteButton_Click()
        {
            // 삭제 버튼 이벤트
        }

        #endregion

        #region [GridControl Event]

        
        private void gvList1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // 상단의 그리드 뷰 내에서 특정 행 선택 시 하단의 그리드 뷰내에 데이터 바인딩 처리
            GetGridViewList2();
        }

        #endregion

        #region [Private Method]

        private void GetGridViewList()
        {
            /// ****************** GridControl과 Bind Grid ***************
            /// 입력컨트롤과 GridControl의 바인딩은 필수적으로 BASE_DXGridHelper.Bind_Grid(...) 사용하도록 함.
            /// **********************************************************
            DataTable dt = new DataTable();

            dt.Columns.Add("1");
            dt.Columns.Add("2");
            dt.Columns.Add("3");
            dt.Columns.Add("4");

            dt.Rows.Add("TestA", "AAA", "1", "가나다");
            dt.Rows.Add("TestB", "BBB", "2", "라마바");
            dt.Rows.Add("TestC", "CCC", "3", "사아자");
            dt.Rows.Add("TestD", "DDD", "4", "차카파");
        
        
            BASE_DXGridHelper.Bind_Grid(gcList1, dt, true);
           
            gvList1.OptionsView.ColumnAutoWidth = false;
            gvList1.OptionsBehavior.Editable = false;
            gvList1.BestFitColumns();
        }

        private void GetGridViewList2()
        {
            /// ****************** GridControl과 Bind Grid ***************
            /// 입력컨트롤과 GridControl의 바인딩은 필수적으로 BASE_DXGridHelper.Bind_Grid(...) 사용하도록 함.
            /// **********************************************************
            DataTable dt = new DataTable();

            dt.Columns.Add("TestA");
            dt.Columns.Add("TestB");
            dt.Columns.Add("TestC");
            dt.Columns.Add("TestD");

            dt.Rows.Add("AAA", "1", "가나다", "테스트1");
            dt.Rows.Add("BBB", "2", "라마바", "테스트2");
            dt.Rows.Add("CCC", "3", "사아자", "테스트3");
            dt.Rows.Add("DDD", "4", "차카파", "테스트4");


            BASE_DXGridHelper.Bind_Grid(gcList2, dt, true);
           
            gvList2.OptionsBehavior.Editable = false;
            gvList2.OptionsView.ColumnAutoWidth = false;
            gvList2.BestFitColumns();
        }


        #endregion
    }
}
