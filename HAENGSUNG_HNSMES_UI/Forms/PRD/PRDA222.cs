using System;
using System.IO;
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
using HAENGSUNG_HNSMES_UI.WebService.Access;

namespace HAENGSUNG_HNSMES_UI.Forms.PRD
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : PRDA222<br/>
    ///      기능 : 작업실적(압착검사) <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    /// 최초작성일 : 2021-03-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>

    public partial class PRDA222 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton, HAENGSUNG_HNSMES_UI.Class.itfScanner
    {
        // ******************************************* Base From Class ************************************
        // BASE_clsDevexpressGridUtil          DevExpress Grid 관련 Util Class.
        // BASE_db;                            웹서비스 DB처리 관련 Util Class.
        // BASE_DXGridHelper;                  DevExpress GridControl 데이터 Bind관련 Class
        // BASE_DXGridLookUpHelper;            DevExpress GridLookUp 데이터 Bind관련 Class
        // BASE_IDATLayoutUtil;                DevExpress LayoutControl Util Class.
        // BASE_Language;                      Language Util. ex) BASE_Language.GetMessageString("Code") 
        // ************************************************************************************************
        private const int _Minvalue = 0;
        private const int _Maxvalue = 999;
        FTPHelper ftp = null;

        #region [Form Event]


        public PRDA222()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            // 최초 폼 로드 시 발생 이벤트
            InitForm();
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            // ************************************************************************************
            // 컨트롤 초기화는 필수적으로 Shown이벤트에 작성을 하도록 합니다.
            // ************************************************************************************
            ftp = new FTPHelper(Global.Global_Variable.FTP_IP, Global.Global_Variable.FTP_ID, Global.Global_Variable.FTP_PW);
        }

        #endregion

        #region [Button Event]

        public void InitButton_Click()
        {
            // 초기화 관련 구현은 여기에 구현 ***

            ////  현재 프로그램 모드정보를 변경한다.
            ////  IDAT.Devexpress.FORM.UPDATEITEMTYPE.None = 초기화 모드
            ////  IDAT.Devexpress.FORM.UPDATEITEMTYPE.New  = 신규 모드
            ////  IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit = 수정 모드
            this.InitForm();
            //base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);
        }


        public void NewButton_Click()
        {
            // 신규 버튼 클릭 이벤트
        }


        public void EditButton_Click()
        {
            // 수정 버튼 클릭 이벤트
        }


        public void StopButton_Click()
        {
            // 중지 버튼 클릭 이벤트
        }


        public void SearchButton_Click()
        {
            // 검색 버튼 클릭 이벤트
            GetGridViewList();
        }


        public void SaveButton_Click()
        {
            // 저장 버튼 클릭 이벤트
        }


        public void PrintButton_Click()
        {
            // 출력 버튼 클릭 이벤트
        }


        public void RefreshButton_Click()
        {
            // 새로 고침 버튼 클릭 이벤트
        }

        public void DeleteButton_Click()
        {
            // 삭제 버튼 클릭 이벤트
        }


        #endregion

        #region Scan Event

        public void Data_Scan(string sType, string sData)
        {
            ProcessScanEvent(sType, sData);
        }

        public void Data_SubScan(string sType, string sData)
        {
            ProcessScanEvent(sType, sData);
        }

        private void ProcessScanEvent(string sType, string sData)
        {
            decimal _dMeasure;
            string _sMeasure;
            
            int _idx = sData.LastIndexOf(" ");

            if (_idx >= 0)
                _sMeasure = sData.Substring(_idx);
            else
                _sMeasure = sData;

            if (!decimal.TryParse(_sMeasure, out _dMeasure))
                _dMeasure = 0;

            if (drgInspItem.SelectedIndex == 0) spiCCH.EditValue = _dMeasure;
            else if (drgInspItem.SelectedIndex == 1) spiCCW.EditValue = _dMeasure;
            else if (drgInspItem.SelectedIndex == 2) spiICH.EditValue = _dMeasure;
            else if (drgInspItem.SelectedIndex == 3) spiICW.EditValue = _dMeasure;
            else if (drgInspItem.SelectedIndex == 4) spiTEN.EditValue = _dMeasure;
            else if (drgInspItem.SelectedIndex == 5) spiRESIS.EditValue = _dMeasure;
        }

        #endregion

        #region [Private Function]
        private void ControlInit()
        {
            drgInspItem.EditValue = null;

            txtWire.EditValue = string.Empty;
            txtTerminal.EditValue = string.Empty;

            txtCCHlow.EditValue = string.Empty;
            txtCCHhigh.EditValue = string.Empty;
            txtCCWlow.EditValue = string.Empty;
            txtCCWhigh.EditValue = string.Empty;
            txtICHlow.EditValue = string.Empty;
            txtICHhigh.EditValue = string.Empty;
            txtICWlow.EditValue = string.Empty;
            txtICWhigh.EditValue = string.Empty;
            txtTENlow.EditValue = string.Empty;
            txtTENhigh.EditValue = string.Empty;
            txtRESISlow.EditValue = string.Empty;
            txtRESIShigh.EditValue = string.Empty;

            spiCCH.EditValue = 0; spiCCH.Enabled = false;
            spiCCW.EditValue = 0; spiCCW.Enabled = false;
            spiICH.EditValue = 0; spiICH.Enabled = false;
            spiICW.EditValue = 0; spiICW.Enabled = false;
            spiTEN.EditValue = 0; spiTEN.Enabled = false;
            spiRESIS.EditValue = 0; spiRESIS.Enabled = false;

            lblCCH.Text = string.Empty;
            lblCCW.Text = string.Empty;
            lblICH.Text = string.Empty;
            lblICW.Text = string.Empty;
            lblTEN.Text = string.Empty;
            lblRESIS.Text = string.Empty;

            lblCCH.BackColor = 
            lblCCW.BackColor =
            lblICH.BackColor =
            lblICW.BackColor =
            lblTEN.BackColor =
            lblRESIS.BackColor = Color.FromArgb(235, 236, 239);

            txtFrontFile.EditValue = null;
            txtRearFile.EditValue = null;
        }

        private void InitForm()
        {
            this.ControlInit();
            this.GetInspObject();
        }

        private void GetInspObject()
        {
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleInspobject
                                                       , "PKGPRD_QC.GET_INSP_OBJECT"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT }
                                                       , "INSPOBJECT"
                                                       , "INSPOBJECT"
                                                       , "WIRE, TERMINAL"
                                                       );

           
        }

        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid_Int( gcList
                                           , "PKGPRD_QC.GET_INSP_HISTORY"
                                           , 1
                                           , new string[] { 
                                             "A_CLIENT"
                                           , "A_COMPANY"
                                           , "A_PLANT"
                                           , "A_SDATE"
                                           , "A_EDATE" }
                                           , new string[] { 
                                             Global.Global_Variable.CLIENT
                                           , Global.Global_Variable.COMPANY
                                           , Global.Global_Variable.PLANT
                                           , dteFromTo.StartDate
                                           , dteFromTo.EndDate }
                                           , true
                                           , "FPATH,RPATH"
                                           , false
                                           , ""
                                           );

            gvList.Columns["CCH"].DisplayFormat.FormatString = "{0:n3}";
            gvList.Columns["CCW"].DisplayFormat.FormatString = "{0:n3}";
            gvList.Columns["ICH"].DisplayFormat.FormatString = "{0:n3}";
            gvList.Columns["ICW"].DisplayFormat.FormatString = "{0:n3}";
            gvList.Columns["TENSION"].DisplayFormat.FormatString = "{0:n3}";
            gvList.Columns["RESISTANCE"].DisplayFormat.FormatString = "{0:n3}";
            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();

        }

        #endregion

        #region [Control Event]

        private void btnSave_Click(object sender, EventArgs e)
        {
            string p_CCH = string.Empty;
            string p_CCW = string.Empty;
            string p_ICH = string.Empty;
            string p_ICW = string.Empty;
            string p_TEN = string.Empty;
            string p_RESIS = string.Empty;

            if (txtCCHlow.EditValue.ObjectNullString() != "" || txtCCHhigh.EditValue.ObjectNullString() != "")
                p_CCH = spiCCH.EditValue.ObjectNullString();

            if (txtCCWlow.EditValue.ObjectNullString() != "" || txtCCWhigh.EditValue.ObjectNullString() != "")
                p_CCW = spiCCW.EditValue.ObjectNullString();

            if (txtICHlow.EditValue.ObjectNullString() != "" || txtICHhigh.EditValue.ObjectNullString() != "")
                p_ICH = spiICH.EditValue.ObjectNullString();

            if (txtICWlow.EditValue.ObjectNullString() != "" || txtICWhigh.EditValue.ObjectNullString() != "")
                p_ICW = spiICW.EditValue.ObjectNullString();

            if (txtTENlow.EditValue.ObjectNullString() != "" || txtTENhigh.EditValue.ObjectNullString() != "")
                p_TEN = spiTEN.EditValue.ObjectNullString();

            if (txtRESISlow.EditValue.ObjectNullString() != "" || txtRESIShigh.EditValue.ObjectNullString() != "")
                p_RESIS = spiRESIS.EditValue.ObjectNullString();
            
            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result =
                BASE_db.Execute_Proc("PKGPRD_QC.SET_INSP_CRIMP"
                                    , 3
                                    , new string[] { 
                                      "A_CLIENT"
                                    , "A_COMPANY"
                                    , "A_PLANT"
                                    , "A_WIRE"
                                    , "A_TERMINAL"
                                    , "A_CCH"
                                    , "A_CCW"
                                    , "A_ICH"
                                    , "A_ICW"
                                    , "A_TEN"
                                    , "A_RESIS"
                                    , "A_FFILE"
                                    , "A_RFILE"
                                    , "A_USER" }
                                    , new object[] { 
                                      Global.Global_Variable.CLIENT
                                    , Global.Global_Variable.COMPANY
                                    , Global.Global_Variable.PLANT
                                    , txtWire.EditValue.ObjectNullString()
                                    , txtTerminal.EditValue.ObjectNullString()
                                    , p_CCH
                                    , p_CCW
                                    , p_ICH
                                    , p_ICW
                                    , p_TEN
                                    , p_RESIS
                                    , Path.GetFileName(txtFrontFile.EditValue.ObjectNullString()) 
                                    , Path.GetFileName(txtRearFile.EditValue.ObjectNullString()) 
                                    , Global.Global_Variable.EHRCODE }
                                    );

            if (_Result.ResultInt == 0)
            {
                /*전단 검사성적서 업로드*/
                if (txtFrontFile.EditValue.ObjectNullString() != "")
                {
                    if (!ftp.checkDirectoryExists(_Result.ResultDataSet.Tables[0].Rows[0]["LEVEL1"].ObjectNullString()))
                        ftp.createDirectory(_Result.ResultDataSet.Tables[0].Rows[0]["LEVEL1"].ObjectNullString());

                    if (!ftp.checkDirectoryExists(_Result.ResultDataSet.Tables[0].Rows[0]["LEVEL1"].ObjectNullString() + "/" + _Result.ResultDataSet.Tables[0].Rows[0]["LEVEL2"].ObjectNullString()))
                        ftp.createDirectory(_Result.ResultDataSet.Tables[0].Rows[0]["LEVEL1"].ObjectNullString() + "/" + _Result.ResultDataSet.Tables[0].Rows[0]["LEVEL2"].ObjectNullString());

                    if (!ftp.checkDirectoryExists(_Result.ResultDataSet.Tables[0].Rows[0]["LEVEL1"].ObjectNullString() + "/" + _Result.ResultDataSet.Tables[0].Rows[0]["LEVEL2"].ObjectNullString() +  "/" + _Result.ResultDataSet.Tables[0].Rows[0]["LEVEL3"].ObjectNullString()))
                        ftp.createDirectory(_Result.ResultDataSet.Tables[0].Rows[0]["LEVEL1"].ObjectNullString() + "/" + _Result.ResultDataSet.Tables[0].Rows[0]["LEVEL2"].ObjectNullString() + "/" + _Result.ResultDataSet.Tables[0].Rows[0]["LEVEL3"].ObjectNullString());

                    if (!ftp.checkDirectoryExists(_Result.ResultDataSet.Tables[0].Rows[0]["LEVEL1"].ObjectNullString() + "/" + _Result.ResultDataSet.Tables[0].Rows[0]["LEVEL2"].ObjectNullString() + "/" + _Result.ResultDataSet.Tables[0].Rows[0]["LEVEL3"].ObjectNullString() + "/FRONT"))
                        ftp.createDirectory(_Result.ResultDataSet.Tables[0].Rows[0]["LEVEL1"].ObjectNullString() + "/" + _Result.ResultDataSet.Tables[0].Rows[0]["LEVEL2"].ObjectNullString() + "/" + _Result.ResultDataSet.Tables[0].Rows[0]["LEVEL3"].ObjectNullString() + "/FRONT");

                    ftp.upload(_Result.ResultDataSet.Tables[0].Rows[0]["LEVEL1"].ObjectNullString() + "/" + _Result.ResultDataSet.Tables[0].Rows[0]["LEVEL2"].ObjectNullString() + "/" + _Result.ResultDataSet.Tables[0].Rows[0]["LEVEL3"].ObjectNullString() + "/FRONT/" + _Result.ResultDataSet.Tables[0].Rows[0]["LEVEL4"].ObjectNullString(), txtFrontFile.EditValue.ObjectNullString());
                }

                /*후단 검사성적서 업로드*/
                if (txtRearFile.EditValue.ObjectNullString() != "")
                {
                    if (!ftp.checkDirectoryExists(_Result.ResultDataSet.Tables[1].Rows[0]["LEVEL1"].ObjectNullString()))
                        ftp.createDirectory(_Result.ResultDataSet.Tables[1].Rows[0]["LEVEL1"].ObjectNullString());

                    if (!ftp.checkDirectoryExists(_Result.ResultDataSet.Tables[1].Rows[0]["LEVEL1"].ObjectNullString() + "/" + _Result.ResultDataSet.Tables[1].Rows[0]["LEVEL2"].ObjectNullString()))
                        ftp.createDirectory(_Result.ResultDataSet.Tables[1].Rows[0]["LEVEL1"].ObjectNullString() + "/" + _Result.ResultDataSet.Tables[1].Rows[0]["LEVEL2"].ObjectNullString());

                    if (!ftp.checkDirectoryExists(_Result.ResultDataSet.Tables[1].Rows[0]["LEVEL1"].ObjectNullString() + "/" + _Result.ResultDataSet.Tables[1].Rows[0]["LEVEL2"].ObjectNullString() + "/" + _Result.ResultDataSet.Tables[1].Rows[0]["LEVEL3"].ObjectNullString()))
                        ftp.createDirectory(_Result.ResultDataSet.Tables[1].Rows[0]["LEVEL1"].ObjectNullString() + "/" + _Result.ResultDataSet.Tables[1].Rows[0]["LEVEL2"].ObjectNullString() + "/" + _Result.ResultDataSet.Tables[1].Rows[0]["LEVEL3"].ObjectNullString());

                    if (!ftp.checkDirectoryExists(_Result.ResultDataSet.Tables[1].Rows[0]["LEVEL1"].ObjectNullString() + "/" + _Result.ResultDataSet.Tables[1].Rows[0]["LEVEL2"].ObjectNullString() + "/" + _Result.ResultDataSet.Tables[1].Rows[0]["LEVEL3"].ObjectNullString() + "/REAR"))
                        ftp.createDirectory(_Result.ResultDataSet.Tables[1].Rows[0]["LEVEL1"].ObjectNullString() + "/" + _Result.ResultDataSet.Tables[1].Rows[0]["LEVEL2"].ObjectNullString() + "/" + _Result.ResultDataSet.Tables[1].Rows[0]["LEVEL3"].ObjectNullString() + "/REAR");

                    ftp.upload(_Result.ResultDataSet.Tables[1].Rows[0]["LEVEL1"].ObjectNullString() + "/" + _Result.ResultDataSet.Tables[1].Rows[0]["LEVEL2"].ObjectNullString() + "/" + _Result.ResultDataSet.Tables[1].Rows[0]["LEVEL3"].ObjectNullString() + "/REAR/" + _Result.ResultDataSet.Tables[1].Rows[0]["LEVEL4"].ObjectNullString(), txtRearFile.EditValue.ObjectNullString());
                }

                gleInspobject.EditValue = null;
                ControlInit();
                iDATMessageBox.OKMessage("MSG_OK_CREATE_001", this.Text, 5);
            }
            else
            {
                iDATMessageBox.ErrorMessage(_Result.ResultString, this.Text, 3);
            }


        }

        private void gleInspobject_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dt = gleInspobject.Properties.DataSource as DataTable;

            ControlInit();

            if (gleInspobject.EditValue.ObjectNullString() == "") return;

            DataRow[] dr = dt.Select("INSPOBJECT='" + gleInspobject.EditValue.ObjectNullString() + "'");

            if (dr.Length > 0)
            {
                drgInspItem.SelectedIndex = 0;

                txtWire.EditValue = dr[0]["WIRE"].ObjectNullString();
                txtTerminal.EditValue = dr[0]["TERMINAL"].ObjectNullString();

                txtCCHlow.EditValue = dr[0]["CCHLOW"].ObjectNullString();
                txtCCHhigh.EditValue = dr[0]["CCHHIGH"].ObjectNullString();
                if (txtCCHlow.EditValue.ObjectNullString() == "" && txtCCHhigh.EditValue.ObjectNullString() == "")
                    spiCCH.Enabled = false;

                txtCCWlow.EditValue = dr[0]["CCWLOW"].ObjectNullString();
                txtCCWhigh.EditValue = dr[0]["CCWHIGH"].ObjectNullString();
                if (txtCCWlow.EditValue.ObjectNullString() == "" && txtCCWhigh.EditValue.ObjectNullString() == "")
                    spiCCW.Enabled = false;

                txtICHlow.EditValue = dr[0]["ICHLOW"].ObjectNullString();
                txtICHhigh.EditValue = dr[0]["ICHHIGH"].ObjectNullString();
                if (txtICHlow.EditValue.ObjectNullString() == "" && txtICHhigh.EditValue.ObjectNullString() == "")
                    spiICH.Enabled = false;

                txtICWlow.EditValue = dr[0]["ICWLOW"].ObjectNullString();
                txtICWhigh.EditValue = dr[0]["ICWHIGH"].ObjectNullString();
                if (txtICWlow.EditValue.ObjectNullString() == "" && txtICWhigh.EditValue.ObjectNullString() == "")
                    spiICW.Enabled = false;

                txtTENlow.EditValue = dr[0]["TENLOW"].ObjectNullString();
                txtTENhigh.EditValue = dr[0]["TENHIGH"].ObjectNullString();
                if (txtTENlow.EditValue.ObjectNullString() == "" && txtTENhigh.EditValue.ObjectNullString() == "")
                    spiTEN.Enabled = false;

                txtRESISlow.EditValue = dr[0]["RESISLOW"].ObjectNullString();
                txtRESIShigh.EditValue = dr[0]["RESISHIGH"].ObjectNullString();
                if (txtRESISlow.EditValue.ObjectNullString() == "" && txtRESIShigh.EditValue.ObjectNullString() == "")
                    spiRESIS.Enabled = false;

            }

        }

        #endregion

        private void spiCCH_EditValueChanged(object sender, EventArgs e)
        {
            decimal _MinSpec, _MaxSpec, _ResultValue;

            if (!decimal.TryParse(txtCCHlow.EditValue.ObjectNullString(), out _MinSpec))
            {
                _MinSpec = _Minvalue;
            }

            if (!decimal.TryParse(txtCCHhigh.EditValue.ObjectNullString(), out _MaxSpec))
            {
                _MaxSpec = _Maxvalue;
            }

            _ResultValue = decimal.Parse(spiCCH.EditValue.ObjectNullString());

            if (_MinSpec <= _ResultValue && _ResultValue <= _MaxSpec)
            {
                lblCCH.Text = "PASS";
                lblCCH.BackColor = Color.LimeGreen;
                lblCCH.ForeColor = Color.Black;
            }
            else
            {
                lblCCH.Text = "NG";
                lblCCH.BackColor = Color.Red;
                lblCCH.ForeColor = Color.White;
            }
        }

        private void spiCCW_EditValueChanged(object sender, EventArgs e)
        {
            decimal _MinSpec, _MaxSpec, _ResultValue;

            if (!decimal.TryParse(txtCCWlow.EditValue.ObjectNullString(), out _MinSpec))
            {
                _MinSpec = _Minvalue;
            }

            if (!decimal.TryParse(txtCCWhigh.EditValue.ObjectNullString(), out _MaxSpec))
            {
                _MaxSpec = _Maxvalue;
            }

            _ResultValue = decimal.Parse(spiCCW.EditValue.ObjectNullString());

            if (_MinSpec <= _ResultValue && _ResultValue <= _MaxSpec)
            {
                lblCCW.Text = "PASS";
                lblCCW.BackColor = Color.LimeGreen;
                lblCCW.ForeColor = Color.Black;
            }
            else
            {
                lblCCW.Text = "NG";
                lblCCW.BackColor = Color.Red;
                lblCCW.ForeColor = Color.White;
            }

        }

        private void spiICH_EditValueChanged(object sender, EventArgs e)
        {
            decimal _MinSpec, _MaxSpec, _ResultValue;

            if (!decimal.TryParse(txtICHlow.EditValue.ObjectNullString(), out _MinSpec))
            {
                _MinSpec = _Minvalue;
            }

            if (!decimal.TryParse(txtICHhigh.EditValue.ObjectNullString(), out _MaxSpec))
            {
                _MaxSpec = _Maxvalue;
            }

            _ResultValue = decimal.Parse(spiICH.EditValue.ObjectNullString());

            if (_MinSpec <= _ResultValue && _ResultValue <= _MaxSpec)
            {
                lblICH.Text = "PASS";
                lblICH.BackColor = Color.LimeGreen;
                lblICH.ForeColor = Color.Black;
            }
            else
            {
                lblICH.Text = "NG";
                lblICH.BackColor = Color.Red;
                lblICH.ForeColor = Color.White;
            }

        }

        private void spiICW_EditValueChanged(object sender, EventArgs e)
        {
            decimal _MinSpec, _MaxSpec, _ResultValue;

            if (!decimal.TryParse(txtICWlow.EditValue.ObjectNullString(), out _MinSpec))
            {
                _MinSpec = _Minvalue;
            }

            if (!decimal.TryParse(txtICWhigh.EditValue.ObjectNullString(), out _MaxSpec))
            {
                _MaxSpec = _Maxvalue;
            }

            if (!decimal.TryParse(spiICW.EditValue.ObjectNullString(), out _ResultValue))
            {
                _ResultValue = 0;
            }
            

            if (_MinSpec <= _ResultValue && _ResultValue <= _MaxSpec)
            {
                lblICW.Text = "PASS";
                lblICW.BackColor = Color.LimeGreen;
                lblICW.ForeColor = Color.Black;
            }
            else
            {
                lblICW.Text = "NG";
                lblICW.BackColor = Color.Red;
                lblICW.ForeColor = Color.White;
            }
        }

        private void spiTEN_EditValueChanged(object sender, EventArgs e)
        {
            decimal _MinSpec, _MaxSpec, _ResultValue;

            if (!decimal.TryParse(txtTENlow.EditValue.ObjectNullString(), out _MinSpec))
            {
                _MinSpec = _Minvalue;
            }

            if (!decimal.TryParse(txtTENhigh.EditValue.ObjectNullString(), out _MaxSpec))
            {
                _MaxSpec = _Maxvalue;
            }

            _ResultValue = decimal.Parse(spiTEN.EditValue.ObjectNullString());

            if (_MinSpec <= _ResultValue && _ResultValue <= _MaxSpec)
            {
                lblTEN.Text = "PASS";
                lblTEN.BackColor = Color.LimeGreen;
                lblTEN.ForeColor = Color.Black;
            }
            else
            {
                lblTEN.Text = "NG";
                lblTEN.BackColor = Color.Red;
                lblTEN.ForeColor = Color.White;
            }

        }

        private void spiRESIS_EditValueChanged(object sender, EventArgs e)
        {
            decimal _MinSpec, _MaxSpec, _ResultValue;

            if (!decimal.TryParse(txtRESISlow.EditValue.ObjectNullString(), out _MinSpec))
            {
                _MinSpec = _Minvalue;
            }

            if (!decimal.TryParse(txtRESIShigh.EditValue.ObjectNullString(), out _MaxSpec))
            {
                _MaxSpec = _Maxvalue;
            }

            _ResultValue = decimal.Parse(spiRESIS.EditValue.ObjectNullString());

            if (_MinSpec <= _ResultValue && _ResultValue <= _MaxSpec)
            {
                lblRESIS.Text = "PASS";
                lblRESIS.BackColor = Color.LimeGreen;
                lblRESIS.ForeColor = Color.Black;
            }
            else
            {
                lblRESIS.Text = "NG";
                lblRESIS.BackColor = Color.Red;
                lblRESIS.ForeColor = Color.White;
            }
        }

        private void drgInspItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (drgInspItem.SelectedIndex)
            {
                case 0:
                    spiCCH.Enabled = true;
                    spiCCW.Enabled = false;
                    spiICH.Enabled = false;
                    spiICW.Enabled = false;
                    spiTEN.Enabled = false;
                    spiRESIS.Enabled = false;
                    break;
                case 1:
                    spiCCH.Enabled = false;
                    spiCCW.Enabled = true;
                    spiICH.Enabled = false;
                    spiICW.Enabled = false;
                    spiTEN.Enabled = false;
                    spiRESIS.Enabled = false;
                    break;
                case 2:
                    spiCCH.Enabled = false;
                    spiCCW.Enabled = false;
                    spiICH.Enabled = true;
                    spiICW.Enabled = false;
                    spiTEN.Enabled = false;
                    spiRESIS.Enabled = false;
                    break;
                case 3:
                    spiCCH.Enabled = false;
                    spiCCW.Enabled = false;
                    spiICH.Enabled = false;
                    spiICW.Enabled = true;
                    spiTEN.Enabled = false;
                    spiRESIS.Enabled = false;
                    break;
                case 4:
                    spiCCH.Enabled = false;
                    spiCCW.Enabled = false;
                    spiICH.Enabled = false;
                    spiICW.Enabled = false;
                    spiTEN.Enabled = true;
                    spiRESIS.Enabled = false;
                    break;
                case 5:
                    spiCCH.Enabled = false;
                    spiCCW.Enabled = false;
                    spiICH.Enabled = false;
                    spiICW.Enabled = false;
                    spiTEN.Enabled = false;
                    spiRESIS.Enabled = true;
                    break;
            }
        }

        private void btnFrontFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = "C:\\";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFrontFile.EditValue = ofd.FileName;
            }
        }

        private void btnRearFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = "C:\\";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtRearFile.EditValue = ofd.FileName;
            }
        }

        private void gvList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                iPicFront.Image = null;
                iPicRear.Image = null;

                if (gvList.GetFocusedRowCellValue("FPATH").ObjectNullString() != "")
                    iPicFront.Image = ftp.GetImgByte(gvList.GetFocusedRowCellValue("FPATH").ObjectNullString());

                if (gvList.GetFocusedRowCellValue("RPATH").ObjectNullString() != "")
                    iPicRear.Image = ftp.GetImgByte(gvList.GetFocusedRowCellValue("RPATH").ObjectNullString());
            }
        }

    }
}
