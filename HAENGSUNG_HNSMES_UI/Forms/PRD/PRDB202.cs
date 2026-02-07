#pragma warning disable IDE1006 // Naming Styles
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
using Oracle.ManagedDataAccess.Client;

namespace HAENGSUNG_HNSMES_UI.Forms.PRD
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : PRDB202<br/>
    ///      기능 : LOT 추적 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    
    public partial class PRDB202 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
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

        public PRDB202()
        {
            InitializeComponent();
        }

        private void PRDB202_Load(object sender, EventArgs e)
        {
        
        }

        private void PRDB202_Shown(object sender, EventArgs e)
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
            string sFlag = rdgFlag.EditValue.ObjectNullString();
            string sMsg;

            switch (sType)
            {
                case "PRODSN":
                case "MATSN":
                    this.GetGridViewList(sData, sFlag);
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
            this.InitControl();
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

            string sFlag = rdgFlag.EditValue.ObjectNullString();

            if (txtSN.EditValue.ObjectNullString() != "")
                this.GetGridViewList(txtSN.EditValue.ObjectNullString(), sFlag);
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

        private void InitControl()
        {
            txtSN.Text = "";
            gcList.DataSource = null;
        }

        private void GetGridViewList(string p_sData, string p_sFlag)
        {
            // 프로시져 수행

            
            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result =
                BASE_db.Execute_Proc( "PKGPRD_REPORT.GET_PRODSN_DETAIL_HIST"
                                    , 1
                                    , new string[] { 
                                      "A_CLIENT"
                                    , "A_COMPANY"
                                    , "A_PLANT"
                                    , "A_FLAG"
                                    , "A_BARCODE" }
                                    , new string[] { 
                                      Global.Global_Variable.CLIENT
                                    , Global.Global_Variable.COMPANY
                                    , Global.Global_Variable.PLANT
                                    , p_sFlag
                                    , p_sData }
                                    );
            
            //public static Result GetDataProc(string ProcName, Dictionary<object[], OracleDbType> Prams, bool isC_RETURN = true)

            //NGS_UI.Class.DirectCon.Result _Result =
            // NGS_UI.Class.DirectCon.GetDataProc("PKGPRD_REPORT.GET_PRODSN_DETAIL_HIST"
            // //NGS_UI.Class.DirectCon.GetDataProc("PKGPRD_HIST.GET_PRODSN_DETAIL_HIST"
            //                     , new Dictionary<object[], OracleDbType>()
            //                     {
            //                            { new object[]{ "A_CLIENT", Global.Global_Variable.CLIENT}, OracleDbType.Varchar2 },
            //                            { new object[]{ "A_COMPANY", Global.Global_Variable.COMPANY}, OracleDbType.Varchar2 },
            //                            { new object[]{ "A_PLANT", Global.Global_Variable.PLANT}, OracleDbType.Varchar2 },
            //                            { new object[]{ "A_FLAG", p_sFlag}, OracleDbType.Varchar2 },
            //                            { new object[]{ "A_BARCODE", p_sData}, OracleDbType.Varchar2 },
            //                            { new object[]{ "C_RETURN1", string.Empty}, OracleDbType.RefCursor }

            //                     });


            BASE_DXGridHelper.Bind_Grid_Int( gcList
                                           , _Result.ResultDataSet.Tables[0]
                                           , true
                                           , ""
                                           , false
                                           , "SEQ,REPRINTCNT"
                                           );

            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();

            if (_Result.ResultDataSet.Tables.Count > 1)
            {
                try
                {
                    gcList1.DataSource = null;
                    gcList2.DataSource = null;
                    gcList3.DataSource = null;

                    DataTable dtCircuit = null; 
                    DataRow[] drCircuit = _Result.ResultDataSet.Tables[1].Select("PRODLINE ='P2005'","SEQ DESC");
                    if (drCircuit.Length > 0)
                    {
                        dtCircuit = drCircuit.CopyToDataTable();
                        BASE_DXGridHelper.Bind_Grid(gcList1
                                               , dtCircuit
                                               , false
                                               , "PRODLINE,UNITNO,BOXNO"
                                               , false
                                               );
                        gvList1.OptionsView.ColumnAutoWidth = false;
                        gvList1.BestFitColumns();
                    }

                    DataTable dtVisual = null;
                    DataRow[] drVisual = _Result.ResultDataSet.Tables[1].Select("PRODLINE ='P2007'", "SEQ DESC");
                    if (drVisual.Length > 0)
                    {
                        dtVisual = drVisual.CopyToDataTable();
                        BASE_DXGridHelper.Bind_Grid(gcList2
                                               , dtVisual
                                               , false
                                               , "PRODLINE,UNITNO,BOXNO"
                                               , false
                                               );
                        gvList2.OptionsView.ColumnAutoWidth = false;
                        gvList2.BestFitColumns();
                    }

                    DataTable dtPacking = null;
                    DataRow[] drPacking = _Result.ResultDataSet.Tables[1].Select("PRODLINE ='P2006'","SEQ DESC");
                    if (drPacking.Length > 0)
                    {
                        dtPacking = drPacking.CopyToDataTable();
                        BASE_DXGridHelper.Bind_Grid(gcList3
                                               , dtPacking
                                               , false
                                               , "PRODLINE,UNITNO"
                                               , false
                                               );
                        gvList3.OptionsView.ColumnAutoWidth = false;
                        gvList3.BestFitColumns();
                    }
                }
                catch
                {
                    //binding error 무시
                }
            }

            LanguageInformation _clsLan = new LanguageInformation();

            string _sMsg;

            for(int i = 0; i < gvList.RowCount; i++)
            {
                _sMsg = _clsLan.GetMessageString(gvList.GetRowCellValue(i, "TXNNAME").ToString());

                gvList.SetRowCellValue(i, "TXNNAME", _sMsg);
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

                this.Get_BarcodeType(txtSN.EditValue.ObjectNullString());

                txtSN.EditValue = "";
                txtSN.Focus();
            }
        }

        #endregion

    }
}
