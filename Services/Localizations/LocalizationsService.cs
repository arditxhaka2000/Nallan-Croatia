using Data;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Localizations
{
    public class LocalizationsService : ILocalizationsService
    {
        private IRepository<Localization> _repo;
        public LocalizationsService(IRepository<Localization> repo)
        {
            _repo = repo;
        }

        public List<Localization> GetAll()
        {
            var includes = new string[] { "Language" };
            return _repo.GetAsNoTracking(includeProperties: includes).ToList();
        }

        public List<Localization> GetAll(int LanguageId)
        {
            var includes = new string[] { "Language" };
            return _repo.GetAsNoTracking(includeProperties: includes, filter: x => x.LanguageId == LanguageId).ToList();
        }

        public List<Localization> GetTokensByLang(string code)
        {
            var includes = new string[] { "Language" };
            return _repo.GetAsNoTracking(includeProperties: includes, filter: x => x.Language.Code == code).ToList();
        }

        public List<Localization> GetTokensByResKey(string resKey)
        {
            var includes = new string[] { "Language" };
            return _repo.GetAsNoTracking(includeProperties: includes, filter: x => x.ResourceKey == resKey).ToList();
        }
        public bool CheckByKeyName(string keyName)
        { 
            return _repo.Any( filter: x => x.KeyName == keyName);
        }

        public IQueryable<Localization> GetAllAsQuerable(string searchName, string keyvalue, string resourceKey, IEnumerable<int> Languages)
        {

            var includes = new string[] { "Language" };
            var result = _repo.GetAsQueryable(includeProperties: includes);

            if (!string.IsNullOrEmpty(searchName))
            {
                result = result.Where(x => x.KeyName.Contains(searchName));
            }
            if (!String.IsNullOrWhiteSpace(keyvalue))
            {
                result = result.Where(x => x.KeyValue.Contains(keyvalue));
            }
            if (!String.IsNullOrWhiteSpace(resourceKey))
            {
                result = result.Where(x => x.ResourceKey.Contains(resourceKey));
            }

            if (Languages.ToList().Count() > 0)
            {
                result = result.Where(x => Languages.Contains(x.LanguageId));
            }

            return result;
        }

        public Localization GetById(int id)
        {
            return _repo.Get(id);
        }
        public IQueryable<Localization> GetAllWithParamaters(int? LanguageId)
        {
            var includes = new string[] { "Language" };
            var result = _repo.GetAsQueryable(includeProperties: includes);
            if (LanguageId != 0)
            {
                result = result.Where(x => x.LanguageId == LanguageId);
            }

            return result;
        }

        public void Insert(Localization Item)
        {
            _repo.Insert(Item);
        }

        public void InsertRange(List<Localization> Item)
        {
            _repo.InsertRange(Item);
        }

        public bool SaveChanges()
        {
            _repo.SaveChanges();
            return true;
        }

        public void Update(Localization Item)
        {
            _repo.Update(Item);
        }
    }
}


