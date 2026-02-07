using System.Collections.Generic;

using NGS.WCFClient;
using NGS.WCFClient.DatabaseService;

// 넷트웍 체크를 위해 다음과 같은 네임스페이스를 쓴다.
using System.ServiceModel;

namespace HAENGSUNG_HNSMES_UI.WebService.Access
{
    class WCFServiceProcess
    {
        //private string xmlPath = Global.Global_Variable.strDataLocalDB_Path;

        private NGS.WCFClient.DatabaseServiceClientHelper WcfSvr = null;
        //private NGS.WCFClient.ControlServiceClientHelper WcfControlSvr = null;

        #region [생성자]

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="WCFSvrAddress">웹서비스 주소</param>
        public WCFServiceProcess()
        {
            WcfSvr = new DatabaseServiceClientHelper();
            //WcfControlSvr = new ControlServiceClientHelper();

            WcfSvr.DatabaseServiceSettings = Program.m_DatabaseSettings;
            //WcfControlSvr.ControlServiceSettings = Program.m_ControlSettings;
        }

        #endregion
         
        /// 1. 프로시져를 수행합니다.
        /// 2. Function을 수행합니다.
        /// 7. 웹서비스 상태를 체크합니다.
        /// 8. 웹서비스를 오픈합니다.
        /// 9. 웹서비스를 닫습니다.
        #region [Public Method]

        /// [1]
        /// <summary>
        /// 프로시져를 수행합니다.
        /// </summary>
        /// <param name="ProcName">프로시져명</param>
        /// <param name="aryName">프로시져 파라메터 이름</param>
        /// <param name="aryValue">프로시져 파라메터 값</param>
        /// <returns>clsDataSetStruct 구조체 클래스</returns>
        public WSResults ExecuteProcCls(string ProcName, int overload, Dictionary<string, object> param)
        {
            WSResults clsResult = new WSResults();
            ReturnDataStructure result = null;

            try
            {
                if (GetWsConnectStatus())
                {
                    WcfSvr.SpParam = param;
                    result = WcfSvr.ExecuteProc(ProcName, overload);
                }
                else
                {
                    result = new ReturnDataStructure();
                    result.ReturnInt = -9;
                    result.ReturnDataSet = null;
                    result.ReturnString = "disconnected WCF Service Server";
                }
            }
            catch (System.Exception ex) // 웹서비스 서버가 중지
            {
                result = new ReturnDataStructure();
                result.ReturnInt = -9;
                result.ReturnDataSet = null;
                result.ReturnString = ex.Message;//"disconnected WCF Service Server";
            }
            finally
            {
                clsResult.ResultDataSet = result.ReturnDataSet;
                clsResult.ResultString = result.ReturnString;
                clsResult.ResultInt = result.ReturnInt;
            }

            return clsResult;
        }

        public WSResults ExecuteProcCls(string ProcName, Dictionary<string, object> param)
        {
            WSResults clsResult = new WSResults();
            ReturnDataStructure result = null;

            try
            {
                if (GetWsConnectStatus())
                {
                    WcfSvr.SpParam = param;
                    result = WcfSvr.ExecuteProc(ProcName, 1);
                }
                else
                {
                    result = new ReturnDataStructure();
                    result.ReturnInt = -9;
                    result.ReturnDataSet = null;
                    result.ReturnString = "disconnected WCF Service Server";
                }
            }
            catch//(InvalidOperationException opEx) // 웹서비스 서버가 중지
            {
                result = new ReturnDataStructure();
                result.ReturnInt = -9;
                result.ReturnDataSet = null;
                result.ReturnString = "disconnected WCF Service Server";
            }
            finally
            {
                clsResult.ResultDataSet = result.ReturnDataSet;
                clsResult.ResultString = result.ReturnString;
                clsResult.ResultInt = result.ReturnInt;
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
                bool flag = false;
                CommunicationState state = new CommunicationState();

                // 넷트웍 연결 상태를 접근할때 3번 시도한다.(Open을 실패했을 경우..)
                for (int i = 0; i < 3; i++)
                {
                    state = WcfSvr.ServiceState();
                    
                    if (i > 0)
                    {
                        Program.frmM.ProgramMessage = "We retry to get into WCF Service... " + i.ToString();
                    }

                    switch (state)
                    {
                        case CommunicationState.Closed:
                            Program.frmM.btnWCFStatus.ImageIndex = 29;
                            flag = false;
                            break;
                        case CommunicationState.Closing:
                            Program.frmM.btnWCFStatus.ImageIndex = 29;
                            flag = false;
                            break;
                        case CommunicationState.Created:
                            Program.frmM.btnWCFStatus.ImageIndex = 28;
                            flag = true;
                            break;
                        case CommunicationState.Faulted:
                            Program.frmM.btnWCFStatus.ImageIndex = 29;
                            flag = false;
                            break;
                        case CommunicationState.Opened:
                            Program.frmM.btnWCFStatus.ImageIndex = 28;
                            flag = true;
                            break;
                        case CommunicationState.Opening:
                            Program.frmM.btnWCFStatus.ImageIndex = 29;
                            flag = false;
                            break;
                    }
                    if (flag) return flag;
                }

                return flag;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
