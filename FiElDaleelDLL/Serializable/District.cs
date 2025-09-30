using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BrokerDLL.Serializable
{
   
    [DataContract]
   public class District
    {
        int _ID;
        string _Name;
       [DataMember]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        [DataMember]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public District(int id, string name)
        {
            _ID = id;
            _Name = name;
        }
    }
}
