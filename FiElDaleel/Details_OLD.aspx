<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details_OLD.aspx.cs" Inherits="BrokerWeb.Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" ng-app="brokerApp" ng-controller="MainController">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="all" name="robots" />
    <title></title>
    <meta name="description" content="" />
    <meta name="keywords" content="عقارات, خريطة, جوجل إرث, فيلا, بيت, منزل, شقة, أرض, قصر, غرفة, للبيع, شراء, مطلوب, تأجير, الرياض, السعودية, دبي, أبو ظبي, الدوحة, مصر, القاهرة, اسكندرية, شقق للب" />
    <link href="styles/style.css" rel="stylesheet" />
    <link href="styles/jquery-ui.css" rel="stylesheet" />
    <link href="styles/jqueryUIedit.css" rel="stylesheet" />
    <link href="styles/jquery.ui.slider-rtl.css" rel="stylesheet" />
    <link href="styles/response.css" rel="stylesheet" />
    <script src="../../scripts/angular.min.js" type="text/javascript"></script>
    <script src="../../scripts/angular-route.min.js" type="text/javascript"></script>
    <script src="../../scripts/angular-ui-router.min.js" type="text/javascript"></script>
    <script src="../../scripts/angular-animate.min.js" type="text/javascript"></script>
    <script src="../../scripts/angular-resource.min.js" type="text/javascript"></script>
    <script src="../../scripts/Map.js" type="text/javascript"></script>
    <script src="../../scripts/DetailController.js" type="text/javascript"></script>
    <script src="../../scripts/directives.js" type="text/javascript"></script>
    <script src="../../scripts/factories.js" type="text/javascript"></script>
    <script src="../../scripts/services.js" type="text/javascript"></script>
    <script src="../../scripts/jquery-2.1.0.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery.ui.touch-punch.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery.ui.slider-rtl.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery.cycle2.min.js" type="text/javascript"></script>
    <base href="/">
    <!-- Facebook Conversion Code for Mastery House Visites -->
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
        <img height="1" width="1" alt="" style="display: none" src="https://www.facebook.com/tr?id=923920740967751&amp;ev=PixelInitialized" /></noscript>
    <script type="text/javascript">
        $(document).ready(function () {
            //$('.map').height($('.property').height());
        });

    </script>
    <style>
        .unitsInfo
        {
            padding: 2px;
        }
    </style>
