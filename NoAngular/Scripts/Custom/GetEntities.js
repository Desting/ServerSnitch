
$(document).ready(function () {
    $.get("/entities", function (data) {
        // This is the target html element:
        $("#result").html(data);
    });
});