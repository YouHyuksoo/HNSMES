using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraExport;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Export;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPrinting;

namespace IDAT.Devexpress.GRID;

public class IDATDevExpress_GridControl
{
	internal void GridControlPrintPreView(GridControl gc)
	{
		try
		{
			PrintingSystem ps = new PrintingSystem();
			PrintableComponentLink printableComponentLink = new PrintableComponentLink(ps);
			printableComponentLink.Component = gc;
			PrintableComponentLink printableComponentLink2 = printableComponentLink;
			printableComponentLink2.CreateDocument();
			Margins margins = new Margins();
			margins.Top = 45;
			margins.Bottom = 45;
			margins.Left = 45;
			margins.Right = 45;
			printableComponentLink2.PrintingSystem.PageSettings.Assign(margins, PaperKind.A4, landscape: false);
			printableComponentLink2.PrintingSystem.Document.AutoFitToPagesWidth = 1;
			printableComponentLink2.ShowPreview();
		}
		catch (Exception)
		{
			throw;
		}
	}

	internal void GridControlPrintPreView(GridControl gc, string sCaption, bool landscape, string sUserName, string sUserId, string sPrintName)
	{
		try
		{
			PrintingSystem ps = new PrintingSystem();
			PrintableComponentLink printableComponentLink = new PrintableComponentLink(ps);
			printableComponentLink.Component = gc;
			PrintableComponentLink printableComponentLink2 = printableComponentLink;
			PageHeaderFooter pageHeaderFooter = printableComponentLink2.PageHeaderFooter as PageHeaderFooter;
			pageHeaderFooter.Header.Font = new Font("돋움", 13f, FontStyle.Bold);
			pageHeaderFooter.Footer.Font = new Font("돋움", 10f);
			pageHeaderFooter.Header.Content.Clear();
			pageHeaderFooter.Footer.Content.Clear();
			string text = "● 문서명 : " + sCaption;
			string text2 = "";
			string text3 = "";
			string text4 = "출력일 : [Date Printed][Time Printed]";
			string text5 = "페이지 : [Page # of Pages #]";
			string text6 = "사용자 : " + sUserName + " (" + sUserId + ")";
			pageHeaderFooter.Header.Content.AddRange(new string[3] { text, text2, text3 });
			pageHeaderFooter.Footer.Content.AddRange(new string[3] { text4, text5, text6 });
			pageHeaderFooter.Header.LineAlignment = BrickAlignment.Far;
			pageHeaderFooter.Footer.LineAlignment = BrickAlignment.Near;
			Margins margins = new Margins();
			margins.Top = 45;
			margins.Bottom = 45;
			margins.Left = 45;
			margins.Right = 45;
			printableComponentLink2.CreateDocument();
			printableComponentLink2.PrintingSystem.PageSettings.Assign(margins, PaperKind.A4, landscape);
			printableComponentLink2.PrintingSystem.Document.AutoFitToPagesWidth = 1;
			printableComponentLink2.Print(sPrintName);
		}
		catch (Exception)
		{
			throw;
		}
	}

	public string SetGridLayoutFolder()
	{
		if (!Directory.Exists(Application.StartupPath + "\\GridLayout"))
		{
			Directory.CreateDirectory(Application.StartupPath + "\\GridLayout");
		}
		if (!Directory.Exists(Application.StartupPath + "\\DefaultGridLayout"))
		{
			Directory.CreateDirectory(Application.StartupPath + "\\DefaultGridLayout");
		}
		return Application.StartupPath + "\\DefaultGridLayout";
	}

	public void InitialGridLayout()
	{
		string[] files = Directory.GetFiles(Application.StartupPath + "\\GridLayout");
		foreach (string path in files)
		{
			File.Delete(path);
		}
		files = Directory.GetFiles(Application.StartupPath + "\\DefaultGridLayout");
		foreach (string path in files)
		{
			File.Delete(path);
		}
	}

