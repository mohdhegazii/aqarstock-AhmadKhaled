<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/SubScriber/SubscriberMaster.Master"
    AutoEventWireup="true" CodeBehind="ViewMessage.aspx.cs" Inherits="BrokerWeb.Backend.SubScriber.ViewMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">

        <div class="panel-heading">
            <asp:Label ID="lblTitle" runat="server" Text="Message Title" CssClass="control-label"></asp:Label>
        </div>
        <div class="panel-body">
        <telerik:RadSplitter ID="rsMessage" runat="server" Orientation="Horizontal" Width="100%"
            BorderStyle="Groove" Height="500px">
            
            <telerik:RadPane ID="rpPrevMessages" CssClass="" runat="server" Width="100%" Scrolling="Y">
                <telerik:RadListView ID="rlvPrevMessages" runat="server" OnItemDataBound="rlvPrevMessages_ItemDataBound">
                    <ItemTemplate>
                        <div class="row Message MessageItem">
                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                <asp:Label ID="lblSender" runat="server" Text='' CssClass="control-label"></asp:Label>
                                <br />
                                <span>
                                    <%#Eval("CreatedDate")%></span>
                            </div>
                            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                <p>
                                    <%#Eval("Body")%>
                                </p>
                            </div>
                        </div>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <div class="row Message MessageAlternateItem">
                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                                <asp:Label ID="lblSender" runat="server" Text='' CssClass="control-label"></asp:Label>
                                <br />
                                <span>
                                    <%#Eval("CreatedDate")%></span>
                            </div>
                            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                <p>
                                    <%#Eval("Body")%>
                                </p>
                            </div>
                        </div>
                    </AlternatingItemTemplate>
                </telerik:RadListView>
            </telerik:RadPane>
            <telerik:RadPane ID="RadPane2" CssClass="" runat="server" Width="100%" Height="30%"
                Scrolling="Y">
                <div id="divMsg" runat="server">
                    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                </div>
                <div class="ContentItem row Message">
                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 pull-right">
                        <asp:Label ID="Label4" runat="server" Text="الرد " CssClass="control-label"></asp:Label>
                    </div>
                    <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                        <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Save" CssClass="Validator"
                            ControlToValidate="txtMessage" runat="server" Display="Dynamic" ErrorMessage="! من فضلك ادخل رد على الرسالة"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="ContentItem row Message">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" style="float: left; margin-left: 20px;" Text="ارسال" ValidationGroup="Save"
                        OnClick="btnSave_Click" />
                </div>
            </telerik:RadPane>
        </telerik:RadSplitter>
            </div>
    </div>
</asp:Content>
