<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SubscriberReport.aspx.cs" Inherits="BrokerWeb.Backend.Admin.SubscriberReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="panel panel-primary">
        <div class="panel-heading">
            <h4>تقرير بالمشتركين الجدد</h4>
            <div id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
              
            </div>
        </div>
        <div class="panel-body">
            <div class="ContentItem">
                <asp:Label ID="Label2" runat="server" CssClass="control-label" Text="من تاريخ"></asp:Label>
                <telerik:RadDatePicker ID="rdpFrom" runat="server">
                </telerik:RadDatePicker>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rdpFrom" CssClass="Validator" ErrorMessage="!" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
                <div class="ContentItem">
                <asp:Label ID="Label1" runat="server" CssClass="control-label" Text="الى تاريخ"></asp:Label>
                <telerik:RadDatePicker ID="rdpTo" runat="server">
                </telerik:RadDatePicker>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rdpTo" CssClass="Validator" ErrorMessage="!" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
               <div class="ContentItem">
                <asp:Label ID="Label3" runat="server" CssClass="control-label" Text="حالة الحساب"></asp:Label>
                   <asp:RadioButtonList ID="rblActiveStatus" runat="server" RepeatDirection="Horizontal">
                       <asp:ListItem Selected="True" Text="الكل" Value="0"></asp:ListItem>
                       <asp:ListItem  Text="تم تفعيله" Value="1"></asp:ListItem>
                       <asp:ListItem  Text="غير مفعل" Value="2"></asp:ListItem>
                   
                   </asp:RadioButtonList>
            </div>
            <div class="ContentItem">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg btn-primary pull-left" OnClick="btnSave_Click" Text="بحث" ValidationGroup="Save" />
            </div>
            <div class="ContentItem">
                <asp:GridView ID="gvSubscribers" runat="server" AllowPaging="True" PageSize="50"
                    AutoGenerateColumns="False" CellPadding="4" 
                    CssClass="table table-striped table-bordered table-hover theGridTable rtlDirection" 
                    DataKeyNames="ID" onrowdatabound="gvSubscribers_RowDataBound" OnPageIndexChanging="gvSubscribers_PageIndexChanging">
                    <alternatingrowstyle />
                    <columns>
                        <asp:boundfield datafield="ID" headertext="Id" visible="false" />
                        <asp:boundfield datafield="FullName" headerstyle-cssclass="GridColumnHeader" headerstyle-horizontalalign="Center" headertext="الاسم بالكامل" />
                         <asp:boundfield datafield="UserName" headerstyle-cssclass="GridColumnHeader" headerstyle-horizontalalign="Center" headertext="اسم المستخدم" />
                          <asp:boundfield datafield="MobileNo" headerstyle-cssclass="GridColumnHeader" headerstyle-horizontalalign="Center" headertext="رقم الهاتف" />
                           <asp:boundfield datafield="Email" headerstyle-cssclass="GridColumnHeader" headerstyle-horizontalalign="Center" headertext="البريد الالكترونى" />
                        <asp:templatefield headerstyle-cssclass="GridColumnHeader" headerstyle-horizontalalign="Center" headertext="تم التفعيل" >
                            <itemtemplate>
                                <asp:CheckBox ID="chkIsActive" runat="server" Enabled="false" />
                            </itemtemplate>
                        </asp:templatefield>
                     
                    </columns>
                    <PagerStyle HorizontalAlign="Center" CssClass="pagerRow" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
