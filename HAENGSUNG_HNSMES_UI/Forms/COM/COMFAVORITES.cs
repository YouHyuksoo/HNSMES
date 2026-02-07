using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using DevExpress.XtraNavBar;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;



//using IDAT_WebService.IDAT_WebSvr;

using HAENGSUNG_HNSMES_UI.Class;
using HAENGSUNG_HNSMES_UI.WebService.Access;

namespace HAENGSUNG_HNSMES_UI.Forms.COM
{
    public partial class COMFAVORITES : BASE.Form
    {

        #region 생성

        LanguageInformation clsLan = new LanguageInformation();

        /// <summary>
        /// 생성자
        /// </summary>
        public COMFAVORITES()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form Load Event
        /// </summary>
        private void frmShortCutMenuMng_Load(object sender, EventArgs e)
        {
            // 메뉴정보를 초기화
            InitMenuList();

            // 현재 로그인 유저의 즐겨찾기 목록을 가져옵니다.
            InitFavoritesList(Global.Global_Variable.USER_ID);
        }

        #endregion

        /// 1. 메뉴 정보를 모두 초기화 합니다.
        /// 2. 즐겨찾기를 저장합니다.
        /// 3. 즐겨찾기 리스트를 불러옵니다.
        /// 4. 즐겨 찾기 목로게 아이템을 추가합니다.
        /// 5. 메뉴 목록을 체크합니다.
        /// 6. 메뉴 항목에서 즐겨찾기 목록으로 추가를 합니다.
        #region [Private Method]

        /// [1]
        /// <summary>
        /// 메뉴 정보를 모두 초기화 합니다.
        /// </summary>
        private void InitMenuList()
        {
            // 메뉴관련 프로시져 네임
            string ProcName = "PKGSYS_MENU.GET_MENU";

            WSResults result = BASE_db.Execute_Proc(ProcName
                                                             , 1
                                                             , new string[] {
                                                                               "A_CLIENT"
                                                                             , "A_COMPANY"
                                                                             , "A_PLANT"
                                                                             , "A_SYSTEM" 
                                                                             , "A_USERROLE"
                                                                            }
                                                             , new string[] {
                                                                               Global.Global_Variable.CLIENT
                                                                             , Global.Global_Variable.COMPANY
                                                                             , Global.Global_Variable.PLANT
                                                                             , Global.Global_Variable.SYSTEMCODE
                                                                             , ""
                                                                            }
                                                            );

            if (result.ResultInt != 0)
            {
                Class.iDATMessageBox.ShowProcResultMessage(result, this.Text, Global.Global_Variable.USER_ID, ProcName, null);
            }
            else
            {
                DataTable dt = result.ResultDataSet.Tables[0];

                tl_Menu.OptionsBehavior.Editable = false;
                tl_Menu.OptionsView.ShowColumns = false;
                tl_Menu.ParentFieldName = "UPRSEQ";
                tl_Menu.KeyFieldName = "MENUSEQ";
                tl_Menu.RowHeight = 30;
                tl_Menu.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowForFocusedRow;
                tl_Menu.OptionsView.ShowCheckBoxes = true;

                tl_Menu.DataSource = result.ResultDataSet.Tables[0].DefaultView;

                tl_Menu.Appearance.Row.Font = new Font("Tahoma", 9);
                tl_Menu.PopulateColumns();
                tl_Menu.ExpandAll();
                tl_Menu.Columns["FORM"].Visible = false;
                tl_Menu.Columns["FORMPARAM"].Visible = false;
                tl_Menu.Columns["IMGIDX"].Visible = false;
                tl_Menu.Columns["DISPFLAG"].Visible = false;
                tl_Menu.Columns["PERENT_MENU"].Visible = false;
                tl_Menu.Columns["DISPSEQ"].Visible = false;
                tl_Menu.Columns["USEFLAG"].Visible = false;
                tl_Menu.Columns["MENUNAME"].Visible = true;

                tl_Menu.BestFitColumns();

                tl_Menu.Cursor = Cursors.Hand;
            }
        }

