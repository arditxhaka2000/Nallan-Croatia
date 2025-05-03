using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ApplicationRole : IdentityRole<string>, Data.Privileges.IAuditTrail<string>
    {
        public string Description { get; set; }
        public ApplicationRole()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Column("ParentId")]
        [ForeignKey("Parent")]
        public string ParentId { get; set; }
        public ApplicationRole Parent { get; set; }
    }
}
