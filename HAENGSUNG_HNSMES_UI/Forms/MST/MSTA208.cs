using System;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;

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

namespace HAENGSUNG_HNSMES_UI.Forms.MST
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : MSTA208<br/>
    ///      기능 : 불량 마스터 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    public partial class MSTA208 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
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

        public MSTA208()
        {
            InitializeComponent();
        }

        private void MSTA208_Load(object sender, EventArgs e)
        {
            this.Set_Init();
            InitButton_Click();
        }

        private void MSTA208_Shown(object sender, EventArgs e)
        {
            //MainButton_INIT.PerformClick();
        }

        #endregion 

        #region 버튼이벤트

        public void InitButton_Click()
        {
            // 초기화 관련 구현은 여기에 구현 ***
            // 상세 항목들을 모두 클리어 한다.
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);
            this.GetGridViewList();
        }
        
        public void NewButton_Click()
        {
            base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New);

            // 그리드뷰에 새로운 행과 초기값을 지정한다.
            gvList.EX_AddNewRow(new string[] { "USEFLAG" }, new string[] { "Y" });

            txtDefectName.Focus();
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
            InitButton_Click();
        }

        public void SaveButton_Click()
        {
            // 저장전에 필수 항목에 대한 Null 값을 초기화 합니다.
            // 유효성검사 다시 수행
            base.baseDxErrorProvider.ClearErrors();
            ValidateChildren(ValidationConstraints.Visible);

            // 유효성 검사를 한다.
            if (base.baseDxErrorProvider.HasErrors)
            {
                return;
            }

            // ****** 마지막 수정항목을 데이터셋에 적용 시킬려면 포커스를 이동을 한다.
            gvList.FocusedRowHandle = -1;

            string _strDefect = "";
            string _strDefectName = "";
            string _strDefectType = "";
           
            string _strUseFlag = "";
            string _strRemarks = "";

            if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit)
            {
                // ****** 마지막 수정항목을 데이터셋에 적용 시킬려면 포커스를 이동을 한다.
                gvList.FocusedRowHandle = -1;

                // 수정,추가,변경 된 데이터를 모두 가져온다.
                DataTable _dt = gvList.EX_GetChangedData();

                if (_dt == null)
                    return;

                // 변경된 데이터가 없으면 return.
                if (_dt.Rows.Count == 0) return;

                // 변경된 데이터를 루프를 통해 하나씩 빼낸다.
                foreach (DataRow _dr in _dt.Rows)
                {
                    switch (_dr.RowState)
                    {
                        case DataRowState.Modified:
                            _strDefect = _dr["DEFECT"].ObjectNullString();
                            _strDefectName = _dr["DEFECTNAME"].ObjectNullString();
                            _strDefectType = _dr["DEFECTTYPE"].ObjectNullString();
                           
                            _strUseFlag = _dr["USEFLAG"].ObjectNullString();
                            _strRemarks = _dr["REMARKS"].ObjectNullString();

                            if (!this.SaveData(_strDefect, _strDefectName, _strDefectType, _strUseFlag, _strRemarks, "N"))
                            {
                                this.MainButton_INIT.PerformClick();
                                //마지막 처리 된 값쪽에 포커스를 이동 시킵니다. 사용시에 주석을 해제하고 수정하세요.
                                gvList.EX_GetFocuseRowCell("DEFECT", _strDefect);
                                return;
                            }

                            break;

                        default:
                            break;
                    }
                }

                this.MainButton_INIT.PerformClick();
                //마지막 처리 된 값쪽에 포커스를 이동 시킵니다. 사용시에 주석을 해제하고 수정하세요.
                gvList.EX_GetFocuseRowCell("DEFECT", _strDefect);
            }
            else if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
            {
                // ***** 신규 관련 프로시져를 여기에 구현을 합니다.
                _strDefect = txtDefect.Text.Trim().ObjectNullString();
                _strDefectName = txtDefectName.Text.Trim().ObjectNullString();
                _strDefectType = gleDefType.EditValue.ObjectNullString();
               

                _strUseFlag = rdoGrUse.EditValue.ObjectNullString();
                _strRemarks = memRemarks.Text.Trim().ObjectNullString();

                if (!this.SaveData(_strDefect, _strDefectName, _strDefectType, _strUseFlag, _strRemarks, "Y"))
                {
                    MainButton_INIT.PerformClick();
                    return;
                }


                MainButton_INIT.PerformClick();
                MainButton_New.PerformClick();
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
            BASE_DXGridLookUpHelper.Bind_GridLookUpEdit( gleDefType
                                                       , "GPKGBAS_BASE.GET_DEF_TYPE"
                                                       , 1
                                                       , new string[] {
                                                         "A_CLIENT"
                                                       , "A_COMPANY"
                                                       , "A_PLANT" }
                                                       , new string[] {
                                                         Global.Global_Variable.CLIENT
                                                       , Global.Global_Variable.COMPANY
                                                       , Global.Global_Variable.PLANT}
                                                       , "NVALUE"
                                                       , "COMMNAME"
                                                       , "COMMNAME,NVALUE,REMARKS"
                                                       );

            
        }

        private void GetGridViewList()
        {
            BASE_DXGridHelper.Bind_Grid( gcList
                                       , "PKGBAS_BASE.GET_DEFECT"
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
                                       , "1" }
                                       , true
                                       );

            gvList.OptionsView.ColumnAutoWidth = false;
            gvList.BestFitColumns();

        }

        private bool SaveData(string p_strDefect, string p_strDefectName, string p_strDefectType, string p_strUseFlag, string p_strRemarks, 
                              string p_strNewflag)
        {
            bool _blReturn = BASE_db.Execute_Proc( "PKGBAS_BASE.PUT_DEFECT"
                                                 , 1
                                                 , new string[] {  
                                                   "A_CLIENT"
                                                 , "A_COMPANY"
                                                 , "A_PLANT"
                                                 , "A_DEFECT"
                                                 , "A_DEFECTNAME"
                                                 , "A_DEFECTTYPE" 
                                                 , "A_USEFLAG"
                                                 , "A_REMARKS"
                                                 , "A_USERID"
                                                 , "A_NEWFLAG" }
                                                 , new string[] {  
                                                   Global.Global_Variable.CLIENT
                                                 , Global.Global_Variable.COMPANY
                                                 , Global.Global_Variable.PLANT
                                                 , p_strDefect
                                                 , p_strDefectName
                                                 , p_strDefectType
                                                 , p_strUseFlag
                                                 , p_strRemarks
                                                 , Global.Global_Variable.EHRCODE
                                                 , p_strNewflag }
                                                 , true
                                                 );

            return _blReturn;                               
        }

        #endregion

        #region 일반 이벤트
        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDlg = new OpenFileDialog();
            fileDlg.RestoreDirectory = true;
            fileDlg.Filter = "Image File (*.jpg;*.bmp;*.gif,*.png)|*.jpg;*.bmp;*.gif;*.png";


            fileDlg.RestoreDirectory = true;

            if (fileDlg.ShowDialog() == DialogResult.OK)
            {
                string _strImageName = fileDlg.FileName;

                FileStream fs = new System.IO.FileStream(_strImageName, FileMode.Open, FileAccess.Read);

                byte[] b = new byte[fs.Length - 1];
                fs.Read(b, 0, b.Length);
                fs.Close();

                Dictionary<string, object> dicParams = new Dictionary<string, object>();
                dicParams.Add("A_CLIENT", Global.Global_Variable.CLIENT);
                dicParams.Add("A_COMPANY", Global.Global_Variable.COMPANY);
                dicParams.Add("A_PLANT", Global.Global_Variable.PLANT);
                dicParams.Add("A_DEFECT", txtDefect.EditValue.ObjectNullString());
                dicParams.Add("A_IMAGE", b);
                dicParams.Add("A_USERID", Global.Global_Variable.USER_ID);

                HAENGSUNG_HNSMES_UI.WebService.Access.WSResults _Result = BASE_db.Execute_Proc("PKGBAS_BASE.SET_DEFECTIMAGE"
                                                                                              , 1
                                                                                              , dicParams);

                if (_Result.ResultInt == 0)
                {
                    iDATMessageBox.OKMessage("DBMSG_SUCCESS", this.Text, 3);
                    this.GetGridViewList();
                }
            }
        }




        #endregion

        
        
    }
}
