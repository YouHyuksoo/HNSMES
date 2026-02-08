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

internal class IDATMessageBox_Error : BaseMessageBox
{
	private string m_MessageText = "";

	private string m_CaptionText = "";

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private PictureEdit pictureEdit1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItemMsg;

	private SimpleButton btnOk;

	private EmptySpaceItem emptySpaceItem1;

	private LayoutControlItem layoutControlItem2;

	private EmptySpaceItem emptySpaceItem4;

	private MemoExEdit memoExEdit;

	private LayoutControlItem layoutControlItemErr;

	private LinkLabel lnkSetup;

	private LayoutControlItem layoutControlItem3;

	private SimpleSeparator simpleSeparator1;

	private SimpleSeparator simpleSeparator2;

	private SimpleLabelItem simpleLabelItem_TEXT;

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

	public IDATMessageBox_Error()
	{
		InitializeComponent();
		layoutControlItemErr.Visibility = LayoutVisibility.Never;
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
		layoutControlItemErr.Visibility = LayoutVisibility.Always;
		MessageText = msg;
		CaptionText = caption;
		memoExEdit.Text = remark;
		ShowDialog();
	}

	private void btnOk_Click(object sender, EventArgs e)
	{
		OK();
	}

	public override void OK()
	{
		base.OK();
		Close();
	}

	private void IDATMessageBox_Error_Load(object sender, EventArgs e)
	{
		base.Size = new Size(620, 320);
	}

