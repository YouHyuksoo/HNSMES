using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System.Text;
using System.Linq;

using IDAT.UI.MessageBox;
using HAENGSUNG_HNSMES_UI.WebService.Access;
using HAENGSUNG_HNSMES_UI.Base.Class.Controls;

namespace HAENGSUNG_HNSMES_UI.Class
{
    public enum SAVE_Q_TYPE
    {
        New = 0,
        Save = 1
    }

    class iDATMessageBox
    {
        static Class.LogUtility _clsLog = new LogUtility();

        #region [WebService Method ShowProcResultMessage]

        private static LanguageInformation lang = new LanguageInformation();

        /// <summary>
        /// 프로시져 수행후 메시지박스를 보여줍니다.
        /// </summary>
        /// <param name="resultCls">IDAT_WebService.clsDataSetStruct Class</param>
        /// <param name="msgCaption">메시지 박스 타이틀 Text</param>
        public static void ShowProcResultMessage(WSResults resultCls, string msgCaption, string user, string proc, Dictionary<string, object> param)
        {
            // 메인 메시지바에 결과를 보여준다.
            Program.frmM.ProgramMessage = lang.GetMessageString(resultCls.ResultString);

            /// 0 : 프로시져 수행 성공
            /// 1 이상 :프로시져 수행 실패 
            if (resultCls.ResultInt == 0)
            {
            }
            else if (resultCls.ResultInt != 0)
            {
                if (IDATMessageBox.Show("Error Code : " + resultCls.ResultInt.ToString(), msgCaption, lang.GetMessageString(resultCls.ResultString), IDAT_MessageType.Error) == DialogResult.Retry)
                {
                    _clsLog.SaveUseHistory("ProcError", Global.Global_Variable.IPADDRESS, "ProcErrorMessage", lang.GetMessageString(resultCls.ResultString));

                    StringBuilder sb = new StringBuilder();
                    sb.Append("From : " + user + "[" + Global.Global_Variable.IPADDRESS + "]");
                    sb.Append("<BR>");
                    sb.Append("<BR>");
                    sb.Append("Message");
                    sb.Append(lang.GetMessageString(resultCls.ResultString));

                    iDATMessageBox.SendErrorReport(sb.ToString(), proc, param);
                }
            }
        }

        /// <summary>
        /// 프로시져 수행후 메시지박스를 보여줍니다.
        /// </summary>
        /// <param name="resultCls">IDAT_WebService.clsDataSetStruct Class</param>
        /// <param name="msgCaption">메시지 박스 타이틀 Text</param>
        /// <param name="ShowTime">자동으로 보여주는 시간</param>
        public static void ShowProcResultMessage(WSResults resultCls, string msgCaption, int ShowTime, string user, string proc, string[] param, string[] param2)
        {

            Dictionary<string, object> _dicPara = new Dictionary<string, object>();

            //파라메터 및 값 설정
            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    _dicPara.Add(param[i], param2[i]);
                }
            }


            // 메인 메시지바에 결과를 보여준다.
            Program.frmM.ProgramMessage = lang.GetMessageString(resultCls.ResultString);

