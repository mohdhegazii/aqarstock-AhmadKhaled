using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BrokerDLL.Serializable
{
    [DataContract]
   public class RealEstateCriteria
    {
        string _Name;
        string _Value;
         [DataMember]
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
         [DataMember]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public RealEstateCriteria(string name, string value)
        {
            _Name = name;
            if (value != "true")
            {
                _Value = value;
            }
            else
            {
                _Value = "true";
            }
        }

    }
}
