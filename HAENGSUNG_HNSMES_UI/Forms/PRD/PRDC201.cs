using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HAENGSUNG_HNSMES_UI.Class;
using GridAlias = DevExpress.XtraGrid.Views.Grid;

using NGS.WCFClient.DatabaseService;
using DevExpress.XtraGrid.Views.Grid;

namespace HAENGSUNG_HNSMES_UI.Forms.PRD
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : PRDC201<br/>
    ///      기능 : 일별 생산 계획 등록 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>

    public partial class PRDC201 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {
        #region 생성

        public PRDC201()
        {
            InitializeComponent();
        }

        private void PRDC201_Load(object sender, EventArgs e)
        {
        }

        private void PRDC201_Shown(object sender, EventArgs e)
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
            // 신규 관련 구현은 여기에 구현.

            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New);

            // 그리드뷰에 새로운 행과 초기값을 지정한다.
            gvList.EX_AddNewRow();
            rdgUseFlag.SelectedIndex = 0;

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
            this.GetGridViewList();
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

            // ****** 마지막 수정항목을 데이터셋에 적용 시킬려면 포커스를 이동을 한다.
            //gvList.FocusedRowHandle = -1;


            string _strDate = "";
            string _StrOper = "";
            string _strEQP = "";
            string _strItemcode = "";
            string _strQty = "";
            string _strHour = "";
            string _strUseFlag = "";
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
                            if (_dr["PLANDATE"].ObjectNullString() != "")
                                _strDate = Convert.ToDateTime(_dr["PLANDATE"].ObjectNullString()).ToString("yyyyMMdd");
                            _strItemcode = _dr["ITEMCODE"] + "";
                            _StrOper = _dr["OPER"] + "";
                            _strQty = spiQty.EditValue.ObjectNullString();
                            _strHour = spiHour.EditValue.ObjectNullString();
                            _strUseFlag = rdgUseFlag.EditValue.ObjectNullString();
                            _strRemarks = memRemarks.EditValue.ObjectNullString();

                            if (!this.SaveData(_strDate, _strEQP, _StrOper, _strItemcode,  _strQty, _strHour, _strUseFlag, _strRemarks))
                                return;
                            break;

                        default:
                            break;
                    }
                }

                MainButton_INIT.PerformClick();
                //마지막 처리 된 값쪽에 포커스를 이동 시킵니다. 사용시에 주석을 해제하고 수정하세요.
                BASE_clsDevexpressGridUtil.GetFocuseRowCell(gvList, "ITEMCODE", _strItemcode);

            }
            else if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
            {
                // ***** 신규 관련 프로시져를 여기에 구현을 합니다.
                if (dteDate.EditValue != null)
                    _strDate = dteDate.DateTime.ToString("yyyyMMdd");

                _StrOper = gleOper.EditValue.ObjectNullString();
                _strItemcode = glePartNo.EditValue.ObjectNullString();
                _strQty = spiQty.EditValue.ObjectNullString();
                _strHour = spiHour.EditValue.ObjectNullString();
                _strUseFlag = rdgUseFlag.EditValue.ObjectNullString();
                _strRemarks = memRemarks.EditValue.ObjectNullString();

                if (!this.SaveData(_strDate, _strEQP, _StrOper, _strItemcode, _strQty, _strHour, _strUseFlag, _strRemarks)) 
                    return;

                MainButton_INIT.PerformClick();
                MainButton_New.PerformClick();

                dteDate.DateTime = DateTime.ParseExact(_strDate, "yyyyMMdd", null);
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
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( glePartNo
                                                       , "GPKGPRD_PROD.GET_PARTNO"
                                                       , 1
                                                       , new string[] { 
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT }
                                                       , "ITEMCODE"
                                                       , "PARTNO"
                                                       , "ITEMCODE, PARTNO"
                                                       );

            /*작업지시 생성 공정 조회 */
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleOper
                                                       , "GPKGPRD_PROD.GET_OPER"
                                                       , 1
                                                       , new string[] { 
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT" }
                                                       , new string[] { 
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT }
                                                       , "OPER"
                                                       , "OPERNAME"
                                                       , "OPER, OPERNAME"
                                                       );

           
        }

        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid( gcList
                                       , "PKGPRD_CURRENT.GET_DAILY_WORKPLAN"
                                       , 1
                                       , new string[] {  
                                         "A_CLIENT"
                                       , "A_COMPANY"
                                       , "A_PLANT"
                                       , "A_SDATE"
                                       , "A_EDATE" }
                                       , new string[] {  
                                         Global.Global_Variable.CLIENT
                                       , Global.Global_Variable.COMPANY
                                       , Global.Global_Variable.PLANT
                                       , dteFromTo.StartDate
                                       , dteFromTo.EndDate  }
                                       , true
                                       , ""
                                       );

            gvList.BestFitColumns();

        }

        private bool SaveData(string p_Date, string p_EQP, string p_Oper, string p_Itemcode, string p_strQty, string p_strHour, string p_strUseFlag, string p_strRemarks)
        {
            bool _blReturn = BASE_db.Execute_Proc( "PKGPRD_CURRENT.SET_DAILY_WORKPLAN"
                                                 , 3
                                                 , new string[] {
                                                   "A_CLIENT"
                                                 , "A_COMPANY"
                                                 , "A_PLANT"
                                                 , "A_PLANDATE"
                                                 , "A_OPER"
                                                 , "A_ITEMCODE"
                                                 , "A_PLANQTY"
                                                 , "A_PLANHOUR"
                                                 , "A_USEFLAG"
                                                 , "A_REMARKS"
                                                 , "A_USER" }
                                                 , new string[] {
                                                   Global.Global_Variable.CLIENT
                                                 , Global.Global_Variable.COMPANY
                                                 , Global.Global_Variable.PLANT
                                                 , p_Date
                                                 , p_Oper
                                                 , p_Itemcode
                                                 , p_strQty
                                                 , p_strHour
                                                 , p_strUseFlag
                                                 , p_strRemarks
                                                 , Global.Global_Variable.USER_ID }
                                                 , true);

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
                if (dr["ITEMCODE"] != null)
                {
                    // 주키가 두개일 경우 AND 문으로 조건을 다중으로 준다.
                    if (dr["ITEMCODE"].ToString() == gvList.GetDataRow(e.RowHandle)["ITEMCODE"].ToString())
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
            }

        }

        #endregion       

    }
}
