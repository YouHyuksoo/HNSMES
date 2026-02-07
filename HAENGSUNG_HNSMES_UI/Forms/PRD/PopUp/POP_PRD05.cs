using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// DevExpress namespace
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views;

// User namespace
using HAENGSUNG_HNSMES_UI.Class;

using GridAlias = DevExpress.XtraGrid.Views.Grid;

namespace HAENGSUNG_HNSMES_UI.Forms.PRD.PopUp
{
    // LENS 생산계획 등록

    public partial class POP_PRD05 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form
    {
        public string mSN = "";
        private bool mbSave = false;

        #region Scanner

        public string SN
        {
            set
            {
                //if (txtPkg1.EditValue.ObjectNullString() == "")
                if (gcPkg1.DataSource == null || gvPkg1.RowCount == 0)
                {
                    txtPkg1.EditValue = value;
                    txtPkg2.EditValue = null;
                }
                else
                {
                    txtPkg2.EditValue = value;
                }
                GetMatInfo();
            }
        }

        public string GRP
        {
            set
            {
                if (txtGrp1.EditValue.ObjectNullString() == "")
                {
                    txtGrp1.EditValue = value;
                }
                else
                {
                    txtGrp2.EditValue = value;
                }
            }
        }
        

        #endregion

        #region [Form Event]

        public POP_PRD05()
        {
            InitializeComponent();
        }
        private void POP_PRD05_Load(object sender, EventArgs e)
        {
            InitForm();
        }       

        #endregion

        #region [Control Event]

