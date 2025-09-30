<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucProjectVedio.ascx.cs"
    Inherits="BrokerWeb.Backend.SubScriber.UserControls.ucProjectVedio" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy2" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="gvVedios">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divVideoControls" LoadingPanelID="radLoadingPannel"
                    UpdatePanelRenderMode="Block" />
                <telerik:AjaxUpdatedControl ControlID="gvVedios" UpdatePanelRenderMode="Block" />
                <telerik:AjaxUpdatedControl ControlID="divMsg" UpdatePanelRenderMode="Block" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="lbtnAdd">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divVideoControls" LoadingPanelID="radLoadingPannel"
                    UpdatePanelRenderMode="Block" />
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
    <div>
        <asp:LinkButton ID="lbtnAdd" OnClientClick="OpenWindow()" runat="server" OnClick="lbtnAdd_Click">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/icons/AddNew.png"></asp:Image>
            <span>اضف فيديو للمشروع</span>
        </asp:LinkButton>
        <%--<a onclick="OpenWindow()">
            <asp:Image ID="imgAdd" runat="server" ImageUrl="~/Images/icons/AddNew.png"></asp:Image>
            <span>اضف فيديو للمشروع</span> </a>--%>
    </div>
</div>
<div class="Content">
    <telerik:RadWindow ID="rwRequestDetails" runat="server" Behaviors="Resize, Close"
        CssClass="row window" Width="700px" Height="430px" KeepInScreenBounds="true"
        Modal="True" OffsetElementID="divWindow" Title="بيانات الفيديو" Top="-10">
        <ContentTemplate>
            <div id="divVideoControls" class="row" style="margin-top: 10px; margin-right: 10px;"
                runat="server">
                <div class="pull-right">
                    <div class="ContentItem row">
                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                            <asp:Label ID="Label9" runat="server" Text="اسم الفيديو  *" CssClass="control-label"></asp:Label>
                        </div>
                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="SaveVedio"
                                CssClass="Validator" ControlToValidate="txtTitle" runat="server" Display="Dynamic"
                                ErrorMessage="! من فضلك ادخل اسم الفيديو"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                        <div class="ContentItem row">
                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                            <asp:Label ID="Label1" runat="server" Text=" الرابط*" CssClass="control-label"></asp:Label>
                        </div>
                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                            <asp:TextBox ID="txtURL" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="SaveVedio"
                                CssClass="Validator" ControlToValidate="txtURL" runat="server" Display="Dynamic"
                                ErrorMessage="! من فضلك ادخل الرابط"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="ContentItem row">
                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                            <asp:Label ID="Label5" runat="server" Text=" رمز التضمين *" CssClass="control-label"></asp:Label>
                        </div>
                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                            <asp:TextBox ID="txtEmbedCode" runat="server" CssClass="form-control" TextMode="MultiLine"
                                MaxLength="500" Style="width: 538px; height: 110px;" placeholder=" أكتب  رمز التضمين."></asp:TextBox>
                            <br />
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="SaveVedio"
                                CssClass="Validator" ControlToValidate="txtEmbedCode" runat="server" Display="Dynamic"
                                ErrorMessage="! من فضلك ادخل رمز التضمين"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row" style="margin-right: 10px;">
                <div class="ContentItem">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg " Text="حفظ" ValidationGroup="SaveVedio"
                        OnClick="btnSave_Click" />
                </div>
            </div>
        </ContentTemplate>
    </telerik:RadWindow>
    <div class="row">
        <div class="ContentItem">
            <asp:GridView ID="gvVedios" runat="server" DataKeyNames="ID" AutoGenerateColumns="False"
                CellPadding="4" CssClass="table table-striped table-bordered table-hover theGridTable"
                AllowPaging="True" PageSize="20" OnPageIndexChanging="gvVedios_PageIndexChanging">
                <AlternatingRowStyle />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Id" Visible="false" />
                    <asp:BoundField DataField="TiTle" HeaderText=" اسم الفيديو" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-CssClass="GridColumnHeader">
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
                            <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/icons/Edit.png"
                                OnClientClick="OpenWindow()" OnClick="ibtnEdit_Click" />
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
</div>
<telerik:RadCodeBlock ID="RadScriptBlock1" runat="server">
    <script type="text/javascript">
        function OpenWindow() {
            var oWnd = $find("<%= rwRequestDetails.ClientID %>");
            oWnd.show();
        }
    </script>
</telerik:RadCodeBlock>
