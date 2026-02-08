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
public class WSFileInit
{
	private string fileNameField;

	private int fileSizeField;

	private int chunkSizeField;

	private byte[] fileHashField;

	private string tagField;

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

	public int FileSize
	{
		get
		{
			return fileSizeField;
		}
		set
		{
			fileSizeField = value;
		}
	}

	public int ChunkSize
	{
		get
		{
			return chunkSizeField;
		}
		set
		{
			chunkSizeField = value;
		}
	}

	[XmlElement(DataType = "base64Binary")]
	public byte[] FileHash
	{
		get
		{
			return fileHashField;
		}
		set
		{
			fileHashField = value;
		}
	}

	public string Tag
	{
		get
		{
			return tagField;
		}
		set
		{
			tagField = value;
		}
	}

	[DebuggerNonUserCode]
	public WSFileInit()
	{
	}
}
