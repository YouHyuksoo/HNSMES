using Microsoft.VisualBasic;

namespace IDAT_Common.Utility;

public class Compare
{
	public static bool SameString(object obj1, object obj2)
	{
		string text = null;
		string text2 = null;
		if (obj1 != null)
		{
			text = obj1.ToString();
		}
		if (obj2 != null)
		{
			text2 = obj2.ToString();
		}
		return text == text2;
	}

	public static bool IsNumeric(string prmValue)
	{
		return Information.IsNumeric(prmValue);
	}
}
