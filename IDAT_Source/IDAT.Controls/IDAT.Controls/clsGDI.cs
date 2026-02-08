using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace IDAT.Controls;

internal class clsGDI
{
	public GraphicsPath getRectPath(int width, int height)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(0, 0, width, 0);
		graphicsPath.AddLine(width - 1, 0, width - 1, height);
		graphicsPath.AddLine(width, height - 1, 0, height - 1);
		graphicsPath.AddLine(0, height, 0, 0);
		return graphicsPath;
	}

	public GraphicsPath getRectPath(int width, int height, int x, int y)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(new Rectangle(x, y, width, height));
		return graphicsPath;
	}

	public GraphicsPath getLinkPath(Point to, Point from)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(from.X, from.Y, to.X, from.Y);
		graphicsPath.AddLine(to.X, from.Y, to.X, to.Y);
		return graphicsPath;
	}

	public GraphicsPath getLinkPath(int tx, int ty, int fx, int fy)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(fx, fy, tx, fy);
		graphicsPath.AddLine(tx, fy, tx, ty);
		return graphicsPath;
	}

	public GraphicsPath getLinkPath(Control me, Control you, int mPoint, int yPoint, string type)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		int num = me.Location.X - 1;
		int y = me.Location.Y;
		int width = me.Width;
		int height = me.Height;
		int x = you.Location.X;
		int y2 = you.Location.Y;
		int width2 = you.Width;
		int height2 = you.Height;
		Point DP = default(Point);
		SetArrowPoint(me, you, me.Width / 2, ref DP);
		graphicsPath.AddLine(num + width / 2, y + height / 2, DP.X, DP.Y);
		float num2 = num + width / 2;
		float num3 = y + height / 2;
		float num4 = DP.X;
		float num5 = DP.Y;
		double num6 = Math.Atan(Math.Abs(num5 - num3) / Math.Abs(num4 - num2)) * 360.0 / 6.283184;
		double num7 = Math.Sqrt(Math.Pow(num5 - num3, 2.0) + Math.Pow(num4 - num2, 2.0));
		double num8 = 0.0;
		num8 = ((!(num3 > num5)) ? ((double)num2 + 80.0 * Math.Cos((90.0 - num6) * Math.PI / 180.0)) : ((double)num2 - 80.0 * Math.Cos((90.0 - num6) * Math.PI / 180.0)));
		double num9 = 0.0;
		num9 = ((!(num2 > num4)) ? ((double)num3 - 50.0 * Math.Cos((90.0 - num6) * Math.PI / 180.0) * Math.Tan((90.0 - num6) * Math.PI / 180.0)) : ((double)num3 + 50.0 * Math.Cos((90.0 - num6) * Math.PI / 180.0) * Math.Tan((90.0 - num6) * Math.PI / 180.0)));
		double num10 = 0.0;
		num10 = ((!(num3 > num5)) ? ((double)num4 + 50.0 * Math.Cos((90.0 - num6) * Math.PI / 180.0)) : ((double)num4 - 50.0 * Math.Cos((90.0 - num6) * Math.PI / 180.0)));
		double num11 = 0.0;
		num11 = ((!(num2 > num4)) ? ((double)num5 - 50.0 * Math.Cos((90.0 - num6) * Math.PI / 180.0) * Math.Tan((90.0 - num6) * Math.PI / 180.0)) : ((double)num5 + 50.0 * Math.Cos((90.0 - num6) * Math.PI / 180.0) * Math.Tan((90.0 - num6) * Math.PI / 180.0)));
		GraphicsPath graphicsPath2 = new GraphicsPath();
		if (type == "1")
		{
			graphicsPath2.AddLine(num2, num3, DP.X, DP.Y);
		}
		else if (type == "2")
		{
			graphicsPath2.AddBezier(num2, num3, (float)num8, (float)num9, (float)num10, (float)num11, num4, num5);
		}
		return graphicsPath2;
	}

	private void SetArrowPoint(Control me, Control you, float HalfWidth, ref Point DP)
	{
		float num = (float)(you.Location.Y - me.Location.Y) / (float)(you.Location.X - me.Location.X);
		if (you.Location.X >= me.Location.X && num <= 1f && num >= -1f)
		{
			float num2 = (float)you.Location.X - HalfWidth - 10f;
			float num3 = (float)you.Location.Y - num * HalfWidth;
			num2 += (float)(you.Width / 2);
			num3 += (float)(you.Height / 2);
			DP = new Point((int)num2, (int)num3);
			return;
		}
		if (you.Location.X < me.Location.X && num <= 1f && num >= -1f)
		{
			float num2 = (float)you.Location.X + HalfWidth + 10f;
			float num3 = (float)you.Location.Y + num * HalfWidth;
			num2 += (float)(you.Width / 2);
			num3 += (float)(you.Height / 2);
			DP = new Point((int)num2, (int)num3);
			return;
		}
		num = (float)(you.Location.X - me.Location.X) / (float)(you.Location.Y - me.Location.Y);
		if (you.Location.Y >= me.Location.Y && num < 1f && num > -1f)
		{
			float num2 = (float)you.Location.X - HalfWidth * num;
			float num3 = (float)you.Location.Y - HalfWidth - 10f;
			num2 += (float)(you.Width / 2);
			num3 += (float)(you.Height / 2);
			DP = new Point((int)num2, (int)num3);
		}
		else if (you.Location.Y < me.Location.Y && num < 1f && num > -1f)
		{
			float num2 = (float)you.Location.X + HalfWidth * num;
			float num3 = (float)you.Location.Y + HalfWidth + 10f;
			num2 += (float)(you.Width / 2);
			num3 += (float)(you.Height / 2);
			DP = new Point((int)num2, (int)num3);
		}
	}
}
