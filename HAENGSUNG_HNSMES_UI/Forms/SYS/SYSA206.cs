using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using HAENGSUNG_HNSMES_UI.WebService.Access;
using HAENGSUNG_HNSMES_UI.Class;
using GridAlias = DevExpress.XtraGrid.Views.Grid;

namespace HAENGSUNG_HNSMES_UI.Forms.SYS
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : SYSA206<br/>
    ///      기능 : 사용자 등급 마스터 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    public partial class SYSA206 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
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

        public SYSA206()
        {
            InitializeComponent();
        }

        private void SYSA206_Load(object sender, EventArgs e)
        {

        }
        private void SYSA206_Shown(object sender, EventArgs e)
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


        // 행 추가 (신규 등록 모드)
        public void NewButton_Click()
        {
            // 신규 항목을 추가하기전에 기존에 수정된 데이터를 저장하고 신규 추가를 한다.
            //this.SaveButton_Click();
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New);
            gvList.EX_AddNewRow();

            rdgUseFlag.SelectedIndex = 0;
            txtUserClassCode.Focus();
        }


        // 데이터 수정 모드
        public void EditButton_Click()
        {
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit);
        }

        public void StopButton_Click()
        {
        }

        // 등록된 마스터 정보 리스트 조회 (사옹자 등급)
        public void SearchButton_Click()
        {
        }

        public void DeleteButton_Click()
        {
        }

        // 사용자 등급 정보 등록 또는 수정 기능
        public void SaveButton_Click()
        {
            // 저장전에 필수 항목에 대한 Null 값을 초기화 합니다.
            // 유효성검사 다시 수행
            base.baseDxErrorProvider.ClearErrors();
            ValidateChildren(ValidationConstraints.Visible);


            // 유효성 검사를 한다.
            if (base.baseDxErrorProvider.HasErrors)
            {
                return;
            }

            string _strUserClassCode = "";
            string _strUserClassName;
            string _strAlertYn;
            string _strUpdateYn;
            string _strUseYn;
            string _strUserRemark;

            // 데이터 수정
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
                foreach (DataRow dr in _dt.Rows)
                {
                    switch (dr.RowState)
                    {
                        case DataRowState.Modified:

                            _strUserClassCode = dr["USERROLE"].ObjectNullString();
                            _strUserClassName = dr["USERROLENAME"].ObjectNullString();
                            _strAlertYn = dr["ALERTFLAG"].ObjectNullString();
                            _strUpdateYn = dr["UPDATEFLAG"].ObjectNullString();
                            _strUseYn = dr["USEFLAG"].ObjectNullString();
                            _strUserRemark = dr["REMARKS"].ObjectNullString();

                            if (!this.SaveData(_strUserClassCode, _strUserClassName, _strAlertYn, _strUpdateYn, _strUseYn, _strUserRemark, "N"))
                                return;
                            break;

                        default:
                            break;
                    }
                }

                MainButton_INIT.PerformClick();

                gvList.EX_GetFocuseRowCell("USERROLE", _strUserClassCode);
            }

            // 데이터 신규 등록 
            else
            {
                _strUserClassCode = txtUserClassCode.Text;
                _strUserClassName = txtUserClassName.Text;
                _strAlertYn = rdgAlertFlag.EditValue + "";
                _strUpdateYn = rdgUpdateFlag.EditValue + "";
                _strUseYn = rdgUseFlag.EditValue + "";
                _strUserRemark = memRemarks.Text + "";

                if (!this.SaveData(_strUserClassCode, _strUserClassName, _strAlertYn, _strUpdateYn, _strUseYn, _strUserRemark, "Y"))
                    return;

                // 신규 항목 데이터를 처리하면 그리드를 리프레쉬 합니다.
                MainButton_INIT.PerformClick();
                MainButton_New.PerformClick();

            }
        }


        public void PrintButton_Click()
        {

        }

        // 새로 고침 기능
        public void RefreshButton_Click()
        {
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);
            GetGridViewListRefresh();
        }

        #endregion

        #region 함수

        // 사용자 등급 정보 조회
        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid( gcList
                                       , "PKGSYS_USER.GET_ROLE"
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
                                       , "1" }
                                       , true
                                       );

            // 컬럼 조절
            gvList.BestFitColumns();
        }

        // 사용자 등급 정보 조회
        private void GetGridViewListRefresh()
        {
            BASE_DXGridHelper.Refresh_Grid( gcList
                                          , "PKGSYS_USER.GET_ROLE"
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
                                          , "1" }
                                          , true
                                          );

            // 컬럼 조절
            gvList.BestFitColumns();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// 사용자 등급 마스터 정보 등록시에 사용자 권한 코드 데이터 중복을 확인하고 유효성 검사후에 
        /// 사용자 등급 정보를 등록 또는 수정 합니다.
        /// </returns>
        private bool SaveData(string p_strUserClassCode, string p_strUseClassName, string p_strAlertFlag, string p_strUpdateFlag, string p_strUseYn, string p_strRemark, string p_strNewFlag)
        {
            bool _blReturn = BASE_db.Execute_Proc( "PKGSYS_USER.PUT_ROLE"
                                                 , 1
                                                 , new string[] { 
                                                   "A_CLIENT"
                                                 , "A_COMPANY"
                                                 , "A_PLANT"
                                                 , "A_SYSCODE"
                                                 , "A_CLASSCD"
                                                 , "A_CLASSNM"
                                                 , "A_ALERTFLAG"
                                                 , "A_UPDATEFLAG"
                                                 , "A_USEFLAG"
                                                 , "A_REMARKS"
                                                 , "A_EHRCODE"
                                                 , "A_NEWFLAG" }
                                                 , new string[] { 
                                                   Global.Global_Variable.CLIENT
                                                 , Global.Global_Variable.COMPANY
                                                 , Global.Global_Variable.PLANT
                                                 , Global.Global_Variable.SYSTEMCODE
                                                 , p_strUserClassCode
                                                 , p_strUseClassName
                                                 , p_strAlertFlag
                                                 , p_strUpdateFlag
                                                 , p_strUseYn
                                                 , p_strRemark
                                                 , Global.Global_Variable.EHRCODE 
                                                 , p_strNewFlag }
                                                 , true
                                                 );

            return _blReturn;
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

            if (gridHitINFO.InColumn)
            {
            }

            if (gridHitINFO.InGroupColumn)
            {
            }

            if (gridHitINFO.InColumnPanel)
            {
            }

            if (gridHitINFO.InFilterPanel)
            {
            }

            if (gridHitINFO.InGroupColumn)
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
            // 수정된 항목을 그리드에 표시하는 기능을 하지 않을려면 주석 처리를 하세요.
            DataTable changes = gvList.EX_GetChangedData(DataRowState.Modified);
            if (changes == null)
                return;

            if (e.RowHandle < 0)
                return;

            // 수정된 키값 필드를 입력한다.
            foreach (DataRow dr in changes.Rows)
            {
                if (dr["USERROLE"] != null)
                {
                    // 주키가 두개일 경우 AND 문으로 조건을 다중으로 준다.
                    if (dr["USERROLE"].ToString() == gvList.GetDataRow(e.RowHandle)["USERROLE"].ToString())
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
            }

        }

        #endregion

    }
}