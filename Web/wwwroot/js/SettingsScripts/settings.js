$('#addSizeBtn').click(function () {
    createSize($(this));
});
$('#addColorBtn').click(function () {
    createColor($(this));
});
$('#addCategoryBtn').click(function () {
    createCategory($(this));
});

function createSize(caller) {
 
    var datas = $('#CreatSizeForm').serialize();

    $('#addSizeBtn').button('loading');
    var url = $('#CreatSizeForm').attr('action');
    $.ajax({
        url: url,
        type: 'post',
        dataType: 'html',
        data: datas,
        beforeSend: function () {
            $('.loading-load').show()
        },
        success: function (res) {
            location.reload();
        },
        complete: function (res) {
            location.reload();
        }
    });
}

function createColor(caller) {
 
    var datas = $('#CreatColorForm').serialize();

    $('#addColorBtn').button('loading');
    var url = $('#CreatColorForm').attr('action');
    $.ajax({
        url: url,
        type: 'post',
        dataType: 'html',
        data: datas,
        beforeSend: function () {
            $('.loading-load').show()
        },
        success: function (res) {
            location.reload();
        },
        complete: function (res) {
            location.reload();
        }
    });
}


//category functions 
// category functions
function createCategory(caller) {
    var form = $('#CreatCategoryForm')[0]; // Get the form element
    var formData = new FormData(form); // Create FormData object

    $('#addCategoryBtn').button('loading');
    var url = $('#CreatCategoryForm').attr('action');

    $.ajax({
        url: url,
        type: 'POST',
        data: formData, // Use FormData for file uploads
        contentType: false, // Required for FormData
        processData: false, // Required for FormData
        beforeSend: function () {
            $('.loading-load').show();
        },
        success: function (res) {
            location.reload();
        },
        complete: function (res) {
            location.reload();
        },
        error: function (err) {
            console.log("Error:", err);
        }
    });
}


$(document).ready(function () {
    // When the edit button is clicked
    $('.editCategoryBtn').click(function () {
        var categoryId = $(this).data('id');
        var categoryName = $(this).data('name');

        // Set the values in the modal
        $('#categoryId').val(categoryId);
        $('#categoryName').val(categoryName);

        // Show the modal
        $('#editCategoryModal').modal('show');
    });

    // Save changes when Save button is clicked
    $('#saveCategoryBtn').click(function () {
        var formData = new FormData($('#editCategoryForm')[0]); // Use FormData to handle file uploads
        var categoryId = $('#categoryId').val();
        var url = "/hr/Product/UpdateCategory?categoryId=" + categoryId; // Correct URL construction

        // AJAX request to save the changes
        $.ajax({
            url: url,
            type: 'POST',
            data: formData, // Send FormData instead of serialized data
            contentType: false, // Set these options for file upload
            processData: false, // Don't process the data
            beforeSend: function () {
                $('.loading-load').show(); // Show loading indicator (optional)
            },
            success: function (res) {
                if (res.success) {
                    // If update is successful, reload or update the page content dynamically
                    location.reload(); // Reload the page if needed
                } else {
                    alert(res.msg); // Show the error message from the server
                }
            },
            error: function (xhr, status, error) {
                console.error('Error:', error); // Log errors for debugging
                alert('An error occurred while updating the category');
            },
            complete: function () {
                $('.loading-load').hide(); // Hide loading indicator
            }
        });
    });
});


//color


$(document).ready(function () {
    // When the edit button is clicked
    $('.editColorBtn').click(function () {
        var colorId = $(this).data('id');
        var colorName = $(this).data('name');

        // Set the values in the modal
        $('#colorId').val(colorId);
        $('#colorName').val(colorName);

        // Show the modal
        $('#editColorModal').modal('show');
    });

    // Save changes when Save button is clicked
    $('#saveColorBtn').click(function () {
        var formData = $('#editColorForm').serialize();
        var colorId = $('#colorId').val();
        var url = "/hr/Product/UpdateColor?colorId=" + colorId; // Correct URL construction

        // AJAX request to save the changes
        $.ajax({
            url: url,
            type: 'post',
            dataType: 'json', // Expecting JSON from the server
            data: formData, // Send the serialized form data
            beforeSend: function () {
                $('.loading-load').show(); // Show loading indicator (optional)
            },
            success: function (res) {
                if (res.success) {
                    // If update is successful, reload or update the page content dynamically
                    location.reload(); // Reload the page if needed
                } else {
                    alert(res.msg); // Show the error message from the server
                }
            },
            error: function (xhr, status, error) {
                console.error('Error:', error); // Log errors for debugging
                alert('An error occurred while updating the category');
            },
            complete: function () {
                $('.loading-load').hide(); // Hide loading indicator
            }
        });
    });

});

//size


$(document).ready(function () {
    // When the edit button is clicked
    $('.editSizeBtn').click(function () {
        var sizeId = $(this).data('id');
        var sizeNr = $(this).data('sizenr');

        // Set the values in the modal
        $('#sizeId').val(sizeId);
        $('#sizeNr').val(sizeNr);

        // Show the modal
        $('#editSizeModal').modal('show');
    });

    // Save changes when Save button is clicked
    $('#saveSizeBtn').click(function () {
        var formData = $('#editSizeForm').serialize();
        var sizeId = $('#sizeId').val();
        var url = "/hr/Product/UpdateSize?sizeId=" + sizeId; // Correct URL construction

        // AJAX request to save the changes
        $.ajax({
            url: url,
            type: 'post',
            dataType: 'json', // Expecting JSON from the server
            data: formData, // Send the serialized form data
            beforeSend: function () {
                $('.loading-load').show(); // Show loading indicator (optional)
            },
            success: function (res) {
                if (res.success) {
                    // If update is successful, reload or update the page content dynamically
                    location.reload(); // Reload the page if needed
                } else {
                    alert(res.msg); // Show the error message from the server
                }
            },
            error: function (xhr, status, error) {
                console.error('Error:', error); // Log errors for debugging
                alert('An error occurred while updating the category');
            },
            complete: function () {
                $('.loading-load').hide(); // Hide loading indicator
            }
        });
    });

});