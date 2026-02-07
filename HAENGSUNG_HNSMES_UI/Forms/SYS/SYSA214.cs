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
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : SYSA214<br/>
    ///      기능 : ERROR LOG 마스터 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    public partial class SYSA214 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
    {
        // ******************************************* Base From Class ************************************
        // BASE_clsDevexpressGridUtil          DevExpress Grid 관련 Util Class.
        // BASE_db;                            웹서비스 DB처리 관련 Util Class.
        // BASE_DXGridHelper;                  DevExpress GridControl 데이터 Bind관련 Class
        // BASE_DXGridLookUpHelper;            DevExpress GridLookUp 데이터 Bind관련 Class
        // BASE_IDATLayoutUtil;                DevExpress LayoutControl Util Class.
        // BASE_Language;                      Language Util. ex) BASE_Language.GetMessageString("Code") 
        // ************************************************************************************************
        #region [생성]

        public SYSA214()
        {
            InitializeComponent();
        }
        private void SYSA214_Load(object sender, EventArgs e)
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
              
            }
            catch (Exception)
            {
            }
        }

        private void GetGridView()
        {
            BASE_DXGridHelper.Bind_Grid( gcMain1
                                       , "PKGSYS_COMM.GET_ERROR_LOG"
                                       , 1
                                       , new string[] { 
                                         "A_CLIENT"
                                       , "A_COMPANY"
                                       , "A_PLANT" }
                                       , new string[] { 
                                         Global.Global_Variable.CLIENT
                                       , Global.Global_Variable.COMPANY
                                       , Global.Global_Variable.PLANT }
                                       , false
                                       , ""
                                       );

            gvMain1.OptionsView.ColumnAutoWidth = false;
            foreach (GridColumn gc in gvMain1.Columns)
            {
                if (gc.DisplayFormat.FormatType == DevExpress.Utils.FormatType.Numeric)
                {
                    gc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gc.DisplayFormat.FormatString = "{0}";
                }
            }
            gvMain1.Columns["LOGTIMEKEY"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gvMain1.Columns["LOGTIMEKEY"].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss.ff";
            gvMain1.OptionsView.ColumnAutoWidth = true;
            gvMain1.BestFitMaxRowCount = 0;
            gvMain1.BestFitColumns();

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
           
        }

        #endregion


        #region [ETC Event]

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
              
            }
            catch (Exception)
            {
            }
        }

        #endregion

    }
}
