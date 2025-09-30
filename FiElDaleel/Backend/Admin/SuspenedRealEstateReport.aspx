<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master"
    AutoEventWireup="true" CodeBehind="SuspenedRealEstateReport.aspx.cs" Inherits="BrokerWeb.Backend.Admin.SuspenedRealEstateReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            تقرير بالعقارات المحجوبة
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
                <asp:Label ID="Label3" runat="server" CssClass="control-label" Text="سبب الحجب"></asp:Label>
                <asp:DropDownList ID="ddlReasons" runat="server" CssClass="form-control">
                </asp:DropDownList>
            </div>
            <div class="ContentItem">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg btn-primary pull-left"
                    OnClick="btnSave_Click" Text="بحث" ValidationGroup="Save" />
            </div>
            <div class="ContentItem">
                <telerik:RadGrid ID="rgSuspended" runat="server" AutoGenerateColumns="false">
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
                                        <asp:Label ID="lblCode" runat="server" Text='<%#Eval("Code") %>'></asp:Label>
                                    </a>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="عنوان اعلان العقار">
                                <ItemTemplate>
                                    <a href="<%#"RealEstateView/"+Eval("RealEstateID")+"/0" %>" target="_blank">
                                        <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title") %>'></asp:Label>
                                    </a>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="Reason" HeaderText="سبب الحجب" ItemStyle-Font-Size="11pt"
                                UniqueName="Reason" />
                            <telerik:GridBoundColumn DataField="SubscriberName" HeaderText="اسم المالك" ItemStyle-Font-Size="11pt"
                                UniqueName="SubscriberName" />
                            <telerik:GridBoundColumn DataField="SubscriberMobile" HeaderText="رقم هاتف المالك"
                                ItemStyle-Font-Size="11pt" UniqueName="SubscriberMobile" />
                        </Columns>
                        <NoRecordsTemplate>
                            <div class="divEmptyData">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Empty.png" />
                                <span>لا يوجد عقارات محجوبة </span>
                            </div>
                        </NoRecordsTemplate>
                    </MasterTableView>
                </telerik:RadGrid>
            </div>
        </div>
    </div>
</asp:Content>
