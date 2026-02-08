using System.IO;
using System.Windows.Forms;
using DevExpress.XtraRichEdit;

namespace IDAT.Devexpress.NOTICE;

public class HtmlLoadHelper
{
	public static string GetRelativePath(string name)
	{
		name = "Data\\" + name;
		string startupPath = Application.StartupPath;
		string text = "\\";
		for (int i = 0; i <= 10; i++)
		{
			if (File.Exists(startupPath + text + name))
			{
				return startupPath + text + name;
			}
			text += "..\\";
		}
		return "";
	}

	public static void Load(string fileName, RichEditControl richEditControl)
	{
		string relativePath = GetRelativePath(fileName);
		if (!string.IsNullOrEmpty(relativePath))
		{
			richEditControl.LoadDocument(relativePath, DocumentFormat.Html);
		}
	}
}
