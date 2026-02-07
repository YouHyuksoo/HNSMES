using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using HAENGSUNG_HNSMES_UI.Class;
using HAENGSUNG_HNSMES_UI.WebService.Access;

namespace HAENGSUNG_HNSMES_UI.Forms.RPT
{
    public partial class RPTA210 : DevExpress.XtraReports.UI.XtraReport
    {
        LanguageInformation _clsLan;
        int mnCopies;

        public RPTA210()
        {
            InitializeComponent();
        }
        public RPTA210(DataTable dTable, int nCopies)
            : this()
        {
            _clsLan = new LanguageInformation();

            foreach (XRControl ctr in GroupHeader1.Controls)
            {
                string _ctrType = ctr.GetType().ToString().ToUpper();
                if (_ctrType.IndexOf("XRTABLE") >= 0)
                {
                    foreach (XRControl row in ctr.Controls)
                    {
                        foreach (XRControl cell in row.Controls)
                        {
                            if (cell.Text.ObjectNullString() != "")
                                cell.Text = _clsLan.GetMessageString(cell.Text.ObjectNullString());
                        }
                    }
                }
                else if (_ctrType.IndexOf("XRLABEL") >= 0)
                {
                    if (ctr.Text.ObjectNullString() != "")
                        ctr.Text = _clsLan.GetMessageString(ctr.Text.ObjectNullString());
                }
            }

            try
            {
                for (int nRow = 0; nRow < dTable.Rows.Count; nRow++)
                    rptds1.Tables["DTPRODORDER"].ImportRow(dTable.Rows[nRow]);

                mnCopies = nCopies;
                PrintingSystem.StartPrint += new DevExpress.XtraPrinting.PrintDocumentEventHandler(PrintingSystem_StartPrint);

                
            }
            catch (Exception ex)
            {
                iDATMessageBox.WARNINGMessage(ex.Message, this.Name, 3);
            }

        }

        private void PrintingSystem_StartPrint(object sender, DevExpress.XtraPrinting.PrintDocumentEventArgs e)
        {
            e.PrintDocument.PrinterSettings.Copies = short.Parse(mnCopies.ObjectNullString());
        }

        public void RptPrint()
        {
            this.Print();
        }

        private void GroupHeader1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //if(_clsLan == null) _clsLan =  new LanguageInformation();

            /*(상단) 타이틀 예)압착생산지시서*/
            xrlOperTitle.Text =
                "[" + ((DataRowView)GetCurrentRow()).Row["OPER"].ObjectNullString() + "] " +
                ((DataRowView)GetCurrentRow()).Row["OPERNAME"].ObjectNullString() + "   " +
                _clsLan.GetMessageString(xrlOperTitle.Tag.ObjectNullString());

            /*(하단) 공정 정보*/
            xrlOperNm.Text =
                _clsLan.GetMessageString(xrlOperNm.Tag.ObjectNullString()) + " : " +
                 ((DataRowView)GetCurrentRow()).Row["OPERNAME"].ObjectNullString();

            /*(하단) 호기 정보*/
            xrlUnitNm.Text =
                _clsLan.GetMessageString(xrlUnitNm.Tag.ObjectNullString()) + " : " +
                ((DataRowView)GetCurrentRow()).Row["UNITNM"].ObjectNullString();

            /*(하단) 시작시간 정보*/
            xrlOrderpDate.Text =
                _clsLan.GetMessageString(xrlOrderpDate.Tag.ObjectNullString()) + " : " +
                ((DataRowView)GetCurrentRow()).Row["PLANSTARTTIME"].ObjectNullString();

            /*(하단) 종료시간 정보*/
            xrlPrintDate.Text =
                _clsLan.GetMessageString(xrlPrintDate.Tag.ObjectNullString()) + " : " +
                ((DataRowView)GetCurrentRow()).Row["PLANENDTIME"].ObjectNullString();




            //if (((DataRowView)GetCurrentRow()).Row["OPER"].ObjectNullString() == "#0100")
            //{
            //    //if (count % 2 == 0)
            //    //    GroupHeader1.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
            //    //else
            //    //    GroupHeader1.PageBreak = DevExpress.XtraReports.UI.PageBreak.None;

            //    xrTable2.Visible = true;
            //    xrTable3.Visible = true;
            //}
            //else
            //{
            //    //if (count % 3 == 0)
            //    //    GroupHeader1.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
            //    //else
            //    //    GroupHeader1.PageBreak = DevExpress.XtraReports.UI.PageBreak.None;

            //    xrTable2.Visible = false;
            //    xrTable3.Visible = false;
            //}

            //count++;
            GroupHeader1.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;

        }

        private void xrPictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //int Average; //RGB값의 평균
            //Color co;
            //Bitmap bmp = null;
            //XRPictureBox pictureBox = (XRPictureBox)sender;

            //object row = GetCurrentRow();
            //try
            //{
            //    if (row is System.Data.DataRowView)
            //    {

            //        DataRow dr = ((DataRowView)GetCurrentRow()).Row;
            //        if (dr["IMAGE"] is Byte[])
            //        {
            //            var data = (Byte[])dr["IMAGE"];
            //            var stream = new MemoryStream(data);
            //            //xrPictureBox1.Image = Image.FromStream(stream);
            //            bmp = (Bitmap)Image.FromStream(stream);
            //        }

            //        for (int x = 0; x < bmp.Width; x++)
            //        {
            //            for (int y = 0; y < bmp.Height; y++)
            //            {
            //                co = bmp.GetPixel(x, y);
            //                Average = (co.R + co.G + co.B) / 3;

            //                co = Color.FromArgb(Average, Average, Average);

            //                bmp.SetPixel(x, y, co);     // 해당 좌표 픽셀의 컬러값을 변경
            //            }

            //        }

            //        xrPictureBox1.Image = bmp;

            //    }
            //}
            //catch (Exception ex)
            //{
 
            //}
        }

    }
}
