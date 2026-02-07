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

namespace HAENGSUNG_HNSMES_UI.Forms.OSC
{
    public partial class OSCA202 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
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

        public OSCA202()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            Set_Init();
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);
        }



        #endregion

        #region [Button Event]

        public void InitButton_Click()
        {            
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
            string _strWH = gleSearchWH.EditValue.ObjectNullString();
            string _strWHLoc = gleSearchWHLoc.EditValue.ObjectNullString();
            string _strPartNo = txtSearchPartNo.EditValue.ObjectNullString();
            string _strSN = txtSearchSN.EditValue.ObjectNullString();

            GetGridViewList(_strWH, _strWHLoc, _strPartNo, _strSN);
        }


        public void SaveButton_Click()
        {
            //아이템을 선택하지 않은 경우
            if (gvList.FocusedRowHandle < 0)
            {
                LanguageInformation _clsLang = new LanguageInformation();
                string _strMsg = _clsLang.GetMessageString("MSG_ER_MAT_009");//이동할 S/N를 선택하세요.
                iDATMessageBox.WARNINGMessage(_strMsg, this.Text, 3);
                return;
            }

            //목적 위치를 선택하지 않은 경우
            if (gleAlterWHLoc.EditValue == null)
            {
                LanguageInformation _clsLang = new LanguageInformation();
                string _strMsg = _clsLang.GetMessageString("MSG_ER_MAT_010");//이동할 위치를 선택하세요.
                iDATMessageBox.WARNINGMessage(_strMsg, this.Text, 3);
                return;
            }

            if (gleWHLoc.EditValue.ObjectNullString() == gleAlterWHLoc.EditValue.ObjectNullString())
            {
                LanguageInformation _clsLang = new LanguageInformation();
                string _strMsg = _clsLang.GetMessageString("MSG_ER_MAT_011");//현재 위치와 이동할 위치가 같습니다.
                iDATMessageBox.WARNINGMessage(_strMsg, this.Text, 3);
                return;
            }
            //gvIqcList.GetRowCellValue(gvIqcList.FocusedRowHandle, "VENDOR").ObjectNullString();
            string _strXML = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "\n";
            _strXML += "<NewDataSet>" + "\n";
            _strXML += "  <Table>" + "\n";
            _strXML += "    <PARTNO>" + txtPartNo.Text + "</PARTNO>" + "\n";
            _strXML += "    <QTY>" + spinAlterStockQty.EditValue.ObjectNullString() + "</QTY>" + "\n";
            _strXML += "    <SN>" + txtSN.Text +"</SN>" + "\n";
            _strXML += "    <TYPE>" + rdgType.EditValue.ObjectNullString() +"</TYPE>" + "\n";
            _strXML += "    <LOC>" + gleWHLoc.EditValue.ObjectNullString() +"</LOC>" + "\n";
            _strXML += "    <ITEMCODE>" + txtItemCode.EditValue.ObjectNullString() + "</ITEMCODE>" + "\n";
            _strXML += "    <VENDOR>" + gvList.GetRowCellValue(gvList.FocusedRowHandle, "VENDOR").ObjectNullString() +"</VENDOR>" + "\n";
            _strXML += "  </Table>" + "\n";
            _strXML += "</NewDataSet>" + "\n"; ;

            bool bRtn = BASE_db.Execute_Proc("PKGPDA_PROD.SET_OSC_RELEASE"
                                            , 1
                                            , new string[] {
                                              "A_CLIENT"
                                            , "A_COMPANY"
                                            , "A_PLANT"
                                            , "A_LOC"
                                            , "A_XML"
                                            , "A_REMARKS"
                                            , "A_EHRCODE" }
                                            , new string[] {
                                              Global.Global_Variable.CLIENT
                                            , Global.Global_Variable.COMPANY
                                            , Global.Global_Variable.PLANT
                                            , gleAlterWHLoc.EditValue.ObjectNullString()
                                            , _strXML
                                            , memRemarks.Text
                                            , Global.Global_Variable.EHRCODE }
                                            , true
                                            );

            if (bRtn)
            {
                iDATMessageBox.OKMessage("MSG_OK_REG_001", this.Text, 3);
                MainButton_Search.PerformClick();
            }
        }


        public void PrintButton_Click()
        {
            // 출력 버튼 클릭 이벤트
        }


        public void RefreshButton_Click()
        {
        }

        public void DeleteButton_Click()
        {
            // 삭제 버튼 클릭 이벤트
        }

        #endregion

        #region Scanner

        public void Data_Scan(string p_strType, string p_strData)
        {
            ProcessScanEvent(p_strType, p_strData);
        }

        public void Data_SubScan(string p_strType, string p_strData)
        {
            ProcessScanEvent(p_strType, p_strData);
        }

        private void ProcessScanEvent(string p_strType, string p_strData)
        {
            string sTemp = p_strType;

            if (sTemp.IndexOf("|") > -1)
            {
                if (sTemp.Split('|').Length > 0)
                {
                    p_strType = sTemp.Split('|')[0];
                }
            }

            switch (p_strType)
            {
                case "MATSN":
                    txtSearchSN.Text = p_strData;
                    this.GetGridViewList(gleSearchWH.EditValue.ObjectNullString(),
                                         gleSearchWHLoc.EditValue.ObjectNullString(),
                                         txtSearchPartNo.Text,
                                         txtSearchSN.Text);
                    break;

                case "PARTNO":
                    txtSearchPartNo.Text = p_strData;
                    break;

                default:
                    LanguageInformation clsLan = new LanguageInformation();
                    string _strMsg = clsLan.GetMessageString("MSG_ER_COMM_027"); //현재 화면에서 사용할 수 없는 바코드 입니다.
                    iDATMessageBox.WARNINGMessage(_strMsg + "\r\n" + "Type : " + p_strType + "\r\n" + "Barcode : " + p_strData, this.Text, 3);
                    break;
            }
        }

        #endregion

        #region [Private Method]

        private void Set_Init()
        {
            string _strWarehouse;
            if (this.Tag.ObjectNullString() == "PRODTRANSLOC")
            {
                _strWarehouse = "3";
                lciSN.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                _strWarehouse = "4";
                lciSN.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleSearchWH
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

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWHLoc
                                                       , "PKGPDA_COMM.GET_LOC"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_WH" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , "TRANSLOC" }
                                                       , "WHLOC"
                                                       , "LOCNAME"
                                                       , "WHLOC, LOCNAME, REMARKS"
                                                       );  

            //BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWH
            //                                           , "PKGBAS_BASE.GET_WAREHOUSE"
            //                                           , 1
            //                                           , new string[] {
            //                                             "A_CLIENT"
            //                                           , "A_COMPANY"
            //                                           , "A_PLANT"
            //                                           , "A_VIEW" }
            //                                           , new string[] {
            //                                             Global.Global_Variable.CLIENT
            //                                           , Global.Global_Variable.COMPANY
            //                                           , Global.Global_Variable.PLANT
            //                                           , _strWarehouse }
            //                                           , "WAREHOUSE"
            //                                           , "WAREHOUSENAME"
            //                                           , "WAREHOUSE, WAREHOUSENAME, REMARKS"
            //                                           );

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleAlterWH
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
                                                       , "7" }
                                                       , "WAREHOUSE"
                                                       , "WAREHOUSENAME"
                                                       , "WAREHOUSE, WAREHOUSENAME, REMARKS"
                                                       );

            gleSearchWH.EditValue = null;
            gleWH.EditValue = null;
            gleAlterWH.EditValue = null;

            gleSearchWHLoc.EditValue = null;
            gleWHLoc.EditValue = null;
            gleAlterWHLoc.EditValue = null;

            dteOut.DateTime = DateTime.Now;
        }

        private void Set_SearchLocation(string p_strWH)
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleSearchWHLoc
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
                                                       , p_strWH
                                                       , "0" }
                                                       , "WHLOC"
                                                       , "WHLOCNAME"
                                                       , "WHLOC, WHLOCNAME, REMARKS"
                                                       );    

        }

        private void Set_AlterLocation(string p_strAlterWH)
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleAlterWHLoc
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
                                                       , p_strAlterWH
                                                       , "0" }
                                                       , "WHLOC"
                                                       , "WHLOCNAME"
                                                       , "WHLOC, WHLOCNAME, REMARKS"
                                                       );  

            
        }

        private void GetGridViewList(string p_strWH, string p_strWHLoc, string p_strPartNo, string p_strSN)
        {
            
            BASE_DXGridHelper.Bind_Grid_Int( gcList
                                           , "PKGBAS_MAT.GET_WAREHOUSE_STOCK"
                                           , 1
                                           , new string[] {
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_WAREHOUSE"
                                           , "A_WHLOC"
                                           , "A_PARTNO"
                                           , "A_SERIAL" }
                                           , new string[] {
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , p_strWH
                                           , p_strWHLoc
                                           , p_strPartNo
                                           , p_strSN }
                                           , true
                                           , "PARTNO, ITEMNAME, SPEC, TYPE, QTY, SN, ITEMCODE, WAREHOUSENAME, WHLOCNAME, VENDOR"
                                           , true
                                           , "ITEMCODE,QTY,VENDOR"
                                           );

            gvList.OptionsView.ColumnAutoWidth = true;
            gvList.BestFitColumns();
        }

        #endregion

        private void gleSearchWH_EditValueChanged(object sender, EventArgs e)
        {
            gcList.DataSource = null;

            Set_SearchLocation(gleSearchWH.EditValue.ObjectNullString());
        }

        private void gleSearchWHLoc_EditValueChanged(object sender, EventArgs e)
        {
            gcList.DataSource = null;
        }
        
        private void gleAlterWH_EditValueChanged(object sender, EventArgs e)
        {
            Set_AlterLocation(gleAlterWH.EditValue.ObjectNullString());
        }

        private void gleWHLoc_EditValueChanged(object sender, EventArgs e)
        {
            spinAlterStockQty.EditValue = spinStockQty.EditValue;
        }

        private void txtSN_EditValueChanged(object sender, EventArgs e)
        {
            spinAlterStockQty.EditValue = spinStockQty.EditValue;

            if (txtSN.EditValue.ObjectNullString() == "NONE")
                spinAlterStockQty.Properties.ReadOnly = false;
            else
                spinAlterStockQty.Properties.ReadOnly = true;


            //if (txtSN.Text == "")
            //    spinAlterStockQty.Enabled = true;
            //else
            //    spinAlterStockQty.Enabled = false;
        }

        private void txtPartNo_EditValueChanged(object sender, EventArgs e)
        {
            spinAlterStockQty.EditValue = spinStockQty.EditValue;
        }

        private void rdgType_SelectedIndexChanged(object sender, EventArgs e)
        {
            spinAlterStockQty.EditValue = spinStockQty.EditValue;
        }
    }
}
