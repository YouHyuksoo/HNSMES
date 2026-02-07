namespace HAENGSUNG_HNSMES_UI.Forms.SAL
{
    partial class SALA204
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
            this.rdgJudge = new IDAT.Devexpress.DXControl.IdatDxRadioGroup();
            this.gcList2 = new DevExpress.XtraGrid.GridControl();
            this.gvList2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcList = new DevExpress.XtraGrid.GridControl();
            this.gvList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtBoxNo = new IDAT.Devexpress.DXControl.IdatDxTextEdit();
            this.dteDate = new HAENGSUNG_HNSMES_UI.UserControl.COM.XucFromToDate();
            this.gleVendor = new IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.OUTDATE = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdgJudge.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBoxNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleVendor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OUTDATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.rdgJudge);
            this.layoutControl1.Controls.Add(this.gcList2);
            this.layoutControl1.Controls.Add(this.gcList);
            this.layoutControl1.Controls.Add(this.txtBoxNo);
            this.layoutControl1.Controls.Add(this.dteDate);
            this.layoutControl1.Controls.Add(this.gleVendor);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1077, 371, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(884, 462);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // rdgJudge
            // 
            this.rdgJudge.BindGridControl = null;
            this.rdgJudge.Location = new System.Drawing.Point(576, 104);
            this.rdgJudge.Name = "rdgJudge";
            this.rdgJudge.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Y", "PASS"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("N", "NG")});
            this.rdgJudge.Size = new System.Drawing.Size(296, 36);
            this.rdgJudge.StyleController = this.layoutControl1;
            this.rdgJudge.TabIndex = 6;
            // 
            // gcList2
            // 
            this.gcList2.Location = new System.Drawing.Point(529, 176);
            this.gcList2.MainView = this.gvList2;
            this.gcList2.Name = "gcList2";
            this.gcList2.Size = new System.Drawing.Size(331, 262);
            this.gcList2.TabIndex = 5;
            this.gcList2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvList2});
            // 
            // gvList2
            // 
            this.gvList2.GridControl = this.gcList2;
            this.gvList2.Name = "gvList2";
            // 
            // gcList
            // 
            this.gcList.Location = new System.Drawing.Point(24, 136);
            this.gcList.MainView = this.gvList;
            this.gcList.Name = "gcList";
            this.gcList.Size = new System.Drawing.Size(472, 302);
            this.gcList.TabIndex = 4;
            this.gcList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvList});
            // 
            // gvList
            // 
            this.gvList.GridControl = this.gcList;
            this.gvList.Name = "gvList";
            this.gvList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvList_FocusedRowChanged);
            this.gvList.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvList_CellValueChanging);
            // 
            // txtBoxNo
            // 
            this.txtBoxNo.BindGridControl = null;
            this.txtBoxNo.Location = new System.Drawing.Point(83, 68);
            this.txtBoxNo.Name = "txtBoxNo";
            this.txtBoxNo.Size = new System.Drawing.Size(298, 20);
            this.txtBoxNo.StyleController = this.layoutControl1;
            this.txtBoxNo.TabIndex = 2;
            // 
            // dteDate
            // 
            this.dteDate.CurrentDataTYPE = IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit;
            this.dteDate.FormClass = "";
            this.dteDate.FormIcon = null;
            this.dteDate.IsButtonAuto = true;
            this.dteDate.Location = new System.Drawing.Point(83, 44);
            this.dteDate.Margin = new System.Windows.Forms.Padding(0);
            this.dteDate.Name = "dteDate";
            this.dteDate.ShowAllCloseButton = true;
            this.dteDate.ShowCloseButton = true;
            this.dteDate.ShowDeleteButton = true;
            this.dteDate.ShowEditButton = true;
            this.dteDate.ShowInitButton = true;
            this.dteDate.ShowNewbutton = true;
            this.dteDate.ShowPrintButton = true;
            this.dteDate.ShowRefreshButton = true;
            this.dteDate.ShowSaveButton = true;
            this.dteDate.ShowSearchButton = true;
            this.dteDate.ShowStopButton = true;
            this.dteDate.Size = new System.Drawing.Size(298, 20);
            this.dteDate.TabIndex = 4;
            // 
            // gleVendor
            // 
            this.gleVendor.BindGridControl = null;
            this.gleVendor.Location = new System.Drawing.Point(444, 44);
            this.gleVendor.Name = "gleVendor";
            this.gleVendor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gleVendor.Properties.View = this.gridView3;
            this.gleVendor.Size = new System.Drawing.Size(236, 20);
            this.gleVendor.StyleController = this.layoutControl1;
            this.gleVendor.TabIndex = 5;
            // 
            // gridView3
            // 
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup3,
            this.layoutControlGroup4,
            this.splitterItem1,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(884, 462);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "CONDITION";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.OUTDATE,
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.layoutControlItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(864, 92);
            this.layoutControlGroup2.Text = "CONDITION";
            // 
            // OUTDATE
            // 
            this.OUTDATE.Control = this.dteDate;
            this.OUTDATE.CustomizationFormText = "OUTDATE";
            this.OUTDATE.Location = new System.Drawing.Point(0, 0);
            this.OUTDATE.MaxSize = new System.Drawing.Size(0, 24);
            this.OUTDATE.MinSize = new System.Drawing.Size(163, 24);
            this.OUTDATE.Name = "OUTDATE";
            this.OUTDATE.Size = new System.Drawing.Size(361, 24);
            this.OUTDATE.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.OUTDATE.Text = "OUTDATE";
            this.OUTDATE.TextSize = new System.Drawing.Size(56, 14);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gleVendor;
            this.layoutControlItem1.CustomizationFormText = "VENDOR";
            this.layoutControlItem1.Location = new System.Drawing.Point(361, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(113, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(299, 24);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "VENDOR";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(56, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(361, 24);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(479, 24);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(660, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(180, 24);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtBoxNo;
            this.layoutControlItem2.CustomizationFormText = "LOT";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(113, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(361, 24);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "BOXNO";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(56, 14);
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "LIST";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 92);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(500, 350);
            this.layoutControlGroup3.Text = "LIST";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gcList;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(476, 306);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.CustomizationFormText = "SERIAL";
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem7});
            this.layoutControlGroup4.Location = new System.Drawing.Point(505, 132);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(359, 310);
            this.layoutControlGroup4.Text = "BOX DETAIL";
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.gcList2;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(335, 266);
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.CustomizationFormText = "splitterItem1";
            this.splitterItem1.Location = new System.Drawing.Point(500, 92);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(5, 350);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.rdgJudge;
            this.layoutControlItem4.CustomizationFormText = "JUDGE";
            this.layoutControlItem4.Location = new System.Drawing.Point(505, 92);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(0, 40);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(113, 40);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(359, 40);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "JUDGE";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(56, 14);
            // 
            // SALA204
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.Controls.Add(this.layoutControl1);
            this.Name = "SALA204";
            this.ShowDeleteButton = false;
            this.ShowEditButton = false;
            this.ShowNewbutton = false;
            this.ShowPrintButton = false;
            this.ShowRefreshButton = false;
            this.ShowStopButton = false;
            this.Text = "SALA204";
            this.Load += new System.EventHandler(this.SALA204_Load);
            this.Shown += new System.EventHandler(this.SALA204_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdgJudge.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBoxNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleVendor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OUTDATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private UserControl.COM.XucFromToDate dteDate;
        private IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit gleVendor;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem OUTDATE;
        private IDAT.Devexpress.DXControl.IdatDxTextEdit txtBoxNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl gcList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvList;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraGrid.GridControl gcList2;
        private DevExpress.XtraGrid.Views.Grid.GridView gvList2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private IDAT.Devexpress.DXControl.IdatDxRadioGroup rdgJudge;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}