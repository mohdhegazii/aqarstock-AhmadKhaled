<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyDetails.aspx.cs"
    Inherits="BrokerWeb.CompanyDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" ng-app="brokerApp" ng-controller="MainController">
<head id="Head1" runat="server">
    <!-- Google Tag Manager -->
<script>(function(w,d,s,l,i){w[l]=w[l]||[];w[l].push({'gtm.start':
new Date().getTime(),event:'gtm.js'});var f=d.getElementsByTagName(s)[0],
j=d.createElement(s),dl=l!='dataLayer'?'&l='+l:'';j.async=true;j.src=
'https://www.googletagmanager.com/gtm.js?id='+i+dl;f.parentNode.insertBefore(j,f);
})(window,document,'script','dataLayer','GTM-K79M4WF');</script>
<!-- End Google Tag Manager -->

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
    

<!-- Google Tag Manager (noscript) -->
<noscript><iframe src="https://www.googletagmanager.com/ns.html?id=GTM-K79M4WF"
height="0" width="0" style="display:none;visibility:hidden"></iframe></noscript>
<!-- End Google Tag Manager (noscript) -->

    <div class="wrapper">
        <header>
	        <div id="divHeader" ng-include src="'parts/Header.htm'" onload="LoadHeader()">
            </div>
        </header>
        <div class="content">
            <div class="container">
                <div ng-controller="CompanyDetailsController">
                    <div id="divDetail" class="compenySide col-md-8">
                        <div class="compenyInfo">
                            <div class="companyTitle">
                                <h4>
                                    <a class="back" href="javascript:void(0);" back-button>رجوع</a>
                                    <asp:Label ID="lblTitle" runat="server"></asp:Label></h4>
                            </div>
                            <div class="map-photo">
                                <div class="projectMap col-md-6 col-sm-6">
                                    <map />
                                </div>
                                <div class="projectImg col-md-6 col-sm-6">
                                    <img id="imgLogo" runat="server" />
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="companyDetails">
                                <div class="detailsRow">
                                    <div class="titl">
                                        <span>العنوان</span>
                                    </div>
                                    <div class="descrip">
                                        <asp:Label ID="lblAddress" runat="server" />
                                    </div>
                                    <div class="clear">
                                    </div>
                                </div>
                                <div class="detailsRow">
                                    <div class="titl">
                                        <span>التليفون</span>
                                    </div>
                                    <div class="descrip">
                                        <asp:Label ID="lblPhone" runat="server" />
                                    </div>
                                    <div class="clear">
                                    </div>
                                </div>
                                <div class="detailsRow">
                                    <div class="titl">
                                        <span>عن الشركة</span>
                                    </div>
                                    <div class="descrip">
                                        <asp:Label ID="lblDescription" runat="server" />
                                    </div>
                                    <div class="clear">
                                    </div>
                                </div>
                                <%--<div class="detailsRow">
                                <div class="titl">
                                    <span>الفاكس</span></div>
                                <div class="descrip">
                                    <span>وحدة سكنية</span></div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="titl">
                                    <span>الأيميل</span></div>
                                <div class="descrip">
                                    <span>وحدة سكنية</span></div>
                                <div class="clear">
                                </div>
                            </div>--%>
                            </div>
                            <div class="shareIcons">
                                   <!-- Go to www.addthis.com/dashboard to customize your tools -->
                                       <div class="addthis_sharing_toolbox  pull-left">
                    </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="projectBtns">
                                <div class="owner">
                                    <a href="javascript:void(0);" ng-click="SendMail()">راسلنا</a>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                        <div id="divCompanyProps" class="compenyAqars">
                            <div class="companyTitle">
                                <h4>
                                    <a class="back" href="javascript:void(0);" ng-click="GetProperties()">المزيد</a><span>عقارات الشركة</span></h4>
                            </div>
                            <div id="divPropertiesLoader" class="loader">
                                <img src="images/Frontend/loading2.gif">
                            </div>
                            <div class="compeniesList">
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
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                        <div id="divCompanyProjects" class="compenyProjects">
                            <div class="companyTitle">
                                <h4>
                                    <a class="back" href="javascript:void(0);" ng-click="GetProjects()">المزيد</a><span>مشاريع الشركة</span></h4>
                            </div>
                            <div id="divProjectLoader" class="loader">
                                <img src="images/Frontend/loading2.gif">
                            </div>
                            <div class="compeniesList">
                                <ul>
                                    <li ng-repeat="Project in Projects" class="col-md-4 col-sm-6">
                                        <div class="item">
                                            <a href="/مشاريع_عقارية/{{Project.ID}}/{{Project.URL}}">
                                                <%--      <div class="wow">
                                                <div class="wowText">
                                                    للإيجار
                                                </div>
                                            </div>--%>
                                                <div class="itemImg">
                                                    <img src="http://www.aqarstock.com/{{Project.Logo}}" />
                                                </div>
                                                <div class="itemDetails">
                                                    <span>{{Project.Name}}</span>
                                                </div>
                                                <div class="itemPrice">
                                                    <span>{{Project.Summary}}</span>
                                                </div>
                                            </a>
                                        </div>
                                    </li>
                                    <div class="clear">
                                    </div>
                                </ul>
                            </div>
                            <div class="projectBtns">
                                <div class="back">
                                    <a href="#">رجوع</a>
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
    </div>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
        <input type="hidden" id="hdnID" runat="server" />
        <input type="hidden" id="hdnLat" runat="server" />
        <input type="hidden" id="hdnLng" runat="server" />
    </form>
   
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
     style="display:block"
     data-ad-client="ca-pub-5262922360583756"
     data-ad-slot="1250179224"
     data-ad-format="auto"></ins>
<script>
(adsbygoogle = window.adsbygoogle || []).push({});
</script>
    <!-- Kissmetrics tracking snippet -->
<script type="text/javascript">var _kmq = _kmq || [];
var _kmk = _kmk || 'b0c17727ad60ec19d2b015267fb8cec453d768b4';
function _kms(u){
  setTimeout(function(){
    var d = document, f = d.getElementsByTagName('script')[0],
    s = d.createElement('script');
    s.type = 'text/javascript'; s.async = true; s.src = u;
    f.parentNode.insertBefore(s, f);
  }, 1);
}
_kms('//i.kissmetrics.com/i.js');
_kms('//scripts.kissmetrics.com/' + _kmk + '.2.js');
</script> 
<script type="text/javascript" src="//s7.addthis.com/js/300/addthis_widget.js#pubid=ra-56de87f91ff9a0c0"></script>
   

</body>
</html>
