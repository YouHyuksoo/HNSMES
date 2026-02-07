using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

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
    ///    화면명 : PRDA213<br/>
    ///      기능 : 육안검사 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    public partial class PRDA213 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
    {
        public PRDA213()
        {
            InitializeComponent();
        }

        private void PRDA213_Load(object sender, EventArgs e)
        {

        }

        private void PRDA213_Shown(object sender, EventArgs e)
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
                    gleUnitNo.EditValue = sData;
                    break;

                case "DEFECT":
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
                    break;

                case "ENTER":
                    Set_VisualInspection();
                    break;

                case "WORKER":
                    gleWorker.EditValue = sData;
                    break;

                case "PRODSN":
                    if (txtSerial.EditValue.ObjectNullString() == "")
                    {
                        txtSerial.EditValue = sData;
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
                        Set_VisualInspection();
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

        private void GetInspectionList()
        {
            WSResults _Result = BASE_db.Execute_Proc( "PKGPRD_CURRENT.GET_VISUAL_INSPECTION"
                                                    , 3
                                                    , new string[] { 
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_WRKORD"
                                                    , "A_PRODLINE"
                                                    , "A_UNITNO" }
                                                    , new object[] { 
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT 
                                                    , gleUnitNo.EditValue.ObjectNullString() }
                                                    );

            if (_Result.ResultInt == 0)
            {
                if (_Result.ResultDataSet.Tables[0].Rows.Count > 0)
                {
                    txtTotalStatus.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["TOTALSTATUS"].ObjectNullString();
                    txtUnitStatus.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["UNITSTATUS"].ObjectNullString();
                    txtGQty.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["GOODQTY"].ObjectNullString();
                    txtNQty.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["NGQTY"].ObjectNullString();

                    txtTotalNGStatus.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["TOTALNGSTATUS"].ObjectNullString();
                    txtTotalNGRate.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["TOTALDRATE"].ObjectNullString();
                    txtUnitNGStatus.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["UNITNGSTATUS"].ObjectNullString();
                    txtUnitNGRate.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["UNITDRATE"].ObjectNullString();
                }
            }
            else
            {
                
            }
        }
        private void InitForm()
        {
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
                                                       , "2"}
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
                                                    , 2
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
                                                    , "A_USER" }
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
                                                    , gleWorker.EditValue.ObjectNullString() }
                                                    );

            if (_Result.ResultInt == 0)
            {
                gleDefect.EditValue = null;
                gleDefect2.EditValue = null;
                gleDefect3.EditValue = null;
                gleDefect4.EditValue = null;
                gleDefect5.EditValue = null;
                txtSerial.EditValue = null;

                if (_Result.ResultDataSet.Tables[0].Rows.Count > 0)
                {
                    glePartNo.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["ITEMCODE"].ObjectNullString();

                    txtTotalStatus.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["TOTALSTATUS"].ObjectNullString();
                    txtUnitStatus.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["UNITSTATUS"].ObjectNullString();

                    if (int.Parse(_Result.ResultDataSet.Tables[0].Rows[0]["GOODQTY"].ObjectNullString()) <= 0)
                        txtGQty.EditValue = txtGQty.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["GOODQTY"].ObjectNullString();
                    else
                        txtGQty.EditValue = string.Format("{0:#,###}", int.Parse(_Result.ResultDataSet.Tables[0].Rows[0]["GOODQTY"].ObjectNullString()));

                    if (int.Parse(_Result.ResultDataSet.Tables[0].Rows[0]["NGQTY"].ObjectNullString()) <= 0)
                        txtNQty.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["NGQTY"].ObjectNullString();
                    else
                        txtNQty.EditValue = string.Format("{0:#,###}", int.Parse(_Result.ResultDataSet.Tables[0].Rows[0]["NGQTY"].ObjectNullString()));

                    txtTotalNGStatus.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["TOTALNGSTATUS"].ObjectNullString();
                    txtTotalNGRate.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["TOTALDRATE"].ObjectNullString();
                    txtUnitNGStatus.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["UNITNGSTATUS"].ObjectNullString();
                    txtUnitNGRate.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["UNITDRATE"].ObjectNullString();
                    
                    GetGridViewList(_Result.ResultDataSet.Tables[1]);
                }

                if (_strJudge == "Y")
                {
                    lblStatus.Text = " [ " + DateTime.Now.ToString("HH:mm:ss") + " ] " + "OK";
                    lblStatus.ForeColor = Color.LimeGreen;
                }
                else
                {
                    lblStatus.Text = " [ " + DateTime.Now.ToString("HH:mm:ss") + " ] " + "NG";
                    lblStatus.ForeColor = Color.Red;
                }
            }
            else
            {
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
            }
           
        }
        private void GetGridViewList(DataTable dt)
        {
            BASE_DXGridHelper.Bind_Grid(gcList
                                       , dt);

            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();
        }
        private void btnInit_Click(object sender, EventArgs e)
        {
            gleDefect.EditValue = null;
            gleDefect2.EditValue = null;
            gleDefect3.EditValue = null;
            gleDefect4.EditValue = null;
            gleDefect5.EditValue = null;
            txtSerial.EditValue = null;

            lblStatus.Text = "";
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {
            //ProcessScanEvent("PRODSN", "HST2019060301803");
        }

        
    }
}