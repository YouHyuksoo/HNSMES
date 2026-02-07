
using IDAT_Common;
using System.Runtime.InteropServices;
using System.Text;

using System;
using IDAT_Common.Serial;

namespace HAENGSUNG_HNSMES_UI.Class
{

    /// <summary>
    /// 바코드를 프린트하는 작업을 구현한 클래스
    /// </summary>
    /// <remarks></remarks>
    public class clsPrintBarcode
    {
        // 멤버 변수
        IDATSerialPort mClassSerialPort;
        clsLPT lpt = new clsLPT();

        public delegate void PrintDataReceive(string data);
        public event PrintDataReceive EventPrintDateReceive;

        public clsPrintBarcode()
        {
            mClassSerialPort = new IDATSerialPort();

            mClassSerialPort.DataReceived += new IDATSerialPort.DataReceivedEventHandler(mClassSerialPort_DataReceived);
            System.IO.Ports.Parity e_Parity = System.IO.Ports.Parity.None;
            System.IO.Ports.StopBits e_Stopbit = System.IO.Ports.StopBits.None;

            switch (Settings_IDAT.Default.Print_ParityBit)
            {
                case "Even":
                    e_Parity = System.IO.Ports.Parity.Even;
                    break;
                case "Mark":
                    e_Parity = System.IO.Ports.Parity.Mark;
                    break;
                case "None":
                    e_Parity = System.IO.Ports.Parity.None;
                    break;
                case "Odd":
                    e_Parity = System.IO.Ports.Parity.Odd;
                    break;
                case "Space":
                    e_Parity = System.IO.Ports.Parity.Space;
                    break;
            }

            switch (Settings_IDAT.Default.Print_StopBit)
            {
                case "None":
                    e_Stopbit = System.IO.Ports.StopBits.None;
                    break;
                case "One":
                    e_Stopbit = System.IO.Ports.StopBits.One;
                    break;
                case "OnePointFive":
                    e_Stopbit = System.IO.Ports.StopBits.OnePointFive;
                    break;
                case "Two":
                    e_Stopbit = System.IO.Ports.StopBits.Two;
                    break;
            }

            mClassSerialPort.SetPortProperty(Settings_IDAT.Default.Print_Comport, IDAT_Common.Utility.ConvertUtil.ParseInt(Settings_IDAT.Default.Print_BaudRate), e_Parity, e_Stopbit, IDAT_Common.Utility.ConvertUtil.ParseInt(Settings_IDAT.Default.Print_DataBit));
        }

        void mClassSerialPort_DataReceived(string Data)
        {
            if (EventPrintDateReceive != null)
            {
                EventPrintDateReceive(Data);
            }
        }

        /// <summary>
        /// Open
        /// </summary>
        public void SerialOpen()
        {
            mClassSerialPort.OpenSerialPort();
        }

        /// <summary>
        /// Close
        /// </summary>
        public void SerialClose()
        {
            mClassSerialPort.CloseSerialPort();
        }

        public void PrintBarcode(string CommandStr)
        {
            // LAN-RS232 통신 컨버트 서버로 라벨 발행 문자열 전송
            if (Global.Global_Variable.gv_sPRCommType == "C")
            {
                SerialPrintBarcode(CommandStr, true);
                System.Threading.Thread.Sleep(500);

                SerialClose();
            }
            else if (Global.Global_Variable.gv_sPRCommType == "L")
            {
                LPTBarcode(CommandStr);
                System.Threading.Thread.Sleep(500);
            }
            else if (Global.Global_Variable.gv_sPRCommType == "T")
            {
                TCPPrintBarcode(CommandStr);
                System.Threading.Thread.Sleep(500);
            }
        }

        /// <summary>
        /// 바코드를 프린트 한다.
        /// </summary>
        /// <param name="CommandStr">바코드를 프린트할 명령어</param>
        /// <param name="bClosePort">시리얼 포트 사용후에 포트를 닫을 것인지 옵션</param>
        /// <returns>바코드 출력이 정상 처리 되었는지 여부</returns>
        /// <remarks></remarks>
        public bool SerialPrintBarcode(string CommandStr, bool bClosePort)
        {
            // 오픈 한다.
            if (mClassSerialPort.OpenSerialPort() == false)
            {
                return false;
            }

            // 출력하고
            if (mClassSerialPort.WriteDate(CommandStr, 2000))
            {
                // bClosePort가 True이면 포트를 닫는다.
                if (bClosePort == true)
                {
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// TCP IP바코드를 프린트 한다.
        /// </summary>
        /// <param name="CommandStr">바코드를 프린트할 명령어</param>
        /// <param name="bClosePort">시리얼 포트 사용후에 포트를 닫을 것인지 옵션</param>
        /// <returns>바코드 출력이 정상 처리 되었는지 여부</returns>
        public bool TCPPrintBarcode(string CommandStr)
        {
            IDAT.TcpSocket.mySoketClient socket = new IDAT.TcpSocket.mySoketClient("PRINT", Settings_IDAT.Default.Print_NetworkIPAddress, IDAT_Common.Utility.ConvertUtil.ParseInt(Settings_IDAT.Default.Print_NetworkPort), 1024);
            socket.LinkServer();
            socket.SendData(CommandStr);
            socket.SendCmdDISCONNECT();
            return false;
        }

        /// <summary>
        /// LPT 바코드를 프린트 한다.
        /// </summary>
        /// <returns>성공유무</returns>
        public void LPTBarcode(string CommandStr)
        {
            if (lpt.Open(@"c:\LPT1:"))
            {
                lpt.Write(CommandStr);
            }

            lpt.Close();
        }
    }
}