<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/SubScriber/SubscriberMaster.Master"
    AutoEventWireup="true" CodeBehind="RealEstatePage.aspx.cs" Inherits="BrokerWeb.Backend.SubScriber.RealEstatePage" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="../../scripts/Map.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
           $(".radioUI").buttonset();
            $(".checkGroup").buttonset();
            $('.buttonUI').button();
            loadScript();
            setTimeout(AddLocationtoMap, 3000);
        });
    </script>
    <style>
        .ruInputs {
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
            <telerik:AjaxSetting AjaxControlID="rplCategories">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="divTypes" LoadingPanelID="radLoadingPannel"
                        UpdatePanelRenderMode="Block" />
                    <telerik:AjaxUpdatedControl ControlID="divStatus" LoadingPanelID="radLoadingPannel"
                        UpdatePanelRenderMode="Block" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rplTypes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rptCrieria" LoadingPanelID="radLoadingPannel"
                        UpdatePanelRenderMode="Block" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <div class=" addPropertyWrapper">
        <div class="addProperty">
            <div class="addPropertyGroupTitle">
                <h1 runat="server" id="hTitle">إضافة جديدة</h1>
            </div>
            <div class="clear">
            </div>
            <div id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
            <div class="alert alert-warning alert-dismissable" id="divHelpMsg1" runat="server">
                قم بإضافة العقار أو الأرض التي ترغب في بيعها أو تأجيرها عن طريق ثلاثة خطوات بسيطة
                <button class="close pull-left" aria-hidden="true" data-dismiss="alert" type="button">
                    ×</button>
            </div>
            <div class="addPropertyGroup">
                <div class="addPropertyGroupTitle addPropertyGroupTitleOrange">
                    <h1>1 - تحديد النوع (ماذا تريد أن تعرض؟)</h1>
                </div>
                <div class="clear">
                </div>
                <div class="alert alert-warning alert-dismissable">
                    دقة البيانات تحسن فرصك في بيع او تأجير عقارك, فضلا تحرى الدقة في ملء البيانات التالية.
                    <button class="close pull-left" aria-hidden="true" data-dismiss="alert" type="button">
                        ×</button>
                </div>
                <div class="row labelRow">
                    <p>
                        تحديد الفئة <span class="tinyNote">مثال:إذا كنت تريد بيع شقتك فقم بإختيار وحدة سكنية</span>
                    </p>
                </div>
                <div class="row">
                    <div class="aControl">
                        <div class="aControl radioUI">
                            <asp:RadioButtonList ID="rplCategories" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rplCategories_SelectedIndexChanged"
                                RepeatLayout="Flow" RepeatDirection="Horizontal">
                            </asp:RadioButtonList>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ValidationGroup="Save"
                                CssClass="Validator" ControlToValidate="rplCategories" runat="server" Display="Dynamic"
                                ErrorMessage="من فضلك ادخل الفئة"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="addPropertyInsideGroup" id="divTypes" runat="server" style="display: none">
                    <div class="row labelRow">
                        <p>
                            نوع الوحدة السكنية <span class="tinyNote">ما هو نوع وحدتك السكنية التي ترغب في بيعها
                                أو تأجيرها؟</span>
                        </p>
                    </div>
                    <div class="row">
                        <div class="aControl">
                            <div class="aControl radioUI">
                                <asp:RadioButtonList ID="rplTypes" runat="server" AutoPostBack="True" RepeatLayout="Flow"
                                    OnSelectedIndexChanged="rplTypes_SelectedIndexChanged" RepeatDirection="Horizontal">
                                </asp:RadioButtonList>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="Save"
                                    CssClass="Validator" ControlToValidate="rplTypes" runat="server" Display="Dynamic"
                                    ErrorMessage="من فضلك ادخل النوع"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="addPropertyGroup">
                <div class="addPropertyGroupTitle addPropertyGroupTitleOrange">
                    <h1>2 - تحديد المواصفات
                    </h1>
                </div>
                <div class="clear">
                </div>
                <div class="alert alert-warning alert-dismissable">
                    .مواصفات ما ترغب في عرضه - تذكر أن الدقة في البيانات تزيد من فرصك في البيع
                    <button class="close pull-left" aria-hidden="true" data-dismiss="alert" type="button">
                        ×</button>
                </div>
                <div class="addPropertyInsideGroup">
                    <div class="row labelRow">
                        <p>
                            مساحة الوحدة <span class="tinyNote">المساحة بالمتر المربع</span>
                        </p>
                    </div>
                    <div class="row">
                        <div class="aControl">
                            <telerik:RadNumericTextBox ID="txtArea" runat="server" LabelWidth="" Width="250">
                                <NumberFormat ZeroPattern="n" AllowRounding="False" DecimalDigits="5" KeepNotRoundedValue="True"></NumberFormat>
                            </telerik:RadNumericTextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ValidationGroup="Save"
                                CssClass="Validator" ControlToValidate="txtArea" runat="server" Display="Dynamic"
                                ErrorMessage=" من فضلك ادخل مساحة العقار/الارض"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="addPropertyInsideGroup" id="divStatus" runat="server" style="display: none">
                    <div class="row labelRow">
                        <p>
                            حالة الوحدة السكنية <span class="tinyNote">قم بتوضيح حالة الوحدة السكنية التي تعرضها</span>
                        </p>
                    </div>
                    <div class="row">
                        <div class="aControl">
                            <div class="aControl radioUI">
                                <asp:RadioButtonList ID="rptStatus" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                </asp:RadioButtonList>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ValidationGroup="Save"
                                    CssClass="Validator" ControlToValidate="rptStatus" runat="server" Display="Dynamic"
                                    ErrorMessage="من فضلك ادخل الحالة"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="checkboxsHolder">
                <asp:ListView ID="rptCrieria" runat="server" DataKeyNames="ID" OnItemDataBound="rptCrieria_ItemDataBound">
                    <ItemTemplate>
                        
                            <asp:HiddenField ID="hdnValueType" Value='<%#Eval("ValueType") %>' runat="server" />
                            <div class="addPropertyInsideGroup" id="divText" runat="server">
                                <div class="row labelRow">
                                    <p>
                                        <%#Eval("Title") %>
                                        <%--<span class="tinyNote">المساحة بالمتر المربع</span>--%>
                                    </p>
                                </div>
                                <div class="row">
                                    <div class="aControl">
                                        <asp:TextBox ID="txtCriteriaValue" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="revCriteriavalue" ControlToValidate="txtCriteriaValue"
                                            runat="server" CssClass="Validator" Display="Dynamic" ValidationGroup="Save"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>

                            <div id="divCheckbox" runat="server">
                                <asp:CheckBox ID="chkCriteria" runat="server" Text='<%#Eval("Title") %>' />
                            </div>
                        
                    </ItemTemplate>
                </asp:ListView>
                    </div>
                <div class="addPropertyInsideGroup">
                    <div class="addPropertyGroupTitle addPropertyGroupTitleGrey">
                        <h1>صور الوحدة</h1>
                    </div>
                    <div class="row labelRow">
                        <p>
                            إضافة صور للوحدة <span class="tinyNote"> (إضافة الصور تحسن من فرصك في البيع)</span>
                        </p>
                    </div>
                    <div class="row">
                        <div class="aControl">
                            <!-- The fileinput-button span is used to style the file input field as button -->
                            <span class="btn btn-success fileinput-button"><i class="glyphicon glyphicon-plus"></i>
                                <span>أختار الصور</span>
                                <%--   <input type="file" name="files[]" multiple="">--%>
                            </span>
                            <br />
                            <telerik:RadAsyncUpload ID="ruPhoto" CssClass="uploadimage form-control" runat="server"
                                Culture="ar-EG" AllowedFileExtensions="png,jpg,jpeg,gif,JPEG" ControlObjectsVisibility="None"
                                MultipleFileSelection="Automatic" UploadedFilesRendering="BelowFileInput"
                                OnClientFileUploaded="OnClientFileUploaded" OnClientValidationFailed="validationFailed"
                                OnClientFileUploading="OnClientFileUploading" EnableInlineProgress="false">
                                <Localization Select="اختار" Cancel="إلغاء" Remove="حذف" />
                            </telerik:RadAsyncUpload>
                            <%--<telerik:RadProgressManager runat="server" ID="RadProgressManager1" />--%>
                            <telerik:RadProgressArea runat="server" ID="RadProgressArea1" />
                            <asp:CustomValidator ID="Customvalidator1" runat="server" ClientValidationFunction="validateRadUpload"
                                ErrorMessage=" من فضلك ادخل صورة" ValidationGroup="Save" CssClass="Validator"
                                Display="Dynamic">
                            </asp:CustomValidator>
                            <asp:CustomValidator ID="Customvalidator11" runat="server" ClientValidationFunction="validateRadUploadExtension"
                                ErrorMessage="نوع الملف غير مسموح به " ValidationGroup="Save" CssClass="Validator"
                                Display="Dynamic">
                            </asp:CustomValidator>
                        <%--    <asp:CustomValidator ID="Customvalidator5" runat="server" ClientValidationFunction="validateRadUploadFilesize"
                                ErrorMessage=" حجم الصورة يجب ان لا يزيد عن 10 ميجا" ValidationGroup="Save" CssClass="Validator"
                                Display="Dynamic">
                            </asp:CustomValidator>--%>
                            <asp:ListView ID="lvPhotos" DataKeyNames="ID" runat="server">
                                <ItemTemplate>
                                    <div class="ImageItem">
                                        <div class="DefaultTitle">
                                            <asp:Label ID="lblDefault" runat="server" Text='<%# CheckDefault(Eval("IsDefault")) %>'></asp:Label>
                                        </div>
                                        <asp:Image ID="imgPhoto" CssClass="img-responsive img-rounded thumbnail Image" ImageUrl='<%#Eval("PhotoName") %>'
                                            runat="server" />
                                        <div class="ImageControls">
                                            <asp:ImageButton ID="imgDelete" CssClass="img-responsive Deleteconfirm" ImageUrl="~/images/icons/deny.png"
                                                runat="server" OnClick="imgDelete_Click" />
                                            <asp:ImageButton ID="imgSetDefault" CssClass="img-responsive" ToolTip="تحديد كصورة رئيسية"
                                                ImageUrl="~/images/icons/approve.png" runat="server" OnClick="imgSetDefault_Click" />
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                            <%--       <button type="submit" class="btn btn-primary start">
                                <i class="glyphicon glyphicon-upload"></i><span>إرسال</span>
                            </button>
                            <button type="reset" class="btn btn-warning cancel">
                                <i class="glyphicon glyphicon-ban-circle"></i><span>إلغاء عمليه الإرسال</span>
                            </button>
                            <button type="button" class="btn btn-danger delete">
                                <i class="glyphicon glyphicon-trash"></i><span>حذف</span>
                            </button>
                            <input type="checkbox" class="toggle">
                            <!-- The global file processing state -->
                            <span class="fileupload-process"></span>--%>
                        </div>
                    </div>
                </div>
                <div class="addPropertyInsideGroupSub">
                    <div class="addPropertyGroupTitle addPropertyGroupTitleGrey">
                        <h1>العنوان</h1>
                    </div>
                    <div class="addPropertyAddressContainer">
                        <div class="addPropertyHalf addPropertyAddress">
                            <div class="addPropertyInsideGroupSubInside">
                                <div class="row labelRow">
                                    <p>
                                        البلد
                                    </p>
                                </div>
                                <div class="row">
                                    <div class="aControl">
                                        <div class="aControl">
                                            <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" onchange="onChange(5);"
                                                OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="Save" CssClass="Validator"
                                                ControlToValidate="ddlCountry" runat="server" ErrorMessage=" من فضلك ادخل البلد المتواجد به العقار/الارض"
                                                InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="addPropertyInsideGroupSubInside">
                                <div class="row labelRow">
                                    <p>
                                        المحافظة
                                    </p>
                                </div>
                                <div class="row">
                                    <div class="aControl">
                                        <div class="aControl">
                                            <asp:DropDownList ID="ddlCities" runat="server" AutoPostBack="True" onchange="onChange(10);"
                                                OnSelectedIndexChanged="ddlCities_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Save" CssClass="Validator"
                                                ControlToValidate="ddlCities" runat="server" ErrorMessage=" من فضلك ادخل المحافظة المتواجد بها العقار/الارض"
                                                InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="addPropertyInsideGroupSubInside">
                                <div class="row labelRow">
                                    <p>
                                        الحي
                                    </p>
                                </div>
                                <div class="row">
                                    <div class="aControl">
                                        <div class="aControl">
                                            <asp:DropDownList ID="ddlDistricts" onchange="onChange(12);" runat="server">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Save" CssClass="Validator"
                                                ControlToValidate="ddlDistricts" runat="server" ErrorMessage=" من فضلك ادخل الحى المتواجد به العقار/الارض"
                                                InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="addPropertyInsideGroupSubInside">
                                <div class="row labelRow">
                                    <p>
                                        العنوان المفصل
                                    </p>
                                </div>
                                <div class="row">
                                    <div class="aControl">
                                        <asp:TextBox ID="txtStreet" runat="server" onchange="onChange(15);"></asp:TextBox>
                                        <%-- <input type="text" />--%>
                                        <br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Save" CssClass="Validator"
                                            ControlToValidate="txtStreet" runat="server" Display="Dynamic" ErrorMessage=" من فضلك ادخل اسم الشارع المتواجد به العقار/الارض"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="addPropertyHalf addPropertyMap">
                            <div class="addPropertyMapCore">
                                <div id="MyMap" class="GoogleMap">
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="row labelRow" style="margin-top: 10px;">
                                <p>
                                    <span class="tinyNote">لإضافة موقع العقار أو الأرض إضغط بالزر الأيمن للفأرة.</span>
                                </p>
                            </div>
                            <div class="addPropertyInsideGroupSubInside">
                                <div class="addPropertyHalf">
                                    <div class="row labelRow">
                                        <p>
                                            دائرة العرض
                                        </p>
                                    </div>
                                    <div class="row">
                                        <div class="aControl">
                                            <asp:TextBox ID="txtLatitude" runat="server"></asp:TextBox>
                                            <%-- <input type="text" />--%>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Save" CssClass="Validator"
                                                ControlToValidate="txtLatitude" runat="server" Display="Dynamic" ErrorMessage=" من فضلك ادخل دائرة العرض او اختار الموقع على الخريطة"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="addPropertyHalf">
                                    <div class="row labelRow">
                                        <p>
                                            خط الطول
                                        </p>
                                    </div>
                                    <div class="row">
                                        <div class="aControl">
                                            <asp:TextBox ID="txtLongitude" runat="server"></asp:TextBox>
                                            <%-- <input type="text" />--%>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="Save" CssClass="Validator"
                                                ControlToValidate="txtLongitude" runat="server" Display="Dynamic" ErrorMessage=" من فضلك ادخل خط الطول او اختار الموقع على الخريطة"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="addPropertyGroup">
                <div class="addPropertyGroupTitle addPropertyGroupTitleOrange">
                    <h1>3 - بيانات الإعلان عن وحدتك
                    </h1>
                </div>
                <div class="clear">
                </div>
                <div class="alert alert-warning alert-dismissable">
                    المعلومات التالية للإعلان عن وحدتك التي حددت مواصفاتها بالأعلى.
                    <button class="close pull-left" aria-hidden="true" data-dismiss="alert" type="button">
                        ×</button>
                </div>
                <div class="addPropertyInsideGroup">
                    <div class="row labelRow">
                        <p>
                            عنوان الإعلان <span class="tinyNote">يرجى ان يكون عنوان الاعلان مختصر بكلمات يبجث بها العميل على جووجل </span>
                        </p>
                    </div>
                    <div class="row">
                        <div class="aControl">
                            <asp:TextBox ID="txtTitle" runat="server" Width="20%" Height="100px" style="text-align:right !important;"  TextMode="MultiLine" MaxLength="500" placeholder="شقة / فيلا / ارض ( نوع العقار ) للبيع / للأيجار [ تقسيط / كاش ]  بـــ ( اسم الحى ) – ( أهم المناطق بجواره )"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="Save" CssClass="Validator"
                                ControlToValidate="txtTitle" runat="server" Display="Dynamic" ErrorMessage=" من فضلك ادخل عنوان الاعلان"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="addPropertyInsideGroup">
                    <div class="row labelRow">
                        <p>
                            للبيع أم للإيجار <span class="tinyNote">هل تعرض للبيع ام للإيجار؟</span>
                        </p>
                    </div>
                    <div class="row">
                        <div class="aControl">
                            <div class="aControl radioUI">
                                <asp:RadioButtonList ID="rptSaleTypes" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                </asp:RadioButtonList>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ValidationGroup="Save"
                                    CssClass="Validator" ControlToValidate="rptSaleTypes" runat="server" Display="Dynamic"
                                    ErrorMessage="من فضلك ادخل نوع العرض"></asp:RequiredFieldValidator>
                                <%--       <input type="radio" id="Radio1" name="saleType" /><label for="Radio1">بيع كاش</label>
                                    <input type="radio" id="Radio15" name="saleType" /><label for="Radio15">بيع بالتقسيط</label>
                                    <input type="radio" id="Radio16" name="saleType" /><label for="Radio16">للإيجار</label>--%>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="addPropertyInsideGroup">
                    <div class="row labelRow">
                        <p>
                            طريقة الدفع<span class="tinyNote">هل يتم الدفع كاش ام بالتقسيط؟</span>
                        </p>
                    </div>
                    <div class="row">
                        <div class="aControl">
                            <div class="aControl radioUI">
                                <asp:RadioButtonList ID="rptPaymentTypes" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                </asp:RadioButtonList>
                                <%--       <input type="radio" id="Radio1" name="saleType" /><label for="Radio1">بيع كاش</label>
                                    <input type="radio" id="Radio15" name="saleType" /><label for="Radio15">بيع بالتقسيط</label>
                                    <input type="radio" id="Radio16" name="saleType" /><label for="Radio16">للإيجار</label>--%>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="addPropertyInsideGroup">
                    <div class="row labelRow">
                        <p>
                            السعر <span class="tinyNote">ما هو السعر الاجمالى التقديري للبيع؟</span>
                        </p>
                    </div>
                    <div class="row">
                        <div class="aControl">
                            <telerik:RadNumericTextBox ID="txtPrice" runat="server" LabelWidth="" Width="250">
                                <NumberFormat ZeroPattern="n" AllowRounding="False" DecimalDigits="5" KeepNotRoundedValue="True"></NumberFormat>
                            </telerik:RadNumericTextBox>
                        </div>
                    </div>
                </div>
                <div class="addPropertyInsideGroup">
                    <div class="row labelRow">
                        <p>
                            عملة الدفع <span class="tinyNote">ما هي العملة التي ترغب في البيع بها؟</span>
                        </p>
                    </div>
                    <div class="row">
                        <div class="aControl">
                            <div class="aControl radioUI">
                                <asp:RadioButtonList ID="rptCurrency" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                </asp:RadioButtonList>
                                <%--            <input type="radio" id="Radio22" name="currency" /><label for="Radio22">الجنية</label>
                                    <input type="radio" id="Radio23" name="currency" /><label for="Radio23">الدولار</label>
                                    <input type="radio" id="Radio24" name="currency" /><label for="Radio24">اليورو</label>--%>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="addPropertyInsideGroup">
                    <div class="row labelRow">
                        <p>
                            وصف الإعلان <span class="tinyNote">أكتب وصف كامل للعقار ومميزاته ومميزات موقعه والخدمات
                                المتاحة والقريبة منه مثل المدارس والمستشفيات وخلافه - 500 حرف.</span>
                        </p>
                    </div>
                    <div class="row">
                        <div class="aControl">
                            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
                            <br />
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="Save" CssClass="Validator"
                                ControlToValidate="txtDescription" runat="server" Display="Dynamic" ErrorMessage=" من فضلك ادخل وصف العقار/الارض"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="addPropertyInsideGroup">
                    <%-- <div class="row labelRow">
                        <p>
                            <%#Eval("Title") %><span class="tinyNote">قم بتوضيح حالة الوحدة السكنية التي تعرضها</span</p>
                    </div>>--%>
                    <div class="row">
                        <div class="aControl">
                            <div class="aControl radioUI">
                                <%--  <input type="radio" id="chkCriteria" name="state" runat="server" /><label for="Radio2"></label>--%>
                                <%--  <asp:CheckBox ID="chkContactData" runat="server" Text="استخدم بيانات الاتصال الخاصة بى"
                                    Checked="true" />--%>
                                <asp:RadioButtonList ID="rptContactData" onchange="ChangeContactVisible();" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="استخدم بيانات الاتصال الخاصة بى" Value="0" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="إدخال بيانات أخرى" Value="1" Selected="False"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="addPropertyInsideGroupSubInside" runat="server" id="divContactName" style="display: none">
                    <div class="row labelRow">
                        <p>
                            اسم جهة الاتصال
                        </p>
                    </div>
                    <div class="row">
                        <div class="aControl">
                            <asp:TextBox ID="txtOwnerName" runat="server"></asp:TextBox>
                            <br />
                            <asp:CustomValidator ID="CustomValidator6" runat="server" ClientValidationFunction="validateOwnerNameText"
                                ErrorMessage=" من فضلك ادخل اسم جهة الاتصال" ValidationGroup="Save" CssClass="Validator"
                                Display="Dynamic"></asp:CustomValidator>

                            <%--                            <asp:CustomValidator ID="Customvalidator2" runat="server" ClientValidationFunction="validateOwnerNameText"
                                ErrorMessage=" من فضلك ادخل اسم جهة الاتصال" ValidationGroup="Save" CssClass="Validator"
                                Display="Dynamic">
                            </asp:CustomValidator>--%>
                        </div>
                    </div>
                </div>
                <div class="addPropertyInsideGroupSubInside" runat="server" id="divContactEmail"
                    style="display: none">
                    <div class="row labelRow">
                        <p>
                            البريد الالكترونى لجهة الاتصال
                        </p>
                    </div>
                    <div class="row">
                        <div class="aControl">
                            <asp:TextBox ID="txtOwnerEmail" runat="server"></asp:TextBox>
                            <br />
                            <asp:CustomValidator ID="Customvalidator4" runat="server" ClientValidationFunction="validateOwnerEmailText"
                                ErrorMessage=" من فضلك ادخل البريد الالكترونى" ValidationGroup="Save" CssClass="Validator"
                                Display="Dynamic"></asp:CustomValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage=" البريد الالكترونى غير صحيح"
                                ControlToValidate="txtOwnerEmail" ValidationGroup="Save" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                CssClass="Validator" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>
                <div class="addPropertyInsideGroupSubInside" runat="server" id="divContactPhone"
                    style="display: none">
                    <div class="row labelRow">
                        <p>
                            رقم هاتف جهة الاتصال
                        </p>
                    </div>
                    <div class="row">
                        <div class="aControl">
                            <asp:TextBox ID="txtOwnerPhone" runat="server"></asp:TextBox>
                            <div class="clear"></div>
                            <asp:Label ID="Label25" runat="server" Text="يجب الفصل بين الارقام بواسطة(-)" CssClass="Note"></asp:Label>
                            <br />
                            <asp:CustomValidator ID="Customvalidator3" runat="server" ClientValidationFunction="validateOwnerPhoneText"
                                ErrorMessage=" من فضلك ادخل رقم الهاتف" ValidationGroup="Save" CssClass="Validator"
                                Display="Dynamic">
                            </asp:CustomValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage=" رقم الهاتف غير صحيح"
                                ControlToValidate="txtOwnerPhone" ValidationGroup="Save" ValidationExpression="([0-9]+\-?)*[0-9]+"
                                CssClass="Validator" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>
                <div class="addPropertyInsideGroup" id="divCheckbox" runat="server">
                    <%-- <div class="row labelRow">
                        <p>
                            <%#Eval("Title") %><span class="tinyNote">قم بتوضيح حالة الوحدة السكنية التي تعرضها</span</p>
                    </div>>--%>
                    <div class="row">
                        <div class="aControl">
                            <div class="aControl radioUI">

                                <%--  <input type="radio" id="chkCriteria" name="state" runat="server" /><label for="Radio2"></label>--%>
                                <%--<asp:CheckBox ID="chkIsSold" runat="server" Text="تم بيع/تأجير العقار" />--%>
                                <asp:RadioButtonList ID="rptIsSold" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="العقار لم يباع بعد" Value="0" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="تم بيع/تأجير العقار" Value="1" Selected="False"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="addPropertyButtonContainer">
                <%--      <button class="btn btn-success fileinput-button addPropertyButton">
                    <i class="glyphicon glyphicon-ok-sign"></i><span>إضافة الوحدة</span>
                </button>--%>
                <asp:LinkButton ID="lbtnSave" runat="server" ValidationGroup="Save" class="btn btn-success fileinput-button addPropertyButton"
                    OnClick="lbtnSave_Click"> 
                  <i class="glyphicon glyphicon-ok-sign"></i><span>إضافة الوحدة</span></asp:LinkButton>
            </div>
        </div>
    </div>
    <telerik:RadCodeBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">

            function validateOwnerNameText(source, e) {
                e.IsValid = false;
                var chkval = $("#<%= rptContactData.ClientID %> input:checked").val();
                if (chkval == 0) {
                    //    alert("test");
                    e.IsValid = true;
                }
                else {
                    var str = $("#<%= txtOwnerName.ClientID %>").val();
                    if (str != "" && str != null) {
                        e.IsValid = true;
                    }
                }
            }

            function validateOwnerEmailText(source, e) {
                e.IsValid = false;
                var chkval = $("#<%= rptContactData.ClientID %> input:checked").val();
                if (chkval == 0) {
                    //    alert("test");
                    e.IsValid = true;
                }
                else {
                    var str = $("#<%= txtOwnerEmail.ClientID %>").val();
                    if (str != "" && str != null) {
                        e.IsValid = true;
                    }
                }
            }
            function validateOwnerPhoneText(source, e) {
                //   alert('tt');
                e.IsValid = false;
                var chkval = $("#<%= rptContactData.ClientID %> input:checked").val();
                if (chkval == 0) {
                    //   alert("test");
                    e.IsValid = true;
                }
                else {
                    var str = $("#<%= txtOwnerPhone.ClientID %>").val();
                    if (str != "" && str != null) {
                        e.IsValid = true;
                    }
                }
            }
            function ChangeContactVisible() {
                var chkval = $("#<%= rptContactData.ClientID %> input:checked").val();
                if (chkval == 0) {
                    $("#<%=divContactPhone.ClientID%>").css("display", "none");
                    $("#<%=divContactEmail.ClientID%>").css("display", "none");
                    $("#<%=divContactName.ClientID%>").css("display", "none");
                }
                else {
                    $("#<%=divContactPhone.ClientID%>").css("display", "block");
                    $("#<%=divContactEmail.ClientID%>").css("display", "block");
                    $("#<%=divContactName.ClientID%>").css("display", "block");
                }
            }
            function onChange(zoom) {
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
                            var str = $("#<%= txtStreet.ClientID %>").val();
                            if (str != "" && str != null) {
                                Address += " , " + str;
                            }

                        }
                    }
                    ShowAddress(Address, zoom);
                }
            }
            function SetLatLongControls(lat, lng) {
                $("#<%= txtLatitude.ClientID %>").val(lat);
                $("#<%= txtLongitude.ClientID %>").val(lng);
                //  alert(lat+", "+lng);
            }
            function AddLocationtoMap() {
                var lat = $("#<%= txtLatitude.ClientID %>").val();

                if (lat != "" && lat != null) {
                    var lng = $("#<%= txtLongitude.ClientID %>").val();
                    if (lng != "" && lng != null) {
                        //  alert(lat+","+lng);
                        AddLocationToMap(lat, lng);
                    }
                }
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
                $("#<%=lbtnSave.ClientID %>").prop('disabled', true);
                // alert($("#<%=lblMsg.ClientID %>").val()); //.hide()//.text("جارى تحميل الصورة....");
            }
            function OnClientFileUploaded(sender, args) {

                $("#divImgLoading").hide();
                $("#<%=lbtnSave.ClientID %>").prop('disabled', false);
            }
        </script>
    </telerik:RadCodeBlock>
</asp:Content>
