using Data.Privileges;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Services.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Web.Infrastructure
{
    public class ClaimRequirementAttribute : TypeFilterAttribute
    {
        public ClaimRequirementAttribute(Mode claimType, ControllerEnum claimValue) : base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] { new Claim(claimValue.ToString(), claimType.ToString()) };
        }


    }
    public class ClaimRequirementFilter : IAuthorizationFilter
    {
        readonly Claim _claim;

        public ClaimRequirementFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            var hasClaim = user.Claims.Any(c => c.Type == _claim.Type && c.Value == _claim.Value);

            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new ForbidResult();
                return;
            }

            if (user.IsInRole("Administrator"))
            {
                return;
            }
            if (_claim.Value == Mode.CanEit.ToString())
            {
                if (!RoleRightProvider.HasWriteRight(user, _claim.Type))
                {
                    context.Result = new ForbidResult();
                }
            } 
           else if (!hasClaim)
            {
                context.Result = new ForbidResult();
            }


        }
    }
}


namespace Microsoft.AspNetCore.Mvc
{
    public static class RoleRightProvider
    {
        private static bool HasRight(IPrincipal User, ControllerEnum controllerEnum, Mode claimType)
        {
            var identity = User.Identity as ClaimsIdentity;
            var hasClaim = identity.Claims.Any(c => c.Type == controllerEnum.ToString() && c.Value == claimType.ToString());

            if (!User.Identity.IsAuthenticated)
            {
                return false;
            }
            if (User.IsInRole("Administrator"))
            {
                return true;
            }
            if (!hasClaim)
            {
                return false;
            }

            return true;
        }
        /*
           identity.AddClaim(new Claim("HasWriteDateValidation", item.HasWriteDateValidation+""));
                            identity.AddClaim(new Claim("DateFromWriteValidation", item.DateFromWriteValidation+""));
                            identity.AddClaim(new Claim("DateToWriteValidation", item.DateToWriteValidation+""));
         */
        public static bool HasWriteRight(IPrincipal User, string controllerName)
        {
            var identity = User.Identity as ClaimsIdentity;
             
            if (!User.Identity.IsAuthenticated)
            {
                return false;
            }
            if (User.IsInRole("Administrator"))
            {
                return true;
            }

            var rootobj = identity.Claims.LastOrDefault(c => c.Type == controllerName).Value.ToString();
            if (rootobj == null)
            { return true; }

            UserActionRootRestRight genderObj = JsonConvert.DeserializeObject<UserActionRootRestRight>(rootobj);


            var hasValueWriteValidation = genderObj.HasWriteDateValidation;
            var hasDateFromWriteValidation = genderObj.DateFromWriteValidation;
            var hasDateToWriteValidation = genderObj.DateToWriteValidation;

            if (!hasValueWriteValidation)
            {
                return true;
            }
            if (hasValueWriteValidation)
            {
                bool haswriteriht = genderObj.HasWriteDateValidation;

                if (!haswriteriht)
                {
                    return false;

                }
                if (hasDateFromWriteValidation.HasValue && hasDateToWriteValidation.HasValue)
                {
                     
                    DateTime datefrom1 = hasDateFromWriteValidation.Value;// hasdate1 = DateTime.TryParse(hasDateFromWriteValidationValue, out DateTime datefrom1);
                    DateTime datefrom2 = hasDateToWriteValidation.Value;//   var hasdate2 = DateTime.TryParse(hasDateToWriteValidationValue, out DateTime datefrom2);

                    return DateTime.Now.Date.AddDays(-1).AddSeconds(1) <= datefrom2 && DateTime.Now.Date.AddDays(1).AddSeconds(-1) >= datefrom1;

                }



            }

            return true;
        }
        public static bool CanWrite(this IPrincipal User, ControllerEnum controllerEnum)
        {
            return HasRight(User, controllerEnum, Mode.CanEit) && HasWriteRight(User, controllerEnum.ToString());
        }
        public static bool CanRead(this IPrincipal User, ControllerEnum controllerEnum)
        {
            return HasRight(User, controllerEnum, Mode.CanView);
        }
        public static bool CanDelete(this IPrincipal User, ControllerEnum controllerEnum)
        {
            return HasRight(User, controllerEnum, Mode.CanDelete);
        }
    }

}
namespace System.Collections.Generic
{
    public static class keyrovider
    {
        public static List<string> addValue = new List<string>();
        public static List<string> getVaues(this Dictionary<string, string> sharedRes)
        {
            return addValue;
        }


        public static string CheckKey(this Dictionary<string, string> sharedRes, string key)
        {
            var rez = key;

            if (!sharedRes.ContainsKey(key))
            {
                addValue.Add(key);
            }
            else
            {
                rez = sharedRes[key];
            }

            return rez;

        }
    }
}

