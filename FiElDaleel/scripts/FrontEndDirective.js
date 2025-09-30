//---------------- Begin: Country Search DDL Directives------------------//
brokerApp.directive('searchSelecttype', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            element.bind('change', $scope.BindSearchStatus);
        }
    }
});
//---------------- End: Country Search DDL Directives-------------------//
//---------------- Begin: Country Search DDL Directives------------------//
brokerApp.directive('searchSelectcountry', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            element.bind('change', $scope.BindSearchCities);
        }
    }
});
//---------------- End: Country Search DDL Directives-------------------//
//---------------- Begin: City Search DDL Directives------------------//
brokerApp.directive('searchSelectcity', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            element.bind('change', $scope.BindSearchDistricts);
            var result = $.grep($scope.Messages, function (e) { return e.Type == "SelectCityError"; });
            element.bind('click', result[0], $scope.ShowMessage);
        }
    }
});
//---------------- End: City Search DDL Directives-------------------//
//---------------- Begin: Country Notify DDL Directives------------------//
brokerApp.directive('notifySelectcountry', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            element.bind('change', $scope.BindNotifyCities);
        }
    }
});
//---------------- End: Country Notify DDL Directives-------------------//
//---------------- Begin: City Notify DDL Directives------------------//
brokerApp.directive('notifySelectcity', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            element.bind('change', $scope.BindNotifyDistricts);
            var result = $.grep($scope.Messages, function (e) { return e.Type == "SelectCityError"; });
            element.bind('click', result[0], $scope.ShowMessage);
        }
    }
});
//---------------- End: City Notify DDL Directives-------------------//
//---------------- Begin: District DDL Directives------------------//
brokerApp.directive('selectDistrict', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            element.bind('change', $scope.BindNotifyDistricts);
            var result = $.grep($scope.Messages, function (e) { return e.Type == "SelectDistrictError"; });
            element.bind('click', result[0], $scope.ShowMessage);
        }
    }
});
//---------------- End: District DDL Directives-------------------//
//---------------- Begin: Status DDL Directives------------------//
brokerApp.directive('selectStatus', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            element.bind('change', $scope.BindNotifyDistricts);
            var result = $.grep($scope.Messages, function (e) { return e.Type == "SelectStatusError"; });
            element.bind('click', result[0], $scope.ShowMessage);
        }
    }
});
//---------------- End: Status DDL Directives-------------------//
//---------------- Begin: Tab Directive-----------------------------//
brokerApp.directive('tabClick', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            element.bind('click', CLickHandler);
            function CLickHandler() {
                $(' div .tabs .active').toggleClass('active');
                $(element).addClass('active');
                var id = $(element).attr("id");

            }
        }
    }
});
//---------------- End : tab Directive-----------------------------//
//---------------- Begin: ForSale Properties Next Button----------//
brokerApp.directive('btnSalenext', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            element.bind('click', CLickHandler);
            function CLickHandler() {
                $scope.GetNextForSaleProps();

            }
        }
    }
});
//---------------- End: ForSale Properties Next Button-----------//
//---------------- Begin: ForSale Properties Previous Button----//
brokerApp.directive('btnSaleprevious', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            element.bind('click', CLickHandler);
            function CLickHandler() {
                $scope.GerPreviousForSaleProps();
//                var slider = $("#ForSaleSlider");
//                var viewportWidth = $('.viewport', slider).width();
//                var previousStep = (parseInt($('.viewport ul', slider).css('left')) - viewportWidth) < 0 ? 0 : (parseInt($('.viewport ul', slider).css('left')) - viewportWidth);
//                $('.viewport ul', slider).animate({ "left": previousStep + "px" }, 1000);

            }
        }
    }
});
//---------------- End: ForSale Properties Previous Button-----//
//---------------- Begin: Property Slider List Item------------//
brokerApp.directive('liSlider', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            var slider = $(element).parents('.slider'); // $("#ForSaleSlider");
            var Liwidth = $('.viewport li:first', slider).width();
            $(element).width(Liwidth);
          //  $(".viewport", slider).height($('.viewport li:first', slider).height());
        }
    }
});
//---------------- End: Property Slider List Item-------------//
//---------------- Begin: ForRent Properties Previous Button----//
brokerApp.directive('btnRentprevious', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            element.bind('click', CLickHandler);
            function CLickHandler() {
                $scope.GerPreviousForRentProps();
//                var slider = $("#ForRentSlider");
//                var viewportWidth = $('.viewport', slider).width();
//                var previousStep = (parseInt($('.viewport ul', slider).css('left')) - viewportWidth) < 0 ? 0 : (parseInt($('.viewport ul', slider).css('left')) - viewportWidth);
//                $('.viewport ul', slider).animate({ "left": previousStep + "px" }, 1000);

            }
        }
    }
});
//---------------- End: ForRent Properties Previous Button-----//
//---------------- Begin: ForRent Properties Next Button----------//
brokerApp.directive('btnRentnext', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            element.bind('click', CLickHandler);
            function CLickHandler() {
                $scope.GetNextForRentProps();

            }
        }
    }
});
//---------------- End: ForRent Properties Next Button-----------//
//---------------- Begin: Banner Slider List Item------------//
brokerApp.directive('liBannerslider', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            var IW = window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;
            
            $(element).width(IW);
            $(element).hide();
        }
    }
});
//---------------- End: Banner Slider List Item-------------//
//---------------- Begin: Header Hight-----------------------//
brokerApp.directive('headerSetting', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            var IW = window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;
            var IH = window.innerHeight || document.documentElement.clientHeight || document.body.clientHeight;
            $('header .logo img').load(function () {
                if (IW > 960 ) {
                var sliderBehind = IH - $(element).height();
                $('.searchArea, .sliderBehind .viewport,.searchAreaImg').height(sliderBehind);
                $('.searchArea .search').css({ "margin-top": -sliderBehind + "px" });
             }
            });
            $("* img").load(function () {
                $('.firstLoader').fadeOut(1000);
            });
            var navigatorScrollPoint = $('.navigator').position().top;
            $(window).scroll(function () {
                if ($(this).scrollTop() > navigatorScrollPoint) {
                    $('.navigator').addClass('fixed');
                    $('.logo img').attr("src", "../images/Frontend/logoSm.png");
                } else {
                    $('.navigator').removeClass('fixed');
                    $('.logo img').attr("src", "../images/Frontend/logo.jpg");
                }
            });


           

        }
    }
});
//---------------- End: Header height------------------------//
//---------------- begin: Advanced Search-------------------//
brokerApp.directive('btnAdvanced', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            //  $(element).attr("href", window.location.href + "/#");
            element.bind('click', CLickHandler);
            function CLickHandler() {
                $('.tabsBox , .tabsBoxSm').toggleClass('expand');
                $('.thirdRow .control span').toggleClass('expand');
                $('.thirdRow .in').slideToggle();

            }
        }
    }
});
//---------------- End: Advanced Search---------------------//
//---------------- Begin: Country Flags--------------------//
brokerApp.directive('liFlag', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            element.bind('click', CLickHandler);
            function CLickHandler() {
                $('header .top_bar .flags').css({ "overflow": $('header .top_bar .flags').css("overflow") === "visible" ? "hidden" : "visible" });

            }
        }
    }
});
//---------------- End: Country Flags---------------------//
//---------------- Begin: Sign in -----------------------//
brokerApp.directive('signIn', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            //   $(element).attr("href", window.location.href+"/#");
            element.bind('click', CLickHandler);
            function CLickHandler() {
                $('#divSignin').slideToggle();
            }
        }
    }
});
//---------------- End:  Sign in ------------------------//
//---------------- Begin: navigator item List-----------------------//
brokerApp.directive('liNavigator', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            element.bind('click', CLickHandler);
            function CLickHandler() {
                if ($('.mark', $(this).parents('.nav')).css('display') === 'block') {
                    $('ul', $(this).parents('.nav')).slideUp(1000);
                }
            }
        }
    }
});
//---------------- End: navigator item List------------------------//
//---------------- Begin: navigator mark div-----------------------//
brokerApp.directive('divMark', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            element.bind('click', CLickHandler);
            function CLickHandler() {
                if ($('ul', element.parents('.nav')).css('display') === 'none') {

                    $('ul', element.parents('.nav')).slideDown(1000);
                } else {
                    $('ul', element.parents('.nav')).slideUp(1000);
                }
            }
        }
    }
});
//---------------- End: navigator mark div------------------------//
//---------------- Begin: Button Sign in-------------------------//
brokerApp.directive('btnSignin', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            //  $(element).attr("href", window.location.href + "/#");
            element.bind('click', CLickHandler);
            function CLickHandler() {
                // $(element).removeAttr('href');
                var username = $("#txtUserName").val();
                var passowrd = $("#txtPassword").val();
                PageMethods.Signin(username, passowrd, onSucess, onError);
            }
            function onSucess(result) {
                if (result == "Admin") {
                    window.location = "/AdminDashboard";
                }
                else {
                    if (result.indexOf("Subscriber") > -1) {
                        $("#divUserName").text(result.split('/')[1]);
                        $("#lPurchaseRequest").text(result.split('/')[2]);
                        $("#divAccountSetting").show();
                        $("#liSignin").hide();
                        $('#divSignin').hide();
                    }
                    else {
                        ///  alert("test");
                        $("#validatMsg").text(result);
                        $("#validatMsg").show();
                    }
                }
                // alert(result);
            }

            function onError(result) {
                $("#validatMsg").val("لقد حدث خطأ, الرجاء المحاولة مرة اخرى");
                $("#validatMsg").show();
                // alert('Cannot process your request at the moment, please try later.');
            }
        }
    }
});
//--
//---------------- End: Button Sign in--------------------------//
//---------------- Begin: Account List-----------------------//
brokerApp.directive('listAccount', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            element.bind('click', CLickHandler);
            function CLickHandler() {
                $('.welcome').slideToggle();
            }
        }
    }
});
//---------------- End: Account List------------------------//
//---------------- Begin: Sign Out-----------------------//
brokerApp.directive('btnSignout', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            // $(element).attr("href", window.location.href + "/#");
            element.bind('click', CLickHandler);
            function CLickHandler() {
                PageMethods.SignOut(onSucess, onError);
            }
            function onSucess(result) {
                $("#divAccountSetting").hide();
                $("#liSignin").show();
            }
            function onError(result) {
                alert("لقد حدث خطأ, الرجاء المحاولة مرة اخرى");
            }
        }
    }
});
//---------------- End: Sign Out------------------------//
//---------------- Begin: Purchase Request-----------------------//
brokerApp.directive('aPurchaseRequest', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            PageMethods.GetPurchaseRequest(onSucess, onError);
            function onSucess(result) {
                $("#lPurchaseRequest").text(result);
            }
            function onError(result) {
                //  alert("لقد حدث خطأ, الرجاء المحاولة مرة اخرى");
            }
        }
    }
});
//---------------- End: Purchase Request------------------------//
//---------------- Begin: General Link Href--------------------//
brokerApp.directive('aHref', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            $(element).attr("href", window.location.href + "/#");
        }
    }
});
//---------------- End: General Link Href--------------------//
//---------------- Begin: Search----------------------------//
brokerApp.directive('btnSearch', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            //   $(element).attr("href", window.location.href + "/#");
            element.bind('click', $scope.Search);
            //            function CLickHandler() {
            //                PageMethods.SignOut(onSucess, onError);
            //            }
        }
    }
});
//---------------- End: Search-----------------------------//
//---------------- Begin: Property List Paging-------------//
brokerApp.directive('paging', function () {
    return {
        restrict: 'A',

        link: function ($scope, element, attrs) {

            if (attrs.id == $scope.PageIndex) {
                element.addClass('active');
            }
            if ($scope.PageIndex <= 2) {
                if (attrs.id > 5) {
                    element.hide();
                }
            }
            else {
                if (attrs.id != $scope.PageIndex) {
                    if (attrs.id != parseInt($scope.PageIndex) + 1) {
                        if (attrs.id != parseInt($scope.PageIndex) + 2) {
                            element.hide();
                        }
                    }
                }
            }
        }
    }
});
//---------------- End: Property List Paging-----------------//
//---------------- Begin: Property Detail images Hover-------------//
brokerApp.directive('imgDefult', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            //   $(element).attr("href", window.location.href + "/#");
            element.bind('mouseover', mouseenterHandler);
            element.bind('mouseout', mouseleaveHandler);
            function mouseenterHandler() {
                $('.allImages').css({ "display": "inline-block" });
            }
            function mouseleaveHandler() {
                $('.allImages').css({ "display": "none" });
            }
        }
    }
});
//---------------- End: Property Detail images Hover--------------//
//---------------- Begin: Property Detail item----------------------------//
brokerApp.directive('detailsRow', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            var detailsRowHeight = Math.max($('.titl', $(element)).height(), $('.descrip', $(element)).height());
            $('.titl, .descrip', $(element)).height(detailsRowHeight);
        }
    }
});
//---------------- End: Property Detail item-------------------------------//
//---------------- Begin: Compare button----------------------------//
brokerApp.directive('btnCompare', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            element.bind('click', CLickHandler);
            function CLickHandler() {
                $(element).toggleClass("checked");
                if ($('input', $(element)).val() == "unchecked") {
                    $('input', $(element)).val("checked");
                    $scope.AddToCompareList(attrs.value);

                } else {
                    $('input', $(element)).val("unchecked");
                }
            }
        }
    }
});
//---------------- End: Compare button-----------------------------//
//---------------- Begin: Map-------- -----------------------------//
brokerApp.directive('map', function () {
    return {
        restrict: 'E',
        replace: true,
        template: ' <div id="MyMap"></div>',
        link: function ($scope, element, attrs) {
            loadScript();
            setTimeout(AddLocation, 3000);
            // setTimeout(RemoveListener, 3000);
            //RemoveListener();
            function AddLocation() {
                RemoveListener();
                if ($('#hdnLat').val() != null || $('#hdnLng').val() != null) {
                    if ($('#hdnLat').val() != "" || $('#hdnLng').val() != "") {
                        //  alert($('#hdnLat').val());
                        
                        AddLocationToMap($('#hdnLat').val(), $('#hdnLng').val());
                    }
                    else {
                        //  alert('test1');
                        AddInfoWindow();
                    }
                }
                else {
                    // alert('test2');
                    AddInfoWindow();
                }
            }
        }
    }
});
//---------------- End: Map------------------------------------------//
//---------------- Begin: Back Button -------------------------------//
brokerApp.directive('backButton', function () {
    return {
        restrict: 'A',

        link: function (scope, element, attrs) {
            element.bind('click', goBack);

            function goBack() {
                history.back();
                scope.$apply();
            }
        }
    }
});
//---------------- End: Back Button --------------------------------//
//---------------- Begin: Detail Back Button -------------------------------//
brokerApp.directive('detailBackbutton', function () {
    return {
        restrict: 'A',

        link: function (scope, element, attrs) {
            element.bind('click', goBack);

            function goBack() {
                $("#divDetail").show();
                $(".projectBtns").show();
                $(".projectControl").show();
                history.back();
                scope.$apply();
            }
        }
    }
});
//---------------- End: Detail Back Button --------------------------------//
//---------------- Begin: Meesages----------------------------//
brokerApp.directive('divMeesage', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            var IW = window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;
            var IH = window.innerHeight || document.documentElement.clientHeight || document.body.clientHeight;
            $(element).width(IW);
            $(element).height(IH);
            $('.popUp').css({ "margin-top": ((IH - $('.popUp').height()) / 2) - 100 + "px" });
            element.bind('click', CLickHandler);
            function CLickHandler() {
                $(element).css({ "display": "none" });
            }
        }
    }
});
//---------------- End: Meesages-----------------------------//
//---------------- Begin: Meesages Close Button----------------------------//
brokerApp.directive('btnCloseMsg', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            element.bind('click', CLickHandler);
            function CLickHandler() {
                $('.popUpContainer').css({ "display": "none" });
            }
        }
    }
});
//---------------- End: Meesages Closes Button-----------------------------//
//---------------- Begin: Account Type Checkbox----------------------------//
brokerApp.directive('chkAccountType', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            element.bind('click', CLickHandler);
            function CLickHandler() {
                if (!$(element).hasClass('clicked')) {
                    $('.accountType').removeClass("clicked");
                    $(element).addClass("clicked");
                    $('input', $(element).parent()).val($('.accountType.clicked').attr('id'));
                }
            }
        }
    }
});
//---------------- End: Account Type Checkbox-----------------------------//
//---------------- Begin: Register Condition----------------------------//
brokerApp.directive('divConditions', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            element.bind('click', CLickHandler);
            function CLickHandler() {
                $(element).toggleClass("checked");
                //  alert($("#chkTerms").val());
                if ($("#chkTerms").val() == "unchecked") {
                    $("#chkTerms").val("checked");

                } else {
                    $("#chkTerms").val("unchecked");
                }
            }
        }
    }
});
//---------------- End: Register Condition-----------------------------//
//---------------- Begin: Register Condition----------------------------//
brokerApp.directive('btnSignToggle', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            element.bind('click', CLickHandler);
            function CLickHandler() {
                $('.tabtitle').toggleClass("signToggle");
                $('.back').toggleClass("signToggle");
                $('.signInForm , .signUpForm').toggleClass("signToggle");
            }
        }
    }
});
//---------------- End: Register Condition-----------------------------//
//---------------- Begin: Register Condition----------------------------//
brokerApp.directive('formSignin', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            var type = window.location.pathname.toString().replace('/', '');
            type = decodeURI(type);
            if (type == "تسجيل") {
                // alert('test');
                $('.tabtitle').toggleClass("signToggle");
                $('.back').toggleClass("signToggle");
                $('.signInForm , .signUpForm').toggleClass("signToggle")
            }
        }
    }
});
//---------------- End: Register Condition-----------------------------//
//---------------- Begin: Compare menu Button---------------------------//
brokerApp.directive('btnComapreMenu', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            $scope.GetCompareList();

            //            $scope.$apply(function () {
            //                var IH = window.innerHeight || document.documentElement.clientHeight || document.body.clientHeight;
            //                $(".compareBtn").css({ "margin-top": ((IH - parseInt($('.compareBtn').height(), 10)) / 2) + "px" });
            //                $(".compareMenu").css({ "margin-top": ((IH - parseInt($('.compareMenu').height(), 10)) / 2) + "px" });
            //            });
            //            var IH = window.innerHeight || document.documentElement.clientHeight || document.body.clientHeight;
            //            $(".compareBtn").css({ "margin-top": ((IH - parseInt($('.compareBtn').height(), 10)) / 2) + "px" });
            //            $(".compareMenu").css({ "margin-top": ((IH - parseInt($('.compareBtn').height(), 10)) / 4) + "px" });
            // $(".compareBtn").show();
            element.bind('click', CLickHandler);

            function CLickHandler() {
                $('.compareToggle').animate({ "right": (parseInt($('.compareToggle').css("right")) == 0 ? -350 : 0) + "px" })
            }
        }
    }
});
//---------------- End: Compare menu Button-----------------------------//
//---------------- Begin: Compare Property----------------------------//
brokerApp.directive('divCompareProp', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            //alert('test');
            //  alert($(element).height());
            //$(element).height($(" > div").height());
            $scope.$watch(function (scope) {
                return $(element).height();
            },
                          function (newValue, oldValue) {
                              var titlesWidth = $(".compareBox .compareFactors").width();
                              var totalWidth = $(".compareBox").width();
                              var Count = $('.compareBox .compareProjects').length;
                              var width = (totalWidth - titlesWidth) / Count;
                              $(element).width(width);
                              var LastId = $(".compareBox .compareProjects:last").attr("id");
                              if (attrs.id == LastId) {
                                  $('.compareBox').each(function () {
                                      var compareBox = $(this);
                                      var compareFactorsCount = $('.compareFactors > *', compareBox).length;
                                      for (i = 0; i < compareFactorsCount; i++) {
                                          var maxCellHeight = 0;
                                          $('> *', compareBox).each(function () {
                                              maxCellHeight = Math.max(parseInt($('> *:eq(' + i + ')', $(this)).height(), 10), maxCellHeight);
                                              //  window.console.log(maxCellHeight);
                                          });
                                          $('> *', compareBox).each(function () {
                                              $('> *:eq(' + i + ')', $(this)).height(maxCellHeight);
                                          });
                                      }
                                  });
                              }
                          });
        }
    }
});
//---------------- End: Compare Property-----------------------------//
//---------------- Begin: Header Menu----------------------------//
brokerApp.directive('ulMenu', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            $(' > *', element).removeClass("active");
            // console.log(decodeURI(window.location.pathname));
            $(' li', element).each(function () {
                var url = $("a", this).attr("href");
                if (url == decodeURI(window.location.pathname)) {
                    $(this).addClass("active");
                }
            });

        }
    }
});
//---------------- End: Header Menu-----------------------------//
//---------------- Begin: Delete Property From List ----------//
brokerApp.directive('btnDelete', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            element.bind('click', CLickHandler);
            function CLickHandler() {
                var id = $(element).attr("value");
                $("#" + id).remove();

            }
        }
    }
});
//---------------- End: Delete Property From List-----------//
//---------------- Begin: add To Favourite List ----------//
brokerApp.directive('btnFav', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            element.bind('click', CLickHandler);
            function CLickHandler() {
                var id = $(element).attr("value");
                PageMethods.AddToFavouriteList(id, onSucess, onError);

            }
            function onSucess(result) {
                var Message;
                //  alert(result);
                if (result == false) {
                    Message = $.grep($scope.Messages, function (e) { return e.Type == "MustLogin"; });

                }
                else {
                    Message = $.grep($scope.Messages, function (e) { return e.Type == "AddedtoFavourite"; });
                }
                $('.popUpTitle').text(Message[0].Title);
                $('.popUpCnotent p').text(Message[0].Message);
                $('.popUpContainer').show();
            }
            function onError(result) {
                var Message = $.grep($scope.Messages, function (e) { return e.Type == "Error"; });
                $('.popUpTitle').text(Message[0].Title);
                $('.popUpCnotent p').text(Message[0].Message);
                $('.popUpContainer').show();
            }
        }
    }
});
//---------------- End: add To Favourite List-----------//
//---------------- Begin: Small HeaderSearch-------------//
brokerApp.directive('mobileSearch', function () {
    return {
        restrict: 'E',
        //replace: true,
         templateUrl: 'parts/HeaderSearch.htm',
        //template:'<div>test>/div>',
        link: function ($scope, element, attrs) {
        }
    }
});
//---------------- End: Small HeaderSearch-------------//
