/* FUNCTIONS DEFINITION */
function buttons_events() {

    /* Links Events */
    $('.links li a').click(function(){
        var temp = $(this).attr('data-target');

        if(temp != ''){
            $('#tabs_control').find('.' + temp + ' a').click();
        }
    });

    /* More Button Events */
    var x = '<div class="item  pull-right no_padding">\
        <div class="img">\
        <img src="images/test.jpg" alt="item"/>\
        </div>\
    <div class="txt">\
        <h4>\
        مهندس ميكانيكا بالرياض\
        </h4>\
        <p>\
        مطلوب مهندس ميكانيكا للعمل\
        ... بالرياض بدوام كامل يرجى\
        </p>\
    </div>\
    </div>';
    $('.more_lnk').click(function () {
        var el = $(this);
        el.siblings('.loading_new_items').fadeIn(0);
        setTimeout(function () {
            el.siblings('.loading_new_items').fadeOut(0);
            el.siblings('.items_container').append(x + x + x + x + x + x);
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
            $('#search_results .items_container').append(x + x + x + x + x + x);
            $('#search_results .more_lnk').fadeIn();
        }, 3000)
    });
}