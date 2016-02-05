(function myfunction() {
    //Scroll Menu
    function menuToggle() {
        var $mainNav = $('.main-nav'),
         windowWidth = $(window).width();

        $mainNav.removeClass('fixed-menu animated slideInDown');
        if (windowWidth > 767) {
            $(window).on('scroll', function () {
                if ($(window).scrollTop() > 405) {
                    $mainNav.addClass('fixed-menu animated slideInDown');
                } else {
                    $mainNav.removeClass('fixed-menu animated slideInDown');
                }
            });
        } else {
            $mainNav.addClass('fixed-menu animated slideInDown');
        }
    }

    menuToggle();
})();