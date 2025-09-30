<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActivateSubscription.aspx.cs"
    Inherits="BrokerWeb.Backend.SubScriber.ActivateSubscription" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="../../scripts/bootstrap.min.js" type="text/javascript"></script>
    <link href="../../styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../styles/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../../styles/cover.css" rel="stylesheet" type="text/css" />
</head>
<body dir="rtl">
    <form id="form1" runat="server">
    <div class="site-wrapper">
        <div class="site-wrapper-inner">
            <div class="cover-container">
                <div class="inner cover">
                    <h1 class="cover-heading">
                        لتفعيل اشتراكك</h1>
                    <p class="lead">
                        الرجاء ادخال الكود الذى تم ارساله على الايميل الخاص بك
                    </p>
                    <p class="lead">
                        <div id="divMsg" runat="server">
                            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                        </div>
                         
                        <asp:TextBox ID="txtActivationCode" CssClass="form-control" runat="server"></asp:TextBox>
                          
                        <br />
                        <%-- <br />--%>
                        <asp:Button ID="btnActivate" class="btn btn-md btn-warning activate" runat="server"
                            Text="تفعيل الاشتراك" OnClick="btnActivate_Click" ValidationGroup="Activate" />
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="Activate"
                            CssClass="Validator alert alert-danger" ControlToValidate="txtActivationCode" runat="server" ErrorMessage="!من فضلك ادخل كود تفعيل الاشتراك" Display="Dynamic"></asp:RequiredFieldValidator>
                      
                    </p>
                    <p class="lead">
                        اذا لم يصلك الايميل او ترغب فى اعادة ارساله اضغط
                        <asp:LinkButton ID="lbtnResendCode" class="btn btn-sm btn-warning" runat="server"
                            OnClick="lbtnResendCode_Click"><b>هنا</b></asp:LinkButton>
                    </p>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
