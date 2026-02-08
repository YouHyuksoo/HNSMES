using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace IDAT.Devexpress.ActionDemo;

public class ActiveActionsImports
{
	public class Msg
	{
		public uint hWnd;

		public uint Message;

		public uint wParam;

		public uint lParam;

		public uint time;

		public IntPtr pt;
	}

	public const uint PM_NOREMOVE = 0u;

	public const uint WM_MOUSEFIRST = 512u;

	public const uint WM_MOUSELAST = 522u;

	public const int WM_KEYDOWN = 256;

	public const int WM_KEYUP = 257;

	public const int WM_CHAR = 258;

	public const int WM_ACTIVATEAPP = 28;

	public static bool CapsIsPressed
	{
		get
		{
			return GetKeyPressed(Keys.Capital);
		}
		set
		{
			SetKeyPressed(Keys.Capital, value);
		}
	}

	[DllImport("user32.dll", EntryPoint = "SendInput")]
	public static extern uint SendMouseInput(int nInputs, [MarshalAs(UnmanagedType.LPArray)] MouseInputArgs[] pInputs, int cbSize);

	[DllImport("user32.dll", EntryPoint = "SendInput")]
	public static extern uint SendKeyInput(int nInputs, [MarshalAs(UnmanagedType.LPArray)] KeyInputArgs[] pInputs, int cbSize);

	[DllImport("kernel32.dll")]
	public static extern uint GetLastError();

	[DllImport("user32.dll")]
	public static extern uint MapVirtualKey(uint uCode, uint uMapType);

	[DllImport("user32.dll")]
	public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, IntPtr dwExtraInfo);

	[DllImport("user32.dll")]
	public static extern uint PeekMessage(Msg msg, IntPtr hWnd, uint firstMessage, uint lastMessage, uint options);

	[DllImport("user32.dll")]
	internal static extern int SendMessage(IntPtr hWnd, int Msg, uint wParam, uint lParam);

	[DllImport("user32.dll")]
	internal static extern int PostMessage(IntPtr hWnd, int Msg, uint wParam, uint lParam);

	[DllImport("user32.dll")]
	public static extern short GetKeyState(int keyCode);

	[DllImport("user32.dll")]
	public static extern bool SetKeyboardState([MarshalAs(UnmanagedType.LPArray)] byte[] bytes);

	[DllImport("user32.dll")]
	public static extern bool GetKeyboardState(byte[] bytes);

	[DllImport("user32.dll")]
	public static extern IntPtr GetActiveWindow();

	[DllImport("user32.dll")]
	public static extern IntPtr WindowFromPoint(Point point);

	[DllImport("user32.dll")]
	public static extern uint GetWindowThreadProcessId(IntPtr hWnd, ref int lpdwProcessId);

	[DllImport("kernel32.dll")]
	public static extern uint GetCurrentThreadId();

	public static bool GetKeyPressed(Keys key)
	{
		uint keyValue = GetKeyValue(key);
		if (keyValue > 255)
		{
			return false;
		}
		byte[] array = new byte[255];
		if (GetKeyboardState(array))
		{
			return array[keyValue] != 0;
		}
		return false;
	}

	public static void SetKeyPressed(Keys key, bool value)
	{
		uint keyValue = GetKeyValue(key);
		if (keyValue > 255)
		{
			return;
		}
		byte[] array = new byte[255];
		if (GetKeyboardState(array))
		{
			if (value)
			{
				array[keyValue] = 128;
			}
			else
			{
				array[keyValue] = 0;
			}
			SetKeyboardState(array);
		}
	}

	public static uint GetKeyValue(Keys key)
	{
		if (IsSealedKey(key))
		{
			return (uint)GetSealedKeyValue(key);
		}
		return (uint)(key & Keys.KeyCode);
	}

	public static bool IsSealedKey(Keys key)
	{
		return GetSealedKeyValue(key) > -1;
	}

	public static int GetSealedKeyValue(Keys key)
	{
		Array values = Enum.GetValues(typeof(InputSealedKey));
		int i;
		for (i = 0; i < values.Length && (Keys)values.GetValue(i) != key; i++)
		{
		}
		if (i < values.Length)
		{
			values = Enum.GetValues(typeof(InputSealedKeyValue));
			return (int)values.GetValue(i);
		}
		return -1;
	}
}
