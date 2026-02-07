namespace HAENGSUNG_HNSMES_UI.UserControl.COM
{
    partial class XUCTileMenu
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl_Fav = new DevExpress.XtraEditors.PanelControl();
            this.panelControl_TileBack = new DevExpress.XtraEditors.PanelControl();
            this.mTileCon = new DevExpress.XtraEditors.TileControl();
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Fav)).BeginInit();
            this.panelControl_Fav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_TileBack)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(77, 522);
            this.panelControl1.TabIndex = 1;
            // 
            // panelControl2
            // 
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl2.Location = new System.Drawing.Point(922, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(77, 522);
            this.panelControl2.TabIndex = 2;
            // 
            // panelControl_Fav
            // 
            this.panelControl_Fav.Controls.Add(this.mTileCon);
            this.panelControl_Fav.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl_Fav.Location = new System.Drawing.Point(77, 0);
            this.panelControl_Fav.Name = "panelControl_Fav";
            this.panelControl_Fav.Size = new System.Drawing.Size(164, 522);
            this.panelControl_Fav.TabIndex = 3;
            // 
            // panelControl_TileBack
            // 
            this.panelControl_TileBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl_TileBack.Location = new System.Drawing.Point(241, 0);
            this.panelControl_TileBack.Name = "panelControl_TileBack";
            this.panelControl_TileBack.Size = new System.Drawing.Size(681, 522);
            this.panelControl_TileBack.TabIndex = 4;
            // 
            // mTileCon
            // 
            this.mTileCon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTileCon.Location = new System.Drawing.Point(2, 2);
            this.mTileCon.Name = "mTileCon";
            this.mTileCon.Size = new System.Drawing.Size(160, 518);
            this.mTileCon.TabIndex = 0;
            this.mTileCon.Text = "tileControl1";
            // 
            // XUCTileMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl_TileBack);
            this.Controls.Add(this.panelControl_Fav);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "XUCTileMenu";
            this.Size = new System.Drawing.Size(999, 522);
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Fav)).EndInit();
            this.panelControl_Fav.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_TileBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl_Fav;
        private DevExpress.XtraEditors.PanelControl panelControl_TileBack;
        private DevExpress.XtraEditors.TileControl mTileCon;
    }
}
