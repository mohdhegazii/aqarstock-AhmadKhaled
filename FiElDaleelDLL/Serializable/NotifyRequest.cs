using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BrokerDLL.Serializable
{
   [DataContract]
   public class NotifyRequest
    {
       string _Name;
       string _Email;
       string _Phone;
       int? _SaleTypeID;
       int? _RealEstateTypeID;
       int? _CountryID;
       int? _CityID;
       int? _DistrictID;
       int? _Price;
       int? _Area;

       
       [DataMember]
       public int? Area
       {
           get { return _Area; }
           set { _Area = value; }
       }

       [DataMember]
       public int? Price
       {
           get { return _Price; }
           set { _Price = value; }
       }

       [DataMember]
       public int? DistrictID
       {
           get { return _DistrictID; }
           set { _DistrictID = value; }
       }

       [DataMember]
       public int? CityID
       {
           get { return _CityID; }
           set { _CityID = value; }
       }

       [DataMember]
       public int? CountryID
       {
           get { return _CountryID; }
           set { _CountryID = value; }
       }

       [DataMember]
       public int? RealEstateTypeID
       {
           get { return _RealEstateTypeID; }
           set { _RealEstateTypeID = value; }
       }

       [DataMember]
       public int? SaleTypeID
       {
           get { return _SaleTypeID; }
           set { _SaleTypeID = value; }
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
       public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
    }
}
