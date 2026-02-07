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


namespace HAENGSUNG_HNSMES_UI.Forms.COM
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : COMREGISTER<br/>
    ///      기능 : 사용자 등록 및 수정 <br/>
    ///      작성 : 남경필<br/>
    ///최초작성일 : 2011-02-01<br/>
    ///==========================================================
    ///</summary>
    public partial class COMREGISTER : BASE.Form
    {
        #region 전역변수

        private string m_strEhrCode;

        #endregion

        #region 생성

        public COMREGISTER(string p_strEhrCode)
        {
            InitializeComponent();
            
            m_strEhrCode = p_strEhrCode;
        }

        private void COMREGISTER_Load(object sender, EventArgs e)
        {
            this.Set_Init();

            this.Set_Data(m_strEhrCode);
        }

        #endregion

        #region 버튼 이벤트

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string _strUserClass = gleUserClass.Text.Trim() + "";
            string _strUserNameLocal = txtUserNameLocal.Text.Trim() + "";

            SaveData(_strUserClass, _strUserNameLocal);

            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region 함수

        private void SaveData(string p_strUserClass, string p_strUserNameLocal)
        {
            BASE_db.Execute_Proc(
                                "PKG_USER.SET_USERMASTER"
                                , 1
                                , new string[] {
                                                  "A_CLIENT"
                                                , "A_COMPANY"
                                                , "A_PLANT"
                                                , "A_USERID"         
                                                , "A_USERNM"
                                               }
                                , new string[] {
                                                  Global.Global_Variable.CLIENT
                                                , Global.Global_Variable.COMPANY
                                                , Global.Global_Variable.PLANT
                                                , Global.Global_Variable.USER_ID
                                                , this.txtUserNameLocal.Text
                                               }
                                , true
                               );
        }

        private void Set_ReadOnly(bool p_bln)
        {
            gleUserClass.Properties.ReadOnly = p_bln;
        }     

        private void Set_Data(string p_strEhrCode)
        {

            if (p_strEhrCode + "" == "")
            {
                this.Set_ReadOnly(false);
                return;
            }

            DataSet _ds = BASE_db.Get_DataBase(
                                                "PKG_USER.GET_USERMASTER"
                                                , 1
                                                , new string[] {
                                                                  "A_CLIENT"
                                                                , "A_COMPANY"
                                                                , "A_PLANT"
                                                                , "A_USERID"
                                                                , "A_ALLVIEW"
                                                               }
                                                , new string[] {
                                                                  Global.Global_Variable.CLIENT
                                                                , Global.Global_Variable.COMPANY
                                                                , Global.Global_Variable.PLANT
                                                                , p_strEhrCode
                                                                , "Y"
                                                               }
                                             );

            if (_ds == null)
                return;
            DataRow _dr = _ds.Tables[0].Rows[0];

            gleUserClass.Text = _dr["USERCLASSCODE"] + "";
            txtUserNameLocal.Text = _dr["USERNAME"] + "";
            this.txtPassword.Text = (_dr["PASSWORD"] + "");

            this.Set_ReadOnly(true);
        }

        private void Set_Init()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(
                                           gleUserClass
                                         , "PKG_USER.GET_USERCLASS2"
                                         , 1
                                         , new string[] {
                                                           "A_CLIENT"
                                                         , "A_COMPANY"
                                                         , "A_PLANT"
                                                         , "A_VIEW" 
                                                        }
                                         , new string[] {
                                                            Global.Global_Variable.CLIENT
                                                          , Global.Global_Variable.COMPANY
                                                          , Global.Global_Variable.PLANT
                                                          , "0" 
                                                        }
                                         , "USERCLASSCODE"
                                         , "USERCLASSNAME"
                                         , "USERCLASSCODE, USERCLASSNAME"
                                        );

            this.txtPassword.Properties.ReadOnly = true;
        }

        private void btn_ChangePW_Click(object sender, EventArgs e)
        {
            layoutControlGroup1.Enabled = false;
            try
            {
                COM.COMPWDCHANGE chPwd = new COM.COMPWDCHANGE(Global.Global_Variable.USER_ID);

                if (chPwd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    this.txtPassword.Text = chPwd.Password;
            }
            catch (Exception)
            {
            }
            finally
            {
                layoutControlGroup1.Enabled = true;
            }
        }    

        #endregion

    }
}
