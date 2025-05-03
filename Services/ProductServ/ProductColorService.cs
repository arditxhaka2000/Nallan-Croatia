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
    public class ProductColorService : IProductColorService
    {
        private IRepository<ProductColor> _repo;
        public ProductColorService(IRepository<ProductColor> repo)
        {
            _repo = repo;
        }

        public List<ProductColor> GetAll()
        {
            return _repo.GetAll();
        }

        public List<ProductColor> GetAllByProductId(int ProductId)
        {
            var includes = new string[] { "Color" };
            return _repo.GetAsNoTracking(includeProperties: includes, filter: x => x.ProductId == ProductId).ToList();

        }

        public ProductColor GetById(int ProductColorId)
        {
            return _repo.Get(ProductColorId);
        }

        public void Insert(ProductColor Item)
        {
            _repo.Insert(Item);
        }

        public bool SaveChanges()
        {
            _repo.SaveChanges();
            return true;
        }

        public void Update(ProductColor Item)
        {
            _repo.Update(Item);

        }
    }
}
