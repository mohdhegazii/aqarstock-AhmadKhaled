<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Migrate.aspx.cs" Inherits="BrokerWeb.Backend.Admin.Migrate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label>
      <br />
        <asp:TextBox ID="txtNo" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtNo"
         runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
        <asp:Button ID="Button1" runat="server" Text="Migrate" 
            onclick="Button1_Click" />
    
      
    
    </div>
    </form>
</body>
</html>
