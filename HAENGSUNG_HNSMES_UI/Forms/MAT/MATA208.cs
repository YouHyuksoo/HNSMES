using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Diagnostics;

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
    ///    화면명 : MATA208<br/>
    ///      기능 : 재고 실사 등록 / 수정 / 확정 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    ///
    public partial class MATA208 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
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

        private Boolean _bRefresh = false;

        public MATA208()
        {
            InitializeComponent();
        }

        private void MATA208_Load(object sender, EventArgs e)
        {
            dteDate1.EditValue = dteDate.EditValue = DateTime.Now;
        }

        private void MATA208_Shown(object sender, EventArgs e)
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
        }

        public void NewButton_Click()
        {
            // 신규 관련 구현은 여기에 구현.
                        
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New);

            // 그리드뷰에 새로운 행과 초기값을 지정한다.
            //gvList.EX_AddNewRow();
            gvList.EX_AddNewRow(new string[] { "PARTNO" }, new string[] { "0" });

            glePartNo.Focus();
        }

        public void EditButton_Click()
        {
            // 수정 관련 구현은 여기에 구현.
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit);

        }

        public void StopButton_Click()
        {
        }


        public void SaveButton_Click()
        {

            // 저장전에 필수 항목에 대한 Null 값을 초기화 합니다.
            // 유효성검사 다시 수행
            base.baseDxErrorProvider.ClearErrors();
            ValidateChildren(ValidationConstraints.Visible);

            // 유효성 검사를 한다.
            if (base.baseDxErrorProvider.HasErrors)
                return;

            string _strActualdate = "";
            string _strWhloc = "";
            string _strSerial = "";
            string _strItemcode = "";
            string _strStocktype = "";
            string _strActualqty = "";

            if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit)
            {
                DataTable _dt = BASE_clsDevexpressGridUtil.GetChangedData(gcList);

                //변경된 데이터가 없으면 return.
                if (_dt.Rows.Count == 0) return;

                // 변경된 데이터를 루프를 통해 하나씩 빼낸다.
                foreach (DataRow _dr in _dt.Rows)
                {
                    //실사 후 실사 수량 수정이 필요한 경우 수정을 통해 수량을 변경한다.
                    //전산 재고만 있는경우(실사정보없음) 실사 정보를 신규 생성한다.
                    switch (_dr.RowState)
                    {
                        case DataRowState.Modified:

                            _strActualdate = _dr["ACTUALMON"].ObjectNullString();
                            _strWhloc = _dr["WHLOC"].ObjectNullString();
                            _strSerial = _dr["SERIAL"].ObjectNullString();
                            _strItemcode = _dr["ITEMCODE"].ObjectNullString();
                            _strStocktype = _dr["STOCKTYPE"].ObjectNullString();
                            _strActualqty = _dr["ACTUALQTY"].ObjectNullString();

                            if (!SaveData(_strActualdate, _strWhloc, _strSerial, _strItemcode, _strStocktype, _strActualqty))
                                return;
                            

                            break;

                        default:
                            break;
                    }
                }

                MainButton_INIT.PerformClick();

                SearchButton_Click();

                gvList.EX_GetFocuseRowCell("ITEMCODE", _strItemcode);
            }
        }

        public void PrintButton_Click()
        {
        }

        public void RefreshButton_Click()
        {
        }

        public void DeleteButton_Click()
        {
            if (iDATMessageBox.QuestionMessage("MSG_QS_PRD_001", this.Text) == System.Windows.Forms.DialogResult.Yes)
            {
                string _strActualdate = gvList.GetRowCellValue(gvList.FocusedRowHandle, "ACTUALMON").ObjectNullString();
                string _strWhloc = gvList.GetRowCellValue(gvList.FocusedRowHandle, "WHLOC").ObjectNullString();
                string _strSerial = gvList.GetRowCellValue(gvList.FocusedRowHandle, "SERIAL").ObjectNullString();
                string _strItemcode = gvList.GetRowCellValue(gvList.FocusedRowHandle, "ITEMCODE").ObjectNullString();
                string _strStocktype = gvList.GetRowCellValue(gvList.FocusedRowHandle, "STOCKTYPE").ObjectNullString();
                string _strActualqty = gvList.GetRowCellValue(gvList.FocusedRowHandle, "ACTUALQTY").ObjectNullString();

                bool _Rtn = BASE_db.Execute_Proc( "PKGTXN_STOCK.SET_ACTUAL_DELETE"
                                                , 1
                                                , new string[] {
                                                  "A_CLIENT"
                                                , "A_COMPANY"
                                                , "A_PLANT"
                                                , "A_ACTUALMONTH"
                                                , "A_WHLOC"
                                                , "A_SERIAL"
                                                , "A_ITEMCODE"
                                                , "A_STOCKTYPE"                                                   
                                                , "A_ACTUALQTY"
                                                , "A_USER" }
                                                , new string[] {
                                                  Global.Global_Variable.CLIENT
                                                , Global.Global_Variable.COMPANY
                                                , Global.Global_Variable.PLANT
                                                , _strActualdate
                                                , _strWhloc
                                                , _strSerial
                                                , _strItemcode
                                                , _strStocktype
                                                , _strActualqty
                                                , Global.Global_Variable.EHRCODE }
                                                , false
                                                );

                SearchButton_Click();

                gvList.EX_GetFocuseRowCell("ITEMCODE", _strItemcode);
            }
        }

        public void SearchButton_Click()
        {
            GetGridViewList();
        }

        #endregion

        #region 함수

        public ArrayList ExcelSheetNames(string excelFile)
        {
            ArrayList sheetNames = new ArrayList();
            string sConnectionString;


            string[] arrText = excelFile.ToString().Split(new char[] { '.' });

            if (arrText[arrText.Length - 1].ToString() == "xls")
            {
                sConnectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=No;\"", excelFile);
            }
            else
            {
                sConnectionString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=No;\"", excelFile);
            }

            using (OleDbConnection excelConnection = new OleDbConnection(sConnectionString))
            {
                System.Data.DataTable dtSheets = new System.Data.DataTable();

                try
                {
                    excelConnection.Open();
                    dtSheets = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    excelConnection.Close();
                    if (dtSheets == null)
                    {
                        return sheetNames;
                    }

                    foreach (DataRow dr in dtSheets.Rows)
                    {
                        string sheetName = dr["TABLE_NAME"].ToString().Trim('\'').Replace("$", "");

                        DataTable dt = Global.GlobalFunction.ReadExcelFile(excelFile, sheetName);

                        if (dt.Rows[0]["F1"] + "" == "Model(파트넘버)")
                        {
                            sheetNames.Add(sheetName);
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    iDATMessageBox.WARNINGMessage(ex.Message, this.Text, 3);
                    //MainButton_INIT.PerformClick();
                    return null;
                }
                finally
                {
                    dtSheets.Dispose();
                }
            }
            return sheetNames;
        }

        /*실사 정보 수정*/
        private bool SaveData(string p_strActualMonth, string p_Loc, string p_Serial,    
                              string p_strItemcode, string p_strStockType, string p_strActualqty)
        {

            bool _Rtn = BASE_db.Execute_Proc( "PKGTXN_STOCK.SET_ACTUAL_ALTER"
                                            , 1
                                            , new string[] {
                                              "A_CLIENT"
                                            , "A_COMPANY"
                                            , "A_PLANT"
                                            , "A_ACTUALMONTH"
                                            , "A_WHLOC"
                                            , "A_SERIAL"
                                            , "A_ITEMCODE"
                                            , "A_STOCKTYPE"                                                   
                                            , "A_ACTUALQTY"
                                            , "A_USER" }
                                            , new string[] {
                                              Global.Global_Variable.CLIENT
                                            , Global.Global_Variable.COMPANY
                                            , Global.Global_Variable.PLANT
                                            , p_strActualMonth
                                            , p_Loc
                                            , p_Serial
                                            , p_strItemcode
                                            , p_strStockType
                                            , p_strActualqty
                                            , Global.Global_Variable.EHRCODE }
                                            , false
                                            );
            return _Rtn;
            
        }
        
        /*컨트롤 초기화*/
        private void Set_Init()
        {
            string _strWarehouse = string.Empty;

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( glePartNo
                                                       , "PKGBAS_BASE.GET_ITEM"
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
                                                       , "PARTNO"
                                                       , "PARTNO"
                                                       , "PARTNO, ITEMNAME, SPEC"
                                                       );

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( glePartNo1
                                                       , "PKGBAS_BASE.GET_ITEM"
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
                                                       , "PARTNO"
                                                       , "PARTNO"
                                                       , "PARTNO, ITEMNAME, SPEC"
                                                       );


            if (this.Tag.ObjectNullString() == "PRODACTUAL") //생산관리 - 재고 실사
            {
                layoutControlItem20.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                _strWarehouse = "3";
            }
            else if (this.Tag.ObjectNullString() == "MATACTUAL")//자재관리 - 재고 실사
            {
                layoutControlItem20.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                _strWarehouse = "4";
            }
            else if (this.Tag.ObjectNullString() == "SALESACTUAL") //영업관리 - 재고 실사
            {
                this.ShowEditButton = false;
                layoutControlItem20.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                _strWarehouse = "5";
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

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWH1
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

        }

        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid( gcList
                                       , "PKGTXN_STOCK.GET_ACTUAL"
                                       , 1
                                       , new string[] {      
                                         "A_CLIENT"
                                       , "A_COMPANY"
                                       , "A_PLANT"
                                       , "A_ACTUALMON"
                                       , "A_WHLOC"
                                       , "A_ITEMCODE" }
                                       , new string[] { 
                                         Global.Global_Variable.CLIENT
                                       , Global.Global_Variable.COMPANY
                                       , Global.Global_Variable.PLANT
                                       , dteDate1.DateTime.ToString("yyyyMM")
                                       , gleWHLoc1.EditValue.ObjectNullString()
                                       , glePartNo1.EditValue.ObjectNullString() }
                                       , true
                                       );

            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();
        }

        #endregion

        #region 일반이벤트

        private void gvList_Click(object sender, EventArgs e)
        {
            if (!(sender is GridAlias.GridView))
            {
                return;
            }

            //IDAT.Controls.IDATDevExpress _clsGrid = new IDAT.Controls.IDATDevExpress();

            GridAlias.GridView gridView = sender as GridAlias.GridView;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo gridHitINFO = BASE_clsDevexpressGridUtil.GetClickHitInfo(gvList, e);

            if (gridHitINFO.InRow && gridHitINFO.InColumn)
            {
                /// ============================================================
                /// 선택된 Row의 정보를 가져올려면 아래에 구현을 하면 된다.
                int RowIdx = gridHitINFO.RowHandle;
                int ColIdx = gridHitINFO.Column.AbsoluteIndex;
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
         
            if (_bRefresh == false)
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
                if (dr["PARTNO"] != null)
                {
                    // 주키가 두개일 경우 AND 문으로 조건을 다중으로 준다.
                    if (dr["PARTNO"].ToString() == gvList.GetDataRow(e.RowHandle)["PARTNO"].ToString())
                    {
                        e.Appearance.ForeColor = Color.Red;                        
                    }
                }
            }
        }
        

        private void gleitemtype_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            
        }

        
        #endregion

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

        private void gleWH1_EditValueChanged(object sender, EventArgs e)
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWHLoc1
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
                                                       , gleWH1.EditValue.ObjectNullString()
                                                       , "0" }
                                                       , "WHLOC"
                                                       , "WHLOCNAME"
                                                       , "WHLOC, WHLOCNAME, REMARKS"
                                                       );            
        }
        
        private void glePartNo_EditValueChanged(object sender, EventArgs e)
        {
            if (glePartNo.EditValue.ObjectNullString() == "")
            {
                return;
            }

            DataTable tempdt =((DataTable)glePartNo.Properties.DataSource).Select("PARTNO = '" + glePartNo.EditValue.ObjectNullString() + "'").CopyToDataTable();

            if (tempdt.Rows.Count < 1)
            {
                return;
            }
            
            txtitemname.Text = tempdt.Rows[0]["ITEMNAME"].ToString();
            txtSpec.Text = tempdt.Rows[0]["SPEC"].ToString();            
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (gleWH1.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.ErrorMessage("MSG_ER_COMM_005", this.Text, 3); //위치를 선택하세요.
                return;
            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.RestoreDirectory = true;
            ofd.Filter = "Excel Files(*.xls, *.xlsx, *.xlt)|*.xls;*.xlsx;*.xlt";
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string _strFilePath = ofd.FileName;

                
                DataTable dTable = Global.GlobalFunction.ReadExcelFile(_strFilePath, "실사");

                if (dTable == null)
                    return;

                dTable.Rows.RemoveAt(0);
                
                LanguageInformation _clsLan = new LanguageInformation();
                string _strMsg = _clsLan.GetMessageString("MSG_QS_SAL_001"); //재고실사 업로드하시겠습니까? 기존 데이터는 삭제됩니다

                if (iDATMessageBox.QuestionMessage(_strMsg, this.Text) == System.Windows.Forms.DialogResult.Yes)
                {
                    SplashScreenManager.ShowForm(typeof(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM), true, false);
                    SplashScreenManager.Default.SendCommand(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM.WaitFormCommand.SetDescription, "UPLOAD...");

                    string _strXml = this.GetDataTableToXml(dTable);
                    WSResults result = BASE_db.Execute_Proc( "PKGTXN_STOCK.PUT_ACTUAL_UPLOAD"
                                                           , 1
                                                           , new string[] {
                                                             "A_CLIENT"
                                                           , "A_COMPANY"
                                                           , "A_PLANT"
                                                           , "A_ACTUALMON"
                                                           , "A_WHLOC"
                                                           , "A_XML"
                                                           , "A_USER" }
                                                           , new string[] {
                                                             Global.Global_Variable.CLIENT
                                                           , Global.Global_Variable.COMPANY
                                                           , Global.Global_Variable.PLANT
                                                           , dteDate1.DateTime.ToString("yyyyMM")
                                                           , gleWHLoc1.EditValue.ObjectNullString()
                                                           , _strXml
                                                           , Global.Global_Variable.EHRCODE }
                                                           );

                    if (result.ResultInt != 0)
                    {
                        SplashScreenManager.CloseForm(true);
                        iDATMessageBox.ErrorMessage(BASE_Language.GetMessageString(result.ResultString), this.Text, 5);
                    }
                    else
                    {
                        SplashScreenManager.Default.SendCommand(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM.WaitFormCommand.SetDescription, "COMPLETE");
                        iDATMessageBox.OKMessage("DBMSG_SUCCESS", this.Text, 3);
                        GetGridViewList();
                    }
                }
            }
        }

        private void btnUploadExcelFormXlsx_Click(object sender, EventArgs e)
        {
            Process pc = new Process();
            pc.StartInfo.FileName = Application.StartupPath + @"\Excel\ACTUALUPLOAD.xlsx";
            pc.StartInfo.Verb = "Open";
            pc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            pc.Start();
        }

        private void btnUploadExcelFormXls_Click(object sender, EventArgs e)
        {
            Process pc = new Process();
            pc.StartInfo.FileName = Application.StartupPath + @"\Excel\ACTUALUPLOAD.xls";
            pc.StartInfo.Verb = "Open";
            pc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            pc.Start();
        }

        private void btnActualClear_Click(object sender, EventArgs e)
        {
            if (iDATMessageBox.QuestionMessage("MSG_QS_MAT_005", this.Text) == System.Windows.Forms.DialogResult.Yes)
            {
                string _strActualMon = dteDate1.DateTime.ToString("yyyyMM");
                string _strWhLoc = gleWHLoc1.EditValue.ObjectNullString();

                if (gleWH1.EditValue.ObjectNullString() == "")
                {
                    iDATMessageBox.ErrorMessage("MSG_ER_COMM_005", this.Text, 3); //위치를 선택하세요.
                    return;
                }

                bool _Rtn = BASE_db.Execute_Proc( "PKGTXN_STOCK.SET_ACTUAL_DELETE_ALL"
                                                , 1
                                                , new string[] {
                                                  "A_CLIENT"
                                                , "A_COMPANY"
                                                , "A_PLANT"
                                                , "A_ACTUALMONTH"
                                                , "A_WHLOC"
                                                , "A_USER" }
                                                , new string[] {
                                                  Global.Global_Variable.CLIENT
                                                , Global.Global_Variable.COMPANY
                                                , Global.Global_Variable.PLANT
                                                , _strActualMon
                                                , _strWhLoc
                                                , Global.Global_Variable.EHRCODE }
                                                , true
                                                );

                if (_Rtn)
                {
                    GetGridViewList();
                }

            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (iDATMessageBox.QuestionMessage("MSG_QS_COMM_001", this.Text) == System.Windows.Forms.DialogResult.Yes)
            {
                string _strActualMon = dteDate1.DateTime.ToString("yyyyMM");
                string _strWhLoc = gleWHLoc1.EditValue.ObjectNullString();

                if (gleWH1.EditValue.ObjectNullString() == "")
                {
                    iDATMessageBox.ErrorMessage("MSG_ER_COMM_005", this.Text, 3); //위치를 선택하세요.
                    return;
                }

                bool _Rtn = BASE_db.Execute_Proc( "PKGTXN_STOCK.SET_ACTUAL_APPLY"
                                                , 1
                                                , new string[] {
                                                  "A_CLIENT"
                                                , "A_COMPANY"
                                                , "A_PLANT"
                                                , "A_ACTUALMON"
                                                , "A_WHLOC"
                                                , "A_USER" }
                                                , new string[] {
                                                  Global.Global_Variable.CLIENT
                                                , Global.Global_Variable.COMPANY
                                                , Global.Global_Variable.PLANT
                                                , _strActualMon
                                                , _strWhLoc
                                                , Global.Global_Variable.EHRCODE }
                                                , true 
                                                );

                if (_Rtn)
                    GetGridViewList();

            }
        }
    }
}
