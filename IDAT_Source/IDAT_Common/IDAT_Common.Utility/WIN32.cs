using System;
using System.Runtime.InteropServices;
using System.Text;

namespace IDAT_Common.Utility;

public class WIN32
{
	public struct SYSTEMTIME
	{
		[MarshalAs(UnmanagedType.U2)]
		public short Year;

		[MarshalAs(UnmanagedType.U2)]
		public short Month;

		[MarshalAs(UnmanagedType.U2)]
		public short DayOfWeek;

		[MarshalAs(UnmanagedType.U2)]
		public short Day;

		[MarshalAs(UnmanagedType.U2)]
		public short Hour;

		[MarshalAs(UnmanagedType.U2)]
		public short Minute;

		[MarshalAs(UnmanagedType.U2)]
		public short Second;

		[MarshalAs(UnmanagedType.U2)]
		public short Milliseconds;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct NETRESOURCE
	{
		public uint dwScope;

		public uint dwType;

		public uint dwDisplayType;

		public uint dwUsage;

		public string lpLocalName;

		public string lpRemoteName;

		public string lpComment;

		public string lpProvider;
	}

	[DllImport("User32.dll")]
	public static extern short GetKeyboardState(byte[] nVirtualKey);

	[DllImport("Kernel32.dll")]
	public static extern void GetSystemTime(ref SYSTEMTIME IpSystemTime);

	[DllImport("Kernel32.dll")]
	public static extern uint SetSystemTime(ref SYSTEMTIME IpSystemTime);

	public static SYSTEMTIME GetTime()
	{
		SYSTEMTIME IpSystemTime = default(SYSTEMTIME);
		GetSystemTime(ref IpSystemTime);
		return IpSystemTime;
	}

	public static void SetTime(SYSTEMTIME systime)
	{
		SetSystemTime(ref systime);
	}

	[DllImport("mpr.dll", CharSet = CharSet.Auto)]
	public static extern int WNetUseConnection(IntPtr hwndOwner, [MarshalAs(UnmanagedType.Struct)] ref NETRESOURCE lpNetResource, string lpPassword, string lpUserID, uint dwFlags, StringBuilder lpAccessName, ref int lpBufferSize, out uint lpResult);
}
