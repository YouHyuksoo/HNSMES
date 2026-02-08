using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace IDAT.WebService.client;

internal class TimeOutSocket
{
	private static bool IsConnectionSuccessful = false;

	private static Exception socketexception;

	private static ManualResetEvent TimeoutObject = new ManualResetEvent(initialState: false);

	[DebuggerNonUserCode]
	public TimeOutSocket()
	{
	}

	public static TcpClient Connect(IPEndPoint remoteEndPoint, int timeoutMSec)
	{
		TimeoutObject.Reset();
		socketexception = null;
		string host = Convert.ToString(remoteEndPoint.Address);
		int port = remoteEndPoint.Port;
		TcpClient tcpClient = new TcpClient();
		tcpClient.BeginConnect(host, port, CallBackMethod, tcpClient);
		if (TimeoutObject.WaitOne(timeoutMSec, exitContext: false))
		{
			if (IsConnectionSuccessful)
			{
				return tcpClient;
			}
			return tcpClient;
		}
		tcpClient.Close();
		throw new TimeoutException("TimeOut Exception");
	}

	public static TcpClient Connect(string IpAddr, string port, int timeoutMSec)
	{
		TimeoutObject.Reset();
		socketexception = null;
		int port2 = Conversions.ToInteger(port);
		TcpClient tcpClient = new TcpClient();
		tcpClient.BeginConnect(IpAddr, port2, CallBackMethod, tcpClient);
		if (TimeoutObject.WaitOne(timeoutMSec, exitContext: false))
		{
			if (IsConnectionSuccessful)
			{
				return tcpClient;
			}
			return tcpClient;
		}
		tcpClient.Close();
		throw new TimeoutException("TimeOut Exception");
	}

	private static void CallBackMethod(IAsyncResult asyncresult)
	{
		try
		{
			IsConnectionSuccessful = false;
			TcpClient tcpClient = asyncresult.AsyncState as TcpClient;
			if (tcpClient.Client != null)
			{
				tcpClient.EndConnect(asyncresult);
				IsConnectionSuccessful = true;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			IsConnectionSuccessful = false;
			socketexception = ex2;
			ProjectData.ClearProjectError();
		}
		finally
		{
			TimeoutObject.Set();
		}
	}
}
