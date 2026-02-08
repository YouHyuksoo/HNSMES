using System.Collections;
using System.IO.Ports;
using System.Text;
using System.Threading;
using Microsoft.Win32;

namespace IDAT_Common.Serial;

public class IDATSerialPort
{
	public delegate void DataReceivedEventHandler(string Data);

	private SerialPort mSerialPort = new SerialPort();

	public event DataReceivedEventHandler DataReceived;

	public IDATSerialPort()
	{
		SerialPort serialPort = new SerialPort();
	}

	public void mSerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
	{
		if (this.DataReceived != null)
		{
			this.DataReceived(mSerialPort.ReadExisting());
		}
	}

	public bool SetPortProperty(string Port, int baud, Parity parity, StopBits stopBits, int dataBit)
	{
		try
		{
			if (Port.Length == 0)
			{
				return false;
			}
			if (!IsAvailableSerialPort(Port))
			{
				return false;
			}
			mSerialPort.PortName = Port;
			mSerialPort.BaudRate = baud;
			mSerialPort.Parity = parity;
			mSerialPort.StopBits = stopBits;
			mSerialPort.DataBits = dataBit;
			mSerialPort.RtsEnable = true;
			mSerialPort.Handshake = Handshake.XOnXOff;
			if (mSerialPort.IsOpen)
			{
				mSerialPort.Close();
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	public bool OpenSerialPort()
	{
		try
		{
			if (mSerialPort.IsOpen)
			{
				mSerialPort.Close();
			}
			mSerialPort.Open();
			return true;
		}
		catch
		{
			return false;
		}
	}

	public bool CloseSerialPort()
	{
		try
		{
			if (mSerialPort.IsOpen)
			{
				mSerialPort.Close();
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	public bool WriteDate(string Data, int An_Sleep)
	{
		try
		{
			mSerialPort.Write(Encoding.Default.GetBytes(Data), 0, Encoding.Default.GetBytes(Data).Length);
			Thread.Sleep(An_Sleep);
			return true;
		}
		catch
		{
			return false;
		}
	}

	public ArrayList GetAvailableSerialPort()
	{
		SerialPort serialPort = new SerialPort();
		ArrayList arrayList = new ArrayList();
		string[] portNames = SerialPort.GetPortNames();
		foreach (string portName in portNames)
		{
			try
			{
				serialPort.PortName = portName;
				if (serialPort.IsOpen)
				{
					serialPort.Close();
				}
				arrayList.Add(serialPort.PortName);
			}
			catch
			{
				if (serialPort.IsOpen)
				{
					serialPort.Close();
				}
			}
		}
		return arrayList;
	}

	public bool IsAvailableSerialPort(string PortName)
	{
		SerialPort serialPort = new SerialPort();
		try
		{
			serialPort.PortName = PortName;
			if (serialPort.IsOpen)
			{
				serialPort.Close();
			}
			serialPort.Open();
			serialPort.Close();
			return true;
		}
		catch
		{
			if (serialPort.IsOpen)
			{
				serialPort.Close();
			}
			return false;
		}
	}

	public bool HasCommPort(string p_strPort)
	{
		bool result = false;
		RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("HARDWARE\\DEVICEMAP\\SERIALCOMM");
		try
		{
			if (registryKey != null)
			{
				string[] valueNames = registryKey.GetValueNames();
				foreach (string name in valueNames)
				{
					if (string.Concat(registryKey.GetValue(name)) == p_strPort)
					{
						result = true;
						break;
					}
				}
				registryKey.Close();
			}
		}
		catch
		{
		}
		return result;
	}
}
