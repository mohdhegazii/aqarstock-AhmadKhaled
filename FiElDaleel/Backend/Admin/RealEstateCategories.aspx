<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="RealEstateCategories.aspx.cs" Inherits="BrokerWeb.Backend.Admin.RealEstateCategories" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        
        .row{
            margin: 0 0 20px 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h4>فئات العقارات</h4>
            <div id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="panel-body">
            <div class="col-lg-4 pull-right">
                <div class="ContentItem row">
                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                        <asp:Label ID="Label2" runat="server" Text="الاسم" CssClass="control-label"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Save" CssClass="Validator"
                            ControlToValidate="txtTitle" runat="server" ErrorMessage="!"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="ContentItem row">
                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                        <asp:Label ID="Label3" runat="server" Text="الرمز" CssClass="control-label"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12 pull-right">
                        <div id="divlogo" runat="server">
                            <asp:Image ID="imgIcon" CssClass="img-thumbnail Icon" runat="server" />
                            <br />
                        </div>
                        <telerik:RadUpload ID="ruIcon" CssClass="uploadimage form-control" runat="server"
                            Culture="ar-EG" AllowedFileExtensions="png,jpg,jpeg,gif,JPEG" MaxFileInputsCount="1"
                            ControlObjectsVisibility="None" MaxFileSize="1048576">
                            <Localization Select="اختار" />
                        </telerik:RadUpload>
                        <asp:CustomValidator ID="Customvalidator1" runat="server" ClientValidationFunction="validateRadUpload"
                            ErrorMessage="!" ValidationGroup="Save" CssClass="Validator" Display="Dynamic">
                        </asp:CustomValidator>
                        <br />
                        <asp:Label ID="Label10" runat="server" Text="حجم الرمز يجب ان لا يزيد عن 1 ميجا"
                            CssClass="Note"></asp:Label>
                    </div>
                </div>
            </div>
        
        <div class="ContentItem">
            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg btn-primary pull-left" Text="حفظ" ValidationGroup="Save"
                OnClick="btnSave_Click" />
        </div>
        <div class="ContentItem">
            <asp:GridView ID="gvCategories" runat="server" DataKeyNames="ID" AutoGenerateColumns="False"
                CellPadding="4" CssClass="table table-striped table-bordered table-hover theGridTable rtlDirection"
                AllowPaging="True" PageSize="20">
                <AlternatingRowStyle/>
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Id" Visible="false" />
                    <asp:BoundField DataField="Title" HeaderText=" الاسم" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-CssClass="GridColumnHeader" />
                    <asp:ImageField DataImageUrlField="Icon">
                    </asp:ImageField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/icons/Edit.png" OnClientClick="OpenWindow()"
                                OnClick="ibtnEdit_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ibtnDelete" CssClass="Deleteconfirm" runat="server" ImageUrl="~/Images/icons/Delete.png"
                                OnClick="ibtnDelete_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <pagerstyle horizontalalign="Center" CssClass="pagerRow" />
            </asp:GridView>
        </div>
            </div>
    </div>
    <script type="text/javascript">

        function validateRadUpload(source, e) {
            e.IsValid = false;
            var mode = "<%= Mode %>";
            if (mode == "Edit") {
                e.IsValid = true;
                return;
            }
            var upload = $find("<%= ruIcon.ClientID %>");
            var inputs = upload.getFileInputs();
            for (var i = 0; i < inputs.length; i++) {
                //check for empty string or invalid extension
                if (inputs[i].value != "" && upload.isExtensionValid(inputs[i].value)) {
                    e.IsValid = true;
                    break;
                }
            }
        }
    </script>
</asp:Content>
