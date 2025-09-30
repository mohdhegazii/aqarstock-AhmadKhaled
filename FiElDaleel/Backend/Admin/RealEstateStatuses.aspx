<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="RealEstateStatuses.aspx.cs" Inherits="BrokerWeb.Backend.Admin.RealEstateStatuses" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <style>
        
        .row{
            margin: 0 0 20px 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h4>حالات العقارات</h4>
            <div id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-4 pull-right">
                    <div class="ContentItem row">
                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                            <asp:Label ID="Label1" runat="server" CssClass="control-label" Text="الفئة"></asp:Label>
                        </div>
                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                            <asp:DropDownList ID="ddlCategories" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCategories" CssClass="Validator" Display="Dynamic" ErrorMessage="!" InitialValue="0" ValidationGroup="Save"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="ContentItem row">
                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                            <asp:Label ID="Label2" runat="server" CssClass="control-label" Text="الاسم"></asp:Label>
                        </div>
                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" CssClass="Validator" ErrorMessage="!" ValidationGroup="Save"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                </div>
            </div>
            <div class="ContentItem">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg btn-primary pull-left" OnClick="btnSave_Click" Text="حفظ" ValidationGroup="Save" />
            </div>
            <div class="ContentItem">
                <asp:GridView ID="gvStatus" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-striped table-bordered table-hover theGridTable rtlDirection" DataKeyNames="ID" PageSize="20">
                    <alternatingrowstyle />
                    <columns>
                        <asp:boundfield datafield="ID" headertext="Id" visible="false" />
                        <asp:boundfield datafield="CategoryTitle" headerstyle-cssclass="GridColumnHeader" headerstyle-horizontalalign="Center" headertext=" الفئة" />
                        <asp:boundfield datafield="Title" headerstyle-cssclass="GridColumnHeader" headerstyle-horizontalalign="Center" headertext=" الاسم" />
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
    </div>
</asp:Content>
