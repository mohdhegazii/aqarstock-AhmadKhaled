<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucChangePassword.ascx.cs" Inherits="BrokerWeb.Backend.Admin.UserControls.ucChangePassword" %>
        <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
     
               <telerik:AjaxSetting AjaxControlID="btnSave">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="divMsg" UpdatePanelRenderMode="Inline" LoadingPanelID="radLoadingPannel"/>
              <telerik:AjaxUpdatedControl ControlID="divContent" UpdatePanelRenderMode="Inline" LoadingPanelID="radLoadingPannel"/>
               </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
       <div class="Header">
  
        <div id="divMsg" runat="server">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </div>
    </div>
     <div class="Content" id="divContent" runat="server">
                  <div class="ContentItem row" id="divPassword" runat="server">
                <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                    <asp:Label ID="Label4" runat="server" Text="كلمة السر *" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                    <asp:TextBox ID="txtRegPassword" runat="server" TextMode="Password" placeholder="كلمة السر"
                        class="form-control" ValidationGroup="ChangePass"></asp:TextBox>
                
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="ChangePass"
                            CssClass="Validator" ControlToValidate="txtRegPassword" Display="Dynamic" runat="server"
                            ErrorMessage="!  من فضلك ادخل كلمة السر"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="ContentItem row" id="divNewPassword" runat="server">
                <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                    <asp:Label ID="Label5" runat="server" Text=" كلمة السر الجديدة *" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                    <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" placeholder=" كلمة السر الجديدة"
                        class="form-control" ValidationGroup="ChangePass"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPassword"
                        ErrorMessage="! من فضلك ادخل كلمة السرالجديدة" ValidationGroup="ChangePass" CssClass="Validator" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="من فضلك ادخل على الأقل 6 و 32 حرفا كحد أقصى"
                        ControlToValidate="txtNewPassword" ValidationGroup="ChangePass" ValidationExpression="^.{6,32}$"
                        CssClass="Validator" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="ContentItem row" id="divConfirmNewPassword" runat="server">
                <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                    <asp:Label ID="Label7" runat="server" Text="تاكيد كلمة السر الجديدة *" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                    <asp:TextBox ID="txtConfirmNewPassword" runat="server" TextMode="Password" placeholder="تاكيد كلمة السر الجديدة"
                        class="form-control" ValidationGroup="ChangePass"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirmNewPassword"
                        ErrorMessage="! من فضلك ادخل تاكيد كلمة السر الجديدة" ValidationGroup="ChangePass" CssClass="Validator" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="كلمة السر غير مطابقة"
                        ControlToCompare="txtNewPassword" ValidationGroup="Register" ControlToValidate="txtConfirmNewPassword"
                        Display="Dynamic" CssClass="ChangePass"></asp:CompareValidator>
                </div>
            </div>
            <div class="ContentItem">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="حفظ" ValidationGroup="ChangePass"
                    OnClick="btnSave_Click" />
            </div>
              </div>