using System;

namespace IDAT.Devexpress.ActionDemo;

public struct KeyInputArgs(KeyEventType keyType, ushort vk)
{
	public int Type = 1;

	public ushort wVK = vk;

	public ushort wScan = Convert.ToUInt16(ActiveActionsImports.MapVirtualKey(vk, 0u));

	public uint dwFlags = Convert.ToUInt32((keyType != KeyEventType.KeyDown) ? 2 : 0);

	public uint time = 0u;

	public IntPtr extraInfo = IntPtr.Zero;
}
