namespace HAENGSUNG_HNSMES_UI.Forms.PRD.PopUp
{
    partial class POP_PRDA201
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
            this.btnSave = new IDAT.Devexpress.DXControl.IdatDxSimpleButton();
            this.btnClose = new IDAT.Devexpress.DXControl.IdatDxSimpleButton();
            this.gleUnitNo = new IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit();
            this.idatDxGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.txtUnitNo = new IDAT.Devexpress.DXControl.IdatDxTextEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtUnitNm = new IDAT.Devexpress.DXControl.IdatDxTextEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtWrkord = new IDAT.Devexpress.DXControl.IdatDxTextEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtPartNo = new IDAT.Devexpress.DXControl.IdatDxTextEdit();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gleUnitNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idatDxGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitNm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWrkord.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPartNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtPartNo);
            this.layoutControl1.Controls.Add(this.txtWrkord);
            this.layoutControl1.Controls.Add(this.txtUnitNm);
            this.layoutControl1.Controls.Add(this.txtUnitNo);
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.gleUnitNo);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(451, 207);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnSave
            // 
            this.btnSave.ButtonEditMode = IDAT.Devexpress.DXControl.ButtonTypes.None;
            this.btnSave.Image = global::HAENGSUNG_HNSMES_UI.Properties.Resources.button_save;
            this.btnSave.Location = new System.Drawing.Point(181, 132);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 39);
            this.btnSave.StyleController = this.layoutControl1;
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "SAVE";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.ButtonEditMode = IDAT.Devexpress.DXControl.ButtonTypes.None;
            this.btnClose.Image = global::HAENGSUNG_HNSMES_UI.Properties.Resources.button_close;
            this.btnClose.Location = new System.Drawing.Point(312, 132);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(127, 39);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gleUnitNo
            // 
            this.gleUnitNo.BindGridControl = null;
            this.gleUnitNo.Location = new System.Drawing.Point(65, 108);
            this.gleUnitNo.Name = "gleUnitNo";
            this.gleUnitNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gleUnitNo.Properties.View = this.idatDxGridLookUpEdit1View;
            this.gleUnitNo.Size = new System.Drawing.Size(374, 20);
            this.gleUnitNo.StyleController = this.layoutControl1;
            this.gleUnitNo.TabIndex = 5;
            // 
            // idatDxGridLookUpEdit1View
            // 
            this.idatDxGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.idatDxGridLookUpEdit1View.Name = "idatDxGridLookUpEdit1View";
            this.idatDxGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.idatDxGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.layoutControlItem2,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.emptySpaceItem1,
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(451, 207);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 120);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(169, 43);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gleUnitNo;
            this.layoutControlItem2.CustomizationFormText = "PRODDIVNAME";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(431, 24);
            this.layoutControlItem2.Text = "UNITNO";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(50, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnClose;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(300, 120);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(131, 43);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(131, 43);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(131, 43);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnSave;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(169, 120);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(131, 43);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(131, 43);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(131, 43);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 163);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(431, 24);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // txtUnitNo
            // 
            this.txtUnitNo.BindGridControl = null;
            this.txtUnitNo.Location = new System.Drawing.Point(65, 60);
            this.txtUnitNo.Name = "txtUnitNo";
            this.txtUnitNo.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtUnitNo.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtUnitNo.Properties.ReadOnly = true;
            this.txtUnitNo.Size = new System.Drawing.Size(374, 20);
            this.txtUnitNo.StyleController = this.layoutControl1;
            this.txtUnitNo.TabIndex = 12;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtUnitNo;
            this.layoutControlItem1.CustomizationFormText = "UNITNO";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(431, 24);
            this.layoutControlItem1.Text = "UNITNO";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(50, 14);
            // 
            // txtUnitNm
            // 
            this.txtUnitNm.BindGridControl = null;
            this.txtUnitNm.Location = new System.Drawing.Point(65, 84);
            this.txtUnitNm.Name = "txtUnitNm";
            this.txtUnitNm.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtUnitNm.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtUnitNm.Properties.ReadOnly = true;
            this.txtUnitNm.Size = new System.Drawing.Size(374, 20);
            this.txtUnitNm.StyleController = this.layoutControl1;
            this.txtUnitNm.TabIndex = 13;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtUnitNm;
            this.layoutControlItem3.CustomizationFormText = "UNITNM";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(431, 24);
            this.layoutControlItem3.Text = "UNITNM";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(50, 14);
            // 
            // txtWrkord
            // 
            this.txtWrkord.BindGridControl = null;
            this.txtWrkord.Location = new System.Drawing.Point(65, 12);
            this.txtWrkord.Name = "txtWrkord";
            this.txtWrkord.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtWrkord.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtWrkord.Properties.ReadOnly = true;
            this.txtWrkord.Size = new System.Drawing.Size(374, 20);
            this.txtWrkord.StyleController = this.layoutControl1;
            this.txtWrkord.TabIndex = 14;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtWrkord;
            this.layoutControlItem4.CustomizationFormText = "WRKORD";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(431, 24);
            this.layoutControlItem4.Text = "WRKORD";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(50, 14);
            // 
            // txtPartNo
            // 
            this.txtPartNo.BindGridControl = null;
            this.txtPartNo.Location = new System.Drawing.Point(65, 36);
            this.txtPartNo.Name = "txtPartNo";
            this.txtPartNo.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPartNo.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtPartNo.Properties.ReadOnly = true;
            this.txtPartNo.Size = new System.Drawing.Size(374, 20);
            this.txtPartNo.StyleController = this.layoutControl1;
            this.txtPartNo.TabIndex = 15;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtPartNo;
            this.layoutControlItem5.CustomizationFormText = "PARTNO";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(431, 24);
            this.layoutControlItem5.Text = "PARTNO";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(50, 14);
            // 
            // POP_PRDA201
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 207);
            this.Controls.Add(this.layoutControl1);
            this.CurrentDataTYPE = IDAT.Devexpress.FORM.UPDATEITEMTYPE.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IsButtonAuto = false;
            this.Name = "POP_PRDA201";
            this.ShowAllCloseButton = false;
            this.ShowCloseButton = false;
            this.ShowDeleteButton = false;
            this.ShowEditButton = false;
            this.ShowIcon = false;
            this.ShowInitButton = false;
            this.ShowInTaskbar = false;
            this.ShowNewbutton = false;
            this.ShowPrintButton = false;
            this.ShowRefreshButton = false;
            this.ShowSaveButton = false;
            this.ShowSearchButton = false;
            this.ShowStopButton = false;
            this.Text = "POP_PRDA201";
            this.Load += new System.EventHandler(this.POP_PRDA201_Load);
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gleUnitNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idatDxGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitNm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWrkord.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPartNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private IDAT.Devexpress.DXControl.IdatDxSimpleButton btnSave;
        private IDAT.Devexpress.DXControl.IdatDxSimpleButton btnClose;
        private IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit gleUnitNo;
        private DevExpress.XtraGrid.Views.Grid.GridView idatDxGridLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private IDAT.Devexpress.DXControl.IdatDxTextEdit txtUnitNm;
        private IDAT.Devexpress.DXControl.IdatDxTextEdit txtUnitNo;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private IDAT.Devexpress.DXControl.IdatDxTextEdit txtPartNo;
        private IDAT.Devexpress.DXControl.IdatDxTextEdit txtWrkord;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;

    }
}