
function getServices(id) {
    $.get("/entities/services/"+id, function (data) {
        $("#services").html(data);

    });
}

function getIIS(id) {
    $.get("/entities/iis/" + id, function (data) {
        $("#iis").html(data);

    });
}