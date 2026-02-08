using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace IDAT.Devexpress.DXControl;

[DisplayName("IDAT DX Controls")]
[Description("Custom toolbox item from package IdatFramework.")]
[ToolboxItem(true)]
[ToolboxBitmap(typeof(IdatDxFromToDate), "IdatDxFromToDate.bmp")]
public class IdatDxFromToDate : XtraUserControl
{
	private DateTimeType _dateType = DateTimeType.YearMonthDay;

	private bool _UseCaption = true;

	private DateTime _FromDateValue = DateTime.Now;

	private DateTime _ToDateValue = DateTime.Now;

	private string _FromDateText = DateTime.Now.ToString("yyyy-MM-dd");

	private string _ToDateText = DateTime.Now.ToString("yyyy-MM-dd");

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private SimpleLabelItem simpleLabelItem_Caption;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem4;

	public DateEdit dateEdit_To;

	public DateEdit dateEdit_From;

	public IdatDXMonthEdit idatDXMonthEdit_To;

	public IdatDXMonthEdit idatDXMonthEdit_From;

	[Category("FromToDate 속성")]
	[Description("날짜 타입을 변경합니다.")]
	[DefaultValue(true)]
	[Bindable(true)]
	public DateTimeType DateType
	{
		get
		{
			return _dateType;
		}
		set
		{
			_dateType = value;
			if (value == DateTimeType.YearMonthDay)
			{
				layoutControlItem1.Visibility = LayoutVisibility.Always;
				layoutControlItem3.Visibility = LayoutVisibility.Never;
				layoutControlItem2.Visibility = LayoutVisibility.Always;
				layoutControlItem4.Visibility = LayoutVisibility.Never;
			}
			else
			{
				layoutControlItem1.Visibility = LayoutVisibility.Never;
				layoutControlItem3.Visibility = LayoutVisibility.Always;
				layoutControlItem2.Visibility = LayoutVisibility.Never;
				layoutControlItem4.Visibility = LayoutVisibility.Always;
			}
		}
	}

	[Bindable(true)]
	[DefaultValue(true)]
	[Description("날짜 사이의 Caption(~)명을 나타나거나 보이지 않게 합니다.")]
	[Category("FromToDate 속성")]
	public bool UseCaption
	{
		get
		{
			return _UseCaption;
		}
		set
		{
			_UseCaption = value;
			if (value)
			{
				simpleLabelItem_Caption.Visibility = LayoutVisibility.Always;
			}
			else
			{
				simpleLabelItem_Caption.Visibility = LayoutVisibility.Never;
			}
		}
	}

	[Category("FromToDate 속성")]
	[Bindable(false)]
	[Description("시작 날짜의 날짜 정보를 가지고 옵니다.")]
	public DateTime FromDateValue
	{
		get
		{
			return _FromDateValue;
		}
		set
		{
			_FromDateValue = value;
			dateEdit_From.DateTime = value;
		}
	}

	[Category("FromToDate 속성")]
	[Bindable(false)]
	[Description("날짜의 표시형식을 설정합니다.")]
	public string FromDateFormat
	{
		get
		{
			return dateEdit_From.Properties.DisplayFormat.FormatString;
		}
		set
		{
			dateEdit_From.Properties.DisplayFormat.FormatString = value;
			dateEdit_From.Properties.EditFormat.FormatString = value;
			dateEdit_From.Properties.Mask.MaskType = MaskType.DateTime;
			dateEdit_From.Properties.EditMask = value;
		}
	}

	[Description("날짜의 표시형식을 설정합니다.")]
	[Category("FromToDate 속성")]
	[Bindable(false)]
	public string ToDateFormat
	{
		get
		{
			return dateEdit_To.Properties.DisplayFormat.FormatString;
		}
		set
		{
			dateEdit_To.Properties.DisplayFormat.FormatString = value;
			dateEdit_To.Properties.EditFormat.FormatString = value;
			dateEdit_To.Properties.Mask.MaskType = MaskType.DateTime;
			dateEdit_To.Properties.EditMask = value;
		}
	}

	[Category("FromToDate 속성")]
	[Description("끝 날짜의 날짜 정보를 가지고 옵니다.")]
	[Bindable(false)]
	public DateTime ToDateValue
	{
		get
		{
			return _ToDateValue;
		}
		set
		{
			_ToDateValue = value;
			dateEdit_To.DateTime = value;
		}
	}

