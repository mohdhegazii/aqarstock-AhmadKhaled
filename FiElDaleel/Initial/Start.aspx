<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Start.aspx.cs" Inherits="BrokerWeb.Initial.Start" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
    
    </div>
    <asp:Button ID="btnRoles" runat="server" onclick="btnRoles_Click" 
        Text="Create Roles" />
    <asp:Button ID="btnUser" runat="server" onclick="btnUser_Click" 
        Text="Create Default User" />
    <asp:Button ID="btnActiveStatus" runat="server" onclick="btnActiveStatus_Click" 
        Text="Create ActiveStatus" />
    <asp:Button ID="btnPaymentType" runat="server" onclick="btnPaymentType_Click" 
        Text="Create Payment Type" />
    <asp:Button ID="btnSaleType" runat="server" onclick="btnSaleType_Click" 
        Text="Create Sale Type" />
    <asp:Button ID="btnCategories" runat="server" onclick="btnCategories_Click" 
        Text="Create Real Estate Category" />
    <p>
    <asp:Button ID="btnMessageTypes" runat="server" onclick="btnMessageTypes_Click" 
        Text="Create Messages Types" />
    <asp:Button ID="btnSuspendReasons" runat="server" onclick="btnSuspendReasons_Click" 
        Text="Create Suspend Reasons" />
    <asp:Button ID="btnAdPackage" runat="server" onclick="btnAdPackage_Click" 
        Text="Create AdPackage" />
    </p>
    </form>
</body>
</html>
