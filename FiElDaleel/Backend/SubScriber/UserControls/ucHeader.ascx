<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucHeader.ascx.cs" Inherits="BrokerWeb.Backend.SubScriber.UserControls.ucHeader" %>
<%@ Register Src="ucNewMessage.ascx" TagName="ucNewMessage" TagPrefix="uc1" %>
<%--
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
    
               <telerik:AjaxSetting AjaxControlID="ucNewMessage1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ucNewMessage1" UpdatePanelRenderMode="Inline" LoadingPanelID="radLoadingPannel"/>
               </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
--%>
<%--<nav class="navbar navbar-default navbar-fixed-top" role="navigation" style="margin-bottom: 0">
    <div class="navbar-header navbar-right">
        <button class="navbar-toggle" data-target=".navbar-static-side" data-toggle="collapse" type="button">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
        </button>
        <a class="navbar-brand pull-right" href="~/index.html" runat="server" target="_blank">
           <i class="fa fa-external-link fa-fw"></i> <asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label></a>
    </div>
    <ul class="nav navbar-top-links">
        <li class="dropdown">
            <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                <i class="fa fa-envelope fa-fw"></i>  <i class="fa fa-caret-down">
                <asp:Label ID="lblMsgCount" runat="server"></asp:Label>
                </i>
            </a>
            <ul class="dropdown-menu dropdown-messages pull-right">
            <asp:Repeater ID="rptMessages" runat="server">
            <ItemTemplate>
                <li>
                    <a href='<%#"/عرض_الرسالة/"+Eval("ID") %>'>
                        <div class="text-right">
                            <strong>الإدارة</strong>
                            <span class="text-muted">
                                <em><%#Eval("CreatedDate", "{0:dd/MM/yyyy}")%></em>
                            </span>
                        </div>
                        <div><%#Eval("Title") %></div>
                    </a>
                </li>
                </ItemTemplate>
                </asp:Repeater>
            <li class="divider"></li>
             
                <li>
                    <a href="/الرسائل"><i class="fa fa-book fa-fw"></i>قراءة كل الرسائل</a>
                </li>
                <li class="divider"></li>
                <li><a data-target="#myModal" data-toggle="modal" href="#"><i class="fa fa-pencil fa-fw"></i>إرسال رسالة جديدة</a>
                </li>
            </ul>
            <!-- /.dropdown-messages -->
        </li>
        <!-- /.dropdown -->
        <li class="dropdown">
            <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                <i class="fa fa-shopping-cart fa-fw"></i>  <i class="fa fa-caret-down">
                <asp:Label ID="lblRequestcount" runat="server"></asp:Label>
                </i>
            </a>
            <ul class="dropdown-menu dropdown-messages pull-right">
             <asp:Repeater ID="rptRequest" runat="server">
             <ItemTemplate>
                <li>
                    <a href='<%#"/طلبات_الشراء/"+Eval("ID") %>'>
                        <div class="text-right">
                            <strong><%#Eval("PurchaserName") %></strong>
                            <span class="text-muted">
                                <em><%#Eval("Date", "{0:dd/MM/yyyy}")%></em>
                            </span>
                        </div>
                        <div><%#Eval("RealEstateTitle") %></div>
                    </a>
                </li>
                <li class="divider"></li>
                </ItemTemplate>
                </asp:Repeater>
          
                <li>
                    <a class="text-center" href="#">
                        <strong>متابعة كل طلبات الشراء</strong>
                        <i class="fa fa-angle-left"></i>
                    </a>
                </li>
            </ul>
            <!-- /.dropdown-messages -->
        </li>
        <!-- /.dropdown -->
        <li class="dropdown">
            <a class="dropdown-toggle" href="/اضافة_عقار_جديد">إضافة عقار جديد 
                <i class="fa fa-plus fa-fw"></i>
            </a>

            <!-- /.dropdown-alerts -->
        </li>
        <!-- /.dropdown -->
        <li class="dropdown">
            <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                <i class="fa fa-user fa-fw"></i><i class="fa fa-caret-down"></i>
            </a>
            <ul class="dropdown-menu dropdown-user">
                <li><a href="/تعديل_بيانات_حسابى"><i class="fa fa-user fa-fw"></i>تعديل بيانات حسابي</a>
                </li>
                <li class="divider"></li>
                <li>
                    <asp:LinkButton ID="lbtnLogout" runat="server" OnClick="lbtnLogout_Click"><i class="fa fa-sign-out fa-fw"></i>تسجيل خروج</asp:LinkButton>
                </li>
            </ul>
            <!-- /.dropdown-user -->
        </li>
        <!-- /.dropdown -->
    </ul>
