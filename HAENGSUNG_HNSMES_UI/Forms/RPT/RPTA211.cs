using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Drawing.Printing;

namespace HAENGSUNG_HNSMES_UI.Forms.RPT
{
    public partial class RPTA211 : DevExpress.XtraReports.UI.XtraReport
    {
        int mnCopies;

        public RPTA211()
        {
            InitializeComponent();            
        }

        public RPTA211(DataTable dTable, string nDecectNm, string nDecectNm1, string nDecectNm2, int nCopies)
            : this()
        {
            for (int nRow = 0; nRow < dTable.Rows.Count; nRow++)
                rptds1.Tables["CURRENT"].ImportRow(dTable.Rows[nRow]);

            lblDecectNM.Text = nDecectNm;
            lblDecectNM1.Text = nDecectNm1;
            lblDecectNM2.Text = nDecectNm2;
            mnCopies = nCopies;
            PrintingSystem.StartPrint += new DevExpress.XtraPrinting.PrintDocumentEventHandler(PrintingSystem_StartPrint);
        }

        private void PrintingSystem_StartPrint(object sender, DevExpress.XtraPrinting.PrintDocumentEventArgs e) 
        {
            e.PrintDocument.PrinterSettings.Copies = short.Parse(mnCopies.ObjectNullString());
        }

        public void RptPrint()
        {
            this.Print();
        }

        public void RptPrint(string _PrinterName)
        {
            this.Print(GetDefaultPrinter(_PrinterName));
        }

        string GetDefaultPrinter(string _strPrint)
        {
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                if (printer.Contains(_strPrint))
                    return printer;
            }
            return string.Empty;
        }
    }
}
