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

namespace HAENGSUNG_HNSMES_UI.Forms.SYS.PopUp
{
    public partial class POP_SYSA202 : BASE.Form
    {
        #region 생성

        private string m_strCommGrp = "";

        public string CommGrp
        {
            get { return m_strCommGrp; }
        }


        public POP_SYSA202()
        {
            InitializeComponent();
        }
        
        private void POP_SYSA202_Load(object sender, EventArgs e)
        {

        }
        private void POP_SYSA202_Shown(object sender, EventArgs e)
        {
            // 리스트 그룹 호출
            this.GetGridViewList();

            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);
            this.btnSave.Enabled = false;
        }        

        #endregion

        #region 버튼 이벤트

        private void btnInit_Click(object sender, EventArgs e)
        {
            // 초기화 관련 구현은 여기에 구현 ***
            // 상세 항목들을 모두 클리어 한다.
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);

            this.GetGridViewList();

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

            gvList.EX_AddNewRow();
            rdgDispFlag.SelectedIndex = 0;
            rdgUseFlag.SelectedIndex = 0;
            this.txtCommGr.Focus();
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

            string _strCommGr = "";
            string _strCommName = "";
            string _strDispFlag = "";
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
                            _strCommGr = _dr["COMMGRP"].ObjectNullString();
                            _strCommName = _dr["COMMGRPNAME"].ObjectNullString();
                            _strDispFlag = _dr["DISPFLAG"].ObjectNullString();
                            _strUseFlag = _dr["USEFLAG"].ObjectNullString();
                            _strRemarks = _dr["REMARKS"].ObjectNullString();

                            if (!SaveData(_strCommGr, _strCommName, _strDispFlag, _strUseFlag, _strRemarks))
                                return;
                            break;

                        default:
                            break;
                    }
                }

                this.btnInit_Click(null, null);

                //마지막 처리 된 값쪽에 포커스를 이동 시킵니다. 사용시에 주석을 해제하고 수정하세요.
                BASE_clsDevexpressGridUtil.GetFocuseRowCell(gvList, "COMMGRP", _strCommGr);
            }
            else if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
            {
                // ***** 신규 관련 프로시져를 여기에 구현을 합니다.
                _strCommGr = txtCommGr.EditValue.ObjectNullString();
                _strCommName = txtCommGrName.EditValue.ObjectNullString();
                _strDispFlag = rdgDispFlag.EditValue.ObjectNullString();
                _strUseFlag = rdgUseFlag.EditValue.ObjectNullString();
                _strRemarks = memRemarks.EditValue.ObjectNullString();

                if (!SaveData(_strCommGr, _strCommName, _strDispFlag, _strUseFlag, _strRemarks))
                    return;
                
                // 신규 항목 데이터를 처리하면 그리드를 리프레쉬 합니다.
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
            this.Close();
        }

        #endregion

        #region 함수

        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid(
                                          gcList
                                        , "PKGSYS_COMM.GET_COMMGRP"
                                        , 1
                                        , new string[] { 
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_DISPFLAG"
                                                       , "A_VIEW"
                                                       }
                                        , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , "0"
                                                       , "0"
                                                       }
                                        , true
                                        , "COMMGRP, COMMGRPNAME, DISPFLAG, USEFLAG, REMARKS"
                                       );
            // 컬럼 조절
            gvList.BestFitColumns();
        }

        private bool SaveData(string p_strCommGr, string p_strCommGrName, string p_strDispFlag,
                                string p_strUseFlag, string p_strRemarks)
        {
            bool _Rtn = BASE_db.Execute_Proc(
                                         "PKGSYS_COMM.PUT_COMMGRP"
                                        , 1
                                        , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_COMMGRP"
                                                       , "A_GRPNAME"
                                                       , "A_DISPFLAG"
                                                       , "A_USEFLAG"
                                                       , "A_REMARKS"
                                                       }
                                        , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , p_strCommGr
                                                       , p_strCommGrName
                                                       , p_strDispFlag
                                                       , p_strUseFlag
                                                       , p_strRemarks
                                                       }
                                        ,true
                                       );

            return _Rtn;
        }

        #endregion

        #region 일반 이벤트

        private void gvList_Click(object sender, EventArgs e)
        {
            //if (!(sender is GridAlias.GridView))
            //{
            //    return;
            //}

            //GridAlias.GridView gridView = sender as GridAlias.GridView;
            //DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo gridHitINFO = BASE_clsDevexpressGridUtil.GetClickHitInfo(gvList, e);

            //if (gridHitINFO.InRow && gridHitINFO.InColumn)
            //{
            //    /// ============================================================
            //    /// 선택된 Row의 정보를 가져올려면 아래에 구현을 하면 된다.
            //    int RowIdx = gridHitINFO.RowHandle;
            //    int ColIdx = gridHitINFO.Column.AbsoluteIndex;
            //}

            //if (gridHitINFO.InRowCell)
            //{
            //}

            //if (gridHitINFO.InColumn)
            //{
            //}

            //if (gridHitINFO.InGroupColumn)
            //{
            //}

            //if (gridHitINFO.InColumnPanel)
            //{
            //}

            //if (gridHitINFO.InFilterPanel)
            //{
            //}

            //if (gridHitINFO.InGroupColumn)
            //{
            //}
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
            DataTable changes = BASE_clsDevexpressGridUtil.GetChangedData(gcList, DataRowState.Modified);

            if (changes == null)
                return;

            //if (e.RowHandle == -1)
            //    return;

            if (e.RowHandle < 0)
                return;

            // 수정된 키값 필드를 입력한다.
            foreach (DataRow dr in changes.Rows)
            {
                if (dr["COMMGRP"] != null)
                {
                    // 주키가 두개일 경우 AND 문으로 조건을 다중으로 준다.
                    if (dr["COMMGRP"].ToString() == gvList.GetDataRow(e.RowHandle)["COMMGRP"].ToString())
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

                string _strCommGrp = gvList.GetRowCellValue(RowIdx, "COMMGRP").ObjectNullString();
                m_strCommGrp = _strCommGrp;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        
    }
}
