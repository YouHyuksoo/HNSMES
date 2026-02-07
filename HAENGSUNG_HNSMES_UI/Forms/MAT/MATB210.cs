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
using DevExpress.XtraGrid.Views.Grid;
// User namespace
using HAENGSUNG_HNSMES_UI.Class;
using GridAlias = DevExpress.XtraGrid.Views.Grid;

namespace HAENGSUNG_HNSMES_UI.Forms.MAT
{
    // 자재 재고실사 반영/조회

    public partial class MATB210 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {

        #region [Form Event]

        public MATB210()
        {
            InitializeComponent();           
        }
                
        private void Form_Load(object sender, EventArgs e)
        {

        }

        private void Form_Shown(object sender, EventArgs e)
        {
            Set_Init();
        }

        #endregion

        #region [Button Event]

        public void InitButton_Click()
        {
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);
        }

        
        public void NewButton_Click()
        {
        }

        
        public void EditButton_Click()
        {
        }

       
        public void StopButton_Click()
        {
        }

       
        public void SearchButton_Click()
        {
            GetGridViewList();
        }

       
        public void SaveButton_Click()
        {

        }

       
        public void PrintButton_Click()
        {
        }

       
        public void RefreshButton_Click()
        {
        }

        public void DeleteButton_Click()
        {
        }

        #endregion
     
        #region [Private Method]

        private void Set_Init()
        {
            dteInsMonth.DateTime = DateTime.Now;
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWH
                                                       , "PKGBAS_BASE.GET_WAREHOUSE"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_VIEW" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , "4" }
                                                       , "WAREHOUSE"
                                                       , "WAREHOUSENAME"
                                                       , "WAREHOUSE, WAREHOUSENAME, REMARKS"
                                                       );

            gleWHLoc.EditValue = null;
            gleWHLoc.Enabled = false;
            gcList.DataSource = null;

