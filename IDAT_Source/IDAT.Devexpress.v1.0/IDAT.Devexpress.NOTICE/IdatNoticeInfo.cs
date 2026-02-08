using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using IDAT.Devexpress.NOTICE.SUB;

namespace IDAT.Devexpress.NOTICE;

public class IdatNoticeInfo : XtraUserControl
{
	private bool _isViewIdatUpdateHistory = true;

	private string _MainProgramTitleString = "IDAT Framework 1.0";

	private string _CompanyNameString = "ID Information System";

	private bool _IsShowNewDataIcon = true;

	private int _SubNoticeTitleMaxLength = 0;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private PictureEdit pictureEdit_MainIcon;

	private LayoutControlItem layoutControlItem1;

	private EmptySpaceItem ProgramTitle;

	private SimpleSeparator simpleSeparator1;

	private EmptySpaceItem Company;

	private EmptySpaceItem IdatNotice;

	private EmptySpaceItem emptySpaceItem5;

	private EmptySpaceItem emptySpaceItem6;

	private SimpleSeparator simpleSeparator2;

	private SimpleSeparator simpleSeparator3;

	private PanelControl panelControl1;

	private LabelControl labelControl1;

	private LayoutControlItem layoutControlItem2;

	private EmptySpaceItem emptySpaceItem2;

	private PanelControl panelControl2;

	private LabelControl labelControl2;

	private LayoutControlItem layoutControlItem4;

	private SimpleSeparator simpleSeparator4;

	private SimpleSeparator simpleSeparator5;

	private PictureEdit pictureEdit2;

	private LabelControl labelControl3;

	private ucSubNotice ucSubNotice_con;

	private LayoutControlItem layoutControlItem5;

	[Browsable(true)]
	[Description("IDAT Framework 공지사항 유무를 설정합니다.")]
	public bool IsViewIdatUpdateHistory
	{
		get
		{
			return _isViewIdatUpdateHistory;
		}
		set
		{
			_isViewIdatUpdateHistory = value;
			if (value)
			{
				IdatNotice.Visibility = LayoutVisibility.Always;
			}
			else
			{
				IdatNotice.Visibility = LayoutVisibility.Never;
			}
		}
	}

	[Browsable(true)]
	[DefaultValue("IDAT Framework 1.0")]
	public string MainProgramTitleString
	{
		get
		{
			return _MainProgramTitleString;
		}
		set
		{
			_MainProgramTitleString = value;
			ProgramTitle.Text = value;
			labelControl3.Text = value;
		}
	}

	[Browsable(true)]
	[DefaultValue("ID Information System")]
	public string CompanyNameString
	{
		get
		{
			return _CompanyNameString;
		}
		set
		{
			_CompanyNameString = value;
			Company.Text = value;
		}
	}

	[Browsable(true)]
	[Description("프레임웍 공지사항 내용을 설정하거나 가져옵니다.")]
	public string NoticeText
	{
		get
		{
			return IdatNotice.Text.Replace("<br>", "\r\n".ToString());
		}
		set
		{
			IdatNotice.Text = value.Replace("\r\n".ToString(), "<br>");
		}
	}

	[Browsable(true)]
	[Description("공지사항 내용을 설정하거나 가져옵니다.")]
	public DataTable NoticeDatatable
	{
		get
		{
			return ucSubNotice_con.DataSource;
		}
		set
		{
			ucSubNotice_con.DataSource = value;
		}
	}

	[Browsable(false)]
	[Description("공지사항 GridView 객체를 가져옵니다.")]
	public GridView NoticeGridView => ucSubNotice_con.GvNotice;

	[Browsable(true)]
	[Description("메인 아이콘 Width 설정합니다.")]
	public int MainIconWidth
	{
		get
		{
			return layoutControlItem1.Size.Width;
		}
		set
		{
			Size size = layoutControlItem1.Size;
			size.Width = value;
			Size minSize = layoutControlItem1.MinSize;
			minSize.Width = value;
			layoutControlItem1.Size = size;
			layoutControlItem1.MinSize = minSize;
		}
	}

	[Description("메인 아이콘 정보를 설정합니다.")]
	[Browsable(true)]
	public Image MainIcon
	{
		get
		{
			return pictureEdit_MainIcon.Image;
		}
		set
		{
			pictureEdit_MainIcon.Image = value;
		}
	}

	[Browsable(true)]
	[Description("아래 아이콘 정보를 설정합니다.")]
	public Image DownIcon
	{
		get
		{
			return pictureEdit2.Image;
		}
		set
		{
			pictureEdit2.Image = value;
		}
	}

