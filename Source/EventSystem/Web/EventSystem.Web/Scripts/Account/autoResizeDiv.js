(function () {
    var footerPixels = 136;

    function resize() {
        var heights = window.innerHeight;
        document.getElementById('main-content').style.height = (heights - footerPixels) + 'px';
    }

    resize();

    window.onresize = function () {
        resize();
    };
}());