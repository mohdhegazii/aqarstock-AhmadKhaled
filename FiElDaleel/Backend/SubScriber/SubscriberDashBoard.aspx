<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/SubScriber/SubscriberMaster.Master" AutoEventWireup="true" CodeBehind="SubscriberDashBoard.aspx.cs" Inherits="BrokerWeb.Backend.SubScriber.SubscriberDashBoard" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="row pull-right">
        <div class="alert alert-warning alert-dismissable">

            <strong>مرحبا!</strong> يمكنك الان اضافة اعلانات العقارات التى ترغب فى عرضها للبيع او للايجار مجانا
            <button class="close pull-left" aria-hidden="true" data-dismiss="alert" type="button">&times;</button>
        </div>

    </div>

    <div class="row">
        <%--<div class="col-lg-2 col-md-2 col-sm-2 hidden-xs pull-right" style="display: none!important;">
            <telerik:RadTabStrip ID="rtsAddBusiness" runat="server" Align="Justify" AutoPostBack="false" CssClass="WizardTabs rightList" EnableEmbeddedSkins="true" Orientation="VerticalRight" Skin="Simple">
                <tabs>
                    <telerik:radtab>
                        <tabtemplate>
                            <a href="اضافة_عقار_جديد">
                                <div class="WizardTab">
                                    <asp:Image ID="Image1" runat="server" CssClass="img-responsive" ImageUrl="~/images/RealEstate.png" />
                                    <asp:Label ID="Label1" runat="server" Text="أضافة عقار"></asp:Label>
                                </div>
                            </a>
                        </tabtemplate>
                    </telerik:radtab>
                    <telerik:radtab>
                        <tabtemplate>
                            <a href="الرسائل">
                                <div class="WizardTab">
                                    <asp:Image ID="Image1" runat="server" CssClass="img-responsive" ImageUrl="~/images/messages.png" />
                                    <asp:Label ID="Label1" runat="server" Text="الرسائل"></asp:Label>
                                    <asp:Label ID="lblUnReadMsgNo" runat="server" CssClass="badge"></asp:Label></
                                </div>
                            </a>
                        </tabtemplate>
                    </telerik:radtab>
                    <telerik:radtab>
                        <tabtemplate>
                            <a href="طلبات_الشراء">
                                <div class="WizardTab">
                                    <asp:Image ID="Image1" runat="server" CssClass="img-responsive" ImageUrl="~/images/Purchase.png" />
                                    <asp:Label ID="Label1" runat="server" Text="طلبات الشراء"></asp:Label>
                                    <asp:Label ID="lblRequestNo" runat="server" CssClass="badge"></asp:Label></
                                </div>
                            </a>
                        </tabtemplate>
                    </telerik:radtab>
                </tabs>
            </telerik:RadTabStrip>
        </div>--%>
        <div class="col-lg-12 nopadding">

            <h1 class="centerThis">العقارات</h1>
            <div class="row nopadding centerThis">
                <telerik:RadListView ID="rlvRealEstates" runat="server" OnItemDataBound="rlvRealEstates_ItemDataBound">
                    <itemtemplate>
                        <div class="unit">
                            <a href="<%#"عرض_بيانات_العقار/"+Eval("ID") %>">
                                <asp:Image ID="imgSold" runat="server" CssClass="img-responsive SoldImage" ImageUrl="~/images/icons/sold.png" />
                                <asp:Image ID="imgLogo" runat="server" CssClass="img-responsive unitImg" />
                                <div class="unitData">
                                    <%-- <asp:Label ID="Label2" runat="server" Text="عنوان اعلان العقار:"></asp:Label>--%>
                                    <p><asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></p>
                                   
                                    <p>
                                    <asp:Label ID="Label1" runat="server" Text="كود العقار:"></asp:Label>
                                    <asp:Label ID="lblCode" runat="server" Text=""></asp:Label>
                                    </p>
                                   
                                    <p>
                                    <asp:Label ID="Label4" runat="server" Text="العنوان:"></asp:Label>
                                    <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                                    </p>
                                    <p>
                                    <asp:Label ID="Label6" runat="server" Text="التفاصيل:"></asp:Label>
                                    <asp:Label ID="lblDetails" runat="server" Text=""></asp:Label>
                                    </p>
                                </div>
                            </a>
                        </div>
                    </itemtemplate>
                    <emptydatatemplate>
                        <div class="divEmptyData">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Empty.png" />
                            <span>لا يوجد عقارات </span>
                        </div>
                    </emptydatatemplate>
                </telerik:RadListView>
            </div>
            <div class="row nopadding centerThis">
            <a href="عرض_العقارات" class="btn btn-success">المزيد</a>
                </div>
        </div>
    </div>
</asp:Content>
