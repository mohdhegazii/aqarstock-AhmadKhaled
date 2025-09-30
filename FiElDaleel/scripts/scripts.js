/* FUNCTIONS DEFINITION */
/* FILL SEARCH ELEMENTS FROM DATABASE */
function fill_ddl() {
    var url_district = 'Services/GeneralService.svc/Districts';
    var url_payment_type = 'Services/General.asmx/GetPaymentTypes';
    var url_sale_types = 'Services/General.asmx/GetSaleTypes';
    var url_types = 'Services/RealEstate.asmx/GetALLRealEstateTypes';

    /* GET DISTRICT */
    $.ajax({
        type: "get",
        contentType: "application/json; charset=utf-8",
        url: url_district,
        success: function (data) {
            var arr = JSON.parse(data);
            for (var i = 0; i < arr.length; i++) {
                $('#realestate_district').append('<option value="' + arr[i].ID + '">' + arr[i].Name + '</option>');
            }
            $("#realestate_district").trigger("chosen:updated");
        },
        error: function (e) {
            alert('حدث خطأ ما ....');
        }
    });

    /* GET PAYMENT METHOD */
    $.ajax({
        type: "post",
        contentType: "application/json; charset=utf-8",
        url: url_payment_type,
        success: function (data) {
            var arr = JSON.parse(data.d);
            for (var i = 0; i < arr.length; i++) {
                $('#realestate_payment_type').append('<option value="' + arr[i].ID + '">' + arr[i].Title + '</option>');
            }
            $("#realestate_payment_type").trigger("chosen:updated");
        },
        error: function (e) {
            alert('حدث خطأ ما ....');
        }
    });

    /* GET SALE TYPE */
    $.ajax({
        type: "post",
        contentType: "application/json; charset=utf-8",
        url: url_sale_types,
        success: function (data) {
            var arr = JSON.parse(data.d);
            for (var i = 0; i < arr.length; i++) {
                $('#realestate_sell_type').append('<option value="' + arr[i].ID + '">' + arr[i].Title + '</option>');
            }
            $("#realestate_sell_type").trigger("chosen:updated");
        },
        error: function (e) {
            alert('حدث خطأ ما ....');
        }
    });

    /* GET TYPES */
    $.ajax({
        type: "post",
        contentType: "application/json; charset=utf-8",
        url: url_types,
        success: function (data) {
            var arr = JSON.parse(data.d);
            for (var i = 0; i < arr.length; i++) {
                $('#realestate_type').append('<option value="' + arr[i].ID + '">' + arr[i].Title + '</option>');
            }
            $("#realestate_type").trigger("chosen:updated");
        },
        error: function (e) {
            alert('حدث خطأ ما ....');
        }
    });
}

function buttons_events() {
    /* Links Events */
    $('.collapse li a').click(function () {
        var temp = $(this).attr('data-target');

        if (temp != '') {
            $('#tabs_control').find('.' + temp + ' a').click();
        }
    });
    var realestate_img = '';

    /* More Button Events - GET MORE REALESTATE ON REQUEST */
    var count = 2;
    $('#profile .more_lnk').click(function () {
        var webservice_url = 'Services/RealEstate.asmx/GetRealEstates';
        var parameters_data = "{ 'PageIndex': '" + count + "', 'PageSize': '" + 8 + "' }";
        var container = $('#profile .items_container');
        var el = $(this);
        el.siblings('.loading_new_items').fadeIn(0);
        get_realestate_items(webservice_url, parameters_data, container, false, false);
        count++;
    });
    var search_count = 2;
    $('#search_results .more_lnk').click(function () {
        search_button_event(search_count, 8);
    });

    /* SEARCH EVENTS */
    $('.search_btn').click(function () {
        search_button_event(1, 8);
    });

    $('.small_search').click(function () {
    });

    /* FIX TOOLBAR ON SCROLL */
    $(window).scroll(function () {
        var scrTop = $(this).scrollTop();
        if (scrTop >= 570) {
            $('.tab_bg,.tabs_header').addClass('fix_it');
        } else if (scrTop <= 500) {
            $('.tab_bg,.tabs_header').removeClass('fix_it');
        }
    });
}

