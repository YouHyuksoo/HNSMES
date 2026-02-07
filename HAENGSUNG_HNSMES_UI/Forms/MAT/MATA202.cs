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


namespace HAENGSUNG_HNSMES_UI.Forms.MAT
{
    // 라벨발행

    // 신규, 재발행, Split, Merge, Reel Taping

    public partial class MATA202 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
    {
        // ******************************************* Base From Class ************************************
        // BASE_clsDevexpressGridUtil          DevExpress Grid 관련 Util Class.
        // BASE_db;                            웹서비스 DB처리 관련 Util Class.
        // BASE_DXGridHelper;                  DevExpress GridControl 데이터 Bind관련 Class
        // BASE_DXGridLookUpHelper;            DevExpress GridLookUp 데이터 Bind관련 Class
        // BASE_IDATLayoutUtil;                DevExpress LayoutControl Util Class.
        // BASE_Language;                      Language Util. ex) BASE_Language.GetMessageString("Code") 
        // ************************************************************************************************

        IDAT.Devexpress.DXControl.IdatDxSimpleButton mNewSelBtn = null;
        string typegbn = "LOCAL";

        #region [Form Event]

        public MATA202()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            // 최초 폼 로드 시 발생 이벤트
            GetVendor();
            GetPartNo();
            GetLoc();
            //InitButton_Click();
            //GetWorkcenter();
            //GetPcbMaker();
        }

