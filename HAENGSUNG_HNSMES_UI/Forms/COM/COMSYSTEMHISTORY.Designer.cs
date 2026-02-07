namespace HAENGSUNG_HNSMES_UI.Forms.COM
{
    partial class COMSYSTEMHISTORY
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(COMSYSTEMHISTORY));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gcError = new DevExpress.XtraGrid.GridControl();
            this.gvError = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcList = new DevExpress.XtraGrid.GridControl();
            this.gvList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dteDate = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gcError);
            this.layoutControl1.Controls.Add(this.gcList);
            this.layoutControl1.Controls.Add(this.dteDate);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1313, 348, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(884, 462);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gcError
            // 
            this.gcError.Location = new System.Drawing.Point(24, 297);
            this.gcError.MainView = this.gvError;
            this.gcError.Name = "gcError";
            this.gcError.Size = new System.Drawing.Size(836, 141);
            this.gcError.TabIndex = 62;
            this.gcError.TabStop = false;
            this.gcError.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvError});
            // 
            // gvError
            // 
            this.gvError.Appearance.FocusedCell.BackColor = System.Drawing.Color.MistyRose;
            this.gvError.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvError.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(140)))), ((int)(((byte)(145)))), ((int)(((byte)(255)))));
            this.gvError.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvError.Appearance.HorzLine.BackColor = System.Drawing.Color.DarkGray;
            this.gvError.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvError.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(140)))), ((int)(((byte)(145)))), ((int)(((byte)(255)))));
            this.gvError.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvError.Appearance.VertLine.BackColor = System.Drawing.Color.DarkGray;
            this.gvError.Appearance.VertLine.Options.UseBackColor = true;
            this.gvError.FixedLineWidth = 1;
            this.gvError.GridControl = this.gcError;
            this.gvError.GroupFormat = "{1}";
            this.gvError.Name = "gvError";
            this.gvError.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvError.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.gvError.OptionsBehavior.Editable = false;
            this.gvError.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvError.OptionsLayout.Columns.StoreAllOptions = true;
            this.gvError.OptionsLayout.Columns.StoreAppearance = true;
            this.gvError.OptionsLayout.StoreAllOptions = true;
            this.gvError.OptionsLayout.StoreAppearance = true;
            this.gvError.OptionsPrint.AutoWidth = false;
            this.gvError.OptionsSelection.MultiSelect = true;
            this.gvError.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gvError.OptionsView.EnableAppearanceEvenRow = true;
            this.gvError.OptionsView.ShowAutoFilterRow = true;
            this.gvError.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gvError.OptionsView.ShowFooter = true;
            this.gvError.OptionsView.ShowGroupedColumns = true;
            this.gvError.OptionsView.ShowGroupPanel = false;
            // 
            // gcList
            // 
            this.gcList.Location = new System.Drawing.Point(24, 114);
            this.gcList.MainView = this.gvList;
            this.gcList.Name = "gcList";
            this.gcList.Size = new System.Drawing.Size(836, 135);
            this.gcList.TabIndex = 7;
            this.gcList.TabStop = false;
            this.gcList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvList});
            // 
            // gvList
            // 
            this.gvList.Appearance.FocusedCell.BackColor = System.Drawing.Color.MistyRose;
            this.gvList.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvList.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(140)))), ((int)(((byte)(145)))), ((int)(((byte)(255)))));
            this.gvList.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvList.Appearance.HorzLine.BackColor = System.Drawing.Color.DarkGray;
            this.gvList.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvList.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(140)))), ((int)(((byte)(145)))), ((int)(((byte)(255)))));
            this.gvList.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvList.Appearance.VertLine.BackColor = System.Drawing.Color.DarkGray;
            this.gvList.Appearance.VertLine.Options.UseBackColor = true;
            this.gvList.FixedLineWidth = 1;
            this.gvList.GridControl = this.gcList;
            this.gvList.GroupFormat = "{1}";
            this.gvList.Name = "gvList";
            this.gvList.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvList.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.gvList.OptionsBehavior.Editable = false;
            this.gvList.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvList.OptionsLayout.Columns.StoreAllOptions = true;
            this.gvList.OptionsLayout.Columns.StoreAppearance = true;
            this.gvList.OptionsLayout.StoreAllOptions = true;
            this.gvList.OptionsLayout.StoreAppearance = true;
            this.gvList.OptionsPrint.AutoWidth = false;
            this.gvList.OptionsSelection.MultiSelect = true;
            this.gvList.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gvList.OptionsView.EnableAppearanceEvenRow = true;
            this.gvList.OptionsView.ShowAutoFilterRow = true;
            this.gvList.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gvList.OptionsView.ShowFooter = true;
            this.gvList.OptionsView.ShowGroupedColumns = true;
            this.gvList.OptionsView.ShowGroupPanel = false;
            this.gvList.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvList_RowClick);
            // 
            // dteDate
            // 
            this.dteDate.EditValue = new System.DateTime(2012, 3, 29, 9, 6, 41, 133);
            this.dteDate.EnterMoveNextControl = true;
            this.dteDate.Location = new System.Drawing.Point(53, 44);
            this.dteDate.Name = "dteDate";
            this.dteDate.Properties.Appearance.Options.UseTextOptions = true;
            this.dteDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dteDate.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.dteDate.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.dteDate.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dteDate.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.dteDate.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.dteDate.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.dteDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 15, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("dteDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.dteDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dteDate.Size = new System.Drawing.Size(164, 22);
            this.dteDate.StyleController = this.layoutControl1;
            this.dteDate.TabIndex = 4;
            this.dteDate.ToolTip = "보이기/숨기기 [키보드 : ALT+DOWN, F4] \r\n값 확인 [키보드 : UP,DOWN]\r\n마우스 휠 지원.";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup3,
            this.layoutControlGroup4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(884, 462);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "조회조건";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(864, 70);
            this.layoutControlGroup2.Text = "Condition";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dteDate;
            this.layoutControlItem1.CustomizationFormText = "Date";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(197, 26);
            this.layoutControlItem1.Text = "Date";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(26, 14);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(197, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(643, 26);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "List";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 70);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(864, 183);
            this.layoutControlGroup3.Text = "System Use History";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gcList;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(840, 139);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.CustomizationFormText = "Package Error";
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 253);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(864, 189);
            this.layoutControlGroup4.Text = "Package Error";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gcError;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(840, 145);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // COMSYSTEMHISTORY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.Controls.Add(this.layoutControl1);
            this.Name = "COMSYSTEMHISTORY";
            this.ShowDeleteButton = false;
            this.ShowEditButton = false;
            this.ShowNewbutton = false;
            this.ShowPrintButton = false;
            this.ShowRefreshButton = false;
            this.ShowSaveButton = false;
            this.ShowStopButton = false;
            this.Text = "COMSYSTEMHISTORY";
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gcList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvList;
        private DevExpress.XtraEditors.DateEdit dteDate;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.GridControl gcError;
        private DevExpress.XtraGrid.Views.Grid.GridView gvError;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}