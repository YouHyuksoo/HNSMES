using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HAENGSUNG_HNSMES_UI.WebService.Access;
using HAENGSUNG_HNSMES_UI.Class;
using GridAlias = DevExpress.XtraGrid.Views.Grid;

namespace HAENGSUNG_HNSMES_UI.Forms.SYS
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : SYSA208<br/>
    ///      기능 : 회사 마스터 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    public partial class SYSA208 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
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

        public SYSA208()
        {
            InitializeComponent();
        }

        private void SYSA208_Shown(object sender, EventArgs e)
        {
            MainButton_INIT.PerformClick();
        }

        #endregion

        #region [Button Event]

        public void InitButton_Click()
        {
            // 초기화 관련 구현은 여기에 구현 ***
            // 상세 항목들을 모두 클리어 한다.
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);
            initClient();                              // 법인 코드 표시 (우측 상세 영역 내 세번째 GridLookUpEdit 내에 표시)
            GetCompany();
            txtCompany.Enabled = true;
        }

        public void NewButton_Click()
        {

            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New);

            // 그리드뷰에 새로운 행과 초기값을 지정한다.
            BASE_clsDevexpressGridUtil.AddNewRow(gvList, new string[] { "USEFLAG"}, new string[] { "Y" });
            //gvList.FocusedRowHandle = gvList.RowCount - 1;
            rdgUseFlag.SelectedIndex = 0;
            grdLookUpClient.EditValue = "IDIF";

            txtCompany.Focus();

        }

        public void EditButton_Click()
        {
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit);
            txtCompany.Enabled = false;
        }

        public void StopButton_Click()
        {
            
        }

        public void SearchButton_Click()
        {
            GetCompany();
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
            string strCompany = "";
            string strCompanyName;
            string strClient;
            string strUseFlag;
            string strRemarks;
            string strUserID;

            // 납품처 정보 수정
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
                            strCompany = dr["COMPANY"].ToString();
                            strCompanyName = dr["COMPANYNAME"].ToString();
                            strClient = grdLookUpClient.Text;
                            strUseFlag = dr["USEFLAG"].ToString();
                            strRemarks = dr["REMARKS"].ToString();
                            strUserID = Global.Global_Variable.EHRCODE;

                            SaveData(strClient, strCompany, strCompanyName, strUseFlag, strRemarks, strUserID);
                            break;

                        default:
                            break;
                    }
                }

                MainButton_INIT.PerformClick();
                gvList.EX_GetFocuseRowCell("COMPANY", strCompany);

            }

            // 납품처 정보 등록
            else
            {
                strCompany = txtCompany.Text;
                strCompanyName = txtCompanyName.Text;
                strClient = grdLookUpClient.Text;
                strUseFlag = rdgUseFlag.EditValue + "";
                strRemarks = txtRemarks.Text;
                strUserID = Global.Global_Variable.EHRCODE;

                SaveData(strClient, strCompany, strCompanyName, strUseFlag, strRemarks, strUserID);
                MainButton_INIT.PerformClick();
                MainButton_New.PerformClick();

                //마지막 처리 된 값쪽에 포커스를 이동 시킵니다. 사용시에 주석을 해제하고 수정하세요.
                gvList.EX_GetFocuseRowCell("COMPANY", strCompany);

            }
        }

        public void PrintButton_Click()
        {
            
        }

        public void RefreshButton_Click()
        {
            
        }

        public void DeleteButton_Click()
        {

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


        #endregion

        #region [Private Method]

        // 법인코드 리스트 표시 (우측 상세 영역 내 세번째 GridLookUpEdit 내에 표시)
        private void initClient()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( grdLookUpClient
                                                       , "PKGSYS_COMM.GET_CLIENT"
                                                       , 1
                                                       , new string[] { }
                                                       , new string[] { }
                                                       , "CLIENT"
                                                       , "CLIENT"
                                                       , "CLIENT, CLIENTNAME"
                                                       );


        }


        // 사업부 마스터 조회 
        private void GetCompany()
        {
            BASE_DXGridHelper.Bind_Grid( gcList
                                       , "PKGSYS_COMM.GET_COMPANY"
                                       , 1
                                       , new string[] {  }
                                       , new string[] {  }
                                       , true
                                       );

            //// 컬럼 조절
            gvList.OptionsView.ColumnAutoWidth = true;
            gvList.BestFitColumns();

            //gvList.BestFitColumns();

            //gvList.Columns[0].Width = 250;
            //gvList.Columns[1].Width = 300;
            //gvList.Columns[2].Width = 300;
            //gvList.Columns[3].Width = 300;
            //gvList.Columns[4].Width = 250;

            //// 불필요한 컬럼 숨기기 처리
            //gvList.OptionsView.ColumnAutoWidth = false;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// 사업부 마스터 정보 등록시에 사용자 권한 코드 데이터 중복을 확인하고 유효성 검사후에 
        /// 납품처 정보를 등록 또는 수정 합니다.
        /// </returns>
        private void SaveData(string client, string company, string companyname, string useflag, string remarks, string userid)
        {

            bool result = BASE_db.Execute_Proc( "PKGSYS_COMM.PUT_COMPANY"
                                              , 1
                                              , new string[] { 
                                                "A_CLIENT"
                                              , "A_COMPANY"
                                              , "A_COMPANYNAME"
                                              , "A_USEFLAG"
                                              , "A_REMARKS"
                                              , "A_USERID" }
                                              , new string[] { 
                                                client
                                              , company
                                              , companyname
                                              , useflag
                                              , remarks
                                              , userid }
                                              , true
                                              );

            if (result == true)
            {
                if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit)
                {
                    iDATMessageBox.OKMessage("사업부 정보가 수정 되었습니다.", this.Text, 3);
                }

                else
                {
                    iDATMessageBox.OKMessage("사업부 정보가 등록 되었습니다.", this.Text, 3);
                }
            }
        }

        #endregion

    }
}