            if (this.Tag.ObjectNullString() == "M")
            {
                btnAllDel.Enabled = false;

                layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void Set_Location()
        {

            // 수정 - 해당 창고에 위치정보만 나오게 변경
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleWHLoc
                                                       , "PKGBAS_BASE.GET_LOCATION"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_WAREHOUSE"
                                                       , "A_VIEW" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , gleWH.EditValue.ObjectNullString()
                                                       , "0" }
                                                       , "WHLOC"
                                                       , "WHLOCNAME"
                                                       , "WHLOC, WHLOCNAME, REMARKS"
                                                       );  
        }

        private void Set_RACK()
        {
            //BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(gleRACK, "PKGBAS_BASE.GET_RACK", 1, new string[] { "A_VIEW" }, new string[] { "0" }, "RACKADDR", "RACKLOC", "RACKADDR,RACKLOC,WHLOCNAME");        
        }
     


        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid( gcList
                                       , "PKGBAS_MAT.GET_MATERIAL_ACTUAL"
                                       , 1
                                       , new string[] {
                                         "A_CLIENT"
                                       , "A_COMPANY"
                                       , "A_PLANT"
                                       , "A_MONTH"
                                       , "A_WHLOC" }
                                       , new string[] {
                                         Global.Global_Variable.CLIENT
                                       , Global.Global_Variable.COMPANY
                                       , Global.Global_Variable.PLANT
                                       , dteInsMonth.DateTime.ToString("yyyyMM")
                                       , gleWHLoc.EditValue.ObjectNullString() }
                                       , false
                                       , "INSPMON,WHLOC,ITEMCODE"
                                       , false
                                       , true
                                       );

            gvList.Columns["STOCKQTY"].DisplayFormat.FormatString = "{0:n2}";
            gvList.EX_SetTotalSummaryItems("STOCKQTY", DevExpress.Data.SummaryItemType.Sum, "{0:n2}");
            gvList.Columns["INSPQTY"].DisplayFormat.FormatString = "{0:n2}";
            gvList.EX_SetTotalSummaryItems("INSPQTY", DevExpress.Data.SummaryItemType.Sum, "{0:n2}");
            gvList.Columns["GAPQTY"].DisplayFormat.FormatString = "{0:n2}";
            gvList.EX_SetTotalSummaryItems("GAPQTY", DevExpress.Data.SummaryItemType.Sum, "{0:n2}");
            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();
        }

        #endregion

        private void gleWH_EditValueChanged(object sender, EventArgs e)
        {
            if (gleWH.EditValue != null)
            {
                gleWHLoc.Enabled = true;
                this.Set_Location();
            }
            else
            {
                gleWHLoc.EditValue = null;
                gleWHLoc.Enabled = false;
            }
        }

        private void btnActualDel_Click(object sender, EventArgs e)
        {
            LanguageInformation _clsLan = new LanguageInformation();
            string _strMsg = "";
            string _strMonth = "";
            string _strWHLoc = "";
            string _strItemCD = "";
            string _strType = "";
            string _strSerial = "";
            string _strLOT = "";
            string _strCntNO = "";
            string _strSide = "";
            string _strPCbLot = "";
            string _strBoxNo = "";
            string _strPltNo = "";

            if (gvList.FocusedRowHandle >= 0 && gvList.FocusedRowHandle < gvList.RowCount)
            {
                _strMonth = gvList.GetRowCellValue(gvList.FocusedRowHandle, "INSPMON").ObjectNullString();
                _strWHLoc = gvList.GetRowCellValue(gvList.FocusedRowHandle, "WHLOC").ObjectNullString();
                _strItemCD = gvList.GetRowCellValue(gvList.FocusedRowHandle, "ITEMCODE").ObjectNullString();                
                _strType = gvList.GetRowCellValue(gvList.FocusedRowHandle, "STOCKTYPE").ObjectNullString();                
                _strLOT = gvList.GetRowCellValue(gvList.FocusedRowHandle, "LOT").ObjectNullString();
                _strCntNO = gvList.GetRowCellValue(gvList.FocusedRowHandle, "CNTNO").ObjectNullString();
                _strSide = gvList.GetRowCellValue(gvList.FocusedRowHandle, "SIDE").ObjectNullString();
                _strSerial = gvList.GetRowCellValue(gvList.FocusedRowHandle, "SN").ObjectNullString();

                if (this.Tag.ObjectNullString() == "P")
                { 
                    _strPCbLot = gvList.GetRowCellValue(gvList.FocusedRowHandle, "PCBLOT").ObjectNullString();
                    _strBoxNo = gvList.GetRowCellValue(gvList.FocusedRowHandle, "BOXNO").ObjectNullString();
                    _strPltNo = gvList.GetRowCellValue(gvList.FocusedRowHandle, "PLTNO").ObjectNullString(); 
                }
                
                // 선택한 항목을 삭제하시겠습니까?
                _strMsg = _clsLan.GetMessageString("MSG_QS_MAT_001");

                if (iDATMessageBox.QuestionMessage(_strMsg, this.Text) == DialogResult.Yes)
                {
                    if (this.ActualDel(_strMonth, _strWHLoc, _strItemCD, _strType, _strLOT, _strCntNO, _strSide, _strSerial, _strPCbLot, _strBoxNo, _strPltNo))
                    {
                        gvList.DeleteRow(gvList.FocusedRowHandle);
                    }
                }
            }
        }


        public DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;
            textBox.PasswordChar = '*';

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }



        private void btnActualApply_Click(object sender, EventArgs e)
        {
            string value = "";
            if (InputBox(this.Text, "Input password:", ref value) == DialogResult.OK)
            {
                //if (value != "HSEVNPCB!@#")
                if (value != "hsgmes123!@#")
                {
                    iDATMessageBox.WARNINGMessage("MSG006", this.Text, 3);
                    return;
                }
            }
            else
                return;

            GridView view = gcList.DefaultView as GridView;

            //if (view.RowCount == 0)
            //    return;

            if (iDATMessageBox.QuestionMessage("MSG_QS_COMM_001", this.Text) == System.Windows.Forms.DialogResult.No)
                return;

            try
            {
                string _strMonth = dteInsMonth.DateTime.ToString("yyyyMM");
                string _strWHLoc = gleWHLoc.EditValue + "";
                string _strProcName = "PKGTXN_STOCK.PUT_ACTUALSTOCK";
                
                bool bRtn = BASE_db.Execute_Proc( _strProcName
                                                , 1
                                                , new string[] {
                                                  "A_CLIENT"
                                                , "A_COMPANY"
                                                , "A_PLANT"
                                                , "A_ACTUALMON"
                                                , "A_WHLOC"
                                                , "A_ITEMTYPE"
                                                , "A_USER" }
                                                , new string[] {
                                                  Global.Global_Variable.CLIENT
                                                , Global.Global_Variable.COMPANY
                                                , Global.Global_Variable.PLANT
                                                , _strMonth
                                                , _strWHLoc
                                                , this.Tag + ""
                                                , Global.Global_Variable.EHRCODE }
                                                , true
                                                );

                if (bRtn)
                    iDATMessageBox.OKMessage("MSG_OK_REG_001", this.Text, 3);
            }
            catch (Exception ex)
            {
                iDATMessageBox.WARNINGMessage(ex.Message,this.Text , 3);
            }
        }
        private bool ActualDel(string p_strMonth, string p_strWHLoc, string p_strItemCD, string p_strType, string p_strLOT, string p_strCntNO,
            string p_strSide, string p_strSerial, string p_strPcbLot, string p_strBoxNo, string p_strPltNo)
        {
            bool _blResult;
            _blResult = BASE_db.Execute_Proc( "PKGBAS_MAT.DEL_PROD_ACTUAL" 
                                            , 1
                                            , new string[] {
                                              "A_CLIENT"
                                            , "A_COMPANY"
                                            , "A_PLANT"
                                            , "A_MONTH"
                                            , "A_WHLOC"
                                            , "A_ITEMCODE"
                                            , "A_STOCKTYPE"
                                            , "A_SIDE"
                                            , "A_SERIAL"
                                            , "A_BOXNO" }
                                            , new string[] {
                                              Global.Global_Variable.CLIENT
                                            , Global.Global_Variable.COMPANY
                                            , Global.Global_Variable.PLANT
                                            , p_strMonth
                                            , p_strWHLoc
                                            , p_strItemCD
                                            , p_strType
                                            , p_strSide
                                            , p_strSerial
                                            , p_strBoxNo }
                                            , true
                                            );
            return _blResult;
        }

        private void btnAllDel_Click(object sender, EventArgs e)
        {
            LanguageInformation _clsLan = new LanguageInformation();
            string _strMsg = "";
            string _strMonth = "";
            string _strWHLoc = "";
            string _strItemCD = "";
            string _strType = "";
            string _strSerial = "";
            string _strLOT = "";
            string _strCntNO = "";
            string _strSide = "";
            string _strPCbLot = "";
            string _strBoxNo = "";
            string _strPltNo = "";

            int _intAddCount = 0;
            int _intRowCount = gvList.RowCount;

            if (gvList.RowCount == 0)
            {
                return;
            }

            // 선택한 항목을 삭제하시겠습니까?
            _strMsg = _clsLan.GetMessageString("MSG_QS_MAT_005");

            if (iDATMessageBox.QuestionMessage(_strMsg, this.Text) == DialogResult.Yes)
            {
                for (_intAddCount = 0; _intAddCount < _intRowCount; _intAddCount++)
                {
                    //0으로 고정한 것은 DeleteRow(0)로 인해서 첫번째 행이 삭제되기때문에 계속 첫번째 행만 삭제함
                    _strMonth = gvList.GetRowCellValue(0, "INSPMON").ObjectNullString();
                    _strWHLoc = gvList.GetRowCellValue(0, "WHLOC").ObjectNullString();
                    _strItemCD = gvList.GetRowCellValue(0, "ITEMCODE").ObjectNullString();
                    _strType = gvList.GetRowCellValue(0, "STOCKTYPE").ObjectNullString();
                    _strLOT = gvList.GetRowCellValue(0, "LOT").ObjectNullString();
                    _strCntNO = gvList.GetRowCellValue(0, "CNTNO").ObjectNullString();
                    _strSide = gvList.GetRowCellValue(0, "SIDE").ObjectNullString();
                    _strSerial = gvList.GetRowCellValue(0, "SN").ObjectNullString();

                    if (this.Tag.ObjectNullString() == "P")
                    {
                        _strPCbLot = gvList.GetRowCellValue(0, "PCBLOT").ObjectNullString();
                        _strBoxNo = gvList.GetRowCellValue(0, "BOXNO").ObjectNullString();
                        _strPltNo = gvList.GetRowCellValue(0, "PLTNO").ObjectNullString();
                    }
                    this.ActualDel(_strMonth, _strWHLoc, _strItemCD, _strType, _strLOT, _strCntNO, _strSide, _strSerial, _strPCbLot, _strBoxNo, _strPltNo);
                    gvList.DeleteRow(0);
                }
            }            
        }
    }
}
