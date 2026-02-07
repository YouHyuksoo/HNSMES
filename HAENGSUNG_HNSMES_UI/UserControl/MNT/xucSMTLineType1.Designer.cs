namespace HAENGSUNG_HNSMES_UI.UserControl.MNT
{
    partial class xucSMTLineType1
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
            this.picAOI = new DevExpress.XtraEditors.PictureEdit();
            this.picReflow = new DevExpress.XtraEditors.PictureEdit();
            this.picSMT2 = new DevExpress.XtraEditors.PictureEdit();
            this.picSMT1 = new DevExpress.XtraEditors.PictureEdit();
            this.picSPI = new DevExpress.XtraEditors.PictureEdit();
            this.picLoader = new DevExpress.XtraEditors.PictureEdit();
            this.txtModel = new DevExpress.XtraEditors.TextEdit();
            this.txtOrdQty = new DevExpress.XtraEditors.TextEdit();
            this.txtProdQty = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rsSMT2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rsSMT1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.bgwSMT1 = new System.ComponentModel.BackgroundWorker();
            this.bgwSMT2 = new System.ComponentModel.BackgroundWorker();
            this.lblProdLine = new DevExpress.XtraEditors.LabelControl();
            this.txtMissRate1 = new DevExpress.XtraEditors.TextEdit();
            this.txtMissRate2 = new DevExpress.XtraEditors.TextEdit();
            this.bgwRefresh = new System.ComponentModel.BackgroundWorker();
            this.lblSecond = new DevExpress.XtraEditors.LabelControl();
            this.pbcMain = new DevExpress.XtraEditors.ProgressBarControl();
            this.tmrRefresh = new System.Windows.Forms.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.picAOI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReflow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSMT2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSMT1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSPI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrdQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProdQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMissRate1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMissRate2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcMain.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // picAOI
            // 
            this.picAOI.EditValue = global::HAENGSUNG_HNSMES_UI.Properties.Resources.AOI;
            this.picAOI.Location = new System.Drawing.Point(586, 61);
            this.picAOI.Name = "picAOI";
            this.picAOI.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picAOI.Size = new System.Drawing.Size(42, 75);
            this.picAOI.TabIndex = 5;
            // 
            // picReflow
            // 
            this.picReflow.EditValue = global::HAENGSUNG_HNSMES_UI.Properties.Resources.REFLOW;
            this.picReflow.Location = new System.Drawing.Point(360, 61);
            this.picReflow.Name = "picReflow";
            this.picReflow.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picReflow.Size = new System.Drawing.Size(224, 75);
            this.picReflow.TabIndex = 4;
            // 
            // picSMT2
            // 
            this.picSMT2.EditValue = global::HAENGSUNG_HNSMES_UI.Properties.Resources.SMT;
            this.picSMT2.Location = new System.Drawing.Point(276, 61);
            this.picSMT2.Name = "picSMT2";
            this.picSMT2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picSMT2.Size = new System.Drawing.Size(82, 75);
            this.picSMT2.TabIndex = 3;
            this.picSMT2.Paint += new System.Windows.Forms.PaintEventHandler(this.picSMT2_Paint);
            // 
            // picSMT1
            // 
            this.picSMT1.EditValue = global::HAENGSUNG_HNSMES_UI.Properties.Resources.SMT;
            this.picSMT1.Location = new System.Drawing.Point(192, 61);
            this.picSMT1.Name = "picSMT1";
            this.picSMT1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picSMT1.Size = new System.Drawing.Size(82, 75);
            this.picSMT1.TabIndex = 2;
            this.picSMT1.Paint += new System.Windows.Forms.PaintEventHandler(this.picSMT1_Paint);
            // 
            // picSPI
            // 
            this.picSPI.EditValue = global::HAENGSUNG_HNSMES_UI.Properties.Resources.SPI;
            this.picSPI.Location = new System.Drawing.Point(115, 61);
            this.picSPI.Name = "picSPI";
            this.picSPI.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picSPI.Size = new System.Drawing.Size(75, 75);
            this.picSPI.TabIndex = 1;
            // 
            // picLoader
            // 
            this.picLoader.EditValue = global::HAENGSUNG_HNSMES_UI.Properties.Resources.Loader1;
            this.picLoader.Location = new System.Drawing.Point(2, 61);
            this.picLoader.Name = "picLoader";
            this.picLoader.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picLoader.Size = new System.Drawing.Size(111, 75);
            this.picLoader.TabIndex = 0;
            // 
            // txtModel
            // 
            this.txtModel.EditValue = "6871L-1939A";
            this.txtModel.Location = new System.Drawing.Point(2, 39);
            this.txtModel.Name = "txtModel";
            this.txtModel.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtModel.Properties.Appearance.Options.UseFont = true;
            this.txtModel.Size = new System.Drawing.Size(96, 20);
            this.txtModel.TabIndex = 6;
            // 
            // txtOrdQty
            // 
            this.txtOrdQty.EditValue = "10,000";
            this.txtOrdQty.Location = new System.Drawing.Point(101, 39);
            this.txtOrdQty.Name = "txtOrdQty";
            this.txtOrdQty.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtOrdQty.Properties.Appearance.Options.UseFont = true;
            this.txtOrdQty.Properties.Appearance.Options.UseTextOptions = true;
            this.txtOrdQty.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtOrdQty.Size = new System.Drawing.Size(75, 20);
            this.txtOrdQty.TabIndex = 7;
            // 
            // txtProdQty
            // 
            this.txtProdQty.EditValue = "10,000";
            this.txtProdQty.Location = new System.Drawing.Point(553, 39);
            this.txtProdQty.Name = "txtProdQty";
            this.txtProdQty.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtProdQty.Properties.Appearance.Options.UseFont = true;
            this.txtProdQty.Properties.Appearance.Options.UseTextOptions = true;
            this.txtProdQty.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtProdQty.Size = new System.Drawing.Size(75, 20);
            this.txtProdQty.TabIndex = 8;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(5, 20);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 14);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Model";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(103, 20);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(63, 14);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Order Q\'ty";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Location = new System.Drawing.Point(555, 20);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(58, 14);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Prod Q\'ty";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rsSMT2,
            this.rsSMT1});
            this.shapeContainer1.Size = new System.Drawing.Size(734, 138);
            this.shapeContainer1.TabIndex = 12;
            this.shapeContainer1.TabStop = false;
            // 
            // rsSMT2
            // 
            this.rsSMT2.BackColor = System.Drawing.Color.Red;
            this.rsSMT2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.rsSMT2.FillColor = System.Drawing.Color.Red;
            this.rsSMT2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Percent25;
            this.rsSMT2.Location = new System.Drawing.Point(366, 182);
            this.rsSMT2.Name = "rsSMT2";
            this.rsSMT2.Size = new System.Drawing.Size(59, 70);
            this.rsSMT2.Visible = false;
            // 
            // rsSMT1
            // 
            this.rsSMT1.BackColor = System.Drawing.Color.Red;
            this.rsSMT1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.rsSMT1.FillColor = System.Drawing.Color.Red;
            this.rsSMT1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Percent25;
            this.rsSMT1.Location = new System.Drawing.Point(259, 194);
            this.rsSMT1.Name = "rsSMT1";
            this.rsSMT1.Size = new System.Drawing.Size(71, 76);
            this.rsSMT1.Visible = false;
            // 
            // bgwSMT1
            // 
            this.bgwSMT1.WorkerSupportsCancellation = true;
            this.bgwSMT1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSMT1_DoWork);
            // 
            // bgwSMT2
            // 
            this.bgwSMT2.WorkerSupportsCancellation = true;
            this.bgwSMT2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSMT2_DoWork);
            // 
            // lblProdLine
            // 
            this.lblProdLine.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.lblProdLine.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblProdLine.Location = new System.Drawing.Point(258, -3);
            this.lblProdLine.Name = "lblProdLine";
            this.lblProdLine.Size = new System.Drawing.Size(117, 25);
            this.lblProdLine.TabIndex = 13;
            this.lblProdLine.Text = "SMT A-Line";
            // 
            // txtMissRate1
            // 
            this.txtMissRate1.EditValue = "100%/100%";
            this.txtMissRate1.Location = new System.Drawing.Point(192, 43);
            this.txtMissRate1.Name = "txtMissRate1";
            this.txtMissRate1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold);
            this.txtMissRate1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtMissRate1.Properties.Appearance.Options.UseFont = true;
            this.txtMissRate1.Properties.Appearance.Options.UseForeColor = true;
            this.txtMissRate1.Properties.Appearance.Options.UseTextOptions = true;
            this.txtMissRate1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtMissRate1.Size = new System.Drawing.Size(82, 16);
            this.txtMissRate1.TabIndex = 14;
            // 
            // txtMissRate2
            // 
            this.txtMissRate2.EditValue = "100%/100%";
            this.txtMissRate2.Location = new System.Drawing.Point(276, 43);
            this.txtMissRate2.Name = "txtMissRate2";
            this.txtMissRate2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold);
            this.txtMissRate2.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtMissRate2.Properties.Appearance.Options.UseFont = true;
            this.txtMissRate2.Properties.Appearance.Options.UseForeColor = true;
            this.txtMissRate2.Properties.Appearance.Options.UseTextOptions = true;
            this.txtMissRate2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtMissRate2.Size = new System.Drawing.Size(82, 16);
            this.txtMissRate2.TabIndex = 15;
            // 
            // bgwRefresh
            // 
            this.bgwRefresh.WorkerSupportsCancellation = true;
            this.bgwRefresh.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRefresh_DoWork);
            // 
            // lblSecond
            // 
            this.lblSecond.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblSecond.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblSecond.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblSecond.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSecond.Location = new System.Drawing.Point(408, 34);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(116, 14);
            this.lblSecond.TabIndex = 17;
            this.lblSecond.Text = "1 sec";
            // 
            // pbcMain
            // 
            this.pbcMain.Location = new System.Drawing.Point(406, 54);
            this.pbcMain.Name = "pbcMain";
            this.pbcMain.Size = new System.Drawing.Size(120, 18);
            this.pbcMain.TabIndex = 16;
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Interval = 1000;
            this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // xucSMTLineType1
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblSecond);
            this.Controls.Add(this.pbcMain);
            this.Controls.Add(this.txtMissRate2);
            this.Controls.Add(this.txtMissRate1);
            this.Controls.Add(this.lblProdLine);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtProdQty);
            this.Controls.Add(this.txtOrdQty);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.picAOI);
            this.Controls.Add(this.picReflow);
            this.Controls.Add(this.picSMT2);
            this.Controls.Add(this.picSPI);
            this.Controls.Add(this.picLoader);
            this.Controls.Add(this.shapeContainer1);
            this.Controls.Add(this.picSMT1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(736, 140);
            this.MinimumSize = new System.Drawing.Size(736, 140);
            this.Name = "xucSMTLineType1";
            this.Size = new System.Drawing.Size(734, 138);
            ((System.ComponentModel.ISupportInitialize)(this.picAOI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReflow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSMT2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSMT1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSPI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrdQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProdQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMissRate1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMissRate2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcMain.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit picLoader;
        private DevExpress.XtraEditors.PictureEdit picSPI;
        private DevExpress.XtraEditors.PictureEdit picSMT1;
        private DevExpress.XtraEditors.PictureEdit picSMT2;
        private DevExpress.XtraEditors.PictureEdit picReflow;
        private DevExpress.XtraEditors.PictureEdit picAOI;
        private DevExpress.XtraEditors.TextEdit txtModel;
        private DevExpress.XtraEditors.TextEdit txtOrdQty;
        private DevExpress.XtraEditors.TextEdit txtProdQty;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rsSMT1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rsSMT2;
        private System.ComponentModel.BackgroundWorker bgwSMT1;
        private System.ComponentModel.BackgroundWorker bgwSMT2;
        private DevExpress.XtraEditors.LabelControl lblProdLine;
        private DevExpress.XtraEditors.TextEdit txtMissRate1;
        private DevExpress.XtraEditors.TextEdit txtMissRate2;
        private System.ComponentModel.BackgroundWorker bgwRefresh;
        private DevExpress.XtraEditors.LabelControl lblSecond;
        private DevExpress.XtraEditors.ProgressBarControl pbcMain;
        private System.Windows.Forms.Timer tmrRefresh;
    }
}
