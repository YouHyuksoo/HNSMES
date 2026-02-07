using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using Microsoft.Win32;

namespace HAENGSUNG_HNSMES_UI.Forms.COM
{
    public partial class COMSCANNERSETTING : BASE.Form
    {
        public COMSCANNERSETTING()
        {
            InitializeComponent();
        }
        
        private void COM02_Load(object sender, EventArgs e)
        {
            GetCommPort();
            GetBaudRate();
            GetDataBit();
            GetParityBit();
            GetStopBit();
            this.Set_Data(radType.EditValue + "");
        }

        private void Set_Data(string p_strScanner)
        {
            switch(p_strScanner)
            {
                case "SCANNER1":
                    cboCommPort.EditValue = Settings_IDAT.Default.Scan_Comport;
                    cboBaudRate.EditValue = Settings_IDAT.Default.Scan_BaudRate;
                    cboDataBit.EditValue = Settings_IDAT.Default.Scan_DataBit;
                    cboParityBit.EditValue = Settings_IDAT.Default.Scan_ParityBit;
                    cboStopBit.EditValue = Settings_IDAT.Default.Scan_StopBit;
                    break;
                case "SCANNER2":
                    cboCommPort.EditValue = Settings_IDAT.Default.Scan2_Comport;
                    cboBaudRate.EditValue = Settings_IDAT.Default.Scan2_BaudRate;
                    cboDataBit.EditValue = Settings_IDAT.Default.Scan2_DataBit;
                    cboParityBit.EditValue = Settings_IDAT.Default.Scan2_ParityBit;
                    cboStopBit.EditValue = Settings_IDAT.Default.Scan2_StopBit;
                    break;
                case "SCANNER3":
                    cboCommPort.EditValue = Settings_IDAT.Default.Scan3_Comport;
                    cboBaudRate.EditValue = Settings_IDAT.Default.Scan3_BaudRate;
                    cboDataBit.EditValue = Settings_IDAT.Default.Scan3_DataBit;
                    cboParityBit.EditValue = Settings_IDAT.Default.Scan3_ParityBit;
                    cboStopBit.EditValue = Settings_IDAT.Default.Scan3_StopBit;
                    break;
                case "SCANNER4":
                    cboCommPort.EditValue = Settings_IDAT.Default.Scan4_Comport;
                    cboBaudRate.EditValue = Settings_IDAT.Default.Scan4_BaudRate;
                    cboDataBit.EditValue = Settings_IDAT.Default.Scan4_DataBit;
                    cboParityBit.EditValue = Settings_IDAT.Default.Scan4_ParityBit;
                    cboStopBit.EditValue = Settings_IDAT.Default.Scan4_StopBit;
                    break;
            }
        }

        #region [Default Info]

        private void GetCommPort()
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey("HARDWARE\\DEVICEMAP\\SERIALCOMM");

