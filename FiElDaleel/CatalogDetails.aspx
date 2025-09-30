<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CatalogDetails.aspx.cs" Inherits="BrokerWeb.CatalogDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" ng-app="brokerApp" ng-controller="MainController">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>Aqar Stock</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="shortcut icon" href="favicon.ico" />
    <!-- Bootstrap -->
    <link rel="stylesheet" type="text/css" media="screen" href="styles/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" media="screen" href="styles/bootstrap-theme.min.css" />
    <link href="styles/CssStyle.css" rel="stylesheet" type="text/css" />
    <script src='../../scripts/jquery-1.11.0.min.js'></script>
    <script src='../../scripts/angular.min.js' type="text/javascript"></script>
    <script src='../../scripts/angular-route.min.js' type="text/javascript"></script>
    <script src='../../scripts/angular-ui-router.js' type="text/javascript"></script>
    <script src='../../scripts/angular-animate.min.js' type="text/javascript"></script>
    <script src='../../scripts/angular-resource.min.js' type="text/javascript"></script>
    <script src="../../scripts/Map.js" type="text/javascript"></script>
    <script src='../../scripts/FrontEndController.js' type="text/javascript"></script>
    <script src='../../scripts/services.js' type="text/javascript"></script>
    <script src='../../scripts/FrontEndDirective.js' type="text/javascript"></script>
    <script src="../../scripts/bootstrap.min.js" type="text/javascript"></script>
    <base href="/">
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
    <div class="wrapper">
        <header>
            <div id="divHeader" ng-include src="'parts/Header.htm'" onload="LoadHeader()">
            </div>
        </header>
        <div class="content">
            <div class="container">
                <div ng-controller="CatalogDetailsController">
                    <div id="divDetail" class="compenySide col-md-8">
                        <div class="compenyInfo">
                            <div class="companyTitle">
                                <h4>
                                    <a class="back" href="javascript:void(0);" back-button>رجوع</a>
                                    <asp:Label ID="lblTitle" runat="server"></asp:Label></h4>
                            </div>
                            <div class="map-photo">

                                <div class="col-md-12 col-sm-12">
                                    <img id="imgLogo" style="width: 100%" runat="server" />
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="companyDetails">

                                <div class="detailsRow">
                                    <div class="titl">
                                        <span>الوصف</span>
                                    </div>
                                    <div class="descrip">
                                        <asp:Label ID="lblDescription" runat="server" />
                                    </div>
                                    <div class="clear">
                                    </div>
                                </div>

                            </div>
                            <div class="shareIcons">
                                <!-- Go to www.addthis.com/dashboard to customize your tools -->
                                <div class="addthis_jumbo_share"></div>
                                <div class="clear">
                                </div>
                            </div>
                            <%--<div class="projectBtns">
                                <div class="owner">
                                    <a href="javascript:void(0);" ng-click="SendMail()">راسلنا</a>
                                </div>
                            </div>--%>
                            <div class="clear">
                            </div>
                        </div>
                        <div id="divCompanyProps" class="compenyAqars">
                            <div class="companyTitle">
                                <h4>
                                    <a class="back" href="javascript:void(0);" ng-click="GetProperties()">المزيد</a><span>عقارات الكتالوج</span></h4>
                            </div>
                            <div id="divPropertiesLoader" class="loader">
                                <img src="images/Frontend/loading2.gif">
                            </div>
                        <%--    <div class="compeniesList">
                                <ul>
                                    <li ng-repeat="realestate in realEstates" class="col-md-4 col-sm-6">
                                        <div class="item">
                                            <a ng-href="/Details/{{realestate.ID}}/{{realestate.URL}}">
                                                <div class="wow">
                                                    <div class="wowText">
                                                        {{realestate.SaleType}}
                                                    </div>
                                                </div>
                                                <div class="itemImg">
                                                    <img src="http://www.aqarstock.com/{{realestate.Logo}}" />
                                                </div>
                                                <div class="itemDetails">
                                                    <span>{{realestate.Type}} <b ng-if="realestate.Area != '0' ">{{realestate.Area}} م </b>
                                                        - {{realestate.District}}, {{realestate.City}}</span>
                                                </div>
                                                <div class="itemPrice">
                                                    <span ng-if="realestate.Price != '0' ">السعر: <b>{{realestate.Price}}</b> {{realestate.Currency}}</span>
                                                    <span ng-if="realestate.Price == '0' ">السعر: غير متوفر</span>
                                            </a>
                                        </div>
                                    </li>
                                </ul>
                            </div>--%>
                            <div class="searchResult col-md-12">
                    <div class="resultItems">
                        <div class="item" ng-repeat="realestate in realEstates" id="{{realestate.ID}}">
                            <div class="wow" ng-if="realestate.IsSpecial == 'True'">
                                <div class="wowText">
                                    عقار مميز
                                </div>
                            </div>
                            <div class="itemImg">
                                <a ng-href="/Details/{{realestate.ID}}/{{realestate.URL}}">
                                    <img src="http://www.aqarstock.com/{{realestate.Logo}}" alt="{{realestate.Name}}" />
                                </a>
                            </div>
                            <div class="itemDitails">
                                <a ng-href="/Details/{{realestate.ID}}/{{realestate.URL}}">
                                    <div class="itemDesc">
                                        <span>{{realestate.Type}} <b ng-if="realestate.Area != '0' ">{{realestate.Area}} م </b>
                                            - {{realestate.District}}, {{realestate.City}}</span>
                                    </div>
                                    <div class="itemPrice">
                                        <span ng-if="realestate.Price != '0' ">السعر: <b>{{realestate.Price}}</b> {{realestate.Currency}}</span>
                                        <span ng-if="realestate.Price == '0' ">السعر: غير متوفر</span>
                                    </div>
                                </a>
                                <div class="itemControls">
                                    <span class="moreDet"><a ng-href="/Details/{{realestate.ID}}/{{realestate.URL}}">عرض
                                        التفاصيل</a></span>
                                    <div class="controls">
                                        <div class="delete" value="{{realestate.ID}}" btn-delete>
                                        </div>
                                        <div class="favorite" value="{{realestate.ID}}" btn-fav>
                                        </div>
                                        <div class="compare" btn-compare value="{{realestate.ID}}">
                                            <span>قارن</span>
                                            <input type="hidden" name="unchecked" value="unchecked" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                                </div>
                            <div class="clear">
                            </div>
                        </div>

                    </div>
                    <div class="mainView" ui-view>
                    </div>

                </div>
                <div id="divSideBar" class="col-md-4" ng-include src="'parts/SideBar.htm'">
                </div>
                <div id="divCompare" ng-include src="'parts/Compare.htm'">
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <footer>
            <form id="NotifyForm" name="NotifyForm" ng-submit="SendNotifyRequest()" novalidate>
                <div ng-include src="'parts/Footer.htm'">
                </div>
            </form>
        </footer>
                <div class="clear">
                            </div>
                            <div id="divTags">
                                <div class="companyTitle">
                                    <h4><span>كلمات دالة</span></h4>
                                </div>
                                <div class="tagContent">
                                    <div id="divTagList" runat="server">
                                    </div>
                                    <%--<a ng-repeat="tag in Tags" href="{{tag.URL}}"><span>{{tag.Name}},</span></a>--%>
                                </div>
                            </div>
    </div>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
        <input type="hidden" id="hdnID" runat="server" />
        <input type="hidden" id="hdnLat" runat="server" />
        <input type="hidden" id="hdnLng" runat="server" />
    </form>
    <script type="text/javascript" src="//s7.addthis.com/js/300/addthis_widget.js#pubid=ra-54fa15520fc7431b" async="async"></script>
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
    <script src="//load.sumome.com/" data-sumo-site-id="557833ccc5a3a29e4be8b83a7168efa0c943a858ddcb66f5f8e829733dc5ce59" async="async"></script>


</body>
</html>
