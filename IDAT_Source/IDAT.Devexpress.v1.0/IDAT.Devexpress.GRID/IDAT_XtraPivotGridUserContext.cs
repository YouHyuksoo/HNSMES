using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPivotGrid;
using IDAT.Devexpress.Properties;

namespace IDAT.Devexpress.GRID;

internal class IDAT_XtraPivotGridUserContext : ContextMenuStrip
{
	private ArrayList aryOrgHiddenField = null;

	private ArrayList aryOrgReadonly = null;

	private ImageList imgListIcon = new ImageList();

	private PivotGridControl m_PivotGrid = null;

	private string m_ParentForm = null;

	private IContainer components = null;

	private ToolStripMenuItem toolStripMenuItem1;

	private ToolStripMenuItem toolStripMenuItem4;

	private ToolStripMenuItem toolStripMenuItem5;

	private ToolStripMenuItem toolStripMenuItem7;

	private ToolStripMenuItem toolStripMenuItem9;

	private ToolStripMenuItem toolStripMenuItem10;

	private ToolStripMenuItem toolStripMenuItem12;

	private ToolStripMenuItem toolStripMenuItem13;

	public PivotGridControl PivotGrid
	{
		get
		{
			return m_PivotGrid;
		}
		set
		{
			aryOrgHiddenField = new ArrayList();
			aryOrgReadonly = new ArrayList();
			m_PivotGrid = value;
		}
	}

	public string ParentForm
	{
		get
		{
			return m_ParentForm;
		}
		set
		{
			if (!(m_ParentForm == value))
			{
				m_ParentForm = value;
			}
		}
	}

	public IDAT_XtraPivotGridUserContext()
	{
		InitializeComponent();
		base.ItemClicked += IDAT_XtraUserContext_ItemClicked;
		base.Opening += IDAT_XtraUserContext_Opening;
		toolStripMenuItem1.DropDownItemClicked += IDAT_XtraUserContext_ItemClicked;
		toolStripMenuItem4.DropDownItemClicked += IDAT_XtraUserContext_ItemClicked;
		imgListIcon.Images.Add(Resources.coledit);
		imgListIcon.Images.Add(Resources._lock);
		imgListIcon.Images.Add(Resources.unlock);
	}

	public IDAT_XtraPivotGridUserContext(PivotGridControl pivotgrid, string parentForm)
		: this()
	{
		m_PivotGrid = pivotgrid;
		m_ParentForm = parentForm;
	}

