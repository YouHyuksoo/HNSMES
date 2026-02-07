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
//using Google.API.Translate;
using IDAT_Common.Utility;

namespace HAENGSUNG_HNSMES_UI.Forms.SYS
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : SYSA201<br/>
    ///      기능 : 용어 마스터 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    public partial class SYSA201 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
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
        public SYSA201()
        {
            InitializeComponent();
        }

        private void SYSA201_Load(object sender, EventArgs e)
        {

        }
        private void SYSA201_Shown(object sender, EventArgs e)
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

        public void DeleteButton_Click()
        {
            string p_strGlsrDle = txtGlossaryGlsr.EditValue.ObjectNullString();

            BASE_db.Execute_Proc( "PKGSYS_COMM.DEL_GLOSSARY"
                                , 1
                                , new string[] { 
                                  "A_SYSTEM"
                                , "A_GLSR" }
                                , new string[] { 
                                  Global.Global_Variable.SYSTEMCODE
                                , p_strGlsrDle }
                                , true
                                );

            MainButton_INIT.PerformClick();
        }
        
        public void NewButton_Click()
        {
            // 신규 항목을 추가하기전에 기존에 수정된 데이터를 저장하고 신규 추가를 한다.
            //this.SaveButton_Click();
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New);
            gvList.EX_AddNewRow();

            txtGlossaryGlsr.Focus();
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
            {
                return;
            }

            string _strGlsr = "";
            string _strKorGlsr;
            string _strEngGlsr;
            string _strNatGlsr;
            string _strRemarks;

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

                //// 변경된 데이터를 루프를 통해 하나씩 빼낸다.
                foreach (DataRow _dr in _dt.Rows)
                {
                    switch (_dr.RowState)
                    {
                        case DataRowState.Modified:
                            _strGlsr = _dr["GLSR"].ObjectNullString();
                            _strKorGlsr = _dr["KORGLSR"].ObjectNullString();
                            _strEngGlsr = _dr["ENGGLSR"].ObjectNullString();
                            _strNatGlsr = _dr["NATGLSR"].ObjectNullString();
                            _strRemarks = _dr["REMARKS"].ObjectNullString();

                            if (!this.SaveData(_strGlsr, _strKorGlsr, _strEngGlsr, _strNatGlsr, _strRemarks, "N"))
                                return;
                            break;

                        default:
                            break;
                    }
                }

                MainButton_INIT.PerformClick();

                //마지막 처리 된 값쪽에 포커스를 이동 시킵니다. 사용시에 주석을 해제하고 수정하세요.
                gvList.EX_GetFocuseRowCell("GLSR", _strGlsr);
            }

            else if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
            {
                // ***** 신규 관련 프로시져를 여기에 구현을 합니다.

                _strGlsr = txtGlossaryGlsr.Text.Trim().ObjectNullString();
                _strKorGlsr = txtGlossaryKorGlsr.Text.Trim().ObjectNullString();
                _strEngGlsr = txtGlossaryEnglishGlsr.Text.Trim().ObjectNullString();
                _strNatGlsr = txtGlossaryNATGLSR.Text.Trim().ObjectNullString();
                _strRemarks = txtGlossaryRemarks.Text.Trim().ObjectNullString();

                if (!this.SaveData(_strGlsr, _strKorGlsr, _strEngGlsr, _strNatGlsr, _strRemarks, "Y"))
                    return;
                // 신규 항목 데이터를 처리하면 그리드를 리프레쉬 합니다.
                MainButton_INIT.PerformClick();
                MainButton_New.PerformClick();

            }

            BASE_Language.SetLanguage();
        }

        public void PrintButton_Click()
        {

        }

        public void RefreshButton_Click()
        {
        }

        public void StopButton_Click()
        {
        }

        public void SearchButton_Click()
        {
        }

        #endregion

        #region 함수

        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid( gcList
                                       , "PKGSYS_COMM.GET_GLOSSARY"
                                       , 1
                                       , new string[] { 
                                         "A_SYSTEM" }
                                       , new string[] {
                                         Global.Global_Variable.SYSTEMCODE }
                                       , true
                                       );

            //gvList.Columns["GLSR"].Visible = false;
            gvList.BestFitColumns();
        }

        /// <summary>
        /// 용어를 등록합니다.
        /// </summary>
        /// <param name="p_Glsr"></param>
        /// <param name="p_KorGlsr"></param>
        /// <param name="p_EngGlsr"></param>
        /// <param name="p_CHNGLSR"></param>
        /// <param name="p_Remarks"></param>
        private bool SaveData( string p_Glsr, string p_KorGlsr, string p_EngGlsr, string p_NATGLSR, string p_Remarks, string p_strNewFlag)
        {
            bool _blReturn = BASE_db.Execute_Proc( "PKGSYS_COMM.PUT_GLOSSARY"
                                                 , 1
                                                 , new string[] { 
                                                   "A_SYSTEM"
                                                 , "A_GLSR"
                                                 , "A_KORGLSR"
                                                 , "A_ENGGLSR"
                                                 , "A_NATGLSR"
                                                 , "A_REMARKS"
                                                 , "A_USER"
                                                 , "A_NEWFLAG" }
                                                 , new string[] {
                                                   Global.Global_Variable.SYSTEMCODE
                                                 , p_Glsr
                                                 , p_KorGlsr
                                                 , p_EngGlsr
                                                 , p_NATGLSR
                                                 , p_Remarks
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
                if (dr["GLSR"] != null)
                {
                    // 주키가 두개일 경우 AND 문으로 조건을 다중으로 준다.
                    if (dr["GLSR"].ToString() == gvList.GetDataRow(e.RowHandle)["GLSR"].ToString())
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
            }
        }

        #endregion

        

        

        

        
    }
}
