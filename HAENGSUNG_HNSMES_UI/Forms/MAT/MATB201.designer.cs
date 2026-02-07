namespace HAENGSUNG_HNSMES_UI.Forms.MAT
{
    partial class MATB201
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
            this.gleWHLoc = new IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit();
            this.idatDxGridLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gleWH = new IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtSN = new IDAT.Devexpress.DXControl.IdatDxTextEdit();
            this.gleType = new IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit();
            this.idatDxGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dteFromTo = new HAENGSUNG_HNSMES_UI.UserControl.COM.XucFromToDate();
            this.rdgInOut = new IDAT.Devexpress.DXControl.IdatDxRadioGroup();
            this.txtPartNo = new IDAT.Devexpress.DXControl.IdatDxTextEdit();
            this.gcList1 = new DevExpress.XtraGrid.GridControl();
            this.gvList1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gleWHLoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idatDxGridLookUpEdit2View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleWH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idatDxGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgInOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPartNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gleWHLoc);
            this.layoutControl1.Controls.Add(this.gleWH);
            this.layoutControl1.Controls.Add(this.txtSN);
            this.layoutControl1.Controls.Add(this.gleType);
            this.layoutControl1.Controls.Add(this.dteFromTo);
            this.layoutControl1.Controls.Add(this.rdgInOut);
            this.layoutControl1.Controls.Add(this.txtPartNo);
            this.layoutControl1.Controls.Add(this.gcList1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(884, 420);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gleWHLoc
            // 
            this.gleWHLoc.BindGridControl = null;
            this.gleWHLoc.Location = new System.Drawing.Point(520, 84);
            this.gleWHLoc.Name = "gleWHLoc";
            this.gleWHLoc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gleWHLoc.Properties.View = this.idatDxGridLookUpEdit2View;
            this.gleWHLoc.Size = new System.Drawing.Size(348, 20);
            this.gleWHLoc.StyleController = this.layoutControl1;
            this.gleWHLoc.TabIndex = 21;
            // 
            // idatDxGridLookUpEdit2View
            // 
            this.idatDxGridLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.idatDxGridLookUpEdit2View.Name = "idatDxGridLookUpEdit2View";
            this.idatDxGridLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.idatDxGridLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            // 
            // gleWH
            // 
            this.gleWH.BindGridControl = null;
            this.gleWH.Location = new System.Drawing.Point(520, 60);
            this.gleWH.Name = "gleWH";
            this.gleWH.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gleWH.Properties.View = this.gridView1;
            this.gleWH.Size = new System.Drawing.Size(348, 20);
            this.gleWH.StyleController = this.layoutControl1;
            this.gleWH.TabIndex = 20;
            this.gleWH.EditValueChanged += new System.EventHandler(this.gleWH_EditValueChanged);
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // txtSN
            // 
            this.txtSN.BindGridControl = null;
            this.txtSN.Location = new System.Drawing.Point(92, 108);
            this.txtSN.Name = "txtSN";
            this.txtSN.Size = new System.Drawing.Size(354, 20);
            this.txtSN.StyleController = this.layoutControl1;
            this.txtSN.TabIndex = 19;
            this.txtSN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSN_KeyPress);
            // 
            // gleType
            // 
            this.gleType.BindGridControl = null;
            this.gleType.IsUseIDATFrameWorkControl = false;
            this.gleType.Location = new System.Drawing.Point(92, 60);
            this.gleType.Name = "gleType";
            this.gleType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gleType.Properties.View = this.idatDxGridLookUpEdit1View;
            this.gleType.Size = new System.Drawing.Size(348, 20);
            this.gleType.StyleController = this.layoutControl1;
            this.gleType.TabIndex = 17;
            // 
            // idatDxGridLookUpEdit1View
            // 
            this.idatDxGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.idatDxGridLookUpEdit1View.Name = "idatDxGridLookUpEdit1View";
            this.idatDxGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.idatDxGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // dteFromTo
            // 
            this.dteFromTo.CurrentDataTYPE = IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit;
            this.dteFromTo.FormClass = "";
            this.dteFromTo.FormIcon = null;
            this.dteFromTo.IsButtonAuto = true;
            this.dteFromTo.Location = new System.Drawing.Point(92, 36);
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
            this.dteFromTo.Size = new System.Drawing.Size(212, 20);
            this.dteFromTo.TabIndex = 1;
            // 
            // rdgInOut
            // 
            this.rdgInOut.BindGridControl = null;
            this.rdgInOut.Location = new System.Drawing.Point(526, 108);
            this.rdgInOut.Name = "rdgInOut";
            this.rdgInOut.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("IN", "RECEIVE")});
            this.rdgInOut.Size = new System.Drawing.Size(131, 25);
            this.rdgInOut.StyleController = this.layoutControl1;
            this.rdgInOut.TabIndex = 3;
            this.rdgInOut.SelectedIndexChanged += new System.EventHandler(this.rdgInOut_SelectedIndexChanged);
            // 
            // txtPartNo
            // 
            this.txtPartNo.BindGridControl = null;
            this.txtPartNo.IsUseIDATFrameWorkControl = false;
            this.txtPartNo.Location = new System.Drawing.Point(92, 84);
            this.txtPartNo.Name = "txtPartNo";
            this.txtPartNo.Size = new System.Drawing.Size(348, 20);
            this.txtPartNo.StyleController = this.layoutControl1;
            this.txtPartNo.TabIndex = 16;
            this.txtPartNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPartNo_KeyPress);
            // 
            // gcList1
            // 
            this.gcList1.Location = new System.Drawing.Point(16, 181);
            this.gcList1.MainView = this.gvList1;
            this.gcList1.Name = "gcList1";
            this.gcList1.Size = new System.Drawing.Size(852, 223);
            this.gcList1.TabIndex = 3;
            this.gcList1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvList1});
            // 
            // gvList1
            // 
            this.gvList1.GridControl = this.gcList1;
            this.gvList1.Name = "gvList1";
            this.gvList1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gvList1_ShowingEditor);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup3,
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup1.Size = new System.Drawing.Size(884, 420);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "LIST";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 145);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(880, 271);
            this.layoutControlGroup3.Text = "LIST";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcList1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(856, 227);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "CONDITION";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem8,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem11,
            this.layoutControlItem12});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(880, 145);
            this.layoutControlGroup2.Text = "CONDITION";
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(292, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(564, 24);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(645, 72);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(211, 29);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dteFromTo;
            this.layoutControlItem2.CustomizationFormText = "DATE";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(155, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(292, 24);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "DATE";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(73, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtSN;
            this.layoutControlItem3.CustomizationFormText = "S/N";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(434, 29);
            this.layoutControlItem3.Text = "S/N";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(73, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.rdgInOut;
            this.layoutControlItem8.CustomizationFormText = "TYPE";
            this.layoutControlItem8.Location = new System.Drawing.Point(434, 72);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(0, 29);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(105, 29);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(211, 29);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.Text = "TYPE";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(73, 14);
            this.layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gleType;
            this.layoutControlItem4.CustomizationFormText = "TYPE";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(428, 24);
            this.layoutControlItem4.Text = "TYPE";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(73, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtPartNo;
            this.layoutControlItem5.CustomizationFormText = "PARTNO";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(428, 24);
            this.layoutControlItem5.Text = "PARTNO";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(73, 14);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.gleWH;
            this.layoutControlItem11.CustomizationFormText = "WAREHOUSE";
            this.layoutControlItem11.Location = new System.Drawing.Point(428, 24);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(428, 24);
            this.layoutControlItem11.Text = "WAREHOUSE";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(73, 14);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.gleWHLoc;
            this.layoutControlItem12.CustomizationFormText = "WHLOC";
            this.layoutControlItem12.Location = new System.Drawing.Point(428, 48);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(428, 24);
            this.layoutControlItem12.Text = "WHLOC";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(73, 14);
            // 
            // MATB201
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 420);
            this.Controls.Add(this.layoutControl1);
            this.Name = "MATB201";
            this.ShowDeleteButton = false;
            this.ShowEditButton = false;
            this.ShowNewbutton = false;
            this.ShowPrintButton = false;
            this.ShowRefreshButton = false;
            this.ShowSaveButton = false;
            this.ShowStopButton = false;
            this.Text = "MATB201";
            this.Load += new System.EventHandler(this.MATB201_Load);
            this.Shown += new System.EventHandler(this.MATB201_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gleWHLoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idatDxGridLookUpEdit2View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleWH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idatDxGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgInOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPartNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraGrid.GridControl gcList1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvList1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private IDAT.Devexpress.DXControl.IdatDxTextEdit txtPartNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private IDAT.Devexpress.DXControl.IdatDxRadioGroup rdgInOut;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private UserControl.COM.XucFromToDate dteFromTo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit gleType;
        private DevExpress.XtraGrid.Views.Grid.GridView idatDxGridLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private IDAT.Devexpress.DXControl.IdatDxTextEdit txtSN;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit gleWHLoc;
        private DevExpress.XtraGrid.Views.Grid.GridView idatDxGridLookUpEdit2View;
        private IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit gleWH;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}