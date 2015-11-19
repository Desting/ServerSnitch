$(function () {
    $('#serviceModal').modal({
        keyboard: true,
        backdrop: "static",
        show: false,
        

    }).on('show', function () {

    });
    $(".table-hover").find('tr[data-id]').on('click', function () {

        //do all your operation populate the modal and open the modal now. DOnt need to use show event of modal again
        $('.modal-body').html($('<b>' + $(this).data('content') + '</b>'));
        $('#serviceModal').modal('show');



    });

});

$(function () {
    $('#iisModal').modal({
        show: false,
    }).on('show', function () {

    });
    $('.modal-body').html($('<b>' + $(this).data('target') + '</b>'));


});