            try
            {
                if (key != null)
                {
                    foreach (string s in key.GetValueNames())
                    {
                        cboCommPort.Properties.Items.Add((string)key.GetValue(s));

                        //if ((string)key.GetValue(s) == Settings_IDAT.Default.Scan_Comport)
                            //cboCommPort.EditValue = Settings_IDAT.Default.Scan_Comport;
                    }
                    key.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void GetBaudRate()
        {
            //int nCnt;

            try
            {
                cboBaudRate.Properties.Items.Add("2400");
                cboBaudRate.Properties.Items.Add("4800");
                cboBaudRate.Properties.Items.Add("9600");
                cboBaudRate.Properties.Items.Add("19200");
                cboBaudRate.Properties.Items.Add("38400");
                cboBaudRate.Properties.Items.Add("115200");

                //for (nCnt = 0; nCnt < cboBaudRate.Properties.Items.Count; nCnt++)
                //{
                    //if (Convert.ToString(cboBaudRate.Properties.Items[nCnt]) == Settings_IDAT.Default.Scan_BaudRate)
                        //cboBaudRate.EditValue = Settings_IDAT.Default.Scan_BaudRate;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void GetDataBit()
        {
            //int nCnt;

            try
            {
                cboDataBit.Properties.Items.Add("5");
                cboDataBit.Properties.Items.Add("6");
                cboDataBit.Properties.Items.Add("7");
                cboDataBit.Properties.Items.Add("8");

                //for (nCnt = 0; nCnt < cboDataBit.Properties.Items.Count; nCnt++)
                //{
                //    if (Convert.ToString(cboDataBit.Properties.Items[nCnt]) == Settings_IDAT.Default.Scan_DataBit)
                //        cboDataBit.EditValue = Settings_IDAT.Default.Scan_DataBit;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetParityBit()
        {
            //int nCnt;

            try
            {
                cboParityBit.Properties.Items.Add("None");
                cboParityBit.Properties.Items.Add("Odd");
                cboParityBit.Properties.Items.Add("Even");
                cboParityBit.Properties.Items.Add("Mark");
                cboParityBit.Properties.Items.Add("Space");

                //for (nCnt = 0; nCnt < cboParityBit.Properties.Items.Count; nCnt++)
                //{
                //    if (Convert.ToString(cboParityBit.Properties.Items[nCnt]) == Settings_IDAT.Default.Scan_ParityBit)
                //        cboParityBit.EditValue = Settings_IDAT.Default.Scan_ParityBit;
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void GetStopBit()
        {
            //int nCnt;

            try
            {
                cboStopBit.Properties.Items.Add("None");
                cboStopBit.Properties.Items.Add("1");
                cboStopBit.Properties.Items.Add("1.5");
                cboStopBit.Properties.Items.Add("2");

                //for (nCnt = 0; nCnt < cboStopBit.Properties.Items.Count; nCnt++)
                //{
                //    if (Convert.ToString(cboStopBit.Properties.Items[nCnt]) == Settings_IDAT.Default.Scan_StopBit)
                //        cboStopBit.EditValue = Settings_IDAT.Default.Scan_StopBit;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region [Button Event]

        /// <summary>
        /// 취소 버튼 이벤트
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 확인 버튼 이벤트
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            //////////dxErrorProvider.ClearErrors();
            //////////ValidateChildren(ValidationConstraints.Visible);

            //////////if (dxErrorProvider.HasErrors)
            //////////{
            //////////    return;
            //////////}
            switch (radType.EditValue + "")
            {
                case "SCANNER1":
                    Settings_IDAT.Default.Scan_Comport = cboCommPort.EditValue.ToString();
                    Settings_IDAT.Default.Scan_BaudRate = cboBaudRate.EditValue.ToString();
                    Settings_IDAT.Default.Scan_ParityBit = cboParityBit.EditValue.ToString();
                    Settings_IDAT.Default.Scan_DataBit = cboDataBit.EditValue.ToString();
                    Settings_IDAT.Default.Scan_StopBit = cboStopBit.EditValue.ToString();
                    break;
                case "SCANNER2":
                    Settings_IDAT.Default.Scan2_Comport = cboCommPort.EditValue.ToString();
                    Settings_IDAT.Default.Scan2_BaudRate = cboBaudRate.EditValue.ToString();
                    Settings_IDAT.Default.Scan2_ParityBit = cboParityBit.EditValue.ToString();
                    Settings_IDAT.Default.Scan2_DataBit = cboDataBit.EditValue.ToString();
                    Settings_IDAT.Default.Scan2_StopBit = cboStopBit.EditValue.ToString();
                    break;
                case "SCANNER3":
                    Settings_IDAT.Default.Scan3_Comport = cboCommPort.EditValue.ToString();
                    Settings_IDAT.Default.Scan3_BaudRate = cboBaudRate.EditValue.ToString();
                    Settings_IDAT.Default.Scan3_ParityBit = cboParityBit.EditValue.ToString();
                    Settings_IDAT.Default.Scan3_DataBit = cboDataBit.EditValue.ToString();
                    Settings_IDAT.Default.Scan3_StopBit = cboStopBit.EditValue.ToString();
                    break;
                case "SCANNER4":
                    Settings_IDAT.Default.Scan4_Comport = cboCommPort.EditValue.ToString();
                    Settings_IDAT.Default.Scan4_BaudRate = cboBaudRate.EditValue.ToString();
                    Settings_IDAT.Default.Scan4_ParityBit = cboParityBit.EditValue.ToString();
                    Settings_IDAT.Default.Scan4_DataBit = cboDataBit.EditValue.ToString();
                    Settings_IDAT.Default.Scan4_StopBit = cboStopBit.EditValue.ToString();
                    break;
            }
            
            Settings_IDAT.Default.Save();

            this.DialogResult = DialogResult.OK;

            //this.Close();
        }

        #endregion

        private void radType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Set_Data(radType.EditValue + "");
        }
    }
}
