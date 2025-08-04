$(document).ready(function () {
    $('#saveProductBtn').on('click', function (e) {
        e.preventDefault();

        var form = $('#createProdId')[0]; // Get form element
        var formData = new FormData(form); // Create FormData object

        // Disable the button and show loading text
        var $button = $(this);
        $button.prop('disabled', true).text('Saving...');

        // Get all selected ColorIds
        var colorIds = [];
        $('.color-checkbox:checked').each(function () {
            colorIds.push($(this).val());
        });
        formData.append('_ColorIds', JSON.stringify(colorIds)); // Convert array to JSON string

        // Get all selected SizeIds
        var sizeIds = [];
        $('.size-checkbox:checked').each(function () {
            sizeIds.push($(this).val());
        });
        formData.append('_SizeIds', JSON.stringify(sizeIds)); // Convert array to JSON string

        // Get all selected CategoryIds
        var categoryIds = [];
        $('select[name="_CategoryIds"] option:selected').each(function () {
            categoryIds.push($(this).val());
        });
        formData.append('_CategoryIds', JSON.stringify(categoryIds)); // Convert array to JSON string
        
        // Send the form data to the controller
        $.ajax({
            url: '/hr/product/AddProduct',
            type: 'POST',
            data: formData,
            contentType: false, // Prevent jQuery from automatically setting the content type
            processData: false, // Prevent jQuery from processing the form data
            success: function (response) {
                if (response.success) {
                    window.location.href = '/hr/product/products';
                } else {
                    alert('Error: ' + response.msg);
                    // Re-enable the button if there's an error
                    $button.prop('disabled', false).text('Save Product');
                }
            },
            error: function () {
                alert('An error occurred while processing the form.');
            }
        });
    });


    $('.delete-product-btn').on('click', function () {
        var productId = $(this).data('product-id'); // Get the product ID from the button data attribute

        // Show confirmation dialog
        if (confirm('Are you sure you want to delete this product? This action cannot be undone.')) {
            $.ajax({
                url: '/hr/Product/DeleteProduct', // Update with your delete endpoint
                type: 'POST',
                data: { productId: productId }, // Send the product ID
                success: function (response) {
                    if (response.success) {
                        alert('Product deleted successfully!');
                        // Optionally, refresh the page or redirect
                        window.location.reload();
                    } else {
                        alert('Error: ' + response.msg);
                    }
                },
                error: function () {
                    alert('An error occurred while deleting the product.');
                }
            });
        }
    });

});
