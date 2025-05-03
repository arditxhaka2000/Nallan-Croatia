using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Web.Models
{
    public class LanguageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Active { get; set; }
    }

    public class LanguageListViewModel
    {
        public LanguageListViewModel()
        {
            list = new List<LanguageViewModel>();
        }
        public List<LanguageViewModel> list { get; set; }

        public string CurrentLanguage { get; set; }
        public List<SearchListViewModel> Lists { get; set; }
    }
 
    public class AddUpdateLanguageListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
    public class SearchListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Active { get; set; }
    }
}
