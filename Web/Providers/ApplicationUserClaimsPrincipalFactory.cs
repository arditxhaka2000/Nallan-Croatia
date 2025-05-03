using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Repository;
using Services.Enum;
using Services.Privileges;
using Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Web.Providers
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<AppUser, ApplicationRole>
    {


        private readonly IUsersService _usersService;
        private readonly IUserActionRootRestRightService _userActionRootRestRightService;
        public ApplicationUserClaimsPrincipalFactory(UserManager<AppUser> userManager,
            RoleManager<ApplicationRole> roleManager, IOptions<IdentityOptions> options,  IUsersService usersService, IUserActionRootRestRightService userActionRootRestRightService)
            : base(userManager, roleManager, options)
        {
            _usersService = usersService;
            _userActionRootRestRightService = userActionRootRestRightService;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            var RoleName = this._usersService.GetRolesByUserId(user).Count() > 0 ? this._usersService.GetRolesByUserId(user)[0].ToString() : "";

            var RoleId = this._usersService.GetRoleByRoleName(RoleName).Id;

            var RoleRights = _userActionRootRestRightService.GetAll(RoleId).ToList();//privileges by RoleId


        

            try
            {
                if (user != null && user.DefaultLanguage != null)
                {
                    foreach (var item in RoleRights)
                    {
                        if (item.CanDelete)
                        {
                            identity.AddClaim(new Claim(item.ActionRoot.CodeName, Mode.CanDelete+""));
                        }
                        if (item.CanRead)
                        {
                            identity.AddClaim(new Claim(item.ActionRoot.CodeName, Mode.CanView+""));
                        }
                        if (item.CanWrite)
                        { 
                            string genderStr = JsonConvert.SerializeObject(item);
                            identity.AddClaim(new Claim(item.ActionRoot.CodeName, Mode.CanEit + "")); 
                            identity.AddClaim(new Claim(item.ActionRoot.CodeName, genderStr)); 
                        }

                    }

                    identity.AddClaim(new Claim("LangCode", user.DefaultLanguage.Code.ToLower() ?? ""));
                   
                }
                else
                {
                    identity.AddClaim(new Claim("LangCode", "sq"));

                }


            }
            catch (Exception)
            {

            }
            return identity;
        }
    }
}