        /// [2]
        /// <summary>
        /// 즐겨찾기를 저장합니다.
        /// </summary>
        /// <param name="aryMenuSeq"></param>
        private void SaveFavorites(int[] aryMenuSeq)
        {
            WaitDialogForm waitDlg = new WaitDialogForm(clsLan.GetMessageString("MSG016"), this.Text);

            try
            {
                /// 프로시져 명 : PKG_USER.EDT_FAVORITES
                /// 즐겨찾기 목록을 수정합니다.
                /// 
                string Procname = "PKGSYS_USER.PUT_FAVRT";

                int sortIdx = 1;
                WSResults resultCls = null;

                waitDlg.Show();

                foreach (int MenuSeq in aryMenuSeq)
                {
                   resultCls =  BASE_db.Execute_Proc(Procname
                                        , 1
                                        , new string[] {
                                                          "A_CLIENT"
                                                        , "A_COMPANY"
                                                        , "A_PLANT"
                                                        , "A_SYSTEM"
                                                        , "A_USERID"
                                                        , "A_MENUSEQ"
                                                        , "A_DISPSEQ"
                                                       }
                                        , new string[] {
                                                          Global.Global_Variable.CLIENT
                                                        , Global.Global_Variable.COMPANY
                                                        , Global.Global_Variable.PLANT
                                                        , Global.Global_Variable.SYSTEMCODE
                                                        , Global.Global_Variable.USER_ID
                                                        , MenuSeq.ToString()
                                                        , (sortIdx++).ToString()
                                                       }
                                       );

                }

                if (aryMenuSeq.Length == 0)
                {
                    resultCls = BASE_db.Execute_Proc(Procname
                                        , 1
                                        , new string[] {
                                                          "A_SYSTEM"
                                                        , "A_USERID"
                                                        , "A_MENUSEQ"
                                                        , "A_DISPSEQ"
                                                       }
                                        , new string[] {
                                                          Global.Global_Variable.SYSTEMCODE
                                                        , Global.Global_Variable.USER_ID
                                                        , "0"
                                                        , "0"
                                                       }
                                       );
                }


                waitDlg.Close();
                iDATMessageBox.ShowProcResultMessage(resultCls, "Save Favorites", 5, Global.Global_Variable.USER_ID, Procname, null);
            }
            catch (Exception ex)
            {
                waitDlg.Close();
                iDATMessageBox.ErrorMessage(ex, 5, Global.Global_Variable.USER_ID, "", null);
            }
            finally
            {
                // 즐겨찾기 항목을 다시 보여줍니다.
                InitFavoritesList(Global.Global_Variable.USER_ID);
            }
        }

        /// [3]
        /// <summary>
        /// 즐겨찾기 리스트를 불러옵니다.
        /// </summary>
        private void InitFavoritesList(string strEHRCode)
        {
            /// 프로시져 명 : PKG_USER.SEL_FAVORITES
            /// 즐겨찾기 목록을 가져옵니다..
            string ProcName = "PKGSYS_USER.GET_FAVRT";

            WSResults resultCls = BASE_db.Execute_Proc(ProcName
                                                    , 1
                                                    , new string[] {
                                                                      "A_CLIENT"
                                                                    , "A_COMPANY"
                                                                    , "A_PLANT"
                                                                    , "A_SYSTEM"
                                                                    , "A_USERID" 
                                                                }
                                                    , new string[] {
                                                                      Global.Global_Variable.CLIENT
                                                                    , Global.Global_Variable.COMPANY
                                                                    , Global.Global_Variable.PLANT
                                                                    , Global.Global_Variable.SYSTEMCODE
                                                                    , Global.Global_Variable.USER_ID
                                                                });

            // 현재 사용자의 즐겨 찾기 목록이 존재하면 리스트를 보여주도록 한다.
            if (resultCls.ResultInt == 0)
            {
                navGroup_ShortCut.ItemLinks.Clear();

                foreach (DataRow dr in resultCls.ResultDataSet.Tables[0].Rows)
                {
                    ShortCutMenu_AddNode(dr["MENUSEQ"].ToString(), dr["MENUNAME"].ToString(), dr["FORM"].ToString());
                }

                // 사용자 즐겨찾기 정보를 트리리스트를 초기화 한다.
                InitFavoritesTreeListCheck(tl_Menu.Nodes);
            }
        }

