<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BrokerWeb.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" ng-app="brokerApp" ng-controller="MainController">
<head runat="server">
    <!-- Google Tag Manager -->
<script>(function(w,d,s,l,i){w[l]=w[l]||[];w[l].push({'gtm.start':
new Date().getTime(),event:'gtm.js'});var f=d.getElementsByTagName(s)[0],
j=d.createElement(s),dl=l!='dataLayer'?'&l='+l:'';j.async=true;j.src=
'https://www.googletagmanager.com/gtm.js?id='+i+dl;f.parentNode.insertBefore(j,f);
})(window,document,'script','dataLayer','GTM-K79M4WF');</script>
<!-- End Google Tag Manager -->

    <meta charset="utf-8" />
    <title>عقار ستوك | محرك بحث عقارى | شقق وفيلات واراضى | للبيع والإيجار - الرئيسية</title>
    <meta name="title" content="عقار ستوك | محرك بحث عقارى | شقق وفيلات واراضى | للبيع والإيجار - الرئيسية" />
    <meta name="description" content="محرك بحث عقارى يوفر لكل فرصة لبيع وإيجار الشقق والاراضى والفيلل والدوبلكس وغيرها ..  بكل سهولة أون لاين مجانا بدون وسيط " />
    <meta name="keywords" content="عقارات, خريطة, جوجل إرث, فيلا, بيت, منزل, شقة, أرض, قصر, غرفة, للبيع, شراء, مطلوب, تأجير, الرياض, السعودية, دبي, أبو ظبي, الدوحة, مصر, القاهرة, اسكندرية, شقق للب" />
    <meta name='twitter:card' content="summary" />
    <meta name='twitter:title' content="عقار ستوك | محرك بحث عقارى | شقق وفيلات واراضى | للبيع والإيجار - الرئيسية" />
    <meta name='twitter:url' content="http://www.aqarstock.com/" />
    <meta name='twitter:url' content="http://www.aqarstock.net/" />
    <meta name='twitter:description' content="محرك بحث عقارى يوفر لكل فرصة لبيع وإيجار الشقق والاراضى والفيلل والدوبلكس وغيرها ..  بكل سهولة أون لاين مجانا بدون وسيط" />
    <meta name='twitter:image' content="http://www.aqarstock.com/images/sociallogo.png" />
    <meta name='og:type' content="article" />
    <meta name='og:title' content="عقار ستوك | محرك بحث عقارى | شقق وفيلات واراضى | للبيع والإيجار - الرئيسية" />
    <meta name='og:image' content="http://www.aqarstock.com/images/sociallogo.png" />
    <meta name="og:image" content="http://www.aqarstock.com/images/RealEstateSocial/Aqar-Stock-Sociallogo-1.png" />
    <meta name="og:image" content="http://www.aqarstock.com/images/RealEstateSocial/Aqar-Stock-Sociallogo-2.png" />
    <meta name="og:image" content="http://www.aqarstock.com/images/RealEstateSocial/Aqar-Stock-Sociallogo-3.png" />
    <meta name="og:image" content="http://www.aqarstock.com/images/RealEstateSocial/Aqar-Stock-Sociallogo-4.png" />
    <meta name="og:image" content="http://www.aqarstock.com/images/RealEstateSocial/Aqar-Stock-Sociallogo-5.png" />
    <meta name="og:image" content="http://www.aqarstock.com/images/RealEstateSocial/Aqar-Stock-Sociallogo-6.png" />
    <meta name='og:url' content="http://www.aqarstock.com/" />
    <meta name='og:url' content="http://www.aqarstock.net/" />
    <meta name='og:description' content="محرك بحث عقارى يوفر لكل فرصة لبيع وإيجار الشقق والاراضى والفيلل والدوبلكس وغيرها ..  بكل سهولة أون لاين مجانا بدون وسيط " />
    <meta name="p:domain_verify" content="cbd3d977e0b536dfac2bfa6c64e31d0f" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="shortcut icon" href="favicon.ico" />
    <!-- Bootstrap -->
    <link rel="stylesheet" type="text/css" media="screen" href="styles/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" media="screen" href="styles/bootstrap-theme.min.css" />
    <link href="styles/CssStyle.css" rel="stylesheet" type="text/css" />
    <link href="styles/styleSelect.css" rel="stylesheet" type="text/css" />
    <script src="scripts/jquery-1.11.0.min.js"></script>
    <script src="scripts/angular.min.js" type="text/javascript"></script>
    <script src="scripts/angular-route.min.js" type="text/javascript"></script>
    <script src="scripts/angular-ui-router.js" type="text/javascript"></script>
    <script src="scripts/angular-animate.min.js" type="text/javascript"></script>
    <script src="scripts/angular-resource.min.js" type="text/javascript"></script>
    <script src="scripts/FrontEndController.js" type="text/javascript"></script>
    <script src="scripts/services.js" type="text/javascript"></script>
    <script src="scripts/FrontEndDirective.js" type="text/javascript"></script>
    <script src="scripts/select.js" type="text/javascript"></script>
    <script src="scripts/bootstrap.min.js" type="text/javascript"></script>
    <script>        (function () {
            var _fbq = window._fbq || (window._fbq = []);
            if (!_fbq.loaded) {
                var fbds = document.createElement('script');
                fbds.async = true;
                fbds.src = '//connect.facebook.net/en_US/fbds.js';
                var s = document.getElementsByTagName('script')[0];
                s.parentNode.insertBefore(fbds, s);
                _fbq.loaded = true;
            }
            _fbq.push(['addPixelId', '923920740967751']);
        })();
        window._fbq = window._fbq || [];
        window._fbq.push(['track', 'PixelInitialized', {}]);
    </script>
    <noscript>
        <img height="1" width="1" alt="" style="display: none" src="https://www.facebook.com/tr?id=923920740967751&amp;ev=PixelInitialized" />
    </noscript>
    <!-- Facebook Conversion Code for Key Page Views - Aqar Stock -->
    <script>    (function () {
        var _fbq = window._fbq || (window._fbq = []);
        if (!_fbq.loaded) {
            var fbds = document.createElement('script');
            fbds.async = true;
            fbds.src = '//connect.facebook.net/en_US/fbds.js';
            var s = document.getElementsByTagName('script')[0];
            s.parentNode.insertBefore(fbds, s);
            _fbq.loaded = true;
        }
    })();
        window._fbq = window._fbq || [];
        window._fbq.push(['track', '6028034916005', { 'value': '0.00', 'currency': 'USD' }]);
    </script>
    <noscript>
        <img height="1" width="1" alt="" style="display: none" src="https://www.facebook.com/tr?ev=6028034916005&amp;cd[value]=0.00&amp;cd[currency]=USD&amp;noscript=1" />
    </noscript>

