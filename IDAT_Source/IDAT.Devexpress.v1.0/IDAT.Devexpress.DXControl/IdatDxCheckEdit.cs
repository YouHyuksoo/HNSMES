using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;

namespace IDAT.Devexpress.DXControl;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(IdatDxCheckEdit), "IdatDxCheckEdit.bmp")]
[Description("Custom toolbox item from package IdatFramework.")]
[DisplayName("IDAT DX Controls")]
public class IdatDxCheckEdit : CheckEdit, IIDATDxControl
{
	private bool _isUseIDATFrameWorkControl = true;

	private string _bindColumnName = "";

	private bool _PK = false;

	private EditModes _EditMode = EditModes.None;

	private bool _ValidationCheck = false;

	private GridControl _gc = null;

	private IContainer components = null;

	[DefaultValue(true)]
	[Bindable(true)]
	[Description("바인딩 대상의 GridControl을 지정합니다. 지정안할시에는 첫번째 그리드 컨트롤이 대상이 됩니다.")]
	[Category("IDAT FrameWork 속성")]
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

	[Bindable(true)]
	[Category("IDAT FrameWork 속성")]
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
	[Description("XtraGrid 컬럼과 바인딩할 컬럼명입니다.")]
	[Category("IDAT FrameWork 속성")]
	[DefaultValue("")]
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

	[Bindable(true)]
	[Category("IDAT FrameWork 속성")]
	[Description("XtraGrid 컬럼과 바인딩하고자 하는 필드 속성이PK 인지 설정합니다. 수정상태시 수정못함")]
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

	[Bindable(true)]
	[Description("바인딩 후 수정 상태로 변경 유무")]
	[Category("IDAT FrameWork 속성")]
	[DefaultValue(EditModes.None)]
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

	[Bindable(true)]
	[Category("IDAT FrameWork 속성")]
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

	public IdatDxCheckEdit()
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
