var phonecatApp = angular.module('Testapp', ['ngResource']);

phonecatApp.service("BrokerServices", function ($resource) {
    //------------Codes------------------------------------------------------------------------//
    this.Cities = $resource('http://109.203.127.181:7070/Services/GeneralService.svc/Cities');
    this.Districts = $resource('http://109.203.127.181:7070/Services/GeneralService.svc/Districts');
    this.DistrictsByCity = $resource('http://109.203.127.181:7070/Services/GeneralService.svc/Districts/:CityID');
    this.PaymentMethods = $resource('http://109.203.127.181:7070/Services/GeneralService.svc/PaymentTypes');
    this.Currencies = $resource('http://109.203.127.181:7070/Services/GeneralService.svc/Currencies');
    this.SaleTypes = $resource('http://109.203.127.181:7070/Services/GeneralService.svc/SalesTypes');
    this.RealEstateCategories = $resource('http://109.203.127.181:7070/Services/RealEstateService.svc/RealEstateCategories');
    this.RealEstateTypes = $resource('http://109.203.127.181:7070/Services/RealEstateService.svc/RealEstateTypes');
    this.RealEstateTypesByCategory = $resource('http://109.203.127.181:7070/Services/RealEstateService.svc/RealEstateTypes/:RealEstateCategoryID');
    this.RealEstateStaus = $resource('http://109.203.127.181:7070/Services/RealEstateService.svc/RealEstateStaus/:RealEstateCategoryID');
    //----------------------Get Real Estate List--------------------------------------------------//
    this.RealEstates = $resource('http://109.203.127.181:7070/Services/RealEstateService.svc/RealEstates/:PageIndex/:PageSize');
    //-------------------------- Real Estate Data------------------------------------------------//
    this.RealEstate = $resource('http://109.203.127.181:7070/Services/RealEstateService.svc/RealEstates/:ID');
    this.RealEstatePhotos = $resource('http://109.203.127.181:7070/Services/RealEstateService.svc/RealEstatePhotos/:RealEstateID');
    this.RealEstateKeywords = $resource('http://109.203.127.181:7070/Services/RealEstateService.svc/RealEstateKeywords/:RealEstateID');
    this.RealEstateCriterias = $resource('http://109.203.127.181:7070/Services/RealEstateService.svc/RealEstateCriterias/:RealEstateID');
    //---------------------------Search---------------------------------------------------------------//
    this.Search = $resource('http://109.203.127.181:7070/Services/RealEstateService.svc/Search', null, { 'Search': { method: 'POST'} });
    //-------------------------- Client Interactions--------------------------------------------------//
    this.Contactus = $resource('http://109.203.127.181:7070/Services/GeneralService.svc/Contactus');
    this.SendComplain = $resource('http://109.203.127.181:7070/Services/RealEstateService.svc/SendComplain');
    this.PurchaseRequest = $resource('http://109.203.127.181:7070/Services/RealEstateService.svc/PurchaseRequest');
});

//----------------------------------- Test Controller---------------------------------------------//
phonecatApp.controller('TestController', function ($scope, BrokerServices) {
    $scope.Cities = BrokerServices.Cities.query();
    //-------------------Events-----------------------------------------------------------//
    $scope.SelectCity = function () {
        $scope.Districts = BrokerServices.DistrictsByCity.query({ CityID: $scope.SelectedCity });
        alert($scope.SelectedCity);
    }
//    $scope.items = BrokerServices.RealEstateTypesByCategory.query({ RealEstateID: 1 });

//    var realestate = BrokerServices.RealEstate.get({ ID: 1 }, function () {
//        $scope.name = realestate.Name;
//    });

//    var email = {};
//    email.Email = 'Test@aa.aa';
//    email.Message = 'Success';
//    email.Name = 'Test angular';
//    email.Phone = '1233';
//    email.RealEstateID = 1;
    //  email.Title = 'Test Complain';

  //  BrokerServices.PurchaseRequest.save({}, JSON.stringify(email));
});