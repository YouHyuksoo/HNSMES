#!/usr/bin/env python3
"""
WinForms Designer File Parser and Visualizer
Converts .designer.cs files to HTML or PNG representations
"""

import re
import os
import json
from dataclasses import dataclass, asdict
from typing import List, Optional, Tuple, Dict, Any
from pathlib import Path


@dataclass
class Control:
    """Represents a WinForms control"""
    name: str
    control_type: str
    text: str
    location: Tuple[int, int]
    size: Tuple[int, int]
    parent: str = "this"
    properties: Dict[str, Any] = None
    
    def __post_init__(self):
        if self.properties is None:
            self.properties = {}
    
    def to_dict(self) -> dict:
        return {
            'name': self.name,
            'type': self.control_type,
            'text': self.text,
            'location': self.location,
            'size': self.size,
            'parent': self.parent
        }


class DesignerParser:
    """Parse WinForms .designer.cs files"""
    
    def __init__(self, file_path: str):
        self.file_path = Path(file_path)
        self.controls: List[Control] = []
        self.form_name: str = ""
        self.form_size: Tuple[int, int] = (800, 600)
        self.raw_content: str = ""
        
    def parse(self) -> 'DesignerParser':
        """Parse the designer file and extract controls"""
        with open(self.file_path, 'r', encoding='utf-8', errors='ignore') as f:
            self.raw_content = f.read()
        
        self._extract_form_name()
        self._extract_form_size()
        self._parse_initialize_component()
        
        return self
    
    def _extract_form_name(self):
        """Extract the form class name"""
        patterns = [
            r'class\s+(\w+)\s*:\s*Base\.Form',
            r'class\s+(\w+)\s*:\s*Form',
            r'partial\s+class\s+(\w+)',
            r'class\s+(\w+)\s*:',
        ]
        
        for pattern in patterns:
            match = re.search(pattern, self.raw_content)
            if match:
                self.form_name = match.group(1)
                break
    
    def _extract_form_size(self):
        """Extract form size from ClientSize or Size property"""
        size_patterns = [
            r'this\.ClientSize\s*=\s*new\s+System\.Drawing\.Size\((\d+),\s*(\d+)\)',
            r'this\.Size\s*=\s*new\s+System\.Drawing\.Size\((\d+),\s*(\d+)\)',
        ]
        
        for pattern in size_patterns:
            match = re.search(pattern, self.raw_content)
            if match:
                self.form_size = (int(match.group(1)), int(match.group(2)))
                break
    
    def _parse_initialize_component(self):
        """Parse InitializeComponent method"""
        # Find InitializeComponent method
        init_pattern = r'private\s+void\s+InitializeComponent\(\)\s*\{(.*?)\n\s*//\s*\}|private\s+void\s+InitializeComponent\(\)\s*\{(.*?)\n\s*\}'
        init_match = re.search(init_pattern, self.raw_content, re.DOTALL)
        
        if not init_match:
            # Try alternative pattern
            init_pattern2 = r'void\s+InitializeComponent\(\)\s*\{([^}]+(?:\{[^}]*\}[^}]*)*)\}'
            init_match = re.search(init_pattern2, self.raw_content, re.DOTALL)
        
        if not init_match:
            return
        
        init_body = init_match.group(1) or init_match.group(2) or ""
        
        # Extract control declarations
        decl_pattern = r'private\s+([\w.]+)\s+(\w+)\s*;'
        declarations = re.findall(decl_pattern, self.raw_content)
        
        for ctrl_type, ctrl_name in declarations:
            if ctrl_name in ['components', 'resources']:
                continue
            
            ctrl = self._extract_control_properties(init_body, ctrl_type, ctrl_name)
            if ctrl:
                self.controls.append(ctrl)
    
    def _extract_control_properties(self, body: str, ctrl_type: str, ctrl_name: str) -> Optional[Control]:
        """Extract properties for a specific control"""
        props = {}
        
        # Build regex patterns for this control
        patterns = {
            'location': rf'{re.escape(ctrl_name)}\.Location\s*=\s*new\s+System\.Drawing\.Point\((\d+)\s*,\s*(\d+)\)',
            'size': rf'{re.escape(ctrl_name)}\.Size\s*=\s*new\s+System\.Drawing\.Size\((\d+)\s*,\s*(\d+)\)',
            'text': rf'{re.escape(ctrl_name)}\.Text\s*=\s*"([^"]*)"',
            'parent_add': rf'(\w+)\.Controls\.Add\({re.escape(ctrl_name)}\)',
            'enabled': rf'{re.escape(ctrl_name)}\.Enabled\s*=\s*(\w+)',
            'visible': rf'{re.escape(ctrl_name)}\.Visible\s*=\s*(\w+)',
        }
        
        # Extract location
        loc_match = re.search(patterns['location'], body)
        location = (int(loc_match.group(1)), int(loc_match.group(2))) if loc_match else (0, 0)
        
        # Extract size
        size_match = re.search(patterns['size'], body)
        size = (int(size_match.group(1)), int(size_match.group(2))) if size_match else (100, 23)
        
        # Extract text
        text_match = re.search(patterns['text'], body)
        text = text_match.group(1) if text_match else ctrl_name
        
        # Extract parent
        parent_match = re.search(patterns['parent_add'], body)
        parent = parent_match.group(1) if parent_match else "this"
        
        # Extract other properties
        enabled_match = re.search(patterns['enabled'], body)
        props['enabled'] = enabled_match.group(1) if enabled_match else "true"
        
        visible_match = re.search(patterns['visible'], body)
        props['visible'] = visible_match.group(1) if visible_match else "true"
        
        # Simplify control type name
        simple_type = ctrl_type.split('.')[-1] if '.' in ctrl_type else ctrl_type
        
        return Control(
            name=ctrl_name,
            control_type=simple_type,
            text=text,
            location=location,
            size=size,
            parent=parent,
            properties=props
        )
    
    def to_html(self, scale: float = 1.0) -> str:
        """Generate HTML representation"""
        form_width = int(self.form_size[0] * scale)
        form_height = int(self.form_size[1] * scale)
        
        html = f'''<!DOCTYPE html>
<html lang="ko">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>{self.form_name} - Layout</title>
    <style>
        * {{ box-sizing: border-box; margin: 0; padding: 0; }}
        body {{
            font-family: 'Segoe UI', 'Malgun Gothic', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            padding: 20px;
            min-height: 100vh;
        }}
        .container {{
            max-width: 1200px;
            margin: 0 auto;
        }}
        h1 {{
            color: white;
            text-align: center;
            margin-bottom: 20px;
            font-size: 24px;
            text-shadow: 0 2px 4px rgba(0,0,0,0.2);
        }}
        .form-wrapper {{
            background: white;
            border-radius: 8px;
            box-shadow: 0 10px 40px rgba(0,0,0,0.2);
            overflow: hidden;
            display: inline-block;
        }}
        .form-container {{
            background: #f5f5f5;
            border: 2px solid #333;
            position: relative;
            width: {form_width}px;
            height: {form_height}px;
            overflow: hidden;
        }}
        .form-title {{
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            color: white;
            padding: 8px 12px;
            font-weight: bold;
            font-size: 13px;
            border-bottom: 1px solid #555;
        }}
        .control {{
            position: absolute;
            overflow: hidden;
            cursor: pointer;
            transition: all 0.15s ease;
            display: flex;
            align-items: center;
            justify-content: center;
            box-sizing: border-box;
            /* 기본적으로 텍스트 숨김 */
            color: transparent;
            font-size: 0;
            text-indent: -9999px;
        }}
        /* 텍스트 표시하는 컨트롤 */
        .control.has-text {{
            color: #333;
            font-size: 10px;
            text-indent: 0;
            font-weight: 500;
        }}
        .control:hover {{
            z-index: 10000 !important;
            box-shadow: 0 0 0 3px #0078d4, 0 8px 25px rgba(0,0,0,0.4);
            transform: scale(1.02);
        }}
        /* 호버 시 툴팁 표시 */
        .control::after {{
            content: attr(data-info);
            position: absolute;
            background: #1a1a2e;
            color: white;
            padding: 6px 10px;
            border-radius: 4px;
            font-size: 11px;
            white-space: nowrap;
            opacity: 0;
            pointer-events: none;
            transition: opacity 0.2s;
            z-index: 10001;
            top: 100%;
            left: 50%;
            transform: translateX(-50%);
            margin-top: 5px;
            box-shadow: 0 4px 12px rgba(0,0,0,0.3);
            text-indent: 0;
        }}
        .control:hover::after {{
            opacity: 1;
        }}
        .control-label {{
            background: transparent;
            border: none;
            justify-content: flex-start;
            padding-left: 2px;
        }}
        .control-label.has-text {{
            color: #222;
            font-weight: 600;
            font-size: 11px;
        }}
        .control-button {{
            background: linear-gradient(135deg, #e0e0e0 0%, #c0c0c0 100%);
            border: 1px solid #888;
            border-radius: 4px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.15);
        }}
        .control-button.has-text {{
            color: #333;
            font-weight: 600;
            font-size: 10px;
            text-shadow: 0 1px 0 rgba(255,255,255,0.5);
        }}
        .control-button:hover {{
            background: linear-gradient(135deg, #0078d4 0%, #005a9e 100%);
            border-color: #005a9e;
        }}
        .control-button.has-text:hover {{
            color: white;
            text-shadow: none;
        }}
        .control-textedit {{
            background: #fff;
            border: 1px solid #bbb;
            border-radius: 3px;
            box-shadow: inset 0 2px 4px rgba(0,0,0,0.08);
        }}
        .control-textedit:hover {{
            border-color: #0078d4;
            box-shadow: inset 0 2px 4px rgba(0,0,0,0.08), 0 0 0 2px rgba(0,120,212,0.2);
        }}
        .control-dateedit {{
            background: white;
            border: 1px solid #c0c0c0;
            padding-right: 20px;
            background-image: url("data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' width='16' height='16' viewBox='0 0 16 16'%3E%3Cpath fill='%23666' d='M4 2h8v1H4zm0 3h8v1H4zm0 3h8v1H4zm0 3h8v1H4z'/%3E%3C/svg%3E");
            background-repeat: no-repeat;
            background-position: right 2px center;
        }}
        .control-combobox {{
            background: white;
            border: 1px solid #c0c0c0;
            padding-right: 18px;
            background-image: url("data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' width='12' height='12' viewBox='0 0 12 12'%3E%3Cpath fill='%23666' d='M6 8L1 3h10z'/%3E%3C/svg%3E");
            background-repeat: no-repeat;
            background-position: right 4px center;
        }}
        .control-grid {{
            background: #fafafa;
            border: 2px solid #666;
            border-radius: 2px;
        }}
        /* 그리드 헤더 */
        .control-grid::before {{
            content: '';
            position: absolute;
            top: 0;
            left: 0;
            right: 0;
            height: 24px;
            background: linear-gradient(to bottom, #e8e8e8, #d0d0d0);
            border-bottom: 1px solid #999;
        }}
        /* 그리드 행 표시 */
        .control-grid::after {{
            content: '';
            position: absolute;
            top: 25px;
            left: 0;
            right: 0;
            bottom: 0;
            background: repeating-linear-gradient(
                0deg,
                transparent,
                transparent 20px,
                #eee 20px,
                #eee 21px
            );
        }}
        .control-panel {{
            background: #f8f8f8;
            border: 1px solid #ccc;
            box-shadow: inset 0 0 10px rgba(0,0,0,0.03);
        }}
        .control-panel::before {{
            content: '□';
            position: absolute;
            top: 2px;
            left: 3px;
            font-size: 8px;
            color: #999;
        }}
        .control-group {{
            background: #f5f5f5;
            border: 2px solid #aaa;
            border-radius: 4px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
        }}
        .control-group.has-text {{
            justify-content: flex-start;
            align-items: flex-start;
            padding-top: 6px;
            padding-left: 8px;
        }}
        .control-group.has-text {{
            color: #555;
            font-weight: 700;
            font-size: 10px;
        }}
        .control-checkbox {{
            background: transparent;
            border: none;
            justify-content: flex-start;
            padding-left: 18px;
        }}
        .control-checkbox::before {{
            content: '☐';
            position: absolute;
            left: 2px;
            font-size: 14px;
            color: #555;
        }}
        .control-checkbox.has-text {{
            color: #333;
            font-size: 10px;
        }}
        .control-radio {{
            background: transparent;
            border: none;
            justify-content: flex-start;
            padding-left: 18px;
        }}
        .control-radio::before {{
            content: '○';
            position: absolute;
            left: 3px;
            font-size: 12px;
            color: #555;
        }}
        .control-radio.has-text {{
            color: #333;
            font-size: 10px;
        }}
        .tooltip {{
            position: fixed;
            background: #333;
            color: white;
            padding: 6px 10px;
            border-radius: 4px;
            font-size: 11px;
            pointer-events: none;
            z-index: 10000;
            white-space: nowrap;
            opacity: 0;
            transition: opacity 0.2s;
            box-shadow: 0 2px 8px rgba(0,0,0,0.3);
        }}
        .control:hover .tooltip {{ opacity: 1; }}
        .info {{
            background: white;
            padding: 15px;
            margin-top: 20px;
            border-radius: 8px;
            box-shadow: 0 4px 12px rgba(0,0,0,0.1);
        }}
        .info h3 {{ color: #333; margin-bottom: 10px; }}
        .info table {{ width: 100%; border-collapse: collapse; }}
        .info th, .info td {{ text-align: left; padding: 8px; border-bottom: 1px solid #eee; }}
        .info th {{ color: #666; font-weight: 500; }}
        .stats {{
            display: flex;
            gap: 15px;
            flex-wrap: wrap;
            margin-top: 10px;
        }}
        .stat {{
            background: #f8f9fa;
            padding: 10px 15px;
            border-radius: 6px;
            border-left: 3px solid #667eea;
        }}
        .stat-value {{ font-size: 20px; font-weight: bold; color: #667eea; }}
        .stat-label {{ font-size: 12px; color: #666; }}
    </style>
</head>
<body>
    <div class="container">
        <h1>📱 {self.form_name}</h1>
        <div class="form-wrapper">
            <div class="form-container">
                <div class="form-title">{self.form_name}</div>
'''
        
        # Control CSS classes mapping (includes IdatDx custom controls)
        control_classes = {
            'LabelControl': 'control-label',
            'SimpleButton': 'control-button',
            'TextEdit': 'control-textedit',
            'DateEdit': 'control-dateedit',
            'ComboBoxEdit': 'control-combobox',
            'LookUpEdit': 'control-combobox',
            'GridControl': 'control-grid',
            'PanelControl': 'control-panel',
            'GroupControl': 'control-group',
            'CheckEdit': 'control-checkbox',
            'RadioGroup': 'control-radio',
            'RadioButton': 'control-radio',
            # Idat custom controls
            'IdatDxTextEdit': 'control-textedit',
            'IdatDxSimpleButton': 'control-button',
            'IdatDxDateEdit': 'control-dateedit',
            'IdatDxComboBoxEdit': 'control-combobox',
            'IdatDxLookUpEdit': 'control-combobox',
            'IdatDxCheckEdit': 'control-checkbox',
            'IdatDxRadioGroup': 'control-radio',
            'IdatDxGridControl': 'control-grid',
            'IdatDxPanelControl': 'control-panel',
            'IdatDxGroupControl': 'control-group',
        }
        
        # Generate control HTML (show all controls, not just top-level)
        for ctrl in self.controls:
            
            css_class = control_classes.get(ctrl.control_type, 'control')
            left = int(ctrl.location[0] * scale)
            top = int(ctrl.location[1] * scale) + 35  # Form title offset
            width = max(20, int(ctrl.size[0] * scale))
            height = max(15, int(ctrl.size[1] * scale))
            
            # 컨트롤 타입별 텍스트 표시 여부 결정
            display_text = ''
            show_text = False
            
            if ctrl.control_type in ['SimpleButton', 'IdatDxSimpleButton']:
                # 버튼 - 텍스트 표시 (짧게)
                display_text = ctrl.text if ctrl.text else ctrl.name
                if len(display_text) > 8:
                    display_text = display_text[:7] + '..'
                show_text = True
                
            elif ctrl.control_type in ['LabelControl']:
                # 라벨 - 텍스트 표시
                display_text = ctrl.text if ctrl.text else ''
                if len(display_text) > 20:
                    display_text = display_text[:18] + '..'
                show_text = True
                
            elif ctrl.control_type in ['GroupControl', 'IdatDxGroupControl', 'LayoutControlGroup']:
                # 그룹 타이틀 - 표시
                display_text = ctrl.text if ctrl.text else ''
                if len(display_text) > 15:
                    display_text = display_text[:13] + '..'
                show_text = True
                
            elif ctrl.control_type in ['CheckEdit', 'RadioGroup', 'RadioButton', 'IdatDxCheckEdit', 'IdatDxRadioGroup']:
                # 체크박스/라디오 - 텍스트 표시
                display_text = ctrl.text if ctrl.text else ''
                if len(display_text) > 12:
                    display_text = display_text[:10] + '..'
                show_text = True
            
            # 툴팁 정보 구성 (data-info 속성에 저장)
            info_parts = [f"Type: {ctrl.control_type}", f"Name: {ctrl.name}"]
            if ctrl.text and ctrl.text != ctrl.name:
                info_parts.append(f"Text: {ctrl.text}")
            info_parts.append(f"Size: {ctrl.size[0]}x{ctrl.size[1]}")
            tooltip = " | ".join(info_parts)
            
            # Z-index based on type
            z_index = 10
            if ctrl.control_type in ['PanelControl', 'GroupControl', 'LayoutControl']:
                z_index = 1  # Background elements
            elif ctrl.control_type == 'GridControl':
                z_index = 5
            elif 'Repository' in ctrl.control_type:
                z_index = 3  # Grid internal components
            
            # 텍스트 표시 여부에 따라 클래스 추가
            text_class = 'has-text' if show_text else ''
            
            html += f'''                <div class="control {css_class} {text_class}" 
                     style="left: {left}px; top: {top}px; width: {width}px; height: {height}px; z-index: {z_index};"
                     data-info="{tooltip}" data-type="{ctrl.control_type}" data-name="{ctrl.name}">
                    {display_text}
                </div>
'''
        
        # Control statistics
        control_types = {}
        for c in self.controls:
            control_types[c.control_type] = control_types.get(c.control_type, 0) + 1
        
        html += '''            </div>
        </div>
        <div class="info">
            <h3>📊 Form Information</h3>
            <div class="stats">
                <div class="stat">
                    <div class="stat-value">''' + str(len(self.controls)) + '''</div>
                    <div class="stat-label">Total Controls</div>
                </div>
                <div class="stat">
                    <div class="stat-value">''' + str(self.form_size[0]) + '''×''' + str(self.form_size[1]) + '''</div>
                    <div class="stat-label">Form Size (px)</div>
                </div>
            </div>
            <h3 style="margin-top: 20px;">🎛️ Control Types</h3>
            <table>
                <tr><th>Type</th><th>Count</th></tr>
'''
        
        for ctrl_type, count in sorted(control_types.items(), key=lambda x: -x[1]):
            html += f'                <tr><td>{ctrl_type}</td><td>{count}</td></tr>\n'
        
        html += '''            </table>
        </div>
    </div>
    <script>
        document.querySelectorAll('.control').forEach(el => {
            const tooltip = document.createElement('div');
            tooltip.className = 'tooltip';
            tooltip.textContent = el.getAttribute('title') || el.textContent;
            document.body.appendChild(tooltip);
            
            el.addEventListener('mouseenter', () => {
                const rect = el.getBoundingClientRect();
                tooltip.style.left = rect.left + 'px';
                tooltip.style.top = (rect.bottom + 5) + 'px';
                tooltip.style.opacity = '1';
            });
            
            el.addEventListener('mouseleave', () => {
                tooltip.style.opacity = '0';
            });
        });
    </script>
</body>
</html>'''
        
        return html
    
    def save_html(self, output_path: str, scale: float = 1.0) -> str:
        """Save HTML to file"""
        html = self.to_html(scale)
        
        os.makedirs(os.path.dirname(output_path) if os.path.dirname(output_path) else '.', exist_ok=True)
        
        with open(output_path, 'w', encoding='utf-8') as f:
            f.write(html)
        
        return output_path
    
    def to_image(self, output_path: str, scale: float = 1.0) -> str:
        """Convert to PNG using Playwright"""
        try:
            from playwright.sync_api import sync_playwright
        except ImportError:
            raise ImportError("Playwright not installed. Run: pip install playwright && playwright install chromium")
        
        html_content = self.to_html(scale)
        
        with sync_playwright() as p:
            browser = p.chromium.launch()
            page = browser.new_page()
            page.set_content(html_content)
            page.wait_for_timeout(500)  # Wait for rendering
            
            # Capture form container only
            element = page.locator('.form-wrapper')
            element.screenshot(path=output_path)
            
            browser.close()
        
        return output_path
    
    def to_json(self) -> str:
        """Export controls as JSON"""
        data = {
            'form_name': self.form_name,
            'form_size': self.form_size,
            'controls': [c.to_dict() for c in self.controls]
        }
        return json.dumps(data, indent=2, ensure_ascii=False)


def main():
    """CLI entry point"""
    import argparse
    
    parser = argparse.ArgumentParser(description='Convert WinForms designer files to HTML/PNG')
    parser.add_argument('input', help='Input .designer.cs file')
    parser.add_argument('-o', '--output', help='Output file path')
    parser.add_argument('-f', '--format', choices=['html', 'png', 'json'], default='html', help='Output format')
    parser.add_argument('-s', '--scale', type=float, default=1.0, help='Scale factor (default: 1.0)')
    
    args = parser.parse_args()
    
    # Parse
    designer = DesignerParser(args.input)
    designer.parse()
    
    # Determine output path
    if args.output:
        output_path = args.output
    else:
        base = os.path.splitext(args.input)[0]
        output_path = f"{base}.{args.format}"
    
    # Generate output
    if args.format == 'html':
        designer.save_html(output_path, args.scale)
    elif args.format == 'png':
        designer.to_image(output_path, args.scale)
    elif args.format == 'json':
        with open(output_path, 'w', encoding='utf-8') as f:
            f.write(designer.to_json())
    
    print(f"Generated: {output_path}")
    print(f"  Form: {designer.form_name}")
    print(f"  Controls: {len(designer.controls)}")


if __name__ == '__main__':
    main()
