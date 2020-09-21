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
window.setHidden = () => {

    $('.wiki-marker').css("visibility", "visible");

    //var markers = document.getElementsByClassName("wiki-marker");

    //if (markers.length > 0) {
    //    for (var i in markers) {
    //        var marker = markers[i];
          
    //        marker.style.visibility = "hidden";
    //    };
    //};

};

window.setVisible = (currentEvents) => {

    for (i in currentEvents) {
        var item = currentEvents[i];
        var eventId = "event" + item.eventId;
        $('.' + eventId).css("visibility", "hidden");
    }

}

window.addMarkers = (eventsJson) => {
    for (var i in eventsJson) {
        var mapItem = eventsJson[i];
        console.log(mapItem);
        var lat = parseFloat(mapItem.location.lat);
        var long = parseFloat(mapItem.location.long);
        var title = "<p>" + mapItem.title + "</p>";
        var coords = [long, lat];

        var el = document.createElement('div');
        el.classList.add("wiki-marker");
        el.classList.add("event" + mapItem.eventId);

        try {
            var marker = new mapboxgl.Marker(el)
                .setLngLat(coords)
                .setPopup(new mapboxgl.Popup().setHTML(title))
                .addTo(map);
        }
        catch (err) {
            console.log(err);
        }
    }
}