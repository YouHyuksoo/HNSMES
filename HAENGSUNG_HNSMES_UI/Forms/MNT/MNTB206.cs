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

namespace HAENGSUNG_HNSMES_UI.Forms.MNT
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : MNTB206<br/>
    ///      기능 : NG SCRAP <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    ///
    public partial class MNTB206 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
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

        public MNTB206()
        {
            InitializeComponent();           
        }

        private void MNTB206_Load(object sender, EventArgs e)
        {
            this.Set_Init();            
        }

        private void MNTB206_Shown(object sender, EventArgs e)
        {

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

            this.Set_Init();
        }


        public void NewButton_Click()
        {
            
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
            this.GetGridViewList();
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
            //GetGridViewListRefresh();
        }

        public void DeleteButton_Click()
        {
            // 삭제 버튼 클릭 이벤트
        }

        #endregion

        #region [Private Method]

        private void Set_Init()
        {
            gcList.DataSource = null;
            dmeMonth.EditValue =  DateTime.Now;
            
        }       

        #endregion

        #region 함수
        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid_Int(gcList
                                           , "PKGHNS_REPORT.GET_NG_SCRAP"
                                           , 1
                                           , new string[] { 
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_ACTUALMON" }
                                           , new string[] { 
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , dmeMonth.DateTime.ToString("yyyyMM") }
                                           , true
                                           , ""
                                           , false
                                           , ""
                                           );

            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();

        }

      

        #endregion


        #region [일반 이벤트]
        private void gvList_DoubleClick(object sender, EventArgs e)
        {
            if (gvList.RowCount > 0)
            {
                string sWire = gvList.GetFocusedRowCellValue("WIRE").ObjectNullString();
                string sTerminal = gvList.GetFocusedRowCellValue("TERMINAL").ObjectNullString();

                Forms.MNT.MNTA202 mnt = new Forms.MNT.MNTA202(sWire, sTerminal);
                mnt.Show(this);
            }
        }
        #endregion

        
    }
}
