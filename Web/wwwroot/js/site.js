$('.add-to-cart-btn').on('click', function (e) {
    e.preventDefault();
    var productId = $(this).data('product-id'); // Main product's ProductCode
    var quantity = $('#quantity-' + productId).val(); // Selected quantity
    var selectedSizeInput = $('input[name="sizeOptions-' + productId + '"]:checked'); // Get the selected size radio input
    var selectedSize = selectedSizeInput.val(); // Size value (e.g., "M", "L")
    var variantProductCode = selectedSizeInput.data('variant-productcode'); // Get variant's ProductCode

    if (!selectedSize) {
        alert('Please select a size.');
        return;
    }

    var modalId = $(this).closest('.modal').attr('id'); // Get modal ID dynamically

    // Perform AJAX request to add the selected product variant to the cart
    $.ajax({
        url: '/sq/Cart/AddToCart', // Your server endpoint
        type: 'POST',
        data: {
            productId: productId, // Main product's ProductCode
            variantProductCode: variantProductCode, // Variant's ProductCode
            quantity: quantity,
            selectedSize: selectedSize // Size value
        },
        success: function (response) {
            if (response.success) {
                // Update cart count in header
                $('.cart-count').text('(' + response.cartCount + ')');

                // Close the modal after successful addition to cart
                $('#' + modalId).modal('hide');
                $('.modal-backdrop').hide();

                // Show the alert
                $('#cart-alert').fadeIn();

                // Automatically hide the alert after 3 seconds
                setTimeout(function () {
                    $('#cart-alert').fadeOut();
                }, 3000);
            }
        },
        error: function () {
            alert("Failed to add product to cart.");
        }
    });
});

// Show cart modal on hover over the cart icon
$('.cart-link').on('click', function () {
    getItem4Cart();
});


function getItem4Cart() {
    var Tr = '<tr>';
    var EndTr = '</tr>';
    var Div = '<div>';
    var EndDiv = '</div>';
    var Td = '<td>';
    var EndTd = '</td>';
    var H6 = '<h6>';
    var EndH6 = '</h6>';
    var Euro = '&euro;';
    var paraG = "<p>";
    var EndparaG = "</p>";
    var parentRow = '<div class="row align-items-center text-center mb-4">';
    var EndparentRow = '</div>';
    var col3 = '<div class="col-3">';
    var col6 = '<div class="col-7">';
    var col1 = '<div class="col-2">';
    var Endcol3 = '</div>';
    var externalBase = "https://nallan.eu/products";
    var internalBase = "/Products";
    var updatedImagePath = "";
    $.ajax({
        url: '/sq/Cart/GetCartItems',
        type: 'GET',
        success: function (response) {
            var cartItems = response.cartItems;
            $('#cart-items').empty();
            $.each(cartItems, function (index, item) {
                $('#cart-items').append(
               

                parentRow +
                    col3 + '<img style="max-width:100%; height:auto" src="' + item.imagePath.replace(externalBase, internalBase) + '" ' + ' alt="#">'
                    + Endcol3
                    + col6 +
                    H6 + item.productName + EndH6 +
                    paraG + "Size: " + item.selectedSize + EndparaG +
                    paraG + "Price: " + item.price + Euro + EndparaG +
                    paraG + "Quantity: " + item.quantity + EndparaG +
                    paraG + "Total: " + (item.price * item.quantity) + Euro + EndparaG
                    + Endcol3 +
                    col1 +
                    `<button class="btn" onclick="removeFromCart('${item.productId}')" > 
         <i class="fa fa-times" style="color:red"></i>
     </button>` + Endcol3 + EndparentRow

                );
        });
    $('#cartModal').modal('show');

}
    });
}


function removeFromCart(productId) {
    $.ajax({
        url: '/sq/Cart/RemoveFromCart',
        type: 'POST',
        data: { productId: productId },
        success: function (response) {
            if (response.success) {
                // Update the cart count displayed on the UI
                $('#cart-count').text(response.cartCount);
                getItem4Cart();
            }
        },
        error: function () {
            alert('Error removing item from cart');
        }
    });
}
