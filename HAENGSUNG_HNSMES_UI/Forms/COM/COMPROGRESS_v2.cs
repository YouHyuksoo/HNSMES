using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HAENGSUNG_HNSMES_UI.Forms.COM
{
    public partial class COMPROGRESS_v2 : XtraForm
    {
        IDAT.WebService.clsWSFile wsFileClient = null;
        System.IO.Stream FileStream = null;
        Timer tmrState = new Timer();

        #region [Constructor]

        public COMPROGRESS_v2()
        {
            InitializeComponent();

            wsFileClient = new IDAT.WebService.clsWSFile(Settings_IDAT.Default.WS_Address);

            tmrState.Interval = 100;
            tmrState.Tick += new EventHandler(tmrState_Tick);
            tmrState.Start();
        }

        public COMPROGRESS_v2(string filepath, string newfilename, string Tag)
            : this()
        {
            try
            {
                FileStream = System.IO.File.Open(filepath, System.IO.FileMode.Open, System.IO.FileAccess.Read);

                textEdit1.Text = Settings_IDAT.Default.WS_Address;
                textEdit2.Text = filepath;
            }
            catch (Exception ex)
            {
                Class.iDATMessageBox.ErrorMessage(ex, 5, Global.Global_Variable.USER_ID, "", null);
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }

            wsFileClient.ChunkSize = 20000;
            wsFileClient.SourceStream = FileStream;
            wsFileClient.Tag = Tag;
            wsFileClient.DestinationFileName = newfilename;
            wsFileClient.Uploaded += new IDAT.WebService.clsWSFile.UploadedEventHandler(wsFileClient_Uploaded);
            wsFileClient.Sending += new IDAT.WebService.clsWSFile.SendingEventHandler(wsFileClient_Sending);
        }

        #endregion

        void wsFileClient_Uploaded(object sender, string val)
        {
            FileStream.Close();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        void wsFileClient_Sending(object sender, IDAT.WebService.WSFileSendEventArgs e)
        {
            textEdit_state.Text = "Sending " + e.ChunkNumber.ToString() + " of " + e.TotalChunks.ToString();
            progressBarControl1.EditValue = e.PercentComplete;
        }

        int stateVal = 0;

        void tmrState_Tick(object sender, EventArgs e)
        {
            try
            {
                linearScaleComponent1.Value = stateVal * 10;

                stateVal = stateVal + 1;

                if (stateVal > 10)
                {
                    stateVal = 0;
                }
            }
            catch (Exception) { }
        }

        private void COMPROGRESS_v2_Load(object sender, EventArgs e)
        {

        }

        private void COMPROGRESS_v2_Shown(object sender, EventArgs e)
        {
            // 업로드를 시작합니다.
            try
            {
                wsFileClient.Upload();
            }
            catch (Exception)
            {
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
        }
    }
}