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
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraCharts;

// User namespace
using HAENGSUNG_HNSMES_UI.Class;
using GridAlias = DevExpress.XtraGrid.Views.Grid;
//using Google.API.Translate;
using HAENGSUNG_HNSMES_UI.WebService.Access;
using HAENGSUNG_HNSMES_UI.WebService.Business;
using DevExpress.XtraSplashScreen;

public class ExcelHelper
{
    Microsoft.Office.Interop.Excel.Application xlApp;
    Microsoft.Office.Interop.Excel.Workbook xlBook;
    Microsoft.Office.Interop.Excel.Range xlRange;
    Microsoft.Office.Interop.Excel.Worksheet xlSheet;

    public DataTable GetSheetDataAsDataTable(String filePath, String sheetName)
    {
        DataTable dt = new DataTable();
        try
        {
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlBook = xlApp.Workbooks.Open(filePath);
            xlSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlBook.Worksheets[sheetName];
            xlRange = xlSheet.UsedRange;
            
            DataRow row = null;
            for (int i = 1; i <= xlRange.Rows.Count; i++)
            {
                if (i != 1)
                    row = dt.NewRow();
                for (int j = 1; j <= xlRange.Columns.Count; j++)
                {
                    if (i == 1)
                        dt.Columns.Add(Convert.ToString(((Microsoft.Office.Interop.Excel.Range)xlRange.Cells[1, j]).Value));
                    else
                        row[j - 1] = ((Microsoft.Office.Interop.Excel.Range)xlRange.Cells[i, j]).Value;
                }
                if (row != null)
                    dt.Rows.Add(row);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            xlBook.Close();
            xlApp.Quit();
        }
        return dt;
    }
}