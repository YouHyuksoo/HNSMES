using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraEditors;
using IDAT.Devexpress.Properties;

namespace IDAT.Devexpress.DXControl;

[Description("Custom toolbox item from package IdatFramework.")]
[ToolboxItem(true)]
[ToolboxBitmap(typeof(IdatDxSimpleButton), "IdatDxSimpleButton.bmp")]
[DisplayName("IDAT DX Controls")]
public class IdatDxSimpleButton : SimpleButton
{
	private ButtonTypes _ButtonEditMode = ButtonTypes.None;

	private IContainer components = null;

	[Bindable(true)]
	[DefaultValue(true)]
	[Description("Button의 타입을 지정합니다.")]
	[Category("IDAT FrameWork 속성")]
	public ButtonTypes ButtonEditMode
	{
		get
		{
			return _ButtonEditMode;
		}
		set
		{
			switch (value)
			{
			case ButtonTypes.None:
				Image = null;
				break;
			case ButtonTypes.Close:
				Image = Resources.button_close;
				base.CausesValidation = false;
				break;
			case ButtonTypes.Save:
				Image = Resources.button_save;
				break;
			case ButtonTypes.Edit:
				Image = Resources.button_edit;
				break;
			case ButtonTypes.Delete:
				Image = Resources.button_delete;
				break;
			case ButtonTypes.Search:
				Image = Resources.button_search;
				break;
			case ButtonTypes.Cancel:
				Image = Resources.button_cancel;
				break;
			case ButtonTypes.Init:
				Image = Resources.button_init;
				break;
			case ButtonTypes.Refresh:
				Image = Resources.button_refresh;
				break;
			case ButtonTypes.Next:
				Image = Resources.button_exit;
				break;
			case ButtonTypes.Prev:
				Image = Resources.button_prev;
				break;
			case ButtonTypes.Print:
				Image = Resources.button_print;
				break;
			case ButtonTypes.Test:
				Image = Resources.button_test;
				break;
			case ButtonTypes.Exit:
				Image = Resources.button_exit;
				break;
			case ButtonTypes.Undo:
				Image = Resources.button_undo;
				break;
			case ButtonTypes.redo:
				Image = Resources.button_redo;
				break;
			case ButtonTypes.Stop:
				Image = Resources.button_stop;
				break;
			case ButtonTypes.Ok:
				Image = Resources.button_ok;
				break;
			case ButtonTypes.Excel:
				Image = Resources.button_excel;
				break;
			case ButtonTypes.Export:
				Image = Resources.button_export;
				break;
			case ButtonTypes.Add:
				Image = Resources.button_add;
				break;
			case ButtonTypes.Remove:
				Image = Resources.button_remove;
				break;
			case ButtonTypes.Alert:
				Image = Resources.button_alert;
				break;
			case ButtonTypes.Capture:
				Image = Resources.button_capture;
				break;
			case ButtonTypes.New:
				Image = Resources.button_new;
				break;
			case ButtonTypes.Setting:
				Image = Resources.setup;
				break;
			}
			_ButtonEditMode = value;
		}
	}

	public IdatDxSimpleButton()
	{
		InitializeComponent();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
	}
}
