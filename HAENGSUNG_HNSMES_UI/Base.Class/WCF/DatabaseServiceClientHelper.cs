using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

using NGS.WCFClient.DatabaseService;

namespace NGS.WCFClient
{
    public class DatabaseServiceClientHelper
    {
        private readonly System.Xml.XmlDictionaryReaderQuotas xmlReaderQuot = new System.Xml.XmlDictionaryReaderQuotas();

        private ServiceSettings databaseService;
        private Dictionary<string, object> m_param = new Dictionary<string, object>();
        private StringBuilder m_sql = new StringBuilder();

        public Dictionary<string, object> SpParam
        {
            get
            {
                return m_param;
            }
            set
            {
                m_param = value;
            }
        }

        public StringBuilder Sql
        {
            get
            {
                return m_sql;
            }
            set
            {
                m_sql = value;
            }
        }

        public ServiceSettings DatabaseServiceSettings
        {
            get
            {
                return databaseService;
            }
            set
            {
                databaseService = value;
            }
        }

        public DatabaseServiceClientHelper()
        {
            databaseService = new ServiceSettings();
        }

        public void SpParamClear()
        {
            m_param.Clear();
        }

        private IDatabaseService CreateDatabaseServiceClient()
        {
            CustomBinding binding = null;
            BindingElementCollection bindingElement = null;

            NetTcpBinding tcp = new NetTcpBinding();
            BasicHttpBinding http = new BasicHttpBinding();

            if (databaseService.Protocol == ProtocolKind.NetTcp)
            {
                tcp.MaxReceivedMessageSize = int.MaxValue;
                tcp.MaxBufferPoolSize = int.MaxValue;
                tcp.MaxConnections = 100;
                tcp.OpenTimeout = TimeSpan.MaxValue;
                tcp.ReceiveTimeout = TimeSpan.MaxValue;
                tcp.SendTimeout = TimeSpan.MaxValue;
                tcp.CloseTimeout = TimeSpan.MaxValue;
                tcp.ReliableSession.InactivityTimeout = TimeSpan.MaxValue;
                if (databaseService.Encryption) tcp.Security.Mode = SecurityMode.Transport;
                else tcp.Security.Mode = SecurityMode.None;
                tcp.ReaderQuotas.MaxStringContentLength = int.MaxValue;
                tcp.ReaderQuotas.MaxArrayLength = int.MaxValue;
                tcp.ReaderQuotas.MaxBytesPerRead = int.MaxValue;

                bindingElement = new BindingElementCollection();

                foreach (BindingElement be in tcp.CreateBindingElements())
                {
                    bindingElement.Add(be);
                }
                if (databaseService.Compression)
                {
                    IDAT.GZipEncoder.GZipMessageEncodingBindingElement gbe = new IDAT.GZipEncoder.GZipMessageEncodingBindingElement();
                    ((BinaryMessageEncodingBindingElement)gbe.InnerMessageEncodingBindingElement).ReaderQuotas.MaxArrayLength = int.MaxValue;
                    ((BinaryMessageEncodingBindingElement)gbe.InnerMessageEncodingBindingElement).ReaderQuotas.MaxBytesPerRead = int.MaxValue;
                    ((BinaryMessageEncodingBindingElement)gbe.InnerMessageEncodingBindingElement).ReaderQuotas.MaxStringContentLength = int.MaxValue;

                    bindingElement[1] = gbe;
                }

                binding = new CustomBinding(bindingElement);


            }
            else if (databaseService.Protocol == ProtocolKind.Http)
            {
                http.MaxReceivedMessageSize = int.MaxValue;
                http.MaxBufferPoolSize = int.MaxValue;
                http.OpenTimeout = TimeSpan.MaxValue;
                http.ReceiveTimeout = TimeSpan.MaxValue;
                http.SendTimeout = TimeSpan.MaxValue;
                http.CloseTimeout = TimeSpan.MaxValue;
                if (databaseService.Encryption) http.Security.Mode = BasicHttpSecurityMode.Transport;
                else http.Security.Mode = BasicHttpSecurityMode.None;
                http.ReaderQuotas.MaxBytesPerRead = int.MaxValue;
                http.ReaderQuotas.MaxArrayLength = int.MaxValue;
                http.ReaderQuotas.MaxStringContentLength = int.MaxValue;
                http.TextEncoding = Encoding.Unicode;
                if (databaseService.Compression)
                {
                    http.MessageEncoding = WSMessageEncoding.Mtom;
                }
                else
                {
                    http.MessageEncoding = WSMessageEncoding.Text;
                }

                bindingElement = new BindingElementCollection();

                foreach (BindingElement be in http.CreateBindingElements())
                {
                    bindingElement.Add(be);
                }
                if (databaseService.Compression)
                {
                    IDAT.GZipEncoder.GZipMessageEncodingBindingElement gbe = new IDAT.GZipEncoder.GZipMessageEncodingBindingElement();
                    ((BinaryMessageEncodingBindingElement)gbe.InnerMessageEncodingBindingElement).ReaderQuotas.MaxArrayLength = int.MaxValue;
                    ((BinaryMessageEncodingBindingElement)gbe.InnerMessageEncodingBindingElement).ReaderQuotas.MaxBytesPerRead = int.MaxValue;
                    ((BinaryMessageEncodingBindingElement)gbe.InnerMessageEncodingBindingElement).ReaderQuotas.MaxStringContentLength = int.MaxValue;

                    bindingElement[1] = gbe;
                }

                binding = new CustomBinding(bindingElement);
            }

            EndpointAddress endpointAddress = new EndpointAddress(databaseService.ServiceUri.ToString());

            //HIMS_POP.Program.mWCFUri = databaseService.ServiceUri.ToString();

            binding.ReceiveTimeout = TimeSpan.MaxValue;
            binding.SendTimeout = TimeSpan.MaxValue;

            ServiceEndpoint ep = new ServiceEndpoint(ContractDescription.GetContract(typeof(IDatabaseService)), binding, endpointAddress);

            //DatabaseServiceClient dHelper = new DatabaseServiceClient(binding, endpointAddress);
            ChannelFactory<IDatabaseService> factory = new ChannelFactory<IDatabaseService>(ep);
            IDatabaseService proxy = factory.CreateChannel();

            return proxy;
        }

