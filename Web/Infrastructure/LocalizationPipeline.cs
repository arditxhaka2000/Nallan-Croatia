using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using static System.Globalization.CultureTypes;

namespace Web.Infrastructure
{
    public class LocalizationPipeline
    {
        public void Configure(IApplicationBuilder app)
        {
            var options = new RequestLocalizationOptions();
            ConfigureOptions(options);

            app.UseRequestLocalization(options);
        }

        public static void ConfigureOptions(RequestLocalizationOptions options)
        {
            var dateformat = new DateTimeFormatInfo
            {
                ShortDatePattern = "dd/MM/yyyy",
                LongDatePattern = "dd/MM/yyyy hh:mm:ss tt"
            };

            var numberFormat = new NumberFormatInfo
            {
                NumberDecimalSeparator = ".",
                CurrencyDecimalSeparator = ".",
                NumberGroupSeparator = ",",
                CurrencyGroupSeparator = ",",
                PercentDecimalSeparator = ".",
            };

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);

            //var test = CultureInfo.GetCultures(SpecificCultures);
            //var langs =new GetLanguages();
            var supportedCultures = new List<CultureInfo>
                                {
                                    new CultureInfo("sq"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("en"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("sr"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("tr"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("bs"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("ar"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("bg"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("ca"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("hr"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("cs"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("da"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("nl"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("fr"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("de"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("el"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("he"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("hi"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("hu"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("is"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("id"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("it"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("ja"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("ko"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("lv"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("lt"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("mk"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("be"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("bn"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("fo"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("ka"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("ks"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("lv"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("ml"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("no"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("pl"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("pt"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("ro"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("ru"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("sk"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("sl"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("es"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("sv"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("uk"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("se"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("vi"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("gl"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("gd"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("et"){DateTimeFormat = dateformat, NumberFormat = numberFormat},
                                    new CultureInfo("eu"){DateTimeFormat = dateformat, NumberFormat = numberFormat },
                                };


            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
            options.RequestCultureProviders = new[] {
                new RouteDataRequestCultureProvider()
                {
                    Options = options,
                    RouteDataStringKey = "lang",
                    UIRouteDataStringKey = "lang"
                }
            };
   
            options.SetDefaultCulture(supportedCultures.FirstOrDefault().Name);
        }
    }
}