	private void lnkSetup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		if (IDATMessageBox.Show("would you send me the report for bug error?", "Send error report", IDAT_MessageType.Question) == DialogResult.Yes)
		{
			Retry();
			Close();
		}
	}

	private void memoExEdit_Click(object sender, EventArgs e)
	{
		msgBoxTmr.Stop();
	}

	private void memoExEdit_CloseUp(object sender, CloseUpEventArgs e)
	{
		if (e.CloseMode != PopupCloseMode.Normal)
		{
			msgBoxTmr.Start();
		}
		else
		{
			msgBoxTmr.Stop();
		}
	}

	private void lnkSetup_Enter(object sender, EventArgs e)
	{
		if (lnkSetup.Focused)
		{
			btnOk.Focus();
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
		this.memoExEdit = new DevExpress.XtraEditors.MemoExEdit();
		this.btnOk = new DevExpress.XtraEditors.SimpleButton();
		this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
		this.lnkSetup = new System.Windows.Forms.LinkLabel();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItemErr = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItemMsg = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
		this.simpleSeparator2 = new DevExpress.XtraLayout.SimpleSeparator();
		this.simpleLabelItem_TEXT = new DevExpress.XtraLayout.SimpleLabelItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.memoExEdit.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItemErr).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItemMsg).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.simpleLabelItem_TEXT).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.AllowCustomizationMenu = false;
		this.layoutControl1.Controls.Add(this.memoExEdit);
		this.layoutControl1.Controls.Add(this.btnOk);
		this.layoutControl1.Controls.Add(this.pictureEdit1);
		this.layoutControl1.Controls.Add(this.lnkSetup);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(842, 129, 250, 350);
		this.layoutControl1.OptionsFocus.MoveFocusDirection = DevExpress.XtraLayout.MoveFocusDirection.DownThenAcross;
		this.layoutControl1.OptionsView.HighlightFocusedItem = true;
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(540, 247);
		this.layoutControl1.TabIndex = 1;
		this.layoutControl1.Text = "layoutControl1";
		this.memoExEdit.EditValue = "";
		this.memoExEdit.Location = new System.Drawing.Point(158, 225);
		this.memoExEdit.Name = "memoExEdit";
		this.memoExEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.memoExEdit.Properties.PopupFormSize = new System.Drawing.Size(377, 150);
		this.memoExEdit.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.memoExEdit.Properties.ShowIcon = false;
		this.memoExEdit.Size = new System.Drawing.Size(380, 20);
		this.memoExEdit.StyleController = this.layoutControl1;
		this.memoExEdit.TabIndex = 6;
		this.memoExEdit.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(memoExEdit_CloseUp);
		this.memoExEdit.Click += new System.EventHandler(memoExEdit_Click);
		this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnOk.Location = new System.Drawing.Point(462, 144);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(76, 36);
		this.btnOk.StyleController = this.layoutControl1;
		this.btnOk.TabIndex = 0;
		this.btnOk.Text = "OK";
		this.btnOk.Click += new System.EventHandler(btnOk_Click);
		this.pictureEdit1.EditValue = IDAT.Properties.Resources.msgbox_error;
		this.pictureEdit1.Location = new System.Drawing.Point(2, 18);
		this.pictureEdit1.Name = "pictureEdit1";
		this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
		this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.pictureEdit1.Properties.ShowMenu = false;
		this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
		this.pictureEdit1.Size = new System.Drawing.Size(96, 122);
		this.pictureEdit1.StyleController = this.layoutControl1;
		this.pictureEdit1.TabIndex = 4;
		this.lnkSetup.Location = new System.Drawing.Point(2, 154);
		this.lnkSetup.Name = "lnkSetup";
		this.lnkSetup.Size = new System.Drawing.Size(456, 20);
		this.lnkSetup.TabIndex = 1;
		this.lnkSetup.TabStop = true;
		this.lnkSetup.Text = "Send Error Report";
		this.lnkSetup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(lnkSetup_LinkClicked);
		this.lnkSetup.Enter += new System.EventHandler(lnkSetup_Enter);
		this.layoutControlGroup1.CustomizationFormText = "Root";
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[9] { this.emptySpaceItem1, this.layoutControlItem2, this.emptySpaceItem4, this.layoutControlItemErr, this.layoutControlItemMsg, this.layoutControlItem3, this.simpleSeparator1, this.simpleSeparator2, this.simpleLabelItem_TEXT });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "Root";
		this.layoutControlGroup1.Size = new System.Drawing.Size(540, 247);
		this.layoutControlGroup1.Text = "Root";
		this.layoutControlGroup1.TextVisible = false;
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(540, 14);
		this.emptySpaceItem1.Text = "emptySpaceItem1";
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.Control = this.btnOk;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(460, 142);
		this.layoutControlItem2.MaxSize = new System.Drawing.Size(80, 40);
		this.layoutControlItem2.MinSize = new System.Drawing.Size(80, 40);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(80, 40);
		this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem2.Text = "layoutControlItem2";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextToControlDistance = 0;
		this.layoutControlItem2.TextVisible = false;
		this.emptySpaceItem4.AllowHotTrack = false;
		this.emptySpaceItem4.CustomizationFormText = "emptySpaceItem4";
		this.emptySpaceItem4.Location = new System.Drawing.Point(0, 184);
		this.emptySpaceItem4.MinSize = new System.Drawing.Size(104, 24);
		this.emptySpaceItem4.Name = "emptySpaceItem4";
		this.emptySpaceItem4.Size = new System.Drawing.Size(540, 37);
		this.emptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.emptySpaceItem4.Text = "emptySpaceItem4";
		this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItemErr.Control = this.memoExEdit;
		this.layoutControlItemErr.CustomizationFormText = "Detail : ";
		this.layoutControlItemErr.Location = new System.Drawing.Point(0, 221);
		this.layoutControlItemErr.Name = "layoutControlItemErr";
		this.layoutControlItemErr.Size = new System.Drawing.Size(540, 26);
		this.layoutControlItemErr.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 2, 0);
		this.layoutControlItemErr.Text = "Detail : ";
		this.layoutControlItemErr.TextSize = new System.Drawing.Size(152, 14);
		this.layoutControlItemMsg.AppearanceItemCaption.Options.UseTextOptions = true;
		this.layoutControlItemMsg.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.layoutControlItemMsg.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
		this.layoutControlItemMsg.AppearanceItemCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
		this.layoutControlItemMsg.Control = this.pictureEdit1;
		this.layoutControlItemMsg.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItemMsg.Location = new System.Drawing.Point(0, 16);
		this.layoutControlItemMsg.MaxSize = new System.Drawing.Size(100, 0);
		this.layoutControlItemMsg.MinSize = new System.Drawing.Size(100, 60);
		this.layoutControlItemMsg.Name = "layoutControlItemMsg";
		this.layoutControlItemMsg.Size = new System.Drawing.Size(100, 126);
		this.layoutControlItemMsg.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItemMsg.Text = "layoutControlItemMsglayoutControlItemMsglayoutControlItemMsglayoutControlItemMsglayoutControlItemMsglayoutControlItemMsg";
		this.layoutControlItemMsg.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
		this.layoutControlItemMsg.TextLocation = DevExpress.Utils.Locations.Right;
		this.layoutControlItemMsg.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItemMsg.TextToControlDistance = 0;
		this.layoutControlItemMsg.TextVisible = false;
		this.layoutControlItem3.Control = this.lnkSetup;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 142);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(460, 40);
		this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 10, 0);
		this.layoutControlItem3.Text = "layoutControlItem3";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextToControlDistance = 0;
		this.layoutControlItem3.TextVisible = false;
		this.simpleSeparator1.AllowHotTrack = false;
		this.simpleSeparator1.CustomizationFormText = "simpleSeparator1";
		this.simpleSeparator1.Location = new System.Drawing.Point(0, 182);
		this.simpleSeparator1.Name = "simpleSeparator1";
		this.simpleSeparator1.Size = new System.Drawing.Size(540, 2);
		this.simpleSeparator1.Text = "simpleSeparator1";
		this.simpleSeparator2.AllowHotTrack = false;
		this.simpleSeparator2.CustomizationFormText = "simpleSeparator2";
		this.simpleSeparator2.Location = new System.Drawing.Point(0, 14);
		this.simpleSeparator2.Name = "simpleSeparator2";
		this.simpleSeparator2.Size = new System.Drawing.Size(540, 2);
		this.simpleSeparator2.Text = "simpleSeparator2";
		this.simpleLabelItem_TEXT.AllowHotTrack = false;
		this.simpleLabelItem_TEXT.AppearanceItemCaption.Options.UseTextOptions = true;
		this.simpleLabelItem_TEXT.AppearanceItemCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
		this.simpleLabelItem_TEXT.CustomizationFormText = "LabelsimpleLabelItem_TEXT";
		this.simpleLabelItem_TEXT.Location = new System.Drawing.Point(100, 16);
		this.simpleLabelItem_TEXT.MinSize = new System.Drawing.Size(126, 18);
		this.simpleLabelItem_TEXT.Name = "simpleLabelItem_TEXT";
		this.simpleLabelItem_TEXT.Size = new System.Drawing.Size(440, 126);
		this.simpleLabelItem_TEXT.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.simpleLabelItem_TEXT.Text = "LabelsimpleLabelItem_TEXT";
		this.simpleLabelItem_TEXT.TextSize = new System.Drawing.Size(152, 14);
		base.Appearance.Font = new System.Drawing.Font("Tahoma", 8f);
		base.Appearance.Options.UseFont = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(540, 267);
		base.Controls.Add(this.layoutControl1);
		this.MinimumSize = new System.Drawing.Size(400, 220);
		base.Name = "IDATMessageBox_Error";
		base.ShowIcon = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "IDATMessageBox_Error";
		base.Load += new System.EventHandler(IDATMessageBox_Error_Load);
		base.Controls.SetChildIndex(this.layoutControl1, 0);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.memoExEdit.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItemErr).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItemMsg).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.simpleLabelItem_TEXT).EndInit();
		base.ResumeLayout(false);
	}
}
