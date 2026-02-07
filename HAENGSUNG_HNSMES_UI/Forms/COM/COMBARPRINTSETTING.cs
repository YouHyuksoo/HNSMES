using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Xml;
using System.IO;
using Neodynamic.SDK.Printing;
using System.Collections;
using HAENGSUNG_HNSMES_UI.Class;

namespace HAENGSUNG_HNSMES_UI.Forms.COM
{
    public partial class COMBARPRINTSETTING : HAENGSUNG_HNSMES_UI.Forms.BASE.Form
    {
        readonly PrintJob _printJob = new PrintJob();
        readonly PrinterSettings _printerSettings = new PrinterSettings();

        public string sScannerPortName;

        public COMBARPRINTSETTING()
        {
            InitializeComponent();
        }

        public Boolean IsPrinterSettings
        {
            get
            {
                if (HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_CommunicationType == string.Empty)
                    return false;
                else
                {
                    _printerSettings.Communication.CommunicationType = (CommunicationType)Enum.Parse(typeof(CommunicationType), HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_CommunicationType);

                    if (_printerSettings.Communication.CommunicationType == CommunicationType.USB)
                    {
                        // usb
                        _printerSettings.PrinterName = HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_Name;
                    }
                    else if (_printerSettings.Communication.CommunicationType == CommunicationType.Parallel)
                    {
                        // parallelPort
                        _printerSettings.Communication.ParallelPortName = HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_ParallelPortName;
                    }
                    else if (_printerSettings.Communication.CommunicationType == CommunicationType.Serial)
                    {
                        // serialPort
                        _printerSettings.Communication.SerialPortName = HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_Comport;
                        _printerSettings.Communication.SerialPortBaudRate = int.Parse(HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_BaudRate);
                        _printerSettings.Communication.SerialPortDataBits = int.Parse(HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_DataBit);
                        _printerSettings.Communication.SerialPortFlowControl = (System.IO.Ports.Handshake)Enum.Parse(typeof(System.IO.Ports.Handshake), HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_FlowControl);
                        _printerSettings.Communication.SerialPortParity = (System.IO.Ports.Parity)Enum.Parse(typeof(System.IO.Ports.Parity), HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_ParityBit);
                        _printerSettings.Communication.SerialPortStopBits = (System.IO.Ports.StopBits)Enum.Parse(typeof(System.IO.Ports.StopBits), HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_StopBit);
                    }
                    else if (_printerSettings.Communication.CommunicationType == CommunicationType.Network)
                    {
                        //Network
                        _printerSettings.Communication.NetworkIPAddress = System.Net.IPAddress.Parse(HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_NetworkIPAddress);
                        _printerSettings.Communication.NetworkPort = int.Parse(HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_NetworkPort);
                    }

                    _printerSettings.Dpi = (double)decimal.Parse(HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_DPI);
                    _printerSettings.ProgrammingLanguage = (ProgrammingLanguage)Enum.Parse(typeof(ProgrammingLanguage), HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_ProgrammingLanguage);

                    _printJob.PrinterSettings = _printerSettings;
                    _printJob.Copies = (int)decimal.Parse(HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_Copies);
                    _printJob.Mirror = Boolean.Parse(HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_Mirror);
                    _printJob.Rotate180 = Boolean.Parse(HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_Rotate180);

                    Neodynamic.SDK.Printing.PrintUtils.PrinterSettings = _printerSettings;


                    return true;
                }                
            }
        }
        
