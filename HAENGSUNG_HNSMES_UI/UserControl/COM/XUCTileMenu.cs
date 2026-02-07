using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.RealtorWorld.Win;
using System.Collections;
using HAENGSUNG_HNSMES_UI.WebService.Access;
using HAENGSUNG_HNSMES_UI.Class;
using IDAT_Common.Utility;

namespace HAENGSUNG_HNSMES_UI.UserControl.COM
{
    public partial class XUCTileMenu : HAENGSUNG_HNSMES_UI.Forms.BASE.UserControl
    {
        private readonly HAENGSUNG_HNSMES_UI.WebService.Business.IDatabaseProcess _Db = null;
        private readonly DevExpress.XtraTreeList.TreeList m_TreeMap = null;

        private readonly ArrayList aryTileControls = new ArrayList();
        private readonly Color[] aryTileColors = new Color[30];

        private readonly LanguageInformation _clsLan = new LanguageInformation();
        private readonly iDATControlBinding _clsBind = null;

        public XUCTileMenu(HAENGSUNG_HNSMES_UI.WebService.Business.IDatabaseProcess clsDb)
        {
            InitializeComponent();

            if (_Db == null)
                _Db = clsDb;

            _clsBind = new iDATControlBinding(_Db);

            Dictionary<string, object> param = new Dictionary<string, object>();

            //메뉴 설정 TreeList
            TreeList TL_Menu = new TreeList();
            string Procname = "PKGSYS_MENU.GET_MENU";
            
            param.Clear();
            param.Add("A_CLIENT", Global.Global_Variable.CLIENT);
            param.Add("A_COMPANY", Global.Global_Variable.COMPANY);
            param.Add("A_PLANT", Global.Global_Variable.PLANT);
            param.Add("A_SYSTEM", Global.Global_Variable.SYSTEMCODE);
            _Db.Execute_Proc(Procname, 1, param);

            TL_Menu.ParentFieldName = "UPRSEQ";
            TL_Menu.KeyFieldName = "MENUSEQ";

            m_TreeMap = TL_Menu;

            SetColors();

            mTileCon.Groups.Clear();

            mTileCon.ItemSize = 120;
            mTileCon.Padding = new Padding(10);
            mTileCon.HorizontalContentAlignment = DevExpress.Utils.HorzAlignment.Near;

            SetFavTileMenu();
        }

        private void SetFavTileMenu()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();

            panelControl_Fav.Visible = false;

            if (Settings_IDAT.Default.Use_Favorites)
            {
                panelControl_Fav.Visible = true;
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

                Random rndColor = new Random();

                TileItem itemFavTitle = new TileItem
                {
                    Text = string.Format("<size=+3>{0}", "즐겨찾기"),
                    ItemSize = TileItemSize.Large
                };
                itemFavTitle.AppearanceItem.Normal.BackColor = aryTileColors[rndColor.Next(21)];
                tgFav.Items.Add(itemFavTitle);


                for (int i = 0; i < _dtFav.Rows.Count; i++)
                {
                    int _intIndex = ConvertUtil.ParseInt(_dtFav.Rows[i]["IMGIDX"] + "");

                    TileItem item = new TileItem();
                    item.AppearanceItem.Normal.BackColor = aryTileColors[rndColor.Next(21)];

                    item.ImageAlignment = TileItemContentAlignment.TopLeft;
                    item.Text = _clsLan.GetMessageString(_dtFav.Rows[i]["MENUNAME"].ObjectNullString());
                    item.ImageIndex = _intIndex;
                    item.TextAlignment = TileItemContentAlignment.BottomRight;
                    tgFav.Items.Add(item);
                }

                mTileCon.Groups.Add(tgFav);
            }
        }

        private void SetColors()
        {
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

        public void AddTileControlParent()
        {
            TileControl tileCon = new TileControl
            {
                Name = "1"
            };

            if (aryTileControls.Count == 0)
                aryTileControls.Add(tileCon);
            else
            {
                foreach (TileControl tlCon in aryTileControls)
                {
                    if (tlCon.Name == "1")
                        return;
                }

                aryTileControls.Add(tileCon);
            }

            TileGroup tileGroup = new TileGroup();

            //foreach (TreeListNode cNode in node.Nodes)
            //{
            //    TileItem tTitle = new TileItem();
            //    tTitle.Text = cNode.GetDisplayText("MENUNAME");
            //    tTitle.Id = IDAT_Common.Utility.ConvertUtil.ParseInt(cNode["MENUSEQ"].ObjectNullString());
            //    tileGroup.Items.Add(tTitle);
            //    tTitle.ItemClick += new TileItemClickEventHandler(tTitle_ItemClick);
            //}

            tileCon.Groups.Add(tileGroup);
            panelControl_TileBack.Controls.Add(tileCon);
        }

        public void AddTileControl(TileItem tile)
        {
            TileControl tileCon = new TileControl
            {
                Name = tile.Id.ObjectNullString()
            };
            
            if (aryTileControls.Count == 0)
                aryTileControls.Add(tileCon);
            else
            {
                foreach (TileControl tlCon in aryTileControls)
                {
                    if (tlCon.Name == tile.Id.ObjectNullString())
                        return;
                }

                aryTileControls.Add(tileCon);
            }

            TreeListNode node = m_TreeMap.GetNodeByVisibleIndex(tile.Id);
            TileGroup tileGroup = new TileGroup();

            foreach (TreeListNode cNode in node.Nodes)
            {
                TileItem tTitle = new TileItem
                {
                    Text = cNode.GetDisplayText("MENUNAME"),
                    Id = IDAT_Common.Utility.ConvertUtil.ParseInt(cNode["MENUSEQ"].ObjectNullString())
                };
                tileGroup.Items.Add(tTitle);
                tTitle.ItemClick += new TileItemClickEventHandler(tTitle_ItemClick);
            }

            tileCon.Groups.Add(tileGroup);
            panelControl_TileBack.Controls.Add(tileCon);
        }

        void tTitle_ItemClick(object sender, TileItemEventArgs e)
        {
            
        }
    }
}