	public void SaveGridLayouts(Control pctl, string _FormName)
	{
		SetGridLayoutFolder();
		if (pctl is GridControl)
		{
			SaveGridLayout(pctl, _FormName);
			return;
		}
		foreach (Control control in pctl.Controls)
		{
			if (control is GridControl)
			{
				SaveGridLayout(control, _FormName);
				continue;
			}
			if (control.Controls.Count > 0)
			{
				SaveGridLayouts(control, _FormName);
			}
			SaveGridLayout(control, _FormName);
		}
	}

	public void LoadGridLayouts(Control pctl, string _FormName)
	{
		if (pctl is GridControl)
		{
			LoadGridLayout(pctl, _FormName);
			return;
		}
		foreach (Control control in pctl.Controls)
		{
			if (control is GridControl)
			{
				LoadGridLayout(control, _FormName);
				continue;
			}
			if (control.Controls.Count > 0)
			{
				LoadGridLayouts(control, _FormName);
			}
			LoadGridLayout(control, _FormName);
		}
	}

	private void SaveGridLayout(Control ctl, string _FormName)
	{
		SetGridLayoutFolder();
		if (ctl is GridControl)
		{
			GridControl gridControl = ctl as GridControl;
			gridControl.Views[0].SaveLayoutToXml(Application.StartupPath + "\\GridLayout\\" + _FormName + "_" + gridControl.Name + ".xml");
		}
	}

	private void LoadGridLayout(Control ctl, string _FormName)
	{
		if (ctl is GridControl)
		{
			GridControl gridControl = ctl as GridControl;
			if (File.Exists(Application.StartupPath + "\\GridLayout\\" + _FormName + "_" + gridControl.Name + ".xml"))
			{
				gridControl.BeginUpdate();
				gridControl.Views[0].RestoreLayoutFromXml(Application.StartupPath + "\\GridLayout\\" + _FormName + "_" + gridControl.Name + ".xml");
				GridView gridView = gridControl.Views[0] as GridView;
				gridView.ClearColumnsFilter();
				gridControl.EndUpdate();
			}
		}
	}

	public void SaveDefaultGridLayouts(Control pctl, string _FormName)
	{
		if (pctl is GridControl)
		{
			SaveDefaultGridLayout(pctl, _FormName);
			return;
		}
		foreach (Control control in pctl.Controls)
		{
			if (control is GridControl)
			{
				SaveDefaultGridLayout(control, _FormName);
				continue;
			}
			if (control.Controls.Count > 0)
			{
				SaveDefaultGridLayouts(control, _FormName);
			}
			SaveDefaultGridLayout(control, _FormName);
		}
	}

	private void SaveDefaultGridLayout(Control ctl, string _FormName)
	{
		if (ctl is GridControl)
		{
			GridControl gridControl = ctl as GridControl;
			gridControl.Views[0].SaveLayoutToXml(Application.StartupPath + "\\DefaultGridLayout\\" + _FormName + "_" + gridControl.Name + ".xml");
		}
	}

	public void LoadDefaultGridLayout(Control ctl, string _FormName)
	{
		if (ctl is GridControl)
		{
			GridControl gridControl = ctl as GridControl;
			if (File.Exists(Application.StartupPath + "\\DefaultGridLayout\\" + _FormName + "_" + gridControl.Name + ".xml"))
			{
				gridControl.BeginUpdate();
				gridControl.Views[0].RestoreLayoutFromXml(Application.StartupPath + "\\DefaultGridLayout\\" + _FormName + "_" + gridControl.Name + ".xml");
				GridView gridView = gridControl.Views[0] as GridView;
				gridView.ClearColumnsFilter();
				gridControl.EndUpdate();
			}
		}
	}

