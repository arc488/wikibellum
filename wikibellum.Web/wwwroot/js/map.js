mapboxgl.accessToken =
    "pk.eyJ1IjoiYXJjNDg4IiwiYSI6ImNrY2EzZjdkcTBmeW4ycW95b3c2MnRoZjQifQ.c_Fdcmu1Eu6k0Lqger642Q";
var map = new mapboxgl.Map({
    container: 'map',
    style: 'mapbox://styles/mapbox/streets-v11',
    center: [51.1657, 10.4515],
    zoom: 8
});

modelData.foreach

for (var i in modelData) {
    console.log(modelData[i]);
    var lat = parseFloat(modelData[i].lat);
    var long = parseFloat(modelData[i].long);
    var coords = [lat, long];
    console.log(coords)
    try {
        var marker = new mapboxgl.Marker()
            .setLngLat(coords)
            .addTo(map);
    }
    catch (err) {
        console.log(err);
    }

}