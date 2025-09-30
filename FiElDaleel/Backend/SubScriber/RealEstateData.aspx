<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/SubScriber/SubscriberMaster.Master"
    AutoEventWireup="true" CodeBehind="RealEstateData.aspx.cs" Inherits="BrokerWeb.Backend.SubScriber.RealEstateData" %>

<%@ Register src="UserControls/ucRealEstatePhotos.ascx" tagname="ucRealEstatePhotos" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../scripts/Map.js" type="text/javascript"></script>
    <link href="../../styles/imgloading.css" rel="stylesheet" type="text/css" />
    <style>
        
        .row{
            padding: 0;
            margin: 0;
        }
        
.ruInputs
{
    width: 300px !important;
    height: 200px !important;
    overflow: auto !important;
}

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
                    <telerik:AjaxSetting AjaxControlID="ddlCategory">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlType" LoadingPanelID="radLoadingPannel"
                        UpdatePanelRenderMode="Block" />
                    <telerik:AjaxUpdatedControl ControlID="ddlStatus" LoadingPanelID="radLoadingPannel"
                        UpdatePanelRenderMode="Block" />
                </UpdatedControls>
            </telerik:AjaxSetting>
                 <telerik:AjaxSetting AjaxControlID="ddlType">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rptCrieria" LoadingPanelID="radLoadingPannel"
                        UpdatePanelRenderMode="Block" />
                </UpdatedControls>
            </telerik:AjaxSetting>
              
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <div class="row">
        <telerik:RadTabStrip ID="rtsAddRealEstate" MultiPageID="rmpAddBusiness" AutoPostBack="True"
            Align="Justify" runat="server" SelectedIndex="0" CssClass="WizardTabs"
            Skin="Simple" ontabclick="rtsAddRealEstate_TabClick">
            <Tabs>
                <telerik:RadTab PageViewID="rpvMainData">
                    <TabTemplate>
                        <div class="WizardTab">
                            <img src="../images/icons/backend/basic.png" />
                            <asp:Label ID="Label1" runat="server" Text="<span>بيانات الاعلان </span><span>أساسية</span>"></asp:Label>
                        </div>
                    </TabTemplate>
                </telerik:RadTab>
                <telerik:RadTab PageViewID="rpvAddressData">
                    <TabTemplate>
                        <div class="WizardTab">
                            <img src="../images/icons/backend/address.png" />
                            <asp:Label ID="Label1" runat="server" Text="العنوان"></asp:Label>
                        </div>
                    </TabTemplate>
                </telerik:RadTab>
                <telerik:RadTab PageViewID="rpvAdvData" Selected="True">
                    <TabTemplate>
                        <div class="WizardTab">
                            <img src="../images/icons/backend/extra.png" />
                            <asp:Label ID="Label1" runat="server" Text="<span>بيانات العقار</span><span>إضافية</span>"></asp:Label>
                        </div>
                    </TabTemplate>
                </telerik:RadTab>
                <telerik:RadTab PageViewID="rpvPhotos" Selected="True">
                    <TabTemplate>
                        <div class="WizardTab">
                            <img src="../images/icons/backend/images.png" />
                            <asp:Label ID="Label1" runat="server" Text="الصور"></asp:Label>
                        </div>
                    </TabTemplate>
                </telerik:RadTab>
               
                  <telerik:RadTab>
                        <TabTemplate>
                            <div class="WizardTab">
                                <img src="../images/icons/backend/view.png" />
                                <asp:Label ID="Label1" runat="server" Text="معاينة "></asp:Label>
                            </div>
                        </TabTemplate>
                    </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <div class="WizardContent">
            <div id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
            <telerik:RadMultiPage ID="rmpAddBusiness" runat="server" RenderSelectedPageOnly="true"
                SelectedIndex="0">
                <telerik:RadPageView CssClass="WizardPageView" ID="rpvMainData" runat="server">
                    <div class="Header">
                        <h1>
                          تفاصيل الاعلان
                   
                        </h1>
                               <div class="alert alert-warning alert-dismissable">
                        دقة البيانات تحسن فرصك في بيع او تأجير عقارك, فضلا تحرى الدقة في ملء البيانات التالية.
                        <button class="close pull-left" aria-hidden="true" data-dismiss="alert" type="button">×</button>
                    </div>
                        <div id="div1" runat="server">
                            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="Content row nopadding">
                        <div class=" pull-right">
                            <div class="ContentItem row">
                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                    <asp:Label ID="Label9" runat="server" Text="عنوان الاعلان *" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" placeholder="مثال:شقة 150 م فى التجمع فى شارع 90 تبعد 20 دقيقة عن الدائرى"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="Save" CssClass="Validator"
                                        ControlToValidate="txtTitle" runat="server" Display="Dynamic" ErrorMessage="! من فضلك ادخل عنوان الاعلان"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="ContentItem row">
                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                    <asp:Label ID="Label16" runat="server" Text="العقار/الارض معروض * " CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                    <asp:RadioButtonList ID="rbsSalesTypes" RepeatDirection="Horizontal" runat="server">
                                    </asp:RadioButtonList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ValidationGroup="Save"
                                        CssClass="Validator" ControlToValidate="rbsSalesTypes" runat="server" Display="Dynamic"
                                        ErrorMessage="! من فضلك اختار نوع العرض"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="ContentItem row">
                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                    <asp:Label ID="Label5" runat="server" Text="وصف العقار/الارض * " CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine"
                                        MaxLength="500" placeholder=" أكتب وصف كامل للعقار ومميزاته ومميزات موقعه والخدمات المتاحة والقريبة منه مثل المدارس والمستشفيات وخلافه."></asp:TextBox>
                                    <asp:Label ID="Label12" runat="server" Text="عدد الاحرف يجب ان لا يزيد عن 500 حرف"
                                        CssClass="Note"></asp:Label>
                                    <br /><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="Save" CssClass="Validator"
                                        ControlToValidate="txtDescription" runat="server" Display="Dynamic" ErrorMessage="! من فضلك ادخل وصف العقار/الارض"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="ContentItem row">
                                <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                                    <asp:Label ID="Label1" runat="server" Text="الفئة *" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Save" CssClass="Validator"
                                        ControlToValidate="ddlCategory" runat="server" ErrorMessage=" من فضلك ادخل الفئة"
                                        InitialValue="0"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="ContentItem row">
                                <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                                    <asp:Label ID="Label14" runat="server" Text="النوع *" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                                    <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control" 
                                        AutoPostBack="True" onselectedindexchanged="ddlType_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="Save" CssClass="Validator"
                                        ControlToValidate="ddlType" runat="server" ErrorMessage="! من فضلك ادخل النوع"
                                        InitialValue="0"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="ContentItem row">
                                <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                                    <asp:Label ID="Label15" runat="server" Text="الحالة *" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ValidationGroup="Save"
                                        CssClass="Validator" ControlToValidate="ddlStatus" runat="server" ErrorMessage="! من فضلك ادخل الحالة"
                                        InitialValue="0"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                   <%--         <div class="ContentItem row">
                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                    <asp:Label ID="Label6" runat="server" Text=" كلمات دالة  *" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12" style="position:relative;">
                                    <telerik:RadAutoCompleteBox ID="txtKeywords" runat="server" CssClass="form-control autoCompleteDrop"
                                        DropDownPosition="Static" AllowCustomEntry="True" Filter="StartsWith" Width="100%"
                                        Delimiter="," DropDownWidth="100%" Culture="ar-EG">
                                    </telerik:RadAutoCompleteBox>
                                    <asp:Label ID="Label11" runat="server" Text="يجب الفصل بين الكلمات بواسطة(,)" CssClass="Note"></asp:Label>
                                    <br /> <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="Save" CssClass="Validator"
                                        ControlToValidate="txtKeywords" runat="server" Display="Dynamic" ErrorMessage="! من فضلك ادخل كلمات دالة على العقار/الارض"></asp:RequiredFieldValidator>
                                </div>
                            </div>--%>
                          
                                 <div class="ContentItem row">
                                <asp:CheckBox ID="chkContactData" Text="استخدم بيانات الاتصال الخاصة بى" CssClass="Check" Checked="true" onclick="ChangeContactVisible(this);"
                                    runat="server" />
                            </div>
                            <div class="ContentItem row" runat="server" id="divContactName" style="display:none">
                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                    <asp:Label ID="Label22" runat="server" Text="اسم جهة الاتصال*" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                    <asp:TextBox ID="txtOwnerName" runat="server" CssClass="form-control"></asp:TextBox>
                                 
                                                   <asp:CustomValidator ID="Customvalidator2" runat="server" ClientValidationFunction="validateOwnerNameText"
                        ErrorMessage="! من فضلك ادخل اسم جهة الاتصال" ValidationGroup="Save" CssClass="Validator"
                        Display="Dynamic">
                    </asp:CustomValidator>
                                </div>
                            </div>
                            <div class="ContentItem row" runat="server" id="divContactEmail" style="display:none">
                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                    <asp:Label ID="Label23" runat="server" Text="البريد الالكترونى لجهة الاتصال *" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                    <asp:TextBox ID="txtOwnerEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                    
                                                   <asp:CustomValidator ID="Customvalidator4" runat="server" ClientValidationFunction="validateOwnerEmailText"
                        ErrorMessage="! من فضلك ادخل البريد الالكترونى" ValidationGroup="Save" CssClass="Validator"
                        Display="Dynamic"></asp:CustomValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="! البريد الالكترونى غير صحيح"
                                        ControlToValidate="txtOwnerEmail" ValidationGroup="Save" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        CssClass="Validator" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="ContentItem row" id="divContactPhone" runat="server" style="display:none">
                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                    <asp:Label ID="Label24" runat="server" Text="رقم هاتف جهة الاتصال*" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                    <asp:TextBox ID="txtOwnerPhone" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="Label25" runat="server" Text="يجب الفصل بين الارقام بواسطة(-)" CssClass="Note"></asp:Label>
                                    <br />
                                   
                                                   <asp:CustomValidator ID="Customvalidator3" runat="server" ClientValidationFunction="validateOwnerPhoneText"
                        ErrorMessage="! من فضلك ادخل رقم الهاتف" ValidationGroup="Save" CssClass="Validator"
                        Display="Dynamic">
                    </asp:CustomValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="! رقم الهاتف غير صحيح"
                                        ControlToValidate="txtOwnerPhone" ValidationGroup="Save" ValidationExpression="([0-9]+\-?)*[0-9]+"
                                        CssClass="Validator" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="ContentItem row">
                                <asp:CheckBox ID="chkIsSold" Text="تم بيع/تأجير العقار" CssClass="Check" Checked="false"
                                    runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="ContentItem">
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg btn-primary pull-left" style="margin-left: 10px;" Text="حفظ" ValidationGroup="Save"
                                OnClick="btnSave_Click" />
                        </div>
                    </div>
                </telerik:RadPageView>
                <telerik:RadPageView CssClass="WizardPageView" ID="rpvAddressData" runat="server">
                    <div class="Header">
                        <h1>
                            عنوان العقار/ الارض
                        </h1>
                        <div id="div4" runat="server">
                            <asp:Label ID="Label26" runat="server" Text=""></asp:Label>
                            
                        </div>
                    </div>
                    <div class="Content row">
                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 pull-right">
                            <div id="divControls" class="row" runat="server">
                                <div class="ContentItem row">
                                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                                        <asp:Label ID="Label013" runat="server" Text="البلد *" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                                        <asp:DropDownList ID="ddlCountries" runat="server" CssClass="form-control" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlCountries_SelectedIndexChanged" onchange="onChange(5);">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="SaveAddress"
                                            CssClass="Validator" ControlToValidate="ddlCountries" runat="server" ErrorMessage=" من فضلك ادخل البلد المتواجد به العقار/الارض!"
                                            InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="ContentItem row">
                                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                                        <asp:Label ID="Label4" runat="server" Text="المحافظة *" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                                        <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" onchange="onChange(10);">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="SaveAddress"
                                            CssClass="Validator" ControlToValidate="ddlCity" runat="server" ErrorMessage="! من فضلك ادخل المحافظة المتواجد بها العقار/الارض"
                                            InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="ContentItem row">
                                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                                        <asp:Label ID="Label13" runat="server" Text="الحى *" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control" onchange="onChange(12);">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="SaveAddress"
                                            CssClass="Validator" ControlToValidate="ddlDistrict" runat="server" ErrorMessage="! من فضلك ادخل الحى المتواجد به العقار/الارض"
                                            InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="ContentItem row">
                                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                                        <asp:Label ID="Label3" runat="server" Text="اسم الشارع *" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                                        <asp:TextBox ID="txtStreet" runat="server" CssClass="form-control" onchange="onChange(15);"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="SaveAddress"
                                            CssClass="Validator" ControlToValidate="txtStreet" runat="server" Display="Dynamic"
                                            ErrorMessage="! من فضلك ادخل اسم الشارع المتواجد به العقار/الارض"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="ContentItem row">
                                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                                        <asp:Label ID="Label7" runat="server" Text="دائرة العرض" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                                        <%-- <asp:TextBox ID="txtLatitude" runat="server" CssClass="form-control" onchange="AddLocationtoMap();"></asp:TextBox>--%>
                                        <telerik:RadNumericTextBox ID="txtLatitude" runat="server" CssClass="form-control"
                                            LabelWidth="" Width="100%" onchange="AddLocationtoMap();">
                                            <NumberFormat ZeroPattern="n" AllowRounding="False" DecimalDigits="15" KeepNotRoundedValue="True">
                                            </NumberFormat>
                                        </telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                <div class="ContentItem row">
                                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                                        <asp:Label ID="Label8" runat="server" Text="خط الطول" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                                        <%--<asp:TextBox ID="txtLongitude" runat="server" CssClass="form-control" onchange="AddLocationtoMap();"></asp:TextBox>--%>
                                        <telerik:RadNumericTextBox ID="txtLongitude" runat="server" CssClass="form-control"
                                            LabelWidth="" Width="100%" onchange="AddLocationtoMap();">
                                            <NumberFormat ZeroPattern="n" AllowRounding="False" DecimalDigits="15" KeepNotRoundedValue="True">
                                            </NumberFormat>
                                        </telerik:RadNumericTextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="ContentItem">
                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-lg btn-primary" Text="حفظ" ValidationGroup="SaveAddress"
                                    OnClick="btnSave_Click" />
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 pull-right">
                            <asp:Label ID="Label10" runat="server" Font-Size="16px" Text="لاضافة موقع العقار/الارض انقر بالزر الايمن للفأرة"
                                CssClass="Note"></asp:Label>
                            <div id="MyMap" class="GoogleMap">
                            </div>
                        </div>
                    </div>
                </telerik:RadPageView>
                <telerik:RadPageView ID="rpvAdvData" CssClass="WizardPageView" runat="server">
                    <div class="Header">
                        <h1>
                           بيانات هامة للعقار
                        </h1>
                        <div class="alert alert-warning alert-dismissable">
                        .مواصفات ما ترغب في عرضه - تذكر أن الدقة في البيانات تزيد من فرصك في البيع
                        <button class="close pull-left" aria-hidden="true" data-dismiss="alert" type="button">×</button>
                    </div>
                        <div id="div2" runat="server">
                            <asp:Label ID="Label17" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="Content">
                        <div id="div3" class="row">
                            <div class="pull-right">
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
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ValidationGroup="SaveAdditionalData" CssClass="Validator"
                                        ControlToValidate="txtArea" runat="server" Display="Dynamic" ErrorMessage="! من فضلك ادخل مساحة العقار/الارض"></asp:RequiredFieldValidator>
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
                                       <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ValidationGroup="SaveAdditionalData" CssClass="Validator"
                                        ControlToValidate="txtPrice" runat="server" Display="Dynamic" ErrorMessage="! من فضلك ادخل سعر العقار/الارض"></asp:RequiredFieldValidator>
                                    --%>
                                    </div>
                                </div>
                                <div class="ContentItem row">
                                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                                        <asp:Label ID="Label20" runat="server" Text="طريقة الدفع" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                                        <asp:DropDownList ID="ddlPaymentType" runat="server" CssClass="form-control" >
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="ContentItem row">
                                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                                        <asp:Label ID="Label21" runat="server" Text="العملة" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                                        <asp:DropDownList ID="ddlCurrency" runat="server" CssClass="form-control" >
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <asp:ListView ID="rptCrieria" runat="server" DataKeyNames="ID" onitemdatabound="rptCrieria_ItemDataBound">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnValueType" Value='<%#Eval("ValueType") %>' runat="server" />
                                        <div class="ContentItem row" ID="divText" runat="server">
                                            <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                                                <asp:Label ID="lblCriteriaTitle" runat="server" Text='<%#Eval("Title") %>' CssClass="control-label"></asp:Label>
                                            </div>
                                            <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                                                <asp:TextBox ID="txtCriteriaValue" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="revCriteriavalue" ControlToValidate="txtCriteriaValue"
                                                    runat="server"  CssClass="Validator" Display="Dynamic"  ValidationGroup="SaveAdditionalData"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                        <div class="ContentItem row" id="divCheckbox" runat="server" style="display:inline;position:inherit">
                                            <asp:CheckBox ID="chkCriteria" Text='<%#Eval("Title") %>' CssClass="Check" Checked="false" runat="server" />
                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>
                            </div>
                        </div>
                             <div class="ContentItem">
                            <asp:Button ID="Button2" runat="server" CssClass="btn btn-lg btn-primary" Text="حفظ" ValidationGroup="SaveAdditionalData"
                                OnClick="btnSave_Click" />
                        </div>
                    </div>
                </telerik:RadPageView>
                <telerik:RadPageView ID="rpvPhotos" CssClass="WizardPageView" runat="server">
                <uc1:ucRealEstatePhotos ID="ucRealEstatePhotos1" runat="server" />
                </telerik:RadPageView>
            </telerik:RadMultiPage>
        </div>
    </div>
    <telerik:RadCodeBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            
            function validateOwnerNameText(source, e) {
                e.IsValid = false;
                var IsChecked = $("#<%= chkContactData.ClientID %>").prop('checked');
                if (IsChecked) {
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
                var IsChecked = $("#<%= chkContactData.ClientID %>").prop('checked');
                if (IsChecked) {
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
                e.IsValid = false;
                var IsChecked = $("#<%= chkContactData.ClientID %>").prop('checked');
                if (IsChecked) {
                    //    alert("test");
                    e.IsValid = true;
                }
                else {
                    var str = $("#<%= txtOwnerPhone.ClientID %>").val();
                    if (str != "" && str != null) {
                        e.IsValid = true;
                    }
                }
            }
            function ChangeContactVisible(control) {
                if (control.checked) {
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
      
            //  window.onload = loadScript;
            $(window).load(function () {
                loadScript();
                setTimeout(AddLocationtoMap, 3000);
                //AddLocationtoMap();
            
            });
     
            //        $(document).ready(function () {
            //            AddLocationtoMap();
            //        });
            function onChange(zoom) {
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
                $find("<%= txtLatitude.ClientID %>").set_value(lat);
                $find("<%= txtLongitude.ClientID %>").set_value(lng);
                //  alert(lat+", "+lng);
            }
            function AddLocationtoMap() {
                var lat = $find("<%= txtLatitude.ClientID %>").get_value();

                if (lat != "" && lat != null) {
                    var lng = $find("<%= txtLongitude.ClientID %>").get_value();
                    if (lng != "" && lng != null) {
                        //  alert(lat+","+lng);
                        AddLocationToMap(lat, lng);
                    }
                }
            }

    
        </script>
    </telerik:RadCodeBlock>
</asp:Content>
