using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Image :BaseEntity
    {
        public Image()
        {
            Date = DateTime.Now;
        }

        public Guid Id { get; set; }
        public string Path { get; set; }
        public string DocumentName { get; set; }
        public DateTime Date { get; set; }
        public int Size { get; set; }

        [Column("ProductId")]
        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
        
        [Column("CategoryId")]
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
