using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

namespace IDAT.Devexpress.KEYBOARD;

public class IDAT_VKeyBoard : RibbonForm
{
	private bool m_IsUpper = true;

	private Control m_Con = null;

	private IContainer components = null;

	private RibbonControl ribbon;

	private RibbonStatusBar ribbonStatusBar;

	private LayoutControl layoutControl1;

	private SimpleButton simpleButton10;

	private SimpleButton simpleButton9;

	private SimpleButton simpleButton8;

	private SimpleButton simpleButton7;

	private SimpleButton simpleButton6;

	private SimpleButton simpleButton5;

	private SimpleButton simpleButton4;

	private SimpleButton simpleButton3;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem4;

	private LayoutControlItem layoutControlItem5;

	private LayoutControlItem layoutControlItem6;

	private LayoutControlItem layoutControlItem7;

	private LayoutControlItem layoutControlItem8;

	private LayoutControlItem layoutControlItem9;

	private LayoutControlItem layoutControlItem10;

	private LayoutControlItem layoutControlItem11;

	private LayoutControlItem layoutControlItem12;

	private LayoutControlItem layoutControlItem13;

	private LayoutControlItem layoutControlItem14;

	private LayoutControlItem layoutControlItem15;

	private LayoutControlItem layoutControlItem16;

	private LayoutControlItem layoutControlItem17;

	private LayoutControlItem layoutControlItem18;

	private LayoutControlItem layoutControlItem19;

	private LayoutControlItem layoutControlItem20;

	private SimpleButton simpleButton30;

	private SimpleButton simpleButton29;

	private SimpleButton simpleButton28;

	private SimpleButton simpleButton27;

	private SimpleButton simpleButton26;

	private SimpleButton simpleButton25;

	private SimpleButton simpleButton24;

	private SimpleButton simpleButton23;

	private SimpleButton simpleButton22;

	private SimpleButton simpleButton21;

	private SimpleButton simpleButton20;

	private SimpleButton simpleButton19;

	private SimpleButton simpleButton18;

	private SimpleButton simpleButton17;

	private SimpleButton simpleButton16;

	private SimpleButton simpleButton15;

	private SimpleButton simpleButton14;

	private SimpleButton simpleButton13;

	private SimpleButton simpleButton12;

	private SimpleButton simpleButton11;

	private LayoutControlItem layoutControlItem21;

	private LayoutControlItem layoutControlItem22;

	private LayoutControlItem layoutControlItem23;

	private LayoutControlItem layoutControlItem24;

	private LayoutControlItem layoutControlItem25;

	private LayoutControlItem layoutControlItem26;

	private LayoutControlItem layoutControlItem27;

	private LayoutControlItem layoutControlItem28;

	private LayoutControlItem layoutControlItem29;

	private LayoutControlItem layoutControlItem30;

	private LayoutControlItem layoutControlItem31;

	private LayoutControlItem layoutControlItem32;

	private LayoutControlItem layoutControlItem33;

	private LayoutControlItem layoutControlItem34;

	private LayoutControlItem layoutControlItem35;

	private LayoutControlItem layoutControlItem36;

	private LayoutControlItem layoutControlItem37;

	private LayoutControlItem layoutControlItem38;

	private LayoutControlItem layoutControlItem39;

	private LayoutControlItem layoutControlItem40;

	private SimpleButton simpleButton33;

	private SimpleButton simpleButton32;

	private SimpleButton btnEnter;

	private LayoutControlItem layoutControlItem41;

	private LayoutControlItem layoutControlItem42;

	private LayoutControlItem layoutControlItem43;

	private SimpleButton simpleButton34;

	private LayoutControlItem layoutControlItem44;

	private EmptySpaceItem emptySpaceItem4;

	private SimpleButton simpleButton44;

	private SimpleButton simpleButton43;

	private SimpleButton simpleButton42;

	private SimpleButton simpleButton41;

	private SimpleButton simpleButton40;

	private SimpleButton simpleButton39;

	private SimpleButton simpleButton38;

	private SimpleButton simpleButton37;

	private SimpleButton simpleButton36;

	private SimpleButton simpleButton35;

	private LayoutControlItem layoutControlItem45;

	private LayoutControlItem layoutControlItem46;

	private LayoutControlItem layoutControlItem47;

	private LayoutControlItem layoutControlItem48;

	private LayoutControlItem layoutControlItem49;

	private LayoutControlItem layoutControlItem50;

	private LayoutControlItem layoutControlItem51;

	private LayoutControlItem layoutControlItem52;

	private LayoutControlItem layoutControlItem53;

	private LayoutControlItem layoutControlItem54;

	private TextEdit txtDisplay;

	private LayoutControlItem layoutControlItem55;

	private SimpleButton simpleButton31;

	private LayoutControlItem layoutControlItem56;

	private SimpleButton simpleButton45;

	private LayoutControlItem layoutControlItem57;

	public IDAT_VKeyBoard()
	{
		InitializeComponent();
	}

	public IDAT_VKeyBoard(Control Con)
		: this()
	{
		m_Con = Con;
		txtDisplay.Text = Con.Text.Replace("\r\n", "");
		m_IsUpper = true;
		SetUpperLower(this);
	}

	public IDAT_VKeyBoard(Control Con, bool isPassword)
		: this(Con)
	{
		if (isPassword)
		{
			txtDisplay.Properties.PasswordChar = '*';
		}
	}

	private void IDATVKeyboard_Shown(object sender, EventArgs e)
	{
		base.Size = new Size(670, 300);
		txtDisplay.SelectAll();
	}

