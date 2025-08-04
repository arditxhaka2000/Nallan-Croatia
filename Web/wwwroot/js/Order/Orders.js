$('#OrderSubmit').on('click', function (e) {
    e.preventDefault(); // Prevent default form submission
    submitOrder(); // Call the function to submit the order
});

function submitOrder() {
    var formData = $('#checkoutForm').serialize();
    // Check validity and add Bootstrap validation classes
    var form = document.getElementById("checkoutForm");
    if (form.checkValidity() === false) {
        event.stopPropagation();
        form.classList.add('was-validated');
    } else {
        // If valid, submit the form programmatically
        var url = $('#checkoutForm').attr('action');
        $("#OrderSubmit").prop("disabled", true).text("Loading...");

        // Perform an AJAX POST request
        $.ajax({
            type: "POST",
            url: url,
            data: formData,
            success: function (response) {


                if (response.success === true) {
                    // Show the alert
                    $('#order-alert').fadeIn();

                    // Automatically hide the alert after 3 seconds
                    setTimeout(function () {
                        $('#order-alert').fadeOut();
                    }, 3000);
                    window.location.href = '/hr/order/OrderConfirmation?orderId=' + response.orderId; // Redirect on success
                } else {
                    $("#OrderSubmit").prop("disabled", false).text("Dërgo porosinë");
                    $('#itemMsg').text(response.message || 'Error placing the order.').removeAttr('hidden');
                }
            },
            error: function (xhr, status, error) {
                console.error("Error status: " + status);
                console.error("XHR object:", xhr);
                console.error("Error details:", error);

                // Displaying error message to the user
                $('#itemMsg').text("An error occurred: " + xhr.status + " " + xhr.statusText);
                $('#itemMsg').removeAttr('hidden');

                // Detailed console logs for debugging
                if (xhr.responseText) {
                    console.error("Response text: " + xhr.responseText);
                }
                if (xhr.status === 302) {
                    console.error("Error: 302 Found. Possible redirect issue.");
                } else if (xhr.status === 403) {
                    console.error("Error: 403 Forbidden. Possible Anti-Forgery token issue.");
                } else if (xhr.status === 500) {
                    console.error("Error: 500 Internal Server Error. Possible server-side issue.");
                }
            }
        });
    }
    // Get the form's action URL

}


$(document).ready(function () {
    // Toggle buttons based on dropdown selection
    $('#PaymentMethoId').change(function () {
        // Get the selected payment method value
        var selectedPaymentMethod = $(this).val();

        if (selectedPaymentMethod === "BANK") {
            // Hide normal submit button, show bank submit button
            $('#OrderSubmit').hide();
            $('#OrderSubmitBank').show();
        } else {
            // Show normal submit button, hide bank submit button
            $('#OrderSubmit').show();
            $('#OrderSubmitBank').hide();
        }
    });

    $('#OrderSubmitBank').on('click', function () {
        var formData = $('#checkoutForm').serialize();
        // Check validity and add Bootstrap validation classes
        var form = document.getElementById("checkoutForm");
        if (form.checkValidity() === false) {
            event.stopPropagation();
            form.classList.add('was-validated');
        } else {
            // If valid, submit the form programmatically
            var url = '/hr/order/CreateBankOrder';
            $("#OrderSubmitBank").prop("disabled", true).text("Loading...");

            // Perform an AJAX POST request
            $.ajax({
                type: "POST",
                url: url,
                data: formData,
                success: function (response) {
                    console.log("Response from server:", response);

                    if (response.success === true) {
                        // Show the alert
                        $('#order-alert').fadeIn();

                        // Automatically hide the alert after 3 seconds
                        setTimeout(function () {
                            $('#order-alert').fadeOut();
                        }, 3000);
                        window.location.href = '/hr/order/BankPayment?orderId=' + response.orderId; // Redirect on success
                    } else {
                        $("#OrderSubmit").prop("disabled", false).text("Dërgo porosinë");
                        $('#itemMsg').text(response.message || 'Error placing the order.').removeAttr('hidden');
                    }
                },
                error: function (xhr, status, error) {
                    console.error("Error status: " + status);
                    console.error("XHR object:", xhr);
                    console.error("Error details:", error);

                    // Displaying error message to the user
                    $('#itemMsg').text("An error occurred: " + xhr.status + " " + xhr.statusText);
                    $('#itemMsg').removeAttr('hidden');

                    // Detailed console logs for debugging
                    if (xhr.responseText) {
                        console.error("Response text: " + xhr.responseText);
                    }
                    if (xhr.status === 302) {
                        console.error("Error: 302 Found. Possible redirect issue.");
                    } else if (xhr.status === 403) {
                        console.error("Error: 403 Forbidden. Possible Anti-Forgery token issue.");
                    } else if (xhr.status === 500) {
                        console.error("Error: 500 Internal Server Error. Possible server-side issue.");
                    }
                }
            });
        }

    });
});

// Listen for changes on the radio buttons
$('input[name="rdo-ani"]').change(function () {
    if ($('#edo-ani').is(':checked')) {
        // Show the credit card section if 'Card Payments' is selected
        $('#creditCard').show();
    } else {
        // Hide the credit card section if 'Cash On Delivery' is selected
        $('#creditCard').hide();
    }
});

let transport = 0;

// Listen for changes on the country dropdown
$('#inputState').change(function () {
    let selectedValue = $(this).val(); // Get the selected value

    // Get the current total price as a number
    var priceTot = parseFloat($('#totalPricee').val()) || 0;
    var finalTotal = priceTot; // Initialize finalTotal with the current total price

    // Assign the transport value based on the selected country
    switch (selectedValue) {
        case "Kosovë":
            transport = 2.00; // Example value for Kosovo
            break;
        case "Shqipëri":
            transport = 5.00; // Example value for Shqipëri
            break;
        case "Maqedoni":
            transport = 5.00; // Example value for Maqedoni
            break;
        default:
            transport = 0; // Default value if no valid option is selected
            break;
    }

    // Add the transport cost to the final total
    finalTotal += transport;

    // Update the #totPrice input with the final total
    $('#totPrice').text(finalTotal.toFixed(2)); // Set with 2 decimal places

    // Update the paragraph text with the transport cost
    if (transport > 0) {
        $('#transportCost').text(transport.toFixed(2)); // Show transport cost
    } else {
        $('#transportCost').text("Zgjidhni shtetin"); // Show default message if no valid country is selected
    }
});
