using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HAENGSUNG_HNSMES_UI.Class
{
    class LanguageInformation
    {
        HAENGSUNG_HNSMES_UI.WebService.Business.IDatabaseProcess _DB = null;
        public void SetLanguage()
        {
            _DB = Program.frmM.DB;

            DataSet _ds = _DB.Get_DataBase("PKGSYS_COMM.GET_GLOSSARY", 1, new string[]{"A_SYSTEM"}, new string[] {Global.Global_Variable.SYSTEMCODE});

            if (_ds != null)
            {
                if (File.Exists(Global.Global_Variable.PATH_DataLanguage))
                {
                    File.Delete(Global.Global_Variable.PATH_DataLanguage);
                }

                _ds.WriteXml(Global.Global_Variable.PATH_DataLanguage);
                _ds.ReadXml(Global.Global_Variable.PATH_DataLanguage);
            }
            else
            {
                _ds = new DataSet();
                if (File.Exists(Global.Global_Variable.PATH_DataLanguage))
                {
                    _ds.ReadXml(Global.Global_Variable.PATH_DataLanguage);
                }
            }

            if (_ds != null)
            {
                Global.Global_Variable.LANGUAGE = _ds.Copy();
            }
            else
            {
                iDATMessageBox.ErrorMessage(this.GetMessageString("MSG017"), "Language File Load", 0, Global.Global_Variable.USER_ID, "", null);
            }
        }


        /// <summary>
        /// DevExpress RadioGroup 의 Item의 Language변환
        /// </summary>
        /// <param name="radioGrp"></param>
        /// <returns></returns>
        public void SetDevExpressRadioGroupLanguage(IDAT.Devexpress.DXControl.IdatDxRadioGroup radioGrp)
        {
            for (int i = 0; i < radioGrp.Properties.Items.Count; i++)
            {
                radioGrp.Properties.Items[i].Description = GetMessageString(radioGrp.Properties.Items[i].Description);
            }
        }

        /// <summary>
        /// 리소스 메시지를 가져온다.
        /// </summary>
        /// <param name="Code">코드 값</param>
        /// <returns>메시지 값</returns>
        public string GetMessageString(string Code)
        {
            try
            {
                if (Global.Global_Variable.LANGUAGE.Tables[0].Rows.Count > 0)
                {
                    DataRow[] drs = Global.Global_Variable.LANGUAGE.Tables[0].Select(string.Format("GLSR = '{0}'", Code.ToUpper()));

                    if (drs.Length > 0)
                    {
                        if (Settings_IDAT.Default.Language.ToUpper() == "LOCAL")
                        {
                            string locMsg = "";
                            switch (Application.CurrentCulture.Name.ToUpper())
                            {
                                case "KO-KR":
                                    locMsg = drs[0]["KORGLSR"].ToString();
                                    break;
                                case "EN-US":
                                    locMsg = drs[0]["ENGGLSR"].ToString();
                                    break;
                                default :
                                    locMsg = drs[0]["NATGLSR"].ToString();
                                    break;
                            }
                            
                            Program.frmM.ProgramMessage = locMsg;
                            return locMsg;
                        }
                        else if (Settings_IDAT.Default.Language.ToUpper() == "KOREAN")
                        {
                            string korMsg = drs[0]["KORGLSR"].ToString();
                            Program.frmM.ProgramMessage = korMsg;
                            return korMsg;
                        }
                        else if (Settings_IDAT.Default.Language.ToUpper() == "ENGLISH")
                        {
                            string engMsg = drs[0]["ENGGLSR"].ToString();
                            Program.frmM.ProgramMessage = engMsg;
                            return engMsg;
                        }
                        else
                        {
                            string engMsg = drs[0]["NATGLSR"].ToString();
                            Program.frmM.ProgramMessage = engMsg;
                            return engMsg;
                        }
                    }
                    else
                    {
                        Program.frmM.ProgramMessage = Code;
                        return Code;
                    }
                }
                else
                {
                    Program.frmM.ProgramMessage = Code;
                    return Code;
                }
            }
            catch
            {
                return Code;
            }
        }

        public string GetColumnsTooltipString(string Code)
        {
            try
            {
                if (Global.Global_Variable.LANGUAGE.Tables[0].Rows.Count > 0)
                {
                    DataRow[] drs = Global.Global_Variable.LANGUAGE.Tables[0].Select(string.Format("GLSR = '{0}'", Code.ToUpper()));

                    if (drs.Length > 0)
                    {
                        string locMsg = drs[0]["REMARKS"].ToString();
                        return locMsg;
                    }
                    else
                    {
                        return Code;
                    }
                }
                else
                {
                    return Code;
                }
            }
            catch
            {
                return Code;
            }
        }
    }
}
