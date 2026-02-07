using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Net;
using System.Drawing;
namespace HAENGSUNG_HNSMES_UI.Global
{
    /// <summary>
    /// </summary>
    partial class Global_Variable
    {
        // 품번 DatSet;
        public static DataSet g_dtPM = null;

        // 사용자 즐겨찾기 메뉴 사용 유무
        public static bool USE_FAVORITES = false;

        public const int PDA_PRINT_INTERVAL = 5000;

        //public static DateTime G_DTime;
        //////////public static string strDockPanel_Path = String.Format("{0}\\Xml_Files\\Layout_Panel.xml", System.Windows.Forms.Application.StartupPath);
        public static string PATH_FileLog = String.Format("{0}\\LOG", System.Windows.Forms.Application.StartupPath);
        public static string strDataLocalDB_Path = String.Format("{0}\\Xml_Files\\LocalDB.xml", System.Windows.Forms.Application.StartupPath);
        //////////public static string strDataCol_Path = String.Format("{0}\\Xml_Files\\IDAT_COLDS.xml", System.Windows.Forms.Application.StartupPath);
        public static string PATH_DataLanguage = String.Format("{0}\\Xml_Files\\IDAT_Language.xml", System.Windows.Forms.Application.StartupPath);
        //////////public static string strDataMENU_Path = String.Format("{0}\\Xml_Files\\IDAT_MENU.xml", System.Windows.Forms.Application.StartupPath);
        //////////public static string strDataMENUCHILD_Path = String.Format("{0}\\Xml_Files\\IDAT_MENUCHILD.xml", System.Windows.Forms.Application.StartupPath);
        //////////public static string strLinkControl_Path = String.Format("{0}\\Xml_Files\\LinkControlsINFO.xml", System.Windows.Forms.Application.StartupPath);
        //////////public static string strScatterChartLayout_Path = String.Format("{0}\\Xml_Files\\ScatterChartLayout.xml", System.Windows.Forms.Application.StartupPath);
        // QMS 연계 URL
        public static string QMS_URL = "http://203.228.11.14/PHCQMS_LotTracking/install.aspx?fromdt={0}&linecd={1}&itemcode={2}&cscd={3}";

        #region 로그인정보

        // - 사용자 코드
        public static string USER_ID = "";
        // - 사용자 등급
        public static string USERROLE = "";
        // - 사용자 경고메시지표시여부
        public static string ALERTFLAG = "";
        // - 사용자 업데이트알림표시여부
        public static string UPDATEFLAG = "";
        // - 사용자 등급 명
        public static string USERCLASSNAME = "";
        // - 사용자 성명
        public static string USERNAMELOCAL = "";

        // - DEPT 코드
        public static string DEPTCODE = "";

        public static string EHRCODE = "";

        public static string POSITION = "";

        public static string CLIENT = "1060";

        public static string COMPANY = "40";

        public static string PLANT = "P200";
        
        public static string gv_sRegPrintName = "TSC TTP-243 Pro";

        public static string gv_sLogInWorkLineGubun = "";

        public static string gv_sLogInWorkLine = "";

        /*2016-04-27 작업장 구분 입력*/
        public static string WRKCTR = "AUTO";

        //public static string FTP_IP = "ftp://10.2.30.9";

        public static string FTP_IP = "ftp://10.2.30.219";

        public static string FTP_ID = "MESUSER";

        public static string FTP_PW = "Admin!@#$%";
             
        #endregion

        #region 툴팁

        public static string LOC_Init = "항목 초기화";
        public static string ENG_Init = "Initialization Entry.";

        public static string LOC_MemoExEdit = "보이기/숨기기 [키보드 : ALT+DOWN, F4]";
        public static string ENG_MemoExEdit = "Keyboard : ALT+DOWN,F4 to show or hide the dropdown memo editer.";

        public static string LOC_DateEdit = "보이기/숨기기 [키보드 : ALT+DOWN, F4] \r\n값 확인 [키보드 : UP,DOWN]\r\n마우스 휠 지원.";
        public static string ENG_DateEdit = "Keyboard : ALT+DOWN,F4 to show to hide the dropdown calender \r\nUP,DOWN keys to scrool the value.\r\nMouse Wheel : Supported";

