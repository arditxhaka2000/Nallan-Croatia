$('.deleteProject').click(function (e) {
    var id = $(this).data('id');
    var data = { Id: id };
    var url = '/' + currentLang + '/administration/deleteproject';
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

$('.deleteSubProject').click(function (e) {
    var id = $(this).data('id');
    var data = { Id: id };
    var url = '/' + currentLang + '/SubProject/DeleteSubproject';
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

$('.deletePermit').click(function (e) {
    var id = $(this).data('id');
    var data = { Id: id };
    var url = '/' + currentLang + '/Permit/DeletePermit';
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

$('.deleteAccount').click(function (e) {
    var id = $(this).data('id');
    var data = { Id: id };
    var url = '/' + currentLang + '/Account/DeleteAccount';
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