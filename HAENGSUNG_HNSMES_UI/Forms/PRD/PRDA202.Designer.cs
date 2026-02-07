namespace HAENGSUNG_HNSMES_UI.Forms.PRD
{
    partial class PRDA202
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
            this.rdgDiv = new IDAT.Devexpress.DXControl.IdatDxRadioGroup();
            this.dteFromTo = new HAENGSUNG_HNSMES_UI.UserControl.COM.XucFromToDate();
            this.chkAllCheck = new System.Windows.Forms.CheckBox();
            this.gcList3 = new DevExpress.XtraGrid.GridControl();
            this.gvList3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcList2 = new DevExpress.XtraGrid.GridControl();
            this.gvList2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcList1 = new DevExpress.XtraGrid.GridControl();
            this.gvList1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcList = new DevExpress.XtraGrid.GridControl();
            this.gvList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnPreview = new IDAT.Devexpress.DXControl.IdatDxSimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup6 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdgDiv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.rdgDiv);
            this.layoutControl1.Controls.Add(this.dteFromTo);
            this.layoutControl1.Controls.Add(this.chkAllCheck);
            this.layoutControl1.Controls.Add(this.gcList3);
            this.layoutControl1.Controls.Add(this.gcList2);
            this.layoutControl1.Controls.Add(this.gcList1);
            this.layoutControl1.Controls.Add(this.gcList);
            this.layoutControl1.Controls.Add(this.btnPreview);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1306, 388, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(884, 462);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // rdgDiv
            // 
            this.rdgDiv.BindGridControl = null;
            this.rdgDiv.Location = new System.Drawing.Point(79, 68);
            this.rdgDiv.Name = "rdgDiv";
            this.rdgDiv.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("P", "PRODUCTION"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("S", "SAMPLE"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("E", "ETC")});
            this.rdgDiv.Size = new System.Drawing.Size(338, 25);
            this.rdgDiv.StyleController = this.layoutControl1;
            this.rdgDiv.TabIndex = 11;
            // 
            // dteFromTo
            // 
            this.dteFromTo.CurrentDataTYPE = IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit;
            this.dteFromTo.FormClass = "";
            this.dteFromTo.FormIcon = null;
            this.dteFromTo.IsButtonAuto = true;
            this.dteFromTo.Location = new System.Drawing.Point(79, 44);
            this.dteFromTo.Margin = new System.Windows.Forms.Padding(0);
            this.dteFromTo.Name = "dteFromTo";
            this.dteFromTo.ShowAllCloseButton = true;
            this.dteFromTo.ShowCloseButton = true;
            this.dteFromTo.ShowDeleteButton = true;
            this.dteFromTo.ShowEditButton = true;
            this.dteFromTo.ShowInitButton = true;
            this.dteFromTo.ShowNewbutton = true;
            this.dteFromTo.ShowPrintButton = true;
            this.dteFromTo.ShowRefreshButton = true;
            this.dteFromTo.ShowSaveButton = true;
            this.dteFromTo.ShowSearchButton = true;
            this.dteFromTo.ShowStopButton = true;
            this.dteFromTo.Size = new System.Drawing.Size(338, 20);
            this.dteFromTo.TabIndex = 10;
            // 
            // chkAllCheck
            // 
            this.chkAllCheck.Location = new System.Drawing.Point(24, 97);
            this.chkAllCheck.Name = "chkAllCheck";
            this.chkAllCheck.Size = new System.Drawing.Size(393, 20);
            this.chkAllCheck.TabIndex = 9;
            this.chkAllCheck.Text = "ALL Check";
            this.chkAllCheck.UseVisualStyleBackColor = true;
            this.chkAllCheck.CheckedChanged += new System.EventHandler(this.chkAllCheck_CheckedChanged);
            // 
            // gcList3
            // 
            this.gcList3.Location = new System.Drawing.Point(24, 208);
            this.gcList3.MainView = this.gvList3;
            this.gcList3.Name = "gcList3";
            this.gcList3.Size = new System.Drawing.Size(413, 230);
            this.gcList3.TabIndex = 8;
            this.gcList3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvList3});
            // 
            // gvList3
            // 
            this.gvList3.GridControl = this.gcList3;
            this.gvList3.Name = "gvList3";
            // 
            // gcList2
            // 
            this.gcList2.Location = new System.Drawing.Point(470, 44);
            this.gcList2.MainView = this.gvList2;
            this.gcList2.Name = "gcList2";
            this.gcList2.Size = new System.Drawing.Size(390, 115);
            this.gcList2.TabIndex = 7;
            this.gcList2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvList2});
            // 
            // gvList2
            // 
            this.gvList2.GridControl = this.gcList2;
            this.gvList2.Name = "gvList2";
            // 
            // gcList1
            // 
            this.gcList1.Location = new System.Drawing.Point(470, 207);
            this.gcList1.MainView = this.gvList1;
            this.gcList1.Name = "gcList1";
            this.gcList1.Size = new System.Drawing.Size(390, 231);
            this.gcList1.TabIndex = 6;
            this.gcList1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvList1});
            // 
            // gvList1
            // 
            this.gvList1.GridControl = this.gcList1;
            this.gvList1.Name = "gvList1";
            // 
            // gcList
            // 
            this.gcList.Location = new System.Drawing.Point(24, 121);
            this.gcList.MainView = this.gvList;
            this.gcList.Name = "gcList";
            this.gcList.Size = new System.Drawing.Size(393, 39);
            this.gcList.TabIndex = 5;
            this.gcList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvList});
            // 
            // gvList
            // 
            this.gvList.GridControl = this.gcList;
            this.gvList.Name = "gvList";
            // 
            // btnPreview
            // 
            this.btnPreview.ButtonEditMode = IDAT.Devexpress.DXControl.ButtonTypes.None;
            this.btnPreview.Location = new System.Drawing.Point(433, 12);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(16, 160);
            this.btnPreview.StyleController = this.layoutControl1;
            this.btnPreview.TabIndex = 4;
            this.btnPreview.Text = "▶";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup3,
            this.splitterItem1,
            this.layoutControlGroup5,
            this.layoutControlGroup6,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(884, 462);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "WAITWORKORDER";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(421, 164);
            this.layoutControlGroup2.Text = "WAITWORKORDER";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gcList;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 77);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(397, 43);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.chkAllCheck;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 53);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(397, 24);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.dteFromTo;
            this.layoutControlItem7.CustomizationFormText = "DATE";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(138, 24);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(397, 24);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "DATE";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.rdgDiv;
            this.layoutControlItem8.CustomizationFormText = "DIVISION";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(0, 29);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(109, 29);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(397, 29);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.Text = "DIVISION";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "EXPECTMATREQUEST";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3});
            this.layoutControlGroup3.Location = new System.Drawing.Point(446, 163);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(418, 279);
            this.layoutControlGroup3.Text = "EXPECTMATREQUEST";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gcList1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(394, 235);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.CustomizationFormText = "splitterItem1";
            this.splitterItem1.Location = new System.Drawing.Point(441, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(5, 442);
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.CustomizationFormText = "PRODUCTSTOCK";
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5});
            this.layoutControlGroup5.Location = new System.Drawing.Point(0, 164);
            this.layoutControlGroup5.Name = "layoutControlGroup5";
            this.layoutControlGroup5.Size = new System.Drawing.Size(441, 278);
            this.layoutControlGroup5.Text = "PRODUCTSTOCK";
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.gcList3;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(417, 234);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlGroup6
            // 
            this.layoutControlGroup6.CustomizationFormText = "WOREQUEST";
            this.layoutControlGroup6.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4});
            this.layoutControlGroup6.Location = new System.Drawing.Point(446, 0);
            this.layoutControlGroup6.Name = "layoutControlGroup6";
            this.layoutControlGroup6.Size = new System.Drawing.Size(418, 163);
            this.layoutControlGroup6.Text = "WOREQUEST";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gcList2;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(394, 119);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnPreview;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(421, 0);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(1, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(20, 164);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // PRDA202
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.Controls.Add(this.layoutControl1);
            this.Name = "PRDA202";
            this.ShowAllCloseButton = false;
            this.ShowCloseButton = false;
            this.ShowDeleteButton = false;
            this.ShowEditButton = false;
            this.ShowInTaskbar = false;
            this.ShowNewbutton = false;
            this.ShowPrintButton = false;
            this.ShowRefreshButton = false;
            this.ShowStopButton = false;
            this.Text = "PRDA202";
            this.Load += new System.EventHandler(this.PRDA202_Load);
            this.Shown += new System.EventHandler(this.PRDA202_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdgDiv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private IDAT.Devexpress.DXControl.IdatDxSimpleButton btnPreview;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl gcList1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvList1;
        private DevExpress.XtraGrid.GridControl gcList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvList;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.GridControl gcList3;
        private DevExpress.XtraGrid.Views.Grid.GridView gvList3;
        private DevExpress.XtraGrid.GridControl gcList2;
        private DevExpress.XtraGrid.Views.Grid.GridView gvList2;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private System.Windows.Forms.CheckBox chkAllCheck;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private UserControl.COM.XucFromToDate dteFromTo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private IDAT.Devexpress.DXControl.IdatDxRadioGroup rdgDiv;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}