<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master"
    AutoEventWireup="true" CodeBehind="PurchaseRequestReport.aspx.cs" Inherits="BrokerWeb.Backend.Admin.PurchaseRequestReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy2" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgRequests">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="divRequestDetails" LoadingPanelID="radLoadingPannel"
                        UpdatePanelRenderMode="Block" />
                    <telerik:AjaxUpdatedControl ControlID="rgRequests" UpdatePanelRenderMode="Block" LoadingPanelID="radLoadingPannel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <%--   <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <ajaxsettings>
            <telerik:ajaxsetting ajaxcontrolid="rgRequests">
                <updatedcontrols>
                    <telerik:ajaxupdatedcontrol controlid="divRequestDetails" loadingpanelid="radLoadingPannel" updatepanelrendermode="Block" />
                    <telerik:ajaxupdatedcontrol controlid="rgRequests" updatepanelrendermode="Block" />
                    <telerik:ajaxupdatedcontrol controlid="lblMsg" updatepanelrendermode="Block" />
                </updatedcontrols>
            </telerik:ajaxsetting>
        </ajaxsettings>
    </telerik:RadAjaxManagerProxy>--%>
    <div class="panel panel-primary">
        <div class="panel-heading">
            تقرير بطلبات الشراء الجديدة
            <div id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="panel-body">
            <div class="ContentItem">
                <asp:Label ID="Label2" runat="server" CssClass="control-label" Text="من تاريخ"></asp:Label>
                <telerik:RadDatePicker ID="rdpFrom" runat="server">
                </telerik:RadDatePicker>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rdpFrom"
                    CssClass="Validator" ErrorMessage="!" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
            <div class="ContentItem">
                <asp:Label ID="Label1" runat="server" CssClass="control-label" Text="الى تاريخ"></asp:Label>
                <telerik:RadDatePicker ID="rdpTo" runat="server">
                </telerik:RadDatePicker>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rdpTo"
                    CssClass="Validator" ErrorMessage="!" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
            <div class="ContentItem">
                <asp:Label ID="Label3" runat="server" CssClass="control-label" Text="حالة الطلب"></asp:Label>
                <asp:RadioButtonList ID="rblReadStatus" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Text="الكل" Value="0"></asp:ListItem>
                    <asp:ListItem Text="تم قرائته" Value="1"></asp:ListItem>
                    <asp:ListItem Text="لم يتم قرائته" Value="2"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="ContentItem">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg btn-primary pull-left"
                    OnClick="btnSave_Click" Text="بحث" ValidationGroup="Save" />
            </div>
            <div class="ContentItem">
                <telerik:RadGrid ID="rgRequests" runat="server" AutoGenerateColumns="false" OnItemDataBound="rgRequests_ItemDataBound">
                    <MasterTableView DataKeyNames="ID">
                        <Columns>
                            <%--     <telerik:gridtemplatecolumn>
                            <itemtemplate>
                                <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/icons/view.png" OnClick="ibtnEdit_Click" OnClientClick="OpenWindow()" />
                            </itemtemplate>
                        </telerik:gridtemplatecolumn>--%>
                            <telerik:GridTemplateColumn HeaderText="كود العقار">
                                <ItemTemplate>
                                    <a href="<%#"RealEstateView/"+Eval("RealEstateID")+"/0" %>" target="_blank">
                                        <asp:Label ID="lblCode" runat="server" Text=""></asp:Label>
                                    </a>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="عنوان اعلان العقار">
                                <ItemTemplate>
                                    <a href="<%#"RealEstateView/"+Eval("RealEstateID")+"/0" %>" target="_blank">
                                        <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
                                    </a>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="SubscriberName" HeaderText="اسم المالك" ItemStyle-Font-Size="11pt"
                                UniqueName="SubscriberName" />
                            <telerik:GridBoundColumn DataField="SubscriberMobile" HeaderText="رقم هاتف المالك"
                                ItemStyle-Font-Size="11pt" UniqueName="SubscriberMobile" />
                            <telerik:GridDateTimeColumn DataField="Date" DataFormatString="{0:dd/MM/yyyy}" DataType="System.DateTime"
                                HeaderText="التاريخ" UniqueName="Date">
                            </telerik:GridDateTimeColumn>
                            <telerik:GridBoundColumn DataField="PurchaserName" HeaderText="اسم المشترى" ItemStyle-Font-Size="11pt"
                                UniqueName="PurchaserName" />
                            <telerik:GridBoundColumn DataField="PurchaserPhone" HeaderText="رقم هاتف المشترى"
                                ItemStyle-Font-Size="11pt" UniqueName="PurchaserPhone" />
                            <telerik:GridBoundColumn DataField="PurchaserEmail" HeaderText="البريد الالكترونى المشترى"
                                ItemStyle-Font-Size="11pt" UniqueName="PurchaserEmail" />
                            <telerik:GridTemplateColumn HeaderText="تم قرائته" ItemStyle-Font-Size="11pt" UniqueName="SubscriberName">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkIsRead" runat="server" Enabled="false" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="Message" HeaderText="الرسالة" ItemStyle-Font-Size="11pt"
                                UniqueName="Message" />
                        </Columns>
                        <NoRecordsTemplate>
                            <div class="divEmptyData">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Empty.png" />
                                <span>لا يوجد طلبات شراء </span>
                            </div>
                        </NoRecordsTemplate>
                    </MasterTableView>
                </telerik:RadGrid>
            </div>
        </div>
        <div id="divWindow">
        </div>
        <telerik:RadWindow ID="rwRequestDetails" runat="server" Behaviors="Close" CssClass="row  Win"
            KeepInScreenBounds="true" Modal="True" OffsetElementID="divWindow" Title="طلب الشراء"
            Top="-10">
            <ContentTemplate>
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
            </ContentTemplate>
        </telerik:RadWindow>
    </div>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script>
            function OpenWindow() {
                var oWnd = $find("<%= rwRequestDetails.ClientID %>");
                oWnd.show();
            }
            
        </script>
    </telerik:RadCodeBlock>
</asp:Content>
