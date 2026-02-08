using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace IDAT.WebService.IDAT_WebSvr;

[DesignerCategory("code")]
[DebuggerStepThrough]
[GeneratedCode("System.Web.Services", "4.0.30319.1")]
public class WSFileInitializeCompletedEventArgs : AsyncCompletedEventArgs
{
	private object[] results;

	public WSFileInitResponse Result
	{
		get
		{
			RaiseExceptionIfNecessary();
			return (WSFileInitResponse)results[0];
		}
	}

	internal WSFileInitializeCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState)
		: base(exception, cancelled, RuntimeHelpers.GetObjectValue(userState))
	{
		this.results = results;
	}
}
