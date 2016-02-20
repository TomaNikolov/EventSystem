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

    $('#add-image').on('click', function () {
        $('div[data-id=\"image-file-uploade\"]')
            .first()
            .clone(true)
            .appendTo('#image-container')
    });

    $('div[data-id=\"remove\"]').on('click', function () {
        $(this).parent('div[data-id=\"image-file-uploade\"]')
               .remove();
    });
}());