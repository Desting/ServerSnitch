$(function () {
    $('#serviceModal').modal({
        keyboard: true,
        backdrop: "static",
        show: false,

    }).on('show', function () {

    });
    console.log("Triggered");
    $(".table-hover").find('tr[data-id]').on('click', function () {
        debugger;

        //do all your operation populate the modal and open the modal now. DOnt need to use show event of modal again

        $('#modal-body').html($('<b> Order Id selected: ' + $(this).data('id') + '</b>'));
        $('#serviceModal').modal('show');



    });

});