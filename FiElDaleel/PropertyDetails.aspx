<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PropertyDetails.aspx.cs"
    Inherits="BrokerWeb.PropertyDetails" %>

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
    <%--<link rel="Stylesheet" type="text/css" media="all" href="http://ct1.addthis.com/static/r07/widget110.css" />--%>
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
        })();
        window._fbq = window._fbq || [];
        window._fbq.push(['track', '6028034916005', { 'value': '0.00', 'currency': 'USD'}]);
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
                <div class="projectSide col-md-8" ng-controller="PropertDetailController">
                    <div class="projectTitle">
                        <h4>
                            <a class="back" ng-href="/Details/{{URL}}" ng-click="BackToDetail()">رجوع</a>
                            <%--  <span>فيلا <b>245</b> م تمليك ، بجنينة <b>70</b> م
                                - التجمع الخامس بمنطقة القرنفل</span>--%>
                            <asp:Label ID="lblTitle" runat="server"></asp:Label>
                        </h4>
                    </div>
                    <div id="divDetail">
                        <div class="map-photo">
                            <div class="projectMap col-md-6 col-sm-6">
                                <map />
                            </div>
                            <div class="projectImg col-md-6 col-sm-6" img-defult>
                                <img id="imgLogo" runat="server" />
                            </div>
                            <div class="allImages" img-defult ng-click="ShowPhotos()">
                                <span>عرض الصور</span>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="projectBtns">
                            <div class="buyOrder">
                                <a href="javascript:void(0);" ng-click="ShowRequest()">راسل المالك</a>
                            </div>
                            <div class="complaint">
                                <a href="javascript:void(0);" ng-click="ShowComplain()">تقديم شكوى</a>
                            </div>
                            <div class="owner">
                                <a href="javascript:void(0);" ng-click="ShowOwnerData()">بيانات المالك</a>
                            </div>
                            <div class="clear">
                            </div>
                            <br />
                        </div>
                             <div class="shareIcons">
                            <div class="addthis_sharing_toolbox  pull-left">
                    </div>
                        <div class="clear">
                        </div>
                    </div>
                    <br />
                        <div class="projectDetails">
                            <div class="detailsRow" details-row>
                                <div class="titl">
                                    <span>عنوان الاعلان</span>
                                </div>
                                <div class="descrip">
                                    <asp:Label ID="lblAdvTitle" runat="server"></asp:Label>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="detailsRow" style="display: none" details-row>
                                <div class="titl">
                                    <span>تاريخ الاضافة</span>
                                </div>
                                <div class="descrip">
                                    <asp:Label ID="lblDate" runat="server"></asp:Label>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="detailsRow" details-row>
                                <div class="titl">
                                    <span>العنوان</span>
                                </div>
                                <div class="descrip">
                                    <asp:Label ID="lblAddress" runat="server" />
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="detailsRow" details-row>
                                <div class="titl">
                                    <span>نوع الوحدة</span>
                                </div>
                                <div class="descrip">
                                    <asp:Label ID="lblCategory" runat="server"></asp:Label>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="detailsRow" details-row>
                                <div class="titl">
                                    <span>النوع</span>
                                </div>
                                <div class="descrip">
                                    <asp:Label ID="lblType" class="propertyType" runat="server"></asp:Label>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="detailsRow" details-row>
                                <div class="titl">
                                    <span>الحالة</span>
                                </div>
                                <div class="descrip">
                                    <asp:Label ID="lblStatus" runat="server" />
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="detailsRow" details-row>
                                <div class="titl">
                                    <span>المساحة</span>
                                </div>
                                <div class="descrip">
                                    <asp:Label ID="lblArea" runat="server" />
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="detailsRow" details-row>
                                <div class="titl">
                                    <span>النظام</span>
                                </div>
                                <div class="descrip">
                                    <asp:Label ID="lblSaleType" runat="server" />
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="detailsRow" details-row>
                                <div class="titl">
                                    <span>السعر الأجمالى</span>
                                </div>
                                <div class="descrip">
                                    <asp:Label ID="lblPrice" runat="server" />
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="detailsRow" details-row>
                                <div class="titl">
                                    <span>العملة</span>
                                </div>
                                <div class="descrip">
                                    <asp:Label ID="lblCurrency" runat="server" />
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="detailsRow" details-row>
                                <div class="titl">
                                    <span>طريقة السداد</span>
                                </div>
                                <div class="descrip">
                                    <asp:Label ID="lblPaymentType" runat="server" />
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="detailsRow" ng-repeat="realestateCriteria in Criterias" details-row>
                                <div class="titl">
                                    <span>{{realestateCriteria.Name}}</span>
                                </div>
                                <div class="descrip">
                                    <span ng-show="realestateCriteria.Value == 'true'">متوفر</span> <span ng-show="realestateCriteria.Value != 'true'">
                                        {{realestateCriteria.Value}}</span>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="detailsRow" details-row>
                                <div class="titl">
                                    <span>ملاحظات</span>
                                </div>
                                <div class="descrip">
                                    <asp:Label ID="lblDescription" runat="server" />
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="mainView" ui-view>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="projectControl">
                        <div class="controls">
                            <div class="delete" detail-backbutton>
                            </div>
                            <div class="favorite" value="{{ID}}" btn-fav>
                            </div>
                            <div class="compare" btn-compare value="{{ID}}">
                                <span>قارن</span>
                                <input type="hidden" name="unchecked" value="unchecked" />
                            </div>
                        </div>
                    </div>
                    <!-- Go to www.addthis.com/dashboard to customize your tools -->
                    <%--<div class="addthis_sharing_toolbox"></div>--%>
            
                    <div class="shareIcons">
                            <div class="addthis_sharing_toolbox pull-left">
                    </div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="projectBtns">
                        <div class="buyOrder">
                            <a href="javascript:void(0);" ng-click="ShowRequest()">راسل المالك</a>
                        </div>
                        <div class="complaint">
                            <a href="javascript:void(0);" ng-click="ShowComplain()">تقديم شكوى</a>
                        </div>
                        <div class="owner">
                            <a href="javascript:void(0);" ng-click="ShowOwnerData()">بيانات المالك</a>
                        </div>
                        <div class="back">
                            <a href="javascript:void(0);"  ng-href="/Details/{{URL}}" ng-click="BackToDetail()">رجوع</a>
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
        <%--   <div class="mainView" ui-view>
                </div>--%>
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
    <input type="hidden" id="hdnURL" runat="server" />
    <input type="hidden" id="hdnLat" runat="server" />
    <input type="hidden" id="hdnLng" runat="server" />
    <input type="hidden" id="hdnCompanyName" runat="server" />
    <input type="hidden" id="hdnCompanyPhone" runat="server" />
    <input type="hidden" id="hdnSubscriberID" runat="server" />
    </form>
    <%--<script>

