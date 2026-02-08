using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

namespace IDAT.UI.MessageBox;

internal class BaseMessageBox : XtraForm
{
	private IContainer components = null;

	private RibbonControl ribbonControl1;

	private ProgressBarControl progressBarControl_Close;

	public Timer msgBoxTmr;

	private bool _AutoHide = false;

	private int _ShowTime = 5;

	public bool AutoHide
	{
		get
		{
			return _AutoHide;
		}
		set
		{
			_AutoHide = value;
			if (!value)
			{
				progressBarControl_Close.Visible = false;
			}
			else
			{
				progressBarControl_Close.Visible = true;
			}
		}
	}

	public int ShowTime
	{
		get
		{
			return _ShowTime;
		}
		set
		{
			progressBarControl_Close.Properties.Maximum = value;
			progressBarControl_Close.Text = "0";
			if (_ShowTime > 0)
			{
				AutoHide = true;
			}
			else
			{
				AutoHide = false;
			}
			_ShowTime = value;
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
		this.msgBoxTmr = new System.Windows.Forms.Timer(this.components);
		this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
		this.progressBarControl_Close = new DevExpress.XtraEditors.ProgressBarControl();
		((System.ComponentModel.ISupportInitialize)this.ribbonControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.progressBarControl_Close.Properties).BeginInit();
		base.SuspendLayout();
		this.msgBoxTmr.Interval = 1000;
		this.ribbonControl1.ApplicationButtonText = null;
		this.ribbonControl1.ExpandCollapseItem.Id = 0;
		this.ribbonControl1.ExpandCollapseItem.Name = "";
		this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[1] { this.ribbonControl1.ExpandCollapseItem });
		this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
		this.ribbonControl1.MaxItemId = 8;
		this.ribbonControl1.Name = "ribbonControl1";
		this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
		this.ribbonControl1.ShowToolbarCustomizeItem = false;
		this.ribbonControl1.Size = new System.Drawing.Size(612, 0);
		this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
		this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
		this.progressBarControl_Close.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.progressBarControl_Close.EditValue = "10";
		this.progressBarControl_Close.Location = new System.Drawing.Point(0, 296);
		this.progressBarControl_Close.Name = "progressBarControl_Close";
		this.progressBarControl_Close.Properties.EndColor = System.Drawing.SystemColors.GradientActiveCaption;
		this.progressBarControl_Close.Size = new System.Drawing.Size(612, 20);
		this.progressBarControl_Close.TabIndex = 1;
		this.progressBarControl_Close.Visible = false;
		base.Appearance.Font = new System.Drawing.Font("Tahoma", 8f);
		base.Appearance.Options.UseFont = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(612, 316);
		base.Controls.Add(this.progressBarControl_Close);
		base.Controls.Add(this.ribbonControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "BaseMessageBox";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "BaseMessageBox";
		base.ControlAdded += new System.Windows.Forms.ControlEventHandler(BaseMessageBox_ControlAdded);
		((System.ComponentModel.ISupportInitialize)this.ribbonControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.progressBarControl_Close.Properties).EndInit();
		base.ResumeLayout(false);
	}

	public BaseMessageBox()
	{
		SkinManager.EnableFormSkins();
		InitializeComponent();
		base.AutoScaleMode = AutoScaleMode.Dpi;
		base.Load += BaseMessageBox_Load;
	}

	private void BaseMessageBox_Load(object sender, EventArgs e)
	{
		if (AutoHide)
		{
			msgBoxTmr.Tick += msgBoxTmr_Tick;
			msgBoxTmr.Start();
		}
	}

	private void msgBoxTmr_Tick(object sender, EventArgs e)
	{
		int num = int.Parse(progressBarControl_Close.Text) + 1;
		progressBarControl_Close.Text = num.ToString();
		if (num.ToString() == ShowTime.ToString())
		{
			Close();
		}
	}

	public virtual void OK()
	{
		base.DialogResult = DialogResult.OK;
	}

	public virtual void Yes()
	{
		base.DialogResult = DialogResult.Yes;
	}

	public virtual void NO()
	{
		base.DialogResult = DialogResult.No;
	}

	public virtual void Cancel()
	{
		base.DialogResult = DialogResult.Cancel;
	}

	public virtual void Retry()
	{
		base.DialogResult = DialogResult.Retry;
	}

	private void BaseMessageBox_ControlAdded(object sender, ControlEventArgs e)
	{
		SetLayControlsInit(e.Control);
	}

	public static void SetLayControlsInit(Control controls)
	{
		foreach (Control control in controls.Controls)
		{
			if (control.Controls.Count > 0)
			{
				SetLayControlsInit(control);
			}
			else if (controls is LayoutControl)
			{
				LayoutControl layoutControl = controls as LayoutControl;
				layoutControl.OptionsView.DrawItemBorders = false;
				layoutControl.OptionsView.HighlightFocusedItem = true;
				layoutControl.OptionsFocus.AllowFocusReadonlyEditors = true;
				layoutControl.OptionsFocus.MoveFocusDirection = MoveFocusDirection.DownThenAcross;
				layoutControl.AllowCustomizationMenu = false;
			}
		}
	}
}
