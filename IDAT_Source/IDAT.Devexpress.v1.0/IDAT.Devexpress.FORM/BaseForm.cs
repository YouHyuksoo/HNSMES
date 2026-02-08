using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid;
using DevExpress.XtraLayout;
using DevExpress.XtraPrinting;
using IDAT.Devexpress.ActionDemo;
using IDAT.Devexpress.DXControl;

namespace IDAT.Devexpress.FORM;

public class BaseForm : XtraForm, IBaseForm
{
	public delegate void IDAT_UpdateItemsEditChanged(object sender, UPDATEITEMTYPE type);

	private string _FormClass = string.Empty;

	private UPDATEITEMTYPE m_CurrentDataTYPE = UPDATEITEMTYPE.Edit;

	private Image m_imgFormIcon;

	private bool _IsButtonAuto = true;

	private bool _ShowAllCloseButton = true;

	private bool _ShowCloseButton = true;

	private bool _ShowPrintButton = true;

	private bool _ShowSaveButton = true;

	private bool _ShowEditButton = true;

	private bool _ShowNewbutton = true;

	private bool _ShowRefreshButton = true;

	private bool _ShowStopButton = true;

	private bool _ShowSearchButton = true;

	private bool _ShowInitButton = true;

	private bool _ShowDeleteButton = true;

	public bool IsButtonPrintEnable = false;

	public bool IsButtonSaveEnable = false;

	public bool IsButtonEditEnable = false;

	public bool IsButtonNewEnable = false;

	public bool IsButtonRefreshEnable = false;

	public bool IsButtonStopEnable = false;

	public bool IsButtonSearchEnable = false;

	public bool IsButtonInitEnable = false;

	public bool IsButtonDeleteEnable = false;

	public bool IsButtonCloseEnable = false;

	public bool IsButtonAllCloseEnable = false;

	private ActiveDemoResults fActiveDemoResults = null;

	private ActiveDemo fActiveDemo = null;

	private IContainer components = null;

	protected internal DXErrorProvider baseDxErrorProvider;

	private PrintingSystem printingSystem1;

	public string FormClass
	{
		get
		{
			return _FormClass;
		}
		set
		{
			_FormClass = value;
		}
	}

	public UPDATEITEMTYPE CurrentDataTYPE
	{
		get
		{
			return m_CurrentDataTYPE;
		}
		set
		{
			m_CurrentDataTYPE = value;
			baseDxErrorProvider.ClearErrors();
		}
	}

	public Image FormIcon
	{
		get
		{
			return m_imgFormIcon;
		}
		set
		{
			m_imgFormIcon = value;
		}
	}

	[Description("버튼특성에 맞게 전체 버튼이 활성화/비활성화 자동 처리 됨.")]
	[Category("메뉴버튼")]
	public bool IsButtonAuto
	{
		get
		{
			return _IsButtonAuto;
		}
		set
		{
			_IsButtonAuto = value;
		}
	}

	[Description("모두닫기 버튼을 활성화 비활성화 됨.")]
	[Category("메뉴버튼")]
	public bool ShowAllCloseButton
	{
		get
		{
			return _ShowAllCloseButton;
		}
		set
		{
			_ShowAllCloseButton = value;
		}
	}

	[Category("메뉴버튼")]
	[Description("닫기 버튼을 활성화 비활성화 됨.")]
	public bool ShowCloseButton
	{
		get
		{
			return _ShowCloseButton;
		}
		set
		{
			_ShowCloseButton = value;
		}
	}

	[Category("메뉴버튼")]
	[Description("프린트 버튼을 활성화 비활성화 됨.")]
	public bool ShowPrintButton
	{
		get
		{
			return _ShowPrintButton;
		}
		set
		{
			_ShowPrintButton = value;
		}
	}

	[Category("메뉴버튼")]
	[Description("저장 버튼을 활성화 비활성화 됨.")]
	public bool ShowSaveButton
	{
		get
		{
			return _ShowSaveButton;
		}
		set
		{
			_ShowSaveButton = value;
		}
	}

