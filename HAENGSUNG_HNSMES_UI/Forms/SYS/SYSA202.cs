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


namespace HAENGSUNG_HNSMES_UI.Forms.SYS
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : SYSA202<br/>
    ///      기능 : 트랜잭션 마스터 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    public partial class SYSA202 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
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
        public SYSA202()
        {
            InitializeComponent();
        }
        private void SYSA202_Load(object sender, EventArgs e)
        {

        }
        private void SYSA202_Shown(object sender, EventArgs e)
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
            this.GetGridViewList();
        }

        public void DeleteButton_Click()
        {
        }
        
        public void NewButton_Click()
        {
            // 신규 항목을 추가하기전에 기존에 수정된 데이터를 저장하고 신규 추가를 한다.
            this.SaveButton_Click();
            
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New);
            gvList.EX_AddNewRow();

            rdgUseFlag.SelectedIndex = 0;
            rdgUseMes.SelectedIndex = 0;

            txtCode.Focus();
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

            string _strCode = "";
            string _strName;
            string _strErpCode;
            string _strMatInFlag;
            string _strMatOutFlag;
            string _strPrdInFlag;
            string _strPrdOutFlag;
            string _strCancelFlag;
            string _strUndoFlag = "";
            string _strMes;
            string _strUsefalg;
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


                // 변경된 데이터를 루프를 통해 하나씩 빼낸다.
                foreach (DataRow _dr in _dt.Rows)
                {
                    switch (_dr.RowState)
                    {
                        case DataRowState.Modified:
                            
                            _strCode = _dr["TXNCODE"].ObjectNullString();
                            _strName = _dr["TXNNAME"].ObjectNullString();
                            _strErpCode = _dr["ERPTXNCODE"].ObjectNullString();
                            _strMatInFlag = _dr["MATINFLAG"].ObjectNullString();
                            _strMatOutFlag = _dr["MATOUTFLAG"].ObjectNullString();
                            _strPrdInFlag = _dr["PRDINFLAG"].ObjectNullString();
                            _strPrdOutFlag = _dr["PRDOUTFLAG"].ObjectNullString();
                            _strCancelFlag = _dr["CANCELFLAG"].ObjectNullString();
                            _strUndoFlag = _dr["UNDOFLAG"].ObjectNullString();
                            _strMes = _dr["USEMES"].ObjectNullString();
                            _strRemarks = _dr["REMARKS"].ObjectNullString();
                            _strUsefalg = _dr["USEFLAG"].ObjectNullString();

                            if (!this.SaveData(_strCode, _strName, _strErpCode, _strMatInFlag,
                                                _strMatOutFlag, _strPrdInFlag, _strPrdOutFlag, _strCancelFlag, _strUndoFlag, _strMes,
                                                _strUsefalg, _strRemarks, "N"))
                                return;
                            break;

                        default:
                            break;
                    }
                }

                MainButton_INIT.PerformClick();

                //마지막 처리 된 값쪽에 포커스를 이동 시킵니다. 사용시에 주석을 해제하고 수정하세요.
                gvList.EX_GetFocuseRowCell("TXNCODE", _strCode);
            }

            else if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
            {
                // ***** 신규 관련 프로시져를 여기에 구현을 합니다.
                _strCode = txtCode.EditValue.ObjectNullString();
                _strName = txtName.EditValue.ObjectNullString();
                _strErpCode = txtErpTxnCode.EditValue.ObjectNullString();
                _strMes = rdgUseMes.EditValue.ObjectNullString();
                _strMatInFlag = rdgMatInFlag.EditValue.ObjectNullString();
                _strMatOutFlag = rdgMatOutFlag.EditValue.ObjectNullString();
                _strPrdInFlag = rdgPrdInFlag.EditValue.ObjectNullString();
                _strPrdOutFlag = rdgPrdOutFlag.EditValue.ObjectNullString();
                _strCancelFlag = rdgCancelFlag.EditValue.ObjectNullString();
                _strRemarks = txtRemarks.EditValue.ObjectNullString();
                _strUsefalg = rdgUseFlag.EditValue.ObjectNullString();

                if (!this.SaveData(_strCode, _strName, _strErpCode, 
                                    _strMatInFlag, _strMatOutFlag, _strPrdInFlag, _strPrdOutFlag, _strCancelFlag, _strUndoFlag, _strMes,
                                    _strUsefalg, _strRemarks, "N"))
                    return;

                // 신규 항목 데이터를 처리하면 그리드를 리프레쉬 합니다.
                MainButton_INIT.PerformClick();
                MainButton_New.PerformClick();
            }

            // 언어를 재성정 함.
            BASE_Language.SetLanguage();
        }

        public void PrintButton_Click()
        {
        }

        public void RefreshButton_Click()
        {
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);
            GetGridViewListRefresh();
        }

        public void StopButton_Click()
        {
        }

        public void SearchButton_Click()
        {
        }


        #endregion

        #region 함수

        private void Set_Init()
        {
            rdgMatInFlag.SelectedIndex = 1;
            rdgMatOutFlag.SelectedIndex = 1;
            rdgPrdInFlag.SelectedIndex = 1;
            rdgPrdOutFlag.SelectedIndex = 1;
            rdgCancelFlag.SelectedIndex = 1;
            rdgUndoFlag.SelectedIndex = 1;

            rdgUseMes.SelectedIndex = 0;
            rdgUseFlag.SelectedIndex = 0;
        }

        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid( gcList
                                       , "PKGSYS_COMM.GET_TRANSACTION"
                                       , 1
                                       , new string[] { 
                                         "A_CLIENT"
                                       , "A_COMPANY"
                                       , "A_PLANT"
                                       , "A_VIEW" }
                                       , new string[] {
                                         Global.Global_Variable.CLIENT
                                       , Global.Global_Variable.COMPANY
                                       , Global.Global_Variable.PLANT
                                       , "1" }
                                       , true
                                       , "TXNCODE, TXNNAME, ERPTXNCODE, USEMES, USEFLAG, REMARKS"
                                       );

            gvList.BestFitColumns();
        }

        private void GetGridViewListRefresh()
        {
            BASE_DXGridHelper.Refresh_Grid( gcList
                                          , "PKGSYS_COMM.GET_TRANSACTION"
                                          , 1
                                          , new string[] { 
                                            "A_CLINET"
                                          , "A_COMPANY"
                                          , "A_PLANT"
                                          , "A_VIEW" }
                                          , new string[] { 
                                            Global.Global_Variable.CLIENT
                                          , Global.Global_Variable.COMPANY
                                          , Global.Global_Variable.PLANT
                                          , "1" }
                                          , true
                                          , "TXNCODE, TXNNAME, ERPTXNCODE, USEMES, USEFLAG, REMARKS"
                                          );

            gvList.BestFitColumns();
        }


        /// <summary>
        /// SHOP을 등록합니다.
        /// </summary>
        /// <returns>
        /// 회원등록시에 아이디 중복을 확인하고 유효성 검사후에 
        /// 회원정보를 등록합니다.
        /// </returns>
        private bool SaveData( string p_strCode, string p_strname, string p_strErpTxnCode, string p_strMes,
                               string p_strMatInFlag, string p_strMatOutFlag, string p_strPrdInFlag, string p_strPrdOutFlag,
                               string p_strCancelFlag, string p_strUndoFlag, string p_strUseFlag, string p_strRemarks, string p_strNewFlag)
        {
            bool _blReturn = BASE_db.Execute_Proc( "PKGSYS_COMM.PUT_TRANSACTION"
                                                 , 1
                                                 , new string[] { 
                                                   "A_CLIENT"
                                                 , "A_COMPANY"
                                                 , "A_PLANT"
                                                 , "A_TXNCODE"
                                                 , "A_TXNNAME"
                                                 , "A_ERPTXNCODE"
                                                 , "A_MATINFLAG"
                                                 , "A_MATOUTFLAG"
                                                 , "A_PRDINFLAG"
                                                 , "A_PRDOUTFLAG"
                                                 , "A_CANCELFLAG"
                                                 , "A_UNDOFLAG"
                                                 , "A_USEMES"
                                                 , "A_USEFLAG"
                                                 , "A_REMARKS"
                                                 , "A_NEWFLAG" }
                                                 , new string[] {
                                                   Global.Global_Variable.CLIENT
                                                 , Global.Global_Variable.COMPANY
                                                 , Global.Global_Variable.PLANT
                                                 , p_strCode
                                                 , p_strname
                                                 , p_strErpTxnCode
                                                 , p_strMatInFlag
                                                 , p_strMatOutFlag
                                                 , p_strPrdInFlag
                                                 , p_strPrdOutFlag
                                                 , p_strCancelFlag
                                                 , p_strUndoFlag
                                                 , p_strMes
                                                 , p_strUseFlag
                                                 , p_strRemarks
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
                if (dr["TXNCODE"] != null)
                {
                    // 주키가 두개일 경우 AND 문으로 조건을 다중으로 준다.
                    if (dr["TXNCODE"].ToString() == gvList.GetDataRow(e.RowHandle)["TXNCODE"].ToString())
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
            }
        }

        #endregion

        

        

        
    }
}
