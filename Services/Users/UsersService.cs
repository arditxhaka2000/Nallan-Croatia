using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository<AppUser> appUsersRepository;
        private readonly IUserRepository<ApplicationRole> appUserRolesRepository;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<AppUser> userManager;
        public UsersService(IUserRepository<AppUser> appUsersRepository, IUserRepository<ApplicationRole> appUserRolesRepository, UserManager<AppUser> _userManager, RoleManager<ApplicationRole> _roleManager)
        {
            this.appUsersRepository = appUsersRepository;
            this.appUserRolesRepository = appUserRolesRepository;
            userManager = _userManager;
            roleManager = _roleManager;
        }
        public AppUser FindByEmail(AppUser user)
        {
            //return await this.userManager.FindByEmailAsync(email).Result;
            return this.appUsersRepository.GetAsNoTracking(filter: x => x.Email == user.Email && x.Id != user.Id).FirstOrDefault();
        }

        public async Task<AppUser> FindByName(string UserName)
        {
            return await this.userManager.FindByNameAsync(UserName);
        }

        public List<AppUser> GetAllUsers()
        {
            IEnumerable<string> includes = new string[] { "DefaultLanguage" };
            return this.appUsersRepository.Get(includeProperties: includes).ToList();
        }

        public List<AppUser> GetAllUsersByUsername(string username = "")
        {
            throw new NotImplementedException();
        }

        public AppUser GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public List<AppUser> GetByIds(List<string> Ids)
        {
            throw new NotImplementedException();
        }
        public bool Create(AppUser appUser)
        {
            this.appUsersRepository.Insert(appUser);
            return true;
        }
        public ApplicationRole GetRoleByUserName(string Username)
        {
            var GetUer = userManager.FindByNameAsync(Username).Result;
            var Role = this.userManager.GetRolesAsync(GetUer).Result.FirstOrDefault();
            var RoleItem = GetRoleByNameWithInclude(Role);
            return RoleItem;
        }
        public ApplicationRole GetRoleByNameWithInclude(string Name)
        {
            return this.roleManager.Roles.Include(x => x.Parent).Where(x => x.Name == Name).FirstOrDefault();
            //   return this.userManager.crea.RoleManager.Create(Role).Succeeded;
        }
        public AppUser FindByUserName(string Username)
        {
            IEnumerable<string> includes = new string[] { "DefaultLanguage" };
            return this.appUsersRepository.Get(filter: x => x.UserName.ToLower() == Username.ToLower(), includeProperties: includes).FirstOrDefault();
        }

        public bool Update(AppUser appUser)
        {

            this.appUsersRepository.Update(appUser);
            return true;
        }


        public async Task<AppUser> FindByEmail(string email)
        {
            return await this.userManager.FindByEmailAsync(email);
        }

        public bool ChangePassword(AppUser user, string currentPassword, string newPassword)
        {
            return this.userManager.ChangePasswordAsync(user, currentPassword, newPassword).Result.Succeeded;
        }

        public bool AddToRoles(AppUser user, List<string> roles)
        {
            return this.userManager.AddToRolesAsync(user, roles.ToArray()).Result.Succeeded;
        }
        //public bool AddToMunicipalities(AppUser user, List<string> Municipalities)
        //{
        //    return this.userManager.AddToRolesAsync(user, roles.ToArray()).Result.Succeeded;
        //}
        //public bool AddToMunicipalities(AppUser user, string Municipalities)
        //{
        //    return this.userManager.AddToRolesAsync(user, roles.ToArray()).Result.Succeeded;
        //}
        public bool AddToRole(AppUser user, string role)
        {
            return this.userManager.AddToRoleAsync(user, role).Result.Succeeded;
        }
        public bool AddRole(ApplicationRole Role)
        {
            this.appUserRolesRepository.Insert(Role);
            return true;

            //   return this.userManager.crea.RoleManager.Create(Role).Succeeded;

        }
        public bool UpdateRole(ApplicationRole Role)
        {
            //return this.roleManager.UpdateAsync(Role).Result.Succeeded;

            this.appUserRolesRepository.Update(Role);
            return true;
            //   return this.userManager.crea.RoleManager.Create(Role).Succeeded;

        }
        public ApplicationRole GetRoleById(string Id)
        {
            return this.roleManager.FindByIdAsync(Id).Result;
            //   return this.userManager.crea.RoleManager.Create(Role).Succeeded;

        }
        public ApplicationRole GetRoleByName(string Name)
        {
            return this.roleManager.FindByNameAsync(Name).Result;
            //   return this.userManager.crea.RoleManager.Create(Role).Succeeded;

        }

        public IQueryable<AppUser> GetAllAsQuerable(string searchName)
        {
            IEnumerable<string> includes = new string[] { "DefaultLanguage" };

            var result = appUsersRepository.GetAsQueryable(includeProperties: includes);

            if (!string.IsNullOrEmpty(searchName))
            {
                result = result.Where(x => x.UserName.Contains(searchName));
            }

            return result;
        }



        public bool RemoveFromRoles(AppUser user, string role)
        {
            return this.userManager.RemoveFromRoleAsync(user, role).Result.Succeeded;
        }
        public IEnumerable<ApplicationRole> GetAllRoles()
        {
            return this.roleManager.Roles.ToList();
        }

        public ApplicationRole GetRoleByUserId(string UserId)
        {
            var role = this.roleManager.Roles.Where(x => x.Id == UserId).FirstOrDefault();
            return role;
        }
        public ApplicationRole GetRoleByRoleName(string RoleName)
        {
            var role = this.roleManager.Roles.Where(x => x.Name == RoleName).FirstOrDefault();
            return role;
        }

        public List<string> GetRolesByUserId(AppUser user)
        {
            return this.userManager.GetRolesAsync(user).Result.ToList();
        }

        public bool IsInRole(AppUser user, string roleName)
        {
            return this.userManager.IsInRoleAsync(user, roleName).Result;
        }
    }
}
