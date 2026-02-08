# 화면 시각화 (Form Viewer)

Designer.cs 파일을 자동 파싱하여 **SVG 기반 인터랙티브 폼 레이아웃**을 시각화합니다.

!!! tip "사용 방법"
    1. 좌측 모듈 목록에서 모듈을 선택합니다
    2. 해당 모듈의 폼 목록이 표시되면 원하는 폼을 클릭합니다
    3. 마우스 휠로 줌, 드래그로 팬 조작이 가능합니다
    4. 컨트롤 위에 마우스를 올리면 상세 정보 툴팁이 표시됩니다

<div class="form-viewer-container" markdown>
<iframe src="../../assets/form-viewer.html" frameborder="0" allowfullscreen></iframe>
</div>

!!! note "데이터 소스"
    이 뷰어는 `tools/form-viewer/parse_designers.py` 스크립트로 생성됩니다.
    Designer.cs 파일이 변경되면 파서를 재실행하여 HTML을 갱신하세요.

    ```bash
    cd tools/form-viewer
    python parse_designers.py
    cp form-viewer.html ../../docs/assets/form-viewer.html
    ```
