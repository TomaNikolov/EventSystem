(function () {
    //Get Addres longitude and latitude
    $('#Street').blur(function () {
        GetAddressGeoLocation();
    })

    $('form').submit(function (e) {
        $this = $(this);
        if (!$('#Latitude').val()) {
            e.preventDefault();

            GetAddressGeoLocation()
             .then(function () {
                 console.log('ok')
                 $this.unbind("submit").submit()
             });
        }
    })

    function GetAddressGeoLocation() {
        var address = $('#Street').val();
        var feedback = $('#feedback');
        var city = $('#CityId option:selected').text()
        console.log(city);

        return $.get('https://maps.googleapis.com/maps/api/geocode/json?address=' + address + city)
                 .then(function (result) {
                     if (result.status === 'OK') {
                         var address = result.results[0].formatted_address;
                         var numCommas = address.match(/,/g).length;
                         if (numCommas == 2) {
                             feedback.removeClass();
                             feedback.addClass('icon-ok');
                             feedback.css('color', 'green');

                             var location = result.results[0].geometry.location;
                             var latitude = $('#Latitude');
                             var longitude = $('#Longitude');
                             latitude.val(parseFloat(location.lat));
                             longitude.val(location.lng);
                             console.log(location.lat);
                             console.log(location.lng);
                             AddMarker(location.lat, location.lng)
                         } else {
                             feedback.removeClass();
                             feedback.addClass('icon-remove');
                             feedback.css('color', 'red');
                         }
                     }
                 })
    }

    //Google Maps
    var map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: 42.1523245, lng: 24.7484875 },
        scrollwheel: false,
        zoom: 15
    });

    var marker = new google.maps.Marker();

    function AddMarker(lat, long, address) {
        var latLng = { lat: lat, lng: long };

        marker.setMap(null);
        map.setCenter(latLng)

        marker = new google.maps.Marker({
            position: latLng,
            map: map,
            title: address
        });
    }
}());