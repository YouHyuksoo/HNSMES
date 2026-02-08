using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;

namespace IDAT.Devexpress.ActionDemo;

public class ActiveDemo : IDisposable
{
	private ActiveActions factions;

	private ToolTipController toolTipCancelOnEscape;

	private ToolTipControllerShowEventArgs toolTipCancelOnEscapeShowArgs;

	public ActiveActions Actions => factions;

	private void InitProperties()
	{
		factions = new ActiveActions();
		toolTipCancelOnEscape = new ToolTipController();
		toolTipCancelOnEscapeShowArgs = toolTipCancelOnEscape.CreateShowArgs();
		toolTipCancelOnEscapeShowArgs.AutoHide = false;
		toolTipCancelOnEscapeShowArgs.AllowHtmlText = DefaultBoolean.False;
		toolTipCancelOnEscapeShowArgs.IconSize = ToolTipIconSize.Large;
		toolTipCancelOnEscapeShowArgs.ToolTip = "\nTo stop Active Demo \n press any key.\n ";
		toolTipCancelOnEscapeShowArgs.IconType = ToolTipIconType.Information;
	}

	public ActiveDemo()
	{
		InitProperties();
		ShowCancelonEscape();
	}

	public void Dispose()
	{
		Actions.Dispose();
		factions = null;
		toolTipCancelOnEscape.HideHint();
		toolTipCancelOnEscape.Dispose();
		toolTipCancelOnEscape = null;
	}

	public void MoveMouseFromPoint(int deltaX, int deltaY)
	{
		Point position = Cursor.Position;
		position.X += deltaX;
		position.Y += deltaY;
		Actions.MoveMousePointTo(position);
	}

	public void ShowMessage(string text)
	{
		ShowMessage(text, Cursor.Position);
	}

	public void ShowMessage(string text, Point pt)
	{
		ShowMessage(text, Cursor.Position, 400);
	}

	public void ShowMessage(string text, int showtime)
	{
		ShowMessage(text, Cursor.Position, showtime);
	}

	public void ShowMessage(string text, Point pt, int showtime)
	{
		if (text.Length != 0 && !Actions.Canceled)
		{
			int num = showtime + text.Length * 30;
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
			ActiveActions.DoEvents();
			int num2 = 0;
			while (num2 < num && !Actions.Canceled)
			{
				ActiveActions.Delay(20);
				num2 += 20;
				ActiveActions.DoEvents();
			}
			toolTipController.HideHint();
			toolTipController.Dispose();
		}
	}

	protected Point GetPointAtCenter(Rectangle r)
	{
		return new Point(r.Left + r.Width / 2, r.Top + r.Height / 2);
	}

	void IDisposable.Dispose()
	{
		Dispose();
	}

	private void ShowCancelonEscape()
	{
		toolTipCancelOnEscape.ShowHint(toolTipCancelOnEscapeShowArgs, new Point(10, 10));
	}
}
