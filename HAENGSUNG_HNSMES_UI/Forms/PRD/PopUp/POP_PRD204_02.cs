using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

//*화면 신규 추가시 아래 네임스페이스 추가*//
using System.Diagnostics;
using HAENGSUNG_HNSMES_UI.Class;
using HAENGSUNG_HNSMES_UI.WebService.Access;
using GridAlias = DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using NGS.WCFClient.DatabaseService;
using DevExpress.XtraGrid;
using DevExpress.XtraSplashScreen;
namespace HAENGSUNG_HNSMES_UI.Forms.PRD.PopUp
{
    public partial class POP_PRD204_02 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form
    {
        /*LOT정보*/
        string strLot = string.Empty;
        /*생산진행정보*/
        string strProdprogNo = string.Empty;
        /*작업지시정보*/
        string strWoBarcode = string.Empty;
        /*GRID COLUMNS 설정*/
        private readonly string strGcListCol = "TERMINALFLAG,PARTNO,SPEC,ASSYUSAGE";
        private readonly string strGcList1Col = "TERMINALFLAGNAME,PARTNO,SPEC,SEQ,ALLJUDGE";
        public POP_PRD204_02()
        {
            InitializeComponent();

            fnControlInspItemEnableMode(false);
        }
        public POP_PRD204_02(string _strLot, string _strProdprogNo, string _strWoBarcode)
        {
            InitializeComponent();

            this.Text = iDATMessageBox.GetMessage(this.Text); //체크시트작성

            strLot = _strLot;
            strProdprogNo = _strProdprogNo;
            strWoBarcode = _strWoBarcode;

            ///*체크시트 대상 조회*/
            //fnGetChkSheetObject(strProdprogNo);

            ///*합불판정GridLookUp내용조회*/
            //fnGetInspJduge();

            ///*검사이력조회*/
            //fnGetInspHis();
        }
        private void POP_PRD204_02_Shown(object sender, EventArgs e)
        {
            /*최초 검사결과 컬럼 설정*/
            BASE_DXGridHelper.Bind_Grid(gcList1,
                                       fnSaveDataTable().Clone(),
                                       true,
                                       strGcList1Col,
                                       true);

            gvList1.OptionsView.ColumnAutoWidth = false;
            gvList1.BestFitColumns();

            /*합불판정GridLookUp내용조회*/
            fnGetInspJduge();
            /*체크시트 실적입력 버튼 컨트롤 처리*/
            fnGetChkSheetButtonEnableMode(false);
            /*체크시트 실적입력 항목 컨트롤 처리*/
            fnControlInspObjectEnableMode(false);
            /*체크시트 실적입력 실적 컨트롤 처리*/
            fnControlInspItemEnableMode(false);
        }
        #region [PRIVATE EVENT]
        private DataTable fnSaveDataTable()
        {
            DataTable dt = new DataTable();
            
            dt.Columns.Add("TERMINALFLAG", typeof(string));
            dt.Columns.Add("TERMINALFLAGNAME", typeof(string));
            dt.Columns.Add("PRODPROGNO", typeof(string));
            dt.Columns.Add("PARTNO", typeof(string));
            dt.Columns.Add("SPEC", typeof(string));
            dt.Columns.Add("ASSYUSAGE", typeof(string));
            dt.Columns.Add("SEQ", typeof(string));
            dt.Columns.Add("MEASEUREFLAG", typeof(string));
            dt.Columns.Add("STRIP_VAL", typeof(string));
            dt.Columns.Add("STRIP_JUDGE", typeof(string));
            dt.Columns.Add("PRES_VAL", typeof(string));
            dt.Columns.Add("PRES_JUDGE", typeof(string));
            dt.Columns.Add("INSUBA_HVAL", typeof(string));
            dt.Columns.Add("INSUBA_HJUDGE", typeof(string));
            dt.Columns.Add("INSUBA_WVAL", typeof(string));
            dt.Columns.Add("INSUBA_WJUDGE", typeof(string));
            dt.Columns.Add("CONDBA_HVAL", typeof(string));
            dt.Columns.Add("CONDBA_HJUDGE", typeof(string));
            dt.Columns.Add("CONDBA_WVAL", typeof(string));
            dt.Columns.Add("CONDBA_WJUDGE", typeof(string));
            dt.Columns.Add("COMPRATE", typeof(string));
            dt.Columns.Add("COMPRATE_JUDGE", typeof(string));
            dt.Columns.Add("CUTTING", typeof(string));
            dt.Columns.Add("CUTTING_JUDGE", typeof(string));
            dt.Columns.Add("JUDGE", typeof(string));
            dt.Columns.Add("ALLJUDGE", typeof(string));

            return dt;
        }
        private bool fnInspResultValidationChk(string strMatType, string strInspType)
        {
            bool bChk = true;

            //자재가 터미널이고, 검사 유형이 초기검사인경우
            if (strMatType.Contains("T") && strInspType.Contains("F"))
            {
                if (spiStrip.EditValue.ObjectNullString() == "")
                    bChk = false;
                if (spiPress.EditValue.ObjectNullString() == "")
                    bChk = false;
                if (spiCondbAH.EditValue.ObjectNullString() == "")
                    bChk = false;
                if (spiComprate.EditValue.ObjectNullString() == "")
                    bChk = false;
            }
            //자재가 터미널이고, 검사 유형이 주기검사인경우
            else if (strMatType.Contains("T") && strInspType.Contains("C"))
            {
                if (spiStrip.EditValue.ObjectNullString() == "")
                    bChk = false;
                if (spiPress.EditValue.ObjectNullString() == "")
                    bChk = false;
                if (spiInsubAH.EditValue.ObjectNullString() == "")
                    bChk = false;
                if (spiInsubAW.EditValue.ObjectNullString() == "")
                    bChk = false;
                if (spiCondbAH.EditValue.ObjectNullString() == "")
                    bChk = false;
                if (spiCondbAW.EditValue.ObjectNullString() == "")
                    bChk = false;
                if (spiComprate.EditValue.ObjectNullString() == "")
                    bChk = false;

            }
            //자재가 와이어이고, 검사유형이 초기 또는 주기검사인경우
            else if (strMatType.Contains("W") && (strInspType.Contains("F") || strInspType.Contains("C")))
            {
                if (spiCuttingL.EditValue.ObjectNullString() == "")
                    bChk = false;

                if (gleCuttingL.EditValue.ObjectNullString() == "")
                    bChk = false;
            }

            if (gleAllJudge.EditValue.ObjectNullString() == "")
                bChk = false;

            return bChk;
        }
        /*검사 대상, 유형에 따라 입력항목 Enable/DisEnable 처리*/
        private void fnSetInspType(string strMatType, string strInspType)
        {
            //자재가 터미널이고, 검사 유형이 초기검사인경우
            if (strMatType.Contains("T") && strInspType.Contains("F"))
            {
                txtInsubAH.EditValue = null;
                txtInsubAW.EditValue = null;
                txtCondbAW.EditValue = null;
                txtCuttingL.EditValue = null;

                txtInsubAHL.EditValue = null;
                txtInsubAWL.EditValue = null;
                txtCondbAWL.EditValue = null;
                txtCuttingLL.EditValue = null;

                txtInsubAHH.EditValue = null;
                txtInsubAWH.EditValue = null;
                txtCondbAWH.EditValue = null;
                txtCuttingLH.EditValue = null;

                spiInsubAH.EditValue = null;
                spiInsubAW.EditValue = null;
                spiCondbAW.EditValue = null;
                spiCuttingL.EditValue = null;

                gleInsubAH.EditValue = null;
                gleInsubAW.EditValue = null;
                gleCondbAW.EditValue = null;
                gleCuttingL.EditValue = null;

                txtInsubAH.Enabled      = false;
                txtInsubAW.Enabled      = false;
                //txtCondbAW.Enabled      = false;
                txtCuttingL.Enabled     = false;

                txtInsubAHL.Enabled = false;
                txtInsubAWL.Enabled = false;
                //txtCondbAWL.Enabled = false;
                txtCuttingLL.Enabled = false;

                txtInsubAHH.Enabled = false;
                txtInsubAWH.Enabled = false;
                //txtCondbAWH.Enabled = false;
                txtCuttingLH.Enabled = false;

                spiInsubAH.Enabled      = false;
                spiInsubAW.Enabled      = false;
                //spiCondbAW.Enabled      = false;
                spiCuttingL.Enabled     = false;

                gleInsubAH.Enabled      = false;
                gleInsubAW.Enabled      = false;
                //gleCondbAW.Enabled      = false;
                gleCuttingL.Enabled     = false;
            }
            //자재가 터미널이고, 검사 유형이 주기검사인경우
            else if (strMatType.Contains("T") && strInspType.Contains("C"))
            {
                
                txtCuttingL.EditValue = null;
                spiCuttingL.EditValue = null;
                gleCuttingL.EditValue = null;

                txtCuttingLL.EditValue = null;
                txtCuttingLH.EditValue = null;

                txtCuttingL.Enabled = false;
                spiCuttingL.Enabled = false;
                gleCuttingL.Enabled = false;

                txtCuttingLL.Enabled = false;
                txtCuttingLH.Enabled = false;
            }
            //자재가 와이어이고, 검사유형이 초기 또는 주기검사인경우
            else if(strMatType.Contains("W") && (strInspType.Contains("F") || strInspType.Contains("C")))
            {
                txtStrip.EditValue = null;
                txtPress.EditValue = null;
                txtInsubAH.EditValue = null;
                txtInsubAW.EditValue = null;
                txtCondbAH.EditValue = null;
                txtCondbAW.EditValue = null;
                txtComprate.EditValue = null;

                txtStripL.EditValue = null;
                txtPressL.EditValue = null;
                txtInsubAHL.EditValue = null;
                txtInsubAWL.EditValue = null;
                txtCondbAHL.EditValue = null;
                txtCondbAWL.EditValue = null;
                txtComprateL.EditValue = null;

                txtStripH.EditValue = null;
                txtPressH.EditValue = null;
                txtInsubAHH.EditValue = null;
                txtInsubAWH.EditValue = null;
                txtCondbAHH.EditValue = null;
                txtCondbAWH.EditValue = null;
                txtComprateH.EditValue = null;

                txtStrip.Enabled        = false;
                txtPress.Enabled        = false;
                txtInsubAH.Enabled      = false;
                txtInsubAW.Enabled      = false;
                txtCondbAH.Enabled      = false;
                txtCondbAW.Enabled      = false;
                txtComprate.Enabled     = false;

                txtStripL.Enabled = false;
                txtPressL.Enabled = false;
                txtInsubAHL.Enabled = false;
                txtInsubAWL.Enabled = false;
                txtCondbAHL.Enabled = false;
                txtCondbAWL.Enabled = false;
                txtComprateL.Enabled = false;

                txtStripH.Enabled = false;
                txtPressH.Enabled = false;
                txtInsubAHH.Enabled = false;
                txtInsubAWH.Enabled = false;
                txtCondbAHH.Enabled = false;
                txtCondbAWH.Enabled = false;
                txtComprateH.Enabled = false;

                spiStrip.Enabled        = false;
                spiPress.Enabled        = false;
                spiInsubAH.Enabled      = false;
                spiInsubAW.Enabled      = false;
                spiCondbAH.Enabled      = false;
                spiCondbAW.Enabled      = false;
                spiComprate.Enabled     = false;

                gleStrip.Enabled        = false;
                glePress.Enabled        = false;
                gleInsubAH.Enabled      = false;
                gleInsubAW.Enabled      = false;
                gleCondbAH.Enabled      = false;
                gleCondbAW.Enabled      = false;
                gleComprate.Enabled     = false;
          
            }
        }
       
