using System;
using System.Drawing;
using System.Reflection;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Drawing;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace IDAT.Devexpress.ActionDemo;

public class ActiveGridDemo : ActiveDemo
{
	private GridControl fgridControl;

	public GridControl GridControl => fgridControl;

	public BaseView ActiveView => GridControl.DefaultView;

	public GridView ActiveGridView
	{
		get
		{
			if (ActiveView != null && ActiveView is GridView)
			{
				return ActiveView as GridView;
			}
			return null;
		}
	}

	public BandedGridView ActiveBandedGridView
	{
		get
		{
			if (ActiveView != null && ActiveView is BandedGridView)
			{
				return ActiveView as BandedGridView;
			}
			return null;
		}
	}

	public GridViewInfo ActiveGridViewInfo
	{
		get
		{
			if (ActiveGridView != null)
			{
				return GetGridViewInfo(ActiveGridView);
			}
			return null;
		}
	}

	public BandedGridViewInfo ActiveBandedGridViewInfo
	{
		get
		{
			if (ActiveBandedGridView != null)
			{
				PropertyInfo property = typeof(BandedGridView).GetProperty("ViewInfo");
				if (property != null)
				{
					return property.GetValue(ActiveGridView, null) as BandedGridViewInfo;
				}
				return null;
			}
			return null;
		}
	}

	public ActiveGridDemo(GridControl fgridControl)
	{
		this.fgridControl = fgridControl;
	}

	public void SelectCellByMouse(GridColumn column, int row)
	{
		if (!base.Actions.Canceled && column != null && column.VisibleIndex >= 0 && column.View is GridView)
		{
			GridView gridView = column.View as GridView;
			gridView.MakeColumnVisible(column);
			GridViewInfo gridViewInfo = GetGridViewInfo(gridView);
			GridCellInfo gridCellInfo = gridViewInfo.GetGridCellInfo(row, column);
			if (gridCellInfo != null)
			{
				Rectangle bounds = gridCellInfo.Bounds;
				base.Actions.MouseClick(fgridControl, new Point(bounds.Left + bounds.Width / 2, bounds.Top + bounds.Height / 2));
			}
		}
	}

	public void SelectCellByKeyBoard(GridColumn column, int row)
	{
		if (base.Actions.Canceled || column == null || column.VisibleIndex < 0 || !(column.View is GridView))
		{
			return;
		}
		GridView gridView = column.View as GridView;
		if (gridView.FocusedColumn == null)
		{
			SelectCellByMouse(column, row);
			return;
		}
		while (gridView.FocusedColumn != column)
		{
			if (base.Actions.Canceled)
			{
				return;
			}
			if (gridView.FocusedColumn.VisibleIndex < column.VisibleIndex)
			{
				base.Actions.SendString(GridControl, "[Right]");
			}
			else
			{
				base.Actions.SendString(GridControl, "[Left]");
			}
		}
		if (row <= -1 || row >= gridView.RowCount)
		{
			return;
		}
		while (GetFocusedRow(gridView) != row && !base.Actions.Canceled)
		{
			if (GetFocusedRow(gridView) > row)
			{
				base.Actions.SendString(GridControl, "[Up]");
			}
			else
			{
				base.Actions.SendString(GridControl, "[Down]");
			}
		}
	}

	public void ClickGridColumn(GridColumn column)
	{
		if (!base.Actions.Canceled && column != null && column.VisibleIndex >= 0 && column.View is GridView)
		{
			base.Actions.MouseClick(GridControl, GetColumnLocationAtCenter(column));
		}
	}

	public void MoveCellByMouse(GridColumn column, int row)
	{
		if (!base.Actions.Canceled && column != null && column.VisibleIndex >= 0 && column.View is GridView)
		{
			GridView gridView = column.View as GridView;
			gridView.MakeColumnVisible(column);
			GridViewInfo gridViewInfo = GetGridViewInfo(gridView);
			GridCellInfo gridCellInfo = gridViewInfo.GetGridCellInfo(row, column);
			if (gridCellInfo != null)
			{
				Rectangle bounds = gridCellInfo.Bounds;
				base.Actions.MoveMousePointTo(fgridControl, new Point(bounds.Left + bounds.Width / 2, bounds.Top + bounds.Height / 2));
			}
		}
	}

	public void GroupByColumn(GridColumn column)
	{
		GroupByColumn(column, column.View.SortInfo.GroupCount);
	}