        private void InitFavoritesTreeListCheck(DataTable dt, TreeListNodes nodes)
        {
            if (dt.Rows.Count > 0)
            {
                foreach (TreeListNode tl_node in nodes)
                {
                    if (tl_node.Nodes.Count > 0)
                    {
                        InitFavoritesTreeListCheck(dt, tl_node.Nodes);
                    }

                    if (dt.Select(string.Format("MENUSEQ = '{0}'", tl_node["MENUSEQ"])).Length > 0)
                    {
                        tl_node.Checked = true;
                    }
                    else
                    {
                        tl_node.Checked = false;
                    }
                }
            }
        }

        private void InitFavoritesTreeListCheck(TreeListNodes nodes)
        {
            foreach (TreeListNode tl_node in nodes)
            {
                if (tl_node.Nodes.Count > 0)
                {
                    InitFavoritesTreeListCheck(tl_node.Nodes);
                }

                tl_node.Checked = false;
            }
        }

        /// [4]
        /// <summary>
        /// 즐겨 찾기 목록에 아이템을 추가합니다.
        /// </summary>
        /// <param name="listNode">선택한 리스트 노드</param>
        private void ShortCutMenu_AddNode(string nodeSeq, string nodeCaption, string nodeFormCode)
        {
            NavLinkCollection _navCol = navGroup_ShortCut.ItemLinks;


            foreach (NavBarItemLink _navItem in _navCol)
            {
                if (_navItem.Caption == nodeCaption)
                {
                    iDATMessageBox.WARNINGMessage("중복된 메뉴입니다", "Warning", 1);
                    return;
                }
            }

            NavBarItem navbarItem = new NavBarItem();

            navbarItem.Appearance.Font = new Font("Tahoma", 12);
            navbarItem.Appearance.Options.UseFont = true;

            navbarItem.AppearanceHotTracked.Font = new Font("Tahoma", 12);
            navbarItem.AppearanceHotTracked.Options.UseFont = true;

            navbarItem.AppearancePressed.Font = new Font("Tahoma", 12, FontStyle.Underline);
            navbarItem.AppearancePressed.ForeColor = Color.MidnightBlue;
            navbarItem.AppearancePressed.Options.UseFont = true;
            navbarItem.AppearancePressed.Options.UseForeColor = true;

            navbarItem.Caption = nodeCaption;
            navbarItem.Tag = nodeSeq + "|" + nodeFormCode;
            navGroup_ShortCut.ItemLinks.Add(navbarItem);
        }

        /// [5]
        /// <summary>
        ///  메뉴 목록을 체크합니다.
        /// </summary>
        /// <param name="gnode">node</param>
        /// <param name="nodeChecker">체크여부</param>
        /// <remarks>
        /// 즐겨찾기를 위해 메뉴목록을 체크하는 프로세스입니다.
        /// </remarks>
        private void ChildNodeCheck(DevExpress.XtraTreeList.Nodes.TreeListNode gnode, bool nodeChecker)
        {
            gnode.Checked = nodeChecker;

            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode node in gnode.Nodes)
            {
                node.Checked = nodeChecker;

                if (node.Nodes.Count > 0)
                {
                    ChildNodeCheck(node, nodeChecker);
                }
            }
        }

        /// [6]
        /// <summary>
        /// 메뉴항목에서 즐겨찾기 목록으로 추가를 합니다.
        /// </summary>
        /// <param name="listNode">노드</param>
        /// <param name="isChecked">체크</param>
        private void AddShortCutMenu(TreeListNode listNode, bool isChecked)
        {
            //// 이코드는 바로찾기 제한을 10개 까지만 제한하기 위해 만든 코드이다. 현재는 사용하지 않음.
            //if (navGroup_ShortCut.ItemLinks.Count > 10)
            //{
            //    return;
            //}

            // 현재 선택된 노드가 구룹이 아니면 바로가기 추가를 한다.
            // 그렇치 않으면 재귀호출을 통해 자식 노드까지 바로가기에 추가를 할 수 있도록 한다.
            if (listNode.GetDisplayText(2) != "")
            {
                foreach (NavBarItemLink item in navGroup_ShortCut.ItemLinks)
                {
                    if (item.Item.Tag.ToString().Split('|')[0] == listNode[3].ToString().Trim())
                    {
                        return;
                    }
                }

                if (isChecked)
                {
                    if (listNode.Checked)
                    {

                        ShortCutMenu_AddNode(listNode.GetValue("MENUSEQ").ToString(), listNode["MENUNAME"].ToString(), listNode["FORM"].ToString());
                    }
                }
                else
                {
                    ShortCutMenu_AddNode(listNode.GetValue("MENUSEQ").ToString(), listNode["MENUNAME"].ToString(), listNode["FORM"].ToString());
                }
            }
            else
            {
                foreach (TreeListNode node in listNode.Nodes)
                {
                    AddShortCutMenu(node, isChecked);
                }
            }
        }

