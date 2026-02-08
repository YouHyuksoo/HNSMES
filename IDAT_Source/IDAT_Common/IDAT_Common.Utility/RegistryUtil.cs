using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace IDAT_Common.Utility;

public class RegistryUtil
{
	public static string RegistryGetValue(string prmSectionName, string prmValueName, string prmDefaultValue)
	{
		string text = "";
		try
		{
			prmSectionName = prmSectionName.Trim();
			if (prmSectionName == "" || prmSectionName == ".")
			{
				prmSectionName = "DefaultSection";
			}
			text = Registry.GetValue(string.Format("{0}\\{1}\\{2}", "HKEY_CURRENT_USER", Application.ProductName, prmSectionName), prmValueName, prmDefaultValue).ToString();
			if (text == null)
			{
				text = "";
			}
			return text;
		}
		catch (NullReferenceException)
		{
			return "";
		}
		catch (Exception ex2)
		{
			throw new Exception(ex2.Message, ex2);
		}
		finally
		{
		}
	}

	public static void RegistrySetValue(string prmSectionName, string prmValueName, string prmValue)
	{
		try
		{
			prmSectionName = prmSectionName.Trim();
			if (prmSectionName == "" || prmSectionName == ".")
			{
				prmSectionName = "DefaultSection";
			}
			Registry.SetValue(string.Format("{0}\\{1}\\{2}", "HKEY_CURRENT_USER", Application.ProductName, prmSectionName), prmValueName, prmValue);
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
	}
}