        public static string LOC_ComboBoxEdit = "보이기/숨기기 [키보드 : ALT+DOWN, F4] \r\n이전,다음 값 확인 [키보드 : UP,DOWN]\r\n마우스 휠 지원.";
        public static string ENG_ComboBoxEdit = "Keyboard : ALT+DOWN, F4 to show or hide the dropdown list \r\nUp, Down Keys to select the previous or next item.\r\nMouse Wheel : Supported";

        public static string LOC_TimeEdit = "값 변경 [키보드 : UP, DOWN]\r\n마우스 휠 지원.";
        public static string ENG_TimeEdit = "Keyboard : UP,DOWN Keys. \r\nMouse Wheel : supported";

        public static string LOC_SpinEdit = "값 변경 [키보드 : UP, DOWN]\r\n마우스 휠 지원.";
        public static string ENG_SpinEdit = "Keyboard : UP,DOWN Keys. \r\nMouse Wheel : supported";

        public static string LOC_CheckEdit = "마우스 기능 : 캡션 / 체크박스 클릭\r\n키보드 : SPACE";
        public static string ENG_CheckEdit = "Mouse features : Click caption or Check Box, \r\nKeyboard : Press SPACE or use mnemonics";

        public static string LOC_RadioGroup = "마우스 기능 : 텍스트 / 이미지 클릭\r\n키보드 : UP,DOWN,LEFT,RIGHT";
        public static string ENG_RadioGroup = "Mouse features : Click an Item's text or glyph. \r\nKeyboard : UP,DOWN,LEFT,RIGHT keys or mnemonics.";

        public static string LOC_LookUP = "보이기/숨기기 [키보드 : ALT+DOWN, F4] \r\n이전,다음 값 확인 [키보드 : UP,DOWN]\r\n마우스 휠 지원.";
        public static string ENG_LookUP = "Keyboard : ALT+DOWN, F4 to show or hide the dropdown list \r\nUp, Down Keys to select the previous or next item.\r\nMouse Wheel : Supported";

        #endregion

        // 시스템 코드
        public static string SYSTEMCODE = "HSMES";

        // 프린터 통신 타입 설정  RS-232 : C  , LPT : L  , TCP/IP : T
        public static string gv_sPRCommType = "C";

        // 게시버젼
        public static string P_VERSION = "1.0.0.1";

        // 등급 기본설정
        public static readonly string SUPERADMIN = "MANAGER";
  
        public static readonly string ADMIN = "ADMIN";
        public static readonly string GUEST = "GUEST";

        // Language 정보를 저장합니다. // 코드, 이름, 영문
        public static DataSet LANGUAGE = null;
        public static DataSet WORKINFO = null;

        //////////// Network 연결 상태를 표시
        public static bool NETWORK_STATUS = true;

        // 아이피 정보
        private static string g_strIPADDRESS = "";

        public static string IPADDRESS
        {
            get
            {
                IPHostEntry senderIP = Dns.GetHostEntry(Dns.GetHostName());
               
                for (int i = 0; i < senderIP.AddressList.Length; i++)
                {
                    //if (senderIP.AddressList[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork &&
                    //    (senderIP.AddressList[i].ToString().Split('.')[0] == "10" || senderIP.AddressList[i].ToString().Split('.')[0] == "100"))
                    //{
                    //    g_strIPADDRESS = senderIP.AddressList[i].ToString();
                    //    break;
                    //}

                    //if (senderIP.AddressList[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork &&
                    //    senderIP.AddressList[i].ToString().Split('.')[0] == "10")
                    //{
                    //    g_strIPADDRESS = senderIP.AddressList[i].ToString();
                    //    break;
                    //}

                    if (senderIP.AddressList[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        g_strIPADDRESS = senderIP.AddressList[i].ToString();
                        break;
                    }

                    if (i == senderIP.AddressList.Length - 1)
                    {
                        g_strIPADDRESS = senderIP.AddressList[i].ToString();
                        break;
                    }
                }

                return g_strIPADDRESS;
            }
        }       
    }
}
