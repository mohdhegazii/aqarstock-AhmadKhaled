<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucHeader.ascx.cs" Inherits="BrokerWeb.Backend.SubScriber.UserControls.ucHeader" %>
<%@ Register src="ucNewMessage.ascx" tagname="ucNewMessage" tagprefix="uc1" %>
<%--    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
     
               <telerik:AjaxSetting AjaxControlID="ucNewMessage1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ucNewMessage1" UpdatePanelRenderMode="Inline" LoadingPanelID="radLoadingPannel"/>
               </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>--%>
<div class="navbar navbar-default row" role="navigation">
    <div class="navbar-header pull-right col-lg-2 col-sm-2 col-xs-12">
        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
            <span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span><span
                class="icon-bar"></span><span class="icon-bar"></span>
        </button>
        <a class="navbar-brand pull-right" href="#"><asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label>
            </a>
    </div>
    <div class="pull-right navbar-collapse collapse col-lg-10 col-sm-10 col-xs-12">
        <ul class="nav navbar-nav navbar-right">
            <li class="  pull-right"><a href="/حسابى">الرئيسية</a></li>
            <li class="dropdown  pull-right"><a href="#" class="dropdown-toggle" data-toggle="dropdown">
                حسابى<b class="caret"></b></a>
                <ul class="dropdown-menu">
                <li><a href="#"  data-toggle="modal" data-target="#myModal">رسالة جديدة</a></li>
                <li><a href="/الرسائل">الرسائل</a></li>
                    <li><a href="/تعديل_بيانات_حسابى">تعديل بيانات حسابى</a></li>
                    <li><asp:LinkButton ID="lbtnLogout" runat="server" onclick="lbtnLogout_Click">خروج</asp:LinkButton></li>
                    </ul>
            </li>
       
            <li class="dropdown  pull-right"><a href="#" class="dropdown-toggle" data-toggle="dropdown">
                العقارات<b class="caret"></b></a>
                <ul class="dropdown-menu">
                    <li><a href="/اضافة_عقار_جديد">أضافة عقار جديد</a></li>
                    <li><a href="/عرض_العقارات">عرض العقارات</a></li>
                </ul>
            </li>
      
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
