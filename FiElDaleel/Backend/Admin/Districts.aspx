<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Districts.aspx.cs" Inherits="BrokerWeb.Backend.Admin.Districts" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h4>الأحياء</h4>
            <div id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="panel-body">
            <div class="ContentItem row">
                <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12 pull-right">
                    <asp:Label ID="Label1" runat="server" CssClass="control-label" Text="البلد"></asp:Label>
                </div>
                <div class="col-lg-11 col-md-11 col-sm-11 col-xs-12">
                    <asp:DropDownList ID="ddlCountries" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlCountries_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCountries" CssClass="Validator" ErrorMessage="!" InitialValue="0" ValidationGroup="Save"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="ContentItem row">
                <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12 pull-right">
                    <asp:Label ID="Label3" runat="server" CssClass="control-label" Text="المحافظة"></asp:Label>
                </div>
                <div class="col-lg-11 col-md-11 col-sm-11 col-xs-12">
                    <asp:DropDownList ID="ddlCities" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlCities" CssClass="Validator" ErrorMessage="!" InitialValue="0" ValidationGroup="Save"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="ContentItem row">
                <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12 pull-right">
                    <asp:Label ID="Label2" runat="server" CssClass="control-label" Text="اسم الحى"></asp:Label>
                </div>
                <div class="col-lg-11 col-md-11 col-sm-11 col-xs-12">
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" CssClass="Validator" ErrorMessage="!" ValidationGroup="Save"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="ContentItem">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg btn-primary pull-left" OnClick="btnSave_Click" Text="حفظ" ValidationGroup="Save" />
            </div>
            <div class="ContentItem">
                <asp:GridView ID="gvDistricts" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-striped table-bordered table-hover theGridTable rtlDirection" DataKeyNames="ID" OnPageIndexChanging="gvDistricts_PageIndexChanging" PageSize="20">
                    <alternatingrowstyle />
                    <columns>
                        <asp:boundfield datafield="ID" headertext="Id" visible="false" />
                        <asp:boundfield datafield="CountryName" headerstyle-cssclass="GridColumnHeader" headerstyle-horizontalalign="Center" headertext="اسم البلد" />
                        <asp:boundfield datafield="CityName" headerstyle-cssclass="GridColumnHeader" headerstyle-horizontalalign="Center" headertext="اسم المحافظة" />
                        <asp:boundfield datafield="Name" headerstyle-cssclass="GridColumnHeader" headerstyle-horizontalalign="Center" headertext="اسم الحى" />
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
                    <PagerStyle HorizontalAlign="Center" CssClass="pagerRow" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
