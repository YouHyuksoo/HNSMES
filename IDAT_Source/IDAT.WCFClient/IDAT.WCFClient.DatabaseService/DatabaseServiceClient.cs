using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace IDAT.WCFClient.DatabaseService;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[DebuggerStepThrough]
public class DatabaseServiceClient : ClientBase<IDatabaseService>, IDatabaseService
{
	public DatabaseServiceClient()
	{
	}

	public DatabaseServiceClient(string endpointConfigurationName)
		: base(endpointConfigurationName)
	{
	}

	public DatabaseServiceClient(string endpointConfigurationName, string remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public DatabaseServiceClient(string endpointConfigurationName, EndpointAddress remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public DatabaseServiceClient(Binding binding, EndpointAddress remoteAddress)
		: base(binding, remoteAddress)
	{
	}

	public bool CheckUserIDAndPassword(string userid, string password)
	{
		return base.Channel.CheckUserIDAndPassword(userid, password);
	}

	public ReturnDataStructure ExecuteQuery(string strSql)
	{
		return base.Channel.ExecuteQuery(strSql);
	}

	public ReturnDataStructure ExecuteQueryReturnDataSet(string strSql)
	{
		return base.Channel.ExecuteQueryReturnDataSet(strSql);
	}

	public ReturnDataStructure ExecuteProcReturnDataSet(string procName, int overload, Dictionary<string, object> param)
	{
		return base.Channel.ExecuteProcReturnDataSet(procName, overload, param);
	}

	public ReturnDataStructure ExecuteProcNoReturnDataSet(string procName, int overload, Dictionary<string, object> param)
	{
		return base.Channel.ExecuteProcNoReturnDataSet(procName, overload, param);
	}
}
