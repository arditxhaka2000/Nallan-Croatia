using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Localization;
using Web.Resources;

namespace Web.Infrastructure
{
    public class CustomLocalizer : StringLocalizer<Common>
    {
        private readonly IStringLocalizer _internalLocalizer;

        public CustomLocalizer(IStringLocalizerFactory factory) : base(factory)
        {

        }
        public CustomLocalizer(IStringLocalizerFactory factory, IHttpContextAccessor httpContextAccessor) : base(factory)
        {
            CurrentLanguage = httpContextAccessor.HttpContext.GetRouteValue("lang") as string;
            if (string.IsNullOrEmpty(CurrentLanguage))
            {
                CurrentLanguage = "hr";
            }

            CultureInfo cultureInfo = new CultureInfo(CurrentLanguage);
            _internalLocalizer =  (IStringLocalizer)cultureInfo;
        }

        public override LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                return _internalLocalizer[name, arguments];
            }
        }

        public override LocalizedString this[string name]
        {
            get
            {
                return _internalLocalizer[name];
            }
        }

        public string CurrentLanguage { get; set; }
    }
}

