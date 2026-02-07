using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using System.Linq;
using System.Diagnostics;
using System.Collections;
 
// user namespace
using HAENGSUNG_HNSMES_UI.Class;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;

using DevExpress.Utils;
using IDAT.WebService;

// 넷트웍 체크를 위해 다음과 같은 네임스페이스를 쓴다.
using Microsoft.VisualBasic.Devices;
using System.Net;
using System.IO;

namespace HAENGSUNG_HNSMES_UI.WebService.Access
{
    /// <summary>
    /// 웹서비스 비지니스 로직 clsWebServiceManager 클래스입니다.
    /// </summary>
    public class WebServiceProcess
    {
        private readonly string xmlPath = HAENGSUNG_HNSMES_UI.Global.Global_Variable.strDataLocalDB_Path;
        private readonly IDAT.WebService.clsWebService WebSvr;

        #region [생성자]

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="WebSvrAddress">웹서비스 주소</param>
        public WebServiceProcess()
        {
            WebSvr = new clsWebService();
        }

        #endregion

        #region [Public Method]

        public WSResults ExecuteProcCls(string ProcName, Dictionary<string, object> param)
        {
            WSResults clsResult = new WSResults();
            clsDataSetStruct result = null;

            ArrayList aryName = new ArrayList();
            ArrayList aryValue = new ArrayList();

            for (int i = 0; i < param.Count; i++)
            {
                aryName.Add(param.Keys.ElementAt(i));
                aryValue.Add(param.Values.ElementAt(i));
            }
            
            try
            {
                if (GetWsConnectStatus())
                {
                    result = WebSvr.ExecuteProcCls(ProcName, aryName, aryValue);
                }
                else
                {
                    result = new clsDataSetStruct
                    {
                        pResultInt = -9,
                        pResultDs = null,
                        pResultString = "disconnected WebService Server"
                    };
                }
            }
            catch (InvalidOperationException) // 웹서비스 서버가 중지
            {
                result = new clsDataSetStruct
                {
                    pResultInt = -9,
                    pResultDs = null,
                    pResultString = "disconnected WebService Server"
                };
            }
            finally
            {
                clsResult.ResultDataSet = result.pResultDs;
                clsResult.ResultInt = result.pResultInt;
                clsResult.ResultString = result.pResultString;
            }

            return clsResult;
        }

        public WSResults ExecuteProcBatchDs(DataSet ds)
        {
            WSResults clsResult = new WSResults();
            clsDataSetStruct result = null;

            try
            {
                if (GetWsConnectStatus())
                {
                    result = WebSvr.ExecuteProcBatchDS(ds);
                }
                else
                {
                    result = new clsDataSetStruct
                    {
                        pResultInt = -9,
                        pResultDs = null,
                        pResultString = "disconnected WebService Server"
                    };
                }
            }
            catch (InvalidOperationException) // 웹서비스 서버가 중지
            {
                result = new clsDataSetStruct
                {
                    pResultInt = -9,
                    pResultDs = null,
                    pResultString = "disconnected WebService Server"
                };
            }
            finally
            {
                clsResult.ResultDataSet = result.pResultDs;
                clsResult.ResultInt = result.pResultInt;
                clsResult.ResultString = result.pResultString;
            }

            return clsResult;
        }

        public WSResults ExecuteQry(string strQry)
        {
            WSResults clsResult = new WSResults();
            clsDataSetStruct result = null;

            try
            {
                result = WebSvr.ExecuteQry(strQry);
            }
            catch (InvalidOperationException) // 웹서비스 서버가 중지
            {
                result = new clsDataSetStruct
                {
                    pResultInt = -9,
                    pResultDs = null,
                    pResultString = "disconnected WebService Server"
                };
            }
            finally
            {
                clsResult.ResultDataSet = result.pResultDs;
                clsResult.ResultInt = result.pResultInt;
                clsResult.ResultString = result.pResultString;
            }

            return clsResult;
        }

