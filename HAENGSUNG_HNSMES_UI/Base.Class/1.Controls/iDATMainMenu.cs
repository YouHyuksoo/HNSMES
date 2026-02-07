using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList;

using IDAT_Common.Utility;
using DevexpressGridUtil = IDAT.Devexpress.GRID;
using HAENGSUNG_HNSMES_UI.WebService.Access;
using System.Threading.Tasks;



namespace HAENGSUNG_HNSMES_UI.Class
{
    class iDATMainMenu
    {
        HAENGSUNG_HNSMES_UI.WebService.Business.IDatabaseProcess _Db = null;

        #region 생성자

        /// <summary>
        /// 생성자 함수
        /// </summary>
        /// <param name="frm">Main Form</param>
        public iDATMainMenu(HAENGSUNG_HNSMES_UI.WebService.Business.IDatabaseProcess clsDb) 
        {
            if (_Db == null)
                _Db = clsDb;
        }

        #endregion

        #region 이벤트 정의

        // TreeList MouseDown Delegate
        public delegate void Menu_MouseDown(object sender, MouseEventArgs e);
        public delegate void FAVMenu_MouseDown(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e);
        public event Menu_MouseDown Menu_SelectEvent;
        public event FAVMenu_MouseDown FAVORITES_SelectEvent;

        #endregion

        //2. 메뉴그룹명으로 동적으로 메인메뉴를 생성하는 기능
        //3. 사용자 바로가기 메뉴를 동적으로 생성하는 기능
        #region 메뉴 만들기

