# UI 컴포넌트 가이드

## 개요

HAENGSUNG HNSMES는 DevExpress WinForms 컨트롤을 기반으로 한 UI를 사용합니다. 본 문서는 주요 UI 컴포넌트의 사용법과 모범 사례를 설명합니다.

---

## DevExpress GridControl

### 기본 사용법

```csharp
// GridControl 선언
private DevExpress.XtraGrid.GridControl gcList;
private DevExpress.XtraGrid.Views.Grid.GridView gvList;
```

### 데이터 바인딩

```csharp
// ✅ 방법 1: 간단한 바인딩
public void BindGridSimple()
{
    DataTable dt = GetDataFromDatabase();
    gcList.DataSource = dt;
}

// ✅ 방법 2: DXGridHelper 사용 (권장)
public void BindGridWithHelper()
{
    BASE_DXGridHelper.Bind_Grid(
        gcList,                                    // GridControl
        "PKGPRD_PROD.GET_WORKORDER_LIST",         // 프로시저명
        1,                                         // 오버로드 번호
        new string[] { "A_CLIENT", "A_COMPANY" }, // 파라미터명
        new object[] { Global_Variable.CLIENT,    // 파라미터값
                      Global_Variable.COMPANY }
    );
}

// ✅ 방법 3: 고급 바인딩
public void BindGridAdvanced()
{
    BASE_DXGridHelper.Bind_Grid_Int(
        gcList,
        "PKGPRD_PROD.GET_WORKORDER_LIST",
        1,
        new string[] { "A_CLIENT", "A_COMPANY", "A_PLANT" },
        new object[] { Global_Variable.CLIENT,
                      Global_Variable.COMPANY,
                      Global_Variable.PLANT },
        true,                                      // Summary 표시
        "QTY,AMOUNT",                             // Summary 컬럼
        true,                                      // BestFitColumns
        "SEQ,ID"                                  // 정수형 컬럼
    );
}
```

### 컬럼 설정

```csharp
// ✅ 컬럼 속성 설정
private void ConfigureGridColumns()
{
    // 그리드 뷰 설정
    gvList.OptionsView.ShowGroupPanel = false;      // 그룹 패널 숨김
    gvList.OptionsView.ShowAutoFilterRow = true;     // 필터 행 표시
    gvList.OptionsView.ColumnAutoWidth = false;      // 컬럼 자동 너비 비활성화
    gvList.OptionsBehavior.Editable = false;         // 읽기 전용
    
    // 특정 컬럼 설정
    GridColumn colWoNo = gvList.Columns["WONO"];
    colWoNo.Caption = "작업지시번호";
    colWoNo.Width = 120;
    colWoNo.Fixed = FixedStyle.Left;                // 좌측 고정
    
    GridColumn colQty = gvList.Columns["QTY"];
    colQty.Caption = "수량";
    colQty.DisplayFormat.FormatType = FormatType.Numeric;
    colQty.DisplayFormat.FormatString = "#,##0";
    colQty.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
}
```

### 그리드 이벤트 처리

```csharp
// ✅ 행 클릭 이벤트
private void gvList_Click(object sender, EventArgs e)
{
    // 클릭 위치 정보 가져오기
    GridHitInfo hitInfo = gvList.CalcHitInfo(gcList.PointToClient(Control.MousePosition));
    
    if (hitInfo.InRow && hitInfo.RowHandle >= 0)
    {
        // 선택된 행 데이터 가져오기
        DataRow row = gvList.GetDataRow(hitInfo.RowHandle);
        string woNo = row["WONO"].ToString();
        string itemCode = row["ITEMCODE"].ToString();
        
        // 상세 정보 표시
        LoadDetail(woNo);
    }
}

// ✅ 셀 값 변경 이벤트
private void gvList_CellValueChanged(object sender, 
    DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
{
    if (e.Column.FieldName == "QTY")
    {
        // 수량 변경 시 금액 재계산
        decimal qty = Convert.ToDecimal(e.Value);
        decimal price = Convert.ToDecimal(gvList.GetRowCellValue(e.RowHandle, "PRICE"));
        gvList.SetRowCellValue(e.RowHandle, "AMOUNT", qty * price);
    }
}

// ✅ 행 스타일 변경
private void gvList_RowStyle(object sender, RowStyleEventArgs e)
{
    if (e.RowHandle < 0) return;
    
    DataRow row = gvList.GetDataRow(e.RowHandle);
    if (row == null) return;
    
    // 조건에 따른 행 스타일 변경
    string status = row["STATUS"].ToString();
    if (status == "COMPLETE")
    {
        e.Appearance.BackColor = Color.LightGreen;
    }
    else if (status == "HOLD")
    {
        e.Appearance.BackColor = Color.LightYellow;
    }
}
```

