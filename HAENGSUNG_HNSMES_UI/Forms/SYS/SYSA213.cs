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


namespace HAENGSUNG_HNSMES_UI.Forms.SYS
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : SYSA213<br/>
    ///      기능 : 공지 마스터 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    public partial class SYSA213 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
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

        public SYSA213()
        {
            InitializeComponent();
        }

        // 최초 폼 로드 시 발생 이벤트
        
        private void SYSA213_Load(object sender, EventArgs e)
        {

        }
        private void SYSA213_Shown(object sender, EventArgs e)
        {
            MainButton_INIT.PerformClick();
        }
       
        #endregion

        #region 버튼이벤트

        public void InitButton_Click()
        {
            // 초기화 관련 구현은 여기에 구현 ***

            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);

            // 그리드 조회 메서드 호출
            this.GetGridViewList();
        }

        public void DeleteButton_Click()
        {
            // 삭제 관련 구현은 여기에 구현 ***

        }

        public void NewButton_Click()
        {
            //// 신규 관련 구현은 여기에 구현 ***

            //// 1.수정된 데이터를 미리 저장하고 신규 구현을 하도록 한다.
            //MainButton_Save.PerformClick(); // 강제로 저장 로직 수행.

            //// 2.신규 상태 변경
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New);

            gvList.EX_AddNewRow();
            idatDxRadioGroup_Type.SelectedIndex = 0;
            idatDxRadioGroup_Useflag.SelectedIndex = 0;

            idatDxTextEdit_No.Focus();

            //// 3.그리드에 새로운 행을 추가.
            BASE_clsDevexpressGridUtil.AddNewRow(gvList);
        }

        public void EditButton_Click()
        {
            //// 수정 관련 구현은 아래에 구현 ***
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit);
        }

        public void StopButton_Click()
        {
            // 정지 관련 구현은 아래에 구현 ***
        }

        public void SearchButton_Click()
        {
            // 검색 관련 구현은 아래에 구현 ***
        }

        public void SaveButton_Click()
        {
            //// 저장 관련 구현은 여기에 구현 ***

            //// ************************************************************************************
            //// 유효성검사 수행
            //// 유효성 검사 대상은 컨트롤 속성
            //// [컨트롤].ValidationCheck == True 일때 체크가 됨.
            //// ************************************************************************************

            // 유효성 검사를 하기 위한 필수 메서드.
            base.baseDxErrorProvider.ClearErrors();
            ValidateChildren(ValidationConstraints.Visible);

            // 유효성 검사시 오류가 있을경우 리턴을 함.
            if (base.baseDxErrorProvider.HasErrors)
            {
                return;
            }


            // 임시 변수 선언. 해당 업무에 맞도록 변수 선언 및 변경 하도록 함.
            // ************ 샘플 ********************** 시작

            string _strType = "", _strNo = "", _strTitle = "", _strRemarks = "", _strUseFlag = "";
            if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit)
            {
                // ****** 마지막 수정항목을 데이터셋에 적용 시킬려면 포커스를 이동을 한다.
                gvList.FocusedRowHandle = -1;

                // 수정,추가,변경 된 데이터를 모두 가져온다.
                DataTable _dt = gvList.EX_GetChangedData();

                if (_dt == null)
                    return;

                // 변경된 데이터가 없으면 return.
                if (_dt.Rows.Count == 0) return;

                // 변경된 데이터를 루프를 통해 하나씩 빼낸다.
                foreach (DataRow _dr in _dt.Rows)
                {
                    switch (_dr.RowState)
                    {
                        case DataRowState.Modified:
                            _strType = _dr["TYPE"].ObjectNullString();
                            _strNo = _dr["NO"].ObjectNullString();
                            _strTitle = _dr["TITLE"].ObjectNullString();
                            _strRemarks = _dr["REMARKS"].ObjectNullString();
                            _strUseFlag = _dr["USEFLAG"].ObjectNullString();
                            this.SaveData(_strType, _strNo, _strTitle, _strRemarks, _strUseFlag);
                            break;

                        default:
                            break;
                    }
                }

                // 수정이 완료 되면 초기화를 수행하도록 함.
                MainButton_INIT.PerformClick();

                // 마지막 처리 된 값쪽에 포커스를 이동 시킵니다.
                // 사용시에 주석을 해제하고 수정하세요.
                gvList.EX_GetFocuseRowCell("NO", _strNo);
                // ************ 샘플 ********************** 끝
            }
            else if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
            {
                // ***** 신규 관련 프로시져를 여기에 구현을 합니다.

                _strType = idatDxRadioGroup_Type.EditValue.ObjectNullString();
                _strNo = idatDxTextEdit_No.Text.ObjectNullString();
                _strTitle = idatDxTextEdit_Title.Text.ObjectNullString();
                _strRemarks = idatDxMemoEdit_Remarks.Text.ObjectNullString();
                _strUseFlag = idatDxRadioGroup_Useflag.EditValue.ObjectNullString();
                this.SaveData(_strType, _strNo, _strTitle, _strRemarks, _strUseFlag);

                // 신규 항목 데이터를 처리하면 그리드를 리프레쉬 합니다.
                MainButton_INIT.PerformClick();
                MainButton_New.PerformClick();

                // 신규 처리 한 곳으로 포커스를 이동 시킵니다. 
                // 사용시에 주석을 해제하고 수정하세요.
            }
        }

        public void PrintButton_Click()
        {
            // 출력 관련 구현은 아래에 구현 ***
        }

        public void RefreshButton_Click()
        {
            GetGridViewList_Refresh();
        }

        #endregion

        #region 함수

        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid( gcList
                                       , "PKGSYS_COMM.GET_NOTICE"
                                       , 1
                                       , new string[] { 
                                         "A_CLIENT"
                                       , "A_COMPANY"
                                       , "A_PLANT"
                                       , "A_SYSTEM"
                                       , "A_VIEW" }
                                       , new string[] {
                                         Global.Global_Variable.CLIENT
                                       , Global.Global_Variable.COMPANY
                                       , Global.Global_Variable.PLANT
                                       , Global.Global_Variable.SYSTEMCODE
                                       , "0" }
                                       , true
                                       );

            gvList.Columns["SYSCODE"].Visible = false;
            // 컬럼 조절
            gvList.BestFitColumns();
        }

        private void GetGridViewList_Refresh()
        {
            BASE_DXGridHelper.Refresh_Grid( gcList
                                          , "PKGSYS_COMM.GET_NOTICE"
                                          , 1
                                          , new string[] { 
                                            "A_CLIENT"
                                          , "A_COMPANY"
                                          , "A_PLANT"
                                          , "A_SYSTEM"
                                          , "A_VIEW" }
                                          , new string[] { 
                                            Global.Global_Variable.CLIENT
                                          , Global.Global_Variable.COMPANY
                                          , Global.Global_Variable.PLANT
                                          , Global.Global_Variable.SYSTEMCODE
                                          , "0" }
                                          , true
                                          );

            gvList.Columns["SYSCODE"].Visible = false;
        }


        private void SaveData(string p_strType, string p_strNo, string p_strTitle, string p_strRemarks, string p_strUseFlag)
        {

            /// ****************** DBData 처리 WebService ****************
            /// 데이터 수정,삭제,추가 정보는 필수적으로 BASE_db.Execute_Proc(...) 사용하도록 함.
            /// **********************************************************
            BASE_db.Execute_Proc( "PKGSYS_COMM.PUT_NOTICE"
                                , 1
                                , new string[] { 
                                  "A_CLIENT"
                                , "A_COMPANY"
                                , "A_PLANT"
                                , "A_SYSTEM"
                                , "A_TYPE"
                                , "A_NO"
                                , "A_TITLE"
                                , "A_REMARKS"
                                , "A_USEFLAG"
                                , "A_USER" }
                                , new string[] {
                                  Global.Global_Variable.CLIENT
                                , Global.Global_Variable.COMPANY
                                , Global.Global_Variable.PLANT
                                , Global.Global_Variable.SYSTEMCODE
                                , p_strType
                                , p_strNo
                                , p_strTitle
                                , p_strRemarks
                                , p_strUseFlag
                                , Global.Global_Variable.EHRCODE }
                                , true
                                );

        }
        #endregion

        #region 일반 이벤트

        private void gvList_Click(object sender, EventArgs e)
        {
            if (!(sender is GridAlias.GridView))
            {
                return;
            }

            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo gridHitINFO = BASE_clsDevexpressGridUtil.GetClickHitInfo(gvList, e);

            if (gridHitINFO.InRow && gridHitINFO.InColumn)
            {
                /// ============================================================
                /// 선택된 Row의 정보를 가져올려면 아래에 구현을 하면 된다.
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

            DataTable changes = gvList.EX_GetChangedData(DataRowState.Modified);

            if (e.RowHandle < 0)
                return;

            // 수정된 키값 필드를 입력한다.
            foreach (DataRow dr in changes.Rows)
            {
                if (dr["A"] != null)
                {
                    // 주키가 두개일 경우 AND 문으로 조건을 다중으로 준다.
                    if (dr["A"].ToString() == gvList.GetDataRow(e.RowHandle)["A"].ToString())
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
            }


        }

        #endregion



    }
}
