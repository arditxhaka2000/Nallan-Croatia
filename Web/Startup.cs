using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository;
using Microsoft.EntityFrameworkCore;
using Services;
using AutoMapper;
using Web.Mapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Web.Infrastructure;
using Microsoft.AspNetCore.Mvc.Razor;
using Web.Resources;
using Services.Languages;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Web.DI;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http.Features;
using Services.Localizations;
using Web.Controllers;
using Services.Logs;
using Web.Providers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AspNetCore.ReCaptcha;
using Web.Components;

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
            //  services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Documents")));
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


            //services.AddDbContext<ApplicationContext>(options => options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging());
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging());


            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationContext>();

            services.AddIdentity<AppUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = true)
                       // services.AddDefaultIdentity<IdentityUser>()
                       .AddEntityFrameworkStores<ApplicationContext>()
                       .AddDefaultTokenProviders();
            
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUserRepository<>), typeof(UserRepository<>));

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
                                              Template = AttributeRouteModel.CombineTemplates(("{lang=sq}"),
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
                                          // if (x.AttributeRouteModel.Template.StartsWith("Identity"))
                                          {
                                              x.AttributeRouteModel = new AttributeRouteModel()
                                              {
                                                  Order = -1,
                                                  Template = AttributeRouteModel.CombineTemplates(("{lang=sq}"),
                                                      x.AttributeRouteModel.Template)
                                              };
                                          }
                                      }
                                  }



                                  );
                          });



            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/sq/Identity/Account/Login";
                options.LogoutPath = "/sq/Identity/Account/Logout";
                options.AccessDeniedPath = "/sq/Identity/Account/AccessDenied";
            });

            services.AddTransient<CustomLocalizer>();

            //var cultureInfo = new CultureInfo("en-US");
            //cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
            //cultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            //CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            //CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;


            //services.Configure<RecaptchaSettings>(Configuration.GetSection("RecaptchaSettings"));

            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.Cookie.Name = "AspNetCore.Identity.Application";
            //    options.ExpireTimeSpan = TimeSpan.FromHours(24);
            //    options.SlidingExpiration = true;
            //});

            services.Configure<SecurityStampValidatorOptions>(o =>
            {
                o.ValidationInterval = TimeSpan.FromHours(24);
            });

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //app.UseFileServer(new FileServerOptions
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Documents")),
            //    RequestPath = "/StaticFiles",
            //    EnableDirectoryBrowsing = true

            //});
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
                //endpoints.MapControllerRoute(
                //    name: "costum",
                //    pattern: "{lang:lang}/{controller=PollingCenter}/{action=ActualPollingCenter}"
                //);

                //KJo e bon UnderConstruction faqen
                app.UseMiddleware<UnderConstructionMiddleware>();

                endpoints.MapControllerRoute(
                   name: "Default",
                   pattern: "{lang:lang}/{controller=Home}/{action=Index}/{id?}"
               );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{*catchall}",
                    defaults: new { controller = "Home", action = "RedirectToDefaultLanguage", lang = "sq" }
                    );
                endpoints.MapRazorPages();
            });
        }

   

      

    }
}
