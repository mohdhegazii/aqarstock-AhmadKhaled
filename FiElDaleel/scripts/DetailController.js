var brokerApp = angular.module('brokerApp', ['ui.router', 'ngAnimate', 'ngResource']);
//---------------------------Start: Configuration------------------------------------------------//
brokerApp.config(function ($stateProvider, $urlRouterProvider, $locationProvider) {
    $urlRouterProvider.otherwise('/');
    $stateProvider
         .state('unit', {
        url: "/",
    })
     .state('request', {
                url: "/Request/:ID/:Name/:Type",
                templateUrl: "views/unitsRequest.html",
                controller: "RequestController"
            })
            .state('gallery', {
                url: "/Gallery/:ID/:Name",
                templateUrl: "views/unitsGallery.html",
                controller: "GalleryController"
            })
//               .state('partner', {
//                url: "partner/:ID/:Name",
//                controller: "PartnerUnitsController"
//            })
                .state('complaint', {
                url: "/Complaint/:ID/:Name",
                templateUrl: "views/unitsComplaint.html",
                controller: "ComplainController"
            })
              .state('requestConfirmation', {
                url: "/requestConfirmation/:ID/:Name/:Type",
                templateUrl: "views/requestConfirmation.html",
                controller: "RequestController"
            })
            .state('complaintConfirmation', {
                url: "/complaintConfirmation/:ID/:Name",
                templateUrl: "views/complaintConfirmation.html",
                controller: "ComplainController"
            })
    $locationProvider.hashPrefix('!');
});
//----------------------- End: Configuration -----------------------------------------------//
//---------------------- Start : Main Controller------------------------------------------//
brokerApp.controller('MainController', function ($scope, $stateParams, $state, $location, BrokerServices) {

    //------------------- Fill Search selects-----------------------------------------------//
    $scope.SaleTypes = BrokerServices.SaleTypes.query();
    $scope.RealEstateTypes = BrokerServices.RealEstateTypes.query();
   // $scope.Cities = BrokerServices.CitiesByCountry.query({CountryID:1});
    $scope.Countries=BrokerServices.Countries.query();

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
        window.location = '/index.html#!/Units/list/1/ByPrice/' + MinPrice + "/" + MaxPrice + "/السعر/";
    }

    $scope.SearchByArea = function () {
        var MinArea = $("#AreaSlider").slider("values", 0);
        var MaxArea = $("#AreaSlider").slider("values", 1);
        window.location = '/index.html#!/Units/list/1/ByArea/' + MinArea + "/" + MaxArea + "/المساحة/";
    }
    $scope.SearchBySaleType = function () {
        var SaleTypeID = $('#SaleType').val();
        if (SaleTypeID != null && SaleTypeID != "") {
            window.location = '/index.html#!/Units/list/1/BySale/' + SaleTypeID + '/' + $("#SaleType option:selected").text();
        }
        else {
            window.location = '/index.html#!/Units/list/1/All/كل_الوحدات';
        }
    }
    $scope.SearchByRealEstateType = function () {
        var RealEstateTypeID = $('#RealEstateType').val();
        if (RealEstateTypeID != null && RealEstateTypeID != "") {
            window.location = '/index.html#!/Units/list/1/ByType/' + RealEstateTypeID + "/" + $("#RealEstateType option:selected").text();

        }
        else {
            window.location = '/index.html#!/Units/list/1/All/كل_الوحدات';
        }
    }
    $scope.SearchByLocation = function () {
    var CountryID=$('#Country').val();
        var CityID = $('#city').val();
        var DistrictID = $('#district').val();
        if(CountryID!=null && CountryID!=""){
            if (CityID != null && CityID != "") {
                if (DistrictID != null && DistrictID != "") {
                    window.location = '/index.html#!/Units/list/1/ByDistrict/' + DistrictID + "/" + $("#district option:selected").text();
                }
                else {
                    window.location = '/index.html#!/Units/list/1/ByCity/' + CityID + "/" + $("#city option:selected").text();
                }
            }
            else
            {
             window.location = '/index.html#!/Units/list/1/ByCountry/' + CountryID + "/" + $("#Country option:selected").text();
            }
        }
        else {
            window.location = '/index.html#!/Units/list/1/All/كل_الوحدات';
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
        window.location = '/index.html#!/Units/list/1/' + Criteria;
    }
    $scope.SearchByCategory = function (CategoryID, Name) {
        window.location = '/index.html#!/Units/list/1/ByCategory/' + CategoryID + "/" + Name.replace(' ', '_');
    }
    $scope.SearchByNew = function () {
        window.location = '/index.html#!/Units/list/1/ByNew/احدث_الوحدات';
    }
    //  alert($scope.ID);

        //-------------------- Bind map-------------------------------------------------//

   

});
//----------------------- End: Main Controller -----------------------------------------------//
//------------------------Start: Detail Controller---------------------------------------------------//
brokerApp.controller('DetailController', function ($scope, $stateParams, $state,  BrokerServices) {
// $('#divloading').hide();
    //------------------- Fill Scope Variables----------------------------------------------//
    $scope.ID = $('#ContentPlaceHolder1_hdnID').val();
    $scope.Name = $('#ContentPlaceHolder1_lblTitle').text();
    $scope.SaleType=$('#lblSaleType').text();
   // alert($scope.Saletype);
       if($scope.Saletype="للبيع"){
        $scope.SaleType=" شراء";
       // alert($scope.Saletype);
        }
        else{
        $scope.SaleType="تأجير"
        }
//$scope.URL=window.location.href;
//    console.log($scope.URL);
    //---------------------Get real Estate Criteria----------------------------------//
    var crteria = BrokerServices.RealEstateCriterias.query({ RealEstateID: $scope.ID }, function () {
            $scope.Criterias = crteria;
              
        });
 //-------------------- Bind Buttons Click----------------------------------------//
    $scope.ShowPhotos = function () {
        $("#divDetails").hide();
        $stateParams = { "ID": $scope.ID, "Name": $scope.Name.replace(/ /g, '_') };
        //  alert('test');
        //  alert(realestate.Name);
        $state.go('gallery', $stateParams);
    }
    $scope.ShowComplainForm = function () {
        //  alert(ID);
        $("#divDetails").hide();
        $stateParams = { "ID": $scope.ID, "Name": $scope.Name.replace(/ /g, '_') };
        $state.go('complaint', $stateParams);
    }
    $scope.ShowRequestForm = function () {
        //  alert(ID);
        $("#divDetails").hide();
        $stateParams = { "ID": $scope.ID, "Name": $scope.Name.replace(/ /g, '_'), "Type": $scope.SaleType };
        $state.go('request', $stateParams);
    }
        //Toggle MiniMenu in responsive view
    $scope.miniMenu = function () {
        $('aside nav').toggleClass('in');
        $('.miniMenu').toggleClass('active');
    }
});
//-----------------------End: Detail Controller------------------------------------------------------//
//-----------------Start:Gallery Controller--------------------------------------------//
brokerApp.controller('GalleryController', function ($scope, $stateParams, BrokerServices) {
  //  alert('test');
    $scope.Title = $stateParams.Name.replace(/_/g, ' ');
    $('#divloading').show();
    var photos = BrokerServices.RealEstatePhotos.query({ RealEstateID: $stateParams.ID }, function () {
        $scope.Photos = photos;
        $('#divloading').hide();
    });
});
//-----------------End:Gallery Controller---------------------------------------------//
//-----------------Start:Complain Controller-----------------------------------------//
brokerApp.controller('ComplainController', function ($scope, $stateParams, BrokerServices, $state) {
    //alert('test');
    $scope.Title = $stateParams.Name.replace(/_/g, ' ');
    $scope.Complain = {};
    $scope.Complain.RealEstateID = $stateParams.ID;
    $scope.SendComplain = function () {
        if ($scope.ComplainForm.$valid) {
        $('#divloading').show();
            var Message = BrokerServices.SendComplain.save({}, JSON.stringify($scope.Complain), function () {
             //  $('#divMessage span').text(Message.SendComplainResult);
              $('#divloading').hide();
              $state.go('complaintConfirmation', $stateParams);
                //alert(Message.SendComplainResult);
              //  $state.go('complaintConfirmation');
                //  console.log(Message);
            });
        }
    }
});
//-----------------End:Complain Controller-------------------------------------------//
//----------------Start:Request Controller------------------------------------------//
brokerApp.controller('RequestController', function ($scope, $stateParams, BrokerServices, $state) {
//alert('view');
    $scope.Title = $stateParams.Name.replace(/_/g, ' ');
    $scope.Type = $stateParams.Type;
    $scope.Request = {};
    $scope.Request.RealEstateID = $stateParams.ID;
    $scope.SendRequest = function () {
  //  alert ("test");
        if ($scope.RequestForm.$valid) {
      //  Console.log($scope.Request);
        $('#divloading').show();
            var Message = BrokerServices.PurchaseRequest.save({}, JSON.stringify($scope.Request), function () {
          // $('#divMessage span').text(Message.PurchaseRequestResult);
               // alert(Message.PurchaseRequestResult);
                $('#divloading').hide();
                $state.go('requestConfirmation', $stateParams);
                   console.log(Message);
            });
        }
        // else{
        //            $scope.invalid=true;
        //            }
    }

});
//----------------End:Request Controller-------------------------------------------//
//---------------------- Start :Partner Units Controller------------------------------------------//
brokerApp.controller('PartnerUnitsController', function ($scope, $stateParams, $state, BrokerServices) {
  //  alert("test Main");
    $scope.ID = $('#ContentPlaceHolder1_hdnID').val();
    $scope.SearchType = $('#ContentPlaceHolder1_hdnTitle').val();
     // $('#divloading').show();
       
    //alert( $('#divloading'));

     var SearchCriteria = {};
        SearchCriteria.PageSize = 40;
        SearchCriteria.PageIndex =1;
        $scope.PageIndex = 1;
         SearchCriteria.SubscriberID = $scope.ID;
         
            var realestates = BrokerServices.Search.query({}, JSON.stringify(SearchCriteria), function () {
                $scope.realEstates = realestates;
                       if(realestates=="" ||realestates==null){
                    $('#divEmpty').show();
                }
                $('#divloading').hide();
               
            });
               //---------------- Set Pages--------------------------------------------------------//
        var count = BrokerServices.CountResult.query({}, JSON.stringify(SearchCriteria), function () {
            if (count.length > 1) {
                $scope.Pages = count;
            }
            else {
                $(".pagination").css("display", "none");
            }
        });
    
                //---------------------- Move to another page-------------------------------------------//
    $scope.MoveTo = function (PageIndex) {
     $('#divloading').show();
     window.scrollTo(0,0);
       var SearchCriteria = {};
        SearchCriteria.PageSize = 20;
        SearchCriteria.PageIndex =PageIndex;
        $scope.PageIndex = PageIndex;
         SearchCriteria.SubscriberID = $scope.ID;
            var realestates = BrokerServices.Search.query({}, JSON.stringify(SearchCriteria), function () {
                $scope.realEstates = realestates;
                       if(realestates=="" ||realestates==null){
                    $('#divEmpty').show();
                }
                $('#divloading').hide();
            });
            $('.pagination a').removeClass("selected");
            //var str=;
            $("#"+PageIndex.toString()).addClass("selected");
    }

        //----------------------show realestate Details-----------------------------------------//
    $scope.ShowDetails = function (ID, Name) {
      window.location = "/Details/"+ID+'/'+ Name.replace(/[^0-9a-zA-Zء-ي]+/g, '_') ;
//        $stateParams = { "ID": ID, "Name": Name.replace(/ /g, '_') };
//        $state.go('units.details', $stateParams);
    }
});
//----------------------- End:Partner Units Controller----------------------------------------//