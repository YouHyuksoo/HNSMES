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
using System.Xml.XPath;
using System.IO;

namespace HAENGSUNG_HNSMES_UI.Forms.PRD
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : PRDA202<br/>
    ///      기능 : 자재 요청 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    ///
    public partial class PRDA202 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
    {
        // ******************************************* Base From Class ************************************
        // BASE_clsDevexpressGridUtil          DevExpress Grid 관련 Util Class.
        // BASE_db;                            웹서비스 DB처리 관련 Util Class.
        // BASE_DXGridHelper;                  DevExpress GridControl 데이터 Bind관련 Class
        // BASE_DXGridLookUpHelper;            DevExpress GridLookUp 데이터 Bind관련 Class
        // BASE_IDATLayoutUtil;                DevExpress LayoutControl Util Class.
        // BASE_Language;                      Language Util. ex) BASE_Language.GetMessageString("Code") 
        // ************************************************************************************************


        public PRDA202()
        {
            InitializeComponent();
        }
        private void PRDA202_Load(object sender, EventArgs e)
        {

        }

        private void PRDA202_Shown(object sender, EventArgs e)
        {
            SearchButton_Click();


        }

        #region 공통 버튼이벤트

        public void InitButton_Click()
        {
            // 초기화 관련 구현은 여기에 구현 ***
            // 상세 항목들을 모두 클리어 한다.
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);


        }

        public void NewButton_Click()
        {
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New);

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
            GetGridViewList_stock();
            //임시
            for (int i = 0; i < gvList.DataRowCount; i++)
            {
                gvList.SetRowCellValue(i, "SEL", "N");
            }
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

            DataTable dTable1 = (gcList2.DataSource as DataTable).Copy();
            DataTable dTable2 = (gcList1.DataSource as DataTable).Copy();

            if (dTable1 == null || dTable1.Rows.Count <= 0) return;

            string sXML1 = HS.DataTableToXML(dTable1);
            string sXML2 = HS.DataTableToXML(dTable2);

            //string sXML1 = base.GetDataTableToXml(dTable1);
            //string sXML2 = base.GetDataTableToXml(dTable2);

            // 프로시져 수행
            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result =
                BASE_db.Execute_Proc("PKGPRD_PROD.PUT_PRODMATERIALREQUEST"
                                    , 1
                                    , new string[] {
                                      "A_CLIENT"
                                    , "A_COMPANY"
                                    , "A_PLANT"
                                    , "A_XML1"
                                    , "A_XML2"
                                    , "A_USER" }
                                    , new object[] {
                                      Global.Global_Variable.CLIENT
                                    , Global.Global_Variable.COMPANY
                                    , Global.Global_Variable.PLANT
                                    , sXML1
                                    , sXML2
                                    , Global.Global_Variable.EHRCODE }
                                    );

            if (_Result.ResultInt == 0)
            {
                iDATMessageBox.OKMessage("MSG_OK_CREATE_001", this.Text, 5);


                GetGridViewList();

            }
            else
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);

        }
        public void RefreshButton_Click()
        {

        }

        public void PrintButton_Click()
        {

        }
        public void DeleteButton_Click()
        {

        }

        #endregion

        #region Scan Event

        public void Data_Scan(string sType, string sData)
        {
            ProcessScanEvent();
        }

        public void Data_SubScan(string sType, string sData)
        {
            ProcessScanEvent();
        }

        private void ProcessScanEvent()
        {
        }

        #endregion

        #region 사용자 정의 
        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid_Int(gcList
                                           , "PKGPRD_PROD.GET_PRODMATERIALREQUEST"
                                           , 1
                                           , new string[] {
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_WRKORDTYPE"
                                           , "A_STDATE"
                                           , "A_ENDATE"}
                                           , new string[] {
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , rdgDiv.EditValue.ObjectNullString()
                                           , dteFromTo.StartDate
                                           , dteFromTo.EndDate }
                                           , true
                                           , "ITEMCODE,WRKORDTYPE,WRKORDSTATE,USEFLAG,REMARKS"
                                           , false//true
                                           , "WRKORDSEQ,ITEMCODE,ORDQTY"
                                           );

            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();

            gvList.OptionsBehavior.Editable = true;

            gvList.Columns["SEL"].OptionsColumn.AllowEdit = true;

            /*계산 그리드 초기화*/
            gcList1.DataSource = null;
            gcList2.DataSource = null;

        }

        private void GetGridViewList_stock()
        {
            BASE_DXGridHelper.Bind_Grid_Int(gcList3
                                           , "PKGPRD_PROD.GET_PRODMATERIALSTOCK"
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
                                           , ""
                                           , false//true
                                           , "GOODQTY"
                                           );

            gvList3.OptionsView.ColumnAutoWidth = false;
            gvList3.BestFitColumns();

        }
        #endregion

        #region 컨트롤 이벤트
        private void btnPreview_Click(object sender, EventArgs e)
        {
            var dr = from row in (gcList.DataSource as DataTable).AsEnumerable()
                     where row.Field<string>("SEL") == "Y"
                     select row;
            DataTable dtSelected;
            try { dtSelected = dr.CopyToDataTable(); }
            catch { return; }

            if (dtSelected.Rows.Count <= 0) return;

            BASE_DXGridHelper.Bind_Grid(gcList2
                                       , dtSelected
                                       , true
                                       , "WRKORD,WRKORDSEQ,BOMGRP,PARTNO,ORDQTY"
                                       , true
                                       );

            gvList2.OptionsView.ColumnAutoWidth = true;
            gvList2.BestFitColumns();

            //string sXML =  base.GetDataTableToXml(dtSelected);
            string sXML = HS.DataTableToXML(dtSelected);

            BASE_DXGridHelper.Bind_Grid_Int(gcList1
                                           , "PKGPRD_PROD.GET_PRODMATERIALREQUEST"
                                           , 2
                                           , new string[] {
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_XML" }
                                           , new string[] {
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , sXML }
                                           , true
                                           , "ITEMCODE"
                                           , false//true
                                           , "REQUESTQTY"
                                           );



            gvList1.OptionsView.ColumnAutoWidth = true;
            gvList1.OptionsBehavior.Editable = true;

            try
            { gvList1.Columns["REQUESTQTY"].OptionsColumn.AllowEdit = true; }
            catch { }

            gvList1.BestFitColumns();

        }

        #endregion

        private void chkAllCheck_CheckedChanged(object sender, EventArgs e)
        {
            string strChk;
            if (chkAllCheck.Checked)
                strChk = "Y";
            else
                strChk = "N";

            for (int i = 0; i < gvList.DataRowCount; i++)
            {
                gvList.SetRowCellValue(i, "SEL", strChk);
            }
        }


    }
}