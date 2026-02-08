namespace IDAT_Common.Serial;

public class ScanBarcode
{
	private IDATSerialPort mClassSerialPort;

	private string mDataReceived = string.Empty;

	public ScanBarcode()
	{
		mClassSerialPort = new IDATSerialPort();
	}

	public bool StartScanBarcode()
	{
		if (!mClassSerialPort.OpenSerialPort())
		{
			return false;
		}
		return true;
	}

	public bool StopScanBarcode()
	{
		if (!mClassSerialPort.CloseSerialPort())
		{
			return false;
		}
		return true;
	}
}
