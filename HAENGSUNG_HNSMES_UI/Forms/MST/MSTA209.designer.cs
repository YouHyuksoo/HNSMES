namespace HAENGSUNG_HNSMES_UI.Forms.MST
{
    partial class MSTA209
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
            this.txtErpCode = new IDAT.Devexpress.DXControl.IdatDxTextEdit();
            this.gcList = new DevExpress.XtraGrid.GridControl();
            this.gvList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gleOper = new IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit();
            this.idatDxGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.rdgUseFlag = new IDAT.Devexpress.DXControl.IdatDxRadioGroup();
            this.memRemarks = new IDAT.Devexpress.DXControl.IdatDxMemoEdit();
            this.txtLineName = new IDAT.Devexpress.DXControl.IdatDxTextEdit();
            this.txtLine = new IDAT.Devexpress.DXControl.IdatDxTextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtErpCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleOper.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idatDxGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgUseFlag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memRemarks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtErpCode);
            this.layoutControl1.Controls.Add(this.gleOper);
            this.layoutControl1.Controls.Add(this.rdgUseFlag);
            this.layoutControl1.Controls.Add(this.memRemarks);
            this.layoutControl1.Controls.Add(this.txtLineName);
            this.layoutControl1.Controls.Add(this.txtLine);
            this.layoutControl1.Controls.Add(this.gcList);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(796, 264, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(884, 462);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtErpCode
            // 
            this.txtErpCode.BindColumnName = "ERPCODE";
            this.txtErpCode.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.txtErpCode.BindGridControl = this.gcList;
            this.txtErpCode.Location = new System.Drawing.Point(655, 92);
            this.txtErpCode.Name = "txtErpCode";
            this.txtErpCode.Size = new System.Drawing.Size(205, 20);
            this.txtErpCode.StyleController = this.layoutControl1;
            this.txtErpCode.TabIndex = 2;
            // 
            // gcList
            // 
            this.gcList.Location = new System.Drawing.Point(24, 44);
            this.gcList.MainView = this.gvList;
            this.gcList.Name = "gcList";
            this.gcList.Size = new System.Drawing.Size(507, 394);
            this.gcList.TabIndex = 4;
            this.gcList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvList});
            // 
            // gvList
            // 
            this.gvList.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvList.GridControl = this.gcList;
            this.gvList.Name = "gvList";
            this.gvList.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvList_RowStyle);
            this.gvList.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gvList_BeforeLeaveRow);
            // 
            // gleOper
            // 
            this.gleOper.BindColumnName = "OPER";
            this.gleOper.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.gleOper.BindGridControl = this.gcList;
            this.gleOper.CausesValidation = false;
            this.gleOper.Location = new System.Drawing.Point(655, 116);
            this.gleOper.Name = "gleOper";
            this.gleOper.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gleOper.Properties.View = this.idatDxGridLookUpEdit1View;
            this.gleOper.Size = new System.Drawing.Size(205, 20);
            this.gleOper.StyleController = this.layoutControl1;
            this.gleOper.TabIndex = 3;
            this.gleOper.ValidationCheck = true;
            // 
            // idatDxGridLookUpEdit1View
            // 
            this.idatDxGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.idatDxGridLookUpEdit1View.Name = "idatDxGridLookUpEdit1View";
            this.idatDxGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.idatDxGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // rdgUseFlag
            // 
            this.rdgUseFlag.BindColumnName = "USEFLAG";
            this.rdgUseFlag.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.rdgUseFlag.BindGridControl = this.gcList;
            this.rdgUseFlag.EditValue = "Y";
            this.rdgUseFlag.IsYesNoType = true;
            this.rdgUseFlag.Location = new System.Drawing.Point(655, 140);
            this.rdgUseFlag.Name = "rdgUseFlag";
            this.rdgUseFlag.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.rdgUseFlag.Properties.Appearance.Options.UseBackColor = true;
            this.rdgUseFlag.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Y", "Yes"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("N", "No")});
            this.rdgUseFlag.Size = new System.Drawing.Size(205, 25);
            this.rdgUseFlag.StyleController = this.layoutControl1;
            this.rdgUseFlag.TabIndex = 6;
            this.rdgUseFlag.Tag = "bind:USEFLAG,edittype:edit";
            this.rdgUseFlag.ValidationCheck = true;
            // 
            // memRemarks
            // 
            this.memRemarks.BindColumnName = "REMARKS";
            this.memRemarks.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.memRemarks.BindGridControl = this.gcList;
            this.memRemarks.CausesValidation = false;
            this.memRemarks.Location = new System.Drawing.Point(655, 169);
            this.memRemarks.Name = "memRemarks";
            this.memRemarks.Size = new System.Drawing.Size(205, 223);
            this.memRemarks.StyleController = this.layoutControl1;
            this.memRemarks.TabIndex = 7;
            this.memRemarks.Tag = "bind:REMARKS,edittype:edit";
            this.memRemarks.UseOptimizedRendering = true;
            // 
            // txtLineName
            // 
            this.txtLineName.BindColumnName = "PRODLINENAME";
            this.txtLineName.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.txtLineName.BindGridControl = this.gcList;
            this.txtLineName.Location = new System.Drawing.Point(655, 68);
            this.txtLineName.Name = "txtLineName";
            this.txtLineName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtLineName.Properties.Appearance.Options.UseBackColor = true;
            this.txtLineName.Size = new System.Drawing.Size(205, 20);
            this.txtLineName.StyleController = this.layoutControl1;
            this.txtLineName.TabIndex = 1;
            this.txtLineName.Tag = "bind:PRODLINENAME,edittype:edit";
            this.txtLineName.ValidationCheck = true;
            // 
            // txtLine
            // 
            this.txtLine.BindColumnName = "PRODLINE";
            this.txtLine.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.txtLine.BindGridControl = this.gcList;
            this.txtLine.BindPK = true;
            this.txtLine.Location = new System.Drawing.Point(655, 44);
            this.txtLine.Name = "txtLine";
            this.txtLine.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtLine.Properties.Appearance.Options.UseBackColor = true;
            this.txtLine.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLine.Size = new System.Drawing.Size(205, 20);
            this.txtLine.StyleController = this.layoutControl1;
            this.txtLine.TabIndex = 0;
            this.txtLine.Tag = "bind:PRODLINE,edittype:edit,pk:y";
            this.txtLine.ValidationCheck = true;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup3,
            this.splitterItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(884, 462);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "List";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(535, 442);
            this.layoutControlGroup2.Text = "List";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcList;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(511, 398);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "Detail";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem8,
            this.emptySpaceItem1,
            this.layoutControlItem9,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup3.Location = new System.Drawing.Point(540, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(324, 442);
            this.layoutControlGroup3.Text = "Detail";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtLine;
            this.layoutControlItem2.CustomizationFormText = "OPERATIONCODE";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(300, 24);
            this.layoutControlItem2.Text = "PRODLINE";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(88, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtLineName;
            this.layoutControlItem3.CustomizationFormText = "OPERATIONNAME";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(300, 24);
            this.layoutControlItem3.Text = "PRODLINENAME";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(88, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.memRemarks;
            this.layoutControlItem8.CustomizationFormText = "REMARKS";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 125);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(300, 227);
            this.layoutControlItem8.Text = "REMARKS";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(88, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 352);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(300, 46);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.rdgUseFlag;
            this.layoutControlItem9.CustomizationFormText = "USEFLAG";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(0, 29);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(146, 29);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(300, 29);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.Text = "USEFLAG";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(88, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.gleOper;
            this.layoutControlItem5.CustomizationFormText = "OPER";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(300, 24);
            this.layoutControlItem5.Text = "OPER";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(88, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtErpCode;
            this.layoutControlItem6.CustomizationFormText = "ERPCODE";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(300, 24);
            this.layoutControlItem6.Text = "ERPCODE";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(88, 14);
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.CustomizationFormText = "splitterItem1";
            this.splitterItem1.Location = new System.Drawing.Point(535, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(5, 442);
            // 
            // MSTA209
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.Controls.Add(this.layoutControl1);
            this.Name = "MSTA209";
            this.ShowDeleteButton = false;
            this.ShowPrintButton = false;
            this.ShowRefreshButton = false;
            this.ShowSaveButton = false;
            this.ShowSearchButton = false;
            this.ShowStopButton = false;
            this.Text = "Prodline Master";
            this.Load += new System.EventHandler(this.MSTA209_Load);
            this.Shown += new System.EventHandler(this.MSTA209_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtErpCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleOper.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idatDxGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgUseFlag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memRemarks.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gcList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvList;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private IDAT.Devexpress.DXControl.IdatDxTextEdit txtLineName;
        private IDAT.Devexpress.DXControl.IdatDxTextEdit txtLine;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private IDAT.Devexpress.DXControl.IdatDxRadioGroup rdgUseFlag;
        private IDAT.Devexpress.DXControl.IdatDxMemoEdit memRemarks;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit gleOper;
        private DevExpress.XtraGrid.Views.Grid.GridView idatDxGridLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private IDAT.Devexpress.DXControl.IdatDxTextEdit txtErpCode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}