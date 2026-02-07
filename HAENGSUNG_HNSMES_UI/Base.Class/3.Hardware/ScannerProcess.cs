using System;
//using IDAT.Serial;
using System.IO.Ports;

namespace HAENGSUNG_HNSMES_UI.Class
{
    class ScannerProcess
    { 
        /// <summary>
        /// Open
        /// </summary>
        public void Open_Serial(SerialPort p_serial, string p_strScannername)
        {
            string _strParityBit = "";
            string _strStopBit = "";
            string _strComport = "";
            string _strBaudRate = "";
            string _strDataBit = "";
            //
            switch(p_strScannername.ToUpper())
            {
                case "SCANNER1":
                    _strParityBit = Settings_IDAT.Default.Scan_ParityBit;
                    _strStopBit = Settings_IDAT.Default.Scan_StopBit;
                    _strComport = Settings_IDAT.Default.Scan_Comport;
                    _strBaudRate = Settings_IDAT.Default.Scan_BaudRate;
                    _strDataBit = Settings_IDAT.Default.Scan_DataBit;
                    break;
                case "SCANNER2":
                    _strParityBit = Settings_IDAT.Default.Scan2_ParityBit;
                    _strStopBit = Settings_IDAT.Default.Scan2_StopBit;
                    _strComport = Settings_IDAT.Default.Scan2_Comport;
                    _strBaudRate = Settings_IDAT.Default.Scan2_BaudRate;
                    _strDataBit = Settings_IDAT.Default.Scan2_DataBit;
                    break;
                case "SCANNER3":
                    _strParityBit = Settings_IDAT.Default.Scan3_ParityBit;
                    _strStopBit = Settings_IDAT.Default.Scan3_StopBit;
                    _strComport = Settings_IDAT.Default.Scan3_Comport;
                    _strBaudRate = Settings_IDAT.Default.Scan3_BaudRate;
                    _strDataBit = Settings_IDAT.Default.Scan3_DataBit;
                    break;
                case "SCANNER4":
                    _strParityBit = Settings_IDAT.Default.Scan4_ParityBit;
                    _strStopBit = Settings_IDAT.Default.Scan4_StopBit;
                    _strComport = Settings_IDAT.Default.Scan4_Comport;
                    _strBaudRate = Settings_IDAT.Default.Scan4_BaudRate;
                    _strDataBit = Settings_IDAT.Default.Scan4_DataBit;
                    break;
            }

            switch (_strParityBit)
            {
                case "Even":
                    p_serial.Parity = Parity.Even;
                    break;
                case "Mark":
                    p_serial.Parity = Parity.Mark;
                    break;
                case "None":
                    p_serial.Parity = Parity.None;
                    break;
                case "Odd":
                    p_serial.Parity = Parity.Odd;
                    break;
                case "Space":
                    p_serial.Parity = Parity.Space;
                    break;
            }

            switch (_strStopBit)
            {
                case "None":
                    p_serial.StopBits = StopBits.None;
                    break;
                case "1":
                    p_serial.StopBits = StopBits.One;
                    break;
                case "1.5":
                    p_serial.StopBits = StopBits.OnePointFive;
                    break;
                case "2":
                    p_serial.StopBits = StopBits.Two;
                    break;
            }

            if (_strComport != "")
            {
                IDAT_Common.Serial.IDATSerialPort _clsUtil = new IDAT_Common.Serial.IDATSerialPort();

                if (_clsUtil.HasCommPort(_strComport))
                {
                    p_serial.PortName = _strComport;
                    p_serial.BaudRate = Convert.ToInt32(_strBaudRate);
                    p_serial.DataBits = Convert.ToInt32(_strDataBit);
                    p_serial.ReceivedBytesThreshold = 1;
                    p_serial.DiscardNull = true;
                    
                    try
                    {
                        if (p_serial.IsOpen) Program.frmM.ProgramMessage = "Serial Port[" + _strComport + "] is could be used.";
                        else p_serial.Open();
                    }
                    catch (Exception) { }
                }
            }
        }
    }
}
