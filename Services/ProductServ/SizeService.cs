using Data;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProductServ
{
    public class SizeService : ISizeService
    {
        private IRepository<Size> _repo;
        public SizeService(IRepository<Size> repo)
        {
            _repo = repo;
        }

        public void Delete(Size Item)
        {
            _repo.Delete(Item);
        }

        public List<Size> GetAll()
        {
            return _repo.GetAll();
        }

        public Size GetById(int SizeId)
        {
            return _repo.Get(SizeId);
        }

        public void Insert(Size Item)
        {
            _repo.Insert(Item);
        }

        public bool SaveChanges()
        {
            _repo.SaveChanges();
            return true;
        }

        public void Update(Size Item)
        {
            _repo.Update(Item);

        }
    }
}
