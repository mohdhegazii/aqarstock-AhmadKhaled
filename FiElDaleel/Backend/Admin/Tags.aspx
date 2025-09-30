<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Tags.aspx.cs" Inherits="BrokerWeb.Backend.Admin.Tags" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h4>كلمات دالة</h4>
            <div id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="panel-body">
            <div class="ContentItem row">
                <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12 pull-right">
                    <asp:Label ID="Label3" runat="server" CssClass="control-label" Text="كلمات البحث الأساسية"></asp:Label>
                </div>
                <div class="col-lg-11 col-md-11 col-sm-11 col-xs-12">
                    <asp:DropDownList ID="ddlParent" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="ContentItem">
                <asp:Label ID="Label2" runat="server" CssClass="control-label" Text="كلمة البحث"></asp:Label>
                <asp:TextBox ID="txtKeyWord" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtKeyWord" CssClass="Validator" ErrorMessage="!" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
            <div class="ContentItem">
                <asp:Label ID="Label1" runat="server" CssClass="control-label" Text="الرابط"></asp:Label>
                <asp:TextBox ID="txtURL" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtURL" CssClass="Validator" ErrorMessage="!" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
            <div class="ContentItem">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg btn-primary pull-left" OnClick="btnSave_Click" Text="حفظ" ValidationGroup="Save" />
            </div>
            <div class="ContentItem">
                <asp:GridView ID="gvkeywords" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-striped table-bordered table-hover theGridTable rtlDirection" DataKeyNames="ID" OnPageIndexChanging="gvCountries_PageIndexChanging" PageSize="20">
                    <AlternatingRowStyle />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="Id" Visible="false" />
                        <asp:BoundField DataField="Name" HeaderStyle-CssClass="GridColumnHeader" HeaderStyle-HorizontalAlign="Center" HeaderText="كلمة البحث" />
                        <asp:BoundField DataField="ParentName" HeaderStyle-CssClass="GridColumnHeader" HeaderStyle-HorizontalAlign="Center" HeaderText="كلمة البحث الأساسية" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/icons/Edit.png" OnClick="ibtnEdit_Click" OnClientClick="OpenWindow()" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnDelete" runat="server" CssClass="Deleteconfirm" ImageUrl="~/Images/icons/Delete.png" OnClick="ibtnDelete_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle HorizontalAlign="Center" CssClass="pagerRow" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
