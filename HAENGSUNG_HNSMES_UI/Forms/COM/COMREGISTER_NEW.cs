using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using IDAT_Common.Security;
using HAENGSUNG_HNSMES_UI.WebService.Access;

namespace HAENGSUNG_HNSMES_UI.Forms.COM
{
    public partial class COMREGISTER_NEW : BASE.Form
    {
        #region [Member Variable & Property]

        #endregion

        #region [생성자 & Load 이벤트]

        /// <summary>
        /// 생성자 함수
        /// </summary>
        /// <remarks>
        /// 회원등록
        /// </remarks>
        public COMREGISTER_NEW()
        {
            WaitDialogForm waitDlg = new WaitDialogForm("Program Loading...", "loading");
            waitDlg.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();

            waitDlg.Close();

            layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        /// <summary>
        /// 생성자 함수
        /// </summary>
        /// <remarks>
        /// 회원수정
        /// </remarks>
        /// <param name="userId">회원 수정을 하기위해 User Id정보를 받음</param>
        public COMREGISTER_NEW(string userId)
            : this()
        {
            // 타이틀 명 변경.
            this.Text = "My Settings";

            layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            txtUserID.Text = userId;
            txtUserID.Properties.ReadOnly = true;
            txtPass.Properties.ReadOnly = true;

            layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            // Register를 Save로 바꾼다.
            layoutControlItem19.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            btnUserIDPassword.Text = "Save";

            // Validate이벤트를 취소합니다.
            txtUserID.Validating -= new CancelEventHandler(txtUserID_Validating);
            txtPass.Validating -= new CancelEventHandler(txtPass_Validating);

            GetUserInfo(userId);
        }

        /// <summary>
        /// 폼 로드 이벤트
        /// </summary>
        private void frmUserRegister_Load(object sender, EventArgs e)
        {
            // Dept, Position 아이템을 설정합니다.
            GetDept();
            getPosition();

            buttonEdit_EHRCODE.Focus();
            txtUserID.Properties.ReadOnly = false;
        }

        #endregion


        /// 1. 회원을 등록합니다.
        /// 2. 사용자 정보를 데이터테이블 객체에 담아 리턴을 합니다.
        /// 3. 부서정보를 셋합니다.
        /// 4. 포지션정보를 셋합니다.
        /// 5. 회원을 수정합니다.
        #region [Private Method]

        /// [1]
        /// <summary>
        /// 회원을 등록합니다.
        /// </summary>
        /// <returns>
        /// 회원등록시에 아이디 중복을 확인하고 유효성 검사후에 
        /// 회원정보를 등록합니다.
        /// </returns>
        private bool AddMember()
        {
            //string strUserId = txtUserID.Text;
            //string strUserNameE = txtUserNameEng.Text;
            //string strUserNameL = txtUserNameLoc.Text;
            //string strPassword = new Encryption().Encrypt(txtPass.Text);
            //string strTel = txtTelNum.Text;
            //string strEmail = txtEmail.Text;
            //string strDept = luDept.EditValue != null ? luDept.EditValue.ToString().Trim() : "";
            //string strPosition = luPosition.EditValue != null ? luPosition.EditValue.ToString().Trim() : "";
            //string strClass = txtUserClass.Text;
            //string strRemark = txtRemark.Text;

            //string Procname = "PKG_USER.INS_USER";
            //System.Collections.ArrayList AryName = new System.Collections.ArrayList();
            //System.Collections.ArrayList AryValue = new System.Collections.ArrayList();

            //AryName.Add("A_USERID");
            //AryName.Add("A_PWD");
            //AryName.Add
            //AryName.Add("A_CLASS");
            //AryName.Add("A_DEPT");
            //AryName.Add("A_POS");
            //AryName.Add("A_PHONE");
            //AryName.Add("A_EMAIL");
            //AryName.Add("A_REMARKS");
            //AryName.Add("A_EDT_USER");

            //AryValue.Add(strUserId);
            //AryValue.Add(strUserNameE);
            //AryValue.Add(strUserNameL);
            //AryValue.Add(strPassword);
            //AryValue.Add("G");
            //AryValue.Add(strDept);
            //AryValue.Add(strPosition);
            //AryValue.Add(strTel);
            //AryValue.Add(strEmail);
            //AryValue.Add(strRemark);
            //AryValue.Add("");

            //clsDataSetStruct result = dbWs.ExecuteProcCls(Procname, AryName, AryValue);

            //if (result.pResultInt != 0)
            //{
            //    return false;
            //}
            //else
            //{
                return true;
            //}
        }

        /// [2]
        /// <summary>
        /// 사용자 정보를 데이터테이블 객체에 담아 리턴을 합니다.
        /// </summary>
        /// <param name="userId">사용자 아이디</param>
        /// <returns>사용자 정보</returns>
        private void GetUserInfo(string userId)
        {
            string Procname = "PKGSYS_USER.GET_REGUSER";

            WSResults result = BASE_db.Execute_Proc(Procname, 
                1, 
                new string[] { 
                               "A_CLIENT"
                             , "A_COMPANY"
                             , "A_PLANT"
                             , "A_SYSTEM"
                             , "A_EHR" 
                             }, 
                new string[] { 
                               Global.Global_Variable.CLIENT
                             , Global.Global_Variable.COMPANY
                             , Global.Global_Variable.PLANT
                             , Global.Global_Variable.SYSTEMCODE
                             , Global.Global_Variable.EHRCODE 
                             }
                );

            if (result.ResultInt != 0)
            {
                Class.iDATMessageBox.WARNINGMessage(result.ResultString, "사용자 정보 조회", 5);
                this.DialogResult = System.Windows.Forms.DialogResult.No;
                this.Close();
                return;
            }

            DataSet ds = result.ResultDataSet;

            buttonEdit_EHRCODE.Text = ds.Tables[0].Rows[0]["EHRCODE"].ObjectNullString();
            txtUserNameEng.Text = ds.Tables[0].Rows[0]["ENGUSERNAME"].ObjectNullString();
            txtUserNameLoc.Text = ds.Tables[0].Rows[0]["LOCUSERNAME"].ObjectNullString();
            txtPass.Text = new Encryption().Decrypt(ds.Tables[0].Rows[0]["PASSWORD"].ObjectNullString());
            luDept.EditValue = ds.Tables[0].Rows[0]["DEPARTMENT"].ObjectNullString();
            luPosition.EditValue = ds.Tables[0].Rows[0]["POSITION"].ObjectNullString();
            txtTelNum.Text = ds.Tables[0].Rows[0]["PHONE"].ObjectNullString();
            txtEmail.Text = ds.Tables[0].Rows[0]["EMAIL"].ObjectNullString();
            txtRemark.Text = ds.Tables[0].Rows[0]["REMARKS"].ObjectNullString();
            txtUserClass.Text = ds.Tables[0].Rows[0]["USERROLE"].ObjectNullString();
            txtUserClassName.Text = ds.Tables[0].Rows[0]["USERROLENAME"].ObjectNullString();
            string hire = ds.Tables[0].Rows[0]["HIREDATE"].ObjectNullString();

            dateEdit_HireDate.EditValue = hire;
        }

        /// [2]
        /// <summary>
        /// 사용자 정보를 데이터테이블 객체에 담아 리턴을 합니다.
        /// </summary>
        /// <param name="userId">사용자 아이디</param>
        /// <returns>사용자 정보</returns>
        private void GetUserEHR(string ehr)
        {
            string Procname = "PKGSYS_USER.GET_REGUSER";

            WSResults result = BASE_db.Execute_Proc(Procname, 
                1, 
                new string[] { 
                               "A_CLIENT"
                             , "A_COMPANY"
                             , "A_PLANT"
                             , "A_SYSTEM"
                             , "A_EHR" }, 
                new string[] { 
                               Global.Global_Variable.CLIENT
                             , Global.Global_Variable.COMPANY
                             , Global.Global_Variable.PLANT
                             , Global.Global_Variable.SYSTEMCODE
                             , ehr 
                             }
                );


            DataSet ds = result.ResultDataSet;

            if(result.ResultInt !=0)
            {
                dxErrorProviderReg.SetError(buttonEdit_EHRCODE, result.ResultString);
                btnUserIDPassword.Enabled = false;
                btnRegister.Enabled = false;
                return;

            }
            else
            {
                btnUserIDPassword.Enabled = true;
                btnRegister.Enabled = true;
            }

            if (ds.Tables[0].Rows[0]["USERID"].ObjectNullString().Length > 0)
            {
                txtUserID.Enabled = false;
                btnUserIDPassword.Enabled = false;
                txtUserID.Text = ds.Tables[0].Rows[0]["USERID"].ObjectNullString();
                txtPass.Text = ds.Tables[0].Rows[0]["PASSWORD"].ObjectNullString();

            }
            else
            {
                txtUserID.Enabled = true;
                btnUserIDPassword.Enabled = true;
            }

            txtUserNameEng.Text = ds.Tables[0].Rows[0]["ENGUSERNAME"].ObjectNullString();
            txtUserNameLoc.Text = ds.Tables[0].Rows[0]["LOCUSERNAME"].ObjectNullString();
            txtPass.Text = new Encryption().Decrypt(ds.Tables[0].Rows[0]["PASSWORD"].ObjectNullString());
            luDept.EditValue = ds.Tables[0].Rows[0]["DEPARTMENT"].ObjectNullString();
            luPosition.EditValue = ds.Tables[0].Rows[0]["POSITION"].ObjectNullString();
            txtTelNum.Text = ds.Tables[0].Rows[0]["PHONE"].ObjectNullString();
            txtEmail.Text = ds.Tables[0].Rows[0]["EMAIL"].ObjectNullString();
            txtRemark.Text = ds.Tables[0].Rows[0]["REMARKS"].ObjectNullString();
            txtUserClass.Text = ds.Tables[0].Rows[0]["USERROLE"].ObjectNullString();
            txtUserClassName.Text = ds.Tables[0].Rows[0]["USERROLENAME"].ObjectNullString();
            string hire = ds.Tables[0].Rows[0]["HIREDATE"].ObjectNullString();

            //textEdit_RankPosition.Text = rankPosi;
            dateEdit_HireDate.EditValue = hire;
            //dateEdit_PromoteDate.EditValue = promote == "" ? "" : string.Format("{0}-{1}-{2}", promote.Substring(0, 4), promote.Substring(4, 2), promote.Substring(6, 2));
            //dateEdit_QuitDate.EditValue = quite == "" ? "" : string.Format("{0}-{1}-{2}", quite.Substring(0, 4), quite.Substring(4, 2), quite.Substring(6, 2));
        }

        /// [3]
        /// <summary>
        /// 부서정보를 셋합니다.
        /// </summary>
        private void GetDept()
        {
            string Procname = "PKGSYS_USER.GET_DEPT";

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(luDept, 
                Procname, 
                1, 
                new string[] { 
                               "A_CLIENT"
                             , "A_COMPANY"
                             , "A_PLANT"
                             }, 
                new string[] { 
                               Global.Global_Variable.CLIENT
                             , Global.Global_Variable.COMPANY
                             , Global.Global_Variable.PLANT
                             }, 
               "DEPARTMENT", 
               "DEPARTMENTNAME", "DEPARTMENT, DEPARTMENTNAME");
        }

        /// [4]
        /// <summary>
        /// 포지션을 셋합니다.
        /// </summary>
        private void getPosition()
        {
            string Procname = "PKGSYS_USER.GET_POST";

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(luPosition, 
                Procname, 
                1, 
                new string[] { 
                               "A_CLIENT"
                             , "A_COMPANY"
                             , "A_PLANT"
                             }, 
                new string[] { 
                               Global.Global_Variable.CLIENT
                             , Global.Global_Variable.COMPANY
                             , Global.Global_Variable.PLANT
                             }, 
                "POSITION", 
                "POSITIONNAME", "POSITION, POSITIONNAME");
        }

        /// [5] 
        /// <summary>
        /// 회원을 수정합니다.
        /// </summary>
        /// <returns>회원을 수정합니다.</returns>
        private void EditMember()
        {
            string strUserId = txtUserID.Text;
            string strEhrcode = buttonEdit_EHRCODE.Text;
            string strDept = luDept.EditValue != null ? luDept.EditValue.ToString().Trim() : "";
            string strPosition = luPosition.EditValue != null ? luPosition.EditValue.ToString().Trim() : "";
            string strTel = txtTelNum.Text;
            string strEmail = txtEmail.Text;
            string strPassword = new IDAT_Common.Security.Encryption().Encrypt(txtPass.Text);
            string strRemark = txtRemark.Text;

            string Procname = "PKGSYS_USER.PUT_REGUSER";

            WSResults result = BASE_db.Execute_Proc(Procname, 
                1,
                new string[] { 
                               "A_CLIENT"
                             , "A_COMPANY"
                             , "A_PLANT"
                             , "A_USERID"
                             , "A_PWD"
                             , "A_EHRCODE"
                             , "A_PHONE"
                             , "A_EMAIL"
                             , "A_DEPT"
                             , "A_POST"
                             , "A_REMARKS"
                             },
                new string[] { 
                               Global.Global_Variable.CLIENT
                             , Global.Global_Variable.COMPANY
                             , Global.Global_Variable.PLANT
                             , strUserId
                             , strPassword
                             , strEhrcode
                             , strTel
                             , strEmail
                             , strDept
                             , strPosition
                             , strRemark 
                             }
                );

            //AryName.Add("A_EHR_CODE");
            //AryName.Add("A_USER_NM_ENG");
            //AryName.Add("A_USER_NM_LOC");
            //AryName.Add("A_CLASS");
            //AryName.Add("A_DEPT");
            //AryName.Add("A_POS");
            //AryName.Add("A_RANKPOS");
            //AryName.Add("A_PHONE");
            //AryName.Add("A_EMAIL");
            //AryName.Add("A_PROMO_DT");
            //AryName.Add("A_HIRE_DT");
            //AryName.Add("A_QUIT_DT");
            //AryName.Add("A_USEFLAG");
            //AryName.Add("A_REMARKS");
            //AryName.Add("A_EDT_USER");

            //AryValue.Add(strEhrcode);
            //AryValue.Add(strUserNameE);
            //AryValue.Add(strUserNameL);
            //AryValue.Add(strClass);
            //AryValue.Add(strDept);
            //AryValue.Add(strPosition);
            //AryValue.Add(strRankPos);
            //AryValue.Add(strTel);
            //AryValue.Add(strEmail);
            //AryValue.Add(strPromote);
            //AryValue.Add(strhire);
            //AryValue.Add(strQuit);
            //AryValue.Add("Y");
            //AryValue.Add(strRemark);
            //AryValue.Add(strUserId);

            //WSResults result = dbWs.ExecuteProcCls(Procname, AryName, AryValue);

            if (result.ResultInt != 0)
            {
                Class.iDATMessageBox.WARNINGMessage(result.ResultString, "정보 수정", 5);
            }
            else
            {
                Class.iDATMessageBox.OKMessage(result.ResultString, "정보 수정", 5);
            }
        }

        #endregion


        /// 1. 종료
        /// 2. 중복체크 [현재 사용하지 않음]
        /// 3. 등록
        /// 4. 비밀번호 변경
        #region [버튼 클릭 이벤트]

        /// [1]
        /// <summary>
        /// 종료 버튼 클릭 이벤트
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// [2]
        /// <summary>
        /// 중복 버튼 클릭 이벤트
        /// </summary>
        private void btnExist_Click(object sender, EventArgs e)
        {
            // 아이디 중복 체크를한다.
        }

        /// [3]
        /// <summary>
        /// 등록 버튼 클릭 이벤트
        /// </summary>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            dxErrorProviderReg.ClearErrors();
            ValidateChildren(ValidationConstraints.Visible);

            // 유효성 검사에서 에러 발생여부를 확인 한다.
            if (dxErrorProviderReg.HasErrors)
            {
                return;
                // 에러가 있다면 등록이 되지 않는다.
            }

            EditMember();
        }