        private void fnGetInspJduge()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleAllJudge,
                                                        "PKGSYS_COMM.GET_COMM",
                                                        1,
                                                        new string[] {"A_COMMGRP", "A_VIEW" },
                                                        new string[] { "CG066", "" },
                                                        "CVALUE",
                                                        "COMMNAME",
                                                        "COMMNAME,CVALUE");

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleStrip
                                                      , gleAllJudge.Properties.DataSource as DataTable
                                                      , "CVALUE"
                                                      , "COMMNAME"
                                                      , "COMMNAME,CVALUE"
                                                      , false);

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(glePress
                                                      , gleAllJudge.Properties.DataSource as DataTable
                                                      , "CVALUE"
                                                      , "COMMNAME"
                                                      , "COMMNAME,CVALUE"
                                                      , false);

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleInsubAH
                                                      , gleAllJudge.Properties.DataSource as DataTable
                                                      , "CVALUE"
                                                      , "COMMNAME"
                                                      , "COMMNAME,CVALUE"
                                                      , false);

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleInsubAW
                                                      , gleAllJudge.Properties.DataSource as DataTable
                                                      , "CVALUE"
                                                      , "COMMNAME"
                                                      , "COMMNAME,CVALUE"
                                                      , false);

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleCondbAH
                                                      , gleAllJudge.Properties.DataSource as DataTable
                                                      , "CVALUE"
                                                      , "COMMNAME"
                                                      , "COMMNAME,CVALUE"
                                                      , false);

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleCondbAW
                                                      , gleAllJudge.Properties.DataSource as DataTable
                                                      , "CVALUE"
                                                      , "COMMNAME"
                                                      , "COMMNAME,CVALUE"
                                                      , false);

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleComprate
                                                      , gleAllJudge.Properties.DataSource as DataTable
                                                      , "CVALUE"
                                                      , "COMMNAME"
                                                      , "COMMNAME,CVALUE"
                                                      , false);

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleCuttingL
                                                      , gleAllJudge.Properties.DataSource as DataTable
                                                      , "CVALUE"
                                                      , "COMMNAME"
                                                      , "COMMNAME,CVALUE"
                                                      , false);

        }
        private void fnSetInspSTDBinding(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                txtStrip.EditValue = dt.Rows[0]["STRIP"].ObjectNullString();
                txtStripL.EditValue = dt.Rows[0]["STRIPL"].ObjectNullString();
                txtStripH.EditValue = dt.Rows[0]["STRIPH"].ObjectNullString();
                
                txtPress.EditValue = dt.Rows[0]["PRESS"].ObjectNullString();
                txtPressL.EditValue = dt.Rows[0]["PRESSL"].ObjectNullString();
                txtPressH.EditValue = dt.Rows[0]["PRESSH"].ObjectNullString();

                txtInsubAH.EditValue = dt.Rows[0]["INSUBAH"].ObjectNullString();
                txtInsubAHL.EditValue = dt.Rows[0]["INSUBAHL"].ObjectNullString();
                txtInsubAHH.EditValue = dt.Rows[0]["INSUBAHH"].ObjectNullString();
                
                txtInsubAW.EditValue = dt.Rows[0]["INSUBAW"].ObjectNullString();
                txtInsubAWL.EditValue = dt.Rows[0]["INSUBAWL"].ObjectNullString();
                txtInsubAWH.EditValue = dt.Rows[0]["INSUBAWH"].ObjectNullString();

                txtCondbAH.EditValue = dt.Rows[0]["CONDBAH"].ObjectNullString();
                txtCondbAHL.EditValue = dt.Rows[0]["CONDBAHL"].ObjectNullString();
                txtCondbAHH.EditValue = dt.Rows[0]["CONDBAHH"].ObjectNullString();

                txtCondbAW.EditValue = dt.Rows[0]["CONDBAW"].ObjectNullString();
                txtCondbAWL.EditValue = dt.Rows[0]["CONDBAWL"].ObjectNullString();
                txtCondbAWH.EditValue = dt.Rows[0]["CONDBAWH"].ObjectNullString();
                
                txtComprate.EditValue = dt.Rows[0]["COMPRATE"].ObjectNullString();
                txtComprateL.EditValue = dt.Rows[0]["COMPRATEL"].ObjectNullString();
                txtComprateH.EditValue = dt.Rows[0]["COMPRATEH"].ObjectNullString();

                txtCuttingL.EditValue = dt.Rows[0]["CUTTINGLENGTH"].ObjectNullString();
                txtCuttingLL.EditValue = dt.Rows[0]["CUTTINGLENGTHL"].ObjectNullString();
                txtCuttingLH.EditValue = dt.Rows[0]["CUTTINGLENGTHH"].ObjectNullString();
                
            }

        }
        /*체크시트 대상 조회*/
        //private void fnGetChkSheetObject(string strLot) --old
        private void fnGetChkSheetObject(string strWoBarcode)
        {
            BASE_DXGridHelper.Bind_Grid(gcList
                                      , "PKGHNS_PROD.GET_PROD_CHKSHEET_OBJECT"
                                      , 1
                                      , new string[] { "A_WOBARCODE", "A_TERMINALFLAG" }
                                      , new string[] { strWoBarcode, rdgObject.EditValue.ObjectNullString() }
                                      , true
                                      , strGcListCol
                                      , true
                                      );

            gvList.OptionsView.ColumnAutoWidth = true;
            gvList.BestFitColumns();

            if ((gcList.DataSource as DataTable).Rows.Count > 0)
            {
                txtTerminalFlag.Tag = gvList.GetRowCellValue(gvList.FocusedRowHandle, "TERMINALCODE").ObjectNullString();
                txtAssyusage.Tag = gvList.GetRowCellValue(gvList.FocusedRowHandle, "ASSYUSAGE").ObjectNullString();

                /*체크시트 실적입력 실적 컨트롤 처리*/
                fnControlInspItemEnableMode(true);

                fnSetInspType(gvList.GetRowCellValue(0, "TERMINALCODE").ObjectNullString(), rdgInspection.EditValue.ObjectNullString());

                HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = BASE_db.Execute_Proc("PKGHNS_PROD.GET_PROD_INSP_STD"
                                                         , 1
                                                         , new string[] { "A_PARTNO" }
                                                         , new string[] { txtPartNo.EditValue.ObjectNullString() }
                                                        );

                if (_Result.ResultInt == 0)
                {
                    fnSetInspSTDBinding(_Result.ResultDataSet.Tables[0]);
                }
                else
                    iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);

                if(rdgInspection.EditValue.ObjectNullString() == "F")
                    txtInspType.EditValue = iDATMessageBox.GetMessage("FIRSTCHECK");
                else
                    txtInspType.EditValue = iDATMessageBox.GetMessage("CYCLECHECK");
            }

        }
        /*체크시트 실적입력 버튼 컨트롤 처리*/
        private void fnGetChkSheetButtonEnableMode(bool bval)
        {
            btnReg.Enabled = !bval;
            btnSave.Enabled = bval;
            rdgObject.Enabled = bval;
            gcList.Enabled = bval;
            gcList1.Enabled = bval;
        }
        /*체크시트 실적입력 항목 컨트롤 처리*/
        private void fnControlInspObjectEnableMode(bool bval)
        {
            /*텍스트박스(기준)처리*/
            rdgInspection.Enabled = !bval;

            /*텍스트박스(기준)처리*/
            txtInspType.Enabled = bval;
            txtTerminalFlag.Enabled = bval;
            txtPartNo.Enabled = bval;
            txtSpec.Enabled = bval;
            txtAssyusage.Enabled = bval;
        }

        /*체크시트 실적입력 실적 컨트롤 처리*/
        private void fnControlInspItemEnableMode(bool bval)
        {
            /*텍스트박스(기준)처리*/
            txtStrip.Enabled = bval;
            txtStrip.EditValue = null;
            txtStrip.Properties.ReadOnly = bval;
            txtStripL.Enabled = bval;
            txtStripL.EditValue = null;
            txtStripL.Properties.ReadOnly = bval;
            txtStripH.Enabled = bval;
            txtStripH.EditValue = null;
            txtStripH.Properties.ReadOnly = bval;

            txtPress.Enabled = bval;
            txtPress.EditValue = null;
            txtPress.Properties.ReadOnly = bval;
            txtPressL.Enabled = bval;
            txtPressL.EditValue = null;
            txtPressL.Properties.ReadOnly = bval;
            txtPressH.Enabled = bval;
            txtPressH.EditValue = null;
            txtPressH.Properties.ReadOnly = bval;
            
            txtInsubAH.Enabled = bval;
            txtInsubAH.EditValue = null;
            txtInsubAH.Properties.ReadOnly = bval;
            txtInsubAHL.Enabled = bval;
            txtInsubAHL.EditValue = null;
            txtInsubAHL.Properties.ReadOnly = bval;
            txtInsubAHH.Enabled = bval;
            txtInsubAHH.EditValue = null;
            txtInsubAHH.Properties.ReadOnly = bval;
            
            txtInsubAW.Enabled = bval;
            txtInsubAW.EditValue = null;
            txtInsubAW.Properties.ReadOnly = bval;
            txtInsubAWL.Enabled = bval;
            txtInsubAWL.EditValue = null;
            txtInsubAWL.Properties.ReadOnly = bval;
            txtInsubAWH.Enabled = bval;
            txtInsubAWH.EditValue = null;
            txtInsubAWH.Properties.ReadOnly = bval;
            
            txtCondbAH.Enabled = bval;
            txtCondbAH.EditValue = null;
            txtCondbAH.Properties.ReadOnly = bval;
            txtCondbAHL.Enabled = bval;
            txtCondbAHL.EditValue = null;
            txtCondbAHL.Properties.ReadOnly = bval;
            txtCondbAHH.Enabled = bval;
            txtCondbAHH.EditValue = null;
            txtCondbAHH.Properties.ReadOnly = bval;
            
            txtCondbAW.Enabled = bval;
            txtCondbAW.EditValue = null;
            txtCondbAW.Properties.ReadOnly = bval;
            txtCondbAWL.Enabled = bval;
            txtCondbAWL.EditValue = null;
            txtCondbAWL.Properties.ReadOnly = bval;
            txtCondbAWH.Enabled = bval;
            txtCondbAWH.EditValue = null;
            txtCondbAWH.Properties.ReadOnly = bval;
            
            txtComprate.Enabled = bval;
            txtComprate.EditValue = null;
            txtComprate.Properties.ReadOnly = bval;
            txtComprateL.Enabled = bval;
            txtComprateL.EditValue = null;
            txtComprateL.Properties.ReadOnly = bval;
            txtComprateH.Enabled = bval;
            txtComprateH.EditValue = null;
            txtComprateH.Properties.ReadOnly = bval;
            
            txtCuttingL.Enabled = bval;
            txtCuttingL.EditValue = null;
            txtCuttingL.Properties.ReadOnly = bval;
            txtCuttingLL.Enabled = bval;
            txtCuttingLL.EditValue = null;
            txtCuttingLL.Properties.ReadOnly = bval;
            txtCuttingLH.Enabled = bval;
            txtCuttingLH.EditValue = null;
            txtCuttingLH.Properties.ReadOnly = bval;

            /*SpinTextbox(결과)처리*/
            spiStrip.Enabled        = bval;
            spiStrip.EditValue      = null;
            spiPress.Enabled        = bval;
            spiPress.EditValue      = null;
            spiInsubAH.Enabled      = bval;
            spiInsubAH.EditValue    = null;
            spiInsubAW.Enabled      = bval;
            spiInsubAW.EditValue    = null;
            spiCondbAH.Enabled      = bval;
            spiCondbAH.EditValue    = null;
            spiCondbAW.Enabled      = bval;
            spiCondbAW.EditValue    = null;
            spiComprate.Enabled     = bval;
            spiComprate.EditValue   = null;
            spiCuttingL.Enabled     = bval;
            spiCuttingL.EditValue   = null;

            /*그리드뷰처리*/
            gleStrip.Enabled        = bval;
            gleStrip.EditValue      = null;
            glePress.Enabled        = bval;
            glePress.EditValue      = null;
            gleInsubAH.Enabled      = bval;
            gleInsubAH.EditValue    = null;
            gleInsubAW.Enabled      = bval;
            gleInsubAW.EditValue    = null;
            gleCondbAH.Enabled      = bval;
            gleCondbAH.EditValue    = null;
            gleCondbAW.Enabled      = bval;
            gleCondbAW.EditValue    = null;
            gleComprate.Enabled     = bval;
            gleComprate.EditValue   = null;
            gleCuttingL.Enabled     = bval;
            gleCuttingL.EditValue   = null;
            gleAllJudge.Enabled     = bval;
            gleAllJudge.EditValue   = null;

            /*버튼처리*/
            btnAdd.Enabled = bval;
            
        }

        /*체크시트 실적입력 실적 컨트롤 처리*/
        private void fnControlInspItemClearMode()
        {
            /*SpinTextbox(결과)처리*/
            spiStrip.EditValue = null;
            
            spiPress.EditValue = null;
            
            spiInsubAH.EditValue = null;
            
            spiInsubAW.EditValue = null;
            
            spiCondbAH.EditValue = null;
            
            spiCondbAW.EditValue = null;
            
            spiComprate.EditValue = null;
            
            spiCuttingL.EditValue = null;

            /*그리드뷰처리*/
            
            gleStrip.EditValue = null;
            
            glePress.EditValue = null;
            
            gleInsubAH.EditValue = null;
            
            gleInsubAW.EditValue = null;
            
            gleCondbAH.EditValue = null;
            
            gleCondbAW.EditValue = null;
            
            gleComprate.EditValue = null;
            
            gleCuttingL.EditValue = null;
            
            gleAllJudge.EditValue = null;

        }
        #endregion

        /*조회대상이 변경*/
        private void rdgObject_SelectedIndexChanged(object sender, EventArgs e)
        {
            //최초 & 주기 검사 여부 설정이 완료된 경우에 한해 자동 재조회한다.
            if (!rdgInspection.Enabled)
            {
                /*조회대상이 변경될 경우 항목을 다시 조회한다.*/
                fnGetChkSheetObject(strWoBarcode);
            }
        }

        #region [BUTTON EVENT]
        
        /*등록버튼*/
        private void btnReg_Click(object sender, EventArgs e)
        {
            fnGetChkSheetButtonEnableMode(true);
            fnControlInspObjectEnableMode(true);
            fnControlInspItemEnableMode(true);

            /*체크시트 대상 조회*/
            fnGetChkSheetObject(strWoBarcode);

            //HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = BASE_db.Execute_Proc("PKGHNS_PROD.GET_PROD_INSP_STD"
            //                                         , 1
            //                                         , new string[] { "A_PARTNO" }
            //                                         , new string[] { txtPartNo.EditValue.ObjectNullString() }
            //                                        );

            //if (_Result.ResultInt == 0)
            //{
            //    fnSetInspSTDBinding(_Result.ResultDataSet.Tables[0]);
                
            //    fnSetInspType(txtTerminalFlag.Tag.ObjectNullString(), rdgInspection.EditValue.ObjectNullString());
            //}
            //else
            //    iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
        }
        /*취소버튼*/
        private void btnCancel_Click(object sender, EventArgs e)
        {
            fnGetChkSheetButtonEnableMode(true);
            fnControlInspObjectEnableMode(true);
            fnControlInspItemEnableMode(false);
        }
        
        /*검사결과 추가*/
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(!fnInspResultValidationChk(txtTerminalFlag.Tag.ObjectNullString(), rdgInspection.EditValue.ObjectNullString()))
            {
                iDATMessageBox.ErrorMessage("MSG_ER_PRD_102", this.Text, 3);
                return;
            }
            DataTable dt = gcList1.DataSource as DataTable;
            int iSequence = 1;
            /*등록여부체크*/
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //터미널인경우는 타입/품목/소요량
                if (dt.Rows[i]["TERMINALFLAG"].ObjectNullString() == "T" &&
                    dt.Rows[i]["TERMINALFLAG"].ObjectNullString() == txtTerminalFlag.Tag.ObjectNullString() &&
                    dt.Rows[i]["PARTNO"].ObjectNullString() == txtPartNo.EditValue.ObjectNullString() &&
                    dt.Rows[i]["ASSYUSAGE"].ObjectNullString() == txtAssyusage.EditValue.ObjectNullString())
                {
                    iSequence++;
                }
                //와이어인경우는 타입/소요량
                if (dt.Rows[i]["TERMINALFLAG"].ObjectNullString() == "W" &&
                    dt.Rows[i]["TERMINALFLAG"].ObjectNullString() == txtTerminalFlag.Tag.ObjectNullString() &&
                    dt.Rows[i]["ASSYUSAGE"].ObjectNullString() == txtAssyusage.EditValue.ObjectNullString())
                {
                    iSequence++;
                }
            }

            dt.Rows.Add(new object[]{
                txtTerminalFlag.Tag.ObjectNullString(), 
                txtTerminalFlag.EditValue.ObjectNullString(), 
                strProdprogNo,
                txtPartNo.EditValue.ObjectNullString(),
                txtSpec.EditValue.ObjectNullString(),
                txtAssyusage.EditValue.ObjectNullString(),
                iSequence,
                rdgInspection.EditValue.ObjectNullString(),
                spiStrip.EditValue.ObjectNullString(),
                gleStrip.EditValue.ObjectNullString(),
                spiPress.EditValue.ObjectNullString(),
                glePress.EditValue.ObjectNullString(),
                spiInsubAH.EditValue.ObjectNullString(),
                gleInsubAH.EditValue.ObjectNullString(),
                spiInsubAW.EditValue.ObjectNullString(),
                gleInsubAW.EditValue.ObjectNullString(),
                spiCondbAH.EditValue.ObjectNullString(),
                gleCondbAH.EditValue.ObjectNullString(),
                spiCondbAW.EditValue.ObjectNullString(),
                gleCondbAW.EditValue.ObjectNullString(),
                spiComprate.EditValue.ObjectNullString(),
                gleComprate.EditValue.ObjectNullString(),
                spiCuttingL.EditValue.ObjectNullString(),
                gleCuttingL.EditValue.ObjectNullString(),
                gleAllJudge.EditValue.ObjectNullString(),
                gleAllJudge.Text
            });

            BASE_DXGridHelper.Bind_Grid(gcList1,
                                       dt,
                                       true,
                                       strGcList1Col,
                                       true);

            gvList1.OptionsView.ColumnAutoWidth = false;
            gvList1.BestFitColumns();

            fnControlInspItemClearMode();
        }

        /*저장버튼*/
        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dtSource = gcList.DataSource as DataTable;
            DataTable dt = gcList1.DataSource as DataTable;

            if (dt == null || dt.Rows.Count == 0)
            {
                iDATMessageBox.ErrorMessage("MSG_ER_PRD_116", this.Text, 3); //저장할 데이터가 없습니다.
                return;
            }

            bool iWireFlag = false;
            int iInspWireCount = 0;
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                int iInspCount = 0;
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (dtSource.Rows[i]["TERMINALCODE"].ObjectNullString() == "T" &&
                        dtSource.Rows[i]["PARTNO"].ObjectNullString() == dt.Rows[j]["PARTNO"].ObjectNullString() &&
                        dtSource.Rows[i]["ASSYUSAGE"].ObjectNullString() == dt.Rows[j]["ASSYUSAGE"].ObjectNullString())
                    {
                        iInspCount++;
                    }
                    if (dtSource.Rows[i]["TERMINALCODE"].ObjectNullString() == "W" &&
                        dtSource.Rows[i]["PARTNO"].ObjectNullString() == dt.Rows[j]["PARTNO"].ObjectNullString() &&
                        dtSource.Rows[i]["ASSYUSAGE"].ObjectNullString() == dt.Rows[j]["ASSYUSAGE"].ObjectNullString())
                    {
                        iWireFlag = true;
                        iInspWireCount++;
                    }
                }

                if ((dtSource.Rows[i]["TERMINALCODE"].ObjectNullString() == "T" && iInspCount <= 2) || //터미널인데 실적이 3번이하로 등록된 경우
                    (((dtSource.Rows.Count - 1 == i && iWireFlag == false) || dtSource.Rows.Count - 1 == i && iWireFlag == true && iInspWireCount <= 2))) //와이어인데 실적이 3번이하로 등록된 경우
                {
                    iDATMessageBox.ErrorMessage("MSG_ER_PRD_104", this.Text, 3);
                    return;
                }

            }

            string _strXml = this.GetDataTableToXml(dt);

            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = BASE_db.Execute_Proc("PKGHNS_PROD.SET_PROD_INSP_RESULT"
                                                               , 1
                                                               , new string[] {
                                                                       "A_XML"
                                                                     , "A_LOT"
                                                                     , "A_PRODPROGNO"
                                                                     , "A_MEASEUREFLAG"
                                                                     , "A_CREATEUSER"
                                                                    }
                                                               , new string[] {
                                                                      _strXml,
                                                                      strLot,
                                                                      strProdprogNo,
                                                                      rdgInspection.EditValue.ObjectNullString(),
                                                                      Global.Global_Variable.EHRCODE
                                                                    }
                                                              );
            if (_Result.ResultInt == 0)
            {
                iDATMessageBox.OKMessage("MSG_OK_REG_001", this.Text, 3);
                this.Close();
            }
            else
            {
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
            }

        }
        #endregion

        private void gvList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                txtTerminalFlag.Tag = gvList.GetRowCellValue(e.FocusedRowHandle, "TERMINALCODE").ObjectNullString();
                txtAssyusage.Tag = gvList.GetRowCellValue(e.FocusedRowHandle, "SIDE").ObjectNullString();

                /*체크시트 실적입력 실적 컨트롤 처리*/
                fnControlInspItemEnableMode(true);
                
                fnSetInspType(gvList.GetRowCellValue(e.FocusedRowHandle, "TERMINALCODE").ObjectNullString(), rdgInspection.EditValue.ObjectNullString());

                HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = BASE_db.Execute_Proc("PKGHNS_PROD.GET_PROD_INSP_STD"
                                                         , 1
                                                         , new string[] { "A_PARTNO" }
                                                         , new string[] { txtPartNo.EditValue.ObjectNullString() }
                                                        );

                if (_Result.ResultInt == 0)
                {
                    fnSetInspSTDBinding(_Result.ResultDataSet.Tables[0]);
                }
                else
                    iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ValueEditValueChanged(object sender, EventArgs e)
        {
            IDAT.Devexpress.DXControl.IdatDxSpinEdit txtControl = sender as IDAT.Devexpress.DXControl.IdatDxSpinEdit;

            if (txtControl.EditValue == null) return;

            if (!decimal.TryParse(txtControl.EditValue.ObjectNullString(), out decimal dCurrentValue))
                dCurrentValue = 0;

            if (decimal.Parse(txtControl.EditValue.ObjectNullString()) <= -1)
            {
                iDATMessageBox.ErrorMessage("MSG_ER_RESULT_029", this.Text, 3);
                txtControl.EditValue = 0;
                return;
            }

            switch (txtControl.Name)
            {
                case "spiStrip":
                    gleStrip.EditValue = fnGetJudgeCheck(txtStripL, txtStripH, dCurrentValue);
                    break;
                case "spiPress" :
                    glePress.EditValue = fnGetJudgeCheck(txtPressL, txtPressH, dCurrentValue);
                    break;
                case "spiInsubAH":
                    gleInsubAH.EditValue = fnGetJudgeCheck(txtInsubAHL, txtInsubAHH, dCurrentValue);
                    break;
                case "spiInsubAW":
                    gleInsubAW.EditValue = fnGetJudgeCheck(txtInsubAWL, txtInsubAWH, dCurrentValue);
                    break;
                case "spiCondbAH":
                    gleCondbAH.EditValue = fnGetJudgeCheck(txtCondbAHL, txtCondbAHH, dCurrentValue);
                    break;
                case "spiCondbAW":
                    gleCondbAW.EditValue = fnGetJudgeCheck(txtCondbAWL, txtCondbAWH, dCurrentValue);
                    break;
                case "spiComprate":
                    gleComprate.EditValue = fnGetJudgeCheck(txtComprateL, txtComprateH, dCurrentValue);
                    break;
                case "spiCuttingL":
                    gleCuttingL.EditValue = fnGetJudgeCheck(txtCuttingLL, txtCuttingLH, dCurrentValue);
                    break;
            }

            gleAllJudge.EditValue = fnGetALLJudgeCheck(txtTerminalFlag.Tag.ObjectNullString(), rdgInspection.EditValue.ObjectNullString());

        }

        private string fnGetJudgeCheck(IDAT.Devexpress.DXControl.IdatDxTextEdit txtLow, IDAT.Devexpress.DXControl.IdatDxTextEdit txtHigh, decimal dValue)
        {
            if (!decimal.TryParse(txtLow.EditValue.ObjectNullString(), out decimal dLVal))
                dLVal = 0;

            if (!decimal.TryParse(txtHigh.EditValue.ObjectNullString(), out decimal dHVal))
                dHVal = 0;

            string sReturn;
            if (dLVal <= dValue && dValue <= dHVal)
            {
                sReturn = "Y";
            }
            else
            {
                sReturn = "N";
            }

            return sReturn;
        }
        private string fnGetALLJudgeCheck(string strMatType, string strInspType)
        {
            string sReturn = "Y";

            //자재가 터미널이고, 검사 유형이 초기검사인경우
            if (strMatType.Contains("T") && strInspType.Contains("F"))
            {
                if (gleStrip.EditValue.ObjectNullString() != "Y")
                    sReturn = "N";
                if (glePress.EditValue.ObjectNullString() != "Y")
                    sReturn = "N";
                if (gleCondbAH.EditValue.ObjectNullString() != "Y")
                    sReturn = "N";
                if (gleComprate.EditValue.ObjectNullString() != "Y")
                    sReturn = "N";
            }
            //자재가 터미널이고, 검사 유형이 주기검사인경우
            else if (strMatType.Contains("T") && strInspType.Contains("C"))
            {
                if (gleStrip.EditValue.ObjectNullString() != "Y")
                    sReturn = "N";
                if (glePress.EditValue.ObjectNullString() != "Y")
                    sReturn = "N";
                if (gleInsubAH.EditValue.ObjectNullString() != "Y")
                    sReturn = "N";
                if (gleInsubAW.EditValue.ObjectNullString() != "Y")
                    sReturn = "N";
                if (gleCondbAH.EditValue.ObjectNullString() != "Y")
                    sReturn = "N";
                if (gleCondbAW.EditValue.ObjectNullString() != "Y")
                    sReturn = "N";
                if (gleComprate.EditValue.ObjectNullString() != "Y")
                    sReturn = "N";

            }
            //자재가 와이어이고, 검사유형이 초기 또는 주기검사인경우
            else if (strMatType.Contains("W") && (strInspType.Contains("F") || strInspType.Contains("C")))
            {
                if (gleCuttingL.EditValue.ObjectNullString() != "Y")
                    sReturn = "N";
            }
            return sReturn;
        }
        /*검사 대상, 유형에 따라 입력항목 Enable/DisEnable 처리*/
        private IDAT.Devexpress.DXControl.IdatDxSpinEdit fnGetInspControl()
        {
            IDAT.Devexpress.DXControl.IdatDxSpinEdit txtFocusControl = null;

            if (spiStrip.Enabled && spiStrip.EditValue.ObjectNullString() == "")
                return spiStrip;
            else if (spiPress.Enabled && spiPress.EditValue.ObjectNullString() == "")
                return spiPress;
            else if (spiInsubAH.Enabled && spiInsubAH.EditValue.ObjectNullString() == "")
                return spiInsubAH;
            else if (spiInsubAW.Enabled && spiInsubAW.EditValue.ObjectNullString() == "")
                return spiInsubAW;
            else if (spiCondbAH.Enabled && spiCondbAH.EditValue.ObjectNullString() == "")
                return spiCondbAH;
            else if (spiCondbAW.Enabled && spiCondbAW.EditValue.ObjectNullString() == "")
                return spiCondbAW;
            else if (spiComprate.Enabled && spiComprate.EditValue.ObjectNullString() == "")
                return spiComprate;

            return txtFocusControl;
          
        }
        private void ControlKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (spiStrip.Enabled && spiStrip.EditValue.ObjectNullString() == "")
                    spiStrip.Focus();
                else if (spiPress.Enabled && spiPress.EditValue.ObjectNullString() == "")
                     spiPress.Focus();
                else if (spiInsubAH.Enabled && spiInsubAH.EditValue.ObjectNullString() == "")
                    spiInsubAH.Focus();
                else if (spiInsubAW.Enabled && spiInsubAW.EditValue.ObjectNullString() == "")
                    spiInsubAW.Focus();
                else if (spiCondbAH.Enabled && spiCondbAH.EditValue.ObjectNullString() == "")
                    spiCondbAH.Focus();
                else if (spiCondbAW.Enabled && spiCondbAW.EditValue.ObjectNullString() == "")
                    spiCondbAW.Focus();
                else if (spiComprate.Enabled && spiComprate.EditValue.ObjectNullString() == "")
                    spiComprate.Focus();
            }
        }
        
    }
}