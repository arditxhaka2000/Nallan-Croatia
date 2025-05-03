using Data;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProductServ
{
    public class CategoryService : ICategoryService
    {
        private IRepository<Category> _repo;
        public CategoryService(IRepository<Category> repo)
        {
            _repo = repo;
        }

        public List<Category> GetAll()
        {

            var includes = new string[] {"Image"};
            return _repo.GetAsNoTracking(includeProperties: includes).ToList();
            //return  _repo.GetAll();
        }

        public Category GetById(int CategoryId)
        {
            return _repo.Get(CategoryId);
        }

        public void Insert(Category Item)
        {
            _repo.Insert(Item);
        }

        public bool SaveChanges()
        {
            _repo.SaveChanges();
            return true;
        }

        public void Update(Category Item)
        {
            _repo.Update(Item);

        }
    }
}
