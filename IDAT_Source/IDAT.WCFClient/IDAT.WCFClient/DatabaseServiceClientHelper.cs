using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;
using IDAT.GZipEncoder;
using IDAT.WCFClient.DatabaseService;

namespace IDAT.WCFClient;

public class DatabaseServiceClientHelper
{
	private XmlDictionaryReaderQuotas xmlReaderQuot = new XmlDictionaryReaderQuotas();

	private ServiceSettings databaseService;

	private Dictionary<string, object> m_param = new Dictionary<string, object>();

	private StringBuilder m_sql = new StringBuilder();

	private int _timeoutminute = 5;

	public Dictionary<string, object> SpParam
	{
		get
		{
			return m_param;
		}
		set
		{
			m_param = value;
		}
	}

	public StringBuilder Sql
	{
		get
		{
			return m_sql;
		}
		set
		{
			m_sql = value;
		}
	}

	public ServiceSettings DatabaseServiceSettings
	{
		get
		{
			return databaseService;
		}
		set
		{
			databaseService = value;
		}
	}

	public DatabaseServiceClientHelper()
	{
		databaseService = new ServiceSettings();
	}

	public void SpParamClear()
	{
		m_param.Clear();
	}

	private DatabaseServiceClient CreateDatabaseServiceClient()
	{
		CustomBinding binding = null;
		BindingElementCollection bindingElementCollection = null;
		NetTcpBinding netTcpBinding = new NetTcpBinding();
		BasicHttpBinding basicHttpBinding = new BasicHttpBinding();
		if (databaseService.Protocol == ProtocolKind.NetTcp)
		{
			netTcpBinding.MaxReceivedMessageSize = 2147483647L;
			netTcpBinding.MaxBufferPoolSize = 2147483647L;
			netTcpBinding.MaxConnections = 100;
			netTcpBinding.OpenTimeout = TimeSpan.MaxValue;
			netTcpBinding.ReceiveTimeout = TimeSpan.MaxValue;
			netTcpBinding.SendTimeout = TimeSpan.MaxValue;
			netTcpBinding.CloseTimeout = TimeSpan.MaxValue;
			netTcpBinding.Security.Mode = SecurityMode.None;
			netTcpBinding.ReaderQuotas.MaxStringContentLength = int.MaxValue;
			netTcpBinding.ReaderQuotas.MaxArrayLength = int.MaxValue;
			netTcpBinding.ReaderQuotas.MaxBytesPerRead = int.MaxValue;
			bindingElementCollection = new BindingElementCollection();
			foreach (BindingElement item in netTcpBinding.CreateBindingElements())
			{
				bindingElementCollection.Add(item);
			}
			if (databaseService.Compression == "Y")
			{
				GZipMessageEncodingBindingElement gZipMessageEncodingBindingElement = new GZipMessageEncodingBindingElement();
				((BinaryMessageEncodingBindingElement)gZipMessageEncodingBindingElement.InnerMessageEncodingBindingElement).ReaderQuotas.MaxArrayLength = int.MaxValue;
				((BinaryMessageEncodingBindingElement)gZipMessageEncodingBindingElement.InnerMessageEncodingBindingElement).ReaderQuotas.MaxBytesPerRead = int.MaxValue;
				((BinaryMessageEncodingBindingElement)gZipMessageEncodingBindingElement.InnerMessageEncodingBindingElement).ReaderQuotas.MaxStringContentLength = int.MaxValue;
				bindingElementCollection[1] = gZipMessageEncodingBindingElement;
			}
			binding = new CustomBinding(bindingElementCollection);
		}
		else if (databaseService.Protocol == ProtocolKind.Http)
		{
			basicHttpBinding.MaxReceivedMessageSize = 2147483647L;
			basicHttpBinding.MaxBufferPoolSize = 2147483647L;
			basicHttpBinding.OpenTimeout = TimeSpan.MaxValue;
			basicHttpBinding.ReceiveTimeout = TimeSpan.MaxValue;
			basicHttpBinding.SendTimeout = TimeSpan.MaxValue;
			basicHttpBinding.CloseTimeout = TimeSpan.MaxValue;
			basicHttpBinding.Security.Mode = BasicHttpSecurityMode.None;
			basicHttpBinding.ReaderQuotas.MaxBytesPerRead = int.MaxValue;
			basicHttpBinding.ReaderQuotas.MaxArrayLength = int.MaxValue;
			basicHttpBinding.ReaderQuotas.MaxStringContentLength = int.MaxValue;
			basicHttpBinding.TextEncoding = Encoding.Unicode;
			if (databaseService.Compression == "Y")
			{
				basicHttpBinding.MessageEncoding = WSMessageEncoding.Mtom;
			}
			else
			{
				basicHttpBinding.MessageEncoding = WSMessageEncoding.Text;
			}
			bindingElementCollection = new BindingElementCollection();
			foreach (BindingElement item2 in basicHttpBinding.CreateBindingElements())
			{
				bindingElementCollection.Add(item2);
			}
			if (databaseService.Compression == "Y")
			{
				GZipMessageEncodingBindingElement gZipMessageEncodingBindingElement = new GZipMessageEncodingBindingElement();
				((BinaryMessageEncodingBindingElement)gZipMessageEncodingBindingElement.InnerMessageEncodingBindingElement).ReaderQuotas.MaxArrayLength = int.MaxValue;
				((BinaryMessageEncodingBindingElement)gZipMessageEncodingBindingElement.InnerMessageEncodingBindingElement).ReaderQuotas.MaxBytesPerRead = int.MaxValue;
				((BinaryMessageEncodingBindingElement)gZipMessageEncodingBindingElement.InnerMessageEncodingBindingElement).ReaderQuotas.MaxStringContentLength = int.MaxValue;
				bindingElementCollection[1] = gZipMessageEncodingBindingElement;
			}
			binding = new CustomBinding(bindingElementCollection);
		}
		EndpointAddress remoteAddress = new EndpointAddress(databaseService.ServiceUri.ToString());
		return new DatabaseServiceClient(binding, remoteAddress);
	}

