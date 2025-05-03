using DocumentFormat.OpenXml.VariantTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ApiData
    {
      
            public string ProductCode { get; set; }
            public string GTIN { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Brand { get; set; }
            public string ProductUrl { get; set; }
            public List<string> ImageUrls { get; set; }
            public List<string> Categories { get; set; } // Now a list of strings
            public decimal Price { get; set; }
            public decimal OldPrice { get; set; }
            public int StoreStockQuantity { get; set; }
            public int StoreSupplierQuantity { get; set; }
            public List<Specification> Specifications { get; set; }
            public List<VariantApi> Variants { get; set; }
        }

}
