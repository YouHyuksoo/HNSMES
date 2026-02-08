using System.ComponentModel;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;

namespace IDAT.Devexpress.DXControl;

[ToolboxBitmap(typeof(IdatDXMonthEdit), "IdatDXMonthEdit.bmp")]
[ToolboxItem(true)]
[Description("Custom toolbox item from package IdatFramework.")]
[DisplayName("IDAT DX Controls")]
public class IdatDXMonthEdit : DateEdit, IIDATDxControl
{
	private bool _isUseIDATFrameWorkControl = true;

	private string _bindColumnName = "";

	private bool _PK = false;

	private EditModes _EditMode = EditModes.None;

	private bool _ValidationCheck = false;

	private GridControl _gc = null;

	private new RepositoryItemDateEdit fProperties;

	[DefaultValue(true)]
	[Description("바인딩 대상의 GridControl을 지정합니다. 지정안할시에는 첫번째 그리드 컨트롤이 대상이 됩니다.")]
	[Bindable(true)]
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

	[Description("IDAT FrameWork의 기본UI 셋팅을 자동으로 가집니다.")]
	[Category("IDAT FrameWork 속성")]
	[Bindable(true)]
	[DefaultValue(true)]
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

	[Description("XtraGrid 컬럼과 바인딩할 컬럼명입니다.")]
	[Category("IDAT FrameWork 속성")]
	[Bindable(true)]
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

	[Category("IDAT FrameWork 속성")]
	[DefaultValue(false)]
	[Description("XtraGrid 컬럼과 바인딩하고자 하는 필드 속성이PK 인지 설정합니다. 수정상태시 수정못함")]
	[Bindable(true)]
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

	[Description("바인딩 후 수정 상태로 변경 유무")]
	[DefaultValue(EditModes.None)]
	[Bindable(true)]
	[Category("IDAT FrameWork 속성")]
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

	[Description("바인딩 후 유효성 체크시에 자동으로 체크 할것인지의 속성을 지정합니다.")]
	[DefaultValue(false)]
	[Category("IDAT FrameWork 속성")]
	[Bindable(true)]
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

	public IdatDXMonthEdit()
	{
		base.Properties.ShowToday = false;
		base.Properties.VistaDisplayMode = DefaultBoolean.True;
		base.Properties.DisplayFormat.FormatType = FormatType.DateTime;
		base.Properties.DisplayFormat.FormatString = "yyyy-MM";
		base.Properties.EditFormat.FormatType = FormatType.DateTime;
		base.Properties.EditFormat.FormatString = "yyyy-MM";
		base.Properties.MaxLength = 7;
		base.Properties.Mask.MaskType = MaskType.RegEx;
		base.Properties.Mask.EditMask = "\\d\\d\\d\\d-\\d\\d";
	}

	protected override PopupBaseForm CreatePopupForm()
	{
		if (base.Properties.VistaDisplayMode == DefaultBoolean.True)
		{
			return new MyVistaPopupDateEditForm(this);
		}
		return base.CreatePopupForm();
	}
}
