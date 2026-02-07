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
using DevExpress.XtraGrid.Views.Grid;
using HAENGSUNG_HNSMES_UI.Global;
using HAENGSUNG_HNSMES_UI;

namespace HAENGSUNG_HNSMES_UI.Forms.MST
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : MSTA204<br/>
    ///      기능 : 사유 마스터 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    public partial class MSTA204 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
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

        public MSTA204()
        {
            InitializeComponent();
        }

        private void MSTA204_Load(object sender, EventArgs e)
        {
        
        }
        private void MSTA204_Shown(object sender, EventArgs e)
        {
            //MainButton_INIT.PerformClick();
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
        
        public void NewButton_Click()
        {
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New);

            gvList.EX_AddNewRow();
            rdgReasonType.EditValue = rdgReason.EditValue;
            rdgUseFlag.SelectedIndex = 0;

            txtReasonCode.Focus();
        }

        public void EditButton_Click()
        {
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit);
        }

        public void StopButton_Click()
        {
        }

        public void SearchButton_Click()
        {
            this.GetGridViewList();
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

            string _strreasonCode = "";
            string _strreason = "";
            string _strdispSeq = "";
            string _strreasonType = "";
            string _strUseFlag = "";
            string _strRemarks = "";

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
                            _strreasonCode = _dr["REASONCODE"] + "";
                            _strreason = _dr["REASON"] + "";
                            _strdispSeq = _dr["DISPSEQ"] + "";
                            _strreasonType = _dr["REASONTYPE"] + "";
                            _strUseFlag = _dr["USEFLAG"] + "";
                            _strRemarks = _dr["REMARKS"] + "";

                            if (!this.SaveData(_strreasonCode, _strreason, _strdispSeq, _strreasonType, _strUseFlag, _strRemarks, "N"))
                            {
                                MainButton_INIT.PerformClick();
                                //마지막 처리 된 값쪽에 포커스를 이동 시킵니다. 사용시에 주석을 해제하고 수정하세요.
                                gvList.EX_GetFocuseRowCell("REASONCODE", _strreasonCode);
                                return;
                            }

                            break;

                        default:
                            break;
                    }
                }
                
                MainButton_INIT.PerformClick();
                //마지막 처리 된 값쪽에 포커스를 이동 시킵니다. 사용시에 주석을 해제하고 수정하세요.
                gvList.EX_GetFocuseRowCell("REASONCODE", _strreasonCode);
            }
            else if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
            {
                // ***** 신규 관련 프로시져를 여기에 구현을 합니다.
                _strreasonCode = txtReasonCode.Text.Trim();
                _strreason = txtReason.Text.Trim();
                _strdispSeq = spnSeq.Value.ObjectNullString();
                _strreasonType = rdgReasonType.EditValue.ObjectNullString();
                _strUseFlag = rdgUseFlag.EditValue.ObjectNullString();
                _strRemarks = memRemarks.Text.Trim();

                if (!this.SaveData(_strreasonCode, _strreason, _strdispSeq, _strreasonType, _strUseFlag, _strRemarks, "Y"))
                {
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

        public void DeleteButton_Click()
        {

        }

        #endregion

        #region 함수
   
        private void GetGridViewList()
        {
             BASE_DXGridHelper.Bind_Grid( gcList
                                        , "PKGBAS_BASE.GET_REASONCODE"
                                        , 1
                                        , new string[] {
                                          "A_CLIENT"
                                        , "A_COMPANY"
                                        , "A_PLANT"
                                        , "A_REASONTYPE"
                                        , "A_VIEW" }
                                        , new string[] {
                                          Global.Global_Variable.CLIENT
                                        , Global.Global_Variable.COMPANY
                                        , Global.Global_Variable.PLANT
                                        , rdgReason.EditValue.ObjectNullString()
                                        , "1" }
                                        , true
                                        , "REASONCODE, REASON, DISPSEQ"
                                        );

            gvList.BestFitColumns();

        }

        private bool SaveData(string p_strreasonCode, string p_strreason, string p_strdispSeq, string p_strreasonType, string p_strUseFlag, string p_strRemarks, string p_strNewflag)
        {

            bool _blReturn = BASE_db.Execute_Proc( "PKGBAS_BASE.PUT_REASONCODE"
                                                 , 1
                                                 , new string[] {
                                                   "A_CLIENT"
                                                 , "A_COMPANY"
                                                 , "A_PLANT"
                                                 , "A_REASONCODE"
                                                 , "A_REASON"
                                                 , "A_DISPSEQ"
                                                 , "A_REASONTYPE"
                                                 , "A_USEFLAG"
                                                 , "A_REMARKS"
                                                 , "A_USERID"
                                                 , "A_NEWFLAG" }
                                                 , new string[] {
                                                   Global.Global_Variable.CLIENT
                                                 , Global.Global_Variable.COMPANY
                                                 , Global.Global_Variable.PLANT
                                                 , p_strreasonCode
                                                 , p_strreason
                                                 , p_strdispSeq
                                                 , p_strreasonType
                                                 , p_strUseFlag
                                                 , p_strRemarks
                                                 , Global_Variable.USER_ID
                                                 , p_strNewflag }
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

        private void gvList_RowStyle(object sender, RowStyleEventArgs e)
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
                if (dr["REASONCODE"] != null)
                {
                    // 주키가 두개일 경우 AND 문으로 조건을 다중으로 준다.
                    if (dr["REASONCODE"].ToString() == gvList.GetDataRow(e.RowHandle)["REASONCODE"].ToString())
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void rdogrReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetGridViewList();
        }

        #endregion

    }
}