</head>
<body class="rtl">
    

<!-- Google Tag Manager (noscript) -->
<noscript><iframe src="https://www.googletagmanager.com/ns.html?id=GTM-K79M4WF"
height="0" width="0" style="display:none;visibility:hidden"></iframe></noscript>
<!-- End Google Tag Manager (noscript) -->

    <div class="firstLoader">
        <div class="loadImages">
            <div class="loadingLogo">
                <img src="images/Frontend/logoloader.png" />
            </div>
            <div class="loading">
                <img src="images/Frontend/loader.gif" />
            </div>
        </div>
    </div>
    <div class="wrapper">
        <header>
		    <div id="divHeader" ng-include src="'parts/Header.htm'" onload="LoadHeader()">
            </div>
	    </header>
        <!-- search Area start -->
        <div class="searchArea" ng-controller="BannerController">
            <div class="searchAreaImg">
                <img ng-src="{{BannerProjects.DefaultPhoto}}" alt="{{Project.ProjectName}}" />
            </div>
            <div id="divSearch" class="search">
                <!-- search area normal -->
                <div class="tabsBox">
                    <div class="tabs">
                        <div id="divTabSale" value="1" class="tab active" tab-click>
                            <span>وحدات للبيع</span>
                        </div>
                        <div id="divTabRent" value="2" class="tab" tab-click>
                            <span>وحدات للإيجار</span>
                        </div>
                    </div>
                    <div class="tabContentBoxes">
                        <div class="tabContentBox">
                            <div class="firstRow">
                                <div class="in">
                                    <span>نوع الوحدة</span></br>
                                    <select id="ddlSearchType" search-selecttype>
                                        <option value="">كل الأنواع</option>
                                        <option ng-repeat="RealEstateType in RealEstateTypes" value="{{RealEstateType.ID}}">{{RealEstateType.Name}}</option>
                                    </select>
                                </div>
                                <div class="in">
                                    <span>البلد</span></br>
                                    <select id="ddlSearchCountry" search-selectcountry>
                                        <option value="">كل البلاد</option>
                                        <option ng-repeat="Country in Countries" value="{{Country.ID}}">{{Country.Name}}</option>
                                    </select>
                                </div>
                                <div class="in">
                                    <span>المحافظة</span></br>
                                    <select id="ddlSearchCity" search-selectcity>
                                        <option value="">كل المحافظات</option>
                                        <option ng-repeat="City in SearchCitiesList" value="{{City.ID}}">{{City.Name}}</option>
                                    </select>
                                </div>
                                <div class="in">
                                    <span>الحي</span></br>
                                    <select id="ddlSearchDistrict" select-district>
                                        <option value="">كل الأحياء</option>
                                        <option ng-repeat="District in SearcDistricts" value="{{District.ID}}">{{District.Name}}</option>
                                    </select>
                                </div>
                                <div class="in">
                                    <span>السعر</span></br>
                                    <select id="ddlSearchPrice">
                                        <option value="">أختر السعر</option>
                                        <option ng-repeat="Price in Prices" value="{{Price.value}}">{{Price.text}}</option>
                                    </select>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="secRow">
                                <div class="control">
                                    <%--<span>البحث عن طريق <b>:</b> </span>
                                    <ul>
                                        <li>
                                            <input type="radio" name="1" value="الصور" /><label>الصور</label></li>
                                        <li>
                                            <input type="radio" name="1" value="القائمة" /><label>القائمة</label></li>
                                        <li>
                                            <input type="radio" name="1" value="الخريطة" /><label>الخريطة</label></li>
                                    </ul>--%>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="line">
                            </div>
                            <div class="thirdRow">
                                <div class="in">
                                    <span>المساحة</span></br>
                                    <select id="ddlSearchArea">
                                        <option value="">أختر المساحة</option>
                                        <option ng-repeat="Area in Areas" value="{{Area.value}}">{{Area.text}}</option>
                                    </select>
                                </div>
                                <div class="in">
                                    <span>حالة الوحدة</span></br>
                                    <select id="ddlSearchStatus" select-status>
                                        <option value="">أختر حالة الوحدة</option>
                                        <option ng-repeat="Status in SearchStatuses" value="{{Status.ID}}">{{Status.Name}}</option>
                                    </select>
                                </div>
                                <div class="in">
                                    <span>طريقة الدفع</span></br>
                                    <select id="ddlSearchPaymentMethod">
                                        <option value="">أختر طريقة الدفع</option>
                                        <option ng-repeat="PaymentType in PaymentTypes" value="{{PaymentType.ID}}">{{PaymentType.Name}}</option>
                                    </select>
                                </div>
                                <div class="in">
                                    <span>العملة</span></br>
                                    <select id="ddlSearchCurrency">
                                        <option value="">أختر العملة</option>
                                        <option ng-repeat="Currency in Currincies" value="{{Currency.ID}}">{{Currency.Name}}</option>
                                    </select>
                                </div>
                                <div class="clear">
                                </div>
                                <div class="control">
                                    <span><a href="javascript:void(0);" btn-advanced>بحث مفصل عن عقارك</a></span>
                                    <span
                                        class="expand" id="close" btn-advanced><a href="javascript:void(0);">غلق البحث المفضل</a></span>
                                    <div class="moreBtn" btn-search>
                                        <a id="searchBtn" href="javascript:void(0);">بحث</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%--   <div class="tabContentBox">
                            tab content 2
                        </div>--%>
                    </div>
                </div>
                <!-- search area normal -->
            </div>
            <div class="bottomBar">
                <div class="container">
                    <div class="moreBtn">
                        <a ng-href="/مشاريع_عقارية/{{BannerProjects.ID}}/{{BannerProjects.URL}}">المزيد</a>
                    </div>
                    <a style="display:block" ng-href="/مشاريع_عقارية/{{BannerProjects.ID}}/{{BannerProjects.URL}}"><span>{{BannerProjects.ProjectName}} - {{BannerProjects.Slogan}}</span></a>
                </div>
            </div>
        </div>
        <!-- search Area end -->
        <!-- search area small -->
        <div id="divMobileSearch" class="container">
            <div class="smallSearch">
                <mobile-search></mobile-search>
            </div>
        </div>
        <%--<div class="container">
            <div class="smallSearch">
                <div class="tabsBoxSm">
                    <div class="tabs">
                        <div id="div1" value="1" class="tab active" tab-click>
                            <span>وحدات للبيع</span>
                        </div>
                        <div id="div2" value="2" class="tab" tab-click>
                            <span>وحدات للإيجار</span>
                        </div>
                    </div>
                    <div class="tabContentBoxes">
                        <div class="tabContentBox">
                            <div class="firstRow">
                                <div class="in">
                                    <span>نوع الوحدة</span></br>
                                    <select id="Select1" search-selecttype>
                                        <option value="">كل الأنواع</option>
                                        <option ng-repeat="RealEstateType in RealEstateTypes" value="{{RealEstateType.ID}}">
                                            {{RealEstateType.Name}}</option>
                                    </select>
                                </div>
                                <div class="in">
                                    <span>البلد</span></br>
                                    <select id="Select2" search-selectcountry>
                                        <option value="">كل البلاد</option>
                                        <option ng-repeat="Country in Countries" value="{{Country.ID}}">{{Country.Name}}</option>
                                    </select>
                                </div>
                                <div class="in">
                                    <span>المحافظة</span></br>
                                    <select id="Select3" search-selectcity>
                                        <option value="">كل المحافظات</option>
                                        <option ng-repeat="City in SearchCitiesList" value="{{City.ID}}">{{City.Name}}</option>
                                    </select>
                                </div>
                                <div class="in">
                                    <span>الحي</span></br>
                                    <select id="Select4" select-district>
                                        <option value="">كل الأحياء</option>
                                        <option ng-repeat="District in SearcDistricts" value="{{District.ID}}">{{District.Name}}</option>
                                    </select>
                                </div>
                                <div class="in">
                                    <span>السعر</span></br>
                                    <select id="Select5">
                                        <option value="">أختر السعر</option>
                                        <option ng-repeat="Price in Prices" value="{{Price.value}}">{{Price.text}}</option>
                                    </select>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="secRow">
                                <div class="control">
                                    <span>البحث عن طريق <b>:</b> </span></br>
                                    <ul>
                                        <li>
                                            <input type="radio" name="1" value="الصور" /><label>الصور</label></li>
                                        <li>
                                            <input type="radio" name="1" value="القائمة" /><label>القائمة</label></li>
                                        <li>
                                            <input type="radio" name="1" value="الخريطة" /><label>الخريطة</label></li>
                                    </ul>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="line">
                            </div>
                            <div class="thirdRow">
                                <div class="in">
                                    <span>المساحة</span></br>
                                    <select id="Select6">
                                        <option value="">أختر المساحة</option>
                                        <option ng-repeat="Area in Areas" value="{{Area.value}}">{{Area.text}}</option>
                                    </select>
                                </div>
                                <div class="in">
                                    <span>حالة الوحدة</span></br>
                                    <select id="Select7" select-status>
                                        <option value="">أختر حالة الوحدة</option>
                                        <option ng-repeat="Status in SearchStatuses" value="{{Status.ID}}">{{Status.Name}}</option>
                                    </select>
                                </div>
                                <div class="in">
                                    <span>طريقة السداد</span></br>
                                    <select id="Select8">
                                        <option value="">أختر طريقة السداد</option>
                                        <option ng-repeat="PaymentType in PaymentTypes" value="{{PaymentType.ID}}">{{PaymentType.Name}}</option>
                                    </select>
                                </div>
                                <div class="in">
                                    <span>العملة</span></br>
                                    <select id="Select9">
                                        <option value="">أختر العملة</option>
                                        <option ng-repeat="Currency in Currincies" value="{{Currency.ID}}">{{Currency.Name}}</option>
                                    </select>
                                </div>
                                <div class="clear">
                                </div>
                                <div class="control">
                                    <span><a href="javascript:void(0);" btn-advanced>بحث مفصل عن عقارك</a></span> <span
                                        class="expand" id="Span1"><a href="javascript:void(0);" btn-advanced>غلق البحث المفضل</a></span>
                                    <div class="moreBtn">
                                        <a btn-search href="javascript:void(0);">بحث</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>--%>
        <!-- search area small -->
        <!-- content Area start -->
        <div class="content" ng-controller="HomePageController">
            <div class="container">
                <div class="ADS">
                    <a href="{{MainAd.URL}}" alt="{{MainAd.Name}}">
                        <img src="{{MainAd.HomePageMainAd}}" />
                    </a>
                    <%--    <a href="/شركات_عقارية/7/شركة-دار-للتنمية-وإدارة-المشروعات#/Properties/">
                        <img src="images/Ads/1140-100.jpg" />
                    </a>--%>
                </div>
                <div class="offers">
                    <div class="offerTitle">
                        <a href="/عروض_مميزة/1">
                            <h4>عروض عقار ستوك المميزة</h4>
                        </a>
                    </div>
                    <div class="offerBody">
                        <ul>
                            <li ng-repeat="Offer in Offers">
                                <div class="item">
                                    <a ng-href="/Details/{{Offer.ID}}/{{Offer.URL}}">
                                        <div class="wow">
                                            <div class="wowText">
                                                {{Offer.SaleType}}
                                            </div>
                                        </div>
                                        <div class="itemImg">
                                            <img src="http://www.aqarstock.com/{{Offer.Logo}}" />
                                        </div>
                                        <div class="itemDetails">
                                            <span>{{Offer.Type}} <b ng-if="Offer.Area != '0' ">{{Offer.Area}} م </b>- {{Offer.District}},{{Offer.City}}</span>
                                        </div>
                                        <div class="itemPrice">
                                            <span ng-if="Offer.Price != '0' ">السعر: <b>{{Offer.Price}}</b> {{Offer.Currency}}</span>
                                            <span ng-if="Offer.Price == '0' ">السعر: غير متوفر</span>
                                        </div>
                                    </a>
                                </div>
                            </li>
                            <li>
                                <div class="squareADS">
                                    <a href="{{SideAd.URL}}" alt="{{SideAd.Name}}">
                                        <img src="{{SideAd.HomepageLeftAd}}" />
                                    </a>
                                    <%--    <a href="/شركات_عقارية/7/شركة-دار-للتنمية-وإدارة-المشروعات#/Properties/">
                                        <img src="images/Ads/277-273.jpg" />
                                    </a>--%>
                                </div>
                            </li>
                        </ul>
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <div id="ForSaleSlider" class="slider">
                    <div class="sliderTitle">
                        <span class="leftBtn" btn-saleprevious>
                            <img src="images/Frontend/prev.png" /></span> <span id="btnForSaleNext" class="rightBtn"
                                btn-salenext>
                                <img src="images/Frontend/next.png" /></span> <a href="/وحدات/1/للبيع/1">
                                    <h4 class="middle">آخر الوحدات المضافة للبيع</h4>
                                </a>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="sliderBody">
                        <div id="divSoldLoader" class="loader">
                            <img src="images/Frontend/loading2.gif" />
                        </div>
                        <div class="viewport">
                            <ul>
                                <li ng-repeat="realestate in ForSaleRealEstates" li-slider>
                                    <div class="item">
                                        <a ng-href="/Details/{{realestate.ID}}/{{realestate.URL}}">
                                            <div class="itemImg">
                                                <img src="http://www.aqarstock.com/{{realestate.Logo}}" />
                                            </div>
                                            <div class="itemDetails">
                                                <span>{{realestate.Type}} <b ng-if="realestate.Area != '0' ">{{realestate.Area}} م </b>
                                                    - {{realestate.District}},{{realestate.City}}</span>
                                            </div>
                                            <div class="itemPrice">
                                                <span ng-if="realestate.Price != '0' ">السعر: <b>{{realestate.Price}}</b> {{realestate.Currency}}</span>
                                                <span ng-if="realestate.Price == '0' ">السعر: غير متوفر</span>
                                            </div>
                                        </a>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div id="ForRentSlider" class="slider">
                    <div class="sliderTitle">
                        <span class="leftBtn" btn-rentprevious>
                            <img src="images/Frontend/prev.png" /></span> <span id="btnForRentNext" class="rightBtn"
                                btn-rentnext>
                                <img src="images/Frontend/next.png" /></span> <a href="/وحدات/1/للإيجار/2">
                                    <h4 class="middle">آخر الوحدات المضافة للإيجار</h4>
                                </a>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="sliderBody">
                        <div id="divRentLoader" class="loader">
                            <img src="images/Frontend/loading2.gif" />
                        </div>
                        <div class="viewport">
                            <ul>
                                <li ng-repeat="realestate in ForRentRealEstates" li-slider>
                                    <div class="item">
                                        <a ng-href="/Details/{{realestate.ID}}/{{realestate.URL}}">
                                            <div class="itemImg">
                                                <img src="http://www.aqarstock.com/{{realestate.Logo}}" />
                                            </div>
                                            <div class="itemDetails">
                                                <span>{{realestate.Type}} <b ng-if="realestate.Area != '0' ">{{realestate.Area}} م </b>
                                                    - {{realestate.District}},{{realestate.City}}</span>
                                            </div>
                                            <div class="itemPrice">
                                                <span ng-if="realestate.Price != '' ">السعر: <b>{{realestate.Price}}</b> {{realestate.Currency}}</span>
                                                <span ng-if="realestate.Price == '' ">السعر: غير متوفر</span>
                                            </div>
                                        </a>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="lastProj">
                    <div class="lastProjTitle">
                        <h4>مشاريع عقارية</h4>
                    </div>
                    <div class="lastProjBody">
                        <div class="firstProj" ng-repeat="Project in Projects">
                            <div class="item">
                                <div class="title">
                                    <a ng-href="/مشاريع_عقارية/{{Project.ID}}/{{Project.URL}}">{{Project.ProjectName}}
                                    </a>
                                </div>
                                <a ng-href="/مشاريع_عقارية/{{Project.ID}}/{{Project.URL}}">
                                    <img src="http://www.aqarstock.com/{{Project.DefaultPhoto}}" /></a>
                                <p>
                                    {{Project.Summary}}
                                </p>
                                <a class="more" ng-href="/مشاريع_عقارية/{{Project.ID}}/{{Project.URL}}">تعرف علي المزيد</a>
                            </div>
                        </div>
                        <%--<div class="secProj">
                            <div class="item">
                                <div class="title">
                                    أسم المشروع - موقع المشروع</div>
                                <a href="#">
                                    <img src="images/Frontend/3.jpg" /></a>
                                <p>
                                    يأتى الإهتمام بالسكن كأحد أهم الأولويات التى يحتاجها الإنسان لتوفير حياة كريمة للأسرة
                                    ويراعى دائماً في اختيار الأنماط السكنية المفضلة للعملاء..</p>
                                <a class="more" href="#">تعرف علي المزيد</a>
                            </div>
                        </div>--%>
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <div id="divCompare" ng-include src="'parts/Compare.htm'">
                </div>
            </div>
        </div>
        <!-- content Area end -->
        <!-- footer Area start -->
        <footer>
        <form id="NotifyForm" name="NotifyForm" ng-submit="SendNotifyRequest()" novalidate>
			<div ng-include src="'parts/Footer.htm'">
            </div>
            </form>
	    </footer>
        <!-- footer Area end -->
    </div>
    <%--<script>
       // var IW = window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;
       // var IH = window.innerHeight || document.documentElement.clientHeight || document.body.clientHeight;

    //    $(function () {
            // var sliderBehind = IH - $('header').height();
            //            $('.searchArea, .sliderBehind .viewport').height(sliderBehind);
            //  $('.searchArea .search').css({ "margin-top": -sliderBehind + "px" });

            // $('.sliderBehind .viewport ul li').width(IW);
            //  $('.sliderBehind .viewport ul').width(IW * $('.sliderBehind .viewport ul li').length);
            //            $('.sliderBehind .viewport ul li').hide();
            //            $('.sliderArea .bottomBar .container').hide();

            //            function fadeSlider(slide, link) {
            //                alert("test");
            //                console.log(0);
            //                link.toggle(400);
            //                slide.fadeIn(200).delay(7000).queue(function () {
            //                    link.hide();
            //                    slide.hide();
            //                    link.remove();
            //                    slide.remove();
            //                    $('.sliderArea .bottomBar .container:eq(' + slide.index() + ')').after(link);
            //                    $('.sliderBehind .viewport ul li:last-child').after(slide);
            //                    setTimeout(function () { fadeSlider($('.sliderBehind .viewport ul li:first-child'), $('.sliderArea .bottomBar .container:eq(' + $('.sliderBehind .viewport ul li:first-child').index() + ')')) });
            //                });
            //            }

            //  var fadeSliderMark = setTimeout(function () { fadeSlider($('.sliderBehind .viewport ul li:first-child'), $('.sliderArea .bottomBar .container:eq(' + $('.sliderBehind .viewport ul li:first-child').index() + ')')) });

            // end search slider //

            //            $('.thirdRow .control span a').click(function () {
            //                $('.tabsBox').toggleClass('expand');
            //                $('.thirdRow .control span').toggleClass('expand');
            //                $('.thirdRow .in').slideToggle();
            //            });

            // end advanced search  //

            //            $('#signIn').click(function () {
            //                $('header .logIn').slideToggle();
            //            });

            // end login event //

            //            $('header .top_bar .flags li').click(function () {
            //                $('header .top_bar .flags').css({ "overflow": $('header .top_bar .flags').css("overflow") === "visible" ? "hidden" : "visible" });
            //            });

            // end flags event //

