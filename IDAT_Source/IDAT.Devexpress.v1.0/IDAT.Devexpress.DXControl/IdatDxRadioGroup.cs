using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;

namespace IDAT.Devexpress.DXControl;

[ToolboxBitmap(typeof(IdatDxRadioGroup), "IdatDxTextEdit.bmp")]
[DisplayName("IDAT DX Controls")]
[Description("Custom toolbox item from package IdatFramework.")]
[ToolboxItem(true)]
public class IdatDxRadioGroup : RadioGroup, IIDATDxControl
{
	private bool _isUseIDATFrameWorkControl = true;

	private string _bindColumnName = "";

	private bool _PK = false;

	private EditModes _EditMode = EditModes.None;

	private bool _ValidationCheck = false;

	private bool _isYesNoType = false;

	private GridControl _gc = null;

	private RadioGroupItem rgItemYes = new RadioGroupItem("Y", "Yes");

	private RadioGroupItem rgItemNo = new RadioGroupItem("N", "No");

	private IContainer components = null;

	[Bindable(true)]
	[Description("바인딩 대상의 GridControl을 지정합니다. 지정안할시에는 첫번째 그리드 컨트롤이 대상이 됩니다.")]
	[Category("IDAT FrameWork 속성")]
	[DefaultValue(true)]
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
	[Description("IDAT FrameWork의 기본UI 셋팅을 자동으로 가집니다.")]
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

	[Category("IDAT FrameWork 속성")]
	[DefaultValue("")]
	[Description("XtraGrid 컬럼과 바인딩할 컬럼명입니다.")]
	[Bindable(true)]
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
	[Description("XtraGrid 컬럼과 바인딩하고자 하는 필드 속성이PK 인지 설정합니다. 수정상태시 수정못함")]
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
	[Description("바인딩 후 수정 상태로 변경 유무")]
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
	[Description("바인딩 후 유효성 체크시에 자동으로 체크 할것인지의 속성을 지정합니다.")]
	[Category("IDAT FrameWork 속성")]
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
	[Category("IDAT FrameWork 속성")]
	[DefaultValue(false)]
	[Description("체크박스 형태를 자동으로 Yes/No 형태로 변환한다..")]
	public bool IsYesNoType
	{
		get
		{
			return _isYesNoType;
		}
		set
		{
			_isYesNoType = value;
			if (base.IsHandleCreated)
			{
				SetChangeYesNo(value);
			}
		}
	}

	public IdatDxRadioGroup()
	{
		InitializeComponent();
	}

	private void SetChangeYesNo(bool value)
	{
		if (value)
		{
			if (base.Properties.Items.Count > 0)
			{
				if (base.Properties.Items.IndexOf(rgItemYes) > -1)
				{
					base.Properties.Items.Remove(rgItemYes);
				}
				if (base.Properties.Items.IndexOf(rgItemNo) > -1)
				{
					base.Properties.Items.Remove(rgItemNo);
				}
				base.Properties.Items.Add(rgItemYes);
				base.Properties.Items.Add(rgItemNo);
				base.SelectedIndex = 0;
			}
			else
			{
				base.Properties.Items.Add(rgItemYes);
				base.Properties.Items.Add(rgItemNo);
				base.SelectedIndex = 0;
			}
		}
		else if (base.Properties.Items.Count > 0 && MessageBox.Show("기존에 만들어 놓으신 아이템이 모두 삭제 됩니다. 계속 하시겠습니까?", "아이템 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
		{
			base.Properties.Items.Clear();
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
