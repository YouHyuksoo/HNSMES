namespace HAENGSUNG_HNSMES_UI.Forms.MST
{
    partial class MSTA212
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
            this.txtMaker = new IDAT.Devexpress.DXControl.IdatDxTextEdit();
            this.gcList = new DevExpress.XtraGrid.GridControl();
            this.gvList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gleWhloc = new IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.rdgUseFlag = new IDAT.Devexpress.DXControl.IdatDxRadioGroup();
            this.memRemarks = new IDAT.Devexpress.DXControl.IdatDxMemoEdit();
            this.txtEQPName = new IDAT.Devexpress.DXControl.IdatDxTextEdit();
            this.txtEQP = new IDAT.Devexpress.DXControl.IdatDxTextEdit();
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
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleWhloc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgUseFlag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memRemarks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEQPName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEQP.Properties)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtMaker);
            this.layoutControl1.Controls.Add(this.gleWhloc);
            this.layoutControl1.Controls.Add(this.rdgUseFlag);
            this.layoutControl1.Controls.Add(this.memRemarks);
            this.layoutControl1.Controls.Add(this.txtEQPName);
            this.layoutControl1.Controls.Add(this.txtEQP);
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
            // txtMaker
            // 
            this.txtMaker.BindColumnName = "MAKER";
            this.txtMaker.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.txtMaker.BindGridControl = this.gcList;
            this.txtMaker.CausesValidation = false;
            this.txtMaker.Location = new System.Drawing.Point(520, 116);
            this.txtMaker.Name = "txtMaker";
            this.txtMaker.Size = new System.Drawing.Size(340, 20);
            this.txtMaker.StyleController = this.layoutControl1;
            this.txtMaker.TabIndex = 4;
            this.txtMaker.Tag = "bind:MAKER,edittype:edit";
            // 
            // gcList
            // 
            this.gcList.Location = new System.Drawing.Point(24, 44);
            this.gcList.MainView = this.gvList;
            this.gcList.Name = "gcList";
            this.gcList.Size = new System.Drawing.Size(405, 394);
            this.gcList.TabIndex = 4;
            this.gcList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvList});
            // 
            // gvList
            // 
            this.gvList.GridControl = this.gcList;
            this.gvList.Name = "gvList";
            this.gvList.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvList_RowStyle);
            this.gvList.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gvList_BeforeLeaveRow);
            // 
            // gleWhloc
            // 
            this.gleWhloc.BindColumnName = "WHLOC";
            this.gleWhloc.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.gleWhloc.BindGridControl = this.gcList;
            this.gleWhloc.Location = new System.Drawing.Point(520, 92);
            this.gleWhloc.Name = "gleWhloc";
            this.gleWhloc.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.gleWhloc.Properties.Appearance.Options.UseBackColor = true;
            this.gleWhloc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gleWhloc.Properties.View = this.gridView1;
            this.gleWhloc.Size = new System.Drawing.Size(340, 20);
            this.gleWhloc.StyleController = this.layoutControl1;
            this.gleWhloc.TabIndex = 2;
            this.gleWhloc.Tag = "bind:EQPGRP,edittype:edit";
            this.gleWhloc.ValidationCheck = true;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // rdgUseFlag
            // 
            this.rdgUseFlag.BindColumnName = "USEFLAG";
            this.rdgUseFlag.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.rdgUseFlag.BindGridControl = this.gcList;
            this.rdgUseFlag.EditValue = "Y";
            this.rdgUseFlag.IsYesNoType = true;
            this.rdgUseFlag.Location = new System.Drawing.Point(520, 140);
            this.rdgUseFlag.Name = "rdgUseFlag";
            this.rdgUseFlag.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.rdgUseFlag.Properties.Appearance.Options.UseBackColor = true;
            this.rdgUseFlag.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Y", "Yes"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("N", "No")});
            this.rdgUseFlag.Size = new System.Drawing.Size(340, 25);
            this.rdgUseFlag.StyleController = this.layoutControl1;
            this.rdgUseFlag.TabIndex = 7;
            this.rdgUseFlag.Tag = "bind:USEFLAG,edittype:edit";
            this.rdgUseFlag.ValidationCheck = true;
            // 
            // memRemarks
            // 
            this.memRemarks.BindColumnName = "REMARKS";
            this.memRemarks.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.memRemarks.BindGridControl = this.gcList;
            this.memRemarks.CausesValidation = false;
            this.memRemarks.Location = new System.Drawing.Point(520, 169);
            this.memRemarks.Name = "memRemarks";
            this.memRemarks.Size = new System.Drawing.Size(340, 220);
            this.memRemarks.StyleController = this.layoutControl1;
            this.memRemarks.TabIndex = 8;
            this.memRemarks.Tag = "bind:REMARKS,edittype:edit";
            this.memRemarks.UseOptimizedRendering = true;
            // 
            // txtEQPName
            // 
            this.txtEQPName.BindColumnName = "EQPNAME";
            this.txtEQPName.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.txtEQPName.BindGridControl = this.gcList;
            this.txtEQPName.Location = new System.Drawing.Point(520, 68);
            this.txtEQPName.Name = "txtEQPName";
            this.txtEQPName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtEQPName.Properties.Appearance.Options.UseBackColor = true;
            this.txtEQPName.Size = new System.Drawing.Size(340, 20);
            this.txtEQPName.StyleController = this.layoutControl1;
            this.txtEQPName.TabIndex = 1;
            this.txtEQPName.Tag = "bind:EQPNAME,edittype:edit";
            this.txtEQPName.ValidationCheck = true;
            // 
            // txtEQP
            // 
            this.txtEQP.BindColumnName = "EQP";
            this.txtEQP.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.txtEQP.BindGridControl = this.gcList;
            this.txtEQP.BindPK = true;
            this.txtEQP.Location = new System.Drawing.Point(520, 44);
            this.txtEQP.Name = "txtEQP";
            this.txtEQP.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtEQP.Properties.Appearance.Options.UseBackColor = true;
            this.txtEQP.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEQP.Properties.MaxLength = 7;
            this.txtEQP.Size = new System.Drawing.Size(340, 20);
            this.txtEQP.StyleController = this.layoutControl1;
            this.txtEQP.TabIndex = 0;
            this.txtEQP.Tag = "bind:EQP,edittype:edit,pk:y";
            this.txtEQP.ValidationCheck = true;
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
            this.layoutControlGroup2.Size = new System.Drawing.Size(433, 442);
            this.layoutControlGroup2.Text = "List";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcList;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(409, 398);
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
            this.layoutControlItem4});
            this.layoutControlGroup3.Location = new System.Drawing.Point(438, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(426, 442);
            this.layoutControlGroup3.Text = "Detail";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtEQP;
            this.layoutControlItem2.CustomizationFormText = "OPERATIONCODE";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(402, 24);
            this.layoutControlItem2.Text = "EQP";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(55, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtEQPName;
            this.layoutControlItem3.CustomizationFormText = "OPERATIONNAME";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(402, 24);
            this.layoutControlItem3.Text = "EQPNAME";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(55, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.memRemarks;
            this.layoutControlItem8.CustomizationFormText = "REMARKS";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 125);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(402, 224);
            this.layoutControlItem8.Text = "REMARKS";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(55, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 349);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(402, 49);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.rdgUseFlag;
            this.layoutControlItem9.CustomizationFormText = "USEFLAG";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(0, 29);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(113, 29);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(402, 29);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.Text = "USEFLAG";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(55, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.gleWhloc;
            this.layoutControlItem5.CustomizationFormText = "EQPGRP";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(402, 24);
            this.layoutControlItem5.Text = "WHLOC";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(55, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtMaker;
            this.layoutControlItem4.CustomizationFormText = "MAKER";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(402, 24);
            this.layoutControlItem4.Text = "MAKER";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(55, 14);
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.CustomizationFormText = "splitterItem1";
            this.splitterItem1.Location = new System.Drawing.Point(433, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(5, 442);
            // 
            // MSTA212
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.Controls.Add(this.layoutControl1);
            this.Name = "MSTA212";
            this.ShowDeleteButton = false;
            this.ShowPrintButton = false;
            this.ShowRefreshButton = false;
            this.ShowSaveButton = false;
            this.ShowSearchButton = false;
            this.ShowStopButton = false;
            this.Text = "EQP Master";
            this.Load += new System.EventHandler(this.MSTA212_Load);
            this.Shown += new System.EventHandler(this.MSTA212_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtMaker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleWhloc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgUseFlag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memRemarks.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEQPName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEQP.Properties)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
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
        private IDAT.Devexpress.DXControl.IdatDxTextEdit txtEQPName;
        private IDAT.Devexpress.DXControl.IdatDxTextEdit txtEQP;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private IDAT.Devexpress.DXControl.IdatDxRadioGroup rdgUseFlag;
        private IDAT.Devexpress.DXControl.IdatDxMemoEdit memRemarks;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit gleWhloc;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private IDAT.Devexpress.DXControl.IdatDxTextEdit txtMaker;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}