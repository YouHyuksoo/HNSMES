
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



namespace HAENGSUNG_HNSMES_UI.Forms.MST
{
    
    public partial class MSTA219 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {
        
        #region 생성

        public MSTA219()
        {
            InitializeComponent();
        }

        private void MSTA219_Load(object sender, EventArgs e)
        {
        }

        private void MSTA219_Shown(object sender, EventArgs e)
        {
            MainButton_INIT.PerformClick();
        }
        #endregion 

        #region 버튼이벤트

        public void InitButton_Click()
        {
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);
            this.Set_Init();
            this.GetGridViewList();
        }
        
        
        public void NewButton_Click()
        {
            // 신규 관련 구현은 여기에 구현.

            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New);

            // 그리드뷰에 새로운 행과 초기값을 지정한다.
            gvList.EX_AddNewRow();
            rdgUseFlag.SelectedIndex = 0;

            txtModel.Focus();
        }

        public void EditButton_Click()
        {
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit);
        }

        public void StopButton_Click()
        {
        }

        public void SearchButton_Click()
        {
            this.GetGridViewList();
        }

        public void SaveButton_Click()
        {
            // 저장전에 필수 항목에 대한 Null 값을 초기화 합니다.
            // 유효성검사 다시 수행
            base.baseDxErrorProvider.ClearErrors();
            ValidateChildren(ValidationConstraints.Visible);

            // 유효성 검사를 한다.
            if (base.baseDxErrorProvider.HasErrors)
            {
                return;
            }

            // ****** 마지막 수정항목을 데이터셋에 적용 시킬려면 포커스를 이동을 한다.
            //gvList.FocusedRowHandle = -1;

            

            string _strModel = "";
            string _strPartNo = "";
            string _strVendor = "";
            string _strWhLoc = "";
            string _strSeq = "";
            string _strQty = "";
            string _strRate = "";
            string _strUseFlag = "";
            string _strRemarks = "";
            
            if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit)
            {
                // ****** 마지막 수정항목을 데이터셋에 적용 시킬려면 포커스를 이동을 한다.
                gvList.FocusedRowHandle = -1;

                // 수정,추가,변경 된 데이터를 모두 가져온다.
                DataTable _dt = gvList.EX_GetChangedData();

                if (_dt == null)
                    return;

                // 변경된 데이터가 없으면 return.
                if (_dt.Rows.Count == 0) return;

                // 변경된 데이터를 루프를 통해 하나씩 빼낸다.
                foreach (DataRow _dr in _dt.Rows)
                {
                    switch (_dr.RowState)
                    {
                        case DataRowState.Modified:
                            _strModel = _dr["MODEL"] + "";
                            _strPartNo = _dr["PARTNO"] + "";
                            _strVendor = _dr["VENDOR"] + "";
                            _strWhLoc = _dr["WHLOC"] + "";
                            _strSeq = _dr["SEQ"] + "";
                            _strQty = _dr["ASSYUSAGE"] + "";
                            _strRate = _dr["ASSYRATE"] + "";
                            _strUseFlag = _dr["USEFLAG"] + "";
                            _strRemarks = _dr["REMARKS"] + "";

                            if (!this.SaveData(_strModel, _strPartNo, _strVendor, _strWhLoc, _strSeq, _strQty, _strRate, _strUseFlag,
                                _strRemarks))
                            {
                                MainButton_INIT.PerformClick();
                                //마지막 처리 된 값쪽에 포커스를 이동 시킵니다. 사용시에 주석을 해제하고 수정하세요.
                                BASE_clsDevexpressGridUtil.GetFocuseRowCell(gvList, "MODEL", _strModel);
                                return;
                            }
                            break;


                        default:
                            break;
                    }
                }

                MainButton_INIT.PerformClick();
                //마지막 처리 된 값쪽에 포커스를 이동 시킵니다. 사용시에 주석을 해제하고 수정하세요.
                BASE_clsDevexpressGridUtil.GetFocuseRowCell(gvList, "EQP", _strModel);

            }
            else if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
            {
                // ***** 신규 관련 프로시져를 여기에 구현을 합니다.
                _strModel = txtModel.EditValue.ObjectNullString().Trim();
                _strPartNo = txtPartNo.EditValue.ObjectNullString();
                _strVendor = gleVendor.EditValue.ObjectNullString();
                _strWhLoc = gleWhLoc.EditValue.ObjectNullString();
                _strSeq = txtSeq.EditValue.ObjectNullString();
                _strQty = txtQty.EditValue.ObjectNullString();
                _strRate = txtRate.EditValue.ObjectNullString();
                _strUseFlag = rdgUseFlag.EditValue.ObjectNullString();
                _strRemarks = memRemarks.EditValue.ObjectNullString();

                if (!this.SaveData(_strModel, _strPartNo, _strVendor, _strWhLoc, _strSeq, _strQty, _strRate, _strUseFlag,
                    _strRemarks))
                {
                    MainButton_INIT.PerformClick();
                    return;
                }

                MainButton_INIT.PerformClick();
                MainButton_New.PerformClick();
            }

        }

        public void RefreshButton_Click()
        {
        }

        public void DeleteButton_Click()
        {
        }

        public void PrintButton_Click()
        {
        }

        #endregion

        #region 함수

        private void Set_Init()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleVendor1
                                                       , "PKGBAS_BASE.GET_VENDOR"
                                                       , 1
                                                       , new string[]
                                                       { 
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_PURCHASE"
                                                       , "A_SALES"
                                                       , "A_OUTSC"
                                                       , "A_VIEW"
                                                       }
                                                       , new string[] 
                                                       { 
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , "Y"
                                                       , "Y"
                                                       , "Y"
                                                       , "0"
                                                       }
                                                       , "VENDOR"
                                                       , "VENDORNAME"
                                                       , "VENDOR, VENDORNAME"
                                                       );

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleVendor
                                                       , "PKGBAS_BASE.GET_VENDOR"
                                                       , 1
                                                       , new string[]
                                                       { 
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_PURCHASE"
                                                       , "A_SALES"
                                                       , "A_OUTSC"
                                                       , "A_VIEW"
                                                       }
                                                       , new string[] 
                                                       { 
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , "Y"
                                                       , "Y"
                                                       , "Y"
                                                       , "0"
                                                       }
                                                       , "VENDOR"
                                                       , "VENDORNAME"
                                                       , "VENDOR, VENDORNAME"
                                                       );

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleWhLoc
                                                       , "PKGBAS_BASE.GET_LOCATION2"
                                                       , 1
                                                       , new string[]
                                                       { 
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_VIEW"
                                                       }
                                                       , new string[] 
                                                       { 
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , "0"
                                                       }
                                                       , "WHLOC"
                                                       , "WHLOCNAME"
                                                       , "WHLOC, WHLOCNAME"
                                                       );
        }

        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid(gcList
                                       , "GPKGBAS_BASE.GET_MODELBOM"
                                       , 1
                                       , new string[] 
                                        {
                                         "A_CLIENT"
                                       , "A_COMPANY"
                                       , "A_PLANT"
                                       , "A_VENDOR"
                                       , "A_MODEL" }
                                       , new string[] 
                                       {
                                         Global.Global_Variable.CLIENT
                                       , Global.Global_Variable.COMPANY
                                       , Global.Global_Variable.PLANT
                                       , gleVendor1.EditValue.ObjectNullString()
                                       , txtModel1.EditValue.ObjectNullString()
                                       }
                                       , true
                                       );

            gvList.Columns["SEQ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvList.Columns["SEQ"].DisplayFormat.FormatString = "{0:n0}";

            gvList.Columns["ASSYUSAGE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvList.Columns["ASSYUSAGE"].DisplayFormat.FormatString = "{0:n0}";

            gvList.Columns["ASSYRATE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvList.Columns["ASSYRATE"].DisplayFormat.FormatString = "{0:n0}";

            gvList.OptionsView.ShowFooter = false;
            gvList.BestFitColumns();

        }

        private bool SaveData(string p_strModel, string p_strPartNo, string p_strVendor, string p_strWhLoc, string p_strSeq, string p_strQty, string p_strRate, 
                              string p_strUseFlag, string p_strRemarks)
        {
            bool _blReturn = BASE_db.Execute_Proc( "GPKGBAS_BASE.PUT_MODELBOM"
                                                 , 1
                                                 , new string[] 
                                                 {
                                                       "A_CLIENT"
                                                     , "A_COMPANY"
                                                     , "A_PLANT"
                                                     , "A_VENDOR"
                                                     , "A_WHLOC"
                                                     , "A_MODEL"
                                                     , "A_PARTNO"
                                                     , "A_SEQ"
                                                     , "A_QTY"
                                                     , "A_RATE"
                                                     , "A_USEFLAG"
                                                     , "A_REMARKS"
                                                     , "A_USER" 
                                                 }
                                                 , new string[] 
                                                 {
                                                       Global.Global_Variable.CLIENT
                                                     , Global.Global_Variable.COMPANY
                                                     , Global.Global_Variable.PLANT
                                                     , p_strVendor
                                                     , p_strWhLoc
                                                     , p_strModel
                                                     , p_strPartNo
                                                     , p_strSeq
                                                     , p_strQty
                                                     , p_strRate
                                                     , p_strUseFlag
                                                     , p_strRemarks
                                                     , Global.Global_Variable.EHRCODE 
                                                 }
                                                 , true
                                                 );

            return _blReturn;

        }

        #endregion

        #region 일반 이벤트

       
        private void gvList_Click(object sender, EventArgs e)
        {
            
        }

        private void gvList_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
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

        private void gvList_RowStyle(object sender, RowStyleEventArgs e)
        {
            
        }

        #endregion       

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.RestoreDirectory = true;
            ofd.Filter = "Excel Files(*.xls, *.xlsx, *.xlt)|*.xls;*.xlsx;*.xlt";
            
            /*
            if (gleVendor1.EditValue == null)
            {
                LanguageInformation _clsLang = new LanguageInformation();
                string _strMsg = _clsLang.GetMessageString("MSG_ER_COMM_007");//거래처를 입력하세요
                iDATMessageBox.WARNINGMessage(_strMsg, this.Text, 3);
                return;
            }
             */
            

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string _strFilePath = ofd.FileName;


                DataTable dTable = Global.GlobalFunction.ReadExcelFile(_strFilePath, "MODEL BOM"); //EXCEL SHEET명

                if (dTable == null)
                    return;

                dTable.Rows.RemoveAt(0);

                LanguageInformation _clsLan = new LanguageInformation();
                string _strMsg = _clsLan.GetMessageString("MSG_QS_BOM_001"); //업로드하시겠습니까?

                if (iDATMessageBox.QuestionMessage(_strMsg, this.Text) == System.Windows.Forms.DialogResult.Yes)
                {
                    string _strXml = this.GetDataTableToXml(dTable);
                    WSResults result = BASE_db.Execute_Proc(
                                                                "PKGBAS_BASE.PUT_MODELBOM_UPLOAD"
                                                            , 1
                                                            , new string[] 
                                                                        {
                                                                          "A_CLIENT"
                                                                        , "A_COMPANY"
                                                                        , "A_PLANT"
                                                                        , "A_XML"
                                                                        , "A_USER"  
                                                                        }
                                                            , new string[] 
                                                                        {
                                                                          Global.Global_Variable.CLIENT
                                                                        , Global.Global_Variable.COMPANY
                                                                        , Global.Global_Variable.PLANT
                                                                        , _strXml
                                                                        , Global.Global_Variable.USER_ID
                                                                        }
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

    }
}
