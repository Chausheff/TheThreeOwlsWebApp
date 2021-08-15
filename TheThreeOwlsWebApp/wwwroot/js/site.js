const { parseHTML } = require("jquery");

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