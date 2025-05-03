using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.RolesAndPrivileges
{
    public class GetActionRootViewModel
    { 
        public Guid Id { get; set; } 
        public string CodeName { get; set; }
        public string NameAl { get; set; }
        public string NameSr { get; set; }
        public string NameEn { get; set; }  
    }
    public class GetUserActionRootRestRightViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public string CodeName { get; set; }
        public string NameAl { get; set; }
        public Guid ActionRootId { get; set; }
        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }
        public bool CanDelete { get; set; }
        public bool HasWriteDateValidation { get; set; }
        public DateTime? DateFromWriteValidation { get; set; }
        public DateTime? DateToWriteValidation { get; set; }

    }
    public class GetIdentityRoleViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        //public List<GetUserComplaintTabViewModel> UserComplaintTabs { get; set; }

    }
    public class GetIdentityRolesViewModel
    {

        public List<GetActionRootViewModel> ActionRoots { get; set; }
        public List<GetIdentityRoleViewModel> Roles { get; set; }

    }
    public class GetPrivilegesViewModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }

        public List<GetUserActionRootRestRightViewModel> ActionRoots { get; set; } 
    }
 
}
