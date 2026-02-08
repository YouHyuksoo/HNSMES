using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace IDAT.WebService.IDAT_WebSvr;

[DebuggerStepThrough]
[GeneratedCode("System.Web.Services", "4.0.30319.1")]
[DesignerCategory("code")]
public class UploadChunkCompletedEventArgs : AsyncCompletedEventArgs
{
	private object[] results;

	public WSFileUploadChunkResponse Result
	{
		get
		{
			RaiseExceptionIfNecessary();
			return (WSFileUploadChunkResponse)results[0];
		}
	}

	internal UploadChunkCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState)
		: base(exception, cancelled, RuntimeHelpers.GetObjectValue(userState))
	{
		this.results = results;
	}
}
