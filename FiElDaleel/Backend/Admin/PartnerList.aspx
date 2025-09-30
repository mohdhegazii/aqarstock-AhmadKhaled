<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="PartnerList.aspx.cs" Inherits="BrokerWeb.Backend.Admin.PartnerList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h4>قائمة صفحات شركائنا</h4>
            <div id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="panel-body">
        <div class="ContentItem">
            <asp:GridView ID="gvPartners" runat="server" DataKeyNames="ID" AutoGenerateColumns="False"
                CellPadding="4" CssClass="table table-striped table-bordered table-hover theGridTable rtlDirection"
                AllowPaging="True" PageSize="20">
                <AlternatingRowStyle />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Id" Visible="false" />
                      <asp:BoundField DataField="Title" HeaderText=" اسم الشركة" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-CssClass="GridColumnHeader" />
                    <asp:BoundField DataField="PageTitle" HeaderText=" عنوان الصفحة" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-CssClass="GridColumnHeader" />
              <%--             <asp:BoundField DataField="Description" HeaderText=" الوصف" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-CssClass="GridColumnHeader" />
                           <asp:BoundField DataField="KeyWords" HeaderText=" كلمات دالة" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-CssClass="GridColumnHeader" />--%>
                           <asp:BoundField DataField="URL" HeaderText=" رابط الصفحة" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-CssClass="GridColumnHeader" />
                <%--    <asp:ImageField DataImageUrlField="Logo">
                    </asp:ImageField>--%>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/icons/Edit.png" OnClientClick="OpenWindow()"
                                OnClick="ibtnEdit_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ibtnDelete" CssClass="Deleteconfirm" runat="server" ImageUrl="~/Images/icons/Delete.png"
                                OnClick="ibtnDelete_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <pagerstyle horizontalalign="Center" CssClass="pagerRow" />
            </asp:GridView>
        </div>
    </div>
    </div>
</asp:Content>