	[Description("시작 날짜의 날짜 정보를 스트링 형태로 가지고 옵니다. (YYYY-MM-DD)")]
	[Bindable(false)]
	[Category("FromToDate 속성")]
	public string FromDateText
	{
		get
		{
			if (DateType == DateTimeType.YearMonth)
			{
				return idatDXMonthEdit_From.Text;
			}
			return _FromDateText;
		}
		set
		{
			if (DateTime.TryParse(value, out var result))
			{
				_FromDateText = result.ToString(dateEdit_From.Properties.DisplayFormat.FormatString);
				dateEdit_From.DateTime = result;
				idatDXMonthEdit_From.DateTime = result;
			}
			else
			{
				_FromDateText = DateTime.Now.ToString(dateEdit_From.Properties.DisplayFormat.FormatString);
				dateEdit_From.DateTime = DateTime.Now;
				idatDXMonthEdit_From.DateTime = DateTime.Now;
			}
		}
	}

	[Description("끝 날짜의 날짜 정보를 스트링 형태로 가지고 옵니다. (YYYY-MM-DD)")]
	[Category("FromToDate 속성")]
	[Bindable(false)]
	public string ToDateText
	{
		get
		{
			if (DateType == DateTimeType.YearMonth)
			{
				return idatDXMonthEdit_To.Text;
			}
			return _ToDateText;
		}
		set
		{
			if (DateTime.TryParse(value, out var result))
			{
				_ToDateText = result.ToString(dateEdit_To.Properties.DisplayFormat.FormatString);
				dateEdit_To.DateTime = result;
				idatDXMonthEdit_To.DateTime = result;
			}
			else
			{
				_ToDateText = DateTime.Now.ToString(dateEdit_To.Properties.DisplayFormat.FormatString);
				dateEdit_To.DateTime = DateTime.Now;
				idatDXMonthEdit_To.DateTime = DateTime.Now;
			}
		}
	}

	public IdatDxFromToDate()
	{
		InitializeComponent();
	}

	private void dateEdit_From_EditValueChanged(object sender, EventArgs e)
	{
		FromDateValue = dateEdit_From.DateTime;
		FromDateText = dateEdit_From.DateTime.ToString("yyyy-MM-dd");
	}

	private void dateEdit_To_EditValueChanged(object sender, EventArgs e)
	{
		ToDateValue = dateEdit_To.DateTime;
		ToDateText = dateEdit_To.DateTime.ToString("yyyy-MM-dd");
	}

	private void idatDXMonthEdit_From_EditValueChanged(object sender, EventArgs e)
	{
		FromDateValue = idatDXMonthEdit_From.DateTime;
		FromDateText = idatDXMonthEdit_From.DateTime.ToString("yyyy-MM");
	}

	private void idatDXMonthEdit_To_EditValueChanged(object sender, EventArgs e)
	{
		ToDateValue = idatDXMonthEdit_To.DateTime;
		ToDateText = idatDXMonthEdit_To.DateTime.ToString("yyyy-MM");
	}

	public virtual string GetFromDate_YYYYMMDD()
	{
		return FromDateText.Replace("-", "");
	}

