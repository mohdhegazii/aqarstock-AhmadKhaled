var brokerApp = angular.module('brokerApp', ['ui.router', 'ngAnimate', 'ngResource']);
//--------------------- Begin:Configuration--------------------------------//

brokerApp.config(function ($stateProvider, $urlRouterProvider, $locationProvider) {
    $urlRouterProvider.otherwise('/');
    $stateProvider
    .state('Default', {
        url: "/",
    })
    .state('gallery', {
        url: "/Gallery/",
        templateUrl: "views/PropertyGallery.htm",
        controller: "GalleryController"
    })
    .state('request', {
        url: "/Request/",
        templateUrl: "views/Request.htm",
        controller: "RequestController"
    })
    .state('UserData', {
        url: "/RegesterData/",
        templateUrl: "views/UserData.htm",
        controller: "UserDataController"
    })
    .state('OwnerData', {
        url: "/OwnerData/",
        templateUrl: "views/OwnerData.htm",
        controller: "OwnerDataController"
    })
    .state('ValidateContact', {
        url: "/ValidateContact/",
        params: { Code: null,Request:null},
        templateUrl: "views/ValidateContacts.htm",
        controller: "ValidateContactController"
                
    })
    .state('complain', {
        url: "/Complain/",
        templateUrl: "views/Complain.htm",
        controller: "ComplainController"
    })
    .state('SendMail', {
        url: "/SendMail/",
        templateUrl: "views/SendMail.htm",
        controller: "SendMailController"
    })
    .state('Properties', {
        url: "/Properties/",
        templateUrl: "views/CompanyProperties.htm",
        controller: "CompanyPropertiesController"
    })
    .state('Projects', {
        url: "/Projects/",
        templateUrl: "views/CompanyProjects.htm",
        controller: "CompanyProjectsController"
    })
    .state('Model', {
        url: "/Model/:ID",
        templateUrl: "views/ModelDetails.htm",
        controller: "ModelDetailsController"
    })
    .state('ProjectPhotos', {
        url: "/Photos/:Date",
        templateUrl: "views/ProjectPhotos.htm",
        controller: "ProjectPhotoController"
    })
    .state('ProjectPhotoAlbum', {
        url: "/PhotosAlbums/",
        templateUrl: "views/Project PhotoList.htm",
        controller: "ProjectPhotoAlbumController"
    })
    .state('ProjectVideos', {
        url: "/Videos/",
        templateUrl: "views/ProjectVideoList.htm",
        controller: "ProjectVediosController"
    })
    .state('ProjectModels', {
        url: "/Models/",
        templateUrl: "views/ProjectModels.htm",
        controller: "ProjectModelsController"
    })
      .state('ProjectProperties', {
          url: "/ProjectProperties/",
          templateUrl: "views/ProjectProperties.htm",
          controller: "ProjectPropsController"
      })
        .state('CatalogProperties', {
            url: "/CatalogProperties/",
            templateUrl: "views/CatalogProperties.html",
            controller: "CatalogPropsController"
        })
    //  $locationProvider.hashPrefix('!');
});
//ComplainController

