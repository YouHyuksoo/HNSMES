using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace IDAT.Controls;

public class LinkControl : Panel
{
	private IContainer components = null;

	private ContextMenuStrip contextMenuStrip;

	private ToolStripMenuItem toolStripMenuItem1;

	private ToolTip linktoolTip;

	private ToolStripSeparator toolStripSeparator1;

	private ToolStripMenuItem toolStripMenuItem2;

	private ToolStripMenuItem toolStripMenuItem3;

	private ToolStripMenuItem toolStripMenuItem4;

	public int m_Point = -1;

	private bool m_IsIn = false;

	public bool m_IsSelect = false;

	private clsGDI m_gdi = new clsGDI();

	public ArrayList aryLink = new ArrayList();

	private Control frm;

	private bool m_isDelete = false;

	private bool m_UseMultiLink = false;

	private bool m_UseMenu = false;

	private bool m_isMove = false;

	private string m_InfoCode = "";

	private string m_InfoName = "";

	private string m_EquipmentCode = "";

	private string m_Equipment = "";

	private string m_PartnumberCode = "";

	private string m_Partnumber = "";

	private Color m_LineColor = Color.Black;

	private int m_LineWidth = 1;

	private Image m_BackImg = null;

	private DataTable m_EquipmentDataSource = null;

	private DataTable m_PartNoDataSource = null;

	private DataTable m_OperationDataSource = null;

	private StringBuilder sb = null;

	[Browsable(true)]
	[ReadOnly(true)]
	public override Image BackgroundImage
	{
		get
		{
			return base.BackgroundImage;
		}
		set
		{
			base.BackgroundImage = value;
		}
	}

	[ReadOnly(true)]
	[Browsable(false)]
	public override ImageLayout BackgroundImageLayout
	{
		get
		{
			return base.BackgroundImageLayout;
		}
		set
		{
			base.BackgroundImageLayout = value;
		}
	}

	[ReadOnly(true)]
	[Browsable(false)]
	public override Color ForeColor
	{
		get
		{
			return base.ForeColor;
		}
		set
		{
			base.ForeColor = value;
		}
	}

	[Browsable(false)]
	[ReadOnly(true)]
	public override Font Font
	{
		get
		{
			return base.Font;
		}
		set
		{
			base.Font = value;
		}
	}

	[Category("공정")]
	[Description("공정이 삭제 상태 정보를 가져오거나 설정합니다.")]
	public bool IsDelete
	{
		get
		{
			return m_isDelete;
		}
		set
		{
			m_isDelete = value;
		}
	}

	[Description("다중 링크를 설정하거나 가져옵니다.")]
	[Category("공정")]
	public bool UseMultiLink
	{
		get
		{
			return m_UseMultiLink;
		}
		set
		{
			m_UseMultiLink = value;
		}
	}

	[Description("공정이 메뉴를 설정하거나 가져옵니다.")]
	[Category("공정")]
	public bool UseMenu
	{
		get
		{
			return m_UseMenu;
		}
		set
		{
			m_UseMenu = value;
		}
	}

	[Description("공정이 이동을 지정합니다.")]
	[Category("공정")]
	public bool IsMove
	{
		get
		{
			return m_isMove;
		}
		set
		{
			m_isMove = value;
		}
	}

	[Description("공정이 그려질 컨트롤.")]
	[Category("공정")]
	public Control BackgroundControl
	{
		get
		{
			return frm;
		}
		set
		{
			frm = value;
			if (!base.DesignMode)
			{
				if (frm != null)
				{
					frm.Paint += frm_Paint;
				}
				else
				{
					frm = value.Parent;
				}
			}
		}
	}

	[Description("공정정보코드를 읽거나 가져옵니다.")]
	[Category("공정")]
	public string OperationCode
	{
		get
		{
			return m_InfoCode;
		}
		set
		{
			m_InfoCode = value;
		}
	}

	[Category("공정")]
	[Description("공정정보이름을 읽거나 가져옵니다.")]
	public string Operation
	{
		get
		{
			return m_InfoName;
		}
		set
		{
			m_InfoName = value;
		}
	}

