using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using IDAT.Devexpress.DXControl;
using IDAT.Devexpress.GRID;
using IDAT.Devexpress.KEYBOARD;
using IDAT.Devexpress.Properties;

namespace IDAT.Devexpress.FORM;

public class iDATCommonControlManager
{
	public delegate void IDAT_ChangedCaptionString(ref string strCaptionText);

	public delegate void IDAT_SelectionSummary(decimal count, decimal result);

	public delegate void SetDefaultControlEventHandler(Control OneControls);

	public delegate void SetLayoutControlEventHandler(LayoutControl layoutControl);

	private PROGRAM_LANGUENGE _PGLAN = PROGRAM_LANGUENGE.KOREA;

	internal Color _ControlReadOnlyBackColor = Color.WhiteSmoke;

	internal Color _ControlReadOnlyFontColor = Color.Black;

	internal Color _ControlPKColor = Color.MistyRose;

	public static readonly string LOC_Init = "항목 초기화";

	public static readonly string ENG_Init = "Initialization Entry.";

	public static readonly string LOC_MemoExEdit = "보이기/숨기기 [키보드 : ALT+DOWN, F4]";

	public static readonly string ENG_MemoExEdit = "Keyboard : ALT+DOWN,F4 to show or hide the dropdown memo editer.";

	public static readonly string LOC_DateEdit = "보이기/숨기기 [키보드 : ALT+DOWN, F4] \r\n값 확인 [키보드 : UP,DOWN]\r\n마우스 휠 지원.";

	public static readonly string ENG_DateEdit = "Keyboard : ALT+DOWN,F4 to show to hide the dropdown calender \r\nUP,DOWN keys to scrool the value.\r\nMouse Wheel : Supported";

	public static readonly string LOC_ComboBoxEdit = "보이기/숨기기 [키보드 : ALT+DOWN, F4] \r\n이전,다음 값 확인 [키보드 : UP,DOWN]\r\n마우스 휠 지원.";

	public static readonly string ENG_ComboBoxEdit = "Keyboard : ALT+DOWN, F4 to show or hide the dropdown list \r\nUp, Down Keys to select the previous or next item.\r\nMouse Wheel : Supported";

	public static readonly string LOC_TimeEdit = "값 변경 [키보드 : UP, DOWN]\r\n마우스 휠 지원.";

	public static readonly string ENG_TimeEdit = "Keyboard : UP,DOWN Keys. \r\nMouse Wheel : supported";

	public static readonly string LOC_SpinEdit = "값 변경 [키보드 : UP, DOWN]\r\n마우스 휠 지원.";

	public static readonly string ENG_SpinEdit = "Keyboard : UP,DOWN Keys. \r\nMouse Wheel : supported";

	public static readonly string LOC_CheckEdit = "마우스 기능 : 캡션 / 체크박스 클릭\r\n키보드 : SPACE";

	public static readonly string ENG_CheckEdit = "Mouse features : Click caption or Check Box, \r\nKeyboard : Press SPACE or use mnemonics";

	public static readonly string LOC_RadioGroup = "마우스 기능 : 텍스트 / 이미지 클릭\r\n키보드 : UP,DOWN,LEFT,RIGHT";

	public static readonly string ENG_RadioGroup = "Mouse features : Click an Item's text or glyph. \r\nKeyboard : UP,DOWN,LEFT,RIGHT keys or mnemonics.";

	public static readonly string LOC_LookUP = "보이기/숨기기 [키보드 : ALT+DOWN, F4] \r\n이전,다음 값 확인 [키보드 : UP,DOWN]\r\n마우스 휠 지원.";

	public static readonly string ENG_LookUP = "Keyboard : ALT+DOWN, F4 to show or hide the dropdown list \r\nUp, Down Keys to select the previous or next item.\r\nMouse Wheel : Supported";

	public event IDAT_ChangedCaptionString IDAT_ChangedCaptionStringEvent;

	public event IDAT_SelectionSummary IDAT_SelectionSummaryEvent;

	public void SetLayControlsInit(Control controls)
	{
		Control[] allLayoutControls = GetAllLayoutControls(controls);
		for (int i = 0; i < allLayoutControls.Length; i++)
		{
			if (allLayoutControls[i] is LayoutControl)
			{
				LayoutControl layoutControlEvent = allLayoutControls[i] as LayoutControl;
				SetLayoutControlEvent(layoutControlEvent);
			}
		}
	}

	private void SetLayoutControlThread(object state)
	{
		LayoutControl layoutControl = state as LayoutControl;
		layoutControl.Invoke(new SetLayoutControlEventHandler(SetLayoutControlEvent), layoutControl);
	}

	private void SetLayoutControlEvent(LayoutControl layoutControl)
	{
		SetLayControlsInitMethod(layoutControl);
	}

	public void SetLayControlsInitFunc(Control controls)
	{
		LayoutControl layControlsInitMethod = controls as LayoutControl;
		SetLayControlsInitMethod(layControlsInitMethod);
	}

