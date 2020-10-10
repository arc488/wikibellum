

window.map = () => {
    mapboxgl.accessToken =
        "pk.eyJ1IjoiYXJjNDg4IiwiYSI6ImNrY2EzZjdkcTBmeW4ycW95b3c2MnRoZjQifQ.c_Fdcmu1Eu6k0Lqger642Q";
    map = new mapboxgl.Map({
        container: 'map',
        style: 'mapbox://styles/mapbox/streets-v11',
        center: [13.24, 53.31],
        zoom: 4
    });
    currentMarkers = [];

    eventId = 0;
}

window.broadcastEventId = (dotNetObject) => {
    dotNetObject.invokeMethodAsync('SetEvent', eventId.toString());
}

window.removeAllMarkers = () => {
    for (var i = 0; i < currentMarkers.length; i++) {
        currentMarkers[i].remove();
        currentMarkers.splice(i, 1);
    }
}

window.setEventJs = (id) => {
    var eventIdInput = document.getElementById("_currentEventIdInput");
    eventIdInput.value = id;
    var event = new Event('change');
    eventIdInput.dispatchEvent(event);
}

window.addCurrentEvents = (currentEvents) => {
    try {
        for (var i in currentEvents) {
            var eventMarker = currentEvents[i];
            var lat = parseFloat(eventMarker.lat);
            var long = parseFloat(eventMarker.long);
            var title = "<p>" + eventMarker.title + "</p>";
            var coords = [long, lat];

            var el = document.createElement('div');
            el.classList.add("wiki-marker");
            el.id = eventMarker.eventId;

            el.addEventListener('click', function(e) {
                setEventJs(this.id);
            }); 

            try {
                var marker = new mapboxgl.Marker(el)
                    .setLngLat(coords)
                    .setPopup(new mapboxgl.Popup().setHTML(title))
                    .addTo(map);
                currentMarkers.push(marker);


            }
            catch (err) {
                console.log(err);
            }
        }
    }
    catch (err) {
        console.log(err);
    }

}
