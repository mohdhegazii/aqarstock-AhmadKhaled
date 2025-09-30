//-------------------General Functions--------------------------//
function LoadMastetFunctions() {
    GetImportantTypes(1);//Residential Types
    GetSpecialProperty();// Get Special Properties
    GetUserInfo();
    GetNotifyService();
    GetKeyWords();
    LoadCompareList();
}
function LoadCompareList() {
    //alert(ID);
    $.ajax({
        url: '/Home/CompareList/',
        datatype: "json",
        type: "get",
        data: { type: "Menu" },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divCompareList").html(data);
            ToggleComparison();
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in loading Compare List');
        }
    });
}
function GetUserInfo()
{
    $.ajax({
        url: '/Home/userinfo/',
        datatype: "json",
        type: "get",
        // data: { id: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            //  alert(data)
            $("#ulUser").html(data);
            //  return data;
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in loading userinfo');
        }
    });
}
function GetImportantTypes(id) {
    var url = "/Home/GetImportantTypes/" + id;

    $.ajax({
        url: url,//'/Districts/GetCities',
        type: "GET",
        dataType: "JSON",
        // data: { id: stateId },
        success: function (cities) {
            //  $("#ddlType").html(""); // clear before appending new list
            $.each(cities, function (i, city) {
                $("#ulResidentialList").append(
                    $('<li></li>').val(city.Id).html("<a href='" + city.URL + "'>" + city.Name + "</a>"));
            });
        }
    });
}
function GetSpecialProperty() {
    $.ajax({
        url: '/Home/GeSpecialtProperties',
        datatype: "json",
        type: "get",
        data: {  Page: 0, PageSize: 6 }
    , contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divLatestAdded").html(data);
            var swiper = SwipperThump('.Latest-Prop .swiper-container');
            SetSpecialPropSwiper(swiper);
            //stickyScrollCustome();// for property Detail Page
        },
        error: function (xhr) {
            console.log('error in Latest added for sale');
        }
    });
}
function GetPageContent(page) {
    $.ajax({
        url: '/Home/GetPageContent',
        datatype: "json",
        type: "get",
        data: { page: page }
    , contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divPageContent").html(data);
        },
        error: function (xhr) {
            console.log('error in loading Home page content');
        }
    });
}
function GetNotifyService() {
    $.ajax({
        url: '/Home/NotifyService',
        datatype: "json",
        type: "get"
    , contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divNotifyService").html(data);
            $('#divNotifyService select').selectpicker('refresh')
            SubmitNotifyService();
        },
        error: function (xhr) {
            console.log('error in loading Notify Service');
        }
    });
}
function SubmitNotifyService() {
    $("#NotifyForm").on('submit', function (e) {
        $("#btnNotify").attr("disabled", "disabled");
        e.preventDefault() // prevent the form's normal submission

        var dataToPost = $(this).serialize()

        $.post("/Home/NotifyService", dataToPost)
                .done(function (response, status, jqxhr) {
                    $("#divNotifyService").html(response);
                    SubmitNotifyService();
                    $('#divNotifyService select').selectpicker('refresh')
                    if (jqxhr.status != 201) {
                        ShowMessage("SendSuccess")
                    }
                    $("#btnNotify").removeAttr("disabled");
                    //  ShowMessage("NotifySuccess")
                    //   alert("success")
                    // this is the "success" callback
                })
                .fail(function (jqxhr, status, error) {
                    // this is the ""error"" callback

                    ShowMessage("SendFailed")
                })
    })
}
function GetKeyWords() {
    $.ajax({
        url: '/Home/FooterKeywords',
        datatype: "json",
        type: "get"
    , contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divFooterKeywords").html(data);
        },
        error: function (xhr) {
            console.log('error in loading Footer Keywords');
        }
    });
}
function GetCities(ddlcountry, ddlcity, ddldistrict, select) {
    var url = "/Home/GetCities/";
    var CountryID = $('#' + ddlcountry).val();
    $("#" + ddlcity).html(""); // clear before appending new lis
    $("#" + ddlcity).append($('<option></option>').html(select));
    $.ajax({
        url: url,//'/Districts/GetCities',
        type: "GET",
        dataType: "JSON",
        data: { CountryID: CountryID },
        success: function (cities) {
            $("#" + ddlcity).removeAttr("disabled");
            $.each(cities, function (i, city) {
                $("#" + ddlcity).append(
                    $('<option></option>').val(city.Id).html(city.Name));
            });
            selectpicker(ddlcity);
        }
    });
    $("#" + ddldistrict).html(""); // clear before appending new list
    $("#" + ddldistrict).attr("disabled", "disabled");
    $("#" + ddldistrict).append($('<option></option>').html(select));
    selectpicker(ddldistrict);
}
function GetDistricts(ddlcity, ddldistrict, select) {
    var url = "/Home/GetDistricts/";
    var CityId = $('#' + ddlcity).val();
    $("#" + ddldistrict).html(""); // clear before appending new lis
    $("#" + ddldistrict).append($('<option></option>').html(select));
    $.ajax({
        url: url,//'/Districts/GetCities',
        type: "GET",
        dataType: "JSON",
        data: { CityId: CityId },
        success: function (cities) {
            $("#" + ddldistrict).removeAttr("disabled");
            $.each(cities, function (i, city) {
                $("#" + ddldistrict).append(
                    $('<option></option>').val(city.Id).html(city.Name));
            });
            selectpicker(ddldistrict);
        }
    });
}
function ShowMessage(type) {
    $.ajax({
        url: '/Home/GetMessage/',
        datatype: "json",
        type: "get",
        data: { MsgType: type },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            //console.log(data)
            //alert(data.Msg.Title)
            $("#MsgTitle").html(data.Msg.Title);
            $("#MsgContent").html(data.Msg.Content);
            $('#divMsgModal').modal('show');
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in Showing Msg');
        }
    });

}
function SetActiveMenu(id)
{
    $("#ulMenu #" + id).addClass("active");
}
//-------------------Home Page Functions -----------------------//
function GetForSaleProperty() {
    $.ajax({
        url: '/Home/GetPropertiesBySaleType',
        datatype: "json",
        type: "get",
        data: { SaleTypeID: 1, Page: 0, PageSize: 6 }
    , contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divLatestSale").html(data);
            var swiper = SwipperThump('.forsale-Prop .swiper-container');
            SetLatestSwiper(swiper, 1);
            //stickyScrollCustome();// for property Detail Page
        },
        error: function (xhr) {
            console.log('error in Latest added for sale');
        }
    });
}
function LoadPageAds() {
   
    LoadContentAd("divFirstAd");
    LoadContentAd("divSecondAd");
}
function LoadContentAd(divAdd) {
    
    $.ajax({
        url: '/Home/ContentAd/',
        datatype: "json",
        type: "get",
        // data: { id: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
          //  alert(data)
             $("#"+divAdd).html(data);
          //  return data;
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in loading Ads');
        }
    });
}
function GetForRentProperty() {
    $.ajax({
        url: '/Home/GetPropertiesBySaleType',
        datatype: "json",
        type: "get",
        data: { SaleTypeID: 2, Page: 0, PageSize: 6 }
    , contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divLatestRent").html(data);
            var swiper = SwipperThump('.latest-rent .swiper-container');
            SetLatestSwiper(swiper, 2);
        },
        error: function (xhr) {
            console.log('error in Latest added for rent');
        }
    });
}
function SetSpecialPropSwiper(mySwiper) {
    // Init Swiper
 //   var mySwiper = SwipperThump('.swiper-SpecialProp .swiper-container');
    mySwiper.on('SlideNextStart', function () {
        var index = mySwiper.activeIndex;
        var pagesize = 3;
        var Length = (index * pagesize) + pagesize * 2;
        if (mySwiper.slides.length < Length) {
            //alert(mySwiper.activeIndex);
            $.ajax({
                url: '/Home/GetSpecialProperties/',
                datatype: "json",
                type: "get",
                data: { Page: mySwiper.activeIndex, PageSize: pagesize },
                contenttype: 'application/json; charset=utf-8',
                async: true,
                success: function (data) {
                    //    alert(data)
                    // $('.Latest-Prop .swiper-containe .swiper-wrapper').append(data);
                    if (data != "")
                        {
                    mySwiper.appendSlide(data);
                    mySwiper.slideTo(index);
                    }
                  //  mySwiper.activeIndex = index + 1;
                    if (mySwiper.slides.length-2 == index) {
                        mySwiper.lockSwipeToNext()
                    }
                },
                error: function (xhr) {
                    //console.log(xhr);
                    console.log('error in Adding Special Properties');
                }
            });
        }
        //else
        //{
        //    mySwiper.slideNext();
        //}
    });

}
function SetLatestSwiper(mySwiper, SaleTypeID) {

    // var mySwiper = new Swiper('.Latest-Prop .swiper-container');
    //  $('.Latest-Prop .swiper-container .swiper-button-next')
    mySwiper.on('SlideNextStart', function () {
        var index = mySwiper.activeIndex;
        var pagesize = 3;
        var Length = (index * pagesize) + pagesize * 2;
        if (mySwiper.slides.length < Length) {
            //  alert(mySwiper.activeIndex);
            $.ajax({
                url: '/Home/GetLatestPropertiesBySaleType/',
                datatype: "json",
                type: "get",
                data: { SaleTypeID: SaleTypeID, Page: mySwiper.activeIndex, PageSize: pagesize },
                contenttype: 'application/json; charset=utf-8',
                async: true,
                success: function (data) {
                    // $('.Latest-Prop .swiper-containe .swiper-wrapper').append(data);
                    mySwiper.appendSlide(data);
                    mySwiper.slideTo(index);
                },
                error: function (xhr) {
                    //console.log(xhr);
                    console.log('error in Adding Latest Properties');
                }
            });
        }
    });
    //mySwiper.nextButton.click(function () {
    //    //  mySwiper.slideNext();
    //    var index = mySwiper.activeIndex;
    //    var pagesize = 3;
    //    var Length = (index * pagesize) + pagesize * 2;
    //    if (mySwiper.slides.length < Length) {
    //        alert(mySwiper.activeIndex);
    //        $.ajax({
    //            url: '/Home/GetLatestProperties/',
    //            datatype: "json",
    //            type: "get",
    //            data: { SaleTypeID: 1, Page: mySwiper.activeIndex, PageSize: pagesize },
    //            contenttype: 'application/json; charset=utf-8',
    //            async: true,
    //            success: function (data) {
    //                // $('.Latest-Prop .swiper-containe .swiper-wrapper').append(data);
    //                mySwiper.appendSlide(data);
    //                mySwiper.slideTo(index);
    //            },
    //            error: function (xhr) {
    //                //console.log(xhr);
    //                console.log('error in Adding Latest for sale');
    //            }
    //        });
    //    }
    //})
}
//----------------- Properties Pages Functions -------------------------//
function showExpiredItemPopUp() {
    $("#MsgContent").html("");
    $.ajax({
        url: '/Home/Search/' ,
        datatype: "json",
        type: "get",
        data: { type: "" },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            var content = "<div><h1 style='color: red;'>عذرا هذا الاعلان انتهت صلاحيته</h1><h4 style='color: red;'>يمكنك تصفح آخر الوحدات المضافة من هنا</h4></div>";
            
            $("#MsgContent").html(content+data);
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in Expired Item PopUp');
        }
    });
    $('#divMsgModal .modal-dialog').addClass("modal-lg");
    $('#divMsgModal .modal-footer').hide();
    $('#divMsgModal .modal-header').hide();
    $('#divMsgModal').modal({
        backdrop: 'static',
        keyboard: false
    });
    //$('#divMsgModal').modal('handleUpdate');
}
function GetStatus(ddlType, ddlStatus, select) {
    var url = "/Home/GetStatus/";
    var CountryID = $('#' + ddlType).val();
    $("#" + ddlStatus).html(""); // clear before appending new lis
    $("#" + ddlStatus).append($('<option></option>').html(select));
    $.ajax({
        url: url,//'/Districts/GetCities',
        type: "GET",
        dataType: "JSON",
        data: { TypeId: CountryID },
        success: function (cities) {
            $("#" + ddlStatus).removeAttr("disabled");
            $.each(cities, function (i, city) {
                $("#" + ddlStatus).append(
                    $('<option></option>').val(city.Id).html(city.Name));
            });
            selectpicker(ddlStatus);
        }
    });
}
function LoadPropertySearch(type) {
    $.ajax({
        url: '/Home/Search/',
        datatype: "json",
        type: "get",
        data: { type: type },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divSearch").html(data);
            $('.search-wrapper select').selectpicker('refresh')
    
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in loading Search');
        }
    });
}
function ShowComplainForm() {
    $('#myModalComplain').modal('show');
    SubmitComplain();
}
function SubmitComplain() {

    $("#ComplainForm").on('submit', function (e) {
        $("#btnSendComplain").attr("disabled", "disabled");
        e.preventDefault() // prevent the form's normal submission

        var dataToPost = $(this).serialize()

        $.post("/Home/SendComplain", dataToPost)
                .done(function (response, status, jqxhr) {
                    $("#divComplain").html(response);
                    SubmitComplain();
                    // alert(jqxhr.status)
                    if (jqxhr.status != 201) {
                        ShowMessage("SendSuccess");
                        $('#myModalComplain').modal('hide');
                    }
                    $("#btnSendComplain").removeAttr("disabled");
                    //   alert("success")
                    // this is the "success" callback
                })
                .fail(function (jqxhr, status, error) {
                    // this is the ""error"" callback
                    ShowMessage("SendFailed");
                    $("#btnSendComplain").removeAttr("disabled");
                })
    })
}
function SubmitRequest() {

    $("#RequestForm").on('submit', function (e) {
        $("#btnSendRequest").attr("disabled", "disabled");
        e.preventDefault() // prevent the form's normal submission

        var dataToPost = $(this).serialize()

        $.post("/Home/SendRequest", dataToPost)
                .done(function (response, status, jqxhr) {
                    $("#divRequest").html(response);
                    SubmitRequest();
                    // alert(jqxhr.status)
                    if (jqxhr.status != 201) {
                        ShowMessage("SendSuccess");
                    }
                    $("#btnSendRequest").removeAttr("disabled");
                    //   alert("success")
                    // this is the "success" callback
                })
                .fail(function (jqxhr, status, error) {
                    // this is the ""error"" callback
                    ShowMessage("SendFailed")
                    $("#btnSendRequest").removeAttr("disabled");
                })
    })
}
function AddToCompareList(ID) {
    $("#btnCompare").attr("disabled", "disabled");
    $.ajax({
        url: '/Home/AddToCompareList/',
        datatype: "json",
        type: "get",
        data: { id: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            //  alert("test")
            $("#divCompareList").html();
            $("#divCompareList").html(data);
            ToggleComparison();
            $("#btnCompare").removeAttr("disabled");
        },
        error: function (xhr) {
            ShowMessage("AddingCompareProp");
            console.log('error in loading Add to Compare List');
        }
    });
}
function RemoveFromCompareList(ID) {
    $.ajax({
        url: '/Home/RemoveFromCompareList/',
        datatype: "json",
        type: "get",
        data: { id: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            //  alert("test")
            $("#divCompareList").html();
            $("#divCompareList").html(data);
            ToggleComparison();
        },
        error: function (xhr) {
            ShowMessage("RemocingCompareProp");
            console.log('error in loading Remove from Compare List');
        }
    });
}
function AddToFavourite(ID) {
    $("#btnFavourite").attr("disabled", "disabled");
    $.ajax({
        url: '/Home/AddToFavorite/',
        datatype: "json",
        type: "get",
        data: { ID: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            if (data.Response.status == "Success") {
                ShowMessage("AddingFavorite");
            }
            else {
                ShowMessage("AddingFavoriteError");
            }
            $("#btnFavourite").removeAttr("disabled");
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in Add to Favourite');
        }
    });

}
function ShowComplainForm() {
    $('#myModalComplain').modal('show');
    SubmitComplain();
}
function GetPropertyowner() {
    var realestateID = $("#hdID").val();
    $.ajax({
        url: '/Home/GetPropertyOwner',
        datatype: "json",
        type: "get",
        data: { id: realestateID }
    , contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divOwnerData").html(data);
            stickyScrollCustome();
        },
        error: function (xhr) {
            console.log('error in loading ownerdata');
        }
    });
}
function ShowLoginForm() {
    $('#myModalLogin').modal('show');
    SubmitLogin();
}
function SubmitLogin() {

    $("#LoginForm").on('submit', function (e) {
        $("#btnLogin").attr("disabled", "disabled");
        e.preventDefault() // prevent the form's normal submission

        var dataToPost = $(this).serialize()

        $.post("/Home/PropertyLogin", dataToPost)
                .done(function (response, status, jqxhr) {
                    $("#divLoginForm").html(response);
                    SubmitLogin();
                    if (jqxhr.status != 201) {
                        location.reload();
                    }
                    $("#btnLogin").removeAttr("disabled");
                    // this is the "success" callback
                })
                .fail(function (jqxhr, status, error) {
                    alert("fail")
                    // this is the ""error"" callback
                    ShowMessage("SendFailed")
                    $("#btnLogin").removeAttr("disabled");
                })
    })
}
function GetRegister() {
    var realestateID = $("#hdID").val();
    var ProjectID = $("#hdProjectID").val();
    var CompanyID = $("#hdCompanyID").val();
    var Type = $("#hdType").val();
    $.ajax({
        url: '/Home/PropertyRegister',
        datatype: "json",
        type: "get",
        data: { Type: Type, realestateID: realestateID, ProjectID: ProjectID, CompanyID: CompanyID }
    , contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divLoginForm").html(data);
            SubmitRegister();
        },
        error: function (xhr) {
            console.log('error in loading Register');
        }
    });
}
function GetLogin() {
    var realestateID = $("#hdID").val();
    $.ajax({
        url: '/Home/PropertyLogin',
        datatype: "json",
        type: "get",
        data: { realestateID: realestateID }
    , contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divLoginForm").html(data);
            SubmitLogin();
        },
        error: function (xhr) {
            console.log('error in loading Login');
        }
    });
}
function SubmitRegister() {

    $("#RegisterForm").on('submit', function (e) {
        $("#btnRegister").attr("disabled", "disabled");
        e.preventDefault() // prevent the form's normal submission

        var dataToPost = $(this).serialize()

        $.post("/Home/PropertyRegister", dataToPost)
                .done(function (response, status, jqxhr) {
                    $("#divLoginForm").html(response);
                    SubmitRegister();
                    // alert(jqxhr.status)
                    if (jqxhr.status != 201) {
                        ShowMessage("SendAccount")
                        GetLogin();
                    }
                    $("#btnRegister").removeAttr("disabled");
                    //   alert("success")
                    // this is the "success" callback
                })
                .fail(function (jqxhr, status, error) {
                    // this is the ""error"" callback
                    ShowMessage("SendFailed")
                    $("#btnRegister").removeAttr("disabled");
                })
    })
}
//function ActivateAccount() {
//    $("#btnActivate").attr("disabled", "disabled");
//    var SubscriberId = $("#SubscriberId").val();
//    var Code = $("#Code").val();
//    var realestateID = $("#hdID").val();
//    $.ajax({
//        url: '/Home/ActivateUser',
//        datatype: "json",
//        type: "get",
//        data: { SubscriberId: SubscriberId, Code: Code, realestateID: realestateID }
//      , contenttype: 'application/json; charset=utf-8',
//        async: true,
//        success: function (data, jqxhr) {
//            if (jqxhr.status != 201) {
//                location.reload();
//            }
//            $("#divLoginForm").html(data);
//            $("#btnActivate").removeAttr("disabled");
//        },
//        error: function (xhr) {
//            console.log('error in loading Activate');
//            $("#btnActivate").removeAttr("disabled");
//        }
//    });
//}
//function ResendActiveCode() {
//    $("#btnResendCode").attr("disabled", "disabled");
//    var SubscriberId = $("#SubscriberId").val();
//    var Code = $("#Code").val();
//    var realestateID = $("#hdID").val();
//    $.ajax({
//        url: '/Home/Resend',
//        datatype: "json",
//        type: "get",
//        data: { SubscriberId: SubscriberId }
//      , contenttype: 'application/json; charset=utf-8',
//        async: true,
//        success: function (data) {
//            $("#divLoginForm").html(data);
//            $("#btnResendCode").removeAttr("disabled");
//        },
//        error: function (xhr) {
//            console.log('error in Resend Activat');
//            $("#btnResendCode").removeAttr("disabled");
//        }
//    });
//}

