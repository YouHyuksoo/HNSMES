using System;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace IDAT_Common.Utility;

public class ExcelUtil
{
	public static DataSet GetDataSetFromExcelFile(string fileNM, bool lsIncludeHeader)
	{
		string empty = string.Empty;
		string format = ((!(Path.GetExtension(fileNM).ToUpper() == ".XLSX")) ? ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileNM + ";Extended Properties=\"Excel 8.0;HDR={0};IMEX=1;\"") : ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileNM + ";Extended Properties=\"Excel 12.0;HDR={0};IMEX=1;\""));
		empty = ((!lsIncludeHeader) ? string.Format(format, "NO") : string.Format(format, "NO"));
		OleDbConnection oleDbConnection = new OleDbConnection(empty);
		oleDbConnection.Open();
		DataTable oleDbSchemaTable = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[4] { null, null, null, "Table" });
		string text = "Sheet1$";
		oleDbConnection.Close();
		string cmdText = "select * from [" + text + "]";
		try
		{
			OleDbCommand selectCommand = new OleDbCommand(cmdText, oleDbConnection);
			OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter();
			oleDbDataAdapter.SelectCommand = selectCommand;
			DataSet dataSet = new DataSet();
			oleDbDataAdapter.Fill(dataSet);
			return dataSet;
		}
		catch (Exception)
		{
			text = oleDbSchemaTable.Rows[0]["Table_Name"].ToString();
			cmdText = "select * from [" + text + "]";
			try
			{
				OleDbCommand selectCommand = new OleDbCommand(cmdText, oleDbConnection);
				OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter();
				oleDbDataAdapter.SelectCommand = selectCommand;
				DataSet dataSet = new DataSet();
				oleDbDataAdapter.Fill(dataSet);
				return dataSet;
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}
