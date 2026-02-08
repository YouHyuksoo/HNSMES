using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;

namespace IDAT_Common.Utility;

public class ConvertUtil
{
	public static string ConvertString(object str)
	{
		try
		{
			if (str != null)
			{
				return str.ToString();
			}
			return "";
		}
		catch (Exception)
		{
			return "";
		}
	}

	public static DateTime ParseDate(string strDate)
	{
		try
		{
			return new DateTime(int.Parse(strDate.Substring(0, 4)), int.Parse(strDate.Substring(4, 2)), int.Parse(strDate.Substring(6, 2)));
		}
		catch (Exception)
		{
			return DateTime.MinValue;
		}
	}

	public static int ParseInt(string value)
	{
		value = value.Replace(",", "");
		value = value.Replace(".", "");
		if (value.Trim().Length == 0)
		{
			return 0;
		}
		int result;
		try
		{
			result = int.Parse(value);
		}
		catch
		{
			return 0;
		}
		return result;
	}

	public static double ParseDouble(string value)
	{
		value = value.Replace(",", "");
		if (value.Trim().Length == 0)
		{
			return 0.0;
		}
		double result;
		try
		{
			result = double.Parse(value);
		}
		catch
		{
			return 0.0;
		}
		return result;
	}

	public static float ParseFloat(string value)
	{
		value = value.Replace(",", "");
		if (value.Trim().Length == 0)
		{
			return 0f;
		}
		float result;
		try
		{
			result = float.Parse(value);
		}
		catch
		{
			return 0f;
		}
		return result;
	}

	public static decimal ParseDecimal(string value)
	{
		value = value.Replace(",", "");
		if (value.Trim().Length == 0)
		{
			return 0m;
		}
		decimal result;
		try
		{
			result = decimal.Parse(value);
		}
		catch
		{
			return 0m;
		}
		return result;
	}

	public static string ParseCurrency(string value)
	{
		try
		{
			return $"{ParseDouble(value.ToString()):N3}";
		}
		catch
		{
			return "0";
		}
	}

	public static string ParseCurrency(string value, string format)
	{
		try
		{
			return string.Format(format, ParseDouble(value.ToString()));
		}
		catch
		{
			return "0";
		}
	}

	public static Bitmap ConvertMakeHangulBitmap(Font prmFont, string prmText)
	{
		try
		{
			Bitmap bitmap = new Bitmap(1000, 200);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.Clear(Color.White);
			graphics.DrawString(prmText, prmFont, Brushes.Black, 0f, 0f);
			SizeF sizeF = graphics.MeasureString(prmText, prmFont);
			Bitmap result = bitmap.Clone(new Rectangle(0, 0, ((int)sizeF.Width + 8) / 8 * 8, (int)sizeF.Height), PixelFormat.Undefined);
			bitmap.Dispose();
			graphics.Dispose();
			return result;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
	}

	public static string ConvertBitmapToBinary(Bitmap prmBitmap)
	{
		string text = "";
		try
		{
			for (int i = 0; i < prmBitmap.Height; i++)
			{
				for (int j = 0; j < prmBitmap.Width; j++)
				{
					text = ((prmBitmap.GetPixel(j, i).R != byte.MaxValue || prmBitmap.GetPixel(j, i).G != byte.MaxValue || prmBitmap.GetPixel(j, i).B != byte.MaxValue) ? (text + "1") : (text + "0"));
				}
			}
			return text;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
	}

	public static string ConvertBinaryToHex(string prmData)
	{
		string text = "";
		string text2 = "";
		try
		{
			for (int i = 0; i < prmData.Length; i += 4)
			{
				switch (prmData.Substring(i, 4))
				{
				case "0000":
					text2 += "0";
					break;
				case "0001":
					text2 += "1";
					break;
				case "0010":
					text2 += "2";
					break;
				case "0011":
					text2 += "3";
					break;
				case "0100":
					text2 += "4";
					break;
				case "0101":
					text2 += "5";
					break;
				case "0110":
					text2 += "6";
					break;
				case "0111":
					text2 += "7";
					break;
				case "1000":
					text2 += "8";
					break;
				case "1001":
					text2 += "9";
					break;
				case "1010":
					text2 += "A";
					break;
				case "1011":
					text2 += "B";
					break;
				case "1100":
					text2 += "C";
					break;
				case "1101":
					text2 += "D";
					break;
				case "1110":
					text2 += "E";
					break;
				case "1111":
					text2 += "F";
					break;
				}
			}
			return text2;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
	}

	public static string ByteToHexString(byte prmData)
	{
		string text = null;
		try
		{
			text = prmData.ToString("X");
			if (text.Length == 1)
			{
				text = "0" + text;
			}
			return text;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
	}

	public static string ByteArrayToHexString(byte[] prmData)
	{
		string text = null;
		try
		{
			foreach (byte prmData2 in prmData)
			{
				text += ByteToHexString(prmData2);
			}
			return text;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
	}

	public static byte[] HexStringToByteArray(string prmHexString)
	{
		byte[] array = null;
		int num = 0;
		prmHexString = prmHexString.Replace(" ", "");
		try
		{
			num = prmHexString.Length / 2 + prmHexString.Length % 2;
			array = new byte[num];
			for (int i = 0; i < num; i++)
			{
				string text = prmHexString.Substring(i * 2);
				if (text.Length >= 2)
				{
					array[i] = byte.Parse(prmHexString.Substring(i * 2, 2), NumberStyles.HexNumber);
				}
				else
				{
					array[i] = byte.Parse(prmHexString.Substring(i * 2, 1), NumberStyles.HexNumber);
				}
			}
			return array;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
	}
}
