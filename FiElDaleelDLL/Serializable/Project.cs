using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace BrokerDLL.Serializable
{
    [DataContract]
    public class Project
    {
        int _ID;
        string _ProjectName;
        string _Description;
        string _Country;
        string _City;
        string _District;
        string _Logo;
        string _DefaultPhoto;
        string _CompanyName;
        int _CompanyID;
        string _Summary;
        string _URL;
        string _Address;
        string _Phone;
        string _Latitude;
        string _Longitude;
        string _CompanyURL;
        string _Slogan;

        [DataMember]
        public string Slogan
        {
            get { return _Slogan; }
            set { _Slogan = value; }
        }

        [DataMember]
        public string CompanyURL
        {
            get { return _CompanyURL; }
            set { _CompanyURL = value; }
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
        public int CompanyID
        {
            get { return _CompanyID; }
            set { _CompanyID = value; }
        }

        [DataMember]
        public string CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }

        [DataMember]
        public string DefaultPhoto
        {
            get { return _DefaultPhoto; }
            set { _DefaultPhoto = value; }
        }

        [DataMember]
        public string Logo
        {
            get { return _Logo; }
            set { _Logo = value; }
        }

        [DataMember]
        public string District
        {
            get { return _District; }
            set { _District = value; }
        }

        [DataMember]
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        [DataMember]
        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

        [DataMember]
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        [DataMember]
        public string ProjectName
        {
            get { return _ProjectName; }
            set { _ProjectName = value; }
        }

        [DataMember]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public Project(BrokerDLL.RealEstateProject RSProject)
        {
            _ID = RSProject.ID;
            _City = RSProject.CityName;
            _CompanyID = RSProject.CompanyID.Value;
            _CompanyName = RSProject.RealEstateCompany.Title;
            _Country = RSProject.CountryName;
            _Description = RSProject.Description;
            _District = RSProject.District.Name;
            _Logo = RSProject.Logo;
            _ProjectName = RSProject.Title;
            _Slogan = RSProject.Sologan;
            _Summary = RSProject.Description.Substring(0, 100);
            _Address=RSProject.District.Name+", "+RSProject.CityName+", "+RSProject.CountryName;
            _Phone = RSProject.RealEstateCompany.Phone;
            _Latitude = RSProject.Latitude;
            _Longitude = RSProject.Longitude;
            _URL = Regex.Replace(RSProject.Title, "[^0-9a-zA-Zء-ي]+", "-");
            _CompanyURL = RSProject.CompanyID + "/" + Regex.Replace(RSProject.RealEstateCompany.Title, "[^0-9a-zA-Zء-ي]+", "-");
            if (RSProject.RealEstateProjectPhotos.Count > 0)
            {
                RealEstateProjectPhoto Photo = RSProject.RealEstateProjectPhotos.FirstOrDefault(P => P.IsDefault == true);
                if (Photo != null)
                {
                    _DefaultPhoto = Photo.PhotoURL;
                }
                else
                {
                    _DefaultPhoto = RSProject.RealEstateProjectPhotos.First().PhotoURL;
                }
            }
            else
            {
                _DefaultPhoto = _Logo;
            }
            _Logo = _Logo.Replace("~/", "");
            _DefaultPhoto = _DefaultPhoto.Replace("~/", "");
            //_DefaultPhoto
        }
    }
}
