using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace BrokerDLL.Serializable
{
    [DataContract]
    public class RealEstate
    {
        int _ID;
        string _Title;
        string _Description;
        string _Logo;
        string _Address;
        string _SaleType;
        string _Type;
        string _Status;
        string _Category;
        string _PaymentType;
        string _Currency;
        string _Price;
        string _Area;
        string _Longitude;
        string _Latitude;
        string _OwnerName;
        string _OwnerPhone;
        string _OwnerEmail;
        string _District;
        string _City;
        string _Summary;
        string _URL;
        string _IsSpecial;
        string _Date;
        string _SubscriberID;

        List<RealEstateCriteria> _Criteria;

        [DataMember]
        public string Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        [DataMember]
        public List<RealEstateCriteria> Criteria
        {
            get { return _Criteria; }
            set { _Criteria = value; }
        }

        [DataMember]
        public string IsSpecial
        {
            get { return _IsSpecial; }
            set { _IsSpecial = value; }
        }

        [DataMember]
        public string URL
        {
            get { return _URL; }
            set { _URL = value; }
        }

        [DataMember]
        public string Summary
        {
            get { return _Summary; }
            set { _Summary = value; }
        }

         [DataMember]
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

         [DataMember]
        public string District
        {
            get { return _District; }
            set { _District = value; }
        }

         [DataMember]
        public string OwnerEmail
        {
            get { return _OwnerEmail; }
            set { _OwnerEmail = value; }
        }
         [DataMember]
        public string OwnerPhone
        {
            get { return _OwnerPhone; }
            set { _OwnerPhone = value; }
        }
         [DataMember]
        public string OwnerName
        {
            get { return _OwnerName; }
            set { _OwnerName = value; }
        }

         [DataMember]
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
         [DataMember]
        public string Latitude
        {
            get { return _Latitude; }
            set { _Latitude = value; }
        }
         [DataMember]
        public string Longitude
        {
            get { return _Longitude; }
            set { _Longitude = value; }
        }
         [DataMember]
        public string Area
        {
            get { return _Area; }
            set { _Area = value; }
        }
         [DataMember]
        public string Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
         [DataMember]
        public string Currency
        {
            get { return _Currency; }
            set { _Currency = value; }
        }
         [DataMember]
        public string PaymentType
        {
            get { return _PaymentType; }
            set { _PaymentType = value; }
        }

         [DataMember]
        public string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }
         [DataMember]
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
         [DataMember]
        public string SaleType
        {
            get { return _SaleType; }
            set { _SaleType = value; }
        }
         [DataMember]
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
         [DataMember]
        public string Logo
        {
            get { return _Logo; }
            set { _Logo = value; }
        }
         [DataMember]
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
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

        [DataMember]
        public string SubscriberID
        {
            get
            {
                return _SubscriberID;
            }

            set
            {
                _SubscriberID = value;
            }
        }

        public RealEstate(BrokerDLL.RealEstate realestate)
        {
            FillRealEstate(realestate);
        }
        public RealEstate(BrokerDLL.RealEstate realestate, bool IsWithCriteria)
        {
            FillRealEstate(realestate);
            if (realestate.RealEstateCriterias.Count > 0)
            {
                _Criteria = new List<RealEstateCriteria>();
                realestate.RealEstateCriterias.ToList().ForEach(C => _Criteria.Add(new RealEstateCriteria(C.RealEstateTypeCriteria.Title, C.Value)));
            }
        }

        private void FillRealEstate(BrokerDLL.RealEstate realestate)
        {
            _ID = realestate.ID;
            _Description = realestate.Description;
            _Title = realestate.Title;
            _Category = realestate.RealEstateCategory.Title.Trim();
            _Type = realestate.RealEstateType.Title.Trim();
            _Status = realestate.RealEstateStatu.Title.Trim();
            _SaleType = realestate.SaleType.Title.Trim();
            _Area = realestate.Area.HasValue ? realestate.Area.Value.ToString().Trim() : "";
            _Currency = realestate.Currency != null ? realestate.Currency.Name.Trim() : "";
            _Latitude = realestate.Latitude;
            _Longitude = realestate.Longitude;
            _PaymentType = realestate.PaymentType != null ? realestate.PaymentType.Title.Trim() : "";
            _Price = realestate.Price.HasValue ? realestate.Price.Value.ToString().Trim() : "";
            _URL = Regex.Replace(realestate.Title, "[^0-9a-zA-Zء-ي]+", "-");
            _Summary = _Type + " ";
            _Date = realestate.CreatedDate.Value.ToString("dd-MM-yyyy");
            _SubscriberID = realestate.SubscriberID.ToString();
            if (realestate.IsSpecialOffer.HasValue)
            {
                _IsSpecial = realestate.IsSpecialOffer.Value.ToString();
            }
            else
            {
                _IsSpecial = "false";
            }
            if (_Area != null)
            {
                _Summary += _Area.Trim() + " م ";
            }
            if (realestate.CountryID > 0 && realestate.CountryID != null)
            {
                _Address = realestate.Street.Trim() + ", " + realestate.District.Name.Trim() + ", " + realestate.City.Name.Trim() + ", " + realestate.Country.Name.Trim();
                _District = realestate.District.Name.Trim();
                _City = realestate.City.Name.Trim();
                _Summary += "- " + _District + ", " + _City;
            }

            if (realestate.UseContactInfo == true)
            {
                if(realestate.Subscriber.CompanyID!=null)
                {
                    _OwnerEmail = realestate.Subscriber.RealEstateCompany.Email;
                    _OwnerName = realestate.Subscriber.RealEstateCompany.Title;
                    _OwnerPhone = realestate.Subscriber.RealEstateCompany.Phone;
                }
                else
                { 
                _OwnerEmail = realestate.Subscriber.Email.Trim();
                _OwnerName = realestate.Subscriber.FullName.Trim();
                _OwnerPhone = realestate.Subscriber.MobileNo.Trim();
                }
            }
            else
            {
                _OwnerPhone = realestate.OwnerMobile.Trim();
                _OwnerName = realestate.OwnerName.Trim();
                _OwnerEmail = realestate.OwnerEmail.Trim();
            }
            if (realestate.RealEstatePhotos.Count > 0)
            {
                BrokerDLL.RealEstatePhoto photo = realestate.RealEstatePhotos.FirstOrDefault(P => P.IsDefault == true);
                if (photo != null)
                {
                    _Logo = photo.PhotoName;
                }
                else
                {
                    _Logo = realestate.RealEstatePhotos.ToList()[0].PhotoName;
                }
            }
            else
            {
                _Logo = realestate.RealEstateType.Icon;
            }
            _Logo = _Logo.Replace("~/", "");
        }

     
    }
}
