//------- Start: Map Loader Scripts--------------------//
function SetLatlngControls(lat, lng) {
    $("#Latitude").val(lat)
    if ($("#Longitude") != null) {
        $("#Longitude").val(lng)
    }
    if ($("#Longutide") != null) {
        $("#Longutide").val(lng)
    }
}
//----------- General Functions-------------------------//
var ConfirmDeleteMsg = "";
function SetConfirmDeleteMsg(Msg) {
    ConfirmDeleteMsg = Msg;
}
function ConfirmDelete(div) {
    $(div + ' .Deleteconfirm').click(function () {
        return confirm(ConfirmDeleteMsg);
    });
}
function GetRealEstateTypes(id) {
    var url = "/RealEstateTypes/GetTypes/"; //+ id;
    
    $.ajax({
        url: "/RealEstateTypes/GetTypes/",//'/Districts/GetCities',
        type: "GET",
        dataType: "JSON",
        data: { id: id },
        success: function (cities) {
          //  alert("success")
            $("#ddlType").html(""); // clear before appending new list
            $.each(cities, function (i, city) {
                $("#ddlType").append(
                    $('<option></option>').val(city.Id).html(city.Name));
            });
        }
    });
}
function GetRealEstateStatus(id) {
    var url = "/RealEstateStatus/GetStatus/" + id;

    $.ajax({
        url: url,//'/Districts/GetCities',
        type: "GET",
        dataType: "JSON",
        // data: { id: stateId },
        success: function (cities) {
            $("#ddlStatus").html(""); // clear before appending new list
            $.each(cities, function (i, city) {
                $("#ddlStatus").append(
                    $('<option></option>').val(city.Id).html(city.Name));
            });
        }
    });
}
function GetTypes() {
    var stateId = $('#CategoryId').val();
    GetRealEstateTypes(stateId);

}
function ChangeCtaegory() {
    var ID = $('#RealEstateCategoryID').val();
    
    GetRealEstateTypes(ID);
    GetRealEstateStatus(ID);
}
function GetUserMsgsNo() {
    var url = "/AdminDashBoard/GetNewMsgByUser/";

    $.ajax({
        url: url,//'/Districts/GetCities',
        type: "GET",
        dataType: "JSON",
        // data: { id: stateId },
        success: function (data) {
            $("#spanComplainNo").html(""); // clear before appending new list
            $("#spanMessageNo").html("");
            $("#spanComplainNo").html(data.ComplainsNo);
            $("#spanMessageNo").html(data.MsgNo);
        }
    });
}
//---------- Company Functions--------------------//
function LoadCompanyUsers(ID) {
    // console.log(ID);
    $.ajax({
        url: '/RealEstateCompanies/GetCompanyUserList/' + ID,
        datatype: "json",
        type: "get",
        // data: { id: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divUsers").html(data);
            ConfirmDelete("#divUsers");
            $('[data-toggle="tooltip"]').tooltip();
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in loading Users');
        }
    });
}
function LoadCompanyProjects(ID) {
    // console.log(ID);
    $.ajax({
        url: '/RealEstateCompanies/GetCompanyProjectList/' + ID,
        datatype: "json",
        type: "get",
        // data: { id: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divProjects").html(data);
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in loading Projects');
        }
    });
}
function EditCompanyUserNo(ID) {
    $("#divModalContent").html("");
    $.ajax({
        url: '/RealEstateCompanies/EditCompanyUserNo/' + ID,
        datatype: "json",
        type: "get",
        // data: { id: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divModalContent").html(data);
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in loading Users');
        }
    });
}
function EditCompanyProjectNo(ID) {
    $("#divModalContent").html("");
    $.ajax({
        url: '/RealEstateCompanies/EditCompanyProjectNo/' + ID,
        datatype: "json",
        type: "get",
        // data: { id: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divModalContent").html(data);
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in loading Projects');
        }
    });
}
function SuspendCompany(ID) {
    $("#divModalContent").html("");
    $.ajax({
        url: '/RealEstateCompanies/Suspend/' + ID,
        datatype: "json",
        type: "get",
        // data: { id: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divModalContent").html(data);
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in SuspendCompany');
        }
    });
}
//------------ Project Function------------------//

