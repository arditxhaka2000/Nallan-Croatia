using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data
{
   
    public class UserChangeHistory : BaseEntity, Privileges.IAuditTrail<Guid>
    {
        public UserChangeHistory()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }

        public virtual ChangeType ChangeType { get; set; }
        public string ChangeInfo { get; set; }
         
    }
    public enum ChangeType
    {
        Root = 1,
        RootTranslation = 2,
        Node = 4,
        NodeTranslation = 8
    }
}
