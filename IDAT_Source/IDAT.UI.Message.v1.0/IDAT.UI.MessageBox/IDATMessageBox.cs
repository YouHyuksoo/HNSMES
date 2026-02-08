using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace IDAT.UI.MessageBox;

public class IDATMessageBox
{
	public static string MemoText = "";

	public static DialogResult Show(string msg, IDAT_MessageType msgType)
	{
		switch (msgType)
		{
		case IDAT_MessageType.Information:
		{
			IDATMessageBox_OK iDATMessageBox_OK2 = new IDATMessageBox_OK();
			iDATMessageBox_OK2.Show(msg);
			return iDATMessageBox_OK2.DialogResult;
		}
		case IDAT_MessageType.Warning:
		{
			IDATMessageBox_OK iDATMessageBox_OK = new IDATMessageBox_OK(IDATMessageBox_OK.MESSAGEOK_TYPE.WARNING);
			iDATMessageBox_OK.Show(msg);
			return iDATMessageBox_OK.DialogResult;
		}
		case IDAT_MessageType.Error:
		{
			IDATMessageBox_Error iDATMessageBox_Error = new IDATMessageBox_Error();
			iDATMessageBox_Error.Show(msg);
			return iDATMessageBox_Error.DialogResult;
		}
		case IDAT_MessageType.Question:
		{
			IDATMessageBox_YesNo iDATMessageBox_YesNo = new IDATMessageBox_YesNo();
			iDATMessageBox_YesNo.Show(msg);
			return iDATMessageBox_YesNo.DialogResult;
		}
		case IDAT_MessageType.MEMOOK:
		{
			IDATMessageBox_MEMOOK iDATMessageBox_MEMOOK = new IDATMessageBox_MEMOOK();
			iDATMessageBox_MEMOOK.Show(msg);
			MemoText = iDATMessageBox_MEMOOK.MessageText;
			return iDATMessageBox_MEMOOK.DialogResult;
		}
		default:
			return DialogResult.None;
		}
	}

	public static DialogResult Show(string msg, string caption, IDAT_MessageType msgType)
	{
		DialogResult result = DialogResult.None;
		switch (msgType)
		{
		case IDAT_MessageType.Information:
		{
			IDATMessageBox_OK iDATMessageBox_OK2 = new IDATMessageBox_OK();
			iDATMessageBox_OK2.Show(msg, caption);
			result = iDATMessageBox_OK2.DialogResult;
			break;
		}
		case IDAT_MessageType.Warning:
		{
			IDATMessageBox_OK iDATMessageBox_OK = new IDATMessageBox_OK(IDATMessageBox_OK.MESSAGEOK_TYPE.WARNING);
			iDATMessageBox_OK.Show(msg, caption);
			result = iDATMessageBox_OK.DialogResult;
			break;
		}
		case IDAT_MessageType.Error:
		{
			IDATMessageBox_Error iDATMessageBox_Error = new IDATMessageBox_Error();
			iDATMessageBox_Error.Show(msg, caption);
			result = iDATMessageBox_Error.DialogResult;
			break;
		}
		case IDAT_MessageType.Question:
		{
			IDATMessageBox_YesNo iDATMessageBox_YesNo = new IDATMessageBox_YesNo();
			iDATMessageBox_YesNo.Show(msg, caption);
			result = iDATMessageBox_YesNo.DialogResult;
			break;
		}
		case IDAT_MessageType.MEMOOK:
		{
			IDATMessageBox_MEMOOK iDATMessageBox_MEMOOK = new IDATMessageBox_MEMOOK();
			iDATMessageBox_MEMOOK.Show(msg, caption);
			MemoText = iDATMessageBox_MEMOOK.MessageText;
			result = iDATMessageBox_MEMOOK.DialogResult;
			break;
		}
		}
		return result;
	}

