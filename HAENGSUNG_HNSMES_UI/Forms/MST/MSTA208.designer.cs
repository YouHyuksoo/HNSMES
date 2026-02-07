namespace HAENGSUNG_HNSMES_UI.Forms.MST
{
    partial class MSTA208
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
            this.btnImage = new IDAT.Devexpress.DXControl.IdatDxSimpleButton();
            this.picImage = new IDAT.Devexpress.DXControl.IdatDxPictureEdit();
            this.gcList = new DevExpress.XtraGrid.GridControl();
            this.gvList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gleDefType = new IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.rdoGrUse = new IDAT.Devexpress.DXControl.IdatDxRadioGroup();
            this.memRemarks = new IDAT.Devexpress.DXControl.IdatDxMemoEdit();
            this.txtDefectName = new IDAT.Devexpress.DXControl.IdatDxTextEdit();
            this.txtDefect = new IDAT.Devexpress.DXControl.IdatDxTextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleDefType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoGrUse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memRemarks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefectName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefect.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnImage);
            this.layoutControl1.Controls.Add(this.picImage);
            this.layoutControl1.Controls.Add(this.gleDefType);
            this.layoutControl1.Controls.Add(this.rdoGrUse);
            this.layoutControl1.Controls.Add(this.memRemarks);
            this.layoutControl1.Controls.Add(this.txtDefectName);
            this.layoutControl1.Controls.Add(this.txtDefect);
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
            // btnImage
            // 
            this.btnImage.ButtonEditMode = IDAT.Devexpress.DXControl.ButtonTypes.None;
            this.btnImage.Location = new System.Drawing.Point(458, 261);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(402, 22);
            this.btnImage.StyleController = this.layoutControl1;
            this.btnImage.TabIndex = 17;
            this.btnImage.Text = "Image";
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // picImage
            // 
            this.picImage.BindColumnName = "IMAGE";
            this.picImage.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.picImage.BindGridControl = this.gcList;
            this.picImage.Location = new System.Drawing.Point(536, 145);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(324, 112);
            this.picImage.StyleController = this.layoutControl1;
            this.picImage.TabIndex = 16;
            // 
            // gcList
            // 
            this.gcList.Location = new System.Drawing.Point(24, 44);
            this.gcList.MainView = this.gvList;
            this.gcList.Name = "gcList";
            this.gcList.Size = new System.Drawing.Size(401, 394);
            this.gcList.TabIndex = 4;
            this.gcList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvList});
            // 
            // gvList
            // 
            this.gvList.GridControl = this.gcList;
            this.gvList.Name = "gvList";
            // 
            // gleDefType
            // 
            this.gleDefType.BindColumnName = "DEFECTTYPE";
            this.gleDefType.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.gleDefType.BindGridControl = this.gcList;
            this.gleDefType.CausesValidation = false;
            this.gleDefType.Location = new System.Drawing.Point(536, 92);
            this.gleDefType.Name = "gleDefType";
            this.gleDefType.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.gleDefType.Properties.Appearance.Options.UseBackColor = true;
            this.gleDefType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gleDefType.Properties.View = this.gridView3;
            this.gleDefType.Size = new System.Drawing.Size(324, 20);
            this.gleDefType.StyleController = this.layoutControl1;
            this.gleDefType.TabIndex = 15;
            this.gleDefType.Tag = "";
            // 
            // gridView3
            // 
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // rdoGrUse
            // 
            this.rdoGrUse.BindColumnName = "USEFLAG";
            this.rdoGrUse.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.rdoGrUse.BindGridControl = this.gcList;
            this.rdoGrUse.EditValue = "Y";
            this.rdoGrUse.IsYesNoType = true;
            this.rdoGrUse.Location = new System.Drawing.Point(536, 116);
            this.rdoGrUse.Name = "rdoGrUse";
            this.rdoGrUse.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.rdoGrUse.Properties.Appearance.Options.UseBackColor = true;
            this.rdoGrUse.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Y", "Yes"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("N", "No")});
            this.rdoGrUse.Size = new System.Drawing.Size(324, 25);
            this.rdoGrUse.StyleController = this.layoutControl1;
            this.rdoGrUse.TabIndex = 12;
            this.rdoGrUse.Tag = "bind:USEFLAG,edittype:edit";
            this.rdoGrUse.ValidationCheck = true;
            // 
            // memRemarks
            // 
            this.memRemarks.BindColumnName = "REMARKS";
            this.memRemarks.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.memRemarks.BindGridControl = this.gcList;
            this.memRemarks.CausesValidation = false;
            this.memRemarks.Location = new System.Drawing.Point(536, 287);
            this.memRemarks.Name = "memRemarks";
            this.memRemarks.Size = new System.Drawing.Size(324, 131);
            this.memRemarks.StyleController = this.layoutControl1;
            this.memRemarks.TabIndex = 11;
            this.memRemarks.Tag = "";
            this.memRemarks.UseOptimizedRendering = true;
            // 
            // txtDefectName
            // 
            this.txtDefectName.BindColumnName = "DEFECTNAME";
            this.txtDefectName.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.txtDefectName.BindGridControl = this.gcList;
            this.txtDefectName.Location = new System.Drawing.Point(536, 68);
            this.txtDefectName.Name = "txtDefectName";
            this.txtDefectName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtDefectName.Properties.Appearance.Options.UseBackColor = true;
            this.txtDefectName.Size = new System.Drawing.Size(324, 20);
            this.txtDefectName.StyleController = this.layoutControl1;
            this.txtDefectName.TabIndex = 6;
            this.txtDefectName.Tag = "";
            this.txtDefectName.ValidationCheck = true;
            // 
            // txtDefect
            // 
            this.txtDefect.BindColumnName = "DEFECT";
            this.txtDefect.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.txtDefect.BindGridControl = this.gcList;
            this.txtDefect.BindPK = true;
            this.txtDefect.Location = new System.Drawing.Point(536, 44);
            this.txtDefect.Name = "txtDefect";
            this.txtDefect.Size = new System.Drawing.Size(324, 20);
            this.txtDefect.StyleController = this.layoutControl1;
            this.txtDefect.TabIndex = 5;
            this.txtDefect.Tag = "";
            this.txtDefect.ValidationCheck = true;
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
            this.layoutControlGroup2.Size = new System.Drawing.Size(429, 442);
            this.layoutControlGroup2.Text = "List";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcList;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(405, 398);
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
            this.emptySpaceItem1,
            this.layoutControlItem9,
            this.layoutControlItem11,
            this.layoutControlItem8,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup3.Location = new System.Drawing.Point(434, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(430, 442);
            this.layoutControlGroup3.Text = "Detail";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtDefect;
            this.layoutControlItem2.CustomizationFormText = "DEFECT";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(406, 24);
            this.layoutControlItem2.Text = "DEFECT";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(75, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtDefectName;
            this.layoutControlItem3.CustomizationFormText = "DEFECTNAME";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(406, 24);
            this.layoutControlItem3.Text = "DEFECTNAME";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(75, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 378);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(406, 20);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.rdoGrUse;
            this.layoutControlItem9.CustomizationFormText = "USEFLAG";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(0, 29);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(133, 29);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(406, 29);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.Text = "USEFLAG";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(75, 14);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.gleDefType;
            this.layoutControlItem11.CustomizationFormText = "DEFECTTYPE";
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(406, 24);
            this.layoutControlItem11.Text = "DEFECTTYPE";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(75, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.memRemarks;
            this.layoutControlItem8.CustomizationFormText = "REMARKS";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 243);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(406, 135);
            this.layoutControlItem8.Text = "REMARKS";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(75, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.picImage;
            this.layoutControlItem4.CustomizationFormText = "IMAGE";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 101);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(406, 116);
            this.layoutControlItem4.Text = "IMAGE";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(75, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnImage;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 217);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(406, 26);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.CustomizationFormText = "splitterItem1";
            this.splitterItem1.Location = new System.Drawing.Point(429, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(5, 442);
            // 
            // MSTA208
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.Controls.Add(this.layoutControl1);
            this.Name = "MSTA208";
            this.ShowDeleteButton = false;
            this.ShowPrintButton = false;
            this.ShowRefreshButton = false;
            this.ShowStopButton = false;
            this.Text = "Defect Master";
            this.Load += new System.EventHandler(this.MSTA208_Load);
            this.Shown += new System.EventHandler(this.MSTA208_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleDefType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoGrUse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memRemarks.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefectName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefect.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
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
        private IDAT.Devexpress.DXControl.IdatDxTextEdit txtDefectName;
        private IDAT.Devexpress.DXControl.IdatDxTextEdit txtDefect;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private IDAT.Devexpress.DXControl.IdatDxRadioGroup rdoGrUse;
        private IDAT.Devexpress.DXControl.IdatDxMemoEdit memRemarks;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit gleDefType;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private IDAT.Devexpress.DXControl.IdatDxSimpleButton btnImage;
        private IDAT.Devexpress.DXControl.IdatDxPictureEdit picImage;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}