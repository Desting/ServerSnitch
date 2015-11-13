$(document).ready(function () {
    $.get("/entities/services/" + id, function (data) {
        $("#services").html(data);

    });
});