	public static DialogResult Show(string msg, string caption, string remark, IDAT_MessageType msgType)
	{
		DialogResult result = DialogResult.None;
		switch (msgType)
		{
		case IDAT_MessageType.Information:
		{
			IDATMessageBox_OK iDATMessageBox_OK2 = new IDATMessageBox_OK();
			iDATMessageBox_OK2.Show(msg, caption);
			result = iDATMessageBox_OK2.DialogResult;
			break;
		}
		case IDAT_MessageType.Warning:
		{
			IDATMessageBox_OK iDATMessageBox_OK = new IDATMessageBox_OK(IDATMessageBox_OK.MESSAGEOK_TYPE.WARNING);
			iDATMessageBox_OK.Show(msg, caption);
			result = iDATMessageBox_OK.DialogResult;
			break;
		}
		case IDAT_MessageType.Error:
		{
			IDATMessageBox_Error iDATMessageBox_Error = new IDATMessageBox_Error();
			iDATMessageBox_Error.Show(msg, caption, remark);
			result = iDATMessageBox_Error.DialogResult;
			break;
		}
		case IDAT_MessageType.Question:
		{
			IDATMessageBox_YesNo iDATMessageBox_YesNo = new IDATMessageBox_YesNo();
			iDATMessageBox_YesNo.Show(msg, caption, remark);
			result = iDATMessageBox_YesNo.DialogResult;
			break;
		}
		case IDAT_MessageType.MEMOOK:
		{
			IDATMessageBox_MEMOOK iDATMessageBox_MEMOOK = new IDATMessageBox_MEMOOK();
			iDATMessageBox_MEMOOK.Show(msg, caption);
			MemoText = iDATMessageBox_MEMOOK.MessageText;
			result = iDATMessageBox_MEMOOK.DialogResult;
			break;
		}
		}
		return result;
	}

	public static DialogResult Show(string msg, string caption, IDAT_MessageType msgType, int showTime)
	{
		DialogResult result = DialogResult.None;
		switch (msgType)
		{
		case IDAT_MessageType.Information:
		{
			showTime = 4;
			IDATMessageBox_OK iDATMessageBox_OK = new IDATMessageBox_OK();
			iDATMessageBox_OK.ShowTime = showTime;
			if (showTime > 0)
			{
				iDATMessageBox_OK.AutoHide = true;
			}
			else
			{
				iDATMessageBox_OK.AutoHide = false;
			}
			iDATMessageBox_OK.Show(msg, caption);
			result = iDATMessageBox_OK.DialogResult;
			break;
		}
		case IDAT_MessageType.Warning:
		{
			showTime = 6;
			IDATMessageBox_OK iDATMessageBox_OK2 = new IDATMessageBox_OK(IDATMessageBox_OK.MESSAGEOK_TYPE.WARNING);
			iDATMessageBox_OK2.ShowTime = showTime;
			if (showTime > 0)
			{
				iDATMessageBox_OK2.AutoHide = true;
			}
			else
			{
				iDATMessageBox_OK2.AutoHide = false;
			}
			iDATMessageBox_OK2.Show(msg, caption);
			result = iDATMessageBox_OK2.DialogResult;
			break;
		}
		case IDAT_MessageType.Error:
		{
			if (10 >= showTime)
			{
				showTime = 10;
			}
			IDATMessageBox_Error iDATMessageBox_Error = new IDATMessageBox_Error();
			iDATMessageBox_Error.ShowTime = showTime;
			if (showTime > 0)
			{
				iDATMessageBox_Error.AutoHide = true;
			}
			else
			{
				iDATMessageBox_Error.AutoHide = false;
			}
			iDATMessageBox_Error.Show(msg, caption);
			result = iDATMessageBox_Error.DialogResult;
			break;
		}
		case IDAT_MessageType.Question:
		{
			IDATMessageBox_YesNo iDATMessageBox_YesNo = new IDATMessageBox_YesNo();
			iDATMessageBox_YesNo.Show(msg, caption);
			result = iDATMessageBox_YesNo.DialogResult;
			break;
		}
		case IDAT_MessageType.MEMOOK:
		{
			showTime = 0;
			IDATMessageBox_MEMOOK iDATMessageBox_MEMOOK = new IDATMessageBox_MEMOOK();
			iDATMessageBox_MEMOOK.ShowTime = showTime;
			iDATMessageBox_MEMOOK.AutoHide = false;
			iDATMessageBox_MEMOOK.Show(msg, caption);
			MemoText = iDATMessageBox_MEMOOK.MessageText;
			result = iDATMessageBox_MEMOOK.DialogResult;
			break;
		}
		}
		return result;
	}

