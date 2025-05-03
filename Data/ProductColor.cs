using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProductColor : BaseEntity
    {
        public int Id { get; set; }
        public string ColorName { get; set; }

        [Column("ProductId")]
        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }


        [Column("ColorId")]
        [ForeignKey("Color")]
        public int? ColorId { get; set; }
        public virtual Color Color { get; set; }

    }
}
