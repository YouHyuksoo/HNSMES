using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraPrinting;

namespace IDAT.Devexpress.LAYOUT;

public class IDATDevExpress_Layoutcontrol
{
	public void PrintPreview(LayoutControl lyControl)
	{
		PrintingSystem printingSystem = new PrintingSystem();
		PrintableComponentLink printableComponentLink = new PrintableComponentLink();
		printableComponentLink.Component = lyControl;
		printableComponentLink.Landscape = true;
		printableComponentLink.Margins.Top = 50;
		printableComponentLink.Margins.Bottom = 50;
		printableComponentLink.Margins.Left = 20;
		printableComponentLink.Margins.Right = 20;
		printableComponentLink.CreateDocument(printingSystem);
		printingSystem.Document.AutoFitToPagesWidth = 1;
		printableComponentLink.ShowPreviewDialog();
	}

	public void DevControlsClear_LayoutControl(LayoutControl contr)
	{
		if (contr == null)
		{
			return;
		}
		if (!contr.IsInitialized)
		{
			return;
		}
		contr.BeginUpdate();
		try
		{
			foreach (BaseLayoutItem item in contr.Items)
			{
				if (!(item is LayoutControlItem { Control: not null } layoutControlItem))
				{
					continue;
				}
				if (layoutControlItem.Control is GridControl)
				{
					if (layoutControlItem.Control is GridControl gridControl)
					{
						GridView gridView = gridControl.DefaultView as GridView;
					}
				}
				else if (layoutControlItem.Control is BaseEdit && layoutControlItem.Control is BaseEdit baseEdit)
				{
					baseEdit.EditValue = null;
				}
			}
		}
		finally
		{
			contr.EndUpdate();
		}
	}
}
