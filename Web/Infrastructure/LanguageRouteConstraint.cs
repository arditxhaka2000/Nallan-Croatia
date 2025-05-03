using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Services.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Infrastructure
{
    public class LanguageRouteConstraint : IRouteConstraint
    {
        //private readonly ILanguageService _languageService;
        //public LanguageRouteConstraint(ILanguageService languageService)
        //{
        //    _languageService = languageService;
        //}
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!values.ContainsKey("lang"))
            {
                return false;
            }

            var lang = values["lang"].ToString();
            //  var testlang = _languageService.GetAllActive();
            return Languages(lang);
        }

        public static bool Languages(string lang)
        {
            return lang == "sq" || lang == "en" || lang == "sr" || lang == "tr" || lang == "bs" || lang == "ar" || lang == "bg" || lang == "ca" || lang == "ch" || lang == "hr" ||
                lang == "cs" || lang == "da" || lang == "nl" || lang == "fr" || lang == "de" || lang == "el" || lang == "he" || lang == "hi" || lang == "hu" || lang == "is" ||
                lang == "id" || lang == "it" || lang == "ja" || lang == "ko" || lang == "lv" || lang == "lt" || lang == "mk" || lang == "be" || lang == "bn" || lang == "fo" ||
                lang == "ka" || lang == "ks" || lang == "lv" || lang == "ml" || lang == "no" || lang == "pl" || lang == "pt" || lang == "ro" || lang == "ru" || lang == "sk" ||
                lang == "sl" || lang == "es" || lang == "sv" || lang == "uk" || lang == "vi" || lang == "gl" || lang == "gd" || lang == "et" || lang == "eu";
        }
    }
}
