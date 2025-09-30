<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/SubScriber/SubscriberMaster.Master" AutoEventWireup="true" CodeBehind="PurchaseRequest.aspx.cs" Inherits="BrokerWeb.Backend.SubScriber.PurchaseRequest" %>
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
            color:White !important;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <ajaxsettings>
            <telerik:ajaxsetting ajaxcontrolid="rgRequests">
                <updatedcontrols>
                    <telerik:ajaxupdatedcontrol controlid="divRequestDetails" loadingpanelid="radLoadingPannel" updatepanelrendermode="Block" />
                    <telerik:ajaxupdatedcontrol controlid="rgRequests" updatepanelrendermode="Block" />
                    <telerik:ajaxupdatedcontrol controlid="lblMsg" updatepanelrendermode="Block" />
                </updatedcontrols>
            </telerik:ajaxsetting>
        </ajaxsettings>
    </telerik:RadAjaxManagerProxy>

    <div class="panel panel-primary">

        <div class="panel-heading">
            طلبات الشراء
        
        </div>
        <div class="panel-body">
            <div id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
            <telerik:RadGrid ID="rgRequests" runat="server" AllowPaging="True" AutoGenerateColumns="false" OnItemDataBound="rgRequests_ItemDataBound" OnNeedDataSource="rgRequests_NeedDataSource">
                <mastertableview datakeynames="ID" AllowPaging="true">
                    <columns>
                        <telerik:gridtemplatecolumn>
                            <itemtemplate>
                                <asp:Image ID="imgNew" runat="server" ImageUrl="~/images/new.png" Visible="false" />
                            </itemtemplate>
                        </telerik:gridtemplatecolumn>
                        <telerik:gridtemplatecolumn HeaderText="حذف">
                            <itemtemplate>
                                <asp:ImageButton ID="ibtnDelete" runat="server" CssClass="Deleteconfirm" ImageUrl="~/Images/icons/Delete.png" OnClick="ibtnDelete_Click" />
                            </itemtemplate>
                        </telerik:gridtemplatecolumn>
                        <telerik:gridtemplatecolumn HeaderText="عرض البيانات">
                            <itemtemplate>
                                <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/icons/view.png" OnClick="ibtnEdit_Click" OnClientClick="OpenWindow()" />
                            </itemtemplate>
                        </telerik:gridtemplatecolumn>
                        <telerik:gridtemplatecolumn headertext="كود العقار">
                            <itemtemplate>
                                <a href="<%#"عرض_بيانات_العقار/"+Eval("RealEstateID") %>" target="_blank">
                                    <asp:Label ID="lblCode" runat="server" Text=""></asp:Label>
                                </a>
                            </itemtemplate>
                        </telerik:gridtemplatecolumn>
                        <telerik:gridtemplatecolumn headertext="عنوان اعلان العقار">
                            <itemtemplate>
                                <a href="<%#"عرض_بيانات_العقار/"+Eval("RealEstateID") %>" target="_blank">
                                    <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
                                </a>
                            </itemtemplate>
                        </telerik:gridtemplatecolumn>
                        <telerik:gridboundcolumn datafield="PurchaserName" headertext="اسم المشترى" itemstyle-font-size="11pt" uniquename="PurchaserName" />
                        <telerik:griddatetimecolumn datafield="Date" dataformatstring="{0:dd/MM/yyyy}" datatype="System.DateTime" headertext="التاريخ" uniquename="Date">
                        </telerik:griddatetimecolumn>
                    </columns>
                    <norecordstemplate>
                        <div class="divEmptyData">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Empty.png" />
                            <span>لا يوجد طلبات شراء </span>
                        </div>
                    </norecordstemplate>
                </mastertableview>

            </telerik:RadGrid>
        </div>
    </div>
    <div id="divWindow">
    </div>
    <telerik:RadWindow ID="rwRequestDetails" runat="server" Behaviors="Close" CssClass="row  Win" KeepInScreenBounds="true" Modal="True" OffsetElementID="divWindow" Title="طلب الشراء" Top="-10">
        <contenttemplate>
            <div id="divRequestDetails" runat="server" style="margin-right: 20px;">
                <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">كود العقار</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label ID="lblCode" runat="server" CssClass="Detail" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
                <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">عنوان اعلان العقار</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label ID="lblTitle" runat="server" CssClass="Detail" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
                <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">اسم المشترى</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label ID="lblPurchaserName" runat="server" CssClass="Detail" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
                <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">رقم الهاتف</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label ID="lblpurchaserPhone" runat="server" CssClass="Detail" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
                <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">البريد الالكترونى</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label ID="lblPurchaserEmail" runat="server" CssClass="Detail" Text="غير متوفر"></asp:Label>
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
                        <span class="DetailTitle">الرسالة</span>
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
