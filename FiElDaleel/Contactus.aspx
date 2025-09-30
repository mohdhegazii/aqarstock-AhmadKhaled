<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contactus.aspx.cs" Inherits="BrokerWeb.Contactus" %>

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
            <div class="container" ng-controller="ContactusController">
                <form name="ContactForm" class="col-md-8" id="ContactForm" ng-submit="SendMessage()"
                novalidate>
                <div class="contactArea" ng-class="{true: 'error'}[submitted && ContactForm.$invalid]">
                    <div class="Title">
                        <h4>
                            <a class="back" back-button href="javascript:void(0);">رجوع</a><span>اتصل بعقار ستوك</span></h4>
                    </div>
                    <div class="contactForm">
                        <div class="item">
                            <span class="title">الإسم</span></br>
                            <input type="text" ng-model="Contactus.Name" name="name" required />
                            <span ng-show="submitted && ContactForm.name.$error.required" class="Error">الإسم مطلوب</span>
                            <br />
                        </div>
                        <div class="item left">
                            <span class="title">رقم التليفون</span></br>
                            <input type="phone" ng-model="Contactus.Phone" name="phone" required />
                            <span ng-show="submitted && ContactForm.phone.$error.required" class="Error">رقم التليفون
                                مطلوب</span><br />
                        </div>
                        <div class="item">
                            <span class="title">البريد الإلكتروني</span></br>
                            <input type="email" ng-model="Contactus.Email" name="email" required />
                            <span ng-show="submitted && ContactForm.email.$error.required" class="Error">البريد
                                الإلكتروني مطلوب</span> <span ng-show="submitted && ContactForm.email.$error.email"
                                    class="Error">البريد الإلكتروني غير صحيح</span> </br>
                        </div>
                        <div class="item left">
                            <span class="title">رسالتك</span></br>
                            <textarea ng-model="Contactus.Message" name="message" required></textarea>
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

</body>
</html>
