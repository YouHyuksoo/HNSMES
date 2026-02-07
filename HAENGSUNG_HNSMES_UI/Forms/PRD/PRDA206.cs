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
using HAENGSUNG_HNSMES_UI.WebService.Access;

namespace HAENGSUNG_HNSMES_UI.Forms.PRD
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : PRDA206<br/>
    ///      기능 : 불량 등록 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    
    public partial class PRDA206 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
    {
        // ******************************************* Base From Class ************************************
        // BASE_clsDevexpressGridUtil          DevExpress Grid 관련 Util Class.
        // BASE_db;                            웹서비스 DB처리 관련 Util Class.
        // BASE_DXGridHelper;                  DevExpress GridControl 데이터 Bind관련 Class
        // BASE_DXGridLookUpHelper;            DevExpress GridLookUp 데이터 Bind관련 Class
        // BASE_IDATLayoutUtil;                DevExpress LayoutControl Util Class.
        // BASE_Language;                      Language Util. ex) BASE_Language.GetMessageString("Code") 
        // ************************************************************************************************

        #region [Form Event]

        public PRDA206()
        {
            InitializeComponent();
        }

        private void PRDA206_Load(object sender, EventArgs e)
        {

        }

        private void PRDA206_Shown(object sender, EventArgs e)
        {
            this.InitForm();
        }
       

        #endregion

        #region Scan Event

        private void Get_BarcodeType(string p_strBarcode)
        {
            WSResults _result = BASE_db.Execute_Proc( "PKGPDA_COMM.GET_BARCODETYPE"
                                                    , 1
                                                    , new string[] {
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_JOB"
                                                    , "A_BARCODE" }
                                                    , new string[] {
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT
                                                    , this.Tag.ObjectNullString()
                                                    , p_strBarcode }
                                                    );

            string _strType = _result.ResultString;
            this.ProcessScanEvent(_strType, p_strBarcode);
        }

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
            if (gleDefect.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_BRD_012", this.Text, 3);
                return;
            }

            LanguageInformation clsLan = new LanguageInformation();
            string sMsg;

            switch (sType)
            {
                case "PRODSN":
                case "MATSN":
                    txtSerial.EditValue = sData;

                    GetGridViewList();
                    break;

                default:
                    sMsg = clsLan.GetMessageString("MSG_ER_COMM_027");
                    iDATMessageBox.WARNINGMessage(sMsg + "\r\n" +
                                                    "Type : " + sType + "\r\n" +
                                                    "Barcode : " + sData, this.Text, 3);
                    break;
            }

        }

        #endregion

        #region [Button Event]

        public void InitButton_Click()
        {
            // 초기화 관련 구현은 여기에 구현 ***
        }

        
        public void NewButton_Click()
        {
            // 신규 버튼 클릭 이벤트
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
            GetGridViewList();
        }

       
        public void SaveButton_Click()
        {
            // 저장 버튼 클릭 이벤트
            this.SaveData();
        }

       
        public void PrintButton_Click()
        {
            // 출력 버튼 클릭 이벤트
        }

       
        public void RefreshButton_Click()
        {
            // 새로 고침 버튼 클릭 이벤트
        }

        public void DeleteButton_Click()
        {
            // 삭제 버튼 클릭 이벤트
        }

        #endregion
     
        #region [Private Method]

        private void InitForm()
        {
            string _strWarehouse;

            //생산관리 - 생산 불량
            if (this.Tag.ObjectNullString() == "PRODBAD")
            {
                lcProdLine.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lcUnitNo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lcDefect.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                _strWarehouse = "3";
            }
            else //자재관리 - 자재 불량
            {
                lcProdLine.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lcUnitNo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lcDefect.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                _strWarehouse = "4";
            }

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWH
                                                       , "PKGBAS_BASE.GET_WAREHOUSE"
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
                                                       , _strWarehouse }
                                                       , "WAREHOUSE"
                                                       , "WAREHOUSENAME"
                                                       , "WAREHOUSE, WAREHOUSENAME, REMARKS"
                                                       );

            /*라인 정보 조회*/
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleProdline
                                                       , "GPKGPRD_PROD.GET_PRODLINE"
                                                       , 1
                                                       , new string[] { 
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT" }
                                                       , new string[] { 
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT }
                                                       , "PRODLINE"
                                                       , "PRODLINENAME"
                                                       , "PRODLINE, PRODLINENAME, REMARKS "
                                                       );

            /*공정 정보 조회*/
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
                                                       , "OPER, OPERNAME, REMARKS "
                                                       );
            
        }

        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid_Int( gcList
                                           , "PKGBAS_BRD.GET_BADREG_SNINFO"
                                           , 1
                                           , new string[] { 
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_WHLOC"
                                           , "A_SERIAL" }
                                           , new string[] { 
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , gleWHLoc.EditValue.ObjectNullString()
                                           , txtSN.EditValue.ObjectNullString() }
                                           , true
                                           , "ITEMCODE, ORIGINQTY, QTYOUTFLAG"
                                           , false//true
                                           , ""
                                           );

            gvList.OptionsView.ColumnAutoWidth = true;
            gvList.BestFitColumns();            

        }

        private void SaveData()
        {
            if (txtSerial.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.ErrorMessage("MSG_ER_COMM_010", this.Text, 3); //S/N를 스캔(입력)하세요.
                return;
            }

            if (int.Parse(spiQty.EditValue.ObjectNullString()) <= 0)
            {
                iDATMessageBox.ErrorMessage("MSG_ER_BRD_021", this.Text, 3); //등록 수량은 0보다 커야합니다.
                return;
            }

            if (gleDefect.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.ErrorMessage("MSG_ER_BRD_012", this.Text, 3); //불량코드를 선택하여 주십시오.
                return;
            }

            if (int.Parse(gvList.GetRowCellValue(gvList.FocusedRowHandle, "ORIGINQTY").ObjectNullString()) < int.Parse(spiQty.EditValue.ObjectNullString()))
            {
                iDATMessageBox.ErrorMessage("MSG_ER_BRD_014", this.Text, 3); //등록 수량은 0보다 커야합니다.
                return;
            }

            if (this.Tag.ObjectNullString() == "PRODBAD")
            {
                if (gleProdline.EditValue.ObjectNullString() == "")
                {
                    iDATMessageBox.ErrorMessage("MSG_ER_LINE_004", this.Text, 3); //라인을 선택하세요.
                    return;
                }

                if (gleUnitNo.EditValue.ObjectNullString() == "")
                {
                    iDATMessageBox.ErrorMessage("MSG_ER_PRD_051", this.Text, 3); //호기를 선택하세요.
                    return;
                }

                if (gleOper.EditValue.ObjectNullString() == "")
                {
                    iDATMessageBox.ErrorMessage("MSG_ER_PRD_082", this.Text, 3); //공정을 선택하세요.
                    return;
                }

            }


            bool _bResult = BASE_db.Execute_Proc( "PKGBAS_BRD.SET_BADREG_SN"
                                                , 1
                                                , new string[] { 
                                                  "A_CLIENT"
                                                , "A_COMPANY"
                                                , "A_PLANT"
                                                , "A_PARTNO"
                                                , "A_SERIAL"
                                                , "A_FROMWHLOC"
                                                , "A_QTY"
                                                , "A_PRODLINE"
                                                , "A_UNITNO"
                                                , "A_OPER"
                                                , "A_DEFECT"
                                                , "A_REMARKS"
                                                , "A_USER" }
                                                , new string[] {  
                                                  Global.Global_Variable.CLIENT
                                                , Global.Global_Variable.COMPANY
                                                , Global.Global_Variable.PLANT
                                                , txtPartNo.EditValue.ObjectNullString()
                                                , txtSerial.EditValue.ObjectNullString()
                                                , txtWhloc.EditValue.ObjectNullString()
                                                , spiQty.EditValue.ObjectNullString()
                                                , gleProdline.EditValue.ObjectNullString()
                                                , gleUnitNo.EditValue.ObjectNullString()
                                                , gleOper.EditValue.ObjectNullString()
                                                , gleDefect.EditValue.ObjectNullString()
                                                , txtRemarks.EditValue.ObjectNullString()
                                                , Global.Global_Variable.EHRCODE }
                                                , true
                                                );

            if (_bResult == true)
            {
                iDATMessageBox.OKMessage("DBMSG_SUCCESS", this.Text, 3);
                txtSerial.EditValue = "";
                txtWhloc.EditValue = "";
                spiQty.EditValue = 0;
                gleDefect.EditValue = "";
                txtRemarks.EditValue = "";
                GetGridViewList();
            }
        }

        #endregion

        #region 일반이벤트

        private void txtSN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSN.Text.Trim() == "")
                    return;

                this.Get_BarcodeType(txtSN.Text);

                txtSN.Text = "";
                txtSN.Focus();
            }
        }

        private void gleWH_EditValueChanged(object sender, EventArgs e)
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWHLoc
                                                       , "PKGBAS_BASE.GET_LOCATION"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_WAREHOUSE"
                                                       , "A_VIEW" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , gleWH.EditValue.ObjectNullString() 
                                                       , "0" }
                                                       , "WHLOC"
                                                       , "WHLOCNAME"
                                                       , "WHLOC, WHLOCNAME, REMARKS"
                                                       );
        }

        private void gvList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvList.GetFocusedRowCellValue("SERIAL").ObjectNullString() == "NONE")
            {
                spiQty.Properties.ReadOnly = false;
            } 
            else if (gvList.GetFocusedRowCellValue("QTYOUTFLAG").ObjectNullString() == "Y")
            {
                spiQty.Properties.ReadOnly = false;
            }
            else
            {
                spiQty.Properties.ReadOnly = true;
            }
        }
        private void gleProdline_EditValueChanged(object sender, EventArgs e)
        {
            /*호기 정보 조회*/
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleUnitNo
                                                       , "GPKGPRD_PROD.GET_PRODLINE_UNIT"
                                                       , 1
                                                       , new string[] { 
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_PRODLINE" }
                                                       , new string[] { 
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , gleProdline.EditValue.ObjectNullString() }
                                                       , "UNITNO"
                                                       , "UNITNM"
                                                       , "UNITNO, UNITNM, REMARKS"
                                                       );
        }
        
        private void gleOper_EditValueChanged(object sender, EventArgs e)
        {
            DataRow[] _dr = (gleOper.Properties.DataSource as DataTable).Select("OPER='" + gleOper.EditValue.ObjectNullString() + "'");

            if (_dr.Length > 0)
            {
                /*불량 유형 조회*/
                BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleDefect
                                                           , "GPKGPRD_PROD.GET_DEFECT"
                                                           , 2
                                                           , new string[] { 
                                                             "A_CLIENT"
                                                           , "A_COMPANY"
                                                           , "A_PLANT"
                                                           , "A_DEFECTTYPE"}
                                                               , new string[] { 
                                                             Global.Global_Variable.CLIENT
                                                           , Global.Global_Variable.COMPANY
                                                           , Global.Global_Variable.PLANT
                                                           , _dr[0]["OPERTYPE"].ObjectNullString()}
                                                           , "DEFECT"
                                                           , "DEFECTNAME"
                                                           , "DEFECT,DEFECTNAME"
                                                           );
            }
        }
        #endregion
    }
}
