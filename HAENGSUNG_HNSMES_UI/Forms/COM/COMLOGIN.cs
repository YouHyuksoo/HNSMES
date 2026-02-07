using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using HAENGSUNG_HNSMES_UI.Class;
using HAENGSUNG_HNSMES_UI.WebService.Access;


namespace HAENGSUNG_HNSMES_UI.Forms.COM
{
    public partial class COMLOGIN : BASE.Form,  HAENGSUNG_HNSMES_UI.Class.itfScanner
    {
        /// <summary>
        /// 
        /// </summary>
        readonly LanguageInformation clsLan = new LanguageInformation();

        /// <summary>
        /// 생성자 함수
        /// </summary>
        public COMLOGIN()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form Load Event
        /// </summary>
        private void frmLogin_Load(object sender, EventArgs e)
        {
            comLanguage.Properties.Items.Clear();
            if (Settings_IDAT.Default.WCF_ServiceIP.StartsWith("10.3.20"))
            {
                comLanguage.Properties.Items.Add("ENGLISH");
                comLanguage.Properties.Items.Add("KOREAN");
                comLanguage.Properties.Items.Add("NATIVE");

                //comLanguage.Properties.Items.Add("NATIVE");
                //comLanguage.Properties.Items.Add("KOREAN");
                //comLanguage.Properties.Items.Add("ENGLISH");
            }
            else if (Application.CurrentCulture.Name.ToUpper() == "KO-KR")
            {
                comLanguage.Properties.Items.Add("KOREAN");
                comLanguage.Properties.Items.Add("NATIVE");
                comLanguage.Properties.Items.Add("ENGLISH");
            }
            else if (Application.CurrentCulture.Name.ToUpper() == "ZH-CN")
            {
                comLanguage.Properties.Items.Add("CHINESE");
                comLanguage.Properties.Items.Add("KOREAN");
                comLanguage.Properties.Items.Add("ENGLISH");
            }
            else if (Application.CurrentCulture.Name.ToUpper() == "EN-US")
            {
                comLanguage.Properties.Items.Add("ENGLISH");
                comLanguage.Properties.Items.Add("KOREAN");
                comLanguage.Properties.Items.Add("NATIVE");
            }
            else
            {
                comLanguage.Properties.Items.Add("NATIVE");
                comLanguage.Properties.Items.Add("KOREAN");
                comLanguage.Properties.Items.Add("ENGLISH");
            }

            //comLanguage.Text = "LOCAL";
            comLanguage.SelectedIndex = 0;
            
            // 저장된 로그인 정보가 존재하면 아이디를 뿌려주고
            // 그렇지 않으면 초기화면을 보여준다.
            txtId.Text = Settings_IDAT.Default.Login;
            comLanguage.EditValue = Settings_IDAT.Default.Language;

            chkSaveID.Checked = true;

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(grdLookPlant, 
                "PKGBAS_BASE.GET_PLANT", 
                1, 
                new string[] { "A_CLIENT"
                             , "A_COMPANY"
                             , "A_PLANT"
                             , "A_VIEW" 
                             }, 
                new string[] { Global.Global_Variable.CLIENT
                             , Global.Global_Variable.COMPANY
                             , Global.Global_Variable.PLANT
                             , "0" 
                             }, 
                "PLANT", 
                "PLANTNAME", 
                "COMPANY, PLANT, PLANTNAME, REMARKS");
        }

        /// <summary>
        /// Form Load Shown Event
        /// </summary>
        private void frmLogin_Shown(object sender, EventArgs e)
        {
            btnLogin.Enabled = true;

            //엔터시 바로 로그인
            txtPassword.EnterMoveNextControl = false;

            // 저장된 아이디 정보가 있으면 패스워드 포커스
            if (txtId.Text.Trim() != "")
                txtPassword.Focus();
            else
                txtId.Focus();

            idatDxComboBoxEdit1_SelectedIndexChanged(null, null);

            grdLookPlant.EditValue = Settings_IDAT.Default.PLANT;
        }

