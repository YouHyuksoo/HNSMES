using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

// DevExpress namespace
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

// User namespace
using HAENGSUNG_HNSMES_UI.Class;

using GridAlias = DevExpress.XtraGrid.Views.Grid;
using HAENGSUNG_HNSMES_UI.WebService.Access;

using DevExpress.XtraGrid;
using DevExpress.XtraSplashScreen;

namespace HAENGSUNG_HNSMES_UI.Forms.MAT
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : MATA204<br/>
    ///      기능 : 자재 요청 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    ///
    public partial class MATA204 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
    {
        // ******************************************* Base From Class ************************************
        // BASE_clsDevexpressGridUtil          DevExpress Grid 관련 Util Class.
        // BASE_db;                            웹서비스 DB처리 관련 Util Class.
        // BASE_DXGridHelper;                  DevExpress GridControl 데이터 Bind관련 Class
        // BASE_DXGridLookUpHelper;            DevExpress GridLookUp 데이터 Bind관련 Class
        // BASE_IDATLayoutUtil;                DevExpress LayoutControl Util Class.
        // BASE_Language;                      Language Util. ex) BASE_Language.GetMessageString("Code") 
        // ************************************************************************************************
        public MATA204()
        {
            InitializeComponent();
        }
        private void MATA204_Load(object sender, EventArgs e)
        {

        }

        private void MATA204_Shown(object sender, EventArgs e)
        {
            layoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        #region 버튼이벤트

        public void InitButton_Click()
        {
            // 초기화 관련 구현은 여기에 구현 ***
            // 상세 항목들을 모두 클리어 한다.
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);
        }

        public void NewButton_Click()
        {

        }

        public void EditButton_Click()
        {

        }

        public void StopButton_Click()
        {
        }

        public void SearchButton_Click()
        {
            gcList.DataSource = null;
            gcList1.DataSource = null;

            if (rdgDiv.EditValue.ObjectNullString() != "O")
            {
                layoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                GetGridViewList();
            }
            else
            {
                layoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                GetGridViewList1();
            }

        }

        public void SaveButton_Click()
        {

        }
        public void RefreshButton_Click()
        {

        }

        public void PrintButton_Click()
        {
            DataTable dTable = (gcList.DataSource as DataTable).Clone();

            for (int i = 0; i < gvList.RowCount; i++)
            {
                if (gvList.GetRowCellValue(i, "SEL").ObjectNullString() == "Y")
                {
                    DataRow dr = (gcList.DataSource as DataTable).Rows[i];
                    dTable.ImportRow(dr);
                }
            }

            string sXML = base.GetDataTableToXml(dTable);

            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = 
                BASE_db.Execute_Proc( "PKGMAT_INOUT.SET_MATREQUESTNO"
                                    , 1
                                    , new string[] { 
                                      "A_CLIENT"
                                    , "A_COMPANY"
                                    , "A_PLANT"
                                    , "A_XML"
                                    , "A_USER" }
                                    , new string[] {
                                      Global.Global_Variable.CLIENT
                                    , Global.Global_Variable.COMPANY
                                    , Global.Global_Variable.PLANT
                                    , sXML
                                    , Global.Global_Variable.EHRCODE }
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
        public void DeleteButton_Click()
        {

        }

        #endregion

        #region Scan Event

        public void Data_Scan(string sType, string sData)
        {
            ProcessScanEvent(sType, sData);
        }

        public void Data_SubScan(string sType, string sData)
        {
            ProcessScanEvent(sType, sData);
        }

        private void ProcessScanEvent(string sType, string sData)
        {
        }

        #endregion

        #region 사용자 정의 
        private void GetGridViewList1()
        {
            BASE_DXGridHelper.Bind_Grid_Int( gcList1
                                           , "PKGMAT_INOUT.GET_PRODMATERIALLOCATION"
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
                                           , dteFromTo.EndDate }
                                           , true
                                           , "ITEMCODE"
                                           , false
                                           , "QTY"
                                           );

            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();

            gvList.OptionsBehavior.Editable = true;
            gvList.Columns["SEL"].OptionsColumn.AllowEdit = true;

        }
        private void GetGridViewList(string p_strVendor = "")
        {
            BASE_DXGridHelper.Bind_Grid_Int( gcList
                                           , "PKGMAT_INOUT.GET_PRODMATERIALREQUEST"
                                           , 2
                                           , new string[] { 
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_VENDOR"
                                           , "A_WRKORDTYPE"
                                           , "A_SDATE"
                                           , "A_EDATE" }
                                           , new string[] { 
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , p_strVendor
                                           , rdgDiv.EditValue.ObjectNullString()
                                           , dteFromTo.StartDate
                                           , dteFromTo.EndDate }
                                           , true
                                           , "ITEMCODE"
                                           , false
                                           , "QTY"
                                           );

            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();

            gvList.OptionsBehavior.Editable = true;
            gvList.Columns["SEL"].OptionsColumn.AllowEdit = true;

        }
        #endregion

        private bool Print(DataTable dTable, int nCopies)
        {
            using (RPT.RPTA204 _rpt = new RPT.RPTA204(dTable, nCopies))
            {
                _rpt.RptPrint();
            }
            return true;
        }

        private void chkAllCheck_CheckedChanged(object sender, EventArgs e)
        {
            string strChk = string.Empty;
            if (chkAllCheck.Checked)
                strChk = "Y";
            else
                strChk = "N";

            for (int i = 0; i < gvList.DataRowCount; i++)
            {
                gvList.SetRowCellValue(i, "SEL", strChk);
            }
        }

        private void gvList1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetGridViewList(gvList1.GetFocusedRowCellValue("VENDOR").ObjectNullString());
        }

        private void gvList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            BASE_DXGridHelper.Bind_Grid_Int( gcList2
                                           , "PKGMAT_INOUT.GET_PRODMATERIALDETAIL"
                                           , 1
                                           , new string[] { 
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_REQUESTMATNO"
                                           , "A_SEQ" }
                                           , new string[] { 
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , gvList.GetFocusedRowCellValue("REQUESTMATNO").ObjectNullString()
                                           , gvList.GetFocusedRowCellValue("SEQ").ObjectNullString() }
                                           , true
                                           , ""
                                           , false
                                           , "ORDQTY,ASSYUSAGE"
                                           );

            gvList2.OptionsView.ColumnAutoWidth = false;
            gvList2.BestFitColumns();

        }
    }
}