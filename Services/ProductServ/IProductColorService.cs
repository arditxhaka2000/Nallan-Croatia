using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProductServ
{
    public interface IProductColorService
    {
        List<ProductColor> GetAll();
        List<ProductColor> GetAllByProductId(int ProductId);
        ProductColor GetById(int ProductColorId);
        void Update(ProductColor Item);
        void Insert(ProductColor Item);
        bool SaveChanges();
    }
}
