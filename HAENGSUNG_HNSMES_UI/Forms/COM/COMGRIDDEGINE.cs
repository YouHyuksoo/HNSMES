using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using IDAT_Common.Utility;



namespace HAENGSUNG_HNSMES_UI.Forms.COM
{
    public partial class COMGRIDDEGINE : HAENGSUNG_HNSMES_UI.Forms.BASE.Form
    {
        public COMGRIDDEGINE()
        {
            InitializeComponent();
        }

        private void COMGRIDDEGINE_Load(object sender, EventArgs e)
        {
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.RestoreDirectory = true;
            openFileDlg.Filter = "XML files (*.xml)|*.xml";

            if (openFileDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    if (File.Exists(openFileDlg.FileName))
                    {
                        textEdit1.Text = openFileDlg.FileName;

                        gridControl1.BeginUpdate();
                        gridControl1.Views[0].RestoreLayoutFromXml(openFileDlg.FileName);
                        gridControl1.EndUpdate();

                        propertyGridControl1.SelectedObject = gridControl1.Views[0];

                        propertyGridControl1.RetrieveFields();

                        gridView1.Columns.Clear();

                        XmlDocument doc = new XmlDocument();
                        doc.Load(openFileDlg.FileName);
                        XmlNodeList list = doc.SelectNodes("//XtraSerializer/property");

                        DataTable dt = new DataTable();

                        foreach (XmlNode node in list)
                        {
                            // 그리드뷰의 컬럼 정보 존재 유무 확인을 한다.
                            if (node.Attributes["name"].InnerText.ToUpper() == "COLUMNS")
                            {
                                DevExpress.XtraGrid.Columns.GridColumn col = null;
                                DataColumn dc = null;

                                foreach (XmlNode colNode in node)
                                {
                                    col = new DevExpress.XtraGrid.Columns.GridColumn();
                                    dc = new DataColumn();

                                    foreach (XmlNode propertyNode in colNode)
                                    {
                                        
                                        switch (propertyNode.Attributes["name"].InnerText.ToUpper())
                                        {
                                                
                                            case "VISIBLEINDEX":
                                                col.VisibleIndex = ConvertUtil.ParseInt(propertyNode.InnerText);
                                                break;

                                            case "VISIBLE":
                                                col.Visible = bool.Parse(propertyNode.InnerText);
                                                break;

                                            case "WIDTH":
                                                col.Width = ConvertUtil.ParseInt(propertyNode.InnerText);
                                                break;

                                            case "NAME": 
                                                col.Name = propertyNode.InnerText;
                                                break;

                                            case "TOOLTIP":
                                                col.ToolTip = propertyNode.InnerText;
                                                break;

                                            case "FIELDNAME":
                                                col.FieldName = propertyNode.InnerText;
                                                dc.ColumnName = propertyNode.InnerText;
                                                break;

                                            //case "COLUMNEDITNAME":
                                            //    col.ColumnEdit = propertyNode.InnerText;
                                            //    break;

                                            default:
                                                break;
                                        }
                                    }
                                    gridView1.Columns.Add(col);
                                    dt.Columns.Add(dc);
                                }
                            }
                        }
                        gridControl1.DataSource = dt;
                        gridView1.AddNewRow();
                        gridView1.AddNewRow();
                    }
                }
                catch (Exception ex)
                {
                    Class.iDATMessageBox.WARNINGMessage(ex.Message, "파일 열기 오류", 5);
                    return;
                }
            }
        }

        IDAT.Devexpress.GRID.IDATDevExpress_GridControl _grid = new IDAT.Devexpress.GRID.IDATDevExpress_GridControl();
        
        private void gridView1_Click(object sender, EventArgs e)
        {
            if (sender is DevExpress.XtraGrid.Views.Grid.GridView)
            {
                DevExpress.XtraGrid.Views.Grid.GridView gv = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                if (_grid.GetClickHitInfo(gv, e).InColumn)
                {
                    propertyGridControl1.SelectedObject = _grid.GetClickHitInfo(gv, e).Column;
                    propertyGridControl1.RetrieveFields();
                }
                else
                {
                    propertyGridControl1.SelectedObject = gv;
                    propertyGridControl1.RetrieveFields();
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            gridView1.SaveLayoutToXml(textEdit1.Text);
        }
    }
}
