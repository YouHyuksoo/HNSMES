using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using IDAT.Devexpress.Properties;

namespace IDAT.Devexpress.DXControl;

[DisplayName("IDAT DX Controls")]
[ToolboxBitmap(typeof(IdatDxLookUpEdit), "IdatDxGridLookUpEdit.bmp")]
[ToolboxItem(true)]
[Description("Custom toolbox item from package IdatFramework.")]
public class IdatDxGridLookUpEdit : GridLookUpEdit, IIDATDxControl
{
	private bool _isUseIDATFrameWorkControl = true;

	private string _bindColumnName = "";

	private bool _PK = false;

	private EditModes _EditMode = EditModes.None;

	private bool _ValidationCheck = false;

	private bool _isInitButton = false;

	private GridControl _gc = null;

	private EditorButton _EdtBtn = new EditorButton(ButtonPredefines.Glyph, "Init", 20, enabled: true, visible: true, isLeft: false, HorzAlignment.Center, Resources.init_1, new KeyShortcut(Keys.F4 | Keys.Alt), "Initialize", "delete");

	private IContainer components = null;

	private new RepositoryItemGridLookUpEdit fProperties;

	private GridView fPropertiesView;

	[Bindable(true)]
	[DefaultValue(true)]
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

	[Description("IDAT FrameWork의 기본UI 셋팅을 자동으로 가집니다.")]
	[DefaultValue(true)]
	[Bindable(true)]
	[Category("IDAT FrameWork 속성")]
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
	[Bindable(true)]
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

	[Category("IDAT FrameWork 속성")]
	[Bindable(true)]
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

	[DefaultValue(false)]
	[Description("바인딩 후 유효성 체크시에 자동으로 체크 할것인지의 속성을 지정합니다.")]
	[Bindable(true)]
	[Category("IDAT FrameWork 속성")]
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

	[DefaultValue(false)]
	[Description("초기화 버튼을 추가합니다.")]
	[Category("IDAT FrameWork 속성")]
	[Bindable(true)]
	public bool IsInitButton
	{
		get
		{
			return _isInitButton;
		}
		set
		{
			_isInitButton = value;
			if (value)
			{
				base.Properties.Buttons.Add(_EdtBtn);
				base.ButtonClick += IdatDxGridLookUpEdit_ButtonClick;
			}
			else
			{
				base.Properties.Buttons.RemoveAt(base.Properties.Buttons.IndexOf(_EdtBtn));
				base.ButtonClick -= IdatDxGridLookUpEdit_ButtonClick;
			}
		}
	}

	private void IdatDxGridLookUpEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
	{
	}

	public IdatDxGridLookUpEdit()
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
		this.fProperties = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
		this.fPropertiesView = new DevExpress.XtraGrid.Views.Grid.GridView();
		((System.ComponentModel.ISupportInitialize)this.fProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.fPropertiesView).BeginInit();
		base.SuspendLayout();
		this.fProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.fProperties.Name = "fProperties";
		this.fProperties.View = this.fPropertiesView;
		this.fPropertiesView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
		this.fPropertiesView.Name = "fPropertiesView";
		this.fPropertiesView.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.fPropertiesView.OptionsView.ShowGroupPanel = false;
		((System.ComponentModel.ISupportInitialize)this.fProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.fPropertiesView).EndInit();
		base.ResumeLayout(false);
	}
}
