$("#usercheck").change(function () {
    var username = $("#usercheck").val();

    $.ajax({
        type: "POST",
        url: "/User/CheckUsername",
        data: { user: username },
        dataType: "json",
        success: function (response) {
            var message = $("#message");
            if (response) {
                message.css("color", "green");
                message.html("Valid Username");
            }
            else {
                message.css("color", "red");
                message.html("Already used Username");
            }
        }

    });

});

$("#usermailcheck").change(function () {
    var usermail = $("#usermailcheck").val();

    $.ajax({
        type: "POST",
        url: "/User/CheckUsermail",
        data: { email: usermail },
        dataType: "json",
        success: function (response) {
            var message = $("#mailmessage");
            if (response) {
                message.css("color", "green");
                message.html("Valid Email");
            }
            else {
                message.css("color", "red");
                message.html("Already used EmailID");
            }
        }

    });

});