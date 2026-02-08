using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace IDAT.WebService.IDAT_WebSvr;

[GeneratedCode("System.Web.Services", "4.0.30319.1")]
[DesignerCategory("code")]
[DebuggerStepThrough]
public class CloseWebServiceCompletedEventArgs : AsyncCompletedEventArgs
{
	private object[] results;

	public int Result
	{
		get
		{
			RaiseExceptionIfNecessary();
			return Conversions.ToInteger(results[0]);
		}
	}

	internal CloseWebServiceCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState)
		: base(exception, cancelled, RuntimeHelpers.GetObjectValue(userState))
	{
		this.results = results;
	}
}
