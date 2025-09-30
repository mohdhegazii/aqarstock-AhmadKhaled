<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="BrokerWeb.Backend.Admin.Catalog" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            margin-right: -29px !important;
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
            <telerik:AjaxSetting AjaxControlID="btnAddTag">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvTags" UpdatePanelRenderMode="Block" />
                    <telerik:AjaxUpdatedControl ControlID="ddlTags" UpdatePanelRenderMode="Block" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAddByCode">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvRealestates" UpdatePanelRenderMode="Block" />
                    <telerik:AjaxUpdatedControl ControlID="txtCode" UpdatePanelRenderMode="Block" LoadingPanelID="radLoadingPannel" />
                    <telerik:AjaxUpdatedControl ControlID="divAddMsg" UpdatePanelRenderMode="Block" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAddByCompany">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvRealestates" UpdatePanelRenderMode="Block" LoadingPanelID="radLoadingPannel" />
                    <telerik:AjaxUpdatedControl ControlID="divAddMsg" UpdatePanelRenderMode="Block" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlCompany">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlCompanyRealestate" LoadingPanelID="radLoadingPannel"
                        UpdatePanelRenderMode="Block" />
                </UpdatedControls>
            </telerik:AjaxSetting>

            <telerik:AjaxSetting AjaxControlID="ddlProjects">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlProjectRealestate" LoadingPanelID="radLoadingPannel"
                        UpdatePanelRenderMode="Block" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAddByProject">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="divAddMsg" />
                    <telerik:AjaxUpdatedControl ControlID="gvRealestates" UpdatePanelRenderMode="Block" />

                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlUsers">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlUserRealestate" LoadingPanelID="radLoadingPannel"
                        UpdatePanelRenderMode="Block" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAddByUser">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvRealestates" UpdatePanelRenderMode="Block" />
                    <telerik:AjaxUpdatedControl ControlID="divAddMsg" UpdatePanelRenderMode="Block" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="gvRealestates">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvRealestates" LoadingPanelID="radLoadingPannel"
                        UpdatePanelRenderMode="Block" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h4>كتالوج العقارات</h4>
        </div>
        <div class="panel-body">
            <div id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
            <div class="row ContentItem">
                <asp:HyperLink ID="lNewCatalog" NavigateUrl="/NewCatalog" runat="server"><span class="glyphicon glyphicon-plus"></span><span>اضف كتالوج جديد</span></asp:HyperLink>
            </div>
            <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                <div id="pnlData" class="panel panel-primary">
                    <div class="panel-heading" role="button" data-toggle="collapse" href="#divData" aria-expanded="false" aria-controls="divData">
                        بيانات الكتالوج 
                         <%--     <a class="btn btn-primary" role="button" data-toggle="collapse" href="#divData" aria-expanded="false" aria-controls="divData">
                        بيانات الكتالوج    
                        </a>--%>
                    </div>
                    <div id="divData" class="panel-body">

                        <div class="Content">
                            <div class="ContentItem row">
                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                    <asp:Label ID="Label9" runat="server" Text="اسم الكتالوج  *" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="Save" CssClass="Validator"
                                        ControlToValidate="txtTitle" runat="server" Display="Dynamic" ErrorMessage="! من فضلك ادخل اسم لكتالوج"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="ContentItem row">
                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                <asp:Label ID="Label15" runat="server" CssClass="control-label" Text="اسم الفئة"></asp:Label>
                            </div>
                            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                <asp:DropDownList ID="ddlCategories" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlCategories" CssClass="Validator" Display="Dynamic" ErrorMessage="الرجاء اختيار الفئة" InitialValue="0" ValidationGroup="Save"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                            <div class="ContentItem row">
                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                    <asp:Label ID="Label3" runat="server" Text="الصورة" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12 pull-right">
                                    <div id="divlogo" class="thumbnail col-md-3 col-sm-12" runat="server">
                                        <asp:Image ID="imgPhoto" runat="server" />
                                    </div>
                                    <telerik:RadAsyncUpload ID="ruPhoto" CssClass="uploadimage form-control" runat="server"
                                        Culture="ar-EG" AllowedFileExtensions="png,jpg,jpeg,gif,JPEG"
                                        ControlObjectsVisibility="None" MaxFileSize="10485760" OnClientValidationFailed="validationFailed"
                                        OnClientFileUploading="OnClientFileUploading" MultipleFileSelection="Automatic"
                                        OnClientFileUploaded="OnClientFileUploaded">
                                        <Localization Select="اختار" Cancel="إلغاء" Remove="حذف" />
                                    </telerik:RadAsyncUpload>
                                    <br />

                                    <div id="divImgLoading" style="display: none">
                                        جارى تحميل الصورة
                
                                    </div>
                                    <asp:CustomValidator ID="Customvalidator1" runat="server" ClientValidationFunction="validateRadUpload"
                                        ErrorMessage="! من فضلك ادخل صورة" ValidationGroup="Save" CssClass="Validator"
                                        Display="Dynamic">
                                    </asp:CustomValidator>
                                    <asp:CustomValidator ID="Customvalidator2" runat="server" ClientValidationFunction="validateRadUploadExtension"
                                        ErrorMessage="نوع الملف غير مسموح به " ValidationGroup="Save" CssClass="Validator"
                                        Display="Dynamic">
                                    </asp:CustomValidator>
                                    <asp:CustomValidator ID="Customvalidator3" runat="server" ClientValidationFunction="validateRadUploadFilesize"
                                        ErrorMessage=" حجم الصورة يجب ان لا يزيد عن 10 ميجا" ValidationGroup="Save"
                                        CssClass="Validator" Display="Dynamic">
                                    </asp:CustomValidator>
                                </div>
                            </div>
                            <%--<div class="ContentItem row">
                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                    <asp:Label ID="Label11" runat="server" Text=" صورة الفيس" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12 pull-right">
                                    <div id="divImgSocial" class="thumbnail col-md-3 col-sm-12" runat="server">
                                        <asp:Image ID="imgSocial" runat="server" />
                                    </div>
                                    <telerik:RadAsyncUpload ID="ruSocial" CssClass="uploadimage form-control" runat="server"
                                        Culture="ar-EG" AllowedFileExtensions="png,jpg,jpeg,gif,JPEG"
                                        ControlObjectsVisibility="None" MaxFileSize="10485760" OnClientValidationFailed="validationFailed"
                                        OnClientFileUploading="OnClientFileSocialUploading" MultipleFileSelection="Automatic"
                                        OnClientFileUploaded="OnClientFileSocialUploaded">
                                        <Localization Select="اختار" Cancel="إلغاء" Remove="حذف" />
                                    </telerik:RadAsyncUpload>
                                    <br />

                                    <div id="divSocialImgLoading" style="display: none">
                                        جارى تحميل الصورة
                
                                    </div>
                                    <asp:CustomValidator ID="Customvalidator4" runat="server" ClientValidationFunction="validatSocialeRadUpload"
                                        ErrorMessage="! من فضلك ادخل صورة" ValidationGroup="Save" CssClass="Validator"
                                        Display="Dynamic">
                                    </asp:CustomValidator>
                                    <asp:CustomValidator ID="Customvalidator5" runat="server" ClientValidationFunction="validateRadUploadExtension"
                                        ErrorMessage="نوع الملف غير مسموح به " ValidationGroup="Save" CssClass="Validator"
                                        Display="Dynamic">
                                    </asp:CustomValidator>
                                    <asp:CustomValidator ID="Customvalidator6" runat="server" ClientValidationFunction="validateRadUploadFilesize"
                                        ErrorMessage=" حجم الصورة يجب ان لا يزيد عن 10 ميجا" ValidationGroup="Save"
                                        CssClass="Validator" Display="Dynamic">
                                    </asp:CustomValidator>
                                </div>
                            </div>--%>
                            <div class="ContentItem row">
                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                    <asp:Label ID="Label5" runat="server" Text="الوصف * " CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" Style="min-height: 60px;"
                                        TextMode="MultiLine" MaxLength="2000" placeholder=" أكتب وصف كامل للكتالوج"></asp:TextBox>
                                    <asp:Label ID="Label12" runat="server" Style="width: 100%; background-color: transparent;"
                                        Text="عدد الاحرف يجب ان لا يزيد عن 2000 حرف" CssClass="Note"></asp:Label>
                                    <br />
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="Save" CssClass="Validator"
                                        ControlToValidate="txtDescription" runat="server" Display="Dynamic" ErrorMessage="! من فضلك ادخل وصف الكتالوج"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="ContentItem row">
                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                    <asp:Label ID="Label16" runat="server" Text="Tags * " CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">

                                    <telerik:RadEditor ID="reTags" CssClass="Editor" runat="server">
                                        <Tools>
                                            <telerik:EditorToolGroup>
                                                <telerik:EditorTool Name="FormatBlock" />
                                                <telerik:EditorTool Name="InsertLink" />
                                            </telerik:EditorToolGroup>
                                        </Tools>
                                    </telerik:RadEditor>
                                </div>
                            </div>
                            <%--    <div class="ContentItem row">
                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                    <asp:Label ID="Label15" runat="server" Text="All Tags" CssClass="control-label"></asp:Label>
                                </div>

                                <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                    <asp:CheckBox ID="chkTags" runat="server" />
                                </div>
                            </div>--%>
                            <div class="ContentItem row">
                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                    <asp:Label ID="Label10" runat="server" Text="اسم الرابط  *" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                    <asp:HyperLink ID="hlURL" Target="_blank" runat="server"> الرابط</asp:HyperLink>
                                </div>
                            </div>

                            <div class="row">
                                <div class="ContentItem">
                                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg btn-primary" Text="حفظ"
                                        ValidationGroup="Save" OnClick="btnSave_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="divRealestateList" runat="server" class="panel panel-default">
                    <ul class="nav nav-tabs pull-right tabList" role="tablist">
                        <li role="presentation" class="active pull-right tab"><a href="#divNewProp" aria-controls="divNewProp" role="tab" data-toggle="tab">اضف عقار جديد</a></li>
                        <li role="presentation" class="pull-right tab"><a href="#divPropList" aria-controls="divPropList" role="tab" data-toggle="tab">قائمة العقارات</a></li>
                        <li role="presentation" class="pull-right tab"><a href="#divTagList" aria-controls="divTagList" role="tab" data-toggle="tab">Tags</a></li>
                    </ul>
                    <div class="tab-content pull-right tabContent" style="margin-top: 10px;">
                        <div role="tabpanel" class="active tab-pane pull-right tabContent" id="divNewProp">

                            <div class=" pull-right  col-md-2 col-sm-2 col-xs-2">
                                <ul class="nav nav-pills nav-stacked tabList-Vertical">
                                    <li role="presentation" class="active pull-right"><a href="#divByCode" aria-controls="divByCode" role="tab" data-toggle="tab">بالكود</a></li>
                                    <li role="presentation" class="pull-right"><a href="#divByCompany" aria-controls="divByCompany" role="tab" data-toggle="tab">بالشركة</a></li>
                                    <li role="presentation" class="pull-right"><a href="#divByProject" aria-controls="divByProject" role="tab" data-toggle="tab">بالمشروع</a></li>
                                    <li role="presentation" class="pull-right"><a href="#divByUser" aria-controls="divByUser" role="tab" data-toggle="tab">بالمستخدم</a></li>
                                </ul>
                            </div>
                            <div class="col-md-10 col-sm-10 col-xs-10">
                                <div id="divAddMsg" runat="server">
                                    <asp:Label ID="lblAddMsg" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="tab-content pull-right tabContent">
                                    <div role="tabpanel" class="tab-pane active pull-right tabContent" id="divByCode">
                                        <div class="ContentItem">
                                            <div class="col-md-8 col-sm-10 pull-right">
                                                <asp:Label ID="Label2" runat="server" CssClass="control-label" Text="اكواد العقارات"></asp:Label>
                                                <asp:TextBox ID="txtCode" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:Label ID="Label11" runat="server" CssClass="Note" Text="ادخل اكواد العقارات بينهم ','"></asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCode" CssClass="Validator" ErrorMessage="!" ValidationGroup="AddByCode"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-1 col-sm-2 pull-right">
                                                <asp:Button ID="btnAddByCode" Style="margin-top: 20px" runat="server" CssClass="btn btn-lg btn-primary pull-left" Text="اضف" ValidationGroup="AddByCode" OnClick="btnAddByCode_Click" />
                                            </div>
                                        </div>

                                    </div>
                                    <div role="tabpanel" class="tab-pane pull-right tabContent" id="divByCompany">
                                        <div class="ContentItem row">
                                            <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                                                <asp:Label ID="Label4" runat="server" Text="الشركة *" CssClass="control-label"></asp:Label>
                                            </div>
                                            <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                                                <asp:DropDownList ID="ddlCompany" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="AddByCompany" CssClass="Validator"
                                                    ControlToValidate="ddlCompany" runat="server" ErrorMessage="!"
                                                    InitialValue="0"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="ContentItem row">
                                            <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                                                <asp:Label ID="Label13" runat="server" Text="العقار *" CssClass="control-label"></asp:Label>
                                            </div>
                                            <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                                                <asp:DropDownList ID="ddlCompanyRealestate" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="AddByCompany" CssClass="Validator"
                                                    ControlToValidate="ddlCompanyRealestate" runat="server" ErrorMessage="!"
                                                    InitialValue="0"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="ContentItem row">
                                            <asp:Button ID="btnAddByCompany" Style="margin-top: 20px" runat="server" CssClass="btn btn-lg btn-primary pull-right" Text="اضف" ValidationGroup="AddByCompany" OnClick="btnAddByCompany_Click" />
                                        </div>
                                    </div>
                                    <div role="tabpanel" class="tab-pane pull-right tabContent" id="divByProject">
                                        <div class="ContentItem row">
                                            <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                                                <asp:Label ID="Label1" runat="server" Text="المشروع *" CssClass="control-label"></asp:Label>
                                            </div>
                                            <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                                                <asp:DropDownList ID="ddlProjects" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlProjects_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="AddByProject" CssClass="Validator"
                                                    ControlToValidate="ddlProjects" runat="server" ErrorMessage="!"
                                                    InitialValue="0"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="ContentItem row">
                                            <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                                                <asp:Label ID="Label6" runat="server" Text="العقار *" CssClass="control-label"></asp:Label>
                                            </div>
                                            <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                                                <asp:DropDownList ID="ddlProjectRealestate" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="AddByProject" CssClass="Validator"
                                                    ControlToValidate="ddlProjectRealestate" runat="server" ErrorMessage="!"
                                                    InitialValue="0"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="ContentItem row">
                                            <asp:Button ID="btnAddByProject" Style="margin-top: 20px" runat="server" CssClass="btn btn-lg btn-primary pull-right" Text="اضف" ValidationGroup="AddByProject" OnClick="btnAddByProject_Click" />
                                        </div>
                                    </div>
                                    <div role="tabpanel" class="tab-pane pull-right tabContent" id="divByUser">
                                        <div class="ContentItem row">
                                            <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                                                <asp:Label ID="Label7" runat="server" Text="اسم المستخدم *" CssClass="control-label"></asp:Label>
                                            </div>
                                            <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                                                <asp:DropDownList ID="ddlUsers" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlUsers_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="AddByUser" CssClass="Validator"
                                                    ControlToValidate="ddlUsers" runat="server" ErrorMessage="!"
                                                    InitialValue="0"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="ContentItem row">
                                            <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                                                <asp:Label ID="Label8" runat="server" Text="العقار *" CssClass="control-label"></asp:Label>
                                            </div>
                                            <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                                                <asp:DropDownList ID="ddlUserRealestate" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="AddByUser" CssClass="Validator"
                                                    ControlToValidate="ddlUserRealestate" runat="server" ErrorMessage="!"
                                                    InitialValue="0"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="ContentItem row">
                                            <asp:Button ID="btnAddByUser" Style="margin-top: 20px" runat="server" CssClass="btn btn-lg btn-primary pull-right" Text="اضف" ValidationGroup="AddByUser" OnClick="btnAddByUser_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div role="tabpanel" class="tab-pane  pull-right tabContent" id="divPropList">
                            <asp:GridView ID="gvRealestates" runat="server" DataKeyNames="ID" AutoGenerateColumns="False"
                                CellPadding="4" CssClass="table table-striped table-bordered table-hover theGridTable">
                                <AlternatingRowStyle />
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="Id" Visible="false" />

                                    <asp:BoundField DataField="Code" HeaderText=" كود العقار" HeaderStyle-HorizontalAlign="Center"
                                        HeaderStyle-CssClass="GridColumnHeader">
                                        <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RealestateTitle" HeaderText="اعلان العقار" HeaderStyle-HorizontalAlign="Center"
                                        HeaderStyle-CssClass="GridColumnHeader">
                                        <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ibtnDelete" runat="server" CssClass="Deleteconfirm" ImageUrl="~/Images/icons/Delete.png" OnClick="ibtnDelete_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <a target="_blank" href='<%#"~/RealEstateView/"+Eval("ID")+"/0" %>' runat="server">
                                                <img src="~/Images/icons/view.png" runat="server" />
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                            <%--                            <asp:ListView DataKeyNames="ID" ID="lvRealestates" runat="server">
                                <ItemTemplate>
                                    <div class="thumbnail">
                                        <span><%=Eval("RealEstate.Title")%></span>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>--%>
                        </div>
                        <div role="tabpanel" class="tab-pane  pull-right tabContent" id="divTagList">
                            <div class="row ContentItem">
                                <div class="col-md-8 col-sm-10 pull-right">
                                    <asp:Label ID="Label14" runat="server" CssClass="control-label" Text="Paent Tags"></asp:Label>
                                    <asp:DropDownList ID="ddlTags" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ValidationGroup="AddTag" CssClass="Validator"
                                        ControlToValidate="ddlTags" runat="server" ErrorMessage="!"
                                        InitialValue="0"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-1 col-sm-2 pull-right">
                                    <asp:Button ID="btnAddTag" Style="margin-top: 20px" runat="server" CssClass="btn btn-lg btn-primary pull-left" Text="اضف" ValidationGroup="AddTag" OnClick="btnAddTag_Click" />
                                </div>
                            </div>
                            <div class="row">
                                <asp:GridView ID="gvTags" runat="server" DataKeyNames="ID" AutoGenerateColumns="False"
                                    CellPadding="4" CssClass="table table-striped table-bordered table-hover theGridTable">
                                    <AlternatingRowStyle />
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="Id" Visible="false" />

                                        <asp:BoundField DataField="TagName" HeaderText="Tag" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-CssClass="GridColumnHeader">
                                            <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibtnDeleteTag" runat="server" CssClass="Deleteconfirm" ImageUrl="~/Images/icons/Delete.png" OnClick="ibtnDeleteTag_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
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
            <%--function validateSocialRadUpload(source, e) {
                if (ValidExt == false || ValidFileSiZe == false) {
                    e.IsValid = true;
                    return;
                }
                var mode = "<;%= Mode %>";
                if (mode == "Edit") {
                    e.IsValid = true;
                    return;
                }
                e.IsValid = false;
                var upload = $find("<%= ruSocial.ClientID %>");
                e.IsValid = upload.getUploadedFiles().length != 0;

            }--%>
            <%--            function OnClientFileSocialUploading(sender, args) {
                //  alert("test");

                $("#divSocialImgLoading").show();
                $("#<%=btnSave.ClientID %>").prop('disabled', true);
                // alert($("#<%=lblMsg.ClientID %>").val()); //.hide()//.text("جارى تحميل الصورة....");
            }
            function OnClientFileSocialUploaded(sender, args) {

                $("#divSocialImgLoading").hide();
                $("#<%=btnSave.ClientID %>").prop('disabled', false);
            }--%>
        </script>
    </telerik:RadCodeBlock>
</asp:Content>
