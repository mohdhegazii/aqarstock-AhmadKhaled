<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/SubScriber/SubscriberMaster.Master" AutoEventWireup="true" CodeBehind="ProjectList.aspx.cs" Inherits="BrokerWeb.Backend.SubScriber.ProjectList" %>
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
                    <telerik:AjaxUpdatedControl ControlID="gvProjects" LoadingPanelID="radLoadingPannel"
                        UpdatePanelRenderMode="Inline" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
        </telerik:RadAjaxManagerProxy>
<div class="panel panel-primary">

    <div class="panel-heading">
      قائمة المشروعات
        <div id="divMsg" runat="server">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div class="panel-body">
        <asp:GridView ID="gvProjects" runat="server" DataKeyNames="ID" AutoGenerateColumns="False"
            CellPadding="4" CssClass="table table-striped table-bordered  theGridTable"
            AllowPaging="True" PageSize="20" 
            OnPageIndexChanging="gvProjects_PageIndexChanging">
            <AlternatingRowStyle />
            <Columns>
              
                <asp:BoundField DataField="ID" HeaderText="Id" Visible="false" />
             
                    <asp:BoundField DataField="CountryName" HeaderText=" البلد" HeaderStyle-HorizontalAlign="Center"
                    HeaderStyle-CssClass="GridColumnHeader" >
<HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                </asp:BoundField>
                    <asp:BoundField DataField="CityName" HeaderText=" المحافظة" HeaderStyle-HorizontalAlign="Center"
                    HeaderStyle-CssClass="GridColumnHeader" >
<HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                </asp:BoundField>
                   <asp:BoundField DataField="Title" HeaderText="اسم المشروع" HeaderStyle-HorizontalAlign="Center"
                    HeaderStyle-CssClass="GridColumnHeader" >
<HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                </asp:BoundField>
                    <asp:TemplateField HeaderText="حذف" HeaderStyle-HorizontalAlign="Center">
                    <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnDelete" CssClass="DoubleDeleteconfirm" runat="server" ImageUrl="~/Images/icons/Delete.png"
                            OnClick="ibtnDelete_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="تعديل" HeaderStyle-HorizontalAlign="Center">
                    <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnEdit"  runat="server" PostBackUrl='<%#"~/تعديل_بيانات_المشروع/"+Eval("ID")%>' ImageUrl="~/Images/icons/Edit.png"
                            />
                    </ItemTemplate>
                </asp:TemplateField>  
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#ea5821" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#ea5821" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#ea5821" ForeColor="Black" HorizontalAlign="Center" />
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
