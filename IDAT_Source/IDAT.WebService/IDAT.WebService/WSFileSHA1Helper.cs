using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace IDAT.WebService;

public class WSFileSHA1Helper
{
	[DebuggerNonUserCode]
	public WSFileSHA1Helper()
	{
	}

	public static string HashString(string textToHash)
	{
		SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();
		byte[] bytes = Encoding.UTF8.GetBytes(textToHash);
		byte[] inArray = HashBytes(bytes);
		sHA1CryptoServiceProvider.Clear();
		return Convert.ToBase64String(inArray);
	}

	public static byte[] HashBytes(byte[] bytes)
	{
		SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();
		byte[] result = sHA1CryptoServiceProvider.ComputeHash(bytes);
		sHA1CryptoServiceProvider.Clear();
		return result;
	}

	public static string GetRandomSalt()
	{
		RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
		byte[] array = new byte[16];
		randomNumberGenerator.GetBytes(array);
		return Convert.ToBase64String(array);
	}
}
