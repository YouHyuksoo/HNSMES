using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Threading.Tasks;

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList;

using IDAT_Common.Utility;
using DevexpressGridUtil = IDAT.Devexpress.GRID;
using HAENGSUNG_HNSMES_UI.WebService.Access;
using System.Drawing;



namespace HAENGSUNG_HNSMES_UI.Class
{
    class iDATMainMenuTile
    {
        HAENGSUNG_HNSMES_UI.WebService.Business.IDatabaseProcess _Db = null;

        Color[] aryTileColors = new Color[30];

        #region 생성자

        /// <summary>
        /// 생성자 함수
        /// </summary>
        /// <param name="frm">Main Form</param>
        public iDATMainMenuTile(HAENGSUNG_HNSMES_UI.WebService.Business.IDatabaseProcess clsDb)
        {
            if (_Db == null)
                _Db = clsDb;

            aryTileColors[0] = Color.FromArgb(0, 112, 153);
            aryTileColors[1] = Color.FromArgb(206, 68, 135);
            aryTileColors[2] = Color.FromArgb(224, 119, 0);
            aryTileColors[3] = Color.FromArgb(109, 58, 25);
            aryTileColors[4] = Color.FromArgb(218, 64, 74);
            aryTileColors[5] = Color.FromArgb(187, 24, 51);
            aryTileColors[6] = Color.FromArgb(166, 50, 110);
            aryTileColors[7] = Color.FromArgb(86, 23, 71);
            aryTileColors[8] = Color.FromArgb(0, 73, 152);
            aryTileColors[9] = Color.FromArgb(94, 151, 216);
            aryTileColors[10] = Color.FromArgb(60, 189, 217);
            aryTileColors[11] = Color.FromArgb(129, 72, 154);
            aryTileColors[12] = Color.FromArgb(151, 187, 0);
            aryTileColors[13] = Color.FromArgb(121, 121, 121);
            aryTileColors[14] = Color.FromArgb(187, 24, 51);
            aryTileColors[15] = Color.FromArgb(231, 198, 56);
            aryTileColors[16] = Color.FromArgb(85, 194, 147);
            aryTileColors[17] = Color.FromArgb(148, 104, 172);
            aryTileColors[18] = Color.FromArgb(65, 38, 76);
            aryTileColors[19] = Color.FromArgb(132, 116, 142);
            aryTileColors[20] = Color.FromArgb(182, 213, 69);
        }

        #endregion

        #region 이벤트 정의

        // TreeList MouseDown Delegate
        public delegate void Menu_MouseDown(object sender, TileItemEventArgs e);
        public delegate void FAVMenu_MouseDown(object sender, TileItemEventArgs e);
        public event Menu_MouseDown Menu_SelectEvent;
        public event FAVMenu_MouseDown FAVORITES_SelectEvent;

        #endregion

        #region 메뉴 만들기

