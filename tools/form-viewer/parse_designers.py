"""
@file tools/form-viewer/parse_designers.py
@description HNSMES Designer.cs 파서 - DevExpress LayoutControl 기반 폼을 JSON으로 변환 후 HTML 생성

초보자 가이드:
1. 실행: python parse_designers.py
2. 결과: form-viewer.html 생성
3. 열기: 브라우저에서 form-viewer.html 열기
"""

import os
import re
import json
import sys

# --- 설정 ---
FORMS_DIR = os.path.join(os.path.dirname(__file__), '..', '..', 'HAENGSUNG_HNSMES_UI', 'Forms')
TEMPLATE_FILE = os.path.join(os.path.dirname(__file__), 'template.html')
OUTPUT_FILE = os.path.join(os.path.dirname(__file__), 'form-viewer.html')
MENU_TREE_FILE = os.path.join(os.path.dirname(__file__), '..', '..', 'MENU_TREE_STRUCTURE.md')

# 컨트롤 타입 매핑 (필드명 접두사 또는 C# 타입에서 추론)
TYPE_MAP = {
    'GridControl': 'GridControl',
    'GridView': 'GridView',
    'LayoutControl': 'LayoutControl',
    'LayoutControlGroup': 'LayoutControlGroup',
    'LayoutControlItem': 'LayoutControlItem',
    'TabbedControlGroup': 'TabbedControlGroup',
    'SplitterItem': 'SplitterItem',
    'EmptySpaceItem': 'EmptySpaceItem',
    'SimpleSeparator': 'SimpleSeparator',
    'SimpleLabelItem': 'SimpleLabelItem',
    'ButtonEdit': 'TextEdit',
    'TextEdit': 'TextEdit',
    'IdatDxTextEdit': 'TextEdit',
    'IdatDxButtonEdit': 'TextEdit',
    'MemoEdit': 'MemoEdit',
    'IdatDxMemoEdit': 'MemoEdit',
    'SpinEdit': 'SpinEdit',
    'IdatDxSpinEdit': 'SpinEdit',
    'DateEdit': 'DateEdit',
    'IdatDxDateEdit': 'DateEdit',
    'ComboBoxEdit': 'ComboBox',
    'IdatDxComboBoxEdit': 'ComboBox',
    'LookUpEdit': 'LookUpEdit',
    'GridLookUpEdit': 'GridLookUpEdit',
    'IdatDxGridLookUpEdit': 'GridLookUpEdit',
    'CheckEdit': 'CheckEdit',
    'RadioGroup': 'RadioGroup',
    'IdatDxRadioGroup': 'RadioGroup',
    'SimpleButton': 'Button',
    'IdatDxSimpleButton': 'Button',
    'PictureEdit': 'PictureEdit',
    'IdatDxPictureEdit': 'PictureEdit',
    'CheckBox': 'CheckEdit',
    'RepositoryItemComboBox': 'ComboBox',
    'BarEditItem': 'BarEditItem',
    'XucFromToDate': 'DateRangeControl',
}

def parse_event_handlers(init_body):
    """InitializeComponent에서 이벤트 핸들러 등록 추출

    패턴: this.컨트롤명.이벤트 += new ...EventHandler(this.핸들러명)
    폼 레벨: this.Load += new ...EventHandler(this.FORM_Load)
    """
    event_map = {}      # { 컨트롤명: [{ event, handler }] }
    form_events = []    # [{ event, handler }] (폼 레벨)

    # 컨트롤 이벤트: this.ctrl.Event += new ...Handler(this.method)
    for m in re.finditer(
        r'this\.(\w+)\.(\w+)\s*\+=\s*new\s+[\w\.]+(?:EventHandler|CancelEventHandler|RowStyleEventHandler'
        r'|RowAllowEventHandler|FocusedRowChangedEventHandler|ClosedEventHandler'
        r'|KeyEventHandler|ColumnFilterChangedEventHandler|CustomDrawCellEventHandler'
        r'|RepositoryItemCheckEdit\.CheckedChangedEventHandler'
        r'|CustomColumnSortEventHandler|FocusedColumnChangedEventHandler'
        r'|ShowingEditorEventHandler|CellValueChangedEventHandler'
        r'|CustomRowCellEditEventHandler|ValidatingEditorEventHandler'
        r'|InvalidValueExceptionEventHandler|ProcessNewRowEventHandler'
        r'|CalcCellValueEventHandler|ConvertEditValueEventHandler'
        r'|CustomSummaryEventHandler)\s*\(\s*this\.(\w+)\s*\)',
        init_body
    ):
        ctrl_name = m.group(1)
        event_name = m.group(2)
        handler_name = m.group(3)
        if ctrl_name not in event_map:
            event_map[ctrl_name] = []
        event_map[ctrl_name].append({'event': event_name, 'handler': handler_name})

    # 폼 레벨 이벤트: this.Load += new ...Handler(this.method)
    for m in re.finditer(
        r'(?<!\.)this\.(Load|Shown|KeyDown|FormClosing|FormClosed|Activated|Resize)\s*\+=\s*'
        r'new\s+[\w\.]+(?:EventHandler|KeyEventHandler|FormClosingEventHandler|FormClosedEventHandler)'
        r'\s*\(\s*this\.(\w+)\s*\)',
        init_body
    ):
        event_name = m.group(1)
        handler_name = m.group(2)
        form_events.append({'event': event_name, 'handler': handler_name})

    return event_map, form_events


