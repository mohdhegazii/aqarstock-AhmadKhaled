<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/SubScriber/SubscriberMaster.Master"
    AutoEventWireup="true" CodeBehind="RealEstateComanyData.aspx.cs" Inherits="BrokerWeb.Backend.SubScriber.RealEstateComanyData" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../scripts/Map.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            loadScriptWithoutMap();
        });
    </script>
    <style>
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
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ddlCountry">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlCities" LoadingPanelID="radLoadingPannel"
                        UpdatePanelRenderMode="Block" />
                    <telerik:AjaxUpdatedControl ControlID="ddlDistricts" LoadingPanelID="radLoadingPannel"
                        UpdatePanelRenderMode="Block" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlCities">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlDistricts" LoadingPanelID="radLoadingPannel"
                        UpdatePanelRenderMode="Block" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <div class="panel panel-primary">
        <div class="panel-heading">
            بيانات حساب الشركة
            <div id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="panel-body">
            <div id="divControls" runat="server">
                <div class="ContentItem row">
                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                        <asp:Label ID="Label6" runat="server" CssClass="control-label" Text="اسم الشركة *"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                        <asp:TextBox ID="txtTitle" runat="server" class="form-control" autofocus placeholder="اسم الشركة "></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTitle"
                            CssClass="Validator" Display="Dynamic" ErrorMessage="!  من فضلك ادخل اسم الشركة"
                            ValidationGroup="Register"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="ContentItem row">
                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                        <asp:Label ID="Label2" runat="server" CssClass="control-label" Text="رقم الهاتف *"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                        <asp:TextBox ID="txtPhone" runat="server" class="form-control" style="direction:ltr;" autofocus placeholder="رقم الهاتف"
                            ValidationGroup="Register"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPhone"
                            CssClass="Validator" Display="Dynamic" ErrorMessage="!  من فضلك ادخل رقم الهاتف"
                            ValidationGroup="Register"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPhone"
                            CssClass="Validator" Display="Dynamic" ErrorMessage="رقم الهاتف غير صحيح" ValidationExpression="(\(?\+?\ ?[0-9]+\ ?\-?\ ?\)?)*[0-9]+"
                            ValidationGroup="Register"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="ContentItem row">
                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                        <asp:Label ID="Label3" runat="server" CssClass="control-label" Text="البريد الالكترونى *"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                        <asp:TextBox ID="txtEmail" runat="server" class="form-control" autofocus placeholder="البريد الالكترونى"
                            ValidationGroup="Register"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEmail"
                            CssClass="Validator" Display="Dynamic" ErrorMessage="!  من فضلك ادخل البريد الالكترونى"
                            ValidationGroup="Register"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail"
                            CssClass="Validator" Display="Dynamic" ErrorMessage="البريد الالكترونى غير صحيح"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Register"></asp:RegularExpressionValidator>
                        <asp:Label ID="lblEmailMsg" runat="server" CssClass="Validator" Text=""></asp:Label>
                    </div>
                </div>
                <div class="ContentItem row">
                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                        <asp:Label ID="Label4" runat="server" CssClass="control-label" Text=" صورة اللوجو *"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                        <div class="row">
                            <div class="col-lg-7 col-md-7 col-sm-7 col-xs-12 pull-right">
                                <telerik:RadAsyncUpload ID="ruPhoto" CssClass="uploadimage form-control" runat="server"
                                    Culture="ar-EG" AllowedFileExtensions="png,jpg,jpeg,gif,JPEG" ControlObjectsVisibility="all"
                                    MultipleFileSelection="Disabled" MaxFileInputsCount="1" UploadedFilesRendering="BelowFileInput"
                                    OnClientFileUploaded="OnClientFileUploaded" OnClientValidationFailed="validationFailed"
                                    OnClientFileUploading="OnClientFileUploading" EnableInlineProgress="false">
                                    <Localization Select="اختار" Cancel="إلغاء" Remove="حذف" />
                                </telerik:RadAsyncUpload>
                                <%-- <telerik:RadProgressManager runat="server" ID="RadProgressManager1" />
                        <telerik:RadProgressArea runat="server" ID="RadProgressArea1" />--%>
                                <asp:CustomValidator ID="Customvalidator1" runat="server" ClientValidationFunction="validateRadUpload"
                                    ErrorMessage=" من فضلك ادخل اللوجو" ValidationGroup="Save" CssClass="Validator"
                                    Display="Dynamic">
                                </asp:CustomValidator>
                                <asp:CustomValidator ID="Customvalidator11" runat="server" ClientValidationFunction="validateRadUploadExtension"
                                    ErrorMessage="نوع الملف غير مسموح به " ValidationGroup="Save" CssClass="Validator"
                                    Display="Dynamic">
                                </asp:CustomValidator>
                            </div>
                            <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12 pull-right">
                                <div id="divlogo" style="max-height: 200px; max-width: 200px" runat="server">
                                    <asp:Image ID="imgLogo" CssClass="img-thumbnail Icon" runat="server" />
                                    <br />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="ContentItem row">
                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                        <asp:Label ID="Label1" runat="server" CssClass="control-label" Text="البلد *"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                        <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" onchange="onChange();"
                            class="form-control" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="Register"
                            CssClass="Validator" ControlToValidate="ddlCountry" runat="server" Display="Dynamic"
                            ErrorMessage=" من فضلك ادخل البلد المتواجد به الشركة" InitialValue="0"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="ContentItem row">
                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                        <asp:Label ID="Label8" runat="server" CssClass="control-label" Text="المحافظة *"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                        <asp:DropDownList ID="ddlCities" runat="server" AutoPostBack="True" class="form-control"
                            onchange="onChange();" OnSelectedIndexChanged="ddlCities_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Register"
                            CssClass="Validator" ControlToValidate="ddlCities" runat="server" ErrorMessage=" من فضلك ادخل المحافظة المتواجد بها الشركة"
                            Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="ContentItem row">
                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                        <asp:Label ID="Label9" runat="server" CssClass="control-label" Text="الحى *"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                        <asp:DropDownList ID="ddlDistricts" onchange="onChange();" class="form-control" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="Register"
                            CssClass="Validator" Display="Dynamic" ControlToValidate="ddlDistricts" runat="server"
                            ErrorMessage=" من فضلك ادخل الحى المتواجد به الشركة" InitialValue="0"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <%--<div class="ContentItem row">
                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                        <asp:Label ID="Label10" runat="server" CssClass="control-label" Text="اسم الشارع *"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                        <asp:TextBox ID="txtstreet" runat="server" class="form-control" autofocus placeholder="اسم الشارع "></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtstreet"
                            CssClass="Validator" Display="Dynamic" ErrorMessage="!  من فضلك ادخل اسم الشارع المتواجد به الشركة"
                            ValidationGroup="Register"></asp:RequiredFieldValidator>
                    </div>
                </div>--%>
                <div class="ContentItem row">
                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                        <asp:Label ID="Label5" runat="server" CssClass="control-label" Text="وصف مختصر *"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                        <asp:TextBox ID="txtSummary" runat="server" Style="min-height: 100px;" TextMode="MultiLine"
                            class="form-control" autofocus placeholder="وصف مختصر " ValidationGroup="Register"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSummary"
                            CssClass="Validator" Display="Dynamic" ErrorMessage="!  من فضلك ادخل وصف مختصر"
                            ValidationGroup="Register"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="ContentItem row">
                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                        <asp:Label ID="Label7" runat="server" CssClass="control-label" Text="وصف كامل *"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                        <asp:TextBox ID="txtDescription" runat="server" Style="min-height: 160px;" TextMode="MultiLine"
                            class="form-control" autofocus placeholder="وصف كامل " ValidationGroup="Register"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescription"
                            CssClass="Validator" Display="Dynamic" ErrorMessage="!  من فضلك ادخل وصف كامل"
                            ValidationGroup="Register"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="ContentItem row">
                    <asp:Button ID="btnSave" runat="server" class="btn btn-lg btn-primary pull-left"
                        OnClick="btnSave_Click" Text="حفظ" ValidationGroup="Register" />
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdnLat" runat="server" />
    <asp:HiddenField ID="hdnLng" runat="server" />
    <script>
        var ValidExt = true;
        var ValidFileSiZe = true;
        function validationFailed(sender, args) {
            // alert('error');
            var fileExtention = args.get_fileName().substring(args.get_fileName().lastIndexOf('.') + 1, args.get_fileName().length);
            if (args.get_fileName().lastIndexOf('.') != -1) {//this checks if the extension is correct
                if (sender.get_allowedFileExtensions().indexOf(fileExtention) == -1) {
                    ValidExt = false;
                    ValidFileSiZe = true;
                }
                else {
                    // alert('test');
                    //  ValidFileSiZe = false;
                    ValidExt = true;
                }
            }
            else {
                ValidExt = false;
                ValidFileSiZe = true;
            }
        }
        function validateRadUploadExtension(source, e) {
            e.IsValid = ValidExt;
            ValidExt = true;
        }
        function validateRadUploadFilesize(source, e) {
            e.IsValid = ValidFileSiZe;
            ValidFileSiZe = true;
        }
        function validateRadUpload(source, e) {
            if (ValidExt == false || ValidFileSiZe == false) {
                e.IsValid = true;
                return;
            }
            var mode = "<%= Mode %>";
            if (mode == "Edit") {
                e.IsValid = true;
                return;
            }
            e.IsValid = false;
            var upload = $find("<%= ruPhoto.ClientID %>");
            e.IsValid = upload.getUploadedFiles().length != 0;

        }
        function OnClientFileUploading(sender, args) {
            //  alert("test");

            $("#divImgLoading").show();
            $("#<%=btnSave.ClientID %>").prop('disabled', true);
            // alert($("#<%=lblMsg.ClientID %>").val()); //.hide()//.text("جارى تحميل الصورة....");
        }
        function OnClientFileUploaded(sender, args) {

            $("#divImgLoading").hide();
            $("#<%=btnSave.ClientID %>").prop('disabled', false);
        }
        function onChange() {
            var Address = "";
            var index = $("#<%= ddlCountry.ClientID %>").prop('selectedIndex');
            if (index > 0) {
                Address = $("#<%= ddlCountry.ClientID %> option:selected").text();
                index = $("#<%= ddlCities.ClientID %>").prop('selectedIndex');
                if (index > 0) {
                    Address += " , " + $("#<%= ddlCities.ClientID %> option:selected").text();

                    index = $("#<%= ddlDistricts.ClientID %>").prop('selectedIndex');
                    if (index > 0) {
                        Address += " , " + $("#<%= ddlDistricts.ClientID %> option:selected").text();
                    }
                }
                GetAddress(Address);
            }
        }
        function SetLatLongControls(lat, lng) {
            $("#<%= hdnLat.ClientID %>").val(lat);
            $("#<%= hdnLng.ClientID %>").val(lng);
            //  alert(lat+", "+lng);
        }
    </script>
</asp:Content>
