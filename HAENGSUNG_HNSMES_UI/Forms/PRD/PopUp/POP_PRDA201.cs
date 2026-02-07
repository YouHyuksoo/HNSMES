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
    public partial class POP_PRDA201 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form
    {
        public DataTable dt;
        private string _strWrkord, _strPartNo, _strOper, _strUnitNo, _strUnitNm = string.Empty;
        public POP_PRDA201()
        {
            InitializeComponent();
        }

        public POP_PRDA201(string p_wrkord, string p_partno, string p_oper, string p_unitno, string p_unitnm)
        {
            InitializeComponent();

            _strWrkord = p_wrkord;
            _strPartNo = p_partno;
            _strOper = p_oper;
            _strUnitNo = p_unitno;
            _strUnitNm = p_unitnm;
            
        }

        private void POP_PRDA201_Load(object sender, EventArgs e)
        {
            /*신규 DataTable 생성 및 입력조건 생성*/
            SplashScreenManager.ShowForm(typeof(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM), true, false);
            SplashScreenManager.Default.SendCommand(HAENGSUNG_HNSMES_UI.Forms.COM.COMWAITFORM.WaitFormCommand.SetDescription, "Loading...");

            txtWrkord.EditValue = _strWrkord;
            txtPartNo.EditValue = _strPartNo;
            txtUnitNo.EditValue = _strUnitNo;
            txtUnitNm.EditValue = _strUnitNm;

            GetUnitNo(_strOper);

            SplashScreenManager.CloseForm(true);
        }

        #region 기본 정보
        /*호기정보*/
        private void GetUnitNo(string p_oper)
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleUnitNo
                                                       , "GPKGBAS_BASE.GET_UNITNO"
                                                       , 1
                                                       , new string[] { 
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_OPER"}
                                                       , new string[] { 
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , p_oper}
                                                       , "UNITNO"
                                                       , "UNITNM"
                                                       , "UNITNO, UNITNM"
                                                       );
        }
        
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (gleUnitNo.EditValue.ObjectNullString() == txtUnitNo.EditValue.ObjectNullString())
            {
                iDATMessageBox.ErrorMessage("MSG_ER_PRD_052", this.Text, 3); //사용가능한 호기가 아닙니다.
                return;
            }

            WSResults _result = BASE_db.Execute_Proc("PKGPRD_PROD.SET_CHANGE_UNITNO"
                                                    , 1
                                                    , new string[] {
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_WRKORD"
                                                    , "A_UNITNO"
                                                    , "A_USER"}
                                                    , new string[] {
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT
                                                    , txtWrkord.EditValue.ObjectNullString()
                                                    , gleUnitNo.EditValue.ObjectNullString()
                                                    , Global.Global_Variable.EHRCODE }
                                                    );

            if (_result.ResultInt == 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                iDATMessageBox.ErrorMessage(_result.ResultString, this.Text, 3); //사용가능한 호기가 아닙니다.

            }
            
        }
    }
}