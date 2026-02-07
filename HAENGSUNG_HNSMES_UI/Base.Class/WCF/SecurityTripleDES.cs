using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace NGS.WCFClient
{
    public class SecurityTripleDES
    {
        private byte[] m_Key;
        private byte[] m_IV;

        public string KeyValue
        {
            get
            {
                return Encoding.ASCII.GetString(m_Key);
            }
            set
            {
                m_Key = Encoding.ASCII.GetBytes(value);
            }
        }

        public string IVValue
        {
            get
            {
                return Encoding.ASCII.GetString(m_IV);
            }
            set
            {
                m_IV = Encoding.ASCII.GetBytes(value);
            }
        }

        public SecurityTripleDES()
        {
            m_Key = Encoding.ASCII.GetBytes("Copyright NG Soft 2015..");
            m_IV = Encoding.ASCII.GetBytes("Copyright NG Soft 2015..");
        }

        public string EncryptString(string thisEncode)
        {
            string encrypted = "";

            try
            {
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                byte[] Code = Encoding.Default.GetBytes(thisEncode);

                encrypted = Convert.ToBase64String(des.CreateEncryptor(m_Key, m_IV).TransformFinalBlock(Code, 0, Code.Length));
            }
            catch { }

            return encrypted;
        }

        public string DecryptString(string thisDecode)
        {
            string strDecode = "";

            try
            {
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                byte[] Code = Convert.FromBase64String(thisDecode);

                strDecode = Encoding.Default.GetString(des.CreateDecryptor(m_Key, m_IV).TransformFinalBlock(Code, 0, Code.Length));
            }
            catch { }

            return strDecode;
        }
    }
}
