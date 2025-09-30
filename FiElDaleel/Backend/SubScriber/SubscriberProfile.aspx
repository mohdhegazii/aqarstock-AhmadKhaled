<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/SubScriber/SubscriberMaster.Master"
    AutoEventWireup="true" CodeBehind="SubscriberProfile.aspx.cs" Inherits="BrokerWeb.Backend.SubScriber.SubscriberProfile" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <style>
        .row
        {
            margin: 0;
            padding: 0;
            margin-bottom: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="panel panel-primary">
        <div class="panel-heading">
            بيانات حسابك
            <div id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="panel-body">
            <div id="divControls" runat="server">
                <div class="ContentItem row">
                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                        <asp:Label ID="Label6" runat="server" CssClass="control-label" Text="اسم المستخدم"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                        <asp:TextBox ID="txtUserName" runat="server" class="form-control" autofocus placeholder="اسم المستخدم "
                            ReadOnly></asp:TextBox>
                    </div>
                </div>
                <div class="ContentItem row">
                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                        <asp:Label ID="Label1" runat="server" CssClass="control-label" Text="الاسم *"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                        <asp:TextBox ID="txtFullName" runat="server" class="form-control" autofocus placeholder="الاسم "
                            ValidationGroup="Register"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFullName"
                            CssClass="Validator" Display="Dynamic" ErrorMessage="!  من فضلك ادخل الاسم" ValidationGroup="Register"></asp:RequiredFieldValidator>
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
                            ValidationGroup="Register"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEmail"
                            CssClass="Validator" Display="Dynamic" ErrorMessage="!  من فضلك ادخل البريد الالكترونى"
                            ValidationGroup="Register"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail"
                            CssClass="Validator" Display="Dynamic" ErrorMessage="البريد الالكترونى غير صحيح"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Register"></asp:RegularExpressionValidator>
                        <asp:Label ID="lblEmailMsg" runat="server" CssClass="Validator" Text=""></asp:Label>
                    </div>
                </div>
                <div class="ContentItem row">
                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                        <asp:Label ID="Label8" runat="server" CssClass="control-label" Text="نوع الاشتراك *"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                        <asp:RadioButtonList ID="rbtnl" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="شخصي" Value="0"></asp:ListItem>
                        <asp:ListItem Text="شركات" Value="1"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="ContentItem row">
                    <asp:CheckBox ID="chkChangePassword" runat="server" CssClass="Check" onclick="ChangePasswordVisible(this);"
                        Text="تغير كلمة السر" />
                </div>
                <div id="divPassword" runat="server" class="ContentItem row">
                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                        <asp:Label ID="Label4" runat="server" CssClass="control-label" Text="كلمة السر *"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                        <asp:TextBox ID="txtRegPassword" runat="server" class="form-control" placeholder="كلمة السر"
                            TextMode="Password" ValidationGroup="Register"></asp:TextBox>
                        <asp:CustomValidator ID="Customvalidator1" runat="server" ClientValidationFunction="validatePassword"
                            CssClass="Validator" Display="Dynamic" ErrorMessage="! من فضلك ادخل كلمة السر"
                            ValidationGroup="Register">
                        </asp:CustomValidator>
                    </div>
                </div>
                <div id="divNewPassword" runat="server" class="ContentItem row">
                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                        <asp:Label ID="Label5" runat="server" CssClass="control-label" Text=" كلمة السر الجديدة *"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                        <asp:TextBox ID="txtNewPassword" runat="server" class="form-control" placeholder=" كلمة السر الجديدة"
                            TextMode="Password" ValidationGroup="Register"></asp:TextBox>
                        <asp:CustomValidator ID="Customvalidator2" runat="server" ClientValidationFunction="validateNewPassword"
                            CssClass="Validator" Display="Dynamic" ErrorMessage="! من فضلك ادخل كلمة السرالجديدة"
                            ValidationGroup="Register">
                        </asp:CustomValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtNewPassword"
                            CssClass="Validator" Display="Dynamic" ErrorMessage="من فضلك ادخل على الأقل 6 و 32 حرفا كحد أقصى"
                            ValidationExpression="^.{6,32}$" ValidationGroup="Register"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div id="divConfirmNewPassword" runat="server" class="ContentItem row">
                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                        <asp:Label ID="Label7" runat="server" CssClass="control-label" Text="تاكيد كلمة السر الجديدة *"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                        <asp:TextBox ID="txtConfirmNewPassword" runat="server" class="form-control" placeholder="تاكيد كلمة السر الجديدة"
                            TextMode="Password" ValidationGroup="Register"></asp:TextBox>
                        <asp:CustomValidator ID="Customvalidator3" runat="server" ClientValidationFunction="validateConfirmNewPassword"
                            CssClass="Validator" Display="Dynamic" ErrorMessage="! من فضلك ادخل تاكيد كلمة السر الجديدة"
                            ValidationGroup="Register">
                        </asp:CustomValidator>
                        <br />
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPassword"
                            ControlToValidate="txtConfirmNewPassword" CssClass="Validator" Display="Dynamic"
                            ErrorMessage="كلمة السر غير مطابقة" ValidationGroup="Register"></asp:CompareValidator>
                    </div>
                </div>
                <div class="ContentItem row">
                    <asp:Button ID="btnSave" runat="server" class="btn btn-lg btn-primary pull-left"
                        OnClick="btnSave_Click" Text="حفظ" ValidationGroup="Register" />
                </div>
            </div>
        </div>
    </div>
    <telerik:RadCodeBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            var ChangePassChecked = false;
            function ChangePasswordVisible(control) {
                if (control.checked) {
                    ChangePassChecked = true;
                    $("#<%=divPassword.ClientID%>").css("display", "block");
                    $("#<%=divNewPassword.ClientID%>").css("display", "block");
                    $("#<%=divConfirmNewPassword.ClientID%>").css("display", "block");
                }
                else {
                    ChangePassChecked = false;
                    $("#<%=divPassword.ClientID%>").css("display", "none");
                    $("#<%=divNewPassword.ClientID%>").css("display", "none");
                    $("#<%=divConfirmNewPassword.ClientID%>").css("display", "none");
                }
            }
            function validatePassword(source, e) {
                e.IsValid = false;

                if (ChangePassChecked == false) {
                    e.IsValid = true;
                    return;
                }
                var value = $("#<%=txtRegPassword.ClientID%>").val();
                if (value != "" && value != null) {
                    e.IsValid = true;
                    return;
                }
            }
            function validateNewPassword(source, e) {
                e.IsValid = false;

                if (ChangePassChecked == false) {
                    e.IsValid = true;
                    return;
                }
                var value = $("#<%=txtNewPassword.ClientID%>").val();
                if (value != "" && value != null) {
                    e.IsValid = true;
                    return;
                }
            }
            function validateConfirmNewPassword(source, e) {
                e.IsValid = false;

                if (ChangePassChecked == false) {
                    e.IsValid = true;
                    return;
                }
                var value = $("#<%=txtConfirmNewPassword.ClientID%>").val();
                if (value != "" && value != null) {
                    e.IsValid = true;
                    return;
                }
            }
        </script>
    </telerik:RadCodeBlock>
</asp:Content>
