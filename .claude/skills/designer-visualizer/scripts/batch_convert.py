#!/usr/bin/env python3
"""
Batch convert multiple designer files to HTML/PNG
"""

import os
import sys
import glob
import argparse
from pathlib import Path
from concurrent.futures import ThreadPoolExecutor, as_completed
from designer_parser import DesignerParser


def convert_file(input_file: str, output_dir: str, format: str, scale: float) -> dict:
    """Convert a single file"""
    try:
        parser = DesignerParser(input_file)
        parser.parse()
        
        base_name = Path(input_file).stem
        output_path = os.path.join(output_dir, f"{base_name}.{format}")
        
        if format == 'html':
            parser.save_html(output_path, scale)
        elif format == 'png':
            parser.to_image(output_path, scale)
        elif format == 'json':
            with open(output_path, 'w', encoding='utf-8') as f:
                f.write(parser.to_json())
        
        return {
            'input': input_file,
            'output': output_path,
            'success': True,
            'controls': len(parser.controls),
            'form': parser.form_name
        }
    except Exception as e:
        return {
            'input': input_file,
            'success': False,
            'error': str(e)
        }


def main():
    parser = argparse.ArgumentParser(description='Batch convert designer files')
    parser.add_argument('pattern', help='Glob pattern for input files (e.g., "**/*.designer.cs")')
    parser.add_argument('-o', '--output', default='visualizations', help='Output directory')
    parser.add_argument('-f', '--format', choices=['html', 'png', 'json'], default='html')
    parser.add_argument('-s', '--scale', type=float, default=1.0)
    parser.add_argument('-j', '--jobs', type=int, default=4, help='Parallel jobs')
    parser.add_argument('--fail-fast', action='store_true', help='Stop on first error')
    
    args = parser.parse_args()
    
    # Find files
    files = glob.glob(args.pattern, recursive=True)
    if not files:
        print(f"No files found matching: {args.pattern}")
        sys.exit(1)
    
    print(f"Found {len(files)} files to convert")
    print(f"Output format: {args.format}")
    print(f"Output directory: {args.output}")
    print()
    
    # Create output directory
    os.makedirs(args.output, exist_ok=True)
    
    # Convert files in parallel
    results = []
    with ThreadPoolExecutor(max_workers=args.jobs) as executor:
        futures = {
            executor.submit(convert_file, f, args.output, args.format, args.scale): f 
            for f in files
        }
        
        for future in as_completed(futures):
            result = future.result()
            results.append(result)
            
            if result['success']:
                print(f"[OK] {result['form']}: {result['controls']} controls -> {result['output']}")
            else:
                print(f"[FAIL] {result['input']}: {result['error']}")
                if args.fail_fast:
                    print("\nStopping due to --fail-fast")
                    sys.exit(1)
    
    # Summary
    success_count = sum(1 for r in results if r['success'])
    fail_count = len(results) - success_count
    total_controls = sum(r.get('controls', 0) for r in results if r['success'])
    
    print()
    print("=" * 50)
    print(f"Conversion complete!")
    print(f"  Success: {success_count}/{len(files)}")
    print(f"  Failed: {fail_count}")
    print(f"  Total controls: {total_controls}")
    print(f"  Output: {os.path.abspath(args.output)}")


if __name__ == '__main__':
    main()
