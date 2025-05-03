using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProductSize : BaseEntity
    {
        public int Id { get; set; }
        public string SizeNr { get; set; }

        [Column("ProductId")]
        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }


        [Column("SizeId")]
        [ForeignKey("Size")]
        public int? SizeId { get; set; }
        public virtual Size Size { get; set; }


    }
}
