using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data
{
    public class AppUser : IdentityUser, Privileges.IAuditTrail<string>
    {
        //public override string Id { get; set; }

        public bool active { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode{ get; set; }
        public virtual List<UserLanguage> UserLanguages { get; set; }

        [Column("DefaultLanguageId")]
        [ForeignKey("DefaultLanguage")]
        public int? DefaultLanguageId { get; set; }
        public virtual Language DefaultLanguage { get; set; }

    }
}