	private void SetLayControlsInitMethod(object state)
	{
		LayoutControl layoutControl = state as LayoutControl;
		layoutControl.BeginUpdate();
		layoutControl.OptionsView.DrawItemBorders = false;
		layoutControl.OptionsView.HighlightFocusedItem = true;
		layoutControl.OptionsFocus.AllowFocusReadonlyEditors = true;
		layoutControl.OptionsFocus.MoveFocusDirection = MoveFocusDirection.DownThenAcross;
		layoutControl.AllowCustomizationMenu = false;
		for (int i = 0; i < layoutControl.Items.Count; i++)
		{
			string strCaptionText = layoutControl.Items[i].Text;
			if (this.IDAT_ChangedCaptionStringEvent != null)
			{
				this.IDAT_ChangedCaptionStringEvent(ref strCaptionText);
			}
			layoutControl.Items[i].Text = strCaptionText;
			layoutControl.Items[i].AppearanceItemCaption.BackColor = Color.Transparent;
			layoutControl.Items[i].AppearanceItemCaption.TextOptions.VAlignment = VertAlignment.Center;
			layoutControl.Padding = new System.Windows.Forms.Padding(2);
			if (layoutControl.Items[i] is LayoutControlItem { TextAlignMode: not TextAlignModeItem.CustomSize })
			{
				layoutControl.Items[i].TextSize = new Size(110, 21);
			}
			if (layoutControl.Items[i].TextVisible)
			{
				layoutControl.Items[i].Spacing = new DevExpress.XtraLayout.Utils.Padding(4, 0, 0, 0);
				if (string.Concat(layoutControl.Items[i].Tag).ToUpper() != "CUSTOM")
				{
					layoutControl.Items[i].AppearanceItemCaption.TextOptions.HAlignment = HorzAlignment.Far;
				}
			}
			if (layoutControl.Items[i] is TabbedControlGroup)
			{
				TabbedControlGroup tabbedControlGroup = (TabbedControlGroup)layoutControl.Items[i];
				tabbedControlGroup.AppearanceTabPage.HeaderActive.Font = new Font("Tahoma", 9f, FontStyle.Bold);
				tabbedControlGroup.AppearanceTabPage.HeaderActive.ForeColor = Color.DarkBlue;
			}
			if (!layoutControl.Items[i].IsGroup)
			{
				continue;
			}
			LayoutControlGroup layoutControlGroup = (LayoutControlGroup)layoutControl.Items[i];
			layoutControlGroup.AppearanceGroup.Font = new Font("Tahoma", 9f, FontStyle.Bold);
			layoutControlGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(1);
			try
			{
				strCaptionText = layoutControlGroup.Text;
				if (this.IDAT_ChangedCaptionStringEvent != null)
				{
					this.IDAT_ChangedCaptionStringEvent(ref strCaptionText);
				}
				layoutControlGroup.Text = strCaptionText;
			}
			catch
			{
				layoutControlGroup.CaptionImage = null;
			}
		}
		layoutControl.EndUpdate();
	}

	public void SetDefaultControls(Control containerControl)
	{
		Control[] allControls = GetAllControls(containerControl);
		for (int i = 0; i < allControls.Length; i++)
		{
			if (allControls[i].InvokeRequired)
			{
				allControls[i].Invoke(new SetDefaultControlEventHandler(SetDefaultControl), allControls[i]);
			}
			else
			{
				SetDefaultControl(allControls[i]);
			}
		}
	}

	private void SetDefaultControlThread(object state)
	{
		Control control = state as Control;
		control.Invoke(new SetDefaultControlEventHandler(SetDefaultControl), control);
	}

