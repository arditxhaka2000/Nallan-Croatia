using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class OrderItem : BaseEntity
    {
        public int OrderItemId { get; set; } // Primary Key
        public int ProductId { get; set; } // Product related info
        public string ProductCode { get; set; } // Product related info
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }
        public string ImagePath { get; set; }
        public string GTN { get; set; }


        [Column("OrderId")]
        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
