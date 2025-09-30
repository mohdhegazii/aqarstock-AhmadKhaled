<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="BrokerWeb.Details1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div ng-controller="DetailController">
    <input type="hidden" id="hdnID" runat="server" />
    <input type="hidden" id="hdnLat" runat="server" />
    <input type="hidden" id="hdnLng" runat="server" />
<div class="property" id="divDetails">
                    <div class="propertyHalf">
                        <div class="propertyTitle">
                            <h1>
                                <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                <div class="clear">
                                </div>
                                <asp:Label ID="lblType" class="propertyType" runat="server"></asp:Label>
                                <asp:Label ID="lblSaleType" class="saleType" runat="server"></asp:Label>
                                <%--      <span class="propertyType">{{realestate.Type}}</span> 
             <span class="saleType">{{realestate.SaleType}}</span>--%>
                            </h1>
                            <div id="Social" class="detailsSocial">
                                <script src="//platform.linkedin.com/in.js" type="text/javascript">
                                    lang: en_US
                                </script>
                                <script type="IN/Share" data-counter="right"></script>
                           <%--     <div class="g-plus" data-action="share" data-annotation="bubble">
                                </div>--%>
                                <div class="g-plus" data-action="share" data-annotation="bubble"></div>
                                <a href="https://twitter.com/share" class="twitter-share-button" data-count="none">Tweet</a>
                              <%--  <div class="fb-share-button" data-type="button_count" data-href='{{URL}}'>
                                </div>--%>
                               <div class="fb-share-button" data-layout="button_count"></div>
                            </div>
                        </div>
                        <div class="propertyDesc">
                            <p id="lblDescription" runat="server">
                            </p>
                        </div>
                        <div class="propertyDesc propertyDetails">
                            <p class="location">
                                <span>العنوان: </span>
                                <asp:Label ID="lblAddress" runat="server" />
                            </p>
                            <p class="area">
                                <span>المساحة: </span>
                                <asp:Label ID="lblArea" runat="server" />
                            </p>
                            <p class="case">
                                <span>الحالة: </span>
                                <asp:Label ID="lblStatus" runat="server" />
                            </p>
                            <p class="price">
                                <span>السعر الأجمالى: </span>
                                <asp:Label ID="lblPrice" runat="server" />
                            </p>
                            <p class="payment">
                                <span>طريقة السداد: </span>
                                <asp:Label ID="lblPaymentType" runat="server" />
                            </p>
                            <p ng-repeat="realestateCriteria in Criterias">
                                <span>{{realestateCriteria.Name}}: </span><span ng-show="realestateCriteria.Value == 'true'">
                                    متوفر</span> <span ng-show="realestateCriteria.Value != 'true'">{{realestateCriteria.Value}}</span>
                            </p>
                        </div>
                        <div class="propertyImage">
                            <img id="imgLogo" runat="server" src="">
                            <div class="propertyLinks">
                                <a ng-click="ShowPhotos()">معرض الصور</a>
                            </div>
                        </div>
                    </div>
                    <div class="propertyHalf propertyHalfLeft">
                        <div class="propertyLinks">
                            <a ng-click="ShowRequestForm()" class="salesRequest">طلب {{SaleType}}</a> <a ng-click="ShowComplainForm()">
                                تقدم بشكوى</a> <a href back-button>رجوع</a>
                        </div>
                        <map />
                        <!--   <div id="MyMap" class="map">-->
                        <!--    <iframe width="100%" height="100%" frameborder="0" style="border:0" src="https://www.google.com/maps/embed/v1/place?key=AIzaSyDFVt9cIFtqLuOizgH-N0kbyYCiys-DmEQ &q=31.2547189335695,30.0007438659668 ">
</iframe>-->
                        <!--    <iframe src="https://www.google.com/maps/embed?pb=!1m10!1m8!1m3!1d55291.32281224635!2d31.294066000000004!3d29.98783!3m2!1i1024!2i768!4f13.1!5e0!3m2!1sen!2sus!4v1404960400138" width="100%" height="100%" frameborder="0" style="border:0"></iframe>-->
                        <!-- </div>-->
                    </div>
                </div>
                 <div class="mainView" ui-view>
                </div>
                <div id='divloading' style="display: none" ng-include src="'parts/loading.html'">
                </div>
                <div class="overlay">
                </div>
                <div class="clear">
                </div>
                </div>
</asp:Content>
