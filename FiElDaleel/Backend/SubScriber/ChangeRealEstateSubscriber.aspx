<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/SubScriber/SubscriberMaster.Master"
    AutoEventWireup="true" CodeBehind="ChangeRealEstateSubscriber.aspx.cs" Inherits="BrokerWeb.Backend.SubScriber.ChangeRealEstateSubscriber" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .RadGrid_Default .rgHeader, .RadGrid_Default th.rgResizeCol
        {
            background: none !important;
            background-color: #ea5821 !important;
            color:White !important;
        }
        .RadToolBar_Default .rtbMiddle
        {
            background: none !important;
            border: 0px !important;
        }
        .RadGrid_Default
        {
            border: 0px !important;
        }
        .RadToolBar_Default .rtbOuter
        {
            border: 0px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgRealEstates">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgRealEstates" loadingpanelid="radLoadingPannel" UpdatePanelRenderMode="Block" />
                    <telerik:AjaxUpdatedControl ControlID="divMsg" UpdatePanelRenderMode="Block" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rtbmovesubscriber">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgRealEstates" loadingpanelid="radLoadingPannel" UpdatePanelRenderMode="Block" />
                    <telerik:AjaxUpdatedControl ControlID="divMsg" UpdatePanelRenderMode="Block" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h4>
                نقل العقارات لموظف أخر</h4>
         
        </div>
        <div class="panel-body">
            <%--     <div class="row">
                <div class="col-lg-4 pull-right">
                    <div class="ContentItem row">
                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                            <asp:Label ID="Label1" runat="server" Text="الموظف" CssClass="control-label"></asp:Label>
                        </div>
                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                            <asp:DropDownList ID="ddlSubscribers" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Save" CssClass="Validator"
                                ControlToValidate="ddlSubscribers" runat="server" ErrorMessage="!" Display="Dynamic"
                                InitialValue="0"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="ContentItem">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg btn-primary pull-left"
                    Text="حفظ" ValidationGroup="Save" OnClick="btnSave_Click" />
            </div>--%>
               <div id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
            <div class="ContentItem">
                <telerik:RadToolBar ID="rtbmovesubscriber" runat="server" Width="100%">
                    <Items>
                        <telerik:RadToolBarButton>
                            <ItemTemplate>
                                <div class="ContentItem row" style="margin-right: 10px; line-height: 3.12;">
                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                        <asp:Label ID="Label1" runat="server" Text="الموظف" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                        <asp:DropDownList ID="ddlSubscribers" runat="server" CssClass="form-control" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlSubscribers_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Move" CssClass="Validator"
                                            ControlToValidate="ddlSubscribers" runat="server" ErrorMessage="!قم باختيار الموظف الذى ترغب فى نقل عقاراته" 
                                            InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton>
                            <ItemTemplate>
                                <div class="ContentItem row" style="margin-right: 10px; line-height: 3.12;">
                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                        <asp:Label ID="Label1" runat="server" Text="نقل الى" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                        <asp:DropDownList ID="ddlNewSubscribers" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Move" CssClass="Validator"
                                            ControlToValidate="ddlNewSubscribers" runat="server" ErrorMessage="!قم باختيار الموظف الذى ترغب فى نقل العقارات له" 
                                            InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton>
                            <ItemTemplate>
                                <div class="ContentItem">
                                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-md pull-left" style="margin-bottom:37px" Text="نقل العقارات"
                                        ValidationGroup="Move" onclick="btnSave_Click" />
                                </div>
                            </ItemTemplate>
                        </telerik:RadToolBarButton>
                    </Items>
                </telerik:RadToolBar>
                <telerik:RadGrid ID="rgRealEstates" runat="server" AllowPaging="True" AutoGenerateColumns="false" OnNeedDataSource="rgRealEstates_NeedDataSource">
                    <MasterTableView DataKeyNames="ID" AllowPaging="true" CssClass="table table-striped table-bordered theGridTable">
                        <CommandItemTemplate>
                        </CommandItemTemplate>
                        <Columns>
                           <%-- <telerik:GridBoundColumn DataField="Title" HeaderText="عنوان اعلان العقار" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="GridColumnHeader" />
                            <telerik:GridBoundColumn DataField="Code" HeaderText="كود العقار" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="GridColumnHeader" />--%>
                                <telerik:gridtemplatecolumn headertext="كود العقار" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="GridColumnHeader">
                            <itemtemplate>
                                <a href="<%#"عرض_بيانات_العقار/"+Eval("ID") %>" target="_blank">
                                    <asp:Label ID="lblCode" runat="server" Text='<%#Eval("Code") %>'></asp:Label>
                                </a>
                            </itemtemplate>
                        </telerik:gridtemplatecolumn>
                        <telerik:gridtemplatecolumn headertext="عنوان اعلان العقار" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="GridColumnHeader">
                            <itemtemplate>
                                <a href="<%#"عرض_بيانات_العقار/"+Eval("ID") %>" target="_blank">
                                    <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title") %>'></asp:Label>
                                </a>
                            </itemtemplate>
                        </telerik:gridtemplatecolumn>
                            <telerik:GridTemplateColumn HeaderText="نقل" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="GridColumnHeader">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkMove" runat="server" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <NoRecordsTemplate>
                            <div class="divEmptyData">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Empty.png" />
                                <span>لا يوجد العقارات </span>
                            </div>
                        </NoRecordsTemplate>
                    </MasterTableView>
                </telerik:RadGrid>
            </div>
        </div>
    </div>
</asp:Content>
