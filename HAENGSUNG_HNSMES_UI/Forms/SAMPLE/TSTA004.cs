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
    public partial class TSTA004 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {
        // ******************************************* Base From Class ************************************
        // BASE_clsDevexpressGridUtil          DevExpress Grid 관련 Util Class.
        // BASE_db;                            웹서비스 DB처리 관련 Util Class.
        // BASE_DXGridHelper;                  DevExpress GridControl 데이터 Bind관련 Class
        // BASE_DXGridLookUpHelper;            DevExpress GridLookUp 데이터 Bind관련 Class
        // BASE_IDATLayoutUtil;                DevExpress LayoutControl Util Class.
        // BASE_Language;                      Language Util. ex) BASE_Language.GetMessageString("Code") 
        // ************************************************************************************************
        #region 생성

        public TSTA004()
        {
            InitializeComponent();

            base.IDAT_UpdateItemsEditChangedEvent +=new IDAT_UpdateItemsEditChanged(FORM_IDAT_UpdateItemsEditChangedEvent);
        }

        void FORM_IDAT_UpdateItemsEditChangedEvent(object sender, IDAT.Devexpress.FORM.UPDATEITEMTYPE type)
        {
            switch (type)
            {
                case IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit:
                    // 폼 상태가 수정 모드일 경우 발생 이벤트
                    break;
                case IDAT.Devexpress.FORM.UPDATEITEMTYPE.New:
                    // 폼 상태가 신규 등록 모드일 경우 발생 이벤트
                    break;
                case IDAT.Devexpress.FORM.UPDATEITEMTYPE.None:
                    // 폼 상태가 초기화 모드일 경우 발생 이벤트
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
            //this.ShowEditButton = true;
            //this.ShowIcon = true;
            //this.ShowInitButton = true;
            //this.ShowInTaskbar = true;
            //this.ShowNewbutton = true;
            //this.ShowPrintButton = false;
            //this.ShowRefreshButton = true;
            //this.ShowSaveButton = true;
            //this.ShowSearchButton = true;
            //this.ShowStopButton = true;
           
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            // ************************************************************************************
            // 컨트롤 초기화는 필수적으로 Load이벤트에 작성을 하도록 합니다.
            // ************************************************************************************

            // 모든 Edit컨트롤을 보기 상태로 변경을 합니다.
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);

            // 리스트 호출
            this.GetGridViewList();
        
        }
        #endregion
       
        #region 버튼이벤트

        public void InitButton_Click()
        {
            // 초기화 관련 구현은 아래에 구현 ***

            ////  현재 프로그램 모드정보를 변경한다.
            ////  IDAT.Devexpress.FORM.UPDATEITEMTYPE.None = 초기화 모드
            ////  IDAT.Devexpress.FORM.UPDATEITEMTYPE.New  = 신규 모드
            ////  IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit = 수정 모드
            ////  [컨트롤].ValidationCheck == True 일때 컨트롤이 상태변경이 됨.
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None, gcList2);

            this.GetGridViewList();
        }

        public void DeleteButton_Click()
        {
            // 삭제 관련 구현은 아래에 구현 ***
            InitButton_Click();

            MainButton_INIT.PerformClick();
        }
        
        public void NewButton_Click()
        {
            // 신규 관련 구현은 아래에 구현 ***

            // ************************************************************************************
            // 신규 항목을 추가하기전에 기존에 수정된 데이터를 저장하고 신규 추가를 한다.
            // 메인화면 버튼접근시에는 아래와 같이 접근을 합니다.

            // MainButton_Save;
            // MainButton_Refresh;
            // MainButton_New;
            // .....
            // MainButton_Refresh;
            // MainButton_Stop;
            // ************************************************************************************

            // 추가하기 전에 기존에 수정된 데이터를 저장 함.
            MainButton_Save.PerformClick();

            // 각 컨트롤마다 신규 상태를 별도로 설정할 수 있습니다.
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New, gcList1);
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New, gcList2);
        }

        public void EditButton_Click()
        {
            // 수정 관련 구현은 여기에 구현 ***
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit, gcList1);
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit, gcList2);
        }

        public void StopButton_Click()
        {
            // 정지 관련 구현은 여기에 구현 ***
        }

        public void SearchButton_Click()
        {
            // 검색 관련 구현은 여기에 구현 ***
        }

        public void SaveButton_Click()
        {
            // 저장 관련 구현은 아래에 구현 ***

            // ************************************************************************************
            // 유효성검사 수행
            // 유효성 검사 대상은 컨트롤 속성
            // [컨트롤].ValidationCheck == True 일때 체크가 됨.
            // ************************************************************************************
            base.baseDxErrorProvider.ClearErrors();
            ValidateChildren(ValidationConstraints.Visible);

            // 유효성 검사를 한다.
            if (base.baseDxErrorProvider.HasErrors)
            {
                return;
            }

            // 수정,추가,변경 된 데이터를 모두 가져온다.
            DataTable _dt = BASE_clsDevexpressGridUtil.GetChangedData(gcList1);

            // 변경된 데이터가 없으면 return.
            if (_dt.Rows.Count == 0) return;

            string _strA = "";
            string _strB;
            string _strC;

            if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit)
            {
                // 변경된 데이터를 루프를 통해 하나씩 빼낸다.
                foreach (DataRow _dr in _dt.Rows)
                {
                    switch (_dr.RowState)
                    {
                        case DataRowState.Modified:
                            _strA = _dr["A"].ObjectNullString();
                            _strB = _dr["B"].ObjectNullString();
                            _strC = _dr["C"].ObjectNullString();

                            this.SaveData(_strA, _strB, _strC);
                            break;

                        default:
                            break;
                    }
                }

                MainButton_INIT.PerformClick();

                // 마지막 처리 된 값쪽에 포커스를 이동 시킵니다.
                // 사용시에 주석을 해제하고 수정하세요.
                gvList1.EX_GetFocuseRowCell("A", _strA);
            }
            else if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
            {
                // ***** 신규 관련 프로시져를 여기에 구현을 합니다.
                _strA = txtA.Text.Trim().ObjectNullString();
                _strB = txtB.Text.Trim().ObjectNullString();
                _strC = txtC.Text.Trim().ObjectNullString();
                SaveData(_strA, _strB, _strC);

                // 신규 항목 데이터를 처리하면 그리드를 리프레쉬 합니다.
                MainButton_INIT.PerformClick();
                MainButton_New.PerformClick();

                // 신규 처리 한 곳으로 포커스를 이동 시킵니다. 
                // 사용시에 주석을 해제하고 수정하세요.
                // BASE_clsDevexpressGridUtil.GetFocuseRowCell(gvList, "A", _strA);
            }

            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);
        }

        public void PrintButton_Click()
        {
            // 출력 관련 구현은 아래에 구현 ***
        }

        public void RefreshButton_Click()
        {
            // 새로고침 관련 구현은 아래에 구현 ***
        }

        #endregion

        #region 함수

        private void GetGridViewList()
        {
            /// ****************** GridControl과 Bind Grid ***************
            /// 입력컨트롤과 GridControl의 바인딩은 필수적으로 BASE_DXGridHelper.Bind_Grid(...) 사용하도록 함.
            /// **********************************************************
            DataTable dt = new DataTable();

            dt.Columns.Add("A");
            dt.Columns.Add("B");
            dt.Columns.Add("C");
            dt.Columns.Add("D");

            dt.Rows.Add("TestA", "AAA", "1", "가나다");
            dt.Rows.Add("TestB", "BBB", "2", "라마바");
            dt.Rows.Add("TestC", "CCC", "3", "사아자");
            dt.Rows.Add("TestD", "DDD", "4", "차카파");
            dt.Rows.Add("TestE", "EEE", "5", "하호히");

            BASE_DXGridHelper.Bind_Grid(gcList1, dt, true);
            BASE_DXGridHelper.Bind_Grid(gcList2, dt.Copy(), true);
        }

        private void SaveData(string p_strA, string p_strB, string p_strC) // sample template parameters
        {
            // 프로시져 수행
            // BASE_db.Execute_Proc("ProcName", 1, new string[] { "param1", "param2", "param3" }, new string[] { p_strA, p_strB, p_strC });
            _ = p_strA; _ = p_strB; _ = p_strC;
        }
        #endregion

        #region 일반 이벤트

        private void gvList_Click(object sender, EventArgs e)
        {
            // 선택된 그리드뷰 내의 Hit Info 정보를 가져오는 소스이다.
            // 사용하지 않을 시에 삭제하거나 주석처리 하세요.
            if (!(sender is GridAlias.GridView))
            {
                return;
            }

            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo gridHitINFO = BASE_clsDevexpressGridUtil.GetClickHitInfo(gvList1, e);

            if (gridHitINFO.InRow && gridHitINFO.InColumn)
            {
                /// ============================================================
                /// 선택된 Row의 정보를 가져올려면 아래에 구현을 하면 된다.
                // int RowIdx = gridHitINFO.RowHandle;
                // int ColIdx = gridHitINFO.Column.AbsoluteIndex;
            }

            if (gridHitINFO.InRowCell)
            {
            }
        }

        private void gvList_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
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

        private void gvList_RowStyle(object sender, GridAlias.RowStyleEventArgs e)
        {
            // 수정된 항목을 그리드에 표시하는 기능. 사용시 주석해제 하고 일부분 수정해야 함.
            // 구현상 기능이 필요하지 않으면 주석처리 하세요.
            DataTable changes = gvList1.EX_GetChangedData(DataRowState.Modified);

            if (e.RowHandle < 0)
                return;

            // 수정된 키값 필드를 입력한다.
            foreach (DataRow dr in changes.Rows)
            {
                if (dr["A"] != null)
                {
                    // 주키가 두개일 경우 AND 문으로 조건을 다중으로 준다.
                    if (dr["A"].ToString() == gvList1.GetDataRow(e.RowHandle)["A"].ToString())
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
            }
        }

        #endregion

    }
}
