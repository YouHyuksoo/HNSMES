namespace HAENGSUNG_HNSMES_UI.Forms.SAL
{
    partial class SALB203
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
            this.components = new System.ComponentModel.Container();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.dteMonth = new IDAT.Devexpress.DXControl.IdatDXMonthEdit();
            this.txtPartNo1 = new IDAT.Devexpress.DXControl.IdatDxTextEdit();
            this.gleWHLoc = new IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gleWH = new IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit();
            this.idatDxGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcList1 = new DevExpress.XtraGrid.GridControl();
            this.gvList1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tabbedControlGroup2 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteMonth.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPartNo1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleWHLoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleWH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idatDxGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.dteMonth);
            this.layoutControl1.Controls.Add(this.txtPartNo1);
            this.layoutControl1.Controls.Add(this.gleWHLoc);
            this.layoutControl1.Controls.Add(this.gleWH);
            this.layoutControl1.Controls.Add(this.gcList1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(884, 462);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // dteMonth
            // 
            this.dteMonth.BindGridControl = null;
            this.dteMonth.EditValue = null;
            this.dteMonth.Location = new System.Drawing.Point(104, 71);
            this.dteMonth.Name = "dteMonth";
            this.dteMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteMonth.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteMonth.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.dteMonth.Properties.DisplayFormat.FormatString = "yyyy-MM";
            this.dteMonth.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dteMonth.Properties.EditFormat.FormatString = "yyyy-MM";
            this.dteMonth.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dteMonth.Properties.Mask.EditMask = "\\d\\d\\d\\d-\\d\\d";
            this.dteMonth.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.dteMonth.Properties.MaxLength = 7;
            this.dteMonth.Properties.ShowToday = false;
            this.dteMonth.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.dteMonth.Size = new System.Drawing.Size(87, 20);
            this.dteMonth.StyleController = this.layoutControl1;
            this.dteMonth.TabIndex = 4;
            // 
            // txtPartNo1
            // 
            this.txtPartNo1.BindGridControl = null;
            this.txtPartNo1.IsUseIDATFrameWorkControl = false;
            this.txtPartNo1.Location = new System.Drawing.Point(690, 71);
            this.txtPartNo1.Name = "txtPartNo1";
            this.txtPartNo1.Size = new System.Drawing.Size(166, 20);
            this.txtPartNo1.StyleController = this.layoutControl1;
            this.txtPartNo1.TabIndex = 1;
            // 
            // gleWHLoc
            // 
            this.gleWHLoc.BindGridControl = null;
            this.gleWHLoc.IsUseIDATFrameWorkControl = false;
            this.gleWHLoc.Location = new System.Drawing.Point(487, 71);
            this.gleWHLoc.Name = "gleWHLoc";
            this.gleWHLoc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gleWHLoc.Properties.View = this.gridView2;
            this.gleWHLoc.Size = new System.Drawing.Size(123, 20);
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
            this.gleWH.Location = new System.Drawing.Point(271, 71);
            this.gleWH.Name = "gleWH";
            this.gleWH.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gleWH.Properties.View = this.idatDxGridLookUpEdit1View;
            this.gleWH.Size = new System.Drawing.Size(136, 20);
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
            // gcList1
            // 
            this.gcList1.Location = new System.Drawing.Point(28, 142);
            this.gcList1.MainView = this.gvList1;
            this.gcList1.Name = "gcList1";
            this.gcList1.Size = new System.Drawing.Size(828, 292);
            this.gcList1.TabIndex = 3;
            this.gcList1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvList1});
            // 
            // gvList1
            // 
            this.gvList1.GridControl = this.gcList1;
            this.gvList1.Name = "gvList1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabbedControlGroup1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup1.Size = new System.Drawing.Size(884, 462);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.CustomizationFormText = "tabbedControlGroup1";
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.layoutControlGroup4;
            this.tabbedControlGroup1.SelectedTabPageIndex = 0;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(880, 458);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup4});
            this.tabbedControlGroup1.Text = "tabbedControlGroup1";
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.CustomizationFormText = "INCOMPANY";
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.tabbedControlGroup2});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(856, 411);
            this.layoutControlGroup4.Text = "INCOMPANY";
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "CONDITION";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(856, 68);
            this.layoutControlGroup2.Text = "CONDITION";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gleWH;
            this.layoutControlItem3.CustomizationFormText = "WAREHOUSE";
            this.layoutControlItem3.Location = new System.Drawing.Point(167, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(216, 24);
            this.layoutControlItem3.Text = "WAREHOUSE";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(73, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gleWHLoc;
            this.layoutControlItem4.CustomizationFormText = "LOCATION";
            this.layoutControlItem4.Location = new System.Drawing.Point(383, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(203, 24);
            this.layoutControlItem4.Text = "LOCATION";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(73, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtPartNo1;
            this.layoutControlItem5.CustomizationFormText = "PARTNO";
            this.layoutControlItem5.Location = new System.Drawing.Point(586, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(246, 24);
            this.layoutControlItem5.Text = "PARTNO";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(73, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dteMonth;
            this.layoutControlItem2.CustomizationFormText = "MONTH";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(167, 24);
            this.layoutControlItem2.Text = "MONTH";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(73, 14);
            // 
            // tabbedControlGroup2
            // 
            this.tabbedControlGroup2.CustomizationFormText = "tabbedControlGroup2";
            this.tabbedControlGroup2.Location = new System.Drawing.Point(0, 68);
            this.tabbedControlGroup2.Name = "tabbedControlGroup2";
            this.tabbedControlGroup2.SelectedTabPage = this.layoutControlGroup3;
            this.tabbedControlGroup2.SelectedTabPageIndex = 0;
            this.tabbedControlGroup2.Size = new System.Drawing.Size(856, 343);
            this.tabbedControlGroup2.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup3});
            this.tabbedControlGroup2.Text = "tabbedControlGroup2";
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "LIST";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(832, 296);
            this.layoutControlGroup3.Text = "BOX INFO";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcList1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(832, 296);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // toolTipController1
            // 
            this.toolTipController1.Appearance.BackColor = System.Drawing.Color.Red;
            this.toolTipController1.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController1.Appearance.Options.UseBackColor = true;
            this.toolTipController1.Appearance.Options.UseFont = true;
            this.toolTipController1.AppearanceTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.toolTipController1.AppearanceTitle.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController1.AppearanceTitle.ForeColor = System.Drawing.Color.Red;
            this.toolTipController1.AppearanceTitle.Options.UseBackColor = true;
            this.toolTipController1.AppearanceTitle.Options.UseFont = true;
            this.toolTipController1.AppearanceTitle.Options.UseForeColor = true;
            this.toolTipController1.AutoPopDelay = 3000;
            this.toolTipController1.ToolTipStyle = DevExpress.Utils.ToolTipStyle.Windows7;
            this.toolTipController1.ToolTipType = DevExpress.Utils.ToolTipType.SuperTip;
            // 
            // SALB203
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.Controls.Add(this.layoutControl1);
            this.Name = "SALB203";
            this.ShowDeleteButton = false;
            this.ShowEditButton = false;
            this.ShowInitButton = false;
            this.ShowNewbutton = false;
            this.ShowPrintButton = false;
            this.ShowRefreshButton = false;
            this.ShowSaveButton = false;
            this.ShowStopButton = false;
            this.Text = "SALB203";
            this.Load += new System.EventHandler(this.SALB203_Load);
            this.Shown += new System.EventHandler(this.SALB203_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dteMonth.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPartNo1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleWHLoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleWH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idatDxGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gcList1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvList1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit gleWHLoc;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit gleWH;
        private DevExpress.XtraGrid.Views.Grid.GridView idatDxGridLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private IDAT.Devexpress.DXControl.IdatDxTextEdit txtPartNo1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private IDAT.Devexpress.DXControl.IdatDXMonthEdit dteMonth;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}