using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace IDAT.WCFClient.DatabaseService;

[Serializable]
[DataContract(Name = "ReturnDataStructure", Namespace = "http://schemas.datacontract.org/2004/07/IDAT.WCFService")]
[DebuggerStepThrough]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
public class ReturnDataStructure : IExtensibleDataObject, INotifyPropertyChanged
{
	[NonSerialized]
	private ExtensionDataObject extensionDataField;

	[OptionalField]
	private DataSet ReturnDataSetField;

	[OptionalField]
	private int ReturnIntField;

	[OptionalField]
	private string ReturnStringField;

	[Browsable(false)]
	public ExtensionDataObject ExtensionData
	{
		get
		{
			return extensionDataField;
		}
		set
		{
			extensionDataField = value;
		}
	}

	[DataMember]
	public DataSet ReturnDataSet
	{
		get
		{
			return ReturnDataSetField;
		}
		set
		{
			if (!object.ReferenceEquals(ReturnDataSetField, value))
			{
				ReturnDataSetField = value;
				RaisePropertyChanged("ReturnDataSet");
			}
		}
	}

	[DataMember]
	public int ReturnInt
	{
		get
		{
			return ReturnIntField;
		}
		set
		{
			if (!ReturnIntField.Equals(value))
			{
				ReturnIntField = value;
				RaisePropertyChanged("ReturnInt");
			}
		}
	}

	[DataMember]
	public string ReturnString
	{
		get
		{
			return ReturnStringField;
		}
		set
		{
			if (!object.ReferenceEquals(ReturnStringField, value))
			{
				ReturnStringField = value;
				RaisePropertyChanged("ReturnString");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
