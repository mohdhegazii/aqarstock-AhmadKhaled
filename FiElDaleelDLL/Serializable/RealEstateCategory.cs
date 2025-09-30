using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BrokerDLL.Serializable
{
    [DataContract]
    public class RealEstateCategory
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

        public RealEstateCategory(int id, string title)
        {
            _ID = id;
            _Title = title;
        }
    }
}
