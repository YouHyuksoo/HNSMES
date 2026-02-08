#define DEBUG
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Xml;
using IDAT.WebService.IDAT_WebSvr;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace IDAT.WebService;

public class clsWebService
{
	private static IDAT.WebService.IDAT_WebSvr.IDAT_WebSvr _Websvr;

	private static int uid;

	private static string macAddr;

	private string sErrMsg;

	private string mCurrentPath;

	private string _Url_Addr;

	public string ErrMsg => sErrMsg;

	public string Url_Addr => _Url_Addr;

	public clsWebService()
	{
		mCurrentPath = Application.StartupPath;
	}

	public bool Open_WebService(string strVal)
	{
		bool result;
		checked
		{
			try
			{
				_Websvr = new IDAT.WebService.IDAT_WebSvr.IDAT_WebSvr();
				_Websvr.Url = strVal;
				_Url_Addr = strVal;
				_Websvr.Timeout = 600000;
				string empty = string.Empty;
				IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
				if (Operators.CompareString(macAddr, "", TextCompare: false) == 0)
				{
					int num = hostEntry.AddressList.Length;
					int num2 = 0;
					while (true)
					{
						int num3 = num2;
						int num4 = num;
						if (num3 > num4)
						{
							break;
						}
						if (hostEntry.AddressList[num2].AddressFamily == AddressFamily.InterNetwork)
						{
							macAddr = hostEntry.AddressList[num2].ToString();
							break;
						}
						num2++;
					}
				}
				int num5 = 600000;
				string text = Url_Addr.Substring(Strings.InStrRev(Url_Addr, ":"));
				int num6 = int.Parse(text.Substring(0, Strings.InStr(text, "/") - 1));
				uid = _Websvr.OpenWebservice(macAddr);
			}
			catch (InvalidOperationException ex)
			{
				ProjectData.SetProjectError(ex);
				InvalidOperationException ex2 = ex;
				result = false;
				ProjectData.ClearProjectError();
				goto IL_0156;
			}
			catch (WebException ex3)
			{
				ProjectData.SetProjectError(ex3);
				WebException ex4 = ex3;
				result = false;
				ProjectData.ClearProjectError();
				goto IL_0156;
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				result = false;
				ProjectData.ClearProjectError();
				goto IL_0156;
			}
			result = true;
			goto IL_0156;
		}
		IL_0156:
		return result;
	}

	public bool Open_WebService(string strVal, string WebserviceID)
	{
		bool result;
		checked
		{
			try
			{
				_Websvr = new IDAT.WebService.IDAT_WebSvr.IDAT_WebSvr();
				_Websvr.Url = strVal;
				_Url_Addr = strVal;
				_Websvr.Timeout = 600000;
				string empty = string.Empty;
				IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
				if (Operators.CompareString(macAddr, "", TextCompare: false) == 0)
				{
					int num = hostEntry.AddressList.Length;
					int num2 = 0;
					while (true)
					{
						int num3 = num2;
						int num4 = num;
						if (num3 > num4)
						{
							break;
						}
						if (hostEntry.AddressList[num2].AddressFamily == AddressFamily.InterNetwork)
						{
							macAddr = hostEntry.AddressList[num2].ToString();
							break;
						}
						num2++;
					}
				}
				int num5 = 600000;
				string text = Url_Addr.Substring(Strings.InStrRev(Url_Addr, ":"));
				int num6 = int.Parse(text.Substring(0, Strings.InStr(text, "/") - 1));
				uid = _Websvr.OpenWebservice(WebserviceID);
				Debug.Print("OPEN BackGround : " + uid);
			}
			catch (InvalidOperationException ex)
			{
				ProjectData.SetProjectError(ex);
				InvalidOperationException ex2 = ex;
				result = false;
				ProjectData.ClearProjectError();
				goto IL_016c;
			}
			catch (WebException ex3)
			{
				ProjectData.SetProjectError(ex3);
				WebException ex4 = ex3;
				result = false;
				ProjectData.ClearProjectError();
				goto IL_016c;
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				result = false;
				ProjectData.ClearProjectError();
				goto IL_016c;
			}
			result = true;
			goto IL_016c;
		}
		IL_016c:
		return result;
	}