	public void SetDefaultControl(Control cons)
	{
		try
		{
			if (cons is XtraTabControl)
			{
				XtraTabControl xtraTabControl = cons as XtraTabControl;
				xtraTabControl.BeginUpdate();
				foreach (XtraTabPage tabPage in xtraTabControl.TabPages)
				{
					string strCaptionText = tabPage.Text;
					if (this.IDAT_ChangedCaptionStringEvent != null)
					{
						this.IDAT_ChangedCaptionStringEvent(ref strCaptionText);
					}
					tabPage.Text = strCaptionText;
					SetLayControlsInit(tabPage);
				}
				xtraTabControl.EndUpdate();
			}
			if (cons is GridControl)
			{
				GridControl gridControl = cons as GridControl;
				GridView gridView = gridControl.DefaultView as GridView;
				gridControl.BeginUpdate();
				gridControl.LookAndFeel.UseDefaultLookAndFeel = true;
				gridControl.TabStop = false;
				if (gridView != null)
				{
					gridView.BestFitMaxRowCount = 10;
					gridView.OptionsLayout.StoreAllOptions = true;
					gridView.OptionsLayout.StoreAppearance = true;
					gridView.OptionsLayout.StoreDataSettings = true;
					gridView.OptionsLayout.StoreVisualOptions = true;
					gridView.OptionsLayout.Columns.StoreAllOptions = true;
					gridView.OptionsLayout.Columns.StoreAppearance = true;
					gridView.OptionsLayout.Columns.StoreLayout = true;
					gridView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
					gridView.OptionsBehavior.Editable = false;
					gridView.OptionsView.ShowGroupPanel = false;
					gridView.OptionsView.EnableAppearanceOddRow = false;
					gridView.OptionsView.EnableAppearanceEvenRow = true;
					gridView.OptionsView.ShowGroupedColumns = true;
					gridView.OptionsView.ShowAutoFilterRow = true;
					gridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Default;
					gridView.OptionsView.ShowVertLines = true;
					gridView.OptionsView.ShowHorzLines = true;
					gridView.OptionsFilter.AllowFilterEditor = true;
					gridView.OptionsFilter.UseNewCustomFilterDialog = true;
					gridView.OptionsBehavior.AutoExpandAllGroups = true;
					gridView.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
					gridView.OptionsCustomization.AllowFilter = true;
					gridView.OptionsPrint.AutoWidth = false;
					gridView.OptionsMenu.EnableFooterMenu = true;
					gridView.OptionsMenu.EnableColumnMenu = true;
					gridView.GroupFormat = "{1}";
					gridView.OptionsView.ShowFooter = true;
					gridView.FixedLineWidth = 1;
					gridView.Appearance.FocusedCell.BackColor = Color.MistyRose;
					gridView.DataSourceChanged += gridV_DataSourceChanged;
					gridView.CustomDrawColumnHeader += gridV_CustomDrawColumnHeader;
					gridView.Click += gridV_Click;
					if (GetTagINFO(gridControl, "ContextMenu") != "N")
					{
						gridView.MouseDown += gridV_MouseDown;
					}
					if (GetTagINFO(gridControl, "UseBackColor") != "N")
					{
						gridView.CustomDrawCell += gridV_CustomDrawCell;
					}
					gridView.SelectionChanged += gridV_SelectionChanged;
					gridView.KeyDown += gridV_KeyDown;
					gridView.RowCountChanged += gridV_RowCountChanged;
					gridView.CustomDrawRowIndicator += gridV_CustomDrawRowIndicator;
					gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
					gridView.OptionsSelection.MultiSelect = true;
					gridView.Appearance.SelectedRow.BackColor = Color.FromArgb(100, 140, 145, 255);
					gridView.Appearance.FocusedRow.BackColor = Color.FromArgb(100, 140, 145, 255);
					gridView.Appearance.HorzLine.BackColor = Color.DarkGray;
					gridView.Appearance.HorzLine.Options.UseBackColor = true;
					gridView.Appearance.VertLine.BackColor = Color.DarkGray;
					gridView.Appearance.VertLine.Options.UseBackColor = true;
				}
				gridControl.EndUpdate();
			}
			if (cons is PivotGridControl)
			{
				PivotGridControl pivotGridControl = cons as PivotGridControl;
			}
			if (cons is DataNavigator)
			{
				ImageList imageList = new ImageList();
				imageList.ImageSize = new Size(32, 32);
				imageList.Images.Add(Resources.button_new);
				imageList.Images.Add(Resources.button_stop);
				imageList.Images.Add(Resources.button_delete);
				imageList.Images.Add(Resources.button_save);
				DataNavigator dataNavigator = cons as DataNavigator;
				dataNavigator.Buttons.First.Visible = false;
				dataNavigator.Buttons.Last.Visible = false;
				dataNavigator.Buttons.Next.Visible = false;
				dataNavigator.Buttons.NextPage.Visible = false;
				dataNavigator.Buttons.Prev.Visible = false;
				dataNavigator.Buttons.PrevPage.Visible = false;
				dataNavigator.Buttons.ImageList = imageList;
				dataNavigator.Buttons.Append.ImageIndex = 0;
				dataNavigator.Buttons.CancelEdit.ImageIndex = 1;
				dataNavigator.Buttons.Remove.ImageIndex = 2;
				dataNavigator.Buttons.EndEdit.ImageIndex = 3;
			}
			if (cons is TreeList)
			{
				TreeList treeList = cons as TreeList;
				treeList.BeginUpdate();
				treeList.OptionsView.ShowHorzLines = true;
				treeList.OptionsView.ShowVertLines = false;
				treeList.OptionsView.EnableAppearanceEvenRow = true;
				foreach (TreeListColumn column in treeList.Columns)
				{
					string strCaptionText = column.FieldName;
					if (this.IDAT_ChangedCaptionStringEvent != null)
					{
						this.IDAT_ChangedCaptionStringEvent(ref strCaptionText);
					}
					column.Caption = strCaptionText;
				}
				treeList.EndUpdate();
			}
			if (cons is IdatDxSimpleButton)
			{
				IdatDxSimpleButton idatDxSimpleButton = cons as IdatDxSimpleButton;
				string strCaptionText = idatDxSimpleButton.Text;
				if (this.IDAT_ChangedCaptionStringEvent != null)
				{
					this.IDAT_ChangedCaptionStringEvent(ref strCaptionText);
				}
				idatDxSimpleButton.Text = strCaptionText;
				idatDxSimpleButton.Cursor = Cursors.Hand;
			}
			IDATDevExpress_GridControl iDATDevExpress_GridControl = new IDATDevExpress_GridControl();
			if (!(cons is IIDATDxControl))
			{
				return;
			}
			if (cons is BaseEdit)
			{
				BaseEdit baseEdit = cons as BaseEdit;
				baseEdit.Properties.AppearanceReadOnly.BackColor = _ControlReadOnlyBackColor;
				baseEdit.Properties.AppearanceReadOnly.ForeColor = _ControlReadOnlyFontColor;
				if (((IIDATDxControl)baseEdit).BindPK)
				{
					baseEdit.Properties.AppearanceReadOnly.BackColor = _ControlPKColor;
				}
			}
			if (cons is IdatDxTextEdit)
			{
				IdatDxTextEdit idatDxTextEdit = cons as IdatDxTextEdit;
				idatDxTextEdit.Properties.BeginUpdate();
				idatDxTextEdit.EnterMoveNextControl = true;
				idatDxTextEdit.Properties.AppearanceDisabled.ForeColor = Color.Black;
				if (idatDxTextEdit.Properties.MaxLength > 0)
				{
					idatDxTextEdit.ToolTip = $"Max Length : {idatDxTextEdit.Properties.MaxLength}";
				}
				if (cons is IdatDxMemoEdit)
				{
					IdatDxMemoEdit idatDxMemoEdit = cons as IdatDxMemoEdit;
					idatDxMemoEdit.EnterMoveNextControl = false;
				}
				idatDxTextEdit.Properties.EndUpdate();
			}
			if (cons is ButtonEdit)
			{
				ButtonEdit buttonEdit = cons as ButtonEdit;
				buttonEdit.Properties.BeginUpdate();
				if (buttonEdit.Properties.ReadOnly && buttonEdit.Properties.Buttons.Count > 0)
				{
					foreach (EditorButton button in buttonEdit.Properties.Buttons)
					{
						button.Enabled = false;
					}
				}
				if (buttonEdit is IdatDxComboBoxEdit)
				{
					if (buttonEdit.Properties.Buttons.Count > 0)
					{
						buttonEdit.Properties.Buttons[0].Width = 15;
					}
				}
				else if (buttonEdit is IdatDxLookUpEdit || buttonEdit is IdatDxPopupContainerEdit || buttonEdit is IdatDxGridLookUpEdit)
				{
					if (buttonEdit.Properties.Buttons.Count > 0)
					{
						buttonEdit.Properties.Buttons[0].Kind = ButtonPredefines.Glyph;
						buttonEdit.Properties.Buttons[0].Width = 15;
						buttonEdit.Properties.Buttons[0].Image = Resources.loouplist;
					}
				}
				else if (buttonEdit is IdatDxCalcEdit)
				{
					if (buttonEdit.Properties.Buttons.Count > 0)
					{
						buttonEdit.Properties.Buttons[0].Kind = ButtonPredefines.Glyph;
						buttonEdit.Properties.Buttons[0].Width = 15;
						buttonEdit.Properties.Buttons[0].Image = Resources.calc_1;
					}
				}
				else if (buttonEdit is IdatDxDateEdit)
				{
					if (buttonEdit.Properties.Buttons.Count > 0)
					{
						buttonEdit.Properties.Buttons[0].Kind = ButtonPredefines.Glyph;
						buttonEdit.Properties.Buttons[0].Width = 15;
						buttonEdit.Properties.Buttons[0].Image = Resources.calendar_1;
					}
				}
				else if (buttonEdit is IdatDxSpinEdit)
				{
					if (buttonEdit.Properties.Buttons.Count > 0)
					{
						IdatDxSpinEdit idatDxSpinEdit = buttonEdit as IdatDxSpinEdit;
						idatDxSpinEdit.Properties.SpinStyle = SpinStyles.Horizontal;
						idatDxSpinEdit.Properties.Buttons[0].Width = 15;
					}
				}
				else if (!(buttonEdit is IdatDxColorEdit) && !(buttonEdit is IdatDxImageComboBoxEdit))
				{
				}
				buttonEdit.Properties.EndUpdate();
			}
			if (cons is IdatDxLookUpEdit)
			{
				IdatDxLookUpEdit idatDxLookUpEdit = cons as IdatDxLookUpEdit;
				idatDxLookUpEdit.Properties.BeginUpdate();
				idatDxLookUpEdit.ToolTip = ((_PGLAN == PROGRAM_LANGUENGE.KOREA) ? LOC_LookUP : ENG_LookUP);
				idatDxLookUpEdit.Properties.CloseUpKey = new KeyShortcut(Keys.F4);
				EditorButton editorButton2 = iDATDevExpress_GridControl.SetButtonAdd(idatDxLookUpEdit, 15, Resources.init_1);
				editorButton2.Tag = "INIT";
				editorButton2.ToolTip = ((_PGLAN == PROGRAM_LANGUENGE.KOREA) ? LOC_Init : ENG_Init);
				idatDxLookUpEdit.ButtonClick += lookupCon_ButtonClick;
				idatDxLookUpEdit.Properties.PopupWidth = 450;
				idatDxLookUpEdit.Properties.AllowNullInput = DefaultBoolean.True;
				if (idatDxLookUpEdit != null && idatDxLookUpEdit.Properties.Columns.Count > 0)
				{
					foreach (LookUpColumnInfo column2 in idatDxLookUpEdit.Properties.Columns)
					{
						string strCaptionText = column2.FieldName;
						if (this.IDAT_ChangedCaptionStringEvent != null)
						{
							this.IDAT_ChangedCaptionStringEvent(ref strCaptionText);
						}
						column2.Caption = strCaptionText;
					}
				}
				idatDxLookUpEdit.Properties.EndUpdate();
			}
			if (cons is IdatDxSpinEdit)
			{
				IdatDxSpinEdit idatDxSpinEdit2 = cons as IdatDxSpinEdit;
				idatDxSpinEdit2.Properties.BeginUpdate();
				EditorButton editorButton2 = new EditorButton();
				editorButton2.Kind = ButtonPredefines.Glyph;
				editorButton2.Width = 15;
				editorButton2.Image = Resources.init_1;
				editorButton2.Tag = "INIT";
				editorButton2.ToolTip = ((_PGLAN == PROGRAM_LANGUENGE.KOREA) ? LOC_Init : ENG_Init);
				idatDxSpinEdit2.Properties.Buttons.Add(editorButton2);
				idatDxSpinEdit2.ButtonClick += lookupCon_ButtonClick;
				idatDxSpinEdit2.Properties.EndUpdate();
			}
			if (cons is IdatDxGridLookUpEdit)
			{
				IdatDxGridLookUpEdit idatDxGridLookUpEdit = cons as IdatDxGridLookUpEdit;
				idatDxGridLookUpEdit.Properties.BeginUpdate();
				idatDxGridLookUpEdit.ToolTip = ((_PGLAN == PROGRAM_LANGUENGE.KOREA) ? LOC_LookUP : ENG_LookUP);
				idatDxGridLookUpEdit.Properties.CloseUpKey = new KeyShortcut(Keys.F4);
				idatDxGridLookUpEdit.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
				EditorButton editorButton2 = iDATDevExpress_GridControl.SetButtonAdd(idatDxGridLookUpEdit, 15, Resources.init_1);
				editorButton2.Tag = "INIT";
				editorButton2.ToolTip = ((_PGLAN == PROGRAM_LANGUENGE.KOREA) ? LOC_Init : ENG_Init);
				idatDxGridLookUpEdit.Properties.NullText = "";
				idatDxGridLookUpEdit.ButtonClick += lookupCon_ButtonClick;
				idatDxGridLookUpEdit.Properties.View.DataSourceChanged += View_DataSourceChanged;
				idatDxGridLookUpEdit.QueryCloseUp += gridUpCon_QueryCloseUp;
				idatDxGridLookUpEdit.Properties.View.OptionsView.ShowAutoFilterRow = true;
				idatDxGridLookUpEdit.Properties.AllowNullInput = DefaultBoolean.True;
				idatDxGridLookUpEdit.Properties.PopupFormSize = new Size(Convert.ToInt16((double)idatDxGridLookUpEdit.Size.Width * 1.7), idatDxGridLookUpEdit.Properties.PopupFormSize.Height);
				idatDxGridLookUpEdit.Properties.AutoComplete = false;
				idatDxGridLookUpEdit.Properties.TextEditStyle = TextEditStyles.Standard;
				idatDxGridLookUpEdit.Properties.View.BestFitColumns();
				idatDxGridLookUpEdit.Properties.EndUpdate();
			}
			if (cons is IdatDxPopupContainerEdit)
			{
				IdatDxPopupContainerEdit idatDxPopupContainerEdit = cons as IdatDxPopupContainerEdit;
				idatDxPopupContainerEdit.Properties.BeginUpdate();
				EditorButton editorButton2 = new EditorButton(ButtonPredefines.Glyph, "", 15, enabled: true, visible: true, isLeft: false, HorzAlignment.Center, Resources.init_1);
				idatDxPopupContainerEdit.Properties.Buttons.Add(editorButton2);
				idatDxPopupContainerEdit.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
				idatDxPopupContainerEdit.ButtonClick += lookupCon_ButtonClick;
				idatDxPopupContainerEdit.Properties.EndUpdate();
			}
			if (cons is IdatDxMemoEdit)
			{
				IdatDxMemoEdit idatDxMemoEdit2 = cons as IdatDxMemoEdit;
				idatDxMemoEdit2.Properties.BeginUpdate();
				if (idatDxMemoEdit2.Properties.MaxLength > 0)
				{
					idatDxMemoEdit2.ToolTip = $"Max Length : {idatDxMemoEdit2.Properties.MaxLength}";
				}
				idatDxMemoEdit2.Properties.EndUpdate();
			}
			if (cons is IdatDxMemoExEdit)
			{
				IdatDxMemoExEdit idatDxMemoExEdit = cons as IdatDxMemoExEdit;
				idatDxMemoExEdit.Properties.BeginUpdate();
				idatDxMemoExEdit.ToolTip = ((_PGLAN == PROGRAM_LANGUENGE.KOREA) ? LOC_MemoExEdit : ENG_MemoExEdit);
				idatDxMemoExEdit.Properties.EndUpdate();
			}
			if (cons is IdatDxDateEdit)
			{
				IdatDxDateEdit idatDxDateEdit = cons as IdatDxDateEdit;
				idatDxDateEdit.Properties.BeginUpdate();
				idatDxDateEdit.EditValue = DateTime.Now;
				idatDxDateEdit.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
				idatDxDateEdit.ToolTip = ((_PGLAN == PROGRAM_LANGUENGE.KOREA) ? LOC_DateEdit : ENG_DateEdit);
				EditorButton editorButton2 = iDATDevExpress_GridControl.SetButtonAdd(idatDxDateEdit, 15, Resources.init_1);
				idatDxDateEdit.Size = new Size(120, 21);
				idatDxDateEdit.Properties.EndUpdate();
			}
			if (cons is IdatDxComboBoxEdit)
			{
				IdatDxComboBoxEdit idatDxComboBoxEdit = cons as IdatDxComboBoxEdit;
				idatDxComboBoxEdit.Properties.BeginUpdate();
				idatDxComboBoxEdit.ToolTip = ((_PGLAN == PROGRAM_LANGUENGE.KOREA) ? LOC_ComboBoxEdit : ENG_ComboBoxEdit);
				if (idatDxComboBoxEdit.Properties.TextEditStyle == TextEditStyles.Standard)
				{
					idatDxComboBoxEdit.EnterMoveNextControl = false;
				}
				idatDxComboBoxEdit.Properties.EndUpdate();
			}
			if (cons is IdatDxTimeEdit || cons is IdatDxTimeEdit)
			{
				IdatDxTimeEdit idatDxTimeEdit = cons as IdatDxTimeEdit;
				idatDxTimeEdit.Properties.BeginUpdate();
				idatDxTimeEdit.ToolTip = ((_PGLAN == PROGRAM_LANGUENGE.KOREA) ? LOC_TimeEdit : ENG_TimeEdit);
				idatDxTimeEdit.Properties.EndUpdate();
			}
			if (cons is IdatDxCheckEdit)
			{
				IdatDxCheckEdit idatDxCheckEdit = cons as IdatDxCheckEdit;
				idatDxCheckEdit.Properties.BeginUpdate();
				idatDxCheckEdit.ToolTip = ((_PGLAN == PROGRAM_LANGUENGE.KOREA) ? LOC_CheckEdit : ENG_CheckEdit);
				string strCaptionText = cons.Text;
				if (this.IDAT_ChangedCaptionStringEvent != null)
				{
					this.IDAT_ChangedCaptionStringEvent(ref strCaptionText);
				}
				cons.Text = strCaptionText;
				idatDxCheckEdit.Properties.EndUpdate();
			}
			if (cons is IdatDxRadioGroup)
			{
				IdatDxRadioGroup idatDxRadioGroup = cons as IdatDxRadioGroup;
				idatDxRadioGroup.Properties.BeginUpdate();
				idatDxRadioGroup.ToolTip = ((_PGLAN == PROGRAM_LANGUENGE.KOREA) ? LOC_RadioGroup : ENG_RadioGroup);
				idatDxRadioGroup.SelectedIndex = 0;
				if (idatDxRadioGroup.Properties.Items.Count > 0)
				{
					foreach (RadioGroupItem item in idatDxRadioGroup.Properties.Items)
					{
						string strCaptionText = item.Description;
						if (this.IDAT_ChangedCaptionStringEvent != null)
						{
							this.IDAT_ChangedCaptionStringEvent(ref strCaptionText);
						}
						item.Description = strCaptionText;
					}
				}
				idatDxRadioGroup.Properties.EndUpdate();
			}
			if (cons is IdatDxCalcEdit)
			{
				IdatDxCalcEdit idatDxCalcEdit = cons as IdatDxCalcEdit;
				idatDxCalcEdit.Properties.BeginUpdate();
				idatDxCalcEdit.Properties.ShowCloseButton = true;
				idatDxCalcEdit.Properties.EndUpdate();
			}
			if (cons is IdatDxPictureEdit)
			{
				IdatDxPictureEdit idatDxPictureEdit = cons as IdatDxPictureEdit;
				idatDxPictureEdit.Properties.BeginUpdate();
				idatDxPictureEdit.Properties.ShowMenu = false;
				idatDxPictureEdit.Properties.EndUpdate();
			}
		}
		catch
		{
		}
	}