        /// [2]
        /// <summary>
        /// 그룹네임에 해당하는 동적메뉴를 생성합니다.
        /// </summary>
        /// <param name="Group_name">그룹 네임 명</param>
        public void Add_MenuGroup(DevExpress.XtraNavBar.NavBarControl p_navMenu)
        {
            WSResults result = null;
            
            LanguageInformation _clsLan = new LanguageInformation();
            iDATControlBinding _clsBind = new iDATControlBinding(_Db);
            DevExpress.XtraNavBar.NavBarGroup _nbg;
            Dictionary<string, object> param = new Dictionary<string, object>();
            //일단 초기화
            p_navMenu.BeginUpdate();
            p_navMenu.Groups.Clear();
            //
            if (Settings_IDAT.Default.Use_Favorites)
            {
                DevExpress.XtraGrid.GridControl _gc = new DevExpress.XtraGrid.GridControl();
                DevExpress.XtraGrid.Views.Grid.GridView _gv = new DevExpress.XtraGrid.Views.Grid.GridView();
                DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit _pic = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();

                _gc.BeginUpdate();
                _gv.BeginUpdate();
                _gc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { _gv });
                _gc.MainView = _gv;
                _gv.GridControl = _gc;
                _gc.Name = "_gc";
                _gv.Name = "_gv";

                _gc.LookAndFeel.UseDefaultLookAndFeel = true;
                _gc.TabStop = false;
                _gc.Dock = DockStyle.Fill;

                if (_gv != null)
                {
                    //Layout
                    _gv.OptionsLayout.StoreAllOptions = true;
                    _gv.OptionsLayout.StoreAppearance = true;
                    _gv.OptionsLayout.StoreDataSettings = true;
                    _gv.OptionsLayout.StoreVisualOptions = true;
                    _gv.OptionsLayout.Columns.StoreAllOptions = true;
                    _gv.OptionsLayout.Columns.StoreAppearance = true;
                    _gv.OptionsLayout.Columns.StoreLayout = true;
                    // 수정 취소
                    _gv.OptionsBehavior.Editable = false;
                    _gv.OptionsView.ShowGroupPanel = false;
                    /// OptionsView
                    _gv.OptionsView.EnableAppearanceOddRow = false;
                    _gv.OptionsView.EnableAppearanceEvenRow = false;
                    _gv.OptionsView.ShowGroupedColumns = false;
                    _gv.OptionsView.ShowColumnHeaders = false;
                    _gv.OptionsView.ShowAutoFilterRow = false;
                    _gv.OptionsView.ShowIndicator = false;
                    _gv.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Default;
                    _gv.OptionsFilter.AllowFilterEditor = true;
                    _gv.OptionsFilter.UseNewCustomFilterDialog = true;
                    _gv.OptionsSelection.EnableAppearanceFocusedCell = false;
                    _gv.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
                    _gv.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
                    /// OptionBehavior
                    _gv.OptionsBehavior.AutoExpandAllGroups = true;
                    _gv.OptionsView.ShowFooter = false;
                    
                    _gv.RowHeight = 40;
                }
                //==========================================================================
                //즐겨찾기 설정
                //==========================================================================
                param.Clear();
                param.Add("A_CLIENT", Global.Global_Variable.CLIENT);
                param.Add("A_COMPANY", Global.Global_Variable.COMPANY);
                param.Add("A_PLANT", Global.Global_Variable.PLANT);
                param.Add("A_SYSTEM", Global.Global_Variable.SYSTEMCODE);
                param.Add("A_USERID", Global.Global_Variable.USER_ID);
                DataSet _ds = _Db.Get_DataBase("PKGSYS_USER.GET_FAVRT", 1, param);
                DataTable _dtFav = _ds.Tables[0];
                _dtFav.Columns.Add("FORMIMAGE", typeof(System.Drawing.Bitmap));

                Parallel.For(0, _dtFav.Rows.Count, i =>
                {
                    int _intIndex = ConvertUtil.ParseInt(_dtFav.Rows[i]["IMGIDX"] + "");
                    _dtFav.Rows[i]["FORMIMAGE"] = Program.frmM.imagesPage24.Images[_intIndex];
                    _dtFav.Rows[i]["MENUNAME"] = _clsLan.GetMessageString(_dtFav.Rows[i]["MENUNAME"] + "");
                });

                _clsBind.Set_GridColumn(_gv, "FORMIMAGE,MENUNAME", true);
                _gv.Columns["FORMIMAGE"].Width = 25;
                _gv.Columns["FORMIMAGE"].ColumnEdit = _pic;
                _gc.DataSource = _dtFav;
                //
                _gv.MouseMove += new MouseEventHandler(_gv_MouseMove);
                _gv.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(_gv_RowClick);
                // ****즐겨찾기 메뉴를 등록한다.
                _nbg = p_navMenu.Groups.Add();
                _nbg.Caption = "Favorites";
                _nbg.SmallImage = HAENGSUNG_HNSMES_UI.Properties.Resources.favorites;
                _nbg.AppearanceHotTracked.ForeColor = System.Drawing.Color.Fuchsia;
                _nbg.AppearanceHotTracked.Options.UseForeColor = true;
                _nbg.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
                _nbg.ControlContainer.Controls.Add(_gc);
                _nbg.Expanded = true;
                //즐겨찾기 항목 없으면 안보이기
                if (_dtFav.Rows.Count <= 0) _nbg.Visible = false;

                _gv.EndUpdate();
                _gc.EndUpdate();
            }
            p_navMenu.EndUpdate();
            // 최상위의 메뉴이름을 가져옵니다.===============================
            string Procname = "PKGSYS_MENU.GET_MENU";

            param.Clear();
            param.Add("A_CLIENT", Global.Global_Variable.CLIENT);
            param.Add("A_COMPANY", Global.Global_Variable.COMPANY);
            param.Add("A_PLANT", Global.Global_Variable.PLANT);
            param.Add("A_SYSTEM", Global.Global_Variable.SYSTEMCODE);
            param.Add("A_USERROLE", Global.Global_Variable.USERROLE);
            param.Add("A_PARENT_NO", 1);
            string _Lang = "";

