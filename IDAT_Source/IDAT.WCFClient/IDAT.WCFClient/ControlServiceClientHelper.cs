using System;
using System.Data;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;
using IDAT.GZipEncoder;
using IDAT.WCFClient.ControlService;

namespace IDAT.WCFClient;

public class ControlServiceClientHelper
{
	private XmlDictionaryReaderQuotas xmlReaderQuot = new XmlDictionaryReaderQuotas();

	private ServiceSettings ctlService = new ServiceSettings();

	private SecurityTripleDES des = new SecurityTripleDES();

	private string mUserID = "";

	private string mPassword = "";

	public ServiceSettings ControlServiceSettings
	{
		get
		{
			return ctlService;
		}
		set
		{
			ctlService = value;
			mUserID = ctlService.UserID;
			mPassword = ctlService.Password;
		}
	}

	public ControlServiceClientHelper()
	{
		xmlReaderQuot.MaxArrayLength = int.MaxValue;
	}

	private ControlServiceClient CreateControlService()
	{
		CustomBinding customBinding = null;
		NetTcpBinding netTcpBinding = new NetTcpBinding();
		BasicHttpBinding basicHttpBinding = new BasicHttpBinding();
		if (ctlService.Protocol == ProtocolKind.NetTcp)
		{
			netTcpBinding.ReaderQuotas.MaxArrayLength = int.MaxValue;
			netTcpBinding.MaxReceivedMessageSize = 2147483647L;
			netTcpBinding.MaxConnections = 100;
			netTcpBinding.ReceiveTimeout = TimeSpan.FromMinutes(ctlService.TimeoutMinute);
			netTcpBinding.SendTimeout = TimeSpan.FromMinutes(ctlService.TimeoutMinute);
			netTcpBinding.Security.Mode = SecurityMode.None;
			netTcpBinding.ReaderQuotas.MaxStringContentLength = int.MaxValue;
			BindingElementCollection bindingElementCollection = new BindingElementCollection();
			GZipMessageEncodingBindingElement gZipMessageEncodingBindingElement = new GZipMessageEncodingBindingElement();
			foreach (BindingElement item in netTcpBinding.CreateBindingElements())
			{
				bindingElementCollection.Add(item);
			}
			customBinding = new CustomBinding(bindingElementCollection);
		}
		else if (ctlService.Protocol == ProtocolKind.Http)
		{
			basicHttpBinding.ReaderQuotas.MaxArrayLength = int.MaxValue;
			basicHttpBinding.MaxReceivedMessageSize = 2147483647L;
			basicHttpBinding.ReceiveTimeout = TimeSpan.FromMinutes(ctlService.TimeoutMinute);
			basicHttpBinding.SendTimeout = TimeSpan.FromMinutes(ctlService.TimeoutMinute);
			basicHttpBinding.Security.Mode = BasicHttpSecurityMode.None;
			basicHttpBinding.ReaderQuotas.MaxStringContentLength = int.MaxValue;
			basicHttpBinding.TextEncoding = Encoding.Unicode;
			basicHttpBinding.MessageEncoding = WSMessageEncoding.Mtom;
			BindingElementCollection bindingElementCollection = new BindingElementCollection();
			GZipMessageEncodingBindingElement gZipMessageEncodingBindingElement = new GZipMessageEncodingBindingElement();
			foreach (BindingElement item2 in basicHttpBinding.CreateBindingElements())
			{
				bindingElementCollection.Add(item2);
			}
			customBinding = new CustomBinding(bindingElementCollection);
		}
		customBinding.SendTimeout = TimeSpan.FromMinutes(ctlService.TimeoutMinute);
		customBinding.ReceiveTimeout = TimeSpan.FromMinutes(ctlService.TimeoutMinute);
		EndpointAddress remoteAddress = new EndpointAddress(ctlService.ServiceUri.ToString());
		return new ControlServiceClient(customBinding, remoteAddress);
	}

	public DataTable GetLogList(string from, string to)
	{
		DataSet dataSet = null;
		using (ControlServiceClient controlServiceClient = CreateControlService())
		{
			if (controlServiceClient.ServiceLogin(mUserID, mPassword))
			{
				dataSet = controlServiceClient.GetLogList(from, to);
			}
			controlServiceClient.Abort();
		}
		return dataSet.Tables[0];
	}

	public void ClearLogList()
	{
		using ControlServiceClient controlServiceClient = CreateControlService();
		if (controlServiceClient.ServiceLogin(mUserID, mPassword))
		{
			controlServiceClient.ClearLogList();
		}
		controlServiceClient.Abort();
	}

