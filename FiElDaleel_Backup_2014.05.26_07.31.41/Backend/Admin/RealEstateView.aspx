<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="RealEstateView.aspx.cs" Inherits="BrokerWeb.Backend.Admin.RealEstateView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../../scripts/Map.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <asp:HiddenField ID="hdnLat" runat="server" />
    <asp:HiddenField ID="hdnLng" runat="server" />
    <asp:HiddenField ID="hdnMapimageURL" runat="server" />
    <div class="Title row">
        <asp:Image ID="imgSold" CssClass="img-responsive SoldImage" ImageUrl="~/images/sold.jpg"
            runat="server" />
        <asp:Image ID="imgLogo" CssClass="img-responsive" runat="server" />
        <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
        <div class="EditBusiness">
                <asp:ImageButton ID="imgActivate" runat="server"
                ImageUrl="~/images/Activate.png" onclick="imgActivate_Click"  />
            <%--<asp:ImageButton ID="imgSuspend" CssClass="DoubleDeleteconfirm" runat="server" 
                ImageUrl="~/images/suspend.png" onclick="imgSuspend_Click" />--%>
                   <a href="#"  data-toggle="modal" data-target="#myModal">
            <asp:Image ID="Image3" ImageUrl="~/images/suspend.png" Style="vertical-align:inherit;" runat="server" />
        </a>
        </div>
    </div>
    <div id="divMsg" class="row" runat="server">
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
    <div class="row">
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 pull-right">
          <div class="divDetails row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right"><span class="DetailTitle">كود العقار</span></div>
                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9"><asp:Label CssClass="Detail" ID="lblCode" runat="server" Text="غير متوفر"></asp:Label>  </div>
            </div>
            <div class="divDetails row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right"><span class="DetailTitle">العقار معروض</span></div>
                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9"><asp:Label CssClass="Detail" ID="lblSaleType" runat="server" Text="غير متوفر"></asp:Label>  </div>
            </div>
            <div class="divDetails row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right"><span class="DetailTitle">فئة العقار</span></div>
                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9"><asp:Label CssClass="Detail" ID="lblCategory" runat="server" Text="غير متوفر"></asp:Label>  </div>
            </div>
            <div class="divDetails row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right"><span class="DetailTitle">نوع العقار</span></div>
                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9"><asp:Label CssClass="Detail" ID="lblType" runat="server" Text="غير متوفر"></asp:Label>  </div>
            </div>
            <div class="divDetails row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right"><span class="DetailTitle">حالة العقار</span></div>
                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9"><asp:Label CssClass="Detail" ID="lblStatus" runat="server" Text="غير متوفر"></asp:Label>  </div>
            </div>
            <div class="divDetails row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right"><span class="DetailTitle">العنوان</span></div>
                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9"><asp:Label CssClass="Detail" ID="lblAddress" runat="server" Text="غير متوفر"></asp:Label>  </div>
            </div>
            <div class="divDetails row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right"><span class="DetailTitle">وصف العقار</span></div>
                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                    <asp:Label ID="lblDescription" CssClass="Detail" runat="server" Text="غير متوفر"></asp:Label>
                </div>
            </div>
            <div class="divDetails row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right"><span class="DetailTitle">المساحة</span></div>
                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9"><asp:Label CssClass="Detail" ID="lblArea" runat="server" Text="غير متوفر"></asp:Label>  </div>
            </div>
            <div class="divDetails row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right"><span class="DetailTitle">السعر</span></div>
                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9"><asp:Label CssClass="Detail" ID="lblPrice" runat="server" Text="غير متوفر"></asp:Label>  </div>
            </div>
            <div class="divDetails row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right"><span class="DetailTitle">العملة</span></div>
                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9"><asp:Label CssClass="Detail" ID="lblCurrency" runat="server" Text="غير متوفر"></asp:Label>  </div>
            </div>
            <div class="divDetails row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right"><span class="DetailTitle">طريقة الدفع</span></div>
                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9"><asp:Label CssClass="Detail" ID="lblPaymentType" runat="server" Text="غير متوفر"></asp:Label>  </div>
            </div>
            <div class="divDetails row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right"><span class="DetailTitle">خصائص العقار</span></div>
                <div class="keyword col-lg-9 col-md-9 col-sm-9 col-xs-9">
                    <asp:Repeater ID="rptCriteria" runat="server" OnItemDataBound="rptCriteria_ItemDataBound">
                        <ItemTemplate>
                            <%--<asp:Image ID="imgCriteria" ImageUrl="~/images/Exist.png"  runat="server" />--%>
                            <asp:Label CssClass="Detail" ID="lblCriteria" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="divDetails row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right"><span class="DetailTitle">كلمات دالة على العقار</span></div>
                <div class="keyword col-lg-9 col-md-9 col-sm-9 col-xs-9">
                    <asp:Repeater ID="rptKeywords" runat="server">
                        <ItemTemplate>
                            <span>
                                <%#Eval("KeywordTitle")%>
                            </span>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="divDetails row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right"><span class="DetailTitle">اسم المالك</span></div>
                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9"><asp:Label CssClass="Detail" ID="lblOwnerName" runat="server" Text="غير متوفر"></asp:Label>  </div>
            </div>
            <div class="divDetails row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right"><span class="DetailTitle">البريد الالكترونى للمالك</span></div>
                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9"><asp:Label CssClass="Detail" ID="lblOwnerEmail" runat="server" Text="غير متوفر"></asp:Label>  </div>
            </div>
            <div class="divDetails row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right"><span class="DetailTitle">رقم هاتف المالك</span></div>
                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9"><asp:Label CssClass="Detail" ID="lblOwnerPhone" runat="server" Text="غير متوفر"></asp:Label>  </div>
            </div>
        </div>
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <telerik:RadTabStrip ID="rtsAddBusiness" MultiPageID="rmpAddBusiness" AutoPostBack="true"
                Align="Justify" runat="server" SelectedIndex="0" CssClass="WizardTabs" EnableEmbeddedSkins="true"
                Skin="Simple">
                <Tabs>
                    <telerik:RadTab PageViewID="rpvMap">
                        <TabTemplate>
                            <div class="WizardTab">
                                <asp:Image ID="Image1" CssClass="img-responsive" ImageUrl="~/images/Map.png" runat="server" />
                                <asp:Label ID="Label1" runat="server" Text=" الخريطة"></asp:Label>
                            </div>
                        </TabTemplate>
                    </telerik:RadTab>
                    <telerik:RadTab PageViewID="rpvPhotos">
                        <TabTemplate>
                            <div class="WizardTab">
                                <asp:Image ID="Image1" CssClass="img-responsive" ImageUrl="~/images/PhotoGallery.png"
                                    runat="server" />
                                <asp:Label ID="Label1" runat="server" Text="الصور"></asp:Label>
                            </div>
                        </TabTemplate>
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <div class="WizardContent">
                <telerik:RadMultiPage ID="rmpAddBusiness" runat="server" RenderSelectedPageOnly="true"
                    SelectedIndex="0">
                    <telerik:RadPageView CssClass="" ID="rpvMap" runat="server" Selected="true">
                        <div id="MyMap" class="GoogleMap">
                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="rpvPhotos" CssClass="" runat="server">
                        <asp:Image ID="imgCurrentPhoto" CssClass="img-responsive currentimage row" runat="server" />
                        <telerik:RadListView ID="rlvPhotos" CssClass="row" runat="server">
                            <ItemTemplate>
                                <div class="imageList">
                                    <asp:Image ID="imgPhoto" runat="server" CssClass="img-responsive" ImageUrl='<%#Eval("PhotoName") %>'
                                        onclick="ChangeImage(this);" />
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
                </telerik:RadMultiPage>
            </div>
        </div>
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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="NewMessageSave" CssClass="Validator"
                            ControlToValidate="ddlSuspendReasons" runat="server" ErrorMessage="! من فضلك ادخل سبب الحجب "
                            InitialValue="0" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="ContentItem ">
                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                        <asp:Label ID="Label4" runat="server" Text="تفاصيل * " CssClass="control-label"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="NewMessageSave" CssClass="Validator"
                            ControlToValidate="txtDescription" runat="server" Display="Dynamic" ErrorMessage="! من فضلك ادخل تفاصيل"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
        </div>
            <div class="ContentItem">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="حفظ" 
                    ValidationGroup="NewMessageSave" onclick="btnSave_Click" />
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
    <script type="text/javascript">
        $('.DoubleDeleteconfirm').click(function () {
            //   return confirm('هل أنت متأكد أنك تريد حذفه؟');
            var confirm1 = confirm('هل أنت متأكد أنك تريد حذف العقار؟');
            if (confirm1 === true) {
                return confirm('اذا قمت بحذف العقار ستفقد كل البيانات المتعلقة به, هل ترغب فى الاستمرار؟');
            }
            return false;
        });
        function ChangeImage(control) {
            //    alert(control.src);
            $("#<%= imgCurrentPhoto.ClientID %>").attr("src", control.src);
        }
        //  window.onload = loadScript;
        $(window).load(function () {
            loadScript();
            setTimeout(AddLocationtoMap, 3000);
            //AddLocationtoMap();
        });
        function AddLocationtoMap() {
            var lat = $("#<%= hdnLat.ClientID %>").val();
            var img = $("#<%= hdnMapimageURL.ClientID %>").val();
            //  var img = "http://egyptreporter.com/images/Edit.png";
            //  alert(img);
            if (lat != "" && lat != null) {
                var lng = $("#<%= hdnLng.ClientID %>").val();
                if (lng != "" && lng != null) {
                    //   alert(lat+","+lng);
                    AddLocationToMapwithimage(lat, lng, img);
                }
            }
        }

    </script>
</asp:Content>
