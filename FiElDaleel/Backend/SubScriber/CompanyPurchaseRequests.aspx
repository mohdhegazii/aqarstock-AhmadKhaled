<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/SubScriber/SubscriberMaster.Master"
    AutoEventWireup="true" CodeBehind="CompanyPurchaseRequests.aspx.cs" Inherits="BrokerWeb.Backend.SubScriber.CompanyPurchaseRequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgRequests">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgRequests" UpdatePanelRenderMode="Block" />
                    <telerik:AjaxUpdatedControl ControlID="divWindowDetail" UpdatePanelRenderMode="Block"
                        LoadingPanelID="radLoadingPannel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <%--     <telerik:AjaxSetting AjaxControlID="btnSave">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgRequests" UpdatePanelRenderMode="Block" />
                </UpdatedControls>
            </telerik:AjaxSetting>--%>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <%--    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting ajaxcontrolid="rgRequests">
                <UpdatedControls>
                    <telerik:ajaxupdatedcontrol controlid="divRequestDetails" loadingpanelid="radLoadingPannel" updatepanelrendermode="Block" />
                    <telerik:ajaxupdatedcontrol controlid="rgRequests" updatepanelrendermode="Block" />
                    <telerik:ajaxupdatedcontrol controlid="lblMsg" updatepanelrendermode="Block" />
                </UpdatedControls>
            </telerik:AjaxSetting>
       </AjaxSettings>
    </telerik:RadAjaxManagerProxy>--%>
    <div class="panel panel-primary">
        <div class="panel-heading">
            تقرير بطلبات الشراء الجديدة
            <div id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="panel-body">
        <div class=pull-right" style="margin-right:10px">
            <div class="ContentItem row">
                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                    <asp:Label ID="Label2" runat="server" CssClass="control-label" Text="من تاريخ"></asp:Label>
                </div>
                <telerik:RadDatePicker ID="rdpFrom" runat="server">
                </telerik:RadDatePicker>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rdpFrom"
                    CssClass="Validator" ErrorMessage="!" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
            <div class="ContentItem row">
                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                    <asp:Label ID="Label1" runat="server" CssClass="control-label" Text="الى تاريخ"></asp:Label>
                </div>
                <telerik:RadDatePicker ID="rdpTo" runat="server">
                </telerik:RadDatePicker>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rdpTo"
                    CssClass="Validator" ErrorMessage="!" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
            <div class="ContentItem row">
                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                    <asp:Label ID="Label4" runat="server" Text="اسم الموظف" CssClass="control-label"></asp:Label>
                </div>
                <telerik:RadComboBox ID="rcbSubscribers" runat="server" MarkFirstMatch="true" EnableTextSelection="true"
                    AllowCustomText="True" CssClass="form-control ComboBox" Style="width: 160px !important"
                    EmptyMessage="ادخل اسم المالك">
                </telerik:RadComboBox>
            </div>
            <div class="ContentItem row">
                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                    <asp:Label ID="Label3" runat="server" CssClass="control-label" Text="حالة الطلب"></asp:Label>
                </div>
                <asp:RadioButtonList ID="rblReadStatus" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Text="الكل" Value="0"></asp:ListItem>
                    <asp:ListItem Text="تم قرائته" Value="1"></asp:ListItem>
                    <asp:ListItem Text="لم يتم قرائته" Value="2"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="ContentItem row">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg pull-left"
                    OnClick="btnSave_Click" Text="بحث" ValidationGroup="Save" />
            </div>
            <div class="ContentItem row">
            <asp:GridView ID="rgRequests" runat="server" AllowPaging="true" DataKeyNames="ID" AutoGenerateColumns="false"
            CellPadding="4" CssClass="table table-striped table-bordered theGridTable" style="font-size:12px;"
            PageSize="10"  OnPageIndexChanging="rgRequests_NeedDataSource"  onrowdatabound="rgRequests_RowDataBound">
            <%--    <MasterTableView DataKeyNames="ID" AllowPaging="true">--%>
                    <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Id" Visible="false" />
                        <%--     <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/icons/view.png"
                                    OnClick="ibtnEdit_Click" OnClientClick="OpenWindow()" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:BoundField DataField="Message" HeaderText="الرسالة" HeaderStyle-HorizontalAlign="Center"  headerstyle-cssclass="GridColumnHeader"/>
                         <asp:BoundField DataField="PurchaserPhone" HeaderText="رقم هاتف المشترى" HeaderStyle-HorizontalAlign="Center"  headerstyle-cssclass="GridColumnHeader"/>
                         <asp:BoundField DataField="PurchaserName" HeaderText="اسم المشترى" HeaderStyle-HorizontalAlign="Center"  headerstyle-cssclass="GridColumnHeader"/>
                         <asp:TemplateField HeaderText="تم قرائته" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-CssClass="GridColumnHeader">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkIsRead" runat="server" Enabled="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Date" DataFormatString="{0:dd/MM/yyyy}"
                            HeaderText="التاريخ" HeaderStyle-HorizontalAlign="Center"  headerstyle-cssclass="GridColumnHeader">
                        </asp:BoundField>
                        <asp:BoundField DataField="SubscriberName" HeaderText="اسم الموظف"  HeaderStyle-HorizontalAlign="Center"  headerstyle-cssclass="GridColumnHeader"/>
                        <asp:TemplateField HeaderText="عنوان اعلان العقار" HeaderStyle-HorizontalAlign="Center"  headerstyle-cssclass="GridColumnHeader">
                            <ItemTemplate>
                                <a href="<%#"عرض_بيانات_العقار/"+Eval("RealEstateID") %>" target="_blank">
                                    <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="الكود" HeaderStyle-HorizontalAlign="Center"  headerstyle-cssclass="GridColumnHeader">
                            <ItemTemplate>
                                <a href="<%#"عرض_بيانات_العقار/"+Eval("RealEstateID") %>" target="_blank">
                                    <asp:Label ID="lblCode" runat="server" Text=""></asp:Label>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--     <asp:BoundField DataField="PurchaserEmail" HeaderText="البريد الالكترونى المشترى"
                             UniqueName="PurchaserEmail" />--%>
                        
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
            
        </script>
    </telerik:RadCodeBlock>
</asp:Content>
