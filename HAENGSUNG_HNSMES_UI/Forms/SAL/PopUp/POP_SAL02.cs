using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

// DevExpress namespace
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views;

// User namespace
using HAENGSUNG_HNSMES_UI.Class;
using HAENGSUNG_HNSMES_UI.WebService.Access;
using DevExpress.XtraPrinting;

namespace HAENGSUNG_HNSMES_UI.Forms.SAL.PopUp
{
    public partial class POP_SAL02 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form
    {
        string m_strBoxNo = "";

        public POP_SAL02(string boxno)
        {
            InitializeComponent();
            this.m_strBoxNo = boxno;
        }

        private void POP_SAL02_PopUp_Load(object sender, EventArgs e)
        {
            GetGridViewList();
        }

        #region Button Event

        private void btnInit_Click(object sender, EventArgs e)
        {
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetGridViewList();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
          
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //if (gvList.FocusedRowHandle < 0 || gvList.FocusedRowHandle >= gvList.RowCount)
            //    return;
            //if (iDATMessageBox.QuestionMessage("MSG_QS_PRD_001", this.Text) == System.Windows.Forms.DialogResult.Yes)
            //{
            //    bool _bResult = BASE_db.Execute_Proc("PKGMAT_INOUT.PUT_IQCEXAMINE"
            //                                        , 1
            //                                        , new string[] {"A_INDAATE"
            //                                                      , "A_TIMEKEY"
            //                                                      , "A_IQCGBN"
            //                                                      , "A_IQCSEQ"
                                                                  
            //                                                    }
            //                                        , new string[] {  
            //                                                       gvList.GetRowCellValue(gvList.FocusedRowHandle, "INSPDATE").ToString().Replace("-", "").Substring(0, 8)
            //                                                     , gvList.GetRowCellValue(gvList.FocusedRowHandle, "TXNTIMEKEY").ToString()
            //                                                     , gvList.GetRowCellValue(gvList.FocusedRowHandle, "IQCGBN").ToString()
            //                                                     , gvList.GetRowCellValue(gvList.FocusedRowHandle, "IQCSEQ").ToString()
            //                                                    }
            //                                       , true);

            //    if (_bResult == true)
            //    {
            //        iDATMessageBox.OKMessage("DBMSG_SUCCESS", this.Text, 3);
            //        this.GetGridViewList();
            //    }
            //}
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Close();
        }

        #endregion

       

        #region Function


        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid(
                                          gcList
                                        , "PKGPRD_SALES.GET_DELIVERY_DETAIL"
                                        , 1
                                         , new string[] {
                                                          "A_BOXNO"
                                                       }
                                        , new string[] {
                                                          m_strBoxNo
                                                       }
                                        , true
                                        , "OQCIMAGEINS, OQCIMAGEAGREE, OQCIMAGEPACK, OUTIMAGE"
                                        , false
                                       );

            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();
            //rdgIqcgbn.EditValue = "1";
        }
        #endregion

        private void gvList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataTable dt = (DataTable)gcList.DataSource;

            if (dt.Rows.Count < 1)
            {
                picImageIns.Image = null;
                picImagePack.Image = null;
                picImageAgree.Image = null;
                return;
            }

            if (gvList.FocusedRowHandle < 0 || gvList.FocusedRowHandle >= gvList.RowCount)
                return;

            // OQC 검사기준서
            if (dt.Rows[gvList.FocusedRowHandle].ItemArray[dt.Columns["OQCIMAGEINS"].Ordinal].ToString() != "")
            {
                byte[] byteData = (byte[])(dt.Rows[gvList.FocusedRowHandle].ItemArray[dt.Columns["OQCIMAGEINS"].Ordinal]);
                System.IO.MemoryStream msData = new System.IO.MemoryStream(byteData);
                picImageIns.Image = Image.FromStream(msData);
                picImageIns.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                picImageIns.Image = null;
            }

            // OQC 검사협정서
            if (dt.Rows[gvList.FocusedRowHandle].ItemArray[dt.Columns["OQCIMAGEAGREE"].Ordinal].ToString() != "")
            {
                byte[] byteData = (byte[])(dt.Rows[gvList.FocusedRowHandle].ItemArray[dt.Columns["OQCIMAGEAGREE"].Ordinal]);
                System.IO.MemoryStream msData = new System.IO.MemoryStream(byteData);
                picImageAgree.Image = Image.FromStream(msData);
                picImageAgree.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                picImageAgree.Image = null;
            }


            // OQC 포장사양서
            if (dt.Rows[gvList.FocusedRowHandle].ItemArray[dt.Columns["OQCIMAGEPACK"].Ordinal].ToString() != "")
            {
                byte[] byteData = (byte[])(dt.Rows[gvList.FocusedRowHandle].ItemArray[dt.Columns["OQCIMAGEPACK"].Ordinal]);
                System.IO.MemoryStream msData = new System.IO.MemoryStream(byteData);
                picImagePack.Image = Image.FromStream(msData);
                picImagePack.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                picImagePack.Image = null;
            }

            // 출하성적서
            byte[] byteDataout = (byte[])(dt.Rows[gvList.FocusedRowHandle]["OUTIMAGE"]);
            spreadsheetControl1.LoadDocument(byteDataout, DevExpress.Spreadsheet.DocumentFormat.OpenXml);

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // 출력 버튼 클릭 이벤트
            PrintingSystem printingSystem = new PrintingSystem();

            using (PrintableComponentLink link = new PrintableComponentLink(printingSystem))
            {
                link.Component = spreadsheetControl1;
                link.CreateDocument();
                link.ShowPreviewDialog();
            }
        }
    }
}
