using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;
using IDAT.Properties;

namespace IDAT.UI.MessageBox;

internal class IDATMessageBox_OK : BaseMessageBox
{
	public enum MESSAGEOK_TYPE
	{
		OK,
		WARNING
	}

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private SimpleButton btnOK;

	private EmptySpaceItem emptySpaceItem3;

	private LayoutControlItem layoutControlItem2;

	private PictureEdit pictureEdit1;

	private LayoutControlItem layoutControlItem1;

	private EmptySpaceItem emptySpaceItem2;

	private SimpleSeparator simpleSeparator1;

	private SimpleSeparator simpleSeparator2;

	private SimpleLabelItem simpleLabelItem_TEXT;

	private string m_MessageText = "";

	private string m_CaptionText = "";

	public string MessageText
	{
		get
		{
			return m_MessageText;
		}
		set
		{
			m_MessageText = value;
			simpleLabelItem_TEXT.Text = value;
		}
	}

	public string CaptionText
	{
		get
		{
			return m_CaptionText;
		}
		set
		{
			m_CaptionText = value;
			Text = value;
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
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
		this.btnOK = new DevExpress.XtraEditors.SimpleButton();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
		this.simpleSeparator2 = new DevExpress.XtraLayout.SimpleSeparator();
		this.simpleLabelItem_TEXT = new DevExpress.XtraLayout.SimpleLabelItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.simpleLabelItem_TEXT).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.AllowCustomizationMenu = false;
		this.layoutControl1.Controls.Add(this.pictureEdit1);
		this.layoutControl1.Controls.Add(this.btnOK);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(806, 379, 250, 350);
		this.layoutControl1.OptionsFocus.MoveFocusDirection = DevExpress.XtraLayout.MoveFocusDirection.DownThenAcross;
		this.layoutControl1.OptionsView.HighlightFocusedItem = true;
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(487, 195);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.pictureEdit1.EditValue = IDAT.Properties.Resources.msgbox_information;
		this.pictureEdit1.Location = new System.Drawing.Point(2, 19);
		this.pictureEdit1.Name = "pictureEdit1";
		this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
		this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.pictureEdit1.Size = new System.Drawing.Size(96, 132);
		this.pictureEdit1.StyleController = this.layoutControl1;
		this.pictureEdit1.TabIndex = 6;
		this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnOK.Location = new System.Drawing.Point(409, 157);
		this.btnOK.Name = "btnOK";
		this.btnOK.Size = new System.Drawing.Size(76, 36);
		this.btnOK.StyleController = this.layoutControl1;
		this.btnOK.TabIndex = 5;
		this.btnOK.Text = "OK";
		this.btnOK.Click += new System.EventHandler(btnOK_Click);
		this.layoutControlGroup1.CustomizationFormText = "Root";
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[7] { this.emptySpaceItem3, this.layoutControlItem2, this.layoutControlItem1, this.emptySpaceItem2, this.simpleSeparator1, this.simpleSeparator2, this.simpleLabelItem_TEXT });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "Root";
		this.layoutControlGroup1.Size = new System.Drawing.Size(487, 195);
		this.layoutControlGroup1.Text = "Root";
		this.layoutControlGroup1.TextVisible = false;
		this.emptySpaceItem3.AllowHotTrack = false;
		this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
		this.emptySpaceItem3.Location = new System.Drawing.Point(0, 155);
		this.emptySpaceItem3.MinSize = new System.Drawing.Size(104, 24);
		this.emptySpaceItem3.Name = "emptySpaceItem3";
		this.emptySpaceItem3.Size = new System.Drawing.Size(407, 40);
		this.emptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.emptySpaceItem3.Text = "emptySpaceItem3";
		this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.Control = this.btnOK;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(407, 155);
		this.layoutControlItem2.MaxSize = new System.Drawing.Size(80, 40);
		this.layoutControlItem2.MinSize = new System.Drawing.Size(80, 40);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(80, 40);
		this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem2.Text = "layoutControlItem2";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextToControlDistance = 0;
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem1.AppearanceItemCaption.Options.UseTextOptions = true;
		this.layoutControlItem1.AppearanceItemCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
		this.layoutControlItem1.Control = this.pictureEdit1;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 17);
		this.layoutControlItem1.MaxSize = new System.Drawing.Size(100, 0);
		this.layoutControlItem1.MinSize = new System.Drawing.Size(100, 60);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(100, 136);
		this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
		this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Right;
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		this.emptySpaceItem2.AllowHotTrack = false;
		this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
		this.emptySpaceItem2.Location = new System.Drawing.Point(0, 0);
		this.emptySpaceItem2.MaxSize = new System.Drawing.Size(0, 15);
		this.emptySpaceItem2.MinSize = new System.Drawing.Size(104, 15);
		this.emptySpaceItem2.Name = "emptySpaceItem2";
		this.emptySpaceItem2.Size = new System.Drawing.Size(487, 15);
		this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.emptySpaceItem2.Text = "emptySpaceItem2";
		this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
		this.simpleSeparator1.AllowHotTrack = false;
		this.simpleSeparator1.CustomizationFormText = "simpleSeparator1";
		this.simpleSeparator1.Location = new System.Drawing.Point(0, 153);
		this.simpleSeparator1.Name = "simpleSeparator1";
		this.simpleSeparator1.Size = new System.Drawing.Size(487, 2);
		this.simpleSeparator1.Text = "simpleSeparator1";
		this.simpleSeparator2.AllowHotTrack = false;
		this.simpleSeparator2.CustomizationFormText = "simpleSeparator2";
		this.simpleSeparator2.Location = new System.Drawing.Point(0, 15);
		this.simpleSeparator2.Name = "simpleSeparator2";
		this.simpleSeparator2.Size = new System.Drawing.Size(487, 2);
		this.simpleSeparator2.Text = "simpleSeparator2";
		this.simpleLabelItem_TEXT.AllowHotTrack = false;
		this.simpleLabelItem_TEXT.AppearanceItemCaption.Options.UseTextOptions = true;
		this.simpleLabelItem_TEXT.AppearanceItemCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
		this.simpleLabelItem_TEXT.CustomizationFormText = "LabelsimpleLabelItem_TEXT";
		this.simpleLabelItem_TEXT.Location = new System.Drawing.Point(100, 17);
		this.simpleLabelItem_TEXT.MinSize = new System.Drawing.Size(126, 18);
		this.simpleLabelItem_TEXT.Name = "simpleLabelItem_TEXT";
		this.simpleLabelItem_TEXT.Size = new System.Drawing.Size(387, 136);
		this.simpleLabelItem_TEXT.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.simpleLabelItem_TEXT.Text = "LabelsimpleLabelItem_TEXTsdaLabelsimpleLabelItem_TEXTsdaLabelsimpleLabelItem_TEXTsdaLabelsimpleLabelItem_TEXTsdaLabelsimpleLabelItem_TEXTsdaLabelsimpleLabelItem_TEXTsdaLabelsimpleLabelItem_TEXTsda";
		this.simpleLabelItem_TEXT.TextSize = new System.Drawing.Size(1190, 14);
		base.Appearance.Font = new System.Drawing.Font("Tahoma", 8f);
		base.Appearance.Options.UseFont = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(487, 215);
		base.Controls.Add(this.layoutControl1);
		this.MinimumSize = new System.Drawing.Size(390, 190);
		base.Name = "IDATMessageBox_OK";
		base.ShowIcon = false;
		base.Load += new System.EventHandler(IDATMessageBox_OK_Load);
		base.Controls.SetChildIndex(this.layoutControl1, 0);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.simpleLabelItem_TEXT).EndInit();
		base.ResumeLayout(false);
	}

	public IDATMessageBox_OK()
	{
		InitializeComponent();
		simpleLabelItem_TEXT.Text = "";
	}

	public IDATMessageBox_OK(MESSAGEOK_TYPE msg_TYPE)
		: this()
	{
		switch (msg_TYPE)
		{
		case MESSAGEOK_TYPE.OK:
			pictureEdit1.Image = Resources.msgbox_information;
			break;
		case MESSAGEOK_TYPE.WARNING:
			pictureEdit1.Image = Resources.msgbox_warning;
			break;
		}
		Application.DoEvents();
	}

	public void Show(string msg)
	{
		MessageText = msg;
		ShowDialog();
	}

	public void Show(string msg, string caption)
	{
		MessageText = msg;
		CaptionText = caption;
		ShowDialog();
	}

	private void btnOK_Click(object sender, EventArgs e)
	{
		OK();
	}

	public override void OK()
	{
		base.OK();
		Close();
	}

	private void IDATMessageBox_OK_Load(object sender, EventArgs e)
	{
		base.Size = new Size(620, 320);
	}
}
