<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Complains.aspx.cs" Inherits="BrokerWeb.Backend.Admin.Complains" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
  
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <ajaxsettings>
            <telerik:ajaxsetting ajaxcontrolid="rgComplains">
                <updatedcontrols>
                    <telerik:ajaxupdatedcontrol controlid="divRequestDetails" loadingpanelid="radLoadingPannel" updatepanelrendermode="Block" />
                    <telerik:ajaxupdatedcontrol controlid="rgComplains" updatepanelrendermode="Block" />
                    <telerik:ajaxupdatedcontrol controlid="lblMsg" updatepanelrendermode="Block" />
                </updatedcontrols>
            </telerik:ajaxsetting>
        </ajaxsettings>
    </telerik:RadAjaxManagerProxy>
    <div class="panel panel-primary">

        <div class="panel-heading">
       الشكاوى
            <div id="divMsg" runat="server">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="panel-body">
            <telerik:RadGrid ID="rgComplains" runat="server" AllowPaging="True" AutoGenerateColumns="false" OnItemDataBound="rgComplains_ItemDataBound" OnNeedDataSource="rgComplains_NeedDataSource">
                <mastertableview datakeynames="ID">
                    <columns>
                        <telerik:gridtemplatecolumn>
                            <itemtemplate>
                                <asp:Image ID="imgNew" runat="server" ImageUrl="~/images/new.png" Visible="false" />
                            </itemtemplate>
                        </telerik:gridtemplatecolumn>
                        <telerik:gridtemplatecolumn>
                            <itemtemplate>
                                <asp:ImageButton ID="ibtnDelete" runat="server" CssClass="Deleteconfirm" ImageUrl="~/Images/icons/Delete.png" OnClick="ibtnDelete_Click" />
                            </itemtemplate>
                        </telerik:gridtemplatecolumn>
                        <telerik:gridtemplatecolumn>
                            <itemtemplate>
                                <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/icons/view.png" OnClick="ibtnEdit_Click" OnClientClick="OpenWindow()" />
                            </itemtemplate>
                        </telerik:gridtemplatecolumn>
                        <telerik:gridtemplatecolumn headertext="كود العقار">
                            <itemtemplate>
                                <a href="<%#"RealEstateView/"+Eval("RealEstateID")+"/0" %>" target="_blank">
                                    <asp:Label ID="lblCode" runat="server" Text=""></asp:Label>
                                </a>
                            </itemtemplate>
                        </telerik:gridtemplatecolumn>
                        <telerik:gridtemplatecolumn headertext="عنوان اعلان العقار">
                            <itemtemplate>
                                <a href="<%#"RealEstateView/"+Eval("RealEstateID")+"/0"%>" target="_blank">
                                    <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
                                </a>
                            </itemtemplate>
                        </telerik:gridtemplatecolumn>
                        <telerik:gridboundcolumn datafield="ComplainTitle" headertext="عنوان الشكوى" itemstyle-font-size="11pt" uniquename="ComplainTitle" />
                        <telerik:griddatetimecolumn datafield="CreatedDate" dataformatstring="{0:dd/MM/yyyy}" datatype="System.DateTime" headertext="التاريخ" uniquename="CreatedDate">
                        </telerik:griddatetimecolumn>
                    </columns>
                    <norecordstemplate>
                        <div class="divEmptyData">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Empty.png" />
                            <span>لا يوجد شكاوى </span>
                        </div>
                    </norecordstemplate>
                </mastertableview>
            </telerik:RadGrid>
        </div>
        <div id="divWindow">
        </div>
    </div>
    <telerik:RadWindow ID="rwComplain" runat="server" Behaviors="Close" CssClass="row  Win" KeepInScreenBounds="true" Modal="True" OffsetElementID="divWindow" Title="الشكوى" Top="-10">
        <contenttemplate>
            <div id="divRequestDetails" runat="server" style="margin-right: 20px;">
                <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">عنوان الشكوى</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label ID="lblComplainTitle" runat="server" CssClass="Detail" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
                <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">كود العقار</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label ID="lblCode" runat="server" CssClass="Detail" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
                <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">عنوان اعلان العقار</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label ID="lblTitle" runat="server" CssClass="Detail" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
                <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">اسم المشتكى</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label ID="lblComplainerName" runat="server" CssClass="Detail" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
                <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">رقم الهاتف</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label ID="lblComplainerPhone" runat="server" CssClass="Detail" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
                <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">البريد الالكترونى</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label ID="lblComplainerEmail" runat="server" CssClass="Detail" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
                <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">التاريخ</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label ID="lblDate" runat="server" CssClass="Detail" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
                <div class="divDetails row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 pull-right">
                        <span class="DetailTitle">الرسالة</span>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:Label ID="lblComplainDetails" runat="server" CssClass="Detail" Text="غير متوفر"></asp:Label>
                    </div>
                </div>
            </div>
        </contenttemplate>
    </telerik:RadWindow>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script>
            function OpenWindow() {
                var oWnd = $find("<%= rwComplain.ClientID %>");
                oWnd.show();
            }
            
        </script>
          <script type="text/javascript">
              $(document).ready(function () {
                  FixGridDesign();
              });
              function FixGridDesign() {
                  $('.rgMasterTable').addClass('table table-striped table-bordered table-hover theGridTable');

                  $('.RadGrid').removeClass('RadGrid RadGrid_Default RadGridRTL RadGridRTL_Default');
              }
    </script>
    </telerik:RadCodeBlock>
</asp:Content>
