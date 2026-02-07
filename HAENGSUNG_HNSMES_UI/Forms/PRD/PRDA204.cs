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

namespace HAENGSUNG_HNSMES_UI.Forms.PRD
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : PRDA204<br/>
    ///      기능 : 포장 박스 라벨 발행 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    /// 최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    
    public partial class PRDA204 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
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

        public PRDA204()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            // 최초 폼 로드 시 발생 이벤트
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

            ////  현재 프로그램 모드정보를 변경한다.
            ////  IDAT.Devexpress.FORM.UPDATEITEMTYPE.None = 초기화 모드
            ////  IDAT.Devexpress.FORM.UPDATEITEMTYPE.New  = 신규 모드
            ////  IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit = 수정 모드
            this.InitForm();
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (gleWH.EditValue.ObjectNullString() == "")
            {
                return;
            }

            if (gleWHLoc.EditValue.ObjectNullString() == "")
            {
                return;
            }

            if (glePartNo.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.ErrorMessage("MSG_ER_COMM_002", this.Text, 3); //품번을 선택하세요.
                return;
            }

            if (int.Parse(spinQty.EditValue.ObjectNullString()) <= 0)
            {
                iDATMessageBox.ErrorMessage("MSG_ER_STOCK_014", this.Text, 3); //수량을 입력하세요.
                return;
            }
            //라벨 출력 테스트용
            if (glePartNo.EditValue.ObjectNullString() == "1685")
            {
                PrintSample();
                return;
            }
            else if (glePartNo.EditValue.ObjectNullString() == "1703")
            {
                PrintSample1();
                return;
            }
            else if (glePartNo.EditValue.ObjectNullString() == "1704")
            {
                PrintSample2();
                return; 
            }
            
            this.CreateBoxNO();
            
        }

        #endregion

        #region [Private Function]

        private void InitForm()
        {
            this.GetPartNo();

            this.GetWarehouse();
        }

        private void GetPartNo()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( glePartNo
                                                       , "GPKGPRD_PROD.GET_PARTNO"
                                                       , 1
                                                       , new string[] { 
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT" }
                                                       , new string[] { 
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT }
                                                       , "PRINTTYPE"
                                                       , "PARTNO"
                                                       , "PRINTTYPE,PARTNO,SPEC"
                                                       );
        }

        private void GetWarehouse()
        {
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
                                                       , "9" }
                                                       , "WAREHOUSE"
                                                       , "WAREHOUSENAME"
                                                       , "WAREHOUSE, WAREHOUSENAME, REMARKS"
                                                       );

            //생산창고 자동 바인딩 처리
            gleWH.EditValue = "W004";

        }

        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid_Int( gcList
                                           , "PKGPRD_PROD.GET_BOXSNINFO"
                                           , 1
                                           , new string[] { 
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_BOXTYPE"
                                           , "A_SDATE"
                                           , "A_EDATE" }
                                           , new string[] { 
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , ""//this.Tag.ObjectNullString() 2021.10.08 박스 전체 조회로 변경
                                           , dteFromTo.StartDate
                                           , dteFromTo.EndDate }
                                           , true
                                           , ""
                                           , false
                                           , "ITEMCODE,QTY"
                                           );

        }

        private void CreateBoxNO()
        {
            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = 
                BASE_db.Execute_Proc( "PKGPRD_PROD.SET_BOXSNINFO"
                                    , 1
                                    , new string[] { 
                                      "A_CLIENT"
                                    , "A_COMPANY"
                                    , "A_PLANT"
                                    , "A_BOXTYPE"
                                    , "A_ITEMCODE"
                                    , "A_WHLOC"
                                    , "A_QTY"
                                    , "A_USER" }
                                    , new object[] { 
                                      Global.Global_Variable.CLIENT
                                    , Global.Global_Variable.COMPANY
                                    , Global.Global_Variable.PLANT
                                    , rdgBoxtype.EditValue.ObjectNullString()//this.Tag.ObjectNullString()
                                    , glePartNo.EditValue.ObjectNullString()
                                    , gleWHLoc.EditValue.ObjectNullString()
                                    , spinQty.EditValue.ObjectNullString()
                                    , Global.Global_Variable.EHRCODE }
                                    );

            if (_Result.ResultInt == 0)
            {
                BASE_DXGridHelper.Bind_Grid( gcList,  _Result.ResultDataSet.Tables[0]);

                int nCopies = 1;

                if (Print(_Result.ResultDataSet.Tables[0], nCopies))
                {
                    iDATMessageBox.OKMessage("MSG_OK_PRINT_001", this.Text, 3);
                }
            }
            else
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
        }

        private bool Print(DataTable dTable, int nCopies)
        {
            using (RPT.RPTA205 _rpt = new RPT.RPTA205(dTable, nCopies))
            {
                _rpt.RptPrint();
            }
            /*태국법인 포장 박스 라벨*/
            //using (RPT.RPTA208 _rpt = new RPT.RPTA208(dTable, nCopies))
            //{
            //    _rpt.RptPrint();
            //}
            return true;
        }       

        private bool PrintSample()
        {
            using (RPT.RPTA216 _rpt = new RPT.RPTA216())
            {
                _rpt.RptPrint();
            }

            return true;
        }
        private bool PrintSample1()
        {
            using (RPT.RPTA2161 _rpt = new RPT.RPTA2161())
            {
                _rpt.RptPrint();
            }

            return true;
        }
        private bool PrintSample2()
        {
            using (RPT.RPTA2162 _rpt = new RPT.RPTA2162())
            {
                _rpt.RptPrint();
            }

            return true;
        }

        #endregion

        #region [Control Event]

        private void glePartNo_EditValueChanged(object sender, EventArgs e)
        {
            spinQty.EditValue = 1;
        }

        private void gleWH_EditValueChanged(object sender, EventArgs e)
        {
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
                                                       , "3" }
                                                       , "WHLOC"
                                                       , "WHLOCNAME"
                                                       , "WHLOC, WHLOCNAME, REMARKS"
                                                       );
        }
        private void btnReprint_Click(object sender, EventArgs e)
        {
            if (gvList.RowCount > 0 && gvList.FocusedRowHandle > -1)
            {
                DataRow[] _dr = (gcList.DataSource as DataTable).Select("BOXNO='" + gvList.GetFocusedRowCellValue("BOXNO").ObjectNullString() + "'");

                if (Print(_dr.CopyToDataTable(), 1))
                {
                    iDATMessageBox.OKMessage("MSG_OK_PRINT_001", this.Text, 3);
                }
            }
        }

        #endregion

    }
}