        void txtVendorSn_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            // ************************************************************************************
            // 컨트롤 초기화는 필수적으로 Shown이벤트에 작성을 하도록 합니다.
            // ************************************************************************************
            rdgIncome.SelectedIndex = 0;
            rdoTapingType.SelectedIndex = 0;
            tabGr.SelectedTabPageIndex = 0;
            MainButton_INIT.PerformClick();
        }

        #endregion

        #region Scan Event

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
            string sItemCode = "";
            double dQty = 0;

            if(sType.Split('|').Length == 3)
            {
                sItemCode = sType.Split('|')[1];
                dQty = double.Parse(sType.Split('|')[2]);
                sType = sType.Split('|')[0];
            }

            switch (sType)
            {
                case "MATSN":
                    Scan_MatSN(sType, sData);
                    break;

                case "PARTNO":
                    Scan_PartNo(sType, sData);
                    break;
                case "VENDORPARTNO":
                    Scan_PartNoQty(sType, sData, sItemCode, dQty);
                    break;

                default:
                    if(tabGr.SelectedTabPageIndex == 0)
                        txtIqcVendor.Text = sData;
                    else
                    {
                        LanguageInformation clsLan = new LanguageInformation();
                        string sMsg = clsLan.GetMessageString("MSG_ER_COMM_027");
                        iDATMessageBox.WARNINGMessage(sMsg + "\r\n" +
                                                      "Type : " + sType + "\r\n" +
                                                      "Barcode : " + sData, this.Text, 3);
                    }
                    
                    break;
            }

        }

        private void Scan_MatSN(string sType, string sData)
        {
            if (tabGr.SelectedTabPageIndex == 1)
            {
                txtReTarget.EditValue = sData;
                btnReSearch_Click(null, null);
            }
            else if (tabGr.SelectedTabPageIndex == 2)
            {
                txtSplitSN.EditValue = sData;
                btnSplitSearch_Click(null, null);
            }
            else if (tabGr.SelectedTabPageIndex == 3)
            {
                if (txtMergeTarget1.EditValue.ObjectNullString() == "")
                {
                    txtMergeTarget1.EditValue = sData;
                    btnMergeSearch1_Click(null, null);
                }
                else
                {
                    txtMergeTarget2.EditValue = sData;
                    btnMergeSearch2_Click(null, null);
                }
            }
            else if (tabGr.SelectedTabPageIndex == 4)
            {
                if (txtMergeTarget1.EditValue.ObjectNullString() == "")
                {
                    txtMergeTarget1.EditValue = sData;
                    btnMergeSearch1_Click(null, null);
                }
                else
                {
                    txtMergeTarget2.EditValue = sData;
                    btnMergeSearch2_Click(null, null);
                }
            }
            else if (tabGr.SelectedTabPageIndex == 7)
            {
                //txtReelSerial.EditValue = sData;
                btnReelSearch_Click(null, null);
            }
            //else if (tabGr.SelectedTabPageIndex == 5) //6
            //{
            //    txtEqualSn.EditValue = sData;
            //    btnEqualSearch_Click(null, null);
            //}
            //else if (tabGr.SelectedTabPageIndex == 6) //7
            //{
            //    txtVlotSn.EditValue = sData;
            //    btnVlotSerch_Click(null, null);
            //}
            else
            {
                LanguageInformation clsLan = new LanguageInformation();
                string sMsg = clsLan.GetMessageString("MSG_ER_COMM_027");
                iDATMessageBox.WARNINGMessage(sMsg + "\r\n" +
                                              "Type : " + sType + "\r\n" +
                                              "Barcode : " + sData, this.Text, 3);
            }
        }

        private void Scan_PartNo(string sType, string sData)
        {
            //if (mNewSelBtn != null && tabGr.SelectedTabPageIndex == 0)
            //{
            //    if (mNewSelBtn.Name != "btnNewRecv1")
            //        gleNewPartNo.EditValue = sData;
            //}
            //else if (tabGr.SelectedTabPageIndex == 1)
            //{
            //    txtReTarget.EditValue = sData;
            //    btnReSearch_Click(null, null);
            //}
            //else if (tabGr.SelectedTabPageIndex == 3)
            //{
            //    if (gleMergeLoc.EditValue.ObjectNullString() != "")
            //        gleMergePartNo.EditValue = sData;
            //}
            ////else if (tabGr.SelectedTabPageIndex == 4) //4
            ////{
            ////    if (gleTapingLoc.EditValue.ObjectNullString() != "")
            ////        gleTapingPartNo.EditValue = sData;
            ////}
            //else if (tabGr.SelectedTabPageIndex == 4) //5
            //{
            //    glePartNo.EditValue = sData;
            //}
            //else
            //{
            //    LanguageInformation clsLan = new LanguageInformation();
            //    string sMsg = clsLan.GetMessageString("MSG_ER_COMM_027");
            //    iDATMessageBox.WARNINGMessage(sMsg + "\r\n" +
            //                                  "Type : " + sType + "\r\n" +
            //                                  "Barcode : " + sData, this.Text, 3);
            //}
        }

        private void Scan_PartNoQty(string sType, string sData, string sItemCode, double dQty)
        {
            //if (mNewSelBtn != null && tabGr.SelectedTabPageIndex == 0)
            //{
            //    gleNewPartNo.EditValue = sItemCode;
            //    speNewQty.EditValue = dQty;
            //}
            //else
            //{
            //    LanguageInformation clsLan = new LanguageInformation();
            //    string sMsg = clsLan.GetMessageString("MSG_ER_COMM_027");
            //    iDATMessageBox.WARNINGMessage(sMsg + "\r\n" +
            //                                  "Type : " + sType + "\r\n" +
            //                                  "Barcode : " + sData, this.Text, 3);
            //}
        }

        #endregion

        #region [Button Event]

        public void InitButton_Click()
        {
            GetVendor();
            GetPartNo();
            GetLoc();

            // 초기화 관련 구현은 아래에 구현 ***
            //if (tabGr.SelectedTabPageIndex == 0)
            //    InitNew();
            if (tabGr.SelectedTabPageIndex == 1)
                InitIqd();
            else if (tabGr.SelectedTabPageIndex == 2)
                InitRe();
            else if (tabGr.SelectedTabPageIndex == 3)
                InitSplit();
            else if (tabGr.SelectedTabPageIndex == 4)
                InitMerge();
            //else if (tabGr.SelectedTabPageIndex == 5)
            //    InitTaping();
            //else if (tabGr.SelectedTabPageIndex == 6)
            //    InitPart();
            //else if (tabGr.SelectedTabPageIndex == 7)
            //    InitReel();

        }

        public void DeleteButton_Click()
        {
            // 삭제 관련 구현은 아래에 구현 ***
        }

        public void NewButton_Click()
        {
            // 신규 관련 구현은 아래에 구현 ***
        }

        public void EditButton_Click()
        {
            // 수정 관련 구현은 여기에 구현 ***
        }

        public void StopButton_Click()
        {
            // 정지 관련 구현은 여기에 구현 ***
        }

        public void SearchButton_Click()
        {
            // 검색 관련 구현은 여기에 구현 ***
        }

        public void SaveButton_Click()
        {
            // 저장 관련 구현은 아래에 구현 ***
        }

        public void PrintButton_Click()
        {
            // 출력 관련 구현은 아래에 구현 ***
        }

        public void RefreshButton_Click()
        {
            // 새로고침 관련 구현은 아래에 구현 ***
        }

        #endregion

        #region [Control Event]

        private void btnNewSearch_Click(object sender, EventArgs e)
        {
            //SetReceiveType(btnNewRecv1);
        }

        #region [Tab별 조회버튼 Event]
        /*TAB 1*/
        /*라벨 발행 대상 조회 버튼*/
        /*VENDOR, PARTNO, INVOICE별 라벨 출력대상 정보를 조회한다*/
        private void btnLSearch_Click(object sender, EventArgs e)
        {
            /*신규 라벨 생성 ORDER 조회*/
            GetTarget( gcList
                     , "COMMON"
                     , "NEWPRINT"
                     , gleLVendor.EditValue.ObjectNullString()
                     , gleLPartNo.EditValue.ObjectNullString()
                     , ""
                     , dteFromTo.StartDate
                     , dteFromTo.EndDate
                     , ""
                     );
        }
        /*TAB 2*/
        /*IQC 라벨 발행 대상 조회 버튼*/
        /*VENDOR, PARTNO, INVOICE별 라벨 출력대상 정보를 조회한다*/
        private void btnIqcSearch_Click(object sender, EventArgs e)
        {
            gcIqcList1.DataSource = null;
            gvIqcList1.Columns.Clear();

            /*IQC 라벨 생성 ORDER 공통 함수 호출(신규발행)*/ 
            if (rdoIqcLebleGbn.SelectedIndex == 0)
            {
                BASE_DXGridHelper.Bind_Grid_Int( gcIqcList
                                               , "PKGMAT_INOUT.GET_IQC_LIST"
                                               , 1
                                               , new string[] {
                                                 "A_CLIENT"
                                               , "A_COMPANY"
                                               , "A_PLANT"
                                               , "A_TAB"
                                               , "A_SDATE"
                                               , "A_EDATE"
                                               , "A_INVOICENO"
                                               , "A_ORDERNO"
                                               , "A_ORDERSEQ"
                                               , "A_ITEMCODE"
                                               , "A_VENDOR" }
                                               , new string[] {
                                                 Global.Global_Variable.CLIENT
                                               , Global.Global_Variable.COMPANY
                                               , Global.Global_Variable.PLANT 
                                               , "MATA202.GetGridViewList"
                                               , dteIqcFromTo.StartDate
                                               , dteIqcFromTo.EndDate
                                               , "" //txtCInvoice.EditValue.ObjectNullString()
                                               , "" //txtCOrderNo.EditValue.ObjectNullString() //OrderNo
                                               , "" //OrderSEQ
                                               , gleIqcPartNo.EditValue.ObjectNullString() //Itemcode
                                               , "" }
                                               , true
                                               , "SEL, VENDORNAME, IQCDATE, PARTNO, QTY, ITEMNAME, SPEC, IQCNO, ORDERNO, ORDERSEQ, INVOICENO, VENDOR, ITEMCODE, IQCJUDGE"
                                               , true
                                               , "QTY,ITEMCODE,ORDERSEQ,IQCNO,INVOICENO"
                                               );

                gvIqcList.OptionsView.ColumnAutoWidth = false;
                gvIqcList.BestFitColumns();

                //speIqcQty.Enabled = true;
                //speIqcUnitQty.Enabled = true;

                //GetTarget(gcIqcList,
                //    "COMMON",
                //    "IQCLABELPRINT",
                //    "",
                //    gleIqcPartNo.EditValue.ObjectNullString(),
                //    "",
                //    dteIqcFromTo.StartDate,
                //    dteIqcFromTo.EndDate,
                //    ""
                //    );
            }
            else/*IQC 라벨 생성 ORDER 공통 함수 호출(재발행)*/ 
            {
                speIqcQty.Enabled = false;
                speIqcUnitQty.Enabled = false;

                GetTarget( gcIqcList
                         , "COMMON"
                         , "IQCREPRINT"
                         , ""
                         , gleIqcPartNo.EditValue.ObjectNullString()
                         , ""
                         , dteIqcFromTo.StartDate
                         , dteIqcFromTo.EndDate
                         , ""
                         );
            }
        }
        /*TAB 3*/
        /*라벨 재출력 조회 버튼*/
        /*대상 라벨 입력 후, 라벨에 대한 상세 내용을 조회한다*/
        private void btnReSearch_Click(object sender, EventArgs e)
        {
            if (txtReTarget.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG002", this.Text, 3);
                txtReTarget.Focus();
                return;
            }

            GetTarget( gcReTarget
                     , "REPRINT"
                     , "REPRINT"
                     , ""
                     , ""
                     , ""
                     , ""
                     , ""
                     , txtReTarget.EditValue.ObjectNullString()
                     );

        }
        /*TAB 4*/
        /*라벨 분할 조회 버튼*/
        /*대상 라벨 입력 후, 라벨에 대한 상세 내용을 조회한다*/
        private void btnSplitSearch_Click(object sender, EventArgs e)
        {
            if (txtSplitSN.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_COMM_008", this.Text, 3);
                txtSplitSN.Focus();
                return;

            }

            GetTarget( gcSplitTarget
                     , "SPLIT"
                     , "SPLIT"
                     , ""
                     , ""
                     , ""
                     , ""
                     , ""
                     , txtSplitSN.EditValue.ObjectNullString()
                     );
        }
        /*TAB 5*/
        /*라벨 병합 정보 조회 버튼*/
        /*대상 라벨 입력 후, 라벨에 대한 상세 내용을 조회한다*/
        private void btnMergeSearch1_Click(object sender, EventArgs e)
        {
            if (txtMergeTarget1.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_COMM_008", this.Text, 3);
                txtMergeTarget1.Focus();
                return;

            }

            GetTarget( gcMergeTarget1
                     , "MERGE"
                     , "MERGE"
                     , ""
                     , ""
                     , ""
                     , ""
                     , ""
                     , txtMergeTarget1.EditValue.ObjectNullString()
                     );
        }
        /*TAB 5*/
        /*라벨 병합 정보 조회 버튼*/
        /*대상 라벨 입력 후, 라벨에 대한 상세 내용을 조회한다*/
        private void btnMergeSearch2_Click(object sender, EventArgs e)
        {
            if (txtMergeTarget2.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_COMM_008", this.Text, 3);
                txtMergeTarget2.Focus();
                return;
            }
            if (txtMergeTarget2.EditValue.ObjectNullString() == "NONE")
            {
                if (gleWhlocTarget2.EditValue.ObjectNullString() == "")
                {
                    iDATMessageBox.WARNINGMessage("MSG_ER_COMM_005", this.Text, 3);
                    gleWhlocTarget2.Focus();
                    return;
                }
                if (gleItemCodeTarget2.EditValue.ObjectNullString() == "")
                {
                    iDATMessageBox.WARNINGMessage("MSG_ER_COMM_002", this.Text, 3);
                    gleItemCodeTarget2.Focus();
                    return;
                }
            }
            
            GetTarget( gcMergeTarget2
                     , "MERGE"
                     , "MERGE"
                     , ""
                     , ""
                     , ""
                     , gleWhlocTarget2.EditValue.ObjectNullString()
                     , gleItemCodeTarget2.EditValue.ObjectNullString()
                     , txtMergeTarget2.EditValue.ObjectNullString()
                     );
        }
        /*TAB 6*/
        /*조회버튼 존재하지 않음*/

        /*TAB 7*/
        /*조회버튼 존재하지 않음*/

        /*TAB 8*/
        /*REEL 정보 조회 버튼*/
        /*대상 품목 선택 후 상세 내용을 조회한다*/
        private void btnReelSearch_Click(object sender, EventArgs e)
        {
            if (gleReelWhLoc.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_COMM_005", this.Text, 3);
                gleReelWhLoc.Focus();
                return;

            }
            if (gleReelPartNo.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_COMM_002", this.Text, 3);
                gleReelPartNo.Focus();
                return;

            }
            GetTarget( gcReelLabel
                     , "REEL"
                     , gleReelWhLoc.EditValue.ObjectNullString()
                     , gleReelPartNo.EditValue.ObjectNullString()
                     );
        }
        #endregion
        
        private void btnMergeInit_Click(object sender, EventArgs e)
        {
            txtMergeTarget1.EditValue = null;
            gcMergeTarget1.DataSource = null;
        }

        private void btnMergeInit2_Click(object sender, EventArgs e)
        {
            txtMergeTarget2.EditValue = null;
            gleWhlocTarget2.EditValue = null;
            gleItemCodeTarget2.EditValue = null;
            gcMergeTarget2.DataSource = null;
        }


        private void btnNewRecv1_Click(object sender, EventArgs e)
        {
            SetReceiveType(sender);
        }

        private void btnNewRecv2_Click(object sender, EventArgs e)
        {
            SetReceiveType(sender);
        }

        private void btnNewRecv3_Click(object sender, EventArgs e)
        {
            SetReceiveType(sender);
        }

        private void btnNewRecv4_Click(object sender, EventArgs e)
        {
            SetReceiveType(sender);
        }

        private void btnNewPrint_Click(object sender, EventArgs e)
        {
            //if (gleNewVendor.EditValue.ObjectNullString() == "")
            //{
            //    iDATMessageBox.ErrorMessage("MSG_ER_COMM_007", this.Text, 3);
            //    gleNewVendor.Focus();
            //    return;
            //}

            //if (speNewUnitQty.EditValue.ObjectNullString() == "" || int.Parse(speNewUnitQty.EditValue.ObjectNullString()) < 1)
            //{
            //    iDATMessageBox.ErrorMessage("MSG_ER_MAT_004", this.Text, 3);
            //    return;
            //}

            //if (speNewQty.EditValue.ObjectNullString() == "" || int.Parse(speNewQty.EditValue.ObjectNullString()) < 1)
            //{
            //    iDATMessageBox.ErrorMessage("MSG_ER_STOCK_014", this.Text, 3);
            //    speNewQty.Focus();
            //    return;
            //}

            //if (mNewSelBtn.Name == "btnNewRecv1")
            //{
            //    if (int.Parse(gvNewOrder.GetRowCellValue(gvNewOrder.FocusedRowHandle,"QTY").ObjectNullString()) < int.Parse(speNewQty.EditValue.ObjectNullString()))
            //    {
            //        iDATMessageBox.ErrorMessage("MSG_ER_COMM_037", this.Text, 3);
            //        speNewQty.Focus();
            //        return;
            //    }
            //}

            CreateIqcSN();
        }

        #region [Print Button]
        /*재발행*/
        private void btnRePrint_Click(object sender, EventArgs e)
        {
            if (gvReTarget.RowCount == 0 || gvReTarget.FocusedRowHandle >= gvReTarget.RowCount && gvReTarget.FocusedRowHandle < gvReTarget.RowCount)
            {
                iDATMessageBox.ErrorMessage("MSG_ER_COMM_025", this.Text, 3);
                return;
            }

            SetRePrint();
        }
        /*분할*/
        private void btnSplitPrint_Click(object sender, EventArgs e)
        {
            if (gvSplitTarget.RowCount == 0)
            {
                iDATMessageBox.ErrorMessage("MSG_ER_COMM_008", this.Text, 3);
                txtSplitSN.Focus();
                return;
            }

            if (int.Parse(speSplitQty.EditValue.ObjectNullString()) < 1)
            {
                iDATMessageBox.ErrorMessage("MSG_ER_COMM_001", this.Text, 3);
                speSplitQty.Focus();
                return;
            }

            SetSplitMerge("SPLIT",
                          gvSplitTarget.GetRowCellValue(0, "B").ObjectNullString(),
                          "",
                          "",//gvSplitTarget.GetRowCellValue(1, "B").ObjectNullString(),
                          speSplitQty.EditValue.ObjectNullString());
        }
        /*병합*/
        private void btnMergePrint_Click(object sender, EventArgs e)
        {
            if (gvMergeTarget1.RowCount == 0)
            {
                iDATMessageBox.ErrorMessage("MSG_ER_COMM_008", this.Text, 3);
                txtMergeTarget1.Focus();
                return;
            }

            if (gvMergeTarget2.RowCount == 0)
            {
                iDATMessageBox.ErrorMessage("MSG_ER_COMM_008", this.Text, 3);
                txtMergeTarget2.Focus();
                return;
            }

            if (gvMergeTarget2.RowCount > 0)
            {
                if (txtMergeTarget2.EditValue.ObjectNullString() == "NONE")
                {
                    //NONE 재고일때는 SERIAL + WHLOC + ITEMCODE를 아규먼트로 넘김
                    SetSplitMerge( "MERGE"
                                 , gvMergeTarget1.GetRowCellValue(0, "B").ObjectNullString()
                                 , gvMergeTarget2.GetRowCellValue(0, "B").ObjectNullString() + gleWhlocTarget2.EditValue.ObjectNullString() + gleItemCodeTarget2.EditValue.ObjectNullString()
                                 , gvMergeTarget2.GetRowCellValue(1, "B").ObjectNullString()
                                 , "0"
                                 );
                }
                else
                {
                    SetSplitMerge( "MERGE"
                                 , gvMergeTarget1.GetRowCellValue(0, "B").ObjectNullString()
                                 , gvMergeTarget2.GetRowCellValue(0, "B").ObjectNullString()
                                 , gvMergeTarget2.GetRowCellValue(1, "B").ObjectNullString()
                                 , "0"
                                 );
                }
            }
        }
        /*기타입고*/
        private void btnTapingPrint_Click(object sender, EventArgs e)
        {
            if (gleTapingLoc.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.ErrorMessage("MSG_ER_COMM_005", this.Text, 3);
                gleTapingLoc.Focus();
                return;
            }

            if (gleTapingPartNo.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.ErrorMessage("MSG_ER_COMM_002", this.Text, 3);
                gleTapingPartNo.Focus();
                return;
            }

            if (int.Parse(speTapingUnitQty.EditValue.ObjectNullString()) <= 0)
            {
                iDATMessageBox.ErrorMessage("MSG_ER_COMM_001", this.Text, 3);
                speTapingUnitQty.Focus();
                return;
            }

            if (int.Parse(speTapingQty.EditValue.ObjectNullString()) <= 0)
            {
                iDATMessageBox.ErrorMessage("MSG_ER_COMM_001", this.Text, 3);
                speTapingQty.Focus();
                return;
            }

            if (rdoTapingType.EditValue.ObjectNullString() == "STOCK" || rdoTapingType.EditValue.ObjectNullString() == "STOCKETC")
            {
                if (int.Parse(speTapingQty.EditValue.ObjectNullString()) < int.Parse(speTapingQty.EditValue.ObjectNullString()))
                {
                    iDATMessageBox.ErrorMessage("MSG_ER_STOCK_010", this.Text, 3);
                    speTapingQty.Focus();
                    return;
                }
            }
            SetTaping();
        }
        /*품번*/
        private void btnPartNoPrint_Click(object sender, EventArgs e)
        {
            GetPartNoLabel();
        }
        #endregion
        
        private void txtReTarget_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnReSearch_Click(null, null);
        }

        private void txtSplitSN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSplitSearch_Click(null, null);
        }

        private void txtMergeTarget1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnMergeSearch1_Click(null, null);
        }

        private void txtMergeTarget2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnMergeSearch2_Click(null, null);
        }

        private void rdoTapingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*2016-04-22*/
            /*화면설계서 상 조회 조건만 존재하므로 해당 로직 주석처리*/
            /*by.HS*/
            //if (rdoTapingType.EditValue.ObjectNullString() == "STOCK" && tabGr.SelectedTabPageIndex == 5)
            //{
            //    layoutControlGroup26.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //    gleTapingLoc.Properties.ReadOnly = true;
            //    gleTapingPartNo.Properties.ReadOnly = true;
            //    TapingStockSearch();
            //}
            //else
            //{
            //    gleTapingLoc.Properties.ReadOnly = false;
            //    gleTapingPartNo.Properties.ReadOnly = false;
            //    layoutControlGroup26.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            //}

            layoutControlGroup26.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void gvList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                //gleNVendor.EditValue = gvList.GetRowCellValue(e.FocusedRowHandle, "VENDOR").ObjectNullString();
                //gleNPartNo.EditValue = gvList.GetRowCellValue(e.FocusedRowHandle, "ITEMCODE").ObjectNullString();
                //speNQty.EditValue = gvList.GetRowCellValue(e.FocusedRowHandle, "QTY").ObjectNullString();
                //speNUnittQty.EditValue = gvList.GetRowCellValue(e.FocusedRowHandle, "UNITQTY").ObjectNullString();
            }
        }

        private void btnIqcPrint_Click(object sender, EventArgs e)
        {
            /*IQC 신규 발행*/
            if (rdoIqcLebleGbn.SelectedIndex == 0)
            {
                if (gcIqcList.DataSource == null)
                {
                    iDATMessageBox.ErrorMessage("MSG_ER_MAT_065", this.Text, 3);

                    return;
                }

                if (txtIqcPartNo.EditValue.ObjectNullString() == "")
                {
                    iDATMessageBox.ErrorMessage("MSG_ER_COMM_002", this.Text, 3);
                    return;
                }

                if (speIqcUnitQty.EditValue.ObjectNullString() == "" || int.Parse(speIqcUnitQty.EditValue.ObjectNullString()) < 1)
                {
                    iDATMessageBox.ErrorMessage("MSG_ER_MAT_004", this.Text, 3);
                    speIqcUnitQty.Focus();
                    return;
                }

                if (speIqcQty.EditValue.ObjectNullString() == "" || int.Parse(speIqcQty.EditValue.ObjectNullString()) < 1)
                {
                    iDATMessageBox.ErrorMessage("MSG_ER_STOCK_014", this.Text, 3);
                    speIqcQty.Focus();
                    return;
                }

                if (rdoIqcLebleGbn.EditValue.ObjectNullString() == "N")
                {
                    CreateSN( gvIqcList.GetRowCellValue(gvIqcList.FocusedRowHandle, "INVOICE").ObjectNullString()
                            , gvIqcList.GetRowCellValue(gvIqcList.FocusedRowHandle, "ORDERNO").ObjectNullString()
                            , gvIqcList.GetRowCellValue(gvIqcList.FocusedRowHandle, "ORDERSEQ").ObjectNullString()
                            , gvIqcList.GetRowCellValue(gvIqcList.FocusedRowHandle, "VENDOR").ObjectNullString()
                            , gvIqcList.GetRowCellValue(gvIqcList.FocusedRowHandle, "ITEMCODE").ObjectNullString()
                            , speIqcUnitQty.Value.ObjectNullString()
                            , speIqcQty.Value.ObjectNullString()
                            , "LOCAL"
                            , gvIqcList.GetRowCellValue(gvIqcList.FocusedRowHandle, "IQCNO").ObjectNullString());
                }
                else
                {

                }

                btnIqcSearch_Click(null, null);
            }
            else/*IQC 재발행*/
            {
                DataRow[] dRowList = (gcIqcList.DataSource as DataTable).Select("SEL = 'Y'");

                DataTable dTable = (gcIqcList.DataSource as DataTable).Clone();
                
                foreach (DataRow dRow in dRowList)
                {
                    DataRow dTempRow = dTable.NewRow();

                    for (int nCol = 0; nCol < dTable.Columns.Count; nCol++)
                        dTempRow[nCol] = dRow[nCol];

                    dTable.Rows.Add(dTempRow);
                }

                if (dTable != null && dTable.Rows.Count > 0)
                {
                    if (Print(dTable, 1))
                    {
                        iDATMessageBox.OKMessage("MSG_OK_PRINT_001", this.Text, 3);
                        btnIqcSearch_Click(null, null);
                    }
                }
            }
        }

        private void txtReelSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnReelSearch_Click(null, null);
        }

        

        private void btnReelSplit_Click(object sender, EventArgs e)
        {
            if (gvReelLabel.RowCount == 0)
            {
                iDATMessageBox.ErrorMessage("MSG_ER_COMM_008", this.Text, 3);
                gleReelWhLoc.Focus();
                return;
            }

            if (int.Parse(speReelQty.EditValue.ObjectNullString()) < 1)
            {
                iDATMessageBox.ErrorMessage("MSG_ER_COMM_001", this.Text, 3);
                speReelQty.Focus();
                return;
            }

            ReelSplit();
        }

        private void tabGr_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            if (tabGr.SelectedTabPageIndex == 5)
            {
                TapingStockSearch();
            }
        }

        private void gvTapingList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                gleTapingPartNo.EditValue = gvTapingList.GetRowCellValue(e.FocusedRowHandle, "PARTNO").ToString();
                gleTapingLoc.EditValue = gvTapingList.GetRowCellValue(e.FocusedRowHandle, "WHLOC").ToString();
            }
        }

        #endregion


        #region [Private Method]

        private void InitNew()
        {
            //SetReceiveType(btnNewRecv1);
            btnLSearch_Click(null, null);
            gcList1.DataSource = null;
        }

        private void InitIqd()
        {
            btnIqcSearch_Click(null, null);
            gcIqcList1.DataSource = null;
        }
        

        private void InitRe()
        {
            txtReTarget.EditValue = null;
            gcReTarget.DataSource = null;
            gcReLabel.DataSource = null;
        }
        private void InitSplit()
        {
            txtSplitSN.EditValue = null;
            gcSplitTarget.DataSource = null;
        }

        private void InitMerge()
        {
            txtMergeTarget1.EditValue = null;
            txtMergeTarget2.EditValue = null;
            gcMergeTarget1.DataSource = null;
            gcMergeTarget2.DataSource = null;
        }

        private void InitTaping()
        {
            gcTapingLabel.DataSource = null;
            gleTapingLoc.EditValue = null;
            gleTapingPartNo.EditValue = null;
            speTapingQty.EditValue = null;
            TapingStockSearch();
        }

        private void InitPart()
        {

        }

        private void InitReel()
        {
            //txtReelSerial.EditValue = null;
            speReelQty.EditValue = null;
            txtReelComment.EditValue = null;
            gcReelLabel.DataSource = null;
        }

        private void SetReceiveType(object sender)
        {

            bool bReadOnly = false;

            gleNPartNo.EditValue = null;
            gleNVendor.EditValue = null;
            speNQty.EditValue = null;
            speNUnittQty.EditValue = null;

            mNewSelBtn = sender as IDAT.Devexpress.DXControl.IdatDxSimpleButton;
            //txtNewInvoice.EditValue = null;
            //txtNewOrder.EditValue = null;
            //txtNewOrderSeq.EditValue = null;
            //gleNewVendor.EditValue = 101607; // 2014.08.05 홍성원. 박영순B 요청. LG Display 자동 선택
            //gleNewPartNo.EditValue = null;
            //txtRankNo.EditValue = null;
            //gleNewPcbMaker.EditValue = null;
            //txtMaker.EditValue = null;
            //speNewUnitQty.EditValue = null;
            //speNewQty.EditValue = null;
            //gcNewLabel.DataSource = null;
            //txtSlipNo.EditValue = null;

            //GetVendor(mNewSelBtn.Tag.ObjectNullString());

            //switch (mNewSelBtn.Name)
            //{
            //    case "btnNewRecv1":
            //        // 로컬/내수
            //        btnNewRecv1.Image = HAENGSUNG_HNSMES_UI.Properties.Resources.button_ok;
            //        btnNewRecv2.Image = null;
            //        btnNewRecv3.Image = null;
            //        btnNewRecv4.Image = null;
            //        typegbn = "LOCAL";

            //        //GetOrder();
            //        bReadOnly = true;
            //        break;

            //    case "btnNewRecv2":
            //        // 차입
            //        btnNewRecv1.Image = null;
            //        btnNewRecv2.Image = HAENGSUNG_HNSMES_UI.Properties.Resources.button_ok;
            //        btnNewRecv3.Image = null;
            //        btnNewRecv4.Image = null;
            //        typegbn = "BORROW";
            //        break;

            //    case "btnNewRecv3":
            //        // 차출반납
            //        btnNewRecv1.Image = null;
            //        btnNewRecv2.Image = null;
            //        btnNewRecv3.Image = HAENGSUNG_HNSMES_UI.Properties.Resources.button_ok;
            //        btnNewRecv4.Image = null;
            //        typegbn = "RETURNRENTAL";
            //        break;

            //    case "btnNewRecv4":
            //        // 업체반납
            //        btnNewRecv1.Image = null;
            //        btnNewRecv2.Image = null;
            //        btnNewRecv3.Image = null;
            //        btnNewRecv4.Image = HAENGSUNG_HNSMES_UI.Properties.Resources.button_ok;
            //        typegbn = "RETURNOUTSOURCING";
            //        break;
            //}

            gleNPartNo.Properties.ReadOnly = bReadOnly;
            gleNVendor.Properties.ReadOnly = bReadOnly;

            if (bReadOnly == true)
            {
                speNQty.Properties.ReadOnly = true;
            }
            else
            {
                speNQty.Properties.ReadOnly = false;
            }
        }

        private void GetLoc()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleTapingLoc
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
                                                       , "MATRECEIVE" }
                                                       , "WHLOC"
                                                       , "LOCNAME"
                                                       , "WHLOC, LOCNAME, REMARKS"
                                                       );

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleReelWhLoc
                                                       , "PKGBAS_BASE.GET_LOCATION2"
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
                                                       , "WHLOC"
                                                       , "WHLOCNAME"
                                                       , "WHLOC, WHLOCNAME, REMARKS"
                                                       );

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWhlocTarget2
                                                       , "PKGBAS_BASE.GET_LOCATION2"
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
                                                       , "WHLOC"
                                                       , "WHLOCNAME"
                                                       , "WHLOC, WHLOCNAME, REMARKS"
                                                       );  
        }

        /*PARTNO 조회 함수*/
        private void GetPartNo()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleLPartNo
                                                       , "PKGBAS_BASE.GET_PARTNO"
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
                                                       , "PARTNO,ITEMNAME, SPEC"
                                                       );
            
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleIqcPartNo
                                                       , "PKGBAS_BASE.GET_PARTNO"
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
                                                       , "PARTNO,ITEMNAME, SPEC"
                                                       );

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleNPartNo
                                                       , "PKGBAS_BASE.GET_PARTNO"
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
                                                       , "PARTNO,ITEMNAME, SPEC"
                                                       );

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleReelPartNo
                                                       , "PKGBAS_BASE.GET_PARTNO"
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
                                                       , "PARTNO,ITEMNAME, SPEC"
                                                       );

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleItemCodeTarget2
                                                       , "PKGBAS_BASE.GET_PARTNO"
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
                                                       , "PARTNO,ITEMNAME, SPEC"
                                                       );

            //DataTable dtPartNo;
            //BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleLPartNo,
            //                                            "PKGMAT_INOUT.GET_PARTNO",
            //                                            1,
            //                                            new string[] { },
            //                                            new string[] { },
            //                                            "ITEMCODE",
            //                                            "SPEC",
            //                                            "PARTNO,SPEC,ITEMNAME");
            ///*탭별 PartNo 조회 데이터 바인딩*/
            //dtPartNo = gleLPartNo.Properties.DataSource as DataTable;

            //BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleNPartNo
            //                                          , dtPartNo.Copy()
            //                                          , "ITEMCODE"
            //                                          , "SPEC"
            //                                          , "PARTNO,SPEC,ITEMNAME"
            //                                          , false);

            //BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleIqcPartNo
            //                                           , dtPartNo.Copy()
            //                                           , "ITEMCODE"
            //                                           , "SPEC"
            //                                           , "PARTNO,SPEC,ITEMNAME"
            //                                           , false);


            //BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(glePartNo
            //                                           , dtPartNo.Copy()
            //                                           , "ITEMCODE"
            //                                           , "SPEC"
            //                                           , "PARTNO,SPEC,ITEMNAME"
            //                                           , false);

            //BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleTapingPartNo
            //                                           , dtPartNo.Copy()
            //                                           , "ITEMCODE"
            //                                           , "SPEC"
            //                                          , "PARTNO,SPEC,ITEMNAME"
            //                                           , false);
        }
        /*VENDOR 조회 함수*/
        private void GetVendor()
        {
            //BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleLVendor,
            //                                            "PKGBAS_BASE.GET_ERP_VENDOR",
            //                                            1,
            //                                            new string[] { },
            //                                            new string[] { },
            //                                            "CVCOD",
            //                                            "CVNAS2",
            //                                            "CVCOD,CVNAS2");

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleLVendor
                                                       , "PKGBAS_BASE.GET_VENDOR"
                                                       , 1
                                                       , new string[] { 
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_PURCHASE"
                                                       , "A_SALES"
                                                       , "A_OUTSC"
                                                       , "A_VIEW" }
                                                       , new string[] { 
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , "Y"
                                                       , "N"
                                                       , "N"
                                                       , "0" }
                                                       , "VENDOR"
                                                       , "VENDORNAME"
                                                       , "VENDOR,VENDORNAME"
                                                       );

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleNVendor
                                                       , "PKGBAS_BASE.GET_VENDOR"
                                                       , 1
                                                       , new string[] { 
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_PURCHASE"
                                                       , "A_SALES"
                                                       , "A_OUTSC"
                                                       , "A_VIEW" }
                                                       , new string[] { 
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , "Y"
                                                       , "N"
                                                       , "N"
                                                       , "0" }
                                                       , "VENDOR"
                                                       , "VENDORNAME"
                                                       , "VENDOR,VENDORNAME"
                                                       );
        }

        private void GetRank(GridLookUpEdit glEdit, string sItemCode)
        {
            glEdit.Properties.ReadOnly = false;

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( glEdit
                                                       , "PKGMAT_INOUT.GET_RANK"
                                                       , 1
                                                       , new string[] { 
                                                         "A_PLANT"
                                                       , "A_ITEMCODE" }
                                                       , new string[] { 
                                                         HAENGSUNG_HNSMES_UI.Global.Global_Variable.PLANT
                                                       , sItemCode }
                                                       , "RANKNO"
                                                       , "RANKNO"
                                                       , "RANKNO,REMARKS"
                                                       );
        }

        private void GetVendor(string sType)
        {
            //BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleNewVendor,
            //                                            "PKGPDA_COMM.GET_VENDOR",
            //                                            1,
            //                                            new string[] { "A_PLANT",
            //                                                           "A_TYPE",
            //                                                           "A_VENDOR"},
            //                                            new string[] { Global.Global_Variable.PLANT,
            //                                                           sType,
            //                                                           ""},
            //                                            "VENDOR",
            //                                            "VENDORNAME",
            //                                            "VENDOR,VENDORNAME");
        }

        /// <summary>
        /// 조회 후 바인딩 Func.sParamTabPage에 따라 바인딩 형식 지정(가로, 세로)
        /// </summary>
        /// <param name="gCtl"></param>
        /// <param name="sParamTabPage"></param>
        /// <param name="sParamValue"></param>
        private void GetTarget(DevExpress.XtraGrid.GridControl gCtl, string sParamTabPage, params string[] sParamValue)
        {
            /*재발행*/
            if (sParamTabPage == "COMMON")
            {
                if (rdgIncome.EditValue.ObjectNullString() == "I")
                {
                    BASE_DXGridHelper.Bind_Grid( gCtl
                                               , "PKGMAT_INOUT.GET_LABEL_ORDER"
                                               , 1
                                               , new string[] { 
                                                 "A_CLIENT"
                                               , "A_COMPANY"
                                               , "A_PLANT"
                                               , "A_TAB"
                                               , "A_VENDOR"
                                               , "A_ITEMCODE"
                                               , "A_INVOICE"
                                               , "A_SDATE"
                                               , "A_EDATE"
                                               , "A_SERIAL" }
                                               , new string[] { 
                                                 Global.Global_Variable.CLIENT
                                               , Global.Global_Variable.COMPANY
                                               , Global.Global_Variable.PLANT
                                               , sParamValue[0]
                                               , sParamValue[1]
                                               , sParamValue[2]
                                               , sParamValue[3]
                                               , sParamValue[4]
                                               , sParamValue[5]
                                               , sParamValue[6] }
                                               , true
                                               , ""
                                               , false
                                               );
                }
                else
                {
                    BASE_DXGridHelper.Bind_Grid( gCtl
                                               , "PKGMAT_INOUT.GET_LABEL_ORDER"
                                               , 1
                                               , new string[] { 
                                                 "A_CLIENT"
                                               , "A_COMPANY"
                                               , "A_PLANT"
                                               , "A_TAB"
                                               , "A_VENDOR"
                                               , "A_ITEMCODE"
                                               , "A_INVOICE"
                                               , "A_SDATE"
                                               , "A_EDATE"
                                               , "A_SERIAL" }
                                                   , new string[] { 
                                                 Global.Global_Variable.CLIENT
                                               , Global.Global_Variable.COMPANY
                                               , Global.Global_Variable.PLANT
                                               , "RETURNOUTSOURCING"
                                               , sParamValue[1]
                                               , sParamValue[2]
                                               , sParamValue[3]
                                               , sParamValue[4]
                                               , sParamValue[5]
                                               , sParamValue[6] }
                                               , true
                                               , ""
                                               , false
                                               );

                }
                var vGridView = gCtl.DefaultView as DevExpress.XtraGrid.Views.Grid.GridView;

                //if (vGridView.RowCount > 0)
                //{
                //    gleNVendor.EditValue = gvList.GetRowCellValue(0, "VENDOR").ObjectNullString();
                //    gleNPartNo.EditValue = gvList.GetRowCellValue(0, "ITEMCODE").ObjectNullString();
                //    speNQty.EditValue = gvList.GetRowCellValue(0, "QTY").ObjectNullString();
                //}
                //else
                //{
                //    gleNVendor.EditValue = null;
                //    gleNPartNo.EditValue = null;
                //    speNQty.EditValue = null;
                //    speNUnittQty.EditValue = null;
                //}

                if (vGridView is DevExpress.XtraGrid.Views.Grid.GridView)
                {
                    vGridView.OptionsView.ColumnAutoWidth = false;
                    vGridView.BestFitColumns();
                }

                if (sParamValue[0] == "IQCREPRINT")
                {
                    gvIqcList.OptionsBehavior.Editable = true;
                    gvIqcList.Columns["SEL"].OptionsColumn.AllowEdit = true;
                }

               
            }
            else if (sParamTabPage == "REPRINT" || sParamTabPage == "SPLIT" || sParamTabPage == "MERGE")
            {
                BASE_DXGridHelper.Bind_Grid_RT( gCtl
                                              , "PKGMAT_INOUT.GET_LABEL_ORDER"
                                              , 1
                                              , new string[] { 
                                                "A_CLIENT"
                                              , "A_COMPANY"
                                              , "A_PLANT"
                                              , "A_TAB"
                                              , "A_VENDOR"
                                              , "A_ITEMCODE"
                                              , "A_INVOICE"
                                              , "A_SDATE"
                                              , "A_EDATE"
                                              , "A_SERIAL" }
                                              , new string[] { 
                                                Global.Global_Variable.CLIENT
                                              , Global.Global_Variable.COMPANY
                                              , Global.Global_Variable.PLANT
                                              , sParamValue[0]
                                              , sParamValue[1]
                                              , sParamValue[2]
                                              , sParamValue[3]
                                              , sParamValue[4]
                                              , sParamValue[5]
                                              , sParamValue[6] }                                            
                                              , true
                                              , "SERIAL, ITEMCODE, PARTNO, ITEMNAME, QTY, BCDDATA, BCDLOT"
                                              , false
                                              );

                if (gvMergeTarget1.RowCount > 0)
                {
                    gleWhlocTarget2.EditValue = gvMergeTarget1.GetRowCellValue(8, "B").ObjectNullString();
                    gleItemCodeTarget2.EditValue = gvMergeTarget1.GetRowCellValue(1, "B").ObjectNullString();
                }
            }
            else if (sParamTabPage == "REEL")
            {
                BASE_DXGridHelper.Bind_Grid_RT( gCtl
                                              , "PKGMAT_INOUT.GET_REELQTYSPLIT"
                                              , 1
                                              , new string[] { 
                                                "A_CLIENT"
                                              , "A_COMPANY"
                                              , "A_PLANT"
                                              , "A_WHLOC"
                                              , "A_ITEMCODE" }
                                              , new string[] { 
                                                Global.Global_Variable.CLIENT
                                              , Global.Global_Variable.COMPANY
                                              , Global.Global_Variable.PLANT
                                              , sParamValue[0]
                                              , sParamValue[1] }
                                              , true
                                              , ""
                                              , false
                                              );
            }
        }


        private void CreateIqcSN()
        {

        }


        private void SetRePrint()
        {
            DataTable dt = (DataTable)gcReTarget.DataSource;
            // 프로시져 수행
            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = 
                BASE_db.Execute_Proc( "PKGMAT_INOUT.SET_REPRINT"
                                    , 1
                                    , new string[] { 
                                      "A_CLIENT"
                                    , "A_COMPANY"
                                    , "A_PLANT"
                                    , "A_PRINTTYPE"
                                    , "A_SN"
                                    , "A_BCDLOT"
                                    , "A_IQCNO"
                                    , "A_USER" }
                                    , new string[] { 
                                      Global.Global_Variable.CLIENT
                                    , Global.Global_Variable.COMPANY
                                    , Global.Global_Variable.PLANT
                                    , rdoPrintGubun.EditValue.ObjectNullString()
                                    , gvReTarget.GetRowCellValue(0,"B").ObjectNullString()
                                    , txtBcdLot.EditValue.ObjectNullString()
                                    , gvReTarget.GetRowCellValue(1,"B").ObjectNullString()
                                    , Global.Global_Variable.EHRCODE }
                                    );
            
            if (_Result.ResultInt == 0)
            {
                BASE_DXGridHelper.Bind_Grid_RT( gcReLabel
                                              , _Result.ResultDataSet.Tables[0]);

                if (Print(_Result.ResultDataSet.Tables[0], 1))
                {
                    iDATMessageBox.OKMessage("MSG_OK_PRINT_001", this.Text, 3);
                    //InitRe();
                }
            }
            else
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
        }


        private void SetSplitMerge(string sType, string sSN1, string sSN2, string sIqcno, string sQty)
        {
            // 프로시져 수행
            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = 
                BASE_db.Execute_Proc( "PKGMAT_INOUT.SET_SPLITMERGE"
                                    , 1
                                    , new string[] { 
                                      "A_CLIENT"
                                    , "A_COMPANY"
                                    , "A_PLANT"
                                    , "A_TYPE"
                                    , "A_SN1"
                                    , "A_SN2"
                                    , "A_SPLITQTY"
                                    , "A_IQCNO"
                                    , "A_USER" }
                                    , new string[] { 
                                      Global.Global_Variable.CLIENT
                                    , Global.Global_Variable.COMPANY
                                    , Global.Global_Variable.PLANT
                                    , sType
                                    , sSN1
                                    , sSN2
                                    , sQty
                                    , sIqcno
                                    , Global.Global_Variable.EHRCODE }
                                    );

            if (_Result.ResultInt == 0)
            {
                if (sType == "SPLIT")
                {
                    BASE_DXGridHelper.Bind_Grid_RT( gcSplitLabel1
                                                  , _Result.ResultDataSet.Tables[0]);

                    BASE_DXGridHelper.Bind_Grid_RT( gcSplitLabel2
                                                  , _Result.ResultDataSet.Tables[1]);

                    if (Print(_Result.ResultDataSet.Tables[0], 1))
                        if (Print(_Result.ResultDataSet.Tables[1], 1))
                        {
                            iDATMessageBox.OKMessage("MSG_OK_PRINT_001", this.Text, 3);
                            gcSplitLabel1.DataSource = null;
                            gcSplitLabel2.DataSource = null;
                            //InitSplit();
                        }
                }
                else
                {
                    BASE_DXGridHelper.Bind_Grid_RT( gcMergeLabel
                                                  , _Result.ResultDataSet.Tables[0]);

                    if (Print(_Result.ResultDataSet.Tables[0], 1))
                    {
                        iDATMessageBox.OKMessage("MSG_OK_PRINT_001", this.Text, 3);
                        //gcMergeLabel.DataSource = null;
                        //InitMerge();
                    }
                }
            }
            else
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
        }

        private void GetPartNoLabel()
        {
            // 프로시져 수행
            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = 
                BASE_db.Execute_Proc( "PKGMAT_INOUT.GET_SNINFO"
                                    , 1
                                    , new string[] { 
                                      "A_PLANT"
                                    , "A_TYPE"
                                    , "A_PARAM1"
                                    , "A_PARAM2" }
                                    , new string[] { 
                                      Global.Global_Variable.PLANT
                                    , "PARTNO"
                                    , glePartNo.EditValue.ObjectNullString()
                                    , ""
                                    , "" }
                                    );

            if (_Result.ResultInt == 0)
            {
                if (Print(_Result.ResultDataSet.Tables[0], 1))
                {
                    iDATMessageBox.OKMessage("MSG_OK_PRINT_001", this.Text, 3);
                    InitPart();
                }
            }
            else
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
        }

        private bool Print(DataTable dTable, int nCopies)
        {
            using (RPT.RPTA202 _rpt = new RPT.RPTA202(dTable, nCopies))
            {
                _rpt.RptPrint();
            }
            return true;
        }

        private void btnNPrint_Click(object sender, EventArgs e)
        {
            if (gleNVendor.Text == "")
            {
                iDATMessageBox.ErrorMessage("MSG_ER_COMM_007", this.Text, 3);
                gleNVendor.Focus();
                return;
            }

            if (gleNPartNo.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.ErrorMessage("MSG_ER_COMM_002", this.Text, 3);
                return;
            }

            if (speNUnittQty.EditValue.ObjectNullString() == "" || int.Parse(speNUnittQty.EditValue.ObjectNullString()) < 1)
            {
                iDATMessageBox.ErrorMessage("MSG_ER_MAT_004", this.Text, 3);
                return;
            }

            if (speNQty.EditValue.ObjectNullString() == "" || int.Parse(speNQty.EditValue.ObjectNullString()) < 1)
            {
                iDATMessageBox.ErrorMessage("MSG_ER_STOCK_014", this.Text, 3);
                speNQty.Focus();
                return;
            }

            //string invoiceno = string.Empty;
            //string orderno = string.Empty;
            //string orderseq = string.Empty;

            string invoiceno= gvList.GetRowCellValue(gvList.FocusedRowHandle, "INVOICE").ObjectNullString();
            string orderno = gvList.GetRowCellValue(gvList.FocusedRowHandle, "ORDERNO").ObjectNullString();
            string orderseq = gvList.GetRowCellValue(gvList.FocusedRowHandle, "ORDERSEQ").ObjectNullString();

            if (rdgIncome.EditValue.ObjectNullString() == "R")
            {
                typegbn = "RETURNOUTSOURCING";
            }
            else
            {
                typegbn = "LOCAL";
            }
            
            CreateSN( invoiceno
                    , orderno
                    , orderseq
                    , gleNVendor.EditValue.ObjectNullString()
                    , gleNPartNo.EditValue.ObjectNullString()
                    , speNUnittQty.Value.ObjectNullString()
                    , speNQty.Value.ObjectNullString()
                    , typegbn
                    , "");

            btnLSearch_Click(null, null);

        }

        private void CreateSN(string invoiceno, string orderno, string orderseq, string vendor, string itemcode, string unitqty, string qty,  string txncode, string iqcno)
        { 
            // 프로시져 수행
            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = 
                BASE_db.Execute_Proc( "PKGMAT_INOUT.SET_NEW_CREATESN"
                                    , 1
                                    , new string[] { 
                                      "A_CLIENT"
                                    , "A_COMPANY"
                                    , "A_PLANT"
                                    , "A_TYPE"
                                    , "A_ORDERNO"
                                    , "A_ORDERSEQ"
                                    , "A_INVOICENO"
                                    , "A_VENDOR"
                                    , "A_ITEMCODE"
                                    , "A_UNITQTY"
                                    , "A_INQTY"
                                    , "A_TXNCODE"
                                    , "A_BCDDATA"
                                    , "A_BEFSN"
                                    , "A_BCDLOT"
                                    , "A_MAKER"
                                    , "A_SLIPNO"
                                    , "A_IQCNO"
                                    , "A_USER" }
                                    , new object[] {
                                      Global.Global_Variable.CLIENT
                                    , Global.Global_Variable.COMPANY
                                    , Global.Global_Variable.PLANT
                                    , "NEW"
                                    , orderno
                                    , orderseq
                                    , invoiceno
                                    , vendor
                                    , itemcode
                                    , unitqty
                                    , qty
                                    , txncode
                                    , gvIqcList.GetRowCellValue(gvIqcList.FocusedRowHandle, "BCDDATA").ObjectNullString() //BCDDATA
                                    , null //BEFSN
                                    , gvIqcList.GetRowCellValue(gvIqcList.FocusedRowHandle, "BCDLOT").ObjectNullString() //BCDLOT
                                    , null //MAKER
                                    , null //SLIPNO
                                    , iqcno
                                    , Global.Global_Variable.EHRCODE}
                                    );
                                                                                               
            

            if (_Result.ResultInt == 0)
            {
                if (tabGr.SelectedTabPageIndex == 0)
                {
                    BASE_DXGridHelper.Bind_Grid( gcList1
                                               , _Result.ResultDataSet.Tables[0]);

                    gvList1.OptionsView.ColumnAutoWidth = false;
                    gvList1.BestFitColumns();
                }
                else
                {
                    BASE_DXGridHelper.Bind_Grid( gcIqcList1
                                               , _Result.ResultDataSet.Tables[0]);

                    gvIqcList1.OptionsView.ColumnAutoWidth = false;
                    gvIqcList1.BestFitColumns();
                }

                int nCopies = 1;

                DataTable dtPrint = _Result.ResultDataSet.Tables[0].Clone();

                for (int nRow = 0; nRow < _Result.ResultDataSet.Tables[0].Rows.Count; nRow++)
                {
                    dtPrint.Clear();
                    dtPrint.ImportRow(_Result.ResultDataSet.Tables[0].Rows[nRow]);

                    Print(dtPrint, nCopies);
                }

                    //if (Print(_Result.ResultDataSet.Tables[0], Convert.ToInt32(speIqcQty.Text.ToString())))
                    //{
                    //    iDATMessageBox.OKMessage("MSG_OK_PRINT_001", this.Text, 3);
                    //    btnLSearch_Click(null, null);
                    //}
                
            }
            else
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
        
        }

        private void ReelSplit()
        {
            // 프로시져 수행
            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = 
                BASE_db.Execute_Proc( "PKGMAT_INOUT.SET_REELSPLIT"
                                    , 1
                                    , new string[] { 
                                      "A_PLANT"
                                    , "A_TYPE"
                                    , "A_SN"
                                    , "A_SPLITQTY"
                                    , "A_REMARKS"
                                    , "A_IQCNO"
                                    , "A_USER" }
                                    , new string[] { 
                                      Global.Global_Variable.PLANT
                                    , "REELSPLIT"
                                    , gvReelLabel.GetRowCellValue(0, "B").ObjectNullString()
                                    , speReelQty.EditValue.ObjectNullString()
                                    , txtReelComment.EditValue.ObjectNullString()
                                    , ""
                                    , Global.Global_Variable.EHRCODE }
                                    );

            if (_Result.ResultInt == 0)
            {
                iDATMessageBox.OKMessage("MSG_OK_REG_001", this.Text, 3);
                InitReel();
            }
            else
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
        }

        private void TapingStockSearch()
        {
            /*2016.04.15*/
            /*PACKEGE 존재하지 않음*/
            /*PACKEGE 생성 후 프로그램 확인 필요*/
            //BASE_DXGridHelper.Bind_Grid(
            //                                gcTapingList
            //                               , "PKGBAS_MAT.GET_MATERIAL_STATUS"
            //                               , 1
            //                               , new string[] {
            //                                                 "A_WAREHOUSE"
            //                                               , "A_WHLOC"
            //                                               , "A_PARTNO"
            //                                               , "A_SERIAL"
            //                                              }
            //                               , new string[] {
            //                                                 ""
            //                                               , ""
            //                                               , ""
            //                                               , "NONE"
            //                                              }
            //                               , true
            //                               , "WRKCTR, WHLOC, STOCKTYPE"
            //                               , false
            //                            );

            //gvTapingList.OptionsView.ColumnAutoWidth = false;
            //gvTapingList.BestFitColumns();
        }

 

        private void SetTaping()
        {
            string stocktype = string.Empty;

            //if (rdoTapingType.EditValue.ObjectNullString() == "STOCK")
            //{
            //    stocktype = gvTapingList.GetRowCellValue(gvTapingList.FocusedRowHandle, "STOCKTYPE").ToString();
            //}
            //else
            //{
            //    stocktype = "G";
            //}
            stocktype = "G";
            // 프로시져 수행
            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = 
                BASE_db.Execute_Proc( "PKGMAT_INOUT.SET_TAPING"
                                    , 1
                                    , new string[] { 
                                      "A_PLANT"
                                    , "A_TYPE"
                                    , "A_WHLOC"
                                    , "A_ITEMCODE"
                                    , "A_STOCKTYPE"
                                    , "A_MAKER"
                                    , "A_BCDLOT"
                                    , "A_UNITQTY"
                                    , "A_QTY"
                                    , "A_IQCNO"
                                    , "A_USER" }
                                    , new string[] { 
                                      Global.Global_Variable.PLANT
                                    , rdoTapingType.EditValue.ObjectNullString()
                                    , gleTapingLoc.EditValue.ObjectNullString()
                                    , gleTapingPartNo.EditValue.ObjectNullString()
                                    , stocktype
                                    , ""
                                    , txtTapingLot.EditValue.ObjectNullString()
                                    , speTapingUnitQty.EditValue.ObjectNullString()
                                    , speTapingQty.EditValue.ObjectNullString()
                                    , ""
                                    , Global.Global_Variable.EHRCODE }
                                    );

            if (_Result.ResultInt == 0)
            {
                BASE_DXGridHelper.Bind_Grid( gcTapingLabel
                                           , _Result.ResultDataSet.Tables[0]);

                if (Print(_Result.ResultDataSet.Tables[0], 1))
                {
                    iDATMessageBox.OKMessage("MSG_OK_PRINT_001", this.Text, 3);
                    InitTaping();
                }
            }
            else
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
        }

        #endregion

        private void rdoIqcLebleGbn_SelectedIndexChanged(object sender, EventArgs e)
        {
            gcIqcList.DataSource = null;
            gvIqcList.Columns.Clear();

            txtIqcVendor.EditValue = null;
            txtIqcPartNo.EditValue = null;
            txtIqcDate.EditValue = null;
            speIqcQty.EditValue = null;
            speIqcUnitQty.EditValue = null;
        }

        private void speIqcUnitQty_Enter(object sender, EventArgs e)
        {
            if (int.Parse(speIqcUnitQty.EditValue.ObjectNullString()) <= 0)
                speIqcUnitQty.EditValue = null;
        }

        private void txtSplitSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                btnSplitSearch_Click(null, null);
        }

        private void txtMergeTarget1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                btnMergeSearch1_Click(null, null);
        }

        private void txtMergeTarget2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                btnMergeSearch2_Click(null, null);
        }

        private void txtReTarget_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                btnReSearch_Click(null, null);
        }
    }
}
