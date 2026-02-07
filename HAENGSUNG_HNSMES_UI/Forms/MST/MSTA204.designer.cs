namespace HAENGSUNG_HNSMES_UI.Forms.MST
{
    partial class MSTA204
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
            this.spnSeq = new IDAT.Devexpress.DXControl.IdatDxSpinEdit();
            this.gcList = new DevExpress.XtraGrid.GridControl();
            this.gvList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.rdgReasonType = new IDAT.Devexpress.DXControl.IdatDxRadioGroup();
            this.rdgReason = new IDAT.Devexpress.DXControl.IdatDxRadioGroup();
            this.rdgUseFlag = new IDAT.Devexpress.DXControl.IdatDxRadioGroup();
            this.memRemarks = new IDAT.Devexpress.DXControl.IdatDxMemoEdit();
            this.txtReason = new IDAT.Devexpress.DXControl.IdatDxTextEdit();
            this.txtReasonCode = new IDAT.Devexpress.DXControl.IdatDxTextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnSeq.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgReasonType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgReason.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgUseFlag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memRemarks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReason.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReasonCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.spnSeq);
            this.layoutControl1.Controls.Add(this.rdgReasonType);
            this.layoutControl1.Controls.Add(this.rdgReason);
            this.layoutControl1.Controls.Add(this.rdgUseFlag);
            this.layoutControl1.Controls.Add(this.memRemarks);
            this.layoutControl1.Controls.Add(this.txtReason);
            this.layoutControl1.Controls.Add(this.txtReasonCode);
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
            // spnSeq
            // 
            this.spnSeq.BindColumnName = "DISPSEQ";
            this.spnSeq.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.spnSeq.BindGridControl = this.gcList;
            this.spnSeq.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spnSeq.Location = new System.Drawing.Point(539, 92);
            this.spnSeq.Name = "spnSeq";
            this.spnSeq.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.spnSeq.Properties.Appearance.Options.UseBackColor = true;
            this.spnSeq.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spnSeq.Properties.Mask.EditMask = "n0";
            this.spnSeq.Size = new System.Drawing.Size(321, 20);
            this.spnSeq.StyleController = this.layoutControl1;
            this.spnSeq.TabIndex = 7;
            this.spnSeq.Tag = "bind:DISPSEQ,edittype:edit";
            // 
            // gcList
            // 
            this.gcList.Location = new System.Drawing.Point(24, 71);
            this.gcList.MainView = this.gvList;
            this.gcList.Name = "gcList";
            this.gcList.Size = new System.Drawing.Size(402, 367);
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
            // rdgReasonType
            // 
            this.rdgReasonType.BindColumnName = "REASONTYPE";
            this.rdgReasonType.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.rdgReasonType.BindGridControl = this.gcList;
            this.rdgReasonType.EditValue = ((short)(1));
            this.rdgReasonType.Location = new System.Drawing.Point(539, 116);
            this.rdgReasonType.Name = "rdgReasonType";
            this.rdgReasonType.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.rdgReasonType.Properties.Appearance.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdgReasonType.Properties.Appearance.Options.UseBackColor = true;
            this.rdgReasonType.Properties.Appearance.Options.UseFont = true;
            this.rdgReasonType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(new decimal(new int[] {
                            1,
                            0,
                            0,
                            0}), "RETURN"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(new decimal(new int[] {
                            2,
                            0,
                            0,
                            0}), "DISCARD"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(new decimal(new int[] {
                            3,
                            0,
                            0,
                            0}), "DOWNTIME"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(new decimal(new int[] {
                            4,
                            0,
                            0,
                            0}), "REPAIR")});
            this.rdgReasonType.Size = new System.Drawing.Size(321, 25);
            this.rdgReasonType.StyleController = this.layoutControl1;
            this.rdgReasonType.TabIndex = 8;
            this.rdgReasonType.Tag = "bind:REASONTYPE,edittype:edit";
            this.rdgReasonType.ValidationCheck = true;
            // 
            // rdgReason
            // 
            this.rdgReason.BindGridControl = null;
            this.rdgReason.EditValue = ((short)(1));
            this.rdgReason.IsUseIDATFrameWorkControl = false;
            this.rdgReason.Location = new System.Drawing.Point(104, 44);
            this.rdgReason.Name = "rdgReason";
            this.rdgReason.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(new decimal(new int[] {
                            1,
                            0,
                            0,
                            0}), "RETURN"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(new decimal(new int[] {
                            2,
                            0,
                            0,
                            0}), "DISCARD"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(new decimal(new int[] {
                            3,
                            0,
                            0,
                            0}), "DOWNTIME"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(new decimal(new int[] {
                            4,
                            0,
                            0,
                            0}), "REPAIR")});
            this.rdgReason.Size = new System.Drawing.Size(322, 23);
            this.rdgReason.StyleController = this.layoutControl1;
            this.rdgReason.TabIndex = 17;
            this.rdgReason.SelectedIndexChanged += new System.EventHandler(this.rdogrReason_SelectedIndexChanged);
            // 
            // rdgUseFlag
            // 
            this.rdgUseFlag.BindColumnName = "USEFLAG";
            this.rdgUseFlag.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.rdgUseFlag.BindGridControl = this.gcList;
            this.rdgUseFlag.EditValue = "Y";
            this.rdgUseFlag.IsYesNoType = true;
            this.rdgUseFlag.Location = new System.Drawing.Point(539, 145);
            this.rdgUseFlag.Name = "rdgUseFlag";
            this.rdgUseFlag.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.rdgUseFlag.Properties.Appearance.Options.UseBackColor = true;
            this.rdgUseFlag.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Y", "Yes"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("N", "No")});
            this.rdgUseFlag.Size = new System.Drawing.Size(321, 25);
            this.rdgUseFlag.StyleController = this.layoutControl1;
            this.rdgUseFlag.TabIndex = 9;
            this.rdgUseFlag.Tag = "bind:USEFLAG,edittype:edit";
            this.rdgUseFlag.ValidationCheck = true;
            // 
            // memRemarks
            // 
            this.memRemarks.BindColumnName = "REMARKS";
            this.memRemarks.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.memRemarks.BindGridControl = this.gcList;
            this.memRemarks.CausesValidation = false;
            this.memRemarks.Location = new System.Drawing.Point(539, 174);
            this.memRemarks.Name = "memRemarks";
            this.memRemarks.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.memRemarks.Properties.Appearance.Options.UseBackColor = true;
            this.memRemarks.Size = new System.Drawing.Size(321, 213);
            this.memRemarks.StyleController = this.layoutControl1;
            this.memRemarks.TabIndex = 10;
            this.memRemarks.Tag = "bind:REMARKS,edittype:edit";
            this.memRemarks.UseOptimizedRendering = true;
            // 
            // txtReason
            // 
            this.txtReason.BindColumnName = "REASON";
            this.txtReason.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.txtReason.BindGridControl = this.gcList;
            this.txtReason.Location = new System.Drawing.Point(539, 68);
            this.txtReason.Name = "txtReason";
            this.txtReason.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtReason.Properties.Appearance.Options.UseBackColor = true;
            this.txtReason.Properties.MaxLength = 300;
            this.txtReason.Size = new System.Drawing.Size(321, 20);
            this.txtReason.StyleController = this.layoutControl1;
            this.txtReason.TabIndex = 6;
            this.txtReason.Tag = "bind:REASON,edittype:edit";
            this.txtReason.ValidationCheck = true;
            // 
            // txtReasonCode
            // 
            this.txtReasonCode.BindColumnName = "REASONCODE";
            this.txtReasonCode.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.txtReasonCode.BindGridControl = this.gcList;
            this.txtReasonCode.BindPK = true;
            this.txtReasonCode.Location = new System.Drawing.Point(539, 44);
            this.txtReasonCode.Name = "txtReasonCode";
            this.txtReasonCode.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtReasonCode.Properties.Appearance.Options.UseBackColor = true;
            this.txtReasonCode.Properties.MaxLength = 5;
            this.txtReasonCode.Size = new System.Drawing.Size(321, 20);
            this.txtReasonCode.StyleController = this.layoutControl1;
            this.txtReasonCode.TabIndex = 5;
            this.txtReasonCode.Tag = "bind:REASONCODE,edittype:edit,pk:y";
            this.txtReasonCode.ValidationCheck = true;
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
            this.layoutControlItem1,
            this.layoutControlItem4});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(430, 442);
            this.layoutControlGroup2.Text = "List";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcList;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 27);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(406, 371);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.rdgReason;
            this.layoutControlItem4.CustomizationFormText = "INSPTYPE";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(0, 27);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(146, 27);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(406, 27);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "TYPE";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(77, 14);
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
            this.layoutControlItem6,
            this.layoutControlItem5});
            this.layoutControlGroup3.Location = new System.Drawing.Point(435, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(429, 442);
            this.layoutControlGroup3.Text = "Detail";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtReasonCode;
            this.layoutControlItem2.CustomizationFormText = "REASONCODE";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(405, 24);
            this.layoutControlItem2.Text = "REASONCODE";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(77, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtReason;
            this.layoutControlItem3.CustomizationFormText = "OPERATIONNAME";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(405, 24);
            this.layoutControlItem3.Text = "REASON";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(77, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.memRemarks;
            this.layoutControlItem8.CustomizationFormText = "REMARKS";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 130);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(405, 217);
            this.layoutControlItem8.Text = "REMARKS";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(77, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 347);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(405, 51);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.rdgUseFlag;
            this.layoutControlItem9.CustomizationFormText = "USEFLAG";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 101);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(0, 29);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(135, 29);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(405, 29);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.Text = "USEFLAG";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(77, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.rdgReasonType;
            this.layoutControlItem6.CustomizationFormText = "INPUTTYPE";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(0, 29);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(135, 29);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(405, 29);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "TYPE";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(77, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.spnSeq;
            this.layoutControlItem5.CustomizationFormText = "DISPSEQ";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(405, 24);
            this.layoutControlItem5.Text = "DISPSEQ";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(77, 14);
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.CustomizationFormText = "splitterItem1";
            this.splitterItem1.Location = new System.Drawing.Point(430, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(5, 442);
            // 
            // MSTA204
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.Controls.Add(this.layoutControl1);
            this.Name = "MSTA204";
            this.ShowDeleteButton = false;
            this.ShowPrintButton = false;
            this.ShowRefreshButton = false;
            this.ShowSaveButton = false;
            this.ShowStopButton = false;
            this.Text = "MSTA204";
            this.Load += new System.EventHandler(this.MSTA204_Load);
            this.Shown += new System.EventHandler(this.MSTA204_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spnSeq.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgReasonType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgReason.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgUseFlag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memRemarks.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReason.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReasonCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
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
        private IDAT.Devexpress.DXControl.IdatDxTextEdit txtReason;
        private IDAT.Devexpress.DXControl.IdatDxTextEdit txtReasonCode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private IDAT.Devexpress.DXControl.IdatDxRadioGroup rdgUseFlag;
        private IDAT.Devexpress.DXControl.IdatDxMemoEdit memRemarks;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private IDAT.Devexpress.DXControl.IdatDxRadioGroup rdgReason;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private IDAT.Devexpress.DXControl.IdatDxRadioGroup rdgReasonType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private IDAT.Devexpress.DXControl.IdatDxSpinEdit spnSeq;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}