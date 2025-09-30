<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CompanyList.aspx.cs" Inherits="BrokerWeb.Backend.Admin.CompanyList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h4>قائمة الشركات العقارية</h4>
            <div id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="panel-body">
        <div class="ContentItem">
            <asp:GridView ID="gvPartners" runat="server" DataKeyNames="ID" AutoGenerateColumns="False"
                CellPadding="4" CssClass="table table-striped table-bordered table-hover theGridTable rtlDirection">
                <AlternatingRowStyle />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Id" Visible="false" />
                          <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/icons/view.png"
                                OnClick="ibtnEdit_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:BoundField DataField="Title" HeaderText=" اسم الشركة" HeaderStyle-CssClass="GridColumnHeader"/>
             
                <%--    <asp:ImageField DataImageUrlField="Logo">
                    </asp:ImageField>--%>
              

                </Columns>
                <pagerstyle horizontalalign="Center" CssClass="pagerRow" />
            </asp:GridView>
        </div>
    </div>
    </div>
</asp:Content>