            /// 0 : 프로시져 수행 성공
            /// 1 이상 :프로시져 수행 실패 
            if (resultCls.ResultInt == 0)
            {
            }
            else if (resultCls.ResultInt != 0)
            {
                if (IDATMessageBox.Show("Error Code : " + resultCls.ResultInt.ToString(), msgCaption, lang.GetMessageString(resultCls.ResultString), IDAT_MessageType.Error, ShowTime) == DialogResult.Retry)
                {
                    _clsLog.SaveUseHistory("ProcError", Global.Global_Variable.IPADDRESS, "ProcErrorMessage", lang.GetMessageString(resultCls.ResultString));

                    StringBuilder sb = new StringBuilder();
                    sb.Append("From : " + user + "[" + Global.Global_Variable.IPADDRESS + "]");
                    sb.Append("<BR>");
                    sb.Append("<BR>");
                    sb.Append("Message");
                    sb.Append(lang.GetMessageString(resultCls.ResultString));

                    iDATMessageBox.SendErrorReport(sb.ToString(), proc, _dicPara);
                }

            }
        }

        /// <summary>
        /// 프로시져 수행후 메시지박스를 보여줍니다.
        /// </summary>
        /// <param name="resultCls">IDAT_WebService.clsDataSetStruct Class</param>
        /// <param name="msgCaption">메시지 박스 타이틀 Text</param>
        /// <param name="ShowTime">자동으로 보여주는 시간</param>
        public static void ShowProcResultMessage(WSResults resultCls, string msgCaption, int ShowTime, string user, string proc, Dictionary<string, object> param)
        {
            // 메인 메시지바에 결과를 보여준다.
            Program.frmM.ProgramMessage = lang.GetMessageString(resultCls.ResultString);

            /// 0 : 프로시져 수행 성공
            /// 1 이상 :프로시져 수행 실패 
            if (resultCls.ResultInt == 0)
            {
            }
            else if (resultCls.ResultInt != 0)
            {
                if (IDATMessageBox.Show("Error Code : " + resultCls.ResultInt.ToString(), msgCaption, lang.GetMessageString(resultCls.ResultString), IDAT_MessageType.Error, ShowTime) == DialogResult.Retry)
                {
                    _clsLog.SaveUseHistory("ProcError", Global.Global_Variable.IPADDRESS, "ProcErrorMessage", lang.GetMessageString(resultCls.ResultString));

                    StringBuilder sb = new StringBuilder();
                    sb.Append("From : " + user + "[" + Global.Global_Variable.IPADDRESS + "]");
                    sb.Append("<BR>");
                    sb.Append("<BR>");
                    sb.Append("Message");
                    sb.Append(lang.GetMessageString(resultCls.ResultString));

                    iDATMessageBox.SendErrorReport(sb.ToString(), proc, param);
                }

            }
        }

        /// <summary>
        /// 프로시져 수행후 메시지박스를 보여줍니다.
        /// </summary>
        /// <param name="resultCls">IDAT_WebService.clsDataSetStruct Class</param>
        /// <param name="msgCaption">메시지 박스 타이틀 Text</param>
        public static void ShowProcResultMessage(WSResults resultCls, string msgCaption, string user, string proc, Dictionary<string, object> param, bool ShowOKMessage)
        {
            // 메인 메시지바에 결과를 보여준다.
            Program.frmM.ProgramMessage = lang.GetMessageString(resultCls.ResultString);

            /// 0 : 프로시져 수행 성공
            /// 1 이상 :프로시져 수행 실패 
            if (resultCls.ResultInt == 0)
            {
                if (ShowOKMessage)
                {
                    IDATMessageBox.Show(lang.GetMessageString(resultCls.ResultString), IDAT_MessageType.Information);
                }
            }
            else if (resultCls.ResultInt != 0)
            {
                if (IDATMessageBox.Show("Error Code : " + resultCls.ResultInt.ToString(), msgCaption, lang.GetMessageString(resultCls.ResultString), IDAT_MessageType.Error) == DialogResult.Retry)
                {
                    _clsLog.SaveUseHistory("ProcError", Global.Global_Variable.IPADDRESS, "ProcErrorMessage", lang.GetMessageString(resultCls.ResultString));

                    StringBuilder sb = new StringBuilder();
                    sb.Append("From : " + user + "[" + Global.Global_Variable.IPADDRESS + "]");
                    sb.Append("<BR>");
                    sb.Append("<BR>");
                    sb.Append("Message");
                    sb.Append(lang.GetMessageString(resultCls.ResultString));

                    iDATMessageBox.SendErrorReport(sb.ToString(), proc, param);
                }
            }
        }

        /// <summary>
        /// 프로시져 수행후 메시지박스를 보여줍니다.
        /// </summary>
        /// <param name="resultCls">IDAT_WebService.clsDataSetStruct Class</param>
        /// <param name="msgCaption">메시지 박스 타이틀 Text</param>
        /// <param name="ShowTime">자동으로 보여주는 시간</param>
        public static void ShowProcResultMessage(WSResults resultCls, string msgCaption, int ShowTime, string user, string proc, Dictionary<string, object> param, bool ShowOKMessage)
        {
            // 메인 메시지바에 결과를 보여준다.
            Program.frmM.ProgramMessage = lang.GetMessageString(resultCls.ResultString);

            /// 0 : 프로시져 수행 성공
            /// 1 이상 :프로시져 수행 실패 
            if (resultCls.ResultInt == 0)
            {
                if (ShowOKMessage)
                {
                    IDATMessageBox.Show(lang.GetMessageString(resultCls.ResultString), IDAT_MessageType.Information);
                }
            }
            else if (resultCls.ResultInt != 0)
            {
                if (IDATMessageBox.Show("Error Code : " + resultCls.ResultInt.ToString(), msgCaption, lang.GetMessageString(resultCls.ResultString), IDAT_MessageType.Error, ShowTime) == DialogResult.Retry)
                {
                    _clsLog.SaveUseHistory("ProcError", Global.Global_Variable.IPADDRESS, "ProcErrorMessage", lang.GetMessageString(resultCls.ResultString));

                    StringBuilder sb = new StringBuilder();
                    sb.Append("From : " + user + "[" + Global.Global_Variable.IPADDRESS + "]");
                    sb.Append("<BR>");
                    sb.Append("<BR>");
                    sb.Append("Message");
                    sb.Append(lang.GetMessageString(resultCls.ResultString));

                    iDATMessageBox.SendErrorReport(sb.ToString(), proc, param);
                }

            }
        }

        #endregion

        public static void SendErrorReport(string msg, string ErrorProc, Dictionary<string, object> pParam)
        {
            string procName = "PKG_ADMIN.SEND_MAIL";

            Dictionary<string, object> param = new Dictionary<string, object>();

            string errParms = "";

            string content = msg;

            if (ErrorProc.Length > 0)
            {
                errParms = ErrorProc + "<br>";
            }

            if (pParam.Count > 0)
            {
                for (int i = 0; i < pParam.Count; i++)
                {
                    errParms = errParms + pParam.ElementAt(i).Key.ToString() + " = " + pParam.ElementAt(i).Value.ToString() + "<br>";
                }
            }

            param.Add("A_PARAMS", errParms);
            param.Add("A_CONTENS", content);


            WSResults result = Program.frmM.DB.Execute_Proc(procName, 1, param);

            if (result.ResultInt == 0)
            {
            }
            else
            {
                LogUtility _LogUtility = new LogUtility();
                _LogUtility.LogWrite(lang.GetMessageString(result.ResultString));
            }
        }

        /// <summary>
        /// 에러 메시지를 보여줍니다.
        /// </summary>
        /// <param name="ex">Exception</param>
        public static void ErrorMessage(Exception ex, string user)
        {
            // 메인 메시지바에 결과를 보여준다.
            Program.frmM.ProgramMessage = ex.Message;

            _clsLog.SaveUseHistory("Error", Global.Global_Variable.IPADDRESS, "ErrorMessage", ex.ToString());

            if (IDATMessageBox.Show(ex.ToString(), "Error", IDAT_MessageType.Error) == DialogResult.Retry)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("From : " + user + "[" + Global.Global_Variable.IPADDRESS + "]");
                sb.Append("<BR>");
                sb.Append("<BR>");
                sb.Append("Message");
                sb.Append("<BR>");
                sb.Append(ex.Message);
                sb.Append("<BR>");
                sb.Append("<BR>");
                sb.Append("StackTrace");
                sb.Append("<BR>");
                sb.Append(ex.StackTrace);
                sb.Append("<BR>");
                sb.Append("<BR>");
                sb.Append("HelpLink");
                sb.Append("<BR>");
                sb.Append(ex.HelpLink);
                sb.Append("<BR>");
                sb.Append("<BR>");
                sb.Append("Source");
                sb.Append("<BR>");
                sb.Append(ex.Source);
            }
        }

        /// <summary>
        /// 에러 메시지를 보여줍니다.
        /// </summary>
        /// <param name="ex">Exception</param>
        public static void ErrorMessage(Exception ex, string user, string proc, Dictionary<string, object> param)
        {
            // 메인 메시지바에 결과를 보여준다.
            Program.frmM.ProgramMessage = ex.Message;

            _clsLog.SaveUseHistory("Error", Global.Global_Variable.IPADDRESS, "ErrorMessage", ex.ToString());

            if (IDATMessageBox.Show(ex.ToString(), "Error", IDAT_MessageType.Error) == DialogResult.Retry)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("From : " + user + "[" + Global.Global_Variable.IPADDRESS + "]");
                sb.Append("<BR>");
                sb.Append("<BR>");
                sb.Append("Message");
                sb.Append("<BR>");
                sb.Append(ex.Message);
                sb.Append("<BR>");
                sb.Append("<BR>");
                sb.Append("StackTrace");
                sb.Append("<BR>");
                sb.Append(ex.StackTrace);
                sb.Append("<BR>");
                sb.Append("<BR>");
                sb.Append("HelpLink");
                sb.Append("<BR>");
                sb.Append(ex.HelpLink);
                sb.Append("<BR>");
                sb.Append("<BR>");
                sb.Append("Source");
                sb.Append("<BR>");
                sb.Append(ex.Source);
                iDATMessageBox.SendErrorReport(sb.ToString(), proc, param);
            }
        }

        /// <summary>
        /// 에러 메시지를 보여줍니다.
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="ShowTime">자동으로 보여주는 시간</param>
        public static void ErrorMessage(Exception ex, int ShowTime, string user, string proc, Dictionary<string, object> param)
        {
            // 메인 메시지바에 결과를 보여준다.
            Program.frmM.ProgramMessage = ex.Message;

            _clsLog.SaveUseHistory("Error", Global.Global_Variable.IPADDRESS, "ErrorMessage", ex.ToString());

            if (IDATMessageBox.Show(ex.ToString(), "Error", IDAT_MessageType.Error, ShowTime) == DialogResult.Retry)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("From : " + user + "[" + Global.Global_Variable.IPADDRESS + "]");
                sb.Append("<BR>");
                sb.Append("<BR>");
                sb.Append("Message");
                sb.Append("<BR>");
                sb.Append(ex.Message);
                sb.Append("<BR>");
                sb.Append("<BR>");
                sb.Append("StackTrace");
                sb.Append("<BR>");
                sb.Append(ex.StackTrace);
                sb.Append("<BR>");
                sb.Append("<BR>");
                sb.Append("HelpLink");
                sb.Append("<BR>");
                sb.Append(ex.HelpLink);
                sb.Append("<BR>");
                sb.Append("<BR>");
                sb.Append("Source");
                sb.Append("<BR>");
                sb.Append(ex.Source);

                iDATMessageBox.SendErrorReport(sb.ToString(), proc, param);
            }
        }

        /// <summary>
        /// 에러 메시지를 보여줍니다.
        /// </summary>
        /// <param name="msg">메시지</param>
        /// <param name="caption">캡션 타이틀</param>
        /// <param name="ShowTime">자동으로 보여주는 시간</param>
        public static void ErrorMessage(string msg, string caption, int ShowTime, string user, string proc, Dictionary<string, object> param)
        {
            // 메인 메시지바에 결과를 보여준다.
            Program.frmM.ProgramMessage = lang.GetMessageString(msg);

            _clsLog.SaveUseHistory("Error", Global.Global_Variable.IPADDRESS, "ErrorMessage", lang.GetMessageString(msg));

            if (IDATMessageBox.Show(msg, caption + " ", IDAT_MessageType.Error, ShowTime) == DialogResult.Retry)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("From : " + user + "[" + Global.Global_Variable.IPADDRESS + "]");
                sb.Append("<BR>");
                sb.Append("<BR>");
                sb.Append("Message");
                sb.Append("<BR>");
                sb.Append(lang.GetMessageString(msg));

                iDATMessageBox.SendErrorReport(sb.ToString(), proc, param);
            }
        }

        /// <summary>
        /// 에러 메시지를 보여줍니다.
        /// </summary>
        /// <param name="msg">메시지</param>
        /// <param name="caption">캡션 타이틀</param>
        /// <param name="ShowTime">자동으로 보여주는 시간</param>
        public static void ErrorMessage(string msg, string caption, int ShowTime)
        {
            // 메인 메시지바에 결과를 보여준다.
            Program.frmM.ProgramMessage = lang.GetMessageString(msg);

            _clsLog.SaveUseHistory("Error", Global.Global_Variable.IPADDRESS, "ErrorMessage", lang.GetMessageString(msg));

            IDATMessageBox.Show(lang.GetMessageString(msg), caption, IDAT_MessageType.Error, ShowTime);
        }
        
        /// <summary>
        /// 에러 메시지를 보여줍니다.
        /// </summary>
        /// <param name="msg">메시지</param>
        /// <param name="caption">캡션 타이틀</param>
        /// <param name="ShowTime">자동으로 보여주는 시간</param>
        public static void ErrorMessage(string msg, string submsg, string caption, int ShowTime)
        {
            // 메인 메시지바에 결과를 보여준다.
            Program.frmM.ProgramMessage = lang.GetMessageString(msg);

            _clsLog.SaveUseHistory("Error", Global.Global_Variable.IPADDRESS, "ErrorMessage", lang.GetMessageString(msg));

            IDATMessageBox.Show(lang.GetMessageString(msg) +Environment.NewLine + submsg, caption, IDAT_MessageType.Error, ShowTime);
        }

        /// <summary>
        /// 변환 메시지를 리턴
        /// </summary>
        /// <param name="msg">메시지</param>
        public static string GetMessage(string msg)
        {
            // 메시지 변환 결과를 리턴
            return lang.GetMessageString(msg);
        }

        /// <summary>
        /// 저장에 대한 메시지박스를 보여줍니다.
        /// </summary>
        /// <param name="ItemCaption">저장하려는 아이템</param>
        /// <param name="e_type">신규/저장</param>
        /// <returns></returns>
        public static DialogResult SaveQuestionMessage(string ItemCaption, SAVE_Q_TYPE e_type)
        {
            LanguageInformation clsLan = new LanguageInformation();
            string msg = clsLan.GetMessageString("MSG008");
            return IDATMessageBox.Show(string.Format(lang.GetMessageString(msg), ItemCaption), e_type == SAVE_Q_TYPE.New ? clsLan.GetMessageString("New") : clsLan.GetMessageString("Save"), IDAT_MessageType.Question);
        }

        /// <summary>
        /// 저장에 대한 메시지박스를 보여줍니다.
        /// </summary>
        /// <param name="ItemCaption">저장하려는 아이템</param>
        /// <param name="e_type">신규/저장</param>
        /// <returns></returns>
        public static DialogResult QuestionMessage(string msg, string title)
        {
            return IDATMessageBox.Show(lang.GetMessageString(msg), title, IDAT_MessageType.Question);
        }

        /// <summary>
        /// OK메시지박스를 보여줍니다.
        /// </summary>
        /// <param name="Caption">내용</param>
        /// <param name="title">타이틀</param>
        /// <param name="ShowTime">출력시간</param>
        /// <returns>Dialogresult</returns>
        public static DialogResult OKMessage(string strMessage, string title)
        {
            // 메인 메시지바에 결과를 보여준다.
            Program.frmM.ProgramMessage = lang.GetMessageString(strMessage);

            return IDATMessageBox.Show(lang.GetMessageString(strMessage), title, IDAT_MessageType.Information);
        }

        /// <summary>
        /// OK메시지박스를 보여줍니다.
        /// </summary>
        /// <param name="Caption">내용</param>
        /// <param name="title">타이틀</param>
        /// <param name="ShowTime">출력시간</param>
        /// <returns>Dialogresult</returns>
        public static DialogResult OKMessage(string strMessage, string title, int ShowTime)
        {
            // 메인 메시지바에 결과를 보여준다.
            Program.frmM.ProgramMessage = lang.GetMessageString(strMessage);

            return IDATMessageBox.Show(lang.GetMessageString(strMessage), title, IDAT_MessageType.Information, ShowTime);
        }

        /// <summary>
        /// Warning메시지박스를 보여줍니다.
        /// </summary>
        /// <param name="Caption">내용</param>
        /// <param name="title">타이틀</param>
        /// <param name="ShowTime">출력시간</param>
        /// <returns>Dialogresult</returns>
        public static DialogResult WARNINGMessage(string strMessage, string title, int ShowTime)
        {
            // 메인 메시지바에 결과를 보여준다.
            Program.frmM.ProgramMessage = lang.GetMessageString(strMessage);

            _clsLog.SaveUseHistory("Warning", Global.Global_Variable.IPADDRESS, "WarningMessage", strMessage);

            return IDATMessageBox.Show(lang.GetMessageString(strMessage), title, IDAT_MessageType.Warning, ShowTime);
        }

        /// <summary>
        /// MEMO메시지박스를 보여줍니다.
        /// </summary>
        /// <param name="strMessage">메모내용</param>
        /// <param name="title">타이틀</param>
        /// <returns>Dialogresult</returns>
        public static DialogResult MemoMessage(string strMessage, string title, out string memo)
        {
            DialogResult dlg = IDATMessageBox.Show(strMessage, title, IDAT_MessageType.MEMOOK);
            if (dlg == DialogResult.OK)
                memo = IDATMessageBox.MemoText;
            else
                memo = "";

            return dlg;
        }


        /// <summary>
        /// 프로그램 하단의 메시지를 출력한다.
        /// </summary>
        /// <param name="msg">메시지 내용</param>
        public static void PROGRAMMessage(string msg)
        {
            // 메인 메시지바에 결과를 보여준다.
            Program.frmM.ProgramMessage = new LanguageInformation().GetMessageString(msg);
        }

        /// <summary>
        /// 파일 열기 메시지
        /// </summary>
        /// <param name="fileName">파일 경로</param>
        public static void ShowOpenFileMessage(XtraForm xtraForm, string fileName)
        {
            if (XtraMessageBox.Show("Do you want to open this file?", "Export To...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Verb = "Open";
                    process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    process.Start();
                }
                catch
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(xtraForm, "Cannot find an application on your system suitable for openning the file with exported data.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Export Message
        /// </summary>
        /// <param name="xtraForm">GridviewControl Export Message를 표시해준다.</param>
        /// <param name="m_GridView">그리드 뷰</param>
        public static void ShowExportFileMessage(XtraForm xtraForm, GridView m_GridView)
        {
            SaveFileDialog saveFileDlg = new SaveFileDialog();
            saveFileDlg.RestoreDirectory = true;
            saveFileDlg.Filter = "Excel files (*.xls)|*.xls|XML files (*.xml)|*.xml|PDF files (*.pdf)|*.pdf|HTML files (*.htm)|*.htm|RTF files (*.rtf)|*.rtf|TXT files (*.txt)|*.txt";
            IDAT.Devexpress.GRID.IDATDevExpress_GridControl _clsDev = new IDAT.Devexpress.GRID.IDATDevExpress_GridControl();
            if (saveFileDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string type = saveFileDlg.FileName.Substring(saveFileDlg.FileName.LastIndexOf(".") + 1, saveFileDlg.FileName.Length - (saveFileDlg.FileName.LastIndexOf(".") + 1));
                    switch (type.ToLower())
                    {
                        case "xls":
                            _clsDev.ExcelExportTo(m_GridView, saveFileDlg.FileName);
                            break;
                        case "xml":
                            _clsDev.XmlExportTo(m_GridView, saveFileDlg.FileName);
                            break;
                        case "pdf":
                            _clsDev.PDFExportTo(m_GridView, saveFileDlg.FileName);
                            break;
                        case "htm":
                            _clsDev.HTMLExportTo(m_GridView, saveFileDlg.FileName);
                            break;
                        case "html":
                            _clsDev.HTMLExportTo(m_GridView, saveFileDlg.FileName);
                            break;
                        case "rtf":
                            _clsDev.RTFExportTo(m_GridView, saveFileDlg.FileName);
                            break;
                        case "txt":
                            _clsDev.TxtExportTo(m_GridView, saveFileDlg.FileName);
                            break;
                        default:
                            saveFileDlg.FileName = saveFileDlg.FileName + ".xls";
                            _clsDev.ExcelExportTo(m_GridView, saveFileDlg.FileName);
                            break;
                    }

                    iDATMessageBox.ShowOpenFileMessage(xtraForm, saveFileDlg.FileName);
                }
                catch (Exception ex)
                {
                    iDATMessageBox.ErrorMessage(ex, 5, Global.Global_Variable.USER_ID, "", null);
                }
            }
        }

        /// <summary>
        /// Wait 메시지 박스 정보를 보여준다.
        /// </summary>
        public static void ShowWait(Form form, string caption, string desc)
        {
            IDATMessageBox.ShowWait(form, caption, desc);
        }

        /// <summary>
        /// Wait 메시지 박스 Caption, Desc 정보를 수정합니다.
        /// </summary>
        public static void WaitChangeCommand(COMWAITFORM.WaitFormCommand CommandType, string strDesc)
        {
            IDATMessageBox.WaitChangeCommand(CommandType, strDesc);
        }

        /// <summary>
        /// Wait 메시지 박스 정보를 닫음.
        /// </summary>
        public static void CloseWait()
        {
            IDATMessageBox.CloseWait();
        }
    }
}
