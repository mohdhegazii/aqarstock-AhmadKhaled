using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BrokerDLL.Serializable
{
    [DataContract]
  public class RealEstatePhoto
    {
        string _PhotoURL;
        bool _IsDefault;
         [DataMember]
        public bool IsDefault
        {
            get { return _IsDefault; }
            set { _IsDefault = value; }
        }
         [DataMember]
        public string PhotoURL
        {
            get { return _PhotoURL; }
            set { _PhotoURL = value; }
        }
        public RealEstatePhoto(string photourl, bool isdefault)
        {
            _IsDefault = isdefault;
            _PhotoURL = photourl.Replace("~/", "");
        }
    }
}
