using System;
using System.Runtime.InteropServices;
using System.Text;

namespace IDAT_Common.Utility;

public class INI_Util
{
	[DllImport("kernel32")]
	public static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

	[DllImport("kernel32")]
	public static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

	public static void IniWrite(string prmSection, string prmKey, string prmValue, string prmIniFilePath)
	{
		try
		{
			if (prmSection == null)
			{
				throw new ArgumentException();
			}
			if (prmKey == null)
			{
				throw new ArgumentException();
			}
			if (prmValue == null)
			{
				throw new ArgumentException();
			}
			if (prmIniFilePath == null)
			{
				throw new ArgumentException();
			}
			prmValue = prmValue.Replace(Environment.NewLine, " ");
			WritePrivateProfileString(prmSection, prmKey, prmValue, prmIniFilePath);
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
	}

	public static string IniRead(string prmSection, string prmKey, string prmDefaultValue, string prmIniFilePath)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Capacity = 1024;
		try
		{
			if (prmSection == null)
			{
				throw new ArgumentException();
			}
			if (prmKey == null)
			{
				throw new ArgumentException();
			}
			if (prmIniFilePath == null)
			{
				throw new ArgumentException();
			}
			GetPrivateProfileString(prmSection, prmKey, prmDefaultValue, stringBuilder, 1024, prmIniFilePath);
			if (stringBuilder != null)
			{
				return stringBuilder.ToString();
			}
			return "";
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
	}
}
