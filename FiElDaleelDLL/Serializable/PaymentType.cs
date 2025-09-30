using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BrokerDLL.Serializable
{
    [DataContract]
   public class PaymentType
    {
        int _ID;
        string _Title;
         [DataMember]
        public string Name
        {
            get { return _Title; }
            set { _Title = value; }
        }
         [DataMember]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public PaymentType(int id, string title)
        {
            _ID = id;
            _Title = title;
        }
    }
}