	[Category("메뉴버튼")]
	[Description("수정 버튼을 활성화 비활성화 됨.")]
	public bool ShowEditButton
	{
		get
		{
			return _ShowEditButton;
		}
		set
		{
			_ShowEditButton = value;
		}
	}

	[Category("메뉴버튼")]
	[Description("신규 버튼을 활성화 비활성화 됨.")]
	public bool ShowNewbutton
	{
		get
		{
			return _ShowNewbutton;
		}
		set
		{
			_ShowNewbutton = value;
		}
	}

	[Category("메뉴버튼")]
	[Description("새로고침 버튼을 활성화 비활성화 됨.")]
	public bool ShowRefreshButton
	{
		get
		{
			return _ShowRefreshButton;
		}
		set
		{
			_ShowRefreshButton = value;
		}
	}

	[Category("메뉴버튼")]
	[Description("정지 버튼을 활성화 비활성화 됨.")]
	public bool ShowStopButton
	{
		get
		{
			return _ShowStopButton;
		}
		set
		{
			_ShowStopButton = value;
		}
	}

	[Category("메뉴버튼")]
	[Description("검색 버튼을 활성화 비활성화 됨.")]
	public bool ShowSearchButton
	{
		get
		{
			return _ShowSearchButton;
		}
		set
		{
			_ShowSearchButton = value;
		}
	}

	[Category("메뉴버튼")]
	[Description("초기화 버튼을 활성화 비활성화 됨.")]
	public bool ShowInitButton
	{
		get
		{
			return _ShowInitButton;
		}
		set
		{
			_ShowInitButton = value;
		}
	}

	[Description("삭제 버튼을 활성화 비활성화 됨.")]
	[Category("메뉴버튼")]
	public bool ShowDeleteButton
	{
		get
		{
			return _ShowDeleteButton;
		}
		set
		{
			_ShowDeleteButton = value;
		}
	}

	public bool IsActiveDemo => fActiveDemo != null;

	public event IDAT_UpdateItemsEditChanged IDAT_UpdateItemsEditChangedEvent;

	public BaseForm()
	{
		InitializeComponent();
	}

	private Control[] GetAllControls(Control containerControl)
	{
		List<Control> allControls = new List<Control>();
		Queue<Control.ControlCollection> queue = new Queue<Control.ControlCollection>();
		queue.Enqueue(containerControl.Controls);
		Task task = new Task(delegate
		{
			while (queue.Count > 0)
			{
				Control.ControlCollection controlCollection = queue.Dequeue();
				if (controlCollection != null && controlCollection.Count != 0)
				{
					foreach (Control item in controlCollection)
					{
						allControls.Add(item);
						queue.Enqueue(item.Controls);
					}
				}
			}
		});
		task.Start();
		task.Wait();
		return allControls.ToArray();
	}

	protected void Update_ItemsEditing(Control con, UPDATEITEMTYPE uType)
	{
		if (this.IDAT_UpdateItemsEditChangedEvent != null)
		{
			this.IDAT_UpdateItemsEditChangedEvent(this, uType);
		}
		UpdateItemEditProcess(con, uType);
	}

