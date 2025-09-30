<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="GenerateSiteMap.aspx.cs" Inherits="BrokerWeb.Backend.Admin.Settings.GenerateSiteMap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h4>
                Generate SitMap</h4>
          
        </div>
        <div class="panel-body">
          <div id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
            <div class="ContentItem row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 pull-right">
                    <asp:Label ID="Label1" runat="server" CssClass="control-label" Text="Generate SiteMap"></asp:Label>
                </div>
                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                   <asp:Button ID="btnGenerateSiteMAp" runat="server" 
                        CssClass="btn btn-lg " Text="Generate" 
                        onclick="btnGenerateSiteMAp_Click" />
                </div>
            </div>
            <div class="ContentItem row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 pull-right">
                    <asp:Label ID="Label2" runat="server" CssClass="control-label" Text="Add General Links"></asp:Label>
                </div>
                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                   <asp:Button ID="btnAddGeneralLinks" runat="server" 
                        CssClass="btn btn-lg" Text="Generate" 
                        onclick="btnAddGeneralLinks_Click" />
                </div>
            </div>
                  <div class="ContentItem row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 pull-right">
                    <asp:Label ID="Label3" runat="server" CssClass="control-label" Text="Add Catalog Links"></asp:Label>
                </div>
                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                   <asp:Button ID="Button1" runat="server" 
                        CssClass="btn btn-lg" Text="Generate" OnClick="Button1_Click"  />
                </div>
            </div>
            </div>
            </div>
</asp:Content>
