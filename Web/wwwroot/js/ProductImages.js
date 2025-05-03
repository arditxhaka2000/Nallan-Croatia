$('#saveImages').on('click', function () {
    //var formData = new FormData($('#UploadProductImages')[0]);
    var form = $('#insrtDocFOrm')[0];
    var _data = new FormData(form);
    if (_data.entries) {
        var data = new FormData();
        for (var p of _data) {
            if (p[1]) {
                // p[1] is the value of form entry
                data.append(p[0], p[1]);
            }
        } _data = data;
    }
    var urls = $('#insrtDocFOrm').attr('action');

    $.ajax({
        url: urls,
        type: 'POST',
        data: _data,
        contentType: false,
        processData: false,
        success: function (data) {
            if (data.success) {
                alert('Images uploaded successfully!');
                $('#uploadModal').modal('hide');
            } else {
                alert('Upload failed!');
            }
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
            alert('Upload failed!');
        }
    });
});