<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminDashBoard.aspx.cs" Inherits="BrokerWeb.Backend.Admin.AdminDashBoard" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="panel panel-primary">

        <div class="panel-heading">
             <h4>أخر الاضافات على الموقع</h4>
        </div>
        <div class="panel-body">
            <asp:GridView ID="gvNewObjects" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-striped table-bordered table-hover theGridTable" DataKeyNames="ID" OnPageIndexChanging="gvNewObjects_PageIndexChanging" OnRowDataBound="gvNewObjects_RowDataBound" PageSize="20">
                <alternatingrowstyle />
                <columns>
                    <asp:templatefield>
                        <itemtemplate>
                            <asp:ImageButton ID="ibtnReview" runat="server" ImageUrl="~/Images/icons/view.png" />
                        </itemtemplate>
                    </asp:templatefield>
                    <asp:templatefield headerstyle-cssclass="GridColumnHeader" headerstyle-horizontalalign="Center" headertext="النوع">
                        <itemtemplate>
                            <asp:Label ID="lblModule" runat="server" class="text-center" Text="Label"></asp:Label>
                        </itemtemplate>
                    </asp:templatefield>
                    <asp:templatefield headerstyle-cssclass="GridColumnHeader" headerstyle-horizontalalign="Center" headertext="نوع الاجراء" itemstyle-horizontalalign="Center">
                        <itemtemplate>
                            <asp:Label ID="lblAction" runat="server" Text="Label"></asp:Label>
                        </itemtemplate>
                    </asp:templatefield>
                    <asp:boundfield datafield="ID" headertext="Id" visible="false" />
                    <asp:boundfield datafield="ObjectName" headerstyle-cssclass="GridColumnHeader" headerstyle-horizontalalign="Center" headertext=" الاسم" itemstyle-horizontalalign="Center" />
                    <%--
                        <asp:BoundField DataField="Module" HeaderText=" النوع" HeaderStyle-HorizontalAlign="Center"
                                        HeaderStyle-CssClass="GridColumnHeader" />
                                        <asp:BoundField DataField="Action" HeaderText=" الاجراء الجديد" HeaderStyle-HorizontalAlign="Center"
                                        HeaderStyle-CssClass="GridColumnHeader" />
                    --%>
                    <asp:boundfield datafield="Date" headerstyle-cssclass="GridColumnHeader" dataformatstring="{0:dd/MM/yyyy}"  headerstyle-horizontalalign="Center" headertext=" تاريخ الاجراء" itemstyle-horizontalalign="Center" />
                </columns>
                <editrowstyle backcolor="#999999" />
                <footerstyle backcolor="#5D7B9D" font-bold="True" forecolor="White" CssClass="gridFoot" />
                <headerstyle backcolor="#5D7B9D" font-bold="True" forecolor="White" />
                <pagerstyle backcolor="#284775" forecolor="White" horizontalalign="Center" CssClass="pagerRow" />
                <rowstyle backcolor="#F7F6F3" forecolor="#333333" horizontalalign="Center" />
                <selectedrowstyle backcolor="#E2DED6" font-bold="True" forecolor="#333333" />
                <sortedascendingcellstyle backcolor="#E9E7E2" />
                <sortedascendingheaderstyle backcolor="#506C8C" />
                <sorteddescendingcellstyle backcolor="#FFFDF8" />
                <sorteddescendingheaderstyle backcolor="#6F8DAE" />
            </asp:GridView>
        </div>
    </div>

</asp:Content>
