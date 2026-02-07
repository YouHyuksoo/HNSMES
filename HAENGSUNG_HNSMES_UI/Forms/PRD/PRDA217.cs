using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

using System.Collections.Generic;
using HAENGSUNG_HNSMES_UI.Class;
using HAENGSUNG_HNSMES_UI.WebService.Access;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

using GridAlias = DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraSplashScreen;


namespace HAENGSUNG_HNSMES_UI.Forms.PRD
{

    public partial class PRDA217 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {

        #region 생성

        private Boolean _bRefresh = false;

        public PRDA217()
        {
            InitializeComponent();
        }

        private void PRDA217_Load(object sender, EventArgs e)
        {
            
        }

        private void PRDA217_Shown(object sender, EventArgs e)
        {
            Set_Init();
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
            
        }

        public void PrintButton_Click()
        {
            DataRow[] dRowList = (gcList.DataSource as DataTable).Select("SEL = 'Y'");

            if (dRowList.Length <= 0) return;

            DataTable dTable = (gcList.DataSource as DataTable).Clone();
            
            foreach (DataRow dRow in dRowList)
            {
                dTable.Clear();

                DataRow dTempRow = dTable.NewRow();

                for (int nCol = 0; nCol < dTable.Columns.Count; nCol++)
                    dTempRow[nCol] = dRow[nCol];

                dTable.Rows.Add(dTempRow);

                if (dTempRow["ITEMTYPE"].ObjectNullString() == "1")
                {
                    if (dTempRow["PRINTTYPE"].ObjectNullString() == "W")
                    {
                        Print1(dTable, 1); //Washer
                    }
                    else if (dTempRow["PRINTTYPE"].ObjectNullString() == "R")
                    {
                        Print2(dTable, 1); //REF
                    }
                    else if (dTempRow["PRINTTYPE"].ObjectNullString() == "D")
                    {
                        Print(dTable, 1); //Dryer
                    }
                    else
                    {
                        Print3(dTable, 1); //ETC
                    }
                }
                else
                {
                    Print4(dTable, 1);
                }
            }
            
            Set_Init();
        }

        public void RefreshButton_Click()
        {
        }

        public void DeleteButton_Click()
        {
            
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
                //sConnectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0;HDR=No;", excelFile);
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

                        Global.GlobalFunction.ReadExcelFile(excelFile, sheetName);
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

        

        
        private void Set_Init()
        {
            GetGridViewList();
        }
            
        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid_Int( gcList
                                           , "PKGPRD_PROD.GET_REPLACEITEM"
                                           , 1
                                           , new string[] { 
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_STDATE"
                                           , "A_ENDATE" }
                                           , new string[] { 
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , dteFromTo.StartDate
                                           , dteFromTo.EndDate }
                                           , true
                                           , "ITEMTYPE,PRINTTYPE,COMPANY,YYYYMMDD,YYYYMMDD2,SEQ,PARTNO3,LABELTEXT,PRINTDATE"
                                           , false//true
                                           , "ITEMCODE,ORIITEMCODE,QTY"
                                           );


            gvList.OptionsBehavior.Editable = true;
            gvList.Columns["SEL"].OptionsColumn.AllowEdit = true;
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
       
        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.RestoreDirectory = true;
            ofd.Filter = "Excel Files(*.xls, *.xlsx, *.xlt)|*.xls;*.xlsx;*.xlt";
            

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string _strFilePath = ofd.FileName;

                
                DataTable dTable = Global.GlobalFunction.ReadExcelFile(_strFilePath, "Sheet1"); //EXCEL SHEET명

                if (dTable == null)
                    return;

                dTable.Rows.RemoveAt(0);

                LanguageInformation _clsLan = new LanguageInformation();
                string _strMsg = _clsLan.GetMessageString("MSG_QS_PRD_005"); //품목대체를 업로드하시겠습니까?

                if (iDATMessageBox.QuestionMessage(_strMsg, this.Text) == System.Windows.Forms.DialogResult.Yes)
                {
                    
                    string _strXml = this.GetDataTableToXml(dTable);

                    WSResults result = BASE_db.Execute_Proc( "PKGPRD_PROD.PUT_REPLACEITEM"
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
                                                           , _strXml
                                                           , Global.Global_Variable.USER_ID }
                                                           );

                    if (result.ResultInt != 0)
                    {
                        iDATMessageBox.ErrorMessage(BASE_Language.GetMessageString(result.ResultString), this.Text, 5);
                    }
                    else
                    {
                        GetGridViewList();
                    }
                }
            }
        }

        private void btnUploadExcelFormXlsx_Click(object sender, EventArgs e)
        {
            Process pc = new Process();
            pc.StartInfo.FileName = Application.StartupPath + @"\Excel\REPLACEITEM.xlsx";
            pc.StartInfo.Verb = "Open";
            pc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            pc.Start();
        }

        private void btnUploadExcelFormXls_Click(object sender, EventArgs e)
        {
            Process pc = new Process();
            pc.StartInfo.FileName = Application.StartupPath + @"\Excel\REPLACEITEM.xls";
            pc.StartInfo.Verb = "Open";
            pc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            pc.Start();
        }

        private void gvList_RowCellStyle(object sender, GridAlias.RowCellStyleEventArgs e)
        {

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
       
        //Dryer or default
        private bool Print(DataTable dTable, int nCopies)
        {
            using (RPT.RPTA203 _rpt = new RPT.RPTA203(dTable, nCopies))
            {
                _rpt.RptPrint();
            }
            return true;
        }
        //Washer
        private bool Print1(DataTable dTable, int nCopies)
        {
            using (RPT.RPTA206 _rpt = new RPT.RPTA206(dTable, nCopies))
            {
                _rpt.RptPrint();
            }
            return true;
        }
        //REF
        private bool Print2(DataTable dTable, int nCopies)
        {
            using (RPT.RPTA207 _rpt = new RPT.RPTA207(dTable, nCopies))
            {
                _rpt.RptPrint();
            }
            return true;
        }
        //ETC
        private bool Print3(DataTable dTable, int nCopies)
        {
            using (RPT.RPTA209 _rpt = new RPT.RPTA209(dTable, nCopies))
            {
                _rpt.RptPrint();
            }
            return true;
        }
        private bool Print4(DataTable dTable, int nCopies)
        {
            using (RPT.RPTA201 _rpt = new RPT.RPTA201(dTable, nCopies))
            {
                _rpt.RptPrint();
            }
            return true;
        }
        
    }
}
