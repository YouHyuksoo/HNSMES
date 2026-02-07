using System.Collections.Generic;
using System.Data;
using HAENGSUNG_HNSMES_UI.WebService.Access;
using HAENGSUNG_HNSMES_UI.Class;

namespace HAENGSUNG_HNSMES_UI.WebService.Business
{
    class WSDatabaseProcess : IDatabaseProcess
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
            //                                                                                                                                                                                                                 
            if (_result.ResultInt == 0)
            {
                return _result.ResultDataSet;
            }
            else
            {
                return null;
            }
        }

        public DataSet Get_DataBase(string p_strProc, int p_iProcSeq, Dictionary<string, object> p_dicPara, ref string p_strReturnStr, ref int p_iReturnNumber)
        {
            WSResults _result = this.Execute_Proc(p_strProc, p_iProcSeq, p_dicPara);

            p_strReturnStr = _result.ResultString;
            p_iReturnNumber = _result.ResultInt;
            
            if (_result.ResultInt == 0)
            {
                return _result.ResultDataSet;
            }
            else
            {
                iDATMessageBox.ShowProcResultMessage(_result, "Error", Global.Global_Variable.USER_ID, p_strProc, p_dicPara);
                return null;
            }
        }
                            
                                                                                                                                                        
        public bool Execute_Proc(string p_strProc, int p_iProcSeq, string[] p_arrPara, string[] p_arrValue, bool p_blnMessageShow)
        {
            WSResults _result = this.Execute_Proc(p_strProc, p_iProcSeq, p_arrPara, p_arrValue);

            if (_result.ResultInt == 0)
            {
               if ( p_blnMessageShow ) iDATMessageBox.ShowProcResultMessage( _result, "Information", Global.Global_Variable.USER_ID, p_strProc, null );
                return true;
            }
            else
            {
                if (p_blnMessageShow) iDATMessageBox.ShowProcResultMessage(_result, "Error", Global.Global_Variable.USER_ID, p_strProc, null);
                return false;
            }
        }

        public string Execute_Proc( string p_strProc, string[] p_arrPara, string[] p_arrValue )
        {
            WSResults _result = this.Execute_Proc(p_strProc, 1, p_arrPara, p_arrValue);

           if ( _result.ResultInt == 0 )
           {
              return _result.ResultString;
           }
           else
           {
              iDATMessageBox.ShowProcResultMessage( _result, "Error", Global.Global_Variable.USER_ID, p_strProc, null );
              return "";
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
        public WSResults Execute_Proc(string p_strProc, int p_iProcSeq, string[] p_arrPara, string[] p_arrValue)
        {
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
            WebServiceProcess _db = new WebServiceProcess();
            WSResults _result = _db.ExecuteProcCls(p_strProc, p_dicPara);
            return _result;
        }

        public bool GetWsConnectStatus()
        {
            WebServiceProcess _db = new WebServiceProcess();
            return _db.GetWsConnectStatus();
        }

        #region [WebService 추가 Method]

        /// <summary>
        /// 데이터 셋 형식의 트렌젝션 작업 RowData 구성
        /// </summary>
        /// <param name="oDt">데이터셋</param>
        /// <param name="strProcName">프로시져명</param>
        /// <param name="sArName">파라메터명</param>
        /// <param name="sArValue">파라메터값</param>
        /// <returns></returns>
        public DataSet InsertTransactionData(DataSet oDs, string strProcName, string[] sArName, string[] sArValue)
        {
            DataRow dr;

            if (oDs == null)
            {
                oDs = new DataSet();
                oDs.Tables.Add(strProcName);
            }

            //if (oDs.Tables.Count <= 0)
            if (oDs.Tables.IndexOf(strProcName) < 0)
                oDs.Tables.Add(strProcName);

            if ((sArName.Length < 0) || (sArName.Length < 0))
                return oDs;                             

            foreach (string strParamName in sArName)
	        {
                if (oDs.Tables[strProcName].Columns.IndexOf(strParamName) < 0)
                    oDs.Tables[strProcName].Columns.Add(strParamName);		 
	        }

            dr = oDs.Tables[strProcName].NewRow();

            for (int i = 0; i < sArName.Length; i++)
            {
                dr[sArName[i]] = sArValue[i];                
            }
            oDs.Tables[strProcName].Rows.Add(dr);

            //oDs.Tables[strProcName].Columns
            return oDs;
        }

        /// <summary>
        /// 쿼리수행
        /// </summary>
        /// <param name="p_strQry">수행할 쿼리</param>
        /// <returns></returns>
        public WSResults Execute_Qry(string p_strQry)
        {
            WebServiceProcess _db = new WebServiceProcess();

            WSResults _result = _db.ExecuteQry(p_strQry);

            return _result;
        }

        #endregion
    }
}