	public StyleFormatCondition SetStyleFormatCondition(GridView gridView, string columnFieldString, object value1, object value2, Color fontColor, Color backColor)
	{
		StyleFormatCondition styleFormatCondition = new StyleFormatCondition();
		Font font = gridView.Appearance.Row.Font.Clone() as Font;
		styleFormatCondition.Appearance.Options.UseForeColor = true;
		styleFormatCondition.Appearance.Font = new Font(font.FontFamily, font.Size);
		styleFormatCondition.Appearance.ForeColor = fontColor;
		styleFormatCondition.Appearance.BackColor = backColor;
		styleFormatCondition.Appearance.Options.UseBackColor = true;
		styleFormatCondition.Appearance.Options.UseFont = true;
		styleFormatCondition.ApplyToRow = true;
		styleFormatCondition.Column = gridView.Columns[columnFieldString];
		styleFormatCondition.Condition = FormatConditionEnum.Equal;
		styleFormatCondition.Value1 = value1;
		styleFormatCondition.Value2 = value2;
		gridView.FormatConditions.Add(styleFormatCondition);
		return styleFormatCondition;
	}

	public StyleFormatCondition SetStyleFormatCondition(GridView gridView, string columnFieldString, object value1, object value2, bool blnUseYN)
	{
		StyleFormatCondition styleFormatCondition = new StyleFormatCondition();
		Font font = gridView.Appearance.Row.Font.Clone() as Font;
		bool flag = blnUseYN;
		if (flag)
		{
			styleFormatCondition.Appearance.Font = new Font(font.FontFamily, font.Size, FontStyle.Strikeout);
			styleFormatCondition.Appearance.ForeColor = Color.Gray;
			styleFormatCondition.Appearance.Options.UseFont = true;
			styleFormatCondition.Appearance.Options.UseForeColor = true;
			styleFormatCondition.ApplyToRow = true;
			styleFormatCondition.Column = gridView.Columns[columnFieldString];
			styleFormatCondition.Condition = FormatConditionEnum.Equal;
			styleFormatCondition.Value1 = value1;
			styleFormatCondition.Value2 = value2;
		}
		else
		{
			styleFormatCondition.Appearance.Font = new Font(font.FontFamily, font.Size, FontStyle.Underline);
			styleFormatCondition.Appearance.BackColor = Color.MistyRose;
			styleFormatCondition.Appearance.Options.UseBackColor = true;
			styleFormatCondition.Appearance.Options.UseFont = true;
			styleFormatCondition.ApplyToRow = true;
			styleFormatCondition.Column = gridView.Columns[columnFieldString];
			styleFormatCondition.Condition = FormatConditionEnum.Equal;
			styleFormatCondition.Value1 = value1;
			styleFormatCondition.Value2 = value2;
		}
		gridView.FormatConditions.Add(styleFormatCondition);
		return styleFormatCondition;
	}

	public void SetTotalSummaryItems(GridView gridview, string columnFieldString, SummaryItemType summaryType)
	{
		gridview.Columns[columnFieldString].SummaryItem.SummaryType = summaryType;
		gridview.Columns[columnFieldString].SummaryItem.DisplayFormat = summaryType.ToString() + " : {0}";
	}

	public void SetTotalSummaryItems(GridView gridview, string columnFieldString, SummaryItemType summaryType, string displayFormat)
	{
		gridview.Columns[columnFieldString].SummaryItem.SummaryType = summaryType;
		gridview.Columns[columnFieldString].SummaryItem.DisplayFormat = displayFormat;
	}

	public void SetTotalSummaryItems(GridView gridview, int Idx, SummaryItemType summaryType)
	{
		gridview.Columns[Idx].SummaryItem.SummaryType = summaryType;
		gridview.Columns[Idx].SummaryItem.DisplayFormat = summaryType.ToString() + " : {0}";
	}

	public void SetTotalSummaryItems(GridView gridview, int Idx, SummaryItemType summaryType, string displayFormat)
	{
		gridview.Columns[Idx].SummaryItem.SummaryType = summaryType;
		gridview.Columns[Idx].SummaryItem.DisplayFormat = displayFormat;
	}

