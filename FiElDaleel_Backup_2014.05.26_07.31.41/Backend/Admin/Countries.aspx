<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master"
    AutoEventWireup="true" CodeBehind="Countries.aspx.cs" Inherits="BrokerWeb.Backend.Admin.Countries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Header">
        <h1>
            البلاد
        </h1>
        <div id="divMsg" runat="server">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div class="Content">
        <div class="ContentItem">
            <asp:Label ID="Label2" runat="server" Text="اسم البلد" CssClass="control-label"></asp:Label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Save" CssClass="Validator"
                ControlToValidate="txtName" runat="server" ErrorMessage="!"></asp:RequiredFieldValidator>
        </div>
        <div class="ContentItem">
            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg" Text="حفظ" ValidationGroup="Save"
                OnClick="btnSave_Click" />
        </div>
        <div class="ContentItem">
            <asp:GridView ID="gvCountries" runat="server" DataKeyNames="ID" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="Grid table .table-hover"
                AllowPaging="True" PageSize="20" OnPageIndexChanging="gvCountries_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Id" Visible="false" />
                    <asp:BoundField DataField="Name" HeaderText="اسم البلد" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-CssClass="GridColumnHeader" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/Edit.png" OnClientClick="OpenWindow()"
                                OnClick="ibtnEdit_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ibtnDelete" CssClass="Deleteconfirm" runat="server" ImageUrl="~/Images/Delete.png"
                                OnClick="ibtnDelete_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
