namespace HAENGSUNG_HNSMES_UI.Forms.SYS
{
    partial class SYSA206
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
            this.rdgUpdateFlag = new IDAT.Devexpress.DXControl.IdatDxRadioGroup();
            this.gcList = new DevExpress.XtraGrid.GridControl();
            this.gvList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.rdgAlertFlag = new IDAT.Devexpress.DXControl.IdatDxRadioGroup();
            this.memRemarks = new IDAT.Devexpress.DXControl.IdatDxMemoEdit();
            this.rdgUseFlag = new IDAT.Devexpress.DXControl.IdatDxRadioGroup();
            this.txtUserClassName = new IDAT.Devexpress.DXControl.IdatDxTextEdit();
            this.txtUserClassCode = new IDAT.Devexpress.DXControl.IdatDxTextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdgUpdateFlag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgAlertFlag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memRemarks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgUseFlag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserClassName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserClassCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Controls.Add(this.rdgUpdateFlag);
            this.layoutControl1.Controls.Add(this.rdgAlertFlag);
            this.layoutControl1.Controls.Add(this.memRemarks);
            this.layoutControl1.Controls.Add(this.rdgUseFlag);
            this.layoutControl1.Controls.Add(this.txtUserClassName);
            this.layoutControl1.Controls.Add(this.txtUserClassCode);
            this.layoutControl1.Controls.Add(this.gcList);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(796, 313, 250, 350);
            this.layoutControl1.OptionsFocus.MoveFocusDirection = DevExpress.XtraLayout.MoveFocusDirection.DownThenAcross;
            this.layoutControl1.OptionsView.HighlightFocusedItem = true;
            this.layoutControl1.Padding = new System.Windows.Forms.Padding(2);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(884, 462);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // rdgUpdateFlag
            // 
            this.rdgUpdateFlag.BindColumnName = "UPDATEFLAG";
            this.rdgUpdateFlag.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.rdgUpdateFlag.BindGridControl = this.gcList;
            this.rdgUpdateFlag.Location = new System.Drawing.Point(673, 102);
            this.rdgUpdateFlag.Name = "rdgUpdateFlag";
            this.rdgUpdateFlag.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Y", "Yes"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("N", "No")});
            this.rdgUpdateFlag.Size = new System.Drawing.Size(206, 25);
            this.rdgUpdateFlag.StyleController = this.layoutControl1;
            this.rdgUpdateFlag.TabIndex = 3;
            // 
            // gcList
            // 
            this.gcList.Location = new System.Drawing.Point(9, 25);
            this.gcList.MainView = this.gvList;
            this.gcList.Name = "gcList";
            this.gcList.Size = new System.Drawing.Size(544, 432);
            this.gcList.TabIndex = 4;
            this.gcList.TabStop = false;
            this.gcList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvList});
            this.gcList.Click += new System.EventHandler(this.gvList_Click);
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
            this.gvList.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
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
            this.gvList.OptionsView.EnableAppearanceEvenRow = true;
            this.gvList.OptionsView.ShowAutoFilterRow = true;
            this.gvList.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gvList.OptionsView.ShowFooter = true;
            this.gvList.OptionsView.ShowGroupedColumns = true;
            this.gvList.OptionsView.ShowGroupPanel = false;
            this.gvList.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvList_RowStyle);
            this.gvList.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gvList_BeforeLeaveRow);
            // 
            // rdgAlertFlag
            // 
            this.rdgAlertFlag.BindColumnName = "ALERTFLAG";
            this.rdgAlertFlag.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.rdgAlertFlag.BindGridControl = this.gcList;
            this.rdgAlertFlag.Location = new System.Drawing.Point(673, 73);
            this.rdgAlertFlag.Name = "rdgAlertFlag";
            this.rdgAlertFlag.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Y", "Yes"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("N", "No")});
            this.rdgAlertFlag.Size = new System.Drawing.Size(206, 25);
            this.rdgAlertFlag.StyleController = this.layoutControl1;
            this.rdgAlertFlag.TabIndex = 2;
            // 
            // memRemarks
            // 
            this.memRemarks.BindColumnName = "REMARKS";
            this.memRemarks.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.memRemarks.BindGridControl = this.gcList;
            this.memRemarks.Location = new System.Drawing.Point(673, 160);
            this.memRemarks.Name = "memRemarks";
            this.memRemarks.Size = new System.Drawing.Size(206, 79);
            this.memRemarks.StyleController = this.layoutControl1;
            this.memRemarks.TabIndex = 5;
            this.memRemarks.UseOptimizedRendering = true;
            // 
            // rdgUseFlag
            // 
            this.rdgUseFlag.BindColumnName = "USEFLAG";
            this.rdgUseFlag.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.rdgUseFlag.BindGridControl = this.gcList;
            this.rdgUseFlag.IsYesNoType = true;
            this.rdgUseFlag.Location = new System.Drawing.Point(673, 131);
            this.rdgUseFlag.Name = "rdgUseFlag";
            this.rdgUseFlag.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Y", "Yes"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("N", "No")});
            this.rdgUseFlag.Size = new System.Drawing.Size(206, 25);
            this.rdgUseFlag.StyleController = this.layoutControl1;
            this.rdgUseFlag.TabIndex = 4;
            this.rdgUseFlag.ValidationCheck = true;
            // 
            // txtUserClassName
            // 
            this.txtUserClassName.BindColumnName = "USERROLENAME";
            this.txtUserClassName.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.txtUserClassName.BindGridControl = this.gcList;
            this.txtUserClassName.Location = new System.Drawing.Point(673, 49);
            this.txtUserClassName.Name = "txtUserClassName";
            this.txtUserClassName.Size = new System.Drawing.Size(206, 20);
            this.txtUserClassName.StyleController = this.layoutControl1;
            this.txtUserClassName.TabIndex = 1;
            this.txtUserClassName.ValidationCheck = true;
            // 
            // txtUserClassCode
            // 
            this.txtUserClassCode.BindColumnName = "USERROLE";
            this.txtUserClassCode.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.txtUserClassCode.BindGridControl = this.gcList;
            this.txtUserClassCode.BindPK = true;
            this.txtUserClassCode.Location = new System.Drawing.Point(673, 25);
            this.txtUserClassCode.Name = "txtUserClassCode";
            this.txtUserClassCode.Size = new System.Drawing.Size(206, 20);
            this.txtUserClassCode.StyleController = this.layoutControl1;
            this.txtUserClassCode.TabIndex = 0;
            this.txtUserClassCode.ValidationCheck = true;
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
            this.layoutControlGroup2.CustomizationFormText = "Detail";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup2.Location = new System.Drawing.Point(561, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlGroup2.Size = new System.Drawing.Size(321, 460);
            this.layoutControlGroup2.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 0, 0, 0);
            this.layoutControlGroup2.Text = "Detail";
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.AppearanceItemCaption.BackColor = System.Drawing.Color.Transparent;
            this.emptySpaceItem1.AppearanceItemCaption.Options.UseBackColor = true;
            this.emptySpaceItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            this.emptySpaceItem1.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 218);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(313, 218);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.BackColor = System.Drawing.Color.Transparent;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.layoutControlItem2.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem2.Control = this.txtUserClassCode;
            this.layoutControlItem2.CustomizationFormText = "사용자 등급 코드";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(313, 24);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 0, 0, 0);
            this.layoutControlItem2.Text = "USERCLASSCODE";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(96, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.AppearanceItemCaption.BackColor = System.Drawing.Color.Transparent;
            this.layoutControlItem7.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlItem7.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem7.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.layoutControlItem7.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem7.Control = this.txtUserClassName;
            this.layoutControlItem7.CustomizationFormText = "사용자 등급 명칭";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(313, 24);
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 0, 0, 0);
            this.layoutControlItem7.Text = "USERCLASSNAME";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(96, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.AppearanceItemCaption.BackColor = System.Drawing.Color.Transparent;
            this.layoutControlItem8.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlItem8.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem8.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.layoutControlItem8.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem8.Control = this.rdgUseFlag;
            this.layoutControlItem8.CustomizationFormText = "사용유무";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 106);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(0, 29);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(158, 29);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(313, 29);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 0, 0, 0);
            this.layoutControlItem8.Text = "USEFLAG";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(96, 14);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.AppearanceItemCaption.BackColor = System.Drawing.Color.Transparent;
            this.layoutControlItem9.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlItem9.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem9.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.layoutControlItem9.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem9.Control = this.memRemarks;
            this.layoutControlItem9.CustomizationFormText = "설명";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 135);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(313, 83);
            this.layoutControlItem9.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 0, 0, 0);
            this.layoutControlItem9.Text = "REMARKS";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(96, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.rdgAlertFlag;
            this.layoutControlItem3.CustomizationFormText = "ALERTFLAG";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(0, 29);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(157, 29);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(313, 29);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 0, 0, 0);
            this.layoutControlItem3.Text = "ALERTFLAG";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(96, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.rdgUpdateFlag;
            this.layoutControlItem4.CustomizationFormText = "UPDATEFLAG";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 77);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(0, 29);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(157, 29);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(313, 29);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 0, 0, 0);
            this.layoutControlItem4.Text = "UPDATEFLAG";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(96, 14);
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
            this.layoutControlGroup3.CustomizationFormText = "List";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlGroup3.Size = new System.Drawing.Size(556, 460);
            this.layoutControlGroup3.Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 0, 0, 0);
            this.layoutControlGroup3.Text = "List";
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
            this.layoutControlItem1.Size = new System.Drawing.Size(548, 436);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.CustomizationFormText = "splitterItem1";
            this.splitterItem1.Location = new System.Drawing.Point(556, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(5, 460);
            // 
            // SYSA206
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.Controls.Add(this.layoutControl1);
            this.Name = "SYSA206";
            this.ShowDeleteButton = false;
            this.ShowPrintButton = false;
            this.ShowRefreshButton = false;
            this.ShowSearchButton = false;
            this.ShowStopButton = false;
            this.Text = "SYSA206";
            this.Load += new System.EventHandler(this.SYSA206_Load);
            this.Shown += new System.EventHandler(this.SYSA206_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdgUpdateFlag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgAlertFlag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memRemarks.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgUseFlag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserClassName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserClassCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gcList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvList;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private IDAT.Devexpress.DXControl.IdatDxMemoEdit memRemarks;
        private IDAT.Devexpress.DXControl.IdatDxRadioGroup rdgUseFlag;
        private IDAT.Devexpress.DXControl.IdatDxTextEdit txtUserClassName;
        private IDAT.Devexpress.DXControl.IdatDxTextEdit txtUserClassCode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private IDAT.Devexpress.DXControl.IdatDxRadioGroup rdgUpdateFlag;
        private IDAT.Devexpress.DXControl.IdatDxRadioGroup rdgAlertFlag;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;

    }
}