using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using IDAT.Properties;

namespace IDAT.UI.MessageBox;

internal class IDATMessageBox_Error_proc : BaseMessageBox
{
	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private SimpleButton btnOk;

	private LayoutControlItem layoutControlItem2;

	private EmptySpaceItem emptySpaceItem4;

	private MemoExEdit memoExEdit;

	private LayoutControlItem layoutControlItemErr;

	private LinkLabel lnkSetup;

	private LayoutControlItem lcReport;

	private SimpleSeparator simpleSeparator1;

	private SimpleSeparator simpleSeparator2;

	private TextEdit txtProcName;

	private ListBoxControl lbcValues;

	private ListBoxControl lbcParameters;

	private SplitterItem splitterItem1;

	private LayoutControlGroup layoutControlGroup2;

	private LayoutControlItem layoutControlItem7;

	private LayoutControlGroup layoutControlGroup3;

	private LayoutControlItem layoutControlItem6;

	private EmptySpaceItem emptySpaceItem2;

	private LayoutControlItem layoutControlItem1;

	private PictureEdit pictureEdit1;

	private LayoutControlItem layoutControlItem4;

	private string m_CaptionText = "";

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
		this.txtProcName = new DevExpress.XtraEditors.TextEdit();
		this.lbcValues = new DevExpress.XtraEditors.ListBoxControl();
		this.lbcParameters = new DevExpress.XtraEditors.ListBoxControl();
		this.memoExEdit = new DevExpress.XtraEditors.MemoExEdit();
		this.btnOk = new DevExpress.XtraEditors.SimpleButton();
		this.lnkSetup = new System.Windows.Forms.LinkLabel();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItemErr = new DevExpress.XtraLayout.LayoutControlItem();
		this.lcReport = new DevExpress.XtraLayout.LayoutControlItem();
		this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
		this.simpleSeparator2 = new DevExpress.XtraLayout.SimpleSeparator();
		this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
		this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtProcName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.lbcValues).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.lbcParameters).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.memoExEdit.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItemErr).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.lcReport).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.splitterItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.AllowCustomizationMenu = false;
		this.layoutControl1.Controls.Add(this.pictureEdit1);
		this.layoutControl1.Controls.Add(this.txtProcName);
		this.layoutControl1.Controls.Add(this.lbcValues);
		this.layoutControl1.Controls.Add(this.lbcParameters);
		this.layoutControl1.Controls.Add(this.memoExEdit);
		this.layoutControl1.Controls.Add(this.btnOk);
		this.layoutControl1.Controls.Add(this.lnkSetup);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(878, 172, 250, 350);
		this.layoutControl1.OptionsFocus.MoveFocusDirection = DevExpress.XtraLayout.MoveFocusDirection.DownThenAcross;
		this.layoutControl1.OptionsView.HighlightFocusedItem = true;
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(494, 252);
		this.layoutControl1.TabIndex = 1;
		this.layoutControl1.Text = "layoutControl1";
		this.pictureEdit1.EditValue = IDAT.Properties.Resources.msgbox_error;
		this.pictureEdit1.Location = new System.Drawing.Point(2, 2);
		this.pictureEdit1.Name = "pictureEdit1";
		this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
		this.pictureEdit1.Size = new System.Drawing.Size(96, 180);
		this.pictureEdit1.StyleController = this.layoutControl1;
		this.pictureEdit1.TabIndex = 17;
		this.txtProcName.Location = new System.Drawing.Point(161, 2);
		this.txtProcName.Name = "txtProcName";
		this.txtProcName.Size = new System.Drawing.Size(155, 20);
		this.txtProcName.StyleController = this.layoutControl1;
		this.txtProcName.TabIndex = 16;
		this.lbcValues.Location = new System.Drawing.Point(316, 60);
		this.lbcValues.Name = "lbcValues";
		this.lbcValues.Size = new System.Drawing.Size(164, 110);
		this.lbcValues.StyleController = this.layoutControl1;
		this.lbcValues.TabIndex = 15;
		this.lbcValues.SelectedIndexChanged += new System.EventHandler(lbc_SelectedIndexChanged);
		this.lbcParameters.Location = new System.Drawing.Point(114, 60);
		this.lbcParameters.Name = "lbcParameters";
		this.lbcParameters.Size = new System.Drawing.Size(169, 110);
		this.lbcParameters.StyleController = this.layoutControl1;
		this.lbcParameters.TabIndex = 14;
		this.lbcParameters.SelectedIndexChanged += new System.EventHandler(lbc_SelectedIndexChanged);
		this.memoExEdit.EditValue = "";
		this.memoExEdit.Location = new System.Drawing.Point(61, 230);
		this.memoExEdit.Name = "memoExEdit";
		this.memoExEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.memoExEdit.Properties.PopupFormSize = new System.Drawing.Size(377, 150);
		this.memoExEdit.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.memoExEdit.Properties.ShowIcon = false;
		this.memoExEdit.Size = new System.Drawing.Size(431, 20);
		this.memoExEdit.StyleController = this.layoutControl1;
		this.memoExEdit.TabIndex = 6;
		this.memoExEdit.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(memoExEdit_CloseUp);
		this.memoExEdit.Click += new System.EventHandler(memoExEdit_Click);
		this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnOk.Location = new System.Drawing.Point(416, 188);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(76, 36);
		this.btnOk.StyleController = this.layoutControl1;
		this.btnOk.TabIndex = 0;
		this.btnOk.Text = "OK";
		this.btnOk.Click += new System.EventHandler(btnOk_Click);
		this.lnkSetup.Location = new System.Drawing.Point(2, 198);
		this.lnkSetup.Name = "lnkSetup";
		this.lnkSetup.Size = new System.Drawing.Size(96, 20);
		this.lnkSetup.TabIndex = 1;
		this.lnkSetup.TabStop = true;
		this.lnkSetup.Text = "Send Error Report";
		this.lnkSetup.Visible = false;
		this.lnkSetup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(lnkSetup_LinkClicked);
		this.lnkSetup.Enter += new System.EventHandler(lnkSetup_Enter);
		this.layoutControlGroup1.CustomizationFormText = "Root";
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[12]
		{
			this.layoutControlItem2, this.emptySpaceItem4, this.layoutControlItemErr, this.lcReport, this.simpleSeparator1, this.simpleSeparator2, this.splitterItem1, this.layoutControlGroup2, this.layoutControlGroup3, this.emptySpaceItem2,
			this.layoutControlItem1, this.layoutControlItem4
		});
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "Root";
		this.layoutControlGroup1.Size = new System.Drawing.Size(494, 252);
		this.layoutControlGroup1.Text = "Root";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem2.Control = this.btnOk;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(414, 186);
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
		this.emptySpaceItem4.Location = new System.Drawing.Point(100, 186);
		this.emptySpaceItem4.MinSize = new System.Drawing.Size(104, 24);
		this.emptySpaceItem4.Name = "emptySpaceItem4";
		this.emptySpaceItem4.Size = new System.Drawing.Size(314, 40);
		this.emptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.emptySpaceItem4.Text = "emptySpaceItem4";
		this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItemErr.Control = this.memoExEdit;
		this.layoutControlItemErr.CustomizationFormText = "Detail : ";
		this.layoutControlItemErr.Location = new System.Drawing.Point(0, 226);
		this.layoutControlItemErr.Name = "layoutControlItemErr";
		this.layoutControlItemErr.Size = new System.Drawing.Size(494, 26);
		this.layoutControlItemErr.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 2, 0);
		this.layoutControlItemErr.Text = "Detail : ";
		this.layoutControlItemErr.TextSize = new System.Drawing.Size(55, 14);
		this.lcReport.Control = this.lnkSetup;
		this.lcReport.CustomizationFormText = "layoutControlItem3";
		this.lcReport.Location = new System.Drawing.Point(0, 186);
		this.lcReport.MaxSize = new System.Drawing.Size(100, 34);
		this.lcReport.MinSize = new System.Drawing.Size(100, 34);
		this.lcReport.Name = "lcReport";
		this.lcReport.Size = new System.Drawing.Size(100, 40);
		this.lcReport.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.lcReport.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 10, 0);
		this.lcReport.Text = "lcReport";
		this.lcReport.TextSize = new System.Drawing.Size(0, 0);
		this.lcReport.TextToControlDistance = 0;
		this.lcReport.TextVisible = false;
		this.simpleSeparator1.AllowHotTrack = false;
		this.simpleSeparator1.CustomizationFormText = "simpleSeparator1";
		this.simpleSeparator1.Location = new System.Drawing.Point(0, 184);
		this.simpleSeparator1.Name = "simpleSeparator1";
		this.simpleSeparator1.Size = new System.Drawing.Size(494, 2);
		this.simpleSeparator1.Text = "simpleSeparator1";
		this.simpleSeparator2.AllowHotTrack = false;
		this.simpleSeparator2.CustomizationFormText = "simpleSeparator2";
		this.simpleSeparator2.Location = new System.Drawing.Point(100, 24);
		this.simpleSeparator2.Name = "simpleSeparator2";
		this.simpleSeparator2.Size = new System.Drawing.Size(394, 2);
		this.simpleSeparator2.Text = "simpleSeparator2";
		this.splitterItem1.AllowHotTrack = true;
		this.splitterItem1.CustomizationFormText = "splitterItem1";
		this.splitterItem1.Location = new System.Drawing.Point(297, 26);
		this.splitterItem1.Name = "splitterItem1";
		this.splitterItem1.Size = new System.Drawing.Size(5, 158);
		this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
		this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[1] { this.layoutControlItem7 });
		this.layoutControlGroup2.Location = new System.Drawing.Point(100, 26);
		this.layoutControlGroup2.Name = "layoutControlGroup2";
		this.layoutControlGroup2.Size = new System.Drawing.Size(197, 158);
		this.layoutControlGroup2.Text = "parameters";
		this.layoutControlItem7.Control = this.lbcParameters;
		this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
		this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(173, 114);
		this.layoutControlItem7.Text = "layoutControlItem7";
		this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem7.TextToControlDistance = 0;
		this.layoutControlItem7.TextVisible = false;
		this.layoutControlGroup3.CustomizationFormText = "layoutControlGroup3";
		this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[1] { this.layoutControlItem6 });
		this.layoutControlGroup3.Location = new System.Drawing.Point(302, 26);
		this.layoutControlGroup3.Name = "layoutControlGroup3";
		this.layoutControlGroup3.Size = new System.Drawing.Size(192, 158);
		this.layoutControlGroup3.Text = "Values";
		this.layoutControlItem6.Control = this.lbcValues;
		this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
		this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(168, 114);
		this.layoutControlItem6.Text = "layoutControlItem6";
		this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem6.TextToControlDistance = 0;
		this.layoutControlItem6.TextVisible = false;
		this.emptySpaceItem2.AllowHotTrack = false;
		this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
		this.emptySpaceItem2.Location = new System.Drawing.Point(318, 0);
		this.emptySpaceItem2.Name = "emptySpaceItem2";
		this.emptySpaceItem2.Size = new System.Drawing.Size(176, 24);
		this.emptySpaceItem2.Text = "emptySpaceItem2";
		this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.Control = this.txtProcName;
		this.layoutControlItem1.CustomizationFormText = "ProcName";
		this.layoutControlItem1.Location = new System.Drawing.Point(100, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(218, 24);
		this.layoutControlItem1.Text = "ProcName";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(55, 14);
		this.layoutControlItem4.Control = this.pictureEdit1;
		this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem4.MaxSize = new System.Drawing.Size(100, 0);
		this.layoutControlItem4.MinSize = new System.Drawing.Size(100, 60);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(100, 184);
		this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem4.Text = "layoutControlItem4";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextToControlDistance = 0;
		this.layoutControlItem4.TextVisible = false;
		base.Appearance.Font = new System.Drawing.Font("Tahoma", 8f);
		base.Appearance.Options.UseFont = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(494, 272);
		base.Controls.Add(this.layoutControl1);
		base.MaximizeBox = true;
		this.MinimumSize = new System.Drawing.Size(500, 300);
		base.Name = "IDATMessageBox_Error_proc";
		base.ShowIcon = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "IDATMessageBox_Error_proc";
		base.Load += new System.EventHandler(IDATMessageBox_Error_Load);
		base.Controls.SetChildIndex(this.layoutControl1, 0);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtProcName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.lbcValues).EndInit();
		((System.ComponentModel.ISupportInitialize)this.lbcParameters).EndInit();
		((System.ComponentModel.ISupportInitialize)this.memoExEdit.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItemErr).EndInit();
		((System.ComponentModel.ISupportInitialize)this.lcReport).EndInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.simpleSeparator2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.splitterItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		base.ResumeLayout(false);
	}

	public IDATMessageBox_Error_proc()
	{
		InitializeComponent();
		txtProcName.Properties.ReadOnly = true;
		memoExEdit.Properties.ReadOnly = true;
		layoutControlItemErr.Visibility = LayoutVisibility.Never;
		lcReport.Visibility = LayoutVisibility.Never;
	}

	public void Show(string proc_name, int procSeq, string[] parameter, object[] values, string remark = null, string caption = null, bool report = false)
	{
		txtProcName.Text = proc_name;
		txtProcName.Text += $" ({procSeq})";
		if (parameter != null)
		{
			foreach (string item in parameter)
			{
				lbcParameters.Items.Add(item);
			}
		}
		if (values != null)
		{
			for (int i = 0; i < values.Length; i++)
			{
				string arg = (string)values[i];
				lbcValues.Items.Add($"{arg}          type:{values.GetType().ToString().Substring(7)}");
			}
		}
		if (remark != null)
		{
			layoutControlItemErr.Visibility = LayoutVisibility.Always;
			memoExEdit.Text = remark;
		}
		if (caption != null)
		{
			CaptionText = caption;
		}
		if (report)
		{
			lcReport.Visibility = LayoutVisibility.Always;
		}
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

	private void lbc_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (lbcParameters.SelectedIndices.Count != 0 || lbcValues.SelectedIndices.Count != 0)
		{
			ListBoxControl listBoxControl = (ListBoxControl)sender;
			int selectedIndex = listBoxControl.SelectedIndex;
			lbcParameters.SelectedIndex = selectedIndex;
			lbcValues.SelectedIndex = selectedIndex;
		}
	}
}
