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

namespace HAENGSUNG_HNSMES_UI.Forms.MAT.PopUp
{
    public partial class POP_MAT02 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfScanner
    {
        string m_strWO = "";
        DataTable m_dtPartNo;

        public DataTable PartNoInfo
        {
            get { return m_dtPartNo; }
        }
        public POP_MAT02()
        {
            InitializeComponent();
        }

        public POP_MAT02(string p_strWO)
        {
            InitializeComponent();
            m_strWO = p_strWO;
        }

        private void MATB002_PopUp_Load(object sender, EventArgs e)
        {
            this.Set_Init();
        }

        #region Button Event

        private void btnInit_Click(object sender, EventArgs e)
        {
            this.Set_Init();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (gleWHLoc.EditValue == null)
            {
                LanguageInformation clsLan = new LanguageInformation();
                string _strMsg = clsLan.GetMessageString("MSG_ER_COMM_005"); // 위치를 선택하세요.
                iDATMessageBox.WARNINGMessage(_strMsg + "\r\n", this.Text, 3);
                return;
            }

            this.GetGridViewList();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (gvList.FocusedRowHandle < 0)
            {
                LanguageInformation clsLan = new LanguageInformation();
                string _strMsg = clsLan.GetMessageString("MSG_ER_COMM_002"); // 품번을 선택하세요.
                iDATMessageBox.WARNINGMessage(_strMsg + "\r\n", this.Text, 3);
                return;
            }

            string _strLoc = gleWHLoc.EditValue.ObjectNullString();
            string _strItemCode = gvList.GetFocusedRowCellValue("ITEMCODE").ObjectNullString();
            string _strQty = gvList.GetFocusedRowCellValue("QTY").ObjectNullString();
            string _strType = gvList.GetFocusedRowCellValue("TYPE").ObjectNullString();
            
            if(_strType == "G")
                _strType = "GOOD";
            else
                _strType = "BAD";

            WSResults _result = BASE_db.Execute_Proc(
                                                       "PKGPDA_MAT.GET_RELEASE_PARTINFO"
                                                     , 1
                                                     , new string[] { 
                                                                       "A_PLANT"
                                                                     , "A_JOB"
                                                                     , "A_LOC"
                                                                     , "A_ITEMCODE"
                                                                     , "A_TYPE"
                                                                     , "A_QTY"
                                                                     , "A_PARAM1"
                                                                     , "A_PARAM2"
                                                                    }
                                                     , new string[] { 
                                                                       Global.Global_Variable.PLANT
                                                                     , "SMTRELEASE"
                                                                     , _strLoc
                                                                     , _strItemCode
                                                                     , _strType
                                                                     , _strQty
                                                                     , m_strWO
                                                                     , ""
                                                                    }
                                                    );

            if (_result.ResultInt != 0)
            {
                LanguageInformation clsLan = new LanguageInformation();
                string _strMsg = clsLan.GetMessageString(_result.ResultString); // 위치를 선택하세요.
                iDATMessageBox.WARNINGMessage(_strMsg + "\r\n", this.Text, 3);
            }
            else
            {
                m_dtPartNo = _result.ResultDataSet.Tables[0];
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Close();
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
            switch (p_strType)
            {
                case "PARTNO":
                    txtPartNo.Text = p_strData;
                    this.btnSearch_Click(null, null);
                    break;

                default:
                    LanguageInformation clsLan = new LanguageInformation();
                    string _strMsg = clsLan.GetMessageString("MSG_ER_COMM_027"); //현재 화면에서 사용할 수 없는 바코드 입니다.
                    iDATMessageBox.WARNINGMessage(_strMsg + "\r\n" + "Type : " + p_strType + "\r\n" + "Barcode : " + p_strData, this.Text, 3);
                    break;
            }
        }

        #endregion

        #region Function

        private void Set_Init()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(
                                           gleWH
                                         , "PKGBAS_STOCK.GET_WAREHOUSE"
                                         , 1
                                         , new string[] {
                                                          "A_PLANT"
                                                         ,"A_VIEW"
                                                        }
                                         , new string[] {
                                                          Global.Global_Variable.PLANT
                                                         , "0"
                                                        }
                                         , "WAREHOUSE"
                                         , "WAREHOUSENAME"
                                         , "WAREHOUSE, WAREHOUSENAME, REMARKS"
                                         );

            gleWH.EditValue = null;
            gleWHLoc.Enabled = false;
            gleWHLoc.EditValue = null;
            txtPartNo.Text = "";
            gcList.DataSource = null;
        }

        private void Set_Location(string p_strWH)
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(
                                                       gleWHLoc
                                                     , "PKGBAS_STOCK.GET_LOCATION"
                                                     , 1
                                                     , new string[] {
                                                                      "A_WAREHOUSE"
                                                                     ,"A_VIEW"
                                                                    }
                                                     , new string[] {
                                                                      p_strWH
                                                                     , "0"
                                                                    }   
                                                     , "WHLOC"
                                                     , "WHLOCNAME"
                                                     , "WHLOC, WHLOCNAME, REMARKS"
                                                     );
        }

        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid(  gcList
                                        , "PKGPDA_MAT.GET_PARTSTOCK"
                                        , 1
                                        , new string[] {
                                                          "A_PLANT"
                                                        , "A_LOC"
                                                        , "A_PARTNO"
                                                       }
                                        , new string[] {
                                                          Global.Global_Variable.PLANT
                                                        , gleWHLoc.EditValue.ObjectNullString()
                                                        , txtPartNo.Text
                                                       }
                                        , true
                                        , "PARTNO, TYPE, QTY"
                                       );
        }
        #endregion

        private void gleWH_EditValueChanged(object sender, EventArgs e)
        {
            if (gleWH.EditValue == null)
            {
                gleWHLoc.EditValue = null;
                gleWHLoc.Enabled = false;
            }
            else
            {
                gleWHLoc.Enabled = true;
                Set_Location(gleWH.EditValue.ObjectNullString());
            }
        }

        private void gleWHLoc_EditValueChanged(object sender, EventArgs e)
        {
            if (gleWHLoc.EditValue == null)
            {
                gcList.DataSource = null;
            }
            else
            {
                this.GetGridViewList();
            }
        }

        private void gvList_DoubleClick(object sender, EventArgs e)
        {
            this.btnSelect_Click(null, null);
        }

        
    }
}
