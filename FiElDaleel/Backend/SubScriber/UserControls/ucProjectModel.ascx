<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucProjectModel.ascx.cs"
    Inherits="BrokerWeb.Backend.SubScriber.UserControls.ucProjectModel" %>
    <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy2" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="gvModels">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divModelControls" LoadingPanelID="radLoadingPannel"
                    UpdatePanelRenderMode="Block" />
                <telerik:AjaxUpdatedControl ControlID="gvModels" UpdatePanelRenderMode="Block" />
                <telerik:AjaxUpdatedControl ControlID="divMsg" UpdatePanelRenderMode="Block" />
            </UpdatedControls>
        </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lbtnAdd">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divModelControls" LoadingPanelID="radLoadingPannel"
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
       <asp:LinkButton ID="lbtnAdd" OnClientClick="OpenWindow()" runat="server" 
            onclick="lbtnAdd_Click">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/icons/AddNew.png"></asp:Image>
            <span>اضف نموذج للمشروع</span>
        </asp:LinkButton>
</div>
<div class="Content">
    <telerik:RadWindow ID="rwRequestDetails" runat="server" Behaviors="Resize, Close"
        CssClass="row window" Width="700px" Height="430px" KeepInScreenBounds="true"
        Modal="True" OffsetElementID="divWindow" Title="بيانات النموذج" Top="-10">
        <ContentTemplate>
    <div id="divModelControls" class="row" style="margin-top:10px; margin-right:10px;" runat="server">
        <div class="pull-right">
            <div class="ContentItem row">
                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                    <asp:Label ID="Label9" runat="server" Text="اسم النموذج  *" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="SaveModel" CssClass="Validator"
                        ControlToValidate="txtTitle" runat="server" Display="Dynamic" ErrorMessage="! من فضلك ادخل اسم النموذج"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="ContentItem row">
                <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                    <asp:Label ID="Label13" runat="server" Text="نوع العقار *" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="SaveModel" CssClass="Validator"
                        ControlToValidate="ddlType" runat="server" ErrorMessage="! من فضلك ادخل نوع العقار"
                        InitialValue="0"></asp:RequiredFieldValidator>
                </div>
            </div>
                 <div class="ContentItem row">
                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                        <asp:Label ID="Label18" runat="server" Text="المساحة" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                     <telerik:RadNumericTextBox ID="txtArea" runat="server" CssClass="form-control"
                                            LabelWidth="" Width="100%" >
                                            <NumberFormat ZeroPattern="n" AllowRounding="False" DecimalDigits="5" KeepNotRoundedValue="True">
                                            </NumberFormat>
                                        </telerik:RadNumericTextBox>
                                        <asp:Label ID="Label27" runat="server" Text="من فضلك ادخل المساحة بالمتر المربع"
                                        CssClass="Note"></asp:Label>
                                        <br />
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ValidationGroup="SaveModel" CssClass="Validator"
                                        ControlToValidate="txtArea" runat="server" Display="Dynamic" ErrorMessage="! من فضلك ادخل المساحة "></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                 <div class="ContentItem row">
                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                        <asp:Label ID="Label19" runat="server" Text="السعر" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                         <telerik:RadNumericTextBox ID="txtPrice" runat="server" CssClass="form-control"
                                            LabelWidth="" Width="100%"  >
                                            <NumberFormat ZeroPattern="n" AllowRounding="False" DecimalDigits="5" KeepNotRoundedValue="True">
                                            </NumberFormat>
                                        </telerik:RadNumericTextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ValidationGroup="SaveModel" CssClass="Validator"
                                        ControlToValidate="txtPrice" runat="server" Display="Dynamic" ErrorMessage="! من فضلك ادخل السعر "></asp:RequiredFieldValidator>
                                    
                                    </div>
                                </div>
            <div class="ContentItem row">
                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                    <asp:Label ID="Label5" runat="server" Text="الوصف * " CssClass="control-label"></asp:Label>
                </div>
                <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine"
                        MaxLength="500" placeholder=" أكتب وصف كامل للنموذج."></asp:TextBox>
                    <asp:Label ID="Label12" runat="server" Style="width: 100%; background-color: transparent;"
                        Text="عدد الاحرف يجب ان لا يزيد عن 500 حرف" CssClass="Note"></asp:Label>
                    <br />
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="SaveModel" CssClass="Validator"
                        ControlToValidate="txtDescription" runat="server" Display="Dynamic" ErrorMessage="! من فضلك ادخل وصف النموذج"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="ContentItem row">
                <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                    <asp:Label ID="Label3" runat="server" CssClass="control-label" Text=" صورة تخطيط العقار*"></asp:Label>
                </div>
                <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                    <div>
                        <div class="col-lg-7 col-md-7 col-sm-7 col-xs-12 pull-right">
                            <telerik:radasyncupload id="ruPhoto" cssclass="uploadimage form-control" runat="server"
                                culture="ar-EG" allowedfileextensions="png,jpg,jpeg,gif,JPEG" controlobjectsvisibility="all"
                                multiplefileselection="Disabled" maxfileinputscount="1" uploadedfilesrendering="BelowFileInput"
                                onclientfileuploaded="OnClientFileUploaded" onclientvalidationfailed="validationFailed"
                                onclientfileuploading="OnClientFileUploading" enableinlineprogress="false">
                            <Localization Select="اختار" Cancel="إلغاء" Remove="حذف" />
                        </telerik:radasyncupload>
                            <%-- <telerik:RadProgressManager runat="server" ID="RadProgressManager1" />--%>
                        <telerik:RadProgressArea runat="server" ID="RadProgressArea1" />
                            <asp:CustomValidator ID="Customvalidator1" runat="server" ClientValidationFunction="validateRadUpload"
                                ErrorMessage=" من فضلك ادخل صورة تخطيط العقار" ValidationGroup="SaveModel" CssClass="Validator"
                                Display="Dynamic">
                            </asp:CustomValidator>
                            <asp:CustomValidator ID="Customvalidator11" runat="server" ClientValidationFunction="validateRadUploadExtension"
                                ErrorMessage="نوع الملف غير مسموح به " ValidationGroup="SaveModel" CssClass="Validator"
                                Display="Dynamic">
                            </asp:CustomValidator>
                        </div>
                        <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12 pull-left">
                            <div id="divlogo" style="max-height: 150px; max-width: 150px; margin-top: -30px; float: left" runat="server">
                                <asp:Image ID="imgLogo" CssClass="img-thumbnail Icon" runat="server" />
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
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
            <asp:GridView ID="gvModels" runat="server" DataKeyNames="ID" AutoGenerateColumns="False"
                CellPadding="4" CssClass="table table-striped table-bordered table-hover theGridTable"
                AllowPaging="True" PageSize="20" 
                OnPageIndexChanging="gvModels_PageIndexChanging">
                <AlternatingRowStyle />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Id" Visible="false" />
                    <asp:BoundField DataField="Price" HeaderText="السعر" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-CssClass="GridColumnHeader" >
                        <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                    </asp:BoundField>
                       <asp:BoundField DataField="Area" HeaderText="المساحة" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-CssClass="GridColumnHeader" >
                        <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                    </asp:BoundField>  
                    <asp:BoundField DataField="Type" HeaderText=" نوع العقار" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-CssClass="GridColumnHeader" >
                        <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                    </asp:BoundField>
                   <asp:BoundField DataField="Title" HeaderText=" اسم النموذج" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-CssClass="GridColumnHeader" >
                        <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                    </asp:BoundField>
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
<telerik:radcodeblock id="RadScriptBlock1" runat="server">
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
    </telerik:radcodeblock>
