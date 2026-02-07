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
using HAENGSUNG_HNSMES_UI.WebService.Access;
using GridAlias = DevExpress.XtraGrid.Views.Grid;

namespace HAENGSUNG_HNSMES_UI.Forms.SAL
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : SALA201<br/>
    ///      기능 : 제품 포장 라벨 분리 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    ///

    public partial class SALA201 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
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

        public SALA201()
        {
            InitializeComponent();
        }

        private void SALA201_Load(object sender, EventArgs e)
        {

        }

        private void SALA201_Shown(object sender, EventArgs e)
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
            LanguageInformation clsLan = new LanguageInformation();
            string sMsg = "";

            switch (sType)
            {
                case "BOXNO":
                    txtBoxNo.EditValue = sData;
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

            ////  현재 프로그램 모드정보를 변경한다.
            ////  IDAT.Devexpress.FORM.UPDATEITEMTYPE.None = 초기화 모드
            ////  IDAT.Devexpress.FORM.UPDATEITEMTYPE.New  = 신규 모드
            ////  IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit = 수정 모드
          
            //base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);
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
           
        }
     
        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid_RT( gcList
                                          , "PKGPRD_SALES.GET_BOXINFO"
                                          , 1
                                          , new string[] {
                                            "A_CLIENT"
                                          , "A_COMPANY"
                                          , "A_PLANT"
                                          , "A_BOXNO" }
                                          , new string[] {
                                            Global.Global_Variable.CLIENT
                                          , Global.Global_Variable.COMPANY
                                          , Global.Global_Variable.PLANT
                                          , txtBoxNo.EditValue.ObjectNullString() }
                                          , true
                                          , "BOXNO, ITEMCODE, PARTNO, WHLOC, WHLOCNAME, QTY"
                                          , false);
        }

        private bool Print(DataTable dTable, int nCopies)
        {
            using (RPT.RPTA205 _rpt = new RPT.RPTA205(dTable, nCopies))
            {
                _rpt.RptPrint();
            }
            return true;
        }
        #endregion

        #region [Control Event]

        private void txtBoxNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBoxNo.EditValue.ObjectNullString() == "")
                    return;

                this.Get_BarcodeType(txtBoxNo.EditValue.ObjectNullString());
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (gvList.RowCount == 0)
            {
                iDATMessageBox.ErrorMessage("MSG_ER_COMM_008", this.Text, 3);
                txtBoxNo.Focus();
                return;
            }

            if (int.Parse(spiQty.EditValue.ObjectNullString()) < 1)
            {
                iDATMessageBox.ErrorMessage("MSG_ER_COMM_001", this.Text, 3);
                spiQty.Focus();
                return;
            }
            
            // 프로시져 수행
            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = 
                BASE_db.Execute_Proc( "PKGPRD_SALES.SET_BOXSPLIT"
                                    , 1
                                    , new string[] { 
                                      "A_CLIENT"
                                    , "A_COMPANY"
                                    , "A_PLANT"
                                    , "A_BOXNO"
                                    , "A_SPLITQTY"
                                    , "A_USER" }
                                    , new string[] { 
                                      Global.Global_Variable.CLIENT
                                    , Global.Global_Variable.COMPANY
                                    , Global.Global_Variable.PLANT
                                    , gvList.GetRowCellValue(0, "B").ObjectNullString()
                                    , spiQty.EditValue.ObjectNullString()
                                    , Global.Global_Variable.EHRCODE }
                                    );

            if (_Result.ResultInt == 0)
            {
                BASE_DXGridHelper.Bind_Grid_RT(gcList2, _Result.ResultDataSet.Tables[0]);

                BASE_DXGridHelper.Bind_Grid_RT(gcList3, _Result.ResultDataSet.Tables[1]);

                if (Print(_Result.ResultDataSet.Tables[0], 1))
                    if (Print(_Result.ResultDataSet.Tables[1], 1))
                    {
                        iDATMessageBox.OKMessage("MSG_OK_PRINT_001", this.Text, 3);

                    }
            }
            else
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);

        }

        #endregion

        
    }
}