            if (Settings_IDAT.Default.Language.ToUpper() == "LOCAL")
            {
                switch (Application.CurrentCulture.Name.ToUpper())
                {
                    case "KO-KR":
                        _Lang = "KOREAN";
                        break;
                    case "EN-US":
                        _Lang = "ENGLISH";
                        break;
                    default :
                        _Lang = "NATIVE";
                        break;
                }
            }
            else
            {
                _Lang = Settings_IDAT.Default.Language.ToUpper();
            }
            param.Add("A_LANG", _Lang);

            result = _Db.Execute_Proc(Procname, 2, param);

            DataSet dsMenu = null;

            if (result.ResultInt != 0)
            {
                iDATMessageBox.ShowProcResultMessage(result, "Menu Error", Global.Global_Variable.USER_ID, Procname, param);
                return;
            }
            else
            {
                dsMenu = result.ResultDataSet;
            }

            //==========================================================================
            //메뉴 구성 - Level1 예. 시스템 관리 / 기준정보 관리 / 자재관리 등
            //==========================================================================
            System.Windows.Forms.ImageList _imgLst = new ImageList();
            _imgLst.Images.Add(HAENGSUNG_HNSMES_UI.Properties.Resources.button_remove);
            _imgLst.Images.Add(HAENGSUNG_HNSMES_UI.Properties.Resources.go);
            p_navMenu.BeginUpdate();
            foreach (DataRow dr in dsMenu.Tables[0].Rows)
            {
                _nbg = p_navMenu.Groups.Add();
                _nbg.Name = dr["MENUNAME"] + "";
                _nbg.Caption = _clsLan.GetMessageString(dr["MENUNAME"] + "");
                _nbg.SmallImage = Program.frmM.imagesPage32.Images[(Int16)IDAT_Common.Utility.ConvertUtil.ParseInt(dr["IMGIDX"].ObjectNullString())];
                _nbg.AppearanceHotTracked.ForeColor = System.Drawing.Color.Fuchsia;
                _nbg.AppearanceHotTracked.Options.UseForeColor = true;
                _nbg.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            }
            p_navMenu.EndUpdate();