//------------------- Projects Page -------------------------//
function GetProjectProperties(id) {
    $.ajax({
        url: '/Home/PropertyByProject/"',
        datatype: "json",
        type: "get",
        data: { ProjectID: id, Type: "InDetails", page: 1 },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divProjectRealestates").html(data);

        },
        error: function (xhr) {
            console.log(xhr);
            //console.log('error in Add to Favourite');
        }
    });
}
function GetProjectModels(id) {
    $.ajax({
        url: '/Home/ProjectModels/"',
        datatype: "json",
        type: "get",
        data: { ProjectID: id, Type: "InDetails", page: 1 },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divModels").html(data);

        },
        error: function (xhr) {
            console.log(xhr);
            //console.log('error in Add to Favourite');
        }
    });
}

function SubmitMessage() {

    $("#MessageForm").on('submit', function (e) {
        $("#btnSendMessage").attr("disabled", "disabled");
        e.preventDefault() // prevent the form's normal submission

        var dataToPost = $(this).serialize()

        $.post("/Home/SendCompanyMessage", dataToPost)
                .done(function (response, status, jqxhr) {
                    $("#divCompanyMessage").html(response);
                    SubmitMessage();
                    // alert(jqxhr.status)
                    if (jqxhr.status != 201) {
                        ShowMessage("SendSuccess");
                    }
                    $("#btnSendMessage").removeAttr("disabled");
                    //   alert("success")
                    // this is the "success" callback
                })
                .fail(function (jqxhr, status, error) {
                   // alert(error)
                    // this is the ""error"" callback
                    ShowMessage("SendFailed")
                    $("#btnSendMessage").removeAttr("disabled");
                })
    })
}
//------------------- Company Page -------------------------//
function GetCompanyProperties(id) {
    $.ajax({
        url: '/Home/PropertyByCompany/"',
        datatype: "json",
        type: "get",
        data: { CompanyID: id, Type: "InDetails", page: 1 },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divCompanyRealestates").html(data);

        },
        error: function (xhr) {
            console.log(xhr);
            //console.log('error in Add to Favourite');
        }
    });
}
function GetCompanyProjects(id) {
    $.ajax({
        url: '/Home/CompanyProjects/"',
        datatype: "json",
        type: "get",
        data: { CompanyID: id, Type: "InDetails", page: 1 },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divCompanyProjects").html(data);

        },
        error: function (xhr) {
            console.log(xhr);
            //console.log('error in Add to Favourite');
        }
    });
}
//------------------- Register Page -------------------------//

function ShowConditionForm() {
    $('#divConditionModal').modal('show');
}
//------------------- CatalogPage---------------------------//
function ShowTags(tags)
{
    $("#divPageContent").html($("#divtag").html());
}
function GetCatalogProperyies(ID)
{
    $.ajax({
        url: '/Home/CatalogProperties/',
        datatype: "json",
        type: "get",
        data: { ID: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#catalogProperties").html(data);

        },
        error: function (xhr) {
            console.log(xhr);
            //console.log('error in Add to Favourite');
        }
    });
}
$(document).on('invalid-form.validate', 'form', function () {
    var buttons = $(this).find('[type="submit"]');
    setTimeout(function () {
        buttons.removeAttr('disabled');
    }, 1);
});
$(document).on('submit', 'form', function () {
    var buttons = $(this).find('[type="submit"]');
    console.log(buttons);
    setTimeout(function () {
        buttons.attr('disabled', 'disabled');
        console.log(buttons);
    }, 0);
});