	private void UpdateItemEditProcess(Control con, UPDATEITEMTYPE uType)
	{
		if (uType == UPDATEITEMTYPE.New)
		{
			baseDxErrorProvider.ClearErrors();
		}
		Control[] allControls = GetAllControls(con);
		Control[] array = allControls;
		foreach (Control control in array)
		{
			if (control.Controls.Count > 0)
			{
				UpdateItemEditProcess(control, uType);
			}
			if (!(control is LayoutControl))
			{
				continue;
			}
			CurrentDataTYPE = uType;
			LayoutControl layoutControl = control as LayoutControl;
			if (!layoutControl.IsInitialized)
			{
				break;
			}
			layoutControl.BeginUpdate();
			try
			{
				foreach (BaseLayoutItem item in layoutControl.Items)
				{
					if (!(item is LayoutControlItem { Control: not null } layoutControlItem))
					{
						continue;
					}
					if (layoutControlItem.Control is IIDATDxControl)
					{
						BaseEdit baseEdit = layoutControlItem.Control as BaseEdit;
						if (!(baseEdit is IIDATDxControl) || !(baseEdit is IIDATDxControl { IsUseIDATFrameWorkControl: not false } iIDATDxControl))
						{
							continue;
						}
						if (baseEdit != null)
						{
							if (uType == UPDATEITEMTYPE.None)
							{
								baseEdit.Properties.ReadOnly = true;
							}
							else if (iIDATDxControl.BindEditMode == EditModes.None)
							{
								(layoutControlItem.Control as BaseEdit).Properties.ReadOnly = true;
							}
							else
							{
								if (iIDATDxControl.BindEditMode == EditModes.Edit)
								{
									baseEdit.Properties.ReadOnly = false;
								}
								if (uType == UPDATEITEMTYPE.Edit)
								{
									if (iIDATDxControl.BindPK)
									{
										baseEdit.Properties.ReadOnly = true;
									}
									else
									{
										baseEdit.Properties.ReadOnly = false;
									}
								}
							}
							if (baseEdit is ButtonEdit)
							{
								ButtonEdit buttonEdit = baseEdit as ButtonEdit;
								if (buttonEdit.Properties.Buttons.Count > 0)
								{
									foreach (EditorButton button in buttonEdit.Properties.Buttons)
									{
										if (buttonEdit.Properties.ReadOnly)
										{
											button.Enabled = false;
										}
										else
										{
											button.Enabled = true;
										}
									}
								}
							}
						}
						if (!iIDATDxControl.ValidationCheck)
						{
							continue;
						}
						try
						{
							baseEdit.Validated -= be_Validated;
						}
						catch
						{
						}
						finally
						{
							if (baseEdit.TabIndex == 0)
							{
								baseEdit.Focus();
							}
							baseDxErrorProvider.ClearErrors();
							baseDxErrorProvider.SetError(baseEdit, "", ErrorType.None);
							baseEdit.Refresh();
							baseEdit.Validated += be_Validated;
						}
					}
					else if (layoutControlItem.Control is IIDATDxControl)
					{
						if (((IIDATDxControl)layoutControlItem.Control).BindEditMode == EditModes.Edit)
						{
							layoutControlItem.Control.Enabled = true;
						}
						if (((IIDATDxControl)layoutControlItem.Control).BindEditMode == EditModes.None)
						{
							(layoutControlItem.Control as BaseEdit).Properties.ReadOnly = true;
						}
					}
				}
			}
			finally
			{
				layoutControl.EndUpdate();
			}
		}
	}

	protected void Update_ItemsEditing(Control con, UPDATEITEMTYPE uType, GridControl p_Grid)
	{
		if (this.IDAT_UpdateItemsEditChangedEvent != null)
		{
			this.IDAT_UpdateItemsEditChangedEvent(this, uType);
		}
		UpdateItemEditProcess(con, uType, p_Grid);
	}

