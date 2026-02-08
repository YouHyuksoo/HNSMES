using System.CodeDom.Compiler;
using System.Data;
using System.ServiceModel;

namespace IDAT.WCFClient.ControlService;

[ServiceContract(ConfigurationName = "ControlService.IControlService")]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public interface IControlService
{
	[OperationContract(Action = "http://tempuri.org/IControlService/GetLogList", ReplyAction = "http://tempuri.org/IControlService/GetLogListResponse")]
	DataSet GetLogList(string from, string to);

	[OperationContract(Action = "http://tempuri.org/IControlService/ClearLogList", ReplyAction = "http://tempuri.org/IControlService/ClearLogListResponse")]
	void ClearLogList();

	[OperationContract(Action = "http://tempuri.org/IControlService/ServiceLogin", ReplyAction = "http://tempuri.org/IControlService/ServiceLoginResponse")]
	bool ServiceLogin(string userid, string password);

	[OperationContract(Action = "http://tempuri.org/IControlService/GetAllSettings", ReplyAction = "http://tempuri.org/IControlService/GetAllSettingsResponse")]
	DataSet GetAllSettings();

	[OperationContract(Action = "http://tempuri.org/IControlService/SetAllSettings", ReplyAction = "http://tempuri.org/IControlService/SetAllSettingsResponse")]
	void SetAllSettings(DataSet ds);

	[OperationContract(Action = "http://tempuri.org/IControlService/StartService", ReplyAction = "http://tempuri.org/IControlService/StartServiceResponse")]
	bool StartService();

	[OperationContract(Action = "http://tempuri.org/IControlService/StopService", ReplyAction = "http://tempuri.org/IControlService/StopServiceResponse")]
	bool StopService();

	[OperationContract(Action = "http://tempuri.org/IControlService/RestartService", ReplyAction = "http://tempuri.org/IControlService/RestartServiceResponse")]
	bool RestartService();

	[OperationContract(Action = "http://tempuri.org/IControlService/ServiceState", ReplyAction = "http://tempuri.org/IControlService/ServiceStateResponse")]
	CommunicationState ServiceState(string servicename);

	[OperationContract(Action = "http://tempuri.org/IControlService/SetControlServiceUserIDAndPassword", ReplyAction = "http://tempuri.org/IControlService/SetControlServiceUserIDAndPasswordResponse")]
	void SetControlServiceUserIDAndPassword(int port, string authuserid, string authpassword, string userid, string password, int nettcpport, int httpport);

	[OperationContract(Action = "http://tempuri.org/IControlService/GetProgramVersion", ReplyAction = "http://tempuri.org/IControlService/GetProgramVersionResponse")]
	DataSet GetProgramVersion();

	[OperationContract(Action = "http://tempuri.org/IControlService/GetProgramFileList", ReplyAction = "http://tempuri.org/IControlService/GetProgramFileListResponse")]
	DataSet GetProgramFileList(string programID, string programVersion);

	[OperationContract(Action = "http://tempuri.org/IControlService/DownloadProgramFile", ReplyAction = "http://tempuri.org/IControlService/DownloadProgramFileResponse")]
	DataSet DownloadProgramFile(string programID, string programVersion, string fileName);

	[OperationContract(Action = "http://tempuri.org/IControlService/AddProgramVersion", ReplyAction = "http://tempuri.org/IControlService/AddProgramVersionResponse")]
	void AddProgramVersion(string programID, string programVersion);

	[OperationContract(Action = "http://tempuri.org/IControlService/UploadProgramFile", ReplyAction = "http://tempuri.org/IControlService/UploadProgramFileResponse")]
	void UploadProgramFile(string programID, string programVersion, string fileName, byte[] fileData, string fileExecute, string filePath);

	[OperationContract(Action = "http://tempuri.org/IControlService/RemoveProgramVersion", ReplyAction = "http://tempuri.org/IControlService/RemoveProgramVersionResponse")]
	void RemoveProgramVersion(string programID);
}