### 선택 및 체크박스

```csharp
// ✅ 체크박스 컬럼 추가
private void AddCheckboxColumn()
{
    // RepositoryItemCheckEdit 생성
    RepositoryItemCheckEdit chkEdit = new RepositoryItemCheckEdit();
    chkEdit.NullStyle = StyleIndeterminate.Unchecked;
    chkEdit.ValueChecked = "Y";
    chkEdit.ValueUnchecked = "N";
    
    // 컬럼 추가
    GridColumn colSel = new GridColumn();
    colSel.FieldName = "SEL";
    colSel.Caption = "선택";
    colSel.ColumnEdit = chkEdit;
    colSel.VisibleIndex = 0;
    colSel.Width = 40;
    
    gvList.Columns.Add(colSel);
    gcList.RepositoryItems.Add(chkEdit);
}

// ✅ 선택된 행 가져오기
private List<DataRow> GetSelectedRows()
{
    List<DataRow> selectedRows = new List<DataRow>();
    
    for (int i = 0; i < gvList.RowCount; i++)
    {
        DataRow row = gvList.GetDataRow(i);
        if (row != null && row["SEL"].ToString() == "Y")
        {
            selectedRows.Add(row);
        }
    }
    
    return selectedRows;
}
```

---

## 공통 컨트롤

### TextEdit (텍스트 입력)

```csharp
// ✅ 기본 설정
private void ConfigureTextEdit()
{
    // 폼 로드 시 초기화
    txtWoNo.Properties.MaxLength = 20;           // 최대 길이
    txtWoNo.Properties.CharacterCasing = CharacterCasing.Upper;  // 대문자 변환
    
    // 필수 입력 표시
    txtWoNo.Tag = "WONO|Y";  // 컬럼명|필수여부
}

// ✅ 데이터 바인딩
private void BindTextEdit()
{
    // 그리드와 양방향 바인딩
    txtWoNo.DataBindings.Add("EditValue", gcList.DataSource, "WONO");
}

// ✅ 유효성 검사
private void txtWoNo_Validating(object sender, CancelEventArgs e)
{
    if (string.IsNullOrEmpty(txtWoNo.Text.Trim()))
    {
        dxErrorProvider.SetError(txtWoNo, "작업지시번호는 필수입니다.");
        e.Cancel = true;
    }
    else
    {
        dxErrorProvider.SetError(txtWoNo, null);
    }
}
```

### DateEdit (날짜 입력)

```csharp
// ✅ 기본 설정
private void ConfigureDateEdit()
{
    // 날짜 형식 설정
    dtWorkDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
    dtWorkDate.Properties.DisplayFormat.FormatType = FormatType.DateTime;
    dtWorkDate.Properties.EditFormat.FormatString = "yyyy-MM-dd";
    dtWorkDate.Properties.EditFormat.FormatType = FormatType.DateTime;
    
    // 편집 마스크 설정
    dtWorkDate.Properties.Mask.EditMask = "yyyy-MM-dd";
    dtWorkDate.Properties.Mask.UseMaskAsDisplayFormat = true;
    
    // 기본값 설정
    dtWorkDate.EditValue = DateTime.Today;
    
    // 날짜 범위 제한
    dtWorkDate.Properties.MinValue = new DateTime(2020, 1, 1);
    dtWorkDate.Properties.MaxValue = DateTime.Today.AddDays(30);
}

// ✅ 날짜 범위 검증
private bool ValidateDateRange()
{
    DateTime fromDate = (DateTime)dtFromDate.EditValue;
    DateTime toDate = (DateTime)dtToDate.EditValue;
    
    if (fromDate > toDate)
    {
        MessageBox.Show("시작일자는 종료일자보다 클 수 없습니다.");
        dtFromDate.Focus();
        return false;
    }
    
    if ((toDate - fromDate).Days > 90)
    {
        MessageBox.Show("조회 기간은 90일을 초과할 수 없습니다.");
        return false;
    }
    
    return true;
}
```

### ComboBoxEdit (콤보박스)

