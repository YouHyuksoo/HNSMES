#pragma warning disable IDE1006 // Naming Styles
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Printing;

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

namespace HAENGSUNG_HNSMES_UI.Forms.PRD
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : PRDA216<br/>
    ///      기능 : 육안검사 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    public partial class PRDA216 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
    {
        private Thread t = null;
        private delegate void SetThreadCallback();

        public PRDA216()
        {
            InitializeComponent();
        }

        private void PRDA216_Load(object sender, EventArgs e)
        {

        }

        private void PRDA216_Shown(object sender, EventArgs e)
        {
            InitForm();
        }

        #region 버튼이벤트

        public void InitButton_Click()
        {
            // 초기화 관련 구현은 여기에 구현 ***
            // 상세 항목들을 모두 클리어 한다.
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);


        }

        public void NewButton_Click()
        {
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New);

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

        }
        public void RefreshButton_Click()
        {

        }

        public void PrintButton_Click()
        {

        }
        public void DeleteButton_Click()
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           

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
            LanguageInformation clsLan = new LanguageInformation();
            string sMsg;

            switch (sType)
            {
                case "UNITNO":
                    if (btnProdReady.Appearance.BackColor == Color.LawnGreen)
                    {
                        gleUnitNo.EditValue = sData;
                    }
                    break;

                case "DEFECT":
                    if (btnInspection.Appearance.BackColor == Color.LawnGreen)
                    {
                        if (gleDefect.EditValue.ObjectNullString() == "")
                            gleDefect.EditValue = sData;
                        else if (gleDefect2.EditValue.ObjectNullString() == "")
                            gleDefect2.EditValue = sData;
                        else if (gleDefect3.EditValue.ObjectNullString() == "")
                            gleDefect3.EditValue = sData;
                        else if (gleDefect4.EditValue.ObjectNullString() == "")
                            gleDefect4.EditValue = sData;
                        else
                            gleDefect5.EditValue = sData;
                    }
                    break;

                case "ENTER":
                    if (btnInspection.Appearance.BackColor == Color.LawnGreen)
                    {
                        Set_VisualInspection();
                    }
                    break;

                case "WORKER":
                    if (btnProdReady.Appearance.BackColor == Color.LawnGreen)
                    {
                        if (gleWorker.EditValue.ObjectNullString() == "")
                            gleWorker.EditValue = sData;
                        else
                            gleWorker2.EditValue = sData;
                    }
                    break;

                case "PRODSN":
                    if (btnInspection.Appearance.BackColor == Color.LawnGreen)
                    {
                        //if (sData.Length > 16) sData = sData.Substring(sData.Length - 16, 16);

                        if (txtSerial.EditValue.ObjectNullString() == "")
                        {
                            txtSerial.EditValue = sData;

                            Check_PartNo();

                            lblStatus.ForeColor = Color.White;
                            lblStatus.Text = "Inspecting...";
                        }
                        else
                        {
                            if (txtSerial.EditValue.ObjectNullString() != sData)
                            {
                                iDATMessageBox.ErrorMessage("MSG_ER_COMM_032", this.Text, 3); //사용가능한 바코드가 아닙니다.
                                return;
                            }
                            Check_PartNo();
                            Set_VisualInspection();
                        }
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
        
        private void InitForm()
        {
            /*버튼 컨트롤 설정*/
            btnProdReady.LookAndFeel.UseDefaultLookAndFeel = false;
            btnProdReady.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            
            //btnHistory.LookAndFeel.UseDefaultLookAndFeel = false;
            //btnHistory.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;

            btnInspection.LookAndFeel.UseDefaultLookAndFeel = false;
            btnInspection.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;

            SetButton(btnProdReady, null);

            if (Global.Global_Variable.USER_ID == "SYSOPER")
            {
                gleUnitNo.Properties.ReadOnly = false;
                txtSerial.Properties.ReadOnly = false;
            }

            /*불량 코드 정보*/
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleDefect
                                                       , "GPKGPRD_PROD.GET_DEFECT"
                                                       , 2
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT" 
                                                       , "A_DEFECTTYPE"}
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , "6"}
                                                       , "DEFECT"
                                                       , "DEFECTNAME"
                                                       , "DEFECT, DEFECTNAME"
                                                       );

            DataTable dt = (gleDefect.Properties.DataSource as DataTable).Copy();
            dt.Rows[0].Delete();
            dt.AcceptChanges();

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleDefect2
                                                       , dt.Copy()
                                                       , "DEFECT"
                                                       , "DEFECTNAME"
                                                       , "DEFECT, DEFECTNAME"
                                                       );

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleDefect3
                                                       , dt.Copy()
                                                       , "DEFECT"
                                                       , "DEFECTNAME"
                                                       , "DEFECT, DEFECTNAME"
                                                       );

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleDefect4
                                                       , dt.Copy()
                                                       , "DEFECT"
                                                       , "DEFECTNAME"
                                                       , "DEFECT, DEFECTNAME"
                                                       );

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleDefect5
                                                       , dt.Copy()
                                                       , "DEFECT"
                                                       , "DEFECTNAME"
                                                       , "DEFECT, DEFECTNAME"
                                                       );

            /*설비 호기 정보*/
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleUnitNo
                                                       , "GPKGPRD_PROD.GET_TYPE_UNITNO"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_TYPE"
                                                       , "A_PRODLINE"}
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , ""
                                                       , this.Tag.ObjectNullString()}
                                                       , "UNITNO"
                                                       , "UNITNM"
                                                       , "UNITNO, UNITNM, REMARKS"
                                                       );

            /*작업자 정보*/
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWorker
                                                       , "GPKGPRD_PROD.GET_WORKER"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT }
                                                       , "USERID"
                                                       , "USERNAME"
                                                       , "USERID, USERNAME"
                                                       );

            DataTable dtWorker = (gleWorker.Properties.DataSource as DataTable).Copy();
            dtWorker.Rows[0].Delete();
            dtWorker.AcceptChanges();

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWorker2
                                                       , dtWorker
                                                       , "USERID"
                                                       , "USERNAME"
                                                       , "USERID, USERNAME"
                                                       );

            /*품번 정보*/
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( glePartNo
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
                                                       , "ITEMCODE, PARTNO, SPEC"
                                                       );
            
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(glePartNoCheck
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
                                                       , "ITEMCODE, PARTNO, SPEC"
                                                       );


        }
        private void SetButton(object sender, EventArgs e)
        {
            IDAT.Devexpress.DXControl.IdatDxSimpleButton btn = sender as IDAT.Devexpress.DXControl.IdatDxSimpleButton;

            btn.Appearance.Options.UseBackColor = true;

            if (btn.Name != "btnProdReady")
            {
                if (Global.Global_Variable.EHRCODE != "SYSOPER")
                {

                    if (gleUnitNo.EditValue.ObjectNullString() == "")
                    {
                        iDATMessageBox.WARNINGMessage("MSG_ER_EQP_001", this.Text, 3); //설비를 선택하세요.
                        return;
                    }
                    if (gleWorker.EditValue.ObjectNullString() == "")
                    {
                        iDATMessageBox.WARNINGMessage("MSG_ER_PRD_098", this.Text, 3); //실작업자 선택하세요.
                        return;
                    }

                }
                gleUnitNo.Properties.ReadOnly = true;
                gleWorker.Properties.ReadOnly = true;
                gleWorker2.Properties.ReadOnly = true;
                    
            }
            else
            {
                gleUnitNo.Properties.ReadOnly = false;
                gleWorker.Properties.ReadOnly = false;
                gleWorker2.Properties.ReadOnly = false;
                
            }

            lcgInspHistory.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcgWorkManual.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            switch (btn.Name)
            {
                case "btnProdReady": //작업준비
                    btnProdReady.Appearance.BackColor = Color.LawnGreen;
                    //btnHistory.Appearance.BackColor = Color.Transparent;
                    btnInspection.Appearance.BackColor = Color.Transparent;
                    
                    tpProdReady.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    tpInspection.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    
                    break;

                case "btnHistory": //작업이력

                    lcgInspHistory.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lcgWorkManual.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                    btnProdReady.Appearance.BackColor = Color.Transparent;
                    //btnHistory.Appearance.BackColor = Color.LawnGreen;
                    btnInspection.Appearance.BackColor = Color.Transparent;

                    tpProdReady.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    tpInspection.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                    break;

                case "btnInspection": //검사모드

                    btnProdReady.Appearance.BackColor = Color.Transparent;
                    //btnHistory.Appearance.BackColor = Color.Transparent;
                    btnInspection.Appearance.BackColor = Color.LawnGreen;
                    
                    tpProdReady.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    tpInspection.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    
                    break;
            }

            
        }
      
        private void Check_PartNo()
        {           
            WSResults _Result = BASE_db.Execute_Proc("PKGPRD_CURRENT.CHK_PARTNO"
                                                    , 1
                                                    , new string[] { 
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_SERIAL"
                                                    , "A_ITEMCODE"}
                                                    , new object[] { 
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT 
                                                    , txtSerial.EditValue.ObjectNullString()
                                                    , glePartNoCheck.EditValue.ObjectNullString()}
                                                    );

            if (_Result.ResultInt != 0)            
            {
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
                txtSerial.EditValue = null;
                return;
            }
        }

        /*육안 검사 실적 저장*/
        private void Set_VisualInspection()
        {
            string _strJudge = "Y";

            if (gleUnitNo.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.ErrorMessage("MSG_ER_PRD_051", this.Text, 3); //호기를 선택하세요.
                return;
            }

            if (gleWorker.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_PRD_098", this.Text, 3); //실작업자 선택하세요.
                return;
            }

            if (gleDefect.EditValue.ObjectNullString() != "") _strJudge = "N";


            WSResults _Result = BASE_db.Execute_Proc( "PKGPRD_CURRENT.SET_VISUAL_INSPECTION"
                                                    , 3
                                                    , new string[] { 
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_UNITNO"
                                                    , "A_SERIAL"
                                                    , "A_JUDGE"
                                                    , "A_DEFECT"
                                                    , "A_DEFECT2"
                                                    , "A_DEFECT3"
                                                    , "A_DEFECT4"
                                                    , "A_DEFECT5"
                                                    , "A_USER"
                                                    , "A_USER2"}
                                                    , new object[] { 
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT 
                                                    , gleUnitNo.EditValue.ObjectNullString()
                                                    , txtSerial.EditValue.ObjectNullString()
                                                    , _strJudge
                                                    , gleDefect.EditValue.ObjectNullString()
                                                    , gleDefect2.EditValue.ObjectNullString()
                                                    , gleDefect3.EditValue.ObjectNullString()
                                                    , gleDefect4.EditValue.ObjectNullString()
                                                    , gleDefect5.EditValue.ObjectNullString()
                                                    , gleWorker.EditValue.ObjectNullString()
                                                    , gleWorker2.EditValue.ObjectNullString()}
                                                    );

            if (_Result.ResultInt == 0)
            {
                gleUnitNo.Tag = _Result.ResultString;

                if (_strJudge == "Y")
                {
                    lblStatus.Text = " [ " + DateTime.Now.ToString("HH:mm:ss") + " ] " + "OK";
                    lblStatus.ForeColor = Color.LimeGreen;
                }
                else
                {
                    lblStatus.Text = " [ " + DateTime.Now.ToString("HH:mm:ss") + " ] " + "NG";
                    lblStatus.ForeColor = Color.Red;

                    var dr1 = from row in (gleDefect.Properties.DataSource as DataTable).AsEnumerable()
                             where row.Field<string>("DEFECT") == gleDefect.EditValue.ObjectNullString()
                             select row;

                    var dr2 = from row in (gleDefect2.Properties.DataSource as DataTable).AsEnumerable()
                              where row.Field<string>("DEFECT") == gleDefect2.EditValue.ObjectNullString()
                             select row;

                    var dr3 = from row in (gleDefect3.Properties.DataSource as DataTable).AsEnumerable()
                              where row.Field<string>("DEFECT") == gleDefect3.EditValue.ObjectNullString()
                             select row;

                    DataTable dtSelected1 = null;
                    DataTable dtSelected2 = null;
                    DataTable dtSelected3 = null;

                    if (gleDefect.EditValue.ObjectNullString() != "") dtSelected1 = dr1.CopyToDataTable();
                    if (gleDefect2.EditValue.ObjectNullString() != "") dtSelected2 = dr2.CopyToDataTable();
                    if (gleDefect3.EditValue.ObjectNullString() != "") dtSelected3 = dr3.CopyToDataTable();
                    
                    string _defect = string.Empty;
                    string _defect1 = string.Empty;
                    string _defect2 = string.Empty;

                    if (dtSelected1 != null && dtSelected1.Rows.Count > 0) _defect = dtSelected1.Rows[0]["DEFECTNAME"].ObjectNullString();

                    if (dtSelected2 != null && dtSelected2.Rows.Count > 0) _defect1 = dtSelected2.Rows[0]["DEFECTNAME"].ObjectNullString();

                    if (dtSelected3 != null && dtSelected3.Rows.Count > 0) _defect2 = dtSelected3.Rows[0]["DEFECTNAME"].ObjectNullString();

                    //NG 라벨 인쇄. 동방에서는 쓰지 않기 때문에 주석처리
                    /*
                    Print4(_Result.ResultDataSet.Tables[0]
                          , _defect
                          , _defect1
                          , _defect2
                          , 1); //NG
                    */
                }

                gleDefect.EditValue = null;
                gleDefect2.EditValue = null;
                gleDefect3.EditValue = null;
                gleDefect4.EditValue = null;
                gleDefect5.EditValue = null;
                txtSerial.EditValue = null;
                //glePartNoCheck.EditValue = null;

                timerThread.Enabled = true;
            }
            else
            {
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
            }
            
            
        }
        private void GetBackgroundProcess()
        {
            if (this.InvokeRequired)
            {
                var d = new SetThreadCallback(GetBackgroundProcess);
                this.Invoke(d, new object[] { });
            }
            else
            {
                try
                {
                    WSResults _Result = BASE_db.Execute_Proc( "PKGPRD_CURRENT.GET_PROD_PRODQTY"
                                                            , 3
                                                            , new string[] { 
                                                              "A_CLIENT"
                                                            , "A_COMPANY"
                                                            , "A_PLANT"
                                                            , "A_WRKORD"
                                                            , "A_UNITNO" }
                                                            , new object[] { 
                                                              Global.Global_Variable.CLIENT
                                                            , Global.Global_Variable.COMPANY
                                                            , Global.Global_Variable.PLANT 
                                                            , gleUnitNo.Tag.ObjectNullString()
                                                            , gleUnitNo.EditValue.ObjectNullString() }
                                                            );

                    
                    if (_Result.ResultInt == 0)
                    {
                        if (_Result.ResultDataSet.Tables[0].Rows.Count > 0)
                        {
                            if (glePartNo.EditValue.ObjectNullString() != _Result.ResultDataSet.Tables[0].Rows[0]["ITEMCODE"].ObjectNullString())
                            {
                                try
                                {
                                    if (_Result.ResultDataSet.Tables[0].Rows[0]["VISUALIMAGE"].ObjectNullString().Length > 0)
                                    {
                                        var data = (Byte[])_Result.ResultDataSet.Tables[0].Rows[0]["VISUALIMAGE"];

                                        if (data != null)
                                        {
                                            var stream = new MemoryStream(data);
                                            idatDxPictureEdit1.Image = Image.FromStream(stream);
                                        }
                                    }
                                }
                                catch { }
                            }

                            glePartNo.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["ITEMCODE"].ObjectNullString();

                            txtUnitQty.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["UNITQTY"].ObjectNullString();
                            spiUnitPQty.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["UNITPASSQTY"].ObjectNullString();
                            spiUnitNQty.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["UNITNGQTY"].ObjectNullString();
                            spiUnitPPM.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["UNITPPM"].ObjectNullString();
                            spiUnitTarget.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["UNITTARGETUPH"].ObjectNullString();
                            spiUnitResult.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["UNITRESULTUPH"].ObjectNullString();

                            txtTotalQty.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["TOTALQTY"].ObjectNullString();
                            spiTotalPQty.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["TOTALPASSQTY"].ObjectNullString();
                            spiTotalNQty.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["TOTALNGQTY"].ObjectNullString();
                            spiTotalPPM.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["TOTALPPM"].ObjectNullString();
                            spiTotalTarget.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["TOTALTARGETUPH"].ObjectNullString();
                            spiTotalResult.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["TOTALRESULTUPH"].ObjectNullString();

                        }
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    t.Abort();
                    t = null;
                }
            }
        }
        private void GetGridViewList(DataTable dt)
        {
            BASE_DXGridHelper.Bind_Grid(gcList
                                       , dt);

            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {
            //ProcessScanEvent("PRODSN", "HST2019060301803");
        }

        private void btnSerialReset_Click(object sender, EventArgs e)
        {
            txtSerial.EditValue = null;

            lblStatus.Text = "";
        }

        private void btnNGReset_Click(object sender, EventArgs e)
        {
            gleDefect.EditValue = null;
            gleDefect2.EditValue = null;
            gleDefect3.EditValue = null;
            gleDefect4.EditValue = null;
            gleDefect5.EditValue = null;
        }

        private void layoutControlItem5_Click(object sender, EventArgs e)
        {
            ProcessScanEvent("UNITNO", "VISUAL#6");
        }

        private void layoutControlItem2_Click(object sender, EventArgs e)
        {
            //ProcessScanEvent("PRODSN", "HST2019070101496");
            /*
            gleUnitNo.EditValue = "VISUAL#6";
            txtSerial.EditValue = "HST2019092507626";
            gleDefect.EditValue = "D037";
            */
            Set_VisualInspection();
        }

        private void timerThread_Tick(object sender, EventArgs e)
        {
            timerThread.Enabled = false;

            if (t == null)
            {
                t = new Thread(new ThreadStart(GetBackgroundProcess));
                t.Start();
            }
        }
        //NG
        private bool Print4(DataTable dTable, string nDefectNm, string nDefectNm1, string nDefectNm2, int nCopies)
        {
            string strPrint = GetDefaultPrinter();

            if (strPrint.ObjectNullString() != "")
            {
                using (RPT.RPTA211 _rpt = new RPT.RPTA211(dTable, nDefectNm, nDefectNm1, nDefectNm2, nCopies))
                {
                    _rpt.RptPrint(strPrint);
                }
            }
            return true;
        }

        string GetDefaultPrinter()
        {
            PrinterSettings settings = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                settings.PrinterName = printer;
                if (settings.IsDefaultPrinter)   // 기본 설정 여부
                    return printer;
            }
            return string.Empty;
        }

        private void txtSerial_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}