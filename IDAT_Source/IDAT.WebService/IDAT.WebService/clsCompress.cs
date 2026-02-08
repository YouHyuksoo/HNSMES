using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.VisualBasic.CompilerServices;

namespace IDAT.WebService;

public class clsCompress
{
	[DebuggerNonUserCode]
	public clsCompress()
	{
	}

	public byte[] CompressDataSet(DataSet Ds)
	{
		Ds.RemotingFormat = SerializationFormat.Binary;
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		MemoryStream memoryStream = new MemoryStream();
		binaryFormatter.Serialize(memoryStream, Ds);
		byte[] array = memoryStream.ToArray();
		MemoryStream memoryStream2 = new MemoryStream();
		DeflateStream deflateStream = new DeflateStream(memoryStream2, CompressionMode.Compress);
		deflateStream.Write(array, 0, array.Length);
		deflateStream.Flush();
		deflateStream.Close();
		return memoryStream2.ToArray();
	}

	public DataSet DecompressDataSet(byte[] bytDs)
	{
		DataSet result;
		try
		{
			DataSet dataSet = new DataSet();
			MemoryStream memoryStream = new MemoryStream(bytDs);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Decompress, leaveOpen: true);
			byte[] buffer = ReadFullStream(deflateStream);
			deflateStream.Flush();
			deflateStream.Close();
			MemoryStream memoryStream2 = new MemoryStream(buffer);
			memoryStream2.Seek(0L, SeekOrigin.Begin);
			dataSet.RemotingFormat = SerializationFormat.Binary;
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			dataSet = (DataSet)binaryFormatter.Deserialize(memoryStream2, null);
			result = dataSet;
		}
		catch (NullReferenceException ex)
		{
			ProjectData.SetProjectError(ex);
			NullReferenceException ex2 = ex;
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public byte[] ReadFullStream(Stream stream)
	{
		byte[] array = new byte[32769];
		byte[] result;
		try
		{
			using MemoryStream memoryStream = new MemoryStream();
			while (true)
			{
				int num = stream.Read(array, 0, array.Length);
				if (num <= 0)
				{
					break;
				}
				memoryStream.Write(array, 0, num);
			}
			result = memoryStream.ToArray();
		}
		catch (NullReferenceException ex)
		{
			ProjectData.SetProjectError(ex);
			NullReferenceException ex2 = ex;
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}
}
