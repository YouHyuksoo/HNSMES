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
    public partial class COMPROGRESS : Form
    {
        BackgroundWorker m_bgw = new BackgroundWorker();
        private string m_strDate;
        private decimal m_dblCount;
        private int m_iFunctionType;
        //
        public COMPROGRESS(int p_iFunctionType, string p_strDate, decimal p_dblCount)
        {
            InitializeComponent();
            //
            m_strDate = p_strDate;
            m_dblCount = p_dblCount;
            m_iFunctionType = p_iFunctionType;
            //
            m_bgw.DoWork += new DoWorkEventHandler(m_bgw_DoWork);
            m_bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(m_bgw_RunWorkerCompleted);
            m_bgw.ProgressChanged += new ProgressChangedEventHandler(m_bgw_ProgressChanged);
        }

        void m_bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            dgt.Text = e.UserState.ToString() + "/" + m_dblCount.ToString();
            prg.EditValue = e.ProgressPercentage;
        }

        void m_bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        void m_bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (m_iFunctionType)
            {
                case 1:
                    this.Make_WIPMaster(m_strDate, m_dblCount);
                    break;
            }
        }

        private void COMPROGRESS_Shown(object sender, EventArgs e)
        {
            m_bgw.WorkerReportsProgress = true;
            if (!m_bgw.IsBusy) m_bgw.RunWorkerAsync();
        }

        private void Make_WIPMaster(string p_strDate, decimal p_dblCount)
        {
        }
    }
}
