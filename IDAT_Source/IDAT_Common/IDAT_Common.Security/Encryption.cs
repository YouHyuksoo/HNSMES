using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace IDAT_Common.Security;

public class Encryption
{
	private const int BLOCK_SIZE = 8;

	private const string KEY_VALUE = "IDIFIDIF";

	private DESCryptoServiceProvider key = new DESCryptoServiceProvider();

	public string Encrypt(string PlainText)
	{
		try
		{
			string result = string.Empty;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				key.Key = Encoding.Default.GetBytes("IDIFIDIF");
				key.IV = Encoding.Default.GetBytes("IDIFIDIF");
				using CryptoStream cryptoStream = new CryptoStream(memoryStream, key.CreateEncryptor(key.Key, key.IV), CryptoStreamMode.Write);
				using StreamWriter streamWriter = new StreamWriter(cryptoStream);
				streamWriter.WriteLine(PlainText);
				streamWriter.Close();
				cryptoStream.Close();
				byte[] inArray = memoryStream.ToArray();
				memoryStream.Close();
				result = Convert.ToBase64String(inArray);
			}
			return result;
		}
		catch
		{
			return string.Empty;
		}
	}

	public string Decrypt(string CypherText)
	{
		try
		{
			string result = "";
			if (CypherText.Length == 0)
			{
				return string.Empty;
			}
			byte[] buffer = Convert.FromBase64String(CypherText);
			using (MemoryStream memoryStream = new MemoryStream(buffer))
			{
				key.Key = Encoding.Default.GetBytes("IDIFIDIF");
				key.IV = Encoding.Default.GetBytes("IDIFIDIF");
				using CryptoStream cryptoStream = new CryptoStream(memoryStream, key.CreateDecryptor(key.Key, key.IV), CryptoStreamMode.Read);
				using StreamReader streamReader = new StreamReader(cryptoStream);
				result = streamReader.ReadLine();
				streamReader.Close();
				cryptoStream.Close();
				memoryStream.Close();
			}
			return result;
		}
		catch
		{
			return string.Empty;
		}
	}
}
