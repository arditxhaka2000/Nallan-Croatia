using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data
{
    //not used
    public class Product : BaseEntity
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string ProductCode { get; set; }
        public string GTIN { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string ProductUrl { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public int Quantity { get; set; }


        // Navigation properties
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<ProductSize> Sizes { get; set; }
        public virtual ICollection<ProductCategory> Categories { get; set; }
        public virtual ICollection<ProductColor> Colors { get; set; }
    }
}