	public void SetTotalSummaryItems(GridView gridview, string[] columnFields, SummaryItemType[] summaryTypes)
	{
		if (columnFields.Length != 0 && summaryTypes.Length != 0 && columnFields.Length == summaryTypes.Length)
		{
			for (int i = 0; i < columnFields.Length; i++)
			{
				gridview.Columns[columnFields[i]].SummaryItem.SummaryType = summaryTypes[i];
				gridview.Columns[columnFields[i]].SummaryItem.DisplayFormat = summaryTypes[i].ToString() + " : {0}";
			}
		}
	}

	public void SetTotalSummaryItems(GridView gridview, int[] columnIndexs, SummaryItemType[] summaryTypes)
	{
		if (columnIndexs.Length != 0 && summaryTypes.Length != 0 && columnIndexs.Length == summaryTypes.Length)
		{
			for (int i = 0; i < columnIndexs.Length; i++)
			{
				gridview.Columns[columnIndexs[i]].SummaryItem.SummaryType = summaryTypes[i];
				gridview.Columns[columnIndexs[i]].SummaryItem.DisplayFormat = summaryTypes[i].ToString() + " : {0}";
			}
		}
	}

	public void SetIDIFExtendGridView(GridControl grid, GridView gridView, string parentForm)
	{
		grid.ContextMenuStrip = new IDAT_XtraUserContext(gridView, parentForm);
		gridView.OptionsSelection.MultiSelect = true;
		gridView.OptionsSelection.EnableAppearanceFocusedCell = true;
		gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
	}

	public void SetIDIFExtendPivotGrid(PivotGridControl grid, string parentForm)
	{
		grid.ContextMenuStrip = new IDAT_XtraPivotGridUserContext(grid, parentForm);
	}

	public EditorButton SetButtonAdd(ButtonEdit lookupCons, int width, Image image)
	{
		LookUpEditBase lookUpEditBase = lookupCons as LookUpEditBase;
		EditorButton editorButton = new EditorButton();
		editorButton.Kind = ButtonPredefines.Glyph;
		editorButton.Width = width;
		editorButton.Image = image;
		lookUpEditBase.Properties.Buttons.Add(editorButton);
		return editorButton;
	}

	public GridHitInfo GetClickHitInfo(GridView gridView, EventArgs e)
	{
		MouseEventArgs e2 = e as MouseEventArgs;
		Point pt = new Point(e2.X, e2.Y);
		GridHitInfo gridHitInfo = gridView.CalcHitInfo(pt);
		if (gridHitInfo != null)
		{
			return gridHitInfo;
		}
		return null;
	}

	public DataTable GetChangedData(GridControl gridCon)
	{
		if (gridCon.DataSource == null)
		{
			return new DataTable();
		}
		if (gridCon.Views.Count > 0 && gridCon.DefaultView is GridView)
		{
			(gridCon.DefaultView as GridView).FocusedRowHandle = -1;
		}
		DataTable changes = (gridCon.DataSource as DataTable).GetChanges();
		if (changes != null)
		{
			return changes;
		}
		return new DataTable();
	}

	public DataTable GetChangedData(GridControl gridCon, ref int newCnt, ref int editCnt, ref int delCnt)
	{
		if (gridCon.DataSource == null)
		{
			return new DataTable();
		}
		DataTable changes = (gridCon.DataSource as DataTable).GetChanges(DataRowState.Added);
		DataTable changes2 = (gridCon.DataSource as DataTable).GetChanges(DataRowState.Modified);
		DataTable changes3 = (gridCon.DataSource as DataTable).GetChanges(DataRowState.Deleted);
		newCnt = changes?.Rows.Count ?? 0;
		editCnt = changes2?.Rows.Count ?? 0;
		delCnt = changes3?.Rows.Count ?? 0;
		DataTable changes4 = (gridCon.DataSource as DataTable).GetChanges();
		if (changes4 != null)
		{
			return changes4;
		}
		return new DataTable();
	}

