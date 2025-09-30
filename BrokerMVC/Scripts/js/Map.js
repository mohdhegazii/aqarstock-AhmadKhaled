var map;
var geocoder;
var NewLocationMarker;
var ClickListener;
var RightClickListener;
function initMap()
{
    map = new google.maps.Map(document.getElementById('divMap'), {
        center: { lat: 30.04449, lng: 31.2356947 },
        zoom: 8
    });
}
function ResizeMap()
{
    google.maps.event.trigger(map, 'resize');
    var center = new google.maps.LatLng({ lat: 30.04449, lng: 31.2356947 })
    map.panTo(center);
}
function GetAddress(address, zoomLevel) {
    RightClickListener = google.maps.event.addListener(map, 'rightclick', function (event) {
        placeMarker(event.latLng);
    });
    ClickListener = google.maps.event.addListener(map, 'click', function (event) {
        placeMarker(event.latLng);
    });
    geocoder = new google.maps.Geocoder();
    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
                        placeMarker(results[0].geometry.location);
                        map.setZoom(zoomLevel);
        } else {
        }
    });
}
function placeMarker(location) {
    if (NewLocationMarker) {
        NewLocationMarker.setMap(null);
    }
        NewLocationMarker = new google.maps.Marker({
            position: location,
            map: map
        });
    map.setCenter(location);
    SetLatlngControls(location.lat(), location.lng());
}
function SetLocation(lat,lng)
{
    //alert(lat)
    map.setZoom(16);
    var location = new google.maps.LatLng(lat,lng);
    if (NewLocationMarker) {
        NewLocationMarker.setMap(null);
    }
    NewLocationMarker = new google.maps.Marker({
        position: location,
        map: map
    });
    map.setCenter(location);
    RightClickListener = google.maps.event.addListener(map, 'rightclick', function (event) {
        placeMarker(event.latLng);
    });
    ClickListener = google.maps.event.addListener(map, 'click', function (event) {
        placeMarker(event.latLng);
    });
    
}
function SetLocationWithoutListener(lat, lng) {
    //alert(lat)
    map.setZoom(12);
    var location = new google.maps.LatLng(lat, lng);
    if (NewLocationMarker) {
        NewLocationMarker.setMap(null);
    }
    NewLocationMarker = new google.maps.Marker({
        position: location,
        map: map
    });
    map.setCenter(location);

}
function ShowMapBound(Bounds)
{
    //alert(Branches[0].lat);
    var bound = new google.maps.LatLngBounds();
    for (var i = 0 ; i < Bounds.length; i++) {
        placeMarkerWithInfo(Bounds[i].lat, Bounds[i].lng, Bounds[i].name);
        bound.extend(new google.maps.LatLng(Bounds[i].lat, Bounds[i].lng));
    }
    map.fitBounds(bound);
}
function placeMarkerWithInfo(lat, lng, title) {
    var location = new google.maps.LatLng(lat, lng);
  
    var Marker = new google.maps.Marker({
        position: location,
        title: title,
        map: map
    });
    map.setCenter(location);
 
}
function SetMapCenter(lat, lng) {
    var location = new google.maps.LatLng(lat, lng);

    map.setCenter(location);
    map.setZoom(12);

}
function ShowAddress(address)
{
    
    geocoder = new google.maps.Geocoder();
    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            placeMarker(results[0].geometry.location);
            map.setZoom(10);
        } 
    });
}
function AddListeners()
{
    RightClickListener = google.maps.event.addListener(map, 'rightclick', function (event) {
        placeMarker(event.latLng);
    });
    ClickListener = google.maps.event.addListener(map, 'click', function (event) {
        placeMarker(event.latLng);
    });
}