        public WSResults ExecuteFunc(string ProcName, Dictionary<string, object> param)
        {
            WSResults clsResult = new WSResults();
            clsDataSetStruct result = null;

            ArrayList aryName = new ArrayList();
            ArrayList aryValue = new ArrayList();

            for (int i = 0; i < param.Count; i++)
            {
                aryName.Add(param.Keys.ElementAt(i));
                aryValue.Add(param.Values.ElementAt(i));
            }

            try
            {
                if (GetWsConnectStatus())
                {
                    result = new clsDataSetStruct
                    {
                        pResultInt = 0,
                        pResultDs = null,
                        pResultString = WebSvr.ExecuteFunc(ProcName, aryName, aryValue)
                    };
                }
                else
                {
                    result = new clsDataSetStruct
                    {
                        pResultInt = -9,
                        pResultDs = null,
                        pResultString = "disconnected WebService Server"
                    };
                }
            }
            catch (InvalidOperationException) // 웹서비스 서버가 중지
            {
                result = new clsDataSetStruct
                {
                    pResultInt = -9,
                    pResultDs = null,
                    pResultString = "disconnected WebService Server"
                };
            }
            finally
            {
                clsResult.ResultString = result.pResultString;
                clsResult.ResultInt = result.pResultInt;
                clsResult.ResultDataSet = result.pResultDs;
            }

            return clsResult;
        }

        /// [7]
        /// <summary>
        /// 웹서비스 상태체크를 합니다.
        /// </summary>
        /// <param name="WebSvrAddress">웹서비스 주소</param>
        /// <returns>연결상태를 리턴합니다.</returns>
        public bool GetWsConnectStatus()
        {
            try
            {
                bool flag = true;

                // 넷트웍 연결 상태를 접근할때 3번 시도한다.(Open을 실패했을 경우..)
                for (int i = 0; i < 3; i++)
                {
                    //flag = true;
                    flag = WebSvr.Open_WebService(Settings_IDAT.Default.WS_Address);

                    if (i > 0)
                    {
                        Program.frmM.ProgramMessage = "We retry to get into WebService... " + i.ToString();
                    }

                    // 상태가 연결 상태이면 속성을 변경한다.
                    if (flag)
                    {
                        Program.frmM.btnWCFStatus.ImageIndex = 28;
                        break;

                    }
                    else
                    {
                        Program.frmM.btnWCFStatus.ImageIndex = 29;
                    }
                }

                return flag;
            }
            catch
            {
                return false;
            }
        }

         double _downloadedByte;

        /// <summary>
        /// 웹 서비스를 통해 파일을 다운 받습니다.
        /// </summary>
        /// <param name="filePath">다운로드 하고자 하는 로컬 경로</param>
        /// <param name="serverPath">서버 파일 경로</param>
        /// <returns>성공유무</returns>
        /// <remarks>
        ///     ================================함수 사용 예제========================================================
        ///     if (XtraMessageBox.Show("Download this file?", "Download", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        ///     {
        ///         try
        ///         {
        ///            if (grdViewSPC.GetFocusedDataRow()["FILENAME"].ToString() == "")
        ///            {
        ///                return;
        ///            }
        /// 
        ///            string addr = Settings.Default.WS_Address.Substring(0, Settings.Default.WS_Address.LastIndexOf("/"));
        ///            string filePath = "C:\\" + grdViewSPC.GetFocusedDataRow()["FILENAME"].ToString();
        ///            string ServerPath = String.Format("{0}/ResultFiles/{1}/{2}", addr, grdViewSPC.GetFocusedDataRow()["FILEPATH"], grdViewSPC.GetFocusedDataRow()["FILENAME"]);
        ///            SaveFileDialog saveDlg = new SaveFileDialog();
        ///            saveDlg.FileName = grdViewSPC.GetFocusedDataRow()["FILENAME"].ToString();
        ///            saveDlg.RestoreDirectory = false;
        ///
        ///            if (saveDlg.ShowDialog() == DialogResult.OK)
        ///            {
        ///                filePath = saveDlg.FileName;
        ///
        ///               if (new clsDBWebServiceManager().WsDownload(filePath, ServerPath))
        ///               {
        ///                    clsMessageBox.ShowOpenFileMessage(this, filePath);
        ///               }
        ///           }
        ///        }
        ///        catch (Exception ex)
        ///         {
        ///            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        ///        }
        ///    }
        /// </remarks>
        public bool WsDownload(string filePath, string serverPath)
        {
            HttpWebRequest hr;
            FileStream fs;
            Stream s;

            try
            {
                hr = HttpWebRequest.Create(serverPath) as HttpWebRequest;

                fs = new FileStream(filePath, FileMode.Create);
                s = hr.GetResponse().GetResponseStream();

                byte[] buffer = new byte[4096];
                int bytesRead = s.Read(buffer, 0, buffer.Length);

                _downloadedByte += bytesRead;

                while (bytesRead > 0)
                {
                    fs.Write(buffer, 0, bytesRead);
                    bytesRead = s.Read(buffer, 0, buffer.Length);
                    _downloadedByte += bytesRead;
                }
                fs.Close();
                return true;
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}