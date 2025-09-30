<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Keywords.aspx.cs" Inherits="BrokerWeb.Backend.Admin.Keywords" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h4>كلمات دالة</h4>
            <div id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="panel-body">
            <div class="ContentItem">
                <asp:Label ID="Label2" runat="server" CssClass="control-label" Text="كلمة دالة"></asp:Label>
                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" CssClass="Validator" ErrorMessage="!" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
            <div class="ContentItem">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg btn-primary pull-left" OnClick="btnSave_Click" Text="حفظ" ValidationGroup="Save" />
            </div>
            <div class="ContentItem">
                <asp:GridView ID="gvKeywords" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-striped table-bordered table-hover theGridTable rtlDirection" DataKeyNames="ID" OnPageIndexChanging="gvKeywords_PageIndexChanging" PageSize="20">
                    <alternatingrowstyle />
                    <columns>
                        <asp:boundfield datafield="ID" headertext="Id" visible="false" />
                        <asp:boundfield datafield="Title" headerstyle-cssclass="GridColumnHeader" headerstyle-horizontalalign="Center" headertext="كلمة دالة" />
                        <asp:templatefield>
                            <itemtemplate>
                                <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/icons/Edit.png" OnClick="ibtnEdit_Click" OnClientClick="OpenWindow()" />
                            </itemtemplate>
                        </asp:templatefield>
                        <asp:templatefield>
                            <itemtemplate>
                                <asp:ImageButton ID="ibtnDelete" runat="server" CssClass="Deleteconfirm" ImageUrl="~/Images/icons/Delete.png" OnClick="ibtnDelete_Click" />
                            </itemtemplate>
                        </asp:templatefield>
                    </columns>
                    <pagerstyle horizontalalign="Center" CssClass="pagerRow" />
                </asp:GridView>
            </div>
        </div>
</asp:Content>
