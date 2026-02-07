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


namespace HAENGSUNG_HNSMES_UI.Forms.COM
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : COMSYSTEMHISTORY<br/>
    ///      기능 : 시스템사용이력조회 <br/>
    ///      작성 : 허지량<br/>
    ///최초작성일 : 2011-02-07<br/>
    ///  수정사항 : <br/>
    ///==========================================================
    ///</summary>
    public partial class COMSYSTEMHISTORY : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {
        #region 전역변수

        #endregion

        #region 생성

        public COMSYSTEMHISTORY()
        {
            InitializeComponent();
        }

        #endregion

        #region 버튼설정

        public string BUTTON()
        {
            return "init, Search";
        }

        #endregion

        #region 버튼이벤트

        public void InitButton_Click()
        {
            dteDate.EditValue = DateTime.Today;
            gcList.DataSource = null;
            gcError.DataSource = null;
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
            if (dteDate.EditValue + "" == "")
            {
                iDATMessageBox.WARNINGMessage("조회일자는 필수 선택 항목입니다.", "조회", 3);
                return;
            }

            using (DevExpress.Utils.WaitDialogForm _msg = new DevExpress.Utils.WaitDialogForm("Loading Data", "Loading"))
            {
                _msg.TopMost = false;
                _msg.BringToFront();
                gvList.Columns.Clear();

                string _strProc = "PKG_BASE.GET_SYSTEMUSEHISTORY";  //프로시져 명

                BASE_DXGridHelper.Bind_Grid(gcList,
                    _strProc, 
                    1, 
                    new string[] { 
                                   "A_CLIENT"
                                 , "A_COMPANY"
                                 , "A_PLANT"
                                 , "A_DATE" 
                                 }, 
                    new string[] { 
                                   Global.Global_Variable.CLIENT
                                 , Global.Global_Variable.COMPANY
                                 , Global.Global_Variable.PLANT
                                 , dteDate.DateTime.ToString("yyyyMMdd") 
                                 }, 
                    false);
            }
        }

        public void DeleteButton_Click()
        {
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

        #endregion

        #region 일반이벤트

        private void gvList_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks != 1) return;
            if (e.RowHandle < 0) return;

            string _strFromDate = Convert.ToDateTime(gvList.GetRowCellValue(e.RowHandle, "STARTDATETIME")).ToString("yyyyMMddHHmmss");
            string _strToDate = DateTime.Now.ToString("yyyyMMddHHmmss");

            if (gvList.GetRowCellValue(e.RowHandle, "ENDDATETIME") != DBNull.Value)
            {
                _strToDate = Convert.ToDateTime(gvList.GetRowCellValue(e.RowHandle, "ENDDATETIME")).ToString("yyyyMMddHHmmss");
            }

            BASE_DXGridHelper.Bind_Grid(gcError, 
                "PKG_BASE.GET_LOGMESSAGE", 
                1, 
                new string[] { 
                               "A_CLIENT"
                             , "A_COMPANY"
                             , "A_PLANT"
                             , "A_FROMDATETIME"
                             , "A_TODATETIME" 
                             }, 
                new string[] { 
                               Global.Global_Variable.CLIENT
                             , Global.Global_Variable.COMPANY
                             , Global.Global_Variable.PLANT
                             , _strFromDate
                             , _strToDate 
                             }, 
                false);
        }

        #endregion

    }
}