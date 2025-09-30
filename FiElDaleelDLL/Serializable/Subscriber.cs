using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BrokerDLL.Serializable
{
    [DataContract]
  public  class Subscriber
    {
        int _ID;
        string _OwnerName;
        string _OwnerPhone;
        string _OwnerEmail;

        [DataMember]
        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }
        [DataMember]
        public string OwnerName
        {
            get
            {
                return _OwnerName;
            }

            set
            {
                _OwnerName = value;
            }
        }
        [DataMember]
        public string OwnerPhone
        {
            get
            {
                return _OwnerPhone;
            }

            set
            {
                _OwnerPhone = value;
            }
        }
        [DataMember]
        public string OwnerEmail
        {
            get
            {
                return _OwnerEmail;
            }

            set
            {
                _OwnerEmail = value;
            }
        }

        public Subscriber(string name,string Phone,string Email)
        {
            _OwnerName = name;
            _OwnerEmail = Email;
            _OwnerPhone = Phone;
        }
        public Subscriber(BrokerDLL.Subscriber subscriber)
        {
            _OwnerName = subscriber.FullName;
            _OwnerEmail = subscriber.Email;
            _OwnerPhone = subscriber.MobileNo;
        }
    }
}
