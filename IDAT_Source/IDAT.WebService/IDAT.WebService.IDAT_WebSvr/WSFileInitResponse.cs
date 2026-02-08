using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace IDAT.WebService.IDAT_WebSvr;

[Serializable]
[GeneratedCode("System.Xml", "4.0.30319.233")]
[XmlType(Namespace = "IDAT_WebSvr")]
[DesignerCategory("code")]
[DebuggerStepThrough]
public class WSFileInitResponse
{
	private string messageField;

	private bool oKToProceedField;

	private string uploaderIDField;

	private string fileNameField;

	public string Message
	{
		get
		{
			return messageField;
		}
		set
		{
			messageField = value;
		}
	}

	public bool OKToProceed
	{
		get
		{
			return oKToProceedField;
		}
		set
		{
			oKToProceedField = value;
		}
	}

	public string UploaderID
	{
		get
		{
			return uploaderIDField;
		}
		set
		{
			uploaderIDField = value;
		}
	}

	public string FileName
	{
		get
		{
			return fileNameField;
		}
		set
		{
			fileNameField = value;
		}
	}

	[DebuggerNonUserCode]
	public WSFileInitResponse()
	{
	}
}