	public void GroupByColumn(GridColumn column, int groupIndex)
	{
		if (!base.Actions.Canceled && column != null && column.VisibleIndex >= 0 && column.View is GridView)
		{
			GridView gridView = column.View as GridView;
			gridView.OptionsView.ShowGroupPanel = true;
			gridView.MakeColumnVisible(column);
			GridViewInfo gridViewInfo = GetGridViewInfo(gridView);
			if (groupIndex < 0)
			{
				groupIndex = 0;
			}
			if (groupIndex >= gridView.SortInfo.GroupCount)
			{
				groupIndex = gridView.SortInfo.GroupCount;
			}
			Rectangle groupPanel = gridViewInfo.ViewRects.GroupPanel;
			Point pt;
			if (groupIndex == 0)
			{
				pt = new Point(groupPanel.Left + 2, groupPanel.Top + 2);
			}
			else
			{
				groupPanel = gridViewInfo.GroupPanel.Rows[groupIndex - 1].Bounds;
				pt = new Point(groupPanel.Left + groupIndex * 100, groupPanel.Bottom);
			}
			base.Actions.MouseDown(fgridControl, GetColumnLocationAtCenter(column));
			base.Actions.MoveMousePointTo(fgridControl, pt);
			base.Actions.MouseUp(fgridControl, pt);
		}
	}

	public void ClickMasterRecordIcon(GridView view, int row)
	{
		if (base.Actions.Canceled)
		{
			return;
		}
		GridViewInfo gridViewInfo = GetGridViewInfo(view);
		if (gridViewInfo == null || row >= gridViewInfo.RowsInfo.Count || !(gridViewInfo.RowsInfo[row] is GridDataRowInfo { IsMasterRow: not false } gridDataRowInfo))
		{
			return;
		}
		Rectangle rectangle = Rectangle.Empty;
		foreach (GridCellInfo cell in gridDataRowInfo.Cells)
		{
			if (!cell.CellButtonRect.IsEmpty)
			{
				rectangle = cell.CellButtonRect;
				break;
			}
		}
		ActiveActions.Delay(1000);
		if (!rectangle.IsEmpty)
		{
			base.Actions.MouseClick(fgridControl, new Point(rectangle.Left + rectangle.Width / 2, rectangle.Top + rectangle.Height / 2));
		}
	}

	public void ColumnResize(GridColumn column, int delta)
	{
		if (column != null && column.View is GridView)
		{
			ColumnResize(column, column.View as GridView, delta);
		}
	}

	public void ColumnResize(GridColumn column, GridView view, int delta)
	{
		if (!base.Actions.Canceled && view != null && column != null && column.VisibleIndex >= 0)
		{
			GridViewInfo gridViewInfo = GetGridViewInfo(view);
			if (gridViewInfo != null)
			{
				Rectangle bounds = GetGridColumnInfo(view, column).Bounds;
				Point pt = new Point(bounds.Right, bounds.Top + bounds.Height / 2);
				base.Actions.MouseDown(fgridControl, pt);
				pt.X += delta;
				base.Actions.MoveMousePointTo(fgridControl, pt);
				base.Actions.MouseUp(fgridControl, pt);
			}
		}
	}

	public void ColumnBestFit(GridColumn column)
	{
		ColumnBestFit(column, string.Empty);
	}

	public void ColumnBestFit(GridColumn column, string message)
	{
		if (column != null && column.View is GridView)
		{
			ColumnBestFit(column, column.View as GridView, message);
		}
	}

	public void ColumnBestFit(GridColumn column, GridView view)
	{
		ColumnBestFit(column, view, string.Empty);
	}

	public void ColumnBestFit(GridColumn column, GridView view, string message)
	{
		if (base.Actions.Canceled || view == null || column == null || column.VisibleIndex < 0)
		{
			return;
		}
		GridViewInfo gridViewInfo = GetGridViewInfo(view);
		if (gridViewInfo != null)
		{
			Rectangle bounds = GetGridColumnInfo(view, column).Bounds;
			Point pt = new Point(bounds.Right, bounds.Top + bounds.Height / 2);
			base.Actions.MoveMousePointTo(fgridControl, pt);
			if (message != string.Empty)
			{
				ShowMessage(message);
			}
			else
			{
				ActiveActions.Delay(300);
			}
			base.Actions.MouseDblClick(fgridControl, pt);
		}
	}

	public void ViewZoom(GridView view)
	{
		ViewZoom(view, string.Empty);
	}

	public void ViewZoom(GridView view, string message)
	{
		if (base.Actions.Canceled)
		{
			return;
		}
		GridViewInfo gridViewInfo = GetGridViewInfo(view);
		if (gridViewInfo == null)
		{
			return;
		}
		for (int i = 0; i < gridViewInfo.ColumnsInfo.Count; i++)
		{
			if (gridViewInfo.ColumnsInfo[i].Type == GridColumnInfoType.Indicator)
			{
				Point pointAtCenter = GetPointAtCenter(gridViewInfo.ColumnsInfo[i].Bounds);
				base.Actions.MoveMousePointTo(fgridControl, pointAtCenter);
				if (message != string.Empty)
				{
					ShowMessage(message);
				}
				base.Actions.MouseClick(fgridControl, pointAtCenter);
				break;
			}
		}
	}

	public void ExpandCollapseRow(GridView view, int groupRow)
	{
		if (base.Actions.Canceled)
		{
			return;
		}
		GridViewInfo gridViewInfo = GetGridViewInfo(view);
		int num = 0;
		if (gridViewInfo == null)
		{
			return;
		}
		for (int i = 0; i < gridViewInfo.RowsInfo.Count; i++)
		{
			if (gridViewInfo.RowsInfo[i].IsGroupRow)
			{
				if (num == groupRow)
				{
					base.Actions.MouseClick(fgridControl, GetPointAtCenter(((GridGroupRowInfo)gridViewInfo.RowsInfo[i]).ButtonBounds));
					break;
				}
				num++;
			}
		}
	}