            //==========================================================================
            //메뉴 구성 - Level2 예. 시스템 관리 → 마스터 메뉴 등
            //==========================================================================
            foreach (DataRow row in dsMenu.Tables[0].Rows)
            {

                param.Clear();
                param.Add("A_CLIENT", Global.Global_Variable.CLIENT);
                param.Add("A_COMPANY", Global.Global_Variable.COMPANY);
                param.Add("A_PLANT", Global.Global_Variable.PLANT);
                param.Add("A_SYSTEM", Global.Global_Variable.SYSTEMCODE);
                param.Add("A_USERROLE", Global.Global_Variable.USERROLE);
                param.Add("A_PARENT_NO", row["MENUSEQ"].ToString());
                param.Add("A_LANG", _Lang);

                result = _Db.Execute_Proc(Procname, 2, param);

                DataTable dtChild = result.ResultDataSet.Tables[0];

                // 메뉴 동적 생성
                // 순서 중요함 Tree 생성 => Navbar Add => DataBinding
                TreeList TL_Menu = new TreeList();
                TL_Menu.BeginUpdate();
                //lock (TL_Menu)
                {
                    p_navMenu.Groups[row["MENUNAME"] + ""].ControlContainer.Controls.Add(TL_Menu);

                    TL_Menu.Dock = DockStyle.Fill;

                    TL_Menu.OptionsBehavior.Editable = false;
                    TL_Menu.OptionsView.ShowColumns = false;
                    TL_Menu.ParentFieldName = "UPRSEQ";
                    TL_Menu.KeyFieldName = "MENUSEQ";

                    //========링크메뉴는 이미지 보이기 by 허지량
                    //이미지 리스트 적용
                    TL_Menu.SelectImageList = _imgLst;
                    //이미지 인덱스 설정
                    TL_Menu.ImageIndexFieldName = "MENUIMG";
                    //트리의 모양 및 속성정의
                    TL_Menu.OptionsView.ShowHorzLines = false;
                    TL_Menu.OptionsView.ShowVertLines = false;
                    TL_Menu.OptionsSelection.EnableAppearanceFocusedCell = false;
                    TL_Menu.OptionsView.ShowIndicator = false;
                    TL_Menu.RowHeight = 25;
                    //마우스 무브 이벤트
                    TL_Menu.MouseMove += new MouseEventHandler(TL_Menu_MouseMove);
                    //===========================================

                    TL_Menu.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowForFocusedRow;

                    TL_Menu.DataSource = dtChild;
                    TL_Menu.PopulateColumns();
                    TL_Menu.ExpandAll();
                    if (TL_Menu.Columns["SUB_NO"] != null)
                        TL_Menu.Columns["SUB_NO"].Visible = false;
                    TL_Menu.Columns["FORM"].Visible = false;
                    TL_Menu.Columns["PERENT_MENU"].Visible = false;
                    TL_Menu.Columns["FORM"].Visible = false;
                    TL_Menu.Columns["FORMPARAM"].Visible = false;
                    TL_Menu.Columns["IMGIDX"].Visible = false;
                    TL_Menu.Columns["DISPFLAG"].Visible = false;
                    TL_Menu.Columns["USEFLAG"].Visible = false;
                    TL_Menu.Columns["FORMROLE"].Visible = false;
                    TL_Menu.Columns["MENUNAME"].Visible = true;

                    TL_Menu.BestFitColumns();

                    TL_Menu.Cursor = Cursors.Hand;

                    TL_Menu.MouseDown += new MouseEventHandler(TL_Menu_MouseDown);

                    // 자식 메뉴가 존재하지 않으면 그룹메뉴를 숨긴다.
                    if (TL_Menu.Nodes.Count > 0)
                        p_navMenu.Groups[row["MENUNAME"] + ""].Visible = true;
                    else
                        p_navMenu.Groups[row["MENUNAME"] + ""].Visible = false;
                }
                TL_Menu.EndUpdate();
            }
        }

        void _gv_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (FAVORITES_SelectEvent != null)
            {
                FAVORITES_SelectEvent(sender, e);
            }
        }

        void _gv_MouseMove(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView _gv = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            //================================
            //마우스 가는곳에 포커스 가도록
            //================================
            if (e.Y > _gv.GridControl.Height - 30) return; //마지막 라인은 포커스 안감
            if (e.X < 40) return;
            //
            DevexpressGridUtil.IDATDevExpress_GridControl _clsGrid = new DevexpressGridUtil.IDATDevExpress_GridControl();
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo gridHitINFO = _clsGrid.GetClickHitInfo(_gv, e);

            _gv.FocusedRowHandle = gridHitINFO.RowHandle;
        }
        
        #endregion

        //1. 레프트메뉴 마우스 다운 이벤트
        #region 메뉴 동작 이벤트

        /// <summary>
        /// 메인메뉴 MouseDown 이벤트
        /// </summary>
        /// <remarks>
        /// 메인메뉴를 선택하면 폼을 호출한다.
        /// </remarks>
        public void TL_Menu_MouseDown(object sender, MouseEventArgs e)
        {
            Menu_SelectEvent(sender, e);

        }

        public void TL_Menu_MouseMove(object sender, MouseEventArgs e)
        {
            DevExpress.XtraTreeList.TreeList ObjTL = sender as DevExpress.XtraTreeList.TreeList;
            //
            //================================
            //마우스 가는곳에 포커스 가도록
            //================================
            if (e.Y > ObjTL.Height - 30) return; //마지막 라인은 포커스 안감
            if (e.X < 40) return;
            //
            DevExpress.XtraTreeList.TreeListHitInfo hi = ObjTL.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            ObjTL.SetFocusedNode(hi.Node);
        }

        #endregion
    }
}
