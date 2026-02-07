using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

// DevExpress namespace
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

// User namespace
using HAENGSUNG_HNSMES_UI.Class;

using GridAlias = DevExpress.XtraGrid.Views.Grid;
using HAENGSUNG_HNSMES_UI.WebService.Access;

namespace HAENGSUNG_HNSMES_UI.Forms.SYS 
{
    ///<summary>
    ///==========================================================<br/>
    ///    화면명 : SYSA207<br/>
    ///      기능 : 메뉴 권한 마스터 <br/>
    ///      작성 : 행성사 정보전략팀<br/>
    ///최초작성일 : 2018-04-01<br/>
    ///  수정사항 : 최초작성<br/>
    ///==========================================================
    ///</summary>
    public partial class SYSA207 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, HAENGSUNG_HNSMES_UI.Class.itfButton
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

        public SYSA207()
        {
            InitializeComponent();
        }
        private void SYSA207_Load(object sender, EventArgs e)
        {
            InitClssDataList();
            InitButton_Click();
            MainButton_Save.IsUse = true;
        }
        

        #endregion

        #region 버튼이벤트

        public void InitButton_Click()
        {
            InitClssDataList();

            if (gvList.GetFocusedDataRow() != null)
            {
                string _ClassCode = ((gvList.GetFocusedDataRow()["USERROLE"]) + "").Trim();

                if (_ClassCode != "")
                {
                    InitMenuList(_ClassCode);
                }
            }
        }

        public void DeleteButton_Click()
        {
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
        }

        public void SaveButton_Click()
        {
            tlMenu.MoveFirst();

            //((DataTable)tlMenu.DataSource).AcceptChanges();
            // GridView ClassCode 정보를 가져옵니다.
            string _sClassCode = ((gvList.GetFocusedDataRow()["USERROLE"]) + "").Trim();
            string _sFormClass = "";
            string _sRemarks = "";
            string _ProcName = "PKGSYS_MENU.PUT_MENUROLE";
            string _strMenuSeq = ""; // 20,21,23

            Dictionary<string, object> param = new Dictionary<string, object>();

            ArrayList _aryNodeCheck = new ArrayList();
            _aryNodeCheck.Clear();

            GetCheckNode(tlMenu.Nodes, ref _aryNodeCheck);

            // 체크된 메뉴가 존재하면
            if (_aryNodeCheck.Count > 0)
            {
                foreach (DevExpress.XtraTreeList.Nodes.TreeListNode node in _aryNodeCheck)
                {
                    _strMenuSeq += node.GetValue("MENUSEQ").ToString() + ",";
                    _sFormClass += node.GetValue("FORMROLE").ToString() + ",";
                    _sRemarks += node.GetValue("REMARKS").ToString() + ",";
                }
                _strMenuSeq = _strMenuSeq.Remove(_strMenuSeq.Length - 1);
                _sFormClass = _sFormClass.Remove(_sFormClass.Length - 1);
                _sRemarks = _sRemarks.Remove(_sRemarks.Length - 1);
            }
            else
            {
                _strMenuSeq = string.Empty;
                _sFormClass = string.Empty;
                _sRemarks = string.Empty;
            }

            param.Clear();

            param.Add("A_CLIENT", Global.Global_Variable.CLIENT);
            param.Add("A_COMPANY", Global.Global_Variable.COMPANY);
            param.Add("A_PLANT", Global.Global_Variable.PLANT);
            param.Add("A_SYSTEM", Global.Global_Variable.SYSTEMCODE);
            param.Add("A_USERROLE", _sClassCode);
            param.Add("A_MENUSEQ", _strMenuSeq);
            param.Add("A_FORMROLE", _sFormClass);
            param.Add("A_OPERATOR", Global.Global_Variable.USER_ID);

            WSResults result = BASE_db.Execute_Proc(_ProcName, 1, param);

            iDATMessageBox.ShowProcResultMessage(result, this.Text, Global.Global_Variable.USER_ID, _ProcName, param);

            if (result.ResultInt == 0)
            {
                // 메뉴를 재설정 합니다.
                Program.frmM.Set_MenuList();
            }
        }

        public void PrintButton_Click()
        {
        }

        public void RefreshButton_Click()
        {
        }

