using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProductServ
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int CategoryId);
        void Update(Category Item);
        void Insert(Category Item);
        bool SaveChanges();
    }
}
