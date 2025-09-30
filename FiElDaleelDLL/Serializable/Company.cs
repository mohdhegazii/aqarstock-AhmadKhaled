using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace BrokerDLL.Serializable
{
    [DataContract]
    public class Company
    {
        int _ID;
        string _Name;
        string _Summary;
        string _Description;
        string _Address;
        string _Phone;
        string _Email;
        string _Logo;
        string _Latitude;
        string _Longitude;
        string _URL;

        [DataMember]
        public string URL
        {
            get { return _URL; }
            set { _URL = value; }
        }

        [DataMember]
        public string Longitude
        {
            get { return _Longitude; }
            set { _Longitude = value; }
        }

        [DataMember]
        public string Latitude
        {
            get { return _Latitude; }
            set { _Latitude = value; }
        }

        [DataMember]
        public string Logo
        {
            get { return _Logo; }
            set { _Logo = value; }
        }

        [DataMember]
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        [DataMember]
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        [DataMember]
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        [DataMember]
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        [DataMember]
        public string Summary
        {
            get { return _Summary; }
            set { _Summary = value; }
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

        public Company(BrokerDLL.RealEstateCompany company)
        {
            _Description = company.Description;
            _Email = company.Email;
            _ID = company.ID;
            _Latitude = company.Latitude;
            _Longitude = company.Longutide;
            _Name = company.Title;
            _Phone = company.Phone.Replace("-"," - ");
            _Summary = company.Summary;
            _URL = Regex.Replace(company.Title, "[^0-9a-zA-Zء-ي]+", "-");
            if (company.CountryId != null)
            {
                _Address = company.District.Name.Trim() + ", " + company.City.Name.Trim() + ", " + company.Country.Name.Trim();
            }
            if (company.Logo != null)
            {
                _Logo = company.Logo.Replace("~/", "");
            }
        }
    }
}
