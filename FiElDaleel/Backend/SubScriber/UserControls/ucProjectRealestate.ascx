<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucProjectRealestate.ascx.cs" Inherits="BrokerWeb.Backend.SubScriber.UserControls.ucProjectRealestate" %>
<telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy2" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="gvRealestate">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="gvRealestate"/>
                <telerik:AjaxUpdatedControl ControlID="gvRealestate" UpdatePanelRenderMode="Block"  LoadingPanelID="radLoadingPannel"/>
                <telerik:AjaxUpdatedControl ControlID="ddlRealestate" UpdatePanelRenderMode="Block" />
                <telerik:AjaxUpdatedControl ControlID="divMsg" UpdatePanelRenderMode="Block" />
            </UpdatedControls>
        </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSave">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="ddlRealestate" UpdatePanelRenderMode="Block" />
                <telerik:AjaxUpdatedControl ControlID="gvRealestate" UpdatePanelRenderMode="Block" LoadingPanelID="radLoadingPannel"/>
                <telerik:AjaxUpdatedControl ControlID="divMsg" UpdatePanelRenderMode="Block" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<div class="Header">
    <%-- <h1>
        صور العقار/الارض
    </h1>--%>
    <div id="divMsg" runat="server">
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
    </div>
   <div class="Content">
       <div class="ContentItem row">
                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                    <asp:Label ID="Label13" runat="server" Text="اعلان العقار *" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                    <asp:DropDownList ID="ddlRealestate" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Save" CssClass="Validator"
                        ControlToValidate="ddlRealestate" runat="server" ErrorMessage="! من فضلك اختار عقار"
                        InitialValue="0"></asp:RequiredFieldValidator>
                </div>
       </div>
       <div class="ContentItem row">
              <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg " Text="حفظ"
                ValidationGroup="Save" OnClick="btnSave_Click" />
       </div>
       <div class="ContentItem row">
             <asp:GridView ID="gvRealestate" runat="server" DataKeyNames="ID" AutoGenerateColumns="False"
                CellPadding="4" CssClass="table table-striped table-bordered table-hover theGridTable"
                AllowPaging="True" PageSize="20" >
                <AlternatingRowStyle />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Id" Visible="false" />
                    <asp:BoundField DataField="Price" HeaderText="السعر" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-CssClass="GridColumnHeader" >
                        <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                    </asp:BoundField>
                       <asp:BoundField DataField="Area" HeaderText="المساحة" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-CssClass="GridColumnHeader" >
                        <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                    </asp:BoundField>  
                    <asp:BoundField DataField="Type" HeaderText=" نوع العقار" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-CssClass="GridColumnHeader" >
                        <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                    </asp:BoundField>
                   <asp:BoundField DataField="Title" HeaderText=" اعلان العقار" HeaderStyle-HorizontalAlign="Center"
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
