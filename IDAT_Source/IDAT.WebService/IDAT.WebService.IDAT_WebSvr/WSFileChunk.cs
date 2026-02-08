using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace IDAT.WebService.IDAT_WebSvr;

[Serializable]
[XmlType(Namespace = "IDAT_WebSvr")]
[GeneratedCode("System.Xml", "4.0.30319.233")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class WSFileChunk
{
	private string uploaderIDField;

	private string fileNameField;

	private int fileSizeField;

	private int totalChunksField;

	private int chunkSizeField;

	private int lastChunkSentField;

	private int thisChunkNumberField;

	private byte[] chunkHashCodeField;

	private byte[] chunkDataField;

	private string filePathField;

	private string tagField;

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

	public int TotalChunks
	{
		get
		{
			return totalChunksField;
		}
		set
		{
			totalChunksField = value;
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

	public int LastChunkSent
	{
		get
		{
			return lastChunkSentField;
		}
		set
		{
			lastChunkSentField = value;
		}
	}

	public int ThisChunkNumber
	{
		get
		{
			return thisChunkNumberField;
		}
		set
		{
			thisChunkNumberField = value;
		}
	}

	[XmlElement(DataType = "base64Binary")]
	public byte[] ChunkHashCode
	{
		get
		{
			return chunkHashCodeField;
		}
		set
		{
			chunkHashCodeField = value;
		}
	}

	[XmlElement(DataType = "base64Binary")]
	public byte[] ChunkData
	{
		get
		{
			return chunkDataField;
		}
		set
		{
			chunkDataField = value;
		}
	}

	public string FilePath
	{
		get
		{
			return filePathField;
		}
		set
		{
			filePathField = value;
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
	public WSFileChunk()
	{
	}
}