	public string GetTagINFO(Control control, string tagInfo)
	{
		if (control.Tag != null)
		{
			if (control.Tag.ToString().IndexOf(",") > -1)
			{
				if (control.Tag.ToString().IndexOf(":") == -1)
				{
					return "";
				}
				string[] array = control.Tag.ToString().Split(',');
				string[] array2 = array;
				foreach (string text in array2)
				{
					if (text.Split(':')[0].ToLower().Trim() == tagInfo.ToLower().Trim())
					{
						return text.Split(':')[1].ToString();
					}
				}
				return "";
			}
			if (control.Tag.ToString().IndexOf(":") == -1)
			{
				return "";
			}
			if (control.Tag.ToString().Split(':')[0].ToLower() == tagInfo.ToLower())
			{
				return control.Tag.ToString().Split(':')[1].ToString();
			}
			return "";
		}
		return "";
	}

	private Control[] GetAllControls(Control containerControl)
	{
		List<Control> list = new List<Control>();
		Queue<Control.ControlCollection> queue = new Queue<Control.ControlCollection>();
		queue.Enqueue(containerControl.Controls);
		while (queue.Count > 0)
		{
			Control.ControlCollection controlCollection = queue.Dequeue();
			if (controlCollection == null || controlCollection.Count == 0)
			{
				continue;
			}
			foreach (Control item in controlCollection)
			{
				list.Add(item);
				queue.Enqueue(item.Controls);
			}
		}
		return list.ToArray();
	}

