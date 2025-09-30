<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucRealEstatePhotos.ascx.cs" Inherits="BrokerWeb.Backend.SubScriber.UserControls.ucRealEstatePhotos" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<div class="Header">
    <h1>
        صور العقار/الارض
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
                    <telerik:RadUpload ID="ruPhoto" CssClass="uploadimage form-control" runat="server"
                        Culture="ar-EG" AllowedFileExtensions="png,jpg,jpeg,gif,JPEG" MaxFileInputsCount="1"
                        ControlObjectsVisibility="None" MaxFileSize="1048576">
                        <Localization Select="اختار" />
                    </telerik:RadUpload>
                    <asp:CustomValidator ID="Customvalidator1" runat="server" ClientValidationFunction="validateRadUpload"
                        ErrorMessage="! من فضلك ادخل صورة" ValidationGroup="SavePhoto" CssClass="Validator"
                        Display="Dynamic">
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
            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg" Text="حفظ" ValidationGroup="SavePhoto"
                OnClick="btnSave_Click" />
        </div>
    </div>
    <div class="row">
        <div class="ContentItem">
            <asp:ListView ID="lvPhotos" DataKeyNames="ID" runat="server">
                <ItemTemplate>
                    <div class="ImageItem col-lg-3 col-md-3 col-sm-4 col-xs-6 pull-right">
                        <div class="DefaultTitle">
                            <asp:Label ID="lblDefault" runat="server" Text='<%# CheckDefault(Eval("IsDefault")) %>'></asp:Label>
                        </div>
                        <asp:Image ID="imgPhoto" CssClass="img-responsive img-rounded thumbnail Image" ImageUrl='<%#Eval("PhotoName") %>'
                            runat="server" />
                        <div class="ImageControls">
                            <asp:ImageButton ID="imgDelete" CssClass="img-responsive Deleteconfirm" ImageUrl="~/images/Delete.png"
                                runat="server" OnClick="imgDelete_Click" />
                            <asp:ImageButton ID="imgSetDefault" CssClass="img-responsive" ToolTip="تحديد كصورة رئيسية"
                                ImageUrl="~/images/DefaultImage.png" runat="server" OnClick="imgSetDefault_Click" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</div>
<script type="text/javascript">

    function validateRadUpload(source, e) {
        e.IsValid = false;
        var upload = $find("<%= ruPhoto.ClientID %>");
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
