
$(document).ready(function () {
    $.get("/entities", function (data) {
        $("#result").html(data);

    });
});