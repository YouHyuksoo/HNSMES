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

namespace HAENGSUNG_HNSMES_UI.Forms.MST.PopUp
{
    public partial class MSTA210_PopUp : HAENGSUNG_HNSMES_UI.Forms.BASE.Form
    {
        #region 생성

        private string m_strWarehouse = "";

        public string Warehouse
        {
            get { return m_strWarehouse; }
        }


        public MSTA210_PopUp()
        {
            InitializeComponent();
        }
        private void MSTA210_PopUp_Load(object sender, EventArgs e)
        {

        }

        private void MSTA210_PopUp_Shown(object sender, EventArgs e)
        {
            this.btnInit_Click(null, null);
        }

        #endregion

        #region 버튼 이벤트

        private void btnInit_Click(object sender, EventArgs e)
        {
            // 초기화 관련 구현은 여기에 구현 ***
            // 상세 항목들을 모두 클리어 한다.
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);

            this.GetGridViewList();
            this.Set_Init();
            // 버튼을 초기화
            this.btnNew.Enabled = true;
            this.btnEdit.Enabled = true;
            this.btnSave.Enabled = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            // 신규 관련 구현은 여기에 구현.
            this.btnNew.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnSave.Enabled = true;
            
            // 신규 항목을 추가하기전에 기존에 수정된 데이터를 저장하고 신규 추가를 한다.
            this.btnSave_Click(null, null);

            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New);
            
            // 그리드뷰에 새로운 행과 초기값을 지정한다.
            gvList.EX_AddNewRow();

            rdgUseFlag.SelectedIndex = 0;
            rdgWHType.SelectedIndex = 0;
            
            this.txtWH.Focus();
        }
        private void btnSave_Click(object sender, EventArgs e)
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

            // ****** 마지막 수정항목을 데이터셋에 적용 시킬려면 포커스를 이동을 한다.
            gvList.FocusedRowHandle = -1;

            // 수정,추가,변경 된 데이터를 모두 가져온다.

            DataTable _dt = BASE_clsDevexpressGridUtil.GetChangedData(gcList);

            if (_dt == null)
            {
                return;
            }

            // 변경된 데이터가 없으면 return.
            if (_dt.Rows.Count == 0) return;

            string _strWH = "";
            string _strWHName = "";
            string _strWHType = "";
            string _strPlant = "";
            string _strVendor = "";
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
                            _strWH = _dr["WAREHOUSE"].ObjectNullString();
                            _strWHName = _dr["WAREHOUSENAME"].ObjectNullString();
                            _strWHType = _dr["WAREHOUSETYPE"].ObjectNullString();
                            _strPlant = _dr["PLANT"].ObjectNullString();
                            _strVendor = _dr["VENDOR"].ObjectNullString();
                            _strUseFlag = _dr["USEFLAG"].ObjectNullString();
                            _strRemarks = _dr["REMARKS"].ObjectNullString();

                            this.SaveData(_strWH, _strWHName, _strPlant, _strWHType, _strVendor, _strUseFlag, _strRemarks, "N");
                            break;

                        default:
                            break;
                    }
                }

                this.btnInit_Click(null, null);

                //마지막 처리 된 값쪽에 포커스를 이동 시킵니다. 사용시에 주석을 해제하고 수정하세요.
                //BASE_clsDevexpressGridUtil.GetFocuseRowCell(gvList, "COMMGRP", _strCommGr);
            }
            else if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
            {
                // ***** 신규 관련 프로시져를 여기에 구현을 합니다.
                _strWH = txtWH.Text.Trim() + "";
                _strWHName = txtWHName.Text.Trim() + "";
                _strWHType = rdgWHType.EditValue + "";
                _strPlant = glePlant.EditValue + "";
                _strVendor = gleVendor.EditValue.ObjectNullString();
                _strUseFlag = rdgUseFlag.EditValue + "";
                _strRemarks = memRemarks.Text.Trim() + "";

                this.SaveData(_strWH, _strWHName, _strPlant, _strWHType, _strVendor, _strUseFlag, _strRemarks, "Y");

                this.btnInit_Click(null, null);
                this.btnNew_Click(null, null);

            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // 수정 관련 구현은 여기에 구현.
            this.btnNew.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnSave.Enabled = true;

            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        #endregion

        #region 함수

        private void Set_Init()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( glePlant
                                                       , "PKGBAS_BASE.GET_PLANT"
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
                                                       , "PLANT"
                                                       , "PLANTNAME"
                                                       , "PLANT, PLANTNAME"
                                                       );

            glePlant.Properties.View.OptionsView.ShowGroupPanel = false;

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
                                                       , "Y"
                                                       , "Y"
                                                       , "Y"
                                                       , "0" }
                                                       , "VENDOR"
                                                       , "VENDORNAME"
                                                       , "VENDOR, VENDORNAME, REMARKS"
                                                       );
        }

        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid( gcList
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
                                       , "1" }
                                       , true
                                       , "WAREHOUSE, WAREHOUSENAME, WAREHOUSETYPE, VENDORNAME, USEFLAG, REMARKS "
                                       );

            gvList.BestFitColumns();
        }

        private void SaveData(string p_strWH, string p_strWHName, string p_strPlant, string p_strWHType, string p_strVendor, string p_strUseFlag, string p_strRemarks, string p_strNewflag)
        {
            BASE_db.Execute_Proc( "PKGBAS_BASE.PUT_WAREHOUSE"
                                , 1
                                , new string[] {
                                  "A_CLIENT"
                                , "A_COMPANY"
                                , "A_PLANT"
                                , "A_WAREHOUSE"
                                , "A_WAREHOUSENAME"
                                , "A_WAREHOUSETYPE"
                                , "A_VENDOR"
                                , "A_USEFLAG"
                                , "A_REMARKS"
                                , "A_USERID"
                                , "A_NEWFLAG" }
                                , new string[] {
                                  Global.Global_Variable.CLIENT
                                , Global.Global_Variable.COMPANY
                                , Global.Global_Variable.PLANT
                                , p_strPlant
                                , p_strWH
                                , p_strWHName
                                , p_strWHType
                                , p_strVendor
                                , p_strUseFlag
                                , p_strRemarks
                                , Global.Global_Variable.USER_ID
                                , p_strNewflag }
                                , true
                                );
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
                if (e.RowHandle == gvList.RowCount - 1)
                {
                    e.Allow = false;
                }
                else
                {
                    e.Allow = true;
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
                if (dr["WAREHOUSE"] != null)
                {
                    // 주키가 두개일 경우 AND 문으로 조건을 다중으로 준다.
                    if (dr["WAREHOUSE"].ToString() == gvList.GetDataRow(e.RowHandle)["WAREHOUSE"].ToString())
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
            }
        }

        #endregion

        private void gvList_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo gridHitINFO = BASE_clsDevexpressGridUtil.GetClickHitInfo(gvList, e);

            if (gridHitINFO.InRow)
            {
                /// ============================================================
                /// 선택된 Row의 정보를 가져올려면 아래에 구현을 하면 된다.
                int RowIdx = gridHitINFO.RowHandle;

                string _strWarehouse = gvList.GetRowCellValue(RowIdx, "WAREHOUSE").ObjectNullString();
                m_strWarehouse = _strWarehouse;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}
