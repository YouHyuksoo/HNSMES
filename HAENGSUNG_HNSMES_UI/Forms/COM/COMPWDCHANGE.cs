using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using HAENGSUNG_HNSMES_UI.Class;
using IDAT_Common.Security;
using IDAT.WebService;
using HAENGSUNG_HNSMES_UI.WebService.Access;

namespace HAENGSUNG_HNSMES_UI.Forms.COM
{
    public partial class COMPWDCHANGE : BASE.Form
    {
        #region [Member Variable & Property]

        private string m_sUserId = "";

        /// <summary>
        /// 사용자 아이디를 설정하거 가져옵니다.
        /// </summary>
        public string SUserId
        {
            get { return m_sUserId; }
            set { m_sUserId = value; }
        }

        private string m_password = "";

        /// <summary>
        /// 사용자의 변경된 비밀번호를 설정하거나 가져옵니다.
        /// </summary>
        public string Password
        {
            get { return m_password; }
            set { m_password = value; }
        }

        #endregion

        #region [생성자 & Load 이벤트]

        /// <summary>
        /// 생성자
        /// </summary>
        public COMPWDCHANGE()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="userID">사용자 아이디</param>
        public COMPWDCHANGE(string userID)
            : this()
        {
            SUserId = userID;
        }

        /// <summary>
        /// Control_Load Event
        /// </summary>
        private void COMPWDCHANGE_Load(object sender, EventArgs e)
        {
            // 컨트롤 위치를 부모폼 기준으로 가운데로 위치시킨다.
            //Common.ShowCenter(this.Parent as Form, this);

            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(9, 9, 20, 9);
            this.BringToFront();
        }

        #endregion

        #region [Control Validate Event]

        private void txt_Validating(object sender, CancelEventArgs e)
        {
            Control con = sender as Control;
            if (con.Text.Length == 0)
            {
                dxErrorProvider.SetError(con, BASE_Language.GetMessageString("MSG002"));
            }
            else
            {
                dxErrorProvider.SetError(con, "", DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);

                // 각 텍스트 박스의 유효성을 검사합니다.
                switch (con.Name)
                {
                    // 패스워드가 사용자 정보와 일치하는지 확인을 합니다.
                    case "txtCurrent":
                        if (txtCurrent.Text != GetPassword(SUserId))
                        {

                            dxErrorProvider.SetError(con, BASE_Language.GetMessageString("MSG006"));
                        }
                        else
                        {
                            dxErrorProvider.SetError(con, "", DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);
                        }
                        break;
                    case "txtRepeat":
                        if (txtChange.Text != txtRepeat.Text)
                        {
                            dxErrorProvider.SetError(con, BASE_Language.GetMessageString("MSG009"));
                        }
                        else
                        {
                            dxErrorProvider.SetError(con, "", DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        #endregion

        /// 1. 사용자의 비밀번호정보를 가져옵니다.
        #region [Private Method]

        /// <summary>
        /// 사용자의 비밀번호정보를 가져옵니다.
        /// </summary>
        /// <param name="userId">사용자 아이디</param>
        /// <returns>비밀번호</returns>
        private string GetPassword(string userId)
        {
            /// 프로시져 명 : PKG_DISP.GET_COLTYPE
            /// 각 컨트롤의 속성을 지정하기 위해 DB테이블의 속성정보를 가져온다.
            DataSet _ds = BASE_db.Get_DataBase(
                                                "PKGSYS_USER.CHK_USER"
                                                , 1
                                                , new string[] { 
                                                                  "A_CLIENT"
                                                                , "A_COMPANY"
                                                                , "A_PLANT"
                                                                , "A_SYSTEM"
                                                                , "A_USER_ID"
                                                               }
                                                , new string[] {
                                                                  Global.Global_Variable.CLIENT
                                                                , Global.Global_Variable.COMPANY
                                                                , Global.Global_Variable.PLANT
                                                                , Global.Global_Variable.SYSTEMCODE
                                                                , userId
                                                               }
                                             );

            if (_ds == null)
                return "";

            if (_ds.Tables.Count < 0)
                return "";
            else
            {
                if (_ds.Tables[0].Rows.Count <= 0)
                    return "";
                else
                {
                    return new IDAT_Common.Security.Encryption().Decrypt(_ds.Tables[0].Rows[0]["PASSWORD"].ToString());
                }
            }
        }

        #endregion


        /// 1. 변경
        /// 2. 취소
        #region [Button Evnet]

        /// [1]
        /// <summary>
        /// 버튼 변경 클릭 이벤트
        /// </summary>
        private void btnChange_Click(object sender, EventArgs e)
        {
            dxErrorProvider.ClearErrors();
            ValidateChildren();

            // 유효성 검사가 완료 되면 Password속성에 변경된 암호를 저장한다.
            if (!dxErrorProvider.HasErrors)
            {
                WSResults clsDataSet = BASE_db.Execute_Proc(
                                                "PKGSYS_USER.PUT_DEFAULTPWD"
                                                , 1
                                                , new string[] {
                                                                  "A_CLIENT"
                                                                , "A_COMPANY"
                                                                , "A_PLANT"
                                                                , "A_USERID"         
                                                                , "A_PWD"
                                                                , "A_EDTUSER"
                                                               }
                                                , new string[] {
                                                                  Global.Global_Variable.CLIENT
                                                                , Global.Global_Variable.COMPANY
                                                                , Global.Global_Variable.PLANT
                                                                , SUserId
                                                                , new IDAT_Common.Security.Encryption().Encrypt(this.txtChange.Text)
                                                                , Global.Global_Variable.USER_ID
                                                               }
                                               );

                if (clsDataSet.ResultInt != 0)
                {
                    Class.iDATMessageBox.ErrorMessage(clsDataSet.ResultString, BASE_Language.GetMessageString("Error"), 5);
                }
                else
                {
                    Password = txtChange.Text;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        }

        /// [2]
        /// <summary>
        /// 취소버튼 클릭 이벤트
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            dxErrorProvider.ClearErrors();
            //ValidateChildren();

            Password = "";
            //CancelEvent(this);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        #endregion
    }
}
