using System;
using System.Windows.Forms;
using DevExpress.LookAndFeel;

using NGS.WCFClient;
using HAENGSUNG_HNSMES_UI.Class;
using HAENGSUNG_HNSMES_UI.Forms.COM;
using System.Deployment.Application;
using DevExpress.Utils;
using DevExpress.XtraSplashScreen;
using System.Threading;
using DevExpress.XtraEditors;

using System.IO;
using System.Net.NetworkInformation;
using System.Collections.Generic;

//
namespace HAENGSUNG_HNSMES_UI
{
    static class Program
    {
        public static MainForm frmM = null;

        public static ServiceSettings m_DatabaseSettings = new ServiceSettings();
        public static ServiceSettings m_ControlSettings = new ServiceSettings();
        public static bool mApplicationUpdate = false;

        private static bool mUpdating = false;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
          try
          {
            //IDAT_Common.Security.Encryption des = new IDAT_Common.Security.Encryption();
            //string s = des.Encrypt("1111");

             if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed) CopyShotcut();

#pragma warning disable CS0618 // Type or member is obsolete
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
#pragma warning restore CS0618
            DevExpress.Utils.Paint.XPaint.ForceTextRenderPaint();

            SplashScreenManager.ShowForm(typeof(HAENGSUNG_HNSMES_UI.Forms.COM.COMSPLASHSCREEN), true, false);
            SplashScreenManager.Default.SendCommand(COMSPLASHSCREEN.SplashScreenCommand.Description, "Checking Program Update...");

            if (UpdateProgram())
            {
                try
                {
                    SplashScreenManager.CloseForm(true);
                }
                catch { }

                Application.Restart();
                return;
            }

            SplashScreenManager.Default.SendCommand(COMSPLASHSCREEN.SplashScreenCommand.Description, "Starting...");

            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                Global.Global_Variable.P_VERSION = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.Major.ToString()
                                                + "." + System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.Minor.ToString()
                                                + "." + System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.Build.ToString()
                                                + "." + System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.Revision.ToString();
            }
            else
            {
                Global.Global_Variable.P_VERSION = "Unknown";
            }

            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

            //===========================================================
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register(); 

            //�ߺ����� ���� üũ
            System.Threading.Mutex _OneProcess = new System.Threading.Mutex(true, Application.ProductName, out bool CheckNewApp);

