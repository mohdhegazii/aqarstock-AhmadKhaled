<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="aboutus.aspx.cs" Inherits="BrokerWeb.aboutus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" ng-app="brokerApp" ng-controller="MainController">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>عقار ستوك | محرك بحث عقارى | شقق وفيلات واراضى | للبيع والإيجار - الدعم الفنى</title>
    <meta name="title" content="عقار ستوك | محرك بحث عقارى | شقق وفيلات واراضى | للبيع والإيجار - الدعم الفنى" />
    <meta name="description" content="محرك بحث عقارى يوفر لكل فرصة لبيع وإيجار الشقق والاراضى والفيلل والدوبلكس وغيرها ..  بكل سهولة أون لاين مجانا بدون وسيط " />
    <meta name="keywords" content="عقارات, خريطة, جوجل إرث, فيلا, بيت, منزل, شقة, أرض, قصر, غرفة, للبيع, شراء, مطلوب, تأجير, الرياض, السعودية, دبي, أبو ظبي, الدوحة, مصر, القاهرة, اسكندرية, شقق للب" />
    <meta name='twitter:card' content="summary" />
    <meta name='twitter:title' content="عقار ستوك | محرك بحث عقارى | شقق وفيلات واراضى | للبيع والإيجار - الدعم الفنى" />
    <meta name='twitter:url' content="http://www.aqarstock.com/" />
    <meta name='twitter:url' content="http://www.aqarstock.net/" />
    <meta name='twitter:description' content="محرك بحث عقارى يوفر لكل فرصة لبيع وإيجار الشقق والاراضى والفيلل والدوبلكس وغيرها ..  بكل سهولة أون لاين مجانا بدون وسيط" />
    <meta name='twitter:image' content="http://www.aqarstock.com/images/sociallogo.png" />
    <meta name='og:type' content="article" />
    <meta name='og:title' content="عقار ستوك | محرك بحث عقارى | شقق وفيلات واراضى | للبيع والإيجار - الدعم الفنى" />
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
</head>
<body class="rtl">
    <div class="wrapper">
        <header>
		<div id="divHeader" ng-include src="'parts/Header.htm'" onload="LoadHeader()">
        </div>
	</header>
        <div class="content">
            <div class="container">
                <div class="about col-md-8">
                    <div class="Title">
                        <h4>
                            <a class="back" back-button href="javascript:void(0);">رجوع</a><span>تعرف علي عقار ستوك</span></h4>
                    </div>
                    <div class="aboutDetails">
                        <p>
                            عقار ستوك – إحدى الخدمات الأحدث المقدمة من<a href="http://www.masteryit.com/en/" target="_blank"> ماسترى آى تى</a> لنظم المعلومات ش.م.م بدأت
                            من القاهرة وأنطلقت لتغطى خدماتها جمهورية مصر العربية بفريق من خبراء المجال العقارى
                            وخبراء التسويق والبرمجيات , استطاع عقار ستوك ان يقدم حلول عقارية متكاملة تبدأ من
                            موقع الألكتروني يعمل كمحرك بحث عقارى يسعى إلى توفير العروض العقارية القيمة التي
                            يمكن إضافتها بكل سهولة من قبل المستخدمين و كذلك يمكن للزوار البحث عنها و تصفحها
                            بشكل فعال و سريع. يشتمل الموقع على شتى أنواع العقارات من قطاعات عديدة و متنوعة.
                            تفضل بالتسجيل الآن و اكتشف عالم جديد من الإمكانيات و الفرص.</p>
                        <p>
                            ولتمد خدمات فريق عقار ستوك لتشمل تقديم كافة الاستشارات الفنية لقطاع العقارات المصرى
                            وقريبا فى الشرق الاوسط كله فى خدمات التسويق وفهم متغيرات بيئة التسويق ومطلبات العميل
                            سواء لشركات التسويق العقارى والسمسرة امتدادا لشركات الاستثمار والتمويل العقارى.
                            وبفهم اعمق لمطلبات تكنولوجيا التسويق الحديثة عبر الأنترنت يستطيع عقار ستوك ان يوصل
                            عقارك ومشروعك العقارى إلى مستويات ابعد من خلق الفرص التسويقة عبر ادوات الشبكات الأجتماعية
                            وادوات جووجل وميكروسوفت وغيرهم من الأدوات التسويقية المتاحة.</p>
                        <p>
                            <span>لمزيد من المعلومات عن خدمات عقار ستوك التسويقة للشركات إتصل بنا على
                                0238383863</span></br> <span>للأتصال بفريق عقار ستوك للدعم الفني للأفراد والشركات اتصل
                                    بنا على 01000950801</span></br> 
                        </p>
                    </div>
                    <%--  <div class="backAbout" back-button>
                        <a href="javascript:void(0);">رجوع</a></div>--%>
                        <div ng-controller="ContactusController">
                    <form name="ContactForm" id="ContactForm" ng-submit="SendMessage()" novalidate>
                    <div class="contactArea" ng-class="{true: 'error'}[submitted && ContactForm.$invalid]">
                        <div class="Title">
                            <h4>
                                <%--<a class="back" back-button href="javascript:void(0);">رجوع</a>--%>
                                <span>اتصل بعقار ستوك</span></h4>
                        </div>
                        <div class="contactForm">
                            <div class="item">
                                <span class="title">الإسم</span></br>
                                <input type="text" id="contactName" ng-model="Contactus.Name" name="name" required />
                                <span ng-show="submitted && ContactForm.name.$error.required" class="Error">الإسم مطلوب</span>
                                <br />
                            </div>
                            <div class="item left">
                                <span class="title">رقم التليفون</span></br>
                                <input type="phone" id="contactPhone" ng-model="Contactus.Phone" name="phone" required data-container="body" data-toggle="popover" data-placement="bottom" data-content="  الرجاء ادخال كود البلد المقيم بها" />
                                <span ng-show="submitted && ContactForm.phone.$error.required" class="Error">رقم التليفون
                                    مطلوب</span><br />
                            </div>
                            <div class="item">
                                <span class="title">البريد الإلكتروني</span></br>
                                <input type="email" id="contactMail" ng-model="Contactus.Email" name="email" required />
                                <span ng-show="submitted && ContactForm.email.$error.required" class="Error">البريد
                                    الإلكتروني مطلوب</span> <span ng-show="submitted && ContactForm.email.$error.email"
                                        class="Error">البريد الإلكتروني غير صحيح</span> </br>
                            </div>
                            <div class="item left">
                                <span class="title">رسالتك</span></br>
                                <textarea id="contactMssg" ng-model="Contactus.Message" name="message" required></textarea>
                                <span ng-show="submitted && ContactForm.message.$error.required" class="Error">الرسالة
                                    مطلوب</span><br />
                            </div>
                            <div class="item">
                            </div>
                            <div class="clear">
                            </div>
                            <div class="actions">
                                <div class="saveBtn">
                                    <%-- <input class="orang" type="submit" value="أرسل" />--%>
                                    <button id="btnSend" class="orang send" type="submit" ng-click="submitted=true">
                                        إرسال</button>
                                </div>
                                <div class="resetBtn">
                                    <input class="gray" type="reset" value="مسح" />
                                </div>
                            </div>
                        </div>
                    </div>
                    </form>
                    </div>
                </div>
                <div id="divSideBar" class="col-md-4" ng-include src="'parts/SideBar.htm'">
                </div>
                <div id="divCompare" ng-include src="'parts/Compare.htm'">
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

    <script>

        $('#contactName , #contactPhone , #contactMail , #contactMssg').keypress(function (event) {
            if (event.keyCode == 13) {
                $('#btnSend').click();
            }
        });
        $("#contactPhone").focusin(function () {
            $("#contactPhone").popover('show');
        });
        $("#contactPhone").focusout(function () {
            $("#contactPhone").popover('hide');
        });
    </script>

</body>
</html>
