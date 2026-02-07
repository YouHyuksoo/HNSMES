using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;

namespace HAENGSUNG_HNSMES_UI.Class
{
    public class CustPlan
    {
        private string mStartTime = "";
        private string mPlanDate = "";

        public string StartTime
        {
            get
            {
                return mStartTime;
            }
            set
            {
                if (mStartTime == value)
                    return;
                mStartTime = value;
            }
        }
        public string PlanDate
        {
            get
            {
                return mPlanDate;
            }
            set
            {
                if (mPlanDate == value)
                    return;
                mPlanDate = value;
            }
        }

        private ArrayList ExcelSheetNames(string excelFile)
        {
            ArrayList sheetNames = new ArrayList();
            string sConnectionString;


            string[] arrText = excelFile.ToString().Split(new char[] { '.' });

            if (arrText[arrText.Length - 1].ToString() == "xls")
            {
                //sConnectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0;HDR=No;", excelFile);
                sConnectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=No;\"", excelFile);
            }
            else
            {
                sConnectionString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=No;\"", excelFile);

            }

            using (OleDbConnection excelConnection = new OleDbConnection(sConnectionString))
            {
                System.Data.DataTable dtSheets = new System.Data.DataTable();

                try
                {
                    excelConnection.Open();
                    dtSheets = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    excelConnection.Close();
                    if (dtSheets == null)
                    {
                        return sheetNames;
                    }

                    foreach (DataRow dr in dtSheets.Rows)
                    {
                        string sheetName = dr["TABLE_NAME"].ToString().Trim('\'').Replace("$", "");
                        sheetNames.Add(sheetName);
                        //DataTable dt = ReadExcelFile(excelFile, sheetName);

                        //if (dt.Rows[0]["F1"] + "" == "Model(파트넘버)")
                        //{
                        //    sheetNames.Add(sheetName);
                        //    break;
                        //}
                    }
                }
                catch (Exception ex)
                {
                    iDATMessageBox.WARNINGMessage(ex.Message, "ExcelSheetNames", 3);
                    //MainButton_INIT.PerformClick();
                    return null;
                }
                finally
                {
                    dtSheets.Dispose();
                }
            }
            return sheetNames;
        }

        //private DataTable ReadExcelFile(string sPath, string sSheetName)
        //{
        //    string sConnectionString;
        //    OleDbConnection conn;
        //    OleDbCommand comm;
        //    OleDbDataAdapter adap;
        //    DataTable dtXls;

        //    try
        //    {
        //        string[] arrText = sPath.ToString().Split(new char[] { '.' });

        //        if (arrText[arrText.Length - 1].ToString() == "xls")
        //            sConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sPath + ";Extended Properties=\"Excel 8.0;HDR=No;IMEX=1\"";
        //        else
        //            sConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sPath + ";Extended Properties=\"Excel 12.0;HDR=No;IMEX=1\"";


        //        using (conn = new OleDbConnection(sConnectionString))
        //        {
        //            using (comm = new OleDbCommand())
        //            {
        //                using (adap = new OleDbDataAdapter())
        //                {
        //                    comm.Connection = conn;
        //                    comm.CommandType = CommandType.Text;
        //                    comm.CommandText = "select * from [" + sSheetName + "$]";

        //                    adap.SelectCommand = comm;

        //                    using (dtXls = new System.Data.DataTable())
        //                    {
        //                        adap.Fill(dtXls);
        //                        //dtXls.Rows.RemoveAt(0);

        //                        DataTable dt = dtXls.Clone();

        //                        dt.BeginLoadData();
        //                        foreach (DataRow dr in dtXls.Rows)
        //                        {
        //                            if (dr["F1"] + "" != "")
        //                            {
        //                                DataRow drNew = dt.NewRow();
        //                                foreach (DataColumn dc in dtXls.Columns)
        //                                {
        //                                    drNew[dc.ColumnName] = dr[dc.ColumnName];
        //                                }
        //                                dt.Rows.Add(drNew);
        //                            }
        //                        }
        //                        dt.EndLoadData();
        //                        dt.AcceptChanges();
        //                        //dtXls.Rows.RemoveAt(0);
        //                        return dt;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        iDATMessageBox.WARNINGMessage(ex.Message, "ReadExcelFile", 3);
        //        //MainButton_INIT.PerformClick();
        //        return null;
        //    }
        //}

        private DataTable SetCustPlanTable()
        {
            DataTable _dt = new DataTable();

            _dt.Columns.Add("WRKCTR", Type.GetType("System.String"));
            _dt.Columns.Add("PLANDATE", Type.GetType("System.String"));
            _dt.Columns.Add("PARTNO", Type.GetType("System.String"));
            _dt.Columns.Add("PLANQTY", Type.GetType("System.Decimal"));

            _dt.AcceptChanges();

            return _dt;
        }

        private DataTable SetCustPlanTimeTable()
        {
            DataTable _dt = new DataTable();

            _dt.Columns.Add("WRKCTR", Type.GetType("System.String"));
            _dt.Columns.Add("PLANDATE", Type.GetType("System.String"));
            _dt.Columns.Add("PARTNO", Type.GetType("System.String"));
            _dt.Columns.Add("PLANQTY", Type.GetType("System.Decimal"));
            _dt.Columns.Add("PRODTIME", Type.GetType("System.String"));

            _dt.AcceptChanges();

            return _dt;
        }

        public DataSet GetCustPlan(string _File)
        {
            DataSet _ds = new DataSet();
            DataTable _dt = Global.GlobalFunction.ReadExcelFile(_File, ExcelSheetNames(_File)[0] + "");
            DateTime _dte = DateTime.Parse(mPlanDate.Substring(0, 4) + "-" + mPlanDate.Substring(4, 2) + "-" + mPlanDate.Substring(6, 2));

            DataTable _dt1 = SetCustPlanTable();
            DataTable _dt2 = SetCustPlanTimeTable();

            int _Skip = 0;
            int _prodtime = int.Parse(mStartTime);
            int _colStart = 0;
            int _PlanQty = 0;

            _colStart = _prodtime - 1;

            _dt1.Clear();

            foreach (DataRow dr in _dt.Rows)
            {
                if (_Skip > 0)
                {
                    int _col = 3;

                    if (dr["F2"] + "" != "")
                    {
                        _prodtime = int.Parse(mStartTime);
                        _dte = DateTime.Parse(mPlanDate.Substring(0, 4) + "-" + mPlanDate.Substring(4, 2) + "-" + mPlanDate.Substring(6, 2));
                        _colStart = _prodtime - 1;

                        for (int i = 0; i < 15; i++)
                        {
                            _PlanQty = 0;
                            for (int j = _colStart; j < 6; j++)
                            {
                                if (dr["F" + _col.ToString().Trim()] + "" != "0" && dr["F" + _col.ToString().Trim()] + "" != "")
                                {
                                    _PlanQty += Convert.ToInt32(dr["F" + _col.ToString().Trim()]);
                                }

                                _prodtime++;
                                _col++;
                            }

                            if (_PlanQty > 0)
                            {
                                DataRow _dr = _dt1.NewRow();

                                _dr["WRKCTR"] = dr["F1"];
                                _dr["PLANDATE"] = _dte.ToString("yyyyMMdd");
                                _dr["PARTNO"] = dr["F2"];
                                _dr["PLANQTY"] = _PlanQty;

                                _dt1.Rows.Add(_dr);
                            }

                            _prodtime = 1;
                            _colStart = 0;

                            _dte = _dte.AddDays(1);
                        }
                    }
                }

                _Skip++;
            }

            _dt1.AcceptChanges();


            _Skip = 0;
            _prodtime = int.Parse(mStartTime);
            _colStart = _prodtime - 1;
            _dte = DateTime.Parse(mPlanDate.Substring(0, 4) + "-" + mPlanDate.Substring(4, 2) + "-" + mPlanDate.Substring(6, 2));
            _dt2.Clear();

            foreach (DataRow dr in _dt.Rows)
            {
                if (_Skip > 0)
                {
                    int _col = 3;

                    if (dr["F2"] + "" != "")
                    {
                        _prodtime = int.Parse(mStartTime);
                        _dte = DateTime.Parse(mPlanDate.Substring(0, 4) + "-" + mPlanDate.Substring(4, 2) + "-" + mPlanDate.Substring(6, 2));
                        _colStart = _prodtime - 1;

                        for (int i = 0; i < 15; i++)
                        {
                            _PlanQty = 0;
                            for (int j = _colStart; j < 6; j++)
                            {
                                if (dr["F" + _col.ToString().Trim()] + "" != "0" && dr["F" + _col.ToString().Trim()] + "" != "")
                                {
                                    DataRow _dr = _dt2.NewRow();

                                    _dr["WRKCTR"] = dr["F1"];
                                    _dr["PLANDATE"] = _dte.ToString("yyyyMMdd");
                                    _dr["PARTNO"] = dr["F2"];
                                    _dr["PLANQTY"] = dr["F" + _col.ToString().Trim()];
                                    _dr["PRODTIME"] = _prodtime.ToString();

                                    _dt2.Rows.Add(_dr);
                                }

                                _prodtime++;
                                _col++;
                            }

                            _prodtime = 1;
                            _colStart = 0;

                            _dte = _dte.AddDays(1);
                        }
                    }
                }

                _Skip++;
            }

            _dt2.AcceptChanges();

            _ds.Tables.Add(_dt1);
            _ds.Tables.Add(_dt2);

            return _ds;
        }
    }
}
