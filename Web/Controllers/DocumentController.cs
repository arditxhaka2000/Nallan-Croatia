using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Services.Documents;
using Services.Enum;
using Web.Models;
using X.PagedList;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Services.Languages;
using Web.Providers;
using Web.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Models.DocumentsVM;
using DocumentFormat.OpenXml.VariantTypes;
using MimeKit.Encodings;

namespace Web.Controllers
{
    //[Authorize(Roles = "Administrator, DataEntry, Shareholder, BankOfficer, CEO")]
    public class DocumentController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IDocumentService _DocumentService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILanguageService _languageService;

        private readonly Microsoft.Extensions.Configuration.IConfiguration configuration;
        private readonly string basicPath = "";
        private readonly string downloadDocuments = "";

        public DocumentController(IMapper mapper, IDocumentService DocumentService, Microsoft.Extensions.Configuration.IConfiguration configuration, ILanguageService languageService, IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
            _DocumentService = DocumentService;
            _webHostEnvironment = webHostEnvironment;
            basicPath = Path.Combine(_webHostEnvironment.WebRootPath, "Documents");
            this.configuration = configuration;
            _languageService = languageService;
            downloadDocuments = Path.Combine(_webHostEnvironment.WebRootPath, "DownloadableDocs");
        }


        [HttpGet]
        [ClaimRequirement(Mode.CanView, ControllerEnum.Document)]
        public IActionResult Index(Guid RootId, int page = 1, string searchName = null, int DocumetTypeId = 0)
        {
            var pageSize = 10;
            var model = new DocumentListViewModel();
            //model.Type = _mapper.Map<List<ListViewModel>>(_listService.GetListsByListTypeId(ListTypeEnum.Type));
            model.Languages = _mapper.Map<List<LanguageViewModel>>(_languageService.GetAllActive());
            //model.IssuingAuthority = _mapper.Map<List<ListViewModel>>(_listService.GetListsByListTypeId(ListTypeEnum.IssuingAuthority));
            //model.Access = _mapper.Map<List<ListViewModel>>(_listService.GetListsByListTypeId(ListTypeEnum.Access));
            var dbDocs = _DocumentService.GetAllAsQuerable(searchName, RootId, DocumetTypeId).ToPagedList(page, pageSize);
            var result = _mapper.Map<List<DocumentViewModel>>(dbDocs);
            model.Documents = result;
            ViewBag.searchName = searchName;
            ViewBag.List = dbDocs;
            ViewBag.DocumetTypeId = DocumetTypeId;
            model.RootId = RootId;



            return View(model);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Download(string filename)
        {
            if (filename == null)
                return Content("filename not present");


            // Path.Combine(this.Environment.WebRootPath, "Uploads");
            var path = Path.Combine(basicPath, filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, GetContentType(path), Path.GetFileName(path));
        }
        [ValidateAntiForgeryToken]
        [ClaimRequirement(Mode.CanEit, ControllerEnum.Document)]
        public JsonResult AddUpdatedocument(AddUpdateDocumentViewModel model, IFormFile file)
        {
            if (file == null)
            {
                return Json(new { success = false });
            }
            model.DocumentName = file.FileName;
            var mappedList = _mapper.Map<Document>(model);
            //var rootID = "48353566-60e2-4c4c-b6e3-08d8ef892f11";// kjo duhet me ardh prej Root-it
            //mappedList.RootId = Guid.Parse(rootID);// "48353566 -60e2-4c4c-b6e3-08d8ef892f11";
            _DocumentService.Insert(mappedList);
            UploadDocumentWithCodeLang(file, mappedList.Id, LanguagesDictionary.GetCodeFromLanguageId()[(int)mappedList.LanguageId].ToString());
            return Json(new { success = true });

        }

        private void UploadDocument(IFormFile file, Guid Id)
        {
            var pathExtension = Path.GetExtension(file.FileName);

            var fileName = Id.ToString() + CurrentLanguage + pathExtension;
            var path = Path.Combine(basicPath, fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                // file.CopyToAsync(stream);
                file.CopyTo(stream);
            }
        }



        [ValidateAntiForgeryToken]
        [ClaimRequirement(Mode.CanEit, ControllerEnum.Document)]
        public JsonResult Update(AddUpdateDocumentViewModel model)
        {
            try
            {
                var dbNodeMapped = _DocumentService.GetById(model.Id);
                var nodeTypeMapped = _mapper.Map(model, dbNodeMapped);
                _DocumentService.Update(nodeTypeMapped);
            }
            catch
            {
                return Json(new { success = false });
            }

            return Json(new { success = true });
        }

        [HttpPost]
        [ClaimRequirement(Mode.CanDelete, ControllerEnum.Document)]
        public JsonResult Delete(Guid Id)
        {
            try
            {
                var dbNodeMapped = _DocumentService.GetById(Id);

                _DocumentService.Delete(Id);


            }
            catch
            {
                return Json(new { success = false });
            }



            return Json(new { success = true });
        }


        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }


