using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace HAENGSUNG_HNSMES_UI.Forms.RPT
{
    public partial class RPTA214 : DevExpress.XtraReports.UI.XtraReport
    {
        int mnCopies;

        public RPTA214()
        {
            InitializeComponent();
        }

        public RPTA214(DataTable dTable, int nCopies)
            : this()
        {
            for (int nRow = 0; nRow < dTable.Rows.Count; nRow++)
                rptds1.Tables["CURRENT"].ImportRow(dTable.Rows[nRow]);

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
            this.Print(_PrinterName);
        }
    }
}
