
function getServices(id) {
    $.get("/entities/services/" + id, function (data) {
        // This is the target html element:
        $("#services").html(data);
    });
}

function getIIS(id) {
    $.get("/entities/iis/" + id, function (data) {
        $("#iis").html(data);

    });
}