def extract_method_body(content, method_name):
    """메서드 시그니처를 찾아 본문을 추출 (브레이스 매칭)"""
    # private/public/protected void/bool/... method_name(...)
    pattern = re.compile(
        r'(?:private|public|protected|internal)\s+(?:(?:virtual|override|static|async)\s+)*'
        r'[\w<>\[\]\.]+\s+' + re.escape(method_name)
        + r'\s*\([^)]*\)',
        re.DOTALL
    )
    match = pattern.search(content)
    if not match:
        return None
    start = match.end()
    brace_pos = content.find('{', start)
    if brace_pos == -1 or brace_pos - start > 50:
        return None
    depth = 1
    pos = brace_pos + 1
    while pos < len(content) and depth > 0:
        if content[pos] == '{':
            depth += 1
        elif content[pos] == '}':
            depth -= 1
        pos += 1
    return content[brace_pos + 1:pos - 1]


def parse_handler_calls(codebehind_content, handler_names):
    """코드비하인드에서 핸들러 메서드 본문을 분석하여 주요 호출 패턴 추출

    반환: { handler_name: [{ type, detail }] }
    """
    result = {}
    for handler_name in handler_names:
        body = extract_method_body(codebehind_content, handler_name)
        if body is None:
            continue
        calls = []

        # db_proc: BASE_db.Execute_Proc("프로시저명"
        for m in re.finditer(r'BASE_db\.Execute_Proc\s*\(\s*"([^"]+)"', body):
            calls.append({'type': 'db_proc', 'detail': m.group(1)})

        # popup: new PopUp.XXX(
        for m in re.finditer(r'new\s+PopUp\.(\w+)\s*\(', body):
            calls.append({'type': 'popup', 'detail': m.group(1)})

        # close: this.Close()
        if re.search(r'this\.Close\s*\(\s*\)', body):
            calls.append({'type': 'close', 'detail': 'this.Close()'})

        # message: iDATMessageBox.XXXMessage(
        for m in re.finditer(r'iDATMessageBox\.(\w+Message)\s*\(', body):
            calls.append({'type': 'message', 'detail': m.group(1)})

        # dialog_result: DialogResult = ...Yes/OK
        for m in re.finditer(r'DialogResult\s*=\s*(?:System\.Windows\.Forms\.)?DialogResult\.(\w+)', body):
            calls.append({'type': 'dialog_result', 'detail': m.group(1)})

        # grid_bind: BASE_DXGridHelper.Bind_Grid(
        for m in re.finditer(r'BASE_DXGridHelper\.\w+\s*\(\s*(\w+)', body):
            calls.append({'type': 'grid_bind', 'detail': m.group(1)})

        # lookup_bind: BASE_DXGridLookUpHelper.Bind_GridLookUpEdit(
        for m in re.finditer(r'BASE_DXGridLookUpHelper\.\w+\s*\(\s*(\w+)', body):
            calls.append({'type': 'lookup_bind', 'detail': m.group(1)})

        # perform_click: XXX.PerformClick()
        for m in re.finditer(r'(\w+)\.PerformClick\s*\(\s*\)', body):
            calls.append({'type': 'perform_click', 'detail': m.group(1)})

        # internal_call: 직접 메서드 호출 (this.Method() 또는 Method())
        for m in re.finditer(r'(?:this\.)?((?:Get|Set|Save|Init|Load|Print|Delete|Insert|Update|Check|Validate|Search|Refresh|Clear|Reset|Bind|Fill|Export|Import)\w*)\s*\(', body):
            detail = m.group(1)
            # 이미 다른 타입으로 분류된 것 제외
            if not any(c['detail'] == detail for c in calls):
                calls.append({'type': 'internal_call', 'detail': detail})

        # 직접 핸들러 호출: this.btnXXX_Click(this, null)
        for m in re.finditer(r'this\.(\w+_\w+)\s*\(\s*this\s*,\s*null\s*\)', body):
            calls.append({'type': 'perform_click', 'detail': m.group(1) + '()'})

        # 중복 제거
        seen = set()
        unique_calls = []
        for c in calls:
            key = (c['type'], c['detail'])
            if key not in seen:
                seen.add(key)
                unique_calls.append(c)

        result[handler_name] = unique_calls

    return result


def classify_type(csharp_type):
    """C# 타입 문자열에서 컨트롤 분류를 반환 (긴 키 우선 매칭)"""
    # 긴 키를 먼저 체크하여 'LayoutControl'이 'LayoutControlGroup'보다 먼저 매칭되지 않도록
    for key in sorted(TYPE_MAP.keys(), key=len, reverse=True):
        if key in csharp_type:
            return TYPE_MAP[key]
    return 'Unknown'


