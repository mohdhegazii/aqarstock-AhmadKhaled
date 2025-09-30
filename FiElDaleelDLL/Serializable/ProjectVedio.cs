using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BrokerDLL.Serializable
{
    [DataContract]
   public class ProjectVedio
    {
        int _ID;
        string _Name;
        string _URL;
        string _Embed;

        [DataMember]
        public string Embed
        {
            get { return _Embed; }
            set { _Embed = value; }
        }

        [DataMember]
        public string URL
        {
            get { return _URL; }
            set { _URL = value; }
        }

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
        public ProjectVedio(BrokerDLL.RealEstateProjectVideo Video)
        {
            _ID = Video.ID;
            _Name = Video.TiTle;
            _URL = Video.URL;
           _Embed = Video.EmedCode;
        }
    }
}
