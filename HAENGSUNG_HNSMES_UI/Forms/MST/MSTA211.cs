using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using HAENGSUNG_HNSMES_UI.Class;
using GridAlias = DevExpress.XtraGrid.Views.Grid;
using HAENGSUNG_HNSMES_UI.WebService.Access;

using NGS.WCFClient.DatabaseService;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;

namespace HAENGSUNG_HNSMES_UI.Forms.MST
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : MSTA211<br/>
    ///      기능 : 호기 마스터 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    public partial class MSTA211 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
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

        DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repProdLine = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();

        public MSTA211()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
        }

        private void Form_Shown(object sender, EventArgs e)
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


        public void NewButton_Click()
        {

            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New);

            // 그리드뷰에 새로운 행과 초기값을 지정한다.
            gvList.EX_AddNewRow();

            rdgUseFlag.SelectedIndex = 0;
            txtUnitNo.Focus();

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
            GetGridViewList();
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

            string strUnitNo = "";
            string strUnitNM = "";
            string strUnitType = "";
            string strProdLine = "";
            string strUseFlag = "";

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
                            strUnitNo = dr["UNITNO"].ToString();
                            strUnitNM = dr["UNITNM"].ToString();
                            strUnitType = dr["UNITTYPE"].ToString();
                            strProdLine = dr["PRODLINE"].ToString();
                            strUseFlag = dr["USEFLAG"].ToString();

                            if (!this.SaveData(strUnitNo, strUnitNM, strUnitType, strProdLine, strUseFlag, "N"))
                            {
                                MainButton_INIT.PerformClick();
                                gvList.EX_GetFocuseRowCell("UNITNO", strUnitNo);
                                return;
                            }
                            
                            break;

                        default:
                            break;
                    }
                }

                MainButton_INIT.PerformClick();
                gvList.EX_GetFocuseRowCell("UNITNO", strUnitNo);
            }
            else if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
            {
                // ***** 신규 관련 프로시져를 여기에 구현을 합니다.

                strUnitNo = txtUnitNo.EditValue.ObjectNullString();
                strUnitNM = txtUnitNM.EditValue.ObjectNullString();
                strUnitType = gleUnitType.EditValue.ObjectNullString();
                strProdLine = gleLine.EditValue.ObjectNullString();
                strUseFlag = rdgUseFlag.EditValue.ObjectNullString();

                if (!this.SaveData(strUnitNo, strUnitNM, strUnitType, strProdLine, strUseFlag, "Y"))
                {
                    MainButton_INIT.PerformClick();
                    return;
                }

                MainButton_INIT.PerformClick();
                MainButton_New.PerformClick();
            }
        }

        public void RefreshButton_Click()
        {
        }

        public void DeleteButton_Click()
        {
        }

        public void PrintButton_Click()
        {
        }

        #endregion

        #region 함수

        private void Set_Init()
        {
            this.GetLine();

            this.GetUnitType();

            BASE_DXGridLookUpHelper.Bind_Repository_GridLookUpEdit( repProdLine
                                                                  , "PKGBAS_BASE.GET_LINE"
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
                                                                  , "0" }
                                                                  , "PRODLINE"
                                                                  , "PRODLINENAME"
                                                                  , "PRODLINE,PRODLINENAME"
                                                                  , false
                                                                  );

            repProdLine.NullText = "";
        }

        private void GetLine()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleLine
                                                       , "PKGBAS_BASE.GET_LINE"
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
                                                       , "0" }
                                                       , "PRODLINE"
                                                       , "PRODLINENAME" 
                                                       , "PRODLINE, PRODLINENAME"
                                                       );
        }

        private void GetUnitType()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleUnitType
                                                       , "PKGBAS_BASE.GET_PRODUNIT_TYPE"
                                                       , 1
                                                       , new string[] { 
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT }
                                                       , "CODE"
                                                       , "CODENAME"
                                                       , "CODE, CODENAME, REMARKS"
                                                       );
        }

        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid( gcList
                                       , "PKGBAS_BASE.GET_PRODLINE_UNIT"
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
                                       );

            gvList.Columns["PRODLINE"].ColumnEdit = repProdLine;

            //// 컬럼 조절
            gvList.OptionsView.ColumnAutoWidth = true;
            gvList.BestFitColumns();

        }

        private bool SaveData(string p_sUnitNo, string p_sUnitNM, string p_sUnitType, string p_sProdLine,  string p_sUseFlag, string p_sNewFlag)
        {

            bool result = BASE_db.Execute_Proc( "PKGBAS_BASE.PUT_PRODLINE_UNIT"
                                              , 1
                                              , new string[] { 
                                                "A_CLIENT"
                                              , "A_COMPANY"
                                              , "A_PLANT"
                                              , "A_UNITNO"
                                              , "A_UNITNM"
                                              , "A_UNITTYPE"
                                              , "A_PRODLINE"
                                              , "A_USEFLAG"
                                              , "A_USER"
                                              , "A_NEWFLAG" }
                                              , new string[] { 
                                                Global.Global_Variable.CLIENT
                                              , Global.Global_Variable.COMPANY
                                              , Global.Global_Variable.PLANT
                                              , p_sUnitNo
                                              , p_sUnitNM
                                              , p_sUnitType
                                              , p_sProdLine
                                              , p_sUseFlag 
                                              , Global.Global_Variable.EHRCODE
                                              , p_sNewFlag }
                                              , true
                                              );

            return result;
        }

        #endregion

        #region 일반 이벤트


        private void gvList_Click(object sender, EventArgs e)
        {
            if (!(sender is GridAlias.GridView))
            {
                return;
            }

            //IDAT.Controls.IDATDevExpress _clsGrid = new IDAT.Controls.IDATDevExpress();

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
                //ITEMCODE, MRMTYPE, MRMSEQ, ARANK, BRANK
                if (dr["UNITNO"] != null)
                {
                    // 주키가 두개일 경우 AND 문으로 조건을 다중으로 준다.
                    if (dr["UNITNO"].ToString() == gvList.GetDataRow(e.RowHandle)["UNITNO"].ToString())
                    {
                        e.Appearance.ForeColor = Color.Red;

                        
                    }
                }
            }
        }

        #endregion
    }
}