	public Rectangle GetGroupPanelRectangle(GridView view)
	{
		if (base.Actions.Canceled)
		{
			return Rectangle.Empty;
		}
		GridViewInfo gridViewInfo = GetGridViewInfo(view);
		return gridViewInfo.ViewRects.GroupPanel;
	}

	public void ClickControlNavigatorButton(NavigatorButtonType buttonType)
	{
		if (base.Actions.Canceled)
		{
			return;
		}
		NavigatorButton navigatorButton = GridControl.EmbeddedNavigator.Buttons.ButtonByButtonType(buttonType);
		if (navigatorButton == null)
		{
			return;
		}
		NavigatorButtonsViewInfo gridNavigatorButtonsViewInfo = GetGridNavigatorButtonsViewInfo();
		if (gridNavigatorButtonsViewInfo != null)
		{
			NavigatorButtonViewInfo buttonViewInfo = gridNavigatorButtonsViewInfo.GetButtonViewInfo(navigatorButton);
			if (buttonViewInfo != null && !buttonViewInfo.Bounds.IsEmpty)
			{
				Point pt = GridControl.PointToScreen(GridControl.EmbeddedNavigator.Location);
				pt.X += buttonViewInfo.Bounds.X + buttonViewInfo.Bounds.Width / 2;
				pt.Y += buttonViewInfo.Bounds.Y + buttonViewInfo.Bounds.Height / 2;
				base.Actions.MouseClick(pt);
				ActiveActions.Delay(300);
			}
		}
	}

	private Point GetColumnLocationAtCenter(GridColumn column)
	{
		GridView gridView = column.View as GridView;
		gridView.MakeColumnVisible(column);
		GridViewInfo gridViewInfo = GetGridViewInfo(gridView);
		return GetPointAtCenter(gridViewInfo.ColumnsInfo[column].Bounds);
	}

	public static GridViewInfo GetGridViewInfo(GridView gridView)
	{
		if (gridView == null)
		{
			return null;
		}
		if (!(gridView.GetViewInfo() is GridViewInfo gridViewInfo))
		{
			return null;
		}
		if (!gridViewInfo.IsReady)
		{
			gridView.LayoutChanged();
		}
		return gridViewInfo;
	}

	private int GetFocusedRow(GridView gridView)
	{
		return gridView.FocusedRowHandle;
	}

	private GridColumnInfoArgs GetGridColumnInfo(GridColumn column)
	{
		return GetGridColumnInfo(column.View as GridView, column);
	}

	private GridColumnInfoArgs GetGridColumnInfo(GridView view, GridColumn column)
	{
		if (column.View != view)
		{
			foreach (GridColumn column2 in view.Columns)
			{
				if (column2.Name == column.Name)
				{
					column = column2;
					break;
				}
			}
		}
		GridViewInfo gridViewInfo = GetGridViewInfo(view);
		return gridViewInfo.ColumnsInfo[column];
	}

	private NavigatorButtonsViewInfo GetGridNavigatorButtonsViewInfo()
	{
		PropertyInfo property = GridControl.EmbeddedNavigator.Buttons.GetType().GetProperty("ViewInfo", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetProperty, null, typeof(NavigatorButtonsViewInfo), new Type[0], null);
		if (property != null)
		{
			return property.GetValue(GridControl.EmbeddedNavigator.Buttons, null) as NavigatorButtonsViewInfo;
		}
		return null;
	}

	public void ClickGridColumnAtFilterButton(GridColumn column)
	{
		ClickGridColumnAtElement(column, typeof(GridFilterButtonInfoArgs));
	}

	public void ClickGridColumnAtElement(GridColumn column, Type type)
	{
		if (!base.Actions.Canceled && column != null && column.VisibleIndex >= 0 && column.View is GridView)
		{
			Point columnLocationAtElement = GetColumnLocationAtElement(column, type);
			if (columnLocationAtElement != Point.Empty)
			{
				base.Actions.MouseClick(GridControl, columnLocationAtElement);
			}
		}
	}

	private Point GetColumnLocationAtElement(GridColumn column, Type type)
	{
		GridView gridView = column.View as GridView;
		gridView.MakeColumnVisible(column);
		GridViewInfo gridViewInfo = GetGridViewInfo(gridView);
		ObjectInfoArgs objectInfoArgs = null;
		foreach (DrawElementInfo innerElement in gridViewInfo.ColumnsInfo[column].InnerElements)
		{
			if (innerElement.ElementInfo.GetType().Equals(type))
			{
				objectInfoArgs = innerElement.ElementInfo;
				break;
			}
		}
		if (objectInfoArgs != null)
		{
			return GetPointAtCenter(objectInfoArgs.Bounds);
		}
		return Point.Empty;
	}
}
