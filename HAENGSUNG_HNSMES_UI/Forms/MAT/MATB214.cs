using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

// DevExpress namespace
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraGrid.Views.Grid;

// User namespace
using HAENGSUNG_HNSMES_UI.Class;
using GridAlias = DevExpress.XtraGrid.Views.Grid;
//using Google.API.Translate;
using HAENGSUNG_HNSMES_UI.WebService.Access;
using HAENGSUNG_HNSMES_UI.WebService.Business;

namespace HAENGSUNG_HNSMES_UI.Forms.MAT
{
    public partial class MATB214 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {
        #region [Form Event]

        public MATB214()
        {
            InitializeComponent();           
        }

        private void MATB214_Load(object sender, EventArgs e)
        {
            this.Set_Init();            
        }

        private void MATB214_Shown(object sender, EventArgs e)
        {

        }

        #endregion

        #region [Button Event]

        public void InitButton_Click()
        {
            // 초기화 관련 구현은 여기에 구현 ***

            ////  현재 프로그램 모드정보를 변경한다.
            ////  IDAT.Devexpress.FORM.UPDATEITEMTYPE.None = 초기화 모드
            ////  IDAT.Devexpress.FORM.UPDATEITEMTYPE.New  = 신규 모드
            ////  IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit = 수정 모드

            //base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);

            this.Set_Init();
        }


        public void NewButton_Click()
        {
            
        }

        public void EditButton_Click()
        {
            // 수정 버튼 클릭 이벤트
        }


        public void StopButton_Click()
        {
            // 중지 버튼 클릭 이벤트
        }

        public void SearchButton_Click()
        {
            // 검색 버튼 클릭 이벤트
            this.GetGridViewList();
        }

        public void SaveButton_Click()
        {
            // 저장 버튼 클릭 이벤트         
        }


        public void PrintButton_Click()
        {
            string _sResponseNo = gvList.GetFocusedRowCellValue("RESPONSENO").ObjectNullString();

            if (_sResponseNo == "")
            {
                iDATMessageBox.ErrorMessage("MSG_ER_COMM_087", this.Text, 3); //불출지시번호를 입력하세요.
                return;
            }

            // 출력 버튼 클릭 이벤트
            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result =
                BASE_db.Execute_Proc("PKGMAT_INOUT.GET_REQUESTPRINT"
                                    , 1
                                    , new string[] { 
                                      "A_CLIENT"
                                    , "A_COMPANY"
                                    , "A_PLANT"
                                    , "A_RESPONSENO" }
                                    , new string[] {
                                      Global.Global_Variable.CLIENT
                                    , Global.Global_Variable.COMPANY
                                    , Global.Global_Variable.PLANT
                                    , _sResponseNo}
                                    );

            if (_Result.ResultInt == 0)
            {
                int nCopies = 1;
                DataTable dtPrint = _Result.ResultDataSet.Tables[0].Clone();

                int nCount = 35;

                for (int nRow = 0; nRow < _Result.ResultDataSet.Tables[0].Rows.Count; nRow++)
                {
                    dtPrint.ImportRow(_Result.ResultDataSet.Tables[0].Rows[nRow]);
                    nCount--;

                    if (nCount == 0)
                    {
                        Print(dtPrint, nCopies);
                        dtPrint.Clear();
                        nCount = 35;
                    }

                    if (nCount != 0 && nRow == _Result.ResultDataSet.Tables[0].Rows.Count - 1)
                    {
                        Print(dtPrint, nCopies);
                    }
                }

            }
            else
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
        }


        public void RefreshButton_Click()
        {
            // 새로 고침 버튼 클릭 이벤트
            //GetGridViewListRefresh();
        }

        public void DeleteButton_Click()
        {
            // 삭제 버튼 클릭 이벤트
        }

        #endregion

        #region [Private Method]
        private bool Print(DataTable dTable, int nCopies)
        {
            using (RPT.RPTA204 _rpt = new RPT.RPTA204(dTable, nCopies))
            {
                _rpt.RptPrint();
            }
            return true;
        }
        private void Set_Init()
        {
            tabList.SelectedTabPageIndex = 0;
            gcList.DataSource = null;

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWHLOC
                                                       , "PKGBAS_BASE.GET_LOCATION2"
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
                                                       , "WHLOC"
                                                       , "WHLOCNAME"
                                                       , "WHLOC, WHLOCNAME, REMARKS"
                                                       );
        }       

        #endregion

        #region 함수
        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid( gcList
                                       , "PKGBAS_MAT.GET_MAT_OUT_LIST"
                                       , 1
                                       , new string[] {
                                         "A_CLIENT"
                                       , "A_COMPANY"
                                       , "A_PLANT"
                                       , "A_FROMDATE"
                                       , "A_TODATE"
                                       , "A_WHLOC" }
                                       , new string[] {
                                         Global.Global_Variable.CLIENT
                                       , Global.Global_Variable.COMPANY
                                       , Global.Global_Variable.PLANT
                                       , dteFromTo.StartDate                                          
                                       , dteFromTo.EndDate
                                       , gleWHLOC.EditValue.ObjectNullString() }
                                       , true
                                       );

            gvList.Columns["OUTQTY"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvList.Columns["OUTQTY"].DisplayFormat.FormatString = "{0:n2}";

            gvList.OptionsBehavior.Editable = true;
        }
       

        #endregion

        #region [일반 이벤트]

        #endregion

    }
}
