using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
    public interface IRealEstateCompany:IView
    {
        int CompanyId { get; set; }
        RealEstateCompany FillObject(RealEstateCompany Company);
        void FillControls(RealEstateCompany Company);
        void FillCountryList(List<Country> Countries);
        void FillCityList(List<City> Cities);
        void FillDistrictList(List<District> Districts);
        void UploadLogo(string Code);
    }
}
