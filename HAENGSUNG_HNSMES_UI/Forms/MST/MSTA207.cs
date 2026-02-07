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
using HAENGSUNG_HNSMES_UI.WebService.Access;
using GridAlias = DevExpress.XtraGrid.Views.Grid;


namespace HAENGSUNG_HNSMES_UI.Forms.MST
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : MSTA207<br/>
    ///      기능 : 라우팅 마스터 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    public partial class MSTA207 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
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

        DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repPartNo = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
        
        public MSTA207()
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
            // 초기화 관련 구현은 아래에 구현 ***
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None, gcList1);
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None, gcList2);

            this.Set_Init();
            this.GetGridViewList1();
            this.GetGridViewList2("");
        }

        public void DeleteButton_Click()
        {
            // 삭제 관련 구현은 아래에 구현 ***
            InitButton_Click();

            MainButton_INIT.PerformClick();
        }
        
        public void NewButton_Click()
        {
            // 신규 관련 구현은 아래에 구현 ***

            // 각 컨트롤마다 신규 상태를 별도로 설정할 수 있습니다.
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New, gcList1);
            // 그리드뷰에 새로운 행과 초기값을 지정한다.
            gvList1.EX_AddNewRow();
            rdgUseFlag.SelectedIndex = 0;
            txtRouteGrp.Focus();

        }

        public void EditButton_Click()
        {
            // 수정 관련 구현은 여기에 구현 ***
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit, gcList1);
        }

        public void StopButton_Click()
        {
            // 정지 관련 구현은 여기에 구현 ***
        }

        public void SearchButton_Click()
        {
            // 검색 관련 구현은 여기에 구현 ***
        }

        public void SaveButton_Click()
        {
            // 저장 관련 구현은 아래에 구현 ***

            base.baseDxErrorProvider.ClearErrors();
            ValidateChildren(ValidationConstraints.Visible);

            // 유효성 검사를 한다.
            if (base.baseDxErrorProvider.HasErrors)
            {
                return;
            }

            string _strRouteGRP = "";
            string _strItemCode = "";
            string _strUseFlag = "";
            string _strRemarks = "";

            if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit)                
            {
                // ****** 마지막 수정항목을 데이터셋에 적용 시킬려면 포커스를 이동을 한다.
                gvList1.FocusedRowHandle = -1;

                // 수정,추가,변경 된 데이터를 모두 가져온다.
                DataTable _dt = gvList1.EX_GetChangedData();

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
                            _strRouteGRP = _dr["ROUTEGRP"].ObjectNullString();
                            _strItemCode = _dr["ITEMCODE"].ObjectNullString();
                            _strUseFlag = _dr["USEFLAG"].ObjectNullString();
                            _strRemarks = _dr["REMARKS"].ObjectNullString();

                            if(!this.SaveData1(_strRouteGRP, _strItemCode, _strUseFlag, _strRemarks, "N"))
                                return;
                            break;

                        default:
                            break;
                    }
                }

                MainButton_INIT.PerformClick();
                // 마지막 처리 된 값쪽에 포커스를 이동 시킵니다.
                // 사용시에 주석을 해제하고 수정하세요.
                gvList1.EX_GetFocuseRowCell("ROUTEGRP", _strRouteGRP);
            }
            else if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
            {
                // ***** 신규 관련 프로시져를 여기에 구현을 합니다.
                _strRouteGRP = txtRouteGrp.Text.Trim().ObjectNullString();
                _strItemCode = gleItem.EditValue.ObjectNullString();
                _strUseFlag = rdgUseFlag.EditValue.ObjectNullString();
                _strRemarks = memRemarks.Text.Trim().ObjectNullString();
                if(!this.SaveData1(_strRouteGRP, _strItemCode, _strUseFlag, _strRemarks, "Y"))
                    return;

                MainButton_INIT.PerformClick();
                MainButton_New.PerformClick();
            }

        }

        public void PrintButton_Click()
        {
            // 출력 관련 구현은 아래에 구현 ***
        }

        public void RefreshButton_Click()
        {
            // 새로고침 관련 구현은 아래에 구현 ***
        }

        #endregion

        #region 함수

        private void Set_Init()
        {
            btnInit.Enabled = false;
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleItem
                                                       , "PKGBAS_BASE.GET_ITEM"
                                                       , 2
                                                       , new string[] { 
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_VIEW"
                                                       , "A_ITEMTYPE" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , "0"
                                                       , "1" }
                                                       , "ITEMCODE"
                                                       , "PARTNO"
                                                       , "ITEMCODE,PARTNO,ITEMNAME"
                                                       );

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleOper
                                                       , "PKGBAS_BASE.GET_OPER"
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
                                                       , "OPER"
                                                       , "OPERNAME"
                                                       , "OPER,OPERNAME,REMARKS,OPERTYPE"
                                                       );

            BASE_DXGridLookUpHelper.Bind_Repository_GridLookUpEdit( repPartNo
                                                                  , "PKGBAS_BASE.GET_ITEM"
                                                                  , 2
                                                                  , new string[] { 
                                                                    "A_CLIENT"
                                                                  , "A_COMPANY"
                                                                  , "A_PLANT"
                                                                  , "A_VIEW"
                                                                  , "A_ITEMTYPE" }
                                                                  , new string[] {
                                                                    Global.Global_Variable.CLIENT
                                                                  , Global.Global_Variable.COMPANY
                                                                  , Global.Global_Variable.PLANT
                                                                  , "0"
                                                                  , "1" }
                                                                  , "ITEMCODE"
                                                                  , "PARTNO"
                                                                  , "ITEMCODE,PARTNO,ITEMNAME"
                                                                  , false
                                                                  );

            repPartNo.NullText = "";
        }

        private void GetGridViewList1()
        {
            /// ****************** GridControl과 Bind Grid ***************
            /// 입력컨트롤과 GridControl의 바인딩은 필수적으로 BASE_DXGridHelper.Bind_Grid(...) 사용하도록 함.
            /// **********************************************************
            BASE_DXGridHelper.Bind_Grid( gcList1
                                       , "PKGBAS_BASE.GET_ROUTINGGRP"
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
                                       , "ROUTEGRP, PARTNO, SPEC, USEFLAG, REMARKS "
                                       );

            gvList1.OptionsView.ColumnAutoWidth = false;
            gvList1.BestFitColumns();

        }

        private void GetGridViewList2(string p_strRouteGrp)
        {
            /// ****************** GridControl과 Bind Grid ***************
            /// 입력컨트롤과 GridControl의 바인딩은 필수적으로 BASE_DXGridHelper.Bind_Grid(...) 사용하도록 함.
            /// **********************************************************
            BASE_DXGridHelper.Bind_Grid( gcList2
                                       , "PKGBAS_BASE.GET_ROUTING"
                                       , 1
                                       , new string[] {
                                         "A_CLIENT"
                                       , "A_COMPANY"
                                       , "A_PLANT"
                                       , "A_ROUTEGRP"
                                       , "A_VIEW" }
                                       , new string[] {
                                         Global.Global_Variable.CLIENT
                                       , Global.Global_Variable.COMPANY
                                       , Global.Global_Variable.PLANT
                                       , p_strRouteGrp
                                       , "1" }
                                       , true
                                       , "ROUTE, OPER, OPERNAME, UPRROUTE, ITEMCODE, INSPFLAG, BOMITEMFLAG, USEFLAG "
                                       );

            gvList2.Columns["ITEMCODE"].ColumnEdit = repPartNo;
            gvList2.OptionsView.ColumnAutoWidth = false;
            gvList2.BestFitColumns();
        }

        private bool SaveData1(string p_strRouteGRP, string p_strItemCode, string p_strUseFlag, string p_strRemarks, string p_strNewFlag)
        {
            // 프로시져 수행
            bool result = BASE_db.Execute_Proc( "PKGBAS_BASE.PUT_ROUTINGGRP"
                                              , 1
                                              , new string[] { 
                                                "A_CLIENT"
                                              , "A_COMPANY"
                                              , "A_PLANT"
                                              , "A_ROUTEGRP"
                                              , "A_ITEMCODE"
                                              , "A_USEFLAG"
                                              , "A_REMARKS"
                                              , "A_EHRCODE"
                                              , "A_NEWFLAG" }
                                              , new string[] {  
                                                Global.Global_Variable.CLIENT
                                              , Global.Global_Variable.COMPANY
                                              , Global.Global_Variable.PLANT
                                              , p_strRouteGRP
                                              , p_strItemCode
                                              , p_strUseFlag 
                                              , p_strRemarks
                                              , Global.Global_Variable.EHRCODE
                                              , p_strNewFlag }
                                              , true
                                              );

            return result;
        }

        private bool SaveData2(string p_strRouteGrp, string p_strRoute, string p_strOper, string p_strUprRoute, string p_strItemCode, string p_strInspFlag,
            string p_strBomItemFlag, string p_strUseFlag, string p_strRemarks, string p_strNewFlag)
        {
            // 프로시져 수행
            bool result = BASE_db.Execute_Proc( "PKGBAS_BASE.PUT_ROUTING"
                                              , 1
                                              , new string[] { 
                                                "A_CLIENT"
                                              , "A_COMPANY"
                                              , "A_PLANT"
                                              , "A_ROUTEGRP"
                                              , "A_ROUTE"
                                              , "A_OPER"
                                              , "A_UPRROUTE"
                                              , "A_ITEMCODE"
                                              , "A_ROUTETYPE"
                                              , "A_INSPFLAG"
                                              , "A_BOMITEMUSEFLAG"
                                              , "A_USEFLAG"
                                              , "A_REMARKS"
                                              , "A_EHRCODE"
                                              , "A_NEWFLAG" }
                                              , new string[] {  
                                                Global.Global_Variable.CLIENT
                                              , Global.Global_Variable.COMPANY
                                              , Global.Global_Variable.PLANT
                                              , p_strRouteGrp
                                              , p_strRoute
                                              , p_strOper
                                              , p_strUprRoute
                                              , p_strItemCode
                                              , "0"
                                              , p_strInspFlag
                                              , p_strBomItemFlag
                                              , p_strUseFlag 
                                              , p_strRemarks
                                              , Global.Global_Variable.EHRCODE
                                              , p_strNewFlag }
                                              , true
                                              );


            return result;
        }
        #endregion

        #region 일반 이벤트

        private void gvList1_Click(object sender, EventArgs e)
        {
            // 선택된 그리드뷰 내의 Hit Info 정보를 가져오는 소스이다.
            // 사용하지 않을 시에 삭제하거나 주석처리 하세요.
            if (!(sender is GridAlias.GridView))
            {
                return;
            }

            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo gridHitINFO = BASE_clsDevexpressGridUtil.GetClickHitInfo(gvList1, e);

            if (gridHitINFO.InRow)
            {
                /// ============================================================
                /// 선택된 Row의 정보를 가져올려면 아래에 구현을 하면 된다.
                int RowIdx = gridHitINFO.RowHandle;

                string _strRouteGrp = "";

                if (gvList1.GetFocusedRowCellValue("ROUTEGRP") != null)
                {
                    if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New || base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit)
                        return;

                    BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleRoutItemCode
                                                               , "PKGBAS_BASE.GET_ROUTING"
                                                               , 2
                                                               , new string[] { 
                                                                 "A_CLIENT"
                                                               , "A_COMPANY"
                                                               , "A_PLANT"
                                                               , "A_ITEMCODE" }
                                                               , new string[] {
                                                                 Global.Global_Variable.CLIENT
                                                               , Global.Global_Variable.COMPANY
                                                               , Global.Global_Variable.PLANT
                                                               , gvList1.GetDataRow(RowIdx)["ITEMCODE"].ObjectNullString() }
                                                               , "ITEMCODE"
                                                               , "PARTNO"
                                                               , "ITEMCODE,PARTNO"
                                                               );

                    _strRouteGrp = gvList1.GetDataRow(RowIdx)["ROUTEGRP"].ToString();

                    this.GetGridViewList2(_strRouteGrp);

                    btnInit.Enabled = true;
                    btnNew.Enabled = true;
                    btnEdit.Enabled = true;
                    btnSave.Enabled = false;
                }
                
            }

            if (gridHitINFO.InRowCell)
            {
            }
        }

        private void gvList1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
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

            btnInit.Enabled = false;
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
        }

        private void gvList1_RowStyle(object sender, GridAlias.RowStyleEventArgs e)
        {
            // 수정된 항목을 그리드에 표시하는 기능. 사용시 주석해제 하고 일부분 수정해야 함.
            // 구현상 기능이 필요하지 않으면 주석처리 하세요.
            DataTable changes = gvList1.EX_GetChangedData(DataRowState.Modified);

            if (e.RowHandle < 0)
                return;

            // 수정된 키값 필드를 입력한다.
            foreach (DataRow dr in changes.Rows)
            {
                if (dr["ROUTEGRP"] != null)
                {
                    // 주키가 두개일 경우 AND 문으로 조건을 다중으로 준다.
                    if (dr["ROUTEGRP"].ToString() == gvList1.GetDataRow(e.RowHandle)["ROUTEGRP"].ToString())
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void gvList2_Click(object sender, EventArgs e)
        {
            // 선택된 그리드뷰 내의 Hit Info 정보를 가져오는 소스이다.
            // 사용하지 않을 시에 삭제하거나 주석처리 하세요.
            if (!(sender is GridAlias.GridView))
            {
                return;
            }

            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo gridHitINFO = BASE_clsDevexpressGridUtil.GetClickHitInfo(gvList2, e);

            if (gridHitINFO.InRow && gridHitINFO.InColumn)
            {
                /// ============================================================
                /// 선택된 Row의 정보를 가져올려면 아래에 구현을 하면 된다.
            }

            if (gridHitINFO.InRowCell)
            {
            }
        }

        private void gvList2_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
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

        private void gvList2_RowStyle(object sender, GridAlias.RowStyleEventArgs e)
        {
            // 수정된 항목을 그리드에 표시하는 기능. 사용시 주석해제 하고 일부분 수정해야 함.
            // 구현상 기능이 필요하지 않으면 주석처리 하세요.
            DataTable changes = gvList2.EX_GetChangedData(DataRowState.Modified);

            if (e.RowHandle < 0)
                return;

            // 수정된 키값 필드를 입력한다.
            foreach (DataRow dr in changes.Rows)
            {
                if (dr["ROUTE"] != null && dr["OPER"] != null)
                {
                    // 주키가 두개일 경우 AND 문으로 조건을 다중으로 준다.
                    if (dr["ROUTE"].ToString() == gvList2.GetDataRow(e.RowHandle)["ROUTE"].ToString())
                    {
                        if (dr["OPER"].ToString() == gvList2.GetDataRow(e.RowHandle)["OPER"].ToString())
                        {
                            e.Appearance.ForeColor = Color.Red;
                        }
                    }
                }
            }
        }

        #endregion

        private void btnInit_Click(object sender, EventArgs e)
        {
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None, gcList2);
            this.GetGridViewList2(txtRouteGrp.Text);

            btnInit.Enabled = true;
            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnInit.Enabled = true;
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;

            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New, gcList2);

            gvList2.EX_AddNewRow();
            rdgInspFlag.SelectedIndex = 1;
            rdgUseFlag2.SelectedIndex = 0;
            txtRoute.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnInit.Enabled = true;
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;

            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit, gcList2);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 저장 관련 구현은 아래에 구현 ***

            // ************************************************************************************
            // 유효성검사 수행
            // 유효성 검사 대상은 컨트롤 속성
            // [컨트롤].ValidationCheck == True 일때 체크가 됨.
            // ************************************************************************************
            base.baseDxErrorProvider.ClearErrors();
            ValidateChildren(ValidationConstraints.Visible);

            // 유효성 검사를 한다.
            if (base.baseDxErrorProvider.HasErrors)
            {
                return;
            }

            // 수정,추가,변경 된 데이터를 모두 가져온다.
            DataTable _dt = BASE_clsDevexpressGridUtil.GetChangedData(gcList2);

            // 변경된 데이터가 없으면 return.
            if (_dt.Rows.Count == 0) return;

            string _strRouteGrp = "";
            string _strRoute = "";
            string _strOper = "";
            string _strUprRoute = "";
            string _strItemCode = "";
            string _strInspFlag = "";
            string _strBomItemFlag = "";
            string _strUseFlag = "";
            string _strRemarks = "";

            if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit)
            {
                // 변경된 데이터를 루프를 통해 하나씩 빼낸다.
                foreach (DataRow _dr in _dt.Rows)
                {
                    switch (_dr.RowState)
                    {
                        case DataRowState.Modified:
                            _strRouteGrp = txtRouteGrp.Text;
                            _strRoute = _dr["ROUTE"].ObjectNullString();
                            _strOper = _dr["OPER"].ObjectNullString();
                            _strUprRoute = _dr["UPRROUTE"].ObjectNullString();
                            _strItemCode = _dr["ITEMCODE"].ObjectNullString();
                            _strInspFlag = _dr["INSPFLAG"].ObjectNullString();
                            _strBomItemFlag = _dr["BOMITEMFLAG"].ObjectNullString();
                            _strUseFlag = _dr["USEFLAG"].ObjectNullString();
                            _strRemarks = _dr["REMARKS"].ObjectNullString();

                            if (!this.SaveData2(_strRouteGrp, _strRoute, _strOper, _strUprRoute, _strItemCode, _strInspFlag, _strBomItemFlag, _strUseFlag, _strRemarks, "N"))
                                return;
                            break;

                        default:
                            break;
                    }

                    btnInit.Enabled = true;
                    btnNew.Enabled = false;
                    btnEdit.Enabled = false;
                    btnSave.Enabled = true;
                }

                this.btnInit_Click(null, null);
                // 마지막 처리 된 값쪽에 포커스를 이동 시킵니다.
                // 사용시에 주석을 해제하고 수정하세요.
                gvList1.EX_GetFocuseRowCell("ROUTE", _strRoute);
            }
            else if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
            {
                // ***** 신규 관련 프로시져를 여기에 구현을 합니다.
                //_strRouteGrp = "TEST";
                _strRouteGrp = txtRouteGrp.Text.Trim().ObjectNullString();
                _strRoute = txtRoute.Text.Trim().ObjectNullString();
                _strOper = gleOper.EditValue.ObjectNullString();
                _strUprRoute = txtUprRoute.EditValue.ObjectNullString();
                _strItemCode = gleRoutItemCode.EditValue.ObjectNullString();
                _strInspFlag = rdgInspFlag.EditValue.ObjectNullString();
                _strBomItemFlag = rdgBomItemFlag.EditValue.ObjectNullString();
                _strUseFlag = rdgUseFlag.EditValue.ObjectNullString();
                _strRemarks = memRemarks.Text.Trim().ObjectNullString();

                if (!this.SaveData2(_strRouteGrp, _strRoute, _strOper, _strUprRoute, _strItemCode, _strInspFlag, _strBomItemFlag, _strUseFlag, _strRemarks, "Y"))
                    return;


                this.btnInit_Click(null, null);
                this.btnNew_Click(null, null);

                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = true;
            }
        }

    }
}