	private Control[] GetAllLayoutControls(Control containerControl)
	{
		List<Control> list = new List<Control>();
		Queue<Control.ControlCollection> queue = new Queue<Control.ControlCollection>();
		queue.Enqueue(containerControl.Controls);
		while (queue.Count > 0)
		{
			Control.ControlCollection controlCollection = queue.Dequeue();
			if (controlCollection == null || controlCollection.Count == 0)
			{
				continue;
			}
			foreach (Control item in controlCollection)
			{
				if (item is LayoutControl)
				{
					list.Add(item);
					queue.Enqueue(item.Controls);
				}
			}
		}
		return list.ToArray();
	}

	private void ebtnCon_ButtonClick(object sender, ButtonPressedEventArgs e)
	{
		if (e.Button.Kind == ButtonPredefines.Glyph && sender is ButtonEdit)
		{
			ButtonEdit buttonEdit = sender as ButtonEdit;
			if (buttonEdit.Properties.PasswordChar != 0)
			{
				IDAT_VKeyBoard iDAT_VKeyBoard = new IDAT_VKeyBoard(buttonEdit, isPassword: true);
				iDAT_VKeyBoard.ShowDialog();
			}
			else
			{
				IDAT_VKeyBoard iDAT_VKeyBoard = new IDAT_VKeyBoard(buttonEdit, isPassword: false);
				iDAT_VKeyBoard.ShowDialog();
			}
		}
	}