function SuspendProject(ID) {
    $("#divModalContent").html("");
    $.ajax({
        url: '/RealEstateProjects/Suspend/' + ID,
        datatype: "json",
        type: "get",
        // data: { id: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divModalContent").html(data);
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in Suspend Project');
        }
    });
}
function LoadProjectViews(ID) {
    LoadProjectModels(ID);
    LoadProjectPhotos(ID);
    LoadProjectRealEstates(ID);
    LoadProjectVideos(ID);

}
function LoadProjectPhotos(ID) {
    // console.log(ID);
    $.ajax({
        url: '/RealEstateProjects/ProjectPhotos/' + ID + '?type=slider',
        datatype: "json",
        type: "get",
        // data: { type: 'slider' },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divPhotos").html(data);
            //$(".carousel-indicators li:first").addClass("active");
            $(".carousel-inner div:first").addClass("active");
            //  InitializeSlider();
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in loading Photos');
        }
    });
}
function LoadProjectVideos(ID) {
    // console.log(ID);
    $.ajax({
        url: '/RealEstateProjects/ProjectVideos/' + ID,
        datatype: "json",
        type: "get",
        // data: { type: 'slider' },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divVideos").html(data);
            ConfirmDelete("#divVideos");
            // DeleteConfirmaion();
            //  InitializeSlider();
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in loading Videos');
        }
    });
}
function LoadProjectModels(ID) {
    // console.log(ID);
    $.ajax({
        url: '/RealEstateProjects/ProjectModels/' + ID,
        datatype: "json",
        type: "get",
        // data: { type: 'slider' },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divModels").html(data);
            ConfirmDelete("#divModels");
            //   DeleteConfirmaion();
            //  InitializeSlider();
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in loading Models');
        }
    });
}
function LoadProjectRealEstates(ID) {
    // console.log(ID);
    $.ajax({
        url: '/RealEstateProjects/ProjectRealEstates/' + ID,
        datatype: "json",
        type: "get",
        // data: { type: 'slider' },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divRealEstates").html(data);
            ConfirmDelete("#divRealEstates");
            //  InitializeSlider();
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in loading RealEstates');
        }
    });
}
function AddNewProjectPhoto(ID) {
    $("#divModalContent").html("");
    $.ajax({
        url: '/RealEstateProjectPhotoes/Create/' + ID,
        datatype: "json",
        type: "get",
        // data: { id: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divModalContent").html(data);
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in New Project Photo');
        }
    });
}
function EditProjectPhoto(ID) {
    $("#divModalContent").html("");
    $.ajax({
        url: '/RealEstateProjectPhotoes/Edit/' + ID,
        datatype: "json",
        type: "get",
        // data: { id: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divModalContent").html(data);
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in Edit Project Photo');
        }
    });
}
function AddNewProjectVideo(ID) {
    $("#divModalContent").html("");
    $.ajax({
        url: '/RealEstateProjectVideos/Create/' + ID,
        datatype: "json",
        type: "get",
        // data: { id: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divModalContent").html(data);
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in New Project Video');
        }
    });
}
function EditProjectVideo(ID) {
    $("#divModalContent").html("");
    $.ajax({
        url: '/RealEstateProjectVideos/Edit/' + ID,
        datatype: "json",
        type: "get",
        // data: { id: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divModalContent").html(data);
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in Edit Project Video');
        }
    });
}
//------------ Subscriber Function------------------//
function LoadUserRealEstates(ID) {
    // console.log(ID);
    $.ajax({
        url: '/Subscribers/SubscriberLatestRealestates/' + ID,
        datatype: "json",
        type: "get",
        // data: { type: 'slider' },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divRealEstates").html(data);
            ConfirmDelete("#divRealEstates");
            //  InitializeSlider();
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in loading RealEstates');
        }
    });
}
function SuspendUser(ID) {
    $("#divModalContent").html("");
    $.ajax({
        url: '/Subscribers/Suspend/' + ID,
        datatype: "json",
        type: "get",
        // data: { id: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divModalContent").html(data);
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in Suspend user');
        }
    });
}