        #endregion

        #region [Menu LIst Event]

        TreeListNode KeyNode = null;
        bool isFlag = false;

        private void tl_Menu_AfterCheckNode(object sender, NodeEventArgs e)
        {
            ChildNodeCheck(e.Node, e.Node.Checked);
        }

        private void tl_Menu_MouseUP(object sender, MouseEventArgs e)
        {
            Console.WriteLine("tl_Menu_MouseDown : " + isFlag);


            if (isFlag)
            {
                isFlag = false;                                          
                return;
            }

            if (e.Clicks == 1)
            {
                TreeListHitInfo hi = tl_Menu.CalcHitInfo(new Point(e.X, e.Y));
                TreeListNode node = hi.Node;

                if (hi.HitInfoType == HitInfoType.NodeCheckBox)
                    return;                

                if (node != null)
                {
                    if (node.Nodes.Count > 0)
                    {
                        if (!node.Expanded)
                        {
                            isFlag = true;
                            node.Expanded = true;
                        }
                        else
                        {
                            isFlag = true;
                            node.Expanded = false;
                        }
                    }
                    else
                    {
                        ChildNodeCheck(node, !node.Checked);
                    }
                }
            }

            #region [더블 클릭시에 수행되는 프로세스-현재는 사용하지 않음]
            //
            //if (e.Clicks == 2)
            //{
            //    TreeListHitInfo hi = tl_Menu.CalcHitInfo(new Point(e.X, e.Y));
            //    TreeListNode node = hi.Node;

            //    //if (node != null)
            //    //{
            //    //    AddShortCutMenu(node, false);
            //    //}
            //}
            #endregion
        }

        /// <summary>
        /// 트리 확장되기전에 발생되는 이벤트
        /// </summary>
        private void tl_Menu_BeforeCollapse(object sender, BeforeCollapseEventArgs e)
        {
            if (!isFlag)
            {
                isFlag = true;
            }
            else
            {
                isFlag = false;
            }
        }

        /// <summary>
        ///  확장 후에 발생되는 이벤트
        /// </summary>
        private void tl_Menu_BeforeExpand(object sender, BeforeExpandEventArgs e)
        {
            if (isFlag)
            {
                isFlag = false;
            }
            else
            {
                isFlag = true;
            }
        }

