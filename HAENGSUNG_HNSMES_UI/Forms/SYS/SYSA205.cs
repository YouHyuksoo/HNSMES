using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;

using HAENGSUNG_HNSMES_UI.Class;
using HAENGSUNG_HNSMES_UI.WebService.Access;


namespace HAENGSUNG_HNSMES_UI.Forms.SYS
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : SYSA205<br/>
    ///      기능 : 메뉴 마스터 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    public partial class SYSA205 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
    {
        // ******************************************* Base From Class ************************************
        // BASE_clsDevexpressGridUtil          DevExpress Grid 관련 Util Class.
        // BASE_db;                            웹서비스 DB처리 관련 Util Class.
        // BASE_DXGridHelper;                  DevExpress GridControl 데이터 Bind관련 Class
        // BASE_DXGridLookUpHelper;            DevExpress GridLookUp 데이터 Bind관련 Class
        // BASE_IDATLayoutUtil;                DevExpress LayoutControl Util Class.
        // BASE_Language;                      Language Util. ex) BASE_Language.GetMessageString("Code") 
        // ************************************************************************************************

        //+++++++++++++++++++++++++++++++++++++++전역변수
        LanguageInformation clsLan = new LanguageInformation();
        TreeListNode tl_SelectNode = null;
        //bool clickFlg = false;
        DataTable dtMenu = null;
        //+++++++++++++++++++++++++++++++++++++++

        #region [생성자 / Form Event]

        /// <summary>
        /// 생성자
        /// </summary>
        public SYSA205()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form Load Event
        /// </summary>
       
        private void SYSA205_Load(object sender, EventArgs e)
        {
            InitButton_Click();
            MainButton_Save.IsUse = true;
        }
        private void SYSA205_Shown(object sender, EventArgs e)
        {

        }
        

        #endregion

        #region 버튼이벤트

        public void InitButton_Click()
        {
            SetImageConllection();
            SetFormMasterRepositoryItemComboBox();

            InitMenuLIst();
        }

        public void DeleteButton_Click()
        {
        }

        public void NewButton_Click()
        {

            WSResults _result;
            string[] _arrPara;
            string[] _arrValue;

            if (tl_Menu.FocusedNode != null)
            {
            }

            /// 자식을 가질수 있는 노드인지 확인
            /// 조건은 FORMCODE가 NULL인 것은 ParentNode가 될수 있는 노드이다.
            if (tl_Menu.FocusedNode.ParentNode != null)
            {
                string tVal = tl_Menu.FocusedNode["FORM"].ToString();

                if (tVal.Length > 0)
                {
                    iDATMessageBox.WARNINGMessage(clsLan.GetMessageString("MSG018"), "WARNING", 0);
                    InitMenuLIst();

                    return;
                }
            }

            // 추가된 PARENT NODE에 자식 노드를 추가하게 되면 PARENT NODE를 디비에 저장해서 SEQUENC번호를 받는다.
            if (tl_Menu.FocusedNode["MENUSEQ"].ToString() == "")
            {
                if (iDATMessageBox.QuestionMessage("생성된 상위 메뉴는 저장이 됩니다. 하위 메뉴를 추가하시겠습니까?", "메뉴 추가") == DialogResult.No)
                {
                    return;
                }

                string procName = "PKGSYS_MENU.PUT_MENU";

                string parentIndex = tl_Menu.FocusedNode.ParentNode["MENUSEQ"].ToString();
                string menuName = tl_Menu.FocusedNode["MENUNAME"].ToString();
                string frmcode = tl_Menu.FocusedNode["FORM"].ToString();
                string imgidx = tl_Menu.FocusedNode["IMGIDX"].ToString();
                string dispIdx = tl_Menu.FocusedNode["DISPSEQ"].ToString();
                string dispflag = tl_Menu.FocusedNode["DISPFLAG"].ToString();
                string frmparam = tl_Menu.FocusedNode["FORMPARAM"].ToString();

                _arrPara = new string[] { "A_CLIENT"
                                        , "A_COMPANY"
                                        , "A_PLANT"
                                        , "A_SYSTEM"
                                        , "A_PARENTSEQ"
                                        , "A_MNUNAME"
                                        , "A_FRMCODE"
                                        , "A_FRMPARAM"
                                        , "A_IMGIDX"
                                        , "A_DISPIDX"
                                        , "A_DISPFLAG"
                                        , "A_REMARKS"
                                        , "A_USER"
                                        };

                _arrValue = new string[] { Global.Global_Variable.CLIENT
                                         , Global.Global_Variable.COMPANY
                                         , Global.Global_Variable.PLANT
                                         , Global.Global_Variable.SYSTEMCODE
                                         , parentIndex
                                         , menuName
                                         , frmcode
                                         , frmparam
                                         , imgidx
                                         , dispIdx
                                         , dispflag
                                         , ""
                                         , Global.Global_Variable.EHRCODE
                                         };

                _result = BASE_db.Execute_Proc(procName, 1, _arrPara, _arrValue);

                if (_result.ResultInt != 0)
                {
                    iDATMessageBox.ShowProcResultMessage(_result, this.Text, 5, Global.Global_Variable.USER_ID, procName, _arrPara, _arrValue);
                }
                else
                {
                    tl_Menu.FocusedNode["MENUSEQ"] = _result.ResultDataSet.Tables[0].Rows[0][0];
                }
            }

            tl_Menu.FocusedNode = tl_Menu.AppendNode(null, tl_Menu.FocusedNode);
            tl_Menu.FocusedNode["PERENT_MENU"] = tl_Menu.FocusedNode.ParentNode["MENUNAME"];
            tl_Menu.FocusedNode["USEFLAG"] = "Y";
            tl_Menu.FocusedNode["DISPFLAG"] = "Y";
            tl_Menu.FocusedNode["UPRSEQ"] = tl_Menu.FocusedNode.ParentNode["MENUSEQ"];
            tl_Menu.FocusedNode["MENUNAME"] = "New Menu";
            tl_Menu.FocusedNode["IMGIDX"] = "0";

            if (tl_Menu.FocusedNode.PrevNode != null)
            {
                tl_Menu.FocusedNode["DISPSEQ"] = 900;
            }
            else
            {
                tl_Menu.FocusedNode["DISPSEQ"] = 900;
            }

            int prevIdx = tl_Menu.GetVisibleIndexByNode(tl_Menu.FocusedNode);

            SaveButton_Click();

            tl_Menu.TopVisibleNodeIndex = prevIdx - 1;

            Class.iDATMessageBox.OKMessage("메뉴추가 성공!", "완료", 5);

            MainButton_New.IsUse = true;

        }

        public void EditButton_Click()
        {
        }

        public void StopButton_Click()
        {
        }

        public void SearchButton_Click()
        {
        }

        public void SaveButton_Click()
        {
            WSResults _result;
            string[] _arrPara;
            string[] _arrValue;

            int currentIdx = tl_Menu.FocusedNode.Id;

            tl_Menu.MoveNext();
            tl_Menu.MovePrev();

            DevExpress.Utils.WaitDialogForm wait = new DevExpress.Utils.WaitDialogForm(clsLan.GetMessageString("MSG016"), clsLan.GetMessageString("Menu Save"));
            wait.Show();

            try
            {
                foreach (DataRow dr in dtMenu.Rows)
                {
                    string procName;
                    string parentIndex;
                    string seq;
                    string menuName;
                    string frmcode;
                    string imgidx;
                    string dispIdx;
                    string dispflag;
                    string useflag;
                    string frmparam;

                    if (dr.RowState == DataRowState.Modified)
                    {
                        procName = "PKGSYS_MENU.PUT_MENU";

                        parentIndex = dr["UPRSEQ"] + "" == "0" ? "1" : dr["UPRSEQ"] + "";
                        seq = dr["MENUSEQ"].ToString();
                        menuName = dr["MENUNAME"].ToString();
                        frmcode = dr["FORM"].ToString();
                        imgidx = dr["IMGIDX"].ToString();
                        dispIdx = dr["DISPSEQ"].ToString();
                        dispflag = dr["DISPFLAG"].ToString();
                        useflag = dr["USEFLAG"].ToString();
                        frmparam = dr["FORMPARAM"].ToString();

                        _arrPara = new string[] { "A_CLIENT"
                                                , "A_COMPANY"
                                                , "A_PLANT"
                                                , "A_SYSTEM"
                                                , "A_PARENTSEQ"
                                                , "A_SEQ"
                                                , "A_MNUNAME"
                                                , "A_FRMCODE"
                                                , "A_FRMPARAM"
                                                , "A_IMGIDX"
                                                , "A_DISPIDX"
                                                , "A_DISPFLAG"
                                                , "A_REMARKS"
                                                , "A_USEFLAG"
                                                , "A_USER"
                                                };

                        _arrValue = new string[] { Global.Global_Variable.CLIENT
                                                 , Global.Global_Variable.COMPANY
                                                 , Global.Global_Variable.PLANT
                                                 , Global.Global_Variable.SYSTEMCODE
                                                 , parentIndex
                                                 , seq
                                                 , menuName
                                                 , frmcode
                                                 , frmparam
                                                 , imgidx
                                                 , dispIdx
                                                 , dispflag
                                                 , ""
                                                 , useflag
                                                 , Global.Global_Variable.USER_ID
                                                 };

                        _result = BASE_db.Execute_Proc(procName, 2, _arrPara, _arrValue);

                        wait.Caption = string.Format("{0} {1}", menuName, clsLan.GetMessageString("Save"));

                        if (_result.ResultInt != 0)
                        {
                            iDATMessageBox.ShowProcResultMessage(_result, this.Text, 5, Global.Global_Variable.USER_ID, procName, _arrPara, _arrValue);
                        }
                    }

                    if (dr.RowState == DataRowState.Added)
                    {
                        procName = "PKGSYS_MENU.PUT_MENU";

                        parentIndex = dr["UPRSEQ"].ToString();
                        menuName = dr["MENUNAME"].ToString();
                        frmcode = dr["FORM"].ToString();
                        imgidx = dr["IMGIDX"].ToString();
                        dispIdx = dr["DISPSEQ"].ToString();
                        dispflag = dr["DISPFLAG"].ToString();
                        frmparam = dr["FORMPARAM"].ToString();

                        _arrPara = new string[] { "A_CLIENT"
                                                , "A_COMPANY"
                                                , "A_PLANT"
                                                , "A_SYSTEM"
                                                , "A_PARENTSEQ"
                                                , "A_MNUNAME"
                                                , "A_FRMCODE"
                                                , "A_FRMPARAM"
                                                , "A_IMGIDX"
                                                , "A_DISPIDX"
                                                , "A_DISPFLAG"
                                                , "A_REMARKS"
                                                , "A_USER"
                                                };

                        _arrValue = new string[] { Global.Global_Variable.CLIENT
                                                 , Global.Global_Variable.COMPANY
                                                 , Global.Global_Variable.PLANT
                                                 , Global.Global_Variable.SYSTEMCODE
                                                 , parentIndex
                                                 , menuName
                                                 , frmcode
                                                 , frmparam
                                                 , imgidx
                                                 , dispIdx
                                                 , dispflag
                                                 , ""
                                                 , Global.Global_Variable.USER_ID
                                                 };

                        _result = BASE_db.Execute_Proc(procName, 1, _arrPara, _arrValue);

                        wait.Caption = string.Format("{0} {1}", menuName, clsLan.GetMessageString("Save"));

                        if (_result.ResultInt != 0)
                        {
                            iDATMessageBox.ShowProcResultMessage(_result, this.Text, 5, Global.Global_Variable.USER_ID, procName, _arrPara, _arrValue);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                iDATMessageBox.ErrorMessage(ex, Global.Global_Variable.USER_ID);
            }
            finally
            {
                wait.Close();

                dtMenu.AcceptChanges();

            }

            InitMenuLIst();

            tl_Menu.FocusedNode = tl_Menu.FindNodeByID(currentIdx);
        }

        public void PrintButton_Click()
        {
        }

        public void RefreshButton_Click()
        {
            BASE_IDATLayoutUtil.DevControlsClear_LayoutControl(layoutControl1);

            this.InitMenuLIst();
            this.SetFormMasterRepositoryItemComboBox();
        }

        #endregion

        #region [트리리스트 스타일 관련 함수]

        /// <summary>
        /// 그리드뷰의 FormatCondition 스타일 지정
        /// </summary>
        /// <param name="gridView">그리드 뷰</param>
        /// <param name="columnFieldString">컬럼필드명</param>
        /// <param name="MathValue">매칭 포멧 명</param>
        /// <param name="apperanceObj">FormatCondition Style</param>
        public void SetStyleFormatCondition_CustomRootMenu(TreeList tl_obj, string columnFieldString, object MathValue, DevExpress.Utils.AppearanceObject apperanceObj)
        {
            DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition styleFormatCondition = new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition();

            tl_obj.FormatConditions.Add(styleFormatCondition);
            styleFormatCondition.Appearance.Combine(apperanceObj);
            styleFormatCondition.Column = tl_obj.Columns[columnFieldString];
            styleFormatCondition.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition.ApplyToRow = true;
            styleFormatCondition.Value1 = MathValue;
        }

        private DevExpress.Utils.AppearanceObject objApperanceColor = new DevExpress.Utils.AppearanceObject();

        public DevExpress.Utils.AppearanceObject GetStyleFormatObjApperanceColor_Root
        {
            get
            {
                objApperanceColor.Font = new System.Drawing.Font("Tahoma", 9F, FontStyle.Bold);
                objApperanceColor.ForeColor = Color.Black;
                objApperanceColor.BackColor = Color.Bisque;
                objApperanceColor.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;

                return objApperanceColor;
            }
        }

        public DevExpress.Utils.AppearanceObject GetStyleFormatObjApperanceColor_USEYN
        {
            get
            {
                objApperanceColor.Font = new System.Drawing.Font("Tahoma", 9F, FontStyle.Strikeout);
                objApperanceColor.ForeColor = Color.Gray;
                objApperanceColor.BackColor = Color.White;
                objApperanceColor.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;

                return objApperanceColor;
            }
        }

        #endregion


        /// 1. 메뉴 항목을 초기화(그리드뷰 초기화)
        /// 2. Child 노드 체크 상태를 표시한다.
        /// 3. Parent 노드 체크 상태를 표시한다.
        /// 4. Parent 노드를 체크 상태를 확인하고 저장합니다.
        /// 5. 자식 노드의 USEFLAG속성을 변경합니다.
        /// 6. 부모 노드의 USEFLAG속성을 변경합니다.
        /// 7. repositoryItem & 콤보박스 아이콘 이미지를 셋합니다.
        /// 8. RepositoryItem 콤바박스의 폼마스터 정보를 셋합니다.
        #region [Private Method]

        /// [1]
        /// <summary>
        /// 메뉴 항목을 초기화(그리드뷰 초기화)
        /// </summary>
        private void InitMenuLIst()
        {
            // 메뉴관련 프로시져 네임
            string Procname = "PKGSYS_MENU.GET_MENU";

            WSResults result = BASE_db.Execute_Proc( Procname
                                                   , 3
                                                   , new string[] { 
                                                     "A_CLIENT"
                                                   , "A_COMPANY"
                                                   , "A_PLANT"
                                                   , "A_SYSTEM"
                                                   , "A_USERROLE" }
                                                   , new string[] { 
                                                     Global.Global_Variable.CLIENT
                                                   , Global.Global_Variable.COMPANY
                                                   , Global.Global_Variable.PLANT
                                                   , Global.Global_Variable.SYSTEMCODE
                                                   , Global.Global_Variable.USERROLE }
                                                   );

            if (result.ResultInt != 0)
            {
                Class.iDATMessageBox.ShowProcResultMessage(result, this.Text, 5, Global.Global_Variable.USER_ID, Procname, null, null);
            }
            else
            {
                dtMenu = result.ResultDataSet.Tables[0];

                tl_Menu.ParentFieldName = "UPRSEQ";
                tl_Menu.KeyFieldName = "MENUSEQ";
                //tl_Menu.RowHeight = 50;
                tl_Menu.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowAlways;
                tl_Menu.DataSource = dtMenu;
                tl_Menu.OptionsView.ShowColumns = true;
                tl_Menu.OptionsBehavior.Editable = true;
                tl_Menu.Appearance.Row.Font = new Font("Tahoma", 9);
                tl_Menu.ExpandAll();
                tl_Menu.BestFitColumns();

                //tl_Menu.Columns["DISP_NO"].Visible = false;
                tl_Menu.Columns["DISPSEQ"].Visible = true;
                tl_Menu.Columns["IMGIDX"].Visible = true;
                tl_Menu.Columns["FORMPARAM"].Visible = true;
                tl_Menu.Columns["DISPFLAG"].Visible = true;
                tl_Menu.Columns["IMGIDX"].ColumnEdit = repositoryItemImageComboBox_ICON;
                tl_Menu.Columns["FORM"].ColumnEdit = repositoryItemComboBox_FORMMST;
                tl_Menu.Columns["DISPFLAG"].ColumnEdit = repositoryItemComboBox_USEYN;
                tl_Menu.Columns["USEFLAG"].ColumnEdit = repositoryItemComboBox_USEYN;
                tl_Menu.Columns["DISPSEQ"].SortOrder = SortOrder.Ascending;

                // 폼의 스타일을 지정합니다.
                SetStyleFormatCondition_CustomRootMenu(tl_Menu, "FORM", null, GetStyleFormatObjApperanceColor_Root);
                SetStyleFormatCondition_CustomRootMenu(tl_Menu, "USEFLAG", "N", GetStyleFormatObjApperanceColor_USEYN);

                tl_Menu.Columns["MENUNAME"].Width = 400;
                tl_Menu.Columns["FORMPARAM"].Width = 150;
                tl_Menu.Columns["FORMPARAM"].MinWidth = 150;
                tl_Menu.Columns["FORM"].Width = 150;
                tl_Menu.Columns["FORM"].MinWidth = 150;
                tl_Menu.Columns["USEFLAG"].MinWidth = 80;
                tl_Menu.Columns["DISPFLAG"].MinWidth = 80;
                tl_Menu.Columns["IMGIDX"].MinWidth = 150;
                tl_Menu.Cursor = Cursors.Hand;
            }
        }

        /// [2]
        /// <summary>
        /// Child 노드 체크 상태를 표시한다.
        /// </summary>
        /// <param name="node">node</param>
        /// <param name="check">check</param>
        private void SetCheckedChildNodes(TreeListNode node, CheckState check)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].CheckState = check;
                SetCheckedChildNodes(node.Nodes[i], check);
            }
        }

        /// [3]
        /// <summary>
        /// Parent 노드 체크 상태를 표시한다.
        /// </summary>
        /// <param name="node">node</param>
        /// <param name="check">Check</param>
        private void SetCheckedParentNodes(TreeListNode node, CheckState check)
        {
            if (node.ParentNode != null)
            {
                bool b = false;
                CheckState state;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    state = (CheckState)node.ParentNode.Nodes[i].CheckState;
                    if (!check.Equals(state))
                    {
                        b = !b;
                        break;
                    }
                }
                node.ParentNode.CheckState = b ? CheckState.Indeterminate : check;
                SetCheckedParentNodes(node.ParentNode, check);
            }
        }

        /// [4]
        /// <summary>
        /// Parent 노드를 체크 상태를 확인하고 저장합니다.
        /// </summary>
        /// <param name="node">node</param>
        /// <param name="check">Check</param>
        private void SetCheckedParentNodesSave(TreeListNode node)
        {
            if (node.ParentNode != null)
            {
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    if (node.ParentNode.Nodes[i].CheckState != CheckState.Unchecked)
                    {
                        node.GetValue("MENUNAME");
                    }
                }
                SetCheckedParentNodesSave(node.ParentNode);
            }
        }

        /// [5]
        /// <summary>
        /// 자식 노드의 USEFLAG속성을 변경합니다.
        /// </summary>
        /// <param name="node">노드</param>
        /// <param name="useFlag">UseFlag</param>
        private void SetChildNodeUseFlag(TreeListNode node, string useFlag)
        {

            if (node.Nodes.Count > 0)
            {
                node["USEFLAG"] = useFlag;

                foreach (TreeListNode t_node in node.Nodes)
                {
                    SetChildNodeUseFlag(t_node, useFlag);
                }
            }
            else
            {
                node["USEFLAG"] = useFlag;
            }

        }

        /// [6]
        /// <summary>
        /// 부모 노드의 USEFLAG속성을 변경합니다.
        /// </summary>
        /// <param name="node">노드</param>
        /// <param name="useFlag">사용유무</param>
        private void SetParentNodeUseFlag(TreeListNode node, string useFlag)
        {
            if (node.ParentNode != null)
            {
                if (useFlag == "Y")
                {
                    if (node.ParentNode["USEFLAG"].ToString() == "N")
                    {
                        node.ParentNode["USEFLAG"] = useFlag;
                    }
                    SetParentNodeUseFlag(node.ParentNode, useFlag);
                }
                else
                {
                    foreach (TreeListNode f_Node in node.ParentNode.Nodes)
                    {
                        if (f_Node["USEFLAG"].ToString() == "Y")
                        {
                            if (f_Node.ParentNode["USEFLAG"] + "" == "N")
                            {
                                f_Node.ParentNode["USEFLAG"] = "Y";
                            }
                            break;
                        }
                        else
                        {
                            f_Node.ParentNode["USEFLAG"] = "N";
                            SetParentNodeUseFlag(f_Node.ParentNode, useFlag);
                        }
                    }
                }
            }
        }

        /// [7]
        /// <summary>
        /// repositoryItem & 콤보박스 아이콘 이미지를 셋합니다.
        /// </summary>
        private void SetImageConllection()
        {
            imageComboBoxEdit_ICOIMAGE.Properties.Items.Clear();
            // 이미지 설정
            imageComboBoxEdit_ICOIMAGE.Properties.SmallImages = Program.frmM.imagesPage32;

            //repositoryItemImageComboBox_ICON.SmallImages = Program.frmM.imageList_16_16;
            repositoryItemImageComboBox_ICON.SmallImages = Program.frmM.imagesPage32;

            for (int i = 0; i < Program.frmM.imagesPage32.Images.Count; i++)
            {
                imageComboBoxEdit_ICOIMAGE.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(i, i));
                repositoryItemImageComboBox_ICON.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(i.ToString(), i));
            }
        }

        /// [8]
        /// <summary>
        /// RepositoryItem 콤바박스의 폼마스터 정보를 셋합니다.
        /// </summary>
        private void SetFormMasterRepositoryItemComboBox()
        {
            string procName = "PKGSYS_MENU.GET_FORMMST";

            WSResults _result = BASE_db.Execute_Proc( procName
                                                    , 1
                                                    , new string[] { 
                                                      "A_CLIENT"
                                                    , "A_COMPANY"
                                                    , "A_PLANT"
                                                    , "A_SYSTEM" }
                                                    , new string[] { 
                                                      Global.Global_Variable.CLIENT
                                                    , Global.Global_Variable.COMPANY
                                                    , Global.Global_Variable.PLANT
                                                    , Global.Global_Variable.SYSTEMCODE }
                                                    );

            repositoryItemComboBox_FORMMST.Items.Clear();
            repositoryItemComboBox_FORMMST.Items.Add("");

            if (_result.ResultDataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in _result.ResultDataSet.Tables[0].Rows)
                {
                    repositoryItemComboBox_FORMMST.Items.Add(dr["FORM"].ToString());
                }
            }
        }

        #endregion

        /// 1. AfterFocusNode Event
        /// 2. TreeList AfterCheckNode Event
        /// 3. TreeList BeforeCheckNode
        /// 4. AfterDragNode Event
        #region [TreeView Event]

        /// [1]
        /// <summary>
        /// AfterFocusNode Event
        /// </summary>
        private void tl_Menu_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node != null)
            {
                tl_SelectNode = e.Node;

                textEdit_SEQ_R.Text = e.Node.GetValue("MENUSEQ").ToString();
                textEdit_MenuCode_R.Text = e.Node.GetValue("FORM").ToString();
                textEdit_MenuNameLoc.Text = e.Node.GetValue("MENUNAME").ToString();
                radioGroup_UseYN.EditValue = e.Node.GetValue("USEFLAG").ToString() == "Y" ? true : false;
                imageComboBoxEdit_ICOIMAGE.SelectedIndex = Convert.ToInt16(e.Node.GetValue("IMGIDX").ToString() == "" ? "-1" : e.Node.GetValue("IMGIDX").ToString());
                layoutControlItem_iMAGEICON.Text = e.Node.GetValue("MENUNAME").ToString();
            }
            else
            {
                BASE_IDATLayoutUtil.DevControlsClear_LayoutControl(layoutControl1);
            }
        }

        /// [2]
        /// <summary>
        /// TreeList AfterCheckNode Event
        /// </summary>
        private void tl_Menu_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            SetCheckedChildNodes(e.Node, e.Node.CheckState);
            SetCheckedParentNodes(e.Node, e.Node.CheckState);
        }

        /// [3]
        /// <summary>
        /// TreeList BeforeCheckNode
        /// </summary>
        private void tl_Menu_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            //e.State = (e.PrevState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);
        }

        /// [4]
        /// <summary>
        /// AfterDragNode
        /// </summary>
        private void tl_Menu_AfterDragNode(object sender, NodeEventArgs e)
        {
            WSResults _result;
            string[] _arrPara;
            string[] _arrValue;

            if (dtMenu.GetChanges().Rows.Count > 0)
            {
                if (Class.iDATMessageBox.QuestionMessage(BASE_Language.GetMessageString("MSG010"), BASE_Language.GetMessageString("NOTICE")) == System.Windows.Forms.DialogResult.Yes)
                {
                    SaveButton_Click();
                    return;
                }
            }

            if (e.Node.ParentNode != null)
            {
                string tVal = e.Node.ParentNode["FORMCODE"].ToString();

                if (tVal.Length > 0)
                {
                    iDATMessageBox.WARNINGMessage(clsLan.GetMessageString("MSG018"), this.Text, 0);
                    InitMenuLIst();

                    tl_Menu.FocusedNode = tl_Menu.FindNodeByID(e.Node.Id);
                    return;
                }
            }

            string prevIndex = "1";

            if (e.Node.PrevNode != null)
            {
                int iTemp = Convert.ToInt16(e.Node["DISPSEQ"].ToString());
                int pTemp = Convert.ToInt16(e.Node.PrevNode["DISPSEQ"].ToString());

                if (iTemp > pTemp)
                {
                    pTemp = pTemp + 1;
                    prevIndex = pTemp.ToString();
                }
                else
                {
                    prevIndex = e.Node.PrevNode["DISPSEQ"].ToString();
                }
            }

            string parentIndex = "";

            if (e.Node.ParentNode != null)
            {
                parentIndex = e.Node.ParentNode["MENUSEQ"].ToString();

                // 추가된 PARENT NODE에 자식 노드를 추가하게 되면 PARENT NODE를 디비에 저장해서 SEQUENC번호를 받는다.
                if (parentIndex == "")
                {
                    if (iDATMessageBox.QuestionMessage("생성된 상위 메뉴는 저장이 됩니다. 하위 메뉴를 추가하시겠습니까?", "메뉴 추가") == DialogResult.No)
                    {
                        return;
                    }

                    string tprocName = "PKGSYS_MENU.PUT_MENU";

                    string tparentIndex = e.Node.ParentNode.ParentNode["MENUSEQUENCE"].ToString();
                    string tmenuName = tl_Menu.FocusedNode.ParentNode["MENUNAME"].ToString();
                    string tfrmcode = tl_Menu.FocusedNode.ParentNode["FORMCODE"].ToString();
                    string timgidx = tl_Menu.FocusedNode.ParentNode["IMAGEINDEX"].ToString();
                    string tdispIdx = tl_Menu.FocusedNode.ParentNode["DISPLAYSEQUENCE"].ToString();
                    string tdispflag = tl_Menu.FocusedNode.ParentNode["DISPLAYFLAG"].ToString();
                    string formparam = tl_Menu.FocusedNode.ParentNode["FORMPARAM"].ToString();

                    _arrPara = new string[] { "A_CLIENT"
                                            , "A_COMPANY"
                                            , "A_PLANT"
                                            , "A_SYSTEM"
                                            , "A_PARENTSEQ"
                                            , "A_MNUNAME"
                                            , "A_FRMCODE"
                                            , "A_FRMPARAM"
                                            , "A_IMGIDX"
                                            , "A_DISPIDX"
                                            , "A_DISPFLAG"
                                            , "A_REMARKS"
                                            , "A_USER"
                                            };

                    _arrValue = new string[] { Global.Global_Variable.CLIENT
                                             , Global.Global_Variable.COMPANY
                                             , Global.Global_Variable.PLANT
                                             , Global.Global_Variable.SYSTEMCODE
                                             , tparentIndex
                                             , tmenuName
                                             , tfrmcode
                                             , formparam
                                             , timgidx
                                             , tdispIdx
                                             , tdispflag
                                             , ""
                                             , Global.Global_Variable.USER_ID
                                             };

                    _result = BASE_db.Execute_Proc(tprocName, 1, _arrPara, _arrValue);

                    if (_result.ResultInt != 0)
                    {
                        iDATMessageBox.ShowProcResultMessage(_result, this.Text, 5, Global.Global_Variable.USER_ID, tprocName, _arrPara, _arrValue);
                    }
                    else
                    {
                        tl_Menu.FocusedNode.ParentNode["MENUSEQ"] = _result.ResultDataSet.Tables[0].Rows[0][0];
                        parentIndex = _result.ResultDataSet.Tables[0].Rows[0][0].ToString();
                    }
                }
            }
            else
            {
                parentIndex = "1";
            }

            string seq = e.Node["MENUSEQ"].ToString();

            string procName = "PKGSYS_MENU.PUT_MENU";

            string menuName = e.Node["MENUNAME"].ToString();
            string frmcode = e.Node["FORM"].ToString();
            string imgidx = e.Node["IMGIDX"].ToString();
            string dispflag = e.Node["DISPFLAG"].ToString();
            string useflag = e.Node["USEFLAG"].ToString();
            string remarks = e.Node["REMARKS"].ToString();
            string frmparam = e.Node["FORMPARAM"].ToString();

            _arrPara = new string[] { "A_CLIENT"
                                    , "A_COMPANY"
                                    , "A_PLANT"
                                    , "A_SYSTEM"
                                    , "A_PARENTSEQ"
                                    , "A_SEQ"
                                    , "A_MNUNAME"
                                    , "A_FRMCODE"
                                    , "A_FRMPARAM"
                                    , "A_IMGIDX"
                                    , "A_DISPIDX"
                                    , "A_DISPFLAG"
                                    , "A_REMARKS"
                                    , "A_USEFLAG"
                                    , "A_USER"
                                    };

            _arrValue = new string[] { Global.Global_Variable.CLIENT
                                     , Global.Global_Variable.COMPANY
                                     , Global.Global_Variable.PLANT
                                     , Global.Global_Variable.SYSTEMCODE
                                     , parentIndex
                                     , seq
                                     , menuName
                                     , frmcode
                                     , frmparam
                                     , imgidx
                                     , prevIndex
                                     , dispflag
                                     , remarks
                                     , useflag
                                     , Global.Global_Variable.USER_ID
                                    };

            _result = BASE_db.Execute_Proc(procName, 1, _arrPara, _arrValue);

            // 메뉴이동이 성공 되면 실시간으로 데이터를 업데이트 해준다.
            if (_result.ResultInt == 0)
            {
                InitMenuLIst();

                tl_Menu.FocusedNode = tl_Menu.FindNodeByID(e.Node.Id);
                //tl_Menu.FocusedNode = tl_Menu.FindNodeByID(e.Node.Id);

                // 메뉴를 재설정 합니다.
                Program.frmM.Set_MenuList();
            }
            else
            {
                iDATMessageBox.ShowProcResultMessage(_result, "Error", 5, Global.Global_Variable.USER_ID, procName, _arrPara, _arrValue);
                InitMenuLIst();
            }
        }

        #endregion

        /// 1. 종료 
        /// 2. 초기화
        /// 3. 확장
        /// 4. 축소
        /// 5. 저장
        #region [버튼 이벤트]


        /// [3]
        /// <summary>
        /// 노드 전체 확장
        /// </summary>
        private void btn_ExpendOn_Click(object sender, EventArgs e)
        {
            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode node in tl_Menu.Nodes)
            {
                node.Expanded = true;
            }
        }

        /// [4]
        /// <summary>
        /// 노드 전체 축소
        /// </summary>
        private void btn_ExpendOff_Click(object sender, EventArgs e)
        {
            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode node in tl_Menu.Nodes)
            {
                node.Expanded = false;
            }
        }

        #endregion

        /// <summary>
        /// Use Y/N을 변경했을때 발생하는 이벤트
        /// </summary>
        private void radioGroup_UseYN_EditValueChanged(object sender, EventArgs e)
        {
            if (radioGroup_UseYN.Focused)
            {
                if (tl_SelectNode != null)
                {
                    if (radioGroup_UseYN.SelectedIndex == 0) // Y
                    {
                        SetChildNodeUseFlag(tl_SelectNode, "Y");
                        SetParentNodeUseFlag(tl_SelectNode, "Y");
                    }
                    else // N
                    {
                        SetChildNodeUseFlag(tl_SelectNode, "N");
                        SetParentNodeUseFlag(tl_SelectNode, "N");
                    }
                }

                foreach (DataRow dr in dtMenu.Rows)
                {
                    if (dr.RowState == DataRowState.Modified)
                    {
                        Console.WriteLine(dr["MENUNAME"].ToString());
                    }
                }

                //clickFlg = false;
            }
        }

        /// <summary>
        /// 변경된 데이터의 노드 색을 변경합니다. tl_Menu_NodeCellStyle Event
        /// </summary>
        private void tl_Menu_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            foreach (DataRow dr in dtMenu.Rows)
            {
                if (dr.RowState == DataRowState.Modified)
                {
                    if (dr["MENUNAME"] == e.Node["MENUNAME"])
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
            }
        }

        #region [EditValueChanged]

        private void textEdit_MenuNameEng_EditValueChanged(object sender, EventArgs e)
        {
            if (tl_SelectNode["MENUNAME"].ToString() != textEdit_MenuNameLoc.Text)
            {
                tl_SelectNode["MENUNAME"] = textEdit_MenuNameLoc.Text;
            }
        }

        private void imageComboBoxEdit_ICOIMAGE_EditValueChanged(object sender, EventArgs e)
        {
            if (imageComboBoxEdit_ICOIMAGE.SelectedIndex != -1)
            {
                if (tl_SelectNode["IMGIDX"].ToString() != imageComboBoxEdit_ICOIMAGE.EditValue.ToString())
                {
                    tl_SelectNode["IMGIDX"] = imageComboBoxEdit_ICOIMAGE.EditValue.ToString();
                }
            }
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void tl_Menu_BeforeDragNode(object sender, BeforeDragNodeEventArgs e)
        {
            if (e.Node["MENUSEQ"].ToString() == "")
                e.CanDrag = false;
        }

        private void btnMainMenuRefresh_Click(object sender, EventArgs e)
        {
            //메뉴를 재설정 합니다.
            Program.frmM.Set_MenuList();
        }
    }
}

