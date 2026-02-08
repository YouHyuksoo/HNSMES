using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace IDAT.WebService.IDAT_WebSvr;

[Serializable]
[XmlType(Namespace = "IDAT_WebSvr")]
[DebuggerStepThrough]
[GeneratedCode("System.Xml", "4.0.30319.233")]
[DesignerCategory("code")]
public class WSFileUploadChunkResponse
{
	private string messageField;

	private bool oKToProceedField;

	private int reSendChunkNumberField;

	private int chunkNumberJustReceivedField;

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

	public int ReSendChunkNumber
	{
		get
		{
			return reSendChunkNumberField;
		}
		set
		{
			reSendChunkNumberField = value;
		}
	}

	public int ChunkNumberJustReceived
	{
		get
		{
			return chunkNumberJustReceivedField;
		}
		set
		{
			chunkNumberJustReceivedField = value;
		}
	}

	[DebuggerNonUserCode]
	public WSFileUploadChunkResponse()
	{
	}
}
