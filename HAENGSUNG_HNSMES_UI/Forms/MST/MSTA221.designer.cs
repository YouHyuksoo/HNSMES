namespace HAENGSUNG_HNSMES_UI.Forms.MST
{
    partial class MSTA221

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
            this.spiQty = new IDAT.Devexpress.DXControl.IdatDxSpinEdit();
            this.txtPartNo = new IDAT.Devexpress.DXControl.IdatDxTextEdit();
            this.gcList = new DevExpress.XtraGrid.GridControl();
            this.gvList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gcList1 = new DevExpress.XtraGrid.GridControl();
            this.gvList1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtItemcode = new IDAT.Devexpress.DXControl.IdatDxTextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            this.lcgEHR = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgDetail = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.idatDxRadioGroup1 = new IDAT.Devexpress.DXControl.IdatDxRadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spiQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPartNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgEHR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idatDxRadioGroup1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.spiQty);
            this.layoutControl1.Controls.Add(this.txtPartNo);
            this.layoutControl1.Controls.Add(this.gcList1);
            this.layoutControl1.Controls.Add(this.txtItemcode);
            this.layoutControl1.Controls.Add(this.gcList);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(74, 55, 417, 565);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(961, 525);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // spiQty
            // 
            this.spiQty.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.spiQty.BindGridControl = null;
            this.spiQty.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spiQty.Location = new System.Drawing.Point(704, 92);
            this.spiQty.Name = "spiQty";
            this.spiQty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spiQty.Size = new System.Drawing.Size(228, 20);
            this.spiQty.StyleController = this.layoutControl1;
            this.spiQty.TabIndex = 46;
            // 
            // txtPartNo
            // 
            this.txtPartNo.BindColumnName = "PARTNO";
            this.txtPartNo.BindGridControl = this.gcList;
            this.txtPartNo.BindPK = true;
            this.txtPartNo.Location = new System.Drawing.Point(704, 68);
            this.txtPartNo.Name = "txtPartNo";
            this.txtPartNo.Size = new System.Drawing.Size(228, 20);
            this.txtPartNo.StyleController = this.layoutControl1;
            this.txtPartNo.TabIndex = 45;
            // 
            // gcList
            // 
            this.gcList.Location = new System.Drawing.Point(24, 44);
            this.gcList.MainView = this.gvList;
            this.gcList.Name = "gcList";
            this.gcList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gcList.Size = new System.Drawing.Size(590, 191);
            this.gcList.TabIndex = 35;
            this.gcList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvList});
            // 
            // gvList
            // 
            this.gvList.GridControl = this.gcList;
            this.gvList.Name = "gvList";
            this.gvList.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvList_RowCellStyle);
            this.gvList.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvList_RowStyle);
            this.gvList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvList_FocusedRowChanged);
            this.gvList.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gvList_BeforeLeaveRow);
            this.gvList.Click += new System.EventHandler(this.gvList_Click);
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gcList1
            // 
            this.gcList1.Location = new System.Drawing.Point(24, 283);
            this.gcList1.MainView = this.gvList1;
            this.gcList1.Name = "gcList1";
            this.gcList1.Size = new System.Drawing.Size(590, 218);
            this.gcList1.TabIndex = 44;
            this.gcList1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvList1});
            // 
            // gvList1
            // 
            this.gvList1.GridControl = this.gcList1;
            this.gvList1.Name = "gvList1";
            // 
            // txtItemcode
            // 
            this.txtItemcode.BindColumnName = "ITEMCODE";
            this.txtItemcode.BindGridControl = this.gcList;
            this.txtItemcode.BindPK = true;
            this.txtItemcode.Location = new System.Drawing.Point(704, 44);
            this.txtItemcode.Name = "txtItemcode";
            this.txtItemcode.Size = new System.Drawing.Size(228, 20);
            this.txtItemcode.StyleController = this.layoutControl1;
            this.txtItemcode.TabIndex = 43;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.splitterItem1,
            this.lcgEHR,
            this.layoutControlGroup2,
            this.lcgDetail});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(961, 525);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.CustomizationFormText = "splitterItem1";
            this.splitterItem1.Location = new System.Drawing.Point(936, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(5, 505);
            // 
            // lcgEHR
            // 
            this.lcgEHR.CustomizationFormText = "List";
            this.lcgEHR.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.lcgEHR.Location = new System.Drawing.Point(0, 0);
            this.lcgEHR.Name = "lcgEHR";
            this.lcgEHR.Size = new System.Drawing.Size(618, 239);
            this.lcgEHR.Text = "List";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcList;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(594, 195);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "SERIAL";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 239);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(618, 266);
            this.layoutControlGroup2.Text = "SERIAL";
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.gcList1;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(594, 222);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // lcgDetail
            // 
            this.lcgDetail.CustomizationFormText = "Detail";
            this.lcgDetail.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem2});
            this.lcgDetail.Location = new System.Drawing.Point(618, 0);
            this.lcgDetail.Name = "lcgDetail";
            this.lcgDetail.Size = new System.Drawing.Size(318, 505);
            this.lcgDetail.Text = "Detail";
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 72);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(294, 389);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtItemcode;
            this.layoutControlItem4.CustomizationFormText = "ITEMCODE";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(294, 24);
            this.layoutControlItem4.Text = "ITEMCODE";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(59, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtPartNo;
            this.layoutControlItem6.CustomizationFormText = "PARTNO";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(294, 24);
            this.layoutControlItem6.Text = "PARTNO";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(59, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.spiQty;
            this.layoutControlItem2.CustomizationFormText = "Qty";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(294, 24);
            this.layoutControlItem2.Text = "Qty";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(59, 14);
            // 
            // idatDxRadioGroup1
            // 
            this.idatDxRadioGroup1.BindColumnName = "TEXTMARKTYPE";
            this.idatDxRadioGroup1.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.idatDxRadioGroup1.BindGridControl = this.gcList;
            this.idatDxRadioGroup1.Location = new System.Drawing.Point(550, 323);
            this.idatDxRadioGroup1.Name = "idatDxRadioGroup1";
            this.idatDxRadioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.idatDxRadioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.idatDxRadioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Y", "Yes"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("N", "No")});
            this.idatDxRadioGroup1.Size = new System.Drawing.Size(293, 25);
            this.idatDxRadioGroup1.StyleController = this.layoutControl1;
            this.idatDxRadioGroup1.TabIndex = 19;
            // 
            // MSTA221
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 525);
            this.Controls.Add(this.layoutControl1);
            this.Name = "MSTA221";
            this.ShowDeleteButton = false;
            this.ShowEditButton = false;
            this.ShowPrintButton = false;
            this.ShowRefreshButton = false;
            this.ShowStopButton = false;
            this.Text = "MSTA221";
            this.Load += new System.EventHandler(this.MSTA221_Load);
            this.Shown += new System.EventHandler(this.MSTA221_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spiQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPartNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgEHR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idatDxRadioGroup1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1; 
        private DevExpress.XtraGrid.GridControl gcList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvList;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraLayout.LayoutControlGroup lcgEHR;
        private DevExpress.XtraLayout.LayoutControlGroup lcgDetail;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private IDAT.Devexpress.DXControl.IdatDxRadioGroup idatDxRadioGroup1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private IDAT.Devexpress.DXControl.IdatDxTextEdit txtItemcode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.GridControl gcList1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvList1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private IDAT.Devexpress.DXControl.IdatDxSpinEdit spiQty;
        private IDAT.Devexpress.DXControl.IdatDxTextEdit txtPartNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}