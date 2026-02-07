using System.Collections.Generic;
using System.Data;

using NGS.WCFClient.DatabaseService;
using HAENGSUNG_HNSMES_UI.WebService.Access;
using HAENGSUNG_HNSMES_UI.Class;

namespace HAENGSUNG_HNSMES_UI.WebService.Business
{
    class WCFDatabaseProcess : IDatabaseProcess
    {
        public DataSet Get_DataBase(string p_strProc, int p_iProcSeq, string[] p_arrPara, string[] p_arrValue)
        {
            string _strReturn = "";
            return this.Get_DataBase(p_strProc, p_iProcSeq, p_arrPara, p_arrValue, ref _strReturn);
        }

        public DataSet Get_DataBase(string p_strProc, int p_iProcSeq, Dictionary<string, object> p_dicPara)
        {
            string _strReturn = "";
            return this.Get_DataBase(p_strProc, p_iProcSeq, p_dicPara, ref _strReturn);
        }


        public string Get_ReturnString(string p_strProc, int p_iProcSeq, string[] p_arrPara, string[] p_arrValue)
        {
            string _strReturn = "";
            this.Get_DataBase(p_strProc, p_iProcSeq, p_arrPara, p_arrValue, ref _strReturn);
            return _strReturn;
        }

        public string Get_ReturnString(string p_strProc, int p_iProcSeq, Dictionary<string, object> p_dicPara)
        {
            string _strReturn = "";
            this.Get_DataBase(p_strProc, p_iProcSeq, p_dicPara, ref _strReturn);
            return _strReturn;
        }


        public DataSet Get_DataBase(string p_strProc, int p_iProcSeq, string[] p_arrPara, string[] p_arrValue, ref string p_strReturnStr)
        {
            int i = 0;
            return this.Get_DataBase(p_strProc, p_iProcSeq, p_arrPara, p_arrValue, ref p_strReturnStr, ref i);
        }

        public DataSet Get_DataBase(string p_strProc, int p_iProcSeq, Dictionary<string, object> p_dicPara, ref string p_strReturnStr)
        {
            int i = 0;
            return this.Get_DataBase(p_strProc, p_iProcSeq, p_dicPara, ref p_strReturnStr, ref i);
        }

        public DataSet Get_DataBase(string p_strProc, int p_iProcSeq, string[] p_arrPara, string[] p_arrValue, ref string p_strReturnStr, ref int p_iReturnNumber)
        {
            Dictionary<string, object> _dicPara = new Dictionary<string, object>();

            //파라메터 및 값 설정                                                                                                                                                                                              
            for (int i = 0; i < p_arrPara.Length; i++)
            {
                _dicPara.Add(p_arrPara[i], p_arrValue[i]);
            }

            WSResults _result = this.Execute_Proc(p_strProc, p_iProcSeq, p_arrPara, p_arrValue);

            p_strReturnStr = _result.ResultString;
            p_iReturnNumber = _result.ResultInt;

            if (_result.ResultInt == 0)
            {
                return _result.ResultDataSet;
            }
            else
            {
                iDATMessageBox.ShowProcResultMessage(_result, "Error", Global.Global_Variable.USER_ID, p_strProc, _dicPara);
                return null;
            }
        }

        public DataSet Get_DataBase(string p_strProc, int p_iProcSeq, Dictionary<string, object> p_dicPara, ref string p_strReturnStr, ref int p_iReturnNumber)
        {
            
            WSResults _result = this.Execute_Proc(p_strProc, p_iProcSeq,p_dicPara);

            p_strReturnStr = _result.ResultString;
            p_iReturnNumber = _result.ResultInt;

            if (_result.ResultInt == 0)
            {
                return _result.ResultDataSet;
            }
            else
            {
                iDATMessageBox.ShowProcResultMessage(_result, "Error", Global.Global_Variable.USER_ID , p_strProc, p_dicPara);
                return null;
            }
        }


