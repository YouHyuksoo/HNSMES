using System.Data;
using System.Diagnostics;

namespace IDAT.WebService;

public class clsDataSetStruct
{
	private DataSet pResultDsField;

	private int pResultIntField;

	private string pResultStringField;

	public DataSet pResultDs
	{
		get
		{
			return pResultDsField;
		}
		set
		{
			pResultDsField = value;
		}
	}

	public int pResultInt
	{
		get
		{
			return pResultIntField;
		}
		set
		{
			pResultIntField = value;
		}
	}

	public string pResultString
	{
		get
		{
			return pResultStringField;
		}
		set
		{
			pResultStringField = value;
		}
	}

	[DebuggerNonUserCode]
	public clsDataSetStruct()
	{
	}
}
