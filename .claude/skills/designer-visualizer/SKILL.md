---
name: designer-visualizer
description: Parse WinForms .designer.cs files and convert them to HTML visualizations or PNG images. Use when Kimi needs to visualize Windows Forms layouts from C# Designer files, generate UI mockups from existing code, or document screen layouts in a visual format. Supports DevExpress controls and standard WinForms controls.
---

# Designer Visualizer

Parse WinForms `.designer.cs` files and convert them to visual HTML or PNG representations.

## When to Use

- Visualizing existing WinForms screen layouts from code
- Documenting UI designs in a human-readable format
- Creating mockups from legacy .NET applications
- Comparing screen designs across versions

## Quick Start

```python
from scripts.designer_parser import DesignerParser

parser = DesignerParser("path/to/form.designer.cs")
parser.parse()

# Generate HTML
parser.save_html("output.html", scale=1.0)

# Generate PNG (requires playwright)
parser.to_image("output.png", scale=1.0)
```

## Supported Controls

| Control Type | Visual Style |
|--------------|--------------|
| LabelControl | Blue background, info label |
| SimpleButton | Gradient button style |
| TextEdit | White input field |
| DateEdit | White input with calendar icon |
| ComboBoxEdit | Dropdown field |
| GridControl | Gray grid with headers |
| PanelControl | Light gray container |
| GroupControl | Titled container |
| CheckEdit | Checkbox style |
| RadioGroup | Radio button group |
| LookUpEdit | Searchable dropdown |

## Usage Patterns

### Single Form Visualization

```python
from scripts.designer_parser import DesignerParser

parser = DesignerParser("Forms/MainForm.designer.cs")
parser.parse()

# Save as HTML for documentation
parser.save_html("docs/screens/main-form.html")

# Or capture as PNG for presentations
parser.to_image("assets/main-form.png", scale=1.5)
```

### Batch Processing

```python
import glob
from scripts.designer_parser import DesignerParser

for designer_file in glob.glob("**/*.designer.cs", recursive=True):
    try:
        parser = DesignerParser(designer_file)
        parser.parse()
        
        output_name = designer_file.replace('.designer.cs', '.html')
        parser.save_html(f"visualizations/{output_name}")
        print(f"✓ Generated: {output_name}")
    except Exception as e:
        print(f"✗ Failed: {designer_file} - {e}")
```

### Custom Styling

Modify the generated HTML CSS for custom branding:

```python
html = parser.to_html(scale=1.0)

# Inject custom CSS
custom_css = """
.form-container { border: 3px solid #0078d4; }
.control-button { background: linear-gradient(to bottom, #0078d4, #106ebe); color: white; }
"""
html = html.replace("</style>", custom_css + "</style>")

with open("custom-output.html", "w") as f:
    f.write(html)
```

## Output Formats

### HTML Output
- Interactive hover tooltips showing control details
- Exact pixel positioning based on designer coordinates
- Responsive scaling support
- Embedded CSS for standalone files

### PNG Output
- High-fidelity rendering via Playwright
- Configurable scale factor (1.0 = original size)
- Transparent or white background options
- Suitable for documentation and presentations

## Scale Factors

| Scale | Use Case |
|-------|----------|
| 0.5 | Thumbnail previews |
| 1.0 | Original size (default) |
| 1.5 | Documentation quality |
| 2.0 | High-resolution presentations |

## Handling Nested Controls

The parser automatically handles nested Panel/GroupControl containers:

```python
# Controls with Parent != "this" are positioned relative to their container
parser.controls  # All controls with location, size, and parent info
```

## Limitations

- Dynamic control creation (runtime) not captured
- Data binding expressions not visualized
- Complex custom controls render as generic boxes
- Event handlers not shown (only visual layout)

## Dependencies

### Required
- Python 3.8+
- No external packages for HTML output

### For PNG Output
```bash
pip install playwright
playwright install chromium
```

## Examples

### Example 1: Document Screen Layout

```python
from scripts.designer_parser import DesignerParser

parser = DesignerParser("PROD/PRODT001.designer.cs")
parser.parse()
parser.save_html("docs/prodt001-layout.html", scale=1.2)
```

Output: Interactive HTML showing exact control positions with tooltips.

### Example 2: Create Thumbnail Gallery

```python
import os
from scripts.designer_parser import DesignerParser

os.makedirs("thumbnails", exist_ok=True)

for file in ["SYST001", "MATM001", "PRDT001"]:
    parser = DesignerParser(f"{file}.designer.cs")
    parser.parse()
    parser.to_image(f"thumbnails/{file}.png", scale=0.5)
```

Output: Small PNG thumbnails of all screens for quick reference.

## Reference: DesignerParser API

### Methods

- `parse()` - Parse the designer file
- `to_html(scale=1.0)` - Return HTML string
- `save_html(path, scale=1.0)` - Save HTML to file
- `to_image(path, scale=1.0)` - Save PNG screenshot

### Properties

- `controls` - List of Control objects
- `form_name` - Extracted form class name
- `form_size` - Estimated form dimensions
