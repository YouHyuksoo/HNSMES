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
    public partial class POP_PRD201 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form
    {
        public DataTable dt;
        public POP_PRD201()
        {
            InitializeComponent();
        }

        private void POP_PRD201_Load(object sender, EventArgs e)
        {
            /*신규 DataTable 생성 및 입력조건 생성*/
            SplashScreenManager.ShowForm(typeof(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM), true, false);
            SplashScreenManager.Default.SendCommand(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM.WaitFormCommand.SetDescription, "Loading...");

            CreateProdPlanTable();
            GetProdDiv();
            GetVendor();
            GetPartNo();
            GetProdType();

            SplashScreenManager.CloseForm(true);
        }
        #region 결과테이블 기본 정보 생성
        private void CreateProdPlanTable()
        {
            if (dt != null) dt = null;

            dt = new DataTable();

            /*결과 컬럼 생성*/
            /*작업지시등록 엑셀 양식에 따라 변경 필요*/
            /*2016.05.06 HS*/
            dt.Columns.Add("F1", typeof(string));
            dt.Columns.Add("F2", typeof(string));
            dt.Columns.Add("F3", typeof(string));
            dt.Columns.Add("F4", typeof(string));
            dt.Columns.Add("F5", typeof(string));
            dt.Columns.Add("F6", typeof(string));
            dt.Columns.Add("F7", typeof(string));

            dt.AcceptChanges();
        }
        #endregion
        #region 기본 정보
        /*생산구분*/
        private void GetProdDiv()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleProdDiv,
                                                        "PKGPRD_PLAN.GET_COMMNAME",
                                                        1,
                                                        new string[] { "A_PLANT", "A_COMMGRP" },
                                                        new string[] { Global.Global_Variable.PLANT, "CG014" },
                                                        "CVALUE", 
                                                        "COMMNAME",
                                                        "CVALUE,COMMNAME");
        }
        /*업체*/
        private void GetVendor()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleVendor,
                                                        "PKGBAS_BASE.GET_VENDOR",
                                                        1,
                                                        new string[] { "A_COMPANY", "A_PURCHASE", "A_SALES", "A_OUTSC", "A_VIEW" },
                                                        new string[] { Global.Global_Variable.COMPANY, "N", "Y", "N", "0" },
                                                        "VENDOR",
                                                        "VENDORNAME",
                                                        "VENDOR,VENDORNAME");
        }
        /*품명*/
        private void GetPartNo()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(glePartNo,
                                                        "PKGMAT_INOUT.GET_PRODUCT_PARTNO",
                                                        1,
                                                        new string[] { },
                                                        new string[] { },
                                                        "ITEMCODE",
                                                        "PARTNO",
                                                        "PARTNO,ITEMNAME, SPEC");
        }
        /*생산형태*/
        private void GetProdType()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleProdType,
                                                        "PKGPRD_PLAN.GET_COMMNAME",
                                                        1,
                                                        new string[] { "A_PLANT", "A_COMMGRP" },
                                                        new string[] { Global.Global_Variable.PLANT, "CG004" },
                                                        "CVALUE",
                                                        "COMMNAME",
                                                        "CVALUE,COMMNAME");
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            /*항목 Validation Check*/
            if (dteDate.Text == "")
            {
                /*일자가 올바르지 않습니다*/
                iDATMessageBox.WARNINGMessage("MSG_ER_PRD_039", this.Text, 3);
                return;
            }
            if (gleProdDiv.Text == "")
            {
                /*생산구분을 선택하세요.*/
                iDATMessageBox.WARNINGMessage("MSG_ER_COMM_084", this.Text, 3);
                return;
            }
            if (gleVendor.EditValue.ObjectNullString() == "")
            {
                /*업체를 선택하세요*/
                iDATMessageBox.WARNINGMessage("MSG_ER_COMM_007", this.Text, 3);
                return;
            }
            if (gleVendor.Text == "")
            {
                /*업체를 선택하세요*/
                iDATMessageBox.WARNINGMessage("MSG_ER_COMM_007", this.Text, 3);
                return;
            }
            if (glePartNo.Text == "")
            {
                /*품번을 선택하세요.*/
                iDATMessageBox.WARNINGMessage("MSG_ER_COMM_002", this.Text, 3);
                return;
            }
            if (int.Parse(spePlanQty.EditValue.ObjectNullString()) <= 0)
            {
                /*수량을 입력하세요.*/
                iDATMessageBox.WARNINGMessage("MSG_ER_STOCK_014", this.Text, 3);
                return;
            }
            if (gleProdType.Text == "")
            {
                /*생산형태을 입력하세요.*/
                iDATMessageBox.WARNINGMessage("MSG_ER_COMM_085", this.Text, 3);
                return;
            }
            /*저장 데이터 생성*/
            if (dt == null) CreateProdPlanTable();

            dt.Rows.Add(new object[]{
                dteDate.DateTime.ToString("yyyyMMdd"),
                gleProdDiv.Text,
                gleVendor.EditValue.ObjectNullString(),
                gleVendor.Text,
                glePartNo.Text,
                spePlanQty.EditValue.ObjectNullString(),
                gleProdType.Text
            });


            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}