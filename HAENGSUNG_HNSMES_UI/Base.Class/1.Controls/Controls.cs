using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraSplashScreen;
using System.Runtime.InteropServices;
using DevExpress.Utils.Drawing;
using DevExpress.Utils.Text;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid;
using DevExpress.XtraPivotGrid;

namespace DevExpress.RealtorWorld.Win {
    public class MenuPanel : PanelControl {
        class LabelInfo {
            PanelControl owner;
            TileItem item;
            string caption;
            int width = -1;
            int left = 0;
            bool hotTrack = false;
            bool current = false;
            public LabelInfo(PanelControl owner, TileItem item, string caption, int left) {
                this.owner = owner;
                this.item = item;
                this.caption = caption;
                this.left = left;
            }
            int CalculateTextWidth(string text) {
                Graphics gr = Graphics.FromHwnd(owner.Handle);
                GraphicsCache cache = new GraphicsCache(gr);
                StringInfo textInfo;
                try {
                    textInfo = StringPainter.Default.Calculate(gr, owner.Appearance, text, -1);
                } finally {
                    cache.Dispose();
                    gr.Dispose();
                }
                return textInfo.Bounds.Width;
            }
            public TileItem Item { get { return item; } }
            public string Caption { 
                get {
                    if(current)
                        return string.Format("<color={1}>{0}", caption, AppConst.HtmlHighlightTextColor);
                    if(hotTrack)
                        return string.Format("<color={1}>{0}", caption, AppConst.HtmlWindowTextColor);
                    return string.Format("<color={1}>{0}", caption, AppConst.HtmlTextColor);; 
                } 
            }
            public int Width {
                get {
                    if(width == -1) width = CalculateTextWidth(Caption);
                    return width;
                }
            }
            public Rectangle Rectangle {
                get {
                    return new Rectangle(left, 0, Width, owner.Height);
                }
            }
            internal bool SetHotTrack(Point? point) {
                bool val = point.HasValue ? Rectangle.Contains(point.Value) : false;
                if(hotTrack == val) return false;
                hotTrack = val;
                return true;
            }
            internal bool SetCurrentModule(TileItem item) {
                bool val = object.ReferenceEquals(this.item, item);
                if(current == val) return false;
                current = val;
                return true;
            }
            public bool AllowClick { get { return !current; } }
        }
        List<LabelInfo> list = new List<LabelInfo>();
        const int separator = 20;
        bool calcViewInfo = false;
        public event EventHandler ItemClick;
        public void AddItem(TileItem item, string caption) {
            caption = string.Format("<size=+5>{0}", caption);
            list.Add(new LabelInfo(this, item, caption, GetPanelSize()));
        }
        int GetPanelSize() { 
            int ret = 0;
            for(int i = 0; i < list.Count; i++) 
                ret += list[i].Width + separator;
            return ret;
        }
        void CalcViewInfo() {
            if(calcViewInfo) return;
            if(DevExpress.Utils.Design.DesignTimeTools.IsDesignMode)
                this.Width = separator;
            else 
                this.Width = GetPanelSize() - separator;
            this.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            calcViewInfo = true;
        }
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            CalcViewInfo();
            using(GraphicsCache cache = new GraphicsCache(e.Graphics)) {
            foreach(LabelInfo info in list)
                StringPainter.Default.DrawString(cache, this.Appearance, info.Caption, info.Rectangle);
            }
        }
        protected override void OnMouseMove(MouseEventArgs e) {
            base.OnMouseMove(e);
            foreach(LabelInfo info in list) {
                if(info.SetHotTrack(e.Location))
                    this.Invalidate(info.Rectangle);
            }
        }
        protected override void OnMouseLeave(EventArgs e) {
            base.OnMouseLeave(e);
            foreach(LabelInfo info in list) {
                if(info.SetHotTrack(null))
                    this.Invalidate(info.Rectangle);
            }
        }
        internal void SetCurrentModule(TileItem item) {
            foreach(LabelInfo info in list) {
                if(info.SetCurrentModule(item))
                    this.Invalidate(info.Rectangle);
            }
        }
        protected override void OnMouseClick(MouseEventArgs e) {
            base.OnMouseClick(e);
            foreach(LabelInfo info in list) {
                if(info.Rectangle.Contains(e.Location) && info.AllowClick)
                    if(ItemClick != null) ItemClick(info.Item, EventArgs.Empty);
            }
        }
    }
    public class ModuleChanger {
        [DllImport("gdi32.dll")]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);
        public const int SRCCOPY = 13369376;
        bool showMainPanel = false;
        int step = 120;
        int indent = 0;
        Form form;
        Control mainPanel, modulePanel; 
        PictureBox draftPanel;
        Timer timer, draftTimer;
        public ModuleChanger(Form form, Control mainPanel, Control modulePanel, int indent) {
            this.form = form;
            this.mainPanel = mainPanel;
            this.modulePanel = modulePanel;
            this.indent = indent;
            modulePanel.Visible = mainPanel.Visible = false;
            CreateDraftPanel();
            CreateTimers();
        }
        void CreateDraftPanel() {
            this.draftPanel = new PictureBox();
            this.draftPanel.Parent = modulePanel;
            this.draftPanel.Visible = false;
            this.draftPanel.BorderStyle = BorderStyle.None;
        }
        void CreateTimers() {
            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += new EventHandler(mainTimer_Tick);
            draftTimer = new Timer();
            draftTimer.Interval = 1;
            draftTimer.Tick += new EventHandler(draftTimer_Tick);
        }
        void mainTimer_Tick(object sender, EventArgs e) {
            UpdateTimer(timer, false);
            if(showMainPanel && mainPanel.Location.X + step  > 0) {
                mainPanel.Location = new Point(form.Padding.Horizontal + draftPanel.Width, form.Padding.Top);
                mainPanel.Dock = DockStyle.Fill;
                modulePanel.Visible = false;
                TimerStop();
                return;
            }
            if(!showMainPanel && modulePanel.Location.X - step < form.Padding.Left) {
                modulePanel.Location = new Point(form.Padding.Horizontal + draftPanel.Width, form.Padding.Top);
                modulePanel.Dock = DockStyle.Fill;
                mainPanel.Visible = false;
                TimerStop();
                return;
            }
            mainPanel.Location = new Point(mainPanel.Location.X + step * (showMainPanel ? 1 : -1), form.Padding.Top);
            modulePanel.Location = new Point(modulePanel.Location.X + step * (showMainPanel ? 1 : -1), form.Padding.Top);
        }
        void TimerStop() {
            timer.Stop();
            ((TileControl)mainPanel).ResumeAnimation();
        }
        public void ShowPanel(bool showMainPanel, bool animation) {
            this.showMainPanel = showMainPanel;
            if(animation) {
                AnimateMainModules();
            } else {
                mainPanel.Visible = false;
                if(showMainPanel) {
                    modulePanel.Visible = false;
                    mainPanel.Dock = DockStyle.Fill;
                    mainPanel.Visible = true;
                } else {
                    HAENGSUNG_HNSMES_UI.Forms.BASE.Form module = DetailPanel.Controls[0] as HAENGSUNG_HNSMES_UI.Forms.BASE.Form;
                    if(!animation && SplashScreenManager.Default == null && (module != null && module.AllowWaitDialog))
                        SplashScreenManager.ShowForm(form, typeof(DevExpress.XtraWaitForm.DemoWaitForm), false, true);
                    modulePanel.Dock = DockStyle.Fill;
                    modulePanel.Visible = true;
                    DetailPanel.Dock = DockStyle.Fill;
                    DetailPanel.Visible = true;
                    mainPanel.Visible = false;
                    if(!animation && SplashScreenManager.Default != null && (module != null && module.AllowWaitDialog))
                        SplashScreenManager.CloseForm();
                }
            }
        }
        void AnimateMainModules() {
            using(CreateDraftImage(form, showMainPanel ? modulePanel : mainPanel)) {
                ((TileControl)mainPanel).SuspendAnimation();
                Size size = mainPanel.Size;
                
                
                mainPanel.Dock = modulePanel.Dock = DockStyle.None;
                mainPanel.Size = size;
                

                //modulePanel.Size = mainPanel.Size = new Size(form.ClientSize.Width - form.Padding.Horizontal, form.ClientSize.Height - form.Padding.Vertical);
                modulePanel.Size = mainPanel.Size = size;
                modulePanel.Visible = mainPanel.Visible = true;
                mainPanel.Location = new Point(showMainPanel ? -mainPanel.Width : form.Padding.Left, form.Padding.Top);
                modulePanel.Location = new Point(showMainPanel ? form.Padding.Left : form.Padding.Horizontal + mainPanel.Width, form.Padding.Top);

                StartTimer(timer, 100, 1);
            }
        }
        PictureBox CreateDraftImage(Control parent, Control image) {
            PictureBox pb = new PictureBox();
            pb.Parent = parent;
            pb.Visible = false;
            pb.BorderStyle = BorderStyle.None;
            pb.Image = GetControlImage(image);
            pb.Dock = DockStyle.Fill;
            pb.Visible = true;
            pb.BringToFront();
            return pb;
        }
        PanelControl DetailPanel { get { return modulePanel.Controls[0] as PanelControl; } }
        static Image GetControlImage(Control ctrl) {
            Graphics graphic = ctrl.CreateGraphics();
            Bitmap memImage = new Bitmap(ctrl.Width, ctrl.Height, graphic);
            Graphics memGraphic = Graphics.FromImage(memImage);
            IntPtr dc1 = graphic.GetHdc();
            IntPtr dc2 = memGraphic.GetHdc();
            BitBlt(dc2, 0, 0, ctrl.ClientRectangle.Width,
                ctrl.ClientRectangle.Height, dc1, 0, 0, SRCCOPY);
            graphic.ReleaseHdc(dc1);
            memGraphic.ReleaseHdc(dc2);
            return memImage;
        }
        public void SetDraftImage() {
            draftPanel.Image = GetControlImage(DetailPanel);
            DetailPanel.Visible = false;
            draftPanel.Size = new Size(modulePanel.ClientSize.Width + modulePanel.Padding.Horizontal, modulePanel.ClientSize.Height - modulePanel.Padding.Vertical);
            draftPanel.Location = new Point(modulePanel.Padding.Left + modulePanel.Left, modulePanel.Top + DetailPanel.Top);
            draftPanel.Visible = true;
        }
        void draftTimer_Tick(object sender, EventArgs e) {
            UpdateTimer(draftTimer, DetailPanel.Location.X < DetailPanel.Width / 3);
            if(DetailPanel.Location.X - indent - step < 0) {
                DetailPanel.Dock = DockStyle.Fill;
                draftPanel.Size = Size.Empty;
                draftPanel.Visible = false;
                draftTimer.Stop();
                return;
            }
            draftPanel.Location = new Point(draftPanel.Location.X - step, modulePanel.Top + DetailPanel.Top);
            DetailPanel.Location = new Point(DetailPanel.Location.X - step, modulePanel.Top + DetailPanel.Top);
        }
        internal void ShowDraftPanel() {
            Size size = DetailPanel.Size;
            DetailPanel.Dock = DockStyle.None;
            DetailPanel.Size = size;
            DetailPanel.Location = new Point(modulePanel.Padding.Left + modulePanel.Left + draftPanel.Width, modulePanel.Top + DetailPanel.Top);
            DetailPanel.Visible = true;

            StartTimer(draftTimer, 100, 1);
        }
        void UpdateTimer(Timer timer, bool slowdown) {
            if(!slowdown) {
                int interval = timer.Interval - 25;
                if(interval < 1) interval = 1;
                timer.Interval = interval;
                int dstep = step + 20;
                if(dstep > 120) dstep = 120;
                step = dstep;
            } else {
                timer.Interval += 5;
                if(timer.Interval > 50) timer.Interval = 50;
                int dstep = step - 20;
                if(dstep < 20) dstep = 20;
                step = dstep;
            }
        }
        void StartTimer(Timer timer, int interaval, int step) {
            timer.Interval = interaval;
            this.step = step;
            timer.Start();
        }
    }
}