	public virtual string GetToDate_YYYYMMDD()
	{
		return ToDateText.Replace("-", "");
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
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.idatDXMonthEdit_To = new IDAT.Devexpress.DXControl.IdatDXMonthEdit();
		this.dateEdit_To = new DevExpress.XtraEditors.DateEdit();
		this.dateEdit_From = new DevExpress.XtraEditors.DateEdit();
		this.idatDXMonthEdit_From = new IDAT.Devexpress.DXControl.IdatDXMonthEdit();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.simpleLabelItem_Caption = new DevExpress.XtraLayout.SimpleLabelItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.idatDXMonthEdit_To.Properties.VistaTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.idatDXMonthEdit_To.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit_To.Properties.VistaTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit_To.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit_From.Properties.VistaTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit_From.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.idatDXMonthEdit_From.Properties.VistaTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.idatDXMonthEdit_From.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.simpleLabelItem_Caption).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.AutoScroll = false;
		this.layoutControl1.Controls.Add(this.idatDXMonthEdit_To);
		this.layoutControl1.Controls.Add(this.dateEdit_To);
		this.layoutControl1.Controls.Add(this.dateEdit_From);
		this.layoutControl1.Controls.Add(this.idatDXMonthEdit_From);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Margin = new System.Windows.Forms.Padding(0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(42, 164, 250, 350);
		this.layoutControl1.OptionsView.AlwaysScrollActiveControlIntoView = false;
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(215, 40);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.idatDXMonthEdit_To.BindGridControl = null;
		this.idatDXMonthEdit_To.EditValue = null;
		this.idatDXMonthEdit_To.IsUseIDATFrameWorkControl = false;
		this.idatDXMonthEdit_To.Location = new System.Drawing.Point(114, 20);
		this.idatDXMonthEdit_To.Name = "idatDXMonthEdit_To";
		this.idatDXMonthEdit_To.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.idatDXMonthEdit_To.Properties.DisplayFormat.FormatString = "yyyy-MM";
		this.idatDXMonthEdit_To.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.idatDXMonthEdit_To.Properties.EditFormat.FormatString = "yyyy-MM";
		this.idatDXMonthEdit_To.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.idatDXMonthEdit_To.Properties.Mask.EditMask = "";
		this.idatDXMonthEdit_To.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
		this.idatDXMonthEdit_To.Properties.Mask.UseMaskAsDisplayFormat = true;
		this.idatDXMonthEdit_To.Properties.MaxLength = 7;
		this.idatDXMonthEdit_To.Properties.ShowToday = false;
		this.idatDXMonthEdit_To.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
		this.idatDXMonthEdit_To.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.idatDXMonthEdit_To.Properties.VistaTimeProperties.DisplayFormat.FormatString = "yyyy-MM";
		this.idatDXMonthEdit_To.Properties.VistaTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.idatDXMonthEdit_To.Properties.VistaTimeProperties.EditFormat.FormatString = "yyyy-MM";
		this.idatDXMonthEdit_To.Properties.VistaTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.idatDXMonthEdit_To.Properties.VistaTimeProperties.Mask.EditMask = "yyyy-MM";
		this.idatDXMonthEdit_To.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = true;
		this.idatDXMonthEdit_To.Size = new System.Drawing.Size(100, 20);
		this.idatDXMonthEdit_To.StyleController = this.layoutControl1;
		this.idatDXMonthEdit_To.TabIndex = 7;
		this.idatDXMonthEdit_To.EditValueChanged += new System.EventHandler(idatDXMonthEdit_To_EditValueChanged);
		this.dateEdit_To.EditValue = null;
		this.dateEdit_To.Location = new System.Drawing.Point(114, 0);
		this.dateEdit_To.Name = "dateEdit_To";
		this.dateEdit_To.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dateEdit_To.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
		this.dateEdit_To.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.dateEdit_To.Properties.Mask.UseMaskAsDisplayFormat = true;
		this.dateEdit_To.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dateEdit_To.Size = new System.Drawing.Size(100, 20);
		this.dateEdit_To.StyleController = this.layoutControl1;
		this.dateEdit_To.TabIndex = 5;
		this.dateEdit_To.EditValueChanged += new System.EventHandler(dateEdit_To_EditValueChanged);
		this.dateEdit_From.EditValue = null;
		this.dateEdit_From.Location = new System.Drawing.Point(0, 0);
		this.dateEdit_From.Name = "dateEdit_From";
		this.dateEdit_From.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dateEdit_From.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
		this.dateEdit_From.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.dateEdit_From.Properties.Mask.UseMaskAsDisplayFormat = true;
		this.dateEdit_From.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dateEdit_From.Size = new System.Drawing.Size(100, 20);
		this.dateEdit_From.StyleController = this.layoutControl1;
		this.dateEdit_From.TabIndex = 4;
		this.dateEdit_From.EditValueChanged += new System.EventHandler(dateEdit_From_EditValueChanged);
		this.idatDXMonthEdit_From.BindGridControl = null;
		this.idatDXMonthEdit_From.EditValue = null;
		this.idatDXMonthEdit_From.IsUseIDATFrameWorkControl = false;
		this.idatDXMonthEdit_From.Location = new System.Drawing.Point(0, 20);
		this.idatDXMonthEdit_From.Name = "idatDXMonthEdit_From";
		this.idatDXMonthEdit_From.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.idatDXMonthEdit_From.Properties.DisplayFormat.FormatString = "yyyy-MM";
		this.idatDXMonthEdit_From.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.idatDXMonthEdit_From.Properties.EditFormat.FormatString = "yyyy-MM";
		this.idatDXMonthEdit_From.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.idatDXMonthEdit_From.Properties.Mask.EditMask = "";
		this.idatDXMonthEdit_From.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
		this.idatDXMonthEdit_From.Properties.Mask.UseMaskAsDisplayFormat = true;
		this.idatDXMonthEdit_From.Properties.MaxLength = 7;
		this.idatDXMonthEdit_From.Properties.ShowToday = false;
		this.idatDXMonthEdit_From.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
		this.idatDXMonthEdit_From.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.idatDXMonthEdit_From.Properties.VistaTimeProperties.DisplayFormat.FormatString = "yyyy-MM";
		this.idatDXMonthEdit_From.Properties.VistaTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.idatDXMonthEdit_From.Properties.VistaTimeProperties.EditFormat.FormatString = "yyyy-MM";
		this.idatDXMonthEdit_From.Properties.VistaTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.idatDXMonthEdit_From.Properties.VistaTimeProperties.Mask.EditMask = "yyyy-MM";
		this.idatDXMonthEdit_From.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = true;
		this.idatDXMonthEdit_From.Size = new System.Drawing.Size(100, 20);
		this.idatDXMonthEdit_From.StyleController = this.layoutControl1;
		this.idatDXMonthEdit_From.TabIndex = 6;
		this.idatDXMonthEdit_From.EditValueChanged += new System.EventHandler(idatDXMonthEdit_From_EditValueChanged);
		this.layoutControlGroup1.CustomizationFormText = "Root";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[5] { this.layoutControlItem1, this.layoutControlItem2, this.simpleLabelItem_Caption, this.layoutControlItem3, this.layoutControlItem4 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "Root";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(215, 40);
		this.layoutControlGroup1.Text = "Root";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.dateEdit_From;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.MaxSize = new System.Drawing.Size(100, 20);
		this.layoutControlItem1.MinSize = new System.Drawing.Size(100, 20);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlItem1.Size = new System.Drawing.Size(100, 20);
		this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem2.Control = this.dateEdit_To;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(114, 0);
		this.layoutControlItem2.MaxSize = new System.Drawing.Size(100, 20);
		this.layoutControlItem2.MinSize = new System.Drawing.Size(100, 20);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlItem2.Size = new System.Drawing.Size(101, 20);
		this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem2.Text = "layoutControlItem2";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextToControlDistance = 0;
		this.layoutControlItem2.TextVisible = false;
		this.simpleLabelItem_Caption.AllowHotTrack = false;
		this.simpleLabelItem_Caption.AppearanceItemCaption.Options.UseTextOptions = true;
		this.simpleLabelItem_Caption.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.simpleLabelItem_Caption.CustomizationFormText = "~";
		this.simpleLabelItem_Caption.Location = new System.Drawing.Point(100, 0);
		this.simpleLabelItem_Caption.MaxSize = new System.Drawing.Size(14, 0);
		this.simpleLabelItem_Caption.MinSize = new System.Drawing.Size(14, 1);
		this.simpleLabelItem_Caption.Name = "simpleLabelItem_Caption";
		this.simpleLabelItem_Caption.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.simpleLabelItem_Caption.Size = new System.Drawing.Size(14, 40);
		this.simpleLabelItem_Caption.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.simpleLabelItem_Caption.Text = "~";
		this.simpleLabelItem_Caption.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
		this.simpleLabelItem_Caption.TextSize = new System.Drawing.Size(9, 14);
		this.layoutControlItem3.Control = this.idatDXMonthEdit_From;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 20);
		this.layoutControlItem3.MaxSize = new System.Drawing.Size(100, 20);
		this.layoutControlItem3.MinSize = new System.Drawing.Size(100, 20);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlItem3.Size = new System.Drawing.Size(100, 20);
		this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem3.Text = "layoutControlItem3";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextToControlDistance = 0;
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
		this.layoutControlItem4.Control = this.idatDXMonthEdit_To;
		this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
		this.layoutControlItem4.Location = new System.Drawing.Point(114, 20);
		this.layoutControlItem4.MaxSize = new System.Drawing.Size(100, 20);
		this.layoutControlItem4.MinSize = new System.Drawing.Size(100, 20);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlItem4.Size = new System.Drawing.Size(101, 20);
		this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem4.Text = "layoutControlItem4";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextToControlDistance = 0;
		this.layoutControlItem4.TextVisible = false;
		this.layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 14f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.AutoScroll = true;
		base.Controls.Add(this.layoutControl1);
		this.MinimumSize = new System.Drawing.Size(215, 0);
		base.Name = "IdatDxFromToDate";
		base.Size = new System.Drawing.Size(215, 40);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.idatDXMonthEdit_To.Properties.VistaTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.idatDXMonthEdit_To.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit_To.Properties.VistaTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit_To.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit_From.Properties.VistaTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit_From.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.idatDXMonthEdit_From.Properties.VistaTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.idatDXMonthEdit_From.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.simpleLabelItem_Caption).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		base.ResumeLayout(false);
	}
}
