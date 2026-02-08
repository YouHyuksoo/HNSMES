using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace IDAT_Common.Utility;

public class Date_Time
{
	public static DateTime GetFirstOfMonth(DateTime sDate)
	{
		return new DateTime(sDate.Year, sDate.Month, 1);
	}

	public static DateTime GetLastOfMonth(DateTime sDate)
	{
		return GetFirstOfMonth(sDate.AddMonths(1)).AddDays(-1.0);
	}

	public static bool CheckDate_FromTo(DateTime pDateFrom, DateTime pDateTo, string pFlag, bool pCurrentDateCheck)
	{
		if (pCurrentDateCheck)
		{
			if (pDateFrom < DateTime.Today && pFlag == "F")
			{
				return false;
			}
			if (pDateTo < DateTime.Today && pFlag == "T")
			{
				return false;
			}
		}
		if (pDateFrom > pDateTo)
		{
			if (pFlag == "F")
			{
				return false;
			}
			return false;
		}
		return true;
	}

	public static bool IsCheckBetweenDatetime(DateTime pStartFrom, DateTime pStartTo, DateTime pVal)
	{
		if (pVal >= pStartFrom && pVal <= pStartTo)
		{
			return true;
		}
		return false;
	}

	public static List<DateTime> GetDateRange(DateTime StartingDate, DateTime EndingDate)
	{
		if (StartingDate > EndingDate)
		{
			return null;
		}
		List<DateTime> list = new List<DateTime>();
		DateTime dateTime = StartingDate;
		do
		{
			list.Add(dateTime);
			dateTime = dateTime.AddDays(1.0);
		}
		while (dateTime <= EndingDate);
		return list;
	}

	public static string GetYmd(DateTime prmDateTime)
	{
		try
		{
			return Strings.Format(prmDateTime, "yyyyMMdd");
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
	}

	public static string GetYmd(DateTime prmDateTime, string prmFormat)
	{
		try
		{
			return Strings.Format(prmDateTime, prmFormat);
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
	}

	public static string GetHms(DateTime prmDateTime)
	{
		try
		{
			return Strings.Format(prmDateTime, "HHmmss");
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
	}

	public static string GetHms(DateTime prmDateTime, string prmFormat)
	{
		try
		{
			return Strings.Format(prmDateTime, prmFormat);
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
	}
}
