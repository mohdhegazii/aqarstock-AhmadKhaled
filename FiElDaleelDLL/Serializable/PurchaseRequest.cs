using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BrokerDLL.Serializable
{
    [DataContract]
  public class PurchaseRequest
    {
        string _Name;
        string _Phone;
        string _Email;
        string _Message;
        int _RealEstateID;
        string _UserName;
        [DataMember]
        public int RealEstateID
        {
            get { return _RealEstateID; }
            set { _RealEstateID = value; }
        }
        [DataMember]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        [DataMember]
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        [DataMember]
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        [DataMember]
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        [DataMember]
        public string UserName
        {
            get
            {
                return _UserName;
            }

            set
            {
                _UserName = value;
            }
        }
    }
}
