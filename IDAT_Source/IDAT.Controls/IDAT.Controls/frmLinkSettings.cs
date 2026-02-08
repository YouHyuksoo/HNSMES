using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace IDAT.Controls;

internal class frmLinkSettings : Form
{
	public delegate void SaveHandler(string partnumbercode, string partnumber, string operationcode, string operation, string equipmentcode, string equipment);

	private IContainer components = null;

	private Button btnSave;

	private Button btnClose;

	private ComboBox comboBox_PartNo;

	private Label label1;

	private Label label2;

	private Label label3;

	private Panel panel1;

	private ComboBox comboBox_OP;

	private ComboBox comboBox_EQP;

	private Panel panel2;

	public event SaveHandler SaveEvent;

	public frmLinkSettings()
	{
		InitializeComponent();
	}

	public frmLinkSettings(string operation, string equipment, string partno, DataTable dtOP, string opDisplayMember, string opDataValue, DataTable dtEQ, string eqDisplayMember, string eqDataValue, DataTable dtPN, string pnDisplayMember, string pnDataValue)
		: this()
	{
		comboBox_OP.DataSource = dtOP;
		comboBox_OP.DisplayMember = opDisplayMember;
		comboBox_OP.ValueMember = opDataValue;
		comboBox_EQP.DataSource = dtEQ;
		comboBox_EQP.DisplayMember = eqDisplayMember;
		comboBox_EQP.ValueMember = eqDataValue;
		comboBox_PartNo.DataSource = dtPN;
		comboBox_PartNo.DisplayMember = pnDisplayMember;
		comboBox_PartNo.ValueMember = pnDataValue;
		comboBox_OP.SelectedValue = operation;
		comboBox_EQP.SelectedValue = equipment;
		comboBox_PartNo.SelectedValue = partno;
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		if (this.SaveEvent != null)
		{
			this.SaveEvent((comboBox_PartNo.SelectedValue != null) ? comboBox_PartNo.SelectedValue.ToString() : "", comboBox_PartNo.Text, (comboBox_OP.SelectedValue != null) ? comboBox_OP.SelectedValue.ToString() : "", comboBox_OP.Text, (comboBox_EQP.SelectedValue != null) ? comboBox_EQP.SelectedValue.ToString() : "", comboBox_EQP.Text);
		}
		Close();
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
		this.btnSave = new System.Windows.Forms.Button();
		this.btnClose = new System.Windows.Forms.Button();
		this.comboBox_PartNo = new System.Windows.Forms.ComboBox();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.panel1 = new System.Windows.Forms.Panel();
		this.comboBox_OP = new System.Windows.Forms.ComboBox();
		this.comboBox_EQP = new System.Windows.Forms.ComboBox();
		this.panel2 = new System.Windows.Forms.Panel();
		base.SuspendLayout();
		this.btnSave.BackColor = System.Drawing.Color.Transparent;
		this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSave.Location = new System.Drawing.Point(62, 107);
		this.btnSave.Name = "btnSave";
		this.btnSave.Size = new System.Drawing.Size(75, 23);
		this.btnSave.TabIndex = 3;
		this.btnSave.Text = "save";
		this.btnSave.UseVisualStyleBackColor = false;
		this.btnSave.Click += new System.EventHandler(btnSave_Click);
		this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnClose.Location = new System.Drawing.Point(143, 107);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(75, 23);
		this.btnClose.TabIndex = 4;
		this.btnClose.Text = "close";
		this.btnClose.UseVisualStyleBackColor = true;
		this.btnClose.Click += new System.EventHandler(btnClose_Click);
		this.comboBox_PartNo.FormattingEnabled = true;
		this.comboBox_PartNo.Location = new System.Drawing.Point(91, 73);
		this.comboBox_PartNo.Name = "comboBox_PartNo";
		this.comboBox_PartNo.Size = new System.Drawing.Size(127, 20);
		this.comboBox_PartNo.TabIndex = 2;
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(12, 15);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(67, 12);
		this.label1.TabIndex = 5;
		this.label1.Text = "Operation :";
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(12, 47);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(73, 12);
		this.label2.TabIndex = 6;
		this.label2.Text = "Equipment :";
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(12, 76);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(59, 12);
		this.label3.TabIndex = 7;
		this.label3.Text = "Part No. :";
		this.panel1.BackColor = System.Drawing.SystemColors.GrayText;
		this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.panel1.Location = new System.Drawing.Point(0, 135);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(226, 5);
		this.panel1.TabIndex = 6;
		this.comboBox_OP.FormattingEnabled = true;
		this.comboBox_OP.Location = new System.Drawing.Point(91, 12);
		this.comboBox_OP.Name = "comboBox_OP";
		this.comboBox_OP.Size = new System.Drawing.Size(127, 20);
		this.comboBox_OP.TabIndex = 0;
		this.comboBox_EQP.FormattingEnabled = true;
		this.comboBox_EQP.Location = new System.Drawing.Point(91, 44);
		this.comboBox_EQP.Name = "comboBox_EQP";
		this.comboBox_EQP.Size = new System.Drawing.Size(127, 20);
		this.comboBox_EQP.TabIndex = 1;
		this.panel2.BackColor = System.Drawing.SystemColors.HotTrack;
		this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
		this.panel2.Location = new System.Drawing.Point(0, 0);
		this.panel2.Name = "panel2";
		this.panel2.Size = new System.Drawing.Size(226, 5);
		this.panel2.TabIndex = 8;
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.GhostWhite;
		base.ClientSize = new System.Drawing.Size(226, 140);
		base.Controls.Add(this.panel2);
		base.Controls.Add(this.comboBox_EQP);
		base.Controls.Add(this.comboBox_OP);
		base.Controls.Add(this.panel1);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.comboBox_PartNo);
		base.Controls.Add(this.btnClose);
		base.Controls.Add(this.btnSave);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmSettings";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		this.Text = "frmSettings";
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
