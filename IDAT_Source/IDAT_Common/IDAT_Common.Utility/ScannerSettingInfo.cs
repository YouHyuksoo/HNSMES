namespace IDAT_Common.Utility;

public class ScannerSettingInfo
{
	private bool mUseFlag = false;

	private string mComport = "";

	private string mBaudRate = "";

	private string mParityBit = "";

	private string mDataBit = "";

	private string mStopBit = "";

	private string mFlowControl = "";

	public bool UseFlag
	{
		get
		{
			return mUseFlag;
		}
		set
		{
			if (mUseFlag != value)
			{
				mUseFlag = value;
			}
		}
	}

	public string Comport
	{
		get
		{
			return mComport;
		}
		set
		{
			if (!(mComport == value))
			{
				mComport = value;
			}
		}
	}

	public string BaudRate
	{
		get
		{
			return mBaudRate;
		}
		set
		{
			if (!(mBaudRate == value))
			{
				mBaudRate = value;
			}
		}
	}

	public string ParityBit
	{
		get
		{
			return mParityBit;
		}
		set
		{
			if (!(mParityBit == value))
			{
				mParityBit = value;
			}
		}
	}

	public string DataBit
	{
		get
		{
			return mDataBit;
		}
		set
		{
			if (!(mDataBit == value))
			{
				mDataBit = value;
			}
		}
	}

	public string StopBit
	{
		get
		{
			return mStopBit;
		}
		set
		{
			if (!(mStopBit == value))
			{
				mStopBit = value;
			}
		}
	}

	public string FlowControl
	{
		get
		{
			return mFlowControl;
		}
		set
		{
			if (!(mFlowControl == value))
			{
				mFlowControl = value;
			}
		}
	}
}
