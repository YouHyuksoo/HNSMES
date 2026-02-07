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
    public partial class MATB006 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
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

        public MATB006()
        {
            InitializeComponent();

            // 활성화 된 폼의 상태에 따라 발생되는 이벤트 정의 부
            this.IDAT_UpdateItemsEditChangedEvent +=new IDAT_UpdateItemsEditChanged(FORM_IDAT_UpdateItemsEditChangedEvent);
           
        }


        void  FORM_IDAT_UpdateItemsEditChangedEvent(object sender, IDAT.Devexpress.FORM.UPDATEITEMTYPE type)
        { 
            switch (type)
	        {
		        case IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit:
                 // 활성화 된 폼의 상태가 수정 모드일 경우 발생 이벤트 구현
                 break;
                 
                case IDAT.Devexpress.FORM.UPDATEITEMTYPE.New:
                 // 활성화 된 폼의 상태가 신규 등록 모드일 경우 발생 이벤트 구현
                 break;

                case IDAT.Devexpress.FORM.UPDATEITEMTYPE.None:
                 // 활성화 된 폼의 상태가 초기화 모드일 경우 발생 이벤트 구현
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
            //this.ShowInitButton = false;
            //this.ShowInTaskbar = true;
            //this.ShowNewbutton = false;
            //this.ShowPrintButton = false;
            //this.ShowRefreshButton = true;
            //this.ShowSaveButton = false;
            //this.ShowSearchButton = true;
            //this.ShowStopButton = false;

        }

        private void Form_Shown(object sender, EventArgs e)
        {
            // ************************************************************************************
            // 컨트롤 초기화는 필수적으로 Shown이벤트에 작성을 하도록 합니다.
            // ************************************************************************************

            // 모든 Edit컨트롤을 보기 상태로 변경을 합니다.
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);

            Set_InitMemberList();
            GetGridViewList();
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
          
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);
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

            // 프로시져 수행
            // BASE_db.Execute_Proc("ProcName", 1, new string[] { "param1", "param2", "param3" }, new string[] { p_strA, p_strB, p_strC });
        }

       
        public void PrintButton_Click()
        {
            // 출력 버튼 클릭 이벤트
        }

       
        public void RefreshButton_Click()
        {
            // 새로 고침 버튼 클릭 이벤트
            GetGridViewListRefresh();
        }

        public void DeleteButton_Click()
        {
            // 삭제 버튼 클릭 이벤트
        }

        #endregion
     
        #region [Private Method]

        private void Set_InitMemberList()
        {
            /// 프로시저 호출을 하여 GridLookUpEdit 컨트롤 내에 데이터 바인딩 처리
            //BASE_DXGridHelper.Bind_Grid(
            //                         gcList
            //                       , "프로시저명"
            //                       , 1
            //                       , new string[] { 
            //                                         "프로시저파라미터1"
            //                                       , "프로시저파라미터2"
            //                                       , "프로시저파라미터3"
                                                 
            //                                      } // DB
            //                       , new string[] { 
            //                                         "프로시저파라미터1"
            //                                       , "프로시저파라미터2"
            //                                       , "프로시저파라미터3"
                                                 
            //                                      }
            //                       , true
            //                       ); // UI 매칭
        }
     


        private void GetGridViewList()
        {
            /// ****************** GridControl과 Bind Grid ***************
            /// 입력컨트롤과 GridControl의 바인딩은 필수적으로 BASE_DXGridHelper.Bind_Grid(...) 사용하도록 함.
            /// **********************************************************
            //BASE_DXGridHelper.Bind_Grid(
            //                                gcList
            //                               , "프로시저명"
            //                               , 1
            //                               , new string[] {
            //                                                 "프로시저 파라미터 1"
            //                                               , "프로시저 파라미터 2"
            //                                               , "프로시저 파라미터 3"
            //                                              }
            //                                              // DB 파라미터와 매칭

            //                               , new string[] {
            //                                                 "프로시저 파라미터 1" 
            //                                               , "프로시저 파라미터 2"
            //                                               , "프로시저 파라미터 3"
            //                                              } 
            //                                              // UI 컨트롤과 매칭 
            //                               , true
            //                               , "그리드 뷰 상에서 보여줄 컬럼 리스트"
            //                            );

            gvList.OptionsView.ShowGroupPanel = false;
            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();
        }

        private void GetGridViewListRefresh()
        {
            /// ****************** GridControl과 Bind Grid ***************
            /// 입력컨트롤과 GridControl의 바인딩은 필수적으로 BASE_DXGridHelper.Bind_Grid(...) 사용하도록 함.
            /// **********************************************************
            //BASE_DXGridHelper.Refresh_Grid(
            //                                gcList
            //                               , "프로시저명"
            //                               , 1
            //                               , new string[] {
            //                                                 "프로시저 파라미터 1"
            //                                               , "프로시저 파라미터 2"
            //                                               , "프로시저 파라미터 3"
            //                                              }
            //    // DB 파라미터와 매칭

            //                               , new string[] {
            //                                                 "프로시저 파라미터 1" 
            //                                               , "프로시저 파라미터 2"
            //                                               , "프로시저 파라미터 3"
            //                                              }
            //    // UI 컨트롤과 매칭 
            //                               , true
            //                            );

        }

        #endregion

    }
}