//        $('.projectImg').hover(
//            function () { $('.allImages').css({ "display": "inline-block" }) }
//            , function () { $('.allImages').css({ "display": "none" }) }

//            );

        // adapt detailsRow height 
//        $(function () {
//            $('.detailsRow').each(function () {
//                var detailsRowHeight = Math.max($('.titl', $(this)).height(), $('.descrip', $(this)).height());
//                $('.titl, .descrip', $(this)).height(detailsRowHeight);
//            });
//        });

        // for compare btn
//        $('.controls .compare').click(function () {
//            $(this).toggleClass("checked");
//            if ($('input', $(this)).val() == "unchecked") {
//                $('input', $(this)).val("checked");

//            } else {
//                $('input', $(this)).val("unchecked");
//            }

//        });
    </script>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDhZ4worVs7Cyb-kk-VLbzJaLJmKyK-Z-Q">
    </script>
    <script type="text/javascript">
        
//        function initialize() {
//            var myLatlng = new google.maps.LatLng(30.0178661, 31.48746);
//            var mapOptions = {
//                zoom:8,
//                center: myLatlng,
//                panControl: false,
//                scaleControl: false,
//                zoomControl: false,
//            }
//            var map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);

//            var marker = new google.maps.Marker({
//                position: myLatlng,
//                map: map,
//                title: 'Hello World!'
//            });
//        }

//        google.maps.event.addDomListener(window, 'load', initialize);
    </script>--%>
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
    <ins class="adsbygoogle" style="display: block" data-ad-client="ca-pub-5262922360583756"
        data-ad-slot="1250179224" data-ad-format="auto"></ins>
    <script>
        (adsbygoogle = window.adsbygoogle || []).push({});
    </script>
    <!-- Kissmetrics tracking snippet -->
    <script type="text/javascript">        var _kmq = _kmq || [];
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
    <!-- Go to www.addthis.com/dashboard to customize your tools -->
    <script type="text/javascript" src="//s7.addthis.com/js/300/addthis_widget.js#pubid=ra-56de87f91ff9a0c0"></script>
    <%--<script src="http://s7.addthis.com/js/300/addthis_widget.js" type="text/javascript"></script>--%>
   
</body>
</html>
