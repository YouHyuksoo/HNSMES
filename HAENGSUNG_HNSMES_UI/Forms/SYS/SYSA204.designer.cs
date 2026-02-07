namespace HAENGSUNG_HNSMES_UI.Forms.SYS
{
    partial class SYSA204
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
            this.rdgTouchFlag = new IDAT.Devexpress.DXControl.IdatDxRadioGroup();
            this.gcList = new DevExpress.XtraGrid.GridControl();
            this.gvList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ImagIndex = new IDAT.Devexpress.DXControl.IdatDxImageComboBoxEdit();
            this.rdgUseFlag = new IDAT.Devexpress.DXControl.IdatDxRadioGroup();
            this.txtFormName = new IDAT.Devexpress.DXControl.IdatDxTextEdit();
            this.txtFormCode = new IDAT.Devexpress.DXControl.IdatDxTextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdgTouchFlag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagIndex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgUseFlag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Controls.Add(this.rdgTouchFlag);
            this.layoutControl1.Controls.Add(this.ImagIndex);
            this.layoutControl1.Controls.Add(this.rdgUseFlag);
            this.layoutControl1.Controls.Add(this.txtFormName);
            this.layoutControl1.Controls.Add(this.txtFormCode);
            this.layoutControl1.Controls.Add(this.gcList);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(796, 288, 250, 350);
            this.layoutControl1.OptionsFocus.MoveFocusDirection = DevExpress.XtraLayout.MoveFocusDirection.DownThenAcross;
            this.layoutControl1.OptionsView.HighlightFocusedItem = true;
            this.layoutControl1.Padding = new System.Windows.Forms.Padding(2);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(884, 462);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // rdgTouchFlag
            // 
            this.rdgTouchFlag.BindColumnName = "TOUCHFLAG";
            this.rdgTouchFlag.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.rdgTouchFlag.BindGridControl = this.gcList;
            this.rdgTouchFlag.EditValue = "Y";
            this.rdgTouchFlag.IsYesNoType = true;
            this.rdgTouchFlag.Location = new System.Drawing.Point(642, 102);
            this.rdgTouchFlag.Name = "rdgTouchFlag";
            this.rdgTouchFlag.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Y", "Yes"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("N", "No")});
            this.rdgTouchFlag.Size = new System.Drawing.Size(237, 27);
            this.rdgTouchFlag.StyleController = this.layoutControl1;
            this.rdgTouchFlag.TabIndex = 20;
            this.rdgTouchFlag.ValidationCheck = true;
            // 
            // gcList
            // 
            this.gcList.Location = new System.Drawing.Point(9, 25);
            this.gcList.MainView = this.gvList;
            this.gcList.Name = "gcList";
            this.gcList.Size = new System.Drawing.Size(545, 432);
            this.gcList.TabIndex = 4;
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
            this.gvList.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvList_RowStyle);
            this.gvList.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gvList_BeforeLeaveRow);
            this.gvList.Click += new System.EventHandler(this.gvList_Click);
            // 
            // ImagIndex
            // 
            this.ImagIndex.BindColumnName = "IMGIDX";
            this.ImagIndex.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.ImagIndex.BindGridControl = this.gcList;
            this.ImagIndex.Location = new System.Drawing.Point(642, 133);
            this.ImagIndex.Name = "ImagIndex";
            this.ImagIndex.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImagIndex.Size = new System.Drawing.Size(237, 20);
            this.ImagIndex.StyleController = this.layoutControl1;
            this.ImagIndex.TabIndex = 19;
            // 
            // rdgUseFlag
            // 
            this.rdgUseFlag.BindColumnName = "USEFLAG";
            this.rdgUseFlag.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.rdgUseFlag.BindGridControl = this.gcList;
            this.rdgUseFlag.EditValue = "Y";
            this.rdgUseFlag.IsYesNoType = true;
            this.rdgUseFlag.Location = new System.Drawing.Point(642, 73);
            this.rdgUseFlag.Name = "rdgUseFlag";
            this.rdgUseFlag.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Y", "Yes"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("N", "No")});
            this.rdgUseFlag.Size = new System.Drawing.Size(237, 25);
            this.rdgUseFlag.StyleController = this.layoutControl1;
            this.rdgUseFlag.TabIndex = 18;
            this.rdgUseFlag.ValidationCheck = true;
            // 
            // txtFormName
            // 
            this.txtFormName.BindColumnName = "FORMNAME";
            this.txtFormName.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.txtFormName.BindGridControl = this.gcList;
            this.txtFormName.Location = new System.Drawing.Point(642, 49);
            this.txtFormName.Name = "txtFormName";
            this.txtFormName.Size = new System.Drawing.Size(237, 20);
            this.txtFormName.StyleController = this.layoutControl1;
            this.txtFormName.TabIndex = 15;
            this.txtFormName.ValidationCheck = true;
            // 
            // txtFormCode
            // 
            this.txtFormCode.BindColumnName = "FORM";
            this.txtFormCode.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.txtFormCode.BindGridControl = this.gcList;
            this.txtFormCode.BindPK = true;
            this.txtFormCode.Location = new System.Drawing.Point(642, 25);
            this.txtFormCode.Name = "txtFormCode";
            this.txtFormCode.Size = new System.Drawing.Size(237, 20);
            this.txtFormCode.StyleController = this.layoutControl1;
            this.txtFormCode.TabIndex = 14;
            this.txtFormCode.ValidationCheck = true;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroup1.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceItemCaption.BackColor = System.Drawing.Color.Transparent;
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlGroup1.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup3,
            this.splitterItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlGroup1.Size = new System.Drawing.Size(884, 462);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroup2.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup2.AppearanceItemCaption.BackColor = System.Drawing.Color.Transparent;
            this.layoutControlGroup2.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlGroup2.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlGroup2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.layoutControlGroup2.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlGroup2.CustomizationFormText = "List";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlGroup2.Size = new System.Drawing.Size(557, 460);
            this.layoutControlGroup2.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 0, 0, 0);
            this.layoutControlGroup2.Text = "List";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.BackColor = System.Drawing.Color.Transparent;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem1.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem1.Control = this.gcList;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(549, 436);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroup3.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup3.AppearanceItemCaption.BackColor = System.Drawing.Color.Transparent;
            this.layoutControlGroup3.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlGroup3.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlGroup3.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.layoutControlGroup3.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlGroup3.CustomizationFormText = "Detail";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup3.Location = new System.Drawing.Point(562, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlGroup3.Size = new System.Drawing.Size(320, 460);
            this.layoutControlGroup3.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 0, 0, 0);
            this.layoutControlGroup3.Text = "Detail";
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtFormCode;
            this.layoutControlItem8.CustomizationFormText = "폼코드";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(312, 24);
            this.layoutControlItem8.Text = "FORMCODE";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(68, 14);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.txtFormName;
            this.layoutControlItem9.CustomizationFormText = "폼명칭";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(312, 24);
            this.layoutControlItem9.Text = "FORMNAME";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(68, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.rdgUseFlag;
            this.layoutControlItem2.CustomizationFormText = "USEFLAG";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(0, 29);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(121, 29);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(312, 29);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "USEFLAG";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(68, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 132);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(312, 304);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.ImagIndex;
            this.layoutControlItem3.CustomizationFormText = "IMGIDX";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 108);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(312, 24);
            this.layoutControlItem3.Text = "IMGIDX";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(68, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.rdgTouchFlag;
            this.layoutControlItem4.CustomizationFormText = "TOUCHFLAG";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 77);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(312, 31);
            this.layoutControlItem4.Text = "TOUCHFLAG";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(68, 14);
            this.layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.CustomizationFormText = "splitterItem1";
            this.splitterItem1.Location = new System.Drawing.Point(557, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(5, 460);
            // 
            // SYSA204
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.Controls.Add(this.layoutControl1);
            this.Name = "SYSA204";
            this.ShowDeleteButton = false;
            this.ShowPrintButton = false;
            this.ShowRefreshButton = false;
            this.ShowSearchButton = false;
            this.ShowStopButton = false;
            this.Text = "SYSA204";
            this.Load += new System.EventHandler(this.SYSA204_Load);
            this.Shown += new System.EventHandler(this.SYSA204_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdgTouchFlag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagIndex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgUseFlag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gcList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvList;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private IDAT.Devexpress.DXControl.IdatDxRadioGroup rdgUseFlag;
        private IDAT.Devexpress.DXControl.IdatDxTextEdit txtFormName;
        private IDAT.Devexpress.DXControl.IdatDxTextEdit txtFormCode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private IDAT.Devexpress.DXControl.IdatDxImageComboBoxEdit ImagIndex;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private IDAT.Devexpress.DXControl.IdatDxRadioGroup rdgTouchFlag;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}