	public static DialogResult Show(string msg, string caption, string remark, IDAT_MessageType msgType, int showTime)
	{
		DialogResult result = DialogResult.None;
		if (10 >= showTime)
		{
			showTime = 10;
		}
		switch (msgType)
		{
		case IDAT_MessageType.Information:
		{
			IDATMessageBox_OK iDATMessageBox_OK2 = new IDATMessageBox_OK();
			iDATMessageBox_OK2.ShowTime = showTime;
			if (showTime > 0)
			{
				iDATMessageBox_OK2.AutoHide = true;
			}
			else
			{
				iDATMessageBox_OK2.AutoHide = false;
			}
			iDATMessageBox_OK2.Show(msg, caption);
			result = iDATMessageBox_OK2.DialogResult;
			break;
		}
		case IDAT_MessageType.Warning:
		{
			IDATMessageBox_OK iDATMessageBox_OK = new IDATMessageBox_OK(IDATMessageBox_OK.MESSAGEOK_TYPE.WARNING);
			iDATMessageBox_OK.ShowTime = showTime;
			if (showTime > 0)
			{
				iDATMessageBox_OK.AutoHide = true;
			}
			else
			{
				iDATMessageBox_OK.AutoHide = false;
			}
			iDATMessageBox_OK.Show(msg, caption);
			result = iDATMessageBox_OK.DialogResult;
			break;
		}
		case IDAT_MessageType.Error:
		{
			IDATMessageBox_Error iDATMessageBox_Error = new IDATMessageBox_Error();
			iDATMessageBox_Error.ShowTime = showTime;
			if (showTime > 0)
			{
				iDATMessageBox_Error.AutoHide = true;
			}
			else
			{
				iDATMessageBox_Error.AutoHide = false;
			}
			iDATMessageBox_Error.Show(msg, caption, remark);
			result = iDATMessageBox_Error.DialogResult;
			break;
		}
		case IDAT_MessageType.Question:
		{
			IDATMessageBox_YesNo iDATMessageBox_YesNo = new IDATMessageBox_YesNo();
			iDATMessageBox_YesNo.Show(msg, caption, remark);
			result = iDATMessageBox_YesNo.DialogResult;
			break;
		}
		case IDAT_MessageType.MEMOOK:
		{
			IDATMessageBox_MEMOOK iDATMessageBox_MEMOOK = new IDATMessageBox_MEMOOK();
			iDATMessageBox_MEMOOK.ShowTime = showTime;
			iDATMessageBox_MEMOOK.AutoHide = false;
			iDATMessageBox_MEMOOK.Show(msg, caption);
			MemoText = iDATMessageBox_MEMOOK.MessageText;
			result = iDATMessageBox_MEMOOK.DialogResult;
			break;
		}
		}
		return result;
	}

	public static DialogResult Show(string procName, int procSeq, string[] parameters, object[] values, string remark = null, string caption = null, bool report = false)
	{
		IDATMessageBox_Error_proc iDATMessageBox_Error_proc = new IDATMessageBox_Error_proc();
		iDATMessageBox_Error_proc.Show(procName, procSeq, parameters, values, remark, caption, report);
		return iDATMessageBox_Error_proc.DialogResult;
	}

	public static void ShowWait(Form parentForm, string strCaption, string strDesc)
	{
		SplashScreenManager.ShowForm(parentForm, typeof(COMWAITFORM), useFadeIn: true, useFadeOut: true, throwExceptionIfAlreadyOpened: false);
		SplashScreenManager.Default.SendCommand(COMWAITFORM.WaitFormCommand.SetCaption, strCaption);
		SplashScreenManager.Default.SendCommand(COMWAITFORM.WaitFormCommand.SetDescription, strDesc);
	}

	public static void WaitChangeCommand(COMWAITFORM.WaitFormCommand CommandType, string strDesc)
	{
		SplashScreenManager.Default.SendCommand(CommandType, strDesc);
	}

	public static void CloseWait()
	{
		SplashScreenManager.CloseForm(throwExceptionIfAlreadyClosed: false);
	}
}
