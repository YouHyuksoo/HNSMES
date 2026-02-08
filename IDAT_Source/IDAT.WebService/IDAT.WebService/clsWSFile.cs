using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using IDAT.WebService.IDAT_WebSvr;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace IDAT.WebService;

public class clsWSFile
{
	public delegate void UploadedEventHandler(object sender, string val);

	public delegate void SendingEventHandler(object sender, WSFileSendEventArgs e);

	public delegate void SentEventHandler(object sender, WSFileSendEventArgs e);

	public delegate void ExceptionEventHandler(object sender, WSFileExceptionEventArgs e);

	private static List<WeakReference> __ENCList = new List<WeakReference>();

	[AccessedThroughProperty("_Websvr")]
	private IDAT.WebService.IDAT_WebSvr.IDAT_WebSvr __Websvr;

	private string _FilePath_Full;

	private WSFileUploadChunkResponse LastResponse;

	private WSFileChunk LastChunk;

	private string _Dir_Path;

	private int _chunkSize;

	private string _tag;

	private Stream _sourceStream;

	private WSFileState _state;

	private string _destinationFileName;

	private int _fileSize;

	internal virtual IDAT.WebService.IDAT_WebSvr.IDAT_WebSvr _Websvr
	{
		[DebuggerNonUserCode]
		get
		{
			return __Websvr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			WSFileInitializeCompletedEventHandler obj = FileUploader_WSFileInitializeCompleted;
			UploadChunkCompletedEventHandler obj2 = FileUploader_UploadChunkCompleted;
			if (__Websvr != null)
			{
				__Websvr.WSFileInitializeCompleted -= obj;
				__Websvr.UploadChunkCompleted -= obj2;
			}
			__Websvr = value;
			if (__Websvr != null)
			{
				__Websvr.WSFileInitializeCompleted += obj;
				__Websvr.UploadChunkCompleted += obj2;
			}
		}
	}

	public string Dir_Path
	{
		get
		{
			return _Dir_Path;
		}
		set
		{
			_Dir_Path = value;
		}
	}

	public int ChunkSize
	{
		get
		{
			return _chunkSize;
		}
		set
		{
			_chunkSize = value;
		}
	}

	public string Tag
	{
		get
		{
			string result = default(string);
			return result;
		}
		set
		{
			_tag = value;
		}
	}