        /// <summary>
        /// Keyup Event
        /// </summary>
        /// <remarks>엔터값을 찾아 트리를 확장하고 축소한다.</remarks>
        private void tl_Menu_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (KeyNode != null)
                {
                    if (KeyNode.Expanded)
                    {
                        KeyNode.Expanded = false;
                    }
                    else
                    {
                        KeyNode.Expanded = true;
                    }
                }
            }
        }

        /// <summary>
        /// FocusedNodeChanged Event
        /// </summary>
        /// <remarks>메뉴의 포커스 이동이 되면 전역변수에 노드정보를 저장한다. Key(엔터값)을 입력하여 트리확장을 하기 위함.</remarks>
        private void tl_Menu_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            KeyNode = e.Node;
        }

        #endregion

        #region [Favorites List Event]

        /// <summary>
        /// 즐겨찾기 목록을 마우스다운했을때 발생하는 이벤트
        /// </summary>
        /// <remarks>
        /// 즐겨찾기 목록을 더블클릭을 하면 목록을 삭제합니다.
        /// </remarks>
        private void navBarControl_ShortCutMenu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks != 2)
            {
                return;
            }

            DevExpress.XtraNavBar.NavBarControl con = sender as DevExpress.XtraNavBar.NavBarControl;
            DevExpress.XtraNavBar.NavBarHitInfo hi = con.CalcHitInfo(new Point(e.X, e.Y));

            if (hi.Link != null)
            {
                navGroup_ShortCut.ItemLinks.Remove(hi.Link);
            }
        }

        #endregion

        /// 1. 체크 버튼
        /// 2. 닫기 버튼
        /// 3. 저장 버튼
        /// 4. 초기화 버튼
        /// 5. 목록추가버튼
        /// 6. 목록삭제버튼
        /// 7. 트리리스트 확장
        /// 8. 트리리스트 축소
        #region [Button Click Event]

        /// [2]
        /// <summary>
        /// 닫기 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// [3]
        /// <summary>
        /// 저장 버튼 클릭 이벤트
        /// </summary>
        /// <remarks>
        /// 즐겨찾기를 수정합니다.
        /// </remarks>
        private void btnSave_Click(object sender, EventArgs e)
        {
            int[] aryMenuNumbers = new int[navGroup_ShortCut.ItemLinks.Count];

            int i = 0;
            foreach (NavBarItemLink item in navGroup_ShortCut.ItemLinks)
            {
                aryMenuNumbers[i++] = Convert.ToInt16(item.Item.Tag.ToString().Split('|')[0]);

            }

            this.SaveFavorites(aryMenuNumbers);

            MainForm frmM = (MainForm)this.Owner;
            frmM.Set_MenuList();
        }

        /// [4]
        /// <summary>
        /// 초기화 버튼 클릭 이벤트
        /// </summary>
        private void btnInit_Click(object sender, EventArgs e)
        {
            navGroup_ShortCut.ItemLinks.Clear();

            // 사용자 즐겨찾기 정보를 트리리스트를 초기화 한다.
            InitFavoritesTreeListCheck(tl_Menu.Nodes);
        }

        /// [5]
        /// <summary>
        /// 추가 버튼 클릭 이벤트
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (TreeListNode node in tl_Menu.Nodes)
            {
                AddShortCutMenu(node, true);
            }

            // 사용자 즐겨찾기 정보를 트리리스트를 초기화 한다.
            InitFavoritesTreeListCheck(tl_Menu.Nodes);
        }

        /// [6]
        /// <summary>
        /// 목록 삭제 버튼 클릭이벤트
        /// </summary>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (navGroup_ShortCut.SelectedLink != null)
            {
                navGroup_ShortCut.ItemLinks.Remove(navGroup_ShortCut.SelectedLink);
            }
        }

        /// [7]
        /// <summary>
        /// 트리 리스트 확장 버튼
        /// </summary>
        private void btn_AllExpendOn_Click(object sender, EventArgs e)
        {
            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode node in tl_Menu.Nodes)
            {
                node.Expanded = true;
            }
        }

        /// [8]
        /// <summary>
        /// 트리 리스트 축소 버튼
        /// </summary>
        private void btn_AllExpendOff_Click(object sender, EventArgs e)
        {
            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode node in tl_Menu.Nodes)
            {
                node.Expanded = false;
            }
        }

        #endregion

        /// <summary>
        /// Up 버튼 클릭 이벤트
        /// </summary>
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (navGroup_ShortCut.SelectedLinkIndex != 0)
            {
                navGroup_ShortCut.ItemLinks.Move(navGroup_ShortCut.SelectedLinkIndex, navGroup_ShortCut.SelectedLinkIndex - 1);
                navGroup_ShortCut.SelectedLinkIndex = navGroup_ShortCut.SelectedLinkIndex - 1;
            }
        }

        /// <summary>
        /// Down 버튼 클릭 이벤트
        /// </summary>
        private void btnDown_Click(object sender, EventArgs e)
        {
            if (navGroup_ShortCut.ItemLinks.Count - 1 > navGroup_ShortCut.SelectedLinkIndex)
            {
                navGroup_ShortCut.ItemLinks.Move(navGroup_ShortCut.SelectedLinkIndex, navGroup_ShortCut.SelectedLinkIndex + 1);
                navGroup_ShortCut.SelectedLinkIndex = navGroup_ShortCut.SelectedLinkIndex + 1;
            }
        }

        /// <summary>
        /// 닫기 버튼 클릭 이벤트
        /// </summary>
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