function ResetPassword(ID) {
    $("#divModalContent").html("");
    $.ajax({
        url: '/Subscribers/ResetPassword/' + ID,
        datatype: "json",
        type: "get",
        // data: { id: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divModalContent").html(data);
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in reset password');
        }
    });
}
//------------- RealEstate Functions-----------------------//
function AddNewRealEstatePhoto(ID) {
    $("#divModalContent").html("");
    $.ajax({
        url: '/RealEstates/AddPhoto/' + ID,
        datatype: "json",
        type: "get",
        // data: { id: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divModalContent").html(data);
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in New Photo');
        }
    });
}
function AddRealEstateOwner(ID) {
    $("#divModalContent").html("");
    $.ajax({
        url: '/RealEstates/AddOwnerData/' + ID,
        datatype: "json",
        type: "get",
        // data: { id: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divModalContent").html(data);
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in Add Owner');
        }
    });
}
function SuspendRealestate(ID) {
    $("#divModalContent").html("");
    $.ajax({
        url: '/RealEstates/Suspend/' + ID,
        datatype: "json",
        type: "get",
        // data: { id: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divModalContent").html(data);
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in Suspend Realestate');
        }
    });
}
function EditRealEstateCriteria(ID) {
    $("#divModalContent").html("");
    $.ajax({
        url: '/RealEstates/EditCriterias/' + ID,
        datatype: "json",
        type: "get",
        // data: { id: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divModalContent").html(data);
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in Edit Criteria');
        }
    });
}
function EditRealEstateOwner(ID) {
    $("#divModalContent").html("");
    $.ajax({
        url: '/RealEstates/EditOwnerData/' + ID,
        datatype: "json",
        type: "get",
        // data: { id: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divModalContent").html(data);
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in Edit Owner');
        }
    });
}
function LoadRealEstatePhotos(ID) {
    // console.log(ID);
    $.ajax({
        url: '/RealEstates/RealestatePhotos/' + ID + '?type=slider',
        datatype: "json",
        type: "get",
        // data: { type: 'slider' },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divPhotos").html(data);
            //$(".carousel-indicators li:first").addClass("active");
            $(".carousel-inner div:first").addClass("active");
            //  InitializeSlider();
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in loading Photos');
        }
    });
}
function LoadRealEstateCriteria(ID) {
    // console.log(ID);
    $.ajax({
        url: '/RealEstates/RealestateCriterias/' + ID,
        datatype: "json",
        type: "get",
        // data: { type: 'slider' },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divCriteria").html(data);
            ConfirmDelete("#divCriteria");
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in loading Criteria');
        }
    });
}
function LoadUserOtherRealEstates(ID) {
    // console.log(ID);
    $.ajax({
        url: '/RealEstates/SubscriberOtherRealestates/' + ID,
        datatype: "json",
        type: "get",
        // data: { type: 'slider' },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divRealEstates").html(data);
            ConfirmDelete("#divRealEstates");
            //  InitializeSlider();
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in loading RealEstates');
        }
    });
}
//------------ UserDashboard-------------------------------//
function LoadUserNotifications() {
    // console.log(ID);
    $.ajax({
        url: '/UserDashBoard/GetNotifications/',
        datatype: "json",
        type: "get",
        // data: { type: 'slider' },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divSubscriberNotifications").html(data);
            ConfirmDelete("#divSubscriberNotifications");
            //  InitializeSlider();
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in loading Notifications');
        }
    });
}
function LoadUserPurchaseRequests() {
    // console.log(ID);
    $.ajax({
        url: '/UserDashBoard/GetPurchaseRequest/',
        datatype: "json",
        type: "get",
        // data: { type: 'slider' },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divSubscriberRequests").html(data);
            ConfirmDelete("#divSubscriberRequests");
            //  InitializeSlider();
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in loading Requests');
        }
    });
}
function LoadCompanyPurchaseRequests() {
    // console.log(ID);
    $.ajax({
        url: '/UserDashBoard/GetCompanyPurchaseRequest/',
        datatype: "json",
        type: "get",
        // data: { type: 'slider' },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divSubscriberCompanyRequests").html(data);
            ConfirmDelete("#divSubscriberCompanyRequests");
            //  InitializeSlider();
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in loading Company Requests');
        }
    });
}
function LoadProjectsInquireis() {
    // console.log(ID);
    $.ajax({
        url: '/UserDashBoard/GetProjectInquiries/',
        datatype: "json",
        type: "get",
        // data: { type: 'slider' },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divSubscriberCompanyInquiries").html(data);
            ConfirmDelete("#divSubscriberCompanyInquiries");
            //  InitializeSlider();
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in loading Inquiries');
        }
    });
}
function LoadIncompleteRealEstate() {
    // console.log(ID);
    $.ajax({
        url: '/UserDashBoard/GetIncompleteRealEstate/',
        datatype: "json",
        type: "get",
        // data: { type: 'slider' },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divIncompleteRealEstates").html(data);
            ConfirmDelete("#divIncompleteRealEstates");
            //  InitializeSlider();
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in loading Incomplete RealEstate');
        }
    });
}
function ViewNotification(ID) {
    $("#divModalContent").html("");
    $.ajax({
        url: '/SubscriberNotifications/Details/' + ID,
        datatype: "json",
        type: "get",
        // data: { id: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divModalContent").html(data);
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in View Notification');
        }
    });
}
function ViewPurchaseRequest(ID) {
    $("#divModalContent").html("");
    // console.log(ID);
    $.ajax({
        url: '/RealEstatePurchaseRequests/Details/' + ID,
        datatype: "json",
        type: "get",
        // data: { id: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divModalContent").html(data);
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in View Purchase Requests');
        }
    });
}
function ViewCuromerInquiry(ID) {
    $("#divModalContent").html("");
    // console.log(ID);
    $.ajax({
        url: '/CompanyMessages/Details/' + ID,
        datatype: "json",
        type: "get",
        // data: { id: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divModalContent").html(data);
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in View Purchase Requests');
        }
    });
}
function ViewComplain(ID) {
    $("#divModalContent").html("");
    // console.log(ID);
    $.ajax({
        url: '/RealEstateComplains/Details/' + ID,
        datatype: "json",
        type: "get",
        // data: { id: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divModalContent").html(data);
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in View Complain Detail');
        }
    });
}
function SendReply(ID) {
    $("#divModalContent").html("");
    // console.log(ID);
    $.ajax({
        url: '/AdminDashBoard/SendReply/' + ID,
        datatype: "json",
        type: "get",
        // data: { id: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divModalContent").html(data);
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in Send Reply');
        }
    });
}
function SendMessage() {
    $("#divModalContent").html("");
    // console.log(ID);
    $.ajax({
        url: '/UserDashBoard/SendMsg/',
        datatype: "json",
        type: "get",
        // data: { id: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divModalContent").html(data);
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in Send Message');
        }
    });
}
function SendReplyToManagement(ID) {
    $("#divModalContent").html("");
    // console.log(ID);
    $.ajax({
        url: '/UserDashBoard/SendReply/' + ID,
        datatype: "json",
        type: "get",
        // data: { id: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divModalContent").html(data);
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in Send Reply');
        }
    });
}
//--------------------------- Catalogs-----------------------------//
function AddCatalogRealestate(ID) {
    $("#divModalContent").html("");
    $.ajax({
        url: '/RealEstateCatalogs/AddRealEstate/' + ID,
        datatype: "json",
        type: "get",
        // data: { id: ID },
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#divModalContent").html(data);
        },
        error: function (xhr) {
            //console.log(xhr);
            console.log('error in New Project Photo');
        }
    });
}
//--------------------------- Plugin--------------------------------//
