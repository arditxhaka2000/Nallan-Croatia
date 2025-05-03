using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Web.Models.Localizations
{
  
    public class IndexLocalizationViewModel
    {
        public List<LocalizationViewModel> localizations { get; set; }
        public List<LanguageViewModel> listlanguages { get; set; }
        public List<LocalizationViewModel> localizationslist { get; set; }
        public IEnumerable<int> SearchLanguages { get; set; }


    }
    public class LocalizationViewModel
    {
        public int Id { get; set; }
        public string ResourceKey { get; set; }
        public string KeyName { get; set; }
        public string KeyValue { get; set; }
        public string Description { get; set; }
        public int LanguageId { get; set; }
        public LanguageViewModel Language { get; set; }
    }
    public class UpdateLocalizationViewModel
    {
        public int Id { get; set; }
        public string KeyValue { get; set; }
        public string Description { get; set; }
    }
    public class CreateUpdateLocalizationViewModel
    {
        public int Id { get; set; }
       public string ResourceKey { get; set; }
        public string KeyName { get; set; }
        public string KeyValue { get; set; }
        public string KeyValueEn { get; set; }
        public string KeyValueSr { get; set; }
        public string Description { get; set; }
        public int LanguageId { get; set; }
    }
}