```csharp
// ✅ 기본 설정
private void ConfigureComboBox()
{
    // 콤보박스 아이템 추가
    cboStatus.Properties.Items.AddRange(new string[] { 
        "ALL", "PENDING", "PROGRESS", "COMPLETE", "HOLD" });
    
    // 기본 선택
    cboStatus.SelectedIndex = 0;
    
    // 편집 비활성화 (선택만 가능)
    cboStatus.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
}

// ✅ 데이터 소스 바인딩
private void BindComboBoxFromDatabase()
{
    WSResults result = BASE_db.Execute_Proc(
        "PKGSYS_COMM.GET_CODE_LIST",
        1,
        new string[] { "A_CLIENT", "A_COMPANY", "A_GROUPCODE" },
        new object[] { Global_Variable.CLIENT, 
                      Global_Variable.COMPANY, "WO_STATUS" }
    );
    
    if (result.ResultInt == 0 && result.ResultDataSet.Tables.Count > 0)
    {
        cboStatus.Properties.DataSource = result.ResultDataSet.Tables[0];
        cboStatus.Properties.DisplayMember = "CODENAME";
        cboStatus.Properties.ValueMember = "CODE";
        cboStatus.Properties.NullText = "[선택]";
    }
}

// ✅ 선택값 사용
private void ProcessSelection()
{
    string selectedValue = cboStatus.EditValue?.ToString();
    string selectedText = cboStatus.Text;
    
    if (string.IsNullOrEmpty(selectedValue))
    {
        MessageBox.Show("상태를 선택하세요.");
        return;
    }
}
```

### GridLookUpEdit (그리드 룩업)

```csharp
// ✅ 기본 설정
private void ConfigureGridLookUp()
{
    // 데이터 소스 설정
    BASE_DXGridLookUpHelper.Bind_GridLookUp(
        gluItemCode,                    // GridLookUpEdit
        "PKGMST_ITEM.GET_ITEM_LIST",    // 프로시저
        1,
        new string[] { "A_CLIENT", "A_COMPANY" },
        new object[] { Global_Variable.CLIENT, Global_Variable.COMPANY },
        "ITEMCODE|ITEMNAME|SPEC",       // 표시 컬럼
        "ITEMCODE",                     // ValueMember
        "ITEMCODE"                      // EditValue
    );
    
    // 뷰 설정
    gluItemCode.Properties.View.OptionsView.ShowAutoFilterRow = true;
    gluItemCode.Properties.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
    gluItemCode.Properties.NullText = "[품목 선택]";
}

// ✅ 선택 이벤트 처리
private void gluItemCode_EditValueChanged(object sender, EventArgs e)
{
    string itemCode = gluItemCode.EditValue?.ToString();
    
    if (!string.IsNullOrEmpty(itemCode))
    {
        // 품목 상세 정보 조회
        LoadItemDetail(itemCode);
    }
}
```

---

## Base.Form 기능

### 기본 폼 상속

```csharp
// ✅ Base.Form 상속
public partial class PRDA201 : HAENGSUNG_HNSMES_UI.Forms.BASE.Form, itfButton
{
    public PRDA201()
    {
        InitializeComponent();
    }
}
```

### 버튼 설정

```csharp
// ✅ 버튼 표시 설정
public PRDA201()
{
    InitializeComponent();
    
    // 버튼 가시성 설정
    this.ShowInitButton = true;      // 초기화 버튼
    this.ShowSearchButton = true;    // 검색 버튼
    this.ShowNewbutton = true;       // 신규 버튼
    this.ShowEditButton = true;      // 수정 버튼
    this.ShowSaveButton = true;      // 저장 버튼
    this.ShowDeleteButton = true;    // 삭제 버튼
    this.ShowPrintButton = false;    // 출력 버튼
    this.ShowRefreshButton = true;   // 새로고침 버튼
    this.ShowCloseButton = true;     // 닫기 버튼
}
```

### 편집 상태 관리

```csharp
// ✅ 편집 상태 변경
public void NewButton_Click()
{
    // 신규 모드로 변경
    base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New);
    
    // 초기값 설정
    txtWoNo.Text = GetNewWoNo();
    dtWorkDate.EditValue = DateTime.Today;
}

public void EditButton_Click()
{
    // 수정 모드로 변경
    base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit);
}

public void InitButton_Click()
{
    // 초기화 모드로 변경
    base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);
    
    // 화면 초기화
    ClearForm();
    LoadData();
}
```

### 유효성 검사 통합

```csharp
// ✅ 폼 수준 유효성 검사
public void SaveButton_Click()
{
    // 1. 오류 프로바이더 초기화
    baseDxErrorProvider.ClearErrors();
    
    // 2. 컨트롤 유효성 검사
    ValidateChildren(ValidationConstraints.Visible);
    
    // 3. 오류 확인
    if (baseDxErrorProvider.HasErrors)
    {
        MessageBox.Show("입력값을 확인하세요.", "확인", 
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }
    
    // 4. 저장 로직
    SaveData();
}
```

---

## itfButton 인터페이스

