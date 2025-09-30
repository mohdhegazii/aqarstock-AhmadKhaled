using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BrokerDLL.General
{
    [DataContract]
   public class SearchCriteria
    {
        int? _RealEstateTypeID;
        int? _SaleTypeID;
        int? _PaymentTypeID;
        int? _DistrictID;
        int _PageIndex;
        int _PageSize;
        int? _CityID;
        int? _MinPrice;
        int? _MaxPrice;
        int? _MinArea;
        int? _MaxArea;
        int? _RealEstateCategoryID;
        int? _SubscriberID;
        int? _CountryID;
        bool? _IsSpecialOffer;
        int? _RealEstateStatusID;
        int? _CurrencyID;
        int? _CompanyID;

        [DataMember]
        public int? CompanyID
        {
            get { return _CompanyID; }
            set { _CompanyID = value; }
        }

        [DataMember]
        public int? CurrencyID
        {
            get { return _CurrencyID; }
            set { _CurrencyID = value; }
        }
      

        [DataMember]
        public int? RealEstateStatusID
        {
            get { return _RealEstateStatusID; }
            set { _RealEstateStatusID = value; }
        }

        [DataMember]
        public bool? IsSpecialOffer
        {
            get { return _IsSpecialOffer; }
            set { _IsSpecialOffer = value; }
        }

        [DataMember]
        public int? CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }

        [DataMember]
        public int? SubscriberID
        {
            get { return _SubscriberID; }
            set { _SubscriberID = value; }
        }

        [DataMember]
        public int? RealEstateCategoryID
        {
            get { return _RealEstateCategoryID; }
            set { _RealEstateCategoryID = value; }
        }

        [DataMember]
        public int? MaxArea
        {
            get { return _MaxArea; }
            set { _MaxArea = value; }
        }
        [DataMember]
        public int? MinArea
        {
            get { return _MinArea; }
            set { _MinArea = value; }
        }
        [DataMember]
        public int? MaxPrice
        {
            get { return _MaxPrice; }
            set { _MaxPrice = value; }
        }
        [DataMember]
        public int? MinPrice
        {
            get { return _MinPrice; }
            set { _MinPrice = value; }
        }
        [DataMember]
        public int? CityID
        {
            get { return _CityID; }
            set { _CityID = value; }
        }
        
        [DataMember]
        public int PageSize
        {
            get { return _PageSize; }
            set { _PageSize = value; }
        }

        [DataMember]
        public int PageIndex
        {
            get { return _PageIndex; }
            set { _PageIndex = value; }
        }

        [DataMember]
        public int? PaymentTypeID
        {
            get { return _PaymentTypeID; }
            set { _PaymentTypeID = value; }
        }

        [DataMember]
        public int? SaleTypeID
        {
            get { return _SaleTypeID; }
            set { _SaleTypeID = value; }
        }

        [DataMember]
        public int? RealEstateTypeID
        {
            get { return _RealEstateTypeID; }
            set { _RealEstateTypeID = value; }
        }

        [DataMember]
        public int? DistrictID
        {
            get { return _DistrictID; }
            set { _DistrictID = value; }
        }

    }
}