	[Browsable(true)]
	[Description("Top Border색상을 지정합니다.")]
	public Color TopBorderBackColor
	{
		get
		{
			return panelControl1.BackColor;
		}
		set
		{
			panelControl1.BackColor = value;
		}
	}

	[Description("Bottom Border색상을 지정합니다.")]
	[Browsable(true)]
	public Color BottomBorderBackColor
	{
		get
		{
			return panelControl2.BackColor;
		}
		set
		{
			panelControl2.BackColor = value;
		}
	}

	[Browsable(true)]
	[Description("공지사항의 신규 아이콘 표시 여부를 지정합니다.")]
	public bool IsShowNewDataIcon
	{
		get
		{
			return _IsShowNewDataIcon;
		}
		set
		{
			_IsShowNewDataIcon = value;
		}
	}

	public int SubNoticeTitleMaxLength
	{
		get
		{
			return _SubNoticeTitleMaxLength;
		}
		set
		{
			_SubNoticeTitleMaxLength = value;
			ucSubNotice_con.SubjectMaxLength = value;
		}
	}

	public IdatNoticeInfo()
	{
		InitializeComponent();
	}

	protected override void OnLoad(EventArgs e)
	{
		IdatNotice.Text = getNoticeMsg();
		ucSubNotice_con.GvNotice.DoubleClick += GvNotice_DoubleClick;
	}

	public virtual void GvNotice_DoubleClick(object sender, EventArgs e)
	{
		ShowFocusedRowDetailView();
	}

	public virtual void InitSubNoticeControl()
	{
		ucSubNotice_con.InitSubNoticeControl();
	}

	public virtual void ShowFocusedRowDetailView()
	{
		ucSubNotice_con.ShowFocusedRowDetailView();
	}

