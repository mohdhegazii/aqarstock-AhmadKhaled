<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNewMessage.ascx.cs" Inherits="BrokerWeb.Backend.SubScriber.UserControls.ucNewMessage" %>
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
        <div id="divControls" class="row" runat="server">
            <div class="pull-right">
                <div class="ContentItem ">
                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                        <asp:Label ID="Label2" runat="server" Text="عنوان الرسالة*" CssClass="control-label"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="NewMessageSave" CssClass="Validator"
                            ControlToValidate="txtTitle" runat="server" Display="Dynamic" ErrorMessage="! من فضلك ادخل عنوان الرسالة"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="ContentItem ">
                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                        <asp:Label ID="Label13" runat="server" Text="نوع الرسالة *" CssClass="control-label"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                        <asp:DropDownList ID="ddlMessageType" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="NewMessageSave" CssClass="Validator"
                            ControlToValidate="ddlMessageType" runat="server" ErrorMessage="! من فضلك ادخل نوع الرسالة "
                            InitialValue="0" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="ContentItem ">
                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                        <asp:Label ID="Label4" runat="server" Text="الرسالة * " CssClass="control-label"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="NewMessageSave" CssClass="Validator"
                            ControlToValidate="txtDescription" runat="server" Display="Dynamic" ErrorMessage="! من فضلك ادخل الرسالة"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
        </div>
            <div class="ContentItem">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg" Text="ارسال" ValidationGroup="NewMessageSave"
                    OnClick="btnSave_Click" />
            </div>
    </div>