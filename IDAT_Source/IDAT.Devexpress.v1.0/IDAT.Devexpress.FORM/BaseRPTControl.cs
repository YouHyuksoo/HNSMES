using System;
using System.ComponentModel;
using System.Drawing.Printing;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace IDAT.Devexpress.FORM;

public class BaseRPTControl : XtraReport
{
	public delegate void SetReportDefaultControl(XRControl obj);

	private IContainer components = null;

	private TopMarginBand topMarginBand1;

	private DetailBand BaseDetail;

	private BottomMarginBand bottomMarginBand1;

	public event SetReportDefaultControl SetReportDefaultContolEvent;

	public BaseRPTControl()
	{
		InitializeComponent();
	}

	public virtual void SetReport_DefaultSetting(XRControl obj)
	{
		try
		{
			if (obj is XtraReport)
			{
				XtraReport xtraReport = obj as XtraReport;
				{
					foreach (Band band3 in xtraReport.Bands)
					{
						Band band2 = band3;
						foreach (XRControl control in band2.Controls)
						{
							SetReport_DefaultSetting(control);
						}
					}
					return;
				}
			}
			if (obj is XRTable)
			{
				XRTable xRTable = obj as XRTable;
				foreach (XRTableRow row in xRTable.Rows)
				{
					foreach (XRTableCell cell in row.Cells)
					{
						SetReport_DefaultSetting(cell);
					}
				}
			}
			if (obj.HasChildren)
			{
				foreach (XRControl control2 in obj.Controls)
				{
					SetReport_DefaultSetting(control2);
				}
				return;
			}
			if (this.SetReportDefaultContolEvent != null)
			{
				this.SetReportDefaultContolEvent(obj);
			}
			if (obj is XRLabel)
			{
				XRLabel xRLabel = obj as XRLabel;
				xRLabel.CanGrow = false;
			}
			if (obj is XRTableCell)
			{
				XRTableCell report_DefaultSetting2 = obj as XRTableCell;
				report_DefaultSetting2.CanGrow = false;
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	private void BaseRPTControl_BeforePrint(object sender, PrintEventArgs e)
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
		topMarginBand1 = new TopMarginBand();
		BaseDetail = new DetailBand();
		bottomMarginBand1 = new BottomMarginBand();
		((ISupportInitialize)this).BeginInit();
		topMarginBand1.BorderWidth = 0f;
		topMarginBand1.HeightF = 0f;
		topMarginBand1.Name = "topMarginBand1";
		topMarginBand1.SnapLinePadding = new PaddingInfo(0, 0, 0, 0, 100f);
		topMarginBand1.StylePriority.UseBorderWidth = false;
		topMarginBand1.Visible = false;
		BaseDetail.BorderWidth = 0f;
		BaseDetail.HeightF = 0f;
		BaseDetail.Name = "BaseDetail";
		BaseDetail.SnapLinePadding = new PaddingInfo(0, 0, 0, 0, 100f);
		BaseDetail.StylePriority.UseBorderWidth = false;
		BaseDetail.Visible = false;
		bottomMarginBand1.BorderWidth = 0f;
		bottomMarginBand1.HeightF = 0f;
		bottomMarginBand1.Name = "bottomMarginBand1";
		bottomMarginBand1.SnapLinePadding = new PaddingInfo(0, 0, 0, 0, 100f);
		bottomMarginBand1.StylePriority.UseBorderWidth = false;
		bottomMarginBand1.Visible = false;
		base.Bands.AddRange(new Band[3] { topMarginBand1, BaseDetail, bottomMarginBand1 });
		base.Margins = new Margins(100, 100, 0, 0);
		base.Version = "11.2";
		BeforePrint += BaseRPTControl_BeforePrint;
		((ISupportInitialize)this).EndInit();
	}
}
