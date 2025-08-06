using AspNetCore.ReCaptcha;
using AutoMapper;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using Repository;
using Services;
using Services.Languages;
using Services.Localizations;
using Services.Logs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web.Components;
using Web.Controllers;
using Web.DI;
using Web.Infrastructure;
using Web.Mapper;
using Web.Models.CorvusPay;
using Web.Models.Payments;
using Web.Providers;
using Web.Resources;
namespace OA_Web
{
    public class Startup
    {
        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) //load base settings
                 .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddReCaptcha(Configuration.GetSection("RecaptchaSettings"));
            var MaxFileLength = Configuration.GetValue<int>("MySettings:MaxFileLengthInMB");

            services.Configure<FormOptions>(x =>
            {
                x.MultipartBodyLengthLimit = 104857600;//100MB
            });

            //cart
            services.AddSession();
            services.AddDistributedMemoryCache(); // Required for session
            services.AddControllersWithViews();

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<ILog, LogNLog>();

            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging());

            services.AddIdentity<AppUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = true)
                       .AddEntityFrameworkStores<ApplicationContext>()
                       .AddDefaultTokenProviders();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUserRepository<>), typeof(UserRepository<>));
            services.AddScoped<ISecureCredentialsService, SecureCredentialsService>();
            // CorvusPay Configuration
            services.Configure<CorvusPaySettings>(Configuration.GetSection("CorvusPaySettings"));

            // Register CorvusPay Services
            services.AddScoped<Services.CorvusPayments.ISecureCredentialsService, Services.CorvusPayments.SecureCredentialsService>();
            services.AddScoped<Services.CorvusPayments.IPaymentSessionService, Services.CorvusPayments.PaymentSessionService>();

            services.AddDependencies();
            services.AddSession();

            services.AddControllersWithViews().AddNewtonsoftJson(options =>
                                                                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                                                            ).AddRazorRuntimeCompilation();
            services.AddRazorPages();

            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddControllersWithViews()
                    .AddDataAnnotationsLocalization(options =>
                    {
                        options.DataAnnotationLocalizerProvider = (type, factory) =>
                            factory.Create(typeof(Common));
                    })
                    .AddViewLocalization(LanguageViewLocationExpanderFormat.SubFolder)
                    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);

            services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("lang", typeof(LanguageRouteConstraint));
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllersWithViews().AddRazorPagesOptions(options =>
            {
                options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
                options.Conventions.AuthorizeAreaPage("Identity", "/Account/Register");
                options.Conventions.AddAreaFolderRouteModelConvention("Identity", "/Account/", model =>
                {
                    foreach (var x in model.Selectors)
                    {
                        if (x.AttributeRouteModel.Template.StartsWith("Identity"))
                        {
                            x.AttributeRouteModel = new AttributeRouteModel()
                            {
                                Order = -1,
                                Template = AttributeRouteModel.CombineTemplates(("{lang=hr}"), // Changed from 'sq' to 'hr'
                                    x.AttributeRouteModel.Template)
                            };
                        }
                    }
                });
                options.Conventions.AddFolderRouteModelConvention("/ListNodeType/",
                     model =>
                     {
                         foreach (var x in model.Selectors)
                         {
                             x.AttributeRouteModel = new AttributeRouteModel()
                             {
                                 Order = -1,
                                 Template = AttributeRouteModel.CombineTemplates(("{lang=hr}"), // Changed from 'sq' to 'hr'
                                                   x.AttributeRouteModel.Template)
                             };
                         }
                     });
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/hr/Identity/Account/Login"; // Changed from '/sq' to '/hr'
                options.LogoutPath = "/hr/Identity/Account/Logout";
                options.AccessDeniedPath = "/hr/Identity/Account/AccessDenied";
            });

            services.AddTransient<CustomLocalizer>();

            services.Configure<SecurityStampValidatorOptions>(o =>
            {
                o.ValidationInterval = TimeSpan.FromHours(24);
            });

            // Memory cache (required for session service)
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILog logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //cart
            app.UseSession(); // Use session

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.ConfigureExceptionHandler(logger);
            app.UseSession();

            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            LocalizationPipeline.ConfigureOptions(options.Value);

            app.UseRequestLocalization(options.Value);

            app.UseEndpoints(endpoints =>
            {
                //KJO e bon UnderConstruction faqen
                //app.UseMiddleware<UnderConstructionMiddleware>();

                endpoints.MapControllerRoute(
                   name: "Default",
                   pattern: "{lang:lang}/{controller=Home}/{action=Index}/{id?}"
               );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{*catchall}",
                    defaults: new { controller = "Home", action = "RedirectToDefaultLanguage", lang = "hr" } // Changed from 'sq' to 'hr'
                    );
                endpoints.MapRazorPages();
            });
        }
    }
}