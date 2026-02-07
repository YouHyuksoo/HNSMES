using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

// 자주 쓰는 공용 펑션 모음

namespace HAENGSUNG_HNSMES_UI
{
    public static class HS
    {
        // 데이터테이블을 XML로 변환
        public static string DataTableToXML(DataTable _DataTable)
        {
            return DataTableToXML(_DataTable, "Table");
        }

        public static string DataTableToXML(DataTable _DataTable, string _DataTableName)
        {
            string sXML = string.Empty;
            _DataTable.TableName = _DataTableName;
            using (StringWriter _StringWriter = new StringWriter())
            {
                _DataTable.WriteXml(_StringWriter);
                sXML = _StringWriter.ToString();
            }
            return sXML;
        }


    }
}
