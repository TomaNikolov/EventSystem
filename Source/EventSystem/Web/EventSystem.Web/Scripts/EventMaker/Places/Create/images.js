(function () {
    function readURL(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $(input)
                    .parent()
                    .parent()
                    .find('img')
                    .attr('src', e.target.result)
                    .show(10);
            }

            reader.readAsDataURL(input.files[0]);
        }
    }

    $(".upload").change(function () {
        readURL(this);
    });

    $('.img-responsive').hide();
}());