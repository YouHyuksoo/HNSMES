using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

// DevExpress namespace
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views;

// User namespace
using HAENGSUNG_HNSMES_UI.Class;
using GridAlias = DevExpress.XtraGrid.Views.Grid;
using HAENGSUNG_HNSMES_UI.WebService.Access;

using DevExpress.XtraSplashScreen;

namespace HAENGSUNG_HNSMES_UI.Forms.PRD
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : PRDA205<br/>
    ///      기능 : 개별 포장 / 수량 포장 / 포장 해체 등록 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>

    public partial class PRDA205 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
    {
        // ******************************************* Base From Class ************************************
        // BASE_clsDevexpressGridUtil          DevExpress Grid 관련 Util Class.
        // BASE_db;                            웹서비스 DB처리 관련 Util Class.
        // BASE_DXGridHelper;                  DevExpress GridControl 데이터 Bind관련 Class
        // BASE_DXGridLookUpHelper;            DevExpress GridLookUp 데이터 Bind관련 Class
        // BASE_IDATLayoutUtil;                DevExpress LayoutControl Util Class.
        // BASE_Language;                      Language Util. ex) BASE_Language.GetMessageString("Code") 
        // ************************************************************************************************

        bool m_blCheck = true;

        #region [Form Event]

        public PRDA205()
        {
            InitializeComponent();
        }

        private void PRDA205_Load(object sender, EventArgs e)
        {
            // 최초 폼 로드 시 발생 이벤트
            InitForm();
        }


        private void PRDA205_Shown(object sender, EventArgs e)
        {
            /*포장 박스 수동 입력 테스트용*/
            if (Global.Global_Variable.USER_ID == "SYSOPER")
                layoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            tabbedControlGroup1.SelectedTabPageIndex = 0;
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
            if (m_blCheck == false)
                return;

            LanguageInformation clsLan = new LanguageInformation();
            string sMsg;


            switch (sType)
            {
                case "BOXPACKING":
                    if (tabbedControlGroup1.SelectedTabPageIndex == 1)
                    {
                        InitControl_BoxPacking();
                        GetBoxInfo_BoxPacking("BOXPACKING", sData);
                    }
                    else
                    {
                        this.GetBoxInfo_UnBoxPacking(sData);
                    }
                    break;
                case "BOXNO":
                    if (tabbedControlGroup1.SelectedTabPageIndex == 0)
                    {
                        InitControl_SerialPacking();

                        if (Check_Data("SERIALPACKING") == false)
                            return;

                        this.GetBoxInfo_SerialPacking("SERIALPACKING", sData);
                    }
                    else if (tabbedControlGroup1.SelectedTabPageIndex == 1)
                    {
                        if (txtBoxpackNo.EditValue.ObjectNullString() == "")
                        {
                            return;
                        }

                        GetProdInfo_BoxPacking(sData);
                    }
                    else
                    {
                       
                        this.GetBoxInfo_UnPacking(sData);
                    }

                    break;
                case "PCBBOXNO":
                    if (tabbedControlGroup1.SelectedTabPageIndex == 0)
                    {
                        txtEmptyBoxNo.EditValue = sData;
                    }
                    else
                    {
                        InitControl_QtyPacking();

                        if (Check_Data("QTYPACKING") == false)
                            return;

                        this.GetBoxInfo_QtyPacking("QTYPACKING", sData);
                    }
                    break;

                case "PRODSN":
                    if (tabbedControlGroup1.SelectedTabPageIndex == 0)
                    {
                        GetProdInfo_SerialPacking(sData); //시리얼 포장
                    }
                   
                    break;

                case "NUMBER":
                    if (int.Parse(txtSerialBoxQty.Text) >= int.Parse(txtSerialPackQty.EditValue.ObjectNullString()) + int.Parse(sData))
                    {
                        txtSerialPackQty.EditValue = (int.Parse(txtSerialPackQty.EditValue.ObjectNullString()) + int.Parse(sData)).ObjectNullString();
                    }

                    break;
                case "WEIGHT":
                    if (txtSerialBoxNo.EditValue.ObjectNullString() == "") return;
                    txtWeight.EditValue = sData.Substring(6).TrimStart().TrimEnd();

                    if (int.Parse(txtSerialBoxQty.EditValue.ObjectNullString()) == int.Parse(txtSerialCurQty.EditValue.ObjectNullString()) + int.Parse(txtSerialPackQty.EditValue.ObjectNullString()))
                    {
                        this.SetSerialPacking();
                    }

                    break;

                case "NODEFINE":
                    if (tabbedControlGroup1.SelectedTabPageIndex == 0)
                        this.GetProdInfo_SerialPacking(sData);

                    else
                    {
                        sMsg = clsLan.GetMessageString("MSG_ER_COMM_027");
                        iDATMessageBox.WARNINGMessage(sMsg + "\r\n" +
                                                        "Type : " + sType + "\r\n" +
                                                        "Barcode : " + sData, this.Text, 3);

                    }

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

            ////  현재 프로그램 모드정보를 변경한다.
            ////  IDAT.Devexpress.FORM.UPDATEITEMTYPE.None = 초기화 모드
            ////  IDAT.Devexpress.FORM.UPDATEITEMTYPE.New  = 신규 모드
            ////  IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit = 수정 모드
            this.InitForm();
            //base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);
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
            if (tabbedControlGroup1.SelectedTabPageIndex == 1)
                GetQtyPackingWrkord();
        }


        public void SaveButton_Click()
        {
            // 저장 버튼 클릭 이벤트
            if (tabbedControlGroup1.SelectedTabPageIndex == 0)
            {
                if (iDATMessageBox.QuestionMessage("MSG_QS_PRD_002", this.Text) == System.Windows.Forms.DialogResult.Yes) //포장 등록하시겠습니까?
                    this.SetSerialPacking();
            }
            else if (tabbedControlGroup1.SelectedTabPageIndex == 1)
            {
                if (iDATMessageBox.QuestionMessage("MSG_QS_PRD_002", this.Text) == System.Windows.Forms.DialogResult.Yes) //포장 등록하시겠습니까?
                    this.SetBoxPacking();
            }
            else
            {
                if (gvList2.RowCount == 0)
                {
                    iDATMessageBox.ErrorMessage("MSG_ER_COMM_008", this.Text, 3); //S/N를 스캔(입력)하세요.
                    return;
                }

                if (iDATMessageBox.QuestionMessage("MSG_QS_PRD_003", this.Text) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (gcList2.Tag.ObjectNullString() == "UNBOXPACKING")
                        this.SetUnBOXPacking();
                    else
                        this.SetUnPacking();
                }
            }
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
            txtSerialBarcode.EnterMoveNextControl = false;
            txtUnpackBarcode.EnterMoveNextControl = false;
            GetPartNo();
            if (tabbedControlGroup1.SelectedTabPageIndex == 0)
            {
                this.GetSerialLine();

                InitControl_SerialPacking();
            }
            else if (tabbedControlGroup1.SelectedTabPageIndex == 1)
            {
                InitControl_BoxPacking();
            }
            else if (tabbedControlGroup1.SelectedTabPageIndex == 2)
            {
                this.GetQtyLine();

                InitControl_QtyPacking();
            }
            else
            {
                InitControl_UnPacking();
            }
        }

        private void InitControl_SerialPacking()
        {
            txtSerialBoxNo.EditValue = null;
            txtSerialPartNo.EditValue = null;
            txtSerialBoxQty.EditValue = null;
            txtSerialCurQty.EditValue = null;
            txtSerialPackQty.EditValue = null;
            txtEmptyBoxNo.EditValue = null;
            txtWeight.EditValue = null;
            spiEtcQty.EditValue = 0;

            gcList1.DataSource = null;
        }

        private void InitControl_BoxPacking()
        {
            txtBoxpackNo.EditValue = null;
            txtBoxpackPartNo.EditValue = null;
            txtBoxPackQty.EditValue = 0;

            gcList3.DataSource = null;
        }

        private void InitControl_QtyPacking()
        {
            
            txtQtyBoxNo.EditValue = "";
            txtQtyCurQty.EditValue = "0";
            
            spiQtyPackQty.EditValue = 0;
        }

        private void InitControl_UnPacking()
        {
            txtUnpackBarcode.EditValue = "";
            gcList2.Tag = "";
            gcList2.DataSource = null;
        }

        private void GetSerialLine()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleSerialLine
                                                       , "GPKGPRD_PROD.GET_PRODLINE"
                                                       , 2
                                                       , new string[] { 
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_TYPE" }
                                                       , new string[] { 
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , "PACKING" }
                                                       , "PRODLINE"
                                                       , "PRODLINENAME"
                                                       , "PRODLINE,PRODLINENAME,REMARKS"
                                                       );
        }

        private void GetQtyLine()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleQtyLine
                                                       , "GPKGPRD_PROD.GET_PRODLINE"
                                                       , 2
                                                       , new string[] { 
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_TYPE" }
                                                       , new string[] { 
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , "PACKING" }
                                                       , "PRODLINE"
                                                       , "PRODLINENAME"
                                                       , "PRODLINE,PRODLINENAME,REMARKS"
                                                       );
        }
        private void GetPartNo()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(glePartNo
                                                       , "GPKGPRD_PROD.GET_PARTNO"
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
                                                       , "ITEMCODE,PARTNO,SPEC"
                                                       );
        }
        private bool Check_Data(string p_sType)
        {
            LanguageInformation clsLan = new LanguageInformation();
            string sMsg = "";

            bool _bState = true;

            if (p_sType == "SERIALPACKING")
            {
                if (gleSerialLine.EditValue.ObjectNullString() == "")
                {
                    _bState = false;
                    sMsg += clsLan.GetMessageString("MSG_ER_LINE_004") + "\n"; //라인을 선택하세요.
                }

                if (gleSerialUnitNo.EditValue.ObjectNullString() == "")
                {
                    _bState = false;
                    sMsg += clsLan.GetMessageString("MSG_ER_PRD_051") + "\n"; //호기를 선택하세요.
                }
            }

            if (p_sType == "QTYPACKING")
            {
                if (gleQtyLine.EditValue.ObjectNullString() == "")
                {
                    _bState = false;
                    sMsg += clsLan.GetMessageString("MSG_ER_LINE_004") + "\n"; //라인을 선택하세요.
                }

                if (gleQtyUnitNo.EditValue.ObjectNullString() == "")
                {
                    _bState = false;
                    sMsg += clsLan.GetMessageString("MSG_ER_PRD_051") + "\n"; //호기를 선택하세요.
                }
                if (txtWrkOrd.EditValue.ObjectNullString() == "")
                {
                    _bState = false;
                    sMsg += clsLan.GetMessageString("MSG_ER_WO_018") + "\n"; //등록된 작업지시가 없습니다.
 
                }
            }

            if (_bState == false)
            {
                iDATMessageBox.WARNINGMessage(sMsg, this.Text, 3);
                return false;
            }
            else
                return true;
        }

        //개별(시리얼)포장 박스 정보
        private void GetBoxInfo_SerialPacking(string p_sType, string p_sData)
        {

            this.InitControl_SerialPacking();
            SplashScreenManager.ShowForm(typeof(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM), true, false);
            SplashScreenManager.Default.SendCommand(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM.WaitFormCommand.SetDescription, "Loading...");

            WSResults _result = BASE_db.Execute_Proc( "PKGPRD_PROD.GET_BOXNO"
                                                    , 1
                                                    , new string[] { 
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_TYPE"
                                                    , "A_BOXNO" }
                                                    , new string[] { 
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT
                                                    , p_sType
                                                    , p_sData }
                                                    );

            SplashScreenManager.CloseForm(true);

            if (_result.ResultInt == 0)
            {
                txtSerialBoxNo.EditValue = _result.ResultDataSet.Tables[0].Rows[0]["BOXNO"].ObjectNullString();
                txtSerialPartNo.EditValue = _result.ResultDataSet.Tables[0].Rows[0]["PARTNO"].ObjectNullString();
                txtSerialBoxQty.EditValue = _result.ResultDataSet.Tables[0].Rows[0]["BOXQTY"].ObjectNullString();
                txtSerialCurQty.EditValue = _result.ResultDataSet.Tables[0].Rows[0]["CURQTY"].ObjectNullString();

                this.AddProdSN_Packing(_result.ResultDataSet.Tables[1]);
            }
            else
            {
                iDATMessageBox.ErrorMessage(_result.ResultString, this.Text, 3);
            }
        }

        //박스 포장 정보
        private void GetBoxInfo_BoxPacking(string p_sType, string p_sData)
        {

            this.InitControl_SerialPacking();
            SplashScreenManager.ShowForm(typeof(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM), true, false);
            SplashScreenManager.Default.SendCommand(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM.WaitFormCommand.SetDescription, "Loading...");

            WSResults _result = BASE_db.Execute_Proc("PKGPRD_PROD.GET_BOXNO"
                                                    , 1
                                                    , new string[] { 
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_TYPE"
                                                    , "A_BOXNO" }
                                                    , new string[] { 
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT
                                                    , p_sType
                                                    , p_sData }
                                                    );

            SplashScreenManager.CloseForm(true);

            if (_result.ResultInt == 0)
            {
                txtBoxpackNo.EditValue = _result.ResultDataSet.Tables[0].Rows[0]["BOXNO"].ObjectNullString();
                txtBoxpackPartNo.EditValue = _result.ResultDataSet.Tables[0].Rows[0]["PARTNO"].ObjectNullString();
                txtBoxPackQty.EditValue = _result.ResultDataSet.Tables[0].Rows[0]["PACKQTY"].ObjectNullString();
             

                this.AddProdBOX_Packing(_result.ResultDataSet.Tables[1]);
            }
            else
            {
                iDATMessageBox.ErrorMessage(_result.ResultString, this.Text, 3);
            }
        }

        //수량포장 박스 정보
        private void GetBoxInfo_QtyPacking(string p_sType, string p_sData)
        {

            this.InitControl_QtyPacking();

            WSResults _result = BASE_db.Execute_Proc( "PKGPRD_PROD.GET_BOXNO"
                                                    , 2
                                                    , new string[] { 
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_PARTNO"
                                                    , "A_WRKORD"
                                                    , "A_BOXNO" }
                                                    , new string[] { 
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT
                                                    , txtQtyPartNo.EditValue.ObjectNullString()
                                                    , txtWrkOrd.EditValue.ObjectNullString()
                                                    , p_sData }
                                                    );

            if (_result.ResultInt == 0)
            {
                txtQtyBoxNo.EditValue = _result.ResultDataSet.Tables[0].Rows[0]["BOXNO"].ObjectNullString();
                txtQtyCurQty.EditValue = _result.ResultDataSet.Tables[0].Rows[0]["CURQTY"].ObjectNullString();

            }
            else
            {
                iDATMessageBox.ErrorMessage(_result.ResultString, this.Text, 3);
            }
        }

        //포장 해체 정보
        private void GetBoxInfo_UnPacking(string p_sData)
        {
            gcList2.DataSource = null;

            gcList2.Tag = "UNPACKING";

            BASE_DXGridHelper.Bind_Grid_Int( gcList2
                                           , "PKGPRD_PROD.GET_BOXNO"
                                           , 1
                                           , new string[] { 
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_TYPE"
                                           , "A_BOXNO" }
                                           , new string[] { 
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , "UNPACKING"
                                           , p_sData }
                                           , true
                                           , ""
                                           , false//true
                                           , "ITEMCODE,PACKQTY"
                                           );
        }

        //포장 해체 정보
        private void GetBoxInfo_UnBoxPacking(string p_sData)
        {
            gcList2.DataSource = null;

            gcList2.Tag = "UNBOXPACKING";

            BASE_DXGridHelper.Bind_Grid_Int(gcList2
                                           , "PKGPRD_PROD.GET_BOXNO"
                                           , 1
                                           , new string[] { 
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_TYPE"
                                           , "A_BOXNO" }
                                           , new string[] { 
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , "UNBOXPACKING"
                                           , p_sData }
                                           , true
                                           , ""
                                           , false//true
                                           , "ITEMCODE,PACKQTY"
                                           );
        }

        //수량(시리얼)포장 : 시리얼 조회
        private void GetProdInfo_SerialPacking(string p_sData)
        {
            LanguageInformation _clsLan = new LanguageInformation();
            string _sMsg;

            if (txtSerialBoxNo.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.ErrorMessage("MSG_ER_BOX_004", this.Text, 3); //Box 바코드를 스캔하세요.
                return;
            }

            if (Convert.ToInt32(txtSerialBoxQty.EditValue.ObjectNullString()) <= Convert.ToInt32(txtSerialCurQty.EditValue.ObjectNullString()))
            {
                iDATMessageBox.ErrorMessage("MSG_ER_PRD_066", this.Text, 3); //BOX 적입수량보다 많이 포장할 수 없습니다.
                return;
            }

            m_blCheck = false;

            WSResults _result = BASE_db.Execute_Proc( "PKGPRD_PROD.GET_SERIAL"
                                                    , 1
                                                    , new string[] { 
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_TYPE"
                                                    , "A_SERIAL"
                                                    , "A_BOXNO" }
                                                    , new string[] { 
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT
                                                    , "SERIALPACKING"
                                                    , p_sData
                                                    , txtSerialBoxNo.EditValue.ObjectNullString() }
                                                    );

            try
            {
                if (_result.ResultInt == 0)
                {
                    for (int i = 0; i < gvList1.RowCount; i++)
                    {
                        if (gvList1.GetRowCellValue(i, "SERIAL").ToString() == _result.ResultDataSet.Tables[0].Rows[0]["SERIAL"].ToString())
                        {
                            SoundPlayer _player = new SoundPlayer(HAENGSUNG_HNSMES_UI.Properties.Resources.error);
                            _player.Play();

                            _sMsg = "S/N : " + p_sData + "\r\n\r\n" + _clsLan.GetMessageString("MSG_ER_PRD_056");

                            //iDATMessageBox.MemoMessage(_sMsg, this.Text, out _sMsg);
                            iDATMessageBox.ErrorMessage(_sMsg, this.Text, 3);

                            if (Program.frmM.Scanner1.IsOpen == true)
                                Program.frmM.Scanner1.ReadExisting();
                            m_blCheck = true;

                            return;
                        }
                    }
                    
                    this.AddProdSN_Packing(_result.ResultDataSet.Tables[0]);
                }
                else
                {
                    SoundPlayer _player = new SoundPlayer(HAENGSUNG_HNSMES_UI.Properties.Resources.error);
                    _player.Play();

                    _sMsg = "S/N : " + p_sData + "\r\n\r\n" + _clsLan.GetMessageString(_result.ResultString);

                    iDATMessageBox.MemoMessage(_sMsg, this.Text, out _sMsg);
                    //iDATMessageBox.ErrorMessage(_sMsg, this.Text, 0);

                }
            }
            catch (Exception ex)
            {
                iDATMessageBox.ErrorMessage(ex, this.Text);
            }
            finally
            {
                if(Program.frmM.Scanner1.IsOpen == true)
                    Program.frmM.Scanner1.ReadExisting();
                m_blCheck = true;
            }
        }

        //박스(시리얼)포장 : 박스 조회
        private void GetProdInfo_BoxPacking(string p_sData)
        {
            LanguageInformation _clsLan = new LanguageInformation();
            string _sMsg;

            WSResults _result = BASE_db.Execute_Proc("PKGPRD_PROD.GET_BOXNO"
                                                    , 1
                                                    , new string[] { 
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_TYPE"
                                                    , "A_BOXNO" }
                                                    , new string[] { 
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT
                                                    , "ADDBOXPACKING"
                                                    , p_sData }
                                                    );

            try
            {
                if (_result.ResultInt == 0)
                {
                    for (int i = 0; i < gvList3.RowCount; i++)
                    {
                        if (gvList3.GetRowCellValue(i, "BOXNO").ToString() == _result.ResultDataSet.Tables[0].Rows[0]["BOXNO"].ToString())
                        {
                            SoundPlayer _player = new SoundPlayer(HAENGSUNG_HNSMES_UI.Properties.Resources.error);
                            _player.Play();

                            _sMsg = "S/N : " + p_sData + "\r\n\r\n" + _clsLan.GetMessageString("MSG_ER_PRD_056");

                            //iDATMessageBox.MemoMessage(_sMsg, this.Text, out _sMsg);
                            iDATMessageBox.ErrorMessage(_sMsg, this.Text, 3);

                            if (Program.frmM.Scanner1.IsOpen == true)
                                Program.frmM.Scanner1.ReadExisting();
                            m_blCheck = true;

                            return;
                        }
                    }

                    this.AddProdBOX_Packing(_result.ResultDataSet.Tables[0]);
                }
                else
                {
                    SoundPlayer _player = new SoundPlayer(HAENGSUNG_HNSMES_UI.Properties.Resources.error);
                    _player.Play();

                    _sMsg = "S/N : " + p_sData + "\r\n\r\n" + _clsLan.GetMessageString(_result.ResultString);

                    iDATMessageBox.MemoMessage(_sMsg, this.Text, out _sMsg);
                    //iDATMessageBox.ErrorMessage(_sMsg, this.Text, 0);

                }
            }
            catch (Exception ex)
            {
                iDATMessageBox.ErrorMessage(ex, this.Text);
            }
            finally
            {
                if (Program.frmM.Scanner1.IsOpen == true)
                    Program.frmM.Scanner1.ReadExisting();
                m_blCheck = true;
            }
        }

        private void AddProdSN_Packing(DataTable p_dtProdSN)
        {
            if (gvList1.RowCount == 0)
                gcList1.DataSource = p_dtProdSN;
            else
            {
                string _sProbYN = gvList1.GetRowCellValue(gvList1.RowCount - 1, "PROBYN").ToString();

                if(p_dtProdSN.Rows[0]["PROBYN"].ToString() != _sProbYN)
                {
                    SoundPlayer _player = new SoundPlayer(HAENGSUNG_HNSMES_UI.Properties.Resources.error);
                    if (_sProbYN == "Y")
                    {
                        _player.Play();
                        iDATMessageBox.ErrorMessage("MSG_ER_PRD_084", this.Text, 3); // 정상 제품입니다. 이상 LOT 제품과 함께 포장할 수 없습니다.
                    }
                    else
                    {
                        _player.Play();
                        iDATMessageBox.ErrorMessage("MSG_ER_PRD_083", this.Text, 3); // 이상 LOT로 등록된 제품입니다. 정상 제품과 함께 포장할 수 없습니다.
                    }

                    return;
                }

                if (int.Parse(txtSerialBoxQty.EditValue.ObjectNullString()) > (gcList1.DataSource as DataTable).Rows.Count)
                {
                    DataTable _dt = gcList1.DataSource as DataTable;

                    DataRow dRow = _dt.NewRow();

                    for (int nCol = 0; nCol < _dt.Columns.Count; nCol++)
                        dRow[nCol] = p_dtProdSN.Rows[0][nCol];

                    _dt.Rows.InsertAt(dRow, 0);
                    gcList1.DataSource = _dt;

                    gvList1.FocusedRowHandle = 0;
                }
                else
                {
                    iDATMessageBox.ErrorMessage("MSG_ER_PRD_066", this.Text, 3); // BOX 적입수량보다 많이 포장할 수 없습니다.
                }
            }


            DataRow[] _dr = (gcList1.DataSource as DataTable).Select("ENDFLAG = 'N'");

            txtSerialPackQty.EditValue = _dr.Length;

            spiEtcQty.EditValue = int.Parse(txtSerialBoxQty.EditValue.ObjectNullString()) -(int.Parse(txtSerialCurQty.EditValue.ObjectNullString()) + _dr.Length);

            gvList1.BestFitColumns();
        }

        private void AddProdBOX_Packing(DataTable p_dtProdBOX)
        {
            if (gvList3.RowCount == 0)
            {
                gcList3.DataSource = p_dtProdBOX;
            }
            else
            {
                DataTable _dt = gcList3.DataSource as DataTable;

                DataRow dRow = _dt.NewRow();

                for (int nCol = 0; nCol < _dt.Columns.Count; nCol++)
                    dRow[nCol] = p_dtProdBOX.Rows[0][nCol];

                _dt.Rows.InsertAt(dRow, 0);
                gcList3.DataSource = _dt;

                gvList3.FocusedRowHandle = 0;
            }

            gvList3.BestFitColumns();
        }

        //개별포장
        private void SetSerialPacking()
        {
            string _strXML = "";

            if (int.Parse(txtSerialBoxQty.EditValue.ObjectNullString()) < gvList1.RowCount)
            {
                iDATMessageBox.ErrorMessage("MSG_ER_BOX_006", this.Text, 3); //박스 적입수량을 초과했습니다.
                return;
            }

            if ((gcList1.DataSource as DataTable) != null && (gcList1.DataSource as DataTable).Rows.Count > 0)
            {
                DataTable _dt = (gcList1.DataSource as DataTable).Select("ENDFLAG = 'N'").CopyToDataTable();

                _strXML = GetDataTableToXml(_dt);
            }
            SplashScreenManager.ShowForm(typeof(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM), true, false);
            SplashScreenManager.Default.SendCommand(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM.WaitFormCommand.SetDescription, "saving...");

            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result =
                BASE_db.Execute_Proc( "PKGPRD_PROD.PUT_SERIALPACKING"
                                    , 2
                                    , new string[] { 
                                      "A_CLIENT"
                                    , "A_COMPANY"
                                    , "A_PLANT"
                                    , "A_TYPE"
                                    , "A_UNITNO"
                                    , "A_BOXNO"
                                    , "A_EMPTYBOXNO"
                                    , "A_ETCQTY"
                                    , "A_WEIGHT"
                                    , "A_XML"
                                    , "A_USER" }
                                    , new string[] {  
                                      Global.Global_Variable.CLIENT
                                    , Global.Global_Variable.COMPANY
                                    , Global.Global_Variable.PLANT
                                    , "SERIALPACKING"
                                    , gleSerialUnitNo.EditValue.ObjectNullString()
                                    , txtSerialBoxNo.EditValue.ObjectNullString()
                                    , txtEmptyBoxNo.EditValue.ObjectNullString()
                                    , "0"//spiEtcQty.EditValue.ObjectNullString()
                                    , txtWeight.EditValue.ObjectNullString()
                                    , _strXML
                                    , Global.Global_Variable.EHRCODE }
                                    );

            SplashScreenManager.CloseForm(true);

            if (_Result.ResultInt == 0)
            {
                Print(_Result.ResultDataSet.Tables[0], 1);

                iDATMessageBox.OKMessage("DBMSG_SUCCESS", this.Text, 3);
                this.InitControl_SerialPacking();
            }

        }
        //수량포장 작업지시 조회
        private void GetQtyPackingWrkord()
        {
            BASE_DXGridHelper.Bind_Grid_Int( gcList
                                           , "PKGPRD_PROD.GET_QTYPACK_WRKORD"
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
                                           , ""
                                           , false//true
                                           , "ITEMCODE,PLANQTY,PRODQTY"
                                           );
 
        }
        //박스포장
        private void SetBoxPacking()
        {
            string _strXML = "";

            if ((gcList3.DataSource as DataTable) != null && (gcList3.DataSource as DataTable).Rows.Count > 0)
            {
                DataTable _dt = (gcList3.DataSource as DataTable).Select("ENDFLAG = 'N'").CopyToDataTable();

                _strXML = GetDataTableToXml(_dt);
            }
            SplashScreenManager.ShowForm(typeof(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM), true, false);
            SplashScreenManager.Default.SendCommand(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM.WaitFormCommand.SetDescription, "saving...");

            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result =
                BASE_db.Execute_Proc("PKGPRD_PROD.PUT_BOXPACKING"
                                    , 1
                                    , new string[] { 
                                      "A_CLIENT"
                                    , "A_COMPANY"
                                    , "A_PLANT"
                                    , "A_BOXNO"
                                    , "A_XML"
                                    , "A_USER" }
                                    , new string[] {  
                                      Global.Global_Variable.CLIENT
                                    , Global.Global_Variable.COMPANY
                                    , Global.Global_Variable.PLANT
                                    , txtBoxpackNo.EditValue.ObjectNullString()
                                    , _strXML
                                    , Global.Global_Variable.EHRCODE }
                                    );

            SplashScreenManager.CloseForm(true);

            if (_Result.ResultInt == 0)
            {
                iDATMessageBox.OKMessage("DBMSG_SUCCESS", this.Text, 3);
                this.InitControl_BoxPacking();
            }

        }
        //수량포장
        private void SetQtyPacking()
        {
            int iBoxQty, iPackQty, iCurQty, iStockQty;

            int.TryParse(txtQtyBoxQty.EditValue.ObjectNullString(), out iBoxQty);
            int.TryParse(spiQtyPackQty.EditValue.ObjectNullString(), out iPackQty);
            int.TryParse(txtQtyCurQty.EditValue.ObjectNullString(), out iCurQty);
            int.TryParse(spiQtyStockQty.EditValue.ObjectNullString(), out iStockQty);

            /*재고수량 포장 수량 비교*/
            if (iStockQty < iPackQty)
            {
                iDATMessageBox.ErrorMessage("MSG_ER_STOCK_010", this.Text, 3); //재고수량이 부족합니다.
                return;
            }

            if (iBoxQty < iPackQty)
            {
                iDATMessageBox.ErrorMessage("MSG_ER_BOX_006", this.Text, 3); //박스 적입수량을 초과했습니다.
                return;
            }

            bool _bResult = BASE_db.Execute_Proc( "PKGPRD_PROD.SET_QTYPACKING"
                                                , 2
                                                , new string[] { 
                                                  "A_CLIENT"
                                                , "A_COMPANY"
                                                , "A_PLANT"
                                                , "A_WRKORD"
                                                , "A_PARTNO"
                                                , "A_UNITNO"
                                                , "A_BOXNO"
                                                , "A_QTY"
                                                , "A_USER" }
                                                , new string[] {  
                                                  Global.Global_Variable.CLIENT
                                                , Global.Global_Variable.COMPANY
                                                , Global.Global_Variable.PLANT
                                                , txtWrkOrd.EditValue.ObjectNullString()
                                                , txtQtyPartNo.EditValue.ObjectNullString()
                                                , gleQtyUnitNo.EditValue.ObjectNullString()
                                                , txtQtyBoxNo.EditValue.ObjectNullString()
                                                , spiQtyPackQty.EditValue.ObjectNullString()
                                                , Global.Global_Variable.EHRCODE }
                                                , true
                                                );

            if (_bResult == true)
            {
                iDATMessageBox.OKMessage("DBMSG_SUCCESS", this.Text, 3);
                this.InitControl_QtyPacking();

                txtQtyBarcode.EditValue = "";

                SearchButton_Click();
            }

        }
        //포장해체
        private void SetUnBOXPacking()
        {
            bool _bResult = BASE_db.Execute_Proc( "PKGPRD_PROD.SET_UNBOXPACKING"
                                                , 1
                                                , new string[] {
                                                  "A_CLIENT"
                                                , "A_COMPANY"
                                                , "A_PLANT"
                                                , "A_TYPE"
                                                , "A_BOXNO"
                                                , "A_USER" }
                                                , new string[] {  
                                                  Global.Global_Variable.CLIENT
                                                , Global.Global_Variable.COMPANY
                                                , Global.Global_Variable.PLANT
                                                , "UNBOXPACKING"
                                                , gvList2.GetRowCellValue(0, "BOXNO").ToString()
                                                , Global.Global_Variable.EHRCODE }
                                                , true );

            if (_bResult == true)
            {
                iDATMessageBox.OKMessage("DBMSG_SUCCESS", this.Text, 3);
                this.InitControl_UnPacking();
            }

        }
        //포장해체
        private void SetUnPacking()
        {
            bool _bResult = BASE_db.Execute_Proc("PKGPRD_PROD.SET_UNPACKING"
                                                , 1
                                                , new string[] {
                                                  "A_CLIENT"
                                                , "A_COMPANY"
                                                , "A_PLANT"
                                                , "A_TYPE"
                                                , "A_BOXNO"
                                                , "A_USER" }
                                                , new string[] {  
                                                  Global.Global_Variable.CLIENT
                                                , Global.Global_Variable.COMPANY
                                                , Global.Global_Variable.PLANT
                                                , "UNPACKING"
                                                , gvList2.GetRowCellValue(0, "BOXNO").ToString()
                                                , Global.Global_Variable.EHRCODE }
                                                , true);

            if (_bResult == true)
            {
                iDATMessageBox.OKMessage("DBMSG_SUCCESS", this.Text, 3);
                this.InitControl_UnPacking();
            }

        }
        #endregion

        #region Control Event

        private void gleSerialLine_EditValueChanged(object sender, EventArgs e)
        {
            if (gleSerialLine.EditValue == null)
            {
                gleSerialUnitNo.Properties.DataSource = null;
                return;
            }

            // 개별(시리얼)포장 호기 정보 조회
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleSerialUnitNo
                                                       , "GPKGPRD_PROD.GET_TYPE_UNITNO"
                                                       , 1
                                                       , new string[] { 
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_TYPE"
                                                       , "A_PRODLINE" }
                                                       , new string[] { 
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , "PACKING"
                                                       , gleSerialLine.EditValue.ObjectNullString() }
                                                       , "UNITNO"
                                                       , "UNITNM"
                                                       , "UNITNO,UNITNM, REMARKS");

            this.InitControl_SerialPacking();
        }

        private void gleQtyLine_EditValueChanged(object sender, EventArgs e)
        {
            if (gleQtyLine.EditValue == null)
            {
                gleSerialUnitNo.Properties.DataSource = null;
                return;
            }

            // 개별(시리얼)포장 호기 정보 조회
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleQtyUnitNo
                                                       , "GPKGPRD_PROD.GET_TYPE_UNITNO"
                                                       , 1
                                                       , new string[] { 
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_TYPE"
                                                       , "A_PRODLINE" }
                                                       , new string[] { 
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , "PACKING"
                                                       , gleQtyLine.EditValue.ObjectNullString() }
                                                       , "UNITNO"
                                                       , "UNITNM"
                                                       , "UNITNO,UNITNM, REMARKS");

            this.InitControl_QtyPacking();
        }

        private void gleUnitNo_EditValueChanged(object sender, EventArgs e)
        {
            this.InitControl_SerialPacking();
        }

        private void txtSerialBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSerialBarcode.Text.Trim() == "")
                    return;

                this.Get_BarcodeType(txtSerialBarcode.Text);

                txtSerialBarcode.Text = "";

            }
        }
        private void txtBoxpackSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBoxpackSerial.Text.Trim() == "")
                    return;

                this.Get_BarcodeType(txtBoxpackSerial.Text);

                txtBoxpackSerial.Text = "";

            }
        }
        private void txtQtyBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtQtyBarcode.EditValue.ObjectNullString() == "")
                    return;

                this.Get_BarcodeType(txtQtyBarcode.EditValue.ObjectNullString());
            }
        }

        private void idatDxTextEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.Get_BarcodeType(idatDxTextEdit1.EditValue.ObjectNullString());
        }

        private void txtUnpackBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtUnpackBarcode.Text.Trim() == "")
                    return;

                gcList2.Tag = "";

                this.Get_BarcodeType(txtUnpackBarcode.EditValue.ObjectNullString());

                txtUnpackBarcode.EditValue = "";
                txtUnpackBarcode.Focus();
            }
        }

        private void tabbedControlGroup1_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            InitForm();
        }

        #endregion

        private void gvList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            InitControl_QtyPacking();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result =
                BASE_db.Execute_Proc("PKGPRD_PROD.SET_BOXSNINFO"
                                    , 1
                                    , new string[] { 
                                      "A_CLIENT"
                                    , "A_COMPANY"
                                    , "A_PLANT"
                                    , "A_BOXTYPE"
                                    , "A_ITEMCODE"
                                    , "A_WHLOC"
                                    , "A_QTY"
                                    , "A_USER" }
                                    , new object[] { 
                                      Global.Global_Variable.CLIENT
                                    , Global.Global_Variable.COMPANY
                                    , Global.Global_Variable.PLANT
                                    , "P"
                                    , glePartNo.EditValue.ObjectNullString()
                                    , "LOC002"
                                    , 1
                                    , Global.Global_Variable.EHRCODE }
                                    );

            if (_Result.ResultInt == 0)
            {
                ProcessScanEvent("BOXNO", _Result.ResultDataSet.Tables[0].Rows[0]["BOXNO"].ObjectNullString());
            }
            else
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
        }
        private bool Print(DataTable dTable, int nCopies)
        {
            using (RPT.RPTA205 _rpt = new RPT.RPTA205(dTable, nCopies))
            {
                _rpt.RptPrint();
            }
            /*태국법인 포장 박스 라벨*/
            //using (RPT.RPTA208 _rpt = new RPT.RPTA208(dTable, nCopies))
            //{
            //    _rpt.RptPrint();
            //}
            return true;
        }

        

    }
}