	private void VsimpleButton_Click(object sender, EventArgs e)
	{
		if (!(sender is SimpleButton))
		{
			return;
		}
		SimpleButton simpleButton = sender as SimpleButton;
		if (simpleButton.Text.ToLower() == "shift")
		{
			m_IsUpper = !m_IsUpper;
			SetUpperLower(this);
		}
		else if (simpleButton.Text.ToLower() == "enter")
		{
			if (m_Con != null)
			{
				if (m_Con is TextEdit textEdit && txtDisplay.Text.Length > textEdit.Properties.MaxLength && textEdit.Properties.MaxLength > 0)
				{
					txtDisplay.Text = txtDisplay.Text.Substring(0, textEdit.Properties.MaxLength);
				}
				m_Con.Text = txtDisplay.Text + "\r\n";
				Close();
			}
		}
		else if (simpleButton.Text.ToLower() == "backspace")
		{
			if (txtDisplay.Text.Length <= 0)
			{
				return;
			}
			if (txtDisplay.Text.Length == txtDisplay.SelectionStart)
			{
				txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1);
				txtDisplay.Select(txtDisplay.Text.Length, 0);
				return;
			}
			int selectionStart = txtDisplay.SelectionStart;
			if (txtDisplay.SelectionLength > 0)
			{
				txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.SelectionStart, txtDisplay.SelectionLength);
				txtDisplay.Select(selectionStart, 0);
			}
			else if (selectionStart > 0)
			{
				txtDisplay.Text = txtDisplay.Text.Remove(selectionStart - 1, 1);
				txtDisplay.Select(selectionStart - 1, 0);
			}
		}
		else if (simpleButton.Text.ToLower() == "space")
		{
			int selectionStart = txtDisplay.SelectionStart;
			if (txtDisplay.SelectionLength > 0)
			{
				txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.SelectionStart, txtDisplay.SelectionLength);
			}
			txtDisplay.Text = txtDisplay.Text.Insert(selectionStart, " ");
			txtDisplay.Select(selectionStart + 1, 0);
		}
		else if (simpleButton.Text.ToLower() == "delete")
		{
			int selectionStart = txtDisplay.SelectionStart;
			if (txtDisplay.SelectionLength > 0)
			{
				txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.SelectionStart, txtDisplay.SelectionLength);
				txtDisplay.Select(selectionStart, 0);
			}
			else if (txtDisplay.Text.Length != txtDisplay.SelectionStart)
			{
				txtDisplay.Text = txtDisplay.Text.Remove(selectionStart, 1);
				txtDisplay.Select(selectionStart, 0);
			}
			else
			{
				txtDisplay.Select(txtDisplay.Text.Length, 0);
			}
		}
		else if (simpleButton.Text.ToLower() == "clear")
		{
			txtDisplay.Text = "";
		}
		else if (simpleButton.Text.Length == 1)
		{
			int selectionStart2 = txtDisplay.SelectionStart;
			int selectionStart3 = txtDisplay.SelectionStart;
			if (txtDisplay.SelectionLength > 0)
			{
				txtDisplay.Text = txtDisplay.Text.Remove(selectionStart3, txtDisplay.SelectionLength);
			}
			if (txtDisplay.Text.Length == selectionStart3)
			{
				txtDisplay.Text += simpleButton.Text;
				txtDisplay.Select(txtDisplay.Text.Length, 0);
			}
			else
			{
				txtDisplay.Text = txtDisplay.Text.Insert(selectionStart3, simpleButton.Text);
				txtDisplay.Select(selectionStart2 + 1, 0);
			}
		}
	}

	private void SetUpperLower(Control con)
	{
		foreach (Control control in con.Controls)
		{
			if (control.Controls.Count > 0)
			{
				SetUpperLower(control);
			}
			else
			{
				if (!(control is SimpleButton) || control.Text.Length != 1)
				{
					continue;
				}
				if (m_IsUpper)
				{
					if (control.Text == ":")
					{
						control.Text = ";";
					}
					if (control.Text == "<")
					{
						control.Text = ",";
					}
					if (control.Text == ">")
					{
						control.Text = ".";
					}
					if (control.Text == "?")
					{
						control.Text = "/";
					}
					control.Text = control.Text.ToLower();
				}
				else
				{
					if (control.Text == ";")
					{
						control.Text = ":";
					}
					if (control.Text == ",")
					{
						control.Text = "<";
					}
					if (control.Text == ".")
					{
						control.Text = ">";
					}
					if (control.Text == "/")
					{
						control.Text = "?";
					}
					control.Text = control.Text.ToUpper();
				}
			}
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
		this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
		this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.simpleButton45 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton31 = new DevExpress.XtraEditors.SimpleButton();
		this.txtDisplay = new DevExpress.XtraEditors.TextEdit();
		this.simpleButton44 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton43 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton42 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton41 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton40 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton39 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton38 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton37 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton36 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton35 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton34 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton33 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton32 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton30 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton29 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton28 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton27 = new DevExpress.XtraEditors.SimpleButton();
		this.btnEnter = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton26 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton25 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton24 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton23 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton22 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton21 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton20 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton19 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton18 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton17 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton16 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton15 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton14 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton13 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton12 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton11 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton10 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton9 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton8 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton7 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton6 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem30 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem31 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem32 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem33 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem34 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem35 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem36 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem37 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem38 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem39 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem40 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem43 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem45 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem46 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem47 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem48 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem49 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem50 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem51 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem52 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem53 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem54 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem55 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem56 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem44 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem57 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem41 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem42 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.ribbon).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtDisplay.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem21).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem22).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem23).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem24).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem25).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem26).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem27).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem28).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem29).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem30).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem31).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem32).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem33).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem34).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem35).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem36).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem37).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem38).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem39).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem40).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem43).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem45).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem46).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem47).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem48).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem49).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem50).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem51).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem52).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem53).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem54).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem55).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem56).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem44).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem57).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem41).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem42).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem12).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem14).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem15).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem16).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem17).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem18).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem19).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem20).BeginInit();
		base.SuspendLayout();
		this.ribbon.ApplicationButtonText = null;
		this.ribbon.ExpandCollapseItem.Id = 0;
		this.ribbon.ExpandCollapseItem.Name = "";
		this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[1] { this.ribbon.ExpandCollapseItem });
		this.ribbon.Location = new System.Drawing.Point(0, 0);
		this.ribbon.MaxItemId = 1;
		this.ribbon.Name = "ribbon";
		this.ribbon.ShowToolbarCustomizeItem = false;
		this.ribbon.Size = new System.Drawing.Size(677, 50);
		this.ribbon.StatusBar = this.ribbonStatusBar;
		this.ribbon.Toolbar.ShowCustomizeItem = false;
		this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
		this.ribbonStatusBar.Location = new System.Drawing.Point(0, 266);
		this.ribbonStatusBar.Name = "ribbonStatusBar";
		this.ribbonStatusBar.Ribbon = this.ribbon;
		this.ribbonStatusBar.Size = new System.Drawing.Size(677, 31);
		this.layoutControl1.Controls.Add(this.simpleButton45);
		this.layoutControl1.Controls.Add(this.simpleButton31);
		this.layoutControl1.Controls.Add(this.txtDisplay);
		this.layoutControl1.Controls.Add(this.simpleButton44);
		this.layoutControl1.Controls.Add(this.simpleButton43);
		this.layoutControl1.Controls.Add(this.simpleButton42);
		this.layoutControl1.Controls.Add(this.simpleButton41);
		this.layoutControl1.Controls.Add(this.simpleButton40);
		this.layoutControl1.Controls.Add(this.simpleButton39);
		this.layoutControl1.Controls.Add(this.simpleButton38);
		this.layoutControl1.Controls.Add(this.simpleButton37);
		this.layoutControl1.Controls.Add(this.simpleButton36);
		this.layoutControl1.Controls.Add(this.simpleButton35);
		this.layoutControl1.Controls.Add(this.simpleButton34);
		this.layoutControl1.Controls.Add(this.simpleButton33);
		this.layoutControl1.Controls.Add(this.simpleButton32);
		this.layoutControl1.Controls.Add(this.simpleButton30);
		this.layoutControl1.Controls.Add(this.simpleButton29);
		this.layoutControl1.Controls.Add(this.simpleButton28);
		this.layoutControl1.Controls.Add(this.simpleButton27);
		this.layoutControl1.Controls.Add(this.btnEnter);
		this.layoutControl1.Controls.Add(this.simpleButton26);
		this.layoutControl1.Controls.Add(this.simpleButton25);
		this.layoutControl1.Controls.Add(this.simpleButton24);
		this.layoutControl1.Controls.Add(this.simpleButton23);
		this.layoutControl1.Controls.Add(this.simpleButton22);
		this.layoutControl1.Controls.Add(this.simpleButton21);
		this.layoutControl1.Controls.Add(this.simpleButton20);
		this.layoutControl1.Controls.Add(this.simpleButton19);
		this.layoutControl1.Controls.Add(this.simpleButton18);
		this.layoutControl1.Controls.Add(this.simpleButton17);
		this.layoutControl1.Controls.Add(this.simpleButton16);
		this.layoutControl1.Controls.Add(this.simpleButton15);
		this.layoutControl1.Controls.Add(this.simpleButton14);
		this.layoutControl1.Controls.Add(this.simpleButton13);
		this.layoutControl1.Controls.Add(this.simpleButton12);
		this.layoutControl1.Controls.Add(this.simpleButton11);
		this.layoutControl1.Controls.Add(this.simpleButton10);
		this.layoutControl1.Controls.Add(this.simpleButton9);
		this.layoutControl1.Controls.Add(this.simpleButton8);
		this.layoutControl1.Controls.Add(this.simpleButton7);
		this.layoutControl1.Controls.Add(this.simpleButton6);
		this.layoutControl1.Controls.Add(this.simpleButton5);
		this.layoutControl1.Controls.Add(this.simpleButton4);
		this.layoutControl1.Controls.Add(this.simpleButton3);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 50);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(677, 216);
		this.layoutControl1.TabIndex = 5;
		this.layoutControl1.Text = "layoutControl1";
		this.simpleButton45.AllowFocus = false;
		this.simpleButton45.Appearance.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold);
		this.simpleButton45.Appearance.Options.UseFont = true;
		this.simpleButton45.Location = new System.Drawing.Point(589, 12);
		this.simpleButton45.Name = "simpleButton45";
		this.simpleButton45.Size = new System.Drawing.Size(76, 31);
		this.simpleButton45.StyleController = this.layoutControl1;
		this.simpleButton45.TabIndex = 50;
		this.simpleButton45.Text = "Clear";
		this.simpleButton45.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton31.AllowFocus = false;
		this.simpleButton31.Appearance.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold);
		this.simpleButton31.Appearance.Options.UseFont = true;
		this.simpleButton31.Location = new System.Drawing.Point(512, 47);
		this.simpleButton31.Name = "simpleButton31";
		this.simpleButton31.Size = new System.Drawing.Size(56, 36);
		this.simpleButton31.StyleController = this.layoutControl1;
		this.simpleButton31.TabIndex = 49;
		this.simpleButton31.Text = "Delete";
		this.simpleButton31.Click += new System.EventHandler(VsimpleButton_Click);
		this.txtDisplay.EditValue = "";
		this.txtDisplay.Location = new System.Drawing.Point(12, 12);
		this.txtDisplay.Name = "txtDisplay";
		this.txtDisplay.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15f, System.Drawing.FontStyle.Bold);
		this.txtDisplay.Properties.Appearance.Options.UseFont = true;
		this.txtDisplay.Size = new System.Drawing.Size(573, 31);
		this.txtDisplay.StyleController = this.layoutControl1;
		this.txtDisplay.TabIndex = 48;
		this.simpleButton44.AllowFocus = false;
		this.simpleButton44.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton44.Appearance.Options.UseFont = true;
		this.simpleButton44.Location = new System.Drawing.Point(462, 47);
		this.simpleButton44.Name = "simpleButton44";
		this.simpleButton44.Size = new System.Drawing.Size(46, 36);
		this.simpleButton44.StyleController = this.layoutControl1;
		this.simpleButton44.TabIndex = 47;
		this.simpleButton44.Text = "0";
		this.simpleButton44.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton43.AllowFocus = false;
		this.simpleButton43.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton43.Appearance.Options.UseFont = true;
		this.simpleButton43.Location = new System.Drawing.Point(412, 47);
		this.simpleButton43.Name = "simpleButton43";
		this.simpleButton43.Size = new System.Drawing.Size(46, 36);
		this.simpleButton43.StyleController = this.layoutControl1;
		this.simpleButton43.TabIndex = 46;
		this.simpleButton43.Text = "9";
		this.simpleButton43.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton42.AllowFocus = false;
		this.simpleButton42.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton42.Appearance.Options.UseFont = true;
		this.simpleButton42.Location = new System.Drawing.Point(362, 47);
		this.simpleButton42.Name = "simpleButton42";
		this.simpleButton42.Size = new System.Drawing.Size(46, 36);
		this.simpleButton42.StyleController = this.layoutControl1;
		this.simpleButton42.TabIndex = 45;
		this.simpleButton42.Text = "8";
		this.simpleButton42.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton41.AllowFocus = false;
		this.simpleButton41.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton41.Appearance.Options.UseFont = true;
		this.simpleButton41.Location = new System.Drawing.Point(312, 47);
		this.simpleButton41.Name = "simpleButton41";
		this.simpleButton41.Size = new System.Drawing.Size(46, 36);
		this.simpleButton41.StyleController = this.layoutControl1;
		this.simpleButton41.TabIndex = 44;
		this.simpleButton41.Text = "7";
		this.simpleButton41.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton40.AllowFocus = false;
		this.simpleButton40.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton40.Appearance.Options.UseFont = true;
		this.simpleButton40.Location = new System.Drawing.Point(262, 47);
		this.simpleButton40.Name = "simpleButton40";
		this.simpleButton40.Size = new System.Drawing.Size(46, 36);
		this.simpleButton40.StyleController = this.layoutControl1;
		this.simpleButton40.TabIndex = 43;
		this.simpleButton40.Text = "6";
		this.simpleButton40.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton39.AllowFocus = false;
		this.simpleButton39.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton39.Appearance.Options.UseFont = true;
		this.simpleButton39.Location = new System.Drawing.Point(212, 47);
		this.simpleButton39.Name = "simpleButton39";
		this.simpleButton39.Size = new System.Drawing.Size(46, 36);
		this.simpleButton39.StyleController = this.layoutControl1;
		this.simpleButton39.TabIndex = 42;
		this.simpleButton39.Text = "5";
		this.simpleButton39.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton38.AllowFocus = false;
		this.simpleButton38.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton38.Appearance.Options.UseFont = true;
		this.simpleButton38.Location = new System.Drawing.Point(162, 47);
		this.simpleButton38.Name = "simpleButton38";
		this.simpleButton38.Size = new System.Drawing.Size(46, 36);
		this.simpleButton38.StyleController = this.layoutControl1;
		this.simpleButton38.TabIndex = 41;
		this.simpleButton38.Text = "4";
		this.simpleButton38.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton37.AllowFocus = false;
		this.simpleButton37.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton37.Appearance.Options.UseFont = true;
		this.simpleButton37.Location = new System.Drawing.Point(112, 47);
		this.simpleButton37.Name = "simpleButton37";
		this.simpleButton37.Size = new System.Drawing.Size(46, 36);
		this.simpleButton37.StyleController = this.layoutControl1;
		this.simpleButton37.TabIndex = 40;
		this.simpleButton37.Text = "3";
		this.simpleButton37.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton36.AllowFocus = false;
		this.simpleButton36.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton36.Appearance.Options.UseFont = true;
		this.simpleButton36.Location = new System.Drawing.Point(62, 47);
		this.simpleButton36.Name = "simpleButton36";
		this.simpleButton36.Size = new System.Drawing.Size(46, 36);
		this.simpleButton36.StyleController = this.layoutControl1;
		this.simpleButton36.TabIndex = 39;
		this.simpleButton36.Text = "2";
		this.simpleButton36.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton35.AllowFocus = false;
		this.simpleButton35.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton35.Appearance.Options.UseFont = true;
		this.simpleButton35.Location = new System.Drawing.Point(12, 47);
		this.simpleButton35.Name = "simpleButton35";
		this.simpleButton35.Size = new System.Drawing.Size(46, 36);
		this.simpleButton35.StyleController = this.layoutControl1;
		this.simpleButton35.TabIndex = 38;
		this.simpleButton35.Text = "1";
		this.simpleButton35.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton34.AllowFocus = false;
		this.simpleButton34.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton34.Appearance.Options.UseFont = true;
		this.simpleButton34.Location = new System.Drawing.Point(512, 167);
		this.simpleButton34.Name = "simpleButton34";
		this.simpleButton34.Size = new System.Drawing.Size(74, 36);
		this.simpleButton34.StyleController = this.layoutControl1;
		this.simpleButton34.TabIndex = 37;
		this.simpleButton34.Text = "Space";
		this.simpleButton34.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton33.AllowFocus = false;
		this.simpleButton33.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton33.Appearance.Options.UseFont = true;
		this.simpleButton33.Location = new System.Drawing.Point(572, 47);
		this.simpleButton33.Name = "simpleButton33";
		this.simpleButton33.Size = new System.Drawing.Size(93, 36);
		this.simpleButton33.StyleController = this.layoutControl1;
		this.simpleButton33.TabIndex = 36;
		this.simpleButton33.Text = "Backspace";
		this.simpleButton33.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton32.AllowFocus = false;
		this.simpleButton32.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton32.Appearance.Options.UseFont = true;
		this.simpleButton32.Location = new System.Drawing.Point(590, 167);
		this.simpleButton32.Name = "simpleButton32";
		this.simpleButton32.Size = new System.Drawing.Size(75, 36);
		this.simpleButton32.StyleController = this.layoutControl1;
		this.simpleButton32.TabIndex = 35;
		this.simpleButton32.Text = "Shift";
		this.simpleButton32.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton30.AllowFocus = false;
		this.simpleButton30.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton30.Appearance.Options.UseFont = true;
		this.simpleButton30.Location = new System.Drawing.Point(462, 127);
		this.simpleButton30.Name = "simpleButton30";
		this.simpleButton30.Size = new System.Drawing.Size(46, 36);
		this.simpleButton30.StyleController = this.layoutControl1;
		this.simpleButton30.TabIndex = 33;
		this.simpleButton30.Text = ":";
		this.simpleButton30.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton29.AllowFocus = false;
		this.simpleButton29.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton29.Appearance.Options.UseFont = true;
		this.simpleButton29.Location = new System.Drawing.Point(412, 127);
		this.simpleButton29.Name = "simpleButton29";
		this.simpleButton29.Size = new System.Drawing.Size(46, 36);
		this.simpleButton29.StyleController = this.layoutControl1;
		this.simpleButton29.TabIndex = 32;
		this.simpleButton29.Text = "L";
		this.simpleButton29.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton28.AllowFocus = false;
		this.simpleButton28.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton28.Appearance.Options.UseFont = true;
		this.simpleButton28.Location = new System.Drawing.Point(362, 127);
		this.simpleButton28.Name = "simpleButton28";
		this.simpleButton28.Size = new System.Drawing.Size(46, 36);
		this.simpleButton28.StyleController = this.layoutControl1;
		this.simpleButton28.TabIndex = 31;
		this.simpleButton28.Text = "K";
		this.simpleButton28.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton27.AllowFocus = false;
		this.simpleButton27.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton27.Appearance.Options.UseFont = true;
		this.simpleButton27.Location = new System.Drawing.Point(312, 127);
		this.simpleButton27.Name = "simpleButton27";
		this.simpleButton27.Size = new System.Drawing.Size(46, 36);
		this.simpleButton27.StyleController = this.layoutControl1;
		this.simpleButton27.TabIndex = 30;
		this.simpleButton27.Text = "J";
		this.simpleButton27.Click += new System.EventHandler(VsimpleButton_Click);
		this.btnEnter.AllowFocus = false;
		this.btnEnter.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.btnEnter.Appearance.Options.UseFont = true;
		this.btnEnter.Location = new System.Drawing.Point(512, 87);
		this.btnEnter.Name = "btnEnter";
		this.btnEnter.Size = new System.Drawing.Size(153, 76);
		this.btnEnter.StyleController = this.layoutControl1;
		this.btnEnter.TabIndex = 34;
		this.btnEnter.Text = "Enter";
		this.btnEnter.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton26.AllowFocus = false;
		this.simpleButton26.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton26.Appearance.Options.UseFont = true;
		this.simpleButton26.Location = new System.Drawing.Point(262, 127);
		this.simpleButton26.Name = "simpleButton26";
		this.simpleButton26.Size = new System.Drawing.Size(46, 36);
		this.simpleButton26.StyleController = this.layoutControl1;
		this.simpleButton26.TabIndex = 29;
		this.simpleButton26.Text = "H";
		this.simpleButton26.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton25.AllowFocus = false;
		this.simpleButton25.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton25.Appearance.Options.UseFont = true;
		this.simpleButton25.Location = new System.Drawing.Point(212, 127);
		this.simpleButton25.Name = "simpleButton25";
		this.simpleButton25.Size = new System.Drawing.Size(46, 36);
		this.simpleButton25.StyleController = this.layoutControl1;
		this.simpleButton25.TabIndex = 28;
		this.simpleButton25.Text = "G";
		this.simpleButton25.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton24.AllowFocus = false;
		this.simpleButton24.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton24.Appearance.Options.UseFont = true;
		this.simpleButton24.Location = new System.Drawing.Point(162, 127);
		this.simpleButton24.Name = "simpleButton24";
		this.simpleButton24.Size = new System.Drawing.Size(46, 36);
		this.simpleButton24.StyleController = this.layoutControl1;
		this.simpleButton24.TabIndex = 27;
		this.simpleButton24.Text = "F";
		this.simpleButton24.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton23.AllowFocus = false;
		this.simpleButton23.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton23.Appearance.Options.UseFont = true;
		this.simpleButton23.Location = new System.Drawing.Point(112, 127);
		this.simpleButton23.Name = "simpleButton23";
		this.simpleButton23.Size = new System.Drawing.Size(46, 36);
		this.simpleButton23.StyleController = this.layoutControl1;
		this.simpleButton23.TabIndex = 26;
		this.simpleButton23.Text = "D";
		this.simpleButton23.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton22.AllowFocus = false;
		this.simpleButton22.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton22.Appearance.Options.UseFont = true;
		this.simpleButton22.Location = new System.Drawing.Point(62, 127);
		this.simpleButton22.Name = "simpleButton22";
		this.simpleButton22.Size = new System.Drawing.Size(46, 36);
		this.simpleButton22.StyleController = this.layoutControl1;
		this.simpleButton22.TabIndex = 25;
		this.simpleButton22.Text = "S";
		this.simpleButton22.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton21.AllowFocus = false;
		this.simpleButton21.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton21.Appearance.Options.UseFont = true;
		this.simpleButton21.Location = new System.Drawing.Point(12, 127);
		this.simpleButton21.Name = "simpleButton21";
		this.simpleButton21.Size = new System.Drawing.Size(46, 36);
		this.simpleButton21.StyleController = this.layoutControl1;
		this.simpleButton21.TabIndex = 24;
		this.simpleButton21.Text = "A";
		this.simpleButton21.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton20.AllowFocus = false;
		this.simpleButton20.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton20.Appearance.Options.UseFont = true;
		this.simpleButton20.Location = new System.Drawing.Point(462, 167);
		this.simpleButton20.Name = "simpleButton20";
		this.simpleButton20.Size = new System.Drawing.Size(46, 36);
		this.simpleButton20.StyleController = this.layoutControl1;
		this.simpleButton20.TabIndex = 23;
		this.simpleButton20.Text = "?";
		this.simpleButton20.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton19.AllowFocus = false;
		this.simpleButton19.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton19.Appearance.Options.UseFont = true;
		this.simpleButton19.Location = new System.Drawing.Point(412, 167);
		this.simpleButton19.Name = "simpleButton19";
		this.simpleButton19.Size = new System.Drawing.Size(46, 36);
		this.simpleButton19.StyleController = this.layoutControl1;
		this.simpleButton19.TabIndex = 22;
		this.simpleButton19.Text = ">";
		this.simpleButton19.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton18.AllowFocus = false;
		this.simpleButton18.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton18.Appearance.Options.UseFont = true;
		this.simpleButton18.Location = new System.Drawing.Point(362, 167);
		this.simpleButton18.Name = "simpleButton18";
		this.simpleButton18.Size = new System.Drawing.Size(46, 36);
		this.simpleButton18.StyleController = this.layoutControl1;
		this.simpleButton18.TabIndex = 21;
		this.simpleButton18.Text = "<";
		this.simpleButton18.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton17.AllowFocus = false;
		this.simpleButton17.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton17.Appearance.Options.UseFont = true;
		this.simpleButton17.Location = new System.Drawing.Point(312, 167);
		this.simpleButton17.Name = "simpleButton17";
		this.simpleButton17.Size = new System.Drawing.Size(46, 36);
		this.simpleButton17.StyleController = this.layoutControl1;
		this.simpleButton17.TabIndex = 20;
		this.simpleButton17.Text = "M";
		this.simpleButton17.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton16.AllowFocus = false;
		this.simpleButton16.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton16.Appearance.Options.UseFont = true;
		this.simpleButton16.Location = new System.Drawing.Point(262, 167);
		this.simpleButton16.Name = "simpleButton16";
		this.simpleButton16.Size = new System.Drawing.Size(46, 36);
		this.simpleButton16.StyleController = this.layoutControl1;
		this.simpleButton16.TabIndex = 19;
		this.simpleButton16.Text = "N";
		this.simpleButton16.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton15.AllowFocus = false;
		this.simpleButton15.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton15.Appearance.Options.UseFont = true;
		this.simpleButton15.Location = new System.Drawing.Point(212, 167);
		this.simpleButton15.Name = "simpleButton15";
		this.simpleButton15.Size = new System.Drawing.Size(46, 36);
		this.simpleButton15.StyleController = this.layoutControl1;
		this.simpleButton15.TabIndex = 18;
		this.simpleButton15.Text = "B";
		this.simpleButton15.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton14.AllowFocus = false;
		this.simpleButton14.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton14.Appearance.Options.UseFont = true;
		this.simpleButton14.Location = new System.Drawing.Point(162, 167);
		this.simpleButton14.Name = "simpleButton14";
		this.simpleButton14.Size = new System.Drawing.Size(46, 36);
		this.simpleButton14.StyleController = this.layoutControl1;
		this.simpleButton14.TabIndex = 17;
		this.simpleButton14.Text = "V";
		this.simpleButton14.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton13.AllowFocus = false;
		this.simpleButton13.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton13.Appearance.Options.UseFont = true;
		this.simpleButton13.Location = new System.Drawing.Point(112, 167);
		this.simpleButton13.Name = "simpleButton13";
		this.simpleButton13.Size = new System.Drawing.Size(46, 36);
		this.simpleButton13.StyleController = this.layoutControl1;
		this.simpleButton13.TabIndex = 16;
		this.simpleButton13.Text = "C";
		this.simpleButton13.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton12.AllowFocus = false;
		this.simpleButton12.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton12.Appearance.Options.UseFont = true;
		this.simpleButton12.Location = new System.Drawing.Point(62, 167);
		this.simpleButton12.Name = "simpleButton12";
		this.simpleButton12.Size = new System.Drawing.Size(46, 36);
		this.simpleButton12.StyleController = this.layoutControl1;
		this.simpleButton12.TabIndex = 15;
		this.simpleButton12.Text = "X";
		this.simpleButton12.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton11.AllowFocus = false;
		this.simpleButton11.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton11.Appearance.Options.UseFont = true;
		this.simpleButton11.Location = new System.Drawing.Point(12, 167);
		this.simpleButton11.Name = "simpleButton11";
		this.simpleButton11.Size = new System.Drawing.Size(46, 36);
		this.simpleButton11.StyleController = this.layoutControl1;
		this.simpleButton11.TabIndex = 14;
		this.simpleButton11.Text = "Z";
		this.simpleButton11.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton10.AllowFocus = false;
		this.simpleButton10.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton10.Appearance.Options.UseFont = true;
		this.simpleButton10.Location = new System.Drawing.Point(112, 87);
		this.simpleButton10.Name = "simpleButton10";
		this.simpleButton10.Size = new System.Drawing.Size(46, 36);
		this.simpleButton10.StyleController = this.layoutControl1;
		this.simpleButton10.TabIndex = 13;
		this.simpleButton10.Text = "E";
		this.simpleButton10.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton9.AllowFocus = false;
		this.simpleButton9.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton9.Appearance.Options.UseFont = true;
		this.simpleButton9.Location = new System.Drawing.Point(412, 87);
		this.simpleButton9.Name = "simpleButton9";
		this.simpleButton9.Size = new System.Drawing.Size(46, 36);
		this.simpleButton9.StyleController = this.layoutControl1;
		this.simpleButton9.TabIndex = 12;
		this.simpleButton9.Text = "O";
		this.simpleButton9.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton8.AllowFocus = false;
		this.simpleButton8.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton8.Appearance.Options.UseFont = true;
		this.simpleButton8.Location = new System.Drawing.Point(362, 87);
		this.simpleButton8.Name = "simpleButton8";
		this.simpleButton8.Size = new System.Drawing.Size(46, 36);
		this.simpleButton8.StyleController = this.layoutControl1;
		this.simpleButton8.TabIndex = 11;
		this.simpleButton8.Text = "I";
		this.simpleButton8.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton7.AllowFocus = false;
		this.simpleButton7.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton7.Appearance.Options.UseFont = true;
		this.simpleButton7.Location = new System.Drawing.Point(312, 87);
		this.simpleButton7.Name = "simpleButton7";
		this.simpleButton7.Size = new System.Drawing.Size(46, 36);
		this.simpleButton7.StyleController = this.layoutControl1;
		this.simpleButton7.TabIndex = 10;
		this.simpleButton7.Text = "U";
		this.simpleButton7.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton6.AllowFocus = false;
		this.simpleButton6.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton6.Appearance.Options.UseFont = true;
		this.simpleButton6.Location = new System.Drawing.Point(62, 87);
		this.simpleButton6.Name = "simpleButton6";
		this.simpleButton6.Size = new System.Drawing.Size(46, 36);
		this.simpleButton6.StyleController = this.layoutControl1;
		this.simpleButton6.TabIndex = 9;
		this.simpleButton6.Text = "W";
		this.simpleButton6.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton5.AllowFocus = false;
		this.simpleButton5.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton5.Appearance.Options.UseFont = true;
		this.simpleButton5.Location = new System.Drawing.Point(212, 87);
		this.simpleButton5.Name = "simpleButton5";
		this.simpleButton5.Size = new System.Drawing.Size(46, 36);
		this.simpleButton5.StyleController = this.layoutControl1;
		this.simpleButton5.TabIndex = 8;
		this.simpleButton5.Text = "T";
		this.simpleButton5.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton4.AllowFocus = false;
		this.simpleButton4.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton4.Appearance.Options.UseFont = true;
		this.simpleButton4.Location = new System.Drawing.Point(162, 87);
		this.simpleButton4.Name = "simpleButton4";
		this.simpleButton4.Size = new System.Drawing.Size(46, 36);
		this.simpleButton4.StyleController = this.layoutControl1;
		this.simpleButton4.TabIndex = 7;
		this.simpleButton4.Text = "R";
		this.simpleButton4.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton3.AllowFocus = false;
		this.simpleButton3.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton3.Appearance.Options.UseFont = true;
		this.simpleButton3.Location = new System.Drawing.Point(262, 87);
		this.simpleButton3.Name = "simpleButton3";
		this.simpleButton3.Size = new System.Drawing.Size(46, 36);
		this.simpleButton3.StyleController = this.layoutControl1;
		this.simpleButton3.TabIndex = 6;
		this.simpleButton3.Text = "Y";
		this.simpleButton3.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton2.AllowFocus = false;
		this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton2.Appearance.Options.UseFont = true;
		this.simpleButton2.Location = new System.Drawing.Point(462, 87);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(46, 36);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 5;
		this.simpleButton2.Text = "P";
		this.simpleButton2.Click += new System.EventHandler(VsimpleButton_Click);
		this.simpleButton1.AllowFocus = false;
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.Location = new System.Drawing.Point(12, 87);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(46, 36);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 4;
		this.simpleButton1.Text = "Q";
		this.simpleButton1.Click += new System.EventHandler(VsimpleButton_Click);
		this.layoutControlGroup1.CustomizationFormText = "Root";
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[48]
		{
			this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem4, this.layoutControlItem5, this.layoutControlItem6, this.layoutControlItem7, this.layoutControlItem8, this.layoutControlItem9, this.layoutControlItem10,
			this.layoutControlItem21, this.layoutControlItem22, this.layoutControlItem23, this.layoutControlItem24, this.layoutControlItem25, this.layoutControlItem26, this.layoutControlItem27, this.layoutControlItem28, this.layoutControlItem29, this.layoutControlItem30,
			this.layoutControlItem31, this.layoutControlItem32, this.layoutControlItem33, this.layoutControlItem34, this.layoutControlItem35, this.layoutControlItem36, this.layoutControlItem37, this.layoutControlItem38, this.layoutControlItem39, this.layoutControlItem40,
			this.layoutControlItem43, this.emptySpaceItem4, this.layoutControlItem45, this.layoutControlItem46, this.layoutControlItem47, this.layoutControlItem48, this.layoutControlItem49, this.layoutControlItem50, this.layoutControlItem51, this.layoutControlItem52,
			this.layoutControlItem53, this.layoutControlItem54, this.layoutControlItem55, this.layoutControlItem56, this.layoutControlItem44, this.layoutControlItem57, this.layoutControlItem41, this.layoutControlItem42
		});
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "Root";
		this.layoutControlGroup1.Size = new System.Drawing.Size(677, 216);
		this.layoutControlGroup1.Text = "Root";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.simpleButton1;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 75);
		this.layoutControlItem1.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem1.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem2.Control = this.simpleButton2;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(450, 75);
		this.layoutControlItem2.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem2.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem2.Text = "layoutControlItem2";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextToControlDistance = 0;
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem3.Control = this.simpleButton3;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(250, 75);
		this.layoutControlItem3.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem3.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem3.Text = "layoutControlItem3";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextToControlDistance = 0;
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem4.Control = this.simpleButton4;
		this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
		this.layoutControlItem4.Location = new System.Drawing.Point(150, 75);
		this.layoutControlItem4.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem4.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem4.Text = "layoutControlItem4";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextToControlDistance = 0;
		this.layoutControlItem4.TextVisible = false;
		this.layoutControlItem5.Control = this.simpleButton5;
		this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
		this.layoutControlItem5.Location = new System.Drawing.Point(200, 75);
		this.layoutControlItem5.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem5.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem5.Text = "layoutControlItem5";
		this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.TextToControlDistance = 0;
		this.layoutControlItem5.TextVisible = false;
		this.layoutControlItem6.Control = this.simpleButton6;
		this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
		this.layoutControlItem6.Location = new System.Drawing.Point(50, 75);
		this.layoutControlItem6.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem6.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem6.Text = "layoutControlItem6";
		this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem6.TextToControlDistance = 0;
		this.layoutControlItem6.TextVisible = false;
		this.layoutControlItem7.Control = this.simpleButton7;
		this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
		this.layoutControlItem7.Location = new System.Drawing.Point(300, 75);
		this.layoutControlItem7.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem7.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem7.Text = "layoutControlItem7";
		this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem7.TextToControlDistance = 0;
		this.layoutControlItem7.TextVisible = false;
		this.layoutControlItem8.Control = this.simpleButton8;
		this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
		this.layoutControlItem8.Location = new System.Drawing.Point(350, 75);
		this.layoutControlItem8.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem8.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem8.Text = "layoutControlItem8";
		this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem8.TextToControlDistance = 0;
		this.layoutControlItem8.TextVisible = false;
		this.layoutControlItem9.Control = this.simpleButton9;
		this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
		this.layoutControlItem9.Location = new System.Drawing.Point(400, 75);
		this.layoutControlItem9.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem9.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem9.Name = "layoutControlItem9";
		this.layoutControlItem9.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem9.Text = "layoutControlItem9";
		this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem9.TextToControlDistance = 0;
		this.layoutControlItem9.TextVisible = false;
		this.layoutControlItem10.Control = this.simpleButton10;
		this.layoutControlItem10.CustomizationFormText = "layoutControlItem10";
		this.layoutControlItem10.Location = new System.Drawing.Point(100, 75);
		this.layoutControlItem10.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem10.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem10.Name = "layoutControlItem10";
		this.layoutControlItem10.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem10.Text = "layoutControlItem10";
		this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem10.TextToControlDistance = 0;
		this.layoutControlItem10.TextVisible = false;
		this.layoutControlItem21.Control = this.simpleButton11;
		this.layoutControlItem21.CustomizationFormText = "layoutControlItem21";
		this.layoutControlItem21.Location = new System.Drawing.Point(0, 155);
		this.layoutControlItem21.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem21.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem21.Name = "layoutControlItem21";
		this.layoutControlItem21.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem21.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem21.Text = "layoutControlItem21";
		this.layoutControlItem21.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem21.TextToControlDistance = 0;
		this.layoutControlItem21.TextVisible = false;
		this.layoutControlItem22.Control = this.simpleButton12;
		this.layoutControlItem22.CustomizationFormText = "layoutControlItem22";
		this.layoutControlItem22.Location = new System.Drawing.Point(50, 155);
		this.layoutControlItem22.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem22.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem22.Name = "layoutControlItem22";
		this.layoutControlItem22.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem22.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem22.Text = "layoutControlItem22";
		this.layoutControlItem22.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem22.TextToControlDistance = 0;
		this.layoutControlItem22.TextVisible = false;
		this.layoutControlItem23.Control = this.simpleButton13;
		this.layoutControlItem23.CustomizationFormText = "layoutControlItem23";
		this.layoutControlItem23.Location = new System.Drawing.Point(100, 155);
		this.layoutControlItem23.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem23.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem23.Name = "layoutControlItem23";
		this.layoutControlItem23.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem23.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem23.Text = "layoutControlItem23";
		this.layoutControlItem23.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem23.TextToControlDistance = 0;
		this.layoutControlItem23.TextVisible = false;
		this.layoutControlItem24.Control = this.simpleButton14;
		this.layoutControlItem24.CustomizationFormText = "V";
		this.layoutControlItem24.Location = new System.Drawing.Point(150, 155);
		this.layoutControlItem24.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem24.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem24.Name = "layoutControlItem24";
		this.layoutControlItem24.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem24.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem24.Text = "V";
		this.layoutControlItem24.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem24.TextToControlDistance = 0;
		this.layoutControlItem24.TextVisible = false;
		this.layoutControlItem25.Control = this.simpleButton15;
		this.layoutControlItem25.CustomizationFormText = "layoutControlItem25";
		this.layoutControlItem25.Location = new System.Drawing.Point(200, 155);
		this.layoutControlItem25.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem25.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem25.Name = "layoutControlItem25";
		this.layoutControlItem25.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem25.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem25.Text = "layoutControlItem25";
		this.layoutControlItem25.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem25.TextToControlDistance = 0;
		this.layoutControlItem25.TextVisible = false;
		this.layoutControlItem26.Control = this.simpleButton16;
		this.layoutControlItem26.CustomizationFormText = "layoutControlItem26";
		this.layoutControlItem26.Location = new System.Drawing.Point(250, 155);
		this.layoutControlItem26.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem26.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem26.Name = "layoutControlItem26";
		this.layoutControlItem26.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem26.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem26.Text = "layoutControlItem26";
		this.layoutControlItem26.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem26.TextToControlDistance = 0;
		this.layoutControlItem26.TextVisible = false;
		this.layoutControlItem27.Control = this.simpleButton17;
		this.layoutControlItem27.CustomizationFormText = "layoutControlItem27";
		this.layoutControlItem27.Location = new System.Drawing.Point(300, 155);
		this.layoutControlItem27.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem27.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem27.Name = "layoutControlItem27";
		this.layoutControlItem27.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem27.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem27.Text = "layoutControlItem27";
		this.layoutControlItem27.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem27.TextToControlDistance = 0;
		this.layoutControlItem27.TextVisible = false;
		this.layoutControlItem28.Control = this.simpleButton18;
		this.layoutControlItem28.CustomizationFormText = "layoutControlItem28";
		this.layoutControlItem28.Location = new System.Drawing.Point(350, 155);
		this.layoutControlItem28.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem28.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem28.Name = "layoutControlItem28";
		this.layoutControlItem28.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem28.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem28.Text = "layoutControlItem28";
		this.layoutControlItem28.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem28.TextToControlDistance = 0;
		this.layoutControlItem28.TextVisible = false;
		this.layoutControlItem29.Control = this.simpleButton19;
		this.layoutControlItem29.CustomizationFormText = "layoutControlItem29";
		this.layoutControlItem29.Location = new System.Drawing.Point(400, 155);
		this.layoutControlItem29.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem29.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem29.Name = "layoutControlItem29";
		this.layoutControlItem29.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem29.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem29.Text = "layoutControlItem29";
		this.layoutControlItem29.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem29.TextToControlDistance = 0;
		this.layoutControlItem29.TextVisible = false;
		this.layoutControlItem30.Control = this.simpleButton20;
		this.layoutControlItem30.CustomizationFormText = "layoutControlItem30";
		this.layoutControlItem30.Location = new System.Drawing.Point(450, 155);
		this.layoutControlItem30.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem30.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem30.Name = "layoutControlItem30";
		this.layoutControlItem30.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem30.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem30.Text = "layoutControlItem30";
		this.layoutControlItem30.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem30.TextToControlDistance = 0;
		this.layoutControlItem30.TextVisible = false;
		this.layoutControlItem31.Control = this.simpleButton21;
		this.layoutControlItem31.CustomizationFormText = "layoutControlItem31";
		this.layoutControlItem31.Location = new System.Drawing.Point(0, 115);
		this.layoutControlItem31.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem31.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem31.Name = "layoutControlItem31";
		this.layoutControlItem31.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem31.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem31.Text = "layoutControlItem31";
		this.layoutControlItem31.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem31.TextToControlDistance = 0;
		this.layoutControlItem31.TextVisible = false;
		this.layoutControlItem32.Control = this.simpleButton22;
		this.layoutControlItem32.CustomizationFormText = "layoutControlItem32";
		this.layoutControlItem32.Location = new System.Drawing.Point(50, 115);
		this.layoutControlItem32.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem32.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem32.Name = "layoutControlItem32";
		this.layoutControlItem32.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem32.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem32.Text = "layoutControlItem32";
		this.layoutControlItem32.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem32.TextToControlDistance = 0;
		this.layoutControlItem32.TextVisible = false;
		this.layoutControlItem33.Control = this.simpleButton23;
		this.layoutControlItem33.CustomizationFormText = "layoutControlItem33";
		this.layoutControlItem33.Location = new System.Drawing.Point(100, 115);
		this.layoutControlItem33.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem33.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem33.Name = "layoutControlItem33";
		this.layoutControlItem33.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem33.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem33.Text = "layoutControlItem33";
		this.layoutControlItem33.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem33.TextToControlDistance = 0;
		this.layoutControlItem33.TextVisible = false;
		this.layoutControlItem34.Control = this.simpleButton24;
		this.layoutControlItem34.CustomizationFormText = "layoutControlItem34";
		this.layoutControlItem34.Location = new System.Drawing.Point(150, 115);
		this.layoutControlItem34.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem34.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem34.Name = "layoutControlItem34";
		this.layoutControlItem34.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem34.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem34.Text = "layoutControlItem34";
		this.layoutControlItem34.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem34.TextToControlDistance = 0;
		this.layoutControlItem34.TextVisible = false;
		this.layoutControlItem35.Control = this.simpleButton25;
		this.layoutControlItem35.CustomizationFormText = "layoutControlItem35";
		this.layoutControlItem35.Location = new System.Drawing.Point(200, 115);
		this.layoutControlItem35.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem35.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem35.Name = "layoutControlItem35";
		this.layoutControlItem35.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem35.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem35.Text = "layoutControlItem35";
		this.layoutControlItem35.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem35.TextToControlDistance = 0;
		this.layoutControlItem35.TextVisible = false;
		this.layoutControlItem36.Control = this.simpleButton26;
		this.layoutControlItem36.CustomizationFormText = "layoutControlItem36";
		this.layoutControlItem36.Location = new System.Drawing.Point(250, 115);
		this.layoutControlItem36.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem36.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem36.Name = "layoutControlItem36";
		this.layoutControlItem36.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem36.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem36.Text = "layoutControlItem36";
		this.layoutControlItem36.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem36.TextToControlDistance = 0;
		this.layoutControlItem36.TextVisible = false;
		this.layoutControlItem37.Control = this.simpleButton27;
		this.layoutControlItem37.CustomizationFormText = "layoutControlItem37";
		this.layoutControlItem37.Location = new System.Drawing.Point(300, 115);
		this.layoutControlItem37.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem37.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem37.Name = "layoutControlItem37";
		this.layoutControlItem37.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem37.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem37.Text = "layoutControlItem37";
		this.layoutControlItem37.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem37.TextToControlDistance = 0;
		this.layoutControlItem37.TextVisible = false;
		this.layoutControlItem38.Control = this.simpleButton28;
		this.layoutControlItem38.CustomizationFormText = "layoutControlItem38";
		this.layoutControlItem38.Location = new System.Drawing.Point(350, 115);
		this.layoutControlItem38.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem38.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem38.Name = "layoutControlItem38";
		this.layoutControlItem38.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem38.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem38.Text = "layoutControlItem38";
		this.layoutControlItem38.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem38.TextToControlDistance = 0;
		this.layoutControlItem38.TextVisible = false;
		this.layoutControlItem39.Control = this.simpleButton29;
		this.layoutControlItem39.CustomizationFormText = "layoutControlItem39";
		this.layoutControlItem39.Location = new System.Drawing.Point(400, 115);
		this.layoutControlItem39.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem39.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem39.Name = "layoutControlItem39";
		this.layoutControlItem39.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem39.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem39.Text = "layoutControlItem39";
		this.layoutControlItem39.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem39.TextToControlDistance = 0;
		this.layoutControlItem39.TextVisible = false;
		this.layoutControlItem40.Control = this.simpleButton30;
		this.layoutControlItem40.CustomizationFormText = "layoutControlItem40";
		this.layoutControlItem40.Location = new System.Drawing.Point(450, 115);
		this.layoutControlItem40.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem40.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem40.Name = "layoutControlItem40";
		this.layoutControlItem40.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem40.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem40.Text = "layoutControlItem40";
		this.layoutControlItem40.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem40.TextToControlDistance = 0;
		this.layoutControlItem40.TextVisible = false;
		this.layoutControlItem43.Control = this.simpleButton33;
		this.layoutControlItem43.CustomizationFormText = "layoutControlItem43";
		this.layoutControlItem43.Location = new System.Drawing.Point(560, 35);
		this.layoutControlItem43.MinSize = new System.Drawing.Size(86, 30);
		this.layoutControlItem43.Name = "layoutControlItem43";
		this.layoutControlItem43.Size = new System.Drawing.Size(97, 40);
		this.layoutControlItem43.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem43.Text = "layoutControlItem43";
		this.layoutControlItem43.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem43.TextToControlDistance = 0;
		this.layoutControlItem43.TextVisible = false;
		this.emptySpaceItem4.CustomizationFormText = "emptySpaceItem4";
		this.emptySpaceItem4.Location = new System.Drawing.Point(0, 195);
		this.emptySpaceItem4.MinSize = new System.Drawing.Size(1, 1);
		this.emptySpaceItem4.Name = "emptySpaceItem4";
		this.emptySpaceItem4.Size = new System.Drawing.Size(657, 1);
		this.emptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.emptySpaceItem4.Text = "emptySpaceItem4";
		this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem45.Control = this.simpleButton35;
		this.layoutControlItem45.CustomizationFormText = "layoutControlItem45";
		this.layoutControlItem45.Location = new System.Drawing.Point(0, 35);
		this.layoutControlItem45.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem45.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem45.Name = "layoutControlItem45";
		this.layoutControlItem45.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem45.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem45.Text = "layoutControlItem45";
		this.layoutControlItem45.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem45.TextToControlDistance = 0;
		this.layoutControlItem45.TextVisible = false;
		this.layoutControlItem46.Control = this.simpleButton36;
		this.layoutControlItem46.CustomizationFormText = "layoutControlItem46";
		this.layoutControlItem46.Location = new System.Drawing.Point(50, 35);
		this.layoutControlItem46.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem46.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem46.Name = "layoutControlItem46";
		this.layoutControlItem46.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem46.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem46.Text = "layoutControlItem46";
		this.layoutControlItem46.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem46.TextToControlDistance = 0;
		this.layoutControlItem46.TextVisible = false;
		this.layoutControlItem47.Control = this.simpleButton37;
		this.layoutControlItem47.CustomizationFormText = "layoutControlItem47";
		this.layoutControlItem47.Location = new System.Drawing.Point(100, 35);
		this.layoutControlItem47.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem47.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem47.Name = "layoutControlItem47";
		this.layoutControlItem47.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem47.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem47.Text = "layoutControlItem47";
		this.layoutControlItem47.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem47.TextToControlDistance = 0;
		this.layoutControlItem47.TextVisible = false;
		this.layoutControlItem48.Control = this.simpleButton38;
		this.layoutControlItem48.CustomizationFormText = "layoutControlItem48";
		this.layoutControlItem48.Location = new System.Drawing.Point(150, 35);
		this.layoutControlItem48.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem48.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem48.Name = "layoutControlItem48";
		this.layoutControlItem48.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem48.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem48.Text = "layoutControlItem48";
		this.layoutControlItem48.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem48.TextToControlDistance = 0;
		this.layoutControlItem48.TextVisible = false;
		this.layoutControlItem49.Control = this.simpleButton39;
		this.layoutControlItem49.CustomizationFormText = "layoutControlItem49";
		this.layoutControlItem49.Location = new System.Drawing.Point(200, 35);
		this.layoutControlItem49.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem49.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem49.Name = "layoutControlItem49";
		this.layoutControlItem49.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem49.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem49.Text = "layoutControlItem49";
		this.layoutControlItem49.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem49.TextToControlDistance = 0;
		this.layoutControlItem49.TextVisible = false;
		this.layoutControlItem50.Control = this.simpleButton40;
		this.layoutControlItem50.CustomizationFormText = "layoutControlItem50";
		this.layoutControlItem50.Location = new System.Drawing.Point(250, 35);
		this.layoutControlItem50.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem50.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem50.Name = "layoutControlItem50";
		this.layoutControlItem50.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem50.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem50.Text = "layoutControlItem50";
		this.layoutControlItem50.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem50.TextToControlDistance = 0;
		this.layoutControlItem50.TextVisible = false;
		this.layoutControlItem51.Control = this.simpleButton41;
		this.layoutControlItem51.CustomizationFormText = "layoutControlItem51";
		this.layoutControlItem51.Location = new System.Drawing.Point(300, 35);
		this.layoutControlItem51.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem51.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem51.Name = "layoutControlItem51";
		this.layoutControlItem51.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem51.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem51.Text = "layoutControlItem51";
		this.layoutControlItem51.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem51.TextToControlDistance = 0;
		this.layoutControlItem51.TextVisible = false;
		this.layoutControlItem52.Control = this.simpleButton42;
		this.layoutControlItem52.CustomizationFormText = "layoutControlItem52";
		this.layoutControlItem52.Location = new System.Drawing.Point(350, 35);
		this.layoutControlItem52.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem52.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem52.Name = "layoutControlItem52";
		this.layoutControlItem52.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem52.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem52.Text = "layoutControlItem52";
		this.layoutControlItem52.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem52.TextToControlDistance = 0;
		this.layoutControlItem52.TextVisible = false;
		this.layoutControlItem53.Control = this.simpleButton43;
		this.layoutControlItem53.CustomizationFormText = "layoutControlItem53";
		this.layoutControlItem53.Location = new System.Drawing.Point(400, 35);
		this.layoutControlItem53.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem53.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem53.Name = "layoutControlItem53";
		this.layoutControlItem53.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem53.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem53.Text = "layoutControlItem53";
		this.layoutControlItem53.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem53.TextToControlDistance = 0;
		this.layoutControlItem53.TextVisible = false;
		this.layoutControlItem54.Control = this.simpleButton44;
		this.layoutControlItem54.CustomizationFormText = "layoutControlItem54";
		this.layoutControlItem54.Location = new System.Drawing.Point(450, 35);
		this.layoutControlItem54.MaxSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem54.MinSize = new System.Drawing.Size(50, 40);
		this.layoutControlItem54.Name = "layoutControlItem54";
		this.layoutControlItem54.Size = new System.Drawing.Size(50, 40);
		this.layoutControlItem54.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem54.Text = "layoutControlItem54";
		this.layoutControlItem54.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem54.TextToControlDistance = 0;
		this.layoutControlItem54.TextVisible = false;
		this.layoutControlItem55.Control = this.txtDisplay;
		this.layoutControlItem55.CustomizationFormText = "layoutControlItem55";
		this.layoutControlItem55.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem55.Name = "layoutControlItem55";
		this.layoutControlItem55.Size = new System.Drawing.Size(577, 35);
		this.layoutControlItem55.Text = "layoutControlItem55";
		this.layoutControlItem55.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem55.TextToControlDistance = 0;
		this.layoutControlItem55.TextVisible = false;
		this.layoutControlItem56.Control = this.simpleButton31;
		this.layoutControlItem56.CustomizationFormText = "Delete";
		this.layoutControlItem56.Location = new System.Drawing.Point(500, 35);
		this.layoutControlItem56.MinSize = new System.Drawing.Size(54, 28);
		this.layoutControlItem56.Name = "layoutControlItem56";
		this.layoutControlItem56.Size = new System.Drawing.Size(60, 40);
		this.layoutControlItem56.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem56.Text = "Delete";
		this.layoutControlItem56.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem56.TextToControlDistance = 0;
		this.layoutControlItem56.TextVisible = false;
		this.layoutControlItem44.Control = this.simpleButton34;
		this.layoutControlItem44.CustomizationFormText = "layoutControlItem44";
		this.layoutControlItem44.Location = new System.Drawing.Point(500, 155);
		this.layoutControlItem44.MinSize = new System.Drawing.Size(56, 30);
		this.layoutControlItem44.Name = "layoutControlItem44";
		this.layoutControlItem44.Size = new System.Drawing.Size(78, 40);
		this.layoutControlItem44.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem44.Text = "layoutControlItem44";
		this.layoutControlItem44.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem44.TextToControlDistance = 0;
		this.layoutControlItem44.TextVisible = false;
		this.layoutControlItem57.Control = this.simpleButton45;
		this.layoutControlItem57.CustomizationFormText = "Clear";
		this.layoutControlItem57.Location = new System.Drawing.Point(577, 0);
		this.layoutControlItem57.MaxSize = new System.Drawing.Size(80, 40);
		this.layoutControlItem57.MinSize = new System.Drawing.Size(80, 30);
		this.layoutControlItem57.Name = "layoutControlItem57";
		this.layoutControlItem57.Size = new System.Drawing.Size(80, 35);
		this.layoutControlItem57.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem57.Text = "Clear";
		this.layoutControlItem57.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem57.TextToControlDistance = 0;
		this.layoutControlItem57.TextVisible = false;
		this.layoutControlItem41.Control = this.btnEnter;
		this.layoutControlItem41.CustomizationFormText = "layoutControlItem41";
		this.layoutControlItem41.Location = new System.Drawing.Point(500, 75);
		this.layoutControlItem41.MinSize = new System.Drawing.Size(53, 30);
		this.layoutControlItem41.Name = "layoutControlItem41";
		this.layoutControlItem41.Size = new System.Drawing.Size(157, 80);
		this.layoutControlItem41.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem41.Text = "layoutControlItem41";
		this.layoutControlItem41.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem41.TextToControlDistance = 0;
		this.layoutControlItem41.TextVisible = false;
		this.layoutControlItem42.Control = this.simpleButton32;
		this.layoutControlItem42.CustomizationFormText = "layoutControlItem42";
		this.layoutControlItem42.Location = new System.Drawing.Point(578, 155);
		this.layoutControlItem42.MinSize = new System.Drawing.Size(1, 40);
		this.layoutControlItem42.Name = "layoutControlItem42";
		this.layoutControlItem42.Size = new System.Drawing.Size(79, 40);
		this.layoutControlItem42.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem42.Text = "layoutControlItem42";
		this.layoutControlItem42.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem42.TextToControlDistance = 0;
		this.layoutControlItem42.TextVisible = false;
		this.layoutControlItem11.Control = this.simpleButton1;
		this.layoutControlItem11.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem11.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem11.Name = "layoutControlItem1";
		this.layoutControlItem11.Size = new System.Drawing.Size(102, 292);
		this.layoutControlItem11.Text = "layoutControlItem1";
		this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem11.TextToControlDistance = 0;
		this.layoutControlItem11.TextVisible = false;
		this.layoutControlItem12.Control = this.simpleButton6;
		this.layoutControlItem12.CustomizationFormText = "layoutControlItem6";
		this.layoutControlItem12.Location = new System.Drawing.Point(102, 0);
		this.layoutControlItem12.Name = "layoutControlItem6";
		this.layoutControlItem12.Size = new System.Drawing.Size(102, 292);
		this.layoutControlItem12.Text = "layoutControlItem6";
		this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem12.TextToControlDistance = 0;
		this.layoutControlItem12.TextVisible = false;
		this.layoutControlItem13.Control = this.simpleButton10;
		this.layoutControlItem13.CustomizationFormText = "layoutControlItem10";
		this.layoutControlItem13.Location = new System.Drawing.Point(204, 0);
		this.layoutControlItem13.Name = "layoutControlItem10";
		this.layoutControlItem13.Size = new System.Drawing.Size(109, 292);
		this.layoutControlItem13.Text = "layoutControlItem10";
		this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem13.TextToControlDistance = 0;
		this.layoutControlItem13.TextVisible = false;
		this.layoutControlItem14.Control = this.simpleButton4;
		this.layoutControlItem14.CustomizationFormText = "layoutControlItem4";
		this.layoutControlItem14.Location = new System.Drawing.Point(313, 0);
		this.layoutControlItem14.Name = "layoutControlItem4";
		this.layoutControlItem14.Size = new System.Drawing.Size(102, 292);
		this.layoutControlItem14.Text = "layoutControlItem4";
		this.layoutControlItem14.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem14.TextToControlDistance = 0;
		this.layoutControlItem14.TextVisible = false;
		this.layoutControlItem15.Control = this.simpleButton5;
		this.layoutControlItem15.CustomizationFormText = "layoutControlItem5";
		this.layoutControlItem15.Location = new System.Drawing.Point(415, 0);
		this.layoutControlItem15.Name = "layoutControlItem5";
		this.layoutControlItem15.Size = new System.Drawing.Size(102, 292);
		this.layoutControlItem15.Text = "layoutControlItem5";
		this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem15.TextToControlDistance = 0;
		this.layoutControlItem15.TextVisible = false;
		this.layoutControlItem16.Control = this.simpleButton3;
		this.layoutControlItem16.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem16.Location = new System.Drawing.Point(517, 0);
		this.layoutControlItem16.Name = "layoutControlItem3";
		this.layoutControlItem16.Size = new System.Drawing.Size(102, 292);
		this.layoutControlItem16.Text = "layoutControlItem3";
		this.layoutControlItem16.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem16.TextToControlDistance = 0;
		this.layoutControlItem16.TextVisible = false;
		this.layoutControlItem17.Control = this.simpleButton7;
		this.layoutControlItem17.CustomizationFormText = "layoutControlItem7";
		this.layoutControlItem17.Location = new System.Drawing.Point(619, 0);
		this.layoutControlItem17.Name = "layoutControlItem7";
		this.layoutControlItem17.Size = new System.Drawing.Size(102, 292);
		this.layoutControlItem17.Text = "layoutControlItem7";
		this.layoutControlItem17.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem17.TextToControlDistance = 0;
		this.layoutControlItem17.TextVisible = false;
		this.layoutControlItem18.Control = this.simpleButton8;
		this.layoutControlItem18.CustomizationFormText = "layoutControlItem8";
		this.layoutControlItem18.Location = new System.Drawing.Point(721, 0);
		this.layoutControlItem18.Name = "layoutControlItem8";
		this.layoutControlItem18.Size = new System.Drawing.Size(102, 292);
		this.layoutControlItem18.Text = "layoutControlItem8";
		this.layoutControlItem18.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem18.TextToControlDistance = 0;
		this.layoutControlItem18.TextVisible = false;
		this.layoutControlItem19.Control = this.simpleButton9;
		this.layoutControlItem19.CustomizationFormText = "layoutControlItem9";
		this.layoutControlItem19.Location = new System.Drawing.Point(823, 0);
		this.layoutControlItem19.Name = "layoutControlItem9";
		this.layoutControlItem19.Size = new System.Drawing.Size(102, 292);
		this.layoutControlItem19.Text = "layoutControlItem9";
		this.layoutControlItem19.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem19.TextToControlDistance = 0;
		this.layoutControlItem19.TextVisible = false;
		this.layoutControlItem20.Control = this.simpleButton2;
		this.layoutControlItem20.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem20.Location = new System.Drawing.Point(925, 0);
		this.layoutControlItem20.Name = "layoutControlItem2";
		this.layoutControlItem20.Size = new System.Drawing.Size(102, 292);
		this.layoutControlItem20.Text = "layoutControlItem2";
		this.layoutControlItem20.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem20.TextToControlDistance = 0;
		this.layoutControlItem20.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		base.ClientSize = new System.Drawing.Size(677, 297);
		base.Controls.Add(this.layoutControl1);
		base.Controls.Add(this.ribbonStatusBar);
		base.Controls.Add(this.ribbon);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "IDAT_VKeyBoard";
		this.Ribbon = this.ribbon;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.StatusBar = this.ribbonStatusBar;
		this.Text = "IDATVKeyboard";
		base.Shown += new System.EventHandler(IDATVKeyboard_Shown);
		((System.ComponentModel.ISupportInitialize)this.ribbon).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtDisplay.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem21).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem22).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem23).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem24).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem25).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem26).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem27).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem28).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem29).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem30).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem31).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem32).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem33).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem34).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem35).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem36).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem37).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem38).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem39).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem40).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem43).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem45).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem46).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem47).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem48).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem49).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem50).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem51).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem52).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem53).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem54).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem55).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem56).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem44).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem57).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem41).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem42).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem12).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem14).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem15).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem16).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem17).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem18).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem19).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem20).EndInit();
		base.ResumeLayout(false);
	}
}
