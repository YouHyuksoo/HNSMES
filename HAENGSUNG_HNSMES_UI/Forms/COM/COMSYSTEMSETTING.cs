using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HAENGSUNG_HNSMES_UI.Class;

namespace HAENGSUNG_HNSMES_UI.Forms.COM
{
    public partial class COMSYSTEMSETTING : BASE.Form
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public COMSYSTEMSETTING()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 닫기 버튼 이벤트
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGridLayoutInit_Click(object sender, EventArgs e)
        {
            if (iDATMessageBox.QuestionMessage("전체 그리드 레이아웃을 초기화 하시겠습니까?", "설정") == DialogResult.Yes)
            {
                IDAT.Devexpress.GRID.IDATDevExpress_GridControl util = new IDAT.Devexpress.GRID.IDATDevExpress_GridControl();
                util.InitialGridLayout();
            }
        }

        private void COMSYSTEMSETTING_Load(object sender, EventArgs e)
        {
            chkFavorites.Checked = Settings_IDAT.Default.Use_Favorites;
            comboBoxEdit1.Text = Settings_IDAT.Default.WINSTYLE;
        }

        private void chkFavorites_CheckedChanged(object sender, EventArgs e)
        {
            Settings_IDAT.Default.Use_Favorites = chkFavorites.Checked;
            Settings_IDAT.Default.Save();
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings_IDAT.Default.WINSTYLE = comboBoxEdit1.EditValue.ObjectNullString();
            Settings_IDAT.Default.Save();
        }
    }
}
