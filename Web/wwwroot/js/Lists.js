$('#SaveBtn').click(function () {
    $(this).prop('disabled', true);
    $('#ListForm').submit();
});

$('.EditBtn').click(function () {
    editList($(this));
});


function editList(caller) {
    var id = caller.data('id');
    var hasrtf = caller.data('hasrtf');
    var isactive = caller.data('isactive');
    var orderindex = caller.data('orderindex');

    setTextEditOrAdd(false, '.modal-title');

    $('#Id').val(id);
    $('#OrderIndex').val(orderindex);

    if (isactive === "True") {
        $('#IsActive').prop("checked", true);
    }

    if (hasrtf === "True") {
        $('#HasRTF').prop("checked", true);
    }

    $("#ListModal").modal('show');
}


$(".modal").on("hidden.bs.modal", function () {
    $('#Id').val(0);
    $('#OrderIndex').val('');
    $('#IsActive').prop("checked", false);
    $('#HasRTF').prop("checked", false);
});