using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BrokerMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            FrontendRoutes(routes);
            FrontendEngRoutes(routes);
            OldRoutes(routes);
            routes.MapRoute(
name: "PageNotFound",
url: "NotFound",
defaults: new { controller = "Home", action = "NotFound" }
);
            routes.MapRoute(
                name: "withCulture",
                url: "{culture}/{controller}/{action}/{id}",
                constraints: new { culture = @"(\w{2})|(\w{2}-\w{2})" },
                defaults: new { culture = CultureHelper.GetDefaultCulture(), controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
        private static void OldRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "ProjectSendMail",
                url: "مشاريع_عقارية/{ProjectID}/{ProjectName}/SendMail",
                defaults: new { controller = "Home", action = "ProjectDetail", Name = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PropertyRequest",
                url: "Details/{ID}/{Name}/Request",
                defaults: new { controller = "Home", action = "PropertyDetail" }
            );
            routes.MapRoute(
                name: "PropertyGallery",
                url: "Details/{ID}/{Name}/Gallery",
                defaults: new { controller = "Home", action = "PropertyDetail" }
            );
            routes.MapRoute(
                name: "PropertyComplain",
                url: "Details/{ID}/{Name}/Complain",
                defaults: new { controller = "Home", action = "PropertyDetail" }
            );
            routes.MapRoute(
                name: "CompanySendMail",
                url: "شركات_عقارية/{CompanyID}/{Name}/SendMail",
                defaults: new { controller = "Home", action = "CompanyDetail" }
            );
        }
        private static void FrontendRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Login",
                url: "دخول",
                defaults: new { controller = "Account", action = "Login" }
            );
            routes.MapRoute(
                name: "Register",
                url: "تسجيل",
                defaults: new { controller = "Home", action = "Register" }
            );
            routes.MapRoute(
                name: "HomePage",
                url: "الرئيسية",
                defaults: new { controller = "Home", action = "Index" }
            );
            routes.MapRoute(
                 name: "TechnicalSupport",
                 url: "الدعم_الفنى",
                 defaults: new { controller = "Home", action = "TechnicalSupport" }
             );
            routes.MapRoute(
                name: "PropByCategory",
                url: "الفئة/{catid}/{catname}/{Page}",
                defaults: new { controller = "Home", action = "PropertyByCategory", Page = 1 }
            );
            routes.MapRoute(
                name: "PropByType",
                url: "النوع/{Typeid}/{Typename}/{Page}",
                defaults: new { controller = "Home", action = "PropertyByType", Page = 1 }
            );
            routes.MapRoute(
                name: "PropList",
                url: "آخر_الوحدات_المضافة/{Page}",
                defaults: new { controller = "Home", action = "GetLatestProperties", Page = 1 }
            );
            routes.MapRoute(
                name: "RentPropList",
                url: "الايجار/{Page}",
                defaults: new { controller = "Home", action = "GetPropertiesForRent", Page = 1 }
            );
            routes.MapRoute(
                name: "ProjectList",
                url: "مشاريع_عقارية/{Page}",
                defaults: new { controller = "Home", action = "ProjectList", Page = 1 }
            );
            routes.MapRoute(
                name: "ProjectDetails",
                url: "مشاريع_عقارية/{ID}/{ProjectName}/",
                defaults: new { controller = "Home", action = "ProjectDetail" }
            );
            routes.MapRoute(
                name: "ProjectProperties",
                url: "مشاريع_عقارية/{ProjectID}/{ProjectName}/ProjectProperties",
                defaults: new { controller = "Home", action = "PropertyByProject", Name = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ProjectModels",
                url: "مشاريع_عقارية/{ProjectID}/{ProjectName}/Models",
                defaults: new { controller = "Home", action = "ProjectModels", Name = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ProjectModelDetail",
                url: "مشاريع_عقارية/{ProjectID}/{ProjectName}/Models/{ModelID}",
                defaults: new { controller = "Home", action = "ModelDetail", Name = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PropertyDetails",
                url: "Details/{ID}/{Name}/",
                defaults: new { controller = "Home", action = "PropertyDetail", Name = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "SearchKeywords",
                url: "كلمات_البحث/{*Query}",
                defaults: new { controller = "Home", action = "SearchKeywords" }
            );
            routes.MapRoute(
              name: "OLdSearch",
              url: "نتيجة_البحث/{*Query}",
              defaults: new { controller = "Home", action = "SearchKeywords" }
          );
            routes.MapRoute(
                name: "CompanyList",
                url: "شركات_عقارية/{Page}",
                defaults: new { controller = "Home", action = "CompanyList", Page = 1 }
            );
            routes.MapRoute(
                name: "CompanyDerails",
                url: "شركات_عقارية/{CompanyID}/{Name}",
                defaults: new { controller = "Home", action = "CompanyDetail" }
            );
            routes.MapRoute(
                name: "CompanyProperties",
                url: "شركات_عقارية/{CompanyID}/{CompanyName}/Properties",
                defaults: new { controller = "Home", action = "PropertyByCompany", CompanyName = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CompanyProjects",
                url: "شركات_عقارية/{CompanyID}/{CompanyName}/Projects",
                defaults: new { controller = "Home", action = "CompanyProjects", CompanyName = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "OldCatalogDerails",
                url: "كتالوجات_عقارية/{ID}/{Name}",
                defaults: new { controller = "Home", action = "OldCatalogDetail" }
            );
            routes.MapRoute(
                name: "CompareList",
                url: "قارن_الوحدات/{type}",
                defaults: new { controller = "Home", action = "CompareList" }
            );
            routes.MapRoute(
                name: "CatalogDerails",
                url: "الكتالوج_العقارى/{ID}/{Name}",
                defaults: new { controller = "Home", action = "CatalogDetail" }
            );
            routes.MapRoute(
                 name: "SupscriptionTypes",
                 url: "انواع_لاشتراكات",
                 defaults: new { controller = "Home", action = "SupscriptionTypes" }
             );
            routes.MapRoute(
                 name: "MarketingServices",
                 url: "الخدمات_التسويقية",
                 defaults: new { controller = "Home", action = "MarketingServices" }
             );
        }
        private static void FrontendEngRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                 name: "EnLogin",
                 url: "Login",
                 defaults: new { controller = "Account", action = "Login" }
            );
            routes.MapRoute(
                name: "EnRegister",
                url: "Register",
                defaults: new { controller = "Home", action = "Register" }
            );
            routes.MapRoute(
                name: "EnHomePage",
                url: "Homepage",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                 name: "EnTechnicalSupport",
                 url: "Technical_Support",
                 defaults: new { controller = "Home", action = "TechnicalSupport" }
             );
            routes.MapRoute(
                name: "EnPropList",
                url: "Latest_Added/{Page}",
                defaults: new { controller = "Home", action = "GetLatestProperties", Page = 1 }
            );
            routes.MapRoute(
                name: "EnRentPropList",
                url: "For_Rent/{Page}",
                defaults: new { controller = "Home", action = "GetPropertiesForRent", Page = 1 }
            );
            routes.MapRoute(
                name: "EnPropByCategory",
                url: "Category/{catid}/{catname}/{Page}",
                defaults: new { controller = "Home", action = "PropertyByCategory", Page = 1 }
            );
            routes.MapRoute(
                name: "EnPropByType",
                url: "Type/{Typeid}/{Typename}/{Page}",
                defaults: new { controller = "Home", action = "PropertyByType", Page = 1 }
            );
            routes.MapRoute(
                name: "EnProjectList",
                url: "Projects/{Page}",
                defaults: new { controller = "Home", action = "ProjectList", Page = 1 }
            );
            routes.MapRoute(
                 name: "EnProjectDetails",
                 url: "Projects/{ID}/{ProjectName}/",
                 defaults: new { controller = "Home", action = "ProjectDetail" }
             );
            routes.MapRoute(
                name: "EnProjectProperties",
                url: "Projects/{ProjectID}/{ProjectName}/ProjectProperties",
                defaults: new { controller = "Home", action = "PropertyByProject", Name = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "EnProjectModels",
                url: "Projects/{ProjectID}/{ProjectName}/Models",
                defaults: new { controller = "Home", action = "ProjectModels", Name = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "EnProjectModelDetail",
                url: "Projects/{ProjectID}/{ProjectName}/Models/{ModelID}",
                defaults: new { controller = "Home", action = "ModelDetail", Name = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "EnCompanyList",
                url: "Companys/{Page}",
                defaults: new { controller = "Home", action = "CompanyList", Page = 1 }
            );
            routes.MapRoute(
                name: "EnCompanyDerails",
                url: "Companys/{CompanyID}/{Name}",
                defaults: new { controller = "Home", action = "CompanyDetail" }
            );
            routes.MapRoute(
                name: "EnCompanyProperties",
                url: "Projects/{CompanyID}/{CompanyName}/Properties",
                defaults: new { controller = "Home", action = "PropertyByCompany", CompanyName = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EnCompanyProjects",
                url: "Projects/{CompanyID}/{CompanyName}/Projects",
                defaults: new { controller = "Home", action = "CompanyProjects", CompanyName = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "EnCompareList",
                url: "CompareList/{type}",
                defaults: new { controller = "Home", action = "CompareList" }
            );
            routes.MapRoute(
                 name: "EnSupscriptionTypes",
                 url: "Supscription_Types",
                 defaults: new { controller = "Home", action = "SupscriptionTypes" }
             );
            routes.MapRoute(
                 name: "EnMarketingServices",
                 url: "Marketing_Services",
                 defaults: new { controller = "Home", action = "MarketingServices" }
             );
        }


    }
}
