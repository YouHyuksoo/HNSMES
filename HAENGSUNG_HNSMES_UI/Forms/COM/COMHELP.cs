using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HAENGSUNG_HNSMES_UI.Forms.COM
{
    public partial class COMHELP : DevExpress.XtraEditors.XtraForm
    {
        public COMHELP()
        {
            InitializeComponent();
        }
        public COMHELP(int sizeX, int sizeY, Image img)
        {
            InitializeComponent();

            this.Width = 1000;// sizeX;
            this.Height = 800;// sizeY;
            
            pnlImage.BackgroundImage = img;
        }
    }
}