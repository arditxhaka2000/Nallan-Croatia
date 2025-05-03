using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Localizations
{
    public interface ILocalizationsService
    {
        List<Localization> GetAll();
        IQueryable<Localization> GetAllAsQuerable(string searchName, string keyvalue, string resourceKey, IEnumerable<int> Languages);
        List<Localization> GetAll(int LanguageId);
        List<Localization> GetTokensByLang(string code);
        List<Localization> GetTokensByResKey(string resKey);
        IQueryable<Localization> GetAllWithParamaters(int? LanguageId);
        void Update(Localization Item);
        void Insert(Localization Item);
        void InsertRange(List<Localization> Item);
        Localization GetById(int id);
        bool CheckByKeyName(string keyName);
        bool SaveChanges();
    }
}
