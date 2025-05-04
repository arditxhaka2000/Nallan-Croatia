using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ArticleData
    {
        public string MainCode { get; set; }     // ProductCode equivalent
        public string Barcode { get; set; }      // GTIN equivalent
        public string Name { get; set; }         // Title equivalent
        public string Info { get; set; }         // Description equivalent
        public string Specode { get; set; }      // Brand equivalent
        public string Parent { get; set; }       // Possibly ProductUrl or group
        public List<string> ImageUrls { get; set; }
        public List<string> Categories { get; set; }
        public decimal CmimiSh { get; set; }     // Price
        public decimal OldPrice { get; set; }    // You can map from another source or leave 0
        public int StoreStockQuantity { get; set; }   // From SASIA
        public int StoreSupplierQuantity { get; set; } // Optional – default 0
        public List<Specification> Specifications { get; set; } // Can be built from other columns
        public List<VariantApi> Variants { get; set; }          // If needed for sizes/colors
    }

}
