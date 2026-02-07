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

    public partial class PRDA214 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {

        #region 생성

        private Boolean _bRefresh = false;

        public PRDA214()
        {
            InitializeComponent();
        }

        private void PRDA214_Load(object sender, EventArgs e)
        {
            dteDate1.EditValue =  DateTime.Now;
        }

        private void PRDA214_Shown(object sender, EventArgs e)
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

        

        
        private void Set_Init()
        {

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
                                                       , "PARTNO, ITEMNAME, SPEC "
                                                       );
           
        }
            
       

        private void GetGridViewList()
        {
            if (dteDate1.EditValue == null)
            {
                LanguageInformation _clsLang = new LanguageInformation();
                string _strMsg = _clsLang.GetMessageString("MSG_ER_COMM_089");//날짜를 입력하세요
                iDATMessageBox.WARNINGMessage(_strMsg, this.Text, 3);
                return;
            }


            WSResults result = BASE_db.Execute_Proc( "PKGPRD_PROD.GET_PRODPLAN"
                                                   , 1
                                                   , new string[] {
                                                     "A_CLIENT"
                                                   , "A_COMPANY"
                                                   , "A_PLANT"
                                                   , "A_PLANDATE"
                                                   , "A_PARTNO" }
                                                   , new string[] {
                                                     Global.Global_Variable.CLIENT
                                                   , Global.Global_Variable.COMPANY
                                                   , Global.Global_Variable.PLANT
                                                   , dteDate1.DateTime.ToString("yyyyMMdd")
                                                   , glePartNo1.EditValue.ObjectNullString() }
                                                   );


            gcList.DataSource = null;
            gvList.Columns.Clear();

            if (result.ResultInt == 0)
            {
                gvList.BeginUpdate();
                gvList.OptionsView.ShowAutoFilterRow = false;
                gvList.OptionsView.RowAutoHeight = true;

                gcList.DataSource = result.ResultDataSet.Tables[0];

                int iColIdx = 0;

                foreach (GridColumn gc in gvList.Columns)
                {
                    if (gc.FieldName.IndexOf("PLANDATE") > -1 || gc.FieldName.IndexOf("SEQ") > -1 ||
                        gc.FieldName.IndexOf("ITEMCODE") > -1 || gc.FieldName.IndexOf("CUSTPARTNO") > -1 ||
                        gc.FieldName.IndexOf("BOM_CHECK") > -1 )                         
                    {
                        gc.Fixed = FixedStyle.Left;
                    }

                    gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                    if (gc.FieldName.Equals("D" + iColIdx.ObjectNullString()))
                    {
                        gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gc.Caption = result.ResultDataSet.Tables[1].Rows[0][iColIdx].ObjectNullString();

                        DateTime datetime = Convert.ToDateTime(gc.Caption);

                        if (datetime.DayOfWeek == DayOfWeek.Saturday || datetime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            gc.AppearanceHeader.Options.UseForeColor = true;
                            gc.AppearanceHeader.ForeColor = Color.Red;
                        }
                        iColIdx++;
                    }

                }
            }

            gvList.EndUpdate();

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
            //ofd.FilterIndex = 1;
            //

            if (dteDate1.EditValue == null)
            {
                LanguageInformation _clsLang = new LanguageInformation();
                string _strMsg = _clsLang.GetMessageString("MSG_ER_COMM_089");//날짜를 입력하세요
                iDATMessageBox.WARNINGMessage(_strMsg, this.Text, 3);
                return;
            }

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string _strFilePath = ofd.FileName;

                
                DataTable dTable = Global.GlobalFunction.ReadExcelFile(_strFilePath, "PLAN"); //EXCEL SHEET명

                if (dTable == null)
                    return;

                dTable.Rows.RemoveAt(0);

                LanguageInformation _clsLan = new LanguageInformation();
                string _strMsg = _clsLan.GetMessageString("MSG_QS_PRD_004"); //생산 계획을 업로드하시겠습니까?

                if (iDATMessageBox.QuestionMessage(_strMsg, this.Text) == System.Windows.Forms.DialogResult.Yes)
                {
                    //SplashScreenManager.ShowForm(typeof(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM), true, false);
                    //SplashScreenManager.Default.SendCommand(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM.WaitFormCommand.SetDescription, "UPLOAD...");

                    string _strXml = this.GetDataTableToXml(dTable);
                    WSResults result = BASE_db.Execute_Proc( "PKGPRD_PROD.PUT_PRODPLAN_UPLOAD"
                                                           , 1
                                                           , new string[] {
                                                             "A_CLIENT"
                                                           , "A_COMPANY"
                                                           , "A_PLANT"
                                                           , "A_XML"
                                                           , "A_PLANDATE"
                                                           , "A_USER" }
                                                           , new string[] {
                                                             Global.Global_Variable.CLIENT
                                                           , Global.Global_Variable.COMPANY
                                                           , Global.Global_Variable.PLANT
                                                           , _strXml
                                                           , dteDate1.DateTime.ToString("yyyyMMdd")
                                                           , Global.Global_Variable.USER_ID }
                                                           );

                    if (result.ResultInt != 0)
                    {
                        //SplashScreenManager.CloseForm(true);

                        //string[] temp = result.ResultString.Split(':');
                        //if (temp.Length > 0)
                        //    iDATMessageBox.ErrorMessage("Part No :" + temp[0] + "\r\n" + BASE_Language.GetMessageString(temp[1]), this.Text, 5);
                        //else
                            iDATMessageBox.ErrorMessage(BASE_Language.GetMessageString(result.ResultString), this.Text, 5);
                    }
                    else
                    {
                        //SplashScreenManager.Default.SendCommand(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM.WaitFormCommand.SetDescription, "COMPLETE");

                        GetGridViewList();

                        //SplashScreenManager.CloseForm(true);
                    }
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Process pc = new Process();
            pc.StartInfo.FileName = Application.StartupPath + @"\Excel\PRODUCTION_PLAN_UPLOAD.xlsx";
            pc.StartInfo.Verb = "Open";
            pc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            pc.Start();
        }

        private void btnUploadExcelFormXls_Click(object sender, EventArgs e)
        {
            Process pc = new Process();
            pc.StartInfo.FileName = Application.StartupPath + @"\Excel\PRODUCTION_PLAN_UPLOAD.xls";
            pc.StartInfo.Verb = "Open";
            pc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            pc.Start();
        }

        private void gvList_RowCellStyle(object sender, GridAlias.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;

            if (e.RowHandle >= 0)
            {
                string bom_check;

                if (e.Column.FieldName.Contains("BOM_CHECK"))
                {
                    bom_check = View.GetRowCellDisplayText(e.RowHandle, View.Columns[e.Column.FieldName]).ObjectNullString();

                    if (bom_check == "N")
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                }
            }
        }
    }
}