        /// [4]
        /// <summary>
        /// 비밀번호를 변경하기 위해 비밀번호 변경 창을 보여준다.
        /// </summary>
        private void btnChange_Click(object sender, EventArgs e)
        {
            layoutControl2.Enabled = false;

            layoutControl2.Enabled = false;
            try
            {
                COM.COMPWDCHANGE chPwd = new COM.COMPWDCHANGE(Global.Global_Variable.USER_ID);

                if (chPwd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    this.txtPass.Text = chPwd.Password;
            }
            catch (Exception)
            {
            }
            finally
            {
                layoutControl2.Enabled = true;
            }
        }


        /// xuc_chp[비밀번호 변경창 컨트롤]에 관련된 이벤트입니다.
        /// <summary>
        /// 비밀번호가 변경이 되면 발생하는 이벤트 입니다.
        /// </summary>
        /// <param name="sender">비밀번호 변경창 컨트롤</param>
        /// <param name="pass">변경된 비밀번호</param>
        void xuc_chp_ChangeEvent(object sender, string pass)
        {
            this.layoutControl2.Enabled = true;
            this.Controls.Remove(sender as Control);
            txtPass.Text = pass;
        }

        /// xuc_chp[비밀번호 변경창 컨트롤]에 관련된 이벤트입니다.
        /// <summary>
        /// 비밀번호 변경창에서 Cancel버튼을 누르면 발생되는 이벤트 입니다.
        /// </summary>
        /// <param name="sender">비밀번호 변경창 컨트롤</param>
        void xuc_chp_CancelEvent(object sender)
        {
            this.layoutControl2.Enabled = true;
            this.Controls.Remove(sender as Control);
        }

        #endregion


        /// 1. 패스워드
        /// 2. 패스워드 확인
        /// 3. 사용자 아이디
        /// 4. Dept, Position
        #region [Validate Event]

        /// [1]
        /// <summary>
        /// 패스워드 Validating 이벤트 유효성 검사를 합니다.
        /// </summary>
        private void txtPass_Validating(object sender, CancelEventArgs e)
        {
            if (txtPass.Text.Trim().Length == 0)
            {
                dxErrorProviderReg.SetError(sender as Control, "패스워드를 입력해주세요.");
            }
            else
            {
                dxErrorProviderReg.SetError(sender as Control, "", DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);
            }
        }

        /// [3]
        /// <summary>
        /// UserId이벤트에서 사용자의 중복여부를 확인을 합니다.
        /// </summary>
        private void txtUserID_Validating(object sender, CancelEventArgs e)
        {
            //if (txtUserID.Text.Trim().Length == 0)
            //{
            //    dxErrorProviderReg.SetError(sender as Control, "아이디를 입력해주세요.");
            //    return;
            //}
            //else
            //{
            //    dxErrorProviderReg.SetError(sender as Control, "", DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);
            //}

            //clsDBWebServiceManager dbWs = new clsDBWebServiceManager();

            ///// 프로시져 명 : PKG_DISP.GET_COLTYPE
            ///// 각 컨트롤의 속성을 지정하기 위해 DB테이블의 속성정보를 가져온다.
            //string Procname = "PKG_USER.SEL_USER";
            //System.Collections.ArrayList AryName = new System.Collections.ArrayList();
            //System.Collections.ArrayList AryValue = new System.Collections.ArrayList();

            //AryName.Add("A_USER_ID");
            //AryValue.Add(txtUserID.Text.Trim());

            //DataSet ds = new DataSet();

            //ds = dbWs.ExecuteProcCls(Procname, AryName, AryValue).pResultDs;

            //if (ds != null && ds.Tables[0].Rows.Count > 0)
            //{
            //    dxErrorProviderReg.SetError(sender as Control, "현재 사용자 아이디가 존재합니다.");
            //}
            //else
            //{
            //    dxErrorProviderReg.SetError(sender as Control, "", DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);
            //}
        }

        #endregion

        private void btnUserIDPassword_Click(object sender, EventArgs e)
        {
            string strUserId = txtUserID.Text.Trim();
            string strPassword = new Encryption().Encrypt(txtPass.Text);
            string strEhrCode = buttonEdit_EHRCODE.Text.Trim();
            string strPhone = txtTelNum.Text.Trim();
            string strEmail = txtEmail.Text.Trim();
            string strDeptCode = luDept.EditValue.ObjectNullString();
            string strPostCode = luPosition.EditValue.ObjectNullString();
            string strRemarks = txtRemark.Text;

            string Procname = "PKGSYS_USER.PUT_REGUSER";

            WSResults result = BASE_db.Execute_Proc(Procname,
                1,
                new string[] {
                               "A_CLIENT"
                             , "A_COMPANY"
                             , "A_PLANT"
                             , "A_USERID"
                             , "A_PWD"
                             , "A_EHRCODE"
                             , "A_PHONE"
                             , "A_EMAIL"
                             , "A_DEPT"
                             , "A_POST"
                             , "A_REMARKS"
                             },
                new string[] {
                               Global.Global_Variable.CLIENT
                             , Global.Global_Variable.COMPANY
                             , Global.Global_Variable.PLANT
                             , strUserId
                             , strPassword
                             , strEhrCode
                             , strPhone
                             , strEmail
                             , strDeptCode
                             , strPostCode
                             , strRemarks
                             }
                );


            if (result.ResultInt != 0)
            {
                Class.iDATMessageBox.WARNINGMessage(result.ResultString, "회원정보 가입/수정", 5);
            }
            else
            {
                Class.iDATMessageBox.WARNINGMessage("저장 완료", "회원정보 가입/수정", 5);
            }
        }

        private void buttonEdit_EHRCODE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dxErrorProviderReg.ClearErrors();
                GetUserEHR(buttonEdit_EHRCODE.Text.Trim());
            }
        }


    }
}