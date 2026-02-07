using System;

namespace HAENGSUNG_HNSMES_UI.WebService.Business
{
    public interface IDatabaseProcess
    {
        HAENGSUNG_HNSMES_UI.WebService.Access.WSResults Execute_Proc(string p_strProc, int p_iProcSeq, System.Collections.Generic.Dictionary<string, object> p_dicPara);
        HAENGSUNG_HNSMES_UI.WebService.Access.WSResults Execute_Proc(string p_strProc, int p_iProcSeq, string[] p_arrPara, object[] p_arrValue);
        HAENGSUNG_HNSMES_UI.WebService.Access.WSResults Execute_Proc(string p_strProc, int p_iProcSeq, string[] p_arrPara, string[] p_arrValue);

        bool Execute_Proc(string p_strProc, int p_iProcSeq, string[] p_arrPara, string[] p_arrValue, bool p_blnMessageShow);

        System.Data.DataSet Get_DataBase(string p_strProc, int p_iProcSeq, System.Collections.Generic.Dictionary<string, object> p_dicPara);
        System.Data.DataSet Get_DataBase(string p_strProc, int p_iProcSeq, System.Collections.Generic.Dictionary<string, object> p_dicPara, ref string p_strReturnStr);
        System.Data.DataSet Get_DataBase(string p_strProc, int p_iProcSeq, System.Collections.Generic.Dictionary<string, object> p_dicPara, ref string p_strReturnStr, ref int p_iReturnNumber);
        System.Data.DataSet Get_DataBase(string p_strProc, int p_iProcSeq, string[] p_arrPara, string[] p_arrValue);
        System.Data.DataSet Get_DataBase(string p_strProc, int p_iProcSeq, string[] p_arrPara, string[] p_arrValue, ref string p_strReturnStr);
        System.Data.DataSet Get_DataBase(string p_strProc, int p_iProcSeq, string[] p_arrPara, string[] p_arrValue, ref string p_strReturnStr, ref int p_iReturnNumber);

        string Get_ReturnString(string p_strProc, int p_iProcSeq, System.Collections.Generic.Dictionary<string, object> p_dicPara);
        string Get_ReturnString(string p_strProc, int p_iProcSeq, string[] p_arrPara, string[] p_arrValue);

        bool GetWsConnectStatus();
    }
}
