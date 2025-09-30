<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master"
    AutoEventWireup="true" CodeBehind="Districts.aspx.cs" Inherits="BrokerWeb.Backend.Admin.Districts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Header">
        <h1>
            الاحياء
        </h1>
        <div id="divMsg" runat="server">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div class="Content">
        <div class="ContentItem row">
        <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12 pull-right">
            <asp:Label ID="Label1" runat="server" Text="البلد" CssClass="control-label"></asp:Label>
            </div>
            <div class="col-lg-11 col-md-11 col-sm-11 col-xs-12">
            <asp:DropDownList ID="ddlCountries" runat="server" CssClass="form-control" AutoPostBack="True"
                OnSelectedIndexChanged="ddlCountries_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Save" CssClass="Validator"
                ControlToValidate="ddlCountries" runat="server" ErrorMessage="!" InitialValue="0"></asp:RequiredFieldValidator>
        </div></div>
        <div class="ContentItem row">
        <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12 pull-right">
            <asp:Label ID="Label3" runat="server" Text="المحافظة" CssClass="control-label"></asp:Label>
            </div>
            <div class="col-lg-11 col-md-11 col-sm-11 col-xs-12">
            <asp:DropDownList ID="ddlCities" runat="server" CssClass="form-control">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Save" CssClass="Validator"
                ControlToValidate="ddlCities" runat="server" ErrorMessage="!" InitialValue="0"></asp:RequiredFieldValidator>
        </div></div>
        <div class="ContentItem row">
        <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12 pull-right">
            <asp:Label ID="Label2" runat="server" Text="اسم الحى" CssClass="control-label"></asp:Label>
            </div>
            <div class="col-lg-11 col-md-11 col-sm-11 col-xs-12">
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Save" CssClass="Validator"
                ControlToValidate="txtName" runat="server" ErrorMessage="!"></asp:RequiredFieldValidator>
        </div></div>
        <div class="ContentItem">
            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg" Text="حفظ" ValidationGroup="Save"
                OnClick="btnSave_Click" />
        </div>
        <div class="ContentItem">
            <asp:GridView ID="gvDistricts" runat="server" DataKeyNames="ID" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="Grid table .table-hover"
                AllowPaging="True" PageSize="20" OnPageIndexChanging="gvDistricts_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Id" Visible="false" />
                    <asp:BoundField DataField="CountryName" HeaderText="اسم البلد" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-CssClass="GridColumnHeader" />
                    <asp:BoundField DataField="CityName" HeaderText="اسم المحافظة" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-CssClass="GridColumnHeader" />
                    <asp:BoundField DataField="Name" HeaderText="اسم الحى" HeaderStyle-HorizontalAlign="Center"
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
