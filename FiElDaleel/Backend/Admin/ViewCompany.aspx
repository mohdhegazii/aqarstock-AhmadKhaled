<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master"
    AutoEventWireup="true" CodeBehind="ViewCompany.aspx.cs" Inherits="BrokerWeb.Backend.Admin.ViewCompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hdnLat" runat="server" />
    <asp:HiddenField ID="hdnLng" runat="server" />
    <asp:HiddenField ID="hdnMapimageURL" runat="server" />
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
            <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/images/icons/Admin/edit.png"
                OnClick="imgEdit_Click" />
        </div>
    </div>
    <div id="divMsg" class="row" runat="server">
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
    <div class="row">
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 pull-right">
            <div class="divDetails row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                    <span class="DetailTitle">كود الشركة</span></div>
                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                    <asp:Label CssClass="Detail" ID="lblCode" runat="server" Text="غير متوفر"></asp:Label>
                </div>
            </div>
            <div class="divDetails row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                    <span class="DetailTitle">رقم الهاتف</span></div>
                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                    <asp:Label CssClass="Detail" ID="lblPhone" runat="server" Text="غير متوفر"></asp:Label>
                </div>
            </div>
            <div class="divDetails row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                    <span class="DetailTitle">البريد الالكترونى</span></div>
                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                    <asp:Label CssClass="Detail" ID="lblEmail" runat="server" Text="غير متوفر"></asp:Label>
                </div>
            </div>
            <div class="divDetails row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                    <span class="DetailTitle">العنوان</span></div>
                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                    <asp:Label CssClass="Detail" ID="lblAddress" runat="server" Text="غير متوفر"></asp:Label>
                </div>
            </div>
            <div class="divDetails row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                    <span class="DetailTitle">وصف مختصر</span></div>
                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                    <asp:Label ID="lblSummary" CssClass="Detail" runat="server" Text="غير متوفر"></asp:Label>
                </div>
            </div>
            <div class="divDetails row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                    <span class="DetailTitle">وصف كامل</span></div>
                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                    <asp:Label CssClass="Detail" ID="lblDescription" runat="server" Text="غير متوفر"></asp:Label>
                </div>
            </div>
            <%-- <div class="divDetails row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right"><span class="DetailTitle">اسم المشترك</span></div>
                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9"><asp:Label CssClass="Detail" ID="lblSubscriberName" runat="server" Text="غير متوفر"></asp:Label>  </div>
            </div>
            <div class="divDetails row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right"><span class="DetailTitle">البريد الالكترونى للمشترك</span></div>
                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9"><asp:Label CssClass="Detail" ID="lblSubscriberEmail" runat="server" Text="غير متوفر"></asp:Label>  </div>
            </div>
            <div class="divDetails row">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right"><span class="DetailTitle">رقم هاتف المشترك</span></div>
                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9"><asp:Label CssClass="Detail" ID="lblSubscriberPhone" runat="server" Text="غير متوفر"></asp:Label>  </div>
            </div>--%>
        </div>
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="divDetails row">
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 pull-right">
                    <span class="DetailTitle">عدد المشتركين المسموح بهم</span></div>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                    <asp:Label CssClass="Detail" ID="lblUserNo" runat="server" Text="غير متوفر"></asp:Label>
                </div>
            </div>
            <div class="divDetails row">
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 pull-right">
                    <span class="DetailTitle">عدد المشتركين المسجلين</span></div>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                    <asp:Label CssClass="Detail" ID="lblCurrenctUserNo" runat="server" Text="غير متوفر"></asp:Label>
                </div>
            </div>
            <div class="divDetails row">
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 pull-right">
                    <span class="DetailTitle">عدد المشروعات المسموح بهم</span></div>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                    <asp:Label CssClass="Detail" ID="lblProjectNo" runat="server" Text="غير متوفر"></asp:Label>
                </div>
            </div>
            <div class="divDetails row">
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 pull-right">
                    <span class="DetailTitle">عدد المشروعات المسجلة</span></div>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                    <asp:Label CssClass="Detail" ID="lblCurrentProjectNo" runat="server" Text="غير متوفر"></asp:Label>
                </div>
            </div>
            <div class="divDetails row">
                <span class="DetailTitle">بيانات الاتصال للمشتركين</span>
            </div>
            <div class="row">
                <asp:GridView ID="gvUsers" runat="server" DataKeyNames="ID" AutoGenerateColumns="False"
                    CellPadding="4" CssClass="table table-striped table-bordered theGridTable pull-right">
                    <AlternatingRowStyle />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="Id" Visible="false" />
                        <asp:BoundField DataField="Email" HeaderText="البريد الالكترونى" HeaderStyle-HorizontalAlign="Center"
                            HeaderStyle-CssClass="GridColumnHeader">
                            <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="MobileNo" HeaderText="رقم الهاتف" HeaderStyle-HorizontalAlign="Center"
                            HeaderStyle-CssClass="GridColumnHeader">
                            <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="UserName" HeaderText="اسم المستخدم" HeaderStyle-HorizontalAlign="Center"
                            HeaderStyle-CssClass="GridColumnHeader">
                            <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="FullName" HeaderText="الاسم بالكامل" HeaderStyle-HorizontalAlign="Center"
                            HeaderStyle-CssClass="GridColumnHeader">
                            <HeaderStyle HorizontalAlign="Center" CssClass="GridColumnHeader"></HeaderStyle>
                        </asp:BoundField>
                        <%--       <asp:TemplateField HeaderText="حذف">
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnDelete" CssClass="Deleteconfirm" runat="server" ImageUrl="~/Images/icons/Delete.png"
                            OnClick="ibtnDelete_Click" />
                    </ItemTemplate>
                </asp:TemplateField>--%>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#ea5821" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#ea5821" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#ea5821" ForeColor="White" HorizontalAlign="Center" />
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
    <%--    <script type="text/javascript">
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
            RemoveListener();
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

    </script>--%>
</asp:Content>
