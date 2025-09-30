
var brokerApp = angular.module('brokerApp', ['ui.router', 'ngAnimate', 'ngResource']);
//---------------------------Start: Configuration------------------------------------------------//

brokerApp.config(function ($stateProvider, $urlRouterProvider, $locationProvider) {
    $urlRouterProvider.otherwise('/');
    $stateProvider
    .state('home', {
        url: "/",
        templateUrl: "views/home.html"
    })
    .state('units', {
        url: "/Units",
        templateUrl: "views/core.html
    })
        .state('units.List', {
            url: "/list/:PageIndex/*Criteria",
            templateUrl: "views/units.html",
            controller: "RealEstateListController"
        })
           
            .state('units.advancedSearch', {
                url: "/AdvancedSearch",
                templateUrl: "views/advancedSearch.html",
            })
           
            .state('units.contact', {
                url: "/ContactUs",
                templateUrl: "views/contact.html",
                controller: "ContactusController"
            })
            .state('units.about', {
                url: "/AboutUs",
                templateUrl: "views/about.html"
            })
            .state('units.contactConfirmation', {
                url: "/ContactUsConfirmation",
                templateUrl: "views/contactConfirmation.html"
            })
           
    $locationProvider.hashPrefix('!');
});
//----------------------- End: Configuration -----------------------------------------------//
//---------------------- Start :Search Controller------------------------------------------//
brokerApp.controller('SearchController', function ($scope, $state, $stateParams, BrokerServices) {
    //alert('test');
    //------------------- Fill Search selects-----------------------------------------------//
    $scope.SaleTypes = BrokerServices.SaleTypes.query();
    $scope.RealEstateTypes = BrokerServices.RealEstateTypes.query();
    $scope.Countries=BrokerServices.Countries.query();
    //$scope.Cities = BrokerServices.CitiesByCountry.query({CountryID:"1"});//BrokerServices.Cities.query();
   // console.log($scope.Cities);
    //-------------------Bind the Cities List According to Country -----------------------------------//
    $scope.BindCities = function (CountryID) {
        if (CountryID > 0) {
            $scope.Cities =BrokerServices.CitiesByCountry.query({CountryID:CountryID});
            $('#city').prop('disabled', false);
        }
        else {
            $scope.Cities = null
            $('#city').prop('disabled', true);
        }
    }

    //-------------------Bind the District List According to City -----------------------------------//
    $scope.BindDistricts = function (CityID) {
        if (CityID > 0) {
            $scope.Districts = BrokerServices.DistrictsByCity.query({ CityID: CityID });
            $('#district').prop('disabled', false);
        }
        else {
            $scope.Districts = null

            $('#district').prop('disabled', true);
        }
    }

    //---------------- Search Event Handlers --------------------------------------//
    $scope.SearchByPrice = function () {
        var MinPrice = $("#PriceSlider").slider("values", 0);
        var MaxPrice = $("#PriceSlider").slider("values", 1);
        $stateParams = { "PageIndex": 1, "Criteria": "ByPrice/" + MinPrice + "/" + MaxPrice + "/السعر/" };
       window.scrollTo(0,0);
       // $scope.Title = " عقار ستوك- " + $scope.SearchType;
       CheckResponsiveMenu();
        $state.go('units.List', $stateParams);
    }

    $scope.SearchByArea = function () {
        var MinArea = $("#AreaSlider").slider("values", 0);
        var MaxArea = $("#AreaSlider").slider("values", 1);
        $stateParams = { "PageIndex": 1, "Criteria": "ByArea/" + MinArea + "/" + MaxArea + "/المساحة/" };
        window.scrollTo(0,0);
      //  $scope.Title = " عقار ستوك- " + $scope.SearchType;
        $state.go('units.List', $stateParams);
    }

    $scope.SearchBySaleType = function () {
        var SaleTypeID = $('#SaleType').val();
        if (SaleTypeID != null && SaleTypeID != "") {
            $stateParams = { "PageIndex": 1, "Criteria": "BySale/" + SaleTypeID + '/' + $("#SaleType option:selected").text() };
           window.scrollTo(0,0);
          //  $scope.Title = " عقار ستوك- " + $scope.SearchType;
            $state.go('units.List', $stateParams);
        }
        else {
            $scope.SearchType = "كل الوحدات";
            $stateParams = { "PageIndex": 1, "Criteria": "All/كل_الوحدات" };
            window.scrollTo(0,0);
            $state.go('units.List', $stateParams);
        }
    }
    $scope.SearchByRealEstateType = function () {
        var RealEstateTypeID = $('#RealEstateType').val();
        if (RealEstateTypeID != null && RealEstateTypeID != "") {
    
    //        $scope.Title = " عقار ستوك- " + $scope.SearchType;
            $stateParams = { "PageIndex": 1, "Criteria": "ByType/" + RealEstateTypeID + "/" + $("#RealEstateType option:selected").text() };
           window.scrollTo(0,0);
            $state.go('units.List', $stateParams);
        }
        else {
            $scope.SearchType = "كل الوحدات";
            $scope.Title =  $scope.SearchType+" - عقار ستوك-عقارات للتداول في جميع مدن مصرعقار ستوك :  سوق تداول العقارات | التجمع | الشروق | أكتوبر | زايد | الساحل وكل مدن مصر - AqarStock.com : Egypt Real Estate Stock" ;
            $stateParams = { "PageIndex": 1, "Criteria": "All/كل_الوحدات" };
          window.scrollTo(0,0);
            $state.go('units.List', $stateParams);
        }
    }
    $scope.SearchByLocation = function () {
    var CountryID=$('#Country').val();
        var CityID = $('#city').val();
        var DistrictID = $('#district').val();
        if(CountryID!=null && CountryID!=""){
            if (CityID != null && CityID != "") {
                if (DistrictID != null && DistrictID != "") {
                    $scope.SearchType = "نتيجة البحث عن وحدات فى  " + $("#district option:selected").text();
                  //  $scope.Title = " عقار ستوك- " + $scope.SearchType;
                    $stateParams = { "PageIndex": 1, "Criteria": "ByDistrict/" + DistrictID + "/" + $("#district option:selected").text() };
                 window.scrollTo(0,0);
                    $state.go('units.List', $stateParams);
                }
                else {
                    $scope.SearchType = "نتيجة البحث عن وحدات فى " + $("#city option:selected").text();
                  //  $scope.Title = " عقار ستوك- " + $scope.SearchType;
                    $stateParams = { "PageIndex": 1, "Criteria": "ByCity/" + CityID + "/" + $("#city option:selected").text() };
                   window.scrollTo(0,0);
                    $state.go('units.List', $stateParams);
                }
            }
            else{
              $scope.SearchType = "نتيجة البحث عن وحدات فى " + $("#Country option:selected").text();
                  //  $scope.Title = " عقار ستوك- " + $scope.SearchType;
                    $stateParams = { "PageIndex": 1, "Criteria": "ByCountry/" + CountryID + "/" + $("#Country option:selected").text() };
                   window.scrollTo(0,0);
                    $state.go('units.List', $stateParams);
            }
        }
        else {
            $scope.SearchType = "كل الوحدات";
            $scope.Title =  $scope.SearchType +" - عقار ستوك :  سوق تداول العقارات | التجمع | الشروق | أكتوبر | زايد | الساحل وكل مدن مصر - AqarStock.com : Egypt Real Estate Stock";
            $stateParams = { "PageIndex": 1, "Criteria": "All/كل_الوحدات" };
          window.scrollTo(0,0);
            $state.go('units.List', $stateParams);
        }
    }
    $scope.AdvancedSearch = function () {
        var Criteria = "Advanced/";
        Criteria += $("#PriceSlider").slider("values", 0) + "/";
        Criteria += $("#PriceSlider").slider("values", 1) + "/";
        Criteria += $("#AreaSlider").slider("values", 0) + "/";
        Criteria += $("#AreaSlider").slider("values", 1) + "/";
        Criteria += $('#SaleType').val() + "/";
        Criteria += $('#RealEstateType').val() + "/";
        Criteria += $('#city').val() + "/";
        Criteria += $('#district').val() + "/";
        Criteria += $('#Country').val() + "/";
        Criteria += "البحث_المفصل";
      
        $stateParams = { "PageIndex": 1, "Criteria": Criteria };
         CheckResponsiveMenu();
      window.scrollTo(0,0);
        $state.go('units.List', $stateParams);
    }
    $scope.SearchByCategory = function (CategoryID, Name) {
        $stateParams = { "PageIndex": 1, "Criteria": "ByCategory/" + CategoryID + "/" + Name.replace(' ', '_') };
        $scope.SearchType = "نتيجة البحث عن " + Name;
        //$scope.Title = " عقار ستوك- " + $scope.SearchType;
        CheckResponsiveMenu();
        window.scrollTo(0,0);
        $state.go('units.List', $stateParams);
    }
    $scope.SearchByNew = function () {
        $stateParams = { "PageIndex": 1, "Criteria": "ByNew/احدث_الوحدات" };
     window.scrollTo(0,0);
         CheckResponsiveMenu();
        $state.go('units.List', $stateParams);
    }
    $scope.GoHome = function () {
        $scope.Title = 'عقار ستوك :  سوق تداول العقارات | التجمع | الشروق | أكتوبر | زايد | الساحل وكل مدن مصر - AqarStock.com : Egypt Real Estate Stock';
        $state.go('home');
    }
       $scope.Aboutus = function () {
        $scope.Title = "عقار ستوك :  سوق تداول العقارات | التجمع | الشروق | أكتوبر | زايد | الساحل وكل مدن مصر - AqarStock.com : Egypt Real Estate Stock";
     CheckResponsiveMenu();
        $state.go('units.about');
    }
    $scope.ContactUs = function () {
        $scope.Title = "عقار ستوك :  سوق تداول العقارات | التجمع | الشروق | أكتوبر | زايد | الساحل وكل مدن مصر - AqarStock.com : Egypt Real Estate Stock";
     CheckResponsiveMenu();
        $state.go('units.contact');
    }

    //Toggle MiniMenu in responsive view
    $scope.miniMenu = function () {
        $('aside nav').toggleClass('in');
        $('.miniMenu').toggleClass('active');
    }
   function CheckResponsiveMenu()
    {
       $('aside nav').hasClass('in')?$('aside nav').removeClass('in'):"";
        $('.miniMenu').hasClass('active')? $('.miniMenu').removeClass('active'):"";
    }
});
//-----------------------End:Search Controller------------------------------------//
//-----------------------Start:RealEstate List Controller-------------------------//
brokerApp.controller('RealEstateListController', function ($scope, $state, $stateParams, $location, BrokerServices) {

    if ($stateParams.Criteria != "" && $stateParams.Criteria != null) {
        var Criteria = $stateParams.Criteria.split('/');
        var SearchCriteria = {};
        SearchCriteria.PageSize = 40;
        SearchCriteria.PageIndex = $stateParams.PageIndex;
        $scope.PageIndex = $stateParams.PageIndex;
        var SearchType = Criteria[0];
         $('#divloading').show();
        //----------------Check The Search Type to specify the Search Criteria----------//
        if (SearchType == "ByPrice") {
         $scope.SearchType = "نتيجة البحث بالسعر";
            SearchCriteria.MinPrice = Criteria[1];
            SearchCriteria.MaxPrice = Criteria[2];
            var realestates = BrokerServices.Search.query({}, JSON.stringify(SearchCriteria), function () {
                $scope.realEstates = realestates;
                  if(realestates=="" ||realestates==null){
                    $('#divEmpty').show();
                }
                $('#divloading').hide();
            });
        }
        if (SearchType == "ByArea") {
        $scope.SearchType = "نتيجة البحث بالمساحة";
            SearchCriteria.MinArea = Criteria[1];
            SearchCriteria.MaxArea = Criteria[2];
            var realestates = BrokerServices.Search.query({}, JSON.stringify(SearchCriteria), function () {
                $scope.realEstates = realestates;
                  if(realestates=="" ||realestates==null){
                    $('#divEmpty').show();
                }
                $('#divloading').hide();

            });
        }
        if (SearchType == "ByType") {
                $scope.SearchType = "نتيجة البحث عن  " + Criteria[2];
            SearchCriteria.RealEstateTypeID = Criteria[1];
            var realestates = BrokerServices.Search.query({}, JSON.stringify(SearchCriteria), function () {
                $scope.realEstates = realestates;
                       if(realestates=="" ||realestates==null){
                    $('#divEmpty').show();
                }
                $('#divloading').hide();
            });
        }
        if (SearchType == "BySale") {
        $scope.SearchType = "نتيجة البحث عن وحدات " + " " + Criteria[2];
            SearchCriteria.SaleTypeID = Criteria[1];
            var realestates = BrokerServices.Search.query({}, JSON.stringify(SearchCriteria), function () {
                $scope.realEstates = realestates;
                       if(realestates=="" ||realestates==null){
                    $('#divEmpty').show();
                }
                $('#divloading').hide();
            });
        }
             if (SearchType == "ByCountry") {
          $scope.SearchType = "نتيجة البحث عن وحدات فى  " +Criteria[2];
            SearchCriteria.CountryID = Criteria[1];
            var realestates = BrokerServices.Search.query({}, JSON.stringify(SearchCriteria), function () {
                $scope.realEstates = realestates;
                       if(realestates=="" ||realestates==null){
                    $('#divEmpty').show();
                }
                $('#divloading').hide();
            });
        }
        if (SearchType == "ByCity") {
          $scope.SearchType = "نتيجة البحث عن وحدات فى  " +Criteria[2];
            SearchCriteria.CityID = Criteria[1];
            var realestates = BrokerServices.Search.query({}, JSON.stringify(SearchCriteria), function () {
                $scope.realEstates = realestates;
                       if(realestates=="" ||realestates==null){
                    $('#divEmpty').show();
                }
                $('#divloading').hide();
            });
        }
        if (SearchType == "ByDistrict") {
           $scope.SearchType = "نتيجة البحث عن وحدات فى  " +Criteria[2];
            SearchCriteria.DistrictID = Criteria[1];
            var realestates = BrokerServices.Search.query({}, JSON.stringify(SearchCriteria), function () {
                $scope.realEstates = realestates;
                       if(realestates=="" ||realestates==null){
                    $('#divEmpty').show();
                }
                $('#divloading').hide();
            });
        }
        if (SearchType == "All") {
            $scope.SearchType = "كل الوحدات";
            var realestates = BrokerServices.Search.query({}, JSON.stringify(SearchCriteria), function () {
                $scope.realEstates = realestates;
                       if(realestates=="" ||realestates==null){
                    $('#divEmpty').show();
                }
                $('#divloading').hide();
            });
        }
        if (SearchType == "Advanced") {
          $scope.SearchType = "نتيجة البحث المفصل";
            SearchCriteria.MinPrice = Criteria[1];
            SearchCriteria.MaxPrice = Criteria[2];
            SearchCriteria.MinArea = Criteria[3];
            SearchCriteria.MaxArea = Criteria[4];
            if (Criteria[5] != null && Criteria[5] != 0) {
                SearchCriteria.SaleTypeID = Criteria[5];
            }
            if (Criteria[6] != null && Criteria[6] != 0) {
                SearchCriteria.RealEstateTypeID = Criteria[6];
            }
            if (Criteria[7] != null && Criteria[7] != 0) {
                SearchCriteria.CityID = Criteria[7];
            }
            if (Criteria[8] != null && Criteria[8] != 0) {
                SearchCriteria.DistrictID = Criteria[8];
            }
              if (Criteria[9] != null && Criteria[9] != 0) {
                SearchCriteria.CountryID = Criteria[9];
            }
            var realestates = BrokerServices.Search.query({}, JSON.stringify(SearchCriteria), function () {
                $scope.realEstates = realestates;
                        if(realestates=="" ||realestates==null){
                    $('#divEmpty').show();
                }
                $('#divloading').hide();
            });
        }
        if (SearchType == "ByCategory") {
         $scope.SearchType = "نتيجة البحث عن " + Criteria[2].replace('_', ' ');
            SearchCriteria.RealEstateCategoryID = Criteria[1];
            var realestates = BrokerServices.Search.query({}, JSON.stringify(SearchCriteria), function () {
                $scope.realEstates = realestates;
                     if(realestates=="" ||realestates==null){
                    // alert('empty');
                    $('#divEmpty').show();
                }
                $('#divloading').hide();
            });
        }
        if (SearchType == "ByNew") {
           $scope.SearchType = "نتيجة البحث عن احدث الوحدات";
            var realestates = BrokerServices.RealEstates.query({ PageIndex: SearchCriteria.PageIndex, PageSize: SearchCriteria.PageSize }, function () {
                $scope.realEstates = realestates;
                       if(realestates=="" ||realestates==null){
                    $('#divEmpty').show();
                }
                $('#divloading').hide();
            });
        }
         $scope.Title =+ $scope.SearchType + " -عقار ستوك :  سوق تداول العقارات | التجمع | الشروق | أكتوبر | زايد | الساحل وكل مدن مصر - AqarStock.com : Egypt Real Estate Stock " ;

          if (SearchType == "ByUser") {
                $scope.SearchType =  Criteria[2];//" أحدث العقارات فى الشروق - شقق و دوبلكس تمليك بالتقسيط بدون فوائد من دار - الخط الساخن 16045";
               // alert(Criteria[1]);
            SearchCriteria.SubscriberID = Criteria[1];
            var realestates = BrokerServices.Search.query({}, JSON.stringify(SearchCriteria), function () {
                $scope.realEstates = realestates;
                       if(realestates=="" ||realestates==null){
                    $('#divEmpty').show();
                }
                $('#divloading').hide();
            });
        }
        //---------------- Set Pages--------------------------------------------------------//
        var count = BrokerServices.CountResult.query({}, JSON.stringify(SearchCriteria), function () {
            if (count.length > 1) {
                $scope.Pages = count;
            }
            else {
                $(".pagination").css("display", "none");
            }
        });
    }
    //---------------------- Move to another page-------------------------------------------//
    $scope.MoveTo = function (PageIndex) {
        // $stateParams.PageIndex = PageIndex;
        window.scrollTo(0,0);
        $stateParams = { "PageIndex": PageIndex, "Criteria": $stateParams.Criteria };
        $state.go('units.List', $stateParams);
        //  alert(PageIndex);
    }
    //----------------------show realestate Details-----------------------------------------//
    $scope.ShowDetails = function (ID, Name) {
      window.location = "/Details/"+ID+'/'+ Name.replace(/[^0-9a-zA-Zء-ي]+/g, '_') ;
//        $stateParams = { "ID": ID, "Name": Name.replace(/ /g, '_') };
//        $state.go('units.details', $stateParams);
    }
});
//----------------------End:RealEstate List Controller------------------------------------------------//
//----------------Start:Contact us Controller------------------------------------------//
brokerApp.controller('ContactusController', function ($scope, $stateParams, BrokerServices,$state) {
$('.unitsInfo').hide();
    $scope.Contactus = {};
    $scope.Contactus.RealEstateID = $stateParams.ID;
    $scope.SendMessage = function () {
        if ($scope.ContactForm.$valid) {
         $('#divloading').show();
            var Message = BrokerServices.Contactus.save({}, JSON.stringify($scope.Contactus), function () {
            //  $('#divMessage span').text(Message.ContactUsResult);
               $('#divloading').hide();
              // $state.go('requestConfirmation');
                /*alert(Message.ContactUsResult);
                            console.log(Message);*/
                $state.go('units.contactConfirmation');
            });
        }
    }
});
//----------------End:Contact us Controller-------------------------------------------//