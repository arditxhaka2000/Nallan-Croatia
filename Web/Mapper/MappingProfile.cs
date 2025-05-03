using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Data.Privileges;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OA_Web.Models;
using Services.Enum;
using Web.Models;
using Web.Models.Localizations;
using Web.Models.RolesAndPrivileges;
using Web.Models.Userss;
using Repository;
using Web.Models.Histories;
using Web.Models.DocumentsVM;
using Web.Controllers;
using Web.Models.EmailConfig;
using Web.Models.SettingsVM;
using Web.Models.ImageVM;

namespace Web.Mapper
{
    public class MappingProfile : Profile
    {
        private int langId = 1;
        private string langCode = "sq";
        private string _date = "";

        private readonly IHttpContextAccessor _httpContextAccessor;
        public MappingProfile(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public MappingProfile()
        {
            CreateMap<HomeViewModel, ApiData>().ReverseMap();
            CreateMap<ApiProdDetails, ApiData>().ReverseMap();
            CreateMap<Product, ProductViewModel>();
            CreateMap<CreateProductViewModel, Product>();
     
            CreateMap<IdentityRole, RolesViewModel>().ForMember(d => d.Name, opt => opt.MapFrom(c => c.NormalizedName));
            CreateMap<ApplicationRole, RolesViewModel>().ForMember(d => d.Name, opt => opt.MapFrom(c => c.NormalizedName));

            CreateMap<Language, LanguageViewModel>();
            CreateMap<Language, LanguageViewModel>().ReverseMap();
            CreateMap<AddUpdateLanguageListViewModel, Language>();

            CreateMap<Localization, LocalizationViewModel>();
            CreateMap<Localization, LocalizationViewModel>().ReverseMap();
            CreateMap<CreateUpdateLocalizationViewModel, Localization>();
            CreateMap<UpdateLocalizationViewModel, Localization>();
            CreateMap<CreateUpdateLocalizationViewModel, UpdateLocalizationViewModel>();

            CreateMap<Document, DocumentViewModel>()
                     //.ForMember(d => d.FileName, opt => opt.MapFrom(c => c.Id.ToString() + GetCodeFromCurrentLangId() + Path.GetExtension(c.DocumentName)));
                     .ForMember(d => d.FileName, opt => opt.MapFrom(c => c.Id.ToString() + LanguagesDictionary.GetCodeFromLanguageId()[c.LanguageId] + Path.GetExtension(c.DocumentName)))
                     //.ForMember(d => d.UserName, opt => opt.MapFrom(c =>    {   return "";      })
                     .ForMember(d => d.SeenByUserName, opt => opt.MapFrom((c, d) => { if (c.SeenByUser != null) { return c.SeenByUser.FirstName + " " + c.SeenByUser.LastName; } else { return ""; } }));


            CreateMap<AddUpdateDocumentViewModel, Document>();

            CreateMap<Document, AddUpdateDocumentViewModel>();
            CreateMap<AppUser, UsersViewModel>();
            CreateMap<AddUser, AppUser>();
            CreateMap<UpdateUser, AppUser>();
            CreateMap<ChangePasswordModel, AppUser>();
            CreateMap<UpdateProfileModel, AppUser>();
            CreateMap<AppUser, ProfileIndex>();
            //SearchPortal

            CreateMap<Document, ScrollDocumentViewModel>()
                     .ForMember(d => d.FileName, opt => opt.MapFrom(c => c.Id.ToString() + GetCodeFromCurrentLangId() + Path.GetExtension(c.DocumentName)));

            CreateMap<ActionRoot, GetActionRootViewModel>();
            CreateMap<ActionRoot, GetUserActionRootRestRightViewModel>().ForMember(d => d.Name, opt => opt.MapFrom(c => c.NameAl))
                                                                        .ForMember(d => d.CodeName, opt => opt.MapFrom(c => c.CodeName))
                                                                        .ForMember(d => d.NameAl, opt => opt.MapFrom(c => c.NameAl));

            CreateMap<UserActionRootRestRight, GetUserActionRootRestRightViewModel>();
            CreateMap<GetUserActionRootRestRightViewModel, UserActionRootRestRight>();
            CreateMap<IdentityRole, GetIdentityRoleViewModel>();
            CreateMap<ApplicationRole, GetIdentityRoleViewModel>();
            CreateMap<IdentityRole, ApplicationRole>().ReverseMap();
            CreateMap<History, GetHistoryDetailViewModel>();
            CreateMap<History, GetHistoryViewModel>();
            CreateMap<History, HistoryViewModel>();




            CreateMap<UploadDocumentsViewModel, Document>();
            CreateMap<InserDoc4PolitaclPartyRegViewModel, Document>();




            //DownloadableDocuments

            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<CreateCategoryViewModel, Category>().ReverseMap();
            CreateMap<Color, ColorViewModel>().ReverseMap();
            CreateMap<Size, SizeViewModel>().ReverseMap();
            //CreateMap<ProductColor, ProductColorViewModel>().ForMember(d => d.ColorName, opt => opt.MapFrom(c => c.Color.Name));
            //CreateMap<ProductColorViewModel, ProductColor>();
            CreateMap<ProductColor, ProductColorViewModel>();
            CreateMap<ProductColorViewModel, ProductColor>();
            CreateMap<ProductSize, ProductSizeViewModel>();
            CreateMap<ProductSizeViewModel, ProductSize>();

            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<ProductCategoryViewModel, ProductCategory>();



            CreateMap<Image, ImageViewModel>();
            CreateMap<ImageViewModel, Image>();


            CreateMap<ErpTemp, ErpTempViewModel>();


            //Orders

            CreateMap<Order, OrdersViewModel>();
            CreateMap<OrdersViewModel, Order>();
            CreateMap<OrderItem, OrderItemViewModel>();
            CreateMap<OrderItemViewModel, OrderItem>();
            
            
            CreateMap<InstagramApi, InstagramMediaViewModel>().ReverseMap();


            CreateMap<SendEmail, EmailsViewModel>();



            CreateMap<Document, DownloadDocumentsZipFileViewModel>().ForMember(d => d.FileName, opt => opt.MapFrom(c => c.Id.ToString() + GetCodeFromCurrentLangId() + Path.GetExtension(c.DocumentName)));


        }

        private void initialDate(ResolutionContext context)
        {
            if (context != null && context.Items["Date"] != null)
            {
                _date = context.Items["Date"] + "";

            }
        }

        private void GetCurrentLangId()
        {
            string lang = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.ToUpperInvariant();

            langId = LanguagesDictionary.LanguagesAsDictionary()[lang];
        }

        private string HasValueDateTime(DateTime? dateTime)
        {
            if (dateTime.HasValue)
            {
                return dateTime.Value.ToShortDateString();
            }
            return null;
        }

        private string GetCodeFromCurrentLangId()
        {
            GetCurrentLangId();
            langCode = LanguagesDictionary.GetCodeFromLanguageId()[langId];
            return langCode;
        }


    }

    public interface IValueResolver<in TSource, in TDestination, TDestMember>
    {
        TDestMember Resolve(TSource source, TDestination destination, TDestMember destMember, ResolutionContext context);
    }
}
