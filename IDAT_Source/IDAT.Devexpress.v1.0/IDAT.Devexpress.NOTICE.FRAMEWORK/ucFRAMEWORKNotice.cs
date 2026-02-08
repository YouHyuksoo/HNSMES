using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace IDAT.Devexpress.NOTICE.FRAMEWORK;

public class ucFRAMEWORKNotice : UserControl
{
	private string _FilePath;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private GridControl gcList;

	private GridView gvList;

	private LayoutControlItem layoutControlItem1;

	public ucFRAMEWORKNotice()
	{
		InitializeComponent();
		_FilePath = Application.StartupPath + "\\FrameworkDoc.xml";
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		if (!base.DesignMode)
		{
			DataSet dataSet = new DataSet("DSFRAMEWORKDOC");
			if (!File.Exists(_FilePath))
			{
				DataColumn column = new DataColumn("NO");
				DataColumn column2 = new DataColumn("TITLE");
				DataColumn column3 = new DataColumn("CONTENT");
				DataColumn column4 = new DataColumn("DATE");
				DataTable dataTable = new DataTable("FRAMEWORKDOC");
				dataTable.Columns.Add(column);
				dataTable.Columns.Add(column2);
				dataTable.Columns.Add(column3);
				dataTable.Columns.Add(column4);
				dataTable.Rows.Add(1, "IDAT Framework 1.0업데이트 내역 v1.0.0.0", "framework1.0.docx", DateTime.Now);
				dataSet.Tables.Add(dataTable);
				dataSet.WriteXml(_FilePath);
			}
			else
			{
				dataSet.ReadXml(_FilePath);
			}
			gcList.DataSource = dataSet.Tables[0];
			gvList.OptionsBehavior.Editable = false;
			gvList.OptionsSelection.EnableAppearanceFocusedCell = false;
			gvList.FocusRectStyle = DrawFocusRectStyle.RowFocus;
			gvList.OptionsSelection.InvertSelection = false;
		}
	}

	private void gvList_DoubleClick(object sender, EventArgs e)
	{
		if (gvList.GetFocusedDataRow() != null)
		{
			POP_FRAMEWORKDOC pOP_FRAMEWORKDOC = new POP_FRAMEWORKDOC(Application.StartupPath + "\\" + gvList.GetFocusedDataRow()["CONTENT"]);
			pOP_FRAMEWORKDOC.ShowDialog();
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
		this.gvList.DoubleClick += new System.EventHandler(gvList_DoubleClick);
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
		base.Name = "ucFRAMEWORKNotice";
		base.Size = new System.Drawing.Size(517, 389);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gcList).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gvList).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		base.ResumeLayout(false);
	}
}