        public CommunicationState ServiceState()
        {
            CommunicationState comSt = new CommunicationState();

            try
            {
                IDatabaseService cHelper = CreateDatabaseServiceClient();

                if (cHelper.ServiceLogin(databaseService.UserID, databaseService.Password)) comSt = cHelper.ServiceState();

                try
                {
                    ((IClientChannel)cHelper).Close();
                }
                catch
                {
                    ((IClientChannel)cHelper).Abort();
                }

                (cHelper as IDisposable).Dispose();
            }
            catch (Exception)
            {
                comSt = CommunicationState.Faulted;
            }

            return comSt;
        }

        public ReturnDataStructure ExecuteQuery()
        {
            ReturnDataStructure returnDataStruct = new ReturnDataStructure();

            try
            {
                IDatabaseService dHelper = CreateDatabaseServiceClient();

                if (dHelper.CheckUserIDAndPassword(databaseService.UserID, databaseService.Password))
                {
                    returnDataStruct = dHelper.ExecuteQuery(m_sql.ToString());
                }
                else
                {
                    returnDataStruct.ReturnInt = -1;
                    returnDataStruct.ReturnString = "Using the service authentication failure.";
                    returnDataStruct.ReturnDataSet = null;
                }

                try
                {
                    ((IClientChannel)dHelper).Close();
                }
                catch
                {
                    ((IClientChannel)dHelper).Abort();
                }

                (dHelper as IDisposable).Dispose();
            }
            catch (Exception ex)
            {
                returnDataStruct.ReturnInt = -1;
                returnDataStruct.ReturnString = ex.Message;
                returnDataStruct.ReturnDataSet = null;
            }

            return returnDataStruct;
        }