function search_button_event(page_index, page_size) {
    $('.search_tab').fadeIn(500);
    var el = $('#search_results').find('.items_container .item');
    $(document).scrollTo($('#tabs_control'), 500);
    $('#search_results .more_lnk').fadeOut();
    el.fadeOut(0);
    $('.tabs_header .search_tab a').click();
    $('.loading_new_items').fadeIn(0);

    /* GET SEARCH PARAMETERS */

//    var realestate_payment_id = $('#realestate_payment_type').val();
//    var realestate_type_id = $('#realestate_type').val();
//    var realestate_sell_type_id = $('#realestate_sell_type').val();
//    var realestate_district_id = $('#realestate_district').val();
    var SearchCriteria = {};
    SearchCriteria.DistrictID= $('#realestate_district').val();
    SearchCriteria.RealEstateTypeID=$('#realestate_type').val();
    SearchCriteria.SaleTypeID=$('#realestate_sell_type').val();
    SearchCriteria.PaymentTypeID = $('#realestate_payment_type').val();
    SearchCriteria.PageIndex=page_index;
    SearchCriteria.PageSize = page_size;


    var webservice_url = 'Services/RealEstate.asmx/Search'; ;
    var parameters_data = "{'RealEstateSearchCriteria': " + JSON.stringify(SearchCriteria) + "}";  //+ ", 'PageIndex': '" + page_index + "','PageSize': '" + page_size + "}";
  //  alert(parameters_data);
    var container = $('#search_results .items_container');
    
    /* GET REALESTATES FROM DATABASE */
    get_realestate_items(webservice_url, parameters_data, container, true, true);
}

/* GET REALESTATES */
function get_realestate_items(url, parameters, container, view_ad, view_container) {
    $.ajax({
        type: "post",
        contentType: "application/json; charset=utf-8",
        url: url,
        data: parameters,
        success: function (data) {
            var arr = JSON.parse(data.d);
            var unavailable = 'غير متوفر';
            var realestate_img = '';
            var type = '';
            var sell_stats = '';
            var area = '';
            var address = '';
            var price = '';

            /* FADE OUT CONTAINER UNTIL ITEMS LOADS */
            if (view_container == true) {
                container.fadeOut(0);
            }
            /* FILTERING EACH ITEM */
            for (var i = 0; i < arr.length; i++) {

                type = arr[i].Type;
                sell_stats = arr[i].SaleType;
                realestate_img = arr[i].Logo == unavailable ? 'images/default_img.jpg' : arr[i].Logo;
                address = arr[i].Address;
                area = arr[i].Area == unavailable ? unavailable : (arr[i].Area + ' م²');
                price = arr[i].Price == unavailable ? unavailable : (arr[i].Currency == unavailable) ? unavailable : (arr[i].Price + ' ' + arr[i].Currency);

                if (realestate_img.trim() == '') {
                    realestate_img = 'images/default_img.jpg';
                }
                var item = '<div class="item  pull-right no_padding">\
        <div class="img">\
        <img class="realestate_img" src="' + realestate_img + '" alt="item"/>\
        </div>\
    <div class="txt">\
        <p>\
        ' + type + '\
        </p>\
        <p>\
        ' + sell_stats + '\
        </p>\
        <p>\
        ' + area + '\
        </p>\
    </div>\
    <div class="item_title">\
        ' + address + '\
    </div>\
    <div class="item_title">\
    ' + price + '\
    </div>\
    </div>';
                container.append(item);
            }
            /* ADD ADS AT START ONLY */
            if (view_ad == true) {
                container.append('<img src="images/Watches-ar.gif" alt="Ads" style="display: block;margin: 0 auto"/>');
            }
            /* HIDE ANDSHOW CONTAINER AT START ONLY */
            if (view_container == true) {
                container.children('img').load(function () {
                    $('.loading_new_items').fadeOut();
                    container.fadeIn();
                });
            } else {
                $('.loading_new_items').fadeOut();
            }

        },
        error: function (e) {
           // alert(e.statusText);
            alert('حدث خطأ ما ....');
        }
    });
}
