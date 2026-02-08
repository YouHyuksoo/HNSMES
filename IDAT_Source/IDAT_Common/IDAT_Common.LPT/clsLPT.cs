using System;
using System.Runtime.InteropServices;
using System.Text;

namespace IDAT_Common.LPT;

internal class clsLPT
{
	private const uint GENERIC_READ = 2147483648u;

	private const uint GENERIC_WRITE = 1073741824u;

	private const uint OPEN_EXISTING = 3u;

	private IntPtr handle;

	[DllImport("kernel32", SetLastError = true)]
	private static extern IntPtr CreateFile(string FileName, uint DesiredAccess, uint ShareMode, uint SecurityAttributes, uint CreationDisposition, uint FlagsAndAttributes, int hTemplateFile);

	[DllImport("kernel32", SetLastError = true)]
	private unsafe static extern bool ReadFile(IntPtr hFile, void* pBuffer, int NumberOfBytesToRead, int* pNumberOfBytesRead, int Overlapped);

	[DllImport("kernel32", SetLastError = true)]
	private unsafe static extern bool WriteFile(IntPtr hFile, void* pBuffer, int nBytesToWrite, int* nBytesWritten, int Overlapped);

	[DllImport("kernel32", SetLastError = true)]
	private static extern int GetLastError();

	[DllImport("kernel32", SetLastError = true)]
	private static extern bool CloseHandle(IntPtr hObject);

	public bool Open(string FileName)
	{
		handle = CreateFile(FileName, 3221225472u, 0u, 0u, 3u, 0u, 0);
		if (handle != IntPtr.Zero)
		{
			return true;
		}
		return false;
	}

	public unsafe int Write(string cont)
	{
		int num = 0;
		int result = 0;
		int length = cont.Length;
		ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
		fixed (byte* bytes = aSCIIEncoding.GetBytes(cont))
		{
			num = 0;
			if (!WriteFile(handle, bytes + num, length + 1, &result, 0))
			{
				return 0;
			}
		}
		return result;
	}

	public bool Close()
	{
		return CloseHandle(handle);
	}
}