### 인터페이스 구현

```csharp
public partial class PRDA201 : Forms.BASE.Form, itfButton
{
    // itfButton 인터페이스 메서드 구현
    
    public void InitButton_Click()
    {
        // 초기화 버튼 클릭 시 실행
        ClearForm();
        LoadData();
        base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.None);
    }
    
    public void NewButton_Click()
    {
        // 신규 버튼 클릭 시 실행
        MainButton_Save.PerformClick();  // 기존 데이터 저장
        base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.New);
        BASE_clsDevexpressGridUtil.AddNewRow(gvList);
    }
    
    public void EditButton_Click()
    {
        // 수정 버튼 클릭 시 실행
        base.Update_ItemsEditing(this, IDAT.Devexpress.FORM.UPDATEITEMTYPE.Edit);
    }
    
    public void StopButton_Click()
    {
        // 정지 버튼 클릭 시 실행
        if (MessageBox.Show("작업을 취소하시겠습니까?", "확인", 
            MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            InitButton_Click();
        }
    }
    
    public void SearchButton_Click()
    {
        // 검색 버튼 클릭 시 실행
        LoadData();
    }
    
    public void SaveButton_Click()
    {
        // 저장 버튼 클릭 시 실행
        if (!ValidateInput()) return;
        
        DataTable changes = BASE_clsDevexpressGridUtil.GetChangedData(gcList);
        if (changes.Rows.Count == 0)
        {
            MessageBox.Show("변경된 데이터가 없습니다.");
            return;
        }
        
        SaveData(changes);
        InitButton_Click();
    }
    
    public void PrintButton_Click()
    {
        // 출력 버튼 클릭 시 실행
        gcList.ShowPrintPreview();
    }
    
    public void RefreshButton_Click()
    {
        // 새로고침 버튼 클릭 시 실행
        LoadData();
    }
    
    public void DeleteButton_Click()
    {
        // 삭제 버튼 클릭 시 실행
        if (gvList.FocusedRowHandle < 0) return;
        
        if (MessageBox.Show("삭제하시겠습니까?", "확인", 
            MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            DeleteData();
        }
    }
}
```

---

## 데이터 바인딩 패턴

### 그리드-폼 양방향 바인딩

```csharp
// ✅ DXGridHelper를 사용한 바인딩
private void BindGridAndForm()
{
    // 그리드 바인딩
    BASE_DXGridHelper.Bind_Grid(
        gcList,
        "PKGPRD_PROD.GET_WORKORDER_LIST",
        1,
        new string[] { "A_CLIENT", "A_COMPANY" },
        new object[] { Global_Variable.CLIENT, Global_Variable.COMPANY }
    );
    
    // 폼 컨트롤에 그리드 데이터 바인딩
    // 컨트롤의 Tag 속성에 "ColumnName|IsRequired" 형식으로 설정
    txtWoNo.Tag = "WONO|Y";
    txtItemCode.Tag = "ITEMCODE|Y";
    dtWorkDate.Tag = "WORKDATE|Y";
    numQty.Tag = "QTY|N";
}

// ✅ 컨트롤에 데이터 바인딩
private void gvList_FocusedRowChanged(object sender, 
    DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
{
    if (e.FocusedRowHandle < 0) return;
    
    DataRow row = gvList.GetDataRow(e.FocusedRowHandle);
    if (row == null) return;
    
    // 수동 바인딩
    txtWoNo.Text = row["WONO"].ToString();
    txtItemCode.Text = row["ITEMCODE"].ToString();
    dtWorkDate.EditValue = row["WORKDATE"];
    numQty.Value = Convert.ToDecimal(row["QTY"]);
}
```

### 변경 데이터 추적

```csharp
// ✅ 그리드 변경 데이터 가져오기
public void SaveButton_Click()
{
    // 추가/수정/삭제된 모든 변경사항 가져오기
    DataTable changes = BASE_clsDevexpressGridUtil.GetChangedData(gcList);
    
    // 특정 상태의 변경사항만 가져오기
    DataTable modified = gvList.EX_GetChangedData(DataRowState.Modified);
    DataTable added = gvList.EX_GetChangedData(DataRowState.Added);
    DataTable deleted = gvList.EX_GetChangedData(DataRowState.Deleted);
    
    foreach (DataRow row in changes.Rows)
    {
        switch (row.RowState)
        {
            case DataRowState.Added:
                InsertData(row);
                break;
            case DataRowState.Modified:
                UpdateData(row);
                break;
            case DataRowState.Deleted:
                // 삭제된 행 처리
                break;
        }
    }
}
```

---

## LayoutControl 사용

### 기본 설정

