using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class VariantApi
    {
        public string ProductCode { get; set; } // Unique code for the variant
        public string GTIN { get; set; } // Global Trade Item Number for the variant
        public string Title { get; set; } // Title of the variant
        public string Description { get; set; } // Description of the variant
        public string Brand { get; set; } // Brand of the variant
        public string ProductUrl { get; set; } // URL for the variant
        public List<string> ImageUrls { get; set; } // List of images for the variant
        public List<string> Categories { get; set; } // Categories specific to the variant
        public decimal Price { get; set; } // Price of the variant
        public decimal OldPrice { get; set; } // Old price of the variant (if applicable)
        public int StoreStockQuantity { get; set; } // Stock quantity in the store
        public int StoreSupplierQuantity { get; set; } // Supplier stock quantity
        public List<Specification> Specifications { get; set; } // Specifications for the variant

    }
}