        /// <summary>
        /// 그룹네임에 해당하는 동적메뉴를 생성합니다.
        /// </summary>
        /// <param name="Group_name">그룹 네임 명</param>
        public void Add_MenuGroup(DevExpress.XtraEditors.TileControl mTileCon)
        {
            WSResults result = null;

            LanguageInformation _clsLan = new LanguageInformation();
            iDATControlBinding _clsBind = new iDATControlBinding(_Db);
            Dictionary<string, object> param = new Dictionary<string, object>();
            //일단 초기화

            mTileCon.Groups.Clear();

            mTileCon.ItemSize = 120;
            mTileCon.Padding = new Padding(10);
            mTileCon.HorizontalContentAlignment = DevExpress.Utils.HorzAlignment.Near;

            Random rndColor = new Random();

            if (Settings_IDAT.Default.Use_Favorites)
            {
                TileGroup tgFav = new TileGroup();
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

                if (_dtFav.Rows.Count > 0)
                {
                    TileItem itemFavTitle = new TileItem();
                    itemFavTitle.Text = string.Format("<size=+3>{0}", "즐겨찾기");
                    itemFavTitle.Image = HAENGSUNG_HNSMES_UI.Properties.Resources.favorites;
                    itemFavTitle.ItemSize = DevExpress.XtraEditors.TileItemSize.Large;
                    itemFavTitle.TextAlignment = TileItemContentAlignment.BottomRight;
                    itemFavTitle.AppearanceItem.Normal.BackColor = aryTileColors[rndColor.Next(21)];
                    tgFav.Items.Add(itemFavTitle);

                    Parallel.For(0, _dtFav.Rows.Count, i =>
                    {
                        int _intIndex = ConvertUtil.ParseInt(_dtFav.Rows[i]["IMGIDX"] + "");

                        TileItem item = new TileItem();
                        item.AppearanceItem.Normal.BackColor = aryTileColors[rndColor.Next(21)];

                        item.ImageAlignment = TileItemContentAlignment.TopLeft;
                        item.Text = _clsLan.GetMessageString(_dtFav.Rows[i]["MENUNAME"].ObjectNullString());
                        item.Name = string.Format("{0},{1},{2}", _dtFav.Rows[i]["MENUSEQ"], _dtFav.Rows[i]["FORM"], _dtFav.Rows[i]["FORMROLE"]);

                        // 폼클래스 가져오기
                        System.Reflection.Assembly Ao_Ass = System.Reflection.Assembly.GetExecutingAssembly();
                        string strNameSpace = "";
                        strNameSpace = string.Format("Forms.{0}.", _dtFav.Rows[i]["FORM"].ObjectNullString().Substring(0, 3));
                        HAENGSUNG_HNSMES_UI.Forms.BASE.Form New_Form = Ao_Ass.CreateInstance(Ao_Ass.EntryPoint.DeclaringType.Namespace + "." + strNameSpace + _dtFav.Rows[i]["FORM"].ObjectNullString(), true) as HAENGSUNG_HNSMES_UI.Forms.BASE.Form;

                        item.Tag = New_Form.GetType();

                        item.ItemClick += new TileItemClickEventHandler(item_favItemClick);

                        item.ImageIndex = _intIndex;
                        item.TextAlignment = TileItemContentAlignment.BottomRight;
                        tgFav.Items.Add(item);
                    });

                    mTileCon.Groups.Add(tgFav);
                }
            }


            // 메뉴이름을 가져옵니다.===============================
            string Procname = "PKGSYS_MENU.GET_MENUROLE";

            param.Clear();
            param.Add("A_CLIENT", Global.Global_Variable.CLIENT);
            param.Add("A_COMPANY", Global.Global_Variable.COMPANY);
            param.Add("A_PLANT", Global.Global_Variable.PLANT);
            param.Add("A_SYSTEM", Global.Global_Variable.SYSTEMCODE);
            param.Add("A_USERROLE", Global.Global_Variable.USERROLE);
            result = _Db.Execute_Proc(Procname, 1, param);
            DataSet dsMenuChild = result.ResultDataSet;
            //이미지 리스트 생성
            System.Windows.Forms.ImageList _imgLst = new ImageList();
            _imgLst.Images.Add(HAENGSUNG_HNSMES_UI.Properties.Resources.button_remove);
            _imgLst.Images.Add(HAENGSUNG_HNSMES_UI.Properties.Resources.go);

            TileGroup tgMainMenu = new TileGroup();

            //foreach (DataRow row in dsMenuChild.Tables[0].Rows)
            Parallel.ForEach(dsMenuChild.Tables[0].AsEnumerable(), row =>
            {
                if (row["FORM"].ObjectNullString() != "")
                {
                    int _intIndex = ConvertUtil.ParseInt(row["IMGIDX"] + "");

                    TileItem item = new TileItem();
                    item.AppearanceItem.Normal.BackColor = aryTileColors[rndColor.Next(21)];

                    item.ImageAlignment = TileItemContentAlignment.TopLeft;
                    item.Text = _clsLan.GetMessageString(row["MENUNAME"].ObjectNullString());
                    item.Name = string.Format("{0},{1},{2}", row["MENUSEQ"], row["FORM"], row["FORMROLE"]);
                    item.ImageIndex = _intIndex;
                    item.TextAlignment = TileItemContentAlignment.BottomRight;
                    item.ItemClick += new TileItemClickEventHandler(item_ItemClick);

                    // 폼클래스 가져오기
                    System.Reflection.Assembly Ao_Ass = System.Reflection.Assembly.GetExecutingAssembly();
                    string strNameSpace = "";
                    strNameSpace = string.Format("Forms.{0}.", row["FORM"].ObjectNullString().Substring(0, 3));
                    HAENGSUNG_HNSMES_UI.Forms.BASE.Form New_Form = Ao_Ass.CreateInstance(Ao_Ass.EntryPoint.DeclaringType.Namespace + "." + strNameSpace + row["FORM"].ObjectNullString(), true) as HAENGSUNG_HNSMES_UI.Forms.BASE.Form;

                    if (New_Form != null)
                        item.Tag = New_Form.GetType();

                    tgMainMenu.Items.Add(item);
                }
            });

            mTileCon.Groups.Add(tgMainMenu);
        }

        void item_ItemClick(object sender, TileItemEventArgs e)
        {
            if (Menu_SelectEvent != null)
                Menu_SelectEvent(sender, e);
        }

        void item_favItemClick(object sender, TileItemEventArgs e)
        {
            if (FAVORITES_SelectEvent != null)
                FAVORITES_SelectEvent(sender, e);
        }

        #endregion
    }
}