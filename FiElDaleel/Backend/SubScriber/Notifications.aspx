<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/SubScriber/SubscriberMaster.Master"
    AutoEventWireup="true" CodeBehind="Notifications.aspx.cs" Inherits="BrokerWeb.Backend.SubScriber.Notifications" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <%--    <script type="text/javascript">
        $(document).ready(function () {
            FixGridDesign();
        });
        function FixGridDesign() {
            $('.rgMasterTable').addClass('table table-striped table-bordered table-hover theGridTable');

            $('.RadGrid').removeClass('RadGrid RadGrid_Default RadGridRTL RadGridRTL_Default');
        }
    </script>--%>
    <style>
        .RadGrid_Default .rgHeader, .RadGrid_Default th.rgResizeCol
        {
            background: none !important;
            background-color: #ea5821 !important;
            color: White !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <ajaxsettings>
            <telerik:AjaxSetting AjaxControlID="rgRequests">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="divRequestDetails" LoadingPanelID="radLoadingPannel"
                        UpdatePanelRenderMode="Block" />
                    <telerik:AjaxUpdatedControl ControlID="rgRequests" UpdatePanelRenderMode="Block" />
                    <telerik:AjaxUpdatedControl ControlID="lblMsg" UpdatePanelRenderMode="Block" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </ajaxsettings>
    </telerik:RadAjaxManagerProxy>
    <div class="panel panel-primary">
        <div class="panel-heading">
            التنبيهات
        </div>
        <div class="panel-body">
            <div id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
            <telerik:RadGrid ID="rgRequests" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                OnItemDataBound="rgRequests_ItemDataBound" OnNeedDataSource="rgRequests_NeedDataSource">
                <mastertableview datakeynames="ID" allowpaging="true">
                    <Columns>
                        <telerik:GridTemplateColumn>
                            <ItemTemplate>
                                <asp:Image ID="imgNew" runat="server" ImageUrl="~/images/new.png" Visible="false" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="حذف">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnDelete" runat="server" CssClass="Deleteconfirm" ImageUrl="~/Images/icons/Delete.png"
                                    OnClick="ibtnDelete_Click" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="عرض البيانات">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/icons/view.png"
                                    OnClick="ibtnEdit_Click" OnClientClick="OpenWindow()" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                  <%--      <telerik:GridTemplateColumn HeaderText="كود العقار">
                            <ItemTemplate>
                                <a href="<%#"عرض_بيانات_العقار/"+Eval("RealEstateID") %>" target="_blank">
                                    <asp:Label ID="lblCode" runat="server" Text='<%#Eval("Code") %>'></asp:Label>
                                </a>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>--%>
                        <telerik:GridTemplateColumn HeaderText="الاسم">
                            <ItemTemplate>
                            <asp:HyperLink ID="lbtn" runat="server" target="_blank">
                                    <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("ObjectName") %>'></asp:Label>
                                </asp:HyperLink>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="Type" HeaderText="النوع" ItemStyle-Font-Size="11pt"
                            UniqueName="PurchaserName" />
                        <telerik:GridBoundColumn DataField="Title" HeaderText="عنوان التنبيه" ItemStyle-Font-Size="11pt"
                            UniqueName="PurchaserName" />
                        <telerik:GridDateTimeColumn DataField="CreatedDate" DataFormatString="{0:dd/MM/yyyy}"
                            DataType="System.DateTime" HeaderText="التاريخ" UniqueName="Date">
                        </telerik:GridDateTimeColumn>
                    </Columns>
                    <NoRecordsTemplate>
                        <div class="divEmptyData">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Empty.png" />
                            <span>لا يوجد تنبيهات </span>
                        </div>
                    </NoRecordsTemplate>
                </mastertableview>
            </telerik:RadGrid>
        </div>
    </div>
    <div id="divWindow">
    </div>
    <telerik:RadWindow ID="rwRequestDetails" runat="server" Behaviors="Close" CssClass="row  Win"
        KeepInScreenBounds="true" Modal="True" OffsetElementID="divWindow" Title="عرض بيانات التنبيه"
        Top="-10">
        <contenttemplate>
            <div id="divRequestDetails" runat="server" style="margin-right: 20px;">
                <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">النوع</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label ID="lblType" runat="server" CssClass="Detail" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
                <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">الاسم</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label ID="lblTitle" runat="server" CssClass="Detail" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
                <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">عنوان التنبيه</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label ID="lblNotificationTitle" runat="server" CssClass="Detail" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
                <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">التاريخ</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label ID="lblDate" runat="server" CssClass="Detail" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
                <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">التنبيه</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label ID="lblMessage" runat="server" CssClass="Detail" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
            </div>
        </contenttemplate>
    </telerik:RadWindow>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function OpenWindow() {
                var oWnd = $find("<%= rwRequestDetails.ClientID %>");
                oWnd.show();
            }
            
        </script>
    </telerik:RadCodeBlock>
</asp:Content>
