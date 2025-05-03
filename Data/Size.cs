using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Size : BaseEntity
    {
        public int Id { get; set; }
        public int SizeNr { get; set; }
        public virtual ICollection<ProductSize> ProductSizes { get; set; }


    }
}
