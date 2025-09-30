<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master"
    AutoEventWireup="true" CodeBehind="ViewProject.aspx.cs" Inherits="BrokerWeb.Backend.Admin.ViewProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .divFrame iframe {
            max-width: 300px;
            max-height: 150px;
        }

        .tdimg img {
            max-width: 300px;
            max-height: 150px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Title row">
        <%--    <asp:Image ID="imgSold" CssClass="img-responsive SoldImage" ImageUrl="~/images/icons/sold.png"
            runat="server" />--%>
        <asp:Image ID="imgLogo" CssClass="img-responsive" Style="max-height: 128px; max-width: 128px;"
            runat="server" />
        <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
        <div class="EditBusiness">
            <asp:ImageButton ID="imgActivate" runat="server" ImageUrl="~/images/icons/Admin/Activate.png"
                OnClick="imgActivate_Click" />
            <%--<asp:ImageButton ID="imgSuspend" CssClass="DoubleDeleteconfirm" runat="server" 
                ImageUrl="~/images/suspend.png" onclick="imgSuspend_Click" />--%>
            <a href="#" data-toggle="modal" data-target="#myModal">
                <asp:Image ID="Image3" ImageUrl="~/images/icons/Admin/suspend.png" Style="vertical-align: inherit;"
                    runat="server" />
            </a>
            <asp:ImageButton ID="imgSetOffer" runat="server" ToolTip="Show on Banner" Style="margin-bottom: 4px"
                ImageUrl="~/images/icons/Admin/Banner.png" OnClick="imgSetOffer_Click" />
            <asp:ImageButton ID="imgHomePage" runat="server" ToolTip="Show on HomePage" Style="margin-bottom: 4px"
                ImageUrl="~/images/icons/Admin/HomePage.png" OnClick="imgHomePage_Click" />
            <asp:ImageButton ID="imgRemoveOffer" runat="server" ToolTip="Set as Normal" Style="margin-bottom: 4px"
                ImageUrl="~/images/icons/Admin/Normal.png" OnClick="imgRemoveOffer_Click" />
            <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/images/icons/Admin/edit.png"
                OnClick="imgEdit_Click" />
        </div>
    </div>
    <div id="divMsg" class="row" runat="server">
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
    <div class="row">
        <telerik:RadTabStrip ID="rtsProject" MultiPageID="rmpProject" AutoPostBack="True"
            Align="Justify" runat="server" SelectedIndex="0" CssClass="WizardTabs" Skin="Simple">
            <Tabs>
                <telerik:RadTab PageViewID="rpvMainData" Selected="true">
                    <TabTemplate>
                        <div class="WizardTab">
                            <asp:Label ID="Label1" runat="server" Text="بيانات المشروع "></asp:Label>
                        </div>
                    </TabTemplate>
                </telerik:RadTab>
                <telerik:RadTab PageViewID="rpvPhotos">
                    <TabTemplate>
                        <div class="WizardTab">
                            <asp:Label ID="Label1" runat="server" Text="صور المشروع"></asp:Label>
                        </div>
                    </TabTemplate>
                </telerik:RadTab>
                <telerik:RadTab PageViewID="rpvVedio">
                    <TabTemplate>
                        <div class="WizardTab">
                            <asp:Label ID="Label1" runat="server" Text="فيديوهات المشروع"></asp:Label>
                        </div>
                    </TabTemplate>
                </telerik:RadTab>
                <telerik:RadTab PageViewID="rpvModels" Selected="True">
                    <TabTemplate>
                        <div class="WizardTab">
                            <asp:Label ID="Label1" runat="server" Text="نماذج المشروع"></asp:Label>
                        </div>
                    </TabTemplate>
                </telerik:RadTab>
                  <telerik:RadTab PageViewID="rpvProperties" Selected="True">
                    <TabTemplate>
                        <div class="WizardTab">
                            <asp:Label ID="Label1" runat="server" Text="عقارات المشروع"></asp:Label>
                        </div>
                    </TabTemplate>
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
    </div>
    <div class="row">
        <telerik:RadMultiPage ID="rmpProject" runat="server" RenderSelectedPageOnly="true"
            SelectedIndex="0">
            <telerik:RadPageView CssClass="WizardPageView" ID="rpvMainData" runat="server">
                <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">كود المشروع</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label CssClass="Detail" ID="lblCode" runat="server" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
                <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">شعار المشروع</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label CssClass="Detail" ID="lblSlogan" runat="server" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
                <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">اسم الشركة</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label CssClass="Detail" ID="lblCompanyName" runat="server" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
                <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">العنوان</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label CssClass="Detail" ID="lblAddress" runat="server" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
                <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">الوصف</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label CssClass="Detail" ID="lblDescription" runat="server" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
                <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">اسم المشترك</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label CssClass="Detail" ID="lblSubscriberName" runat="server" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
                <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">البريد الالكترونى للمشترك</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label CssClass="Detail" ID="lblSubscriberEmail" runat="server" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
                <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">رقم هاتف المشترك</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label CssClass="Detail" ID="lblSubscriberPhone" runat="server" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView CssClass="WizardPageView" ID="rpvPhotos" runat="server">
                <div class="divDetails row">
                    <asp:Image ID="imgCurrentPhoto" CssClass="img-responsive currentimage " runat="server" />
                </div>
                <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">التاريخ</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label CssClass="Detail" ID="lblDate" runat="server" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
                <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">وصف</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label CssClass="Detail" ID="lblPhotoDesc" runat="server" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
                <telerik:RadListView ID="rlvPhotos" CssClass="row" runat="server">
                    <ItemTemplate>
                        <div class="imageList">
                            <asp:Image ID="imgPhoto" runat="server" CssClass="img-responsive" ImageUrl='<%#Eval("PhotoURL") %>'
                                onclick="ChangeImage(this);" Date='<%#Eval("Date") %>' Desc='<%#Eval("Description") %>' />
                        </div>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <div class="divEmptyData">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Empty.png" />
                            <span>لا يوجد صور للعقار </span>
                        </div>
                    </EmptyDataTemplate>
                </telerik:RadListView>
            </telerik:RadPageView>
            <telerik:RadPageView CssClass="WizardPageView" ID="rpvVedio" runat="server">
                <br />
                <div class="row">
                    <asp:GridView ID="gvVedios" runat="server" DataKeyNames="ID" AutoGenerateColumns="False"
                        CellPadding="4" CssClass="table table-striped table-bordered table-hover theGridTable">
                        <AlternatingRowStyle />
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="Id" Visible="false" />
                <%--            <asp:TemplateField HeaderText="الفيديو" HeaderStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                                <ItemTemplate>
                                    <div class="divFrame">
                                        <%#Eval("EmedCode")%>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:BoundField DataField="TiTle" HeaderText=" اسم الفيديو" HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-CssClass="GridColumnHeader">
                                <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                            </asp:BoundField>
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
            </telerik:RadPageView>
            <telerik:RadPageView CssClass="WizardPageView" ID="rpvModels" runat="server">
                <br />
                <asp:GridView ID="gvModels" runat="server" DataKeyNames="ID" AutoGenerateColumns="False"
                    CellPadding="4" CssClass="table table-striped table-bordered table-hover theGridTable">
                    <AlternatingRowStyle />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="Id" Visible="false" />
                        <asp:ImageField DataImageUrlField="PlanImgURL" ItemStyle-CssClass="tdimg">
                        </asp:ImageField>
                        <asp:BoundField DataField="Description" HeaderText="الوصف" HeaderStyle-HorizontalAlign="Center"
                            HeaderStyle-CssClass="GridColumnHeader">
                            <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Price" HeaderText="السعر" HeaderStyle-HorizontalAlign="Center"
                            HeaderStyle-CssClass="GridColumnHeader">
                            <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Area" HeaderText="المساحة" HeaderStyle-HorizontalAlign="Center"
                            HeaderStyle-CssClass="GridColumnHeader">
                            <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Type" HeaderText=" نوع العقار" HeaderStyle-HorizontalAlign="Center"
                            HeaderStyle-CssClass="GridColumnHeader">
                            <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Title" HeaderText=" اسم النموذج" HeaderStyle-HorizontalAlign="Center"
                            HeaderStyle-CssClass="GridColumnHeader">
                            <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                        </asp:BoundField>
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
            </telerik:RadPageView>
            <telerik:RadPageView CssClass="WizardPageView" ID="rpvProperties" runat="server">
                <br />
                <asp:GridView ID="gvRealestates" runat="server" DataKeyNames="ID" AutoGenerateColumns="False"
                    CellPadding="4" CssClass="table table-striped table-bordered table-hover theGridTable">
                    <AlternatingRowStyle />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="Id" Visible="false" />
                    
                        <asp:BoundField DataField="Price" HeaderText="السعر" HeaderStyle-HorizontalAlign="Center"
                            HeaderStyle-CssClass="GridColumnHeader">
                            <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Area" HeaderText="المساحة" HeaderStyle-HorizontalAlign="Center"
                            HeaderStyle-CssClass="GridColumnHeader">
                            <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Type" HeaderText=" نوع العقار" HeaderStyle-HorizontalAlign="Center"
                            HeaderStyle-CssClass="GridColumnHeader">
                            <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Title" HeaderText="اعلان العقار" HeaderStyle-HorizontalAlign="Center"
                            HeaderStyle-CssClass="GridColumnHeader">
                            <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                        </asp:BoundField>
                          <asp:TemplateField HeaderText="عرض" HeaderStyle-HorizontalAlign="Center">
                        <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                        <ItemTemplate>
                            <a target="_blank" href='<%#"~/RealEstateView/"+Eval("ID")+"/0" %>' runat="server">
                                <img src="~/Images/icons/view.png" runat="server" />
                            </a>
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
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </div>
    <div class="modal fade pull-right" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true" dir="rtl">
        <div class="modal-dialog">
            <div class="modal-content">
                <%--      <div class="modal-header">
                    <button type="button" class="close pull-left" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title" id="myModalLabel">
                              رسالة جديدة
                    </h4>
                </div>--%>
                <div class="modal-body login">
                    <div class="Content">
                        <div id="divControls" class="row" runat="server">
                            <div class="pull-right">
                                <div class="ContentItem ">
                                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12 pull-right">
                                        <asp:Label ID="Label13" runat="server" Text="سبب الحجب*" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-lg-10 col-md-9 col-sm-9 col-xs-12">
                                        <asp:DropDownList ID="ddlSuspendReasons" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="NewMessageSave"
                                            CssClass="Validator" ControlToValidate="ddlSuspendReasons" runat="server" ErrorMessage="! من فضلك ادخل سبب الحجب "
                                            InitialValue="0" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="ContentItem ">
                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                        <asp:Label ID="Label4" runat="server" Text="تفاصيل * " CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="NewMessageSave"
                                            CssClass="Validator" ControlToValidate="txtDescription" runat="server" Display="Dynamic"
                                            ErrorMessage="! من فضلك ادخل تفاصيل"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="ContentItem">
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="حفظ" ValidationGroup="NewMessageSave"
                                OnClick="btnSave_Click" />
                        </div>
                    </div>
                </div>
                <%-- <div class="modal-footer">
              
                   <asp:Button ID="btnForgetPassword" class="btn btn-primary" runat="server" Text="ارسال"
                        ValidationGroup="ForgetPassword" OnClick="btnForgetPassword_Click" />
                    <button type="button" class="btn btn-default" data-dismiss="modal">
                        اغلاق</button>
                </div>--%>
            </div>
        </div>
    </div>
    <script>
        function ChangeImage(control) {
            //    alert(control.src);
            var date = new Date($(control).attr("date"));
            var desc = $(control).attr("desc");
            $("#<%= imgCurrentPhoto.ClientID %>").attr("src", control.src);
            $("#<%= lblDate.ClientID %>").text(date.toLocaleDateString());
            $("#<%= lblPhotoDesc.ClientID %>").text(desc);
        }
    </script>
</asp:Content>
