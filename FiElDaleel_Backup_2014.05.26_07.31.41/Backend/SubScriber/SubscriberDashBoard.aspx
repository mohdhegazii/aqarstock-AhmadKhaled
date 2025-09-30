<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/SubScriber/SubscriberMaster.Master"
    AutoEventWireup="true" CodeBehind="SubscriberDashBoard.aspx.cs" Inherits="BrokerWeb.Backend.SubScriber.SubscriberDashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-2 col-md-2 col-sm-2 hidden-xs pull-right">
            <telerik:RadTabStrip ID="rtsAddBusiness" AutoPostBack="false" Align="Justify" runat="server"
                CssClass="WizardTabs rightList" EnableEmbeddedSkins="true" Skin="Simple" Orientation="VerticalRight">
                <Tabs>
                    <telerik:RadTab>
                        <TabTemplate>
                            <a href="اضافة_عقار_جديد">
                                <div class="WizardTab">
                                    <asp:Image ID="Image1" CssClass="img-responsive" ImageUrl="~/images/RealEstate.png"
                                        runat="server" />
                                    <asp:Label ID="Label1" runat="server" Text="أضافة عقار"></asp:Label>
                                </div>
                            </a>
                        </TabTemplate>
                    </telerik:RadTab>
                    <telerik:RadTab>
                        <TabTemplate>
                            <a href="الرسائل">
                                <div class="WizardTab">
                                    <asp:Image ID="Image1" CssClass="img-responsive" ImageUrl="~/images/messages.png"
                                        runat="server" />
                                    <asp:Label ID="Label1" runat="server" Text="الرسائل"></asp:Label>
                                    <asp:Label ID="lblUnReadMsgNo" runat="server" CssClass="badge"></asp:Label></
                                </div>
                            </a>
                        </TabTemplate>
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
        </div>
        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
      
            <div>
                <div class="divListHeader row">
                    <span>العقارات </span><a href="عرض_العقارات">المزيد</a>
                </div>
                <div class="divList row">
                    <telerik:RadListView ID="rlvRealEstates" runat="server" OnItemDataBound="rlvRealEstates_ItemDataBound">
                        <ItemTemplate>
                            <div class="divListItem col-lg-6 col-md-6 col-sm-6 col-xs-12 pull-right">
                                <a href='<%#"عرض_بيانات_العقار/"+Eval("ID") %>'>
                                    <asp:Image ID="imgSold" CssClass="img-responsive SoldImage" ImageUrl="~/images/sold.jpg"
                                        runat="server" />
                                    <asp:Image ID="imgLogo" CssClass="img-responsive" runat="server" />
                                    <div class="divListItemContent">
                                        <asp:Label ID="Label2" runat="server" Text="عنوان اعلان العقار:"></asp:Label>
                                        <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
                                        <br />
                                                <asp:Label ID="Label1" runat="server" Text="كود العقار:"></asp:Label>
                                <asp:Label ID="lblCode" runat="server" Text=""></asp:Label>
                                <br />
                                        <asp:Label ID="Label4" runat="server" Text="العنوان:"></asp:Label>
                                        <asp:Label ID="lblAddress" runat="server" Text=''></asp:Label>
                                        <br />
                                        <asp:Label ID="Label6" runat="server" Text="التفاصيل:"></asp:Label>
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
                </div>
            </div>
     
        </div>
</asp:Content>
