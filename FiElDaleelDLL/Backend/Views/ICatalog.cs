using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
   public enum CatalogSearchMode
    {
        none,
        ByCode,
        ByCompany,
        ByProject,
        ByUser
    }
    public interface ICatalog:IView
    {
        
        int CatalogID { get; set; }
        CatalogSearchMode SearchMode { get; set; }
        void BindList(List<RealestateCatalogProperty> Props);

        void FillCategoryList(List<CatalogCategory> Categories);

        void BindTagList(List<RealestateCatalogTag> Tags);
        void FillControls(RealEstateCatalog Catalog);
        RealEstateCatalog FillObject(RealEstateCatalog Catalog);
        void FillRealestateList(List<RealEstate> Realestates);

        void FillCompanyList(List<RealEstateCompany> Companies);
        void FillProjectList(List<RealEstateProject> Projects);
        void FillUserList(List<Subscriber> Subscribers);

        void FillTagsList(List<Tag> Tags);
        void Upload(string Code);
    }
}
