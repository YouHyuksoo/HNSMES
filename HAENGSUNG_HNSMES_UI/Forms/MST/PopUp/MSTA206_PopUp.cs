using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using HAENGSUNG_HNSMES_UI.Class;
using HAENGSUNG_HNSMES_UI.WebService.Access;

using IDAT.Controls;
using NGS.WCFClient;
using NGS.WCFClient.DatabaseService;

namespace HAENGSUNG_HNSMES_UI.Forms.MST.PopUp
{
    public partial class MSTA206_PopUp : BASE.Form
    {
        private MSTA206 mParent = null;

        public MSTA206 _ParentForm
        {
            get { return mParent; }
            set { mParent = value; }
        }

        public MSTA206_PopUp()
        {
            InitializeComponent();
        }

        private void MSTA206_PopUp_Load(object sender, EventArgs e)
        {
            layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 58, 2);
            Set_BomGrp();
        }

        private void Set_BomGrp()
        {
            //iDATControlBinding _clsBind = new iDATControlBinding();

            /// BOM 그룹 리스트를 가져온다.

            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(
                                     gleBomGrp
                                   , "PKGBAS_BASE.GET_BOMGRP"
                                   , 1
                                   , new string[] { 
                                                    "A_CLIENT"
                                                  , "A_COMPANY"
                                                  , "A_PLANT"
                                                  }
                                   , new string[] { 
                                                    Global.Global_Variable.CLIENT
                                                  , Global.Global_Variable.COMPANY
                                                  , Global.Global_Variable.PLANT
                                                  }
                                   , "BOMGRP"
                                   , "BOMGRP"
                                   , "BOMGRP, REL "
                                  );
        }

        private void Set_InitTreeList()
        {
            ///// BOM Tree 바인딩

            WSResults resultDS = BASE_db.Execute_Proc("PKGBAS_BASE.GET_BOM"
                                                               , 2
                                                               , new string[] {
                                                                                 "A_CLIENT"
                                                                               , "A_COMPANY"
                                                                               , "A_PLANT"
                                                                               , "A_BOMGRP"
                                                                               , "A_GRPREL"
                                                                              }
                                                               , new string[] {
                                                                                Global.Global_Variable.CLIENT
                                                                              , Global.Global_Variable.COMPANY
                                                                              , Global.Global_Variable.PLANT
                                                                              , gleBomGrp.EditValue + ""
                                                                              , gleBomGrp.Properties.View.GetRowCellValue(gleBomGrp.Properties.View.FocusedRowHandle, "REL") + ""
                                                                              }
                                                              );


            if (resultDS.ResultDataSet == null)
            {
                return;
            }

            tlBOM.Update();

            //resultDS.ReturnDataSet.Tables[0].Columns.Add("UPRPARENT", Type.GetType("System.String"));

            tlBOM.KeyFieldName = "IDX";
            tlBOM.ParentFieldName = "UPRIDX";
            tlBOM.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowAlways;
            tlBOM.DataSource = resultDS.ResultDataSet.Tables[0];
            tlBOM.OptionsView.ShowColumns = true;
            tlBOM.OptionsBehavior.Editable = true;
            tlBOM.OptionsView.ShowRoot = true;


            //tlBOM.Columns["NO"].Visible = false;
            //tlBOM.Columns["SUB_NO"].Visible = false;
            tlBOM.Columns["DISP_NO"].Visible = false;
            tlBOM.Columns["SEQ"].Visible = false;
            tlBOM.Columns["PROJECT"].Visible = false;
            tlBOM.Columns["ITEMCODE"].Visible = false;
            tlBOM.Columns["DRWNO"].Visible = false;
            tlBOM.Columns["UPRITEM"].Visible = false;
            tlBOM.Columns["UPRPARENT"].Visible = false;
            tlBOM.Columns["USEFLAG"].Visible = false;
            //tlBOM.Columns["IDX"].Visible = false;
            //tlBOM.Columns["UPRIDX"].Visible = false;

            tlBOM.OptionsBehavior.AutoChangeParent = false;
            tlBOM.OptionsBehavior.CanCloneNodesOnDrop = true;
            tlBOM.OptionsBehavior.CloseEditorOnLostFocus = false;
            tlBOM.OptionsBehavior.DragNodes = true;
            tlBOM.OptionsBehavior.KeepSelectedOnClick = false;
            tlBOM.OptionsBehavior.ShowEditorOnMouseUp = true;
            tlBOM.OptionsBehavior.SmartMouseHover = false;
            //tlBOM.Columns["PARTNO"].OptionsColumn.AllowEdit = false;
            tlBOM.Columns["ITEMNAME"].OptionsColumn.AllowEdit = false;
            tlBOM.Columns["SEQ"].OptionsColumn.AllowEdit = false;
            //tlBOM.Columns["USEFLAG"].ColumnEdit = repositoryItemComboBox_USEYN;
            //tlBOM.Columns["ASSYUSAGE"].ColumnEdit =  repositorySpin;
            //tlBOM.Columns["PARTNO"].ColumnEdit = repositoryItemButton;
            tlBOM.Columns["PARTNO"].VisibleIndex = 0;

            for (int i = 0; i < tlBOM.Columns.Count; i++)
            {
                tlBOM.Columns[i].OptionsColumn.AllowSort = false;
            }

            tlBOM.OptionsView.AutoWidth = true;

            LanguageInformation _clsLan = new LanguageInformation();
            tlBOM.Columns["PARTNO"].Caption = _clsLan.GetMessageString("PARTNO");
            tlBOM.Columns["ASSYUSAGE"].Caption = _clsLan.GetMessageString("ASSYUSAGE");
            tlBOM.Columns["ITEMNAME"].Caption = _clsLan.GetMessageString("ITEMNAME");
            tlBOM.Columns["DRWNO"].Caption = _clsLan.GetMessageString("DRWNO");
            tlBOM.Columns["UNITCODE"].Caption = _clsLan.GetMessageString("UNITCODE");

            tlBOM.BestFitColumns();


            // 스타일 설정
            //SetStyleFormatCondition_CustomRootMenu(tlBOM, "USEFLAG", "N", GetStyleFormatObjApperanceColor_USEYN);


            tlBOM.Cursor = Cursors.Hand;
            tlBOM.ExpandAll();

            //resultDS.ReturnDataSet.Tables[0].AcceptChanges();


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            //foreach (DataRow dr in ((DataTable)tlBOM.DataSource).Rows)
            //{
            //    DataRow drNew = ((DataTable)mParent.tlBOM.DataSource).NewRow();

            //    for (int i = 0; i < ((DataTable)tlBOM.DataSource).Columns.Count; i++)
            //    {
            //        drNew[i] = dr[i];
            //    }

            //    drNew["UPRIDX"] = DBNull.Value;
            //    drNew["IDX"] = DBNull.Value;

            //    ((DataTable)mParent.tlBOM.DataSource).Rows.Add(drNew);
            //}

            mParent.tlBOM.DataSource = ((DataTable)tlBOM.DataSource).Copy();
            mParent.tlBOM.ExpandAll();

            this.Close();
        }

        private void gleBomGrp_EditValueChanged(object sender, EventArgs e)
        {
            if (gleBomGrp.EditValue + "" != "") Set_InitTreeList();
        }
    }
}