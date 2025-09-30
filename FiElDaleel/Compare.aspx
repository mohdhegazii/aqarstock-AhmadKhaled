<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Compare.aspx.cs" Inherits="BrokerWeb.Compare" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" ng-app="brokerApp" ng-controller="MainController">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
     <title>عقار ستوك | محرك بحث عقارى | شقق وفيلات واراضى | للبيع والإيجار - مقارنة العقارات</title>
    <meta name="title" content="عقار ستوك | محرك بحث عقارى | شقق وفيلات واراضى | للبيع والإيجار - مقارنة العقارات" />
    <meta name="description" content="محرك بحث عقارى يوفر لكل فرصة لبيع وإيجار الشقق والاراضى والفيلل والدوبلكس وغيرها ..  بكل سهولة أون لاين مجانا بدون وسيط " />
    <meta name="keywords" content="عقارات, خريطة, جوجل إرث, فيلا, بيت, منزل, شقة, أرض, قصر, غرفة, للبيع, شراء, مطلوب, تأجير, الرياض, السعودية, دبي, أبو ظبي, الدوحة, مصر, القاهرة, اسكندرية, شقق للب" />
    <meta name='twitter:card' content="summary" />
    <meta name='twitter:title' content="عقار ستوك | محرك بحث عقارى | شقق وفيلات واراضى | للبيع والإيجار - مقارنة العقارات" />
    <meta name='twitter:url' content="http://www.aqarstock.com/" />
    <meta name='twitter:url' content="http://www.aqarstock.net/" />
    <meta name='twitter:description' content="محرك بحث عقارى يوفر لكل فرصة لبيع وإيجار الشقق والاراضى والفيلل والدوبلكس وغيرها ..  بكل سهولة أون لاين مجانا بدون وسيط" />
    <meta name='twitter:image' content="http://www.aqarstock.com/images/sociallogo.png" />
    <meta name='og:type' content="article" />
    <meta name='og:title' content="عقار ستوك | محرك بحث عقارى | شقق وفيلات واراضى | للبيع والإيجار - مقارنة العقارات" />
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
<noscript><img height="1" width="1" alt="" style="display:none" src="https://www.facebook.com/tr?id=923920740967751&amp;ev=PixelInitialized" /></noscript>
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
    window._fbq.push(['track', '6028034916005', { 'value': '0.00', 'currency': 'USD'}]);
</script>
<noscript><img height="1" width="1" alt="" style="display:none" src="https://www.facebook.com/tr?ev=6028034916005&amp;cd[value]=0.00&amp;cd[currency]=USD&amp;noscript=1" /></noscript>

