using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraExport;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Export;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using IDAT.Devexpress.Properties;

namespace IDAT.Devexpress.GRID;

public class IDAT_XtraUserContext : ContextMenuStrip
{
	private ArrayList aryOrgHiddenField = null;

	private ArrayList aryOrgReadonly = null;

	private ImageList imgListIcon = new ImageList();

	private ProgressWindow pw = null;

	private GridView m_GridView = null;

	private string m_ParentForm = null;

	private IContainer components = null;

	private ToolStripMenuItem toolStripMenuItem1;

	private ToolStripMenuItem toolStripMenuItem2;

	private ToolStripMenuItem toolStripMenuItem3;

	private ToolStripMenuItem toolStripMenuItem4;

	private ToolStripMenuItem toolStripMenuItem5;

	private ToolStripMenuItem toolStripMenuItem6;

	private ToolStripMenuItem toolStripMenuItem7;

	private ToolStripMenuItem toolStripMenuItem8;

	private ToolStripMenuItem toolStripMenuItem9;

	private ToolStripMenuItem toolStripMenuItem10;

	private ToolStripMenuItem toolStripMenuItem11;

	private ToolStripMenuItem toolStripMenuItem12;

	private ToolStripMenuItem toolStripMenuItem13;

	private ToolStripMenuItem toolStripMenuItem14;

	private ToolStripMenuItem toolStripMenuItem15;

	private ToolStripMenuItem toolStripMenuItem16;

	private ToolStripMenuItem toolStripMenuItem17;

	private ToolStripMenuItem toolStripMenuItem18;

	private ToolStripMenuItem toolStripMenuItem19;

	private ToolStripMenuItem toolStripMenuItem20;

	private ToolStripMenuItem toolStripMenuItem21;

	private ToolStripMenuItem toolStripMenuItem22;

	private ToolStripMenuItem toolStripMenuItem23;

	private ToolStripMenuItem toolStripMenuItem24;

	private ToolStripMenuItem toolStripMenuItem_CHK;

	private ToolStripMenuItem toolStripMenuItem_UNCHK;

	private ToolStripSeparator toolStripSeparator1;

