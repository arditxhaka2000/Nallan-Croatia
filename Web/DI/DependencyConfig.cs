using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Documents;
using Services.Users;
using Services.Localizations;
using Data;
using Microsoft.AspNetCore.Identity;
using Web.Providers;
using Services.Privileges;
using Services.Histories;
using Microsoft.AspNetCore.Identity.UI.Services;
using Services.Emails;
using SimpleEmailApp.Services.EmailService;
using AspNetCore.ReCaptcha;
using Services.ProductServ;
using Services.Orders;
using Services.InstaApi;
using Services.TEBPayments;

namespace Web.DI
{
    public static class DependencyConfig
    {
        /// <summary>
        /// This method serves for registering types, as it can be seen: interface -> implementation
        /// </summary>
        /// <param name="services"></param>
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
     
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<ILocalizationsService, LocalizationsService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, ApplicationUserClaimsPrincipalFactory>();
            services.AddScoped<IUserActionRootRestRightService, UserActionRootRestRightService>();
            services.AddScoped<IActionRootService, ActionRootService>();
            services.AddScoped<IHistoryService, HistoryService>();
          
       

            services.AddScoped<IApiServices, ApiServices>();
            services.AddScoped<IInstagramApiService, InstagramApiService>();



            services.AddScoped<IEmailsService, EmailsService>();
            services.AddScoped<IEmailService, EmailService>();


            //teb implementation
            services.AddScoped<IHashService,HashService>();


            //prodcut serv

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductColorService, ProductColorService>();
            services.AddScoped<IProductSizeService, ProductSizeService>();
            services.AddScoped<ISizeService, SizeService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IImageService, ImageService>();


            //orders
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<IErpTempService, ErpTempService>();


        }
    }
}
