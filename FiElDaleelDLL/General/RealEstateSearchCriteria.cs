using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.General
{
    public class RealEstateSearchCriteria
    {
        string _Keyword;
        int _DistrictID;
        int _RealEstateCategoryID;
        int _RealEstateTypeID;
        int _RealEstateStatusID;
        int _SaleTypeID;
        int _PaymentTypeID;
        int _CurrencyID;
        double _Price;
        double _Area;
        int _Code;
        double _MinPrice;
        double _MaxPrice;
        int _SubscriberID;
        DateTime _FromDate;
        DateTime _ToDate;
        int _CountryID;
        int _CityID;

        public int CityID
        {
            get { return _CityID; }
            set { _CityID = value; }
        }

        public int CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }

        public DateTime ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
        }

        public DateTime FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }
        public int SubscriberID
        {
            get { return _SubscriberID; }
            set { _SubscriberID = value; }
        }

        public double MaxPrice
        {
            get { return _MaxPrice; }
            set { _MaxPrice = value; }
        }

        public double MinPrice
        {
            get { return _MinPrice; }
            set { _MinPrice = value; }
        }

        public int Code
        {
            get { return _Code; }
            set { _Code = value; }
        }

        public double Area
        {
            get { return _Area; }
            set { _Area = value; }
        }

        public double Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

        public int CurrencyID
        {
            get { return _CurrencyID; }
            set { _CurrencyID = value; }
        }

        public int PaymentTypeID
        {
            get { return _PaymentTypeID; }
            set { _PaymentTypeID = value; }
        }

        public int SaleTypeID
        {
            get { return _SaleTypeID; }
            set { _SaleTypeID = value; }
        }

        public int RealEstateStatusID
        {
            get { return _RealEstateStatusID; }
            set { _RealEstateStatusID = value; }
        }

        public int RealEstateTypeID
        {
            get { return _RealEstateTypeID; }
            set { _RealEstateTypeID = value; }
        }

        public int RealEstateCategoryID
        {
            get { return _RealEstateCategoryID; }
            set { _RealEstateCategoryID = value; }
        }

        public int DistrictID
        {
            get { return _DistrictID; }
            set { _DistrictID = value; }
        }

        public string Keyword
        {
            get { return _Keyword; }
            set { _Keyword = value; }
        }
    }
}
