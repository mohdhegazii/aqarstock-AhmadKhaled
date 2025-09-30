<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/SubScriber/SubscriberMaster.Master"
    AutoEventWireup="true" CodeBehind="RealEstateList.aspx.cs" Inherits="BrokerWeb.Backend.SubScriber.RealEstateList" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div>
        <div id="divSearch" class="panel panel-primary">
            <div class="panel-heading">
                البحث
            </div>
            <div class="panel-body">
                <div class="ContentItem row">
                    <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12 pull-right">
                        <asp:Label ID="Label19" runat="server" CssClass="control-label" Text="كود العقار"></asp:Label>
                    </div>
                    <div class="col-lg-11 col-md-11 col-sm-10 col-xs-12">
                        <telerik:RadNumericTextBox ID="txtCode" runat="server" CssClass="form-control" DataType="System.Int32"
                            LabelWidth="" Width="100%">
                            <NumberFormat AllowRounding="False" DecimalDigits="5" KeepNotRoundedValue="True"
                                ZeroPattern="n"></NumberFormat>
                        </telerik:RadNumericTextBox>
                    </div>
                </div>
                <div class="ContentItem row">
                    <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12 pull-right">
                        <asp:Label ID="Label14" runat="server" CssClass="control-label" Text="النوع"></asp:Label>
                    </div>
                    <div class="col-lg-11 col-md-11 col-sm-10 col-xs-12">
                        <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="ContentItem row">
                    <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12 pull-right">
                        <asp:Label ID="Label6" runat="server" CssClass="control-label" Text="العنوان"></asp:Label>
                    </div>
                    <div class="col-lg-11 col-md-11 col-sm-10 col-xs-12">
                        <telerik:RadComboBox ID="rcbAddresses" runat="server" AllowCustomText="True" CssClass="form-control ComboBox"
                            EmptyMessage="ادخل العنوان" EnableTextSelection="true" MarkFirstMatch="true">
                        </telerik:RadComboBox>
                    </div>
                </div>
                <div class="ContentItem">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg " OnClick="btnSave_Click"
                        Text="بحث" ValidationGroup="SaveAddress" />
                </div>
            </div>
        </div>
        <h1 class="centerThis">العقارات</h1>
        <div class="row nopadding">
            <telerik:RadListView ID="rlvRealEstates" runat="server" AllowPaging="true" OnItemDataBound="rlvRealEstates_ItemDataBound"
                OnNeedDataSource="rlvRealEstates_NeedDataSource" PageSize="6">
                <ItemTemplate>
                    <div class="unit">
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