        public ReturnDataStructure ExecuteQueryReturnDataSet()
        {
            ReturnDataStructure returnDataStruct = new ReturnDataStructure();

            try
            {
                IDatabaseService dHelper = CreateDatabaseServiceClient();

                if (dHelper.CheckUserIDAndPassword(databaseService.UserID, databaseService.Password))
                {
                    returnDataStruct = dHelper.ExecuteQueryReturnDataSet(m_sql.ToString());
                }
                else
                {
                    returnDataStruct.ReturnInt = -1;
                    returnDataStruct.ReturnString = "Using the service authentication failure.";
                    returnDataStruct.ReturnDataSet = null;
                }

                try
                {
                    ((IClientChannel)dHelper).Close();
                }
                catch
                {
                    ((IClientChannel)dHelper).Abort();
                }

                (dHelper as IDisposable).Dispose();
            }
            catch (Exception ex)
            {
                returnDataStruct.ReturnInt = -1;
                returnDataStruct.ReturnString = ex.Message;
                returnDataStruct.ReturnDataSet = null;
            }

            return returnDataStruct;
        }

        public ReturnDataStructure ExecuteProcNoReturnDataSet(string procName, int overload)
        {
            ReturnDataStructure returnDataStruct = new ReturnDataStructure();

            try
            {
                IDatabaseService dHelper = CreateDatabaseServiceClient();

                if (dHelper.CheckUserIDAndPassword(databaseService.UserID, databaseService.Password))
                {
                    returnDataStruct = dHelper.ExecuteProcNoReturnDataSet(procName, overload, m_param);
                }
                else
                {
                    returnDataStruct.ReturnInt = -1;
                    returnDataStruct.ReturnString = "Using the service authentication failure.";
                    returnDataStruct.ReturnDataSet = null;
                }

                try
                {
                    ((IClientChannel)dHelper).Close();
                }
                catch
                {
                    ((IClientChannel)dHelper).Abort();
                }

                (dHelper as IDisposable).Dispose();
            }
            catch (Exception ex)
            {
                returnDataStruct.ReturnInt = -1;
                returnDataStruct.ReturnString = ex.Message;
                returnDataStruct.ReturnDataSet = null;
            }

            return returnDataStruct;
        }

        public ReturnDataStructure ExecuteProc(string procName, int overload)
        {
            xmlReaderQuot.MaxArrayLength = int.MaxValue;
            xmlReaderQuot.MaxBytesPerRead = int.MaxValue;

            ReturnDataStructure returnDataStruct = new ReturnDataStructure();

            try
            {
                IDatabaseService dHelper = CreateDatabaseServiceClient();

                if (dHelper.CheckUserIDAndPassword(databaseService.UserID, databaseService.Password))
                {
                    returnDataStruct = dHelper.ExecuteProcReturnDataSet(procName, overload, m_param);
                }
                else
                {
                    returnDataStruct.ReturnInt = -1;
                    returnDataStruct.ReturnString = "Using the service authentication failure.";
                    returnDataStruct.ReturnDataSet = null;
                }

                try
                {
                    ((IClientChannel)dHelper).Close();
                }
                catch
                {
                    ((IClientChannel)dHelper).Abort();
                }

                (dHelper as IDisposable).Dispose();
            }
            catch (Exception ex)
            {
                returnDataStruct.ReturnInt = -1;
                returnDataStruct.ReturnString = ex.Message;
                returnDataStruct.ReturnDataSet = null;
            }

            return returnDataStruct;
        }

        public bool BarcodePrint(string _PrinterName, string _BarcodePrintCommand)
        {
            bool bRet = false;

            try
            {
                IDatabaseService dHelper = CreateDatabaseServiceClient();

                if (dHelper.CheckUserIDAndPassword(databaseService.UserID, databaseService.Password))
                {
                    bRet = dHelper.BarcodePrint(_PrinterName, _BarcodePrintCommand);
                }
                else
                {
                    bRet = false;
                }

                (dHelper as IDisposable).Dispose();
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }
    }
}