        private void POP_COM06_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Abort)
                e.Cancel = true;
        }

        private void POP_COM06_Load(object sender, EventArgs e)
        {
            try
            {
                Init();

                this.cboPrinters.Text = Settings_IDAT.Default.Print_Name;
                this.txtParallelPort.Text = Settings_IDAT.Default.Print_ParallelPortName;
                this.cboSerialPorts.SelectedItem = Settings_IDAT.Default.Print_Comport;
                this.txtBaudRate.Text = Settings_IDAT.Default.Print_BaudRate;
                this.txtDataBits.Text = Settings_IDAT.Default.Print_DataBit;

                this.cboFlowControl.SelectedItem = HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_FlowControl.ToString();
                this.cboParity.SelectedItem = HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_ParityBit.ToString();
                this.cboStopBits.SelectedItem = HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_StopBit.ToString();

                this.txtIPAddress.Text = Settings_IDAT.Default.Print_NetworkIPAddress;
                this.txtIPPort.Text = Settings_IDAT.Default.Print_NetworkPort;
                this.textBox_TSCPRINTNAME.Text = Settings_IDAT.Default.TSC_PRINT_NAME;
                radioGroup_printtype.EditValue = Settings_IDAT.Default.Print_CommunicationType;

                if (_printerSettings.Communication.CommunicationType == CommunicationType.USB)
                {
                    this.tabControl1.SelectedIndex = 0;
                }
                else if (_printerSettings.Communication.CommunicationType == CommunicationType.Parallel)
                {
                    this.tabControl1.SelectedIndex = 1;
                }
                else if (_printerSettings.Communication.CommunicationType == CommunicationType.Serial)
                {
                    this.tabControl1.SelectedIndex = 2;
                }
                else if (_printerSettings.Communication.CommunicationType == CommunicationType.Network)
                {
                    this.tabControl1.SelectedIndex = 3;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Init()
        {
            //Load installed printers...
            string[] installedPrinters = new string[System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count];
            System.Drawing.Printing.PrinterSettings.InstalledPrinters.CopyTo(installedPrinters, 0);
            this.cboPrinters.DataSource = installedPrinters;

            //Load Serial Comm settings...
            this.cboSerialPorts.DataSource = System.IO.Ports.SerialPort.GetPortNames();
            this.cboParity.DataSource = Enum.GetNames(typeof(System.IO.Ports.Parity));
            this.cboStopBits.DataSource = Enum.GetNames(typeof(System.IO.Ports.StopBits));
            this.cboFlowControl.DataSource = Enum.GetNames(typeof(System.IO.Ports.Handshake));

            
            // xml 파일로 부터 프린터 설정정보 얻기
            //bIsPrinterSettings = GetPrinterSettings();
        }


        private Boolean SaveSettings()
        {
            try
            {
                HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_CommunicationType = radioGroup_printtype.EditValue + "";

                HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_Name = cboPrinters.Text;

                HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_NetworkIPAddress = txtIPAddress.Text;

                HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_NetworkPort = txtIPPort.Text;

                HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_ParallelPortName = txtParallelPort.Text;

                HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_Comport = cboSerialPorts.Text;

                HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_BaudRate = txtBaudRate.Text;

                HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_DataBit = txtDataBits.Text;

                HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_FlowControl = cboFlowControl.Text;

                HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_ParityBit = cboParity.Text;

                HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_StopBit = cboStopBits.Text;

                HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_NetworkIPAddress = txtIPAddress.Text;

                HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.Print_NetworkPort = txtIPPort.Text;
 
                HAENGSUNG_HNSMES_UI.Settings_IDAT.Default.TSC_PRINT_NAME = textBox_TSCPRINTNAME.Text + "";

                Global.Global_Variable.gv_sPRCommType = Settings_IDAT.Default.Print_CommunicationType;

                Settings_IDAT.Default.Save();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public PrintJob PrintJob
        {
            get { return _printJob; }
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;   
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            try
            {
                SaveSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Class.clsPrintBarcode clsPrint = new Class.clsPrintBarcode();
            StringBuilder sb = new StringBuilder();
            sb.Append("^XA");
            sb.Append("^FO17,1^GB464,229,24,B,0^FS");
            sb.Append("^A0N,135,136^FO112,48^FDTEST^FS");
            sb.Append("^XZ");

            clsPrint.PrintBarcode(sb.ToString());
            clsPrint = null;
        }
    }
}