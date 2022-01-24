window.onload = init


function init() {
    const map = new ol.Map({
        view: new ol.View({
            center: [-404180.7585249506, 4892627.401621883],
            zoom: 7
        }),
        layers: [
            new ol.layer.Tile({
                source: new ol.source.OSM()
            })
        ],
        target: "prueba"
    })

    map.on('click', function (e){
        console.log(e.coordinate);
    })

    var layer = new ol.layer.Vector({
        source: new ol.source.Vector({
            features: [new ol.Feature({
                geometry: new ol.geom.Point(ol.proj.fromLonLat([39.4697065, -0.3763353]))
            })]
        })
    });
    map.addLayer(layer);
}