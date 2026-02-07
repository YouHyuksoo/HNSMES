using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HAENGSUNG_HNSMES_UI.WebService.Access
{
    public enum WS_RESULT_TYPE
    {
        STRING,
        INT,
        DATASET
    }

    /// <summary>
    /// 웹서비스 리턴값 형태를 통합해주는 파라메터 정보입니다.
    /// </summary>
    public class WSResults
    {
        private string _resultString;

        public string ResultString
        {
            get
            {
                return _resultString;
            }
            set
            {
                _resultString = value;
                this.RaisePropertyChanged( WS_RESULT_TYPE.STRING);
            }
        }

        private int _resultInt;

        public int ResultInt
        {
            get
            {
                return _resultInt;
            }
            set
            {
                _resultInt = value;
                this.RaisePropertyChanged(WS_RESULT_TYPE.INT);
            }
        }

        private DataSet _resultData;

        public DataSet ResultDataSet 
        {
            get
            {
                return _resultData;
            }
            set
            {
                _resultData = value;
                this.RaisePropertyChanged(WS_RESULT_TYPE.DATASET);
            }
        }

        public event CustomPropertyChangedEventHander PropertyChanged;
        public delegate void CustomPropertyChangedEventHander(object sender, WS_RESULT_TYPE resultType);

        protected void RaisePropertyChanged(WS_RESULT_TYPE propertyType)
        {
            if ((PropertyChanged != null))
            {
                PropertyChanged(this, propertyType);
            }
        }
    }
}
