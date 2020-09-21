window.map = () => {


    mapboxgl.accessToken =
        "pk.eyJ1IjoiYXJjNDg4IiwiYSI6ImNrY2EzZjdkcTBmeW4ycW95b3c2MnRoZjQifQ.c_Fdcmu1Eu6k0Lqger642Q";
    map = new mapboxgl.Map({
        container: 'map',
        style: 'mapbox://styles/mapbox/streets-v11',
        center: [51.1657, 10.4515],
        zoom: 8
    });



}

window.addMarkers = (eventsJson) => {
    for (var i in eventsJson) {
        var mapItem = eventsJson[i];
        var lat = parseFloat(mapItem.location.lat);
        var long = parseFloat(mapItem.location.long);
        var title = "<p>" + mapItem.title + "</p>";
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

    }
}