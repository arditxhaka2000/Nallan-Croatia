using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Languages
{
    public interface ILanguageService
    {
        List<Language> GetAll();
        IQueryable<Language> GetAllAsQuerable(string searchName, string searchCode, bool Active);
        List<Language> GetAllActive();
        List<Language> GetAllByIds(List<int> Ids);
        void Update(Language Item);
        void Insert(Language Item);
        Language GetById(int id);
        bool SaveChanges();
    }
}
