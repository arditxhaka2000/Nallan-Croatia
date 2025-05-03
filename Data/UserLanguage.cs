using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class UserLanguage
    {
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
    }
}
