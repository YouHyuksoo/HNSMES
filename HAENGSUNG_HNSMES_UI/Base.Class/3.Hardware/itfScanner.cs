using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HAENGSUNG_HNSMES_UI.Class
{
    interface itfScanner
    {
        void Data_Scan(string p_strType, string p_strData);
        void Data_SubScan(string p_strType, string p_strData);
    }
}