        /// <summary>
        /// 컨트롤 Validating 이벤트
        /// </summary>
        private void Control_Validating(object sender, CancelEventArgs e)
        {
            TextEdit con = sender as TextEdit;

            if (con.Text.Trim().Length == 0)
            {
                if (con.Name.ToLower() == "txtid")
                {
                    baseDxErrorProvider.SetError(con, BASE_Language.GetMessageString("MSG003"));
                }

                if (con.Name.ToLower() == "txtpassword")
                {
                    baseDxErrorProvider.SetError(con, BASE_Language.GetMessageString("MSG004"));
                }
            }
            else
            {
                baseDxErrorProvider.SetError(con, "", DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);
            }
        }
        
        #region [Private Method]

        private bool SetLogin()
        {
            if (grdLookPlant.EditValue + "" == "")
            {
                iDATMessageBox.WARNINGMessage(BASE_Language.GetMessageString("SELECTPLANT"), this.Text, 3);
                return false;
            }

            string Procname = "PKGSYS_USER.CHK_USER";
            Dictionary<string, object> param = new Dictionary<string, object>
            {
                { "A_CLIENT", Global.Global_Variable.CLIENT },
                { "A_COMPANY", Global.Global_Variable.COMPANY },
                { "A_PLANT", Global.Global_Variable.PLANT },
                { "A_SYSTEM", Global.Global_Variable.SYSTEMCODE },
                { "A_USER_ID", txtId.Text.Trim().Replace("\r\n", "") }
            };

            WSResults resultCls = BASE_db.Execute_Proc(Procname, 1, param);

            if (resultCls.ResultInt == 0)
            {
                DataSet ds = resultCls.ResultDataSet;

                try
                {
                    /// 사용자 정보가 Y인지 확인을 함.
                    if (ds.Tables[0].Rows[0]["USEFLAG"].ToString() == "Y")
                    {
                        if (new IDAT_Common.Security.Encryption().Decrypt(ds.Tables[0].Rows[0]["PASSWORD"].ToString()) == txtPassword.Text.Replace("\r\n", ""))
                        {
                            // 로그인이 성공하면 로그인 정보를 전역변수에 저장을 한다.
                            
                            // - 사원코드
                            Global.Global_Variable.EHRCODE = ds.Tables[0].Rows[0]["EHRCODE"] + "";

                            // - 사용자 코드
                            Global.Global_Variable.USER_ID = ds.Tables[0].Rows[0]["USERID"] + "";

                            // - 사용자 성명
                            Global.Global_Variable.USERNAMELOCAL = ds.Tables[0].Rows[0]["LOCUSERNAME"] + "";

                            // - 기존 MES  - 사용자 등급
                            Global.Global_Variable.USERROLE = ds.Tables[0].Rows[0]["USERROLE"] + "";

                            // - 기존 MES  - 경고메시지 표시여부
                            Global.Global_Variable.ALERTFLAG = ds.Tables[0].Rows[0]["ALERTFLAG"] + "";

                            // - 기존 MES  - 업데이트알림메시지 표시여부
                            Global.Global_Variable.UPDATEFLAG = ds.Tables[0].Rows[0]["UPDATEFLAG"] + "";

                            // - 기존 DEPT코드
                            Global.Global_Variable.DEPTCODE = ds.Tables[0].Rows[0]["DEPARTMENT"].ObjectNullString();

                            // - 기존 Position 코드
                            Global.Global_Variable.POSITION = ds.Tables[0].Rows[0]["POSITION"].ObjectNullString();
                                


                            //프린터 설정이 되어 있지 않으면 윈도우 기본 프린터로 설정 - 2011.09.06
                            if ((HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_Name.Trim() == "") && (new System.Drawing.Printing.PrintDocument().PrinterSettings.IsDefaultPrinter == true))
                                HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_Name = new System.Drawing.Printing.PrintDocument().PrinterSettings.PrinterName;

                            // Login 성공
                            return true;
                        }
                        else
                        {
                            iDATMessageBox.ErrorMessage(clsLan.GetMessageString("MSG006"), clsLan.GetMessageString("LOGIN"), 3, Global.Global_Variable.USER_ID, Procname, param);
                            // Login 실패
                            return false;
                        }
                    }
                    else
                    {
                        iDATMessageBox.ErrorMessage(BASE_Language.GetMessageString("MSG005"), clsLan.GetMessageString("LOGIN"), 3, Global.Global_Variable.USER_ID, Procname, param);
                        return false;
                    }
                }
                catch
                {
                    iDATMessageBox.ErrorMessage(BASE_Language.GetMessageString("MSG005"), clsLan.GetMessageString("LOGIN"), 3, Global.Global_Variable.USER_ID, Procname, param); 
                    return false;
                }
            }
            else
            {
                iDATMessageBox.ErrorMessage(BASE_Language.GetMessageString("MSG005"), clsLan.GetMessageString("LOGIN"), 3, Global.Global_Variable.USER_ID, Procname, param); 
                return false;
            }

        }

