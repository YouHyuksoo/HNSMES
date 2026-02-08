using System;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace IDAT_Common.Utility;

public class ETC
{
	public static void Execute(string prmCommand)
	{
		try
		{
			Process.Start(prmCommand);
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
	}

	public static string GetDataTableToXml(DataTable dt)
	{
		string result = "";
		if (dt.TableName == "")
		{
			dt.TableName = "Table";
		}
		using (MemoryStream memoryStream = new MemoryStream())
		{
			dt.WriteXml(memoryStream, XmlWriteMode.IgnoreSchema);
			memoryStream.Flush();
			memoryStream.Position = 0L;
			using (StreamReader streamReader = new StreamReader(memoryStream))
			{
				result = streamReader.ReadToEnd();
				streamReader.Close();
			}
			memoryStream.Close();
		}
		return result;
	}
}
