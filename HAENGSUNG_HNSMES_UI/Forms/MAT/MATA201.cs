using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

// DevExpress namespace
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views;

// User namespace
using HAENGSUNG_HNSMES_UI.Class;
using GridAlias = DevExpress.XtraGrid.Views.Grid;


namespace HAENGSUNG_HNSMES_UI.Forms.MAT
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : MATA201<br/>
    ///      기능 : IQC 등록 <br/>
    ///      작성 : HS<br/>
    ///최초작성일 : 2016-04-14<br/>
    ///  수정사항 : 2016-04-18 프로그램 최초 구현<br/>
    ///==========================================================
    ///</summary>
    ///

    public partial class MATA201 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
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

        public MATA201()
        {
            InitializeComponent();
        }


        private void Form_Load(object sender, EventArgs e)
        {
            // 최초 폼 로드 시 발생 이벤트            
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
            MainButton_INIT.PerformClick();
            InitForm();
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
        }

        #endregion


        #region [Button Event]

        public void InitButton_Click()
        {
            // 초기화 관련 구현은 여기에 구현 ***
            // 상세 항목들을 모두 클리어 한다.
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);
            //GetPartNo();
            //GetVendor();
            //GetGridViewList();
            //GetIQCList();
        }

        public void DeleteButton_Click()
        {
            // 삭제 관련 구현은 아래에 구현 ***
        }

        public void NewButton_Click()
        {
            // 신규 관련 구현은 여기에 구현.

            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New);

            // 그리드뷰에 새로운 행과 초기값을 지정한다.
            //gvList.EX_AddNewRow();
           
        }

        public void EditButton_Click()
        {
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit);
        }

        public void StopButton_Click()
        {
            // 정지 관련 구현은 여기에 구현 ***
        }

        public void SearchButton_Click()
        {
             GetGridViewList();
        }

        public void SaveButton_Click()
        {

            if (tabbedControlGroup1.SelectedTabPageIndex == 0)
                this.SaveIqc();
            else if (tabbedControlGroup1.SelectedTabPageIndex == 1)
                this.Save_Cancel();
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


        #endregion


        #region [Private Method]
        /*초기화 함수*/
        private void InitForm()
        {
            tabbedControlGroup1.SelectedTabPageIndex = 0;
            rdgUseFlag.SelectedIndex = 0;
            
            
        }
        

        /*IQC 이력 조회 함수*/
        private void GetIQCList()
        {
            BASE_DXGridHelper.Bind_Grid_Int( gcList1
                                           , "PKGMAT_INOUT.GET_IQC_SERIAL"
                                           , 1
                                           , new string[] { 
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_PRTDATE"
                                           , "A_ITEMCODE"}
                                           , new string[] {
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , gvList.GetRowCellValue(gvList.FocusedRowHandle, "PRINTDATE").ObjectNullString()
                                           , gvList.GetRowCellValue(gvList.FocusedRowHandle, "ITEMCODE").ObjectNullString() }
                                           , true
                                           , ""
                                           , false
                                           , "QTY"
                                           );
            
            gvList1.OptionsView.ColumnAutoWidth = false;
            gvList1.BestFitColumns();
        }

        /*IQC 목록 조회*/
        private void GetGridViewList()
        {
            if (tabbedControlGroup1.SelectedTabPageIndex == 0)
            {
                gcList.DataSource = null;
                gcList1.DataSource = null;

                BASE_DXGridHelper.Bind_Grid_Int( gcList
                                               , "PKGMAT_INOUT.GET_ORDER"
                                               , 2
                                               , new string[] {  
                                                 "A_CLIENT"
                                               , "A_COMPANY"
                                               , "A_PLANT"
                                               , "A_SDATE"
                                               , "A_EDATE" }
                                               , new string[] { 
                                                 Global.Global_Variable.CLIENT
                                               , Global.Global_Variable.COMPANY
                                               , Global.Global_Variable.PLANT
                                               , dteFromTo1.StartDate
                                               , dteFromTo1.EndDate }
                                               , true
                                               , ""
                                               , false
                                               , "QTY,ITEMCODE"
                                               );
                
                gvList.OptionsView.ColumnAutoWidth = false;
                gvList.BestFitColumns();

                if (gvList.DataRowCount > 0)
                {
                    speIqcQty.EditValue = gvList.GetRowCellValue(0, "QTY").ObjectNullString();
                    //GetIQCList();
                }
            }
            else
            {
                /*2016.04.14*/
                /*IQC 등록 취소를 위한 데이터 조회*/
                BASE_DXGridHelper.Bind_Grid_Int( gcList2
                                               , "PKGMAT_INOUT.GET_IQC_LIST"
                                               , 1
                                               , new string[] {
                                                 "A_CLIENT"
                                               , "A_COMPANY"
                                               , "A_PLANT"
                                               , "A_SDATE"
                                               , "A_EDATE"}
                                               , new string[] {
                                                 Global.Global_Variable.CLIENT
                                               , Global.Global_Variable.COMPANY
                                               , Global.Global_Variable.PLANT 
                                               , dteFromTo.StartDate
                                               , dteFromTo.EndDate }
                                               , true
                                               , "SEL, IQCDATE, IQCNO, ITEMCODE, PARTNO, ITEMNAME, SPEC, INVOICENO, ORDERNO, ORDERSEQ, IQCQTY, IQCJUDGE, FILES"
                                               , true
                                               , "ITEMCODE, IQCQTY,ORDERSEQ,INVOICENO, IQCNO"
                                               );

                gvList2.OptionsView.ColumnAutoWidth = false;
                gvList2.BestFitColumns();

                gvList2.OptionsBehavior.Editable = true;
                gvList2.Columns["SEL"].OptionsColumn.AllowEdit = true;

            }

        }

        /*IQC 등록 패키지(프로시저) 호출 함수*/
        private void SaveIqc()
        {
            /*IQC 등록시 Validation Check*/
            /*step 1) INVOICE가 존재할경우, INVOICE 수량만큼만 저장 가능하다*/
            if (gvList.GetRowCellValue(gvList.FocusedRowHandle, "INVOICE").ObjectNullString() != "")
            {
                int iInvoiceQty = 0;
                int iIqcQty = 0;

                /*INVOICE 수량*/
                if(!int.TryParse(gvList.GetRowCellValue(gvList.FocusedRowHandle, "QTY").ObjectNullString(), out iInvoiceQty))
                    iInvoiceQty = 0;

                /*IQC 등록 수량*/
                if(!int.TryParse(gvList1.Columns["IQCQTY"].SummaryItem.SummaryValue.ToString(), out iIqcQty))
                    iIqcQty = 0;

                /*INVOICE 수량, IQC 등록 수량 비교*/
                if (iIqcQty > 0 && iInvoiceQty <= iIqcQty)
                {
                    iDATMessageBox.ErrorMessage("MSG_ER_MAT_065", this.Text, 3);
                    return;
                }
            }

            if (int.Parse(speIqcQty.EditValue.ObjectNullString()) <= 0)
            {
                iDATMessageBox.ErrorMessage("MSG_ER_MAT_072", this.Text, 3);
                return;
            }
            
            // 프로시져 수행
            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = 
                BASE_db.Execute_Proc( "PKGMAT_INOUT.SET_IQC_JUDGE"
                                    , 1
                                    , new string[] { 
                                      "A_CLIENT"
                                    , "A_COMPANY"
                                    , "A_PLANT"
                                    , "A_PRTDATE"
                                    , "A_ITEMCODE"
                                    , "A_IQCQTY"
                                    , "A_FILE"
                                    , "A_DOCDATE"
                                    , "A_JUDGE"
                                    , "A_USER" }
                                    , new object[] { 
                                      Global.Global_Variable.CLIENT
                                    , Global.Global_Variable.COMPANY
                                    , Global.Global_Variable.PLANT 
                                    , txtPrtdate.EditValue.ObjectNullString()
                                    , txtItemcode.EditValue.ObjectNullString()
                                    , speIqcQty.EditValue.ObjectNullString()
                                    , Path.GetFileName(txtFileInfo.EditValue.ObjectNullString()) //txtFileInfo.EditValue.ObjectNullString()
                                    , Convert.ToDateTime(DteDocDate.EditValue.ObjectNullString()).ToString("yyyyMMdd")
                                    , rdgUseFlag.EditValue.ObjectNullString()
                                    , Global.Global_Variable.USER_ID}
                                    );
            
            if (_Result.ResultInt == 0)
            {
                /*검사성적서(친환경) 업로드*/
                if (txtFileInfo.EditValue.ObjectNullString() != "")
                {
                    FTPHelper ftp = new FTPHelper(Global.Global_Variable.FTP_IP, Global.Global_Variable.FTP_ID, Global.Global_Variable.FTP_PW);

                    if (!ftp.checkDirectoryExists(_Result.ResultDataSet.Tables[0].Rows[0]["LEVEL1"].ObjectNullString()))
                        ftp.createDirectory(_Result.ResultDataSet.Tables[0].Rows[0]["LEVEL1"].ObjectNullString());

                    ftp.createDirectory(_Result.ResultDataSet.Tables[0].Rows[0]["LEVEL1"].ObjectNullString() + "/" + _Result.ResultDataSet.Tables[0].Rows[0]["LEVEL2"].ObjectNullString());

                    ftp.upload(_Result.ResultDataSet.Tables[0].Rows[0]["LEVEL1"].ObjectNullString() + "/" + _Result.ResultDataSet.Tables[0].Rows[0]["LEVEL2"].ObjectNullString() + "/" + _Result.ResultDataSet.Tables[0].Rows[0]["LEVEL3"].ObjectNullString(), txtFileInfo.EditValue.ObjectNullString());
                }

                /*정상 저장 완료후, IQC 등록 내역 조회*/
                //GetIQCList();
                iDATMessageBox.OKMessage("IQC_OK", this.Text, 5);
                GetGridViewList();
                
            }
            else
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
        }
        /*IQC 등록 취소 패키지(프로시저) 호출 함수*/
        private void Save_Cancel()
        {
            if (iDATMessageBox.QuestionMessage("MSG_ER_SALES_020", this.Text) == System.Windows.Forms.DialogResult.No)
                return;

            DataRow[] dRowList = (gcList2.DataSource as DataTable).Select("SEL = 'Y'");

            DataTable dTable = (gcList2.DataSource as DataTable).Copy();
            dTable.Clear();

            foreach (DataRow dRow in dRowList)
            {
                DataRow dTempRow = dTable.NewRow();

                for (int nCol = 0; nCol < dTable.Columns.Count; nCol++)
                    dTempRow[nCol] = dRow[nCol];

                dTable.Rows.Add(dTempRow);
            }

            string sXML = GetDataTableToXml(dTable);

            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = 
                BASE_db.Execute_Proc( "PKGMAT_INOUT.SET_IQC_CANCEL"
                                    , 1
                                    , new string[] {
                                      "A_CLIENT"
                                    , "A_COMPANY"
                                    , "A_PLANT"
                                    , "A_XML"
                                    , "A_REMARKS"
                                    , "A_USER" }
                                    , new string[] {
                                      Global.Global_Variable.CLIENT
                                    , Global.Global_Variable.COMPANY
                                    , Global.Global_Variable.PLANT  
                                    , sXML
                                    , ""
                                    , Global.Global_Variable.EHRCODE }
                                    );

            if (_Result.ResultInt == 0)
            {
                iDATMessageBox.OKMessage("DBMSG_SUCCESS", this.Text, 3);
                GetGridViewList();
            }
            else
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
        }

        #endregion

        private void gvList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ///*이전 선택된 RowHandle이 없을 경우 예외 처리*/
            //if (e.PrevFocusedRowHandle < 0)
            //    return;

            /*현재 선택된 RowHandle이 0 보다 큰 경우 IQC 등록된 내용 조회*/
            if (e.FocusedRowHandle >= 0)
            {
                ///*Invoice번호가 없는경우는 수량 수정이 가능하도록 변경*/
                //if (gvList.GetRowCellValue(e.FocusedRowHandle, "INVOICE").ObjectNullString() != "")
                //    speIqcQty.Properties.ReadOnly = true;
                //else
                //    speIqcQty.Properties.ReadOnly = false;

                speIqcQty.EditValue = gvList.GetRowCellValue(e.FocusedRowHandle, "QTY").ObjectNullString();

                /*IQC 이력 조회*/
                GetIQCList();
            }
        }

        private void btnFileInfo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            
            ofd.InitialDirectory = "C:\\";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFileInfo.EditValue = ofd.FileName;
                
                //FTPHelper ftp = new FTPHelper(Global.Global_Variable.FTP_IP, Global.Global_Variable.FTP_ID, Global.Global_Variable.FTP_PW);
                
                //ftp.upload(Path.GetFileName(ofd.FileName), txtFileInfo.EditValue.ObjectNullString());
                //ftp.download(@"test123.txt", @"C:\test123.txt");
            }
        }

        private void gvList2_RowCellClick(object sender, GridAlias.RowCellClickEventArgs e)
        {
            if (e.Column.Caption == "FILES")
            {
                if (gvList2.GetFocusedRowCellValue("FPATH").ObjectNullString() != "")
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    
                    sfd.InitialDirectory = @"C:\";
                    int iFileNameIdx = gvList2.GetFocusedRowCellValue("FPATH").ObjectNullString().LastIndexOf('/');
                    int iFileExt = gvList2.GetFocusedRowCellValue("FPATH").ObjectNullString().LastIndexOf('.');
                    sfd.FileName = gvList2.GetFocusedRowCellValue("FPATH").ObjectNullString().Substring(iFileNameIdx + 1);
                    sfd.DefaultExt = gvList2.GetFocusedRowCellValue("FPATH").ObjectNullString().Substring(iFileExt + 1);

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        FTPHelper ftp = new FTPHelper(Global.Global_Variable.FTP_IP, Global.Global_Variable.FTP_ID, Global.Global_Variable.FTP_PW);
                        ftp.download(gvList2.GetFocusedRowCellValue("FPATH").ObjectNullString(), sfd.FileName);
                        iDATMessageBox.OKMessage("DBMSG_SUCCESS", this.Text, 3);
                    }
                }
            }
        }

    }
}