</nav>--%>
<!--/.nav-collapse -->
 <%--<button class="navbar-toggle" data-target=".navbar-static-side" data-toggle="collapse" type="button">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
        </button>--%>
<nav class="navbar-default navbar-static-side collapse in" style="width: 200px;
position: absolute;z-index:7;" role="navigation">

    <div class="sidebar-collapse">
        <ul id="side-menu" class="nav">
            <li>
                <a href="/حسابى"><i class="fa fa-dashboard fa-fw"></i>لوحة التحكم </a>
            </li>
            <li>
                <a href="/اضافة_عقار_جديد"><i class="fa fa-plus fa-fw"></i>إضافة عقار جديد </a>
            </li>
            <li id="liNewProject" runat="server" visible="false">
                <a href="/اضافة_مشروع_جديد"><i class="fa fa-plus-square-o fa-fw"></i>اضافة مشروع جديد</a>
            </li>
            <li>
                <a href="/طلبات_الشراء"><i class="fa fa-table fa-fw"></i>طلبات الشراء <i class="fa ">(<asp:Label ID="lblRequestNo" runat="server" Text=""></asp:Label></i>)</a>
            </li>
            <li id="liMessages" runat="server" visible="false">
                <a href="/رسائل_العملاء"><i class="fa fa-envelope-o fa-fw"></i> رسائل العملاء <i class="fa"> (<asp:Label ID="lblMsgNo" runat="server" Text=""></asp:Label></i>)</a>
            </li>
             <li>
                <a href="/التنبيهات"><i class="fa fa-bell-o fa-fw"></i> التنبيهات<i class="fa"> (<asp:Label ID="lblNotificationNo" runat="server" Text=""></asp:Label></i>)</a>
            </li>
            <li>
                <a href="/عرض_العقارات"><i class="fa fa-eye fa-fw"></i>عرض العقارات </a>
            </li>
            <li>
                <a href="/العقارات_المفضلة"><i class="fa fa-star-o fa-fw"></i>العقارات المفضلة </a>
            </li>
                <li id="liCompany" runat="server" visible="false">
                    <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                <i class="fa fa-building-o fa-fw"></i>  <i class="fa fa-caret-down">
                <asp:Label ID="Label1" runat="server" CssClass="menuitem">حساب الشركة</asp:Label>
                </i>
            </a>
                <ul class="dropdown-menu dropdown-messages" style="background-color:#ea5821; min-width:100%; position:inherit;margin-bottom:5px;">
            
               <li id="liProjectList" class="menuLi" runat="server" visible="false">
                <a href="/قائمة_المشروعات"><i class="fa fa-cogs fa-fw"></i>قائمة المشروعات</a>
            </li>
         <li class="menuLi">
                <a href="/طلبات_شراء_لعقارات_الشركة"><i class="fa fa-list-alt fa-fw"></i>طلبات شراء لعقارات الشركة</a>
         </li>
           <li class="menuLi">
                <a href="/اضافة_حساب_موظف_جديد"><i class="fa fa-user-md fa-fw"></i>اضافة حساب موظف جديد</a>
         </li>
          <li class="menuLi">
                <a href="/قائمة_الموظفين"><i class="fa fa-users fa-fw"></i>قائمة الموظفين</a>
         </li>
            <li class="menuLi">
                <a href="/نقل_العقارات_لموظف_أخر"><i class="fa fa-exchange fa-fw"></i> نقل العقارات لموظف أخر</a>
         </li>
             <li class="menuLi">
                <a href="/تعديل_بيانات_حساب_الشركة"><i class="fa fa-edit fa-fw"></i>تعديل بيانات الشركة </a>
         </li>
           </ul>
            </li>
              <li>
                <a href="/تعديل_بيانات_حسابى"><i class="fa fa-user fa-fw"></i>تعديل بيانات حسابك</a>
            </li>
            <li>
                <a a data-target="#myModal" data-toggle="modal" href="#"><i class="fa fa-pencil fa-fw"></i>راسل الادارة</a>
            </li>
            <li>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="lbtnLogout_Click"><i class="fa fa-sign-out fa-fw"></i>تسجيل خروج</asp:LinkButton>
            </li>

        </ul>
        <!-- /#side-menu -->
    </div>
    <!-- /.sidebar-collapse -->
    </div>
</nav>
<script>
    $("a.navbar-toggle").on('click', function () {
        var state = $(this).hasClass('active');
        $(this).html(state ? 'Hide' : 'Show')
           .toggleClass('active')
           .next("div.abstract").toggle(state);
    });
</script>
