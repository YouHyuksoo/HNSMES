using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace IDAT.TcpSocket
{
    // A delegate type for Server connect status is change.
    public delegate void ServerConnectChangeEventHandler();

    // A delegate type for proces received command through soket doread.
    public delegate void ReceivedCommandEventHandler(string pMessage);

    public class mySoketClient
    {
        #region Request To Server Public Function

        public void SendCmdDISCONNECT() { client.Close(); }

        #endregion

        #region Client Event

        public event ReceivedCommandEventHandler ProcessCommand;
        public event ServerConnectChangeEventHandler ServerConnectChange;

        /*************************************************************************************/
        // 접속 지연 시간 관련 수정.. TimeOut 조정 : 2009.06.02 최성근 수정
        /*************************************************************************************/
        private static bool IsConnectionSuccessful = false;
        private static System.Exception socketexception;
        private static ManualResetEvent TimeoutObject = new ManualResetEvent(false);
        /*************************************************************************************/

        // RaiseServerConnectChange
        private void RaiseServerConnectChange()
        {
            ServerConnectChangeEventHandler temp = ServerConnectChange;
            if (temp != null)
            {
                temp();
            }
        }

        // RaiseProcessCommand
        private void RaiseProcessCommand(string pMessage)
        {
            ReceivedCommandEventHandler temp = ProcessCommand;
            if (temp != null)
            {
                temp(pMessage);
            }
        }
        #endregion

        private string vMyName;
        private string ServerIP;
        private int PORT_NUM;
        private int READ_BUFFER_SIZE;
        private TcpClient client;
        private byte[] readBuffer;

        private ListBox _lstUsers = new ListBox();
        private Ping _ping = new Ping();

        private bool _IsServerLinked;
        private string _ServerLinkMessage = "";
        private string _SendDataErrorMessage = "";

        #region 속성

        // 서버 접속 여부
        public bool IsServerLinked
        {
            get { return _IsServerLinked; }
            set
            {
                _IsServerLinked = value;
                RaiseServerConnectChange();
            }
        }

        // 서버 접속 메시지
        public string ServerLinkMessage
        {
            get { return _ServerLinkMessage; }
            set { _ServerLinkMessage = value; }
        }

        // 서버 이용자
        public ListBox ServerLinkUsers
        {
            get { return _lstUsers; }
            set { _lstUsers = value; }
        }

        // SendData 에러 메시지
        public string SendDataErrorMessage
        {
            get { return _SendDataErrorMessage; }
            set { _SendDataErrorMessage = value; }
        }

        #endregion

        // mySoketClient
        public mySoketClient(string pMyName, string pServerIP, int pPORT_NUM, int pREAD_BUFFER_SIZE)
        {
            vMyName = pMyName;
            ServerIP = pServerIP;
            PORT_NUM = pPORT_NUM;
            READ_BUFFER_SIZE = pREAD_BUFFER_SIZE;
            readBuffer = new byte[READ_BUFFER_SIZE];
        }

        // LinkServer
        public void LinkServer()
        {
            TimeoutObject.Reset();
            socketexception = null;

            IsServerLinked = false;

            ServerLinkMessage = DoPing(ServerIP);

            if (ServerLinkMessage == "")
            {
                try
                {
                    if (client != null) client = null;
                    /*************************************************************************************/
                    // 접속 지연 시간 관련 수정.. TimeOut 조정 : 2009.06.02 최성근 수정
                    /*************************************************************************************/
                    client = new TcpClient();
                    client.BeginConnect(ServerIP, PORT_NUM, new AsyncCallback(CallBackMethod), client);


                    if (TimeoutObject.WaitOne(200, false))
                    {
                        if (!IsConnectionSuccessful) { throw socketexception; }
                    }
                    else
                    {
                        client.Close();
                        throw new TimeoutException("TimeOut Exception");
                    }

                    client.GetStream().BeginRead(readBuffer, 0, READ_BUFFER_SIZE, new AsyncCallback(DoRead), null);

                    IsServerLinked = true;
                }
                catch (Exception ex)
                {
                    ServerLinkMessage = "client:" + vMyName + " Message:" + ex.Message;
                }
            }
        }

        /*************************************************************************************/
        // 접속 지연 시간 관련 수정.. TimeOut 조정 : 2009.06.02 최성근 추가
        /*************************************************************************************/
        private static void CallBackMethod(IAsyncResult asyncresult)
        {
            try
            {
                IsConnectionSuccessful = false;
                TcpClient tcpclient = asyncresult.AsyncState as TcpClient;

                if (tcpclient.Client != null)
                {
                    tcpclient.EndConnect(asyncresult);
                    IsConnectionSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                IsConnectionSuccessful = false;
                socketexception = ex;
            }
            finally
            {
                TimeoutObject.Set();
            }
        }

        // DoRead
        private void DoRead(IAsyncResult ar)
        {
            int BytesRead;
            string strMessage;

            try
            {
                lock (client.GetStream())
                {
                    BytesRead = client.GetStream().EndRead(ar);
                }
                if (BytesRead < 1)
                {
                    IsServerLinked = false;
                    ServerLinkMessage = "연결이 끊어졌읍니다.";
                    return;
                }
                strMessage = Encoding.ASCII.GetString(readBuffer, 0, BytesRead);

                // Message parts are divided by "|"  Break the string into an array accordingly.
                // dataArray(0) is the command.
                string[] dataArray = strMessage.Split((char)124);

                try
                {
                    switch (dataArray[0])
                    {
                        case "JOIN":
                            ServerLinkMessage = "Log in completed.";
                            RaiseServerConnectChange();
                            break;
                        case "CHAT":
                            RaiseProcessCommand(dataArray[1]);
                            break;
                        case "REFUSE":      //사용안함
                            ServerLinkMessage = "Log in failed.";
                            RaiseServerConnectChange();
                            break;
                        case "LISTUSERS":   //사용안함
                            // Server sent a list of users.
                            ServerLinkUsers = ListUsers(dataArray);
                            break;
                        case "BROAD":
                            // Server sent a broadcast message
                            RaiseProcessCommand(dataArray[1]);
                            break;
                    }
                }
                catch (Exception)
                {
                }
                lock (client.GetStream())
                {
                    client.GetStream().BeginRead(readBuffer, 0, READ_BUFFER_SIZE, new AsyncCallback(DoRead), null);
                }
            }
            catch (Exception)
            {
                IsServerLinked = false;
                ServerLinkMessage = "client:" + vMyName + " 연결이 끊어졌읍니다.";
            }
        }

        // DoPing
        private string DoPing(string ipAddress)
        {
            try
            {
                PingReply reply = _ping.Send(ipAddress);
                if (reply.Status != IPStatus.Success)
                {
                    return ipAddress + " Ping Time out.";
                }
                return "";
            }
            catch (PingException ex)
            {
                return ex.Message;
            }
        }

        // Use a StreamWriter to send a message to server.
        public void SendData(string data)
        {
            if (!IsServerLinked)
            {
                return;
            }
            try
            {
                lock (client.GetStream())
                {
                    StreamWriter writer = new StreamWriter(client.GetStream());
                    writer.Write(data);
                    writer.Flush();
                }
            }
            catch
            {
                throw;
            }
        }

        // ListUsers
        private ListBox ListUsers(string[] users)
        {
            ListBox listUser = new ListBox();
            int I;
            for (I = 1; I <= (users.Length - 1); I++)
            {
                listUser.Items.Add(users[I]);
            }
            return listUser;
        }
    }
}
