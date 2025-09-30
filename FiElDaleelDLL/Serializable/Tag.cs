using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BrokerDLL.Serializable
{
    [DataContract]
    public class Tag
    {
        string _Name;
        string _URL;

        [DataMember]
        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = value;
            }
        }
        [DataMember]
        public string URL
        {
            get
            {
                return _URL;
            }

            set
            {
                _URL = value;
            }
        }

        public Tag(BrokerDLL.Tag tag)
        {
            _Name = tag.Name;
            _URL = tag.URL;
        }
    }
}
