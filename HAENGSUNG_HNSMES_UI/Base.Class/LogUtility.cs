using System;
using System.Collections.Generic;

using IDAT_Common;
using IDAT.IO.Log;
using HAENGSUNG_HNSMES_UI.Class;
using HAENGSUNG_HNSMES_UI.WebService.Access;

namespace HAENGSUNG_HNSMES_UI.Class
{
    public enum LogInOut
    {
        Login = 1,
        Logout = 2
    }

    class LogUtility
    {
        LogManager m_LogUtility = new LogManager();
        /// <summary>
        /// 로그파일을 씁니다.
        /// </summary>
        /// <param name="ex">Exception</param> 
        public void LogWrite(Exception ex)
        {
            // Log파일경로 정보를 가져옵니다.
            string path = HAENGSUNG_HNSMES_UI.Global.Global_Variable.PATH_FileLog;

            m_LogUtility.StackTraceWriteLog(ex, path);
        }

        /// <summary>
        /// 로그파일을 씁니다.
        /// </summary>
        /// <param name="Message">msg</param>
        public void LogWrite(string msg)
        {
            // Log파일경로 정보를 가져옵니다.
            string path = HAENGSUNG_HNSMES_UI.Global.Global_Variable.PATH_FileLog;
            m_LogUtility.LogWrite(LogType.NORMAL, msg, path);
        }

        #region 시스템 이력

        /// <summary>                                                                                                                                                                                                          
        /// 시스템 로그인, 로그아웃 저장                                                                                                                                                                                       
        /// </summary>                                                                                                                                                                                                         
        /// <param name="_loinout"></param>                                                                                                                                                                                    
        /// <returns></returns>                                                                                                                                                                                                
        public void SaveLogInOut(LogInOut _loginout)
        {
            HAENGSUNG_HNSMES_UI.WebService.Business.IDatabaseProcess dbHelper = Program.frmM.DB;

            dbHelper.Execute_Proc("PKGSYS_COMM.PUT_USESYSTEM",
                                        1, 
                                        new string[] 
                                        {
                                            "A_CLIENT",
                                            "A_COMPANY",
                                            "A_PLANT",
                                            "A_SYSTEM",
                                            "A_USER",
                                            "A_IPADR",
                                            "A_CONTYPE"
                                        },
                                        new string[]
                                        {
                                            Global.Global_Variable.CLIENT,
                                            Global.Global_Variable.COMPANY,
                                            Global.Global_Variable.PLANT,
                                            Global.Global_Variable.SYSTEMCODE,
                                            Global.Global_Variable.EHRCODE,
                                            Global.Global_Variable.IPADDRESS,
                                            Convert.ToInt32(_loginout).ToString()
                                        }
                                        );
            
        }

        /// <summary>                                                                                                                                                                                                          
        /// 시스템 사용이력                                                                                                                                                                                                    
        /// </summary>                                                                                                                                                                                                         
        /// <param name="_loinout"></param>                                                                                                                                                                                    
        /// <returns></returns>                                                                                                                                                                                                
        public void SaveUseHistory(string _formname, string _useitem, string _remark, string _errormessage)
        {
            HAENGSUNG_HNSMES_UI.WebService.Business.IDatabaseProcess dbHelper = Program.frmM.DB;

            dbHelper.Execute_Proc("PKGSYS_COMM.PUT_USESYSTEMLOG",
                                        1,
                                        new string[] 
                                        {
                                            "A_CLIENT",
                                            "A_COMPANY",
                                            "A_PLANT",
                                            "A_SYSTEM",
                                            "A_USER",
                                            "A_IPADR",
                                            "A_SUBJECT",
                                            "A_HEADER",
                                            "A_CONTENTS"
                                        },
                                        new string[]
                                        {
                                            Global.Global_Variable.CLIENT,
                                            Global.Global_Variable.COMPANY,
                                            Global.Global_Variable.PLANT,
                                            Global.Global_Variable.SYSTEMCODE,
                                            Global.Global_Variable.EHRCODE,
                                            Global.Global_Variable.IPADDRESS,
                                            _formname,
                                            _useitem,
                                            _remark + _errormessage
                                        }
                                        );
        }

        #endregion
    }
}
