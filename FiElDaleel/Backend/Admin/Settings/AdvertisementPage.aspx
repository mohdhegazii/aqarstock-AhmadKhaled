<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdvertisementPage.aspx.cs" Inherits="BrokerWeb.Backend.Admin.Settings.AdvertisementPage" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    .tdimg img
    {
        max-height:100px;
        }
         .row
        {
            margin: 0;
            padding: 0;
            margin-bottom: 20px;
        }
        div.RadUpload .ruBrowse
        {
            display: inline-block;
            vertical-align: baseline;
            background-image: none !important;
            color: #ffffff;
            background-color: #47a447;
            border-color: #47a447;
            border-radius: 6px;
            height: 33px;
        }
        .RadUpload_rtl .ruRemove
        {
            display: inline-block;
            vertical-align: baseline;
            background-image: none !important;
            color: #ffffff !important;
            background-color: red !important;
            border-color: red !important;
            border-radius: 6px;
            height: 33px !important;
            font-size: 14px !important;
            margin-top: -16px !important;
        }
        .ruInputs li:first-child span.ruFileWrap
        {
            margin-top: -23px !important;
            height: 57px !important;
            opacity: 1;
            margin-right: -26px !important;
        }
        .RadUpload_Default .ruFakeInput
        {
            border: 2px solid #bdc3c7 !important;
            width: 332px !important;
            border-radius: 6px;
        }
        .ruInputs li
        {
            padding: 15px;
            background-color: #eeeeee;
            border-radius: 10px;
            width: 350px;
        }
        .RadUpload_rtl .ruUploadSuccess
        {
            margin-right: 18px;
            background-color: ghostwhite !important;
            width: 258px;
            height: 40px;
        }

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h4>ادارة الاعلانات</h4>
            <div id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="panel-body">
        <div class="row">
            <div class="pull-right">
                
                <div class="ContentItem row">
                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                        <asp:Label ID="Label2" runat="server" Text="اسم الشركة" CssClass="control-label"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Save" CssClass="Validator"
                            ControlToValidate="txtTitle" runat="server" ErrorMessage="!"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="ContentItem row">
                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                        <asp:Label ID="Label1" runat="server" Text="الرايط" CssClass="control-label"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                        <asp:TextBox ID="txtURL" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Save" CssClass="Validator"
                            ControlToValidate="txtURL" runat="server" ErrorMessage="!"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="ContentItem row">
                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                        <asp:Label ID="Label3" runat="server" Text="صورة اعلان جميع الصفحات" CssClass="control-label"></asp:Label>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12 pull-right">
                        <div id="divcontentSide" runat="server">
                            <asp:Image ID="imgContentSide" CssClass="img-thumbnail Icon" runat="server" />
                            <br />
                        </div>
                        <telerik:RadAsyncUpload ID="ruContentSide" CssClass="uploadimage form-control" runat="server"
                                    Culture="ar-EG" AllowedFileExtensions="png,jpg,jpeg,gif,JPEG" ControlObjectsVisibility="all"
                                    MultipleFileSelection="Disabled" MaxFileInputsCount="1" UploadedFilesRendering="BelowFileInput" EnableInlineProgress="false">
                                    <Localization Select="اختار" Cancel="إلغاء" Remove="حذف" />
                                </telerik:RadAsyncUpload>
                                
                    </div>
                </div>
                <div class="ContentItem row">
                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                        <asp:Label ID="Label4" runat="server" Text="صورة اعلان الصفحة الرئيسة " CssClass="control-label"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12 pull-right">
                        <div id="divHomePageSide" runat="server">
                            <asp:Image ID="imgHomePageSide" CssClass="img-thumbnail Icon" runat="server" />
                            <br />
                        </div>
                        <telerik:RadAsyncUpload ID="ruHomePageSide" CssClass="uploadimage form-control" runat="server"
                                    Culture="ar-EG" AllowedFileExtensions="png,jpg,jpeg,gif,JPEG" ControlObjectsVisibility="all"
                                    MultipleFileSelection="Disabled" MaxFileInputsCount="1" UploadedFilesRendering="BelowFileInput" EnableInlineProgress="false">
                                    <Localization Select="اختار" Cancel="إلغاء" Remove="حذف" />
                                </telerik:RadAsyncUpload>
                                
                    </div>
                </div>
                <div class="ContentItem row">
                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                        <asp:Label ID="Label5" runat="server" Text="الاعلان الرئيسى للصفحة الرئيسية" CssClass="control-label"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12 pull-right">
                        <div id="divHomePageMainLarge" runat="server">
                            <asp:Image ID="imgHomePageMainLarge" CssClass="img-thumbnail Icon" runat="server" />
                            <br />
                        </div>
                        <telerik:RadAsyncUpload ID="ruHomePageMainLarge" CssClass="uploadimage form-control" runat="server"
                                    Culture="ar-EG" AllowedFileExtensions="png,jpg,jpeg,gif,JPEG" ControlObjectsVisibility="all"
                                    MultipleFileSelection="Disabled" MaxFileInputsCount="1" UploadedFilesRendering="BelowFileInput" EnableInlineProgress="false">
                                    <Localization Select="اختار" Cancel="إلغاء" Remove="حذف" />
                                </telerik:RadAsyncUpload>
                                
                    </div>
                </div>
                <div class="ContentItem row">
                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                        <asp:Label ID="Label6" runat="server" Text="الاعلان الرئيسى للصفحة الرئيسية للموبيل" CssClass="control-label"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12 pull-right">
                        <div id="divHomePageMainSmall" runat="server">
                            <asp:Image ID="imgHomePageMainSmall" CssClass="img-thumbnail Icon" runat="server" />
                            <br />
                        </div>
                        <telerik:RadAsyncUpload ID="ruHomePageMainSmall" CssClass="uploadimage form-control" runat="server"
                                    Culture="ar-EG" AllowedFileExtensions="png,jpg,jpeg,gif,JPEG" ControlObjectsVisibility="all"
                                    MultipleFileSelection="Disabled" MaxFileInputsCount="1" UploadedFilesRendering="BelowFileInput" EnableInlineProgress="false">
                                    <Localization Select="اختار" Cancel="إلغاء" Remove="حذف" />
                                </telerik:RadAsyncUpload>
                                <telerik:RadProgressArea runat="server" ID="RadProgressArea1" />
                    </div>
                </div>
            </div>
        </div>
        <div class="ContentItem">
            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg btn-primary pull-left" Text="حفظ" ValidationGroup="Save"
                OnClick="btnSave_Click" />
        </div>
        <div class="ContentItem">
            <asp:GridView ID="gvTypes" runat="server" DataKeyNames="ID" AutoGenerateColumns="False"
                CellPadding="4" CssClass="table table-striped table-bordered table-hover theGridTable rtlDirection">
                <AlternatingRowStyle />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Id" Visible="false" />
                    
                    <asp:BoundField DataField="Name" HeaderText=" الاسم" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-CssClass="GridColumnHeader" />
                    <asp:ImageField DataImageUrlField="HomePageSide" ItemStyle-CssClass="tdimg">
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
<%--    <script type="text/javascript">

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
    </script>--%>
</asp:Content>

