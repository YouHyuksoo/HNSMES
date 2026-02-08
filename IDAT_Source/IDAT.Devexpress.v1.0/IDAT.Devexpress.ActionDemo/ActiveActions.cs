using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Utils;

namespace IDAT.Devexpress.ActionDemo;

public class ActiveActions : IMessageFilter, IDisposable
{
	private class WndForm : Form
	{
		private ActiveActions ActiveActions;

		public WndForm(ActiveActions ActiveActions)
		{
			this.ActiveActions = ActiveActions;
			base.StartPosition = FormStartPosition.Manual;
			base.FormBorderStyle = FormBorderStyle.None;
			base.ShowInTaskbar = false;
			base.Width = 1;
			base.Height = 1;
			base.Left = -100;
			base.Top = -100;
		}

		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			if (m.Msg == 28 && !ActiveActions.Canceled)
			{
				ActiveActions.CancelMode = ActiveActionsCancelMode.ApplicationDeactivated;
			}
		}
	}

	private const int DefaultMouseMoveDelay = 10;

	private const int DefaultMouseMoveDelayPerPixels = 3;

	private const int DefaultKeyboardDelay = 200;

	private const uint MOUSEEVENTF_MOVE = 1u;

	private const uint MOUSEEVENTF_LEFTDOWN = 2u;

	private const uint MOUSEEVENTF_LEFTUP = 4u;

	private const uint MOUSEEVENTF_RIGHTDOWN = 8u;

	private const uint MOUSEEVENTF_RIGHTUP = 16u;

	private const uint MOUSEEVENTF_MIDDLEDOWN = 32u;

	private const uint MOUSEEVENTF_MIDDLEUP = 64u;

	private const uint MOUSEEVENTF_ABSOLUTE = 32768u;

	private ToolTipController toolTipCancelOnEscape;

	private ActiveActionsCancelMode canceleMode;

	private WndForm wndForm;

	private bool keyActiveActionsProccessing;

	public bool Canceled => CancelMode != ActiveActionsCancelMode.None;

	public ActiveActionsCancelMode CancelMode
	{
		get
		{
			return canceleMode;
		}
		set
		{
			canceleMode = value;
		}
	}

	private static Control ActiveControl
	{
		get
		{
			if (Form.ActiveForm != null)
			{
				return Form.ActiveForm.ActiveControl;
			}
			return null;
		}
	}

	private void InitProperties()
	{
		toolTipCancelOnEscape = new ToolTipController();
	}

	public ActiveActions()
	{
		InitProperties();
		canceleMode = ActiveActionsCancelMode.None;
		Application.AddMessageFilter(this);
		wndForm = new WndForm(this);
		wndForm.Show();
	}

	public virtual void Dispose()
	{
		Application.RemoveMessageFilter(this);
		wndForm.Hide();
		wndForm.Dispose();
		wndForm = null;
	}

	public static void DoEvents()
	{
		SendKeys.Flush();
		Application.DoEvents();
	}

	public void SendKey(Control control, char key)
	{
		if (!Canceled)
		{
			SendKeyCore((control != null) ? control : ActiveControl, key);
			SendKeys.Flush();
		}
	}

	public void SendString(Control control, string keys)
	{
		if (!Canceled)
		{
			SendStringCore((control != null) ? control : ActiveControl, keys);
			SendKeys.Flush();
		}
	}

	public void MoveMousePointTo(Control control, Point pt)
	{
		Point pt2 = control?.PointToScreen(pt) ?? pt;
		MoveMousePointTo(pt2);
	}

	public void MoveMousePointTo(Point pt)
	{
		try
		{
			if (Canceled)
			{
				return;
			}
			int num = 0;
			int num2 = 1;
			int num3 = 1;
			while (!Cursor.Position.Equals(pt) && !Canceled)
			{
				Point position = Cursor.Position;
				int num4 = position.X - pt.X;
				int num5 = position.Y - pt.Y;
				double num6 = ((num5 != 0) ? Math.Abs((double)num4 / (double)num5) : 1.0);
				double num7 = ((num4 != 0) ? Math.Abs((double)num5 / (double)num4) : 1.0);
				if (position.X == pt.X || num6 * (double)num2++ <= 1.0)
				{
					num4 = 0;
				}
				else
				{
					num4 = ((position.X < pt.X) ? 1 : (-1));
					num2 = 1;
				}
				if (position.Y == pt.Y || num7 * (double)num3++ <= 1.0)
				{
					num5 = 0;
				}
				else
				{
					num5 = ((position.Y < pt.Y) ? 1 : (-1));
					num3 = 1;
				}
				position.X += num4;
				position.Y += num5;
				Cursor.Position = position;
				uint dx = Convert.ToUInt32(65536.0 * (double)position.X / (double)Screen.PrimaryScreen.Bounds.Width + 65536.0 / (double)Screen.PrimaryScreen.Bounds.Width / 2.0);
				uint dy = Convert.ToUInt32(65536.0 * (double)position.Y / (double)Screen.PrimaryScreen.Bounds.Height + 65536.0 / (double)Screen.PrimaryScreen.Bounds.Height / 2.0);
				ActiveActionsImports.mouse_event(32769u, dx, dy, 0u, IntPtr.Zero);
				DoEvents();
				if (num++ == 3)
				{
					Delay(10);
					num = 0;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void MouseClick()
	{
		MouseClick(MouseButtons.Left);
	}

	public void MouseClick(MouseButtons mouseButtons)
	{
		MouseClick(Cursor.Position, mouseButtons);
	}

	public void MouseClick(Control control, Point pt)
	{
		MouseClick(control, pt, MouseButtons.Left);
	}

	public void MouseClick(Control control, Point pt, MouseButtons mouseButtons)
	{
		Point pt2 = control?.PointToScreen(pt) ?? pt;
		MouseClick(pt2, mouseButtons);
	}

	public void MouseClick(Point pt)
	{
		MouseClick(pt, MouseButtons.Left);
	}

	public void MouseClick(Point pt, MouseButtons mouseButtons)
	{
		if (!Canceled)
		{
			MoveMousePointTo(pt);
			if (CheckMouse(pt))
			{
				MouseInputArgs[] array = new MouseInputArgs[2];
				array[0].dx = Convert.ToInt32(pt.X);
				array[0].dy = Convert.ToInt32(pt.Y);
				array[0].dwFlags = Convert.ToInt32(2u);
				array[1].dx = Convert.ToInt32(pt.X);
				array[1].dy = Convert.ToInt32(pt.Y);
				array[1].dwFlags = Convert.ToInt32(4u);
				ActiveActionsImports.SendMouseInput(array.Length, array, Marshal.SizeOf(array[0].GetType()));
				DoEvents();
			}
		}
	}

	public void MouseDown()
	{
		MouseDown(MouseButtons.Left);
	}

	public void MouseDown(MouseButtons mouseButtons)
	{
		MouseDown(Cursor.Position, mouseButtons);
	}

	public void MouseDown(Control control, Point pt)
	{
		MouseDown(control, pt, MouseButtons.Left);
	}

	public void MouseDown(Control control, Point pt, MouseButtons mouseButtons)
	{
		Point pt2 = control?.PointToScreen(pt) ?? pt;
		MouseDown(pt2, mouseButtons);
	}

	public void MouseDown(Point pt)
	{
		MouseDown(pt, MouseButtons.Left);
	}

	public void MouseDown(Point pt, MouseButtons mouseButtons)
	{
		if (!Canceled)
		{
			MoveMousePointTo(pt);
			if (CheckMouse(pt))
			{
				ActiveActionsImports.mouse_event(GetMouseFlagsByMouseButtons(mouseButtons, down: true), Convert.ToUInt32(pt.X), Convert.ToUInt32(pt.Y), 0u, IntPtr.Zero);
				DoEvents();
			}
		}
	}

	public void MouseUp()
	{
		MouseUp(MouseButtons.Left);
	}

	public void MouseUp(MouseButtons mouseButtons)
	{
		MouseUp(Cursor.Position, mouseButtons);
	}

	public void MouseUp(Control control, Point pt)
	{
		MouseUp(control, pt, MouseButtons.Left);
	}

	public void MouseUp(Control control, Point pt, MouseButtons mouseButtons)
	{
		Point pt2 = control?.PointToScreen(pt) ?? pt;
		MouseUp(pt2, mouseButtons);
	}

	public void MouseUp(Point pt)
	{
		MouseUp(pt, MouseButtons.Left);
	}

	public void MouseUp(Point pt, MouseButtons mouseButtons)
	{
		if (!Canceled)
		{
			MoveMousePointTo(pt);
			if (CheckMouse(pt))
			{
				ActiveActionsImports.mouse_event(GetMouseFlagsByMouseButtons(mouseButtons, down: false), Convert.ToUInt32(pt.X), Convert.ToUInt32(pt.Y), 0u, IntPtr.Zero);
				DoEvents();
			}
		}
	}

	public void MouseDblClick()
	{
		MouseDblClick(MouseButtons.Left);
	}

	public void MouseDblClick(MouseButtons mouseButtons)
	{
		MouseDblClick(Cursor.Position, mouseButtons);
	}

	public void MouseDblClick(Control control, Point pt)
	{
		MouseDblClick(control, pt, MouseButtons.Left);
	}

	public void MouseDblClick(Control control, Point pt, MouseButtons mouseButtons)
	{
		Point pt2 = control?.PointToScreen(pt) ?? pt;
		MouseDblClick(pt2, mouseButtons);
	}

	public void MouseDblClick(Point pt)
	{
		MouseDblClick(pt, MouseButtons.Left);
	}

	public void MouseDblClick(Point pt, MouseButtons mouseButtons)
	{
		if (!Canceled)
		{
			MoveMousePointTo(pt);
			if (CheckMouse(pt))
			{
				ActiveActionsImports.mouse_event(GetMouseFlagsByMouseButtons(mouseButtons, down: true), Convert.ToUInt32(pt.X), Convert.ToUInt32(pt.Y), 0u, IntPtr.Zero);
				ActiveActionsImports.mouse_event(GetMouseFlagsByMouseButtons(mouseButtons, down: false), Convert.ToUInt32(pt.X), Convert.ToUInt32(pt.Y), 0u, IntPtr.Zero);
				DoEvents();
				ActiveActionsImports.mouse_event(GetMouseFlagsByMouseButtons(mouseButtons, down: true), Convert.ToUInt32(pt.X), Convert.ToUInt32(pt.Y), 0u, IntPtr.Zero);
				ActiveActionsImports.mouse_event(GetMouseFlagsByMouseButtons(mouseButtons, down: false), Convert.ToUInt32(pt.X), Convert.ToUInt32(pt.Y), 0u, IntPtr.Zero);
				DoEvents();
			}
		}
	}

	private bool CheckMouse(Point pt)
	{
		IntPtr intPtr = ActiveActionsImports.WindowFromPoint(pt);
		if (intPtr != IntPtr.Zero)
		{
			uint currentThreadId = ActiveActionsImports.GetCurrentThreadId();
			int lpdwProcessId = 1;
			uint windowThreadProcessId = ActiveActionsImports.GetWindowThreadProcessId(intPtr, ref lpdwProcessId);
			if (currentThreadId != windowThreadProcessId)
			{
				CancelMode = ActiveActionsCancelMode.UnknownTopWindow;
			}
		}
		return !Canceled;
	}

	private uint GetMouseFlagsByMouseButtons(MouseButtons mouseButtons, bool down)
	{
		uint num = 0u;
		switch (mouseButtons)
		{
		case MouseButtons.Left:
			num = (down ? 2u : 4u);
			break;
		case MouseButtons.Middle:
			num = (down ? 8u : 16u);
			break;
		case MouseButtons.Right:
			num = (down ? 32u : 64u);
			break;
		}
		return num | 0x8000;
	}

	bool IMessageFilter.PreFilterMessage(ref Message m)
	{
		if (m.Msg == 256 && !keyActiveActionsProccessing)
		{
			CancelMode = ActiveActionsCancelMode.UserCancel;
			return true;
		}
		return false;
	}

	void IDisposable.Dispose()
	{
		Dispose();
	}

	public static void Delay(int millisecs)
	{
		Thread.Sleep(millisecs);
	}

	private void SendKeyCore(Control control, char key)
	{
		if (control == null)
		{
			return;
		}
		keyActiveActionsProccessing = true;
		try
		{
			string text = new string(key, 1);
			char wParam = text.ToUpper()[0];
			ActiveActionsImports.SendMessage(control.Handle, 256, wParam, 0u);
			ActiveActionsImports.SendMessage(control.Handle, 258, key, 0u);
			ActiveActionsImports.SendMessage(control.Handle, 257, wParam, 0u);
			DoEvents();
			Delay(200);
		}
		finally
		{
			keyActiveActionsProccessing = false;
		}
	}

	private void SendStringCore(Control control, string keys)
	{
		if (control == null)
		{
			return;
		}
		keyActiveActionsProccessing = true;
		try
		{
			ArrayList arrayList = new ArrayList();
			while (keys != string.Empty)
			{
				if (HasKey(ref keys, out var key))
				{
					InputKey(control, key, arrayList);
				}
				else
				{
					SendKeyCore(control, keys[0]);
					keys = keys.Remove(0, 1);
				}
				Delay(200);
			}
			foreach (object item in arrayList)
			{
				UnPressedSealedKey(control, (Keys)item);
			}
		}
		finally
		{
			keyActiveActionsProccessing = false;
		}
	}

	private static void InputKey(Control control, Keys key, ArrayList sealedKeyPressed)
	{
		if (PressSealedKey(control, key, sealedKeyPressed))
		{
			return;
		}
		uint keyValue = ActiveActionsImports.GetKeyValue(key);
		if (Keys.Back == key)
		{
			ActiveActionsImports.PostMessage(control.Handle, 258, keyValue, 0u);
		}
		else if (ActiveControl != null)
		{
			Message msg = new Message
			{
				HWnd = control.Handle,
				LParam = (IntPtr)0,
				WParam = (IntPtr)keyValue,
				Msg = 256
			};
			if (!control.PreProcessMessage(ref msg))
			{
				ActiveActionsImports.SendMessage(control.Handle, 256, keyValue, 0u);
			}
			msg.Msg = 257;
			if (!control.PreProcessMessage(ref msg))
			{
				ActiveActionsImports.SendMessage(control.Handle, 257, keyValue, 0u);
			}
		}
	}

	private static bool PressSealedKey(Control control, Keys key, ArrayList sealedKeyPressed)
	{
		if (ActiveActionsImports.IsSealedKey(key))
		{
			if (sealedKeyPressed.IndexOf(key) < 0)
			{
				sealedKeyPressed.Add(key);
				uint keyValue = ActiveActionsImports.GetKeyValue(key);
				ActiveActionsImports.SetKeyPressed(key, value: true);
				ActiveActionsImports.SendMessage(control.Handle, 256, keyValue, 0u);
			}
			return true;
		}
		return false;
	}

	private static void UnPressedSealedKey(Control control, Keys key)
	{
		uint keyValue = ActiveActionsImports.GetKeyValue(key);
		ActiveActionsImports.SetKeyPressed(key, value: false);
		ActiveActionsImports.SendMessage(control.Handle, 257, keyValue, 0u);
	}

	private static bool HasKey(ref string keys, out Keys key)
	{
		key = Keys.A;
		if (keys == string.Empty || keys[0] != '[')
		{
			return false;
		}
		int num = keys.IndexOf(']');
		int num2 = keys.IndexOf('[', 1);
		if (num < 0 || (num2 > 0 && num > num2))
		{
			return false;
		}
		string text = keys.Substring(1, num - 1);
		if (text == string.Empty)
		{
			return false;
		}
		foreach (Keys value in Enum.GetValues(typeof(Keys)))
		{
			if (value.ToString().ToUpper() == text.ToUpper())
			{
				key = value;
				keys = keys.Remove(0, num + 1);
				return true;
			}
		}
		return false;
	}

	public void ShowMessage(string text)
	{
		ShowMessage(text, Cursor.Position);
	}

	public void ShowMessage(string text, Point pt)
	{
		if (text.Length != 0)
		{
			int num = 2000 + text.Length * 30;
			text = "\n" + text + "\n ";
			ToolTipController toolTipController = new ToolTipController();
			ToolTipControllerShowEventArgs e = toolTipCancelOnEscape.CreateShowArgs();
			e.AutoHide = false;
			e.ToolTip = text;
			e.IconSize = ToolTipIconSize.Large;
			e.IconType = ToolTipIconType.Information;
			e.ToolTipLocation = ToolTipLocation.BottomRight;
			e.ShowBeak = true;
			e.Rounded = true;
			e.AllowHtmlText = DefaultBoolean.False;
			toolTipController.ShowHint(e, pt);
			DoEvents();
			int num2 = 0;
			while (num2 < num)
			{
				Delay(20);
				num2 += 20;
				DoEvents();
			}
			toolTipController.HideHint();
			toolTipController.Dispose();
		}
	}
}
