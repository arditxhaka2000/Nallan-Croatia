using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using Web.Infrastructure;
using Services.Languages;
using Web.Models;
using Services.Users;
using Web.Models.Userss;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Services.Enum;
using Services.Localizations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Documents;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;

namespace Web.Controllers
{
    [Authorize]
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class AdministrationController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILanguageService _languageService;
        private readonly IUsersService _usersService;
        private readonly ILocalizationsService _localizationService;
        private readonly IDocumentService _documentService;
        private readonly string basicPath = "";

        public AdministrationController(IMapper mapper,
            ILanguageService languageService,
            IUsersService usersService,
            ILocalizationsService localizationService,
            IDocumentService documentService,
            IWebHostEnvironment webHostEnvironment
         )
        {
            _mapper = mapper;
            _languageService = languageService;
            _usersService = usersService;
            _localizationService = localizationService;
            _documentService = documentService;
            _webHostEnvironment = webHostEnvironment;
            basicPath = Path.Combine(_webHostEnvironment.WebRootPath, "Documents");
        }

        #region users

        [Authorize(Roles = "Administrator")]
        public IActionResult Index(int page = 1, string searchName = null)
        {
            var pageSize = 10;
            var model = new IndexUsersViewModel();

            var users = _usersService.GetAllAsQuerable(searchName).ToPagedList(page, pageSize);

            List<UserAdminRowViewModel> models = new List<UserAdminRowViewModel>();
            users.ToList().ForEach(u =>
            {

                UserAdminRowViewModel ua = new UserAdminRowViewModel()
                {
                    Id = u.Id,
                    email = u.Email,
                    userName = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    active = u.active,
                    RoleId = this._usersService.GetRolesByUserId(u).Count() > 0 ? this._usersService.GetRolesByUserId(u)[0].ToString() : "",
                    DefaultLanguageId = u.DefaultLanguageId,
                    DefaultLanguage = _mapper.Map<LanguageViewModel>(u.DefaultLanguage),

                };
                models.Add(ua);
            });

            model.Users = _mapper.Map<List<UserAdminRowViewModel>>(models).ToPagedList(page, pageSize);
            model.Languages = _mapper.Map<List<LanguageViewModel>>(_languageService.GetAllActive());
            model.Roles = _mapper.Map<List<RolesViewModel>>(_usersService.GetAllRoles());
            //ViewBag.roles = string.Join(",", model.Roles.Select(c=>c.Name));


            //ViewBag.searchName = searchName;
            ViewBag.List = users;

            return View(model);

        }

        [HttpPost]
        [ClaimRequirement(Mode.CanEit, ControllerEnum.Administration)]
        public JsonResult AddUser(AddUser model)
        {
            var sharedRes = (Dictionary<string, string>)ViewData["Shared"];

            var mappedState = _mapper.Map<AppUser>(model);

            try
            {
                if (this._usersService.FindByUserName(model.UserName) != null)
                {
                    return Json(new { success = false, msg = sharedRes["THISUSEREXISTS"] });
                }


                if (this._usersService.FindByEmail(model.Email).Result != null)
                {
                    return Json(new { success = false, msg = sharedRes["THIS_EMAIL_EXISTS"] });
                }
                mappedState.PasswordHash = (new PasswordHasher<AppUser>()).HashPassword(mappedState, model.UserPassword);
                mappedState.NormalizedUserName = model.UserName;
                mappedState.NormalizedEmail = model.Email;
                mappedState.PhoneNumberConfirmed = true;
                mappedState.EmailConfirmed = true;
                mappedState.LockoutEnabled = true;

                if (model.UserName != null)
                {
                    this._usersService.Create(mappedState);
                }
                this._usersService.AddToRole(mappedState, model._Roles[0].ToString());

             

                return Json(new { success = true });
            }
            catch (Exception e)
            {
                return Json(new { success = false, msg = sharedRes["SOMETHING_WENT_WRONG"] });

            }

        }

        [HttpPost]
        [ClaimRequirement(Mode.CanEit, ControllerEnum.Administration)]
        public JsonResult UpdateUser(UpdateUser model)
        {
            var sharedRes = (Dictionary<string, string>)ViewData["Shared"];

            var user = this._usersService.FindByUserName(model.UserName);


            try
            {
                if (user == null)
                {
                    return Json(new { success = false, msg = sharedRes["USER_DOES_NOT_EXIST"] });
                }

                var requestUser4Update = new AppUser { Id = user.Id, Email = model.Email };
                var emailUser = this._usersService.FindByEmail(requestUser4Update);

                if (emailUser != null)
                {
                    return Json(new { success = false, msg = sharedRes["THIS_EMAIL_BELONGS_TO_OTHER_USER"] });
                }

                var mappedState = _mapper.Map<UpdateUser, AppUser>(model, user);


                _usersService.Update(mappedState);

                var currentRoles = this._usersService.GetRolesByUserId(mappedState);

                if (!string.IsNullOrEmpty(model._Roles[0].ToString()))
                {
                    this._usersService.RemoveFromRoles(mappedState, currentRoles[0].ToString());
                    this._usersService.AddToRole(mappedState, model._Roles[0].ToString());
                }

                return Json(new { success = true });
            }
            catch (Exception e)
            {

                return Json(new { success = false, msg = sharedRes["SOMETHING_WENT_WRONG"] });
            }

        }


