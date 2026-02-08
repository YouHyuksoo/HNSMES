using System;

namespace IDAT.WCFClient;

public class ServiceSettings
{
	private string mIP = "";

	private int mPort = 0;

	private string mUserID = "";

	private string mPassword = "";

	private string mServiceName = "";

	private Uri mUri = null;

	private ProtocolKind mProtocol = ProtocolKind.Unknown;

	private int _timeoutminute = 5;

	private string mCompression = "";

	private string mEncryption = "";

	private SecurityTripleDES des = new SecurityTripleDES();

	public string UserID
	{
		get
		{
			return mUserID;
		}
		set
		{
			mUserID = value;
		}
	}

	public string Password
	{
		get
		{
			return mPassword;
		}
		set
		{
			mPassword = value;
		}
	}

	public Uri ServiceUri
	{
		get
		{
			mUri = new Uri(MakeUri());
			return mUri;
		}
	}

	public string IPAddress
	{
		get
		{
			return mIP;
		}
		set
		{
			mIP = value;
		}
	}

	public int Port
	{
		get
		{
			return mPort;
		}
		set
		{
			mPort = value;
		}
	}

	public ProtocolKind Protocol
	{
		get
		{
			return mProtocol;
		}
		set
		{
			mProtocol = value;
		}
	}

	public string ServiceName
	{
		get
		{
			return mServiceName;
		}
		set
		{
			mServiceName = value;
		}
	}

	public string Compression
	{
		get
		{
			return mCompression;
		}
		set
		{
			mCompression = value;
		}
	}

	public string Encryption
	{
		get
		{
			return mEncryption;
		}
		set
		{
			mEncryption = value;
		}
	}

	public int TimeoutMinute
	{
		get
		{
			return _timeoutminute;
		}
		set
		{
			_timeoutminute = value;
		}
	}

	private string MakeUri()
	{
		string text = "";
		return mProtocol switch
		{
			ProtocolKind.Http => "http://" + mIP + ":" + mPort + "/" + mServiceName, 
			ProtocolKind.NetTcp => "net.tcp://" + mIP + ":" + mPort + "/" + mServiceName, 
			ProtocolKind.Unknown => "", 
			_ => "", 
		};
	}
}
