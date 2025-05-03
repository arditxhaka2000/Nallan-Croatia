using Data;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProductServ
{
    public class ColorService : IColorService
    {
        private IRepository<Color> _repo;
        public ColorService(IRepository<Color> repo)
        {
            _repo = repo;
        }

        public void Delete(Color Item)
        {
            _repo.Delete(Item);
        }

        public List<Color> GetAll()
        {
            return _repo.GetAll();
        }

        public Color GetById(int ColorId)
        {
            return _repo.Get(ColorId);
        }

        public void Insert(Color Item)
        {
            _repo.Insert(Item);
        }

        public bool SaveChanges()
        {
            _repo.SaveChanges();
            return true;
        }

        public void Update(Color Item)
        {
            _repo.Update(Item);

        }
    }
}
