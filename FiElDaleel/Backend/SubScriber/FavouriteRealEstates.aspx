<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/SubScriber/SubscriberMaster.Master"
    AutoEventWireup="true" CodeBehind="FavouriteRealEstates.aspx.cs" Inherits="BrokerWeb.Backend.SubScriber.FavouriteRealEstates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            العقارات المفضلة
        </div>
        <div class="panel-body">
        <telerik:RadListView ID="rlvRealEstates" runat="server" AllowPaging="true" OnItemDataBound="rlvRealEstates_ItemDataBound"
                OnNeedDataSource="rlvRealEstates_NeedDataSource" PageSize="6">
                <ItemTemplate>
                    <div class="unit" style="padding:10px; width:276px;">
                        <a href="<%#"عرض_بيانات_العقار/"+Eval("ID") %>">
                            <asp:Image ID="imgSold" runat="server" CssClass="img-responsive SoldImage" ImageUrl="~/images/icons/sold.png" />
                            <asp:Image ID="imgLogo" runat="server" CssClass="img-responsive unitImg" />
                            <div class="unitData">
                                <%--  <asp:Label ID="Label2" runat="server" Text="عنوان اعلان العفار"></asp:Label>--%>
                                <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
                                <br />
                                <asp:Label ID="Label1" runat="server" Text="كود العقار:"></asp:Label>
                                <asp:Label ID="lblCode" runat="server" Text=""></asp:Label>
                                <br />
                                <asp:Label ID="Label4" runat="server" Text="العنوان: "></asp:Label>
                                <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                                <br />
                                <asp:Label ID="Label6" runat="server" Text="التفاصيل: "></asp:Label>
                                <asp:Label ID="lblDetails" runat="server" Text=""></asp:Label>
                            </div>
                        </a>
                    </div>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <div class="divEmptyData">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Empty.png" />
                        <span>لا يوجد عقارات </span>
                    </div>
                </EmptyDataTemplate>
            </telerik:RadListView>
            <telerik:RadDataPager ID="RadDataPager1" runat="server" Culture="ar-EG" PagedControlID="rlvRealEstates"
                PageSize="6">
                <Fields>
                    <telerik:RadDataPagerButtonField FieldType="NextLast" HorizontalPosition="RightFloat" />
                    <telerik:RadDataPagerButtonField FieldType="Numeric" HorizontalPosition="RightFloat" />
                    <telerik:RadDataPagerButtonField FieldType="FirstPrev" HorizontalPosition="RightFloat" />
                </Fields>
            </telerik:RadDataPager>
        </div>
    </div>
</asp:Content>