```csharp
// ✅ LayoutControl 설정
private void ConfigureLayoutControl()
{
    // 레이아웃 저장/복원 가능
    layoutControl1.SaveLayoutToXml("layout.xml");
    layoutControl1.RestoreLayoutFromXml("layout.xml");
    
    // 탭 이동 설정
    layoutControl1.OptionsFocus.MoveFocusDirection = MoveFocusDirection.AcrossThenDown;
}
```

### 레이아웃 아이템 설정

```csharp
// ✅ 코드로 레이아웃 아이템 생성
private void CreateLayoutItem()
{
    // 텍스트 입력 아이템
    LayoutControlItem itemWoNo = new LayoutControlItem();
    itemWoNo.Name = "layoutItemWoNo";
    itemWoNo.Text = "작업지시번호";
    itemWoNo.Control = txtWoNo;
    itemWoNo.TextLocation = Locations.Left;
    itemWoNo.TextSize = new Size(80, 14);
    
    layoutControl1.Root.Add(itemWoNo);
}
```

---

## 메시지 및 다이얼로그

### 표준 메시지

```csharp
// ✅ 확인 메시지
DialogResult result = MessageBox.Show(
    "저장하시겠습니까?",
    "확인",
    MessageBoxButtons.YesNoCancel,
    MessageBoxIcon.Question);

if (result == DialogResult.Yes)
{
    SaveData();
}

// ✅ 오류 메시지
MessageBox.Show(
    "저장 중 오류가 발생했습니다.",
    "오류",
    MessageBoxButtons.OK,
    MessageBoxIcon.Error);

// ✅ 정보 메시지
MessageBox.Show(
    "저장되었습니다.",
    "확인",
    MessageBoxButtons.OK,
    MessageBoxIcon.Information);
```

### 커스텀 메시지

```csharp
// ✅ IDATMessageBox 사용
IDAT.WebService.Access.WSResults result = BASE_db.Execute_Proc(...);
iDATMessageBox.ShowProcResultMessage(
    result,           // WSResults 객체
    "Error",          // 메시지 유형
    Global_Variable.USER_ID,  // 사용자 ID
    "PKGPRD_PROD.SET_WORKORDER",  // 프로시저명
    parameters        // 파라미터 딕셔너리
);
```

---

## 팝업 폼

### 팝업 열기

```csharp
// ✅ 모달 팝업
private void OpenPopup()
{
    using (POP_PRD01 popup = new POP_PRD01())
    {
        popup.StartPosition = FormStartPosition.CenterParent;
        
        // 파라미터 전달
        popup.WoNo = txtWoNo.Text;
        popup.ItemCode = txtItemCode.Text;
        
        if (popup.ShowDialog(this) == DialogResult.OK)
        {
            // 팝업에서 반환된 값 처리
            string result = popup.ResultValue;
            LoadData();
        }
    }
}

// ✅ 비모달 팝업
private void OpenNonModalPopup()
{
    POP_PRD01 popup = new POP_PRD01();
    popup.FormClosed += (s, e) => { LoadData(); };
    popup.Show(this);
}
```

---

## 성능 최적화

### 그리드 최적화

```csharp
// ✅ 대용량 데이터 처리
gvList.BeginUpdate();
try
{
    gcList.DataSource = largeDataTable;
    gvList.BestFitColumns();
}
finally
{
    gvList.EndUpdate();
}

// ✅ 가상 모드 사용 (매우 대용량 데이터)
gvList.OptionsBehavior.CacheValuesOnRowUpdating = CacheRowValuesMode.Enabled;
gvList.OptionsView.RowAutoHeight = false;
```

### 화면 업데이트 최적화

```csharp
// ✅ Suspend/Resume Layout
this.SuspendLayout();
try
{
    // 다수의 컨트롤 업데이트
    foreach (var control in Controls)
    {
        // 업데이트
    }
}
finally
{
    this.ResumeLayout(true);
}
```

---

## 체크리스트

UI 개발 시 다음 사항을 확인하세요:

- [ ] Base.Form을 상속받았는가?
- [ ] itfButton 인터페이스를 구현했는가?
- [ ] 컨트롤의 Tag 속성이 올바르게 설정되었는가?
- [ ] 유효성 검사가 적용되었는가?
- [ ] dxErrorProvider를 사용하여 오류를 표시하는가?
- [ ] 데이터 바인딩이 올바르게 설정되었는가?
- [ ] 그리드 컬럼이 적절히 설정되었는가?
- [ ] Null 값 처리가 되어 있는가?
- [ ] 성능을 위해 BeginUpdate/EndUpdate를 사용했는가?
