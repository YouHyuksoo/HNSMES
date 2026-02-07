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
using DevExpress.XtraEditors.Repository;

// User namespace
using HAENGSUNG_HNSMES_UI.Class;
using GridAlias = DevExpress.XtraGrid.Views.Grid;
using HAENGSUNG_HNSMES_UI.WebService.Access;
using HAENGSUNG_HNSMES_UI.WebService.Business;


namespace HAENGSUNG_HNSMES_UI.Forms.MST
{
    // 조회
    // 자재입고, 자재출고, 자재입/출고, Split/Merge이력

    public partial class MSTB201 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {
        #region [Form Event]

        public MSTB201()
        {
            InitializeComponent();           
        }

        private void MSTB201_Load(object sender, EventArgs e)
        {

        }

        private void MSTB201_Shown(object sender, EventArgs e)
        {
            this.Set_Init();
        }

        

        #endregion

        

        #region [Button Event]

        public void InitButton_Click()
        {
            this.Set_Init();
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
            gcList1.DataSource = null;
            gcList2.DataSource = null;   
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( glePartNo
                                                       , "PKGBAS_BASE.GET_ITEM"
                                                       , 2
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT"
                                                       , "A_VIEW"
                                                       , "A_ITEMTYPE" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT
                                                       , "0"
                                                       , "1" }
                                                       , "PARTNO"
                                                       , "PARTNO"
                                                       , "PARTNO, ITEMNAME"
                                                       );
        }

        private void GetGridViewList()
        {
            gcList1.DataSource = null;
            gcList2.DataSource = null;   

            BASE_DXGridHelper.Bind_Grid_Int( gcList2
                                           , "PKGBAS_BASE.GET_BOMGRP_LIST"
                                           , 1
                                           , new string[] {
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_PARTNO" }
                                           , new string[] {
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , glePartNo.EditValue.ObjectNullString() }
                                           , true
                                           , "BOMGRP,FPATH"
                                           , false
                                           , "REV"
                                           ); 

            
        }

        private void GetGridViewList1(string p_sBomgrp, string p_sRev)
        {
            BASE_DXGridHelper.Bind_Grid_Int(gcList1
                                           , "PKGBAS_BASE.GET_BOM_LIST"
                                           , 1
                                           , new string[] {
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_BOMGRP"
                                           , "A_REV" }
                                           , new string[] {
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , p_sBomgrp
                                           , p_sRev }
                                           , true
                                           , ""
                                           , false
                                           , "REV,SEQ"
                                           ); 

            gvList1.Columns["ASSYUSAGE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;     
            gvList1.Columns["ASSYUSAGE"].DisplayFormat.FormatString = "{0:n6}";

            gvList1.OptionsView.ColumnAutoWidth = false;
            gvList1.BestFitColumns();
        }
        
        
        #endregion

        private void gvList2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvList2.RowCount == 0)
            {
                gcList1.DataSource = null;
                return;
            }

            if (e.FocusedRowHandle < 0) return;

            string _sBomgrp = gvList2.GetRowCellValue(e.FocusedRowHandle, "BOMGRP").ToString();
            string _sRev = gvList2.GetRowCellValue(e.FocusedRowHandle, "REV").ToString();

            if (_sBomgrp != "" && _sRev != "" )
                this.GetGridViewList1(_sBomgrp, _sRev);
        }

        private void gvList2_RowCellClick(object sender, GridAlias.RowCellClickEventArgs e)
        {
            if (e.Column.Caption == "FILES")
            {
                if (gvList2.GetFocusedRowCellValue("FPATH").ObjectNullString() != "")
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    
                    sfd.InitialDirectory = @"C:\";
                    int iFileNameIdx = gvList2.GetFocusedRowCellValue("FPATH").ObjectNullString().LastIndexOf('/');
                    int iFileExt = gvList2.GetFocusedRowCellValue("FPATH").ObjectNullString().LastIndexOf('.');
                    sfd.FileName = gvList2.GetFocusedRowCellValue("FPATH").ObjectNullString().Substring(iFileNameIdx + 1);
                    sfd.DefaultExt = gvList2.GetFocusedRowCellValue("FPATH").ObjectNullString().Substring(iFileExt + 1);

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        FTPHelper ftp = new FTPHelper(Global.Global_Variable.FTP_IP, Global.Global_Variable.FTP_ID, Global.Global_Variable.FTP_PW);
                        ftp.download(gvList2.GetFocusedRowCellValue("FPATH").ObjectNullString(), sfd.FileName);
                        iDATMessageBox.OKMessage("DBMSG_SUCCESS", this.Text, 3);
                    }
                }
            }
        }


      
    }
}
