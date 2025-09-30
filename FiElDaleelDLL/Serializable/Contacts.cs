using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BrokerDLL.Serializable
{
    [DataContract]
   public class Contacts
    {
        string _Email;
        string _Phone;

        [DataMember]
        public string Email
        {
            get
            {
                return _Email;
            }

            set
            {
                _Email = value;
            }
        }

        [DataMember]
        public string Phone
        {
            get
            {
                return _Phone;
            }

            set
            {
                _Phone = value;
            }
        }
    }
}
