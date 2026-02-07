using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using HAENGSUNG_HNSMES_UI.Class;
using GridAlias = DevExpress.XtraGrid.Views.Grid;
using HAENGSUNG_HNSMES_UI.WebService.Access;

namespace HAENGSUNG_HNSMES_UI.Forms.SYS
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : SYSA211<br/>
    ///      기능 : 사원 마스터 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    public partial class SYSA211 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
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

        public SYSA211()
        {
            InitializeComponent();
        }
        private void SYSA211_Load(object sender, EventArgs e)
        {

        }

        private void SYSA211_Shown(object sender, EventArgs e)
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
            this.Set_Init();
            this.GetGridViewList("");
        }

        public void NewButton_Click()
        {
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New);
            gvList.EX_AddNewRow();

            //dteHire.DateTime = DateTime.Now;
            //dteQuit.DateTime = DateTime.Now.AddYears(100);

            rdgUseFlag.SelectedIndex = 0;
            txtEhrCode.Focus();
        }

        public void EditButton_Click()
        {
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit);
        }

        public void StopButton_Click()
        {
        }

        public void DeleteButton_Click()
        {
        }

        public void SearchButton_Click()
        {
        }

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



            string _strEhrCode = "";
            string _strUseID = "";
            string _strEngName = "";
            string _strLocName = "";
            string _strUserClass = "";
            string _strDept = "";
            string _strPos = "";
            string _strPhone = "";
            string _strEmail = "";
            string _strHireDate = "";
            string _strQuitDate = "";
            string _strRemarks = "";
            string _strUseyn = "";

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
                            _strEhrCode = _dr["EHRCODE"].ObjectNullString();
                            _strUseID = _dr["USERID"].ObjectNullString();
                            _strEngName = _dr["ENGUSERNAME"].ObjectNullString();
                            _strLocName = _dr["LOCUSERNAME"].ObjectNullString();
                            _strUserClass = _dr["USERROLE"].ObjectNullString();
                            _strDept = _dr["DEPARTMENT"].ObjectNullString();
                            _strPos = _dr["POSITION"].ObjectNullString();
                            _strPhone = _dr["PHONE"].ObjectNullString();
                            _strEmail = _dr["EMAIL"].ObjectNullString();
                            _strHireDate = "";//_dr["HIREDATE"].ObjectNullString().Substring(0,10).Replace("-","");
                            _strQuitDate = "";//_dr["QUITDATE"].ObjectNullString().Substring(0,10).Replace("-","");
                            _strRemarks = _dr["REMARKS"].ObjectNullString();
                            _strUseyn = _dr["USEFLAG"].ObjectNullString();

                            if (!SaveData(_strEhrCode,
                                          _strUseID,
                                          _strEngName,
                                          _strLocName,
                                          _strUserClass,
                                          _strDept,
                                          _strPos,
                                          _strPhone,
                                          _strEmail,
                                          _strHireDate,
                                          _strQuitDate,
                                          _strRemarks,
                                          _strUseyn,
                                          "N"))
                            {
                                MainButton_INIT.PerformClick();
                                gvList.EX_GetFocuseRowCell("EHRCODE", _strEhrCode);
                                return;
                            }

                            break;

                        default:
                            break;
                    }
                }

                MainButton_INIT.PerformClick();

                gvList.EX_GetFocuseRowCell("EHRCODE", _strEhrCode);
            }
            else if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
            {
                // ***** 신규 관련 프로시져를 여기에 구현을 합니다.
                _strEhrCode = txtEhrCode.EditValue.ObjectNullString();
                _strUseID = txtUserID.EditValue.ObjectNullString();
                _strEngName = txtEngName.EditValue.ObjectNullString();
                _strLocName = txtLocName.EditValue.ObjectNullString();
                _strUserClass = gleUserRole.EditValue.ObjectNullString();
                _strDept = gleDept.EditValue.ObjectNullString();
                _strPos = glePos.EditValue.ObjectNullString();
                _strPhone = txtPhone.EditValue.ObjectNullString();
                _strEmail = txtEmail.EditValue.ObjectNullString();
                _strHireDate = dteHire.DateTime.ToString("yyyyMMdd");
                _strQuitDate = dteQuit.DateTime.ToString("yyyyMMdd");
                _strRemarks = memRemarks.EditValue.ObjectNullString();
                _strUseyn = rdgUseFlag.EditValue.ObjectNullString();

                if (!SaveData(_strEhrCode,
                         _strUseID,
                         _strEngName,
                         _strLocName,
                         _strUserClass,
                         _strDept,
                         _strPos,
                         _strPhone,
                         _strEmail,
                         _strHireDate,
                         _strQuitDate,
                         _strRemarks,
                         _strUseyn,
                         "Y"))
                {
                    // 신규 항목 데이터를 처리하면 그리드를 리프레쉬 합니다.
                    MainButton_INIT.PerformClick();
                    return;
                }

                // 신규 항목 데이터를 처리하면 그리드를 리프레쉬 합니다.
                MainButton_INIT.PerformClick();
                MainButton_New.PerformClick();
            }

        }

        public void PrintButton_Click()
        {
        }

        public void RefreshButton_Click()
        {
        }


        private void btnAddUser_Click(object sender, EventArgs e)
        {
            using (HAENGSUNG_HNSMES_UI.Forms.COM.COMREGISTER_NEW _frm = new Forms.COM.COMREGISTER_NEW())
            {
                _frm.FormClass = "W";
                _frm.ShowDialog(this);
            }
        }

        private void btnChangePW_Click(object sender, EventArgs e)
        {

            using (COM.COMPWDCHANGE chPwd = new COM.COMPWDCHANGE(txtEhrCode.EditValue.ObjectNullString()))
            {
                if (chPwd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    chPwd.Close();
            }
        }


        private void btnReSetPW_Click(object sender, EventArgs e)
        {
            if (txtEhrCode.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_COMM_025", this.Text, 5);
                return;
            }

            if (iDATMessageBox.QuestionMessage("MSG_QS_COMM_002", this.Text) == System.Windows.Forms.DialogResult.No)
                return;


            WSResults clsDataSet = BASE_db.Execute_Proc( "PKGSYS_USER.PUT_DEFAULTPWD"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_USERID"         
                                                       , "A_PWD"
                                                       , "A_EDTUSER" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , txtEhrCode.EditValue.ObjectNullString()
                                                       , new IDAT_Common.Security.Encryption().Encrypt("1111")
                                                       , Global.Global_Variable.EHRCODE }
                                                       );

            if (clsDataSet.ResultInt == 0)
            {
                iDATMessageBox.OKMessage("MSG_OK_REG_001", this.Text, 3);
            }
            else
            {
                iDATMessageBox.ErrorMessage(clsDataSet.ResultString, BASE_Language.GetMessageString("Error"), 5);
            }
        }


        #endregion

        #region 함수

        private bool SaveData(
            string p_strEhr = "",
            string p_strUseID = "",
            string p_strEngName = "",
            string p_strLocName = "",
            string p_strClass = "",
            string p_strDept = "",
            string p_strPos = "",
            string p_strPhone = "",
            string p_strEmail = "",
            string p_strHireDate = "",
            string p_strQuitDate = "",
            string p_strRemarks = "",
            string p_strUseFlag = "",
            string p_strNewFlag = "")
        {

            bool _Rtn = BASE_db.Execute_Proc( "PKGSYS_USER.PUT_EHR"
                                            , 1
                                            , new string[] {
                                              "A_CLIENT"
                                            , "A_COMPANY"
                                            , "A_PLANT"
                                            , "A_SYSTEM"
                                            , "A_EHR"
                                            , "A_USERID"
                                            , "A_ENG_NM"
                                            , "A_LOC_NM"  
                                            , "A_CLASS"
                                            , "A_DEPT"
                                            , "A_POS"
                                            , "A_PHONE"
                                            , "A_EMAIL"
                                            , "A_HIRE_DT"
                                            , "A_QUIT_DT"
                                            , "A_REMARKS"      
                                            , "A_USEFLAG"
                                            , "A_EDT_USER"
                                            , "A_NEWFLAG" }
                                            , new string[] {
                                              Global.Global_Variable.CLIENT
                                            , Global.Global_Variable.COMPANY
                                            , Global.Global_Variable.PLANT
                                            , Global.Global_Variable.SYSTEMCODE
                                            , p_strEhr
                                            , p_strUseID
                                            , p_strEngName
                                            , p_strLocName
                                            , p_strClass
                                            , p_strDept
                                            , p_strPos
                                            , p_strPhone
                                            , p_strEmail
                                            , p_strHireDate
                                            , p_strQuitDate
                                            , p_strRemarks
                                            , p_strUseFlag
                                            , Global.Global_Variable.EHRCODE
                                            , p_strNewFlag }
                                            , true
                                            );

            return _Rtn;

        }

        private void Set_Init()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleUserRole
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
                                                       , "0" }
                                                       , "USERROLE"
                                                       , "USERROLENAME"
                                                       , "USERROLE, USERROLENAME, REMARKS"
                                                       );

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleDept
                                                       , "PKGSYS_USER.GET_DEPT"
                                                       , 1
                                                       , new string[] { 
                                                        "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT" }
                                                       , new string[] { 
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT }
                                                       , "DEPARTMENT"
                                                       , "DEPARTMENTNAME"
                                                       , "DEPARTMENT, DEPARTMENTNAME, REMARKS"
                                                       );

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( glePos
                                                       , "PKGSYS_USER.GET_POST"
                                                       , 1
                                                       , new string[] { 
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT" }
                                                       , new string[] { 
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT }
                                                       , "POSITION"
                                                       , "POSITIONNAME"
                                                       , "POSITION, POSITIONNAME, REMARKS"
                                                       );
        }

        private void GetGridViewList(string p_UserName)
        {
            /// 프로시져 명 : PKG_USER.GET_EHRMASTER
            /// 컨트롤의 사용자 정보를 셋하기 위해 사용한다.
            BASE_DXGridHelper.Bind_Grid( gcList
                                       , "PKGSYS_USER.GET_EHR"
                                       , 1
                                       , new string[] { 
                                         "A_CLIENT"
                                       , "A_COMPANY"
                                       , "A_PLANT"
                                       , "A_SYSTEM"
                                       , "A_NAMELOC"
                                       , "A_VIEW" }
                                       , new string[] { 
                                         Global.Global_Variable.CLIENT
                                       , Global.Global_Variable.COMPANY
                                       , Global.Global_Variable.PLANT
                                       , Global.Global_Variable.SYSTEMCODE
                                       , p_UserName
                                       , "1" }
                                       , true
                                       , "EHRCODE, USERID, LOCUSERNAME, DEPARTMENTNAME, POSITIONNAME, USERROLENAME, REMARKS1, USEFLAG"
                                       );

            gvList.BestFitColumns();

        }

        #endregion

        #region 일반이벤트

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
            // 수정된 항목을 그리드에 표시하는 기능을 하지 않을려면 주석 처리를 하세요.
            DataTable changes = BASE_clsDevexpressGridUtil.GetChangedData(gcList, DataRowState.Modified);

            if (e.RowHandle < 0)
                return;

            // 수정된 키값 필드를 입력한다.
            foreach (DataRow dr in changes.Rows)
            {
                if (dr["EHRCODE"] != null)
                {
                    // 주키가 두개일 경우 AND 문으로 조건을 다중으로 준다.
                    if (dr["EHRCODE"].ToString() == gvList.GetDataRow(e.RowHandle)["EHRCODE"].ToString())
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
            }
        }

        #endregion


    }
}
