using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using HAENGSUNG_HNSMES_UI.Class;
using DevExpress.XtraGrid.Views.Grid;

namespace HAENGSUNG_HNSMES_UI.Forms.SYS
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : SYSA204<br/>
    ///      기능 : 화면 마스터 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    public partial class SYSA204 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
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

        public SYSA204()
        {
            InitializeComponent();

            ImagIndex.Properties.LargeImages = Program.frmM.imagesPage32;
        }

        private void SYSA204_Load(object sender, EventArgs e)
        {

        }
        private void SYSA204_Shown(object sender, EventArgs e)
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
            // 신규 항목을 추가하기전에 기존에 수정된 데이터를 저장하고 신규 추가를 한다.
            this.SaveButton_Click();

            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New);

            gvList.EX_AddNewRow();

            rdgUseFlag.SelectedIndex = 0;
            rdgTouchFlag.SelectedIndex = 1;
            

            txtFormCode.Focus();
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
        }

        public void DeleteButton_Click()
        {
            string p_strFormDle = txtFormCode.EditValue.ObjectNullString();

            BASE_db.Execute_Proc( "PKGSYS_MENU.DEL_FORMMST"
                                , 1
                                , new string[] { 
                                  "A_CLIENT"
                                , "A_COMPANY"
                                , "A_PLANT"
                                , "A_SYSTEM"
                                , "A_FORMCD" }
                                , new string[] { 
                                  Global.Global_Variable.CLIENT
                                , Global.Global_Variable.COMPANY
                                , Global.Global_Variable.PLANT
                                , Global.Global_Variable.SYSTEMCODE
                                , p_strFormDle }
                                , true
                                );

            MainButton_INIT.PerformClick();
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

            string _strFormCode = "";
            string _strFormName;
            string _strUseYn;

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
                            _strFormCode = _dr["FORM"] + "";
                            _strFormName = _dr["FORMNAME"] + "";
                            _strUseYn = _dr["USEFLAG"] + "";

                            if (!this.SaveData(_strFormCode, _strFormName, _strUseYn, "N"))
                                return;
                            break;
                            
                        default:
                            break;
                    }
                }

                MainButton_INIT.PerformClick();

                gvList.EX_GetFocuseRowCell("FORM", _strFormCode);

            }
            else if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
            {
                // ***** 신규 관련 프로시져를 여기에 구현을 합니다.
                _strFormCode = txtFormCode.Text.Trim().ObjectNullString();
                _strFormName = txtFormName.Text.Trim().ObjectNullString();
                _strUseYn = rdgUseFlag.EditValue.ObjectNullString();

                if (!this.SaveData(_strFormCode, _strFormName, _strUseYn, "Y"))
                    return;

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
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);

            GetGridViewListRefresh();
        }

        #endregion

        #region 함수

        private void Set_Init()
        {
        }

        /// <summary>
        /// Gridview Data INIT
        /// </summary>
        /// <remarks>
        /// GridView의 Name 속성을 변경하고자 한다면 디자이너 모드에서 변경바람.
        /// </remarks>
        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid( gcList
                                       , "PKGSYS_MENU.GET_FORMS"
                                       , 1
                                       , new string[] { 
                                         "A_CLIENT"
                                       , "A_COMPANY"
                                       , "A_PLANT"
                                       , "A_SYSTEM"
                                       , "A_VIEW" }
                                       , new string[] { 
                                         Global.Global_Variable.CLIENT
                                       , Global.Global_Variable.COMPANY
                                       , Global.Global_Variable.PLANT
                                       , Global.Global_Variable.SYSTEMCODE
                                       , "1" }
                                       , true
                                       , "FORM, FORMNAME, USEFLAG, IMGIDX"
                                       );

            gvList.BestFitColumns();
        }

        /// <summary>
        /// Gridview Data INIT
        /// </summary>
        /// <remarks>
        /// GridView의 Name 속성을 변경하고자 한다면 디자이너 모드에서 변경바람.
        /// </remarks>
        private void GetGridViewListRefresh()
        {
            BASE_DXGridHelper.Refresh_Grid( gcList
                                          , "PKGSYS_MENU.GET_FORMS"
                                          , 1
                                          , new string[] { 
                                            "A_CLIENT"
                                          , "A_COMPANY"
                                          , "A_PLANT"
                                          , "A_SYSTEM"
                                          , "A_VIEW" }
                                          , new string[] { 
                                            Global.Global_Variable.CLIENT
                                          , Global.Global_Variable.COMPANY
                                          , Global.Global_Variable.PLANT
                                          , Global.Global_Variable.SYSTEMCODE
                                          , "1" }
                                          , true
                                          , "FORM, FORMNAME, USEFLAG, IMGIDX"
                                          );
        }

        /// <summary>
        /// SHOP을 등록합니다.
        /// </summary>
        /// <returns>
        /// 회원등록시에 아이디 중복을 확인하고 유효성 검사후에 
        /// 회원정보를 등록합니다.
        /// </returns>
        private bool SaveData(string p_strFormCode, string p_strFormName, string p_strUseYn, string p_strNewFlag)
        {
            bool _blReturn = BASE_db.Execute_Proc( "PKGSYS_MENU.PUT_FORMMST"
                                                 , 1
                                                 , new string[] { 
                                                   "A_CLIENT"
                                                 , "A_COMPANY"
                                                 , "A_PLANT"
                                                 , "A_SYSTEM"
                                                 , "A_FORMCD"               
                                                 , "A_FORMNM"
                                                 , "A_USEFLAG"
                                                 , "A_NEWFLAG" }
                                                 , new string[] {
                                                   Global.Global_Variable.CLIENT
                                                 , Global.Global_Variable.COMPANY
                                                 , Global.Global_Variable.PLANT
                                                 , Global.Global_Variable.SYSTEMCODE
                                                 , p_strFormCode
                                                 , p_strFormName
                                                 , p_strUseYn
                                                 , p_strNewFlag }
                                                 , true
                                                 );
            return _blReturn;
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
                if (dr["FORM"] != null)
                {
                    // 주키가 두개일 경우 AND 문으로 조건을 다중으로 준다.
                    if (dr["FORM"].ToString() == gvList.GetDataRow(e.RowHandle)["FORM"].ToString())
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
            }
       }


        private void gvList_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.RowHandle < 0) return;
        }

        #endregion

        

        
    }
}
