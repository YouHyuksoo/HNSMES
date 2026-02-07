using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

//*화면 신규 추가시 아래 네임스페이스 추가*//
using System.Diagnostics;
using HAENGSUNG_HNSMES_UI.Class;
using HAENGSUNG_HNSMES_UI.WebService.Access;
using GridAlias = DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using NGS.WCFClient.DatabaseService;
using DevExpress.XtraGrid;
using DevExpress.XtraSplashScreen;

namespace HAENGSUNG_HNSMES_UI.Forms.PRD.PopUp
{
    public partial class POP_PRD204_01 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form
    {
        public string strfrontORrear { get; set; }
        public POP_PRD204_01()
        {
            InitializeComponent();
        }
        public POP_PRD204_01(string strMatCode)
        {
            InitializeComponent();

            this.Text = iDATMessageBox.GetMessage(this.Text);
            txtMatInfo.EditValue = strMatCode;
        }
        /*전/후 선택*/
        private void btnSelect_Click(object sender, EventArgs e)
        {
            strfrontORrear = rdgOneSide.EditValue.ObjectNullString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        /*닫기*/
        private void btnClose_Click(object sender, EventArgs e)
        {
            strfrontORrear = string.Empty;
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}