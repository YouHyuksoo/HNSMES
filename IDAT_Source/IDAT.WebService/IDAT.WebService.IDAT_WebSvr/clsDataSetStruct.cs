using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Xml.Serialization;

namespace IDAT.WebService.IDAT_WebSvr;

[Serializable]
[XmlType(Namespace = "IDAT_WebSvr")]
[DesignerCategory("code")]
[DebuggerStepThrough]
[GeneratedCode("System.Xml", "4.0.30319.233")]
public class clsDataSetStruct
{
	private int pResultIntField;

	private string pResultStringField;

	private DataSet pResultDsField;

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

	[DebuggerNonUserCode]
	public clsDataSetStruct()
	{
	}
}
