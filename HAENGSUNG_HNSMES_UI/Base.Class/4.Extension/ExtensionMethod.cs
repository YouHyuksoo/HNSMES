using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace HAENGSUNG_HNSMES_UI
{
    public static class ExtensionMethod
    {

        public static IDAT.Devexpress.GRID.IDATDevExpress_GridControl _clsGrid = new IDAT.Devexpress.GRID.IDATDevExpress_GridControl();

        public static string ObjectNullString(this object result)
        {
            if (result == null)
                return "";
            else
                return result.ToString();
        }

        #region [GridControl]


        /// <summary>
        /// 그리드 레이아웃을 저장하는 폴더를 만든다.
        /// </summary>
        /// <returns>폴더 경로</returns>
        public static string EX_SetGridLayoutFolder(this GridView grid)
        {
            return _clsGrid.SetGridLayoutFolder();
        }

        /// <summary>
        /// Grid의 Layout 정보를 모두 초기화 한다.
        /// </summary>
        public static void EX_InitialGridLayout(this GridView grid)
        {
            _clsGrid.InitialGridLayout();
        }

        /// <summary>                                                                                                                                                                                                          
        /// 화면의 그리드 레이아웃 저장                                                                                                                                                                                        
        /// </summary>                                                                                                                                                                                                         
        /// <param name="ctl">GridControl</param>
        /// <param name="_FormName">Form에 Name</param>
        public static void EX_SaveGridLayouts(this GridView grid, string _FormName)
        {
            _clsGrid.SaveGridLayouts(grid.GridControl, _FormName);
        }

        /// <summary>                                                                                                                                                                                                          
        /// 화면의 그리드 레이아웃 적용                                                                                                                                                                                        
        /// </summary>                                                                                                                                                                                                         
        /// <param name="_FormName">Form에 Name</param>
        public static void EX_LoadGridLayouts(this GridView grid, string _FormName)
        {
            _clsGrid.LoadGridLayouts(grid.GridControl, _FormName);
        }

        /// <summary>                                                                                                                                                                                                          
        /// 화면의 그리드 Default 레이아웃 저장                                                                                                                                                                                        
        /// </summary>                                                                                                                                                                                                         
        public static void EX_SaveDefaultGridLayouts(this GridView grid, string _FormName)
        {
            _clsGrid.SaveDefaultGridLayouts(grid.GridControl, _FormName);
        }

        /// <summary>
        /// 화면의 그리드 Default 레이아웃 불러온다.
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="_FormName"></param>
        public static void EX_LoadDefaultGridLayout(this GridView grid, string _FormName)
        {
            _clsGrid.LoadDefaultGridLayout(grid.GridControl, _FormName);
        }

        /// <summary>
        /// DevExpress GridView 총 Summary를 설정합니다.
        /// </summary>
        /// <param name="columnFieldString">지정 Column Name</param>
        /// <param name="summaryType">Summary Type</param>
        public static void EX_SetTotalSummaryItems(this GridView gridview, string columnFieldString, DevExpress.Data.SummaryItemType summaryType)
        {
            _clsGrid.SetTotalSummaryItems(gridview, columnFieldString, summaryType);
        }

        /// <summary>
        /// DevExpress GridView 총 Summary를 설정합니다.
        /// </summary>
        /// <param name="gridview">DevExpress GridView</param>
        /// <param name="columnFieldString">지정 Column Name</param>
        /// <param name="summaryType">Summary Type</param>
        /// <param name="displayFormat">Display Format을 설정. ex) "Total : {0}"</param>
        public static void EX_SetTotalSummaryItems(this DevExpress.XtraGrid.Views.Grid.GridView gridview, string columnFieldString, DevExpress.Data.SummaryItemType summaryType, string displayFormat)
        {
            _clsGrid.SetTotalSummaryItems(gridview, columnFieldString, summaryType, displayFormat);
        }

        /// <summary>
        /// DevExpress GridView 총 Summary를 설정합니다.
        /// </summary>
        /// <param name="gridview">DevExpress GridView</param>
        /// <param name="Idx">Column Index</param>
        /// <param name="summaryType">Summary Type</param>
        public static void EX_SetTotalSummaryItems(this DevExpress.XtraGrid.Views.Grid.GridView gridview, int Idx, DevExpress.Data.SummaryItemType summaryType)
        {
            _clsGrid.SetTotalSummaryItems(gridview, Idx, summaryType);
        }

        /// <summary>
        /// DevExpress GridView 총 Summary를 설정합니다.
        /// </summary>
        /// <param name="gridview">DevExpress GridView</param>
        /// <param name="columnFieldString">Column Name</param>
        /// <param name="summaryType">Summary Type</param>
        /// <param name="displayFormat">Display Format을 설정. ex) "Total : {0}"</param>
        public static void EX_SetTotalSummaryItems(this DevExpress.XtraGrid.Views.Grid.GridView gridview, int Idx, DevExpress.Data.SummaryItemType summaryType, string displayFormat)
        {
            _clsGrid.SetTotalSummaryItems(gridview, Idx, summaryType, displayFormat);
        }

        /// <summary>
        /// DevExpress GridView 총 Summary를 설정합니다.
        /// </summary>
        /// <param name="gridview">DevExpress GridView</param>
        /// <param name="columnFields">Column Name 배열</param>
        /// <param name="summaryTypes">Summary Type</param>
        public static void EX_SetTotalSummaryItems(this DevExpress.XtraGrid.Views.Grid.GridView gridview, string[] columnFields, DevExpress.Data.SummaryItemType[] summaryTypes)
        {
            _clsGrid.SetTotalSummaryItems(gridview, columnFields, summaryTypes);
        }

        /// <summary>
        /// DevExpress GridView 총 Summary를 설정합니다.
        /// </summary>
        /// <param name="gridview">DevExpress GridView</param>
        /// <param name="columnIndexs">Column Index 배열</param>
        /// <param name="summaryTypes">Summary Type</param>
        public static void EX_SetTotalSummaryItems(this DevExpress.XtraGrid.Views.Grid.GridView gridview, int[] columnIndexs, DevExpress.Data.SummaryItemType[] summaryTypes)
        {
            _clsGrid.SetTotalSummaryItems(gridview, columnIndexs, summaryTypes);
        }

        /// <summary>
        /// DevExpress 컨트롤에 확장된 기능을 부여한다. <br/>
        /// 마우스 오른쪽 클릭 (카피, 검색, 익스포트.. 등) 기능 부여
        /// </summary>
        /// <param name="gridview">Dev GridView</param>
        public static void EX_SetIDIFExtendGridView(this DevExpress.XtraGrid.Views.Grid.GridView gridView, string parentForm)
        {
            _clsGrid.SetIDIFExtendGridView(gridView.GridControl, gridView, parentForm);
        }

        /// <summary>
        /// GridView Hit 정보를 가져옵니다.
        /// </summary>
        /// <param name="gridView">DevExpress GridView</param>
        /// <param name="e">EventArgs</param>
        /// <returns>Hit 정보</returns>
        public static DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo EX_GetClickHitInfo(this GridView gridView, EventArgs e)
        {
            return _clsGrid.GetClickHitInfo(gridView, e);
        }

        #region GetChangedTable 관련 함수

        /// <summary>
        /// GridView의 변경된 데이터 정보(추가,수정,삭제)를 가져옵니다.
        /// </summary>
        /// <param name="gridCon">그리드 컨트롤</param>
        /// <returns>GridView에서 수정된 Row 정보만 반환합니다.</returns>
        public static DataTable EX_GetChangedData(this GridView grid)
        {
            return _clsGrid.GetChangedData(grid.GridControl);

        }

        /// <summary>
        /// GridView의 변경된 데이터 정보(추가,수정,삭제)를 가져옵니다.
        /// </summary>
        /// <param name="gridCon">그리드 컨트롤</param>
        /// <param name="newCnt">신규데이터 카운트</param>
        /// <param name="editCnt">수정데이터 카운트</param>
        /// <param name="delCnt">삭제데이터 카운트</param>
        /// <returns>GridView에서 수정된 Row 정보만 반환합니다.</returns>
        public static DataTable EX_GetChangedData(this GridView grid, ref int newCnt, ref int editCnt, ref int delCnt)
        {
            return _clsGrid.GetChangedData(grid.GridControl, ref newCnt, ref editCnt, ref delCnt);
        }

        /// <summary>
        /// GridView의 변경된 데이터 정보(추가,수정,삭제)를 가져옵니다. 
        /// </summary>
        /// <param name="gridCon">그리드 컨트롤</param>
        /// <param name="state">DataRowState 정보</param>
        /// <returns>GridView에서 수정된 Row 정보중 해당하는 DataRowState 정보만을 반환합니다.</returns>
        public static DataTable EX_GetChangedData(this GridView grid, DataRowState state)
        {
            return _clsGrid.GetChangedData(grid.GridControl, state);
        }

        /// <summary>
        /// GridView의 변경된 데이터 정보(추가,수정,삭제)를 가져옵니다.  
        /// </summary>
        /// <param name="gridCon">그리드 컨트롤</param>
        /// <param name="state">DataRowState 정보</param>
        /// <param name="cnt">해당 DataRowState 정보의 카운트</param>
        /// <returns>GridView에서 수정된 Row 정보중 해당하는 DataRowState 정보만을 반환합니다.</returns>
        public static DataTable EX_GetChangedData(this GridView grid, DataRowState state, ref int cnt)
        {
            return _clsGrid.GetChangedData(grid.GridControl, state, ref cnt);
        }

        #endregion

        #region [DevExpress Focuse 설정]

        /// <summary>
        /// 해당 값에 포커스를 이동한다.
        /// </summary>
        /// <param name="gridView">GridView</param>
        /// <param name="columns">컬럼 필드명</param>
        /// <param name="strValue">검색 값</param>
        public static void EX_GetFocuseRowCell(this GridView gridView, string columns, string strValue)
        {
            _clsGrid.GetFocuseRowCell(gridView, columns, strValue);
        }

        /// <summary>
        /// 해당 값에 포커스를 이동한다.
        /// </summary>
        /// <param name="gridView">GridView</param>
        /// <param name="columns">컬럼 필드명</param>
        /// <param name="strValue">검색 값</param>
        public static void EX_GetFocuseRowCell(this GridView grid, string[] columns, string[] strValue)
        {
            _clsGrid.GetFocuseRowCell(grid, columns, strValue);
        }

        #endregion

        #region [GridView의 NewRow를 추가한다.]

        /// <summary>
        /// 그리드뷰의 Row행을 추가한다.
        /// </summary>
        /// <param name="gridviewCon">그리드뷰</param>
        public static void EX_AddNewRow(this GridView gridviewCon)
        {
            _clsGrid.AddNewRow(gridviewCon);
        }

        public static void EX_AddNewRow(this GridView gridviewCon, string[] initColumn, object[] initValues)
        {
            _clsGrid.AddNewRow(gridviewCon, initColumn, initValues);
        }

        #endregion

        #region [GridView의 유효성 검사]

        /// <summary>
        /// 그리드 뷰의 유효성 검사를 실시합니다.
        /// </summary>
        /// <param name="gridViewCon">그리드 뷰 컨트롤</param>
        /// <param name="Columns">유효성 검사 대상 컬럼</param>
        public static bool EX_XtraGridViewValidateChildrenColumnsHasErrors(this GridView gridViewCon, string sValidateMsg, params string[] Columns)
        {
            return _clsGrid.IDAT_XtraGridViewValidateChildrenColumnsHasErrors(gridViewCon, sValidateMsg, Columns);
        }

        /// <summary>
        /// 그리드 뷰의 유효성 검사를 실시합니다.
        /// </summary>
        /// <param name="gridViewCon">그리드 뷰 컨트롤</param>
        /// <param name="Columns">유효성 검사 대상 컬럼</param>
        public static bool EX_XtraGridViewValidateChildrenColumnsHasErrors(this GridView gridViewCon, int rowidx, string sValidateMsg, params string[] Columns)
        {
            return _clsGrid.IDAT_XtraGridViewValidateChildrenColumnsHasErrors(gridViewCon, rowidx, sValidateMsg, Columns);
        }

        #endregion

        #region Export

        public static void EX_ExcelExportTo(this GridView tmpGridView, string filename)
        {
            _clsGrid.ExcelExportTo(tmpGridView, filename);
        }

        public static void EX_TxtExportTo(this GridView tmpGridView, string filename)
        {
            _clsGrid.TxtExportTo(tmpGridView, filename);
        }

        public static void EX_XmlExportTo(this GridView tmpGridView, string filename)
        {
            _clsGrid.XmlExportTo(tmpGridView, filename);
        }

        public static void EX_HTMLExportTo(this GridView tmpGridView, string filename)
        {
            _clsGrid.HTMLExportTo(tmpGridView, filename);
        }

        public static void EX_PDFExportTo(this GridView tmpGridView, string filename)
        {
            _clsGrid.PDFExportTo(tmpGridView, filename);
        }

        public static void EX_RTFExportTo(this GridView tmpGridView, string filename)
        {
            _clsGrid.RTFExportTo(tmpGridView, filename);
        }

        #endregion

        #endregion

    }
}
