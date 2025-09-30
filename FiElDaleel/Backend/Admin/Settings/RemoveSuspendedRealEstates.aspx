<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="RemoveSuspendedRealEstates.aspx.cs" Inherits="BrokerWeb.Backend.Admin.Settings.RemoveSuspendedRealEstates" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="panel panel-primary">
        <div class="panel-heading">
            <h4>حذف العقارات المحجوبة</h4>
            <div id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="panel-body">
        <div class="row">
            <div class="pull-right">
                
                <div class="ContentItem">
                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                        <asp:Label ID="Label2" runat="server" Text="التاريخ" CssClass="control-label"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                        <telerik:RadDatePicker ID="rdpDate" runat="server"></telerik:RadDatePicker>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Save" CssClass="Validator"
                            ControlToValidate="rdpDate" runat="server" ErrorMessage="!"></asp:RequiredFieldValidator>
                    </div>
                </div>
                   <div class="ContentItem">
            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg btn-primary pull-left" Text="حفظ" ValidationGroup="Save"
                OnClick="btnSave_Click" />
        </div>
                </div>
            </div>
            </div>
           </div>
</asp:Content>
