var map;
var geocoder;
var NewLocationMarker;
function loadScript() {

    var script = document.createElement('script');
    script.type = 'text/javascript';
    script.src = 'http://maps.googleapis.com/maps/api/js?sensor=true&language=ar&key=AIzaSyBz4VviK04Yohp-0Uu2xLT6THX4XpirPKs&' +
      'callback=CreateMap';
    document.getElementsByTagName("head")[0].appendChild(script);
}
function CreateMap() {
    //   alert("Ready");
    var myLatlng = new google.maps.LatLng(30.04449, 31.2356947);
    var myOptions = {
        zoom: 3,
        center: myLatlng
    };
    geocoder = new google.maps.Geocoder();

    map = new google.maps.Map(document.getElementById("MyMap"), myOptions);
    google.maps.event.addListener(map, 'rightclick', function (event) {
        placeMarker(event.latLng);
    });

}
function ShowAddress(address, zoomlevel) {
    // alert("test");
    // var address = "مصر, القاهرة, المعادى"; //document.getElementById("address").value;
    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            map.setCenter(results[0].geometry.location);
            map.setZoom(zoomlevel);
        } else {
          //  alert("Geocode was not successful for the following reason: " + status);
        }
    });
}
function AddMarkerList(Branches, img) {

    var infowindow = new google.maps.InfoWindow();
  var locations=JSON.parse(Branches);
    var marker, i;
    markerBounds = new google.maps.LatLngBounds();
    for (i = 0; i < locations.length; i++) {
        if (locations[i].Latitude != null && locations[i].Latitude != "" && locations[i].Longitude != null && locations[i].Longitude != "") {
            marker = new google.maps.Marker({
                position: new google.maps.LatLng(locations[i].Latitude, locations[i].Longitude),
                map: map,
                icon: img,
                title: locations[i].Title
            });
            markerBounds.extend(new google.maps.LatLng(locations[i].Latitude, locations[i].Longitude));
            google.maps.event.addListener(marker, 'mouseover', (function (marker, i) {
                return function () {
                    infowindow.setContent("<div style='Min-Width:80px; text-align:center'>"+locations[i].Title.toString()+"</div>");
                    infowindow.open(map, marker);
                }
            })(marker, i));
        }
    }
    map.fitBounds(markerBounds);
  //  map.setZoom(18);
}

function placeMarker(location) {
    //   alert("test");
    if (NewLocationMarker) {
        NewLocationMarker.setPosition(location);
    } else {
        NewLocationMarker = new google.maps.Marker({
            position: location,
            map: map
        });
    }
    map.setCenter(location);
    SetLatLongControls(location.lat(), location.lng());
}

function AddLocationToMap(lat, lng) {
    var location = new google.maps.LatLng(lat, lng);
    //  alert("test");
    if (NewLocationMarker) {
        NewLocationMarker.setPosition(location);
    } else {
        NewLocationMarker = new google.maps.Marker({
            position: location,
            map: map
        });
    }
    map.setCenter(location);
    map.setZoom(15);
}
function AddLocationToMapwithimage(lat, lng,img) {
    var location = new google.maps.LatLng(lat, lng);
  //    alert(img);
    if (NewLocationMarker) {
        NewLocationMarker.setPosition(location);
    } else {
        NewLocationMarker = new google.maps.Marker({
            position: location,
            map: map,
            icon:img
        });
    }
    map.setCenter(location);
    map.setZoom(18);
}

   
   
