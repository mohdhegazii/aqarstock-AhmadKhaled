<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/SubScriber/SubscriberMaster.Master" AutoEventWireup="true" CodeBehind="RealEstateList.aspx.cs" Inherits="BrokerWeb.Backend.SubScriber.RealEstateList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div>
   <telerik:RadAutoCompleteBox runat="server" ID="RadAutoCompleteBox2" EnableClientFiltering="true" Width="250" DropDownHeight="150"
                    DropDownWidth="250">
                    <WebServiceSettings Path="Services/General.asmx" Method="BindDistricts" />
                </telerik:RadAutoCompleteBox>
        <div class="divListHeader row">
            <span>العقارات </span>
           <%-- <a>المزيد</a>--%>
        </div>
        <div class="divList row">
               
             <telerik:RadListView ID="rlvRealEstates" runat="server" AllowPaging="true"
                onitemdatabound="rlvRealEstates_ItemDataBound" 
                 onneeddatasource="rlvRealEstates_NeedDataSource" >
                <ItemTemplate>
                    <div class="divListItem col-lg-6 col-md-6 col-sm-6 col-xs-12 pull-right">
                        <a href='<%#"عرض_بيانات_العقار/"+Eval("ID") %>'>
                             <asp:Image ID="imgSold" CssClass="img-responsive SoldImage" ImageUrl="~/images/sold.jpg"
                                        runat="server" />
                            <asp:Image ID="imgLogo" CssClass="img-responsive" runat="server" />
                            <div class="divListItemContent">
                                <asp:Label ID="Label2" runat="server" Text="عنوان اعلان العفار"></asp:Label>
                                <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
                                <br />
                                    <asp:Label ID="Label1" runat="server" Text="كود العقار:"></asp:Label>
                                <asp:Label ID="lblCode" runat="server" Text=""></asp:Label>
                                <br />
                                <asp:Label ID="Label4" runat="server" Text="العنوان"></asp:Label>
                                <asp:Label ID="lblAddress" runat="server" Text=''></asp:Label>
                                <br />
                                <asp:Label ID="Label6" runat="server" Text="التفاصيل"></asp:Label>
                                <asp:Label ID="lblDetails" runat="server" Text=""></asp:Label>
                            </div>
                        </a>
                    </div>
                </ItemTemplate>
                <EmptyDataTemplate>
                <div class="divEmptyData">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Empty.png" />
                <span>
                    لا يوجد عقارات
                    </span>
                    </div>
                </EmptyDataTemplate>
            </telerik:RadListView>
        </div>
    </div>

</asp:Content>
