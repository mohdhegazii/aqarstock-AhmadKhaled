<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master"
    AutoEventWireup="true" CodeBehind="ProjectList.aspx.cs" Inherits="BrokerWeb.Backend.Admin.ProjectList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            قائمة المشروعات
            <div id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="panel-body">
            <div class="ContentItem">
                <asp:Label ID="Label3" runat="server" CssClass="control-label" Text="اسم الشركة"></asp:Label>
                <asp:DropDownList ID="ddlCompanies" runat="server" CssClass="form-control">
                </asp:DropDownList>
            </div>
            <div class="ContentItem">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg btn-primary pull-left"
                    OnClick="btnSave_Click" Text="بحث" ValidationGroup="Save" />
            </div>
            <div class="ContentItem">
                <asp:GridView ID="gvPartners" runat="server" DataKeyNames="ID" AutoGenerateColumns="False"
                    CellPadding="4" CssClass="table table-striped table-bordered table-hover theGridTable rtlDirection">
                    <AlternatingRowStyle />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="Id" Visible="false" />
                        <asp:TemplateField HeaderText="" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnEdit" runat="server" OnClick="ibtnEdit_Click" ImageUrl="~/Images/icons/view.png" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Title" HeaderText="اسم المشروع" HeaderStyle-HorizontalAlign="Center"
                            HeaderStyle-CssClass="GridColumnHeader" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CountryName" HeaderText=" البلد" HeaderStyle-HorizontalAlign="Center"
                            HeaderStyle-CssClass="GridColumnHeader" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CityName" HeaderText=" المحافظة" HeaderStyle-HorizontalAlign="Center"
                            HeaderStyle-CssClass="GridColumnHeader" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                        </asp:BoundField>
                    </Columns>
                    <PagerStyle HorizontalAlign="Center" CssClass="pagerRow" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
