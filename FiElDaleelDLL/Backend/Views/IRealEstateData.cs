using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
    public interface IRealEstateData:IView
    {
        int RealEstateID { get; set; }
        RealEstate FillRealEstateObject(RealEstate realestate,string random);
        void FillRealEstateControls(RealEstate realestate);
        void FillCountryList(List<Country> Countries);
        void FillCityList(List<City> Cities);
        void FillDistrictList(List<District> Districts);
        void FillCategoryList(List<RealEstateCategory> Categories);
        void FillTypeList(List<RealEstateType> Types);
        void FillStatusList(List<RealEstateStatus> Status);
        void FillPaymentList(List<PaymentType> PaymentTypess);
        void FillCurrencyList(List<Currency> Currencies);
        void FillSaleTypeList(List<SaleType> SaleTypes);
        void FillKeywordList(List<Keyword> Keywords);
        void FillRealEstateTypeCriteriaList(List<RealEstateTypeCriteria> TypeCriterias);
        void UploadRealEstatePhoto(int Code,string random);
        void BindPhotoList(List<BrokerDLL.RealEstatePhoto> Photos);
        //void FillBusinessList(List<Business> Businesses);
        //void FillBranchesList(List<BusinessBranch> Branches);
    }
}
