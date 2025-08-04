// Get current language from route (same as ViewContext.RouteData.Values["lang"])
function getCurrentLanguage() {
    var path = window.location.pathname;
    var segments = path.split('/').filter(function (segment) { return segment.length > 0; });
    return segments.length > 0 ? segments[0] : 'en';
}

// Set translations based on current language
var currentLang = getCurrentLanguage();
var translations = {};

if (currentLang === 'hr') {
    translations = {
        selectSize: 'Molim vas odaberite veličinu.',
        addToCartFailed: 'Greška pri dodavanju proizvoda u košaricu.',
        removeFromCartError: 'Greška pri uklanjanju stavke iz košarice',
        size: 'Veličina',
        price: 'Cijena',
        quantity: 'Količina',
        total: 'Ukupno'
    };
} else {
    translations = {
        selectSize: 'Please select a size.',
        addToCartFailed: 'Failed to add product to cart.',
        removeFromCartError: 'Error removing item from cart',
        size: 'Size',
        price: 'Price',
        quantity: 'Quantity',
        total: 'Total'
    };
}

$('.add-to-cart-btn').on('click', function (e) {
    e.preventDefault();
    var productId = $(this).data('product-id');
    var quantity = $('#quantity-' + productId).val();
    var selectedSizeInput = $('input[name="sizeOptions-' + productId + '"]:checked');
    var selectedSize = selectedSizeInput.val();
    var variantProductCode = selectedSizeInput.data('variant-productcode');

    if (!selectedSize) {
        alert(translations.selectSize);
        return;
    }

    var modalId = $(this).closest('.modal').attr('id');

    $.ajax({
        url: '/hr/Cart/AddToCart',
        type: 'POST',
        data: {
            productId: productId,
            variantProductCode: variantProductCode,
            quantity: quantity,
            selectedSize: selectedSize
        },
        success: function (response) {
            if (response.success) {
                $('.cart-count').text('(' + response.cartCount + ')');
                $('#' + modalId).modal('hide');
                $('.modal-backdrop').hide();
                $('#cart-alert').fadeIn();
                setTimeout(function () {
                    $('#cart-alert').fadeOut();
                }, 3000);
            }
        },
        error: function () {
            alert(translations.addToCartFailed);
        }
    });
});

$('.cart-link').on('click', function () {
    getItem4Cart();
});

function getItem4Cart() {
    var parentRow = '<div class="row align-items-center text-center mb-4">';
    var EndparentRow = '</div>';
    var col3 = '<div class="col-3">';
    var col6 = '<div class="col-7">';
    var col1 = '<div class="col-2">';
    var Endcol3 = '</div>';
    var H6 = '<h6>';
    var EndH6 = '</h6>';
    var paraG = "<p>";
    var EndparaG = "</p>";
    var Euro = '&euro;';
    var externalBase = "https://nallan.eu/products";
    var internalBase = "/Products";

    $.ajax({
        url: '/hr/Cart/GetCartItems',
        type: 'GET',
        success: function (response) {
            var cartItems = response.cartItems;
            $('#cart-items').empty();
            $.each(cartItems, function (index, item) {
                $('#cart-items').append(
                    parentRow +
                    col3 + '<img style="max-width:100%; height:auto" src="' + item.imagePath.replace(externalBase, internalBase) + '" alt="#">' + Endcol3 +
                    col6 +
                    H6 + item.productName + EndH6 +
                    paraG + translations.size + ": " + item.selectedSize + EndparaG +
                    paraG + translations.price + ": " + item.price + Euro + EndparaG +
                    paraG + translations.quantity + ": " + item.quantity + EndparaG +
                    paraG + translations.total + ": " + (item.price * item.quantity) + Euro + EndparaG +
                    Endcol3 +
                    col1 +
                    `<button class="btn" onclick="removeFromCart('${item.productId}')"> 
                            <i class="fa fa-times" style="color:red"></i>
                        </button>` + Endcol3 +
                    EndparentRow
                );
            });
            $('#cartModal').modal('show');
        }
    });
}

function removeFromCart(productId) {
    $.ajax({
        url: '/hr/Cart/RemoveFromCart',
        type: 'POST',
        data: { productId: productId },
        success: function (response) {
            if (response.success) {
                $('#cart-count').text(response.cartCount);
                getItem4Cart();
            }
        },
        error: function () {
            alert(translations.removeFromCartError);
        }
    });
}