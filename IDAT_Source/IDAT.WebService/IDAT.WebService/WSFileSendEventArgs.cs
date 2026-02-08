using System;

namespace IDAT.WebService;

public class WSFileSendEventArgs : EventArgs
{
	private int _chunkNumber;

	private int _totalChunks;

	private byte[] _chunkData;

	public int ChunkNumber => _chunkNumber;

	public int TotalChunks => _totalChunks;

	public byte[] ChunkData
	{
		get
		{
			return _chunkData;
		}
		set
		{
			_chunkData = value;
		}
	}

	public int PercentComplete
	{
		get
		{
			if (TotalChunks <= 0)
			{
				return 0;
			}
			if (ChunkNumber <= 0)
			{
				return 0;
			}
			return checked(ChunkNumber * 100) / TotalChunks;
		}
	}

	public WSFileSendEventArgs(int ChunkNumber, int TotalChunks, byte[] ChunkData)
	{
		_chunkNumber = ChunkNumber;
		_totalChunks = TotalChunks;
		_chunkData = ChunkData;
	}
}