def parse_menu_descriptions():
    """MENU_TREE_STRUCTURE.md에서 폼 ID -> 설명 매핑 추출"""
    desc_map = {}
    if not os.path.exists(MENU_TREE_FILE):
        return desc_map
    with open(MENU_TREE_FILE, 'r', encoding='utf-8') as f:
        content = f.read()
    # 패턴: FORMID ─+ 설명
    for m in re.finditer(r'([A-Z_][A-Z0-9_]+)\s+─+\s+(.+)', content):
        form_id = m.group(1).strip()
        desc = m.group(2).strip()
        desc_map[form_id] = desc
    return desc_map


def extract_init_component(content):
    """InitializeComponent() 메서드 본문 추출"""
    # 시작 찾기
    match = re.search(r'private\s+void\s+InitializeComponent\s*\(\s*\)', content)
    if not match:
        return None
    start = match.end()
    # 첫 번째 { 찾기
    brace_pos = content.find('{', start)
    if brace_pos == -1:
        return None
    # 매칭 } 찾기
    depth = 1
    pos = brace_pos + 1
    while pos < len(content) and depth > 0:
        if content[pos] == '{':
            depth += 1
        elif content[pos] == '}':
            depth -= 1
        pos += 1
    return content[brace_pos + 1:pos - 1]


def parse_field_declarations(content):
    """필드 선언에서 name -> C# type 매핑 추출"""
    fields = {}
    # private [Type] fieldName;
    for m in re.finditer(
        r'private\s+([\w\.]+(?:<[\w\.]+>)?)\s+(\w+)\s*[;=]', content
    ):
        csharp_type = m.group(1)
        name = m.group(2)
        fields[name] = csharp_type
    return fields


