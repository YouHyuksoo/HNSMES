using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using IDAT.Devexpress.ActionDemo;
using System.Drawing;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars.Ribbon.ViewInfo;

namespace HAENGSUNG_HNSMES_UI.Base.Class.ActiveDemo
{
    class ActiveDemoBusiness
    {
        public void RunDemo(ActiveGridDemo activeDemo, Control form)
        {
            Control control = null;
            Point point = new Point();

            DataTable orders = getDateSet(Application.StartupPath + "\\XML_FILES\\CreateXML.xml", form.Name);

            foreach (DataRow row in orders.Rows)
            {
                if (activeDemo.Actions.Canceled) return;

                if (row["TYPE"].ToString() == "CONTROL") //컨트롤일 경우 마우스 포인터 이동
                {
                    //CONTROL
                    control = getControl(row["CONTROL"].ToString());

                    if (control == null)
                        return;

                    if (Settings_IDAT.Default.WINSTYLE.ToUpper() == "RIBBON")
                    {
                        RibbonViewInfo vi = Program.frmM.rcPageTop.ViewInfo as RibbonViewInfo;
                        Rectangle r = vi.SelectedPage.Groups[0].ItemLinks[0].ScreenBounds;
                        MessageBox.Show(r.ToString());
                    }



                    point = control.PointToScreen(new Point(control.Size.Width / 2, control.Size.Height / 2));
                    activeDemo.MoveMouseFromPoint(point.X - Cursor.Position.X, point.Y - Cursor.Position.Y);
                    //ActiveActions.Delay(1000);

                }
                else if (row["TYPE"].ToString() == "COLUMN") //컬럼일 경우 마우스 포인터 이동
                {
                    string temp = row["CONTROL"].ToString();

                    string[] list = temp.Split('.');

                    if (list.Length != 3)
                        return;

                    control = getControl(list[0]);

                    if (control == null)
                        return;

                    GridControl gcList = (GridControl)control;
                    GridView gvList = (GridView)gcList.DefaultView;

                    activeDemo.SelectCellByMouse(gvList.Columns[list[2]], 0);
                }
                else
                {
                    return;
                }

                //CLICK
                bool isClick;

                if (row["CLICK"].ToString() == "Y")
                    isClick = true;
                else
                    isClick = false;

                if (isClick)
                {
                    activeDemo.Actions.MouseClick();
                }

                //SHOWTIME
                int showtime = Convert.ToInt32(row["SHOWTIME"]);

                if (showtime == 0)
                {
                    showtime = 400;
                }

                //MESSAGE
                activeDemo.ShowMessage(row["MESSAGE"].ToString(), showtime);

                //DELAY
                int delay = Convert.ToInt32(row["DELAY"].ToString());
                ActiveActions.Delay(delay);
            }
        }

        /// <summary>
        /// 마우스 이동할 XML파일 정보를 읽어 온다.
        /// </summary>
        /// <param name="f_path">파일명</param>
        /// <returns>DataSet</returns>
        private DataTable getDateSet(string f_path,string strFormName)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(f_path);
            DataTable orders = ds.Tables[0];

            //반환할 DataSet
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("FORM", typeof(string));
            dtResult.Columns.Add("SEQ", typeof(int));
            dtResult.Columns.Add("TYPE", typeof(string));
            dtResult.Columns.Add("CONTROL", typeof(string));
            dtResult.Columns.Add("CLICK", typeof(string));
            dtResult.Columns.Add("MESSAGE", typeof(string));
            dtResult.Columns.Add("SHOWTIME", typeof(int));
            dtResult.Columns.Add("DELAY", typeof(int));
            dtResult.Columns.Add("USEFLAG", typeof(string));

            var query = from history in orders.AsEnumerable()
                        where history.Field<string>("FORM") == strFormName
                           && history.Field<string>("USEFLAG") == "Y"
                        orderby history.Field<string>("SEQ")
                        select new Func<DataRow, string, string, string, string, string, string, string, string, string, DataRow>
                            ((DataRow addRow, string form, string seq, string type, string control, string click, string message, string showtime, string delay, string useflag) =>
                            {
                                addRow["FORM"] = form;
                                addRow["SEQ"] = seq;
                                addRow["TYPE"] = type;
                                addRow["CONTROL"] = control;
                                addRow["CLICK"] = click;
                                addRow["MESSAGE"] = message;
                                addRow["SHOWTIME"] = showtime;
                                addRow["DELAY"] = delay;
                                addRow["USEFLAG"] = useflag;
                                return addRow;
                            }).Invoke(dtResult.NewRow(), history.Field<string>("FORM"), history.Field<string>("SEQ"), history.Field<string>("TYPE"), history.Field<string>("CONTROL"),
                                        history.Field<string>("CLICK"), history.Field<string>("MESSAGE"), history.Field<string>("SHOWTIME"), history.Field<string>("DELAY"),
                                        history.Field<string>("USEFLAG"));

            try
            {
                dtResult = query.CopyToDataTable();
            }
            catch (Exception)
            {
                //
            }

            return dtResult;
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
                        allControls.Add(control);
                        queue.Enqueue(control.Controls);
                    }
                }
            });

            task.Start();
            task.Wait();

            return allControls.ToArray();
        }
        /// <summary>
        /// 현제 폼이 가지고 있는 컨트롤을 반환한다.
        /// </summary>
        /// <param name="_controlName">컨틀로 명</param>
        /// <returns>컨트롤</returns>
        private System.Windows.Forms.Control getControl(string _controlName)
        {
            Control rtControl = null;
            Control[] controls = GetAllControls(Program.frmM);

            foreach (Control c in controls)
            {
                if (c.Name == _controlName)
                    rtControl = c;
            }

            return rtControl;
        }
    }
}
