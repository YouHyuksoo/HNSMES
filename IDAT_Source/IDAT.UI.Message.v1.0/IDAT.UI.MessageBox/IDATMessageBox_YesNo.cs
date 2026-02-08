using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using IDAT.Properties;

namespace IDAT.UI.MessageBox;

internal class IDATMessageBox_YesNo : BaseMessageBox
{
	private IContainer components = null;

	private LayoutControl layOut;

	private PictureEdit imgMsg;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItemMsg;

	private SimpleButton btnNo;

	private SimpleButton btnYes;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private LabelControl lblMsg;

	private LayoutControlItem layoutControlItem1;

	private SimpleSeparator simpleSeparator1;

	private SimpleSeparator simpleSeparator2;

	private SimpleLabelItem simpleLabelItem_TEXT;

	private string m_MessageText = "";

	private string m_CaptionText = "";

	private string m_remarkText = "";

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

	public string RemarkText
	{
		get
		{
			return m_remarkText;
		}
		set
		{
			m_remarkText = value;
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
		this.layOut = new DevExpress.XtraLayout.LayoutControl();
		this.lblMsg = new DevExpress.XtraEditors.LabelControl();
		this.btnNo = new DevExpress.XtraEditors.SimpleButton();
		this.btnYes = new DevExpress.XtraEditors.SimpleButton();
		this.imgMsg = new DevExpress.XtraEditors.PictureEdit();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItemMsg = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
		this.simpleSeparator2 = new DevExpress.XtraLayout.SimpleSeparator();
		this.simpleLabelItem_TEXT = new DevExpress.XtraLayout.SimpleLabelItem();
		((System.ComponentModel.ISupportInitialize)this.layOut).BeginInit();
		this.layOut.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.imgMsg.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItemMsg).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.simpleLabelItem_TEXT).BeginInit();
		base.SuspendLayout();
		this.layOut.AllowCustomizationMenu = false;
		this.layOut.Controls.Add(this.lblMsg);
		this.layOut.Controls.Add(this.btnNo);
		this.layOut.Controls.Add(this.btnYes);
		this.layOut.Controls.Add(this.imgMsg);
		this.layOut.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layOut.Location = new System.Drawing.Point(0, 0);
		this.layOut.Name = "layOut";
		this.layOut.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(990, 284, 250, 350);
		this.layOut.OptionsFocus.MoveFocusDirection = DevExpress.XtraLayout.MoveFocusDirection.DownThenAcross;
		this.layOut.OptionsView.HighlightFocusedItem = true;
		this.layOut.Root = this.layoutControlGroup1;
		this.layOut.Size = new System.Drawing.Size(434, 202);
		this.layOut.TabIndex = 1;
		this.layOut.Text = "layoutControl1";
		this.lblMsg.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
		this.lblMsg.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
		this.lblMsg.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblMsg.Location = new System.Drawing.Point(2, 164);
		this.lblMsg.Name = "lblMsg";
		this.lblMsg.Size = new System.Drawing.Size(270, 36);
		this.lblMsg.StyleController = this.layOut;
		this.lblMsg.TabIndex = 7;
		this.btnNo.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnNo.Location = new System.Drawing.Point(356, 164);
		this.btnNo.Name = "btnNo";
		this.btnNo.Size = new System.Drawing.Size(76, 36);
		this.btnNo.StyleController = this.layOut;
		this.btnNo.TabIndex = 6;
		this.btnNo.Text = "No";
		this.btnNo.Click += new System.EventHandler(btnNo_Click);
		this.btnYes.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnYes.Location = new System.Drawing.Point(276, 164);
		this.btnYes.Name = "btnYes";
		this.btnYes.Size = new System.Drawing.Size(76, 36);
		this.btnYes.StyleController = this.layOut;
		this.btnYes.TabIndex = 5;
		this.btnYes.Text = "Yes";
		this.btnYes.Click += new System.EventHandler(btnYes_Click);
		this.imgMsg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.imgMsg.EditValue = IDAT.Properties.Resources.msgbox_question1;
		this.imgMsg.Location = new System.Drawing.Point(10, 7);
		this.imgMsg.Name = "imgMsg";
		this.imgMsg.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.imgMsg.Properties.Appearance.ForeColor = System.Drawing.Color.Transparent;
		this.imgMsg.Properties.Appearance.Options.UseBackColor = true;
		this.imgMsg.Properties.Appearance.Options.UseForeColor = true;
		this.imgMsg.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.imgMsg.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
		this.imgMsg.Size = new System.Drawing.Size(80, 148);
		this.imgMsg.StyleController = this.layOut;
		this.imgMsg.TabIndex = 4;
		this.layoutControlGroup1.CustomizationFormText = "Root";
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[7] { this.layoutControlItemMsg, this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem1, this.simpleSeparator1, this.simpleSeparator2, this.simpleLabelItem_TEXT });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "Root";
		this.layoutControlGroup1.Size = new System.Drawing.Size(434, 202);
		this.layoutControlGroup1.Text = "Root";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItemMsg.AppearanceItemCaption.Options.UseTextOptions = true;
		this.layoutControlItemMsg.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.layoutControlItemMsg.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
		this.layoutControlItemMsg.AppearanceItemCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
		this.layoutControlItemMsg.Control = this.imgMsg;
		this.layoutControlItemMsg.CustomizationFormText = "DSJKLDJKDJKSDJKLSDAJSDKJJSDKJSKLJSDKLJSDKLJSDKLSDJKLJKLSDJKLJLDKSJDKLJDSKLSDJKLDSJKLDJDKLJKLJSKLSDJL";
		this.layoutControlItemMsg.Location = new System.Drawing.Point(0, 2);
		this.layoutControlItemMsg.MinSize = new System.Drawing.Size(100, 60);
		this.layoutControlItemMsg.Name = "layoutControlItemMsg";
		this.layoutControlItemMsg.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 5, 5);
		this.layoutControlItemMsg.Size = new System.Drawing.Size(100, 158);
		this.layoutControlItemMsg.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItemMsg.Text = "DSJKLDJKDJKSDJKLSDAJSDKJJSDKJSKLJSDKLJSDKLJSDKLSDJKLJKLSDJKLJLDKSJDKLJDSKLSDJKLDSJKLDJDKLJKLJSKLSDJL";
		this.layoutControlItemMsg.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
		this.layoutControlItemMsg.TextLocation = DevExpress.Utils.Locations.Right;
		this.layoutControlItemMsg.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItemMsg.TextToControlDistance = 0;
		this.layoutControlItemMsg.TextVisible = false;
		this.layoutControlItem2.Control = this.btnYes;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(274, 162);
		this.layoutControlItem2.MaxSize = new System.Drawing.Size(80, 40);
		this.layoutControlItem2.MinSize = new System.Drawing.Size(80, 40);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(80, 40);
		this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem2.Text = "layoutControlItem2";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextToControlDistance = 0;
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem3.Control = this.btnNo;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(354, 162);
		this.layoutControlItem3.MaxSize = new System.Drawing.Size(80, 40);
		this.layoutControlItem3.MinSize = new System.Drawing.Size(80, 40);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(80, 40);
		this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem3.Text = "layoutControlItem3";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextToControlDistance = 0;
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem1.Control = this.lblMsg;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 162);
		this.layoutControlItem1.MinSize = new System.Drawing.Size(21, 11);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(274, 40);
		this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		this.simpleSeparator1.AllowHotTrack = false;
		this.simpleSeparator1.CustomizationFormText = "simpleSeparator1";
		this.simpleSeparator1.Location = new System.Drawing.Point(0, 160);
		this.simpleSeparator1.Name = "simpleSeparator1";
		this.simpleSeparator1.Size = new System.Drawing.Size(434, 2);
		this.simpleSeparator1.Text = "simpleSeparator1";
		this.simpleSeparator2.AllowHotTrack = false;
		this.simpleSeparator2.CustomizationFormText = "simpleSeparator2";
		this.simpleSeparator2.Location = new System.Drawing.Point(0, 0);
		this.simpleSeparator2.Name = "simpleSeparator2";
		this.simpleSeparator2.Size = new System.Drawing.Size(434, 2);
		this.simpleSeparator2.Text = "simpleSeparator2";
		this.simpleLabelItem_TEXT.AllowHotTrack = false;
		this.simpleLabelItem_TEXT.AppearanceItemCaption.Options.UseTextOptions = true;
		this.simpleLabelItem_TEXT.AppearanceItemCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
		this.simpleLabelItem_TEXT.CustomizationFormText = "LabelsimpleLabelItem1";
		this.simpleLabelItem_TEXT.Location = new System.Drawing.Point(100, 2);
		this.simpleLabelItem_TEXT.MinSize = new System.Drawing.Size(126, 18);
		this.simpleLabelItem_TEXT.Name = "simpleLabelItem_TEXT";
		this.simpleLabelItem_TEXT.Size = new System.Drawing.Size(334, 158);
		this.simpleLabelItem_TEXT.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.simpleLabelItem_TEXT.Text = "LabelsimpleLabelItem_TEXTsimpleLabelItem_TEXTsimpleLabelItem_TEXTsimpleLabelItem_TEXTsimpleLabelItem_TEXTsimpleLabelItem_TEXTsimpleLabelItem_TEXTsimpleLabelItem_TEXT";
		this.simpleLabelItem_TEXT.TextSize = new System.Drawing.Size(1020, 14);
		base.Appearance.Font = new System.Drawing.Font("Tahoma", 8f);
		base.Appearance.Options.UseFont = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(434, 222);
		base.Controls.Add(this.layOut);
		this.MinimumSize = new System.Drawing.Size(440, 250);
		base.Name = "IDATMessageBox_YesNo";
		base.ShowIcon = false;
		base.Load += new System.EventHandler(IDATMessageBox_YesNo_Load);
		base.Controls.SetChildIndex(this.layOut, 0);
		((System.ComponentModel.ISupportInitialize)this.layOut).EndInit();
		this.layOut.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.imgMsg.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItemMsg).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.simpleLabelItem_TEXT).EndInit();
		base.ResumeLayout(false);
	}

	public IDATMessageBox_YesNo()
	{
		InitializeComponent();
		base.DialogResult = DialogResult.No;
		base.AutoHide = false;
		Text = "";
		lblMsg.Text = "";
		simpleLabelItem_TEXT.Text = "";
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

	public void Show(string msg, string caption, string remark)
	{
		MessageText = msg;
		CaptionText = caption;
		RemarkText = remark;
		ShowDialog();
	}

	private void btnYes_Click(object sender, EventArgs e)
	{
		Yes();
	}

	private void btnNo_Click(object sender, EventArgs e)
	{
		NO();
	}

	public override void Yes()
	{
		base.Yes();
		Close();
	}

	public override void NO()
	{
		base.NO();
		Close();
	}

	private void IDATMessageBox_YesNo_Load(object sender, EventArgs e)
	{
		base.Size = new Size(620, 320);
	}
}
