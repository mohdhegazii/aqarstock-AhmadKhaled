<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucRealEstatePhotos.ascx.cs"
    Inherits="BrokerWeb.Backend.SubScriber.UserControls.ucRealEstatePhotos" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<div class="Header">
    <h1>صور العقار/الارض
    </h1>
    <div id="divMsg" runat="server">
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
</div>
<div class="Content">
    <div id="divControls" class="row" runat="server">
        <div class="pull-right">
            <div class="ContentItem row">
                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                    <asp:Label ID="Label3" runat="server" Text="الصورة" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12 pull-right">
                    <div id="divlogo" runat="server">
                    </div>
                    <%--<telerik:RadUpload ID="ruPhoto" CssClass="uploadimage form-control" runat="server"
                        Culture="ar-EG" AllowedFileExtensions="png,jpg,jpeg,gif,JPEG" MaxFileInputsCount="1"
                        ControlObjectsVisibility="None" >
                        
                        <Localization Select="اختار" />
                        
                    </telerik:RadUpload>--%>
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
                        ErrorMessage="! من فضلك ادخل صورة" ValidationGroup="SavePhoto" CssClass="Validator"
                        Display="Dynamic">
                    </asp:CustomValidator>
                    <asp:CustomValidator ID="Customvalidator2" runat="server" ClientValidationFunction="validateRadUploadExtension"
                        ErrorMessage="نوع الملف غير مسموح به " ValidationGroup="SavePhoto" CssClass="Validator"
                        Display="Dynamic">
                    </asp:CustomValidator>
                    <asp:CustomValidator ID="Customvalidator3" runat="server" ClientValidationFunction="validateRadUploadFilesize"
                        ErrorMessage=" حجم الصورة يجب ان لا يزيد عن 10 ميجا" ValidationGroup="SavePhoto"
                        CssClass="Validator" Display="Dynamic">
                    </asp:CustomValidator>
                </div>
            </div>
            <div class="ContentItem row">
                <asp:CheckBox ID="chkIsDefault" Text="الصورة الرئيسية" CssClass="Check" runat="server" />
            </div>
        </div>
    </div>

    <div class="row">
        <div class="ContentItem">
            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg btn-primary" Text="حفظ"
                ValidationGroup="SavePhoto" OnClick="btnSave_Click" />
        </div>
    </div>
    <div class="row">
        <div class="ContentItem">
            <asp:ListView ID="lvPhotos" DataKeyNames="ID" runat="server">
                <ItemTemplate>
                    <div class="ImageItemHolder">
                        <div class="ImageItem col-lg-3 col-md-3 col-sm-4 col-xs-6 pull-right">
                            <div class="DefaultTitle">
                                <asp:Label ID="lblDefault" runat="server" Text='<%# CheckDefault(Eval("IsDefault")) %>'></asp:Label>
                            </div>
                            <asp:Image ID="imgPhoto" CssClass="img-responsive img-rounded thumbnail Image" ImageUrl='<%#Eval("PhotoName") %>'
                                runat="server" />

                        </div>
                        <div class="ImageControls">
                            <asp:ImageButton ID="imgDelete" CssClass="img-responsive Deleteconfirm" ImageUrl="~/images/icons/deny.png"
                                runat="server" OnClick="imgDelete_Click" />
                            <asp:ImageButton ID="imgSetDefault" CssClass="img-responsive" ToolTip="تحديد كصورة رئيسية"
                                ImageUrl="~/images/icons/approve.png" runat="server" OnClick="imgSetDefault_Click" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
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
