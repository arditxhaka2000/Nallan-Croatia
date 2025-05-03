using Data;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProductServ
{
    public class ProductSizeService : IProductSizeService
    {
        private IRepository<ProductSize> _repo;
        public ProductSizeService(IRepository<ProductSize> repo)
        {
            _repo = repo;
        }

        public List<ProductSize> GetAll()
        {
            return _repo.GetAll();
        }

        public List<ProductSize> GetAllByProductId(int ProductID)
        {
            var includes = new string[] { "Size" };
            return _repo.GetAsNoTracking(includeProperties: includes, filter: x => x.ProductId == ProductID).ToList();

        }

        public ProductSize GetById(int ProductSizeId)
        {
            return _repo.Get(ProductSizeId);
        }

        public void Insert(ProductSize Item)
        {
            _repo.Insert(Item);
        }

        public bool SaveChanges()
        {
            _repo.SaveChanges();
            return true;
        }

        public void Update(ProductSize Item)
        {
            _repo.Update(Item);

        }
    }
}
