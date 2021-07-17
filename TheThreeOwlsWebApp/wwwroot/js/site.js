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