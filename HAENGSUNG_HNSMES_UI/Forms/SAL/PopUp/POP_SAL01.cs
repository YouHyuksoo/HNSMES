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

namespace HAENGSUNG_HNSMES_UI.Forms.SAL.PopUp
{
    // 출하 불량반납 Tray 구성

    public partial class POP_SAL01 : BASE.Form
    {
        #region 생성

        public POP_SAL01()
        {
            InitializeComponent();
        }
        private void POP_SAL01_Load(object sender, EventArgs e)
        {

        }

        private void POP_SAL01_Shown(object sender, EventArgs e)
        {
            // 리스트 그룹 호출
            //this.GetGridViewList();
        }

        #endregion

        #region 버튼 이벤트
                
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

                iDATMessageBox.OKMessage("등록 되었습니다.", this.Text, 3);

                //this.btnInit_Click(null, null);

                //마지막 처리 된 값쪽에 포커스를 이동 시킵니다. 사용시에 주석을 해제하고 수정하세요.
                BASE_clsDevexpressGridUtil.GetFocuseRowCell(gvList, "COMMGRP", _strCommGr);
            }
            else if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
            {
                // ***** 신규 관련 프로시져를 여기에 구현을 합니다.
                //_strCommGr = txtCommGr.EditValue.ObjectNullString();
                //_strCommName = txtCommGrName.EditValue.ObjectNullString();
                //_strDispFlag = rdoDispFlag.EditValue.ObjectNullString();
                //_strUseFlag = rdoUseFlag.EditValue.ObjectNullString();
                //_strRemarks = memRemarks.EditValue.ObjectNullString();

                if (!SaveData(_strCommGr, _strCommName, _strDispFlag, _strUseFlag, _strRemarks))
                    return;
                
                iDATMessageBox.OKMessage("등록 되었습니다.", this.Text, 3);
                

                // 신규 처리 한 곳으로 포커스를 이동 시킵니다. 사용시에 주석을 해제하고 수정하세요.
                BASE_clsDevexpressGridUtil.GetFocuseRowCell(gvList, "COMMGRP", _strCommGr);
            }
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
                                                     "A_SYSCODE"
                                                   , "A_DISPFLAG"
                                                   , "A_VIEW"
                                                  }
                                   , new string[] { 
                                                     Global.Global_Variable.SYSTEMCODE
                                                   , "0"
                                                   , "0"
                                                  }
                                   , true
                                   , "COMMGRP, COMMGRPNAME, USEFLAG"
                                  );
            // 컬럼 조절
            gvList.BestFitColumns();
        }

        private bool SaveData(string p_strCommGr, string p_strCommGrName, string p_strDispFlag,
                                string p_strUseFlag, string p_strRemarks)
        {
            bool _Rtn = BASE_db.Execute_Proc(
                                  "PKGSYS_COMM.PUT_COMMONGR"
                                , 1
                                , new string[] {
                                                 "A_SYSCODE"
                                                ,"A_COMMGRP"
                                                ,"A_GRPNAME"
                                                ,"A_DISPFLAG"
                                                ,"A_USEFLAG"
                                                ,"A_REMARKS"
                                               }
                                , new string[] {
                                                   Global.Global_Variable.SYSTEMCODE
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

       

        #endregion
        
    }
}