	public bool CheckUserIDAndPassword(string userid, string password)
	{
		bool flag = false;
		using (ControlServiceClient controlServiceClient = CreateControlService())
		{
			flag = controlServiceClient.ServiceLogin(userid, password);
			if (flag)
			{
				mUserID = userid;
				mPassword = password;
			}
			controlServiceClient.Abort();
		}
		return flag;
	}

	public void ServiceLogin(string userid, string password)
	{
		mUserID = userid;
		mPassword = password;
		ctlService.UserID = userid;
	}

	public DataSet GetAllSettings()
	{
		DataSet result = null;
		using (ControlServiceClient controlServiceClient = CreateControlService())
		{
			if (controlServiceClient.ServiceLogin(mUserID, mPassword))
			{
				result = controlServiceClient.GetAllSettings();
			}
			controlServiceClient.Abort();
		}
		return result;
	}

	public void SetAllSettings(DataSet ds)
	{
		using ControlServiceClient controlServiceClient = CreateControlService();
		if (controlServiceClient.ServiceLogin(mUserID, mPassword))
		{
			controlServiceClient.SetAllSettings(ds);
		}
		controlServiceClient.Abort();
	}

	public bool StartService()
	{
		bool result = false;
		using (ControlServiceClient controlServiceClient = CreateControlService())
		{
			if (controlServiceClient.ServiceLogin(mUserID, mPassword))
			{
				result = controlServiceClient.StartService();
			}
			controlServiceClient.Abort();
		}
		return result;
	}

	public bool StopService()
	{
		bool result = false;
		using (ControlServiceClient controlServiceClient = CreateControlService())
		{
			if (controlServiceClient.ServiceLogin(mUserID, mPassword))
			{
				result = controlServiceClient.StopService();
			}
			controlServiceClient.Abort();
		}
		return result;
	}

	public bool RestartService()
	{
		bool result = false;
		using (ControlServiceClient controlServiceClient = CreateControlService())
		{
			if (controlServiceClient.ServiceLogin(mUserID, mPassword))
			{
				result = controlServiceClient.RestartService();
			}
			controlServiceClient.Abort();
		}
		return result;
	}

	public CommunicationState ServiceState(string servicename)
	{
		CommunicationState result = CommunicationState.Created;
		try
		{
			using ControlServiceClient controlServiceClient = CreateControlService();
			if (controlServiceClient.ServiceLogin(mUserID, mPassword))
			{
				result = controlServiceClient.ServiceState(servicename);
			}
			controlServiceClient.Abort();
		}
		catch (Exception)
		{
			result = CommunicationState.Faulted;
		}
		return result;
	}

	public DataSet GetProgramVersion()
	{
		DataSet result = null;
		using (ControlServiceClient controlServiceClient = CreateControlService())
		{
			if (controlServiceClient.ServiceLogin(mUserID, mPassword))
			{
				result = controlServiceClient.GetProgramVersion();
			}
			controlServiceClient.Abort();
		}
		return result;
	}

	public DataSet GetProgramFileList(string programID, string programVersion)
	{
		DataSet result = null;
		using (ControlServiceClient controlServiceClient = CreateControlService())
		{
			if (controlServiceClient.ServiceLogin(mUserID, mPassword))
			{
				result = controlServiceClient.GetProgramFileList(programID, programVersion);
			}
			controlServiceClient.Abort();
		}
		return result;
	}

	public DataSet DownloadProgramFile(string programID, string programVersion, string fileName)
	{
		DataSet result = null;
		using (ControlServiceClient controlServiceClient = CreateControlService())
		{
			if (controlServiceClient.ServiceLogin(mUserID, mPassword))
			{
				result = controlServiceClient.DownloadProgramFile(programID, programVersion, fileName);
			}
			controlServiceClient.Abort();
		}
		return result;
	}

	public void AddProgramVersion(string programID, string programVersion)
	{
		using ControlServiceClient controlServiceClient = CreateControlService();
		if (controlServiceClient.ServiceLogin(mUserID, mPassword))
		{
			controlServiceClient.AddProgramVersion(programID, programVersion);
		}
		controlServiceClient.Abort();
	}

	public void RemoveProgramVersion(string programID)
	{
		using ControlServiceClient controlServiceClient = CreateControlService();
		if (controlServiceClient.ServiceLogin(mUserID, mPassword))
		{
			controlServiceClient.RemoveProgramVersion(programID);
		}
		controlServiceClient.Abort();
	}

	public void UploadProgramFile(string programID, string programVersion, string fileName, byte[] fileData, string fileExecute, string filePath)
	{
		using ControlServiceClient controlServiceClient = CreateControlService();
		if (controlServiceClient.ServiceLogin(mUserID, mPassword))
		{
			controlServiceClient.UploadProgramFile(programID, programVersion, fileName, fileData, fileExecute, filePath);
		}
		controlServiceClient.Abort();
	}
}
