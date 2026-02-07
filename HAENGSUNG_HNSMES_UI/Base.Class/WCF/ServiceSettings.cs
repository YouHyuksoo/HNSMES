using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NGS.WCFClient
{
    public enum ProtocolKind
    {
        Unknown = -1,
        NetTcp = 0,
        Http = 1,
        Socket = 2
    }

    public enum StartType
    {
        Unknown = -1,
        Auto = 0,
        Manual = 1
    }

    public enum DatabaseKind
    {
        Unknown = -1,
        Oracle = 0,
        SQLServer = 1
    }

    public class ServiceSettings
    {
        private string mIP = "";
        private int mPort = 0;
        private string mUserID = "";
        private string mPassword = "";
        private string mServiceName = "";
        private Uri mUri = null;
        private ProtocolKind mProtocol = ProtocolKind.Unknown;
        private int _timeoutminute = 5;
        private bool mCompression = false;
        private bool mEncryption = false;

        public string UserID
        {
            get
            {
                return mUserID;
            }
            set
            {
                mUserID = value;
            }
        }

        public string Password
        {
            get
            {
                return mPassword;
            }
            set
            {
                mPassword = value;
            }
        }

        public Uri ServiceUri
        {
            get
            {
                mUri = new Uri(MakeUri());
                return mUri;
            }
        }

        public string IPAddress
        {
            get
            {
                return mIP;
            }
            set
            {
                mIP = value;
            }
        }

        public int Port
        {
            get
            {
                return mPort;
            }
            set
            {
                mPort = value;
            }
        }

        public ProtocolKind Protocol
        {
            get
            {
                return mProtocol;
            }
            set
            {
                mProtocol = value;
            }
        }

        public string ServiceName
        {
            get
            {
                return mServiceName;
            }
            set
            {
                mServiceName = value;
            }
        }

        public bool Compression
        {
            get
            {
                return mCompression;
            }
            set
            {
                mCompression = value;
            }
        }

        public bool Encryption
        {
            get
            {
                return mEncryption;
            }
            set
            {
                mEncryption = value;
            }
        }

        public int TimeoutMinute
        {
            get
            {
                return _timeoutminute;
            }
            set
            {
                _timeoutminute = value;
            }
        }

        private string MakeUri()
        {
            string strUri = "";

            switch (mProtocol)
            {
                case ProtocolKind.Http:
                    if (mEncryption) strUri = "https://" + mIP + ":" + mPort.ToString() + "/" + mServiceName;
                    else strUri = "http://" + mIP + ":" + mPort.ToString() + "/" + mServiceName;
                    break;
                case ProtocolKind.NetTcp:
                    strUri = "net.tcp://" + mIP + ":" + mPort.ToString() + "/" + mServiceName;
                    break;
                case ProtocolKind.Unknown:
                    strUri = "";
                    break;
                default:
                    strUri = "";
                    break;
            }

            return strUri;
        }
    }
}
