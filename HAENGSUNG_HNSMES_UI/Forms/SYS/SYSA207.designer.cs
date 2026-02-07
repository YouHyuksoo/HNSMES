namespace HAENGSUNG_HNSMES_UI.Forms.SYS
{
    partial class SYSA207
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
            this.btnExpendOff = new DevExpress.XtraEditors.SimpleButton();
            this.btnExpendOn = new DevExpress.XtraEditors.SimpleButton();
            this.tlMenu = new DevExpress.XtraTreeList.TreeList();
            this.gcList = new DevExpress.XtraGrid.GridControl();
            this.gvList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Controls.Add(this.btnExpendOff);
            this.layoutControl1.Controls.Add(this.btnExpendOn);
            this.layoutControl1.Controls.Add(this.tlMenu);
            this.layoutControl1.Controls.Add(this.gcList);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(978, 316, 250, 350);
            this.layoutControl1.OptionsFocus.MoveFocusDirection = DevExpress.XtraLayout.MoveFocusDirection.DownThenAcross;
            this.layoutControl1.OptionsView.HighlightFocusedItem = true;
            this.layoutControl1.Padding = new System.Windows.Forms.Padding(2);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(884, 462);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnExpendOff
            // 
            this.btnExpendOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExpendOff.Image = global::HAENGSUNG_HNSMES_UI.Properties.Resources.btn_AllExpendOff_Image;
            this.btnExpendOff.Location = new System.Drawing.Point(387, 25);
            this.btnExpendOff.Name = "btnExpendOff";
            this.btnExpendOff.Size = new System.Drawing.Size(46, 36);
            this.btnExpendOff.StyleController = this.layoutControl1;
            this.btnExpendOff.TabIndex = 8;
            this.btnExpendOff.Click += new System.EventHandler(this.btnExpendOff_Click);
            // 
            // btnExpendOn
            // 
            this.btnExpendOn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExpendOn.Image = global::HAENGSUNG_HNSMES_UI.Properties.Resources.btn_AllExpendOn_Image;
            this.btnExpendOn.Location = new System.Drawing.Point(337, 25);
            this.btnExpendOn.Name = "btnExpendOn";
            this.btnExpendOn.Size = new System.Drawing.Size(46, 36);
            this.btnExpendOn.StyleController = this.layoutControl1;
            this.btnExpendOn.TabIndex = 7;
            this.btnExpendOn.Click += new System.EventHandler(this.btnExpendOn_Click);
            // 
            // tlMenu
            // 
            this.tlMenu.Location = new System.Drawing.Point(337, 65);
            this.tlMenu.Name = "tlMenu";
            this.tlMenu.OptionsBehavior.AllowIndeterminateCheckState = true;
            this.tlMenu.OptionsView.EnableAppearanceEvenRow = true;
            this.tlMenu.OptionsView.ShowVertLines = false;
            this.tlMenu.Size = new System.Drawing.Size(542, 392);
            this.tlMenu.TabIndex = 6;
            this.tlMenu.CustomNodeCellEdit += new DevExpress.XtraTreeList.GetCustomNodeCellEditEventHandler(this.tlMenu_CustomNodeCellEdit);
            this.tlMenu.BeforeCheckNode += new DevExpress.XtraTreeList.CheckNodeEventHandler(this.tl_Menu_BeforeCheckNode);
            this.tlMenu.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.tl_Menu_AfterCheckNode);
            this.tlMenu.NodeChanged += new DevExpress.XtraTreeList.NodeChangedEventHandler(this.tlMenu_NodeChanged);
            this.tlMenu.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.tlMenu_CellValueChanged);
            this.tlMenu.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.tlMenu_ShowingEditor);
            // 
            // gcList
            // 
            this.gcList.Location = new System.Drawing.Point(9, 25);
            this.gcList.MainView = this.gvList;
            this.gcList.Name = "gcList";
            this.gcList.Size = new System.Drawing.Size(311, 432);
            this.gcList.TabIndex = 5;
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
            this.gvList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvList_FocusedRowChanged);
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
            this.layoutControlGroup2.CustomizationFormText = "Class List";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlGroup2.Size = new System.Drawing.Size(323, 460);
            this.layoutControlGroup2.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 0, 0, 0);
            this.layoutControlGroup2.Text = "List";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.BackColor = System.Drawing.Color.Transparent;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem2.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem2.Control = this.gcList;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(315, 436);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
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
            this.layoutControlGroup3.CustomizationFormText = "Menu";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem1,
            this.layoutControlItem5});
            this.layoutControlGroup3.Location = new System.Drawing.Point(328, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlGroup3.Size = new System.Drawing.Size(554, 460);
            this.layoutControlGroup3.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 0, 0, 0);
            this.layoutControlGroup3.Text = "Menu";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.BackColor = System.Drawing.Color.Transparent;
            this.layoutControlItem3.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlItem3.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem3.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem3.Control = this.tlMenu;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(546, 396);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.BackColor = System.Drawing.Color.Transparent;
            this.layoutControlItem4.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlItem4.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem4.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem4.Control = this.btnExpendOn;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(50, 40);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(50, 40);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(50, 40);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.AppearanceItemCaption.BackColor = System.Drawing.Color.Transparent;
            this.emptySpaceItem1.AppearanceItemCaption.Options.UseBackColor = true;
            this.emptySpaceItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            this.emptySpaceItem1.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(100, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(446, 40);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.BackColor = System.Drawing.Color.Transparent;
            this.layoutControlItem5.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlItem5.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem5.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem5.Control = this.btnExpendOff;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(50, 0);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(50, 40);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(50, 40);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(50, 40);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.CustomizationFormText = "splitterItem1";
            this.splitterItem1.Location = new System.Drawing.Point(323, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(5, 460);
            // 
            // SYSA207
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.Controls.Add(this.layoutControl1);
            this.IsButtonAuto = false;
            this.Name = "SYSA207";
            this.ShowDeleteButton = false;
            this.ShowEditButton = false;
            this.ShowNewbutton = false;
            this.ShowPrintButton = false;
            this.ShowSearchButton = false;
            this.ShowStopButton = false;
            this.Text = "SYSA207";
            this.Load += new System.EventHandler(this.SYSA207_Load);
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gcList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvList;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraTreeList.TreeList tlMenu;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton btnExpendOff;
        private DevExpress.XtraEditors.SimpleButton btnExpendOn;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
    }
}