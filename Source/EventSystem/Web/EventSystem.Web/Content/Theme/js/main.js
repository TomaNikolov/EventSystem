jQuery(function($) {'use strict',
	// Carousel Auto Slide Off
	$('#event-carousel, #twitter-feed, #sponsor-carousel ').carousel({
		interval: false
	});

	// Contact form validation
	var form = $('.contact-form');
	form.submit(function () {'use strict',
		$this = $(this);
		$.post($(this).attr('action'), function(data) {
			$this.prev().text(data.message).fadeIn().delay(3000).fadeOut();
		},'json');
		return false;
	});

	//$('.main-nav ul').onePageNav({
	//	currentClass: 'active',
	//    changeHash: false,
	//    scrollSpeed: 900,
	//    scrollOffset: 0,
	//    scrollThreshold: 0.3,
	//    filter: ':not(.no-scroll)'
	//});
});






