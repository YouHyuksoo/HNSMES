namespace HAENGSUNG_HNSMES_UI.Forms.OSC
{
    partial class OSCA205
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.dteInsMonth = new IDAT.Devexpress.DXControl.IdatDXMonthEdit();
            this.gleWHLoc = new IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gleWH = new IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit();
            this.idatDxGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcList = new DevExpress.XtraGrid.GridControl();
            this.gvList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteInsMonth.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteInsMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleWHLoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleWH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idatDxGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.dteInsMonth);
            this.layoutControl1.Controls.Add(this.gleWHLoc);
            this.layoutControl1.Controls.Add(this.gleWH);
            this.layoutControl1.Controls.Add(this.gcList);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(884, 462);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // dteInsMonth
            // 
            this.dteInsMonth.BindGridControl = null;
            this.dteInsMonth.EditValue = null;
            this.dteInsMonth.IsUseIDATFrameWorkControl = false;
            this.dteInsMonth.Location = new System.Drawing.Point(106, 36);
            this.dteInsMonth.Name = "dteInsMonth";
            this.dteInsMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteInsMonth.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dteInsMonth.Properties.DisplayFormat.FormatString = "yyyy-MM";
            this.dteInsMonth.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dteInsMonth.Properties.EditFormat.FormatString = "yyyyMM";
            this.dteInsMonth.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dteInsMonth.Size = new System.Drawing.Size(120, 20);
            this.dteInsMonth.StyleController = this.layoutControl1;
            this.dteInsMonth.TabIndex = 1;
            // 
            // gleWHLoc
            // 
            this.gleWHLoc.BindGridControl = null;
            this.gleWHLoc.IsUseIDATFrameWorkControl = false;
            this.gleWHLoc.Location = new System.Drawing.Point(619, 36);
            this.gleWHLoc.Name = "gleWHLoc";
            this.gleWHLoc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gleWHLoc.Properties.View = this.gridView2;
            this.gleWHLoc.Size = new System.Drawing.Size(249, 20);
            this.gleWHLoc.StyleController = this.layoutControl1;
            this.gleWHLoc.TabIndex = 2;
            // 
            // gridView2
            // 
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gleWH
            // 
            this.gleWH.BindGridControl = null;
            this.gleWH.IsUseIDATFrameWorkControl = false;
            this.gleWH.Location = new System.Drawing.Point(320, 36);
            this.gleWH.Name = "gleWH";
            this.gleWH.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gleWH.Properties.View = this.idatDxGridLookUpEdit1View;
            this.gleWH.Size = new System.Drawing.Size(205, 20);
            this.gleWH.StyleController = this.layoutControl1;
            this.gleWH.TabIndex = 1;
            this.gleWH.EditValueChanged += new System.EventHandler(this.gleWH_EditValueChanged);
            // 
            // idatDxGridLookUpEdit1View
            // 
            this.idatDxGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.idatDxGridLookUpEdit1View.Name = "idatDxGridLookUpEdit1View";
            this.idatDxGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.idatDxGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gcList
            // 
            this.gcList.Location = new System.Drawing.Point(16, 104);
            this.gcList.MainView = this.gvList;
            this.gcList.Name = "gcList";
            this.gcList.Size = new System.Drawing.Size(852, 342);
            this.gcList.TabIndex = 3;
            this.gcList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvList});
            // 
            // gvList
            // 
            this.gvList.GridControl = this.gcList;
            this.gvList.Name = "gvList";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup3,
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup1.Size = new System.Drawing.Size(884, 462);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "LIST";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 68);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(880, 390);
            this.layoutControlGroup3.Text = "LIST";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcList;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(856, 346);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "CONDITION";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(880, 68);
            this.layoutControlGroup2.Text = "CONDITION";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gleWH;
            this.layoutControlItem3.CustomizationFormText = "WAREHOUSE";
            this.layoutControlItem3.Location = new System.Drawing.Point(214, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(299, 24);
            this.layoutControlItem3.Text = "WAREHOUSE";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(87, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gleWHLoc;
            this.layoutControlItem4.CustomizationFormText = "LOCATION";
            this.layoutControlItem4.Location = new System.Drawing.Point(513, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(343, 24);
            this.layoutControlItem4.Text = "LOCATION";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(87, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dteInsMonth;
            this.layoutControlItem2.CustomizationFormText = "ACTUALMONTH";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(214, 24);
            this.layoutControlItem2.Text = "ACTUALMONTH";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(87, 14);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem2.Location = new System.Drawing.Point(357, 416);
            this.emptySpaceItem2.Name = "emptySpaceItem1";
            this.emptySpaceItem2.Size = new System.Drawing.Size(343, 42);
            this.emptySpaceItem2.Text = "emptySpaceItem1";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // OSCA205
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.Controls.Add(this.layoutControl1);
            this.Name = "OSCA205";
            this.ShowDeleteButton = false;
            this.ShowEditButton = false;
            this.ShowNewbutton = false;
            this.ShowPrintButton = false;
            this.ShowRefreshButton = false;
            this.ShowSaveButton = false;
            this.ShowStopButton = false;
            this.Text = "OSCA205";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Shown += new System.EventHandler(this.Form_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dteInsMonth.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteInsMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleWHLoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleWH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idatDxGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraGrid.GridControl gcList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvList;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit gleWHLoc;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit gleWH;
        private DevExpress.XtraGrid.Views.Grid.GridView idatDxGridLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private IDAT.Devexpress.DXControl.IdatDXMonthEdit dteInsMonth;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}