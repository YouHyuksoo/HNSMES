using System;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
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

namespace HAENGSUNG_HNSMES_UI.Forms.MST
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : MSTA206<br/>
    ///      기능 : BOM 마스터 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    public partial class MSTA206 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {
        // ******************************************* Base From Class ************************************
        // BASE_clsDevexpressGridUtil          DevExpress Grid 관련 Util Class.
        // BASE_db;                            웹서비스 DB처리 관련 Util Class.
        // BASE_DXGridHelper;                  DevExpress GridControl 데이터 Bind관련 Class
        // BASE_DXGridLookUpHelper;            DevExpress GridLookUp 데이터 Bind관련 Class
        // BASE_IDATLayoutUtil;                DevExpress LayoutControl Util Class.
        // BASE_Language;                      Language Util. ex) BASE_Language.GetMessageString("Code") 
        // ************************************************************************************************
        #region [Property & Member]

        DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositorySpin = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
        DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox_USEYN = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
        DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox_SIDE = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
        DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButton = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
        DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();

        private string m_ProgramMessage = "";

        // 프로그램 메시지를 출력합니다.
        public string ProgramMessage
        {
            get { return m_ProgramMessage; }
            set
            {
                if (Program.frmM != null)
                {
                    Program.frmM.ProgramMessage = value;
                }

                m_ProgramMessage = value;
            }
        }

        #endregion


        #region 생성

        public MSTA206
