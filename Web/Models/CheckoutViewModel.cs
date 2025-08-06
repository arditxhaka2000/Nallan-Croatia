using Data;
using System.Collections.Generic;

namespace Web.Models
{
    public class CheckoutViewModel
    {
        // List of items in the cart
        public List<CartItem> CartItems { get; set; }

        // Total price of all items in the cart
        public decimal TotalPrice { get; set; }

        // Optional: Add customer info fields if needed for the checkout
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }

        // Optional: Shipping details
        public string ShippingAddress { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingPostalCode { get; set; }
        public string PaymentType { get; set; }
        public string PhoneNumber { get; set; }
        public decimal TransportFee { get; set; }
        public string ShipingCountry { get; set; }
        //public bool CardPaymentCompleted { get; set; }
    }

}
