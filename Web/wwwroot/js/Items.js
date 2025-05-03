$('.deleteSubProjectItem').click(function (e) {
    var id = $(this).data('id'); 
    var data = { Id: id };
    var url = '/' + currentLang + '/SubprojectItem/DeleteItem';
    $.confirm({
        confirm: function () {
            $.post(url, data, function (d) {
                if (d.success === true) {
                    location.reload(true);
                }
                else {
                    cancelConfirm();
                }
            }, 'json');
        },
        cancel: function () {
            cancelConfirm();
        }
    });
});

$('.deleteSubProjectSubItem').click(function (e) {
    var id = $(this).data('id');
    var data = { Id: id };
    var url = '/' + currentLang + '/SubProjectItem/DeleteSubItem';
    $.confirm({
        confirm: function () {
            $.post(url, data, function (d) {
                if (d.success === true) {
                    location.reload(true);
                }
                else {
                    cancelConfirm();
                }
            }, 'json');
        },
        cancel: function () {
            cancelConfirm();
        }
    });
});