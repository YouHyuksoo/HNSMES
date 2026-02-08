namespace IDAT_Common.Serial;

public class PrintBarcode
{
	private IDATSerialPort mClassSerialPort;

	public PrintBarcode()
	{
		mClassSerialPort = new IDATSerialPort();
	}

	public bool printBarcode(string CommandStr, bool bClosePort, int iSleep = 50)
	{
		if (!mClassSerialPort.OpenSerialPort())
		{
			return false;
		}
		if (mClassSerialPort.WriteDate(CommandStr, iSleep))
		{
			mClassSerialPort.CloseSerialPort();
			return true;
		}
		return false;
	}
}