</head>
<body>
    <%--   <asp:HiddenField ID="hdnID" ng-model="ID" runat="server" />--%>
    <input type="hidden" id="hdnID" runat="server" />
    <input type="hidden" id="hdnLat" runat="server" />
    <input type="hidden" id="hdnLng" runat="server" />
    <div class="background" data-cycle-log="false" cycle="{fx: 'fade',slides: '> div',timeout: 6000,speed: 2000}">
        <div class="backgroundUnit" style="background-image: url(images/backgrounds/1.jpg)">
        </div>
        <div class="backgroundUnit" style="background-image: url(images/backgrounds/2.jpg)">
        </div>
        <div class="backgroundUnit" style="background-image: url(images/backgrounds/3.jpg)">
        </div>
    </div>
    <div class="content">
        <nav class="top">
            <div class="navCore">
                <a class="payment" href="javascript:void(0);" top-search-link><span>إبحث </span>بالنظام</a>
                <a class="type" href="" top-search-link><span>إبحث </span>بالنوع</a>
                <a class="location" href="" top-search-link><span>إبحث </span>بالمكان</a>
                <a class="price" href="" top-search-link><span>إبحث </span>بالسعر</a>
                <a class="area" href="" top-search-link><span>إبحث </span>بالمساحة</a>
                <a class="advanced" href="/index.html#!/Units/AdvancedSearch"><span>إبحث </span>المفصل</a>
                <a class="miniMenu" href="javascript:void(0);" ng-click="miniMenu()">القائمة</a>
            </div>
        </nav>
        <div class="unitsInfo">
        </div>
        <aside>
            <a class="logo" href="index.html">
                <img src="images/logo.png" /></a>
            <div class="topSocial">
                <div class="topSocialUnit">
                    <div class="fb-like" data-href="https://www.facebook.com/aqarstock" data-layout="button_count" data-action="like" data-show-faces="false" data-share="false"></div>
                </div>
                <div class="topSocialUnit">
                    <a href="https://www.twitter.com/aqar_stock" class="twitter-follow-button" data-show-count="false" data-show-screen-name="false">Follow @aqar_stock</a>
                </div>
                <div class="topSocialUnit">
                     <div class="g-plusone" data-annotation="none" data-size="medium" data-href="http://www.aqarstock.com/#!/"></div>

                </div>
            </div>
            <nav>
                <a href='/index.html#!/'>الرئيسية</a>
                <a href="/login" class="addYourProperty">أضف عقارك</a>
                <a href="/index.html#!/Units/AboutUs">تعرف على عقار ستوك</a>
                <a ng-click="SearchByCategory(1,'وحدات سكنية')">وحدات سكنية</a>
                <a ng-click="SearchByCategory(2,'وحدات تجارية')">وحدات تجارية</a>
                <a ng-click="SearchByCategory(3,'اراضى')">اراضى</a>
                <a ng-click="SearchByNew()">أخر الوحدات المضافة</a>
                <a href="/index.html#!/Units/AdvancedSearch">البحث المفصل</a>
                <!--<a href="">الخريطة</a>-->
                <a href="/index.html#!/Units/ContactUs">اتصل بنا</a>
                <div class="copyrights">
                    <p>جميع الحقوق محفوظة لعقار ستوك 2014</p>
                    <p>تطوير <a href="http://masteryit.com/" target="_blank">
                        <img src="images/icons/masteryIT.png" /></a></p>
                </div>
            </nav>
        </aside>
        <div class="core">
            <div class="units">
                <div class="property" id="divDetails">
                    <div class="propertyHalf">
                        <div class="propertyTitle">
                            <h1>
                                <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                <div class="clear">
                                </div>
                                <asp:Label ID="lblType" class="propertyType" runat="server"></asp:Label>
                                <asp:Label ID="lblSaleType" class="saleType" runat="server"></asp:Label>
                                <%--      <span class="propertyType">{{realestate.Type}}</span> 
             <span class="saleType">{{realestate.SaleType}}</span>--%>
                            </h1>
                            <div id="Social" class="detailsSocial">
                                <script src="//platform.linkedin.com/in.js" type="text/javascript">
                                    lang: en_US
                                </script>
                                <script type="IN/Share" data-counter="right"></script>
                                <div class="g-plus" data-action="share" data-annotation="bubble">
                                </div>
                                <a href="https://twitter.com/share" class="twitter-share-button" data-count="none">Tweet</a>
                                <div class="fb-share-button" data-type="button_count" data-href='{{URL}}'>
                                </div>
                            </div>
                        </div>
                        <div class="propertyDesc">
                            <p id="lblDescription" runat="server">
                            </p>
                        </div>
                        <div class="propertyDesc propertyDetails">
                            <p class="location">
                                <span>العنوان: </span>
                                <asp:Label ID="lblAddress" runat="server" />
                            </p>
                            <p class="area">
                                <span>المساحة: </span>
                                <asp:Label ID="lblArea" runat="server" />
                            </p>
                            <p class="case">
                                <span>الحالة: </span>
                                <asp:Label ID="lblStatus" runat="server" />
                            </p>
                            <p class="price">
                                <span>السعر: </span>
                                <asp:Label ID="lblPrice" runat="server" />
                            </p>
                            <p class="payment">
                                <span>طريقة السداد: </span>
                                <asp:Label ID="lblPaymentType" runat="server" />
                            </p>
                            <p ng-repeat="realestateCriteria in Criterias">
                                <span>{{realestateCriteria.Name}}: </span><span ng-show="realestateCriteria.Value == 'true'">
                                    متوفر</span> <span ng-show="realestateCriteria.Value != 'true'">{{realestateCriteria.Value}}</span>
                            </p>
                        </div>
                        <div class="propertyImage">
                            <img id="imgLogo" runat="server" src="">
                            <div class="propertyLinks">
                                <a ng-click="ShowPhotos()">معرض الصور</a>
                            </div>
                        </div>
                    </div>
                    <div class="propertyHalf propertyHalfLeft">
                        <div class="propertyLinks">
                            <a ng-click="ShowRequestForm()" class="salesRequest">طلب {{SaleType}}</a> <a ng-click="ShowComplainForm()">
                                تقدم بشكوى</a> <a href back-button>رجوع</a>
                        </div>
                        <map />
                        <!--   <div id="MyMap" class="map">-->
                        <!--    <iframe width="100%" height="100%" frameborder="0" style="border:0" src="https://www.google.com/maps/embed/v1/place?key=AIzaSyDFVt9cIFtqLuOizgH-N0kbyYCiys-DmEQ &q=31.2547189335695,30.0007438659668 ">
</iframe>-->
                        <!--    <iframe src="https://www.google.com/maps/embed?pb=!1m10!1m8!1m3!1d55291.32281224635!2d31.294066000000004!3d29.98783!3m2!1i1024!2i768!4f13.1!5e0!3m2!1sen!2sus!4v1404960400138" width="100%" height="100%" frameborder="0" style="border:0"></iframe>-->
                        <!-- </div>-->
                    </div>
                </div>
                <div class="mainView" ui-view>
                </div>
                <div id='divloading' style="display: none" ng-include src="'parts/loading.html'">
                </div>
                <div class="overlay">
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
    </div>
    <div ng-include src="'parts/searchCircles.html'">
    </div>
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
    <div id="fb-root">
    </div>
    <script>        (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0]; if (d.getElementById(id))
                return; js = d.createElement(s); js.id = id; js.src = "//connect.facebook.net/en_US/sdk.js#xfbml=1&version=v2.0";
            fjs.parentNode.insertBefore(js, fjs);
        } (document, 'script', 'facebook-jssdk'));</script>
    <script type="text/javascript">        window.___gcfg = { lang: 'en-GB' }; (function () {
            var po = document.createElement('script'); po.type = 'text/javascript'; po.async
    = true; po.src = 'https://apis.google.com/js/platform.js'; var s = document.getElementsByTagName('script')[0];
            s.parentNode.insertBefore(po, s);
        })(); </script>
    <script>
        !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } } (document, 'script', 'twitter-wjs');</script>
</body>
</html>
