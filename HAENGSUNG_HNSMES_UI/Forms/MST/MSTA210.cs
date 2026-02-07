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
using HAENGSUNG_HNSMES_UI.WebService.Access;

namespace HAENGSUNG_HNSMES_UI.Forms.MST
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : MSTA210<br/>
    ///      기능 : 위치 마스터 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    public partial class MSTA210 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
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

        public MSTA210()
        {
            InitializeComponent();
        }

        private void MSTA210_Load(object sender, EventArgs e)
        {
            

        }

        private void MSTA210_Shown(object sender, EventArgs e)
        {
            MainButton_INIT.PerformClick();
        }

        #endregion 

        #region 버튼이벤트

        public void InitButton_Click()
        {
            gleWH.Enabled = true;
            gleWH.EditValue = null;
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);

            this.Set_Init();
            this.GetGridViewList(gleWH.EditValue.ObjectNullString());
        }
        
        
        public void NewButton_Click()
        {
            gleWH.Enabled = false;

            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New);

            // 그리드뷰에 새로운 행과 초기값을 지정한다.
            gvList.EX_AddNewRow();

            rdgUseFlag.SelectedIndex = 0;
            rdoBadFlag.SelectedIndex = 1;
            rdoRetrievalFlag.SelectedIndex = 1;
            rdoStInspFlag.SelectedIndex = 0;
            rdoSNDesFlag.SelectedIndex = 1;
            rdoPurchaseflag.SelectedIndex = 1;
            rdoRepairflag.SelectedIndex = 1;
            rdoOtherflag.SelectedIndex = 1;
            rdoPubFlag.SelectedIndex = 1;
            rdoFifoFlag.SelectedIndex = 1;

            txtWHLocName.Focus();
        }

        public void EditButton_Click()
        {
            gleWH.Enabled = false;
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit);
        }

        public void StopButton_Click()
        {
        }

        public void SearchButton_Click()
        {
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

            string _strWH = "";
            string _strWHLocName = "";
            string _strWHLoc = "";
            string _strProdLine = "";
            string _strUseFlag = "";
            string _strRemarks = "";
            string _strLocType = "";
            string _strBadFlag = "";
            string _strRetrievalFlag = "";
            string _strStInspFlag = "";
            string _strSNDesFlag = "";
            string _strVendor = "";
            string _strErpLocCode = "";
            string _strPurchaseflag = "";
            string _strRepairflag = "";
            string _strOtherflag = "";
            string _strPubFlag = "";
            string _strFifoFlag = "";

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
                            _strWH = _dr["WAREHOUSE"] + "";
                            _strWHLoc = _dr["WHLOC"] + "";
                            _strWHLocName = _dr["WHLOCNAME"] + "";
                            _strProdLine = _dr["PRODLINE"].ObjectNullString();
                            _strUseFlag = _dr["USEFLAG"] + "";
                            _strRemarks = _dr["REMARKS"] + "";
                            _strLocType = _dr["LOCTYPE"] + "";
                            _strBadFlag = _dr["BADWHFLAG"] + "";
                            _strRetrievalFlag = _dr["RETRIEVALFLAG"] + "";
                            _strStInspFlag = _dr["STOCKINSPFLAG"] + "";
                            _strSNDesFlag = _dr["SERIALDESTFLAG"] + "";
                            _strVendor = _dr["VENDOR"] + "";
                            _strErpLocCode = _dr["ERPLOCCODE"] + "";
                            _strPurchaseflag = _dr["PURCHASEFLAG"] + "";
                            _strRepairflag = _dr["REPAIRFLAG"] + "";
                            _strOtherflag = _dr["OTHERINFLAG"] + "";
                            _strPubFlag = _dr["PUBFLAG"] + "";
                            _strFifoFlag = _dr["FIFOFLAG"] + "";

                            if (!this.SaveData(_strWH, _strWHLoc, _strWHLocName, _strProdLine, _strUseFlag,
                                          _strRemarks, _strLocType, _strBadFlag, _strRetrievalFlag, _strStInspFlag,
                                          _strSNDesFlag, _strVendor, _strErpLocCode, "N", _strPurchaseflag,
                                          _strRepairflag, _strOtherflag, _strPubFlag, _strFifoFlag))
                            {
                                MainButton_INIT.PerformClick();
                                gleWH.EditValue = _strWH;
                                //마지막 처리 된 값쪽에 포커스를 이동 시킵니다. 사용시에 주석을 해제하고 수정하세요.
                                gvList.EX_GetFocuseRowCell("WHLOC", _strWHLoc);
                                return;
                            }

                            break;

                        default:
                            break;
                    }
                }

                MainButton_INIT.PerformClick();
                gleWH.EditValue = _strWH;
                //마지막 처리 된 값쪽에 포커스를 이동 시킵니다. 사용시에 주석을 해제하고 수정하세요.
                gvList.EX_GetFocuseRowCell("WHLOC", _strWHLoc);
            }
            else if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
            {
                // ***** 신규 관련 프로시져를 여기에 구현을 합니다.
                _strWH = gleWarehouse.EditValue.ObjectNullString();
                _strWHLoc = txtWHLoc.EditValue.ObjectNullString();
                _strWHLocName = txtWHLocName.EditValue.ObjectNullString();
                _strProdLine = gleProdLine.EditValue.ObjectNullString();
                _strUseFlag = rdgUseFlag.EditValue.ObjectNullString();
                _strRemarks = memRemarks.EditValue.ObjectNullString();
                _strLocType = gleLocType.EditValue.ObjectNullString();
                _strBadFlag = rdoBadFlag.EditValue.ObjectNullString();
                _strRetrievalFlag = rdoRetrievalFlag.EditValue.ObjectNullString();
                _strStInspFlag = rdoStInspFlag.EditValue.ObjectNullString();
                _strSNDesFlag = rdoSNDesFlag.EditValue.ObjectNullString();
                _strVendor = gleVendor.EditValue.ObjectNullString();;
                _strErpLocCode = txtErpLocCode.EditValue.ObjectNullString();
                _strPurchaseflag = rdoPurchaseflag.EditValue.ObjectNullString();
                _strRepairflag = rdoRepairflag.EditValue.ObjectNullString();
                _strOtherflag = rdoOtherflag.EditValue.ObjectNullString();
                _strPubFlag = rdoPubFlag.EditValue.ObjectNullString();
                _strFifoFlag = rdoFifoFlag.EditValue.ObjectNullString();

                if (!this.SaveData(_strWH, _strWHLoc, _strWHLocName, _strProdLine, _strUseFlag,
                              _strRemarks, _strLocType, _strBadFlag, _strRetrievalFlag, _strStInspFlag,
                              _strSNDesFlag, _strVendor, _strErpLocCode, "N", _strPurchaseflag,
                              _strRepairflag, _strOtherflag, _strPubFlag, _strFifoFlag))
                {
                    this.MainButton_INIT.PerformClick();
                    gleWH.EditValue = _strWH;
                    return;
                }

                this.MainButton_INIT.PerformClick();
                gleWH.EditValue = _strWH;
                this.MainButton_New.PerformClick();


            }
            
        }

        public void DeleteButton_Click()
        {
        }

        public void PrintButton_Click()
        {
        }

        public void RefreshButton_Click()
        {
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);
            this.GetGridViewList(gleWH.EditValue.ObjectNullString());
        }

        #endregion

        #region 함수

        private void Set_Init()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWH
                                                       , "GPKGBAS_BASE.GET_WAREHOUSE"
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
                                                       , "WAREHOUSE"
                                                       , "WAREHOUSENAME"
                                                       , "WAREHOUSE, WAREHOUSENAME, REMARKS"
                                                       );


            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWarehouse
                                                       , "GPKGBAS_BASE.GET_WAREHOUSE"
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
                                                       , "WAREHOUSE"
                                                       , "WAREHOUSENAME"
                                                       , "WAREHOUSE, WAREHOUSENAME, REMARKS"
                                                       );


            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleProdLine
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
                                                       , "PRODLINE, PRODLINENAME, REMARKS"
                                                       );


            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleVendor
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
                                                       , "Y"
                                                       , ""
                                                       , "0" }
                                                       , "VENDOR"
                                                       , "VENDORNAME"
                                                       , "VENDOR, VENDORNAME"
                                                       );


            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleLocType
                                                       , "GPKGBAS_BASE.GET_LOC_TYPE"
                                                       , 1
                                                       , new string[] { 
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT }
                                                       , "LOCTYPE"
                                                       , "KORDESC"
                                                       , "LOCTYPE, KORDESC"
                                                       );

        }

        private void GetGridViewList(string p_strWH)
        {
            BASE_DXGridHelper.Bind_Grid( gcList
                                       , "PKGBAS_BASE.GET_LOCATION"
                                       , 1
                                       , new string[] {
                                         "A_CLIENT"
                                       , "A_COMPANY"
                                       , "A_PLANT"
                                       , "A_WAREHOUSE"
                                       , "A_VIEW" }
                                       , new string[] {
                                         Global.Global_Variable.CLIENT
                                       , Global.Global_Variable.COMPANY
                                       , Global.Global_Variable.PLANT
                                       , p_strWH
                                       , "2" }
                                       , true
                                       , "WHLOC, WHLOCNAME, PRODLINE, USEFLAG, REMARKS "
                                       );

            gvList.BestFitColumns();

        }

        private bool SaveData(string p_strWH, string p_strWHLoc, string p_strWHLocName, string p_strProdLine, string p_strUseFlag, 
                              string p_strRemarks, string p_strLocType, string p_strBadFlag, string p_strRetrievalFlag, string p_strStInspFlag,
                              string p_strSNDesFlag, string p_strVendor, string p_strErpLocCode, string p_strNewflag, string p_strPurchaseflag, 
                              string p_strRepairflag, string p_strOtherflag, string p_strPubFlag, string p_strFifoFlag)
        {
            bool _blReturn = BASE_db.Execute_Proc( "PKGBAS_BASE.PUT_LOCATION"
                                                 , 1
                                                 , new string[] { 
                                                   "A_CLIENT"
                                                 , "A_COMPANY"
                                                 , "A_PLANT"
                                                 , "A_WHLOC"
                                                 , "A_WHLOCNAME"
                                                 , "A_WAREHOUSE"
                                                 , "A_PRODLINE"
                                                 , "A_USEFLAG"
                                                 , "A_REMARKS"
                                                 , "A_LOCTYPE"
                                                 , "A_BADWHFLAG"
                                                 , "A_RETRIEVALFLAG"
                                                 , "A_STOCKINSPFLAG"
                                                 , "A_SERIALDESTFLAG"
                                                 , "A_VENDOR"
                                                 , "A_ERPLOCCODE"
                                                 , "A_USERID"
                                                 , "A_PURCHASEFLAG"
                                                 , "A_REPAIRFLAG"
                                                 , "A_OTHERINFLAG"
                                                 , "A_PUBFLAG"
                                                 , "A_FIFOFLAG"
                                                 , "A_NEWFLAG" }
                                                 , new string[] {
                                                   Global.Global_Variable.CLIENT
                                                 , Global.Global_Variable.COMPANY
                                                 , Global.Global_Variable.PLANT
                                                 , p_strWHLoc
                                                 , p_strWHLocName
                                                 , p_strWH
                                                 , p_strProdLine
                                                 , p_strUseFlag
                                                 , p_strRemarks
                                                 , p_strLocType
                                                 , p_strBadFlag
                                                 , p_strRetrievalFlag
                                                 , p_strStInspFlag
                                                 , p_strSNDesFlag
                                                 , p_strVendor
                                                 , p_strErpLocCode
                                                 , Global.Global_Variable.EHRCODE
                                                 , p_strPurchaseflag
                                                 , p_strRepairflag
                                                 , p_strOtherflag
                                                 , p_strPubFlag
                                                 , p_strFifoFlag
                                                 , p_strNewflag }
                                                 , true
                                                 );

            return _blReturn;

        }

        

        #endregion

        #region 일반 이벤트

       
        private void gvList_Click(object sender, EventArgs e)
        {
            if (!(sender is GridView))
            {
                return;
            }

            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo gridHitINFO = gvList.EX_GetClickHitInfo(e);

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
                if (dr["WHLOC"] != null)
                {
                    // 주키가 두개일 경우 AND 문으로 조건을 다중으로 준다.
                    if (dr["WHLOC"].ToString() == gvList.GetDataRow(e.RowHandle)["WHLOC"].ToString())
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
            }
        }

        #endregion

        private void gleWH_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            gleWH.Properties.View.ActiveFilter.Clear();
        }

        private void btnWHManage_Click(object sender, EventArgs e)
        {
            using (PopUp.MSTA210_PopUp frm = new PopUp.MSTA210_PopUp())
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MainButton_INIT.PerformClick();
                    gleWH.EditValue = frm.Warehouse;
                }
            }
        }

        private void gleWH_EditValueChanged(object sender, EventArgs e)
        {
            this.GetGridViewList(gleWH.EditValue.ObjectNullString());
        }

        
    }
}
