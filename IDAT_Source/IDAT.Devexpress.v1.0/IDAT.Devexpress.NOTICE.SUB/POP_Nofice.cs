using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace IDAT.Devexpress.NOTICE.SUB;

public class POP_Nofice : Form
{
	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private TextEdit txtUserName;

	private TextEdit txtTitle;

	private TextEdit txtDATE;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem4;

	private MemoEdit memContent;

	private LayoutControlItem layoutControlItem6;

	private EmptySpaceItem emptySpaceItem1;

	private EmptySpaceItem emptySpaceItem2;

	private SimpleSeparator simpleSeparator1;

	public POP_Nofice()
	{
		InitializeComponent();
	}

	public POP_Nofice(string p_Date, string p_Title, string p_Name, string p_Content)
	{
		InitializeComponent();
		txtDATE.EditValue = p_Date;
		txtTitle.EditValue = p_Title;
		txtUserName.EditValue = p_Name;
		memContent.Text = p_Content;
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
		this.memContent = new DevExpress.XtraEditors.MemoEdit();
		this.txtUserName = new DevExpress.XtraEditors.TextEdit();
		this.txtTitle = new DevExpress.XtraEditors.TextEdit();
		this.txtDATE = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.memContent.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtUserName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtTitle.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtDATE.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator1).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.memContent);
		this.layoutControl1.Controls.Add(this.txtUserName);
		this.layoutControl1.Controls.Add(this.txtTitle);
		this.layoutControl1.Controls.Add(this.txtDATE);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(788, 160, 250, 350);
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(685, 368);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.memContent.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
		this.memContent.Location = new System.Drawing.Point(56, 74);
		this.memContent.Name = "memContent";
		this.memContent.Properties.Appearance.Options.UseTextOptions = true;
		this.memContent.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
		this.memContent.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
		this.memContent.Properties.AppearanceReadOnly.Options.UseBackColor = true;
		this.memContent.Properties.ReadOnly = true;
		this.memContent.Size = new System.Drawing.Size(627, 292);
		this.memContent.StyleController = this.layoutControl1;
		this.memContent.TabIndex = 9;
		this.txtUserName.Location = new System.Drawing.Point(56, 26);
		this.txtUserName.Name = "txtUserName";
		this.txtUserName.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
		this.txtUserName.Properties.AppearanceReadOnly.Options.UseBackColor = true;
		this.txtUserName.Properties.ReadOnly = true;
		this.txtUserName.Size = new System.Drawing.Size(284, 20);
		this.txtUserName.StyleController = this.layoutControl1;
		this.txtUserName.TabIndex = 7;
		this.txtTitle.Location = new System.Drawing.Point(56, 50);
		this.txtTitle.Name = "txtTitle";
		this.txtTitle.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
		this.txtTitle.Properties.AppearanceReadOnly.Options.UseBackColor = true;
		this.txtTitle.Properties.ReadOnly = true;
		this.txtTitle.Size = new System.Drawing.Size(627, 20);
		this.txtTitle.StyleController = this.layoutControl1;
		this.txtTitle.TabIndex = 5;
		this.txtDATE.Location = new System.Drawing.Point(56, 2);
		this.txtDATE.Name = "txtDATE";
		this.txtDATE.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
		this.txtDATE.Properties.AppearanceReadOnly.Options.UseBackColor = true;
		this.txtDATE.Properties.ReadOnly = true;
		this.txtDATE.Size = new System.Drawing.Size(284, 20);
		this.txtDATE.StyleController = this.layoutControl1;
		this.txtDATE.TabIndex = 4;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[7] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem6, this.emptySpaceItem1, this.layoutControlItem4, this.emptySpaceItem2, this.simpleSeparator1 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "Root";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(685, 368);
		this.layoutControlGroup1.Text = "Root";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.txtDATE;
		this.layoutControlItem1.CustomizationFormText = "순번";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(342, 24);
		this.layoutControlItem1.Text = "Date";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(50, 14);
		this.layoutControlItem2.Control = this.txtTitle;
		this.layoutControlItem2.CustomizationFormText = "제목";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 48);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(685, 24);
		this.layoutControlItem2.Text = "Title";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(50, 14);
		this.layoutControlItem6.Control = this.memContent;
		this.layoutControlItem6.CustomizationFormText = "내용";
		this.layoutControlItem6.Location = new System.Drawing.Point(0, 72);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(685, 296);
		this.layoutControlItem6.Text = "Contents";
		this.layoutControlItem6.TextSize = new System.Drawing.Size(50, 14);
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
		this.emptySpaceItem1.Location = new System.Drawing.Point(344, 0);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(341, 24);
		this.emptySpaceItem1.Text = "emptySpaceItem1";
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.Control = this.txtUserName;
		this.layoutControlItem4.CustomizationFormText = "작성자";
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 24);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(342, 24);
		this.layoutControlItem4.Text = "Writer";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(50, 14);
		this.emptySpaceItem2.AllowHotTrack = false;
		this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
		this.emptySpaceItem2.Location = new System.Drawing.Point(344, 24);
		this.emptySpaceItem2.Name = "emptySpaceItem2";
		this.emptySpaceItem2.Size = new System.Drawing.Size(341, 24);
		this.emptySpaceItem2.Text = "emptySpaceItem2";
		this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
		this.simpleSeparator1.AllowHotTrack = false;
		this.simpleSeparator1.CustomizationFormText = "simpleSeparator1";
		this.simpleSeparator1.Location = new System.Drawing.Point(342, 0);
		this.simpleSeparator1.Name = "simpleSeparator1";
		this.simpleSeparator1.Size = new System.Drawing.Size(2, 48);
		this.simpleSeparator1.Text = "simpleSeparator1";
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(685, 368);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "POP_Nofice";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.memContent.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtUserName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtTitle.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtDATE.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator1).EndInit();
		base.ResumeLayout(false);
	}
}
