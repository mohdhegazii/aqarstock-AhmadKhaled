<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="RealEstateList.aspx.cs" Inherits="BrokerWeb.Backend.Admin.RealEstateList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="ddlCategory">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlType" LoadingPanelID="radLoadingPannel"
                        UpdatePanelRenderMode="Block" />
                    <telerik:AjaxUpdatedControl ControlID="ddlStatus" LoadingPanelID="radLoadingPannel"
                        UpdatePanelRenderMode="Block" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
        <div class="panel panel-primary" id="divSearch">
        <div class="panel-heading">
            <h4>البحث</h4>
        </div>
        <div class="panel-body">
            <div class="ContentItem row">
                <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12 pull-right">
                    <asp:Label ID="Label19" runat="server" Text="كود العقار" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-lg-11 col-md-11 col-sm-10 col-xs-12">
                    <telerik:RadNumericTextBox ID="txtCode" runat="server" CssClass="form-control" LabelWidth=""
                        Width="100%" DataType="System.Int32">
                        <NumberFormat ZeroPattern="n" AllowRounding="False" DecimalDigits="5" KeepNotRoundedValue="True">
                        </NumberFormat>
                    </telerik:RadNumericTextBox>
                </div>
            </div>
                    <div class="ContentItem row">
                                <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12 pull-right">
                                    <asp:Label ID="Label16" runat="server" Text="العقار/الارض معروض" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-lg-11 col-md-11 col-sm-10 col-xs-12">
                                    <asp:RadioButtonList ID="rbsSalesTypes" RepeatDirection="Horizontal" runat="server">
                                    </asp:RadioButtonList>
                              </div>
                            </div>
                  <div class="ContentItem row">
                               <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12 pull-right">
                                    <asp:Label ID="Label1" runat="server" Text="الفئة" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-lg-11 col-md-11 col-sm-9 col-xs-12">
                                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                    </asp:DropDownList>
                             </div>
                            </div>
            <div class="ContentItem row">
                <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12 pull-right">
                    <asp:Label ID="Label14" runat="server" Text="النوع" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-lg-11 col-md-11 col-sm-10 col-xs-12">
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
            </div>
                     <div class="ContentItem row">
                                 <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12 pull-right">
                                    <asp:Label ID="Label15" runat="server" Text="الحالة" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-lg-11 col-md-11 col-sm-9 col-xs-12">
                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                            </div>
                            </div>
            <div class="ContentItem row">
                <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12 pull-right">
                    <asp:Label ID="Label6" runat="server" Text="العنوان" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-lg-11 col-md-11 col-sm-10 col-xs-12">
                    <telerik:RadComboBox ID="rcbAddresses" runat="server" MarkFirstMatch="true" 
                        EnableTextSelection="true" AllowCustomText="True"  CssClass="form-control ComboBox" EmptyMessage="ادخل العنوان">
                    </telerik:RadComboBox>
                </div>
            </div>
                  <div class="ContentItem row">
                <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12 pull-right">
                    <asp:Label ID="Label2" runat="server" Text="اسم المالك" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-lg-11 col-md-11 col-sm-10 col-xs-12">
                    <telerik:RadComboBox ID="rcbSubscribers" runat="server" MarkFirstMatch="true" 
                        EnableTextSelection="true" AllowCustomText="True"  CssClass="form-control ComboBox" EmptyMessage="ادخل اسم المالك">
                    </telerik:RadComboBox>
                </div>
            </div>
                  <div class="ContentItem row">
                <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12 pull-right">
                    <asp:Label ID="Label3" runat="server" Text="من تاريخ" CssClass="control-label"></asp:Label>
                </div>
               
                <div class="col-lg-11 col-md-11 col-sm-10 col-xs-12">
                     <telerik:RadDatePicker ID="rdpFrom" runat="server">
                      </telerik:RadDatePicker>
                </div>
            </div>
                  <div class="ContentItem row">
                <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12 pull-right">
                    <asp:Label ID="Label5" runat="server" Text="الى تاريخ" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-lg-11 col-md-11 col-sm-10 col-xs-12">
             <telerik:RadDatePicker ID="rdpTo" runat="server">
                      </telerik:RadDatePicker>
                </div>
            </div>
            <div class="ContentItem">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg btn-primary" Text="بحث" ValidationGroup="SaveAddress"
                    OnClick="btnSave_Click" />
            </div>
        </div>
            </div>
        <div id="divRealestateList" runat="server" visible="false">
        <h1 class="centerThis">العقارات</h1>
        <div class="row nopadding centerThis">
            <telerik:RadListView ID="rlvRealEstates" runat="server" AllowPaging="true" OnItemDataBound="rlvRealEstates_ItemDataBound"
                OnNeedDataSource="rlvRealEstates_NeedDataSource" PageSize="21">
                <ItemTemplate>
                    <div class="unit">
                        <a href='<%#"RealEstateView/"+Eval("ID")+"/0" %>'>
                            <asp:Image ID="imgSold" CssClass="img-responsive SoldImage" ImageUrl="~/images/icons/sold.png"
                                runat="server" />
                            <asp:Image ID="imgLogo" CssClass="img-responsive unitImg" runat="server" />

                            <div class="unitData">
                                <%--<asp:Label ID="Label2" runat="server" Text="عنوان اعلان العقار: "></asp:Label>--%>
                                <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
                                <br />
                                <asp:Label ID="Label1" runat="server" Text="كود العقار:"></asp:Label>
                                <asp:Label ID="lblCode" runat="server" Text=""></asp:Label>
                                <br />
                                <asp:Label ID="Label4" runat="server" Text="العنوان: "></asp:Label>
                                <asp:Label ID="lblAddress" runat="server" Text=''></asp:Label>
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
                  <telerik:RadDataPager ID="RadDataPager1" runat="server" Culture="ar-EG" PagedControlID="rlvRealEstates" PageSize="21">
                <fields>
                    <telerik:raddatapagerbuttonfield fieldtype="NextLast" horizontalposition="RightFloat" />
                    <telerik:raddatapagerbuttonfield fieldtype="Numeric" horizontalposition="RightFloat" />
                    <telerik:raddatapagerbuttonfield fieldtype="FirstPrev" horizontalposition="RightFloat" />
                </fields>
            </telerik:RadDataPager>
        </div>
        </div>
    </div>
</asp:Content>
