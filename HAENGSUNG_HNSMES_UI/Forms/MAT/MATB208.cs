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
using HAENGSUNG_HNSMES_UI.WebService.Access;
using GridAlias = DevExpress.XtraGrid.Views.Grid;

namespace HAENGSUNG_HNSMES_UI.Forms.MAT
{
	public partial class MATB208 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
	{
        LanguageInformation m_clsLan;

		#region [Form Event]

		public MATB208()
		{
			InitializeComponent();
		   
		}

		private void Form_Load(object sender, EventArgs e)
		{
            m_clsLan = new LanguageInformation();
		}

		private void Form_Shown(object sender, EventArgs e)
		{
			MainButton_INIT.PerformClick();
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
            gvList.FocusedRowHandle = -1;

            DataRow[] _arrDr = (gcList.DataSource as DataTable).Select(string.Format("SEL = 'Y'"));

            if (_arrDr.Length < 1)
            {
                iDATMessageBox.WARNINGMessage(m_clsLan.GetMessageString("MSG_ER_MAT_021"), "Cancel", 3); //폐기할 데이터를 선탁하세요.
                return;
            }
            else
            {
                DataTable _dt = (gcList.DataSource as DataTable).Copy();
                _dt.Clear();
              
                foreach (DataRow _dr in _arrDr)
                {
                    DataRow dRow = _dt.NewRow();

                    for (int nCol = 0; nCol < _dt.Columns.Count; nCol++)                      
                        dRow[nCol] = _dr[nCol];

                    _dt.Rows.Add(dRow);
                }

                string _strXML = GetDataTableToXml(_dt);
                string _strLanMsg = m_clsLan.GetMessageString("MSG_QS_MAT_002"); //선택항목을 폐기하시겠습니까?

                if (iDATMessageBox.QuestionMessage(_strLanMsg, "Cancel") == System.Windows.Forms.DialogResult.Yes)
                {
                    WSResults _result = BASE_db.Execute_Proc( "PKGPDA_MAT.SET_RELEASE"
                                                            , 1
                                                            , new string[] {
                                                              "A_CLIENT"
                                                            , "A_COMPANY"
                                                            , "A_PLANT"
                                                            , "A_JOB"
                                                            , "A_PARAM1"
                                                            , "A_PARAM2"
                                                            , "A_XML"
                                                            , "A_REMARKS"
                                                            , "A_EHRCODE" }
                                                            , new string[] {
                                                              Global.Global_Variable.CLIENT
                                                            , Global.Global_Variable.COMPANY
                                                            , Global.Global_Variable.PLANT
                                                            , "DISCARD"
                                                            , "LOC005"
                                                            , ""
                                                            , _strXML
                                                            , memRemarks.Text
                                                            , Global.Global_Variable.EHRCODE }
                                                            );

                    if (_result.ResultInt != 0)
                    {
                        iDATMessageBox.WARNINGMessage(_result.ResultString, "DISCARD", 3); //폐기할 데이터를 선탁하세요.
                        return;
                    }

                    MainButton_Search.PerformClick();
                }
            }
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

		#region Scanner

		public void Data_Scan(string p_strType, string p_strData)
		{
			ProcessScanEvent(p_strType, p_strData);
		}

		public void Data_SubScan(string p_strType, string p_strData)
		{
			ProcessScanEvent(p_strType, p_strData);
		}

		private void ProcessScanEvent(string p_strType, string p_strData)
		{
			switch (p_strType)
			{
				case "MATSN":
					this.GetGridViewList();
					break;
				default:
					LanguageInformation clsLan = new LanguageInformation();
					string _strMsg = clsLan.GetMessageString("MSG_ER_COMM_027"); //현재 화면에서 사용할 수 없는 바코드 입니다.
					iDATMessageBox.WARNINGMessage(_strMsg + "\r\n" + "Type : " + p_strType + "\r\n" + "Barcode : " + p_strData, this.Text, 3);
					break;
			}
		}

		#endregion

		#region [Private Method]

		private void Set_Init()
		{
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

			gleWH.EditValue = null;
			gleWHLoc.EditValue = null;
			gleWHLoc.Enabled = false;
			gcList.DataSource = null;
			txtSN.Text = "";
		}
	 


		private void GetGridViewList()
		{
            memRemarks.EditValue = null;

            BASE_DXGridHelper.Bind_Grid( gcList
                                       , "PKGBAS_MAT.GET_BAD_MAT_LIST"
                                       , 1
                                       , new string[] {
                                         "A_CLIENT"
                                       , "A_COMPANY"
                                       , "A_PLANT"
                                       , "A_WHLOC"
                                       , "A_SN"
                                       , "A_PARTNO" }
                                       , new string[] {
                                         Global.Global_Variable.CLIENT
                                       , Global.Global_Variable.COMPANY
                                       , Global.Global_Variable.PLANT
                                       , gleWHLoc.EditValue.ObjectNullString()
                                       , txtSN.Text
                                       , txtPartNo.Text }
                                       , false
                                       , "LOC,ITEMCODE"
                                       , false
                                       );

            gvList.BeginUpdate();
            gvList.OptionsBehavior.Editable = true;
            gvList.Columns["QTY"].OptionsColumn.AllowEdit = true;
            DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repository1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            repository1.EditMask = "N00";
            gvList.Columns["QTY"].ColumnEdit = repository1;
            gvList.BestFitColumns();
            gvList.EndUpdate();
		}

		#endregion

		private void gleWH_EditValueChanged(object sender, EventArgs e)
		{
			if (gleWH.EditValue == null)
			{
				gleWHLoc.Enabled = false;
				gleWHLoc.EditValue = null;
                gcList.DataSource = null;
			}
			else
			{
				gleWHLoc.Enabled = true;
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
                                                           , "1" }
                                                           , "WHLOC"
                                                           , "WHLOCNAME"
                                                           , "WHLOC, WHLOCNAME, REMARKS"
                                                           );  
			}
		}

        private void gvList_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (gvList.FocusedColumn.FieldName == "QTY")
            {
                if (gvList.GetRowCellValue(gvList.FocusedRowHandle, "SN").ObjectNullString() != "NONE")             
                    e.Cancel = true;
            }

            //string _strSN = gvList.GetRowCellValue(gvList.FocusedRowHandle, "SN").ObjectNullString();

            //GridView view = sender as GridView; 

            //if(view.FocusedColumn.FieldName == "QTY" && (_strSN != "" || _strSN != "NONE"))
            //{
            //    e.Cancel = true;
            //}
        }

	}
}
