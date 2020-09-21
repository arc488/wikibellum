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
}


window.removeAllMarkers = () => {
    console.log("Remove all markers");
    for (var i = 0; i < currentMarkers.length; i++) {
        console.log("Removing marker: " + i);
        currentMarkers[i].remove();
        currentMarkers.splice(i, 1);
    }
}

window.addCurrentEvents = (currentEvents) => {
    try {
        for (var i in currentEvents) {
            var mapItem = currentEvents[i];
            var lat = parseFloat(mapItem.location.lat);
            var long = parseFloat(mapItem.location.long);
            var title = "<p>" + mapItem.title + "</p>";
            var coords = [long, lat];

            try {
                var marker = new mapboxgl.Marker()
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
//window.setHidden = () => {

//    $('.wiki-marker').css("visibility", "hidden");

//    //var markers = document.getElementsByClassName("wiki-marker");

//    //if (markers.length > 0) {
//    //    for (var i in markers) {
//    //        var marker = markers[i];
          
//    //        marker.style.visibility = "hidden";
//    //    };
//    //};

//};



//window.setVisible = (currentEvents) => {

//    for (i in currentEvents) {
//        var item = currentEvents[i];
//        var eventId = "event" + item.eventId;
//        $('.' + eventId).css("visibility", "visible");
//    }

//}

//window.addMarkers = (eventsJson) => {
//    for (var i in eventsJson) {
//        var mapItem = eventsJson[i];
//        console.log(mapItem);
//        var lat = parseFloat(mapItem.location.lat);
//        var long = parseFloat(mapItem.location.long);-
//        var title = "<p>" + mapItem.title + "</p>";
//        var coords = [long, lat];

//        var el = document.createElement('div');
//        el.classList.add("wiki-marker");
//        el.classList.add("event" + mapItem.eventId);

//        try {
//            var marker = new mapboxgl.Marker(el)
//                .setLngLat(coords)
//                .setPopup(new mapboxgl.Popup().setHTML(title))
//                .addTo(map);
//            currentMarkers.push(marker);
//        }
//        catch (err) {
//            console.log(err);
//        }
//    }
//}