def parse_designer(filepath):
    """단일 Designer.cs 파일을 파싱하여 폼 데이터 반환"""
    with open(filepath, 'r', encoding='utf-8-sig') as f:
        content = f.read()

    # 클래스명 추출
    class_match = re.search(r'partial\s+class\s+(\w+)', content)
    class_name = class_match.group(1) if class_match else os.path.basename(filepath).replace('.Designer.cs', '')

    # 네임스페이스에서 모듈 추출
    ns_match = re.search(r'namespace\s+[\w\.]+\.Forms\.(\w+)', content)
    module = ns_match.group(1) if ns_match else 'Unknown'

    # 필드 선언 파싱
    fields = parse_field_declarations(content)

    # InitializeComponent 추출
    init_body = extract_init_component(content)
    if not init_body:
        return None

    # 컨트롤 속성 파싱
    controls = {}

    # 1단계: Items.AddRange / TabPages.AddRange 여러 줄 블록을 미리 추출
    # 이 패턴들은 여러 줄에 걸쳐 있으므로 init_body 전체에서 매칭
    items_map = {}   # ctrl_name -> [child_names]
    tabs_map = {}    # ctrl_name -> [tab_names]

    for m in re.finditer(
        r'this\.(\w+)\.Items\.AddRange\s*\(new\s+DevExpress[^{]*\{([^}]*)\}\s*\)',
        init_body, re.DOTALL
    ):
        ctrl_name = m.group(1)
        block = m.group(2)
        children = re.findall(r'this\.(\w+)', block)
        items_map[ctrl_name] = children

    for m in re.finditer(
        r'this\.(\w+)\.TabPages\.AddRange\s*\(new\s+DevExpress[^{]*\{([^}]*)\}\s*\)',
        init_body, re.DOTALL
    ):
        ctrl_name = m.group(1)
        block = m.group(2)
        children = re.findall(r'this\.(\w+)', block)
        tabs_map[ctrl_name] = children

    # 2단계: Root 참조 미리 추출
    root_map = {}  # layout_ctrl -> root_group
    for m in re.finditer(r'this\.(\w+)\.Root\s*=\s*this\.(\w+)\s*;', init_body):
        root_map[m.group(1)] = m.group(2)

    # 3단계: Control 참조 미리 추출
    ctrl_ref_map = {}  # layout_item -> control_name
    for m in re.finditer(r'this\.(\w+)\.Control\s*=\s*this\.(\w+)\s*;', init_body):
        ctrl_ref_map[m.group(1)] = m.group(2)

    # 4단계: 줄 단위 속성 파싱
    current_ctrl = None

    for line in init_body.split('\n'):
        line = line.strip()

        # 주석 블록에서 컨트롤명 식별
        name_comment = re.match(r'^//\s+(\w+)\s*$', line)
        if name_comment:
            ctrl_name = name_comment.group(1)
            if ctrl_name in fields or ctrl_name == class_name:
                current_ctrl = ctrl_name
                if ctrl_name not in controls and ctrl_name != class_name:
                    ctype = fields.get(ctrl_name, 'Unknown')
                    controls[ctrl_name] = {
                        'name': ctrl_name,
                        'csharpType': ctype,
                        'type': classify_type(ctype),
                        'properties': {}
                    }
            continue

        # this.Name = "FORMNAME" -> 폼 속성
        form_name_m = re.match(r'this\.Name\s*=\s*"([^"]+)"', line)
        if form_name_m and current_ctrl == class_name:
            continue

        # this.Text = "FormTitle"
        form_text_m = re.match(r'this\.Text\s*=\s*"([^"]+)"', line)
        if form_text_m and current_ctrl == class_name:
            controls['__form__'] = controls.get('__form__', {'properties': {}})
            controls['__form__']['properties']['Text'] = form_text_m.group(1)
            continue

        # this.ClientSize = new System.Drawing.Size(W, H)
        client_size_m = re.match(r'this\.ClientSize\s*=\s*new\s+System\.Drawing\.Size\((\d+),\s*(\d+)\)', line)
        if client_size_m and current_ctrl == class_name:
            controls['__form__'] = controls.get('__form__', {'properties': {}})
            controls['__form__']['properties']['ClientSize'] = {
                'width': int(client_size_m.group(1)),
                'height': int(client_size_m.group(2))
            }
            continue

        if not current_ctrl or current_ctrl == class_name:
            continue
        if current_ctrl not in controls:
            continue

        ctrl = controls[current_ctrl]
        props = ctrl['properties']

        # this.ctrl.Property = value 패턴들
        prop_line = line
        if not prop_line.startswith('this.'):
            continue

        # Items.AddRange, TabPages.AddRange는 이미 1단계에서 처리했으므로 건너뛰기
        if '.Items.AddRange' in prop_line or '.TabPages.AddRange' in prop_line:
            continue

        # Location
        loc_m = re.match(r'this\.\w+\.Location\s*=\s*new\s+System\.Drawing\.Point\((\d+),\s*(\d+)\)', prop_line)
        if loc_m:
            props['Location'] = {'x': int(loc_m.group(1)), 'y': int(loc_m.group(2))}
            continue

        # Size
        size_m = re.match(r'this\.\w+\.Size\s*=\s*new\s+System\.Drawing\.Size\((\d+),\s*(\d+)\)', prop_line)
        if size_m:
            props['Size'] = {'width': int(size_m.group(1)), 'height': int(size_m.group(2))}
            continue

        # Text
        text_m = re.match(r'this\.\w+\.Text\s*=\s*"([^"]*)"', prop_line)
        if text_m:
            props['Text'] = text_m.group(1)
            continue

        # Name
        name_m = re.match(r'this\.\w+\.Name\s*=\s*"([^"]*)"', prop_line)
        if name_m:
            props['Name'] = name_m.group(1)
            continue

        # TextVisible
        tv_m = re.match(r'this\.\w+\.TextVisible\s*=\s*(true|false)', prop_line)
        if tv_m:
            props['TextVisible'] = tv_m.group(1) == 'true'
            continue

        # TextSize
        ts_m = re.match(r'this\.\w+\.TextSize\s*=\s*new\s+System\.Drawing\.Size\((\d+),\s*(\d+)\)', prop_line)
        if ts_m:
            props['TextSize'] = {'width': int(ts_m.group(1)), 'height': int(ts_m.group(2))}
            continue

        # TextToControlDistance
        ttcd_m = re.match(r'this\.\w+\.TextToControlDistance\s*=\s*(\d+)', prop_line)
        if ttcd_m:
            props['TextToControlDistance'] = int(ttcd_m.group(1))
            continue

        # Dock
        dock_m = re.match(r'this\.\w+\.Dock\s*=\s*System\.Windows\.Forms\.DockStyle\.(\w+)', prop_line)
        if dock_m:
            props['Dock'] = dock_m.group(1)
            continue

        # CustomizationFormText (useful label)
        cft_m = re.match(r'this\.\w+\.CustomizationFormText\s*=\s*"([^"]*)"', prop_line)
        if cft_m:
            props['CustomizationFormText'] = cft_m.group(1)
            continue

        # GroupBordersVisible
        gbv_m = re.match(r'this\.\w+\.GroupBordersVisible\s*=\s*(true|false)', prop_line)
        if gbv_m:
            props['GroupBordersVisible'] = gbv_m.group(1) == 'true'
            continue

        # Visibility
        vis_m = re.match(r'this\.\w+\.Visibility\s*=\s*DevExpress\.XtraLayout\.Utils\.LayoutVisibility\.(\w+)', prop_line)
        if vis_m:
            props['Visibility'] = vis_m.group(1)
            continue

    # 5단계: 미리 추출한 Items/TabPages/Root/Control 참조를 controls에 반영
    for ctrl_name, children in items_map.items():
        if ctrl_name in controls:
            controls[ctrl_name]['properties']['Items'] = children
    for ctrl_name, children in tabs_map.items():
        if ctrl_name in controls:
            controls[ctrl_name]['properties']['TabPages'] = children
    for layout_ctrl, root_group in root_map.items():
        if layout_ctrl in controls:
            controls[layout_ctrl]['properties']['Root'] = root_group
    for layout_item, control_name in ctrl_ref_map.items():
        if layout_item in controls:
            controls[layout_item]['properties']['Control'] = control_name

    # 폼 전체 속성
    form_props = controls.pop('__form__', {}).get('properties', {})
    form_text = form_props.get('Text', class_name)
    client_size = form_props.get('ClientSize', {'width': 884, 'height': 552})

    # 이벤트 핸들러 파싱
    event_map, form_events = parse_event_handlers(init_body)

    # 코드비하인드 파일에서 핸들러 본문 분석
    codebehind_path = filepath.replace('.Designer.cs', '.cs')
    handler_calls = {}
    if os.path.exists(codebehind_path):
        with open(codebehind_path, 'r', encoding='utf-8-sig') as f:
            codebehind_content = f.read()
        # 모든 핸들러 이름 수집
        all_handler_names = set()
        for events in event_map.values():
            for ev in events:
                all_handler_names.add(ev['handler'])
        for ev in form_events:
            all_handler_names.add(ev['handler'])
        handler_calls = parse_handler_calls(codebehind_content, all_handler_names)

    # 이벤트에 호출 정보 병합
    for ctrl_name, events in event_map.items():
        for ev in events:
            ev['calls'] = handler_calls.get(ev['handler'], [])
    for ev in form_events:
        ev['calls'] = handler_calls.get(ev['handler'], [])

    # 레이아웃 트리 구성
    layout_root = None
    for cname, ctrl in controls.items():
        if ctrl['type'] == 'LayoutControl' and 'Root' in ctrl['properties']:
            layout_root = ctrl['properties']['Root']
            break

    # 탭 유무, 스플리터 유무 → 레이아웃 타입 결정
    has_tabs = any(c['type'] == 'TabbedControlGroup' for c in controls.values())
    has_splitter = any(c['type'] == 'SplitterItem' for c in controls.values())

    if has_tabs:
        layout_type = 'Tabbed'
    elif has_splitter:
        layout_type = 'Master-Detail'
    else:
        layout_type = 'Simple'

    # 레이아웃 트리를 재귀적으로 구성
    def build_tree(node_name, depth=0):
        if depth > 20:
            return None
        ctrl = controls.get(node_name)
        if not ctrl:
            return None

        node = {
            'name': node_name,
            'type': ctrl['type'],
            'csharpType': ctrl.get('csharpType', ''),
            'text': ctrl['properties'].get('Text', ctrl['properties'].get('CustomizationFormText', '')),
            'location': ctrl['properties'].get('Location'),
            'size': ctrl['properties'].get('Size'),
            'textVisible': ctrl['properties'].get('TextVisible', True),
            'textSize': ctrl['properties'].get('TextSize'),
            'groupBordersVisible': ctrl['properties'].get('GroupBordersVisible', True),
            'visibility': ctrl['properties'].get('Visibility', 'Always'),
            'children': [],
        }

        # LayoutControlItem → Control 참조 추가
        if ctrl['type'] == 'LayoutControlItem' and 'Control' in ctrl['properties']:
            ref_name = ctrl['properties']['Control']
            ref_ctrl = controls.get(ref_name)
            if ref_ctrl:
                node['controlRef'] = {
                    'name': ref_name,
                    'type': ref_ctrl['type'],
                    'csharpType': ref_ctrl.get('csharpType', ''),
                    'location': ref_ctrl['properties'].get('Location'),
                    'size': ref_ctrl['properties'].get('Size'),
                    'text': ref_ctrl['properties'].get('Text', ''),
                    'events': event_map.get(ref_name, []),
                }

        # Items (LayoutControlGroup 자식)
        if 'Items' in ctrl['properties']:
            for child_name in ctrl['properties']['Items']:
                child_node = build_tree(child_name, depth + 1)
                if child_node:
                    node['children'].append(child_node)

        # TabPages (TabbedControlGroup 탭)
        if 'TabPages' in ctrl['properties']:
            node['tabPages'] = []
            for tab_name in ctrl['properties']['TabPages']:
                tab_node = build_tree(tab_name, depth + 1)
                if tab_node:
                    node['tabPages'].append(tab_node)

        return node

    tree = build_tree(layout_root) if layout_root else None

    return {
        'id': class_name,
        'module': module,
        'title': form_text,
        'clientSize': client_size,
        'layoutType': layout_type,
        'layoutTree': tree,
        'controlCount': sum(1 for c in controls.values()
                           if c['type'] not in ('LayoutControl', 'LayoutControlGroup',
                                                'LayoutControlItem', 'TabbedControlGroup',
                                                'EmptySpaceItem', 'SplitterItem',
                                                'SimpleSeparator', 'SimpleLabelItem',
                                                'GridView', 'BarEditItem')),
        'filepath': os.path.relpath(filepath, os.path.join(FORMS_DIR, '..', '..')),
        'formEvents': form_events,
    }


