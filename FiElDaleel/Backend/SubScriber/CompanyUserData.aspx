<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/SubScriber/SubscriberMaster.Master" AutoEventWireup="true" CodeBehind="CompanyUserData.aspx.cs" Inherits="BrokerWeb.Backend.SubScriber.CompanyUserData" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <style>
        .row
        {
            margin: 0;
            padding: 0;
            margin-bottom: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="txtUserName">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblUserNameMsg" UpdatePanelRenderMode="Inline"  />
                    <telerik:AjaxUpdatedControl ControlID="txtUserName" LoadingPanelID="radLoadingPannel"
                        UpdatePanelRenderMode="Inline" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="txtEmail">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblEmailMsg" UpdatePanelRenderMode="Inline" />
                     <telerik:AjaxUpdatedControl ControlID="txtEmail" LoadingPanelID="radLoadingPannel"
                        UpdatePanelRenderMode="Inline" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
        </telerik:RadAjaxManagerProxy>
 <div class="panel panel-primary">
        <div class="panel-heading">
            بيانات حساب الموظف
            <div id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="panel-body"  >
            <div id="divControls" runat="server">
               
                <div class="ContentItem row">
                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                        <asp:Label ID="Label1" runat="server" CssClass="control-label" Text="الاسم بالكامل *"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                        <asp:TextBox ID="txtFullName" runat="server" class="form-control" autofocus placeholder="الاسم بالكامل"
                            ValidationGroup="Register"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFullName"
                             CssClass="Validator" Display="Dynamic" ErrorMessage="!  من فضلك ادخل الاسم بالكامل" ValidationGroup="Register"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="ContentItem row">
                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                        <asp:Label ID="Label2" runat="server" CssClass="control-label" Text="رقم الموبيل *"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                        <asp:TextBox ID="txtMobileNo" runat="server" class="form-control" autofocus placeholder="رقم الموبيل"
                            ValidationGroup="Register"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMobileNo"
                            CssClass="Validator" Display="Dynamic" ErrorMessage="!  من فضلك ادخل رقم الموبيل"
                            ValidationGroup="Register"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMobileNo"
                            CssClass="Validator" Display="Dynamic" ErrorMessage="رقم الموبيل غير صحيح" ValidationExpression="([0-9]+\-?)*[0-9]+"
                            ValidationGroup="Register"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="ContentItem row">
                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                        <asp:Label ID="Label3" runat="server" CssClass="control-label" Text="البريد الالكترونى *"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                        <asp:TextBox ID="txtEmail" runat="server" class="form-control" autofocus placeholder="البريد الالكترونى"
                            ValidationGroup="Register" AutoPostBack="true" OnTextChanged="txtEmail_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEmail"
                            CssClass="Validator" Display="Dynamic" ErrorMessage="!  من فضلك ادخل البريد الالكترونى"
                            ValidationGroup="Register"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail"
                            CssClass="Validator" Display="Dynamic" ErrorMessage="البريد الالكترونى غير صحيح"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Register"></asp:RegularExpressionValidator>
                        <asp:Label ID="lblEmailMsg" runat="server"  Text=""></asp:Label>
                    </div>
                </div>
            
                 <div class="ContentItem row">
                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                        <asp:Label ID="Label6" runat="server" CssClass="control-label" Text="اسم المستخدم"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                        <asp:TextBox ID="txtUserName" runat="server" AutoPostBack="true" OnTextChanged="txtRegUserNamr_TextChanged" class="form-control" autofocus placeholder="اسم المستخدم "></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
                             CssClass="Validator" Display="Dynamic" ErrorMessage="!  من فضلك ادخل اسم المستخدم" ValidationGroup="Register"></asp:RequiredFieldValidator>
                              <asp:Label ID="lblUserNameMsg" runat="server" CssClass="Validator" Text=""></asp:Label>
                   
                    </div>
                </div>
          
                <div id="divNewPassword" runat="server" class="ContentItem row">
                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                        <asp:Label ID="Label5" runat="server" CssClass="control-label" Text=" كلمة السر  *"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                        <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder=" كلمة السر "
                            TextMode="Password" ValidationGroup="Register"></asp:TextBox>
                  
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtPassword"
                            CssClass="Validator" Display="Dynamic" ErrorMessage="من فضلك ادخل على الأقل 6 و 32 حرفا كحد أقصى"
                            ValidationExpression="^.{6,32}$" ValidationGroup="Register"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div id="divConfirmNewPassword" runat="server" class="ContentItem row">
                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                        <asp:Label ID="Label7" runat="server" CssClass="control-label" Text="تاكيد كلمة السر  *"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                        <asp:TextBox ID="txtConfirmNewPassword" runat="server" class="form-control" placeholder="تاكيد كلمة السر "
                            TextMode="Password" ValidationGroup="Register"></asp:TextBox>
                     
                        <br />
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword"
                            ControlToValidate="txtConfirmNewPassword" CssClass="Validator" Display="Dynamic"
                            ErrorMessage="كلمة السر غير مطابقة" ValidationGroup="Register"></asp:CompareValidator>
                    </div>
                </div>
                   <div class="ContentItem row">
                    <asp:CheckBox ID="chkIsAdmin" runat="server" CssClass="Check" 
                        Text="يمكنه إدارة حساب الشركة على الموقع" />
                </div>
                <div class="ContentItem row">
                    <asp:Button ID="btnSave" runat="server" class="btn btn-lg pull-left"
                        OnClick="btnSave_Click" Text="حفظ" ValidationGroup="Register" />
                </div>
            </div>
        </div>
    </div>
  
</asp:Content>
