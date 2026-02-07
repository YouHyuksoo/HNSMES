using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace HAENGSUNG_HNSMES_UI.Forms.RPT
{
    public partial class RPTA201 : DevExpress.XtraReports.UI.XtraReport
    {
        readonly int mnCopies;

        public RPTA201()
        {
            InitializeComponent();
        }

        public RPTA201(DataTable dTable, int nCopies) : this()
        {
            for (int nRow = 0; nRow < dTable.Rows.Count; nRow++)
                rptds1.Tables["PRODSN_LABEL"].ImportRow(dTable.Rows[nRow]);

            mnCopies = nCopies;
            PrintingSystem.StartPrint += new DevExpress.XtraPrinting.PrintDocumentEventHandler(PrintingSystem_StartPrint);
            
        }
        private void PrintingSystem_StartPrint(object sender, DevExpress.XtraPrinting.PrintDocumentEventArgs e)
        {
            e.PrintDocument.PrinterSettings.Copies = short.Parse(mnCopies.ObjectNullString());
        }

        public void RptPrint()
        {
             try
             {
                 this.Print();
             }
             catch (Exception)
             {
                 //라벨 프린트 연결 안됨...
             }
         }
         public void RptPrint(bool bLandscape)
         {
             try
             {
                 this.Landscape = bLandscape;
                 this.Print();
             }
             catch (Exception)
             {
                 //라벨 프린트 연결 안됨...
             }
         }
         public void RptPrint(string _PrinterName)
         {
             this.Print(_PrinterName);
         }
    }
}
