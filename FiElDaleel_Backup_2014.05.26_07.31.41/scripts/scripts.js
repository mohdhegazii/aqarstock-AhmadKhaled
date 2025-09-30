/* FUNCTIONS DEFINITION */
function buttons_events() {

    /* Links Events */
    $('.collapse li a').click(function () {
        var temp = $(this).attr('data-target');

        if (temp != '') {
            $('#tabs_control').find('.' + temp + ' a').click();
        }
    });

    /* More Button Events */
    var x = '<div class="item  pull-right no_padding">\
        <div class="img">\
        <img src="images/test.jpg" alt="item"/>\
        </div>\
    <div class="txt">\
        <p>\
        150 م²\
        </p>\
        <p>\
        3 غرف\
        </p>\
        <p>\
        2 حمام\
        </p>\
    </div>\
    <div class="item_title">\
        القاهرة - مدينة نصر -  مكرم عبيد\
    </div>\
    <div class="item_title">\
    400000 جنية\
    </div>\
    </div>';
    $('.more_lnk').click(function () {
        var el = $(this);
        el.siblings('.loading_new_items').fadeIn(0);
        setTimeout(function () {
            el.siblings('.loading_new_items').fadeOut(0);
            el.siblings('.items_container').append(x + x + x + x + x + x + x + x);
        }, 3000)
    });

    /* Search Events */
    $('.small_search,.big_search').click(function () {
        $('.search_tab').fadeIn(500);
        var el = $('#search_results').find('.items_container .item');
        $(document).scrollTo($('#tabs_control'), 500);
        $('#search_results .more_lnk').fadeOut();
        el.fadeOut(0);
        $('.tabs_header .search_tab a').click();
        $('.loading_search_result').fadeIn(0);
        setTimeout(function () {
            $('.loading_search_result').fadeOut(0);
            el.empty();
            $('#search_results .items_container').append(x + x + x + x + x + x + x + x);
            $('#search_results .more_lnk').fadeIn();
        }, 3000)
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

//function get_realestate_items() {
//    var url = '/Services/RealEstate.asmx/GetRealEstateCategories';
//    $.ajax({
//        dataType: "json",
//        url: 'http://localhost/Broker/Services/RealEstate.asmx/GetRealEstateCategories',
//        type: "POST",
//        contentType: "application/json; charset=utf-8",
//        success: function (data) {
//            //GET OBJECT'S ATTRIBUTES VALUE
//            alert($("#category option:first").text());
//          //   $("#category").append("<option value='1'> 500 </option>");
//            //            console.log(data);
//            //GET OBJECT'S ATTRIBUTES NAME
//            var C = JSON.parse(data.d);
//            for (i = 0; i < C.length; i++) {
//                $("#category").append("<option value='" + C[i].ID + "'>" + C[i].Title + "</option>");
//               // $("#category").append("<option value='1'>Some oranges</option>");
//                //  alert(C[i].Title);
//                //  $('.view').append(value + '<br/>');
//            }
//        },
//        error: function (data) {
//        alert(data.toString());
//        }
//    });
//}
function get_realestate_items() {
    var url = '/Services/RealEstate.asmx/GetRealEstateCategories';
    $.ajax({
        //        dataType: "json",
        type: "post",
        contentType: "application/json; charset=utf-8",
        url: url,
        success: function (data) {
            var y = JSON.parse(data.d);
            var x = (y[1].Title);
            console.log(x);

        },
        error: function (e) {
            alert('Error: ' + e);
        }
    });
}
