using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using NGS.WCFClient.DatabaseService;
using DevExpress.XtraGrid.Views.Grid;

namespace HAENGSUNG_HNSMES_UI.Forms.MST
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : MSTA202<br/>
    ///      기능 : 거래처 마스터 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    public partial class MSTA202 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, Class.itfButton
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

        public MSTA202()
        {
            InitializeComponent();
        }

        private void MSTA202_Load(object sender, EventArgs e)
        {

        }
        private void MSTA202_Shown(object sender, EventArgs e)
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

        public void NewButton_Click()
        {
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New);

            gvList.EX_AddNewRow();

            rdgOSCFlag.SelectedIndex = 0;
            rdgPRCFlag.SelectedIndex = 0;
            rdgSALFlag.SelectedIndex = 0;
            rdgUseFlag.SelectedIndex = 0;

            txtvendor.Focus();
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

            string _strvendor = "";
            string _strvendorname = "";
            string _strMaker = "";
            string _strentry = "";
            string _strceo = "";
            string _strphone = "";
            string _strfax = "";
            string _straddr = "";
            string _strprc = "";
            string _strsal = "";
            string _strosc = "";
            string _strUseyn = "";
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
                            _strvendor = _dr["VENDOR"].ObjectNullString();
                            _strvendorname = _dr["VENDORNAME"].ObjectNullString();
                            _strMaker = _dr["MAKER"].ObjectNullString();
                            _strentry = _dr["ENTRYNO"].ObjectNullString();
                            _strceo = _dr["CEONAME"].ObjectNullString();
                            _strphone = _dr["PHONE"].ObjectNullString();
                            _strfax = _dr["FAXNO"].ObjectNullString();
                            _straddr = _dr["ADDRESS"].ObjectNullString();
                            _strprc = _dr["PRCFLAG"].ObjectNullString();
                            _strsal = _dr["SALFLAG"].ObjectNullString();
                            _strosc = _dr["OSCFLAG"].ObjectNullString();
                            _strUseyn = _dr["USEFLAG"].ObjectNullString();
                            _strRemarks = _dr["REMARKS"].ObjectNullString();

                            if (!this.SaveData(_strvendor, _strvendorname, _strMaker, _strentry, _strceo, _strphone, _strfax, _straddr, _strprc, _strsal, _strosc, _strUseyn, _strRemarks, "N"))
                            {
                                MainButton_INIT.PerformClick();
                                //마지막 처리 된 값쪽에 포커스를 이동 시킵니다. 사용시에 주석을 해제하고 수정하세요.
                                gvList.EX_GetFocuseRowCell("VENDOR", _strvendor);
                                return;
                            }
                            break;

                        default:
                            break;
                    }
                }

                MainButton_INIT.PerformClick();
                //마지막 처리 된 값쪽에 포커스를 이동 시킵니다. 사용시에 주석을 해제하고 수정하세요.
                gvList.EX_GetFocuseRowCell("VENDOR", _strvendor);

            }
            else if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
            {
                _strvendor = txtvendor.Text.Trim().ObjectNullString();
                _strvendorname = txtvendorname.Text.Trim().ObjectNullString();
                _strMaker = txtMaker.EditValue.ObjectNullString();
                _strentry = txtentryno.Text.Trim().ObjectNullString();
                _strceo = txtCEO.Text.Trim().ObjectNullString();
                _strphone = txtphone.Text.Trim().ObjectNullString();
                _strfax = txtfax.Text.Trim().ObjectNullString();
                _straddr = txtaddr.EditValue.ObjectNullString();
                _strprc = rdgPRCFlag.EditValue.ObjectNullString();
                _strsal = rdgSALFlag.EditValue.ObjectNullString();
                _strosc = rdgOSCFlag.EditValue.ObjectNullString();
                _strUseyn = rdgUseFlag.EditValue.ObjectNullString();
                _strRemarks = memRemarks.Text.Trim().ObjectNullString();

                if (!this.SaveData(_strvendor, _strvendorname, _strMaker, _strentry, _strceo, _strphone, _strfax, _straddr, _strprc, _strsal, _strosc, _strUseyn, _strRemarks, "Y"))
                {
                    MainButton_INIT.PerformClick();
                    return;
                }

                // 신규 항목 데이터를 처리하면 그리드를 리프레쉬 합니다.
                MainButton_INIT.PerformClick();
                MainButton_New.PerformClick();
            }
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

        public void PrintButton_Click()
        {
        }

        public void DeleteButton_Click()
        {
        }

        #endregion

        #region 함수


        private bool SaveData(string p_strvendor, string p_strvendorname, string p_strMaker, string p_strentry, string p_strceo,
                              string p_strphone, string p_strfax, string p_straddr, string p_strprc, string p_strsal,
                              string p_strosc, string p_strUseyn, string p_strRemarks, string p_strNewFlag)
        {

            bool _blReturn = BASE_db.Execute_Proc( "PKGBAS_BASE.PUT_VENDOR"
                                                 , 1
                                                 , new string[] {
                                                   "A_CLIENT"
                                                 , "A_COMPANY"
                                                 , "A_PLANT"
                                                 , "A_VENDOR"
                                                 , "A_VENDORNAME"   
                                                 , "A_MAKER"
                                                 , "A_ENTRYNO"
                                                 , "A_CEONAME"   
                                                 , "A_PHONE"  
                                                 , "A_FAXNO"    
                                                 , "A_ADDRESS"      
                                                 , "A_PRCFLAG"   
                                                 , "A_SALFLAG"
                                                 , "A_OSCFLAG"    
                                                 , "A_USEFLAG"      
                                                 , "A_REMARKS"    
                                                 , "A_USER" 
                                                 , "A_NEWFLAG" }
                                                 , new string[] {
                                                   Global.Global_Variable.CLIENT
                                                 , Global.Global_Variable.COMPANY
                                                 , Global.Global_Variable.PLANT
                                                 , p_strvendor
                                                 , p_strvendorname
                                                 , p_strMaker
                                                 , p_strentry
                                                 , p_strceo
                                                 , p_strphone
                                                 , p_strfax
                                                 , p_straddr
                                                 , p_strprc
                                                 , p_strsal
                                                 , p_strosc
                                                 , p_strUseyn
                                                 , p_strRemarks
                                                 , Global.Global_Variable.EHRCODE
                                                 , p_strNewFlag }
                                                 , true
                                                 );

            return _blReturn;
                 
        }

        private void GetGridViewList()
        {
            /// 프로시져 명 : PKGBAS_BASE.GET_VENDOR
            /// 컨트롤의 사용자 정보를 셋하기 위해 사용한다.
            BASE_DXGridHelper.Bind_Grid( gcList
                                       , "PKGBAS_BASE.GET_VENDOR"
                                       , 1
                                       , new string[] { 
                                         "A_CLIENT"
                                       , "A_COMPANY"
                                       , "A_PLANT"
                                       , "A_PURCHASE"
                                       , "A_SALES"
                                       , "A_OUTSC"
                                       , "A_VIEW" }
                                       , new string[] { 
                                         Global.Global_Variable.CLIENT
                                       , Global.Global_Variable.COMPANY
                                       , Global.Global_Variable.PLANT
                                       , "" 
                                       , ""
                                       , ""
                                       , "0" }
                                       , true
                                       );

            gvList.Columns["COMPANY"].Visible = false;
            gvList.Columns["VENDOR"].Visible = true;
            gvList.Columns["PRCFLAG"].Visible = false;
            gvList.Columns["SALFLAG"].Visible = false;
            gvList.Columns["OSCFLAG"].Visible = false;
            gvList.BestFitColumns();

        }

        #endregion

        #region 일반이벤트

        private void gvList_Click(object sender, EventArgs e)
        {
            if (!(sender is GridView))
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

            DataTable changes = BASE_clsDevexpressGridUtil.GetChangedData(gcList, DataRowState.Modified);

            if (changes == null)
                return;

            if (e.RowHandle < 0)
                return;

            // 수정된 키값 필드를 입력한다.
            foreach (DataRow dr in changes.Rows)
            {
                if (dr["VENDOR"] != null)
                {
                    // 주키가 두개일 경우 AND 문으로 조건을 다중으로 준다.
                    if (dr["VENDOR"].ToString() == gvList.GetDataRow(e.RowHandle)["VENDOR"].ToString())
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
            }
        }

        #endregion
    }
}