//--------------------- End:Configuration---------------------------------//
//--------------------- Begin: Main Controller----------------------------//
brokerApp.controller('MainController', function ($scope, $state, BrokerServices) {
    //----------------Begin: Mobile Controls Visibility--------------------------------------//
    //if (window.matchMedia('(max-width: 768px)').matches)
    //{
    //$("#divSideSearch").remove();
    ////alert("test");
    //    // do functionality on screens smaller than 768px
    //}
    //else
    //{
    //$("#MobileSearch").remove();
    //}
    //----------------End: Mobile Controls Visibility--------------------------------------//
    //-------------Begin: Static Variables----------------------------------------------------//
    PageMethods.set_path('/Default.aspx');
    $scope.BaseURl = "";
    $scope.Prices = [
     { text: "اقل من 1000", value: "1000" }
    , { text: "اقل من 5000", value: "5000" }
    , { text: "اقل من 10000", value: "10000" }
    , { text: "اقل من 15000", value: "15000" }
    , { text: "اقل من 20000", value: "20000" }
    , { text: "اقل من 50000", value: "50000" }
    , { text: "اقل من 100000", value: "100000" }
    , { text: "اقل من 250000", value: "250000" }
    , { text: "اقل من 500000", value: "500000" }
    , { text: "اقل من 1000000", value: "1000000" }
    , { text: "اقل من 5000000", value: "5000000" }
    , { text: "اقل من 10000000", value: "10000000" }
    , { text: "اقل من 20000000", value: "20000000" }
    , { text: "اقل من 50000000", value: "50000000" }
    , { text: "اقل من 100000000", value: "100000000" }
    ];
    $scope.Areas = [
    { text: "اقل من 100م", value: "100" }
    , { text: "اقل من 200م", value: "200" }
    , { text: "اقل من 500م", value: "500" }
    , { text: "اقل من 1000م", value: "1000" }
    , { text: "اقل من 1500م", value: "1500" }
    , { text: "اقل من 2000م", value: "2000" }
    , { text: "اقل من 2500م", value: "2500" }
    , { text: "اقل من 3000م", value: "3000" }
    , { text: "اقل من 5000م", value: "5000" }
    , { text: "اقل من 10000م", value: "10000" }
    ];
    $scope.Messages = [
    { Type: "SelectCityError", Title: "عفوا", Message: "يجب اختيار البلد قبل اختيار المحافظة" }
    , { Type: "SelectDistrictError", Title: "عفوا", Message: "يجب اختيار البلد والمحافظة قبل اختيار الحى" }
    , { Type: "SelectStatusError", Title: "عفوا", Message: "يجب اختيار نوع الوحدة قبل اختيار حالة الوحدة" }
    , { Type: "NotifyMessage", Title: "شكراً لك", Message: "لقد تم ارسال بيانات العقار الذى تبحث عنه,سنقوم بالاتصال بك عندما يتم اضافته" }
    , { Type: "RequestMessage", Title: "شكراً لك", Message: "لقد تم تقديم الطلب ,سيقوم مالك العقار بالاتصال بك" }
    , { Type: "ComplainMessage", Title: "شكراً لك", Message: "لقد تم ارسال الشكوى, سنقوم بالتحقيق فيها و الاتصال بك" }
    , { Type: "CompareMaxError", Title: "عفوا", Message: "لا يمكنك المقارنة بين اكثر من 5 عقارات" }
    , { Type: "Error", Title: "عفوا", Message: "لقد حدث خطأ يرجى المحاولة مرة اخرى" }
    , { Type: "ContactusMessage", Title: "شكراً لك", Message: "لقد تم ارسال رسالتك, سنقوم بالاتصال بك قريبا" }
    , { Type: "SendMailMessage", Title: "شكراً لك", Message: "لقد تم ارسال رسالتك, ستقوم الشركة بالاتصال بك قريبا" }
    , { Type: "MustLogin", Title: "عفوا", Message: "يجب تسجيل الدخول قبل اضافة العقار للعقارات المفضلة" }
    , { Type: "AddedtoFavourite", Title: "شكراً لك", Message: "تم اضافة العقار لقائمة العقارات المفضلة الخاصة بك" }
    , { Type: "ShowOwnerData", Title: "عفوا", Message: "يجب تسجيل بياناتك قبل عرض بيانات المالك" }
     , { Type: "CodeNotMatch", Title: "عفوا", Message: "الكود الذى ادخلته لا يطابق الكود المرسل الى رقم هاتفك و الايميل الخاص بك" }
    ];
    $scope.Notify = {};
    //-------------End: Static Variables-----------------------------------------------------//
    //------------------------------------Begin: Bind General Lists---------------------------//
    //  $scope.Prices=SalePrices;
    $scope.RealEstateTypes = BrokerServices.RealEstateTypes.query();
    $scope.Countries = BrokerServices.Countries.query();
    //$scope.NotifyCountries=$scope.Countries;
    $scope.PaymentTypes = BrokerServices.PaymentMethods.query();
    $scope.Currincies = BrokerServices.Currencies.query();
    $scope.Keywords = BrokerServices.Keywords.query();
    //-------------------------------------End: Bind General Lists----------------------------//
    //------------------------------------ Begin: Event Handler Functions--------------------//
    //--------------------------Begin: Search Event Handler------------------------------//
    $scope.BindSearchCities = function () {
        var CountryID = $('#ddlSearchCountry option:selected').val();
        //  alert($('#ddlSearchCountry option:selected').text());
        if (CountryID > 0) {
            $('#ddlSearchCity').unbind('click');
            $scope.SearchCitiesList = BrokerServices.CitiesByCountry.query({ CountryID: CountryID });
            $scope.SearcDistricts = null;
            var result = $.grep($scope.Messages, function (e) { return e.Type == "SelectDistrictError"; });
            $('#ddlSearchDistrict').bind('click', result[0], $scope.ShowMessage);
            $('#ddlSearchDistrict option:first').attr('selected', 'selected');
        }
        else {
            $scope.SearchCitiesList = null;
            $scope.SearcDistricts = null;
            var result = $.grep($scope.Messages, function (e) { return e.Type == "SelectCityError"; });
            $('#ddlSearchCity').bind('click', result[0], $scope.ShowMessage);
            result = $.grep($scope.Messages, function (e) { return e.Type == "SelectDistrictError"; });
            $('#ddlSearchDistrict').bind('click', result[0], $scope.ShowMessage);
            $('#ddlSearchCity option:first').attr('selected', 'selected');
            $('#ddlSearchDistrict option:first').attr('selected', 'selected');
        }
    }
    //---------------------------------------------------
    $scope.BindSearchDistricts = function () {
        var CityID = $('#ddlSearchCity option:selected').val();
        if (CityID > 0) {
            $scope.SearcDistricts = BrokerServices.DistrictsByCity.query({ CityID: CityID });
            $('#ddlSearchDistrict').unbind('click');
        }
        else {
            $scope.SearcDistricts = null;
            var result = $.grep($scope.Messages, function (e) { return e.Type == "SelectDistrictError"; });
            $('#ddlSearchDistrict').bind('click', result[0], $scope.ShowMessage)
            $('#ddlSearchDistrict option:first').attr('selected', 'selected');
        }
    }
    //--------------------------------------------------
    $scope.BindSearchStatus = function () {
        var TypeID = $('#ddlSearchType option:selected').val();
        if (TypeID > 0) {
            $scope.SearchStatuses = BrokerServices.RealEstateStausByType.query({ RealEstateTypeID: TypeID });
            $('#ddlSearchStatus').unbind('click');
        }
        else {
            $scope.SearchStatuses = null;
            var result = $.grep($scope.Messages, function (e) { return e.Type == "SelectStatusError"; });
            $('#ddlSearchStatus').bind('click', result[0], $scope.ShowMessage)
            $('#ddlSearchStatus option:first').attr('selected', 'selected');
        }
    }
    //--------------------------End: Search Event Handler-------------------------------//
    //-------------------------Begin:Show Message Event Handler-------------------------//
    $scope.ShowMessage = function (e) {
        $('.popUpTitle').text(e.data.Title);
        $('.popUpCnotent p').text(e.data.Message);
        $('.popUpContainer').show();
    }
    //-------------------------End:Show Message Event Handler--------------------------//
    //--------------------------Begin: Notify Event Handler-------------------------------//
    $scope.BindNotifyCities = function () {
        var CountryID = $('#ddlNotifyCountry option:selected').val();
        if (CountryID > 0) {
            $('#ddlNotifyCity').unbind('click');
            $scope.NotifyCities = BrokerServices.CitiesByCountry.query({ CountryID: CountryID });
            $scope.NotifyDistricts = null;
            var result = $.grep($scope.Messages, function (e) { return e.Type == "SelectDistrictError"; });
            $('#ddlNotifyDistrict').bind('click', result[0], $scope.ShowMessage);
            $('#ddlNotifyDistrict option:first').attr('selected', 'selected');
        }
        else {
            $scope.NotifyCities = null;
            $scope.NotifyDistricts = null;
            //SelectCityError
            var result = $.grep($scope.Messages, function (e) { return e.Type == "SelectCityError"; });
            $('#ddlNotifyCity').bind('click', result[0], $scope.ShowMessage);
            result = $.grep($scope.Messages, function (e) { return e.Type == "SelectDistrictError"; });
            $('#ddlNotifyDistrict').bind('click', result[0], $scope.ShowMessage);
            $('#ddlNotifyCity option:first').attr('selected', 'selected');
            $('#ddlNotifyDistrict option:first').attr('selected', 'selected');
        }
    }
    //---------------------------------------------------
    $scope.BindNotifyDistricts = function () {
        var CityID = $('#ddlNotifyCity option:selected').val();
        if (CityID > 0) {
            $('#ddlNotifyDistrict').unbind('click');
            $scope.NotifyDistricts = BrokerServices.DistrictsByCity.query({ CityID: CityID });
        }
        else {
            $scope.NotifyDistricts = null;
            var result = $.grep($scope.Messages, function (e) { return e.Type == "SelectDistrictError"; });
            $('#ddlNotifyDistrict').bind('click', result[0], $scope.ShowMessage);
            $('#ddlNotifyDistrict option:first').attr('selected', 'selected');
        }
    }
    //--------------------------End: Notify Event Handler--------------------------------//
    //---------------------------Begin: Search Button Event Handler-----------------------------//
    $scope.Search = function () {
        var Criteria = 1 + "/";
        Criteria += $("div .tabs .active").attr("value") + "/";
        var CriteriaText = "";//"نتيجة_البحث/";
        CriteriaText += $("div .tabs .active span").text() + "/";
        if ($('#ddlSearchType').val() != "" && $('#ddlSearchType').val() != null) {
            Criteria += $('#ddlSearchType').val() + "/";
            CriteriaText += $('#ddlSearchType option:selected').text() + "/";
        }
        else {
            Criteria += "0/";
        }
        if ($('#ddlSearchCountry').val() != "" && $('#ddlSearchCountry').val() != null) {
            Criteria += $('#ddlSearchCountry').val() + "/";
            CriteriaText += $('#ddlSearchCountry option:selected').text() + "/";
        }
        else {
            Criteria += "0/";
        }
        if ($('#ddlSearchCity').val() != "" && $('#ddlSearchCity').val() != null) {
            Criteria += $('#ddlSearchCity').val() + "/";
            CriteriaText += $('#ddlSearchCity option:selected').text() + "/";
        }
        else {
            Criteria += "0/";
        }
        if ($('#ddlSearchDistrict').val() != "" && $('#ddlSearchDistrict').val() != null) {
            Criteria += $('#ddlSearchDistrict').val() + "/";
            CriteriaText += $('#ddlSearchDistrict option:selected').text() + "/";
        }
        else {
            Criteria += "0/";
        }
        if ($('#ddlSearchPrice').val() != "" && $('#ddlSearchPrice').val() != null) {
            Criteria += $('#ddlSearchPrice').val() + "/";
            CriteriaText += $('#ddlSearchPrice option:selected').text() + "/";
        }
        else {
            Criteria += "0/";
        }
        if ($('#ddlSearchArea').val() != "" && $('#ddlSearchArea').val() != null) {
            Criteria += $('#ddlSearchArea').val() + "/";
            CriteriaText += $('#ddlSearchArea option:selected').text() + "/";
        }
        else {
            Criteria += "0/";
        }
        if ($('#ddlSearchStatus').val() != "" && $('#ddlSearchStatus').val() != null) {
            Criteria += $('#ddlSearchStatus').val() + "/";
            CriteriaText += $('#ddlSearchStatus option:selected').text() + "/";
        }
        else {
            Criteria += "0/";
        }
        if ($('#ddlSearchPaymentMethod').val() != "" && $('#ddlSearchPaymentMethod').val() != null) {
            Criteria += $('#ddlSearchPaymentMethod').val() + "/";
            CriteriaText += $('#ddlSearchPaymentMethod option:selected').text() + "/";
        }
        else {
            Criteria += "0/";
        }
        if ($('#ddlSearchCurrency').val() != "" && $('#ddlSearchCurrency').val() != null) {
            Criteria += $('#ddlSearchCurrency').val() + "/";
            CriteriaText += $('#ddlSearchCurrency option:selected').text() + "/";
        }
        else {
            Criteria += "0/";
        }
        // alert("test");
        var URL = '/نتيجة_البحث/' + Criteria + CriteriaText.replace(/ /g, '_');
        var Query = CriteriaText.replace(/\//g, ' ,');
        // var tmp=BrokerServices.SearchQuery.get({URL:decodeURI(URL).replace(/\//g, ';'),Query:decodeURI(Query).replace(/\//g, ';')});
        //window.location =URL;
        // PageMethods.AddToSiteMap(window.location.hostname+URL,Query, onError, onError);
        PageMethods.AddToSiteMap('http://www.aqarstock.com' + decodeURI(URL), Query, AddToSiteMapResult, AddToSiteMapResult);
        window.location = URL;
        // alert(Criteria+CriteriaText.replace(/ /g, '_'));
    }
    function AddToSiteMapResult(result) {
        console.log(result);
    }
    //---------------------------End: Search Button Event Handler------------------------------//
    //---------------------------Begin: Notify Button Event Handler------------------------------//

    $scope.SendNotifyRequest = function () {
        if ($scope.NotifyForm.$valid) {
            $("#btnNotify").attr("disabled", true);
            var Message = BrokerServices.NotifyRequest.save({}, JSON.stringify($scope.Notify), function () {
                var result = $.grep($scope.Messages, function (e) { return e.Type == "NotifyMessage"; });
                $('.popUpTitle').text(result[0].Title);
                $('.popUpCnotent p').text(result[0].Message);
                $('.popUpContainer').show();
                $("#btnNotify").attr("disabled", false);
            });
        }
    }
    //---------------------------End: Notify Button Event Handler-------------------------------//
    //----------------------------------- End:Event Handler Functions----------------------//
    //----------------------------------- Begin: Header Load Handler----------------------//
    $scope.LoadHeader = function () {
        PageMethods.CheckLogginStatus(onSucess, onError);
        $("#divAccountMenu").addClass('HideMenu');
    }
    function onSucess(result) {
        if (result == "None") {
            $("#divAccountSetting").hide();
            $("#liSignin").show();
        }
        else {
            $("#divUserName").text(result.split('/')[0]);
            $("#lPurchaseRequest").text(result.split('/')[1]);
            $("#divAccountSetting").show();
            $("#liSignin").hide();
        }
    }
    function onError(result) {
        //  alert("test");
    }
    //----------------------------------- End: Header Load Handler------------------------//
    //----------------------------------- Begin: Compare Menu Handler--------------------//
    $scope.CompareRealEstates = {};
    $scope.GetCompareList = function () {
        PageMethods.GetCompareList(onetCompareListSucess, onCompareError);
    }
    $scope.AddToCompareList = function (realestateId) {
        PageMethods.AddToCompareList(realestateId, onCompareSucess, onCompareError);
        PageMethods.GetCompareList(onetCompareListSucess, onCompareError);
    }
    $scope.RemoveFromCompareList = function (realestateId) {
        PageMethods.RemoveFromCompareList(realestateId, onRemoveFromCompareSucess, onCompareError);
    }
    $scope.GotoCompare = function () {
        window.location = "/قارن_الوحدات";
    }
    function onRemoveFromCompareSucess(result) {
        $scope.$apply(function () {
            $scope.CompareRealEstates = $scope.CompareRealEstates.filter(function (el) {
                return el.ID !== result;
            });
        });
        var lastId = $(".compareMenu ul li:last").attr('id');
        var firstId = $(".compareMenu ul li:first").attr('id');
        $('#' + result).remove();
        if (lastId == result && firstId == result) {
            $(".compareBtn").hide();
            $('.compareToggle').animate({ "right": "-350 px" })
        }
    }
    function onCompareSucess(result) {
        if (result == false) {
            var Message = $.grep($scope.Messages, function (e) { return e.Type == "CompareMaxError"; });
            $('.popUpTitle').text(Message[0].Title);
            $('.popUpCnotent p').text(Message[0].Message);
            $('.popUpContainer').show();
        }
    }
    function onCompareError(result) {
        var Message = $.grep($scope.Messages, function (e) { return e.Type == "Error"; });
        $('.popUpTitle').text(Message[0].Title);
        $('.popUpCnotent p').text(Message[0].Message);
        $('.popUpContainer').show();
    }
    function onetCompareListSucess(result) {

        if (result == null || result == "") {
            $("#divCompareBtn").hide();
        }
        else {
            $scope.$apply(function () {
                $scope.CompareRealEstates = result;
                $(".compareBtn").show();
            });
            var IH = window.innerHeight || document.documentElement.clientHeight || document.body.clientHeight;
            $(".compareBtn").css({ "margin-top": ((IH - parseInt($('.compareBtn').height(), 10)) / 2) + "px" });
            $scope.$watch(function (scope) { return $('.compareMenu').height(); },
              function (newValue, oldValue) {
                  //  alert(newValue+" , "+oldValue);
                  if (newValue == oldValue) {
                      $(".compareMenu").css({ "margin-top": ((IH - parseInt($('.compareMenu').height(), 10)) / 2) + "px" });
                  }
                  else {
                      if (newValue > oldValue) {
                          $(".compareMenu").css({ "margin-top": ((IH - parseInt((newValue - oldValue), 10)) / 2) + "px" });
                      }
                      else {
                          $(".compareMenu").css({ "margin-top": ((IH - parseInt($('.compareMenu').height(), 10)) / 2) + "px" });
                      }
                  }
              }
             );
        }
    }
    //----------------------------------- End: Compare Menu Handler-------------------------------------------//
    //----------------------------------- Begin: Advertisements-----------------------------------------------------//
   // MainAd[Math.floor(Math.random() * MainAd.length)];
    var Ads = BrokerServices.Ads.query({}, function () {
        $scope.FooterAd = Ads[Math.floor(Math.random() * Ads.length)];//FooterAd;
        $scope.SideAd = Ads[Math.floor(Math.random() * Ads.length)];//SideAd;
        if (Ads != null || Ads != "") {
        }
    });
    //var SideAd = BrokerServices.Ads.get({}, function () {
    //    $scope.SideAd = SideAd;
    //    if (SideAd != null || SideAd != "") {
    //    }
    //});
    //----------------------------------- End: Advertisements------------------------------------------------------//
});
//---------------------------------- End:Main Controller----------------------------------------------------------//

//---------------------------------- Begin:Banner Controller------------------------------------------------------//
brokerApp.controller('BannerController', function ($scope, $state, BrokerServices) {
    //--------------------------Begin: Bind Banner Project Lis---------------------------//
    var bannerProjects = BrokerServices.BannerProjects.query({}, function () {
        $scope.BannerProjects = bannerProjects[Math.floor(Math.random() * bannerProjects.length)];//bannerProjects;
        if (bannerProjects != null || bannerProjects != "") {
            //        var IW = window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;
            //            $('.sliderBehind .viewport ul').width(IW * bannerProjects.length);
            //            $scope.ProjectName=bannerProjects[0].ProjectName;
            //            setTimeout(function () { fadeSlider($('.sliderBehind .viewport ul li:first-child')) });
        }
        if (window.matchMedia('(max-width: 780px)').matches) {
            //   $(".searchArea").css("min-height", "60px");
            $("#divSearch").remove();
            $("#MobileSearch").remove();
            $('.searchIcon').unbind('click');
            $('.searchIcon').click(function () {
                $(window).scrollTop($(".bottomBar").offset().top);
            });
        }
        else {

            $("#divMobileSearch").remove();
        }
    });
    //--------------------------End: Bind Banner Project List ---------------------------//
    //---------------------------Begin: Fade Affect Method--------------------------------//
    function fadeSlider(slide) {
        // console.log(0);
        var id = $(slide).attr("id");
        var result = $.grep($scope.BannerProjects, function (e) { return e.ID == id; });
        $scope.$apply(function () {
            $scope.ProjectName = result[0].ProjectName;//$scope.BannerProjects[slide.index()].ProjectName;
            $scope.ProjectURL = "/مشاريع_عقارية/" + result[0].ID + "/" + result[0].URL;
        });
        //200
        slide.fadeIn(2000).delay(6000).queue(function () {
            slide.fadeOut(2000);
            // slide.hide();
            slide.remove();
            $('.sliderBehind .viewport ul li:last-child').after(slide);
            setTimeout(function () { fadeSlider($('.sliderBehind .viewport ul li:first-child')) });
        });
    }
    //---------------------------End: Fade Affect Method---------------------------------//
});
//---------------------------------- End:Banner Controller-------------------------------------------------------//

//--------------------------------- Begin:HomePage Controller------------------------------------------------------//
brokerApp.controller('HomePageController', function ($scope, $state, BrokerServices) {
    //---------------------- Main Ad-----------------------------------------------//
    var MainAd = BrokerServices.Ads.query({}, function () 
    {
        $scope.MainAd = MainAd[Math.floor(Math.random() * MainAd.length)];//MainAd;
        if (MainAd != null || MainAd != "") {
        }
    });
    //--------------------------Begin: Bind Project List -------------------------------//
    $scope.Projects = BrokerServices.HomePageProjects.query({});
    //--------------------------End: Bind Project List --------------------------------//
    //---------------------------Begin: Bind Properties List---------------------------//
    //-------------------------Begin: Bind Special Offer List--------------------------//
    var SpecialOfferCriteria = {};
    //SpecialOfferCriteria.PageSize = 3;
    //SpecialOfferCriteria.PageIndex =1;
    SpecialOfferCriteria.IsSpecialOffer = true;
    var Offers = BrokerServices.SpecialRealEstates.query({ PageIndex: 1, PageSize: 100 }, function () {
        var SOffers = new Array(3);
        SOffers[0] = Offers[Math.floor(Math.random() * Offers.length)];
        Offers.splice(Offers.indexOf(SOffers[0]), 1);
        SOffers[1] = Offers[Math.floor(Math.random() * Offers.length)];
        Offers.splice(Offers.indexOf(SOffers[1]), 1);
        SOffers[2] = Offers[Math.floor(Math.random() * Offers.length)];
        $scope.Offers = SOffers;
        if (Offers == "" || Offers == null) {
            // $('#divEmpty').show();
        }
    });
    //-------------------------End: Bind Special Offer List---------------------------//
    //-------------------------Begin:Bind For Sale Properties List-------------------//
    $scope.ForSalePropsIndex = 1;
    $scope.ForSaleNewPageFlag = true;
    //       var size= $("#divSoldLoader").width()/( $('#divSoldLoader .viewport li').width());
    //     alert(size);
    var ForSaleProps = BrokerServices.LatestRealEstatesBySaleType.query({ SaleType: 1, PageIndex: $scope.ForSalePropsIndex, PageSize: 4 }, function () {
        $scope.ForSaleRealEstates = ForSaleProps;

        if (ForSaleProps != "" && ForSaleProps != null) {
            $("#divSoldLoader").hide();
        }
    });
    //-------------------------End:Bind For Sale Properties List--------------------//
    //-------------------------Begin:Bind For Rent Properties List-------------------//
    $scope.ForRentPropsIndex = 1;
    $scope.ForRentNewPageFlag = true;
    var ForRentProps = BrokerServices.LatestRealEstatesBySaleType.query({ SaleType: 2, PageIndex: $scope.ForRentPropsIndex, PageSize: 4 }, function () {
        $scope.ForRentRealEstates = ForRentProps;
        if (ForRentProps != "" && ForRentProps != null) {
            $("#divRentLoader").hide();
        }
    });
    //-------------------------End:Bind For Rent Properties List--------------------//
    //---------------------------End: Bind Properties List-----------------------------------//
    //------------------------------------ Begin: Event Handler Functions--------------------//
    //--------------------------Begin: For Sale Properties Handlers---------------------//
    $scope.GetNextForSaleProps = function () {
        $("#divSoldLoader").show();
        //$("#btnForSaleNext").attr("disabled",true);
        var slider = $("#ForSaleSlider");
        var PageSize = 4;
        $scope.ForSalePropsIndex = $scope.ForSalePropsIndex + 1

        var LastIndex = $('.viewport li', slider).length / PageSize;
        if ($scope.ForSalePropsIndex > LastIndex) {
            var ForSaleProps = BrokerServices.LatestRealEstatesBySaleType.query({ SaleType: 1, PageIndex: $scope.ForSalePropsIndex, PageSize: PageSize }, function () {
                var last = PageSize * $scope.ForSalePropsIndex;
                Array.prototype.splice.apply($scope.ForSaleRealEstates, [last + 1, 0].concat(ForSaleProps));
                if (ForSaleProps != "" && ForSaleProps != null) {
                    $('.viewport li', slider).hide();//.css('display','none');
                    var end = ($scope.ForSalePropsIndex * PageSize) - 1;
                    var start = end - PageSize;
                    $("#divSoldLoader").hide();
                }
            });
        }
        else {
            $("#divSoldLoader").hide();
            $('.viewport li', slider).hide();//.css('display','none');
            var end = ($scope.ForSalePropsIndex * PageSize) - 1;
            var start;
            start = end - PageSize;
            // alert(end);
            $('.viewport li:eq(' + (start) + ')', slider).nextUntil('.viewport li:gt(' + end + ')', slider).show()
        }
    }
    //-----------------------------------------
    $scope.GerPreviousForSaleProps = function () {
        var slider = $("#ForSaleSlider");
        $scope.ForSalePropsIndex = $scope.ForSalePropsIndex - 1;
        if ($scope.ForSalePropsIndex > 0) {
            var PageSize = 4;
            $('.viewport li', slider).hide();//.css('display','none');
            var end = ($scope.ForSalePropsIndex * PageSize) - 1;
            var start;
            start = end - PageSize;
            //  alert(end+","+start);
            $('.viewport li:eq(' + (end) + ')', slider).prevUntil('.viewport li:eq(' + start + ')', slider).show();
            $('.viewport li:eq(' + (end) + ')', slider).show();
        }
        else {
            $scope.ForSalePropsIndex = 1;
        }
    }
    //--------------------------End: For Sale Properties Handlers----------------------//
    //--------------------------Begin: For Rent Properties Handlers----------------------//
    $scope.GetNextForRentProps = function () {
        $("#divRentLoader").show();
        //$("#btnForSaleNext").attr("disabled",true);
        var slider = $("#ForRentSlider");
        var PageSize = 4;
        $scope.ForRentPropsIndex = $scope.ForRentPropsIndex + 1

        var LastIndex = $('.viewport li', slider).length / PageSize;
        if ($scope.ForRentPropsIndex > LastIndex) {
            var ForSaleProps = BrokerServices.LatestRealEstatesBySaleType.query({ SaleType: 2, PageIndex: $scope.ForRentPropsIndex, PageSize: PageSize }, function () {
                var last = PageSize * $scope.ForRentPropsIndex;
                Array.prototype.splice.apply($scope.ForRentRealEstates, [last + 1, 0].concat(ForSaleProps));
                if (ForSaleProps != "" && ForSaleProps != null) {
                    $('.viewport li', slider).hide();//.css('display','none');
                    //                        var end=($scope.ForRentPropsIndex* PageSize)-1;
                    //                        var start=end-PageSize;
                    $("#divRentLoader").hide();
                }
            });
        }
        else {
            $("#divRentLoader").hide();
            $('#ForRentSlider .viewport li').hide();//.css('display','none');
            var end = ($scope.ForRentPropsIndex * PageSize) - 1;
            var start;
            start = end - PageSize;
            // alert(end);
            $('#ForRentSlider .viewport li:eq(' + (start) + ')').nextUntil('#ForRentSlider .viewport li:gt(' + end + ')').show()
        }
    }
    //------------------------------------------------------
    $scope.GerPreviousForRentProps = function () {
        var slider = $("#ForRentSlider");
        $scope.ForRentPropsIndex = $scope.ForRentPropsIndex - 1;
        if ($scope.ForRentPropsIndex > 0) {
            var PageSize = 4;
            $('#ForRentSlider .viewport li').hide();//.css('display','none');
            var end = ($scope.ForRentPropsIndex * PageSize) - 1;
            var start;
            start = end - PageSize;
            //  alert(end+","+start);
            $('#ForRentSlider .viewport li:eq(' + (end) + ')').prevUntil('#ForRentSlider .viewport li:eq(' + start + ')').show();
            $('#ForRentSlider .viewport li:eq(' + (end) + ')').show();
        }
        else {
            $scope.ForRentPropsIndex = 1;
        }

    }
    //------------------- -------End: For Rent Properties Handlers------------------------//
    //----------------------------------- End:Event Handler Functions----------------------// 

});
//----------------------------- End:HomePage Controller---------------------------------------------------//
//--------------------------------- Begin:Property List Controller----------------------------------------//
brokerApp.controller('PropertyListController', function ($scope, $state, BrokerServices) {
    var Query = decodeURI(window.location.pathname);
    var Parameters = Query.split('/');
    $scope.PageIndex = Parameters[2];
    if ($scope.PageIndex > 2) {
        $(".firstOne").show();
        $("#divFirstPage").show();
    }
    var IsPostBack = false;
    var PageSize = 10;

    $scope.FirstPage = 1;
    if (Parameters[1] == "نتيجة_البحث") {
        $scope.ListTitle = "نتيجة البحث";
        // var tmp=BrokerServices.SearchQuery.get({URL:decodeURI(window.location).replace(/\//g, ';'),Query:decodeURI(Query).replace(/\//g, ';')});
        //    PageMethods.AddToSiteMap(decodeURI(window.location),Query,AddToSiteMapResult, AddToSiteMapResult);
        GetSearchResult();
    }
    if (Parameters[1] == "عروض_مميزة") {
        $scope.ListTitle = "عروض عقار ستوك المميزة";
        GetSpecialOffer();
    }
    if (Parameters[1] == "وحدات") {
        $scope.ListTitle = Parameters[1] + " " + Parameters[3];
        GetPropertyListBySaleType();
    }
    if (Parameters[1] == "الفئة") {
        $scope.ListTitle = Parameters[3].replace('_', ' ');
        GetPropertyListByCategory();
    }
    if (Parameters[1] == "آخر_الوحدات_المضافة") {
        $scope.ListTitle = Parameters[1].replace(/_/g, ' ');
        GetLatestProperties();
    }
    if (Parameters[1] == "كلمات_البحث") {
        $scope.ListTitle = Parameters[Parameters.length - 1].replace(/_/g, ' ');;
        GetSearchResult();
    }
    //-------------------Begin: Event Handler--------------------------//
    $scope.MoveTo = function (PageIndex) {
        $('.resultItems .item').remove();
        $("#divListLoading").show();
        IsPostBack = true;
        window.scrollTo(0, 0);
        $scope.PageIndex = PageIndex;
        Parameters[2] = PageIndex;
            $(".numbers li").removeClass("active");
            $("#" + PageIndex).addClass("active");
        if ($scope.LastPage > 5) {
            if (PageIndex >= 3) {
                $("#" + PageIndex).show();
                $(".firstOne").show();
                $("#divFirstPage").show();
                if (PageIndex < $scope.LastPage) {
                    $(".numbers li").hide();
                    $(".numbers li:lt(" + (PageIndex - 1) + ")").hide();
                    $("#" + (PageIndex - 1)).nextUntil("#" + (PageIndex + 3)).show();
                }
                else {
                    $(".numbers li:lt(" + (PageIndex - 1) + ")").hide();
                    $("#" + PageIndex).prevUntil("#" + (PageIndex - 3)).show();
                }
            }
            else {
                $(".numbers li").hide();
                $(".numbers li:lt(5)").show();
                $(".firstOne").hide();
                $("#divFirstPage").hide();
            }
        }
        if (Parameters[1] == "نتيجة_البحث") {
            GetSearchResult();
        }
        if (Parameters[1] == "عروض_مميزة") {
            GetSpecialOffer();
        }
        if (Parameters[1] == "وحدات") {
            GetPropertyListBySaleType();
        }
        if (Parameters[1] == "الفئة") {
            GetPropertyListByCategory();
        }
        if (Parameters[1] == "آخر_الوحدات_المضافة") {
            GetLatestProperties();
        }
        if (Parameters[1] == "كلمات_البحث") {
            GetSearchResult();
        }
        window.history.pushState("Page" + PageIndex, "Page" + PageIndex, Parameters.join('/'));
    }
    $scope.NextPage = function () {
        var LastPage = $(".numbers li:last").attr("id");
        if ($scope.PageIndex < LastPage) {
            $scope.MoveTo(parseInt($scope.PageIndex) + 1);
        }
    }
    $scope.PreviousPage = function () {
        var FirstPage = $(".numbers li:first").attr("id");
        if ($scope.PageIndex > FirstPage) {
            $scope.MoveTo(parseInt($scope.PageIndex) - 1);
        }
    }
    //-------------------End: Event Handler-------------------------------//
    function AddToSiteMapResult(result) {
        console.log(result);
    }
    function GetLatestProperties() {
        var Criteria = {};
        Criteria.PageSize = PageSize;
        Criteria.PageIndex = $scope.PageIndex;
        var realestates = BrokerServices.RealEstates.query({ PageIndex: $scope.PageIndex, PageSize: PageSize }, function () {
            $scope.realEstates = realestates;
            if (realestates == "" || realestates == null) {
            }
            $("#divListLoading").hide();
        });
        if (IsPostBack == false) {
            var count = BrokerServices.CountRealEstates.query({ PageSize: PageSize }, function () {
                if (count.length > 1) {
                    $scope.Pages = count;
                    $scope.LastPage = count[count.length - 1];
                    if ($scope.LastPage <= 5) {
                        $("#divLastPage").css("display", "none");
                        $(".lastOne").css("display", "none");
                    }
                }
                else {
                    $(".pageController").css("display", "none");
                }
            });
        }
    }
    function GetPropertyListByCategory() {
        var Criteria = {};
        //Criteria.PageSize = PageSize;
        //Criteria.PageIndex = $scope.PageIndex;
        //Criteria.RealEstateCategoryID = Parameters[4];
        var realEstates = BrokerServices.RealEstatesByCategory.query({ Category: Parameters[4], PageIndex: $scope.PageIndex, PageSize: PageSize }, function () {
            $scope.realEstates = realEstates;
            $("#divListLoading").hide();
            if (realEstates == "" || realEstates == null) {
                // $('#divEmpty').show();
            }
        });
        if (IsPostBack == false) {
            var count = BrokerServices.CountRealEstatesByCategory.query({ Category: Parameters[4], PageSize: PageSize }, function () {
                if (count.length > 1) {
                    $scope.Pages = count;
                    $scope.LastPage = count[count.length - 1];
                    if ($scope.LastPage <= 5) {
                        $("#divLastPage").css("display", "none");
                        $(".lastOne").css("display", "none");
                    }
                }
                else {
                    $(".pageController").css("display", "none");
                }
            });
        }
    }
    function GetPropertyListBySaleType() {
        //var Criteria = {};
        //Criteria.PageSize = PageSize;
        //Criteria.PageIndex = $scope.PageIndex;
        //Criteria.SaleTypeID = Parameters[4];
        var realEstates = BrokerServices.RealEstatesBySaleType.query({SaleType:Parameters[4],PageIndex:$scope.PageIndex,PageSize:PageSize}, function () {
            $scope.realEstates = realEstates;
            $("#divListLoading").hide();
            if (realEstates == "" || realEstates == null) {
                // $('#divEmpty').show();
            }
        });
        if (IsPostBack == false) {
            var count = BrokerServices.CountRealEstatesBySaleType.query({SaleType:Parameters[4],PageSize:PageSize}, function () {
                if (count.length > 1) {
                    $scope.Pages = count;
                    $scope.LastPage = count[count.length - 1];
                    if ($scope.LastPage <= 5) {
                        $("#divLastPage").css("display", "none");
                        $(".lastOne").css("display", "none");
                    }
                }
                else {
                    $(".pageController").css("display", "none");
                }
            });
        }
    }
    function GetSpecialOffer() {
        //var SpecialOfferCriteria = {};
        //SpecialOfferCriteria.PageSize = PageSize;
        //SpecialOfferCriteria.PageIndex =$scope.PageIndex;
        //SpecialOfferCriteria.IsSpecialOffer=true;
        var Offers = BrokerServices.SpecialRealEstates.query({ PageIndex: $scope.PageIndex, PageSize: PageSize }, function () {
            $scope.realEstates = Offers;
            $("#divListLoading").hide();
            if (Offers == "" || Offers == null) {
                // $('#divEmpty').show();
            }
        });
        if (IsPostBack == false) {
            var count = BrokerServices.CountSpecialRealEstates.query({ PageSize: PageSize }, function () {
                if (count.length > 1) {
                    $scope.Pages = count;
                    $scope.LastPage = count[count.length - 1];
                    if ($scope.LastPage <= 5) {
                        $("#divLastPage").css("display", "none");
                        $(".lastOne").css("display", "none");
                    }
                }
                else {
                    $(".pageController").css("display", "none");
                }
            });
        }
    }
    function GetSearchResult() {
        var SearchCriteria = {};
        SearchCriteria.PageSize = PageSize;
        SearchCriteria.PageIndex = $scope.PageIndex;//Parameters[2];
        SearchCriteria.SaleTypeID = Parameters[3];
        SearchCriteria.RealEstateTypeID = Parameters[4];
        SearchCriteria.CountryID = Parameters[5];
        SearchCriteria.CityID = Parameters[6];
        SearchCriteria.DistrictID = Parameters[7];
        SearchCriteria.Price = Parameters[8];
        SearchCriteria.Area = Parameters[9];
        SearchCriteria.RealEstateStatusID = Parameters[10];
        SearchCriteria.PaymentTypeID = Parameters[11];
        SearchCriteria.CurrencyID = Parameters[12];
        var realestates = BrokerServices.Search.query({
            PageSize: SearchCriteria.PageSize, PageIndex: SearchCriteria.PageIndex, SaleType: SearchCriteria.SaleTypeID
            ,Type: SearchCriteria.RealEstateTypeID, Status: SearchCriteria.RealEstateStatusID, Country: SearchCriteria.CountryID, City: SearchCriteria.CityID
            ,District:SearchCriteria.DistrictID,Area:SearchCriteria.Area,Price:SearchCriteria.Price,PaymentType:SearchCriteria.PaymentTypeID,Currency:SearchCriteria.CurrencyID }, function () {
            $scope.realEstates = realestates;
            $("#divListLoading").hide();
            if (realestates == "" || realestates == null) {
                //  $('#divEmpty').show();
            }
            //    $('#divloading').hide();
        });
        if (IsPostBack == false) {
            var count = BrokerServices.CountResult.query({PageSize: SearchCriteria.PageSize, SaleType: SearchCriteria.SaleTypeID, Type: SearchCriteria.RealEstateTypeID, Status: SearchCriteria.RealEstateStatusID, Country: SearchCriteria.CountryID, City: SearchCriteria.CityID, District: SearchCriteria.DistrictID, Area: SearchCriteria.Area, Price: SearchCriteria.Price, PaymentType: SearchCriteria.PaymentTypeID, Currency: SearchCriteria.CurrencyID}, function () {
                if (count.length > 1) {
                    $scope.Pages = count;
                    $scope.LastPage = count[count.length - 1];
                    if ($scope.LastPage <= 5) {
                        $("#divLastPage").css("display", "none");
                        $(".lastOne").css("display", "none");
                    }
                }
                else {
                    $(".pageController").css("display", "none");
                }
            });
        }

        //    var index=Parameters.indexOf("نتيجة_البحث");
        //    var Title="نتيجة_البحث  عن: ";
        //    for (i=index+1;i<Parameters.length-1;i++)
        //    {
        //    Title+=Parameters[i]+"- ";
        //    }
        //   // alert(Title);
        //   $scope.ListTitle=Title.replace(/_/g, ' ').slice(0,Title.lastIndexOf('-'));
        // alert(Parameters[2]);
    }
});
//--------------------------------- End:Property List Controller----------------------------------------//
//--------------------------------- Begin:New Added Properties Controller------------------------------//
brokerApp.controller('LastAddedPropertiesController', function ($scope, $state, BrokerServices) {
    var realestates = BrokerServices.RealEstates.query({ PageIndex: 1, PageSize: 5 }, function () {
        $scope.LastAddedrealEstates = realestates;
        if (realestates == "" || realestates == null) {
            //  $('#divEmpty').show();
        }
        //    $('#divloading').hide();
    });
});
//--------------------------------- End:New Added Properties Controller-------------------------------//
//--------------------------------- Begin: Property Detail  Controller------------------------------//
brokerApp.controller('PropertDetailController', function ($scope, $state, BrokerServices) {
    $scope.ID = $('#hdnID').val();
    $scope.Name = $('#lblTitle').text();
    $scope.URL = $('#hdnID').val() + "/" + $('#hdnURL').val();
    //---------------------Begin: Fill Criteria List----------------------------------//
    var crteria = BrokerServices.RealEstateCriterias.query({ RealEstateID: $scope.ID }, function () {
        $scope.Criterias = crteria;
    });
    //---------------------End: Fill Criteria List----------------------------------//
    //--------------------Begin: Even Handlers----------------------------------------//
    $scope.ShowPhotos = function () {
        // $("#divDetail").hide();
        $state.go('gallery');
    }
    $scope.ShowRequest = function () {
        $state.go('request');
    }
    $scope.ShowComplain = function () {
        $state.go('complain');
    }
    $scope.ShowOwnerData = function () {
        $scope.SubscriberID = $('#hdnSubscriberID').val();
        $(".owner").attr("disabled", true);
        var Message = BrokerServices.CheckLogin.save({}, function () {
            var r = Message.CheckLoginResult;
          //  alert(r);
            if (r != "true") {
                $('.popUpCnotent p').empty();
                var result = $.grep($scope.Messages, function (e) { return e.Type == "ShowOwnerData"; });
                $('.popUpTitle').text(result[0].Title);
                $('.popUpCnotent p').text(result[0].Message);
                $('.popUpContainer').show();
                $state.go('UserData');
            }
            else {
                $state.go('OwnerData');
            }
        });
  
    }
    $scope.BackToDetail = function () {
        $("#divDetail").show();
        $(".projectBtns").show();
        $(".projectControl").show();
    }
    //--------------------End: Even Handlers----------------------------------------//
});
//--------------------------------- End: Property Detail  Controller---------------------------------//
//--------------------------------- Begin: Property Gallery  Controller------------------------------//
brokerApp.controller('GalleryController', function ($scope, $state, BrokerServices) {
    $("#divDetail").hide();
    var fadeSliderMark;
    var photos = BrokerServices.RealEstatePhotos.query({ RealEstateID: $scope.ID }, function () {
        $scope.Photos = photos;
        if (photos.length <= 1) {
            $("#divSlidetBtn").hide();
        }
        fadeSliderMark = setTimeout(function () { fadeSlider($('.slider .viewPort ul li:first-child')) });
        //  $('#divloading').hide();
    });
    //----------------------------Begin: Event Handler---------------------------------------------//

    $scope.Next = function () {
        clearTimeout(fadeSliderMark);
        slide = $('.slider .viewPort ul li:first-child');
        slide.hide();
        slide.remove();
        $('.slider .viewPort ul li:last-child').after(slide);
        fadeSliderMark = setTimeout(function () { fadeSlider($('.slider .viewPort ul li:first-child')) });
    }
    $scope.Previous = function () {
        clearTimeout(fadeSliderMark);
        slide = $('.slider .viewPort ul li:not(:last-child)');
        slide.hide();
        slide.remove();
        $('.slider .viewPort ul li:last-child').after(slide);
        fadeSliderMark = setTimeout(function () { fadeSlider($('.slider .viewPort ul li:first-child')) });
    }
    //-----------------------------------------------
    function fadeSlider(slide) {
        slide.fadeIn(1000).delay(6000).queue(function () {
            if ($('.slider .viewPort ul li').length > 1) {
                slide.fadeOut(1000);
                slide.remove();
                $('.slider .viewPort ul li:last-child').after(slide);
                fadeSliderMark = setTimeout(function () { fadeSlider($('.slider .viewPort ul li:first-child')) });
            }
        });
    }
    //-----------------------------End: Event Handler----------------------------------------------//

});
//--------------------------------- End: Property Gallery  Controller---------------------------------//
//--------------------------------- Begin: Property Request  Controller---------------------------------//
brokerApp.controller('RequestController', function ($scope, BrokerServices, $state) {
    window.scrollTo(0, 0);
    $("#divDetail").hide();
    $(".projectBtns").hide();
    $(".projectControl").hide();
    $scope.Request = {};
    $scope.Request.RealEstateID = $scope.ID;
    $scope.SendRequest = function () {
        if ($scope.RequestForm.$valid) {    
            //  alert("true");
            $("#btnSend").attr("disabled", true);
            var Message = BrokerServices.PurchaseRequest.save({}, JSON.stringify($scope.Request), function () {
                var result = $.grep($scope.Messages, function (e) { return e.Type == "RequestMessage"; });
                $('.popUpTitle').text(result[0].Title);
                $('.popUpCnotent p').text(result[0].Message);
                $('.popUpContainer').show();
                $("#btnSend").attr("disabled", false);
            });
        }
    }

});
brokerApp.controller('UserDataController', function ($scope, BrokerServices, $state) {
    window.scrollTo(0, 0);
    $("#divDetail").hide();
    $(".projectBtns").hide();
    $(".projectControl").hide();
    $scope.Request = {};
    $scope.Request.RealEstateID = $scope.ID;
    $scope.login = {};
    $scope.login.RealEstateID = $scope.ID;
    $scope.SendRequest = function () {
        if ($scope.UserDataForm.$valid) {
            //  alert("true");
            $("#btnRegister").attr("disabled", true);
            //var contact = {};
            //contact.Email= $scope.Request.Email;
            //contact.Phone=$scope.Request.Phone;
            var Message = BrokerServices.ValidateContactData.save({}, JSON.stringify($scope.Request), function () {
                // console.log(Message.ValidateContactDataResult);
                var r = Message.ValidateContactDataResult;
                if (r.indexOf("Error:") >= 0) {
                    //  var result = $.grep($scope.Messages, function (e) { return e.Type == "CodeNotMatch"; });
                    $('.popUpTitle').text("عفوا");
                    $('.popUpCnotent p').text(r.replace("Error:", ""));
                    $('.popUpContainer').show();
                    $("#btnRegister").attr("disabled", false);
                }
                else {
                    $state.go('ValidateContact', { Code: r, Request: $scope.Request });
                }
            });
        }
    }
    $scope.Login = function () {
        //alert("test");
        if ($scope.LoginForm.$valid) {
            
            $("#btnlogin").attr("disabled", true);
            var Message = BrokerServices.Login.save({}, JSON.stringify($scope.login), function () {
                var r = Message.LoginResult;
              //  alert(r.indexOf("Error:"));
                if(r.indexOf("Error:")>=0)
                {
                  //  var result = $.grep($scope.Messages, function (e) { return e.Type == "CodeNotMatch"; });
                    $('.popUpTitle').text("عفوا");
                    $('.popUpCnotent p').text(r.replace("Error:",""));
                    $('.popUpContainer').show();
                    $("#btnlogin").attr("disabled", false);
                }
                else
                {
                    $state.go('OwnerData');
                }
            });
        }
    }

});
brokerApp.controller('ValidateContactController', function ($scope, BrokerServices, $state, $stateParams) {
    //var v = "yuy";
    //v
    console.log($stateParams.Code);
    window.scrollTo(0, 0);
    $("#divDetail").hide();
    $(".projectBtns").hide();
    $(".projectControl").hide();
    $scope.ReSendCode = function () {
     //   alert("ii");
        var contact = {};
        contact.Email = $stateParams.Request.Email;
        contact.Phone = $stateParams.Request.Phone;
        var Message = BrokerServices.ValidateContactData.save({}, JSON.stringify(contact), function () {
            console.log(Message.ValidateContactDataResult);
            $state.go('ValidateContact', { Code: Message.ValidateContactDataResult, Request: $stateParams.Request });
        });
    }
    $scope.SendRequest = function () {
       // alert($stateParams.Code.toString().replace(/"/g, "") + " - " + $scope.CodeEntry)
        if ($stateParams.Code.toString().replace(/"/g, "") == $scope.CodeEntry) {
            //alert("success");
            ////  alert("true");
            $("#btnSendInduiry").attr("disabled", true);
            var Message = BrokerServices.InqueryRequest.save({}, JSON.stringify($stateParams.Request), function () {
                // $stateParams = { ID: ID };
                $state.go('OwnerData');
                //var result = $.grep($scope.Messages, function (e) { return e.Type == "RequestMessage"; });
                //$('.popUpTitle').text(result[0].Title);
                //$('.popUpCnotent p').text(result[0].Message);
                //$('.popUpContainer').show();
                //$("#btnSend").attr("disabled", false);
            });
        }
        else {
            var result = $.grep($scope.Messages, function (e) { return e.Type == "CodeNotMatch"; });
            $('.popUpTitle').text(result[0].Title);
            $('.popUpCnotent p').text(result[0].Message);
            $('.popUpContainer').show();
            $("#btnSend").attr("disabled", false);
        }
        
        
    }

});
brokerApp.controller('OwnerDataController', function ($scope, BrokerServices, $state) {
    window.scrollTo(0, 0);
    $("#divDetail").hide();
    $(".projectBtns").hide();
    $(".projectControl").hide();
    var Model = BrokerServices.RealEstateOwner.get({ ID: $scope.ID }, function () {
        $scope.Model = Model;
        //$("#divModelDetailsLoading").hide();
        if (Model == "" || Model == null) {
            //  $('#divProjectPhotos').hide();
        }
    });
});
//--------------------------------- End: Property Request  Controller----------------------------------//
//----------------------------------Begin:Complain Controller-----------------------------------------//
brokerApp.controller('ComplainController', function ($scope, BrokerServices, $state) {
    window.scrollTo(0, 0);
    $("#divDetail").hide();
    $(".projectBtns").hide();
    $(".projectControl").hide();
    $scope.Complain = {};
    $scope.Complain.RealEstateID = $scope.ID;
    $scope.SendComplain = function () {
        if ($scope.ComplainForm.$valid) {
            $("#btnSend").attr("disabled", true);
            var Message = BrokerServices.SendComplain.save({}, JSON.stringify($scope.Complain), function () {
                var result = $.grep($scope.Messages, function (e) { return e.Type == "ComplainMessage"; });
                $('.popUpTitle').text(result[0].Title);
                $('.popUpCnotent p').text(result[0].Message);
                $('.popUpContainer').show();
                $("#btnSend").attr("disabled", false);
            });
        }
    }
});
//----------------------------------------End:Complain Controller-------------------------------------------//
//--------------------- Begin: Master Controller----------------------------//
brokerApp.controller('MasterController', function ($scope, $state, BrokerServices) {
    //-------------Begin: Static Variables----------------------------------------------------//
    PageMethods.set_path('../../Backend/SubScriber/SubscriberDashBoard.aspx')
    $scope.BaseURl = "../..";
    //----------------------------------- Begin: Header Load Handler----------------------//
    $scope.LoadHeader = function () {
        PageMethods.CheckLogginStatus(onSucess, onError);
    }
    function onSucess(result) {
        if (result == "None") {
            $("#divAccountSetting").hide();
            $("#liSignin").show();
        }
        else {
            $("#divUserName").text(result.split('/')[0]);
            $("#lPurchaseRequest").text(result.split('/')[1]);
            $("#divAccountSetting").show();
            $("#liSignin").hide();
        }
    }
    function onError(result) {
        //  alert("test");
    }
    //----------------------------------- End: Header Load Handler------------------------//
});
//--------------------- Begin: Master Controller----------------------------//
//----------------------------------Begin:Contact Us Controller-----------------------------------------//
brokerApp.controller('ContactusController', function ($scope, BrokerServices, $state) {
    //window.scrollTo(0,0);
    $scope.Contactus = {};
    $scope.Contactus.RealEstateID = $scope.ID;
    $scope.SendMessage = function () {
        if ($scope.ContactForm.$valid) {
            $("#btnSend").attr("disabled", true);
            var Message = BrokerServices.Contactus.save({}, JSON.stringify($scope.Contactus), function () {
                var result = $.grep($scope.Messages, function (e) { return e.Type == "ContactusMessage"; });
                $('.popUpTitle').text(result[0].Title);
                $('.popUpCnotent p').text(result[0].Message);
                $('.popUpContainer').show();
                $("#btnSend").attr("disabled", false);
            });
        }
    }

});
//----------------------------------------End:ContactUs Controller-------------------------------------------//
//----------------------------------Begin:Compare Controller-----------------------------------------//
brokerApp.controller('CompareController', function ($scope, BrokerServices) {
    PageMethods.GetCompareList(onetCompareListSucess, onCompareError);
    $scope.RemoveFromComparingList = function (realestateId) {
        PageMethods.RemoveFromCompareList(realestateId, onRemoveFromCompareSucess, onCompareError);
    }
    function onCompareError(result) {
        var Message = $.grep($scope.Messages, function (e) { return e.Type == "Error"; });
        $('.popUpTitle').text(Message[0].Title);
        $('.popUpCnotent p').text(Message[0].Message);
        $('.popUpContainer').show();
    }
    function onetCompareListSucess(result) {
        $scope.realEstates = result;

    }
    function onRemoveFromCompareSucess(result) {
        $('#' + result).remove();
        var titlesWidth = $(".compareBox .compareFactors").width();
        var totalWidth = $(".compareBox").width();
        var Count = $('.compareBox .compareProjects').length;
        var width = (totalWidth - titlesWidth) / Count;
        $('.compareProjects').width(width);
        $('.compareProjects  > *').height('auto');
        $('.compareFactors  > *').height('auto');
        $('.compareBox').each(function () {
            var compareBox = $(this);
            var compareFactorsCount = $('.compareFactors > *', compareBox).length;
            for (i = 0; i < compareFactorsCount; i++) {
                var maxCellHeight = 0;
                $('> *', compareBox).each(function () {
                    maxCellHeight = Math.max(parseInt($('> *:eq(' + i + ')', $(this)).height(), 10), maxCellHeight);
                    window.console.log(maxCellHeight);
                });
                $('> *', compareBox).each(function () {
                    $('> *:eq(' + i + ')', $(this)).height(maxCellHeight);
                });
            }
        });
    }
});
//----------------------------------------End:Compare Controller-------------------------------------------//
//----------------------------------Begin:Company List Controller-----------------------------------------//
brokerApp.controller('CompanyListController', function ($scope, BrokerServices) {
    var Query = decodeURI(window.location.pathname);
    var Parameters = Query.split('/');
    $scope.PageIndex = Parameters[2];
    //alert(Parameters[2]);
    var PageSize = 10;
    if ($scope.PageIndex > 2) {
        $(".firstOne").show();
        $("#divFirstPage").show();
    }
    $scope.FirstPage = 1;
    var Companies = BrokerServices.Companies.query({ PageIndex: $scope.PageIndex, PageSize: PageSize }, function () {
        $scope.Companies = Companies;
        if (Companies == "" || Companies == null) {
            //  $('#divEmpty').show();
        }
        //    $('#divloading').hide();
        $("#divListLoading").hide();
    });

    var count = BrokerServices.CompaniesCount.query({ PageSize: PageSize }, function () {
        if (count.length > 1) {
            $scope.Pages = count;
            $scope.LastPage = count[count.length - 1];
            if ($scope.LastPage <= 5) {
                $("#divLastPage").css("display", "none");
                $(".lastOne").css("display", "none");
            }
        }
        else {
            $(".pageController").css("display", "none");
        }
    });
    $scope.MoveTo = function (PageIndex) {
        $('.compeniesList .compeny').remove();
        $("#divListLoading").show();
        window.scrollTo(0, 0);
        $scope.PageIndex = PageIndex;
        Parameters[2] = PageIndex;
        $(".numbers li").removeClass("active");
        $("#" + PageIndex).addClass("active");
        var Companies = BrokerServices.Companies.query({ PageIndex: $scope.PageIndex, PageSize: PageSize }, function () {
            $scope.Companies = Companies;
            if (Companies == "" || Companies == null) {
                //  $('#divEmpty').show();
            }
            //    $('#divloading').hide();
            $("#divListLoading").hide();
        });
        if ($scope.LastPage > 5) {
            if (PageIndex >= 3) {
                $("#" + PageIndex).show();
                $(".firstOne").show();
                $("#divFirstPage").show();
                if (PageIndex < $scope.LastPage) {
                    $(".numbers li").hide();
                    $(".numbers li:lt(" + (PageIndex - 1) + ")").hide();
                    $("#" + (PageIndex - 1)).nextUntil("#" + (PageIndex + 3)).show();
                }
                else {
                    $(".numbers li:lt(" + (PageIndex - 1) + ")").hide();
                    $("#" + PageIndex).prevUntil("#" + (PageIndex - 3)).show();
                }
            }
            else {
                $(".numbers li").hide();
                $(".numbers li:lt(5)").show();
                $(".firstOne").hide();
                $("#divFirstPage").hide();
            }
        }
        window.history.pushState("Page" + PageIndex, "Page" + PageIndex, Parameters.join('/'));
    }
    $scope.NextPage = function () {
        var LastPage = $(".numbers li:last").attr("id");
        if ($scope.PageIndex < LastPage) {
            $scope.MoveTo(parseInt($scope.PageIndex) + 1);
        }
    }
    $scope.PreviousPage = function () {
        var FirstPage = $(".numbers li:first").attr("id");
        if ($scope.PageIndex > FirstPage) {
            $scope.MoveTo(parseInt($scope.PageIndex) - 1);
        }
    }
});
//----------------------------------------End:Company List Controller-------------------------------------------//
//----------------------------------Begin:Project List Controller-----------------------------------------//
brokerApp.controller('ProjectListController', function ($scope, BrokerServices) {
    var Query = decodeURI(window.location.pathname);
    var Parameters = Query.split('/');
    $scope.PageIndex = Parameters[2];
    //alert(Parameters[2]);
    var PageSize = 10;
    if ($scope.PageIndex > 2) {
        $(".firstOne").show();
        $("#divFirstPage").show();
    }
    $scope.FirstPage = 1;
    var Projects = BrokerServices.Projects.query({ PageIndex: $scope.PageIndex, PageSize: PageSize }, function () {
        $scope.Projects = Projects;
        if (Projects == "" || Projects == null) {
            //  $('#divEmpty').show();
        }
        //    $('#divloading').hide();
        $("#divListLoading").hide();
    });

    var count = BrokerServices.ProjectsCount.query({ PageSize: PageSize }, function () {
        if (count.length > 1) {
            $scope.Pages = count;
            $scope.LastPage = count[count.length - 1];
            if ($scope.LastPage <= 5) {
                $("#divLastPage").css("display", "none");
                $(".lastOne").css("display", "none");
            }
        }
        else {
            $(".pageController").css("display", "none");
        }
    });
    $scope.MoveTo = function (PageIndex) {
        $('.compeniesList .compeny').remove();
        $("#divListLoading").show();
        window.scrollTo(0, 0);
        $scope.PageIndex = PageIndex;
        Parameters[2] = PageIndex;
        $(".numbers li").removeClass("active");
        $("#" + PageIndex).addClass("active");
        var Projects = BrokerServices.Projects.query({ PageIndex: $scope.PageIndex, PageSize: PageSize }, function () {
            $scope.Projects = Projects;
            if (Projects == "" || Projects == null) {
                //  $('#divEmpty').show();
            }
            //    $('#divloading').hide();
            $("#divListLoading").hide();
        });
        if ($scope.LastPage > 5) {
            if (PageIndex >= 3) {
                $("#" + PageIndex).show();
                $(".firstOne").show();
                $("#divFirstPage").show();
                if (PageIndex < $scope.LastPage) {
                    $(".numbers li").hide();
                    $(".numbers li:lt(" + (PageIndex - 1) + ")").hide();
                    $("#" + (PageIndex - 1)).nextUntil("#" + (PageIndex + 3)).show();
                }
                else {
                    $(".numbers li:lt(" + (PageIndex - 1) + ")").hide();
                    $("#" + PageIndex).prevUntil("#" + (PageIndex - 3)).show();
                }
            }
            else {
                $(".numbers li").hide();
                $(".numbers li:lt(5)").show();
                // $(".numbers li:gt(4)").hide();
                $(".firstOne").hide();
                $("#divFirstPage").hide();
            }
        }
        window.history.pushState("Page" + PageIndex, "Page" + PageIndex, Parameters.join('/'));
    }
    $scope.NextPage = function () {
        var LastPage = $(".numbers li:last").attr("id");
        if ($scope.PageIndex < LastPage) {
            $scope.MoveTo(parseInt($scope.PageIndex) + 1);
        }
    }
    $scope.PreviousPage = function () {
        var FirstPage = $(".numbers li:first").attr("id");
        if ($scope.PageIndex > FirstPage) {
            $scope.MoveTo(parseInt($scope.PageIndex) - 1);
        }
    }
});
//----------------------------------------End:Project List Controller-------------------------------------------//
//----------------------------------Begin:Company Controller-----------------------------------------//
brokerApp.controller('CompanyDetailsController', function ($scope, $state, BrokerServices) {
    $scope.ID = $('#hdnID').val();
    $scope.Name = $('#lblTitle').text();
    $scope.CompanyID = $scope.ID;
    $scope.ProjectID = "";
    var realestate = BrokerServices.RealEstatesByCompany.query({ CompanyID: $scope.ID, PageIndex: 1, PageSize: 3 }, function () {
        $scope.realEstates = realestate;
        $("#divPropertiesLoader").hide();
        if (realestate == "" || realestate == null) {
            $('#divCompanyProps').hide();
        }
    });
    var Projects = BrokerServices.CompanyProjects.query({ CompanyID: $scope.ID, PageIndex: 1, PageSize: 3 }, function () {
        $scope.Projects = Projects;
        $("#divProjectLoader").hide();
        if (Projects == "" || Projects == null) {
            $('#divCompanyProjects').hide();
        }
    });
    $scope.SendMail = function () {
        $state.go('SendMail');
    };
    $scope.GetProperties = function () {
        $state.go('Properties');
    };
    $scope.GetProjects = function () {
        $state.go('Projects');
    };
});
//----------------------------------------End:Company Controller-------------------------------------------//

//----------------------------------Begin:Send Mail Controller-----------------------------------------//
brokerApp.controller('SendMailController', function ($scope, BrokerServices, $state) {
    window.scrollTo(0, 0);
    $("#divDetail").hide();
    $scope.Contactus = {};
    $scope.Contactus.CompanyID = $scope.CompanyID;
    $scope.Contactus.ProjectID = $scope.ProjectID;
    $scope.SendMessage = function () {
        if ($scope.ContactForm.$valid) {
            $("#btnSend").attr("disabled", true);
            var Message = BrokerServices.SendMail.save({}, JSON.stringify($scope.Contactus), function () {
                var result = $.grep($scope.Messages, function (e) { return e.Type == "SendMailMessage"; });
                $('.popUpTitle').text(result[0].Title);
                $('.popUpCnotent p').text(result[0].Message);
                $('.popUpContainer').show();
                $("#btnSend").attr("disabled", false);
            });
        }
    }

});
//----------------------------------------End:Send Mail Controller-------------------------------------------//
//----------------------------------Begin:Company Property List Controller-----------------------------------------//
brokerApp.controller('CompanyPropertiesController', function ($scope, BrokerServices, $state) {
    window.scrollTo(0, 0);
    $("#divDetail").hide();
    //$('.resultItems .item').remove();
    $scope.PageSize = 10;
    $scope.PageIndex = 1;
    var realestate = BrokerServices.RealEstatesByCompany.query({ CompanyID: $scope.ID, PageIndex: $scope.PageIndex, PageSize: $scope.PageSize }, function () {
        $scope.realEstates = realestate;
        $("#divListLoading").hide();
        if (realestate == "" || realestate == null) {
            //  $('#divCompanyProps').hide();
        }
    });
    var count = BrokerServices.CountRealEstatesByCompany.query({ CompanyID: $scope.ID, PageSize: $scope.PageSize }, function () {
        if (count.length > 1) {
            $scope.Pages = count;
            $scope.LastPage = count[count.length - 1];
            if ($scope.LastPage <= 5) {
                $("#divLastPage").css("display", "none");
                $(".lastOne").css("display", "none");
            }
        }
        else {
            $(".pageController").css("display", "none");
        }
    });
    $scope.MoveTo = function (PageIndex) {
        $('.resultItems .item').remove();
        $("#divListLoading").show();
        window.scrollTo(0, 0);
        $scope.PageIndex = PageIndex;
        // Parameters[2]=PageIndex;
        $(".numbers li").removeClass("active");
        $("#" + PageIndex).addClass("active");
        var realestate = BrokerServices.RealEstatesByCompany.query({ CompanyID: $scope.ID, PageIndex: $scope.PageIndex, PageSize: $scope.PageSize }, function () {
            $scope.realEstates = realestate;
            $("#divListLoading").hide();
            if (realestate == "" || realestate == null) {
                //  $('#divCompanyProps').hide();
            }
        });
        if ($scope.LastPage > 5) {
            if (PageIndex >= 3) {
                $("#" + PageIndex).show();
                $(".firstOne").show();
                $("#divFirstPage").show();
                if (PageIndex < $scope.LastPage) {
                    $(".numbers li").hide();
                    $(".numbers li:lt(" + (PageIndex - 1) + ")").hide();
                    $("#" + (PageIndex - 1)).nextUntil("#" + (PageIndex + 3)).show();
                }
                else {
                    $(".numbers li:lt(" + (PageIndex - 1) + ")").hide();
                    $("#" + PageIndex).prevUntil("#" + (PageIndex - 3)).show();
                }
            }
            else {
                $(".numbers li").hide();
                $(".numbers li:lt(5)").show();
                $(".firstOne").hide();
                $("#divFirstPage").hide();
            }
        }
        //    window.history.pushState("Page"+PageIndex, "Page"+PageIndex, Parameters.join('/'));
    }
    $scope.NextPage = function () {
        var LastPage = $(".numbers li:last").attr("id");
        if ($scope.PageIndex < LastPage) {
            $scope.MoveTo(parseInt($scope.PageIndex) + 1);
        }
    }
    $scope.PreviousPage = function () {
        var FirstPage = $(".numbers li:first").attr("id");
        if ($scope.PageIndex > FirstPage) {
            $scope.MoveTo(parseInt($scope.PageIndex) - 1);
        }
    }
});
//----------------------------------------End:Company Property List Controller-------------------------------------------//

//----------------------------------Begin:Company Project List Controller-----------------------------------------//
brokerApp.controller('CompanyProjectsController', function ($scope, BrokerServices) {
    window.scrollTo(0, 0);
    $("#divDetail").hide();
    $scope.PageSize = 10;
    $scope.PageIndex = 1;
    if ($scope.PageIndex > 2) {
        $(".firstOne").show();
        $("#divFirstPage").show();
    }
    $scope.FirstPage = 1;
    var Projects = BrokerServices.CompanyProjects.query({ CompanyID: $scope.ID, PageIndex: $scope.PageIndex, PageSize: $scope.PageSize }, function () {
        $scope.Projects = Projects;
        if (Projects == "" || Projects == null) {
            //  $('#divEmpty').show();
        }
        //    $('#divloading').hide();
        $("#divListLoading").hide();
    });

    var count = BrokerServices.CompanyProjectsCount.query({ CompanyID: $scope.ID, PageSize: $scope.PageSize }, function () {
        if (count.length > 1) {
            $scope.Pages = count;
            $scope.LastPage = count[count.length - 1];
            if ($scope.LastPage <= 5) {
                $("#divLastPage").css("display", "none");
                $(".lastOne").css("display", "none");
            }
        }
        else {
            $(".pageController").css("display", "none");
        }
    });
    $scope.MoveTo = function (PageIndex) {
        $('.compeniesList .compeny').remove();
        $("#divListLoading").show();
        window.scrollTo(0, 0);
        $scope.PageIndex = PageIndex;
        $(".numbers li").removeClass("active");
        $("#" + PageIndex).addClass("active");
        var Projects = BrokerServices.Projects.query({ CompanyID: $scope.ID, PageIndex: $scope.PageIndex, PageSize: $scope.PageSize }, function () {
            $scope.Projects = Projects;
            if (Projects == "" || Projects == null) {
                //  $('#divEmpty').show();
            }
            //    $('#divloading').hide();
            $("#divListLoading").hide();
        });
        if ($scope.LastPage > 5) {
            if (PageIndex >= 3) {
                $("#" + PageIndex).show();
                $(".firstOne").show();
                $("#divFirstPage").show();
                if (PageIndex < $scope.LastPage) {
                    $(".numbers li").hide();
                    $(".numbers li:lt(" + (PageIndex - 1) + ")").hide();
                    $("#" + (PageIndex - 1)).nextUntil("#" + (PageIndex + 3)).show();
                }
                else {
                    $(".numbers li:lt(" + (PageIndex - 1) + ")").hide();
                    $("#" + PageIndex).prevUntil("#" + (PageIndex - 3)).show();
                }
            }
            else {
                $(".numbers li").hide();
                $(".numbers li:lt(5)").show();
                $(".firstOne").hide();
                $("#divFirstPage").hide();
            }
        }
        // window.history.pushState("Page"+PageIndex, "Page"+PageIndex, Parameters.join('/'));
    }
    $scope.NextPage = function () {
        var LastPage = $(".numbers li:last").attr("id");
        if ($scope.PageIndex < LastPage) {
            $scope.MoveTo(parseInt($scope.PageIndex) + 1);
        }
    }
    $scope.PreviousPage = function () {
        var FirstPage = $(".numbers li:first").attr("id");
        if ($scope.PageIndex > FirstPage) {
            $scope.MoveTo(parseInt($scope.PageIndex) - 1);
        }
    }
});
//----------------------------------------End: Company Project List Controller-------------------------------------------//
//----------------------------------Begin:Project Controller-----------------------------------------//
brokerApp.controller('ProjectDetailsController', function ($scope, $state, BrokerServices, $stateParams) {
    $("#divDetail").show();
    $scope.ID = $('#hdnID').val();
    $scope.Name = $('#lblTitle').text();
    
    $scope.CompanyID = "";
    $scope.ProjectID = $scope.ID;
    var Photos = BrokerServices.ProjectPhotoAlbum.query({ ID: $scope.ID, PageSize: 3 }, function () {
        $scope.Photos = Photos;
        $("#divPhotosLoader").hide();
        if (Photos == "" || Photos == null) {
            $('#divProjectPhotos').hide();
        }
    });
    var Vedios = BrokerServices.ProjectVedios.query({ ID: $scope.ID, PageSize: 3 }, function () {
        $scope.Vedios = Vedios;
        $("#divVideosLoader").hide();
        if (Vedios == "" || Vedios == null) {
            $('#divProjectVideos').hide();
        }
        else {
            for (i = 0; i < Vedios.length; i++) {
                $("#ulVedio").prepend(AddVedio(Vedios[i].Name, Vedios[i].Embed));
            }
        }
    });
    var Models = BrokerServices.ProjectModels.query({ ID: $scope.ID, PageSize: 3 }, function () {
        $scope.Models = Models;
        $("#divModelLoader").hide();
        if (Models == "" || Models == null) {
            $('#divModels').hide();
        }
    });
    var Props = BrokerServices.ProjectProperties.query({ ID: $scope.ID,PageIndex: 1, PageSize: 3 }, function () {
        $scope.Props = Props;
        $("#divPropsLoader").hide();
        if (Props == "" || Props == null) {
            $('#divProps').hide();
        }
    });
    //------------------------------------------------
    function AddVedio(Name, Embed) {
        var Li = "<li><div class='item'><a href='javascript:void(0);'>";
        Li += "<div class='divVedio'>" + Embed + "</div>";
        Li += "<div class='itemDetails'><span>" + Name + "</span></div>";
        Li += "</a></div></li>";
        return Li;
    }
    $scope.SendMail = function () {
        $state.go('SendMail');
    };
    $scope.ShowModel = function (ID) {
        $stateParams = { ID: ID };
        $state.go('Model', $stateParams);
    };
    $scope.ShowPhotos = function (Date) {
        $stateParams = { Date: Date };
        $state.go('ProjectPhotos', $stateParams);
    };
    $scope.ShowPhotoAlbum = function () {
        $state.go('ProjectPhotoAlbum');
    };
    $scope.ShowVideos = function () {
        $state.go('ProjectVideos');
    };
    $scope.ShowModels = function () {
        $state.go('ProjectModels');
    };
    $scope.ShowProps = function () {
        $state.go('ProjectProperties');
    };

});
//----------------------------------------End:Project Controller-------------------------------------------//

//----------------------------------Begin:Model Detail Controller-----------------------------------------//
brokerApp.controller('ModelDetailsController', function ($scope, BrokerServices, $state, $stateParams) {
    window.scrollTo(0, 0);
    $("#divDetail").hide();
    $("#divModelDetailsLoading").show();
    var Model = BrokerServices.Model.get({ ID: $stateParams.ID }, function () {
        $scope.Model = Model;
        $("#divModelDetailsLoading").hide();
        if (Model == "" || Model == null) {
            //  $('#divProjectPhotos').hide();
        }
    });


});
//----------------------------------------End:Model Detail Controller-------------------------------------------//

//----------------------------------Begin:Project Photos Controller-----------------------------------------//
brokerApp.controller('ProjectPhotoController', function ($scope, BrokerServices, $state, $stateParams) {
    window.scrollTo(0, 0);
    $("#divDetail").hide();
    var fadeSliderMark;
    $scope.Date = $stateParams.Date;
    var Photos = BrokerServices.ProjectPhotos.query({ ID: $scope.ID, Date: $stateParams.Date }, function () {
        $scope.Photos = Photos;
        if (Photos.length <= 1) {
            $("#divSlidetBtn").hide();
        }
        //        else{
        fadeSliderMark = setTimeout(function () { fadeSlider($('.slider .viewPort ul li:first-child')) });
        //   }
        //        }
        // $("#divPhotosLoader").hide();
        if (Photos == "" || Photos == null) {
            //  $('#divProjectPhotos').hide();
        }
    });

    //----------------------------Begin: Event Handler---------------------------------------------//

    $scope.Next = function () {
        clearTimeout(fadeSliderMark);
        slide = $('.slider .viewPort ul li:first-child');
        slide.hide();
        slide.remove();
        $('.slider .viewPort ul li:last-child').after(slide);
        fadeSliderMark = setTimeout(function () { fadeSlider($('.slider .viewPort ul li:first-child')) });
    }
    $scope.Previous = function () {
        clearTimeout(fadeSliderMark);
        slide = $('.slider .viewPort ul li:not(:last-child)');
        slide.hide();
        slide.remove();
        $('.slider .viewPort ul li:last-child').after(slide);
        fadeSliderMark = setTimeout(function () { fadeSlider($('.slider .viewPort ul li:first-child')) });
    }
    //-----------------------------------------------
    function fadeSlider(slide) {
        slide.fadeIn(1000).delay(6000).queue(function () {
            if ($('.slider .viewPort ul li').length > 1) {
                slide.fadeOut(1000);
                slide.remove();
                $('.slider .viewPort ul li:last-child').after(slide);
                fadeSliderMark = setTimeout(function () { fadeSlider($('.slider .viewPort ul li:first-child')) });
            }
        });
    }
    //-----------------------------End: Event Handler----------------------------------------------//

});
//----------------------------------------End:Project Photos Controller-------------------------------------------//
//----------------------------------Begin:Project Photo List Controller-----------------------------------------//
brokerApp.controller('ProjectPhotoAlbumController', function ($scope, BrokerServices, $state, $stateParams) {
    $("#divPhotoLoading").show();
    window.scrollTo(0, 0);
    $("#divDetail").hide();
    var Photos = BrokerServices.ProjectPhotoAlbum.query({ ID: $scope.ID, PageSize: 0 }, function () {
        $scope.Photos = Photos;

        $("#divPhotoLoading").hide();
        if (Photos == "" || Photos == null) {
            // alert("test");
            $('#divPhotoLoading').hide();
        }
    });
    $scope.ShowPhotos = function (Date) {
        $stateParams = { Date: Date };
        $state.go('ProjectPhotos', $stateParams);
    };

});
//----------------------------------------End:Project Photo List Controller-------------------------------------------//
//----------------------------------Begin:Project Photo List Controller-----------------------------------------//
brokerApp.controller('ProjectVediosController', function ($scope, BrokerServices, $state) {
    $("#divVideoloading").hide();
    window.scrollTo(0, 0);
    $("#divDetail").hide();

    var Vedios = BrokerServices.ProjectVedios.query({ ID: $scope.ID, PageSize: 0 }, function () {
        $scope.Vedios = Vedios;
        $("#divVideoloading").hide();
        if (Vedios == "" || Vedios == null) {
            $('#divProjectVideos').hide();
        }
        else {
            for (i = 0; i < Vedios.length; i++) {
                $("#ulVedioList").prepend(AddVedio(Vedios[i].Name, Vedios[i].Embed));
            }
        }
    });

    function AddVedio(Name, Embed) {
        var Li = "<li class='col-md-6'><div class='item'><a href='javascript:void(0);'>";
        Li += "<div class='divVedio'>" + Embed + "</div>";
        Li += "<div class='itemDetails'><span>" + Name + "</span></div>";
        Li += "</a></div></li>";
        return Li;
    }

});
//----------------------------------------End:Project Photo List Controller-------------------------------------------//

//----------------------------------Begin:Project Model List Controller-----------------------------------------//
brokerApp.controller('ProjectModelsController', function ($scope, BrokerServices, $state, $stateParams) {
    $("#divModelLoading").show();
    window.scrollTo(0, 0);
    $("#divDetail").hide();
    var Models = BrokerServices.ProjectModels.query({ ID: $scope.ID, PageSize: 0 }, function () {
        $scope.Models = Models;
        $("#divModelLoading").hide();
        if (Models == "" || Models == null) {
            $('#divModels').hide();
        }
    });
    $scope.ShowModel = function (ID) {
        $stateParams = { ID: ID };
        $state.go('Model', $stateParams);
    };
});
//----------------------------------------End:Project Model List Controller-------------------------------------------//
//----------------------------------Begin:Project Props List Controller-----------------------------------------//
brokerApp.controller('ProjectPropsController', function ($scope, BrokerServices, $state, $stateParams) {
    window.scrollTo(0, 0);
    $("#divDetail").hide();
    //$('.resultItems .item').remove();
    $scope.PageSize = 10;
    $scope.PageIndex = 1;
    var realestate = BrokerServices.ProjectProperties.query({ ID: $scope.ID, PageIndex: $scope.PageIndex, PageSize: $scope.PageSize }, function () {
        $scope.realEstates = realestate;
        $("#divListLoading").hide();
        if (realestate == "" || realestate == null) {
            //  $('#divCompanyProps').hide();
        }
    });
    var count = BrokerServices.CountProjectProperties.query({ ID: $scope.ID, PageSize: $scope.PageSize }, function () {
        if (count.length > 1) {
            $scope.Pages = count;
            $scope.LastPage = count[count.length - 1];
            if ($scope.LastPage <= 5) {
                $("#divLastPage").css("display", "none");
                $(".lastOne").css("display", "none");
            }
        }
        else {
            $(".pageController").css("display", "none");
        }
    });
    $scope.MoveTo = function (PageIndex) {
        $('.resultItems .item').remove();
        $("#divListLoading").show();
        window.scrollTo(0, 0);
        $scope.PageIndex = PageIndex;
        // Parameters[2]=PageIndex;
        $(".numbers li").removeClass("active");
        $("#" + PageIndex).addClass("active");
        var realestate = BrokerServices.ProjectProperties.query({ ID: $scope.ID, PageIndex: $scope.PageIndex, PageSize: $scope.PageSize }, function () {
            $scope.realEstates = realestate;
            $("#divListLoading").hide();
            if (realestate == "" || realestate == null) {
                //  $('#divCompanyProps').hide();
            }
        });
        if ($scope.LastPage > 5) {
            if (PageIndex >= 3) {
                $("#" + PageIndex).show();
                $(".firstOne").show();
                $("#divFirstPage").show();
                if (PageIndex < $scope.LastPage) {
                    $(".numbers li").hide();
                    $(".numbers li:lt(" + (PageIndex - 1) + ")").hide();
                    $("#" + (PageIndex - 1)).nextUntil("#" + (PageIndex + 3)).show();
                }
                else {
                    $(".numbers li:lt(" + (PageIndex - 1) + ")").hide();
                    $("#" + PageIndex).prevUntil("#" + (PageIndex - 3)).show();
                }
            }
            else {
                $(".numbers li").hide();
                $(".numbers li:lt(5)").show();
                $(".firstOne").hide();
                $("#divFirstPage").hide();
            }
        }
        //    window.history.pushState("Page"+PageIndex, "Page"+PageIndex, Parameters.join('/'));
    }
    $scope.NextPage = function () {
        var LastPage = $(".numbers li:last").attr("id");
        if ($scope.PageIndex < LastPage) {
            $scope.MoveTo(parseInt($scope.PageIndex) + 1);
        }
    }
    $scope.PreviousPage = function () {
        var FirstPage = $(".numbers li:first").attr("id");
        if ($scope.PageIndex > FirstPage) {
            $scope.MoveTo(parseInt($scope.PageIndex) - 1);
        }
    }
});
//----------------------------------------End:Project Props List Controller-------------------------------------------//
//----------------------------------Begin:catalog Controller-----------------------------------------//
brokerApp.controller('CatalogDetailsController', function ($scope, $state, BrokerServices) {
    $scope.ID = $('#hdnID').val();
    $scope.Name = $('#lblTitle').text();
    $scope.CompanyID = $scope.ID;
    $scope.ProjectID = "";
    var realestate = BrokerServices.RealEstatesByCatalog.query({ CatalogID: $scope.ID, PageIndex: 1, PageSize: 50 }, function () {
        $scope.realEstates = realestate;
        $("#divPropertiesLoader").hide();
        if (realestate == "" || realestate == null) {
            $('#divCompanyProps').hide();
        }
    });
    
    
    $scope.SendMail = function () {
        $state.go('SendMail');
    };
    $scope.GetProperties = function () {
        $state.go('CatalogProperties');
    };
    
});
//----------------------------------------End:catalog Controller-------------------------------------------//

//----------------------------------Begin:catalog Props List Controller-----------------------------------------//
brokerApp.controller('CatalogPropsController', function ($scope, BrokerServices, $state, $stateParams) {
    window.scrollTo(0, 0);
    $("#divDetail").hide();
    //$('.resultItems .item').remove();
    $scope.PageSize = 10;
    $scope.PageIndex = 1;
    var realestate = BrokerServices.RealEstatesByCatalog.query({ CatalogID: $scope.ID, PageIndex: $scope.PageIndex, PageSize: $scope.PageSize }, function () {
        $scope.realEstates = realestate;
        $("#divListLoading").hide();
        if (realestate == "" || realestate == null) {
            //  $('#divCompanyProps').hide();
        }
    });
    var count = BrokerServices.CountRealEstatesByCatalog.query({ Catalog: $scope.ID, PageSize: $scope.PageSize }, function () {
        if (count.length > 1) {
            $scope.Pages = count;
            $scope.LastPage = count[count.length - 1];
            if ($scope.LastPage <= 5) {
                $("#divLastPage").css("display", "none");
                $(".lastOne").css("display", "none");
            }
        }
        else {
            $(".pageController").css("display", "none");
        }
    });
    $scope.MoveTo = function (PageIndex) {
        $('.resultItems .item').remove();
        $("#divListLoading").show();
        window.scrollTo(0, 0);
        $scope.PageIndex = PageIndex;
        // Parameters[2]=PageIndex;
        $(".numbers li").removeClass("active");
        $("#" + PageIndex).addClass("active");
        var realestate = BrokerServices.RealEstatesByCatalog.query({ CatalogID: $scope.ID, PageIndex: $scope.PageIndex, PageSize: $scope.PageSize }, function () {
            $scope.realEstates = realestate;
            $("#divListLoading").hide();
            if (realestate == "" || realestate == null) {
                //  $('#divCompanyProps').hide();
            }
        });
        if ($scope.LastPage > 5) {
            if (PageIndex >= 3) {
                $("#" + PageIndex).show();
                $(".firstOne").show();
                $("#divFirstPage").show();
                if (PageIndex < $scope.LastPage) {
                    $(".numbers li").hide();
                    $(".numbers li:lt(" + (PageIndex - 1) + ")").hide();
                    $("#" + (PageIndex - 1)).nextUntil("#" + (PageIndex + 3)).show();
                }
                else {
                    $(".numbers li:lt(" + (PageIndex - 1) + ")").hide();
                    $("#" + PageIndex).prevUntil("#" + (PageIndex - 3)).show();
                }
            }
            else {
                $(".numbers li").hide();
                $(".numbers li:lt(5)").show();
                $(".firstOne").hide();
                $("#divFirstPage").hide();
            }
        }
        //    window.history.pushState("Page"+PageIndex, "Page"+PageIndex, Parameters.join('/'));
    }
    $scope.NextPage = function () {
        var LastPage = $(".numbers li:last").attr("id");
        if ($scope.PageIndex < LastPage) {
            $scope.MoveTo(parseInt($scope.PageIndex) + 1);
        }
    }
    $scope.PreviousPage = function () {
        var FirstPage = $(".numbers li:first").attr("id");
        if ($scope.PageIndex > FirstPage) {
            $scope.MoveTo(parseInt($scope.PageIndex) - 1);
        }
    }
});
//----------------------------------------End:catalog Props List Controller-------------------------------------------//
