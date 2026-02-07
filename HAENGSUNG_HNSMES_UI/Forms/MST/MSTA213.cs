using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using HAENGSUNG_HNSMES_UI.Class;
using GridAlias = DevExpress.XtraGrid.Views.Grid;

using NGS.WCFClient.DatabaseService;
using DevExpress.XtraGrid.Views.Grid;

namespace HAENGSUNG_HNSMES_UI.Forms.MST
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : MSTA213<br/>
    ///      기능 : 압착 검사 이미지 마스터 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    public partial class MSTA213 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {
        // ******************************************* Base From Class ************************************
        // BASE_clsDevexpressGridUtil          DevExpress Grid 관련 Util Class.
        // BASE_db;                            웹서비스 DB처리 관련 Util Class.
        // BASE_DXGridHelper;                  DevExpress GridControl 데이터 Bind관련 Class
        // BASE_DXGridLookUpHelper;            DevExpress GridLookUp 데이터 Bind관련 Class
        // BASE_IDATLayoutUtil;                DevExpress LayoutControl Util Class.
        // BASE_Language;                      Language Util. ex) BASE_Language.GetMessageString("Code") 
        // ************************************************************************************************
        #region 생성

        public MSTA213()
        {
            InitializeComponent();
        }

        private void MSTA213_Load(object sender, EventArgs e)
        {
        }

        private void MSTA213_Shown(object sender, EventArgs e)
        {
            MainButton_INIT.PerformClick();
        }
        #endregion 

        #region 버튼이벤트

        public void InitButton_Click()
        {
            // 초기화 관련 구현은 여기에 구현 ***
            // 상세 항목들을 모두 클리어 한다.
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);
            this.Set_Init();
            this.GetGridViewList();
        }
        
        
        public void NewButton_Click()
        {
            // 신규 관련 구현은 여기에 구현.

            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New);

            // 그리드뷰에 새로운 행과 초기값을 지정한다.
            gvList.EX_AddNewRow();
            rdgUseFlag.SelectedIndex = 0;

            txtWire.Focus();
        }

        public void EditButton_Click()
        {
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit);
        }

        public void StopButton_Click()
        {
        }

        public void SearchButton_Click()
        {
        }

        public void SaveButton_Click()
        {
            // 저장전에 필수 항목에 대한 Null 값을 초기화 합니다.
            // 유효성검사 다시 수행
            base.baseDxErrorProvider.ClearErrors();
            ValidateChildren(ValidationConstraints.Visible);

            //// 유효성 검사를 한다.
            //if (base.baseDxErrorProvider.HasErrors)
            //{
            //    return;
            //}

            // ****** 마지막 수정항목을 데이터셋에 적용 시킬려면 포커스를 이동을 한다.
            //gvList.FocusedRowHandle = -1;

            string _strWire = "";
            string _strTerminal = "";
            string _strCCHlow = "";
            string _strCCHhigh = "";
            string _strCCWlow = "";
            string _strCCWhigh = "";
            string _strICHlow = "";
            string _strICHhigh = "";
            string _strICWlow = "";
            string _strICWhigh = "";
            string _strTENlow = "";
            string _strTENhigh = "";
            string _strRESISlow = "";
            string _strRESIShigh = "";
            string _struseflag = "";
            string _strremarks = "";

            if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit || base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
            {
                // ***** 신규 관련 프로시져를 여기에 구현을 합니다.
                _strWire = txtWire.EditValue.ObjectNullString().Trim();
                _strTerminal = txtTerminal.EditValue.ObjectNullString().Trim();

                _strCCHlow = spiCCHlow.EditValue.ObjectNullString();
                _strCCHhigh = spiCCHhigh.EditValue.ObjectNullString();

                _strCCWlow = spiCCWlow.EditValue.ObjectNullString();
                _strCCWhigh = spiCCWhigh.EditValue.ObjectNullString();

                _strICHlow = spiICHlow.EditValue.ObjectNullString();
                _strICHhigh = spiICHhigh.EditValue.ObjectNullString();

                _strICWlow = spiICWlow.EditValue.ObjectNullString();
                _strICWhigh = spiICWhigh.EditValue.ObjectNullString();

                _strTENlow = spiTENlow.EditValue.ObjectNullString();
                _strTENhigh = spiTENhigh.EditValue.ObjectNullString();

                _strRESISlow = spiRESISlow.EditValue.ObjectNullString();
                _strRESIShigh = spiRESIShigh.EditValue.ObjectNullString();

                _struseflag = rdgUseFlag.EditValue.ObjectNullString();
                _strremarks = memRemarks.EditValue.ObjectNullString();

                if (!this.SaveData( _strWire, _strTerminal, _strCCHlow, _strCCHhigh
                                  , _strCCWlow, _strCCWhigh, _strICHlow, _strICHhigh
                                  , _strICWlow, _strICWhigh, _strTENlow, _strTENhigh
                                  , _strRESISlow, _strRESIShigh, _struseflag, _strremarks))
                {
                    MainButton_INIT.PerformClick();
                    return;
                }

                MainButton_INIT.PerformClick();
                

            }
            

        }

        public void RefreshButton_Click()
        {
        }

        public void DeleteButton_Click()
        {
        }

        public void PrintButton_Click()
        {
        }

        #endregion

        #region 함수

        private void Set_Init()
        {
            

           
        }

        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid( gcList
                                       , "PKGBAS_BASE.GET_ITEMIMAGE"
                                       , 1
                                       , new string[] { 
                                         "A_CLIENT"
                                       , "A_COMPANY"
                                       , "A_PLANT" }
                                       , new string[] { 
                                         Global.Global_Variable.CLIENT
                                       , Global.Global_Variable.COMPANY
                                       , Global.Global_Variable.PLANT }
                                       , true
                                       , "WIRE, TERMINAL, USERID"
                                       );

            gvList.BestFitColumns();

        }

        public byte[] imageToByteArray(IDAT.Devexpress.DXControl.IdatDxPictureEdit pic)
        {
            MemoryStream ms = new MemoryStream();
            try
            {
                Bitmap img = (Bitmap)pic.Image;

                if (img == null)
                    img = (Bitmap)Properties.Resources.button_close;

                Bitmap NewImg = new Bitmap(img);

                img.Dispose();

                img = null;

                NewImg.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

            }
            catch (Exception)
            {
                return null;
            }
            return ms.ToArray();
        }

        private bool SaveData( string p_wire, string p_Terminal, string p_CCHlow, string p_CCHhigh
                             , string p_CCWlow, string p_CCWhigh, string p_ICHlow, string p_ICHhigh
                             , string p_ICWlow, string p_ICWhigh, string p_TENlow, string p_TENhigh
                             , string p_RESISlow, string p_RESIShigh, string p_useflag, string p_remarks)
        {
            
            byte[] bWire = imageToByteArray(picWire);

            byte[] bTerminal = imageToByteArray(picTerminal);

            if (bWire.Length == 0 || bTerminal.Length == 0)
                return false;
            

            Dictionary<string, object> dicParams = new Dictionary<string, object>();
            dicParams.Add("A_CLIENT", Global.Global_Variable.CLIENT);
            dicParams.Add("A_COMPANY", Global.Global_Variable.COMPANY);
            dicParams.Add("A_PLANT", Global.Global_Variable.PLANT);
            dicParams.Add("A_WIRE", p_wire);
            dicParams.Add("A_TERMINAL", p_Terminal);
            dicParams.Add("A_CCHLOW", p_CCHlow);
            dicParams.Add("A_CCHHIGH", p_CCHhigh);
            dicParams.Add("A_CCWLOW", p_CCWlow);
            dicParams.Add("A_CCWHIGH", p_CCWhigh);
            dicParams.Add("A_ICHLOW", p_ICHlow);
            dicParams.Add("A_ICHHIGH", p_ICHhigh);
            dicParams.Add("A_ICWLOW", p_ICWlow);
            dicParams.Add("A_ICWHIGH", p_ICWhigh);
            dicParams.Add("A_TENLOW", p_TENlow);
            dicParams.Add("A_TENHIGH", p_TENhigh);
            dicParams.Add("A_RESISLOW", p_RESISlow);
            dicParams.Add("A_RESISHIGH", p_RESIShigh);
            dicParams.Add("A_IMGWIRE", bWire);
            dicParams.Add("A_IMGTERMINAL", bTerminal);
            dicParams.Add("A_USEFLAG", p_useflag);
            dicParams.Add("A_REMARKS", p_remarks);
            dicParams.Add("A_USERID", Global.Global_Variable.USER_ID);

            HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = BASE_db.Execute_Proc("PKGBAS_BASE.SET_ITEMIMAGE"
                                                                                          , 1
                                                                                          , dicParams);

            if (_Result.ResultInt == 0)
            {
                iDATMessageBox.OKMessage("DBMSG_SUCCESS", this.Text, 3);
                this.GetGridViewList();
            }

            return true;

        }

        #endregion

        #region 일반 이벤트

       
       

        #endregion       

        private void btnWimage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDlg = new OpenFileDialog();
            fileDlg.RestoreDirectory = true;
            fileDlg.Filter = "Image File (*.jpg;*.bmp;*.gif,*.png)|*.jpg;*.bmp;*.gif;*.png";


            fileDlg.RestoreDirectory = true;

            if (fileDlg.ShowDialog() == DialogResult.OK)
            {
                string _strImageName = fileDlg.FileName;

                FileStream fs = new System.IO.FileStream(_strImageName, FileMode.Open, FileAccess.Read);

                Image imgFromBlob = Image.FromStream(fs);
                picWire.Image = imgFromBlob;
                picWire.Tag = _strImageName;

                fs.Close();
            }
        }

        private void btnTimage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDlg = new OpenFileDialog();
            fileDlg.RestoreDirectory = true;
            fileDlg.Filter = "Image File (*.jpg;*.bmp;*.gif,*.png)|*.jpg;*.bmp;*.gif;*.png";


            fileDlg.RestoreDirectory = true;

            if (fileDlg.ShowDialog() == DialogResult.OK)
            {
                string _strImageName = fileDlg.FileName;

                FileStream fs = new System.IO.FileStream(_strImageName, FileMode.Open, FileAccess.Read);

                Image imgFromBlob = Image.FromStream(fs);
                picTerminal.Image = imgFromBlob;
                picTerminal.Tag = _strImageName;

                fs.Close();
            }
        }

    }
}
