namespace HAENGSUNG_HNSMES_UI.Forms.COM
{
    partial class COMPWDCHANGE
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnCancel = new IDAT.Devexpress.DXControl.IdatDxSimpleButton();
            this.btnChange = new IDAT.Devexpress.DXControl.IdatDxSimpleButton();
            this.txtCurrent = new DevExpress.XtraEditors.TextEdit();
            this.txtChange = new DevExpress.XtraEditors.TextEdit();
            this.txtRepeat = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChange.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRepeat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.btnChange);
            this.layoutControl1.Controls.Add(this.txtCurrent);
            this.layoutControl1.Controls.Add(this.txtChange);
            this.layoutControl1.Controls.Add(this.txtRepeat);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(308, 184);
            this.layoutControl1.TabIndex = 55;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnCancel
            // 
            this.btnCancel.ButtonEditMode = IDAT.Devexpress.DXControl.ButtonTypes.None;
            this.btnCancel.CausesValidation = false;
            this.btnCancel.Location = new System.Drawing.Point(215, 145);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 22);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnChange
            // 
            this.btnChange.ButtonEditMode = IDAT.Devexpress.DXControl.ButtonTypes.None;
            this.btnChange.Location = new System.Drawing.Point(135, 145);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(76, 22);
            this.btnChange.StyleController = this.layoutControl1;
            this.btnChange.TabIndex = 4;
            this.btnChange.Text = "CHANGE";
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // txtCurrent
            // 
            this.txtCurrent.EditValue = "";
            this.txtCurrent.EnterMoveNextControl = true;
            this.txtCurrent.Location = new System.Drawing.Point(141, 43);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtCurrent.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrent.Properties.Appearance.Options.UseBackColor = true;
            this.txtCurrent.Properties.Appearance.Options.UseFont = true;
            this.txtCurrent.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtCurrent.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtCurrent.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCurrent.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.txtCurrent.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtCurrent.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.txtCurrent.Properties.PasswordChar = '♣';
            this.txtCurrent.Properties.ValidateOnEnterKey = true;
            this.txtCurrent.Size = new System.Drawing.Size(150, 20);
            this.txtCurrent.StyleController = this.layoutControl1;
            this.txtCurrent.TabIndex = 0;
            this.txtCurrent.Tag = "T_USERMASTER.PASSWORD";
            this.txtCurrent.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // txtChange
            // 
            this.txtChange.EditValue = "";
            this.txtChange.EnterMoveNextControl = true;
            this.txtChange.Location = new System.Drawing.Point(141, 67);
            this.txtChange.Name = "txtChange";
            this.txtChange.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtChange.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChange.Properties.Appearance.Options.UseBackColor = true;
            this.txtChange.Properties.Appearance.Options.UseFont = true;
            this.txtChange.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtChange.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtChange.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtChange.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.txtChange.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtChange.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.txtChange.Properties.PasswordChar = '♣';
            this.txtChange.Properties.ValidateOnEnterKey = true;
            this.txtChange.Size = new System.Drawing.Size(150, 20);
            this.txtChange.StyleController = this.layoutControl1;
            this.txtChange.TabIndex = 1;
            this.txtChange.Tag = "T_USERMASTER.PASSWORD";
            this.txtChange.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // txtRepeat
            // 
            this.txtRepeat.EditValue = "";
            this.txtRepeat.EnterMoveNextControl = true;
            this.txtRepeat.Location = new System.Drawing.Point(141, 91);
            this.txtRepeat.Name = "txtRepeat";
            this.txtRepeat.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtRepeat.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRepeat.Properties.Appearance.Options.UseBackColor = true;
            this.txtRepeat.Properties.Appearance.Options.UseFont = true;
            this.txtRepeat.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtRepeat.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtRepeat.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtRepeat.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.txtRepeat.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtRepeat.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.txtRepeat.Properties.PasswordChar = '♣';
            this.txtRepeat.Properties.ValidateOnEnterKey = true;
            this.txtRepeat.Size = new System.Drawing.Size(150, 20);
            this.txtRepeat.StyleController = this.layoutControl1;
            this.txtRepeat.TabIndex = 2;
            this.txtRepeat.Tag = "T_USERMASTER.PASSWORD";
            this.txtRepeat.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceItemCaption.BackColor = System.Drawing.Color.Transparent;
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlGroup1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlGroup1.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup1.Size = new System.Drawing.Size(308, 184);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup2.AppearanceItemCaption.BackColor = System.Drawing.Color.Transparent;
            this.layoutControlGroup2.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlGroup2.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlGroup2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlGroup2.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlGroup2.CustomizationFormText = "Change Password";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(9, 9, 15, 9);
            this.layoutControlGroup2.Size = new System.Drawing.Size(302, 178);
            this.layoutControlGroup2.Text = "Change Password";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.BackColor = System.Drawing.Color.Transparent;
            this.layoutControlItem3.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlItem3.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem3.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem3.Control = this.txtRepeat;
            this.layoutControlItem3.CustomizationFormText = "Repeat Password";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(278, 24);
            this.layoutControlItem3.Text = "CONFIRM PASSWORD";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(121, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.BackColor = System.Drawing.Color.Transparent;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem2.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem2.Control = this.txtChange;
            this.layoutControlItem2.CustomizationFormText = "Change Password";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(278, 24);
            this.layoutControlItem2.Text = "PASSWORD";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(121, 14);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.BackColor = System.Drawing.Color.Transparent;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem1.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem1.Control = this.txtCurrent;
            this.layoutControlItem1.CustomizationFormText = "Current Password";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(278, 24);
            this.layoutControlItem1.Text = "CURRENT PASSWORD";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(121, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.AppearanceItemCaption.BackColor = System.Drawing.Color.Transparent;
            this.emptySpaceItem1.AppearanceItemCaption.Options.UseBackColor = true;
            this.emptySpaceItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            this.emptySpaceItem1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.emptySpaceItem1.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 72);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(1, 1);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(278, 30);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 102);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(118, 26);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnChange;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(118, 102);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(80, 26);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(80, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(80, 26);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnCancel;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(198, 102);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(80, 26);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(80, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(80, 26);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // COMPWDCHANGE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 184);
            this.Controls.Add(this.layoutControl1);
            this.Name = "COMPWDCHANGE";
            this.ShowIcon = false;
            this.Text = "";
            this.Load += new System.EventHandler(this.COMPWDCHANGE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChange.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRepeat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtRepeat;
        private DevExpress.XtraEditors.TextEdit txtChange;
        private DevExpress.XtraEditors.TextEdit txtCurrent;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private IDAT.Devexpress.DXControl.IdatDxSimpleButton btnCancel;
        private IDAT.Devexpress.DXControl.IdatDxSimpleButton btnChange;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}