        public string Execute_Proc(string p_strProc, string[] p_arrPara, string[] p_arrValue)
        {
            WSResults _result = this.Execute_Proc(p_strProc, 1, p_arrPara, p_arrValue);

            if (_result.ResultInt == 0)
            {
                return _result.ResultString;
            }
            else
            {
                iDATMessageBox.ShowProcResultMessage(_result, "Error", Global.Global_Variable.USER_ID, p_strProc, null);
                return "";
            }
        }

        public bool Execute_Proc(string p_strProc, int p_iProcSeq, string[] p_arrPara, string[] p_arrValue, bool p_blnMessageShow)
        {
            WSResults _result = this.Execute_Proc(p_strProc, p_iProcSeq, p_arrPara, p_arrValue);

            if (_result.ResultInt == 0)
            {
                return true;
            }
            else
            {
                if (p_blnMessageShow) iDATMessageBox.ShowProcResultMessage(_result, "Error", Global.Global_Variable.USER_ID, p_strProc, null);
                return false;
            }
        }

        /// <summary>
        /// 프로시저 실행
        /// </summary>
        /// <param name="p_strProc">프로시저명</param>
        /// <param name="p_iProcSeq">순번</param>
        /// <param name="p_arrPara">파라미터명리스트</param>
        /// <param name="p_arrValue">파라미터리스트</param>
        /// <returns></returns>
        public WSResults  Execute_Proc(string p_strProc, int p_iProcSeq, string[] p_arrPara, string[] p_arrValue)
        {
            HAENGSUNG_HNSMES_UI.WebService.Access.WCFServiceProcess _db = new HAENGSUNG_HNSMES_UI.WebService.Access.WCFServiceProcess();
            Dictionary<string, object> _dicPara = new Dictionary<string, object>();

            //파라메터 및 값 설정                                                                                                                                                                   
            for (int i = 0; i < p_arrPara.Length; i++)
            {
                _dicPara.Add(p_arrPara[i], p_arrValue[i]);
            }

            WSResults _result = this.Execute_Proc(p_strProc, p_iProcSeq, _dicPara);

            return _result;
        }

        /// <summary>
        /// 프로시저 실행
        /// </summary>
        /// <param name="p_strProc">프로시저명</param>
        /// <param name="p_iProcSeq">순번</param>
        /// <param name="p_arrPara">파라미터명리스트</param>
        /// <param name="p_arrValue">파라미터리스트</param>
        /// <returns></returns>
        public WSResults Execute_Proc(string p_strProc, int p_iProcSeq, string[] p_arrPara, object[] p_arrValue)
        {
            HAENGSUNG_HNSMES_UI.WebService.Access.WCFServiceProcess _db = new HAENGSUNG_HNSMES_UI.WebService.Access.WCFServiceProcess();
            Dictionary<string, object> _dicPara = new Dictionary<string, object>();

            //파라메터 및 값 설정                                                                                                                                                                   
            for (int i = 0; i < p_arrPara.Length; i++)
            {
                _dicPara.Add(p_arrPara[i], p_arrValue[i]);
            }

            WSResults _result = this.Execute_Proc(p_strProc, p_iProcSeq, _dicPara);

            return _result;
        }

        /// <summary>
        /// 프로시저 실행
        /// </summary>
        /// <param name="p_strProc">프로시저명</param>
        /// <param name="p_iProcSeq">순번</param>
        /// <param name="p_dicPara">dictionary</param>
        /// <returns></returns>
        public WSResults Execute_Proc(string p_strProc, int p_iProcSeq, Dictionary<string, object> p_dicPara)
        {
            HAENGSUNG_HNSMES_UI.WebService.Access.WCFServiceProcess _db = new HAENGSUNG_HNSMES_UI.WebService.Access.WCFServiceProcess();
            WSResults _result = _db.ExecuteProcCls(p_strProc, p_iProcSeq, p_dicPara);
            return _result;
        }

        public bool GetWsConnectStatus()
        {
            HAENGSUNG_HNSMES_UI.WebService.Access.WCFServiceProcess _db = new HAENGSUNG_HNSMES_UI.WebService.Access.WCFServiceProcess();
            return _db.GetWsConnectStatus();
        }
    }
}