def is_report_form(filepath):
    """RPT 모듈의 XtraReports 기반 폼인지 확인"""
    module_dir = os.path.basename(os.path.dirname(filepath))
    if module_dir == 'PopUp':
        module_dir = os.path.basename(os.path.dirname(os.path.dirname(filepath)))
    return module_dir.upper() == 'RPT'


# XtraReports 컨트롤 타입 매핑
XR_TYPE_MAP = {
    'XRLabel': 'Label',
    'XRBarCode': 'BarCode',
    'XRTable': 'Table',
    'XRTableRow': 'TableRow',
    'XRTableCell': 'TableCell',
    'XRLine': 'Line',
    'XRPictureBox': 'PictureBox',
    'DetailBand': 'Band',
    'TopMarginBand': 'Band',
    'BottomMarginBand': 'Band',
    'GroupHeaderBand': 'Band',
}


def classify_xr_type(csharp_type):
    """C# 타입에서 XtraReports 컨트롤 분류 반환"""
    for key in sorted(XR_TYPE_MAP.keys(), key=len, reverse=True):
        if key in csharp_type:
            return XR_TYPE_MAP[key]
    return 'Unknown'


def parse_report_designer(filepath):
    """XtraReports Designer.cs 파일을 파싱하여 리포트 데이터 반환"""
    with open(filepath, 'r', encoding='utf-8-sig') as f:
        content = f.read()

    # 클래스명/모듈 추출
    class_match = re.search(r'partial\s+class\s+(\w+)', content)
    class_name = class_match.group(1) if class_match else os.path.basename(filepath).replace('.Designer.cs', '')

    ns_match = re.search(r'namespace\s+[\w\.]+\.Forms\.(\w+)', content)
    module = ns_match.group(1) if ns_match else 'RPT'

    # 필드 선언 파싱
    fields = parse_field_declarations(content)

    # InitializeComponent 추출
    init_body = extract_init_component(content)
    if not init_body:
        return None

    # --- 컨트롤별 속성 수집 ---
    ctrl_props = {}  # name -> { props dict }

    # LocationFloat: DevExpress.Utils.PointFloat(X, Y)
    for m in re.finditer(
        r'this\.(\w+)\.LocationFloat\s*=\s*new\s+DevExpress\.Utils\.PointFloat\(\s*([\d\.]+)F?\s*,\s*([\d\.]+)F?\s*\)',
        init_body
    ):
        name = m.group(1)
        ctrl_props.setdefault(name, {})['location'] = {
            'x': float(m.group(2)), 'y': float(m.group(3))
        }

    # SizeF: System.Drawing.SizeF(W, H)
    for m in re.finditer(
        r'this\.(\w+)\.SizeF\s*=\s*new\s+System\.Drawing\.SizeF\(\s*([\d\.]+)F?\s*,\s*([\d\.]+)F?\s*\)',
        init_body
    ):
        name = m.group(1)
        ctrl_props.setdefault(name, {})['size'] = {
            'width': float(m.group(2)), 'height': float(m.group(3))
        }

    # DataBindings: XRBinding("Text", null, "TABLE.FIELD")
    for m in re.finditer(
        r'this\.(\w+)\.DataBindings\.AddRange\([^)]*"Text"\s*,\s*null\s*,\s*"([^"]+)"',
        init_body, re.DOTALL
    ):
        name = m.group(1)
        ctrl_props.setdefault(name, {})['binding'] = m.group(2)

    # Font: new System.Drawing.Font("name", size, ...)
    for m in re.finditer(
        r'this\.(\w+)\.Font\s*=\s*new\s+System\.Drawing\.Font\(\s*"([^"]+)"\s*,\s*([\d\.]+)F?',
        init_body
    ):
        name = m.group(1)
        ctrl_props.setdefault(name, {})['font'] = {
            'name': m.group(2), 'size': float(m.group(3))
        }

    # TextAlignment
    for m in re.finditer(
        r'this\.(\w+)\.TextAlignment\s*=\s*DevExpress\.XtraPrinting\.TextAlignment\.(\w+)',
        init_body
    ):
        name = m.group(1)
        ctrl_props.setdefault(name, {})['alignment'] = m.group(2)

    # Name
    for m in re.finditer(r'this\.(\w+)\.Name\s*=\s*"([^"]+)"', init_body):
        name = m.group(1)
        ctrl_props.setdefault(name, {})['nameAttr'] = m.group(2)

    # Text (정적 텍스트)
    for m in re.finditer(r'this\.(\w+)\.Text\s*=\s*"([^"]*)"', init_body):
        name = m.group(1)
        ctrl_props.setdefault(name, {})['text'] = m.group(2)

    # ShowText (바코드)
    for m in re.finditer(r'this\.(\w+)\.ShowText\s*=\s*(true|false)', init_body):
        name = m.group(1)
        ctrl_props.setdefault(name, {})['showText'] = m.group(2) == 'true'

    # Symbology 매핑: 변수명 -> 바코드 타입
    symbology_types = {}
    for m in re.finditer(
        r'(QRCodeGenerator|Code128Generator|DataMatrixGenerator)\s+(\w+)',
        init_body
    ):
        symbology_types[m.group(2)] = m.group(1).replace('Generator', '')

    # Symbology 할당: this.ctrl.Symbology = variable
    for m in re.finditer(r'this\.(\w+)\.Symbology\s*=\s*(\w+)', init_body):
        name = m.group(1)
        var_name = m.group(2)
        sym_type = symbology_types.get(var_name, 'Unknown')
        ctrl_props.setdefault(name, {})['symbology'] = sym_type

    # Weight (테이블 셀 상대 너비)
    for m in re.finditer(r'this\.(\w+)\.Weight\s*=\s*([\d\.]+)D?', init_body):
        name = m.group(1)
        ctrl_props.setdefault(name, {})['weight'] = float(m.group(2))

    # BackColor
    for m in re.finditer(
        r'this\.(\w+)\.BackColor\s*=\s*System\.Drawing\.Color\.(\w+)',
        init_body
    ):
        name = m.group(1)
        ctrl_props.setdefault(name, {})['backColor'] = m.group(2)

    # --- Band 자식 추출 (Controls.AddRange, re.DOTALL) ---
    band_children = {}  # band_name -> [ctrl_names]
    for m in re.finditer(
        r'this\.(\w+)\.Controls\.AddRange\s*\(new\s+DevExpress[^{]*\{([^}]*)\}\s*\)',
        init_body, re.DOTALL
    ):
        band_name = m.group(1)
        block = m.group(2)
        children = re.findall(r'this\.(\w+)', block)
        band_children[band_name] = children

    # XRTable Rows.AddRange
    table_rows = {}  # table_name -> [row_names]
    for m in re.finditer(
        r'this\.(\w+)\.Rows\.AddRange\s*\(new\s+DevExpress[^{]*\{([^}]*)\}\s*\)',
        init_body, re.DOTALL
    ):
        table_name = m.group(1)
        block = m.group(2)
        rows = re.findall(r'this\.(\w+)', block)
        table_rows[table_name] = rows

    # XRTableRow Cells.AddRange
    row_cells = {}  # row_name -> [cell_names]
    for m in re.finditer(
        r'this\.(\w+)\.Cells\.AddRange\s*\(new\s+DevExpress[^{]*\{([^}]*)\}\s*\)',
        init_body, re.DOTALL
    ):
        row_name = m.group(1)
        block = m.group(2)
        cells = re.findall(r'this\.(\w+)', block)
        row_cells[row_name] = cells

    # --- 페이지 속성 ---
    page_width_m = re.search(r'this\.PageWidth\s*=\s*(\d+)', init_body)
    page_height_m = re.search(r'this\.PageHeight\s*=\s*(\d+)', init_body)
    data_member_m = re.search(r'this\.DataMember\s*=\s*"([^"]+)"', init_body)

    page_width = int(page_width_m.group(1)) if page_width_m else 700
    page_height = int(page_height_m.group(1)) if page_height_m else 400
    data_member = data_member_m.group(1) if data_member_m else ''

    # --- reportControls 리스트 조립 ---
    report_controls = []

    # Detail 밴드의 자식 컨트롤 처리
    detail_children = band_children.get('Detail', [])
    # GroupHeader1 자식도 포함
    group_header_children = band_children.get('GroupHeader1', [])

    all_ctrl_names = detail_children + group_header_children

    for ctrl_name in all_ctrl_names:
        csharp_type = fields.get(ctrl_name, '')
        xr_type = classify_xr_type(csharp_type)

        if xr_type == 'Unknown':
            continue

        props = ctrl_props.get(ctrl_name, {})
        ctrl_data = {
            'name': props.get('nameAttr', ctrl_name),
            'type': xr_type,
            'location': props.get('location', {'x': 0, 'y': 0}),
            'size': props.get('size', {'width': 50, 'height': 20}),
            'binding': props.get('binding', ''),
            'text': props.get('text', ''),
            'font': props.get('font'),
            'alignment': props.get('alignment', ''),
            'symbology': props.get('symbology'),
            'showText': props.get('showText'),
            'band': 'GroupHeader' if ctrl_name in group_header_children else 'Detail',
        }
        report_controls.append(ctrl_data)

        # XRTable인 경우 하위 Row → Cell 전개
        if xr_type == 'Table':
            rows = table_rows.get(ctrl_name, [])
            table_loc = props.get('location', {'x': 0, 'y': 0})
            table_size = props.get('size', {'width': 100, 'height': 25})

            for row_name in rows:
                cells = row_cells.get(row_name, [])
                # 셀 위치 계산: weight 기반 상대 배치
                total_weight = sum(
                    ctrl_props.get(cn, {}).get('weight', 1.0) for cn in cells
                )
                cell_x = table_loc['x']
                for cell_name in cells:
                    cell_props = ctrl_props.get(cell_name, {})
                    cell_weight = cell_props.get('weight', 1.0)
                    cell_w = (cell_weight / total_weight) * table_size['width'] if total_weight else 50
                    cell_data = {
                        'name': cell_props.get('nameAttr', cell_name),
                        'type': 'TableCell',
                        'location': {'x': cell_x, 'y': table_loc['y']},
                        'size': {'width': cell_w, 'height': table_size['height']},
                        'binding': cell_props.get('binding', ''),
                        'text': cell_props.get('text', ''),
                        'font': cell_props.get('font'),
                        'alignment': cell_props.get('alignment', ''),
                        'symbology': None,
                        'showText': None,
                        'band': ctrl_data['band'],
                    }
                    report_controls.append(cell_data)
                    cell_x += cell_w

    # 이벤트 파싱 (리포트는 보통 없지만 일관성 위해)
    _, form_events = parse_event_handlers(init_body)

    return {
        'id': class_name,
        'module': module,
        'title': class_name,
        'isReport': True,
        'layoutType': 'Report',
        'pageSize': {'width': page_width, 'height': page_height},
        'dataMember': data_member,
        'reportControls': report_controls,
        'formEvents': form_events,
        'filepath': os.path.relpath(filepath, os.path.join(FORMS_DIR, '..', '..')),
    }