	private string getNoticeMsg()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<br>");
		stringBuilder.Append("IDAT Frmaework Update History");
		stringBuilder.Append("<br>");
		stringBuilder.Append("<br>");
		stringBuilder.Append("<br>");
		stringBuilder.Append("1. DLL을 최신 버전으로 항상 유지하시기 바랍니다.<br>");
		stringBuilder.Append("- 유지 방법은 IDAT 프레임웍 경로의 DLL폴더 안에 업데이트 파일을 실행하면 최신버전으로 다운을 받을 수 있습니다.");
		stringBuilder.Append("<br>");
		stringBuilder.Append("<br>");
		stringBuilder.Append("2. DX 컨트롤과 그리드 컨트롤 간의 바인딩을 지정 할 수 있습니다. 각 IDAT 에디터 컨트롤의 속성 [BindGridControl]을 확인하세요. [DateTime : 2012.05.16, 작성자 : 남경필]");
		stringBuilder.Append("<br>");
		stringBuilder.Append("<br>");
		stringBuilder.Append("3. DX 컨트롤의 IdatDxMonth 컨트롤이 추가 되었습니다. [DateTime : 2012.06.08, 작성자 : 남경필]");
		return stringBuilder.ToString();
	}

	private void pictureEdit_MainIcon_EditValueChanged(object sender, EventArgs e)
	{
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IDAT.Devexpress.NOTICE.IdatNoticeInfo));
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.ucSubNotice_con = new IDAT.Devexpress.NOTICE.SUB.ucSubNotice();
		this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
		this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.pictureEdit_MainIcon = new DevExpress.XtraEditors.PictureEdit();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.ProgramTitle = new DevExpress.XtraLayout.EmptySpaceItem();
		this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
		this.Company = new DevExpress.XtraLayout.EmptySpaceItem();
		this.IdatNotice = new DevExpress.XtraLayout.EmptySpaceItem();
		this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.simpleSeparator2 = new DevExpress.XtraLayout.SimpleSeparator();
		this.simpleSeparator3 = new DevExpress.XtraLayout.SimpleSeparator();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.simpleSeparator4 = new DevExpress.XtraLayout.SimpleSeparator();
		this.simpleSeparator5 = new DevExpress.XtraLayout.SimpleSeparator();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.panelControl2).BeginInit();
		this.panelControl2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit2.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).BeginInit();
		this.panelControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit_MainIcon.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.ProgramTitle).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.Company).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.IdatNotice).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.ucSubNotice_con);
		this.layoutControl1.Controls.Add(this.panelControl2);
		this.layoutControl1.Controls.Add(this.panelControl1);
		this.layoutControl1.Controls.Add(this.pictureEdit_MainIcon);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(477, 367, 250, 350);
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(1604, 995);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.ucSubNotice_con.DataSource = null;
		this.ucSubNotice_con.Location = new System.Drawing.Point(803, 223);
		this.ucSubNotice_con.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
		this.ucSubNotice_con.Name = "ucSubNotice_con";
		this.ucSubNotice_con.Size = new System.Drawing.Size(801, 656);
		this.ucSubNotice_con.SubjectMaxLength = 10;
		this.ucSubNotice_con.TabIndex = 7;
		this.panelControl2.Appearance.BackColor = System.Drawing.Color.FromArgb(0, 0, 32);
		this.panelControl2.Appearance.Options.UseBackColor = true;
		this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.panelControl2.Controls.Add(this.pictureEdit2);
		this.panelControl2.Controls.Add(this.labelControl3);
		this.panelControl2.Controls.Add(this.labelControl2);
		this.panelControl2.Location = new System.Drawing.Point(2, 937);
		this.panelControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
		this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
		this.panelControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.panelControl2.Name = "panelControl2";
		this.panelControl2.Size = new System.Drawing.Size(1600, 56);
		this.panelControl2.TabIndex = 6;
		this.pictureEdit2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.pictureEdit2.EditValue = resources.GetObject("pictureEdit2.EditValue");
		this.pictureEdit2.Location = new System.Drawing.Point(1087, 2);
		this.pictureEdit2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.pictureEdit2.Name = "pictureEdit2";
		this.pictureEdit2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.pictureEdit2.Properties.Appearance.Options.UseBackColor = true;
		this.pictureEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.pictureEdit2.Properties.ShowMenu = false;
		this.pictureEdit2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
		this.pictureEdit2.Size = new System.Drawing.Size(64, 83);
		this.pictureEdit2.StyleController = this.layoutControl1;
		this.pictureEdit2.TabIndex = 5;
		this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.labelControl3.Appearance.ForeColor = System.Drawing.Color.White;
		this.labelControl3.Location = new System.Drawing.Point(1160, 14);
		this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(210, 22);
		this.labelControl3.TabIndex = 1;
		this.labelControl3.Text = "ECM Framework. Ver 1.0.0";
		this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.labelControl2.Appearance.ForeColor = System.Drawing.Color.White;
		this.labelControl2.Location = new System.Drawing.Point(1160, 46);
		this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(360, 22);
		this.labelControl2.TabIndex = 0;
		this.labelControl2.Text = "Copyright (c) ECM System All rights reserved.";
		this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(0, 0, 64);
		this.panelControl1.Appearance.Options.UseBackColor = true;
		this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.panelControl1.Controls.Add(this.labelControl1);
		this.panelControl1.Location = new System.Drawing.Point(2, 2);
		this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
		this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
		this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.panelControl1.Name = "panelControl1";
		this.panelControl1.Size = new System.Drawing.Size(1600, 34);
		this.panelControl1.TabIndex = 5;
		this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
		this.labelControl1.Location = new System.Drawing.Point(1544, 5);
		this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(49, 22);
		this.labelControl1.TabIndex = 0;
		this.labelControl1.Text = "Notice";
		this.pictureEdit_MainIcon.EditValue = resources.GetObject("pictureEdit_MainIcon.EditValue");
		this.pictureEdit_MainIcon.Location = new System.Drawing.Point(2, 40);
		this.pictureEdit_MainIcon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.pictureEdit_MainIcon.Name = "pictureEdit_MainIcon";
		this.pictureEdit_MainIcon.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.pictureEdit_MainIcon.Properties.Appearance.Options.UseBackColor = true;
		this.pictureEdit_MainIcon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.pictureEdit_MainIcon.Properties.ShowMenu = false;
		this.pictureEdit_MainIcon.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
		this.pictureEdit_MainIcon.Size = new System.Drawing.Size(139, 87);
		this.pictureEdit_MainIcon.StyleController = this.layoutControl1;
		this.pictureEdit_MainIcon.TabIndex = 4;
		this.pictureEdit_MainIcon.EditValueChanged += new System.EventHandler(pictureEdit_MainIcon_EditValueChanged);
		this.layoutControlGroup1.CustomizationFormText = "Root";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[15]
		{
			this.layoutControlItem1, this.ProgramTitle, this.simpleSeparator1, this.Company, this.IdatNotice, this.emptySpaceItem5, this.emptySpaceItem6, this.simpleSeparator2, this.simpleSeparator3, this.layoutControlItem2,
			this.emptySpaceItem2, this.layoutControlItem4, this.simpleSeparator4, this.simpleSeparator5, this.layoutControlItem5
		});
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "Root";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(1604, 995);
		this.layoutControlGroup1.Text = "Root";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.pictureEdit_MainIcon;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 38);
		this.layoutControlItem1.MinSize = new System.Drawing.Size(100, 24);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(143, 91);
		this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Right;
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		this.ProgramTitle.AllowHotTrack = false;
		this.ProgramTitle.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 30f);
		this.ProgramTitle.AppearanceItemCaption.Options.UseFont = true;
		this.ProgramTitle.AppearanceItemCaption.Options.UseTextOptions = true;
		this.ProgramTitle.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.ProgramTitle.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
		this.ProgramTitle.CustomizationFormText = "IDAT Framework 1.0";
		this.ProgramTitle.Location = new System.Drawing.Point(145, 38);
		this.ProgramTitle.MaxSize = new System.Drawing.Size(0, 70);
		this.ProgramTitle.MinSize = new System.Drawing.Size(100, 70);
		this.ProgramTitle.Name = "ProgramTitle";
		this.ProgramTitle.Size = new System.Drawing.Size(1459, 70);
		this.ProgramTitle.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.ProgramTitle.Text = "IDAT Framework 1.0";
		this.ProgramTitle.TextSize = new System.Drawing.Size(0, 0);
		this.ProgramTitle.TextVisible = true;
		this.simpleSeparator1.AllowHotTrack = false;
		this.simpleSeparator1.CustomizationFormText = "simpleSeparator1";
		this.simpleSeparator1.Location = new System.Drawing.Point(143, 38);
		this.simpleSeparator1.Name = "simpleSeparator1";
		this.simpleSeparator1.Size = new System.Drawing.Size(2, 91);
		this.simpleSeparator1.Text = "simpleSeparator1";
		this.Company.AllowHotTrack = false;
		this.Company.AppearanceItemCaption.Options.UseTextOptions = true;
		this.Company.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.Company.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
		this.Company.CustomizationFormText = "ID Information System";
		this.Company.Location = new System.Drawing.Point(145, 108);
		this.Company.MaxSize = new System.Drawing.Size(0, 21);
		this.Company.MinSize = new System.Drawing.Size(10, 21);
		this.Company.Name = "Company";
		this.Company.Size = new System.Drawing.Size(1459, 21);
		this.Company.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.Company.Text = "ID Information System";
		this.Company.TextSize = new System.Drawing.Size(0, 0);
		this.Company.TextVisible = true;
		this.IdatNotice.AllowHotTrack = false;
		this.IdatNotice.AllowHtmlStringInCaption = true;
		this.IdatNotice.AppearanceItemCaption.Options.UseTextOptions = true;
		this.IdatNotice.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.IdatNotice.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
		this.IdatNotice.AppearanceItemCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
		this.IdatNotice.CustomizationFormText = "emptySpaceItem1";
		this.IdatNotice.Location = new System.Drawing.Point(0, 175);
		this.IdatNotice.MinSize = new System.Drawing.Size(104, 24);
		this.IdatNotice.Name = "IdatNotice";
		this.IdatNotice.Size = new System.Drawing.Size(801, 704);
		this.IdatNotice.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.IdatNotice.Text = "1. DLL을 최신 버전으로 항상 유지하시기 바랍니다.<br>- 유지 방법은 IDAT 프레임웍 경로의 DLL폴더 안에 업데이트 파일을 실행하면 최신버전으로 다운을 받을 수 있습니다.";
		this.IdatNotice.TextSize = new System.Drawing.Size(0, 0);
		this.IdatNotice.TextVisible = true;
		this.emptySpaceItem5.AllowHotTrack = false;
		this.emptySpaceItem5.CustomizationFormText = "emptySpaceItem5";
		this.emptySpaceItem5.Location = new System.Drawing.Point(0, 129);
		this.emptySpaceItem5.Name = "emptySpaceItem5";
		this.emptySpaceItem5.Size = new System.Drawing.Size(1604, 44);
		this.emptySpaceItem5.Text = "emptySpaceItem5";
		this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
		this.emptySpaceItem6.AllowHotTrack = false;
		this.emptySpaceItem6.CustomizationFormText = "emptySpaceItem6";
		this.emptySpaceItem6.Location = new System.Drawing.Point(0, 881);
		this.emptySpaceItem6.Name = "emptySpaceItem6";
		this.emptySpaceItem6.Size = new System.Drawing.Size(1604, 54);
		this.emptySpaceItem6.Text = "emptySpaceItem6";
		this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
		this.simpleSeparator2.AllowHotTrack = false;
		this.simpleSeparator2.CustomizationFormText = "simpleSeparator2";
		this.simpleSeparator2.Location = new System.Drawing.Point(801, 175);
		this.simpleSeparator2.Name = "simpleSeparator2";
		this.simpleSeparator2.Size = new System.Drawing.Size(2, 704);
		this.simpleSeparator2.Text = "simpleSeparator2";
		this.simpleSeparator3.AllowHotTrack = false;
		this.simpleSeparator3.CustomizationFormText = "simpleSeparator3";
		this.simpleSeparator3.Location = new System.Drawing.Point(0, 173);
		this.simpleSeparator3.Name = "simpleSeparator3";
		this.simpleSeparator3.Size = new System.Drawing.Size(1604, 2);
		this.simpleSeparator3.Text = "simpleSeparator3";
		this.layoutControlItem2.AppearanceItemCaption.BackColor = System.Drawing.Color.Blue;
		this.layoutControlItem2.AppearanceItemCaption.BackColor2 = System.Drawing.Color.Blue;
		this.layoutControlItem2.AppearanceItemCaption.Options.UseBackColor = true;
		this.layoutControlItem2.Control = this.panelControl1;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.ShowInCustomizationForm = false;
		this.layoutControlItem2.Size = new System.Drawing.Size(1604, 38);
		this.layoutControlItem2.Text = "layoutControlItem2";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextToControlDistance = 0;
		this.layoutControlItem2.TextVisible = false;
		this.emptySpaceItem2.AllowHotTrack = false;
		this.emptySpaceItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12f);
		this.emptySpaceItem2.AppearanceItemCaption.Options.UseFont = true;
		this.emptySpaceItem2.AppearanceItemCaption.Options.UseTextOptions = true;
		this.emptySpaceItem2.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
		this.emptySpaceItem2.CustomizationFormText = "Latest news";
		this.emptySpaceItem2.Location = new System.Drawing.Point(803, 175);
		this.emptySpaceItem2.Name = "emptySpaceItem2";
		this.emptySpaceItem2.Size = new System.Drawing.Size(801, 46);
		this.emptySpaceItem2.Text = "Latest news";
		this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
		this.emptySpaceItem2.TextVisible = true;
		this.layoutControlItem4.Control = this.panelControl2;
		this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 935);
		this.layoutControlItem4.MaxSize = new System.Drawing.Size(0, 60);
		this.layoutControlItem4.MinSize = new System.Drawing.Size(104, 60);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(1604, 60);
		this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem4.Text = "layoutControlItem4";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextToControlDistance = 0;
		this.layoutControlItem4.TextVisible = false;
		this.simpleSeparator4.AllowHotTrack = false;
		this.simpleSeparator4.CustomizationFormText = "simpleSeparator4";
		this.simpleSeparator4.Location = new System.Drawing.Point(803, 221);
		this.simpleSeparator4.Name = "simpleSeparator4";
		this.simpleSeparator4.Size = new System.Drawing.Size(801, 2);
		this.simpleSeparator4.Text = "simpleSeparator4";
		this.simpleSeparator5.AllowHotTrack = false;
		this.simpleSeparator5.CustomizationFormText = "simpleSeparator5";
		this.simpleSeparator5.Location = new System.Drawing.Point(0, 879);
		this.simpleSeparator5.Name = "simpleSeparator5";
		this.simpleSeparator5.Size = new System.Drawing.Size(1604, 2);
		this.simpleSeparator5.Text = "simpleSeparator5";
		this.layoutControlItem5.Control = this.ucSubNotice_con;
		this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
		this.layoutControlItem5.Location = new System.Drawing.Point(803, 223);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlItem5.Size = new System.Drawing.Size(801, 656);
		this.layoutControlItem5.Text = "layoutControlItem5";
		this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.TextToControlDistance = 0;
		this.layoutControlItem5.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(10f, 22f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		base.Name = "IdatNoticeInfo";
		base.Size = new System.Drawing.Size(1604, 995);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.panelControl2).EndInit();
		this.panelControl2.ResumeLayout(false);
		this.panelControl2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit2.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).EndInit();
		this.panelControl1.ResumeLayout(false);
		this.panelControl1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit_MainIcon.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.ProgramTitle).EndInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.Company).EndInit();
		((System.ComponentModel.ISupportInitialize)this.IdatNotice).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		base.ResumeLayout(false);
	}
}