        private void btnExpendOn_Click(object sender, EventArgs e)
        {


            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode node in tlMenu.Nodes)
            {
                node.Expanded = true;
            }
        }

        private void btnExpendOff_Click(object sender, EventArgs e)
        {
            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode node in tlMenu.Nodes)
            {
                node.Expanded = false;
            }
        }

        #endregion

        #region TreeList Event

        /// [1]
        /// <summary>
        /// AfterCheckNode 이벤트
        /// </summary>
        private void tl_Menu_AfterCheckNode(object sender, NodeEventArgs e)
        {
            SetCheckedChildNodes(e.Node, e.Node.CheckState);
            SetCheckedParentNodes(e.Node, e.Node.CheckState);
        }

        /// [2]
        /// <summary>
        /// BeforeCheckNode 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tl_Menu_BeforeCheckNode(object sender, CheckNodeEventArgs e)
        {
            e.State = (e.PrevState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);
        }

        /// <summary>
        /// NodeChanged Event
        /// </summary>
        private void tlMenu_NodeChanged(object sender, NodeChangedEventArgs e)
        {
            if (e.ChangeType == NodeChangeTypeEnum.Add)
            {
                if (e.Node.GetValue("USEFLAG").ToString() == "Y")
                {
                    e.Node.Checked = true;
                }
                else
                {
                    e.Node.Checked = false;
                }
            }
        }

        #endregion

        #region GridView Event
        /// [1]
        /// <summary>
        /// FocusedRowChanged Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0 && e.FocusedRowHandle < gvList.RowCount)
            {
                string _ClassCode = ((gvList.GetFocusedDataRow()["USERROLE"]) + "").Trim();

                if (_ClassCode != "")
                {
                    InitMenuList(_ClassCode);
                }
            }
        }

        #endregion

        #region 함수

        /// [1]
        /// <summary>
        /// 메뉴 정보를 모두 초기화 합니다.
        /// </summary>
        private void InitClssDataList()
        {

            // 메뉴관련 프로시져 네임
            string _Procname = "PKGSYS_USER.GET_ROLE";
            Dictionary<string, object> param = new Dictionary<string, object>();

            param.Clear();

            param.Add("A_CLIENT", Global.Global_Variable.CLIENT);
            param.Add("A_COMPANY", Global.Global_Variable.COMPANY);
            param.Add("A_PLANT", Global.Global_Variable.PLANT);
            param.Add("A_SYSTEM", Global.Global_Variable.SYSTEMCODE);
            param.Add("A_VIEW", 0);

            WSResults _result = BASE_db.Execute_Proc(_Procname, 1, param);

            if (_result.ResultInt != 0)
            {
                iDATMessageBox.ShowProcResultMessage(_result, this.Text, Global.Global_Variable.USER_ID, _Procname, param);
            }
            else
            {
                //gcList.DataSource = _result.ResultDataSet.Tables[0].DefaultView;
                BASE_DXGridHelper.Bind_Grid( gcList
                                           , _result.ResultDataSet.Tables[0]
                                           , false
                                           , "USEFLAG"
                                           , false
                                           );
            }
        }

        /// [2]
        /// <summary>
        /// 사용자 클래스 정보를 데이터 그리드에 초기화 합니다.
        /// </summary>
        private void InitMenuList(string p_classCode)
        {
            tlMenu.ClearNodes();
            // 메뉴관련 프로시져 네임
            string _Procname = "PKGSYS_MENU.GET_MENUROLE";
            Dictionary<string, object> param = new Dictionary<string, object>();

            param.Add("A_CLIENT", Global.Global_Variable.CLIENT);
            param.Add("A_COMPANY", Global.Global_Variable.COMPANY);
            param.Add("A_PLANT", Global.Global_Variable.PLANT);
            param.Add("A_SYSTEM", Global.Global_Variable.SYSTEMCODE);
            param.Add("A_USERROLE", p_classCode);

            WSResults result = BASE_db.Execute_Proc(_Procname, 1, param);

            if (result.ResultInt != 0)
            {
                iDATMessageBox.ShowProcResultMessage(result, this.Text, Global.Global_Variable.USER_ID, _Procname, param);
                return;
            }

            tlMenu.OptionsBehavior.Editable = false;
            tlMenu.OptionsView.ShowColumns = false;
            tlMenu.ParentFieldName = "UPRSEQ";
            tlMenu.KeyFieldName = "MENUSEQ";
            tlMenu.RowHeight = 30;
            tlMenu.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowForFocusedRow;
            tlMenu.OptionsView.ShowCheckBoxes = true;
            tlMenu.OptionsBehavior.Editable = true;

            tlMenu.DataSource = result.ResultDataSet.Tables[0].DefaultView;

            tlMenu.Appearance.Row.Font = new Font("Tahoma", 9);
            tlMenu.PopulateColumns();
            tlMenu.ExpandAll();
            tlMenu.Columns["FORM"].Visible = false;
            tlMenu.Columns["USEFLAG"].Visible = false;
            tlMenu.Columns["FORMPARAM"].Visible = false;
            tlMenu.Columns["IMGIDX"].Visible = false;
            tlMenu.Columns["DISPFLAG"].Visible = false;
            tlMenu.Columns["PERENT_MENU"].Visible = false;
            tlMenu.Columns["SUB_NO"].Visible = false;

            tlMenu.Columns["FORM"].OptionsColumn.AllowEdit = false;
            tlMenu.Columns["USEFLAG"].OptionsColumn.AllowEdit = false;
            tlMenu.Columns["FORMPARAM"].OptionsColumn.AllowEdit = false;
            tlMenu.Columns["IMGIDX"].OptionsColumn.AllowEdit = false;
            tlMenu.Columns["DISPFLAG"].OptionsColumn.AllowEdit = false;

            tlMenu.Columns["MENUNAME"].OptionsColumn.AllowEdit = false;
            tlMenu.Columns["NATGLSR"].OptionsColumn.AllowEdit = false;
            tlMenu.Columns["KORGLSR"].OptionsColumn.AllowEdit = false;

            //tlMenu.Columns["DISPSEQ"].SortOrder = SortOrder.Ascending;
            //tlMenu.Columns["DISPSEQ"].Visible = false;

            DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup repository1 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            DevExpress.XtraEditors.Controls.RadioGroupItem rdg1 = new DevExpress.XtraEditors.Controls.RadioGroupItem();
            rdg1.Description = "Read Only";
            rdg1.Value = "R";
            repository1.Items.Add(rdg1);

            DevExpress.XtraEditors.Controls.RadioGroupItem rdg2 = new DevExpress.XtraEditors.Controls.RadioGroupItem();
            rdg2.Description = "Read / Write";
            rdg2.Value = "W";
            repository1.Items.Add(rdg2);

            tlMenu.Columns["FORMROLE"].ColumnEdit = repository1;

            tlMenu.BestFitColumns();

            tlMenu.Cursor = Cursors.Hand;
        }

        /// [3]
        /// <summary>
        /// ChildNode를 선택
        /// </summary>
        /// <param name="node">노드</param>
        /// <param name="check">체크상태</param>
        private void SetCheckedChildNodes(TreeListNode node, CheckState check)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].CheckState = check;
                SetCheckedChildNodes(node.Nodes[i], check);
            }
        }

        /// [4]
        /// <summary>
        /// ParentNode 선택
        /// </summary>
        /// <param name="node">노드</param>
        /// <param name="check">체크상태</param>
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

        /// [5]
        /// <summary>
        /// 메뉴리스트의 체크정보를 가져옵니다.
        /// </summary>
        /// <param name="nodes">노드</param>
        /// <param name="aryMenucodes">체크된 노드 배열</param>
        private void GetCheckNode(DevExpress.XtraTreeList.Nodes.TreeListNodes nodes, ref ArrayList aryMenucodes)
        {
            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode node in nodes)
            {
                Console.WriteLine(string.Format("{0} -- {1}", node.GetValue("MENUNAME").ToString(), node.GetValue("MENUSEQ").ToString()));
                if (node.Nodes.Count > 0)
                {
                    GetCheckNode(node.Nodes, ref aryMenucodes);

                    if (node.Checked || node.CheckState == CheckState.Indeterminate)
                    {
                        aryMenucodes.Add(node);
                    }

                }
                else
                {
                    if (node.Checked || node.CheckState == CheckState.Indeterminate)
                    {
                        aryMenucodes.Add(node);
                    }
                }
            }
        }

        #endregion

        private void tlMenu_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {

        }

        private void tlMenu_CustomNodeCellEdit(object sender, GetCustomNodeCellEditEventArgs e)
        {
            if (e.Column.FieldName != "REMARKS") return;
            if (tlMenu.GetDataRecordByNode(e.Node) == null) return;
        }

        private void tlMenu_ShowingEditor(object sender, CancelEventArgs e)
        {
        }
    }
}
