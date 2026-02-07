namespace HAENGSUNG_HNSMES_UI.Forms.COM
{
    partial class COMREGISTER
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(COMREGISTER));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnClose = new IDAT.Devexpress.DXControl.IdatDxSimpleButton();
            this.btnRegister = new IDAT.Devexpress.DXControl.IdatDxSimpleButton();
            this.btn_ChangePW = new DevExpress.XtraEditors.SimpleButton();
            this.gleUserClass = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtUserNameLocal = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.LayoutPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gleUserClass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNameLocal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.btnRegister);
            this.layoutControl1.Controls.Add(this.btn_ChangePW);
            this.layoutControl1.Controls.Add(this.gleUserClass);
            this.layoutControl1.Controls.Add(this.txtUserNameLocal);
            this.layoutControl1.Controls.Add(this.txtPassword);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(640, 418, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(529, 173);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnClose
            // 
            this.btnClose.ButtonEditMode = IDAT.Devexpress.DXControl.ButtonTypes.Close;
            this.btnClose.CausesValidation = false;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(421, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 36);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "Cancel";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.ButtonEditMode = IDAT.Devexpress.DXControl.ButtonTypes.Save;
            this.btnRegister.Image = ((System.Drawing.Image)(resources.GetObject("btnRegister.Image")));
            this.btnRegister.Location = new System.Drawing.Point(321, 12);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(96, 36);
            this.btnRegister.StyleController = this.layoutControl1;
            this.btnRegister.TabIndex = 27;
            this.btnRegister.Text = "OK";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btn_ChangePW
            // 
            this.btn_ChangePW.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ChangePW.Location = new System.Drawing.Point(418, 76);
            this.btn_ChangePW.Name = "btn_ChangePW";
            this.btn_ChangePW.Size = new System.Drawing.Size(99, 22);
            this.btn_ChangePW.StyleController = this.layoutControl1;
            this.btn_ChangePW.TabIndex = 26;
            this.btn_ChangePW.Text = "비밀번호 변경";
            this.btn_ChangePW.Click += new System.EventHandler(this.btn_ChangePW_Click);
            // 
            // gleUserClass
            // 
            this.gleUserClass.EnterMoveNextControl = true;
            this.gleUserClass.Location = new System.Drawing.Point(79, 102);
            this.gleUserClass.Name = "gleUserClass";
            this.gleUserClass.Properties.Appearance.Options.UseTextOptions = true;
            this.gleUserClass.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gleUserClass.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.gleUserClass.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.gleUserClass.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gleUserClass.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.gleUserClass.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.gleUserClass.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.gleUserClass.Properties.AutoComplete = false;
            this.gleUserClass.Properties.NullText = "";
            this.gleUserClass.Properties.PopupFormSize = new System.Drawing.Size(743, 0);
            this.gleUserClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gleUserClass.Properties.View = this.gridLookUpEdit1View;
            this.gleUserClass.Size = new System.Drawing.Size(438, 20);
            this.gleUserClass.StyleController = this.layoutControl1;
            this.gleUserClass.TabIndex = 21;
            this.gleUserClass.ToolTip = "보이기/숨기기 [키보드 : ALT+DOWN, F4] \r\n이전,다음 값 확인 [키보드 : UP,DOWN]\r\n마우스 휠 지원.";
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // txtUserNameLocal
            // 
            this.txtUserNameLocal.EnterMoveNextControl = true;
            this.txtUserNameLocal.Location = new System.Drawing.Point(79, 52);
            this.txtUserNameLocal.Name = "txtUserNameLocal";
            this.txtUserNameLocal.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtUserNameLocal.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtUserNameLocal.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUserNameLocal.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.txtUserNameLocal.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtUserNameLocal.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.txtUserNameLocal.Size = new System.Drawing.Size(438, 20);
            this.txtUserNameLocal.StyleController = this.layoutControl1;
            this.txtUserNameLocal.TabIndex = 11;
            // 
            // txtPassword
            // 
            this.txtPassword.EnterMoveNextControl = true;
            this.txtPassword.Location = new System.Drawing.Point(79, 76);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtPassword.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPassword.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtPassword.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Properties.ReadOnly = true;
            this.txtPassword.Size = new System.Drawing.Size(335, 20);
            this.txtPassword.StyleController = this.layoutControl1;
            this.txtPassword.TabIndex = 5;
            this.txtPassword.Tag = "bind:PASSWORD,edittype:edit";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.LayoutPassword,
            this.layoutControlItem14,
            this.layoutControlItem8,
            this.layoutControlItem10,
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(529, 173);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(309, 40);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // LayoutPassword
            // 
            this.LayoutPassword.Control = this.txtPassword;
            this.LayoutPassword.CustomizationFormText = "USERID_";
            this.LayoutPassword.Location = new System.Drawing.Point(0, 64);
            this.LayoutPassword.Name = "LayoutPassword";
            this.LayoutPassword.Size = new System.Drawing.Size(406, 26);
            this.LayoutPassword.Text = "비밀번호";
            this.LayoutPassword.TextSize = new System.Drawing.Size(64, 14);
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.btn_ChangePW;
            this.layoutControlItem14.CustomizationFormText = "layoutControlItem14";
            this.layoutControlItem14.Location = new System.Drawing.Point(406, 64);
            this.layoutControlItem14.MaxSize = new System.Drawing.Size(103, 26);
            this.layoutControlItem14.MinSize = new System.Drawing.Size(103, 26);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(103, 26);
            this.layoutControlItem14.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem14.Text = "layoutControlItem14";
            this.layoutControlItem14.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem14.TextToControlDistance = 0;
            this.layoutControlItem14.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtUserNameLocal;
            this.layoutControlItem8.CustomizationFormText = "사용자 이름";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(509, 24);
            this.layoutControlItem8.Text = "사용자 이름";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(64, 14);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.gleUserClass;
            this.layoutControlItem10.CustomizationFormText = "USERCLASS";
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 90);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(509, 63);
            this.layoutControlItem10.Text = "사용자 등급";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(64, 14);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnRegister;
            this.layoutControlItem1.CustomizationFormText = "OK";
            this.layoutControlItem1.Location = new System.Drawing.Point(309, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(100, 40);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(100, 40);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(100, 40);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "OK";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnClose;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(409, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(100, 40);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(100, 40);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(100, 40);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtPassword;
            this.layoutControlItem4.CustomizationFormText = "USERID_";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem4.Name = "LayoutPassword";
            this.layoutControlItem4.Size = new System.Drawing.Size(485, 25);
            this.layoutControlItem4.Text = "PASSWORD";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(119, 14);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.txtPassword;
            this.layoutControlItem11.CustomizationFormText = "USERID_";
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem11.Name = "LayoutPassword";
            this.layoutControlItem11.Size = new System.Drawing.Size(485, 25);
            this.layoutControlItem11.Text = "PASSWORD";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(119, 14);
            this.layoutControlItem11.TextToControlDistance = 5;
            // 
            // COMREGISTER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 173);
            this.Controls.Add(this.layoutControl1);
            this.Name = "COMREGISTER";
            this.Text = "COMREGISTER ";
            this.Load += new System.EventHandler(this.COMREGISTER_Load);
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gleUserClass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNameLocal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit txtUserNameLocal;
        private DevExpress.XtraEditors.GridLookUpEdit gleUserClass;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraEditors.SimpleButton btn_ChangePW;
        private DevExpress.XtraLayout.LayoutControlItem LayoutPassword;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private IDAT.Devexpress.DXControl.IdatDxSimpleButton btnClose;
        private IDAT.Devexpress.DXControl.IdatDxSimpleButton btnRegister;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}