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
using HAENGSUNG_HNSMES_UI.WebService.Access;

namespace HAENGSUNG_HNSMES_UI.Forms.PRD
{

    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : PRDH001<br/>
    ///      기능 : 검사 이력 조회 (통전, 외관) <br/>
    ///      작성 : 김범수<br/>
    ///최초작성일 : 2024-04-15<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>

    public partial class PRDH001 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
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

        public PRDH001()
        {
            InitializeComponent();           
        }
                
        private void Form_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            // ************************************************************************************
            // 컨트롤 초기화는 필수적으로 Shown이벤트에 작성을 하도록 합니다.
            // ************************************************************************************
        }

        #endregion

        #region [Button Event]

        public void InitButton_Click()
        {
            // 초기화 관련 구현은 여기에 구현 ***
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

            if (tabbedControlGroup1.SelectedTabPageIndex == 0)
            {
                GetGridViewList1();
            }
            else
            {
                GetGridViewList2();
            }
            
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
            gcList.DataSource = null;
            gcList2.DataSource = null;

        }

        public void DeleteButton_Click()
        {
            // 삭제 버튼 클릭 이벤트
        }

        #region [Private Method]

        private void InitForm()
        {

            GetUnitNo();
            GetWorker();

        }

        private void GetUnitNo()
        {
            /*설비 호기 정보*/
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleUnitNo
                                                       , "PKGPRD_HIST.GET_UNITNO"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"}
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT}
                                                       , "UNITNO"
                                                       , "UNITNM"
                                                       , "UNITNO, UNITNM, REMARKS"
                                                       );
        }
        
        private void GetWorker()
        {
            /*작업자 정보*/
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleWorker
                                                       , "GPKGPRD_PROD.GET_WORKER"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT }
                                                       , "USERID"
                                                       , "USERNAME"
                                                       , "USERID, USERNAME"
                                                       );
        }
  






        private void GetGridViewList1() // 통전검사
        {


            BASE_DXGridHelper.Bind_Grid(gcList,
                                             "PKGPRD_HIST.GET_CIRCUIT",
                                             1,
                                             new string[] { "A_SDATE",
                                                            "A_EDATE",
                                                            "A_UNITNO",
                                                            "A_WORKER"},
                                             new string[] { dteFromTo.StartDate,
                                                            dteFromTo.EndDate,
                                                            gleUnitNo.EditValue.ObjectNullString(),
                                                            gleWorker.EditValue.ObjectNullString()
                                                           },
                                             false);

            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();


           
        }


        private void GetGridViewList2()  // 외관검사
        {


            BASE_DXGridHelper.Bind_Grid(gcList2,
                                             "PKGPRD_HIST.GET_VISUALINSP",
                                             1,
                                             new string[] { "A_SDATE",
                                                            "A_EDATE",
                                                            "A_UNITNO",
                                                            "A_WORKER"},
                                             new string[] { dteFromTo.StartDate,
                                                            dteFromTo.EndDate,
                                                            gleUnitNo.EditValue.ObjectNullString(),
                                                            gleWorker.EditValue.ObjectNullString()
                                                           },
                                             false);

            gvList2.OptionsView.ColumnAutoWidth = false;
            gvList2.BestFitColumns();

        }

        #endregion     

        private void gleOper_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gleWorkCenter_EditValueChanged(object sender, EventArgs e)
        {

        }

        #region 일반함수


        #endregion

        private void glePartNo_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void txtPartNo_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void xucFromToDate_Load(object sender, EventArgs e)
        {

        }

        private void dteEND_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
#endregion