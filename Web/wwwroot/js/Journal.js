$('.deleteJournal').click(function (e) {
    var id = $(this).data('id'); 
    var data = { Id: id };
    var url = '/' + currentLang + '/Journal/DeleteJournal';
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

$('.deleteJournalDetail').click(function (e) {
    var id = $(this).data('id');
    var data = { Id: id };
    var url = '/' + currentLang + '/Journal/DeleteJournalDetail';
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