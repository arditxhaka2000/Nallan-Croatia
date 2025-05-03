using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Web.Models.Userss
{
    public class IndexUsersViewModel
    {
        public List<LanguageViewModel> Languages { get; set; }
        public List<RolesViewModel> Roles { get; set; }
        public IPagedList<UserAdminRowViewModel> Users { get; set; }
        public IEnumerable<int> SearchMunicipalities { get; set; }

    }

    public class UsersViewModel
    {
        public string Id { get; set; }
        public string userName { get; set; }
        public bool active { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string email { get; set; }
        public string UserPassword { get; set; }
        public int DefaultLanguageId { get; set; }
        public virtual LanguageViewModel DefaultLanguage { get; set; }

    }


    public class UserAdminRowViewModel
    {
        public string Id { get; set; }
        public string userName { get; set; }
        public bool active { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }

        public string email { get; set; }
        public string UserPassword { get; set; }
        public int? DefaultLanguageId { get; set; }
        public virtual LanguageViewModel DefaultLanguage { get; set; }

        public string RoleId { get; set; }
        public IEnumerable<int> SearchMunicipalities { get; set; }
        public string sSearchMunicipalities { get; set; }


    }
    public class AddUser
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }

        public bool active { get; set; }
        public string UserPassword { get; set; }
        public int DefaultLanguageId { get; set; }
        public List<string> _Roles { get; set; }

        public List<string> SearchMunicipalities { get; set; } 

    }

    public class UpdateUser
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }

        public string Email { get; set; }
        public bool active { get; set; }
        public string UserPassword { get; set; }
        public string DefaultLanguageId { get; set; }
        public List<string> _Roles { get; set; }
         
        public List<string> SearchMunicipalities { get; set; }
    }
    public class ChangePasswordModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public string PasswordHash { get; set; }
        public string newPassword { get; set; }
    }


    public class RolesViewModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }

}
