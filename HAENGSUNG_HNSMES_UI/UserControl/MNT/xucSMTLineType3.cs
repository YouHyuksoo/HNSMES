using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using DevExpress.XtraEditors;
using System.Threading.Tasks;

using HAENGSUNG_HNSMES_UI.WebService.Business;
using HAENGSUNG_HNSMES_UI.WebService.Access;
using Microsoft.VisualBasic.PowerPacks;
namespace HAENGSUNG_HNSMES_UI.UserControl.MNT
{
    public partial class xucSMTLineType3 : DevExpress.XtraEditors.XtraUserControl
    {
        private bool mSMT1Error = false;
        private bool mSMT2Error = false;

        private string mProdLine = "";
        private string mProdLineName = "";
        private DataTable mInfo = null;

        private int mSecond = 5;

        private delegate void TextEditEventHandler(TextEdit _Text, object _Message);

        private delegate void RectangleShapeEventHandler(RectangleShape _Shape, PictureEdit _Pic, Point _Location, Size _Size, bool _Visible);
        private delegate void PictureEditEventHandler(PictureEdit _Pic);

        public DataTable Info
        {
            get
            {
                return mInfo;
            }
            set
            {
                if (mInfo == value)
                    return;
                mInfo = value;

                SetInit();
            }
        }

        public string ProdLine
        {
            get
            {
                return mProdLine;
            }
            set
            {
                if (mProdLine == value)
                    return;
                mProdLine = value;

                if (mProdLine != null)
                {
                    SetData();
                }
            }
        }

        public string ProdLineName
        {
            get
            {
                return mProdLineName;
            }
            set
            {
                if (mProdLineName == value)
                    return;
                mProdLineName = value;

                lblProdLine.Text = mProdLineName;
                lblProdLine.Location = new Point((this.Width / 2) - (lblProdLine.Width / 2), lblProdLine.Location.Y);
            }
        }

        public bool SMT1Error
        {
            get
            {
                return mSMT1Error;
            }
            set
            {
                if (mSMT1Error == value)
                    return;
                mSMT1Error = value;

                if (mSMT1Error) bgwSMT1.RunWorkerAsync();
                else bgwSMT1.CancelAsync();
            }
        }
        public bool SMT2Error
        {
            get
            {
                return mSMT2Error;
            }
            set
            {
                if (mSMT1Error) bgwSMT1.RunWorkerAsync();
                else bgwSMT1.CancelAsync();
            }
        }

        private void TextEditEvent(TextEdit _Text, object _Message)
        {
            _Text.EditValue = _Message;
        }

        public xucSMTLineType3()
        {
            InitializeComponent();
        }

        public void StartMonitoring()
        {
            pbcMain.Position = mSecond;
            pbcMain.Properties.Maximum = 5;
            rsSMT1.BringToFront();
            rsSMT2.BringToFront();
            tmrRefresh.Start();
        }

        public void StopMonitoring()
        {
            tmrRefresh.Stop();
            if (bgwSMT1.IsBusy) bgwSMT1.CancelAsync();
            //if (bgwSMT2.IsBusy) bgwSMT2.CancelAsync();
            if (bgwRefresh.IsBusy) bgwRefresh.CancelAsync();
        }

        private void SetInit()
        {
            Control[] controls = GetAllControls(this);

            foreach (Control ctl in controls)
            {
                DataRow[] dr = mInfo.Select("UNITNO = " + ctl.Name.Replace("picSMT",""));
                if (dr != null)
                {
                    if (dr.Length > 0)
                    {
                        txtOrdQty.EditValue = dr[0]["ORDQTY"];
                        txtProdQty.EditValue = dr[0]["PRODQTY"];

                        if (ctl.Name.Replace("picSMT", "") == "1")
                        {
                            txtMissRate1.EditValue = dr[0]["MISSRATE"] + "% / " + dr[0]["PICKUPRATE"] + "%";
                        }
                        //else if (ctl.Name.Replace("picSMT", "") == "2")
                        //{
                        //    txtMissRate2.EditValue = dr[0]["MISSRATE"] + "% / " + dr[0]["PICKUPRATE"] + "%";
                        //}
                    }
                }
            }
        }

