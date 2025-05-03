using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProductServ
{
    public interface IProductSizeService
    {
        List<ProductSize> GetAll();
        List<ProductSize> GetAllByProductId(int ProductID);
        ProductSize GetById(int ProductSizeId);
        void Update(ProductSize Item);
        void Insert(ProductSize Item);
        bool SaveChanges();
    }
}
