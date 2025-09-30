using BrokerMVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models
{
    public partial class RealEstate
    {
        Suspend _SuspendData;
        OwnerData _OwnerData;
        public RealEstatePhoto DefaultImage
        {
            get
            {
                if (this.RealEstatePhotos.Count()>0)
                {
                    RealEstatePhoto photo = this.RealEstatePhotos.FirstOrDefault(p => p.IsDefault == true);
                    if(photo!=null)
                    {
                        return photo;
                    }
                    else
                    {
                        photo = this.RealEstatePhotos.First();
                        return photo;
                            }
                }
                else
                {
                    return new RealEstatePhoto();
                }
            }
        }
        public string Address
        {
            get
            {
                if(this.Country!=null)
                { 
                return this.Street+", "+this.District.Name+" "+this.City.Name+" "+this.Country.Name;
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
                    return this.EnStreet + ", " + this.District.EnName + " " + this.City.EnName + " " + this.Country.EnName;
                }
                else
                {
                    return "";
                }
            }
        }
        public Suspend SuspendData
        {
            get
            {
                if (_SuspendData == null)
                {
                    if (this.RealEstateSuspendeds.Count() > 0)
                    {
                        _SuspendData = new Suspend();
                        _SuspendData.ID = this.ID;
                        _SuspendData.Message = this.RealEstateSuspendeds.First().Message;

                        _SuspendData.SuspendReason = this.RealEstateSuspendeds.First().SuspendReason.Title;
                        _SuspendData.SuspendReasonID = this.RealEstateSuspendeds.First().SuspendReasonId;
                    }
                }
                return _SuspendData;
            }

        }
        public OwnerData Owner
        {
            get
            {
                if(_OwnerData==null)
                {
                    if(this.UseContactInfo==false)
                    {
                        _OwnerData = new OwnerData();
                        _OwnerData.Email = OwnerEmail;
                        _OwnerData.Id = ID;
                        _OwnerData.Name = OwnerName;
                        _OwnerData.Phone = OwnerMobile;
                    }
                }
                return _OwnerData;
            }
        }

    }
}