        // SSO 처리를 위해 로그인 메소드를 외부로 오픈
        public DialogResult AutoLogin(string UserID)
        {
            Settings_IDAT.Default.AutoLogin_User = UserID;

            return (SetAutoLogin() ? DialogResult.Yes : DialogResult.Cancel);
        }

        private bool SetAutoLogin()
        {
            if (grdLookPlant.EditValue + "" == "")
            {
                iDATMessageBox.WARNINGMessage(BASE_Language.GetMessageString("SELECTPLANT"), this.Text, 3);
                return false;
            }

            // 웹서비스 객체를 생성하고 오픈한다.
            WebServiceProcess ws = new WebServiceProcess();

            /// 프로시져 명 : PKG_DISP.GET_COLTYPE
            /// 각 컨트롤의 속성을 지정하기 위해 DB테이블의 속성정보를 가져온다.
            string Procname = "PKG_USER.GET_USERMASTER";
            Dictionary<string, object> param = new Dictionary<string, object>
            {
                { "A_CLIENT", Global.Global_Variable.CLIENT },
                { "A_COMPANY", Global.Global_Variable.COMPANY },
                { "A_PLANT", Global.Global_Variable.PLANT },
                { "A_SYSTEM", Global.Global_Variable.SYSTEMCODE },
                { "A_USER_ID", Settings_IDAT.Default.AutoLogin_User }
            };

            WSResults resultCls = ws.ExecuteProcCls(Procname, param);

            if (resultCls.ResultInt == 0)
            {
                DataSet ds = resultCls.ResultDataSet;

                try
                {
                    /// 사용자 정보가 Y인지 확인을 함.
                    //if (ds.Tables[0].Rows[0]["USEFLAG"].ToString() == "Y")
                    if (ds.Tables[0].Rows[0]["F_USERVALD"].ToString() == "T")
                    {
                        // 로그인이 성공하면 로그인 정보를 전역변수에 저장을 한다.

                        // - 사원코드
                        Global.Global_Variable.EHRCODE = ds.Tables[0].Rows[0]["EHRCODE"] + "";

                        // - 사용자 코드
                        Global.Global_Variable.USER_ID = ds.Tables[0].Rows[0]["USERID"] + "";
                        // - 사용자 성명
                        Global.Global_Variable.USERNAMELOCAL = ds.Tables[0].Rows[0]["LOCUSERNAME"] + "";
                        //  기존 MES  - 사용자 등급
                        Global.Global_Variable.USERROLE = ds.Tables[0].Rows[0]["USERROLE"] + "";

                        // - 기존 MES  - 경고메시지 표시여부
                        Global.Global_Variable.ALERTFLAG = ds.Tables[0].Rows[0]["ALERTFLAG"] + "";

                        // - 기존 MES  - 업데이트알림메시지 표시여부
                        Global.Global_Variable.UPDATEFLAG = ds.Tables[0].Rows[0]["UPDATEFLAG"] + "";

                        //프린터 설정이 되어 있지 않으면 윈도우 기본 프린터로 설정 - 2011.09.06
                        if ((HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_Name.Trim() == "") && (new System.Drawing.Printing.PrintDocument().PrinterSettings.IsDefaultPrinter == true))
                            HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_Name = new System.Drawing.Printing.PrintDocument().PrinterSettings.PrinterName;

                        return true;
                    }
                    else
                    {
                        iDATMessageBox.ErrorMessage(clsLan.GetMessageString("MSG005"), clsLan.GetMessageString("LOGIN"), 3, Global.Global_Variable.USER_ID, Procname, param);
                        return false;
                    }
                }
                catch
                {
                    iDATMessageBox.ErrorMessage(clsLan.GetMessageString("MSG005"), clsLan.GetMessageString("LOGIN"), 3, Global.Global_Variable.USER_ID, Procname, param);
                    return false;
                }
            }
            else
            {
                iDATMessageBox.ErrorMessage(clsLan.GetMessageString("MSG005"), clsLan.GetMessageString("LOGIN"), 3, Global.Global_Variable.USER_ID, Procname, param);
                return false;
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
            this.layoutControl1.Enabled = true;
            this.Controls.Remove(sender as Control);
            txtPassword.Text = pass;
        }

        /// xuc_chp[비밀번호 변경창 컨트롤]에 관련된 이벤트입니다.
        /// <summary>
        /// 비밀번호 변경창에서 Cancel버튼을 누르면 발생되는 이벤트 입니다.
        /// </summary>
        /// <param name="sender">비밀번호 변경창 컨트롤</param>
        void xuc_chp_CancelEvent(object sender)
        {
            this.layoutControl1.Enabled = true;
            this.Controls.Remove(sender as Control);
        }

        #endregion

        #region [버튼 클릭 이벤트]

        /// <summary>
        /// 로그인 버튼 클릭 이벤트
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            baseDxErrorProvider.ClearErrors();
            ValidateChildren(ValidationConstraints.Visible);

            // 언어를 저장합니다. -- 이부분은 추후에 언어 설정에서 사용하도록 합니다.
            Settings_IDAT.Default.Language = comLanguage.EditValue + "";
            Settings_IDAT.Default.PLANT = grdLookPlant.EditValue.ObjectNullString();

            Settings_IDAT.Default.Save();

            if (!baseDxErrorProvider.HasErrors)
            {
                // 유효성 검사에서 에러가 발생하지 않으면 로그인을 수행합니다.
                if (SetLogin())
                {
                    //IDAT_WebService.clsDataSetStruct resultCls = null;

                    if (chkSaveID.Checked)
                    {
                        // 로그인 아이디 정보를 저장합니다.
                        Settings_IDAT.Default.Login = txtId.Text.Replace("\r\n", ""); ;
                        Global.Global_Variable.EHRCODE = txtId.Text.Replace("\r\n", "");

                    }
                    else
                    {   // 로그인 아이디 정보를 저장합니다.
                        Settings_IDAT.Default.Login = "";
                    }

                    Settings_IDAT.Default.Save();

                    //if ((chkSavePass.Checked))
                    //{
                    //    // 로그인 패스워드 정보를 저장합니다.
                    //    Settings_IDAT.Default.Login_Pass = txtPassword.Text;
                    //}
                    //else
                    //{
                    //    Settings_IDAT.Default.Login_Pass = "";
                    //}

                    // 로그인 성공시에 Yes
                    DialogResult = DialogResult.Yes;
                }
            }
        }

