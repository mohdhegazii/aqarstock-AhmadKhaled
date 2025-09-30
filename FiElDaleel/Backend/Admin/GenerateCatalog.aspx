<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="GenerateCatalog.aspx.cs" Inherits="BrokerWeb.Backend.Admin.GenerateCatalog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .row {
            margin: 0;
            padding: 0;
            margin-bottom: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h4>إنشاء كتالوجات</h4>
        </div>
        <div class="panel-body">
            <div id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
            <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                <div id="pnlData" class="panel panel-primary">
                    <div class="panel-heading" role="button" data-toggle="collapse" href="#divData" aria-expanded="false" aria-controls="divData">
                        بيانات الكتالوجات
                         <%--     <a class="btn btn-primary" role="button" data-toggle="collapse" href="#divData" aria-expanded="false" aria-controls="divData">
                        بيانات الكتالوج    
                        </a>--%>
                    </div>
                    <div id="divData" class="panel-body">
                        <div class="ContentItem row">
                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                <asp:Label ID="Label1" runat="server" CssClass="control-label" Text="اسم الفئة"></asp:Label>
                            </div>
                            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                <asp:DropDownList ID="ddlCategories" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCategories" CssClass="Validator" Display="Dynamic" ErrorMessage="الرجاء اختيار الفئة" InitialValue="0" ValidationGroup="Save"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="ContentItem row">
                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                <asp:Label ID="Label5" runat="server" Text="أسماء الكتالوجات" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                <asp:TextBox ID="txtCatalogs" runat="server" CssClass="form-control" Style="min-height: 60px;"
                                    TextMode="MultiLine" MaxLength="2000" placeholder=" أكتب أسماء الكتالوجات"></asp:TextBox>
                                <asp:Label ID="Label12" runat="server" Style="width: 100%; background-color: transparent;"
                                    Text="يرجى كتابة اسم كل كتالوج في سطر منفصل" CssClass="Note"></asp:Label>
                                <br />
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="Save" CssClass="Validator"
                                    ControlToValidate="txtCatalogs" runat="server" Display="Dynamic" ErrorMessage="! من فضلك ادخل أسماء الكتالوجات"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <%--                     <div class="ContentItem row">
                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                <asp:Label ID="Label13" runat="server" Text="وصف الكتالوجات" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control" Style="min-height: 60px;"
                                    TextMode="MultiLine" MaxLength="2000" placeholder=" أكتب وصف الكتالوجات"></asp:TextBox>
                                
                                <br />
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ValidationGroup="Save" CssClass="Validator"
                                    ControlToValidate="txtDesc" runat="server" Display="Dynamic" ErrorMessage="! من فضلك ادخل وصف الكتالوجات"></asp:RequiredFieldValidator>
                            </div>
                        </div>--%>
                    </div>
                </div>
                <div id="pnlContentData" class="panel panel-primary">
                    <div class="panel-heading" role="button" data-toggle="collapse" href="#divData" aria-expanded="false" aria-controls="divData">
                        مواصفات المحتوى
                         <%--     <a class="btn btn-primary" role="button" data-toggle="collapse" href="#divData" aria-expanded="false" aria-controls="divData">
                        بيانات الكتالوج    
                        </a>--%>
                    </div>
                    <div id="divData" class="panel-body">
                        <%--         <div class="ContentItem row">
                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                <asp:Label ID="Label4" runat="server" CssClass="control-label" Text="فئة المحتوى"></asp:Label>
                            </div>
                            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                <asp:DropDownList ID="ddlTagCategories" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlTagCategories" CssClass="Validator" Display="Dynamic" ErrorMessage="!" InitialValue="0" ValidationGroup="Save"></asp:RequiredFieldValidator>
                            </div>
                        </div>--%>
                        <div class="ContentItem row">
                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                <asp:Label ID="Label3" runat="server" Text="عدد كلمات المحتوى * " CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                <telerik:RadNumericTextBox ID="txtTagsNo" runat="server" CssClass="form-control" LabelWidth="" Width="250">
                                    <NumberFormat ZeroPattern="n" AllowRounding="False" DecimalDigits="5" KeepNotRoundedValue="True"></NumberFormat>
                                </telerik:RadNumericTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Save"
                                    CssClass="Validator" ControlToValidate="txtTagsNo" runat="server" Display="Dynamic"
                                    ErrorMessage=" من فضلك ادخل عدد كلمات المحتوى"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="ContentItem row">
                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                <asp:Label ID="Label6" runat="server" Text="عدد الفقرات * " CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                <telerik:RadNumericTextBox ID="txtParagraphNo" runat="server" CssClass="form-control" LabelWidth="" Width="250">
                                    <NumberFormat ZeroPattern="n" AllowRounding="False" DecimalDigits="5" KeepNotRoundedValue="True"></NumberFormat>
                                </telerik:RadNumericTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Save"
                                    CssClass="Validator" ControlToValidate="txtParagraphNo" runat="server" Display="Dynamic"
                                    ErrorMessage=" من فضلك ادخل عدد الفقرات"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="ContentItem row">
                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                <asp:Label ID="Label7" runat="server" Text="عدد التكرار * " CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                <telerik:RadNumericTextBox ID="txtOccuranceNo" runat="server" CssClass="form-control" LabelWidth="" Width="250">
                                    <NumberFormat ZeroPattern="n" AllowRounding="False" DecimalDigits="5" KeepNotRoundedValue="True"></NumberFormat>
                                </telerik:RadNumericTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="Save"
                                    CssClass="Validator" ControlToValidate="txtOccuranceNo" runat="server" Display="Dynamic"
                                    ErrorMessage=" من فضلك ادخل عدد التكرار"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="ContentItem row">
                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                <asp:Label ID="Label2" runat="server" Text="عناوين الفقرات * " CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                <asp:TextBox ID="txtHeaders" runat="server" CssClass="form-control" Style="min-height: 60px;"
                                    TextMode="MultiLine" MaxLength="2000" placeholder=" أكتب عناوين الفقرات"></asp:TextBox>
                                <asp:Label ID="Label8" runat="server" Style="width: 100%; background-color: transparent;"
                                    Text="يرجى كتابة  كل عنوان في سطر منفصل" CssClass="Note"></asp:Label>

                            </div>
                        </div>
                        <%--    <div class="ContentItem row">
                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                <asp:Label ID="Label9" runat="server" CssClass="control-label" Text="الكلمة الرئيسية"></asp:Label>
                            </div>
                            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                <asp:TextBox ID="txtKeywordText" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtKeywordText" CssClass="Validator" Display="Dynamic" ErrorMessage="!" ValidationGroup="Save"></asp:RequiredFieldValidator>
                            </div>
                        </div>--%>
                        <div class="ContentItem row">
                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                <asp:Label ID="Label10" runat="server" CssClass="control-label" Text="رابط الكلمة الرئيسية"></asp:Label>
                            </div>
                            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                <asp:TextBox ID="txtKeywordLink" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtKeywordLink" CssClass="Validator" Display="Dynamic" ErrorMessage="!" ValidationGroup="Save"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="ContentItem row">
                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                <asp:Label ID="Label11" runat="server" CssClass="control-label" Text="رابط عام"></asp:Label>
                            </div>
                            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                <asp:TextBox ID="txtGeneralLink" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtGeneralLink" CssClass="Validator" Display="Dynamic" ErrorMessage="!" ValidationGroup="Save"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <div class="ContentItem row">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg btn-primary" Text="حفظ" ValidationGroup="Save" OnClick="btnSave_Click" />
            </div>
        </div>
</asp:Content>
