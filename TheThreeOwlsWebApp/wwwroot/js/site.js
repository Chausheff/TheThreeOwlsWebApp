function sendMail() {
    var tempParams = {
        from_name: document.getElementById("fromName").value,
        to_name: document.getElementById("toName").value,
        message: document.getElementById("message").value,
    };

    emailjs.send('service_gvy327c','template_s89isc4', tempParams)
        .then(function (res) {
            document.getElementById("message").value = '';
            alert("succsess", res.status);
    })
}

function openCourseDetails(id) {
    var path = window.location.pathname;
    var controller = path.substring(0, path.lastIndexOf('/'));

    if (controller === '/Courses') {
        window.location.href = `Details/${id}`;
    }
    else {
        window.location.href = `Courses/Details/${id}`;
    }
}

$(document).ready(function () {
	"use strict";
	$('.menu > ul > li:has( > ul)').addClass('menu-dropdown-icon');
	$('.menu > ul > li > ul:not(:has(ul))').addClass('normal-sub');
	$(".menu > ul").before("<a href=\"#\" class=\"menu-mobile\">&nbsp;</a>");
	$(".menu > ul > li").hover(function (e) {
		if ($(window).width() > 943) {
			$(this).children("ul").stop(true, false).fadeToggle(150);
			e.preventDefault();
		}
	});
	$(".menu > ul > li").click(function () {
		if ($(window).width() <= 943) {
			$(this).children("ul").fadeToggle(150);
		}
	});
	$(".menu-mobile").click(function (e) {
		$(".menu > ul").toggleClass('show-on-mobile');
		e.preventDefault();
	});
});
$(window).resize(function () {
	$(".menu > ul > li").children("ul").hide();
	$(".menu > ul").removeClass('show-on-mobile');
});
