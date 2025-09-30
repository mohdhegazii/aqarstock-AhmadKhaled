using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
  public interface IRealEstateProject:IView
    {
      int ProjectID { get; set; }
      void FillCountryList(List<Country> Countries);
      void FillCityList(List<City> Cities);
      void FillDistrictList(List<District> Districts);
      RealEstateProject FillObject(RealEstateProject Project);
      void FillControls(RealEstateProject Project);
      void upload(string Code);
    }
}
