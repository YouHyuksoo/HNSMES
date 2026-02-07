using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using HAENGSUNG_HNSMES_UI.Class;


namespace NGS_UI.Class
{
    //2023-06-16 강동화 추가
    //포장 바코드 스캔시 너무 느려 데이터베이스에 직접 연결하기 위해 만듬

    public static class DirectCon
    {

        static string ConnectionString = String.Format("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1})))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={2})));User Id = {3}; Password = {4}; Connection Timeout={5};",
                                           "10.2.30.9", "1521", "CDBHNSMES", "MESUSER", "MESUSER123", 3000);

        public class Result
        {
            internal int ResultInt = 0;
            internal string ResultString = string.Empty;
            internal DataSet ResultDataSet = new DataSet();
        }


        public static Result GetDataProc(string ProcName, Dictionary<object[], OracleDbType> Prams, bool isC_RETURN = true)
        { //동기형

            Result _Result = new Result();
            try
            {
                using (OracleConnection _OracleConnection = new OracleConnection(ConnectionString))
                using (OracleCommand _OracleCommand = new OracleCommand())
                {
                    _OracleCommand.Connection = _OracleConnection;
                    _OracleCommand.CommandType = CommandType.StoredProcedure;
                    _OracleCommand.CommandText = ProcName;
                    _OracleCommand.BindByName = true;


                    // 여기만 씀
                    foreach (KeyValuePair<object[], OracleDbType> pair in Prams)
                    {
                        if (pair.Value == OracleDbType.Varchar2)
                        {
                            _OracleCommand.Parameters.Add(pair.Key[0].ToString(), pair.Value, 1000).Value = pair.Key[1];
                        }
                        else if (pair.Value == OracleDbType.RefCursor)
                        {
                            _OracleCommand.Parameters.Add(pair.Key[0].ToString(), OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                        }
                        else
                        {
                            _OracleCommand.Parameters.Add(pair.Key[0].ToString(), pair.Value).Value = pair.Key[1];
                        }

                    }

                    _OracleCommand.Parameters.Add("N_RETURN", OracleDbType.Double).Direction = ParameterDirection.Output;
                    _OracleCommand.Parameters.Add("V_RETURN", OracleDbType.Varchar2, 1000).Direction = ParameterDirection.Output;

                    if (isC_RETURN)
                    {
                        _OracleCommand.Parameters.Add("C_RETURN", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    }

                    _OracleConnection.Open();

                    DataSet TEMP = new DataSet();

                    using (OracleDataAdapter _OracleDataAdapter = new OracleDataAdapter(_OracleCommand))
                    {
                        _OracleDataAdapter.Fill(_Result.ResultDataSet);
                        _OracleDataAdapter.GetFillParameters();
                        _Result.ResultInt = Convert.ToInt32(_OracleCommand.Parameters["N_RETURN"].Value.ObjectNullString());
                        _Result.ResultString = _OracleCommand.Parameters["V_RETURN"].Value.ObjectNullString();
                    }
                }
            }
            catch (Exception ex)
            {
                _Result.ResultInt = -1;
                _Result.ResultString = ex.Message;
                _Result.ResultDataSet = null;
            }

            return _Result;
        }

        public static Task<Result> GetDataProcAsyc(string ProcName, Dictionary<object[], OracleDbType> Prams, bool isC_RETURN = true)
        { //비동기형. 
          //화면단 프로그램 자체가 동기형이라 써봐야 의미없음. 혹시 모르니 참고하세요.

            return Task.Factory.StartNew<Result>(() =>
            {
                Result _Result = new Result();
                try
                {
                    using (OracleConnection _OracleConnection = new OracleConnection(ConnectionString))
                    using (OracleCommand _OracleCommand = new OracleCommand())
                    {
                        _OracleCommand.Connection = _OracleConnection;
                        _OracleCommand.CommandType = CommandType.StoredProcedure;
                        _OracleCommand.CommandText = ProcName;
                        _OracleCommand.BindByName = true;


                        // 여기만 씀
                        foreach (KeyValuePair<object[], OracleDbType> pair in Prams)
                        {
                            if (pair.Value == OracleDbType.Varchar2)
                            {
                                _OracleCommand.Parameters.Add(pair.Key[0].ToString(), pair.Value, 1000).Value = pair.Key[1];
                            }
                            else if (pair.Value == OracleDbType.RefCursor)
                            {
                                _OracleCommand.Parameters.Add(pair.Key[0].ToString(), OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                            }
                            else
                            {
                                _OracleCommand.Parameters.Add(pair.Key[0].ToString(), pair.Value).Value = pair.Key[1];
                            }

                        }

                        _OracleCommand.Parameters.Add("N_RETURN", OracleDbType.Double).Direction = ParameterDirection.Output;
                        _OracleCommand.Parameters.Add("V_RETURN", OracleDbType.Varchar2, 1000).Direction = ParameterDirection.Output;

                        if (isC_RETURN)
                        {
                            _OracleCommand.Parameters.Add("C_RETURN", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                        }

                        _OracleConnection.Open();

                        DataSet TEMP = new DataSet();

                        using (OracleDataAdapter _OracleDataAdapter = new OracleDataAdapter(_OracleCommand))
                        {
                            _OracleDataAdapter.Fill(_Result.ResultDataSet);
                            _OracleDataAdapter.GetFillParameters();
                            _Result.ResultInt = Convert.ToInt32(_OracleCommand.Parameters["N_RETURN"].Value.ObjectNullString());
                            _Result.ResultString = _OracleCommand.Parameters["V_RETURN"].Value.ObjectNullString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    _Result.ResultInt = -1;
                    _Result.ResultString = ex.Message;
                    _Result.ResultDataSet = null;
                }

                return _Result;
            });
        }
        public static string ObjectNullString(this object result)
        {
            if (result == null)
                return "";
            else
                return result.ToString();
        }
    }

}

