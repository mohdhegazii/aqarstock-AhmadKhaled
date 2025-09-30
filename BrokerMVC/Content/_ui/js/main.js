
(function ($) {

    var App = {

        /**
		 * Init Function
		 */
        init: function () {
            $("body").removeClass("no-js");
            App.testFunction();
            //App.fullBackground();
            App.swiperThumb();
            App.swiperThumbRelated();
            App.equalDivsHeight();
            App.scrollToDiv();
            App.navPosition();
            App.selectCustome();
            App.appFlexSlider();
            App.stickyScrollCustome();
            App.comparesionToggle();
			//App.comparesionTable();
			App.contactMassLauncher();
            //App.modalLuncher();
        },

        /**
		 * Custom Form Style
		 */
        testFunction: function () {

        },

        /**
		 * fullBackground
		 */
        fullBackground: function () {
            $(".full-size-img").each(function () {
                var width = $(window).width();
                var height = $(window).height();
                $(this).css("width", width);
                $(this).css("height", height);

                $(".search-wrapper").css("height", height - 169);
            });
            $(window).resize(function () {
                $(".full-size-img").each(function () {
                    var width = $(window).width();
                    var height = $(window).height();
                    var imgwidth = $(this).width();
                    var imgheight = $(this).height();
                    //console.log((imgwidth - width) / 2);
                    $(this).css("margin-left", -(imgwidth - width) / 2);
                    $(this).css("margin-top", -(imgheight - height) / 2);
                });
            });
        },


        /**
		* swiperThumb
		*/
        swiperThumb: function () {
            var swiper = new Swiper('.swiper-container', {
                pagination: '.swiper-pagination',
                paginationClickable: true,
                nextButton: '.swiper-button-next',
                prevButton: '.swiper-button-prev',
                slidesPerView: 3,
                spaceBetween: 30,
                breakpoints: {
                    1024: {
                        slidesPerView: 2,
                        spaceBetween: 30
                    },
                    768: {
                        slidesPerView: 2,
                        spaceBetween: 15
                    },
                    640: {
                        slidesPerView: 2,
                        spaceBetween: 15
                    },
                    320: {
                        slidesPerView: 1,
                        spaceBetween: 15
                    }
                }
            });
        },

        /**
		* swiperThumb
		*/
        swiperThumbRelated: function () {
            var swiper = new Swiper('.swiper-container-Related', {
                pagination: '.swiper-pagination',
                paginationClickable: true,
                nextButton: '.swiper-button-next',
                prevButton: '.swiper-button-prev',
                slidesPerView: 4,
                spaceBetween: 30,
                breakpoints: {
                    1024: {
                        slidesPerView: 4,
                        spaceBetween: 30
                    },
                    768: {
                        slidesPerView: 2,
                        spaceBetween: 15
                    },
                    640: {
                        slidesPerView: 2,
                        spaceBetween: 15
                    },
                    320: {
                        slidesPerView: 1,
                        spaceBetween: 15
                    }
                }
            });
        },

        /**
		* equalDivsHeight
		*/
        equalDivsHeight: function () {
            var aDivHeight = $(".thumbnail.thumbnail-list .caption").height();

            $(".img-listing-background").css("height", aDivHeight);

        },

        /*
		* scroll To Div
		*/
        scrollToDiv: function () {
            $(".go-up").click(function () {
                $('html, body').animate({
                    scrollTop: $(".inner-banner,.main-banner").offset().top
                }, 1000);
                return false;
            });

            $(".go-to-search").click(function () {
                $('html, body').animate({
                    scrollTop: $(".search-wrapper").offset().top
                }, 1000);
                return false;
            });

            $(".slideToMap").click(function () {
                $('html, body').animate({
                    scrollTop: $(".map-wrapper").offset().top
                }, 1000);
                return false;
            });


        },

        /*
		* navPosition
		*/
		navPosition: function() {
			var headerHeight = $('header').height();
			var innerBannerHeight = $('.inner-banner').height();
			var searchAsideHeight = $('.search-aside').height();
			
			$(window).scroll(function() {
				if ($(window).scrollTop() >= ( headerHeight - 41)) {
					$('.navbar.navbar-custome').addClass('navbar-fixed-top');
				} else {
					$('.navbar.navbar-custome').removeClass('navbar-fixed-top');
				}
			});
			if($(window).width() >= 769){
				$(window).scroll(function() {
					if ($(window).scrollTop() >= ( headerHeight - 41)) {
						$('.navbar-header > .navbar-brand').css('width','73px');
					} else {
						$('.navbar-header > .navbar-brand').css('width','0');
					}
				});
			}
		},

        /*
		* selectCustome
		*/
        selectCustome: function () {
            $('.selectpicker').selectpicker({
                style: 'btn-info',
                size: 5
            })
        },

        /*
		* appFlexSlider
		*/
        appFlexSlider: function () {
            $('.flex-carousel').flexslider({
                animation: "slide",
                controlNav: !1,
                animationLoop: !1,
                slideshow: !1,
                itemWidth: 220,
                itemMargin: 16,
                asNavFor: ".flex-slider",
                prevText: '<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16.5 30.1" enable-background="new 0 0 16.5 30.1"><path d="M15 30.1L0 15 15 0l1.5 1.4L2.8 15l13.7 13.7z"/></svg>',
                nextText: '<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16.5 30.1" enable-background="new 0 0 16.5 30.1"><path d="M1.4 30.1L0 28.7 13.6 15 0 1.4 1.4 0l15.1 15z"/></svg>'
            });

            $('.flex-slider').flexslider({
                animation: "slide",
                controlNav: !1,
                animationLoop: !0,
                slideshow: !1,
                sync: ".flex-carousel",
                prevText: '<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16.5 30.1" enable-background="new 0 0 16.5 30.1"><path d="M15 30.1L0 15 15 0l1.5 1.4L2.8 15l13.7 13.7z"/></svg>',
                nextText: '<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16.5 30.1" enable-background="new 0 0 16.5 30.1"><path d="M1.4 30.1L0 28.7 13.6 15 0 1.4 1.4 0l15.1 15z"/></svg>'
            });


        },

        /*
		* stickyScrollCustome
		*/
		stickyScrollCustome: function () {
			if($(window).width() >= 769){
				if ($('.owner-contact-wrapper').length) { // make sure "#sticky" element exists
					var el = $('.owner-contact-wrapper');
					var stickyTop = $('.owner-contact-wrapper').offset().top; // returns number
					var stickyHeight = $('.owner-contact-wrapper').height();

					var widthScreen = $(window).width();
					var containerScreen = $(".container").width();

					var marginSpace = widthScreen - containerScreen + 30;

					$(window).scroll(function () { // scroll event
					    var limit = $('.latest-Prop').offset().top - stickyHeight - 20;
						var windowTop = $(window).scrollTop(); // returns number
						if (stickyTop < windowTop) {
							el.css({ position: 'fixed', top: 42 });
							//$(el).css('left', widthScreen - containerScreen );
							$(el).css('left', marginSpace / 2);
						}
						else {
							el.css('position', 'static');
						}
						if (limit < windowTop) {
							var diff = limit - windowTop;
							el.css({ top: diff });
						}
					});
				}
			}
			$(window).resize(function () {
				if($(window).width() >= 769){
					if ($('.owner-contact-wrapper').length) { // make sure "#sticky" element exists
						var el = $('.owner-contact-wrapper');
						var stickyTop = $('.owner-contact-wrapper').offset().top; // returns number
						var stickyHeight = $('.owner-contact-wrapper').height();
	
						var widthScreen = $(window).width();
						var containerScreen = $(".container").width();
	
						var marginSpace = widthScreen - containerScreen + 30;
	
						$(window).scroll(function () { // scroll event
						    var limit = $('.latest-Prop').offset().top - stickyHeight - 20;
							var windowTop = $(window).scrollTop(); // returns number
							if (stickyTop < windowTop) {
								el.css({ position: 'fixed', top: 42 });
								//$(el).css('left', widthScreen - containerScreen );
								$(el).css('left', marginSpace / 2);
							}
							else {
								el.css('position', 'static');
							}
							if (limit < windowTop) {
								var diff = limit - windowTop;
								el.css({ top: diff });
							}
						});
					}
				}
			});	
        },


        /*
		* Comparesion Toggle
		*/
        comparesionToggle: function () {
            $(".call-comparesion-list").click(function () {
                $(".comparesion-list").toggleClass("open");
            });
        },

        /*
		* modalLuncher
		*/
        modalLuncher: function () {
            $('#myModal').on('hidden', function () {
                $('#myModalNew').modal('show')
            })
        },
		
		
		/*
		* Comparesion Table
		*/
		comparesionTable: function() {
			var C = $('.comparesion-wrapper .table-responsive').length;
			$(".comparesion-wrapper .table-responsive").width(1080 / C);
			
			
			
			//set the starting bigestHeight variable  
			var biggestHeight = 0;  
			$('.table-responsive tr:first-child td').each(function(){  
				if($(this).height() > biggestHeight){  
					biggestHeight = $(this).height();  
				}  
			});  
			$('.table-responsive tr:first-child td').height(biggestHeight);
			
			
			var biggestHeight2 = 0;  
			$('.table-responsive tr:nth-child(2) td').each(function(){  
				if($(this).height() > biggestHeight2){  
					biggestHeight2 = $(this).height();  
				}  
			});  
			$('.table-responsive tr:nth-child(2) td').height(biggestHeight2);
			
			var biggestHeight3 = 0;  
			$('.table-responsive tr:nth-child(3) td').each(function(){  
				if($(this).height() > biggestHeight3){  
					biggestHeight3 = $(this).height();  
				}  
			});  
			$('.table-responsive tr:nth-child(3) td').height(biggestHeight3);
			
			var biggestHeight4 = 0;  
			$('.table-responsive tr:nth-child(4) td').each(function(){  
				if($(this).height() > biggestHeight4){  
					biggestHeight4 = $(this).height();  
				}  
			});  
			$('.table-responsive tr:nth-child(4) td').height(biggestHeight4);
			
			var biggestHeight5 = 0;  
			$('.table-responsive tr:nth-child(5) td').each(function(){  
				if($(this).height() > biggestHeight5){  
					biggestHeight5 = $(this).height();  
				}  
			});  
			$('.table-responsive tr:nth-child(4) td').height(biggestHeight5);
			
			var biggestHeight6 = 0;  
			$('.table-responsive tr:nth-child(6) td').each(function(){  
				if($(this).height() > biggestHeight6){  
					biggestHeight6 = $(this).height();  
				}  
			});  
			$('.table-responsive tr:nth-child(6) td').height(biggestHeight6);
			
			var biggestHeight7 = 0;  
			$('.table-responsive tr:nth-child(7) td').each(function(){  
				if($(this).height() > biggestHeight7){  
					biggestHeight7 = $(this).height();  
				}  
			});  
			$('.table-responsive tr:nth-child(7) td').height(biggestHeight7);
			
			var biggestHeight8 = 0;  
			$('.table-responsive tr:nth-child(8) td').each(function(){  
				if($(this).height() > biggestHeight8){  
					biggestHeight8 = $(this).height();  
				}  
			});  
			$('.table-responsive tr:nth-child(8) td').height(biggestHeight8);
			
			var biggestHeight9 = 0;  
			$('.table-responsive tr:nth-child(9) td').each(function(){  
				if($(this).height() > biggestHeight9){  
					biggestHeight9 = $(this).height();  
				}  
			});  
			$('.table-responsive tr:nth-child(9) td').height(biggestHeight9);
			
			var biggestHeight10 = 0;  
			$('.table-responsive tr:nth-child(10) td').each(function(){  
				if($(this).height() > biggestHeight10){  
					biggestHeight10 = $(this).height();  
				}  
			});  
			$('.table-responsive tr:nth-child(10) td').height(biggestHeight10);
			
			var biggestHeight11 = 0;  
			$('.table-responsive tr:nth-child(11) td').each(function(){  
				if($(this).height() > biggestHeight11){  
					biggestHeight11 = $(this).height();  
				}  
			});  
			$('.table-responsive tr:nth-child(11) td').height(biggestHeight11);
			
			var biggestHeight12 = 0;  
			$('.table-responsive tr:nth-child(12) td').each(function(){  
				if($(this).height() > biggestHeight12){  
					biggestHeight12 = $(this).height();  
				}  
			});  
			$('.table-responsive tr:nth-child(12) td').height(biggestHeight12);
			
			var biggestHeight13 = 0;  
			$('.table-responsive tr:nth-child(13) td').each(function(){  
				if($(this).height() > biggestHeight13){  
					biggestHeight13 = $(this).height();  
				}  
			});  
			$('.table-responsive tr:nth-child(13) td').height(biggestHeight13);
			
			var biggestHeight14 = 0;  
			$('.table-responsive tr:nth-child(14) td').each(function(){  
				if($(this).height() > biggestHeight14){  
					biggestHeight14 = $(this).height();  
				}  
			});  
			$('.table-responsive tr:nth-child(14) td').height(biggestHeight14);
			
			var biggestHeight15 = 0;  
			$('.table-responsive tr:nth-child(15) td').each(function(){  
				if($(this).height() > biggestHeight15){  
					biggestHeight15 = $(this).height();  
				}  
			});  
			$('.table-responsive tr:nth-child(15) td').height(biggestHeight15);
			
			
		},

		/*
		* contactMassLauncher
		*/
        contactMassLauncher: function () {
            $(".contact-mass-wrapper-launch").click(function(){			
				$(".owner-mass-wrapper").toggleClass("open");
				$(".contact-mass-wrapper-launch").toggleClass("change-btn");
			});	
        },
		


    }



    $(function () {
        App.init();
    });

})(jQuery);
function SwipperThump(swipper) {
    var swiper = new Swiper(swipper, {
        pagination: '.swiper-pagination',
        paginationClickable: true,
        nextButton: '.swiper-button-next',
        prevButton: '.swiper-button-prev',
        slidesPerView: 3,
        spaceBetween: 30,
        breakpoints: {
            1024: {
                slidesPerView: 2,
                spaceBetween: 30
            },
            768: {
                slidesPerView: 2,
                spaceBetween: 15
            },
            640: {
                slidesPerView: 2,
                spaceBetween: 15
            },
            320: {
                slidesPerView: 1,
                spaceBetween: 15
            }
        }
    });
    return swiper;
}
function stickyScrollCustome() {
	if($(window).width() >= 769){
		if ($('.owner-contact-wrapper').length) { // make sure "#sticky" element exists
			var el = $('.owner-contact-wrapper');
			var stickyTop = $('.owner-contact-wrapper').offset().top; // returns number
			var stickyHeight = $('.owner-contact-wrapper').height();
	
			var widthScreen = $(window).width();
			var containerScreen = $(".container").width();
	
			var marginSpace = widthScreen - containerScreen + 30;
	
			$(window).scroll(function () { // scroll event
				var limit = $('.latest-unit').offset().top - stickyHeight - 20;
				var windowTop = $(window).scrollTop(); // returns number
				if (stickyTop < windowTop) {
					el.css({ position: 'fixed', top: 42 });
					//$(el).css('left', widthScreen - containerScreen );
					$(el).css('left', marginSpace / 2);
				}
				else {
					el.css('position', 'static');
				}
				if (limit < windowTop) {
					var diff = limit - windowTop;
					el.css({ top: diff });
				}
			});
		}
    }
	$(window).resize(function () {
				if($(window).width() >= 769){
					if ($('.owner-contact-wrapper').length) { // make sure "#sticky" element exists
						var el = $('.owner-contact-wrapper');
						var stickyTop = $('.owner-contact-wrapper').offset().top; // returns number
						var stickyHeight = $('.owner-contact-wrapper').height();
	
						var widthScreen = $(window).width();
						var containerScreen = $(".container").width();
	
						var marginSpace = widthScreen - containerScreen + 30;
	
						$(window).scroll(function () { // scroll event
						    var limit = $('.latest-Prop').offset().top - stickyHeight - 20;
							var windowTop = $(window).scrollTop(); // returns number
							if (stickyTop < windowTop) {
								el.css({ position: 'fixed', top: 42 });
								//$(el).css('left', widthScreen - containerScreen );
								$(el).css('left', marginSpace / 2);
							}
							else {
								el.css('position', 'static');
							}
							if (limit < windowTop) {
								var diff = limit - windowTop;
								el.css({ top: diff });
							}
						});
					}
				}
			});
}
function selectpicker(ddl) {
   // alert(ddl)
    $('#' + ddl).selectpicker('refresh')
   // $('#' + ddl).selectpicker('render')
    //$('#' + ddl).selectpicker({
    //    style: 'btn-info',
    //    size: 2
    //})
}
function ToggleComparison()
{
    $(".call-comparesion-list").click(function () {
        $(".comparesion-list").toggleClass("open");
    });
}


