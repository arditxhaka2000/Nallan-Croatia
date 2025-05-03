
$('.clear-field').on('click', function () {
    $(".SearchForm").trigger("reset");
    $('.SearchForm').find('input:text,select, textarea, input[type=number]').val('');
    $('.chosen-select')
        .find('option:first-child').prop('selected', false)
        .end().trigger('chosen:updated');

});
$('.history-details').click(function () { 
    var historytype = $(this).data('actionname');
    var objectid = $(this).data('objectid');
    var id = $(this).data('id');

    $('#logHistoryDetails').text('Tabela' + ' : ' + historytype);

    $.get('/sq/Histories/GetDetail?objectId=' + objectid, 'jsonp').done(function (data) {
        $('#historyDetailEntitry').empty();
        $('#historyDetailEntitry').append('<tr><td>Id</td>' + '<td> ' + id + '</td >' + '<td>' + id + '</td></tr> ');
      
        for (var i = 0; i < data.length; i++) {
            $('#historyDetailEntitry').append('<tr><td>' + data[i].columnName + '</td>' +
                '<td> ' + data[i].oldValue + '</td >' +
                '<td>' + data[i].newValue + '</td></tr> ');
        }
    });
});

