using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

using HAENGSUNG_HNSMES_UI.Class;

namespace HAENGSUNG_HNSMES_UI.Global
{
    /// <summary>
    /// 공통 사용 가능한 Function Class
    /// </summary>
    class GlobalFunction
    {
        /// <summary>
        /// 엑셀파일 로드후, DataTable로 변환 후 리턴
        /// </summary>
        /// <param name="sPath">엑셀파일경로</param>
        /// <param name="sSheetName">Sheet명(데이터테이블명)</param>
        /// <returns></returns>
        public static DataTable ReadExcelFile(string sPath, string sSheetName)
        {
            string sConnectionString;
            OleDbConnection conn;
            OleDbCommand comm;
            OleDbDataAdapter adap;
            DataTable dtXls;

            try
            {
                string[] arrText = sPath.ToString().Split(new char[] { '.' });

                if (arrText[arrText.Length - 1].ToString() == "xls")
                    sConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sPath + ";Extended Properties=\"Excel 8.0;HDR=No;IMEX=1\"";
                else
                    sConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sPath + ";Extended Properties=\"Excel 12.0;HDR=No;IMEX=1\"";


                using (conn = new OleDbConnection(sConnectionString))
                {
                    using (comm = new OleDbCommand())
                    {
                        using (adap = new OleDbDataAdapter())
                        {
                            comm.Connection = conn;
                            comm.CommandType = CommandType.Text;
                            comm.CommandText = "select * from [" + sSheetName + "$]";

                            adap.SelectCommand = comm;

                            using (dtXls = new System.Data.DataTable())
                            {
                                adap.Fill(dtXls);
                                
                                DataTable dt = dtXls.Clone();

                                dt.BeginLoadData();
                                foreach (DataRow dr in dtXls.Rows)
                                {
                                    if (dr["F1"] + "" != "")
                                    {
                                        DataRow drNew = dt.NewRow();
                                        foreach (DataColumn dc in dtXls.Columns)
                                        {
                                            drNew[dc.ColumnName] = dr[dc.ColumnName];
                                        }
                                        dt.Rows.Add(drNew);
                                    }
                                }
                                dt.EndLoadData();
                                dt.AcceptChanges();
                                //dtXls.Rows.RemoveAt(0);
                                return dt;
                            }
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