	public GridView GridView
	{
		get
		{
			return m_GridView;
		}
		set
		{
			aryOrgHiddenField = new ArrayList();
			aryOrgReadonly = new ArrayList();
			m_GridView = value;
			GridView.Images = imgListIcon;
			m_GridView.KeyDown += m_GridView_KeyDown;
			foreach (GridColumn column in value.Columns)
			{
				column.ImageAlignment = StringAlignment.Far;
				if (value.OptionsBehavior.Editable)
				{
					if (!column.OptionsColumn.AllowEdit)
					{
						aryOrgReadonly.Add(column.FieldName);
					}
					else
					{
						column.ImageIndex = 0;
					}
				}
				if (!column.Visible)
				{
					aryOrgHiddenField.Add(column.FieldName);
				}
			}
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

	private void m_GridView_KeyDown(object sender, KeyEventArgs e)
	{
		Keys keyCode = e.KeyCode;
		if (keyCode == Keys.F && e.Control && !e.Control)
		{
		}
	}

	public IDAT_XtraUserContext()
	{
		InitializeComponent();
		base.ItemClicked += IDAT_XtraUserContext_ItemClicked;
		base.Opening += IDAT_XtraUserContext_Opening;
		toolStripMenuItem1.DropDownItemClicked += IDAT_XtraUserContext_ItemClicked;
		toolStripMenuItem2.DropDownItemClicked += IDAT_XtraUserContext_ItemClicked;
		toolStripMenuItem3.DropDownItemClicked += IDAT_XtraUserContext_ItemClicked;
		toolStripMenuItem4.DropDownItemClicked += IDAT_XtraUserContext_ItemClicked;
		toolStripMenuItem20.DropDownItemClicked += IDAT_XtraUserContext_ItemClicked;
		toolStripMenuItem24.DropDownItemClicked += IDAT_XtraUserContext_ItemClicked;
		imgListIcon.Images.Add(Resources.coledit);
		imgListIcon.Images.Add(Resources._lock);
		imgListIcon.Images.Add(Resources.unlock);
	}

	public IDAT_XtraUserContext(GridView gridView, string parentForm)
		: this()
	{
		GridView = gridView;
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

	protected override void OnOpened(EventArgs e)
	{
		bool flag = false;
		foreach (GridColumn column in GridView.Columns)
		{
			if (column.FieldName == "CHK")
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			toolStripMenuItem_CHK.Visible = true;
			toolStripMenuItem_UNCHK.Visible = true;
			toolStripSeparator1.Visible = true;
		}
		else
		{
			toolStripMenuItem_CHK.Visible = false;
			toolStripMenuItem_UNCHK.Visible = false;
			toolStripSeparator1.Visible = false;
		}
		base.OnOpened(e);
	}

	private void IDAT_XtraUserContext_Opening(object sender, CancelEventArgs e)
	{
		try
		{
			if (GridView.GetFocusedRow() != null)
			{
				if (GridView.GetSelectedCells()[0].Column.OptionsColumn.AllowEdit)
				{
					toolStripMenuItem19.Image = Resources.unlock;
				}
				else
				{
					toolStripMenuItem19.Image = Resources._lock;
				}
			}
		}
		catch
		{
		}
	}

	private void IDAT_XtraUserContext_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
	{
		string text = null;
		switch (e.ClickedItem.Tag.ToString())
		{
		case "CHK":
			try
			{
				int[] selectedRows = GridView.GetSelectedRows();
				if (selectedRows.Length != 0)
				{
					int[] array = selectedRows;
					foreach (int rowHandle in array)
					{
						GridView.GetDataRow(rowHandle)["CHK"] = true;
					}
				}
				break;
			}
			catch (Exception)
			{
				break;
			}
		case "UNCHK":
			try
			{
				int[] selectedRows = GridView.GetSelectedRows();
				if (selectedRows.Length != 0)
				{
					int[] array = selectedRows;
					foreach (int rowHandle in array)
					{
						GridView.GetDataRow(rowHandle)["CHK"] = false;
					}
				}
				break;
			}
			catch (Exception)
			{
				break;
			}
		case "A-1":
			Close();
			text = ShowExportFileMessage("xls");
			if (text != null)
			{
				string text2 = text;
				ExportXlsProvider provider = new ExportXlsProvider(text2);
				GridViewExportLink gridViewExportLink = GridView.CreateExportLink(provider) as GridViewExportLink;
				gridViewExportLink.ExportCellsAsDisplayText = false;
				gridViewExportLink.Progress += link_Progress;
				pw = new ProgressWindow();
				pw.StartPosition = FormStartPosition.CenterScreen;
				pw.Show();
				gridViewExportLink.ExportTo(doCommit: true);
				pw.Close();
				pw.Dispose();
				pw = null;
				ShowOpenFileMessage(text);
			}
			break;
		case "A-2":
			Close();
			text = ShowExportFileMessage("html");
			if (text != null)
			{
				GridView.ExportToHtml(text);
				ShowOpenFileMessage(text);
			}
			break;
		case "A-3":
			Close();
			text = ShowExportFileMessage("htm");
			if (text != null)
			{
				GridView.ExportToExcelOld(text);
				ShowOpenFileMessage(text);
			}
			break;
		case "A-4":
			Close();
			text = ShowExportFileMessage("pdf");
			if (text != null)
			{
				GridView.ExportToPdf(text);
				ShowOpenFileMessage(text);
			}
			break;
		case "A-5":
			Close();
			text = ShowExportFileMessage("txt");
			if (text != null)
			{
				GridView.ExportToText(text);
				ShowOpenFileMessage(text);
			}
			break;
		case "A-6":
			Close();
			text = ShowExportFileMessage("txt");
			if (text != null)
			{
				GridView.ExportToTextOld(text);
				ShowOpenFileMessage(text);
			}
			break;
		case "A-7":
			Close();
			text = ShowExportFileMessage("xls");
			if (text != null)
			{
				string text2 = text;
				GridView.PrintExportProgress += GridView_PrintExportProgress;
				pw = new ProgressWindow();
				pw.StartPosition = FormStartPosition.CenterScreen;
				pw.Show();
				GridView.ExportToXls(text);
				ShowOpenFileMessage(text);
			}
			break;
		case "A-8":
			Close();
			text = ShowExportFileMessage("xlsx");
			if (text != null)
			{
				string text2 = text;
				GridView.PrintExportProgress += GridView_PrintExportProgress;
				pw = new ProgressWindow();
				pw.StartPosition = FormStartPosition.CenterScreen;
				pw.Show();
				GridView.ExportToXlsx(text);
				ShowOpenFileMessage(text);
			}
			break;
		case "B":
			break;
		case "B-1":
			Close();
			GridView.SelectAll();
			GridView.CopyToClipboard();
			break;
		case "B-2":
		{
			Close();
			int[] selectedRows2 = GridView.GetSelectedRows();
			StringBuilder stringBuilder = new StringBuilder();
			int[] array = selectedRows2;
			foreach (int rowHandle2 in array)
			{
				for (int j = 0; j < GridView.Columns.Count; j++)
				{
					stringBuilder.Append($"{GridView.GetDataRow(rowHandle2)[j]}\t");
				}
				stringBuilder.Append(Environment.NewLine);
			}
			Clipboard.SetDataObject(stringBuilder.ToString());
			break;
		}
		case "B-3":
			Close();
			Clipboard.SetDataObject(GridView.GetFocusedValue());
			break;
		case "C":
			break;
		case "C-1":
		{
			Close();
			ArrayList arrayList = new ArrayList();
			{
				foreach (GridColumn column in GridView.Columns)
				{
					if (!column.Visible && !aryOrgHiddenField.Contains(column.FieldName))
					{
						arrayList.Add(column.FieldName.ToString() + ":" + column.Caption);
					}
				}
				break;
			}
		}
		case "C-2":
		{
			Close();
			GridCell[] selectedCells = GridView.GetSelectedCells();
			foreach (GridCell gridCell in selectedCells)
			{
				gridCell.Column.Visible = false;
			}
			break;
		}
		case "C-3":
		{
			Close();
			GridCell[] selectedCells = GridView.GetSelectedCells();
			foreach (GridCell gridCell in selectedCells)
			{
				if (gridCell.Column.OptionsColumn.AllowEdit)
				{
					gridCell.Column.OptionsColumn.AllowEdit = false;
				}
				else if (!aryOrgReadonly.Contains(gridCell.Column.FieldName))
				{
					gridCell.Column.OptionsColumn.AllowEdit = true;
				}
			}
			break;
		}
		case "C-4-1":
		{
			GridCell[] selectedCells = GridView.GetSelectedCells();
			foreach (GridCell gridCell in selectedCells)
			{
				GridView.Columns[gridCell.Column.FieldName].Fixed = FixedStyle.Left;
			}
			break;
		}
		case "C-4-2":
		{
			GridCell[] selectedCells = GridView.GetSelectedCells();
			foreach (GridCell gridCell in selectedCells)
			{
				GridView.Columns[gridCell.Column.FieldName].Fixed = FixedStyle.Right;
			}
			break;
		}
		case "C-4-3":
		{
			GridCell[] selectedCells = GridView.GetSelectedCells();
			foreach (GridCell gridCell in selectedCells)
			{
				GridView.Columns[gridCell.Column.FieldName].Fixed = FixedStyle.None;
			}
			break;
		}
		case "D":
			break;
		case "E":
			try
			{
				PrintingSystem ps = new PrintingSystem();
				PrintableComponentLink printableComponentLink = new PrintableComponentLink(ps);
				printableComponentLink.Component = GridView.GridControl;
				PrintableComponentLink printableComponentLink2 = printableComponentLink;
				printableComponentLink2.CreateDocument();
				PageHeaderFooter pageHeaderFooter = printableComponentLink2.PageHeaderFooter as PageHeaderFooter;
				pageHeaderFooter.Header.Font = new Font("굴림체", 9f, FontStyle.Bold);
				pageHeaderFooter.Footer.Font = new Font("굴림체", 9f);
				pageHeaderFooter.Header.Content.Clear();
				pageHeaderFooter.Footer.Content.Clear();
				string text3 = "";
				string text4 = "";
				string text5 = "";
				string text6 = "출력일 : [Date Printed][Time Printed]";
				string text7 = "페이지 : [Page # of Pages #]";
				string text8 = "";
				pageHeaderFooter.Header.Content.AddRange(new string[3] { text3, text4, text5 });
				pageHeaderFooter.Footer.Content.AddRange(new string[3] { text6, text7, text8 });
				pageHeaderFooter.Header.LineAlignment = BrickAlignment.Far;
				pageHeaderFooter.Footer.LineAlignment = BrickAlignment.Far;
				Margins margins = new Margins();
				margins.Top = 50;
				margins.Bottom = 50;
				margins.Left = 20;
				margins.Right = 20;
				printableComponentLink2.PrintingSystem.PageSettings.Assign(margins, PaperKind.A4, landscape: false);
				printableComponentLink2.PrintingSystem.Document.AutoFitToPagesWidth = 1;
				printableComponentLink2.ShowPreview();
				break;
			}
			catch (Exception)
			{
				break;
			}
		case "F":
			MessageBox.Show(Application.StartupPath + "\\DefaultGridLayout\\" + m_ParentForm + "_" + GridView.GridControl.Name + ".xml");
			if (Directory.Exists(Application.StartupPath + "\\DefaultGridLayout") && File.Exists(Application.StartupPath + "\\DefaultGridLayout\\" + m_ParentForm + "_" + GridView.GridControl.Name + ".xml"))
			{
				MessageBox.Show(Application.StartupPath + "\\DefaultGridLayout\\" + m_ParentForm + "_" + GridView.GridControl.Name + ".xml");
				GridView.BeginUpdate();
				GridView.RestoreLayoutFromXml(Application.StartupPath + "\\DefaultGridLayout\\" + m_ParentForm + "_" + GridView.GridControl.Name + ".xml");
				GridView.EndUpdate();
			}
			break;
		}
	}

	private void GridView_PrintExportProgress(object sender, ProgressChangedEventArgs e)
	{
		pw.SetProgress(e.ProgressPercentage);
	}

	private void link_Progress(object sender, DevExpress.XtraGrid.Export.ProgressEventArgs e)
	{
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IDAT.Devexpress.GRID.IDAT_XtraUserContext));
		this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem20 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem21 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem22 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem23 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem24 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem_CHK = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem_UNCHK = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		base.SuspendLayout();
		this.toolStripMenuItem5.Name = "toolStripMenuItem5";
		this.toolStripMenuItem5.Size = new System.Drawing.Size(134, 22);
		this.toolStripMenuItem5.Tag = "E";
		this.toolStripMenuItem5.Text = "Print";
		this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[8] { this.toolStripMenuItem12, this.toolStripMenuItem6, this.toolStripMenuItem13, this.toolStripMenuItem7, this.toolStripMenuItem8, this.toolStripMenuItem9, this.toolStripMenuItem10, this.toolStripMenuItem11 });
		this.toolStripMenuItem1.Name = "toolStripMenuItem1";
		this.toolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
		this.toolStripMenuItem1.Tag = "A";
		this.toolStripMenuItem1.Text = "Export";
		this.toolStripMenuItem12.Name = "toolStripMenuItem12";
		this.toolStripMenuItem12.Size = new System.Drawing.Size(124, 22);
		this.toolStripMenuItem12.Tag = "A-7";
		this.toolStripMenuItem12.Text = "xls";
		this.toolStripMenuItem6.Name = "toolStripMenuItem6";
		this.toolStripMenuItem6.Size = new System.Drawing.Size(124, 22);
		this.toolStripMenuItem6.Tag = "A-1";
		this.toolStripMenuItem6.Text = "Excel Old";
		this.toolStripMenuItem13.Name = "toolStripMenuItem13";
		this.toolStripMenuItem13.Size = new System.Drawing.Size(124, 22);
		this.toolStripMenuItem13.Tag = "A-8";
		this.toolStripMenuItem13.Text = "xlsx";
		this.toolStripMenuItem7.Name = "toolStripMenuItem7";
		this.toolStripMenuItem7.Size = new System.Drawing.Size(124, 22);
		this.toolStripMenuItem7.Tag = "A-2";
		this.toolStripMenuItem7.Text = "Html";
		this.toolStripMenuItem8.Name = "toolStripMenuItem8";
		this.toolStripMenuItem8.Size = new System.Drawing.Size(124, 22);
		this.toolStripMenuItem8.Tag = "A-3";
		this.toolStripMenuItem8.Text = "Html Old";
		this.toolStripMenuItem9.Name = "toolStripMenuItem9";
		this.toolStripMenuItem9.Size = new System.Drawing.Size(124, 22);
		this.toolStripMenuItem9.Tag = "A-4";
		this.toolStripMenuItem9.Text = "pdf";
		this.toolStripMenuItem10.Name = "toolStripMenuItem10";
		this.toolStripMenuItem10.Size = new System.Drawing.Size(124, 22);
		this.toolStripMenuItem10.Tag = "A-5";
		this.toolStripMenuItem10.Text = "Text";
		this.toolStripMenuItem11.Name = "toolStripMenuItem11";
		this.toolStripMenuItem11.Size = new System.Drawing.Size(124, 22);
		this.toolStripMenuItem11.Tag = "A-6";
		this.toolStripMenuItem11.Text = "Text Old";
		this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.toolStripMenuItem14, this.toolStripMenuItem15, this.toolStripMenuItem16 });
		this.toolStripMenuItem2.Name = "toolStripMenuItem2";
		this.toolStripMenuItem2.Size = new System.Drawing.Size(134, 22);
		this.toolStripMenuItem2.Tag = "B";
		this.toolStripMenuItem2.Text = "Copy";
		this.toolStripMenuItem14.Name = "toolStripMenuItem14";
		this.toolStripMenuItem14.Size = new System.Drawing.Size(128, 22);
		this.toolStripMenuItem14.Tag = "B-1";
		this.toolStripMenuItem14.Text = "All Copy";
		this.toolStripMenuItem15.Name = "toolStripMenuItem15";
		this.toolStripMenuItem15.Size = new System.Drawing.Size(128, 22);
		this.toolStripMenuItem15.Tag = "B-2";
		this.toolStripMenuItem15.Text = "Line Copy";
		this.toolStripMenuItem16.Name = "toolStripMenuItem16";
		this.toolStripMenuItem16.Size = new System.Drawing.Size(128, 22);
		this.toolStripMenuItem16.Tag = "B-3";
		this.toolStripMenuItem16.Text = "Cell Copy";
		this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.toolStripMenuItem17, this.toolStripMenuItem18, this.toolStripMenuItem19, this.toolStripMenuItem20 });
		this.toolStripMenuItem3.Name = "toolStripMenuItem3";
		this.toolStripMenuItem3.Size = new System.Drawing.Size(134, 22);
		this.toolStripMenuItem3.Tag = "C";
		this.toolStripMenuItem3.Text = "Columns";
		this.toolStripMenuItem3.Visible = false;
		this.toolStripMenuItem17.Name = "toolStripMenuItem17";
		this.toolStripMenuItem17.Size = new System.Drawing.Size(120, 22);
		this.toolStripMenuItem17.Tag = "C-1";
		this.toolStripMenuItem17.Text = "Show";
		this.toolStripMenuItem18.Name = "toolStripMenuItem18";
		this.toolStripMenuItem18.Size = new System.Drawing.Size(120, 22);
		this.toolStripMenuItem18.Tag = "C-2";
		this.toolStripMenuItem18.Text = "Hide";
		this.toolStripMenuItem19.Name = "toolStripMenuItem19";
		this.toolStripMenuItem19.Size = new System.Drawing.Size(120, 22);
		this.toolStripMenuItem19.Tag = "C-3";
		this.toolStripMenuItem19.Text = "lock Edit";
		this.toolStripMenuItem20.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.toolStripMenuItem21, this.toolStripMenuItem22, this.toolStripMenuItem23 });
		this.toolStripMenuItem20.Name = "toolStripMenuItem20";
		this.toolStripMenuItem20.Size = new System.Drawing.Size(120, 22);
		this.toolStripMenuItem20.Tag = "C-4";
		this.toolStripMenuItem20.Text = "Fixed";
		this.toolStripMenuItem21.Name = "toolStripMenuItem21";
		this.toolStripMenuItem21.Size = new System.Drawing.Size(103, 22);
		this.toolStripMenuItem21.Tag = "C-4-1";
		this.toolStripMenuItem21.Text = "Left";
		this.toolStripMenuItem22.Name = "toolStripMenuItem22";
		this.toolStripMenuItem22.Size = new System.Drawing.Size(103, 22);
		this.toolStripMenuItem22.Tag = "C-4-2";
		this.toolStripMenuItem22.Text = "Right";
		this.toolStripMenuItem23.Name = "toolStripMenuItem23";
		this.toolStripMenuItem23.Size = new System.Drawing.Size(103, 22);
		this.toolStripMenuItem23.Tag = "C-4-3";
		this.toolStripMenuItem23.Text = "None";
		this.toolStripMenuItem4.Name = "toolStripMenuItem4";
		this.toolStripMenuItem4.Size = new System.Drawing.Size(134, 22);
		this.toolStripMenuItem4.Tag = "D";
		this.toolStripMenuItem4.Text = "Find";
		this.toolStripMenuItem24.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem24.Image");
		this.toolStripMenuItem24.Name = "toolStripMenuItem24";
		this.toolStripMenuItem24.Size = new System.Drawing.Size(134, 22);
		this.toolStripMenuItem24.Tag = "F";
		this.toolStripMenuItem24.Text = "Layout Init.";
		this.toolStripMenuItem_CHK.Name = "toolStripMenuItem_CHK";
		this.toolStripMenuItem_CHK.Size = new System.Drawing.Size(134, 22);
		this.toolStripMenuItem_CHK.Tag = "CHK";
		this.toolStripMenuItem_CHK.Text = "check";
		this.toolStripMenuItem_CHK.Visible = false;
		this.toolStripMenuItem_UNCHK.Name = "toolStripMenuItem_UNCHK";
		this.toolStripMenuItem_UNCHK.Size = new System.Drawing.Size(134, 22);
		this.toolStripMenuItem_UNCHK.Tag = "UNCHK";
		this.toolStripMenuItem_UNCHK.Text = "uncheck";
		this.toolStripMenuItem_UNCHK.Visible = false;
		this.toolStripSeparator1.Name = "toolStripSeparator1";
		this.toolStripSeparator1.Size = new System.Drawing.Size(6, 6);
		this.toolStripSeparator1.Visible = false;
		this.Items.AddRange(new System.Windows.Forms.ToolStripItem[9] { this.toolStripMenuItem_CHK, this.toolStripMenuItem_UNCHK, this.toolStripSeparator1, this.toolStripMenuItem1, this.toolStripMenuItem2, this.toolStripMenuItem3, this.toolStripMenuItem4, this.toolStripMenuItem5, this.toolStripMenuItem24 });
		base.Size = new System.Drawing.Size(135, 180);
		base.ResumeLayout(false);
	}
}