def main():
    print("HNSMES Designer.cs Parser")
    print("=" * 50)

    # 메뉴 설명 로드
    desc_map = parse_menu_descriptions()
    print(f"Menu descriptions loaded: {len(desc_map)} entries")

    # Designer.cs 파일 수집
    designer_files = []
    for root, dirs, files in os.walk(FORMS_DIR):
        # bak 폴더 제외
        dirs[:] = [d for d in dirs if d.lower() != 'bak']
        for f in files:
            if f.endswith('.Designer.cs'):
                designer_files.append(os.path.join(root, f))

    print(f"Found {len(designer_files)} Designer.cs files")

    # 파싱
    forms = []
    errors = []
    for filepath in sorted(designer_files):
        rel = os.path.relpath(filepath, FORMS_DIR)
        try:
            # Base 폴더 제외
            if rel.startswith('Base'):
                continue

            is_rpt = is_report_form(filepath)
            if is_rpt:
                rpt_result = parse_report_designer(filepath)
                if rpt_result:
                    rpt_result['description'] = desc_map.get(rpt_result['id'], '')
                    if rpt_result['description']:
                        rpt_result['title'] = rpt_result['description']
                    ctrl_count = len(rpt_result.get('reportControls', []))
                    forms.append(rpt_result)
                    print(f"  OK: {rel} (Report, {ctrl_count} controls)")
                else:
                    # fallback: 기본 정보만
                    with open(filepath, 'r', encoding='utf-8-sig') as rf:
                        rpt_content = rf.read()
                    class_match = re.search(r'partial\s+class\s+(\w+)', rpt_content)
                    class_name = class_match.group(1) if class_match else os.path.basename(filepath).replace('.Designer.cs', '')
                    forms.append({
                        'id': class_name,
                        'module': 'RPT',
                        'title': desc_map.get(class_name, class_name),
                        'isReport': True,
                        'layoutType': 'Report',
                        'pageSize': {'width': 700, 'height': 400},
                        'dataMember': '',
                        'reportControls': [],
                        'formEvents': [],
                        'filepath': os.path.relpath(filepath, os.path.join(FORMS_DIR, '..', '..')),
                        'description': desc_map.get(class_name, ''),
                    })
                    print(f"  SKIP: {rel} (Report, no InitializeComponent)")
                continue

            result = parse_designer(filepath)
            if result:
                # 설명 추가
                result['description'] = desc_map.get(result['id'], '')
                forms.append(result)
                print(f"  OK: {rel} ({result['layoutType']}, {result['controlCount']} controls)")
            else:
                errors.append((rel, "No InitializeComponent found"))
                print(f"  SKIP: {rel} (no InitializeComponent)")
        except Exception as e:
            errors.append((rel, str(e)))
            print(f"  ERROR: {rel}: {e}")

    # 모듈별 통계
    modules = {}
    for form in forms:
        mod = form['module']
        if mod not in modules:
            modules[mod] = {'count': 0, 'forms': []}
        modules[mod]['count'] += 1
        modules[mod]['forms'].append(form['id'])

    print(f"\nTotal forms parsed: {len(forms)}")
    print(f"Errors: {len(errors)}")
    for mod, info in sorted(modules.items()):
        print(f"  {mod}: {info['count']} forms")

    # HTML 생성
    if not os.path.exists(TEMPLATE_FILE):
        print(f"\nERROR: Template file not found: {TEMPLATE_FILE}")
        sys.exit(1)

    with open(TEMPLATE_FILE, 'r', encoding='utf-8') as f:
        template = f.read()

    # JSON 임베딩
    forms_json = json.dumps(forms, ensure_ascii=False, indent=None)
    html = template.replace('{{FORM_DATA_JSON}}', forms_json)

    with open(OUTPUT_FILE, 'w', encoding='utf-8') as f:
        f.write(html)

    print(f"\nGenerated: {OUTPUT_FILE}")
    print(f"Open in browser to view.")

    if errors:
        print(f"\n--- Errors ---")
        for path, err in errors:
            print(f"  {path}: {err}")


if __name__ == '__main__':
    main()
