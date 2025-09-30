<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CatalogList.aspx.cs" Inherits="BrokerWeb.Backend.Admin.CatalogList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .row {
            margin: 0;
            padding: 0;
            margin-bottom: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h4>قائمة بكتالوجات العقارات</h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div id="divMsg" runat="server">
                    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row ContentItem">
                <asp:HyperLink ID="lNewCatalog" NavigateUrl="/NewCatalog" runat="server"><span class="glyphicon glyphicon-plus"></span><span>اضف كتالوج جديد</span></asp:HyperLink>
            </div>
            <div class="ContentItem row">
                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                <asp:Label ID="Label1" runat="server" CssClass="control-label" Text="اسم الفئة"></asp:Label>
                            </div>
                            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                <asp:DropDownList ID="ddlCategories" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCategories" CssClass="Validator" Display="Dynamic" ErrorMessage="الرجاء اختيار الفئة" InitialValue="0" ValidationGroup="Save"></asp:RequiredFieldValidator>
                            </div>
                        </div>
              <div class="row ContentItem">
                  <asp:Button ID="btnFilter" runat="server" CssClass="btn btn-lg btn-primary" Text="get" OnClick="btnFilter_Click" />
            </div>
            <div class="row ContentItem">
                <asp:GridView ID="gvCatalogs" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-striped table-bordered table-hover theGridTable rtlDirection" DataKeyNames="ID" PageSize="20" OnPageIndexChanging="gvCatalogs_PageIndexChanging">
                    <AlternatingRowStyle />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="Id" Visible="false" />
                        <%--<asp:BoundField DataField="Title" HeaderStyle-CssClass="GridColumnHeader" HeaderStyle-HorizontalAlign="Center" HeaderText="اسم الكتالوج" />--%>
                        <asp:HyperLinkField DataNavigateUrlFields="URL" DataTextField="Title" Target="_blank" HeaderStyle-CssClass="GridColumnHeader" HeaderStyle-HorizontalAlign="Center" HeaderText="اسم الكتالوج" />
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
