using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AutoMapper;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OA_Web.Models;
using Repository;
using Services.Emails;
using Services.Languages;
using SimpleEmailApp.Services.EmailService;
using Web.Controllers;
using Web.Infrastructure;
using Web.Models;
using Web.Models.EmailConfig;
using ZXing.Common;
using ZXing;
using SkiaSharp;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Newtonsoft.Json;
using Services;
using Web.Models.SettingsVM;
using Services.ProductServ;
using System.Threading.Tasks;
using Services.InstaApi;
using Microsoft.AspNetCore.Authorization;
namespace OA_Web.Controllers
{


    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        protected readonly ILanguageService _languageService;
        private readonly IMapper _mapper;
        private readonly IEmailsService _emailsService;
        private readonly IEmailService _emailService;
        private readonly Microsoft.Extensions.Configuration.IConfiguration configuration;
        private readonly ApplicationContext _context;
        private readonly IConfiguration _config;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IApiServices _apiServices;
        private readonly IInstagramApiService _instagramAPi;
        public HomeController(ILogger<HomeController> logger, ILanguageService languageService, IMapper mapper,
            Microsoft.Extensions.Configuration.IConfiguration configuration, IProductService productService,
            ApplicationContext context,
              IEmailsService emailsService,
              ICategoryService categoryService,
              IInstagramApiService instagramAPi,
              IApiServices apiServices
              ,
              IEmailService emailService, IConfiguration config) : base()
        {
            this._logger = logger;
            _languageService = languageService;
            _mapper = mapper;
            this.configuration = configuration;
            _context = context;
            _emailService = emailService;
            _emailsService = emailsService;
            _config = config;
            _productService = productService;
            _categoryService = categoryService;
            _apiServices = apiServices;
            _instagramAPi = instagramAPi;
        }



        public async Task<IActionResult> Index()
        {
            var lang = CurrentLanguage;
            ViewBag.Lang = lang;

            var model = new HomeViewModel();

            // Wait for the async method to complete and fetch data
            var prodDB = await _apiServices.GetAllAsync();
            var filteredProducts = prodDB
    .Where(product => product.ImageUrls != null && product.ImageUrls.Any())
    .ToList();
            // Extract category name from product title and ensure distinct categories
            var distinctCategoryProducts = filteredProducts
                .GroupBy(product =>
                {
                    var categoryName = product.Title.Split('-').Skip(1).FirstOrDefault(); // Text between first and second hyphen
                    return categoryName?.Trim();
                })
                .Where(group => !string.IsNullOrEmpty(group.Key)) // Filter out empty category names
                .Select(group => group.First()) // Select the first product from each distinct category
                .Take(4) // Limit to 4 products
                .ToList();

            // Map to ApiData model and assign to Products
            model.Products = _mapper.Map<List<ApiData>>(distinctCategoryProducts);
            //model.Products = _mapper.Map<List<ApiData>>(prodDB).Take(4).ToList();
            var categoryDb = _categoryService.GetAll();
            model.Categories = _mapper.Map<List<CategoryViewModel>>(categoryDb);
            // Map the result to the view model after data is fetched

            var categoryViewModels = filteredProducts
        .Select(product =>
        {
            var name = product.Title.Split('-').Skip(1).FirstOrDefault(); // Get text between first and second hyphen
            var image = product.ImageUrls?.FirstOrDefault(); // Get the first image URL

            return new ApiCategoryViewModel
            {
                Name = name,
                Image = image
            };
        })
        .DistinctBy(viewModel => viewModel.Name) // Ignore duplicates
        .ToList(); 
            
            var categoryViewModelss = filteredProducts
        .Select(product =>
        {
            var name = product.Title.Split('-').Skip(1).FirstOrDefault(); // Get text between first and second hyphen
            var image = product.ImageUrls?.FirstOrDefault(); // Get the first image URL

            return new CategoryViewModel
            {
                Name = name,
                Image = image
            };
        })
        .DistinctBy(viewModel => viewModel.Name) // Ignore duplicates
        .ToList();

            model.Categories = categoryViewModelss;

            model.ApiCategories = categoryViewModels;
            //var instaDatas = await _instagramAPi.GetInstagramMediaAsync();
            //model.InstaData = _mapper.Map<List<InstagramMediaViewModel>>(instaDatas);
            var instaDatas = new List<InstagramApi>();
            try
            {
                instaDatas = await _instagramAPi.GetInstagramMediaAsync();
                model.InstaData = _mapper.Map<List<InstagramMediaViewModel>>(instaDatas);
            }
            catch (Exception ex)
            {

                   var fallbackData = new List<InstagramMediaViewModel>
                {
                    new InstagramMediaViewModel
                    {
                        id = "fallback",
                        media_type = "TEXT",
                        media_url = "",
                    }
                };

                model.InstaData = fallbackData;  // Assign the fallback data to InstaData
                Console.WriteLine($"Instagram API fetch failed: {ex.Message}");
            }


            return View(model);
        }
        [AllowAnonymous]
        public IActionResult Catalog()
        {
            return View();
        }

        public IActionResult SendEmail(string code = "15072023000007")
        {
            EmailConfiguration e = new EmailConfiguration();
            e.Subject = "Porosi e re ne Nallan";
            e.Body = System.IO.File.ReadAllText(Path.Combine("wwwroot", "html/") + "AbroadVoters-approve.html");
            e.ToAsBcc = new List<string>() { "denis.shalaku@harrisia.com" };
            if (_emailService.SendEmailWithImageAndFile(e))
            {
                var _addOnTable = new List<SendEmail>();
                foreach (var email in e.ToAsBcc)
                {
                    _addOnTable.Add(new SendEmail { Body = e.Body, Subject = e.Subject, Date = DateTime.Now, EmailTo = email, IsSended = true, Queue = false, SendedFromSystem = true });
                }
                _emailsService.Insert(_addOnTable);
                return Json(new { success = true, msg = "Email-i eshte derguar me sukses!" });
            }
            else
            {
                var _addOnTable = new List<SendEmail>();
                foreach (var email in e.ToAsBcc)
                {
                    _addOnTable.Add(new SendEmail { Body = e.Body, Subject = e.Subject, Date = DateTime.Now, EmailTo = email, IsSended = false, Queue = true, SendedFromSystem = true });
                }
                _emailsService.Insert(_addOnTable);
                return Json(new { success = false, msg = "Ju lutemi kontrolloni email-at" });
            }
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int Id)
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, StatusCode = Id });
        }

        public ActionResult RedirectToDefaultLanguage()
        {
            var lang = CurrentLanguage;
            var dbLanguages = _languageService.GetAllActive().Where(x => x.Code == lang);
            if (dbLanguages == null)
            {
                lang = "sq";
            }
            return RedirectToAction("Index", new { lang = lang });
        }
        public IActionResult UnderConstruction()
        {
            return View();
        }
    }
}