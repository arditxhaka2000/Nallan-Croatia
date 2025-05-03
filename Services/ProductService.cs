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
    public class ProductService : IProductService
    {
        private IRepository<Product> _repo;
        public ProductService(IRepository<Product> repo)
        {
            _repo = repo;
        }

        public List<Product> GetAll()
        {

            var includes = new string[] { "Categories","Images","Sizes","Colors" };
            return _repo.GetAsNoTracking(includeProperties: includes).ToList();
        }

        public Product GetById(int ProductId)
        {
            var includes = new string[] { "Categories", "Images", "Sizes", "Colors" };
            return _repo.GetAsNoTracking(p => p.ProductId == ProductId, includeProperties: includes).FirstOrDefault();
        }

        public void Insert(Product Item)
        {
            _repo.Insert(Item);
        }

        public bool SaveChanges()
        {
            _repo.SaveChanges();
            return true;
        }

        public void Update(Product Item)
        {
            _repo.Update(Item);

        }
    }
}
