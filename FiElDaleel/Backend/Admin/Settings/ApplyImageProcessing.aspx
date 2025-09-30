<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyImageProcessing.aspx.cs" Inherits="BrokerWeb.Backend.Admin.Settings.ApplyImageProcessing" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../styles/bootstrap.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    
    <div class="row">
    <asp:Button ID="btnRealestates" runat="server" Text="Apply on Property Photos" 
            onclick="btnRealestates_Click" />
    </div>
        <div class="row">
    <asp:Button ID="btnProjects" runat="server" Text="Apply on Project Photos" 
                onclick="btnProjects_Click" />
    </div>
    </form>
</body>
</html>
