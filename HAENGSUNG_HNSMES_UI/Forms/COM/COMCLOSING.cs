using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HAENGSUNG_HNSMES_UI.Class;
using GridAlias = DevExpress.XtraGrid.Views.Grid;

using NGS.WCFClient.DatabaseService;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

using DevExpress.XtraSplashScreen;

namespace HAENGSUNG_HNSMES_UI.Forms.COM
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : COMCLOSING<br/>
    ///      기능 : 마감 정보 <br/>
    ///      작성 : 아이디정보시스템<br/>
    ///최초작성일 : 2012-07-18<br/>
    ///  수정사항 : <br/>
    ///==========================================================
    ///</summary>
    ///

    public partial class COMCLOSING : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {

        #region 생성

        public COMCLOSING()
        {
            InitializeComponent();
        }

        private void COMCLOSING_Load(object sender, EventArgs e)
        {
            Set_Init();
        }

        private void COMCLOSING_Shown(object sender, EventArgs e)
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
            //base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New);

            //// 그리드뷰에 새로운 행과 초기값을 지정한다.
            //gvList.EX_AddNewRow();
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

            // 유효성 검사를 한다.
            if (base.baseDxErrorProvider.HasErrors)
            {
                return;
            }

            string _strItemCode = "";
            string _strRankNo = "";
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
                            _strItemCode = _dr["ITEMCODE"] + "";
                            _strRankNo = _dr["RANKNO"] + "";
                            _strUseFlag = _dr["USEFLAG"] + "";
                            _strRemarks = _dr["REMARKS"] + "";

                            //if (!this.SaveData(_strItemCode, _strRankNo, _strUseFlag, _strRemarks, "N"))
                            //    return;

                            break;

                        default:
                            break;
                    }
                }

                MainButton_INIT.PerformClick();

            }
            else if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
            {
                // ***** 신규 관련 프로시져를 여기에 구현을 합니다.
                //_strItemCode = gleItemCode.EditValue.ObjectNullString();
                //_strRankNo = gleRankNo.EditValue.ObjectNullString();
                //_strUseFlag = rdgUseFlag.EditValue + "";
                //_strRemarks = memRemarks.Text.Trim() + "";

                //if (!this.SaveData(_strItemCode, _strRankNo, _strUseFlag, _strRemarks, "Y"))
                //    return;


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
            dteYear.DateTime = DateTime.Now;

            GetGridViewList();
        }
        private void GetGridViewList()
        {
            SplashScreenManager.ShowForm(this, typeof(COMWAITFORM), true, true, false);
            SplashScreenManager.Default.SendCommand(COMWAITFORM.WaitFormCommand.SetCaption, BASE_Language.GetMessageString("Data Loading..."));
            SplashScreenManager.Default.SendCommand(COMWAITFORM.WaitFormCommand.SetDescription, BASE_Language.GetMessageString("LOADING"));

            gvList.OptionsView.EnableAppearanceEvenRow = false;
            gvList.OptionsView.EnableAppearanceOddRow = false;
            gvList.FormatConditions.Clear();

            DataTable dt = new DataTable();
            dt.Columns.Add("MONTH", Type.GetType("System.String"));
            for (int i = 1; i < 32; i++)
            {
                StyleFormatCondition cnd = new StyleFormatCondition();
                cnd.ApplyToRow = false;
                cnd.Appearance.ForeColor = Color.Red;
                cnd.Column = gvList.Columns["DAY_" + i.ToString("00")];
                cnd.Condition = FormatConditionEnum.Equal;
                cnd.Value1 = "Y";

                gvList.FormatConditions.Add(cnd);

                StyleFormatCondition cnd1 = new StyleFormatCondition();
                cnd1.ApplyToRow = false;
                cnd1.Appearance.ForeColor = Color.Blue;
                cnd1.Column = gvList.Columns["DAY_" + i.ToString("00")];
                cnd1.Condition = FormatConditionEnum.Equal;
                cnd1.Value1 = "N";

                gvList.FormatConditions.Add(cnd1);

                StyleFormatCondition cnd2 = new StyleFormatCondition();
                cnd2.ApplyToRow = false;
                cnd2.Appearance.BackColor = Color.Gray;
                cnd2.Column = gvList.Columns["DAY_" + i.ToString("00")];
                cnd2.Condition = FormatConditionEnum.Equal;
                cnd2.Value1 = "";

                gvList.FormatConditions.Add(cnd2);

                dt.Columns.Add("DAY_" + i.ToString("00"), Type.GetType("System.String"));
            }

            dt.AcceptChanges();

            dt.BeginLoadData();
            for (int i = 1; i < 13; i++)
            {
                DataSet ds = BASE_db.Get_DataBase(
                                                                  "PKGSYS_COMM.GET_CLOSING"
                                                                , 1
                                                                , new string[] {
                                                                                 "A_CLIENT",
                                                                                 "A_COMPANY",
                                                                                 "A_PLANT",
                                                                                 "A_MONTH",
                                                                                 "A_CLOSINGTYPE"
                                                                               }
                                                                , new string[] {
                                                                                Global.Global_Variable.CLIENT,
                                                                                Global.Global_Variable.COMPANY,
                                                                                Global.Global_Variable.PLANT,
                                                                                dteYear.DateTime.ToString("yyyy") + i.ToString("00"),
                                                                                this.Tag + ""
                                                                               }
                                                               );

                if (ds.Tables[0].Rows.Count == 1)
                {
                    DataRow dr1 = ds.Tables[0].Rows[0];

                    DataRow dr = dt.NewRow();
                    dr["MONTH"] = dr1["MONTH"];
                    for (int j = 1; j < 32; j++)
                    {
                        dr["DAY_" + j.ToString("00")] = dr1["DAY_" + j.ToString("00")];
                    }
                    dt.Rows.Add(dr);
                }
            }
            dt.EndLoadData();

            gcList.BeginUpdate();
            gcList.DataSource = dt;
            gcList.EndUpdate();

            gvList.BeginUpdate();
            gvList.Columns["MONTH"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvList.Columns["MONTH"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            for (int i = 1; i < 32; i++)
            {
                

                gvList.Columns["DAY_" + i.ToString("00")].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gvList.Columns["DAY_" + i.ToString("00")].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            gvList.BestFitColumns();
            gvList.EndUpdate();

            SplashScreenManager.CloseForm(true);
        }

        private bool SaveData(string p_strDate, string p_strClosingType)
        {

            bool _blReturn = BASE_db.Execute_Proc(
                                                    "PKGSYS_COMM.PUT_CLOSING"
                                                  , 1
                                                  , new string[] {
                                                                   "A_CLIENT"
                                                                 , "A_COMPANY"
                                                                 , "A_PLANT"
                                                                 , "A_DATE"
                                                                 , "A_CLOSINGTYPE"
                                                                 , "A_USER"
                                                                }
                                                  , new string[] {
                                                                   Global.Global_Variable.CLIENT
                                                                 , Global.Global_Variable.COMPANY
                                                                 , Global.Global_Variable.PLANT
                                                                 , p_strDate
                                                                 , p_strClosingType
                                                                 , Global.Global_Variable.EHRCODE
                                                                }
                                                  , true);

            return _blReturn;
        }

        #endregion

        #region 일반 이벤트


        private void gvList_Click(object sender, EventArgs e)
        {
            if (!(sender is GridAlias.GridView))
            {
                return;
            }

            //IDAT.Controls.IDATDevExpress _clsGrid = new IDAT.Controls.IDATDevExpress();

            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo gridHitINFO = BASE_clsDevexpressGridUtil.GetClickHitInfo(gvList, e);

            if (gridHitINFO.InRow && gridHitINFO.InColumn)
            {
                /// ============================================================
                /// 선택된 Row의 정보를 가져올려면 아래에 구현을 하면 된다.
            }

            if (gridHitINFO.InRowCell)
            {
            }

            if (gridHitINFO.InColumn)
            {
            }

            if (gridHitINFO.InGroupColumn)
            {
            }

            if (gridHitINFO.InColumnPanel)
            {
            }

            if (gridHitINFO.InFilterPanel)
            {
            }

            if (gridHitINFO.InGroupColumn)
            {
            }
        }

        private void gvList_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            // 신규 상태일때 다른 컬럼을 선택시에 기능을 상실하도록 한다.
            // 구현상 기능이 필요하지 않으면 주석처리 하세요.
            if (base.CurrentDataTYPE == IDAT.Devexpress.FORM.UPDATEITEMTYPE.New)
            {
                if (e.RowHandle == -2147483647)
                {
                    e.Allow = false;
                }
            }
        }

        private void gvList_RowStyle(object sender, RowStyleEventArgs e)
        {
            // 수정된 항목을 그리드에 표시하는 기능을 하지 않을려면 주석 처리를 하세요.
            DataTable changes = BASE_clsDevexpressGridUtil.GetChangedData(gcList, DataRowState.Modified);

            if (changes == null)
                return;

            if (e.RowHandle < 0)
                return;

            // 수정된 키값 필드를 입력한다.
            foreach (DataRow dr in changes.Rows)
            {
                if (dr["ITEMCODE"] != null)
                {
                    // 주키가 두개일 경우 AND 문으로 조건을 다중으로 준다.
                    if (dr["ITEMCODE"].ToString() == gvList.GetDataRow(e.RowHandle)["ITEMCODE"].ToString())
                    {
                        if (dr["RANKNO"].ToString() == gvList.GetDataRow(e.RowHandle)["RANKNO"].ToString())
                        {
                            e.Appearance.ForeColor = Color.Red;
                        }
                    }
                }
            }
        }

        #endregion

        private void gvList_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //if (e.Column.FieldName.IndexOf("DAY_") > -1)
            //{
            //    switch (e.CellValue + "")
            //    {
            //        case "Y":
            //            e.Column.AppearanceCell.BackColor = Color.Empty;
            //            e.Column.AppearanceCell.ForeColor = Color.Red;
            //            break;
            //        case "N":
            //            e.Column.AppearanceCell.BackColor = Color.Empty;
            //            e.Column.AppearanceCell.ForeColor = Color.Blue;
            //            break;
            //        default:
            //            e.Column.AppearanceCell.BackColor = Color.Gray;
            //            break;
            //    }
            //}
            //else
            //{
            //    e.Column.AppearanceCell.BackColor = Color.Empty;
            //}
        }

        private void gvList_DoubleClick(object sender, EventArgs e)
        {
            if (gvList.GetRowCellValue(gvList.FocusedRowHandle, "") + "" != "" && gvList.GetRowCellValue(gvList.FocusedRowHandle, "") + "" != "Y")
            {
                if (iDATMessageBox.QuestionMessage(BASE_Language.GetMessageString("CLOSINGQUESTION"), this.Text) == System.Windows.Forms.DialogResult.Yes)
                {
                }
            }
        }


    }
}
