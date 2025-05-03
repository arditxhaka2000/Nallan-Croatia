using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NuGet.Packaging;
using Repository;
using Services.Documents;
using Services.Emails;
using Services.Enum;
using Services.Languages;
using Services.Localizations;
using SimpleEmailApp.Services.EmailService;
using Web.Infrastructure;
using Web.Models.DocumentsVM;
using Web.Models.EmailConfig;
using Web.Models.Localizations;
using Web.Providers;
using static ClosedXML.Excel.XLPredefinedFormat;

namespace Web.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    //[MiddlewareFilter(typeof(MySampleActionFilter))]
    public class BaseController : Controller
    {
        protected string _currentLanguage;
        //private readonly IHttpContextAccessor _httpContextAccessor;
        protected ILocalizationsService _localizationService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDocumentService _documentService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly string basicPath = "";
        private readonly IEmailsService _emailsService;
        private readonly IEmailService _emailService;
        protected Dictionary<string, string> sharedRes;

        public string UserId { get; private set; }
        private List<int> _municipalityUserId { get; set; }
        public BaseController(IHttpContextAccessor httpContextAccessor)
        {

            _httpContextAccessor = httpContextAccessor;
            keyrovider.addValue = new List<string>();
        }

        public BaseController(IDocumentService documentService, IWebHostEnvironment webHostEnvironment, IMapper mapper, IConfiguration configuration, IEmailsService emailsService,
              IEmailService emailService)
        {
            _documentService = documentService;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
            basicPath = Path.Combine(_webHostEnvironment.WebRootPath, "Documents");
            _configuration = configuration;
            _emailService = emailService;
            _emailsService = emailsService;
        }
        
        public BaseController(IDocumentService documentService, IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {
            _documentService = documentService;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
            basicPath = Path.Combine(_webHostEnvironment.WebRootPath, "Documents");
        }
        public BaseController()
        {
            keyrovider.addValue = new List<string>();
        }

        public BaseController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

    
      

        public override void OnActionExecuting(ActionExecutingContext ctx)
        {
            UserId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Kthen Id e User-it
            base.OnActionExecuting(ctx);
            //var services = this.HttpContext.RequestServices;

            var currentLg = ctx.RouteData.Values["lang"].ToString();

            //var localizations = (ILocalizationsService)services.GetService(typeof(ILocalizationsService));
            //var dbResult = localizations.GetTokensByResKey(ResourceKeys.Shared);
            //dbResult = dbResult.Where(x=>x.Language.Code == currentLg).ToList();
            //var resource = dbResult.ToDictionary(x => x.KeyName, x => x.KeyValue);

            //var cache = (IMemoryCache)services.GetService(typeof(IMemoryCache));

            var result = GetCachedResource(currentLg);
            ViewData["Shared"] = result.ToDictionary(x => x.KeyName, x => x.KeyValue);
            sharedRes = (Dictionary<string, string>)ViewData["Shared"];

        }

        public override void OnActionExecuted(ActionExecutedContext ctx)
        {


            string actionName = ctx.ActionDescriptor.RouteValues["Action"].ToString();
            string controllerName = ctx.ActionDescriptor.RouteValues["Controller"].ToString();
            base.OnActionExecuted(ctx);
            ViewData["actionName"] = actionName;
            ViewData["controllerName"] = controllerName;
            // our code after action executes
        }
        public string GetResource(string key)
        {
            return sharedRes.CheckKey(key);
        }

        public List<Localization> GetCachedResource(string lang)
        {
            List<Localization> resource;

            var services = this.HttpContext.RequestServices;

            var cache = (IMemoryCache)services.GetService(typeof(IMemoryCache));

            if (!cache.TryGetValue("Shared", out resource))
            {
                var localizations = (ILocalizationsService)services.GetService(typeof(ILocalizationsService));
                resource = localizations.GetTokensByResKey(ResourceKeys.Shared);

                //= dbResult.ToDictionary(x => x.KeyName, x => x.KeyValue);

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(7));
                cache.Set("Shared", resource, cacheEntryOptions);
            }

            var returnedRes = resource.Where(x => x.Language.Code == lang).Distinct().ToList();

            if (returnedRes.Count() == 0)
            {
                returnedRes = resource.Where(x => x.Language.Code == "sq").Distinct().ToList();
            }

            return returnedRes;
        }


        [HttpPost]
        public JsonResult UploadDocumentsForAnyTable(UploadDocumentsViewModel model, IFormFile file)
        {
            if (file == null)
            {
                return Json(new { success = false });
            }
          
                model.DocumentName = file.FileName;
            var mappedList = _mapper.Map<Document>(model);
            _documentService.Insert(mappedList);
            UploadDocumentWithCodeLang(file, mappedList.Id, "sq");
            return Json(new { success = true });
        }
        [HttpPost]
        public JsonResult UploadDocs4ConditionalVoter(UploadDocumentsViewModel model, IFormFile file)
        {
            if (file == null)
            {
                return Json(new { success = false });
            }
            if (String.IsNullOrEmpty(model.DocumentName))
            {
                model.DocumentName = file.FileName;

            }
            var mappedList = _mapper.Map<Document>(model);
            _documentService.Insert(mappedList);
            InsertDoc(file, model.ConditionalVoterId);
            return Json(new { success = true });
        }
    

        public void UploadDocumentWithCodeLang(IFormFile file, Guid Id, string Code)
        {
            var pathExtension = Path.GetExtension(file.FileName);

            var fileName = Id.ToString() + Code + pathExtension;
            var path = Path.Combine(basicPath, fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                // file.CopyToAsync(stream);
                file.CopyTo(stream);
            }
        }

        public void InsertDoc(IFormFile file, Guid? Id)
        {
            var pathExtension = Path.GetExtension(file.FileName);

            var fileName = Id + pathExtension; 
            var path = Path.Combine(basicPath, fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                // file.CopyToAsync(stream);
                file.CopyTo(stream);
            }
        }



        public string UploadOnlyDocument(IFormFile file)
        {
            var pathExtension = Path.GetExtension(file.FileName);
            if (!Directory.Exists(basicPath))
            {
                Directory.CreateDirectory(basicPath);
            }
            var fileName = Guid.NewGuid().ToString() + pathExtension;
            var path = Path.Combine(basicPath, fileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return fileName;
        }


        public void ClearCachedResource()
        {
            var services = this.HttpContext.RequestServices;
            var cache = (IMemoryCache)services.GetService(typeof(IMemoryCache));
            cache.Remove("Shared");
        }




        public string CurrentLanguage
        {
            get
            {
                if (!string.IsNullOrEmpty(_currentLanguage))
                {
                    return _currentLanguage;
                }

                if (string.IsNullOrEmpty(_currentLanguage))
                {
                    var feature = HttpContext.Features.Get<IRequestCultureFeature>();
                    _currentLanguage = feature.RequestCulture.Culture.TwoLetterISOLanguageName.ToLower();
                }

                if (User.Identity.IsAuthenticated)
                {
                    try
                    {
                        _currentLanguage = User.FindFirst("LangCode")?.Value;

                    }
                    catch (Exception)
                    {

                    }
                }

                return _currentLanguage;
            }
        }

        public static string ExtractHtmlInnerText(string htmlText = "")
        {
            Regex regex = new Regex("(<.*?>\\s*)+", RegexOptions.Singleline);

            string resultText = regex.Replace(htmlText, " ").Trim();

            return resultText;
        }


        public static int GetCurrentLangID
        {
            get
            {
                string lang = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.ToUpperInvariant();
                int langId = LanguagesDictionary.LanguagesAsDictionary()[lang];
                return langId;
            }
        }

        public static string currentSystemLang
        {
            get
            {
                string lang = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.ToLowerInvariant();
                return lang;
            }
        }
        public string baseURL
        {
            get
            {
                var request = _httpContextAccessor.HttpContext.Request;
                var _baseURL = $"{request.Scheme}://{request.Host}";
                return _baseURL;
            }
        }

        public string GetApiUrl
        {
            get
            {
                var mainUrl = _configuration.GetValue<string>("APIConfiguration:URL");
                return mainUrl;
            }
        }

        public async Task<string> GetToken()
        {
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(GetApiUrl + "token")
                };
                try
                {
                    using (var response = await httpClient.SendAsync(request))
                    {

                        string apiResponse = await response.Content.ReadAsStringAsync();
                        //VotersViewModel returnData = JsonConvert.DeserializeObject<VotersViewModel>(apiResponse);
                        GetTokens myContent = JsonConvert.DeserializeObject<GetTokens>(apiResponse);
                        return "Bearer " + myContent.token;
                    }
                }
                catch (Exception ex)
                {
                    return "404";
                }

            }
        }

        public class GetTokens
        {
            public string token { get; set; }
        }


        public bool SendEmail(EmailConfiguration e, string Template)
        {
            e.Body = System.IO.File.ReadAllText(System.IO.Path.Combine("wwwroot", "html/") + Template);
            if (e.dynamictext != null)
            {
                for (int i = 0; i < e.dynamictext.Length; i++)
                {
                    e.Body = e.Body.Replace("{" + i + "}", e.dynamictext[i]);
                }
            }
            if (_emailService.SendEmailWithImageAndFile(e))
            {
                var _addOnTable = new List<SendEmail>();
                foreach (var email in e.ToAsBcc)
                {
                    _addOnTable.Add(new SendEmail { Body = e.Body, Subject = e.Subject, Date = System.DateTime.Now, EmailTo = email, IsSended = true, Queue = false, SendedFromSystem = true });
                }
                _emailsService.Insert(_addOnTable);
                return true;
            }
            else
            {
                var _addOnTable = new List<SendEmail>();
                foreach (var email in e.ToAsBcc)
                {
                    _addOnTable.Add(new SendEmail { Body = e.Body, Subject = e.Subject, Date = System.DateTime.Now, EmailTo = email, IsSended = false, Queue = true, SendedFromSystem = true });
                }
                _emailsService.Insert(_addOnTable);
                return false;
            }

        }

        [AllowAnonymous]
        public IActionResult DownloadFilesAsZip(List<DownloadDocumentsZipFileViewModel> files, string folderName, string zipFileName)
        {
            string tempDirectory = Path.Combine(_webHostEnvironment.WebRootPath, folderName);
            if (!Directory.Exists(tempDirectory))
            {
                return null;
            }
            if (files != null && files.Count > 0)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (var zip = new ZipArchive(ms, ZipArchiveMode.Create, true))
                    {
                        foreach (var file in files)
                        {
                            var fileForInfo = Path.Combine(tempDirectory, file.FileName).ToString();
                            if (System.IO.File.Exists(fileForInfo))
                            {
                                var fileInfo = new FileInfo(fileForInfo);
                                var entry = zip.CreateEntry(fileInfo.Name);
                                using (var entryStream = entry.Open())
                                using (var fileStream = new FileStream(fileForInfo, FileMode.Open, FileAccess.Read))
                                {
                                    fileStream.CopyTo(entryStream);
                                }
                            }
                        }
                    }
                    ms.Seek(0, SeekOrigin.Begin);
                    return File(ms.ToArray(), "application/zip", zipFileName);
                }
            }
            return null;
        }
    }

  

}