	[Category("공정")]
	[Description("설비정보코드 지정합니다.")]
	public string EquipmentCode
	{
		get
		{
			return m_EquipmentCode;
		}
		set
		{
			m_EquipmentCode = value;
		}
	}

	[Category("공정")]
	[Description("설비정보 지정합니다.")]
	public string Equipment
	{
		get
		{
			return m_Equipment;
		}
		set
		{
			m_Equipment = value;
		}
	}

	[Description("품목코드정보를 지정합니다.")]
	[Category("공정")]
	public string PartnumberCode
	{
		get
		{
			return m_PartnumberCode;
		}
		set
		{
			m_PartnumberCode = value;
		}
	}

	[Category("공정")]
	[Description("품목정보를 지정합니다.")]
	public string Partnumber
	{
		get
		{
			return m_Partnumber;
		}
		set
		{
			m_Partnumber = value;
		}
	}

	[Description("연결 선 색깔을 읽거나 가져옵니다.")]
	[Category("공정")]
	public Color LineColor
	{
		get
		{
			return m_LineColor;
		}
		set
		{
			m_LineColor = value;
		}
	}

	[Description("연결 선 굵기정보를 읽거나 가져옵니다.")]
	[Category("공정")]
	public int LineWidth
	{
		get
		{
			return m_LineWidth;
		}
		set
		{
			m_LineWidth = value;
		}
	}

	[Category("공정")]
	[Description("배경이미지를 지정합니다.")]
	public Image BackImg
	{
		get
		{
			return m_BackImg;
		}
		set
		{
			m_BackImg = value;
		}
	}

	[Category("공정 DataSource")]
	[Description("설비 DataSource 지정합니다.")]
	public DataTable EquipmentDataSource
	{
		get
		{
			return m_EquipmentDataSource;
		}
		set
		{
			m_EquipmentDataSource = value;
		}
	}

	[Category("공정 DataSource")]
	[Description("품번 DataSource 지정합니다.")]
	public DataTable PartNoDataSource
	{
		get
		{
			return m_PartNoDataSource;
		}
		set
		{
			m_PartNoDataSource = value;
		}
	}

