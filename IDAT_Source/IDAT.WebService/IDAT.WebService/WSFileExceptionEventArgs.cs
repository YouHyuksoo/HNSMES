using System;

namespace IDAT.WebService;

public class WSFileExceptionEventArgs : EventArgs
{
	private string _message;

	private Exception _ex;

	public string Message => _message;

	public Exception ex => _ex;

	public WSFileExceptionEventArgs(string Message, Exception ex)
	{
		_message = Message;
		_ex = ex;
	}
}
