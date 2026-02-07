namespace HAENGSUNG_HNSMES_UI.Forms.SYS
{
    partial class SYSA208
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
            this.txtRemarks = new IDAT.Devexpress.DXControl.IdatDxMemoEdit();
            this.grdLookUpClient = new IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit();
            this.idatDxGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtCompanyName = new IDAT.Devexpress.DXControl.IdatDxTextEdit();
            this.txtCompany = new IDAT.Devexpress.DXControl.IdatDxTextEdit();
            this.gcList = new DevExpress.XtraGrid.GridControl();
            this.gvList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.rdgUseFlag = new IDAT.Devexpress.DXControl.IdatDxRadioGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpClient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idatDxGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompanyName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgUseFlag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtRemarks);
            this.layoutControl1.Controls.Add(this.grdLookUpClient);
            this.layoutControl1.Controls.Add(this.txtCompanyName);
            this.layoutControl1.Controls.Add(this.txtCompany);
            this.layoutControl1.Controls.Add(this.gcList);
            this.layoutControl1.Controls.Add(this.rdgUseFlag);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(913, 228, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(897, 493);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtRemarks
            // 
            this.txtRemarks.BindColumnName = "REMARKS";
            this.txtRemarks.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.txtRemarks.BindGridControl = this.gcList;
            this.txtRemarks.Location = new System.Drawing.Point(668, 130);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(220, 174);
            this.txtRemarks.StyleController = this.layoutControl1;
            this.txtRemarks.TabIndex = 9;
            this.txtRemarks.UseOptimizedRendering = true;
            // 
            // grdLookUpClient
            // 
            this.grdLookUpClient.BindColumnName = "CLIENT";
            this.grdLookUpClient.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.grdLookUpClient.BindGridControl = this.gcList;
            this.grdLookUpClient.CausesValidation = false;
            this.grdLookUpClient.Location = new System.Drawing.Point(668, 77);
            this.grdLookUpClient.Name = "grdLookUpClient";
            this.grdLookUpClient.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grdLookUpClient.Properties.View = this.idatDxGridLookUpEdit1View;
            this.grdLookUpClient.Size = new System.Drawing.Size(220, 20);
            this.grdLookUpClient.StyleController = this.layoutControl1;
            this.grdLookUpClient.TabIndex = 7;
            // 
            // idatDxGridLookUpEdit1View
            // 
            this.idatDxGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.idatDxGridLookUpEdit1View.Name = "idatDxGridLookUpEdit1View";
            this.idatDxGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.idatDxGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.BindColumnName = "COMPANYNAME";
            this.txtCompanyName.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.txtCompanyName.BindGridControl = this.gcList;
            this.txtCompanyName.CausesValidation = false;
            this.txtCompanyName.Location = new System.Drawing.Point(668, 53);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(220, 20);
            this.txtCompanyName.StyleController = this.layoutControl1;
            this.txtCompanyName.TabIndex = 6;
            // 
            // txtCompany
            // 
            this.txtCompany.BindColumnName = "COMPANY";
            this.txtCompany.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.txtCompany.BindGridControl = this.gcList;
            this.txtCompany.Location = new System.Drawing.Point(668, 29);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(220, 20);
            this.txtCompany.StyleController = this.layoutControl1;
            this.txtCompany.TabIndex = 5;
            // 
            // gcList
            // 
            this.gcList.Location = new System.Drawing.Point(9, 29);
            this.gcList.MainView = this.gvList;
            this.gcList.Name = "gcList";
            this.gcList.Size = new System.Drawing.Size(549, 455);
            this.gcList.TabIndex = 4;
            this.gcList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvList});
            // 
            // gvList
            // 
            this.gvList.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvList.GridControl = this.gcList;
            this.gvList.Name = "gvList";
            this.gvList.OptionsView.ShowGroupPanel = false;
            this.gvList.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gvList_BeforeLeaveRow);
            // 
            // rdgUseFlag
            // 
            this.rdgUseFlag.BindColumnName = "USEFLAG";
            this.rdgUseFlag.BindEditMode = IDAT.Devexpress.DXControl.EditModes.Edit;
            this.rdgUseFlag.BindGridControl = this.gcList;
            this.rdgUseFlag.Location = new System.Drawing.Point(668, 101);
            this.rdgUseFlag.Name = "rdgUseFlag";
            this.rdgUseFlag.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Y", "Yes"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("N", "No")});
            this.rdgUseFlag.Size = new System.Drawing.Size(220, 25);
            this.rdgUseFlag.StyleController = this.layoutControl1;
            this.rdgUseFlag.TabIndex = 8;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup3,
            this.splitterItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup1.Size = new System.Drawing.Size(897, 493);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "COMPANYLIST";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup2.Size = new System.Drawing.Size(563, 489);
            this.layoutControlGroup2.Text = "List";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcList;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(553, 459);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "Detail";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup3.Location = new System.Drawing.Point(568, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup3.Size = new System.Drawing.Size(325, 489);
            this.layoutControlGroup3.Text = "Detail";
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 279);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(315, 180);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtCompany;
            this.layoutControlItem2.CustomizationFormText = "COMPANY";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(315, 24);
            this.layoutControlItem2.Text = "COMPANY";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(88, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtCompanyName;
            this.layoutControlItem3.CustomizationFormText = "COMPANYNAME";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(315, 24);
            this.layoutControlItem3.Text = "COMPANYNAME";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(88, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.grdLookUpClient;
            this.layoutControlItem4.CustomizationFormText = "CLIENT";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(315, 24);
            this.layoutControlItem4.Text = "CLIENT";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(88, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.rdgUseFlag;
            this.layoutControlItem5.CustomizationFormText = "USEFLAG";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(0, 29);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(146, 29);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(315, 29);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "USEFLAG";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(88, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtRemarks;
            this.layoutControlItem6.CustomizationFormText = "REMARKS";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 101);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(315, 178);
            this.layoutControlItem6.Text = "REMARKS";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(88, 14);
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.CustomizationFormText = "splitterItem1";
            this.splitterItem1.Location = new System.Drawing.Point(563, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(5, 489);
            // 
            // SYSA208
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 493);
            this.Controls.Add(this.layoutControl1);
            this.Name = "SYSA208";
            this.ShowDeleteButton = false;
            this.ShowPrintButton = false;
            this.ShowRefreshButton = false;
            this.ShowSaveButton = false;
            this.ShowStopButton = false;
            this.Text = "SYSA208";
            this.Shown += new System.EventHandler(this.SYSA208_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.baseDxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpClient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idatDxGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompanyName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgUseFlag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private IDAT.Devexpress.DXControl.IdatDxRadioGroup rdgUseFlag;
        private IDAT.Devexpress.DXControl.IdatDxGridLookUpEdit grdLookUpClient;
        private DevExpress.XtraGrid.Views.Grid.GridView idatDxGridLookUpEdit1View;
        private IDAT.Devexpress.DXControl.IdatDxTextEdit txtCompanyName;
        private IDAT.Devexpress.DXControl.IdatDxTextEdit txtCompany;
        private DevExpress.XtraGrid.GridControl gcList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvList;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private IDAT.Devexpress.DXControl.IdatDxMemoEdit txtRemarks;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}