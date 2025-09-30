<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucProjectPhoto.ascx.cs"
    Inherits="BrokerWeb.Backend.SubScriber.UserControls.ucProjectPhoto" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="gvPhotos">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divPhotoControls" LoadingPanelID="radLoadingPannel"
                    UpdatePanelRenderMode="Block" />
                <telerik:AjaxUpdatedControl ControlID="gvPhotos" UpdatePanelRenderMode="Block" />
                <telerik:AjaxUpdatedControl ControlID="divMsg" UpdatePanelRenderMode="Block" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="lbtnAdd">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divPhotoControls" LoadingPanelID="radLoadingPannel"
                    UpdatePanelRenderMode="Block" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<div class="Header">
    <%-- <h1>
        صور العقار/الارض
    </h1>--%>
    <div id="divMsg" runat="server">
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:LinkButton ID="lbtnAdd" OnClientClick="OpenWindow()" runat="server"
            OnClick="lbtnAdd_Click">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/icons/AddNew.png"></asp:Image>
            <span>اضف صورة للمشروع</span>
        </asp:LinkButton>
        <%-- <a onclick="OpenWindow()">
            <asp:Image ID="imgAdd" runat="server" ImageUrl="~/Images/icons/AddNew.png"></asp:Image>
            <span>اضف صورة للمشروع</span> </a>--%>
    </div>
</div>
<div class="Content">
    <telerik:RadWindow ID="rwRequestDetails" runat="server" Behaviors="Resize, Close"
        CssClass="row window" Width="700px" Height="430px" KeepInScreenBounds="true"
        Modal="True" OffsetElementID="divWindow" Title="بيانات الصورة" Top="-10">
        <ContentTemplate>
            <div id="divPhotoControls" class="row" style="margin-top: 10px;" runat="server">
                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12 pull-right">
                    <div class="ContentItem row">
                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 pull-right">
                            <asp:Label ID="Label3" runat="server" CssClass="control-label" Text=" الصورة  *"></asp:Label>
                        </div>
                        <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                            <div>
                                <telerik:RadAsyncUpload ID="ruPhoto" CssClass="uploadimage form-control" runat="server"
                                    Culture="ar-EG" AllowedFileExtensions="png,jpg,jpeg,gif,JPEG" ControlObjectsVisibility="all"
                                    MultipleFileSelection="Disabled" MaxFileInputsCount="1" UploadedFilesRendering="BelowFileInput"
                                    OnClientFileUploaded="OnClientFileUploaded" OnClientValidationFailed="validationFailed"
                                    OnClientFileUploading="OnClientFileUploading" EnableInlineProgress="false">
                                    <Localization Select="اختار" Cancel="إلغاء" Remove="حذف" />
                                    <Localization Select="اختار" Cancel="إلغاء" Remove="حذف" />
                                </telerik:RadAsyncUpload>
                                <%-- <telerik:RadProgressManager runat="server" ID="RadProgressManager1" />--%>
                                <telerik:RadProgressArea runat="server" ID="RadProgressArea1" />
                                <asp:CustomValidator ID="Customvalidator1" runat="server" ClientValidationFunction="validateRadUpload"
                                    ErrorMessage=" من فضلك ادخل الصورة" ValidationGroup="SavePhoto" CssClass="Validator"
                                    Display="Dynamic">
                                </asp:CustomValidator>
                                <asp:CustomValidator ID="Customvalidator11" runat="server" ClientValidationFunction="validateRadUploadExtension"
                                    ErrorMessage="نوع الملف غير مسموح به " ValidationGroup="SavePhoto" CssClass="Validator"
                                    Display="Dynamic">
                                </asp:CustomValidator>
                            </div>
                        </div>
                    </div>
                    <div class="ContentItem row">
                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 pull-right">
                            <asp:Label ID="Label1" runat="server" Text="التاريخ" CssClass="control-label"></asp:Label>
                        </div>
                        <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                            <telerik:RadDatePicker ID="rdpDate" runat="server">
                            </telerik:RadDatePicker>
                        </div>
                    </div>
                    <div class="ContentItem row" style="margin-bottom: 0px">
                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 pull-right">
                            <asp:Label ID="Label5" runat="server" Text=" وصف الصورة *" CssClass="control-label"></asp:Label>
                        </div>
                        <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine"
                                MaxLength="500" placeholder=" أكتب وصف للصورة."></asp:TextBox>
                            <asp:Label ID="Label12" runat="server" Style="width: 100%; background-color: transparent;"
                                Text="عدد الاحرف يجب ان لا يزيد عن 500 حرف" CssClass="Note"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="SavePhoto"
                                CssClass="Validator" ControlToValidate="txtDescription" runat="server" Display="Dynamic"
                                ErrorMessage="! من فضلك ادخل وصف الصورة"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="ContentItem row">
                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 pull-right hidden-xs">
                        </div>
                        <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                            <asp:CheckBox ID="chkIsDefault" Text="الصورة الرئيسية" CssClass="Check" Style="margin: 5px;"
                                runat="server" />
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                    <div id="divlogo" style="max-height: 200px; max-width: 200px; margin-top: 10px; float: left"
                        runat="server">
                        <asp:Image ID="imgLogo" CssClass="img-thumbnail Icon" runat="server" />
                        <br />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="ContentItem">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg " Text="حفظ"
                        ValidationGroup="SavePhoto" OnClick="btnSave_Click" />
                </div>
            </div>
        </ContentTemplate>
    </telerik:RadWindow>
    <div class="row">
        <div class="ContentItem">
            <asp:GridView ID="gvPhotos" runat="server" DataKeyNames="ID" AutoGenerateColumns="False"
                CellPadding="4" CssClass="table table-striped table-bordered table-hover theGridTable"
                AllowPaging="True" PageSize="20" OnPageIndexChanging="gvPhotos_PageIndexChanging">
                <AlternatingRowStyle />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Id" Visible="false" />
                    <asp:CheckBoxField DataField="IsDefault" HeaderText="الصورة الرئيسية" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-CssClass="GridColumnHeader">
                        <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                    </asp:CheckBoxField>
                    <asp:BoundField DataField="Description" HeaderText=" الملاحظات" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-CssClass="GridColumnHeader">
                        <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Date" HeaderText=" التاريخ" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-CssClass="GridColumnHeader" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                    </asp:BoundField>
                    <asp:ImageField DataImageUrlField="PhotoURL" HeaderText="الصورة" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-CssClass="GridColumnHeader" ItemStyle-CssClass="imageColumnStyle">
                        <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                    </asp:ImageField>
                    <asp:TemplateField HeaderText="حذف" HeaderStyle-HorizontalAlign="Center">
                        <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                        <ItemTemplate>
                            <asp:ImageButton ID="ibtnDelete" CssClass="DoubleDeleteconfirm" runat="server" ImageUrl="~/Images/icons/Delete.png"
                                OnClick="ibtnDelete_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="تعديل" HeaderStyle-HorizontalAlign="Center">
                        <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                        <ItemTemplate>
                            <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/icons/Edit.png"
                                OnClientClick="OpenWindow()" OnClick="ibtnEdit_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
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
<telerik:RadCodeBlock ID="RadScriptBlock1" runat="server">
    <script type="text/javascript">

        function OpenWindow() {
            var oWnd = $find("<%= rwRequestDetails.ClientID %>");
            oWnd.show();
        }
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
    </script>
</telerik:RadCodeBlock>
