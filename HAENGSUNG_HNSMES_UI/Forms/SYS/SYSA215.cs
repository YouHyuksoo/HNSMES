using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// User namespace
using HAENGSUNG_HNSMES_UI.Class;
using HAENGSUNG_HNSMES_UI.WebService.Access;
using GridAlias = DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace HAENGSUNG_HNSMES_UI.Forms.SYS
{
    public partial class SYSA215 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
    {

        #region [생성]

        public SYSA215()
        {
            InitializeComponent();
        }
        private void SYSA215_Load(object sender, EventArgs e)
        {
            SetInit();
        }
        
        #endregion


        #region [Scan Event]

        public void Data_Scan(string sType, string sData)
        {
            ProcessScanEvent();
        }

        public void Data_SubScan(string sType, string sData)
        {
            ProcessScanEvent();
        }

        private void ProcessScanEvent()
        {
            try
            {
                //switch (sType)
                //{
                //    // 제품S/N
                //    case "PRODSN":
                //        txtSN.EditValue = sData;
                //        txtSN.Focus();
                //        txtSN.SelectAll();
                //        break;

                //    // LOT
                //    case "LENS_LOT":
                //        txtLot.EditValue = sData;
                //        txtLot.Focus();
                //        txtLot.SelectAll();
                //        break;

                //    default:
                //        LanguageInformation clsLan = new LanguageInformation();
                //        string sMsg = clsLan.GetMessageString("MSG_ER_COMM_027");
                //        iDATMessageBox.WARNINGMessage(sMsg + "\r\n" +
                //                                      "Type : " + sType + "\r\n" +
                //                                      "Barcode : " + sData, this.Text, 3);
                //        break;
                //}


            }
            catch (Exception)
            {
            }
        }

        private void GetGridView()
        {

            switch (tabList.SelectedTabPageIndex)
            {
                case (0):

                    BASE_DXGridHelper.Bind_Grid(gcMain1, "PKGSYS_DBA.GET_TABLESPACE_01", 1, new string[] { }, new string[] { }, false, "");

                    gvMain1.OptionsView.ColumnAutoWidth = false;
                    foreach (GridColumn gc in gvMain1.Columns)
                    {
                        if (gc.DisplayFormat.FormatType == DevExpress.Utils.FormatType.Numeric)
                        {
                            gc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                            gc.DisplayFormat.FormatString = "{0}";
                        }
                    }
                    gvMain1.BestFitColumns();

                    break;
                case (1):

                    BASE_DXGridHelper.Bind_Grid(gcMain2, "PKGSYS_DBA.GET_TABLESPACE_02", 1, new string[] { }, new string[] { }, false, "");

                    gvMain2.OptionsView.ColumnAutoWidth = false;
                    foreach (GridColumn gc in gvMain2.Columns)
                    {
                        if (gc.DisplayFormat.FormatType == DevExpress.Utils.FormatType.Numeric)
                        {
                            gc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                            gc.DisplayFormat.FormatString = "{0}";
                        }
                    }
                    gvMain2.BestFitColumns();

                    break;
                case (2):

                    BASE_DXGridHelper.Bind_Grid(gcMain3, "PKGSYS_DBA.GET_TABLESPACE_03", 1, new string[] { }, new string[] { }, false, "");

                    gvMain3.OptionsView.ColumnAutoWidth = false;
                    foreach (GridColumn gc in gvMain3.Columns)
                    {
                        if (gc.DisplayFormat.FormatType == DevExpress.Utils.FormatType.Numeric)
                        {
                            gc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                            gc.DisplayFormat.FormatString = "{0}";
                        }
                    }
                    gvMain3.BestFitColumns();

                    break;
                default:

                    BASE_DXGridHelper.Bind_Grid(gcMain4, "PKGSYS_DBA.GET_TABLESPACE_04", 1, new string[] { "A_SEGMENT" }, new string[] { txtSEGMENT.EditValue.ToString() }, false, "");

                    gvMain4.OptionsView.ColumnAutoWidth = false;
                    foreach (GridColumn gc in gvMain4.Columns)
                    {
                        if (gc.DisplayFormat.FormatType == DevExpress.Utils.FormatType.Numeric)
                        {
                            gc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                            gc.DisplayFormat.FormatString = "{0}";
                        }
                    }
                    gvMain4.BestFitColumns();

                    break;
            }

        }

        #endregion


        #region [Button Event]

        public void InitButton_Click()
        {
            SetInit();
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
            GetGridView();
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

        #region [FUNCTION]

        private void SetInit()
        {
            //BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(
            //                               gleModel
            //                             , "PKGBAS_BASE.GET_LENSITEM"
            //                             , 1
            //                             , new string[] {
            //                                 "A_TYPE"
            //                                            }
            //                             , new string[] {
            //                                 "MODEL"
            //                                            }
            //                             , "ITEMCODE"
            //                             , "PARTNO"
            //                             , "PARTNO,ITEMNAME,SPEC"
            //                             );
        }

        #endregion


        #region [ETC Event]

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //if (gvMain1.RowCount == 0)
                //    return;

                //if (gvMain1.FocusedRowHandle < 0)
                //{
                //    // 취소할 데이터를 선택하여 주십시오
                //    iDATMessageBox.ErrorMessage("MSG_ER_COMM_046", this.Text, 3);
                //    return;
                //}

                //gvMain1.DeleteRow(gvMain1.FocusedRowHandle);
            }
            catch (Exception)
            {
            }
        }

        #endregion

    }
}