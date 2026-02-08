using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using IDAT.Devexpress.KEYBOARD;
using IDAT.Devexpress.Properties;

namespace IDAT.Devexpress.DXControl;

[Description("Custom toolbox item from package IdatFramework.")]
[DisplayName("IDAT DX Controls")]
[ToolboxBitmap(typeof(IdatDxButtonEdit), "IdatDxButtonEdit.bmp")]
[ToolboxItem(true)]
public class IdatDxButtonEdit : ButtonEdit, IIDATDxControl
{
	private bool _isUseIDATFrameWorkControl = true;

	private string _bindColumnName = "";

	private bool _PK = false;

	private EditModes _EditMode = EditModes.None;

	private bool _ValidationCheck = false;

	private bool _isButtonRemove = false;

	private bool _isButtonKeyBoard = false;

	private GridControl _gc = null;

	private IContainer components = null;

	[Description("바인딩 대상의 GridControl을 지정합니다. 지정안할시에는 첫번째 그리드 컨트롤이 대상이 됩니다.")]
	[Category("IDAT FrameWork 속성")]
	[DefaultValue(true)]
	[Bindable(true)]
	public GridControl BindGridControl
	{
		get
		{
			return _gc;
		}
		set
		{
			_gc = value;
		}
	}

	[Category("IDAT FrameWork 속성")]
	[Bindable(true)]
	[DefaultValue(true)]
	[Description("IDAT FrameWork의 기본UI 셋팅을 자동으로 가집니다.")]
	public bool IsUseIDATFrameWorkControl
	{
		get
		{
			return _isUseIDATFrameWorkControl;
		}
		set
		{
			if (!value)
			{
				BindColumnName = "";
				BindPK = false;
				BindEditMode = EditModes.None;
				ValidationCheck = false;
			}
			_isUseIDATFrameWorkControl = value;
		}
	}

	[Bindable(true)]
	[Category("IDAT FrameWork 속성")]
	[DefaultValue("")]
	[Description("XtraGrid 컬럼과 바인딩할 컬럼명입니다.")]
	public string BindColumnName
	{
		get
		{
			return _bindColumnName;
		}
		set
		{
			_bindColumnName = value;
		}
	}

	[Description("XtraGrid 컬럼과 바인딩하고자 하는 필드 속성이PK 인지 설정합니다. 수정상태시 수정못함")]
	[Bindable(true)]
	[Category("IDAT FrameWork 속성")]
	[DefaultValue(false)]
	public bool BindPK
	{
		get
		{
			return _PK;
		}
		set
		{
			_PK = value;
		}
	}

	[Category("IDAT FrameWork 속성")]
	[Bindable(true)]
	[DefaultValue(EditModes.None)]
	[Description("바인딩 후 수정 상태로 변경 유무")]
	public EditModes BindEditMode
	{
		get
		{
			return _EditMode;
		}
		set
		{
			_EditMode = value;
		}
	}

	[Category("IDAT FrameWork 속성")]
	[Bindable(true)]
	[Description("바인딩 후 유효성 체크시에 자동으로 체크 할것인지의 속성을 지정합니다.")]
	[DefaultValue(false)]
	public bool ValidationCheck
	{
		get
		{
			return _ValidationCheck;
		}
		set
		{
			_ValidationCheck = value;
		}
	}

	[Bindable(true)]
	[Description("삭제 버튼을 지정합니다..")]
	[Category("IDAT FrameWork 속성")]
	[DefaultValue(false)]
	public bool IsButtonRemove
	{
		get
		{
			return _isButtonRemove;
		}
		set
		{
			_isButtonRemove = value;
			if (!base.IsHandleCreated)
			{
				return;
			}
			base.Properties.Buttons[0].Visible = false;
			bool flag = false;
			foreach (EditorButton button in base.Properties.Buttons)
			{
				if (string.Concat(button.Tag) == "DEL")
				{
					flag = true;
					button.Visible = value;
				}
			}
			if (!flag)
			{
				EditorButton editorButton2 = new EditorButton(ButtonPredefines.Glyph);
				editorButton2.Image = Resources.init_1;
				editorButton2.Tag = "DEL";
				base.Properties.Buttons.Add(editorButton2);
			}
		}
	}

	[Category("IDAT FrameWork 속성")]
	[Description("키보드 버튼을 지정합니다..")]
	[Bindable(true)]
	[DefaultValue(false)]
	public bool IsButtonKeyBoard
	{
		get
		{
			return _isButtonKeyBoard;
		}
		set
		{
			_isButtonKeyBoard = value;
			if (!base.IsHandleCreated)
			{
				return;
			}
			base.Properties.Buttons[0].Visible = false;
			bool flag = false;
			foreach (EditorButton button in base.Properties.Buttons)
			{
				if (string.Concat(button.Tag) == "KEYBOARD")
				{
					flag = true;
					button.Visible = value;
				}
			}
			if (!flag)
			{
				EditorButton editorButton2 = new EditorButton(ButtonPredefines.Glyph);
				editorButton2.Image = Resources.keyboard_1;
				editorButton2.Tag = "KEYBOARD";
				base.Properties.Buttons.Add(editorButton2);
			}
		}
	}

	public IdatDxButtonEdit()
	{
		InitializeComponent();
		base.ButtonClick += IdatDxButtonEdit_ButtonClick;
	}

	private void IdatDxButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
	{
		if (string.Concat(e.Button.Tag) == "KEYBOARD")
		{
			IDAT_VKeyBoard iDAT_VKeyBoard = new IDAT_VKeyBoard(this);
			iDAT_VKeyBoard.ShowDialog();
		}
		else if (string.Concat(e.Button.Tag) == "DEL")
		{
			Text = "";
		}
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