	public DataTable GetChangedData(GridControl gridCon, DataRowState state)
	{
		if (gridCon.DataSource == null)
		{
			return new DataTable();
		}
		DataTable changes = (gridCon.DataSource as DataTable).GetChanges(state);
		if (changes != null)
		{
			return changes;
		}
		return new DataTable();
	}

	public DataTable GetChangedData(GridControl gridCon, DataRowState state, ref int cnt)
	{
		if (gridCon.DataSource == null)
		{
			return new DataTable();
		}
		DataTable changes = (gridCon.DataSource as DataTable).GetChanges(state);
		if (changes != null)
		{
			cnt = changes.Rows.Count;
			return changes;
		}
		return new DataTable();
	}

	public void GetFocuseRowCell(GridView gridView, string columns, string strValue)
	{
		GridColumn gridColumn = gridView.Columns[columns];
		if (gridColumn != null)
		{
			int num = gridView.LocateByDisplayText(0, gridColumn, strValue);
			if (num != int.MinValue)
			{
				gridView.ClearSelection();
				gridView.FocusedRowHandle = num;
				gridView.FocusedColumn = gridColumn;
				gridView.SelectRow(num);
				gridView.TopRowIndex = gridView.GetVisibleIndex(num);
			}
		}
	}

	public void GetFocuseRowCell(GridView gridView, string[] columns, string[] strValue)
	{
		ArrayList arrayList = new ArrayList();
		int num = 0;
		int[] array = null;
		for (int i = 0; i < columns.Length; i++)
		{
			GridColumn column = gridView.Columns[columns[i]];
			ArrayList arrayList2 = new ArrayList();
			num = gridView.LocateByDisplayText(num, column, strValue[i]);
			if (num != int.MinValue)
			{
				arrayList2.Add(num);
			}
			array = (int[])arrayList2.ToArray(typeof(int));
			arrayList.Add(array);
		}
		int[] source = arrayList[0] as int[];
		IOrderedEnumerable<int> source2 = source.OrderByDescending((int d) => d);
		int[] array2 = source2.ToArray();
		for (int num2 = 1; num2 < arrayList.Count; num2++)
		{
			int[] second = arrayList[num2] as int[];
			IEnumerable<int> source3 = array2.Intersect(second);
			array2 = source3.ToArray();
		}
		num = 0;
		int[] array3 = array2;
		foreach (int num4 in array3)
		{
			if (num4 != 0)
			{
				num = num4;
			}
		}
		GridColumn focusedColumn = gridView.Columns[columns[0]];
		gridView.ClearSelection();
		gridView.FocusedRowHandle = num;
		gridView.FocusedColumn = focusedColumn;
		gridView.SelectRow(num);
		gridView.TopRowIndex = gridView.GetVisibleIndex(num);
	}

	public void AddNewRow(GridView gridviewCon)
	{
		gridviewCon.AddNewRow();
	}