        [HttpGet]
        public ActionResult GetConfigurationValue4MaxFileLengthInMB()
        {
            const string sectionName = "MySettings", paramName = "MaxFileLengthInMB";
            var MaxFileLength = configuration[$"{sectionName}:{paramName}"];

            return Json(new { parameter = MaxFileLength });
        }
        [HttpGet]
        public ActionResult GetConfigurationValue4MaxFileLengthPoliticalPartyInMB()
        {
            const string sectionName = "MySettings", paramName = "MaxFileLengthPoliticalPartyInMB";
            var MaxFileLength = configuration[$"{sectionName}:{paramName}"];

            return Json(new { parameter = MaxFileLength });
        }
        [HttpGet]
        public ActionResult GetConfigurationValue4MaxFileLengthPollingCenterInMB()
        {
            const string sectionName = "MySettings", paramName = "MaxFileLengtPollingCenterInMB";
            var MaxFileLength = configuration[$"{sectionName}:{paramName}"];

            return Json(new { parameter = MaxFileLength });
        }
        [HttpGet]
        public ActionResult GetConfigurationValue4MaxFileLengthMaxFileLengtAbroadVoterInMB()
        {
            const string sectionName = "MySettings", paramName = "MaxFileLengtAbroadVoterInMB";
            var MaxFileLength = configuration[$"{sectionName}:{paramName}"];

            return Json(new { parameter = MaxFileLength });
        }
        [HttpGet]
        public ActionResult GetConfigurationValue4MaxFileLengthMaxFileLengtSpecialNeedsInMB()
        {
            const string sectionName = "MySettings", paramName = "MaxFileLengtSpecialNeedsInMB";
            var MaxFileLength = configuration[$"{sectionName}:{paramName}"];

            return Json(new { parameter = MaxFileLength });
        }

        public bool ValidateFileImage(IFormFile files)
        {
            if (files != null)
            {
                string fileName = files.FileName;
                var pathExtension = Path.GetExtension(fileName);
                if (files.Length > 0 || fileName != "")
                {
                    if (pathExtension.ToLower() == ".png" || pathExtension.ToLower() == ".jpg" || pathExtension.ToLower() == ".jpeg")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public IActionResult callAnyProcedure(string nameProcedure = "ReportPollingCenterChange")
        {
            var callProcedure = new ProcedureProvider(configuration);
            var model = new DynamicRowAndColumns();
            model = callProcedure.getProcedure(nameProcedure, "2020-1-1", "2024-1-1", 0, null);
            return View(model);
        }


        #region UploadDocuments

        [HttpPost]
        public JsonResult UploadDocumentsForAnyTable(UploadDocumentsViewModel model, IFormFile file)
        {
            if (file == null)
            {
                return Json(new { success = false });
            }
            model.DocumentName = file.FileName;
            var mappedList = _mapper.Map<Document>(model);
            _DocumentService.Insert(mappedList);
            UploadDocumentWithCodeLang(file, mappedList.Id, LanguagesDictionary.GetCodeFromLanguageId()[(int)mappedList.LanguageId].ToString());
            return Json(new { success = true });
        }

        private void UploadDocumentWithCodeLang(IFormFile file, Guid Id, string Code)
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
        #endregion


        #region DownloadableDocuments



        private void UploadDownloadedDocumentWithCodeLang(IFormFile file, Guid Id, string Code)
        {
            var pathExtension = Path.GetExtension(file.FileName);

            var fileName = Id.ToString() + Code + pathExtension;
            var path = Path.Combine(downloadDocuments, fileName);
            if (!Directory.Exists(downloadDocuments))
            {
                Directory.CreateDirectory(downloadDocuments);
            }
            using (var stream = new FileStream(path, FileMode.Create))
            {
                // file.CopyToAsync(stream);
                file.CopyTo(stream);
            }
        }

        [AllowAnonymous]
        public async Task<IActionResult> DownloadableDocs(string filename)
        {
            if (filename == null)
                return Content("filename not present");


            // Path.Combine(this.Environment.WebRootPath, "Uploads");
            var path = Path.Combine(downloadDocuments, filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        #endregion


        public IActionResult GetDocumentComponent(int listTypeId, bool isSearch = false, int? ElectionId = null)
        {
            return ViewComponent("DownloadableDocuments", new { ListTypeId = listTypeId, isSearch = isSearch, ElectionId = ElectionId });
        }

       

        [HttpPost]
        public JsonResult ValidateAnyFileByExeAndsize(IFormFile file)
        {
            if (file != null)
            {
                string fileName = file.FileName;
                var pathExtension = Path.GetExtension(fileName);
                string[] _extensions = { ".png", ".jpg", ".jpeg", ".pdf", ".doc", ".docx", ".xlsx" };
                if (file.Length > 0 || fileName != "")
                {
                    if (_extensions.Where(item => item.Equals(pathExtension.ToLower())).Any())
                    {
                        return Json(new { success = true });
                    }
                    else
                    {
                        return Json(new { success = false });
                    }
                }
                else
                {
                    return Json(new { success = false });
                }
            }
            else
            {
                return Json(new { success = false, msg = "Please upload file..." });
            }
        }

 

    }
}