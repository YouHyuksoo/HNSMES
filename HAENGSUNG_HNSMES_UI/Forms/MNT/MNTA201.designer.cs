namespace HAENGSUNG_HNSMES_UI.Forms.MNT
{
    partial class MNTA201
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNTA201));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSecond = new DevExpress.XtraEditors.LabelControl();
            this.lblTimer = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pbcMain = new DevExpress.XtraEditors.ProgressBarControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gcMonTab1 = new DevExpress.XtraGrid.GridControl();
            this.gvMonTab1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcMonTab2 = new DevExpress.XtraGrid.GridControl();
            this.gvMonTab2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tcgMain = new DevExpress.XtraLayout.TabbedControlGroup();
            this.lcgMonTab1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgMonTab2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.tmrWorkCenter = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbcMain.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcMonTab1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMonTab1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMonTab2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMonTab2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMonTab1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMonTab2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.ContentImageAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.panelControl1.Controls.Add(this.panel1);
            this.panelControl1.Controls.Add(this.lblSecond);
            this.panelControl1.Controls.Add(this.lblTimer);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(884, 110);
            this.panelControl1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(3, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 76);
            this.panel1.TabIndex = 6;
            // 
            // lblSecond
            // 
            this.lblSecond.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSecond.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecond.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblSecond.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblSecond.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSecond.Location = new System.Drawing.Point(756, 15);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(116, 28);
            this.lblSecond.TabIndex = 4;
            this.lblSecond.Text = "1 sec";
            this.lblSecond.Visible = false;
            this.lblSecond.DoubleClick += new System.EventHandler(this.lblSecond_DoubleClick);
            // 
            // lblTimer
            // 
            this.lblTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimer.Appearance.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblTimer.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblTimer.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTimer.Location = new System.Drawing.Point(417, 45);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(467, 53);
            this.lblTimer.TabIndex = 5;
            this.lblTimer.Click += new System.EventHandler(this.lblTimer_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(252, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(138, 80);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Production info";
            // 
            // pbcMain
            // 
            this.pbcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbcMain.Location = new System.Drawing.Point(4, 330);
            this.pbcMain.Name = "pbcMain";
            this.pbcMain.Size = new System.Drawing.Size(876, 18);
            this.pbcMain.StyleController = this.layoutControl1;
            this.pbcMain.TabIndex = 3;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.pbcMain);
            this.layoutControl1.Controls.Add(this.gcMonTab1);
            this.layoutControl1.Controls.Add(this.gcMonTab2);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 110);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(884, 352);
            this.layoutControl1.TabIndex = 6;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gcMonTab1
            // 
            this.gcMonTab1.Location = new System.Drawing.Point(9, 32);
            this.gcMonTab1.MainView = this.gvMonTab1;
            this.gcMonTab1.Name = "gcMonTab1";
            this.gcMonTab1.Size = new System.Drawing.Size(866, 289);
            this.gcMonTab1.TabIndex = 4;
            this.gcMonTab1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMonTab1});
            // 
            // gvMonTab1
            // 
            this.gvMonTab1.Appearance.Empty.BackColor = System.Drawing.Color.Black;
            this.gvMonTab1.Appearance.Empty.Options.UseBackColor = true;
            this.gvMonTab1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 42.75F, System.Drawing.FontStyle.Bold);
            this.gvMonTab1.Appearance.Row.Options.UseFont = true;
            this.gvMonTab1.GridControl = this.gcMonTab1;
            this.gvMonTab1.Name = "gvMonTab1";
            this.gvMonTab1.OptionsView.RowAutoHeight = true;
            this.gvMonTab1.CustomDrawFooterCell += new DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventHandler(this.gv_CustomDrawFooterCell);
            this.gvMonTab1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gv_RowCellStyle);
            this.gvMonTab1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gv_RowStyle);
            this.gvMonTab1.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.gv_CustomSummaryCalculate);
            this.gvMonTab1.RowCellDefaultAlignment += new DevExpress.XtraGrid.Views.Base.RowCellAlignmentEventHandler(this.gv_RowCellDefaultAlignment);
            // 
            // gcMonTab2
            // 
            this.gcMonTab2.Location = new System.Drawing.Point(9, 32);
            this.gcMonTab2.MainView = this.gvMonTab2;
            this.gcMonTab2.Name = "gcMonTab2";
            this.gcMonTab2.Size = new System.Drawing.Size(866, 289);
            this.gcMonTab2.TabIndex = 5;
            this.gcMonTab2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMonTab2});
            // 
            // gvMonTab2
            // 
            this.gvMonTab2.Appearance.Empty.BackColor = System.Drawing.Color.Black;
            this.gvMonTab2.Appearance.Empty.Options.UseBackColor = true;
            this.gvMonTab2.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 42.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvMonTab2.Appearance.Row.Options.UseFont = true;
            this.gvMonTab2.GridControl = this.gcMonTab2;
            this.gvMonTab2.Name = "gvMonTab2";
            this.gvMonTab2.OptionsView.RowAutoHeight = true;
            this.gvMonTab2.CustomDrawFooterCell += new DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventHandler(this.gv_CustomDrawFooterCell);
            this.gvMonTab2.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gv_RowCellStyle);
            this.gvMonTab2.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gv_RowStyle);
            this.gvMonTab2.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.gv_CustomSummaryCalculate);
            this.gvMonTab2.RowCellDefaultAlignment += new DevExpress.XtraGrid.Views.Base.RowCellAlignmentEventHandler(this.gv_RowCellDefaultAlignment);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tcgMain,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup1.Size = new System.Drawing.Size(884, 352);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // tcgMain
            // 
            this.tcgMain.CustomizationFormText = "tcgMain";
            this.tcgMain.Location = new System.Drawing.Point(0, 0);
            this.tcgMain.Name = "tcgMain";
            this.tcgMain.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.tcgMain.SelectedTabPage = this.lcgMonTab1;
            this.tcgMain.SelectedTabPageIndex = 0;
            this.tcgMain.Size = new System.Drawing.Size(880, 326);
            this.tcgMain.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgMonTab1,
            this.lcgMonTab2});
            this.tcgMain.Text = "tcgMain";
            // 
            // lcgMonTab1
            // 
            this.lcgMonTab1.CustomizationFormText = "PARTNO";
            this.lcgMonTab1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.lcgMonTab1.Location = new System.Drawing.Point(0, 0);
            this.lcgMonTab1.Name = "lcgMonTab1";
            this.lcgMonTab1.Size = new System.Drawing.Size(870, 293);
            this.lcgMonTab1.Text = "MonDisplayTab1";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcMonTab1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(870, 293);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // lcgMonTab2
            // 
            this.lcgMonTab2.CustomizationFormText = "EQP";
            this.lcgMonTab2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.lcgMonTab2.Location = new System.Drawing.Point(0, 0);
            this.lcgMonTab2.Name = "lcgMonTab2";
            this.lcgMonTab2.Size = new System.Drawing.Size(870, 293);
            this.lcgMonTab2.Text = "MonDisplayTab2";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gcMonTab2;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(870, 293);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.pbcMain;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 326);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(880, 22);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Interval = 1000;
            this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // tmrWorkCenter
            // 
            this.tmrWorkCenter.Interval = 5000;
            this.tmrWorkCenter.Tick += new System.EventHandler(this.tmrWorkCenter_Tick);
            // 
            // MNTA201
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.ControlBox = false;
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MNTA201";
            this.ShowCloseButton = false;
            this.ShowDeleteButton = false;
            this.ShowEditButton = false;
            this.ShowInitButton = false;
            this.ShowNewbutton = false;
            this.ShowPrintButton = false;
            this.ShowRefreshButton = false;
            this.ShowSaveButton = false;
            this.ShowSearchButton = false;
            this.ShowStopButton = false;
            this.Text = "";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Load);
            this.Shown += new System.EventHandler(this.Form_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbcMain.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcMonTab1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMonTab1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMonTab2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMonTab2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMonTab1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMonTab2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LabelControl lblSecond;
        private DevExpress.XtraEditors.ProgressBarControl pbcMain;
        private System.Windows.Forms.Timer tmrRefresh;
        private System.Windows.Forms.Timer tmrWorkCenter;
        private DevExpress.XtraLayout.TabbedControlGroup tcgMain;
        private DevExpress.XtraLayout.LayoutControlGroup lcgMonTab1;
        private DevExpress.XtraLayout.LayoutControlGroup lcgMonTab2;
        private DevExpress.XtraGrid.GridControl gcMonTab2;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMonTab2;
        private DevExpress.XtraGrid.GridControl gcMonTab1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMonTab1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.LabelControl lblTimer;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;

    }
}