        /// <summary>
        /// 취소 버튼 클릭 이벤트
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        /// <summary>
        /// 엔터시 바로 로그인
        /// </summary>
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            this.btnLogin_Click(this, null);
        }

        private void COMLOGIN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void idatDxComboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comLanguage.EditValue.ObjectNullString().ToUpper() == "LOCAL"))
            {
                switch (Application.CurrentCulture.Name.ToUpper())
                {
                    case "KO-KR":
                        layoutControlItem9.Text = "아이디";
                        layoutControlItem10.Text = "비밀번호";
                        btnLogin.Text = "로그인";
                        chkSaveID.Text = "아이디 저장";
                        btnCancel.Text = "취소";
                        break;
                    case "EN-US":
                        layoutControlItem9.Text = "User ID";
                        layoutControlItem10.Text = "Password";
                        btnLogin.Text = "Login";
                        chkSaveID.Text = "Save User ID";
                        btnCancel.Text = "Cancel";
                        break;
                    case "ZH-CN":
                        layoutControlItem9.Text = "用户ID";
                        layoutControlItem10.Text = "密码";
                        btnLogin.Text = "登录";
                        chkSaveID.Text = "保存用户ID";
                        btnCancel.Text = "取消";
                        break;
                    default :
                        layoutControlItem9.Text = "User ID";
                        layoutControlItem10.Text = "Password";
                        btnLogin.Text = "Login";
                        chkSaveID.Text = "Save User ID";
                        btnCancel.Text = "Cancel";
                        break;

                }
            }
            else
            {
                switch (comLanguage.EditValue.ObjectNullString().ToUpper())
                {
                    case "KOREAN":
                        layoutControlItem9.Text = "아이디";
                        layoutControlItem10.Text = "비밀번호";
                        btnLogin.Text = "로그인";
                        chkSaveID.Text = "아이디 저장";
                        btnCancel.Text = "취소";
                        break;
                    case "ENGLISH":
                        layoutControlItem9.Text = "User ID";
                        layoutControlItem10.Text = "Password";
                        btnLogin.Text = "Login";
                        chkSaveID.Text = "Save User ID";
                        btnCancel.Text = "Cancel";
                        break;
                    case "CHINESE":
                        layoutControlItem9.Text = "用户ID";
                        layoutControlItem10.Text = "密码";
                        btnLogin.Text = "登录";
                        chkSaveID.Text = "保存用户ID";
                        btnCancel.Text = "取消";
                        break;
                    default:
                        layoutControlItem9.Text = "User ID";
                        layoutControlItem10.Text = "Password";
                        btnLogin.Text = "Login";
                        chkSaveID.Text = "Save User ID";
                        btnCancel.Text = "Cancel";
                        break;
                }
            }
        }

        private void grdLookPlant_EditValueChanged(object sender, EventArgs e)
        {
            Settings_IDAT.Default.PLANT = grdLookPlant.EditValue.ObjectNullString();
            Global.Global_Variable.PLANT = grdLookPlant.EditValue.ObjectNullString();
            Settings_IDAT.Default.Save();
        }

        #region Scan Event
        public void Data_Scan(string sType, string sData)
        {
            ProcessScanEvent(sType, sData);
        }

        public void Data_SubScan(string sType, string sData)
        {
            ProcessScanEvent(sType, sData);
        }

        private void ProcessScanEvent(string sType, string sData)
        {
            if (sType == "WORKER")
            {
                txtId.EditValue = sData;
                txtPassword.EditValue = sData;
                this.btnLogin_Click(this, null);
            }
            //string[] strSplit = sData.Split(new string[] { "PASS" }, StringSplitOptions.None);

            //if (strSplit.Length == 2)
            //{
            //    txtId.EditValue = strSplit[0];
            //    txtPassword.EditValue = strSplit[1];
            //    this.btnLogin_Click(this, null);
            //}
            
        }

        #endregion
    }
}
