using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

namespace IDAT.UI.MessageBox;

internal class IDATMessageBox_MEMOOK : BaseMessageBox
{
	private string m_MessageText = "";

	private string m_CaptionText = "";

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private SimpleButton btnOK;

	private EmptySpaceItem emptySpaceItem3;

	private LayoutControlItem layoutControlItem2;

	private EmptySpaceItem emptySpaceItem2;

	private SimpleSeparator simpleSeparator1;

	private SimpleSeparator simpleSeparator2;

	private MemoEdit memoEdit_txt;

	private LayoutControlItem layoutControlItem1;

	private SimpleButton btnCancel;

	private LayoutControlItem layoutControlItem3;

	public string MessageText
	{
		get
		{
			return m_MessageText;
		}
		set
		{
			m_MessageText = value;
			memoEdit_txt.Text = value;
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

	public IDATMessageBox_MEMOOK()
	{
		InitializeComponent();
		memoEdit_txt.Text = "";
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

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.Cancel();
	}

	public override void OK()
	{
		MessageText = memoEdit_txt.Text;
		base.OK();
		Close();
	}

	private void IDATMessageBox_OK_Load(object sender, EventArgs e)
	{
		base.Size = new Size(620, 320);
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
		this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
		this.memoEdit_txt = new DevExpress.XtraEditors.MemoEdit();
		this.btnOK = new DevExpress.XtraEditors.SimpleButton();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
		this.simpleSeparator2 = new DevExpress.XtraLayout.SimpleSeparator();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.memoEdit_txt.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.AllowCustomizationMenu = false;
		this.layoutControl1.Controls.Add(this.btnCancel);
		this.layoutControl1.Controls.Add(this.memoEdit_txt);
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
		this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnCancel.Location = new System.Drawing.Point(409, 157);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(76, 36);
		this.btnCancel.StyleController = this.layoutControl1;
		this.btnCancel.TabIndex = 6;
		this.btnCancel.Text = "Cancel";
		this.btnCancel.Click += new System.EventHandler(btnCancel_Click);
		this.memoEdit_txt.Location = new System.Drawing.Point(2, 17);
		this.memoEdit_txt.Name = "memoEdit_txt";
		this.memoEdit_txt.Size = new System.Drawing.Size(483, 132);
		this.memoEdit_txt.StyleController = this.layoutControl1;
		this.memoEdit_txt.TabIndex = 6;
		this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnOK.Location = new System.Drawing.Point(329, 157);
		this.btnOK.Name = "btnOK";
		this.btnOK.Size = new System.Drawing.Size(76, 36);
		this.btnOK.StyleController = this.layoutControl1;
		this.btnOK.TabIndex = 5;
		this.btnOK.Text = "OK";
		this.btnOK.Click += new System.EventHandler(btnOK_Click);
		this.layoutControlGroup1.CustomizationFormText = "Root";
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[7] { this.emptySpaceItem3, this.layoutControlItem2, this.emptySpaceItem2, this.simpleSeparator1, this.simpleSeparator2, this.layoutControlItem1, this.layoutControlItem3 });
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
		this.emptySpaceItem3.Size = new System.Drawing.Size(327, 40);
		this.emptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.emptySpaceItem3.Text = "emptySpaceItem3";
		this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.Control = this.btnOK;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(327, 155);
		this.layoutControlItem2.MaxSize = new System.Drawing.Size(80, 40);
		this.layoutControlItem2.MinSize = new System.Drawing.Size(80, 40);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(80, 40);
		this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem2.Text = "layoutControlItem2";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextToControlDistance = 0;
		this.layoutControlItem2.TextVisible = false;
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
		this.simpleSeparator2.Location = new System.Drawing.Point(0, 151);
		this.simpleSeparator2.Name = "simpleSeparator2";
		this.simpleSeparator2.Size = new System.Drawing.Size(487, 2);
		this.simpleSeparator2.Text = "simpleSeparator2";
		this.layoutControlItem1.Control = this.memoEdit_txt;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 15);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(487, 136);
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem3.Control = this.btnCancel;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(407, 155);
		this.layoutControlItem3.MaxSize = new System.Drawing.Size(80, 40);
		this.layoutControlItem3.MinSize = new System.Drawing.Size(80, 40);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(80, 40);
		this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem3.Text = "layoutControlItem3";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextToControlDistance = 0;
		this.layoutControlItem3.TextVisible = false;
		base.Appearance.Font = new System.Drawing.Font("Tahoma", 8f);
		base.Appearance.Options.UseFont = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(487, 215);
		base.Controls.Add(this.layoutControl1);
		this.MinimumSize = new System.Drawing.Size(390, 190);
		base.Name = "IDATMessageBox_MEMOOK";
		base.ShowIcon = false;
		base.Load += new System.EventHandler(IDATMessageBox_OK_Load);
		base.Controls.SetChildIndex(this.layoutControl1, 0);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.memoEdit_txt.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		base.ResumeLayout(false);
	}
}
