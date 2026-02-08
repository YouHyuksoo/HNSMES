using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ServiceModel;

namespace IDAT.WCFClient.DatabaseService;

[ServiceContract(ConfigurationName = "DatabaseService.IDatabaseService")]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public interface IDatabaseService
{
	[OperationContract(Action = "http://tempuri.org/IDatabaseService/CheckUserIDAndPassword", ReplyAction = "http://tempuri.org/IDatabaseService/CheckUserIDAndPasswordResponse")]
	bool CheckUserIDAndPassword(string userid, string password);

	[OperationContract(Action = "http://tempuri.org/IDatabaseService/ExecuteQuery", ReplyAction = "http://tempuri.org/IDatabaseService/ExecuteQueryResponse")]
	ReturnDataStructure ExecuteQuery(string strSql);

	[OperationContract(Action = "http://tempuri.org/IDatabaseService/ExecuteQueryReturnDataSet", ReplyAction = "http://tempuri.org/IDatabaseService/ExecuteQueryReturnDataSetResponse")]
	ReturnDataStructure ExecuteQueryReturnDataSet(string strSql);

	[OperationContract(Action = "http://tempuri.org/IDatabaseService/ExecuteProcReturnDataSet", ReplyAction = "http://tempuri.org/IDatabaseService/ExecuteProcReturnDataSetResponse")]
	ReturnDataStructure ExecuteProcReturnDataSet(string procName, int overload, Dictionary<string, object> param);

	[OperationContract(Action = "http://tempuri.org/IDatabaseService/ExecuteProcNoReturnDataSet", ReplyAction = "http://tempuri.org/IDatabaseService/ExecuteProcNoReturnDataSetResponse")]
	ReturnDataStructure ExecuteProcNoReturnDataSet(string procName, int overload, Dictionary<string, object> param);
}
