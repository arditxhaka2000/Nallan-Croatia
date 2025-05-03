using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int ProductId);
        void Update(Product Item);
        void Insert(Product Item);
        bool SaveChanges();
    }
}
