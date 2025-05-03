using Data.Privileges;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Language : BaseEntity, IAuditTrail<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Active { get; set; }
        public virtual List<UserLanguage> UserLanguages { get; set; }
        public virtual List<AppUser> AppUsers { get; set; }
    }
}