            if (CheckNewApp)
            {
                _OneProcess.ReleaseMutex();
                frmM = new HAENGSUNG_HNSMES_UI.MainForm();

                //=====================WCF ����=========================
                //if (Global.Global_Variable.IPADDRESS.StartsWith("10.3.20."))
                //    Settings_IDAT.Default.WCF_ServiceIP = "10.3.20.19"; 
                //else
                //    Settings_IDAT.Default.WCF_ServiceIP = "10.3.10.19"; 

                //Settings_IDAT.Default.WCF_ServiceIP = "10.2.30.9"; 

                List<string> IPS = new List<string> { "10.2.31.9", "10.2.30.9" };
                bool _NetworkState = NetworkInterface.GetIsNetworkAvailable();
                bool _PingResult = true;


                foreach (string _IP in IPS)
                {
                    if (_NetworkState)
                    {
                        using (Ping _Ping = new Ping())
                        {
                            PingReply _PingReply = _Ping.Send(_IP, 1500);
                            _PingResult = _PingReply.Status == IPStatus.Success;
                        }
                    }
                    if (_NetworkState & _PingResult)
                    {
                        Settings_IDAT.Default.WCF_ServiceIP = _IP;
                        break;
                    }
                }
                // Ȥ�� ���� �ѹ��� üũ
                if (Settings_IDAT.Default.WCF_ServiceIP == string.Empty)
                {
                    foreach (string _IP in IPS)
                    {
                        if (_NetworkState)
                        {
                            using (Ping _Ping = new Ping())
                            {
                                PingReply _PingReply = _Ping.Send(_IP, 1500);
                                _PingResult = _PingReply.Status == IPStatus.Success;
                            }
                        }
                        if (_NetworkState & _PingResult)
                        {
                            Settings_IDAT.Default.WCF_ServiceIP = _IP;
                            break;
                        }
                    }
                }

                //�׷��� ������ ���� ó����
                if (Settings_IDAT.Default.WCF_ServiceIP == string.Empty)
                {
                    Settings_IDAT.Default.WCF_ServiceIP = IPS[0];
                }




                SetWCFServiceSettings();

                frmM.DB = new HAENGSUNG_HNSMES_UI.WebService.Business.WCFDatabaseProcess();
                // =========================================================================================

                Settings_IDAT.Default.Save();

                try
                {
                    //ClickOnce�� ���� ���    
                    frmM.lblVersion.Caption = "Ver " + System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                }
                catch (System.Deployment.Application.DeploymentException)
                {
                    //ClickOnce������ �ƴϹǷ� ������������� ���
                    frmM.lblVersion.Caption = "Ver " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                }
                catch (Exception)
                {
                    frmM.lblVersion.Caption = "Ȯ�κҰ�";
                }

                Application.Run(frmM);
            }
            else
            {
                MessageBox.Show("Program is running.");
            }
          }
          catch (Exception ex)
          {
              string logPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "crash_log.txt");
              System.IO.File.WriteAllText(logPath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine + ex.ToString());
              MessageBox.Show("Application Error:\n" + ex.Message + "\n\nDetails saved to: " + logPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }

        /*����ȭ�� �ٷΰ��� ������ ����*/
        private static void CopyShotcut()
        {
            string shotcutPath = Environment.GetFolderPath(Environment.SpecialFolder.Programs) + @"\Haengsung CHINA DB HNS MES\MES";

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (!System.IO.File.Exists(desktopPath + @"\HAENGSUNG CDB HNS MES.appref-ms"))
            {
                System.IO.File.Copy(shotcutPath + @"\HAENGSUNG CDB HNS MES.appref-ms", desktopPath + @"\HAENGSUNG CDB HNS MES.appref-ms");
            }
        }

        /*���α׷� ���� ������Ʈ*/
        private static void ApplicationUpdate()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                ad.CheckForUpdateProgressChanged += new DeploymentProgressChangedEventHandler(ad_CheckForUpdateProgressChanged);
                ad.CheckForUpdateCompleted += new CheckForUpdateCompletedEventHandler(ad_CheckForUpdateCompleted);
                ad.UpdateProgressChanged += new DeploymentProgressChangedEventHandler(ad_UpdateProgressChanged);
                ad.UpdateCompleted += new System.ComponentModel.AsyncCompletedEventHandler(ad_UpdateCompleted);
                ad.CheckForUpdateAsync();
            }
        }

        private static void ad_UpdateCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            SplashScreenManager.Default.SendCommand(COMSPLASHSCREEN.SplashScreenCommand.Description, "Program Update Complete.");
            mUpdating = false;
        }

        private static void ad_UpdateProgressChanged(object sender, DeploymentProgressChangedEventArgs e)
        {
            mUpdating = true;
            SplashScreenManager.Default.SendCommand(COMSPLASHSCREEN.SplashScreenCommand.Description, "Program Updating...(" + e.ProgressPercentage + "%)");
        }

        private static void ad_CheckForUpdateCompleted(object sender, CheckForUpdateCompletedEventArgs e)
        {
            if (e.UpdateAvailable)
            {
            }
        }

        private static void ad_CheckForUpdateProgressChanged(object sender, DeploymentProgressChangedEventArgs e)
        {
        }

        private static bool UpdateProgram()
        {
            bool bRet = false;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                UpdateCheckInfo info;
                try
                {
                    info = ad.CheckForDetailedUpdate();

                }
                catch (DeploymentDownloadException dde)
                {
                    MessageBox.Show("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + dde.Message);
                    return false;
                }
                catch (InvalidDeploymentException ide)
                {
                    MessageBox.Show("Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message);
                    return false;
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " + ioe.Message);
                    return false;
                }

                if (info.UpdateAvailable)
                {
                    SplashScreenManager.Default.SendCommand(COMSPLASHSCREEN.SplashScreenCommand.Description, "MES Updating...");
                    Boolean doUpdate = true;

                    if (doUpdate)
                    {
                        try
                        {
                            ad.UpdateProgressChanged+=new DeploymentProgressChangedEventHandler(ad_UpdateProgressChanged);
                            ad.UpdateCompleted+=new System.ComponentModel.AsyncCompletedEventHandler(ad_UpdateCompleted);
                            mUpdating = true;
                            ad.UpdateAsync();

                            while (mUpdating)
                            {
                                Application.DoEvents();
                            }
                            
                            bRet = true;
                        }
                        catch (DeploymentDownloadException dde)
                        {
                            MessageBox.Show("Cannot install the latest version of the application. \n\nPlease check your network connection, or try again later. Error: " + dde);
                        }
                    }
                }
            }
            
            return bRet;
        }

        public static bool CheckUpdateProgram(out string _currentversion, out string _newversion)
        {
            bool bRet = false;
            _currentversion = "";
            _newversion = "";

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                UpdateCheckInfo info;
                try
                {
                    info = ad.CheckForDetailedUpdate();

                }
                catch (DeploymentDownloadException dde)
                {
                    MessageBox.Show("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + dde.Message);
                    return false;
                }
                catch (InvalidDeploymentException ide)
                {
                    MessageBox.Show("Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message);
                    return false;
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " + ioe.Message);
                    return false;
                }

                if (info.UpdateAvailable)
                {
                    _newversion = info.AvailableVersion.ToString();
                    _currentversion = ad.CurrentVersion.ToString();
                    bRet = true;
                }
            }

            return bRet;
        }

        private static void ad_DownloadFileGroupProgressChanged(object sender, DeploymentProgressChangedEventArgs e)
        {
        }

        private static void SetWCFServiceSettings()
        {
            m_DatabaseSettings.IPAddress = Settings_IDAT.Default.WCF_ServiceIP;
            m_DatabaseSettings.Port = 8101;
            m_DatabaseSettings.Protocol = ProtocolKind.NetTcp;
            m_DatabaseSettings.ServiceName = "HNSMES_UI";
            m_DatabaseSettings.UserID = "HNSMES_UI";
            m_DatabaseSettings.Password = "HNSMES_UI";
            m_DatabaseSettings.TimeoutMinute = 1;
            m_DatabaseSettings.Compression = true;
            m_DatabaseSettings.Encryption = false;
        }
    }
}