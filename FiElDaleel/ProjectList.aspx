<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectList.aspx.cs" Inherits="BrokerWeb.ProjectList" %>

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
<!-- Google Tag Manager -->
<script>(function(w,d,s,l,i){w[l]=w[l]||[];w[l].push({'gtm.start':
new Date().getTime(),event:'gtm.js'});var f=d.getElementsByTagName(s)[0],
j=d.createElement(s),dl=l!='dataLayer'?'&l='+l:'';j.async=true;j.src=
'https://www.googletagmanager.com/gtm.js?id='+i+dl;f.parentNode.insertBefore(j,f);
})(window,document,'script','dataLayer','GTM-K79M4WF');</script>
<!-- End Google Tag Manager -->

    <meta charset="utf-8" />
    <title>عقار ستوك | محرك بحث عقارى | شقق وفيلات واراضى | للبيع والإيجار - مشروعات عقارية</title>
    <meta name="title" content="عقار ستوك | محرك بحث عقارى | شقق وفيلات واراضى | للبيع والإيجار - مشروعات عقارية" />
    <meta name="description" content="محرك بحث عقارى يوفر لكل فرصة لبيع وإيجار الشقق والاراضى والفيلل والدوبلكس وغيرها ..  بكل سهولة أون لاين مجانا بدون وسيط " />
    <meta name="keywords" content="عقارات, خريطة, جوجل إرث, فيلا, بيت, منزل, شقة, أرض, قصر, غرفة, للبيع, شراء, مطلوب, تأجير, الرياض, السعودية, دبي, أبو ظبي, الدوحة, مصر, القاهرة, اسكندرية, شقق للب" />
    <meta name='twitter:card' content="summary" />
    <meta name='twitter:title' content="عقار ستوك | محرك بحث عقارى | شقق وفيلات واراضى | للبيع والإيجار - مشروعات عقارية" />
    <meta name='twitter:url' content="http://www.aqarstock.com/" />
    <meta name='twitter:url' content="http://www.aqarstock.net/" />
    <meta name='twitter:description' content="محرك بحث عقارى يوفر لكل فرصة لبيع وإيجار الشقق والاراضى والفيلل والدوبلكس وغيرها ..  بكل سهولة أون لاين مجانا بدون وسيط" />
    <meta name='twitter:image' content="http://www.aqarstock.com/images/sociallogo.png" />
    <meta name='og:type' content="article" />
    <meta name='og:title' content="عقار ستوك | محرك بحث عقارى | شقق وفيلات واراضى | للبيع والإيجار - مشروعات عقارية" />
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

    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="shortcut icon" href="favicon.ico" />
    <!-- Bootstrap -->
    <base href="/" />
    <link rel="stylesheet" type="text/css" media="screen" href="styles/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" media="screen" href="styles/bootstrap-theme.min.css" />
    <link href="styles/CssStyle.css" rel="stylesheet" type="text/css" />
    <script src="scripts/jquery-1.11.0.min.js"></script>
    <script src="scripts/angular.min.js" type="text/javascript"></script>
    <script src="scripts/angular-route.min.js" type="text/javascript"></script>
    <script src="scripts/angular-ui-router.js" type="text/javascript"></script>
    <script src="scripts/angular-animate.min.js" type="text/javascript"></script>
    <script src="scripts/angular-resource.min.js" type="text/javascript"></script>
    <script src="scripts/FrontEndController.js" type="text/javascript"></script>
    <script src="scripts/services.js" type="text/javascript"></script>
    <script src="scripts/FrontEndDirective.js" type="text/javascript"></script>
    <script src="../../scripts/bootstrap.min.js" type="text/javascript"></script>
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
                <div class="compenies col-md-8" ng-controller="ProjectListController">
                    <div class="Title">
                        <h4>
                            <span>مشاريع عقارية</span></h4>
                    </div>
                    <div class="compeniesList">
                        <div class="compeny ComanyItem" ng-repeat="Project in Projects">
                            <a ng-href="/مشاريع_عقارية/{{Project.ID}}/{{Project.URL}}">
                                <div class="companyImg">
                                    <img src="http://www.aqarstock.com/{{Project.Logo}}" alt="{{Project.ProjectName}}" />
                                </div>
                            </a>
                            <div class="companyDes">
                                <div class="companyTitle">
                                    <a ng-href="/مشاريع_عقارية/{{Project.ID}}/{{Project.URL}}">
                                    <span>{{Project.ProjectName}}</span>
                                        </a>
                                </div>
                                <hr />
                           <%--     <div class="companyTxt">
                                    <span> <a href="/شركات_عقارية/{{Project.CompanyURL}}" target="_blank">
                                        المسوق: {{Project.CompanyName}}
                                    </a></span>
                                    </div>--%>
                                <div class="companyTxt">
                                    <span>{{Project.Summary}} </span>
                                </div>
                                <div class="moreBtn">
                                    <span><a ng-href="/مشاريع_عقارية/{{Project.ID}}/{{Project.URL}}">تعرف على المزيد</a></span>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div id="divListLoading" class="loader">
                        <img src="images/Frontend/loading2.gif" />
                    </div>
                    <div class="pageController">
                        <div class="prevBtn" ng-click="PreviousPage()">
                        </div>
                        <div class="firstOne" style="display: none">
                            <a href="javascript:void(0);" ng-click="MoveTo(FirstPage)">{{FirstPage}}</a>
                        </div>
                        <div id="divFirstPage" class="dottes" style="display: none">
                            <span>...</span>
                        </div>
                        <div class="numbers">
                            <ul>
                                <li class="number" ng-repeat="page in Pages" id="{{page}}" paging ng-click="MoveTo(page)">
                                    <a href="javascript:void(0);">{{page}}</a>

                                </li>
                            </ul>
                        </div>
                        <div id="divLastPage" class="dottes">
                            <span>...</span>
                        </div>
                        <div class="lastOne">
                            <a href="javascript:void(0);" ng-click="MoveTo(LastPage)">{{LastPage}}</a>
                        </div>
                        <div class="nextBtn" ng-click="NextPage()">
                        </div>
                        <div class="clear">
                        </div>
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
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
            </asp:ScriptManager>
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
       

</body>
</html>
