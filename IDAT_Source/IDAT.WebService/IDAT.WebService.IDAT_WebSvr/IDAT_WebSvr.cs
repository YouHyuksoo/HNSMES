using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using IDAT.WebService.My;
using Microsoft.VisualBasic.CompilerServices;

namespace IDAT.WebService.IDAT_WebSvr;

[DebuggerStepThrough]
[GeneratedCode("System.Web.Services", "4.0.30319.1")]
[WebServiceBinding(Name = "IDAT_WebSvrSoap", Namespace = "IDAT_WebSvr")]
[DesignerCategory("code")]
public class IDAT_WebSvr : SoapHttpClientProtocol
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private SendOrPostCallback HelloWorldOperationCompleted;

	private SendOrPostCallback OpenWebserviceOperationCompleted;

	private SendOrPostCallback CloseWebServiceOperationCompleted;

	private SendOrPostCallback closeAllWebServiceOperationCompleted;

	private SendOrPostCallback Get_ProcClsDsOperationCompleted;

	private SendOrPostCallback Get_ProcClsBatchDsOperationCompleted;

	private SendOrPostCallback Get_QryClsDsOperationCompleted;

	private SendOrPostCallback Get_FuncOperationCompleted;

	private SendOrPostCallback WSFileInitializeOperationCompleted;

	private SendOrPostCallback UploadChunkOperationCompleted;

	private bool useDefaultCredentialsSetExplicitly;

	public new string Url
	{
		get
		{
			return base.Url;
		}
		set
		{
			if ((IsLocalFileSystemWebService(base.Url) && !useDefaultCredentialsSetExplicitly && !IsLocalFileSystemWebService(value)) ? true : false)
			{
				base.UseDefaultCredentials = false;
			}
			base.Url = value;
		}
	}

	public new bool UseDefaultCredentials
	{
		get
		{
			return base.UseDefaultCredentials;
		}
		set
		{
			base.UseDefaultCredentials = value;
			useDefaultCredentialsSetExplicitly = true;
		}
	}

	[method: DebuggerNonUserCode]
	public event HelloWorldCompletedEventHandler HelloWorldCompleted;

	[method: DebuggerNonUserCode]
	public event OpenWebserviceCompletedEventHandler OpenWebserviceCompleted;

	[method: DebuggerNonUserCode]
	public event CloseWebServiceCompletedEventHandler CloseWebServiceCompleted;

	[method: DebuggerNonUserCode]
	public event closeAllWebServiceCompletedEventHandler closeAllWebServiceCompleted;

	[method: DebuggerNonUserCode]
	public event Get_ProcClsDsCompletedEventHandler Get_ProcClsDsCompleted;

	[method: DebuggerNonUserCode]
	public event Get_ProcClsBatchDsCompletedEventHandler Get_ProcClsBatchDsCompleted;

	[method: DebuggerNonUserCode]
	public event Get_QryClsDsCompletedEventHandler Get_QryClsDsCompleted;

	[method: DebuggerNonUserCode]
	public event Get_FuncCompletedEventHandler Get_FuncCompleted;

	[method: DebuggerNonUserCode]
	public event WSFileInitializeCompletedEventHandler WSFileInitializeCompleted;

	[method: DebuggerNonUserCode]
	public event UploadChunkCompletedEventHandler UploadChunkCompleted;

	[DebuggerNonUserCode]
	private static void __ENCAddToList(object value)
	{
		checked
		{
			lock (__ENCList)
			{
				if (__ENCList.Count == __ENCList.Capacity)
				{
					int num = 0;
					int num2 = __ENCList.Count - 1;
					int num3 = 0;
					while (true)
					{
						int num4 = num3;
						int num5 = num2;
						if (num4 > num5)
						{
							break;
						}
						WeakReference weakReference = __ENCList[num3];
						if (weakReference.IsAlive)
						{
							if (num3 != num)
							{
								__ENCList[num] = __ENCList[num3];
							}
							num++;
						}
						num3++;
					}
					__ENCList.RemoveRange(num, __ENCList.Count - num);
					__ENCList.Capacity = __ENCList.Count;
				}
				__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
			}
		}
	}

	public IDAT_WebSvr()
	{
		__ENCAddToList(this);
		Url = MySettings.Default.IDAT_WebService_IDAT_WebSvr_IDAT_WebSvr;
		if (IsLocalFileSystemWebService(Url))
		{
			UseDefaultCredentials = true;
			useDefaultCredentialsSetExplicitly = false;
		}
		else
		{
			useDefaultCredentialsSetExplicitly = true;
		}
	}

	[SoapDocumentMethod("IDAT_WebSvr/HelloWorld", RequestNamespace = "IDAT_WebSvr", ResponseNamespace = "IDAT_WebSvr", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
	public string HelloWorld()
	{
		object[] array = Invoke("HelloWorld", new object[0]);
		return Conversions.ToString(array[0]);
	}

	public void HelloWorldAsync()
	{
		HelloWorldAsync(null);
	}

	public void HelloWorldAsync(object userState)
	{
		if (HelloWorldOperationCompleted == null)
		{
			HelloWorldOperationCompleted = OnHelloWorldOperationCompleted;
		}
		InvokeAsync("HelloWorld", new object[0], HelloWorldOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
	}

	private void OnHelloWorldOperationCompleted(object arg)
	{
		if (HelloWorldCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			HelloWorldCompleted?.Invoke(this, new HelloWorldCompletedEventArgs(e.Results, e.Error, e.Cancelled, RuntimeHelpers.GetObjectValue(e.UserState)));
		}
	}

	[SoapDocumentMethod("IDAT_WebSvr/OpenWebservice", RequestNamespace = "IDAT_WebSvr", ResponseNamespace = "IDAT_WebSvr", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
	public int OpenWebservice(string SystemID)
	{
		object[] array = Invoke("OpenWebservice", new object[1] { SystemID });
		return Conversions.ToInteger(array[0]);
	}

	public void OpenWebserviceAsync(string SystemID)
	{
		OpenWebserviceAsync(SystemID, null);
	}

	public void OpenWebserviceAsync(string SystemID, object userState)
	{
		if (OpenWebserviceOperationCompleted == null)
		{
			OpenWebserviceOperationCompleted = OnOpenWebserviceOperationCompleted;
		}
		InvokeAsync("OpenWebservice", new object[1] { SystemID }, OpenWebserviceOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
	}

	private void OnOpenWebserviceOperationCompleted(object arg)
	{
		if (OpenWebserviceCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			OpenWebserviceCompleted?.Invoke(this, new OpenWebserviceCompletedEventArgs(e.Results, e.Error, e.Cancelled, RuntimeHelpers.GetObjectValue(e.UserState)));
		}
	}

	[SoapDocumentMethod("IDAT_WebSvr/CloseWebService", RequestNamespace = "IDAT_WebSvr", ResponseNamespace = "IDAT_WebSvr", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
	public int CloseWebService(int uID)
	{
		object[] array = Invoke("CloseWebService", new object[1] { uID });
		return Conversions.ToInteger(array[0]);
	}

	public void CloseWebServiceAsync(int uID)
	{
		CloseWebServiceAsync(uID, null);
	}

	public void CloseWebServiceAsync(int uID, object userState)
	{
		if (CloseWebServiceOperationCompleted == null)
		{
			CloseWebServiceOperationCompleted = OnCloseWebServiceOperationCompleted;
		}
		InvokeAsync("CloseWebService", new object[1] { uID }, CloseWebServiceOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
	}

	private void OnCloseWebServiceOperationCompleted(object arg)
	{
		if (CloseWebServiceCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			CloseWebServiceCompleted?.Invoke(this, new CloseWebServiceCompletedEventArgs(e.Results, e.Error, e.Cancelled, RuntimeHelpers.GetObjectValue(e.UserState)));
		}
	}

	[SoapDocumentMethod("IDAT_WebSvr/closeAllWebService", RequestNamespace = "IDAT_WebSvr", ResponseNamespace = "IDAT_WebSvr", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
	public int closeAllWebService()
	{
		object[] array = Invoke("closeAllWebService", new object[0]);
		return Conversions.ToInteger(array[0]);
	}

	public void closeAllWebServiceAsync()
	{
		closeAllWebServiceAsync(null);
	}

	public void closeAllWebServiceAsync(object userState)
	{
		if (closeAllWebServiceOperationCompleted == null)
		{
			closeAllWebServiceOperationCompleted = OncloseAllWebServiceOperationCompleted;
		}
		InvokeAsync("closeAllWebService", new object[0], closeAllWebServiceOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
	}

	private void OncloseAllWebServiceOperationCompleted(object arg)
	{
		if (closeAllWebServiceCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			closeAllWebServiceCompleted?.Invoke(this, new closeAllWebServiceCompletedEventArgs(e.Results, e.Error, e.Cancelled, RuntimeHelpers.GetObjectValue(e.UserState)));
		}
	}

	[SoapDocumentMethod("IDAT_WebSvr/Get_ProcClsDs", RequestNamespace = "IDAT_WebSvr", ResponseNamespace = "IDAT_WebSvr", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
	public clsDataSetStruct Get_ProcClsDs(int uid, DataSet ds)
	{
		object[] array = Invoke("Get_ProcClsDs", new object[2] { uid, ds });
		return (clsDataSetStruct)array[0];
	}

	public void Get_ProcClsDsAsync(int uid, DataSet ds)
	{
		Get_ProcClsDsAsync(uid, ds, null);
	}

	public void Get_ProcClsDsAsync(int uid, DataSet ds, object userState)
	{
		if (Get_ProcClsDsOperationCompleted == null)
		{
			Get_ProcClsDsOperationCompleted = OnGet_ProcClsDsOperationCompleted;
		}
		InvokeAsync("Get_ProcClsDs", new object[2] { uid, ds }, Get_ProcClsDsOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
	}

	private void OnGet_ProcClsDsOperationCompleted(object arg)
	{
		if (Get_ProcClsDsCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			Get_ProcClsDsCompleted?.Invoke(this, new Get_ProcClsDsCompletedEventArgs(e.Results, e.Error, e.Cancelled, RuntimeHelpers.GetObjectValue(e.UserState)));
		}
	}

	[SoapDocumentMethod("IDAT_WebSvr/Get_ProcClsBatchDs", RequestNamespace = "IDAT_WebSvr", ResponseNamespace = "IDAT_WebSvr", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
	public clsDataSetStruct Get_ProcClsBatchDs(int uid, DataSet ds)
	{
		object[] array = Invoke("Get_ProcClsBatchDs", new object[2] { uid, ds });
		return (clsDataSetStruct)array[0];
	}

	public void Get_ProcClsBatchDsAsync(int uid, DataSet ds)
	{
		Get_ProcClsBatchDsAsync(uid, ds, null);
	}

	public void Get_ProcClsBatchDsAsync(int uid, DataSet ds, object userState)
	{
		if (Get_ProcClsBatchDsOperationCompleted == null)
		{
			Get_ProcClsBatchDsOperationCompleted = OnGet_ProcClsBatchDsOperationCompleted;
		}
		InvokeAsync("Get_ProcClsBatchDs", new object[2] { uid, ds }, Get_ProcClsBatchDsOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
	}

	private void OnGet_ProcClsBatchDsOperationCompleted(object arg)
	{
		if (Get_ProcClsBatchDsCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			Get_ProcClsBatchDsCompleted?.Invoke(this, new Get_ProcClsBatchDsCompletedEventArgs(e.Results, e.Error, e.Cancelled, RuntimeHelpers.GetObjectValue(e.UserState)));
		}
	}

	[SoapDocumentMethod("IDAT_WebSvr/Get_QryClsDs", RequestNamespace = "IDAT_WebSvr", ResponseNamespace = "IDAT_WebSvr", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
	public clsDataSetStruct Get_QryClsDs(int uid, string qry)
	{
		object[] array = Invoke("Get_QryClsDs", new object[2] { uid, qry });
		return (clsDataSetStruct)array[0];
	}

	public void Get_QryClsDsAsync(int uid, string qry)
	{
		Get_QryClsDsAsync(uid, qry, null);
	}

	public void Get_QryClsDsAsync(int uid, string qry, object userState)
	{
		if (Get_QryClsDsOperationCompleted == null)
		{
			Get_QryClsDsOperationCompleted = OnGet_QryClsDsOperationCompleted;
		}
		InvokeAsync("Get_QryClsDs", new object[2] { uid, qry }, Get_QryClsDsOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
	}

	private void OnGet_QryClsDsOperationCompleted(object arg)
	{
		if (Get_QryClsDsCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			Get_QryClsDsCompleted?.Invoke(this, new Get_QryClsDsCompletedEventArgs(e.Results, e.Error, e.Cancelled, RuntimeHelpers.GetObjectValue(e.UserState)));
		}
	}

	[SoapDocumentMethod("IDAT_WebSvr/Get_Func", RequestNamespace = "IDAT_WebSvr", ResponseNamespace = "IDAT_WebSvr", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
	public string Get_Func(int uid, DataSet ds, int returntype)
	{
		object[] array = Invoke("Get_Func", new object[3] { uid, ds, returntype });
		return Conversions.ToString(array[0]);
	}

	public void Get_FuncAsync(int uid, DataSet ds, int returntype)
	{
		Get_FuncAsync(uid, ds, returntype, null);
	}

	public void Get_FuncAsync(int uid, DataSet ds, int returntype, object userState)
	{
		if (Get_FuncOperationCompleted == null)
		{
			Get_FuncOperationCompleted = OnGet_FuncOperationCompleted;
		}
		InvokeAsync("Get_Func", new object[3] { uid, ds, returntype }, Get_FuncOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
	}

	private void OnGet_FuncOperationCompleted(object arg)
	{
		if (Get_FuncCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			Get_FuncCompleted?.Invoke(this, new Get_FuncCompletedEventArgs(e.Results, e.Error, e.Cancelled, RuntimeHelpers.GetObjectValue(e.UserState)));
		}
	}

	[SoapDocumentMethod("IDAT_WebSvr/WSFileInitialize", RequestNamespace = "IDAT_WebSvr", ResponseNamespace = "IDAT_WebSvr", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
	public WSFileInitResponse WSFileInitialize(int uid, WSFileInit Init)
	{
		object[] array = Invoke("WSFileInitialize", new object[2] { uid, Init });
		return (WSFileInitResponse)array[0];
	}

	public void WSFileInitializeAsync(int uid, WSFileInit Init)
	{
		WSFileInitializeAsync(uid, Init, null);
	}

	public void WSFileInitializeAsync(int uid, WSFileInit Init, object userState)
	{
		if (WSFileInitializeOperationCompleted == null)
		{
			WSFileInitializeOperationCompleted = OnWSFileInitializeOperationCompleted;
		}
		InvokeAsync("WSFileInitialize", new object[2] { uid, Init }, WSFileInitializeOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
	}

	private void OnWSFileInitializeOperationCompleted(object arg)
	{
		if (WSFileInitializeCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			WSFileInitializeCompleted?.Invoke(this, new WSFileInitializeCompletedEventArgs(e.Results, e.Error, e.Cancelled, RuntimeHelpers.GetObjectValue(e.UserState)));
		}
	}

	[SoapDocumentMethod("IDAT_WebSvr/UploadChunk", RequestNamespace = "IDAT_WebSvr", ResponseNamespace = "IDAT_WebSvr", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
	public WSFileUploadChunkResponse UploadChunk(int uid, WSFileChunk Chunk)
	{
		object[] array = Invoke("UploadChunk", new object[2] { uid, Chunk });
		return (WSFileUploadChunkResponse)array[0];
	}

	public void UploadChunkAsync(int uid, WSFileChunk Chunk)
	{
		UploadChunkAsync(uid, Chunk, null);
	}

	public void UploadChunkAsync(int uid, WSFileChunk Chunk, object userState)
	{
		if (UploadChunkOperationCompleted == null)
		{
			UploadChunkOperationCompleted = OnUploadChunkOperationCompleted;
		}
		InvokeAsync("UploadChunk", new object[2] { uid, Chunk }, UploadChunkOperationCompleted, RuntimeHelpers.GetObjectValue(userState));
	}

	private void OnUploadChunkOperationCompleted(object arg)
	{
		if (UploadChunkCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			UploadChunkCompleted?.Invoke(this, new UploadChunkCompletedEventArgs(e.Results, e.Error, e.Cancelled, RuntimeHelpers.GetObjectValue(e.UserState)));
		}
	}

	public new void CancelAsync(object userState)
	{
		base.CancelAsync(RuntimeHelpers.GetObjectValue(userState));
	}

	private bool IsLocalFileSystemWebService(string url)
	{
		if (url == null || (((object)url == string.Empty) ? true : false))
		{
			return false;
		}
		Uri uri = new Uri(url);
		if ((uri.Port >= 1024 && string.Compare(uri.Host, "localHost", StringComparison.OrdinalIgnoreCase) == 0) ? true : false)
		{
			return true;
		}
		return false;
	}
}
