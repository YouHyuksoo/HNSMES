using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace IDAT.Devexpress.NOTICE.SUB;

public class ucSubNotice : UserControl
{
	private DataTable dt = null;

	private GridView gvNotice = null;

	private int _SubjectMaxLength = 0;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private GridView gvList;

	private LayoutControlItem layoutControlItem1;

	public GridControl gcList;

	public DataTable DataSource
	{
		get
		{
			return dt;
		}
		set
		{
			dt = value;
			gcList.DataSource = dt;
		}
	}

	public GridView GvNotice => gvList;

	public int SubjectMaxLength
	{
		get
		{
			return _SubjectMaxLength;
		}
		set
		{
			_SubjectMaxLength = value;
			if (value == 0)
			{
				_SubjectMaxLength = 10;
			}
		}
	}

	public ucSubNotice()
	{
		InitializeComponent();
	}

	private void idatNoticeInfo_Load(object sender, EventArgs e)
	{
	}

	public virtual void InitSubNoticeControl()
	{
		gvList.CustomDrawCell -= gvList_CustomDrawCell;
		gvList.CustomDrawCell += gvList_CustomDrawCell;
		gvList.Columns["NOTICENO"].Visible = false;
		gvList.Columns["NOTICETYPE"].Visible = false;
		gvList.Columns["POSTDATE"].VisibleIndex = 0;
		gvList.Columns["SUBJECT"].VisibleIndex = 1;
		gvList.Columns["CONTENTS"].VisibleIndex = 2;
		gvList.Columns["EDTUSER"].VisibleIndex = 3;
		gvList.OptionsBehavior.Editable = false;
		gvList.OptionsSelection.EnableAppearanceFocusedCell = false;
		gvList.FocusRectStyle = DrawFocusRectStyle.RowFocus;
		gvList.OptionsSelection.InvertSelection = false;
	}

	public virtual void ShowFocusedRowDetailView()
	{
		int focusedRowHandle = gvList.FocusedRowHandle;
		string p_Date = gvList.GetRowCellValue(focusedRowHandle, "POSTDATE").ToString();
		string p_Title = gvList.GetRowCellValue(focusedRowHandle, "SUBJECT").ToString();
		string p_Name = gvList.GetRowCellValue(focusedRowHandle, "EDTUSER").ToString();
		string p_Content = gvList.GetRowCellValue(focusedRowHandle, "CONTENTS").ToString();
		POP_Nofice pOP_Nofice = new POP_Nofice(p_Date, p_Title, p_Name, p_Content);
		pOP_Nofice.StartPosition = FormStartPosition.CenterParent;
		pOP_Nofice.ShowDialog();
	}

	public virtual void gvList_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
	{
		if (e.Column.FieldName == "CONTENTS" && string.Concat(e.CellValue).Length > SubjectMaxLength)
		{
			e.DisplayText = e.CellValue.ToString().Substring(0, SubjectMaxLength) + "...";
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
		this.gcList = new DevExpress.XtraGrid.GridControl();
		this.gvList = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gcList).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gvList).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.gcList);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(517, 389);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.gcList.Location = new System.Drawing.Point(2, 2);
		this.gcList.MainView = this.gvList;
		this.gcList.Name = "gcList";
		this.gcList.Size = new System.Drawing.Size(513, 385);
		this.gcList.TabIndex = 4;
		this.gcList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gvList });
		this.gvList.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
		this.gvList.GridControl = this.gcList;
		this.gvList.Name = "gvList";
		this.gvList.OptionsView.ShowGroupPanel = false;
		this.gvList.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(gvList_CustomDrawCell);
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[1] { this.layoutControlItem1 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(517, 389);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.gcList;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(517, 389);
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "ucSubNotice";
		base.Size = new System.Drawing.Size(517, 389);
		base.Load += new System.EventHandler(idatNoticeInfo_Load);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gcList).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gvList).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		base.ResumeLayout(false);
	}
}
