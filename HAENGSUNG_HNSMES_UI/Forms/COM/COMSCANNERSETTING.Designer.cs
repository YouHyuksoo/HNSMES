namespace HAENGSUNG_HNSMES_UI.Forms.COM
{
    partial class COMSCANNERSETTING
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(COMSCANNERSETTING));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.radType = new DevExpress.XtraEditors.RadioGroup();
            this.cboStopBit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboDataBit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboParityBit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboBaudRate = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboCommPort = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStopBit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDataBit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboParityBit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBaudRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCommPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.radType);
            this.layoutControl1.Controls.Add(this.cboStopBit);
            this.layoutControl1.Controls.Add(this.cboDataBit);
            this.layoutControl1.Controls.Add(this.cboParityBit);
            this.layoutControl1.Controls.Add(this.cboBaudRate);
            this.layoutControl1.Controls.Add(this.cboCommPort);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.btnOk);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(304, 295);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // radType
            // 
            this.radType.EditValue = "SCANNER1";
            this.radType.Location = new System.Drawing.Point(80, 62);
            this.radType.Name = "radType";
            this.radType.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke;
            this.radType.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.radType.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.radType.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.radType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("SCANNER1", "BASE"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("SCANNER2", "SUB"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("SCANNER3", "TESTER"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("SCANNER4", "INSP(Micro)")});
            this.radType.Properties.NullText = "SCANNER1";
            this.radType.Size = new System.Drawing.Size(212, 83);
            this.radType.StyleController = this.layoutControl1;
            this.radType.TabIndex = 7;
            this.radType.ToolTip = "마우스 기능 : 텍스트 / 이미지 클릭\r\n키보드 : UP,DOWN,LEFT,RIGHT";
            this.radType.SelectedIndexChanged += new System.EventHandler(this.radType_SelectedIndexChanged);
            // 
            // cboStopBit
            // 
            this.cboStopBit.Location = new System.Drawing.Point(80, 245);
            this.cboStopBit.Name = "cboStopBit";
            this.cboStopBit.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.cboStopBit.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.cboStopBit.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboStopBit.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.cboStopBit.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.cboStopBit.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.cboStopBit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", 15, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.cboStopBit.Size = new System.Drawing.Size(212, 20);
            this.cboStopBit.StyleController = this.layoutControl1;
            this.cboStopBit.TabIndex = 6;
            this.cboStopBit.ToolTip = "보이기/숨기기 [키보드 : ALT+DOWN, F4] \r\n이전,다음 값 확인 [키보드 : UP,DOWN]\r\n마우스 휠 지원.";
            // 
            // cboDataBit
            // 
            this.cboDataBit.Location = new System.Drawing.Point(80, 221);
            this.cboDataBit.Name = "cboDataBit";
            this.cboDataBit.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.cboDataBit.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.cboDataBit.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboDataBit.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.cboDataBit.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.cboDataBit.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.cboDataBit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", 15, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.cboDataBit.Size = new System.Drawing.Size(212, 20);
            this.cboDataBit.StyleController = this.layoutControl1;
            this.cboDataBit.TabIndex = 6;
            this.cboDataBit.ToolTip = "보이기/숨기기 [키보드 : ALT+DOWN, F4] \r\n이전,다음 값 확인 [키보드 : UP,DOWN]\r\n마우스 휠 지원.";
            // 
            // cboParityBit
            // 
            this.cboParityBit.Location = new System.Drawing.Point(80, 197);
            this.cboParityBit.Name = "cboParityBit";
            this.cboParityBit.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.cboParityBit.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.cboParityBit.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboParityBit.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.cboParityBit.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.cboParityBit.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.cboParityBit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", 15, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.cboParityBit.Size = new System.Drawing.Size(212, 20);
            this.cboParityBit.StyleController = this.layoutControl1;
            this.cboParityBit.TabIndex = 6;
            this.cboParityBit.ToolTip = "보이기/숨기기 [키보드 : ALT+DOWN, F4] \r\n이전,다음 값 확인 [키보드 : UP,DOWN]\r\n마우스 휠 지원.";
            // 
            // cboBaudRate
            // 
            this.cboBaudRate.Location = new System.Drawing.Point(80, 173);
            this.cboBaudRate.Name = "cboBaudRate";
            this.cboBaudRate.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.cboBaudRate.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.cboBaudRate.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboBaudRate.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.cboBaudRate.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.cboBaudRate.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.cboBaudRate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", 15, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.cboBaudRate.Size = new System.Drawing.Size(212, 20);
            this.cboBaudRate.StyleController = this.layoutControl1;
            this.cboBaudRate.TabIndex = 6;
            this.cboBaudRate.ToolTip = "보이기/숨기기 [키보드 : ALT+DOWN, F4] \r\n이전,다음 값 확인 [키보드 : UP,DOWN]\r\n마우스 휠 지원.";
            // 
            // cboCommPort
            // 
            this.cboCommPort.Location = new System.Drawing.Point(80, 149);
            this.cboCommPort.Name = "cboCommPort";
            this.cboCommPort.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.cboCommPort.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.cboCommPort.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboCommPort.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.cboCommPort.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.cboCommPort.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.cboCommPort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", 15, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "", null, null, true)});
            this.cboCommPort.Size = new System.Drawing.Size(212, 20);
            this.cboCommPort.StyleController = this.layoutControl1;
            this.cboCommPort.TabIndex = 5;
            this.cboCommPort.ToolTip = "보이기/숨기기 [키보드 : ALT+DOWN, F4] \r\n이전,다음 값 확인 [키보드 : UP,DOWN]\r\n마우스 휠 지원.";
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(196, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 46);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Tag = "cancel";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.Location = new System.Drawing.Point(96, 12);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(96, 46);
            this.btnOk.StyleController = this.layoutControl1;
            this.btnOk.TabIndex = 2;
            this.btnOk.Tag = "ok";
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.emptySpaceItem2,
            this.layoutControlItem8,
            this.emptySpaceItem1,
            this.layoutControlItem5,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(304, 295);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.cboCommPort;
            this.layoutControlItem1.CustomizationFormText = "COMMPORT";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 137);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(284, 24);
            this.layoutControlItem1.Text = "COMMPORT";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(65, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cboBaudRate;
            this.layoutControlItem2.CustomizationFormText = "BAUDRATE";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 161);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(284, 24);
            this.layoutControlItem2.Text = "BAUDRATE";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(65, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.cboParityBit;
            this.layoutControlItem3.CustomizationFormText = "PARITYBIT";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 185);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(284, 24);
            this.layoutControlItem3.Text = "PARITYBIT";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(65, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.cboDataBit;
            this.layoutControlItem6.CustomizationFormText = "DATABIT";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 209);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(284, 24);
            this.layoutControlItem6.Text = "DATABIT";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(65, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.cboStopBit;
            this.layoutControlItem7.CustomizationFormText = "STOPBIT";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 233);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(284, 24);
            this.layoutControlItem7.Text = "STOPBIT";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(65, 14);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 257);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(284, 18);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.radType;
            this.layoutControlItem8.CustomizationFormText = "TYPE";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(284, 87);
            this.layoutControlItem8.Text = "TYPE";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(65, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "item0";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "item0";
            this.emptySpaceItem1.Size = new System.Drawing.Size(84, 50);
            this.emptySpaceItem1.Text = "item0";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnCancel;
            this.layoutControlItem5.CustomizationFormText = "Cancel";
            this.layoutControlItem5.Location = new System.Drawing.Point(184, 0);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(100, 50);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(100, 50);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(100, 50);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "Cancel";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnOk;
            this.layoutControlItem4.CustomizationFormText = "OK";
            this.layoutControlItem4.Location = new System.Drawing.Point(84, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(100, 50);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(100, 50);
            this.layoutControlItem4.Name = "layoutControlItem1";
            this.layoutControlItem4.Size = new System.Drawing.Size(100, 50);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "OK";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // COMSCANNERSETTING
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 295);
            this.ControlBox = false;
            this.Controls.Add(this.layoutControl1);
            this.Name = "COMSCANNERSETTING";
            this.Text = "SCANNERSETTING  ";
            this.Load += new System.EventHandler(this.COM02_Load);
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStopBit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDataBit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboParityBit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBaudRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCommPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.ComboBoxEdit cboStopBit;
        private DevExpress.XtraEditors.ComboBoxEdit cboDataBit;
        private DevExpress.XtraEditors.ComboBoxEdit cboParityBit;
        private DevExpress.XtraEditors.ComboBoxEdit cboBaudRate;
        private DevExpress.XtraEditors.ComboBoxEdit cboCommPort;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.RadioGroup radType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}