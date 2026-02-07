using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Net;
using System.Data;
using System.Threading.Tasks;

namespace NGS.WCFClient.DatabaseService
{
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "ReturnDataStructure", Namespace = "http://schemas.datacontract.org/2004/07/NGS_WCF.Class")]
    [System.SerializableAttribute()]
    public partial class ReturnDataStructure : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private NGS.WCFClient.DatabaseService.OutputParameterValue[] OutputParamListField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Data.DataSet ReturnDataSetField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ReturnIntField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ReturnStringField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public NGS.WCFClient.DatabaseService.OutputParameterValue[] OutputParamList
        {
            get
            {
                return this.OutputParamListField;
            }
            set
            {
                if ((object.ReferenceEquals(this.OutputParamListField, value) != true))
                {
                    this.OutputParamListField = value;
                    this.RaisePropertyChanged("OutputParamList");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Data.DataSet ReturnDataSet
        {
            get
            {
                return this.ReturnDataSetField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ReturnDataSetField, value) != true))
                {
                    this.ReturnDataSetField = value;
                    this.RaisePropertyChanged("ReturnDataSet");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ReturnInt
        {
            get
            {
                return this.ReturnIntField;
            }
            set
            {
                if ((this.ReturnIntField.Equals(value) != true))
                {
                    this.ReturnIntField = value;
                    this.RaisePropertyChanged("ReturnInt");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ReturnString
        {
            get
            {
                return this.ReturnStringField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ReturnStringField, value) != true))
                {
                    this.ReturnStringField = value;
                    this.RaisePropertyChanged("ReturnString");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "OutputParameterValue", Namespace = "http://schemas.datacontract.org/2004/07/NGS_WCF.Class")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(NGS.WCFClient.DatabaseService.ReturnDataStructure))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(NGS.WCFClient.DatabaseService.OutputParameterValue[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Collections.Generic.Dictionary<string, object>))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.ServiceModel.CommunicationState))]
    public partial class OutputParameterValue : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ParamNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object ParamValueField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ParamName
        {
            get
            {
                return this.ParamNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ParamNameField, value) != true))
                {
                    this.ParamNameField = value;
                    this.RaisePropertyChanged("ParamName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public object ParamValue
        {
            get
            {
                return this.ParamValueField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ParamValueField, value) != true))
                {
                    this.ParamValueField = value;
                    this.RaisePropertyChanged("ParamValue");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "DatabaseService.IDatabaseService")]
    public interface IDatabaseService
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDatabaseService/CheckUserIDAndPassword", ReplyAction = "http://tempuri.org/IDatabaseService/CheckUserIDAndPasswordResponse")]
        bool CheckUserIDAndPassword(string userid, string password);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDatabaseService/ExecuteQuery", ReplyAction = "http://tempuri.org/IDatabaseService/ExecuteQueryResponse")]
        NGS.WCFClient.DatabaseService.ReturnDataStructure ExecuteQuery(string strSql);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDatabaseService/ExecuteQueryReturnDataSet", ReplyAction = "http://tempuri.org/IDatabaseService/ExecuteQueryReturnDataSetResponse")]
        NGS.WCFClient.DatabaseService.ReturnDataStructure ExecuteQueryReturnDataSet(string strSql);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDatabaseService/ExecuteProcReturnDataSet", ReplyAction = "http://tempuri.org/IDatabaseService/ExecuteProcReturnDataSetResponse")]
        NGS.WCFClient.DatabaseService.ReturnDataStructure ExecuteProcReturnDataSet(string procName, int overload, System.Collections.Generic.Dictionary<string, object> param);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDatabaseService/ExecuteProcNoReturnDataSet", ReplyAction = "http://tempuri.org/IDatabaseService/ExecuteProcNoReturnDataSetResponse")]
        NGS.WCFClient.DatabaseService.ReturnDataStructure ExecuteProcNoReturnDataSet(string procName, int overload, System.Collections.Generic.Dictionary<string, object> param);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDatabaseService/ServiceLogin", ReplyAction = "http://tempuri.org/IDatabaseService/ServiceLoginResponse")]
        bool ServiceLogin(string userid, string password);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDatabaseService/ServiceState", ReplyAction = "http://tempuri.org/IDatabaseService/ServiceStateResponse")]
        System.ServiceModel.CommunicationState ServiceState();

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDatabaseService/BarcodePrint", ReplyAction = "http://tempuri.org/IDatabaseService/BarcodePrintResponse")]
        bool BarcodePrint(string _PrinterName, string _BarcodePrintCommand);
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDatabaseServiceChannel : NGS.WCFClient.DatabaseService.IDatabaseService, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DatabaseServiceClient : System.ServiceModel.ClientBase<NGS.WCFClient.DatabaseService.IDatabaseService>, NGS.WCFClient.DatabaseService.IDatabaseService
    {

        public DatabaseServiceClient()
        {
        }

        public DatabaseServiceClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public DatabaseServiceClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public DatabaseServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public DatabaseServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        public bool CheckUserIDAndPassword(string userid, string password)
        {
            return base.Channel.CheckUserIDAndPassword(userid, password);
        }

        public NGS.WCFClient.DatabaseService.ReturnDataStructure ExecuteQuery(string strSql)
        {
            return base.Channel.ExecuteQuery(strSql);
        }

        public NGS.WCFClient.DatabaseService.ReturnDataStructure ExecuteQueryReturnDataSet(string strSql)
        {
            return base.Channel.ExecuteQueryReturnDataSet(strSql);
        }

        public NGS.WCFClient.DatabaseService.ReturnDataStructure ExecuteProcReturnDataSet(string procName, int overload, System.Collections.Generic.Dictionary<string, object> param)
        {
            return base.Channel.ExecuteProcReturnDataSet(procName, overload, param);
        }

        public NGS.WCFClient.DatabaseService.ReturnDataStructure ExecuteProcNoReturnDataSet(string procName, int overload, System.Collections.Generic.Dictionary<string, object> param)
        {
            return base.Channel.ExecuteProcNoReturnDataSet(procName, overload, param);
        }

        public bool ServiceLogin(string userid, string password)
        {
            return base.Channel.ServiceLogin(userid, password);
        }

        public System.ServiceModel.CommunicationState ServiceState()
        {
            return base.Channel.ServiceState();
        }

        public bool BarcodePrint(string _PrinterName, string _BarcodePrintCommand)
        {
            return base.Channel.BarcodePrint(_PrinterName, _BarcodePrintCommand);
        }
    }
}
