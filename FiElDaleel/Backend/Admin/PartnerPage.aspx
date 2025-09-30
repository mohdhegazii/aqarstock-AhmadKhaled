<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master"
    AutoEventWireup="true" CodeBehind="PartnerPage.aspx.cs" Inherits="BrokerWeb.Backend.Admin.PartnerPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h4>
                بيانات صفحة شركة المشترك</h4>
            <div id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="panel-body">
            <div class="ContentItem row">
                <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12 pull-right">
                    <asp:Label ID="Label1" runat="server" CssClass="control-label" Text="اسم المشترك"></asp:Label>
                </div>
                <div class="col-lg-11 col-md-11 col-sm-11 col-xs-12">
                    <asp:DropDownList ID="ddlSubscriber" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlSubscriber"
                        CssClass="Validator" Display="Dynamic" ErrorMessage="!" InitialValue="0" ValidationGroup="Save"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="ContentItem row">
                <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12 pull-right">
                    <asp:Label ID="Label2" runat="server" CssClass="control-label" Text="اسم الشركة"></asp:Label>
                </div>
                <div class="col-lg-11 col-md-11 col-sm-11 col-xs-12">
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                        CssClass="Validator" Display="Dynamic" ErrorMessage="!" ValidationGroup="Save"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="ContentItem row">
                <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12 pull-right">
                    <asp:Label ID="Label3" runat="server" CssClass="control-label" Text=" عنوان الصفحة"></asp:Label>
                </div>
                <div class="col-lg-11 col-md-11 col-sm-11 col-xs-12">
                    <asp:TextBox ID="txtPageTitle" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPageTitle"
                        CssClass="Validator" Display="Dynamic" ErrorMessage="!" ValidationGroup="Save"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="ContentItem row">
                <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12 pull-right">
                    <asp:Label ID="Label4" runat="server" CssClass="control-label" Text=" الوصف"></asp:Label>
                </div>
                <div class="col-lg-11 col-md-11 col-sm-11 col-xs-12">
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDescription"
                        CssClass="Validator" Display="Dynamic" ErrorMessage="!" ValidationGroup="Save"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="ContentItem row">
                <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12 pull-right">
                    <asp:Label ID="Label5" runat="server" CssClass="control-label" Text="كلمات دالة"></asp:Label>
                </div>
                <div class="col-lg-11 col-md-11 col-sm-11 col-xs-12">
                    <asp:TextBox ID="txtkeywords" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtkeywords"
                        CssClass="Validator" Display="Dynamic" ErrorMessage="!" ValidationGroup="Save"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="ContentItem row">
                <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12 pull-right">
                    <asp:Label ID="Label6" runat="server" CssClass="control-label" Text="رابط الصفحة"></asp:Label>
                </div>
                <div class="col-lg-11 col-md-11 col-sm-11 col-xs-12">
                    <asp:TextBox ID="txtURL" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtURL"
                        CssClass="Validator" Display="Dynamic" ErrorMessage="!" ValidationGroup="Save"></asp:RequiredFieldValidator>--%>
                </div>
            </div>
            <div class="ContentItem row">
                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                    <asp:Label ID="Label7" runat="server" Text="الصورة" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12 pull-right">
                    <div id="divlogo" runat="server">
                        <asp:Image ID="imgIcon" CssClass="img-thumbnail Icon" runat="server" />
                        <br />
                    </div>
                    <%--<telerik:RadUpload ID="ruPhoto" CssClass="uploadimage form-control" runat="server"
                        Culture="ar-EG" AllowedFileExtensions="png,jpg,jpeg,gif,JPEG" MaxFileInputsCount="1"
                        ControlObjectsVisibility="None" >
                        
                        <Localization Select="اختار" />
                        
                    </telerik:RadUpload>--%>
                    <telerik:RadAsyncUpload ID="ruPhoto" CssClass="uploadimage form-control" runat="server"
                        Culture="ar-EG" AllowedFileExtensions="png,jpg,jpeg,gif,JPEG" ControlObjectsVisibility="None"
                        MaxFileSize="10485760" OnClientValidationFailed="validationFailed" OnClientFileUploading="OnClientFileUploading"
                        MultipleFileSelection="Automatic" OnClientFileUploaded="OnClientFileUploaded">
                        <Localization Select="اختار" Cancel="إلغاء" Remove="حذف" />
                    </telerik:RadAsyncUpload>
                    <br />
                    <div id="divImgLoading" style="display: none">
                        جارى تحميل الصورة
                    </div>
                    <asp:CustomValidator ID="Customvalidator1" runat="server" ClientValidationFunction="validateRadUpload"
                        ErrorMessage="! من فضلك ادخل صورة" ValidationGroup="SavePhoto" CssClass="Validator"
                        Display="Dynamic">
                    </asp:CustomValidator>
                    <asp:CustomValidator ID="Customvalidator2" runat="server" ClientValidationFunction="validateRadUploadExtension"
                        ErrorMessage="نوع الملف غير مسموح به " ValidationGroup="SavePhoto" CssClass="Validator"
                        Display="Dynamic">
                    </asp:CustomValidator>
                </div>
            </div>
            <div class="ContentItem">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg btn-primary pull-left"
                    OnClick="btnSave_Click" Text="حفظ" ValidationGroup="Save" />
            </div>
        </div>
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
                        ValidFileSiZe = false;
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
        </script>
</asp:Content>
