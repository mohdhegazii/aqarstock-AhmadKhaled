brokerApp.directive('cycle', function () {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            $(element).cycle(scope.$eval(attrs.cycle));
        }
    };
});
brokerApp.directive('searchSlider', function () {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            $(element).slider({
                range: true,
                isRTL: true,
                min: parseInt(attrs.min),
                max: parseInt(attrs.max),
                values: [parseInt(attrs.valuesFrom), parseInt(attrs.valuesTo)],
                step: parseInt(attrs.step),
                slide: function (event, ui) { $(this).prev().find('span.sliderAmount').html("من " + ui.values[0] + " " + attrs.unit + " إلى " + ui.values[1] + " " + attrs.unit + "") }

            });
        }
    };
});
brokerApp.directive('uiSelect', function () {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            $(element).selectmenu();
        }
    };
});
brokerApp.directive('circleSearchLink', function () {
    return {
        restrict: 'E',

        template: '<figure><img/><span/></span></figure>',
        replace: true,
        link: function ($scope, element, attrs) {
            attrs.$observe('theClass', function (value) {
                element.attr('class', value)
            })
            attrs.$observe('theIcon', function (value) {
                element.find('img').attr('src', value)
            })
            attrs.$observe('theLabel', function (value) {
                element.find('span').html(value)
            })
            element.bind('click', function (e) {
                $(".homeSearchContent").find('.' + element.attr('class')).addClass('active');
                $('.overlay').fadeIn();
            })
        }
    }
});
brokerApp.directive('topSearchLink', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            element.bind('click', function (e) {
                $(".homeSearchContent").find('.' + element.attr('class')).addClass('active');
                $('.overlay').fadeIn();
            })
        }
    };
});


brokerApp.directive('circleSearchButtons', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            element.find('a').bind('click', function (e) {
                $(element).parents('.homeSearchContentUnit').removeClass('active');
                $('.overlay').fadeOut();
                if ($(e.currentTarget).attr('class') == 'search') {
                    $('.homeSearch').delay(300).queue(function () { $(this).addClass('collapse'); $(this).dequeue(); });
                    //$('.homeSearch').delay(600).queue(function() { $(this).hide() })
                    //$('.loadingView').delay(300).queue(function() { $(this).show(); $(this).dequeue(); });
                    //$('.loadingView').delay(600).queue(function() { $(this).hide() });
                }
            })
        }
    };
});
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
brokerApp.directive('backButtonTwo', function () {
    return {
        restrict: 'A',

        link: function (scope, element, attrs) {
            element.bind('click', goBack);

            function goBack() {
                history.go(-2) ;
                scope.$apply();
            }
        }
    }
});
//------------------------------- to add selected class to current page--------------------------//
brokerApp.directive('paging', function () {
    return {
        restrict: 'A',

        link: function ($scope, element, attrs) {

            if (attrs.id == $scope.PageIndex) {
                element.addClass('selected');
            }
        }
    }
});
//------------------------------ to create map div and load the map---------------------------//
brokerApp.directive('map', function () {
    return {
        restrict: 'E',
        replace: true,
        template: ' <div id="MyMap" class="map"></div>',
        link: function ($scope, element, attrs) {
            loadScript();
            setTimeout(AddLocation, 3000);
            //RemoveListener();
            function AddLocation() {

                if ($('#ContentPlaceHolder1_hdnLat').val() != null || $('#ContentPlaceHolder1_hdnLng').val() != null) {
                    if ($('#ContentPlaceHolder1_hdnLat').val() != "" || $('#ContentPlaceHolder1_hdnLng').val() != "") {
                        //  alert($('#hdnLat').val());
                        AddLocationToMap($('#ContentPlaceHolder1_hdnLat').val(), $('#ContentPlaceHolder1_hdnLng').val());
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
//------------ for Country Select to change the City and District select values according to city value------------------//
brokerApp.directive('uiSelectcountry', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            $(element).selectmenu({
                style: "dropdown",
                change: function (event, ui) {
                    $("#city").selectmenu("destroy");
                    $scope.BindCities(ui.item.value);
                    $('#city option:first').attr('selected', 'selected');
                    $("#city").selectmenu({ style: "dropdown" });

                    $("#district").selectmenu("destroy");
                    $('#district option:first').attr('selected', 'selected');
                    $("#district").selectmenu({ style: "dropdown" });
                    $("#district").selectmenu("disable");
                    if (ui.item.value > 0) {
                        $("#city").selectmenu("enable");
                        $("#city").selectmenu({
                            change: function (event, ui) {
                          //      alert("test");
                                $("#district").selectmenu("destroy");
                                $scope.BindDistricts(ui.item.value);
                                $('#district option:first').attr('selected', 'selected');
                                $("#district").selectmenu({ style: "dropdown" });
                                if (ui.item.value > 0) {
                                    $("#district").selectmenu("enable");
                                }
                                else {
                                    $("#district").selectmenu("disable");
                                }
                            }
                        });
                        ;
                    }
                    else {
                        $("#city").selectmenu("disable");
                        $("#district").selectmenu("disable");
                    }

                }
            });

        }
    };
});
//------------ for City Select to change the district select values according to city value------------------//
brokerApp.directive('uiSelectcity', function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            $(element).selectmenu({
                style: "dropdown",
                change: function (event, ui) {
                  //  alert("test");
                    $("#district").selectmenu("destroy");
                    $scope.BindDistricts(ui.item.value);
                    $('#district option:first').attr('selected', 'selected');
                    $("#district").selectmenu({ style: "dropdown" });
                    if (ui.item.value > 0) {
                        $("#district").selectmenu("enable");
                    }
                    else {
                        $("#district").selectmenu("disable");
                    }
                }
            });

        }
    };
});
//--------------------------------- Details back Button----------------------------------------//
brokerApp.directive('detailbackbutton', function () {
    return {
        restrict: 'A',

        link: function (scope, element, attrs) {
         
            element.bind('click', goBack);

            function goBack() {
                $("#divDetails").show();
                history.back();
                scope.$apply();
            }
        }
    }
});
//--------------------------------- Details back Button----------------------------------------//
brokerApp.directive('detailconfirmationbackbutton', function () {
    return {
        restrict: 'A',

        link: function (scope, element, attrs) {

            element.bind('click', goBack);

            function goBack() {
                $("#divDetails").show();
                history.go(-2);
                scope.$apply();
            }
        }
    }
});