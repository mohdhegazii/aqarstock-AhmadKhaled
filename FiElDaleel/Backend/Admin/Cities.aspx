<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Cities.aspx.cs" Inherits="BrokerWeb.Backend.Admin.Cities" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div class="panel panel-primary">
        <div class="panel-heading">
            <h4>المحافظات</h4>
            <div id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="panel-body">
            <div class="ContentItem row">
                <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12 pull-right">
                    <asp:Label ID="Label1" runat="server" CssClass="control-label" Text="اسم البلد"></asp:Label>
                </div>
                <div class="col-lg-11 col-md-11 col-sm-11 col-xs-12">
                    <asp:DropDownList ID="ddlCountries" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCountries" CssClass="Validator" Display="Dynamic" ErrorMessage="!" InitialValue="0" ValidationGroup="Save"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="ContentItem row">
                <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12 pull-right">
                    <asp:Label ID="Label2" runat="server" CssClass="control-label" Text="اسم المحافظة"></asp:Label>
                </div>
                <div class="col-lg-11 col-md-11 col-sm-11 col-xs-12">
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" CssClass="Validator" Display="Dynamic" ErrorMessage="!" ValidationGroup="Save"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="ContentItem">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg btn-primary pull-left" OnClick="btnSave_Click" Text="حفظ" ValidationGroup="Save" />
            </div>


            <asp:GridView ID="gvCities" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-striped table-bordered table-hover theGridTable rtlDirection" DataKeyNames="ID" OnPageIndexChanging="gvCities_PageIndexChanging" PageSize="20">
                <alternatingrowstyle />
                <columns>
                    <asp:boundfield datafield="ID" headertext="Id" visible="false" />
                    <asp:boundfield datafield="CountryName" headerstyle-cssclass="GridColumnHeader" headerstyle-horizontalalign="Center" headertext="اسم البلد" />
                    <asp:boundfield datafield="Name" headerstyle-cssclass="GridColumnHeader" headerstyle-horizontalalign="Center" headertext="اسم المحافظة" />
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
</asp:Content>
