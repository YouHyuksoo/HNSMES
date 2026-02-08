using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;

namespace IDAT.Devexpress.NOTICE;

public class RichEditDemoExceptionsHandler
{
	private readonly RichEditControl control;

	public RichEditDemoExceptionsHandler(RichEditControl control)
	{
		this.control = control;
	}

	public void Install()
	{
		if (control != null)
		{
			control.UnhandledException += OnRichEditControlUnhandledException;
		}
	}

	protected virtual void OnRichEditControlUnhandledException(object sender, RichEditUnhandledExceptionEventArgs e)
	{
		try
		{
			if (e.Exception != null)
			{
				throw e.Exception;
			}
		}
		catch (RichEditUnsupportedFormatException ex)
		{
			XtraMessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			e.Handled = true;
		}
		catch (ExternalException ex2)
		{
			XtraMessageBox.Show(ex2.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			e.Handled = true;
		}
		catch (IOException ex3)
		{
			XtraMessageBox.Show(ex3.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			e.Handled = true;
		}
	}
}
