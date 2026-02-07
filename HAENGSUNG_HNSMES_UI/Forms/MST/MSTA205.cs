using System;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;

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
    ///    화면명 : MSTA205<br/>
    ///      기능 : 품목 마스터 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    public partial class MSTA205 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
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

        public MSTA205()
        {
            InitializeComponent();
        }

        
        private void MSTA205_Load(object sender, EventArgs e)
        {
            
        }
        private void MSTA205_Shown(object sender, EventArgs e)
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
            this.GetGridViewList();
        }

        public void NewButton_Click()
        {
            // 신규 관련 구현은 여기에 구현.
                        
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New);

            // 그리드뷰에 새로운 행과 초기값을 지정한다.
            //gvList.EX_AddNewRow();
            gvList.EX_AddNewRow(new string[] { "ITEMCODE" }, new string[] { "0" });


            gleTerminalFlag.EditValue = "N";
            rdgCurrflowFlag.SelectedIndex = 1;
            rdgQtyPack.SelectedIndex = 0;
            rdgQtyRelease.SelectedIndex = 1;
            txtitemCode.EditValue = 0;
            speSaftyQty.EditValue = 0;
            speBoxQty.EditValue = 0;
            speLotUnitQty.EditValue = 0;
            spePrintUnit.EditValue = 0;
            dteValidDate.DateTime =  DateTime.Now;

            txtPartno.Focus();
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

            string _stritemCode = "";
            string _stritemName = "";
            string _strPartNo = "";
            string _strCustPartNo = "";
            string _strSpec = "";
            string _strTool = "";
            string _strSize = "";
            string _strType = "";
            string _strRootItemcode = "";
            string _strRev = "";
            string _strItemtype = "";
            string _strUnitCode = "";
            string _strLotUnitqty = "";
            string _strBoxqty = "";
            string _strSaftyQty = "";
            string _strValiddate = "";
            string _strTerminalFlag = "";
            string _strCurrflowinflag = "";
            string _strUnitNo = "";
            string _strPrintUnit = "";
            string _strQtyoutFlag = "";
            string _strQtypackFlag = "";
            string _strPrinttype = "";
            string _strTactTime = "";
            string _strVisualTactTime = "";
            string _strExpiryDate = "";
            string _strLongTermDate = "";
            string _strLabelText = "";
            string _strUseyn = "";
            string _strRemarks = "";

            if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit)
            {
                DataTable _dt = BASE_clsDevexpressGridUtil.GetChangedData(gcList);

                //변경된 데이터가 없으면 return.
                if (_dt.Rows.Count == 0) return;

                // 변경된 데이터를 루프를 통해 하나씩 빼낸다.
                foreach (DataRow _dr in _dt.Rows)
                {
                    switch (_dr.RowState)
                    {
                        case DataRowState.Modified:
                            _stritemCode = _dr["ITEMCODE"].ObjectNullString();
                            _stritemName = _dr["ITEMNAME"].ObjectNullString();
                            _strPartNo = _dr["PARTNO"].ObjectNullString();
                            _strCustPartNo = _dr["CUSTPARTNO"].ObjectNullString();
                            _strSpec = _dr["SPEC"].ObjectNullString();
                            _strTool = _dr["TOOL"].ObjectNullString();
                            _strSize = _dr["PARTNOSIZE"].ObjectNullString();
                            _strType = _dr["PARTNOTYPE"].ObjectNullString();
                            _strRootItemcode = _dr["ROOTITEMCODE"].ObjectNullString();
                            _strRev = _dr["REV"].ObjectNullString();
                            _strItemtype = _dr["ITEMTYPE"].ObjectNullString();
                            _strUnitCode = _dr["UNITCODE"].ObjectNullString();
                            _strLotUnitqty = _dr["LOTUNITQTY"].ObjectNullString();
                            _strBoxqty = _dr["BOXQTY"].ObjectNullString();
                            _strSaftyQty = _dr["SAFTYQTY"].ObjectNullString();

                            if (_dr["VALIDFROMDATE"] + "" != "")
                                _strValiddate = Convert.ToDateTime(_dr["VALIDFROMDATE"] + "").ToString("yyyyMMdd");

                            _strTerminalFlag = _dr["TERMINALFLAG"].ObjectNullString();
                            _strCurrflowinflag = _dr["CURRFLOWINSFLAG"].ObjectNullString();
                            _strUnitNo = _dr["UNITNO"].ObjectNullString();
                            _strPrintUnit = _dr["PRINTUNIT"].ObjectNullString();
                            _strQtyoutFlag = _dr["QTYOUTFLAG"].ObjectNullString();
                            _strQtypackFlag = _dr["QTYPACKFLAG"].ObjectNullString();
                            _strPrinttype = _dr["PRINTTYPE"].ObjectNullString();
                            _strTactTime = _dr["TACTTIME"].ObjectNullString();
                            _strVisualTactTime = _dr["VISUALTACTTIME"].ObjectNullString();
                            _strExpiryDate = _dr["EXPIRYDATE"].ObjectNullString();
                            _strLongTermDate = _dr["LONGTERMDATE"].ObjectNullString();
                            _strLabelText = _dr["COLABELTEXT"].ObjectNullString();
                            _strUseyn = _dr["USEFLAG"].ObjectNullString();
                            _strRemarks = _dr["REMARKS"].ObjectNullString();

                            if (!this.SaveData(_stritemCode, _stritemName, _strPartNo, _strCustPartNo, _strSpec,
                                               _strTool, _strSize, _strType,
                                               _strRootItemcode, _strRev, _strItemtype, _strUnitCode, _strLotUnitqty,
                                               _strBoxqty, _strSaftyQty, _strValiddate, _strTerminalFlag, _strCurrflowinflag,
                                               _strUnitNo, _strPrintUnit, _strQtyoutFlag, _strQtypackFlag, _strPrinttype,
                                               _strTactTime, _strVisualTactTime, _strExpiryDate, _strLongTermDate, _strLabelText, _strUseyn, 
                                               _strRemarks))
                            {
                                MainButton_INIT.PerformClick();
                                gvList.EX_GetFocuseRowCell("PARTNO", _strPartNo);
                                return;
                            }

                            break;

                        default:
                            break;
                    }
                }

                MainButton_INIT.PerformClick();
                gvList.EX_GetFocuseRowCell("PARTNO", _strPartNo);


            }
            else if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
            {
                _stritemCode = txtitemCode.EditValue.ObjectNullString();
                _stritemName = txtitemname.EditValue.ObjectNullString();
                _strPartNo = txtPartno.EditValue.ObjectNullString();
                _strCustPartNo = txtCustPartNo.EditValue.ObjectNullString();
                _strSpec = txtSpec.EditValue.ObjectNullString();
                _strTool = txtTool.EditValue.ObjectNullString();
                _strSize = txtSize.EditValue.ObjectNullString();
                _strType = txtType.EditValue.ObjectNullString();
                _strRootItemcode = gleRootItem.EditValue.ObjectNullString();
                _strRev = txtREV.EditValue.ObjectNullString();
                _strItemtype = gleitemtype.EditValue.ObjectNullString();
                _strUnitCode = gleUnitCode.EditValue.ObjectNullString();
                _strLotUnitqty = speLotUnitQty.EditValue.ObjectNullString();
                _strBoxqty = speBoxQty.EditValue.ObjectNullString();
                _strSaftyQty = speSaftyQty.EditValue.ObjectNullString();

                if (dteValidDate.EditValue != null)
                    _strValiddate = dteValidDate.DateTime.ToString("yyyyMMdd");

                _strCurrflowinflag = rdgCurrflowFlag.EditValue.ObjectNullString();
                _strTerminalFlag = gleTerminalFlag.EditValue.ObjectNullString();
                _strUnitNo = gleUnitNo.EditValue.ObjectNullString();
                _strPrintUnit = spePrintUnit.EditValue.ObjectNullString();
                _strQtyoutFlag = rdgQtyRelease.EditValue.ObjectNullString();
                _strQtypackFlag = rdgQtyPack.EditValue.ObjectNullString();
                _strPrinttype = glePrinttype.EditValue.ObjectNullString();
                _strTactTime = spiTactTime.EditValue.ObjectNullString();
                _strVisualTactTime = spiVisualTactTime.EditValue.ObjectNullString();
                _strExpiryDate = spiExpiryDate.EditValue.ObjectNullString();
                _strLongTermDate = spiLongTermDate.EditValue.ObjectNullString();
                _strLabelText = gleLabelText.EditValue.ObjectNullString();
                _strUseyn = rdgUseflag.EditValue.ObjectNullString();
                _strRemarks = memRemarks.EditValue.ObjectNullString();

                if (!this.SaveData(_stritemCode, _stritemName, _strPartNo, _strCustPartNo, _strSpec,
                                   _strTool, _strSize, _strType,
                                   _strRootItemcode, _strRev, _strItemtype, _strUnitCode, _strLotUnitqty,
                                   _strBoxqty, _strSaftyQty, _strValiddate, _strTerminalFlag, _strCurrflowinflag,
                                   _strUnitNo, _strPrintUnit, _strQtyoutFlag, _strQtypackFlag, _strPrinttype,
                                   _strTactTime, _strVisualTactTime, _strExpiryDate, _strLongTermDate, _strLabelText, _strUseyn, 
                                   _strRemarks))
                {
                    MainButton_INIT.PerformClick();
                    return;
                }

                MainButton_INIT.PerformClick();
                MainButton_New.PerformClick();

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
        }

        public void SearchButton_Click()
        {
        }

        #endregion

        #region 함수

        private bool SaveData(string p_stritemCode, string p_stritemName, string p_strPartNo, string p_strCustpartNo, string p_strSpec,
                              string p_strTool, string p_strSize, string p_strType,
                              string p_strRootItem, string p_strRev, string p_strItemtype, string p_strUnitCode, string p_strLotUnitqty,
                              string p_strBoxqty, string p_strSaftyQty, string p_strValiddate, string p_strTerminalFlag, string p_strCurrflowinspFlag,
                              string p_strUnitNo, string p_strPrintUnit, string p_strQtyoutFlag, string p_strQtypackFlag, string p_strPrinttype,
                              string p_strTactTime, string p_strVisualTactTime,  string p_strExpiryDate, string p_strLongTermDate, string p_strLabelText, string p_strUseyn, 
                              string p_strRemarks)
        {

            bool _Rtn = BASE_db.Execute_Proc( "PKGBAS_BASE.PUT_ITEM"
                                            , 1
                                            , new string[] {
                                              "A_CLIENT"
                                            , "A_COMPANY"
                                            , "A_PLANT"
                                            , "A_ITEMCODE"  
                                            , "A_ITEMNAME"
                                            , "A_PARTNO"
                                            , "A_CUSTPARTNO"
                                            , "A_SPEC"
                                            , "A_TOOL"
                                            , "A_SIZE"
                                            , "A_TYPE"
                                            , "A_ROOTITEM"
                                            , "A_REV"  
                                            , "A_ITEMTYPE" 
                                            , "A_UNITCODE"
                                            , "A_LOTUNITQTY"
                                            , "A_BOXQTY"
                                            , "A_SAFTYQTY"
                                            , "A_VALIDFROMDATE"   
                                            , "A_TERMINALFLAG"
                                            , "A_CURRFLOWINSFLAG"
                                            , "A_UNITNO"
                                            , "A_PRINTUNIT"
                                            , "A_QTYOUTFLAG"
                                            , "A_QTYPACKFLAG"
                                            , "A_PRINTTYPE"
                                            , "A_TACTTIME"
                                            , "A_VISUALTACTTIME"
                                            , "A_EXPIRYDATE"
                                            , "A_LONGTERMDATE"
                                            , "A_LABELTEXT"
                                            , "A_USEFLAG"      
                                            , "A_REMARKS"
                                            , "A_USER" }
                                            , new string[] {
                                              Global.Global_Variable.CLIENT
                                            , Global.Global_Variable.COMPANY
                                            , Global.Global_Variable.PLANT
                                            , p_stritemCode
                                            , p_stritemName
                                            , p_strPartNo
                                            , p_strCustpartNo
                                            , p_strSpec
                                            , p_strTool
                                            , p_strSize
                                            , p_strType
                                            , p_strRootItem
                                            , p_strRev
                                            , p_strItemtype
                                            , p_strUnitCode
                                            , p_strLotUnitqty
                                            , p_strBoxqty
                                            , p_strSaftyQty
                                            , p_strValiddate
                                            , p_strTerminalFlag
                                            , p_strCurrflowinspFlag
                                            , p_strUnitNo
                                            , p_strPrintUnit
                                            , p_strQtyoutFlag
                                            , p_strQtypackFlag
                                            , p_strPrinttype
                                            , p_strTactTime
                                            , p_strVisualTactTime
                                            , p_strExpiryDate
                                            , p_strLongTermDate
                                            , p_strLabelText
                                            , p_strUseyn
                                            , p_strRemarks
                                            , Global.Global_Variable.EHRCODE }
                                            , true
                                            );
             
            return _Rtn;
        }

        private void Set_Init()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleitemtype
                                                       , "GPKGBAS_BASE.GET_ITEMTYPE"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT" }
                                                       , new string[] { 
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT }
                                                       , "ITEMTYPE"
                                                       , "ITEMNAME"
                                                       , "ITEMTYPE, ITEMNAME"
                                                       );

            gleitemtype.Properties.View.OptionsView.ShowGroupPanel = false;


            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleUnitCode
                                                       , "GPKGBAS_BASE.GET_UNITCODE"
                                                       , 1
                                                       , new string[] { 
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT" }
                                                       , new string[] { 
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT }
                                                       , "UNITCODE"
                                                       , "UNITNAME"
                                                       , "UNITCODE, UNITNAME, REMARKS"
                                                       );

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleRootItem
                                                       , "GPKGBAS_BASE.GET_ROOTITEM"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT }
                                                       , "ITEMCODE"
                                                       , "PARTNO"
                                                       , "ITEMCODE,PARTNO,ITEMNAME,SPEC"
                                                       );

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleTerminalFlag
                                                       , "GPKGBAS_BASE.GET_TERMINALFLAG"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT" }
                                                       , new string[] { 
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT }
                                                       , "MATCODE"
                                                       , "MATCODENAME"
                                                       , "MATCODE, MATCODENAME"
                                                       );

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleUnitNo
                                                       , "GPKGBAS_BASE.GET_PRODLINE_UNIT"
                                                       , 1
                                                       , new string[] { 
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT }
                                                       , "UNITNO"
                                                       , "UNITNM"
                                                       , "UNITNO,UNITNM"
                                                       );

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( glePrinttype
                                                       , "GPKGBAS_BASE.GET_PRINTTYPE"
                                                       , 1
                                                       , new string[] { 
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT }
                                                       , "PRINTTYPE"
                                                       , "PRINTTYPENAME"
                                                       , "PRINTTYPE,PRINTTYPENAME"
                                                       );

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleLabelText
                                                       , "GPKGBAS_BASE.GET_LABELTEXT"
                                                       , 1
                                                       , new string[] { 
                                                                     "A_CLIENT"
                                                                   , "A_COMPANY"
                                                                   , "A_PLANT" }
                                                       , new string[] {
                                                                     Global.Global_Variable.CLIENT
                                                                   , Global.Global_Variable.COMPANY
                                                                   , Global.Global_Variable.PLANT }
                                                       , "CVALUE"
                                                       , "COMMNAME"
                                                       , "CVALUE,COMMNAME"
                                                       );
        }

        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid( gcList
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
                                       , true
                                       , "" //사용하지 않는 컬럼 보이지 않도록 수정(2014.11.05 홍성원)
                                       , false
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
                if (dr["ITEMCODE"] != null)
                {
                    // 주키가 두개일 경우 AND 문으로 조건을 다중으로 준다.
                    if (dr["ITEMCODE"].ToString() == gvList.GetDataRow(e.RowHandle)["ITEMCODE"].ToString())
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void gleitemtype_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            gleitemtype.Properties.View.ActiveFilter.Clear();
        }

        #endregion

        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDlg = new OpenFileDialog();
            fileDlg.RestoreDirectory = true;
            fileDlg.Filter = "Image File (*.jpg;*.bmp;*.gif,*.png)|*.jpg;*.bmp;*.gif;*.png";


            fileDlg.RestoreDirectory = true;

            if (fileDlg.ShowDialog() == DialogResult.OK)
            {
                string _strImageName = fileDlg.FileName;

                FileStream fs = new System.IO.FileStream(_strImageName, FileMode.Open, FileAccess.Read);

                byte[] b = new byte[fs.Length - 1];
                fs.Read(b, 0, b.Length);
                fs.Close();

                Dictionary<string, object> dicParams = new Dictionary<string, object>();
                dicParams.Add("A_CLIENT", Global.Global_Variable.CLIENT);
                dicParams.Add("A_COMPANY", Global.Global_Variable.COMPANY);
                dicParams.Add("A_PLANT", Global.Global_Variable.PLANT);
                dicParams.Add("A_ITEMCODE", txtitemCode.EditValue.ObjectNullString());
                dicParams.Add("A_IMAGE", b);
                dicParams.Add("A_USERID", Global.Global_Variable.USER_ID);

                HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = BASE_db.Execute_Proc("PKGBAS_BASE.SET_SAMPLEIMAGE"
                                                                                              , 1
                                                                                              , dicParams);

                if (_Result.ResultInt == 0)
                {
                    iDATMessageBox.OKMessage("DBMSG_SUCCESS", this.Text, 3);
                    this.GetGridViewList();
                }
            }
        }

        private void btnImage2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDlg = new OpenFileDialog();
            fileDlg.RestoreDirectory = true;
            fileDlg.Filter = "Image File (*.jpg;*.bmp;*.gif,*.png)|*.jpg;*.bmp;*.gif;*.png";


            fileDlg.RestoreDirectory = true;

            if (fileDlg.ShowDialog() == DialogResult.OK)
            {
                string _strImageName = fileDlg.FileName;

                FileStream fs = new System.IO.FileStream(_strImageName, FileMode.Open, FileAccess.Read);

                byte[] b = new byte[fs.Length - 1];
                fs.Read(b, 0, b.Length);
                fs.Close();

                Dictionary<string, object> dicParams = new Dictionary<string, object>();
                dicParams.Add("A_CLIENT", Global.Global_Variable.CLIENT);
                dicParams.Add("A_COMPANY", Global.Global_Variable.COMPANY);
                dicParams.Add("A_PLANT", Global.Global_Variable.PLANT);
                dicParams.Add("A_ITEMCODE", txtitemCode.EditValue.ObjectNullString());
                dicParams.Add("A_IMAGE", b);
                dicParams.Add("A_USERID", Global.Global_Variable.USER_ID);

                HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = BASE_db.Execute_Proc("PKGBAS_BASE.SET_SAMPLEIMAGE2"
                                                                                              , 1
                                                                                              , dicParams);

                if (_Result.ResultInt == 0)
                {
                    iDATMessageBox.OKMessage("DBMSG_SUCCESS", this.Text, 3);
                    this.GetGridViewList();
                }
            }
        }

        private void btnUploadExcelFormXlsx_Click(object sender, EventArgs e)
        {
            Process pc = new Process();
            pc.StartInfo.FileName = Application.StartupPath + @"\Excel\ITEMUPLOAD.xlsx";
            pc.StartInfo.Verb = "Open";
            pc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            pc.Start();
        }

        private void btnUploadExcelFormXls_Click(object sender, EventArgs e)
        {
            Process pc = new Process();
            pc.StartInfo.FileName = Application.StartupPath + @"\Excel\ITEMUPLOAD.xls";
            pc.StartInfo.Verb = "Open";
            pc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            pc.Start();
        }

        private void btnItemUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.RestoreDirectory = true;
            ofd.Filter = "Excel Files(*.xls, *.xlsx, *.xlt)|*.xls;*.xlsx;*.xlt";
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string _strFilePath = ofd.FileName;

                DataTable dTable = ReadExcelFile(_strFilePath, "ITEM");

                if (dTable == null)
                    return;

                dTable.Rows.RemoveAt(0);
                string _strModel = dTable.Rows[0]["F1"].ObjectNullString();

                LanguageInformation _clsLan = new LanguageInformation();
                string _strMsg = _clsLan.GetMessageString("MSG_QS_MST_002"); //선택한 파일의 아이템을 저장하시겠습니까?

                if (iDATMessageBox.QuestionMessage(_strMsg, this.Text) == System.Windows.Forms.DialogResult.Yes)
                {
                    SplashScreenManager.ShowForm(typeof(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM), true, false);
                    SplashScreenManager.Default.SendCommand(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM.WaitFormCommand.SetDescription, "Items Creating...");

                    string _strXml = base.GetDataTableToXml(dTable);

                    WSResults result = BASE_db.Execute_Proc("PKGBAS_BASE.PUT_ITEM"
                                                           , 2
                                                           , new string[] {
                                                             "A_CLIENT"
                                                           , "A_COMPANY"
                                                           , "A_PLANT"
                                                           , "A_XML"
                                                           , "A_USERID" }
                                                           , new string[] {
                                                             Global.Global_Variable.CLIENT
                                                           , Global.Global_Variable.COMPANY
                                                           , Global.Global_Variable.PLANT
                                                           , _strXml
                                                           , Global.Global_Variable.EHRCODE }
                                                           );

                    SplashScreenManager.CloseForm(true);

                    if (result.ResultInt == 0)
                    {
                        GetGridViewList();
                    }

                    
                }
            }
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
    }
}
