﻿(function () {
    $("#countdown").countdown({
        date: $('#countdown').attr('data-time'),
        format: "on"
    });

    // Google Map Customization
    function showMap(lat, long) {

        var map;

        map = new GMaps({
            el: '#gmap',
            lat: lat,
            lng: long,
            scrollwheel: false,
            zoom: 16,
            zoomControl: false,
            panControl: false,
            streetViewControl: false,
            mapTypeControl: false,
            overviewMapControl: false,
            clickable: false
        });

        var image = 'Content/Theme/images/map-icon.png';
        map.addMarker({
            lat: lat,
            lng: long,
            icon: image,
            animation: google.maps.Animation.DROP,
            verticalAlign: 'bottom',
            horizontalAlign: 'center',
            backgroundColor: '#3e8bff',
        });


        var styles = [

        {
            "featureType": "road",
            "stylers": [
            { "color": "#b4b4b4" }
            ]
        }, {
            "featureType": "water",
            "stylers": [
            { "color": "#d8d8d8" }
            ]
        }, {
            "featureType": "landscape",
            "stylers": [
            { "color": "#f1f1f1" }
            ]
        }, {
            "elementType": "labels.text.fill",
            "stylers": [
            { "color": "#000000" }
            ]
        }, {
            "featureType": "poi",
            "stylers": [
            { "color": "#d9d9d9" }
            ]
        }, {
            "elementType": "labels.text",
            "stylers": [
            { "saturation": 1 },
            { "weight": 0.1 },
            { "color": "#000000" }
            ]
        }

        ];

        map.addStyle({
            styledMapName: "Styled Map",
            styles: styles,
            mapTypeId: "map_style"
        });

        map.setStyle("map_style");
    }

    var $map = $('#map');
    var lat = parseFloat($map.attr('data-lat'));
    var long = parseFloat($map.attr('data-long'));

    showMap(lat, long);
}());