using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Order : BaseEntity
    {
        public int OrderId { get; set; } // Primary Key
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        public string ShippingAddress { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingPostalCode { get; set; }
        public string PaymentType { get; set; }
        public string TransactionId { get; set; }
        public string PaymentReference { get; set; }
        public string PaymentStatus { get; set; }
        public int TransportFee { get; set; }
        public string PhoneNumber { get; set; }
        //public bool CardPaymentCompleted { get; set; }
        public string ShipingCountry { get; set; }



        // Navigation property to represent the related order items
        public List<OrderItem> OrderItems { get; set; }
    }
}
