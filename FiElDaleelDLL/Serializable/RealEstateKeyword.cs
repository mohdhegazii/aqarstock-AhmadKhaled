using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BrokerDLL.Serializable
{
    [DataContract]
   public class RealEstateKeyword
    {
        string _Keyword;
         [DataMember]
        public string Keyword
        {
            get { return _Keyword; }
            set { _Keyword = value; }
        }

        public RealEstateKeyword(string keyword)
        {
            _Keyword = keyword;
        }
    }
}