	public void AddNewRow(GridView gridviewCon, string[] initColumn, object[] initValues)
	{
		gridviewCon.AddNewRow();
		try
		{
			for (int i = 0; i < initColumn.Length; i++)
			{
				gridviewCon.SetFocusedRowCellValue(initColumn[i], initValues[i]);
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public bool IDAT_XtraGridViewValidateChildrenColumnsHasErrors(GridView gridViewCon, string sValidateMsg, params string[] Columns)
	{
		if (gridViewCon.RowCount > 0)
		{
			for (int i = 0; i < gridViewCon.RowCount; i++)
			{
				foreach (string text in Columns)
				{
					if (gridViewCon.GetDataRow(i) != null)
					{
						if (gridViewCon.GetDataRow(i)[text] == DBNull.Value || string.Concat(gridViewCon.GetDataRow(i)[text]) == "")
						{
							gridViewCon.FocusedRowHandle = i;
							gridViewCon.SetColumnError(gridViewCon.Columns[text], sValidateMsg, ErrorType.Warning);
							return true;
						}
						gridViewCon.SetColumnError(gridViewCon.Columns[text], "", ErrorType.None);
						continue;
					}
					gridViewCon.FocusedRowHandle = i;
					gridViewCon.SetColumnError(gridViewCon.Columns[text], sValidateMsg, ErrorType.Warning);
					return true;
				}
			}
		}
		return false;
	}

	public bool IDAT_XtraGridViewValidateChildrenColumnsHasErrors(GridView gridViewCon, int rowidx, string sValidateMsg, params string[] Columns)
	{
		if (gridViewCon.RowCount > 0)
		{
			foreach (string text in Columns)
			{
				if (gridViewCon.GetDataRow(rowidx) != null)
				{
					if (gridViewCon.GetDataRow(rowidx)[text] == DBNull.Value || string.Concat(gridViewCon.GetDataRow(rowidx)[text]) == "")
					{
						gridViewCon.FocusedRowHandle = rowidx;
						gridViewCon.SetColumnError(gridViewCon.Columns[text], sValidateMsg, ErrorType.Warning);
						return true;
					}
					gridViewCon.SetColumnError(gridViewCon.Columns[text], "", ErrorType.None);
					continue;
				}
				gridViewCon.FocusedRowHandle = rowidx;
				gridViewCon.SetColumnError(gridViewCon.Columns[text], sValidateMsg, ErrorType.Warning);
				return true;
			}
		}
		return false;
	}

	public void ExcelExportTo(GridView tmpGridView, string filename)
	{
		IExportProvider exportProvider = new ExportXlsProvider(filename);
		Cursor current = Cursor.Current;
		Cursor.Current = Cursors.WaitCursor;
		BaseExportLink baseExportLink = tmpGridView.CreateExportLink(exportProvider);
		(baseExportLink as GridViewExportLink).ExpandAll = false;
		baseExportLink.ExportTo(doCommit: true);
		exportProvider.Dispose();
		Cursor.Current = current;
	}

	public void TxtExportTo(GridView tmpGridView, string filename)
	{
		IExportProvider exportProvider = new ExportTxtProvider(filename);
		Cursor current = Cursor.Current;
		Cursor.Current = Cursors.WaitCursor;
		BaseExportLink baseExportLink = tmpGridView.CreateExportLink(exportProvider);
		(baseExportLink as GridViewExportLink).ExpandAll = false;
		baseExportLink.ExportTo(doCommit: true);
		exportProvider.Dispose();
		Cursor.Current = current;
	}

	public void XmlExportTo(GridView tmpGridView, string filename)
	{
		IExportProvider exportProvider = new ExportXmlProvider(filename);
		Cursor current = Cursor.Current;
		Cursor.Current = Cursors.WaitCursor;
		BaseExportLink baseExportLink = tmpGridView.CreateExportLink(exportProvider);
		(baseExportLink as GridViewExportLink).ExpandAll = false;
		baseExportLink.ExportTo(doCommit: true);
		exportProvider.Dispose();
		Cursor.Current = current;
	}

	public void HTMLExportTo(GridView tmpGridView, string filename)
	{
		IExportProvider exportProvider = new ExportHtmlProvider(filename);
		Cursor current = Cursor.Current;
		Cursor.Current = Cursors.WaitCursor;
		BaseExportLink baseExportLink = tmpGridView.CreateExportLink(exportProvider);
		(baseExportLink as GridViewExportLink).ExpandAll = false;
		baseExportLink.ExportTo(doCommit: true);
		exportProvider.Dispose();
		Cursor.Current = current;
	}

	public void PDFExportTo(GridView tmpGridView, string filename)
	{
		tmpGridView.ExportToPdf(filename);
	}

	public void RTFExportTo(GridView tmpGridView, string filename)
	{
		tmpGridView.ExportToRtf(filename);
	}
}
