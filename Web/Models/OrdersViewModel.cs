using Data;
using OA_Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class IndexOrdersViewModel
    {
        public List<OrdersViewModel> Orders { get; set; }
    }
    public class OrdersViewModel
    {
        public int OrderId { get; set; } // Primary Key
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingCity { get; set; }
        public string ShipingCountry { get; set; }
        public string ShippingPostalCode { get; set; }
        public string PaymentType { get; set; }
        public int TransportFee { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }

        // Navigation property to represent the related order items
        public List<OrderItemViewModel> OrderItems { get; set; }

    }
    public class OrderItemViewModel
    {
        public int OrderItemId { get; set; } // Primary Key
        public int ProductId { get; set; } // Product related info
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }

        public int? OrderId { get; set; }
        public string ImagePath { get; set; }
        public string GTN { get; set; }

    }
}