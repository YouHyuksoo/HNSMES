using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HAENGSUNG_HNSMES_UI.UserControl.COM
{
    public partial class TreePopup : Form
    {
        #region 전역변수

        private int m_iTop;
        private int m_iLeft;
        private int m_iWidth;

        public HAENGSUNG_HNSMES_UI.UserControl.COM.TreeEdit m_TreeEdit;

        #endregion

        public TreePopup(int p_iTop, int p_iLeft, int p_iWidth, HAENGSUNG_HNSMES_UI.UserControl.COM.TreeEdit p_TreeEdit)
        {
            InitializeComponent();
            //최대화
            layoutControl1.Dock = DockStyle.Fill;
            //팝업 위치
            m_iTop = p_iTop;//
            m_iLeft = p_iLeft;
            m_iWidth = p_iWidth;
            m_TreeEdit = p_TreeEdit;
            //
            treeDept.OptionsView.EnableAppearanceEvenRow = true;
        }

        private void picClose_EditValueChanged(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TreePopup_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TreePopup_Load(object sender, EventArgs e)
        {
            this.Set_Data(); //소속 셋팅
            //위치조절 및 크기 조절
            if (m_iTop + this.Height > Program.frmM.Location.Y + Program.frmM.Height)
            {
                m_iTop = m_iTop - this.Height - 20;
                
            }
            this.Top = m_iTop;
            if (this.Width < m_iWidth) this.Width = m_iWidth; //가로 크기 조절
            this.Left = m_iLeft;
        }


        #region 함수

        private void Set_Data()
        {
            if (m_TreeEdit.m_dt == null) return;

            treeDept.ParentFieldName = m_TreeEdit.m_strParentFieldName;
            treeDept.KeyFieldName = m_TreeEdit.m_strKeyFieldName;
            treeDept.ImageIndexFieldName = m_TreeEdit.m_strImageIndexFieldName;
            treeDept.DataSource = m_TreeEdit.m_dt;
            //
            if (m_TreeEdit.m_strTreeColumn != "")
            {
                string _strColumnName = "," + m_TreeEdit.m_strTreeColumn + ",";
                for (int i = 0; i<treeDept.Columns.Count; i++)
                {
                    if (_strColumnName.IndexOf("," + treeDept.Columns[i].FieldName + ",") >= 0)
                    {
                        treeDept.Columns[i].Visible = true;
                    }
                    else
                    {
                        treeDept.Columns[i].Visible = false;
                    }
                }
            }
            //
            treeDept.ExpandAll();
        }


        private void Set_Focus(DevExpress.XtraTreeList.TreeListHitInfo hi)
        {
            //================================
            //트리 아이템에 포커스 보내기
            //================================
            treeDept.SetFocusedNode(hi.Node);
        }

        private void Set_Text(DevExpress.XtraTreeList.TreeListHitInfo hi)
        {
            //================================
            //콘트롤로 데이터 넘기기
            //================================
            if (hi.Node == null) return;
            
            m_TreeEdit.EditValue = hi.Node.GetValue(m_TreeEdit.Properties.ValueMember);
            this.Close();
        }

        #endregion


        # region 이벤트

        private void treeDept_MouseMove(object sender, MouseEventArgs e)
        {
            //================================
            //마우스 가는곳에 포커스 가도록
            //================================
            if (e.Y > treeDept.Height - 30) return; //마지막 라인은 포커스 안감
            if (e.Y < 40) return; //헤더에는 포커스 안감
            if (e.X < 40) return;
            Set_Focus(treeDept.CalcHitInfo(new Point(e.X, e.Y)));
        }

        private void treeDept_MouseClick(object sender, MouseEventArgs e)
        {
            this.Set_Text(treeDept.CalcHitInfo(new Point(e.X, e.Y)));
        }

        #endregion

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