()
        {
            InitializeComponent();
        }

        private void MSTA206_Load(object sender, EventArgs e)
        {
            
        }

        private void MSTA206_Shown(object sender, EventArgs e)
        {
            this.Set_Init();
            this.GetGridViewList(true);
            gvBOMgrp.FocusedRowHandle = -1;
            this.Set_InitTreeList();
            gvBOMgrp.OptionsBehavior.Editable = false;
            tlBOM.OptionsBehavior.Editable = false;

        }

        #endregion

        #region 버튼이벤트

        public void InitButton_Click()
        {
            // 초기화 관련 구현은 여기에 구현 ***
            // 상세 항목들을 모두 클리어 한다.
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);

            this.Set_Init();
            this.GetGridViewList(true);
            gvBOMgrp.FocusedRowHandle = - 1;
            this.Set_InitTreeList();
        }

        public void NewButton_Click()
        {
            gvBOMgrp.OptionsBehavior.Editable = false;
            gvBOMgrp.Columns["BOMGRP"].OptionsColumn.AllowEdit = true;
            gvBOMgrp.Columns["REV"].OptionsColumn.AllowEdit = true;

        }

        public void EditButton_Click()
        {
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit);

            gvBOMgrp.OptionsBehavior.Editable = true;
            gvBOMgrp.Columns["USEFLAG"].ColumnEdit = repositoryItemComboBox_USEYN;
            gvBOMgrp.Columns["USEFLAG"].OptionsColumn.AllowEdit = true;
        }

        public void StopButton_Click()
        {
        }

        public void SaveButton_Click()
        {
            if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.None)
            {
                return;
            }

            // 저장전에 필수 항목에 대한 Null 값을 초기화 합니다.
            // 유효성검사 다시 수행
            base.baseDxErrorProvider.ClearErrors();
            ValidateChildren(ValidationConstraints.Visible);

            // 유효성 검사를 한다.
            if (base.baseDxErrorProvider.HasErrors)
            {
                return;
            }

            string _strBOMgrp = "";
            string _strGrpRev = "";
            string _strUseyn = "";

            if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit)
            {
                // ****** 마지막 수정항목을 데이터셋에 적용 시킬려면 포커스를 이동을 한다.
                gvBOMgrp.FocusedRowHandle = -1;

                // 수정,추가,변경 된 데이터를 모두 가져온다.
                DataTable _dt = gvBOMgrp.EX_GetChangedData();

                if (_dt == null)
                    return;

                // 변경된 데이터가 없으면 return.
                if (_dt.Rows.Count == 0) return;

                //// 변경된 데이터를 루프를 통해 하나씩 빼낸다.
                foreach (DataRow _dr in _dt.Rows)
                {
                    switch (_dr.RowState)
                    {
                        case DataRowState.Modified:

                            _strBOMgrp = _dr["BOMGRP"].ObjectNullString();
                            _strGrpRev = _dr["REV"].ObjectNullString();
                            _strUseyn = _dr["USEFLAG"].ObjectNullString();

                            bool bReturn = BASE_db.Execute_Proc( "PKGBAS_BASE.PUT_BOMGRP"
                                                               , 2
                                                               , new string[] {
                                                                 "A_CLIENT"
                                                               , "A_COMPANY"
                                                               , "A_PLANT"  
                                                               , "A_BOMGRP"
                                                               , "A_GRPREV"
                                                               , "A_USEFLAG"
                                                               , "A_USER" }
                                                               , new string[] {
                                                                 Global.Global_Variable.CLIENT
                                                               , Global.Global_Variable.COMPANY
                                                               , Global.Global_Variable.PLANT
                                                               , _strBOMgrp
                                                               , _strGrpRev
                                                               , _strUseyn
                                                               , Global.Global_Variable.EHRCODE }
                                                               , true
                                                               );

                            if (!bReturn)
                                return;

                            break;

                        default:
                            break;
                    }
                }

                MainButton_INIT.PerformClick();

                //마지막 처리 된 값쪽에 포커스를 이동 시킵니다. 사용시에 주석을 해제하고 수정하세요.
                gvBOMgrp.EX_GetFocuseRowCell("BOMGRP", _strBOMgrp);
            }
           
        }

        public void PrintButton_Click()
        {
        }

        public void RefreshButton_Click()
        {
            this.Set_RefreshMemberList();
        }

        public void DeleteButton_Click()
        {
        }

        public void SearchButton_Click()
        {
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            /*BOM 복사 기능 삭제*/
            //using (PopUp.MSTB003_PopUp frm = new PopUp.MSTB003_PopUp())
            //{
            //    frm._ParentForm = this;
            //    frm.FormClass = this.FormClass;
            //    frm.ShowDialog();
            //}
        }
        #endregion

        #region 함수

        private void Edit_UserInfo()
        {
            
        }

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

                        DataTable dt = ReadExcelFile(excelFile, sheetName);

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
                    return null;
                }
                finally
                {
                    dtSheets.Dispose();
                }
            }
            return sheetNames;
        }

        private DataTable ReadExcelFile(string sPath, string sSheetName)
        {
            string sConnectionString;
            OleDbConnection conn;
            OleDbCommand comm;
            OleDbDataAdapter adap;
            DataTable dtXls;

            try
            {
                string[] arrText = sPath.ToString().Split(new char[] { '.' });

                if (arrText[arrText.Length - 1].ToString() == "xls")
                    sConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sPath + ";Extended Properties=\"Excel 8.0;HDR=No;IMEX=1\"";
                else
                    sConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sPath + ";Extended Properties=\"Excel 12.0;HDR=No;IMEX=1\"";


                using (conn = new OleDbConnection(sConnectionString))
                {
                    using (comm = new OleDbCommand())
                    {
                        using (adap = new OleDbDataAdapter())
                        {
                            comm.Connection = conn;
                            comm.CommandType = CommandType.Text;
                            comm.CommandText = "select * from [" + sSheetName + "$]";

                            adap.SelectCommand = comm;

                            using (dtXls = new System.Data.DataTable())
                            {
                                adap.Fill(dtXls);
                                //dtXls.Rows.RemoveAt(0);

                                DataTable dt = dtXls.Clone();

                                dt.BeginLoadData();
                                foreach (DataRow dr in dtXls.Rows)
                                {
                                    if (dr["F1"] + "" != "")
                                    {
                                        DataRow drNew = dt.NewRow();
                                        foreach (DataColumn dc in dtXls.Columns)
                                        {
                                            drNew[dc.ColumnName] = dr[dc.ColumnName];
                                        }
                                        dt.Rows.Add(drNew);
                                    }
                                }
                                dt.EndLoadData();
                                dt.AcceptChanges();
                                //dtXls.Rows.RemoveAt(0);
                                return dt;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                iDATMessageBox.WARNINGMessage(ex.Message, this.Text, 3);
                return null;
            }
        }

        private void SaveData(string p_strBOMgrp, string p_strGrpRev, string p_stritem, string p_strUpritem, string p_strUprPrtitem, 
                              string p_strSeq, string p_strUsage, string p_strLocation, string p_strUseyn, string p_strSide,
                              string p_strStartDate, string p_strEndDate, string p_strOper)
        {

            BASE_db.Execute_Proc( "PKGBAS_BASE.PUT_BOM"
                                , 1
                                , new string[] {
                                  "A_CLIENT"
                                , "A_COMPANY"
                                , "A_PLANT"  
                                , "A_BOMGRP"
                                , "A_GRPREV"
                                , "A_ITEM"
                                , "A_UPRITEM"
                                , "A_UPRPARENTITEM"
                                , "A_SEQ"  
                                , "A_USAGE"  
                                , "A_SIDE"
                                , "A_LOCATION"
                                , "A_STARTDATE"
                                , "A_ENDDATE"
                                , "A_USEFLAG"   
                                , "A_OPER"
                                , "A_USERID" }
                                , new string[] {
                                  Global.Global_Variable.CLIENT
                                , Global.Global_Variable.COMPANY
                                , Global.Global_Variable.PLANT
                                , p_strBOMgrp
                                , p_strGrpRev
                                , p_stritem
                                , p_strUpritem
                                , p_strUprPrtitem
                                , p_strSeq
                                , p_strUsage
                                , p_strSide
                                , p_strLocation
                                , p_strStartDate
                                , p_strEndDate
                                , p_strUseyn
                                , p_strOper
                                , Global.Global_Variable.EHRCODE }
                                , true
                                );
        }

        private void Set_Init()
        {
            
            // Repository Item 셋팅
            repositorySpin.MinValue = 1;
            repositorySpin.MaxValue = 9999;
            repositorySpin.SpinStyle = DevExpress.XtraEditors.Controls.SpinStyles.Horizontal;
            repositorySpin.Buttons[0].Visible = false;

            // Repository Item 셋팅
            repositoryItemComboBox_USEYN.AutoHeight = false;
            repositoryItemComboBox_USEYN.Items.Clear();
            repositoryItemComboBox_USEYN.Items.AddRange(new object[] { "Y", "N" });
            repositoryItemComboBox_USEYN.Name = "repositoryItemComboBox_USEYN";
            repositoryItemComboBox_USEYN.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            // Repository 버튼 셋팅
            repositoryItemButton.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            repositoryItemButton.Buttons[0].Image = Properties.Resources.init_1;
            repositoryItemButton.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repositoryItemButton.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(repositoryItemButton_ButtonClick);
            

            //Repository Combobox 셋팅
            repositoryItemComboBox_SIDE.AutoHeight = false;
            repositoryItemComboBox_SIDE.Items.Clear();
            repositoryItemComboBox_SIDE.Items.AddRange(new object[] { "N", "T", "B" });
            repositoryItemComboBox_SIDE.Name = "repositoryItemComboBox_SIDE";
            repositoryItemComboBox_SIDE.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            //Repository Dateedit 셋팅
            repositoryDateEdit.DisplayFormat.FormatString = "yyyy-MM-dd";
            repositoryDateEdit.EditFormat.FormatString = "yyyy-MM-dd";
        }

        private void GetGridViewList( bool b_initItems)
        {
            /// BOM 그룹 리스트를 가져온다.
            BASE_DXGridHelper.Bind_Grid( gcBOMgrp
                                       , "PKGBAS_BASE.GET_BOMGRP"
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
                                       , "BOMGRP, REV, ITEMCNT, SUBITEMCNT, STARTDATE, ENDDATE, USEFLAG "
                                       );

            gvBOMgrp.OptionsView.ShowGroupPanel = false;
            gvBOMgrp.OptionsView.ColumnAutoWidth = false;
            gvBOMgrp.BestFitColumns();

            gvBOMgrp.OptionsBehavior.Editable = false;

        }


        private void Set_InitTreeList()
        {
            ///// BOM Tree 바인딩
            if (gvBOMgrp.GetFocusedDataRow() == null) return;

            WSResults resultDS = BASE_db.Execute_Proc( "PKGBAS_BASE.GET_BOM"
                                                     , 2
                                                     , new string[] {
                                                       "A_CLIENT"
                                                     , "A_COMPANY"
                                                     , "A_PLANT"
                                                     , "A_BOMGRP"
                                                     , "A_GRPREV" }
                                                     , new string[] {
                                                       Global.Global_Variable.CLIENT
                                                     , Global.Global_Variable.COMPANY
                                                     , Global.Global_Variable.PLANT
                                                     , gvBOMgrp.GetFocusedDataRow()["BOMGRP"] + ""
                                                     , gvBOMgrp.GetFocusedDataRow()["REV"] + "" }
                                                     );


            if (resultDS.ResultInt != 0)
            {
                return;
            }

            tlBOM.Update();

            //resultDS.ReturnDataSet.Tables[0].Columns.Add("UPRPARENT", Type.GetType("System.String"));

            tlBOM.KeyFieldName = "IDX";
            tlBOM.ParentFieldName = "UPRIDX";
            tlBOM.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowAlways;
            tlBOM.DataSource = resultDS.ResultDataSet.Tables[0];
            tlBOM.OptionsView.ShowColumns = true;
            tlBOM.OptionsBehavior.Editable = false;
            tlBOM.OptionsView.ShowRoot = true;
            
            tlBOM.Columns["DISP_NO"].Visible = false;
            tlBOM.Columns["SEQ"].Visible = false;
            tlBOM.Columns["ITEMCODE"].Visible = false;
            tlBOM.Columns["UPRITEM"].Visible = false;
            tlBOM.Columns["UPRPARENT"].Visible = false;
            tlBOM.Columns["USEFLAG"].Visible = false;
            tlBOM.Columns["STARTDATE"].Visible = false;
            tlBOM.Columns["ENDDATE"].Visible = false;
            tlBOM.Columns["SUBITEMS"].Visible = false;

            tlBOM.OptionsBehavior.AutoChangeParent = false;
            tlBOM.OptionsBehavior.CanCloneNodesOnDrop = true;
            tlBOM.OptionsBehavior.CloseEditorOnLostFocus = false;
            tlBOM.OptionsBehavior.DragNodes = true;
            tlBOM.OptionsBehavior.KeepSelectedOnClick = false;
            tlBOM.OptionsBehavior.ShowEditorOnMouseUp = true;
            tlBOM.OptionsBehavior.SmartMouseHover = false;

            
            tlBOM.Columns["ITEMNAME"].OptionsColumn.AllowEdit = false;
            tlBOM.Columns["SEQ"].OptionsColumn.AllowEdit = false;

            tlBOM.Columns["ASSYUSAGE"].ColumnEdit =  repositorySpin;
            tlBOM.Columns["PARTNO"].ColumnEdit = repositoryItemButton;
            tlBOM.Columns["STARTDATE"].ColumnEdit = repositoryDateEdit;
            tlBOM.Columns["ENDDATE"].ColumnEdit = repositoryDateEdit;
            tlBOM.Columns["SIDE"].ColumnEdit = repositoryItemComboBox_SIDE;

            tlBOM.Columns["PARTNO"].VisibleIndex = 0;
            

            for (int i = 0; i < tlBOM.Columns.Count; i++)
            {
                tlBOM.Columns[i].OptionsColumn.AllowSort = false;
            }

            tlBOM.OptionsView.AutoWidth = false;

            tlBOM.Columns["ASSYUSAGE"].Format.FormatString = "{0}";

            tlBOM.Columns["PARTNO"].Caption = BASE_Language.GetMessageString("PARTNO");
            tlBOM.Columns["ASSYUSAGE"].Caption = BASE_Language.GetMessageString("ASSYUSAGE");
            tlBOM.Columns["SUBITEMFLAG"].Caption = BASE_Language.GetMessageString("SUBITEMFLAG");
            tlBOM.Columns["SIDE"].Caption = BASE_Language.GetMessageString("SIDE");
            tlBOM.Columns["ITEMNAME"].Caption = BASE_Language.GetMessageString("ITEMNAME");
            tlBOM.Columns["UNITCODE"].Caption = BASE_Language.GetMessageString("UNITCODE");
            tlBOM.Columns["STARTDATE"].Caption = BASE_Language.GetMessageString("STARTDATE");
            tlBOM.Columns["ENDDATE"].Caption = BASE_Language.GetMessageString("ENDDATE");
            tlBOM.Columns["LOCATION"].Caption = BASE_Language.GetMessageString("LOCATION");
            tlBOM.Columns["OPERNAME"].Caption = BASE_Language.GetMessageString("OPERNAME");

            tlBOM.BestFitColumns();


            // 스타일 설정
            //SetStyleFormatCondition_CustomRootMenu(tlBOM, "USEFLAG", "N", GetStyleFormatObjApperanceColor_USEYN);


            tlBOM.Cursor = Cursors.Hand;
            tlBOM.ExpandAll();

            //resultDS.ReturnDataSet.Tables[0].AcceptChanges();


        }


        private void Set_RefreshMemberList()
        { 
            /// BOM 그룹 리스트를 가져온다.
            BASE_DXGridHelper.Refresh_Grid( gcBOMgrp
                                          , "PKGBAS_BASE.GET_BOMGRP"
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
                                          , "BOMGRP, REV, ITEMCNT, SUBITEMCNT, STARTDATE, ENDDATE, USEFLAG"
                                          );

            //gvBOMgrp.OptionsView.ShowGroupPanel = false;
            //gvBOMgrp.OptionsView.ColumnAutoWidth = false;
            //gvBOMgrp.BestFitColumns();
        }


        #endregion

        #region [트리리스트 스타일 관련 함수]

        /// <summary>
        /// 그리드뷰의 FormatCondition 스타일 지정
        /// </summary>
        /// <param name="gridView">그리드 뷰</param>
        /// <param name="columnFieldString">컬럼필드명</param>
        /// <param name="MathValue">매칭 포멧 명</param>
        /// <param name="apperanceObj">FormatCondition Style</param>
        public void SetStyleFormatCondition_CustomRootMenu(TreeList tl_obj, string columnFieldString, object MathValue, DevExpress.Utils.AppearanceObject apperanceObj)
        {
            DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition styleFormatCondition = new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition();

            tl_obj.FormatConditions.Add(styleFormatCondition);
            styleFormatCondition.Appearance.Combine(apperanceObj);
            styleFormatCondition.Column = tl_obj.Columns[columnFieldString];
            styleFormatCondition.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition.ApplyToRow = true;
            styleFormatCondition.Value1 = MathValue;
        }

        private DevExpress.Utils.AppearanceObject objApperanceColor = new DevExpress.Utils.AppearanceObject();

        public DevExpress.Utils.AppearanceObject GetStyleFormatObjApperanceColor_New
        {
            get
            {
                objApperanceColor.Font = new System.Drawing.Font("Tahoma", 9F, FontStyle.Bold);
                objApperanceColor.ForeColor = Color.Black;
                objApperanceColor.BackColor = Color.Bisque;
                objApperanceColor.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;

                return objApperanceColor;
            }
        }

        public DevExpress.Utils.AppearanceObject GetStyleFormatObjApperanceColor_USEYN
        {
            get
            {
                objApperanceColor.Font = new System.Drawing.Font("Tahoma", 9F, FontStyle.Strikeout);
                objApperanceColor.ForeColor = Color.Gray;
                objApperanceColor.BackColor = Color.White;
                objApperanceColor.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;

                return objApperanceColor;
            }
        }

        #endregion

        #region 일반이벤트

        private void gvList_Click(object sender, EventArgs e)
        {
            //if (!(sender is GridAlias.GridView))
            //{
            //    return;
            //}

            ////IDAT.Controls.IDATDevExpress _clsGrid = new IDAT.Controls.IDATDevExpress();

            //GridAlias.GridView gridView = sender as GridAlias.GridView;
            //DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo gridHitINFO = BASE_clsDevexpressGridUtil.GetClickHitInfo(gvList, e);

            //if (gridHitINFO.InRow && gridHitINFO.InColumn)
            //{
            //    /// ============================================================
            //    /// 선택된 Row의 정보를 가져올려면 아래에 구현을 하면 된다.
            //    int RowIdx = gridHitINFO.RowHandle;
            //    int ColIdx = gridHitINFO.Column.AbsoluteIndex;
            //}

            //if (gridHitINFO.InRowCell)
            //{
            //}

            //if (gridHitINFO.InColumn)
            //{
            //}

            //if (gridHitINFO.InGroupColumn)
            //{
            //}

            //if (gridHitINFO.InColumnPanel)
            //{
            //}

            //if (gridHitINFO.InFilterPanel)
            //{
            //}

            //if (gridHitINFO.InGroupColumn)
            //{
            //}
        }

        private void gvList_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            // 신규 상태일때 다른 컬럼을 선택시에 기능을 상실하도록 한다.
            // 구현상 기능이 필요하지 않으면 주석처리 하세요.
            //if (base.CurrentDataTYPE == BASE.UPDATEITEMTYPE.New)
            //{
            //    if (e.RowHandle == -2147483647)
            //    {
            //        e.Allow = false;
            //    }
            //}
        }

       
        #endregion

        #region [Repository Event]

        void repositoryItemButton_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.None)
                return;

            if (tlBOM.FocusedNode == null)
                return;

            if (iDATMessageBox.QuestionMessage("선택한 노드를 삭제 하시겠습니까?", "노드삭제") == DialogResult.Yes)
            {

                TreeListNode FNode = tlBOM.FocusedNode;
                TreeListNode PNode = tlBOM.FocusedNode.ParentNode;
                int NodeCount = FNode.Nodes.Count;

                ArrayList NodeList = new ArrayList();


                for (int i = 0; i < NodeCount; i++)
                {
                    NodeList.Add(FNode.Nodes[i]);
                }

                // 노드 삭제시 하위 노드를 삭제노드의 위치로 이동시킨다.
                for (int i = 0; i < NodeCount; i++)
                {
                    tlBOM.MoveNode((TreeListNode)NodeList[i], PNode);
                }

                // 선택한 노드를 삭제한다.
                tlBOM.DeleteNode(FNode);

            }
            tlBOM.BestFitColumns();

        }

        #endregion

        #region [Tree List]

        /// <summary>
        /// TreeList에 순서 Index를 부여한다.
        /// </summary>
        /// <param name="tl">TreeList</param>
        /// <param name="nodes">Nodes</param>
        /// <param name="fieldname">Seq 필드이름</param>
        private bool IsNodePK(TreeListNodes nodes, string partname)
        {
            foreach (TreeListNode node in nodes)
            {
                if (node.HasChildren)
                {
                    if (!IsNodePK(node.Nodes, partname))
                        return false;
                }

                if (node["ITEMCODE"].ToString() == partname)
                {
                    if (node.ParentNode == null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        
        private void DeleteNode(TreeListNode nodes)
        {
            try
            {
                foreach (TreeListNode node in nodes.Nodes)
                {
                    
                    if (node["NO"] == DBNull.Value)
                    {
                        tlBOM.DeleteNode(node);
                        (tlBOM.DataSource as DataTable).AcceptChanges();
                    }
                    //else
                    //{
                    //    node["USEFLAG"] = node["USEFLAG"].ToString() == "N" ? "N" : "N";
                    //}
                }
                if (nodes["NO"] == DBNull.Value)
                {
                    tlBOM.DeleteNode(nodes);
                    (tlBOM.DataSource as DataTable).AcceptChanges();
                }
                //else
                //{
                //    nodes["USEFLAG"] = nodes["USEFLAG"].ToString() == "N" ? "N" : "N";
                //}
            }
            catch (Exception)
            {
            }
        }


        #endregion

        #region [Grid Drag 기능]
        private void gcList_MouseDown(object sender, MouseEventArgs e)
        {
            //hitInfo = gvList.CalcHitInfo(new Point(e.X, e.Y));

        }

        private void gcList_MouseMove(object sender, MouseEventArgs e)
        {
            

            //if (hitInfo == null) return;
            //if (e.Button != MouseButtons.Left) return;
            //Rectangle dragRect = new Rectangle(new Point(
            //    hitInfo.HitPoint.X - SystemInformation.DragSize.Width / 2,
            //    hitInfo.HitPoint.Y - SystemInformation.DragSize.Height / 2), SystemInformation.DragSize);
            //if (!dragRect.Contains(new Point(e.X, e.Y)))
            //{
            //    if (hitInfo.InRow)
            //    {
            //        DataRow dr = gvList.GetDataRow(hitInfo.RowHandle);
            //        gcList.DoDragDrop(dr, DragDropEffects.Copy);
            //    }
            //}


        }

        #endregion

        #region [Tree Drag 기능]

        private void tlBOM_DragDrop(object sender, DragEventArgs e)
        {
            // 신규 / 수정 상태가 아니면 아이템을 추가하지 않는다.
            if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.None)
            {
                return;
            }

            
            // 저장전에 필수 항목에 대한 Null 값을 초기화 합니다.
            // 유효성검사 다시 수행
            base.baseDxErrorProvider.ClearErrors();
            ValidateChildren(ValidationConstraints.Visible);

            // 유효성 검사를 한다.
            if (base.baseDxErrorProvider.HasErrors)
            {
                return;
            }

            TreeListHitInfo hi = tlBOM.CalcHitInfo(tlBOM.PointToClient(new Point(e.X, e.Y)));
            DataRow dr = e.Data.GetData("System.Data.DataRow") as DataRow;

            TreeListNode node = hi.Node;

            // 추가하려는 노드가 상위 노드이면 다른 상위노드의 하위노드에 있는지 확인. 무한루프 돌기때문에.
            if (node == null)
            {
                if (!IsNodePK(tlBOM.Nodes, dr["ITEMCODE"].ToString() + ""))
                {
                    iDATMessageBox.WARNINGMessage("다른 상위 아이템에 속해 있는 아이템입니다.", this.Text, 5);
                    return;
                }
            }

            if (dr != null)
            {
                
                if (node != null)
                {
                    foreach (TreeListNode tnode in node.Nodes)
                    {
                        if (tnode["ITEMCODE"].ToString() == dr["ITEMCODE"].ToString())
                        {
                            tnode["USEFLAG"] = "Y";
                            tnode.Visible = true;
                            return;
                        }
                    }
                }
                else
                {
                    foreach (TreeListNode tnode in tlBOM.Nodes)
                    {
                        if (tnode["ITEMCODE"].ToString() == dr["ITEMCODE"].ToString())
                        {
                            tnode["USEFLAG"] = "Y";
                            tnode.Visible = true;
                            return;
                        }

                    }
                }


                TreeListNode Newnode;
                //Newnode = tlBOM.AppendNode(null, node);

                if (node == null)
                {
                    // 왜그럴까?
                    Newnode = tlBOM.AppendNode(new object[] { "1"                            //DISP_NO
                                                             ,dr["ITEMCODE"]                 //ITEMCODE
                                                             ,dr["PARTNO"]                   //PARTNO
                                                             ,dr["ITEMNAME"].ToString()      //ITEMNAME
                                                             ,dr["DRWNO"]                    //DRWNO
                                                             ,dr["OPER"]                 //OPER
                                                             ,"0"                            //UPRITEM
                                                             ,""                             //UPRPARENT
                                                             ,"1"                            //ASSYUSAGE
                                                             ,"N"                           //SUBITEMFLAG
                                                             ,""                              //SIDE
                                                             , dr["UNITCODE"]                //UNITCODE
                                                             ,""                                //LOCATION
                                                             ,"Y"                            //USEFLAG
                                                             ,"0"                            //UPRIDX
                                                             ,""                             //IDX
                                                             ,""                             //PROJECT
                                                             ,"1"                            //SEQ
                                                            }, 0);


                }
                else Newnode = tlBOM.AppendNode(new object[] { "1"                           //DISP_NO
                                                             ,dr["ITEMCODE"]                 //ITEMCODE
                                                             ,dr["PARTNO"]                   //PARTNO
                                                             ,dr["ITEMNAME"].ToString()      //ITEMNAME
                                                             ,dr["DRWNO"]                    //DRWNO
                                                             ,dr["OPER"]                 //OPER
                                                             ,node["ITEMCODE"]               //UPRITEM
                                                             ,node["UPRITEM"]                //UPRPARENT
                                                             ,"1"                            //ASSYUSAGE
                                                             ,"N"                           //SUBITEMFLAG
                                                             ,""                              //SIDE
                                                             , dr["UNITCODE"]                //UNITCODE
                                                             ,""                                //LOCATION
                                                             ,"Y"                            //USEFLAG
                                                             ,""                             //UPRIDX
                                                             ,""                             //IDX
                                                             ,""                             //PROJECT
                                                             ,"1"                            //SEQ

                                                            }, node);


                if (node != null)
                {
                    //Newnode["UPRITEM"] = node["ITEMCODE"];
                    //Newnode["UPRPARENT"] = node["UPRITEM"];

                    node.Expanded = true;
                }
                //else
                //{
                //    Newnode["UPRIDX"] = "0";
                //    Newnode["UPRITEM"] = "0";
                //}

                //Newnode["USEFLAG"] = "Y";
                //Newnode["ITEMCODE"] = dr["ITEMCODE"];
                //Newnode["PARTNO"] = dr["PARTNO"];
                //Newnode["ITEMNAME"] = dr["ITEMNAME"].ToString();
                //Newnode["ASSYUSAGE"] = 1;


            }
        }


        private void tlBOM_DragEnter(object sender, DragEventArgs e)
        {
            // 신규 / 수정 상태가 아니면 아이템을 추가하지 않는다.
            if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.None)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            else
            {
                e.Effect = DragDropEffects.Copy;

            }
        }

        private void tlBOM_AfterDragNode(object sender, NodeEventArgs e)
        {
            if (e.Node.ParentNode != null)
            {
                e.Node["UPRITEM"] = e.Node.ParentNode["ITEMCODE"];
            }
            else
            {
                e.Node["UPRITEM"] = "0";
            }
        }


        private void tlBOM_BeforeDragNode(object sender, BeforeDragNodeEventArgs e)
        {
            if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.None)
            {
                e.CanDrag = false;
            }
        }


        #endregion

        #region [Tree Drag 기능]

        private void listBoxControl1_DragDrop(object sender, DragEventArgs e)
        {
            tlBOM_DragDrop(sender, e);
        }

        private void listBoxControl1_DragEnter(object sender, DragEventArgs e)
        {
            // 신규 / 수정 상태가 아니면 아이템을 추가하지 않는다.
            if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.None)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            else
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        #endregion


        private void gvBOMgrp_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
            {
                return;
            }


            this.Set_InitTreeList();
        }

        private void gvBOMgrp_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
            {
                if (e.RowHandle == index)
                    e.Allow = false;
            }
        }

        private void tlBOM_MouseMove(object sender, MouseEventArgs e)
        {
            TreeListHitInfo hi = tlBOM.CalcHitInfo(new Point(e.X, e.Y));

            if (hi.Node != null)
            {
                lblPos.Text = "Node: " + hi.Node.Id.ToString() + " Type: "  + hi.HitInfoType.ToString();
            }
            else
            {
                lblPos.Text = "None";
            }
             

            lblPos2.Text = "X: " + e.X.ToString() + "    Y: " + e.Y.ToString();
        }


        int index = -1;
        private void gvBOMgrp_InitNewRow(object sender, GridAlias.InitNewRowEventArgs e)
        {
            index = gvBOMgrp.GetDataSourceRowIndex(e.RowHandle);
        }

        private void tlBOM_DoubleClick(object sender, EventArgs e)
        {
            TreeListNode node = tlBOM.FocusedNode;

            if (node != null)
            {
                using (PopUp.MSTA206_PopUp2 pop = new PopUp.MSTA206_PopUp2())
                {
                    pop.txtIdx.EditValue = node["IDX"];
                    pop.txtSeq.EditValue = node["SEQ"];
                    pop.txtBomGrp.EditValue = gvBOMgrp.GetRowCellValue(gvBOMgrp.FocusedRowHandle, "BOMGRP");
                    pop.txtPartNo.EditValue = node["PARTNO"];
                    pop.ShowDialog(this);
                }

                this.Set_InitTreeList();
            }
        }

        private void btnUploadExcelForm_Click(object sender, EventArgs e)
        {
            Process pc = new Process();
            pc.StartInfo.FileName = Application.StartupPath + @"\Excel\BOMUPLOAD.xlsx";
            pc.StartInfo.Verb = "Open";
            pc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            pc.Start();
        }

        private void btnUploadExcelFormXls_Click(object sender, EventArgs e)
        {
            Process pc = new Process();
            pc.StartInfo.FileName = Application.StartupPath + @"\Excel\BOMUPLOAD.xls";
            pc.StartInfo.Verb = "Open";
            pc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            pc.Start();
        }

        private void btnBomUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.RestoreDirectory = true;
            ofd.Filter = "Excel Files(*.xls, *.xlsx, *.xlt)|*.xls;*.xlsx;*.xlt";
            //ofd.FilterIndex = 1;
            //

            if (txtFileInfo.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.ErrorMessage("MSG_QS_BOM_003", this.Text, 3); //도면을 선택해주세요.
                return;
            }

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string _strFilePath = ofd.FileName;

                // Sheet명 조회
                //ArrayList _alSheetName = ExcelSheetNames(_strFilePath);

                //if (_alSheetName == null || _alSheetName.Count == 0)
                //{
                //    LanguageInformation _clsLan = new LanguageInformation();
                //    string _strMsg = _clsLan.GetMessageString("MSG_ER_MST_004"); //Sheet를 찾을 수 없습니다.
                //    iDATMessageBox.WARNINGMessage(_strMsg, this.Text, 3);

                //    //MainButton_INIT.PerformClick();
                //}
                //else
                //{
                    DataTable dTable = ReadExcelFile(_strFilePath, "MESBOM");

                    if (dTable == null)
                        return;

                    dTable.Rows.RemoveAt(0);
                    string _strModel = dTable.Rows[0]["F1"].ObjectNullString();

                    //gvBOMgrp.SetRowCellValue(gvBOMgrp.FocusedRowHandle, "BOMGRP", _strModel);
                    //gvBOMgrp.SetRowCellValue(gvBOMgrp.FocusedRowHandle, "REL", "1");

                    LanguageInformation _clsLan = new LanguageInformation();
                    string _strMsg = _clsLan.GetMessageString("MSG_QS_BOM_001"); //선택한 파일의 자재 장착 목록을 저장하시겠습니까?\r\n기존 데이터는 삭제됩니다.

                    if (iDATMessageBox.QuestionMessage(_strMsg, this.Text) == System.Windows.Forms.DialogResult.Yes)
                    {
                        SplashScreenManager.ShowForm(typeof(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM), true, false);
                        SplashScreenManager.Default.SendCommand(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM.WaitFormCommand.SetDescription, "BOM Creating...");

                        string _strXml = base.GetDataTableToXml(dTable);
                        WSResults result = BASE_db.Execute_Proc( "PKGBAS_BASE.PUT_BOM"
                                                               , 1
                                                               , new string[] {
                                                                 "A_CLIENT"
                                                               , "A_COMPANY"
                                                               , "A_PLANT"
                                                               , "A_BOMGRP"
                                                               , "A_GRPREV"
                                                               , "A_XML"
                                                               , "A_FPATH"
                                                               , "A_USERID" }
                                                               , new string[] {
                                                                 Global.Global_Variable.CLIENT
                                                               , Global.Global_Variable.COMPANY
                                                               , Global.Global_Variable.PLANT
                                                               , _strModel
                                                               , "1"
                                                               , _strXml
                                                               , Path.GetFileName(txtFileInfo.EditValue.ObjectNullString())
                                                               , Global.Global_Variable.EHRCODE }
                                                               );

                        if (result.ResultInt != 0)
                        {
                            SplashScreenManager.CloseForm(true);

                            string[] temp = result.ResultString.Split(':');
                            if (temp.Length > 0 )
                                iDATMessageBox.ErrorMessage("Part No :" + temp[0] + "\r\n" +  BASE_Language.GetMessageString(temp[1]), this.Text, 5);
                            else
                                iDATMessageBox.ErrorMessage(BASE_Language.GetMessageString(result.ResultString), this.Text, 5);
                        }
                        else
                        {
                            SplashScreenManager.Default.SendCommand(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM.WaitFormCommand.SetDescription, "BOM Listing");
                            
                            SetFileupload(result.ResultDataSet.Tables[0]);
                            
                            this.Set_RefreshMemberList();
                            gvBOMgrp.FocusedRowHandle = -1;
                            gvBOMgrp.EX_GetFocuseRowCell(new string[] { "BOMGRP", "REV" }, new string[] { _strModel, result.ResultString });

                            this.Set_InitTreeList();

                            SplashScreenManager.CloseForm(true);
                        }

                        txtFileInfo.EditValue = "";
                    }
                //}
            }
        }
        private void SetFileupload(DataTable dtUrl)
        {
            /*검사성적서(친환경) 업로드*/
                if (txtFileInfo.EditValue.ObjectNullString() != "")
                {
                    FTPHelper ftp = new FTPHelper(Global.Global_Variable.FTP_IP, Global.Global_Variable.FTP_ID, Global.Global_Variable.FTP_PW);

                    if (!ftp.checkDirectoryExists(dtUrl.Rows[0]["LEVEL1"].ObjectNullString()))
                        ftp.createDirectory(dtUrl.Rows[0]["LEVEL1"].ObjectNullString());

                    ftp.createDirectory(dtUrl.Rows[0]["LEVEL1"].ObjectNullString() + "/" + dtUrl.Rows[0]["LEVEL2"].ObjectNullString());

                    ftp.upload(dtUrl.Rows[0]["LEVEL1"].ObjectNullString() + "/" + dtUrl.Rows[0]["LEVEL2"].ObjectNullString() + "/" + dtUrl.Rows[0]["LEVEL3"].ObjectNullString(), txtFileInfo.EditValue.ObjectNullString());
                }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            LanguageInformation _clsLan = new LanguageInformation();
            string _strMsg = _clsLan.GetMessageString("MSG_QS_BOM_002"); //Do you want to auto-register the BOM replace item?

            if (iDATMessageBox.QuestionMessage(_strMsg, this.Text) == System.Windows.Forms.DialogResult.Yes)
            {
                SplashScreenManager.ShowForm(typeof(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM), true, false);
                SplashScreenManager.Default.SendCommand(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM.WaitFormCommand.SetDescription, "BOM Creating...");

                BASE_db.Execute_Proc("PKGBAS_BASE.PUT_BOM_RELEASE",
                                                         1,
                                                         new string[] {
                                                                    "A_CLIENT"
                                                                  , "A_COMPANY"
                                                                  , "A_PLANT"
                                                                  },
                                                         new string[] {
                                                                     Global.Global_Variable.CLIENT
                                                                   , Global.Global_Variable.COMPANY
                                                                   , Global.Global_Variable.PLANT
                                                                  }
                                                       );

                BASE_db.Execute_Proc("PKGBAS_BASE.PUT_BOM_FIND2",
                                                         1,
                                                         new string[] {
                                                                    "A_CLIENT"
                                                                  , "A_COMPANY"
                                                                  , "A_PLANT"
                                                                  },
                                                         new string[] {
                                                                     Global.Global_Variable.CLIENT
                                                                   , Global.Global_Variable.COMPANY
                                                                   , Global.Global_Variable.PLANT
                                                                  }
                                                       );

                BASE_db.Execute_Proc("PKGBAS_BASE.PUT_BOM_SUBITEM_ALL",
                                                         1,
                                                         new string[] {
                                                                    "A_CLIENT"
                                                                  , "A_COMPANY"
                                                                  , "A_PLANT"
                                                                  , "A_USERID"
                                                                  },
                                                         new string[] {
                                                                     Global.Global_Variable.CLIENT
                                                                   , Global.Global_Variable.COMPANY
                                                                   , Global.Global_Variable.PLANT
                                                                   , Global.Global_Variable.EHRCODE
                                                                  }
                                                       );
                SplashScreenManager.CloseForm(true);
            }

        }

        private void btnFileInfo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = "C:\\";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFileInfo.EditValue = ofd.FileName;

            }
        }
    }
}