	public string ShowExportFileMessage(string type)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.RestoreDirectory = false;
		saveFileDialog.FileName = DateTime.Now.ToString("yyyyMMddhhmmss") + "." + type;
		saveFileDialog.Filter = string.Format("files (*.{0})|*.{0}", type);
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			try
			{
				return saveFileDialog.FileName;
			}
			catch
			{
				return null;
			}
		}
		return null;
	}

	public void ShowOpenFileMessage(string fileName)
	{
		if (XtraMessageBox.Show("Do you want to open this file?", "Export To...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
		{
			try
			{
				Process process = new Process();
				process.StartInfo.FileName = fileName;
				process.StartInfo.Verb = "Open";
				process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
				process.Start();
			}
			catch
			{
				MessageBox.Show("Cannot find an application on your system suitable for openning the file with exported data.", "Open Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	private void IDAT_XtraUserContext_Opening(object sender, CancelEventArgs e)
	{
	}

	private void IDAT_XtraUserContext_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
	{
		string text = null;
		switch (e.ClickedItem.Tag.ToString())
		{
		case "A-2":
			Close();
			text = ShowExportFileMessage("html");
			if (text != null)
			{
				m_PivotGrid.ExportToHtml(text);
				ShowOpenFileMessage(text);
			}
			break;
		case "A-4":
			Close();
			text = ShowExportFileMessage("pdf");
			if (text != null)
			{
				m_PivotGrid.ExportToPdf(text);
				ShowOpenFileMessage(text);
			}
			break;
		case "A-5":
			Close();
			text = ShowExportFileMessage("txt");
			if (text != null)
			{
				m_PivotGrid.ExportToText(text);
				ShowOpenFileMessage(text);
			}
			break;
		case "A-7":
			Close();
			text = ShowExportFileMessage("xls");
			if (text != null)
			{
				m_PivotGrid.ExportToXls(text);
				ShowOpenFileMessage(text);
			}
			break;
		case "A-8":
			Close();
			text = ShowExportFileMessage("xlsx");
			if (text != null)
			{
				m_PivotGrid.ExportToXlsx(text);
				ShowOpenFileMessage(text);
			}
			break;
		case "E":
			m_PivotGrid.ShowPrintPreview();
			break;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IDAT.Devexpress.GRID.IDAT_XtraPivotGridUserContext));
		this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
		base.SuspendLayout();
		this.toolStripMenuItem5.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem5.Image");
		this.toolStripMenuItem5.Name = "toolStripMenuItem5";
		this.toolStripMenuItem5.Size = new System.Drawing.Size(134, 22);
		this.toolStripMenuItem5.Tag = "E";
		this.toolStripMenuItem5.Text = "Print";
		this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[5] { this.toolStripMenuItem12, this.toolStripMenuItem13, this.toolStripMenuItem7, this.toolStripMenuItem9, this.toolStripMenuItem10 });
		this.toolStripMenuItem1.Image = IDAT.Devexpress.Properties.Resources.export;
		this.toolStripMenuItem1.Name = "toolStripMenuItem1";
		this.toolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
		this.toolStripMenuItem1.Tag = "A";
		this.toolStripMenuItem1.Text = "Export";
		this.toolStripMenuItem12.Image = IDAT.Devexpress.Properties.Resources.xls;
		this.toolStripMenuItem12.Name = "toolStripMenuItem12";
		this.toolStripMenuItem12.Size = new System.Drawing.Size(124, 22);
		this.toolStripMenuItem12.Tag = "A-7";
		this.toolStripMenuItem12.Text = "xls";
		this.toolStripMenuItem13.Image = IDAT.Devexpress.Properties.Resources.xls;
		this.toolStripMenuItem13.Name = "toolStripMenuItem13";
		this.toolStripMenuItem13.Size = new System.Drawing.Size(124, 22);
		this.toolStripMenuItem13.Tag = "A-8";
		this.toolStripMenuItem13.Text = "xlsx";
		this.toolStripMenuItem7.Image = IDAT.Devexpress.Properties.Resources.html;
		this.toolStripMenuItem7.Name = "toolStripMenuItem7";
		this.toolStripMenuItem7.Size = new System.Drawing.Size(124, 22);
		this.toolStripMenuItem7.Tag = "A-2";
		this.toolStripMenuItem7.Text = "Html";
		this.toolStripMenuItem9.Image = IDAT.Devexpress.Properties.Resources.pdf;
		this.toolStripMenuItem9.Name = "toolStripMenuItem9";
		this.toolStripMenuItem9.Size = new System.Drawing.Size(124, 22);
		this.toolStripMenuItem9.Tag = "A-4";
		this.toolStripMenuItem9.Text = "pdf";
		this.toolStripMenuItem9.Visible = false;
		this.toolStripMenuItem10.Image = IDAT.Devexpress.Properties.Resources.text;
		this.toolStripMenuItem10.Name = "toolStripMenuItem10";
		this.toolStripMenuItem10.Size = new System.Drawing.Size(124, 22);
		this.toolStripMenuItem10.Tag = "A-5";
		this.toolStripMenuItem10.Text = "Text";
		this.toolStripMenuItem4.Image = IDAT.Devexpress.Properties.Resources.find;
		this.toolStripMenuItem4.Name = "toolStripMenuItem4";
		this.toolStripMenuItem4.Size = new System.Drawing.Size(134, 22);
		this.toolStripMenuItem4.Tag = "D";
		this.toolStripMenuItem4.Text = "Find";
		this.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.toolStripMenuItem1, this.toolStripMenuItem4, this.toolStripMenuItem5 });
		base.Size = new System.Drawing.Size(135, 136);
		base.ResumeLayout(false);
	}
}
