<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master"
    AutoEventWireup="true" CodeBehind="NotifyReqiestReport.aspx.cs" Inherits="BrokerWeb.Backend.Admin.NotifyReqiestReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgRequests">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgRequests" UpdatePanelRenderMode="Block" />
       <%--             <telerik:AjaxUpdatedControl ControlID="divWindowDetail" UpdatePanelRenderMode="Block"
                        LoadingPanelID="radLoadingPannel" />--%>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlCity">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlDistrict" LoadingPanelID="radLoadingPannel" UpdatePanelRenderMode="Block" />
                </UpdatedControls>
       </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlCountry">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlCity" LoadingPanelID="radLoadingPannel"
                        UpdatePanelRenderMode="Block" />
                    <telerik:AjaxUpdatedControl ControlID="ddlDistrict" LoadingPanelID="radLoadingPannel"
                        UpdatePanelRenderMode="Block" />
                </UpdatedControls>
            </telerik:AjaxSetting>
         

        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
                <%--     <telerik:AjaxSetting AjaxControlID="btnSave">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgRequests" UpdatePanelRenderMode="Block" />
                </UpdatedControls>
            </telerik:AjaxSetting>--%>
    <div class="panel panel-primary">
        <div class="panel-heading">
            تقرير بالعقارات المطلوبة
            <div id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="panel-body">
            <div class="pull-right" style="margin-right: 10px">
                <div class="ContentItem row">
                    <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12 pull-right">
                        <asp:Label ID="Label16" runat="server" Text="النظام" CssClass="control-label"></asp:Label>
                    </div>
                    <div class="col-lg-11 col-md-11 col-sm-10 col-xs-12">
                        <asp:RadioButtonList ID="rbsSalesTypes" RepeatDirection="Horizontal" runat="server">
                        </asp:RadioButtonList>
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
                        <asp:Label ID="Label5" runat="server" Text="البلد" CssClass="control-label"></asp:Label>
                    </div>
                    <div class="col-lg-11 col-md-11 col-sm-9 col-xs-12">
                        <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control" 
                            AutoPostBack="True" onselectedindexchanged="ddlCountry_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="ContentItem row">
                    <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12 pull-right">
                        <asp:Label ID="Label6" runat="server" Text="المحافظة" CssClass="control-label"></asp:Label>
                    </div>
                    <div class="col-lg-11 col-md-11 col-sm-9 col-xs-12">
                        <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" 
                            AutoPostBack="True" onselectedindexchanged="ddlCity_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="ContentItem row">
                    <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12 pull-right">
                        <asp:Label ID="Label7" runat="server" Text="الحى" CssClass="control-label"></asp:Label>
                    </div>
                    <div class="col-lg-11 col-md-11 col-sm-10 col-xs-12">
                              <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control" 
                            AutoPostBack="True">
                        </asp:DropDownList>
                    </div>
                </div>
                   <div class="ContentItem row">
                <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12 pull-right">
                    <asp:Label ID="Label19" runat="server" Text="اقل سعر" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-lg-11 col-md-11 col-sm-10 col-xs-12">
                    <telerik:RadNumericTextBox ID="txtPrice" runat="server" CssClass="form-control" LabelWidth=""
                        Width="100%" DataType="System.Int32">
                        <NumberFormat ZeroPattern="n" AllowRounding="False" DecimalDigits="5" KeepNotRoundedValue="True">
                        </NumberFormat>
                    </telerik:RadNumericTextBox>
                </div>
            </div>
               <div class="ContentItem row">
                <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12 pull-right">
                    <asp:Label ID="Label3" runat="server" Text="اقل مساحة" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-lg-11 col-md-11 col-sm-10 col-xs-12">
                    <telerik:RadNumericTextBox ID="txtArea" runat="server" CssClass="form-control" LabelWidth=""
                        Width="100%" DataType="System.Int32">
                        <NumberFormat ZeroPattern="n" AllowRounding="False" DecimalDigits="5" KeepNotRoundedValue="True">
                        </NumberFormat>
                    </telerik:RadNumericTextBox>
                </div>
            </div>
                <div class="ContentItem row">
                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                        <asp:Label ID="Label2" runat="server" CssClass="control-label" Text="من تاريخ"></asp:Label>
                    </div>
                    <telerik:RadDatePicker ID="rdpFrom" runat="server">
                    </telerik:RadDatePicker>
                    
                </div>
                <div class="ContentItem row">
                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                        <asp:Label ID="Label1" runat="server" CssClass="control-label" Text="الى تاريخ"></asp:Label>
                    </div>
                    <telerik:RadDatePicker ID="rdpTo" runat="server">
                    </telerik:RadDatePicker>
                    
                </div>
            
             
                <div class="ContentItem row">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg pull-left" OnClick="btnSave_Click"
                        Text="بحث" ValidationGroup="Save" />
                </div>
                <div class="ContentItem row">
                    <asp:GridView ID="rgRequests" runat="server" AllowPaging="true" DataKeyNames="ID"
                        AutoGenerateColumns="false" CellPadding="4" CssClass="table table-striped table-bordered theGridTable"
                        Style="font-size: 12px;" PageSize="20" OnPageIndexChanging="rgRequests_NeedDataSource">
                        <%--    <MasterTableView DataKeyNames="ID" AllowPaging="true">--%>
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="Id" Visible="false" />
                            <%--     <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/icons/view.png"
                                    OnClick="ibtnEdit_Click" OnClientClick="OpenWindow()" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                            <asp:BoundField DataField="Email" HeaderText="رقم هاتف " HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-CssClass="GridColumnHeader" />
                            <asp:BoundField DataField="Phone" HeaderText="رقم هاتف " HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-CssClass="GridColumnHeader" />
                            <asp:BoundField DataField="Name" HeaderText="اسم " HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-CssClass="GridColumnHeader" />
                            <asp:BoundField DataField="Date" DataFormatString="{0:dd/MM/yyyy}" HeaderText="التاريخ"
                                HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="GridColumnHeader">
                            </asp:BoundField>
                            <asp:BoundField DataField="Area" HeaderText="المساحة" HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-CssClass="GridColumnHeader" />
                            <asp:BoundField DataField="Price" HeaderText="السعر" HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-CssClass="GridColumnHeader" />
                            <asp:BoundField DataField="Address" HeaderText="العنوان" HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-CssClass="GridColumnHeader" />
                            <asp:BoundField DataField="SaleTypeName" HeaderText="النظام" HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-CssClass="GridColumnHeader" />
                                <asp:BoundField DataField="Type" HeaderText="نوع العقار" HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-CssClass="GridColumnHeader" />
                        
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#ea5821" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#ea5821" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#ea5821" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        <%--                    <NoRecordsTemplate>
                        <div class="divEmptyData">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Empty.png" />
                            <span>لا يوجد طلبات شراء </span>
                        </div>
                    </NoRecordsTemplate>--%>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <div id="divWindow">
    </div>
    <telerik:RadWindow ID="rwRequestDetails" runat="server" Behaviors="Close" CssClass="row  Win"
        KeepInScreenBounds="true" Modal="True" OffsetElementID="divWindow" Title="طلب الشراء"
        Top="-10">
        <ContentTemplate>
            <div id="divWindowDetail" runat="server">
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
            </div>
        </ContentTemplate>
    </telerik:RadWindow>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function OpenWindow() {
                var oWnd = $find("<%= rwRequestDetails.ClientID %>");
                oWnd.show();
            }
            function FixGridDesign() {
                $('.rgMasterTable').addClass('table table-striped table-bordered table-hover theGridTable');

                $('.RadGrid').removeClass('RadGrid RadGrid_Default RadGridRTL RadGridRTL_Default');
            }
        </script>
    </telerik:RadCodeBlock>
</asp:Content>
