using System.CodeDom.Compiler;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace IDAT.WCFClient.ControlService;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[DebuggerStepThrough]
public class ControlServiceClient : ClientBase<IControlService>, IControlService
{
	public ControlServiceClient()
	{
	}

	public ControlServiceClient(string endpointConfigurationName)
		: base(endpointConfigurationName)
	{
	}

	public ControlServiceClient(string endpointConfigurationName, string remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public ControlServiceClient(string endpointConfigurationName, EndpointAddress remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public ControlServiceClient(Binding binding, EndpointAddress remoteAddress)
		: base(binding, remoteAddress)
	{
	}

	public DataSet GetLogList(string from, string to)
	{
		return base.Channel.GetLogList(from, to);
	}

	public void ClearLogList()
	{
		base.Channel.ClearLogList();
	}

	public bool ServiceLogin(string userid, string password)
	{
		return base.Channel.ServiceLogin(userid, password);
	}

	public DataSet GetAllSettings()
	{
		return base.Channel.GetAllSettings();
	}

	public void SetAllSettings(DataSet ds)
	{
		base.Channel.SetAllSettings(ds);
	}

	public bool StartService()
	{
		return base.Channel.StartService();
	}

	public bool StopService()
	{
		return base.Channel.StopService();
	}

	public bool RestartService()
	{
		return base.Channel.RestartService();
	}

	public CommunicationState ServiceState(string servicename)
	{
		return base.Channel.ServiceState(servicename);
	}

	public void SetControlServiceUserIDAndPassword(int port, string authuserid, string authpassword, string userid, string password, int nettcpport, int httpport)
	{
		base.Channel.SetControlServiceUserIDAndPassword(port, authuserid, authpassword, userid, password, nettcpport, httpport);
	}

	public DataSet GetProgramVersion()
	{
		return base.Channel.GetProgramVersion();
	}

	public DataSet GetProgramFileList(string programID, string programVersion)
	{
		return base.Channel.GetProgramFileList(programID, programVersion);
	}

	public DataSet DownloadProgramFile(string programID, string programVersion, string fileName)
	{
		return base.Channel.DownloadProgramFile(programID, programVersion, fileName);
	}

	public void AddProgramVersion(string programID, string programVersion)
	{
		base.Channel.AddProgramVersion(programID, programVersion);
	}

	public void UploadProgramFile(string programID, string programVersion, string fileName, byte[] fileData, string fileExecute, string filePath)
	{
		base.Channel.UploadProgramFile(programID, programVersion, fileName, fileData, fileExecute, filePath);
	}

	public void RemoveProgramVersion(string programID)
	{
		base.Channel.RemoveProgramVersion(programID);
	}
}