	[Description("공정 DataSource 지정합니다.")]
	[Category("공정 DataSource")]
	public DataTable OperationDataSource
	{
		get
		{
			return m_OperationDataSource;
		}
		set
		{
			m_OperationDataSource = value;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IDAT.Controls.LinkControl));
		this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
		this.linktoolTip = new System.Windows.Forms.ToolTip(this.components);
		this.contextMenuStrip.SuspendLayout();
		base.SuspendLayout();
		this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[5] { this.toolStripMenuItem1, this.toolStripMenuItem4, this.toolStripMenuItem2, this.toolStripSeparator1, this.toolStripMenuItem3 });
		this.contextMenuStrip.Name = "contextMenuStrip";
		this.contextMenuStrip.Size = new System.Drawing.Size(203, 98);
		this.contextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(contextMenuStrip_ItemClicked);
		this.toolStripMenuItem1.CheckOnClick = true;
		this.toolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.toolStripMenuItem1.Name = "toolStripMenuItem1";
		this.toolStripMenuItem1.Size = new System.Drawing.Size(202, 22);
		this.toolStripMenuItem1.Text = "[직선]연결 / 해제 하기";
		this.toolStripMenuItem4.CheckOnClick = true;
		this.toolStripMenuItem4.Name = "toolStripMenuItem4";
		this.toolStripMenuItem4.Size = new System.Drawing.Size(202, 22);
		this.toolStripMenuItem4.Text = "[곡선]연결 / 해제 하기";
		this.toolStripMenuItem2.Name = "toolStripMenuItem2";
		this.toolStripMenuItem2.Size = new System.Drawing.Size(202, 22);
		this.toolStripMenuItem2.Text = "연결모두해제";
		this.toolStripSeparator1.Name = "toolStripSeparator1";
		this.toolStripSeparator1.Size = new System.Drawing.Size(199, 6);
		this.toolStripMenuItem3.Name = "toolStripMenuItem3";
		this.toolStripMenuItem3.Size = new System.Drawing.Size(202, 22);
		this.toolStripMenuItem3.Text = "공정삭제";
		this.linktoolTip.AutoPopDelay = 5000;
		this.linktoolTip.InitialDelay = 500;
		this.linktoolTip.IsBalloon = true;
		this.linktoolTip.ReshowDelay = 10000;
		this.linktoolTip.ShowAlways = true;
		this.linktoolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
		this.linktoolTip.ToolTipTitle = "공정 라우터 정보";
		this.BackColor = System.Drawing.Color.Transparent;
		this.BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
		this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		base.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.ContextMenuStrip = this.contextMenuStrip;
		base.Size = new System.Drawing.Size(52, 52);
		base.Paint += new System.Windows.Forms.PaintEventHandler(LinkControl_Paint);
		base.MouseDown += new System.Windows.Forms.MouseEventHandler(LinkControl_MouseDown);
		this.contextMenuStrip.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	public LinkControl()
	{
		InitializeComponent();
		SetStyle(ControlStyles.DoubleBuffer, value: true);
		SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
		SetStyle(ControlStyles.UserPaint, value: true);
		SetStyle(ControlStyles.ResizeRedraw, value: true);
		linktoolTip.AutoPopDelay = 5000;
		linktoolTip.InitialDelay = 500;
		linktoolTip.ReshowDelay = 500;
	}

	public LinkControl(Control con)
		: this()
	{
		BackgroundControl = con;
	}

	public void LinkRemove(LinkControl linkCon)
	{
		linkCon.aryLink.Clear();
		SetConSelClear();
		if (frm != null)
		{
			frm.Invalidate();
		}
		foreach (Control control in base.Parent.Controls)
		{
			if (!(control is LinkControl))
			{
				continue;
			}
			LinkControl linkControl = control as LinkControl;
			for (int i = 0; i < linkControl.aryLink.Count; i++)
			{
				clsLinkInfo clsLinkInfo2 = linkControl.aryLink[i] as clsLinkInfo;
				if (clsLinkInfo2.name == linkCon.Name)
				{
					linkControl.aryLink.RemoveAt(i);
				}
			}
			linkControl.Invalidate();
		}
	}

	public void SetColor(Color color)
	{
		foreach (Control control in base.Parent.Controls)
		{
			if (control is LinkControl)
			{
				LinkControl linkControl = control as LinkControl;
				if (linkControl != null)
				{
					linkControl.LineColor = color;
				}
				linkControl.Invalidate();
			}
		}
	}

	public void SetLinkState(int type)
	{
		m_Point = -1;
		bool flag = toolStripMenuItem1.Checked;
		bool flag2 = toolStripMenuItem4.Checked;
		foreach (Control control in BackgroundControl.Controls)
		{
			if (!(control is LinkControl))
			{
				continue;
			}
			LinkControl linkControl = control as LinkControl;
			if (Operation != linkControl.Operation)
			{
				switch (type)
				{
				case 1:
					linkControl.toolStripMenuItem1.Checked = !flag;
					toolStripMenuItem1.Checked = !flag;
					linkControl.toolStripMenuItem4.Checked = false;
					toolStripMenuItem4.Checked = false;
					break;
				case 2:
					linkControl.toolStripMenuItem1.Checked = false;
					toolStripMenuItem1.Checked = false;
					linkControl.toolStripMenuItem4.Checked = !flag2;
					toolStripMenuItem4.Checked = !flag2;
					break;
				}
			}
			linkControl.Invalidate();
		}
	}

	public void SetLinkState(bool flag)
	{
		m_Point = -1;
		foreach (Control control in base.Parent.Controls)
		{
			if (control is LinkControl)
			{
				LinkControl linkControl = control as LinkControl;
				if (Operation != linkControl.Operation)
				{
					linkControl.toolStripMenuItem1.Checked = flag;
					toolStripMenuItem1.Checked = flag;
					linkControl.toolStripMenuItem4.Checked = flag;
					toolStripMenuItem4.Checked = flag;
				}
				linkControl.Invalidate();
			}
		}
	}

	private void SetLinkC(int linktype)
	{
		clsLinkInfo clsLinkInfo2 = new clsLinkInfo();
		clsLinkInfo2.name = base.Name;
		clsLinkInfo2.linkType = linktype;
		clsLinkInfo2.linkColor = LineColor;
		clsLinkInfo2.youLocaion = base.Location;
		foreach (Control control in base.Parent.Controls)
		{
			if (!(control is LinkControl))
			{
				continue;
			}
			LinkControl linkControl = control as LinkControl;
			if (!m_IsSelect || (!toolStripMenuItem1.Checked && !toolStripMenuItem4.Checked) || !(linkControl.Name != base.Name) || (!toolStripMenuItem1.Checked && !toolStripMenuItem4.Checked) || (!linkControl.toolStripMenuItem1.Checked && !linkControl.toolStripMenuItem4.Checked) || !linkControl.m_IsSelect)
			{
				continue;
			}
			bool flag = false;
			foreach (clsLinkInfo item in linkControl.aryLink)
			{
				if (item.name == clsLinkInfo2.name)
				{
					flag = true;
					break;
				}
				flag = false;
			}
			if (!flag)
			{
				if (!m_UseMultiLink)
				{
					linkControl.aryLink.Clear();
				}
				linkControl.aryLink.Add(clsLinkInfo2);
				Console.WriteLine($"{linkControl.Operation}과 {Operation}이 연결");
				linkControl.m_Point = -1;
				m_Point = -1;
			}
			else
			{
				if (MessageBox.Show($"{linkControl.Operation}과 {Operation}을 연결해제 하시겠습니까?", "연결해제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					for (int i = 0; i < linkControl.aryLink.Count; i++)
					{
						clsLinkInfo clsLinkInfo4 = linkControl.aryLink[i] as clsLinkInfo;
						if (clsLinkInfo2.name == clsLinkInfo4.name)
						{
							linkControl.aryLink.RemoveAt(i);
						}
					}
					Console.WriteLine($"{linkControl.Operation}과 {Operation}이 해제");
				}
				linkControl.m_Point = -1;
				m_Point = -1;
			}
			m_IsSelect = false;
			linkControl.m_IsSelect = false;
			if (frm != null)
			{
				frm.Invalidate();
			}
		}
	}

	private void SetConSelClear()
	{
		foreach (Control control in base.Parent.Controls)
		{
			if (control is LinkControl)
			{
				LinkControl linkControl = control as LinkControl;
				linkControl.m_IsSelect = false;
				linkControl.toolStripMenuItem1.Checked = false;
				linkControl.toolStripMenuItem4.Checked = false;
				linkControl.Invalidate();
			}
		}
	}

	private void LinkControl_MouseDown(object sender, MouseEventArgs e)
	{
		if (base.DesignMode)
		{
			return;
		}
		if (UseMenu && e.Clicks == 2 && !toolStripMenuItem1.Checked && !toolStripMenuItem4.Checked)
		{
			frmLinkSettings frmLinkSettings2 = new frmLinkSettings(OperationCode, EquipmentCode, PartnumberCode, OperationDataSource, "OPERATIONNAME", "OPERATION", EquipmentDataSource, "EQUIPMENTNAME", "EQUIPMENT", PartNoDataSource, "PARTNUMBERNAME", "PARTNUMBER");
			frmLinkSettings2.SaveEvent += frmStg_SaveEvent;
			frmLinkSettings2.Text = Operation;
			frmLinkSettings2.StartPosition = FormStartPosition.CenterParent;
			frmLinkSettings2.ShowDialog();
		}
		if (e.Button != MouseButtons.Left)
		{
			return;
		}
		if (!toolStripMenuItem1.Checked && !toolStripMenuItem4.Checked && IsMove)
		{
			Cursor = Cursors.NoMove2D;
			clsApiMethod.ReleaseCapture();
			clsApiMethod.SendMessage(base.Handle, 161, 2, 0);
			Cursor = Cursors.Default;
		}
		if (toolStripMenuItem1.Checked && base.Location.X + e.X < base.Location.X + base.Width && base.Location.Y + e.Y < base.Location.Y + base.Height)
		{
			if (m_IsSelect)
			{
				m_IsSelect = false;
				m_Point = -1;
			}
			else
			{
				m_IsSelect = true;
				m_Point = 1;
				SetLinkC(1);
			}
		}
		if (toolStripMenuItem4.Checked && base.Location.X + e.X < base.Location.X + base.Width && base.Location.Y + e.Y < base.Location.Y + base.Height)
		{
			if (m_IsSelect)
			{
				m_IsSelect = false;
				m_Point = -1;
			}
			else
			{
				m_IsSelect = true;
				m_Point = 1;
				SetLinkC(2);
			}
		}
		Invalidate();
		if (frm != null)
		{
			frm.Invalidate();
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		if (!base.ClientRectangle.Contains(e.X, e.Y))
		{
			return;
		}
		if (!m_IsIn)
		{
			if (toolStripMenuItem1.Checked)
			{
				Cursor = Cursors.UpArrow;
			}
			else
			{
				Cursor = Cursors.Default;
			}
			Invalidate();
			sb = new StringBuilder();
			sb.Append("Operation Code : " + OperationCode + "\r\n");
			sb.Append("Operation : " + Operation + "\r\n");
			foreach (clsLinkInfo item in aryLink)
			{
				sb.Append("Link : " + base.Name + "->" + item.name + "\r\n");
			}
			linktoolTip.SetToolTip(this, sb.ToString());
		}
		m_IsIn = true;
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		m_IsIn = false;
		Invalidate();
	}

	private void LinkControl_Paint(object sender, PaintEventArgs e)
	{
		if (Operation == null)
		{
			Operation = base.Name;
		}
		if (!toolStripMenuItem1.Checked && !toolStripMenuItem4.Checked)
		{
			return;
		}
		e.Graphics.DrawPath(new Pen(Brushes.Red, 2f), m_gdi.getRectPath(base.Width - 1, base.Height - 1));
		Brush black = Brushes.Black;
		Brush blue = Brushes.Blue;
		if (m_IsIn)
		{
			Console.WriteLine("MPOING" + m_Point);
			if (m_Point == 1)
			{
				e.Graphics.DrawPath(new Pen(Brushes.Red, 4f), m_gdi.getRectPath(base.Width - 1, base.Height - 1));
			}
			else
			{
				e.Graphics.DrawPath(new Pen(Brushes.Red, 2f), m_gdi.getRectPath(base.Width - 1, base.Height - 1));
			}
		}
	}

	public void frm_Paint(object sender, PaintEventArgs e)
	{
		try
		{
			foreach (Control control in base.Parent.Controls)
			{
				if (!(control is LinkControl))
				{
					continue;
				}
				LinkControl linkControl = control as LinkControl;
				foreach (clsLinkInfo item in linkControl.aryLink)
				{
					if (item.name == base.Name)
					{
						using Pen pen = new Pen(item.linkColor, linkControl.LineWidth);
						e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
						pen.Color = item.linkColor;
						pen.CustomEndCap = new AdjustableArrowCap(3f, 3f, isFilled: true);
						e.Graphics.DrawPath(pen, m_gdi.getLinkPath(control, this, 0, 0, item.linkType.ToString()));
					}
				}
				if (linkControl.Visible)
				{
					e.Graphics.DrawString(linkControl.Operation, new Font("Tahoma", 9f), Brushes.Black, new PointF(control.Location.X, control.Location.Y + control.Height + 5));
					e.Graphics.DrawString(linkControl.Equipment, new Font("Tahoma", 9f), Brushes.Red, new PointF(control.Location.X, control.Location.Y + control.Height + 20));
				}
			}
		}
		catch
		{
		}
	}

	public void contextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
	{
		if (contextMenuStrip.Items[0].Selected)
		{
			toolStripMenuItem4.Checked = false;
			SetLinkState(1);
		}
		if (contextMenuStrip.Items[1].Selected)
		{
			toolStripMenuItem1.Checked = false;
			SetLinkState(2);
		}
		if (contextMenuStrip.Items[2].Selected)
		{
			LinkRemove(this);
		}
		if (contextMenuStrip.Items[4].Selected)
		{
			LinkRemove(this);
			Dispose();
		}
	}

	private void frmStg_SaveEvent(string partnumbercode, string partnumber, string operationcode, string operation, string equipmentcode, string equipment)
	{
		PartnumberCode = partnumbercode;
		Partnumber = partnumber;
		OperationCode = operationcode;
		Operation = operation;
		EquipmentCode = equipmentcode;
		Equipment = equipment;
	}
}
