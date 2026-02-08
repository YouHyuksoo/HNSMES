using System;

namespace IDAT.Devexpress.ActionDemo;

public struct MouseInputArgs(int dx, int dy, int dwFlags)
{
	public int Type = 0;

	public int dx = dx;

	public int dy = dy;

	public int mouseData = 0;

	public int dwFlags = dwFlags;

	public int time = 0;

	public IntPtr extraInfo = IntPtr.Zero;

	public MouseInputArgs(int dx, int dy, int dwFlags, int mouseData)
		: this(dx, dy, dwFlags)
	{
		this.mouseData = mouseData;
	}
}
