using System;
using System.Security.Cryptography;
using System.Text;

namespace IDAT.WCFClient;

public class SecurityTripleDES
{
	private byte[] m_Key;

	private byte[] m_IV;

	public string KeyValue
	{
		get
		{
			return Encoding.ASCII.GetString(m_Key);
		}
		set
		{
			m_Key = Encoding.ASCII.GetBytes(value);
		}
	}

	public string IVValue
	{
		get
		{
			return Encoding.ASCII.GetString(m_IV);
		}
		set
		{
			m_IV = Encoding.ASCII.GetBytes(value);
		}
	}

	public SecurityTripleDES()
	{
		m_Key = Encoding.ASCII.GetBytes("ID Information System WC");
		m_IV = Encoding.ASCII.GetBytes("ID Information System WC");
	}

	public string EncryptString(string thisEncode)
	{
		string result = "";
		try
		{
			TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
			byte[] bytes = Encoding.Default.GetBytes(thisEncode);
			result = Convert.ToBase64String(tripleDESCryptoServiceProvider.CreateEncryptor(m_Key, m_IV).TransformFinalBlock(bytes, 0, bytes.Length));
		}
		catch
		{
		}
		return result;
	}

	public string DecryptString(string thisDecode)
	{
		string result = "";
		try
		{
			TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
			byte[] array = Convert.FromBase64String(thisDecode);
			result = Encoding.Default.GetString(tripleDESCryptoServiceProvider.CreateDecryptor(m_Key, m_IV).TransformFinalBlock(array, 0, array.Length));
		}
		catch
		{
		}
		return result;
	}
}
