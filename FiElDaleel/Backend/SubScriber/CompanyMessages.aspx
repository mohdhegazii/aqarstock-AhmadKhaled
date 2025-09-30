<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/SubScriber/SubscriberMaster.Master" AutoEventWireup="true" CodeBehind="CompanyMessages.aspx.cs" Inherits="BrokerWeb.Backend.SubScriber.CompanyMessages" %>
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
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgRequests">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="divRequestDetails" LoadingPanelID="radLoadingPannel"
                        UpdatePanelRenderMode="Block" />
                    <telerik:AjaxUpdatedControl ControlID="rgRequests" UpdatePanelRenderMode="Block" />
                    <telerik:AjaxUpdatedControl ControlID="lblMsg" UpdatePanelRenderMode="Block" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <div class="panel panel-primary">
        <div class="panel-heading">
            رسائل العملاء
        </div>
        <div class="panel-body">
            <div id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
            <telerik:RadGrid ID="rgRequests" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                OnItemDataBound="rgRequests_ItemDataBound" OnNeedDataSource="rgRequests_NeedDataSource">
                <MasterTableView DataKeyNames="ID" AllowPaging="true">
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
                        <telerik:GridBoundColumn DataField="ProjectName" HeaderText="اسم المشروع" ItemStyle-Font-Size="11pt"
                            UniqueName="PurchaserName" />
                        <telerik:GridBoundColumn DataField="Name" HeaderText="الاسم" ItemStyle-Font-Size="11pt"
                            UniqueName="PurchaserName" />
                        <telerik:GridDateTimeColumn DataField="CreatedDate" DataFormatString="{0:dd/MM/yyyy}"
                            DataType="System.DateTime" HeaderText="التاريخ" UniqueName="Date">
                        </telerik:GridDateTimeColumn>
                    </Columns>
                    <NoRecordsTemplate>
                        <div class="divEmptyData">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Empty.png" />
                            <span>لا يوجد رسائل العملاء </span>
                        </div>
                    </NoRecordsTemplate>
                </MasterTableView>
            </telerik:RadGrid>
        </div>
    </div>
    <div id="divWindow">
    </div>
    <telerik:RadWindow ID="rwRequestDetails" runat="server" Behaviors="Close" CssClass="row  Win"
        KeepInScreenBounds="true" Modal="True" OffsetElementID="divWindow" Title="عرض بيانات الرسالة "
        Top="-10">
        <ContentTemplate>
            <div id="divRequestDetails" runat="server" style="margin-right: 20px;">
                     <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">اسم المشروع</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label ID="lblProjectName" runat="server" CssClass="Detail" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
                 <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">الاسم</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label ID="lblName" runat="server" CssClass="Detail" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
                   <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">رقم الهاتف</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label ID="lblPhone" runat="server" CssClass="Detail" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
                <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">البريد الالكترونى</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label ID="lblEmail" runat="server" CssClass="Detail" Text="غير متوفر"></asp:Label>
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
        </ContentTemplate>
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

