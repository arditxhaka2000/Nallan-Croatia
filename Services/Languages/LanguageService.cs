using Data;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Languages
{
    public class LanguageService : ILanguageService
    {
        private IRepository<Language> _repo;
        public LanguageService(IRepository<Language> repo)
        {
            _repo = repo;
        }

        public List<Language> GetAll()
        {
            return _repo.GetAll();
        }
       

        public List<Language> GetAllActive()
        {
            return _repo.Get(filter: x => x.Active).ToList();
        }

        public IQueryable<Language> GetAllAsQuerable(string searchName, string searchCode, bool Active)
        {
            var result = _repo.GetAsQueryable();

            if (!string.IsNullOrEmpty(searchName))
            {
                result = result.Where(x => x.Name.Contains(searchName));
            }
            if (!string.IsNullOrEmpty(searchCode))
            {
                result = result.Where(x => x.Code.Contains(searchCode));
            }
            if (Active)
            {
                result = result.Where(x => x.Active);
            }

            return result;
        }

        public void Insert(Language Item)
        {
            _repo.Insert(Item);
        }

        public void Update(Language Item)
        {
            _repo.Update(Item);
        }
        public Language GetById(int id)
        {
            return _repo.Get(id);
        }
        public bool SaveChanges()
        {
            _repo.SaveChanges();
            return true;
        }

        public List<Language> GetAllByIds(List<int> Ids)
        {
            return _repo.GetAsNoTracking(c => !Ids.Contains(c.Id) && c.Active == true).ToList();
        }
    }
}
