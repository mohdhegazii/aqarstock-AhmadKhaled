<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucHeader.ascx.cs" Inherits="BrokerWeb.Backend.Admin.UserControls.ucHeader" %>

<nav class="navbar navbar-default navbar-fixed-top navbar-admin" role="navigation" style="margin-bottom: 0">
    <div class="navbar-header pull-right  col-xs-12">
        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
            <span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span><span
                class="icon-bar"></span><span class="icon-bar"></span>
        </button>
     <%--   <a class="navbar-brand pull-right" href="~/الرئيسية" runat="server" target="_blank"><asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label><i class="fa fa-external-link fa-fw"></i>

            <div class="tooltip left logoTip" role="tooltip"><div class="tooltip-arrow"></div><div class="tooltip-inner">الذهاب إلى صفحة البحث</div></div>
        </a>--%>
    </div>
    <div class="pull-right navbar-collapse collapse col-lg-12 col-sm-12 col-xs-12">
        <ul class="nav navbar-nav navbar-right">
        <li class="pull-right"><a href="/الرئيسية" target="_blank"><i class="fa fa-home fa-fw"></i>الرئيسية</a></li>
            <li class="pull-right"><a href="/AdminDashboard"><i class="fa fa-th-list fa-fw"></i>اخر الاضافات</a></li>
              <li class="  pull-right"><a href="/MessagesList"><i class="fa fa-envelope fa-fw"></i>الرسائل<asp:Label ID="lblUnReadMsgNo"
                  runat="server" CssClass="badge"></asp:Label></a></li>
         <li class="  pull-right"><a href="/Complains"><i class="fa fa-file-text-o fa-fw"></i>الشكاوى<asp:Label ID="lblComplains"
                  runat="server" CssClass="badge"></asp:Label></a></li>
            <li class="dropdown  pull-right"><a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="fa fa-search fa-fw"></i>
                بحث <b class="caret"></b></a>
                <ul class="dropdown-menu Menu">
                    <li><a href="/RealEstateList">العقارات</a></li>
                   <%-- <li><a href="/RealEstateCategories">فئات العقارات</a></li>--%>
                    <li><a href="/CompanyList">الشركات العقارية </a></li>
                    <li><a href="/ProjectList">المشروعات العقارية </a></li>
                </ul>
            </li>
        
            <li class="dropdown  pull-right"><a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="fa fa-paperclip fa-fw"></i>
                اكواد  <b class="caret"></b></a>
                <ul class="dropdown-menu Menu">
                    <li><a href="/RealEstateTypes">انواع العقارات</a></li>
                    <li><a href="/RealEstateStatuses">حالات العقارات</a></li>
                    <li><a href="/RealEstateTypeCriterias">خصائص العقارات</a></li>
                <li class="divider"></li>
                    <li><a href="/Countries">البلاد</a></li>
                    <li><a href="/Cities">المحافظات</a></li>
                    <li><a href="/Districts">الاحياء</a></li>
                    <li><a href="/Currencies">العملات</a></li>
                    <li><a href="/Keywords">كلمات دالة</a></li>
                </ul>
            </li>
            
            <li class="dropdown  pull-right"><a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="fa  fa-wrench fa-fw"></i>
                الإعدادات  <b class="caret"></b></a>
                <ul class="dropdown-menu Menu">
                    <li><a href="/GenerateCatalogs">إنشاء كتالوجات</a></li>
                    <li><a href="/CatalogCategory">فئات الكتالوجات </a></li>
                    <li><a href="/CatalogList">الكتالوجات العقارية</a></li>
                 <li><a href="/Advertisement">ادارة الاعلانات</a></li>
                    <li><a href="/RemoveSuspended">حذف العقارات المحجوبة</a></li>
                    <li><a href="/Tags">Tags</a></li>
                 <li><a href="/GenerateSiteMap">Generate Site Map</a></li>
           <%--         <li><a href="/CompanyList">الشركات العقارية </a></li>
                    <li><a href="/ProjectList">المشروعات العقارية </a></li>
                <li class="divider"></li>
                    <li><a href="/Countries">البلاد</a></li>
                    <li><a href="/Cities">المحافظات</a></li>
                    <li><a href="/Districts">الاحياء</a></li>
                    <li><a href="/Currencies">العملات</a></li>
                    <li><a href="/Keywords">كلمات دالة</a></li>--%>
                </ul>
            </li>
                <li class="dropdown  pull-right"><a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="fa fa-bar-chart-o fa-fw"></i>
                تقارير <b class="caret"></b></a>
                <ul class="dropdown-menu Menu">
                    <li><a href="/NotifyReqiestReport">تقرير بالعقارات المطلوبة</a></li>
                    <li><a href="/SubscriberReport">تقرير بالمشتركين الجدد</a></li>
                    <li><a href="/PurchaseRequestReport">  تقرير بطلبات الشراء الجديدة</a></li>
                    <li><a href="/SuspenedRealEstateReport">  تقرير بالعقارات المحجوبة</a></li>
                </ul>
            </li>
           <%--       <li class="dropdown  pull-right"><a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="fa fa-building-o fa-fw"></i>
                الإعدادات <b class="caret"></b></a>
                <ul class="dropdown-menu">
                    <li><a href="/SubscriberReport">تقرير بالمشتركين الجدد</a></li>
                    <li><a href="/PartnerList"> قائمة صفحات شركائنا </a></li>
                </ul>
            </li>--%>
            <li class="pull-right"><a href="#" data-toggle="modal" data-target="#myModal"><i class="fa fa-key fa-fw"></i>تغير كلمة السر</a></li>
              <li class="pull-right"><asp:LinkButton ID="lbtnLogout" runat="server" onclick="lbtnLogout_Click"><i class="fa fa-sign-out fa-fw"></i>خروج</asp:LinkButton></li>
        </ul>
    </div>
    <!--/.nav-collapse -->
</div>
    
<script>
    $("a.navbar-toggle").on('click', function () {
        var state = $(this).hasClass('active');
        $(this).html(state ? 'Hide' : 'Show')
           .toggleClass('active')
           .next("div.abstract").toggle(state);
    });
</script>
