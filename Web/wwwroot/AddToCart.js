
//function updateCartCount(newCount) {
//    // Update the count in sessionStorage
//    sessionStorage.setItem('cartCount', newCount);

//    // Update the cart badge in the header
//    const cartBadge = document.getElementById('cartCountBadge');
//    if (cartBadge) {
//        cartBadge.textContent = newCount;
//    }

//    // Dispatch a custom event that other components can listen for
//    document.dispatchEvent(new Event('cartCountUpdated'));
//}

//// Function to get the current cart count from the server
//function refreshCartCountFromServer() {
//    fetch('/sq/Cart/GetCartItemCount', {
//        method: 'GET',
//        headers: {
//            'X-Requested-With': 'XMLHttpRequest'
//        }
//    })
//        .then(response => response.json()) // Make sure to parse the JSON
//        .then(data => {
//            // Convert to number and fallback to 0 if invalid
//            const count = Number(data.count);
//            updateCartCount(isNaN(count) ? 0 : count);
//        })
//        .catch(error => {
//            console.error('Error fetching cart count:', error);
//        });
//}


//// Initialize cart count on page load
//document.addEventListener('DOMContentLoaded', function () {
//    // Try to get from sessionStorage first
//    const storedCount = sessionStorage.getItem('cartCount');

//    if (storedCount) {
//        // Update the header with stored count
//        const cartBadge = document.getElementById('cartCountBadge');
//        if (cartBadge) {
//            cartBadge.textContent = storedCount;
//        }
//    } else {
//        // If not in sessionStorage, fetch from server
//        refreshCartCountFromServer();
//    }
//});