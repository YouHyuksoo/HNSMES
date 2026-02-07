namespace HAENGSUNG_HNSMES_UI.Forms.MST
{
    partial class MSTA201
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
            this.rdgUseFlag = new IDAT.Devexpress.DXControl.IdatDxRadioGroup();
            this.gcList = new DevExpress.XtraGrid.GridControl();
            this.gvList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.memRemarks = new IDAT.Devexpress.DXControl.IdatDxMemoEdit();
            this.txtPlantName = new IDAT.Devexpress.DXControl.IdatDxTextEdit();
            this.txtPlant = new IDAT.Devexpress.DXControl.IdatDxTextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdgUseFlag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memRemarks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlantName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.rdgUseFlag);
            this.layoutControl1.Controls.Add(this.memRemarks);
            this.layoutControl1.Controls.Add(this.txtPlantName);
            this.layoutControl1.Controls.Add(this.txtPlant);
            this.layoutControl1.Controls.Add(this.gcList);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1801, 464, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(884, 462);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // rdgUseFlag
            // 
            this.rdgUseFlag.BindColumnName = "USEFLAG";
            this.rdgUseFlag.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.rdgUseFlag.BindGridControl = this.gcList;
            this.rdgUseFlag.EditValue = "Y";
            this.rdgUseFlag.IsYesNoType = true;
            this.rdgUseFlag.Location = new System.Drawing.Point(666, 92);
            this.rdgUseFlag.Name = "rdgUseFlag";
            this.rdgUseFlag.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.rdgUseFlag.Properties.Appearance.Options.UseBackColor = true;
            this.rdgUseFlag.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Y", "Yes"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("N", "No")});
            this.rdgUseFlag.Size = new System.Drawing.Size(194, 25);
            this.rdgUseFlag.StyleController = this.layoutControl1;
            this.rdgUseFlag.TabIndex = 12;
            this.rdgUseFlag.Tag = "bind:USEFLAG,edittype:edit";
            this.rdgUseFlag.ValidationCheck = true;
            // 
            // gcList
            // 
            this.gcList.Location = new System.Drawing.Point(24, 44);
            this.gcList.MainView = this.gvList;
            this.gcList.Name = "gcList";
            this.gcList.Size = new System.Drawing.Size(537, 394);
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
            // memRemarks
            // 
            this.memRemarks.BindColumnName = "REMARKS";
            this.memRemarks.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.memRemarks.BindGridControl = this.gcList;
            this.memRemarks.CausesValidation = false;
            this.memRemarks.Location = new System.Drawing.Point(666, 121);
            this.memRemarks.Name = "memRemarks";
            this.memRemarks.Size = new System.Drawing.Size(194, 183);
            this.memRemarks.StyleController = this.layoutControl1;
            this.memRemarks.TabIndex = 11;
            this.memRemarks.Tag = "bind:REMARKS,edittype:edit";
            this.memRemarks.UseOptimizedRendering = true;
            // 
            // txtPlantName
            // 
            this.txtPlantName.BindColumnName = "PLANTNAME";
            this.txtPlantName.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.txtPlantName.BindGridControl = this.gcList;
            this.txtPlantName.Location = new System.Drawing.Point(666, 68);
            this.txtPlantName.Name = "txtPlantName";
            this.txtPlantName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtPlantName.Properties.Appearance.Options.UseBackColor = true;
            this.txtPlantName.Size = new System.Drawing.Size(194, 20);
            this.txtPlantName.StyleController = this.layoutControl1;
            this.txtPlantName.TabIndex = 6;
            this.txtPlantName.Tag = "bind:PLANTNAME,edittype:edit";
            this.txtPlantName.ValidationCheck = true;
            // 
            // txtPlant
            // 
            this.txtPlant.BindColumnName = "PLANT";
            this.txtPlant.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.txtPlant.BindGridControl = this.gcList;
            this.txtPlant.BindPK = true;
            this.txtPlant.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtPlant.Location = new System.Drawing.Point(666, 44);
            this.txtPlant.Name = "txtPlant";
            this.txtPlant.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtPlant.Properties.Appearance.Options.UseBackColor = true;
            this.txtPlant.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPlant.Properties.MaxLength = 4;
            this.txtPlant.Size = new System.Drawing.Size(194, 20);
            this.txtPlant.StyleController = this.layoutControl1;
            this.txtPlant.TabIndex = 5;
            this.txtPlant.Tag = "bind:PLANT,edittype:edit,pk:y";
            this.txtPlant.ValidationCheck = true;
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
            this.layoutControlGroup2.Size = new System.Drawing.Size(565, 442);
            this.layoutControlGroup2.Text = "List";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcList;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(541, 398);
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
            this.layoutControlItem9});
            this.layoutControlGroup3.Location = new System.Drawing.Point(570, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(294, 442);
            this.layoutControlGroup3.Text = "Detail";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtPlant;
            this.layoutControlItem2.CustomizationFormText = "OPERATIONCODE";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(270, 24);
            this.layoutControlItem2.Text = "PLANT";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(69, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtPlantName;
            this.layoutControlItem3.CustomizationFormText = "OPERATIONNAME";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(270, 24);
            this.layoutControlItem3.Text = "PLANTNAME";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(69, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.memRemarks;
            this.layoutControlItem8.CustomizationFormText = "REMARKS";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 77);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(270, 187);
            this.layoutControlItem8.Text = "REMARKS";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(69, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 264);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(270, 134);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.rdgUseFlag;
            this.layoutControlItem9.CustomizationFormText = "USEFLAG";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(0, 29);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(127, 29);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(270, 29);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.Text = "USEFLAG";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(69, 14);
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.CustomizationFormText = "splitterItem1";
            this.splitterItem1.Location = new System.Drawing.Point(565, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(5, 442);
            // 
            // MSTA201
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "MSTA201";
            this.ShowDeleteButton = false;
            this.ShowPrintButton = false;
            this.ShowRefreshButton = false;
            this.ShowSaveButton = false;
            this.ShowSearchButton = false;
            this.ShowStopButton = false;
            this.Text = "Plant Master";
            this.Load += new System.EventHandler(this.MSTA201_Load);
            this.Shown += new System.EventHandler(this.MSTA201_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdgUseFlag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memRemarks.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlantName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
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
        private IDAT.Devexpress.DXControl.IdatDxTextEdit txtPlantName;
        private IDAT.Devexpress.DXControl.IdatDxTextEdit txtPlant;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private IDAT.Devexpress.DXControl.IdatDxRadioGroup rdgUseFlag;
        private IDAT.Devexpress.DXControl.IdatDxMemoEdit memRemarks;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}