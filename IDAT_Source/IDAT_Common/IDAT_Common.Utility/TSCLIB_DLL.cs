using System.Runtime.InteropServices;

namespace IDAT_Common.Utility;

public class TSCLIB_DLL
{
	[DllImport("TSCLIB.dll")]
	public static extern int about();

	[DllImport("TSCLIB.dll")]
	public static extern int openport(string printername);

	[DllImport("TSCLIB.dll")]
	public static extern int barcode(string x, string y, string type, string height, string readable, string rotation, string narrow, string wide, string code);

	[DllImport("TSCLIB.dll")]
	public static extern int clearbuffer();

	[DllImport("TSCLIB.dll")]
	public static extern int closeport();

	[DllImport("TSCLIB.dll")]
	public static extern int downloadpcx(string filename, string image_name);

	[DllImport("TSCLIB.dll")]
	public static extern int formfeed();

	[DllImport("TSCLIB.dll")]
	public static extern int nobackfeed();

	[DllImport("TSCLIB.dll")]
	public static extern int printerfont(string x, string y, string fonttype, string rotation, string xmul, string ymul, string text);

	[DllImport("TSCLIB.dll")]
	public static extern int printlabel(string set, string copy);

	[DllImport("TSCLIB.dll")]
	public static extern int sendcommand(string printercommand);

	[DllImport("TSCLIB.dll")]
	public static extern int setup(string width, string height, string speed, string density, string sensor, string vertical, string offset);

	[DllImport("TSCLIB.dll")]
	public static extern int windowsfont(int x, int y, int fontheight, int rotation, int fontstyle, int fontunderline, string szFaceName, string content);
}
