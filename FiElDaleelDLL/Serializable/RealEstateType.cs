using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BrokerDLL.Serializable
{
    [DataContract]
   public class RealEstateType
    {
        int _ID;
        int _RealEstateCategoryID;
        string _Title;
         [DataMember]
        public string Name
        {
            get { return _Title; }
            set { _Title = value; }
        }
         [DataMember]
        public int RealEstateCategoryID
        {
            get { return _RealEstateCategoryID; }
            set { _RealEstateCategoryID = value; }
        }
         [DataMember]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public RealEstateType(int id, int realestatecategoryid, string title)
        {
            _ID = id;
            _RealEstateCategoryID = realestatecategoryid;
            _Title = title.Trim() ;
        }
    }
}
