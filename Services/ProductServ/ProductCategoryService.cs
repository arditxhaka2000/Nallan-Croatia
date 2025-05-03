using Data;
using Irony.Parsing;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProductServ
{
    public class ProductCategoryService : IProductCategoryService
    {
        private IRepository<ProductCategory> _repo;
        public ProductCategoryService(IRepository<ProductCategory> repo)
        {
            _repo = repo;
        }

        public List<ProductCategory> GetAll()
        {
            return _repo.GetAll();
        }

        public List<ProductCategory> GetAllByProductId(int ProductID)
        {

            var includes = new string[] { "Category" };
            return _repo.GetAsNoTracking(includeProperties: includes, filter: x => x.ProductId == ProductID).ToList();
        }

        public ProductCategory GetById(int ProductCategoryId)
        {
            return _repo.Get(ProductCategoryId);
        }

        public void Insert(ProductCategory Item)
        {
           _repo.Insert(Item);
        }

        public bool SaveChanges()
        {
            _repo.SaveChanges();
            return true;
        }

        public void Update(ProductCategory Item)
        {
            _repo.Update(Item);

        }
    }
}
