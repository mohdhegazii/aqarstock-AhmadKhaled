<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/SubScriber/SubscriberMaster.Master"
    AutoEventWireup="true" CodeBehind="SubscriberProfile.aspx.cs" Inherits="BrokerWeb.Backend.SubScriber.SubscriberProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Header">
        <h1>
            بيانات حسابك
        </h1>
        <div id="divMsg" runat="server">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div class="Content row">
        <div id="divControls" class="row" runat="server">
            <div class="ContentItem row">
                <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                    <asp:Label ID="Label6" runat="server" Text="اسم المستخدم" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                    <asp:TextBox ID="txtUserName" runat="server" class="form-control" placeholder="اسم المستخدم "
                        autofocus ReadOnly></asp:TextBox>
                </div>
            </div>
            <div class="ContentItem row">
                <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                    <asp:Label ID="Label1" runat="server" Text="الاسم *" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                    <asp:TextBox ID="txtFullName" runat="server" ValidationGroup="Register" class="form-control"
                        placeholder="الاسم " autofocus></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="Register"
                        CssClass="Validator" ControlToValidate="txtFullName" runat="server" ErrorMessage="!  من فضلك ادخل الاسم"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="ContentItem row">
                <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                    <asp:Label ID="Label2" runat="server" Text="رقم الموبيل *" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                    <asp:TextBox ID="txtMobileNo" runat="server" ValidationGroup="Register" class="form-control"
                        placeholder="رقم الموبيل" autofocus></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="Register"
                        CssClass="Validator" ControlToValidate="txtMobileNo" runat="server" ErrorMessage="!  من فضلك ادخل رقم الموبيل"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="رقم الموبيل غير صحيح"
                        ControlToValidate="txtMobileNo" ValidationGroup="Register" ValidationExpression="([0-9]+\-?)*[0-9]+"
                        CssClass="Validator" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="ContentItem row">
                <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                    <asp:Label ID="Label3" runat="server" Text="البريد الالكترونى *" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                    <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="Register" class="form-control"
                        placeholder="البريد الالكترونى" autofocus></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="Register"
                        CssClass="Validator" ControlToValidate="txtEmail" Display="Dynamic" runat="server"
                        ErrorMessage="!  من فضلك ادخل البريد الالكترونى"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="البريد الالكترونى غير صحيح"
                        ControlToValidate="txtEmail" ValidationGroup="Register" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        CssClass="Validator" Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:Label ID="lblEmailMsg" runat="server" CssClass="Validator" Text=""></asp:Label>
                </div>
            </div>
            <div class="ContentItem row">
                <asp:CheckBox ID="chkChangePassword" Text="تغير كلمة السر" CssClass="Check" onclick="ChangePasswordVisible(this);"
                    runat="server" />
            </div>
            <div class="ContentItem row" id="divPassword" runat="server">
                <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                    <asp:Label ID="Label4" runat="server" Text="كلمة السر *" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                    <asp:TextBox ID="txtRegPassword" runat="server" TextMode="Password" placeholder="كلمة السر"
                        class="form-control" ValidationGroup="Register"></asp:TextBox>
                    <asp:CustomValidator ID="Customvalidator1" runat="server" ClientValidationFunction="validatePassword"
                        ErrorMessage="! من فضلك ادخل كلمة السر" ValidationGroup="Register" CssClass="Validator" Display="Dynamic">
                    </asp:CustomValidator>
                </div>
            </div>
            <div class="ContentItem row" id="divNewPassword" runat="server">
                <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                    <asp:Label ID="Label5" runat="server" Text=" كلمة السر الجديدة *" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                    <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" placeholder=" كلمة السر الجديدة"
                        class="form-control" ValidationGroup="Register"></asp:TextBox>
                    <asp:CustomValidator ID="Customvalidator2" runat="server" ClientValidationFunction="validateNewPassword"
                        ErrorMessage="! من فضلك ادخل كلمة السرالجديدة" ValidationGroup="Register" CssClass="Validator" Display="Dynamic">
                    </asp:CustomValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="من فضلك ادخل على الأقل 6 و 32 حرفا كحد أقصى"
                        ControlToValidate="txtNewPassword" ValidationGroup="Register" ValidationExpression="^.{6,32}$"
                        CssClass="Validator" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="ContentItem row" id="divConfirmNewPassword" runat="server">
                <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                    <asp:Label ID="Label7" runat="server" Text="تاكيد كلمة السر الجديدة *" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                    <asp:TextBox ID="txtConfirmNewPassword" runat="server" TextMode="Password" placeholder="تاكيد كلمة السر الجديدة"
                        class="form-control" ValidationGroup="Register"></asp:TextBox>
                    <asp:CustomValidator ID="Customvalidator3" runat="server" ClientValidationFunction="validateConfirmNewPassword"
                        ErrorMessage="! من فضلك ادخل تاكيد كلمة السر الجديدة" ValidationGroup="Register" CssClass="Validator" Display="Dynamic">
                    </asp:CustomValidator>
                    <br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="كلمة السر غير مطابقة"
                        ControlToCompare="txtNewPassword" ValidationGroup="Register" ControlToValidate="txtConfirmNewPassword"
                        Display="Dynamic" CssClass="Validator"></asp:CompareValidator>
                </div>
            </div>
            <div class="ContentItem row">
                <asp:Button ID="btnSave" class="btn btn-lg" runat="server" Text="حفظ" ValidationGroup="Register"
                    OnClick="btnSave_Click" />
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
