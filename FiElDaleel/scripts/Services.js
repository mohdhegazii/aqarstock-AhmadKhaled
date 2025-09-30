brokerApp.service("BrokerServices", function ($resource) {
    var generalURL = 'Services/GeneralService.svc/';
    var realestateURL = 'Services/RealEstateService.svc/';
    var ProjectURL = 'Services/ProjectService.svc/';
    //------------Codes------------------------------------------------------------------------//
    this.Keywords = $resource(generalURL + 'Keywords');
    this.Countries = $resource(generalURL + 'Countries');
    this.Cities = $resource(generalURL + 'Cities');
    this.CitiesByCountry = $resource(generalURL + 'Cities/:CountryID');
    this.Districts = $resource(generalURL + 'Districts');
    this.DistrictsByCity = $resource(generalURL + 'Districts/:CityID');
    this.PaymentMethods = $resource(generalURL + 'PaymentTypes');
    this.Currencies = $resource(generalURL + 'Currencies');
    this.SaleTypes = $resource(generalURL + 'SalesTypes');
    this.RealEstateCategories = $resource(realestateURL + 'RealEstateCategories');
    this.RealEstateTypes = $resource(realestateURL + 'RealEstateTypes');
    this.RealEstateTypesByCategory = $resource(realestateURL + 'RealEstateTypes/:RealEstateCategoryID');
    this.RealEstateStaus = $resource(realestateURL + 'RealEstateStaus/:RealEstateCategoryID');
    this.RealEstateStausByType = $resource(realestateURL + 'RealEstateStausByType/:RealEstateTypeID');
    this.CatalogTags = $resource(generalURL + 'CatalogTags/:ID');
    //----------------------Get Real Estate List--------------------------------------------------//
    this.RealEstates = $resource(realestateURL + 'RealEstates/:PageIndex/:PageSize');
    this.LatestRealEstatesBySaleType = $resource(realestateURL + 'LatestRealEstatesBySaleType/:SaleType/:PageIndex/:PageSize');
    this.RealEstatesByCompany = $resource(realestateURL + 'RealEstatesByCompany/:CompanyID/:PageIndex/:PageSize');
    this.CountRealEstatesByCompany = $resource(realestateURL + 'RealEstatesNoByCompany/:CompanyID/:PageSize');
    this.SpecialRealEstates = $resource(realestateURL + 'SpecialRealEstates/:PageIndex/:PageSize');
    this.CountSpecialRealEstates = $resource(realestateURL + 'CountSpecialRealEstates/:PageSize');
    this.RealEstatesBySaleType = $resource(realestateURL + 'RealEstatesBySaleType/:SaleType/:PageIndex/:PageSize');
    this.CountRealEstatesBySaleType = $resource(realestateURL + 'CountRealEstatesBySaleType/:SaleType/:PageSize');
    this.RealEstatesByCategory = $resource(realestateURL + 'RealEstatesByCategory/:Category/:PageIndex/:PageSize');
    this.CountRealEstatesByCategory = $resource(realestateURL + 'CountRealEstatesByCategory/:Category/:PageSize');
    this.CountRealEstates = $resource(realestateURL + 'CountRealEstates/:PageSize');
    this.Search = $resource(realestateURL + 'Search/:PageSize/:PageIndex/:SaleType/:Type/:Status/:Country/:City/:District/:Area/:Price/:PaymentType/:Currency');
    this.CountResult = $resource(realestateURL + 'CountSearchResult/:PageSize/:SaleType/:Type/:Status/:Country/:City/:District/:Area/:Price/:PaymentType/:Currency');
    this.RealEstatesByCatalog = $resource(realestateURL + 'RealEstatesByCatalog/:CatalogID/:PageIndex/:PageSize');
    this.CountRealEstatesByCatalog = $resource(realestateURL + 'RealEstatesNoByCatalog/:Catalog/:PageSize');
    //-------------------------- Real Estate Data------------------------------------------------//
    this.RealEstate = $resource(realestateURL + 'RealEstates/:ID');
    this.RealEstateOwner = $resource(realestateURL + 'RealEstateOwner/:ID');
    this.RealEstatePhotos = $resource(realestateURL + 'RealEstatePhotos/:RealEstateID');
    this.RealEstateKeywords = $resource(realestateURL + 'RealEstateKeywords/:RealEstateID');
    this.RealEstateCriterias = $resource(realestateURL + 'RealEstateCriterias/:RealEstateID');
    //---------------------------Search---------------------------------------------------------------//
    this.SearchQuery = $resource(generalURL + 'SearchQuery/:URL:/Query');
    //-------------------------- Client Interactions--------------------------------------------------//
    this.Contactus = $resource(generalURL + 'Contactus');
    this.SendComplain = $resource(realestateURL + 'SendComplain');
    this.PurchaseRequest = $resource(realestateURL + 'PurchaseRequest');
    this.NotifyRequest = $resource(generalURL + 'SendNotifyRequest');
    this.SendMail = $resource(generalURL + 'ContactCompany');
    this.ValidateContactData = $resource(realestateURL + 'ValidateContactData');
    this.InqueryRequest = $resource(realestateURL + 'InqueryRequest');
    this.Login = $resource(generalURL + 'Login');
    this.CheckLogin = $resource(generalURL + 'CheckLogin');
    //------------------------- Projects Data ------------------------------------------------------//
    this.Projects = $resource(ProjectURL + 'Projects/:PageIndex/:PageSize');
    this.BannerProjects = $resource(ProjectURL + 'BannerProjects');
    this.ProjectsCount = $resource(ProjectURL + 'ProjectCount/:PageSize');
    this.CompanyProjects = $resource(ProjectURL + 'ProjectsByCompany/:CompanyID/:PageIndex/:PageSize');
    this.CompanyProjectsCount = $resource(ProjectURL + 'CompanyProjectsCount/:CompanyID/:PageSize');
    this.ProjectPhotoAlbum = $resource(ProjectURL + 'ProjectPhotoAlbum/:ID/:PageSize');
    this.ProjectPhotos = $resource(ProjectURL + 'ProjectPhoto/:ID/:Date');
    this.ProjectVedios = $resource(ProjectURL + 'ProjectVedios/:ID/:PageSize');
    this.ProjectModels = $resource(ProjectURL + 'ProjectModels/:ID/:PageSize');
    this.Model = $resource(ProjectURL + 'ProjectModel/:ID');
    this.HomePageProjects = $resource(ProjectURL + 'HomePageProjects');
    this.ProjectProperties = $resource(ProjectURL + 'ProjectProperties/:ID/:PageIndex/:PageSize');
    this.CountProjectProperties = $resource(ProjectURL + 'CountProjectProperties/:ID/:PageSize');
    //------------------------- Company Date-------------------------------------------------------//
    this.Companies = $resource(generalURL + 'Companies/:PageIndex/:PageSize');
    this.CompaniesCount = $resource(generalURL + 'CompaniesCount/:PageSize');
    //------------------------- Ads Data---------------------------------------------------------//
    this.Ads = $resource(generalURL + 'Advertisement');
    //------------------------- Catalogs Data--------------------------------------------------//
});