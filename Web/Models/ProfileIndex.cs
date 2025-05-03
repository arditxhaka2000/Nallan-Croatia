using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class ProfileIndexViewModel
    {

        public ProfileIndex Profile { get; set; }
        public List<LanguageViewModel> Language { get; set; }

    }
    public class ProfileIndex
    {
        public string id { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public int? DefaultLanguageId { get; set; }
        public LanguageViewModel DefaultLanguage { get; set; }

    }

    public class UpdateProfileModel
    {
        public int DefaultLanguageId { get; set; }
    }
}
