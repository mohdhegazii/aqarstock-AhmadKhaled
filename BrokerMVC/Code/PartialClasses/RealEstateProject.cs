
using BrokerMVC.Code.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models
{
    public partial class RealEstateProject : ProjectBase
    {
        public string DefaultPhotoURL
        {
            get
            {
                if(this.RealEstateProjectPhotos.Count()>0)
                {
                    RealEstateProjectPhoto Photo = this.RealEstateProjectPhotos.FirstOrDefault(p => p.IsDefault == true);
                    if(Photo!=null)
                    {
                        return Photo.PhotoURL;
                    }
                    else
                    {
                        Photo = this.RealEstateProjectPhotos.First();
                        return Photo.PhotoURL;
                    }
                }
                else { return ""; }
            }
        }
        public string Address
        {
            get
            {
                if (this.Country != null)
                {
                    return  this.District.Name + " " + this.City.Name + " " + this.Country.Name;
                }
                else
                {
                    return "";
                }
            }
        }
        public string EnAddress
        {
            get
            {
                if (this.Country != null)
                {
                    return  this.District.EnName + " " + this.City.EnName + " " + this.Country.EnName;
                }
                else
                {
                    return "";
                }
            }
        }
    }
}