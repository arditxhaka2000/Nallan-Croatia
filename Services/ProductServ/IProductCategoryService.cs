using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProductServ
{
    public interface IProductCategoryService
    {
        List<ProductCategory> GetAll();
        List<ProductCategory> GetAllByProductId(int ProductID);
        ProductCategory GetById(int ProductCategoryId);
        void Update(ProductCategory Item);
        void Insert(ProductCategory Item);
        bool SaveChanges();
    }
}