	public clsDataSetStruct ExecuteProcCls(string sSPname, ArrayList alName, ArrayList alValue)
	{
		clsDataSetStruct clsDataSetStruct2 = new clsDataSetStruct();
		try
		{
			IDAT.WebService.IDAT_WebSvr.clsDataSetStruct clsDataSetStruct3 = _Websvr.Get_ProcClsDs(uid, Set_DS(sSPname, alName, alValue));
			clsDataSetStruct2.pResultDs = clsDataSetStruct3.pResultDs;
			clsDataSetStruct2.pResultInt = clsDataSetStruct3.pResultInt;
			clsDataSetStruct2.pResultString = clsDataSetStruct3.pResultString;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			clsDataSetStruct2.pResultDs = null;
			clsDataSetStruct2.pResultInt = -1;
			clsDataSetStruct2.pResultString = ex2.Message;
			ProjectData.ClearProjectError();
		}
		return clsDataSetStruct2;
	}

	public clsDataSetStruct ExecuteProcBatchDS(DataSet _ds)
	{
		clsDataSetStruct clsDataSetStruct2 = new clsDataSetStruct();
		try
		{
			IDAT.WebService.IDAT_WebSvr.clsDataSetStruct clsDataSetStruct3 = _Websvr.Get_ProcClsBatchDs(uid, _ds);
			clsDataSetStruct2.pResultDs = clsDataSetStruct3.pResultDs;
			clsDataSetStruct2.pResultInt = clsDataSetStruct3.pResultInt;
			clsDataSetStruct2.pResultString = clsDataSetStruct3.pResultString;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			clsDataSetStruct2.pResultDs = null;
			clsDataSetStruct2.pResultInt = -1;
			clsDataSetStruct2.pResultString = ex2.Message;
			ProjectData.ClearProjectError();
		}
		return clsDataSetStruct2;
	}

	public clsDataSetStruct ExecuteQry(string strqry)
	{
		clsDataSetStruct clsDataSetStruct2 = new clsDataSetStruct();
		try
		{
			DataSet dataSet = null;
			IDAT.WebService.IDAT_WebSvr.clsDataSetStruct clsDataSetStruct3 = _Websvr.Get_QryClsDs(uid, strqry);
			dataSet = clsDataSetStruct3.pResultDs;
			clsDataSetStruct2.pResultDs = clsDataSetStruct3.pResultDs;
			clsDataSetStruct2.pResultInt = clsDataSetStruct3.pResultInt;
			clsDataSetStruct2.pResultString = clsDataSetStruct3.pResultString;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			clsDataSetStruct2.pResultDs = null;
			clsDataSetStruct2.pResultInt = -1;
			clsDataSetStruct2.pResultString = ex2.Message;
			ProjectData.ClearProjectError();
		}
		return clsDataSetStruct2;
	}

	public string ExecuteFunc(string sSPname, ArrayList alName, ArrayList alValue, int Return_Type = 22)
	{
		string result;
		try
		{
			result = _Websvr.Get_Func(uid, Set_DS(sSPname, alName, alValue), Return_Type);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			sErrMsg = ex2.Message.ToString();
			result = string.Empty;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private DataSet Set_DS(string name, ArrayList al_name, ArrayList al_value)
	{
		DataSet dataSet = new DataSet();
		DataTable dataTable = new DataTable();
		Type type = Type.GetType("System.String");
		dataTable.TableName = name;
		dataTable.Columns.Add(new DataColumn("Param", type));
		dataTable.Columns.Add(new DataColumn("Value", type));
		checked
		{
			int num = al_name.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = al_name[num2].ToString();
				dataRow[1] = al_value[num2].ToString();
				dataTable.Rows.Add(dataRow);
				num2++;
			}
			dataSet.Tables.Add(dataTable);
			return dataSet;
		}
	}

	private string GetXmlData(string Node)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(mCurrentPath + "\\IDATAppUpdater.xml");
		string result;
		try
		{
			XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName(Node);
			result = elementsByTagName[0].FirstChild.Value;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			result = "";
			ProjectData.ClearProjectError();
		}
		return result;
	}
}