        private void SetData()
        {
            WCFDatabaseProcess db = new WCFDatabaseProcess();
            WSResults result = db.Execute_Proc("PKGPRD_MNT.GET_PRODLINE",
                                                        1,
                                                        new string[] {
                                                            "A_PRODLINE"
                                                        },
                                                        new string[] {
                                                            mProdLine
                                                        });
            if (result.ResultInt == 0)
            {
                foreach (DataRow dr in result.ResultDataSet.Tables[0].Rows)
                {
                    if (dr["UNITNO"] + "" == "1")
                    {
                        if (txtModel.InvokeRequired) txtModel.Invoke(new TextEditEventHandler(TextEditEvent), txtModel, dr["PARTNO"]);
                        if (txtOrdQty.InvokeRequired) txtOrdQty.Invoke(new TextEditEventHandler(TextEditEvent), txtOrdQty, dr["ORDQTY"]);
                        if (txtProdQty.InvokeRequired) txtProdQty.Invoke(new TextEditEventHandler(TextEditEvent), txtProdQty, dr["PRODQTY"]);
                        if (txtMissRate1.InvokeRequired) txtMissRate1.Invoke(new TextEditEventHandler(TextEditEvent), txtMissRate1, dr["MISSRATE"] + "%/" + dr["PICKUPRATE"] + "%");

                        if (dr["LOCKFLAG"] + "" == "Y" || dr["ISSTKERR"] + "" == "Y")
                        {
                            if (dr["LOCKFLAG"] + "" == "Y") rsSMT1.FillColor = Color.Red;
                            if (dr["ISSTKERR"] + "" == "Y") rsSMT1.FillColor = Color.DarkOrange;

                            if (!bgwSMT1.IsBusy) bgwSMT1.RunWorkerAsync();
                        }
                        else
                        {
                            if (bgwSMT1.IsBusy) bgwSMT1.CancelAsync();
                            rsSMT1.Location = new Point(rsSMT1.Location.X, this.Height);
                            if (picSMT1.InvokeRequired) picSMT1.Invoke(new PictureEditEventHandler(PictureEditEvent), picSMT1);
                        }
                    }
                    //else if (dr["UNITNO"] + "" == "2")
                    //{
                    //    if (txtMissRate2.InvokeRequired) txtMissRate2.Invoke(new TextEditEventHandler(TextEditEvent), txtMissRate2, dr["MISSRATE"] + "%/" + dr["PICKUPRATE"] + "%");

                    //    if (dr["LOCKFLAG"] + "" == "Y" || dr["ISSTKERR"] + "" == "Y")
                    //    {
                    //        if (!bgwSMT2.IsBusy) bgwSMT2.RunWorkerAsync();
                    //    }
                    //    else
                    //    {
                    //        if (bgwSMT2.IsBusy) bgwSMT2.CancelAsync();
                    //    }
                    //}
                }
            }
        }

        private Control[] GetAllControls(Control containerControl)
        {
            List<Control> allControls = new List<Control>();
            Queue<Control.ControlCollection> queue = new Queue<Control.ControlCollection>();
            queue.Enqueue(containerControl.Controls);

            Task task = new Task(() =>
            {
                while (queue.Count > 0)
                {
                    Control.ControlCollection controls = (Control.ControlCollection)queue.Dequeue();
                    if (controls == null || controls.Count == 0) continue;

                    foreach (Control control in controls)
                    {
                        if (control.Name.IndexOf("picSMT") > -1)
                        {
                            allControls.Add(control);
                        }

                        queue.Enqueue(control.Controls);
                    }
                }
            });

            task.Start();
            task.Wait();

            return allControls.ToArray();
        }

        private void picSMT1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void picSMT2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bgwSMT2_DoWork(object sender, DoWorkEventArgs e)
        {
            bool bReverse = true;

            //rsSMT2.BringToFront();

            while (!bgwSMT2.CancellationPending)
            {
                //rsSMT2.Location = picSMT2.Location;
                //rsSMT2.Size = picSMT2.Size;
                //rsSMT2.Visible = bReverse;
                //if (this.InvokeRequired) this.Invoke(new RectangleShapeEventHandler(RectangleShapeEvent), rsSMT2, picSMT2, picSMT2.Location, picSMT2.Size, bReverse);

                bReverse = !bReverse;

                Thread.Sleep(1000);
            }

            //rsSMT2.Visible = false;
        }

        private void bgwSMT1_DoWork(object sender, DoWorkEventArgs e)
        {
            bool bReverse = true;

            while (!bgwSMT1.CancellationPending)
            {
                try
                {
                    if (this.InvokeRequired) this.Invoke(new RectangleShapeEventHandler(RectangleShapeEvent), rsSMT1, picSMT1, picSMT1.Location, picSMT1.Size, bReverse);
                }
                catch { }

                bReverse = !bReverse;

                Thread.Sleep(1000);
            }
        }

        private void RectangleShapeEvent(RectangleShape _Shape, PictureEdit _Pic, Point _Location, Size _Size, bool _Visible)
        {
            _Shape.Location = _Location;
            _Shape.Size = _Size;
            _Shape.Visible = _Visible;
            _Shape.BringToFront();
            _Shape.Refresh();
            _Pic.SendToBack();
            _Pic.Refresh();
        }

        private void PictureEditEvent(PictureEdit _Pic)
        {
            _Pic.Refresh();
        }

        private void bgwRefresh_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                SetData();
            }
            catch { }
        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            lblSecond.Text = mSecond.ToString() + " sec";

            mSecond--;
            
            if (mSecond == 0)
            {
                if (!bgwRefresh.IsBusy) bgwRefresh.RunWorkerAsync();

                mSecond = 5;

                lblSecond.Text = mSecond.ToString() + " sec";
            }

            pbcMain.Position = mSecond;
        }
    }
}