	private void UpdateItemEditProcess(Control con, UPDATEITEMTYPE uType, GridControl p_Grid)
	{
		if (uType == UPDATEITEMTYPE.New)
		{
			baseDxErrorProvider.ClearErrors();
		}
		Control[] allControls = GetAllControls(con);
		Control[] array = allControls;
		foreach (Control control in array)
		{
			if (control.Controls.Count > 0)
			{
				UpdateItemEditProcess(control, uType, p_Grid);
			}
			if (!(control is LayoutControl))
			{
				continue;
			}
			CurrentDataTYPE = uType;
			LayoutControl layoutControl = control as LayoutControl;
			if (!layoutControl.IsInitialized)
			{
				break;
			}
			layoutControl.BeginUpdate();
			try
			{
				foreach (BaseLayoutItem item in layoutControl.Items)
				{
					if (!(item is LayoutControlItem layoutControlItem) || layoutControlItem == null || layoutControlItem.Control == null || !(layoutControlItem.Control is IIDATDxControl))
					{
						continue;
					}
					BaseEdit baseEdit = layoutControlItem.Control as BaseEdit;
					if (baseEdit == null)
					{
						Console.WriteLine(baseEdit);
					}
					if (!(baseEdit is IIDATDxControl) || !(baseEdit is IIDATDxControl { BindGridControl: not null } iIDATDxControl) || !(iIDATDxControl.BindGridControl.Name == p_Grid.Name))
					{
						continue;
					}
					if (iIDATDxControl.IsUseIDATFrameWorkControl && baseEdit != null)
					{
						if (uType == UPDATEITEMTYPE.None)
						{
							baseEdit.Properties.ReadOnly = true;
						}
						else if (iIDATDxControl.BindEditMode == EditModes.None)
						{
							(layoutControlItem.Control as BaseEdit).Properties.ReadOnly = true;
						}
						else
						{
							if (iIDATDxControl.BindEditMode == EditModes.Edit)
							{
								baseEdit.Properties.ReadOnly = false;
							}
							if (uType == UPDATEITEMTYPE.Edit)
							{
								if (iIDATDxControl.BindPK)
								{
									baseEdit.Properties.ReadOnly = true;
								}
								else
								{
									baseEdit.Properties.ReadOnly = false;
								}
							}
						}
						if (baseEdit is ButtonEdit)
						{
							ButtonEdit buttonEdit = baseEdit as ButtonEdit;
							if (buttonEdit.Properties.Buttons.Count > 0)
							{
								foreach (EditorButton button in buttonEdit.Properties.Buttons)
								{
									if (buttonEdit.Properties.ReadOnly)
									{
										button.Enabled = false;
									}
									else
									{
										button.Enabled = true;
									}
								}
							}
						}
					}
					if (!iIDATDxControl.ValidationCheck)
					{
						continue;
					}
					try
					{
						baseEdit.Validated -= be_Validated;
					}
					catch
					{
					}
					finally
					{
						if (baseEdit.TabIndex == 0)
						{
							baseEdit.Focus();
						}
						baseDxErrorProvider.ClearErrors();
						baseDxErrorProvider.SetError(baseEdit, "", ErrorType.None);
						baseEdit.Refresh();
						baseEdit.Validated += be_Validated;
					}
				}
			}
			catch (Exception)
			{
			}
			finally
			{
				layoutControl.EndUpdate();
			}
		}
	}

	private void be_Validated(object sender, EventArgs e)
	{
		if (sender is BaseEdit baseEdit)
		{
			if ((baseEdit.EditValue == null || baseEdit.EditValue.ToString() == string.Empty) && !baseEdit.Properties.ReadOnly)
			{
				baseDxErrorProvider.SetError(sender as BaseEdit, "필수 입력항목입니다.", ErrorType.Warning);
			}
			else
			{
				baseDxErrorProvider.SetError(sender as BaseEdit, "", ErrorType.None);
			}
		}
	}

	public void RunActiveDemo()
	{
		if (!IsActiveDemo)
		{
			fActiveDemo = CreateActiveDemo();
			RunGridActiveDemo(fActiveDemo as ActiveGridDemo);
			ActiveActionsCancelMode cancelMode = fActiveDemo.Actions.CancelMode;
			fActiveDemo.Dispose();
			fActiveDemo = null;
			if (cancelMode == ActiveActionsCancelMode.UnknownTopWindow)
			{
				MessageBox.Show("There is unknown window above the demo. Please hide or close all tops windows to run active demo");
			}
			if (cancelMode == ActiveActionsCancelMode.UserCancel)
			{
				MessageBox.Show("도움말을 종료 합니다.");
			}
		}
	}

	protected virtual ActiveDemo CreateActiveDemo()
	{
		return new ActiveDemo();
	}

	protected virtual void RunGridActiveDemo(ActiveGridDemo fActiveDemo)
	{
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
		this.baseDxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
		this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem();
		((System.ComponentModel.ISupportInitialize)this.baseDxErrorProvider).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.printingSystem1).BeginInit();
		base.SuspendLayout();
		this.baseDxErrorProvider.ContainerControl = this;
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 14f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(761, 490);
		base.Name = "BaseForm";
		this.Text = "BaseForm";
		((System.ComponentModel.ISupportInitialize)this.baseDxErrorProvider).EndInit();
		((System.ComponentModel.ISupportInitialize)this.printingSystem1).EndInit();
		base.ResumeLayout(false);
	}
}
