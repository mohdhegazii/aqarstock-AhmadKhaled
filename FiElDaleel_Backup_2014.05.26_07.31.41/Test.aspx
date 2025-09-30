<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="BrokerWeb.Test" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">

<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
</telerik:RadScriptManager>
    <telerik:RadAutoCompleteBox  ID="RadAutoCompleteBox2" EnableClientFiltering="true" Width="250" 
                 runat="server"  DropDownPosition="Static" AllowCustomEntry="True" Filter="StartsWith"
                                        Delimiter=","  Culture="ar-EG"   DropDownWidth="250">
                    <WebServiceSettings Path="Services/AutoComplete.asmx" Method="BindDistricts" />
                </telerik:RadAutoCompleteBox>
    </form>
</body>
</html>