	private void gridV_Click(object sender, EventArgs e)
	{
		if (!(sender is GridView))
		{
			return;
		}
		GridView gridView = sender as GridView;
		GridHitInfo clickHitInfo = new IDATDevExpress_GridControl().GetClickHitInfo(gridView, e);
		if (!clickHitInfo.InColumn || !(clickHitInfo.Column.FieldName == "CHK"))
		{
			return;
		}
		clickHitInfo.Column.OptionsColumn.AllowSort = DefaultBoolean.False;
		if (gridView.RowCount <= 0)
		{
			return;
		}
		bool flag = false;
		for (int i = 0; i < gridView.RowCount; i++)
		{
			if (gridView.GetDataRow(i)["CHK"].ToString() == "False")
			{
				flag = true;
				break;
			}
		}
		for (int i = 0; i < gridView.RowCount; i++)
		{
			if (flag)
			{
				gridView.SetRowCellValue(i, "CHK", true);
			}
			else
			{
				gridView.SetRowCellValue(i, "CHK", false);
			}
		}
	}

	private void gridV_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
	{
		if (e.Column != null && e.Column.FieldName == "CHK")
		{
			e.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
			e.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Underline);
			e.Appearance.BackColor = Color.Yellow;
			e.Appearance.ForeColor = Color.Red;
		}
	}

	public void gridV_DataSourceChanged(object sender, EventArgs e)
	{
		GridView gridView = sender as GridView;
		IDATDevExpress_GridControl iDATDevExpress_GridControl = new IDATDevExpress_GridControl();
		if (gridView == null)
		{
			return;
		}
		if (sender is BandedGridView)
		{
			BandedGridView bandedGridView = sender as BandedGridView;
			foreach (GridBand band in bandedGridView.Bands)
			{
				string strCaptionText = band.Caption;
				if (this.IDAT_ChangedCaptionStringEvent != null)
				{
					this.IDAT_ChangedCaptionStringEvent(ref strCaptionText);
				}
				band.Caption = strCaptionText;
				if (band.Children.Count <= 0)
				{
					continue;
				}
				for (int i = 0; i < band.Children.Count; i++)
				{
					string strCaptionText2 = band.Children[i].Caption;
					if (this.IDAT_ChangedCaptionStringEvent != null)
					{
						this.IDAT_ChangedCaptionStringEvent(ref strCaptionText2);
					}
					band.Children[i].Caption = strCaptionText2;
				}
			}
		}
		RepositoryItemSpinEdit columnEdit = new RepositoryItemSpinEdit();
		foreach (GridColumn column in gridView.Columns)
		{
			if (column.ColumnType.ToString() == "System.Int32" || column.ColumnType.ToString() == "System.Decimal" || column.ColumnType.ToString() == "System.Byte" || column.ColumnType.ToString() == "System.Long" || column.ColumnType.ToString() == "System.Double")
			{
				string text = "";
				string text2 = "";
				if (column.ColumnType.ToString() == "System.Double")
				{
					text = "n0";
					text2 = "{0:n0}";
				}
				else
				{
					text = "n0";
					text2 = "{0:n0}";
				}
				if (column.DisplayFormat.FormatType == FormatType.None)
				{
					column.DisplayFormat.FormatType = FormatType.Numeric;
				}
				if (column.DisplayFormat.FormatString == "")
				{
					column.DisplayFormat.FormatString = "n0";
				}
				if (column.ColumnEdit == null)
				{
					column.ColumnEdit = columnEdit;
					column.ColumnEdit.EditFormat.FormatString = "{0:n0}";
					column.ColumnEdit.EditFormat.FormatType = FormatType.Numeric;
				}
				if (column.SummaryItem.DisplayFormat == "")
				{
					column.SummaryItem.DisplayFormat = "{0:n0}";
				}
				if (column.SummaryItem.SummaryType == DevExpress.Data.SummaryItemType.None)
				{
					column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
				}
			}
			if (column.Caption == "")
			{
				string strCaptionText = column.FieldName;
				if (this.IDAT_ChangedCaptionStringEvent != null)
				{
					this.IDAT_ChangedCaptionStringEvent(ref strCaptionText);
				}
				column.ToolTip = strCaptionText;
				column.Caption = strCaptionText;
			}
			column.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
		}
		try
		{
			if (gridView.OptionsView.ShowFooter)
			{
				iDATDevExpress_GridControl.SetTotalSummaryItems(gridView, gridView.VisibleColumns[0].AbsoluteIndex, DevExpress.Data.SummaryItemType.Count, "Total:{0}");
			}
		}
		catch
		{
		}
	}

	private void gridV_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			if (e.Button == MouseButtons.Right)
			{
				Point point = new Point(e.X, e.Y);
				GridView gridView = sender as GridView;
				GridHitInfo gridHitInfo = gridView.CalcHitInfo(point);
				if (gridHitInfo.InRow)
				{
					((DXMouseEventArgs)e).Handled = true;
					return;
				}
				GridColumn info = gridView.Columns[0];
				GridViewColumnMenu gridViewColumnMenu = new GridViewColumnMenu(gridView);
				gridViewColumnMenu.Init(info);
				gridViewColumnMenu.Show(point);
				((DXMouseEventArgs)e).Handled = true;
			}
		}
		catch
		{
		}
	}

	private void gridV_KeyDown(object sender, KeyEventArgs e)
	{
		try
		{
			GridView gridView = sender as GridView;
			if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.Insert) && !gridView.IsEditing)
			{
				gridView.CopyToClipboard();
				string text = Clipboard.GetText();
				if (!(text == ""))
				{
					Clipboard.SetText(Clipboard.GetText().Trim());
					e.Handled = true;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private void gridV_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
	{
		GridView gridView = sender as GridView;
		string text = (string)gridView.Tag;
		if (text != null && text.Length > 0 && text.IndexOf(":") != -1)
		{
			string[] array = text.Split(':');
			if (e.Info.IsRowIndicator && e.RowHandle >= 0 && array[0].ToLower().Trim() == "showrownum" && array[1].ToLower().Trim() == "t")
			{
				e.Info.DisplayText = (e.RowHandle + 1).ToString();
			}
		}
	}

	private void gridV_RowCountChanged(object sender, EventArgs e)
	{
		GridView gridView = (GridView)sender;
		string text = (string)gridView.Tag;
		if (text != null && text.Length > 0 && text.IndexOf(":") != -1)
		{
			string[] array = text.Split(':');
			if (array[0].ToLower().Trim() == "showrownum" && array[1].ToLower().Trim() == "t" && gridView.GridControl.IsHandleCreated)
			{
				Graphics graphics = Graphics.FromHwnd(gridView.GridControl.Handle);
				gridView.IndicatorWidth = Convert.ToInt32(graphics.MeasureString(gridView.RowCount.ToString(), gridView.PaintAppearance.Row.GetFont()).Width + 0.999f) + GridPainter.Indicator.ImageSize.Width + 10;
			}
		}
	}

	private void gridV_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		try
		{
			GridView gridView = null;
			if (!(sender is GridView))
			{
				return;
			}
			gridView = sender as GridView;
			if (gridView.GetSelectedCells().Length <= 0)
			{
				return;
			}
			int visibleIndex = gridView.GetSelectedCells()[0].Column.VisibleIndex;
			int rowHandle = gridView.GetSelectedCells()[0].RowHandle;
			decimal num = 0m;
			decimal count = 0m;
			GridCell[] selectedCells = gridView.GetSelectedCells();
			foreach (GridCell gridCell in selectedCells)
			{
				decimal result = 0m;
				if (gridCell.Column.UnboundType == UnboundColumnType.Bound && decimal.TryParse("0" + gridView.GetDataRow(gridCell.RowHandle)[gridCell.Column.FieldName].ToString(), out result))
				{
					num += result;
					++count;
				}
			}
			if (num > 0m && this.IDAT_SelectionSummaryEvent != null)
			{
				this.IDAT_SelectionSummaryEvent(count, num);
			}
		}
		catch (Exception)
		{
		}
	}

	private string GetSelectedValues(GridView view)
	{
		if (view.SelectedRowsCount == 0)
		{
			return "";
		}
		string text = "";
		if (view.GetSelectedRows().Length <= 0)
		{
			return "";
		}
		int rowHandle = view.GetSelectedRows()[0];
		if (view.GetSelectedCells(rowHandle).Length <= 0)
		{
			return "";
		}
		int visibleIndex = view.GetSelectedCells(rowHandle)[0].VisibleIndex;
		return string.Concat(view.GetRowCellValue(rowHandle, view.VisibleColumns[visibleIndex]));
	}

	public void gridV_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
	{
		GridView gridView = sender as GridView;
		if (e.Column.OptionsColumn.AllowEdit && gridView.Editable)
		{
			e.Appearance.BackColor = Color.FromArgb(255, 255, 204);
			e.Appearance.BackColor2 = Color.FromArgb(255, 255, 102);
			e.Appearance.ForeColor = Color.Black;
		}
	}

	private void View_DataSourceChanged(object sender, EventArgs e)
	{
		if (!(sender is GridView gridView) || gridView.Columns.Count <= 0)
		{
			return;
		}
		gridView.BestFitMaxRowCount = 100;
		gridView.BestFitColumns();
		foreach (GridColumn column in gridView.Columns)
		{
			string strCaptionText = column.FieldName;
			if (this.IDAT_ChangedCaptionStringEvent != null)
			{
				this.IDAT_ChangedCaptionStringEvent(ref strCaptionText);
			}
			column.Caption = strCaptionText;
			column.ToolTip = strCaptionText;
			column.OptionsColumn.AllowSort = DefaultBoolean.False;
			column.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
		}
	}

	private void lookupCon_ButtonClick(object sender, ButtonPressedEventArgs e)
	{
		if (e.Button.Kind != ButtonPredefines.Glyph)
		{
			return;
		}
		if (sender is LookUpEditBase)
		{
			LookUpEditBase lookUpEditBase = sender as LookUpEditBase;
			if (lookUpEditBase.Enabled && !lookUpEditBase.Properties.ReadOnly)
			{
				lookUpEditBase.EditValue = null;
			}
		}
		else if (sender is IdatDxPopupContainerEdit)
		{
			IdatDxPopupContainerEdit idatDxPopupContainerEdit = sender as IdatDxPopupContainerEdit;
			idatDxPopupContainerEdit.EditValue = null;
		}
		else if (sender is IdatDxSpinEdit)
		{
			IdatDxSpinEdit idatDxSpinEdit = sender as IdatDxSpinEdit;
			idatDxSpinEdit.EditValue = null;
		}
		if (sender is IdatDxGridLookUpEdit)
		{
			IdatDxGridLookUpEdit idatDxGridLookUpEdit = sender as IdatDxGridLookUpEdit;
			if (idatDxGridLookUpEdit.Enabled && !idatDxGridLookUpEdit.Properties.ReadOnly)
			{
				idatDxGridLookUpEdit.EditValue = null;
				idatDxGridLookUpEdit.Properties.View.ClearColumnsFilter();
			}
		}
	}

	private void gridUpCon_QueryCloseUp(object sender, CancelEventArgs e)
	{
		IdatDxGridLookUpEdit idatDxGridLookUpEdit = sender as IdatDxGridLookUpEdit;
		idatDxGridLookUpEdit.Properties.View.ApplyFindFilter(idatDxGridLookUpEdit.Text);
		idatDxGridLookUpEdit.Properties.View.ApplyFindFilter("");
	}
}
