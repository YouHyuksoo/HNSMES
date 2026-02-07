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

namespace HAENGSUNG_HNSMES_UI.Forms.SYS
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : SYSA203<br/>
    ///      기능 : 공통 코드 마스터 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    public partial class SYSA203 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
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

        public SYSA203()
        {
            InitializeComponent();
        }

        private void SYSA203_Load(object sender, EventArgs e)
        {

        }
        private void SYSA203_Shown(object sender, EventArgs e)
        {
            MainButton_INIT.PerformClick();
        }
        

        #endregion

        #region 버튼이벤트

        public void InitButton_Click()
        {
            // 초기화 관련 구현은 여기에 구현 ***
            gleCommGrp.Enabled = true;
            gleCommGrp.EditValue = null;
            btnCommGrMng.Enabled = true;
            // 상세 항목들을 모두 클리어 한다.
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);
            this.Set_Init(); 
            this.GetGridViewList();
            
        }
        
        public void NewButton_Click()
        {
            gleCommGrp.Enabled = false;
            btnCommGrMng.Enabled = false;
            // 신규 관련 구현은 여기에 구현.
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New);

            // 그리드뷰에 새로운 행과 초기값을 지정한다.
            gvList.EX_AddNewRow();
            rdgGrUse.SelectedIndex = 0;
            txtCommCode.Focus();
        }

        public void EditButton_Click()
        {
            gleCommGrp.Enabled = false;
            btnCommGrMng.Enabled = false;
            // 수정 관련 구현은 여기에 구현.
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit);
        }

        public void SaveButton_Click()
        {
            // 저장전에 필수 항목에 대한 Null 값을 초기화 합니다.
            // 유효성검사 다시 수행
            base.baseDxErrorProvider.ClearErrors();
            ValidateChildren(ValidationConstraints.Visible);

            string _strCommGr = "";
            string _strCommCode = "";
            string _strCommCodeName;
            string _strRemarks;
            string _strUseFlag;
            string _strNValue;
            string _strCValue;

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
                            _strCommGr = _dr["COMMGRP"].ObjectNullString();
                            _strCommCode = _dr["COMMCODE"].ObjectNullString();
                            _strCommCodeName = _dr["COMMNAME"].ObjectNullString();
                            _strNValue = _dr["NVALUE"].ObjectNullString();
                            _strCValue = _dr["CVALUE"].ObjectNullString();
                            _strUseFlag = _dr["USEFLAG"].ObjectNullString();
                            _strRemarks = _dr["REMARKS"].ObjectNullString();

                            if (!SaveData(_strCommGr, _strCommCode, _strCommCodeName, _strNValue, _strCValue, _strUseFlag, _strRemarks, "N"))
                                return;

                            break;

                        default:
                            break;
                    }
                }

                MainButton_INIT.PerformClick();
                gleCommGrp.EditValue = _strCommGr;
                this.GetGridViewList();

                //마지막 처리 된 값쪽에 포커스를 이동 시킵니다. 사용시에 주석을 해제하고 수정하세요.
                BASE_clsDevexpressGridUtil.GetFocuseRowCell(gvList, "COMMCODE", _strCommCode);
            }
            else if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
            {
                // ***** 신규 관련 프로시져를 여기에 구현을 합니다.
                _strCommGr = gleCommGrp.EditValue.ObjectNullString();
                _strCommCode = gleCommGrp.EditValue.ObjectNullString() + "-" + txtCommCode.EditValue.ObjectNullString();
                _strCommCodeName = txtCommCodeName.EditValue.ObjectNullString();
                _strNValue = speNValue.EditValue.ObjectNullString();
                _strCValue = txtCValue.EditValue.ObjectNullString();
                _strUseFlag = rdgGrUse.EditValue.ObjectNullString();
                _strRemarks = memRemarks.EditValue.ObjectNullString();

                if (!SaveData(_strCommGr, _strCommCode, _strCommCodeName, _strNValue, _strCValue, _strUseFlag, _strRemarks, "Y"))
                    return;

                // 신규 항목 데이터를 처리하면 그리드를 리프레쉬 합니다.
                MainButton_INIT .PerformClick();
                gleCommGrp.EditValue = _strCommGr;
                MainButton_New.PerformClick();
            }
        }

        public void RefreshButton_Click()
        {
        }

        #region Unused
        public void PrintButton_Click()
        {
        }

        public void StopButton_Click()
        {
        }

        public void SearchButton_Click()
        {            
        }

        public void DeleteButton_Click()
        {
        } 
        #endregion

        #endregion

        #region 함수
        //공통코드
        private void Set_Init()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleCommGrp
                                                       , "PKGSYS_COMM.GET_COMMGRP"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_SYSCODE"
                                                       , "A_DISPFLAG"
                                                       , "A_VIEW" }
                                                       , new string[] { 
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , Global.Global_Variable.SYSTEMCODE
                                                       , "0"
                                                       , "0" }
                                                       , "COMMGRP"
                                                       , "COMMGRPNAME"
                                                       , "COMMGRP,COMMGRPNAME, REMARKS"
                                                       );
        }

        //공통코드 조회
        private void GetGridViewList()
        {  
            BASE_DXGridHelper.Bind_Grid( gcList
                                       , "PKGSYS_COMM.GET_COMM"
                                       , 1
                                       , new string[] { 
                                         "A_CLIENT"
                                       , "A_COMPANY"
                                       , "A_PLANT"
                                       , "A_COMMGRP"
                                       , "A_VIEW" }
                                       , new string[] {       
                                         Global.Global_Variable.CLIENT
                                       , Global.Global_Variable.COMPANY
                                       , Global.Global_Variable.PLANT
                                       , gleCommGrp.EditValue.ObjectNullString()
                                       , "1" }
                                       , true
                                       );

            // 컬럼 조절
            gvList.Columns["COMMGRP"].Visible = false;

            gvList.Columns["NVALUE"].DisplayFormat.FormatString = "N02";
            gvList.Columns["NVALUE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            gvList.BestFitColumns();
        }

        //저장
        private bool SaveData(string p_strCommGr, string p_strCommCode, string p_strCommCodeName, string p_strNValue, 
                            string p_strCValue, string p_strUseFlag, string p_strRemarks, string p_strNewFlag)
        {
            bool _Rtn = BASE_db.Execute_Proc( "PKGSYS_COMM.PUT_COMM"
                                            , 1
                                            , new string[] { 
                                              "A_CLIENT"
                                            , "A_COMPANY"
                                            , "A_PLANT"
                                            , "A_COMMGRP"
                                            , "A_COMMCODE"
                                            , "A_COMMNAME"
                                            , "A_NVALUE"
                                            , "A_CVALUE"
                                            , "A_USEFLAG"
                                            , "A_REMARKS" 
                                            , "A_NEWFLAG" }
                                            , new string[] {
                                              Global.Global_Variable.CLIENT
                                            , Global.Global_Variable.COMPANY
                                            , Global.Global_Variable.PLANT
                                            , p_strCommGr
                                            , p_strCommCode
                                            , p_strCommCodeName
                                            , p_strNValue
                                            , p_strCValue
                                            , p_strUseFlag
                                            , p_strRemarks
                                            , p_strNewFlag }
                                            , true
                                            );

            return _Rtn;
        }
        #endregion

        #region 일반이벤트

        private void btnCommGrMng_Click(object sender, EventArgs e)
        {
            using (PopUp.POP_SYS01 frm = new PopUp.POP_SYS01())
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MainButton_INIT.PerformClick();
                    gleCommGrp.EditValue = frm.CommGrp;
                }
            }
        }

        private void gleCommGrp_EditValueChanged(object sender, EventArgs e)
        {
            this.GetGridViewList();
        }

        private void gvList_Click(object sender, EventArgs e)
        {
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
            DataTable changes = BASE_clsDevexpressGridUtil.GetChangedData(gcList, DataRowState.Modified);

            if (changes == null)
                return;

            if (e.RowHandle < 0)
                return;

            // 수정된 키값 필드를 입력한다.
            foreach (DataRow dr in changes.Rows)
            {
                if (dr["COMMCODE"] != null)
                {
                    // 주키가 두개일 경우 AND 문으로 조건을 다중으로 준다.
                    if (dr["COMMCODE"].ToString() == gvList.GetDataRow(e.RowHandle)["COMMCODE"].ToString())
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
            }
        }

        #endregion

        

        
    }
}