	public ReturnDataStructure ExecuteQuery()
	{
		ReturnDataStructure returnDataStructure = new ReturnDataStructure();
		using (DatabaseServiceClient databaseServiceClient = CreateDatabaseServiceClient())
		{
			if (databaseServiceClient.CheckUserIDAndPassword(databaseService.UserID, databaseService.Password))
			{
				returnDataStructure = databaseServiceClient.ExecuteQuery(m_sql.ToString());
			}
			else
			{
				returnDataStructure.ReturnInt = 0;
				returnDataStructure.ReturnString = "Using the service authentication failure.";
				returnDataStructure.ReturnDataSet = null;
			}
			databaseServiceClient.Abort();
		}
		return returnDataStructure;
	}

	public ReturnDataStructure ExecuteQueryReturnDataSet()
	{
		ReturnDataStructure returnDataStructure = new ReturnDataStructure();
		using (DatabaseServiceClient databaseServiceClient = CreateDatabaseServiceClient())
		{
			if (databaseServiceClient.CheckUserIDAndPassword(databaseService.UserID, databaseService.Password))
			{
				returnDataStructure = databaseServiceClient.ExecuteQueryReturnDataSet(m_sql.ToString());
			}
			else
			{
				returnDataStructure.ReturnInt = 0;
				returnDataStructure.ReturnString = "Using the service authentication failure.";
				returnDataStructure.ReturnDataSet = null;
			}
			databaseServiceClient.Abort();
		}
		return returnDataStructure;
	}

	public ReturnDataStructure ExecuteProcNoReturnDataSet(string procName, int overload)
	{
		ReturnDataStructure returnDataStructure = new ReturnDataStructure();
		using (DatabaseServiceClient databaseServiceClient = CreateDatabaseServiceClient())
		{
			if (databaseServiceClient.CheckUserIDAndPassword(databaseService.UserID, databaseService.Password))
			{
				returnDataStructure = databaseServiceClient.ExecuteProcNoReturnDataSet(procName, overload, m_param);
			}
			else
			{
				returnDataStructure.ReturnInt = 0;
				returnDataStructure.ReturnString = "Using the service authentication failure.";
				returnDataStructure.ReturnDataSet = null;
			}
			databaseServiceClient.Abort();
		}
		return returnDataStructure;
	}

	public ReturnDataStructure ExecuteProc(string procName, int overload)
	{
		xmlReaderQuot.MaxArrayLength = int.MaxValue;
		xmlReaderQuot.MaxBytesPerRead = int.MaxValue;
		ReturnDataStructure returnDataStructure = new ReturnDataStructure();
		using (DatabaseServiceClient databaseServiceClient = CreateDatabaseServiceClient())
		{
			if (databaseServiceClient.CheckUserIDAndPassword(databaseService.UserID, databaseService.Password))
			{
				returnDataStructure = databaseServiceClient.ExecuteProcReturnDataSet(procName, overload, m_param);
			}
			else
			{
				returnDataStructure.ReturnInt = 0;
				returnDataStructure.ReturnString = "Using the service authentication failure.";
				returnDataStructure.ReturnDataSet = null;
			}
			databaseServiceClient.Abort();
		}
		return returnDataStructure;
	}
}