//            var navigatorScrollPoint = $('.navigator').position().top;
//            $(window).scroll(function () {
//                if ($(this).scrollTop() > navigatorScrollPoint) {
//                    alert('test');
//                    $('.navigator').addClass('fixed');
//                    $('.logo img').attr("src", "../images/Frontend/logoSm.png");
//                } else {
//                    $('.navigator').removeClass('fixed');
//                    $('.logo img').attr("src", "../images/Frontend/logo.jpg");
//                }
//            });


//            function toggleNavMenu(mark) {

//                if ($('ul', mark.parents('.nav')).css('display') === 'none') {

//                    $('ul', mark.parents('.nav')).slideDown(1000);
//                } else {
//                    $('ul', mark.parents('.nav')).slideUp(1000);
//                }
//            }
//            $('.nav .mark').click(function () {
//                toggleNavMenu($(this));
//            });
//            $('.nav li').click(function () {
//                if ($('.mark', $(this).parents('.nav')).css('display') === 'block') {
//                    $('ul', $(this).parents('.nav')).slideUp(1000);
//                }
//            });



            //            $('.slider').each(function () {
            //                var slider = $(this);
            //                var viewportWidth = $('.viewport', slider).width();
            //                var sliderWidth = $('.viewport li', slider).width() * $('.viewport li', slider).length;
            //                var nextStepFlag = true, previousStepFlag = true;
            //                $('.viewport li', slider).width($('.viewport li', slider).width());
            //                $('.viewport ul', slider).width(sliderWidth);

            //                $('.rightBtn', slider).click(function () {
            //                    if (nextStepFlag) {
            //                        nextStepFlag = false;
            //                        var nextStep = ((parseInt($('.viewport ul', slider).css('left')) + viewportWidth) + viewportWidth) > sliderWidth ? (sliderWidth - viewportWidth) : (parseInt($('.viewport ul', slider).css('left')) + viewportWidth);
            //                        $('.viewport ul', slider).animate({ "left": nextStep + "px" }, 1000, function () {
            //                            nextStepFlag = true;
            //                        });
            //                    }
            //                });
            //                $('.leftBtn', slider).click(function () {
            //                    if (previousStepFlag) {
            //                        previousStepFlag = false;
            //                        var previousStep = (parseInt($('.viewport ul', slider).css('left')) - viewportWidth) < 0 ? 0 : (parseInt($('.viewport ul', slider).css('left')) - viewportWidth);
            //                        $('.viewport ul', slider).animate({ "left": previousStep + "px" }, 1000, function () {
            //                            previousStepFlag = true;
            //                        });
            //                    }
            //                });
            //            });

            //		        $('.tabsBox').each(function () {
            //		            var tabsBox = $(this);		           
            //		            $('.tab', tabsBox).click(function () {
            //		                
            //		                $('.tab.active', tabsBox).toggleClass('active');
            //		                $('.tab:eq(' + $(this).index() + ')', tabsBox).addClass('active');
            //		                
            //		            });
            //		        });
     //   });
   
        $('#accountList').click(function () {
            $('.welcome').slideToggle();
        });
    </script>--%>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
    </form>
    <script>
        //         if (window.matchMedia('(max-width: 768px)').matches) {
        //              $(".searchArea").css("min-height", "60px");
        //             $("#divSearch").remove();
        //             $('header .tabsBoxSm').show();
        //         }

        var IW = window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;
        var IH = window.innerHeight || document.documentElement.clientHeight || document.body.clientHeight;
        $('.firstLoader').width(IW);
        $('.firstLoader').height(IH);

        $('.firstLoader .loadImages').css({ "margin-top": ((IH - 130) / 2) + "px" });


    </script>
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-54058681-1', 'auto');
        ga('send', 'pageview');

    </script>
    <script>
        $('#ddlSearchType , #ddlSearchCountry , #ddlSearchCity , #ddlSearchDistrict , #ddlSearchPrice , #ddlSearchArea , #ddlSearchStatus , #ddlSearchPaymentMethod , #ddlSearchCurrency ').keypress(function (event) {
            if (event.keyCode == 13) {
                $('#searchBtn').click();
            }
        });
    </script>
    <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
    <!-- Aqar Stock 2 -->
    <ins class="adsbygoogle"
        style="display: block"
        data-ad-client="ca-pub-5262922360583756"
        data-ad-slot="1250179224"
        data-ad-format="auto"></ins>
    <script>
        (adsbygoogle = window.adsbygoogle || []).push({});
    </script>
    <!-- Kissmetrics tracking snippet -->
    <script type="text/javascript">var _kmq = _kmq || [];
        var _kmk = _kmk || 'b0c17727ad60ec19d2b015267fb8cec453d768b4';
        function _kms(u) {
            setTimeout(function () {
                var d = document, f = d.getElementsByTagName('script')[0],
                s = d.createElement('script');
                s.type = 'text/javascript'; s.async = true; s.src = u;
                f.parentNode.insertBefore(s, f);
            }, 1);
        }
        _kms('//i.kissmetrics.com/i.js');
        _kms('//scripts.kissmetrics.com/' + _kmk + '.2.js');
    </script>
   

</body>
</html>
