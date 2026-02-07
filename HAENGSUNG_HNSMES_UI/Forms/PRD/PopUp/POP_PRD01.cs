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
    // 생산계획 등록

    public partial class POP_PRD01 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form
    {
        DevExpress.XtraEditors.Repository.RepositoryItemComboBox rcbRank = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
        bool mbSave = false;

        #region [Form Event]

        public POP_PRD01()
        {
            InitializeComponent();
        }
        private void POP_PRD01_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void POP_PRD01_Shown(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }

        #endregion

        #region [Control Event]

        private void speArray_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            txtEnd.EditValue = null;
        }

        private void speModelChTime_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            txtEnd.EditValue = null;
        }

        private void speOrdQty_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            txtEnd.EditValue = null;
        }

        private void teStart_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            txtEnd.EditValue = null;
        }

        private void gvList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            InitItem();

            if (gvList.RowCount > 0 && gvList.FocusedRowHandle >= 0 && gvList.FocusedRowHandle < gvList.RowCount)
            {
                txtVendor.EditValue = gvList.GetRowCellValue(gvList.FocusedRowHandle, "VENDORNAME").ObjectNullString();
                txtVendor.Tag = gvList.GetRowCellValue(gvList.FocusedRowHandle, "VENDOR").ObjectNullString();
                txtModel.EditValue = gvList.GetRowCellValue(gvList.FocusedRowHandle, "MODEL").ObjectNullString();
                txtModel.Tag = gvList.GetRowCellValue(gvList.FocusedRowHandle, "ITEMCODE").ObjectNullString();
                GetSide(gvList.GetRowCellValue(gvList.FocusedRowHandle, "PRODUCTIONTYPE").ObjectNullString());

                if (gvList.GetRowCellValue(gvList.FocusedRowHandle, "PRODUCTIONTYPE").ObjectNullString() == "1")
                {
                    gleSide.Properties.ReadOnly = false;
                    gleSide.EditValue = "";

                    lciTotTopOrdQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lciTotBotOrdQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lciOneSideOrdQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                    lciTopRemainQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lciBotRemainQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lciOneSideRemainQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                else if (gvList.GetRowCellValue(gvList.FocusedRowHandle, "PRODUCTIONTYPE").ObjectNullString() == "2")
                {
                    gleSide.Properties.ReadOnly = true;
                    gleSide.EditValue = "D";

                    lciTotTopOrdQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lciTotBotOrdQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lciOneSideOrdQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                    lciTopRemainQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lciBotRemainQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lciOneSideRemainQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                else
                {
                    gleSide.Properties.ReadOnly = true;
                    gleSide.EditValue = "N";

                    lciTotTopOrdQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciTotBotOrdQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciOneSideOrdQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                    lciTopRemainQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciBotRemainQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;                    
                    lciOneSideRemainQty.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }

                txtTotPlanQty.EditValue = int.Parse(gvList.GetRowCellValue(gvList.FocusedRowHandle, "TOTPLANQTY").ObjectNullString());
                txtTotTopOrdQty.EditValue = int.Parse(gvList.GetRowCellValue(gvList.FocusedRowHandle, "TOTTOPORDQTY").ObjectNullString());
                txtTotBotOrdQty.EditValue = int.Parse(gvList.GetRowCellValue(gvList.FocusedRowHandle, "TOTBOTORDQTY").ObjectNullString());
                txtOneSideOrdQty.EditValue = int.Parse(gvList.GetRowCellValue(gvList.FocusedRowHandle, "TOTORDQTY").ObjectNullString());
                txtTopRemainQty.EditValue = int.Parse(gvList.GetRowCellValue(gvList.FocusedRowHandle, "TOPREMAINQTY").ObjectNullString());
                txtBotRemainQty.EditValue = int.Parse(gvList.GetRowCellValue(gvList.FocusedRowHandle, "BOTREMAINQTY").ObjectNullString());
                txtOneSideRemainQty.EditValue = int.Parse(gvList.GetRowCellValue(gvList.FocusedRowHandle, "REMAINQTY").ObjectNullString());
                txtCrtValue.EditValue = gvList.GetRowCellValue(gvList.FocusedRowHandle, "CRTVALUE").ObjectNullString();
                speArray.EditValue = gvList.GetRowCellValue(gvList.FocusedRowHandle, "ARRAYQTY").ObjectNullString();
            }
        }
              
        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetCustPlan();
        }

        private void speOrdQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnTimeSearch_Click(null, null);
        }

        private void gleLine_EditValueChanged(object sender, EventArgs e)
        {
            teStart.EditValue = null;
            txtEnd.EditValue = null;

            // 프로시져 수행
            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = BASE_db.Execute_Proc("PKGPRD_SMT.GET_ESTIMATED_STARTTIME",
                                                                                1,
                                                                                new string[] { "A_LINE" },
                                                                                new string[] { gleLine.EditValue.ObjectNullString() });

            if (_Result.ResultInt == 0)
            {
                teStart.EditValue = DateTime.Parse(_Result.ResultString);
                teStart.Properties.ReadOnly = true;
            }
            else if (_Result.ResultInt == 1)
            {
                teStart.EditValue = DateTime.Parse(_Result.ResultString);
                teStart.Properties.ReadOnly = false;
            }
            else
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
           
             gleSide_EditValueChanged(null, null);
        }

        private void gleSide_EditValueChanged(object sender, EventArgs e)
        {
            txtEnd.EditValue = null;

            // 프로시져 수행
            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = BASE_db.Execute_Proc("PKGPRD_SMT.GET_MODELCHANGEST",
                                                                                1,
                                                                                new string[] { "A_PLANT",
                                                                                               "A_LINE",
                                                                                               "A_MODEL",
                                                                                               "A_SIDE" },
                                                                                new string[] { HAENGSUNG_HNSMES_UI.Global.Global_Variable.PLANT,
                                                                                                gleLine.EditValue.ObjectNullString(),
                                                                                                txtModel.Tag.ObjectNullString(),
                                                                                                gleSide.EditValue.ObjectNullString() });

            if (_Result.ResultInt == 0)
                speModelChTime.EditValue = _Result.ResultDataSet.Tables[0].Rows[0]["MODELCHANGETIME"];
            else
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);

        }

        private void btnTimeSearch_Click(object sender, EventArgs e)
        {
            if (!InputChk(false))
                return;

             txtEnd.EditValue = null;

            // 프로시져 수행
            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = BASE_db.Execute_Proc("PKGPRD_SMT.GET_ESTIMATED_ENDTIME",
                                                                                1,
                                                                                new string[] { "A_PLANT",
                                                                                               "A_VENDOR",
                                                                                               "A_LINE",
                                                                                               "A_MODEL",
                                                                                               "A_SIDE",
                                                                                               "A_MODELCHANGETIME",
                                                                                               "A_ARRAY",
                                                                                               "A_PLANQTY",
                                                                                               "A_STARTDATETIME" },
                                                                                new string[] { HAENGSUNG_HNSMES_UI.Global.Global_Variable.PLANT,
                                                                                               txtVendor.Tag.ObjectNullString(),
                                                                                               gleLine.EditValue.ObjectNullString(),
                                                                                               txtModel.Tag.ObjectNullString(),
                                                                                               gleSide.EditValue.ObjectNullString(),
                                                                                               speModelChTime.EditValue.ObjectNullString(),
                                                                                               speArray.EditValue.ObjectNullString(),
                                                                                               speOrdQty.EditValue.ObjectNullString(),
                                                                                               teStart.Text.Replace("-","").Replace(":","").Replace(" ","") });

            if (_Result.ResultInt == 0)
                txtEnd.EditValue = _Result.ResultString;
            else
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!InputChk(true))
                return;

            SavePlan();
        }       

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (mbSave)
                DialogResult = System.Windows.Forms.DialogResult.OK;
            else
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        #endregion

        #region [Private Method]

        private void InitForm()
        {
            GetLine();
            GetRank();
        }


        private void GetLine()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleLine,
                                                        "PKGPRD_SMT.GET_LINE",
                                                        1,
                                                        new string[] { "A_PLANT" },
                                                        new string[] { Global.Global_Variable.PLANT },
                                                        "PRODLINE",
                                                        "PRODLINENAME",
                                                        "PRODLINE,PRODLINENAME");
        }

        private void GetSide(string sType)
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleSide,
                                                        "PKGPRD_SMT.GET_SIDE",
                                                        1,
                                                        new string[] { "A_TYPE" },
                                                        new string[] { sType },
                                                        "CODE",
                                                        "CODENAME",
                                                        "CODE,CODENAME,REMARKS");
        }

        private void GetRank()
        {
            BASE_DXGridHelper.Bind_RepositoryItemComboBox(rcbRank,
                                                          "PKGMAT_INOUT.GET_RANK",
                                                          1,
                                                          new string[] { "A_PLANT",
                                                                         "A_ITEMCODE"},
                                                          new string[] { HAENGSUNG_HNSMES_UI.Global.Global_Variable.PLANT,
                                                                         "-1"},
                                                          true);
        }

        private void InitItem()
        {
            txtVendor.EditValue = null;
            txtModel.EditValue = null;
            txtTotPlanQty.EditValue = null;
            txtTotTopOrdQty.EditValue = null;
            txtTotBotOrdQty.EditValue = null;
            txtOneSideOrdQty.EditValue = null;
            txtTopRemainQty.EditValue = null;
            txtBotRemainQty.EditValue = null;
            txtOneSideRemainQty.EditValue = null;
            txtCrtValue.EditValue = null;
            gleLine.EditValue = null;
            gleSide.EditValue = null;
            speModelChTime.EditValue = 0;
            speArray.EditValue = 1;
            speOrdQty.EditValue = 0;
            teStart.EditValue = null;
            txtEnd.EditValue = null;
        }

        private bool InputChk(bool bSave)
        {
            if (txtVendor.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_WO_011", this.Text, 3);
                return false;
            }

            if (gleLine.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_LINE_004", this.Text, 3);
                gleLine.Focus();
                return false;
            }

            if (gleSide.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_WO_014", this.Text, 3);
                gleSide.Focus();
                return false;
            }

            if (speModelChTime.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_WO_025", this.Text, 3);
                speModelChTime.Focus();
                return false;
            }

            if (int.Parse(speModelChTime.EditValue.ObjectNullString()) < 0)
            {
                iDATMessageBox.ErrorMessage("MSG_ER_COMM_001", this.Text, 3);
                speModelChTime.Focus();
                return false;
            }

            if (speArray.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_WO_024", this.Text, 3);
                speArray.Focus();
                return false;
            }

            if (int.Parse(speArray.EditValue.ObjectNullString()) < 1)
            {
                iDATMessageBox.ErrorMessage("MSG_ER_COMM_001", this.Text, 3);
                speArray.Focus();
                return false;
            }

            if (speOrdQty.EditValue.ObjectNullString() == "")
            {
                iDATMessageBox.WARNINGMessage("MSG_ER_WO_013", this.Text, 3);
                speOrdQty.Focus();
                return false;
            }

            if (int.Parse(speOrdQty.EditValue.ObjectNullString()) < 1)
            {
                iDATMessageBox.ErrorMessage("MSG_ER_COMM_001", this.Text, 3);
                speOrdQty.Focus();
                return false;
            }

            if (bSave)
            {
                if (txtEnd.EditValue.ObjectNullString() == "")
                {
                    iDATMessageBox.ErrorMessage("MSG_ER_WO_015", this.Text, 3);
                    btnTimeSearch.Focus();
                    return false;
                }                
            }
            return true;
        }

        private void GetCustPlan()
        {
            int nRow = gvList.FocusedRowHandle;

            BASE_DXGridHelper.Bind_Grid(gcList,
                                        "PKGPRD_SMT.GET_CUSTOMPLAN",
                                        1,
                                        new string[] { "A_TYPE" },
                                        new string[] { "SMT" },
                                        false,
                                        "VENDOR,ITEMCODE,TOTTOPORDQTY,TOTBOTORDQTY,TOTORDQTY,TOPREMAINQTY,BOTREMAINQTY,REMAINQTY,PRODUCTIONTYPE,ARRAYQTY",
                                        false);

            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();

            if (nRow == 0)
                gvList_FocusedRowChanged(null, null);
        }

        private void SavePlan()
        {
            // 프로시져 수행
            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = BASE_db.Execute_Proc("PKGPRD_SMT.SET_WO",
                                                                                1,
                                                                                new string[] { "A_PLANT",
                                                                                               "A_VENDOR",
                                                                                               "A_LINE",
                                                                                               "A_MODEL",
                                                                                               "A_SIDE",
                                                                                               "A_MDLCHGTIME",
                                                                                               "A_ARRAY",
                                                                                               "A_PLANQTY",
                                                                                               "A_STARTDAETIME",
                                                                                               "A_ENDDATETIME",
                                                                                               "A_CRTVALUE",
                                                                                               "A_USER" },
                                                                                new string[] { Global.Global_Variable.PLANT,
                                                                                               txtVendor.Tag.ObjectNullString(),
                                                                                               gleLine.EditValue.ObjectNullString(),
                                                                                               txtModel.Tag.ObjectNullString(),
                                                                                               gleSide.EditValue.ObjectNullString(),
                                                                                               speModelChTime.EditValue.ObjectNullString(),
                                                                                               speArray.EditValue.ObjectNullString(),
                                                                                               speOrdQty.EditValue.ObjectNullString(),
                                                                                               teStart.Text.Replace("-","").Replace(":","").Replace(" ",""),
                                                                                               txtEnd.EditValue.ObjectNullString().Replace("-","").Replace(":","").Replace(" ",""),                                                                                               
                                                                                               txtCrtValue.EditValue.ObjectNullString(),
                                                                                               Global.Global_Variable.EHRCODE });

            if (_Result.ResultInt == 0)
            {
                mbSave = true;
                iDATMessageBox.OKMessage("MSG_OK_REG_001", this.Text, 3);
                btnSearch_Click(null, null);
            }
            else
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
        }

        #endregion
    }
}
