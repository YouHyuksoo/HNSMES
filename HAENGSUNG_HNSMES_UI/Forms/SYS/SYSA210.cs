using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HAENGSUNG_HNSMES_UI.Forms.SYS
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : SYSA210<br/>
    ///      기능 : 직위 마스터 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    public partial class SYSA210 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {
        // ******************************************* Base From Class ************************************
        // BASE_clsDevexpressGridUtil          DevExpress Grid 관련 Util Class.
        // BASE_db;                            웹서비스 DB처리 관련 Util Class.
        // BASE_DXGridHelper;                  DevExpress GridControl 데이터 Bind관련 Class
        // BASE_DXGridLookUpHelper;            DevExpress GridLookUp 데이터 Bind관련 Class
        // BASE_IDATLayoutUtil;                DevExpress LayoutControl Util Class.
        // BASE_Language;                      Language Util. ex) BASE_Language.GetMessageString("Code") 
        // ************************************************************************************************
        public SYSA210()
        {
            InitializeComponent();
        }

        #region 생성
        
        private void SYSA210_Load(object sender, EventArgs e)
        {

        }
        private void SYSA210_Shown(object sender, EventArgs e)
        {
            MainButton_INIT.PerformClick();
        }
        

        #endregion 


        #region 버튼이벤트

        public void InitButton_Click()
        {
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);

            this.GetGridViewList();
        }

        public void NewButton_Click()
        {
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New);

            gvList.EX_AddNewRow();
            rdgUseFlag.SelectedIndex = 0;

            txtPosition.Focus();
        }

        public void EditButton_Click()
        {
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit);
        }


        public void SaveButton_Click()
        {
            // 저장전에 필수 항목에 대한 Null 값을 초기화 합니다.
            // 유효성검사 다시 수행
            base.baseDxErrorProvider.ClearErrors();
            ValidateChildren(ValidationConstraints.Visible);

            // 유효성 검사를 한다.
            if (base.baseDxErrorProvider.HasErrors)
                return;

            string _strClient = "";
            string _strPost = "";
            string _strPostName = "";
            string _strUseflag = "";

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

                            _strClient = Global.Global_Variable.CLIENT;
                            _strPost = _dr["POSITION"].ObjectNullString();
                            _strPostName = _dr["POSITIONNAME"].ObjectNullString();
                            _strUseflag = _dr["USEFLAG"].ObjectNullString();

                            if (!this.SaveData(_strClient, _strPost, _strPostName, _strUseflag, "N"))
                            {
                                MainButton_INIT.PerformClick();
                                //마지막 처리 된 값쪽에 포커스를 이동 시킵니다. 사용시에 주석을 해제하고 수정하세요.
                                gvList.EX_GetFocuseRowCell("POSITION", _strPost);
                                return;
                            }

                            break;

                        default:
                            break;
                    }
                }

                MainButton_INIT.PerformClick();

                //마지막 처리 된 값쪽에 포커스를 이동 시킵니다. 사용시에 주석을 해제하고 수정하세요.
                gvList.EX_GetFocuseRowCell("POSITION", _strPost);
            }

            else if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
            {
                // ***** 신규 관련 프로시져를 여기에 구현을 합니다.
                _strClient = Global.Global_Variable.CLIENT;
                _strPost = txtPosition.EditValue.ObjectNullString();
                _strPostName = txtPositionName.EditValue.ObjectNullString();
                _strUseflag = rdgUseFlag.EditValue.ObjectNullString();

                if (!this.SaveData(_strClient, _strPost, _strPostName, _strUseflag, "Y"))
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

        public void StopButton_Click()
        {
        }

        public void SearchButton_Click()
        {
        }

        public void PrintButton_Click()
        {
        }

        public void RefreshButton_Click()
        {
            GetGridViewListRefresh();
        }

        public void DeleteButton_Click()
        {
        }


        #endregion

        #region 함수
        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid( gcList
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
                                       , true
                                       , "POSITION, POSITIONNAME, USEFLAG" 
                                       );

            gvList.BestFitColumns();
        }

        private void GetGridViewListRefresh()
        {
            BASE_DXGridHelper.Refresh_Grid( gcList
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
                                          , true
                                          , "POSITION, POSITIONNAME, USEFLAG"
                                          );
        }

        private void GetClient()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( idatDxGridLookUpEdit_Client
                                                       , "PKGSYS_COMM.GET_CLIENT"
                                                       , 1
                                                       , new string[] { }
                                                       , new string[] { }
                                                       , "CLIENT"
                                                       , "CLIENTNAME"
                                                       , "CLIENTNAME, CLIENT, REMARKS"
                                                       );
        }

        /// <summary>
        /// 직위코드를 등록합니다.
        /// </summary>
        /// <returns>.
        /// </returns>
        private bool SaveData(string p_strClient, string p_strPost, string p_strPostName, string p_strUseflag, string p_strNewFlag)
        {
            bool _blReturn = BASE_db.Execute_Proc( "PKGSYS_USER.PUT_POST"
                                                 , 1
                                                 , new string[] { 
                                                   "A_CLIENT"
                                                 , "A_COMPANY"
                                                 , "A_PLANT"
                                                 , "A_POST"
                                                 , "A_POSTNAME"
                                                 , "A_USEFLAG"
                                                 , "A_NEWFLAG" }
                                                 , new string[] {
                                                   Global.Global_Variable.CLIENT
                                                 , Global.Global_Variable.COMPANY
                                                 , Global.Global_Variable.PLANT
                                                 , p_strPost
                                                 , p_strPostName
                                                 , p_strUseflag
                                                 , p_strNewFlag }
                                                 , true
                                                 );

            return _blReturn;
        }
        #endregion

        private void gvList_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            // 수정된 항목을 그리드에 표시하는 기능을 하지 않을려면 주석 처리를 하세요.

            DataTable changes = BASE_clsDevexpressGridUtil.GetChangedData(gcList, DataRowState.Modified);

            if (changes == null)
                return;

            if (e.RowHandle < 0)
                return;

            // 수정된 키값 필드를 입력한다.
            foreach (DataRow dr in changes.Rows)
            {
                if (dr["POSITION"] != null)
                {
                    // 주키가 두개일 경우 AND 문으로 조건을 다중으로 준다.
                    if (dr["POSITION"].ToString() == gvList.GetDataRow(e.RowHandle)["POSITION"].ToString())
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
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
    }
}