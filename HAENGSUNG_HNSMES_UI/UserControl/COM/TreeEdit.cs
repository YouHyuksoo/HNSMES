using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace HAENGSUNG_HNSMES_UI.UserControl.COM
{
    public partial class TreeEdit : DevExpress.XtraEditors.GridLookUpEdit
    {
        #region 전역변수

        public DataTable m_dt;
        public string m_strParentFieldName;
        public string m_strKeyFieldName;
        public string m_strImageIndexFieldName;
        public string m_strTreeColumn;

        #endregion

        #region 생성

        public TreeEdit()
        {
            InitializeComponent();
            //
            this.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(TreeEdit_ButtonClick);
            this.MouseClick += new MouseEventHandler(TreeEdit_MouseClick);
        }

        public TreeEdit(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            //
            this.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(TreeEdit_ButtonClick);
            this.MouseClick += new MouseEventHandler(TreeEdit_MouseClick);
            this.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.NewfProperties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            
            //this.Enabled = false;
            //this.Properties.ReadOnly = true;
            //
            this.Properties.Buttons[0].Visible = false;
        }

        #endregion

        #region 속성

        public object DataSource
        {
            get
            {
                return m_dt;
            }
            set
            {
                if (value is DataTable)
                {
                    m_dt = (DataTable)value;
                    this.Properties.DataSource = value;
                    this.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
                    //this.NewfProperties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
                    this.Properties.Buttons[0].Visible = false;
                }
                else
                {
                    
                }
            }
        }

        public string TreeColumn
        {
            get
            {
                return m_strTreeColumn;
            }
            set
            {
                m_strTreeColumn = value;
            }
        }

        public string ImageIndexFieldName
        {
            get
            {
                return m_strImageIndexFieldName;
            }
            set
            {
                m_strImageIndexFieldName = value;
            }
        }

        public string KeyFieldName
        {
            get
            {
                return m_strKeyFieldName;
            }
            set
            {
                m_strKeyFieldName = value;
            }
        }

        public string ParentFieldName
        {
            get
            {
                return m_strParentFieldName;
            }
            set
            {
                m_strParentFieldName = value;
            }
        }

        #endregion

        #region 이벤트
        
        private void TreeEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //this.Properties.ShowDropDown = false;
            if ((e.Button.Tag + "").ToUpper() == "INIT")
            {
                this.EditValue = null;
            }
            else
            {
                this.Show_PopUp();
            }
        }

        private void TreeEdit_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X > this.Width - 40)
            {
                //this.DEPARTMENTCODE = "";
            }
            else
            {
                this.Show_PopUp();
            }
        }

        #endregion

        #region 함수

        private void Show_PopUp()
        {
            if (this.Properties.ReadOnly) return;
            //
            int _iTop = 0;
            int _iLeft = 0;
            int _iWidth = this.Width;

            _iTop = this.PointToScreen(this.Location).Y - this.Top + this.Height;// this.PointToScreen(e.Location).Y;//this.ParentForm.PointToScreen(e.Location).Y;
            _iLeft = this.PointToScreen(this.Location).X - this.Left; //this.ParentForm.PointToScreen(e.Location).X;

            TreePopup _frm = new TreePopup(_iTop, _iLeft, _iWidth, this);//, m_dt, m_strParentFieldName, m_strKeyFieldName, m_strImageIndexFieldName);
            _frm.Show(this);
        }

        #endregion
    }
}
