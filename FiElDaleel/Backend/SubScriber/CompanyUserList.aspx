<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/SubScriber/SubscriberMaster.Master"
    AutoEventWireup="true" CodeBehind="CompanyUserList.aspx.cs" Inherits="BrokerWeb.Backend.SubScriber.CompanyUserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('.rgMasterTable').addClass('table table-striped table-bordered table-hover theGridTable');

            $('.RadGrid').removeClass('RadGrid RadGrid_Default RadGridRTL RadGridRTL_Default');
        });
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
           <telerik:AjaxSetting AjaxControlID="gvUsers">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="divMsg" UpdatePanelRenderMode="Inline"  />
                    <telerik:AjaxUpdatedControl ControlID="gvUsers" LoadingPanelID="radLoadingPannel"
                        UpdatePanelRenderMode="Inline" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
        </telerik:RadAjaxManagerProxy>
<div class="panel panel-primary">

    <div class="panel-heading">
      قائمة الموظفين
        <div id="divMsg" runat="server">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div class="panel-body">
        <asp:GridView ID="gvUsers" runat="server" DataKeyNames="ID" AutoGenerateColumns="False"
            CellPadding="4" CssClass="table table-striped table-bordered theGridTable"
            AllowPaging="True" PageSize="20"  
            OnPageIndexChanging="gvUsers_PageIndexChanging">
            <AlternatingRowStyle />
            <Columns>
                   <asp:TemplateField HeaderText="مسؤول الحساب">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkIsAdmin" runat="server" Checked='<%#CheckAdminStatus(Eval("IsCompanyAdmin")) %>' AutoPostBack="True" 
                            oncheckedchanged="chkIsAdmin_CheckedChanged" />
                       
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ID" HeaderText="Id" Visible="false" />
                <asp:BoundField DataField="FullName" HeaderText="الاسم بالكامل" HeaderStyle-HorizontalAlign="Center"
                    HeaderStyle-CssClass="GridColumnHeader" >
<HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField DataField="UserName" HeaderText="اسم المستخدم" HeaderStyle-HorizontalAlign="Center"
                    HeaderStyle-CssClass="GridColumnHeader" >
<HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                </asp:BoundField>
                    <asp:BoundField DataField="Email" HeaderText="البريد الالكترونى" HeaderStyle-HorizontalAlign="Center"
                    HeaderStyle-CssClass="GridColumnHeader" >
<HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                </asp:BoundField>
                    <asp:BoundField DataField="MobileNo" HeaderText="رقم الهاتف" HeaderStyle-HorizontalAlign="Center"
                    HeaderStyle-CssClass="GridColumnHeader" >
<HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                </asp:BoundField>
                    <asp:TemplateField HeaderText="حذف">
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnDelete" CssClass="Deleteconfirm" runat="server" ImageUrl="~/Images/icons/Delete.png"
                            OnClick="ibtnDelete_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
             
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#ea5821" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#ea5821" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#ea5821" ForeColor="White" HorizontalAlign="Center" />
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