        [HttpPost]
        [ClaimRequirement(Mode.CanEit, ControllerEnum.Administration)]
        public JsonResult ChangeUserPassWord(ChangePasswordModel model)
        {
            var sharedRes = (Dictionary<string, string>)ViewData["Shared"];

            var user = _usersService.FindByName(model.UserName);
            if (user.Result == null)
            {
                return Json(new { success = false, msg = sharedRes["USER_DOES_NOT_EXIST"] });
            }
            var editUser = _usersService.FindByName(user.Result.UserName);

            if (string.IsNullOrEmpty(model.newPassword) || string.IsNullOrWhiteSpace(model.newPassword))
            {
                return Json(new { success = false, msg = sharedRes["PASSWORD_REQUIRED"] });
            }
            editUser.Result.PasswordHash = (new PasswordHasher<AppUser>()).HashPassword(user.Result, model.newPassword);
            _usersService.Update(editUser.Result);
            return Json(new { success = true });

        }

        //Profile - User

        public IActionResult Profile()
        {
            var user = this._usersService.FindByUserName(User.Identity.Name);
            //var model = new ProfileIndex()
            //{
            //    id = user.Id,
            //    email = user.Email,
            //    userName = user.UserName,
            //    DefaultLanguageId = user.DefaultLanguageId
            //};

            var model = new ProfileIndexViewModel();

            model.Profile = _mapper.Map<ProfileIndex>(user);
            model.Language = _mapper.Map<List<LanguageViewModel>>(_languageService.GetAll());
            return View(model);
        }


        [ClaimRequirement(Mode.CanEit, ControllerEnum.Administration)]
        public JsonResult UpdateProfile(UpdateProfileModel model)
        {
            var sharedRes = (Dictionary<string, string>)ViewData["Shared"];

            var user = this._usersService.FindByUserName(User.Identity.Name);
            if (user == null)
            {
                return Json(new { success = false, msg = sharedRes["USER_DOES_NOT_EXIST"] });
            }
            var mappedState = _mapper.Map<UpdateProfileModel, AppUser>(model, user);
            _usersService.Update(mappedState);
            return Json(new { success = true, msg = sharedRes["RESETPASSWORDCONFIRMATION_MESSAGE"] });
        }

        //End

        #endregion



      
        [HttpGet]
        [ClaimRequirement(Mode.CanView, ControllerEnum.Administration)]
        public IActionResult LanguageList(int page = 1, string searchName = null, string searchCode = null, bool Active = false)
        {
            var pageSize = 10;
            var model = new LanguageListViewModel();
            var dbResult = _languageService.GetAllAsQuerable(searchName, searchCode, Active).ToPagedList(page, pageSize);
            model.list = _mapper.Map<List<LanguageViewModel>>(dbResult);
            ViewBag.searchName = searchName;
            ViewBag.searchCode = searchCode;
            ViewBag.Active = Active;
            ViewBag.List = dbResult;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ClaimRequirement(Mode.CanEit, ControllerEnum.Administration)]
        public JsonResult AddUpdateLanguage(AddUpdateLanguageListViewModel model)
        {
            if (model.Id == 0)
            {
                var language = new Language();
                var mappedState = _mapper.Map(model, language);
                _languageService.Insert(mappedState);
                _languageService.SaveChanges();
            }
            else
            {
                var dbResult = _languageService.GetById(model.Id);
                var mapped = _mapper.Map(model, dbResult);

                var otherLangsDb = _localizationService.GetAll(model.Id).Count();
                if (model.Active && otherLangsDb == 0)
                {
                    var albanianLocalizationsDb = _localizationService.GetAll(1);
                    albanianLocalizationsDb.ForEach(x => x.LanguageId = model.Id);
                    albanianLocalizationsDb.ForEach(x => x.Language = null);
                    albanianLocalizationsDb.ForEach(x => x.Id = 0);
                    _localizationService.InsertRange(albanianLocalizationsDb);
                    _localizationService.SaveChanges();
                }

                _languageService.Update(mapped);
                _languageService.SaveChanges();
            }
            return Json(new { success = true });
        }

    }
}