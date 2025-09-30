<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectDetails.aspx.cs"
    Inherits="BrokerWeb.ProjectDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
    

<!-- Google Tag Manager (noscript) -->
<noscript><iframe src="https://www.googletagmanager.com/ns.html?id=GTM-K79M4WF"
height="0" width="0" style="display:none;visibility:hidden"></iframe></noscript>
<!-- End Google Tag Manager (noscript) -->

    <div class="wrapper">
        <header>
	        <div id="divHeader" ng-include src="'parts/Header.htm'" onload="LoadHeader()">
            </div>
        </header>
        <!-- content Area start -->
        <div class="content">
            <div class="container">
                <div ng-controller="ProjectDetailsController">
                    <div class="projectsSide col-md-8" id="divDetail">
                        <div class="projectInfo">
                            <div class="companyTitle">
                                <h4>
                                    <a class="back" href="javascript:void(0);" back-button>رجوع</a>
                                    <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                </h4>
                            </div>
                            <div class="map-photo">
                                <div class="projectMap col-md-6 col-sm-6">
                                    <map />
                                </div>
                                <div class="projectImg col-md-6 col-sm-6">
                                    <img id="imgLogo" runat="server" />
                                </div>
                                <div class="projectBtns">

                                    <div class="owner ProjectOwner">
                                        <a href="javascript:void(0);" ng-click="SendMail()">راسلنا</a>
                                    </div>

                                </div>
                                <div class="clear"></div>
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
                                <div class="detailsRow" style="display:none">
                                    <div class="titl">
                                        <span>الشركة المعلنة</span>
                                    </div>
                                    <div class="descrip">
                                        <asp:HyperLink ID="lnkCompanyURL" runat="server">
                                            <asp:Label ID="lblCompanyName" runat="server" />
                                        </asp:HyperLink>
                                    </div>
                                    <div class="clear">
                                    </div>
                                </div>
                                <%--     <div class="detailsRow">
                                    <div class="titl">
                                        <span>التليفون</span>
                                    </div>
                                    <div class="descrip" style="direction: ltr;">
                                        <asp:Label ID="lblPhone" Style="direction: ltr" runat="server" />
                                    </div>
                                    <div class="clear">
                                    </div>
                                </div>--%>
                                <div class="detailsRow">
                                    <div class="titl">
                                        <span>عن المشروع</span>
                                    </div>
                                    <div class="descrip">
                                        <asp:Label ID="lblDescription" runat="server" />
                                    </div>
                                    <div class="clear">
                                    </div>
                                </div>
                                <%-- <div class="detailsRow">
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
                            <div class="projectBtns">

                                <div class="owner ProjectOwner">
                                    <a href="javascript:void(0);" ng-click="SendMail()">راسلنا</a>
                                </div>
                                <div class="clear"></div>
                            </div>
                            <div class="shareIcons">
                                <!-- Go to www.addthis.com/dashboard to customize your tools -->
                                       <div class="addthis_sharing_toolbox  pull-left">
                    </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                        <div id="divProps" class="compenyAqarsP">
                            <div class="companyTitle">
                                <h4>
                                    <a class="back" ng-click="ShowProps()">المزيد</a><span>وحدات المشروع</span></h4>
                            </div>
                            <div id="divPropsLoader" class="loader">
                                <img src="images/Frontend/loading2.gif">
                            </div>
                            <div class="compeniesListP">
                                <ul>
                                    <li ng-repeat=" realestate in Props" class="col-md-4 col-sm-6 col-xs-6">
                                        <div class="item">
                                            <a ng-href="/Details/{{realestate.ID}}/{{realestate.URL}}">
                                                <div class="itemImg">
                                                    <img src="http://www.aqarstock.com/{{realestate.Logo}}" />
                                                </div>
                                                <div class="itemDetails">
                                                    <span>{{realestate.Type}} <b ng-if="realestate.Area != '0' ">{{realestate.Area}} م </b>
                                                        - {{realestate.District}}, {{realestate.City}}</span>
                                                </div>
                                            </a>
                                        </div>
                                    </li>
                                    <div class="clear">
                                    </div>
                                </ul>
                            </div>

                        </div>
                        <div id="divProjectPhotos" class="compenyAqarsP">
                            <div class="companyTitle">
                                <h4>
                                    <a class="back" ng-click="ShowPhotoAlbum()">المزيد</a><span>البومات صور المشروع</span></h4>
                            </div>
                            <div id="divPhotosLoader" class="loader">
                                <img src="images/Frontend/loading2.gif">
                            </div>
                            <div class="compeniesListP">
                                <ul>
                                    <li ng-repeat="Photo in Photos" class="col-md-4 col-sm-6 col-xs-6">
                                        <div class="item">
                                            <a ng-click="ShowPhotos(Photo.Date)">
                                                <%--   <div class="wow">
                                                <div class="wowText">
                                                    للإيجار
                                                </div>
                                            </div>--%>
                                                <div class="itemImg">
                                                    <img src="http://www.aqarstock.com/{{Photo.PhotoURL}}" />
                                                </div>
                                                <div class="itemDetails">
                                                    <span>{{Photo.Date}}</span>
                                                </div>
                                            </a>
                                        </div>
                                    </li>
                                    <%--  <li>
                                    <div class="item">
                                        <a href="#">
                                            <div class="wow">
                                                <div class="wowText">
                                                    للإيجار</div>
                                            </div>
                                            <div class="itemImg">
                                                <img src="images/Frontend/offers.jpg" /></div>
                                            <div class="itemDetails">
                                                <span>فيلا <b>245</b> م تمليك _ التجمع الخامس بمنطقة القرنفل</span></div>
                                        </a>
                                    </div>
                                </li>
                                <li>
                                    <div class="item">
                                        <a href="#">
                                            <div class="wow">
                                                <div class="wowText">
                                                    للبيع</div>
                                            </div>
                                            <div class="itemImg">
                                                <img src="images/Frontend/offers.jpg" /></div>
                                            <div class="itemDetails">
                                                <span>فيلا <b>245</b> م تمليك _ التجمع الخامس بمنطقة القرنفل</span></div>
                                        </a>
                                    </div>
                                </li>--%>
                                </ul>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                        <div id="divProjectVideos" class="projectsVideos">
                            <div class="companyTitle">
                                <h4>
                                    <a class="back" ng-click="ShowVideos()">المزيد</a><span>فيديوهات المشروع</span></h4>
                            </div>
                            <div id="divVideosLoader" class="loader">
                                <img src="images/Frontend/loading2.gif" />
                            </div>
                            <div class="compeniesList">
                                <ul id="ulVedio">
                                    <%--      <li>
                                    <div class="item">
                                         <a href="#">
                                        <div id="divVedio">
                                        
                                        </div>
                                            <div class="itemDetails">
                                                <span>{{Vedio.Name}}</span>
                                            </div>
                                        </a>
                                    </div>
                                </li>
                                   <li>
                                    <div class="item">
                                        <a href="#">
                                            <video width="100%" height="136px" controls>
                                              <source src="mov_bbb.mp4" type="video/mp4">
                                              <source src="mov_bbb.ogg" type="video/ogg">  
                                            </video>
                                            <div class="itemDetails">
                                                <span>اسم المشروع يوضع هنا</span></div>
                                        </a>
                                    </div>
                                </li>
                                <li>
                                    <div class="item">
                                        <a href="#">
                                            <div class="videoPlay">
                                                <img src="images/Frontend/video.png" />
                                            </div>
                                            <div class="itemImg">
                                                <img src="images/Frontend/offers.jpg" /></div>
                                            <div class="itemDetails">
                                                <span>اسم المشروع يوضع هنا</span></div>
                                        </a>
                                    </div>
                                </li>--%>
                                    <div class="clear">
                                    </div>
                                </ul>
                            </div>
                        </div>
                        <div id="divModels" class="compenyAqarsP">
                            <div class="companyTitle">
                                <h4>
                                    <a class="back" ng-click="ShowModels()">المزيد</a><span>نماذج المشروع</span></h4>
                            </div>
                            <div id="divModelLoader" class="loader">
                                <img src="images/Frontend/loading2.gif">
                            </div>
                            <div class="compeniesListP">
                                <ul>
                                    <li ng-repeat="Model in Models" class="col-md-4 col-sm-6 col-xs-6">
                                        <div class="item">
                                            <a ng-click="ShowModel(Model.ID)">
                                                <%--   <div class="wow">
                                                <div class="wowText">
                                                    للإيجار
                                                </div>
                                            </div>--%>
                                                <div class="itemImg">
                                                    <img src="http://www.aqarstock.com/{{Model.PlanImageURL}}" />
                                                </div>
                                                <div class="itemDetails">
                                                    <span>{{Model.Name}}</span>
                                                </div>
                                            </a>
                                        </div>
                                    </li>
                                    <%--     <li>
                                    <div class="item">
                                        <a href="#">
                                            <div class="wow">
                                                <div class="wowText">
                                                    للإيجار</div>
                                            </div>
                                            <div class="itemImg">
                                                <img src="images/Frontend/offers.jpg" /></div>
                                            <div class="itemDetails">
                                                <span>فيلا <b>245</b> م تمليك _ التجمع الخامس بمنطقة القرنفل</span></div>
                                        </a>
                                    </div>
                                </li>
                                <li>
                                    <div class="item">
                                        <a href="#">
                                            <div class="wow">
                                                <div class="wowText">
                                                    للبيع</div>
                                            </div>
                                            <div class="itemImg">
                                                <img src="images/Frontend/offers.jpg" /></div>
                                            <div class="itemDetails">
                                                <span>فيلا <b>245</b> م تمليك _ التجمع الخامس بمنطقة القرنفل</span></div>
                                        </a>
                                    </div>
                                </li>--%>
                                    <div class="clear">
                                    </div>
                                </ul>
                            </div>

                        </div>

                        <div class="projectBtns">
                            <div class="back">
                                <a href="#">رجوع</a>
                            </div>
                            <div class="owner ProjectOwner">
                                <a href="javascript:void(0);" ng-click="SendMail()">راسلنا</a>
                            </div>

                        </div>
                        <div class="clear"></div>


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
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
        <input type="hidden" id="hdnID" runat="server" />
        <input type="hidden" id="hdnLat" runat="server" />
        <input type="hidden" id="hdnLng" runat="server" />
    </form>
   
    <script>

        $('.map-photo').hover(
            function () { $('.allImages').css({ "display": "inline-block" }) }
            , function () { $('.allImages').css({ "display": "none" }) }

            );

        // adapt detailsRow height 
        $(function () {
            $('.detailsRow').each(function () {
                var detailsRowHeight = Math.max($('.titl', $(this)).height(), $('.descrip', $(this)).height());
                $('.titl, .descrip', $(this)).height(detailsRowHeight);
            });
        });

        // for compare btn
        $('.controls .compare').click(function () {
            $(this).toggleClass("checked");
            if ($('input', $(this)).val() == "unchecked") {
                $('input', $(this)).val("checked");

            } else {
                $('input', $(this)).val("unchecked");
            }

        });
    </script>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDhZ4worVs7Cyb-kk-VLbzJaLJmKyK-Z-Q">
    </script>
    <script type="text/javascript">
        
        function initialize() {
            var myLatlng = new google.maps.LatLng(30.0178661, 31.48746);
            var mapOptions = {
                zoom:8,
                center: myLatlng,
                panControl: false,
                scaleControl: false,
                zoomControl: false,
            }
            var map = new google.maps.Map(document.getElementById('map-project'), mapOptions);

            var marker = new google.maps.Marker({
                position: myLatlng,
                map: map,
                title: 'Hello World!'
            });
        }

        google.maps.event.addDomListener(window, 'load', initialize);
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
<script type="text/javascript" src="//s7.addthis.com/js/300/addthis_widget.js#pubid=ra-56de87f91ff9a0c0"></script>
    

</body>
</html>
