using System;
using System.Data;
using System.Configuration;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
 
/// <summary>
/// Summary description for LogFile
/// </summary>
public class LogHelper
{
 
    private static string strLogDir = System.IO.Directory.GetCurrentDirectory() + @"\Log\";
    private static string strLogFile = "Log";
    private static readonly object thisLock = new object();

    public LogHelper()
    {
    }
 
    public static void SetLogPath(string strDir)
    {
        strLogDir = strDir;
    }
 
    public static void SetLogFile(string strFile)
    {
        strLogFile = strFile;
    }
 
    public static void WriteLog(string strLog)
    {
        WriteLog(strLog, LogCode.Infomation, strLogFile);
    }
 
    public static void WriteLog(string strLog, string strFileName)
    {
 
        WriteLog(strLog, LogCode.Infomation, strFileName, strLogDir);
    }
 
    public static void WriteLog(string strLog, string strFileName, string strPath)
    {
        WriteLog(strLog, LogCode.Infomation, strFileName, strPath);
    }
 
    public static void WriteLog(string strLog, LogCode logCode)
    {
        WriteLog(strLog, logCode, strLogFile);
    }
 
    public static void WriteLog(string strLog, LogCode logCode, string strFileName)
    {
 
        WriteLog(strLog, logCode, strFileName, strLogDir);
    }
 
    public static void WriteLog(string strLog, LogCode logCode, string strFileName, string strPath)
    {
        string strFullName;
 
        if (!Directory.Exists(strPath))
        {
            Directory.CreateDirectory(strPath);
        }
 
        if (strPath.EndsWith(@"\") == false || strPath.EndsWith("/") == false)
        {
            strPath = strPath + @"\";
        }

        strFullName = strPath + strFileName + "_" + DateTime.Now.ToShortDateString() + ".txt";
 
        lock(thisLock)
        {
            StreamWriter sw = new StreamWriter(strFullName, true, System.Text.Encoding.UTF8, 4096);
            sw.WriteLine(strLog);
            sw.Close();
        }
    }

    public static List<string> ReadLog()
    {
        return ReadLog(LogCode.Infomation, strLogFile, strLogDir);
    }

    public static List<string> ReadLog(LogCode logCode, string strFileName, string strPath)
    {
        string line = string.Empty;

        List<string> listLog = new List<string>();

        DirectoryInfo di = new DirectoryInfo(strPath);

        foreach (var item in di.GetFiles())
        {
            System.IO.StreamReader file = new System.IO.StreamReader(strPath + item.Name);
            while ((line = file.ReadLine()) != null)
            {
                listLog.Add(line);
            }

            file.Close();  
        }

        return listLog;
    }

    public static void DeleteLog()
    {
        DeleteLog(LogCode.Infomation, strLogFile, strLogDir);
    }
    public static void DeleteLog(LogCode logCode, string strFileName, string strPath)
    {
        DirectoryInfo di = new DirectoryInfo(strPath);

        foreach (var item in di.GetFiles())
        {
            item.Delete();
        }
    }
 
    public enum LogCode
    {
        Infomation = 0,
        Success = 1,
        Error = -1,
        Failure = -2,
        Warning = -10,
        SystemError = -101,
        ApplicationError = -201
    }
}


