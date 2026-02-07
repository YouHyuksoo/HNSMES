namespace HAENGSUNG_HNSMES_UI.Forms.MNT
{
    partial class MNTB207

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
            this.dteDate1 = new IDAT.Devexpress.DXControl.IdatDXMonthEdit();
            this.gleWHLoc1 = new IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gleWH1 = new IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcList = new DevExpress.XtraGrid.GridControl();
            this.gvList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            this.lcgEHR = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.idatDxRadioGroup1 = new IDAT.Devexpress.DXControl.IdatDxRadioGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteDate1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDate1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleWHLoc1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleWH1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgEHR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idatDxRadioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.dteDate1);
            this.layoutControl1.Controls.Add(this.gleWHLoc1);
            this.layoutControl1.Controls.Add(this.gleWH1);
            this.layoutControl1.Controls.Add(this.gcList);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(74, 55, 417, 565);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(961, 525);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // dteDate1
            // 
            this.dteDate1.BindGridControl = null;
            this.dteDate1.EditValue = null;
            this.dteDate1.IsUseIDATFrameWorkControl = false;
            this.dteDate1.Location = new System.Drawing.Point(100, 44);
            this.dteDate1.Margin = new System.Windows.Forms.Padding(2);
            this.dteDate1.Name = "dteDate1";
            this.dteDate1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteDate1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteDate1.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.dteDate1.Properties.DisplayFormat.FormatString = "yyyy-MM";
            this.dteDate1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dteDate1.Properties.EditFormat.FormatString = "yyyy-MM";
            this.dteDate1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dteDate1.Properties.Mask.EditMask = "\\d\\d\\d\\d-\\d\\d";
            this.dteDate1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.dteDate1.Properties.MaxLength = 7;
            this.dteDate1.Properties.ShowToday = false;
            this.dteDate1.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.dteDate1.Size = new System.Drawing.Size(218, 20);
            this.dteDate1.StyleController = this.layoutControl1;
            this.dteDate1.TabIndex = 35;
            // 
            // gleWHLoc1
            // 
            this.gleWHLoc1.BindGridControl = null;
            this.gleWHLoc1.IsUseIDATFrameWorkControl = false;
            this.gleWHLoc1.Location = new System.Drawing.Point(718, 44);
            this.gleWHLoc1.Name = "gleWHLoc1";
            this.gleWHLoc1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gleWHLoc1.Properties.View = this.gridView4;
            this.gleWHLoc1.Size = new System.Drawing.Size(219, 20);
            this.gleWHLoc1.StyleController = this.layoutControl1;
            this.gleWHLoc1.TabIndex = 23;
            // 
            // gridView4
            // 
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // gleWH1
            // 
            this.gleWH1.BindGridControl = null;
            this.gleWH1.IsUseIDATFrameWorkControl = false;
            this.gleWH1.Location = new System.Drawing.Point(398, 44);
            this.gleWH1.Name = "gleWH1";
            this.gleWH1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gleWH1.Properties.View = this.gridView1;
            this.gleWH1.Size = new System.Drawing.Size(240, 20);
            this.gleWH1.StyleController = this.layoutControl1;
            this.gleWH1.TabIndex = 21;
            this.gleWH1.EditValueChanged += new System.EventHandler(this.gleWH1_EditValueChanged);
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gcList
            // 
            this.gcList.Location = new System.Drawing.Point(24, 112);
            this.gcList.MainView = this.gvList;
            this.gcList.Name = "gcList";
            this.gcList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gcList.Size = new System.Drawing.Size(908, 389);
            this.gcList.TabIndex = 35;
            this.gcList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvList});
            // 
            // gvList
            // 
            this.gvList.GridControl = this.gcList;
            this.gvList.Name = "gvList";
            this.gvList.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvList_RowStyle);
            this.gvList.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gvList_BeforeLeaveRow);
            this.gvList.Click += new System.EventHandler(this.gvList_Click);
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.splitterItem1,
            this.lcgEHR,
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(961, 525);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.CustomizationFormText = "splitterItem1";
            this.splitterItem1.Location = new System.Drawing.Point(936, 68);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(5, 437);
            // 
            // lcgEHR
            // 
            this.lcgEHR.CustomizationFormText = "List";
            this.lcgEHR.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.lcgEHR.Location = new System.Drawing.Point(0, 68);
            this.lcgEHR.Name = "lcgEHR";
            this.lcgEHR.Size = new System.Drawing.Size(936, 437);
            this.lcgEHR.Text = "List";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcList;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(912, 393);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "CONDITION";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem11,
            this.layoutControlItem12,
            this.layoutControlItem18});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(941, 68);
            this.layoutControlGroup2.Text = "CONDITION";
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.gleWH1;
            this.layoutControlItem11.CustomizationFormText = "WAREHOUSE";
            this.layoutControlItem11.Location = new System.Drawing.Point(298, 0);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(320, 24);
            this.layoutControlItem11.Text = "WAREHOUSE";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(73, 14);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.gleWHLoc1;
            this.layoutControlItem12.CustomizationFormText = "WHLOC";
            this.layoutControlItem12.Location = new System.Drawing.Point(618, 0);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(299, 24);
            this.layoutControlItem12.Text = "WHLOC";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(73, 14);
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.dteDate1;
            this.layoutControlItem18.CustomizationFormText = "ACTUALMON";
            this.layoutControlItem18.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(298, 24);
            this.layoutControlItem18.Text = "ACTUALMON";
            this.layoutControlItem18.TextSize = new System.Drawing.Size(73, 14);
            // 
            // idatDxRadioGroup1
            // 
            this.idatDxRadioGroup1.BindColumnName = "TEXTMARKTYPE";
            this.idatDxRadioGroup1.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.idatDxRadioGroup1.BindGridControl = this.gcList;
            this.idatDxRadioGroup1.Location = new System.Drawing.Point(550, 323);
            this.idatDxRadioGroup1.Name = "idatDxRadioGroup1";
            this.idatDxRadioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.idatDxRadioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.idatDxRadioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Y", "Yes"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("N", "No")});
            this.idatDxRadioGroup1.Size = new System.Drawing.Size(293, 25);
            this.idatDxRadioGroup1.StyleController = this.layoutControl1;
            this.idatDxRadioGroup1.TabIndex = 19;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.CustomizationFormText = "DATE";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(155, 24);
            this.layoutControlItem5.Name = "layoutControlItem2";
            this.layoutControlItem5.Size = new System.Drawing.Size(292, 24);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "DATE";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(73, 14);
            this.layoutControlItem5.TextToControlDistance = 5;
            // 
            // MNTB207
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 525);
            this.Controls.Add(this.layoutControl1);
            this.Name = "MNTB207";
            this.ShowDeleteButton = false;
            this.ShowEditButton = false;
            this.ShowNewbutton = false;
            this.ShowPrintButton = false;
            this.ShowRefreshButton = false;
            this.ShowSaveButton = false;
            this.ShowStopButton = false;
            this.Text = "MNTB207";
            this.Load += new System.EventHandler(this.MNTB207_Load);
            this.Shown += new System.EventHandler(this.MNTB207_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dteDate1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDate1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleWHLoc1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleWH1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgEHR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idatDxRadioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gcList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvList;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraLayout.LayoutControlGroup lcgEHR;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private IDAT.Devexpress.DXControl.IdatDxRadioGroup idatDxRadioGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit gleWH1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit gleWHLoc1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private IDAT.Devexpress.DXControl.IdatDXMonthEdit dteDate1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
    }
}