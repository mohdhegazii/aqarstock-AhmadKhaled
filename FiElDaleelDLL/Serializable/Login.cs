using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BrokerDLL.Serializable
{
    [DataContract]
    public class Login
    {
        string _UserName;
        string _Password;
        int _RealEstateId;

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

        [DataMember]
        public string Password
        {
            get
            {
                return _Password;
            }

            set
            {
                _Password = value;
            }
        }

        [DataMember]
        public int RealEstateId
        {
            get
            {
                return _RealEstateId;
            }

            set
            {
                _RealEstateId = value;
            }
        }
    }
}
