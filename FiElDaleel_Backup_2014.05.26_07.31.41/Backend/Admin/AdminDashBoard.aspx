<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Admin/AdminMaster.Master"
    AutoEventWireup="true" CodeBehind="AdminDashBoard.aspx.cs" Inherits="BrokerWeb.Backend.Admin.AdminDashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <%--<div class="col-lg-3 col-md-3 col-sm-3 col-xs-2 pull-right">
            <telerik:RadTabStrip ID="RadTabStrip1" runat="server" EnableEmbeddedSkins="true"
                Skin="Simple" CssClass="WizardTabs rightList" Orientation="VerticalRight" OnTabClick="RadTabStrip1_TabClick">
            <Tabs>
                    <telerik:RadTab Value="0" Width="100%">
                        <TabTemplate>
                            <div class="WizardTab">
                                <asp:Image ID="Image1" CssClass="img-responsive ShowImg" ImageUrl="~/images/All.png"
                                    ToolTip="عرض كل الجديد" runat="server" />
                                <asp:Label ID="Label1" runat="server" CssClass="WizardSpan" Text="عرض كل الجديد"></asp:Label>
                            </div>
                        </TabTemplate>
                    </telerik:RadTab>
                    <telerik:RadTab Value="1" Width="100%">
                        <TabTemplate>
                            <div class="WizardTab">
                                <asp:Image ID="Image1" CssClass="img-responsive ShowImg" ImageUrl="~/images/Business.png"
                                    ToolTip="عرض الانشطة التجارية الجديدة" runat="server" />
                                <asp:Label ID="Label1" runat="server" CssClass="WizardSpan" Text="عرض الانشطة التجارية الجديدة"></asp:Label>
                            </div>
                        </TabTemplate>
                    </telerik:RadTab>
                    <telerik:RadTab Value="2" Width="100%">
                        <TabTemplate>
                            <div class="WizardTab">
                                <asp:Image ID="Image1" CssClass="img-responsive ShowImg" ImageUrl="~/images/RealEstate.png"
                                    ToolTip="عرض العقارات الجديدة" runat="server" />
                                <asp:Label ID="Label1" runat="server" CssClass="WizardSpan" Text=" عرض العقارات الجديدة"></asp:Label>
                            </div>
                        </TabTemplate>
                    </telerik:RadTab>
                    <telerik:RadTab Value="3" Width="100%">
                        <TabTemplate>
                            <div class="WizardTab">
                                <asp:Image ID="Image1" CssClass="img-responsive ShowImg" ImageUrl="~/images/Item.png"
                                    runat="server" ToolTip="عرض المنتجات الجديدة" />
                                <asp:Label ID="Label1" runat="server" CssClass="WizardSpan" Text=" عرض المنتجات الجديدة"></asp:Label>
                            </div>
                        </TabTemplate>
                    </telerik:RadTab>
                    <telerik:RadTab Value="4" Width="100%">
                        <TabTemplate>
                            <div class="WizardTab">
                                <asp:Image ID="Image1" CssClass="img-responsive ShowImg" ImageUrl="~/images/Offer_sale.png"
                                    ToolTip="عرض العروض و الخصومات الجديدة" runat="server" />
                                <asp:Label ID="Label1" runat="server" CssClass="WizardSpan" Text="عرض العروض و الخصومات الجديدة"></asp:Label>
                            </div>
                        </TabTemplate>
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
        </div>
        <div class="col-lg-9 col-md-9 col-sm-9 col-xs-10">--%>
            <div class="Content">
                <div class="ContentItem">
                    <asp:GridView ID="gvNewObjects" runat="server" DataKeyNames="ID" AutoGenerateColumns="False"
                        CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="Grid table .table-hover"
                        AllowPaging="True" PageSize="20" OnPageIndexChanging="gvNewObjects_PageIndexChanging"
                        OnRowDataBound="gvNewObjects_RowDataBound">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ibtnReview" runat="server" ImageUrl="~/Images/Review.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="النوع" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblModule" runat="server" Text="Label"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="نوع الاجراء" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblAction" runat="server" Text="Label"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ID" HeaderText="Id" Visible="false" />
                            <asp:BoundField DataField="ObjectName" HeaderText=" الاسم" HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-CssClass="GridColumnHeader" />
                            <%--        <asp:BoundField DataField="Module" HeaderText=" النوع" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-CssClass="GridColumnHeader" />
                        <asp:BoundField DataField="Action" HeaderText=" الاجراء الجديد" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-CssClass="GridColumnHeader" />--%>
                            <asp:BoundField DataField="Date" HeaderText=" تاريخ الاجراء" HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-CssClass="GridColumnHeader" />
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
     <%--   </div>--%>
    </div>
</asp:Content>
