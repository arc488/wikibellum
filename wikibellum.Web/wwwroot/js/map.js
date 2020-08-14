mapboxgl.accessToken =
    "pk.eyJ1IjoiYXJjNDg4IiwiYSI6ImNrY2EzZjdkcTBmeW4ycW95b3c2MnRoZjQifQ.c_Fdcmu1Eu6k0Lqger642Q";
var map = new mapboxgl.Map({
    container: 'map',
    style: 'mapbox://styles/mapbox/streets-v11',
    center: [51.1657, 10.4515],
    zoom: 8
});


for (var i in modelData) {
    var mapItem = modelData[i];
    var lat = parseFloat(mapItem.lat);
    var long = parseFloat(mapItem.long);
    var title = "<h6>" + mapItem.title + "</h6>";
    var coords = [long, lat];

    try {
        var marker = new mapboxgl.Marker()
            .setLngLat(coords)
            .setPopup(new mapboxgl.Popup().setHTML(title))
            .addTo(map);
    }
    catch (err) {
        console.log(err);
    }
    marker.togglePopup();

}