        private void txtPkg1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPkg1.EditValue.ObjectNullString() == "")
                {
                    iDATMessageBox.WARNINGMessage("MSG_ER_COMM_056", this.Text, 3);
                    txtPkg1.Focus();
                    return;
                }
                GetMatInfo();
            }
        }

        private void txtPkg2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //if (txtPkg1.EditValue.ObjectNullString() == "")
                if (gcPkg1.DataSource == null || gvPkg1.RowCount == 0)
                {
                    iDATMessageBox.WARNINGMessage("MSG_ER_COMM_056", this.Text, 3);
                    txtPkg1.Focus();
                    return;
                }

                if (txtPkg2.EditValue.ObjectNullString() == "")
                {
                    iDATMessageBox.WARNINGMessage("MSG_ER_COMM_056", this.Text, 3);
                    txtPkg2.Focus();
                    return;
                }
                GetMatInfo();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ChkInput())
                return;

            SetPlan();
        }
       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPkg1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (!mbSave)
            {
                gcPkg1.DataSource = null;
                gcPkg2.DataSource = null;
                gcList.DataSource = null;
                gcSerial.DataSource = null;
            }
        }

        private void txtPkg2_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (!mbSave)
            {
                gcPkg2.DataSource = null;
                gcList.DataSource = null;
                gcSerial.DataSource = null;
            }
        }

        private void gleLine_EditValueChanged(object sender, EventArgs e)
        {
            txtPkg1.EditValue = null;
            txtPkg2.EditValue = null;
            gcList.DataSource = null;
            gcSerial.DataSource = null;
        }

        private void gleModel_EditValueChanged(object sender, EventArgs e)
        {
            txtPkg1.EditValue = null;
            txtPkg2.EditValue = null;
            gcList.DataSource = null;
            gcSerial.DataSource = null;

            if (gleModel.EditValue.ObjectNullString() == "")
                txtRankRatio.EditValue = null;
            else
                txtRankRatio.EditValue = gleModel.Properties.View.GetRowCellValue(gleModel.Properties.View.FocusedRowHandle, "RANKRATIO");
        }

        private void chkNoStock_CheckedChanged(object sender, EventArgs e)
        {
            speQty.EditValue = 0;
            speQty.Properties.ReadOnly = !chkNoStock.Checked;

            txtPkg1.EditValue = null;
            txtPkg2.EditValue = null;
            gcList.DataSource = null;
            gcSerial.DataSource = null;
        }

        #endregion

        #region [Private Method]

        private void InitForm()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleLine,
                                                        "PKGPRD_SMT.GET_LINE2",
                                                        1,
                                                        new string[] { "A_PLANT",
                                                                       "A_TYPE"},
                                                        new string[] { Global.Global_Variable.PLANT,
                                                                       "LENS"},
                                                        "PRODLINE",
                                                        "PRODLINENAME",
                                                        "PRODLINE,PRODLINENAME");

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleModel,
                                                        "PKGPRD_LENS.GET_MODEL",
                                                        1,
                                                        new string[] { },
                                                        new string[] { },
                                                        "ITEMCODE",
                                                        "MODEL",
                                                        "MODEL,SPEC,RANKRATIO");

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleProdType,
                                                        "PKGPDA_LENS.GET_PRODTYPE",
                                                        1,
                                                        new string[] { },
                                                        new string[] { },
                                                        "CVALUE",
                                                        "COMMNAME",
                                                        "COMMNAME,CVALUE,REMARKS");

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleShift,
                                                        "PKGPDA_LENS.GET_SHIFT",
                                                        1,
                                                        new string[] { },
                                                        new string[] { },
                                                        "CVALUE",
                                                        "COMMNAME",
                                                        "COMMNAME,CVALUE,REMARKS");

            gvPkg1.OptionsView.ShowAutoFilterRow = false;
            gvPkg2.OptionsView.ShowAutoFilterRow = false;
            gvList.OptionsView.ShowAutoFilterRow = false;
            gvSerial.OptionsView.ShowAutoFilterRow = false;
        }


        private void GetMatInfo()
        {
            if (gleModel.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_COMM_017", this.Text, 3);
                gleModel.Focus();
                return;
            }

            DevExpress.XtraGrid.GridControl gCtl;

            if (txtPkg2.EditValue.ObjectNullString() == "")
                gCtl = gcPkg1;
            else
                gCtl = gcPkg2;

            string sChkStock = "Y";

            if (chkNoStock.Checked)
                sChkStock = "N";

            BASE_DXGridHelper.Bind_Grid(gCtl,
                                        "PKGPRD_SMT.GET_LENSPKGMAT",
                                        1,
                                        new string[] { 
                                            "A_PLANT",
                                            "A_MODELITEM",
                                            "A_SN1",
                                            "A_SN2",
                                            "A_CHKSTOCK"
                                        },
                                        new string[] { 
                                            Global.Global_Variable.PLANT,
                                            gleModel.EditValue.ObjectNullString(),
                                            txtPkg1.EditValue.ObjectNullString(),
                                            txtPkg2.EditValue.ObjectNullString(),
                                            sChkStock
                                        },
                                        false);

            DevExpress.XtraGrid.Views.Grid.GridView view = gCtl.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            view.OptionsView.ColumnAutoWidth = false;
            view.BestFitColumns();
        }


        private bool ChkInput()
        {
            if (gleLine.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_LINE_004", this.Text, 3);
                gleLine.Focus();
                return false;
            }

            if (gleModel.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_COMM_017", this.Text, 3);
                gleModel.Focus();
                return false;
            }

            if (gleProdType.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_MST_005", this.Text, 3);
                gleProdType.Focus();
                return false;
            }

            if (gleShift.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_COMM_059", this.Text, 3);
                gleShift.Focus();
                return false;
            }

            if (gcPkg1.DataSource == null || gvPkg1.RowCount == 0)
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_MAT_002", this.Text, 3);
                txtPkg1.Focus();
                return false;
            }

            if (gcPkg2.DataSource == null || gvPkg2.RowCount == 0)
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_MAT_002", this.Text, 3);
                txtPkg2.Focus();
                return false;
            }

            if (txtGrp1.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_MAT_027", this.Text, 3);
                txtGrp1.Focus();
                return false;
            }

            if (txtGrp2.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_MAT_027", this.Text, 3);
                txtGrp2.Focus();
                return false;
            }

            if (chkNoStock.Checked)
            {
                if (speQty.EditValue.ObjectNullString() == "" || int.Parse(speQty.EditValue.ObjectNullString()) < 1)
                {
                    iDATMessageBox.WARNINGMessage("MSG_ER_COMM_001", this.Text, 3);
                    speQty.Focus();
                    return false;
                }
            }
            return true;
        }

        private void SetPlan()
        {
            // 프로시져 수행
            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = BASE_db.Execute_Proc("PKGPRD_SMT.SET_LENSPLAN",
                                                                                1,
                                                                                new string[] { "A_PLANT",
                                                                                               "A_LINE",
                                                                                               "A_MODELITEM",
                                                                                               "A_PRODTYPE",
                                                                                               "A_SHIFT",
                                                                                               "A_PCBWEEK",
                                                                                               "A_SN1",
                                                                                               "A_GRP1",
                                                                                               "A_SN2",
                                                                                               "A_GRP2",
                                                                                               "A_LOTQTY",
                                                                                               "A_USER" },
                                                                                new string[] { Global.Global_Variable.PLANT,
                                                                                               gleLine.EditValue.ObjectNullString(),
                                                                                               gleModel.EditValue.ObjectNullString(),
                                                                                               gleProdType.EditValue.ObjectNullString(),
                                                                                               gleShift.EditValue.ObjectNullString(),
                                                                                               txtPcbWeek.EditValue.ObjectNullString(),
                                                                                               txtPkg1.EditValue.ObjectNullString(),
                                                                                               txtGrp1.EditValue.ObjectNullString(),
                                                                                               txtPkg2.EditValue.ObjectNullString(),
                                                                                               txtGrp2.EditValue.ObjectNullString(),
                                                                                               speQty.EditValue.ObjectNullString(),
                                                                                               Global.Global_Variable.EHRCODE });

            if (_Result.ResultInt == 0)
            {
                BASE_DXGridHelper.Bind_Grid_RT(gcList,
                                                _Result.ResultDataSet.Tables[0],
                                                false);
                
                //gvList.OptionsView.ColumnAutoWidth = false;
                gvList.BestFitColumns();
                
                
                BASE_DXGridHelper.Bind_Grid(gcSerial,
                                            _Result.ResultDataSet.Tables[1],
                                            false);

                gvSerial.OptionsView.ColumnAutoWidth = false;
                gvSerial.BestFitColumns();


                mbSave = true;

                txtPkg1.EditValue = null;
                txtPkg2.EditValue = null;

                mbSave = false;

                iDATMessageBox.OKMessage("MSG_OK_REG_001", this.Text, 3);                
            }
            else
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
        }

        #endregion
    }
}
