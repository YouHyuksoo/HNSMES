using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace IDAT_Common.Utility;

public class PC_Info
{
	public static ArrayList GetMACAddress()
	{
		ArrayList arrayList = new ArrayList();
		string query = "select * FROM Win32_NetworkAdapter";
		ObjectQuery query2 = new ObjectQuery(query);
		ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(query2);
		string text = "";
		foreach (ManagementObject item in managementObjectSearcher.Get())
		{
			if (item["MACAddress"] != null)
			{
				arrayList.Add(item["MACAddress"].ToString());
			}
		}
		return arrayList;
	}

	public static bool KeyState(int KeyCode)
	{
		byte[] array = new byte[257];
		WIN32.GetKeyboardState(array);
		return array[KeyCode] == 1;
	}

	public static string GetErrorMessage(Exception prmException)
	{
		string text = "";
		string text2 = "";
		Exception ex = prmException;
		text2 = ex.StackTrace + Environment.NewLine;
		while (ex.InnerException != null)
		{
			ex = ex.InnerException;
			text2 = ex.StackTrace + Environment.NewLine + text2;
		}
		return prmException.Message + Environment.NewLine + text2;
	}

	public static List<Hashtable> GetPrinterList()
	{
		List<Hashtable> list = new List<Hashtable>();
		try
		{
			ManagementScope scope = new ManagementScope();
			ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_Printer");
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(scope, query);
			ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
			foreach (ManagementObject item in managementObjectCollection)
			{
				Hashtable hashtable = new Hashtable();
				hashtable.Add("Name", string.Concat(item["Name"]));
				hashtable.Add("Caption", string.Concat(item["Caption"]));
				hashtable.Add("PrinterName", string.Concat(item["DeviceID"]));
				hashtable.Add("Default", ((bool)item["Default"]) ? "Y" : "N");
				hashtable.Add("PrinterState", string.Concat(item["PrinterState"]));
				list.Add(hashtable);
			}
			managementObjectCollection.Dispose();
			managementObjectSearcher.Dispose();
		}
		catch (Exception)
		{
			list = null;
		}
		return list;
	}
}