</head>
<body>
<body class="rtl">
<div class="wrapper">
    <header>
		<div id="divHeader" ng-include src="'parts/Header.htm'" onload="LoadHeader()">
        </div>
	</header>

    <div class="content">
            <div class="container">
                <div class="comparePG" ng-controller="CompareController">
                    <div class="compareTitle">
                        <h4>
                            <a class="back" href="javascript:void(0);" back-Button>رجوع</a><span>قائمة قارن</span></h4>
                    </div>
                    <div class="compareBox">
                        <div class="compareFactors col-lg-2">
                            <div class="detailsRow">
                                <div class="titl">
                                    <span>صورة الوحدة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="titl">
                                    <span>العنوان</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="titl">
                                    <span>نوع الوحدة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="titl">
                                    <span>النوع</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="titl">
                                    <span>الحالة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="titl">
                                    <span>المساحة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="titl">
                                    <span>النظام</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="titl">
                                    <span>السعر الأجمالى</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="titl">
                                    <span>العملة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="titl">
                                    <span>طريقة الدفع</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="titl">
                                    <span>خصائص العقار</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="titl">
                                    <span>ملاحظات</span>
                                </div>
                            </div>
                        </div>
                        <div class="compareProjects" ng-repeat="realestate in realEstates" id="{{realestate.ID}}"  div-Compare-Prop>
                            <div class="detailsRow" >
                                <div class="descrip">
                                    <div class="photo">
                                       <!-- <div class="delete" ng-click="RemoveFromComparingList(realestate.ID)">
                                            <img src="images/Frontend/popUpClose.png" /></div> -->
                                        <div class="projectImage">
                                            <img src="http://www.aqarstock.com/{{realestate.Logo}}" /></div>
                                    </div>
                                    <div class="compareItemControls">
                                        <div class="compareItemDetails">تفاصيل</div>
                                        <div class="compareItemDelet">حذف</div>
                                    </div>
                                    <div class="clear"></div>
                                </div>
                            </div>
                            <div class="detailsRow" >
                                <div class="descrip">
                                    <span>{{realestate.Address}}</span>
                                </div>
                            </div>
                             <div class="detailsRow" >
                                <div class="descrip">
                                    <span>{{realestate.Category}}</span>
                                </div>
                            </div>
                            <div class="detailsRow" >
                                <div class="descrip">
                                    <span>{{realestate.Type}}</span>
                                </div>
                            </div>
                            <div class="detailsRow" >
                                <div class="descrip">
                                    <span>{{realestate.Status}}</span>
                                </div>
                            </div>
                            <div class="detailsRow" >
                                <div class="descrip">
                                    <span>{{realestate.Area}} م</span>
                                </div>
                            </div>
                            <div class="detailsRow" >
                                <div class="descrip">
                                    <span>{{realestate.SaleType}}</span>
                                </div>
                            </div>
                            <div class="detailsRow" >
                                <div class="descrip">
                                    <span>{{realestate.Price}}</span>
                                </div>
                            </div>
                            <div class="detailsRow" >
                                <div class="descrip">
                                    <span>{{realestate.Currency}}</span>
                                </div>
                            </div>
                            <div class="detailsRow" >
                                <div class="descrip">
                                    <span>{{realestate.PaymentType}}</span>
                                </div>
                            </div>
                            <div class="detailsRow" >
                                <div class="descrip">
                                <div ng-repeat="realestateCriteria in realestate.Criteria">
                                    <span>{{realestateCriteria.Name}}</span><span ng-show="realestateCriteria.Value == 'true'">,</span><span ng-show="realestateCriteria.Value != 'true'">:{{realestateCriteria.Value}}  <br /></span>
                              
                                    </div>
                                </div>
                            </div>
                          
                            <div class="detailsRow" >
                                <div class="descrip">
                                    <span>{{realestate.Description}}</span>
                                </div>
                            </div>
                        </div>
                        <%--<div class="compareProjects col-lg-2">
                            <div class="detailsRow a1">
                                <div class="descrip">
                                    <div class="photo">
                                        <div class="delete">
                                            <img src="images/Frontend/popUpClose.png" /></div>
                                        <div class="projectImage">
                                            <img src="images/Frontend/compareXS.png" /></div>
                                    </div>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>فيلا تمليك ، بجنينة ، التجمع الخامس - بمنطقة القرنفل</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>صورة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>الوحدة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>صورة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>صورة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>صورة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>فيلا تمليك ، بجنينة ، التجمع الخامس - بمنطقة القرنفل</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>صورة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>صورة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>صورة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>صورة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>صورة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>صورة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>صورة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>صورة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>صورة</span>
                                </div>
                            </div>
                        </div>
                        <div class="compareProjects col-lg-2">
                            <div class="detailsRow">
                                <div class="descrip">
                                    <div class="photo">
                                        <div class="delete">
                                            <img src="images/Frontend/popUpClose.png" /></div>
                                        <div class="projectImage">
                                            <img src="images/Frontend/compareXS.png" /></div>
                                    </div>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>فيلا تمليك ، بجنينة ، التجمع الخامس - بمنطقة القرنفل</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>صورة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>الوحدة الوحدة الوحدة الوحدة الوحدة الوحدة الوحدة الوحدة الوحدة الوحدة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>صورة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>صورة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>صورة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>فيلا تمليك ، بجنينة ، التجمع الخامس - بمنطقة القرنفل</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>صورة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>صورة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>صورة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>صورة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>صورة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>صورة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>صورة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>صورة</span>
                                </div>
                            </div>
                            <div class="detailsRow">
                                <div class="descrip">
                                    <span>صورة</span>
                                </div>
                            </div>
                        </div>--%>
                    </div>
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
   

</body>
</html>
