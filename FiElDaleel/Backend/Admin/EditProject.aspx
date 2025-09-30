<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="EditProject.aspx.cs" Inherits="BrokerWeb.Backend.Admin.EditProject" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/Backend/SubScriber/UserControls/ucProjectPhoto.ascx" TagName="ucProjectPhoto" TagPrefix="uc1" %>
<%@ Register Src="~/Backend/SubScriber/UserControls/ucProjectVedio.ascx" TagName="ucProjectVedio" TagPrefix="uc2" %>
<%@ Register Src="~/Backend/SubScriber/UserControls/ucProjectModel.ascx" TagName="ucProjectModel" TagPrefix="uc3" %>
<%@ Register Src="~/Backend/SubScriber/UserControls/ucProjectRealestate.ascx" TagName="ucProjectRealestate" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../scripts/Map.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            loadScriptWithoutMap();
        });
    </script>
    <style>
        .row {
            margin: 0;
            padding: 0;
            margin-bottom: 20px;
        }


        div.RadUpload .ruBrowse {
            display: inline-block;
            vertical-align: baseline;
            background-image: none !important;
            color: #ffffff;
            background-color: #47a447;
            border-color: #47a447;
            border-radius: 6px;
            height: 33px;
        }

        .rcCalPopup {
            /*background-image:url('../images/icons/backend/calendar.png') !important;  */
            height: 32px !important;
            width: 32px !important;
            background-size: 25px;
        }

        .RadUpload_rtl .ruRemove {
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

        .ruInputs li:first-child span.ruFileWrap {
            margin-top: -23px !important;
            height: 57px !important;
            opacity: 1;
            margin-right: -44px !important;
        }

        .RadUpload_Default .ruFakeInput, .riTextBox {
            border: 2px solid #bdc3c7 !important;
            width: 332px !important;
            border-radius: 6px;
        }

        .riTextBox {
            height: 34px;
        }

        .ruInputs li {
            padding: 15px;
            background-color: #eeeeee;
            border-radius: 10px;
            width: 350px;
        }

        .RadUpload_rtl .ruUploadSuccess {
            margin-right: 18px;
            background-color: ghostwhite !important;
            width: 258px;
            height: 40px;
        }

        .RadAsyncUpload {
            height: 36px !important;
        }
        /*------------ Begin:Photo UserControl Style----------------------------- */
        .window .RadUpload_Default .ruFakeInput, .window .riTextBox {
            width: 258px !important;
        }

        .window .ruInputs li:first-child span.ruFileWrap {
            margin-right: -30px !important;
        }
        /*------------ End:PhotoUserControl Style-------------------------------- */
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ddlCountries">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlCity" LoadingPanelID="radLoadingPannel"
                        UpdatePanelRenderMode="Block" />
                    <telerik:AjaxUpdatedControl ControlID="ddlDistrict" LoadingPanelID="radLoadingPannel"
                        UpdatePanelRenderMode="Block" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlCity">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlDistrict" LoadingPanelID="radLoadingPannel"
                        UpdatePanelRenderMode="Block" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadTabStrip ID="rtsProject" MultiPageID="rmpProject" AutoPostBack="True"
        Align="Justify" runat="server" SelectedIndex="0" CssClass="WizardTabs" Skin="Simple"
        OnTabClick="rtsProject_TabClick">
        <Tabs>
            <telerik:RadTab PageViewID="rpvMainData" Selected="true">
                <TabTemplate>
                    <div class="WizardTab">
                        <img src="../images/icons/backend/basic.png" />
                        <asp:Label ID="Label1" runat="server" Text="بيانات المشروع "></asp:Label>
                    </div>
                </TabTemplate>
            </telerik:RadTab>
            <telerik:RadTab PageViewID="rpvPhotos">
                <TabTemplate>
                    <div class="WizardTab">
                        <img src="../images/icons/backend/images.png" />
                        <asp:Label ID="Label1" runat="server" Text="صور المشروع"></asp:Label>
                    </div>
                </TabTemplate>
            </telerik:RadTab>
            <telerik:RadTab PageViewID="rpvVedio">
                <TabTemplate>
                    <div class="WizardTab">
                        <img src="../images/icons/backend/Vedio.png" />
                        <asp:Label ID="Label1" runat="server" Text="فيديوهات المشروع"></asp:Label>
                    </div>
                </TabTemplate>
            </telerik:RadTab>
            <telerik:RadTab PageViewID="rpvModels" Selected="True">
                <TabTemplate>
                    <div class="WizardTab">
                        <img src="../images/icons/backend/extra.png" />
                        <asp:Label ID="Label1" runat="server" Text="نماذج المشروع"></asp:Label>
                    </div>
                </TabTemplate>
            </telerik:RadTab>
            <telerik:RadTab PageViewID="rpvRealestates" Selected="True">
                <TabTemplate>
                    <div class="WizardTab">
                        <img src="../images/icons/backend/ProjectRealestates.png" />
                        <asp:Label ID="Label1" runat="server" Text="عقارات المشروع"></asp:Label>
                    </div>
                </TabTemplate>
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <div class="WizardContent">
        <telerik:RadMultiPage ID="rmpProject" runat="server" RenderSelectedPageOnly="true"
            SelectedIndex="0">
            <telerik:RadPageView CssClass="WizardPageView" ID="rpvMainData" runat="server">
                <div class="Header" style="border-bottom: 0; margin-bottom: 0; padding-bottom: 0;">
                    <%--       <h1>
                          تفاصيل الاعلان
                   
                        </h1>--%>
                    <div id="divMsg" runat="server">
                        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="Content row nopadding">
                    <div class=" pull-right">
                        <div class="ContentItem row">
                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                <asp:Label ID="Label9" runat="server" Text="اسم المشروع  *" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="Save" CssClass="Validator"
                                    ControlToValidate="txtTitle" runat="server" Display="Dynamic" ErrorMessage="! من فضلك ادخل اسم المشروع"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="ContentItem row">
                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                <asp:Label ID="Label2" runat="server" Text="شعار المشروع  *" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                <asp:TextBox ID="txtSlogan" runat="server" MaxLength="50" CssClass="form-control" placeholder=""></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Save" CssClass="Validator"
                                    ControlToValidate="txtSlogan" runat="server" Display="Dynamic" ErrorMessage="! من فضلك ادخل شعار المشروع"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="ContentItem row">
                            <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                                <asp:Label ID="Label013" runat="server" Text="البلد *" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                                <asp:DropDownList ID="ddlCountries" runat="server" CssClass="form-control" AutoPostBack="True"
                                    onchange="onChange();" OnSelectedIndexChanged="ddlCountries_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="Save" CssClass="Validator"
                                    ControlToValidate="ddlCountries" runat="server" ErrorMessage=" من فضلك ادخل البلد المتواجد به المشروع!"
                                    InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="ContentItem row">
                            <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                                <asp:Label ID="Label4" runat="server" Text="المحافظة *" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                                <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" AutoPostBack="True"
                                    onchange="onChange();" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Save" CssClass="Validator"
                                    ControlToValidate="ddlCity" runat="server" ErrorMessage="! من فضلك ادخل المحافظة المتواجد بها المشروع"
                                    InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="ContentItem row">
                            <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                                <asp:Label ID="Label13" runat="server" Text="الحى *" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                                <asp:DropDownList ID="ddlDistrict" runat="server" onchange="onChange();" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Save" CssClass="Validator"
                                    ControlToValidate="ddlDistrict" runat="server" ErrorMessage="! من فضلك ادخل الحى المتواجد به المشروع"
                                    InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="ContentItem row">
                            <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                                <asp:Label ID="Label3" runat="server" CssClass="control-label" Text=" صورة اللوجو *"></asp:Label>
                            </div>
                            <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                                <div>
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
                                    <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12 pull-left">
                                        <div id="divlogo" style="max-height: 200px; max-width: 200px; margin-top: -21px; float: left"
                                            runat="server">
                                            <asp:Image ID="imgLogo" CssClass="img-thumbnail Icon" runat="server" />
                                            <br />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="ContentItem row">
                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                <asp:Label ID="Label5" runat="server" Text="الوصف * " CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" Style="min-height: 160px;"
                                    TextMode="MultiLine" MaxLength="500" placeholder=" أكتب وصف كامل للمشروع ومميزات موقعه والخدمات المتاحة."></asp:TextBox>
                                <asp:Label ID="Label12" runat="server" Style="width: 100%; background-color: transparent;"
                                    Text="عدد الاحرف يجب ان لا يزيد عن 500 حرف" CssClass="Note"></asp:Label>
                                <br />
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="Save" CssClass="Validator"
                                    ControlToValidate="txtDescription" runat="server" Display="Dynamic" ErrorMessage="! من فضلك ادخل وصف المشروع"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="ContentItem ">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg pull-right" Style="margin-left: 10px;"
                            Text="حفظ" ValidationGroup="Save" OnClick="btnSave_Click" />
                    </div>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView CssClass="WizardPageView" ID="rpvPhotos" runat="server">
                <uc1:ucProjectPhoto ID="ucProjectPhoto1" runat="server" />
            </telerik:RadPageView>
            <telerik:RadPageView CssClass="WizardPageView" ID="rpvVedio" runat="server">
                <uc2:ucProjectVedio ID="ucProjectVedio1" runat="server" />
            </telerik:RadPageView>
            <telerik:RadPageView CssClass="WizardPageView" ID="rpvModels" runat="server">
                <uc3:ucProjectModel ID="ucProjectModel1" runat="server" />
            </telerik:RadPageView>
            <telerik:RadPageView CssClass="WizardPageView" ID="rpvRealestates" runat="server">
                <uc4:ucProjectRealestate ID="ucProjectRealestate1" runat="server" />
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </div>
    <asp:HiddenField ID="hdnLat" runat="server" />
    <asp:HiddenField ID="hdnLng" runat="server" />
    <telerik:RadCodeBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
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
                var index = $("#<%= ddlCountries.ClientID %>").prop('selectedIndex');
                if (index > 0) {
                    Address = $("#<%= ddlCountries.ClientID %> option:selected").text();
                    index = $("#<%= ddlCity.ClientID %>").prop('selectedIndex');
                    if (index > 0) {
                        Address += " , " + $("#<%= ddlCity.ClientID %> option:selected").text();

                        index = $("#<%= ddlDistrict.ClientID %>").prop('selectedIndex');
                        if (index > 0) {
                            Address += " , " + $("#<%= ddlDistrict.ClientID %> option:selected").text();
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
    </telerik:RadCodeBlock>
</asp:Content>