	[Browsable(false)]
	public Stream SourceStream
	{
		get
		{
			return _sourceStream;
		}
		set
		{
			if (value == null)
			{
				return;
			}
			if (!value.CanRead)
			{
				throw new ApplicationException("Stream must be readable");
			}
			if (!value.CanSeek)
			{
				throw new ApplicationException("Stream must be seekable");
			}
			try
			{
				_fileSize = checked((int)value.Length);
				if (_fileSize < ChunkSize)
				{
					ChunkSize = FileSize;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				throw;
			}
			_sourceStream = value;
		}
	}

	public WSFileState State
	{
		get
		{
			return _state;
		}
		set
		{
			if (value == WSFileState.Uploading && _state == WSFileState.Paused)
			{
				_state = value;
				ResumeUpload();
			}
			else
			{
				_state = value;
			}
		}
	}

	public string DestinationFileName
	{
		get
		{
			return _destinationFileName;
		}
		set
		{
			_destinationFileName = value;
		}
	}

	public int FileSize => _fileSize;

	[method: DebuggerNonUserCode]
	public event EventHandler Uploading;

	[method: DebuggerNonUserCode]
	public event UploadedEventHandler Uploaded;

	[method: DebuggerNonUserCode]
	public event EventHandler Initializing;

	[method: DebuggerNonUserCode]
	public event EventHandler Initialized;

	[method: DebuggerNonUserCode]
	public event SendingEventHandler Sending;

	[method: DebuggerNonUserCode]
	public event SentEventHandler Sent;

	[method: DebuggerNonUserCode]
	public event ExceptionEventHandler Exception;

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

	public clsWSFile(string url)
	{
		__ENCAddToList(this);
		_chunkSize = 20000;
		_tag = "";
		try
		{
			_Websvr = new IDAT.WebService.IDAT_WebSvr.IDAT_WebSvr();
			_Websvr.Url = url;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox("IDATAppUpdater.xml Open error. ");
			ProjectData.ClearProjectError();
		}
	}

	public void Upload()
	{
		WSFileInit wSFileInit = new WSFileInit();
		State = WSFileState.Dormant;
		try
		{
			WSFileInit wSFileInit2 = wSFileInit;
			wSFileInit2.FileName = DestinationFileName;
			wSFileInit2.FileSize = FileSize;
			wSFileInit2.ChunkSize = ChunkSize;
			wSFileInit2.Tag = _tag;
			byte[] array = new byte[checked(FileSize - 1 + 1)];
			Stream sourceStream = SourceStream;
			sourceStream.Seek(0L, SeekOrigin.Begin);
			sourceStream.Read(array, 0, array.Length);
			wSFileInit.FileHash = WSFileSHA1Helper.HashBytes(array);
			sourceStream = null;
			array = new byte[1];
			wSFileInit2 = null;
			_Websvr.WSFileInitializeAsync(1, wSFileInit);
			Initializing?.Invoke(this, new EventArgs());
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			WSFileExceptionEventArgs e = new WSFileExceptionEventArgs(ex2.Message, ex2);
			Exception?.Invoke(this, e);
			ProjectData.ClearProjectError();
		}
	}

	private void ResumeUpload()
	{
		object[] results = new object[1] { LastResponse };
		UploadChunkCompletedEventArgs e = new UploadChunkCompletedEventArgs(results, null, cancelled: false, LastChunk);
		FileUploader_UploadChunkCompleted(this, e);
	}

	private void FileUploader_WSFileInitializeCompleted(object sender, WSFileInitializeCompletedEventArgs e)
	{
		if (!e.Result.OKToProceed)
		{
			WSFileExceptionEventArgs e2 = new WSFileExceptionEventArgs(e.Result.Message, new ApplicationException(e.Result.Message));
			Exception?.Invoke(this, e2);
			return;
		}
		Initialized?.Invoke(this, new EventArgs());
		try
		{
			WSFileChunk wSFileChunk = new WSFileChunk();
			WSFileChunk wSFileChunk2 = wSFileChunk;
			wSFileChunk2.FileName = e.Result.FileName;
			wSFileChunk2.ChunkSize = ChunkSize;
			wSFileChunk2.LastChunkSent = 0;
			wSFileChunk2.FileSize = FileSize;
			wSFileChunk2.Tag = _tag;
			byte[] chunkData = new byte[checked(wSFileChunk2.ChunkSize - 1 + 1)];
			wSFileChunk2.ChunkData = chunkData;
			Stream sourceStream = SourceStream;
			sourceStream.Seek(0L, SeekOrigin.Begin);
			sourceStream.Read(wSFileChunk.ChunkData, 0, wSFileChunk.ChunkData.Length);
			sourceStream = null;
			WSFileSendEventArgs e3 = new WSFileSendEventArgs(wSFileChunk.ThisChunkNumber, wSFileChunk.TotalChunks, wSFileChunk.ChunkData);
			Sending?.Invoke(this, e3);
			wSFileChunk2.ChunkHashCode = WSFileSHA1Helper.HashBytes(wSFileChunk2.ChunkData);
			wSFileChunk2.ThisChunkNumber = 1;
			wSFileChunk2.TotalChunks = wSFileChunk2.FileSize / wSFileChunk2.ChunkSize;
			if (wSFileChunk2.FileSize % wSFileChunk2.ChunkSize > 0)
			{
				checked
				{
					wSFileChunk2.TotalChunks++;
				}
			}
			wSFileChunk2 = null;
			State = WSFileState.Uploading;
			_Websvr.UploadChunkAsync(1, wSFileChunk, wSFileChunk);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			WSFileExceptionEventArgs e4 = new WSFileExceptionEventArgs(e.Result.Message, ex2);
			Exception?.Invoke(this, e4);
			ProjectData.ClearProjectError();
		}
	}

	private void FileUploader_UploadChunkCompleted(object sender, UploadChunkCompletedEventArgs e)
	{
		if (!e.Result.OKToProceed)
		{
			WSFileExceptionEventArgs e2 = new WSFileExceptionEventArgs(e.Result.Message, new ApplicationException(e.Result.Message));
			Exception?.Invoke(this, e2);
			return;
		}
		switch ((int)State)
		{
		case 2:
			LastResponse = e.Result;
			LastChunk = (WSFileChunk)e.UserState;
			return;
		case 0:
			LastChunk = null;
			LastResponse = null;
			return;
		}
		checked
		{
			try
			{
				WSFileChunk wSFileChunk = (WSFileChunk)e.UserState;
				WSFileSendEventArgs e3 = new WSFileSendEventArgs(wSFileChunk.ThisChunkNumber, wSFileChunk.TotalChunks, wSFileChunk.ChunkData);
				Sent?.Invoke(this, e3);
				WSFileChunk wSFileChunk2 = wSFileChunk;
				if (wSFileChunk2.ThisChunkNumber == wSFileChunk2.TotalChunks)
				{
					State = WSFileState.Dormant;
					SourceStream.Close();
					Uploaded?.Invoke(this, e.Result.Message);
					return;
				}
				wSFileChunk2.LastChunkSent = wSFileChunk2.ThisChunkNumber;
				wSFileChunk2.ThisChunkNumber++;
				if (wSFileChunk2.ThisChunkNumber == wSFileChunk2.TotalChunks)
				{
					byte[] chunkData = new byte[unchecked(wSFileChunk2.FileSize % wSFileChunk2.ChunkSize) - 1 + 1];
					wSFileChunk2.ChunkData = chunkData;
				}
				int num = wSFileChunk.ChunkSize * (wSFileChunk.ThisChunkNumber - 1);
				Stream sourceStream = SourceStream;
				sourceStream.Seek(num, SeekOrigin.Begin);
				sourceStream.Read(wSFileChunk.ChunkData, 0, wSFileChunk.ChunkData.Length);
				sourceStream = null;
				e3 = new WSFileSendEventArgs(wSFileChunk.ThisChunkNumber, wSFileChunk.TotalChunks, wSFileChunk.ChunkData);
				Sending?.Invoke(this, e3);
				wSFileChunk2.ChunkHashCode = WSFileSHA1Helper.HashBytes(wSFileChunk2.ChunkData);
				wSFileChunk2 = null;
				_Websvr.UploadChunkAsync(1, wSFileChunk, wSFileChunk);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				WSFileExceptionEventArgs e4 = new WSFileExceptionEventArgs(e.Result.Message, ex2);
				Exception?.Invoke(this, e4);
				ProjectData.ClearProjectError();
			}
		}
	}
}
