<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master"
    AutoEventWireup="true" CodeBehind="MessagesList.aspx.cs" Inherits="BrokerWeb.Backend.Admin.MessagesList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Header">
        <h1>
            الرسائل الجديدة
        </h1>
        <div id="divMsg" runat="server">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div class="Content">
        <div class="ContentItem">
            <asp:GridView ID="gvMessages" runat="server" DataKeyNames="ID" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="Grid table .table-hover"
                AllowPaging="True" PageSize="20" OnPageIndexChanging="gvMessages_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/ViewEmail.png" OnClick="ibtnEdit_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ID" HeaderText="Id" Visible="false" />
                    <asp:BoundField DataField="Type" HeaderText=" نوع الرسالة" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-CssClass="GridColumnHeader" />
                    <asp:BoundField DataField="Title" HeaderText=" عنوان الرسالة" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-CssClass="GridColumnHeader" />
                    <asp:BoundField DataField="CreatedDate" HeaderText=" تاريخ الارسال" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-CssClass="GridColumnHeader" />
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
