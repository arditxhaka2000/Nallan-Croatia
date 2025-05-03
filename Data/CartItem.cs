using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CartItem
    {
        public string ProductId { get; set; }

        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string GTN { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; } // Optional, for displaying product image
        public string SelectedSize { get; set; } // Optional, for displaying product image
    }

}
