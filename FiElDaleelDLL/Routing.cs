using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace BrokerDLL
{
    public static class Routing
    {
        public static void RegisterSubscriberURLS(RouteCollection routes)
        {
            routes.MapPageRoute("SubscriberDashboard", "حسابى", "~/Backend/SubScriber/SubscriberDashBoard.aspx");
            //routes.MapPageRoute("AddRealEstate", "اضافة_عقار_جديد", "~/Backend/SubScriber/RealEstateData.aspx");
            //routes.MapPageRoute("EditRealEstate", "تعديل_بيانات_العقار/{RealEstateID}", "~/Backend/SubScriber/RealEstateData.aspx");
            routes.MapPageRoute("AddRealEstate", "اضافة_عقار_جديد", "~/Backend/SubScriber/RealEstatePage.aspx");
            routes.MapPageRoute("EditRealEstate", "تعديل_بيانات_العقار/{RealEstateID}", "~/Backend/SubScriber/RealEstatePage.aspx");
            routes.MapPageRoute("RealEstateList", "عرض_العقارات", "~/Backend/SubScriber/RealEstateList.aspx");
            routes.MapPageRoute("ViewRealEstate", "عرض_بيانات_العقار/{RealEstateID}", "~/Backend/SubScriber/ViewRealEstate.aspx");
            routes.MapPageRoute("ActivateAccount", "تفعيل_الاشتراك", "~/Backend/SubScriber/ActivateSubscription.aspx");
            routes.MapPageRoute("SubscriberProfile", "تعديل_بيانات_حسابى", "~/Backend/SubScriber/SubscriberProfile.aspx");
            routes.MapPageRoute("SubscriberNotification", "التنبيهات", "~/Backend/SubScriber/Notifications.aspx");
            routes.MapPageRoute("SubscriberViewMessage", "عرض_التنبيه/{NotificationID}", "~/Backend/SubScriber/Notifications.aspx");
            routes.MapPageRoute("PurchaseRequest", "طلبات_الشراء", "~/Backend/SubScriber/PurchaseRequest.aspx");
            routes.MapPageRoute("Request", "طلبات_الشراء/{RequestID}", "~/Backend/SubScriber/PurchaseRequest.aspx");
            routes.MapPageRoute("EditCompanyDate", "تعديل_بيانات_حساب_الشركة", "~/Backend/SubScriber/RealEstateComanyData.aspx");
            routes.MapPageRoute("CreateCompanyUser", "اضافة_حساب_موظف_جديد", "~/Backend/SubScriber/CompanyUserData.aspx");
            routes.MapPageRoute("CompanyUserList", "قائمة_الموظفين", "~/Backend/SubScriber/CompanyUserList.aspx");
            routes.MapPageRoute("NewProject", "اضافة_مشروع_جديد", "~/Backend/SubScriber/ProjectData.aspx");
            routes.MapPageRoute("EditProject", "تعديل_بيانات_المشروع/{ProjectID}", "~/Backend/SubScriber/ProjectData.aspx");
            routes.MapPageRoute("ProjectList", "قائمة_المشروعات", "~/Backend/SubScriber/ProjectList.aspx");
            routes.MapPageRoute("CompanyPurchaseRequests", "طلبات_شراء_لعقارات_الشركة", "~/Backend/SubScriber/CompanyPurchaseRequests.aspx");
            routes.MapPageRoute("ChangeRealEstateSubscriber", "نقل_العقارات_لموظف_أخر", "~/Backend/SubScriber/ChangeRealEstateSubscriber.aspx");
            routes.MapPageRoute("CompanyMessages", "رسائل_العملاء", "~/Backend/SubScriber/CompanyMessages.aspx");
            routes.MapPageRoute("FavouriteRealEstates", "العقارات_المفضلة", "~/Backend/SubScriber/FavouriteRealEstates.aspx");
        }

        public static void RegisterAdminURLS(RouteCollection routes)
        {
            routes.MapPageRoute("AdminDashboard", "AdminDashboard", "~/Backend/Admin/AdminDashBoard.aspx");
            routes.MapPageRoute("Keywords", "Keywords", "~/Backend/Admin/SearchKeywords.aspx");
            routes.MapPageRoute("Countries", "Countries", "~/Backend/Admin/Countries.aspx");
            routes.MapPageRoute("Cities", "Cities", "~/Backend/Admin/Cities.aspx");
            routes.MapPageRoute("Districts", "Districts", "~/Backend/Admin/Districts.aspx");
            routes.MapPageRoute("RealEstateCategories", "RealEstateCategories", "~/Backend/Admin/RealEstateCategories.aspx");
            routes.MapPageRoute("RealEstateTypes", "RealEstateTypes", "~/Backend/Admin/RealEstateTypes.aspx");
            routes.MapPageRoute("RealEstateStatuses", "RealEstateStatuses", "~/Backend/Admin/RealEstateStatuses.aspx");
            routes.MapPageRoute("RealEstateTypeCriterias", "RealEstateTypeCriterias", "~/Backend/Admin/RealEstateTypeCriterias.aspx");
            routes.MapPageRoute("Currencies", "Currencies", "~/Backend/Admin/Currencies.aspx");
            routes.MapPageRoute("MessagesList", "MessagesList", "~/Backend/Admin/MessagesList.aspx");
            routes.MapPageRoute("ViewMessage", "ViewMessage/{MessageID}", "~/Backend/Admin/ViewMessage.aspx");
            routes.MapPageRoute("AdminRealEstateView", "RealEstateView/{RealEstateID}/{SubscriberLogID}", "~/Backend/Admin/RealEstateView.aspx");
            routes.MapPageRoute("AdminRealEstateList", "RealEstateList", "~/Backend/Admin/RealEstateList.aspx");
            routes.MapPageRoute("Complains", "Complains", "~/Backend/Admin/Complains.aspx");
            routes.MapPageRoute("SubscriberReport", "SubscriberReport", "~/Backend/Admin/SubscriberReport.aspx");
            routes.MapPageRoute("PurchaseRequestReport", "PurchaseRequestReport", "~/Backend/Admin/PurchaseRequestReport.aspx");
            routes.MapPageRoute("AdminRealEstateEdit", "AdminRealEstateEdit/{RealEstateID}", "~/Backend/Admin/RealEstateEdit.aspx");
            routes.MapPageRoute("CompanyList", "CompanyList", "~/Backend/Admin/CompanyList.aspx");
            routes.MapPageRoute("Partner", "Partner/{PartnerID}", "~/Backend/Admin/PartnerPage.aspx");
            routes.MapPageRoute("NewPartner", "NewPartner", "~/Backend/Admin/PartnerPage.aspx");
            routes.MapPageRoute("SuspenedRealEstateReport", "SuspenedRealEstateReport", "~/Backend/Admin/SuspenedRealEstateReport.aspx");
            routes.MapPageRoute("EditCompany", "EditCompany/{CompanyID}", "~/Backend/Admin/EditCompany.aspx");
            routes.MapPageRoute("ViewCompany", "ViewCompany/{CompanyID}/{SubscriberLogID}", "~/Backend/Admin/ViewCompany.aspx");
            routes.MapPageRoute("ViewProject", "ViewProject/{ProjectID}/{SubscriberLogID}", "~/Backend/Admin/ViewProject.aspx");
            routes.MapPageRoute("AdminEditProject", "EditProject/{ProjectID}", "~/Backend/Admin/EditProject.aspx");
            routes.MapPageRoute("AdminProjectList", "ProjectList", "~/Backend/Admin/ProjectList.aspx");
            routes.MapPageRoute("GenerateSiteMap", "GenerateSiteMap", "~/Backend/Admin/Settings/GenerateSiteMap.aspx");
            routes.MapPageRoute("Advertisement", "Advertisement", "~/Backend/Admin/Settings/AdvertisementPage.aspx");
            routes.MapPageRoute("NotifyReqiestReport", "NotifyReqiestReport", "~/Backend/Admin/NotifyReqiestReport.aspx");
            routes.MapPageRoute("RemoveSuspended", "RemoveSuspended", "~/Backend/Admin/Settings/RemoveSuspendedRealEstates.aspx");
            routes.MapPageRoute("CatalogList", "CatalogList", "~/Backend/Admin/CatalogList.aspx");
            routes.MapPageRoute("NewCatalog", "NewCatalog", "~/Backend/Admin/Catalog.aspx");
            routes.MapPageRoute("EditCatalog", "EditCatalog/{CatalogID}", "~/Backend/Admin/Catalog.aspx");
            routes.MapPageRoute("Tags", "Tags", "~/Backend/Admin/Tags.aspx");
            routes.MapPageRoute("CatalogCategory", "CatalogCategory", "~/Backend/Admin/CatalogCategory.aspx");
            routes.MapPageRoute("GenerateCatalogs", "GenerateCatalogs", "~/Backend/Admin/GenerateCatalog.aspx");
        }

        public static void RegisterFrontendURLS(RouteCollection routes)
        {
            routes.MapPageRoute("EnLogin", "Login", "~/Register.aspx");
            routes.MapPageRoute("Login", "دخول", "~/Register.aspx");
            routes.MapPageRoute("Register", "تسجيل", "~/Register.aspx");
            routes.MapPageRoute("Home", "الرئيسية", "~/Default.aspx");
            routes.MapPageRoute("aboutus", "الدعم_الفنى", "~/aboutus.aspx");
           // routes.MapPageRoute("contactus", "اتصل_بنا", "~/Contactus.aspx");
            routes.MapPageRoute("Details", "Details/{ID}/{Name}", "~/PropertyDetails.aspx");
            //routes.MapPageRoute("Details", "Details/{ID}/{Name}", "~/Details.aspx");
            routes.MapPageRoute("PartnerUnits", "Page/{ID}/{Name}", "~/PartnerUnits.aspx");
            routes.MapPageRoute("SearchResult", "نتيجة_البحث/{*Query}", "~/PropertyList.aspx");
            routes.MapPageRoute("SpecialOffer", "عروض_مميزة/{Pageindex}", "~/PropertyList.aspx");
            routes.MapPageRoute("PropertiesBySale", "وحدات/{*Query}", "~/PropertyList.aspx");
            routes.MapPageRoute("PropertiesByCategory", "الفئة/{PageIndex}/{Category}/{CategoryID}", "~/PropertyList.aspx");
            routes.MapPageRoute("LatestProperties", "آخر_الوحدات_المضافة/{PageIndex}", "~/PropertyList.aspx");
            routes.MapPageRoute("PropertiesByKeywords", "كلمات_البحث/{*Query}", "~/PropertyList.aspx");
            routes.MapPageRoute("Compare", "قارن_الوحدات", "~/Compare.aspx");
            routes.MapPageRoute("CompaniesList", "شركات_عقارية/{PageIndex}", "~/CompaniesList.aspx");
            routes.MapPageRoute("CompanyDetails", "شركات_عقارية/{ID}/{Name}", "~/CompanyDetails.aspx");
            routes.MapPageRoute("ProjectsList", "مشاريع_عقارية/{PageIndex}", "~/ProjectList.aspx");
            routes.MapPageRoute("ProjectDetails", "مشاريع_عقارية/{ID}/{Name}", "~/ProjectDetails.aspx");
            //routes.MapPageRoute("CompaniesList", "شركات_عقارية/{PageIndex}", "~/CatalogList.aspx");
            routes.MapPageRoute("CatalogDetails", "كتالوجات_عقارية/{ID}/{Name}", "~/CatalogDetails.aspx");
            routes.Ignore("blog");
           // routes.Ignore("SearchResult","نتيجة_البحث/{*result}");
            //routes.MapPageRoute("blog", "blog", "~/Backend/Login.aspx");
        }
    }
}
